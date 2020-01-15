
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
	/// <summary>This class is used to manage StoredValueAccount related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class StoredValueAccountManager
	{
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public StoredValueAccountManager()
		{
			//
			// constructor logic
			//
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------
		/// <summary>This method inserts StoredValueAccount data.</summary>
		///
		/// <param name="item">The StoredValueAccount to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneStoredValueAccount(BLL.Accounts.StoredValueAccount item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Accounts.StoredValueAccountManager.AddOneStoredValueAccount(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method inserts StoredValueAccount data.</summary>
		///
		/// <param name="item">The StoredValueAccount to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneStoredValueAccount(BLL.Accounts.StoredValueAccount item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Accounts.StoredValueAccount itemDAL = new DAL.Accounts.StoredValueAccount();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Accounts.StoredValueAccount.AddOneStoredValueAccount(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.AddOneStoredValueAccount");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all StoredValueAccount data by a key.</summary>
		///
		/// <param name="accountID">A key for StoredValueAccount items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllStoredValueAccountDataByAccountID(Guid accountID)
		{
			// perform main method tasks
			BLL.Accounts.StoredValueAccountManager.DeleteAllStoredValueAccountDataByAccountID(accountID, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all StoredValueAccount data by a key.</summary>
		///
		/// <param name="accountID">A key for StoredValueAccount items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllStoredValueAccountDataByAccountID(Guid accountID, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Accounts.StoredValueAccount.DeleteAllStoredValueAccountDataByAccountID(accountID, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.DeleteAllStoredValueAccountDataByAccountID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all StoredValueAccount data by a key.</summary>
		///
		/// <param name="accountSubTypeCode">A key for StoredValueAccount items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllStoredValueAccountDataByAccountSubTypeCode(int accountSubTypeCode)
		{
			// perform main method tasks
			BLL.Accounts.StoredValueAccountManager.DeleteAllStoredValueAccountDataByAccountSubTypeCode(accountSubTypeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all StoredValueAccount data by a key.</summary>
		///
		/// <param name="accountSubTypeCode">A key for StoredValueAccount items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllStoredValueAccountDataByAccountSubTypeCode(int accountSubTypeCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Accounts.StoredValueAccount.DeleteAllStoredValueAccountDataByAccountSubTypeCode(accountSubTypeCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.DeleteAllStoredValueAccountDataByAccountSubTypeCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all StoredValueAccount data by a key.</summary>
		///
		/// <param name="currencyCode">A key for StoredValueAccount items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllStoredValueAccountDataByCurrencyCode(int currencyCode)
		{
			// perform main method tasks
			BLL.Accounts.StoredValueAccountManager.DeleteAllStoredValueAccountDataByCurrencyCode(currencyCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all StoredValueAccount data by a key.</summary>
		///
		/// <param name="currencyCode">A key for StoredValueAccount items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllStoredValueAccountDataByCurrencyCode(int currencyCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Accounts.StoredValueAccount.DeleteAllStoredValueAccountDataByCurrencyCode(currencyCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.DeleteAllStoredValueAccountDataByCurrencyCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all StoredValueAccount data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for StoredValueAccount items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllStoredValueAccountDataByMetaPartnerID(Guid metaPartnerID)
		{
			// perform main method tasks
			BLL.Accounts.StoredValueAccountManager.DeleteAllStoredValueAccountDataByMetaPartnerID(metaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all StoredValueAccount data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for StoredValueAccount items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllStoredValueAccountDataByMetaPartnerID(Guid metaPartnerID, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Accounts.StoredValueAccount.DeleteAllStoredValueAccountDataByMetaPartnerID(metaPartnerID, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.DeleteAllStoredValueAccountDataByMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all StoredValueAccount data by a key.</summary>
		///
		/// <param name="metaPartnerPhoneID">A key for StoredValueAccount items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllStoredValueAccountDataByMetaPartnerPhoneID(Guid metaPartnerPhoneID)
		{
			// perform main method tasks
			BLL.Accounts.StoredValueAccountManager.DeleteAllStoredValueAccountDataByMetaPartnerPhoneID(metaPartnerPhoneID, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all StoredValueAccount data by a key.</summary>
		///
		/// <param name="metaPartnerPhoneID">A key for StoredValueAccount items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllStoredValueAccountDataByMetaPartnerPhoneID(Guid metaPartnerPhoneID, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Accounts.StoredValueAccount.DeleteAllStoredValueAccountDataByMetaPartnerPhoneID(metaPartnerPhoneID, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.DeleteAllStoredValueAccountDataByMetaPartnerPhoneID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes StoredValueAccount data.</summary>
		///
		/// <param name="item">The StoredValueAccount to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneStoredValueAccount(BLL.Accounts.StoredValueAccount item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Accounts.StoredValueAccountManager.DeleteOneStoredValueAccount(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes StoredValueAccount data.</summary>
		///
		/// <param name="item">The StoredValueAccount to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneStoredValueAccount(BLL.Accounts.StoredValueAccount item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Accounts.StoredValueAccount itemDAL = new DAL.Accounts.StoredValueAccount();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Accounts.StoredValueAccount.DeleteOneStoredValueAccount(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = false;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.DeleteOneStoredValueAccount");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all StoredValueAccount data.</summary>
		///
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.StoredValueAccount> GetAllStoredValueAccountData(MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.StoredValueAccountManager.GetAllStoredValueAccountData(BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all StoredValueAccount data.</summary>
		///
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.StoredValueAccount> GetAllStoredValueAccountData()
		{
			// perform main method tasks
			return BLL.Accounts.StoredValueAccountManager.GetAllStoredValueAccountData(BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all StoredValueAccount data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.StoredValueAccount> GetAllStoredValueAccountData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Accounts.StoredValueAccount> sortableList = new BLL.SortableList<BLL.Accounts.StoredValueAccount>(DAL.Accounts.StoredValueAccount.GetAllStoredValueAccountData(dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Accounts.StoredValueAccount loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetAllStoredValueAccountData");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all StoredValueAccount data by a key.</summary>
		///
		/// <param name="accountID">A key for StoredValueAccount items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.StoredValueAccount> GetAllStoredValueAccountDataByAccountID(Guid accountID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.StoredValueAccountManager.GetAllStoredValueAccountDataByAccountID(accountID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all StoredValueAccount data by a key.</summary>
		///
		/// <param name="accountID">A key for StoredValueAccount items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.StoredValueAccount> GetAllStoredValueAccountDataByAccountID(Guid accountID)
		{
			// perform main method tasks
			return BLL.Accounts.StoredValueAccountManager.GetAllStoredValueAccountDataByAccountID(accountID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all StoredValueAccount data by a key.</summary>
		///
		/// <param name="accountID">A key for StoredValueAccount items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.StoredValueAccount> GetAllStoredValueAccountDataByAccountID(Guid accountID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Accounts.StoredValueAccount> sortableList = new BLL.SortableList<BLL.Accounts.StoredValueAccount>(DAL.Accounts.StoredValueAccount.GetAllStoredValueAccountDataByAccountID(accountID, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Accounts.StoredValueAccount loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetAllStoredValueAccountDataByAccountID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all StoredValueAccount data by a key.</summary>
		///
		/// <param name="accountSubTypeCode">A key for StoredValueAccount items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.StoredValueAccount> GetAllStoredValueAccountDataByAccountSubTypeCode(int accountSubTypeCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.StoredValueAccountManager.GetAllStoredValueAccountDataByAccountSubTypeCode(accountSubTypeCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all StoredValueAccount data by a key.</summary>
		///
		/// <param name="accountSubTypeCode">A key for StoredValueAccount items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.StoredValueAccount> GetAllStoredValueAccountDataByAccountSubTypeCode(int accountSubTypeCode)
		{
			// perform main method tasks
			return BLL.Accounts.StoredValueAccountManager.GetAllStoredValueAccountDataByAccountSubTypeCode(accountSubTypeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all StoredValueAccount data by a key.</summary>
		///
		/// <param name="accountSubTypeCode">A key for StoredValueAccount items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.StoredValueAccount> GetAllStoredValueAccountDataByAccountSubTypeCode(int accountSubTypeCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Accounts.StoredValueAccount> sortableList = new BLL.SortableList<BLL.Accounts.StoredValueAccount>(DAL.Accounts.StoredValueAccount.GetAllStoredValueAccountDataByAccountSubTypeCode(accountSubTypeCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Accounts.StoredValueAccount loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetAllStoredValueAccountDataByAccountSubTypeCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all StoredValueAccount data by criteria.</summary>
		///
		/// <param name="debitAccountNumber">A key for StoredValueAccount items to be fetched</param>
		/// <param name="accountName">A key for StoredValueAccount items to be fetched</param>
		/// <param name="currencyCode">A key for StoredValueAccount items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for StoredValueAccount items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for StoredValueAccount items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.StoredValueAccount> GetAllStoredValueAccountDataByCriteria(string debitAccountNumber, string accountName, int? currencyCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.StoredValueAccountManager.GetAllStoredValueAccountDataByCriteria(debitAccountNumber, accountName, currencyCode, lastModifiedDateStart, lastModifiedDateEnd, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all StoredValueAccount data by criteria.</summary>
		///
		/// <param name="debitAccountNumber">A key for StoredValueAccount items to be fetched</param>
		/// <param name="accountName">A key for StoredValueAccount items to be fetched</param>
		/// <param name="currencyCode">A key for StoredValueAccount items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for StoredValueAccount items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for StoredValueAccount items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.StoredValueAccount> GetAllStoredValueAccountDataByCriteria(string debitAccountNumber, string accountName, int? currencyCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd)
		{
			// perform main method tasks
			return BLL.Accounts.StoredValueAccountManager.GetAllStoredValueAccountDataByCriteria(debitAccountNumber, accountName, currencyCode, lastModifiedDateStart, lastModifiedDateEnd, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all StoredValueAccount data by criteria.</summary>
		///
		/// <param name="debitAccountNumber">A key for StoredValueAccount items to be fetched</param>
		/// <param name="accountName">A key for StoredValueAccount items to be fetched</param>
		/// <param name="currencyCode">A key for StoredValueAccount items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for StoredValueAccount items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for StoredValueAccount items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.StoredValueAccount> GetAllStoredValueAccountDataByCriteria(string debitAccountNumber, string accountName, int? currencyCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Accounts.StoredValueAccount> sortableList = new BLL.SortableList<BLL.Accounts.StoredValueAccount>(DAL.Accounts.StoredValueAccount.GetAllStoredValueAccountDataByCriteria(debitAccountNumber, accountName, currencyCode, lastModifiedDateStart, lastModifiedDateEnd, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Accounts.StoredValueAccount loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetAllStoredValueAccountDataByCriteria");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all StoredValueAccount data by a key.</summary>
		///
		/// <param name="currencyCode">A key for StoredValueAccount items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.StoredValueAccount> GetAllStoredValueAccountDataByCurrencyCode(int currencyCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.StoredValueAccountManager.GetAllStoredValueAccountDataByCurrencyCode(currencyCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all StoredValueAccount data by a key.</summary>
		///
		/// <param name="currencyCode">A key for StoredValueAccount items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.StoredValueAccount> GetAllStoredValueAccountDataByCurrencyCode(int currencyCode)
		{
			// perform main method tasks
			return BLL.Accounts.StoredValueAccountManager.GetAllStoredValueAccountDataByCurrencyCode(currencyCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all StoredValueAccount data by a key.</summary>
		///
		/// <param name="currencyCode">A key for StoredValueAccount items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.StoredValueAccount> GetAllStoredValueAccountDataByCurrencyCode(int currencyCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Accounts.StoredValueAccount> sortableList = new BLL.SortableList<BLL.Accounts.StoredValueAccount>(DAL.Accounts.StoredValueAccount.GetAllStoredValueAccountDataByCurrencyCode(currencyCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Accounts.StoredValueAccount loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetAllStoredValueAccountDataByCurrencyCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all StoredValueAccount data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for StoredValueAccount items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.StoredValueAccount> GetAllStoredValueAccountDataByMetaPartnerID(Guid metaPartnerID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.StoredValueAccountManager.GetAllStoredValueAccountDataByMetaPartnerID(metaPartnerID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all StoredValueAccount data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for StoredValueAccount items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.StoredValueAccount> GetAllStoredValueAccountDataByMetaPartnerID(Guid metaPartnerID)
		{
			// perform main method tasks
			return BLL.Accounts.StoredValueAccountManager.GetAllStoredValueAccountDataByMetaPartnerID(metaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all StoredValueAccount data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for StoredValueAccount items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.StoredValueAccount> GetAllStoredValueAccountDataByMetaPartnerID(Guid metaPartnerID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Accounts.StoredValueAccount> sortableList = new BLL.SortableList<BLL.Accounts.StoredValueAccount>(DAL.Accounts.StoredValueAccount.GetAllStoredValueAccountDataByMetaPartnerID(metaPartnerID, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Accounts.StoredValueAccount loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetAllStoredValueAccountDataByMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all StoredValueAccount data by a key.</summary>
		///
		/// <param name="metaPartnerPhoneID">A key for StoredValueAccount items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.StoredValueAccount> GetAllStoredValueAccountDataByMetaPartnerPhoneID(Guid metaPartnerPhoneID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.StoredValueAccountManager.GetAllStoredValueAccountDataByMetaPartnerPhoneID(metaPartnerPhoneID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all StoredValueAccount data by a key.</summary>
		///
		/// <param name="metaPartnerPhoneID">A key for StoredValueAccount items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.StoredValueAccount> GetAllStoredValueAccountDataByMetaPartnerPhoneID(Guid metaPartnerPhoneID)
		{
			// perform main method tasks
			return BLL.Accounts.StoredValueAccountManager.GetAllStoredValueAccountDataByMetaPartnerPhoneID(metaPartnerPhoneID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all StoredValueAccount data by a key.</summary>
		///
		/// <param name="metaPartnerPhoneID">A key for StoredValueAccount items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.StoredValueAccount> GetAllStoredValueAccountDataByMetaPartnerPhoneID(Guid metaPartnerPhoneID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Accounts.StoredValueAccount> sortableList = new BLL.SortableList<BLL.Accounts.StoredValueAccount>(DAL.Accounts.StoredValueAccount.GetAllStoredValueAccountDataByMetaPartnerPhoneID(metaPartnerPhoneID, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Accounts.StoredValueAccount loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetAllStoredValueAccountDataByMetaPartnerPhoneID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all StoredValueAccount data by criteria.</summary>
		///
		/// <param name="debitAccountNumber">A key for StoredValueAccount items to be fetched</param>
		/// <param name="accountName">A key for StoredValueAccount items to be fetched</param>
		/// <param name="currencyCode">A key for StoredValueAccount items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for StoredValueAccount items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for StoredValueAccount items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.StoredValueAccount> GetManyStoredValueAccountDataByCriteria(string debitAccountNumber, string accountName, int? currencyCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.StoredValueAccountManager.GetManyStoredValueAccountDataByCriteria(debitAccountNumber, accountName, currencyCode, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all StoredValueAccount data by criteria.</summary>
		///
		/// <param name="debitAccountNumber">A key for StoredValueAccount items to be fetched</param>
		/// <param name="accountName">A key for StoredValueAccount items to be fetched</param>
		/// <param name="currencyCode">A key for StoredValueAccount items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for StoredValueAccount items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for StoredValueAccount items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.StoredValueAccount> GetManyStoredValueAccountDataByCriteria(string debitAccountNumber, string accountName, int? currencyCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Accounts.StoredValueAccount> sortableList = new BLL.SortableList<BLL.Accounts.StoredValueAccount>(DAL.Accounts.StoredValueAccount.GetManyStoredValueAccountDataByCriteria(debitAccountNumber, accountName, currencyCode, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Accounts.StoredValueAccount loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetManyStoredValueAccountDataByCriteria");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single StoredValueAccount by an index.</summary>
		///
		/// <param name="accountID">The index for StoredValueAccount to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Accounts.StoredValueAccount GetOneStoredValueAccount(Guid accountID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.StoredValueAccountManager.GetOneStoredValueAccount(accountID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single StoredValueAccount by an index.</summary>
		///
		/// <param name="accountID">The index for StoredValueAccount to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Accounts.StoredValueAccount GetOneStoredValueAccount(Guid accountID)
		{
			// perform main method tasks
			return BLL.Accounts.StoredValueAccountManager.GetOneStoredValueAccount(accountID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single StoredValueAccount by an index.</summary>
		///
		/// <param name="accountID">The index for StoredValueAccount to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Accounts.StoredValueAccount GetOneStoredValueAccount(Guid accountID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.Accounts.StoredValueAccount itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.Accounts.StoredValueAccount)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.Accounts.StoredValueAccount.GetCacheKey(typeof(BLL.Accounts.StoredValueAccount), "PrimaryKey", accountID.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.Accounts.StoredValueAccount)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.Accounts.StoredValueAccount item = DAL.Accounts.StoredValueAccount.GetOneStoredValueAccount(accountID, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.Accounts.StoredValueAccount();
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
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetOneStoredValueAccount");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates StoredValueAccount data.</summary>
		///
		/// <param name="item">The StoredValueAccount to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneStoredValueAccount(BLL.Accounts.StoredValueAccount item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Accounts.StoredValueAccountManager.UpdateOneStoredValueAccount(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates StoredValueAccount data.</summary>
		///
		/// <param name="item">The StoredValueAccount to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneStoredValueAccount(BLL.Accounts.StoredValueAccount item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Accounts.StoredValueAccount itemDAL = new DAL.Accounts.StoredValueAccount();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Accounts.StoredValueAccount.UpdateOneStoredValueAccount(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.UpdateOneStoredValueAccount");
			}
		}
		#endregion Methods
	}
}