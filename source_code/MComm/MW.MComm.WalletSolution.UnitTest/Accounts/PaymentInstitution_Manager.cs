

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

namespace MW.MComm.WalletSolution.UnitTest.Accounts
{
    // ------------------------------------------------------------------------------
    /// <summary>This class contains support methods to test PaymentInstitution instances.</summary>
    ///
    /// File History:
    /// <created>7/31/2007 (Brian MacDonald)</created>
    ///
    /// <remarks></remarks>
    // ------------------------------------------------------------------------------
    public partial class PaymentInstitution_Manager
    {

		#region Properties
        #endregion Properties

        #region Constructors

        // ------------------------------------------------------------------------------
        /// <summary>This method is the constructor (currently does nothing).</summary>
        // ------------------------------------------------------------------------------
        public PaymentInstitution_Manager()
        {
            //
            // constructor logic
            //
        }

        #endregion Constructors

		#region Methods

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add PaymentInstitution items.</summary>
        // ------------------------------------------------------------------------------
        public static void PopulateItem(BLL.Accounts.PaymentInstitution item, MOD.Data.NamedObjectCollection useCollections, bool performCascade, bool isAddOperation, bool isCollectionOperation, MOD.Test.TestResults results)
        {
            if (item == null)
            {
                return;
            }

            //
            // populate the PaymentInstitution item
            //
            if (isAddOperation == true)
            {
                item.PaymentInstitutionCode = TestHelper.GetInt(null, null);
            }
            item.PaymentInstitutionName = TestHelper.GetString(null, 255);
            item.Description = TestHelper.GetString(null, 2000);
            item.IsActive = TestHelper.GetBool();
            PopulateItemCleanup(item, useCollections, performCascade, isAddOperation, isCollectionOperation, results);
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add PaymentInstitution items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Accounts.PaymentInstitution AddOnePaymentInstitutionTest(bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // add item
            //
            BLL.Accounts.PaymentInstitution item = new BLL.Accounts.PaymentInstitution();
            MOD.Data.NamedObjectCollection useCollections = new MOD.Data.NamedObjectCollection();
            BLL.SortableList<BLL.Accounts.PaymentInstitution> itemsAccountsPaymentInstitution = new BLL.SortableList<BLL.Accounts.PaymentInstitution>();
            itemsAccountsPaymentInstitution.Add((BLL.Accounts.PaymentInstitution)item);
            useCollections["Accounts.PaymentInstitution"] = itemsAccountsPaymentInstitution;
            PaymentInstitution_Manager.PopulateItem(item, useCollections, performCascade, true, false, results);
            results.IsCollision = false;
            try
            {
                BLL.Accounts.PaymentInstitution item2 = BLL.Accounts.PaymentInstitutionManager.GetOnePaymentInstitution(item.PaymentInstitutionCode);
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
                        BLL.Accounts.PaymentInstitutionManager.AddOnePaymentInstitution(item, performCascade);
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
        /// <summary>This method is used to update PaymentInstitution items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Accounts.PaymentInstitution UpdateOnePaymentInstitutionTest(int paymentInstitutionCode, bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get and update item
            //
            BLL.Accounts.PaymentInstitution item = new BLL.Accounts.PaymentInstitution();
            try
            {
                item = BLL.Accounts.PaymentInstitutionManager.GetOnePaymentInstitution(paymentInstitutionCode);
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
            BLL.SortableList<BLL.Accounts.PaymentInstitution> itemsAccountsPaymentInstitution = new BLL.SortableList<BLL.Accounts.PaymentInstitution>();
            itemsAccountsPaymentInstitution.Add((BLL.Accounts.PaymentInstitution)item);
            useCollections["Accounts.PaymentInstitution"] = itemsAccountsPaymentInstitution;
            PaymentInstitution_Manager.PopulateItem(item, useCollections, performCascade, false, false, results);
            try
            {
                if (IsValidForUpdate(item, performCascade, results) == true)
                {
                    startTicks = DateTime.Now.Ticks;
                    BLL.Accounts.PaymentInstitutionManager.UpdateOnePaymentInstitution(item, performCascade);
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
        /// <summary>This method is used to get PaymentInstitution items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.Accounts.PaymentInstitution> GetAllPaymentInstitutionDataTest(MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get all items
            //
            try
            {
                startTicks = DateTime.Now.Ticks;
                BLL.SortableList<BLL.Accounts.PaymentInstitution> items = BLL.Accounts.PaymentInstitutionManager.GetAllPaymentInstitutionData();
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
        /// <summary>This method is used to delete PaymentInstitution items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Accounts.PaymentInstitution DeleteOnePaymentInstitutionTest(int paymentInstitutionCode, bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get and delete item
            //
            BLL.Accounts.PaymentInstitution item = new BLL.Accounts.PaymentInstitution();
            try
            {
                item = BLL.Accounts.PaymentInstitutionManager.GetOnePaymentInstitution(paymentInstitutionCode);
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
                    BLL.Accounts.PaymentInstitutionManager.DeleteOnePaymentInstitution(item, performCascade);
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