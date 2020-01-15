
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
	/// <summary>This class is used to manage NotificationDeliveryType related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class NotificationDeliveryTypeManager
	{
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public NotificationDeliveryTypeManager()
		{
			//
			// constructor logic
			//
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------
		/// <summary>This method inserts NotificationDeliveryType data.</summary>
		///
		/// <param name="item">The NotificationDeliveryType to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneNotificationDeliveryType(BLL.Notifications.NotificationDeliveryType item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Notifications.NotificationDeliveryTypeManager.AddOneNotificationDeliveryType(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method inserts NotificationDeliveryType data.</summary>
		///
		/// <param name="item">The NotificationDeliveryType to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneNotificationDeliveryType(BLL.Notifications.NotificationDeliveryType item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				// perform enum check
				if (Enum.IsDefined(typeof(NotificationDeliveryTypeCode), item.NotificationDeliveryTypeCode) == true)
				{
					throw new Utility.CustomAppException(BLL.Core.ErrorNumber.EnumerationAddException, BLL.Core.ErrorManager.GetErrorMessageFromErrorNumber(BLL.Core.ErrorNumber.EnumerationAddException), null);
				}
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Notifications.NotificationDeliveryType itemDAL = new DAL.Notifications.NotificationDeliveryType();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Notifications.NotificationDeliveryType.AddOneNotificationDeliveryType(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Notifications.AddOneNotificationDeliveryType");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes NotificationDeliveryType data.</summary>
		///
		/// <param name="item">The NotificationDeliveryType to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneNotificationDeliveryType(BLL.Notifications.NotificationDeliveryType item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Notifications.NotificationDeliveryTypeManager.DeleteOneNotificationDeliveryType(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes NotificationDeliveryType data.</summary>
		///
		/// <param name="item">The NotificationDeliveryType to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneNotificationDeliveryType(BLL.Notifications.NotificationDeliveryType item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				// perform enum check
				if (Enum.IsDefined(typeof(NotificationDeliveryTypeCode), item.NotificationDeliveryTypeCode) == true)
				{
					throw new Utility.CustomAppException(BLL.Core.ErrorNumber.EnumerationDeleteException, BLL.Core.ErrorManager.GetErrorMessageFromErrorNumber(BLL.Core.ErrorNumber.EnumerationDeleteException), null);
				}
				DAL.Notifications.NotificationDeliveryType itemDAL = new DAL.Notifications.NotificationDeliveryType();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Notifications.NotificationDeliveryType.DeleteOneNotificationDeliveryType(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = false;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Notifications.DeleteOneNotificationDeliveryType");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all NotificationDeliveryType data.</summary>
		///
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Notifications.NotificationDeliveryType> GetAllNotificationDeliveryTypeData(MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Notifications.NotificationDeliveryTypeManager.GetAllNotificationDeliveryTypeData(BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all NotificationDeliveryType data.</summary>
		///
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Notifications.NotificationDeliveryType> GetAllNotificationDeliveryTypeData()
		{
			// perform main method tasks
			return BLL.Notifications.NotificationDeliveryTypeManager.GetAllNotificationDeliveryTypeData(BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all NotificationDeliveryType data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Notifications.NotificationDeliveryType> GetAllNotificationDeliveryTypeData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Notifications.NotificationDeliveryType> sortableList = new BLL.SortableList<BLL.Notifications.NotificationDeliveryType>(DAL.Notifications.NotificationDeliveryType.GetAllNotificationDeliveryTypeData(dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Notifications.NotificationDeliveryType loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Notifications.GetAllNotificationDeliveryTypeData");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single NotificationDeliveryType by an index.</summary>
		///
		/// <param name="notificationDeliveryTypeCode">The index for NotificationDeliveryType to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Notifications.NotificationDeliveryType GetOneNotificationDeliveryType(int notificationDeliveryTypeCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Notifications.NotificationDeliveryTypeManager.GetOneNotificationDeliveryType(notificationDeliveryTypeCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single NotificationDeliveryType by an index.</summary>
		///
		/// <param name="notificationDeliveryTypeCode">The index for NotificationDeliveryType to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Notifications.NotificationDeliveryType GetOneNotificationDeliveryType(int notificationDeliveryTypeCode)
		{
			// perform main method tasks
			return BLL.Notifications.NotificationDeliveryTypeManager.GetOneNotificationDeliveryType(notificationDeliveryTypeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single NotificationDeliveryType by an index.</summary>
		///
		/// <param name="notificationDeliveryTypeCode">The index for NotificationDeliveryType to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Notifications.NotificationDeliveryType GetOneNotificationDeliveryType(int notificationDeliveryTypeCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.Notifications.NotificationDeliveryType itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.Notifications.NotificationDeliveryType)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.Notifications.NotificationDeliveryType.GetCacheKey(typeof(BLL.Notifications.NotificationDeliveryType), "PrimaryKey", notificationDeliveryTypeCode.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.Notifications.NotificationDeliveryType)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.Notifications.NotificationDeliveryType item = DAL.Notifications.NotificationDeliveryType.GetOneNotificationDeliveryType(notificationDeliveryTypeCode, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.Notifications.NotificationDeliveryType();
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
				throw Utility.CustomAppException.WrapException(ex, "BLL.Notifications.GetOneNotificationDeliveryType");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates NotificationDeliveryType data.</summary>
		///
		/// <param name="item">The NotificationDeliveryType to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneNotificationDeliveryType(BLL.Notifications.NotificationDeliveryType item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Notifications.NotificationDeliveryTypeManager.UpdateOneNotificationDeliveryType(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates NotificationDeliveryType data.</summary>
		///
		/// <param name="item">The NotificationDeliveryType to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneNotificationDeliveryType(BLL.Notifications.NotificationDeliveryType item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Notifications.NotificationDeliveryType itemDAL = new DAL.Notifications.NotificationDeliveryType();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Notifications.NotificationDeliveryType.UpdateOneNotificationDeliveryType(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Notifications.UpdateOneNotificationDeliveryType");
			}
		}
		#endregion Methods
	}
}