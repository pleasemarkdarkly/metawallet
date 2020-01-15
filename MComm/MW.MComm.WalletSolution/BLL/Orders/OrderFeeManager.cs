
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
using MW.MComm.WalletSolution.BLL.Orders;
using MOD.Data;
using MW.MComm.WalletSolution.BLL.Config;
using BLL = MW.MComm.WalletSolution.BLL;
using DAL = MW.MComm.WalletSolution.DAL;
using Utility = MW.MComm.WalletSolution.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
namespace MW.MComm.WalletSolution.BLL.Orders
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage OrderFee related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class OrderFeeManager
	{
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public OrderFeeManager()
		{
			//
			// constructor logic
			//
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------
		/// <summary>This method inserts OrderFee data.</summary>
		///
		/// <param name="item">The OrderFee to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneOrderFee(BLL.Orders.OrderFee item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Orders.OrderFeeManager.AddOneOrderFee(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method inserts OrderFee data.</summary>
		///
		/// <param name="item">The OrderFee to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneOrderFee(BLL.Orders.OrderFee item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Orders.OrderFee itemDAL = new DAL.Orders.OrderFee();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Orders.OrderFee.AddOneOrderFee(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Orders.AddOneOrderFee");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all OrderFee data by a key.</summary>
		///
		/// <param name="feeCode">A key for OrderFee items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllOrderFeeDataByFeeCode(int feeCode)
		{
			// perform main method tasks
			BLL.Orders.OrderFeeManager.DeleteAllOrderFeeDataByFeeCode(feeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all OrderFee data by a key.</summary>
		///
		/// <param name="feeCode">A key for OrderFee items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllOrderFeeDataByFeeCode(int feeCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Orders.OrderFee.DeleteAllOrderFeeDataByFeeCode(feeCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Orders.DeleteAllOrderFeeDataByFeeCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all OrderFee data by a key.</summary>
		///
		/// <param name="orderID">A key for OrderFee items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllOrderFeeDataByOrderID(Guid orderID)
		{
			// perform main method tasks
			BLL.Orders.OrderFeeManager.DeleteAllOrderFeeDataByOrderID(orderID, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all OrderFee data by a key.</summary>
		///
		/// <param name="orderID">A key for OrderFee items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllOrderFeeDataByOrderID(Guid orderID, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Orders.OrderFee.DeleteAllOrderFeeDataByOrderID(orderID, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Orders.DeleteAllOrderFeeDataByOrderID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes OrderFee data.</summary>
		///
		/// <param name="item">The OrderFee to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneOrderFee(BLL.Orders.OrderFee item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Orders.OrderFeeManager.DeleteOneOrderFee(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes OrderFee data.</summary>
		///
		/// <param name="item">The OrderFee to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneOrderFee(BLL.Orders.OrderFee item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Orders.OrderFee itemDAL = new DAL.Orders.OrderFee();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Orders.OrderFee.DeleteOneOrderFee(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = false;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Orders.DeleteOneOrderFee");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all OrderFee data.</summary>
		///
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Orders.OrderFee> GetAllOrderFeeData(MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Orders.OrderFeeManager.GetAllOrderFeeData(BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all OrderFee data.</summary>
		///
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Orders.OrderFee> GetAllOrderFeeData()
		{
			// perform main method tasks
			return BLL.Orders.OrderFeeManager.GetAllOrderFeeData(BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all OrderFee data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Orders.OrderFee> GetAllOrderFeeData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Orders.OrderFee> sortableList = new BLL.SortableList<BLL.Orders.OrderFee>(DAL.Orders.OrderFee.GetAllOrderFeeData(dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Orders.OrderFee loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Orders.GetAllOrderFeeData");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all OrderFee data by a key.</summary>
		///
		/// <param name="feeCode">A key for OrderFee items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Orders.OrderFee> GetAllOrderFeeDataByFeeCode(int feeCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Orders.OrderFeeManager.GetAllOrderFeeDataByFeeCode(feeCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all OrderFee data by a key.</summary>
		///
		/// <param name="feeCode">A key for OrderFee items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Orders.OrderFee> GetAllOrderFeeDataByFeeCode(int feeCode)
		{
			// perform main method tasks
			return BLL.Orders.OrderFeeManager.GetAllOrderFeeDataByFeeCode(feeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all OrderFee data by a key.</summary>
		///
		/// <param name="feeCode">A key for OrderFee items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Orders.OrderFee> GetAllOrderFeeDataByFeeCode(int feeCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Orders.OrderFee> sortableList = new BLL.SortableList<BLL.Orders.OrderFee>(DAL.Orders.OrderFee.GetAllOrderFeeDataByFeeCode(feeCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Orders.OrderFee loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Orders.GetAllOrderFeeDataByFeeCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all OrderFee data by a key.</summary>
		///
		/// <param name="orderID">A key for OrderFee items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Orders.OrderFee> GetAllOrderFeeDataByOrderID(Guid orderID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Orders.OrderFeeManager.GetAllOrderFeeDataByOrderID(orderID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all OrderFee data by a key.</summary>
		///
		/// <param name="orderID">A key for OrderFee items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Orders.OrderFee> GetAllOrderFeeDataByOrderID(Guid orderID)
		{
			// perform main method tasks
			return BLL.Orders.OrderFeeManager.GetAllOrderFeeDataByOrderID(orderID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all OrderFee data by a key.</summary>
		///
		/// <param name="orderID">A key for OrderFee items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Orders.OrderFee> GetAllOrderFeeDataByOrderID(Guid orderID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Orders.OrderFee> sortableList = new BLL.SortableList<BLL.Orders.OrderFee>(DAL.Orders.OrderFee.GetAllOrderFeeDataByOrderID(orderID, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Orders.OrderFee loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Orders.GetAllOrderFeeDataByOrderID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single OrderFee by an index.</summary>
		///
		/// <param name="orderID">The index for OrderFee to be fetched</param>
		/// <param name="feeCode">The index for OrderFee to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Orders.OrderFee GetOneOrderFee(Guid orderID, int feeCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Orders.OrderFeeManager.GetOneOrderFee(orderID, feeCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single OrderFee by an index.</summary>
		///
		/// <param name="orderID">The index for OrderFee to be fetched</param>
		/// <param name="feeCode">The index for OrderFee to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Orders.OrderFee GetOneOrderFee(Guid orderID, int feeCode)
		{
			// perform main method tasks
			return BLL.Orders.OrderFeeManager.GetOneOrderFee(orderID, feeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single OrderFee by an index.</summary>
		///
		/// <param name="orderID">The index for OrderFee to be fetched</param>
		/// <param name="feeCode">The index for OrderFee to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Orders.OrderFee GetOneOrderFee(Guid orderID, int feeCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.Orders.OrderFee itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.Orders.OrderFee)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.Orders.OrderFee.GetCacheKey(typeof(BLL.Orders.OrderFee), "PrimaryKey", orderID.ToString() + ", " + feeCode.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.Orders.OrderFee)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.Orders.OrderFee item = DAL.Orders.OrderFee.GetOneOrderFee(orderID, feeCode, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.Orders.OrderFee();
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
				throw Utility.CustomAppException.WrapException(ex, "BLL.Orders.GetOneOrderFee");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates OrderFee data.</summary>
		///
		/// <param name="item">The OrderFee to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneOrderFee(BLL.Orders.OrderFee item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Orders.OrderFeeManager.UpdateOneOrderFee(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates OrderFee data.</summary>
		///
		/// <param name="item">The OrderFee to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneOrderFee(BLL.Orders.OrderFee item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Orders.OrderFee itemDAL = new DAL.Orders.OrderFee();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Orders.OrderFee.UpdateOneOrderFee(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Orders.UpdateOneOrderFee");
			}
		}
		#endregion Methods
	}
}