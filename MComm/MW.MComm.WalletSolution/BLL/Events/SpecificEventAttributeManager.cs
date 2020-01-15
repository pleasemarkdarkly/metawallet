
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
	/// <summary>This class is used to manage SpecificEventAttribute related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class SpecificEventAttributeManager
	{
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public SpecificEventAttributeManager()
		{
			//
			// constructor logic
			//
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------
		/// <summary>This method inserts SpecificEventAttribute data.</summary>
		///
		/// <param name="item">The SpecificEventAttribute to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneSpecificEventAttribute(BLL.Events.SpecificEventAttribute item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Events.SpecificEventAttributeManager.AddOneSpecificEventAttribute(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method inserts SpecificEventAttribute data.</summary>
		///
		/// <param name="item">The SpecificEventAttribute to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneSpecificEventAttribute(BLL.Events.SpecificEventAttribute item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Events.SpecificEventAttribute itemDAL = new DAL.Events.SpecificEventAttribute();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Events.SpecificEventAttribute.AddOneSpecificEventAttribute(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Events.AddOneSpecificEventAttribute");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all SpecificEventAttribute data by a key.</summary>
		///
		/// <param name="baseAttributeID">A key for SpecificEventAttribute items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllSpecificEventAttributeDataByBaseAttributeID(Guid baseAttributeID)
		{
			// perform main method tasks
			BLL.Events.SpecificEventAttributeManager.DeleteAllSpecificEventAttributeDataByBaseAttributeID(baseAttributeID, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all SpecificEventAttribute data by a key.</summary>
		///
		/// <param name="baseAttributeID">A key for SpecificEventAttribute items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllSpecificEventAttributeDataByBaseAttributeID(Guid baseAttributeID, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Events.SpecificEventAttribute.DeleteAllSpecificEventAttributeDataByBaseAttributeID(baseAttributeID, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Events.DeleteAllSpecificEventAttributeDataByBaseAttributeID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all SpecificEventAttribute data by a key.</summary>
		///
		/// <param name="eventCode">A key for SpecificEventAttribute items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllSpecificEventAttributeDataByEventCode(int eventCode)
		{
			// perform main method tasks
			BLL.Events.SpecificEventAttributeManager.DeleteAllSpecificEventAttributeDataByEventCode(eventCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all SpecificEventAttribute data by a key.</summary>
		///
		/// <param name="eventCode">A key for SpecificEventAttribute items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllSpecificEventAttributeDataByEventCode(int eventCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Events.SpecificEventAttribute.DeleteAllSpecificEventAttributeDataByEventCode(eventCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Events.DeleteAllSpecificEventAttributeDataByEventCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes SpecificEventAttribute data.</summary>
		///
		/// <param name="item">The SpecificEventAttribute to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneSpecificEventAttribute(BLL.Events.SpecificEventAttribute item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Events.SpecificEventAttributeManager.DeleteOneSpecificEventAttribute(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes SpecificEventAttribute data.</summary>
		///
		/// <param name="item">The SpecificEventAttribute to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneSpecificEventAttribute(BLL.Events.SpecificEventAttribute item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Events.SpecificEventAttribute itemDAL = new DAL.Events.SpecificEventAttribute();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Events.SpecificEventAttribute.DeleteOneSpecificEventAttribute(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = false;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Events.DeleteOneSpecificEventAttribute");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all SpecificEventAttribute data.</summary>
		///
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.SpecificEventAttribute> GetAllSpecificEventAttributeData(MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Events.SpecificEventAttributeManager.GetAllSpecificEventAttributeData(BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all SpecificEventAttribute data.</summary>
		///
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.SpecificEventAttribute> GetAllSpecificEventAttributeData()
		{
			// perform main method tasks
			return BLL.Events.SpecificEventAttributeManager.GetAllSpecificEventAttributeData(BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all SpecificEventAttribute data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.SpecificEventAttribute> GetAllSpecificEventAttributeData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Events.SpecificEventAttribute> sortableList = new BLL.SortableList<BLL.Events.SpecificEventAttribute>(DAL.Events.SpecificEventAttribute.GetAllSpecificEventAttributeData(dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Events.SpecificEventAttribute loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Events.GetAllSpecificEventAttributeData");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all SpecificEventAttribute data by a key.</summary>
		///
		/// <param name="baseAttributeID">A key for SpecificEventAttribute items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.SpecificEventAttribute> GetAllSpecificEventAttributeDataByBaseAttributeID(Guid baseAttributeID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Events.SpecificEventAttributeManager.GetAllSpecificEventAttributeDataByBaseAttributeID(baseAttributeID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all SpecificEventAttribute data by a key.</summary>
		///
		/// <param name="baseAttributeID">A key for SpecificEventAttribute items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.SpecificEventAttribute> GetAllSpecificEventAttributeDataByBaseAttributeID(Guid baseAttributeID)
		{
			// perform main method tasks
			return BLL.Events.SpecificEventAttributeManager.GetAllSpecificEventAttributeDataByBaseAttributeID(baseAttributeID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all SpecificEventAttribute data by a key.</summary>
		///
		/// <param name="baseAttributeID">A key for SpecificEventAttribute items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.SpecificEventAttribute> GetAllSpecificEventAttributeDataByBaseAttributeID(Guid baseAttributeID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Events.SpecificEventAttribute> sortableList = new BLL.SortableList<BLL.Events.SpecificEventAttribute>(DAL.Events.SpecificEventAttribute.GetAllSpecificEventAttributeDataByBaseAttributeID(baseAttributeID, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Events.SpecificEventAttribute loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Events.GetAllSpecificEventAttributeDataByBaseAttributeID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all SpecificEventAttribute data by a key.</summary>
		///
		/// <param name="eventCode">A key for SpecificEventAttribute items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.SpecificEventAttribute> GetAllSpecificEventAttributeDataByEventCode(int eventCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Events.SpecificEventAttributeManager.GetAllSpecificEventAttributeDataByEventCode(eventCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all SpecificEventAttribute data by a key.</summary>
		///
		/// <param name="eventCode">A key for SpecificEventAttribute items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.SpecificEventAttribute> GetAllSpecificEventAttributeDataByEventCode(int eventCode)
		{
			// perform main method tasks
			return BLL.Events.SpecificEventAttributeManager.GetAllSpecificEventAttributeDataByEventCode(eventCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all SpecificEventAttribute data by a key.</summary>
		///
		/// <param name="eventCode">A key for SpecificEventAttribute items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.SpecificEventAttribute> GetAllSpecificEventAttributeDataByEventCode(int eventCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Events.SpecificEventAttribute> sortableList = new BLL.SortableList<BLL.Events.SpecificEventAttribute>(DAL.Events.SpecificEventAttribute.GetAllSpecificEventAttributeDataByEventCode(eventCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Events.SpecificEventAttribute loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Events.GetAllSpecificEventAttributeDataByEventCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single SpecificEventAttribute by an index.</summary>
		///
		/// <param name="eventCode">The index for SpecificEventAttribute to be fetched</param>
		/// <param name="baseAttributeID">The index for SpecificEventAttribute to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Events.SpecificEventAttribute GetOneSpecificEventAttribute(int eventCode, Guid baseAttributeID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Events.SpecificEventAttributeManager.GetOneSpecificEventAttribute(eventCode, baseAttributeID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single SpecificEventAttribute by an index.</summary>
		///
		/// <param name="eventCode">The index for SpecificEventAttribute to be fetched</param>
		/// <param name="baseAttributeID">The index for SpecificEventAttribute to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Events.SpecificEventAttribute GetOneSpecificEventAttribute(int eventCode, Guid baseAttributeID)
		{
			// perform main method tasks
			return BLL.Events.SpecificEventAttributeManager.GetOneSpecificEventAttribute(eventCode, baseAttributeID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single SpecificEventAttribute by an index.</summary>
		///
		/// <param name="eventCode">The index for SpecificEventAttribute to be fetched</param>
		/// <param name="baseAttributeID">The index for SpecificEventAttribute to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Events.SpecificEventAttribute GetOneSpecificEventAttribute(int eventCode, Guid baseAttributeID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.Events.SpecificEventAttribute itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.Events.SpecificEventAttribute)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.Events.SpecificEventAttribute.GetCacheKey(typeof(BLL.Events.SpecificEventAttribute), "PrimaryKey", eventCode.ToString() + ", " + baseAttributeID.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.Events.SpecificEventAttribute)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.Events.SpecificEventAttribute item = DAL.Events.SpecificEventAttribute.GetOneSpecificEventAttribute(eventCode, baseAttributeID, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.Events.SpecificEventAttribute();
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
				throw Utility.CustomAppException.WrapException(ex, "BLL.Events.GetOneSpecificEventAttribute");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates SpecificEventAttribute data.</summary>
		///
		/// <param name="item">The SpecificEventAttribute to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneSpecificEventAttribute(BLL.Events.SpecificEventAttribute item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Events.SpecificEventAttributeManager.UpdateOneSpecificEventAttribute(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates SpecificEventAttribute data.</summary>
		///
		/// <param name="item">The SpecificEventAttribute to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneSpecificEventAttribute(BLL.Events.SpecificEventAttribute item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Events.SpecificEventAttribute itemDAL = new DAL.Events.SpecificEventAttribute();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Events.SpecificEventAttribute.UpdateOneSpecificEventAttribute(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Events.UpdateOneSpecificEventAttribute");
			}
		}
		#endregion Methods
	}
}