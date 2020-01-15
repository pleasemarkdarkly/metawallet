

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
    /// <summary>This class contains support methods to test Coupon instances.</summary>
    ///
    /// File History:
    /// <created>7/31/2007 (Brian MacDonald)</created>
    ///
    /// <remarks></remarks>
    // ------------------------------------------------------------------------------
    public partial class Coupon_Manager
    {

		#region Properties
        #endregion Properties

        #region Constructors

        // ------------------------------------------------------------------------------
        /// <summary>This method is the constructor (currently does nothing).</summary>
        // ------------------------------------------------------------------------------
        public Coupon_Manager()
        {
            //
            // constructor logic
            //
        }

        #endregion Constructors

		#region Methods

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add Coupon items.</summary>
        // ------------------------------------------------------------------------------
        public static void PopulateItem(BLL.Promotions.Coupon item, MOD.Data.NamedObjectCollection useCollections, bool performCascade, bool isAddOperation, bool isCollectionOperation, MOD.Test.TestResults results)
        {
            if (item == null)
            {
                return;
            }

            //
            // populate the Coupon item
            //
            if (isAddOperation == true)
            {
                item.CouponCode = TestHelper.GetInt(null, null);
            }
            item.CouponName = TestHelper.GetString(null, 255);
            item.CouponText = TestHelper.GetString(null, 1000);
            BLL.SortableList<BLL.Promotions.CouponType> itemCouponTypeCouponTypeCode = null;
            if (useCollections != null && useCollections["Promotions.CouponType"] != null)
            {
                itemCouponTypeCouponTypeCode = (BLL.SortableList<BLL.Promotions.CouponType>)useCollections["Promotions.CouponType"];
            }
            if (itemCouponTypeCouponTypeCode == null || itemCouponTypeCouponTypeCode.Count <= 0)
            {
                itemCouponTypeCouponTypeCode = BLL.Promotions.CouponTypeManager.GetAllCouponTypeData();
            }
            if (itemCouponTypeCouponTypeCode.Count > 0)
            {
                int index = TestHelper.GetInt(0, Math.Max(0, itemCouponTypeCouponTypeCode.Count-1));
                item.CouponTypeCode = itemCouponTypeCouponTypeCode[index].CouponTypeCode;
            }
            else
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Could not find values for CouponType.", null);
            }
            BLL.SortableList<BLL.Promotions.DiscountType> itemDiscountTypeDiscountTypeCode = null;
            if (useCollections != null && useCollections["Promotions.DiscountType"] != null)
            {
                itemDiscountTypeDiscountTypeCode = (BLL.SortableList<BLL.Promotions.DiscountType>)useCollections["Promotions.DiscountType"];
            }
            if (itemDiscountTypeDiscountTypeCode == null || itemDiscountTypeDiscountTypeCode.Count <= 0)
            {
                itemDiscountTypeDiscountTypeCode = BLL.Promotions.DiscountTypeManager.GetAllDiscountTypeData();
            }
            if (itemDiscountTypeDiscountTypeCode.Count > 0)
            {
                int index = TestHelper.GetInt(0, Math.Max(0, itemDiscountTypeDiscountTypeCode.Count-1));
                item.DiscountTypeCode = itemDiscountTypeDiscountTypeCode[index].DiscountTypeCode;
            }
            else
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Could not find values for DiscountType.", null);
            }
            item.DiscountAmount = TestHelper.GetDecimal(-1000000, 1000000);
            item.TriggerAmount = TestHelper.GetDecimal(-1000000, 1000000);
            BLL.SortableList<BLL.Accounts.Currency> itemCurrencyCurrencyCode = null;
            if (useCollections != null && useCollections["Accounts.Currency"] != null)
            {
                itemCurrencyCurrencyCode = (BLL.SortableList<BLL.Accounts.Currency>)useCollections["Accounts.Currency"];
            }
            if (itemCurrencyCurrencyCode == null || itemCurrencyCurrencyCode.Count <= 0)
            {
                itemCurrencyCurrencyCode = BLL.Accounts.CurrencyManager.GetAllCurrencyData();
            }
            if (itemCurrencyCurrencyCode.Count > 0)
            {
                int index = TestHelper.GetInt(0, Math.Max(0, itemCurrencyCurrencyCode.Count-1));
                item.CurrencyCode = itemCurrencyCurrencyCode[index].CurrencyCode;
            }
            else
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Could not find values for Currency.", null);
            }
            item.DaysToExpire = TestHelper.GetInt(null, null);
            item.IsFeeEnabled = TestHelper.GetBool();
            item.IsPaymentEnabled = TestHelper.GetBool();
            item.Description = TestHelper.GetString(null, 2000);
            item.IsActive = TestHelper.GetBool();
            PopulateItemCleanup(item, useCollections, performCascade, isAddOperation, isCollectionOperation, results);
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add Coupon items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Promotions.Coupon AddOneCouponTest(bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // add item
            //
            BLL.Promotions.Coupon item = new BLL.Promotions.Coupon();
            MOD.Data.NamedObjectCollection useCollections = new MOD.Data.NamedObjectCollection();
            BLL.SortableList<BLL.Promotions.Coupon> itemsPromotionsCoupon = new BLL.SortableList<BLL.Promotions.Coupon>();
            itemsPromotionsCoupon.Add((BLL.Promotions.Coupon)item);
            useCollections["Promotions.Coupon"] = itemsPromotionsCoupon;
            Coupon_Manager.PopulateItem(item, useCollections, performCascade, true, false, results);
            results.IsCollision = false; // discard collection collisions
            BLL.Promotions.Coupon item2 = null;
            try
            {
                item2 = BLL.Promotions.CouponManager.GetOneCoupon(item.CouponCode);
            }
            catch (UnitTestException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Get failed for Coupon: " + item.PrimaryKey.ToString(), ex);
            }
            if (item2 != null)
            {
                results.IsCollision = true;
                throw new UnitTestException(UnitTestErrorType.Warning, "Add collision encountered for Coupon: " + item.PrimaryKey.ToString(), null);
            }
            if (results.IsCollision == false)
            {
                try
                {
                    if (IsValidForAdd(item, performCascade, results) == true)
                    {
                        startTicks = DateTime.Now.Ticks;
                        BLL.Promotions.CouponManager.AddOneCoupon(item, performCascade);
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
        /// <summary>This method is used to update Coupon items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Promotions.Coupon UpdateOneCouponTest(int couponCode, bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get and update item
            //
            BLL.Promotions.Coupon item = new BLL.Promotions.Coupon();
            try
            {
                item = BLL.Promotions.CouponManager.GetOneCoupon(couponCode);
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
            BLL.SortableList<BLL.Promotions.Coupon> itemsPromotionsCoupon = new BLL.SortableList<BLL.Promotions.Coupon>();
            itemsPromotionsCoupon.Add((BLL.Promotions.Coupon)item);
            useCollections["Promotions.Coupon"] = itemsPromotionsCoupon;
            Coupon_Manager.PopulateItem(item, useCollections, performCascade, false, false, results);
            try
            {
                if (IsValidForUpdate(item, performCascade, results) == true)
                {
                    startTicks = DateTime.Now.Ticks;
                    BLL.Promotions.CouponManager.UpdateOneCoupon(item, performCascade);
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
        /// <summary>This method is used to get Coupon items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.Promotions.Coupon> GetAllCouponDataTest(MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get all items
            //
            try
            {
                startTicks = DateTime.Now.Ticks;
                BLL.SortableList<BLL.Promotions.Coupon> items = BLL.Promotions.CouponManager.GetAllCouponData();
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
        /// <summary>This method is used to get a set of Coupon items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.Promotions.Coupon> GetManyCouponDataByCriteriaTest(MOD.Data.DataOptions dataOptions, MOD.Test.TestResults results)
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
                NamedObjectCollection nocCouponName = new NamedObjectCollection();
                NamedObjectCollection nocCouponTypeCode = new NamedObjectCollection();
                NamedObjectCollection nocDiscountTypeCode = new NamedObjectCollection();
                NamedObjectCollection nocCurrencyCode = new NamedObjectCollection();
                NamedObjectCollection nocLastModifiedDate = new NamedObjectCollection();
                startTicks = DateTime.Now.Ticks;
                BLL.SortableList<BLL.Promotions.Coupon> items =  BLL.Promotions.CouponManager.GetManyCouponDataByCriteria(null, null, null, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                BLL.SortableList<BLL.Promotions.Coupon> specificItems = null;
                string specificWarnings = String.Empty;
                bool searchValueUsed = false;
                int paramCount = 0;
                if (items.Count < 1)
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "No items found in GetManyCouponDataByCriteria generic search.", null);
                }
                paramCount = 0;
                foreach (BLL.Promotions.Coupon item in items)
                {
                    nocCouponName[TestHelper.GetStringKeyFromObject((object)(item.CouponName), paramCount)] = item.CouponName;
                    nocCouponTypeCode[TestHelper.GetStringKeyFromObject((object)(item.CouponTypeCode), paramCount)] = item.CouponTypeCode;
                    nocDiscountTypeCode[TestHelper.GetStringKeyFromObject((object)(item.DiscountTypeCode), paramCount)] = item.DiscountTypeCode;
                    nocCurrencyCode[TestHelper.GetStringKeyFromObject((object)(item.CurrencyCode), paramCount)] = item.CurrencyCode;
                    nocLastModifiedDate[TestHelper.GetStringKeyFromObject((object)(item.LastModifiedDate), paramCount)] = item.LastModifiedDate;
                    paramCount++;
                }
                paramCount = 0;
                string itemCouponName = TestHelper.GetString(null, 255, nocCouponName, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Promotions.CouponManager.GetManyCouponDataByCriteria(itemCouponName, null, null, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyCouponDataByCriteria search with CouponName = " + itemCouponName.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                int itemCouponTypeCode = TestHelper.GetInt(null, null, nocCouponTypeCode, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Promotions.CouponManager.GetManyCouponDataByCriteria(null, itemCouponTypeCode, null, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyCouponDataByCriteria search with CouponTypeCode = " + itemCouponTypeCode.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                int itemDiscountTypeCode = TestHelper.GetInt(null, null, nocDiscountTypeCode, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Promotions.CouponManager.GetManyCouponDataByCriteria(null, null, itemDiscountTypeCode, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyCouponDataByCriteria search with DiscountTypeCode = " + itemDiscountTypeCode.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                int itemCurrencyCode = TestHelper.GetInt(null, null, nocCurrencyCode, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Promotions.CouponManager.GetManyCouponDataByCriteria(null, null, null, itemCurrencyCode, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyCouponDataByCriteria search with CurrencyCode = " + itemCurrencyCode.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                DateTime itemLastModifiedDate = TestHelper.GetDateTime(null, null, nocLastModifiedDate, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Promotions.CouponManager.GetManyCouponDataByCriteria(null, null, null, null, itemLastModifiedDate, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyCouponDataByCriteria search with LastModifiedDate = " + itemLastModifiedDate.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                if (specificWarnings != String.Empty)
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "Results were not returned for GetManyCouponDataByCriteria specific searches.", new Exception(specificWarnings));
                }
                return items;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to delete Coupon items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Promotions.Coupon DeleteOneCouponTest(int couponCode, bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get and delete item
            //
            BLL.Promotions.Coupon item = new BLL.Promotions.Coupon();
            try
            {
                item = BLL.Promotions.CouponManager.GetOneCoupon(couponCode);
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
                    BLL.Promotions.CouponManager.DeleteOneCoupon(item, performCascade);
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