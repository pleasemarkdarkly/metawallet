

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
	/// <summary>This class is used to manage UserRoleActivity related information.</summary>
	///
	/// File History:
	/// <created>10/20/2006 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class UserRoleActivityManager
	{

		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public UserRoleActivityManager()
		{
			//
			// constructor logic
			//
		}

		#endregion Constructors

		#region Methods

		// ------------------------------------------------------------------------------
		/// <summary>This method loads the UserRoleActivity from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public static BLL.Users.UserRoleActivity Load(int userRoleCode, int activityCode, int accessModeCode)
		{
			BLL.Users.UserRoleActivity businessObject = new BLL.Users.UserRoleActivity(userRoleCode, activityCode, accessModeCode);
			string key = BLL.Users.UserRoleActivity.GetCacheKey(typeof(BLL.Users.UserRoleActivity), "PrimaryKey", businessObject.PrimaryKey);
			businessObject = (BLL.Users.UserRoleActivity)Utility.CacheManager.Cache[key];
			if (businessObject == null)
			{
				businessObject = BLL.Users.UserRoleActivityManager.GetOneUserRoleActivity(userRoleCode, activityCode, accessModeCode);
				Utility.CacheManager.Cache.Add(key, businessObject);
			}
			return businessObject;
		}


		// ------------------------------------------------------------------
		/// <summary>This method inserts UserRoleActivity data.</summary>
		///
		/// <param name="item">The UserRoleActivity to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneUserRoleActivity(BLL.Users.UserRoleActivity item, bool performCascadeOperation )
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = ConfigurationInterface.CurrentUserID;
				item.LastModifiedByUserID = ConfigurationInterface.CurrentUserID;
				DAL.Users.UserRoleActivity itemDAL = new DAL.Users.UserRoleActivity();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Users.UserRoleActivity.AddOneUserRoleActivity(itemDAL, performCascadeOperation, ConfigurationInterface.DBOptions, ConfigurationInterface.DebugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.AddOneUserRoleActivity");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method inserts UserRoleActivity data.</summary>
		///
		/// <param name="item">The UserRoleActivity to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneUserRoleActivity(BLL.Users.UserRoleActivity item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Users.UserRoleActivity itemDAL = new DAL.Users.UserRoleActivity();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Users.UserRoleActivity.AddOneUserRoleActivity(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.AddOneUserRoleActivity");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method deletes all UserRoleActivity data by a key.</summary>
		///
		/// <param name="accessModeCode">A key for UserRoleActivity items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllUserRoleActivityDataByAccessModeCode(int accessModeCode)
		{
			try
			{
				// perform main method tasks
				DAL.Users.UserRoleActivity.DeleteAllUserRoleActivityDataByAccessModeCode(accessModeCode, ConfigurationInterface.DBOptions, ConfigurationInterface.DebugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.DeleteAllUserRoleActivityDataByAccessModeCode");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method deletes all UserRoleActivity data by a key.</summary>
		///
		/// <param name="accessModeCode">A key for UserRoleActivity items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllUserRoleActivityDataByAccessModeCode(int accessModeCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Users.UserRoleActivity.DeleteAllUserRoleActivityDataByAccessModeCode(accessModeCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.DeleteAllUserRoleActivityDataByAccessModeCode");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method deletes all UserRoleActivity data by a key.</summary>
		///
		/// <param name="activityCode">A key for UserRoleActivity items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllUserRoleActivityDataByActivityCode(int activityCode)
		{
			try
			{
				// perform main method tasks
				DAL.Users.UserRoleActivity.DeleteAllUserRoleActivityDataByActivityCode(activityCode, ConfigurationInterface.DBOptions, ConfigurationInterface.DebugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.DeleteAllUserRoleActivityDataByActivityCode");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method deletes all UserRoleActivity data by a key.</summary>
		///
		/// <param name="activityCode">A key for UserRoleActivity items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllUserRoleActivityDataByActivityCode(int activityCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Users.UserRoleActivity.DeleteAllUserRoleActivityDataByActivityCode(activityCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.DeleteAllUserRoleActivityDataByActivityCode");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method deletes all UserRoleActivity data by a key.</summary>
		///
		/// <param name="userRoleCode">A key for UserRoleActivity items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllUserRoleActivityDataByUserRoleCode(int userRoleCode)
		{
			try
			{
				// perform main method tasks
				DAL.Users.UserRoleActivity.DeleteAllUserRoleActivityDataByUserRoleCode(userRoleCode, ConfigurationInterface.DBOptions, ConfigurationInterface.DebugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.DeleteAllUserRoleActivityDataByUserRoleCode");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method deletes all UserRoleActivity data by a key.</summary>
		///
		/// <param name="userRoleCode">A key for UserRoleActivity items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllUserRoleActivityDataByUserRoleCode(int userRoleCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Users.UserRoleActivity.DeleteAllUserRoleActivityDataByUserRoleCode(userRoleCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.DeleteAllUserRoleActivityDataByUserRoleCode");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method deletes UserRoleActivity data.</summary>
		///
		/// <param name="item">The UserRoleActivity to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneUserRoleActivity(BLL.Users.UserRoleActivity item, bool performCascadeOperation )
		{
			try
			{
				// perform main method tasks
				DAL.Users.UserRoleActivity itemDAL = new DAL.Users.UserRoleActivity();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Users.UserRoleActivity.DeleteOneUserRoleActivity(itemDAL, performCascadeOperation, ConfigurationInterface.DBOptions, ConfigurationInterface.DebugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = false;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.DeleteOneUserRoleActivity");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method deletes UserRoleActivity data.</summary>
		///
		/// <param name="item">The UserRoleActivity to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneUserRoleActivity(BLL.Users.UserRoleActivity item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Users.UserRoleActivity itemDAL = new DAL.Users.UserRoleActivity();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Users.UserRoleActivity.DeleteOneUserRoleActivity(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = false;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.DeleteOneUserRoleActivity");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets all UserRoleActivity data.</summary>
		///
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Users.UserRoleActivity> GetAllUserRoleActivityData(MOD.Data.DataOptions dataOptions)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, ConfigurationInterface.CurrentUserID);
				BLL.SortableList<BLL.Users.UserRoleActivity> sortableList = new BLL.SortableList<BLL.Users.UserRoleActivity>(DAL.Users.UserRoleActivity.GetAllUserRoleActivityData(ConfigurationInterface.DBOptions, dataOptions, ConfigurationInterface.DebugLevel), true, true);
				foreach(BLL.Users.UserRoleActivity loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.GetAllUserRoleActivityData");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets all UserRoleActivity data.</summary>
		///
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Users.UserRoleActivity> GetAllUserRoleActivityData()
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.CurrentUserID);
				BLL.SortableList<BLL.Users.UserRoleActivity> sortableList = new BLL.SortableList<BLL.Users.UserRoleActivity>(DAL.Users.UserRoleActivity.GetAllUserRoleActivityData(ConfigurationInterface.DBOptions, ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.DebugLevel), true, true);
				foreach(BLL.Users.UserRoleActivity loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.GetAllUserRoleActivityData");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets all UserRoleActivity data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Users.UserRoleActivity> GetAllUserRoleActivityData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Users.UserRoleActivity> sortableList = new BLL.SortableList<BLL.Users.UserRoleActivity>(DAL.Users.UserRoleActivity.GetAllUserRoleActivityData(dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Users.UserRoleActivity loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.GetAllUserRoleActivityData");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets all UserRoleActivity data by a key.</summary>
		///
		/// <param name="accessModeCode">A key for UserRoleActivity items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Users.UserRoleActivity> GetAllUserRoleActivityDataByAccessModeCode(int accessModeCode, MOD.Data.DataOptions dataOptions)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, ConfigurationInterface.CurrentUserID);
				BLL.SortableList<BLL.Users.UserRoleActivity> sortableList = new BLL.SortableList<BLL.Users.UserRoleActivity>(DAL.Users.UserRoleActivity.GetAllUserRoleActivityDataByAccessModeCode(accessModeCode, ConfigurationInterface.DBOptions, dataOptions, ConfigurationInterface.DebugLevel), true, true);
				foreach(BLL.Users.UserRoleActivity loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.GetAllUserRoleActivityDataByAccessModeCode");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets all UserRoleActivity data by a key.</summary>
		///
		/// <param name="accessModeCode">A key for UserRoleActivity items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Users.UserRoleActivity> GetAllUserRoleActivityDataByAccessModeCode(int accessModeCode)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.CurrentUserID);
				BLL.SortableList<BLL.Users.UserRoleActivity> sortableList = new BLL.SortableList<BLL.Users.UserRoleActivity>(DAL.Users.UserRoleActivity.GetAllUserRoleActivityDataByAccessModeCode(accessModeCode, ConfigurationInterface.DBOptions, ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.DebugLevel), true, true);
				foreach(BLL.Users.UserRoleActivity loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.GetAllUserRoleActivityDataByAccessModeCode");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets all UserRoleActivity data by a key.</summary>
		///
		/// <param name="accessModeCode">A key for UserRoleActivity items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Users.UserRoleActivity> GetAllUserRoleActivityDataByAccessModeCode(int accessModeCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Users.UserRoleActivity> sortableList = new BLL.SortableList<BLL.Users.UserRoleActivity>(DAL.Users.UserRoleActivity.GetAllUserRoleActivityDataByAccessModeCode(accessModeCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Users.UserRoleActivity loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.GetAllUserRoleActivityDataByAccessModeCode");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets all UserRoleActivity data by a key.</summary>
		///
		/// <param name="activityCode">A key for UserRoleActivity items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Users.UserRoleActivity> GetAllUserRoleActivityDataByActivityCode(int activityCode, MOD.Data.DataOptions dataOptions)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, ConfigurationInterface.CurrentUserID);
				BLL.SortableList<BLL.Users.UserRoleActivity> sortableList = new BLL.SortableList<BLL.Users.UserRoleActivity>(DAL.Users.UserRoleActivity.GetAllUserRoleActivityDataByActivityCode(activityCode, ConfigurationInterface.DBOptions, dataOptions, ConfigurationInterface.DebugLevel), true, true);
				foreach(BLL.Users.UserRoleActivity loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.GetAllUserRoleActivityDataByActivityCode");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets all UserRoleActivity data by a key.</summary>
		///
		/// <param name="activityCode">A key for UserRoleActivity items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Users.UserRoleActivity> GetAllUserRoleActivityDataByActivityCode(int activityCode)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.CurrentUserID);
				BLL.SortableList<BLL.Users.UserRoleActivity> sortableList = new BLL.SortableList<BLL.Users.UserRoleActivity>(DAL.Users.UserRoleActivity.GetAllUserRoleActivityDataByActivityCode(activityCode, ConfigurationInterface.DBOptions, ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.DebugLevel), true, true);
				foreach(BLL.Users.UserRoleActivity loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.GetAllUserRoleActivityDataByActivityCode");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets all UserRoleActivity data by a key.</summary>
		///
		/// <param name="activityCode">A key for UserRoleActivity items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Users.UserRoleActivity> GetAllUserRoleActivityDataByActivityCode(int activityCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Users.UserRoleActivity> sortableList = new BLL.SortableList<BLL.Users.UserRoleActivity>(DAL.Users.UserRoleActivity.GetAllUserRoleActivityDataByActivityCode(activityCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Users.UserRoleActivity loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.GetAllUserRoleActivityDataByActivityCode");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets all UserRoleActivity data by a key.</summary>
		///
		/// <param name="userRoleCode">A key for UserRoleActivity items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Users.UserRoleActivity> GetAllUserRoleActivityDataByUserRoleCode(int userRoleCode, MOD.Data.DataOptions dataOptions)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, ConfigurationInterface.CurrentUserID);
				BLL.SortableList<BLL.Users.UserRoleActivity> sortableList = new BLL.SortableList<BLL.Users.UserRoleActivity>(DAL.Users.UserRoleActivity.GetAllUserRoleActivityDataByUserRoleCode(userRoleCode, ConfigurationInterface.DBOptions, dataOptions, ConfigurationInterface.DebugLevel), true, true);
				foreach(BLL.Users.UserRoleActivity loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.GetAllUserRoleActivityDataByUserRoleCode");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets all UserRoleActivity data by a key.</summary>
		///
		/// <param name="userRoleCode">A key for UserRoleActivity items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Users.UserRoleActivity> GetAllUserRoleActivityDataByUserRoleCode(int userRoleCode)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.CurrentUserID);
				BLL.SortableList<BLL.Users.UserRoleActivity> sortableList = new BLL.SortableList<BLL.Users.UserRoleActivity>(DAL.Users.UserRoleActivity.GetAllUserRoleActivityDataByUserRoleCode(userRoleCode, ConfigurationInterface.DBOptions, ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.DebugLevel), true, true);
				foreach(BLL.Users.UserRoleActivity loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.GetAllUserRoleActivityDataByUserRoleCode");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets all UserRoleActivity data by a key.</summary>
		///
		/// <param name="userRoleCode">A key for UserRoleActivity items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Users.UserRoleActivity> GetAllUserRoleActivityDataByUserRoleCode(int userRoleCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Users.UserRoleActivity> sortableList = new BLL.SortableList<BLL.Users.UserRoleActivity>(DAL.Users.UserRoleActivity.GetAllUserRoleActivityDataByUserRoleCode(userRoleCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Users.UserRoleActivity loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.GetAllUserRoleActivityDataByUserRoleCode");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets a single UserRoleActivity by an index.</summary>
		///
		/// <param name="userRoleCode">The index for UserRoleActivity to be fetched</param>
		/// <param name="activityCode">The index for UserRoleActivity to be fetched</param>
		/// <param name="accessModeCode">The index for UserRoleActivity to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Users.UserRoleActivity GetOneUserRoleActivity(int userRoleCode, int activityCode, int accessModeCode, MOD.Data.DataOptions dataOptions)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, ConfigurationInterface.CurrentUserID);
				DAL.Users.UserRoleActivity item = null;
				item = DAL.Users.UserRoleActivity.GetOneUserRoleActivity(userRoleCode, activityCode, accessModeCode, ConfigurationInterface.DBOptions, dataOptions, ConfigurationInterface.DebugLevel);
				BLL.Users.UserRoleActivity itemBLL = null;
				if (item != null)
				{
					itemBLL = new BLL.Users.UserRoleActivity();
					ReflectionHelper.Copy(item, itemBLL, true);
					itemBLL.ClearDirtyState(true);
					itemBLL.IsLoaded = true;
				}
				return itemBLL;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.GetOneUserRoleActivity");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets a single UserRoleActivity by an index.</summary>
		///
		/// <param name="userRoleCode">The index for UserRoleActivity to be fetched</param>
		/// <param name="activityCode">The index for UserRoleActivity to be fetched</param>
		/// <param name="accessModeCode">The index for UserRoleActivity to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Users.UserRoleActivity GetOneUserRoleActivity(int userRoleCode, int activityCode, int accessModeCode)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.CurrentUserID);
				DAL.Users.UserRoleActivity item = null;
				item = DAL.Users.UserRoleActivity.GetOneUserRoleActivity(userRoleCode, activityCode, accessModeCode, ConfigurationInterface.DBOptions, ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.DebugLevel);
				BLL.Users.UserRoleActivity itemBLL = null;
				if (item != null)
				{
					itemBLL = new BLL.Users.UserRoleActivity();
					ReflectionHelper.Copy(item, itemBLL, true);
					itemBLL.ClearDirtyState(true);
					itemBLL.IsLoaded = true;
				}
				return itemBLL;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.GetOneUserRoleActivity");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets a single UserRoleActivity by an index.</summary>
		///
		/// <param name="userRoleCode">The index for UserRoleActivity to be fetched</param>
		/// <param name="activityCode">The index for UserRoleActivity to be fetched</param>
		/// <param name="accessModeCode">The index for UserRoleActivity to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Users.UserRoleActivity GetOneUserRoleActivity(int userRoleCode, int activityCode, int accessModeCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				DAL.Users.UserRoleActivity item = null;
				item = DAL.Users.UserRoleActivity.GetOneUserRoleActivity(userRoleCode, activityCode, accessModeCode, dbOptions, dataOptions, debugLevel);
				BLL.Users.UserRoleActivity itemBLL = null;
				if (item != null)
				{
					itemBLL = new BLL.Users.UserRoleActivity();
					ReflectionHelper.Copy(item, itemBLL, true);
					itemBLL.ClearDirtyState(true);
					itemBLL.IsLoaded = true;
				}
				return itemBLL;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.GetOneUserRoleActivity");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method updates UserRoleActivity data.</summary>
		///
		/// <param name="item">The UserRoleActivity to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneUserRoleActivity(BLL.Users.UserRoleActivity item, bool performCascadeOperation )
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = ConfigurationInterface.CurrentUserID;
				item.LastModifiedByUserID = ConfigurationInterface.CurrentUserID;
				DAL.Users.UserRoleActivity itemDAL = new DAL.Users.UserRoleActivity();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Users.UserRoleActivity.UpdateOneUserRoleActivity(itemDAL, performCascadeOperation, ConfigurationInterface.DBOptions, ConfigurationInterface.DebugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.UpdateOneUserRoleActivity");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method updates UserRoleActivity data.</summary>
		///
		/// <param name="item">The UserRoleActivity to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneUserRoleActivity(BLL.Users.UserRoleActivity item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Users.UserRoleActivity itemDAL = new DAL.Users.UserRoleActivity();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Users.UserRoleActivity.UpdateOneUserRoleActivity(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Users.UpdateOneUserRoleActivity");
			}
		}
		#endregion Methods
	}
}