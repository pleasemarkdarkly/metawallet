
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
using MW.MComm.WalletSolution.BLL.Users;
using MOD.Data;
using MW.MComm.WalletSolution.BLL.Config;
using BLL = MW.MComm.WalletSolution.BLL;
using DAL = MW.MComm.WalletSolution.DAL;
using Utility = MW.MComm.WalletSolution.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
namespace MW.MComm.WalletSolution.BLL.Users
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage User related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class UserManager
	{
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public UserManager()
		{
			//
			// constructor logic
			//
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------
		/// <summary>This method deletes all User data by a key.</summary>
		///
		/// <param name="localeCode">A key for User items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllUserDataByLocaleCode(int localeCode)
		{
			// perform main method tasks
			BLL.Users.UserManager.DeleteAllUserDataByLocaleCode(localeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all User data by a key.</summary>
		///
		/// <param name="localeCode">A key for User items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllUserDataByLocaleCode(int localeCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Users.User.DeleteAllUserDataByLocaleCode(localeCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.DeleteAllUserDataByLocaleCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes User data.</summary>
		///
		/// <param name="item">The User to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneUser(BLL.Users.User item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Users.UserManager.DeleteOneUser(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes User data.</summary>
		///
		/// <param name="item">The User to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneUser(BLL.Users.User item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Users.User itemDAL = new DAL.Users.User();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Users.User.DeleteOneUser(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = false;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.DeleteOneUser");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all User data.</summary>
		///
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Users.User> GetAllUserData(MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Users.UserManager.GetAllUserData(BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all User data.</summary>
		///
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Users.User> GetAllUserData()
		{
			// perform main method tasks
			return BLL.Users.UserManager.GetAllUserData(BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all User data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Users.User> GetAllUserData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Users.User> sortableList = new BLL.SortableList<BLL.Users.User>(DAL.Users.User.GetAllUserData(dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Users.User loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.GetAllUserData");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all User data by criteria.</summary>
		///
		/// <param name="userName">A key for User items to be fetched</param>
		/// <param name="firstName">A key for User items to be fetched</param>
		/// <param name="lastName">A key for User items to be fetched</param>
		/// <param name="localeCode">A key for User items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for User items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for User items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Users.User> GetAllUserDataByCriteria(string userName, string firstName, string lastName, int? localeCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Users.UserManager.GetAllUserDataByCriteria(userName, firstName, lastName, localeCode, lastModifiedDateStart, lastModifiedDateEnd, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all User data by criteria.</summary>
		///
		/// <param name="userName">A key for User items to be fetched</param>
		/// <param name="firstName">A key for User items to be fetched</param>
		/// <param name="lastName">A key for User items to be fetched</param>
		/// <param name="localeCode">A key for User items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for User items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for User items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Users.User> GetAllUserDataByCriteria(string userName, string firstName, string lastName, int? localeCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd)
		{
			// perform main method tasks
			return BLL.Users.UserManager.GetAllUserDataByCriteria(userName, firstName, lastName, localeCode, lastModifiedDateStart, lastModifiedDateEnd, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all User data by criteria.</summary>
		///
		/// <param name="userName">A key for User items to be fetched</param>
		/// <param name="firstName">A key for User items to be fetched</param>
		/// <param name="lastName">A key for User items to be fetched</param>
		/// <param name="localeCode">A key for User items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for User items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for User items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Users.User> GetAllUserDataByCriteria(string userName, string firstName, string lastName, int? localeCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Users.User> sortableList = new BLL.SortableList<BLL.Users.User>(DAL.Users.User.GetAllUserDataByCriteria(userName, firstName, lastName, localeCode, lastModifiedDateStart, lastModifiedDateEnd, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Users.User loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.GetAllUserDataByCriteria");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all User data by a key.</summary>
		///
		/// <param name="localeCode">A key for User items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Users.User> GetAllUserDataByLocaleCode(int localeCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Users.UserManager.GetAllUserDataByLocaleCode(localeCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all User data by a key.</summary>
		///
		/// <param name="localeCode">A key for User items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Users.User> GetAllUserDataByLocaleCode(int localeCode)
		{
			// perform main method tasks
			return BLL.Users.UserManager.GetAllUserDataByLocaleCode(localeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all User data by a key.</summary>
		///
		/// <param name="localeCode">A key for User items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Users.User> GetAllUserDataByLocaleCode(int localeCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Users.User> sortableList = new BLL.SortableList<BLL.Users.User>(DAL.Users.User.GetAllUserDataByLocaleCode(localeCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Users.User loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.GetAllUserDataByLocaleCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all User data by criteria.</summary>
		///
		/// <param name="userName">A key for User items to be fetched</param>
		/// <param name="firstName">A key for User items to be fetched</param>
		/// <param name="lastName">A key for User items to be fetched</param>
		/// <param name="localeCode">A key for User items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for User items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for User items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Users.User> GetManyUserDataByCriteria(string userName, string firstName, string lastName, int? localeCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Users.UserManager.GetManyUserDataByCriteria(userName, firstName, lastName, localeCode, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all User data by criteria.</summary>
		///
		/// <param name="userName">A key for User items to be fetched</param>
		/// <param name="firstName">A key for User items to be fetched</param>
		/// <param name="lastName">A key for User items to be fetched</param>
		/// <param name="localeCode">A key for User items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for User items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for User items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Users.User> GetManyUserDataByCriteria(string userName, string firstName, string lastName, int? localeCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Users.User> sortableList = new BLL.SortableList<BLL.Users.User>(DAL.Users.User.GetManyUserDataByCriteria(userName, firstName, lastName, localeCode, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Users.User loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.GetManyUserDataByCriteria");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single User by an index.</summary>
		///
		/// <param name="userID">The index for User to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Users.User GetOneUser(Guid userID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Users.UserManager.GetOneUser(userID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single User by an index.</summary>
		///
		/// <param name="userID">The index for User to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Users.User GetOneUser(Guid userID)
		{
			// perform main method tasks
			return BLL.Users.UserManager.GetOneUser(userID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single User by an index.</summary>
		///
		/// <param name="userID">The index for User to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Users.User GetOneUser(Guid userID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.Users.User itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.Users.User)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.Users.User.GetCacheKey(typeof(BLL.Users.User), "PrimaryKey", userID.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.Users.User)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.Users.User item = DAL.Users.User.GetOneUser(userID, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.Users.User();
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
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.GetOneUser");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single User by an index.</summary>
		///
		/// <param name="firstName">The index for User to be fetched</param>
		/// <param name="lastName">The index for User to be fetched</param>
		/// <param name="password">The index for User to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Users.User GetOneUserByFirstNameAndLastNameAndPassword(string firstName, string lastName, string password, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Users.UserManager.GetOneUserByFirstNameAndLastNameAndPassword(firstName, lastName, password, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single User by an index.</summary>
		///
		/// <param name="firstName">The index for User to be fetched</param>
		/// <param name="lastName">The index for User to be fetched</param>
		/// <param name="password">The index for User to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Users.User GetOneUserByFirstNameAndLastNameAndPassword(string firstName, string lastName, string password)
		{
			// perform main method tasks
			return BLL.Users.UserManager.GetOneUserByFirstNameAndLastNameAndPassword(firstName, lastName, password, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single User by an index.</summary>
		///
		/// <param name="firstName">The index for User to be fetched</param>
		/// <param name="lastName">The index for User to be fetched</param>
		/// <param name="password">The index for User to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Users.User GetOneUserByFirstNameAndLastNameAndPassword(string firstName, string lastName, string password, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.Users.User itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.Users.User)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.Users.User.GetCacheKey(typeof(BLL.Users.User), "PrimaryKey", firstName.ToString() + ", " + lastName.ToString() + ", " + password.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.Users.User)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.Users.User item = DAL.Users.User.GetOneUserByFirstNameAndLastNameAndPassword(firstName, lastName, password, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.Users.User();
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
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.GetOneUserByFirstNameAndLastNameAndPassword");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single User by an index.</summary>
		///
		/// <param name="userName">The index for User to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Users.User GetOneUserByUserName(string userName, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Users.UserManager.GetOneUserByUserName(userName, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single User by an index.</summary>
		///
		/// <param name="userName">The index for User to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Users.User GetOneUserByUserName(string userName)
		{
			// perform main method tasks
			return BLL.Users.UserManager.GetOneUserByUserName(userName, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single User by an index.</summary>
		///
		/// <param name="userName">The index for User to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Users.User GetOneUserByUserName(string userName, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.Users.User itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.Users.User)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.Users.User.GetCacheKey(typeof(BLL.Users.User), "PrimaryKey", userName.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.Users.User)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.Users.User item = DAL.Users.User.GetOneUserByUserName(userName, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.Users.User();
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
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.GetOneUserByUserName");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method inserts or updates User data.</summary>
		///
		/// <param name="item">The User to be inserted or updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpsertOneUser(BLL.Users.User item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Users.UserManager.UpsertOneUser(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method inserts or updates User data.</summary>
		///
		/// <param name="item">The User to be inserted or updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpsertOneUser(BLL.Users.User item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Users.User itemDAL = new DAL.Users.User();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Users.User.UpsertOneUser(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.UpsertOneUser");
			}
		}
		#endregion Methods
	}
}