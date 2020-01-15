

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
    /// <summary>This class contains support methods to test PromotionCoupon instances.</summary>
    ///
    /// File History:
    /// <created>7/31/2007 (Brian MacDonald)</created>
    ///
    /// <remarks></remarks>
    // ------------------------------------------------------------------------------
    public partial class PromotionCoupon_Manager
    {

		#region Properties
        #endregion Properties

        #region Constructors

        // ------------------------------------------------------------------------------
        /// <summary>This method is the constructor (currently does nothing).</summary>
        // ------------------------------------------------------------------------------
        public PromotionCoupon_Manager()
        {
            //
            // constructor logic
            //
        }

        #endregion Constructors

		#region Methods

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add PromotionCoupon items.</summary>
        // ------------------------------------------------------------------------------
        public static void PopulateItem(BLL.Promotions.PromotionCoupon item, MOD.Data.NamedObjectCollection useCollections, bool performCascade, bool isAddOperation, bool isCollectionOperation, MOD.Test.TestResults results)
        {
            if (item == null)
            {
                return;
            }

            //
            // populate the PromotionCoupon item
            //
            int totalRecords = 0;
            bool totalRecordsExceeded = false;
            if (isCollectionOperation == true && isAddOperation == true)
            {
                totalRecords = 0;
                totalRecordsExceeded = false;
                BLL.SortableList<BLL.Promotions.Promotion> itemPromotionPromotionCode = null;
                if (useCollections != null && useCollections["Promotions.Promotion"] != null)
                {
                    itemPromotionPromotionCode = (BLL.SortableList<BLL.Promotions.Promotion>)useCollections["Promotions.Promotion"];
                }
                if (itemPromotionPromotionCode == null || itemPromotionPromotionCode.Count <= 0)
                {
                    itemPromotionPromotionCode = BLL.Promotions.PromotionManager.GetManyPromotionDataByCriteria(null, null, null, null, null, null, out totalRecords, out totalRecordsExceeded, Globals.getDataOptions("","",1,200,2000));
                    results.TotalRecords = totalRecords;
                    results.TotalRecordsExceeded = totalRecordsExceeded;
                }
                if (itemPromotionPromotionCode.Count > 0)
                {
                    int index = TestHelper.GetInt(0, Math.Max(0, itemPromotionPromotionCode.Count-1));
                    item.PromotionCode = itemPromotionPromotionCode[index].PromotionCode;
                }
                else
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "Could not find values for Promotion.", null);
                }
            }
            if (isCollectionOperation == true && isAddOperation == true)
            {
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
            }
            item.Rank = TestHelper.GetInt(null, null);
            PopulateItemCleanup(item, useCollections, performCascade, isAddOperation, isCollectionOperation, results);
        }
        #endregion Methods
    }
}