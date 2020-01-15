
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
	/// <summary>This class is used to manage SiteHelpDefinition related information.</summary>
	///
	/// File History:
	/// <created>2/16/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class SiteHelpDefinitionManager
	{
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public SiteHelpDefinitionManager()
		{
			//
			// constructor logic
			//
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------
		/// <summary>This method inserts SiteHelpDefinition data.</summary>
		///
		/// <param name="item">The SiteHelpDefinition to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneSiteHelpDefinition(BLL.UserExperience.SiteHelpDefinition item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.UserExperience.SiteHelpDefinitionManager.AddOneSiteHelpDefinition(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method inserts SiteHelpDefinition data.</summary>
		///
		/// <param name="item">The SiteHelpDefinition to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneSiteHelpDefinition(BLL.UserExperience.SiteHelpDefinition item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				// perform enum check
				if (Enum.IsDefined(typeof(SiteHelpDefinitionCode), item.SiteHelpDefinitionCode) == true)
				{
					throw new Utility.CustomAppException(BLL.Core.ErrorNumber.EnumerationAddException, BLL.Core.ErrorManager.GetErrorMessageFromErrorNumber(BLL.Core.ErrorNumber.EnumerationAddException), null);
				}
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.UserExperience.SiteHelpDefinition itemDAL = new DAL.UserExperience.SiteHelpDefinition();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.UserExperience.SiteHelpDefinition.AddOneSiteHelpDefinition(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.UserExperience.AddOneSiteHelpDefinition");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates SiteHelpDefinition data.</summary>
		///
		/// <param name="item">The SiteHelpDefinition to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneSiteHelpDefinition(BLL.UserExperience.SiteHelpDefinition item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.UserExperience.SiteHelpDefinitionManager.UpdateOneSiteHelpDefinition(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates SiteHelpDefinition data.</summary>
		///
		/// <param name="item">The SiteHelpDefinition to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneSiteHelpDefinition(BLL.UserExperience.SiteHelpDefinition item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.UserExperience.SiteHelpDefinition itemDAL = new DAL.UserExperience.SiteHelpDefinition();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.UserExperience.SiteHelpDefinition.UpdateOneSiteHelpDefinition(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.UserExperience.UpdateOneSiteHelpDefinition");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes SiteHelpDefinition data.</summary>
		///
		/// <param name="item">The SiteHelpDefinition to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneSiteHelpDefinition(BLL.UserExperience.SiteHelpDefinition item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.UserExperience.SiteHelpDefinitionManager.DeleteOneSiteHelpDefinition(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes SiteHelpDefinition data.</summary>
		///
		/// <param name="item">The SiteHelpDefinition to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneSiteHelpDefinition(BLL.UserExperience.SiteHelpDefinition item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				// perform enum check
				if (Enum.IsDefined(typeof(SiteHelpDefinitionCode), item.SiteHelpDefinitionCode) == true)
				{
					throw new Utility.CustomAppException(BLL.Core.ErrorNumber.EnumerationDeleteException, BLL.Core.ErrorManager.GetErrorMessageFromErrorNumber(BLL.Core.ErrorNumber.EnumerationDeleteException), null);
				}
				DAL.UserExperience.SiteHelpDefinition itemDAL = new DAL.UserExperience.SiteHelpDefinition();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.UserExperience.SiteHelpDefinition.DeleteOneSiteHelpDefinition(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = false;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.UserExperience.DeleteOneSiteHelpDefinition");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single SiteHelpDefinition by an index.</summary>
		///
		/// <param name="siteHelpDefinitionCode">The index for SiteHelpDefinition to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.UserExperience.SiteHelpDefinition GetOneSiteHelpDefinition(int siteHelpDefinitionCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.UserExperience.SiteHelpDefinitionManager.GetOneSiteHelpDefinition(siteHelpDefinitionCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single SiteHelpDefinition by an index.</summary>
		///
		/// <param name="siteHelpDefinitionCode">The index for SiteHelpDefinition to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.UserExperience.SiteHelpDefinition GetOneSiteHelpDefinition(int siteHelpDefinitionCode)
		{
			// perform main method tasks
			return BLL.UserExperience.SiteHelpDefinitionManager.GetOneSiteHelpDefinition(siteHelpDefinitionCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single SiteHelpDefinition by an index.</summary>
		///
		/// <param name="siteHelpDefinitionCode">The index for SiteHelpDefinition to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.UserExperience.SiteHelpDefinition GetOneSiteHelpDefinition(int siteHelpDefinitionCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.UserExperience.SiteHelpDefinition itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.UserExperience.SiteHelpDefinition)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.UserExperience.SiteHelpDefinition.GetCacheKey(typeof(BLL.UserExperience.SiteHelpDefinition), "PrimaryKey", siteHelpDefinitionCode.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.UserExperience.SiteHelpDefinition)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.UserExperience.SiteHelpDefinition item = DAL.UserExperience.SiteHelpDefinition.GetOneSiteHelpDefinition(siteHelpDefinitionCode, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.UserExperience.SiteHelpDefinition();
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
				throw Utility.CustomAppException.WrapException(ex, "BLL.UserExperience.GetOneSiteHelpDefinition");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all SiteHelpDefinition data.</summary>
		///
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.SiteHelpDefinition> GetAllSiteHelpDefinitionData(MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.UserExperience.SiteHelpDefinitionManager.GetAllSiteHelpDefinitionData(BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all SiteHelpDefinition data.</summary>
		///
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.SiteHelpDefinition> GetAllSiteHelpDefinitionData()
		{
			// perform main method tasks
			return BLL.UserExperience.SiteHelpDefinitionManager.GetAllSiteHelpDefinitionData(BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all SiteHelpDefinition data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.SiteHelpDefinition> GetAllSiteHelpDefinitionData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.UserExperience.SiteHelpDefinition> sortableList = new BLL.SortableList<BLL.UserExperience.SiteHelpDefinition>(DAL.UserExperience.SiteHelpDefinition.GetAllSiteHelpDefinitionData(dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.UserExperience.SiteHelpDefinition loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.UserExperience.GetAllSiteHelpDefinitionData");
			}
		}
		#endregion Methods
	}
}