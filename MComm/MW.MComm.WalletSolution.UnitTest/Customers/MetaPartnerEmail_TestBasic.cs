

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
using MW.MComm.WalletSolution.UnitTest.Customers;
using BLL = MW.MComm.WalletSolution.BLL;
using Utility = MW.MComm.WalletSolution.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace MW.MComm.WalletSolution.UnitTest.Customers
{
    // ------------------------------------------------------------------------------
    /// <summary>This class is used to run BLL method tests for MetaPartnerEmail instances.</summary>
    ///
    /// File History:
    /// <created>7/31/2007 (Brian MacDonald)</created>
    ///
    /// <remarks></remarks>
    // ------------------------------------------------------------------------------
    [TestFixture, FixtureCategory("Basic.Customers"), Author("Common"), Importance(TestImportance.Serious), TestsOn(typeof(BLL.Customers.MetaPartnerEmail))]
    public partial class MetaPartnerEmail_TestBasic : BaseUnitTest
    {

        #region Fields
        #endregion Fields

        #region Properties
        #endregion Properties

        #region Constructors

        // ------------------------------------------------------------------------------
        /// <summary>This method is the constructor, initializes unit test info and status.</summary>
        // ------------------------------------------------------------------------------
        public MetaPartnerEmail_TestBasic() : base()
        {
        }

        #endregion Constructors

        #region Methods
        [SetUp]
        public void Init()
        {
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is the basic entity test for MetaPartnerEmail.</summary>
        // ------------------------------------------------------------------------------
        [Test]
        public void Customers_MetaPartnerEmail_BasicTest()
        {
            try
            {
                // This is required to allow the application to provide default data options
                BLL.BusinessObjectManager.Initialize(new Globals());

                if (Globals.RunPrimaryEntityTests == false)
                    return;

                Console.WriteLine("******************** Customers_MetaPartnerEmail_BasicTest START ********************");
                Console.WriteLine("Automation framework check - Is MbUnit running? : " + IsMbUnitRunning.ToString());

                if (Globals.IsUnitTestConfiguration == false)
                {
                    UpdateUnitTestErrorInfo(UnitTestErrorType.Warning, "Basic Entity tests can only be run against a unit test database.", null, null, null);
                    return;
                }
                

                string itemStr = String.Empty;

                // Validate BLL BusinessObjectManager initialization
                try
                {
                    DatabaseOptions dbOptions = BLL.BusinessObjectManager.DBOptions;
                    int debugLevel = BLL.BusinessObjectManager.DebugLevel;
                    Guid applicationUserId = BLL.BusinessObjectManager.ApplicationUserID;
                }
                catch (Exception ex)
                {
                    UpdateUnitTestErrorInfo(UnitTestErrorType.Functional, "BLL.BusinessObjectManager not properly initialized.", null, ex, null);
                    FailureLevel = UnitTestFailureLevel.Abort;
                    throw new Exception();
                }

                SortableObjectCollection idList = new SortableObjectCollection();

                // Validating SortableObjectCollection creation
                bool bIdList_valid = (idList != null);
                if (!bIdList_valid)
                {
                    UpdateUnitTestErrorInfo(UnitTestErrorType.Functional, "MOD.Data.SortableObjectCollection is null.", null, null, null);
                    FailureLevel = UnitTestFailureLevel.Abort;
                    throw new Exception();
                }

                BLL.Customers.MetaPartnerEmail item = null;
                int currentTicks = (int)DateTime.Now.Ticks;
                TestHelper.ReportValueToConsole("Customers_MetaPartnerEmail_BasicTest: Value generation method: Random seed -- Current ticks", currentTicks.ToString());
                TestHelper.SeedRandom(currentTicks);

                int loadCount = TestHelper.GetInt(Globals.MinimumLoadCountPerEntity, Globals.MaximumLoadCountPerEntity);
                TestHelper.ReportValueToConsole("Customers_MetaPartnerEmail_BasicTest: Next entity add load count", loadCount.ToString());
                int collectionLoadCount = TestHelper.GetInt(Globals.MinimumLoadCountPerCollection, Globals.MaximumLoadCountPerCollection);
                TestHelper.ReportValueToConsole("Assets_AlbumEntityTest: Next collection load count", collectionLoadCount.ToString());
                //bool isCollision = false;
                bool performCascade = Globals.RunCollectionTests;

                //
                // add items
                //
                TestHelper.ReportValueToConsole("Customers_MetaPartnerEmail_BasicTest: Add MetaPartnerEmail count", loadCount.ToString());
                for (int i=0; i < loadCount; i++)
                {
                    Results.IsCollision = false;
                    try
                    {
                        item = MetaPartnerEmail_Manager.AddOneMetaPartnerEmailTest(true, Results);
                        if (Results.IsCollision == true)
                        {
                            throw new UnitTestException(UnitTestErrorType.Warning, "Add collision encountered for MetaPartnerEmail: " + item.PrimaryKey.ToString(), null);
                        }
                        else
                        {
                            MOD.Data.NamedObjectCollection entityID = new MOD.Data.NamedObjectCollection();
                            entityID["MetaPartnerEmailID"] = item.MetaPartnerEmailID;
                            idList.Add(entityID);
                            TestHelper.ReportValueToConsole("Customers_MetaPartnerEmail_BasicTest: Add succeeded for MetaPartnerEmail", item.PrimaryKey.ToString());

                            // serialize and deserialize
                            itemStr = MOD.Data.Serialization.Serialize(item);
                            object oItem = (object)item;
                            MOD.Data.Serialization.Deserialize(itemStr, ref oItem);
                            item = (BLL.Customers.MetaPartnerEmail)oItem;
                            oItem = null;
                            item = null;
                        }
                    }
                    catch (System.Exception ex)
                    {
                        string strExtraInfo = "Loop iteration #" + i.ToString();

                        try
                        {
                            if (item != null)
                            {
                                itemStr = MOD.Data.Serialization.Serialize(item);
                            }
                        }
                        catch (System.Exception serialEx)
                        {
                            UpdateUnitTestErrorInfo(UnitTestErrorType.Functional, "Serialization failed for MetaPartnerEmail", itemStr, serialEx, strExtraInfo);
                        }
                        if (ex is UnitTestException)
                        {
                            UpdateUnitTestErrorInfo(((UnitTestException)ex).ErrorType, ex.Message, itemStr, ex.InnerException, strExtraInfo);
                        }
                        else
                        {
                            UpdateUnitTestErrorInfo(UnitTestErrorType.Functional, "Add failed for MetaPartnerEmail", itemStr, ex, strExtraInfo);
                        }
                    }
                }

                // TODO: Assert Warning if MetaPartnerEmail Add count is not the same as Update count

                //
                // get and update items
                //
                int loopIndex = 0;
                TestHelper.ReportValueToConsole("Customers_MetaPartnerEmail_BasicTest: Update MetaPartnerEmail count", idList.Count.ToString());
                foreach (MOD.Data.NamedObjectCollection loopID in idList)
                {
                    try
                    {
                        item = MetaPartnerEmail_Manager.UpdateOneMetaPartnerEmailTest((Guid)loopID["MetaPartnerEmailID"], true, Results);
                        TestHelper.ReportValueToConsole("Customers_MetaPartnerEmail_BasicTest: Update succeeded for MetaPartnerEmail", item.PrimaryKey.ToString());

                        // serialize and deserialize
                        itemStr = MOD.Data.Serialization.Serialize(item);
                        object oItem = (object)item;
                        MOD.Data.Serialization.Deserialize(itemStr, ref oItem);
                        item = (BLL.Customers.MetaPartnerEmail)oItem;
                        oItem = null;
                        item = null;
                    }
                    catch (System.Exception ex)
                    {
                        string strExtraInfo = "Loop iteration #" + loopIndex.ToString();

                        try
                        {
                            if (item != null)
                            {
                                itemStr = MOD.Data.Serialization.Serialize(item);
                            }
                        }
                        catch (System.Exception serialEx)
                        {
                            UpdateUnitTestErrorInfo(UnitTestErrorType.Functional, "Serialization failed for MetaPartnerEmail", itemStr, serialEx, strExtraInfo);
                        }
                        if (ex is UnitTestException)
                        {
                            UpdateUnitTestErrorInfo(((UnitTestException)ex).ErrorType, ex.Message, itemStr, ex.InnerException, strExtraInfo);
                        }
                        else
                        {
                            UpdateUnitTestErrorInfo(UnitTestErrorType.Functional, "Update failed for MetaPartnerEmail", itemStr, ex, strExtraInfo);
                        }
                    }
                    loopIndex++;
                }

                //
                // get and delete items (clean up)
                //
                loopIndex = 0;
                TestHelper.ReportValueToConsole("Customers_MetaPartnerEmail_BasicTest: Delete MetaPartnerEmail count", idList.Count.ToString());
                foreach (MOD.Data.NamedObjectCollection loopID in idList)
                {
                    // either delete all created records or a random sample of created records
                    if (Globals.DeleteAllCreatedRecords == true || TestHelper.GetBool() == true)
                    {
                        try
                        {
                            item = MetaPartnerEmail_Manager.DeleteOneMetaPartnerEmailTest((Guid)loopID["MetaPartnerEmailID"], true, Results);
                            TestHelper.ReportValueToConsole("Customers_MetaPartnerEmail_BasicTest: Delete succeeded for MetaPartnerEmail", item.PrimaryKey);
                        }
                        catch (System.Exception ex)
                        {
                            string strExtraInfo = "Loop iteration #" + loopIndex.ToString();

                            try
                            {
                                if (item != null)
                                {
                                    itemStr = MOD.Data.Serialization.Serialize(item);
                                }
                            }
                            catch (System.Exception serialEx)
                            {
                                UpdateUnitTestErrorInfo(UnitTestErrorType.Functional, "Serialization failed for MetaPartnerEmail", itemStr, serialEx, strExtraInfo);
                            }
                            if (ex is UnitTestException)
                            {
                                UpdateUnitTestErrorInfo(((UnitTestException)ex).ErrorType, ex.Message, itemStr, ex.InnerException, strExtraInfo);
                            }
                            else
                            {
                                UpdateUnitTestErrorInfo(UnitTestErrorType.Functional, "Delete failed for MetaPartnerEmail", itemStr, ex, strExtraInfo);
                            }
                        }
                    }
                    loopIndex++;
                }

                Console.WriteLine("******************** Customers_MetaPartnerEmail_BasicTest END **********************");
                Console.WriteLine();
                Console.WriteLine();
                if ((ErrorIndex > 0) || (WarningIndex > 0))
                {
                    Console.WriteLine("==================== Customers_MetaPartnerEmail_BasicTest Error/Warning Details ====");
                    Console.WriteLine();
                }
            }
            catch (System.Exception ex)
            {
                if (FailureLevel != UnitTestFailureLevel.Abort)
                {
                    UpdateUnitTestErrorInfo(UnitTestErrorType.Functional, "Unhandled error", null, ex, null);
                }
            }
            finally
            {
                System.GC.Collect();
                OutputUnitTestStatus();
            }
        }

        #endregion Methods
    }
}