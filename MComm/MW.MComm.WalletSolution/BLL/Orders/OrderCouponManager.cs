
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
	/// <summary>This class is used to manage OrderCoupon related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class OrderCouponManager
	{
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public OrderCouponManager()
		{
			//
			// constructor logic
			//
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------
		/// <summary>This method inserts OrderCoupon data.</summary>
		///
		/// <param name="item">The OrderCoupon to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneOrderCoupon(BLL.Orders.OrderCoupon item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Orders.OrderCouponManager.AddOneOrderCoupon(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method inserts OrderCoupon data.</summary>
		///
		/// <param name="item">The OrderCoupon to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneOrderCoupon(BLL.Orders.OrderCoupon item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Orders.OrderCoupon itemDAL = new DAL.Orders.OrderCoupon();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Orders.OrderCoupon.AddOneOrderCoupon(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Orders.AddOneOrderCoupon");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all OrderCoupon data by a key.</summary>
		///
		/// <param name="metaPartnerCouponID">A key for OrderCoupon items to be deleted</param>
		/// <param name="debitMetaPartnerID">A key for OrderCoupon items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllOrderCouponDataByMetaPartnerCouponIDAndDebitMetaPartnerID(Guid metaPartnerCouponID, Guid debitMetaPartnerID)
		{
			// perform main method tasks
			BLL.Orders.OrderCouponManager.DeleteAllOrderCouponDataByMetaPartnerCouponIDAndDebitMetaPartnerID(metaPartnerCouponID, debitMetaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all OrderCoupon data by a key.</summary>
		///
		/// <param name="metaPartnerCouponID">A key for OrderCoupon items to be deleted</param>
		/// <param name="debitMetaPartnerID">A key for OrderCoupon items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllOrderCouponDataByMetaPartnerCouponIDAndDebitMetaPartnerID(Guid metaPartnerCouponID, Guid debitMetaPartnerID, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Orders.OrderCoupon.DeleteAllOrderCouponDataByMetaPartnerCouponIDAndDebitMetaPartnerID(metaPartnerCouponID, debitMetaPartnerID, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Orders.DeleteAllOrderCouponDataByMetaPartnerCouponIDAndDebitMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all OrderCoupon data by a key.</summary>
		///
		/// <param name="orderID">A key for OrderCoupon items to be deleted</param>
		/// <param name="debitMetaPartnerID">A key for OrderCoupon items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllOrderCouponDataByOrderIDAndDebitMetaPartnerID(Guid orderID, Guid debitMetaPartnerID)
		{
			// perform main method tasks
			BLL.Orders.OrderCouponManager.DeleteAllOrderCouponDataByOrderIDAndDebitMetaPartnerID(orderID, debitMetaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all OrderCoupon data by a key.</summary>
		///
		/// <param name="orderID">A key for OrderCoupon items to be deleted</param>
		/// <param name="debitMetaPartnerID">A key for OrderCoupon items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllOrderCouponDataByOrderIDAndDebitMetaPartnerID(Guid orderID, Guid debitMetaPartnerID, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Orders.OrderCoupon.DeleteAllOrderCouponDataByOrderIDAndDebitMetaPartnerID(orderID, debitMetaPartnerID, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Orders.DeleteAllOrderCouponDataByOrderIDAndDebitMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes OrderCoupon data.</summary>
		///
		/// <param name="item">The OrderCoupon to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneOrderCoupon(BLL.Orders.OrderCoupon item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Orders.OrderCouponManager.DeleteOneOrderCoupon(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes OrderCoupon data.</summary>
		///
		/// <param name="item">The OrderCoupon to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneOrderCoupon(BLL.Orders.OrderCoupon item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Orders.OrderCoupon itemDAL = new DAL.Orders.OrderCoupon();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Orders.OrderCoupon.DeleteOneOrderCoupon(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = false;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Orders.DeleteOneOrderCoupon");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all OrderCoupon data.</summary>
		///
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Orders.OrderCoupon> GetAllOrderCouponData(MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Orders.OrderCouponManager.GetAllOrderCouponData(BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all OrderCoupon data.</summary>
		///
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Orders.OrderCoupon> GetAllOrderCouponData()
		{
			// perform main method tasks
			return BLL.Orders.OrderCouponManager.GetAllOrderCouponData(BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all OrderCoupon data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Orders.OrderCoupon> GetAllOrderCouponData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Orders.OrderCoupon> sortableList = new BLL.SortableList<BLL.Orders.OrderCoupon>(DAL.Orders.OrderCoupon.GetAllOrderCouponData(dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Orders.OrderCoupon loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Orders.GetAllOrderCouponData");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all OrderCoupon data by a key.</summary>
		///
		/// <param name="metaPartnerCouponID">A key for OrderCoupon items to be fetched</param>
		/// <param name="debitMetaPartnerID">A key for OrderCoupon items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Orders.OrderCoupon> GetAllOrderCouponDataByMetaPartnerCouponIDAndDebitMetaPartnerID(Guid metaPartnerCouponID, Guid debitMetaPartnerID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Orders.OrderCouponManager.GetAllOrderCouponDataByMetaPartnerCouponIDAndDebitMetaPartnerID(metaPartnerCouponID, debitMetaPartnerID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all OrderCoupon data by a key.</summary>
		///
		/// <param name="metaPartnerCouponID">A key for OrderCoupon items to be fetched</param>
		/// <param name="debitMetaPartnerID">A key for OrderCoupon items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Orders.OrderCoupon> GetAllOrderCouponDataByMetaPartnerCouponIDAndDebitMetaPartnerID(Guid metaPartnerCouponID, Guid debitMetaPartnerID)
		{
			// perform main method tasks
			return BLL.Orders.OrderCouponManager.GetAllOrderCouponDataByMetaPartnerCouponIDAndDebitMetaPartnerID(metaPartnerCouponID, debitMetaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all OrderCoupon data by a key.</summary>
		///
		/// <param name="metaPartnerCouponID">A key for OrderCoupon items to be fetched</param>
		/// <param name="debitMetaPartnerID">A key for OrderCoupon items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Orders.OrderCoupon> GetAllOrderCouponDataByMetaPartnerCouponIDAndDebitMetaPartnerID(Guid metaPartnerCouponID, Guid debitMetaPartnerID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Orders.OrderCoupon> sortableList = new BLL.SortableList<BLL.Orders.OrderCoupon>(DAL.Orders.OrderCoupon.GetAllOrderCouponDataByMetaPartnerCouponIDAndDebitMetaPartnerID(metaPartnerCouponID, debitMetaPartnerID, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Orders.OrderCoupon loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Orders.GetAllOrderCouponDataByMetaPartnerCouponIDAndDebitMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all OrderCoupon data by a key.</summary>
		///
		/// <param name="orderID">A key for OrderCoupon items to be fetched</param>
		/// <param name="debitMetaPartnerID">A key for OrderCoupon items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Orders.OrderCoupon> GetAllOrderCouponDataByOrderIDAndDebitMetaPartnerID(Guid orderID, Guid debitMetaPartnerID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Orders.OrderCouponManager.GetAllOrderCouponDataByOrderIDAndDebitMetaPartnerID(orderID, debitMetaPartnerID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all OrderCoupon data by a key.</summary>
		///
		/// <param name="orderID">A key for OrderCoupon items to be fetched</param>
		/// <param name="debitMetaPartnerID">A key for OrderCoupon items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Orders.OrderCoupon> GetAllOrderCouponDataByOrderIDAndDebitMetaPartnerID(Guid orderID, Guid debitMetaPartnerID)
		{
			// perform main method tasks
			return BLL.Orders.OrderCouponManager.GetAllOrderCouponDataByOrderIDAndDebitMetaPartnerID(orderID, debitMetaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all OrderCoupon data by a key.</summary>
		///
		/// <param name="orderID">A key for OrderCoupon items to be fetched</param>
		/// <param name="debitMetaPartnerID">A key for OrderCoupon items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Orders.OrderCoupon> GetAllOrderCouponDataByOrderIDAndDebitMetaPartnerID(Guid orderID, Guid debitMetaPartnerID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Orders.OrderCoupon> sortableList = new BLL.SortableList<BLL.Orders.OrderCoupon>(DAL.Orders.OrderCoupon.GetAllOrderCouponDataByOrderIDAndDebitMetaPartnerID(orderID, debitMetaPartnerID, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Orders.OrderCoupon loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Orders.GetAllOrderCouponDataByOrderIDAndDebitMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single OrderCoupon by an index.</summary>
		///
		/// <param name="orderID">The index for OrderCoupon to be fetched</param>
		/// <param name="metaPartnerCouponID">The index for OrderCoupon to be fetched</param>
		/// <param name="debitMetaPartnerID">The index for OrderCoupon to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Orders.OrderCoupon GetOneOrderCoupon(Guid orderID, Guid metaPartnerCouponID, Guid debitMetaPartnerID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Orders.OrderCouponManager.GetOneOrderCoupon(orderID, metaPartnerCouponID, debitMetaPartnerID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single OrderCoupon by an index.</summary>
		///
		/// <param name="orderID">The index for OrderCoupon to be fetched</param>
		/// <param name="metaPartnerCouponID">The index for OrderCoupon to be fetched</param>
		/// <param name="debitMetaPartnerID">The index for OrderCoupon to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Orders.OrderCoupon GetOneOrderCoupon(Guid orderID, Guid metaPartnerCouponID, Guid debitMetaPartnerID)
		{
			// perform main method tasks
			return BLL.Orders.OrderCouponManager.GetOneOrderCoupon(orderID, metaPartnerCouponID, debitMetaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single OrderCoupon by an index.</summary>
		///
		/// <param name="orderID">The index for OrderCoupon to be fetched</param>
		/// <param name="metaPartnerCouponID">The index for OrderCoupon to be fetched</param>
		/// <param name="debitMetaPartnerID">The index for OrderCoupon to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Orders.OrderCoupon GetOneOrderCoupon(Guid orderID, Guid metaPartnerCouponID, Guid debitMetaPartnerID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.Orders.OrderCoupon itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.Orders.OrderCoupon)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.Orders.OrderCoupon.GetCacheKey(typeof(BLL.Orders.OrderCoupon), "PrimaryKey", orderID.ToString() + ", " + metaPartnerCouponID.ToString() + ", " + debitMetaPartnerID.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.Orders.OrderCoupon)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.Orders.OrderCoupon item = DAL.Orders.OrderCoupon.GetOneOrderCoupon(orderID, metaPartnerCouponID, debitMetaPartnerID, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.Orders.OrderCoupon();
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
				throw Utility.CustomAppException.WrapException(ex, "BLL.Orders.GetOneOrderCoupon");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates OrderCoupon data.</summary>
		///
		/// <param name="item">The OrderCoupon to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneOrderCoupon(BLL.Orders.OrderCoupon item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Orders.OrderCouponManager.UpdateOneOrderCoupon(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates OrderCoupon data.</summary>
		///
		/// <param name="item">The OrderCoupon to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneOrderCoupon(BLL.Orders.OrderCoupon item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Orders.OrderCoupon itemDAL = new DAL.Orders.OrderCoupon();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Orders.OrderCoupon.UpdateOneOrderCoupon(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Orders.UpdateOneOrderCoupon");
			}
		}
		#endregion Methods
	}
}