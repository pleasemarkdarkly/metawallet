

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

namespace MW.MComm.WalletSolution.UnitTest.Payments
{
    // ------------------------------------------------------------------------------
    /// <summary>This class contains support methods to test PaymentTransactionLog instances.</summary>
    ///
    /// File History:
    /// <created>7/31/2007 (Brian MacDonald)</created>
    ///
    /// <remarks></remarks>
    // ------------------------------------------------------------------------------
    public partial class PaymentTransactionLog_Manager
    {

		#region Properties
        #endregion Properties

        #region Constructors

        // ------------------------------------------------------------------------------
        /// <summary>This method is the constructor (currently does nothing).</summary>
        // ------------------------------------------------------------------------------
        public PaymentTransactionLog_Manager()
        {
            //
            // constructor logic
            //
        }

        #endregion Constructors

		#region Methods

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add PaymentTransactionLog items.</summary>
        // ------------------------------------------------------------------------------
        public static void PopulateItem(BLL.Payments.PaymentTransactionLog item, MOD.Data.NamedObjectCollection useCollections, bool performCascade, bool isAddOperation, bool isCollectionOperation, MOD.Test.TestResults results)
        {
            if (item == null)
            {
                return;
            }

            //
            // populate the PaymentTransactionLog item
            //
            int totalRecords = 0;
            bool totalRecordsExceeded = false;
            if (isAddOperation == true)
            {
                item.PaymentTransactionLogID = TestHelper.GetGuid();
            }
            totalRecords = 0;
            totalRecordsExceeded = false;
            BLL.SortableList<BLL.Payments.Payment> itemPaymentPaymentID = null;
            if (useCollections != null && useCollections["Payments.Payment"] != null)
            {
                itemPaymentPaymentID = (BLL.SortableList<BLL.Payments.Payment>)useCollections["Payments.Payment"];
            }
            if (itemPaymentPaymentID == null || itemPaymentPaymentID.Count <= 0)
            {
                itemPaymentPaymentID = BLL.Payments.PaymentManager.GetManyPaymentDataByCriteria(null, null, null, out totalRecords, out totalRecordsExceeded, Globals.getDataOptions("","",1,200,2000));
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
            }
            if (itemPaymentPaymentID.Count > 0)
            {
                int index = TestHelper.GetInt(0, Math.Max(0, itemPaymentPaymentID.Count-1));
                item.PaymentID = itemPaymentPaymentID[index].PaymentID;
            }
            else
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Could not find values for Payment.", null);
            }
            BLL.SortableList<BLL.Payments.TransactionType> itemTransactionTypeTransactionTypeCode = null;
            if (useCollections != null && useCollections["Payments.TransactionType"] != null)
            {
                itemTransactionTypeTransactionTypeCode = (BLL.SortableList<BLL.Payments.TransactionType>)useCollections["Payments.TransactionType"];
            }
            if (itemTransactionTypeTransactionTypeCode == null || itemTransactionTypeTransactionTypeCode.Count <= 0)
            {
                itemTransactionTypeTransactionTypeCode = BLL.Payments.TransactionTypeManager.GetAllTransactionTypeData();
            }
            if (itemTransactionTypeTransactionTypeCode.Count > 0)
            {
                int index = TestHelper.GetInt(0, Math.Max(0, itemTransactionTypeTransactionTypeCode.Count-1));
                item.TransactionTypeCode = itemTransactionTypeTransactionTypeCode[index].TransactionTypeCode;
            }
            else
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Could not find values for TransactionType.", null);
            }
            BLL.SortableList<BLL.Payments.TransactionStatus> itemTransactionStatusTransactionStatusCode = null;
            if (useCollections != null && useCollections["Payments.TransactionStatus"] != null)
            {
                itemTransactionStatusTransactionStatusCode = (BLL.SortableList<BLL.Payments.TransactionStatus>)useCollections["Payments.TransactionStatus"];
            }
            if (itemTransactionStatusTransactionStatusCode == null || itemTransactionStatusTransactionStatusCode.Count <= 0)
            {
                itemTransactionStatusTransactionStatusCode = BLL.Payments.TransactionStatusManager.GetAllTransactionStatusData();
            }
            if (itemTransactionStatusTransactionStatusCode.Count > 0)
            {
                int index = TestHelper.GetInt(0, Math.Max(0, itemTransactionStatusTransactionStatusCode.Count-1));
                item.TransactionStatusCode = itemTransactionStatusTransactionStatusCode[index].TransactionStatusCode;
            }
            else
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Could not find values for TransactionStatus.", null);
            }
            item.TransactionAmount = TestHelper.GetDecimal(-1000000, 1000000);
            item.ResponseCode = TestHelper.GetString(null, 25);
            item.TransactionCode = TestHelper.GetString(null, 25);
            item.TransactionMessage = TestHelper.GetString(null, 255);
            item.Balance = TestHelper.GetDecimal(-1000000, 1000000);

            //
            // collections
            //
            if (performCascade == true && isAddOperation == true)
            {
                int collectionLoadCount = 0;
                collectionLoadCount = TestHelper.GetInt(Globals.MinimumLoadCountPerCollection, Globals.MaximumLoadCountPerCollection);
                TestHelper.ReportValueToConsole("PopulateItem: Next collection load count", collectionLoadCount);
                item.PaymentTransactionAttributeValueLogList = new BLL.SortableList<BLL.Payments.PaymentTransactionAttributeValueLog>();
                BLL.Payments.PaymentTransactionAttributeValueLog vPaymentTransactionAttributeValueLogList = null;
                for (int j=0; j < collectionLoadCount; j++)
                {
                    vPaymentTransactionAttributeValueLogList = new BLL.Payments.PaymentTransactionAttributeValueLog();
                    MW.MComm.WalletSolution.UnitTest.Payments.PaymentTransactionAttributeValueLog_Manager.PopulateItem(vPaymentTransactionAttributeValueLogList, useCollections, false, true, true, results);
                    results.IsCollision = false;
                    try
                    {
                        BLL.Payments.PaymentTransactionAttributeValueLog item2 = BLL.Payments.PaymentTransactionAttributeValueLogManager.GetOnePaymentTransactionAttributeValueLog(vPaymentTransactionAttributeValueLogList.PaymentTransactionAttributeValueLogID);
                        if (item2 != null)
                        {
                            results.IsCollision = true;
                            Console.WriteLine("Add collision encountered for PaymentTransactionAttributeValueLog: " + item2.PrimaryKey.ToString());
                        }
                    }
                    catch (UnitTestException ex)
                    {
                        throw ex;
                    }
                    catch (System.Exception ex)
                    {
                        throw new UnitTestException(UnitTestErrorType.Warning, "Get failed for PaymentTransactionAttributeValueLog", ex);
                    }
                    if (results.IsCollision == false)
                    {
                        item.PaymentTransactionAttributeValueLogList.Add(vPaymentTransactionAttributeValueLogList);
                    }
                }
            }
            PopulateItemCleanup(item, useCollections, performCascade, isAddOperation, isCollectionOperation, results);
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add PaymentTransactionLog items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Payments.PaymentTransactionLog AddOnePaymentTransactionLogTest(bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // add item
            //
            BLL.Payments.PaymentTransactionLog item = new BLL.Payments.PaymentTransactionLog();
            MOD.Data.NamedObjectCollection useCollections = new MOD.Data.NamedObjectCollection();
            BLL.SortableList<BLL.Payments.PaymentTransactionLog> itemsPaymentsPaymentTransactionLog = new BLL.SortableList<BLL.Payments.PaymentTransactionLog>();
            itemsPaymentsPaymentTransactionLog.Add((BLL.Payments.PaymentTransactionLog)item);
            useCollections["Payments.PaymentTransactionLog"] = itemsPaymentsPaymentTransactionLog;
            PaymentTransactionLog_Manager.PopulateItem(item, useCollections, performCascade, true, false, results);
            results.IsCollision = false; // discard collection collisions
            BLL.Payments.PaymentTransactionLog item2 = null;
            try
            {
                item2 = BLL.Payments.PaymentTransactionLogManager.GetOnePaymentTransactionLog(item.PaymentTransactionLogID);
            }
            catch (UnitTestException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Get failed for PaymentTransactionLog: " + item.PrimaryKey.ToString(), ex);
            }
            if (item2 != null)
            {
                results.IsCollision = true;
                throw new UnitTestException(UnitTestErrorType.Warning, "Add collision encountered for PaymentTransactionLog: " + item.PrimaryKey.ToString(), null);
            }
            if (results.IsCollision == false)
            {
                try
                {
                    if (IsValidForAdd(item, performCascade, results) == true)
                    {
                        startTicks = DateTime.Now.Ticks;
                        BLL.Payments.PaymentTransactionLogManager.LogOnePaymentTransactionLog(item, performCascade);
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
        /// <summary>This method is used to get PaymentTransactionLog items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.Payments.PaymentTransactionLog> GetAllPaymentTransactionLogDataTest(MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get all items
            //
            try
            {
                startTicks = DateTime.Now.Ticks;
                BLL.SortableList<BLL.Payments.PaymentTransactionLog> items = BLL.Payments.PaymentTransactionLogManager.GetAllPaymentTransactionLogData();
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
        /// <summary>This method is used to get a set of PaymentTransactionLog items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.Payments.PaymentTransactionLog> GetManyPaymentTransactionLogDataByCriteriaTest(MOD.Data.DataOptions dataOptions, MOD.Test.TestResults results)
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
                NamedObjectCollection nocTransactionTypeCode = new NamedObjectCollection();
                NamedObjectCollection nocTransactionStatusCode = new NamedObjectCollection();
                NamedObjectCollection nocLastModifiedDate = new NamedObjectCollection();
                startTicks = DateTime.Now.Ticks;
                BLL.SortableList<BLL.Payments.PaymentTransactionLog> items =  BLL.Payments.PaymentTransactionLogManager.GetManyPaymentTransactionLogDataByCriteria(null, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                BLL.SortableList<BLL.Payments.PaymentTransactionLog> specificItems = null;
                string specificWarnings = String.Empty;
                bool searchValueUsed = false;
                int paramCount = 0;
                if (items.Count < 1)
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "No items found in GetManyPaymentTransactionLogDataByCriteria generic search.", null);
                }
                paramCount = 0;
                foreach (BLL.Payments.PaymentTransactionLog item in items)
                {
                    nocTransactionTypeCode[TestHelper.GetStringKeyFromObject((object)(item.TransactionTypeCode), paramCount)] = item.TransactionTypeCode;
                    nocTransactionStatusCode[TestHelper.GetStringKeyFromObject((object)(item.TransactionStatusCode), paramCount)] = item.TransactionStatusCode;
                    nocLastModifiedDate[TestHelper.GetStringKeyFromObject((object)(item.LastModifiedDate), paramCount)] = item.LastModifiedDate;
                    paramCount++;
                }
                paramCount = 0;
                int itemTransactionTypeCode = TestHelper.GetInt(null, null, nocTransactionTypeCode, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Payments.PaymentTransactionLogManager.GetManyPaymentTransactionLogDataByCriteria(itemTransactionTypeCode, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyPaymentTransactionLogDataByCriteria search with TransactionTypeCode = " + itemTransactionTypeCode.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                int itemTransactionStatusCode = TestHelper.GetInt(null, null, nocTransactionStatusCode, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Payments.PaymentTransactionLogManager.GetManyPaymentTransactionLogDataByCriteria(null, itemTransactionStatusCode, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyPaymentTransactionLogDataByCriteria search with TransactionStatusCode = " + itemTransactionStatusCode.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                DateTime itemLastModifiedDate = TestHelper.GetDateTime(null, null, nocLastModifiedDate, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Payments.PaymentTransactionLogManager.GetManyPaymentTransactionLogDataByCriteria(null, null, itemLastModifiedDate, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyPaymentTransactionLogDataByCriteria search with LastModifiedDate = " + itemLastModifiedDate.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                if (specificWarnings != String.Empty)
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "Results were not returned for GetManyPaymentTransactionLogDataByCriteria specific searches.", new Exception(specificWarnings));
                }
                return items;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        #endregion Methods
    }
}