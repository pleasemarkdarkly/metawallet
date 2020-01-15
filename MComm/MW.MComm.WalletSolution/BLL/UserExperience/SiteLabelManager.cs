
/*<copyright>
Meta Wallet, Inc (c) 2007 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2007, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/
using System;
using System.ComponentModel;
using MW.MComm.WalletSolution.BLL.UserExperience;
using MOD.Data;
using MW.MComm.WalletSolution.BLL.Config;
using BLL = MW.MComm.WalletSolution.BLL;
using DAL = MW.MComm.WalletSolution.DAL;
using Utility = MW.MComm.WalletSolution.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
namespace MW.MComm.WalletSolution.BLL.UserExperience
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage SiteLabel related information.</summary>
	///
	/// File History:
	/// <created>5/8/2007 (Chris Grundy)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class SiteLabelManager
	{
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public SiteLabelManager()
		{
			//
			// constructor logic
			//
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------
		/// <summary>This method inserts SiteLabel data.</summary>
		///
		/// <param name="item">The SiteLabel to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneSiteLabel(BLL.UserExperience.SiteLabel item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.UserExperience.SiteLabelManager.AddOneSiteLabel(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method inserts SiteLabel data.</summary>
		///
		/// <param name="item">The SiteLabel to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneSiteLabel(BLL.UserExperience.SiteLabel item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.UserExperience.SiteLabel itemDAL = new DAL.UserExperience.SiteLabel();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.UserExperience.SiteLabel.AddOneSiteLabel(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.UserExperience.AddOneSiteLabel");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates SiteLabel data.</summary>
		///
		/// <param name="item">The SiteLabel to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneSiteLabel(BLL.UserExperience.SiteLabel item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.UserExperience.SiteLabelManager.UpdateOneSiteLabel(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates SiteLabel data.</summary>
		///
		/// <param name="item">The SiteLabel to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneSiteLabel(BLL.UserExperience.SiteLabel item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.UserExperience.SiteLabel itemDAL = new DAL.UserExperience.SiteLabel();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.UserExperience.SiteLabel.UpdateOneSiteLabel(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.UserExperience.UpdateOneSiteLabel");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes SiteLabel data.</summary>
		///
		/// <param name="item">The SiteLabel to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneSiteLabel(BLL.UserExperience.SiteLabel item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.UserExperience.SiteLabelManager.DeleteOneSiteLabel(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes SiteLabel data.</summary>
		///
		/// <param name="item">The SiteLabel to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneSiteLabel(BLL.UserExperience.SiteLabel item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.UserExperience.SiteLabel itemDAL = new DAL.UserExperience.SiteLabel();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.UserExperience.SiteLabel.DeleteOneSiteLabel(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = false;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.UserExperience.DeleteOneSiteLabel");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all SiteLabel data by a key.</summary>
		///
		/// <param name="localeCode">A key for SiteLabel items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllSiteLabelDataByLocaleCode(int localeCode)
		{
			// perform main method tasks
			BLL.UserExperience.SiteLabelManager.DeleteAllSiteLabelDataByLocaleCode(localeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all SiteLabel data by a key.</summary>
		///
		/// <param name="localeCode">A key for SiteLabel items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllSiteLabelDataByLocaleCode(int localeCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.UserExperience.SiteLabel.DeleteAllSiteLabelDataByLocaleCode(localeCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.UserExperience.DeleteAllSiteLabelDataByLocaleCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single SiteLabel by an index.</summary>
		///
		/// <param name="siteLabelDefinitionCode">The index for SiteLabel to be fetched</param>
		/// <param name="localeCode">The index for SiteLabel to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.UserExperience.SiteLabel GetOneSiteLabel(int siteLabelDefinitionCode, int localeCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.UserExperience.SiteLabelManager.GetOneSiteLabel(siteLabelDefinitionCode, localeCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single SiteLabel by an index.</summary>
		///
		/// <param name="siteLabelDefinitionCode">The index for SiteLabel to be fetched</param>
		/// <param name="localeCode">The index for SiteLabel to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.UserExperience.SiteLabel GetOneSiteLabel(int siteLabelDefinitionCode, int localeCode)
		{
			// perform main method tasks
			return BLL.UserExperience.SiteLabelManager.GetOneSiteLabel(siteLabelDefinitionCode, localeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single SiteLabel by an index.</summary>
		///
		/// <param name="siteLabelDefinitionCode">The index for SiteLabel to be fetched</param>
		/// <param name="localeCode">The index for SiteLabel to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.UserExperience.SiteLabel GetOneSiteLabel(int siteLabelDefinitionCode, int localeCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.UserExperience.SiteLabel itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.UserExperience.SiteLabel)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.UserExperience.SiteLabel.GetCacheKey(typeof(BLL.UserExperience.SiteLabel), "PrimaryKey", siteLabelDefinitionCode.ToString() + ", " + localeCode.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.UserExperience.SiteLabel)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.UserExperience.SiteLabel item = DAL.UserExperience.SiteLabel.GetOneSiteLabel(siteLabelDefinitionCode, localeCode, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.UserExperience.SiteLabel();
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
				throw Utility.CustomAppException.WrapException(ex, "BLL.UserExperience.GetOneSiteLabel");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all SiteLabel data.</summary>
		///
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.SiteLabel> GetAllSiteLabelData(MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.UserExperience.SiteLabelManager.GetAllSiteLabelData(BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all SiteLabel data.</summary>
		///
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.SiteLabel> GetAllSiteLabelData()
		{
			// perform main method tasks
			return BLL.UserExperience.SiteLabelManager.GetAllSiteLabelData(BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all SiteLabel data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.SiteLabel> GetAllSiteLabelData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.UserExperience.SiteLabel> sortableList = new BLL.SortableList<BLL.UserExperience.SiteLabel>(DAL.UserExperience.SiteLabel.GetAllSiteLabelData(dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.UserExperience.SiteLabel loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.UserExperience.GetAllSiteLabelData");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all SiteLabel data by a key.</summary>
		///
		/// <param name="localeCode">A key for SiteLabel items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.SiteLabel> GetAllSiteLabelDataByLocaleCode(int localeCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.UserExperience.SiteLabelManager.GetAllSiteLabelDataByLocaleCode(localeCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all SiteLabel data by a key.</summary>
		///
		/// <param name="localeCode">A key for SiteLabel items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.SiteLabel> GetAllSiteLabelDataByLocaleCode(int localeCode)
		{
			// perform main method tasks
			return BLL.UserExperience.SiteLabelManager.GetAllSiteLabelDataByLocaleCode(localeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all SiteLabel data by a key.</summary>
		///
		/// <param name="localeCode">A key for SiteLabel items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.SiteLabel> GetAllSiteLabelDataByLocaleCode(int localeCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.UserExperience.SiteLabel> sortableList = new BLL.SortableList<BLL.UserExperience.SiteLabel>(DAL.UserExperience.SiteLabel.GetAllSiteLabelDataByLocaleCode(localeCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.UserExperience.SiteLabel loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.UserExperience.GetAllSiteLabelDataByLocaleCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all SiteLabel data by criteria.</summary>
		///
		/// <param name="title">A key for SiteLabel items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for SiteLabel items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for SiteLabel items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.SiteLabel> GetAllSiteLabelDataByCriteria(string title, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.UserExperience.SiteLabelManager.GetAllSiteLabelDataByCriteria(title, lastModifiedDateStart, lastModifiedDateEnd, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all SiteLabel data by criteria.</summary>
		///
		/// <param name="title">A key for SiteLabel items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for SiteLabel items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for SiteLabel items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.SiteLabel> GetAllSiteLabelDataByCriteria(string title, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd)
		{
			// perform main method tasks
			return BLL.UserExperience.SiteLabelManager.GetAllSiteLabelDataByCriteria(title, lastModifiedDateStart, lastModifiedDateEnd, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all SiteLabel data by criteria.</summary>
		///
		/// <param name="title">A key for SiteLabel items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for SiteLabel items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for SiteLabel items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.SiteLabel> GetAllSiteLabelDataByCriteria(string title, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.UserExperience.SiteLabel> sortableList = new BLL.SortableList<BLL.UserExperience.SiteLabel>(DAL.UserExperience.SiteLabel.GetAllSiteLabelDataByCriteria(title, lastModifiedDateStart, lastModifiedDateEnd, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.UserExperience.SiteLabel loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.UserExperience.GetAllSiteLabelDataByCriteria");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all SiteLabel data by criteria.</summary>
		///
		/// <param name="title">A key for SiteLabel items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for SiteLabel items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for SiteLabel items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.SiteLabel> GetManySiteLabelDataByCriteria(string title, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.UserExperience.SiteLabelManager.GetManySiteLabelDataByCriteria(title, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all SiteLabel data by criteria.</summary>
		///
		/// <param name="title">A key for SiteLabel items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for SiteLabel items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for SiteLabel items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.SiteLabel> GetManySiteLabelDataByCriteria(string title, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.UserExperience.SiteLabel> sortableList = new BLL.SortableList<BLL.UserExperience.SiteLabel>(DAL.UserExperience.SiteLabel.GetManySiteLabelDataByCriteria(title, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.UserExperience.SiteLabel loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.UserExperience.GetManySiteLabelDataByCriteria");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all SiteLabel data by a key.</summary>
		///
		/// <param name="siteLabelDefinitionCode">A key for SiteLabel items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllSiteLabelDataBySiteLabelDefinitionCode(int siteLabelDefinitionCode)
		{
			// perform main method tasks
			BLL.UserExperience.SiteLabelManager.DeleteAllSiteLabelDataBySiteLabelDefinitionCode(siteLabelDefinitionCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all SiteLabel data by a key.</summary>
		///
		/// <param name="siteLabelDefinitionCode">A key for SiteLabel items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllSiteLabelDataBySiteLabelDefinitionCode(int siteLabelDefinitionCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.UserExperience.SiteLabel.DeleteAllSiteLabelDataBySiteLabelDefinitionCode(siteLabelDefinitionCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.UserExperience.DeleteAllSiteLabelDataBySiteLabelDefinitionCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all SiteLabel data by a key.</summary>
		///
		/// <param name="siteLabelDefinitionCode">A key for SiteLabel items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.SiteLabel> GetAllSiteLabelDataBySiteLabelDefinitionCode(int siteLabelDefinitionCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.UserExperience.SiteLabelManager.GetAllSiteLabelDataBySiteLabelDefinitionCode(siteLabelDefinitionCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all SiteLabel data by a key.</summary>
		///
		/// <param name="siteLabelDefinitionCode">A key for SiteLabel items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.SiteLabel> GetAllSiteLabelDataBySiteLabelDefinitionCode(int siteLabelDefinitionCode)
		{
			// perform main method tasks
			return BLL.UserExperience.SiteLabelManager.GetAllSiteLabelDataBySiteLabelDefinitionCode(siteLabelDefinitionCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all SiteLabel data by a key.</summary>
		///
		/// <param name="siteLabelDefinitionCode">A key for SiteLabel items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.SiteLabel> GetAllSiteLabelDataBySiteLabelDefinitionCode(int siteLabelDefinitionCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.UserExperience.SiteLabel> sortableList = new BLL.SortableList<BLL.UserExperience.SiteLabel>(DAL.UserExperience.SiteLabel.GetAllSiteLabelDataBySiteLabelDefinitionCode(siteLabelDefinitionCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.UserExperience.SiteLabel loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.UserExperience.GetAllSiteLabelDataBySiteLabelDefinitionCode");
			}
		}
		#endregion Methods
	}
}