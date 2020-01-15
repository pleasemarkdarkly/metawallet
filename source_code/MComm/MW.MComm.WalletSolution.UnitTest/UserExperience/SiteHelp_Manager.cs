

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
    /// <summary>This class contains support methods to test SiteHelp instances.</summary>
    ///
    /// File History:
    /// <created>7/31/2007 (Brian MacDonald)</created>
    ///
    /// <remarks></remarks>
    // ------------------------------------------------------------------------------
    public partial class SiteHelp_Manager
    {

		#region Properties
        #endregion Properties

        #region Constructors

        // ------------------------------------------------------------------------------
        /// <summary>This method is the constructor (currently does nothing).</summary>
        // ------------------------------------------------------------------------------
        public SiteHelp_Manager()
        {
            //
            // constructor logic
            //
        }

        #endregion Constructors

		#region Methods

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add SiteHelp items.</summary>
        // ------------------------------------------------------------------------------
        public static void PopulateItem(BLL.UserExperience.SiteHelp item, MOD.Data.NamedObjectCollection useCollections, bool performCascade, bool isAddOperation, bool isCollectionOperation, MOD.Test.TestResults results)
        {
            if (item == null)
            {
                return;
            }

            //
            // populate the SiteHelp item
            //
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
            item.SiteHelpName = TestHelper.GetString(null, 255);
            item.SiteHelpText = TestHelper.GetString(null, 2000);
            item.SiteHelpImageURL = TestHelper.GetURL(null, 255);
            BLL.SortableList<BLL.UserExperience.SiteHelpGroup> itemSiteHelpGroupSiteHelpGroupCode = null;
            if (useCollections != null && useCollections["UserExperience.SiteHelpGroup"] != null)
            {
                itemSiteHelpGroupSiteHelpGroupCode = (BLL.SortableList<BLL.UserExperience.SiteHelpGroup>)useCollections["UserExperience.SiteHelpGroup"];
            }
            if (itemSiteHelpGroupSiteHelpGroupCode == null || itemSiteHelpGroupSiteHelpGroupCode.Count <= 0)
            {
                itemSiteHelpGroupSiteHelpGroupCode = BLL.UserExperience.SiteHelpGroupManager.GetAllSiteHelpGroupData();
            }
            if (itemSiteHelpGroupSiteHelpGroupCode.Count > 0)
            {
                int index = TestHelper.GetInt(0, Math.Max(0, itemSiteHelpGroupSiteHelpGroupCode.Count-1));
                item.SiteHelpGroupCode = itemSiteHelpGroupSiteHelpGroupCode[index].SiteHelpGroupCode;
            }
            else
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Could not find values for SiteHelpGroup.", null);
            }
            if (isAddOperation == true)
            {
                BLL.SortableList<BLL.UserExperience.SiteHelpDefinition> itemSiteHelpDefinitionSiteHelpDefinitionCode = null;
                if (useCollections != null && useCollections["UserExperience.SiteHelpDefinition"] != null)
                {
                    itemSiteHelpDefinitionSiteHelpDefinitionCode = (BLL.SortableList<BLL.UserExperience.SiteHelpDefinition>)useCollections["UserExperience.SiteHelpDefinition"];
                }
                if (itemSiteHelpDefinitionSiteHelpDefinitionCode == null || itemSiteHelpDefinitionSiteHelpDefinitionCode.Count <= 0)
                {
                    itemSiteHelpDefinitionSiteHelpDefinitionCode = BLL.UserExperience.SiteHelpDefinitionManager.GetAllSiteHelpDefinitionData();
                }
                if (itemSiteHelpDefinitionSiteHelpDefinitionCode.Count > 0)
                {
                    int index = TestHelper.GetInt(0, Math.Max(0, itemSiteHelpDefinitionSiteHelpDefinitionCode.Count-1));
                    item.SiteHelpDefinitionCode = itemSiteHelpDefinitionSiteHelpDefinitionCode[index].SiteHelpDefinitionCode;
                }
                else
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "Could not find values for SiteHelpDefinition.", null);
                }
            }
            PopulateItemCleanup(item, useCollections, performCascade, isAddOperation, isCollectionOperation, results);
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add SiteHelp items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.UserExperience.SiteHelp AddOneSiteHelpTest(bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // add item
            //
            BLL.UserExperience.SiteHelp item = new BLL.UserExperience.SiteHelp();
            MOD.Data.NamedObjectCollection useCollections = new MOD.Data.NamedObjectCollection();
            BLL.SortableList<BLL.UserExperience.SiteHelp> itemsUserExperienceSiteHelp = new BLL.SortableList<BLL.UserExperience.SiteHelp>();
            itemsUserExperienceSiteHelp.Add((BLL.UserExperience.SiteHelp)item);
            useCollections["UserExperience.SiteHelp"] = itemsUserExperienceSiteHelp;
            SiteHelp_Manager.PopulateItem(item, useCollections, performCascade, true, false, results);
            results.IsCollision = false; // discard collection collisions
            BLL.UserExperience.SiteHelp item2 = null;
            try
            {
                item2 = BLL.UserExperience.SiteHelpManager.GetOneSiteHelp(item.SiteHelpDefinitionCode, item.LocaleCode);
            }
            catch (UnitTestException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Get failed for SiteHelp: " + item.PrimaryKey.ToString(), ex);
            }
            if (item2 != null)
            {
                results.IsCollision = true;
                throw new UnitTestException(UnitTestErrorType.Warning, "Add collision encountered for SiteHelp: " + item.PrimaryKey.ToString(), null);
            }
            if (results.IsCollision == false)
            {
                try
                {
                    if (IsValidForAdd(item, performCascade, results) == true)
                    {
                        startTicks = DateTime.Now.Ticks;
                        BLL.UserExperience.SiteHelpManager.AddOneSiteHelp(item, performCascade);
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
        /// <summary>This method is used to update SiteHelp items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.UserExperience.SiteHelp UpdateOneSiteHelpTest(int siteHelpDefinitionCode, int localeCode, bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get and update item
            //
            BLL.UserExperience.SiteHelp item = new BLL.UserExperience.SiteHelp();
            try
            {
                item = BLL.UserExperience.SiteHelpManager.GetOneSiteHelp(siteHelpDefinitionCode, localeCode);
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
            BLL.SortableList<BLL.UserExperience.SiteHelp> itemsUserExperienceSiteHelp = new BLL.SortableList<BLL.UserExperience.SiteHelp>();
            itemsUserExperienceSiteHelp.Add((BLL.UserExperience.SiteHelp)item);
            useCollections["UserExperience.SiteHelp"] = itemsUserExperienceSiteHelp;
            SiteHelp_Manager.PopulateItem(item, useCollections, performCascade, false, false, results);
            try
            {
                if (IsValidForUpdate(item, performCascade, results) == true)
                {
                    startTicks = DateTime.Now.Ticks;
                    BLL.UserExperience.SiteHelpManager.UpdateOneSiteHelp(item, performCascade);
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
        /// <summary>This method is used to get SiteHelp items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.UserExperience.SiteHelp> GetAllSiteHelpDataTest(MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get all items
            //
            try
            {
                startTicks = DateTime.Now.Ticks;
                BLL.SortableList<BLL.UserExperience.SiteHelp> items = BLL.UserExperience.SiteHelpManager.GetAllSiteHelpData();
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
        /// <summary>This method is used to get a set of SiteHelp items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.UserExperience.SiteHelp> GetManySiteHelpDataByCriteriaTest(MOD.Data.DataOptions dataOptions, MOD.Test.TestResults results)
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
                NamedObjectCollection nocSiteHelpName = new NamedObjectCollection();
                NamedObjectCollection nocSiteHelpGroupCode = new NamedObjectCollection();
                NamedObjectCollection nocLastModifiedDate = new NamedObjectCollection();
                startTicks = DateTime.Now.Ticks;
                BLL.SortableList<BLL.UserExperience.SiteHelp> items =  BLL.UserExperience.SiteHelpManager.GetManySiteHelpDataByCriteria(null, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                BLL.SortableList<BLL.UserExperience.SiteHelp> specificItems = null;
                string specificWarnings = String.Empty;
                bool searchValueUsed = false;
                int paramCount = 0;
                if (items.Count < 1)
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "No items found in GetManySiteHelpDataByCriteria generic search.", null);
                }
                paramCount = 0;
                foreach (BLL.UserExperience.SiteHelp item in items)
                {
                    nocSiteHelpName[TestHelper.GetStringKeyFromObject((object)(item.SiteHelpName), paramCount)] = item.SiteHelpName;
                    nocSiteHelpGroupCode[TestHelper.GetStringKeyFromObject((object)(item.SiteHelpGroupCode), paramCount)] = item.SiteHelpGroupCode;
                    nocLastModifiedDate[TestHelper.GetStringKeyFromObject((object)(item.LastModifiedDate), paramCount)] = item.LastModifiedDate;
                    paramCount++;
                }
                paramCount = 0;
                string itemSiteHelpName = TestHelper.GetString(null, 255, nocSiteHelpName, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.UserExperience.SiteHelpManager.GetManySiteHelpDataByCriteria(itemSiteHelpName, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManySiteHelpDataByCriteria search with SiteHelpName = " + itemSiteHelpName.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                int itemSiteHelpGroupCode = TestHelper.GetInt(null, null, nocSiteHelpGroupCode, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.UserExperience.SiteHelpManager.GetManySiteHelpDataByCriteria(null, itemSiteHelpGroupCode, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManySiteHelpDataByCriteria search with SiteHelpGroupCode = " + itemSiteHelpGroupCode.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                DateTime itemLastModifiedDate = TestHelper.GetDateTime(null, null, nocLastModifiedDate, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.UserExperience.SiteHelpManager.GetManySiteHelpDataByCriteria(null, null, itemLastModifiedDate, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManySiteHelpDataByCriteria search with LastModifiedDate = " + itemLastModifiedDate.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                if (specificWarnings != String.Empty)
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "Results were not returned for GetManySiteHelpDataByCriteria specific searches.", new Exception(specificWarnings));
                }
                return items;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to delete SiteHelp items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.UserExperience.SiteHelp DeleteOneSiteHelpTest(int siteHelpDefinitionCode, int localeCode, bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get and delete item
            //
            BLL.UserExperience.SiteHelp item = new BLL.UserExperience.SiteHelp();
            try
            {
                item = BLL.UserExperience.SiteHelpManager.GetOneSiteHelp(siteHelpDefinitionCode, localeCode);
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
                    BLL.UserExperience.SiteHelpManager.DeleteOneSiteHelp(item, performCascade);
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