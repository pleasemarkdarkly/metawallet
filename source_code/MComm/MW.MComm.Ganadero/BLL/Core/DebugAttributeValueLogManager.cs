

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
using MW.MComm.Ganadero.BLL.Core;
using MOD.Data;
using MW.MComm.Ganadero.BLL.Config;
using BLL = MW.MComm.Ganadero.BLL;
using DAL = MW.MComm.Ganadero.DAL;
using Utility = MW.MComm.Ganadero.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace MW.MComm.Ganadero.BLL.Core
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage DebugAttributeValueLog related information.</summary>
	///
	/// File History:
	/// <created>10/20/2006 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class DebugAttributeValueLogManager
	{

		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public DebugAttributeValueLogManager()
		{
			//
			// constructor logic
			//
		}

		#endregion Constructors

		#region Methods

		// ------------------------------------------------------------------------------
		/// <summary>This method loads the DebugAttributeValueLog from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public static BLL.Core.DebugAttributeValueLog Load(Guid debugAttributeValueLogID)
		{
			BLL.Core.DebugAttributeValueLog businessObject = new BLL.Core.DebugAttributeValueLog(debugAttributeValueLogID);
			string key = BLL.Core.DebugAttributeValueLog.GetCacheKey(typeof(BLL.Core.DebugAttributeValueLog), "PrimaryKey", businessObject.PrimaryKey);
			businessObject = (BLL.Core.DebugAttributeValueLog)Utility.CacheManager.Cache[key];
			if (businessObject == null)
			{
				businessObject = BLL.Core.DebugAttributeValueLogManager.GetOneDebugAttributeValueLog(debugAttributeValueLogID);
				Utility.CacheManager.Cache.Add(key, businessObject);
			}
			return businessObject;
		}


		// ------------------------------------------------------------------
		/// <summary>This method gets all DebugAttributeValueLog data.</summary>
		///
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.DebugAttributeValueLog> GetAllDebugAttributeValueLogData(MOD.Data.DataOptions dataOptions)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, ConfigurationInterface.CurrentUserID);
				BLL.SortableList<BLL.Core.DebugAttributeValueLog> sortableList = new BLL.SortableList<BLL.Core.DebugAttributeValueLog>(DAL.Core.DebugAttributeValueLog.GetAllDebugAttributeValueLogData(ConfigurationInterface.DBOptions, dataOptions, ConfigurationInterface.DebugLevel), true, true);
				foreach(BLL.Core.DebugAttributeValueLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.GetAllDebugAttributeValueLogData");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets all DebugAttributeValueLog data.</summary>
		///
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.DebugAttributeValueLog> GetAllDebugAttributeValueLogData()
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.CurrentUserID);
				BLL.SortableList<BLL.Core.DebugAttributeValueLog> sortableList = new BLL.SortableList<BLL.Core.DebugAttributeValueLog>(DAL.Core.DebugAttributeValueLog.GetAllDebugAttributeValueLogData(ConfigurationInterface.DBOptions, ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.DebugLevel), true, true);
				foreach(BLL.Core.DebugAttributeValueLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.GetAllDebugAttributeValueLogData");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets all DebugAttributeValueLog data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.DebugAttributeValueLog> GetAllDebugAttributeValueLogData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Core.DebugAttributeValueLog> sortableList = new BLL.SortableList<BLL.Core.DebugAttributeValueLog>(DAL.Core.DebugAttributeValueLog.GetAllDebugAttributeValueLogData(dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Core.DebugAttributeValueLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.GetAllDebugAttributeValueLogData");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets all DebugAttributeValueLog data by a key.</summary>
		///
		/// <param name="baseAttributeID">A key for DebugAttributeValueLog items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.DebugAttributeValueLog> GetAllDebugAttributeValueLogDataByBaseAttributeID(Guid baseAttributeID, MOD.Data.DataOptions dataOptions)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, ConfigurationInterface.CurrentUserID);
				BLL.SortableList<BLL.Core.DebugAttributeValueLog> sortableList = new BLL.SortableList<BLL.Core.DebugAttributeValueLog>(DAL.Core.DebugAttributeValueLog.GetAllDebugAttributeValueLogDataByBaseAttributeID(baseAttributeID, ConfigurationInterface.DBOptions, dataOptions, ConfigurationInterface.DebugLevel), true, true);
				foreach(BLL.Core.DebugAttributeValueLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.GetAllDebugAttributeValueLogDataByBaseAttributeID");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets all DebugAttributeValueLog data by a key.</summary>
		///
		/// <param name="baseAttributeID">A key for DebugAttributeValueLog items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.DebugAttributeValueLog> GetAllDebugAttributeValueLogDataByBaseAttributeID(Guid baseAttributeID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.CurrentUserID);
				BLL.SortableList<BLL.Core.DebugAttributeValueLog> sortableList = new BLL.SortableList<BLL.Core.DebugAttributeValueLog>(DAL.Core.DebugAttributeValueLog.GetAllDebugAttributeValueLogDataByBaseAttributeID(baseAttributeID, ConfigurationInterface.DBOptions, ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.DebugLevel), true, true);
				foreach(BLL.Core.DebugAttributeValueLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.GetAllDebugAttributeValueLogDataByBaseAttributeID");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets all DebugAttributeValueLog data by a key.</summary>
		///
		/// <param name="baseAttributeID">A key for DebugAttributeValueLog items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.DebugAttributeValueLog> GetAllDebugAttributeValueLogDataByBaseAttributeID(Guid baseAttributeID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Core.DebugAttributeValueLog> sortableList = new BLL.SortableList<BLL.Core.DebugAttributeValueLog>(DAL.Core.DebugAttributeValueLog.GetAllDebugAttributeValueLogDataByBaseAttributeID(baseAttributeID, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Core.DebugAttributeValueLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.GetAllDebugAttributeValueLogDataByBaseAttributeID");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets all DebugAttributeValueLog data by criteria.</summary>
		///
		/// <param name="attributeValue">A key for DebugAttributeValueLog items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for DebugAttributeValueLog items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for DebugAttributeValueLog items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.DebugAttributeValueLog> GetAllDebugAttributeValueLogDataByCriteria(string attributeValue, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DataOptions dataOptions)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, ConfigurationInterface.CurrentUserID);
				BLL.SortableList<BLL.Core.DebugAttributeValueLog> sortableList = new BLL.SortableList<BLL.Core.DebugAttributeValueLog>(DAL.Core.DebugAttributeValueLog.GetAllDebugAttributeValueLogDataByCriteria(attributeValue, lastModifiedDateStart, lastModifiedDateEnd, ConfigurationInterface.DBOptions, dataOptions, ConfigurationInterface.DebugLevel), true, true);
				foreach(BLL.Core.DebugAttributeValueLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.GetAllDebugAttributeValueLogDataByCriteria");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets all DebugAttributeValueLog data by criteria.</summary>
		///
		/// <param name="attributeValue">A key for DebugAttributeValueLog items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for DebugAttributeValueLog items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for DebugAttributeValueLog items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.DebugAttributeValueLog> GetAllDebugAttributeValueLogDataByCriteria(string attributeValue, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.CurrentUserID);
				BLL.SortableList<BLL.Core.DebugAttributeValueLog> sortableList = new BLL.SortableList<BLL.Core.DebugAttributeValueLog>(DAL.Core.DebugAttributeValueLog.GetAllDebugAttributeValueLogDataByCriteria(attributeValue, lastModifiedDateStart, lastModifiedDateEnd, ConfigurationInterface.DBOptions, ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.DebugLevel), true, true);
				foreach(BLL.Core.DebugAttributeValueLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.GetAllDebugAttributeValueLogDataByCriteria");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets all DebugAttributeValueLog data by criteria.</summary>
		///
		/// <param name="attributeValue">A key for DebugAttributeValueLog items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for DebugAttributeValueLog items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for DebugAttributeValueLog items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.DebugAttributeValueLog> GetAllDebugAttributeValueLogDataByCriteria(string attributeValue, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Core.DebugAttributeValueLog> sortableList = new BLL.SortableList<BLL.Core.DebugAttributeValueLog>(DAL.Core.DebugAttributeValueLog.GetAllDebugAttributeValueLogDataByCriteria(attributeValue, lastModifiedDateStart, lastModifiedDateEnd, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Core.DebugAttributeValueLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.GetAllDebugAttributeValueLogDataByCriteria");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets all DebugAttributeValueLog data by a key.</summary>
		///
		/// <param name="debugLogID">A key for DebugAttributeValueLog items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.DebugAttributeValueLog> GetAllDebugAttributeValueLogDataByDebugLogID(Guid debugLogID, MOD.Data.DataOptions dataOptions)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, ConfigurationInterface.CurrentUserID);
				BLL.SortableList<BLL.Core.DebugAttributeValueLog> sortableList = new BLL.SortableList<BLL.Core.DebugAttributeValueLog>(DAL.Core.DebugAttributeValueLog.GetAllDebugAttributeValueLogDataByDebugLogID(debugLogID, ConfigurationInterface.DBOptions, dataOptions, ConfigurationInterface.DebugLevel), true, true);
				foreach(BLL.Core.DebugAttributeValueLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.GetAllDebugAttributeValueLogDataByDebugLogID");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets all DebugAttributeValueLog data by a key.</summary>
		///
		/// <param name="debugLogID">A key for DebugAttributeValueLog items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.DebugAttributeValueLog> GetAllDebugAttributeValueLogDataByDebugLogID(Guid debugLogID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.CurrentUserID);
				BLL.SortableList<BLL.Core.DebugAttributeValueLog> sortableList = new BLL.SortableList<BLL.Core.DebugAttributeValueLog>(DAL.Core.DebugAttributeValueLog.GetAllDebugAttributeValueLogDataByDebugLogID(debugLogID, ConfigurationInterface.DBOptions, ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.DebugLevel), true, true);
				foreach(BLL.Core.DebugAttributeValueLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.GetAllDebugAttributeValueLogDataByDebugLogID");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets all DebugAttributeValueLog data by a key.</summary>
		///
		/// <param name="debugLogID">A key for DebugAttributeValueLog items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.DebugAttributeValueLog> GetAllDebugAttributeValueLogDataByDebugLogID(Guid debugLogID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Core.DebugAttributeValueLog> sortableList = new BLL.SortableList<BLL.Core.DebugAttributeValueLog>(DAL.Core.DebugAttributeValueLog.GetAllDebugAttributeValueLogDataByDebugLogID(debugLogID, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Core.DebugAttributeValueLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.GetAllDebugAttributeValueLogDataByDebugLogID");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets all DebugAttributeValueLog data by criteria.</summary>
		///
		/// <param name="attributeValue">A key for DebugAttributeValueLog items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for DebugAttributeValueLog items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for DebugAttributeValueLog items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.DebugAttributeValueLog> GetManyDebugAttributeValueLogDataByCriteria(string attributeValue, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DataOptions dataOptions)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, ConfigurationInterface.CurrentUserID);
				BLL.SortableList<BLL.Core.DebugAttributeValueLog> sortableList = new BLL.SortableList<BLL.Core.DebugAttributeValueLog>(DAL.Core.DebugAttributeValueLog.GetManyDebugAttributeValueLogDataByCriteria(attributeValue, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, ConfigurationInterface.DBOptions, dataOptions, ConfigurationInterface.DebugLevel), true, true);
				foreach(BLL.Core.DebugAttributeValueLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.GetManyDebugAttributeValueLogDataByCriteria");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets all DebugAttributeValueLog data by criteria.</summary>
		///
		/// <param name="attributeValue">A key for DebugAttributeValueLog items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for DebugAttributeValueLog items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for DebugAttributeValueLog items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.DebugAttributeValueLog> GetManyDebugAttributeValueLogDataByCriteria(string attributeValue, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Core.DebugAttributeValueLog> sortableList = new BLL.SortableList<BLL.Core.DebugAttributeValueLog>(DAL.Core.DebugAttributeValueLog.GetManyDebugAttributeValueLogDataByCriteria(attributeValue, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Core.DebugAttributeValueLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.GetManyDebugAttributeValueLogDataByCriteria");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets a single DebugAttributeValueLog by an index.</summary>
		///
		/// <param name="debugAttributeValueLogID">The index for DebugAttributeValueLog to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Core.DebugAttributeValueLog GetOneDebugAttributeValueLog(Guid debugAttributeValueLogID, MOD.Data.DataOptions dataOptions)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, ConfigurationInterface.CurrentUserID);
				DAL.Core.DebugAttributeValueLog item = null;
				item = DAL.Core.DebugAttributeValueLog.GetOneDebugAttributeValueLog(debugAttributeValueLogID, ConfigurationInterface.DBOptions, dataOptions, ConfigurationInterface.DebugLevel);
				BLL.Core.DebugAttributeValueLog itemBLL = null;
				if (item != null)
				{
					itemBLL = new BLL.Core.DebugAttributeValueLog();
					ReflectionHelper.Copy(item, itemBLL, true);
					itemBLL.ClearDirtyState(true);
					itemBLL.IsLoaded = true;
				}
				return itemBLL;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.GetOneDebugAttributeValueLog");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets a single DebugAttributeValueLog by an index.</summary>
		///
		/// <param name="debugAttributeValueLogID">The index for DebugAttributeValueLog to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Core.DebugAttributeValueLog GetOneDebugAttributeValueLog(Guid debugAttributeValueLogID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.CurrentUserID);
				DAL.Core.DebugAttributeValueLog item = null;
				item = DAL.Core.DebugAttributeValueLog.GetOneDebugAttributeValueLog(debugAttributeValueLogID, ConfigurationInterface.DBOptions, ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.DebugLevel);
				BLL.Core.DebugAttributeValueLog itemBLL = null;
				if (item != null)
				{
					itemBLL = new BLL.Core.DebugAttributeValueLog();
					ReflectionHelper.Copy(item, itemBLL, true);
					itemBLL.ClearDirtyState(true);
					itemBLL.IsLoaded = true;
				}
				return itemBLL;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.GetOneDebugAttributeValueLog");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets a single DebugAttributeValueLog by an index.</summary>
		///
		/// <param name="debugAttributeValueLogID">The index for DebugAttributeValueLog to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Core.DebugAttributeValueLog GetOneDebugAttributeValueLog(Guid debugAttributeValueLogID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				DAL.Core.DebugAttributeValueLog item = null;
				item = DAL.Core.DebugAttributeValueLog.GetOneDebugAttributeValueLog(debugAttributeValueLogID, dbOptions, dataOptions, debugLevel);
				BLL.Core.DebugAttributeValueLog itemBLL = null;
				if (item != null)
				{
					itemBLL = new BLL.Core.DebugAttributeValueLog();
					ReflectionHelper.Copy(item, itemBLL, true);
					itemBLL.ClearDirtyState(true);
					itemBLL.IsLoaded = true;
				}
				return itemBLL;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.GetOneDebugAttributeValueLog");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets a single DebugAttributeValueLog by an index.</summary>
		///
		/// <param name="debugAttributeValueLogID">The index for DebugAttributeValueLog to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Core.DebugAttributeValueLog GetOneDebugAttributeValueLogByDebugAttributeValueLogID(Guid debugAttributeValueLogID, MOD.Data.DataOptions dataOptions)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, ConfigurationInterface.CurrentUserID);
				DAL.Core.DebugAttributeValueLog item = null;
				item = DAL.Core.DebugAttributeValueLog.GetOneDebugAttributeValueLogByDebugAttributeValueLogID(debugAttributeValueLogID, ConfigurationInterface.DBOptions, dataOptions, ConfigurationInterface.DebugLevel);
				BLL.Core.DebugAttributeValueLog itemBLL = null;
				if (item != null)
				{
					itemBLL = new BLL.Core.DebugAttributeValueLog();
					ReflectionHelper.Copy(item, itemBLL, true);
					itemBLL.ClearDirtyState(true);
					itemBLL.IsLoaded = true;
				}
				return itemBLL;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.GetOneDebugAttributeValueLogByDebugAttributeValueLogID");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets a single DebugAttributeValueLog by an index.</summary>
		///
		/// <param name="debugAttributeValueLogID">The index for DebugAttributeValueLog to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Core.DebugAttributeValueLog GetOneDebugAttributeValueLogByDebugAttributeValueLogID(Guid debugAttributeValueLogID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.CurrentUserID);
				DAL.Core.DebugAttributeValueLog item = null;
				item = DAL.Core.DebugAttributeValueLog.GetOneDebugAttributeValueLogByDebugAttributeValueLogID(debugAttributeValueLogID, ConfigurationInterface.DBOptions, ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.DebugLevel);
				BLL.Core.DebugAttributeValueLog itemBLL = null;
				if (item != null)
				{
					itemBLL = new BLL.Core.DebugAttributeValueLog();
					ReflectionHelper.Copy(item, itemBLL, true);
					itemBLL.ClearDirtyState(true);
					itemBLL.IsLoaded = true;
				}
				return itemBLL;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.GetOneDebugAttributeValueLogByDebugAttributeValueLogID");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets a single DebugAttributeValueLog by an index.</summary>
		///
		/// <param name="debugAttributeValueLogID">The index for DebugAttributeValueLog to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Core.DebugAttributeValueLog GetOneDebugAttributeValueLogByDebugAttributeValueLogID(Guid debugAttributeValueLogID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				DAL.Core.DebugAttributeValueLog item = null;
				item = DAL.Core.DebugAttributeValueLog.GetOneDebugAttributeValueLogByDebugAttributeValueLogID(debugAttributeValueLogID, dbOptions, dataOptions, debugLevel);
				BLL.Core.DebugAttributeValueLog itemBLL = null;
				if (item != null)
				{
					itemBLL = new BLL.Core.DebugAttributeValueLog();
					ReflectionHelper.Copy(item, itemBLL, true);
					itemBLL.ClearDirtyState(true);
					itemBLL.IsLoaded = true;
				}
				return itemBLL;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.GetOneDebugAttributeValueLogByDebugAttributeValueLogID");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method logs DebugAttributeValueLog data.</summary>
		///
		/// <param name="item">The DebugAttributeValueLog to be logged.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void LogOneDebugAttributeValueLog(BLL.Core.DebugAttributeValueLog item, bool performCascadeOperation )
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = ConfigurationInterface.CurrentUserID;
				item.LastModifiedByUserID = ConfigurationInterface.CurrentUserID;
				DAL.Core.DebugAttributeValueLog itemDAL = new DAL.Core.DebugAttributeValueLog();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Core.DebugAttributeValueLog.LogOneDebugAttributeValueLog(itemDAL, performCascadeOperation, ConfigurationInterface.DBOptions, ConfigurationInterface.DebugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.LogOneDebugAttributeValueLog");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method logs DebugAttributeValueLog data.</summary>
		///
		/// <param name="item">The DebugAttributeValueLog to be logged.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void LogOneDebugAttributeValueLog(BLL.Core.DebugAttributeValueLog item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Core.DebugAttributeValueLog itemDAL = new DAL.Core.DebugAttributeValueLog();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Core.DebugAttributeValueLog.LogOneDebugAttributeValueLog(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.LogOneDebugAttributeValueLog");
			}
		}
		#endregion Methods
	}
}