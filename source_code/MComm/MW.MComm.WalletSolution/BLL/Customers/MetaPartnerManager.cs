
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
	/// <summary>This class is used to manage MetaPartner related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class MetaPartnerManager
	{
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public MetaPartnerManager()
		{
			//
			// constructor logic
			//
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------
		/// <summary>This method deletes all MetaPartner data by a key.</summary>
		///
		/// <param name="currencyCode">A key for MetaPartner items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllMetaPartnerDataByCurrencyCode(int currencyCode)
		{
			// perform main method tasks
			BLL.Customers.MetaPartnerManager.DeleteAllMetaPartnerDataByCurrencyCode(currencyCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all MetaPartner data by a key.</summary>
		///
		/// <param name="currencyCode">A key for MetaPartner items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllMetaPartnerDataByCurrencyCode(int currencyCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Customers.MetaPartner.DeleteAllMetaPartnerDataByCurrencyCode(currencyCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.DeleteAllMetaPartnerDataByCurrencyCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all MetaPartner data by a key.</summary>
		///
		/// <param name="dateFormatCode">A key for MetaPartner items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllMetaPartnerDataByDateFormatCode(int dateFormatCode)
		{
			// perform main method tasks
			BLL.Customers.MetaPartnerManager.DeleteAllMetaPartnerDataByDateFormatCode(dateFormatCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all MetaPartner data by a key.</summary>
		///
		/// <param name="dateFormatCode">A key for MetaPartner items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllMetaPartnerDataByDateFormatCode(int dateFormatCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Customers.MetaPartner.DeleteAllMetaPartnerDataByDateFormatCode(dateFormatCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.DeleteAllMetaPartnerDataByDateFormatCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all MetaPartner data by a key.</summary>
		///
		/// <param name="localeCode">A key for MetaPartner items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllMetaPartnerDataByLocaleCode(int localeCode)
		{
			// perform main method tasks
			BLL.Customers.MetaPartnerManager.DeleteAllMetaPartnerDataByLocaleCode(localeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all MetaPartner data by a key.</summary>
		///
		/// <param name="localeCode">A key for MetaPartner items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllMetaPartnerDataByLocaleCode(int localeCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Customers.MetaPartner.DeleteAllMetaPartnerDataByLocaleCode(localeCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.DeleteAllMetaPartnerDataByLocaleCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all MetaPartner data by a key.</summary>
		///
		/// <param name="metaPartnerSubTypeCode">A key for MetaPartner items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllMetaPartnerDataByMetaPartnerSubTypeCode(int metaPartnerSubTypeCode)
		{
			// perform main method tasks
			BLL.Customers.MetaPartnerManager.DeleteAllMetaPartnerDataByMetaPartnerSubTypeCode(metaPartnerSubTypeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all MetaPartner data by a key.</summary>
		///
		/// <param name="metaPartnerSubTypeCode">A key for MetaPartner items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllMetaPartnerDataByMetaPartnerSubTypeCode(int metaPartnerSubTypeCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Customers.MetaPartner.DeleteAllMetaPartnerDataByMetaPartnerSubTypeCode(metaPartnerSubTypeCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.DeleteAllMetaPartnerDataByMetaPartnerSubTypeCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes MetaPartner data.</summary>
		///
		/// <param name="item">The MetaPartner to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneMetaPartner(BLL.Customers.MetaPartner item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Customers.MetaPartnerManager.DeleteOneMetaPartner(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes MetaPartner data.</summary>
		///
		/// <param name="item">The MetaPartner to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneMetaPartner(BLL.Customers.MetaPartner item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Customers.MetaPartner itemDAL = new DAL.Customers.MetaPartner();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Customers.MetaPartner.DeleteOneMetaPartner(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = false;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.DeleteOneMetaPartner");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartner data.</summary>
		///
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.MetaPartner> GetAllMetaPartnerData(MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.MetaPartnerManager.GetAllMetaPartnerData(BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartner data.</summary>
		///
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.MetaPartner> GetAllMetaPartnerData()
		{
			// perform main method tasks
			return BLL.Customers.MetaPartnerManager.GetAllMetaPartnerData(BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartner data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.MetaPartner> GetAllMetaPartnerData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Customers.MetaPartner> sortableList = new BLL.SortableList<BLL.Customers.MetaPartner>(DAL.Customers.MetaPartner.GetAllMetaPartnerData(dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Customers.MetaPartner loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetAllMetaPartnerData");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartner data by criteria.</summary>
		///
		/// <param name="metaPartnerSubTypeCode">A key for MetaPartner items to be fetched</param>
		/// <param name="localeCode">A key for MetaPartner items to be fetched</param>
		/// <param name="currencyCode">A key for MetaPartner items to be fetched</param>
		/// <param name="dateFormatCode">A key for MetaPartner items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for MetaPartner items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for MetaPartner items to be fetched</param>
		/// <param name="metaPartnerName">A key for MetaPartner items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.MetaPartner> GetAllMetaPartnerDataByCriteria(int? metaPartnerSubTypeCode, int? localeCode, int? currencyCode, int? dateFormatCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, string metaPartnerName, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.MetaPartnerManager.GetAllMetaPartnerDataByCriteria(metaPartnerSubTypeCode, localeCode, currencyCode, dateFormatCode, lastModifiedDateStart, lastModifiedDateEnd, metaPartnerName, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartner data by criteria.</summary>
		///
		/// <param name="metaPartnerSubTypeCode">A key for MetaPartner items to be fetched</param>
		/// <param name="localeCode">A key for MetaPartner items to be fetched</param>
		/// <param name="currencyCode">A key for MetaPartner items to be fetched</param>
		/// <param name="dateFormatCode">A key for MetaPartner items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for MetaPartner items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for MetaPartner items to be fetched</param>
		/// <param name="metaPartnerName">A key for MetaPartner items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.MetaPartner> GetAllMetaPartnerDataByCriteria(int? metaPartnerSubTypeCode, int? localeCode, int? currencyCode, int? dateFormatCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, string metaPartnerName)
		{
			// perform main method tasks
			return BLL.Customers.MetaPartnerManager.GetAllMetaPartnerDataByCriteria(metaPartnerSubTypeCode, localeCode, currencyCode, dateFormatCode, lastModifiedDateStart, lastModifiedDateEnd, metaPartnerName, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartner data by criteria.</summary>
		///
		/// <param name="metaPartnerSubTypeCode">A key for MetaPartner items to be fetched</param>
		/// <param name="localeCode">A key for MetaPartner items to be fetched</param>
		/// <param name="currencyCode">A key for MetaPartner items to be fetched</param>
		/// <param name="dateFormatCode">A key for MetaPartner items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for MetaPartner items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for MetaPartner items to be fetched</param>
		/// <param name="metaPartnerName">A key for MetaPartner items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.MetaPartner> GetAllMetaPartnerDataByCriteria(int? metaPartnerSubTypeCode, int? localeCode, int? currencyCode, int? dateFormatCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, string metaPartnerName, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Customers.MetaPartner> sortableList = new BLL.SortableList<BLL.Customers.MetaPartner>(DAL.Customers.MetaPartner.GetAllMetaPartnerDataByCriteria(metaPartnerSubTypeCode, localeCode, currencyCode, dateFormatCode, lastModifiedDateStart, lastModifiedDateEnd, metaPartnerName, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Customers.MetaPartner loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetAllMetaPartnerDataByCriteria");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartner data by a key.</summary>
		///
		/// <param name="currencyCode">A key for MetaPartner items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.MetaPartner> GetAllMetaPartnerDataByCurrencyCode(int currencyCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.MetaPartnerManager.GetAllMetaPartnerDataByCurrencyCode(currencyCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartner data by a key.</summary>
		///
		/// <param name="currencyCode">A key for MetaPartner items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.MetaPartner> GetAllMetaPartnerDataByCurrencyCode(int currencyCode)
		{
			// perform main method tasks
			return BLL.Customers.MetaPartnerManager.GetAllMetaPartnerDataByCurrencyCode(currencyCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartner data by a key.</summary>
		///
		/// <param name="currencyCode">A key for MetaPartner items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.MetaPartner> GetAllMetaPartnerDataByCurrencyCode(int currencyCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Customers.MetaPartner> sortableList = new BLL.SortableList<BLL.Customers.MetaPartner>(DAL.Customers.MetaPartner.GetAllMetaPartnerDataByCurrencyCode(currencyCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Customers.MetaPartner loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetAllMetaPartnerDataByCurrencyCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartner data by a key.</summary>
		///
		/// <param name="dateFormatCode">A key for MetaPartner items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.MetaPartner> GetAllMetaPartnerDataByDateFormatCode(int dateFormatCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.MetaPartnerManager.GetAllMetaPartnerDataByDateFormatCode(dateFormatCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartner data by a key.</summary>
		///
		/// <param name="dateFormatCode">A key for MetaPartner items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.MetaPartner> GetAllMetaPartnerDataByDateFormatCode(int dateFormatCode)
		{
			// perform main method tasks
			return BLL.Customers.MetaPartnerManager.GetAllMetaPartnerDataByDateFormatCode(dateFormatCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartner data by a key.</summary>
		///
		/// <param name="dateFormatCode">A key for MetaPartner items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.MetaPartner> GetAllMetaPartnerDataByDateFormatCode(int dateFormatCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Customers.MetaPartner> sortableList = new BLL.SortableList<BLL.Customers.MetaPartner>(DAL.Customers.MetaPartner.GetAllMetaPartnerDataByDateFormatCode(dateFormatCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Customers.MetaPartner loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetAllMetaPartnerDataByDateFormatCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartner data by a key.</summary>
		///
		/// <param name="localeCode">A key for MetaPartner items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.MetaPartner> GetAllMetaPartnerDataByLocaleCode(int localeCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.MetaPartnerManager.GetAllMetaPartnerDataByLocaleCode(localeCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartner data by a key.</summary>
		///
		/// <param name="localeCode">A key for MetaPartner items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.MetaPartner> GetAllMetaPartnerDataByLocaleCode(int localeCode)
		{
			// perform main method tasks
			return BLL.Customers.MetaPartnerManager.GetAllMetaPartnerDataByLocaleCode(localeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartner data by a key.</summary>
		///
		/// <param name="localeCode">A key for MetaPartner items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.MetaPartner> GetAllMetaPartnerDataByLocaleCode(int localeCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Customers.MetaPartner> sortableList = new BLL.SortableList<BLL.Customers.MetaPartner>(DAL.Customers.MetaPartner.GetAllMetaPartnerDataByLocaleCode(localeCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Customers.MetaPartner loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetAllMetaPartnerDataByLocaleCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartner data by a key.</summary>
		///
		/// <param name="metaPartnerSubTypeCode">A key for MetaPartner items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.MetaPartner> GetAllMetaPartnerDataByMetaPartnerSubTypeCode(int metaPartnerSubTypeCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.MetaPartnerManager.GetAllMetaPartnerDataByMetaPartnerSubTypeCode(metaPartnerSubTypeCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartner data by a key.</summary>
		///
		/// <param name="metaPartnerSubTypeCode">A key for MetaPartner items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.MetaPartner> GetAllMetaPartnerDataByMetaPartnerSubTypeCode(int metaPartnerSubTypeCode)
		{
			// perform main method tasks
			return BLL.Customers.MetaPartnerManager.GetAllMetaPartnerDataByMetaPartnerSubTypeCode(metaPartnerSubTypeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartner data by a key.</summary>
		///
		/// <param name="metaPartnerSubTypeCode">A key for MetaPartner items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.MetaPartner> GetAllMetaPartnerDataByMetaPartnerSubTypeCode(int metaPartnerSubTypeCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Customers.MetaPartner> sortableList = new BLL.SortableList<BLL.Customers.MetaPartner>(DAL.Customers.MetaPartner.GetAllMetaPartnerDataByMetaPartnerSubTypeCode(metaPartnerSubTypeCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Customers.MetaPartner loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetAllMetaPartnerDataByMetaPartnerSubTypeCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartner data by criteria.</summary>
		///
		/// <param name="metaPartnerSubTypeCode">A key for MetaPartner items to be fetched</param>
		/// <param name="localeCode">A key for MetaPartner items to be fetched</param>
		/// <param name="currencyCode">A key for MetaPartner items to be fetched</param>
		/// <param name="dateFormatCode">A key for MetaPartner items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for MetaPartner items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for MetaPartner items to be fetched</param>
		/// <param name="metaPartnerName">A key for MetaPartner items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.MetaPartner> GetManyMetaPartnerDataByCriteria(int? metaPartnerSubTypeCode, int? localeCode, int? currencyCode, int? dateFormatCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, string metaPartnerName, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.MetaPartnerManager.GetManyMetaPartnerDataByCriteria(metaPartnerSubTypeCode, localeCode, currencyCode, dateFormatCode, lastModifiedDateStart, lastModifiedDateEnd, metaPartnerName, out totalRecords, out maximumListSizeExceeded, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartner data by criteria.</summary>
		///
		/// <param name="metaPartnerSubTypeCode">A key for MetaPartner items to be fetched</param>
		/// <param name="localeCode">A key for MetaPartner items to be fetched</param>
		/// <param name="currencyCode">A key for MetaPartner items to be fetched</param>
		/// <param name="dateFormatCode">A key for MetaPartner items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for MetaPartner items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for MetaPartner items to be fetched</param>
		/// <param name="metaPartnerName">A key for MetaPartner items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.MetaPartner> GetManyMetaPartnerDataByCriteria(int? metaPartnerSubTypeCode, int? localeCode, int? currencyCode, int? dateFormatCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, string metaPartnerName, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Customers.MetaPartner> sortableList = new BLL.SortableList<BLL.Customers.MetaPartner>(DAL.Customers.MetaPartner.GetManyMetaPartnerDataByCriteria(metaPartnerSubTypeCode, localeCode, currencyCode, dateFormatCode, lastModifiedDateStart, lastModifiedDateEnd, metaPartnerName, out totalRecords, out maximumListSizeExceeded, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Customers.MetaPartner loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetManyMetaPartnerDataByCriteria");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single MetaPartner by an index.</summary>
		///
		/// <param name="metaPartnerID">The index for MetaPartner to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Customers.MetaPartner GetOneMetaPartner(Guid metaPartnerID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.MetaPartnerManager.GetOneMetaPartner(metaPartnerID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single MetaPartner by an index.</summary>
		///
		/// <param name="metaPartnerID">The index for MetaPartner to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Customers.MetaPartner GetOneMetaPartner(Guid metaPartnerID)
		{
			// perform main method tasks
			return BLL.Customers.MetaPartnerManager.GetOneMetaPartner(metaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single MetaPartner by an index.</summary>
		///
		/// <param name="metaPartnerID">The index for MetaPartner to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Customers.MetaPartner GetOneMetaPartner(Guid metaPartnerID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.Customers.MetaPartner itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.Customers.MetaPartner)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.Customers.MetaPartner.GetCacheKey(typeof(BLL.Customers.MetaPartner), "PrimaryKey", metaPartnerID.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.Customers.MetaPartner)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.Customers.MetaPartner item = DAL.Customers.MetaPartner.GetOneMetaPartner(metaPartnerID, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.Customers.MetaPartner();
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
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetOneMetaPartner");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method inserts or updates MetaPartner data.</summary>
		///
		/// <param name="item">The MetaPartner to be inserted or updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpsertOneMetaPartner(BLL.Customers.MetaPartner item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Customers.MetaPartnerManager.UpsertOneMetaPartner(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method inserts or updates MetaPartner data.</summary>
		///
		/// <param name="item">The MetaPartner to be inserted or updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpsertOneMetaPartner(BLL.Customers.MetaPartner item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Customers.MetaPartner itemDAL = new DAL.Customers.MetaPartner();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Customers.MetaPartner.UpsertOneMetaPartner(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.UpsertOneMetaPartner");
			}
		}
		#endregion Methods
	}
}