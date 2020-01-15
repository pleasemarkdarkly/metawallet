

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
using MW.MComm.WalletSolution.UnitTest.Accounts;
using BLL = MW.MComm.WalletSolution.BLL;
using Utility = MW.MComm.WalletSolution.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace MW.MComm.WalletSolution.UnitTest.Accounts
{
    // ------------------------------------------------------------------------------
    /// <summary>This class is used to run BLL method tests for ExternalAccount instances.</summary>
    ///
    /// File History:
    /// <created>7/31/2007 (Brian MacDonald)</created>
    ///
    /// <remarks></remarks>
    // ------------------------------------------------------------------------------
    [TestFixture, FixtureCategory("Performance.Accounts"), Author("Common"), Importance(TestImportance.Serious), TestsOn(typeof(BLL.Accounts.ExternalAccount))]
    public partial class ExternalAccount_TestPerformance : BaseUnitTest
    {

        #region Fields
        #endregion Fields

        #region Properties
        #endregion Properties

        #region Constructors

        // ------------------------------------------------------------------------------
        /// <summary>This method is the constructor, initializes unit test info and status.</summary>
        // ------------------------------------------------------------------------------
        public ExternalAccount_TestPerformance() : base()
        {
        }

        #endregion Constructors

        #region Methods
        [SetUp]
        public void Init()
        {
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is the performance entity test for ExternalAccount.</summary>
        // ------------------------------------------------------------------------------
        [Test]
        public void Accounts_ExternalAccount_PerformanceTest()
        {
            try
            {
                Console.WriteLine("******************** Accounts_ExternalAccount_PerformanceTest START ********************");
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
                TestHelper.ReportValueToConsole("Accounts_ExternalAccount_PerformanceTest: Value generation method: Random seed -- Current ticks", currentTicks.ToString());
                TestHelper.SeedRandom(currentTicks);

                double[] perfTimeLevels = new double[] {0.25, 1.00, 2.00, 4.00, 8.00};
                double acceptableTime = perfTimeLevels[(int)UnitTestPerformanceLevel.Tolerable - 1];
                for (int i = 0; i < perfTimeLevels.Length; i++)
                {
                    TestHelper.ReportValueToConsole("Accounts_ExternalAccount_PerformanceTest: " + TestHelper.GetUnitTestPerformanceLevelString((UnitTestPerformanceLevel)(i + 1)) + " time (in seconds)", perfTimeLevels[i]);
                }
                TestHelper.ReportValueToConsole("Accounts_ExternalAccount_PerformanceTest: " + TestHelper.GetUnitTestPerformanceLevelString(UnitTestPerformanceLevel.Unacceptable) + " time (in seconds) is beyond", perfTimeLevels[(((int)UnitTestPerformanceLevel.Unacceptable - 1) - 1)]);

                int loadCount = 0;

                double avgCallsTime = 0.00;

                double avgGetDataSearchSecs = 0.00;
                double avgSerializeDataSecs = 0.00;
                double avgDeserializeDataSecs = 0.00;
                int numGetDataSearches = 0;
                int numSerializations = 0;
                int numDeserializations = 0;

                int pageSize = 200;
                int maxListSize = 2000;
                TestHelper.ReportValueToConsole("Accounts_ExternalAccount_PerformanceTest: page size", pageSize);
                TestHelper.ReportValueToConsole("Accounts_ExternalAccount_PerformanceTest: maxListSize", maxListSize);
                if (Globals.RunPrimaryEntityTests == false)
                    return;

                //
                // perform get all and get many operations
                //

                double maxSerializationFactor = Globals.MaximumSerializationPerfTimeFactor;
                double maxDeserializationFactor = Globals.MaximumDeserializationPerfTimeFactor;
                if (avgSerializeDataSecs > (maxSerializationFactor * avgGetDataSearchSecs))
                {
                    string errorStr = String.Empty;
                    if (avgDeserializeDataSecs > (maxDeserializationFactor * avgGetDataSearchSecs))
                    {
                        errorStr = "Serialization and deserialization, each, was unusually long -- serialization took greater than " + maxSerializationFactor.ToString() + " times search in seconds, and deserialization took greater than " + maxDeserializationFactor.ToString() + " seconds.  Investigate for probable causes.";
                    }
                    else
                    {
                        errorStr = "Serialization was unusually long - greater than " + maxSerializationFactor.ToString() + " times search in seconds.  Investigate for probable causes.";
                    }

                    throw new UnitTestException(UnitTestErrorType.Functional, errorStr, null);
                }
                else if (avgDeserializeDataSecs > (maxDeserializationFactor * avgGetDataSearchSecs))
                {
                    string errorStr = "Deserialization was unusually long -- greater than " + maxDeserializationFactor.ToString() + " times search in seconds.  Investigate for probable causes.";
                    throw new UnitTestException(UnitTestErrorType.Functional, errorStr, null);
                }

                Console.WriteLine("******************** Accounts_ExternalAccount_PerformanceTest END **********************");
                Console.WriteLine();
                Console.WriteLine();
                if ((ErrorIndex > 0) || (WarningIndex > 0))
                {
                    Console.WriteLine("==================== Accounts_ExternalAccount_PerformanceTest Error/Warning Details ====");
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