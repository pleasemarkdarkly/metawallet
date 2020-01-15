
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
using MW.MComm.WalletSolution.BLL.Accounts;
using MOD.Data;
using MW.MComm.WalletSolution.BLL.Config;
using BLL = MW.MComm.WalletSolution.BLL;
using DAL = MW.MComm.WalletSolution.DAL;
using Utility = MW.MComm.WalletSolution.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
namespace MW.MComm.WalletSolution.BLL.Accounts
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage ParticipatingPartner related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class ParticipatingPartnerManager
	{
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public ParticipatingPartnerManager()
		{
			//
			// constructor logic
			//
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------
		/// <summary>This method inserts ParticipatingPartner data.</summary>
		///
		/// <param name="item">The ParticipatingPartner to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneParticipatingPartner(BLL.Accounts.ParticipatingPartner item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Accounts.ParticipatingPartnerManager.AddOneParticipatingPartner(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method inserts ParticipatingPartner data.</summary>
		///
		/// <param name="item">The ParticipatingPartner to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneParticipatingPartner(BLL.Accounts.ParticipatingPartner item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Accounts.ParticipatingPartner itemDAL = new DAL.Accounts.ParticipatingPartner();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Accounts.ParticipatingPartner.AddOneParticipatingPartner(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.AddOneParticipatingPartner");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all ParticipatingPartner data by a key.</summary>
		///
		/// <param name="accountID">A key for ParticipatingPartner items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllParticipatingPartnerDataByAccountID(Guid accountID)
		{
			// perform main method tasks
			BLL.Accounts.ParticipatingPartnerManager.DeleteAllParticipatingPartnerDataByAccountID(accountID, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all ParticipatingPartner data by a key.</summary>
		///
		/// <param name="accountID">A key for ParticipatingPartner items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllParticipatingPartnerDataByAccountID(Guid accountID, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Accounts.ParticipatingPartner.DeleteAllParticipatingPartnerDataByAccountID(accountID, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.DeleteAllParticipatingPartnerDataByAccountID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all ParticipatingPartner data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for ParticipatingPartner items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllParticipatingPartnerDataByMetaPartnerID(Guid metaPartnerID)
		{
			// perform main method tasks
			BLL.Accounts.ParticipatingPartnerManager.DeleteAllParticipatingPartnerDataByMetaPartnerID(metaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all ParticipatingPartner data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for ParticipatingPartner items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllParticipatingPartnerDataByMetaPartnerID(Guid metaPartnerID, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Accounts.ParticipatingPartner.DeleteAllParticipatingPartnerDataByMetaPartnerID(metaPartnerID, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.DeleteAllParticipatingPartnerDataByMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes ParticipatingPartner data.</summary>
		///
		/// <param name="item">The ParticipatingPartner to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneParticipatingPartner(BLL.Accounts.ParticipatingPartner item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Accounts.ParticipatingPartnerManager.DeleteOneParticipatingPartner(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes ParticipatingPartner data.</summary>
		///
		/// <param name="item">The ParticipatingPartner to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneParticipatingPartner(BLL.Accounts.ParticipatingPartner item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Accounts.ParticipatingPartner itemDAL = new DAL.Accounts.ParticipatingPartner();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Accounts.ParticipatingPartner.DeleteOneParticipatingPartner(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = false;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.DeleteOneParticipatingPartner");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all ParticipatingPartner data.</summary>
		///
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.ParticipatingPartner> GetAllParticipatingPartnerData(MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.ParticipatingPartnerManager.GetAllParticipatingPartnerData(BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all ParticipatingPartner data.</summary>
		///
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.ParticipatingPartner> GetAllParticipatingPartnerData()
		{
			// perform main method tasks
			return BLL.Accounts.ParticipatingPartnerManager.GetAllParticipatingPartnerData(BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all ParticipatingPartner data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.ParticipatingPartner> GetAllParticipatingPartnerData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Accounts.ParticipatingPartner> sortableList = new BLL.SortableList<BLL.Accounts.ParticipatingPartner>(DAL.Accounts.ParticipatingPartner.GetAllParticipatingPartnerData(dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Accounts.ParticipatingPartner loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetAllParticipatingPartnerData");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all ParticipatingPartner data by a key.</summary>
		///
		/// <param name="accountID">A key for ParticipatingPartner items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.ParticipatingPartner> GetAllParticipatingPartnerDataByAccountID(Guid accountID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.ParticipatingPartnerManager.GetAllParticipatingPartnerDataByAccountID(accountID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all ParticipatingPartner data by a key.</summary>
		///
		/// <param name="accountID">A key for ParticipatingPartner items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.ParticipatingPartner> GetAllParticipatingPartnerDataByAccountID(Guid accountID)
		{
			// perform main method tasks
			return BLL.Accounts.ParticipatingPartnerManager.GetAllParticipatingPartnerDataByAccountID(accountID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all ParticipatingPartner data by a key.</summary>
		///
		/// <param name="accountID">A key for ParticipatingPartner items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.ParticipatingPartner> GetAllParticipatingPartnerDataByAccountID(Guid accountID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Accounts.ParticipatingPartner> sortableList = new BLL.SortableList<BLL.Accounts.ParticipatingPartner>(DAL.Accounts.ParticipatingPartner.GetAllParticipatingPartnerDataByAccountID(accountID, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Accounts.ParticipatingPartner loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetAllParticipatingPartnerDataByAccountID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all ParticipatingPartner data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for ParticipatingPartner items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.ParticipatingPartner> GetAllParticipatingPartnerDataByMetaPartnerID(Guid metaPartnerID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.ParticipatingPartnerManager.GetAllParticipatingPartnerDataByMetaPartnerID(metaPartnerID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all ParticipatingPartner data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for ParticipatingPartner items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.ParticipatingPartner> GetAllParticipatingPartnerDataByMetaPartnerID(Guid metaPartnerID)
		{
			// perform main method tasks
			return BLL.Accounts.ParticipatingPartnerManager.GetAllParticipatingPartnerDataByMetaPartnerID(metaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all ParticipatingPartner data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for ParticipatingPartner items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.ParticipatingPartner> GetAllParticipatingPartnerDataByMetaPartnerID(Guid metaPartnerID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Accounts.ParticipatingPartner> sortableList = new BLL.SortableList<BLL.Accounts.ParticipatingPartner>(DAL.Accounts.ParticipatingPartner.GetAllParticipatingPartnerDataByMetaPartnerID(metaPartnerID, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Accounts.ParticipatingPartner loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetAllParticipatingPartnerDataByMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single ParticipatingPartner by an index.</summary>
		///
		/// <param name="accountID">The index for ParticipatingPartner to be fetched</param>
		/// <param name="metaPartnerID">The index for ParticipatingPartner to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Accounts.ParticipatingPartner GetOneParticipatingPartner(Guid accountID, Guid metaPartnerID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.ParticipatingPartnerManager.GetOneParticipatingPartner(accountID, metaPartnerID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single ParticipatingPartner by an index.</summary>
		///
		/// <param name="accountID">The index for ParticipatingPartner to be fetched</param>
		/// <param name="metaPartnerID">The index for ParticipatingPartner to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Accounts.ParticipatingPartner GetOneParticipatingPartner(Guid accountID, Guid metaPartnerID)
		{
			// perform main method tasks
			return BLL.Accounts.ParticipatingPartnerManager.GetOneParticipatingPartner(accountID, metaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single ParticipatingPartner by an index.</summary>
		///
		/// <param name="accountID">The index for ParticipatingPartner to be fetched</param>
		/// <param name="metaPartnerID">The index for ParticipatingPartner to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Accounts.ParticipatingPartner GetOneParticipatingPartner(Guid accountID, Guid metaPartnerID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.Accounts.ParticipatingPartner itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.Accounts.ParticipatingPartner)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.Accounts.ParticipatingPartner.GetCacheKey(typeof(BLL.Accounts.ParticipatingPartner), "PrimaryKey", accountID.ToString() + ", " + metaPartnerID.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.Accounts.ParticipatingPartner)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.Accounts.ParticipatingPartner item = DAL.Accounts.ParticipatingPartner.GetOneParticipatingPartner(accountID, metaPartnerID, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.Accounts.ParticipatingPartner();
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
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetOneParticipatingPartner");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates ParticipatingPartner data.</summary>
		///
		/// <param name="item">The ParticipatingPartner to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneParticipatingPartner(BLL.Accounts.ParticipatingPartner item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Accounts.ParticipatingPartnerManager.UpdateOneParticipatingPartner(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates ParticipatingPartner data.</summary>
		///
		/// <param name="item">The ParticipatingPartner to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneParticipatingPartner(BLL.Accounts.ParticipatingPartner item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Accounts.ParticipatingPartner itemDAL = new DAL.Accounts.ParticipatingPartner();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Accounts.ParticipatingPartner.UpdateOneParticipatingPartner(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.UpdateOneParticipatingPartner");
			}
		}
		#endregion Methods
	}
}