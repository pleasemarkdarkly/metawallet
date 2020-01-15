/*<copyright>
MOD Systems, Inc (c) 2006 All Rights Reserved. 
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036 

All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by MOD Systems.  The contents may only be viewed by MOD Systems Engineers (employees) and selected Starbucks employees as outlined in the Licensing Agreement between MOD Systems and Starbucks Corporation on June 3rd, 2005.   

No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.  

No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact MOD System's competitive advantage.   

Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.   


</copyright>*/

using Microsoft.Win32;
using System;
using System.Configuration;
using System.ComponentModel;
using System.Collections;
using System.Collections.Specialized;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using MOD.Data;
using MW.MComm.CarrierSim.Utility;

using MW.MComm.CarrierSim.BLL.Core;

namespace MW.MComm.CarrierSim
{
	// ------------------------------------------------------------------------------
	/// <summary>This class contains global methods and properties for the data access layer, and to be used by any application tier.</summary>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public class Globals
	{
		#region "Declarations"
		#endregion "Declarations"

		#region "Constants And Enumerations"
		#endregion "Constants And Enumerations"

		#region "Public Static Properties"
		#endregion "Public Static Properties"

		#region "Public Static Methods"

		//------------------------------------------------------------------------
		/// <summary>This method adds required filter properties based on business rules.</summary>
		///
		/// <param name="filterProperties">named collection of filter properties to potentially add to</param>
		/// <param name="currentUserID">authentication key of user to determine filter collection</param>
		/// <returns></returns>
		//------------------------------------------------------------------------
		public static void AddRequiredFilterProperties(MOD.Data.DataOptions dataOptions, Guid currentUserID)
		{
			try
			{ 
				// add standard auditing fields if not an authenticated user
				if (currentUserID == MOD.Data.DefaultValue.Guid)
				{
					dataOptions.FilterFields["CreatedByUserID"] = true;
					dataOptions.FilterFields["LastModifiedByUserID"] = true;
					dataOptions.FilterFields["Timestamp"] = true;
				}
			}
			catch (CustomAppException ex)
			{
				throw ex;
			}
			catch (System.Exception ex)
			{
				throw CustomAppException.WrapException(ex, "MW.MComm.CarrierSim.Globals.AddRequiredFilterProperties");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method maps an SQL severity level to a <see cref="SeverityLevel"/>.</summary>
		/// 
		/// <param name="sqlSeverityLevel">The SQL severity level to map.</param>
		/// <returns>The <see cref="SeverityLevel"/>.</returns>
		/// <seealso cref="System.Data.SqlClient.SqlException"/>
		// ------------------------------------------------------------------
		public static BLL.Core.SeverityLevelCode GetSeverityLevelFromSqlSeverity(int sqlSeverityLevel) 
		{
			if (sqlSeverityLevel <= 10)
				return BLL.Core.SeverityLevelCode.Warning;
			else if (sqlSeverityLevel <= 16)
				return BLL.Core.SeverityLevelCode.NonCriticalError;
			else
				return BLL.Core.SeverityLevelCode.CriticalError;
		}

		public static void CheckThrowSqlError(NamedObjectCollection sprocParameters) 
		{
			// get output parameters and error handling
			if (sprocParameters.HasKey("SqlErrorNumber") && MOD.Data.DataHelper.GetInt(sprocParameters["SqlErrorNumber"], 0) != 0)
			{
				BLL.Core.ErrorNumber errorNumber = BLL.Core.ErrorManager.GetErrorNumberFromSqlError(MOD.Data.DataHelper.GetInt(sprocParameters["SqlErrorNumber"], 0));
				throw new CustomAppException(errorNumber, BLL.Core.SeverityLevelCode.CriticalError, BLL.Core.EventTypeCode.ErrorLog, "AssetSolution.Globals",
					BLL.Core.ErrorManager.GetErrorMessageFromErrorNumber(errorNumber), null);
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method checks the sql parameters and throws and exception if there is a sql error.</summary>
		/// 
		/// <param name="sprocParameters">The error number</param>
		/// <returns></returns>
		// ------------------------------------------------------------------
		//		public static CustomAppException GetSqlError(int sqlErrorNumber, string eventName) 
		//		{
		//			// get output parameters and error handling
		//			Globals.ErrorNumber errorNumber = Globals.GetErrorNumberFromSqlError(sqlErrorNumber);
		//
		//            return new CustomAppException();
		//            //return new CustomAppException(errorNumber, SeverityLevel.CriticalError, EventType.ErrorLog, eventName, 
		//            //    GetErrorMessageFromErrorNumber(errorNumber), null);
		//		}

		#endregion "Public Static Methods"

		#region "Miscellaneous"

		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public Globals()
		{
			//
			// constructor logic
			//
		}
		#endregion "Miscellaneous"
	}
}
