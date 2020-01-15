

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
    /// <summary>This class contains support methods to test Account instances.</summary>
    ///
    /// File History:
    /// <created>7/31/2007 (Brian MacDonald)</created>
    ///
    /// <remarks></remarks>
    // ------------------------------------------------------------------------------
    public partial class Account_Manager
    {

		#region Properties
        #endregion Properties

        #region Constructors

        // ------------------------------------------------------------------------------
        /// <summary>This method is the constructor (currently does nothing).</summary>
        // ------------------------------------------------------------------------------
        public Account_Manager()
        {
            //
            // constructor logic
            //
        }

        #endregion Constructors

		#region Methods

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add Account items.</summary>
        // ------------------------------------------------------------------------------
        public static void PopulateItem(BLL.Accounts.Account item, MOD.Data.NamedObjectCollection useCollections, bool performCascade, bool isAddOperation, bool isCollectionOperation, MOD.Test.TestResults results)
        {
            if (item == null)
            {
                return;
            }

            //
            // populate the Account item
            //
            int totalRecords = 0;
            bool totalRecordsExceeded = false;
            if (isAddOperation == true)
            {
                item.AccountID = TestHelper.GetGuid();
            }
            totalRecords = 0;
            totalRecordsExceeded = false;
            BLL.SortableList<BLL.Customers.MetaPartner> itemMetaPartnerMetaPartnerID = null;
            if (useCollections != null && useCollections["Customers.MetaPartner"] != null)
            {
                itemMetaPartnerMetaPartnerID = (BLL.SortableList<BLL.Customers.MetaPartner>)useCollections["Customers.MetaPartner"];
            }
            if (itemMetaPartnerMetaPartnerID == null || itemMetaPartnerMetaPartnerID.Count <= 0)
            {
                itemMetaPartnerMetaPartnerID = BLL.Customers.MetaPartnerManager.GetManyMetaPartnerDataByCriteria(null, null, null, null, null, null, null, out totalRecords, out totalRecordsExceeded, Globals.getDataOptions("","",1,200,2000));
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
            }
            if (itemMetaPartnerMetaPartnerID.Count > 0)
            {
                int index = TestHelper.GetInt(0, Math.Max(0, itemMetaPartnerMetaPartnerID.Count-1));
                item.MetaPartnerID = itemMetaPartnerMetaPartnerID[index].MetaPartnerID;
            }
            else
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Could not find values for MetaPartner.", null);
            }
            item.AccountName = TestHelper.GetString(null, 255);
            BLL.SortableList<BLL.Accounts.AccountSubType> itemAccountSubTypeAccountSubTypeCode = null;
            if (useCollections != null && useCollections["Accounts.AccountSubType"] != null)
            {
                itemAccountSubTypeAccountSubTypeCode = (BLL.SortableList<BLL.Accounts.AccountSubType>)useCollections["Accounts.AccountSubType"];
            }
            if (itemAccountSubTypeAccountSubTypeCode == null || itemAccountSubTypeAccountSubTypeCode.Count <= 0)
            {
                itemAccountSubTypeAccountSubTypeCode = BLL.Accounts.AccountSubTypeManager.GetAllAccountSubTypeData();
            }
            if (itemAccountSubTypeAccountSubTypeCode.Count > 0)
            {
                int index = TestHelper.GetInt(0, Math.Max(0, itemAccountSubTypeAccountSubTypeCode.Count-1));
                item.AccountSubTypeCode = itemAccountSubTypeAccountSubTypeCode[index].AccountSubTypeCode;
            }
            else
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Could not find values for AccountSubType.", null);
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
            item.Description = TestHelper.GetString(null, 2000);
            item.IsActive = TestHelper.GetBool();
            PopulateItemCleanup(item, useCollections, performCascade, isAddOperation, isCollectionOperation, results);
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add Account items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Accounts.Account AddOneAccountTest(bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // add item
            //
            BLL.Accounts.Account item = new BLL.Accounts.Account();
            MOD.Data.NamedObjectCollection useCollections = new MOD.Data.NamedObjectCollection();
            BLL.SortableList<BLL.Accounts.Account> itemsAccountsAccount = new BLL.SortableList<BLL.Accounts.Account>();
            itemsAccountsAccount.Add((BLL.Accounts.Account)item);
            useCollections["Accounts.Account"] = itemsAccountsAccount;
            Account_Manager.PopulateItem(item, useCollections, performCascade, true, false, results);
            results.IsCollision = false; // discard collection collisions
            BLL.Accounts.Account item2 = null;
            try
            {
                item2 = BLL.Accounts.AccountManager.GetOneAccount(item.AccountID);
            }
            catch (UnitTestException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Get failed for Account: " + item.PrimaryKey.ToString(), ex);
            }
            if (item2 != null)
            {
                results.IsCollision = true;
                throw new UnitTestException(UnitTestErrorType.Warning, "Add collision encountered for Account: " + item.PrimaryKey.ToString(), null);
            }
            if (results.IsCollision == false)
            {
                try
                {
                    if (IsValidForAdd(item, performCascade, results) == true)
                    {
                        startTicks = DateTime.Now.Ticks;
                        BLL.Accounts.AccountManager.UpsertOneAccount(item, performCascade);
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
        /// <summary>This method is used to update Account items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Accounts.Account UpdateOneAccountTest(Guid accountID, bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get and update item
            //
            BLL.Accounts.Account item = new BLL.Accounts.Account();
            try
            {
                item = BLL.Accounts.AccountManager.GetOneAccount(accountID);
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
            BLL.SortableList<BLL.Accounts.Account> itemsAccountsAccount = new BLL.SortableList<BLL.Accounts.Account>();
            itemsAccountsAccount.Add((BLL.Accounts.Account)item);
            useCollections["Accounts.Account"] = itemsAccountsAccount;
            Account_Manager.PopulateItem(item, useCollections, performCascade, false, false, results);
            try
            {
                if (IsValidForUpdate(item, performCascade, results) == true)
                {
                    startTicks = DateTime.Now.Ticks;
                    BLL.Accounts.AccountManager.UpsertOneAccount(item, performCascade);
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
        /// <summary>This method is used to get Account items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.Accounts.Account> GetAllAccountDataTest(MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get all items
            //
            try
            {
                startTicks = DateTime.Now.Ticks;
                BLL.SortableList<BLL.Accounts.Account> items = BLL.Accounts.AccountManager.GetAllAccountData();
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
        /// <summary>This method is used to get a set of Account items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.Accounts.Account> GetManyAccountDataByCriteriaTest(MOD.Data.DataOptions dataOptions, MOD.Test.TestResults results)
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
                NamedObjectCollection nocAccountName = new NamedObjectCollection();
                NamedObjectCollection nocAccountSubTypeCode = new NamedObjectCollection();
                NamedObjectCollection nocCurrencyCode = new NamedObjectCollection();
                NamedObjectCollection nocLastModifiedDate = new NamedObjectCollection();
                startTicks = DateTime.Now.Ticks;
                BLL.SortableList<BLL.Accounts.Account> items =  BLL.Accounts.AccountManager.GetManyAccountDataByCriteria(null, null, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                BLL.SortableList<BLL.Accounts.Account> specificItems = null;
                string specificWarnings = String.Empty;
                bool searchValueUsed = false;
                int paramCount = 0;
                if (items.Count < 1)
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "No items found in GetManyAccountDataByCriteria generic search.", null);
                }
                paramCount = 0;
                foreach (BLL.Accounts.Account item in items)
                {
                    nocAccountName[TestHelper.GetStringKeyFromObject((object)(item.AccountName), paramCount)] = item.AccountName;
                    nocAccountSubTypeCode[TestHelper.GetStringKeyFromObject((object)(item.AccountSubTypeCode), paramCount)] = item.AccountSubTypeCode;
                    nocCurrencyCode[TestHelper.GetStringKeyFromObject((object)(item.CurrencyCode), paramCount)] = item.CurrencyCode;
                    nocLastModifiedDate[TestHelper.GetStringKeyFromObject((object)(item.LastModifiedDate), paramCount)] = item.LastModifiedDate;
                    paramCount++;
                }
                paramCount = 0;
                string itemAccountName = TestHelper.GetString(null, 255, nocAccountName, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Accounts.AccountManager.GetManyAccountDataByCriteria(itemAccountName, null, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyAccountDataByCriteria search with AccountName = " + itemAccountName.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                int itemAccountSubTypeCode = TestHelper.GetInt(null, null, nocAccountSubTypeCode, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Accounts.AccountManager.GetManyAccountDataByCriteria(null, itemAccountSubTypeCode, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyAccountDataByCriteria search with AccountSubTypeCode = " + itemAccountSubTypeCode.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                int itemCurrencyCode = TestHelper.GetInt(null, null, nocCurrencyCode, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Accounts.AccountManager.GetManyAccountDataByCriteria(null, null, itemCurrencyCode, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyAccountDataByCriteria search with CurrencyCode = " + itemCurrencyCode.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                DateTime itemLastModifiedDate = TestHelper.GetDateTime(null, null, nocLastModifiedDate, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Accounts.AccountManager.GetManyAccountDataByCriteria(null, null, null, itemLastModifiedDate, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyAccountDataByCriteria search with LastModifiedDate = " + itemLastModifiedDate.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                if (specificWarnings != String.Empty)
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "Results were not returned for GetManyAccountDataByCriteria specific searches.", new Exception(specificWarnings));
                }
                return items;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to delete Account items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Accounts.Account DeleteOneAccountTest(Guid accountID, bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get and delete item
            //
            BLL.Accounts.Account item = new BLL.Accounts.Account();
            try
            {
                item = BLL.Accounts.AccountManager.GetOneAccount(accountID);
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
                    BLL.Accounts.AccountManager.DeleteOneAccount(item, performCascade);
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