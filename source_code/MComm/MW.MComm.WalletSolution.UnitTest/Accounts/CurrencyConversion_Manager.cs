

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
    /// <summary>This class contains support methods to test CurrencyConversion instances.</summary>
    ///
    /// File History:
    /// <created>7/31/2007 (Brian MacDonald)</created>
    ///
    /// <remarks></remarks>
    // ------------------------------------------------------------------------------
    public partial class CurrencyConversion_Manager
    {

		#region Properties
        #endregion Properties

        #region Constructors

        // ------------------------------------------------------------------------------
        /// <summary>This method is the constructor (currently does nothing).</summary>
        // ------------------------------------------------------------------------------
        public CurrencyConversion_Manager()
        {
            //
            // constructor logic
            //
        }

        #endregion Constructors

		#region Methods

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add CurrencyConversion items.</summary>
        // ------------------------------------------------------------------------------
        public static void PopulateItem(BLL.Accounts.CurrencyConversion item, MOD.Data.NamedObjectCollection useCollections, bool performCascade, bool isAddOperation, bool isCollectionOperation, MOD.Test.TestResults results)
        {
            if (item == null)
            {
                return;
            }

            //
            // populate the CurrencyConversion item
            //
            int totalRecords = 0;
            bool totalRecordsExceeded = false;
            if (isAddOperation == true)
            {
                item.CurrencyConversionID = TestHelper.GetGuid();
            }
            BLL.SortableList<BLL.Accounts.Currency> itemCurrencyConvertFromCurrencyCode = null;
            if (useCollections != null && useCollections["Accounts.Currency"] != null)
            {
                itemCurrencyConvertFromCurrencyCode = (BLL.SortableList<BLL.Accounts.Currency>)useCollections["Accounts.Currency"];
            }
            if (itemCurrencyConvertFromCurrencyCode == null || itemCurrencyConvertFromCurrencyCode.Count <= 0)
            {
                itemCurrencyConvertFromCurrencyCode = BLL.Accounts.CurrencyManager.GetAllCurrencyData();
            }
            if (itemCurrencyConvertFromCurrencyCode.Count > 0)
            {
                int index = TestHelper.GetInt(0, Math.Max(0, itemCurrencyConvertFromCurrencyCode.Count-1));
                item.ConvertFromCurrencyCode = itemCurrencyConvertFromCurrencyCode[index].CurrencyCode;
            }
            else
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Could not find values for Currency.", null);
            }
            BLL.SortableList<BLL.Accounts.Currency> itemCurrencyConvertToCurrencyCode = null;
            if (useCollections != null && useCollections["Accounts.Currency"] != null)
            {
                itemCurrencyConvertToCurrencyCode = (BLL.SortableList<BLL.Accounts.Currency>)useCollections["Accounts.Currency"];
            }
            if (itemCurrencyConvertToCurrencyCode == null || itemCurrencyConvertToCurrencyCode.Count <= 0)
            {
                itemCurrencyConvertToCurrencyCode = BLL.Accounts.CurrencyManager.GetAllCurrencyData();
            }
            if (itemCurrencyConvertToCurrencyCode.Count > 0)
            {
                int index = TestHelper.GetInt(0, Math.Max(0, itemCurrencyConvertToCurrencyCode.Count-1));
                item.ConvertToCurrencyCode = itemCurrencyConvertToCurrencyCode[index].CurrencyCode;
            }
            else
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Could not find values for Currency.", null);
            }
            totalRecords = 0;
            totalRecordsExceeded = false;
            BLL.SortableList<BLL.Customers.Business> itemBusinessMetaPartnerID = null;
            if (useCollections != null && useCollections["Customers.Business"] != null)
            {
                itemBusinessMetaPartnerID = (BLL.SortableList<BLL.Customers.Business>)useCollections["Customers.Business"];
            }
            if (itemBusinessMetaPartnerID == null || itemBusinessMetaPartnerID.Count <= 0)
            {
                itemBusinessMetaPartnerID = BLL.Customers.BusinessManager.GetManyBusinessDataByCriteria(null, null, null, null, null, null, out totalRecords, out totalRecordsExceeded, Globals.getDataOptions("","",1,200,2000));
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
            }
            if (itemBusinessMetaPartnerID.Count > 0)
            {
                int index = TestHelper.GetInt(0, Math.Max(0, itemBusinessMetaPartnerID.Count-1));
                item.MetaPartnerID = itemBusinessMetaPartnerID[index].MetaPartnerID;
            }
            else
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Could not find values for Business.", null);
            }
            item.ConversionRate = TestHelper.GetFloat(null, null);
            item.IsActive = TestHelper.GetBool();
            PopulateItemCleanup(item, useCollections, performCascade, isAddOperation, isCollectionOperation, results);
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add CurrencyConversion items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Accounts.CurrencyConversion AddOneCurrencyConversionTest(bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // add item
            //
            BLL.Accounts.CurrencyConversion item = new BLL.Accounts.CurrencyConversion();
            MOD.Data.NamedObjectCollection useCollections = new MOD.Data.NamedObjectCollection();
            BLL.SortableList<BLL.Accounts.CurrencyConversion> itemsAccountsCurrencyConversion = new BLL.SortableList<BLL.Accounts.CurrencyConversion>();
            itemsAccountsCurrencyConversion.Add((BLL.Accounts.CurrencyConversion)item);
            useCollections["Accounts.CurrencyConversion"] = itemsAccountsCurrencyConversion;
            CurrencyConversion_Manager.PopulateItem(item, useCollections, performCascade, true, false, results);
            results.IsCollision = false; // discard collection collisions
            BLL.Accounts.CurrencyConversion item2 = null;
            try
            {
                item2 = BLL.Accounts.CurrencyConversionManager.GetOneCurrencyConversion(item.CurrencyConversionID);
            }
            catch (UnitTestException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Get failed for CurrencyConversion: " + item.PrimaryKey.ToString(), ex);
            }
            if (item2 != null)
            {
                results.IsCollision = true;
                throw new UnitTestException(UnitTestErrorType.Warning, "Add collision encountered for CurrencyConversion: " + item.PrimaryKey.ToString(), null);
            }
            if (results.IsCollision == false)
            {
                try
                {
                    if (IsValidForAdd(item, performCascade, results) == true)
                    {
                        startTicks = DateTime.Now.Ticks;
                        BLL.Accounts.CurrencyConversionManager.UpsertOneCurrencyConversion(item, performCascade);
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
        /// <summary>This method is used to update CurrencyConversion items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Accounts.CurrencyConversion UpdateOneCurrencyConversionTest(Guid currencyConversionID, bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get and update item
            //
            BLL.Accounts.CurrencyConversion item = new BLL.Accounts.CurrencyConversion();
            try
            {
                item = BLL.Accounts.CurrencyConversionManager.GetOneCurrencyConversion(currencyConversionID);
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
            BLL.SortableList<BLL.Accounts.CurrencyConversion> itemsAccountsCurrencyConversion = new BLL.SortableList<BLL.Accounts.CurrencyConversion>();
            itemsAccountsCurrencyConversion.Add((BLL.Accounts.CurrencyConversion)item);
            useCollections["Accounts.CurrencyConversion"] = itemsAccountsCurrencyConversion;
            CurrencyConversion_Manager.PopulateItem(item, useCollections, performCascade, false, false, results);
            try
            {
                if (IsValidForUpdate(item, performCascade, results) == true)
                {
                    startTicks = DateTime.Now.Ticks;
                    BLL.Accounts.CurrencyConversionManager.UpsertOneCurrencyConversion(item, performCascade);
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
        /// <summary>This method is used to get CurrencyConversion items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.Accounts.CurrencyConversion> GetAllCurrencyConversionDataTest(MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get all items
            //
            try
            {
                startTicks = DateTime.Now.Ticks;
                BLL.SortableList<BLL.Accounts.CurrencyConversion> items = BLL.Accounts.CurrencyConversionManager.GetAllCurrencyConversionData();
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
        /// <summary>This method is used to get a set of CurrencyConversion items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.Accounts.CurrencyConversion> GetManyCurrencyConversionDataByCriteriaTest(MOD.Data.DataOptions dataOptions, MOD.Test.TestResults results)
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
                NamedObjectCollection nocConvertFromCurrencyCode = new NamedObjectCollection();
                NamedObjectCollection nocConvertToCurrencyCode = new NamedObjectCollection();
                NamedObjectCollection nocLastModifiedDate = new NamedObjectCollection();
                startTicks = DateTime.Now.Ticks;
                BLL.SortableList<BLL.Accounts.CurrencyConversion> items =  BLL.Accounts.CurrencyConversionManager.GetManyCurrencyConversionDataByCriteria(null, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                BLL.SortableList<BLL.Accounts.CurrencyConversion> specificItems = null;
                string specificWarnings = String.Empty;
                bool searchValueUsed = false;
                int paramCount = 0;
                if (items.Count < 1)
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "No items found in GetManyCurrencyConversionDataByCriteria generic search.", null);
                }
                paramCount = 0;
                foreach (BLL.Accounts.CurrencyConversion item in items)
                {
                    nocConvertFromCurrencyCode[TestHelper.GetStringKeyFromObject((object)(item.ConvertFromCurrencyCode), paramCount)] = item.ConvertFromCurrencyCode;
                    nocConvertToCurrencyCode[TestHelper.GetStringKeyFromObject((object)(item.ConvertToCurrencyCode), paramCount)] = item.ConvertToCurrencyCode;
                    nocLastModifiedDate[TestHelper.GetStringKeyFromObject((object)(item.LastModifiedDate), paramCount)] = item.LastModifiedDate;
                    paramCount++;
                }
                paramCount = 0;
                int itemConvertFromCurrencyCode = TestHelper.GetInt(null, null, nocConvertFromCurrencyCode, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Accounts.CurrencyConversionManager.GetManyCurrencyConversionDataByCriteria(itemConvertFromCurrencyCode, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyCurrencyConversionDataByCriteria search with ConvertFromCurrencyCode = " + itemConvertFromCurrencyCode.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                int itemConvertToCurrencyCode = TestHelper.GetInt(null, null, nocConvertToCurrencyCode, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Accounts.CurrencyConversionManager.GetManyCurrencyConversionDataByCriteria(null, itemConvertToCurrencyCode, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyCurrencyConversionDataByCriteria search with ConvertToCurrencyCode = " + itemConvertToCurrencyCode.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                DateTime itemLastModifiedDate = TestHelper.GetDateTime(null, null, nocLastModifiedDate, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Accounts.CurrencyConversionManager.GetManyCurrencyConversionDataByCriteria(null, null, itemLastModifiedDate, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyCurrencyConversionDataByCriteria search with LastModifiedDate = " + itemLastModifiedDate.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                if (specificWarnings != String.Empty)
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "Results were not returned for GetManyCurrencyConversionDataByCriteria specific searches.", new Exception(specificWarnings));
                }
                return items;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to delete CurrencyConversion items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Accounts.CurrencyConversion DeleteOneCurrencyConversionTest(Guid currencyConversionID, bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get and delete item
            //
            BLL.Accounts.CurrencyConversion item = new BLL.Accounts.CurrencyConversion();
            try
            {
                item = BLL.Accounts.CurrencyConversionManager.GetOneCurrencyConversion(currencyConversionID);
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
                    BLL.Accounts.CurrencyConversionManager.DeleteOneCurrencyConversion(item, performCascade);
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