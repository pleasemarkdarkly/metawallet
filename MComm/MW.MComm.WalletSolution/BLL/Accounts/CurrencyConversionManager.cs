
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
	/// <summary>This class is used to manage CurrencyConversion related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class CurrencyConversionManager
	{
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public CurrencyConversionManager()
		{
			//
			// constructor logic
			//
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------
		/// <summary>This method deletes all CurrencyConversion data by a key.</summary>
		///
		/// <param name="convertFromCurrencyCode">A key for CurrencyConversion items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllCurrencyConversionDataByConvertFromCurrencyCode(int convertFromCurrencyCode)
		{
			// perform main method tasks
			BLL.Accounts.CurrencyConversionManager.DeleteAllCurrencyConversionDataByConvertFromCurrencyCode(convertFromCurrencyCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all CurrencyConversion data by a key.</summary>
		///
		/// <param name="convertFromCurrencyCode">A key for CurrencyConversion items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllCurrencyConversionDataByConvertFromCurrencyCode(int convertFromCurrencyCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Accounts.CurrencyConversion.DeleteAllCurrencyConversionDataByConvertFromCurrencyCode(convertFromCurrencyCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.DeleteAllCurrencyConversionDataByConvertFromCurrencyCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all CurrencyConversion data by a key.</summary>
		///
		/// <param name="convertToCurrencyCode">A key for CurrencyConversion items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllCurrencyConversionDataByConvertToCurrencyCode(int convertToCurrencyCode)
		{
			// perform main method tasks
			BLL.Accounts.CurrencyConversionManager.DeleteAllCurrencyConversionDataByConvertToCurrencyCode(convertToCurrencyCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all CurrencyConversion data by a key.</summary>
		///
		/// <param name="convertToCurrencyCode">A key for CurrencyConversion items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllCurrencyConversionDataByConvertToCurrencyCode(int convertToCurrencyCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Accounts.CurrencyConversion.DeleteAllCurrencyConversionDataByConvertToCurrencyCode(convertToCurrencyCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.DeleteAllCurrencyConversionDataByConvertToCurrencyCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all CurrencyConversion data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for CurrencyConversion items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllCurrencyConversionDataByMetaPartnerID(Guid metaPartnerID)
		{
			// perform main method tasks
			BLL.Accounts.CurrencyConversionManager.DeleteAllCurrencyConversionDataByMetaPartnerID(metaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all CurrencyConversion data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for CurrencyConversion items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllCurrencyConversionDataByMetaPartnerID(Guid metaPartnerID, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Accounts.CurrencyConversion.DeleteAllCurrencyConversionDataByMetaPartnerID(metaPartnerID, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.DeleteAllCurrencyConversionDataByMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes CurrencyConversion data.</summary>
		///
		/// <param name="item">The CurrencyConversion to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneCurrencyConversion(BLL.Accounts.CurrencyConversion item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Accounts.CurrencyConversionManager.DeleteOneCurrencyConversion(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes CurrencyConversion data.</summary>
		///
		/// <param name="item">The CurrencyConversion to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneCurrencyConversion(BLL.Accounts.CurrencyConversion item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Accounts.CurrencyConversion itemDAL = new DAL.Accounts.CurrencyConversion();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Accounts.CurrencyConversion.DeleteOneCurrencyConversion(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = false;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.DeleteOneCurrencyConversion");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all CurrencyConversion data.</summary>
		///
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.CurrencyConversion> GetAllCurrencyConversionData(MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.CurrencyConversionManager.GetAllCurrencyConversionData(BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all CurrencyConversion data.</summary>
		///
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.CurrencyConversion> GetAllCurrencyConversionData()
		{
			// perform main method tasks
			return BLL.Accounts.CurrencyConversionManager.GetAllCurrencyConversionData(BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all CurrencyConversion data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.CurrencyConversion> GetAllCurrencyConversionData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Accounts.CurrencyConversion> sortableList = new BLL.SortableList<BLL.Accounts.CurrencyConversion>(DAL.Accounts.CurrencyConversion.GetAllCurrencyConversionData(dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Accounts.CurrencyConversion loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetAllCurrencyConversionData");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all CurrencyConversion data by a key.</summary>
		///
		/// <param name="convertFromCurrencyCode">A key for CurrencyConversion items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.CurrencyConversion> GetAllCurrencyConversionDataByConvertFromCurrencyCode(int convertFromCurrencyCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.CurrencyConversionManager.GetAllCurrencyConversionDataByConvertFromCurrencyCode(convertFromCurrencyCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all CurrencyConversion data by a key.</summary>
		///
		/// <param name="convertFromCurrencyCode">A key for CurrencyConversion items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.CurrencyConversion> GetAllCurrencyConversionDataByConvertFromCurrencyCode(int convertFromCurrencyCode)
		{
			// perform main method tasks
			return BLL.Accounts.CurrencyConversionManager.GetAllCurrencyConversionDataByConvertFromCurrencyCode(convertFromCurrencyCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all CurrencyConversion data by a key.</summary>
		///
		/// <param name="convertFromCurrencyCode">A key for CurrencyConversion items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.CurrencyConversion> GetAllCurrencyConversionDataByConvertFromCurrencyCode(int convertFromCurrencyCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Accounts.CurrencyConversion> sortableList = new BLL.SortableList<BLL.Accounts.CurrencyConversion>(DAL.Accounts.CurrencyConversion.GetAllCurrencyConversionDataByConvertFromCurrencyCode(convertFromCurrencyCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Accounts.CurrencyConversion loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetAllCurrencyConversionDataByConvertFromCurrencyCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all CurrencyConversion data by a key.</summary>
		///
		/// <param name="convertToCurrencyCode">A key for CurrencyConversion items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.CurrencyConversion> GetAllCurrencyConversionDataByConvertToCurrencyCode(int convertToCurrencyCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.CurrencyConversionManager.GetAllCurrencyConversionDataByConvertToCurrencyCode(convertToCurrencyCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all CurrencyConversion data by a key.</summary>
		///
		/// <param name="convertToCurrencyCode">A key for CurrencyConversion items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.CurrencyConversion> GetAllCurrencyConversionDataByConvertToCurrencyCode(int convertToCurrencyCode)
		{
			// perform main method tasks
			return BLL.Accounts.CurrencyConversionManager.GetAllCurrencyConversionDataByConvertToCurrencyCode(convertToCurrencyCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all CurrencyConversion data by a key.</summary>
		///
		/// <param name="convertToCurrencyCode">A key for CurrencyConversion items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.CurrencyConversion> GetAllCurrencyConversionDataByConvertToCurrencyCode(int convertToCurrencyCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Accounts.CurrencyConversion> sortableList = new BLL.SortableList<BLL.Accounts.CurrencyConversion>(DAL.Accounts.CurrencyConversion.GetAllCurrencyConversionDataByConvertToCurrencyCode(convertToCurrencyCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Accounts.CurrencyConversion loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetAllCurrencyConversionDataByConvertToCurrencyCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all CurrencyConversion data by criteria.</summary>
		///
		/// <param name="convertFromCurrencyCode">A key for CurrencyConversion items to be fetched</param>
		/// <param name="convertToCurrencyCode">A key for CurrencyConversion items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for CurrencyConversion items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for CurrencyConversion items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.CurrencyConversion> GetAllCurrencyConversionDataByCriteria(int? convertFromCurrencyCode, int? convertToCurrencyCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.CurrencyConversionManager.GetAllCurrencyConversionDataByCriteria(convertFromCurrencyCode, convertToCurrencyCode, lastModifiedDateStart, lastModifiedDateEnd, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all CurrencyConversion data by criteria.</summary>
		///
		/// <param name="convertFromCurrencyCode">A key for CurrencyConversion items to be fetched</param>
		/// <param name="convertToCurrencyCode">A key for CurrencyConversion items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for CurrencyConversion items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for CurrencyConversion items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.CurrencyConversion> GetAllCurrencyConversionDataByCriteria(int? convertFromCurrencyCode, int? convertToCurrencyCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd)
		{
			// perform main method tasks
			return BLL.Accounts.CurrencyConversionManager.GetAllCurrencyConversionDataByCriteria(convertFromCurrencyCode, convertToCurrencyCode, lastModifiedDateStart, lastModifiedDateEnd, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all CurrencyConversion data by criteria.</summary>
		///
		/// <param name="convertFromCurrencyCode">A key for CurrencyConversion items to be fetched</param>
		/// <param name="convertToCurrencyCode">A key for CurrencyConversion items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for CurrencyConversion items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for CurrencyConversion items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.CurrencyConversion> GetAllCurrencyConversionDataByCriteria(int? convertFromCurrencyCode, int? convertToCurrencyCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Accounts.CurrencyConversion> sortableList = new BLL.SortableList<BLL.Accounts.CurrencyConversion>(DAL.Accounts.CurrencyConversion.GetAllCurrencyConversionDataByCriteria(convertFromCurrencyCode, convertToCurrencyCode, lastModifiedDateStart, lastModifiedDateEnd, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Accounts.CurrencyConversion loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetAllCurrencyConversionDataByCriteria");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all CurrencyConversion data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for CurrencyConversion items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.CurrencyConversion> GetAllCurrencyConversionDataByMetaPartnerID(Guid metaPartnerID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.CurrencyConversionManager.GetAllCurrencyConversionDataByMetaPartnerID(metaPartnerID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all CurrencyConversion data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for CurrencyConversion items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.CurrencyConversion> GetAllCurrencyConversionDataByMetaPartnerID(Guid metaPartnerID)
		{
			// perform main method tasks
			return BLL.Accounts.CurrencyConversionManager.GetAllCurrencyConversionDataByMetaPartnerID(metaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all CurrencyConversion data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for CurrencyConversion items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.CurrencyConversion> GetAllCurrencyConversionDataByMetaPartnerID(Guid metaPartnerID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Accounts.CurrencyConversion> sortableList = new BLL.SortableList<BLL.Accounts.CurrencyConversion>(DAL.Accounts.CurrencyConversion.GetAllCurrencyConversionDataByMetaPartnerID(metaPartnerID, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Accounts.CurrencyConversion loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetAllCurrencyConversionDataByMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all CurrencyConversion data by criteria.</summary>
		///
		/// <param name="convertFromCurrencyCode">A key for CurrencyConversion items to be fetched</param>
		/// <param name="convertToCurrencyCode">A key for CurrencyConversion items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for CurrencyConversion items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for CurrencyConversion items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.CurrencyConversion> GetManyCurrencyConversionDataByCriteria(int? convertFromCurrencyCode, int? convertToCurrencyCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.CurrencyConversionManager.GetManyCurrencyConversionDataByCriteria(convertFromCurrencyCode, convertToCurrencyCode, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all CurrencyConversion data by criteria.</summary>
		///
		/// <param name="convertFromCurrencyCode">A key for CurrencyConversion items to be fetched</param>
		/// <param name="convertToCurrencyCode">A key for CurrencyConversion items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for CurrencyConversion items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for CurrencyConversion items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.CurrencyConversion> GetManyCurrencyConversionDataByCriteria(int? convertFromCurrencyCode, int? convertToCurrencyCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Accounts.CurrencyConversion> sortableList = new BLL.SortableList<BLL.Accounts.CurrencyConversion>(DAL.Accounts.CurrencyConversion.GetManyCurrencyConversionDataByCriteria(convertFromCurrencyCode, convertToCurrencyCode, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Accounts.CurrencyConversion loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetManyCurrencyConversionDataByCriteria");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single CurrencyConversion by an index.</summary>
		///
		/// <param name="currencyConversionID">The index for CurrencyConversion to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Accounts.CurrencyConversion GetOneCurrencyConversion(Guid currencyConversionID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.CurrencyConversionManager.GetOneCurrencyConversion(currencyConversionID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single CurrencyConversion by an index.</summary>
		///
		/// <param name="currencyConversionID">The index for CurrencyConversion to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Accounts.CurrencyConversion GetOneCurrencyConversion(Guid currencyConversionID)
		{
			// perform main method tasks
			return BLL.Accounts.CurrencyConversionManager.GetOneCurrencyConversion(currencyConversionID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single CurrencyConversion by an index.</summary>
		///
		/// <param name="currencyConversionID">The index for CurrencyConversion to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Accounts.CurrencyConversion GetOneCurrencyConversion(Guid currencyConversionID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.Accounts.CurrencyConversion itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.Accounts.CurrencyConversion)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.Accounts.CurrencyConversion.GetCacheKey(typeof(BLL.Accounts.CurrencyConversion), "PrimaryKey", currencyConversionID.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.Accounts.CurrencyConversion)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.Accounts.CurrencyConversion item = DAL.Accounts.CurrencyConversion.GetOneCurrencyConversion(currencyConversionID, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.Accounts.CurrencyConversion();
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
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetOneCurrencyConversion");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method inserts or updates CurrencyConversion data.</summary>
		///
		/// <param name="item">The CurrencyConversion to be inserted or updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpsertOneCurrencyConversion(BLL.Accounts.CurrencyConversion item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Accounts.CurrencyConversionManager.UpsertOneCurrencyConversion(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method inserts or updates CurrencyConversion data.</summary>
		///
		/// <param name="item">The CurrencyConversion to be inserted or updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpsertOneCurrencyConversion(BLL.Accounts.CurrencyConversion item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Accounts.CurrencyConversion itemDAL = new DAL.Accounts.CurrencyConversion();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Accounts.CurrencyConversion.UpsertOneCurrencyConversion(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.UpsertOneCurrencyConversion");
			}
		}
		#endregion Methods
	}
}