

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
    /// <summary>This class contains support methods to test StoredValueAccount instances.</summary>
    ///
    /// File History:
    /// <created>7/31/2007 (Brian MacDonald)</created>
    ///
    /// <remarks></remarks>
    // ------------------------------------------------------------------------------
    public partial class StoredValueAccount_Manager
    {

		#region Properties
        #endregion Properties

        #region Constructors

        // ------------------------------------------------------------------------------
        /// <summary>This method is the constructor (currently does nothing).</summary>
        // ------------------------------------------------------------------------------
        public StoredValueAccount_Manager()
        {
            //
            // constructor logic
            //
        }

        #endregion Constructors

		#region Methods

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add StoredValueAccount items.</summary>
        // ------------------------------------------------------------------------------
        public static void PopulateItem(BLL.Accounts.StoredValueAccount item, MOD.Data.NamedObjectCollection useCollections, bool performCascade, bool isAddOperation, bool isCollectionOperation, MOD.Test.TestResults results)
        {
            if (item == null)
            {
                return;
            }

            //
            // populate the StoredValueAccount item
            //
            int totalRecords = 0;
            bool totalRecordsExceeded = false;
            MW.MComm.WalletSolution.UnitTest.Accounts.DebitAccount_Manager.PopulateItem((BLL.Accounts.DebitAccount)item, useCollections, performCascade, isAddOperation, isCollectionOperation, results);
            if (isAddOperation == true)
            {
                item.AccountID = TestHelper.GetGuid();
            }
            item.Balance = TestHelper.GetDecimal(-1000000, 1000000);
            totalRecords = 0;
            totalRecordsExceeded = false;
            BLL.SortableList<BLL.Customers.MetaPartnerPhone> itemMetaPartnerPhoneMetaPartnerPhoneID = null;
            if (useCollections != null && useCollections["Customers.MetaPartnerPhone"] != null)
            {
                itemMetaPartnerPhoneMetaPartnerPhoneID = (BLL.SortableList<BLL.Customers.MetaPartnerPhone>)useCollections["Customers.MetaPartnerPhone"];
            }
            if (itemMetaPartnerPhoneMetaPartnerPhoneID == null || itemMetaPartnerPhoneMetaPartnerPhoneID.Count <= 0)
            {
                itemMetaPartnerPhoneMetaPartnerPhoneID = BLL.Customers.MetaPartnerPhoneManager.GetManyMetaPartnerPhoneDataByCriteria(null, null, null, out totalRecords, out totalRecordsExceeded, Globals.getDataOptions("","",1,200,2000));
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
            }
            if (itemMetaPartnerPhoneMetaPartnerPhoneID.Count > 0)
            {
                int index = TestHelper.GetInt(0, Math.Max(0, itemMetaPartnerPhoneMetaPartnerPhoneID.Count-1));
                item.MetaPartnerPhoneID = itemMetaPartnerPhoneMetaPartnerPhoneID[index].MetaPartnerPhoneID;
            }
            else
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Could not find values for MetaPartnerPhone.", null);
            }
            PopulateItemCleanup(item, useCollections, performCascade, isAddOperation, isCollectionOperation, results);
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add StoredValueAccount items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Accounts.StoredValueAccount AddOneStoredValueAccountTest(bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // add item
            //
            BLL.Accounts.StoredValueAccount item = new BLL.Accounts.StoredValueAccount();
            MOD.Data.NamedObjectCollection useCollections = new MOD.Data.NamedObjectCollection();
            BLL.SortableList<BLL.Accounts.StoredValueAccount> itemsAccountsStoredValueAccount = new BLL.SortableList<BLL.Accounts.StoredValueAccount>();
            itemsAccountsStoredValueAccount.Add((BLL.Accounts.StoredValueAccount)item);
            useCollections["Accounts.StoredValueAccount"] = itemsAccountsStoredValueAccount;
            BLL.SortableList<BLL.Accounts.DebitAccount> itemsAccountsDebitAccount = new BLL.SortableList<BLL.Accounts.DebitAccount>();
            itemsAccountsDebitAccount.Add((BLL.Accounts.DebitAccount)item);
            useCollections["Accounts.DebitAccount"] = itemsAccountsDebitAccount;
            BLL.SortableList<BLL.Accounts.Account> itemsAccountsAccount = new BLL.SortableList<BLL.Accounts.Account>();
            itemsAccountsAccount.Add((BLL.Accounts.Account)item);
            useCollections["Accounts.Account"] = itemsAccountsAccount;
            StoredValueAccount_Manager.PopulateItem(item, useCollections, performCascade, true, false, results);
            results.IsCollision = false; // discard collection collisions
            BLL.Accounts.StoredValueAccount item2 = null;
            try
            {
                item2 = BLL.Accounts.StoredValueAccountManager.GetOneStoredValueAccount(item.AccountID);
            }
            catch (UnitTestException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Get failed for StoredValueAccount: " + item.PrimaryKey.ToString(), ex);
            }
            if (item2 != null)
            {
                results.IsCollision = true;
                throw new UnitTestException(UnitTestErrorType.Warning, "Add collision encountered for StoredValueAccount: " + item.PrimaryKey.ToString(), null);
            }
            if (results.IsCollision == false)
            {
                try
                {
                    if (IsValidForAdd(item, performCascade, results) == true)
                    {
                        startTicks = DateTime.Now.Ticks;
                        BLL.Accounts.StoredValueAccountManager.AddOneStoredValueAccount(item, performCascade);
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
        /// <summary>This method is used to update StoredValueAccount items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Accounts.StoredValueAccount UpdateOneStoredValueAccountTest(Guid accountID, bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get and update item
            //
            BLL.Accounts.StoredValueAccount item = new BLL.Accounts.StoredValueAccount();
            try
            {
                item = BLL.Accounts.StoredValueAccountManager.GetOneStoredValueAccount(accountID);
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
            BLL.SortableList<BLL.Accounts.StoredValueAccount> itemsAccountsStoredValueAccount = new BLL.SortableList<BLL.Accounts.StoredValueAccount>();
            itemsAccountsStoredValueAccount.Add((BLL.Accounts.StoredValueAccount)item);
            useCollections["Accounts.StoredValueAccount"] = itemsAccountsStoredValueAccount;
            BLL.SortableList<BLL.Accounts.DebitAccount> itemsAccountsDebitAccount = new BLL.SortableList<BLL.Accounts.DebitAccount>();
            itemsAccountsDebitAccount.Add((BLL.Accounts.DebitAccount)item);
            useCollections["Accounts.DebitAccount"] = itemsAccountsDebitAccount;
            BLL.SortableList<BLL.Accounts.Account> itemsAccountsAccount = new BLL.SortableList<BLL.Accounts.Account>();
            itemsAccountsAccount.Add((BLL.Accounts.Account)item);
            useCollections["Accounts.Account"] = itemsAccountsAccount;
            StoredValueAccount_Manager.PopulateItem(item, useCollections, performCascade, false, false, results);
            try
            {
                if (IsValidForUpdate(item, performCascade, results) == true)
                {
                    startTicks = DateTime.Now.Ticks;
                    BLL.Accounts.StoredValueAccountManager.UpdateOneStoredValueAccount(item, performCascade);
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
        /// <summary>This method is used to get StoredValueAccount items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.Accounts.StoredValueAccount> GetAllStoredValueAccountDataTest(MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get all items
            //
            try
            {
                startTicks = DateTime.Now.Ticks;
                BLL.SortableList<BLL.Accounts.StoredValueAccount> items = BLL.Accounts.StoredValueAccountManager.GetAllStoredValueAccountData();
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
        /// <summary>This method is used to get a set of StoredValueAccount items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.Accounts.StoredValueAccount> GetManyStoredValueAccountDataByCriteriaTest(MOD.Data.DataOptions dataOptions, MOD.Test.TestResults results)
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
                NamedObjectCollection nocDebitAccountNumber = new NamedObjectCollection();
                NamedObjectCollection nocAccountName = new NamedObjectCollection();
                NamedObjectCollection nocCurrencyCode = new NamedObjectCollection();
                NamedObjectCollection nocLastModifiedDate = new NamedObjectCollection();
                startTicks = DateTime.Now.Ticks;
                BLL.SortableList<BLL.Accounts.StoredValueAccount> items =  BLL.Accounts.StoredValueAccountManager.GetManyStoredValueAccountDataByCriteria(null, null, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                BLL.SortableList<BLL.Accounts.StoredValueAccount> specificItems = null;
                string specificWarnings = String.Empty;
                bool searchValueUsed = false;
                int paramCount = 0;
                if (items.Count < 1)
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "No items found in GetManyStoredValueAccountDataByCriteria generic search.", null);
                }
                paramCount = 0;
                foreach (BLL.Accounts.StoredValueAccount item in items)
                {
                    nocDebitAccountNumber[TestHelper.GetStringKeyFromObject((object)(item.DebitAccountNumber), paramCount)] = item.DebitAccountNumber;
                    nocAccountName[TestHelper.GetStringKeyFromObject((object)(item.AccountName), paramCount)] = item.AccountName;
                    nocCurrencyCode[TestHelper.GetStringKeyFromObject((object)(item.CurrencyCode), paramCount)] = item.CurrencyCode;
                    nocLastModifiedDate[TestHelper.GetStringKeyFromObject((object)(item.LastModifiedDate), paramCount)] = item.LastModifiedDate;
                    paramCount++;
                }
                paramCount = 0;
                string itemDebitAccountNumber = TestHelper.GetString(null, 100, nocDebitAccountNumber, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Accounts.StoredValueAccountManager.GetManyStoredValueAccountDataByCriteria(itemDebitAccountNumber, null, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyStoredValueAccountDataByCriteria search with DebitAccountNumber = " + itemDebitAccountNumber.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                string itemAccountName = TestHelper.GetString(null, 255, nocAccountName, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Accounts.StoredValueAccountManager.GetManyStoredValueAccountDataByCriteria(null, itemAccountName, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyStoredValueAccountDataByCriteria search with AccountName = " + itemAccountName.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                int itemCurrencyCode = TestHelper.GetInt(null, null, nocCurrencyCode, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Accounts.StoredValueAccountManager.GetManyStoredValueAccountDataByCriteria(null, null, itemCurrencyCode, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyStoredValueAccountDataByCriteria search with CurrencyCode = " + itemCurrencyCode.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                DateTime itemLastModifiedDate = TestHelper.GetDateTime(null, null, nocLastModifiedDate, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Accounts.StoredValueAccountManager.GetManyStoredValueAccountDataByCriteria(null, null, null, itemLastModifiedDate, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyStoredValueAccountDataByCriteria search with LastModifiedDate = " + itemLastModifiedDate.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                if (specificWarnings != String.Empty)
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "Results were not returned for GetManyStoredValueAccountDataByCriteria specific searches.", new Exception(specificWarnings));
                }
                return items;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to delete StoredValueAccount items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Accounts.StoredValueAccount DeleteOneStoredValueAccountTest(Guid accountID, bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get and delete item
            //
            BLL.Accounts.StoredValueAccount item = new BLL.Accounts.StoredValueAccount();
            try
            {
                item = BLL.Accounts.StoredValueAccountManager.GetOneStoredValueAccount(accountID);
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
                    BLL.Accounts.StoredValueAccountManager.DeleteOneStoredValueAccount(item, performCascade);
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