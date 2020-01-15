

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
    /// <summary>This class contains support methods to test AuditAttributeValueLog instances.</summary>
    ///
    /// File History:
    /// <created>7/31/2007 (Brian MacDonald)</created>
    ///
    /// <remarks></remarks>
    // ------------------------------------------------------------------------------
    public partial class AuditAttributeValueLog_Manager
    {

		#region Properties
        #endregion Properties

        #region Constructors

        // ------------------------------------------------------------------------------
        /// <summary>This method is the constructor (currently does nothing).</summary>
        // ------------------------------------------------------------------------------
        public AuditAttributeValueLog_Manager()
        {
            //
            // constructor logic
            //
        }

        #endregion Constructors

		#region Methods

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add AuditAttributeValueLog items.</summary>
        // ------------------------------------------------------------------------------
        public static void PopulateItem(BLL.Events.AuditAttributeValueLog item, MOD.Data.NamedObjectCollection useCollections, bool performCascade, bool isAddOperation, bool isCollectionOperation, MOD.Test.TestResults results)
        {
            if (item == null)
            {
                return;
            }

            //
            // populate the AuditAttributeValueLog item
            //
            int totalRecords = 0;
            bool totalRecordsExceeded = false;
            if (isAddOperation == true)
            {
                item.AuditAttributeValueLogID = TestHelper.GetGuid();
            }
            totalRecords = 0;
            totalRecordsExceeded = false;
            BLL.SortableList<BLL.Events.AuditLog> itemAuditLogAuditLogID = null;
            if (useCollections != null && useCollections["Events.AuditLog"] != null)
            {
                itemAuditLogAuditLogID = (BLL.SortableList<BLL.Events.AuditLog>)useCollections["Events.AuditLog"];
            }
            if (itemAuditLogAuditLogID == null || itemAuditLogAuditLogID.Count <= 0)
            {
                itemAuditLogAuditLogID = BLL.Events.AuditLogManager.GetManyAuditLogDataByCriteria(null, null, null, out totalRecords, out totalRecordsExceeded, Globals.getDataOptions("","",1,200,2000));
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
            }
            if (itemAuditLogAuditLogID.Count > 0)
            {
                int index = TestHelper.GetInt(0, Math.Max(0, itemAuditLogAuditLogID.Count-1));
                item.AuditLogID = itemAuditLogAuditLogID[index].AuditLogID;
            }
            else
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Could not find values for AuditLog.", null);
            }
            totalRecords = 0;
            totalRecordsExceeded = false;
            BLL.SortableList<BLL.Events.EventAttribute> itemEventAttributeBaseAttributeID = null;
            if (useCollections != null && useCollections["Events.EventAttribute"] != null)
            {
                itemEventAttributeBaseAttributeID = (BLL.SortableList<BLL.Events.EventAttribute>)useCollections["Events.EventAttribute"];
            }
            if (itemEventAttributeBaseAttributeID == null || itemEventAttributeBaseAttributeID.Count <= 0)
            {
                itemEventAttributeBaseAttributeID = BLL.Events.EventAttributeManager.GetManyEventAttributeDataByCriteria(null, null, null, null, null, out totalRecords, out totalRecordsExceeded, Globals.getDataOptions("","",1,200,2000));
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
            }
            if (itemEventAttributeBaseAttributeID.Count > 0)
            {
                int index = TestHelper.GetInt(0, Math.Max(0, itemEventAttributeBaseAttributeID.Count-1));
                item.BaseAttributeID = itemEventAttributeBaseAttributeID[index].BaseAttributeID;
            }
            else
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Could not find values for EventAttribute.", null);
            }
            item.AttributeValue = TestHelper.GetString(null, 1000);
            PopulateItemCleanup(item, useCollections, performCascade, isAddOperation, isCollectionOperation, results);
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add AuditAttributeValueLog items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Events.AuditAttributeValueLog AddOneAuditAttributeValueLogTest(bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // add item
            //
            BLL.Events.AuditAttributeValueLog item = new BLL.Events.AuditAttributeValueLog();
            MOD.Data.NamedObjectCollection useCollections = new MOD.Data.NamedObjectCollection();
            BLL.SortableList<BLL.Events.AuditAttributeValueLog> itemsEventsAuditAttributeValueLog = new BLL.SortableList<BLL.Events.AuditAttributeValueLog>();
            itemsEventsAuditAttributeValueLog.Add((BLL.Events.AuditAttributeValueLog)item);
            useCollections["Events.AuditAttributeValueLog"] = itemsEventsAuditAttributeValueLog;
            AuditAttributeValueLog_Manager.PopulateItem(item, useCollections, performCascade, true, false, results);
            results.IsCollision = false; // discard collection collisions
            BLL.Events.AuditAttributeValueLog item2 = null;
            try
            {
                item2 = BLL.Events.AuditAttributeValueLogManager.GetOneAuditAttributeValueLog(item.AuditAttributeValueLogID);
            }
            catch (UnitTestException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Get failed for AuditAttributeValueLog: " + item.PrimaryKey.ToString(), ex);
            }
            if (item2 != null)
            {
                results.IsCollision = true;
                throw new UnitTestException(UnitTestErrorType.Warning, "Add collision encountered for AuditAttributeValueLog: " + item.PrimaryKey.ToString(), null);
            }
            if (results.IsCollision == false)
            {
                try
                {
                    if (IsValidForAdd(item, performCascade, results) == true)
                    {
                        startTicks = DateTime.Now.Ticks;
                        BLL.Events.AuditAttributeValueLogManager.LogOneAuditAttributeValueLog(item, performCascade);
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
        /// <summary>This method is used to get AuditAttributeValueLog items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.Events.AuditAttributeValueLog> GetAllAuditAttributeValueLogDataTest(MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get all items
            //
            try
            {
                startTicks = DateTime.Now.Ticks;
                BLL.SortableList<BLL.Events.AuditAttributeValueLog> items = BLL.Events.AuditAttributeValueLogManager.GetAllAuditAttributeValueLogData();
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
        /// <summary>This method is used to get a set of AuditAttributeValueLog items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.Events.AuditAttributeValueLog> GetManyAuditAttributeValueLogDataByCriteriaTest(MOD.Data.DataOptions dataOptions, MOD.Test.TestResults results)
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
                NamedObjectCollection nocAttributeValue = new NamedObjectCollection();
                NamedObjectCollection nocLastModifiedDate = new NamedObjectCollection();
                startTicks = DateTime.Now.Ticks;
                BLL.SortableList<BLL.Events.AuditAttributeValueLog> items =  BLL.Events.AuditAttributeValueLogManager.GetManyAuditAttributeValueLogDataByCriteria(null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                BLL.SortableList<BLL.Events.AuditAttributeValueLog> specificItems = null;
                string specificWarnings = String.Empty;
                bool searchValueUsed = false;
                int paramCount = 0;
                if (items.Count < 1)
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "No items found in GetManyAuditAttributeValueLogDataByCriteria generic search.", null);
                }
                paramCount = 0;
                foreach (BLL.Events.AuditAttributeValueLog item in items)
                {
                    nocAttributeValue[TestHelper.GetStringKeyFromObject((object)(item.AttributeValue), paramCount)] = item.AttributeValue;
                    nocLastModifiedDate[TestHelper.GetStringKeyFromObject((object)(item.LastModifiedDate), paramCount)] = item.LastModifiedDate;
                    paramCount++;
                }
                paramCount = 0;
                string itemAttributeValue = TestHelper.GetString(null, 1000, nocAttributeValue, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Events.AuditAttributeValueLogManager.GetManyAuditAttributeValueLogDataByCriteria(itemAttributeValue, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyAuditAttributeValueLogDataByCriteria search with AttributeValue = " + itemAttributeValue.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                DateTime itemLastModifiedDate = TestHelper.GetDateTime(null, null, nocLastModifiedDate, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Events.AuditAttributeValueLogManager.GetManyAuditAttributeValueLogDataByCriteria(null, itemLastModifiedDate, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyAuditAttributeValueLogDataByCriteria search with LastModifiedDate = " + itemLastModifiedDate.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                if (specificWarnings != String.Empty)
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "Results were not returned for GetManyAuditAttributeValueLogDataByCriteria specific searches.", new Exception(specificWarnings));
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