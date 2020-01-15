

/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Configuration;
using System.Web;
using System.ComponentModel;
using System.Threading;
using System.Collections.Specialized;
using MOD.Data;
using MW.MComm.CarrierSim.BLL.Config;
using MW.MComm.CarrierSim.BLL.Core;
using MW.MComm.CarrierSim.DAL.Core;

namespace MW.MComm.CarrierSim.BLL.Config
{
    public class ConfigurationContext
    {
        #region Static Fields
        /// <summary>
        /// This flag allows DatabaseOptionsProviders to avoid accessing configuration settings 
        /// until the context has been fully loaded.
        /// </summary>
        private static bool _isCurrentContextLoaded = false;
        private static string _connectionString;

        /// <summary>
        /// The debug level.
        /// </summary>
        private static int _debugLevel = 0;

		/// <summary>
		/// The command timeout.
		/// </summary>
		private static int _commandTimeout = 0;
		#endregion

        #region Fields
        #endregion

        #region Static Properties
        /// <summary>
        /// The value retrieved from the discovery service or app config file.
        /// This should only be used for retrieving configuration (the real connection
        /// string should come from the database via an instance of ConfigurationContext).
        /// </summary>
        public static string ConnectionString
        {
            get { return _connectionString; }
        }

		public static MOD.Data.DatabaseOptions DBOptions
		{
			get
			{
				MOD.Data.DatabaseOptions dbOptions = BLL.BusinessObjectManager.DBOptions;
				if (dbOptions == null)
				{
					dbOptions = new MOD.Data.DatabaseOptions();
					dbOptions.ConnectionString = ConnectionString;
					dbOptions.CommandTimeout = CommandTimeout;
				}
				return dbOptions;
			}
		}

		public static MOD.Data.DataOptions DefaultDataOptions
		{
			get
			{
				MOD.Data.DataOptions dataOptions = new MOD.Data.DataOptions();
				Globals.AddRequiredFilterProperties(dataOptions, CurrentUserID);
				return dataOptions;
			}
		}
        /// <summary>
        /// If no value was returned by the discovery service, default to 0 until
        /// loaded from database.
        /// </summary>
        public static int DebugLevel
        {
            get
			{
				return _debugLevel;
			}
        }

		/// <summary>
		/// If no value was returned by the discovery service, default to 0 until
		/// loaded from database.
		/// </summary>
		public static int CommandTimeout
		{
			get { return (int)_commandTimeout; }
		}

		/// <summary>
		/// If no value was returned by the discovery service, default to 0 until
		/// loaded from database.
		/// </summary>
		public static Guid CurrentUserID
		{
			get
			{
				return new Guid();
			}
		}

		public static bool IsCurrentContextLoaded
        {
            get { return _isCurrentContextLoaded; }
        }
        #endregion

        #region Properties

        public ConfigurationValueList AllValues
        {
            get { return GetRelevantConfigurationValues(true, true, true); }
        }
        #endregion

        public static ConfigurationContext Current
        {
            get
            {
                ConfigurationContext context = new ConfigurationContext();

                // this flag only needs to be set once after the first time the configuration context is loaded.
                _isCurrentContextLoaded = true;

                return context;
            }
        }

        #region Static Constructor
        /// <summary>
        /// The Connection String is necessary for retrieving all other configuration values.
        /// 
        /// Previously, when this code was used from the FlashLauncher, an event was used to signal the response
        /// from the discovery service. The event wasn't firing when called from this static constructor, probably
        /// due to thread marshalling issues. So, this method now checks the client.ResponseCache directly
        /// </summary>
        static ConfigurationContext()
        {
			// Check local app settings
			_connectionString = ConfigurationManager.AppSettings["ConnectionString"];

			if (ConfigurationManager.AppSettings["DBCommandTimeout"] != null)
			{
				_commandTimeout = int.Parse(ConfigurationManager.AppSettings["DBCommandTimeout"]);
			}

			if (_connectionString == null)
			{
				_connectionString = ConfigurationManager.AppSettings["DBConnectionString"];
			}

			if (ConfigurationManager.AppSettings["DebugLevel"] != null)
			{
				_debugLevel = int.Parse(ConfigurationManager.AppSettings["DebugLevel"]);
			}
        }
        #endregion

		public ConfigurationValueList GetRelevantConfigurationValues(bool includeBootstrapValues,
			bool includeAppConfig, bool includeCookies)
		{
			ConfigurationValueList mergedList = new ConfigurationValueList();

			if (includeBootstrapValues)
			{
				// Add the "bootstrap" values to the list
				mergedList.Add(new ConfigurationValue("ConnectionString", ConnectionString, "Bootstrap"));
				mergedList.Add(new ConfigurationValue("CommandTimeout", CommandTimeout.ToString(), "Bootstrap"));
				mergedList.Add(new ConfigurationValue("DebugLevel", DebugLevel.ToString(), "Bootstrap"));
			}

			if (includeAppConfig)
			{
				// Override again with app.config settings
				foreach (string key in ConfigurationManager.AppSettings.Keys)
				{
					ConfigurationValue cv = new ConfigurationValue(key, ConfigurationManager.AppSettings[key], "AppSettings");
					mergedList.Merge(cv);
				}
			}

			if (includeCookies)
			{
				// Override again with cookie values (useful for changing the connection string when connecting to Web site)
				if (HttpContext.Current != null)
				{
					foreach (string key in HttpContext.Current.Request.Cookies.Keys)
					{
						ConfigurationValue cv = new ConfigurationValue(key,
							HttpUtility.UrlDecode(HttpContext.Current.Request.Cookies[key].Value), "Cookie");
						mergedList.Merge(cv);
					}
				}
			}

			return mergedList;
		}
	}
}