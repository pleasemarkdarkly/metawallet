

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

namespace MW.MComm.WalletSolution.UnitTest.Events
{
    // ------------------------------------------------------------------------------
    /// <summary>This class contains support methods to test EventAttribute instances.</summary>
    ///
    /// File History:
    /// <created>7/31/2007 (Brian MacDonald)</created>
    ///
    /// <remarks></remarks>
    // ------------------------------------------------------------------------------
    public partial class EventAttribute_Manager
    {

		#region Properties
        #endregion Properties

        #region Constructors

        // ------------------------------------------------------------------------------
        /// <summary>This method is the constructor (currently does nothing).</summary>
        // ------------------------------------------------------------------------------
        public EventAttribute_Manager()
        {
            //
            // constructor logic
            //
        }

        #endregion Constructors

		#region Methods

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add EventAttribute items.</summary>
        // ------------------------------------------------------------------------------
        public static void PopulateItem(BLL.Events.EventAttribute item, MOD.Data.NamedObjectCollection useCollections, bool performCascade, bool isAddOperation, bool isCollectionOperation, MOD.Test.TestResults results)
        {
            if (item == null)
            {
                return;
            }

            //
            // populate the EventAttribute item
            //
            MW.MComm.WalletSolution.UnitTest.Core.BaseAttribute_Manager.PopulateItem((BLL.Core.BaseAttribute)item, useCollections, performCascade, isAddOperation, isCollectionOperation, results);
            if (isAddOperation == true)
            {
                item.BaseAttributeID = TestHelper.GetGuid();
            }
            item.AttributeCode = TestHelper.GetInt(null, null);
            PopulateItemCleanup(item, useCollections, performCascade, isAddOperation, isCollectionOperation, results);
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add EventAttribute items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Events.EventAttribute AddOneEventAttributeTest(bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // add item
            //
            BLL.Events.EventAttribute item = new BLL.Events.EventAttribute();
            MOD.Data.NamedObjectCollection useCollections = new MOD.Data.NamedObjectCollection();
            BLL.SortableList<BLL.Events.EventAttribute> itemsEventsEventAttribute = new BLL.SortableList<BLL.Events.EventAttribute>();
            itemsEventsEventAttribute.Add((BLL.Events.EventAttribute)item);
            useCollections["Events.EventAttribute"] = itemsEventsEventAttribute;
            BLL.SortableList<BLL.Core.BaseAttribute> itemsCoreBaseAttribute = new BLL.SortableList<BLL.Core.BaseAttribute>();
            itemsCoreBaseAttribute.Add((BLL.Core.BaseAttribute)item);
            useCollections["Core.BaseAttribute"] = itemsCoreBaseAttribute;
            EventAttribute_Manager.PopulateItem(item, useCollections, performCascade, true, false, results);
            results.IsCollision = false; // discard collection collisions
            BLL.Events.EventAttribute item2 = null;
            try
            {
                item2 = BLL.Events.EventAttributeManager.GetOneEventAttribute(item.BaseAttributeID);
            }
            catch (UnitTestException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Get failed for EventAttribute: " + item.PrimaryKey.ToString(), ex);
            }
            if (item2 != null)
            {
                results.IsCollision = true;
                throw new UnitTestException(UnitTestErrorType.Warning, "Add collision encountered for EventAttribute: " + item.PrimaryKey.ToString(), null);
            }
            if (results.IsCollision == false)
            {
                try
                {
                    if (IsValidForAdd(item, performCascade, results) == true)
                    {
                        startTicks = DateTime.Now.Ticks;
                        BLL.Events.EventAttributeManager.AddOneEventAttribute(item, performCascade);
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
        /// <summary>This method is used to update EventAttribute items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Events.EventAttribute UpdateOneEventAttributeTest(Guid baseAttributeID, bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get and update item
            //
            BLL.Events.EventAttribute item = new BLL.Events.EventAttribute();
            try
            {
                item = BLL.Events.EventAttributeManager.GetOneEventAttribute(baseAttributeID);
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
            BLL.SortableList<BLL.Events.EventAttribute> itemsEventsEventAttribute = new BLL.SortableList<BLL.Events.EventAttribute>();
            itemsEventsEventAttribute.Add((BLL.Events.EventAttribute)item);
            useCollections["Events.EventAttribute"] = itemsEventsEventAttribute;
            BLL.SortableList<BLL.Core.BaseAttribute> itemsCoreBaseAttribute = new BLL.SortableList<BLL.Core.BaseAttribute>();
            itemsCoreBaseAttribute.Add((BLL.Core.BaseAttribute)item);
            useCollections["Core.BaseAttribute"] = itemsCoreBaseAttribute;
            EventAttribute_Manager.PopulateItem(item, useCollections, performCascade, false, false, results);
            try
            {
                if (IsValidForUpdate(item, performCascade, results) == true)
                {
                    startTicks = DateTime.Now.Ticks;
                    BLL.Events.EventAttributeManager.UpdateOneEventAttribute(item, performCascade);
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
        /// <summary>This method is used to get EventAttribute items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.Events.EventAttribute> GetAllEventAttributeDataTest(MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get all items
            //
            try
            {
                startTicks = DateTime.Now.Ticks;
                BLL.SortableList<BLL.Events.EventAttribute> items = BLL.Events.EventAttributeManager.GetAllEventAttributeData();
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
        /// <summary>This method is used to get a set of EventAttribute items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.Events.EventAttribute> GetManyEventAttributeDataByCriteriaTest(MOD.Data.DataOptions dataOptions, MOD.Test.TestResults results)
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
                NamedObjectCollection nocAttributeName = new NamedObjectCollection();
                NamedObjectCollection nocAttributeTypeCode = new NamedObjectCollection();
                NamedObjectCollection nocDataTypeCode = new NamedObjectCollection();
                NamedObjectCollection nocLastModifiedDate = new NamedObjectCollection();
                startTicks = DateTime.Now.Ticks;
                BLL.SortableList<BLL.Events.EventAttribute> items =  BLL.Events.EventAttributeManager.GetManyEventAttributeDataByCriteria(null, null, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                BLL.SortableList<BLL.Events.EventAttribute> specificItems = null;
                string specificWarnings = String.Empty;
                bool searchValueUsed = false;
                int paramCount = 0;
                if (items.Count < 1)
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "No items found in GetManyEventAttributeDataByCriteria generic search.", null);
                }
                paramCount = 0;
                foreach (BLL.Events.EventAttribute item in items)
                {
                    nocAttributeName[TestHelper.GetStringKeyFromObject((object)(item.AttributeName), paramCount)] = item.AttributeName;
                    nocAttributeTypeCode[TestHelper.GetStringKeyFromObject((object)(item.AttributeTypeCode), paramCount)] = item.AttributeTypeCode;
                    nocDataTypeCode[TestHelper.GetStringKeyFromObject((object)(item.DataTypeCode), paramCount)] = item.DataTypeCode;
                    nocLastModifiedDate[TestHelper.GetStringKeyFromObject((object)(item.LastModifiedDate), paramCount)] = item.LastModifiedDate;
                    paramCount++;
                }
                paramCount = 0;
                string itemAttributeName = TestHelper.GetString(null, 100, nocAttributeName, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Events.EventAttributeManager.GetManyEventAttributeDataByCriteria(itemAttributeName, null, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyEventAttributeDataByCriteria search with AttributeName = " + itemAttributeName.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                int itemAttributeTypeCode = TestHelper.GetInt(null, null, nocAttributeTypeCode, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Events.EventAttributeManager.GetManyEventAttributeDataByCriteria(null, itemAttributeTypeCode, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyEventAttributeDataByCriteria search with AttributeTypeCode = " + itemAttributeTypeCode.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                int itemDataTypeCode = TestHelper.GetInt(null, null, nocDataTypeCode, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Events.EventAttributeManager.GetManyEventAttributeDataByCriteria(null, null, itemDataTypeCode, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyEventAttributeDataByCriteria search with DataTypeCode = " + itemDataTypeCode.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                DateTime itemLastModifiedDate = TestHelper.GetDateTime(null, null, nocLastModifiedDate, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Events.EventAttributeManager.GetManyEventAttributeDataByCriteria(null, null, null, itemLastModifiedDate, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyEventAttributeDataByCriteria search with LastModifiedDate = " + itemLastModifiedDate.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                if (specificWarnings != String.Empty)
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "Results were not returned for GetManyEventAttributeDataByCriteria specific searches.", new Exception(specificWarnings));
                }
                return items;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to delete EventAttribute items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Events.EventAttribute DeleteOneEventAttributeTest(Guid baseAttributeID, bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get and delete item
            //
            BLL.Events.EventAttribute item = new BLL.Events.EventAttribute();
            try
            {
                item = BLL.Events.EventAttributeManager.GetOneEventAttribute(baseAttributeID);
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
                    BLL.Events.EventAttributeManager.DeleteOneEventAttribute(item, performCascade);
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