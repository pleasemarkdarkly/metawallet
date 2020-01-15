
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
	/// <summary>This class is used to manage SiteHelp related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class SiteHelpManager
	{
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public SiteHelpManager()
		{
			//
			// constructor logic
			//
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------
		/// <summary>This method inserts SiteHelp data.</summary>
		///
		/// <param name="item">The SiteHelp to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneSiteHelp(BLL.UserExperience.SiteHelp item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.UserExperience.SiteHelpManager.AddOneSiteHelp(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method inserts SiteHelp data.</summary>
		///
		/// <param name="item">The SiteHelp to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneSiteHelp(BLL.UserExperience.SiteHelp item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.UserExperience.SiteHelp itemDAL = new DAL.UserExperience.SiteHelp();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.UserExperience.SiteHelp.AddOneSiteHelp(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.UserExperience.AddOneSiteHelp");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all SiteHelp data by a key.</summary>
		///
		/// <param name="localeCode">A key for SiteHelp items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllSiteHelpDataByLocaleCode(int localeCode)
		{
			// perform main method tasks
			BLL.UserExperience.SiteHelpManager.DeleteAllSiteHelpDataByLocaleCode(localeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all SiteHelp data by a key.</summary>
		///
		/// <param name="localeCode">A key for SiteHelp items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllSiteHelpDataByLocaleCode(int localeCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.UserExperience.SiteHelp.DeleteAllSiteHelpDataByLocaleCode(localeCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.UserExperience.DeleteAllSiteHelpDataByLocaleCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all SiteHelp data by a key.</summary>
		///
		/// <param name="siteHelpDefinitionCode">A key for SiteHelp items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllSiteHelpDataBySiteHelpDefinitionCode(int siteHelpDefinitionCode)
		{
			// perform main method tasks
			BLL.UserExperience.SiteHelpManager.DeleteAllSiteHelpDataBySiteHelpDefinitionCode(siteHelpDefinitionCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all SiteHelp data by a key.</summary>
		///
		/// <param name="siteHelpDefinitionCode">A key for SiteHelp items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllSiteHelpDataBySiteHelpDefinitionCode(int siteHelpDefinitionCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.UserExperience.SiteHelp.DeleteAllSiteHelpDataBySiteHelpDefinitionCode(siteHelpDefinitionCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.UserExperience.DeleteAllSiteHelpDataBySiteHelpDefinitionCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all SiteHelp data by a key.</summary>
		///
		/// <param name="siteHelpGroupCode">A key for SiteHelp items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllSiteHelpDataBySiteHelpGroupCode(int siteHelpGroupCode)
		{
			// perform main method tasks
			BLL.UserExperience.SiteHelpManager.DeleteAllSiteHelpDataBySiteHelpGroupCode(siteHelpGroupCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all SiteHelp data by a key.</summary>
		///
		/// <param name="siteHelpGroupCode">A key for SiteHelp items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllSiteHelpDataBySiteHelpGroupCode(int siteHelpGroupCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.UserExperience.SiteHelp.DeleteAllSiteHelpDataBySiteHelpGroupCode(siteHelpGroupCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.UserExperience.DeleteAllSiteHelpDataBySiteHelpGroupCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes SiteHelp data.</summary>
		///
		/// <param name="item">The SiteHelp to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneSiteHelp(BLL.UserExperience.SiteHelp item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.UserExperience.SiteHelpManager.DeleteOneSiteHelp(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes SiteHelp data.</summary>
		///
		/// <param name="item">The SiteHelp to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneSiteHelp(BLL.UserExperience.SiteHelp item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.UserExperience.SiteHelp itemDAL = new DAL.UserExperience.SiteHelp();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.UserExperience.SiteHelp.DeleteOneSiteHelp(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = false;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.UserExperience.DeleteOneSiteHelp");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all SiteHelp data.</summary>
		///
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.SiteHelp> GetAllSiteHelpData(MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.UserExperience.SiteHelpManager.GetAllSiteHelpData(BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all SiteHelp data.</summary>
		///
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.SiteHelp> GetAllSiteHelpData()
		{
			// perform main method tasks
			return BLL.UserExperience.SiteHelpManager.GetAllSiteHelpData(BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all SiteHelp data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.SiteHelp> GetAllSiteHelpData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.UserExperience.SiteHelp> sortableList = new BLL.SortableList<BLL.UserExperience.SiteHelp>(DAL.UserExperience.SiteHelp.GetAllSiteHelpData(dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.UserExperience.SiteHelp loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.UserExperience.GetAllSiteHelpData");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all SiteHelp data by criteria.</summary>
		///
		/// <param name="siteHelpName">A key for SiteHelp items to be fetched</param>
		/// <param name="siteHelpGroupCode">A key for SiteHelp items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for SiteHelp items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for SiteHelp items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.SiteHelp> GetAllSiteHelpDataByCriteria(string siteHelpName, int? siteHelpGroupCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.UserExperience.SiteHelpManager.GetAllSiteHelpDataByCriteria(siteHelpName, siteHelpGroupCode, lastModifiedDateStart, lastModifiedDateEnd, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all SiteHelp data by criteria.</summary>
		///
		/// <param name="siteHelpName">A key for SiteHelp items to be fetched</param>
		/// <param name="siteHelpGroupCode">A key for SiteHelp items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for SiteHelp items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for SiteHelp items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.SiteHelp> GetAllSiteHelpDataByCriteria(string siteHelpName, int? siteHelpGroupCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd)
		{
			// perform main method tasks
			return BLL.UserExperience.SiteHelpManager.GetAllSiteHelpDataByCriteria(siteHelpName, siteHelpGroupCode, lastModifiedDateStart, lastModifiedDateEnd, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all SiteHelp data by criteria.</summary>
		///
		/// <param name="siteHelpName">A key for SiteHelp items to be fetched</param>
		/// <param name="siteHelpGroupCode">A key for SiteHelp items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for SiteHelp items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for SiteHelp items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.SiteHelp> GetAllSiteHelpDataByCriteria(string siteHelpName, int? siteHelpGroupCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.UserExperience.SiteHelp> sortableList = new BLL.SortableList<BLL.UserExperience.SiteHelp>(DAL.UserExperience.SiteHelp.GetAllSiteHelpDataByCriteria(siteHelpName, siteHelpGroupCode, lastModifiedDateStart, lastModifiedDateEnd, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.UserExperience.SiteHelp loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.UserExperience.GetAllSiteHelpDataByCriteria");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all SiteHelp data by a key.</summary>
		///
		/// <param name="localeCode">A key for SiteHelp items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.SiteHelp> GetAllSiteHelpDataByLocaleCode(int localeCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.UserExperience.SiteHelpManager.GetAllSiteHelpDataByLocaleCode(localeCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all SiteHelp data by a key.</summary>
		///
		/// <param name="localeCode">A key for SiteHelp items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.SiteHelp> GetAllSiteHelpDataByLocaleCode(int localeCode)
		{
			// perform main method tasks
			return BLL.UserExperience.SiteHelpManager.GetAllSiteHelpDataByLocaleCode(localeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all SiteHelp data by a key.</summary>
		///
		/// <param name="localeCode">A key for SiteHelp items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.SiteHelp> GetAllSiteHelpDataByLocaleCode(int localeCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.UserExperience.SiteHelp> sortableList = new BLL.SortableList<BLL.UserExperience.SiteHelp>(DAL.UserExperience.SiteHelp.GetAllSiteHelpDataByLocaleCode(localeCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.UserExperience.SiteHelp loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.UserExperience.GetAllSiteHelpDataByLocaleCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all SiteHelp data by a key.</summary>
		///
		/// <param name="siteHelpDefinitionCode">A key for SiteHelp items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.SiteHelp> GetAllSiteHelpDataBySiteHelpDefinitionCode(int siteHelpDefinitionCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.UserExperience.SiteHelpManager.GetAllSiteHelpDataBySiteHelpDefinitionCode(siteHelpDefinitionCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all SiteHelp data by a key.</summary>
		///
		/// <param name="siteHelpDefinitionCode">A key for SiteHelp items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.SiteHelp> GetAllSiteHelpDataBySiteHelpDefinitionCode(int siteHelpDefinitionCode)
		{
			// perform main method tasks
			return BLL.UserExperience.SiteHelpManager.GetAllSiteHelpDataBySiteHelpDefinitionCode(siteHelpDefinitionCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all SiteHelp data by a key.</summary>
		///
		/// <param name="siteHelpDefinitionCode">A key for SiteHelp items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.SiteHelp> GetAllSiteHelpDataBySiteHelpDefinitionCode(int siteHelpDefinitionCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.UserExperience.SiteHelp> sortableList = new BLL.SortableList<BLL.UserExperience.SiteHelp>(DAL.UserExperience.SiteHelp.GetAllSiteHelpDataBySiteHelpDefinitionCode(siteHelpDefinitionCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.UserExperience.SiteHelp loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.UserExperience.GetAllSiteHelpDataBySiteHelpDefinitionCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all SiteHelp data by a key.</summary>
		///
		/// <param name="siteHelpGroupCode">A key for SiteHelp items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.SiteHelp> GetAllSiteHelpDataBySiteHelpGroupCode(int siteHelpGroupCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.UserExperience.SiteHelpManager.GetAllSiteHelpDataBySiteHelpGroupCode(siteHelpGroupCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all SiteHelp data by a key.</summary>
		///
		/// <param name="siteHelpGroupCode">A key for SiteHelp items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.SiteHelp> GetAllSiteHelpDataBySiteHelpGroupCode(int siteHelpGroupCode)
		{
			// perform main method tasks
			return BLL.UserExperience.SiteHelpManager.GetAllSiteHelpDataBySiteHelpGroupCode(siteHelpGroupCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all SiteHelp data by a key.</summary>
		///
		/// <param name="siteHelpGroupCode">A key for SiteHelp items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.SiteHelp> GetAllSiteHelpDataBySiteHelpGroupCode(int siteHelpGroupCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.UserExperience.SiteHelp> sortableList = new BLL.SortableList<BLL.UserExperience.SiteHelp>(DAL.UserExperience.SiteHelp.GetAllSiteHelpDataBySiteHelpGroupCode(siteHelpGroupCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.UserExperience.SiteHelp loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.UserExperience.GetAllSiteHelpDataBySiteHelpGroupCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all SiteHelp data by criteria.</summary>
		///
		/// <param name="siteHelpName">A key for SiteHelp items to be fetched</param>
		/// <param name="siteHelpGroupCode">A key for SiteHelp items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for SiteHelp items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for SiteHelp items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.SiteHelp> GetManySiteHelpDataByCriteria(string siteHelpName, int? siteHelpGroupCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.UserExperience.SiteHelpManager.GetManySiteHelpDataByCriteria(siteHelpName, siteHelpGroupCode, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all SiteHelp data by criteria.</summary>
		///
		/// <param name="siteHelpName">A key for SiteHelp items to be fetched</param>
		/// <param name="siteHelpGroupCode">A key for SiteHelp items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for SiteHelp items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for SiteHelp items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.SiteHelp> GetManySiteHelpDataByCriteria(string siteHelpName, int? siteHelpGroupCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.UserExperience.SiteHelp> sortableList = new BLL.SortableList<BLL.UserExperience.SiteHelp>(DAL.UserExperience.SiteHelp.GetManySiteHelpDataByCriteria(siteHelpName, siteHelpGroupCode, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.UserExperience.SiteHelp loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.UserExperience.GetManySiteHelpDataByCriteria");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single SiteHelp by an index.</summary>
		///
		/// <param name="siteHelpDefinitionCode">The index for SiteHelp to be fetched</param>
		/// <param name="localeCode">The index for SiteHelp to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.UserExperience.SiteHelp GetOneSiteHelp(int siteHelpDefinitionCode, int localeCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.UserExperience.SiteHelpManager.GetOneSiteHelp(siteHelpDefinitionCode, localeCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single SiteHelp by an index.</summary>
		///
		/// <param name="siteHelpDefinitionCode">The index for SiteHelp to be fetched</param>
		/// <param name="localeCode">The index for SiteHelp to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.UserExperience.SiteHelp GetOneSiteHelp(int siteHelpDefinitionCode, int localeCode)
		{
			// perform main method tasks
			return BLL.UserExperience.SiteHelpManager.GetOneSiteHelp(siteHelpDefinitionCode, localeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single SiteHelp by an index.</summary>
		///
		/// <param name="siteHelpDefinitionCode">The index for SiteHelp to be fetched</param>
		/// <param name="localeCode">The index for SiteHelp to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.UserExperience.SiteHelp GetOneSiteHelp(int siteHelpDefinitionCode, int localeCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.UserExperience.SiteHelp itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.UserExperience.SiteHelp)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.UserExperience.SiteHelp.GetCacheKey(typeof(BLL.UserExperience.SiteHelp), "PrimaryKey", siteHelpDefinitionCode.ToString() + ", " + localeCode.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.UserExperience.SiteHelp)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.UserExperience.SiteHelp item = DAL.UserExperience.SiteHelp.GetOneSiteHelp(siteHelpDefinitionCode, localeCode, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.UserExperience.SiteHelp();
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
				throw Utility.CustomAppException.WrapException(ex, "BLL.UserExperience.GetOneSiteHelp");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates SiteHelp data.</summary>
		///
		/// <param name="item">The SiteHelp to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneSiteHelp(BLL.UserExperience.SiteHelp item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.UserExperience.SiteHelpManager.UpdateOneSiteHelp(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates SiteHelp data.</summary>
		///
		/// <param name="item">The SiteHelp to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneSiteHelp(BLL.UserExperience.SiteHelp item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.UserExperience.SiteHelp itemDAL = new DAL.UserExperience.SiteHelp();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.UserExperience.SiteHelp.UpdateOneSiteHelp(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.UserExperience.UpdateOneSiteHelp");
			}
		}
		#endregion Methods
	}
}