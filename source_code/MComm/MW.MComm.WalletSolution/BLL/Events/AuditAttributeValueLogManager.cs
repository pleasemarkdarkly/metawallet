
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
using MW.MComm.WalletSolution.BLL.Events;
using MOD.Data;
using MW.MComm.WalletSolution.BLL.Config;
using BLL = MW.MComm.WalletSolution.BLL;
using DAL = MW.MComm.WalletSolution.DAL;
using Utility = MW.MComm.WalletSolution.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
namespace MW.MComm.WalletSolution.BLL.Events
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage AuditAttributeValueLog related information.</summary>
	///
	/// File History:
	/// <created>3/2/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class AuditAttributeValueLogManager
	{
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public AuditAttributeValueLogManager()
		{
			//
			// constructor logic
			//
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------
		/// <summary>This method logs AuditAttributeValueLog data.</summary>
		///
		/// <param name="item">The AuditAttributeValueLog to be logged.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void LogOneAuditAttributeValueLog(BLL.Events.AuditAttributeValueLog item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Events.AuditAttributeValueLogManager.LogOneAuditAttributeValueLog(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method logs AuditAttributeValueLog data.</summary>
		///
		/// <param name="item">The AuditAttributeValueLog to be logged.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void LogOneAuditAttributeValueLog(BLL.Events.AuditAttributeValueLog item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Events.AuditAttributeValueLog itemDAL = new DAL.Events.AuditAttributeValueLog();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Events.AuditAttributeValueLog.LogOneAuditAttributeValueLog(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Events.LogOneAuditAttributeValueLog");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single AuditAttributeValueLog by an index.</summary>
		///
		/// <param name="auditAttributeValueLogID">The index for AuditAttributeValueLog to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Events.AuditAttributeValueLog GetOneAuditAttributeValueLog(Guid auditAttributeValueLogID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Events.AuditAttributeValueLogManager.GetOneAuditAttributeValueLog(auditAttributeValueLogID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single AuditAttributeValueLog by an index.</summary>
		///
		/// <param name="auditAttributeValueLogID">The index for AuditAttributeValueLog to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Events.AuditAttributeValueLog GetOneAuditAttributeValueLog(Guid auditAttributeValueLogID)
		{
			// perform main method tasks
			return BLL.Events.AuditAttributeValueLogManager.GetOneAuditAttributeValueLog(auditAttributeValueLogID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single AuditAttributeValueLog by an index.</summary>
		///
		/// <param name="auditAttributeValueLogID">The index for AuditAttributeValueLog to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Events.AuditAttributeValueLog GetOneAuditAttributeValueLog(Guid auditAttributeValueLogID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.Events.AuditAttributeValueLog itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.Events.AuditAttributeValueLog)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.Events.AuditAttributeValueLog.GetCacheKey(typeof(BLL.Events.AuditAttributeValueLog), "PrimaryKey", auditAttributeValueLogID.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.Events.AuditAttributeValueLog)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.Events.AuditAttributeValueLog item = DAL.Events.AuditAttributeValueLog.GetOneAuditAttributeValueLog(auditAttributeValueLogID, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.Events.AuditAttributeValueLog();
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
				throw Utility.CustomAppException.WrapException(ex, "BLL.Events.GetOneAuditAttributeValueLog");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all AuditAttributeValueLog data.</summary>
		///
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.AuditAttributeValueLog> GetAllAuditAttributeValueLogData(MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Events.AuditAttributeValueLogManager.GetAllAuditAttributeValueLogData(BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all AuditAttributeValueLog data.</summary>
		///
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.AuditAttributeValueLog> GetAllAuditAttributeValueLogData()
		{
			// perform main method tasks
			return BLL.Events.AuditAttributeValueLogManager.GetAllAuditAttributeValueLogData(BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all AuditAttributeValueLog data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.AuditAttributeValueLog> GetAllAuditAttributeValueLogData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Events.AuditAttributeValueLog> sortableList = new BLL.SortableList<BLL.Events.AuditAttributeValueLog>(DAL.Events.AuditAttributeValueLog.GetAllAuditAttributeValueLogData(dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Events.AuditAttributeValueLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Events.GetAllAuditAttributeValueLogData");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all AuditAttributeValueLog data by a key.</summary>
		///
		/// <param name="auditLogID">A key for AuditAttributeValueLog items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.AuditAttributeValueLog> GetAllAuditAttributeValueLogDataByAuditLogID(Guid auditLogID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Events.AuditAttributeValueLogManager.GetAllAuditAttributeValueLogDataByAuditLogID(auditLogID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all AuditAttributeValueLog data by a key.</summary>
		///
		/// <param name="auditLogID">A key for AuditAttributeValueLog items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.AuditAttributeValueLog> GetAllAuditAttributeValueLogDataByAuditLogID(Guid auditLogID)
		{
			// perform main method tasks
			return BLL.Events.AuditAttributeValueLogManager.GetAllAuditAttributeValueLogDataByAuditLogID(auditLogID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all AuditAttributeValueLog data by a key.</summary>
		///
		/// <param name="auditLogID">A key for AuditAttributeValueLog items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.AuditAttributeValueLog> GetAllAuditAttributeValueLogDataByAuditLogID(Guid auditLogID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Events.AuditAttributeValueLog> sortableList = new BLL.SortableList<BLL.Events.AuditAttributeValueLog>(DAL.Events.AuditAttributeValueLog.GetAllAuditAttributeValueLogDataByAuditLogID(auditLogID, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Events.AuditAttributeValueLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Events.GetAllAuditAttributeValueLogDataByAuditLogID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all AuditAttributeValueLog data by a key.</summary>
		///
		/// <param name="baseAttributeID">A key for AuditAttributeValueLog items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.AuditAttributeValueLog> GetAllAuditAttributeValueLogDataByBaseAttributeID(Guid baseAttributeID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Events.AuditAttributeValueLogManager.GetAllAuditAttributeValueLogDataByBaseAttributeID(baseAttributeID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all AuditAttributeValueLog data by a key.</summary>
		///
		/// <param name="baseAttributeID">A key for AuditAttributeValueLog items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.AuditAttributeValueLog> GetAllAuditAttributeValueLogDataByBaseAttributeID(Guid baseAttributeID)
		{
			// perform main method tasks
			return BLL.Events.AuditAttributeValueLogManager.GetAllAuditAttributeValueLogDataByBaseAttributeID(baseAttributeID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all AuditAttributeValueLog data by a key.</summary>
		///
		/// <param name="baseAttributeID">A key for AuditAttributeValueLog items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.AuditAttributeValueLog> GetAllAuditAttributeValueLogDataByBaseAttributeID(Guid baseAttributeID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Events.AuditAttributeValueLog> sortableList = new BLL.SortableList<BLL.Events.AuditAttributeValueLog>(DAL.Events.AuditAttributeValueLog.GetAllAuditAttributeValueLogDataByBaseAttributeID(baseAttributeID, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Events.AuditAttributeValueLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Events.GetAllAuditAttributeValueLogDataByBaseAttributeID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all AuditAttributeValueLog data by criteria.</summary>
		///
		/// <param name="attributeValue">A key for AuditAttributeValueLog items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for AuditAttributeValueLog items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for AuditAttributeValueLog items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.AuditAttributeValueLog> GetAllAuditAttributeValueLogDataByCriteria(string attributeValue, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Events.AuditAttributeValueLogManager.GetAllAuditAttributeValueLogDataByCriteria(attributeValue, lastModifiedDateStart, lastModifiedDateEnd, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all AuditAttributeValueLog data by criteria.</summary>
		///
		/// <param name="attributeValue">A key for AuditAttributeValueLog items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for AuditAttributeValueLog items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for AuditAttributeValueLog items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.AuditAttributeValueLog> GetAllAuditAttributeValueLogDataByCriteria(string attributeValue, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd)
		{
			// perform main method tasks
			return BLL.Events.AuditAttributeValueLogManager.GetAllAuditAttributeValueLogDataByCriteria(attributeValue, lastModifiedDateStart, lastModifiedDateEnd, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all AuditAttributeValueLog data by criteria.</summary>
		///
		/// <param name="attributeValue">A key for AuditAttributeValueLog items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for AuditAttributeValueLog items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for AuditAttributeValueLog items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.AuditAttributeValueLog> GetAllAuditAttributeValueLogDataByCriteria(string attributeValue, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Events.AuditAttributeValueLog> sortableList = new BLL.SortableList<BLL.Events.AuditAttributeValueLog>(DAL.Events.AuditAttributeValueLog.GetAllAuditAttributeValueLogDataByCriteria(attributeValue, lastModifiedDateStart, lastModifiedDateEnd, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Events.AuditAttributeValueLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Events.GetAllAuditAttributeValueLogDataByCriteria");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all AuditAttributeValueLog data by criteria.</summary>
		///
		/// <param name="attributeValue">A key for AuditAttributeValueLog items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for AuditAttributeValueLog items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for AuditAttributeValueLog items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.AuditAttributeValueLog> GetManyAuditAttributeValueLogDataByCriteria(string attributeValue, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Events.AuditAttributeValueLogManager.GetManyAuditAttributeValueLogDataByCriteria(attributeValue, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all AuditAttributeValueLog data by criteria.</summary>
		///
		/// <param name="attributeValue">A key for AuditAttributeValueLog items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for AuditAttributeValueLog items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for AuditAttributeValueLog items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.AuditAttributeValueLog> GetManyAuditAttributeValueLogDataByCriteria(string attributeValue, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Events.AuditAttributeValueLog> sortableList = new BLL.SortableList<BLL.Events.AuditAttributeValueLog>(DAL.Events.AuditAttributeValueLog.GetManyAuditAttributeValueLogDataByCriteria(attributeValue, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Events.AuditAttributeValueLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Events.GetManyAuditAttributeValueLogDataByCriteria");
			}
		}
		#endregion Methods
	}
}