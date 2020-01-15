

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
using MW.MComm.WalletSolution.UnitTest.Payments;
using BLL = MW.MComm.WalletSolution.BLL;
using Utility = MW.MComm.WalletSolution.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace MW.MComm.WalletSolution.UnitTest.Payments
{
    // ------------------------------------------------------------------------------
    /// <summary>This class is used to run BLL method tests for FeeType instances.</summary>
    ///
    /// File History:
    /// <created>7/31/2007 (Brian MacDonald)</created>
    ///
    /// <remarks></remarks>
    // ------------------------------------------------------------------------------
    [TestFixture, FixtureCategory("Search.Payments"), Author("Common"), Importance(TestImportance.Serious), TestsOn(typeof(BLL.Payments.FeeType))]
    public partial class FeeType_TestSearch : BaseUnitTest
    {

        #region Fields
        #endregion Fields

        #region Properties
        #endregion Properties

        #region Constructors

        // ------------------------------------------------------------------------------
        /// <summary>This method is the constructor, initializes unit test info and status.</summary>
        // ------------------------------------------------------------------------------
        public FeeType_TestSearch() : base()
        {
        }

        #endregion Constructors

        #region Methods
        [SetUp]
        public void Init()
        {
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is the search entity test for FeeType.</summary>
        // ------------------------------------------------------------------------------
        [Test]
        public void Payments_FeeType_SearchTest()
        {
            try
            {
                Console.WriteLine("******************** Payments_FeeType_SearchTest START ********************");
                Console.WriteLine("Automation framework check - Is MbUnit running? : " + IsMbUnitRunning.ToString());
                
                string itemStr = String.Empty;

                // This is required to allow the application to provide default data options
                BLL.BusinessObjectManager.Initialize(new Globals());

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

                int currentTicks = (int)DateTime.Now.Ticks;
                Console.WriteLine("Value generation method: Random seed -- Current ticks = {0}", currentTicks.ToString());
                TestHelper.SeedRandom(currentTicks);

                int loadCount = 0;
                if (Globals.RunLookupEntityTests == false)
                    return;

                //
                // get all items
                //
                loadCount = TestHelper.GetInt(Globals.MinimumGetAllCountPerEntity, Globals.MaximumGetAllCountPerEntity);
                Console.WriteLine("GetAllFeeTypeData test count is {0}.", loadCount.ToString());
                for (int i=0; i < loadCount; i++)
                {
                    try
                    {
                        BLL.SortableList<BLL.Payments.FeeType> items = FeeType_Manager.GetAllFeeTypeDataTest(Results);
                        Console.WriteLine("GetAllFeeTypeData succeeded for FeeType.");

                        // serialize and deserialize
                        itemStr = MOD.Data.Serialization.Serialize(items);
                        object oItems = (object)items;
                        MOD.Data.Serialization.Deserialize(itemStr, ref oItems);
                        items = (BLL.SortableList<BLL.Payments.FeeType>)oItems;
                        oItems = null;
                        items = null;
                    }
                    catch (System.Exception ex)
                    {
                        string strExtraInfo = "Loop iteration #" + i.ToString();
                        if (ex is UnitTestException)
                        {
                            UpdateUnitTestErrorInfo(((UnitTestException)ex).ErrorType, ex.Message, itemStr, ex.InnerException, strExtraInfo);
                        }
                        else
                        {
                            UpdateUnitTestErrorInfo(UnitTestErrorType.Functional, "GetAllFeeTypeData failed for FeeType", itemStr, ex, strExtraInfo);
                        }
                    }
                }

                Console.WriteLine("******************** Payments_FeeType_SearchTest END **********************");
                Console.WriteLine();
                Console.WriteLine();
                if ((ErrorIndex > 0) || (WarningIndex > 0))
                {
                    Console.WriteLine("==================== Payments_FeeType_SearchTest Error/Warning Details ====");
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