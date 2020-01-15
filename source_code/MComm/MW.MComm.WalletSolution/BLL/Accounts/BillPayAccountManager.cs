
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
	/// <summary>This class is used to manage BillPayAccount related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class BillPayAccountManager
	{
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public BillPayAccountManager()
		{
			//
			// constructor logic
			//
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------
		/// <summary>This method inserts BillPayAccount data.</summary>
		///
		/// <param name="item">The BillPayAccount to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneBillPayAccount(BLL.Accounts.BillPayAccount item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Accounts.BillPayAccountManager.AddOneBillPayAccount(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method inserts BillPayAccount data.</summary>
		///
		/// <param name="item">The BillPayAccount to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneBillPayAccount(BLL.Accounts.BillPayAccount item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Accounts.BillPayAccount itemDAL = new DAL.Accounts.BillPayAccount();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Accounts.BillPayAccount.AddOneBillPayAccount(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.AddOneBillPayAccount");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all BillPayAccount data by a key.</summary>
		///
		/// <param name="accountID">A key for BillPayAccount items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllBillPayAccountDataByAccountID(Guid accountID)
		{
			// perform main method tasks
			BLL.Accounts.BillPayAccountManager.DeleteAllBillPayAccountDataByAccountID(accountID, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all BillPayAccount data by a key.</summary>
		///
		/// <param name="accountID">A key for BillPayAccount items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllBillPayAccountDataByAccountID(Guid accountID, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Accounts.BillPayAccount.DeleteAllBillPayAccountDataByAccountID(accountID, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.DeleteAllBillPayAccountDataByAccountID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all BillPayAccount data by a key.</summary>
		///
		/// <param name="accountSubTypeCode">A key for BillPayAccount items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllBillPayAccountDataByAccountSubTypeCode(int accountSubTypeCode)
		{
			// perform main method tasks
			BLL.Accounts.BillPayAccountManager.DeleteAllBillPayAccountDataByAccountSubTypeCode(accountSubTypeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all BillPayAccount data by a key.</summary>
		///
		/// <param name="accountSubTypeCode">A key for BillPayAccount items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllBillPayAccountDataByAccountSubTypeCode(int accountSubTypeCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Accounts.BillPayAccount.DeleteAllBillPayAccountDataByAccountSubTypeCode(accountSubTypeCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.DeleteAllBillPayAccountDataByAccountSubTypeCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all BillPayAccount data by a key.</summary>
		///
		/// <param name="businessMetaPartnerID">A key for BillPayAccount items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllBillPayAccountDataByBusinessMetaPartnerID(Guid businessMetaPartnerID)
		{
			// perform main method tasks
			BLL.Accounts.BillPayAccountManager.DeleteAllBillPayAccountDataByBusinessMetaPartnerID(businessMetaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all BillPayAccount data by a key.</summary>
		///
		/// <param name="businessMetaPartnerID">A key for BillPayAccount items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllBillPayAccountDataByBusinessMetaPartnerID(Guid businessMetaPartnerID, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Accounts.BillPayAccount.DeleteAllBillPayAccountDataByBusinessMetaPartnerID(businessMetaPartnerID, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.DeleteAllBillPayAccountDataByBusinessMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all BillPayAccount data by a key.</summary>
		///
		/// <param name="currencyCode">A key for BillPayAccount items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllBillPayAccountDataByCurrencyCode(int currencyCode)
		{
			// perform main method tasks
			BLL.Accounts.BillPayAccountManager.DeleteAllBillPayAccountDataByCurrencyCode(currencyCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all BillPayAccount data by a key.</summary>
		///
		/// <param name="currencyCode">A key for BillPayAccount items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllBillPayAccountDataByCurrencyCode(int currencyCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Accounts.BillPayAccount.DeleteAllBillPayAccountDataByCurrencyCode(currencyCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.DeleteAllBillPayAccountDataByCurrencyCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all BillPayAccount data by a key.</summary>
		///
		/// <param name="frequencyCode">A key for BillPayAccount items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllBillPayAccountDataByFrequencyCode(int frequencyCode)
		{
			// perform main method tasks
			BLL.Accounts.BillPayAccountManager.DeleteAllBillPayAccountDataByFrequencyCode(frequencyCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all BillPayAccount data by a key.</summary>
		///
		/// <param name="frequencyCode">A key for BillPayAccount items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllBillPayAccountDataByFrequencyCode(int frequencyCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Accounts.BillPayAccount.DeleteAllBillPayAccountDataByFrequencyCode(frequencyCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.DeleteAllBillPayAccountDataByFrequencyCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all BillPayAccount data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for BillPayAccount items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllBillPayAccountDataByMetaPartnerID(Guid metaPartnerID)
		{
			// perform main method tasks
			BLL.Accounts.BillPayAccountManager.DeleteAllBillPayAccountDataByMetaPartnerID(metaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all BillPayAccount data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for BillPayAccount items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllBillPayAccountDataByMetaPartnerID(Guid metaPartnerID, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Accounts.BillPayAccount.DeleteAllBillPayAccountDataByMetaPartnerID(metaPartnerID, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.DeleteAllBillPayAccountDataByMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes BillPayAccount data.</summary>
		///
		/// <param name="item">The BillPayAccount to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneBillPayAccount(BLL.Accounts.BillPayAccount item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Accounts.BillPayAccountManager.DeleteOneBillPayAccount(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes BillPayAccount data.</summary>
		///
		/// <param name="item">The BillPayAccount to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneBillPayAccount(BLL.Accounts.BillPayAccount item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Accounts.BillPayAccount itemDAL = new DAL.Accounts.BillPayAccount();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Accounts.BillPayAccount.DeleteOneBillPayAccount(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = false;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.DeleteOneBillPayAccount");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all BillPayAccount data.</summary>
		///
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.BillPayAccount> GetAllBillPayAccountData(MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.BillPayAccountManager.GetAllBillPayAccountData(BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all BillPayAccount data.</summary>
		///
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.BillPayAccount> GetAllBillPayAccountData()
		{
			// perform main method tasks
			return BLL.Accounts.BillPayAccountManager.GetAllBillPayAccountData(BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all BillPayAccount data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.BillPayAccount> GetAllBillPayAccountData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Accounts.BillPayAccount> sortableList = new BLL.SortableList<BLL.Accounts.BillPayAccount>(DAL.Accounts.BillPayAccount.GetAllBillPayAccountData(dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Accounts.BillPayAccount loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetAllBillPayAccountData");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all BillPayAccount data by a key.</summary>
		///
		/// <param name="accountID">A key for BillPayAccount items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.BillPayAccount> GetAllBillPayAccountDataByAccountID(Guid accountID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.BillPayAccountManager.GetAllBillPayAccountDataByAccountID(accountID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all BillPayAccount data by a key.</summary>
		///
		/// <param name="accountID">A key for BillPayAccount items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.BillPayAccount> GetAllBillPayAccountDataByAccountID(Guid accountID)
		{
			// perform main method tasks
			return BLL.Accounts.BillPayAccountManager.GetAllBillPayAccountDataByAccountID(accountID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all BillPayAccount data by a key.</summary>
		///
		/// <param name="accountID">A key for BillPayAccount items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.BillPayAccount> GetAllBillPayAccountDataByAccountID(Guid accountID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Accounts.BillPayAccount> sortableList = new BLL.SortableList<BLL.Accounts.BillPayAccount>(DAL.Accounts.BillPayAccount.GetAllBillPayAccountDataByAccountID(accountID, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Accounts.BillPayAccount loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetAllBillPayAccountDataByAccountID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all BillPayAccount data by a key.</summary>
		///
		/// <param name="accountSubTypeCode">A key for BillPayAccount items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.BillPayAccount> GetAllBillPayAccountDataByAccountSubTypeCode(int accountSubTypeCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.BillPayAccountManager.GetAllBillPayAccountDataByAccountSubTypeCode(accountSubTypeCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all BillPayAccount data by a key.</summary>
		///
		/// <param name="accountSubTypeCode">A key for BillPayAccount items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.BillPayAccount> GetAllBillPayAccountDataByAccountSubTypeCode(int accountSubTypeCode)
		{
			// perform main method tasks
			return BLL.Accounts.BillPayAccountManager.GetAllBillPayAccountDataByAccountSubTypeCode(accountSubTypeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all BillPayAccount data by a key.</summary>
		///
		/// <param name="accountSubTypeCode">A key for BillPayAccount items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.BillPayAccount> GetAllBillPayAccountDataByAccountSubTypeCode(int accountSubTypeCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Accounts.BillPayAccount> sortableList = new BLL.SortableList<BLL.Accounts.BillPayAccount>(DAL.Accounts.BillPayAccount.GetAllBillPayAccountDataByAccountSubTypeCode(accountSubTypeCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Accounts.BillPayAccount loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetAllBillPayAccountDataByAccountSubTypeCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all BillPayAccount data by a key.</summary>
		///
		/// <param name="businessMetaPartnerID">A key for BillPayAccount items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.BillPayAccount> GetAllBillPayAccountDataByBusinessMetaPartnerID(Guid businessMetaPartnerID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.BillPayAccountManager.GetAllBillPayAccountDataByBusinessMetaPartnerID(businessMetaPartnerID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all BillPayAccount data by a key.</summary>
		///
		/// <param name="businessMetaPartnerID">A key for BillPayAccount items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.BillPayAccount> GetAllBillPayAccountDataByBusinessMetaPartnerID(Guid businessMetaPartnerID)
		{
			// perform main method tasks
			return BLL.Accounts.BillPayAccountManager.GetAllBillPayAccountDataByBusinessMetaPartnerID(businessMetaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all BillPayAccount data by a key.</summary>
		///
		/// <param name="businessMetaPartnerID">A key for BillPayAccount items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.BillPayAccount> GetAllBillPayAccountDataByBusinessMetaPartnerID(Guid businessMetaPartnerID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Accounts.BillPayAccount> sortableList = new BLL.SortableList<BLL.Accounts.BillPayAccount>(DAL.Accounts.BillPayAccount.GetAllBillPayAccountDataByBusinessMetaPartnerID(businessMetaPartnerID, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Accounts.BillPayAccount loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetAllBillPayAccountDataByBusinessMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all BillPayAccount data by criteria.</summary>
		///
		/// <param name="businessAccountNumber">A key for BillPayAccount items to be fetched</param>
		/// <param name="startDate">A key for BillPayAccount items to be fetched</param>
		/// <param name="endDate">A key for BillPayAccount items to be fetched</param>
		/// <param name="numberOfReminders">A key for BillPayAccount items to be fetched</param>
		/// <param name="frequencyCode">A key for BillPayAccount items to be fetched</param>
		/// <param name="accountName">A key for BillPayAccount items to be fetched</param>
		/// <param name="currencyCode">A key for BillPayAccount items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for BillPayAccount items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for BillPayAccount items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.BillPayAccount> GetAllBillPayAccountDataByCriteria(string businessAccountNumber, DateTime? startDate, DateTime? endDate, int? numberOfReminders, int? frequencyCode, string accountName, int? currencyCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.BillPayAccountManager.GetAllBillPayAccountDataByCriteria(businessAccountNumber, startDate, endDate, numberOfReminders, frequencyCode, accountName, currencyCode, lastModifiedDateStart, lastModifiedDateEnd, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all BillPayAccount data by criteria.</summary>
		///
		/// <param name="businessAccountNumber">A key for BillPayAccount items to be fetched</param>
		/// <param name="startDate">A key for BillPayAccount items to be fetched</param>
		/// <param name="endDate">A key for BillPayAccount items to be fetched</param>
		/// <param name="numberOfReminders">A key for BillPayAccount items to be fetched</param>
		/// <param name="frequencyCode">A key for BillPayAccount items to be fetched</param>
		/// <param name="accountName">A key for BillPayAccount items to be fetched</param>
		/// <param name="currencyCode">A key for BillPayAccount items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for BillPayAccount items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for BillPayAccount items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.BillPayAccount> GetAllBillPayAccountDataByCriteria(string businessAccountNumber, DateTime? startDate, DateTime? endDate, int? numberOfReminders, int? frequencyCode, string accountName, int? currencyCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd)
		{
			// perform main method tasks
			return BLL.Accounts.BillPayAccountManager.GetAllBillPayAccountDataByCriteria(businessAccountNumber, startDate, endDate, numberOfReminders, frequencyCode, accountName, currencyCode, lastModifiedDateStart, lastModifiedDateEnd, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all BillPayAccount data by criteria.</summary>
		///
		/// <param name="businessAccountNumber">A key for BillPayAccount items to be fetched</param>
		/// <param name="startDate">A key for BillPayAccount items to be fetched</param>
		/// <param name="endDate">A key for BillPayAccount items to be fetched</param>
		/// <param name="numberOfReminders">A key for BillPayAccount items to be fetched</param>
		/// <param name="frequencyCode">A key for BillPayAccount items to be fetched</param>
		/// <param name="accountName">A key for BillPayAccount items to be fetched</param>
		/// <param name="currencyCode">A key for BillPayAccount items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for BillPayAccount items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for BillPayAccount items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.BillPayAccount> GetAllBillPayAccountDataByCriteria(string businessAccountNumber, DateTime? startDate, DateTime? endDate, int? numberOfReminders, int? frequencyCode, string accountName, int? currencyCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Accounts.BillPayAccount> sortableList = new BLL.SortableList<BLL.Accounts.BillPayAccount>(DAL.Accounts.BillPayAccount.GetAllBillPayAccountDataByCriteria(businessAccountNumber, startDate, endDate, numberOfReminders, frequencyCode, accountName, currencyCode, lastModifiedDateStart, lastModifiedDateEnd, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Accounts.BillPayAccount loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetAllBillPayAccountDataByCriteria");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all BillPayAccount data by a key.</summary>
		///
		/// <param name="currencyCode">A key for BillPayAccount items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.BillPayAccount> GetAllBillPayAccountDataByCurrencyCode(int currencyCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.BillPayAccountManager.GetAllBillPayAccountDataByCurrencyCode(currencyCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all BillPayAccount data by a key.</summary>
		///
		/// <param name="currencyCode">A key for BillPayAccount items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.BillPayAccount> GetAllBillPayAccountDataByCurrencyCode(int currencyCode)
		{
			// perform main method tasks
			return BLL.Accounts.BillPayAccountManager.GetAllBillPayAccountDataByCurrencyCode(currencyCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all BillPayAccount data by a key.</summary>
		///
		/// <param name="currencyCode">A key for BillPayAccount items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.BillPayAccount> GetAllBillPayAccountDataByCurrencyCode(int currencyCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Accounts.BillPayAccount> sortableList = new BLL.SortableList<BLL.Accounts.BillPayAccount>(DAL.Accounts.BillPayAccount.GetAllBillPayAccountDataByCurrencyCode(currencyCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Accounts.BillPayAccount loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetAllBillPayAccountDataByCurrencyCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all BillPayAccount data by a key.</summary>
		///
		/// <param name="frequencyCode">A key for BillPayAccount items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.BillPayAccount> GetAllBillPayAccountDataByFrequencyCode(int frequencyCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.BillPayAccountManager.GetAllBillPayAccountDataByFrequencyCode(frequencyCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all BillPayAccount data by a key.</summary>
		///
		/// <param name="frequencyCode">A key for BillPayAccount items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.BillPayAccount> GetAllBillPayAccountDataByFrequencyCode(int frequencyCode)
		{
			// perform main method tasks
			return BLL.Accounts.BillPayAccountManager.GetAllBillPayAccountDataByFrequencyCode(frequencyCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all BillPayAccount data by a key.</summary>
		///
		/// <param name="frequencyCode">A key for BillPayAccount items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.BillPayAccount> GetAllBillPayAccountDataByFrequencyCode(int frequencyCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Accounts.BillPayAccount> sortableList = new BLL.SortableList<BLL.Accounts.BillPayAccount>(DAL.Accounts.BillPayAccount.GetAllBillPayAccountDataByFrequencyCode(frequencyCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Accounts.BillPayAccount loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetAllBillPayAccountDataByFrequencyCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all BillPayAccount data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for BillPayAccount items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.BillPayAccount> GetAllBillPayAccountDataByMetaPartnerID(Guid metaPartnerID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.BillPayAccountManager.GetAllBillPayAccountDataByMetaPartnerID(metaPartnerID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all BillPayAccount data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for BillPayAccount items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.BillPayAccount> GetAllBillPayAccountDataByMetaPartnerID(Guid metaPartnerID)
		{
			// perform main method tasks
			return BLL.Accounts.BillPayAccountManager.GetAllBillPayAccountDataByMetaPartnerID(metaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all BillPayAccount data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for BillPayAccount items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.BillPayAccount> GetAllBillPayAccountDataByMetaPartnerID(Guid metaPartnerID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Accounts.BillPayAccount> sortableList = new BLL.SortableList<BLL.Accounts.BillPayAccount>(DAL.Accounts.BillPayAccount.GetAllBillPayAccountDataByMetaPartnerID(metaPartnerID, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Accounts.BillPayAccount loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetAllBillPayAccountDataByMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all BillPayAccount data by criteria.</summary>
		///
		/// <param name="businessAccountNumber">A key for BillPayAccount items to be fetched</param>
		/// <param name="startDate">A key for BillPayAccount items to be fetched</param>
		/// <param name="endDate">A key for BillPayAccount items to be fetched</param>
		/// <param name="numberOfReminders">A key for BillPayAccount items to be fetched</param>
		/// <param name="frequencyCode">A key for BillPayAccount items to be fetched</param>
		/// <param name="accountName">A key for BillPayAccount items to be fetched</param>
		/// <param name="currencyCode">A key for BillPayAccount items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for BillPayAccount items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for BillPayAccount items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.BillPayAccount> GetManyBillPayAccountDataByCriteria(string businessAccountNumber, DateTime? startDate, DateTime? endDate, int? numberOfReminders, int? frequencyCode, string accountName, int? currencyCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.BillPayAccountManager.GetManyBillPayAccountDataByCriteria(businessAccountNumber, startDate, endDate, numberOfReminders, frequencyCode, accountName, currencyCode, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all BillPayAccount data by criteria.</summary>
		///
		/// <param name="businessAccountNumber">A key for BillPayAccount items to be fetched</param>
		/// <param name="startDate">A key for BillPayAccount items to be fetched</param>
		/// <param name="endDate">A key for BillPayAccount items to be fetched</param>
		/// <param name="numberOfReminders">A key for BillPayAccount items to be fetched</param>
		/// <param name="frequencyCode">A key for BillPayAccount items to be fetched</param>
		/// <param name="accountName">A key for BillPayAccount items to be fetched</param>
		/// <param name="currencyCode">A key for BillPayAccount items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for BillPayAccount items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for BillPayAccount items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.BillPayAccount> GetManyBillPayAccountDataByCriteria(string businessAccountNumber, DateTime? startDate, DateTime? endDate, int? numberOfReminders, int? frequencyCode, string accountName, int? currencyCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Accounts.BillPayAccount> sortableList = new BLL.SortableList<BLL.Accounts.BillPayAccount>(DAL.Accounts.BillPayAccount.GetManyBillPayAccountDataByCriteria(businessAccountNumber, startDate, endDate, numberOfReminders, frequencyCode, accountName, currencyCode, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Accounts.BillPayAccount loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetManyBillPayAccountDataByCriteria");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single BillPayAccount by an index.</summary>
		///
		/// <param name="accountID">The index for BillPayAccount to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Accounts.BillPayAccount GetOneBillPayAccount(Guid accountID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.BillPayAccountManager.GetOneBillPayAccount(accountID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single BillPayAccount by an index.</summary>
		///
		/// <param name="accountID">The index for BillPayAccount to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Accounts.BillPayAccount GetOneBillPayAccount(Guid accountID)
		{
			// perform main method tasks
			return BLL.Accounts.BillPayAccountManager.GetOneBillPayAccount(accountID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single BillPayAccount by an index.</summary>
		///
		/// <param name="accountID">The index for BillPayAccount to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Accounts.BillPayAccount GetOneBillPayAccount(Guid accountID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.Accounts.BillPayAccount itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.Accounts.BillPayAccount)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.Accounts.BillPayAccount.GetCacheKey(typeof(BLL.Accounts.BillPayAccount), "PrimaryKey", accountID.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.Accounts.BillPayAccount)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.Accounts.BillPayAccount item = DAL.Accounts.BillPayAccount.GetOneBillPayAccount(accountID, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.Accounts.BillPayAccount();
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
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetOneBillPayAccount");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates BillPayAccount data.</summary>
		///
		/// <param name="item">The BillPayAccount to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneBillPayAccount(BLL.Accounts.BillPayAccount item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Accounts.BillPayAccountManager.UpdateOneBillPayAccount(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates BillPayAccount data.</summary>
		///
		/// <param name="item">The BillPayAccount to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneBillPayAccount(BLL.Accounts.BillPayAccount item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Accounts.BillPayAccount itemDAL = new DAL.Accounts.BillPayAccount();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Accounts.BillPayAccount.UpdateOneBillPayAccount(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.UpdateOneBillPayAccount");
			}
		}
		#endregion Methods
	}
}