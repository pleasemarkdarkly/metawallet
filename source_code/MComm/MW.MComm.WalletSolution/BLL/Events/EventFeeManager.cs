
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
	/// <summary>This class is used to manage EventFee related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class EventFeeManager
	{
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public EventFeeManager()
		{
			//
			// constructor logic
			//
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------
		/// <summary>This method inserts EventFee data.</summary>
		///
		/// <param name="item">The EventFee to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneEventFee(BLL.Events.EventFee item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Events.EventFeeManager.AddOneEventFee(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method inserts EventFee data.</summary>
		///
		/// <param name="item">The EventFee to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneEventFee(BLL.Events.EventFee item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Events.EventFee itemDAL = new DAL.Events.EventFee();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Events.EventFee.AddOneEventFee(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Events.AddOneEventFee");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all EventFee data by a key.</summary>
		///
		/// <param name="eventCode">A key for EventFee items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllEventFeeDataByEventCode(int eventCode)
		{
			// perform main method tasks
			BLL.Events.EventFeeManager.DeleteAllEventFeeDataByEventCode(eventCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all EventFee data by a key.</summary>
		///
		/// <param name="eventCode">A key for EventFee items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllEventFeeDataByEventCode(int eventCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Events.EventFee.DeleteAllEventFeeDataByEventCode(eventCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Events.DeleteAllEventFeeDataByEventCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all EventFee data by a key.</summary>
		///
		/// <param name="feeCode">A key for EventFee items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllEventFeeDataByFeeCode(int feeCode)
		{
			// perform main method tasks
			BLL.Events.EventFeeManager.DeleteAllEventFeeDataByFeeCode(feeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all EventFee data by a key.</summary>
		///
		/// <param name="feeCode">A key for EventFee items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllEventFeeDataByFeeCode(int feeCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Events.EventFee.DeleteAllEventFeeDataByFeeCode(feeCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Events.DeleteAllEventFeeDataByFeeCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes EventFee data.</summary>
		///
		/// <param name="item">The EventFee to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneEventFee(BLL.Events.EventFee item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Events.EventFeeManager.DeleteOneEventFee(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes EventFee data.</summary>
		///
		/// <param name="item">The EventFee to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneEventFee(BLL.Events.EventFee item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Events.EventFee itemDAL = new DAL.Events.EventFee();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Events.EventFee.DeleteOneEventFee(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = false;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Events.DeleteOneEventFee");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all EventFee data.</summary>
		///
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.EventFee> GetAllEventFeeData(MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Events.EventFeeManager.GetAllEventFeeData(BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all EventFee data.</summary>
		///
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.EventFee> GetAllEventFeeData()
		{
			// perform main method tasks
			return BLL.Events.EventFeeManager.GetAllEventFeeData(BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all EventFee data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.EventFee> GetAllEventFeeData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Events.EventFee> sortableList = new BLL.SortableList<BLL.Events.EventFee>(DAL.Events.EventFee.GetAllEventFeeData(dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Events.EventFee loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Events.GetAllEventFeeData");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all EventFee data by a key.</summary>
		///
		/// <param name="eventCode">A key for EventFee items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.EventFee> GetAllEventFeeDataByEventCode(int eventCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Events.EventFeeManager.GetAllEventFeeDataByEventCode(eventCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all EventFee data by a key.</summary>
		///
		/// <param name="eventCode">A key for EventFee items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.EventFee> GetAllEventFeeDataByEventCode(int eventCode)
		{
			// perform main method tasks
			return BLL.Events.EventFeeManager.GetAllEventFeeDataByEventCode(eventCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all EventFee data by a key.</summary>
		///
		/// <param name="eventCode">A key for EventFee items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.EventFee> GetAllEventFeeDataByEventCode(int eventCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Events.EventFee> sortableList = new BLL.SortableList<BLL.Events.EventFee>(DAL.Events.EventFee.GetAllEventFeeDataByEventCode(eventCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Events.EventFee loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Events.GetAllEventFeeDataByEventCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all EventFee data by a key.</summary>
		///
		/// <param name="feeCode">A key for EventFee items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.EventFee> GetAllEventFeeDataByFeeCode(int feeCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Events.EventFeeManager.GetAllEventFeeDataByFeeCode(feeCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all EventFee data by a key.</summary>
		///
		/// <param name="feeCode">A key for EventFee items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.EventFee> GetAllEventFeeDataByFeeCode(int feeCode)
		{
			// perform main method tasks
			return BLL.Events.EventFeeManager.GetAllEventFeeDataByFeeCode(feeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all EventFee data by a key.</summary>
		///
		/// <param name="feeCode">A key for EventFee items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.EventFee> GetAllEventFeeDataByFeeCode(int feeCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Events.EventFee> sortableList = new BLL.SortableList<BLL.Events.EventFee>(DAL.Events.EventFee.GetAllEventFeeDataByFeeCode(feeCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Events.EventFee loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Events.GetAllEventFeeDataByFeeCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single EventFee by an index.</summary>
		///
		/// <param name="eventCode">The index for EventFee to be fetched</param>
		/// <param name="feeCode">The index for EventFee to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Events.EventFee GetOneEventFee(int eventCode, int feeCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Events.EventFeeManager.GetOneEventFee(eventCode, feeCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single EventFee by an index.</summary>
		///
		/// <param name="eventCode">The index for EventFee to be fetched</param>
		/// <param name="feeCode">The index for EventFee to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Events.EventFee GetOneEventFee(int eventCode, int feeCode)
		{
			// perform main method tasks
			return BLL.Events.EventFeeManager.GetOneEventFee(eventCode, feeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single EventFee by an index.</summary>
		///
		/// <param name="eventCode">The index for EventFee to be fetched</param>
		/// <param name="feeCode">The index for EventFee to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Events.EventFee GetOneEventFee(int eventCode, int feeCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.Events.EventFee itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.Events.EventFee)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.Events.EventFee.GetCacheKey(typeof(BLL.Events.EventFee), "PrimaryKey", eventCode.ToString() + ", " + feeCode.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.Events.EventFee)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.Events.EventFee item = DAL.Events.EventFee.GetOneEventFee(eventCode, feeCode, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.Events.EventFee();
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
				throw Utility.CustomAppException.WrapException(ex, "BLL.Events.GetOneEventFee");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates EventFee data.</summary>
		///
		/// <param name="item">The EventFee to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneEventFee(BLL.Events.EventFee item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Events.EventFeeManager.UpdateOneEventFee(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates EventFee data.</summary>
		///
		/// <param name="item">The EventFee to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneEventFee(BLL.Events.EventFee item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Events.EventFee itemDAL = new DAL.Events.EventFee();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Events.EventFee.UpdateOneEventFee(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Events.UpdateOneEventFee");
			}
		}
		#endregion Methods
	}
}