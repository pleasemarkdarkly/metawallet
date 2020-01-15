
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
	/// <summary>This class is used to manage SiteLabelDefinition related information.</summary>
	///
	/// File History:
	/// <created>2/16/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class SiteLabelDefinitionManager
	{
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public SiteLabelDefinitionManager()
		{
			//
			// constructor logic
			//
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------
		/// <summary>This method inserts SiteLabelDefinition data.</summary>
		///
		/// <param name="item">The SiteLabelDefinition to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneSiteLabelDefinition(BLL.UserExperience.SiteLabelDefinition item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.UserExperience.SiteLabelDefinitionManager.AddOneSiteLabelDefinition(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method inserts SiteLabelDefinition data.</summary>
		///
		/// <param name="item">The SiteLabelDefinition to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneSiteLabelDefinition(BLL.UserExperience.SiteLabelDefinition item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				// perform enum check
				if (Enum.IsDefined(typeof(SiteLabelDefinitionCode), item.SiteLabelDefinitionCode) == true)
				{
					throw new Utility.CustomAppException(BLL.Core.ErrorNumber.EnumerationAddException, BLL.Core.ErrorManager.GetErrorMessageFromErrorNumber(BLL.Core.ErrorNumber.EnumerationAddException), null);
				}
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.UserExperience.SiteLabelDefinition itemDAL = new DAL.UserExperience.SiteLabelDefinition();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.UserExperience.SiteLabelDefinition.AddOneSiteLabelDefinition(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.UserExperience.AddOneSiteLabelDefinition");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates SiteLabelDefinition data.</summary>
		///
		/// <param name="item">The SiteLabelDefinition to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneSiteLabelDefinition(BLL.UserExperience.SiteLabelDefinition item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.UserExperience.SiteLabelDefinitionManager.UpdateOneSiteLabelDefinition(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates SiteLabelDefinition data.</summary>
		///
		/// <param name="item">The SiteLabelDefinition to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneSiteLabelDefinition(BLL.UserExperience.SiteLabelDefinition item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.UserExperience.SiteLabelDefinition itemDAL = new DAL.UserExperience.SiteLabelDefinition();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.UserExperience.SiteLabelDefinition.UpdateOneSiteLabelDefinition(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.UserExperience.UpdateOneSiteLabelDefinition");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes SiteLabelDefinition data.</summary>
		///
		/// <param name="item">The SiteLabelDefinition to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneSiteLabelDefinition(BLL.UserExperience.SiteLabelDefinition item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.UserExperience.SiteLabelDefinitionManager.DeleteOneSiteLabelDefinition(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes SiteLabelDefinition data.</summary>
		///
		/// <param name="item">The SiteLabelDefinition to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneSiteLabelDefinition(BLL.UserExperience.SiteLabelDefinition item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				// perform enum check
				if (Enum.IsDefined(typeof(SiteLabelDefinitionCode), item.SiteLabelDefinitionCode) == true)
				{
					throw new Utility.CustomAppException(BLL.Core.ErrorNumber.EnumerationDeleteException, BLL.Core.ErrorManager.GetErrorMessageFromErrorNumber(BLL.Core.ErrorNumber.EnumerationDeleteException), null);
				}
				DAL.UserExperience.SiteLabelDefinition itemDAL = new DAL.UserExperience.SiteLabelDefinition();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.UserExperience.SiteLabelDefinition.DeleteOneSiteLabelDefinition(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = false;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.UserExperience.DeleteOneSiteLabelDefinition");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single SiteLabelDefinition by an index.</summary>
		///
		/// <param name="siteLabelDefinitionCode">The index for SiteLabelDefinition to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.UserExperience.SiteLabelDefinition GetOneSiteLabelDefinition(int siteLabelDefinitionCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.UserExperience.SiteLabelDefinitionManager.GetOneSiteLabelDefinition(siteLabelDefinitionCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single SiteLabelDefinition by an index.</summary>
		///
		/// <param name="siteLabelDefinitionCode">The index for SiteLabelDefinition to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.UserExperience.SiteLabelDefinition GetOneSiteLabelDefinition(int siteLabelDefinitionCode)
		{
			// perform main method tasks
			return BLL.UserExperience.SiteLabelDefinitionManager.GetOneSiteLabelDefinition(siteLabelDefinitionCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single SiteLabelDefinition by an index.</summary>
		///
		/// <param name="siteLabelDefinitionCode">The index for SiteLabelDefinition to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.UserExperience.SiteLabelDefinition GetOneSiteLabelDefinition(int siteLabelDefinitionCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.UserExperience.SiteLabelDefinition itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.UserExperience.SiteLabelDefinition)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.UserExperience.SiteLabelDefinition.GetCacheKey(typeof(BLL.UserExperience.SiteLabelDefinition), "PrimaryKey", siteLabelDefinitionCode.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.UserExperience.SiteLabelDefinition)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.UserExperience.SiteLabelDefinition item = DAL.UserExperience.SiteLabelDefinition.GetOneSiteLabelDefinition(siteLabelDefinitionCode, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.UserExperience.SiteLabelDefinition();
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
				throw Utility.CustomAppException.WrapException(ex, "BLL.UserExperience.GetOneSiteLabelDefinition");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all SiteLabelDefinition data.</summary>
		///
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.SiteLabelDefinition> GetAllSiteLabelDefinitionData(MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.UserExperience.SiteLabelDefinitionManager.GetAllSiteLabelDefinitionData(BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all SiteLabelDefinition data.</summary>
		///
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.SiteLabelDefinition> GetAllSiteLabelDefinitionData()
		{
			// perform main method tasks
			return BLL.UserExperience.SiteLabelDefinitionManager.GetAllSiteLabelDefinitionData(BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all SiteLabelDefinition data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.SiteLabelDefinition> GetAllSiteLabelDefinitionData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.UserExperience.SiteLabelDefinition> sortableList = new BLL.SortableList<BLL.UserExperience.SiteLabelDefinition>(DAL.UserExperience.SiteLabelDefinition.GetAllSiteLabelDefinitionData(dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.UserExperience.SiteLabelDefinition loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.UserExperience.GetAllSiteLabelDefinitionData");
			}
		}
		#endregion Methods
	}
}