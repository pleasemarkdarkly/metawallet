

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
    /// <summary>This class contains support methods to test NotificationTemplate instances.</summary>
    ///
    /// File History:
    /// <created>7/31/2007 (Brian MacDonald)</created>
    ///
    /// <remarks></remarks>
    // ------------------------------------------------------------------------------
    public partial class NotificationTemplate_Manager
    {

		#region Properties
        #endregion Properties

        #region Constructors

        // ------------------------------------------------------------------------------
        /// <summary>This method is the constructor (currently does nothing).</summary>
        // ------------------------------------------------------------------------------
        public NotificationTemplate_Manager()
        {
            //
            // constructor logic
            //
        }

        #endregion Constructors

		#region Methods

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add NotificationTemplate items.</summary>
        // ------------------------------------------------------------------------------
        public static void PopulateItem(BLL.Notifications.NotificationTemplate item, MOD.Data.NamedObjectCollection useCollections, bool performCascade, bool isAddOperation, bool isCollectionOperation, MOD.Test.TestResults results)
        {
            if (item == null)
            {
                return;
            }

            //
            // populate the NotificationTemplate item
            //
            int totalRecords = 0;
            bool totalRecordsExceeded = false;
            if (isAddOperation == true)
            {
                item.NotificationTemplateID = TestHelper.GetGuid();
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
            item.NotificationSubjectTemplate = TestHelper.GetString(null, 255);
            item.NotificationMessageTemplate = TestHelper.GetString(null, 16);
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
            PopulateItemCleanup(item, useCollections, performCascade, isAddOperation, isCollectionOperation, results);
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add NotificationTemplate items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Notifications.NotificationTemplate AddOneNotificationTemplateTest(bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // add item
            //
            BLL.Notifications.NotificationTemplate item = new BLL.Notifications.NotificationTemplate();
            MOD.Data.NamedObjectCollection useCollections = new MOD.Data.NamedObjectCollection();
            BLL.SortableList<BLL.Notifications.NotificationTemplate> itemsNotificationsNotificationTemplate = new BLL.SortableList<BLL.Notifications.NotificationTemplate>();
            itemsNotificationsNotificationTemplate.Add((BLL.Notifications.NotificationTemplate)item);
            useCollections["Notifications.NotificationTemplate"] = itemsNotificationsNotificationTemplate;
            NotificationTemplate_Manager.PopulateItem(item, useCollections, performCascade, true, false, results);
            results.IsCollision = false; // discard collection collisions
            BLL.Notifications.NotificationTemplate item2 = null;
            try
            {
                item2 = BLL.Notifications.NotificationTemplateManager.GetOneNotificationTemplate(item.NotificationTemplateID);
            }
            catch (UnitTestException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Get failed for NotificationTemplate: " + item.PrimaryKey.ToString(), ex);
            }
            if (item2 != null)
            {
                results.IsCollision = true;
                throw new UnitTestException(UnitTestErrorType.Warning, "Add collision encountered for NotificationTemplate: " + item.PrimaryKey.ToString(), null);
            }
            if (results.IsCollision == false)
            {
                try
                {
                    if (IsValidForAdd(item, performCascade, results) == true)
                    {
                        startTicks = DateTime.Now.Ticks;
                        BLL.Notifications.NotificationTemplateManager.UpsertOneNotificationTemplate(item, performCascade);
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
        /// <summary>This method is used to update NotificationTemplate items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Notifications.NotificationTemplate UpdateOneNotificationTemplateTest(Guid notificationTemplateID, bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get and update item
            //
            BLL.Notifications.NotificationTemplate item = new BLL.Notifications.NotificationTemplate();
            try
            {
                item = BLL.Notifications.NotificationTemplateManager.GetOneNotificationTemplate(notificationTemplateID);
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
            BLL.SortableList<BLL.Notifications.NotificationTemplate> itemsNotificationsNotificationTemplate = new BLL.SortableList<BLL.Notifications.NotificationTemplate>();
            itemsNotificationsNotificationTemplate.Add((BLL.Notifications.NotificationTemplate)item);
            useCollections["Notifications.NotificationTemplate"] = itemsNotificationsNotificationTemplate;
            NotificationTemplate_Manager.PopulateItem(item, useCollections, performCascade, false, false, results);
            try
            {
                if (IsValidForUpdate(item, performCascade, results) == true)
                {
                    startTicks = DateTime.Now.Ticks;
                    BLL.Notifications.NotificationTemplateManager.UpsertOneNotificationTemplate(item, performCascade);
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
        /// <summary>This method is used to get NotificationTemplate items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.Notifications.NotificationTemplate> GetAllNotificationTemplateDataTest(MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get all items
            //
            try
            {
                startTicks = DateTime.Now.Ticks;
                BLL.SortableList<BLL.Notifications.NotificationTemplate> items = BLL.Notifications.NotificationTemplateManager.GetAllNotificationTemplateData();
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
        /// <summary>This method is used to get a set of NotificationTemplate items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.Notifications.NotificationTemplate> GetManyNotificationTemplateDataByCriteriaTest(MOD.Data.DataOptions dataOptions, MOD.Test.TestResults results)
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
                BLL.SortableList<BLL.Notifications.NotificationTemplate> items =  BLL.Notifications.NotificationTemplateManager.GetManyNotificationTemplateDataByCriteria(null, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                BLL.SortableList<BLL.Notifications.NotificationTemplate> specificItems = null;
                string specificWarnings = String.Empty;
                bool searchValueUsed = false;
                int paramCount = 0;
                if (items.Count < 1)
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "No items found in GetManyNotificationTemplateDataByCriteria generic search.", null);
                }
                paramCount = 0;
                foreach (BLL.Notifications.NotificationTemplate item in items)
                {
                    nocNotificationCode[TestHelper.GetStringKeyFromObject((object)(item.NotificationCode), paramCount)] = item.NotificationCode;
                    nocLocaleCode[TestHelper.GetStringKeyFromObject((object)(item.LocaleCode), paramCount)] = item.LocaleCode;
                    nocLastModifiedDate[TestHelper.GetStringKeyFromObject((object)(item.LastModifiedDate), paramCount)] = item.LastModifiedDate;
                    paramCount++;
                }
                paramCount = 0;
                int itemNotificationCode = TestHelper.GetInt(null, null, nocNotificationCode, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Notifications.NotificationTemplateManager.GetManyNotificationTemplateDataByCriteria(itemNotificationCode, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyNotificationTemplateDataByCriteria search with NotificationCode = " + itemNotificationCode.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                int itemLocaleCode = TestHelper.GetInt(null, null, nocLocaleCode, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Notifications.NotificationTemplateManager.GetManyNotificationTemplateDataByCriteria(null, itemLocaleCode, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyNotificationTemplateDataByCriteria search with LocaleCode = " + itemLocaleCode.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                DateTime itemLastModifiedDate = TestHelper.GetDateTime(null, null, nocLastModifiedDate, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Notifications.NotificationTemplateManager.GetManyNotificationTemplateDataByCriteria(null, null, itemLastModifiedDate, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyNotificationTemplateDataByCriteria search with LastModifiedDate = " + itemLastModifiedDate.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                if (specificWarnings != String.Empty)
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "Results were not returned for GetManyNotificationTemplateDataByCriteria specific searches.", new Exception(specificWarnings));
                }
                return items;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to delete NotificationTemplate items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Notifications.NotificationTemplate DeleteOneNotificationTemplateTest(Guid notificationTemplateID, bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get and delete item
            //
            BLL.Notifications.NotificationTemplate item = new BLL.Notifications.NotificationTemplate();
            try
            {
                item = BLL.Notifications.NotificationTemplateManager.GetOneNotificationTemplate(notificationTemplateID);
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
                    BLL.Notifications.NotificationTemplateManager.DeleteOneNotificationTemplate(item, performCascade);
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