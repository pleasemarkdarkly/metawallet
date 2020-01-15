

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
    /// <summary>This class contains support methods to test Promotion instances.</summary>
    ///
    /// File History:
    /// <created>7/31/2007 (Brian MacDonald)</created>
    ///
    /// <remarks></remarks>
    // ------------------------------------------------------------------------------
    public partial class Promotion_Manager
    {

		#region Properties
        #endregion Properties

        #region Constructors

        // ------------------------------------------------------------------------------
        /// <summary>This method is the constructor (currently does nothing).</summary>
        // ------------------------------------------------------------------------------
        public Promotion_Manager()
        {
            //
            // constructor logic
            //
        }

        #endregion Constructors

		#region Methods

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add Promotion items.</summary>
        // ------------------------------------------------------------------------------
        public static void PopulateItem(BLL.Promotions.Promotion item, MOD.Data.NamedObjectCollection useCollections, bool performCascade, bool isAddOperation, bool isCollectionOperation, MOD.Test.TestResults results)
        {
            if (item == null)
            {
                return;
            }

            //
            // populate the Promotion item
            //
            if (isAddOperation == true)
            {
                item.PromotionCode = TestHelper.GetInt(null, null);
            }
            item.PromotionName = TestHelper.GetString(null, 255);
            item.PromotionText = TestHelper.GetString(null, 1000);
            BLL.SortableList<BLL.Promotions.PromotionType> itemPromotionTypePromotionTypeCode = null;
            if (useCollections != null && useCollections["Promotions.PromotionType"] != null)
            {
                itemPromotionTypePromotionTypeCode = (BLL.SortableList<BLL.Promotions.PromotionType>)useCollections["Promotions.PromotionType"];
            }
            if (itemPromotionTypePromotionTypeCode == null || itemPromotionTypePromotionTypeCode.Count <= 0)
            {
                itemPromotionTypePromotionTypeCode = BLL.Promotions.PromotionTypeManager.GetAllPromotionTypeData();
            }
            if (itemPromotionTypePromotionTypeCode.Count > 0)
            {
                int index = TestHelper.GetInt(0, Math.Max(0, itemPromotionTypePromotionTypeCode.Count-1));
                item.PromotionTypeCode = itemPromotionTypePromotionTypeCode[index].PromotionTypeCode;
            }
            else
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Could not find values for PromotionType.", null);
            }
            item.StartDate = TestHelper.GetDateTime(null, null);
            item.EndDate = TestHelper.GetDateTime(null, null);
            item.Description = TestHelper.GetString(null, 2000);
            item.IsActive = TestHelper.GetBool();

            //
            // collections
            //
            if (performCascade == true && isAddOperation == true)
            {
                int collectionLoadCount = 0;
                collectionLoadCount = TestHelper.GetInt(Globals.MinimumLoadCountPerCollection, Globals.MaximumLoadCountPerCollection);
                TestHelper.ReportValueToConsole("PopulateItem: Next collection load count", collectionLoadCount);
                item.PromotionCouponList = new BLL.SortableList<BLL.Promotions.PromotionCoupon>();
                BLL.Promotions.PromotionCoupon vPromotionCouponList = null;
                for (int j=0; j < collectionLoadCount; j++)
                {
                    vPromotionCouponList = new BLL.Promotions.PromotionCoupon();
                    MW.MComm.WalletSolution.UnitTest.Promotions.PromotionCoupon_Manager.PopulateItem(vPromotionCouponList, useCollections, false, true, true, results);
                    results.IsCollision = false;
                    foreach (BLL.Promotions.PromotionCoupon loopPromotionCoupon in item.PromotionCouponList)
                    {
                        if (loopPromotionCoupon.PrimaryKey == vPromotionCouponList.PrimaryKey)
                        {
                            Console.WriteLine("Collision in collection encountered for PromotionCoupon: " + vPromotionCouponList.PrimaryKey.ToString());
                            results.IsCollision = true;
                            break;
                        }
                    }
                    if (results.IsCollision == false)
                    {
                        try
                        {
                            BLL.Promotions.PromotionCoupon item2 = BLL.Promotions.PromotionCouponManager.GetOnePromotionCoupon(vPromotionCouponList.PromotionCode, vPromotionCouponList.CouponCode);
                            if (item2 != null)
                            {
                                results.IsCollision = true;
                                Console.WriteLine("Add collision encountered for PromotionCoupon: " + item2.PrimaryKey.ToString());
                            }
                        }
                        catch (UnitTestException ex)
                        {
                            throw ex;
                        }
                        catch (System.Exception ex)
                        {
                            throw new UnitTestException(UnitTestErrorType.Warning, "Get failed for PromotionCoupon", ex);
                        }
                    }
                    if (results.IsCollision == false)
                    {
                        item.PromotionCouponList.Add(vPromotionCouponList);
                    }
                }
            }
            PopulateItemCleanup(item, useCollections, performCascade, isAddOperation, isCollectionOperation, results);
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add Promotion items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Promotions.Promotion AddOnePromotionTest(bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // add item
            //
            BLL.Promotions.Promotion item = new BLL.Promotions.Promotion();
            MOD.Data.NamedObjectCollection useCollections = new MOD.Data.NamedObjectCollection();
            BLL.SortableList<BLL.Promotions.Promotion> itemsPromotionsPromotion = new BLL.SortableList<BLL.Promotions.Promotion>();
            itemsPromotionsPromotion.Add((BLL.Promotions.Promotion)item);
            useCollections["Promotions.Promotion"] = itemsPromotionsPromotion;
            Promotion_Manager.PopulateItem(item, useCollections, performCascade, true, false, results);
            results.IsCollision = false; // discard collection collisions
            BLL.Promotions.Promotion item2 = null;
            try
            {
                item2 = BLL.Promotions.PromotionManager.GetOnePromotion(item.PromotionCode);
            }
            catch (UnitTestException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Get failed for Promotion: " + item.PrimaryKey.ToString(), ex);
            }
            if (item2 != null)
            {
                results.IsCollision = true;
                throw new UnitTestException(UnitTestErrorType.Warning, "Add collision encountered for Promotion: " + item.PrimaryKey.ToString(), null);
            }
            if (results.IsCollision == false)
            {
                try
                {
                    if (IsValidForAdd(item, performCascade, results) == true)
                    {
                        startTicks = DateTime.Now.Ticks;
                        BLL.Promotions.PromotionManager.AddOnePromotion(item, performCascade);
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
        /// <summary>This method is used to update Promotion items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Promotions.Promotion UpdateOnePromotionTest(int promotionCode, bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get and update item
            //
            BLL.Promotions.Promotion item = new BLL.Promotions.Promotion();
            try
            {
                item = BLL.Promotions.PromotionManager.GetOnePromotion(promotionCode);
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
            BLL.SortableList<BLL.Promotions.Promotion> itemsPromotionsPromotion = new BLL.SortableList<BLL.Promotions.Promotion>();
            itemsPromotionsPromotion.Add((BLL.Promotions.Promotion)item);
            useCollections["Promotions.Promotion"] = itemsPromotionsPromotion;
            Promotion_Manager.PopulateItem(item, useCollections, performCascade, false, false, results);
            try
            {
                if (IsValidForUpdate(item, performCascade, results) == true)
                {
                    startTicks = DateTime.Now.Ticks;
                    BLL.Promotions.PromotionManager.UpdateOnePromotion(item, performCascade);
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
        /// <summary>This method is used to get Promotion items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.Promotions.Promotion> GetAllPromotionDataTest(MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get all items
            //
            try
            {
                startTicks = DateTime.Now.Ticks;
                BLL.SortableList<BLL.Promotions.Promotion> items = BLL.Promotions.PromotionManager.GetAllPromotionData();
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
        /// <summary>This method is used to get a set of Promotion items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.Promotions.Promotion> GetManyPromotionDataByCriteriaTest(MOD.Data.DataOptions dataOptions, MOD.Test.TestResults results)
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
                NamedObjectCollection nocPromotionName = new NamedObjectCollection();
                NamedObjectCollection nocPromotionTypeCode = new NamedObjectCollection();
                NamedObjectCollection nocStartDate = new NamedObjectCollection();
                NamedObjectCollection nocEndDate = new NamedObjectCollection();
                NamedObjectCollection nocLastModifiedDate = new NamedObjectCollection();
                startTicks = DateTime.Now.Ticks;
                BLL.SortableList<BLL.Promotions.Promotion> items =  BLL.Promotions.PromotionManager.GetManyPromotionDataByCriteria(null, null, null, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                BLL.SortableList<BLL.Promotions.Promotion> specificItems = null;
                string specificWarnings = String.Empty;
                bool searchValueUsed = false;
                int paramCount = 0;
                if (items.Count < 1)
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "No items found in GetManyPromotionDataByCriteria generic search.", null);
                }
                paramCount = 0;
                foreach (BLL.Promotions.Promotion item in items)
                {
                    nocPromotionName[TestHelper.GetStringKeyFromObject((object)(item.PromotionName), paramCount)] = item.PromotionName;
                    nocPromotionTypeCode[TestHelper.GetStringKeyFromObject((object)(item.PromotionTypeCode), paramCount)] = item.PromotionTypeCode;
                    nocStartDate[TestHelper.GetStringKeyFromObject((object)(item.StartDate), paramCount)] = item.StartDate;
                    nocEndDate[TestHelper.GetStringKeyFromObject((object)(item.EndDate), paramCount)] = item.EndDate;
                    nocLastModifiedDate[TestHelper.GetStringKeyFromObject((object)(item.LastModifiedDate), paramCount)] = item.LastModifiedDate;
                    paramCount++;
                }
                paramCount = 0;
                string itemPromotionName = TestHelper.GetString(null, 255, nocPromotionName, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Promotions.PromotionManager.GetManyPromotionDataByCriteria(itemPromotionName, null, null, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyPromotionDataByCriteria search with PromotionName = " + itemPromotionName.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                int itemPromotionTypeCode = TestHelper.GetInt(null, null, nocPromotionTypeCode, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Promotions.PromotionManager.GetManyPromotionDataByCriteria(null, itemPromotionTypeCode, null, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyPromotionDataByCriteria search with PromotionTypeCode = " + itemPromotionTypeCode.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                DateTime itemStartDate = TestHelper.GetDateTime(null, null, nocStartDate, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Promotions.PromotionManager.GetManyPromotionDataByCriteria(null, null, itemStartDate, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyPromotionDataByCriteria search with StartDate = " + itemStartDate.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                DateTime itemEndDate = TestHelper.GetDateTime(null, null, nocEndDate, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Promotions.PromotionManager.GetManyPromotionDataByCriteria(null, null, null, itemEndDate, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyPromotionDataByCriteria search with EndDate = " + itemEndDate.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                DateTime itemLastModifiedDate = TestHelper.GetDateTime(null, null, nocLastModifiedDate, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Promotions.PromotionManager.GetManyPromotionDataByCriteria(null, null, null, null, itemLastModifiedDate, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyPromotionDataByCriteria search with LastModifiedDate = " + itemLastModifiedDate.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                if (specificWarnings != String.Empty)
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "Results were not returned for GetManyPromotionDataByCriteria specific searches.", new Exception(specificWarnings));
                }
                return items;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to delete Promotion items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Promotions.Promotion DeleteOnePromotionTest(int promotionCode, bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get and delete item
            //
            BLL.Promotions.Promotion item = new BLL.Promotions.Promotion();
            try
            {
                item = BLL.Promotions.PromotionManager.GetOnePromotion(promotionCode);
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
                    BLL.Promotions.PromotionManager.DeleteOnePromotion(item, performCascade);
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