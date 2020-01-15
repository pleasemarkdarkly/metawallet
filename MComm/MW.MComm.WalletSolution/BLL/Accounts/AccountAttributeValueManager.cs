
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
	/// <summary>This class is used to manage AccountAttributeValue related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class AccountAttributeValueManager
	{
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public AccountAttributeValueManager()
		{
			//
			// constructor logic
			//
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------
		/// <summary>This method deletes all AccountAttributeValue data by a key.</summary>
		///
		/// <param name="accountID">A key for AccountAttributeValue items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllAccountAttributeValueDataByAccountID(Guid accountID)
		{
			// perform main method tasks
			BLL.Accounts.AccountAttributeValueManager.DeleteAllAccountAttributeValueDataByAccountID(accountID, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all AccountAttributeValue data by a key.</summary>
		///
		/// <param name="accountID">A key for AccountAttributeValue items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllAccountAttributeValueDataByAccountID(Guid accountID, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Accounts.AccountAttributeValue.DeleteAllAccountAttributeValueDataByAccountID(accountID, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.DeleteAllAccountAttributeValueDataByAccountID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all AccountAttributeValue data by a key.</summary>
		///
		/// <param name="baseAttributeID">A key for AccountAttributeValue items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllAccountAttributeValueDataByBaseAttributeID(Guid baseAttributeID)
		{
			// perform main method tasks
			BLL.Accounts.AccountAttributeValueManager.DeleteAllAccountAttributeValueDataByBaseAttributeID(baseAttributeID, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all AccountAttributeValue data by a key.</summary>
		///
		/// <param name="baseAttributeID">A key for AccountAttributeValue items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllAccountAttributeValueDataByBaseAttributeID(Guid baseAttributeID, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Accounts.AccountAttributeValue.DeleteAllAccountAttributeValueDataByBaseAttributeID(baseAttributeID, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.DeleteAllAccountAttributeValueDataByBaseAttributeID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes AccountAttributeValue data.</summary>
		///
		/// <param name="item">The AccountAttributeValue to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneAccountAttributeValue(BLL.Accounts.AccountAttributeValue item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Accounts.AccountAttributeValueManager.DeleteOneAccountAttributeValue(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes AccountAttributeValue data.</summary>
		///
		/// <param name="item">The AccountAttributeValue to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneAccountAttributeValue(BLL.Accounts.AccountAttributeValue item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Accounts.AccountAttributeValue itemDAL = new DAL.Accounts.AccountAttributeValue();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Accounts.AccountAttributeValue.DeleteOneAccountAttributeValue(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = false;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.DeleteOneAccountAttributeValue");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all AccountAttributeValue data.</summary>
		///
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.AccountAttributeValue> GetAllAccountAttributeValueData(MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.AccountAttributeValueManager.GetAllAccountAttributeValueData(BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all AccountAttributeValue data.</summary>
		///
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.AccountAttributeValue> GetAllAccountAttributeValueData()
		{
			// perform main method tasks
			return BLL.Accounts.AccountAttributeValueManager.GetAllAccountAttributeValueData(BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all AccountAttributeValue data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.AccountAttributeValue> GetAllAccountAttributeValueData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Accounts.AccountAttributeValue> sortableList = new BLL.SortableList<BLL.Accounts.AccountAttributeValue>(DAL.Accounts.AccountAttributeValue.GetAllAccountAttributeValueData(dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Accounts.AccountAttributeValue loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetAllAccountAttributeValueData");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all AccountAttributeValue data by a key.</summary>
		///
		/// <param name="accountID">A key for AccountAttributeValue items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.AccountAttributeValue> GetAllAccountAttributeValueDataByAccountID(Guid accountID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.AccountAttributeValueManager.GetAllAccountAttributeValueDataByAccountID(accountID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all AccountAttributeValue data by a key.</summary>
		///
		/// <param name="accountID">A key for AccountAttributeValue items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.AccountAttributeValue> GetAllAccountAttributeValueDataByAccountID(Guid accountID)
		{
			// perform main method tasks
			return BLL.Accounts.AccountAttributeValueManager.GetAllAccountAttributeValueDataByAccountID(accountID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all AccountAttributeValue data by a key.</summary>
		///
		/// <param name="accountID">A key for AccountAttributeValue items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.AccountAttributeValue> GetAllAccountAttributeValueDataByAccountID(Guid accountID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Accounts.AccountAttributeValue> sortableList = new BLL.SortableList<BLL.Accounts.AccountAttributeValue>(DAL.Accounts.AccountAttributeValue.GetAllAccountAttributeValueDataByAccountID(accountID, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Accounts.AccountAttributeValue loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetAllAccountAttributeValueDataByAccountID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all AccountAttributeValue data by a key.</summary>
		///
		/// <param name="baseAttributeID">A key for AccountAttributeValue items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.AccountAttributeValue> GetAllAccountAttributeValueDataByBaseAttributeID(Guid baseAttributeID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.AccountAttributeValueManager.GetAllAccountAttributeValueDataByBaseAttributeID(baseAttributeID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all AccountAttributeValue data by a key.</summary>
		///
		/// <param name="baseAttributeID">A key for AccountAttributeValue items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.AccountAttributeValue> GetAllAccountAttributeValueDataByBaseAttributeID(Guid baseAttributeID)
		{
			// perform main method tasks
			return BLL.Accounts.AccountAttributeValueManager.GetAllAccountAttributeValueDataByBaseAttributeID(baseAttributeID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all AccountAttributeValue data by a key.</summary>
		///
		/// <param name="baseAttributeID">A key for AccountAttributeValue items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.AccountAttributeValue> GetAllAccountAttributeValueDataByBaseAttributeID(Guid baseAttributeID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Accounts.AccountAttributeValue> sortableList = new BLL.SortableList<BLL.Accounts.AccountAttributeValue>(DAL.Accounts.AccountAttributeValue.GetAllAccountAttributeValueDataByBaseAttributeID(baseAttributeID, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Accounts.AccountAttributeValue loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetAllAccountAttributeValueDataByBaseAttributeID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all AccountAttributeValue data by criteria.</summary>
		///
		/// <param name="parameterValue">A key for AccountAttributeValue items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for AccountAttributeValue items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for AccountAttributeValue items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.AccountAttributeValue> GetAllAccountAttributeValueDataByCriteria(string parameterValue, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.AccountAttributeValueManager.GetAllAccountAttributeValueDataByCriteria(parameterValue, lastModifiedDateStart, lastModifiedDateEnd, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all AccountAttributeValue data by criteria.</summary>
		///
		/// <param name="parameterValue">A key for AccountAttributeValue items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for AccountAttributeValue items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for AccountAttributeValue items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.AccountAttributeValue> GetAllAccountAttributeValueDataByCriteria(string parameterValue, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd)
		{
			// perform main method tasks
			return BLL.Accounts.AccountAttributeValueManager.GetAllAccountAttributeValueDataByCriteria(parameterValue, lastModifiedDateStart, lastModifiedDateEnd, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all AccountAttributeValue data by criteria.</summary>
		///
		/// <param name="parameterValue">A key for AccountAttributeValue items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for AccountAttributeValue items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for AccountAttributeValue items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.AccountAttributeValue> GetAllAccountAttributeValueDataByCriteria(string parameterValue, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Accounts.AccountAttributeValue> sortableList = new BLL.SortableList<BLL.Accounts.AccountAttributeValue>(DAL.Accounts.AccountAttributeValue.GetAllAccountAttributeValueDataByCriteria(parameterValue, lastModifiedDateStart, lastModifiedDateEnd, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Accounts.AccountAttributeValue loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetAllAccountAttributeValueDataByCriteria");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all AccountAttributeValue data by criteria.</summary>
		///
		/// <param name="parameterValue">A key for AccountAttributeValue items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for AccountAttributeValue items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for AccountAttributeValue items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.AccountAttributeValue> GetManyAccountAttributeValueDataByCriteria(string parameterValue, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.AccountAttributeValueManager.GetManyAccountAttributeValueDataByCriteria(parameterValue, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all AccountAttributeValue data by criteria.</summary>
		///
		/// <param name="parameterValue">A key for AccountAttributeValue items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for AccountAttributeValue items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for AccountAttributeValue items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.AccountAttributeValue> GetManyAccountAttributeValueDataByCriteria(string parameterValue, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Accounts.AccountAttributeValue> sortableList = new BLL.SortableList<BLL.Accounts.AccountAttributeValue>(DAL.Accounts.AccountAttributeValue.GetManyAccountAttributeValueDataByCriteria(parameterValue, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Accounts.AccountAttributeValue loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetManyAccountAttributeValueDataByCriteria");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single AccountAttributeValue by an index.</summary>
		///
		/// <param name="accountAttributeValueID">The index for AccountAttributeValue to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Accounts.AccountAttributeValue GetOneAccountAttributeValue(Guid accountAttributeValueID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.AccountAttributeValueManager.GetOneAccountAttributeValue(accountAttributeValueID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single AccountAttributeValue by an index.</summary>
		///
		/// <param name="accountAttributeValueID">The index for AccountAttributeValue to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Accounts.AccountAttributeValue GetOneAccountAttributeValue(Guid accountAttributeValueID)
		{
			// perform main method tasks
			return BLL.Accounts.AccountAttributeValueManager.GetOneAccountAttributeValue(accountAttributeValueID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single AccountAttributeValue by an index.</summary>
		///
		/// <param name="accountAttributeValueID">The index for AccountAttributeValue to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Accounts.AccountAttributeValue GetOneAccountAttributeValue(Guid accountAttributeValueID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.Accounts.AccountAttributeValue itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.Accounts.AccountAttributeValue)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.Accounts.AccountAttributeValue.GetCacheKey(typeof(BLL.Accounts.AccountAttributeValue), "PrimaryKey", accountAttributeValueID.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.Accounts.AccountAttributeValue)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.Accounts.AccountAttributeValue item = DAL.Accounts.AccountAttributeValue.GetOneAccountAttributeValue(accountAttributeValueID, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.Accounts.AccountAttributeValue();
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
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetOneAccountAttributeValue");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method inserts or updates AccountAttributeValue data.</summary>
		///
		/// <param name="item">The AccountAttributeValue to be inserted or updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpsertOneAccountAttributeValue(BLL.Accounts.AccountAttributeValue item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Accounts.AccountAttributeValueManager.UpsertOneAccountAttributeValue(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method inserts or updates AccountAttributeValue data.</summary>
		///
		/// <param name="item">The AccountAttributeValue to be inserted or updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpsertOneAccountAttributeValue(BLL.Accounts.AccountAttributeValue item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Accounts.AccountAttributeValue itemDAL = new DAL.Accounts.AccountAttributeValue();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Accounts.AccountAttributeValue.UpsertOneAccountAttributeValue(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.UpsertOneAccountAttributeValue");
			}
		}
		#endregion Methods
	}
}