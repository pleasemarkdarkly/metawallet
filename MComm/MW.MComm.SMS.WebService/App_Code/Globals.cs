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
using System.Text;
using System.Text.RegularExpressions; 
using System.ComponentModel;
using System.Configuration;
using System.Threading;
using System.IO;
using MW.MComm.SMS;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;
using MOD.Data;
using MW.MComm.SMS.BLL;
using BLL = MW.MComm.SMS.BLL;


namespace MW.MComm.SMS.WebService
{
	// ------------------------------------------------------------------------------
	/// <summary>This class contains global methods and properties for the web service layer.</summary>
	/// 
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public class Globals : ApplicationOptionsProvider
	{
		#region "Declarations"
		#endregion "Declarations"

		#region "Constants And Enumerations"
		#endregion "Constants And Enumerations"

		#region "Public Static Properties"

		// ------------------------------------------------------------------
		/// <summary>This method retrieves the debug level setting from the system configuration.</summary>
		// ------------------------------------------------------------------
		public static Guid CurrentUserID
		{
			get
			{  
				return MOD.Data.DefaultValue.Guid;
			}
		}
		public override Guid ApplicationUserID
		{
			get
			{
				return CurrentUserID;
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method retrieves the debug level setting from the system configuration.</summary>
		// ------------------------------------------------------------------
		public static int DebugLevel
		{
			get
			{  
				// get the debug level from the application setting
				return Globals.getAppSettingInt("DebugLevel", 0);
			}
		}
		public override int ApplicationDebugLevel
		{
			get
			{
				// get the debug level from the application setting
				return DebugLevel;
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method retrieves the database connection string from the system configuration.</summary>
		// ------------------------------------------------------------------
		public static string DBConnectionString
		{
			get
			{  
				// get the database connection string from the application setting
				// TODO: this should be encrypted if not handled by enterprise application blocks
				return Globals.getAppSettingString("DBConnectionString", "");
			}
		}
   
		// ------------------------------------------------------------------
		/// <summary>This method retrieves the database timeout setting from the system configuration.</summary>
		// ------------------------------------------------------------------
		public static int DBCommandTimeout
		{
			get
			{  
				// get the database timeout setting from the application setting
				return Globals.getAppSettingInt("DBCommandTimeout", 60);
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method retrieves the application database options.</summary>
		// ------------------------------------------------------------------
		public static MOD.Data.DatabaseOptions DBOptions
		{
			get
			{
				MOD.Data.DatabaseOptions databaseOptions = (MOD.Data.DatabaseOptions) Globals.getAppCacheObject("DBOptions");

				// build new database options if not in application cache
				if (databaseOptions == null)
				{
					databaseOptions = new MOD.Data.DatabaseOptions();
					databaseOptions.ConnectionString = Globals.DBConnectionString;
					databaseOptions.CommandTimeout = Globals.DBCommandTimeout;
					Globals.setAppCacheObject("DBOptions", databaseOptions, Globals.DefaultMinutesInAppCache);
				}
				return databaseOptions;
			}
		}
		public override MOD.Data.DatabaseOptions ApplicationDBOptions
		{
			get
			{
				// get the database options
				return DBOptions;
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method retrieves the default minutes data should stay in the application cache the system configuration.</summary>
		// ------------------------------------------------------------------
		public static int DefaultMinutesInAppCache
		{
			get
			{  
				// get the database timeout setting from the application setting
				return Globals.getAppSettingInt("DefaultMinutesInAppCache", 60);
			}
		}

		// ------------------------------------------------------------------
		/// <summary>Returns the Enterprise Caching Library</summary>
		// ------------------------------------------------------------------
        public static CacheManager Cache
        {
            get
            {
                return CacheFactory.GetCacheManager();
            }
        }


		#endregion "Public Static Properties"

		#region "Public Static Methods"

		// ------------------------------------------------------------------
		/// <summary>Get the selected object from the application cache.</summary>
		/// 
		/// <param name="cacheSettingKey">The key ID of the cache to get an object from</param>
		/// <returns>The object that results from the cache data</returns>
		// ------------------------------------------------------------------
		public static object getAppCacheObject(string cacheSettingKey)
		{
			// get the object from the cache
			return Globals.Cache.GetData(cacheSettingKey);
		}

		// ------------------------------------------------------------------
		/// <summary>Store the selected object to the application cache.</summary>
		/// 
		/// <param name="cacheSettingKey">The key value of the cache where the object will be stored</param>
		/// <param name="cacheObject">The object to be stored</param>
		/// <param name="minutesInCache">The time (in minutes) that the object should be store in the cache</param>
		// ------------------------------------------------------------------
		public static void setAppCacheObject(string cacheSettingKey, object cacheObject, int minutesInCache)
		{
			// set the object to the cache
			Globals.Cache.Add(cacheSettingKey, cacheObject, CacheItemPriority.Normal, null, new SlidingTime(TimeSpan.FromMinutes(minutesInCache)));
		}

		// ------------------------------------------------------------------
		/// <summary>Store the selected object to the application cache (using default minutes in cache).</summary>
		/// 
		/// <param name="cacheSettingKey"></param>
		/// <param name="cacheObject"></param>
		// ------------------------------------------------------------------
		public static void setAppCacheObject(string cacheSettingKey, object cacheObject)
		{
			// set the object to the cache
			Globals.setAppCacheObject(cacheSettingKey, cacheObject, Globals.DefaultMinutesInAppCache);
		}

		// ------------------------------------------------------------------
		/// <summary>Store the selected object to the application cache.</summary>
		/// 
		/// <param name="cacheSettingKey">The key value of the cache where the object will be stored</param>
		/// <param name="cacheObject">The object to be stored</param>
		/// <param name="minutesInCache">The time (in minutes) that the object should be store in the cache</param>
		// ------------------------------------------------------------------
		public static void setAppCacheObject(string cacheSettingKey, object cacheObject, CacheItemPriority priority, 
			int minutesInCache)
		{
			// set the object to the cache
			Globals.Cache.Add(cacheSettingKey, cacheObject, priority, null, 
				new SlidingTime(TimeSpan.FromMinutes(minutesInCache)));
		}

		// ------------------------------------------------------------------
		/// <summary>Get the application setting as a string.</summary>
		/// 
		/// <param name="appSettingKey">The key value of the AppSetting to be referenced</param>
		/// <param name="defaultValue">The default value to get if the AppSetting is empty</param>
		/// <returns>The string representing the value of the AppSetting</returns>
		// ------------------------------------------------------------------
		public static string getAppSettingString(string appSettingKey, string defaultValue)
		{
			// get app setting as a string
			return MOD.Data.DataHelper.GetString(System.Configuration.ConfigurationSettings.AppSettings[appSettingKey], defaultValue);

		}

		// ------------------------------------------------------------------
		/// <summary>Get the application setting as an int.</summary>
		/// 
		/// <param name="appSettingKey">The key value of the AppSetting to be referenced</param>
		/// <param name="defaultValue">The default value to get if the AppSetting is empty</param>
		/// <returns>The string representing the value of the AppSetting</returns>
		// ------------------------------------------------------------------
		public static int getAppSettingInt(string appSettingKey, int defaultValue)
		{
			// get app setting as an int
			return MOD.Data.DataHelper.GetInt(System.Configuration.ConfigurationSettings.AppSettings[appSettingKey], defaultValue);
		}

		// ------------------------------------------------------------------
		/// <summary>Get the application setting as a bool.</summary>
		/// 
		/// <param name="appSettingKey">The key value of the AppSetting to be referenced</param>
		/// <param name="defaultValue">The default value to get if the AppSetting is empty</param>
		/// <returns>The string representing the value of the AppSetting</returns>
		// ------------------------------------------------------------------
		public static bool getAppSettingBool(string appSettingKey, bool defaultValue)
		{
			// get app setting as a bool
			return MOD.Data.DataHelper.GetBool(System.Configuration.ConfigurationSettings.AppSettings[appSettingKey], defaultValue);
		}

		// ------------------------------------------------------------------
		/// <summary>Get a list options instance, based on input sort and direction.</summary>
		/// 
		/// <param name="sortColumn">The column to sort by</param>
		/// <param name="sortDirection">The direction to sort by</param>
		/// <returns>A ListOptions instance, based on sortColumn and sortDirection</returns>
		// ------------------------------------------------------------------
		public static MOD.Data.DataOptions getDataOptions(string sortColumn, string sortDirection)
		{
			// populate new list options with sort and direction
			MOD.Data.DataOptions newOptions = new MOD.Data.DataOptions();
			newOptions.IncludeInactive = true;
			newOptions.IncludeDateInactive = true;
			newOptions.SortColumn = sortColumn.Trim();
			newOptions.SortDirection = MOD.Data.SortDirection.Ascending;
			if ((sortDirection.ToLower().Trim() == "descending") || (sortDirection.ToLower().Trim() == "desc"))
			{
				newOptions.SortDirection = MOD.Data.SortDirection.Descending;
			}
			else if ((sortDirection.ToLower().Trim() == "random") || (sortDirection.ToLower().Trim() == "rand"))
			{
				newOptions.SortDirection = MOD.Data.SortDirection.Random;
			}
			return newOptions;
		}

		// ------------------------------------------------------------------
		/// <summary>Get a list options instance, based on input sort and direction.</summary>
		/// 
		/// <param name="sortColumn">The column to sort by</param>
		/// <param name="sortDirection">The direction to sort by</param>
		/// <returns>A ListOptions instance, based on sortColumn and sortDirection</returns>
		// ------------------------------------------------------------------
		public static MOD.Data.DataOptions getDataOptions(string sortColumn, string sortDirection, NamedObjectCollection filterFields)
		{
			// populate new list options with sort and direction
			MOD.Data.DataOptions newOptions = new MOD.Data.DataOptions();
			newOptions.IncludeInactive = true;
			newOptions.IncludeDateInactive = true;
			newOptions.SortColumn = sortColumn.Trim();
			newOptions.SortDirection = MOD.Data.SortDirection.Ascending;
			newOptions.FilterFields = filterFields;
			if ((sortDirection.ToLower().Trim() == "descending") || (sortDirection.ToLower().Trim() == "desc"))
			{
				newOptions.SortDirection = MOD.Data.SortDirection.Descending;
			}
			else if ((sortDirection.ToLower().Trim() == "random") || (sortDirection.ToLower().Trim() == "rand"))
			{
				newOptions.SortDirection = MOD.Data.SortDirection.Random;
			}
			return newOptions;
		}

		// ------------------------------------------------------------------
		/// <summary>Get a list options instance, based on input sort and direction.</summary>
		/// 
		/// <param name="sortColumn">The column to sort by</param>
		/// <param name="sortDirection">The direction to sort by</param>
		/// <returns>A ListOptions instance, based on sortColumn and sortDirection</returns>
		// ------------------------------------------------------------------
		public static MOD.Data.DataOptions getDataOptions(string sortColumn, string sortDirection, NamedObjectCollection filterFields, int startIndex, int pageSize, int maximumListSize)
		{
			// populate new list options with sort and direction
			MOD.Data.DataOptions newOptions = getDataOptions(sortColumn, sortDirection, filterFields);
			newOptions.StartIndex = startIndex;
			newOptions.PageSize = pageSize;
			newOptions.MaximumListSize = maximumListSize;
			newOptions.FilterFields = filterFields;
			return newOptions;
		}

		// ------------------------------------------------------------------
		/// <summary>Get a list options instance, based on input sort and direction.</summary>
		/// 
		/// <param name="sortColumn">The column to sort by</param>
		/// <param name="sortDirection">The direction to sort by</param>
		/// <returns>A ListOptions instance, based on sortColumn and sortDirection</returns>
		// ------------------------------------------------------------------
		public static MOD.Data.DataOptions getDataOptions(string sortColumn, string sortDirection, int startIndex, int pageSize, int maximumListSize)
		{
			// populate new list options with sort and direction
			MOD.Data.DataOptions newOptions = getDataOptions(sortColumn, sortDirection);
			newOptions.StartIndex = startIndex;
			newOptions.PageSize = pageSize;
			newOptions.MaximumListSize = maximumListSize;
			return newOptions;
		}

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
