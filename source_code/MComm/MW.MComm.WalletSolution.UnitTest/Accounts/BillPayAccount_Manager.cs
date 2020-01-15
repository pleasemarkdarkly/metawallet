

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
    /// <summary>This class contains support methods to test BillPayAccount instances.</summary>
    ///
    /// File History:
    /// <created>7/31/2007 (Brian MacDonald)</created>
    ///
    /// <remarks></remarks>
    // ------------------------------------------------------------------------------
    public partial class BillPayAccount_Manager
    {

		#region Properties
        #endregion Properties

        #region Constructors

        // ------------------------------------------------------------------------------
        /// <summary>This method is the constructor (currently does nothing).</summary>
        // ------------------------------------------------------------------------------
        public BillPayAccount_Manager()
        {
            //
            // constructor logic
            //
        }

        #endregion Constructors

		#region Methods

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add BillPayAccount items.</summary>
        // ------------------------------------------------------------------------------
        public static void PopulateItem(BLL.Accounts.BillPayAccount item, MOD.Data.NamedObjectCollection useCollections, bool performCascade, bool isAddOperation, bool isCollectionOperation, MOD.Test.TestResults results)
        {
            if (item == null)
            {
                return;
            }

            //
            // populate the BillPayAccount item
            //
            int totalRecords = 0;
            bool totalRecordsExceeded = false;
            MW.MComm.WalletSolution.UnitTest.Accounts.Account_Manager.PopulateItem((BLL.Accounts.Account)item, useCollections, performCascade, isAddOperation, isCollectionOperation, results);
            if (isAddOperation == true)
            {
                item.AccountID = TestHelper.GetGuid();
            }
            item.BusinessAccountNumber = TestHelper.GetString(null, 100);
            item.StartDate = TestHelper.GetDateTime(null, null);
            item.EndDate = TestHelper.GetDateTime(null, null);
            item.DefaultMinimumPayment = TestHelper.GetDecimal(-1000000, 1000000);
            item.DefaultMaximumPayment = TestHelper.GetDecimal(-1000000, 1000000);
            totalRecords = 0;
            totalRecordsExceeded = false;
            BLL.SortableList<BLL.Customers.Business> itemBusinessBusinessMetaPartnerID = null;
            if (useCollections != null && useCollections["Customers.Business"] != null)
            {
                itemBusinessBusinessMetaPartnerID = (BLL.SortableList<BLL.Customers.Business>)useCollections["Customers.Business"];
            }
            if (itemBusinessBusinessMetaPartnerID == null || itemBusinessBusinessMetaPartnerID.Count <= 0)
            {
                itemBusinessBusinessMetaPartnerID = BLL.Customers.BusinessManager.GetManyBusinessDataByCriteria(null, null, null, null, null, null, out totalRecords, out totalRecordsExceeded, Globals.getDataOptions("","",1,200,2000));
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
            }
            if (itemBusinessBusinessMetaPartnerID.Count > 0)
            {
                int index = TestHelper.GetInt(0, Math.Max(0, itemBusinessBusinessMetaPartnerID.Count-1));
                item.BusinessMetaPartnerID = itemBusinessBusinessMetaPartnerID[index].MetaPartnerID;
            }
            else
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Could not find values for Business.", null);
            }
            item.HourOfDay = TestHelper.GetInt(null, null);
            item.DayOfWeek = TestHelper.GetInt(null, null);
            item.WeekOfMonth = TestHelper.GetInt(null, null);
            item.MonthOfYear = TestHelper.GetInt(null, null);
            item.NumberOfReminders = TestHelper.GetInt(null, null);
            BLL.SortableList<BLL.Accounts.Frequency> itemFrequencyFrequencyCode = null;
            if (useCollections != null && useCollections["Accounts.Frequency"] != null)
            {
                itemFrequencyFrequencyCode = (BLL.SortableList<BLL.Accounts.Frequency>)useCollections["Accounts.Frequency"];
            }
            if (itemFrequencyFrequencyCode == null || itemFrequencyFrequencyCode.Count <= 0)
            {
                itemFrequencyFrequencyCode = BLL.Accounts.FrequencyManager.GetAllFrequencyData();
            }
            if (itemFrequencyFrequencyCode.Count > 0)
            {
                int index = TestHelper.GetInt(0, Math.Max(0, itemFrequencyFrequencyCode.Count-1));
                item.FrequencyCode = itemFrequencyFrequencyCode[index].FrequencyCode;
            }
            else
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Could not find values for Frequency.", null);
            }
            PopulateItemCleanup(item, useCollections, performCascade, isAddOperation, isCollectionOperation, results);
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add BillPayAccount items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Accounts.BillPayAccount AddOneBillPayAccountTest(bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // add item
            //
            BLL.Accounts.BillPayAccount item = new BLL.Accounts.BillPayAccount();
            MOD.Data.NamedObjectCollection useCollections = new MOD.Data.NamedObjectCollection();
            BLL.SortableList<BLL.Accounts.BillPayAccount> itemsAccountsBillPayAccount = new BLL.SortableList<BLL.Accounts.BillPayAccount>();
            itemsAccountsBillPayAccount.Add((BLL.Accounts.BillPayAccount)item);
            useCollections["Accounts.BillPayAccount"] = itemsAccountsBillPayAccount;
            BLL.SortableList<BLL.Accounts.Account> itemsAccountsAccount = new BLL.SortableList<BLL.Accounts.Account>();
            itemsAccountsAccount.Add((BLL.Accounts.Account)item);
            useCollections["Accounts.Account"] = itemsAccountsAccount;
            BillPayAccount_Manager.PopulateItem(item, useCollections, performCascade, true, false, results);
            results.IsCollision = false; // discard collection collisions
            BLL.Accounts.BillPayAccount item2 = null;
            try
            {
                item2 = BLL.Accounts.BillPayAccountManager.GetOneBillPayAccount(item.AccountID);
            }
            catch (UnitTestException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Get failed for BillPayAccount: " + item.PrimaryKey.ToString(), ex);
            }
            if (item2 != null)
            {
                results.IsCollision = true;
                throw new UnitTestException(UnitTestErrorType.Warning, "Add collision encountered for BillPayAccount: " + item.PrimaryKey.ToString(), null);
            }
            if (results.IsCollision == false)
            {
                try
                {
                    if (IsValidForAdd(item, performCascade, results) == true)
                    {
                        startTicks = DateTime.Now.Ticks;
                        BLL.Accounts.BillPayAccountManager.AddOneBillPayAccount(item, performCascade);
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
        /// <summary>This method is used to update BillPayAccount items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Accounts.BillPayAccount UpdateOneBillPayAccountTest(Guid accountID, bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get and update item
            //
            BLL.Accounts.BillPayAccount item = new BLL.Accounts.BillPayAccount();
            try
            {
                item = BLL.Accounts.BillPayAccountManager.GetOneBillPayAccount(accountID);
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
            BLL.SortableList<BLL.Accounts.BillPayAccount> itemsAccountsBillPayAccount = new BLL.SortableList<BLL.Accounts.BillPayAccount>();
            itemsAccountsBillPayAccount.Add((BLL.Accounts.BillPayAccount)item);
            useCollections["Accounts.BillPayAccount"] = itemsAccountsBillPayAccount;
            BLL.SortableList<BLL.Accounts.Account> itemsAccountsAccount = new BLL.SortableList<BLL.Accounts.Account>();
            itemsAccountsAccount.Add((BLL.Accounts.Account)item);
            useCollections["Accounts.Account"] = itemsAccountsAccount;
            BillPayAccount_Manager.PopulateItem(item, useCollections, performCascade, false, false, results);
            try
            {
                if (IsValidForUpdate(item, performCascade, results) == true)
                {
                    startTicks = DateTime.Now.Ticks;
                    BLL.Accounts.BillPayAccountManager.UpdateOneBillPayAccount(item, performCascade);
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
        /// <summary>This method is used to get BillPayAccount items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.Accounts.BillPayAccount> GetAllBillPayAccountDataTest(MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get all items
            //
            try
            {
                startTicks = DateTime.Now.Ticks;
                BLL.SortableList<BLL.Accounts.BillPayAccount> items = BLL.Accounts.BillPayAccountManager.GetAllBillPayAccountData();
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
        /// <summary>This method is used to get a set of BillPayAccount items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.Accounts.BillPayAccount> GetManyBillPayAccountDataByCriteriaTest(MOD.Data.DataOptions dataOptions, MOD.Test.TestResults results)
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
                NamedObjectCollection nocBusinessAccountNumber = new NamedObjectCollection();
                NamedObjectCollection nocStartDate = new NamedObjectCollection();
                NamedObjectCollection nocEndDate = new NamedObjectCollection();
                NamedObjectCollection nocNumberOfReminders = new NamedObjectCollection();
                NamedObjectCollection nocFrequencyCode = new NamedObjectCollection();
                NamedObjectCollection nocAccountName = new NamedObjectCollection();
                NamedObjectCollection nocCurrencyCode = new NamedObjectCollection();
                NamedObjectCollection nocLastModifiedDate = new NamedObjectCollection();
                startTicks = DateTime.Now.Ticks;
                BLL.SortableList<BLL.Accounts.BillPayAccount> items =  BLL.Accounts.BillPayAccountManager.GetManyBillPayAccountDataByCriteria(null, null, null, null, null, null, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                BLL.SortableList<BLL.Accounts.BillPayAccount> specificItems = null;
                string specificWarnings = String.Empty;
                bool searchValueUsed = false;
                int paramCount = 0;
                if (items.Count < 1)
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "No items found in GetManyBillPayAccountDataByCriteria generic search.", null);
                }
                paramCount = 0;
                foreach (BLL.Accounts.BillPayAccount item in items)
                {
                    nocBusinessAccountNumber[TestHelper.GetStringKeyFromObject((object)(item.BusinessAccountNumber), paramCount)] = item.BusinessAccountNumber;
                    nocStartDate[TestHelper.GetStringKeyFromObject((object)(item.StartDate), paramCount)] = item.StartDate;
                    nocEndDate[TestHelper.GetStringKeyFromObject((object)(item.EndDate), paramCount)] = item.EndDate;
                    nocNumberOfReminders[TestHelper.GetStringKeyFromObject((object)(item.NumberOfReminders), paramCount)] = item.NumberOfReminders;
                    nocFrequencyCode[TestHelper.GetStringKeyFromObject((object)(item.FrequencyCode), paramCount)] = item.FrequencyCode;
                    nocAccountName[TestHelper.GetStringKeyFromObject((object)(item.AccountName), paramCount)] = item.AccountName;
                    nocCurrencyCode[TestHelper.GetStringKeyFromObject((object)(item.CurrencyCode), paramCount)] = item.CurrencyCode;
                    nocLastModifiedDate[TestHelper.GetStringKeyFromObject((object)(item.LastModifiedDate), paramCount)] = item.LastModifiedDate;
                    paramCount++;
                }
                paramCount = 0;
                string itemBusinessAccountNumber = TestHelper.GetString(null, 100, nocBusinessAccountNumber, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Accounts.BillPayAccountManager.GetManyBillPayAccountDataByCriteria(itemBusinessAccountNumber, null, null, null, null, null, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyBillPayAccountDataByCriteria search with BusinessAccountNumber = " + itemBusinessAccountNumber.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                DateTime itemStartDate = TestHelper.GetDateTime(null, null, nocStartDate, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Accounts.BillPayAccountManager.GetManyBillPayAccountDataByCriteria(null, itemStartDate, null, null, null, null, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyBillPayAccountDataByCriteria search with StartDate = " + itemStartDate.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                DateTime itemEndDate = TestHelper.GetDateTime(null, null, nocEndDate, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Accounts.BillPayAccountManager.GetManyBillPayAccountDataByCriteria(null, null, itemEndDate, null, null, null, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyBillPayAccountDataByCriteria search with EndDate = " + itemEndDate.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                int itemNumberOfReminders = TestHelper.GetInt(null, null, nocNumberOfReminders, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Accounts.BillPayAccountManager.GetManyBillPayAccountDataByCriteria(null, null, null, itemNumberOfReminders, null, null, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyBillPayAccountDataByCriteria search with NumberOfReminders = " + itemNumberOfReminders.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                int itemFrequencyCode = TestHelper.GetInt(null, null, nocFrequencyCode, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Accounts.BillPayAccountManager.GetManyBillPayAccountDataByCriteria(null, null, null, null, itemFrequencyCode, null, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyBillPayAccountDataByCriteria search with FrequencyCode = " + itemFrequencyCode.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                string itemAccountName = TestHelper.GetString(null, 255, nocAccountName, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Accounts.BillPayAccountManager.GetManyBillPayAccountDataByCriteria(null, null, null, null, null, itemAccountName, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyBillPayAccountDataByCriteria search with AccountName = " + itemAccountName.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                int itemCurrencyCode = TestHelper.GetInt(null, null, nocCurrencyCode, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Accounts.BillPayAccountManager.GetManyBillPayAccountDataByCriteria(null, null, null, null, null, null, itemCurrencyCode, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyBillPayAccountDataByCriteria search with CurrencyCode = " + itemCurrencyCode.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                DateTime itemLastModifiedDate = TestHelper.GetDateTime(null, null, nocLastModifiedDate, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Accounts.BillPayAccountManager.GetManyBillPayAccountDataByCriteria(null, null, null, null, null, null, null, itemLastModifiedDate, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyBillPayAccountDataByCriteria search with LastModifiedDate = " + itemLastModifiedDate.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                if (specificWarnings != String.Empty)
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "Results were not returned for GetManyBillPayAccountDataByCriteria specific searches.", new Exception(specificWarnings));
                }
                return items;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to delete BillPayAccount items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Accounts.BillPayAccount DeleteOneBillPayAccountTest(Guid accountID, bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get and delete item
            //
            BLL.Accounts.BillPayAccount item = new BLL.Accounts.BillPayAccount();
            try
            {
                item = BLL.Accounts.BillPayAccountManager.GetOneBillPayAccount(accountID);
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
                    BLL.Accounts.BillPayAccountManager.DeleteOneBillPayAccount(item, performCascade);
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