
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
using MW.MComm.WalletSolution.BLL.Core;
using MOD.Data;
using MW.MComm.WalletSolution.BLL.Config;
using BLL = MW.MComm.WalletSolution.BLL;
using DAL = MW.MComm.WalletSolution.DAL;
using Utility = MW.MComm.WalletSolution.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
namespace MW.MComm.WalletSolution.BLL.Core
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage DebugLog related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class DebugLogManager
	{
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public DebugLogManager()
		{
			//
			// constructor logic
			//
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------
		/// <summary>This method gets all DebugLog data.</summary>
		///
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.DebugLog> GetAllDebugLogData(MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Core.DebugLogManager.GetAllDebugLogData(BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all DebugLog data.</summary>
		///
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.DebugLog> GetAllDebugLogData()
		{
			// perform main method tasks
			return BLL.Core.DebugLogManager.GetAllDebugLogData(BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all DebugLog data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.DebugLog> GetAllDebugLogData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Core.DebugLog> sortableList = new BLL.SortableList<BLL.Core.DebugLog>(DAL.Core.DebugLog.GetAllDebugLogData(dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Core.DebugLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.GetAllDebugLogData");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all DebugLog data by criteria.</summary>
		///
		/// <param name="eventName">A key for DebugLog items to be fetched</param>
		/// <param name="errorNumber">A key for DebugLog items to be fetched</param>
		/// <param name="eventTypeCode">A key for DebugLog items to be fetched</param>
		/// <param name="severityLevelCode">A key for DebugLog items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for DebugLog items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for DebugLog items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.DebugLog> GetAllDebugLogDataByCriteria(string eventName, int? errorNumber, int? eventTypeCode, int? severityLevelCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Core.DebugLogManager.GetAllDebugLogDataByCriteria(eventName, errorNumber, eventTypeCode, severityLevelCode, lastModifiedDateStart, lastModifiedDateEnd, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all DebugLog data by criteria.</summary>
		///
		/// <param name="eventName">A key for DebugLog items to be fetched</param>
		/// <param name="errorNumber">A key for DebugLog items to be fetched</param>
		/// <param name="eventTypeCode">A key for DebugLog items to be fetched</param>
		/// <param name="severityLevelCode">A key for DebugLog items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for DebugLog items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for DebugLog items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.DebugLog> GetAllDebugLogDataByCriteria(string eventName, int? errorNumber, int? eventTypeCode, int? severityLevelCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd)
		{
			// perform main method tasks
			return BLL.Core.DebugLogManager.GetAllDebugLogDataByCriteria(eventName, errorNumber, eventTypeCode, severityLevelCode, lastModifiedDateStart, lastModifiedDateEnd, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all DebugLog data by criteria.</summary>
		///
		/// <param name="eventName">A key for DebugLog items to be fetched</param>
		/// <param name="errorNumber">A key for DebugLog items to be fetched</param>
		/// <param name="eventTypeCode">A key for DebugLog items to be fetched</param>
		/// <param name="severityLevelCode">A key for DebugLog items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for DebugLog items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for DebugLog items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.DebugLog> GetAllDebugLogDataByCriteria(string eventName, int? errorNumber, int? eventTypeCode, int? severityLevelCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Core.DebugLog> sortableList = new BLL.SortableList<BLL.Core.DebugLog>(DAL.Core.DebugLog.GetAllDebugLogDataByCriteria(eventName, errorNumber, eventTypeCode, severityLevelCode, lastModifiedDateStart, lastModifiedDateEnd, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Core.DebugLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.GetAllDebugLogDataByCriteria");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all DebugLog data by a key.</summary>
		///
		/// <param name="eventTypeCode">A key for DebugLog items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.DebugLog> GetAllDebugLogDataByEventTypeCode(int eventTypeCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Core.DebugLogManager.GetAllDebugLogDataByEventTypeCode(eventTypeCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all DebugLog data by a key.</summary>
		///
		/// <param name="eventTypeCode">A key for DebugLog items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.DebugLog> GetAllDebugLogDataByEventTypeCode(int eventTypeCode)
		{
			// perform main method tasks
			return BLL.Core.DebugLogManager.GetAllDebugLogDataByEventTypeCode(eventTypeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all DebugLog data by a key.</summary>
		///
		/// <param name="eventTypeCode">A key for DebugLog items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.DebugLog> GetAllDebugLogDataByEventTypeCode(int eventTypeCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Core.DebugLog> sortableList = new BLL.SortableList<BLL.Core.DebugLog>(DAL.Core.DebugLog.GetAllDebugLogDataByEventTypeCode(eventTypeCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Core.DebugLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.GetAllDebugLogDataByEventTypeCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all DebugLog data by a key.</summary>
		///
		/// <param name="severityLevelCode">A key for DebugLog items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.DebugLog> GetAllDebugLogDataBySeverityLevelCode(int severityLevelCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Core.DebugLogManager.GetAllDebugLogDataBySeverityLevelCode(severityLevelCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all DebugLog data by a key.</summary>
		///
		/// <param name="severityLevelCode">A key for DebugLog items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.DebugLog> GetAllDebugLogDataBySeverityLevelCode(int severityLevelCode)
		{
			// perform main method tasks
			return BLL.Core.DebugLogManager.GetAllDebugLogDataBySeverityLevelCode(severityLevelCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all DebugLog data by a key.</summary>
		///
		/// <param name="severityLevelCode">A key for DebugLog items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.DebugLog> GetAllDebugLogDataBySeverityLevelCode(int severityLevelCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Core.DebugLog> sortableList = new BLL.SortableList<BLL.Core.DebugLog>(DAL.Core.DebugLog.GetAllDebugLogDataBySeverityLevelCode(severityLevelCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Core.DebugLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.GetAllDebugLogDataBySeverityLevelCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all DebugLog data by criteria.</summary>
		///
		/// <param name="eventName">A key for DebugLog items to be fetched</param>
		/// <param name="errorNumber">A key for DebugLog items to be fetched</param>
		/// <param name="eventTypeCode">A key for DebugLog items to be fetched</param>
		/// <param name="severityLevelCode">A key for DebugLog items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for DebugLog items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for DebugLog items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.DebugLog> GetManyDebugLogDataByCriteria(string eventName, int? errorNumber, int? eventTypeCode, int? severityLevelCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Core.DebugLogManager.GetManyDebugLogDataByCriteria(eventName, errorNumber, eventTypeCode, severityLevelCode, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all DebugLog data by criteria.</summary>
		///
		/// <param name="eventName">A key for DebugLog items to be fetched</param>
		/// <param name="errorNumber">A key for DebugLog items to be fetched</param>
		/// <param name="eventTypeCode">A key for DebugLog items to be fetched</param>
		/// <param name="severityLevelCode">A key for DebugLog items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for DebugLog items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for DebugLog items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.DebugLog> GetManyDebugLogDataByCriteria(string eventName, int? errorNumber, int? eventTypeCode, int? severityLevelCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Core.DebugLog> sortableList = new BLL.SortableList<BLL.Core.DebugLog>(DAL.Core.DebugLog.GetManyDebugLogDataByCriteria(eventName, errorNumber, eventTypeCode, severityLevelCode, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Core.DebugLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.GetManyDebugLogDataByCriteria");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single DebugLog by an index.</summary>
		///
		/// <param name="debugLogID">The index for DebugLog to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Core.DebugLog GetOneDebugLog(Guid debugLogID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Core.DebugLogManager.GetOneDebugLog(debugLogID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single DebugLog by an index.</summary>
		///
		/// <param name="debugLogID">The index for DebugLog to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Core.DebugLog GetOneDebugLog(Guid debugLogID)
		{
			// perform main method tasks
			return BLL.Core.DebugLogManager.GetOneDebugLog(debugLogID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single DebugLog by an index.</summary>
		///
		/// <param name="debugLogID">The index for DebugLog to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Core.DebugLog GetOneDebugLog(Guid debugLogID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.Core.DebugLog itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.Core.DebugLog)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.Core.DebugLog.GetCacheKey(typeof(BLL.Core.DebugLog), "PrimaryKey", debugLogID.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.Core.DebugLog)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.Core.DebugLog item = DAL.Core.DebugLog.GetOneDebugLog(debugLogID, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.Core.DebugLog();
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
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.GetOneDebugLog");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method logs DebugLog data.</summary>
		///
		/// <param name="item">The DebugLog to be logged.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void LogOneDebugLog(BLL.Core.DebugLog item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Core.DebugLogManager.LogOneDebugLog(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method logs DebugLog data.</summary>
		///
		/// <param name="item">The DebugLog to be logged.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void LogOneDebugLog(BLL.Core.DebugLog item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Core.DebugLog itemDAL = new DAL.Core.DebugLog();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Core.DebugLog.LogOneDebugLog(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.LogOneDebugLog");
			}
		}
		#endregion Methods
	}
}