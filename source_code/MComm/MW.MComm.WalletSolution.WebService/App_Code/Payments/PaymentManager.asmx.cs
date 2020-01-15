
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
using MW.MComm.WalletSolution.WebService;
using MW.MComm.WalletSolution.WebService.Payments;
using BLL = MW.MComm.WalletSolution.BLL;
using MW.MComm.WalletSolution.BLL.Payments;
using MOD.Data;
using Utility = MW.MComm.WalletSolution.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
namespace MW.MComm.WalletSolution.WebService.Payments
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage Payment related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public class PaymentManager : System.Web.Services.WebService
	{
		#region "Service Methods"
		// ------------------------------------------------------------------
		/// <summary>This web service method deletes all Payment data by a key.</summary>
		///
		/// <param name="destinationAccountID">A key for Payment items to be deleted</param>
		/// <param name="creditMetaPartnerID">A key for Payment items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Payments.PaymentResults DeleteAllPaymentDataByDestinationAccountIDAndCreditMetaPartnerID(string destinationAccountID, string creditMetaPartnerID)
		{
			Components.Payments.PaymentResults results = new Components.Payments.PaymentResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Payments.PaymentManager.DeleteAllPaymentDataByDestinationAccountIDAndCreditMetaPartnerID(MOD.Data.DataHelper.GetGuid(destinationAccountID, MOD.Data.DefaultValue.Guid), MOD.Data.DataHelper.GetGuid(creditMetaPartnerID, MOD.Data.DefaultValue.Guid));
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
		/// <summary>This web service method deletes all Payment data by a key.</summary>
		///
		/// <param name="orderID">A key for Payment items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Payments.PaymentResults DeleteAllPaymentDataByOrderID(string orderID)
		{
			Components.Payments.PaymentResults results = new Components.Payments.PaymentResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Payments.PaymentManager.DeleteAllPaymentDataByOrderID(MOD.Data.DataHelper.GetGuid(orderID, MOD.Data.DefaultValue.Guid));
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
		/// <summary>This web service method deletes all Payment data by a key.</summary>
		///
		/// <param name="paymentStatusCode">A key for Payment items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Payments.PaymentResults DeleteAllPaymentDataByPaymentStatusCode(int paymentStatusCode)
		{
			Components.Payments.PaymentResults results = new Components.Payments.PaymentResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Payments.PaymentManager.DeleteAllPaymentDataByPaymentStatusCode(paymentStatusCode);
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
		/// <summary>This web service method deletes all Payment data by a key.</summary>
		///
		/// <param name="sourceAccountID">A key for Payment items to be deleted</param>
		/// <param name="debitMetaPartnerID">A key for Payment items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Payments.PaymentResults DeleteAllPaymentDataBySourceAccountIDAndDebitMetaPartnerID(string sourceAccountID, string debitMetaPartnerID)
		{
			Components.Payments.PaymentResults results = new Components.Payments.PaymentResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Payments.PaymentManager.DeleteAllPaymentDataBySourceAccountIDAndDebitMetaPartnerID(MOD.Data.DataHelper.GetGuid(sourceAccountID, MOD.Data.DefaultValue.Guid), MOD.Data.DataHelper.GetGuid(debitMetaPartnerID, MOD.Data.DefaultValue.Guid));
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
		/// <summary>This web service method deletes Payment data.</summary>
		///
		/// <param name="item">The Payment to be deleted.</param>
		/// <param name="performCascadeOperation">Flag, indicating if a cascade delete should be performed on the Payment item.</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Payments.PaymentResults DeleteOnePayment(BLL.Payments.Payment item, bool performCascadeOperation)
		{
			Components.Payments.PaymentResults results = new Components.Payments.PaymentResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Payments.PaymentManager.DeleteOnePayment(item, performCascadeOperation);
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
		/// <summary>This web service method gets all Payment data.</summary>
		///
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Payments.PaymentResults GetAllPaymentData(string sortColumn, string sortDirection)
		{
			Components.Payments.PaymentResults results = new Components.Payments.PaymentResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Payments.PaymentManager.GetAllPaymentData(Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Payment data by criteria.</summary>
		///
		/// <param name="paymentStatusCode">A key for Payment items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Payment items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Payment items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Payments.PaymentResults GetAllPaymentDataByCriteria(string paymentStatusCode, string lastModifiedDateStart, string lastModifiedDateEnd, string sortColumn, string sortDirection)
		{
			Components.Payments.PaymentResults results = new Components.Payments.PaymentResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Payments.PaymentManager.GetAllPaymentDataByCriteria(MOD.Data.SearchHelper.GetInt(paymentStatusCode), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateStart), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateEnd), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Payment data by a key.</summary>
		///
		/// <param name="destinationAccountID">A key for Payment items to be fetched</param>
		/// <param name="creditMetaPartnerID">A key for Payment items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Payments.PaymentResults GetAllPaymentDataByDestinationAccountIDAndCreditMetaPartnerID(string destinationAccountID, string creditMetaPartnerID, string sortColumn, string sortDirection)
		{
			Components.Payments.PaymentResults results = new Components.Payments.PaymentResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Payments.PaymentManager.GetAllPaymentDataByDestinationAccountIDAndCreditMetaPartnerID(MOD.Data.DataHelper.GetGuid(destinationAccountID, MOD.Data.DefaultValue.Guid), MOD.Data.DataHelper.GetGuid(creditMetaPartnerID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Payment data by a key.</summary>
		///
		/// <param name="orderID">A key for Payment items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Payments.PaymentResults GetAllPaymentDataByOrderID(string orderID, string sortColumn, string sortDirection)
		{
			Components.Payments.PaymentResults results = new Components.Payments.PaymentResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Payments.PaymentManager.GetAllPaymentDataByOrderID(MOD.Data.DataHelper.GetGuid(orderID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Payment data by a key.</summary>
		///
		/// <param name="paymentStatusCode">A key for Payment items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Payments.PaymentResults GetAllPaymentDataByPaymentStatusCode(string paymentStatusCode, string sortColumn, string sortDirection)
		{
			Components.Payments.PaymentResults results = new Components.Payments.PaymentResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Payments.PaymentManager.GetAllPaymentDataByPaymentStatusCode(MOD.Data.DataHelper.GetInt(paymentStatusCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Payment data by a key.</summary>
		///
		/// <param name="sourceAccountID">A key for Payment items to be fetched</param>
		/// <param name="debitMetaPartnerID">A key for Payment items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Payments.PaymentResults GetAllPaymentDataBySourceAccountIDAndDebitMetaPartnerID(string sourceAccountID, string debitMetaPartnerID, string sortColumn, string sortDirection)
		{
			Components.Payments.PaymentResults results = new Components.Payments.PaymentResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Payments.PaymentManager.GetAllPaymentDataBySourceAccountIDAndDebitMetaPartnerID(MOD.Data.DataHelper.GetGuid(sourceAccountID, MOD.Data.DefaultValue.Guid), MOD.Data.DataHelper.GetGuid(debitMetaPartnerID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Payment data by criteria.</summary>
		///
		/// <param name="paymentStatusCode">A key for Payment items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Payment items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Payment items to be fetched</param>
         /// <param name="startIndex">Start Index (beginning at 1)</param>
         /// <param name="pageSize">Page Size</param>
         /// <param name="maximumListSize">Maximum List Size</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Payments.PaymentResults GetManyPaymentDataByCriteria(string paymentStatusCode, string lastModifiedDateStart, string lastModifiedDateEnd, int startIndex, int pageSize, int maximumListSize, string sortColumn, string sortDirection)
		{
			Components.Payments.PaymentResults results = new Components.Payments.PaymentResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				int totalRecords = 0;
				bool maximumListSizeExceeded = false;
				results.Results = BLL.Payments.PaymentManager.GetManyPaymentDataByCriteria(MOD.Data.SearchHelper.GetInt(paymentStatusCode), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateStart), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateEnd), out totalRecords, out maximumListSizeExceeded, Globals.getDataOptions(sortColumn, sortDirection, startIndex, pageSize, maximumListSize));
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
		/// <summary>This web service method gets a single Payment by an index.</summary>
		///
		/// <param name="paymentID">The index for Payment to be fetched</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Payments.PaymentResults GetOnePayment(string paymentID, string sortColumn, string sortDirection)
		{
			Components.Payments.PaymentResults results = new Components.Payments.PaymentResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Payments.Payment item =  BLL.Payments.PaymentManager.GetOnePayment(MOD.Data.DataHelper.GetGuid(paymentID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
				// populate desired collections with lazy loading
				bool isAccessed = true;
				isAccessed = item.PaymentTransactionLogList.IsDirty;
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
		/// <summary>This web service method inserts or updates Payment data.</summary>
		///
		/// <param name="item">The Payment to be managed.</param>
		/// <param name="performCascadeOperation">Flag, indicating if a cascade operation should be performed on the Payment item.</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Payments.PaymentResults UpsertOnePayment(BLL.Payments.Payment item, bool performCascadeOperation)
		{
			Components.Payments.PaymentResults results = new Components.Payments.PaymentResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Payments.PaymentManager.UpsertOnePayment(item, performCascadeOperation);
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
		public PaymentManager()
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