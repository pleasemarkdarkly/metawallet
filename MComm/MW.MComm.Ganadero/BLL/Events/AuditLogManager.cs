

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
using MW.MComm.Ganadero.BLL.Events;
using MOD.Data;
using MW.MComm.Ganadero.BLL.Config;
using BLL = MW.MComm.Ganadero.BLL;
using DAL = MW.MComm.Ganadero.DAL;
using Utility = MW.MComm.Ganadero.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace MW.MComm.Ganadero.BLL.Events
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage AuditLog related information.</summary>
	///
	/// File History:
	/// <created>10/20/2006 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class AuditLogManager
	{

		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public AuditLogManager()
		{
			//
			// constructor logic
			//
		}

		#endregion Constructors

		#region Methods

		// ------------------------------------------------------------------------------
		/// <summary>This method loads the AuditLog from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public static BLL.Events.AuditLog Load(Guid auditLogID)
		{
			BLL.Events.AuditLog businessObject = new BLL.Events.AuditLog(auditLogID);
			string key = BLL.Events.AuditLog.GetCacheKey(typeof(BLL.Events.AuditLog), "PrimaryKey", businessObject.PrimaryKey);
			businessObject = (BLL.Events.AuditLog)Utility.CacheManager.Cache[key];
			if (businessObject == null)
			{
				businessObject = BLL.Events.AuditLogManager.GetOneAuditLog(auditLogID);
				Utility.CacheManager.Cache.Add(key, businessObject);
			}
			return businessObject;
		}


		// ------------------------------------------------------------------
		/// <summary>This method gets all AuditLog data.</summary>
		///
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.AuditLog> GetAllAuditLogData(MOD.Data.DataOptions dataOptions)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, ConfigurationInterface.CurrentUserID);
				BLL.SortableList<BLL.Events.AuditLog> sortableList = new BLL.SortableList<BLL.Events.AuditLog>(DAL.Events.AuditLog.GetAllAuditLogData(ConfigurationInterface.DBOptions, dataOptions, ConfigurationInterface.DebugLevel), true, true);
				foreach(BLL.Events.AuditLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Events.GetAllAuditLogData");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets all AuditLog data.</summary>
		///
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.AuditLog> GetAllAuditLogData()
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.CurrentUserID);
				BLL.SortableList<BLL.Events.AuditLog> sortableList = new BLL.SortableList<BLL.Events.AuditLog>(DAL.Events.AuditLog.GetAllAuditLogData(ConfigurationInterface.DBOptions, ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.DebugLevel), true, true);
				foreach(BLL.Events.AuditLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Events.GetAllAuditLogData");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets all AuditLog data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.AuditLog> GetAllAuditLogData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Events.AuditLog> sortableList = new BLL.SortableList<BLL.Events.AuditLog>(DAL.Events.AuditLog.GetAllAuditLogData(dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Events.AuditLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Events.GetAllAuditLogData");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets all AuditLog data by criteria.</summary>
		///
		/// <param name="eventCode">A key for AuditLog items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for AuditLog items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for AuditLog items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.AuditLog> GetAllAuditLogDataByCriteria(int? eventCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DataOptions dataOptions)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, ConfigurationInterface.CurrentUserID);
				BLL.SortableList<BLL.Events.AuditLog> sortableList = new BLL.SortableList<BLL.Events.AuditLog>(DAL.Events.AuditLog.GetAllAuditLogDataByCriteria(eventCode, lastModifiedDateStart, lastModifiedDateEnd, ConfigurationInterface.DBOptions, dataOptions, ConfigurationInterface.DebugLevel), true, true);
				foreach(BLL.Events.AuditLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Events.GetAllAuditLogDataByCriteria");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets all AuditLog data by criteria.</summary>
		///
		/// <param name="eventCode">A key for AuditLog items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for AuditLog items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for AuditLog items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.AuditLog> GetAllAuditLogDataByCriteria(int? eventCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.CurrentUserID);
				BLL.SortableList<BLL.Events.AuditLog> sortableList = new BLL.SortableList<BLL.Events.AuditLog>(DAL.Events.AuditLog.GetAllAuditLogDataByCriteria(eventCode, lastModifiedDateStart, lastModifiedDateEnd, ConfigurationInterface.DBOptions, ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.DebugLevel), true, true);
				foreach(BLL.Events.AuditLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Events.GetAllAuditLogDataByCriteria");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets all AuditLog data by criteria.</summary>
		///
		/// <param name="eventCode">A key for AuditLog items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for AuditLog items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for AuditLog items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.AuditLog> GetAllAuditLogDataByCriteria(int? eventCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Events.AuditLog> sortableList = new BLL.SortableList<BLL.Events.AuditLog>(DAL.Events.AuditLog.GetAllAuditLogDataByCriteria(eventCode, lastModifiedDateStart, lastModifiedDateEnd, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Events.AuditLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Events.GetAllAuditLogDataByCriteria");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets all AuditLog data by a key.</summary>
		///
		/// <param name="eventCode">A key for AuditLog items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.AuditLog> GetAllAuditLogDataByEventCode(int eventCode, MOD.Data.DataOptions dataOptions)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, ConfigurationInterface.CurrentUserID);
				BLL.SortableList<BLL.Events.AuditLog> sortableList = new BLL.SortableList<BLL.Events.AuditLog>(DAL.Events.AuditLog.GetAllAuditLogDataByEventCode(eventCode, ConfigurationInterface.DBOptions, dataOptions, ConfigurationInterface.DebugLevel), true, true);
				foreach(BLL.Events.AuditLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Events.GetAllAuditLogDataByEventCode");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets all AuditLog data by a key.</summary>
		///
		/// <param name="eventCode">A key for AuditLog items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.AuditLog> GetAllAuditLogDataByEventCode(int eventCode)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.CurrentUserID);
				BLL.SortableList<BLL.Events.AuditLog> sortableList = new BLL.SortableList<BLL.Events.AuditLog>(DAL.Events.AuditLog.GetAllAuditLogDataByEventCode(eventCode, ConfigurationInterface.DBOptions, ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.DebugLevel), true, true);
				foreach(BLL.Events.AuditLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Events.GetAllAuditLogDataByEventCode");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets all AuditLog data by a key.</summary>
		///
		/// <param name="eventCode">A key for AuditLog items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.AuditLog> GetAllAuditLogDataByEventCode(int eventCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Events.AuditLog> sortableList = new BLL.SortableList<BLL.Events.AuditLog>(DAL.Events.AuditLog.GetAllAuditLogDataByEventCode(eventCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Events.AuditLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Events.GetAllAuditLogDataByEventCode");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets all AuditLog data by criteria.</summary>
		///
		/// <param name="eventCode">A key for AuditLog items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for AuditLog items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for AuditLog items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.AuditLog> GetManyAuditLogDataByCriteria(int? eventCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DataOptions dataOptions)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, ConfigurationInterface.CurrentUserID);
				BLL.SortableList<BLL.Events.AuditLog> sortableList = new BLL.SortableList<BLL.Events.AuditLog>(DAL.Events.AuditLog.GetManyAuditLogDataByCriteria(eventCode, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, ConfigurationInterface.DBOptions, dataOptions, ConfigurationInterface.DebugLevel), true, true);
				foreach(BLL.Events.AuditLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Events.GetManyAuditLogDataByCriteria");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets all AuditLog data by criteria.</summary>
		///
		/// <param name="eventCode">A key for AuditLog items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for AuditLog items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for AuditLog items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.AuditLog> GetManyAuditLogDataByCriteria(int? eventCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Events.AuditLog> sortableList = new BLL.SortableList<BLL.Events.AuditLog>(DAL.Events.AuditLog.GetManyAuditLogDataByCriteria(eventCode, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Events.AuditLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Events.GetManyAuditLogDataByCriteria");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets a single AuditLog by an index.</summary>
		///
		/// <param name="auditLogID">The index for AuditLog to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Events.AuditLog GetOneAuditLog(Guid auditLogID, MOD.Data.DataOptions dataOptions)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, ConfigurationInterface.CurrentUserID);
				DAL.Events.AuditLog item = null;
				item = DAL.Events.AuditLog.GetOneAuditLog(auditLogID, ConfigurationInterface.DBOptions, dataOptions, ConfigurationInterface.DebugLevel);
				BLL.Events.AuditLog itemBLL = null;
				if (item != null)
				{
					itemBLL = new BLL.Events.AuditLog();
					ReflectionHelper.Copy(item, itemBLL, true);
					itemBLL.ClearDirtyState(true);
					itemBLL.IsLoaded = true;
				}
				return itemBLL;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Events.GetOneAuditLog");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets a single AuditLog by an index.</summary>
		///
		/// <param name="auditLogID">The index for AuditLog to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Events.AuditLog GetOneAuditLog(Guid auditLogID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.CurrentUserID);
				DAL.Events.AuditLog item = null;
				item = DAL.Events.AuditLog.GetOneAuditLog(auditLogID, ConfigurationInterface.DBOptions, ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.DebugLevel);
				BLL.Events.AuditLog itemBLL = null;
				if (item != null)
				{
					itemBLL = new BLL.Events.AuditLog();
					ReflectionHelper.Copy(item, itemBLL, true);
					itemBLL.ClearDirtyState(true);
					itemBLL.IsLoaded = true;
				}
				return itemBLL;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Events.GetOneAuditLog");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets a single AuditLog by an index.</summary>
		///
		/// <param name="auditLogID">The index for AuditLog to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Events.AuditLog GetOneAuditLog(Guid auditLogID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				DAL.Events.AuditLog item = null;
				item = DAL.Events.AuditLog.GetOneAuditLog(auditLogID, dbOptions, dataOptions, debugLevel);
				BLL.Events.AuditLog itemBLL = null;
				if (item != null)
				{
					itemBLL = new BLL.Events.AuditLog();
					ReflectionHelper.Copy(item, itemBLL, true);
					itemBLL.ClearDirtyState(true);
					itemBLL.IsLoaded = true;
				}
				return itemBLL;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Events.GetOneAuditLog");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method logs AuditLog data.</summary>
		///
		/// <param name="item">The AuditLog to be logged.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void LogOneAuditLog(BLL.Events.AuditLog item, bool performCascadeOperation )
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = ConfigurationInterface.CurrentUserID;
				item.LastModifiedByUserID = ConfigurationInterface.CurrentUserID;
				DAL.Events.AuditLog itemDAL = new DAL.Events.AuditLog();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Events.AuditLog.LogOneAuditLog(itemDAL, performCascadeOperation, ConfigurationInterface.DBOptions, ConfigurationInterface.DebugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Events.LogOneAuditLog");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method logs AuditLog data.</summary>
		///
		/// <param name="item">The AuditLog to be logged.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void LogOneAuditLog(BLL.Events.AuditLog item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Events.AuditLog itemDAL = new DAL.Events.AuditLog();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Events.AuditLog.LogOneAuditLog(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Events.LogOneAuditLog");
			}
		}
		#endregion Methods
	}
}