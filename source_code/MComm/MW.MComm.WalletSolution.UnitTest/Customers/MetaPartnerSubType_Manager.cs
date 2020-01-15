

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

namespace MW.MComm.WalletSolution.UnitTest.Customers
{
    // ------------------------------------------------------------------------------
    /// <summary>This class contains support methods to test MetaPartnerSubType instances.</summary>
    ///
    /// File History:
    /// <created>7/31/2007 (Brian MacDonald)</created>
    ///
    /// <remarks></remarks>
    // ------------------------------------------------------------------------------
    public partial class MetaPartnerSubType_Manager
    {

		#region Properties
        #endregion Properties

        #region Constructors

        // ------------------------------------------------------------------------------
        /// <summary>This method is the constructor (currently does nothing).</summary>
        // ------------------------------------------------------------------------------
        public MetaPartnerSubType_Manager()
        {
            //
            // constructor logic
            //
        }

        #endregion Constructors

		#region Methods

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add MetaPartnerSubType items.</summary>
        // ------------------------------------------------------------------------------
        public static void PopulateItem(BLL.Customers.MetaPartnerSubType item, MOD.Data.NamedObjectCollection useCollections, bool performCascade, bool isAddOperation, bool isCollectionOperation, MOD.Test.TestResults results)
        {
            if (item == null)
            {
                return;
            }

            //
            // populate the MetaPartnerSubType item
            //
            if (isAddOperation == true)
            {
                item.MetaPartnerSubTypeCode = TestHelper.GetInt(null, null);
            }
            item.MetaPartnerSubTypeName = TestHelper.GetString(null, 255);
            item.Description = TestHelper.GetString(null, 2000);
            item.IsActive = TestHelper.GetBool();
            PopulateItemCleanup(item, useCollections, performCascade, isAddOperation, isCollectionOperation, results);
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add MetaPartnerSubType items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Customers.MetaPartnerSubType AddOneMetaPartnerSubTypeTest(bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // add item
            //
            BLL.Customers.MetaPartnerSubType item = new BLL.Customers.MetaPartnerSubType();
            MOD.Data.NamedObjectCollection useCollections = new MOD.Data.NamedObjectCollection();
            BLL.SortableList<BLL.Customers.MetaPartnerSubType> itemsCustomersMetaPartnerSubType = new BLL.SortableList<BLL.Customers.MetaPartnerSubType>();
            itemsCustomersMetaPartnerSubType.Add((BLL.Customers.MetaPartnerSubType)item);
            useCollections["Customers.MetaPartnerSubType"] = itemsCustomersMetaPartnerSubType;
            MetaPartnerSubType_Manager.PopulateItem(item, useCollections, performCascade, true, false, results);
            results.IsCollision = false;
            try
            {
                BLL.Customers.MetaPartnerSubType item2 = BLL.Customers.MetaPartnerSubTypeManager.GetOneMetaPartnerSubType(item.MetaPartnerSubTypeCode);
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
                        BLL.Customers.MetaPartnerSubTypeManager.AddOneMetaPartnerSubType(item, performCascade);
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
        /// <summary>This method is used to update MetaPartnerSubType items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Customers.MetaPartnerSubType UpdateOneMetaPartnerSubTypeTest(int metaPartnerSubTypeCode, bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get and update item
            //
            BLL.Customers.MetaPartnerSubType item = new BLL.Customers.MetaPartnerSubType();
            try
            {
                item = BLL.Customers.MetaPartnerSubTypeManager.GetOneMetaPartnerSubType(metaPartnerSubTypeCode);
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
            BLL.SortableList<BLL.Customers.MetaPartnerSubType> itemsCustomersMetaPartnerSubType = new BLL.SortableList<BLL.Customers.MetaPartnerSubType>();
            itemsCustomersMetaPartnerSubType.Add((BLL.Customers.MetaPartnerSubType)item);
            useCollections["Customers.MetaPartnerSubType"] = itemsCustomersMetaPartnerSubType;
            MetaPartnerSubType_Manager.PopulateItem(item, useCollections, performCascade, false, false, results);
            try
            {
                if (IsValidForUpdate(item, performCascade, results) == true)
                {
                    startTicks = DateTime.Now.Ticks;
                    BLL.Customers.MetaPartnerSubTypeManager.UpdateOneMetaPartnerSubType(item, performCascade);
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
        /// <summary>This method is used to get MetaPartnerSubType items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.Customers.MetaPartnerSubType> GetAllMetaPartnerSubTypeDataTest(MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get all items
            //
            try
            {
                startTicks = DateTime.Now.Ticks;
                BLL.SortableList<BLL.Customers.MetaPartnerSubType> items = BLL.Customers.MetaPartnerSubTypeManager.GetAllMetaPartnerSubTypeData();
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
        /// <summary>This method is used to delete MetaPartnerSubType items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Customers.MetaPartnerSubType DeleteOneMetaPartnerSubTypeTest(int metaPartnerSubTypeCode, bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get and delete item
            //
            BLL.Customers.MetaPartnerSubType item = new BLL.Customers.MetaPartnerSubType();
            try
            {
                item = BLL.Customers.MetaPartnerSubTypeManager.GetOneMetaPartnerSubType(metaPartnerSubTypeCode);
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
                    BLL.Customers.MetaPartnerSubTypeManager.DeleteOneMetaPartnerSubType(item, performCascade);
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