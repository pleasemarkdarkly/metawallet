

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
	/// <summary>This class is used to manage UserRoleUser related information.</summary>
	///
	/// File History:
	/// <created>10/20/2006 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class UserRoleUserManager
	{

		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public UserRoleUserManager()
		{
			//
			// constructor logic
			//
		}

		#endregion Constructors

		#region Methods

		// ------------------------------------------------------------------------------
		/// <summary>This method loads the UserRoleUser from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public static BLL.Users.UserRoleUser Load(int userRoleCode, Guid userID)
		{
			BLL.Users.UserRoleUser businessObject = new BLL.Users.UserRoleUser(userRoleCode, userID);
			string key = BLL.Users.UserRoleUser.GetCacheKey(typeof(BLL.Users.UserRoleUser), "PrimaryKey", businessObject.PrimaryKey);
			businessObject = (BLL.Users.UserRoleUser)Utility.CacheManager.Cache[key];
			if (businessObject == null)
			{
				businessObject = BLL.Users.UserRoleUserManager.GetOneUserRoleUser(userRoleCode, userID);
				Utility.CacheManager.Cache.Add(key, businessObject);
			}
			return businessObject;
		}


		// ------------------------------------------------------------------
		/// <summary>This method inserts UserRoleUser data.</summary>
		///
		/// <param name="item">The UserRoleUser to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneUserRoleUser(BLL.Users.UserRoleUser item, bool performCascadeOperation )
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = ConfigurationInterface.CurrentUserID;
				item.LastModifiedByUserID = ConfigurationInterface.CurrentUserID;
				DAL.Users.UserRoleUser itemDAL = new DAL.Users.UserRoleUser();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Users.UserRoleUser.AddOneUserRoleUser(itemDAL, performCascadeOperation, ConfigurationInterface.DBOptions, ConfigurationInterface.DebugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.AddOneUserRoleUser");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method inserts UserRoleUser data.</summary>
		///
		/// <param name="item">The UserRoleUser to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneUserRoleUser(BLL.Users.UserRoleUser item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Users.UserRoleUser itemDAL = new DAL.Users.UserRoleUser();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Users.UserRoleUser.AddOneUserRoleUser(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.AddOneUserRoleUser");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method deletes all UserRoleUser data by a key.</summary>
		///
		/// <param name="userID">A key for UserRoleUser items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllUserRoleUserDataByUserID(Guid userID)
		{
			try
			{
				// perform main method tasks
				DAL.Users.UserRoleUser.DeleteAllUserRoleUserDataByUserID(userID, ConfigurationInterface.DBOptions, ConfigurationInterface.DebugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.DeleteAllUserRoleUserDataByUserID");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method deletes all UserRoleUser data by a key.</summary>
		///
		/// <param name="userID">A key for UserRoleUser items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllUserRoleUserDataByUserID(Guid userID, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Users.UserRoleUser.DeleteAllUserRoleUserDataByUserID(userID, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.DeleteAllUserRoleUserDataByUserID");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method deletes all UserRoleUser data by a key.</summary>
		///
		/// <param name="userRoleCode">A key for UserRoleUser items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllUserRoleUserDataByUserRoleCode(int userRoleCode)
		{
			try
			{
				// perform main method tasks
				DAL.Users.UserRoleUser.DeleteAllUserRoleUserDataByUserRoleCode(userRoleCode, ConfigurationInterface.DBOptions, ConfigurationInterface.DebugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.DeleteAllUserRoleUserDataByUserRoleCode");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method deletes all UserRoleUser data by a key.</summary>
		///
		/// <param name="userRoleCode">A key for UserRoleUser items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllUserRoleUserDataByUserRoleCode(int userRoleCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Users.UserRoleUser.DeleteAllUserRoleUserDataByUserRoleCode(userRoleCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.DeleteAllUserRoleUserDataByUserRoleCode");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method deletes UserRoleUser data.</summary>
		///
		/// <param name="item">The UserRoleUser to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneUserRoleUser(BLL.Users.UserRoleUser item, bool performCascadeOperation )
		{
			try
			{
				// perform main method tasks
				DAL.Users.UserRoleUser itemDAL = new DAL.Users.UserRoleUser();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Users.UserRoleUser.DeleteOneUserRoleUser(itemDAL, performCascadeOperation, ConfigurationInterface.DBOptions, ConfigurationInterface.DebugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = false;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.DeleteOneUserRoleUser");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method deletes UserRoleUser data.</summary>
		///
		/// <param name="item">The UserRoleUser to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneUserRoleUser(BLL.Users.UserRoleUser item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Users.UserRoleUser itemDAL = new DAL.Users.UserRoleUser();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Users.UserRoleUser.DeleteOneUserRoleUser(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = false;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.DeleteOneUserRoleUser");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets all UserRoleUser data.</summary>
		///
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Users.UserRoleUser> GetAllUserRoleUserData(MOD.Data.DataOptions dataOptions)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, ConfigurationInterface.CurrentUserID);
				BLL.SortableList<BLL.Users.UserRoleUser> sortableList = new BLL.SortableList<BLL.Users.UserRoleUser>(DAL.Users.UserRoleUser.GetAllUserRoleUserData(ConfigurationInterface.DBOptions, dataOptions, ConfigurationInterface.DebugLevel), true, true);
				foreach(BLL.Users.UserRoleUser loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.GetAllUserRoleUserData");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets all UserRoleUser data.</summary>
		///
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Users.UserRoleUser> GetAllUserRoleUserData()
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.CurrentUserID);
				BLL.SortableList<BLL.Users.UserRoleUser> sortableList = new BLL.SortableList<BLL.Users.UserRoleUser>(DAL.Users.UserRoleUser.GetAllUserRoleUserData(ConfigurationInterface.DBOptions, ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.DebugLevel), true, true);
				foreach(BLL.Users.UserRoleUser loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.GetAllUserRoleUserData");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets all UserRoleUser data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Users.UserRoleUser> GetAllUserRoleUserData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Users.UserRoleUser> sortableList = new BLL.SortableList<BLL.Users.UserRoleUser>(DAL.Users.UserRoleUser.GetAllUserRoleUserData(dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Users.UserRoleUser loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.GetAllUserRoleUserData");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets all UserRoleUser data by a key.</summary>
		///
		/// <param name="userID">A key for UserRoleUser items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Users.UserRoleUser> GetAllUserRoleUserDataByUserID(Guid userID, MOD.Data.DataOptions dataOptions)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, ConfigurationInterface.CurrentUserID);
				BLL.SortableList<BLL.Users.UserRoleUser> sortableList = new BLL.SortableList<BLL.Users.UserRoleUser>(DAL.Users.UserRoleUser.GetAllUserRoleUserDataByUserID(userID, ConfigurationInterface.DBOptions, dataOptions, ConfigurationInterface.DebugLevel), true, true);
				foreach(BLL.Users.UserRoleUser loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.GetAllUserRoleUserDataByUserID");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets all UserRoleUser data by a key.</summary>
		///
		/// <param name="userID">A key for UserRoleUser items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Users.UserRoleUser> GetAllUserRoleUserDataByUserID(Guid userID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.CurrentUserID);
				BLL.SortableList<BLL.Users.UserRoleUser> sortableList = new BLL.SortableList<BLL.Users.UserRoleUser>(DAL.Users.UserRoleUser.GetAllUserRoleUserDataByUserID(userID, ConfigurationInterface.DBOptions, ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.DebugLevel), true, true);
				foreach(BLL.Users.UserRoleUser loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.GetAllUserRoleUserDataByUserID");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets all UserRoleUser data by a key.</summary>
		///
		/// <param name="userID">A key for UserRoleUser items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Users.UserRoleUser> GetAllUserRoleUserDataByUserID(Guid userID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Users.UserRoleUser> sortableList = new BLL.SortableList<BLL.Users.UserRoleUser>(DAL.Users.UserRoleUser.GetAllUserRoleUserDataByUserID(userID, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Users.UserRoleUser loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.GetAllUserRoleUserDataByUserID");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets all UserRoleUser data by a key.</summary>
		///
		/// <param name="userRoleCode">A key for UserRoleUser items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Users.UserRoleUser> GetAllUserRoleUserDataByUserRoleCode(int userRoleCode, MOD.Data.DataOptions dataOptions)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, ConfigurationInterface.CurrentUserID);
				BLL.SortableList<BLL.Users.UserRoleUser> sortableList = new BLL.SortableList<BLL.Users.UserRoleUser>(DAL.Users.UserRoleUser.GetAllUserRoleUserDataByUserRoleCode(userRoleCode, ConfigurationInterface.DBOptions, dataOptions, ConfigurationInterface.DebugLevel), true, true);
				foreach(BLL.Users.UserRoleUser loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.GetAllUserRoleUserDataByUserRoleCode");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets all UserRoleUser data by a key.</summary>
		///
		/// <param name="userRoleCode">A key for UserRoleUser items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Users.UserRoleUser> GetAllUserRoleUserDataByUserRoleCode(int userRoleCode)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.CurrentUserID);
				BLL.SortableList<BLL.Users.UserRoleUser> sortableList = new BLL.SortableList<BLL.Users.UserRoleUser>(DAL.Users.UserRoleUser.GetAllUserRoleUserDataByUserRoleCode(userRoleCode, ConfigurationInterface.DBOptions, ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.DebugLevel), true, true);
				foreach(BLL.Users.UserRoleUser loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.GetAllUserRoleUserDataByUserRoleCode");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets all UserRoleUser data by a key.</summary>
		///
		/// <param name="userRoleCode">A key for UserRoleUser items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Users.UserRoleUser> GetAllUserRoleUserDataByUserRoleCode(int userRoleCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Users.UserRoleUser> sortableList = new BLL.SortableList<BLL.Users.UserRoleUser>(DAL.Users.UserRoleUser.GetAllUserRoleUserDataByUserRoleCode(userRoleCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Users.UserRoleUser loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.GetAllUserRoleUserDataByUserRoleCode");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets a single UserRoleUser by an index.</summary>
		///
		/// <param name="userRoleCode">The index for UserRoleUser to be fetched</param>
		/// <param name="userID">The index for UserRoleUser to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Users.UserRoleUser GetOneUserRoleUser(int userRoleCode, Guid userID, MOD.Data.DataOptions dataOptions)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, ConfigurationInterface.CurrentUserID);
				DAL.Users.UserRoleUser item = null;
				item = DAL.Users.UserRoleUser.GetOneUserRoleUser(userRoleCode, userID, ConfigurationInterface.DBOptions, dataOptions, ConfigurationInterface.DebugLevel);
				BLL.Users.UserRoleUser itemBLL = null;
				if (item != null)
				{
					itemBLL = new BLL.Users.UserRoleUser();
					ReflectionHelper.Copy(item, itemBLL, true);
					itemBLL.ClearDirtyState(true);
					itemBLL.IsLoaded = true;
				}
				return itemBLL;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.GetOneUserRoleUser");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets a single UserRoleUser by an index.</summary>
		///
		/// <param name="userRoleCode">The index for UserRoleUser to be fetched</param>
		/// <param name="userID">The index for UserRoleUser to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Users.UserRoleUser GetOneUserRoleUser(int userRoleCode, Guid userID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.CurrentUserID);
				DAL.Users.UserRoleUser item = null;
				item = DAL.Users.UserRoleUser.GetOneUserRoleUser(userRoleCode, userID, ConfigurationInterface.DBOptions, ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.DebugLevel);
				BLL.Users.UserRoleUser itemBLL = null;
				if (item != null)
				{
					itemBLL = new BLL.Users.UserRoleUser();
					ReflectionHelper.Copy(item, itemBLL, true);
					itemBLL.ClearDirtyState(true);
					itemBLL.IsLoaded = true;
				}
				return itemBLL;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.GetOneUserRoleUser");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets a single UserRoleUser by an index.</summary>
		///
		/// <param name="userRoleCode">The index for UserRoleUser to be fetched</param>
		/// <param name="userID">The index for UserRoleUser to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Users.UserRoleUser GetOneUserRoleUser(int userRoleCode, Guid userID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				DAL.Users.UserRoleUser item = null;
				item = DAL.Users.UserRoleUser.GetOneUserRoleUser(userRoleCode, userID, dbOptions, dataOptions, debugLevel);
				BLL.Users.UserRoleUser itemBLL = null;
				if (item != null)
				{
					itemBLL = new BLL.Users.UserRoleUser();
					ReflectionHelper.Copy(item, itemBLL, true);
					itemBLL.ClearDirtyState(true);
					itemBLL.IsLoaded = true;
				}
				return itemBLL;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.GetOneUserRoleUser");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method updates UserRoleUser data.</summary>
		///
		/// <param name="item">The UserRoleUser to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneUserRoleUser(BLL.Users.UserRoleUser item, bool performCascadeOperation )
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = ConfigurationInterface.CurrentUserID;
				item.LastModifiedByUserID = ConfigurationInterface.CurrentUserID;
				DAL.Users.UserRoleUser itemDAL = new DAL.Users.UserRoleUser();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Users.UserRoleUser.UpdateOneUserRoleUser(itemDAL, performCascadeOperation, ConfigurationInterface.DBOptions, ConfigurationInterface.DebugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.UpdateOneUserRoleUser");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method updates UserRoleUser data.</summary>
		///
		/// <param name="item">The UserRoleUser to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneUserRoleUser(BLL.Users.UserRoleUser item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Users.UserRoleUser itemDAL = new DAL.Users.UserRoleUser();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Users.UserRoleUser.UpdateOneUserRoleUser(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.UpdateOneUserRoleUser");
			}
		}
		#endregion Methods
	}
}