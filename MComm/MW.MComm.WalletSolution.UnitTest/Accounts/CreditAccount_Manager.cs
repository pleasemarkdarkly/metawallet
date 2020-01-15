

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
    /// <summary>This class contains support methods to test CreditAccount instances.</summary>
    ///
    /// File History:
    /// <created>7/31/2007 (Brian MacDonald)</created>
    ///
    /// <remarks></remarks>
    // ------------------------------------------------------------------------------
    public partial class CreditAccount_Manager
    {

		#region Properties
        #endregion Properties

        #region Constructors

        // ------------------------------------------------------------------------------
        /// <summary>This method is the constructor (currently does nothing).</summary>
        // ------------------------------------------------------------------------------
        public CreditAccount_Manager()
        {
            //
            // constructor logic
            //
        }

        #endregion Constructors

		#region Methods

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add CreditAccount items.</summary>
        // ------------------------------------------------------------------------------
        public static void PopulateItem(BLL.Accounts.CreditAccount item, MOD.Data.NamedObjectCollection useCollections, bool performCascade, bool isAddOperation, bool isCollectionOperation, MOD.Test.TestResults results)
        {
            if (item == null)
            {
                return;
            }

            //
            // populate the CreditAccount item
            //
            MW.MComm.WalletSolution.UnitTest.Accounts.Account_Manager.PopulateItem((BLL.Accounts.Account)item, useCollections, performCascade, isAddOperation, isCollectionOperation, results);
            if (isAddOperation == true)
            {
                item.AccountID = TestHelper.GetGuid();
            }
            item.CreditCardNumber = TestHelper.GetString(null, 50);
            item.CreditCardLastFour = TestHelper.GetString(null, 4);
            item.CreditCardName = TestHelper.GetString(null, 255);
            item.ExpirationDate = TestHelper.GetNullableDateTime(null, null);
            BLL.SortableList<BLL.Accounts.CreditCardType> itemCreditCardTypeCreditCardTypeCode = null;
            if (useCollections != null && useCollections["Accounts.CreditCardType"] != null)
            {
                itemCreditCardTypeCreditCardTypeCode = (BLL.SortableList<BLL.Accounts.CreditCardType>)useCollections["Accounts.CreditCardType"];
            }
            if (itemCreditCardTypeCreditCardTypeCode == null || itemCreditCardTypeCreditCardTypeCode.Count <= 0)
            {
                itemCreditCardTypeCreditCardTypeCode = BLL.Accounts.CreditCardTypeManager.GetAllCreditCardTypeData();
            }
            if (itemCreditCardTypeCreditCardTypeCode.Count > 0)
            {
                int index = TestHelper.GetInt(0, Math.Max(0, itemCreditCardTypeCreditCardTypeCode.Count-1));
                item.CreditCardTypeCode = itemCreditCardTypeCreditCardTypeCode[index].CreditCardTypeCode;
            }
            else
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Could not find values for CreditCardType.", null);
            }
            PopulateItemCleanup(item, useCollections, performCascade, isAddOperation, isCollectionOperation, results);
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add CreditAccount items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Accounts.CreditAccount AddOneCreditAccountTest(bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // add item
            //
            BLL.Accounts.CreditAccount item = new BLL.Accounts.CreditAccount();
            MOD.Data.NamedObjectCollection useCollections = new MOD.Data.NamedObjectCollection();
            BLL.SortableList<BLL.Accounts.CreditAccount> itemsAccountsCreditAccount = new BLL.SortableList<BLL.Accounts.CreditAccount>();
            itemsAccountsCreditAccount.Add((BLL.Accounts.CreditAccount)item);
            useCollections["Accounts.CreditAccount"] = itemsAccountsCreditAccount;
            BLL.SortableList<BLL.Accounts.Account> itemsAccountsAccount = new BLL.SortableList<BLL.Accounts.Account>();
            itemsAccountsAccount.Add((BLL.Accounts.Account)item);
            useCollections["Accounts.Account"] = itemsAccountsAccount;
            CreditAccount_Manager.PopulateItem(item, useCollections, performCascade, true, false, results);
            results.IsCollision = false; // discard collection collisions
            BLL.Accounts.CreditAccount item2 = null;
            try
            {
                item2 = BLL.Accounts.CreditAccountManager.GetOneCreditAccount(item.AccountID);
            }
            catch (UnitTestException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Get failed for CreditAccount: " + item.PrimaryKey.ToString(), ex);
            }
            if (item2 != null)
            {
                results.IsCollision = true;
                throw new UnitTestException(UnitTestErrorType.Warning, "Add collision encountered for CreditAccount: " + item.PrimaryKey.ToString(), null);
            }
            if (results.IsCollision == false)
            {
                try
                {
                    if (IsValidForAdd(item, performCascade, results) == true)
                    {
                        startTicks = DateTime.Now.Ticks;
                        BLL.Accounts.CreditAccountManager.AddOneCreditAccount(item, performCascade);
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
        /// <summary>This method is used to update CreditAccount items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Accounts.CreditAccount UpdateOneCreditAccountTest(Guid accountID, bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get and update item
            //
            BLL.Accounts.CreditAccount item = new BLL.Accounts.CreditAccount();
            try
            {
                item = BLL.Accounts.CreditAccountManager.GetOneCreditAccount(accountID);
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
            BLL.SortableList<BLL.Accounts.CreditAccount> itemsAccountsCreditAccount = new BLL.SortableList<BLL.Accounts.CreditAccount>();
            itemsAccountsCreditAccount.Add((BLL.Accounts.CreditAccount)item);
            useCollections["Accounts.CreditAccount"] = itemsAccountsCreditAccount;
            BLL.SortableList<BLL.Accounts.Account> itemsAccountsAccount = new BLL.SortableList<BLL.Accounts.Account>();
            itemsAccountsAccount.Add((BLL.Accounts.Account)item);
            useCollections["Accounts.Account"] = itemsAccountsAccount;
            CreditAccount_Manager.PopulateItem(item, useCollections, performCascade, false, false, results);
            try
            {
                if (IsValidForUpdate(item, performCascade, results) == true)
                {
                    startTicks = DateTime.Now.Ticks;
                    BLL.Accounts.CreditAccountManager.UpdateOneCreditAccount(item, performCascade);
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
        /// <summary>This method is used to get CreditAccount items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.Accounts.CreditAccount> GetAllCreditAccountDataTest(MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get all items
            //
            try
            {
                startTicks = DateTime.Now.Ticks;
                BLL.SortableList<BLL.Accounts.CreditAccount> items = BLL.Accounts.CreditAccountManager.GetAllCreditAccountData();
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
        /// <summary>This method is used to get a set of CreditAccount items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.Accounts.CreditAccount> GetManyCreditAccountDataByCriteriaTest(MOD.Data.DataOptions dataOptions, MOD.Test.TestResults results)
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
                NamedObjectCollection nocCreditCardNumber = new NamedObjectCollection();
                NamedObjectCollection nocCreditCardName = new NamedObjectCollection();
                NamedObjectCollection nocExpirationDate = new NamedObjectCollection();
                NamedObjectCollection nocCreditCardTypeCode = new NamedObjectCollection();
                NamedObjectCollection nocAccountName = new NamedObjectCollection();
                NamedObjectCollection nocCurrencyCode = new NamedObjectCollection();
                NamedObjectCollection nocLastModifiedDate = new NamedObjectCollection();
                startTicks = DateTime.Now.Ticks;
                BLL.SortableList<BLL.Accounts.CreditAccount> items =  BLL.Accounts.CreditAccountManager.GetManyCreditAccountDataByCriteria(null, null, null, null, null, null, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                BLL.SortableList<BLL.Accounts.CreditAccount> specificItems = null;
                string specificWarnings = String.Empty;
                bool searchValueUsed = false;
                int paramCount = 0;
                if (items.Count < 1)
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "No items found in GetManyCreditAccountDataByCriteria generic search.", null);
                }
                paramCount = 0;
                foreach (BLL.Accounts.CreditAccount item in items)
                {
                    nocCreditCardNumber[TestHelper.GetStringKeyFromObject((object)(item.CreditCardNumber), paramCount)] = item.CreditCardNumber;
                    nocCreditCardName[TestHelper.GetStringKeyFromObject((object)(item.CreditCardName), paramCount)] = item.CreditCardName;
                    nocExpirationDate[TestHelper.GetStringKeyFromObject((object)(item.ExpirationDate), paramCount)] = item.ExpirationDate;
                    nocCreditCardTypeCode[TestHelper.GetStringKeyFromObject((object)(item.CreditCardTypeCode), paramCount)] = item.CreditCardTypeCode;
                    nocAccountName[TestHelper.GetStringKeyFromObject((object)(item.AccountName), paramCount)] = item.AccountName;
                    nocCurrencyCode[TestHelper.GetStringKeyFromObject((object)(item.CurrencyCode), paramCount)] = item.CurrencyCode;
                    nocLastModifiedDate[TestHelper.GetStringKeyFromObject((object)(item.LastModifiedDate), paramCount)] = item.LastModifiedDate;
                    paramCount++;
                }
                paramCount = 0;
                string itemCreditCardNumber = TestHelper.GetString(null, 50, nocCreditCardNumber, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Accounts.CreditAccountManager.GetManyCreditAccountDataByCriteria(itemCreditCardNumber, null, null, null, null, null, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyCreditAccountDataByCriteria search with CreditCardNumber = " + itemCreditCardNumber.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                string itemCreditCardName = TestHelper.GetString(null, 255, nocCreditCardName, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Accounts.CreditAccountManager.GetManyCreditAccountDataByCriteria(null, itemCreditCardName, null, null, null, null, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyCreditAccountDataByCriteria search with CreditCardName = " + itemCreditCardName.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                DateTime itemExpirationDate = TestHelper.GetDateTime(null, null, nocExpirationDate, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Accounts.CreditAccountManager.GetManyCreditAccountDataByCriteria(null, null, itemExpirationDate, null, null, null, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyCreditAccountDataByCriteria search with ExpirationDate = " + itemExpirationDate.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                int itemCreditCardTypeCode = TestHelper.GetInt(null, null, nocCreditCardTypeCode, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Accounts.CreditAccountManager.GetManyCreditAccountDataByCriteria(null, null, null, null, itemCreditCardTypeCode, null, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyCreditAccountDataByCriteria search with CreditCardTypeCode = " + itemCreditCardTypeCode.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                string itemAccountName = TestHelper.GetString(null, 255, nocAccountName, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Accounts.CreditAccountManager.GetManyCreditAccountDataByCriteria(null, null, null, null, null, itemAccountName, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyCreditAccountDataByCriteria search with AccountName = " + itemAccountName.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                int itemCurrencyCode = TestHelper.GetInt(null, null, nocCurrencyCode, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Accounts.CreditAccountManager.GetManyCreditAccountDataByCriteria(null, null, null, null, null, null, itemCurrencyCode, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyCreditAccountDataByCriteria search with CurrencyCode = " + itemCurrencyCode.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                DateTime itemLastModifiedDate = TestHelper.GetDateTime(null, null, nocLastModifiedDate, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Accounts.CreditAccountManager.GetManyCreditAccountDataByCriteria(null, null, null, null, null, null, null, itemLastModifiedDate, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyCreditAccountDataByCriteria search with LastModifiedDate = " + itemLastModifiedDate.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                if (specificWarnings != String.Empty)
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "Results were not returned for GetManyCreditAccountDataByCriteria specific searches.", new Exception(specificWarnings));
                }
                return items;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to delete CreditAccount items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Accounts.CreditAccount DeleteOneCreditAccountTest(Guid accountID, bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get and delete item
            //
            BLL.Accounts.CreditAccount item = new BLL.Accounts.CreditAccount();
            try
            {
                item = BLL.Accounts.CreditAccountManager.GetOneCreditAccount(accountID);
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
                    BLL.Accounts.CreditAccountManager.DeleteOneCreditAccount(item, performCascade);
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