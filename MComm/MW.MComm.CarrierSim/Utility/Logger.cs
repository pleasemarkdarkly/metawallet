/*<copyright>
 MOD Systems, Inc (c) 2005 All Rights Reserved. 720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036 
All Rights Reserved, (c) 2005, covered by Trademark Laws, contents are considered Restricted Secrets 
by MOD Systems.  The contents also may only be viewed by MOD Systems Engineers (employees) and selected 
SBUX employees as outlined in the Licensing Agreement between MOD Systems and Starbuck Corporation on 
June 3rd, 2005.   
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, 
read, or have access to any part or whole of software source code.  If you have done so, immediatly 
report yourself to your manager. 
Do not reproduce any portions of this software.  Unauthorized use or disclosure of this information 
could impact MOD System's competitive advantage.   
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel 
or otherwise, to any intellectual property rights is granted in this source code.   
CONFIDENTIAL SOURCE CODE
</copyright>*/

using System;
using System.Configuration;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;

using MOD.Data;
using MW.MComm.CarrierSim.Utility;
using MW.MComm.CarrierSim.BLL.Core;

namespace MW.MComm.CarrierSim.Utility
{
	/// <summary>
	/// Summary description for Logger.
	/// </summary>
	public class Logger
	{
		public static void Log(Exception ex, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			Log(BLL.Core.ErrorNumber.GeneralException, ex.GetType().ToString(), 
				ex.Message + "\n" + ex.StackTrace,
				BLL.Core.SeverityLevelCode.CriticalError, BLL.Core.EventTypeCode.ErrorLog, dbOptions, debugLevel, currentUserID);
		}

		public static void Log(CustomAppException ex, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			string name = ex.EventName;
			string message = ex.Message;

            Exception innerException = ex.InnerException;

			while (innerException != null)
			{
				message += string.Format("\nInner Exception: {0}\n{1}", innerException.GetType().ToString(), innerException.Message);
                innerException = innerException.InnerException;
			}

			BLL.Core.DebugLog entry = new BLL.Core.DebugLog();
			entry.ErrorNumber = (int)ex.ErrorNumber;
			entry.EventName = name;
			entry.CreatedByUserID = MOD.Data.DefaultValue.Guid;
			entry.Message = message;
			entry.SeverityLevelCode = (int)ex.SeverityLevel;
			entry.EventTypeCode = (int)ex.EventTypeCode;
			entry.DebugAttributeValueLogList = new MW.MComm.CarrierSim.BLL.SortableList<DebugAttributeValueLog>();

			BLL.Core.DebugAttributeValueLog newAttribute = new BLL.Core.DebugAttributeValueLog();
			for (int i = 0; i < ex.DebugAttributeValues.Count; ++i)
			{
				BLL.Core.DebugAttributeValueLog valueLog = new DebugAttributeValueLog();
				MOD.Data.ReflectionHelper.Copy(ex.DebugAttributeValues[i], valueLog);
				entry.DebugAttributeValueLogList.Add(valueLog);
			}

			// Add any property values to the DebugAttributeValues array list.
			// Enumerate through all the properties of the object.
			PropertyInfo[] props = ex.GetType().GetProperties();
			for (int i = 0; i < props.Length; ++i)
			{
				object[] attDebugAttributeValues = props[i].GetCustomAttributes( typeof( DebugAttributeValueAttribute ), true );
				if ((attDebugAttributeValues != null) && (attDebugAttributeValues.Length > 0))
				{
					DebugAttributeValueAttribute dava = attDebugAttributeValues[0] as DebugAttributeValueAttribute;
					object oValue = props[i].GetValue( ex, null );

					// If the property has a default value attribute and the property's value matches that
					// default value then don't log it.
					object[] attDefaultValues = props[i].GetCustomAttributes( typeof( DefaultValueAttribute ), true );
					if ((attDefaultValues != null) && (attDefaultValues.Length > 0))
					{
						DefaultValueAttribute dva = attDefaultValues[0] as DefaultValueAttribute;
						if (dva.Value.Equals( oValue ))
							continue;
					}

					BLL.Core.DebugAttributeValueLog dav = new BLL.Core.DebugAttributeValueLog();
					BLL.Core.DebugAttribute debugAttribute = BLL.Core.DebugAttributeManager.GetOneDebugAttributeByAttributeCode((int)dava.AttributeCode, dbOptions, new DataOptions(), debugLevel, currentUserID);
					if (debugAttribute != null)
					{
						dav.BaseAttributeID = debugAttribute.BaseAttributeID;
					}
					dav.AttributeValue = oValue.ToString();
					entry.DebugAttributeValueLogList.Add( dav );
				}
			}

			BLL.Core.DebugLogManager.LogOneDebugLog(entry, true, dbOptions, debugLevel, currentUserID);
		}

        public static EventLogEntryType GetType(BLL.Core.EventTypeCode type)
		{
			if (type == BLL.Core.EventTypeCode.DebugTrace)
				return EventLogEntryType.Information;
			else // if (type == Globals.EventType.ErrorLog)
				return EventLogEntryType.Error;
		}

        /// <summary>
        /// A helper function to simplify logging.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="name"></param>
        /// <param name="message"></param>
		public static void Log(BLL.Core.ErrorNumber number, string name, string message, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
        {
			Log(number, name, message, BLL.Core.SeverityLevelCode.OK, BLL.Core.EventTypeCode.DebugTrace, new BLL.Core.DebugAttributeValueLog[0], dbOptions, debugLevel, currentUserID);
        }

        /// <summary>
        /// NOTE: Ignores app.config "DebugLevel" setting when determining what to log. However,
        /// does pass it through to the CoreLib so that it can filter messages appropriately.
        /// So, Publishing status messages are logged using this function with SeverityLevel.None,
        /// but are logged regardless of "DebugLevel"
        /// 
        /// Appends StoreNumber attribute to every log entry
        /// </summary>
        /// <param name="number"></param>
        /// <param name="name"></param>
        /// <param name="message"></param>
        /// <param name="level"></param>
        /// <param name="type"></param>
        /// <param name="values"></param>
		public static void Log(BLL.Core.ErrorNumber number, string name, string message, BLL.Core.SeverityLevelCode level,
			BLL.Core.EventTypeCode type, BLL.Core.DebugAttributeValueLog[] values, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
        {
            //MSLog.Logger.Write((name == null ? string.Empty : name + ": ") +
            //    (message == null ? string.Empty : message), "Trace");

			BLL.Core.DebugLog entry = new BLL.Core.DebugLog();

            entry.ErrorNumber = (int)number;
            entry.EventName = name;
            entry.Message = message;
            entry.SeverityLevelCode = (int)level;
            entry.EventTypeCode = (int)type;
            entry.DebugAttributeValueLogList = new MW.MComm.CarrierSim.BLL.SortableList<DebugAttributeValueLog>();

            // add default attribute values
			foreach (BLL.Core.DebugAttributeValueLog value in values)
            {
				BLL.Core.DebugAttributeValueLog logEntry = new BLL.Core.DebugAttributeValueLog();
                logEntry.AttributeValue = value.AttributeValue;
                logEntry.BaseAttributeID = value.BaseAttributeID;
                entry.DebugAttributeValueLogList.Add(logEntry);
            }

			// TODO: get configuration context
			BLL.Core.DebugLogManager.LogOneDebugLog(entry, true, dbOptions, debugLevel, currentUserID);
        }

		public static void Log(BLL.Core.ErrorNumber number, string name, string message, BLL.Core.SeverityLevelCode level, BLL.Core.EventTypeCode type, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			BLL.Core.DebugLog entry = new BLL.Core.DebugLog();
			entry.ErrorNumber = (int)number; // (int)Globals..InventoryOverride;
			entry.EventName = name;
			entry.CreatedByUserID = currentUserID;
			entry.Message = message;
			entry.SeverityLevelCode = (int)level;
			entry.EventTypeCode = (int)type;
			entry.DebugAttributeValueLogList = new MW.MComm.CarrierSim.BLL.SortableList<DebugAttributeValueLog>();

			BLL.Core.DebugAttributeValueLog newAttribute = new BLL.Core.DebugAttributeValueLog();

			BLL.Core.DebugLogManager.LogOneDebugLog(entry, true, dbOptions, debugLevel, currentUserID);
		}
	}
}
