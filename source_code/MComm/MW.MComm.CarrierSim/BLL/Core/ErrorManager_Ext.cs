

/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/
using System;
using System.ComponentModel;
using MW.MComm.CarrierSim.BLL.Core;
using MOD.Data;
using BLL = MW.MComm.CarrierSim.BLL;
using DAL = MW.MComm.CarrierSim.DAL;
using Utility = MW.MComm.CarrierSim.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace MW.MComm.CarrierSim.BLL.Core
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage Error related information.</summary>
	///
	/// File History:
	/// <created>10/6/2006 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class ErrorManager
	{
		// for error list from db
		private static SortableList<BLL.Core.Error> _errorList = null;

		#region Methods
		// ------------------------------------------------------------------------------
		/// <summary>This method sets the error list.</summary>
		// ------------------------------------------------------------------------------
		public static void SetErrors(int debugLevel, MOD.Data.DatabaseOptions dbOptions, Guid currentUserID)
		{
			// lock and load sproc xml data
			lock (typeof(Error))
			{
				_errorList = BLL.Core.ErrorManager.GetAllErrorData(dbOptions, new DataOptions(), debugLevel, currentUserID);
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets a single FriendlyError by an index.</summary>
		///
		/// <param name="errorNumber">The index for FriendlyError to be fetched</param>
		/// <param name="localeCode">The index for FriendlyError to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static string GetErrorMessageFromException(System.Exception error, int localeCode, bool includeStackTrace)
		{
			try
			{
				// perform main method tasks
				string message = string.Empty;
				while (error != null)
				{
					message += "\r\n" + error.Message;
					if (includeStackTrace == true)
					{
						message += "\r\n\r\n" + error.StackTrace + "\r\n";
					}
					error = error.InnerException;
				}
				return message;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.ErrorManager.GetErrorMessageFromException");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method returns an error message based on an error number.</summary>
		/// 
		/// <param name="errorNumber">The error number</param>
		/// <returns>The error message</returns>
		// ------------------------------------------------------------------
		public static string GetErrorMessageFromErrorNumber(BLL.Core.ErrorNumber errorNumber)
		{
			try
			{
				// try to get extended error from app cache first
				try
				{
					foreach (BLL.Core.Error loopError in _errorList)
					{
						if (loopError.ErrorNumber == int.Parse(errorNumber.ToString("D")))
						{
							// found error
							return loopError.ErrorMessage;
						}
					}
					// couldn't find error
					return errorNumber.ToString();
				}
				catch
				{
					// problem with error list
					return errorNumber.ToString();
				}
			}
			catch
			{
				// couldn't use errorNumber
				return BLL.Core.ErrorNumber.GeneralException.ToString();
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method returns an error message based on an error number.</summary>
		/// 
		/// <param name="errorNumber">The error number</param>
		/// <returns>The error message</returns>
		// ------------------------------------------------------------------
		public static string GetErrorMessageFromErrorNumber(int errorNumber)
		{
			try
			{
				// try to get extended error from app cache first
				try
				{
					foreach (BLL.Core.Error loopError in _errorList)
					{
						if (loopError.ErrorNumber == errorNumber)
						{
							// found error
							return loopError.ErrorMessage;
						}
					}
					// couldn't find error
					return BLL.Core.ErrorNumber.GeneralException.ToString();
				}
				catch
				{
					// problem with error list
					return BLL.Core.ErrorNumber.GeneralException.ToString();
				}
			}
			catch
			{
				// couldn't use errorNumber
				return BLL.Core.ErrorNumber.GeneralException.ToString();
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method returns a known error number based on a sql error number.</summary>
		/// 
		/// <param name="sqlErrorNumber">The sql error number</param>
		/// <returns>The enumeration of the known error</returns>
		// ------------------------------------------------------------------
		public static BLL.Core.ErrorNumber GetErrorNumberFromSqlError(int sqlErrorNumber)
		{
			return GetErrorNumberFromSqlError(sqlErrorNumber, "");
		}

		// ------------------------------------------------------------------
		/// <summary>This method returns a known error number based on a sql error number.</summary>
		/// 
		/// <param name="sqlErrorNumber">The sql error number</param>
		/// <returns>The enumeration of the known error</returns>
		// ------------------------------------------------------------------
		public static BLL.Core.ErrorNumber GetErrorNumberFromSqlError(int sqlErrorNumber, string message)
		{
			switch (sqlErrorNumber)
			{
				case 0:
					return BLL.Core.ErrorNumber.None;
				case -1001:
					return BLL.Core.ErrorNumber.SqlInvalidParameter;
				case -1002:
					return BLL.Core.ErrorNumber.SqlTimestampFailure;
				case -1003:
					return BLL.Core.ErrorNumber.SqlInvalidRecord;
				case 547:
					if (message.StartsWith("INSERT") == true)
					{
						return BLL.Core.ErrorNumber.SqlInsertConstraintViolation;
					}
					else if (message.StartsWith("UPDATE") == true)
					{
						return BLL.Core.ErrorNumber.SqlUpdateConstraintViolation;
					}
					else if (message.StartsWith("DELETE") == true)
					{
						return BLL.Core.ErrorNumber.SqlDeleteConstraintViolation;
					}
					return BLL.Core.ErrorNumber.SqlConstraintViolation;
				case 701:
					return BLL.Core.ErrorNumber.SqlOutOfMemory;
				case 1204:
					return BLL.Core.ErrorNumber.SqlLockIssue;
				case 1205:
					return BLL.Core.ErrorNumber.SqlDeadlockVictim;
				case 1222:
					return BLL.Core.ErrorNumber.SqlLockRequestTimeout;
				case 8651:
					return BLL.Core.ErrorNumber.SqlLowMemory;
				case 7619:
					return BLL.Core.ErrorNumber.SqlIgnoredWords;
				default:
					return BLL.Core.ErrorNumber.SqlGeneralException;
			}

		}
		#endregion Methods
	}
}