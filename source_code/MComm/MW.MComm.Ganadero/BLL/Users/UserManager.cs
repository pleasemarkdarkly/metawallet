

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
using MW.MComm.Ganadero.BLL.Users;
using MOD.Data;
using MW.MComm.Ganadero.BLL.Config;
using BLL = MW.MComm.Ganadero.BLL;
using DAL = MW.MComm.Ganadero.DAL;
using Utility = MW.MComm.Ganadero.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace MW.MComm.Ganadero.BLL.Users
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage User related information.</summary>
	///
	/// File History:
	/// <created>10/20/2006 (Dave Clemmer)</created>
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

		// ------------------------------------------------------------------------------
		/// <summary>This method loads the User from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public static BLL.Users.User Load(Guid userID)
		{
			BLL.Users.User businessObject = new BLL.Users.User(userID);
			string key = BLL.Users.User.GetCacheKey(typeof(BLL.Users.User), "PrimaryKey", businessObject.PrimaryKey);
			businessObject = (BLL.Users.User)Utility.CacheManager.Cache[key];
			if (businessObject == null)
			{
				businessObject = BLL.Users.UserManager.GetOneUser(userID);
				Utility.CacheManager.Cache.Add(key, businessObject);
			}
			return businessObject;
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
			try
			{
				// perform main method tasks
				DAL.Users.User itemDAL = new DAL.Users.User();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Users.User.DeleteOneUser(itemDAL, performCascadeOperation, ConfigurationInterface.DBOptions, ConfigurationInterface.DebugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = false;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.DeleteOneUser");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method deletes User data.</summary>
		///
		/// <param name="item">The User to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
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
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, ConfigurationInterface.CurrentUserID);
				BLL.SortableList<BLL.Users.User> sortableList = new BLL.SortableList<BLL.Users.User>(DAL.Users.User.GetAllUserData(ConfigurationInterface.DBOptions, dataOptions, ConfigurationInterface.DebugLevel), true, true);
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
		/// <summary>This method gets all User data.</summary>
		///
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Users.User> GetAllUserData()
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.CurrentUserID);
				BLL.SortableList<BLL.Users.User> sortableList = new BLL.SortableList<BLL.Users.User>(DAL.Users.User.GetAllUserData(ConfigurationInterface.DBOptions, ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.DebugLevel), true, true);
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
		/// <param name="lastModifiedDateStart">A key for User items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for User items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Users.User> GetAllUserDataByCriteria(string userName, string firstName, string lastName, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DataOptions dataOptions)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, ConfigurationInterface.CurrentUserID);
				BLL.SortableList<BLL.Users.User> sortableList = new BLL.SortableList<BLL.Users.User>(DAL.Users.User.GetAllUserDataByCriteria(userName, firstName, lastName, lastModifiedDateStart, lastModifiedDateEnd, ConfigurationInterface.DBOptions, dataOptions, ConfigurationInterface.DebugLevel), true, true);
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
		/// <summary>This method gets all User data by criteria.</summary>
		///
		/// <param name="userName">A key for User items to be fetched</param>
		/// <param name="firstName">A key for User items to be fetched</param>
		/// <param name="lastName">A key for User items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for User items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for User items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Users.User> GetAllUserDataByCriteria(string userName, string firstName, string lastName, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.CurrentUserID);
				BLL.SortableList<BLL.Users.User> sortableList = new BLL.SortableList<BLL.Users.User>(DAL.Users.User.GetAllUserDataByCriteria(userName, firstName, lastName, lastModifiedDateStart, lastModifiedDateEnd, ConfigurationInterface.DBOptions, ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.DebugLevel), true, true);
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
		/// <summary>This method gets all User data by criteria.</summary>
		///
		/// <param name="userName">A key for User items to be fetched</param>
		/// <param name="firstName">A key for User items to be fetched</param>
		/// <param name="lastName">A key for User items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for User items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for User items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Users.User> GetAllUserDataByCriteria(string userName, string firstName, string lastName, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Users.User> sortableList = new BLL.SortableList<BLL.Users.User>(DAL.Users.User.GetAllUserDataByCriteria(userName, firstName, lastName, lastModifiedDateStart, lastModifiedDateEnd, dbOptions, dataOptions, debugLevel), true, true);
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
		/// <summary>This method gets all User data by criteria.</summary>
		///
		/// <param name="userName">A key for User items to be fetched</param>
		/// <param name="firstName">A key for User items to be fetched</param>
		/// <param name="lastName">A key for User items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for User items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for User items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Users.User> GetManyUserDataByCriteria(string userName, string firstName, string lastName, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DataOptions dataOptions)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, ConfigurationInterface.CurrentUserID);
				BLL.SortableList<BLL.Users.User> sortableList = new BLL.SortableList<BLL.Users.User>(DAL.Users.User.GetManyUserDataByCriteria(userName, firstName, lastName, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, ConfigurationInterface.DBOptions, dataOptions, ConfigurationInterface.DebugLevel), true, true);
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
		/// <summary>This method gets all User data by criteria.</summary>
		///
		/// <param name="userName">A key for User items to be fetched</param>
		/// <param name="firstName">A key for User items to be fetched</param>
		/// <param name="lastName">A key for User items to be fetched</param>
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
		public static BLL.SortableList<BLL.Users.User> GetManyUserDataByCriteria(string userName, string firstName, string lastName, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Users.User> sortableList = new BLL.SortableList<BLL.Users.User>(DAL.Users.User.GetManyUserDataByCriteria(userName, firstName, lastName, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, dbOptions, dataOptions, debugLevel), true, true);
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
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, ConfigurationInterface.CurrentUserID);
				DAL.Users.User item = null;
				item = DAL.Users.User.GetOneUser(userID, ConfigurationInterface.DBOptions, dataOptions, ConfigurationInterface.DebugLevel);
				BLL.Users.User itemBLL = null;
				if (item != null)
				{
					itemBLL = new BLL.Users.User();
					ReflectionHelper.Copy(item, itemBLL, true);
					itemBLL.ClearDirtyState(true);
					itemBLL.IsLoaded = true;
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
		/// <param name="userID">The index for User to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Users.User GetOneUser(Guid userID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.CurrentUserID);
				DAL.Users.User item = null;
				item = DAL.Users.User.GetOneUser(userID, ConfigurationInterface.DBOptions, ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.DebugLevel);
				BLL.Users.User itemBLL = null;
				if (item != null)
				{
					itemBLL = new BLL.Users.User();
					ReflectionHelper.Copy(item, itemBLL, true);
					itemBLL.ClearDirtyState(true);
					itemBLL.IsLoaded = true;
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
				DAL.Users.User item = null;
				item = DAL.Users.User.GetOneUser(userID, dbOptions, dataOptions, debugLevel);
				BLL.Users.User itemBLL = null;
				if (item != null)
				{
					itemBLL = new BLL.Users.User();
					ReflectionHelper.Copy(item, itemBLL, true);
					itemBLL.ClearDirtyState(true);
					itemBLL.IsLoaded = true;
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
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, ConfigurationInterface.CurrentUserID);
				DAL.Users.User item = null;
				item = DAL.Users.User.GetOneUserByFirstNameAndLastNameAndPassword(firstName, lastName, password, ConfigurationInterface.DBOptions, dataOptions, ConfigurationInterface.DebugLevel);
				BLL.Users.User itemBLL = null;
				if (item != null)
				{
					itemBLL = new BLL.Users.User();
					ReflectionHelper.Copy(item, itemBLL, true);
					itemBLL.ClearDirtyState(true);
					itemBLL.IsLoaded = true;
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
		/// <param name="firstName">The index for User to be fetched</param>
		/// <param name="lastName">The index for User to be fetched</param>
		/// <param name="password">The index for User to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Users.User GetOneUserByFirstNameAndLastNameAndPassword(string firstName, string lastName, string password)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.CurrentUserID);
				DAL.Users.User item = null;
				item = DAL.Users.User.GetOneUserByFirstNameAndLastNameAndPassword(firstName, lastName, password, ConfigurationInterface.DBOptions, ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.DebugLevel);
				BLL.Users.User itemBLL = null;
				if (item != null)
				{
					itemBLL = new BLL.Users.User();
					ReflectionHelper.Copy(item, itemBLL, true);
					itemBLL.ClearDirtyState(true);
					itemBLL.IsLoaded = true;
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
				DAL.Users.User item = null;
				item = DAL.Users.User.GetOneUserByFirstNameAndLastNameAndPassword(firstName, lastName, password, dbOptions, dataOptions, debugLevel);
				BLL.Users.User itemBLL = null;
				if (item != null)
				{
					itemBLL = new BLL.Users.User();
					ReflectionHelper.Copy(item, itemBLL, true);
					itemBLL.ClearDirtyState(true);
					itemBLL.IsLoaded = true;
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
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, ConfigurationInterface.CurrentUserID);
				DAL.Users.User item = null;
				item = DAL.Users.User.GetOneUserByUserName(userName, ConfigurationInterface.DBOptions, dataOptions, ConfigurationInterface.DebugLevel);
				BLL.Users.User itemBLL = null;
				if (item != null)
				{
					itemBLL = new BLL.Users.User();
					ReflectionHelper.Copy(item, itemBLL, true);
					itemBLL.ClearDirtyState(true);
					itemBLL.IsLoaded = true;
				}
				return itemBLL;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.GetOneUserByUserName");
			}
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
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.CurrentUserID);
				DAL.Users.User item = null;
				item = DAL.Users.User.GetOneUserByUserName(userName, ConfigurationInterface.DBOptions, ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.DebugLevel);
				BLL.Users.User itemBLL = null;
				if (item != null)
				{
					itemBLL = new BLL.Users.User();
					ReflectionHelper.Copy(item, itemBLL, true);
					itemBLL.ClearDirtyState(true);
					itemBLL.IsLoaded = true;
				}
				return itemBLL;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.GetOneUserByUserName");
			}
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
				DAL.Users.User item = null;
				item = DAL.Users.User.GetOneUserByUserName(userName, dbOptions, dataOptions, debugLevel);
				BLL.Users.User itemBLL = null;
				if (item != null)
				{
					itemBLL = new BLL.Users.User();
					ReflectionHelper.Copy(item, itemBLL, true);
					itemBLL.ClearDirtyState(true);
					itemBLL.IsLoaded = true;
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
			try
			{
				// perform main method tasks
				item.CreatedByUserID = ConfigurationInterface.CurrentUserID;
				item.LastModifiedByUserID = ConfigurationInterface.CurrentUserID;
				DAL.Users.User itemDAL = new DAL.Users.User();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Users.User.UpsertOneUser(itemDAL, performCascadeOperation, ConfigurationInterface.DBOptions, ConfigurationInterface.DebugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.UpsertOneUser");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method inserts or updates User data.</summary>
		///
		/// <param name="item">The User to be inserted or updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
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