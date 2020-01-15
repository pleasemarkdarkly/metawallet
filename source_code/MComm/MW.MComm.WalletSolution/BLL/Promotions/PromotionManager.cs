
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
	/// <summary>This class is used to manage Promotion related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class PromotionManager
	{
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public PromotionManager()
		{
			//
			// constructor logic
			//
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------
		/// <summary>This method inserts Promotion data.</summary>
		///
		/// <param name="item">The Promotion to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOnePromotion(BLL.Promotions.Promotion item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Promotions.PromotionManager.AddOnePromotion(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method inserts Promotion data.</summary>
		///
		/// <param name="item">The Promotion to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOnePromotion(BLL.Promotions.Promotion item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				// perform enum check
				if (Enum.IsDefined(typeof(PromotionCode), item.PromotionCode) == true)
				{
					throw new Utility.CustomAppException(BLL.Core.ErrorNumber.EnumerationAddException, BLL.Core.ErrorManager.GetErrorMessageFromErrorNumber(BLL.Core.ErrorNumber.EnumerationAddException), null);
				}
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Promotions.Promotion itemDAL = new DAL.Promotions.Promotion();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Promotions.Promotion.AddOnePromotion(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Promotions.AddOnePromotion");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Promotion data by a key.</summary>
		///
		/// <param name="promotionTypeCode">A key for Promotion items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllPromotionDataByPromotionTypeCode(int promotionTypeCode)
		{
			// perform main method tasks
			BLL.Promotions.PromotionManager.DeleteAllPromotionDataByPromotionTypeCode(promotionTypeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Promotion data by a key.</summary>
		///
		/// <param name="promotionTypeCode">A key for Promotion items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllPromotionDataByPromotionTypeCode(int promotionTypeCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Promotions.Promotion.DeleteAllPromotionDataByPromotionTypeCode(promotionTypeCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Promotions.DeleteAllPromotionDataByPromotionTypeCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes Promotion data.</summary>
		///
		/// <param name="item">The Promotion to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOnePromotion(BLL.Promotions.Promotion item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Promotions.PromotionManager.DeleteOnePromotion(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes Promotion data.</summary>
		///
		/// <param name="item">The Promotion to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOnePromotion(BLL.Promotions.Promotion item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				// perform enum check
				if (Enum.IsDefined(typeof(PromotionCode), item.PromotionCode) == true)
				{
					throw new Utility.CustomAppException(BLL.Core.ErrorNumber.EnumerationDeleteException, BLL.Core.ErrorManager.GetErrorMessageFromErrorNumber(BLL.Core.ErrorNumber.EnumerationDeleteException), null);
				}
				DAL.Promotions.Promotion itemDAL = new DAL.Promotions.Promotion();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Promotions.Promotion.DeleteOnePromotion(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = false;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Promotions.DeleteOnePromotion");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Promotion data.</summary>
		///
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Promotions.Promotion> GetAllPromotionData(MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Promotions.PromotionManager.GetAllPromotionData(BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Promotion data.</summary>
		///
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Promotions.Promotion> GetAllPromotionData()
		{
			// perform main method tasks
			return BLL.Promotions.PromotionManager.GetAllPromotionData(BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Promotion data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Promotions.Promotion> GetAllPromotionData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Promotions.Promotion> sortableList = new BLL.SortableList<BLL.Promotions.Promotion>(DAL.Promotions.Promotion.GetAllPromotionData(dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Promotions.Promotion loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Promotions.GetAllPromotionData");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Promotion data by criteria.</summary>
		///
		/// <param name="promotionName">A key for Promotion items to be fetched</param>
		/// <param name="promotionTypeCode">A key for Promotion items to be fetched</param>
		/// <param name="startDate">A key for Promotion items to be fetched</param>
		/// <param name="endDate">A key for Promotion items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Promotion items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Promotion items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Promotions.Promotion> GetAllPromotionDataByCriteria(string promotionName, int? promotionTypeCode, DateTime? startDate, DateTime? endDate, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Promotions.PromotionManager.GetAllPromotionDataByCriteria(promotionName, promotionTypeCode, startDate, endDate, lastModifiedDateStart, lastModifiedDateEnd, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Promotion data by criteria.</summary>
		///
		/// <param name="promotionName">A key for Promotion items to be fetched</param>
		/// <param name="promotionTypeCode">A key for Promotion items to be fetched</param>
		/// <param name="startDate">A key for Promotion items to be fetched</param>
		/// <param name="endDate">A key for Promotion items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Promotion items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Promotion items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Promotions.Promotion> GetAllPromotionDataByCriteria(string promotionName, int? promotionTypeCode, DateTime? startDate, DateTime? endDate, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd)
		{
			// perform main method tasks
			return BLL.Promotions.PromotionManager.GetAllPromotionDataByCriteria(promotionName, promotionTypeCode, startDate, endDate, lastModifiedDateStart, lastModifiedDateEnd, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Promotion data by criteria.</summary>
		///
		/// <param name="promotionName">A key for Promotion items to be fetched</param>
		/// <param name="promotionTypeCode">A key for Promotion items to be fetched</param>
		/// <param name="startDate">A key for Promotion items to be fetched</param>
		/// <param name="endDate">A key for Promotion items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Promotion items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Promotion items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Promotions.Promotion> GetAllPromotionDataByCriteria(string promotionName, int? promotionTypeCode, DateTime? startDate, DateTime? endDate, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Promotions.Promotion> sortableList = new BLL.SortableList<BLL.Promotions.Promotion>(DAL.Promotions.Promotion.GetAllPromotionDataByCriteria(promotionName, promotionTypeCode, startDate, endDate, lastModifiedDateStart, lastModifiedDateEnd, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Promotions.Promotion loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Promotions.GetAllPromotionDataByCriteria");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Promotion data by a key.</summary>
		///
		/// <param name="promotionTypeCode">A key for Promotion items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Promotions.Promotion> GetAllPromotionDataByPromotionTypeCode(int promotionTypeCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Promotions.PromotionManager.GetAllPromotionDataByPromotionTypeCode(promotionTypeCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Promotion data by a key.</summary>
		///
		/// <param name="promotionTypeCode">A key for Promotion items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Promotions.Promotion> GetAllPromotionDataByPromotionTypeCode(int promotionTypeCode)
		{
			// perform main method tasks
			return BLL.Promotions.PromotionManager.GetAllPromotionDataByPromotionTypeCode(promotionTypeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Promotion data by a key.</summary>
		///
		/// <param name="promotionTypeCode">A key for Promotion items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Promotions.Promotion> GetAllPromotionDataByPromotionTypeCode(int promotionTypeCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Promotions.Promotion> sortableList = new BLL.SortableList<BLL.Promotions.Promotion>(DAL.Promotions.Promotion.GetAllPromotionDataByPromotionTypeCode(promotionTypeCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Promotions.Promotion loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Promotions.GetAllPromotionDataByPromotionTypeCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Promotion data by criteria.</summary>
		///
		/// <param name="promotionName">A key for Promotion items to be fetched</param>
		/// <param name="promotionTypeCode">A key for Promotion items to be fetched</param>
		/// <param name="startDate">A key for Promotion items to be fetched</param>
		/// <param name="endDate">A key for Promotion items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Promotion items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Promotion items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Promotions.Promotion> GetManyPromotionDataByCriteria(string promotionName, int? promotionTypeCode, DateTime? startDate, DateTime? endDate, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Promotions.PromotionManager.GetManyPromotionDataByCriteria(promotionName, promotionTypeCode, startDate, endDate, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Promotion data by criteria.</summary>
		///
		/// <param name="promotionName">A key for Promotion items to be fetched</param>
		/// <param name="promotionTypeCode">A key for Promotion items to be fetched</param>
		/// <param name="startDate">A key for Promotion items to be fetched</param>
		/// <param name="endDate">A key for Promotion items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Promotion items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Promotion items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Promotions.Promotion> GetManyPromotionDataByCriteria(string promotionName, int? promotionTypeCode, DateTime? startDate, DateTime? endDate, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Promotions.Promotion> sortableList = new BLL.SortableList<BLL.Promotions.Promotion>(DAL.Promotions.Promotion.GetManyPromotionDataByCriteria(promotionName, promotionTypeCode, startDate, endDate, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Promotions.Promotion loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Promotions.GetManyPromotionDataByCriteria");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single Promotion by an index.</summary>
		///
		/// <param name="promotionCode">The index for Promotion to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Promotions.Promotion GetOnePromotion(int promotionCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Promotions.PromotionManager.GetOnePromotion(promotionCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single Promotion by an index.</summary>
		///
		/// <param name="promotionCode">The index for Promotion to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Promotions.Promotion GetOnePromotion(int promotionCode)
		{
			// perform main method tasks
			return BLL.Promotions.PromotionManager.GetOnePromotion(promotionCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single Promotion by an index.</summary>
		///
		/// <param name="promotionCode">The index for Promotion to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Promotions.Promotion GetOnePromotion(int promotionCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.Promotions.Promotion itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.Promotions.Promotion)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.Promotions.Promotion.GetCacheKey(typeof(BLL.Promotions.Promotion), "PrimaryKey", promotionCode.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.Promotions.Promotion)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.Promotions.Promotion item = DAL.Promotions.Promotion.GetOnePromotion(promotionCode, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.Promotions.Promotion();
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
				throw Utility.CustomAppException.WrapException(ex, "BLL.Promotions.GetOnePromotion");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates Promotion data.</summary>
		///
		/// <param name="item">The Promotion to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOnePromotion(BLL.Promotions.Promotion item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Promotions.PromotionManager.UpdateOnePromotion(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates Promotion data.</summary>
		///
		/// <param name="item">The Promotion to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOnePromotion(BLL.Promotions.Promotion item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Promotions.Promotion itemDAL = new DAL.Promotions.Promotion();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Promotions.Promotion.UpdateOnePromotion(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Promotions.UpdateOnePromotion");
			}
		}
		#endregion Methods
	}
}