

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
    /// <summary>This class contains support methods to test SiteLabel instances.</summary>
    ///
    /// File History:
    /// <created>7/31/2007 (Brian MacDonald)</created>
    ///
    /// <remarks></remarks>
    // ------------------------------------------------------------------------------
    public partial class SiteLabel_Manager
    {

		#region Properties
        #endregion Properties

        #region Constructors

        // ------------------------------------------------------------------------------
        /// <summary>This method is the constructor (currently does nothing).</summary>
        // ------------------------------------------------------------------------------
        public SiteLabel_Manager()
        {
            //
            // constructor logic
            //
        }

        #endregion Constructors

		#region Methods

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add SiteLabel items.</summary>
        // ------------------------------------------------------------------------------
        public static void PopulateItem(BLL.UserExperience.SiteLabel item, MOD.Data.NamedObjectCollection useCollections, bool performCascade, bool isAddOperation, bool isCollectionOperation, MOD.Test.TestResults results)
        {
            if (item == null)
            {
                return;
            }

            //
            // populate the SiteLabel item
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
            item.Title = TestHelper.GetString(null, 255);
            item.DisplayText = TestHelper.GetString(null, 2000);
            item.TargetLocation = TestHelper.GetString(null, 255);
            item.FileURL = TestHelper.GetURL(null, 255);
            item.Description = TestHelper.GetString(null, 1000);
            if (isAddOperation == true)
            {
                BLL.SortableList<BLL.UserExperience.SiteLabelDefinition> itemSiteLabelDefinitionSiteLabelDefinitionCode = null;
                if (useCollections != null && useCollections["UserExperience.SiteLabelDefinition"] != null)
                {
                    itemSiteLabelDefinitionSiteLabelDefinitionCode = (BLL.SortableList<BLL.UserExperience.SiteLabelDefinition>)useCollections["UserExperience.SiteLabelDefinition"];
                }
                if (itemSiteLabelDefinitionSiteLabelDefinitionCode == null || itemSiteLabelDefinitionSiteLabelDefinitionCode.Count <= 0)
                {
                    itemSiteLabelDefinitionSiteLabelDefinitionCode = BLL.UserExperience.SiteLabelDefinitionManager.GetAllSiteLabelDefinitionData();
                }
                if (itemSiteLabelDefinitionSiteLabelDefinitionCode.Count > 0)
                {
                    int index = TestHelper.GetInt(0, Math.Max(0, itemSiteLabelDefinitionSiteLabelDefinitionCode.Count-1));
                    item.SiteLabelDefinitionCode = itemSiteLabelDefinitionSiteLabelDefinitionCode[index].SiteLabelDefinitionCode;
                }
                else
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "Could not find values for SiteLabelDefinition.", null);
                }
            }
            PopulateItemCleanup(item, useCollections, performCascade, isAddOperation, isCollectionOperation, results);
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add SiteLabel items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.UserExperience.SiteLabel AddOneSiteLabelTest(bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // add item
            //
            BLL.UserExperience.SiteLabel item = new BLL.UserExperience.SiteLabel();
            MOD.Data.NamedObjectCollection useCollections = new MOD.Data.NamedObjectCollection();
            BLL.SortableList<BLL.UserExperience.SiteLabel> itemsUserExperienceSiteLabel = new BLL.SortableList<BLL.UserExperience.SiteLabel>();
            itemsUserExperienceSiteLabel.Add((BLL.UserExperience.SiteLabel)item);
            useCollections["UserExperience.SiteLabel"] = itemsUserExperienceSiteLabel;
            SiteLabel_Manager.PopulateItem(item, useCollections, performCascade, true, false, results);
            results.IsCollision = false; // discard collection collisions
            BLL.UserExperience.SiteLabel item2 = null;
            try
            {
                item2 = BLL.UserExperience.SiteLabelManager.GetOneSiteLabel(item.SiteLabelDefinitionCode, item.LocaleCode);
            }
            catch (UnitTestException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Get failed for SiteLabel: " + item.PrimaryKey.ToString(), ex);
            }
            if (item2 != null)
            {
                results.IsCollision = true;
                throw new UnitTestException(UnitTestErrorType.Warning, "Add collision encountered for SiteLabel: " + item.PrimaryKey.ToString(), null);
            }
            if (results.IsCollision == false)
            {
                try
                {
                    if (IsValidForAdd(item, performCascade, results) == true)
                    {
                        startTicks = DateTime.Now.Ticks;
                        BLL.UserExperience.SiteLabelManager.AddOneSiteLabel(item, performCascade);
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
        /// <summary>This method is used to update SiteLabel items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.UserExperience.SiteLabel UpdateOneSiteLabelTest(int siteLabelDefinitionCode, int localeCode, bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get and update item
            //
            BLL.UserExperience.SiteLabel item = new BLL.UserExperience.SiteLabel();
            try
            {
                item = BLL.UserExperience.SiteLabelManager.GetOneSiteLabel(siteLabelDefinitionCode, localeCode);
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
            BLL.SortableList<BLL.UserExperience.SiteLabel> itemsUserExperienceSiteLabel = new BLL.SortableList<BLL.UserExperience.SiteLabel>();
            itemsUserExperienceSiteLabel.Add((BLL.UserExperience.SiteLabel)item);
            useCollections["UserExperience.SiteLabel"] = itemsUserExperienceSiteLabel;
            SiteLabel_Manager.PopulateItem(item, useCollections, performCascade, false, false, results);
            try
            {
                if (IsValidForUpdate(item, performCascade, results) == true)
                {
                    startTicks = DateTime.Now.Ticks;
                    BLL.UserExperience.SiteLabelManager.UpdateOneSiteLabel(item, performCascade);
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
        /// <summary>This method is used to get SiteLabel items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.UserExperience.SiteLabel> GetAllSiteLabelDataTest(MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get all items
            //
            try
            {
                startTicks = DateTime.Now.Ticks;
                BLL.SortableList<BLL.UserExperience.SiteLabel> items = BLL.UserExperience.SiteLabelManager.GetAllSiteLabelData();
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
        /// <summary>This method is used to get a set of SiteLabel items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.UserExperience.SiteLabel> GetManySiteLabelDataByCriteriaTest(MOD.Data.DataOptions dataOptions, MOD.Test.TestResults results)
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
                NamedObjectCollection nocTitle = new NamedObjectCollection();
                NamedObjectCollection nocLastModifiedDate = new NamedObjectCollection();
                startTicks = DateTime.Now.Ticks;
                BLL.SortableList<BLL.UserExperience.SiteLabel> items =  BLL.UserExperience.SiteLabelManager.GetManySiteLabelDataByCriteria(null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                BLL.SortableList<BLL.UserExperience.SiteLabel> specificItems = null;
                string specificWarnings = String.Empty;
                bool searchValueUsed = false;
                int paramCount = 0;
                if (items.Count < 1)
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "No items found in GetManySiteLabelDataByCriteria generic search.", null);
                }
                paramCount = 0;
                foreach (BLL.UserExperience.SiteLabel item in items)
                {
                    nocTitle[TestHelper.GetStringKeyFromObject((object)(item.Title), paramCount)] = item.Title;
                    nocLastModifiedDate[TestHelper.GetStringKeyFromObject((object)(item.LastModifiedDate), paramCount)] = item.LastModifiedDate;
                    paramCount++;
                }
                paramCount = 0;
                string itemTitle = TestHelper.GetString(null, 255, nocTitle, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.UserExperience.SiteLabelManager.GetManySiteLabelDataByCriteria(itemTitle, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManySiteLabelDataByCriteria search with Title = " + itemTitle.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                DateTime itemLastModifiedDate = TestHelper.GetDateTime(null, null, nocLastModifiedDate, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.UserExperience.SiteLabelManager.GetManySiteLabelDataByCriteria(null, itemLastModifiedDate, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManySiteLabelDataByCriteria search with LastModifiedDate = " + itemLastModifiedDate.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                if (specificWarnings != String.Empty)
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "Results were not returned for GetManySiteLabelDataByCriteria specific searches.", new Exception(specificWarnings));
                }
                return items;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to delete SiteLabel items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.UserExperience.SiteLabel DeleteOneSiteLabelTest(int siteLabelDefinitionCode, int localeCode, bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get and delete item
            //
            BLL.UserExperience.SiteLabel item = new BLL.UserExperience.SiteLabel();
            try
            {
                item = BLL.UserExperience.SiteLabelManager.GetOneSiteLabel(siteLabelDefinitionCode, localeCode);
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
                    BLL.UserExperience.SiteLabelManager.DeleteOneSiteLabel(item, performCascade);
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