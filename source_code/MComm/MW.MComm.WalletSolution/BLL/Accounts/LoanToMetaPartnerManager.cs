
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
	/// <summary>This class is used to manage LoanToMetaPartner related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class LoanToMetaPartnerManager
	{
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public LoanToMetaPartnerManager()
		{
			//
			// constructor logic
			//
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------
		/// <summary>This method inserts LoanToMetaPartner data.</summary>
		///
		/// <param name="item">The LoanToMetaPartner to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneLoanToMetaPartner(BLL.Accounts.LoanToMetaPartner item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Accounts.LoanToMetaPartnerManager.AddOneLoanToMetaPartner(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method inserts LoanToMetaPartner data.</summary>
		///
		/// <param name="item">The LoanToMetaPartner to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneLoanToMetaPartner(BLL.Accounts.LoanToMetaPartner item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Accounts.LoanToMetaPartner itemDAL = new DAL.Accounts.LoanToMetaPartner();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Accounts.LoanToMetaPartner.AddOneLoanToMetaPartner(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.AddOneLoanToMetaPartner");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all LoanToMetaPartner data by a key.</summary>
		///
		/// <param name="accountID">A key for LoanToMetaPartner items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllLoanToMetaPartnerDataByAccountID(Guid accountID)
		{
			// perform main method tasks
			BLL.Accounts.LoanToMetaPartnerManager.DeleteAllLoanToMetaPartnerDataByAccountID(accountID, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all LoanToMetaPartner data by a key.</summary>
		///
		/// <param name="accountID">A key for LoanToMetaPartner items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllLoanToMetaPartnerDataByAccountID(Guid accountID, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Accounts.LoanToMetaPartner.DeleteAllLoanToMetaPartnerDataByAccountID(accountID, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.DeleteAllLoanToMetaPartnerDataByAccountID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all LoanToMetaPartner data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for LoanToMetaPartner items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllLoanToMetaPartnerDataByMetaPartnerID(Guid metaPartnerID)
		{
			// perform main method tasks
			BLL.Accounts.LoanToMetaPartnerManager.DeleteAllLoanToMetaPartnerDataByMetaPartnerID(metaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all LoanToMetaPartner data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for LoanToMetaPartner items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllLoanToMetaPartnerDataByMetaPartnerID(Guid metaPartnerID, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Accounts.LoanToMetaPartner.DeleteAllLoanToMetaPartnerDataByMetaPartnerID(metaPartnerID, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.DeleteAllLoanToMetaPartnerDataByMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes LoanToMetaPartner data.</summary>
		///
		/// <param name="item">The LoanToMetaPartner to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneLoanToMetaPartner(BLL.Accounts.LoanToMetaPartner item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Accounts.LoanToMetaPartnerManager.DeleteOneLoanToMetaPartner(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes LoanToMetaPartner data.</summary>
		///
		/// <param name="item">The LoanToMetaPartner to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneLoanToMetaPartner(BLL.Accounts.LoanToMetaPartner item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Accounts.LoanToMetaPartner itemDAL = new DAL.Accounts.LoanToMetaPartner();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Accounts.LoanToMetaPartner.DeleteOneLoanToMetaPartner(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = false;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.DeleteOneLoanToMetaPartner");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all LoanToMetaPartner data.</summary>
		///
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.LoanToMetaPartner> GetAllLoanToMetaPartnerData(MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.LoanToMetaPartnerManager.GetAllLoanToMetaPartnerData(BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all LoanToMetaPartner data.</summary>
		///
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.LoanToMetaPartner> GetAllLoanToMetaPartnerData()
		{
			// perform main method tasks
			return BLL.Accounts.LoanToMetaPartnerManager.GetAllLoanToMetaPartnerData(BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all LoanToMetaPartner data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.LoanToMetaPartner> GetAllLoanToMetaPartnerData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Accounts.LoanToMetaPartner> sortableList = new BLL.SortableList<BLL.Accounts.LoanToMetaPartner>(DAL.Accounts.LoanToMetaPartner.GetAllLoanToMetaPartnerData(dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Accounts.LoanToMetaPartner loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetAllLoanToMetaPartnerData");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all LoanToMetaPartner data by a key.</summary>
		///
		/// <param name="accountID">A key for LoanToMetaPartner items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.LoanToMetaPartner> GetAllLoanToMetaPartnerDataByAccountID(Guid accountID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.LoanToMetaPartnerManager.GetAllLoanToMetaPartnerDataByAccountID(accountID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all LoanToMetaPartner data by a key.</summary>
		///
		/// <param name="accountID">A key for LoanToMetaPartner items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.LoanToMetaPartner> GetAllLoanToMetaPartnerDataByAccountID(Guid accountID)
		{
			// perform main method tasks
			return BLL.Accounts.LoanToMetaPartnerManager.GetAllLoanToMetaPartnerDataByAccountID(accountID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all LoanToMetaPartner data by a key.</summary>
		///
		/// <param name="accountID">A key for LoanToMetaPartner items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.LoanToMetaPartner> GetAllLoanToMetaPartnerDataByAccountID(Guid accountID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Accounts.LoanToMetaPartner> sortableList = new BLL.SortableList<BLL.Accounts.LoanToMetaPartner>(DAL.Accounts.LoanToMetaPartner.GetAllLoanToMetaPartnerDataByAccountID(accountID, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Accounts.LoanToMetaPartner loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetAllLoanToMetaPartnerDataByAccountID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all LoanToMetaPartner data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for LoanToMetaPartner items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.LoanToMetaPartner> GetAllLoanToMetaPartnerDataByMetaPartnerID(Guid metaPartnerID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.LoanToMetaPartnerManager.GetAllLoanToMetaPartnerDataByMetaPartnerID(metaPartnerID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all LoanToMetaPartner data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for LoanToMetaPartner items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.LoanToMetaPartner> GetAllLoanToMetaPartnerDataByMetaPartnerID(Guid metaPartnerID)
		{
			// perform main method tasks
			return BLL.Accounts.LoanToMetaPartnerManager.GetAllLoanToMetaPartnerDataByMetaPartnerID(metaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all LoanToMetaPartner data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for LoanToMetaPartner items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.LoanToMetaPartner> GetAllLoanToMetaPartnerDataByMetaPartnerID(Guid metaPartnerID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Accounts.LoanToMetaPartner> sortableList = new BLL.SortableList<BLL.Accounts.LoanToMetaPartner>(DAL.Accounts.LoanToMetaPartner.GetAllLoanToMetaPartnerDataByMetaPartnerID(metaPartnerID, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Accounts.LoanToMetaPartner loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetAllLoanToMetaPartnerDataByMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single LoanToMetaPartner by an index.</summary>
		///
		/// <param name="accountID">The index for LoanToMetaPartner to be fetched</param>
		/// <param name="metaPartnerID">The index for LoanToMetaPartner to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Accounts.LoanToMetaPartner GetOneLoanToMetaPartner(Guid accountID, Guid metaPartnerID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.LoanToMetaPartnerManager.GetOneLoanToMetaPartner(accountID, metaPartnerID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single LoanToMetaPartner by an index.</summary>
		///
		/// <param name="accountID">The index for LoanToMetaPartner to be fetched</param>
		/// <param name="metaPartnerID">The index for LoanToMetaPartner to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Accounts.LoanToMetaPartner GetOneLoanToMetaPartner(Guid accountID, Guid metaPartnerID)
		{
			// perform main method tasks
			return BLL.Accounts.LoanToMetaPartnerManager.GetOneLoanToMetaPartner(accountID, metaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single LoanToMetaPartner by an index.</summary>
		///
		/// <param name="accountID">The index for LoanToMetaPartner to be fetched</param>
		/// <param name="metaPartnerID">The index for LoanToMetaPartner to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Accounts.LoanToMetaPartner GetOneLoanToMetaPartner(Guid accountID, Guid metaPartnerID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.Accounts.LoanToMetaPartner itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.Accounts.LoanToMetaPartner)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.Accounts.LoanToMetaPartner.GetCacheKey(typeof(BLL.Accounts.LoanToMetaPartner), "PrimaryKey", accountID.ToString() + ", " + metaPartnerID.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.Accounts.LoanToMetaPartner)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.Accounts.LoanToMetaPartner item = DAL.Accounts.LoanToMetaPartner.GetOneLoanToMetaPartner(accountID, metaPartnerID, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.Accounts.LoanToMetaPartner();
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
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetOneLoanToMetaPartner");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates LoanToMetaPartner data.</summary>
		///
		/// <param name="item">The LoanToMetaPartner to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneLoanToMetaPartner(BLL.Accounts.LoanToMetaPartner item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Accounts.LoanToMetaPartnerManager.UpdateOneLoanToMetaPartner(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates LoanToMetaPartner data.</summary>
		///
		/// <param name="item">The LoanToMetaPartner to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneLoanToMetaPartner(BLL.Accounts.LoanToMetaPartner item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Accounts.LoanToMetaPartner itemDAL = new DAL.Accounts.LoanToMetaPartner();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Accounts.LoanToMetaPartner.UpdateOneLoanToMetaPartner(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.UpdateOneLoanToMetaPartner");
			}
		}
		#endregion Methods
	}
}