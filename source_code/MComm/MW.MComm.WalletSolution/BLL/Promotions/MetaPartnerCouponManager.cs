
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
	/// <summary>This class is used to manage MetaPartnerCoupon related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class MetaPartnerCouponManager
	{
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public MetaPartnerCouponManager()
		{
			//
			// constructor logic
			//
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------
		/// <summary>This method deletes all MetaPartnerCoupon data by a key.</summary>
		///
		/// <param name="couponCode">A key for MetaPartnerCoupon items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllMetaPartnerCouponDataByCouponCode(int couponCode)
		{
			// perform main method tasks
			BLL.Promotions.MetaPartnerCouponManager.DeleteAllMetaPartnerCouponDataByCouponCode(couponCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all MetaPartnerCoupon data by a key.</summary>
		///
		/// <param name="couponCode">A key for MetaPartnerCoupon items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllMetaPartnerCouponDataByCouponCode(int couponCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Promotions.MetaPartnerCoupon.DeleteAllMetaPartnerCouponDataByCouponCode(couponCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Promotions.DeleteAllMetaPartnerCouponDataByCouponCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all MetaPartnerCoupon data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for MetaPartnerCoupon items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllMetaPartnerCouponDataByMetaPartnerID(Guid metaPartnerID)
		{
			// perform main method tasks
			BLL.Promotions.MetaPartnerCouponManager.DeleteAllMetaPartnerCouponDataByMetaPartnerID(metaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all MetaPartnerCoupon data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for MetaPartnerCoupon items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllMetaPartnerCouponDataByMetaPartnerID(Guid metaPartnerID, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Promotions.MetaPartnerCoupon.DeleteAllMetaPartnerCouponDataByMetaPartnerID(metaPartnerID, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Promotions.DeleteAllMetaPartnerCouponDataByMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes MetaPartnerCoupon data.</summary>
		///
		/// <param name="item">The MetaPartnerCoupon to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneMetaPartnerCoupon(BLL.Promotions.MetaPartnerCoupon item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Promotions.MetaPartnerCouponManager.DeleteOneMetaPartnerCoupon(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes MetaPartnerCoupon data.</summary>
		///
		/// <param name="item">The MetaPartnerCoupon to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneMetaPartnerCoupon(BLL.Promotions.MetaPartnerCoupon item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Promotions.MetaPartnerCoupon itemDAL = new DAL.Promotions.MetaPartnerCoupon();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Promotions.MetaPartnerCoupon.DeleteOneMetaPartnerCoupon(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = false;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Promotions.DeleteOneMetaPartnerCoupon");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartnerCoupon data.</summary>
		///
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Promotions.MetaPartnerCoupon> GetAllMetaPartnerCouponData(MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Promotions.MetaPartnerCouponManager.GetAllMetaPartnerCouponData(BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartnerCoupon data.</summary>
		///
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Promotions.MetaPartnerCoupon> GetAllMetaPartnerCouponData()
		{
			// perform main method tasks
			return BLL.Promotions.MetaPartnerCouponManager.GetAllMetaPartnerCouponData(BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartnerCoupon data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Promotions.MetaPartnerCoupon> GetAllMetaPartnerCouponData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Promotions.MetaPartnerCoupon> sortableList = new BLL.SortableList<BLL.Promotions.MetaPartnerCoupon>(DAL.Promotions.MetaPartnerCoupon.GetAllMetaPartnerCouponData(dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Promotions.MetaPartnerCoupon loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Promotions.GetAllMetaPartnerCouponData");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartnerCoupon data by a key.</summary>
		///
		/// <param name="couponCode">A key for MetaPartnerCoupon items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Promotions.MetaPartnerCoupon> GetAllMetaPartnerCouponDataByCouponCode(int couponCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Promotions.MetaPartnerCouponManager.GetAllMetaPartnerCouponDataByCouponCode(couponCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartnerCoupon data by a key.</summary>
		///
		/// <param name="couponCode">A key for MetaPartnerCoupon items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Promotions.MetaPartnerCoupon> GetAllMetaPartnerCouponDataByCouponCode(int couponCode)
		{
			// perform main method tasks
			return BLL.Promotions.MetaPartnerCouponManager.GetAllMetaPartnerCouponDataByCouponCode(couponCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartnerCoupon data by a key.</summary>
		///
		/// <param name="couponCode">A key for MetaPartnerCoupon items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Promotions.MetaPartnerCoupon> GetAllMetaPartnerCouponDataByCouponCode(int couponCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Promotions.MetaPartnerCoupon> sortableList = new BLL.SortableList<BLL.Promotions.MetaPartnerCoupon>(DAL.Promotions.MetaPartnerCoupon.GetAllMetaPartnerCouponDataByCouponCode(couponCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Promotions.MetaPartnerCoupon loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Promotions.GetAllMetaPartnerCouponDataByCouponCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartnerCoupon data by criteria.</summary>
		///
		/// <param name="couponCode">A key for MetaPartnerCoupon items to be fetched</param>
		/// <param name="startDate">A key for MetaPartnerCoupon items to be fetched</param>
		/// <param name="endDate">A key for MetaPartnerCoupon items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for MetaPartnerCoupon items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for MetaPartnerCoupon items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Promotions.MetaPartnerCoupon> GetAllMetaPartnerCouponDataByCriteria(int? couponCode, DateTime? startDate, DateTime? endDate, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Promotions.MetaPartnerCouponManager.GetAllMetaPartnerCouponDataByCriteria(couponCode, startDate, endDate, lastModifiedDateStart, lastModifiedDateEnd, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartnerCoupon data by criteria.</summary>
		///
		/// <param name="couponCode">A key for MetaPartnerCoupon items to be fetched</param>
		/// <param name="startDate">A key for MetaPartnerCoupon items to be fetched</param>
		/// <param name="endDate">A key for MetaPartnerCoupon items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for MetaPartnerCoupon items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for MetaPartnerCoupon items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Promotions.MetaPartnerCoupon> GetAllMetaPartnerCouponDataByCriteria(int? couponCode, DateTime? startDate, DateTime? endDate, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd)
		{
			// perform main method tasks
			return BLL.Promotions.MetaPartnerCouponManager.GetAllMetaPartnerCouponDataByCriteria(couponCode, startDate, endDate, lastModifiedDateStart, lastModifiedDateEnd, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartnerCoupon data by criteria.</summary>
		///
		/// <param name="couponCode">A key for MetaPartnerCoupon items to be fetched</param>
		/// <param name="startDate">A key for MetaPartnerCoupon items to be fetched</param>
		/// <param name="endDate">A key for MetaPartnerCoupon items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for MetaPartnerCoupon items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for MetaPartnerCoupon items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Promotions.MetaPartnerCoupon> GetAllMetaPartnerCouponDataByCriteria(int? couponCode, DateTime? startDate, DateTime? endDate, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Promotions.MetaPartnerCoupon> sortableList = new BLL.SortableList<BLL.Promotions.MetaPartnerCoupon>(DAL.Promotions.MetaPartnerCoupon.GetAllMetaPartnerCouponDataByCriteria(couponCode, startDate, endDate, lastModifiedDateStart, lastModifiedDateEnd, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Promotions.MetaPartnerCoupon loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Promotions.GetAllMetaPartnerCouponDataByCriteria");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartnerCoupon data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for MetaPartnerCoupon items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Promotions.MetaPartnerCoupon> GetAllMetaPartnerCouponDataByMetaPartnerID(Guid metaPartnerID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Promotions.MetaPartnerCouponManager.GetAllMetaPartnerCouponDataByMetaPartnerID(metaPartnerID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartnerCoupon data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for MetaPartnerCoupon items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Promotions.MetaPartnerCoupon> GetAllMetaPartnerCouponDataByMetaPartnerID(Guid metaPartnerID)
		{
			// perform main method tasks
			return BLL.Promotions.MetaPartnerCouponManager.GetAllMetaPartnerCouponDataByMetaPartnerID(metaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartnerCoupon data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for MetaPartnerCoupon items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Promotions.MetaPartnerCoupon> GetAllMetaPartnerCouponDataByMetaPartnerID(Guid metaPartnerID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Promotions.MetaPartnerCoupon> sortableList = new BLL.SortableList<BLL.Promotions.MetaPartnerCoupon>(DAL.Promotions.MetaPartnerCoupon.GetAllMetaPartnerCouponDataByMetaPartnerID(metaPartnerID, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Promotions.MetaPartnerCoupon loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Promotions.GetAllMetaPartnerCouponDataByMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartnerCoupon data by criteria.</summary>
		///
		/// <param name="couponCode">A key for MetaPartnerCoupon items to be fetched</param>
		/// <param name="startDate">A key for MetaPartnerCoupon items to be fetched</param>
		/// <param name="endDate">A key for MetaPartnerCoupon items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for MetaPartnerCoupon items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for MetaPartnerCoupon items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Promotions.MetaPartnerCoupon> GetManyMetaPartnerCouponDataByCriteria(int? couponCode, DateTime? startDate, DateTime? endDate, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Promotions.MetaPartnerCouponManager.GetManyMetaPartnerCouponDataByCriteria(couponCode, startDate, endDate, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartnerCoupon data by criteria.</summary>
		///
		/// <param name="couponCode">A key for MetaPartnerCoupon items to be fetched</param>
		/// <param name="startDate">A key for MetaPartnerCoupon items to be fetched</param>
		/// <param name="endDate">A key for MetaPartnerCoupon items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for MetaPartnerCoupon items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for MetaPartnerCoupon items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Promotions.MetaPartnerCoupon> GetManyMetaPartnerCouponDataByCriteria(int? couponCode, DateTime? startDate, DateTime? endDate, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Promotions.MetaPartnerCoupon> sortableList = new BLL.SortableList<BLL.Promotions.MetaPartnerCoupon>(DAL.Promotions.MetaPartnerCoupon.GetManyMetaPartnerCouponDataByCriteria(couponCode, startDate, endDate, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Promotions.MetaPartnerCoupon loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Promotions.GetManyMetaPartnerCouponDataByCriteria");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single MetaPartnerCoupon by an index.</summary>
		///
		/// <param name="metaPartnerCouponID">The index for MetaPartnerCoupon to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Promotions.MetaPartnerCoupon GetOneMetaPartnerCoupon(Guid metaPartnerCouponID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Promotions.MetaPartnerCouponManager.GetOneMetaPartnerCoupon(metaPartnerCouponID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single MetaPartnerCoupon by an index.</summary>
		///
		/// <param name="metaPartnerCouponID">The index for MetaPartnerCoupon to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Promotions.MetaPartnerCoupon GetOneMetaPartnerCoupon(Guid metaPartnerCouponID)
		{
			// perform main method tasks
			return BLL.Promotions.MetaPartnerCouponManager.GetOneMetaPartnerCoupon(metaPartnerCouponID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single MetaPartnerCoupon by an index.</summary>
		///
		/// <param name="metaPartnerCouponID">The index for MetaPartnerCoupon to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Promotions.MetaPartnerCoupon GetOneMetaPartnerCoupon(Guid metaPartnerCouponID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.Promotions.MetaPartnerCoupon itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.Promotions.MetaPartnerCoupon)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.Promotions.MetaPartnerCoupon.GetCacheKey(typeof(BLL.Promotions.MetaPartnerCoupon), "PrimaryKey", metaPartnerCouponID.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.Promotions.MetaPartnerCoupon)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.Promotions.MetaPartnerCoupon item = DAL.Promotions.MetaPartnerCoupon.GetOneMetaPartnerCoupon(metaPartnerCouponID, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.Promotions.MetaPartnerCoupon();
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
				throw Utility.CustomAppException.WrapException(ex, "BLL.Promotions.GetOneMetaPartnerCoupon");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single MetaPartnerCoupon by an index.</summary>
		///
		/// <param name="metaPartnerCouponID">The index for MetaPartnerCoupon to be fetched</param>
		/// <param name="metaPartnerID">The index for MetaPartnerCoupon to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Promotions.MetaPartnerCoupon GetOneMetaPartnerCouponByMetaPartnerCouponIDAndMetaPartnerID(Guid metaPartnerCouponID, Guid metaPartnerID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Promotions.MetaPartnerCouponManager.GetOneMetaPartnerCouponByMetaPartnerCouponIDAndMetaPartnerID(metaPartnerCouponID, metaPartnerID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single MetaPartnerCoupon by an index.</summary>
		///
		/// <param name="metaPartnerCouponID">The index for MetaPartnerCoupon to be fetched</param>
		/// <param name="metaPartnerID">The index for MetaPartnerCoupon to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Promotions.MetaPartnerCoupon GetOneMetaPartnerCouponByMetaPartnerCouponIDAndMetaPartnerID(Guid metaPartnerCouponID, Guid metaPartnerID)
		{
			// perform main method tasks
			return BLL.Promotions.MetaPartnerCouponManager.GetOneMetaPartnerCouponByMetaPartnerCouponIDAndMetaPartnerID(metaPartnerCouponID, metaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single MetaPartnerCoupon by an index.</summary>
		///
		/// <param name="metaPartnerCouponID">The index for MetaPartnerCoupon to be fetched</param>
		/// <param name="metaPartnerID">The index for MetaPartnerCoupon to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Promotions.MetaPartnerCoupon GetOneMetaPartnerCouponByMetaPartnerCouponIDAndMetaPartnerID(Guid metaPartnerCouponID, Guid metaPartnerID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.Promotions.MetaPartnerCoupon itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.Promotions.MetaPartnerCoupon)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.Promotions.MetaPartnerCoupon.GetCacheKey(typeof(BLL.Promotions.MetaPartnerCoupon), "PrimaryKey", metaPartnerCouponID.ToString() + ", " + metaPartnerID.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.Promotions.MetaPartnerCoupon)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.Promotions.MetaPartnerCoupon item = DAL.Promotions.MetaPartnerCoupon.GetOneMetaPartnerCouponByMetaPartnerCouponIDAndMetaPartnerID(metaPartnerCouponID, metaPartnerID, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.Promotions.MetaPartnerCoupon();
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
				throw Utility.CustomAppException.WrapException(ex, "BLL.Promotions.GetOneMetaPartnerCouponByMetaPartnerCouponIDAndMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method inserts or updates MetaPartnerCoupon data.</summary>
		///
		/// <param name="item">The MetaPartnerCoupon to be inserted or updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpsertOneMetaPartnerCoupon(BLL.Promotions.MetaPartnerCoupon item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Promotions.MetaPartnerCouponManager.UpsertOneMetaPartnerCoupon(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method inserts or updates MetaPartnerCoupon data.</summary>
		///
		/// <param name="item">The MetaPartnerCoupon to be inserted or updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpsertOneMetaPartnerCoupon(BLL.Promotions.MetaPartnerCoupon item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Promotions.MetaPartnerCoupon itemDAL = new DAL.Promotions.MetaPartnerCoupon();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Promotions.MetaPartnerCoupon.UpsertOneMetaPartnerCoupon(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Promotions.UpsertOneMetaPartnerCoupon");
			}
		}
		#endregion Methods
	}
}