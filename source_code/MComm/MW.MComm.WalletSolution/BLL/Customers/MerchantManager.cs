
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
using MW.MComm.WalletSolution.BLL.Customers;
using MOD.Data;
using MW.MComm.WalletSolution.BLL.Config;
using BLL = MW.MComm.WalletSolution.BLL;
using DAL = MW.MComm.WalletSolution.DAL;
using Utility = MW.MComm.WalletSolution.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
namespace MW.MComm.WalletSolution.BLL.Customers
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage Merchant related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class MerchantManager
	{
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public MerchantManager()
		{
			//
			// constructor logic
			//
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------
		/// <summary>This method inserts Merchant data.</summary>
		///
		/// <param name="item">The Merchant to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneMerchant(BLL.Customers.Merchant item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Customers.MerchantManager.AddOneMerchant(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method inserts Merchant data.</summary>
		///
		/// <param name="item">The Merchant to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneMerchant(BLL.Customers.Merchant item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Customers.Merchant itemDAL = new DAL.Customers.Merchant();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Customers.Merchant.AddOneMerchant(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.AddOneMerchant");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Merchant data by a key.</summary>
		///
		/// <param name="currencyCode">A key for Merchant items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllMerchantDataByCurrencyCode(int currencyCode)
		{
			// perform main method tasks
			BLL.Customers.MerchantManager.DeleteAllMerchantDataByCurrencyCode(currencyCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Merchant data by a key.</summary>
		///
		/// <param name="currencyCode">A key for Merchant items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllMerchantDataByCurrencyCode(int currencyCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Customers.Merchant.DeleteAllMerchantDataByCurrencyCode(currencyCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.DeleteAllMerchantDataByCurrencyCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Merchant data by a key.</summary>
		///
		/// <param name="dateFormatCode">A key for Merchant items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllMerchantDataByDateFormatCode(int dateFormatCode)
		{
			// perform main method tasks
			BLL.Customers.MerchantManager.DeleteAllMerchantDataByDateFormatCode(dateFormatCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Merchant data by a key.</summary>
		///
		/// <param name="dateFormatCode">A key for Merchant items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllMerchantDataByDateFormatCode(int dateFormatCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Customers.Merchant.DeleteAllMerchantDataByDateFormatCode(dateFormatCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.DeleteAllMerchantDataByDateFormatCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Merchant data by a key.</summary>
		///
		/// <param name="localeCode">A key for Merchant items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllMerchantDataByLocaleCode(int localeCode)
		{
			// perform main method tasks
			BLL.Customers.MerchantManager.DeleteAllMerchantDataByLocaleCode(localeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Merchant data by a key.</summary>
		///
		/// <param name="localeCode">A key for Merchant items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllMerchantDataByLocaleCode(int localeCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Customers.Merchant.DeleteAllMerchantDataByLocaleCode(localeCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.DeleteAllMerchantDataByLocaleCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Merchant data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for Merchant items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllMerchantDataByMetaPartnerID(Guid metaPartnerID)
		{
			// perform main method tasks
			BLL.Customers.MerchantManager.DeleteAllMerchantDataByMetaPartnerID(metaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Merchant data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for Merchant items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllMerchantDataByMetaPartnerID(Guid metaPartnerID, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Customers.Merchant.DeleteAllMerchantDataByMetaPartnerID(metaPartnerID, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.DeleteAllMerchantDataByMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Merchant data by a key.</summary>
		///
		/// <param name="metaPartnerSubTypeCode">A key for Merchant items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllMerchantDataByMetaPartnerSubTypeCode(int metaPartnerSubTypeCode)
		{
			// perform main method tasks
			BLL.Customers.MerchantManager.DeleteAllMerchantDataByMetaPartnerSubTypeCode(metaPartnerSubTypeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Merchant data by a key.</summary>
		///
		/// <param name="metaPartnerSubTypeCode">A key for Merchant items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllMerchantDataByMetaPartnerSubTypeCode(int metaPartnerSubTypeCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Customers.Merchant.DeleteAllMerchantDataByMetaPartnerSubTypeCode(metaPartnerSubTypeCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.DeleteAllMerchantDataByMetaPartnerSubTypeCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes Merchant data.</summary>
		///
		/// <param name="item">The Merchant to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneMerchant(BLL.Customers.Merchant item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Customers.MerchantManager.DeleteOneMerchant(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes Merchant data.</summary>
		///
		/// <param name="item">The Merchant to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneMerchant(BLL.Customers.Merchant item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Customers.Merchant itemDAL = new DAL.Customers.Merchant();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Customers.Merchant.DeleteOneMerchant(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = false;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.DeleteOneMerchant");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Merchant data.</summary>
		///
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Merchant> GetAllMerchantData(MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.MerchantManager.GetAllMerchantData(BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Merchant data.</summary>
		///
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Merchant> GetAllMerchantData()
		{
			// perform main method tasks
			return BLL.Customers.MerchantManager.GetAllMerchantData(BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Merchant data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Merchant> GetAllMerchantData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Customers.Merchant> sortableList = new BLL.SortableList<BLL.Customers.Merchant>(DAL.Customers.Merchant.GetAllMerchantData(dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Customers.Merchant loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetAllMerchantData");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Merchant data by criteria.</summary>
		///
		/// <param name="localeCode">A key for Merchant items to be fetched</param>
		/// <param name="currencyCode">A key for Merchant items to be fetched</param>
		/// <param name="dateFormatCode">A key for Merchant items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Merchant items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Merchant items to be fetched</param>
		/// <param name="metaPartnerName">A key for Merchant items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Merchant> GetAllMerchantDataByCriteria(int? localeCode, int? currencyCode, int? dateFormatCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, string metaPartnerName, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.MerchantManager.GetAllMerchantDataByCriteria(localeCode, currencyCode, dateFormatCode, lastModifiedDateStart, lastModifiedDateEnd, metaPartnerName, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Merchant data by criteria.</summary>
		///
		/// <param name="localeCode">A key for Merchant items to be fetched</param>
		/// <param name="currencyCode">A key for Merchant items to be fetched</param>
		/// <param name="dateFormatCode">A key for Merchant items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Merchant items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Merchant items to be fetched</param>
		/// <param name="metaPartnerName">A key for Merchant items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Merchant> GetAllMerchantDataByCriteria(int? localeCode, int? currencyCode, int? dateFormatCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, string metaPartnerName)
		{
			// perform main method tasks
			return BLL.Customers.MerchantManager.GetAllMerchantDataByCriteria(localeCode, currencyCode, dateFormatCode, lastModifiedDateStart, lastModifiedDateEnd, metaPartnerName, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Merchant data by criteria.</summary>
		///
		/// <param name="localeCode">A key for Merchant items to be fetched</param>
		/// <param name="currencyCode">A key for Merchant items to be fetched</param>
		/// <param name="dateFormatCode">A key for Merchant items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Merchant items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Merchant items to be fetched</param>
		/// <param name="metaPartnerName">A key for Merchant items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Merchant> GetAllMerchantDataByCriteria(int? localeCode, int? currencyCode, int? dateFormatCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, string metaPartnerName, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Customers.Merchant> sortableList = new BLL.SortableList<BLL.Customers.Merchant>(DAL.Customers.Merchant.GetAllMerchantDataByCriteria(localeCode, currencyCode, dateFormatCode, lastModifiedDateStart, lastModifiedDateEnd, metaPartnerName, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Customers.Merchant loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetAllMerchantDataByCriteria");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Merchant data by a key.</summary>
		///
		/// <param name="currencyCode">A key for Merchant items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Merchant> GetAllMerchantDataByCurrencyCode(int currencyCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.MerchantManager.GetAllMerchantDataByCurrencyCode(currencyCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Merchant data by a key.</summary>
		///
		/// <param name="currencyCode">A key for Merchant items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Merchant> GetAllMerchantDataByCurrencyCode(int currencyCode)
		{
			// perform main method tasks
			return BLL.Customers.MerchantManager.GetAllMerchantDataByCurrencyCode(currencyCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Merchant data by a key.</summary>
		///
		/// <param name="currencyCode">A key for Merchant items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Merchant> GetAllMerchantDataByCurrencyCode(int currencyCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Customers.Merchant> sortableList = new BLL.SortableList<BLL.Customers.Merchant>(DAL.Customers.Merchant.GetAllMerchantDataByCurrencyCode(currencyCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Customers.Merchant loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetAllMerchantDataByCurrencyCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Merchant data by a key.</summary>
		///
		/// <param name="dateFormatCode">A key for Merchant items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Merchant> GetAllMerchantDataByDateFormatCode(int dateFormatCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.MerchantManager.GetAllMerchantDataByDateFormatCode(dateFormatCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Merchant data by a key.</summary>
		///
		/// <param name="dateFormatCode">A key for Merchant items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Merchant> GetAllMerchantDataByDateFormatCode(int dateFormatCode)
		{
			// perform main method tasks
			return BLL.Customers.MerchantManager.GetAllMerchantDataByDateFormatCode(dateFormatCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Merchant data by a key.</summary>
		///
		/// <param name="dateFormatCode">A key for Merchant items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Merchant> GetAllMerchantDataByDateFormatCode(int dateFormatCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Customers.Merchant> sortableList = new BLL.SortableList<BLL.Customers.Merchant>(DAL.Customers.Merchant.GetAllMerchantDataByDateFormatCode(dateFormatCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Customers.Merchant loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetAllMerchantDataByDateFormatCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Merchant data by a key.</summary>
		///
		/// <param name="localeCode">A key for Merchant items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Merchant> GetAllMerchantDataByLocaleCode(int localeCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.MerchantManager.GetAllMerchantDataByLocaleCode(localeCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Merchant data by a key.</summary>
		///
		/// <param name="localeCode">A key for Merchant items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Merchant> GetAllMerchantDataByLocaleCode(int localeCode)
		{
			// perform main method tasks
			return BLL.Customers.MerchantManager.GetAllMerchantDataByLocaleCode(localeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Merchant data by a key.</summary>
		///
		/// <param name="localeCode">A key for Merchant items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Merchant> GetAllMerchantDataByLocaleCode(int localeCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Customers.Merchant> sortableList = new BLL.SortableList<BLL.Customers.Merchant>(DAL.Customers.Merchant.GetAllMerchantDataByLocaleCode(localeCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Customers.Merchant loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetAllMerchantDataByLocaleCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Merchant data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for Merchant items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Merchant> GetAllMerchantDataByMetaPartnerID(Guid metaPartnerID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.MerchantManager.GetAllMerchantDataByMetaPartnerID(metaPartnerID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Merchant data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for Merchant items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Merchant> GetAllMerchantDataByMetaPartnerID(Guid metaPartnerID)
		{
			// perform main method tasks
			return BLL.Customers.MerchantManager.GetAllMerchantDataByMetaPartnerID(metaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Merchant data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for Merchant items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Merchant> GetAllMerchantDataByMetaPartnerID(Guid metaPartnerID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Customers.Merchant> sortableList = new BLL.SortableList<BLL.Customers.Merchant>(DAL.Customers.Merchant.GetAllMerchantDataByMetaPartnerID(metaPartnerID, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Customers.Merchant loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetAllMerchantDataByMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Merchant data by a key.</summary>
		///
		/// <param name="metaPartnerSubTypeCode">A key for Merchant items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Merchant> GetAllMerchantDataByMetaPartnerSubTypeCode(int metaPartnerSubTypeCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.MerchantManager.GetAllMerchantDataByMetaPartnerSubTypeCode(metaPartnerSubTypeCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Merchant data by a key.</summary>
		///
		/// <param name="metaPartnerSubTypeCode">A key for Merchant items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Merchant> GetAllMerchantDataByMetaPartnerSubTypeCode(int metaPartnerSubTypeCode)
		{
			// perform main method tasks
			return BLL.Customers.MerchantManager.GetAllMerchantDataByMetaPartnerSubTypeCode(metaPartnerSubTypeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Merchant data by a key.</summary>
		///
		/// <param name="metaPartnerSubTypeCode">A key for Merchant items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Merchant> GetAllMerchantDataByMetaPartnerSubTypeCode(int metaPartnerSubTypeCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Customers.Merchant> sortableList = new BLL.SortableList<BLL.Customers.Merchant>(DAL.Customers.Merchant.GetAllMerchantDataByMetaPartnerSubTypeCode(metaPartnerSubTypeCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Customers.Merchant loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetAllMerchantDataByMetaPartnerSubTypeCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Merchant data by criteria.</summary>
		///
		/// <param name="localeCode">A key for Merchant items to be fetched</param>
		/// <param name="currencyCode">A key for Merchant items to be fetched</param>
		/// <param name="dateFormatCode">A key for Merchant items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Merchant items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Merchant items to be fetched</param>
		/// <param name="metaPartnerName">A key for Merchant items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Merchant> GetManyMerchantDataByCriteria(int? localeCode, int? currencyCode, int? dateFormatCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, string metaPartnerName, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.MerchantManager.GetManyMerchantDataByCriteria(localeCode, currencyCode, dateFormatCode, lastModifiedDateStart, lastModifiedDateEnd, metaPartnerName, out totalRecords, out maximumListSizeExceeded, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Merchant data by criteria.</summary>
		///
		/// <param name="localeCode">A key for Merchant items to be fetched</param>
		/// <param name="currencyCode">A key for Merchant items to be fetched</param>
		/// <param name="dateFormatCode">A key for Merchant items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Merchant items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Merchant items to be fetched</param>
		/// <param name="metaPartnerName">A key for Merchant items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Merchant> GetManyMerchantDataByCriteria(int? localeCode, int? currencyCode, int? dateFormatCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, string metaPartnerName, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Customers.Merchant> sortableList = new BLL.SortableList<BLL.Customers.Merchant>(DAL.Customers.Merchant.GetManyMerchantDataByCriteria(localeCode, currencyCode, dateFormatCode, lastModifiedDateStart, lastModifiedDateEnd, metaPartnerName, out totalRecords, out maximumListSizeExceeded, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Customers.Merchant loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetManyMerchantDataByCriteria");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single Merchant by an index.</summary>
		///
		/// <param name="metaPartnerID">The index for Merchant to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Customers.Merchant GetOneMerchant(Guid metaPartnerID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.MerchantManager.GetOneMerchant(metaPartnerID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single Merchant by an index.</summary>
		///
		/// <param name="metaPartnerID">The index for Merchant to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Customers.Merchant GetOneMerchant(Guid metaPartnerID)
		{
			// perform main method tasks
			return BLL.Customers.MerchantManager.GetOneMerchant(metaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single Merchant by an index.</summary>
		///
		/// <param name="metaPartnerID">The index for Merchant to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Customers.Merchant GetOneMerchant(Guid metaPartnerID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.Customers.Merchant itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.Customers.Merchant)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.Customers.Merchant.GetCacheKey(typeof(BLL.Customers.Merchant), "PrimaryKey", metaPartnerID.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.Customers.Merchant)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.Customers.Merchant item = DAL.Customers.Merchant.GetOneMerchant(metaPartnerID, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.Customers.Merchant();
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
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetOneMerchant");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates Merchant data.</summary>
		///
		/// <param name="item">The Merchant to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneMerchant(BLL.Customers.Merchant item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Customers.MerchantManager.UpdateOneMerchant(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates Merchant data.</summary>
		///
		/// <param name="item">The Merchant to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneMerchant(BLL.Customers.Merchant item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Customers.Merchant itemDAL = new DAL.Customers.Merchant();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Customers.Merchant.UpdateOneMerchant(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.UpdateOneMerchant");
			}
		}
		#endregion Methods
	}
}