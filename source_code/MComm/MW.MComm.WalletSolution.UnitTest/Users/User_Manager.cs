

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
    /// <summary>This class contains support methods to test User instances.</summary>
    ///
    /// File History:
    /// <created>7/31/2007 (Brian MacDonald)</created>
    ///
    /// <remarks></remarks>
    // ------------------------------------------------------------------------------
    public partial class User_Manager
    {

		#region Properties
        #endregion Properties

        #region Constructors

        // ------------------------------------------------------------------------------
        /// <summary>This method is the constructor (currently does nothing).</summary>
        // ------------------------------------------------------------------------------
        public User_Manager()
        {
            //
            // constructor logic
            //
        }

        #endregion Constructors

		#region Methods

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add User items.</summary>
        // ------------------------------------------------------------------------------
        public static void PopulateItem(BLL.Users.User item, MOD.Data.NamedObjectCollection useCollections, bool performCascade, bool isAddOperation, bool isCollectionOperation, MOD.Test.TestResults results)
        {
            if (item == null)
            {
                return;
            }

            //
            // populate the User item
            //
            if (isAddOperation == true)
            {
                item.UserID = TestHelper.GetGuid();
            }
            item.UserName = TestHelper.GetString(null, 50);
            item.FirstName = TestHelper.GetString(null, 100);
            item.LastName = TestHelper.GetString(null, 100);
            item.Password = TestHelper.GetString(null, 100);
            BLL.SortableList<BLL.Environments.Locale> itemLocaleLocaleCode = null;
            if (useCollections != null && useCollections["Environments.Locale"] != null)
            {
                itemLocaleLocaleCode = (BLL.SortableList<BLL.Environments.Locale>)useCollections["Environments.Locale"];
            }
            if (itemLocaleLocaleCode == null || itemLocaleLocaleCode.Count <= 0)
            {
                itemLocaleLocaleCode = BLL.Environments.LocaleManager.GetAllLocaleData();
            }
            if (itemLocaleLocaleCode.Count > 0)
            {
                int index = TestHelper.GetInt(0, Math.Max(0, itemLocaleLocaleCode.Count-1));
                item.LocaleCode = itemLocaleLocaleCode[index].LocaleCode;
            }
            else
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Could not find values for Locale.", null);
            }
            item.IsActive = TestHelper.GetBool();

            //
            // collections
            //
            if (performCascade == true && isAddOperation == true)
            {
                int collectionLoadCount = 0;
                collectionLoadCount = TestHelper.GetInt(Globals.MinimumLoadCountPerCollection, Globals.MaximumLoadCountPerCollection);
                TestHelper.ReportValueToConsole("PopulateItem: Next collection load count", collectionLoadCount);
                item.UserRoleUserList = new BLL.SortableList<BLL.Users.UserRoleUser>();
                BLL.Users.UserRoleUser vUserRoleUserList = null;
                for (int j=0; j < collectionLoadCount; j++)
                {
                    vUserRoleUserList = new BLL.Users.UserRoleUser();
                    MW.MComm.WalletSolution.UnitTest.Users.UserRoleUser_Manager.PopulateItem(vUserRoleUserList, useCollections, false, true, true, results);
                    results.IsCollision = false;
                    foreach (BLL.Users.UserRoleUser loopUserRoleUser in item.UserRoleUserList)
                    {
                        if (loopUserRoleUser.PrimaryKey == vUserRoleUserList.PrimaryKey)
                        {
                            Console.WriteLine("Collision in collection encountered for UserRoleUser: " + vUserRoleUserList.PrimaryKey.ToString());
                            results.IsCollision = true;
                            break;
                        }
                    }
                    if (results.IsCollision == false)
                    {
                        try
                        {
                            BLL.Users.UserRoleUser item2 = BLL.Users.UserRoleUserManager.GetOneUserRoleUser(vUserRoleUserList.UserRoleCode, vUserRoleUserList.UserID);
                            if (item2 != null)
                            {
                                results.IsCollision = true;
                                Console.WriteLine("Add collision encountered for UserRoleUser: " + item2.PrimaryKey.ToString());
                            }
                        }
                        catch (UnitTestException ex)
                        {
                            throw ex;
                        }
                        catch (System.Exception ex)
                        {
                            throw new UnitTestException(UnitTestErrorType.Warning, "Get failed for UserRoleUser", ex);
                        }
                    }
                    if (results.IsCollision == false)
                    {
                        item.UserRoleUserList.Add(vUserRoleUserList);
                    }
                }
            }
            PopulateItemCleanup(item, useCollections, performCascade, isAddOperation, isCollectionOperation, results);
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add User items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Users.User AddOneUserTest(bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // add item
            //
            BLL.Users.User item = new BLL.Users.User();
            MOD.Data.NamedObjectCollection useCollections = new MOD.Data.NamedObjectCollection();
            BLL.SortableList<BLL.Users.User> itemsUsersUser = new BLL.SortableList<BLL.Users.User>();
            itemsUsersUser.Add((BLL.Users.User)item);
            useCollections["Users.User"] = itemsUsersUser;
            User_Manager.PopulateItem(item, useCollections, performCascade, true, false, results);
            results.IsCollision = false; // discard collection collisions
            BLL.Users.User item2 = null;
            try
            {
                item2 = BLL.Users.UserManager.GetOneUser(item.UserID);
            }
            catch (UnitTestException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Get failed for User: " + item.PrimaryKey.ToString(), ex);
            }
            if (item2 != null)
            {
                results.IsCollision = true;
                throw new UnitTestException(UnitTestErrorType.Warning, "Add collision encountered for User: " + item.PrimaryKey.ToString(), null);
            }
            if (results.IsCollision == false)
            {
                try
                {
                    if (IsValidForAdd(item, performCascade, results) == true)
                    {
                        startTicks = DateTime.Now.Ticks;
                        BLL.Users.UserManager.UpsertOneUser(item, performCascade);
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
        /// <summary>This method is used to update User items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Users.User UpdateOneUserTest(Guid userID, bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get and update item
            //
            BLL.Users.User item = new BLL.Users.User();
            try
            {
                item = BLL.Users.UserManager.GetOneUser(userID);
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
            BLL.SortableList<BLL.Users.User> itemsUsersUser = new BLL.SortableList<BLL.Users.User>();
            itemsUsersUser.Add((BLL.Users.User)item);
            useCollections["Users.User"] = itemsUsersUser;
            User_Manager.PopulateItem(item, useCollections, performCascade, false, false, results);
            try
            {
                if (IsValidForUpdate(item, performCascade, results) == true)
                {
                    startTicks = DateTime.Now.Ticks;
                    BLL.Users.UserManager.UpsertOneUser(item, performCascade);
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
        /// <summary>This method is used to get User items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.Users.User> GetAllUserDataTest(MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get all items
            //
            try
            {
                startTicks = DateTime.Now.Ticks;
                BLL.SortableList<BLL.Users.User> items = BLL.Users.UserManager.GetAllUserData();
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
        /// <summary>This method is used to get a set of User items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.Users.User> GetManyUserDataByCriteriaTest(MOD.Data.DataOptions dataOptions, MOD.Test.TestResults results)
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
                NamedObjectCollection nocUserName = new NamedObjectCollection();
                NamedObjectCollection nocFirstName = new NamedObjectCollection();
                NamedObjectCollection nocLastName = new NamedObjectCollection();
                NamedObjectCollection nocLocaleCode = new NamedObjectCollection();
                NamedObjectCollection nocLastModifiedDate = new NamedObjectCollection();
                startTicks = DateTime.Now.Ticks;
                BLL.SortableList<BLL.Users.User> items =  BLL.Users.UserManager.GetManyUserDataByCriteria(null, null, null, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                BLL.SortableList<BLL.Users.User> specificItems = null;
                string specificWarnings = String.Empty;
                bool searchValueUsed = false;
                int paramCount = 0;
                if (items.Count < 1)
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "No items found in GetManyUserDataByCriteria generic search.", null);
                }
                paramCount = 0;
                foreach (BLL.Users.User item in items)
                {
                    nocUserName[TestHelper.GetStringKeyFromObject((object)(item.UserName), paramCount)] = item.UserName;
                    nocFirstName[TestHelper.GetStringKeyFromObject((object)(item.FirstName), paramCount)] = item.FirstName;
                    nocLastName[TestHelper.GetStringKeyFromObject((object)(item.LastName), paramCount)] = item.LastName;
                    nocLocaleCode[TestHelper.GetStringKeyFromObject((object)(item.LocaleCode), paramCount)] = item.LocaleCode;
                    nocLastModifiedDate[TestHelper.GetStringKeyFromObject((object)(item.LastModifiedDate), paramCount)] = item.LastModifiedDate;
                    paramCount++;
                }
                paramCount = 0;
                string itemUserName = TestHelper.GetString(null, 50, nocUserName, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Users.UserManager.GetManyUserDataByCriteria(itemUserName, null, null, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyUserDataByCriteria search with UserName = " + itemUserName.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                string itemFirstName = TestHelper.GetString(null, 100, nocFirstName, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Users.UserManager.GetManyUserDataByCriteria(null, itemFirstName, null, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyUserDataByCriteria search with FirstName = " + itemFirstName.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                string itemLastName = TestHelper.GetString(null, 100, nocLastName, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Users.UserManager.GetManyUserDataByCriteria(null, null, itemLastName, null, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyUserDataByCriteria search with LastName = " + itemLastName.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                int itemLocaleCode = TestHelper.GetInt(null, null, nocLocaleCode, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Users.UserManager.GetManyUserDataByCriteria(null, null, null, itemLocaleCode, null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyUserDataByCriteria search with LocaleCode = " + itemLocaleCode.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                DateTime itemLastModifiedDate = TestHelper.GetDateTime(null, null, nocLastModifiedDate, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.Users.UserManager.GetManyUserDataByCriteria(null, null, null, null, itemLastModifiedDate, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyUserDataByCriteria search with LastModifiedDate = " + itemLastModifiedDate.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                if (specificWarnings != String.Empty)
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "Results were not returned for GetManyUserDataByCriteria specific searches.", new Exception(specificWarnings));
                }
                return items;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to delete User items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.Users.User DeleteOneUserTest(Guid userID, bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get and delete item
            //
            BLL.Users.User item = new BLL.Users.User();
            try
            {
                item = BLL.Users.UserManager.GetOneUser(userID);
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
                    BLL.Users.UserManager.DeleteOneUser(item, performCascade);
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