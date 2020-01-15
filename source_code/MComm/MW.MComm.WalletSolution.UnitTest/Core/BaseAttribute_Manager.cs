

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

namespace MW.MComm.WalletSolution.UnitTest.Core
{
    // ------------------------------------------------------------------------------
    /// <summary>This class contains support methods to test BaseAttribute instances.</summary>
    ///
    /// File History:
    /// <created>7/31/2007 (Brian MacDonald)</created>
    ///
    /// <remarks></remarks>
    // ------------------------------------------------------------------------------
    public partial class BaseAttribute_Manager
    {

		#region Properties
        #endregion Properties

        #region Constructors

        // ------------------------------------------------------------------------------
        /// <summary>This method is the constructor (currently does nothing).</summary>
        // ------------------------------------------------------------------------------
        public BaseAttribute_Manager()
        {
            //
            // constructor logic
            //
        }

        #endregion Constructors

		#region Methods

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add BaseAttribute items.</summary>
        // ------------------------------------------------------------------------------
        public static void PopulateItem(BLL.Core.BaseAttribute item, MOD.Data.NamedObjectCollection useCollections, bool performCascade, bool isAddOperation, bool isCollectionOperation, MOD.Test.TestResults results)
        {
            if (item == null)
            {
                return;
            }

            //
            // populate the BaseAttribute item
            //
            if (isAddOperation == true)
            {
                item.BaseAttributeID = TestHelper.GetGuid();
            }
            item.AttributeName = TestHelper.GetString(null, 100);
            BLL.SortableList<BLL.Core.AttributeType> itemAttributeTypeAttributeTypeCode = null;
            if (useCollections != null && useCollections["Core.AttributeType"] != null)
            {
                itemAttributeTypeAttributeTypeCode = (BLL.SortableList<BLL.Core.AttributeType>)useCollections["Core.AttributeType"];
            }
            if (itemAttributeTypeAttributeTypeCode == null || itemAttributeTypeAttributeTypeCode.Count <= 0)
            {
                itemAttributeTypeAttributeTypeCode = BLL.Core.AttributeTypeManager.GetAllAttributeTypeData();
            }
            if (itemAttributeTypeAttributeTypeCode.Count > 0)
            {
                int index = TestHelper.GetInt(0, Math.Max(0, itemAttributeTypeAttributeTypeCode.Count-1));
                item.AttributeTypeCode = itemAttributeTypeAttributeTypeCode[index].AttributeTypeCode;
            }
            else
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Could not find values for AttributeType.", null);
            }
            BLL.SortableList<BLL.Core.DataType> itemDataTypeDataTypeCode = null;
            if (useCollections != null && useCollections["Core.DataType"] != null)
            {
                itemDataTypeDataTypeCode = (BLL.SortableList<BLL.Core.DataType>)useCollections["Core.DataType"];
            }
            if (itemDataTypeDataTypeCode == null || itemDataTypeDataTypeCode.Count <= 0)
            {
                itemDataTypeDataTypeCode = BLL.Core.DataTypeManager.GetAllDataTypeData();
            }
            if (itemDataTypeDataTypeCode.Count > 0)
            {
                int index = TestHelper.GetInt(0, Math.Max(0, itemDataTypeDataTypeCode.Count-1));
                item.DataTypeCode = itemDataTypeDataTypeCode[index].DataTypeCode;
            }
            else
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Could not find values for DataType.", null);
            }
            item.Description = TestHelper.GetString(null, 1000);
            item.IsActive = TestHelper.GetBool();
            PopulateItemCleanup(item, useCollections, performCascade, isAddOperation, isCollectionOperation, results);
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add BaseAttribute items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Core.BaseAttribute AddOneBaseAttributeTest(bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // add item
            //
            BLL.Core.BaseAttribute item = new BLL.Core.BaseAttribute();
            MOD.Data.NamedObjectCollection useCollections = new MOD.Data.NamedObjectCollection();
            BLL.SortableList<BLL.Core.BaseAttribute> itemsCoreBaseAttribute = new BLL.SortableList<BLL.Core.BaseAttribute>();
            itemsCoreBaseAttribute.Add((BLL.Core.BaseAttribute)item);
            useCollections["Core.BaseAttribute"] = itemsCoreBaseAttribute;
            BaseAttribute_Manager.PopulateItem(item, useCollections, performCascade, true, false, results);
            results.IsCollision = false; // discard collection collisions
            BLL.Core.BaseAttribute item2 = null;
            try
            {
                item2 = BLL.Core.BaseAttributeManager.GetOneBaseAttribute(item.BaseAttributeID);
            }
            catch (UnitTestException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Get failed for BaseAttribute: " + item.PrimaryKey.ToString(), ex);
            }
            if (item2 != null)
            {
                results.IsCollision = true;
                throw new UnitTestException(UnitTestErrorType.Warning, "Add collision encountered for BaseAttribute: " + item.PrimaryKey.ToString(), null);
            }
            if (results.IsCollision == false)
            {
                try
                {
                    if (IsValidForAdd(item, performCascade, results) == true)
                    {
                        startTicks = DateTime.Now.Ticks;
                        BLL.Core.BaseAttributeManager.UpsertOneBaseAttribute(item, performCascade);
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
        /// <summary>This method is used to update BaseAttribute items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Core.BaseAttribute UpdateOneBaseAttributeTest(Guid baseAttributeID, bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get and update item
            //
            BLL.Core.BaseAttribute item = new BLL.Core.BaseAttribute();
            try
            {
                item = BLL.Core.BaseAttributeManager.GetOneBaseAttribute(baseAttributeID);
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
            BLL.SortableList<BLL.Core.BaseAttribute> itemsCoreBaseAttribute = new BLL.SortableList<BLL.Core.BaseAttribute>();
            itemsCoreBaseAttribute.Add((BLL.Core.BaseAttribute)item);
            useCollections["Core.BaseAttribute"] = itemsCoreBaseAttribute;
            BaseAttribute_Manager.PopulateItem(item, useCollections, performCascade, false, false, results);
            try
            {
                if (IsValidForUpdate(item, performCascade, results) == true)
                {
                    startTicks = DateTime.Now.Ticks;
                    BLL.Core.BaseAttributeManager.UpsertOneBaseAttribute(item, performCascade);
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
        /// <summary>This method is used to get BaseAttribute items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.Core.BaseAttribute> GetAllBaseAttributeDataTest(MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get all items
            //
            try
            {
                startTicks = DateTime.Now.Ticks;
                BLL.SortableList<BLL.Core.BaseAttribute> items = BLL.Core.BaseAttributeManager.GetAllBaseAttributeData();
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
        /// <summary>This method is used to get a set of BaseAttribute items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.Core.BaseAttribute> GetManyBaseAttributeDataByCriteriaTest(MOD.Data.DataOptions dataOptions, MOD.Test.TestResults results)
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
                BLL.SortableList<BLL.Core.BaseAttribute> items =  BLL.Core.BaseAttributeManager.GetManyBaseAttributeDataByCriteria(null, null, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                BLL.SortableList<BLL.Core.BaseAttribute> specificItems = null;
                string specificWarnings = String.Empty;
                bool searchValueUsed = false;
                int paramCount = 0;
                if (items.Count < 1)
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "No items found in GetManyBaseAttributeDataByCriteria generic search.", null);
                }
                paramCount = 0;
                foreach (BLL.Core.BaseAttribute item in items)
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
                specificItems =  BLL.Core.BaseAttributeManager.GetManyBaseAttributeDataByCriteria(itemAttributeName, null, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyBaseAttributeDataByCriteria search with AttributeName = " + itemAttributeName.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                int itemAttributeTypeCode = TestHelper.GetInt(null, null, nocAttributeTypeCode, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Core.BaseAttributeManager.GetManyBaseAttributeDataByCriteria(null, itemAttributeTypeCode, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyBaseAttributeDataByCriteria search with AttributeTypeCode = " + itemAttributeTypeCode.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                int itemDataTypeCode = TestHelper.GetInt(null, null, nocDataTypeCode, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Core.BaseAttributeManager.GetManyBaseAttributeDataByCriteria(null, null, itemDataTypeCode, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyBaseAttributeDataByCriteria search with DataTypeCode = " + itemDataTypeCode.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                DateTime itemLastModifiedDate = TestHelper.GetDateTime(null, null, nocLastModifiedDate, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Core.BaseAttributeManager.GetManyBaseAttributeDataByCriteria(null, null, null, itemLastModifiedDate, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyBaseAttributeDataByCriteria search with LastModifiedDate = " + itemLastModifiedDate.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                if (specificWarnings != String.Empty)
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "Results were not returned for GetManyBaseAttributeDataByCriteria specific searches.", new Exception(specificWarnings));
                }
                return items;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to delete BaseAttribute items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Core.BaseAttribute DeleteOneBaseAttributeTest(Guid baseAttributeID, bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get and delete item
            //
            BLL.Core.BaseAttribute item = new BLL.Core.BaseAttribute();
            try
            {
                item = BLL.Core.BaseAttributeManager.GetOneBaseAttribute(baseAttributeID);
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
                    BLL.Core.BaseAttributeManager.DeleteOneBaseAttribute(item, performCascade);
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