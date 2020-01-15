

/*<copyright>
Meta Wallet, Inc (c) 2007 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2007, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/
using System;
using System.Xml;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using MOD.Data;
using MOD.Test;
using MbUnit.Framework;
using MbUnit.Core;
using MW.MComm.WalletSolution.BLL.Config;
using BLL = MW.MComm.WalletSolution.BLL;
using Utility = MW.MComm.WalletSolution.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace MW.MComm.WalletSolution.UnitTest.Customers
{
    // ------------------------------------------------------------------------------
    /// <summary>This class contains support methods to test MetaPartner instances.</summary>
    ///
    /// File History:
    /// <created>7/31/2007 (Brian MacDonald)</created>
    ///
    /// <remarks></remarks>
    // ------------------------------------------------------------------------------
    public partial class MetaPartner_Manager
    {

		#region Properties
        #endregion Properties

        #region Constructors

        // ------------------------------------------------------------------------------
        /// <summary>This method is the constructor (currently does nothing).</summary>
        // ------------------------------------------------------------------------------
        public MetaPartner_Manager()
        {
            //
            // constructor logic
            //
        }

        #endregion Constructors

		#region Methods

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add MetaPartner items.</summary>
        // ------------------------------------------------------------------------------
        public static void PopulateItem(BLL.Customers.MetaPartner item, MOD.Data.NamedObjectCollection useCollections, bool performCascade, bool isAddOperation, bool isCollectionOperation, MOD.Test.TestResults results)
        {
            if (item == null)
            {
                return;
            }

            //
            // populate the MetaPartner item
            //
            if (isAddOperation == true)
            {
                item.MetaPartnerID = TestHelper.GetGuid();
            }
            BLL.SortableList<BLL.Customers.MetaPartnerSubType> itemMetaPartnerSubTypeMetaPartnerSubTypeCode = null;
            if (useCollections != null && useCollections["Customers.MetaPartnerSubType"] != null)
            {
                itemMetaPartnerSubTypeMetaPartnerSubTypeCode = (BLL.SortableList<BLL.Customers.MetaPartnerSubType>)useCollections["Customers.MetaPartnerSubType"];
            }
            if (itemMetaPartnerSubTypeMetaPartnerSubTypeCode == null || itemMetaPartnerSubTypeMetaPartnerSubTypeCode.Count <= 0)
            {
                itemMetaPartnerSubTypeMetaPartnerSubTypeCode = BLL.Customers.MetaPartnerSubTypeManager.GetAllMetaPartnerSubTypeData();
            }
            if (itemMetaPartnerSubTypeMetaPartnerSubTypeCode.Count > 0)
            {
                int index = TestHelper.GetInt(0, Math.Max(0, itemMetaPartnerSubTypeMetaPartnerSubTypeCode.Count-1));
                item.MetaPartnerSubTypeCode = itemMetaPartnerSubTypeMetaPartnerSubTypeCode[index].MetaPartnerSubTypeCode;
            }
            else
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Could not find values for MetaPartnerSubType.", null);
            }
            BLL.SortableList<BLL.Environments.Locale> itemLocaleLocaleCode = null;
            if (useCollections != null && useCollections["Environments.Locale"] != null)
            {
                itemLocaleLocaleCode = (BLL.SortableList<BLL.Environments.Locale>)useCollections["Environments.Locale"];
            }
            if (itemLocaleLocaleCode == null || itemLocaleLocaleCode.Count <= 0)
            {
                itemLocaleLocaleCode = BLL.Environments.LocaleManager.GetAllLocaleData();
            }
            if (itemLocaleLocaleCode.Count > 0)
            {
                int index = TestHelper.GetInt(0, Math.Max(0, itemLocaleLocaleCode.Count-1));
                item.LocaleCode = itemLocaleLocaleCode[index].LocaleCode;
            }
            else
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Could not find values for Locale.", null);
            }
            BLL.SortableList<BLL.Accounts.Currency> itemCurrencyCurrencyCode = null;
            if (useCollections != null && useCollections["Accounts.Currency"] != null)
            {
                itemCurrencyCurrencyCode = (BLL.SortableList<BLL.Accounts.Currency>)useCollections["Accounts.Currency"];
            }
            if (itemCurrencyCurrencyCode == null || itemCurrencyCurrencyCode.Count <= 0)
            {
                itemCurrencyCurrencyCode = BLL.Accounts.CurrencyManager.GetAllCurrencyData();
            }
            if (itemCurrencyCurrencyCode.Count > 0)
            {
                int index = TestHelper.GetInt(0, Math.Max(0, itemCurrencyCurrencyCode.Count-1));
                item.CurrencyCode = itemCurrencyCurrencyCode[index].CurrencyCode;
            }
            else
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Could not find values for Currency.", null);
            }
            BLL.SortableList<BLL.Environments.DateFormat> itemDateFormatDateFormatCode = null;
            if (useCollections != null && useCollections["Environments.DateFormat"] != null)
            {
                itemDateFormatDateFormatCode = (BLL.SortableList<BLL.Environments.DateFormat>)useCollections["Environments.DateFormat"];
            }
            if (itemDateFormatDateFormatCode == null || itemDateFormatDateFormatCode.Count <= 0)
            {
                itemDateFormatDateFormatCode = BLL.Environments.DateFormatManager.GetAllDateFormatData();
            }
            if (itemDateFormatDateFormatCode.Count > 0)
            {
                int index = TestHelper.GetInt(0, Math.Max(0, itemDateFormatDateFormatCode.Count-1));
                item.DateFormatCode = itemDateFormatDateFormatCode[index].DateFormatCode;
            }
            else
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Could not find values for DateFormat.", null);
            }
            item.TaxCode = TestHelper.GetString(null, 100);
            item.IsActive = TestHelper.GetNullableBool();
            item.MetaPartnerName = TestHelper.GetString(null, 255);
            item.PictureImageURL = TestHelper.GetURL(null, 255);

            //
            // collections
            //
            if (performCascade == true && isAddOperation == true)
            {
                int collectionLoadCount = 0;
                collectionLoadCount = TestHelper.GetInt(Globals.MinimumLoadCountPerCollection, Globals.MaximumLoadCountPerCollection);
                TestHelper.ReportValueToConsole("PopulateItem: Next collection load count", collectionLoadCount);
                item.PhoneList = new BLL.SortableList<BLL.Customers.MetaPartnerPhone>();
                BLL.Customers.MetaPartnerPhone vPhoneList = null;
                for (int j=0; j < collectionLoadCount; j++)
                {
                    vPhoneList = new BLL.Customers.MetaPartnerPhone();
                    MW.MComm.WalletSolution.UnitTest.Customers.MetaPartnerPhone_Manager.PopulateItem(vPhoneList, useCollections, false, true, true, results);
                    results.IsCollision = false;
                    try
                    {
                        BLL.Customers.MetaPartnerPhone item2 = BLL.Customers.MetaPartnerPhoneManager.GetOneMetaPartnerPhone(vPhoneList.MetaPartnerPhoneID);
                        if (item2 != null)
                        {
                            results.IsCollision = true;
                            Console.WriteLine("Add collision encountered for MetaPartnerPhone: " + item2.PrimaryKey.ToString());
                        }
                    }
                    catch (UnitTestException ex)
                    {
                        throw ex;
                    }
                    catch (System.Exception ex)
                    {
                        throw new UnitTestException(UnitTestErrorType.Warning, "Get failed for MetaPartnerPhone", ex);
                    }
                    if (results.IsCollision == false)
                    {
                        item.PhoneList.Add(vPhoneList);
                    }
                }
                collectionLoadCount = TestHelper.GetInt(Globals.MinimumLoadCountPerCollection, Globals.MaximumLoadCountPerCollection);
                TestHelper.ReportValueToConsole("PopulateItem: Next collection load count", collectionLoadCount);
                item.EmailList = new BLL.SortableList<BLL.Customers.MetaPartnerEmail>();
                BLL.Customers.MetaPartnerEmail vEmailList = null;
                for (int j=0; j < collectionLoadCount; j++)
                {
                    vEmailList = new BLL.Customers.MetaPartnerEmail();
                    MW.MComm.WalletSolution.UnitTest.Customers.MetaPartnerEmail_Manager.PopulateItem(vEmailList, useCollections, false, true, true, results);
                    results.IsCollision = false;
                    try
                    {
                        BLL.Customers.MetaPartnerEmail item2 = BLL.Customers.MetaPartnerEmailManager.GetOneMetaPartnerEmail(vEmailList.MetaPartnerEmailID);
                        if (item2 != null)
                        {
                            results.IsCollision = true;
                            Console.WriteLine("Add collision encountered for MetaPartnerEmail: " + item2.PrimaryKey.ToString());
                        }
                    }
                    catch (UnitTestException ex)
                    {
                        throw ex;
                    }
                    catch (System.Exception ex)
                    {
                        throw new UnitTestException(UnitTestErrorType.Warning, "Get failed for MetaPartnerEmail", ex);
                    }
                    if (results.IsCollision == false)
                    {
                        item.EmailList.Add(vEmailList);
                    }
                }
                collectionLoadCount = TestHelper.GetInt(Globals.MinimumLoadCountPerCollection, Globals.MaximumLoadCountPerCollection);
                TestHelper.ReportValueToConsole("PopulateItem: Next collection load count", collectionLoadCount);
                item.LocationList = new BLL.SortableList<BLL.Customers.Location>();
                BLL.Customers.Location vLocationList = null;
                for (int j=0; j < collectionLoadCount; j++)
                {
                    vLocationList = new BLL.Customers.Location();
                    MW.MComm.WalletSolution.UnitTest.Customers.Location_Manager.PopulateItem(vLocationList, useCollections, false, true, true, results);
                    results.IsCollision = false;
                    try
                    {
                        BLL.Customers.Location item2 = BLL.Customers.LocationManager.GetOneLocation(vLocationList.LocationID);
                        if (item2 != null)
                        {
                            results.IsCollision = true;
                            Console.WriteLine("Add collision encountered for Location: " + item2.PrimaryKey.ToString());
                        }
                    }
                    catch (UnitTestException ex)
                    {
                        throw ex;
                    }
                    catch (System.Exception ex)
                    {
                        throw new UnitTestException(UnitTestErrorType.Warning, "Get failed for Location", ex);
                    }
                    if (results.IsCollision == false)
                    {
                        item.LocationList.Add(vLocationList);
                    }
                }
                collectionLoadCount = TestHelper.GetInt(Globals.MinimumLoadCountPerCollection, Globals.MaximumLoadCountPerCollection);
                TestHelper.ReportValueToConsole("PopulateItem: Next collection load count", collectionLoadCount);
                item.BankAccountList = new BLL.SortableList<BLL.Accounts.BankAccount>();
                BLL.Accounts.BankAccount vBankAccountList = null;
                for (int j=0; j < collectionLoadCount; j++)
                {
                    vBankAccountList = new BLL.Accounts.BankAccount();
                    MW.MComm.WalletSolution.UnitTest.Accounts.BankAccount_Manager.PopulateItem(vBankAccountList, useCollections, false, true, true, results);
                    results.IsCollision = false;
                    try
                    {
                        BLL.Accounts.BankAccount item2 = BLL.Accounts.BankAccountManager.GetOneBankAccount(vBankAccountList.AccountID);
                        if (item2 != null)
                        {
                            results.IsCollision = true;
                            Console.WriteLine("Add collision encountered for BankAccount: " + item2.PrimaryKey.ToString());
                        }
                    }
                    catch (UnitTestException ex)
                    {
                        throw ex;
                    }
                    catch (System.Exception ex)
                    {
                        throw new UnitTestException(UnitTestErrorType.Warning, "Get failed for BankAccount", ex);
                    }
                    if (results.IsCollision == false)
                    {
                        item.BankAccountList.Add(vBankAccountList);
                    }
                }
                collectionLoadCount = TestHelper.GetInt(Globals.MinimumLoadCountPerCollection, Globals.MaximumLoadCountPerCollection);
                TestHelper.ReportValueToConsole("PopulateItem: Next collection load count", collectionLoadCount);
                item.StoredValueAccountList = new BLL.SortableList<BLL.Accounts.StoredValueAccount>();
                BLL.Accounts.StoredValueAccount vStoredValueAccountList = null;
                for (int j=0; j < collectionLoadCount; j++)
                {
                    vStoredValueAccountList = new BLL.Accounts.StoredValueAccount();
                    MW.MComm.WalletSolution.UnitTest.Accounts.StoredValueAccount_Manager.PopulateItem(vStoredValueAccountList, useCollections, false, true, true, results);
                    results.IsCollision = false;
                    try
                    {
                        BLL.Accounts.StoredValueAccount item2 = BLL.Accounts.StoredValueAccountManager.GetOneStoredValueAccount(vStoredValueAccountList.AccountID);
                        if (item2 != null)
                        {
                            results.IsCollision = true;
                            Console.WriteLine("Add collision encountered for StoredValueAccount: " + item2.PrimaryKey.ToString());
                        }
                    }
                    catch (UnitTestException ex)
                    {
                        throw ex;
                    }
                    catch (System.Exception ex)
                    {
                        throw new UnitTestException(UnitTestErrorType.Warning, "Get failed for StoredValueAccount", ex);
                    }
                    if (results.IsCollision == false)
                    {
                        item.StoredValueAccountList.Add(vStoredValueAccountList);
                    }
                }
                collectionLoadCount = TestHelper.GetInt(Globals.MinimumLoadCountPerCollection, Globals.MaximumLoadCountPerCollection);
                TestHelper.ReportValueToConsole("PopulateItem: Next collection load count", collectionLoadCount);
                item.CreditAccountList = new BLL.SortableList<BLL.Accounts.CreditAccount>();
                BLL.Accounts.CreditAccount vCreditAccountList = null;
                for (int j=0; j < collectionLoadCount; j++)
                {
                    vCreditAccountList = new BLL.Accounts.CreditAccount();
                    MW.MComm.WalletSolution.UnitTest.Accounts.CreditAccount_Manager.PopulateItem(vCreditAccountList, useCollections, false, true, true, results);
                    results.IsCollision = false;
                    try
                    {
                        BLL.Accounts.CreditAccount item2 = BLL.Accounts.CreditAccountManager.GetOneCreditAccount(vCreditAccountList.AccountID);
                        if (item2 != null)
                        {
                            results.IsCollision = true;
                            Console.WriteLine("Add collision encountered for CreditAccount: " + item2.PrimaryKey.ToString());
                        }
                    }
                    catch (UnitTestException ex)
                    {
                        throw ex;
                    }
                    catch (System.Exception ex)
                    {
                        throw new UnitTestException(UnitTestErrorType.Warning, "Get failed for CreditAccount", ex);
                    }
                    if (results.IsCollision == false)
                    {
                        item.CreditAccountList.Add(vCreditAccountList);
                    }
                }
                collectionLoadCount = TestHelper.GetInt(Globals.MinimumLoadCountPerCollection, Globals.MaximumLoadCountPerCollection);
                TestHelper.ReportValueToConsole("PopulateItem: Next collection load count", collectionLoadCount);
                item.FundAccountList = new BLL.SortableList<BLL.Accounts.FundAccount>();
                BLL.Accounts.FundAccount vFundAccountList = null;
                for (int j=0; j < collectionLoadCount; j++)
                {
                    vFundAccountList = new BLL.Accounts.FundAccount();
                    MW.MComm.WalletSolution.UnitTest.Accounts.FundAccount_Manager.PopulateItem(vFundAccountList, useCollections, false, true, true, results);
                    results.IsCollision = false;
                    try
                    {
                        BLL.Accounts.FundAccount item2 = BLL.Accounts.FundAccountManager.GetOneFundAccount(vFundAccountList.AccountID);
                        if (item2 != null)
                        {
                            results.IsCollision = true;
                            Console.WriteLine("Add collision encountered for FundAccount: " + item2.PrimaryKey.ToString());
                        }
                    }
                    catch (UnitTestException ex)
                    {
                        throw ex;
                    }
                    catch (System.Exception ex)
                    {
                        throw new UnitTestException(UnitTestErrorType.Warning, "Get failed for FundAccount", ex);
                    }
                    if (results.IsCollision == false)
                    {
                        item.FundAccountList.Add(vFundAccountList);
                    }
                }
                collectionLoadCount = TestHelper.GetInt(Globals.MinimumLoadCountPerCollection, Globals.MaximumLoadCountPerCollection);
                TestHelper.ReportValueToConsole("PopulateItem: Next collection load count", collectionLoadCount);
                item.BillPayAccountList = new BLL.SortableList<BLL.Accounts.BillPayAccount>();
                BLL.Accounts.BillPayAccount vBillPayAccountList = null;
                for (int j=0; j < collectionLoadCount; j++)
                {
                    vBillPayAccountList = new BLL.Accounts.BillPayAccount();
                    MW.MComm.WalletSolution.UnitTest.Accounts.BillPayAccount_Manager.PopulateItem(vBillPayAccountList, useCollections, false, true, true, results);
                    results.IsCollision = false;
                    try
                    {
                        BLL.Accounts.BillPayAccount item2 = BLL.Accounts.BillPayAccountManager.GetOneBillPayAccount(vBillPayAccountList.AccountID);
                        if (item2 != null)
                        {
                            results.IsCollision = true;
                            Console.WriteLine("Add collision encountered for BillPayAccount: " + item2.PrimaryKey.ToString());
                        }
                    }
                    catch (UnitTestException ex)
                    {
                        throw ex;
                    }
                    catch (System.Exception ex)
                    {
                        throw new UnitTestException(UnitTestErrorType.Warning, "Get failed for BillPayAccount", ex);
                    }
                    if (results.IsCollision == false)
                    {
                        item.BillPayAccountList.Add(vBillPayAccountList);
                    }
                }
                collectionLoadCount = TestHelper.GetInt(Globals.MinimumLoadCountPerCollection, Globals.MaximumLoadCountPerCollection);
                TestHelper.ReportValueToConsole("PopulateItem: Next collection load count", collectionLoadCount);
                item.MetaTransferAccountList = new BLL.SortableList<BLL.Accounts.MetaTransferAccount>();
                BLL.Accounts.MetaTransferAccount vMetaTransferAccountList = null;
                for (int j=0; j < collectionLoadCount; j++)
                {
                    vMetaTransferAccountList = new BLL.Accounts.MetaTransferAccount();
                    MW.MComm.WalletSolution.UnitTest.Accounts.MetaTransferAccount_Manager.PopulateItem(vMetaTransferAccountList, useCollections, false, true, true, results);
                    results.IsCollision = false;
                    try
                    {
                        BLL.Accounts.MetaTransferAccount item2 = BLL.Accounts.MetaTransferAccountManager.GetOneMetaTransferAccount(vMetaTransferAccountList.AccountID);
                        if (item2 != null)
                        {
                            results.IsCollision = true;
                            Console.WriteLine("Add collision encountered for MetaTransferAccount: " + item2.PrimaryKey.ToString());
                        }
                    }
                    catch (UnitTestException ex)
                    {
                        throw ex;
                    }
                    catch (System.Exception ex)
                    {
                        throw new UnitTestException(UnitTestErrorType.Warning, "Get failed for MetaTransferAccount", ex);
                    }
                    if (results.IsCollision == false)
                    {
                        item.MetaTransferAccountList.Add(vMetaTransferAccountList);
                    }
                }
                collectionLoadCount = TestHelper.GetInt(Globals.MinimumLoadCountPerCollection, Globals.MaximumLoadCountPerCollection);
                TestHelper.ReportValueToConsole("PopulateItem: Next collection load count", collectionLoadCount);
                item.LoanAccountList = new BLL.SortableList<BLL.Accounts.LoanAccount>();
                BLL.Accounts.LoanAccount vLoanAccountList = null;
                for (int j=0; j < collectionLoadCount; j++)
                {
                    vLoanAccountList = new BLL.Accounts.LoanAccount();
                    MW.MComm.WalletSolution.UnitTest.Accounts.LoanAccount_Manager.PopulateItem(vLoanAccountList, useCollections, false, true, true, results);
                    results.IsCollision = false;
                    try
                    {
                        BLL.Accounts.LoanAccount item2 = BLL.Accounts.LoanAccountManager.GetOneLoanAccount(vLoanAccountList.AccountID);
                        if (item2 != null)
                        {
                            results.IsCollision = true;
                            Console.WriteLine("Add collision encountered for LoanAccount: " + item2.PrimaryKey.ToString());
                        }
                    }
                    catch (UnitTestException ex)
                    {
                        throw ex;
                    }
                    catch (System.Exception ex)
                    {
                        throw new UnitTestException(UnitTestErrorType.Warning, "Get failed for LoanAccount", ex);
                    }
                    if (results.IsCollision == false)
                    {
                        item.LoanAccountList.Add(vLoanAccountList);
                    }
                }
                collectionLoadCount = TestHelper.GetInt(Globals.MinimumLoadCountPerCollection, Globals.MaximumLoadCountPerCollection);
                TestHelper.ReportValueToConsole("PopulateItem: Next collection load count", collectionLoadCount);
                item.MetaPartnerCouponList = new BLL.SortableList<BLL.Promotions.MetaPartnerCoupon>();
                BLL.Promotions.MetaPartnerCoupon vMetaPartnerCouponList = null;
                for (int j=0; j < collectionLoadCount; j++)
                {
                    vMetaPartnerCouponList = new BLL.Promotions.MetaPartnerCoupon();
                    MW.MComm.WalletSolution.UnitTest.Promotions.MetaPartnerCoupon_Manager.PopulateItem(vMetaPartnerCouponList, useCollections, false, true, true, results);
                    results.IsCollision = false;
                    try
                    {
                        BLL.Promotions.MetaPartnerCoupon item2 = BLL.Promotions.MetaPartnerCouponManager.GetOneMetaPartnerCoupon(vMetaPartnerCouponList.MetaPartnerCouponID);
                        if (item2 != null)
                        {
                            results.IsCollision = true;
                            Console.WriteLine("Add collision encountered for MetaPartnerCoupon: " + item2.PrimaryKey.ToString());
                        }
                    }
                    catch (UnitTestException ex)
                    {
                        throw ex;
                    }
                    catch (System.Exception ex)
                    {
                        throw new UnitTestException(UnitTestErrorType.Warning, "Get failed for MetaPartnerCoupon", ex);
                    }
                    if (results.IsCollision == false)
                    {
                        item.MetaPartnerCouponList.Add(vMetaPartnerCouponList);
                    }
                }
            }
            PopulateItemCleanup(item, useCollections, performCascade, isAddOperation, isCollectionOperation, results);
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add MetaPartner items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Customers.MetaPartner AddOneMetaPartnerTest(bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // add item
            //
            BLL.Customers.MetaPartner item = new BLL.Customers.MetaPartner();
            MOD.Data.NamedObjectCollection useCollections = new MOD.Data.NamedObjectCollection();
            BLL.SortableList<BLL.Customers.MetaPartner> itemsCustomersMetaPartner = new BLL.SortableList<BLL.Customers.MetaPartner>();
            itemsCustomersMetaPartner.Add((BLL.Customers.MetaPartner)item);
            useCollections["Customers.MetaPartner"] = itemsCustomersMetaPartner;
            MetaPartner_Manager.PopulateItem(item, useCollections, performCascade, true, false, results);
            results.IsCollision = false; // discard collection collisions
            BLL.Customers.MetaPartner item2 = null;
            try
            {
                item2 = BLL.Customers.MetaPartnerManager.GetOneMetaPartner(item.MetaPartnerID);
            }
            catch (UnitTestException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Get failed for MetaPartner: " + item.PrimaryKey.ToString(), ex);
            }
            if (item2 != null)
            {
                results.IsCollision = true;
                throw new UnitTestException(UnitTestErrorType.Warning, "Add collision encountered for MetaPartner: " + item.PrimaryKey.ToString(), null);
            }
            if (results.IsCollision == false)
            {
                try
                {
                    if (IsValidForAdd(item, performCascade, results) == true)
                    {
                        startTicks = DateTime.Now.Ticks;
                        BLL.Customers.MetaPartnerManager.UpsertOneMetaPartner(item, performCascade);
                        endTicks = DateTime.Now.Ticks;
                        results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                    }
                }
                catch (UnitTestException ex)
                {
                    throw ex;
                }
                catch (System.Exception ex)
                {
                    throw new System.Exception(ex.Message + " {primary key: " + item.PrimaryKey + "}", ex);
                }
            }
            return item;
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to update MetaPartner items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Customers.MetaPartner UpdateOneMetaPartnerTest(Guid metaPartnerID, bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get and update item
            //
            BLL.Customers.MetaPartner item = new BLL.Customers.MetaPartner();
            try
            {
                item = BLL.Customers.MetaPartnerManager.GetOneMetaPartner(metaPartnerID);
            }
            catch (UnitTestException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message + " {primary key: " + item.PrimaryKey + "}", ex);
            }
            MOD.Data.NamedObjectCollection useCollections = new MOD.Data.NamedObjectCollection();
            BLL.SortableList<BLL.Customers.MetaPartner> itemsCustomersMetaPartner = new BLL.SortableList<BLL.Customers.MetaPartner>();
            itemsCustomersMetaPartner.Add((BLL.Customers.MetaPartner)item);
            useCollections["Customers.MetaPartner"] = itemsCustomersMetaPartner;
            MetaPartner_Manager.PopulateItem(item, useCollections, performCascade, false, false, results);
            try
            {
                if (IsValidForUpdate(item, performCascade, results) == true)
                {
                    startTicks = DateTime.Now.Ticks;
                    BLL.Customers.MetaPartnerManager.UpsertOneMetaPartner(item, performCascade);
                    endTicks = DateTime.Now.Ticks;
                    results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                }
            }
            catch (UnitTestException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message + " {primary key: " + item.PrimaryKey + "}", ex);
            }
            return item;
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to get MetaPartner items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.Customers.MetaPartner> GetAllMetaPartnerDataTest(MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get all items
            //
            try
            {
                startTicks = DateTime.Now.Ticks;
                BLL.SortableList<BLL.Customers.MetaPartner> items = BLL.Customers.MetaPartnerManager.GetAllMetaPartnerData();
                endTicks = DateTime.Now.Ticks;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                return items;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to get a set of MetaPartner items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.Customers.MetaPartner> GetManyMetaPartnerDataByCriteriaTest(MOD.Data.DataOptions dataOptions, MOD.Test.TestResults results)
        {
            int totalRecords = 0;
            bool totalRecordsExceeded = false;
            long startTicks = 0;
            long endTicks = 0;
            //
            // get a set of items
            //
            try
            {
                NamedObjectCollection nocMetaPartnerSubTypeCode = new NamedObjectCollection();
                NamedObjectCollection nocLocaleCode = new NamedObjectCollection();
                NamedObjectCollection nocCurrencyCode = new NamedObjectCollection();
                NamedObjectCollection nocDateFormatCode = new NamedObjectCollection();
                NamedObjectCollection nocLastModifiedDate = new NamedObjectCollection();
                NamedObjectCollection nocMetaPartnerName = new NamedObjectCollection();
                startTicks = DateTime.Now.Ticks;
                BLL.SortableList<BLL.Customers.MetaPartner> items =  BLL.Customers.MetaPartnerManager.GetManyMetaPartnerDataByCriteria(null, null, null, null, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                BLL.SortableList<BLL.Customers.MetaPartner> specificItems = null;
                string specificWarnings = String.Empty;
                bool searchValueUsed = false;
                int paramCount = 0;
                if (items.Count < 1)
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "No items found in GetManyMetaPartnerDataByCriteria generic search.", null);
                }
                paramCount = 0;
                foreach (BLL.Customers.MetaPartner item in items)
                {
                    nocMetaPartnerSubTypeCode[TestHelper.GetStringKeyFromObject((object)(item.MetaPartnerSubTypeCode), paramCount)] = item.MetaPartnerSubTypeCode;
                    nocLocaleCode[TestHelper.GetStringKeyFromObject((object)(item.LocaleCode), paramCount)] = item.LocaleCode;
                    nocCurrencyCode[TestHelper.GetStringKeyFromObject((object)(item.CurrencyCode), paramCount)] = item.CurrencyCode;
                    nocDateFormatCode[TestHelper.GetStringKeyFromObject((object)(item.DateFormatCode), paramCount)] = item.DateFormatCode;
                    nocLastModifiedDate[TestHelper.GetStringKeyFromObject((object)(item.LastModifiedDate), paramCount)] = item.LastModifiedDate;
                    nocMetaPartnerName[TestHelper.GetStringKeyFromObject((object)(item.MetaPartnerName), paramCount)] = item.MetaPartnerName;
                    paramCount++;
                }
                paramCount = 0;
                int itemMetaPartnerSubTypeCode = TestHelper.GetInt(null, null, nocMetaPartnerSubTypeCode, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Customers.MetaPartnerManager.GetManyMetaPartnerDataByCriteria(itemMetaPartnerSubTypeCode, null, null, null, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyMetaPartnerDataByCriteria search with MetaPartnerSubTypeCode = " + itemMetaPartnerSubTypeCode.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                int itemLocaleCode = TestHelper.GetInt(null, null, nocLocaleCode, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Customers.MetaPartnerManager.GetManyMetaPartnerDataByCriteria(null, itemLocaleCode, null, null, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyMetaPartnerDataByCriteria search with LocaleCode = " + itemLocaleCode.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                int itemCurrencyCode = TestHelper.GetInt(null, null, nocCurrencyCode, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Customers.MetaPartnerManager.GetManyMetaPartnerDataByCriteria(null, null, itemCurrencyCode, null, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyMetaPartnerDataByCriteria search with CurrencyCode = " + itemCurrencyCode.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                int itemDateFormatCode = TestHelper.GetInt(null, null, nocDateFormatCode, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Customers.MetaPartnerManager.GetManyMetaPartnerDataByCriteria(null, null, null, itemDateFormatCode, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyMetaPartnerDataByCriteria search with DateFormatCode = " + itemDateFormatCode.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                DateTime itemLastModifiedDate = TestHelper.GetDateTime(null, null, nocLastModifiedDate, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Customers.MetaPartnerManager.GetManyMetaPartnerDataByCriteria(null, null, null, null, itemLastModifiedDate, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyMetaPartnerDataByCriteria search with LastModifiedDate = " + itemLastModifiedDate.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                string itemMetaPartnerName = TestHelper.GetString(null, 255, nocMetaPartnerName, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Customers.MetaPartnerManager.GetManyMetaPartnerDataByCriteria(null, null, null, null, null, null, itemMetaPartnerName, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyMetaPartnerDataByCriteria search with MetaPartnerName = " + itemMetaPartnerName.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                if (specificWarnings != String.Empty)
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "Results were not returned for GetManyMetaPartnerDataByCriteria specific searches.", new Exception(specificWarnings));
                }
                return items;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to delete MetaPartner items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Customers.MetaPartner DeleteOneMetaPartnerTest(Guid metaPartnerID, bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get and delete item
            //
            BLL.Customers.MetaPartner item = new BLL.Customers.MetaPartner();
            try
            {
                item = BLL.Customers.MetaPartnerManager.GetOneMetaPartner(metaPartnerID);
            }
            catch (UnitTestException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message + item.PrimaryKey, ex);
            }
            try
            {
                if (IsValidForDelete(item, performCascade, results) == true)
                {
                    startTicks = DateTime.Now.Ticks;
                    BLL.Customers.MetaPartnerManager.DeleteOneMetaPartner(item, performCascade);
                    endTicks = DateTime.Now.Ticks;
                    results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                }
            }
            catch (UnitTestException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message + item.PrimaryKey, ex);
            }
            return item;
        }

        #endregion Methods
    }
}