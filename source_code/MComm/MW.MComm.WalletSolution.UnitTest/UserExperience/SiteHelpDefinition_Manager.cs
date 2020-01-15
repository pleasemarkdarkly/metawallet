

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
    /// <summary>This class contains support methods to test SiteHelpDefinition instances.</summary>
    ///
    /// File History:
    /// <created>7/31/2007 (Brian MacDonald)</created>
    ///
    /// <remarks></remarks>
    // ------------------------------------------------------------------------------
    public partial class SiteHelpDefinition_Manager
    {

		#region Properties
        #endregion Properties

        #region Constructors

        // ------------------------------------------------------------------------------
        /// <summary>This method is the constructor (currently does nothing).</summary>
        // ------------------------------------------------------------------------------
        public SiteHelpDefinition_Manager()
        {
            //
            // constructor logic
            //
        }

        #endregion Constructors

		#region Methods

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add SiteHelpDefinition items.</summary>
        // ------------------------------------------------------------------------------
        public static void PopulateItem(BLL.UserExperience.SiteHelpDefinition item, MOD.Data.NamedObjectCollection useCollections, bool performCascade, bool isAddOperation, bool isCollectionOperation, MOD.Test.TestResults results)
        {
            if (item == null)
            {
                return;
            }

            //
            // populate the SiteHelpDefinition item
            //
            if (isAddOperation == true)
            {
                item.SiteHelpDefinitionCode = TestHelper.GetInt(null, null);
            }
            item.SiteHelpDefinitionName = TestHelper.GetString(null, 255);
            item.DefaultText = TestHelper.GetString(null, 2000);
            item.Description = TestHelper.GetString(null, 1000);
            item.IsActive = TestHelper.GetBool();
            PopulateItemCleanup(item, useCollections, performCascade, isAddOperation, isCollectionOperation, results);
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add SiteHelpDefinition items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.UserExperience.SiteHelpDefinition AddOneSiteHelpDefinitionTest(bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // add item
            //
            BLL.UserExperience.SiteHelpDefinition item = new BLL.UserExperience.SiteHelpDefinition();
            MOD.Data.NamedObjectCollection useCollections = new MOD.Data.NamedObjectCollection();
            BLL.SortableList<BLL.UserExperience.SiteHelpDefinition> itemsUserExperienceSiteHelpDefinition = new BLL.SortableList<BLL.UserExperience.SiteHelpDefinition>();
            itemsUserExperienceSiteHelpDefinition.Add((BLL.UserExperience.SiteHelpDefinition)item);
            useCollections["UserExperience.SiteHelpDefinition"] = itemsUserExperienceSiteHelpDefinition;
            SiteHelpDefinition_Manager.PopulateItem(item, useCollections, performCascade, true, false, results);
            results.IsCollision = false;
            try
            {
                BLL.UserExperience.SiteHelpDefinition item2 = BLL.UserExperience.SiteHelpDefinitionManager.GetOneSiteHelpDefinition(item.SiteHelpDefinitionCode);
                if (item2 != null)
                {
                    results.IsCollision = true;
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
            if (results.IsCollision == false)
            {
                try
                {
                    if (IsValidForAdd(item, performCascade, results) == true)
                    {
                        startTicks = DateTime.Now.Ticks;
                        BLL.UserExperience.SiteHelpDefinitionManager.AddOneSiteHelpDefinition(item, performCascade);
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
        /// <summary>This method is used to update SiteHelpDefinition items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.UserExperience.SiteHelpDefinition UpdateOneSiteHelpDefinitionTest(int siteHelpDefinitionCode, bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get and update item
            //
            BLL.UserExperience.SiteHelpDefinition item = new BLL.UserExperience.SiteHelpDefinition();
            try
            {
                item = BLL.UserExperience.SiteHelpDefinitionManager.GetOneSiteHelpDefinition(siteHelpDefinitionCode);
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
            BLL.SortableList<BLL.UserExperience.SiteHelpDefinition> itemsUserExperienceSiteHelpDefinition = new BLL.SortableList<BLL.UserExperience.SiteHelpDefinition>();
            itemsUserExperienceSiteHelpDefinition.Add((BLL.UserExperience.SiteHelpDefinition)item);
            useCollections["UserExperience.SiteHelpDefinition"] = itemsUserExperienceSiteHelpDefinition;
            SiteHelpDefinition_Manager.PopulateItem(item, useCollections, performCascade, false, false, results);
            try
            {
                if (IsValidForUpdate(item, performCascade, results) == true)
                {
                    startTicks = DateTime.Now.Ticks;
                    BLL.UserExperience.SiteHelpDefinitionManager.UpdateOneSiteHelpDefinition(item, performCascade);
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
        /// <summary>This method is used to get SiteHelpDefinition items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.UserExperience.SiteHelpDefinition> GetAllSiteHelpDefinitionDataTest(MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get all items
            //
            try
            {
                startTicks = DateTime.Now.Ticks;
                BLL.SortableList<BLL.UserExperience.SiteHelpDefinition> items = BLL.UserExperience.SiteHelpDefinitionManager.GetAllSiteHelpDefinitionData();
                endTicks = DateTime.Now.Ticks;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                return items;
            }
            catch (UnitTestException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to delete SiteHelpDefinition items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.UserExperience.SiteHelpDefinition DeleteOneSiteHelpDefinitionTest(int siteHelpDefinitionCode, bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get and delete item
            //
            BLL.UserExperience.SiteHelpDefinition item = new BLL.UserExperience.SiteHelpDefinition();
            try
            {
                item = BLL.UserExperience.SiteHelpDefinitionManager.GetOneSiteHelpDefinition(siteHelpDefinitionCode);
            }
            catch (UnitTestException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message + " {primary key: " + item.PrimaryKey + "}", ex);
            }
            try
            {
                if (IsValidForDelete(item, performCascade, results) == true)
                {
                    startTicks = DateTime.Now.Ticks;
                    BLL.UserExperience.SiteHelpDefinitionManager.DeleteOneSiteHelpDefinition(item, performCascade);
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
        #endregion Methods
    }
}