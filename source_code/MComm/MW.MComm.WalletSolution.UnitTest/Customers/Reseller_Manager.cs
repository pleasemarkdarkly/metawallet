

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
    /// <summary>This class contains support methods to test Reseller instances.</summary>
    ///
    /// File History:
    /// <created>7/31/2007 (Brian MacDonald)</created>
    ///
    /// <remarks></remarks>
    // ------------------------------------------------------------------------------
    public partial class Reseller_Manager
    {

		#region Properties
        #endregion Properties

        #region Constructors

        // ------------------------------------------------------------------------------
        /// <summary>This method is the constructor (currently does nothing).</summary>
        // ------------------------------------------------------------------------------
        public Reseller_Manager()
        {
            //
            // constructor logic
            //
        }

        #endregion Constructors

		#region Methods

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add Reseller items.</summary>
        // ------------------------------------------------------------------------------
        public static void PopulateItem(BLL.Customers.Reseller item, MOD.Data.NamedObjectCollection useCollections, bool performCascade, bool isAddOperation, bool isCollectionOperation, MOD.Test.TestResults results)
        {
            if (item == null)
            {
                return;
            }

            //
            // populate the Reseller item
            //
            MW.MComm.WalletSolution.UnitTest.Customers.Business_Manager.PopulateItem((BLL.Customers.Business)item, useCollections, performCascade, isAddOperation, isCollectionOperation, results);
            if (isAddOperation == true)
            {
                item.MetaPartnerID = TestHelper.GetGuid();
            }
            BLL.SortableList<BLL.Customers.ResellerType> itemResellerTypeResellerTypeCode = null;
            if (useCollections != null && useCollections["Customers.ResellerType"] != null)
            {
                itemResellerTypeResellerTypeCode = (BLL.SortableList<BLL.Customers.ResellerType>)useCollections["Customers.ResellerType"];
            }
            if (itemResellerTypeResellerTypeCode == null || itemResellerTypeResellerTypeCode.Count <= 0)
            {
                itemResellerTypeResellerTypeCode = BLL.Customers.ResellerTypeManager.GetAllResellerTypeData();
            }
            if (itemResellerTypeResellerTypeCode.Count > 0)
            {
                int index = TestHelper.GetInt(0, Math.Max(0, itemResellerTypeResellerTypeCode.Count-1));
                item.ResellerTypeCode = itemResellerTypeResellerTypeCode[index].ResellerTypeCode;
            }
            else
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Could not find values for ResellerType.", null);
            }
            PopulateItemCleanup(item, useCollections, performCascade, isAddOperation, isCollectionOperation, results);
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add Reseller items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Customers.Reseller AddOneResellerTest(bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // add item
            //
            BLL.Customers.Reseller item = new BLL.Customers.Reseller();
            MOD.Data.NamedObjectCollection useCollections = new MOD.Data.NamedObjectCollection();
            BLL.SortableList<BLL.Customers.Reseller> itemsCustomersReseller = new BLL.SortableList<BLL.Customers.Reseller>();
            itemsCustomersReseller.Add((BLL.Customers.Reseller)item);
            useCollections["Customers.Reseller"] = itemsCustomersReseller;
            BLL.SortableList<BLL.Customers.Business> itemsCustomersBusiness = new BLL.SortableList<BLL.Customers.Business>();
            itemsCustomersBusiness.Add((BLL.Customers.Business)item);
            useCollections["Customers.Business"] = itemsCustomersBusiness;
            BLL.SortableList<BLL.Customers.MetaPartner> itemsCustomersMetaPartner = new BLL.SortableList<BLL.Customers.MetaPartner>();
            itemsCustomersMetaPartner.Add((BLL.Customers.MetaPartner)item);
            useCollections["Customers.MetaPartner"] = itemsCustomersMetaPartner;
            Reseller_Manager.PopulateItem(item, useCollections, performCascade, true, false, results);
            results.IsCollision = false; // discard collection collisions
            BLL.Customers.Reseller item2 = null;
            try
            {
                item2 = BLL.Customers.ResellerManager.GetOneReseller(item.MetaPartnerID);
            }
            catch (UnitTestException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Get failed for Reseller: " + item.PrimaryKey.ToString(), ex);
            }
            if (item2 != null)
            {
                results.IsCollision = true;
                throw new UnitTestException(UnitTestErrorType.Warning, "Add collision encountered for Reseller: " + item.PrimaryKey.ToString(), null);
            }
            if (results.IsCollision == false)
            {
                try
                {
                    if (IsValidForAdd(item, performCascade, results) == true)
                    {
                        startTicks = DateTime.Now.Ticks;
                        BLL.Customers.ResellerManager.AddOneReseller(item, performCascade);
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
        /// <summary>This method is used to update Reseller items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Customers.Reseller UpdateOneResellerTest(Guid metaPartnerID, bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get and update item
            //
            BLL.Customers.Reseller item = new BLL.Customers.Reseller();
            try
            {
                item = BLL.Customers.ResellerManager.GetOneReseller(metaPartnerID);
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
            BLL.SortableList<BLL.Customers.Reseller> itemsCustomersReseller = new BLL.SortableList<BLL.Customers.Reseller>();
            itemsCustomersReseller.Add((BLL.Customers.Reseller)item);
            useCollections["Customers.Reseller"] = itemsCustomersReseller;
            BLL.SortableList<BLL.Customers.Business> itemsCustomersBusiness = new BLL.SortableList<BLL.Customers.Business>();
            itemsCustomersBusiness.Add((BLL.Customers.Business)item);
            useCollections["Customers.Business"] = itemsCustomersBusiness;
            BLL.SortableList<BLL.Customers.MetaPartner> itemsCustomersMetaPartner = new BLL.SortableList<BLL.Customers.MetaPartner>();
            itemsCustomersMetaPartner.Add((BLL.Customers.MetaPartner)item);
            useCollections["Customers.MetaPartner"] = itemsCustomersMetaPartner;
            Reseller_Manager.PopulateItem(item, useCollections, performCascade, false, false, results);
            try
            {
                if (IsValidForUpdate(item, performCascade, results) == true)
                {
                    startTicks = DateTime.Now.Ticks;
                    BLL.Customers.ResellerManager.UpdateOneReseller(item, performCascade);
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
        /// <summary>This method is used to get Reseller items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.Customers.Reseller> GetAllResellerDataTest(MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get all items
            //
            try
            {
                startTicks = DateTime.Now.Ticks;
                BLL.SortableList<BLL.Customers.Reseller> items = BLL.Customers.ResellerManager.GetAllResellerData();
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
        /// <summary>This method is used to get a set of Reseller items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.Customers.Reseller> GetManyResellerDataByCriteriaTest(MOD.Data.DataOptions dataOptions, MOD.Test.TestResults results)
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
                NamedObjectCollection nocResellerTypeCode = new NamedObjectCollection();
                NamedObjectCollection nocLocaleCode = new NamedObjectCollection();
                NamedObjectCollection nocCurrencyCode = new NamedObjectCollection();
                NamedObjectCollection nocDateFormatCode = new NamedObjectCollection();
                NamedObjectCollection nocLastModifiedDate = new NamedObjectCollection();
                NamedObjectCollection nocMetaPartnerName = new NamedObjectCollection();
                startTicks = DateTime.Now.Ticks;
                BLL.SortableList<BLL.Customers.Reseller> items =  BLL.Customers.ResellerManager.GetManyResellerDataByCriteria(null, null, null, null, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                BLL.SortableList<BLL.Customers.Reseller> specificItems = null;
                string specificWarnings = String.Empty;
                bool searchValueUsed = false;
                int paramCount = 0;
                if (items.Count < 1)
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "No items found in GetManyResellerDataByCriteria generic search.", null);
                }
                paramCount = 0;
                foreach (BLL.Customers.Reseller item in items)
                {
                    nocResellerTypeCode[TestHelper.GetStringKeyFromObject((object)(item.ResellerTypeCode), paramCount)] = item.ResellerTypeCode;
                    nocLocaleCode[TestHelper.GetStringKeyFromObject((object)(item.LocaleCode), paramCount)] = item.LocaleCode;
                    nocCurrencyCode[TestHelper.GetStringKeyFromObject((object)(item.CurrencyCode), paramCount)] = item.CurrencyCode;
                    nocDateFormatCode[TestHelper.GetStringKeyFromObject((object)(item.DateFormatCode), paramCount)] = item.DateFormatCode;
                    nocLastModifiedDate[TestHelper.GetStringKeyFromObject((object)(item.LastModifiedDate), paramCount)] = item.LastModifiedDate;
                    nocMetaPartnerName[TestHelper.GetStringKeyFromObject((object)(item.MetaPartnerName), paramCount)] = item.MetaPartnerName;
                    paramCount++;
                }
                paramCount = 0;
                int itemResellerTypeCode = TestHelper.GetInt(null, null, nocResellerTypeCode, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Customers.ResellerManager.GetManyResellerDataByCriteria(itemResellerTypeCode, null, null, null, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyResellerDataByCriteria search with ResellerTypeCode = " + itemResellerTypeCode.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                int itemLocaleCode = TestHelper.GetInt(null, null, nocLocaleCode, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Customers.ResellerManager.GetManyResellerDataByCriteria(null, itemLocaleCode, null, null, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyResellerDataByCriteria search with LocaleCode = " + itemLocaleCode.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                int itemCurrencyCode = TestHelper.GetInt(null, null, nocCurrencyCode, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Customers.ResellerManager.GetManyResellerDataByCriteria(null, null, itemCurrencyCode, null, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyResellerDataByCriteria search with CurrencyCode = " + itemCurrencyCode.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                int itemDateFormatCode = TestHelper.GetInt(null, null, nocDateFormatCode, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Customers.ResellerManager.GetManyResellerDataByCriteria(null, null, null, itemDateFormatCode, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyResellerDataByCriteria search with DateFormatCode = " + itemDateFormatCode.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                DateTime itemLastModifiedDate = TestHelper.GetDateTime(null, null, nocLastModifiedDate, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Customers.ResellerManager.GetManyResellerDataByCriteria(null, null, null, null, itemLastModifiedDate, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyResellerDataByCriteria search with LastModifiedDate = " + itemLastModifiedDate.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                string itemMetaPartnerName = TestHelper.GetString(null, 255, nocMetaPartnerName, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Customers.ResellerManager.GetManyResellerDataByCriteria(null, null, null, null, null, null, itemMetaPartnerName, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyResellerDataByCriteria search with MetaPartnerName = " + itemMetaPartnerName.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                if (specificWarnings != String.Empty)
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "Results were not returned for GetManyResellerDataByCriteria specific searches.", new Exception(specificWarnings));
                }
                return items;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to delete Reseller items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Customers.Reseller DeleteOneResellerTest(Guid metaPartnerID, bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get and delete item
            //
            BLL.Customers.Reseller item = new BLL.Customers.Reseller();
            try
            {
                item = BLL.Customers.ResellerManager.GetOneReseller(metaPartnerID);
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
                    BLL.Customers.ResellerManager.DeleteOneReseller(item, performCascade);
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