

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

namespace MW.MComm.WalletSolution.UnitTest.Accounts
{
    // ------------------------------------------------------------------------------
    /// <summary>This class contains support methods to test LoanAccount instances.</summary>
    ///
    /// File History:
    /// <created>7/31/2007 (Brian MacDonald)</created>
    ///
    /// <remarks></remarks>
    // ------------------------------------------------------------------------------
    public partial class LoanAccount_Manager
    {

		#region Properties
        #endregion Properties

        #region Constructors

        // ------------------------------------------------------------------------------
        /// <summary>This method is the constructor (currently does nothing).</summary>
        // ------------------------------------------------------------------------------
        public LoanAccount_Manager()
        {
            //
            // constructor logic
            //
        }

        #endregion Constructors

		#region Methods

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add LoanAccount items.</summary>
        // ------------------------------------------------------------------------------
        public static void PopulateItem(BLL.Accounts.LoanAccount item, MOD.Data.NamedObjectCollection useCollections, bool performCascade, bool isAddOperation, bool isCollectionOperation, MOD.Test.TestResults results)
        {
            if (item == null)
            {
                return;
            }

            //
            // populate the LoanAccount item
            //
            MW.MComm.WalletSolution.UnitTest.Accounts.Account_Manager.PopulateItem((BLL.Accounts.Account)item, useCollections, performCascade, isAddOperation, isCollectionOperation, results);
            if (isAddOperation == true)
            {
                item.AccountID = TestHelper.GetGuid();
            }
            item.LoanAmount = TestHelper.GetDecimal(-1000000, 1000000);
            item.OutstandingAmount = TestHelper.GetDecimal(-1000000, 1000000);
            item.DueDate = TestHelper.GetDateTime(null, null);
            item.LoanRate = TestHelper.GetFloat(null, null);

            //
            // collections
            //
            if (performCascade == true && isAddOperation == true)
            {
                int collectionLoadCount = 0;
                collectionLoadCount = TestHelper.GetInt(Globals.MinimumLoadCountPerCollection, Globals.MaximumLoadCountPerCollection);
                TestHelper.ReportValueToConsole("PopulateItem: Next collection load count", collectionLoadCount);
                item.LoanToMetaPartnerList = new BLL.SortableList<BLL.Accounts.LoanToMetaPartner>();
                BLL.Accounts.LoanToMetaPartner vLoanToMetaPartnerList = null;
                for (int j=0; j < collectionLoadCount; j++)
                {
                    vLoanToMetaPartnerList = new BLL.Accounts.LoanToMetaPartner();
                    MW.MComm.WalletSolution.UnitTest.Accounts.LoanToMetaPartner_Manager.PopulateItem(vLoanToMetaPartnerList, useCollections, false, true, true, results);
                    results.IsCollision = false;
                    foreach (BLL.Accounts.LoanToMetaPartner loopLoanToMetaPartner in item.LoanToMetaPartnerList)
                    {
                        if (loopLoanToMetaPartner.PrimaryKey == vLoanToMetaPartnerList.PrimaryKey)
                        {
                            Console.WriteLine("Collision in collection encountered for LoanToMetaPartner: " + vLoanToMetaPartnerList.PrimaryKey.ToString());
                            results.IsCollision = true;
                            break;
                        }
                    }
                    if (results.IsCollision == false)
                    {
                        try
                        {
                            BLL.Accounts.LoanToMetaPartner item2 = BLL.Accounts.LoanToMetaPartnerManager.GetOneLoanToMetaPartner(vLoanToMetaPartnerList.AccountID, vLoanToMetaPartnerList.MetaPartnerID);
                            if (item2 != null)
                            {
                                results.IsCollision = true;
                                Console.WriteLine("Add collision encountered for LoanToMetaPartner: " + item2.PrimaryKey.ToString());
                            }
                        }
                        catch (UnitTestException ex)
                        {
                            throw ex;
                        }
                        catch (System.Exception ex)
                        {
                            throw new UnitTestException(UnitTestErrorType.Warning, "Get failed for LoanToMetaPartner", ex);
                        }
                    }
                    if (results.IsCollision == false)
                    {
                        item.LoanToMetaPartnerList.Add(vLoanToMetaPartnerList);
                    }
                }
            }
            PopulateItemCleanup(item, useCollections, performCascade, isAddOperation, isCollectionOperation, results);
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add LoanAccount items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Accounts.LoanAccount AddOneLoanAccountTest(bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // add item
            //
            BLL.Accounts.LoanAccount item = new BLL.Accounts.LoanAccount();
            MOD.Data.NamedObjectCollection useCollections = new MOD.Data.NamedObjectCollection();
            BLL.SortableList<BLL.Accounts.LoanAccount> itemsAccountsLoanAccount = new BLL.SortableList<BLL.Accounts.LoanAccount>();
            itemsAccountsLoanAccount.Add((BLL.Accounts.LoanAccount)item);
            useCollections["Accounts.LoanAccount"] = itemsAccountsLoanAccount;
            BLL.SortableList<BLL.Accounts.Account> itemsAccountsAccount = new BLL.SortableList<BLL.Accounts.Account>();
            itemsAccountsAccount.Add((BLL.Accounts.Account)item);
            useCollections["Accounts.Account"] = itemsAccountsAccount;
            LoanAccount_Manager.PopulateItem(item, useCollections, performCascade, true, false, results);
            results.IsCollision = false; // discard collection collisions
            BLL.Accounts.LoanAccount item2 = null;
            try
            {
                item2 = BLL.Accounts.LoanAccountManager.GetOneLoanAccount(item.AccountID);
            }
            catch (UnitTestException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Get failed for LoanAccount: " + item.PrimaryKey.ToString(), ex);
            }
            if (item2 != null)
            {
                results.IsCollision = true;
                throw new UnitTestException(UnitTestErrorType.Warning, "Add collision encountered for LoanAccount: " + item.PrimaryKey.ToString(), null);
            }
            if (results.IsCollision == false)
            {
                try
                {
                    if (IsValidForAdd(item, performCascade, results) == true)
                    {
                        startTicks = DateTime.Now.Ticks;
                        BLL.Accounts.LoanAccountManager.AddOneLoanAccount(item, performCascade);
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
        /// <summary>This method is used to update LoanAccount items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Accounts.LoanAccount UpdateOneLoanAccountTest(Guid accountID, bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get and update item
            //
            BLL.Accounts.LoanAccount item = new BLL.Accounts.LoanAccount();
            try
            {
                item = BLL.Accounts.LoanAccountManager.GetOneLoanAccount(accountID);
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
            BLL.SortableList<BLL.Accounts.LoanAccount> itemsAccountsLoanAccount = new BLL.SortableList<BLL.Accounts.LoanAccount>();
            itemsAccountsLoanAccount.Add((BLL.Accounts.LoanAccount)item);
            useCollections["Accounts.LoanAccount"] = itemsAccountsLoanAccount;
            BLL.SortableList<BLL.Accounts.Account> itemsAccountsAccount = new BLL.SortableList<BLL.Accounts.Account>();
            itemsAccountsAccount.Add((BLL.Accounts.Account)item);
            useCollections["Accounts.Account"] = itemsAccountsAccount;
            LoanAccount_Manager.PopulateItem(item, useCollections, performCascade, false, false, results);
            try
            {
                if (IsValidForUpdate(item, performCascade, results) == true)
                {
                    startTicks = DateTime.Now.Ticks;
                    BLL.Accounts.LoanAccountManager.UpdateOneLoanAccount(item, performCascade);
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
        /// <summary>This method is used to get LoanAccount items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.Accounts.LoanAccount> GetAllLoanAccountDataTest(MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get all items
            //
            try
            {
                startTicks = DateTime.Now.Ticks;
                BLL.SortableList<BLL.Accounts.LoanAccount> items = BLL.Accounts.LoanAccountManager.GetAllLoanAccountData();
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
        /// <summary>This method is used to get a set of LoanAccount items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.Accounts.LoanAccount> GetManyLoanAccountDataByCriteriaTest(MOD.Data.DataOptions dataOptions, MOD.Test.TestResults results)
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
                NamedObjectCollection nocDueDate = new NamedObjectCollection();
                NamedObjectCollection nocAccountName = new NamedObjectCollection();
                NamedObjectCollection nocCurrencyCode = new NamedObjectCollection();
                NamedObjectCollection nocLastModifiedDate = new NamedObjectCollection();
                startTicks = DateTime.Now.Ticks;
                BLL.SortableList<BLL.Accounts.LoanAccount> items =  BLL.Accounts.LoanAccountManager.GetManyLoanAccountDataByCriteria(null, null, null, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                BLL.SortableList<BLL.Accounts.LoanAccount> specificItems = null;
                string specificWarnings = String.Empty;
                bool searchValueUsed = false;
                int paramCount = 0;
                if (items.Count < 1)
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "No items found in GetManyLoanAccountDataByCriteria generic search.", null);
                }
                paramCount = 0;
                foreach (BLL.Accounts.LoanAccount item in items)
                {
                    nocDueDate[TestHelper.GetStringKeyFromObject((object)(item.DueDate), paramCount)] = item.DueDate;
                    nocAccountName[TestHelper.GetStringKeyFromObject((object)(item.AccountName), paramCount)] = item.AccountName;
                    nocCurrencyCode[TestHelper.GetStringKeyFromObject((object)(item.CurrencyCode), paramCount)] = item.CurrencyCode;
                    nocLastModifiedDate[TestHelper.GetStringKeyFromObject((object)(item.LastModifiedDate), paramCount)] = item.LastModifiedDate;
                    paramCount++;
                }
                paramCount = 0;
                DateTime itemDueDate = TestHelper.GetDateTime(null, null, nocDueDate, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Accounts.LoanAccountManager.GetManyLoanAccountDataByCriteria(itemDueDate, null, null, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyLoanAccountDataByCriteria search with DueDate = " + itemDueDate.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                string itemAccountName = TestHelper.GetString(null, 255, nocAccountName, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Accounts.LoanAccountManager.GetManyLoanAccountDataByCriteria(null, null, itemAccountName, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyLoanAccountDataByCriteria search with AccountName = " + itemAccountName.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                int itemCurrencyCode = TestHelper.GetInt(null, null, nocCurrencyCode, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Accounts.LoanAccountManager.GetManyLoanAccountDataByCriteria(null, null, null, itemCurrencyCode, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyLoanAccountDataByCriteria search with CurrencyCode = " + itemCurrencyCode.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                DateTime itemLastModifiedDate = TestHelper.GetDateTime(null, null, nocLastModifiedDate, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Accounts.LoanAccountManager.GetManyLoanAccountDataByCriteria(null, null, null, null, itemLastModifiedDate, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyLoanAccountDataByCriteria search with LastModifiedDate = " + itemLastModifiedDate.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                if (specificWarnings != String.Empty)
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "Results were not returned for GetManyLoanAccountDataByCriteria specific searches.", new Exception(specificWarnings));
                }
                return items;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to delete LoanAccount items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Accounts.LoanAccount DeleteOneLoanAccountTest(Guid accountID, bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get and delete item
            //
            BLL.Accounts.LoanAccount item = new BLL.Accounts.LoanAccount();
            try
            {
                item = BLL.Accounts.LoanAccountManager.GetOneLoanAccount(accountID);
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
                    BLL.Accounts.LoanAccountManager.DeleteOneLoanAccount(item, performCascade);
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