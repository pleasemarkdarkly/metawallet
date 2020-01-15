
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
	/// <summary>This class is used to manage FundAccount related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class FundAccountManager
	{
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public FundAccountManager()
		{
			//
			// constructor logic
			//
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------
		/// <summary>This method inserts FundAccount data.</summary>
		///
		/// <param name="item">The FundAccount to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneFundAccount(BLL.Accounts.FundAccount item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Accounts.FundAccountManager.AddOneFundAccount(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method inserts FundAccount data.</summary>
		///
		/// <param name="item">The FundAccount to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneFundAccount(BLL.Accounts.FundAccount item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Accounts.FundAccount itemDAL = new DAL.Accounts.FundAccount();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Accounts.FundAccount.AddOneFundAccount(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.AddOneFundAccount");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all FundAccount data by a key.</summary>
		///
		/// <param name="accountID">A key for FundAccount items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllFundAccountDataByAccountID(Guid accountID)
		{
			// perform main method tasks
			BLL.Accounts.FundAccountManager.DeleteAllFundAccountDataByAccountID(accountID, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all FundAccount data by a key.</summary>
		///
		/// <param name="accountID">A key for FundAccount items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllFundAccountDataByAccountID(Guid accountID, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Accounts.FundAccount.DeleteAllFundAccountDataByAccountID(accountID, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.DeleteAllFundAccountDataByAccountID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all FundAccount data by a key.</summary>
		///
		/// <param name="accountSubTypeCode">A key for FundAccount items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllFundAccountDataByAccountSubTypeCode(int accountSubTypeCode)
		{
			// perform main method tasks
			BLL.Accounts.FundAccountManager.DeleteAllFundAccountDataByAccountSubTypeCode(accountSubTypeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all FundAccount data by a key.</summary>
		///
		/// <param name="accountSubTypeCode">A key for FundAccount items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllFundAccountDataByAccountSubTypeCode(int accountSubTypeCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Accounts.FundAccount.DeleteAllFundAccountDataByAccountSubTypeCode(accountSubTypeCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.DeleteAllFundAccountDataByAccountSubTypeCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all FundAccount data by a key.</summary>
		///
		/// <param name="currencyCode">A key for FundAccount items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllFundAccountDataByCurrencyCode(int currencyCode)
		{
			// perform main method tasks
			BLL.Accounts.FundAccountManager.DeleteAllFundAccountDataByCurrencyCode(currencyCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all FundAccount data by a key.</summary>
		///
		/// <param name="currencyCode">A key for FundAccount items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllFundAccountDataByCurrencyCode(int currencyCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Accounts.FundAccount.DeleteAllFundAccountDataByCurrencyCode(currencyCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.DeleteAllFundAccountDataByCurrencyCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all FundAccount data by a key.</summary>
		///
		/// <param name="frequencyCode">A key for FundAccount items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllFundAccountDataByFrequencyCode(int frequencyCode)
		{
			// perform main method tasks
			BLL.Accounts.FundAccountManager.DeleteAllFundAccountDataByFrequencyCode(frequencyCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all FundAccount data by a key.</summary>
		///
		/// <param name="frequencyCode">A key for FundAccount items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllFundAccountDataByFrequencyCode(int frequencyCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Accounts.FundAccount.DeleteAllFundAccountDataByFrequencyCode(frequencyCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.DeleteAllFundAccountDataByFrequencyCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all FundAccount data by a key.</summary>
		///
		/// <param name="fundAccountTypeCode">A key for FundAccount items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllFundAccountDataByFundAccountTypeCode(int fundAccountTypeCode)
		{
			// perform main method tasks
			BLL.Accounts.FundAccountManager.DeleteAllFundAccountDataByFundAccountTypeCode(fundAccountTypeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all FundAccount data by a key.</summary>
		///
		/// <param name="fundAccountTypeCode">A key for FundAccount items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllFundAccountDataByFundAccountTypeCode(int fundAccountTypeCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Accounts.FundAccount.DeleteAllFundAccountDataByFundAccountTypeCode(fundAccountTypeCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.DeleteAllFundAccountDataByFundAccountTypeCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all FundAccount data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for FundAccount items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllFundAccountDataByMetaPartnerID(Guid metaPartnerID)
		{
			// perform main method tasks
			BLL.Accounts.FundAccountManager.DeleteAllFundAccountDataByMetaPartnerID(metaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all FundAccount data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for FundAccount items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllFundAccountDataByMetaPartnerID(Guid metaPartnerID, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Accounts.FundAccount.DeleteAllFundAccountDataByMetaPartnerID(metaPartnerID, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.DeleteAllFundAccountDataByMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes FundAccount data.</summary>
		///
		/// <param name="item">The FundAccount to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneFundAccount(BLL.Accounts.FundAccount item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Accounts.FundAccountManager.DeleteOneFundAccount(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes FundAccount data.</summary>
		///
		/// <param name="item">The FundAccount to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneFundAccount(BLL.Accounts.FundAccount item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Accounts.FundAccount itemDAL = new DAL.Accounts.FundAccount();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Accounts.FundAccount.DeleteOneFundAccount(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = false;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.DeleteOneFundAccount");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all FundAccount data.</summary>
		///
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.FundAccount> GetAllFundAccountData(MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.FundAccountManager.GetAllFundAccountData(BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all FundAccount data.</summary>
		///
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.FundAccount> GetAllFundAccountData()
		{
			// perform main method tasks
			return BLL.Accounts.FundAccountManager.GetAllFundAccountData(BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all FundAccount data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.FundAccount> GetAllFundAccountData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Accounts.FundAccount> sortableList = new BLL.SortableList<BLL.Accounts.FundAccount>(DAL.Accounts.FundAccount.GetAllFundAccountData(dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Accounts.FundAccount loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetAllFundAccountData");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all FundAccount data by a key.</summary>
		///
		/// <param name="accountID">A key for FundAccount items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.FundAccount> GetAllFundAccountDataByAccountID(Guid accountID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.FundAccountManager.GetAllFundAccountDataByAccountID(accountID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all FundAccount data by a key.</summary>
		///
		/// <param name="accountID">A key for FundAccount items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.FundAccount> GetAllFundAccountDataByAccountID(Guid accountID)
		{
			// perform main method tasks
			return BLL.Accounts.FundAccountManager.GetAllFundAccountDataByAccountID(accountID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all FundAccount data by a key.</summary>
		///
		/// <param name="accountID">A key for FundAccount items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.FundAccount> GetAllFundAccountDataByAccountID(Guid accountID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Accounts.FundAccount> sortableList = new BLL.SortableList<BLL.Accounts.FundAccount>(DAL.Accounts.FundAccount.GetAllFundAccountDataByAccountID(accountID, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Accounts.FundAccount loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetAllFundAccountDataByAccountID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all FundAccount data by a key.</summary>
		///
		/// <param name="accountSubTypeCode">A key for FundAccount items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.FundAccount> GetAllFundAccountDataByAccountSubTypeCode(int accountSubTypeCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.FundAccountManager.GetAllFundAccountDataByAccountSubTypeCode(accountSubTypeCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all FundAccount data by a key.</summary>
		///
		/// <param name="accountSubTypeCode">A key for FundAccount items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.FundAccount> GetAllFundAccountDataByAccountSubTypeCode(int accountSubTypeCode)
		{
			// perform main method tasks
			return BLL.Accounts.FundAccountManager.GetAllFundAccountDataByAccountSubTypeCode(accountSubTypeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all FundAccount data by a key.</summary>
		///
		/// <param name="accountSubTypeCode">A key for FundAccount items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.FundAccount> GetAllFundAccountDataByAccountSubTypeCode(int accountSubTypeCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Accounts.FundAccount> sortableList = new BLL.SortableList<BLL.Accounts.FundAccount>(DAL.Accounts.FundAccount.GetAllFundAccountDataByAccountSubTypeCode(accountSubTypeCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Accounts.FundAccount loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetAllFundAccountDataByAccountSubTypeCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all FundAccount data by criteria.</summary>
		///
		/// <param name="startDate">A key for FundAccount items to be fetched</param>
		/// <param name="endDate">A key for FundAccount items to be fetched</param>
		/// <param name="fundAccountTypeCode">A key for FundAccount items to be fetched</param>
		/// <param name="frequencyCode">A key for FundAccount items to be fetched</param>
		/// <param name="accountName">A key for FundAccount items to be fetched</param>
		/// <param name="currencyCode">A key for FundAccount items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for FundAccount items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for FundAccount items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.FundAccount> GetAllFundAccountDataByCriteria(DateTime? startDate, DateTime? endDate, int? fundAccountTypeCode, int? frequencyCode, string accountName, int? currencyCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.FundAccountManager.GetAllFundAccountDataByCriteria(startDate, endDate, fundAccountTypeCode, frequencyCode, accountName, currencyCode, lastModifiedDateStart, lastModifiedDateEnd, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all FundAccount data by criteria.</summary>
		///
		/// <param name="startDate">A key for FundAccount items to be fetched</param>
		/// <param name="endDate">A key for FundAccount items to be fetched</param>
		/// <param name="fundAccountTypeCode">A key for FundAccount items to be fetched</param>
		/// <param name="frequencyCode">A key for FundAccount items to be fetched</param>
		/// <param name="accountName">A key for FundAccount items to be fetched</param>
		/// <param name="currencyCode">A key for FundAccount items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for FundAccount items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for FundAccount items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.FundAccount> GetAllFundAccountDataByCriteria(DateTime? startDate, DateTime? endDate, int? fundAccountTypeCode, int? frequencyCode, string accountName, int? currencyCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd)
		{
			// perform main method tasks
			return BLL.Accounts.FundAccountManager.GetAllFundAccountDataByCriteria(startDate, endDate, fundAccountTypeCode, frequencyCode, accountName, currencyCode, lastModifiedDateStart, lastModifiedDateEnd, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all FundAccount data by criteria.</summary>
		///
		/// <param name="startDate">A key for FundAccount items to be fetched</param>
		/// <param name="endDate">A key for FundAccount items to be fetched</param>
		/// <param name="fundAccountTypeCode">A key for FundAccount items to be fetched</param>
		/// <param name="frequencyCode">A key for FundAccount items to be fetched</param>
		/// <param name="accountName">A key for FundAccount items to be fetched</param>
		/// <param name="currencyCode">A key for FundAccount items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for FundAccount items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for FundAccount items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.FundAccount> GetAllFundAccountDataByCriteria(DateTime? startDate, DateTime? endDate, int? fundAccountTypeCode, int? frequencyCode, string accountName, int? currencyCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Accounts.FundAccount> sortableList = new BLL.SortableList<BLL.Accounts.FundAccount>(DAL.Accounts.FundAccount.GetAllFundAccountDataByCriteria(startDate, endDate, fundAccountTypeCode, frequencyCode, accountName, currencyCode, lastModifiedDateStart, lastModifiedDateEnd, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Accounts.FundAccount loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetAllFundAccountDataByCriteria");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all FundAccount data by a key.</summary>
		///
		/// <param name="currencyCode">A key for FundAccount items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.FundAccount> GetAllFundAccountDataByCurrencyCode(int currencyCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.FundAccountManager.GetAllFundAccountDataByCurrencyCode(currencyCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all FundAccount data by a key.</summary>
		///
		/// <param name="currencyCode">A key for FundAccount items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.FundAccount> GetAllFundAccountDataByCurrencyCode(int currencyCode)
		{
			// perform main method tasks
			return BLL.Accounts.FundAccountManager.GetAllFundAccountDataByCurrencyCode(currencyCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all FundAccount data by a key.</summary>
		///
		/// <param name="currencyCode">A key for FundAccount items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.FundAccount> GetAllFundAccountDataByCurrencyCode(int currencyCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Accounts.FundAccount> sortableList = new BLL.SortableList<BLL.Accounts.FundAccount>(DAL.Accounts.FundAccount.GetAllFundAccountDataByCurrencyCode(currencyCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Accounts.FundAccount loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetAllFundAccountDataByCurrencyCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all FundAccount data by a key.</summary>
		///
		/// <param name="frequencyCode">A key for FundAccount items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.FundAccount> GetAllFundAccountDataByFrequencyCode(int frequencyCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.FundAccountManager.GetAllFundAccountDataByFrequencyCode(frequencyCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all FundAccount data by a key.</summary>
		///
		/// <param name="frequencyCode">A key for FundAccount items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.FundAccount> GetAllFundAccountDataByFrequencyCode(int frequencyCode)
		{
			// perform main method tasks
			return BLL.Accounts.FundAccountManager.GetAllFundAccountDataByFrequencyCode(frequencyCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all FundAccount data by a key.</summary>
		///
		/// <param name="frequencyCode">A key for FundAccount items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.FundAccount> GetAllFundAccountDataByFrequencyCode(int frequencyCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Accounts.FundAccount> sortableList = new BLL.SortableList<BLL.Accounts.FundAccount>(DAL.Accounts.FundAccount.GetAllFundAccountDataByFrequencyCode(frequencyCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Accounts.FundAccount loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetAllFundAccountDataByFrequencyCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all FundAccount data by a key.</summary>
		///
		/// <param name="fundAccountTypeCode">A key for FundAccount items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.FundAccount> GetAllFundAccountDataByFundAccountTypeCode(int fundAccountTypeCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.FundAccountManager.GetAllFundAccountDataByFundAccountTypeCode(fundAccountTypeCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all FundAccount data by a key.</summary>
		///
		/// <param name="fundAccountTypeCode">A key for FundAccount items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.FundAccount> GetAllFundAccountDataByFundAccountTypeCode(int fundAccountTypeCode)
		{
			// perform main method tasks
			return BLL.Accounts.FundAccountManager.GetAllFundAccountDataByFundAccountTypeCode(fundAccountTypeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all FundAccount data by a key.</summary>
		///
		/// <param name="fundAccountTypeCode">A key for FundAccount items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.FundAccount> GetAllFundAccountDataByFundAccountTypeCode(int fundAccountTypeCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Accounts.FundAccount> sortableList = new BLL.SortableList<BLL.Accounts.FundAccount>(DAL.Accounts.FundAccount.GetAllFundAccountDataByFundAccountTypeCode(fundAccountTypeCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Accounts.FundAccount loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetAllFundAccountDataByFundAccountTypeCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all FundAccount data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for FundAccount items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.FundAccount> GetAllFundAccountDataByMetaPartnerID(Guid metaPartnerID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.FundAccountManager.GetAllFundAccountDataByMetaPartnerID(metaPartnerID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all FundAccount data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for FundAccount items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.FundAccount> GetAllFundAccountDataByMetaPartnerID(Guid metaPartnerID)
		{
			// perform main method tasks
			return BLL.Accounts.FundAccountManager.GetAllFundAccountDataByMetaPartnerID(metaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all FundAccount data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for FundAccount items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.FundAccount> GetAllFundAccountDataByMetaPartnerID(Guid metaPartnerID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Accounts.FundAccount> sortableList = new BLL.SortableList<BLL.Accounts.FundAccount>(DAL.Accounts.FundAccount.GetAllFundAccountDataByMetaPartnerID(metaPartnerID, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Accounts.FundAccount loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetAllFundAccountDataByMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all FundAccount data by criteria.</summary>
		///
		/// <param name="startDate">A key for FundAccount items to be fetched</param>
		/// <param name="endDate">A key for FundAccount items to be fetched</param>
		/// <param name="fundAccountTypeCode">A key for FundAccount items to be fetched</param>
		/// <param name="frequencyCode">A key for FundAccount items to be fetched</param>
		/// <param name="accountName">A key for FundAccount items to be fetched</param>
		/// <param name="currencyCode">A key for FundAccount items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for FundAccount items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for FundAccount items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.FundAccount> GetManyFundAccountDataByCriteria(DateTime? startDate, DateTime? endDate, int? fundAccountTypeCode, int? frequencyCode, string accountName, int? currencyCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.FundAccountManager.GetManyFundAccountDataByCriteria(startDate, endDate, fundAccountTypeCode, frequencyCode, accountName, currencyCode, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all FundAccount data by criteria.</summary>
		///
		/// <param name="startDate">A key for FundAccount items to be fetched</param>
		/// <param name="endDate">A key for FundAccount items to be fetched</param>
		/// <param name="fundAccountTypeCode">A key for FundAccount items to be fetched</param>
		/// <param name="frequencyCode">A key for FundAccount items to be fetched</param>
		/// <param name="accountName">A key for FundAccount items to be fetched</param>
		/// <param name="currencyCode">A key for FundAccount items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for FundAccount items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for FundAccount items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.FundAccount> GetManyFundAccountDataByCriteria(DateTime? startDate, DateTime? endDate, int? fundAccountTypeCode, int? frequencyCode, string accountName, int? currencyCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Accounts.FundAccount> sortableList = new BLL.SortableList<BLL.Accounts.FundAccount>(DAL.Accounts.FundAccount.GetManyFundAccountDataByCriteria(startDate, endDate, fundAccountTypeCode, frequencyCode, accountName, currencyCode, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Accounts.FundAccount loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetManyFundAccountDataByCriteria");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single FundAccount by an index.</summary>
		///
		/// <param name="accountID">The index for FundAccount to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Accounts.FundAccount GetOneFundAccount(Guid accountID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.FundAccountManager.GetOneFundAccount(accountID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single FundAccount by an index.</summary>
		///
		/// <param name="accountID">The index for FundAccount to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Accounts.FundAccount GetOneFundAccount(Guid accountID)
		{
			// perform main method tasks
			return BLL.Accounts.FundAccountManager.GetOneFundAccount(accountID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single FundAccount by an index.</summary>
		///
		/// <param name="accountID">The index for FundAccount to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Accounts.FundAccount GetOneFundAccount(Guid accountID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.Accounts.FundAccount itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.Accounts.FundAccount)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.Accounts.FundAccount.GetCacheKey(typeof(BLL.Accounts.FundAccount), "PrimaryKey", accountID.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.Accounts.FundAccount)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.Accounts.FundAccount item = DAL.Accounts.FundAccount.GetOneFundAccount(accountID, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.Accounts.FundAccount();
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
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetOneFundAccount");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates FundAccount data.</summary>
		///
		/// <param name="item">The FundAccount to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneFundAccount(BLL.Accounts.FundAccount item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Accounts.FundAccountManager.UpdateOneFundAccount(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates FundAccount data.</summary>
		///
		/// <param name="item">The FundAccount to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneFundAccount(BLL.Accounts.FundAccount item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Accounts.FundAccount itemDAL = new DAL.Accounts.FundAccount();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Accounts.FundAccount.UpdateOneFundAccount(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.UpdateOneFundAccount");
			}
		}
		#endregion Methods
	}
}