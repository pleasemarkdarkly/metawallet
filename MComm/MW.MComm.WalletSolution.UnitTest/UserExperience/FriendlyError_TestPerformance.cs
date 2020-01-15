

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
using MW.MComm.WalletSolution.UnitTest.UserExperience;
using BLL = MW.MComm.WalletSolution.BLL;
using Utility = MW.MComm.WalletSolution.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace MW.MComm.WalletSolution.UnitTest.UserExperience
{
    // ------------------------------------------------------------------------------
    /// <summary>This class is used to run BLL method tests for FriendlyError instances.</summary>
    ///
    /// File History:
    /// <created>7/31/2007 (Brian MacDonald)</created>
    ///
    /// <remarks></remarks>
    // ------------------------------------------------------------------------------
    [TestFixture, FixtureCategory("Performance.UserExperience"), Author("Common"), Importance(TestImportance.Serious), TestsOn(typeof(BLL.UserExperience.FriendlyError))]
    public partial class FriendlyError_TestPerformance : BaseUnitTest
    {

        #region Fields
        #endregion Fields

        #region Properties
        #endregion Properties

        #region Constructors

        // ------------------------------------------------------------------------------
        /// <summary>This method is the constructor, initializes unit test info and status.</summary>
        // ------------------------------------------------------------------------------
        public FriendlyError_TestPerformance() : base()
        {
        }

        #endregion Constructors

        #region Methods
        [SetUp]
        public void Init()
        {
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method is the performance entity test for FriendlyError.</summary>
        // ------------------------------------------------------------------------------
        [Test]
        public void UserExperience_FriendlyError_PerformanceTest()
        {
            try
            {
                Console.WriteLine("******************** UserExperience_FriendlyError_PerformanceTest START ********************");
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
                TestHelper.ReportValueToConsole("UserExperience_FriendlyError_PerformanceTest: Value generation method: Random seed -- Current ticks", currentTicks.ToString());
                TestHelper.SeedRandom(currentTicks);

                double[] perfTimeLevels = new double[] {0.25, 1.00, 2.00, 4.00, 8.00};
                double acceptableTime = perfTimeLevels[(int)UnitTestPerformanceLevel.Tolerable - 1];
                for (int i = 0; i < perfTimeLevels.Length; i++)
                {
                    TestHelper.ReportValueToConsole("UserExperience_FriendlyError_PerformanceTest: " + TestHelper.GetUnitTestPerformanceLevelString((UnitTestPerformanceLevel)(i + 1)) + " time (in seconds)", perfTimeLevels[i]);
                }
                TestHelper.ReportValueToConsole("UserExperience_FriendlyError_PerformanceTest: " + TestHelper.GetUnitTestPerformanceLevelString(UnitTestPerformanceLevel.Unacceptable) + " time (in seconds) is beyond", perfTimeLevels[(((int)UnitTestPerformanceLevel.Unacceptable - 1) - 1)]);

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
                TestHelper.ReportValueToConsole("UserExperience_FriendlyError_PerformanceTest: page size", pageSize);
                TestHelper.ReportValueToConsole("UserExperience_FriendlyError_PerformanceTest: maxListSize", maxListSize);
                if (Globals.RunPrimaryEntityTests == false)
                    return;

                //
                // perform get all and get many operations
                //
                avgCallsTime = 0.00;
                avgGetDataSearchSecs = 0.00;
                avgSerializeDataSecs = 0.00;
                avgDeserializeDataSecs = 0.00;
                numGetDataSearches = 0;
                numSerializations = 0;
                numDeserializations = 0;

                Results.ClearTestResults();

                //loadCount = TestHelper.GetInt(Globals.MinimumGetAllCountPerEntity, Globals.MaximumGetAllCountPerEntity);
                loadCount = Globals.MaximumGetAllCountPerEntity;
                TestHelper.ReportValueToConsole("UserExperience_FriendlyError_PerformanceTest: GetManyFriendlyErrorDataByCriteria test count", loadCount.ToString());
                for (int i=0; i < loadCount; i++)
                {
                    long startTicks = 0;
                    long endTicks = 0;
                    double secondsInterval = 0.00;
                    BLL.SortableList<BLL.UserExperience.FriendlyError> items = null;

                    TestHelper.ReportValueToConsole("UserExperience_FriendlyError_PerformanceTest: Loop Iteration", i);
                    DataOptions dbOptions = Globals.getDataOptions("", "Random", 1, pageSize, maxListSize);
                    UnitTestPerformanceLevel perfLevel = UnitTestPerformanceLevel.None;
                    string perfStr = String.Empty;

                    TestHelper.ReportValueToConsole("UserExperience_FriendlyError_PerformanceTest: GetManyFriendlyErrorDataByCriteria acceptable search time (in seconds)", acceptableTime);
                    try
                    {
                        // get many
                        Results.ResetCurrentPerfMetric();
                        Results.SetPerfMetricName("UserExperience.FriendlyError.GetMany." + i.ToString());
                        items = FriendlyError_Manager.GetManyFriendlyErrorDataByCriteriaTest(dbOptions, Results);
                        TestHelper.ReportValueToConsole("UserExperience_FriendlyError_PerformanceTest: GetManyFriendlyErrorDataByCriteria succeeded for FriendlyError. The count", items.Count.ToString());
                            Results.SaveCurrentPerfMetric();
                        numGetDataSearches++;
                        Console.WriteLine(Results.CurrentPerfMetrics.ToString());
                        avgCallsTime = Results.CurrentPerfMetrics.PerfAvgCallTimeInSeconds;
                        avgGetDataSearchSecs += avgCallsTime;

                        perfLevel = TestHelper.GetPerformanceLevelFromTime(avgCallsTime, perfTimeLevels);
                        perfStr = "GetManyFriendlyErrorDataByCriteria search time (in seconds) for FriendlyError count " + items.Count + " was " + avgCallsTime + ". " + TestHelper.GetUnitTestPerformanceLevelString(perfLevel) + ".";

                        throw new UnitTestException(TestHelper.GetUnitTestErrorTypeForPerformanceLevel(perfLevel), perfStr, null);
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
                            UpdateUnitTestErrorInfo(UnitTestErrorType.Functional,"GetManyFriendlyErrorDataByCriteria failed for FriendlyError", itemStr, ex, strExtraInfo);
                        }
                    }

                    if (items != null)
                    {
                        TestHelper.ReportValueToConsole("UserExperience_FriendlyError_PerformanceTest: GetManyFriendlyErrorDataByCriteria acceptable serialization time (in seconds)", acceptableTime);
                        try
                        {
                            // serialize
                            Results.ResetCurrentPerfMetric();
                            Results.SetPerfMetricName("UserExperience.FriendlyError.Serialize." + i.ToString());
                            startTicks = DateTime.Now.Ticks;
                            itemStr = MOD.Data.Serialization.Serialize(items);
                            endTicks = DateTime.Now.Ticks;
                            secondsInterval = TestHelper.GetSecondsFromTicks(endTicks - startTicks);
                            Results.AddPerfMetric(secondsInterval, null, String.Empty);
                            Results.SaveCurrentPerfMetric();
                            numSerializations++;
                            Console.WriteLine(Results.CurrentPerfMetrics.ToString());
                            avgCallsTime = Results.CurrentPerfMetrics.PerfAvgCallTimeInSeconds;
                            avgSerializeDataSecs += avgCallsTime;

                            perfLevel = TestHelper.GetPerformanceLevelFromTime(avgCallsTime, perfTimeLevels);
                            perfStr = "GetManyFriendlyErrorDataByCriteria serialization time (in seconds) for FriendlyError count " + items.Count + " was " + avgCallsTime + ". " + TestHelper.GetUnitTestPerformanceLevelString(perfLevel) + ".";
                            throw new UnitTestException(TestHelper.GetUnitTestErrorTypeForPerformanceLevel(perfLevel), perfStr, null);
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
                                UpdateUnitTestErrorInfo(UnitTestErrorType.Functional,"GetManyFriendlyErrorDataByCriteria failed for FriendlyError", itemStr, ex, strExtraInfo);
                            }
                        }

                        TestHelper.ReportValueToConsole("UserExperience_FriendlyError_PerformanceTest: GetManyFriendlyErrorDataByCriteria acceptable deserialization time (in seconds)", acceptableTime);
                        try
                        {
                            // deserialize
                            Results.ResetCurrentPerfMetric();
                            Results.SetPerfMetricName("UserExperience.FriendlyError.Deserialize." + i.ToString());
                            object oItems = (object)items;
                            startTicks = DateTime.Now.Ticks;
                            MOD.Data.Serialization.Deserialize(itemStr, ref oItems);
                            endTicks = DateTime.Now.Ticks;
                            secondsInterval = TestHelper.GetSecondsFromTicks(endTicks - startTicks);
                            Results.AddPerfMetric(secondsInterval, null, String.Empty);
                            Results.SaveCurrentPerfMetric();
                            numDeserializations++;
                            Console.WriteLine(Results.CurrentPerfMetrics.ToString());
                            avgCallsTime = Results.CurrentPerfMetrics.PerfAvgCallTimeInSeconds;
                            avgDeserializeDataSecs += avgCallsTime;
                            items = (BLL.SortableList<BLL.UserExperience.FriendlyError>)oItems;
                            int itemCount = items.Count;
                            oItems = null;
                            items = null;

                            perfLevel = TestHelper.GetPerformanceLevelFromTime(avgCallsTime, perfTimeLevels);
                            perfStr = "GetManyFriendlyErrorDataByCriteria deserialization time (in seconds) for FriendlyError count " + itemCount + " was " + avgCallsTime + ". " + TestHelper.GetUnitTestPerformanceLevelString(perfLevel) + ".";
                            throw new UnitTestException(TestHelper.GetUnitTestErrorTypeForPerformanceLevel(perfLevel), perfStr, null);
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
                                UpdateUnitTestErrorInfo(UnitTestErrorType.Functional, "GetManyFriendlyErrorDataByCriteria failed for FriendlyError", itemStr, ex, strExtraInfo);
                            }
                        }
                    }
                }
                if (numGetDataSearches > 0)
                {
                    avgGetDataSearchSecs /= numGetDataSearches;
                    TestHelper.ReportValueToConsole("UserExperience_FriendlyError_PerformanceTest: GetManyFriendlyErrorDataByCriteria AVERAGE SEARCH TIME (in seconds)", avgGetDataSearchSecs);
                }
                else
                {
                    Console.WriteLine("UserExperience_FriendlyError_PerformanceTest: GetManyFriendlyErrorDataByCriteria -- Could not perform search. NO AVERAGE SEARCH TIME AVAILABLE.");
                }
                if (numSerializations > 0)
                {
                    avgSerializeDataSecs /= numSerializations;
                    TestHelper.ReportValueToConsole("UserExperience_FriendlyError_PerformanceTest: GetManyFriendlyErrorDataByCriteria AVERAGE SERIALIZATION TIME (in seconds)", avgSerializeDataSecs);
                }
                else
                {
                    Console.WriteLine("UserExperience_FriendlyError_PerformanceTest: GetManyFriendlyErrorDataByCriteria -- Could not serialize. NO AVERAGE SERIALIZATION TIME AVAILABLE.");
                }
                if (numDeserializations > 0)
                {
                    avgDeserializeDataSecs /= numDeserializations;
                    TestHelper.ReportValueToConsole("UserExperience_FriendlyError_PerformanceTest: GetManyFriendlyErrorDataByCriteria AVERAGE DESERIALIZATION TIME (in seconds)", avgDeserializeDataSecs);
                }
                else
                {
                    Console.WriteLine("UserExperience_FriendlyError_PerformanceTest: GetManyFriendlyErrorDataByCriteria -- Could not deserialize. NO AVERAGE DESERIALIZATION TIME AVAILABLE.");
                }


                

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

                Console.WriteLine("******************** UserExperience_FriendlyError_PerformanceTest END **********************");
                Console.WriteLine();
                Console.WriteLine();
                if ((ErrorIndex > 0) || (WarningIndex > 0))
                {
                    Console.WriteLine("==================== UserExperience_FriendlyError_PerformanceTest Error/Warning Details ====");
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