

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
    /// <summary>This class contains support methods to test Order instances.</summary>
    ///
    /// File History:
    /// <created>7/31/2007 (Brian MacDonald)</created>
    ///
    /// <remarks></remarks>
    // ------------------------------------------------------------------------------
    public partial class Order_Manager
    {

		#region Properties
        #endregion Properties

        #region Constructors

        // ------------------------------------------------------------------------------
        /// <summary>This method is the constructor (currently does nothing).</summary>
        // ------------------------------------------------------------------------------
        public Order_Manager()
        {
            //
            // constructor logic
            //
        }

        #endregion Constructors

		#region Methods

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add Order items.</summary>
        // ------------------------------------------------------------------------------
        public static void PopulateItem(BLL.Orders.Order item, MOD.Data.NamedObjectCollection useCollections, bool performCascade, bool isAddOperation, bool isCollectionOperation, MOD.Test.TestResults results)
        {
            if (item == null)
            {
                return;
            }

            //
            // populate the Order item
            //
            int totalRecords = 0;
            bool totalRecordsExceeded = false;
            if (isAddOperation == true)
            {
                item.OrderID = TestHelper.GetGuid();
            }
            totalRecords = 0;
            totalRecordsExceeded = false;
            BLL.SortableList<BLL.Customers.MetaPartner> itemMetaPartnerDebitMetaPartnerID = null;
            if (useCollections != null && useCollections["Customers.MetaPartner"] != null)
            {
                itemMetaPartnerDebitMetaPartnerID = (BLL.SortableList<BLL.Customers.MetaPartner>)useCollections["Customers.MetaPartner"];
            }
            if (itemMetaPartnerDebitMetaPartnerID == null || itemMetaPartnerDebitMetaPartnerID.Count <= 0)
            {
                itemMetaPartnerDebitMetaPartnerID = BLL.Customers.MetaPartnerManager.GetManyMetaPartnerDataByCriteria(null, null, null, null, null, null, null, out totalRecords, out totalRecordsExceeded, Globals.getDataOptions("","",1,200,2000));
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
            }
            if (itemMetaPartnerDebitMetaPartnerID.Count > 0)
            {
                int index = TestHelper.GetInt(0, Math.Max(0, itemMetaPartnerDebitMetaPartnerID.Count-1));
                item.DebitMetaPartnerID = itemMetaPartnerDebitMetaPartnerID[index].MetaPartnerID;
            }
            else
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Could not find values for MetaPartner.", null);
            }
            if (isAddOperation == true)
            {
                totalRecords = 0;
                totalRecordsExceeded = false;
                BLL.SortableList<BLL.Accounts.Account> itemAccountCreditMetaPartnerID = null;
                if (useCollections != null && useCollections["Accounts.Account"] != null)
                {
                    itemAccountCreditMetaPartnerID = (BLL.SortableList<BLL.Accounts.Account>)useCollections["Accounts.Account"];
                }
                if (itemAccountCreditMetaPartnerID == null || itemAccountCreditMetaPartnerID.Count <= 0)
                {
                    itemAccountCreditMetaPartnerID = BLL.Accounts.AccountManager.GetManyAccountDataByCriteria(null, null, null, null, null, out totalRecords, out totalRecordsExceeded, Globals.getDataOptions("","",1,200,2000));
                    results.TotalRecords = totalRecords;
                    results.TotalRecordsExceeded = totalRecordsExceeded;
                }
                if (itemAccountCreditMetaPartnerID.Count > 0)
                {
                    int index = TestHelper.GetInt(0, Math.Max(0, itemAccountCreditMetaPartnerID.Count-1));
                    item.LogToAccountID = itemAccountCreditMetaPartnerID[index].AccountID;
                    item.CreditMetaPartnerID = itemAccountCreditMetaPartnerID[index].MetaPartnerID;
                }
                else
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "Could not find values for Account.", null);
                }
            }
            totalRecords = 0;
            totalRecordsExceeded = false;
            BLL.SortableList<BLL.Customers.MetaPartner> itemMetaPartnerCreditMetaPartnerID = null;
            if (useCollections != null && useCollections["Customers.MetaPartner"] != null)
            {
                itemMetaPartnerCreditMetaPartnerID = (BLL.SortableList<BLL.Customers.MetaPartner>)useCollections["Customers.MetaPartner"];
            }
            if (itemMetaPartnerCreditMetaPartnerID == null || itemMetaPartnerCreditMetaPartnerID.Count <= 0)
            {
                itemMetaPartnerCreditMetaPartnerID = BLL.Customers.MetaPartnerManager.GetManyMetaPartnerDataByCriteria(null, null, null, null, null, null, null, out totalRecords, out totalRecordsExceeded, Globals.getDataOptions("","",1,200,2000));
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
            }
            if (itemMetaPartnerCreditMetaPartnerID.Count > 0)
            {
                int index = TestHelper.GetInt(0, Math.Max(0, itemMetaPartnerCreditMetaPartnerID.Count-1));
                item.CreditMetaPartnerID = itemMetaPartnerCreditMetaPartnerID[index].MetaPartnerID;
            }
            else
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Could not find values for MetaPartner.", null);
            }
            if (isAddOperation == true)
            {
                totalRecords = 0;
                totalRecordsExceeded = false;
                BLL.SortableList<BLL.Accounts.Account> itemAccountLogToAccountID = null;
                if (useCollections != null && useCollections["Accounts.Account"] != null)
                {
                    itemAccountLogToAccountID = (BLL.SortableList<BLL.Accounts.Account>)useCollections["Accounts.Account"];
                }
                if (itemAccountLogToAccountID == null || itemAccountLogToAccountID.Count <= 0)
                {
                    itemAccountLogToAccountID = BLL.Accounts.AccountManager.GetManyAccountDataByCriteria(null, null, null, null, null, out totalRecords, out totalRecordsExceeded, Globals.getDataOptions("","",1,200,2000));
                    results.TotalRecords = totalRecords;
                    results.TotalRecordsExceeded = totalRecordsExceeded;
                }
                if (itemAccountLogToAccountID.Count > 0)
                {
                    int index = TestHelper.GetInt(0, Math.Max(0, itemAccountLogToAccountID.Count-1));
                    item.LogToAccountID = itemAccountLogToAccountID[index].AccountID;
                    item.CreditMetaPartnerID = itemAccountLogToAccountID[index].MetaPartnerID;
                }
                else
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "Could not find values for Account.", null);
                }
            }
            item.OrderDescription = TestHelper.GetString(null, 2000);
            item.OrderAmount = TestHelper.GetDecimal(-1000000, 1000000);
            item.OrderSubtotal = TestHelper.GetDecimal(-1000000, 1000000);
            item.OrderTax = TestHelper.GetDecimal(-1000000, 1000000);
            item.OrderServiceCharge = TestHelper.GetDecimal(-1000000, 1000000);
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
            BLL.SortableList<BLL.Orders.OrderStatus> itemOrderStatusOrderStatusCode = null;
            if (useCollections != null && useCollections["Orders.OrderStatus"] != null)
            {
                itemOrderStatusOrderStatusCode = (BLL.SortableList<BLL.Orders.OrderStatus>)useCollections["Orders.OrderStatus"];
            }
            if (itemOrderStatusOrderStatusCode == null || itemOrderStatusOrderStatusCode.Count <= 0)
            {
                itemOrderStatusOrderStatusCode = BLL.Orders.OrderStatusManager.GetAllOrderStatusData();
            }
            if (itemOrderStatusOrderStatusCode.Count > 0)
            {
                int index = TestHelper.GetInt(0, Math.Max(0, itemOrderStatusOrderStatusCode.Count-1));
                item.OrderStatusCode = itemOrderStatusOrderStatusCode[index].OrderStatusCode;
            }
            else
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Could not find values for OrderStatus.", null);
            }
            item.OrderStatusMessage = TestHelper.GetString(null, 1000);

            //
            // collections
            //
            if (performCascade == true && isAddOperation == true)
            {
                int collectionLoadCount = 0;
                collectionLoadCount = TestHelper.GetInt(Globals.MinimumLoadCountPerCollection, Globals.MaximumLoadCountPerCollection);
                TestHelper.ReportValueToConsole("PopulateItem: Next collection load count", collectionLoadCount);
                item.PaymentList = new BLL.SortableList<BLL.Payments.Payment>();
                BLL.Payments.Payment vPaymentList = null;
                for (int j=0; j < collectionLoadCount; j++)
                {
                    vPaymentList = new BLL.Payments.Payment();
                    MW.MComm.WalletSolution.UnitTest.Payments.Payment_Manager.PopulateItem(vPaymentList, useCollections, false, true, true, results);
                    results.IsCollision = false;
                    try
                    {
                        BLL.Payments.Payment item2 = BLL.Payments.PaymentManager.GetOnePayment(vPaymentList.PaymentID);
                        if (item2 != null)
                        {
                            results.IsCollision = true;
                            Console.WriteLine("Add collision encountered for Payment: " + item2.PrimaryKey.ToString());
                        }
                    }
                    catch (UnitTestException ex)
                    {
                        throw ex;
                    }
                    catch (System.Exception ex)
                    {
                        throw new UnitTestException(UnitTestErrorType.Warning, "Get failed for Payment", ex);
                    }
                    if (results.IsCollision == false)
                    {
                        item.PaymentList.Add(vPaymentList);
                    }
                }
                collectionLoadCount = TestHelper.GetInt(Globals.MinimumLoadCountPerCollection, Globals.MaximumLoadCountPerCollection);
                TestHelper.ReportValueToConsole("PopulateItem: Next collection load count", collectionLoadCount);
                item.OrderCouponList = new BLL.SortableList<BLL.Orders.OrderCoupon>();
                BLL.Orders.OrderCoupon vOrderCouponList = null;
                for (int j=0; j < collectionLoadCount; j++)
                {
                    vOrderCouponList = new BLL.Orders.OrderCoupon();
                    MW.MComm.WalletSolution.UnitTest.Orders.OrderCoupon_Manager.PopulateItem(vOrderCouponList, useCollections, false, true, true, results);
                    results.IsCollision = false;
                    foreach (BLL.Orders.OrderCoupon loopOrderCoupon in item.OrderCouponList)
                    {
                        if (loopOrderCoupon.PrimaryKey == vOrderCouponList.PrimaryKey)
                        {
                            Console.WriteLine("Collision in collection encountered for OrderCoupon: " + vOrderCouponList.PrimaryKey.ToString());
                            results.IsCollision = true;
                            break;
                        }
                    }
                    if (results.IsCollision == false)
                    {
                        try
                        {
                            BLL.Orders.OrderCoupon item2 = BLL.Orders.OrderCouponManager.GetOneOrderCoupon(vOrderCouponList.OrderID, vOrderCouponList.MetaPartnerCouponID, vOrderCouponList.DebitMetaPartnerID);
                            if (item2 != null)
                            {
                                results.IsCollision = true;
                                Console.WriteLine("Add collision encountered for OrderCoupon: " + item2.PrimaryKey.ToString());
                            }
                        }
                        catch (UnitTestException ex)
                        {
                            throw ex;
                        }
                        catch (System.Exception ex)
                        {
                            throw new UnitTestException(UnitTestErrorType.Warning, "Get failed for OrderCoupon", ex);
                        }
                    }
                    if (results.IsCollision == false)
                    {
                        item.OrderCouponList.Add(vOrderCouponList);
                    }
                }
                collectionLoadCount = TestHelper.GetInt(Globals.MinimumLoadCountPerCollection, Globals.MaximumLoadCountPerCollection);
                TestHelper.ReportValueToConsole("PopulateItem: Next collection load count", collectionLoadCount);
                item.OrderFeeList = new BLL.SortableList<BLL.Orders.OrderFee>();
                BLL.Orders.OrderFee vOrderFeeList = null;
                for (int j=0; j < collectionLoadCount; j++)
                {
                    vOrderFeeList = new BLL.Orders.OrderFee();
                    MW.MComm.WalletSolution.UnitTest.Orders.OrderFee_Manager.PopulateItem(vOrderFeeList, useCollections, false, true, true, results);
                    results.IsCollision = false;
                    foreach (BLL.Orders.OrderFee loopOrderFee in item.OrderFeeList)
                    {
                        if (loopOrderFee.PrimaryKey == vOrderFeeList.PrimaryKey)
                        {
                            Console.WriteLine("Collision in collection encountered for OrderFee: " + vOrderFeeList.PrimaryKey.ToString());
                            results.IsCollision = true;
                            break;
                        }
                    }
                    if (results.IsCollision == false)
                    {
                        try
                        {
                            BLL.Orders.OrderFee item2 = BLL.Orders.OrderFeeManager.GetOneOrderFee(vOrderFeeList.OrderID, vOrderFeeList.FeeCode);
                            if (item2 != null)
                            {
                                results.IsCollision = true;
                                Console.WriteLine("Add collision encountered for OrderFee: " + item2.PrimaryKey.ToString());
                            }
                        }
                        catch (UnitTestException ex)
                        {
                            throw ex;
                        }
                        catch (System.Exception ex)
                        {
                            throw new UnitTestException(UnitTestErrorType.Warning, "Get failed for OrderFee", ex);
                        }
                    }
                    if (results.IsCollision == false)
                    {
                        item.OrderFeeList.Add(vOrderFeeList);
                    }
                }
            }
            PopulateItemCleanup(item, useCollections, performCascade, isAddOperation, isCollectionOperation, results);
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add Order items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Orders.Order AddOneOrderTest(bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // add item
            //
            BLL.Orders.Order item = new BLL.Orders.Order();
            MOD.Data.NamedObjectCollection useCollections = new MOD.Data.NamedObjectCollection();
            BLL.SortableList<BLL.Orders.Order> itemsOrdersOrder = new BLL.SortableList<BLL.Orders.Order>();
            itemsOrdersOrder.Add((BLL.Orders.Order)item);
            useCollections["Orders.Order"] = itemsOrdersOrder;
            Order_Manager.PopulateItem(item, useCollections, performCascade, true, false, results);
            results.IsCollision = false; // discard collection collisions
            BLL.Orders.Order item2 = null;
            try
            {
                item2 = BLL.Orders.OrderManager.GetOneOrder(item.OrderID);
            }
            catch (UnitTestException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Get failed for Order: " + item.PrimaryKey.ToString(), ex);
            }
            if (item2 != null)
            {
                results.IsCollision = true;
                throw new UnitTestException(UnitTestErrorType.Warning, "Add collision encountered for Order: " + item.PrimaryKey.ToString(), null);
            }
            if (results.IsCollision == false)
            {
                try
                {
                    if (IsValidForAdd(item, performCascade, results) == true)
                    {
                        startTicks = DateTime.Now.Ticks;
                        BLL.Orders.OrderManager.UpsertOneOrder(item, performCascade);
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
        /// <summary>This method is used to update Order items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Orders.Order UpdateOneOrderTest(Guid orderID, bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get and update item
            //
            BLL.Orders.Order item = new BLL.Orders.Order();
            try
            {
                item = BLL.Orders.OrderManager.GetOneOrder(orderID);
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
            BLL.SortableList<BLL.Orders.Order> itemsOrdersOrder = new BLL.SortableList<BLL.Orders.Order>();
            itemsOrdersOrder.Add((BLL.Orders.Order)item);
            useCollections["Orders.Order"] = itemsOrdersOrder;
            Order_Manager.PopulateItem(item, useCollections, performCascade, false, false, results);
            try
            {
                if (IsValidForUpdate(item, performCascade, results) == true)
                {
                    startTicks = DateTime.Now.Ticks;
                    BLL.Orders.OrderManager.UpsertOneOrder(item, performCascade);
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
        /// <summary>This method is used to get Order items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.Orders.Order> GetAllOrderDataTest(MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get all items
            //
            try
            {
                startTicks = DateTime.Now.Ticks;
                BLL.SortableList<BLL.Orders.Order> items = BLL.Orders.OrderManager.GetAllOrderData();
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
        /// <summary>This method is used to get a set of Order items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.Orders.Order> GetManyOrderDataByCriteriaTest(MOD.Data.DataOptions dataOptions, MOD.Test.TestResults results)
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
                NamedObjectCollection nocCurrencyCode = new NamedObjectCollection();
                NamedObjectCollection nocOrderStatusCode = new NamedObjectCollection();
                NamedObjectCollection nocLastModifiedDate = new NamedObjectCollection();
                startTicks = DateTime.Now.Ticks;
                BLL.SortableList<BLL.Orders.Order> items =  BLL.Orders.OrderManager.GetManyOrderDataByCriteria(null, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                BLL.SortableList<BLL.Orders.Order> specificItems = null;
                string specificWarnings = String.Empty;
                bool searchValueUsed = false;
                int paramCount = 0;
                if (items.Count < 1)
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "No items found in GetManyOrderDataByCriteria generic search.", null);
                }
                paramCount = 0;
                foreach (BLL.Orders.Order item in items)
                {
                    nocCurrencyCode[TestHelper.GetStringKeyFromObject((object)(item.CurrencyCode), paramCount)] = item.CurrencyCode;
                    nocOrderStatusCode[TestHelper.GetStringKeyFromObject((object)(item.OrderStatusCode), paramCount)] = item.OrderStatusCode;
                    nocLastModifiedDate[TestHelper.GetStringKeyFromObject((object)(item.LastModifiedDate), paramCount)] = item.LastModifiedDate;
                    paramCount++;
                }
                paramCount = 0;
                int itemCurrencyCode = TestHelper.GetInt(null, null, nocCurrencyCode, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Orders.OrderManager.GetManyOrderDataByCriteria(itemCurrencyCode, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyOrderDataByCriteria search with CurrencyCode = " + itemCurrencyCode.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                int itemOrderStatusCode = TestHelper.GetInt(null, null, nocOrderStatusCode, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Orders.OrderManager.GetManyOrderDataByCriteria(null, itemOrderStatusCode, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyOrderDataByCriteria search with OrderStatusCode = " + itemOrderStatusCode.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                DateTime itemLastModifiedDate = TestHelper.GetDateTime(null, null, nocLastModifiedDate, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Orders.OrderManager.GetManyOrderDataByCriteria(null, null, itemLastModifiedDate, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyOrderDataByCriteria search with LastModifiedDate = " + itemLastModifiedDate.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                if (specificWarnings != String.Empty)
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "Results were not returned for GetManyOrderDataByCriteria specific searches.", new Exception(specificWarnings));
                }
                return items;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to delete Order items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Orders.Order DeleteOneOrderTest(Guid orderID, bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get and delete item
            //
            BLL.Orders.Order item = new BLL.Orders.Order();
            try
            {
                item = BLL.Orders.OrderManager.GetOneOrder(orderID);
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
                    BLL.Orders.OrderManager.DeleteOneOrder(item, performCascade);
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