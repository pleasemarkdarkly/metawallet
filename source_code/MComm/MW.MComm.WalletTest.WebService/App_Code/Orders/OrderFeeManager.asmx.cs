
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
using MW.MComm.WalletTest.WebService.Orders;
using BLL = MW.MComm.WalletSolution.BLL;
using MW.MComm.WalletSolution.BLL.Orders;
using MOD.Data;
using Utility = MW.MComm.WalletSolution.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
namespace MW.MComm.WalletTest.WebService.Orders
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage OrderFee related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public class OrderFeeManager : System.Web.Services.WebService
	{
		#region "Service Methods"
		// ------------------------------------------------------------------
		/// <summary>This web service method inserts OrderFee data.</summary>
		///
		/// <param name="orderID">A property of OrderFee item to be managed</param>
		/// <param name="feeCode">A property of OrderFee item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Orders.OrderFeeResults AddOneOrderFee(string orderID, int feeCode)
		{
			Components.Orders.OrderFeeResults results = new Components.Orders.OrderFeeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Orders.OrderFee item = new BLL.Orders.OrderFee();
				item.OrderID = MOD.Data.DataHelper.GetGuid(orderID, MOD.Data.DefaultValue.Guid);
				item.FeeCode = feeCode;
				BLL.Orders.OrderFeeManager.AddOneOrderFee(item, false);
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
		/// <summary>This web service method deletes all OrderFee data by a key.</summary>
		///
		/// <param name="feeCode">A key for OrderFee items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Orders.OrderFeeResults DeleteAllOrderFeeDataByFeeCode(int feeCode)
		{
			Components.Orders.OrderFeeResults results = new Components.Orders.OrderFeeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Orders.OrderFeeManager.DeleteAllOrderFeeDataByFeeCode(feeCode);
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
		/// <summary>This web service method deletes all OrderFee data by a key.</summary>
		///
		/// <param name="orderID">A key for OrderFee items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Orders.OrderFeeResults DeleteAllOrderFeeDataByOrderID(string orderID)
		{
			Components.Orders.OrderFeeResults results = new Components.Orders.OrderFeeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Orders.OrderFeeManager.DeleteAllOrderFeeDataByOrderID(MOD.Data.DataHelper.GetGuid(orderID, MOD.Data.DefaultValue.Guid));
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
		/// <summary>This web service method deletes OrderFee data.</summary>
		///
		/// <param name="orderID">A property of OrderFee item to be managed</param>
		/// <param name="feeCode">A property of OrderFee item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Orders.OrderFeeResults DeleteOneOrderFee(string orderID, int feeCode)
		{
			Components.Orders.OrderFeeResults results = new Components.Orders.OrderFeeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Orders.OrderFee item = new BLL.Orders.OrderFee();
				item.OrderID = MOD.Data.DataHelper.GetGuid(orderID, MOD.Data.DefaultValue.Guid);
				item.FeeCode = feeCode;
				BLL.Orders.OrderFeeManager.DeleteOneOrderFee(item, false);
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
		/// <summary>This web service method gets all OrderFee data.</summary>
		///
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Orders.OrderFeeResults GetAllOrderFeeData(string sortColumn, string sortDirection)
		{
			Components.Orders.OrderFeeResults results = new Components.Orders.OrderFeeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Orders.OrderFeeManager.GetAllOrderFeeData(Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all OrderFee data by a key.</summary>
		///
		/// <param name="feeCode">A key for OrderFee items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Orders.OrderFeeResults GetAllOrderFeeDataByFeeCode(string feeCode, string sortColumn, string sortDirection)
		{
			Components.Orders.OrderFeeResults results = new Components.Orders.OrderFeeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Orders.OrderFeeManager.GetAllOrderFeeDataByFeeCode(MOD.Data.DataHelper.GetInt(feeCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all OrderFee data by a key.</summary>
		///
		/// <param name="orderID">A key for OrderFee items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Orders.OrderFeeResults GetAllOrderFeeDataByOrderID(string orderID, string sortColumn, string sortDirection)
		{
			Components.Orders.OrderFeeResults results = new Components.Orders.OrderFeeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Orders.OrderFeeManager.GetAllOrderFeeDataByOrderID(MOD.Data.DataHelper.GetGuid(orderID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets a single OrderFee by an index.</summary>
		///
		/// <param name="orderID">The index for OrderFee to be fetched</param>
		/// <param name="feeCode">The index for OrderFee to be fetched</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Orders.OrderFeeResults GetOneOrderFee(string orderID, int feeCode, string sortColumn, string sortDirection)
		{
			Components.Orders.OrderFeeResults results = new Components.Orders.OrderFeeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Orders.OrderFee item =  BLL.Orders.OrderFeeManager.GetOneOrderFee(MOD.Data.DataHelper.GetGuid(orderID, MOD.Data.DefaultValue.Guid), MOD.Data.DataHelper.GetInt(feeCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
				// populate desired collections with lazy loading
				bool isAccessed = true;
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
		/// <summary>This web service method updates OrderFee data.</summary>
		///
		/// <param name="orderID">A property of OrderFee item to be managed</param>
		/// <param name="feeCode">A property of OrderFee item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Orders.OrderFeeResults UpdateOneOrderFee(string orderID, int feeCode)
		{
			Components.Orders.OrderFeeResults results = new Components.Orders.OrderFeeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Orders.OrderFee item = new BLL.Orders.OrderFee();
				item.OrderID = MOD.Data.DataHelper.GetGuid(orderID, MOD.Data.DefaultValue.Guid);
				item.FeeCode = feeCode;
				BLL.Orders.OrderFeeManager.UpdateOneOrderFee(item, false);
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
		public OrderFeeManager()
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