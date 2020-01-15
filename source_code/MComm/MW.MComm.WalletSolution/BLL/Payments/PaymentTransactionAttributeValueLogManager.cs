
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
	/// <summary>This class is used to manage PaymentTransactionAttributeValueLog related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class PaymentTransactionAttributeValueLogManager
	{
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public PaymentTransactionAttributeValueLogManager()
		{
			//
			// constructor logic
			//
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------
		/// <summary>This method gets all PaymentTransactionAttributeValueLog data.</summary>
		///
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Payments.PaymentTransactionAttributeValueLog> GetAllPaymentTransactionAttributeValueLogData(MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Payments.PaymentTransactionAttributeValueLogManager.GetAllPaymentTransactionAttributeValueLogData(BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all PaymentTransactionAttributeValueLog data.</summary>
		///
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Payments.PaymentTransactionAttributeValueLog> GetAllPaymentTransactionAttributeValueLogData()
		{
			// perform main method tasks
			return BLL.Payments.PaymentTransactionAttributeValueLogManager.GetAllPaymentTransactionAttributeValueLogData(BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all PaymentTransactionAttributeValueLog data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Payments.PaymentTransactionAttributeValueLog> GetAllPaymentTransactionAttributeValueLogData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Payments.PaymentTransactionAttributeValueLog> sortableList = new BLL.SortableList<BLL.Payments.PaymentTransactionAttributeValueLog>(DAL.Payments.PaymentTransactionAttributeValueLog.GetAllPaymentTransactionAttributeValueLogData(dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Payments.PaymentTransactionAttributeValueLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Payments.GetAllPaymentTransactionAttributeValueLogData");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all PaymentTransactionAttributeValueLog data by a key.</summary>
		///
		/// <param name="baseAttributeID">A key for PaymentTransactionAttributeValueLog items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Payments.PaymentTransactionAttributeValueLog> GetAllPaymentTransactionAttributeValueLogDataByBaseAttributeID(Guid baseAttributeID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Payments.PaymentTransactionAttributeValueLogManager.GetAllPaymentTransactionAttributeValueLogDataByBaseAttributeID(baseAttributeID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all PaymentTransactionAttributeValueLog data by a key.</summary>
		///
		/// <param name="baseAttributeID">A key for PaymentTransactionAttributeValueLog items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Payments.PaymentTransactionAttributeValueLog> GetAllPaymentTransactionAttributeValueLogDataByBaseAttributeID(Guid baseAttributeID)
		{
			// perform main method tasks
			return BLL.Payments.PaymentTransactionAttributeValueLogManager.GetAllPaymentTransactionAttributeValueLogDataByBaseAttributeID(baseAttributeID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all PaymentTransactionAttributeValueLog data by a key.</summary>
		///
		/// <param name="baseAttributeID">A key for PaymentTransactionAttributeValueLog items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Payments.PaymentTransactionAttributeValueLog> GetAllPaymentTransactionAttributeValueLogDataByBaseAttributeID(Guid baseAttributeID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Payments.PaymentTransactionAttributeValueLog> sortableList = new BLL.SortableList<BLL.Payments.PaymentTransactionAttributeValueLog>(DAL.Payments.PaymentTransactionAttributeValueLog.GetAllPaymentTransactionAttributeValueLogDataByBaseAttributeID(baseAttributeID, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Payments.PaymentTransactionAttributeValueLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Payments.GetAllPaymentTransactionAttributeValueLogDataByBaseAttributeID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all PaymentTransactionAttributeValueLog data by criteria.</summary>
		///
		/// <param name="attributeValue">A key for PaymentTransactionAttributeValueLog items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for PaymentTransactionAttributeValueLog items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for PaymentTransactionAttributeValueLog items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Payments.PaymentTransactionAttributeValueLog> GetAllPaymentTransactionAttributeValueLogDataByCriteria(string attributeValue, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Payments.PaymentTransactionAttributeValueLogManager.GetAllPaymentTransactionAttributeValueLogDataByCriteria(attributeValue, lastModifiedDateStart, lastModifiedDateEnd, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all PaymentTransactionAttributeValueLog data by criteria.</summary>
		///
		/// <param name="attributeValue">A key for PaymentTransactionAttributeValueLog items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for PaymentTransactionAttributeValueLog items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for PaymentTransactionAttributeValueLog items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Payments.PaymentTransactionAttributeValueLog> GetAllPaymentTransactionAttributeValueLogDataByCriteria(string attributeValue, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd)
		{
			// perform main method tasks
			return BLL.Payments.PaymentTransactionAttributeValueLogManager.GetAllPaymentTransactionAttributeValueLogDataByCriteria(attributeValue, lastModifiedDateStart, lastModifiedDateEnd, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all PaymentTransactionAttributeValueLog data by criteria.</summary>
		///
		/// <param name="attributeValue">A key for PaymentTransactionAttributeValueLog items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for PaymentTransactionAttributeValueLog items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for PaymentTransactionAttributeValueLog items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Payments.PaymentTransactionAttributeValueLog> GetAllPaymentTransactionAttributeValueLogDataByCriteria(string attributeValue, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Payments.PaymentTransactionAttributeValueLog> sortableList = new BLL.SortableList<BLL.Payments.PaymentTransactionAttributeValueLog>(DAL.Payments.PaymentTransactionAttributeValueLog.GetAllPaymentTransactionAttributeValueLogDataByCriteria(attributeValue, lastModifiedDateStart, lastModifiedDateEnd, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Payments.PaymentTransactionAttributeValueLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Payments.GetAllPaymentTransactionAttributeValueLogDataByCriteria");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all PaymentTransactionAttributeValueLog data by a key.</summary>
		///
		/// <param name="paymentTransactionLogID">A key for PaymentTransactionAttributeValueLog items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Payments.PaymentTransactionAttributeValueLog> GetAllPaymentTransactionAttributeValueLogDataByPaymentTransactionLogID(Guid paymentTransactionLogID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Payments.PaymentTransactionAttributeValueLogManager.GetAllPaymentTransactionAttributeValueLogDataByPaymentTransactionLogID(paymentTransactionLogID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all PaymentTransactionAttributeValueLog data by a key.</summary>
		///
		/// <param name="paymentTransactionLogID">A key for PaymentTransactionAttributeValueLog items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Payments.PaymentTransactionAttributeValueLog> GetAllPaymentTransactionAttributeValueLogDataByPaymentTransactionLogID(Guid paymentTransactionLogID)
		{
			// perform main method tasks
			return BLL.Payments.PaymentTransactionAttributeValueLogManager.GetAllPaymentTransactionAttributeValueLogDataByPaymentTransactionLogID(paymentTransactionLogID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all PaymentTransactionAttributeValueLog data by a key.</summary>
		///
		/// <param name="paymentTransactionLogID">A key for PaymentTransactionAttributeValueLog items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Payments.PaymentTransactionAttributeValueLog> GetAllPaymentTransactionAttributeValueLogDataByPaymentTransactionLogID(Guid paymentTransactionLogID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Payments.PaymentTransactionAttributeValueLog> sortableList = new BLL.SortableList<BLL.Payments.PaymentTransactionAttributeValueLog>(DAL.Payments.PaymentTransactionAttributeValueLog.GetAllPaymentTransactionAttributeValueLogDataByPaymentTransactionLogID(paymentTransactionLogID, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Payments.PaymentTransactionAttributeValueLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Payments.GetAllPaymentTransactionAttributeValueLogDataByPaymentTransactionLogID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all PaymentTransactionAttributeValueLog data by criteria.</summary>
		///
		/// <param name="attributeValue">A key for PaymentTransactionAttributeValueLog items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for PaymentTransactionAttributeValueLog items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for PaymentTransactionAttributeValueLog items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Payments.PaymentTransactionAttributeValueLog> GetManyPaymentTransactionAttributeValueLogDataByCriteria(string attributeValue, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Payments.PaymentTransactionAttributeValueLogManager.GetManyPaymentTransactionAttributeValueLogDataByCriteria(attributeValue, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all PaymentTransactionAttributeValueLog data by criteria.</summary>
		///
		/// <param name="attributeValue">A key for PaymentTransactionAttributeValueLog items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for PaymentTransactionAttributeValueLog items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for PaymentTransactionAttributeValueLog items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Payments.PaymentTransactionAttributeValueLog> GetManyPaymentTransactionAttributeValueLogDataByCriteria(string attributeValue, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Payments.PaymentTransactionAttributeValueLog> sortableList = new BLL.SortableList<BLL.Payments.PaymentTransactionAttributeValueLog>(DAL.Payments.PaymentTransactionAttributeValueLog.GetManyPaymentTransactionAttributeValueLogDataByCriteria(attributeValue, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Payments.PaymentTransactionAttributeValueLog loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Payments.GetManyPaymentTransactionAttributeValueLogDataByCriteria");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single PaymentTransactionAttributeValueLog by an index.</summary>
		///
		/// <param name="paymentTransactionAttributeValueLogID">The index for PaymentTransactionAttributeValueLog to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Payments.PaymentTransactionAttributeValueLog GetOnePaymentTransactionAttributeValueLog(Guid paymentTransactionAttributeValueLogID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Payments.PaymentTransactionAttributeValueLogManager.GetOnePaymentTransactionAttributeValueLog(paymentTransactionAttributeValueLogID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single PaymentTransactionAttributeValueLog by an index.</summary>
		///
		/// <param name="paymentTransactionAttributeValueLogID">The index for PaymentTransactionAttributeValueLog to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Payments.PaymentTransactionAttributeValueLog GetOnePaymentTransactionAttributeValueLog(Guid paymentTransactionAttributeValueLogID)
		{
			// perform main method tasks
			return BLL.Payments.PaymentTransactionAttributeValueLogManager.GetOnePaymentTransactionAttributeValueLog(paymentTransactionAttributeValueLogID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single PaymentTransactionAttributeValueLog by an index.</summary>
		///
		/// <param name="paymentTransactionAttributeValueLogID">The index for PaymentTransactionAttributeValueLog to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Payments.PaymentTransactionAttributeValueLog GetOnePaymentTransactionAttributeValueLog(Guid paymentTransactionAttributeValueLogID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.Payments.PaymentTransactionAttributeValueLog itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.Payments.PaymentTransactionAttributeValueLog)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.Payments.PaymentTransactionAttributeValueLog.GetCacheKey(typeof(BLL.Payments.PaymentTransactionAttributeValueLog), "PrimaryKey", paymentTransactionAttributeValueLogID.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.Payments.PaymentTransactionAttributeValueLog)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.Payments.PaymentTransactionAttributeValueLog item = DAL.Payments.PaymentTransactionAttributeValueLog.GetOnePaymentTransactionAttributeValueLog(paymentTransactionAttributeValueLogID, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.Payments.PaymentTransactionAttributeValueLog();
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
				throw Utility.CustomAppException.WrapException(ex, "BLL.Payments.GetOnePaymentTransactionAttributeValueLog");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method logs PaymentTransactionAttributeValueLog data.</summary>
		///
		/// <param name="item">The PaymentTransactionAttributeValueLog to be logged.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void LogOnePaymentTransactionAttributeValueLog(BLL.Payments.PaymentTransactionAttributeValueLog item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Payments.PaymentTransactionAttributeValueLogManager.LogOnePaymentTransactionAttributeValueLog(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method logs PaymentTransactionAttributeValueLog data.</summary>
		///
		/// <param name="item">The PaymentTransactionAttributeValueLog to be logged.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void LogOnePaymentTransactionAttributeValueLog(BLL.Payments.PaymentTransactionAttributeValueLog item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Payments.PaymentTransactionAttributeValueLog itemDAL = new DAL.Payments.PaymentTransactionAttributeValueLog();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Payments.PaymentTransactionAttributeValueLog.LogOnePaymentTransactionAttributeValueLog(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Payments.LogOnePaymentTransactionAttributeValueLog");
			}
		}
		#endregion Methods
	}
}