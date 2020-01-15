

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
    /// <summary>This class contains support methods to test AccountAttributeValue instances.</summary>
    ///
    /// File History:
    /// <created>7/31/2007 (Brian MacDonald)</created>
    ///
    /// <remarks></remarks>
    // ------------------------------------------------------------------------------
    public partial class AccountAttributeValue_Manager
    {

		#region Properties
        #endregion Properties

        #region Constructors

        // ------------------------------------------------------------------------------
        /// <summary>This method is the constructor (currently does nothing).</summary>
        // ------------------------------------------------------------------------------
        public AccountAttributeValue_Manager()
        {
            //
            // constructor logic
            //
        }

        #endregion Constructors

		#region Methods

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add AccountAttributeValue items.</summary>
        // ------------------------------------------------------------------------------
        public static void PopulateItem(BLL.Accounts.AccountAttributeValue item, MOD.Data.NamedObjectCollection useCollections, bool performCascade, bool isAddOperation, bool isCollectionOperation, MOD.Test.TestResults results)
        {
            if (item == null)
            {
                return;
            }

            //
            // populate the AccountAttributeValue item
            //
            int totalRecords = 0;
            bool totalRecordsExceeded = false;
            if (isAddOperation == true)
            {
                item.AccountAttributeValueID = TestHelper.GetGuid();
            }
            totalRecords = 0;
            totalRecordsExceeded = false;
            BLL.SortableList<BLL.Accounts.Account> itemAccountAccountID = null;
            if (useCollections != null && useCollections["Accounts.Account"] != null)
            {
                itemAccountAccountID = (BLL.SortableList<BLL.Accounts.Account>)useCollections["Accounts.Account"];
            }
            if (itemAccountAccountID == null || itemAccountAccountID.Count <= 0)
            {
                itemAccountAccountID = BLL.Accounts.AccountManager.GetManyAccountDataByCriteria(null, null, null, null, null, out totalRecords, out totalRecordsExceeded, Globals.getDataOptions("","",1,200,2000));
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
            }
            if (itemAccountAccountID.Count > 0)
            {
                int index = TestHelper.GetInt(0, Math.Max(0, itemAccountAccountID.Count-1));
                item.AccountID = itemAccountAccountID[index].AccountID;
            }
            else
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Could not find values for Account.", null);
            }
            totalRecords = 0;
            totalRecordsExceeded = false;
            BLL.SortableList<BLL.Accounts.AccountAttribute> itemAccountAttributeBaseAttributeID = null;
            if (useCollections != null && useCollections["Accounts.AccountAttribute"] != null)
            {
                itemAccountAttributeBaseAttributeID = (BLL.SortableList<BLL.Accounts.AccountAttribute>)useCollections["Accounts.AccountAttribute"];
            }
            if (itemAccountAttributeBaseAttributeID == null || itemAccountAttributeBaseAttributeID.Count <= 0)
            {
                itemAccountAttributeBaseAttributeID = BLL.Accounts.AccountAttributeManager.GetManyAccountAttributeDataByCriteria(null, null, null, null, null, out totalRecords, out totalRecordsExceeded, Globals.getDataOptions("","",1,200,2000));
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
            }
            if (itemAccountAttributeBaseAttributeID.Count > 0)
            {
                int index = TestHelper.GetInt(0, Math.Max(0, itemAccountAttributeBaseAttributeID.Count-1));
                item.BaseAttributeID = itemAccountAttributeBaseAttributeID[index].BaseAttributeID;
            }
            else
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Could not find values for AccountAttribute.", null);
            }
            item.ParameterValue = TestHelper.GetString(null, 255);
            PopulateItemCleanup(item, useCollections, performCascade, isAddOperation, isCollectionOperation, results);
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add AccountAttributeValue items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Accounts.AccountAttributeValue AddOneAccountAttributeValueTest(bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // add item
            //
            BLL.Accounts.AccountAttributeValue item = new BLL.Accounts.AccountAttributeValue();
            MOD.Data.NamedObjectCollection useCollections = new MOD.Data.NamedObjectCollection();
            BLL.SortableList<BLL.Accounts.AccountAttributeValue> itemsAccountsAccountAttributeValue = new BLL.SortableList<BLL.Accounts.AccountAttributeValue>();
            itemsAccountsAccountAttributeValue.Add((BLL.Accounts.AccountAttributeValue)item);
            useCollections["Accounts.AccountAttributeValue"] = itemsAccountsAccountAttributeValue;
            AccountAttributeValue_Manager.PopulateItem(item, useCollections, performCascade, true, false, results);
            results.IsCollision = false; // discard collection collisions
            BLL.Accounts.AccountAttributeValue item2 = null;
            try
            {
                item2 = BLL.Accounts.AccountAttributeValueManager.GetOneAccountAttributeValue(item.AccountAttributeValueID);
            }
            catch (UnitTestException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Get failed for AccountAttributeValue: " + item.PrimaryKey.ToString(), ex);
            }
            if (item2 != null)
            {
                results.IsCollision = true;
                throw new UnitTestException(UnitTestErrorType.Warning, "Add collision encountered for AccountAttributeValue: " + item.PrimaryKey.ToString(), null);
            }
            if (results.IsCollision == false)
            {
                try
                {
                    if (IsValidForAdd(item, performCascade, results) == true)
                    {
                        startTicks = DateTime.Now.Ticks;
                        BLL.Accounts.AccountAttributeValueManager.UpsertOneAccountAttributeValue(item, performCascade);
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
        /// <summary>This method is used to update AccountAttributeValue items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Accounts.AccountAttributeValue UpdateOneAccountAttributeValueTest(Guid accountAttributeValueID, bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get and update item
            //
            BLL.Accounts.AccountAttributeValue item = new BLL.Accounts.AccountAttributeValue();
            try
            {
                item = BLL.Accounts.AccountAttributeValueManager.GetOneAccountAttributeValue(accountAttributeValueID);
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
            BLL.SortableList<BLL.Accounts.AccountAttributeValue> itemsAccountsAccountAttributeValue = new BLL.SortableList<BLL.Accounts.AccountAttributeValue>();
            itemsAccountsAccountAttributeValue.Add((BLL.Accounts.AccountAttributeValue)item);
            useCollections["Accounts.AccountAttributeValue"] = itemsAccountsAccountAttributeValue;
            AccountAttributeValue_Manager.PopulateItem(item, useCollections, performCascade, false, false, results);
            try
            {
                if (IsValidForUpdate(item, performCascade, results) == true)
                {
                    startTicks = DateTime.Now.Ticks;
                    BLL.Accounts.AccountAttributeValueManager.UpsertOneAccountAttributeValue(item, performCascade);
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
        /// <summary>This method is used to get AccountAttributeValue items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.Accounts.AccountAttributeValue> GetAllAccountAttributeValueDataTest(MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get all items
            //
            try
            {
                startTicks = DateTime.Now.Ticks;
                BLL.SortableList<BLL.Accounts.AccountAttributeValue> items = BLL.Accounts.AccountAttributeValueManager.GetAllAccountAttributeValueData();
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
        /// <summary>This method is used to get a set of AccountAttributeValue items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.Accounts.AccountAttributeValue> GetManyAccountAttributeValueDataByCriteriaTest(MOD.Data.DataOptions dataOptions, MOD.Test.TestResults results)
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
                NamedObjectCollection nocParameterValue = new NamedObjectCollection();
                NamedObjectCollection nocLastModifiedDate = new NamedObjectCollection();
                startTicks = DateTime.Now.Ticks;
                BLL.SortableList<BLL.Accounts.AccountAttributeValue> items =  BLL.Accounts.AccountAttributeValueManager.GetManyAccountAttributeValueDataByCriteria(null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                BLL.SortableList<BLL.Accounts.AccountAttributeValue> specificItems = null;
                string specificWarnings = String.Empty;
                bool searchValueUsed = false;
                int paramCount = 0;
                if (items.Count < 1)
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "No items found in GetManyAccountAttributeValueDataByCriteria generic search.", null);
                }
                paramCount = 0;
                foreach (BLL.Accounts.AccountAttributeValue item in items)
                {
                    nocParameterValue[TestHelper.GetStringKeyFromObject((object)(item.ParameterValue), paramCount)] = item.ParameterValue;
                    nocLastModifiedDate[TestHelper.GetStringKeyFromObject((object)(item.LastModifiedDate), paramCount)] = item.LastModifiedDate;
                    paramCount++;
                }
                paramCount = 0;
                string itemParameterValue = TestHelper.GetString(null, 255, nocParameterValue, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Accounts.AccountAttributeValueManager.GetManyAccountAttributeValueDataByCriteria(itemParameterValue, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyAccountAttributeValueDataByCriteria search with ParameterValue = " + itemParameterValue.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                DateTime itemLastModifiedDate = TestHelper.GetDateTime(null, null, nocLastModifiedDate, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Accounts.AccountAttributeValueManager.GetManyAccountAttributeValueDataByCriteria(null, itemLastModifiedDate, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyAccountAttributeValueDataByCriteria search with LastModifiedDate = " + itemLastModifiedDate.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                if (specificWarnings != String.Empty)
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "Results were not returned for GetManyAccountAttributeValueDataByCriteria specific searches.", new Exception(specificWarnings));
                }
                return items;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to delete AccountAttributeValue items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Accounts.AccountAttributeValue DeleteOneAccountAttributeValueTest(Guid accountAttributeValueID, bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get and delete item
            //
            BLL.Accounts.AccountAttributeValue item = new BLL.Accounts.AccountAttributeValue();
            try
            {
                item = BLL.Accounts.AccountAttributeValueManager.GetOneAccountAttributeValue(accountAttributeValueID);
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
                    BLL.Accounts.AccountAttributeValueManager.DeleteOneAccountAttributeValue(item, performCascade);
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