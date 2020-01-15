
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
	/// <summary>This class is used to manage LoanAccount related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class LoanAccountManager
	{
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public LoanAccountManager()
		{
			//
			// constructor logic
			//
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------
		/// <summary>This method inserts LoanAccount data.</summary>
		///
		/// <param name="item">The LoanAccount to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneLoanAccount(BLL.Accounts.LoanAccount item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Accounts.LoanAccountManager.AddOneLoanAccount(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method inserts LoanAccount data.</summary>
		///
		/// <param name="item">The LoanAccount to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneLoanAccount(BLL.Accounts.LoanAccount item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Accounts.LoanAccount itemDAL = new DAL.Accounts.LoanAccount();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Accounts.LoanAccount.AddOneLoanAccount(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.AddOneLoanAccount");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all LoanAccount data by a key.</summary>
		///
		/// <param name="accountID">A key for LoanAccount items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllLoanAccountDataByAccountID(Guid accountID)
		{
			// perform main method tasks
			BLL.Accounts.LoanAccountManager.DeleteAllLoanAccountDataByAccountID(accountID, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all LoanAccount data by a key.</summary>
		///
		/// <param name="accountID">A key for LoanAccount items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllLoanAccountDataByAccountID(Guid accountID, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Accounts.LoanAccount.DeleteAllLoanAccountDataByAccountID(accountID, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.DeleteAllLoanAccountDataByAccountID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all LoanAccount data by a key.</summary>
		///
		/// <param name="accountSubTypeCode">A key for LoanAccount items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllLoanAccountDataByAccountSubTypeCode(int accountSubTypeCode)
		{
			// perform main method tasks
			BLL.Accounts.LoanAccountManager.DeleteAllLoanAccountDataByAccountSubTypeCode(accountSubTypeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all LoanAccount data by a key.</summary>
		///
		/// <param name="accountSubTypeCode">A key for LoanAccount items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllLoanAccountDataByAccountSubTypeCode(int accountSubTypeCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Accounts.LoanAccount.DeleteAllLoanAccountDataByAccountSubTypeCode(accountSubTypeCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.DeleteAllLoanAccountDataByAccountSubTypeCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all LoanAccount data by a key.</summary>
		///
		/// <param name="currencyCode">A key for LoanAccount items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllLoanAccountDataByCurrencyCode(int currencyCode)
		{
			// perform main method tasks
			BLL.Accounts.LoanAccountManager.DeleteAllLoanAccountDataByCurrencyCode(currencyCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all LoanAccount data by a key.</summary>
		///
		/// <param name="currencyCode">A key for LoanAccount items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllLoanAccountDataByCurrencyCode(int currencyCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Accounts.LoanAccount.DeleteAllLoanAccountDataByCurrencyCode(currencyCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.DeleteAllLoanAccountDataByCurrencyCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all LoanAccount data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for LoanAccount items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllLoanAccountDataByMetaPartnerID(Guid metaPartnerID)
		{
			// perform main method tasks
			BLL.Accounts.LoanAccountManager.DeleteAllLoanAccountDataByMetaPartnerID(metaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all LoanAccount data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for LoanAccount items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllLoanAccountDataByMetaPartnerID(Guid metaPartnerID, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Accounts.LoanAccount.DeleteAllLoanAccountDataByMetaPartnerID(metaPartnerID, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.DeleteAllLoanAccountDataByMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes LoanAccount data.</summary>
		///
		/// <param name="item">The LoanAccount to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneLoanAccount(BLL.Accounts.LoanAccount item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Accounts.LoanAccountManager.DeleteOneLoanAccount(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes LoanAccount data.</summary>
		///
		/// <param name="item">The LoanAccount to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneLoanAccount(BLL.Accounts.LoanAccount item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Accounts.LoanAccount itemDAL = new DAL.Accounts.LoanAccount();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Accounts.LoanAccount.DeleteOneLoanAccount(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = false;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.DeleteOneLoanAccount");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all LoanAccount data.</summary>
		///
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.LoanAccount> GetAllLoanAccountData(MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.LoanAccountManager.GetAllLoanAccountData(BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all LoanAccount data.</summary>
		///
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.LoanAccount> GetAllLoanAccountData()
		{
			// perform main method tasks
			return BLL.Accounts.LoanAccountManager.GetAllLoanAccountData(BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all LoanAccount data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.LoanAccount> GetAllLoanAccountData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Accounts.LoanAccount> sortableList = new BLL.SortableList<BLL.Accounts.LoanAccount>(DAL.Accounts.LoanAccount.GetAllLoanAccountData(dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Accounts.LoanAccount loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetAllLoanAccountData");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all LoanAccount data by a key.</summary>
		///
		/// <param name="accountID">A key for LoanAccount items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.LoanAccount> GetAllLoanAccountDataByAccountID(Guid accountID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.LoanAccountManager.GetAllLoanAccountDataByAccountID(accountID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all LoanAccount data by a key.</summary>
		///
		/// <param name="accountID">A key for LoanAccount items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.LoanAccount> GetAllLoanAccountDataByAccountID(Guid accountID)
		{
			// perform main method tasks
			return BLL.Accounts.LoanAccountManager.GetAllLoanAccountDataByAccountID(accountID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all LoanAccount data by a key.</summary>
		///
		/// <param name="accountID">A key for LoanAccount items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.LoanAccount> GetAllLoanAccountDataByAccountID(Guid accountID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Accounts.LoanAccount> sortableList = new BLL.SortableList<BLL.Accounts.LoanAccount>(DAL.Accounts.LoanAccount.GetAllLoanAccountDataByAccountID(accountID, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Accounts.LoanAccount loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetAllLoanAccountDataByAccountID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all LoanAccount data by a key.</summary>
		///
		/// <param name="accountSubTypeCode">A key for LoanAccount items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.LoanAccount> GetAllLoanAccountDataByAccountSubTypeCode(int accountSubTypeCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.LoanAccountManager.GetAllLoanAccountDataByAccountSubTypeCode(accountSubTypeCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all LoanAccount data by a key.</summary>
		///
		/// <param name="accountSubTypeCode">A key for LoanAccount items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.LoanAccount> GetAllLoanAccountDataByAccountSubTypeCode(int accountSubTypeCode)
		{
			// perform main method tasks
			return BLL.Accounts.LoanAccountManager.GetAllLoanAccountDataByAccountSubTypeCode(accountSubTypeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all LoanAccount data by a key.</summary>
		///
		/// <param name="accountSubTypeCode">A key for LoanAccount items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.LoanAccount> GetAllLoanAccountDataByAccountSubTypeCode(int accountSubTypeCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Accounts.LoanAccount> sortableList = new BLL.SortableList<BLL.Accounts.LoanAccount>(DAL.Accounts.LoanAccount.GetAllLoanAccountDataByAccountSubTypeCode(accountSubTypeCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Accounts.LoanAccount loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetAllLoanAccountDataByAccountSubTypeCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all LoanAccount data by criteria.</summary>
		///
		/// <param name="dueDateStart">A key for LoanAccount items to be fetched</param>
		/// <param name="dueDateEnd">A key for LoanAccount items to be fetched</param>
		/// <param name="accountName">A key for LoanAccount items to be fetched</param>
		/// <param name="currencyCode">A key for LoanAccount items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for LoanAccount items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for LoanAccount items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.LoanAccount> GetAllLoanAccountDataByCriteria(DateTime? dueDateStart, DateTime? dueDateEnd, string accountName, int? currencyCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.LoanAccountManager.GetAllLoanAccountDataByCriteria(dueDateStart, dueDateEnd, accountName, currencyCode, lastModifiedDateStart, lastModifiedDateEnd, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all LoanAccount data by criteria.</summary>
		///
		/// <param name="dueDateStart">A key for LoanAccount items to be fetched</param>
		/// <param name="dueDateEnd">A key for LoanAccount items to be fetched</param>
		/// <param name="accountName">A key for LoanAccount items to be fetched</param>
		/// <param name="currencyCode">A key for LoanAccount items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for LoanAccount items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for LoanAccount items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.LoanAccount> GetAllLoanAccountDataByCriteria(DateTime? dueDateStart, DateTime? dueDateEnd, string accountName, int? currencyCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd)
		{
			// perform main method tasks
			return BLL.Accounts.LoanAccountManager.GetAllLoanAccountDataByCriteria(dueDateStart, dueDateEnd, accountName, currencyCode, lastModifiedDateStart, lastModifiedDateEnd, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all LoanAccount data by criteria.</summary>
		///
		/// <param name="dueDateStart">A key for LoanAccount items to be fetched</param>
		/// <param name="dueDateEnd">A key for LoanAccount items to be fetched</param>
		/// <param name="accountName">A key for LoanAccount items to be fetched</param>
		/// <param name="currencyCode">A key for LoanAccount items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for LoanAccount items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for LoanAccount items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.LoanAccount> GetAllLoanAccountDataByCriteria(DateTime? dueDateStart, DateTime? dueDateEnd, string accountName, int? currencyCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Accounts.LoanAccount> sortableList = new BLL.SortableList<BLL.Accounts.LoanAccount>(DAL.Accounts.LoanAccount.GetAllLoanAccountDataByCriteria(dueDateStart, dueDateEnd, accountName, currencyCode, lastModifiedDateStart, lastModifiedDateEnd, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Accounts.LoanAccount loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetAllLoanAccountDataByCriteria");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all LoanAccount data by a key.</summary>
		///
		/// <param name="currencyCode">A key for LoanAccount items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.LoanAccount> GetAllLoanAccountDataByCurrencyCode(int currencyCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.LoanAccountManager.GetAllLoanAccountDataByCurrencyCode(currencyCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all LoanAccount data by a key.</summary>
		///
		/// <param name="currencyCode">A key for LoanAccount items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.LoanAccount> GetAllLoanAccountDataByCurrencyCode(int currencyCode)
		{
			// perform main method tasks
			return BLL.Accounts.LoanAccountManager.GetAllLoanAccountDataByCurrencyCode(currencyCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all LoanAccount data by a key.</summary>
		///
		/// <param name="currencyCode">A key for LoanAccount items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.LoanAccount> GetAllLoanAccountDataByCurrencyCode(int currencyCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Accounts.LoanAccount> sortableList = new BLL.SortableList<BLL.Accounts.LoanAccount>(DAL.Accounts.LoanAccount.GetAllLoanAccountDataByCurrencyCode(currencyCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Accounts.LoanAccount loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetAllLoanAccountDataByCurrencyCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all LoanAccount data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for LoanAccount items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.LoanAccount> GetAllLoanAccountDataByMetaPartnerID(Guid metaPartnerID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.LoanAccountManager.GetAllLoanAccountDataByMetaPartnerID(metaPartnerID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all LoanAccount data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for LoanAccount items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.LoanAccount> GetAllLoanAccountDataByMetaPartnerID(Guid metaPartnerID)
		{
			// perform main method tasks
			return BLL.Accounts.LoanAccountManager.GetAllLoanAccountDataByMetaPartnerID(metaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all LoanAccount data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for LoanAccount items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.LoanAccount> GetAllLoanAccountDataByMetaPartnerID(Guid metaPartnerID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Accounts.LoanAccount> sortableList = new BLL.SortableList<BLL.Accounts.LoanAccount>(DAL.Accounts.LoanAccount.GetAllLoanAccountDataByMetaPartnerID(metaPartnerID, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Accounts.LoanAccount loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetAllLoanAccountDataByMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all LoanAccount data by criteria.</summary>
		///
		/// <param name="dueDateStart">A key for LoanAccount items to be fetched</param>
		/// <param name="dueDateEnd">A key for LoanAccount items to be fetched</param>
		/// <param name="accountName">A key for LoanAccount items to be fetched</param>
		/// <param name="currencyCode">A key for LoanAccount items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for LoanAccount items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for LoanAccount items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.LoanAccount> GetManyLoanAccountDataByCriteria(DateTime? dueDateStart, DateTime? dueDateEnd, string accountName, int? currencyCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.LoanAccountManager.GetManyLoanAccountDataByCriteria(dueDateStart, dueDateEnd, accountName, currencyCode, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all LoanAccount data by criteria.</summary>
		///
		/// <param name="dueDateStart">A key for LoanAccount items to be fetched</param>
		/// <param name="dueDateEnd">A key for LoanAccount items to be fetched</param>
		/// <param name="accountName">A key for LoanAccount items to be fetched</param>
		/// <param name="currencyCode">A key for LoanAccount items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for LoanAccount items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for LoanAccount items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.LoanAccount> GetManyLoanAccountDataByCriteria(DateTime? dueDateStart, DateTime? dueDateEnd, string accountName, int? currencyCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Accounts.LoanAccount> sortableList = new BLL.SortableList<BLL.Accounts.LoanAccount>(DAL.Accounts.LoanAccount.GetManyLoanAccountDataByCriteria(dueDateStart, dueDateEnd, accountName, currencyCode, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Accounts.LoanAccount loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetManyLoanAccountDataByCriteria");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single LoanAccount by an index.</summary>
		///
		/// <param name="accountID">The index for LoanAccount to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Accounts.LoanAccount GetOneLoanAccount(Guid accountID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.LoanAccountManager.GetOneLoanAccount(accountID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single LoanAccount by an index.</summary>
		///
		/// <param name="accountID">The index for LoanAccount to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Accounts.LoanAccount GetOneLoanAccount(Guid accountID)
		{
			// perform main method tasks
			return BLL.Accounts.LoanAccountManager.GetOneLoanAccount(accountID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single LoanAccount by an index.</summary>
		///
		/// <param name="accountID">The index for LoanAccount to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Accounts.LoanAccount GetOneLoanAccount(Guid accountID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.Accounts.LoanAccount itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.Accounts.LoanAccount)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.Accounts.LoanAccount.GetCacheKey(typeof(BLL.Accounts.LoanAccount), "PrimaryKey", accountID.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.Accounts.LoanAccount)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.Accounts.LoanAccount item = DAL.Accounts.LoanAccount.GetOneLoanAccount(accountID, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.Accounts.LoanAccount();
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
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetOneLoanAccount");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates LoanAccount data.</summary>
		///
		/// <param name="item">The LoanAccount to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneLoanAccount(BLL.Accounts.LoanAccount item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Accounts.LoanAccountManager.UpdateOneLoanAccount(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates LoanAccount data.</summary>
		///
		/// <param name="item">The LoanAccount to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneLoanAccount(BLL.Accounts.LoanAccount item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Accounts.LoanAccount itemDAL = new DAL.Accounts.LoanAccount();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Accounts.LoanAccount.UpdateOneLoanAccount(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.UpdateOneLoanAccount");
			}
		}
		#endregion Methods
	}
}