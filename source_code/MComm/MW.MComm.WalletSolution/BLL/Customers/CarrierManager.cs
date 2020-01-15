
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
	/// <summary>This class is used to manage Carrier related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class CarrierManager
	{
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public CarrierManager()
		{
			//
			// constructor logic
			//
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------
		/// <summary>This method inserts Carrier data.</summary>
		///
		/// <param name="item">The Carrier to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneCarrier(BLL.Customers.Carrier item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Customers.CarrierManager.AddOneCarrier(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method inserts Carrier data.</summary>
		///
		/// <param name="item">The Carrier to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneCarrier(BLL.Customers.Carrier item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Customers.Carrier itemDAL = new DAL.Customers.Carrier();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Customers.Carrier.AddOneCarrier(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.AddOneCarrier");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Carrier data by a key.</summary>
		///
		/// <param name="currencyCode">A key for Carrier items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllCarrierDataByCurrencyCode(int currencyCode)
		{
			// perform main method tasks
			BLL.Customers.CarrierManager.DeleteAllCarrierDataByCurrencyCode(currencyCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Carrier data by a key.</summary>
		///
		/// <param name="currencyCode">A key for Carrier items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllCarrierDataByCurrencyCode(int currencyCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Customers.Carrier.DeleteAllCarrierDataByCurrencyCode(currencyCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.DeleteAllCarrierDataByCurrencyCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Carrier data by a key.</summary>
		///
		/// <param name="dateFormatCode">A key for Carrier items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllCarrierDataByDateFormatCode(int dateFormatCode)
		{
			// perform main method tasks
			BLL.Customers.CarrierManager.DeleteAllCarrierDataByDateFormatCode(dateFormatCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Carrier data by a key.</summary>
		///
		/// <param name="dateFormatCode">A key for Carrier items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllCarrierDataByDateFormatCode(int dateFormatCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Customers.Carrier.DeleteAllCarrierDataByDateFormatCode(dateFormatCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.DeleteAllCarrierDataByDateFormatCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Carrier data by a key.</summary>
		///
		/// <param name="localeCode">A key for Carrier items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllCarrierDataByLocaleCode(int localeCode)
		{
			// perform main method tasks
			BLL.Customers.CarrierManager.DeleteAllCarrierDataByLocaleCode(localeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Carrier data by a key.</summary>
		///
		/// <param name="localeCode">A key for Carrier items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllCarrierDataByLocaleCode(int localeCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Customers.Carrier.DeleteAllCarrierDataByLocaleCode(localeCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.DeleteAllCarrierDataByLocaleCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Carrier data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for Carrier items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllCarrierDataByMetaPartnerID(Guid metaPartnerID)
		{
			// perform main method tasks
			BLL.Customers.CarrierManager.DeleteAllCarrierDataByMetaPartnerID(metaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Carrier data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for Carrier items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllCarrierDataByMetaPartnerID(Guid metaPartnerID, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Customers.Carrier.DeleteAllCarrierDataByMetaPartnerID(metaPartnerID, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.DeleteAllCarrierDataByMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Carrier data by a key.</summary>
		///
		/// <param name="metaPartnerSubTypeCode">A key for Carrier items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllCarrierDataByMetaPartnerSubTypeCode(int metaPartnerSubTypeCode)
		{
			// perform main method tasks
			BLL.Customers.CarrierManager.DeleteAllCarrierDataByMetaPartnerSubTypeCode(metaPartnerSubTypeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Carrier data by a key.</summary>
		///
		/// <param name="metaPartnerSubTypeCode">A key for Carrier items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllCarrierDataByMetaPartnerSubTypeCode(int metaPartnerSubTypeCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Customers.Carrier.DeleteAllCarrierDataByMetaPartnerSubTypeCode(metaPartnerSubTypeCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.DeleteAllCarrierDataByMetaPartnerSubTypeCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes Carrier data.</summary>
		///
		/// <param name="item">The Carrier to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneCarrier(BLL.Customers.Carrier item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Customers.CarrierManager.DeleteOneCarrier(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes Carrier data.</summary>
		///
		/// <param name="item">The Carrier to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneCarrier(BLL.Customers.Carrier item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Customers.Carrier itemDAL = new DAL.Customers.Carrier();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Customers.Carrier.DeleteOneCarrier(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = false;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.DeleteOneCarrier");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Carrier data.</summary>
		///
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Carrier> GetAllCarrierData(MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.CarrierManager.GetAllCarrierData(BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Carrier data.</summary>
		///
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Carrier> GetAllCarrierData()
		{
			// perform main method tasks
			return BLL.Customers.CarrierManager.GetAllCarrierData(BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Carrier data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Carrier> GetAllCarrierData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Customers.Carrier> sortableList = new BLL.SortableList<BLL.Customers.Carrier>(DAL.Customers.Carrier.GetAllCarrierData(dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Customers.Carrier loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetAllCarrierData");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Carrier data by criteria.</summary>
		///
		/// <param name="localeCode">A key for Carrier items to be fetched</param>
		/// <param name="currencyCode">A key for Carrier items to be fetched</param>
		/// <param name="dateFormatCode">A key for Carrier items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Carrier items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Carrier items to be fetched</param>
		/// <param name="metaPartnerName">A key for Carrier items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Carrier> GetAllCarrierDataByCriteria(int? localeCode, int? currencyCode, int? dateFormatCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, string metaPartnerName, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.CarrierManager.GetAllCarrierDataByCriteria(localeCode, currencyCode, dateFormatCode, lastModifiedDateStart, lastModifiedDateEnd, metaPartnerName, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Carrier data by criteria.</summary>
		///
		/// <param name="localeCode">A key for Carrier items to be fetched</param>
		/// <param name="currencyCode">A key for Carrier items to be fetched</param>
		/// <param name="dateFormatCode">A key for Carrier items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Carrier items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Carrier items to be fetched</param>
		/// <param name="metaPartnerName">A key for Carrier items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Carrier> GetAllCarrierDataByCriteria(int? localeCode, int? currencyCode, int? dateFormatCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, string metaPartnerName)
		{
			// perform main method tasks
			return BLL.Customers.CarrierManager.GetAllCarrierDataByCriteria(localeCode, currencyCode, dateFormatCode, lastModifiedDateStart, lastModifiedDateEnd, metaPartnerName, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Carrier data by criteria.</summary>
		///
		/// <param name="localeCode">A key for Carrier items to be fetched</param>
		/// <param name="currencyCode">A key for Carrier items to be fetched</param>
		/// <param name="dateFormatCode">A key for Carrier items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Carrier items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Carrier items to be fetched</param>
		/// <param name="metaPartnerName">A key for Carrier items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Carrier> GetAllCarrierDataByCriteria(int? localeCode, int? currencyCode, int? dateFormatCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, string metaPartnerName, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Customers.Carrier> sortableList = new BLL.SortableList<BLL.Customers.Carrier>(DAL.Customers.Carrier.GetAllCarrierDataByCriteria(localeCode, currencyCode, dateFormatCode, lastModifiedDateStart, lastModifiedDateEnd, metaPartnerName, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Customers.Carrier loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetAllCarrierDataByCriteria");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Carrier data by a key.</summary>
		///
		/// <param name="currencyCode">A key for Carrier items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Carrier> GetAllCarrierDataByCurrencyCode(int currencyCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.CarrierManager.GetAllCarrierDataByCurrencyCode(currencyCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Carrier data by a key.</summary>
		///
		/// <param name="currencyCode">A key for Carrier items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Carrier> GetAllCarrierDataByCurrencyCode(int currencyCode)
		{
			// perform main method tasks
			return BLL.Customers.CarrierManager.GetAllCarrierDataByCurrencyCode(currencyCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Carrier data by a key.</summary>
		///
		/// <param name="currencyCode">A key for Carrier items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Carrier> GetAllCarrierDataByCurrencyCode(int currencyCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Customers.Carrier> sortableList = new BLL.SortableList<BLL.Customers.Carrier>(DAL.Customers.Carrier.GetAllCarrierDataByCurrencyCode(currencyCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Customers.Carrier loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetAllCarrierDataByCurrencyCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Carrier data by a key.</summary>
		///
		/// <param name="dateFormatCode">A key for Carrier items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Carrier> GetAllCarrierDataByDateFormatCode(int dateFormatCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.CarrierManager.GetAllCarrierDataByDateFormatCode(dateFormatCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Carrier data by a key.</summary>
		///
		/// <param name="dateFormatCode">A key for Carrier items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Carrier> GetAllCarrierDataByDateFormatCode(int dateFormatCode)
		{
			// perform main method tasks
			return BLL.Customers.CarrierManager.GetAllCarrierDataByDateFormatCode(dateFormatCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Carrier data by a key.</summary>
		///
		/// <param name="dateFormatCode">A key for Carrier items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Carrier> GetAllCarrierDataByDateFormatCode(int dateFormatCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Customers.Carrier> sortableList = new BLL.SortableList<BLL.Customers.Carrier>(DAL.Customers.Carrier.GetAllCarrierDataByDateFormatCode(dateFormatCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Customers.Carrier loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetAllCarrierDataByDateFormatCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Carrier data by a key.</summary>
		///
		/// <param name="localeCode">A key for Carrier items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Carrier> GetAllCarrierDataByLocaleCode(int localeCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.CarrierManager.GetAllCarrierDataByLocaleCode(localeCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Carrier data by a key.</summary>
		///
		/// <param name="localeCode">A key for Carrier items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Carrier> GetAllCarrierDataByLocaleCode(int localeCode)
		{
			// perform main method tasks
			return BLL.Customers.CarrierManager.GetAllCarrierDataByLocaleCode(localeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Carrier data by a key.</summary>
		///
		/// <param name="localeCode">A key for Carrier items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Carrier> GetAllCarrierDataByLocaleCode(int localeCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Customers.Carrier> sortableList = new BLL.SortableList<BLL.Customers.Carrier>(DAL.Customers.Carrier.GetAllCarrierDataByLocaleCode(localeCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Customers.Carrier loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetAllCarrierDataByLocaleCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Carrier data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for Carrier items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Carrier> GetAllCarrierDataByMetaPartnerID(Guid metaPartnerID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.CarrierManager.GetAllCarrierDataByMetaPartnerID(metaPartnerID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Carrier data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for Carrier items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Carrier> GetAllCarrierDataByMetaPartnerID(Guid metaPartnerID)
		{
			// perform main method tasks
			return BLL.Customers.CarrierManager.GetAllCarrierDataByMetaPartnerID(metaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Carrier data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for Carrier items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Carrier> GetAllCarrierDataByMetaPartnerID(Guid metaPartnerID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Customers.Carrier> sortableList = new BLL.SortableList<BLL.Customers.Carrier>(DAL.Customers.Carrier.GetAllCarrierDataByMetaPartnerID(metaPartnerID, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Customers.Carrier loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetAllCarrierDataByMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Carrier data by a key.</summary>
		///
		/// <param name="metaPartnerSubTypeCode">A key for Carrier items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Carrier> GetAllCarrierDataByMetaPartnerSubTypeCode(int metaPartnerSubTypeCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.CarrierManager.GetAllCarrierDataByMetaPartnerSubTypeCode(metaPartnerSubTypeCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Carrier data by a key.</summary>
		///
		/// <param name="metaPartnerSubTypeCode">A key for Carrier items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Carrier> GetAllCarrierDataByMetaPartnerSubTypeCode(int metaPartnerSubTypeCode)
		{
			// perform main method tasks
			return BLL.Customers.CarrierManager.GetAllCarrierDataByMetaPartnerSubTypeCode(metaPartnerSubTypeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Carrier data by a key.</summary>
		///
		/// <param name="metaPartnerSubTypeCode">A key for Carrier items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Carrier> GetAllCarrierDataByMetaPartnerSubTypeCode(int metaPartnerSubTypeCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Customers.Carrier> sortableList = new BLL.SortableList<BLL.Customers.Carrier>(DAL.Customers.Carrier.GetAllCarrierDataByMetaPartnerSubTypeCode(metaPartnerSubTypeCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Customers.Carrier loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetAllCarrierDataByMetaPartnerSubTypeCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Carrier data by criteria.</summary>
		///
		/// <param name="localeCode">A key for Carrier items to be fetched</param>
		/// <param name="currencyCode">A key for Carrier items to be fetched</param>
		/// <param name="dateFormatCode">A key for Carrier items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Carrier items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Carrier items to be fetched</param>
		/// <param name="metaPartnerName">A key for Carrier items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Carrier> GetManyCarrierDataByCriteria(int? localeCode, int? currencyCode, int? dateFormatCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, string metaPartnerName, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.CarrierManager.GetManyCarrierDataByCriteria(localeCode, currencyCode, dateFormatCode, lastModifiedDateStart, lastModifiedDateEnd, metaPartnerName, out totalRecords, out maximumListSizeExceeded, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Carrier data by criteria.</summary>
		///
		/// <param name="localeCode">A key for Carrier items to be fetched</param>
		/// <param name="currencyCode">A key for Carrier items to be fetched</param>
		/// <param name="dateFormatCode">A key for Carrier items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Carrier items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Carrier items to be fetched</param>
		/// <param name="metaPartnerName">A key for Carrier items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Carrier> GetManyCarrierDataByCriteria(int? localeCode, int? currencyCode, int? dateFormatCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, string metaPartnerName, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Customers.Carrier> sortableList = new BLL.SortableList<BLL.Customers.Carrier>(DAL.Customers.Carrier.GetManyCarrierDataByCriteria(localeCode, currencyCode, dateFormatCode, lastModifiedDateStart, lastModifiedDateEnd, metaPartnerName, out totalRecords, out maximumListSizeExceeded, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Customers.Carrier loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetManyCarrierDataByCriteria");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single Carrier by an index.</summary>
		///
		/// <param name="metaPartnerID">The index for Carrier to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Customers.Carrier GetOneCarrier(Guid metaPartnerID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.CarrierManager.GetOneCarrier(metaPartnerID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single Carrier by an index.</summary>
		///
		/// <param name="metaPartnerID">The index for Carrier to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Customers.Carrier GetOneCarrier(Guid metaPartnerID)
		{
			// perform main method tasks
			return BLL.Customers.CarrierManager.GetOneCarrier(metaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single Carrier by an index.</summary>
		///
		/// <param name="metaPartnerID">The index for Carrier to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Customers.Carrier GetOneCarrier(Guid metaPartnerID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.Customers.Carrier itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.Customers.Carrier)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.Customers.Carrier.GetCacheKey(typeof(BLL.Customers.Carrier), "PrimaryKey", metaPartnerID.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.Customers.Carrier)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.Customers.Carrier item = DAL.Customers.Carrier.GetOneCarrier(metaPartnerID, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.Customers.Carrier();
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
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetOneCarrier");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single Carrier by an index.</summary>
		///
		/// <param name="carrierCode">The index for Carrier to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Customers.Carrier GetOneCarrierByCarrierCode(int carrierCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.CarrierManager.GetOneCarrierByCarrierCode(carrierCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single Carrier by an index.</summary>
		///
		/// <param name="carrierCode">The index for Carrier to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Customers.Carrier GetOneCarrierByCarrierCode(int carrierCode)
		{
			// perform main method tasks
			return BLL.Customers.CarrierManager.GetOneCarrierByCarrierCode(carrierCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single Carrier by an index.</summary>
		///
		/// <param name="carrierCode">The index for Carrier to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Customers.Carrier GetOneCarrierByCarrierCode(int carrierCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.Customers.Carrier itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.Customers.Carrier)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.Customers.Carrier.GetCacheKey(typeof(BLL.Customers.Carrier), "PrimaryKey", carrierCode.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.Customers.Carrier)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.Customers.Carrier item = DAL.Customers.Carrier.GetOneCarrierByCarrierCode(carrierCode, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.Customers.Carrier();
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
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetOneCarrierByCarrierCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates Carrier data.</summary>
		///
		/// <param name="item">The Carrier to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneCarrier(BLL.Customers.Carrier item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Customers.CarrierManager.UpdateOneCarrier(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates Carrier data.</summary>
		///
		/// <param name="item">The Carrier to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneCarrier(BLL.Customers.Carrier item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Customers.Carrier itemDAL = new DAL.Customers.Carrier();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Customers.Carrier.UpdateOneCarrier(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.UpdateOneCarrier");
			}
		}
		#endregion Methods
	}
}