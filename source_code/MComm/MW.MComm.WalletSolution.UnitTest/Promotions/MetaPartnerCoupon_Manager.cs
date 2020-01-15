

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

namespace MW.MComm.WalletSolution.UnitTest.Promotions
{
    // ------------------------------------------------------------------------------
    /// <summary>This class contains support methods to test MetaPartnerCoupon instances.</summary>
    ///
    /// File History:
    /// <created>7/31/2007 (Brian MacDonald)</created>
    ///
    /// <remarks></remarks>
    // ------------------------------------------------------------------------------
    public partial class MetaPartnerCoupon_Manager
    {

		#region Properties
        #endregion Properties

        #region Constructors

        // ------------------------------------------------------------------------------
        /// <summary>This method is the constructor (currently does nothing).</summary>
        // ------------------------------------------------------------------------------
        public MetaPartnerCoupon_Manager()
        {
            //
            // constructor logic
            //
        }

        #endregion Constructors

		#region Methods

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add MetaPartnerCoupon items.</summary>
        // ------------------------------------------------------------------------------
        public static void PopulateItem(BLL.Promotions.MetaPartnerCoupon item, MOD.Data.NamedObjectCollection useCollections, bool performCascade, bool isAddOperation, bool isCollectionOperation, MOD.Test.TestResults results)
        {
            if (item == null)
            {
                return;
            }

            //
            // populate the MetaPartnerCoupon item
            //
            int totalRecords = 0;
            bool totalRecordsExceeded = false;
            if (isAddOperation == true)
            {
                item.MetaPartnerCouponID = TestHelper.GetGuid();
            }
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
            totalRecords = 0;
            totalRecordsExceeded = false;
            BLL.SortableList<BLL.Promotions.Coupon> itemCouponCouponCode = null;
            if (useCollections != null && useCollections["Promotions.Coupon"] != null)
            {
                itemCouponCouponCode = (BLL.SortableList<BLL.Promotions.Coupon>)useCollections["Promotions.Coupon"];
            }
            if (itemCouponCouponCode == null || itemCouponCouponCode.Count <= 0)
            {
                itemCouponCouponCode = BLL.Promotions.CouponManager.GetManyCouponDataByCriteria(null, null, null, null, null, null, out totalRecords, out totalRecordsExceeded, Globals.getDataOptions("","",1,200,2000));
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
            }
            if (itemCouponCouponCode.Count > 0)
            {
                int index = TestHelper.GetInt(0, Math.Max(0, itemCouponCouponCode.Count-1));
                item.CouponCode = itemCouponCouponCode[index].CouponCode;
            }
            else
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Could not find values for Coupon.", null);
            }
            item.OriginalAmount = TestHelper.GetDecimal(-1000000, 1000000);
            item.BalanceAmount = TestHelper.GetDecimal(-1000000, 1000000);
            item.StartDate = TestHelper.GetDateTime(null, null);
            item.EndDate = TestHelper.GetDateTime(null, null);
            PopulateItemCleanup(item, useCollections, performCascade, isAddOperation, isCollectionOperation, results);
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add MetaPartnerCoupon items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Promotions.MetaPartnerCoupon AddOneMetaPartnerCouponTest(bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // add item
            //
            BLL.Promotions.MetaPartnerCoupon item = new BLL.Promotions.MetaPartnerCoupon();
            MOD.Data.NamedObjectCollection useCollections = new MOD.Data.NamedObjectCollection();
            BLL.SortableList<BLL.Promotions.MetaPartnerCoupon> itemsPromotionsMetaPartnerCoupon = new BLL.SortableList<BLL.Promotions.MetaPartnerCoupon>();
            itemsPromotionsMetaPartnerCoupon.Add((BLL.Promotions.MetaPartnerCoupon)item);
            useCollections["Promotions.MetaPartnerCoupon"] = itemsPromotionsMetaPartnerCoupon;
            MetaPartnerCoupon_Manager.PopulateItem(item, useCollections, performCascade, true, false, results);
            results.IsCollision = false; // discard collection collisions
            BLL.Promotions.MetaPartnerCoupon item2 = null;
            try
            {
                item2 = BLL.Promotions.MetaPartnerCouponManager.GetOneMetaPartnerCoupon(item.MetaPartnerCouponID);
            }
            catch (UnitTestException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Get failed for MetaPartnerCoupon: " + item.PrimaryKey.ToString(), ex);
            }
            if (item2 != null)
            {
                results.IsCollision = true;
                throw new UnitTestException(UnitTestErrorType.Warning, "Add collision encountered for MetaPartnerCoupon: " + item.PrimaryKey.ToString(), null);
            }
            if (results.IsCollision == false)
            {
                try
                {
                    if (IsValidForAdd(item, performCascade, results) == true)
                    {
                        startTicks = DateTime.Now.Ticks;
                        BLL.Promotions.MetaPartnerCouponManager.UpsertOneMetaPartnerCoupon(item, performCascade);
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
        /// <summary>This method is used to update MetaPartnerCoupon items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Promotions.MetaPartnerCoupon UpdateOneMetaPartnerCouponTest(Guid metaPartnerCouponID, bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get and update item
            //
            BLL.Promotions.MetaPartnerCoupon item = new BLL.Promotions.MetaPartnerCoupon();
            try
            {
                item = BLL.Promotions.MetaPartnerCouponManager.GetOneMetaPartnerCoupon(metaPartnerCouponID);
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
            BLL.SortableList<BLL.Promotions.MetaPartnerCoupon> itemsPromotionsMetaPartnerCoupon = new BLL.SortableList<BLL.Promotions.MetaPartnerCoupon>();
            itemsPromotionsMetaPartnerCoupon.Add((BLL.Promotions.MetaPartnerCoupon)item);
            useCollections["Promotions.MetaPartnerCoupon"] = itemsPromotionsMetaPartnerCoupon;
            MetaPartnerCoupon_Manager.PopulateItem(item, useCollections, performCascade, false, false, results);
            try
            {
                if (IsValidForUpdate(item, performCascade, results) == true)
                {
                    startTicks = DateTime.Now.Ticks;
                    BLL.Promotions.MetaPartnerCouponManager.UpsertOneMetaPartnerCoupon(item, performCascade);
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
        /// <summary>This method is used to get MetaPartnerCoupon items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.Promotions.MetaPartnerCoupon> GetAllMetaPartnerCouponDataTest(MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get all items
            //
            try
            {
                startTicks = DateTime.Now.Ticks;
                BLL.SortableList<BLL.Promotions.MetaPartnerCoupon> items = BLL.Promotions.MetaPartnerCouponManager.GetAllMetaPartnerCouponData();
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
        /// <summary>This method is used to get a set of MetaPartnerCoupon items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.Promotions.MetaPartnerCoupon> GetManyMetaPartnerCouponDataByCriteriaTest(MOD.Data.DataOptions dataOptions, MOD.Test.TestResults results)
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
                NamedObjectCollection nocCouponCode = new NamedObjectCollection();
                NamedObjectCollection nocStartDate = new NamedObjectCollection();
                NamedObjectCollection nocEndDate = new NamedObjectCollection();
                NamedObjectCollection nocLastModifiedDate = new NamedObjectCollection();
                startTicks = DateTime.Now.Ticks;
                BLL.SortableList<BLL.Promotions.MetaPartnerCoupon> items =  BLL.Promotions.MetaPartnerCouponManager.GetManyMetaPartnerCouponDataByCriteria(null, null, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                BLL.SortableList<BLL.Promotions.MetaPartnerCoupon> specificItems = null;
                string specificWarnings = String.Empty;
                bool searchValueUsed = false;
                int paramCount = 0;
                if (items.Count < 1)
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "No items found in GetManyMetaPartnerCouponDataByCriteria generic search.", null);
                }
                paramCount = 0;
                foreach (BLL.Promotions.MetaPartnerCoupon item in items)
                {
                    nocCouponCode[TestHelper.GetStringKeyFromObject((object)(item.CouponCode), paramCount)] = item.CouponCode;
                    nocStartDate[TestHelper.GetStringKeyFromObject((object)(item.StartDate), paramCount)] = item.StartDate;
                    nocEndDate[TestHelper.GetStringKeyFromObject((object)(item.EndDate), paramCount)] = item.EndDate;
                    nocLastModifiedDate[TestHelper.GetStringKeyFromObject((object)(item.LastModifiedDate), paramCount)] = item.LastModifiedDate;
                    paramCount++;
                }
                paramCount = 0;
                int itemCouponCode = TestHelper.GetInt(null, null, nocCouponCode, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Promotions.MetaPartnerCouponManager.GetManyMetaPartnerCouponDataByCriteria(itemCouponCode, null, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyMetaPartnerCouponDataByCriteria search with CouponCode = " + itemCouponCode.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                DateTime itemStartDate = TestHelper.GetDateTime(null, null, nocStartDate, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Promotions.MetaPartnerCouponManager.GetManyMetaPartnerCouponDataByCriteria(null, itemStartDate, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyMetaPartnerCouponDataByCriteria search with StartDate = " + itemStartDate.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                DateTime itemEndDate = TestHelper.GetDateTime(null, null, nocEndDate, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Promotions.MetaPartnerCouponManager.GetManyMetaPartnerCouponDataByCriteria(null, null, itemEndDate, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyMetaPartnerCouponDataByCriteria search with EndDate = " + itemEndDate.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                DateTime itemLastModifiedDate = TestHelper.GetDateTime(null, null, nocLastModifiedDate, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Promotions.MetaPartnerCouponManager.GetManyMetaPartnerCouponDataByCriteria(null, null, null, itemLastModifiedDate, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyMetaPartnerCouponDataByCriteria search with LastModifiedDate = " + itemLastModifiedDate.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                if (specificWarnings != String.Empty)
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "Results were not returned for GetManyMetaPartnerCouponDataByCriteria specific searches.", new Exception(specificWarnings));
                }
                return items;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to delete MetaPartnerCoupon items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Promotions.MetaPartnerCoupon DeleteOneMetaPartnerCouponTest(Guid metaPartnerCouponID, bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get and delete item
            //
            BLL.Promotions.MetaPartnerCoupon item = new BLL.Promotions.MetaPartnerCoupon();
            try
            {
                item = BLL.Promotions.MetaPartnerCouponManager.GetOneMetaPartnerCoupon(metaPartnerCouponID);
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
                    BLL.Promotions.MetaPartnerCouponManager.DeleteOneMetaPartnerCoupon(item, performCascade);
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