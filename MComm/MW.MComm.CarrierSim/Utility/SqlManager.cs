/*<copyright>
MOD Systems, Inc (c) 2006 All Rights Reserved. 
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036 

All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by MOD Systems.  The contents may only be viewed by MOD Systems Engineers (employees) and selected Starbucks employees as outlined in the Licensing Agreement between MOD Systems and Starbucks Corporation on June 3rd, 2005.   

No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.  

No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact MOD System's competitive advantage.   

Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.   


</copyright>*/

using System;
using System.Xml;
using System.Xml.Serialization;
using System.ComponentModel;
using MOD.Data;
using System.Data;
using System.Data.SqlClient;
using System.Threading;

using MW.MComm.CarrierSim.BLL.Core;

namespace MW.MComm.CarrierSim.Utility
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to hold basic database access properties.</summary>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[Serializable()]
	public class SqlManager : MOD.Data.SqlManager
	{
		#region "Declarations"

		// for stored procedure info
		//private static XmlDocument m_xmlProcs = null;

		#endregion "Declarations"

		#region "Public Properties"

		#endregion "Public Properties"

		// ------------------------------------------------------------------------------
		/// <summary>This method gets the SQL Proc Adapter.</summary>
		// ------------------------------------------------------------------------------
		public void LogDebugInfo(string debugEvent, string debugInfo)
		{
			LogDebugInfo(debugEvent, 
				debugInfo,
                BLL.Core.EventTypeCode.DebugTrace, 
				BLL.Core.AttributeTypeCode.Logging );
		}

		// ------------------------------------------------------------------------------
		/// <summary>This method gets the SQL Proc Adapter.</summary>
		// ------------------------------------------------------------------------------
        public void LogDebugInfo(string debugEvent, string debugInfo, BLL.Core.EventTypeCode eventType, BLL.Core.AttributeTypeCode attributeType)
		{
			NamedObjectCollection spParams = new NamedObjectCollection();
			BLL.Core.ErrorNumber errorNumber = BLL.Core.ErrorNumber.None;
			spParams["EventName"] = debugEvent;
			spParams["Message"] = debugInfo;
			spParams["ErrorNumber"] = (int) errorNumber;
            spParams["EventTypeCode"] = (int)BLL.Core.EventTypeCode.DebugTrace;
			spParams["SeverityLevelCode"] = (int)BLL.Core.SeverityLevelCode.OK;
			SqlManager logManager = new SqlManager();
			try
			{
				SqlProcAdapter logAdapter = logManager.GetAdapter(_debugLevel, _dbOptions);
				logAdapter.ExecuteProcNQ("spCORE_LogOneDebugLog", null, spParams);
			}
			finally
			{
				logManager.ClearAdapter();
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This method gets the SQL Proc Adapter.</summary>
		// ------------------------------------------------------------------------------
		public void LogError(BLL.Core.ErrorNumber errorNumber, string debugEvent)
		{
			NamedObjectCollection spParams = new NamedObjectCollection();
			spParams["EventName"] = debugEvent;
			spParams["Message"] = BLL.Core.ErrorManager.GetErrorMessageFromErrorNumber(errorNumber);
			spParams["ErrorNumber"] = errorNumber;
            spParams["EventTypeCode"] = (int)BLL.Core.EventTypeCode.ErrorLog;
			spParams["SeverityLevelCode"] = (int)BLL.Core.SeverityLevelCode.CriticalError;
			SqlManager logManager = new SqlManager();
			try
			{
				SqlProcAdapter logAdapter = logManager.GetAdapter(_debugLevel, _dbOptions);
				logAdapter.ExecuteProcNQ("spCORE_LogOneDebugLog", null, spParams);
			}
			finally
			{
				logManager.ClearAdapter();
			}
		}

		#region "Public Methods"

		#endregion "Public Methods"

		#region "Miscellaneous"
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public SqlManager()
		{
			//
			// constructor logic
			//
		}

		private void Adapter_BeforeSPEvent(object o, SqlProcEventArg e)
		{
			SqlCommand cmd = e.Command;
			if(ShouldTraceCommand(cmd))
				try
				{
					LogDebugInfo( cmd.CommandText, SqlExceptionHandler.GetCommandInfo(cmd) );
				}
				catch
				{
					//                    System.Diagnostics.Debugger.Break();
				}
		}

		private void Adapter_AfterSPEvent(object o, SqlProcEventArg e)
		{
			SqlCommand cmd = e.Command;
			if(ShouldLogCommandOnError(cmd))
			{
				BLL.Core.ErrorNumber errorNumber = BLL.Core.ErrorNumber.None;
				foreach(SqlParameter param in cmd.Parameters)
					if( string.Compare(param.ParameterName ,"@SqlErrorNumber",true) == 0 && param.Direction != ParameterDirection.Input && param.Value != DBNull.Value )
					{
						errorNumber = BLL.Core.ErrorManager.GetErrorNumberFromSqlError(MOD.Data.DataHelper.GetInt(param.Value, 0));
					}
				if (errorNumber != BLL.Core.ErrorNumber.None)
					try
					{
						LogError( errorNumber, cmd.CommandText );
					}
					catch
					{
						//						System.Diagnostics.Debugger.Break();
					}
			}
		}

		private bool ShouldTraceCommand(SqlCommand cmd)
		{
			return cmd != null 
				&& string.Compare(cmd.CommandText,"spCORE_LogOneDebugLog",true) != 0
				&& string.Compare(cmd.CommandText,"dbo.spCORE_LogOneDebugLog",true) != 0
				&& _debugLevel > 1;
		}

		private bool ShouldLogCommandOnError(SqlCommand cmd)
		{
			return cmd != null 
				&& string.Compare(cmd.CommandText,"spCORE_LogOneDebugLog",true) != 0
				&& string.Compare(cmd.CommandText,"dbo.spCORE_LogOneDebugLog",true) != 0
				&& _debugLevel > 0;
		}
		#endregion "Miscellaneous"

	}
}
