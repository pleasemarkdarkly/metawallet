

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
	/// <summary>This class is used to manage SeverityLevel related information.</summary>
	///
	/// File History:
	/// <created>10/20/2006 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class SeverityLevelManager
	{

		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public SeverityLevelManager()
		{
			//
			// constructor logic
			//
		}

		#endregion Constructors

		#region Methods

		// ------------------------------------------------------------------------------
		/// <summary>This method loads the SeverityLevel from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public static BLL.Core.SeverityLevel Load(int severityLevelCode)
		{
			BLL.Core.SeverityLevel businessObject = new BLL.Core.SeverityLevel(severityLevelCode);
			string key = BLL.Core.SeverityLevel.GetCacheKey(typeof(BLL.Core.SeverityLevel), "PrimaryKey", businessObject.PrimaryKey);
			businessObject = (BLL.Core.SeverityLevel)Utility.CacheManager.Cache[key];
			if (businessObject == null)
			{
				businessObject = BLL.Core.SeverityLevelManager.GetOneSeverityLevel(severityLevelCode);
				Utility.CacheManager.Cache.Add(key, businessObject);
			}
			return businessObject;
		}


		// ------------------------------------------------------------------
		/// <summary>This method inserts SeverityLevel data.</summary>
		///
		/// <param name="item">The SeverityLevel to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneSeverityLevel(BLL.Core.SeverityLevel item, bool performCascadeOperation )
		{
			try
			{
				// perform main method tasks
				// perform enum check
				if (Enum.IsDefined(typeof(SeverityLevelCode), item.SeverityLevelCode) == true)
				{
					throw new Utility.CustomAppException(BLL.Core.ErrorNumber.EnumerationAddException, BLL.Core.ErrorManager.GetErrorMessageFromErrorNumber(BLL.Core.ErrorNumber.EnumerationAddException), null);
				}

				item.CreatedByUserID = ConfigurationInterface.CurrentUserID;
				item.LastModifiedByUserID = ConfigurationInterface.CurrentUserID;
				DAL.Core.SeverityLevel itemDAL = new DAL.Core.SeverityLevel();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Core.SeverityLevel.AddOneSeverityLevel(itemDAL, performCascadeOperation, ConfigurationInterface.DBOptions, ConfigurationInterface.DebugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.AddOneSeverityLevel");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method inserts SeverityLevel data.</summary>
		///
		/// <param name="item">The SeverityLevel to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneSeverityLevel(BLL.Core.SeverityLevel item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				// perform enum check
				if (Enum.IsDefined(typeof(SeverityLevelCode), item.SeverityLevelCode) == true)
				{
					throw new Utility.CustomAppException(BLL.Core.ErrorNumber.EnumerationAddException, BLL.Core.ErrorManager.GetErrorMessageFromErrorNumber(BLL.Core.ErrorNumber.EnumerationAddException), null);
				}

				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Core.SeverityLevel itemDAL = new DAL.Core.SeverityLevel();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Core.SeverityLevel.AddOneSeverityLevel(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.AddOneSeverityLevel");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method deletes SeverityLevel data.</summary>
		///
		/// <param name="item">The SeverityLevel to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneSeverityLevel(BLL.Core.SeverityLevel item, bool performCascadeOperation )
		{
			try
			{
				// perform main method tasks
				// perform enum check
				if (Enum.IsDefined(typeof(SeverityLevelCode), item.SeverityLevelCode) == true)
				{
					throw new Utility.CustomAppException(BLL.Core.ErrorNumber.EnumerationDeleteException, BLL.Core.ErrorManager.GetErrorMessageFromErrorNumber(BLL.Core.ErrorNumber.EnumerationDeleteException), null);
				}

				DAL.Core.SeverityLevel itemDAL = new DAL.Core.SeverityLevel();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Core.SeverityLevel.DeleteOneSeverityLevel(itemDAL, performCascadeOperation, ConfigurationInterface.DBOptions, ConfigurationInterface.DebugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = false;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.DeleteOneSeverityLevel");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method deletes SeverityLevel data.</summary>
		///
		/// <param name="item">The SeverityLevel to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneSeverityLevel(BLL.Core.SeverityLevel item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				// perform enum check
				if (Enum.IsDefined(typeof(SeverityLevelCode), item.SeverityLevelCode) == true)
				{
					throw new Utility.CustomAppException(BLL.Core.ErrorNumber.EnumerationDeleteException, BLL.Core.ErrorManager.GetErrorMessageFromErrorNumber(BLL.Core.ErrorNumber.EnumerationDeleteException), null);
				}

				DAL.Core.SeverityLevel itemDAL = new DAL.Core.SeverityLevel();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Core.SeverityLevel.DeleteOneSeverityLevel(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = false;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.DeleteOneSeverityLevel");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets all SeverityLevel data.</summary>
		///
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.SeverityLevel> GetAllSeverityLevelData(MOD.Data.DataOptions dataOptions)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, ConfigurationInterface.CurrentUserID);
				BLL.SortableList<BLL.Core.SeverityLevel> sortableList = new BLL.SortableList<BLL.Core.SeverityLevel>(DAL.Core.SeverityLevel.GetAllSeverityLevelData(ConfigurationInterface.DBOptions, dataOptions, ConfigurationInterface.DebugLevel), true, true);
				foreach(BLL.Core.SeverityLevel loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.GetAllSeverityLevelData");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets all SeverityLevel data.</summary>
		///
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.SeverityLevel> GetAllSeverityLevelData()
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.CurrentUserID);
				BLL.SortableList<BLL.Core.SeverityLevel> sortableList = new BLL.SortableList<BLL.Core.SeverityLevel>(DAL.Core.SeverityLevel.GetAllSeverityLevelData(ConfigurationInterface.DBOptions, ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.DebugLevel), true, true);
				foreach(BLL.Core.SeverityLevel loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.GetAllSeverityLevelData");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets all SeverityLevel data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.SeverityLevel> GetAllSeverityLevelData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Core.SeverityLevel> sortableList = new BLL.SortableList<BLL.Core.SeverityLevel>(DAL.Core.SeverityLevel.GetAllSeverityLevelData(dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Core.SeverityLevel loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.GetAllSeverityLevelData");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets a single SeverityLevel by an index.</summary>
		///
		/// <param name="severityLevelCode">The index for SeverityLevel to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Core.SeverityLevel GetOneSeverityLevel(int severityLevelCode, MOD.Data.DataOptions dataOptions)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, ConfigurationInterface.CurrentUserID);
				DAL.Core.SeverityLevel item = null;
				item = DAL.Core.SeverityLevel.GetOneSeverityLevel(severityLevelCode, ConfigurationInterface.DBOptions, dataOptions, ConfigurationInterface.DebugLevel);
				BLL.Core.SeverityLevel itemBLL = null;
				if (item != null)
				{
					itemBLL = new BLL.Core.SeverityLevel();
					ReflectionHelper.Copy(item, itemBLL, true);
					itemBLL.ClearDirtyState(true);
					itemBLL.IsLoaded = true;
				}
				return itemBLL;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.GetOneSeverityLevel");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets a single SeverityLevel by an index.</summary>
		///
		/// <param name="severityLevelCode">The index for SeverityLevel to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Core.SeverityLevel GetOneSeverityLevel(int severityLevelCode)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.CurrentUserID);
				DAL.Core.SeverityLevel item = null;
				item = DAL.Core.SeverityLevel.GetOneSeverityLevel(severityLevelCode, ConfigurationInterface.DBOptions, ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.DebugLevel);
				BLL.Core.SeverityLevel itemBLL = null;
				if (item != null)
				{
					itemBLL = new BLL.Core.SeverityLevel();
					ReflectionHelper.Copy(item, itemBLL, true);
					itemBLL.ClearDirtyState(true);
					itemBLL.IsLoaded = true;
				}
				return itemBLL;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.GetOneSeverityLevel");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets a single SeverityLevel by an index.</summary>
		///
		/// <param name="severityLevelCode">The index for SeverityLevel to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Core.SeverityLevel GetOneSeverityLevel(int severityLevelCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				DAL.Core.SeverityLevel item = null;
				item = DAL.Core.SeverityLevel.GetOneSeverityLevel(severityLevelCode, dbOptions, dataOptions, debugLevel);
				BLL.Core.SeverityLevel itemBLL = null;
				if (item != null)
				{
					itemBLL = new BLL.Core.SeverityLevel();
					ReflectionHelper.Copy(item, itemBLL, true);
					itemBLL.ClearDirtyState(true);
					itemBLL.IsLoaded = true;
				}
				return itemBLL;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.GetOneSeverityLevel");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method updates SeverityLevel data.</summary>
		///
		/// <param name="item">The SeverityLevel to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneSeverityLevel(BLL.Core.SeverityLevel item, bool performCascadeOperation )
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = ConfigurationInterface.CurrentUserID;
				item.LastModifiedByUserID = ConfigurationInterface.CurrentUserID;
				DAL.Core.SeverityLevel itemDAL = new DAL.Core.SeverityLevel();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Core.SeverityLevel.UpdateOneSeverityLevel(itemDAL, performCascadeOperation, ConfigurationInterface.DBOptions, ConfigurationInterface.DebugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.UpdateOneSeverityLevel");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method updates SeverityLevel data.</summary>
		///
		/// <param name="item">The SeverityLevel to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneSeverityLevel(BLL.Core.SeverityLevel item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Core.SeverityLevel itemDAL = new DAL.Core.SeverityLevel();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Core.SeverityLevel.UpdateOneSeverityLevel(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.UpdateOneSeverityLevel");
			}
		}
		#endregion Methods
	}
}