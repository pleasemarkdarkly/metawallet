

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
    /// <summary>This class contains support methods to test Event instances.</summary>
    ///
    /// File History:
    /// <created>7/31/2007 (Brian MacDonald)</created>
    ///
    /// <remarks></remarks>
    // ------------------------------------------------------------------------------
    public partial class Event_Manager
    {

		#region Properties
        #endregion Properties

        #region Constructors

        // ------------------------------------------------------------------------------
        /// <summary>This method is the constructor (currently does nothing).</summary>
        // ------------------------------------------------------------------------------
        public Event_Manager()
        {
            //
            // constructor logic
            //
        }

        #endregion Constructors

		#region Methods

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add Event items.</summary>
        // ------------------------------------------------------------------------------
        public static void PopulateItem(BLL.Events.Event item, MOD.Data.NamedObjectCollection useCollections, bool performCascade, bool isAddOperation, bool isCollectionOperation, MOD.Test.TestResults results)
        {
            if (item == null)
            {
                return;
            }

            //
            // populate the Event item
            //
            if (isAddOperation == true)
            {
                item.EventCode = TestHelper.GetInt(null, null);
            }
            item.EventName = TestHelper.GetString(null, 255);
            BLL.SortableList<BLL.Events.EventType> itemEventTypeEventTypeCode = null;
            if (useCollections != null && useCollections["Events.EventType"] != null)
            {
                itemEventTypeEventTypeCode = (BLL.SortableList<BLL.Events.EventType>)useCollections["Events.EventType"];
            }
            if (itemEventTypeEventTypeCode == null || itemEventTypeEventTypeCode.Count <= 0)
            {
                itemEventTypeEventTypeCode = BLL.Events.EventTypeManager.GetAllEventTypeData();
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
            item.Description = TestHelper.GetString(null, 2000);
            item.IsActive = TestHelper.GetBool();

            //
            // collections
            //
            if (performCascade == true && isAddOperation == true)
            {
                int collectionLoadCount = 0;
                collectionLoadCount = TestHelper.GetInt(Globals.MinimumLoadCountPerCollection, Globals.MaximumLoadCountPerCollection);
                TestHelper.ReportValueToConsole("PopulateItem: Next collection load count", collectionLoadCount);
                item.SpecificEventAttributeList = new BLL.SortableList<BLL.Events.SpecificEventAttribute>();
                BLL.Events.SpecificEventAttribute vSpecificEventAttributeList = null;
                for (int j=0; j < collectionLoadCount; j++)
                {
                    vSpecificEventAttributeList = new BLL.Events.SpecificEventAttribute();
                    MW.MComm.WalletSolution.UnitTest.Events.SpecificEventAttribute_Manager.PopulateItem(vSpecificEventAttributeList, useCollections, false, true, true, results);
                    results.IsCollision = false;
                    foreach (BLL.Events.SpecificEventAttribute loopSpecificEventAttribute in item.SpecificEventAttributeList)
                    {
                        if (loopSpecificEventAttribute.PrimaryKey == vSpecificEventAttributeList.PrimaryKey)
                        {
                            Console.WriteLine("Collision in collection encountered for SpecificEventAttribute: " + vSpecificEventAttributeList.PrimaryKey.ToString());
                            results.IsCollision = true;
                            break;
                        }
                    }
                    if (results.IsCollision == false)
                    {
                        try
                        {
                            BLL.Events.SpecificEventAttribute item2 = BLL.Events.SpecificEventAttributeManager.GetOneSpecificEventAttribute(vSpecificEventAttributeList.EventCode, vSpecificEventAttributeList.BaseAttributeID);
                            if (item2 != null)
                            {
                                results.IsCollision = true;
                                Console.WriteLine("Add collision encountered for SpecificEventAttribute: " + item2.PrimaryKey.ToString());
                            }
                        }
                        catch (UnitTestException ex)
                        {
                            throw ex;
                        }
                        catch (System.Exception ex)
                        {
                            throw new UnitTestException(UnitTestErrorType.Warning, "Get failed for SpecificEventAttribute", ex);
                        }
                    }
                    if (results.IsCollision == false)
                    {
                        item.SpecificEventAttributeList.Add(vSpecificEventAttributeList);
                    }
                }
                collectionLoadCount = TestHelper.GetInt(Globals.MinimumLoadCountPerCollection, Globals.MaximumLoadCountPerCollection);
                TestHelper.ReportValueToConsole("PopulateItem: Next collection load count", collectionLoadCount);
                item.NotificationList = new BLL.SortableList<BLL.Notifications.Notification>();
                BLL.Notifications.Notification vNotificationList = null;
                for (int j=0; j < collectionLoadCount; j++)
                {
                    vNotificationList = new BLL.Notifications.Notification();
                    MW.MComm.WalletSolution.UnitTest.Notifications.Notification_Manager.PopulateItem(vNotificationList, useCollections, false, true, true, results);
                    results.IsCollision = false;
                    try
                    {
                        BLL.Notifications.Notification item2 = BLL.Notifications.NotificationManager.GetOneNotification(vNotificationList.NotificationCode);
                        if (item2 != null)
                        {
                            results.IsCollision = true;
                            Console.WriteLine("Add collision encountered for Notification: " + item2.PrimaryKey.ToString());
                        }
                    }
                    catch (UnitTestException ex)
                    {
                        throw ex;
                    }
                    catch (System.Exception ex)
                    {
                        throw new UnitTestException(UnitTestErrorType.Warning, "Get failed for Notification", ex);
                    }
                    if (results.IsCollision == false)
                    {
                        item.NotificationList.Add(vNotificationList);
                    }
                }
                collectionLoadCount = TestHelper.GetInt(Globals.MinimumLoadCountPerCollection, Globals.MaximumLoadCountPerCollection);
                TestHelper.ReportValueToConsole("PopulateItem: Next collection load count", collectionLoadCount);
                item.EventFeeList = new BLL.SortableList<BLL.Events.EventFee>();
                BLL.Events.EventFee vEventFeeList = null;
                for (int j=0; j < collectionLoadCount; j++)
                {
                    vEventFeeList = new BLL.Events.EventFee();
                    MW.MComm.WalletSolution.UnitTest.Events.EventFee_Manager.PopulateItem(vEventFeeList, useCollections, false, true, true, results);
                    results.IsCollision = false;
                    foreach (BLL.Events.EventFee loopEventFee in item.EventFeeList)
                    {
                        if (loopEventFee.PrimaryKey == vEventFeeList.PrimaryKey)
                        {
                            Console.WriteLine("Collision in collection encountered for EventFee: " + vEventFeeList.PrimaryKey.ToString());
                            results.IsCollision = true;
                            break;
                        }
                    }
                    if (results.IsCollision == false)
                    {
                        try
                        {
                            BLL.Events.EventFee item2 = BLL.Events.EventFeeManager.GetOneEventFee(vEventFeeList.EventCode, vEventFeeList.FeeCode);
                            if (item2 != null)
                            {
                                results.IsCollision = true;
                                Console.WriteLine("Add collision encountered for EventFee: " + item2.PrimaryKey.ToString());
                            }
                        }
                        catch (UnitTestException ex)
                        {
                            throw ex;
                        }
                        catch (System.Exception ex)
                        {
                            throw new UnitTestException(UnitTestErrorType.Warning, "Get failed for EventFee", ex);
                        }
                    }
                    if (results.IsCollision == false)
                    {
                        item.EventFeeList.Add(vEventFeeList);
                    }
                }
                collectionLoadCount = TestHelper.GetInt(Globals.MinimumLoadCountPerCollection, Globals.MaximumLoadCountPerCollection);
                TestHelper.ReportValueToConsole("PopulateItem: Next collection load count", collectionLoadCount);
                item.EventPromotionList = new BLL.SortableList<BLL.Events.EventPromotion>();
                BLL.Events.EventPromotion vEventPromotionList = null;
                for (int j=0; j < collectionLoadCount; j++)
                {
                    vEventPromotionList = new BLL.Events.EventPromotion();
                    MW.MComm.WalletSolution.UnitTest.Events.EventPromotion_Manager.PopulateItem(vEventPromotionList, useCollections, false, true, true, results);
                    results.IsCollision = false;
                    foreach (BLL.Events.EventPromotion loopEventPromotion in item.EventPromotionList)
                    {
                        if (loopEventPromotion.PrimaryKey == vEventPromotionList.PrimaryKey)
                        {
                            Console.WriteLine("Collision in collection encountered for EventPromotion: " + vEventPromotionList.PrimaryKey.ToString());
                            results.IsCollision = true;
                            break;
                        }
                    }
                    if (results.IsCollision == false)
                    {
                        try
                        {
                            BLL.Events.EventPromotion item2 = BLL.Events.EventPromotionManager.GetOneEventPromotion(vEventPromotionList.EventCode, vEventPromotionList.PromotionCode);
                            if (item2 != null)
                            {
                                results.IsCollision = true;
                                Console.WriteLine("Add collision encountered for EventPromotion: " + item2.PrimaryKey.ToString());
                            }
                        }
                        catch (UnitTestException ex)
                        {
                            throw ex;
                        }
                        catch (System.Exception ex)
                        {
                            throw new UnitTestException(UnitTestErrorType.Warning, "Get failed for EventPromotion", ex);
                        }
                    }
                    if (results.IsCollision == false)
                    {
                        item.EventPromotionList.Add(vEventPromotionList);
                    }
                }
                collectionLoadCount = TestHelper.GetInt(Globals.MinimumLoadCountPerCollection, Globals.MaximumLoadCountPerCollection);
                TestHelper.ReportValueToConsole("PopulateItem: Next collection load count", collectionLoadCount);
                item.AuditLogList = new BLL.SortableList<BLL.Events.AuditLog>();
                BLL.Events.AuditLog vAuditLogList = null;
                for (int j=0; j < collectionLoadCount; j++)
                {
                    vAuditLogList = new BLL.Events.AuditLog();
                    MW.MComm.WalletSolution.UnitTest.Events.AuditLog_Manager.PopulateItem(vAuditLogList, useCollections, false, true, true, results);
                    results.IsCollision = false;
                    try
                    {
                        BLL.Events.AuditLog item2 = BLL.Events.AuditLogManager.GetOneAuditLog(vAuditLogList.AuditLogID);
                        if (item2 != null)
                        {
                            results.IsCollision = true;
                            Console.WriteLine("Add collision encountered for AuditLog: " + item2.PrimaryKey.ToString());
                        }
                    }
                    catch (UnitTestException ex)
                    {
                        throw ex;
                    }
                    catch (System.Exception ex)
                    {
                        throw new UnitTestException(UnitTestErrorType.Warning, "Get failed for AuditLog", ex);
                    }
                    if (results.IsCollision == false)
                    {
                        item.AuditLogList.Add(vAuditLogList);
                    }
                }
            }
            PopulateItemCleanup(item, useCollections, performCascade, isAddOperation, isCollectionOperation, results);
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add Event items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Events.Event AddOneEventTest(bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // add item
            //
            BLL.Events.Event item = new BLL.Events.Event();
            MOD.Data.NamedObjectCollection useCollections = new MOD.Data.NamedObjectCollection();
            BLL.SortableList<BLL.Events.Event> itemsEventsEvent = new BLL.SortableList<BLL.Events.Event>();
            itemsEventsEvent.Add((BLL.Events.Event)item);
            useCollections["Events.Event"] = itemsEventsEvent;
            Event_Manager.PopulateItem(item, useCollections, performCascade, true, false, results);
            results.IsCollision = false; // discard collection collisions
            BLL.Events.Event item2 = null;
            try
            {
                item2 = BLL.Events.EventManager.GetOneEvent(item.EventCode);
            }
            catch (UnitTestException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Get failed for Event: " + item.PrimaryKey.ToString(), ex);
            }
            if (item2 != null)
            {
                results.IsCollision = true;
                throw new UnitTestException(UnitTestErrorType.Warning, "Add collision encountered for Event: " + item.PrimaryKey.ToString(), null);
            }
            if (results.IsCollision == false)
            {
                try
                {
                    if (IsValidForAdd(item, performCascade, results) == true)
                    {
                        startTicks = DateTime.Now.Ticks;
                        BLL.Events.EventManager.AddOneEvent(item, performCascade);
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
        /// <summary>This method is used to update Event items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Events.Event UpdateOneEventTest(int eventCode, bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get and update item
            //
            BLL.Events.Event item = new BLL.Events.Event();
            try
            {
                item = BLL.Events.EventManager.GetOneEvent(eventCode);
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
            BLL.SortableList<BLL.Events.Event> itemsEventsEvent = new BLL.SortableList<BLL.Events.Event>();
            itemsEventsEvent.Add((BLL.Events.Event)item);
            useCollections["Events.Event"] = itemsEventsEvent;
            Event_Manager.PopulateItem(item, useCollections, performCascade, false, false, results);
            try
            {
                if (IsValidForUpdate(item, performCascade, results) == true)
                {
                    startTicks = DateTime.Now.Ticks;
                    BLL.Events.EventManager.UpdateOneEvent(item, performCascade);
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
        /// <summary>This method is used to get Event items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.Events.Event> GetAllEventDataTest(MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get all items
            //
            try
            {
                startTicks = DateTime.Now.Ticks;
                BLL.SortableList<BLL.Events.Event> items = BLL.Events.EventManager.GetAllEventData();
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
        /// <summary>This method is used to get a set of Event items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.Events.Event> GetManyEventDataByCriteriaTest(MOD.Data.DataOptions dataOptions, MOD.Test.TestResults results)
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
                NamedObjectCollection nocEventTypeCode = new NamedObjectCollection();
                NamedObjectCollection nocLastModifiedDate = new NamedObjectCollection();
                startTicks = DateTime.Now.Ticks;
                BLL.SortableList<BLL.Events.Event> items =  BLL.Events.EventManager.GetManyEventDataByCriteria(null, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                BLL.SortableList<BLL.Events.Event> specificItems = null;
                string specificWarnings = String.Empty;
                bool searchValueUsed = false;
                int paramCount = 0;
                if (items.Count < 1)
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "No items found in GetManyEventDataByCriteria generic search.", null);
                }
                paramCount = 0;
                foreach (BLL.Events.Event item in items)
                {
                    nocEventName[TestHelper.GetStringKeyFromObject((object)(item.EventName), paramCount)] = item.EventName;
                    nocEventTypeCode[TestHelper.GetStringKeyFromObject((object)(item.EventTypeCode), paramCount)] = item.EventTypeCode;
                    nocLastModifiedDate[TestHelper.GetStringKeyFromObject((object)(item.LastModifiedDate), paramCount)] = item.LastModifiedDate;
                    paramCount++;
                }
                paramCount = 0;
                string itemEventName = TestHelper.GetString(null, 255, nocEventName, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Events.EventManager.GetManyEventDataByCriteria(itemEventName, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyEventDataByCriteria search with EventName = " + itemEventName.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                int itemEventTypeCode = TestHelper.GetInt(null, null, nocEventTypeCode, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Events.EventManager.GetManyEventDataByCriteria(null, itemEventTypeCode, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyEventDataByCriteria search with EventTypeCode = " + itemEventTypeCode.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                DateTime itemLastModifiedDate = TestHelper.GetDateTime(null, null, nocLastModifiedDate, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Events.EventManager.GetManyEventDataByCriteria(null, null, itemLastModifiedDate, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyEventDataByCriteria search with LastModifiedDate = " + itemLastModifiedDate.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                if (specificWarnings != String.Empty)
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "Results were not returned for GetManyEventDataByCriteria specific searches.", new Exception(specificWarnings));
                }
                return items;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to delete Event items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Events.Event DeleteOneEventTest(int eventCode, bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get and delete item
            //
            BLL.Events.Event item = new BLL.Events.Event();
            try
            {
                item = BLL.Events.EventManager.GetOneEvent(eventCode);
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
                    BLL.Events.EventManager.DeleteOneEvent(item, performCascade);
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