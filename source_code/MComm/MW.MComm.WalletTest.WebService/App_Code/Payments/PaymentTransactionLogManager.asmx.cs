
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
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using MW.MComm.WalletTest.WebService;
using MW.MComm.WalletTest.WebService.Payments;
using BLL = MW.MComm.WalletSolution.BLL;
using MW.MComm.WalletSolution.BLL.Payments;
using MOD.Data;
using Utility = MW.MComm.WalletSolution.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
namespace MW.MComm.WalletTest.WebService.Payments
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage PaymentTransactionLog related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public class PaymentTransactionLogManager : System.Web.Services.WebService
	{
		#region "Service Methods"
		// ------------------------------------------------------------------
		/// <summary>This web service method gets all PaymentTransactionLog data.</summary>
		///
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Payments.PaymentTransactionLogResults GetAllPaymentTransactionLogData(string sortColumn, string sortDirection)
		{
			Components.Payments.PaymentTransactionLogResults results = new Components.Payments.PaymentTransactionLogResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Payments.PaymentTransactionLogManager.GetAllPaymentTransactionLogData(Globals.getDataOptions(sortColumn, sortDirection));
				results.TotalRecords = results.Results.Count;
			}
			catch (System.Exception ex)
			{
				results.StatusCode = -1;
				string exceptionMessage = "";
				System.Exception messageEx = ex;
				while (messageEx != null)
				{
					exceptionMessage += System.Environment.NewLine + messageEx.Message;
					messageEx = messageEx.InnerException;
				}
				results.StatusDescription = exceptionMessage;
			}
			finally
			{
			}
			return results;
		}
		// ------------------------------------------------------------------
		/// <summary>This web service method gets all PaymentTransactionLog data by criteria.</summary>
		///
		/// <param name="transactionTypeCode">A key for PaymentTransactionLog items to be fetched</param>
		/// <param name="transactionStatusCode">A key for PaymentTransactionLog items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for PaymentTransactionLog items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for PaymentTransactionLog items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Payments.PaymentTransactionLogResults GetAllPaymentTransactionLogDataByCriteria(string transactionTypeCode, string transactionStatusCode, string lastModifiedDateStart, string lastModifiedDateEnd, string sortColumn, string sortDirection)
		{
			Components.Payments.PaymentTransactionLogResults results = new Components.Payments.PaymentTransactionLogResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Payments.PaymentTransactionLogManager.GetAllPaymentTransactionLogDataByCriteria(MOD.Data.SearchHelper.GetInt(transactionTypeCode), MOD.Data.SearchHelper.GetInt(transactionStatusCode), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateStart), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateEnd), Globals.getDataOptions(sortColumn, sortDirection));
				results.TotalRecords = results.Results.Count;
			}
			catch (System.Exception ex)
			{
				results.StatusCode = -1;
				string exceptionMessage = "";
				System.Exception messageEx = ex;
				while (messageEx != null)
				{
					exceptionMessage += System.Environment.NewLine + messageEx.Message;
					messageEx = messageEx.InnerException;
				}
				results.StatusDescription = exceptionMessage;
			}
			finally
			{
			}
			return results;
		}
		// ------------------------------------------------------------------
		/// <summary>This web service method gets all PaymentTransactionLog data by a key.</summary>
		///
		/// <param name="paymentID">A key for PaymentTransactionLog items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Payments.PaymentTransactionLogResults GetAllPaymentTransactionLogDataByPaymentID(string paymentID, string sortColumn, string sortDirection)
		{
			Components.Payments.PaymentTransactionLogResults results = new Components.Payments.PaymentTransactionLogResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Payments.PaymentTransactionLogManager.GetAllPaymentTransactionLogDataByPaymentID(MOD.Data.DataHelper.GetGuid(paymentID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
				results.TotalRecords = results.Results.Count;
			}
			catch (System.Exception ex)
			{
				results.StatusCode = -1;
				string exceptionMessage = "";
				System.Exception messageEx = ex;
				while (messageEx != null)
				{
					exceptionMessage += System.Environment.NewLine + messageEx.Message;
					messageEx = messageEx.InnerException;
				}
				results.StatusDescription = exceptionMessage;
			}
			finally
			{
			}
			return results;
		}
		// ------------------------------------------------------------------
		/// <summary>This web service method gets all PaymentTransactionLog data by a key.</summary>
		///
		/// <param name="transactionStatusCode">A key for PaymentTransactionLog items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Payments.PaymentTransactionLogResults GetAllPaymentTransactionLogDataByTransactionStatusCode(string transactionStatusCode, string sortColumn, string sortDirection)
		{
			Components.Payments.PaymentTransactionLogResults results = new Components.Payments.PaymentTransactionLogResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Payments.PaymentTransactionLogManager.GetAllPaymentTransactionLogDataByTransactionStatusCode(MOD.Data.DataHelper.GetInt(transactionStatusCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
				results.TotalRecords = results.Results.Count;
			}
			catch (System.Exception ex)
			{
				results.StatusCode = -1;
				string exceptionMessage = "";
				System.Exception messageEx = ex;
				while (messageEx != null)
				{
					exceptionMessage += System.Environment.NewLine + messageEx.Message;
					messageEx = messageEx.InnerException;
				}
				results.StatusDescription = exceptionMessage;
			}
			finally
			{
			}
			return results;
		}
		// ------------------------------------------------------------------
		/// <summary>This web service method gets all PaymentTransactionLog data by a key.</summary>
		///
		/// <param name="transactionTypeCode">A key for PaymentTransactionLog items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Payments.PaymentTransactionLogResults GetAllPaymentTransactionLogDataByTransactionTypeCode(string transactionTypeCode, string sortColumn, string sortDirection)
		{
			Components.Payments.PaymentTransactionLogResults results = new Components.Payments.PaymentTransactionLogResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Payments.PaymentTransactionLogManager.GetAllPaymentTransactionLogDataByTransactionTypeCode(MOD.Data.DataHelper.GetInt(transactionTypeCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
				results.TotalRecords = results.Results.Count;
			}
			catch (System.Exception ex)
			{
				results.StatusCode = -1;
				string exceptionMessage = "";
				System.Exception messageEx = ex;
				while (messageEx != null)
				{
					exceptionMessage += System.Environment.NewLine + messageEx.Message;
					messageEx = messageEx.InnerException;
				}
				results.StatusDescription = exceptionMessage;
			}
			finally
			{
			}
			return results;
		}
		// ------------------------------------------------------------------
		/// <summary>This web service method gets all PaymentTransactionLog data by criteria.</summary>
		///
		/// <param name="transactionTypeCode">A key for PaymentTransactionLog items to be fetched</param>
		/// <param name="transactionStatusCode">A key for PaymentTransactionLog items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for PaymentTransactionLog items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for PaymentTransactionLog items to be fetched</param>
         /// <param name="startIndex">Start Index (beginning at 1)</param>
         /// <param name="pageSize">Page Size</param>
         /// <param name="maximumListSize">Maximum List Size</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Payments.PaymentTransactionLogResults GetManyPaymentTransactionLogDataByCriteria(string transactionTypeCode, string transactionStatusCode, string lastModifiedDateStart, string lastModifiedDateEnd, int startIndex, int pageSize, int maximumListSize, string sortColumn, string sortDirection)
		{
			Components.Payments.PaymentTransactionLogResults results = new Components.Payments.PaymentTransactionLogResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				int totalRecords = 0;
				bool maximumListSizeExceeded = false;
				results.Results = BLL.Payments.PaymentTransactionLogManager.GetManyPaymentTransactionLogDataByCriteria(MOD.Data.SearchHelper.GetInt(transactionTypeCode), MOD.Data.SearchHelper.GetInt(transactionStatusCode), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateStart), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateEnd), out totalRecords, out maximumListSizeExceeded, Globals.getDataOptions(sortColumn, sortDirection, startIndex, pageSize, maximumListSize));
				results.TotalRecords = results.Results.Count;
			}
			catch (System.Exception ex)
			{
				results.StatusCode = -1;
				string exceptionMessage = "";
				System.Exception messageEx = ex;
				while (messageEx != null)
				{
					exceptionMessage += System.Environment.NewLine + messageEx.Message;
					messageEx = messageEx.InnerException;
				}
				results.StatusDescription = exceptionMessage;
			}
			finally
			{
			}
			return results;
		}
		// ------------------------------------------------------------------
		/// <summary>This web service method gets a single PaymentTransactionLog by an index.</summary>
		///
		/// <param name="paymentTransactionLogID">The index for PaymentTransactionLog to be fetched</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Payments.PaymentTransactionLogResults GetOnePaymentTransactionLog(string paymentTransactionLogID, string sortColumn, string sortDirection)
		{
			Components.Payments.PaymentTransactionLogResults results = new Components.Payments.PaymentTransactionLogResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Payments.PaymentTransactionLog item =  BLL.Payments.PaymentTransactionLogManager.GetOnePaymentTransactionLog(MOD.Data.DataHelper.GetGuid(paymentTransactionLogID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
				// populate desired collections with lazy loading
				bool isAccessed = true;
				isAccessed = item.PaymentTransactionAttributeValueLogList.IsDirty;
				results.Results.Add(item);
			}
			catch (System.Exception ex)
			{
				results.StatusCode = -1;
				string exceptionMessage = "";
				System.Exception messageEx = ex;
				while (messageEx != null)
				{
					exceptionMessage += System.Environment.NewLine + messageEx.Message;
					messageEx = messageEx.InnerException;
				}
				results.StatusDescription = exceptionMessage;
			}
			finally
			{
			}
			return results;
		}
		// ------------------------------------------------------------------
		/// <summary>This web service method logs PaymentTransactionLog data.</summary>
		///
		/// <param name="paymentTransactionLogID">A property of PaymentTransactionLog item to be managed</param>
		/// <param name="paymentID">A property of PaymentTransactionLog item to be managed</param>
		/// <param name="transactionTypeCode">A property of PaymentTransactionLog item to be managed</param>
		/// <param name="transactionStatusCode">A property of PaymentTransactionLog item to be managed</param>
		/// <param name="transactionAmount">A property of PaymentTransactionLog item to be managed</param>
		/// <param name="responseCode">A property of PaymentTransactionLog item to be managed</param>
		/// <param name="transactionCode">A property of PaymentTransactionLog item to be managed</param>
		/// <param name="transactionMessage">A property of PaymentTransactionLog item to be managed</param>
		/// <param name="balance">A property of PaymentTransactionLog item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Payments.PaymentTransactionLogResults LogOnePaymentTransactionLog(string paymentTransactionLogID, string paymentID, int transactionTypeCode, int transactionStatusCode, decimal transactionAmount, string responseCode, string transactionCode, string transactionMessage, decimal balance)
		{
			Components.Payments.PaymentTransactionLogResults results = new Components.Payments.PaymentTransactionLogResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Payments.PaymentTransactionLog item = new BLL.Payments.PaymentTransactionLog();
				item.PaymentTransactionLogID = MOD.Data.DataHelper.GetGuid(paymentTransactionLogID, MOD.Data.DefaultValue.Guid);
				item.PaymentID = MOD.Data.DataHelper.GetGuid(paymentID, MOD.Data.DefaultValue.Guid);
				item.TransactionTypeCode = transactionTypeCode;
				item.TransactionStatusCode = transactionStatusCode;
				item.TransactionAmount = transactionAmount;
				item.ResponseCode = responseCode;
				item.TransactionCode = transactionCode;
				item.TransactionMessage = transactionMessage;
				item.Balance = balance;
				BLL.Payments.PaymentTransactionLogManager.LogOnePaymentTransactionLog(item, false);
				results.Results.Add(item);
			}
			catch (System.Exception ex)
			{
				results.StatusCode = -1;
				string exceptionMessage = "";
				System.Exception messageEx = ex;
				while (messageEx != null)
				{
					exceptionMessage += System.Environment.NewLine + messageEx.Message;
					messageEx = messageEx.InnerException;
				}
				results.StatusDescription = exceptionMessage;
			}
			finally
			{
			}
			return results;
		}
		#endregion "Service Methods"
		#region "Miscellaneous"
		// ------------------------------------------------------------------------------
		/// <summary>This web service method is the constructor.</summary>
		// ------------------------------------------------------------------------------
		public PaymentTransactionLogManager()
		{
			//
			// constructor logic
			//
			InitializeComponent();
		}
			//Required by the Web Services Designer
			private IContainer components = null;
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
		}
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if(disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}
		#endregion "Miscellaneous"
	}
}