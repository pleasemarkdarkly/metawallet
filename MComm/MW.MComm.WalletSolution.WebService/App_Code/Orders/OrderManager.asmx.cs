
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
using MW.MComm.WalletSolution.WebService.Orders;
using BLL = MW.MComm.WalletSolution.BLL;
using MW.MComm.WalletSolution.BLL.Orders;
using MOD.Data;
using Utility = MW.MComm.WalletSolution.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
namespace MW.MComm.WalletSolution.WebService.Orders
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage Order related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public class OrderManager : System.Web.Services.WebService
	{
		#region "Service Methods"
		// ------------------------------------------------------------------
		/// <summary>This web service method deletes all Order data by a key.</summary>
		///
		/// <param name="creditMetaPartnerID">A key for Order items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Orders.OrderResults DeleteAllOrderDataByCreditMetaPartnerID(string creditMetaPartnerID)
		{
			Components.Orders.OrderResults results = new Components.Orders.OrderResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Orders.OrderManager.DeleteAllOrderDataByCreditMetaPartnerID(MOD.Data.DataHelper.GetGuid(creditMetaPartnerID, MOD.Data.DefaultValue.Guid));
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
		/// <summary>This web service method deletes all Order data by a key.</summary>
		///
		/// <param name="currencyCode">A key for Order items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Orders.OrderResults DeleteAllOrderDataByCurrencyCode(int currencyCode)
		{
			Components.Orders.OrderResults results = new Components.Orders.OrderResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Orders.OrderManager.DeleteAllOrderDataByCurrencyCode(currencyCode);
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
		/// <summary>This web service method deletes all Order data by a key.</summary>
		///
		/// <param name="debitMetaPartnerID">A key for Order items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Orders.OrderResults DeleteAllOrderDataByDebitMetaPartnerID(string debitMetaPartnerID)
		{
			Components.Orders.OrderResults results = new Components.Orders.OrderResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Orders.OrderManager.DeleteAllOrderDataByDebitMetaPartnerID(MOD.Data.DataHelper.GetGuid(debitMetaPartnerID, MOD.Data.DefaultValue.Guid));
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
		/// <summary>This web service method deletes all Order data by a key.</summary>
		///
		/// <param name="logToAccountID">A key for Order items to be deleted</param>
		/// <param name="creditMetaPartnerID">A key for Order items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Orders.OrderResults DeleteAllOrderDataByLogToAccountIDAndCreditMetaPartnerID(string logToAccountID, string creditMetaPartnerID)
		{
			Components.Orders.OrderResults results = new Components.Orders.OrderResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Orders.OrderManager.DeleteAllOrderDataByLogToAccountIDAndCreditMetaPartnerID(MOD.Data.DataHelper.GetGuid(logToAccountID, MOD.Data.DefaultValue.Guid), MOD.Data.DataHelper.GetGuid(creditMetaPartnerID, MOD.Data.DefaultValue.Guid));
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
		/// <summary>This web service method deletes all Order data by a key.</summary>
		///
		/// <param name="orderStatusCode">A key for Order items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Orders.OrderResults DeleteAllOrderDataByOrderStatusCode(int orderStatusCode)
		{
			Components.Orders.OrderResults results = new Components.Orders.OrderResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Orders.OrderManager.DeleteAllOrderDataByOrderStatusCode(orderStatusCode);
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
		/// <summary>This web service method deletes Order data.</summary>
		///
		/// <param name="item">The Order to be deleted.</param>
		/// <param name="performCascadeOperation">Flag, indicating if a cascade delete should be performed on the Order item.</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Orders.OrderResults DeleteOneOrder(BLL.Orders.Order item, bool performCascadeOperation)
		{
			Components.Orders.OrderResults results = new Components.Orders.OrderResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Orders.OrderManager.DeleteOneOrder(item, performCascadeOperation);
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
		/// <summary>This web service method gets all Order data.</summary>
		///
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Orders.OrderResults GetAllOrderData(string sortColumn, string sortDirection)
		{
			Components.Orders.OrderResults results = new Components.Orders.OrderResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Orders.OrderManager.GetAllOrderData(Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Order data by a key.</summary>
		///
		/// <param name="creditMetaPartnerID">A key for Order items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Orders.OrderResults GetAllOrderDataByCreditMetaPartnerID(string creditMetaPartnerID, string sortColumn, string sortDirection)
		{
			Components.Orders.OrderResults results = new Components.Orders.OrderResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Orders.OrderManager.GetAllOrderDataByCreditMetaPartnerID(MOD.Data.DataHelper.GetGuid(creditMetaPartnerID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Order data by criteria.</summary>
		///
		/// <param name="currencyCode">A key for Order items to be fetched</param>
		/// <param name="orderStatusCode">A key for Order items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Order items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Order items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Orders.OrderResults GetAllOrderDataByCriteria(string currencyCode, string orderStatusCode, string lastModifiedDateStart, string lastModifiedDateEnd, string sortColumn, string sortDirection)
		{
			Components.Orders.OrderResults results = new Components.Orders.OrderResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Orders.OrderManager.GetAllOrderDataByCriteria(MOD.Data.SearchHelper.GetInt(currencyCode), MOD.Data.SearchHelper.GetInt(orderStatusCode), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateStart), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateEnd), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Order data by a key.</summary>
		///
		/// <param name="currencyCode">A key for Order items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Orders.OrderResults GetAllOrderDataByCurrencyCode(string currencyCode, string sortColumn, string sortDirection)
		{
			Components.Orders.OrderResults results = new Components.Orders.OrderResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Orders.OrderManager.GetAllOrderDataByCurrencyCode(MOD.Data.DataHelper.GetInt(currencyCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Order data by a key.</summary>
		///
		/// <param name="debitMetaPartnerID">A key for Order items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Orders.OrderResults GetAllOrderDataByDebitMetaPartnerID(string debitMetaPartnerID, string sortColumn, string sortDirection)
		{
			Components.Orders.OrderResults results = new Components.Orders.OrderResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Orders.OrderManager.GetAllOrderDataByDebitMetaPartnerID(MOD.Data.DataHelper.GetGuid(debitMetaPartnerID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Order data by a key.</summary>
		///
		/// <param name="logToAccountID">A key for Order items to be fetched</param>
		/// <param name="creditMetaPartnerID">A key for Order items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Orders.OrderResults GetAllOrderDataByLogToAccountIDAndCreditMetaPartnerID(string logToAccountID, string creditMetaPartnerID, string sortColumn, string sortDirection)
		{
			Components.Orders.OrderResults results = new Components.Orders.OrderResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Orders.OrderManager.GetAllOrderDataByLogToAccountIDAndCreditMetaPartnerID(MOD.Data.DataHelper.GetGuid(logToAccountID, MOD.Data.DefaultValue.Guid), MOD.Data.DataHelper.GetGuid(creditMetaPartnerID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Order data by a key.</summary>
		///
		/// <param name="orderStatusCode">A key for Order items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Orders.OrderResults GetAllOrderDataByOrderStatusCode(string orderStatusCode, string sortColumn, string sortDirection)
		{
			Components.Orders.OrderResults results = new Components.Orders.OrderResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Orders.OrderManager.GetAllOrderDataByOrderStatusCode(MOD.Data.DataHelper.GetInt(orderStatusCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Order data by criteria.</summary>
		///
		/// <param name="currencyCode">A key for Order items to be fetched</param>
		/// <param name="orderStatusCode">A key for Order items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Order items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Order items to be fetched</param>
         /// <param name="startIndex">Start Index (beginning at 1)</param>
         /// <param name="pageSize">Page Size</param>
         /// <param name="maximumListSize">Maximum List Size</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Orders.OrderResults GetManyOrderDataByCriteria(string currencyCode, string orderStatusCode, string lastModifiedDateStart, string lastModifiedDateEnd, int startIndex, int pageSize, int maximumListSize, string sortColumn, string sortDirection)
		{
			Components.Orders.OrderResults results = new Components.Orders.OrderResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				int totalRecords = 0;
				bool maximumListSizeExceeded = false;
				results.Results = BLL.Orders.OrderManager.GetManyOrderDataByCriteria(MOD.Data.SearchHelper.GetInt(currencyCode), MOD.Data.SearchHelper.GetInt(orderStatusCode), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateStart), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateEnd), out totalRecords, out maximumListSizeExceeded, Globals.getDataOptions(sortColumn, sortDirection, startIndex, pageSize, maximumListSize));
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
		/// <summary>This web service method gets a single Order by an index.</summary>
		///
		/// <param name="orderID">The index for Order to be fetched</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Orders.OrderResults GetOneOrder(string orderID, string sortColumn, string sortDirection)
		{
			Components.Orders.OrderResults results = new Components.Orders.OrderResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Orders.Order item =  BLL.Orders.OrderManager.GetOneOrder(MOD.Data.DataHelper.GetGuid(orderID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
				// populate desired collections with lazy loading
				bool isAccessed = true;
				isAccessed = item.PaymentList.IsDirty;
				isAccessed = item.OrderCouponList.IsDirty;
				isAccessed = item.OrderFeeList.IsDirty;
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
		/// <summary>This web service method gets a single Order by an index.</summary>
		///
		/// <param name="orderID">The index for Order to be fetched</param>
		/// <param name="debitMetaPartnerID">The index for Order to be fetched</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Orders.OrderResults GetOneOrderByOrderIDAndDebitMetaPartnerID(string orderID, string debitMetaPartnerID, string sortColumn, string sortDirection)
		{
			Components.Orders.OrderResults results = new Components.Orders.OrderResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Orders.Order item =  BLL.Orders.OrderManager.GetOneOrderByOrderIDAndDebitMetaPartnerID(MOD.Data.DataHelper.GetGuid(orderID, MOD.Data.DefaultValue.Guid), MOD.Data.DataHelper.GetGuid(debitMetaPartnerID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
				// populate desired collections with lazy loading
				bool isAccessed = true;
				isAccessed = item.PaymentList.IsDirty;
				isAccessed = item.OrderCouponList.IsDirty;
				isAccessed = item.OrderFeeList.IsDirty;
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
		/// <summary>This web service method gets a single Order by an index.</summary>
		///
		/// <param name="orderID">The index for Order to be fetched</param>
		/// <param name="debitMetaPartnerID">The index for Order to be fetched</param>
		/// <param name="creditMetaPartnerID">The index for Order to be fetched</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Orders.OrderResults GetOneOrderByOrderIDAndDebitMetaPartnerIDAndCreditMetaPartnerID(string orderID, string debitMetaPartnerID, string creditMetaPartnerID, string sortColumn, string sortDirection)
		{
			Components.Orders.OrderResults results = new Components.Orders.OrderResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Orders.Order item =  BLL.Orders.OrderManager.GetOneOrderByOrderIDAndDebitMetaPartnerIDAndCreditMetaPartnerID(MOD.Data.DataHelper.GetGuid(orderID, MOD.Data.DefaultValue.Guid), MOD.Data.DataHelper.GetGuid(debitMetaPartnerID, MOD.Data.DefaultValue.Guid), MOD.Data.DataHelper.GetGuid(creditMetaPartnerID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
				// populate desired collections with lazy loading
				bool isAccessed = true;
				isAccessed = item.PaymentList.IsDirty;
				isAccessed = item.OrderCouponList.IsDirty;
				isAccessed = item.OrderFeeList.IsDirty;
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
		/// <summary>This web service method inserts or updates Order data.</summary>
		///
		/// <param name="item">The Order to be managed.</param>
		/// <param name="performCascadeOperation">Flag, indicating if a cascade operation should be performed on the Order item.</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Orders.OrderResults UpsertOneOrder(BLL.Orders.Order item, bool performCascadeOperation)
		{
			Components.Orders.OrderResults results = new Components.Orders.OrderResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Orders.OrderManager.UpsertOneOrder(item, performCascadeOperation);
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
		public OrderManager()
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