

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
    /// <summary>This class contains support methods to test MetaPartnerEmail instances.</summary>
    ///
    /// File History:
    /// <created>7/31/2007 (Brian MacDonald)</created>
    ///
    /// <remarks></remarks>
    // ------------------------------------------------------------------------------
    public partial class MetaPartnerEmail_Manager
    {

		#region Properties
        #endregion Properties

        #region Constructors

        // ------------------------------------------------------------------------------
        /// <summary>This method is the constructor (currently does nothing).</summary>
        // ------------------------------------------------------------------------------
        public MetaPartnerEmail_Manager()
        {
            //
            // constructor logic
            //
        }

        #endregion Constructors

		#region Methods

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add MetaPartnerEmail items.</summary>
        // ------------------------------------------------------------------------------
        public static void PopulateItem(BLL.Customers.MetaPartnerEmail item, MOD.Data.NamedObjectCollection useCollections, bool performCascade, bool isAddOperation, bool isCollectionOperation, MOD.Test.TestResults results)
        {
            if (item == null)
            {
                return;
            }

            //
            // populate the MetaPartnerEmail item
            //
            int totalRecords = 0;
            bool totalRecordsExceeded = false;
            if (isAddOperation == true)
            {
                item.MetaPartnerEmailID = TestHelper.GetGuid();
            }
            item.EmailAddress = TestHelper.GetString(null, 255);
            item.Password = TestHelper.GetString(null, 50);
            totalRecords = 0;
            totalRecordsExceeded = false;
            BLL.SortableList<BLL.Customers.MetaPartner> itemMetaPartnerMetaPartnerID = null;
            if (useCollections != null && useCollections["Customers.MetaPartner"] != null)
            {
                itemMetaPartnerMetaPartnerID = (BLL.SortableList<BLL.Customers.MetaPartner>)useCollections["Customers.MetaPartner"];
            }
            if (itemMetaPartnerMetaPartnerID == null || itemMetaPartnerMetaPartnerID.Count <= 0)
            {
                itemMetaPartnerMetaPartnerID = BLL.Customers.MetaPartnerManager.GetManyMetaPartnerDataByCriteria(null, null, null, null, null, null, null, out totalRecords, out totalRecordsExceeded, Globals.getDataOptions("","",1,200,2000));
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
            }
            if (itemMetaPartnerMetaPartnerID.Count > 0)
            {
                int index = TestHelper.GetInt(0, Math.Max(0, itemMetaPartnerMetaPartnerID.Count-1));
                item.MetaPartnerID = itemMetaPartnerMetaPartnerID[index].MetaPartnerID;
            }
            else
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Could not find values for MetaPartner.", null);
            }
            item.Rank = TestHelper.GetInt(null, null);
            item.IsActive = TestHelper.GetBool();
            PopulateItemCleanup(item, useCollections, performCascade, isAddOperation, isCollectionOperation, results);
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add MetaPartnerEmail items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Customers.MetaPartnerEmail AddOneMetaPartnerEmailTest(bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // add item
            //
            BLL.Customers.MetaPartnerEmail item = new BLL.Customers.MetaPartnerEmail();
            MOD.Data.NamedObjectCollection useCollections = new MOD.Data.NamedObjectCollection();
            BLL.SortableList<BLL.Customers.MetaPartnerEmail> itemsCustomersMetaPartnerEmail = new BLL.SortableList<BLL.Customers.MetaPartnerEmail>();
            itemsCustomersMetaPartnerEmail.Add((BLL.Customers.MetaPartnerEmail)item);
            useCollections["Customers.MetaPartnerEmail"] = itemsCustomersMetaPartnerEmail;
            MetaPartnerEmail_Manager.PopulateItem(item, useCollections, performCascade, true, false, results);
            results.IsCollision = false; // discard collection collisions
            BLL.Customers.MetaPartnerEmail item2 = null;
            try
            {
                item2 = BLL.Customers.MetaPartnerEmailManager.GetOneMetaPartnerEmail(item.MetaPartnerEmailID);
            }
            catch (UnitTestException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Get failed for MetaPartnerEmail: " + item.PrimaryKey.ToString(), ex);
            }
            if (item2 != null)
            {
                results.IsCollision = true;
                throw new UnitTestException(UnitTestErrorType.Warning, "Add collision encountered for MetaPartnerEmail: " + item.PrimaryKey.ToString(), null);
            }
            if (results.IsCollision == false)
            {
                try
                {
                    if (IsValidForAdd(item, performCascade, results) == true)
                    {
                        startTicks = DateTime.Now.Ticks;
                        BLL.Customers.MetaPartnerEmailManager.UpsertOneMetaPartnerEmail(item, performCascade);
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
        /// <summary>This method is used to update MetaPartnerEmail items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Customers.MetaPartnerEmail UpdateOneMetaPartnerEmailTest(Guid metaPartnerEmailID, bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get and update item
            //
            BLL.Customers.MetaPartnerEmail item = new BLL.Customers.MetaPartnerEmail();
            try
            {
                item = BLL.Customers.MetaPartnerEmailManager.GetOneMetaPartnerEmail(metaPartnerEmailID);
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
            BLL.SortableList<BLL.Customers.MetaPartnerEmail> itemsCustomersMetaPartnerEmail = new BLL.SortableList<BLL.Customers.MetaPartnerEmail>();
            itemsCustomersMetaPartnerEmail.Add((BLL.Customers.MetaPartnerEmail)item);
            useCollections["Customers.MetaPartnerEmail"] = itemsCustomersMetaPartnerEmail;
            MetaPartnerEmail_Manager.PopulateItem(item, useCollections, performCascade, false, false, results);
            try
            {
                if (IsValidForUpdate(item, performCascade, results) == true)
                {
                    startTicks = DateTime.Now.Ticks;
                    BLL.Customers.MetaPartnerEmailManager.UpsertOneMetaPartnerEmail(item, performCascade);
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
        /// <summary>This method is used to get MetaPartnerEmail items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.Customers.MetaPartnerEmail> GetAllMetaPartnerEmailDataTest(MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get all items
            //
            try
            {
                startTicks = DateTime.Now.Ticks;
                BLL.SortableList<BLL.Customers.MetaPartnerEmail> items = BLL.Customers.MetaPartnerEmailManager.GetAllMetaPartnerEmailData();
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
        /// <summary>This method is used to get a set of MetaPartnerEmail items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.Customers.MetaPartnerEmail> GetManyMetaPartnerEmailDataByCriteriaTest(MOD.Data.DataOptions dataOptions, MOD.Test.TestResults results)
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
                NamedObjectCollection nocLastModifiedDate = new NamedObjectCollection();
                startTicks = DateTime.Now.Ticks;
                BLL.SortableList<BLL.Customers.MetaPartnerEmail> items =  BLL.Customers.MetaPartnerEmailManager.GetManyMetaPartnerEmailDataByCriteria(null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                BLL.SortableList<BLL.Customers.MetaPartnerEmail> specificItems = null;
                string specificWarnings = String.Empty;
                bool searchValueUsed = false;
                int paramCount = 0;
                if (items.Count < 1)
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "No items found in GetManyMetaPartnerEmailDataByCriteria generic search.", null);
                }
                paramCount = 0;
                foreach (BLL.Customers.MetaPartnerEmail item in items)
                {
                    nocLastModifiedDate[TestHelper.GetStringKeyFromObject((object)(item.LastModifiedDate), paramCount)] = item.LastModifiedDate;
                    paramCount++;
                }
                paramCount = 0;
                DateTime itemLastModifiedDate = TestHelper.GetDateTime(null, null, nocLastModifiedDate, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Customers.MetaPartnerEmailManager.GetManyMetaPartnerEmailDataByCriteria(itemLastModifiedDate, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyMetaPartnerEmailDataByCriteria search with LastModifiedDate = " + itemLastModifiedDate.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                if (specificWarnings != String.Empty)
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "Results were not returned for GetManyMetaPartnerEmailDataByCriteria specific searches.", new Exception(specificWarnings));
                }
                return items;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to delete MetaPartnerEmail items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Customers.MetaPartnerEmail DeleteOneMetaPartnerEmailTest(Guid metaPartnerEmailID, bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get and delete item
            //
            BLL.Customers.MetaPartnerEmail item = new BLL.Customers.MetaPartnerEmail();
            try
            {
                item = BLL.Customers.MetaPartnerEmailManager.GetOneMetaPartnerEmail(metaPartnerEmailID);
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
                    BLL.Customers.MetaPartnerEmailManager.DeleteOneMetaPartnerEmail(item, performCascade);
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