

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

namespace MW.MComm.WalletSolution.UnitTest.Notifications
{
    // ------------------------------------------------------------------------------
    /// <summary>This class contains support methods to test NotificationLog instances.</summary>
    ///
    /// File History:
    /// <created>7/31/2007 (Brian MacDonald)</created>
    ///
    /// <remarks></remarks>
    // ------------------------------------------------------------------------------
    public partial class NotificationLog_Manager
    {

		#region Properties
        #endregion Properties

        #region Constructors

        // ------------------------------------------------------------------------------
        /// <summary>This method is the constructor (currently does nothing).</summary>
        // ------------------------------------------------------------------------------
        public NotificationLog_Manager()
        {
            //
            // constructor logic
            //
        }

        #endregion Constructors

		#region Methods

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add NotificationLog items.</summary>
        // ------------------------------------------------------------------------------
        public static void PopulateItem(BLL.Notifications.NotificationLog item, MOD.Data.NamedObjectCollection useCollections, bool performCascade, bool isAddOperation, bool isCollectionOperation, MOD.Test.TestResults results)
        {
            if (item == null)
            {
                return;
            }

            //
            // populate the NotificationLog item
            //
            int totalRecords = 0;
            bool totalRecordsExceeded = false;
            if (isAddOperation == true)
            {
                item.NotificationLogID = TestHelper.GetGuid();
            }
            totalRecords = 0;
            totalRecordsExceeded = false;
            BLL.SortableList<BLL.Notifications.Notification> itemNotificationNotificationCode = null;
            if (useCollections != null && useCollections["Notifications.Notification"] != null)
            {
                itemNotificationNotificationCode = (BLL.SortableList<BLL.Notifications.Notification>)useCollections["Notifications.Notification"];
            }
            if (itemNotificationNotificationCode == null || itemNotificationNotificationCode.Count <= 0)
            {
                itemNotificationNotificationCode = BLL.Notifications.NotificationManager.GetManyNotificationDataByCriteria(null, null, null, null, out totalRecords, out totalRecordsExceeded, Globals.getDataOptions("","",1,200,2000));
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
            }
            if (itemNotificationNotificationCode.Count > 0)
            {
                int index = TestHelper.GetInt(0, Math.Max(0, itemNotificationNotificationCode.Count-1));
                item.NotificationCode = itemNotificationNotificationCode[index].NotificationCode;
            }
            else
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Could not find values for Notification.", null);
            }
            item.NotificationSubject = TestHelper.GetString(null, 255);
            item.NotificationMessage = TestHelper.GetString(null, 16);
            BLL.SortableList<BLL.Environments.Locale> itemLocaleLocaleCode = null;
            if (useCollections != null && useCollections["Environments.Locale"] != null)
            {
                itemLocaleLocaleCode = (BLL.SortableList<BLL.Environments.Locale>)useCollections["Environments.Locale"];
            }
            if (itemLocaleLocaleCode == null || itemLocaleLocaleCode.Count <= 0)
            {
                itemLocaleLocaleCode = BLL.Environments.LocaleManager.GetAllLocaleData();
            }
            if (itemLocaleLocaleCode.Count > 0)
            {
                int index = TestHelper.GetInt(0, Math.Max(0, itemLocaleLocaleCode.Count-1));
                item.LocaleCode = itemLocaleLocaleCode[index].LocaleCode;
            }
            else
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Could not find values for Locale.", null);
            }

            //
            // collections
            //
            if (performCascade == true && isAddOperation == true)
            {
                int collectionLoadCount = 0;
                collectionLoadCount = TestHelper.GetInt(Globals.MinimumLoadCountPerCollection, Globals.MaximumLoadCountPerCollection);
                TestHelper.ReportValueToConsole("PopulateItem: Next collection load count", collectionLoadCount);
                item.NotificationAttributeValueLogList = new BLL.SortableList<BLL.Notifications.NotificationAttributeValueLog>();
                BLL.Notifications.NotificationAttributeValueLog vNotificationAttributeValueLogList = null;
                for (int j=0; j < collectionLoadCount; j++)
                {
                    vNotificationAttributeValueLogList = new BLL.Notifications.NotificationAttributeValueLog();
                    MW.MComm.WalletSolution.UnitTest.Notifications.NotificationAttributeValueLog_Manager.PopulateItem(vNotificationAttributeValueLogList, useCollections, false, true, true, results);
                    results.IsCollision = false;
                    try
                    {
                        BLL.Notifications.NotificationAttributeValueLog item2 = BLL.Notifications.NotificationAttributeValueLogManager.GetOneNotificationAttributeValueLog(vNotificationAttributeValueLogList.NotificationAttributeValueLogID);
                        if (item2 != null)
                        {
                            results.IsCollision = true;
                            Console.WriteLine("Add collision encountered for NotificationAttributeValueLog: " + item2.PrimaryKey.ToString());
                        }
                    }
                    catch (UnitTestException ex)
                    {
                        throw ex;
                    }
                    catch (System.Exception ex)
                    {
                        throw new UnitTestException(UnitTestErrorType.Warning, "Get failed for NotificationAttributeValueLog", ex);
                    }
                    if (results.IsCollision == false)
                    {
                        item.NotificationAttributeValueLogList.Add(vNotificationAttributeValueLogList);
                    }
                }
                collectionLoadCount = TestHelper.GetInt(Globals.MinimumLoadCountPerCollection, Globals.MaximumLoadCountPerCollection);
                TestHelper.ReportValueToConsole("PopulateItem: Next collection load count", collectionLoadCount);
                item.NotificationDeliveryLogList = new BLL.SortableList<BLL.Notifications.NotificationDeliveryLog>();
                BLL.Notifications.NotificationDeliveryLog vNotificationDeliveryLogList = null;
                for (int j=0; j < collectionLoadCount; j++)
                {
                    vNotificationDeliveryLogList = new BLL.Notifications.NotificationDeliveryLog();
                    MW.MComm.WalletSolution.UnitTest.Notifications.NotificationDeliveryLog_Manager.PopulateItem(vNotificationDeliveryLogList, useCollections, false, true, true, results);
                    results.IsCollision = false;
                    foreach (BLL.Notifications.NotificationDeliveryLog loopNotificationDeliveryLog in item.NotificationDeliveryLogList)
                    {
                        if (loopNotificationDeliveryLog.PrimaryKey == vNotificationDeliveryLogList.PrimaryKey)
                        {
                            Console.WriteLine("Collision in collection encountered for NotificationDeliveryLog: " + vNotificationDeliveryLogList.PrimaryKey.ToString());
                            results.IsCollision = true;
                            break;
                        }
                    }
                    if (results.IsCollision == false)
                    {
                        try
                        {
                            BLL.Notifications.NotificationDeliveryLog item2 = BLL.Notifications.NotificationDeliveryLogManager.GetOneNotificationDeliveryLog(vNotificationDeliveryLogList.NotificationLogID, vNotificationDeliveryLogList.MetaPartnerID, vNotificationDeliveryLogList.NotificationDeliveryTypeCode);
                            if (item2 != null)
                            {
                                results.IsCollision = true;
                                Console.WriteLine("Add collision encountered for NotificationDeliveryLog: " + item2.PrimaryKey.ToString());
                            }
                        }
                        catch (UnitTestException ex)
                        {
                            throw ex;
                        }
                        catch (System.Exception ex)
                        {
                            throw new UnitTestException(UnitTestErrorType.Warning, "Get failed for NotificationDeliveryLog", ex);
                        }
                    }
                    if (results.IsCollision == false)
                    {
                        item.NotificationDeliveryLogList.Add(vNotificationDeliveryLogList);
                    }
                }
            }
            PopulateItemCleanup(item, useCollections, performCascade, isAddOperation, isCollectionOperation, results);
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add NotificationLog items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Notifications.NotificationLog AddOneNotificationLogTest(bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // add item
            //
            BLL.Notifications.NotificationLog item = new BLL.Notifications.NotificationLog();
            MOD.Data.NamedObjectCollection useCollections = new MOD.Data.NamedObjectCollection();
            BLL.SortableList<BLL.Notifications.NotificationLog> itemsNotificationsNotificationLog = new BLL.SortableList<BLL.Notifications.NotificationLog>();
            itemsNotificationsNotificationLog.Add((BLL.Notifications.NotificationLog)item);
            useCollections["Notifications.NotificationLog"] = itemsNotificationsNotificationLog;
            NotificationLog_Manager.PopulateItem(item, useCollections, performCascade, true, false, results);
            results.IsCollision = false; // discard collection collisions
            BLL.Notifications.NotificationLog item2 = null;
            try
            {
                item2 = BLL.Notifications.NotificationLogManager.GetOneNotificationLog(item.NotificationLogID);
            }
            catch (UnitTestException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Get failed for NotificationLog: " + item.PrimaryKey.ToString(), ex);
            }
            if (item2 != null)
            {
                results.IsCollision = true;
                throw new UnitTestException(UnitTestErrorType.Warning, "Add collision encountered for NotificationLog: " + item.PrimaryKey.ToString(), null);
            }
            if (results.IsCollision == false)
            {
                try
                {
                    if (IsValidForAdd(item, performCascade, results) == true)
                    {
                        startTicks = DateTime.Now.Ticks;
                        BLL.Notifications.NotificationLogManager.LogOneNotificationLog(item, performCascade);
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
        /// <summary>This method is used to get NotificationLog items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.Notifications.NotificationLog> GetAllNotificationLogDataTest(MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get all items
            //
            try
            {
                startTicks = DateTime.Now.Ticks;
                BLL.SortableList<BLL.Notifications.NotificationLog> items = BLL.Notifications.NotificationLogManager.GetAllNotificationLogData();
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
        /// <summary>This method is used to get a set of NotificationLog items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.Notifications.NotificationLog> GetManyNotificationLogDataByCriteriaTest(MOD.Data.DataOptions dataOptions, MOD.Test.TestResults results)
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
                NamedObjectCollection nocNotificationCode = new NamedObjectCollection();
                NamedObjectCollection nocLocaleCode = new NamedObjectCollection();
                NamedObjectCollection nocLastModifiedDate = new NamedObjectCollection();
                startTicks = DateTime.Now.Ticks;
                BLL.SortableList<BLL.Notifications.NotificationLog> items =  BLL.Notifications.NotificationLogManager.GetManyNotificationLogDataByCriteria(null, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                BLL.SortableList<BLL.Notifications.NotificationLog> specificItems = null;
                string specificWarnings = String.Empty;
                bool searchValueUsed = false;
                int paramCount = 0;
                if (items.Count < 1)
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "No items found in GetManyNotificationLogDataByCriteria generic search.", null);
                }
                paramCount = 0;
                foreach (BLL.Notifications.NotificationLog item in items)
                {
                    nocNotificationCode[TestHelper.GetStringKeyFromObject((object)(item.NotificationCode), paramCount)] = item.NotificationCode;
                    nocLocaleCode[TestHelper.GetStringKeyFromObject((object)(item.LocaleCode), paramCount)] = item.LocaleCode;
                    nocLastModifiedDate[TestHelper.GetStringKeyFromObject((object)(item.LastModifiedDate), paramCount)] = item.LastModifiedDate;
                    paramCount++;
                }
                paramCount = 0;
                int itemNotificationCode = TestHelper.GetInt(null, null, nocNotificationCode, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Notifications.NotificationLogManager.GetManyNotificationLogDataByCriteria(itemNotificationCode, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyNotificationLogDataByCriteria search with NotificationCode = " + itemNotificationCode.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                int itemLocaleCode = TestHelper.GetInt(null, null, nocLocaleCode, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Notifications.NotificationLogManager.GetManyNotificationLogDataByCriteria(null, itemLocaleCode, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyNotificationLogDataByCriteria search with LocaleCode = " + itemLocaleCode.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                DateTime itemLastModifiedDate = TestHelper.GetDateTime(null, null, nocLastModifiedDate, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Notifications.NotificationLogManager.GetManyNotificationLogDataByCriteria(null, null, itemLastModifiedDate, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyNotificationLogDataByCriteria search with LastModifiedDate = " + itemLastModifiedDate.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                if (specificWarnings != String.Empty)
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "Results were not returned for GetManyNotificationLogDataByCriteria specific searches.", new Exception(specificWarnings));
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