
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
	/// <summary>This class is used to manage NotificationDeliveryLog related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class NotificationDeliveryLogManager
	{
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public NotificationDeliveryLogManager()
		{
			//
			// constructor logic
			//
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------
		/// <summary>This method inserts NotificationDeliveryLog data.</summary>
		///
		/// <param name="item">The NotificationDeliveryLog to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneNotificationDeliveryLog(BLL.Notifications.NotificationDeliveryLog item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Notifications.NotificationDeliveryLogManager.AddOneNotificationDeliveryLog(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method inserts NotificationDeliveryLog data.</summary>
		///
		/// <param name="item">The NotificationDeliveryLog to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneNotificationDeliveryLog(BLL.Notifications.NotificationDeliveryLog item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Notifications.NotificationDeliveryLog itemDAL = new DAL.Notifications.NotificationDeliveryLog();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Notifications.NotificationDeliveryLog.AddOneNotificationDeliveryLog(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Notifications.AddOneNotificationDeliveryLog");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all NotificationDeliveryLog data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for NotificationDeliveryLog items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllNotificationDeliveryLogDataByMetaPartnerID(Guid metaPartnerID)
		{
			// perform main method tasks
			BLL.Notifications.NotificationDeliveryLogManager.DeleteAllNotificationDeliveryLogDataByMetaPartnerID(metaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all NotificationDeliveryLog data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for NotificationDeliveryLog items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllNotificationDeliveryLogDataByMetaPartnerID(Guid metaPartnerID, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Notifications.NotificationDeliveryLog.DeleteAllNotificationDeliveryLogDataByMetaPartnerID(metaPartnerID, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Notifications.DeleteAllNotificationDeliveryLogDataByMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all NotificationDeliveryLog data by a key.</summary>
		///
		/// <param name="notificationDeliveryTypeCode">A key for NotificationDeliveryLog items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllNotificationDeliveryLogDataByNotificationDeliveryTypeCode(int notificationDeliveryTypeCode)
		{
			// perform main method tasks
			BLL.Notifications.NotificationDeliveryLogManager.DeleteAllNotificationDeliveryLogDataByNotificationDeliveryTypeCode(notificationDeliveryTypeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all NotificationDeliveryLog data by a key.</summary>
		///
		/// <param name="notificationDeliveryTypeCode">A key for NotificationDeliveryLog items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllNotificationDeliveryLogDataByNotificationDeliveryTypeCode(int notificationDeliveryTypeCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Notifications.NotificationDeliveryLog.DeleteAllNotificationDeliveryLogDataByNotificationDeliveryTypeCode(notificationDeliveryTypeCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Notifications.DeleteAllNotificationDeliveryLogDataByNotificationDeliveryTypeCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all NotificationDeliveryLog data by a key.</summary>
		///
		/// <param name="notificationLogID">A key for NotificationDeliveryLog items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllNotificationDeliveryLogDataByNotificationLogID(Guid notificationLogID)
		{
			// perform main method tasks
			BLL.Notifications.NotificationDeliveryLogManager.DeleteAllNotificationDeliveryLogDataByNotificationLogID(notificationLogID, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all NotificationDeliveryLog data by a key.</summary>
		///
		/// <param name="notificationLogID">A key for NotificationDeliveryLog items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllNotificationDeliveryLogDataByNotificationLogID(Guid notificationLogID, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Notifications.NotificationDeliveryLog.DeleteAllNotificationDeliveryLogDataByNotificationLogID(notificationLogID, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Notifications.DeleteAllNotificationDeliveryLogDataByNotificationLogID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes NotificationDeliveryLog data.</summary>
		///
		/// <param name="item">The NotificationDeliveryLog to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneNotificationDeliveryLog(BLL.Notifications.NotificationDeliveryLog item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Notifications.NotificationDeliveryLogManager.DeleteOneNotificationDeliveryLog(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes NotificationDeliveryLog data.</summary>
		///
		/// <param name="item">The NotificationDeliveryLog to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneNotificationDeliveryLog(BLL.Notifications.NotificationDeliveryLog item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Notifications.NotificationDeliveryLog itemDAL = new DAL.Notifications.NotificationDeliveryLog();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Notifications.NotificationDeliveryLog.DeleteOneNotificationDeliveryLog(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = false;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Notifications.DeleteOneNotificationDeliveryLog");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all NotificationDeliveryLog data.</summary>
		///
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Notifications.NotificationDeliveryLog> GetAllNotificationDeliveryLogData(MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Notifications.NotificationDeliveryLogManager.GetAllNotificationDeliveryLogData(BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all NotificationDeliveryLog data.</summary>
		///
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Notifications.NotificationDeliveryLog> GetAllNotificationDeliveryLogData()
		{
			// perform main method tasks
			return BLL.Notifications.NotificationDeliveryLogManager.GetAllNotificationDeliveryLogData(BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all NotificationDeliveryLog data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Notifications.NotificationDeliveryLog> GetAllNotificationDeliveryLogData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Notifications.NotificationDeliveryLog> sortableList = new BLL.SortableList<BLL.Notifications.NotificationDeliveryLog>(DAL.Notifications.NotificationDeliveryLog.GetAllNotificationDeliveryLogData(dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Notifications.NotificationDeliveryLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Notifications.GetAllNotificationDeliveryLogData");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all NotificationDeliveryLog data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for NotificationDeliveryLog items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Notifications.NotificationDeliveryLog> GetAllNotificationDeliveryLogDataByMetaPartnerID(Guid metaPartnerID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Notifications.NotificationDeliveryLogManager.GetAllNotificationDeliveryLogDataByMetaPartnerID(metaPartnerID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all NotificationDeliveryLog data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for NotificationDeliveryLog items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Notifications.NotificationDeliveryLog> GetAllNotificationDeliveryLogDataByMetaPartnerID(Guid metaPartnerID)
		{
			// perform main method tasks
			return BLL.Notifications.NotificationDeliveryLogManager.GetAllNotificationDeliveryLogDataByMetaPartnerID(metaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all NotificationDeliveryLog data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for NotificationDeliveryLog items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Notifications.NotificationDeliveryLog> GetAllNotificationDeliveryLogDataByMetaPartnerID(Guid metaPartnerID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Notifications.NotificationDeliveryLog> sortableList = new BLL.SortableList<BLL.Notifications.NotificationDeliveryLog>(DAL.Notifications.NotificationDeliveryLog.GetAllNotificationDeliveryLogDataByMetaPartnerID(metaPartnerID, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Notifications.NotificationDeliveryLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Notifications.GetAllNotificationDeliveryLogDataByMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all NotificationDeliveryLog data by a key.</summary>
		///
		/// <param name="notificationDeliveryTypeCode">A key for NotificationDeliveryLog items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Notifications.NotificationDeliveryLog> GetAllNotificationDeliveryLogDataByNotificationDeliveryTypeCode(int notificationDeliveryTypeCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Notifications.NotificationDeliveryLogManager.GetAllNotificationDeliveryLogDataByNotificationDeliveryTypeCode(notificationDeliveryTypeCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all NotificationDeliveryLog data by a key.</summary>
		///
		/// <param name="notificationDeliveryTypeCode">A key for NotificationDeliveryLog items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Notifications.NotificationDeliveryLog> GetAllNotificationDeliveryLogDataByNotificationDeliveryTypeCode(int notificationDeliveryTypeCode)
		{
			// perform main method tasks
			return BLL.Notifications.NotificationDeliveryLogManager.GetAllNotificationDeliveryLogDataByNotificationDeliveryTypeCode(notificationDeliveryTypeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all NotificationDeliveryLog data by a key.</summary>
		///
		/// <param name="notificationDeliveryTypeCode">A key for NotificationDeliveryLog items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Notifications.NotificationDeliveryLog> GetAllNotificationDeliveryLogDataByNotificationDeliveryTypeCode(int notificationDeliveryTypeCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Notifications.NotificationDeliveryLog> sortableList = new BLL.SortableList<BLL.Notifications.NotificationDeliveryLog>(DAL.Notifications.NotificationDeliveryLog.GetAllNotificationDeliveryLogDataByNotificationDeliveryTypeCode(notificationDeliveryTypeCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Notifications.NotificationDeliveryLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Notifications.GetAllNotificationDeliveryLogDataByNotificationDeliveryTypeCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all NotificationDeliveryLog data by a key.</summary>
		///
		/// <param name="notificationLogID">A key for NotificationDeliveryLog items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Notifications.NotificationDeliveryLog> GetAllNotificationDeliveryLogDataByNotificationLogID(Guid notificationLogID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Notifications.NotificationDeliveryLogManager.GetAllNotificationDeliveryLogDataByNotificationLogID(notificationLogID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all NotificationDeliveryLog data by a key.</summary>
		///
		/// <param name="notificationLogID">A key for NotificationDeliveryLog items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Notifications.NotificationDeliveryLog> GetAllNotificationDeliveryLogDataByNotificationLogID(Guid notificationLogID)
		{
			// perform main method tasks
			return BLL.Notifications.NotificationDeliveryLogManager.GetAllNotificationDeliveryLogDataByNotificationLogID(notificationLogID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all NotificationDeliveryLog data by a key.</summary>
		///
		/// <param name="notificationLogID">A key for NotificationDeliveryLog items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Notifications.NotificationDeliveryLog> GetAllNotificationDeliveryLogDataByNotificationLogID(Guid notificationLogID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Notifications.NotificationDeliveryLog> sortableList = new BLL.SortableList<BLL.Notifications.NotificationDeliveryLog>(DAL.Notifications.NotificationDeliveryLog.GetAllNotificationDeliveryLogDataByNotificationLogID(notificationLogID, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Notifications.NotificationDeliveryLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Notifications.GetAllNotificationDeliveryLogDataByNotificationLogID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single NotificationDeliveryLog by an index.</summary>
		///
		/// <param name="notificationLogID">The index for NotificationDeliveryLog to be fetched</param>
		/// <param name="metaPartnerID">The index for NotificationDeliveryLog to be fetched</param>
		/// <param name="notificationDeliveryTypeCode">The index for NotificationDeliveryLog to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Notifications.NotificationDeliveryLog GetOneNotificationDeliveryLog(Guid notificationLogID, Guid metaPartnerID, int notificationDeliveryTypeCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Notifications.NotificationDeliveryLogManager.GetOneNotificationDeliveryLog(notificationLogID, metaPartnerID, notificationDeliveryTypeCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single NotificationDeliveryLog by an index.</summary>
		///
		/// <param name="notificationLogID">The index for NotificationDeliveryLog to be fetched</param>
		/// <param name="metaPartnerID">The index for NotificationDeliveryLog to be fetched</param>
		/// <param name="notificationDeliveryTypeCode">The index for NotificationDeliveryLog to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Notifications.NotificationDeliveryLog GetOneNotificationDeliveryLog(Guid notificationLogID, Guid metaPartnerID, int notificationDeliveryTypeCode)
		{
			// perform main method tasks
			return BLL.Notifications.NotificationDeliveryLogManager.GetOneNotificationDeliveryLog(notificationLogID, metaPartnerID, notificationDeliveryTypeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single NotificationDeliveryLog by an index.</summary>
		///
		/// <param name="notificationLogID">The index for NotificationDeliveryLog to be fetched</param>
		/// <param name="metaPartnerID">The index for NotificationDeliveryLog to be fetched</param>
		/// <param name="notificationDeliveryTypeCode">The index for NotificationDeliveryLog to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Notifications.NotificationDeliveryLog GetOneNotificationDeliveryLog(Guid notificationLogID, Guid metaPartnerID, int notificationDeliveryTypeCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.Notifications.NotificationDeliveryLog itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.Notifications.NotificationDeliveryLog)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.Notifications.NotificationDeliveryLog.GetCacheKey(typeof(BLL.Notifications.NotificationDeliveryLog), "PrimaryKey", notificationLogID.ToString() + ", " + metaPartnerID.ToString() + ", " + notificationDeliveryTypeCode.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.Notifications.NotificationDeliveryLog)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.Notifications.NotificationDeliveryLog item = DAL.Notifications.NotificationDeliveryLog.GetOneNotificationDeliveryLog(notificationLogID, metaPartnerID, notificationDeliveryTypeCode, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.Notifications.NotificationDeliveryLog();
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
				throw Utility.CustomAppException.WrapException(ex, "BLL.Notifications.GetOneNotificationDeliveryLog");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates NotificationDeliveryLog data.</summary>
		///
		/// <param name="item">The NotificationDeliveryLog to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneNotificationDeliveryLog(BLL.Notifications.NotificationDeliveryLog item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Notifications.NotificationDeliveryLogManager.UpdateOneNotificationDeliveryLog(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates NotificationDeliveryLog data.</summary>
		///
		/// <param name="item">The NotificationDeliveryLog to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneNotificationDeliveryLog(BLL.Notifications.NotificationDeliveryLog item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Notifications.NotificationDeliveryLog itemDAL = new DAL.Notifications.NotificationDeliveryLog();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Notifications.NotificationDeliveryLog.UpdateOneNotificationDeliveryLog(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Notifications.UpdateOneNotificationDeliveryLog");
			}
		}
		#endregion Methods
	}
}