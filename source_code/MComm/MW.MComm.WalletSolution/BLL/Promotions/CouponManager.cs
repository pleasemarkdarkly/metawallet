
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
	/// <summary>This class is used to manage Coupon related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class CouponManager
	{
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public CouponManager()
		{
			//
			// constructor logic
			//
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------
		/// <summary>This method inserts Coupon data.</summary>
		///
		/// <param name="item">The Coupon to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneCoupon(BLL.Promotions.Coupon item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Promotions.CouponManager.AddOneCoupon(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method inserts Coupon data.</summary>
		///
		/// <param name="item">The Coupon to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneCoupon(BLL.Promotions.Coupon item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				// perform enum check
				if (Enum.IsDefined(typeof(CouponCode), item.CouponCode) == true)
				{
					throw new Utility.CustomAppException(BLL.Core.ErrorNumber.EnumerationAddException, BLL.Core.ErrorManager.GetErrorMessageFromErrorNumber(BLL.Core.ErrorNumber.EnumerationAddException), null);
				}
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Promotions.Coupon itemDAL = new DAL.Promotions.Coupon();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Promotions.Coupon.AddOneCoupon(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Promotions.AddOneCoupon");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Coupon data by a key.</summary>
		///
		/// <param name="couponTypeCode">A key for Coupon items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllCouponDataByCouponTypeCode(int couponTypeCode)
		{
			// perform main method tasks
			BLL.Promotions.CouponManager.DeleteAllCouponDataByCouponTypeCode(couponTypeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Coupon data by a key.</summary>
		///
		/// <param name="couponTypeCode">A key for Coupon items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllCouponDataByCouponTypeCode(int couponTypeCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Promotions.Coupon.DeleteAllCouponDataByCouponTypeCode(couponTypeCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Promotions.DeleteAllCouponDataByCouponTypeCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Coupon data by a key.</summary>
		///
		/// <param name="currencyCode">A key for Coupon items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllCouponDataByCurrencyCode(int currencyCode)
		{
			// perform main method tasks
			BLL.Promotions.CouponManager.DeleteAllCouponDataByCurrencyCode(currencyCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Coupon data by a key.</summary>
		///
		/// <param name="currencyCode">A key for Coupon items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllCouponDataByCurrencyCode(int currencyCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Promotions.Coupon.DeleteAllCouponDataByCurrencyCode(currencyCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Promotions.DeleteAllCouponDataByCurrencyCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Coupon data by a key.</summary>
		///
		/// <param name="discountTypeCode">A key for Coupon items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllCouponDataByDiscountTypeCode(int discountTypeCode)
		{
			// perform main method tasks
			BLL.Promotions.CouponManager.DeleteAllCouponDataByDiscountTypeCode(discountTypeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Coupon data by a key.</summary>
		///
		/// <param name="discountTypeCode">A key for Coupon items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllCouponDataByDiscountTypeCode(int discountTypeCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Promotions.Coupon.DeleteAllCouponDataByDiscountTypeCode(discountTypeCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Promotions.DeleteAllCouponDataByDiscountTypeCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes Coupon data.</summary>
		///
		/// <param name="item">The Coupon to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneCoupon(BLL.Promotions.Coupon item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Promotions.CouponManager.DeleteOneCoupon(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes Coupon data.</summary>
		///
		/// <param name="item">The Coupon to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneCoupon(BLL.Promotions.Coupon item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				// perform enum check
				if (Enum.IsDefined(typeof(CouponCode), item.CouponCode) == true)
				{
					throw new Utility.CustomAppException(BLL.Core.ErrorNumber.EnumerationDeleteException, BLL.Core.ErrorManager.GetErrorMessageFromErrorNumber(BLL.Core.ErrorNumber.EnumerationDeleteException), null);
				}
				DAL.Promotions.Coupon itemDAL = new DAL.Promotions.Coupon();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Promotions.Coupon.DeleteOneCoupon(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = false;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Promotions.DeleteOneCoupon");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Coupon data.</summary>
		///
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Promotions.Coupon> GetAllCouponData(MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Promotions.CouponManager.GetAllCouponData(BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Coupon data.</summary>
		///
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Promotions.Coupon> GetAllCouponData()
		{
			// perform main method tasks
			return BLL.Promotions.CouponManager.GetAllCouponData(BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Coupon data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Promotions.Coupon> GetAllCouponData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Promotions.Coupon> sortableList = new BLL.SortableList<BLL.Promotions.Coupon>(DAL.Promotions.Coupon.GetAllCouponData(dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Promotions.Coupon loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Promotions.GetAllCouponData");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Coupon data by a key.</summary>
		///
		/// <param name="couponTypeCode">A key for Coupon items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Promotions.Coupon> GetAllCouponDataByCouponTypeCode(int couponTypeCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Promotions.CouponManager.GetAllCouponDataByCouponTypeCode(couponTypeCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Coupon data by a key.</summary>
		///
		/// <param name="couponTypeCode">A key for Coupon items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Promotions.Coupon> GetAllCouponDataByCouponTypeCode(int couponTypeCode)
		{
			// perform main method tasks
			return BLL.Promotions.CouponManager.GetAllCouponDataByCouponTypeCode(couponTypeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Coupon data by a key.</summary>
		///
		/// <param name="couponTypeCode">A key for Coupon items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Promotions.Coupon> GetAllCouponDataByCouponTypeCode(int couponTypeCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Promotions.Coupon> sortableList = new BLL.SortableList<BLL.Promotions.Coupon>(DAL.Promotions.Coupon.GetAllCouponDataByCouponTypeCode(couponTypeCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Promotions.Coupon loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Promotions.GetAllCouponDataByCouponTypeCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Coupon data by criteria.</summary>
		///
		/// <param name="couponName">A key for Coupon items to be fetched</param>
		/// <param name="couponTypeCode">A key for Coupon items to be fetched</param>
		/// <param name="discountTypeCode">A key for Coupon items to be fetched</param>
		/// <param name="currencyCode">A key for Coupon items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Coupon items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Coupon items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Promotions.Coupon> GetAllCouponDataByCriteria(string couponName, int? couponTypeCode, int? discountTypeCode, int? currencyCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Promotions.CouponManager.GetAllCouponDataByCriteria(couponName, couponTypeCode, discountTypeCode, currencyCode, lastModifiedDateStart, lastModifiedDateEnd, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Coupon data by criteria.</summary>
		///
		/// <param name="couponName">A key for Coupon items to be fetched</param>
		/// <param name="couponTypeCode">A key for Coupon items to be fetched</param>
		/// <param name="discountTypeCode">A key for Coupon items to be fetched</param>
		/// <param name="currencyCode">A key for Coupon items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Coupon items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Coupon items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Promotions.Coupon> GetAllCouponDataByCriteria(string couponName, int? couponTypeCode, int? discountTypeCode, int? currencyCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd)
		{
			// perform main method tasks
			return BLL.Promotions.CouponManager.GetAllCouponDataByCriteria(couponName, couponTypeCode, discountTypeCode, currencyCode, lastModifiedDateStart, lastModifiedDateEnd, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Coupon data by criteria.</summary>
		///
		/// <param name="couponName">A key for Coupon items to be fetched</param>
		/// <param name="couponTypeCode">A key for Coupon items to be fetched</param>
		/// <param name="discountTypeCode">A key for Coupon items to be fetched</param>
		/// <param name="currencyCode">A key for Coupon items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Coupon items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Coupon items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Promotions.Coupon> GetAllCouponDataByCriteria(string couponName, int? couponTypeCode, int? discountTypeCode, int? currencyCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Promotions.Coupon> sortableList = new BLL.SortableList<BLL.Promotions.Coupon>(DAL.Promotions.Coupon.GetAllCouponDataByCriteria(couponName, couponTypeCode, discountTypeCode, currencyCode, lastModifiedDateStart, lastModifiedDateEnd, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Promotions.Coupon loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Promotions.GetAllCouponDataByCriteria");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Coupon data by a key.</summary>
		///
		/// <param name="currencyCode">A key for Coupon items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Promotions.Coupon> GetAllCouponDataByCurrencyCode(int currencyCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Promotions.CouponManager.GetAllCouponDataByCurrencyCode(currencyCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Coupon data by a key.</summary>
		///
		/// <param name="currencyCode">A key for Coupon items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Promotions.Coupon> GetAllCouponDataByCurrencyCode(int currencyCode)
		{
			// perform main method tasks
			return BLL.Promotions.CouponManager.GetAllCouponDataByCurrencyCode(currencyCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Coupon data by a key.</summary>
		///
		/// <param name="currencyCode">A key for Coupon items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Promotions.Coupon> GetAllCouponDataByCurrencyCode(int currencyCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Promotions.Coupon> sortableList = new BLL.SortableList<BLL.Promotions.Coupon>(DAL.Promotions.Coupon.GetAllCouponDataByCurrencyCode(currencyCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Promotions.Coupon loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Promotions.GetAllCouponDataByCurrencyCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Coupon data by a key.</summary>
		///
		/// <param name="discountTypeCode">A key for Coupon items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Promotions.Coupon> GetAllCouponDataByDiscountTypeCode(int discountTypeCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Promotions.CouponManager.GetAllCouponDataByDiscountTypeCode(discountTypeCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Coupon data by a key.</summary>
		///
		/// <param name="discountTypeCode">A key for Coupon items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Promotions.Coupon> GetAllCouponDataByDiscountTypeCode(int discountTypeCode)
		{
			// perform main method tasks
			return BLL.Promotions.CouponManager.GetAllCouponDataByDiscountTypeCode(discountTypeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Coupon data by a key.</summary>
		///
		/// <param name="discountTypeCode">A key for Coupon items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Promotions.Coupon> GetAllCouponDataByDiscountTypeCode(int discountTypeCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Promotions.Coupon> sortableList = new BLL.SortableList<BLL.Promotions.Coupon>(DAL.Promotions.Coupon.GetAllCouponDataByDiscountTypeCode(discountTypeCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Promotions.Coupon loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Promotions.GetAllCouponDataByDiscountTypeCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Coupon data by criteria.</summary>
		///
		/// <param name="couponName">A key for Coupon items to be fetched</param>
		/// <param name="couponTypeCode">A key for Coupon items to be fetched</param>
		/// <param name="discountTypeCode">A key for Coupon items to be fetched</param>
		/// <param name="currencyCode">A key for Coupon items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Coupon items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Coupon items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Promotions.Coupon> GetManyCouponDataByCriteria(string couponName, int? couponTypeCode, int? discountTypeCode, int? currencyCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Promotions.CouponManager.GetManyCouponDataByCriteria(couponName, couponTypeCode, discountTypeCode, currencyCode, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Coupon data by criteria.</summary>
		///
		/// <param name="couponName">A key for Coupon items to be fetched</param>
		/// <param name="couponTypeCode">A key for Coupon items to be fetched</param>
		/// <param name="discountTypeCode">A key for Coupon items to be fetched</param>
		/// <param name="currencyCode">A key for Coupon items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Coupon items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Coupon items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Promotions.Coupon> GetManyCouponDataByCriteria(string couponName, int? couponTypeCode, int? discountTypeCode, int? currencyCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Promotions.Coupon> sortableList = new BLL.SortableList<BLL.Promotions.Coupon>(DAL.Promotions.Coupon.GetManyCouponDataByCriteria(couponName, couponTypeCode, discountTypeCode, currencyCode, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Promotions.Coupon loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Promotions.GetManyCouponDataByCriteria");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single Coupon by an index.</summary>
		///
		/// <param name="couponCode">The index for Coupon to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Promotions.Coupon GetOneCoupon(int couponCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Promotions.CouponManager.GetOneCoupon(couponCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single Coupon by an index.</summary>
		///
		/// <param name="couponCode">The index for Coupon to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Promotions.Coupon GetOneCoupon(int couponCode)
		{
			// perform main method tasks
			return BLL.Promotions.CouponManager.GetOneCoupon(couponCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single Coupon by an index.</summary>
		///
		/// <param name="couponCode">The index for Coupon to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Promotions.Coupon GetOneCoupon(int couponCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.Promotions.Coupon itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.Promotions.Coupon)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.Promotions.Coupon.GetCacheKey(typeof(BLL.Promotions.Coupon), "PrimaryKey", couponCode.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.Promotions.Coupon)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.Promotions.Coupon item = DAL.Promotions.Coupon.GetOneCoupon(couponCode, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.Promotions.Coupon();
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
				throw Utility.CustomAppException.WrapException(ex, "BLL.Promotions.GetOneCoupon");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates Coupon data.</summary>
		///
		/// <param name="item">The Coupon to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneCoupon(BLL.Promotions.Coupon item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Promotions.CouponManager.UpdateOneCoupon(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates Coupon data.</summary>
		///
		/// <param name="item">The Coupon to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneCoupon(BLL.Promotions.Coupon item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Promotions.Coupon itemDAL = new DAL.Promotions.Coupon();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Promotions.Coupon.UpdateOneCoupon(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Promotions.UpdateOneCoupon");
			}
		}
		#endregion Methods
	}
}