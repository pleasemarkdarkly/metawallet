
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
	/// <summary>This class is used to manage NotificationTemplate related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class NotificationTemplateManager
	{
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public NotificationTemplateManager()
		{
			//
			// constructor logic
			//
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------
		/// <summary>This method deletes all NotificationTemplate data by a key.</summary>
		///
		/// <param name="localeCode">A key for NotificationTemplate items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllNotificationTemplateDataByLocaleCode(int localeCode)
		{
			// perform main method tasks
			BLL.Notifications.NotificationTemplateManager.DeleteAllNotificationTemplateDataByLocaleCode(localeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all NotificationTemplate data by a key.</summary>
		///
		/// <param name="localeCode">A key for NotificationTemplate items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllNotificationTemplateDataByLocaleCode(int localeCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Notifications.NotificationTemplate.DeleteAllNotificationTemplateDataByLocaleCode(localeCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Notifications.DeleteAllNotificationTemplateDataByLocaleCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all NotificationTemplate data by a key.</summary>
		///
		/// <param name="notificationCode">A key for NotificationTemplate items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllNotificationTemplateDataByNotificationCode(int notificationCode)
		{
			// perform main method tasks
			BLL.Notifications.NotificationTemplateManager.DeleteAllNotificationTemplateDataByNotificationCode(notificationCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all NotificationTemplate data by a key.</summary>
		///
		/// <param name="notificationCode">A key for NotificationTemplate items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllNotificationTemplateDataByNotificationCode(int notificationCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Notifications.NotificationTemplate.DeleteAllNotificationTemplateDataByNotificationCode(notificationCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Notifications.DeleteAllNotificationTemplateDataByNotificationCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes NotificationTemplate data.</summary>
		///
		/// <param name="item">The NotificationTemplate to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneNotificationTemplate(BLL.Notifications.NotificationTemplate item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Notifications.NotificationTemplateManager.DeleteOneNotificationTemplate(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes NotificationTemplate data.</summary>
		///
		/// <param name="item">The NotificationTemplate to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneNotificationTemplate(BLL.Notifications.NotificationTemplate item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Notifications.NotificationTemplate itemDAL = new DAL.Notifications.NotificationTemplate();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Notifications.NotificationTemplate.DeleteOneNotificationTemplate(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = false;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Notifications.DeleteOneNotificationTemplate");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all NotificationTemplate data.</summary>
		///
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Notifications.NotificationTemplate> GetAllNotificationTemplateData(MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Notifications.NotificationTemplateManager.GetAllNotificationTemplateData(BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all NotificationTemplate data.</summary>
		///
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Notifications.NotificationTemplate> GetAllNotificationTemplateData()
		{
			// perform main method tasks
			return BLL.Notifications.NotificationTemplateManager.GetAllNotificationTemplateData(BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all NotificationTemplate data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Notifications.NotificationTemplate> GetAllNotificationTemplateData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Notifications.NotificationTemplate> sortableList = new BLL.SortableList<BLL.Notifications.NotificationTemplate>(DAL.Notifications.NotificationTemplate.GetAllNotificationTemplateData(dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Notifications.NotificationTemplate loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Notifications.GetAllNotificationTemplateData");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all NotificationTemplate data by criteria.</summary>
		///
		/// <param name="notificationCode">A key for NotificationTemplate items to be fetched</param>
		/// <param name="localeCode">A key for NotificationTemplate items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for NotificationTemplate items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for NotificationTemplate items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Notifications.NotificationTemplate> GetAllNotificationTemplateDataByCriteria(int? notificationCode, int? localeCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Notifications.NotificationTemplateManager.GetAllNotificationTemplateDataByCriteria(notificationCode, localeCode, lastModifiedDateStart, lastModifiedDateEnd, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all NotificationTemplate data by criteria.</summary>
		///
		/// <param name="notificationCode">A key for NotificationTemplate items to be fetched</param>
		/// <param name="localeCode">A key for NotificationTemplate items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for NotificationTemplate items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for NotificationTemplate items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Notifications.NotificationTemplate> GetAllNotificationTemplateDataByCriteria(int? notificationCode, int? localeCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd)
		{
			// perform main method tasks
			return BLL.Notifications.NotificationTemplateManager.GetAllNotificationTemplateDataByCriteria(notificationCode, localeCode, lastModifiedDateStart, lastModifiedDateEnd, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all NotificationTemplate data by criteria.</summary>
		///
		/// <param name="notificationCode">A key for NotificationTemplate items to be fetched</param>
		/// <param name="localeCode">A key for NotificationTemplate items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for NotificationTemplate items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for NotificationTemplate items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Notifications.NotificationTemplate> GetAllNotificationTemplateDataByCriteria(int? notificationCode, int? localeCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Notifications.NotificationTemplate> sortableList = new BLL.SortableList<BLL.Notifications.NotificationTemplate>(DAL.Notifications.NotificationTemplate.GetAllNotificationTemplateDataByCriteria(notificationCode, localeCode, lastModifiedDateStart, lastModifiedDateEnd, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Notifications.NotificationTemplate loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Notifications.GetAllNotificationTemplateDataByCriteria");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all NotificationTemplate data by a key.</summary>
		///
		/// <param name="localeCode">A key for NotificationTemplate items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Notifications.NotificationTemplate> GetAllNotificationTemplateDataByLocaleCode(int localeCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Notifications.NotificationTemplateManager.GetAllNotificationTemplateDataByLocaleCode(localeCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all NotificationTemplate data by a key.</summary>
		///
		/// <param name="localeCode">A key for NotificationTemplate items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Notifications.NotificationTemplate> GetAllNotificationTemplateDataByLocaleCode(int localeCode)
		{
			// perform main method tasks
			return BLL.Notifications.NotificationTemplateManager.GetAllNotificationTemplateDataByLocaleCode(localeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all NotificationTemplate data by a key.</summary>
		///
		/// <param name="localeCode">A key for NotificationTemplate items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Notifications.NotificationTemplate> GetAllNotificationTemplateDataByLocaleCode(int localeCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Notifications.NotificationTemplate> sortableList = new BLL.SortableList<BLL.Notifications.NotificationTemplate>(DAL.Notifications.NotificationTemplate.GetAllNotificationTemplateDataByLocaleCode(localeCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Notifications.NotificationTemplate loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Notifications.GetAllNotificationTemplateDataByLocaleCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all NotificationTemplate data by a key.</summary>
		///
		/// <param name="notificationCode">A key for NotificationTemplate items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Notifications.NotificationTemplate> GetAllNotificationTemplateDataByNotificationCode(int notificationCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Notifications.NotificationTemplateManager.GetAllNotificationTemplateDataByNotificationCode(notificationCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all NotificationTemplate data by a key.</summary>
		///
		/// <param name="notificationCode">A key for NotificationTemplate items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Notifications.NotificationTemplate> GetAllNotificationTemplateDataByNotificationCode(int notificationCode)
		{
			// perform main method tasks
			return BLL.Notifications.NotificationTemplateManager.GetAllNotificationTemplateDataByNotificationCode(notificationCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all NotificationTemplate data by a key.</summary>
		///
		/// <param name="notificationCode">A key for NotificationTemplate items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Notifications.NotificationTemplate> GetAllNotificationTemplateDataByNotificationCode(int notificationCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Notifications.NotificationTemplate> sortableList = new BLL.SortableList<BLL.Notifications.NotificationTemplate>(DAL.Notifications.NotificationTemplate.GetAllNotificationTemplateDataByNotificationCode(notificationCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Notifications.NotificationTemplate loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Notifications.GetAllNotificationTemplateDataByNotificationCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all NotificationTemplate data by criteria.</summary>
		///
		/// <param name="notificationCode">A key for NotificationTemplate items to be fetched</param>
		/// <param name="localeCode">A key for NotificationTemplate items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for NotificationTemplate items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for NotificationTemplate items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Notifications.NotificationTemplate> GetManyNotificationTemplateDataByCriteria(int? notificationCode, int? localeCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Notifications.NotificationTemplateManager.GetManyNotificationTemplateDataByCriteria(notificationCode, localeCode, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all NotificationTemplate data by criteria.</summary>
		///
		/// <param name="notificationCode">A key for NotificationTemplate items to be fetched</param>
		/// <param name="localeCode">A key for NotificationTemplate items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for NotificationTemplate items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for NotificationTemplate items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Notifications.NotificationTemplate> GetManyNotificationTemplateDataByCriteria(int? notificationCode, int? localeCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Notifications.NotificationTemplate> sortableList = new BLL.SortableList<BLL.Notifications.NotificationTemplate>(DAL.Notifications.NotificationTemplate.GetManyNotificationTemplateDataByCriteria(notificationCode, localeCode, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Notifications.NotificationTemplate loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Notifications.GetManyNotificationTemplateDataByCriteria");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single NotificationTemplate by an index.</summary>
		///
		/// <param name="notificationTemplateID">The index for NotificationTemplate to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Notifications.NotificationTemplate GetOneNotificationTemplate(Guid notificationTemplateID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Notifications.NotificationTemplateManager.GetOneNotificationTemplate(notificationTemplateID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single NotificationTemplate by an index.</summary>
		///
		/// <param name="notificationTemplateID">The index for NotificationTemplate to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Notifications.NotificationTemplate GetOneNotificationTemplate(Guid notificationTemplateID)
		{
			// perform main method tasks
			return BLL.Notifications.NotificationTemplateManager.GetOneNotificationTemplate(notificationTemplateID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single NotificationTemplate by an index.</summary>
		///
		/// <param name="notificationTemplateID">The index for NotificationTemplate to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Notifications.NotificationTemplate GetOneNotificationTemplate(Guid notificationTemplateID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.Notifications.NotificationTemplate itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.Notifications.NotificationTemplate)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.Notifications.NotificationTemplate.GetCacheKey(typeof(BLL.Notifications.NotificationTemplate), "PrimaryKey", notificationTemplateID.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.Notifications.NotificationTemplate)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.Notifications.NotificationTemplate item = DAL.Notifications.NotificationTemplate.GetOneNotificationTemplate(notificationTemplateID, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.Notifications.NotificationTemplate();
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
				throw Utility.CustomAppException.WrapException(ex, "BLL.Notifications.GetOneNotificationTemplate");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method inserts or updates NotificationTemplate data.</summary>
		///
		/// <param name="item">The NotificationTemplate to be inserted or updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpsertOneNotificationTemplate(BLL.Notifications.NotificationTemplate item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Notifications.NotificationTemplateManager.UpsertOneNotificationTemplate(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method inserts or updates NotificationTemplate data.</summary>
		///
		/// <param name="item">The NotificationTemplate to be inserted or updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpsertOneNotificationTemplate(BLL.Notifications.NotificationTemplate item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Notifications.NotificationTemplate itemDAL = new DAL.Notifications.NotificationTemplate();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Notifications.NotificationTemplate.UpsertOneNotificationTemplate(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Notifications.UpsertOneNotificationTemplate");
			}
		}
		#endregion Methods
	}
}