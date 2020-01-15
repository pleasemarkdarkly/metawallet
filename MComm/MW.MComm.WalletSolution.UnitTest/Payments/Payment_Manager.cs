

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

namespace MW.MComm.WalletSolution.UnitTest.Payments
{
    // ------------------------------------------------------------------------------
    /// <summary>This class contains support methods to test Payment instances.</summary>
    ///
    /// File History:
    /// <created>7/31/2007 (Brian MacDonald)</created>
    ///
    /// <remarks></remarks>
    // ------------------------------------------------------------------------------
    public partial class Payment_Manager
    {

		#region Properties
        #endregion Properties

        #region Constructors

        // ------------------------------------------------------------------------------
        /// <summary>This method is the constructor (currently does nothing).</summary>
        // ------------------------------------------------------------------------------
        public Payment_Manager()
        {
            //
            // constructor logic
            //
        }

        #endregion Constructors

		#region Methods

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add Payment items.</summary>
        // ------------------------------------------------------------------------------
        public static void PopulateItem(BLL.Payments.Payment item, MOD.Data.NamedObjectCollection useCollections, bool performCascade, bool isAddOperation, bool isCollectionOperation, MOD.Test.TestResults results)
        {
            if (item == null)
            {
                return;
            }

            //
            // populate the Payment item
            //
            int totalRecords = 0;
            bool totalRecordsExceeded = false;
            if (isAddOperation == true)
            {
                item.PaymentID = TestHelper.GetGuid();
            }
            item.PaymentAmount = TestHelper.GetDecimal(-1000000, 1000000);
            item.PaymentSubtotal = TestHelper.GetDecimal(-1000000, 1000000);
            item.PaymentTax = TestHelper.GetDecimal(-1000000, 1000000);
            item.PaymentServiceCharge = TestHelper.GetDecimal(-1000000, 1000000);
            totalRecords = 0;
            totalRecordsExceeded = false;
            BLL.SortableList<BLL.Orders.Order> itemOrderOrderID = null;
            if (useCollections != null && useCollections["Orders.Order"] != null)
            {
                itemOrderOrderID = (BLL.SortableList<BLL.Orders.Order>)useCollections["Orders.Order"];
            }
            if (itemOrderOrderID == null || itemOrderOrderID.Count <= 0)
            {
                itemOrderOrderID = BLL.Orders.OrderManager.GetManyOrderDataByCriteria(null, null, null, null, out totalRecords, out totalRecordsExceeded, Globals.getDataOptions("","",1,200,2000));
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
            }
            if (itemOrderOrderID.Count > 0)
            {
                int index = TestHelper.GetInt(0, Math.Max(0, itemOrderOrderID.Count-1));
                item.OrderID = itemOrderOrderID[index].OrderID;
            }
            else
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Could not find values for Order.", null);
            }
            if (isAddOperation == true)
            {
                totalRecords = 0;
                totalRecordsExceeded = false;
                BLL.SortableList<BLL.Accounts.Account> itemAccountDebitMetaPartnerID = null;
                if (useCollections != null && useCollections["Accounts.Account"] != null)
                {
                    itemAccountDebitMetaPartnerID = (BLL.SortableList<BLL.Accounts.Account>)useCollections["Accounts.Account"];
                }
                if (itemAccountDebitMetaPartnerID == null || itemAccountDebitMetaPartnerID.Count <= 0)
                {
                    itemAccountDebitMetaPartnerID = BLL.Accounts.AccountManager.GetManyAccountDataByCriteria(null, null, null, null, null, out totalRecords, out totalRecordsExceeded, Globals.getDataOptions("","",1,200,2000));
                    results.TotalRecords = totalRecords;
                    results.TotalRecordsExceeded = totalRecordsExceeded;
                }
                if (itemAccountDebitMetaPartnerID.Count > 0)
                {
                    int index = TestHelper.GetInt(0, Math.Max(0, itemAccountDebitMetaPartnerID.Count-1));
                    item.SourceAccountID = itemAccountDebitMetaPartnerID[index].AccountID;
                    item.DebitMetaPartnerID = itemAccountDebitMetaPartnerID[index].MetaPartnerID;
                }
                else
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "Could not find values for Account.", null);
                }
            }
            if (isAddOperation == true)
            {
                totalRecords = 0;
                totalRecordsExceeded = false;
                BLL.SortableList<BLL.Accounts.Account> itemAccountSourceAccountID = null;
                if (useCollections != null && useCollections["Accounts.Account"] != null)
                {
                    itemAccountSourceAccountID = (BLL.SortableList<BLL.Accounts.Account>)useCollections["Accounts.Account"];
                }
                if (itemAccountSourceAccountID == null || itemAccountSourceAccountID.Count <= 0)
                {
                    itemAccountSourceAccountID = BLL.Accounts.AccountManager.GetManyAccountDataByCriteria(null, null, null, null, null, out totalRecords, out totalRecordsExceeded, Globals.getDataOptions("","",1,200,2000));
                    results.TotalRecords = totalRecords;
                    results.TotalRecordsExceeded = totalRecordsExceeded;
                }
                if (itemAccountSourceAccountID.Count > 0)
                {
                    int index = TestHelper.GetInt(0, Math.Max(0, itemAccountSourceAccountID.Count-1));
                    item.SourceAccountID = itemAccountSourceAccountID[index].AccountID;
                    item.DebitMetaPartnerID = itemAccountSourceAccountID[index].MetaPartnerID;
                }
                else
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "Could not find values for Account.", null);
                }
            }
            if (isAddOperation == true)
            {
                totalRecords = 0;
                totalRecordsExceeded = false;
                BLL.SortableList<BLL.Accounts.Account> itemAccountCreditMetaPartnerID = null;
                if (useCollections != null && useCollections["Accounts.Account"] != null)
                {
                    itemAccountCreditMetaPartnerID = (BLL.SortableList<BLL.Accounts.Account>)useCollections["Accounts.Account"];
                }
                if (itemAccountCreditMetaPartnerID == null || itemAccountCreditMetaPartnerID.Count <= 0)
                {
                    itemAccountCreditMetaPartnerID = BLL.Accounts.AccountManager.GetManyAccountDataByCriteria(null, null, null, null, null, out totalRecords, out totalRecordsExceeded, Globals.getDataOptions("","",1,200,2000));
                    results.TotalRecords = totalRecords;
                    results.TotalRecordsExceeded = totalRecordsExceeded;
                }
                if (itemAccountCreditMetaPartnerID.Count > 0)
                {
                    int index = TestHelper.GetInt(0, Math.Max(0, itemAccountCreditMetaPartnerID.Count-1));
                    item.DestinationAccountID = itemAccountCreditMetaPartnerID[index].AccountID;
                    item.CreditMetaPartnerID = itemAccountCreditMetaPartnerID[index].MetaPartnerID;
                }
                else
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "Could not find values for Account.", null);
                }
            }
            if (isAddOperation == true)
            {
                totalRecords = 0;
                totalRecordsExceeded = false;
                BLL.SortableList<BLL.Accounts.Account> itemAccountDestinationAccountID = null;
                if (useCollections != null && useCollections["Accounts.Account"] != null)
                {
                    itemAccountDestinationAccountID = (BLL.SortableList<BLL.Accounts.Account>)useCollections["Accounts.Account"];
                }
                if (itemAccountDestinationAccountID == null || itemAccountDestinationAccountID.Count <= 0)
                {
                    itemAccountDestinationAccountID = BLL.Accounts.AccountManager.GetManyAccountDataByCriteria(null, null, null, null, null, out totalRecords, out totalRecordsExceeded, Globals.getDataOptions("","",1,200,2000));
                    results.TotalRecords = totalRecords;
                    results.TotalRecordsExceeded = totalRecordsExceeded;
                }
                if (itemAccountDestinationAccountID.Count > 0)
                {
                    int index = TestHelper.GetInt(0, Math.Max(0, itemAccountDestinationAccountID.Count-1));
                    item.DestinationAccountID = itemAccountDestinationAccountID[index].AccountID;
                    item.CreditMetaPartnerID = itemAccountDestinationAccountID[index].MetaPartnerID;
                }
                else
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "Could not find values for Account.", null);
                }
            }
            BLL.SortableList<BLL.Payments.PaymentStatus> itemPaymentStatusPaymentStatusCode = null;
            if (useCollections != null && useCollections["Payments.PaymentStatus"] != null)
            {
                itemPaymentStatusPaymentStatusCode = (BLL.SortableList<BLL.Payments.PaymentStatus>)useCollections["Payments.PaymentStatus"];
            }
            if (itemPaymentStatusPaymentStatusCode == null || itemPaymentStatusPaymentStatusCode.Count <= 0)
            {
                itemPaymentStatusPaymentStatusCode = BLL.Payments.PaymentStatusManager.GetAllPaymentStatusData();
            }
            if (itemPaymentStatusPaymentStatusCode.Count > 0)
            {
                int index = TestHelper.GetInt(0, Math.Max(0, itemPaymentStatusPaymentStatusCode.Count-1));
                item.PaymentStatusCode = itemPaymentStatusPaymentStatusCode[index].PaymentStatusCode;
            }
            else
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Could not find values for PaymentStatus.", null);
            }
            item.PaymentStatusMessage = TestHelper.GetString(null, 1000);

            //
            // collections
            //
            if (performCascade == true && isAddOperation == true)
            {
                int collectionLoadCount = 0;
                collectionLoadCount = TestHelper.GetInt(Globals.MinimumLoadCountPerCollection, Globals.MaximumLoadCountPerCollection);
                TestHelper.ReportValueToConsole("PopulateItem: Next collection load count", collectionLoadCount);
                item.PaymentTransactionLogList = new BLL.SortableList<BLL.Payments.PaymentTransactionLog>();
                BLL.Payments.PaymentTransactionLog vPaymentTransactionLogList = null;
                for (int j=0; j < collectionLoadCount; j++)
                {
                    vPaymentTransactionLogList = new BLL.Payments.PaymentTransactionLog();
                    MW.MComm.WalletSolution.UnitTest.Payments.PaymentTransactionLog_Manager.PopulateItem(vPaymentTransactionLogList, useCollections, false, true, true, results);
                    results.IsCollision = false;
                    try
                    {
                        BLL.Payments.PaymentTransactionLog item2 = BLL.Payments.PaymentTransactionLogManager.GetOnePaymentTransactionLog(vPaymentTransactionLogList.PaymentTransactionLogID);
                        if (item2 != null)
                        {
                            results.IsCollision = true;
                            Console.WriteLine("Add collision encountered for PaymentTransactionLog: " + item2.PrimaryKey.ToString());
                        }
                    }
                    catch (UnitTestException ex)
                    {
                        throw ex;
                    }
                    catch (System.Exception ex)
                    {
                        throw new UnitTestException(UnitTestErrorType.Warning, "Get failed for PaymentTransactionLog", ex);
                    }
                    if (results.IsCollision == false)
                    {
                        item.PaymentTransactionLogList.Add(vPaymentTransactionLogList);
                    }
                }
            }
            PopulateItemCleanup(item, useCollections, performCascade, isAddOperation, isCollectionOperation, results);
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add Payment items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Payments.Payment AddOnePaymentTest(bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // add item
            //
            BLL.Payments.Payment item = new BLL.Payments.Payment();
            MOD.Data.NamedObjectCollection useCollections = new MOD.Data.NamedObjectCollection();
            BLL.SortableList<BLL.Payments.Payment> itemsPaymentsPayment = new BLL.SortableList<BLL.Payments.Payment>();
            itemsPaymentsPayment.Add((BLL.Payments.Payment)item);
            useCollections["Payments.Payment"] = itemsPaymentsPayment;
            Payment_Manager.PopulateItem(item, useCollections, performCascade, true, false, results);
            results.IsCollision = false; // discard collection collisions
            BLL.Payments.Payment item2 = null;
            try
            {
                item2 = BLL.Payments.PaymentManager.GetOnePayment(item.PaymentID);
            }
            catch (UnitTestException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Get failed for Payment: " + item.PrimaryKey.ToString(), ex);
            }
            if (item2 != null)
            {
                results.IsCollision = true;
                throw new UnitTestException(UnitTestErrorType.Warning, "Add collision encountered for Payment: " + item.PrimaryKey.ToString(), null);
            }
            if (results.IsCollision == false)
            {
                try
                {
                    if (IsValidForAdd(item, performCascade, results) == true)
                    {
                        startTicks = DateTime.Now.Ticks;
                        BLL.Payments.PaymentManager.UpsertOnePayment(item, performCascade);
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
        /// <summary>This method is used to update Payment items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Payments.Payment UpdateOnePaymentTest(Guid paymentID, bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get and update item
            //
            BLL.Payments.Payment item = new BLL.Payments.Payment();
            try
            {
                item = BLL.Payments.PaymentManager.GetOnePayment(paymentID);
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
            BLL.SortableList<BLL.Payments.Payment> itemsPaymentsPayment = new BLL.SortableList<BLL.Payments.Payment>();
            itemsPaymentsPayment.Add((BLL.Payments.Payment)item);
            useCollections["Payments.Payment"] = itemsPaymentsPayment;
            Payment_Manager.PopulateItem(item, useCollections, performCascade, false, false, results);
            try
            {
                if (IsValidForUpdate(item, performCascade, results) == true)
                {
                    startTicks = DateTime.Now.Ticks;
                    BLL.Payments.PaymentManager.UpsertOnePayment(item, performCascade);
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
        /// <summary>This method is used to get Payment items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.Payments.Payment> GetAllPaymentDataTest(MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get all items
            //
            try
            {
                startTicks = DateTime.Now.Ticks;
                BLL.SortableList<BLL.Payments.Payment> items = BLL.Payments.PaymentManager.GetAllPaymentData();
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
        /// <summary>This method is used to get a set of Payment items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.Payments.Payment> GetManyPaymentDataByCriteriaTest(MOD.Data.DataOptions dataOptions, MOD.Test.TestResults results)
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
                NamedObjectCollection nocPaymentStatusCode = new NamedObjectCollection();
                NamedObjectCollection nocLastModifiedDate = new NamedObjectCollection();
                startTicks = DateTime.Now.Ticks;
                BLL.SortableList<BLL.Payments.Payment> items =  BLL.Payments.PaymentManager.GetManyPaymentDataByCriteria(null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                BLL.SortableList<BLL.Payments.Payment> specificItems = null;
                string specificWarnings = String.Empty;
                bool searchValueUsed = false;
                int paramCount = 0;
                if (items.Count < 1)
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "No items found in GetManyPaymentDataByCriteria generic search.", null);
                }
                paramCount = 0;
                foreach (BLL.Payments.Payment item in items)
                {
                    nocPaymentStatusCode[TestHelper.GetStringKeyFromObject((object)(item.PaymentStatusCode), paramCount)] = item.PaymentStatusCode;
                    nocLastModifiedDate[TestHelper.GetStringKeyFromObject((object)(item.LastModifiedDate), paramCount)] = item.LastModifiedDate;
                    paramCount++;
                }
                paramCount = 0;
                int itemPaymentStatusCode = TestHelper.GetInt(null, null, nocPaymentStatusCode, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Payments.PaymentManager.GetManyPaymentDataByCriteria(itemPaymentStatusCode, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyPaymentDataByCriteria search with PaymentStatusCode = " + itemPaymentStatusCode.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                DateTime itemLastModifiedDate = TestHelper.GetDateTime(null, null, nocLastModifiedDate, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Payments.PaymentManager.GetManyPaymentDataByCriteria(null, itemLastModifiedDate, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyPaymentDataByCriteria search with LastModifiedDate = " + itemLastModifiedDate.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                if (specificWarnings != String.Empty)
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "Results were not returned for GetManyPaymentDataByCriteria specific searches.", new Exception(specificWarnings));
                }
                return items;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to delete Payment items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Payments.Payment DeleteOnePaymentTest(Guid paymentID, bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get and delete item
            //
            BLL.Payments.Payment item = new BLL.Payments.Payment();
            try
            {
                item = BLL.Payments.PaymentManager.GetOnePayment(paymentID);
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
                    BLL.Payments.PaymentManager.DeleteOnePayment(item, performCascade);
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