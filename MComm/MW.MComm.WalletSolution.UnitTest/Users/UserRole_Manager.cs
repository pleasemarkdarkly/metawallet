

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

namespace MW.MComm.WalletSolution.UnitTest.Users
{
    // ------------------------------------------------------------------------------
    /// <summary>This class contains support methods to test UserRole instances.</summary>
    ///
    /// File History:
    /// <created>7/31/2007 (Brian MacDonald)</created>
    ///
    /// <remarks></remarks>
    // ------------------------------------------------------------------------------
    public partial class UserRole_Manager
    {

		#region Properties
        #endregion Properties

        #region Constructors

        // ------------------------------------------------------------------------------
        /// <summary>This method is the constructor (currently does nothing).</summary>
        // ------------------------------------------------------------------------------
        public UserRole_Manager()
        {
            //
            // constructor logic
            //
        }

        #endregion Constructors

		#region Methods

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add UserRole items.</summary>
        // ------------------------------------------------------------------------------
        public static void PopulateItem(BLL.Users.UserRole item, MOD.Data.NamedObjectCollection useCollections, bool performCascade, bool isAddOperation, bool isCollectionOperation, MOD.Test.TestResults results)
        {
            if (item == null)
            {
                return;
            }

            //
            // populate the UserRole item
            //
            if (isAddOperation == true)
            {
                item.UserRoleCode = TestHelper.GetInt(null, null);
            }
            item.UserRoleName = TestHelper.GetString(null, 255);
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
                item.UserRoleActivityList = new BLL.SortableList<BLL.Users.UserRoleActivity>();
                BLL.Users.UserRoleActivity vUserRoleActivityList = null;
                for (int j=0; j < collectionLoadCount; j++)
                {
                    vUserRoleActivityList = new BLL.Users.UserRoleActivity();
                    MW.MComm.WalletSolution.UnitTest.Users.UserRoleActivity_Manager.PopulateItem(vUserRoleActivityList, useCollections, false, true, true, results);
                    results.IsCollision = false;
                    foreach (BLL.Users.UserRoleActivity loopUserRoleActivity in item.UserRoleActivityList)
                    {
                        if (loopUserRoleActivity.PrimaryKey == vUserRoleActivityList.PrimaryKey)
                        {
                            Console.WriteLine("Collision in collection encountered for UserRoleActivity: " + vUserRoleActivityList.PrimaryKey.ToString());
                            results.IsCollision = true;
                            break;
                        }
                    }
                    if (results.IsCollision == false)
                    {
                        try
                        {
                            BLL.Users.UserRoleActivity item2 = BLL.Users.UserRoleActivityManager.GetOneUserRoleActivity(vUserRoleActivityList.UserRoleCode, vUserRoleActivityList.ActivityCode, vUserRoleActivityList.AccessModeCode);
                            if (item2 != null)
                            {
                                results.IsCollision = true;
                                Console.WriteLine("Add collision encountered for UserRoleActivity: " + item2.PrimaryKey.ToString());
                            }
                        }
                        catch (UnitTestException ex)
                        {
                            throw ex;
                        }
                        catch (System.Exception ex)
                        {
                            throw new UnitTestException(UnitTestErrorType.Warning, "Get failed for UserRoleActivity", ex);
                        }
                    }
                    if (results.IsCollision == false)
                    {
                        item.UserRoleActivityList.Add(vUserRoleActivityList);
                    }
                }
            }
            PopulateItemCleanup(item, useCollections, performCascade, isAddOperation, isCollectionOperation, results);
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add UserRole items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Users.UserRole AddOneUserRoleTest(bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // add item
            //
            BLL.Users.UserRole item = new BLL.Users.UserRole();
            MOD.Data.NamedObjectCollection useCollections = new MOD.Data.NamedObjectCollection();
            BLL.SortableList<BLL.Users.UserRole> itemsUsersUserRole = new BLL.SortableList<BLL.Users.UserRole>();
            itemsUsersUserRole.Add((BLL.Users.UserRole)item);
            useCollections["Users.UserRole"] = itemsUsersUserRole;
            UserRole_Manager.PopulateItem(item, useCollections, performCascade, true, false, results);
            results.IsCollision = false;
            try
            {
                BLL.Users.UserRole item2 = BLL.Users.UserRoleManager.GetOneUserRole(item.UserRoleCode);
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
                        BLL.Users.UserRoleManager.AddOneUserRole(item, performCascade);
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
        /// <summary>This method is used to update UserRole items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Users.UserRole UpdateOneUserRoleTest(int userRoleCode, bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get and update item
            //
            BLL.Users.UserRole item = new BLL.Users.UserRole();
            try
            {
                item = BLL.Users.UserRoleManager.GetOneUserRole(userRoleCode);
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
            BLL.SortableList<BLL.Users.UserRole> itemsUsersUserRole = new BLL.SortableList<BLL.Users.UserRole>();
            itemsUsersUserRole.Add((BLL.Users.UserRole)item);
            useCollections["Users.UserRole"] = itemsUsersUserRole;
            UserRole_Manager.PopulateItem(item, useCollections, performCascade, false, false, results);
            try
            {
                if (IsValidForUpdate(item, performCascade, results) == true)
                {
                    startTicks = DateTime.Now.Ticks;
                    BLL.Users.UserRoleManager.UpdateOneUserRole(item, performCascade);
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
        /// <summary>This method is used to get UserRole items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.Users.UserRole> GetAllUserRoleDataTest(MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get all items
            //
            try
            {
                startTicks = DateTime.Now.Ticks;
                BLL.SortableList<BLL.Users.UserRole> items = BLL.Users.UserRoleManager.GetAllUserRoleData();
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
        /// <summary>This method is used to delete UserRole items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Users.UserRole DeleteOneUserRoleTest(int userRoleCode, bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get and delete item
            //
            BLL.Users.UserRole item = new BLL.Users.UserRole();
            try
            {
                item = BLL.Users.UserRoleManager.GetOneUserRole(userRoleCode);
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
                    BLL.Users.UserRoleManager.DeleteOneUserRole(item, performCascade);
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