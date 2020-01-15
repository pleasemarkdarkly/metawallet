
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
using MW.MComm.WalletSolution.BLL.Notifications;
using MOD.Data;
using MW.MComm.WalletSolution.BLL.Config;
using BLL = MW.MComm.WalletSolution.BLL;
using DAL = MW.MComm.WalletSolution.DAL;
using Utility = MW.MComm.WalletSolution.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
namespace MW.MComm.WalletSolution.BLL.Notifications
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage NotificationLog related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class NotificationLogManager
	{
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public NotificationLogManager()
		{
			//
			// constructor logic
			//
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------
		/// <summary>This method gets all NotificationLog data.</summary>
		///
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Notifications.NotificationLog> GetAllNotificationLogData(MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Notifications.NotificationLogManager.GetAllNotificationLogData(BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all NotificationLog data.</summary>
		///
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Notifications.NotificationLog> GetAllNotificationLogData()
		{
			// perform main method tasks
			return BLL.Notifications.NotificationLogManager.GetAllNotificationLogData(BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all NotificationLog data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Notifications.NotificationLog> GetAllNotificationLogData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Notifications.NotificationLog> sortableList = new BLL.SortableList<BLL.Notifications.NotificationLog>(DAL.Notifications.NotificationLog.GetAllNotificationLogData(dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Notifications.NotificationLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Notifications.GetAllNotificationLogData");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all NotificationLog data by criteria.</summary>
		///
		/// <param name="notificationCode">A key for NotificationLog items to be fetched</param>
		/// <param name="localeCode">A key for NotificationLog items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for NotificationLog items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for NotificationLog items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Notifications.NotificationLog> GetAllNotificationLogDataByCriteria(int? notificationCode, int? localeCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Notifications.NotificationLogManager.GetAllNotificationLogDataByCriteria(notificationCode, localeCode, lastModifiedDateStart, lastModifiedDateEnd, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all NotificationLog data by criteria.</summary>
		///
		/// <param name="notificationCode">A key for NotificationLog items to be fetched</param>
		/// <param name="localeCode">A key for NotificationLog items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for NotificationLog items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for NotificationLog items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Notifications.NotificationLog> GetAllNotificationLogDataByCriteria(int? notificationCode, int? localeCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd)
		{
			// perform main method tasks
			return BLL.Notifications.NotificationLogManager.GetAllNotificationLogDataByCriteria(notificationCode, localeCode, lastModifiedDateStart, lastModifiedDateEnd, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all NotificationLog data by criteria.</summary>
		///
		/// <param name="notificationCode">A key for NotificationLog items to be fetched</param>
		/// <param name="localeCode">A key for NotificationLog items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for NotificationLog items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for NotificationLog items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Notifications.NotificationLog> GetAllNotificationLogDataByCriteria(int? notificationCode, int? localeCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Notifications.NotificationLog> sortableList = new BLL.SortableList<BLL.Notifications.NotificationLog>(DAL.Notifications.NotificationLog.GetAllNotificationLogDataByCriteria(notificationCode, localeCode, lastModifiedDateStart, lastModifiedDateEnd, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Notifications.NotificationLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Notifications.GetAllNotificationLogDataByCriteria");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all NotificationLog data by a key.</summary>
		///
		/// <param name="localeCode">A key for NotificationLog items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Notifications.NotificationLog> GetAllNotificationLogDataByLocaleCode(int localeCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Notifications.NotificationLogManager.GetAllNotificationLogDataByLocaleCode(localeCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all NotificationLog data by a key.</summary>
		///
		/// <param name="localeCode">A key for NotificationLog items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Notifications.NotificationLog> GetAllNotificationLogDataByLocaleCode(int localeCode)
		{
			// perform main method tasks
			return BLL.Notifications.NotificationLogManager.GetAllNotificationLogDataByLocaleCode(localeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all NotificationLog data by a key.</summary>
		///
		/// <param name="localeCode">A key for NotificationLog items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Notifications.NotificationLog> GetAllNotificationLogDataByLocaleCode(int localeCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Notifications.NotificationLog> sortableList = new BLL.SortableList<BLL.Notifications.NotificationLog>(DAL.Notifications.NotificationLog.GetAllNotificationLogDataByLocaleCode(localeCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Notifications.NotificationLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Notifications.GetAllNotificationLogDataByLocaleCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all NotificationLog data by a key.</summary>
		///
		/// <param name="notificationCode">A key for NotificationLog items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Notifications.NotificationLog> GetAllNotificationLogDataByNotificationCode(int notificationCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Notifications.NotificationLogManager.GetAllNotificationLogDataByNotificationCode(notificationCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all NotificationLog data by a key.</summary>
		///
		/// <param name="notificationCode">A key for NotificationLog items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Notifications.NotificationLog> GetAllNotificationLogDataByNotificationCode(int notificationCode)
		{
			// perform main method tasks
			return BLL.Notifications.NotificationLogManager.GetAllNotificationLogDataByNotificationCode(notificationCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all NotificationLog data by a key.</summary>
		///
		/// <param name="notificationCode">A key for NotificationLog items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Notifications.NotificationLog> GetAllNotificationLogDataByNotificationCode(int notificationCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Notifications.NotificationLog> sortableList = new BLL.SortableList<BLL.Notifications.NotificationLog>(DAL.Notifications.NotificationLog.GetAllNotificationLogDataByNotificationCode(notificationCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Notifications.NotificationLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Notifications.GetAllNotificationLogDataByNotificationCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all NotificationLog data by criteria.</summary>
		///
		/// <param name="notificationCode">A key for NotificationLog items to be fetched</param>
		/// <param name="localeCode">A key for NotificationLog items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for NotificationLog items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for NotificationLog items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Notifications.NotificationLog> GetManyNotificationLogDataByCriteria(int? notificationCode, int? localeCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Notifications.NotificationLogManager.GetManyNotificationLogDataByCriteria(notificationCode, localeCode, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all NotificationLog data by criteria.</summary>
		///
		/// <param name="notificationCode">A key for NotificationLog items to be fetched</param>
		/// <param name="localeCode">A key for NotificationLog items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for NotificationLog items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for NotificationLog items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Notifications.NotificationLog> GetManyNotificationLogDataByCriteria(int? notificationCode, int? localeCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Notifications.NotificationLog> sortableList = new BLL.SortableList<BLL.Notifications.NotificationLog>(DAL.Notifications.NotificationLog.GetManyNotificationLogDataByCriteria(notificationCode, localeCode, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Notifications.NotificationLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Notifications.GetManyNotificationLogDataByCriteria");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single NotificationLog by an index.</summary>
		///
		/// <param name="notificationLogID">The index for NotificationLog to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Notifications.NotificationLog GetOneNotificationLog(Guid notificationLogID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Notifications.NotificationLogManager.GetOneNotificationLog(notificationLogID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single NotificationLog by an index.</summary>
		///
		/// <param name="notificationLogID">The index for NotificationLog to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Notifications.NotificationLog GetOneNotificationLog(Guid notificationLogID)
		{
			// perform main method tasks
			return BLL.Notifications.NotificationLogManager.GetOneNotificationLog(notificationLogID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single NotificationLog by an index.</summary>
		///
		/// <param name="notificationLogID">The index for NotificationLog to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Notifications.NotificationLog GetOneNotificationLog(Guid notificationLogID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.Notifications.NotificationLog itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.Notifications.NotificationLog)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.Notifications.NotificationLog.GetCacheKey(typeof(BLL.Notifications.NotificationLog), "PrimaryKey", notificationLogID.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.Notifications.NotificationLog)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.Notifications.NotificationLog item = DAL.Notifications.NotificationLog.GetOneNotificationLog(notificationLogID, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.Notifications.NotificationLog();
						ReflectionHelper.Copy(item, itemBLL, true);
						itemBLL.ClearDirtyState(true);
						itemBLL.IsLoaded = true;
						if (useCache == true)
						{
							Utility.CacheManager.Cache.Add(key, itemBLL);
						}
					}
				}
				return itemBLL;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Notifications.GetOneNotificationLog");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method logs NotificationLog data.</summary>
		///
		/// <param name="item">The NotificationLog to be logged.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void LogOneNotificationLog(BLL.Notifications.NotificationLog item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Notifications.NotificationLogManager.LogOneNotificationLog(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method logs NotificationLog data.</summary>
		///
		/// <param name="item">The NotificationLog to be logged.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void LogOneNotificationLog(BLL.Notifications.NotificationLog item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Notifications.NotificationLog itemDAL = new DAL.Notifications.NotificationLog();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Notifications.NotificationLog.LogOneNotificationLog(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Notifications.LogOneNotificationLog");
			}
		}
		#endregion Methods
	}
}