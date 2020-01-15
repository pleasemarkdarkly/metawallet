
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
using MW.MComm.WalletSolution.BLL.UserExperience;
using MOD.Data;
using MW.MComm.WalletSolution.BLL.Config;
using BLL = MW.MComm.WalletSolution.BLL;
using DAL = MW.MComm.WalletSolution.DAL;
using Utility = MW.MComm.WalletSolution.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
namespace MW.MComm.WalletSolution.BLL.UserExperience
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage AdminHelp related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class AdminHelpManager
	{
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public AdminHelpManager()
		{
			//
			// constructor logic
			//
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------
		/// <summary>This method inserts AdminHelp data.</summary>
		///
		/// <param name="item">The AdminHelp to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneAdminHelp(BLL.UserExperience.AdminHelp item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.UserExperience.AdminHelpManager.AddOneAdminHelp(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method inserts AdminHelp data.</summary>
		///
		/// <param name="item">The AdminHelp to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneAdminHelp(BLL.UserExperience.AdminHelp item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.UserExperience.AdminHelp itemDAL = new DAL.UserExperience.AdminHelp();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.UserExperience.AdminHelp.AddOneAdminHelp(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.UserExperience.AddOneAdminHelp");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all AdminHelp data by a key.</summary>
		///
		/// <param name="activityCode">A key for AdminHelp items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllAdminHelpDataByActivityCode(int activityCode)
		{
			// perform main method tasks
			BLL.UserExperience.AdminHelpManager.DeleteAllAdminHelpDataByActivityCode(activityCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all AdminHelp data by a key.</summary>
		///
		/// <param name="activityCode">A key for AdminHelp items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllAdminHelpDataByActivityCode(int activityCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.UserExperience.AdminHelp.DeleteAllAdminHelpDataByActivityCode(activityCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.UserExperience.DeleteAllAdminHelpDataByActivityCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all AdminHelp data by a key.</summary>
		///
		/// <param name="localeCode">A key for AdminHelp items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllAdminHelpDataByLocaleCode(int localeCode)
		{
			// perform main method tasks
			BLL.UserExperience.AdminHelpManager.DeleteAllAdminHelpDataByLocaleCode(localeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all AdminHelp data by a key.</summary>
		///
		/// <param name="localeCode">A key for AdminHelp items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllAdminHelpDataByLocaleCode(int localeCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.UserExperience.AdminHelp.DeleteAllAdminHelpDataByLocaleCode(localeCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.UserExperience.DeleteAllAdminHelpDataByLocaleCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes AdminHelp data.</summary>
		///
		/// <param name="item">The AdminHelp to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneAdminHelp(BLL.UserExperience.AdminHelp item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.UserExperience.AdminHelpManager.DeleteOneAdminHelp(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes AdminHelp data.</summary>
		///
		/// <param name="item">The AdminHelp to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneAdminHelp(BLL.UserExperience.AdminHelp item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.UserExperience.AdminHelp itemDAL = new DAL.UserExperience.AdminHelp();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.UserExperience.AdminHelp.DeleteOneAdminHelp(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = false;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.UserExperience.DeleteOneAdminHelp");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all AdminHelp data.</summary>
		///
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.AdminHelp> GetAllAdminHelpData(MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.UserExperience.AdminHelpManager.GetAllAdminHelpData(BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all AdminHelp data.</summary>
		///
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.AdminHelp> GetAllAdminHelpData()
		{
			// perform main method tasks
			return BLL.UserExperience.AdminHelpManager.GetAllAdminHelpData(BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all AdminHelp data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.AdminHelp> GetAllAdminHelpData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.UserExperience.AdminHelp> sortableList = new BLL.SortableList<BLL.UserExperience.AdminHelp>(DAL.UserExperience.AdminHelp.GetAllAdminHelpData(dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.UserExperience.AdminHelp loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.UserExperience.GetAllAdminHelpData");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all AdminHelp data by a key.</summary>
		///
		/// <param name="activityCode">A key for AdminHelp items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.AdminHelp> GetAllAdminHelpDataByActivityCode(int activityCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.UserExperience.AdminHelpManager.GetAllAdminHelpDataByActivityCode(activityCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all AdminHelp data by a key.</summary>
		///
		/// <param name="activityCode">A key for AdminHelp items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.AdminHelp> GetAllAdminHelpDataByActivityCode(int activityCode)
		{
			// perform main method tasks
			return BLL.UserExperience.AdminHelpManager.GetAllAdminHelpDataByActivityCode(activityCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all AdminHelp data by a key.</summary>
		///
		/// <param name="activityCode">A key for AdminHelp items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.AdminHelp> GetAllAdminHelpDataByActivityCode(int activityCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.UserExperience.AdminHelp> sortableList = new BLL.SortableList<BLL.UserExperience.AdminHelp>(DAL.UserExperience.AdminHelp.GetAllAdminHelpDataByActivityCode(activityCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.UserExperience.AdminHelp loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.UserExperience.GetAllAdminHelpDataByActivityCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all AdminHelp data by criteria.</summary>
		///
		/// <param name="adminHelpTitle">A key for AdminHelp items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for AdminHelp items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for AdminHelp items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.AdminHelp> GetAllAdminHelpDataByCriteria(string adminHelpTitle, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.UserExperience.AdminHelpManager.GetAllAdminHelpDataByCriteria(adminHelpTitle, lastModifiedDateStart, lastModifiedDateEnd, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all AdminHelp data by criteria.</summary>
		///
		/// <param name="adminHelpTitle">A key for AdminHelp items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for AdminHelp items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for AdminHelp items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.AdminHelp> GetAllAdminHelpDataByCriteria(string adminHelpTitle, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd)
		{
			// perform main method tasks
			return BLL.UserExperience.AdminHelpManager.GetAllAdminHelpDataByCriteria(adminHelpTitle, lastModifiedDateStart, lastModifiedDateEnd, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all AdminHelp data by criteria.</summary>
		///
		/// <param name="adminHelpTitle">A key for AdminHelp items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for AdminHelp items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for AdminHelp items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.AdminHelp> GetAllAdminHelpDataByCriteria(string adminHelpTitle, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.UserExperience.AdminHelp> sortableList = new BLL.SortableList<BLL.UserExperience.AdminHelp>(DAL.UserExperience.AdminHelp.GetAllAdminHelpDataByCriteria(adminHelpTitle, lastModifiedDateStart, lastModifiedDateEnd, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.UserExperience.AdminHelp loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.UserExperience.GetAllAdminHelpDataByCriteria");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all AdminHelp data by a key.</summary>
		///
		/// <param name="localeCode">A key for AdminHelp items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.AdminHelp> GetAllAdminHelpDataByLocaleCode(int localeCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.UserExperience.AdminHelpManager.GetAllAdminHelpDataByLocaleCode(localeCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all AdminHelp data by a key.</summary>
		///
		/// <param name="localeCode">A key for AdminHelp items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.AdminHelp> GetAllAdminHelpDataByLocaleCode(int localeCode)
		{
			// perform main method tasks
			return BLL.UserExperience.AdminHelpManager.GetAllAdminHelpDataByLocaleCode(localeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all AdminHelp data by a key.</summary>
		///
		/// <param name="localeCode">A key for AdminHelp items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.AdminHelp> GetAllAdminHelpDataByLocaleCode(int localeCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.UserExperience.AdminHelp> sortableList = new BLL.SortableList<BLL.UserExperience.AdminHelp>(DAL.UserExperience.AdminHelp.GetAllAdminHelpDataByLocaleCode(localeCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.UserExperience.AdminHelp loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.UserExperience.GetAllAdminHelpDataByLocaleCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all AdminHelp data by criteria.</summary>
		///
		/// <param name="adminHelpTitle">A key for AdminHelp items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for AdminHelp items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for AdminHelp items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.AdminHelp> GetManyAdminHelpDataByCriteria(string adminHelpTitle, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.UserExperience.AdminHelpManager.GetManyAdminHelpDataByCriteria(adminHelpTitle, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all AdminHelp data by criteria.</summary>
		///
		/// <param name="adminHelpTitle">A key for AdminHelp items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for AdminHelp items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for AdminHelp items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.AdminHelp> GetManyAdminHelpDataByCriteria(string adminHelpTitle, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.UserExperience.AdminHelp> sortableList = new BLL.SortableList<BLL.UserExperience.AdminHelp>(DAL.UserExperience.AdminHelp.GetManyAdminHelpDataByCriteria(adminHelpTitle, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.UserExperience.AdminHelp loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.UserExperience.GetManyAdminHelpDataByCriteria");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single AdminHelp by an index.</summary>
		///
		/// <param name="activityCode">The index for AdminHelp to be fetched</param>
		/// <param name="localeCode">The index for AdminHelp to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.UserExperience.AdminHelp GetOneAdminHelp(int activityCode, int localeCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.UserExperience.AdminHelpManager.GetOneAdminHelp(activityCode, localeCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single AdminHelp by an index.</summary>
		///
		/// <param name="activityCode">The index for AdminHelp to be fetched</param>
		/// <param name="localeCode">The index for AdminHelp to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.UserExperience.AdminHelp GetOneAdminHelp(int activityCode, int localeCode)
		{
			// perform main method tasks
			return BLL.UserExperience.AdminHelpManager.GetOneAdminHelp(activityCode, localeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single AdminHelp by an index.</summary>
		///
		/// <param name="activityCode">The index for AdminHelp to be fetched</param>
		/// <param name="localeCode">The index for AdminHelp to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.UserExperience.AdminHelp GetOneAdminHelp(int activityCode, int localeCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.UserExperience.AdminHelp itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.UserExperience.AdminHelp)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.UserExperience.AdminHelp.GetCacheKey(typeof(BLL.UserExperience.AdminHelp), "PrimaryKey", activityCode.ToString() + ", " + localeCode.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.UserExperience.AdminHelp)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.UserExperience.AdminHelp item = DAL.UserExperience.AdminHelp.GetOneAdminHelp(activityCode, localeCode, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.UserExperience.AdminHelp();
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
				throw Utility.CustomAppException.WrapException(ex, "BLL.UserExperience.GetOneAdminHelp");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates AdminHelp data.</summary>
		///
		/// <param name="item">The AdminHelp to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneAdminHelp(BLL.UserExperience.AdminHelp item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.UserExperience.AdminHelpManager.UpdateOneAdminHelp(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates AdminHelp data.</summary>
		///
		/// <param name="item">The AdminHelp to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneAdminHelp(BLL.UserExperience.AdminHelp item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.UserExperience.AdminHelp itemDAL = new DAL.UserExperience.AdminHelp();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.UserExperience.AdminHelp.UpdateOneAdminHelp(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.UserExperience.UpdateOneAdminHelp");
			}
		}
		#endregion Methods
	}
}