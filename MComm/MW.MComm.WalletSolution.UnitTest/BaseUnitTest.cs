/*<copyright>
MOD Systems, Inc (c) 2007 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2007, covered by Trademark Laws, contents are considered Restricted Secrets by MOD Systems.  The contents may only be viewed by MOD Systems Engineers (employees).
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact MOD System's competitive advantage.
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
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace MW.MComm.WalletSolution.UnitTest
{
    // ------------------------------------------------------------------------------
    /// <summary>This class is used to manage the base behavior and handling for all
	/// unit tests.</summary>
    ///
    /// File History:
    /// <created>7/12/2007 (Dave Clemmer)</created>
    ///
    /// <remarks></remarks>
    // ------------------------------------------------------------------------------
	public class BaseUnitTest
	{
		#region Fields
		// for ErrorReport property
		private string _strErrorReport;

		// for ErrorItems property
		private string _strErrorItems;

		// for ErrorIndex property
		private int _iErrorIndex;


        // for WarningReport property
        private string _strWarningReport;

        // for WarningItems property
        private string _strWarningItems;

        // for WarningIndex property
        private int _iWarningIndex;


        // for InfoReport property
        private string _strInfoReport;

        // for InfoItems property
        private string _strInfoItems;

        // for InfoIndex property
        private int _iInfoIndex;


		// for FailureLevel property
		private UnitTestFailureLevel _failureLevel;

		// for Results property
		private MOD.Test.TestResults _results;

		#endregion Fields
		
		#region Properties
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the ErrorReport.</summary>
		// ------------------------------------------------------------------------------
		public virtual string ErrorReport
		{
			get
			{
                return _strErrorReport;
			}
			set
			{
                if (_strErrorReport != value)
				{
                    _strErrorReport = value;
				}
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the ErrorItems.</summary>
		// ------------------------------------------------------------------------------
		public virtual string ErrorItems
		{
			get
			{
                return _strErrorItems;
			}
			set
			{
                if (_strErrorItems != value)
				{
                    _strErrorItems = value;
				}
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the ErrorIndex.</summary>
		// ------------------------------------------------------------------------------
		public virtual int ErrorIndex
		{
			get
			{
                return _iErrorIndex;
			}
			set
			{
                if (_iErrorIndex != value)
				{
                    _iErrorIndex = value;
				}
			}
		}

        // ------------------------------------------------------------------------------
        /// <summary>This property gets or sets the WarningReport.</summary>
        // ------------------------------------------------------------------------------
        public virtual string WarningReport
        {
            get
            {
                return _strWarningReport;
            }
            set
            {
                if (_strWarningReport != value)
                {
                    _strWarningReport = value;
                }
            }
        }

        // ------------------------------------------------------------------------------
        /// <summary>This property gets or sets the WarningItems.</summary>
        // ------------------------------------------------------------------------------
        public virtual string WarningItems
        {
            get
            {
                return _strWarningItems;
            }
            set
            {
                if (_strWarningItems != value)
                {
                    _strWarningItems = value;
                }
            }
        }

        // ------------------------------------------------------------------------------
        /// <summary>This property gets or sets the WarningIndex.</summary>
        // ------------------------------------------------------------------------------
        public virtual int WarningIndex
        {
            get
            {
                return _iWarningIndex;
            }
            set
            {
                if (_iWarningIndex != value)
                {
                    _iWarningIndex = value;
                }
            }
        }

        // ------------------------------------------------------------------------------
        /// <summary>This property gets or sets the InfoReport.</summary>
        // ------------------------------------------------------------------------------
        public virtual string InfoReport
        {
            get
            {
                return _strInfoReport;
            }
            set
            {
                if (_strInfoReport != value)
                {
                    _strInfoReport = value;
                }
            }
        }

        // ------------------------------------------------------------------------------
        /// <summary>This property gets or sets the InfoItems.</summary>
        // ------------------------------------------------------------------------------
        public virtual string InfoItems
        {
            get
            {
                return _strInfoItems;
            }
            set
            {
                if (_strInfoItems != value)
                {
                    _strInfoItems = value;
                }
            }
        }

        // ------------------------------------------------------------------------------
        /// <summary>This property gets or sets the InfoIndex.</summary>
        // ------------------------------------------------------------------------------
        public virtual int InfoIndex
        {
            get
            {
                return _iInfoIndex;
            }
            set
            {
                if (_iInfoIndex != value)
                {
                    _iInfoIndex = value;
                }
            }
        }


		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the FailureLevel.</summary>
		// ------------------------------------------------------------------------------
		public virtual UnitTestFailureLevel FailureLevel
		{
			get
			{
				return _failureLevel;
			}
			set
			{
				if (_failureLevel != value)
				{
					_failureLevel = value;
				}
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the Results.</summary>
		// ------------------------------------------------------------------------------
		public virtual MOD.Test.TestResults Results
		{
			get
			{
				if (_results == null)
				{
					_results = new TestResults();
				}
				return _results;
			}
			set
			{
				if (_results != value)
				{
					_results = value;
				}
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the IsMbUnitRunning.</summary>
		// ------------------------------------------------------------------------------
		public virtual bool IsMbUnitRunning
		{
			get
			{
                string prefix = "domain";
                return AppDomain.CurrentDomain.FriendlyName.Substring(0, prefix.Length).Equals(prefix);
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the IsVStudioRunning.</summary>
		// ------------------------------------------------------------------------------
		public virtual bool IsVStudioRunning
		{
			get
			{
                string prefix = "UnitTestAdapterDomain";
                return AppDomain.CurrentDomain.FriendlyName.Substring(0, prefix.Length).Equals(prefix);
            }
		}

		#endregion Properties

        #region Constructors

        // ------------------------------------------------------------------------------
        /// <summary>This method is the constructor, initializes unit test info and status.</summary>
        // ------------------------------------------------------------------------------
        public BaseUnitTest()
        {
            ErrorReport = String.Empty;
            ErrorItems = String.Empty;
            ErrorIndex = 0;

            WarningReport = String.Empty;
            WarningItems = String.Empty;
            WarningIndex = 0;

            InfoReport = String.Empty;
            InfoItems = String.Empty;
            InfoIndex = 0;

            FailureLevel = UnitTestFailureLevel.Success;
        }

        #endregion Constructors


        #region Methods
        // ------------------------------------------------------------------------------
        /// <summary>This method outputs the unit test status and information.
        /// Error or warning assertions are thrown if issues are present.</summary >
        // ------------------------------------------------------------------------------
		protected virtual void OutputUnitTestStatus()
        {
            string finalAssertionStr = "\r\n\r\nUnit Test Status: " + FailureLevel.ToString() + "\r\n\r\n";
            finalAssertionStr += "TOTAL ERROR COUNT: " + ErrorIndex.ToString() + "\r\n";
            finalAssertionStr += "TOTAL WARNING COUNT: " + WarningIndex.ToString() + "\r\n";
            if (InfoIndex > 0)
            {
                finalAssertionStr += "TOTAL INFO ITEM COUNT: " + InfoIndex.ToString() + "\r\n";
            }

            finalAssertionStr += "\r\n...\r\n";

            Console.WriteLine(finalAssertionStr);

            Console.WriteLine(ErrorItems);
            Console.WriteLine(WarningItems);
            if (InfoIndex > 0)
            {
                Console.WriteLine(InfoItems);
            }

            if (ErrorIndex > 0)
            {
                finalAssertionStr += "\r\n========== ERROR REPORT ============\r\n" + ErrorReport;
            }
            if (WarningIndex > 0)
            {
                finalAssertionStr += "\r\n========== WARNING REPORT ==========\r\n" + WarningReport;
            }
            if (InfoIndex > 0)
            {
                finalAssertionStr += "\r\n========== INFO ITEM REPORT ==========\r\n" + InfoReport;
            }

            finalAssertionStr += "\r\n====================================\r\n";
    

            // assert based on failure level
            switch (FailureLevel)
            {
                case UnitTestFailureLevel.Warning:                  
					if (IsMbUnitRunning == true)
					{
						MbUnit.Framework.Assert.Warning(finalAssertionStr);
                        MbUnit.Framework.Assert.Ignore(finalAssertionStr);
					}
                    else if (IsVStudioRunning == true)
                    {
                        throw new UnitTestException("OutputUnitTestStatus: Cannot handle Visual Studio Test Tool warning assertions.", null);
                        //Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Inconclusive(finalAssertionStr);
                    }
                    else
                    {
                        throw new UnitTestException("OutputUnitTestStatus: Cannot handle asserting a warning type failure.", null);
                    }
                    break;

                case UnitTestFailureLevel.Error:
                case UnitTestFailureLevel.Abort:
                    if (IsMbUnitRunning == true)
					{
						MbUnit.Framework.Assert.Fail(finalAssertionStr);
					}
					else if (IsVStudioRunning == true)
					{
                        throw new UnitTestException("OutputUnitTestStatus: Cannot handle Visual Studio Test Tool error assertions.", null);
                        //Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail(finalAssertionStr);
					}
                    else
                    {
                        throw new UnitTestException("OutputUnitTestStatus: Cannot handle asserting an error type failure.", null);
                    }
                    break;

                case UnitTestFailureLevel.None:
                case UnitTestFailureLevel.Success:                   
                    // nothing
                    break;

                default:
                    throw new InvalidOperationException("OutputUnitTestStatus: Cannot recognize this unit test failure level.");
                    
            }
        }

        // ------------------------------------------------------------------------------
        /// <summary>This method will update this test fixture's running error messages in preparation for the final report.</summary>
        /// errType: This is the Unit Test err type passed in order to state what type of Unit test error this is in the report.
        /// errMsg: This is the accompanying string describing what type of error occurred. If there isn't an error message, assign "null"
        /// errItem: This is the subject data related to the errMsg above.  If there isn't an error item, assign "null"
        /// errEx: If non-null, information regarding this exception is added.  If no exception occurred, assign "null"
        /// customErrObj: Depending on the type of unit test error, a generic Object is passed as a way to customize parameters for the method.
        ///     [UnknownError: null]
        ///     [Validation Error: a custom object parameter.  Currently a string, but extensible.]
        ///     [Performance Error: *TBD* ]
        // ------------------------------------------------------------------------------
        protected virtual void UpdateDetailedUnitTestErrorInfo(UnitTestErrorType errType, string errMsg, string errItem, Exception errEx, object customErrObj,ref string alertReport, ref string alertItems, int alertIndex, string alertTypeStr)
        {
            // start console dump string
            string consoleStr = String.Empty;

            // Append new test error composition
            string briefAlertMsg = alertTypeStr + " #";
            briefAlertMsg += alertIndex.ToString();
            briefAlertMsg += ": " + TestHelper.GetUnitTestErrorTypeString(errType);

            if (errMsg != null)
            {
                briefAlertMsg += " -- " + errMsg;
            }

            if (customErrObj != null)
            {
                briefAlertMsg += " - " + (string)customErrObj;
            }

            // Update console output
            consoleStr += "===== " + briefAlertMsg + " (See details)";

            briefAlertMsg += " ";

            Exception ex = errEx;
            if (ex != null)
            {
                briefAlertMsg += " -- Exception thrown: " + ex.GetType().ToString() + "\r\n";
				if (ex is Utility.CustomAppException)
				{
					briefAlertMsg += " EVENT: " + ((Utility.CustomAppException)ex).EventName + "\r\n";
				}
				briefAlertMsg += "MESSAGE/CALL STACK:\r\n" + MOD.Exceptions.ExceptionHelper.GetExtendedErrorMessageAndStackTrace(ex);

                ex = ex.InnerException;
                while (ex != null)
                {
                    briefAlertMsg += "\r\n\r\n";
                    briefAlertMsg += "Inner exception: " + ex.GetType().ToString() + "\r\n";
					if (ex is Utility.CustomAppException)
					{
						briefAlertMsg += " Event: " + ((Utility.CustomAppException)ex).EventName + "\r\n";
					}
					briefAlertMsg += "Message/call stack:\r\n" + MOD.Exceptions.ExceptionHelper.GetExtendedErrorMessageAndStackTrace(ex);
                    ex = ex.InnerException;
                }
            }

            // Now add extra information for related items for the 
            briefAlertMsg += "\r\n";

            // Update report
            alertReport += "\r\n" + briefAlertMsg;           

            // Append new test error data composition
            briefAlertMsg += "------------------------------------------------------------------------------------------------------------------------\r\n";
            briefAlertMsg += "DATA:\r\n";
            if (errItem != null && errItem != String.Empty)
            {
                briefAlertMsg += errItem;
            }
            else
            {
                briefAlertMsg += "(none)";
            }
            briefAlertMsg += "\r\n";

            // Update alert items
            alertItems += "\r\n============================================================";
            alertItems += "\r\n" + briefAlertMsg;
            alertItems += "============================================================\r\n";

            Console.WriteLine(consoleStr);
        }

        protected virtual void UpdateUnitTestErrorInfo(UnitTestErrorType errType, string errMsg, string errItem, Exception errEx, object customErrObj)
        {
            // update test failure level
            UnitTestFailureLevel errorLevel = TestHelper.GetUnitTestFailureLevelForErrorType(errType);
            if ((int)errorLevel > (int)FailureLevel)
            {
                FailureLevel = errorLevel;
            }

            string alertReport = String.Empty;
            string alertItems = String.Empty;
            
            switch (errorLevel)
            {

                case UnitTestFailureLevel.Warning:
                    UpdateDetailedUnitTestErrorInfo(errType, errMsg, errItem, errEx, customErrObj, ref alertReport, ref alertItems, WarningIndex, "WARNING");
                    WarningReport += alertReport;
                    WarningItems += alertItems;
                    WarningIndex++;
                    break;

                case UnitTestFailureLevel.Error:
                case UnitTestFailureLevel.Abort:
                    UpdateDetailedUnitTestErrorInfo(errType, errMsg, errItem, errEx, customErrObj, ref alertReport, ref alertItems, ErrorIndex, "ERROR");
                    ErrorReport += alertReport;
                    ErrorItems += alertItems;
                    ErrorIndex++;
                    break;

                case UnitTestFailureLevel.Success:
                    UpdateDetailedUnitTestErrorInfo(errType, errMsg, errItem, errEx, customErrObj, ref alertReport, ref alertItems, InfoIndex, "INFO ITEM");
                    InfoReport += alertReport;
                    InfoItems += alertItems;
                    InfoIndex++;
                    break;

                case UnitTestFailureLevel.None:
                    throw new InvalidOperationException("We should not be calling UpdateUnitTestErrorInfo in the context of an undetermined error level");
                    break;
                
                default:
                    throw new InvalidOperationException("UpdateUnitTestErrorInfo does not recognize this error level.");
                    break;
            }
        }

        #endregion Methods

	}
}
