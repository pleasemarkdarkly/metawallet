
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
	/// <summary>This class is used to manage FriendlyError related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class FriendlyErrorManager
	{
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public FriendlyErrorManager()
		{
			//
			// constructor logic
			//
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------
		/// <summary>This method inserts FriendlyError data.</summary>
		///
		/// <param name="item">The FriendlyError to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneFriendlyError(BLL.UserExperience.FriendlyError item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.UserExperience.FriendlyErrorManager.AddOneFriendlyError(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method inserts FriendlyError data.</summary>
		///
		/// <param name="item">The FriendlyError to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneFriendlyError(BLL.UserExperience.FriendlyError item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.UserExperience.FriendlyError itemDAL = new DAL.UserExperience.FriendlyError();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.UserExperience.FriendlyError.AddOneFriendlyError(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.UserExperience.AddOneFriendlyError");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all FriendlyError data by a key.</summary>
		///
		/// <param name="errorNumber">A key for FriendlyError items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllFriendlyErrorDataByErrorNumber(int errorNumber)
		{
			// perform main method tasks
			BLL.UserExperience.FriendlyErrorManager.DeleteAllFriendlyErrorDataByErrorNumber(errorNumber, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all FriendlyError data by a key.</summary>
		///
		/// <param name="errorNumber">A key for FriendlyError items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllFriendlyErrorDataByErrorNumber(int errorNumber, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.UserExperience.FriendlyError.DeleteAllFriendlyErrorDataByErrorNumber(errorNumber, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.UserExperience.DeleteAllFriendlyErrorDataByErrorNumber");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all FriendlyError data by a key.</summary>
		///
		/// <param name="localeCode">A key for FriendlyError items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllFriendlyErrorDataByLocaleCode(int localeCode)
		{
			// perform main method tasks
			BLL.UserExperience.FriendlyErrorManager.DeleteAllFriendlyErrorDataByLocaleCode(localeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all FriendlyError data by a key.</summary>
		///
		/// <param name="localeCode">A key for FriendlyError items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllFriendlyErrorDataByLocaleCode(int localeCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.UserExperience.FriendlyError.DeleteAllFriendlyErrorDataByLocaleCode(localeCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.UserExperience.DeleteAllFriendlyErrorDataByLocaleCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes FriendlyError data.</summary>
		///
		/// <param name="item">The FriendlyError to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneFriendlyError(BLL.UserExperience.FriendlyError item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.UserExperience.FriendlyErrorManager.DeleteOneFriendlyError(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes FriendlyError data.</summary>
		///
		/// <param name="item">The FriendlyError to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneFriendlyError(BLL.UserExperience.FriendlyError item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.UserExperience.FriendlyError itemDAL = new DAL.UserExperience.FriendlyError();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.UserExperience.FriendlyError.DeleteOneFriendlyError(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = false;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.UserExperience.DeleteOneFriendlyError");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all FriendlyError data.</summary>
		///
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.FriendlyError> GetAllFriendlyErrorData(MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.UserExperience.FriendlyErrorManager.GetAllFriendlyErrorData(BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all FriendlyError data.</summary>
		///
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.FriendlyError> GetAllFriendlyErrorData()
		{
			// perform main method tasks
			return BLL.UserExperience.FriendlyErrorManager.GetAllFriendlyErrorData(BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all FriendlyError data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.FriendlyError> GetAllFriendlyErrorData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.UserExperience.FriendlyError> sortableList = new BLL.SortableList<BLL.UserExperience.FriendlyError>(DAL.UserExperience.FriendlyError.GetAllFriendlyErrorData(dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.UserExperience.FriendlyError loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.UserExperience.GetAllFriendlyErrorData");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all FriendlyError data by criteria.</summary>
		///
		/// <param name="lastModifiedDateStart">A key for FriendlyError items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for FriendlyError items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.FriendlyError> GetAllFriendlyErrorDataByCriteria(DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.UserExperience.FriendlyErrorManager.GetAllFriendlyErrorDataByCriteria(lastModifiedDateStart, lastModifiedDateEnd, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all FriendlyError data by criteria.</summary>
		///
		/// <param name="lastModifiedDateStart">A key for FriendlyError items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for FriendlyError items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.FriendlyError> GetAllFriendlyErrorDataByCriteria(DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd)
		{
			// perform main method tasks
			return BLL.UserExperience.FriendlyErrorManager.GetAllFriendlyErrorDataByCriteria(lastModifiedDateStart, lastModifiedDateEnd, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all FriendlyError data by criteria.</summary>
		///
		/// <param name="lastModifiedDateStart">A key for FriendlyError items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for FriendlyError items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.FriendlyError> GetAllFriendlyErrorDataByCriteria(DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.UserExperience.FriendlyError> sortableList = new BLL.SortableList<BLL.UserExperience.FriendlyError>(DAL.UserExperience.FriendlyError.GetAllFriendlyErrorDataByCriteria(lastModifiedDateStart, lastModifiedDateEnd, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.UserExperience.FriendlyError loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.UserExperience.GetAllFriendlyErrorDataByCriteria");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all FriendlyError data by a key.</summary>
		///
		/// <param name="errorNumber">A key for FriendlyError items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.FriendlyError> GetAllFriendlyErrorDataByErrorNumber(int errorNumber, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.UserExperience.FriendlyErrorManager.GetAllFriendlyErrorDataByErrorNumber(errorNumber, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all FriendlyError data by a key.</summary>
		///
		/// <param name="errorNumber">A key for FriendlyError items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.FriendlyError> GetAllFriendlyErrorDataByErrorNumber(int errorNumber)
		{
			// perform main method tasks
			return BLL.UserExperience.FriendlyErrorManager.GetAllFriendlyErrorDataByErrorNumber(errorNumber, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all FriendlyError data by a key.</summary>
		///
		/// <param name="errorNumber">A key for FriendlyError items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.FriendlyError> GetAllFriendlyErrorDataByErrorNumber(int errorNumber, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.UserExperience.FriendlyError> sortableList = new BLL.SortableList<BLL.UserExperience.FriendlyError>(DAL.UserExperience.FriendlyError.GetAllFriendlyErrorDataByErrorNumber(errorNumber, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.UserExperience.FriendlyError loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.UserExperience.GetAllFriendlyErrorDataByErrorNumber");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all FriendlyError data by a key.</summary>
		///
		/// <param name="localeCode">A key for FriendlyError items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.FriendlyError> GetAllFriendlyErrorDataByLocaleCode(int localeCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.UserExperience.FriendlyErrorManager.GetAllFriendlyErrorDataByLocaleCode(localeCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all FriendlyError data by a key.</summary>
		///
		/// <param name="localeCode">A key for FriendlyError items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.FriendlyError> GetAllFriendlyErrorDataByLocaleCode(int localeCode)
		{
			// perform main method tasks
			return BLL.UserExperience.FriendlyErrorManager.GetAllFriendlyErrorDataByLocaleCode(localeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all FriendlyError data by a key.</summary>
		///
		/// <param name="localeCode">A key for FriendlyError items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.FriendlyError> GetAllFriendlyErrorDataByLocaleCode(int localeCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.UserExperience.FriendlyError> sortableList = new BLL.SortableList<BLL.UserExperience.FriendlyError>(DAL.UserExperience.FriendlyError.GetAllFriendlyErrorDataByLocaleCode(localeCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.UserExperience.FriendlyError loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.UserExperience.GetAllFriendlyErrorDataByLocaleCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all FriendlyError data by criteria.</summary>
		///
		/// <param name="lastModifiedDateStart">A key for FriendlyError items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for FriendlyError items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.FriendlyError> GetManyFriendlyErrorDataByCriteria(DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.UserExperience.FriendlyErrorManager.GetManyFriendlyErrorDataByCriteria(lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all FriendlyError data by criteria.</summary>
		///
		/// <param name="lastModifiedDateStart">A key for FriendlyError items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for FriendlyError items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.UserExperience.FriendlyError> GetManyFriendlyErrorDataByCriteria(DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.UserExperience.FriendlyError> sortableList = new BLL.SortableList<BLL.UserExperience.FriendlyError>(DAL.UserExperience.FriendlyError.GetManyFriendlyErrorDataByCriteria(lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.UserExperience.FriendlyError loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.UserExperience.GetManyFriendlyErrorDataByCriteria");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single FriendlyError by an index.</summary>
		///
		/// <param name="errorNumber">The index for FriendlyError to be fetched</param>
		/// <param name="localeCode">The index for FriendlyError to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.UserExperience.FriendlyError GetOneFriendlyError(int errorNumber, int localeCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.UserExperience.FriendlyErrorManager.GetOneFriendlyError(errorNumber, localeCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single FriendlyError by an index.</summary>
		///
		/// <param name="errorNumber">The index for FriendlyError to be fetched</param>
		/// <param name="localeCode">The index for FriendlyError to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.UserExperience.FriendlyError GetOneFriendlyError(int errorNumber, int localeCode)
		{
			// perform main method tasks
			return BLL.UserExperience.FriendlyErrorManager.GetOneFriendlyError(errorNumber, localeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single FriendlyError by an index.</summary>
		///
		/// <param name="errorNumber">The index for FriendlyError to be fetched</param>
		/// <param name="localeCode">The index for FriendlyError to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.UserExperience.FriendlyError GetOneFriendlyError(int errorNumber, int localeCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.UserExperience.FriendlyError itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.UserExperience.FriendlyError)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.UserExperience.FriendlyError.GetCacheKey(typeof(BLL.UserExperience.FriendlyError), "PrimaryKey", errorNumber.ToString() + ", " + localeCode.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.UserExperience.FriendlyError)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.UserExperience.FriendlyError item = DAL.UserExperience.FriendlyError.GetOneFriendlyError(errorNumber, localeCode, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.UserExperience.FriendlyError();
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
				throw Utility.CustomAppException.WrapException(ex, "BLL.UserExperience.GetOneFriendlyError");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates FriendlyError data.</summary>
		///
		/// <param name="item">The FriendlyError to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneFriendlyError(BLL.UserExperience.FriendlyError item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.UserExperience.FriendlyErrorManager.UpdateOneFriendlyError(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates FriendlyError data.</summary>
		///
		/// <param name="item">The FriendlyError to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneFriendlyError(BLL.UserExperience.FriendlyError item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.UserExperience.FriendlyError itemDAL = new DAL.UserExperience.FriendlyError();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.UserExperience.FriendlyError.UpdateOneFriendlyError(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.UserExperience.UpdateOneFriendlyError");
			}
		}
		#endregion Methods
	}
}