
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
using MW.MComm.WalletSolution.BLL.Promotions;
using MOD.Data;
using MW.MComm.WalletSolution.BLL.Config;
using BLL = MW.MComm.WalletSolution.BLL;
using DAL = MW.MComm.WalletSolution.DAL;
using Utility = MW.MComm.WalletSolution.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
namespace MW.MComm.WalletSolution.BLL.Promotions
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage PromotionCoupon related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class PromotionCouponManager
	{
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public PromotionCouponManager()
		{
			//
			// constructor logic
			//
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------
		/// <summary>This method inserts PromotionCoupon data.</summary>
		///
		/// <param name="item">The PromotionCoupon to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOnePromotionCoupon(BLL.Promotions.PromotionCoupon item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Promotions.PromotionCouponManager.AddOnePromotionCoupon(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method inserts PromotionCoupon data.</summary>
		///
		/// <param name="item">The PromotionCoupon to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOnePromotionCoupon(BLL.Promotions.PromotionCoupon item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Promotions.PromotionCoupon itemDAL = new DAL.Promotions.PromotionCoupon();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Promotions.PromotionCoupon.AddOnePromotionCoupon(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Promotions.AddOnePromotionCoupon");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all PromotionCoupon data by a key.</summary>
		///
		/// <param name="couponCode">A key for PromotionCoupon items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllPromotionCouponDataByCouponCode(int couponCode)
		{
			// perform main method tasks
			BLL.Promotions.PromotionCouponManager.DeleteAllPromotionCouponDataByCouponCode(couponCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all PromotionCoupon data by a key.</summary>
		///
		/// <param name="couponCode">A key for PromotionCoupon items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllPromotionCouponDataByCouponCode(int couponCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Promotions.PromotionCoupon.DeleteAllPromotionCouponDataByCouponCode(couponCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Promotions.DeleteAllPromotionCouponDataByCouponCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all PromotionCoupon data by a key.</summary>
		///
		/// <param name="promotionCode">A key for PromotionCoupon items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllPromotionCouponDataByPromotionCode(int promotionCode)
		{
			// perform main method tasks
			BLL.Promotions.PromotionCouponManager.DeleteAllPromotionCouponDataByPromotionCode(promotionCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all PromotionCoupon data by a key.</summary>
		///
		/// <param name="promotionCode">A key for PromotionCoupon items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllPromotionCouponDataByPromotionCode(int promotionCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Promotions.PromotionCoupon.DeleteAllPromotionCouponDataByPromotionCode(promotionCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Promotions.DeleteAllPromotionCouponDataByPromotionCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes PromotionCoupon data.</summary>
		///
		/// <param name="item">The PromotionCoupon to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOnePromotionCoupon(BLL.Promotions.PromotionCoupon item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Promotions.PromotionCouponManager.DeleteOnePromotionCoupon(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes PromotionCoupon data.</summary>
		///
		/// <param name="item">The PromotionCoupon to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOnePromotionCoupon(BLL.Promotions.PromotionCoupon item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Promotions.PromotionCoupon itemDAL = new DAL.Promotions.PromotionCoupon();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Promotions.PromotionCoupon.DeleteOnePromotionCoupon(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = false;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Promotions.DeleteOnePromotionCoupon");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all PromotionCoupon data.</summary>
		///
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Promotions.PromotionCoupon> GetAllPromotionCouponData(MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Promotions.PromotionCouponManager.GetAllPromotionCouponData(BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all PromotionCoupon data.</summary>
		///
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Promotions.PromotionCoupon> GetAllPromotionCouponData()
		{
			// perform main method tasks
			return BLL.Promotions.PromotionCouponManager.GetAllPromotionCouponData(BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all PromotionCoupon data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Promotions.PromotionCoupon> GetAllPromotionCouponData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Promotions.PromotionCoupon> sortableList = new BLL.SortableList<BLL.Promotions.PromotionCoupon>(DAL.Promotions.PromotionCoupon.GetAllPromotionCouponData(dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Promotions.PromotionCoupon loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Promotions.GetAllPromotionCouponData");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all PromotionCoupon data by a key.</summary>
		///
		/// <param name="couponCode">A key for PromotionCoupon items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Promotions.PromotionCoupon> GetAllPromotionCouponDataByCouponCode(int couponCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Promotions.PromotionCouponManager.GetAllPromotionCouponDataByCouponCode(couponCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all PromotionCoupon data by a key.</summary>
		///
		/// <param name="couponCode">A key for PromotionCoupon items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Promotions.PromotionCoupon> GetAllPromotionCouponDataByCouponCode(int couponCode)
		{
			// perform main method tasks
			return BLL.Promotions.PromotionCouponManager.GetAllPromotionCouponDataByCouponCode(couponCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all PromotionCoupon data by a key.</summary>
		///
		/// <param name="couponCode">A key for PromotionCoupon items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Promotions.PromotionCoupon> GetAllPromotionCouponDataByCouponCode(int couponCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Promotions.PromotionCoupon> sortableList = new BLL.SortableList<BLL.Promotions.PromotionCoupon>(DAL.Promotions.PromotionCoupon.GetAllPromotionCouponDataByCouponCode(couponCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Promotions.PromotionCoupon loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Promotions.GetAllPromotionCouponDataByCouponCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all PromotionCoupon data by a key.</summary>
		///
		/// <param name="promotionCode">A key for PromotionCoupon items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Promotions.PromotionCoupon> GetAllPromotionCouponDataByPromotionCode(int promotionCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Promotions.PromotionCouponManager.GetAllPromotionCouponDataByPromotionCode(promotionCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all PromotionCoupon data by a key.</summary>
		///
		/// <param name="promotionCode">A key for PromotionCoupon items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Promotions.PromotionCoupon> GetAllPromotionCouponDataByPromotionCode(int promotionCode)
		{
			// perform main method tasks
			return BLL.Promotions.PromotionCouponManager.GetAllPromotionCouponDataByPromotionCode(promotionCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all PromotionCoupon data by a key.</summary>
		///
		/// <param name="promotionCode">A key for PromotionCoupon items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Promotions.PromotionCoupon> GetAllPromotionCouponDataByPromotionCode(int promotionCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Promotions.PromotionCoupon> sortableList = new BLL.SortableList<BLL.Promotions.PromotionCoupon>(DAL.Promotions.PromotionCoupon.GetAllPromotionCouponDataByPromotionCode(promotionCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Promotions.PromotionCoupon loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Promotions.GetAllPromotionCouponDataByPromotionCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single PromotionCoupon by an index.</summary>
		///
		/// <param name="promotionCode">The index for PromotionCoupon to be fetched</param>
		/// <param name="couponCode">The index for PromotionCoupon to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Promotions.PromotionCoupon GetOnePromotionCoupon(int promotionCode, int couponCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Promotions.PromotionCouponManager.GetOnePromotionCoupon(promotionCode, couponCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single PromotionCoupon by an index.</summary>
		///
		/// <param name="promotionCode">The index for PromotionCoupon to be fetched</param>
		/// <param name="couponCode">The index for PromotionCoupon to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Promotions.PromotionCoupon GetOnePromotionCoupon(int promotionCode, int couponCode)
		{
			// perform main method tasks
			return BLL.Promotions.PromotionCouponManager.GetOnePromotionCoupon(promotionCode, couponCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single PromotionCoupon by an index.</summary>
		///
		/// <param name="promotionCode">The index for PromotionCoupon to be fetched</param>
		/// <param name="couponCode">The index for PromotionCoupon to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Promotions.PromotionCoupon GetOnePromotionCoupon(int promotionCode, int couponCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.Promotions.PromotionCoupon itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.Promotions.PromotionCoupon)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.Promotions.PromotionCoupon.GetCacheKey(typeof(BLL.Promotions.PromotionCoupon), "PrimaryKey", promotionCode.ToString() + ", " + couponCode.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.Promotions.PromotionCoupon)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.Promotions.PromotionCoupon item = DAL.Promotions.PromotionCoupon.GetOnePromotionCoupon(promotionCode, couponCode, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.Promotions.PromotionCoupon();
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
				throw Utility.CustomAppException.WrapException(ex, "BLL.Promotions.GetOnePromotionCoupon");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates PromotionCoupon data.</summary>
		///
		/// <param name="item">The PromotionCoupon to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOnePromotionCoupon(BLL.Promotions.PromotionCoupon item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Promotions.PromotionCouponManager.UpdateOnePromotionCoupon(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates PromotionCoupon data.</summary>
		///
		/// <param name="item">The PromotionCoupon to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOnePromotionCoupon(BLL.Promotions.PromotionCoupon item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Promotions.PromotionCoupon itemDAL = new DAL.Promotions.PromotionCoupon();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Promotions.PromotionCoupon.UpdateOnePromotionCoupon(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Promotions.UpdateOnePromotionCoupon");
			}
		}
		#endregion Methods
	}
}