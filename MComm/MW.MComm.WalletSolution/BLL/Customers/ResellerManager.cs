
/*<copyright>
Meta Wallet, Inc (c) 2007 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2007, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
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
	/// <summary>This class is used to manage Reseller related information.</summary>
	///
	/// File History:
	/// <created>5/8/2007 (Chris Grundy)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class ResellerManager
	{
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public ResellerManager()
		{
			//
			// constructor logic
			//
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Reseller data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for Reseller items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllResellerDataByMetaPartnerID(Guid metaPartnerID)
		{
			// perform main method tasks
			BLL.Customers.ResellerManager.DeleteAllResellerDataByMetaPartnerID(metaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Reseller data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for Reseller items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllResellerDataByMetaPartnerID(Guid metaPartnerID, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Customers.Reseller.DeleteAllResellerDataByMetaPartnerID(metaPartnerID, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.DeleteAllResellerDataByMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Reseller data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for Reseller items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Reseller> GetAllResellerDataByMetaPartnerID(Guid metaPartnerID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.ResellerManager.GetAllResellerDataByMetaPartnerID(metaPartnerID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Reseller data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for Reseller items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Reseller> GetAllResellerDataByMetaPartnerID(Guid metaPartnerID)
		{
			// perform main method tasks
			return BLL.Customers.ResellerManager.GetAllResellerDataByMetaPartnerID(metaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Reseller data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for Reseller items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Reseller> GetAllResellerDataByMetaPartnerID(Guid metaPartnerID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Customers.Reseller> sortableList = new BLL.SortableList<BLL.Customers.Reseller>(DAL.Customers.Reseller.GetAllResellerDataByMetaPartnerID(metaPartnerID, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Customers.Reseller loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetAllResellerDataByMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Reseller data by a key.</summary>
		///
		/// <param name="currencyCode">A key for Reseller items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllResellerDataByCurrencyCode(int currencyCode)
		{
			// perform main method tasks
			BLL.Customers.ResellerManager.DeleteAllResellerDataByCurrencyCode(currencyCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Reseller data by a key.</summary>
		///
		/// <param name="currencyCode">A key for Reseller items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllResellerDataByCurrencyCode(int currencyCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Customers.Reseller.DeleteAllResellerDataByCurrencyCode(currencyCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.DeleteAllResellerDataByCurrencyCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Reseller data by a key.</summary>
		///
		/// <param name="metaPartnerSubTypeCode">A key for Reseller items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllResellerDataByMetaPartnerSubTypeCode(int metaPartnerSubTypeCode)
		{
			// perform main method tasks
			BLL.Customers.ResellerManager.DeleteAllResellerDataByMetaPartnerSubTypeCode(metaPartnerSubTypeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Reseller data by a key.</summary>
		///
		/// <param name="metaPartnerSubTypeCode">A key for Reseller items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllResellerDataByMetaPartnerSubTypeCode(int metaPartnerSubTypeCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Customers.Reseller.DeleteAllResellerDataByMetaPartnerSubTypeCode(metaPartnerSubTypeCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.DeleteAllResellerDataByMetaPartnerSubTypeCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Reseller data by a key.</summary>
		///
		/// <param name="dateFormatCode">A key for Reseller items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllResellerDataByDateFormatCode(int dateFormatCode)
		{
			// perform main method tasks
			BLL.Customers.ResellerManager.DeleteAllResellerDataByDateFormatCode(dateFormatCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Reseller data by a key.</summary>
		///
		/// <param name="dateFormatCode">A key for Reseller items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllResellerDataByDateFormatCode(int dateFormatCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Customers.Reseller.DeleteAllResellerDataByDateFormatCode(dateFormatCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.DeleteAllResellerDataByDateFormatCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Reseller data by a key.</summary>
		///
		/// <param name="localeCode">A key for Reseller items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllResellerDataByLocaleCode(int localeCode)
		{
			// perform main method tasks
			BLL.Customers.ResellerManager.DeleteAllResellerDataByLocaleCode(localeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Reseller data by a key.</summary>
		///
		/// <param name="localeCode">A key for Reseller items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllResellerDataByLocaleCode(int localeCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Customers.Reseller.DeleteAllResellerDataByLocaleCode(localeCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.DeleteAllResellerDataByLocaleCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Reseller data by a key.</summary>
		///
		/// <param name="currencyCode">A key for Reseller items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Reseller> GetAllResellerDataByCurrencyCode(int currencyCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.ResellerManager.GetAllResellerDataByCurrencyCode(currencyCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Reseller data by a key.</summary>
		///
		/// <param name="currencyCode">A key for Reseller items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Reseller> GetAllResellerDataByCurrencyCode(int currencyCode)
		{
			// perform main method tasks
			return BLL.Customers.ResellerManager.GetAllResellerDataByCurrencyCode(currencyCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Reseller data by a key.</summary>
		///
		/// <param name="currencyCode">A key for Reseller items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Reseller> GetAllResellerDataByCurrencyCode(int currencyCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Customers.Reseller> sortableList = new BLL.SortableList<BLL.Customers.Reseller>(DAL.Customers.Reseller.GetAllResellerDataByCurrencyCode(currencyCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Customers.Reseller loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetAllResellerDataByCurrencyCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Reseller data by a key.</summary>
		///
		/// <param name="metaPartnerSubTypeCode">A key for Reseller items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Reseller> GetAllResellerDataByMetaPartnerSubTypeCode(int metaPartnerSubTypeCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.ResellerManager.GetAllResellerDataByMetaPartnerSubTypeCode(metaPartnerSubTypeCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Reseller data by a key.</summary>
		///
		/// <param name="metaPartnerSubTypeCode">A key for Reseller items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Reseller> GetAllResellerDataByMetaPartnerSubTypeCode(int metaPartnerSubTypeCode)
		{
			// perform main method tasks
			return BLL.Customers.ResellerManager.GetAllResellerDataByMetaPartnerSubTypeCode(metaPartnerSubTypeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Reseller data by a key.</summary>
		///
		/// <param name="metaPartnerSubTypeCode">A key for Reseller items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Reseller> GetAllResellerDataByMetaPartnerSubTypeCode(int metaPartnerSubTypeCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Customers.Reseller> sortableList = new BLL.SortableList<BLL.Customers.Reseller>(DAL.Customers.Reseller.GetAllResellerDataByMetaPartnerSubTypeCode(metaPartnerSubTypeCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Customers.Reseller loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetAllResellerDataByMetaPartnerSubTypeCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Reseller data by a key.</summary>
		///
		/// <param name="dateFormatCode">A key for Reseller items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Reseller> GetAllResellerDataByDateFormatCode(int dateFormatCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.ResellerManager.GetAllResellerDataByDateFormatCode(dateFormatCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Reseller data by a key.</summary>
		///
		/// <param name="dateFormatCode">A key for Reseller items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Reseller> GetAllResellerDataByDateFormatCode(int dateFormatCode)
		{
			// perform main method tasks
			return BLL.Customers.ResellerManager.GetAllResellerDataByDateFormatCode(dateFormatCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Reseller data by a key.</summary>
		///
		/// <param name="dateFormatCode">A key for Reseller items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Reseller> GetAllResellerDataByDateFormatCode(int dateFormatCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Customers.Reseller> sortableList = new BLL.SortableList<BLL.Customers.Reseller>(DAL.Customers.Reseller.GetAllResellerDataByDateFormatCode(dateFormatCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Customers.Reseller loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetAllResellerDataByDateFormatCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Reseller data by a key.</summary>
		///
		/// <param name="localeCode">A key for Reseller items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Reseller> GetAllResellerDataByLocaleCode(int localeCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.ResellerManager.GetAllResellerDataByLocaleCode(localeCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Reseller data by a key.</summary>
		///
		/// <param name="localeCode">A key for Reseller items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Reseller> GetAllResellerDataByLocaleCode(int localeCode)
		{
			// perform main method tasks
			return BLL.Customers.ResellerManager.GetAllResellerDataByLocaleCode(localeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Reseller data by a key.</summary>
		///
		/// <param name="localeCode">A key for Reseller items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Reseller> GetAllResellerDataByLocaleCode(int localeCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Customers.Reseller> sortableList = new BLL.SortableList<BLL.Customers.Reseller>(DAL.Customers.Reseller.GetAllResellerDataByLocaleCode(localeCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Customers.Reseller loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetAllResellerDataByLocaleCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method inserts Reseller data.</summary>
		///
		/// <param name="item">The Reseller to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneReseller(BLL.Customers.Reseller item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Customers.ResellerManager.AddOneReseller(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method inserts Reseller data.</summary>
		///
		/// <param name="item">The Reseller to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneReseller(BLL.Customers.Reseller item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Customers.Reseller itemDAL = new DAL.Customers.Reseller();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Customers.Reseller.AddOneReseller(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.AddOneReseller");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates Reseller data.</summary>
		///
		/// <param name="item">The Reseller to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneReseller(BLL.Customers.Reseller item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Customers.ResellerManager.UpdateOneReseller(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates Reseller data.</summary>
		///
		/// <param name="item">The Reseller to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneReseller(BLL.Customers.Reseller item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Customers.Reseller itemDAL = new DAL.Customers.Reseller();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Customers.Reseller.UpdateOneReseller(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.UpdateOneReseller");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes Reseller data.</summary>
		///
		/// <param name="item">The Reseller to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneReseller(BLL.Customers.Reseller item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Customers.ResellerManager.DeleteOneReseller(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes Reseller data.</summary>
		///
		/// <param name="item">The Reseller to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneReseller(BLL.Customers.Reseller item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Customers.Reseller itemDAL = new DAL.Customers.Reseller();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Customers.Reseller.DeleteOneReseller(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = false;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.DeleteOneReseller");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Reseller data by a key.</summary>
		///
		/// <param name="resellerTypeCode">A key for Reseller items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllResellerDataByResellerTypeCode(int resellerTypeCode)
		{
			// perform main method tasks
			BLL.Customers.ResellerManager.DeleteAllResellerDataByResellerTypeCode(resellerTypeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Reseller data by a key.</summary>
		///
		/// <param name="resellerTypeCode">A key for Reseller items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllResellerDataByResellerTypeCode(int resellerTypeCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Customers.Reseller.DeleteAllResellerDataByResellerTypeCode(resellerTypeCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.DeleteAllResellerDataByResellerTypeCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single Reseller by an index.</summary>
		///
		/// <param name="metaPartnerID">The index for Reseller to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Customers.Reseller GetOneReseller(Guid metaPartnerID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.ResellerManager.GetOneReseller(metaPartnerID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single Reseller by an index.</summary>
		///
		/// <param name="metaPartnerID">The index for Reseller to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Customers.Reseller GetOneReseller(Guid metaPartnerID)
		{
			// perform main method tasks
			return BLL.Customers.ResellerManager.GetOneReseller(metaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single Reseller by an index.</summary>
		///
		/// <param name="metaPartnerID">The index for Reseller to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Customers.Reseller GetOneReseller(Guid metaPartnerID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.Customers.Reseller itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.Customers.Reseller)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.Customers.Reseller.GetCacheKey(typeof(BLL.Customers.Reseller), "PrimaryKey", metaPartnerID.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.Customers.Reseller)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.Customers.Reseller item = DAL.Customers.Reseller.GetOneReseller(metaPartnerID, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.Customers.Reseller();
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
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetOneReseller");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Reseller data.</summary>
		///
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Reseller> GetAllResellerData(MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.ResellerManager.GetAllResellerData(BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Reseller data.</summary>
		///
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Reseller> GetAllResellerData()
		{
			// perform main method tasks
			return BLL.Customers.ResellerManager.GetAllResellerData(BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Reseller data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Reseller> GetAllResellerData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Customers.Reseller> sortableList = new BLL.SortableList<BLL.Customers.Reseller>(DAL.Customers.Reseller.GetAllResellerData(dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Customers.Reseller loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetAllResellerData");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Reseller data by a key.</summary>
		///
		/// <param name="resellerTypeCode">A key for Reseller items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Reseller> GetAllResellerDataByResellerTypeCode(int resellerTypeCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.ResellerManager.GetAllResellerDataByResellerTypeCode(resellerTypeCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Reseller data by a key.</summary>
		///
		/// <param name="resellerTypeCode">A key for Reseller items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Reseller> GetAllResellerDataByResellerTypeCode(int resellerTypeCode)
		{
			// perform main method tasks
			return BLL.Customers.ResellerManager.GetAllResellerDataByResellerTypeCode(resellerTypeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Reseller data by a key.</summary>
		///
		/// <param name="resellerTypeCode">A key for Reseller items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Reseller> GetAllResellerDataByResellerTypeCode(int resellerTypeCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Customers.Reseller> sortableList = new BLL.SortableList<BLL.Customers.Reseller>(DAL.Customers.Reseller.GetAllResellerDataByResellerTypeCode(resellerTypeCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Customers.Reseller loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetAllResellerDataByResellerTypeCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Reseller data by criteria.</summary>
		///
		/// <param name="resellerTypeCode">A key for Reseller items to be fetched</param>
		/// <param name="localeCode">A key for Reseller items to be fetched</param>
		/// <param name="currencyCode">A key for Reseller items to be fetched</param>
		/// <param name="dateFormatCode">A key for Reseller items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Reseller items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Reseller items to be fetched</param>
		/// <param name="metaPartnerName">A key for Reseller items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Reseller> GetAllResellerDataByCriteria(int? resellerTypeCode, int? localeCode, int? currencyCode, int? dateFormatCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, string metaPartnerName, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.ResellerManager.GetAllResellerDataByCriteria(resellerTypeCode, localeCode, currencyCode, dateFormatCode, lastModifiedDateStart, lastModifiedDateEnd, metaPartnerName, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Reseller data by criteria.</summary>
		///
		/// <param name="resellerTypeCode">A key for Reseller items to be fetched</param>
		/// <param name="localeCode">A key for Reseller items to be fetched</param>
		/// <param name="currencyCode">A key for Reseller items to be fetched</param>
		/// <param name="dateFormatCode">A key for Reseller items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Reseller items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Reseller items to be fetched</param>
		/// <param name="metaPartnerName">A key for Reseller items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Reseller> GetAllResellerDataByCriteria(int? resellerTypeCode, int? localeCode, int? currencyCode, int? dateFormatCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, string metaPartnerName)
		{
			// perform main method tasks
			return BLL.Customers.ResellerManager.GetAllResellerDataByCriteria(resellerTypeCode, localeCode, currencyCode, dateFormatCode, lastModifiedDateStart, lastModifiedDateEnd, metaPartnerName, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Reseller data by criteria.</summary>
		///
		/// <param name="resellerTypeCode">A key for Reseller items to be fetched</param>
		/// <param name="localeCode">A key for Reseller items to be fetched</param>
		/// <param name="currencyCode">A key for Reseller items to be fetched</param>
		/// <param name="dateFormatCode">A key for Reseller items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Reseller items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Reseller items to be fetched</param>
		/// <param name="metaPartnerName">A key for Reseller items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Reseller> GetAllResellerDataByCriteria(int? resellerTypeCode, int? localeCode, int? currencyCode, int? dateFormatCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, string metaPartnerName, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Customers.Reseller> sortableList = new BLL.SortableList<BLL.Customers.Reseller>(DAL.Customers.Reseller.GetAllResellerDataByCriteria(resellerTypeCode, localeCode, currencyCode, dateFormatCode, lastModifiedDateStart, lastModifiedDateEnd, metaPartnerName, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Customers.Reseller loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetAllResellerDataByCriteria");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Reseller data by criteria.</summary>
		///
		/// <param name="resellerTypeCode">A key for Reseller items to be fetched</param>
		/// <param name="localeCode">A key for Reseller items to be fetched</param>
		/// <param name="currencyCode">A key for Reseller items to be fetched</param>
		/// <param name="dateFormatCode">A key for Reseller items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Reseller items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Reseller items to be fetched</param>
		/// <param name="metaPartnerName">A key for Reseller items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Reseller> GetManyResellerDataByCriteria(int? resellerTypeCode, int? localeCode, int? currencyCode, int? dateFormatCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, string metaPartnerName, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.ResellerManager.GetManyResellerDataByCriteria(resellerTypeCode, localeCode, currencyCode, dateFormatCode, lastModifiedDateStart, lastModifiedDateEnd, metaPartnerName, out totalRecords, out maximumListSizeExceeded, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Reseller data by criteria.</summary>
		///
		/// <param name="resellerTypeCode">A key for Reseller items to be fetched</param>
		/// <param name="localeCode">A key for Reseller items to be fetched</param>
		/// <param name="currencyCode">A key for Reseller items to be fetched</param>
		/// <param name="dateFormatCode">A key for Reseller items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Reseller items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Reseller items to be fetched</param>
		/// <param name="metaPartnerName">A key for Reseller items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Reseller> GetManyResellerDataByCriteria(int? resellerTypeCode, int? localeCode, int? currencyCode, int? dateFormatCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, string metaPartnerName, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Customers.Reseller> sortableList = new BLL.SortableList<BLL.Customers.Reseller>(DAL.Customers.Reseller.GetManyResellerDataByCriteria(resellerTypeCode, localeCode, currencyCode, dateFormatCode, lastModifiedDateStart, lastModifiedDateEnd, metaPartnerName, out totalRecords, out maximumListSizeExceeded, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Customers.Reseller loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetManyResellerDataByCriteria");
			}
		}
		#endregion Methods
	}
}