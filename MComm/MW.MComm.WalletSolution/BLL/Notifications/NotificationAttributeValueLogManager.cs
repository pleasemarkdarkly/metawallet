
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
	/// <summary>This class is used to manage NotificationAttributeValueLog related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class NotificationAttributeValueLogManager
	{
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public NotificationAttributeValueLogManager()
		{
			//
			// constructor logic
			//
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------
		/// <summary>This method gets all NotificationAttributeValueLog data.</summary>
		///
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Notifications.NotificationAttributeValueLog> GetAllNotificationAttributeValueLogData(MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Notifications.NotificationAttributeValueLogManager.GetAllNotificationAttributeValueLogData(BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all NotificationAttributeValueLog data.</summary>
		///
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Notifications.NotificationAttributeValueLog> GetAllNotificationAttributeValueLogData()
		{
			// perform main method tasks
			return BLL.Notifications.NotificationAttributeValueLogManager.GetAllNotificationAttributeValueLogData(BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all NotificationAttributeValueLog data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Notifications.NotificationAttributeValueLog> GetAllNotificationAttributeValueLogData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Notifications.NotificationAttributeValueLog> sortableList = new BLL.SortableList<BLL.Notifications.NotificationAttributeValueLog>(DAL.Notifications.NotificationAttributeValueLog.GetAllNotificationAttributeValueLogData(dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Notifications.NotificationAttributeValueLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Notifications.GetAllNotificationAttributeValueLogData");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all NotificationAttributeValueLog data by a key.</summary>
		///
		/// <param name="baseAttributeValueID">A key for NotificationAttributeValueLog items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Notifications.NotificationAttributeValueLog> GetAllNotificationAttributeValueLogDataByBaseAttributeValueID(Guid baseAttributeValueID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Notifications.NotificationAttributeValueLogManager.GetAllNotificationAttributeValueLogDataByBaseAttributeValueID(baseAttributeValueID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all NotificationAttributeValueLog data by a key.</summary>
		///
		/// <param name="baseAttributeValueID">A key for NotificationAttributeValueLog items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Notifications.NotificationAttributeValueLog> GetAllNotificationAttributeValueLogDataByBaseAttributeValueID(Guid baseAttributeValueID)
		{
			// perform main method tasks
			return BLL.Notifications.NotificationAttributeValueLogManager.GetAllNotificationAttributeValueLogDataByBaseAttributeValueID(baseAttributeValueID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all NotificationAttributeValueLog data by a key.</summary>
		///
		/// <param name="baseAttributeValueID">A key for NotificationAttributeValueLog items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Notifications.NotificationAttributeValueLog> GetAllNotificationAttributeValueLogDataByBaseAttributeValueID(Guid baseAttributeValueID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Notifications.NotificationAttributeValueLog> sortableList = new BLL.SortableList<BLL.Notifications.NotificationAttributeValueLog>(DAL.Notifications.NotificationAttributeValueLog.GetAllNotificationAttributeValueLogDataByBaseAttributeValueID(baseAttributeValueID, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Notifications.NotificationAttributeValueLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Notifications.GetAllNotificationAttributeValueLogDataByBaseAttributeValueID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all NotificationAttributeValueLog data by criteria.</summary>
		///
		/// <param name="attributeValue">A key for NotificationAttributeValueLog items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for NotificationAttributeValueLog items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for NotificationAttributeValueLog items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Notifications.NotificationAttributeValueLog> GetAllNotificationAttributeValueLogDataByCriteria(string attributeValue, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Notifications.NotificationAttributeValueLogManager.GetAllNotificationAttributeValueLogDataByCriteria(attributeValue, lastModifiedDateStart, lastModifiedDateEnd, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all NotificationAttributeValueLog data by criteria.</summary>
		///
		/// <param name="attributeValue">A key for NotificationAttributeValueLog items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for NotificationAttributeValueLog items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for NotificationAttributeValueLog items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Notifications.NotificationAttributeValueLog> GetAllNotificationAttributeValueLogDataByCriteria(string attributeValue, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd)
		{
			// perform main method tasks
			return BLL.Notifications.NotificationAttributeValueLogManager.GetAllNotificationAttributeValueLogDataByCriteria(attributeValue, lastModifiedDateStart, lastModifiedDateEnd, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all NotificationAttributeValueLog data by criteria.</summary>
		///
		/// <param name="attributeValue">A key for NotificationAttributeValueLog items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for NotificationAttributeValueLog items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for NotificationAttributeValueLog items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Notifications.NotificationAttributeValueLog> GetAllNotificationAttributeValueLogDataByCriteria(string attributeValue, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Notifications.NotificationAttributeValueLog> sortableList = new BLL.SortableList<BLL.Notifications.NotificationAttributeValueLog>(DAL.Notifications.NotificationAttributeValueLog.GetAllNotificationAttributeValueLogDataByCriteria(attributeValue, lastModifiedDateStart, lastModifiedDateEnd, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Notifications.NotificationAttributeValueLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Notifications.GetAllNotificationAttributeValueLogDataByCriteria");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all NotificationAttributeValueLog data by a key.</summary>
		///
		/// <param name="notificationLogID">A key for NotificationAttributeValueLog items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Notifications.NotificationAttributeValueLog> GetAllNotificationAttributeValueLogDataByNotificationLogID(Guid notificationLogID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Notifications.NotificationAttributeValueLogManager.GetAllNotificationAttributeValueLogDataByNotificationLogID(notificationLogID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all NotificationAttributeValueLog data by a key.</summary>
		///
		/// <param name="notificationLogID">A key for NotificationAttributeValueLog items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Notifications.NotificationAttributeValueLog> GetAllNotificationAttributeValueLogDataByNotificationLogID(Guid notificationLogID)
		{
			// perform main method tasks
			return BLL.Notifications.NotificationAttributeValueLogManager.GetAllNotificationAttributeValueLogDataByNotificationLogID(notificationLogID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all NotificationAttributeValueLog data by a key.</summary>
		///
		/// <param name="notificationLogID">A key for NotificationAttributeValueLog items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Notifications.NotificationAttributeValueLog> GetAllNotificationAttributeValueLogDataByNotificationLogID(Guid notificationLogID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Notifications.NotificationAttributeValueLog> sortableList = new BLL.SortableList<BLL.Notifications.NotificationAttributeValueLog>(DAL.Notifications.NotificationAttributeValueLog.GetAllNotificationAttributeValueLogDataByNotificationLogID(notificationLogID, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Notifications.NotificationAttributeValueLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Notifications.GetAllNotificationAttributeValueLogDataByNotificationLogID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all NotificationAttributeValueLog data by criteria.</summary>
		///
		/// <param name="attributeValue">A key for NotificationAttributeValueLog items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for NotificationAttributeValueLog items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for NotificationAttributeValueLog items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Notifications.NotificationAttributeValueLog> GetManyNotificationAttributeValueLogDataByCriteria(string attributeValue, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Notifications.NotificationAttributeValueLogManager.GetManyNotificationAttributeValueLogDataByCriteria(attributeValue, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all NotificationAttributeValueLog data by criteria.</summary>
		///
		/// <param name="attributeValue">A key for NotificationAttributeValueLog items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for NotificationAttributeValueLog items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for NotificationAttributeValueLog items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Notifications.NotificationAttributeValueLog> GetManyNotificationAttributeValueLogDataByCriteria(string attributeValue, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Notifications.NotificationAttributeValueLog> sortableList = new BLL.SortableList<BLL.Notifications.NotificationAttributeValueLog>(DAL.Notifications.NotificationAttributeValueLog.GetManyNotificationAttributeValueLogDataByCriteria(attributeValue, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Notifications.NotificationAttributeValueLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Notifications.GetManyNotificationAttributeValueLogDataByCriteria");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single NotificationAttributeValueLog by an index.</summary>
		///
		/// <param name="notificationAttributeValueLogID">The index for NotificationAttributeValueLog to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Notifications.NotificationAttributeValueLog GetOneNotificationAttributeValueLog(Guid notificationAttributeValueLogID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Notifications.NotificationAttributeValueLogManager.GetOneNotificationAttributeValueLog(notificationAttributeValueLogID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single NotificationAttributeValueLog by an index.</summary>
		///
		/// <param name="notificationAttributeValueLogID">The index for NotificationAttributeValueLog to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Notifications.NotificationAttributeValueLog GetOneNotificationAttributeValueLog(Guid notificationAttributeValueLogID)
		{
			// perform main method tasks
			return BLL.Notifications.NotificationAttributeValueLogManager.GetOneNotificationAttributeValueLog(notificationAttributeValueLogID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single NotificationAttributeValueLog by an index.</summary>
		///
		/// <param name="notificationAttributeValueLogID">The index for NotificationAttributeValueLog to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Notifications.NotificationAttributeValueLog GetOneNotificationAttributeValueLog(Guid notificationAttributeValueLogID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.Notifications.NotificationAttributeValueLog itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.Notifications.NotificationAttributeValueLog)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.Notifications.NotificationAttributeValueLog.GetCacheKey(typeof(BLL.Notifications.NotificationAttributeValueLog), "PrimaryKey", notificationAttributeValueLogID.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.Notifications.NotificationAttributeValueLog)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.Notifications.NotificationAttributeValueLog item = DAL.Notifications.NotificationAttributeValueLog.GetOneNotificationAttributeValueLog(notificationAttributeValueLogID, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.Notifications.NotificationAttributeValueLog();
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
				throw Utility.CustomAppException.WrapException(ex, "BLL.Notifications.GetOneNotificationAttributeValueLog");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method logs NotificationAttributeValueLog data.</summary>
		///
		/// <param name="item">The NotificationAttributeValueLog to be logged.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void LogOneNotificationAttributeValueLog(BLL.Notifications.NotificationAttributeValueLog item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Notifications.NotificationAttributeValueLogManager.LogOneNotificationAttributeValueLog(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method logs NotificationAttributeValueLog data.</summary>
		///
		/// <param name="item">The NotificationAttributeValueLog to be logged.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void LogOneNotificationAttributeValueLog(BLL.Notifications.NotificationAttributeValueLog item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Notifications.NotificationAttributeValueLog itemDAL = new DAL.Notifications.NotificationAttributeValueLog();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Notifications.NotificationAttributeValueLog.LogOneNotificationAttributeValueLog(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Notifications.LogOneNotificationAttributeValueLog");
			}
		}
		#endregion Methods
	}
}