

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

namespace MW.MComm.WalletSolution.UnitTest.UserExperience
{
    // ------------------------------------------------------------------------------
    /// <summary>This class contains support methods to test FriendlyError instances.</summary>
    ///
    /// File History:
    /// <created>7/31/2007 (Brian MacDonald)</created>
    ///
    /// <remarks></remarks>
    // ------------------------------------------------------------------------------
    public partial class FriendlyError_Manager
    {

		#region Properties
        #endregion Properties

        #region Constructors

        // ------------------------------------------------------------------------------
        /// <summary>This method is the constructor (currently does nothing).</summary>
        // ------------------------------------------------------------------------------
        public FriendlyError_Manager()
        {
            //
            // constructor logic
            //
        }

        #endregion Constructors

		#region Methods

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add FriendlyError items.</summary>
        // ------------------------------------------------------------------------------
        public static void PopulateItem(BLL.UserExperience.FriendlyError item, MOD.Data.NamedObjectCollection useCollections, bool performCascade, bool isAddOperation, bool isCollectionOperation, MOD.Test.TestResults results)
        {
            if (item == null)
            {
                return;
            }

            //
            // populate the FriendlyError item
            //
            if (isAddOperation == true)
            {
                BLL.SortableList<BLL.Core.Error> itemErrorErrorNumber = null;
                if (useCollections != null && useCollections["Core.Error"] != null)
                {
                    itemErrorErrorNumber = (BLL.SortableList<BLL.Core.Error>)useCollections["Core.Error"];
                }
                if (itemErrorErrorNumber == null || itemErrorErrorNumber.Count <= 0)
                {
                    itemErrorErrorNumber = BLL.Core.ErrorManager.GetAllErrorData();
                }
                if (itemErrorErrorNumber.Count > 0)
                {
                    int index = TestHelper.GetInt(0, Math.Max(0, itemErrorErrorNumber.Count-1));
                    item.ErrorNumber = itemErrorErrorNumber[index].ErrorNumber;
                }
                else
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "Could not find values for Error.", null);
                }
            }
            if (isAddOperation == true)
            {
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
            }
            item.FriendlyErrorMessage = TestHelper.GetString(null, 2000);
            PopulateItemCleanup(item, useCollections, performCascade, isAddOperation, isCollectionOperation, results);
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add FriendlyError items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.UserExperience.FriendlyError AddOneFriendlyErrorTest(bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // add item
            //
            BLL.UserExperience.FriendlyError item = new BLL.UserExperience.FriendlyError();
            MOD.Data.NamedObjectCollection useCollections = new MOD.Data.NamedObjectCollection();
            BLL.SortableList<BLL.UserExperience.FriendlyError> itemsUserExperienceFriendlyError = new BLL.SortableList<BLL.UserExperience.FriendlyError>();
            itemsUserExperienceFriendlyError.Add((BLL.UserExperience.FriendlyError)item);
            useCollections["UserExperience.FriendlyError"] = itemsUserExperienceFriendlyError;
            FriendlyError_Manager.PopulateItem(item, useCollections, performCascade, true, false, results);
            results.IsCollision = false; // discard collection collisions
            BLL.UserExperience.FriendlyError item2 = null;
            try
            {
                item2 = BLL.UserExperience.FriendlyErrorManager.GetOneFriendlyError(item.ErrorNumber, item.LocaleCode);
            }
            catch (UnitTestException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw new UnitTestException(UnitTestErrorType.Warning, "Get failed for FriendlyError: " + item.PrimaryKey.ToString(), ex);
            }
            if (item2 != null)
            {
                results.IsCollision = true;
                throw new UnitTestException(UnitTestErrorType.Warning, "Add collision encountered for FriendlyError: " + item.PrimaryKey.ToString(), null);
            }
            if (results.IsCollision == false)
            {
                try
                {
                    if (IsValidForAdd(item, performCascade, results) == true)
                    {
                        startTicks = DateTime.Now.Ticks;
                        BLL.UserExperience.FriendlyErrorManager.AddOneFriendlyError(item, performCascade);
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
        /// <summary>This method is used to update FriendlyError items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.UserExperience.FriendlyError UpdateOneFriendlyErrorTest(int errorNumber, int localeCode, bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get and update item
            //
            BLL.UserExperience.FriendlyError item = new BLL.UserExperience.FriendlyError();
            try
            {
                item = BLL.UserExperience.FriendlyErrorManager.GetOneFriendlyError(errorNumber, localeCode);
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
            BLL.SortableList<BLL.UserExperience.FriendlyError> itemsUserExperienceFriendlyError = new BLL.SortableList<BLL.UserExperience.FriendlyError>();
            itemsUserExperienceFriendlyError.Add((BLL.UserExperience.FriendlyError)item);
            useCollections["UserExperience.FriendlyError"] = itemsUserExperienceFriendlyError;
            FriendlyError_Manager.PopulateItem(item, useCollections, performCascade, false, false, results);
            try
            {
                if (IsValidForUpdate(item, performCascade, results) == true)
                {
                    startTicks = DateTime.Now.Ticks;
                    BLL.UserExperience.FriendlyErrorManager.UpdateOneFriendlyError(item, performCascade);
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
        /// <summary>This method is used to get FriendlyError items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.UserExperience.FriendlyError> GetAllFriendlyErrorDataTest(MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get all items
            //
            try
            {
                startTicks = DateTime.Now.Ticks;
                BLL.SortableList<BLL.UserExperience.FriendlyError> items = BLL.UserExperience.FriendlyErrorManager.GetAllFriendlyErrorData();
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
        /// <summary>This method is used to get a set of FriendlyError items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.SortableList<BLL.UserExperience.FriendlyError> GetManyFriendlyErrorDataByCriteriaTest(MOD.Data.DataOptions dataOptions, MOD.Test.TestResults results)
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
                NamedObjectCollection nocLastModifiedDate = new NamedObjectCollection();
                startTicks = DateTime.Now.Ticks;
                BLL.SortableList<BLL.UserExperience.FriendlyError> items =  BLL.UserExperience.FriendlyErrorManager.GetManyFriendlyErrorDataByCriteria(null, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                BLL.SortableList<BLL.UserExperience.FriendlyError> specificItems = null;
                string specificWarnings = String.Empty;
                bool searchValueUsed = false;
                int paramCount = 0;
                if (items.Count < 1)
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "No items found in GetManyFriendlyErrorDataByCriteria generic search.", null);
                }
                paramCount = 0;
                foreach (BLL.UserExperience.FriendlyError item in items)
                {
                    nocLastModifiedDate[TestHelper.GetStringKeyFromObject((object)(item.LastModifiedDate), paramCount)] = item.LastModifiedDate;
                    paramCount++;
                }
                paramCount = 0;
                DateTime itemLastModifiedDate = TestHelper.GetDateTime(null, null, nocLastModifiedDate, 75, out searchValueUsed);
                startTicks = DateTime.Now.Ticks;
                specificItems =  BLL.UserExperience.FriendlyErrorManager.GetManyFriendlyErrorDataByCriteria(itemLastModifiedDate, null, out totalRecords, out totalRecordsExceeded, dataOptions);
                endTicks = DateTime.Now.Ticks;
                results.TotalRecords = totalRecords;
                results.TotalRecordsExceeded = totalRecordsExceeded;
                results.AddPerfMetric(TestHelper.GetSecondsFromTicks(endTicks - startTicks), null, String.Empty);
                if (specificItems.Count < 1 && searchValueUsed == true)
                {
                    specificWarnings += "\r\n" + "No items found in GetManyFriendlyErrorDataByCriteria search with LastModifiedDate = " + itemLastModifiedDate.ToString() + ".  Original search has " + items.Count.ToString() + " items.";
                }
                if (specificWarnings != String.Empty)
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "Results were not returned for GetManyFriendlyErrorDataByCriteria specific searches.", new Exception(specificWarnings));
                }
                return items;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to delete FriendlyError items.</summary>
        // ------------------------------------------------------------------------------
        public static BLL.UserExperience.FriendlyError DeleteOneFriendlyErrorTest(int errorNumber, int localeCode, bool performCascade, MOD.Test.TestResults results)
        {
            long startTicks = 0;
            long endTicks = 0;
            //
            // get and delete item
            //
            BLL.UserExperience.FriendlyError item = new BLL.UserExperience.FriendlyError();
            try
            {
                item = BLL.UserExperience.FriendlyErrorManager.GetOneFriendlyError(errorNumber, localeCode);
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
                    BLL.UserExperience.FriendlyErrorManager.DeleteOneFriendlyError(item, performCascade);
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