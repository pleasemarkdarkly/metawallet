
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
using MW.MComm.WalletSolution.BLL.Payments;
using MOD.Data;
using MW.MComm.WalletSolution.BLL.Config;
using BLL = MW.MComm.WalletSolution.BLL;
using DAL = MW.MComm.WalletSolution.DAL;
using Utility = MW.MComm.WalletSolution.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
namespace MW.MComm.WalletSolution.BLL.Payments
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage PaymentTransactionLog related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class PaymentTransactionLogManager
	{
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public PaymentTransactionLogManager()
		{
			//
			// constructor logic
			//
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------
		/// <summary>This method gets all PaymentTransactionLog data.</summary>
		///
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Payments.PaymentTransactionLog> GetAllPaymentTransactionLogData(MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Payments.PaymentTransactionLogManager.GetAllPaymentTransactionLogData(BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all PaymentTransactionLog data.</summary>
		///
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Payments.PaymentTransactionLog> GetAllPaymentTransactionLogData()
		{
			// perform main method tasks
			return BLL.Payments.PaymentTransactionLogManager.GetAllPaymentTransactionLogData(BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all PaymentTransactionLog data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Payments.PaymentTransactionLog> GetAllPaymentTransactionLogData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Payments.PaymentTransactionLog> sortableList = new BLL.SortableList<BLL.Payments.PaymentTransactionLog>(DAL.Payments.PaymentTransactionLog.GetAllPaymentTransactionLogData(dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Payments.PaymentTransactionLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Payments.GetAllPaymentTransactionLogData");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all PaymentTransactionLog data by criteria.</summary>
		///
		/// <param name="transactionTypeCode">A key for PaymentTransactionLog items to be fetched</param>
		/// <param name="transactionStatusCode">A key for PaymentTransactionLog items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for PaymentTransactionLog items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for PaymentTransactionLog items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Payments.PaymentTransactionLog> GetAllPaymentTransactionLogDataByCriteria(int? transactionTypeCode, int? transactionStatusCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Payments.PaymentTransactionLogManager.GetAllPaymentTransactionLogDataByCriteria(transactionTypeCode, transactionStatusCode, lastModifiedDateStart, lastModifiedDateEnd, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all PaymentTransactionLog data by criteria.</summary>
		///
		/// <param name="transactionTypeCode">A key for PaymentTransactionLog items to be fetched</param>
		/// <param name="transactionStatusCode">A key for PaymentTransactionLog items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for PaymentTransactionLog items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for PaymentTransactionLog items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Payments.PaymentTransactionLog> GetAllPaymentTransactionLogDataByCriteria(int? transactionTypeCode, int? transactionStatusCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd)
		{
			// perform main method tasks
			return BLL.Payments.PaymentTransactionLogManager.GetAllPaymentTransactionLogDataByCriteria(transactionTypeCode, transactionStatusCode, lastModifiedDateStart, lastModifiedDateEnd, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all PaymentTransactionLog data by criteria.</summary>
		///
		/// <param name="transactionTypeCode">A key for PaymentTransactionLog items to be fetched</param>
		/// <param name="transactionStatusCode">A key for PaymentTransactionLog items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for PaymentTransactionLog items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for PaymentTransactionLog items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Payments.PaymentTransactionLog> GetAllPaymentTransactionLogDataByCriteria(int? transactionTypeCode, int? transactionStatusCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Payments.PaymentTransactionLog> sortableList = new BLL.SortableList<BLL.Payments.PaymentTransactionLog>(DAL.Payments.PaymentTransactionLog.GetAllPaymentTransactionLogDataByCriteria(transactionTypeCode, transactionStatusCode, lastModifiedDateStart, lastModifiedDateEnd, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Payments.PaymentTransactionLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Payments.GetAllPaymentTransactionLogDataByCriteria");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all PaymentTransactionLog data by a key.</summary>
		///
		/// <param name="paymentID">A key for PaymentTransactionLog items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Payments.PaymentTransactionLog> GetAllPaymentTransactionLogDataByPaymentID(Guid paymentID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Payments.PaymentTransactionLogManager.GetAllPaymentTransactionLogDataByPaymentID(paymentID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all PaymentTransactionLog data by a key.</summary>
		///
		/// <param name="paymentID">A key for PaymentTransactionLog items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Payments.PaymentTransactionLog> GetAllPaymentTransactionLogDataByPaymentID(Guid paymentID)
		{
			// perform main method tasks
			return BLL.Payments.PaymentTransactionLogManager.GetAllPaymentTransactionLogDataByPaymentID(paymentID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all PaymentTransactionLog data by a key.</summary>
		///
		/// <param name="paymentID">A key for PaymentTransactionLog items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Payments.PaymentTransactionLog> GetAllPaymentTransactionLogDataByPaymentID(Guid paymentID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Payments.PaymentTransactionLog> sortableList = new BLL.SortableList<BLL.Payments.PaymentTransactionLog>(DAL.Payments.PaymentTransactionLog.GetAllPaymentTransactionLogDataByPaymentID(paymentID, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Payments.PaymentTransactionLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Payments.GetAllPaymentTransactionLogDataByPaymentID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all PaymentTransactionLog data by a key.</summary>
		///
		/// <param name="transactionStatusCode">A key for PaymentTransactionLog items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Payments.PaymentTransactionLog> GetAllPaymentTransactionLogDataByTransactionStatusCode(int transactionStatusCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Payments.PaymentTransactionLogManager.GetAllPaymentTransactionLogDataByTransactionStatusCode(transactionStatusCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all PaymentTransactionLog data by a key.</summary>
		///
		/// <param name="transactionStatusCode">A key for PaymentTransactionLog items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Payments.PaymentTransactionLog> GetAllPaymentTransactionLogDataByTransactionStatusCode(int transactionStatusCode)
		{
			// perform main method tasks
			return BLL.Payments.PaymentTransactionLogManager.GetAllPaymentTransactionLogDataByTransactionStatusCode(transactionStatusCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all PaymentTransactionLog data by a key.</summary>
		///
		/// <param name="transactionStatusCode">A key for PaymentTransactionLog items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Payments.PaymentTransactionLog> GetAllPaymentTransactionLogDataByTransactionStatusCode(int transactionStatusCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Payments.PaymentTransactionLog> sortableList = new BLL.SortableList<BLL.Payments.PaymentTransactionLog>(DAL.Payments.PaymentTransactionLog.GetAllPaymentTransactionLogDataByTransactionStatusCode(transactionStatusCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Payments.PaymentTransactionLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Payments.GetAllPaymentTransactionLogDataByTransactionStatusCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all PaymentTransactionLog data by a key.</summary>
		///
		/// <param name="transactionTypeCode">A key for PaymentTransactionLog items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Payments.PaymentTransactionLog> GetAllPaymentTransactionLogDataByTransactionTypeCode(int transactionTypeCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Payments.PaymentTransactionLogManager.GetAllPaymentTransactionLogDataByTransactionTypeCode(transactionTypeCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all PaymentTransactionLog data by a key.</summary>
		///
		/// <param name="transactionTypeCode">A key for PaymentTransactionLog items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Payments.PaymentTransactionLog> GetAllPaymentTransactionLogDataByTransactionTypeCode(int transactionTypeCode)
		{
			// perform main method tasks
			return BLL.Payments.PaymentTransactionLogManager.GetAllPaymentTransactionLogDataByTransactionTypeCode(transactionTypeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all PaymentTransactionLog data by a key.</summary>
		///
		/// <param name="transactionTypeCode">A key for PaymentTransactionLog items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Payments.PaymentTransactionLog> GetAllPaymentTransactionLogDataByTransactionTypeCode(int transactionTypeCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Payments.PaymentTransactionLog> sortableList = new BLL.SortableList<BLL.Payments.PaymentTransactionLog>(DAL.Payments.PaymentTransactionLog.GetAllPaymentTransactionLogDataByTransactionTypeCode(transactionTypeCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Payments.PaymentTransactionLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Payments.GetAllPaymentTransactionLogDataByTransactionTypeCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all PaymentTransactionLog data by criteria.</summary>
		///
		/// <param name="transactionTypeCode">A key for PaymentTransactionLog items to be fetched</param>
		/// <param name="transactionStatusCode">A key for PaymentTransactionLog items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for PaymentTransactionLog items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for PaymentTransactionLog items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Payments.PaymentTransactionLog> GetManyPaymentTransactionLogDataByCriteria(int? transactionTypeCode, int? transactionStatusCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Payments.PaymentTransactionLogManager.GetManyPaymentTransactionLogDataByCriteria(transactionTypeCode, transactionStatusCode, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all PaymentTransactionLog data by criteria.</summary>
		///
		/// <param name="transactionTypeCode">A key for PaymentTransactionLog items to be fetched</param>
		/// <param name="transactionStatusCode">A key for PaymentTransactionLog items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for PaymentTransactionLog items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for PaymentTransactionLog items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Payments.PaymentTransactionLog> GetManyPaymentTransactionLogDataByCriteria(int? transactionTypeCode, int? transactionStatusCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Payments.PaymentTransactionLog> sortableList = new BLL.SortableList<BLL.Payments.PaymentTransactionLog>(DAL.Payments.PaymentTransactionLog.GetManyPaymentTransactionLogDataByCriteria(transactionTypeCode, transactionStatusCode, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Payments.PaymentTransactionLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Payments.GetManyPaymentTransactionLogDataByCriteria");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single PaymentTransactionLog by an index.</summary>
		///
		/// <param name="paymentTransactionLogID">The index for PaymentTransactionLog to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Payments.PaymentTransactionLog GetOnePaymentTransactionLog(Guid paymentTransactionLogID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Payments.PaymentTransactionLogManager.GetOnePaymentTransactionLog(paymentTransactionLogID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single PaymentTransactionLog by an index.</summary>
		///
		/// <param name="paymentTransactionLogID">The index for PaymentTransactionLog to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Payments.PaymentTransactionLog GetOnePaymentTransactionLog(Guid paymentTransactionLogID)
		{
			// perform main method tasks
			return BLL.Payments.PaymentTransactionLogManager.GetOnePaymentTransactionLog(paymentTransactionLogID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single PaymentTransactionLog by an index.</summary>
		///
		/// <param name="paymentTransactionLogID">The index for PaymentTransactionLog to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Payments.PaymentTransactionLog GetOnePaymentTransactionLog(Guid paymentTransactionLogID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.Payments.PaymentTransactionLog itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.Payments.PaymentTransactionLog)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.Payments.PaymentTransactionLog.GetCacheKey(typeof(BLL.Payments.PaymentTransactionLog), "PrimaryKey", paymentTransactionLogID.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.Payments.PaymentTransactionLog)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.Payments.PaymentTransactionLog item = DAL.Payments.PaymentTransactionLog.GetOnePaymentTransactionLog(paymentTransactionLogID, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.Payments.PaymentTransactionLog();
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
				throw Utility.CustomAppException.WrapException(ex, "BLL.Payments.GetOnePaymentTransactionLog");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method logs PaymentTransactionLog data.</summary>
		///
		/// <param name="item">The PaymentTransactionLog to be logged.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void LogOnePaymentTransactionLog(BLL.Payments.PaymentTransactionLog item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Payments.PaymentTransactionLogManager.LogOnePaymentTransactionLog(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method logs PaymentTransactionLog data.</summary>
		///
		/// <param name="item">The PaymentTransactionLog to be logged.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void LogOnePaymentTransactionLog(BLL.Payments.PaymentTransactionLog item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Payments.PaymentTransactionLog itemDAL = new DAL.Payments.PaymentTransactionLog();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Payments.PaymentTransactionLog.LogOnePaymentTransactionLog(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Payments.LogOnePaymentTransactionLog");
			}
		}
		#endregion Methods
	}
}