

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
using MW.MComm.Ganadero.BLL.Config;
using MW.MComm.Ganadero.BLL.Core;
using MW.MComm.Ganadero.DAL.Core;

namespace MW.MComm.Ganadero.BLL.Config
{
	public class ConfigurationInterface
	{

		#region Static Properties
		public static MOD.Data.DatabaseOptions DBOptions
		{
			get
			{
				MOD.Data.DatabaseOptions dbOptions = BLL.BusinessObjectManager.DBOptions;
				if (dbOptions == null)
				{
					dbOptions = ConfigurationContext.DBOptions;
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
				return BusinessObjectManager.DebugLevel;
			}
		}

		/// <summary>
		/// If no value was returned by the discovery service, default to 0 until
		/// loaded from database.
		/// </summary>
		public static Guid CurrentUserID
		{
			get
			{
				return BusinessObjectManager.ApplicationUserID;
			}
		}

		#endregion


		#region Static Constructor
		/// <summary>
		/// </summary>
		static ConfigurationInterface()
		{
		}
		#endregion
	}
}