
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
using MW.MComm.WalletSolution.BLL.Orders;
using MOD.Data;
using MW.MComm.WalletSolution.BLL.Config;
using BLL = MW.MComm.WalletSolution.BLL;
using DAL = MW.MComm.WalletSolution.DAL;
using Utility = MW.MComm.WalletSolution.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
namespace MW.MComm.WalletSolution.BLL.Orders
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage Order related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class OrderManager
	{
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public OrderManager()
		{
			//
			// constructor logic
			//
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Order data by a key.</summary>
		///
		/// <param name="creditMetaPartnerID">A key for Order items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllOrderDataByCreditMetaPartnerID(Guid creditMetaPartnerID)
		{
			// perform main method tasks
			BLL.Orders.OrderManager.DeleteAllOrderDataByCreditMetaPartnerID(creditMetaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Order data by a key.</summary>
		///
		/// <param name="creditMetaPartnerID">A key for Order items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllOrderDataByCreditMetaPartnerID(Guid creditMetaPartnerID, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Orders.Order.DeleteAllOrderDataByCreditMetaPartnerID(creditMetaPartnerID, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Orders.DeleteAllOrderDataByCreditMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Order data by a key.</summary>
		///
		/// <param name="currencyCode">A key for Order items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllOrderDataByCurrencyCode(int currencyCode)
		{
			// perform main method tasks
			BLL.Orders.OrderManager.DeleteAllOrderDataByCurrencyCode(currencyCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Order data by a key.</summary>
		///
		/// <param name="currencyCode">A key for Order items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllOrderDataByCurrencyCode(int currencyCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Orders.Order.DeleteAllOrderDataByCurrencyCode(currencyCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Orders.DeleteAllOrderDataByCurrencyCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Order data by a key.</summary>
		///
		/// <param name="debitMetaPartnerID">A key for Order items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllOrderDataByDebitMetaPartnerID(Guid debitMetaPartnerID)
		{
			// perform main method tasks
			BLL.Orders.OrderManager.DeleteAllOrderDataByDebitMetaPartnerID(debitMetaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Order data by a key.</summary>
		///
		/// <param name="debitMetaPartnerID">A key for Order items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllOrderDataByDebitMetaPartnerID(Guid debitMetaPartnerID, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Orders.Order.DeleteAllOrderDataByDebitMetaPartnerID(debitMetaPartnerID, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Orders.DeleteAllOrderDataByDebitMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Order data by a key.</summary>
		///
		/// <param name="logToAccountID">A key for Order items to be deleted</param>
		/// <param name="creditMetaPartnerID">A key for Order items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllOrderDataByLogToAccountIDAndCreditMetaPartnerID(Guid logToAccountID, Guid creditMetaPartnerID)
		{
			// perform main method tasks
			BLL.Orders.OrderManager.DeleteAllOrderDataByLogToAccountIDAndCreditMetaPartnerID(logToAccountID, creditMetaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Order data by a key.</summary>
		///
		/// <param name="logToAccountID">A key for Order items to be deleted</param>
		/// <param name="creditMetaPartnerID">A key for Order items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllOrderDataByLogToAccountIDAndCreditMetaPartnerID(Guid logToAccountID, Guid creditMetaPartnerID, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Orders.Order.DeleteAllOrderDataByLogToAccountIDAndCreditMetaPartnerID(logToAccountID, creditMetaPartnerID, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Orders.DeleteAllOrderDataByLogToAccountIDAndCreditMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Order data by a key.</summary>
		///
		/// <param name="orderStatusCode">A key for Order items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllOrderDataByOrderStatusCode(int orderStatusCode)
		{
			// perform main method tasks
			BLL.Orders.OrderManager.DeleteAllOrderDataByOrderStatusCode(orderStatusCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Order data by a key.</summary>
		///
		/// <param name="orderStatusCode">A key for Order items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllOrderDataByOrderStatusCode(int orderStatusCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Orders.Order.DeleteAllOrderDataByOrderStatusCode(orderStatusCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Orders.DeleteAllOrderDataByOrderStatusCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes Order data.</summary>
		///
		/// <param name="item">The Order to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneOrder(BLL.Orders.Order item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Orders.OrderManager.DeleteOneOrder(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes Order data.</summary>
		///
		/// <param name="item">The Order to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneOrder(BLL.Orders.Order item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Orders.Order itemDAL = new DAL.Orders.Order();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Orders.Order.DeleteOneOrder(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = false;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Orders.DeleteOneOrder");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Order data.</summary>
		///
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Orders.Order> GetAllOrderData(MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Orders.OrderManager.GetAllOrderData(BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Order data.</summary>
		///
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Orders.Order> GetAllOrderData()
		{
			// perform main method tasks
			return BLL.Orders.OrderManager.GetAllOrderData(BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Order data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Orders.Order> GetAllOrderData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Orders.Order> sortableList = new BLL.SortableList<BLL.Orders.Order>(DAL.Orders.Order.GetAllOrderData(dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Orders.Order loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Orders.GetAllOrderData");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Order data by a key.</summary>
		///
		/// <param name="creditMetaPartnerID">A key for Order items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Orders.Order> GetAllOrderDataByCreditMetaPartnerID(Guid creditMetaPartnerID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Orders.OrderManager.GetAllOrderDataByCreditMetaPartnerID(creditMetaPartnerID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Order data by a key.</summary>
		///
		/// <param name="creditMetaPartnerID">A key for Order items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Orders.Order> GetAllOrderDataByCreditMetaPartnerID(Guid creditMetaPartnerID)
		{
			// perform main method tasks
			return BLL.Orders.OrderManager.GetAllOrderDataByCreditMetaPartnerID(creditMetaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Order data by a key.</summary>
		///
		/// <param name="creditMetaPartnerID">A key for Order items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Orders.Order> GetAllOrderDataByCreditMetaPartnerID(Guid creditMetaPartnerID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Orders.Order> sortableList = new BLL.SortableList<BLL.Orders.Order>(DAL.Orders.Order.GetAllOrderDataByCreditMetaPartnerID(creditMetaPartnerID, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Orders.Order loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Orders.GetAllOrderDataByCreditMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Order data by criteria.</summary>
		///
		/// <param name="currencyCode">A key for Order items to be fetched</param>
		/// <param name="orderStatusCode">A key for Order items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Order items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Order items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Orders.Order> GetAllOrderDataByCriteria(int? currencyCode, int? orderStatusCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Orders.OrderManager.GetAllOrderDataByCriteria(currencyCode, orderStatusCode, lastModifiedDateStart, lastModifiedDateEnd, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Order data by criteria.</summary>
		///
		/// <param name="currencyCode">A key for Order items to be fetched</param>
		/// <param name="orderStatusCode">A key for Order items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Order items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Order items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Orders.Order> GetAllOrderDataByCriteria(int? currencyCode, int? orderStatusCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd)
		{
			// perform main method tasks
			return BLL.Orders.OrderManager.GetAllOrderDataByCriteria(currencyCode, orderStatusCode, lastModifiedDateStart, lastModifiedDateEnd, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Order data by criteria.</summary>
		///
		/// <param name="currencyCode">A key for Order items to be fetched</param>
		/// <param name="orderStatusCode">A key for Order items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Order items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Order items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Orders.Order> GetAllOrderDataByCriteria(int? currencyCode, int? orderStatusCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Orders.Order> sortableList = new BLL.SortableList<BLL.Orders.Order>(DAL.Orders.Order.GetAllOrderDataByCriteria(currencyCode, orderStatusCode, lastModifiedDateStart, lastModifiedDateEnd, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Orders.Order loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Orders.GetAllOrderDataByCriteria");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Order data by a key.</summary>
		///
		/// <param name="currencyCode">A key for Order items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Orders.Order> GetAllOrderDataByCurrencyCode(int currencyCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Orders.OrderManager.GetAllOrderDataByCurrencyCode(currencyCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Order data by a key.</summary>
		///
		/// <param name="currencyCode">A key for Order items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Orders.Order> GetAllOrderDataByCurrencyCode(int currencyCode)
		{
			// perform main method tasks
			return BLL.Orders.OrderManager.GetAllOrderDataByCurrencyCode(currencyCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Order data by a key.</summary>
		///
		/// <param name="currencyCode">A key for Order items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Orders.Order> GetAllOrderDataByCurrencyCode(int currencyCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Orders.Order> sortableList = new BLL.SortableList<BLL.Orders.Order>(DAL.Orders.Order.GetAllOrderDataByCurrencyCode(currencyCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Orders.Order loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Orders.GetAllOrderDataByCurrencyCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Order data by a key.</summary>
		///
		/// <param name="debitMetaPartnerID">A key for Order items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Orders.Order> GetAllOrderDataByDebitMetaPartnerID(Guid debitMetaPartnerID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Orders.OrderManager.GetAllOrderDataByDebitMetaPartnerID(debitMetaPartnerID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Order data by a key.</summary>
		///
		/// <param name="debitMetaPartnerID">A key for Order items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Orders.Order> GetAllOrderDataByDebitMetaPartnerID(Guid debitMetaPartnerID)
		{
			// perform main method tasks
			return BLL.Orders.OrderManager.GetAllOrderDataByDebitMetaPartnerID(debitMetaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Order data by a key.</summary>
		///
		/// <param name="debitMetaPartnerID">A key for Order items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Orders.Order> GetAllOrderDataByDebitMetaPartnerID(Guid debitMetaPartnerID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Orders.Order> sortableList = new BLL.SortableList<BLL.Orders.Order>(DAL.Orders.Order.GetAllOrderDataByDebitMetaPartnerID(debitMetaPartnerID, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Orders.Order loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Orders.GetAllOrderDataByDebitMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Order data by a key.</summary>
		///
		/// <param name="logToAccountID">A key for Order items to be fetched</param>
		/// <param name="creditMetaPartnerID">A key for Order items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Orders.Order> GetAllOrderDataByLogToAccountIDAndCreditMetaPartnerID(Guid logToAccountID, Guid creditMetaPartnerID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Orders.OrderManager.GetAllOrderDataByLogToAccountIDAndCreditMetaPartnerID(logToAccountID, creditMetaPartnerID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Order data by a key.</summary>
		///
		/// <param name="logToAccountID">A key for Order items to be fetched</param>
		/// <param name="creditMetaPartnerID">A key for Order items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Orders.Order> GetAllOrderDataByLogToAccountIDAndCreditMetaPartnerID(Guid logToAccountID, Guid creditMetaPartnerID)
		{
			// perform main method tasks
			return BLL.Orders.OrderManager.GetAllOrderDataByLogToAccountIDAndCreditMetaPartnerID(logToAccountID, creditMetaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Order data by a key.</summary>
		///
		/// <param name="logToAccountID">A key for Order items to be fetched</param>
		/// <param name="creditMetaPartnerID">A key for Order items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Orders.Order> GetAllOrderDataByLogToAccountIDAndCreditMetaPartnerID(Guid logToAccountID, Guid creditMetaPartnerID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Orders.Order> sortableList = new BLL.SortableList<BLL.Orders.Order>(DAL.Orders.Order.GetAllOrderDataByLogToAccountIDAndCreditMetaPartnerID(logToAccountID, creditMetaPartnerID, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Orders.Order loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Orders.GetAllOrderDataByLogToAccountIDAndCreditMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Order data by a key.</summary>
		///
		/// <param name="orderStatusCode">A key for Order items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Orders.Order> GetAllOrderDataByOrderStatusCode(int orderStatusCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Orders.OrderManager.GetAllOrderDataByOrderStatusCode(orderStatusCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Order data by a key.</summary>
		///
		/// <param name="orderStatusCode">A key for Order items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Orders.Order> GetAllOrderDataByOrderStatusCode(int orderStatusCode)
		{
			// perform main method tasks
			return BLL.Orders.OrderManager.GetAllOrderDataByOrderStatusCode(orderStatusCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Order data by a key.</summary>
		///
		/// <param name="orderStatusCode">A key for Order items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Orders.Order> GetAllOrderDataByOrderStatusCode(int orderStatusCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Orders.Order> sortableList = new BLL.SortableList<BLL.Orders.Order>(DAL.Orders.Order.GetAllOrderDataByOrderStatusCode(orderStatusCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Orders.Order loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Orders.GetAllOrderDataByOrderStatusCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Order data by criteria.</summary>
		///
		/// <param name="currencyCode">A key for Order items to be fetched</param>
		/// <param name="orderStatusCode">A key for Order items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Order items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Order items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Orders.Order> GetManyOrderDataByCriteria(int? currencyCode, int? orderStatusCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Orders.OrderManager.GetManyOrderDataByCriteria(currencyCode, orderStatusCode, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Order data by criteria.</summary>
		///
		/// <param name="currencyCode">A key for Order items to be fetched</param>
		/// <param name="orderStatusCode">A key for Order items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Order items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Order items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Orders.Order> GetManyOrderDataByCriteria(int? currencyCode, int? orderStatusCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Orders.Order> sortableList = new BLL.SortableList<BLL.Orders.Order>(DAL.Orders.Order.GetManyOrderDataByCriteria(currencyCode, orderStatusCode, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Orders.Order loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Orders.GetManyOrderDataByCriteria");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single Order by an index.</summary>
		///
		/// <param name="orderID">The index for Order to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Orders.Order GetOneOrder(Guid orderID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Orders.OrderManager.GetOneOrder(orderID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single Order by an index.</summary>
		///
		/// <param name="orderID">The index for Order to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Orders.Order GetOneOrder(Guid orderID)
		{
			// perform main method tasks
			return BLL.Orders.OrderManager.GetOneOrder(orderID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single Order by an index.</summary>
		///
		/// <param name="orderID">The index for Order to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Orders.Order GetOneOrder(Guid orderID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.Orders.Order itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.Orders.Order)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.Orders.Order.GetCacheKey(typeof(BLL.Orders.Order), "PrimaryKey", orderID.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.Orders.Order)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.Orders.Order item = DAL.Orders.Order.GetOneOrder(orderID, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.Orders.Order();
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
				throw Utility.CustomAppException.WrapException(ex, "BLL.Orders.GetOneOrder");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single Order by an index.</summary>
		///
		/// <param name="orderID">The index for Order to be fetched</param>
		/// <param name="debitMetaPartnerID">The index for Order to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Orders.Order GetOneOrderByOrderIDAndDebitMetaPartnerID(Guid orderID, Guid debitMetaPartnerID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Orders.OrderManager.GetOneOrderByOrderIDAndDebitMetaPartnerID(orderID, debitMetaPartnerID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single Order by an index.</summary>
		///
		/// <param name="orderID">The index for Order to be fetched</param>
		/// <param name="debitMetaPartnerID">The index for Order to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Orders.Order GetOneOrderByOrderIDAndDebitMetaPartnerID(Guid orderID, Guid debitMetaPartnerID)
		{
			// perform main method tasks
			return BLL.Orders.OrderManager.GetOneOrderByOrderIDAndDebitMetaPartnerID(orderID, debitMetaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single Order by an index.</summary>
		///
		/// <param name="orderID">The index for Order to be fetched</param>
		/// <param name="debitMetaPartnerID">The index for Order to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Orders.Order GetOneOrderByOrderIDAndDebitMetaPartnerID(Guid orderID, Guid debitMetaPartnerID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.Orders.Order itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.Orders.Order)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.Orders.Order.GetCacheKey(typeof(BLL.Orders.Order), "PrimaryKey", orderID.ToString() + ", " + debitMetaPartnerID.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.Orders.Order)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.Orders.Order item = DAL.Orders.Order.GetOneOrderByOrderIDAndDebitMetaPartnerID(orderID, debitMetaPartnerID, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.Orders.Order();
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
				throw Utility.CustomAppException.WrapException(ex, "BLL.Orders.GetOneOrderByOrderIDAndDebitMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single Order by an index.</summary>
		///
		/// <param name="orderID">The index for Order to be fetched</param>
		/// <param name="debitMetaPartnerID">The index for Order to be fetched</param>
		/// <param name="creditMetaPartnerID">The index for Order to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Orders.Order GetOneOrderByOrderIDAndDebitMetaPartnerIDAndCreditMetaPartnerID(Guid orderID, Guid debitMetaPartnerID, Guid creditMetaPartnerID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Orders.OrderManager.GetOneOrderByOrderIDAndDebitMetaPartnerIDAndCreditMetaPartnerID(orderID, debitMetaPartnerID, creditMetaPartnerID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single Order by an index.</summary>
		///
		/// <param name="orderID">The index for Order to be fetched</param>
		/// <param name="debitMetaPartnerID">The index for Order to be fetched</param>
		/// <param name="creditMetaPartnerID">The index for Order to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Orders.Order GetOneOrderByOrderIDAndDebitMetaPartnerIDAndCreditMetaPartnerID(Guid orderID, Guid debitMetaPartnerID, Guid creditMetaPartnerID)
		{
			// perform main method tasks
			return BLL.Orders.OrderManager.GetOneOrderByOrderIDAndDebitMetaPartnerIDAndCreditMetaPartnerID(orderID, debitMetaPartnerID, creditMetaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single Order by an index.</summary>
		///
		/// <param name="orderID">The index for Order to be fetched</param>
		/// <param name="debitMetaPartnerID">The index for Order to be fetched</param>
		/// <param name="creditMetaPartnerID">The index for Order to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Orders.Order GetOneOrderByOrderIDAndDebitMetaPartnerIDAndCreditMetaPartnerID(Guid orderID, Guid debitMetaPartnerID, Guid creditMetaPartnerID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.Orders.Order itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.Orders.Order)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.Orders.Order.GetCacheKey(typeof(BLL.Orders.Order), "PrimaryKey", orderID.ToString() + ", " + debitMetaPartnerID.ToString() + ", " + creditMetaPartnerID.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.Orders.Order)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.Orders.Order item = DAL.Orders.Order.GetOneOrderByOrderIDAndDebitMetaPartnerIDAndCreditMetaPartnerID(orderID, debitMetaPartnerID, creditMetaPartnerID, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.Orders.Order();
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
				throw Utility.CustomAppException.WrapException(ex, "BLL.Orders.GetOneOrderByOrderIDAndDebitMetaPartnerIDAndCreditMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method inserts or updates Order data.</summary>
		///
		/// <param name="item">The Order to be inserted or updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpsertOneOrder(BLL.Orders.Order item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Orders.OrderManager.UpsertOneOrder(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method inserts or updates Order data.</summary>
		///
		/// <param name="item">The Order to be inserted or updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpsertOneOrder(BLL.Orders.Order item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Orders.Order itemDAL = new DAL.Orders.Order();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Orders.Order.UpsertOneOrder(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Orders.UpsertOneOrder");
			}
		}
		#endregion Methods
	}
}