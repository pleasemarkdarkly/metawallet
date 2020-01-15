

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

namespace MW.MComm.WalletSolution.UnitTest.Orders
{
    // ------------------------------------------------------------------------------
    /// <summary>This class contains support methods to test OrderCoupon instances.</summary>
    ///
    /// File History:
    /// <created>7/31/2007 (Brian MacDonald)</created>
    ///
    /// <remarks></remarks>
    // ------------------------------------------------------------------------------
    public partial class OrderCoupon_Manager
    {

		#region Properties
        #endregion Properties

        #region Constructors

        // ------------------------------------------------------------------------------
        /// <summary>This method is the constructor (currently does nothing).</summary>
        // ------------------------------------------------------------------------------
        public OrderCoupon_Manager()
        {
            //
            // constructor logic
            //
        }

        #endregion Constructors

		#region Methods

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add OrderCoupon items.</summary>
        // ------------------------------------------------------------------------------
        public static void PopulateItem(BLL.Orders.OrderCoupon item, MOD.Data.NamedObjectCollection useCollections, bool performCascade, bool isAddOperation, bool isCollectionOperation, MOD.Test.TestResults results)
        {
            if (item == null)
            {
                return;
            }

            //
            // populate the OrderCoupon item
            //
            int totalRecords = 0;
            bool totalRecordsExceeded = false;
            if (isCollectionOperation == true && isAddOperation == true)
            {
                totalRecords = 0;
                totalRecordsExceeded = false;
                BLL.SortableList<BLL.Orders.Order> itemOrderOrderID = null;
                if (useCollections != null && useCollections["Orders.Order"] != null)
                {
                    itemOrderOrderID = (BLL.SortableList<BLL.Orders.Order>)useCollections["Orders.Order"];
                }
                if (itemOrderOrderID == null || itemOrderOrderID.Count <= 0)
                {
                    itemOrderOrderID = BLL.Orders.OrderManager.GetManyOrderDataByCriteria(null, null, null, null, out totalRecords, out totalRecordsExceeded, Globals.getDataOptions("","",1,200,2000));
                    results.TotalRecords = totalRecords;
                    results.TotalRecordsExceeded = totalRecordsExceeded;
                }
                if (itemOrderOrderID.Count > 0)
                {
                    int index = TestHelper.GetInt(0, Math.Max(0, itemOrderOrderID.Count-1));
                    item.OrderID = itemOrderOrderID[index].OrderID;
                    item.DebitMetaPartnerID = itemOrderOrderID[index].DebitMetaPartnerID;
                }
                else
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "Could not find values for Order.", null);
                }
            }
            if (isCollectionOperation == true && isAddOperation == true)
            {
                totalRecords = 0;
                totalRecordsExceeded = false;
                BLL.SortableList<BLL.Promotions.MetaPartnerCoupon> itemMetaPartnerCouponMetaPartnerCouponID = null;
                if (useCollections != null && useCollections["Promotions.MetaPartnerCoupon"] != null)
                {
                    itemMetaPartnerCouponMetaPartnerCouponID = (BLL.SortableList<BLL.Promotions.MetaPartnerCoupon>)useCollections["Promotions.MetaPartnerCoupon"];
                }
                if (itemMetaPartnerCouponMetaPartnerCouponID == null || itemMetaPartnerCouponMetaPartnerCouponID.Count <= 0)
                {
                    itemMetaPartnerCouponMetaPartnerCouponID = BLL.Promotions.MetaPartnerCouponManager.GetManyMetaPartnerCouponDataByCriteria(null, null, null, null, null, out totalRecords, out totalRecordsExceeded, Globals.getDataOptions("","",1,200,2000));
                    results.TotalRecords = totalRecords;
                    results.TotalRecordsExceeded = totalRecordsExceeded;
                }
                if (itemMetaPartnerCouponMetaPartnerCouponID.Count > 0)
                {
                    int index = TestHelper.GetInt(0, Math.Max(0, itemMetaPartnerCouponMetaPartnerCouponID.Count-1));
                    item.MetaPartnerCouponID = itemMetaPartnerCouponMetaPartnerCouponID[index].MetaPartnerCouponID;
                    item.DebitMetaPartnerID = itemMetaPartnerCouponMetaPartnerCouponID[index].MetaPartnerID;
                }
                else
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "Could not find values for MetaPartnerCoupon.", null);
                }
            }
            if (isCollectionOperation == true && isAddOperation == true)
            {
                totalRecords = 0;
                totalRecordsExceeded = false;
                BLL.SortableList<BLL.Orders.Order> itemOrderDebitMetaPartnerID = null;
                if (useCollections != null && useCollections["Orders.Order"] != null)
                {
                    itemOrderDebitMetaPartnerID = (BLL.SortableList<BLL.Orders.Order>)useCollections["Orders.Order"];
                }
                if (itemOrderDebitMetaPartnerID == null || itemOrderDebitMetaPartnerID.Count <= 0)
                {
                    itemOrderDebitMetaPartnerID = BLL.Orders.OrderManager.GetManyOrderDataByCriteria(null, null, null, null, out totalRecords, out totalRecordsExceeded, Globals.getDataOptions("","",1,200,2000));
                    results.TotalRecords = totalRecords;
                    results.TotalRecordsExceeded = totalRecordsExceeded;
                }
                if (itemOrderDebitMetaPartnerID.Count > 0)
                {
                    int index = TestHelper.GetInt(0, Math.Max(0, itemOrderDebitMetaPartnerID.Count-1));
                    item.OrderID = itemOrderDebitMetaPartnerID[index].OrderID;
                    item.DebitMetaPartnerID = itemOrderDebitMetaPartnerID[index].DebitMetaPartnerID;
                }
                else
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "Could not find values for Order.", null);
                }
            }
            if (isCollectionOperation == true && isAddOperation == true)
            {
                totalRecords = 0;
                totalRecordsExceeded = false;
                BLL.SortableList<BLL.Promotions.MetaPartnerCoupon> itemMetaPartnerCouponDebitMetaPartnerID = null;
                if (useCollections != null && useCollections["Promotions.MetaPartnerCoupon"] != null)
                {
                    itemMetaPartnerCouponDebitMetaPartnerID = (BLL.SortableList<BLL.Promotions.MetaPartnerCoupon>)useCollections["Promotions.MetaPartnerCoupon"];
                }
                if (itemMetaPartnerCouponDebitMetaPartnerID == null || itemMetaPartnerCouponDebitMetaPartnerID.Count <= 0)
                {
                    itemMetaPartnerCouponDebitMetaPartnerID = BLL.Promotions.MetaPartnerCouponManager.GetManyMetaPartnerCouponDataByCriteria(null, null, null, null, null, out totalRecords, out totalRecordsExceeded, Globals.getDataOptions("","",1,200,2000));
                    results.TotalRecords = totalRecords;
                    results.TotalRecordsExceeded = totalRecordsExceeded;
                }
                if (itemMetaPartnerCouponDebitMetaPartnerID.Count > 0)
                {
                    int index = TestHelper.GetInt(0, Math.Max(0, itemMetaPartnerCouponDebitMetaPartnerID.Count-1));
                    item.MetaPartnerCouponID = itemMetaPartnerCouponDebitMetaPartnerID[index].MetaPartnerCouponID;
                    item.DebitMetaPartnerID = itemMetaPartnerCouponDebitMetaPartnerID[index].MetaPartnerID;
                }
                else
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "Could not find values for MetaPartnerCoupon.", null);
                }
            }
            PopulateItemCleanup(item, useCollections, performCascade, isAddOperation, isCollectionOperation, results);
        }
        #endregion Methods
    }
}