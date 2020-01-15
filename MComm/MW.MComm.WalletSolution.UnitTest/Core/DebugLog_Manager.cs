

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
    /// <summary>This class contains support methods to test DebugLog instances.</summary>
    ///
    /// File History:
    /// <created>7/31/2007 (Brian MacDonald)</created>
    ///
    /// <remarks></remarks>
    // ------------------------------------------------------------------------------
    public partial class DebugLog_Manager
    {

		#region Properties
        #endregion Properties

        #region Constructors

        // ------------------------------------------------------------------------------
        /// <summary>This method is the constructor (currently does nothing).</summary>
        // ------------------------------------------------------------------------------
        public DebugLog_Manager()
        {
            //
            // constructor logic
            //
        }

        #endregion Constructors

		#region Methods

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add DebugLog items.</summary>
        // ------------------------------------------------------------------------------
        public static void PopulateItem(BLL.Core.DebugLog item, MOD.Data.NamedObjectCollection useCollections, bool performCascade, bool isAddOperation, bool isCollectionOperation, MOD.Test.TestResults results)
        {
            if (item == null)
            {
                return;
            }

            //
            // populate the DebugLog item
            //
            if (isAddOperation == true)
            {
                item.DebugLogID = TestHelper.GetGuid();
            }
            item.EventName = TestHelper.GetString(null, 255);
            item.Message = TestHelper.GetString(null, 1000);
            item.ErrorNumber = TestHelper.GetNullableInt(null, null);
            BLL.SortableList<BLL.Core.EventType> itemEventTypeEventTypeCode = null;
            if (useCollections != null && useCollections["Core.EventType"] != null)
            {
                itemEventTypeEventTypeCode = (BLL.SortableList<BLL.Core.EventType>)useCollections["Core.EventType"];
            }
            if (itemEventTypeEventTypeCode == null || itemEventTypeEventTypeCode.Count <= 0)
            {
                itemEventTypeEventTypeCode = BLL.Core.EventTypeManager.GetAllEventTypeData();
            }
            if (itemEventTypeEventTypeCode.Count > 0)
            {
                int index = TestHelper.GetInt(0, Math.Max(0, itemEventTypeEventTypeCode.Count-1));
                item.EventTypeCode = itemEventTypeEventTypeCode[index].EventTypeCode;
            }
            else
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Could not find values for EventType.", null);
            }
            BLL.SortableList<BLL.Core.SeverityLevel> itemSeverityLevelSeverityLevelCode = null;
            if (useCollections != null && useCollections["Core.SeverityLevel"] != null)
            {
                itemSeverityLevelSeverityLevelCode = (BLL.SortableList<BLL.Core.SeverityLevel>)useCollections["Core.SeverityLevel"];
            }
            if (itemSeverityLevelSeverityLevelCode == null || itemSeverityLevelSeverityLevelCode.Count <= 0)
            {
                itemSeverityLevelSeverityLevelCode = BLL.Core.SeverityLevelManager.GetAllSeverityLevelData();
            }
            if (itemSeverityLevelSeverityLevelCode.Count > 0)
            {
                int index = TestHelper.GetInt(0, Math.Max(0, itemSeverityLevelSeverityLevelCode.Count-1));
                item.SeverityLevelCode = itemSeverityLevelSeverityLevelCode[index].SeverityLevelCode;
            }
            else
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Could not find values for SeverityLevel.", null);
            }

            //
            // collections
            //
            if (performCascade == true && isAddOperation == true)
            {
                int collectionLoadCount = 0;
                collectionLoadCount = TestHelper.GetInt(Globals.MinimumLoadCountPerCollection, Globals.MaximumLoadCountPerCollection);
                TestHelper.ReportValueToConsole("PopulateItem: Next collection load count", collectionLoadCount);
                item.DebugAttributeValueLogList = new BLL.SortableList<BLL.Core.DebugAttributeValueLog>();
                BLL.Core.DebugAttributeValueLog vDebugAttributeValueLogList = null;
                for (int j=0; j < collectionLoadCount; j++)
                {
                    vDebugAttributeValueLogList = new BLL.Core.DebugAttributeValueLog();
                    MW.MComm.WalletSolution.UnitTest.Core.DebugAttributeValueLog_Manager.PopulateItem(vDebugAttributeValueLogList, useCollections, false, true, true, results);
                    results.IsCollision = false;
                    try
                    {
                        BLL.Core.DebugAttributeValueLog item2 = BLL.Core.DebugAttributeValueLogManager.GetOneDebugAttributeValueLog(vDebugAttributeValueLogList.DebugAttributeValueLogID);
                        if (item2 != null)
                        {
                            results.IsCollision = true;
                            Console.WriteLine("Add collision encountered for DebugAttributeValueLog: " + item2.PrimaryKey.ToString());
                        }
                    }
                    catch (UnitTestException ex)
                    {
                        throw ex;
                    }
                    catch (System.Exception ex)
                    {
                        throw new UnitTestException(UnitTestErrorType.Warning, "Get failed for DebugAttributeValueLog", ex);
                    }
                    if (results.IsCollision == false)
                    {
                        item.DebugAttributeValueLogList.Add(vDebugAttributeValueLogList);
                    }
                }
            }
            PopulateItemCleanup(item, useCollections, performCascade, isAddOperation, isCollectionOperation, results);
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add DebugLog items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Core.DebugLog AddOneDebugLogTest(bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // add item
            //
            BLL.Core.DebugLog item = new BLL.Core.DebugLog();
            MOD.Data.NamedObjectCollection useCollections = new MOD.Data.NamedObjectCollection();
            BLL.SortableList<BLL.Core.DebugLog> itemsCoreDebugLog = new BLL.SortableList<BLL.Core.DebugLog>();
            itemsCoreDebugLog.Add((BLL.Core.DebugLog)item);
            useCollections["Core.DebugLog"] = itemsCoreDebugLog;
            DebugLog_Manager.PopulateItem(item, useCollections, performCascade, true, false, results);
            results.IsCollision = false; // discard collection collisions
            BLL.Core.DebugLog item2 = null;
            try
            {
                item2 = BLL.Core.DebugLogManager.GetOneDebugLog(item.DebugLogID);
            }
            catch (UnitTestException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Get failed for DebugLog: " + item.PrimaryKey.ToString(), ex);
            }
            if (item2 != null)
            {
                results.IsCollision = true;
                throw new UnitTestException(UnitTestErrorType.Warning, "Add collision encountered for DebugLog: " + item.PrimaryKey.ToString(), null);
            }
            if (results.IsCollision == false)
            {
                try
                {
                    if (IsValidForAdd(item, performCascade, results) == true)
                    {
                        startTicks = DateTime.Now.Ticks;
                        BLL.Core.DebugLogManager.LogOneDebugLog(item, performCascade);
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
        /// <summary>This method is used to get DebugLog items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.Core.DebugLog> GetAllDebugLogDataTest(MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get all items
            //
            try
            {
                startTicks = DateTime.Now.Ticks;
                BLL.SortableList<BLL.Core.DebugLog> items = BLL.Core.DebugLogManager.GetAllDebugLogData();
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
        /// <summary>This method is used to get a set of DebugLog items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.Core.DebugLog> GetManyDebugLogDataByCriteriaTest(MOD.Data.DataOptions dataOptions, MOD.Test.TestResults results)
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
                NamedObjectCollection nocEventName = new NamedObjectCollection();
                NamedObjectCollection nocErrorNumber = new NamedObjectCollection();
                NamedObjectCollection nocEventTypeCode = new NamedObjectCollection();
                NamedObjectCollection nocSeverityLevelCode = new NamedObjectCollection();
                NamedObjectCollection nocLastModifiedDate = new NamedObjectCollection();
                startTicks = DateTime.Now.Ticks;
                BLL.SortableList<BLL.Core.DebugLog> items =  BLL.Core.DebugLogManager.GetManyDebugLogDataByCriteria(null, null, null, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                BLL.SortableList<BLL.Core.DebugLog> specificItems = null;
                string specificWarnings = String.Empty;
                bool searchValueUsed = false;
                int paramCount = 0;
                if (items.Count < 1)
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "No items found in GetManyDebugLogDataByCriteria generic search.", null);
                }
                paramCount = 0;
                foreach (BLL.Core.DebugLog item in items)
                {
                    nocEventName[TestHelper.GetStringKeyFromObject((object)(item.EventName), paramCount)] = item.EventName;
                    nocErrorNumber[TestHelper.GetStringKeyFromObject((object)(item.ErrorNumber), paramCount)] = item.ErrorNumber;
                    nocEventTypeCode[TestHelper.GetStringKeyFromObject((object)(item.EventTypeCode), paramCount)] = item.EventTypeCode;
                    nocSeverityLevelCode[TestHelper.GetStringKeyFromObject((object)(item.SeverityLevelCode), paramCount)] = item.SeverityLevelCode;
                    nocLastModifiedDate[TestHelper.GetStringKeyFromObject((object)(item.LastModifiedDate), paramCount)] = item.LastModifiedDate;
                    paramCount++;
                }
                paramCount = 0;
                string itemEventName = TestHelper.GetString(null, 255, nocEventName, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Core.DebugLogManager.GetManyDebugLogDataByCriteria(itemEventName, null, null, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyDebugLogDataByCriteria search with EventName = " + itemEventName.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                int itemErrorNumber = TestHelper.GetInt(null, null, nocErrorNumber, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Core.DebugLogManager.GetManyDebugLogDataByCriteria(null, itemErrorNumber, null, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyDebugLogDataByCriteria search with ErrorNumber = " + itemErrorNumber.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                int itemEventTypeCode = TestHelper.GetInt(null, null, nocEventTypeCode, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Core.DebugLogManager.GetManyDebugLogDataByCriteria(null, null, itemEventTypeCode, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyDebugLogDataByCriteria search with EventTypeCode = " + itemEventTypeCode.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                int itemSeverityLevelCode = TestHelper.GetInt(null, null, nocSeverityLevelCode, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Core.DebugLogManager.GetManyDebugLogDataByCriteria(null, null, null, itemSeverityLevelCode, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyDebugLogDataByCriteria search with SeverityLevelCode = " + itemSeverityLevelCode.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                DateTime itemLastModifiedDate = TestHelper.GetDateTime(null, null, nocLastModifiedDate, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Core.DebugLogManager.GetManyDebugLogDataByCriteria(null, null, null, null, itemLastModifiedDate, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyDebugLogDataByCriteria search with LastModifiedDate = " + itemLastModifiedDate.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                if (specificWarnings != String.Empty)
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "Results were not returned for GetManyDebugLogDataByCriteria specific searches.", new Exception(specificWarnings));
                }
                return items;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        #endregion Methods
    }
}