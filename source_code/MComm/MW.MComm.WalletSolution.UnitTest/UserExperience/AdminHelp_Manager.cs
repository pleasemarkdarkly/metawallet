

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

namespace MW.MComm.WalletSolution.UnitTest.UserExperience
{
    // ------------------------------------------------------------------------------
    /// <summary>This class contains support methods to test AdminHelp instances.</summary>
    ///
    /// File History:
    /// <created>7/31/2007 (Brian MacDonald)</created>
    ///
    /// <remarks></remarks>
    // ------------------------------------------------------------------------------
    public partial class AdminHelp_Manager
    {

		#region Properties
        #endregion Properties

        #region Constructors

        // ------------------------------------------------------------------------------
        /// <summary>This method is the constructor (currently does nothing).</summary>
        // ------------------------------------------------------------------------------
        public AdminHelp_Manager()
        {
            //
            // constructor logic
            //
        }

        #endregion Constructors

		#region Methods

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add AdminHelp items.</summary>
        // ------------------------------------------------------------------------------
        public static void PopulateItem(BLL.UserExperience.AdminHelp item, MOD.Data.NamedObjectCollection useCollections, bool performCascade, bool isAddOperation, bool isCollectionOperation, MOD.Test.TestResults results)
        {
            if (item == null)
            {
                return;
            }

            //
            // populate the AdminHelp item
            //
            if (isAddOperation == true)
            {
                BLL.SortableList<BLL.Users.Activity> itemActivityActivityCode = null;
                if (useCollections != null && useCollections["Users.Activity"] != null)
                {
                    itemActivityActivityCode = (BLL.SortableList<BLL.Users.Activity>)useCollections["Users.Activity"];
                }
                if (itemActivityActivityCode == null || itemActivityActivityCode.Count <= 0)
                {
                    itemActivityActivityCode = BLL.Users.ActivityManager.GetAllActivityData();
                }
                if (itemActivityActivityCode.Count > 0)
                {
                    int index = TestHelper.GetInt(0, Math.Max(0, itemActivityActivityCode.Count-1));
                    item.ActivityCode = itemActivityActivityCode[index].ActivityCode;
                }
                else
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "Could not find values for Activity.", null);
                }
            }
            if (isAddOperation == true)
            {
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
            }
            item.AdminHelpTitle = TestHelper.GetString(null, 255);
            item.AdminHelpText = TestHelper.GetString(null, 2000);
            PopulateItemCleanup(item, useCollections, performCascade, isAddOperation, isCollectionOperation, results);
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add AdminHelp items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.UserExperience.AdminHelp AddOneAdminHelpTest(bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // add item
            //
            BLL.UserExperience.AdminHelp item = new BLL.UserExperience.AdminHelp();
            MOD.Data.NamedObjectCollection useCollections = new MOD.Data.NamedObjectCollection();
            BLL.SortableList<BLL.UserExperience.AdminHelp> itemsUserExperienceAdminHelp = new BLL.SortableList<BLL.UserExperience.AdminHelp>();
            itemsUserExperienceAdminHelp.Add((BLL.UserExperience.AdminHelp)item);
            useCollections["UserExperience.AdminHelp"] = itemsUserExperienceAdminHelp;
            AdminHelp_Manager.PopulateItem(item, useCollections, performCascade, true, false, results);
            results.IsCollision = false; // discard collection collisions
            BLL.UserExperience.AdminHelp item2 = null;
            try
            {
                item2 = BLL.UserExperience.AdminHelpManager.GetOneAdminHelp(item.ActivityCode, item.LocaleCode);
            }
            catch (UnitTestException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Get failed for AdminHelp: " + item.PrimaryKey.ToString(), ex);
            }
            if (item2 != null)
            {
                results.IsCollision = true;
                throw new UnitTestException(UnitTestErrorType.Warning, "Add collision encountered for AdminHelp: " + item.PrimaryKey.ToString(), null);
            }
            if (results.IsCollision == false)
            {
                try
                {
                    if (IsValidForAdd(item, performCascade, results) == true)
                    {
                        startTicks = DateTime.Now.Ticks;
                        BLL.UserExperience.AdminHelpManager.AddOneAdminHelp(item, performCascade);
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
        /// <summary>This method is used to update AdminHelp items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.UserExperience.AdminHelp UpdateOneAdminHelpTest(int activityCode, int localeCode, bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get and update item
            //
            BLL.UserExperience.AdminHelp item = new BLL.UserExperience.AdminHelp();
            try
            {
                item = BLL.UserExperience.AdminHelpManager.GetOneAdminHelp(activityCode, localeCode);
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
            BLL.SortableList<BLL.UserExperience.AdminHelp> itemsUserExperienceAdminHelp = new BLL.SortableList<BLL.UserExperience.AdminHelp>();
            itemsUserExperienceAdminHelp.Add((BLL.UserExperience.AdminHelp)item);
            useCollections["UserExperience.AdminHelp"] = itemsUserExperienceAdminHelp;
            AdminHelp_Manager.PopulateItem(item, useCollections, performCascade, false, false, results);
            try
            {
                if (IsValidForUpdate(item, performCascade, results) == true)
                {
                    startTicks = DateTime.Now.Ticks;
                    BLL.UserExperience.AdminHelpManager.UpdateOneAdminHelp(item, performCascade);
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
        /// <summary>This method is used to get AdminHelp items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.UserExperience.AdminHelp> GetAllAdminHelpDataTest(MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get all items
            //
            try
            {
                startTicks = DateTime.Now.Ticks;
                BLL.SortableList<BLL.UserExperience.AdminHelp> items = BLL.UserExperience.AdminHelpManager.GetAllAdminHelpData();
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
        /// <summary>This method is used to get a set of AdminHelp items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.UserExperience.AdminHelp> GetManyAdminHelpDataByCriteriaTest(MOD.Data.DataOptions dataOptions, MOD.Test.TestResults results)
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
                NamedObjectCollection nocAdminHelpTitle = new NamedObjectCollection();
                NamedObjectCollection nocLastModifiedDate = new NamedObjectCollection();
                startTicks = DateTime.Now.Ticks;
                BLL.SortableList<BLL.UserExperience.AdminHelp> items =  BLL.UserExperience.AdminHelpManager.GetManyAdminHelpDataByCriteria(null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                BLL.SortableList<BLL.UserExperience.AdminHelp> specificItems = null;
                string specificWarnings = String.Empty;
                bool searchValueUsed = false;
                int paramCount = 0;
                if (items.Count < 1)
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "No items found in GetManyAdminHelpDataByCriteria generic search.", null);
                }
                paramCount = 0;
                foreach (BLL.UserExperience.AdminHelp item in items)
                {
                    nocAdminHelpTitle[TestHelper.GetStringKeyFromObject((object)(item.AdminHelpTitle), paramCount)] = item.AdminHelpTitle;
                    nocLastModifiedDate[TestHelper.GetStringKeyFromObject((object)(item.LastModifiedDate), paramCount)] = item.LastModifiedDate;
                    paramCount++;
                }
                paramCount = 0;
                string itemAdminHelpTitle = TestHelper.GetString(null, 255, nocAdminHelpTitle, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.UserExperience.AdminHelpManager.GetManyAdminHelpDataByCriteria(itemAdminHelpTitle, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyAdminHelpDataByCriteria search with AdminHelpTitle = " + itemAdminHelpTitle.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                DateTime itemLastModifiedDate = TestHelper.GetDateTime(null, null, nocLastModifiedDate, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.UserExperience.AdminHelpManager.GetManyAdminHelpDataByCriteria(null, itemLastModifiedDate, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyAdminHelpDataByCriteria search with LastModifiedDate = " + itemLastModifiedDate.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                if (specificWarnings != String.Empty)
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "Results were not returned for GetManyAdminHelpDataByCriteria specific searches.", new Exception(specificWarnings));
                }
                return items;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to delete AdminHelp items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.UserExperience.AdminHelp DeleteOneAdminHelpTest(int activityCode, int localeCode, bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get and delete item
            //
            BLL.UserExperience.AdminHelp item = new BLL.UserExperience.AdminHelp();
            try
            {
                item = BLL.UserExperience.AdminHelpManager.GetOneAdminHelp(activityCode, localeCode);
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
                    BLL.UserExperience.AdminHelpManager.DeleteOneAdminHelp(item, performCascade);
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