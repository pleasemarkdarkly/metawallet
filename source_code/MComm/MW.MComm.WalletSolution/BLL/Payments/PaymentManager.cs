
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
	/// <summary>This class is used to manage Payment related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class PaymentManager
	{
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public PaymentManager()
		{
			//
			// constructor logic
			//
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Payment data by a key.</summary>
		///
		/// <param name="destinationAccountID">A key for Payment items to be deleted</param>
		/// <param name="creditMetaPartnerID">A key for Payment items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllPaymentDataByDestinationAccountIDAndCreditMetaPartnerID(Guid destinationAccountID, Guid creditMetaPartnerID)
		{
			// perform main method tasks
			BLL.Payments.PaymentManager.DeleteAllPaymentDataByDestinationAccountIDAndCreditMetaPartnerID(destinationAccountID, creditMetaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Payment data by a key.</summary>
		///
		/// <param name="destinationAccountID">A key for Payment items to be deleted</param>
		/// <param name="creditMetaPartnerID">A key for Payment items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllPaymentDataByDestinationAccountIDAndCreditMetaPartnerID(Guid destinationAccountID, Guid creditMetaPartnerID, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Payments.Payment.DeleteAllPaymentDataByDestinationAccountIDAndCreditMetaPartnerID(destinationAccountID, creditMetaPartnerID, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Payments.DeleteAllPaymentDataByDestinationAccountIDAndCreditMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Payment data by a key.</summary>
		///
		/// <param name="orderID">A key for Payment items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllPaymentDataByOrderID(Guid orderID)
		{
			// perform main method tasks
			BLL.Payments.PaymentManager.DeleteAllPaymentDataByOrderID(orderID, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Payment data by a key.</summary>
		///
		/// <param name="orderID">A key for Payment items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllPaymentDataByOrderID(Guid orderID, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Payments.Payment.DeleteAllPaymentDataByOrderID(orderID, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Payments.DeleteAllPaymentDataByOrderID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Payment data by a key.</summary>
		///
		/// <param name="paymentStatusCode">A key for Payment items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllPaymentDataByPaymentStatusCode(int paymentStatusCode)
		{
			// perform main method tasks
			BLL.Payments.PaymentManager.DeleteAllPaymentDataByPaymentStatusCode(paymentStatusCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Payment data by a key.</summary>
		///
		/// <param name="paymentStatusCode">A key for Payment items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllPaymentDataByPaymentStatusCode(int paymentStatusCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Payments.Payment.DeleteAllPaymentDataByPaymentStatusCode(paymentStatusCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Payments.DeleteAllPaymentDataByPaymentStatusCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Payment data by a key.</summary>
		///
		/// <param name="sourceAccountID">A key for Payment items to be deleted</param>
		/// <param name="debitMetaPartnerID">A key for Payment items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllPaymentDataBySourceAccountIDAndDebitMetaPartnerID(Guid sourceAccountID, Guid debitMetaPartnerID)
		{
			// perform main method tasks
			BLL.Payments.PaymentManager.DeleteAllPaymentDataBySourceAccountIDAndDebitMetaPartnerID(sourceAccountID, debitMetaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Payment data by a key.</summary>
		///
		/// <param name="sourceAccountID">A key for Payment items to be deleted</param>
		/// <param name="debitMetaPartnerID">A key for Payment items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllPaymentDataBySourceAccountIDAndDebitMetaPartnerID(Guid sourceAccountID, Guid debitMetaPartnerID, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Payments.Payment.DeleteAllPaymentDataBySourceAccountIDAndDebitMetaPartnerID(sourceAccountID, debitMetaPartnerID, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Payments.DeleteAllPaymentDataBySourceAccountIDAndDebitMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes Payment data.</summary>
		///
		/// <param name="item">The Payment to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOnePayment(BLL.Payments.Payment item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Payments.PaymentManager.DeleteOnePayment(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes Payment data.</summary>
		///
		/// <param name="item">The Payment to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOnePayment(BLL.Payments.Payment item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Payments.Payment itemDAL = new DAL.Payments.Payment();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Payments.Payment.DeleteOnePayment(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = false;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Payments.DeleteOnePayment");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Payment data.</summary>
		///
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Payments.Payment> GetAllPaymentData(MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Payments.PaymentManager.GetAllPaymentData(BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Payment data.</summary>
		///
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Payments.Payment> GetAllPaymentData()
		{
			// perform main method tasks
			return BLL.Payments.PaymentManager.GetAllPaymentData(BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Payment data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Payments.Payment> GetAllPaymentData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Payments.Payment> sortableList = new BLL.SortableList<BLL.Payments.Payment>(DAL.Payments.Payment.GetAllPaymentData(dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Payments.Payment loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Payments.GetAllPaymentData");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Payment data by criteria.</summary>
		///
		/// <param name="paymentStatusCode">A key for Payment items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Payment items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Payment items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Payments.Payment> GetAllPaymentDataByCriteria(int? paymentStatusCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Payments.PaymentManager.GetAllPaymentDataByCriteria(paymentStatusCode, lastModifiedDateStart, lastModifiedDateEnd, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Payment data by criteria.</summary>
		///
		/// <param name="paymentStatusCode">A key for Payment items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Payment items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Payment items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Payments.Payment> GetAllPaymentDataByCriteria(int? paymentStatusCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd)
		{
			// perform main method tasks
			return BLL.Payments.PaymentManager.GetAllPaymentDataByCriteria(paymentStatusCode, lastModifiedDateStart, lastModifiedDateEnd, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Payment data by criteria.</summary>
		///
		/// <param name="paymentStatusCode">A key for Payment items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Payment items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Payment items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Payments.Payment> GetAllPaymentDataByCriteria(int? paymentStatusCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Payments.Payment> sortableList = new BLL.SortableList<BLL.Payments.Payment>(DAL.Payments.Payment.GetAllPaymentDataByCriteria(paymentStatusCode, lastModifiedDateStart, lastModifiedDateEnd, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Payments.Payment loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Payments.GetAllPaymentDataByCriteria");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Payment data by a key.</summary>
		///
		/// <param name="destinationAccountID">A key for Payment items to be fetched</param>
		/// <param name="creditMetaPartnerID">A key for Payment items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Payments.Payment> GetAllPaymentDataByDestinationAccountIDAndCreditMetaPartnerID(Guid destinationAccountID, Guid creditMetaPartnerID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Payments.PaymentManager.GetAllPaymentDataByDestinationAccountIDAndCreditMetaPartnerID(destinationAccountID, creditMetaPartnerID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Payment data by a key.</summary>
		///
		/// <param name="destinationAccountID">A key for Payment items to be fetched</param>
		/// <param name="creditMetaPartnerID">A key for Payment items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Payments.Payment> GetAllPaymentDataByDestinationAccountIDAndCreditMetaPartnerID(Guid destinationAccountID, Guid creditMetaPartnerID)
		{
			// perform main method tasks
			return BLL.Payments.PaymentManager.GetAllPaymentDataByDestinationAccountIDAndCreditMetaPartnerID(destinationAccountID, creditMetaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Payment data by a key.</summary>
		///
		/// <param name="destinationAccountID">A key for Payment items to be fetched</param>
		/// <param name="creditMetaPartnerID">A key for Payment items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Payments.Payment> GetAllPaymentDataByDestinationAccountIDAndCreditMetaPartnerID(Guid destinationAccountID, Guid creditMetaPartnerID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Payments.Payment> sortableList = new BLL.SortableList<BLL.Payments.Payment>(DAL.Payments.Payment.GetAllPaymentDataByDestinationAccountIDAndCreditMetaPartnerID(destinationAccountID, creditMetaPartnerID, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Payments.Payment loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Payments.GetAllPaymentDataByDestinationAccountIDAndCreditMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Payment data by a key.</summary>
		///
		/// <param name="orderID">A key for Payment items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Payments.Payment> GetAllPaymentDataByOrderID(Guid orderID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Payments.PaymentManager.GetAllPaymentDataByOrderID(orderID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Payment data by a key.</summary>
		///
		/// <param name="orderID">A key for Payment items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Payments.Payment> GetAllPaymentDataByOrderID(Guid orderID)
		{
			// perform main method tasks
			return BLL.Payments.PaymentManager.GetAllPaymentDataByOrderID(orderID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Payment data by a key.</summary>
		///
		/// <param name="orderID">A key for Payment items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Payments.Payment> GetAllPaymentDataByOrderID(Guid orderID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Payments.Payment> sortableList = new BLL.SortableList<BLL.Payments.Payment>(DAL.Payments.Payment.GetAllPaymentDataByOrderID(orderID, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Payments.Payment loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Payments.GetAllPaymentDataByOrderID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Payment data by a key.</summary>
		///
		/// <param name="paymentStatusCode">A key for Payment items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Payments.Payment> GetAllPaymentDataByPaymentStatusCode(int paymentStatusCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Payments.PaymentManager.GetAllPaymentDataByPaymentStatusCode(paymentStatusCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Payment data by a key.</summary>
		///
		/// <param name="paymentStatusCode">A key for Payment items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Payments.Payment> GetAllPaymentDataByPaymentStatusCode(int paymentStatusCode)
		{
			// perform main method tasks
			return BLL.Payments.PaymentManager.GetAllPaymentDataByPaymentStatusCode(paymentStatusCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Payment data by a key.</summary>
		///
		/// <param name="paymentStatusCode">A key for Payment items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Payments.Payment> GetAllPaymentDataByPaymentStatusCode(int paymentStatusCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Payments.Payment> sortableList = new BLL.SortableList<BLL.Payments.Payment>(DAL.Payments.Payment.GetAllPaymentDataByPaymentStatusCode(paymentStatusCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Payments.Payment loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Payments.GetAllPaymentDataByPaymentStatusCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Payment data by a key.</summary>
		///
		/// <param name="sourceAccountID">A key for Payment items to be fetched</param>
		/// <param name="debitMetaPartnerID">A key for Payment items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Payments.Payment> GetAllPaymentDataBySourceAccountIDAndDebitMetaPartnerID(Guid sourceAccountID, Guid debitMetaPartnerID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Payments.PaymentManager.GetAllPaymentDataBySourceAccountIDAndDebitMetaPartnerID(sourceAccountID, debitMetaPartnerID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Payment data by a key.</summary>
		///
		/// <param name="sourceAccountID">A key for Payment items to be fetched</param>
		/// <param name="debitMetaPartnerID">A key for Payment items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Payments.Payment> GetAllPaymentDataBySourceAccountIDAndDebitMetaPartnerID(Guid sourceAccountID, Guid debitMetaPartnerID)
		{
			// perform main method tasks
			return BLL.Payments.PaymentManager.GetAllPaymentDataBySourceAccountIDAndDebitMetaPartnerID(sourceAccountID, debitMetaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Payment data by a key.</summary>
		///
		/// <param name="sourceAccountID">A key for Payment items to be fetched</param>
		/// <param name="debitMetaPartnerID">A key for Payment items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Payments.Payment> GetAllPaymentDataBySourceAccountIDAndDebitMetaPartnerID(Guid sourceAccountID, Guid debitMetaPartnerID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Payments.Payment> sortableList = new BLL.SortableList<BLL.Payments.Payment>(DAL.Payments.Payment.GetAllPaymentDataBySourceAccountIDAndDebitMetaPartnerID(sourceAccountID, debitMetaPartnerID, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Payments.Payment loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Payments.GetAllPaymentDataBySourceAccountIDAndDebitMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Payment data by criteria.</summary>
		///
		/// <param name="paymentStatusCode">A key for Payment items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Payment items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Payment items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Payments.Payment> GetManyPaymentDataByCriteria(int? paymentStatusCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Payments.PaymentManager.GetManyPaymentDataByCriteria(paymentStatusCode, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Payment data by criteria.</summary>
		///
		/// <param name="paymentStatusCode">A key for Payment items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Payment items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Payment items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Payments.Payment> GetManyPaymentDataByCriteria(int? paymentStatusCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Payments.Payment> sortableList = new BLL.SortableList<BLL.Payments.Payment>(DAL.Payments.Payment.GetManyPaymentDataByCriteria(paymentStatusCode, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Payments.Payment loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Payments.GetManyPaymentDataByCriteria");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single Payment by an index.</summary>
		///
		/// <param name="paymentID">The index for Payment to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Payments.Payment GetOnePayment(Guid paymentID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Payments.PaymentManager.GetOnePayment(paymentID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single Payment by an index.</summary>
		///
		/// <param name="paymentID">The index for Payment to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Payments.Payment GetOnePayment(Guid paymentID)
		{
			// perform main method tasks
			return BLL.Payments.PaymentManager.GetOnePayment(paymentID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single Payment by an index.</summary>
		///
		/// <param name="paymentID">The index for Payment to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Payments.Payment GetOnePayment(Guid paymentID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.Payments.Payment itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.Payments.Payment)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.Payments.Payment.GetCacheKey(typeof(BLL.Payments.Payment), "PrimaryKey", paymentID.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.Payments.Payment)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.Payments.Payment item = DAL.Payments.Payment.GetOnePayment(paymentID, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.Payments.Payment();
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
				throw Utility.CustomAppException.WrapException(ex, "BLL.Payments.GetOnePayment");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method inserts or updates Payment data.</summary>
		///
		/// <param name="item">The Payment to be inserted or updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpsertOnePayment(BLL.Payments.Payment item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Payments.PaymentManager.UpsertOnePayment(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method inserts or updates Payment data.</summary>
		///
		/// <param name="item">The Payment to be inserted or updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpsertOnePayment(BLL.Payments.Payment item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Payments.Payment itemDAL = new DAL.Payments.Payment();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Payments.Payment.UpsertOnePayment(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Payments.UpsertOnePayment");
			}
		}
		#endregion Methods
	}
}