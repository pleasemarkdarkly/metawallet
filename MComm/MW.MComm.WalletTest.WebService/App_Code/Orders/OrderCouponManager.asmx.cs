
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
	/// <summary>This class is used to manage OrderCoupon related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public class OrderCouponManager : System.Web.Services.WebService
	{
		#region "Service Methods"
		// ------------------------------------------------------------------
		/// <summary>This web service method inserts OrderCoupon data.</summary>
		///
		/// <param name="orderID">A property of OrderCoupon item to be managed</param>
		/// <param name="metaPartnerCouponID">A property of OrderCoupon item to be managed</param>
		/// <param name="debitMetaPartnerID">A property of OrderCoupon item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Orders.OrderCouponResults AddOneOrderCoupon(string orderID, string metaPartnerCouponID, string debitMetaPartnerID)
		{
			Components.Orders.OrderCouponResults results = new Components.Orders.OrderCouponResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Orders.OrderCoupon item = new BLL.Orders.OrderCoupon();
				item.OrderID = MOD.Data.DataHelper.GetGuid(orderID, MOD.Data.DefaultValue.Guid);
				item.MetaPartnerCouponID = MOD.Data.DataHelper.GetGuid(metaPartnerCouponID, MOD.Data.DefaultValue.Guid);
				item.DebitMetaPartnerID = MOD.Data.DataHelper.GetGuid(debitMetaPartnerID, MOD.Data.DefaultValue.Guid);
				BLL.Orders.OrderCouponManager.AddOneOrderCoupon(item, false);
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
		/// <summary>This web service method deletes all OrderCoupon data by a key.</summary>
		///
		/// <param name="metaPartnerCouponID">A key for OrderCoupon items to be deleted</param>
		/// <param name="debitMetaPartnerID">A key for OrderCoupon items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Orders.OrderCouponResults DeleteAllOrderCouponDataByMetaPartnerCouponIDAndDebitMetaPartnerID(string metaPartnerCouponID, string debitMetaPartnerID)
		{
			Components.Orders.OrderCouponResults results = new Components.Orders.OrderCouponResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Orders.OrderCouponManager.DeleteAllOrderCouponDataByMetaPartnerCouponIDAndDebitMetaPartnerID(MOD.Data.DataHelper.GetGuid(metaPartnerCouponID, MOD.Data.DefaultValue.Guid), MOD.Data.DataHelper.GetGuid(debitMetaPartnerID, MOD.Data.DefaultValue.Guid));
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
		/// <summary>This web service method deletes all OrderCoupon data by a key.</summary>
		///
		/// <param name="orderID">A key for OrderCoupon items to be deleted</param>
		/// <param name="debitMetaPartnerID">A key for OrderCoupon items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Orders.OrderCouponResults DeleteAllOrderCouponDataByOrderIDAndDebitMetaPartnerID(string orderID, string debitMetaPartnerID)
		{
			Components.Orders.OrderCouponResults results = new Components.Orders.OrderCouponResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Orders.OrderCouponManager.DeleteAllOrderCouponDataByOrderIDAndDebitMetaPartnerID(MOD.Data.DataHelper.GetGuid(orderID, MOD.Data.DefaultValue.Guid), MOD.Data.DataHelper.GetGuid(debitMetaPartnerID, MOD.Data.DefaultValue.Guid));
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
		/// <summary>This web service method deletes OrderCoupon data.</summary>
		///
		/// <param name="orderID">A property of OrderCoupon item to be managed</param>
		/// <param name="metaPartnerCouponID">A property of OrderCoupon item to be managed</param>
		/// <param name="debitMetaPartnerID">A property of OrderCoupon item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Orders.OrderCouponResults DeleteOneOrderCoupon(string orderID, string metaPartnerCouponID, string debitMetaPartnerID)
		{
			Components.Orders.OrderCouponResults results = new Components.Orders.OrderCouponResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Orders.OrderCoupon item = new BLL.Orders.OrderCoupon();
				item.OrderID = MOD.Data.DataHelper.GetGuid(orderID, MOD.Data.DefaultValue.Guid);
				item.MetaPartnerCouponID = MOD.Data.DataHelper.GetGuid(metaPartnerCouponID, MOD.Data.DefaultValue.Guid);
				item.DebitMetaPartnerID = MOD.Data.DataHelper.GetGuid(debitMetaPartnerID, MOD.Data.DefaultValue.Guid);
				BLL.Orders.OrderCouponManager.DeleteOneOrderCoupon(item, false);
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
		/// <summary>This web service method gets all OrderCoupon data.</summary>
		///
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Orders.OrderCouponResults GetAllOrderCouponData(string sortColumn, string sortDirection)
		{
			Components.Orders.OrderCouponResults results = new Components.Orders.OrderCouponResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Orders.OrderCouponManager.GetAllOrderCouponData(Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all OrderCoupon data by a key.</summary>
		///
		/// <param name="metaPartnerCouponID">A key for OrderCoupon items to be fetched</param>
		/// <param name="debitMetaPartnerID">A key for OrderCoupon items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Orders.OrderCouponResults GetAllOrderCouponDataByMetaPartnerCouponIDAndDebitMetaPartnerID(string metaPartnerCouponID, string debitMetaPartnerID, string sortColumn, string sortDirection)
		{
			Components.Orders.OrderCouponResults results = new Components.Orders.OrderCouponResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Orders.OrderCouponManager.GetAllOrderCouponDataByMetaPartnerCouponIDAndDebitMetaPartnerID(MOD.Data.DataHelper.GetGuid(metaPartnerCouponID, MOD.Data.DefaultValue.Guid), MOD.Data.DataHelper.GetGuid(debitMetaPartnerID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all OrderCoupon data by a key.</summary>
		///
		/// <param name="orderID">A key for OrderCoupon items to be fetched</param>
		/// <param name="debitMetaPartnerID">A key for OrderCoupon items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Orders.OrderCouponResults GetAllOrderCouponDataByOrderIDAndDebitMetaPartnerID(string orderID, string debitMetaPartnerID, string sortColumn, string sortDirection)
		{
			Components.Orders.OrderCouponResults results = new Components.Orders.OrderCouponResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Orders.OrderCouponManager.GetAllOrderCouponDataByOrderIDAndDebitMetaPartnerID(MOD.Data.DataHelper.GetGuid(orderID, MOD.Data.DefaultValue.Guid), MOD.Data.DataHelper.GetGuid(debitMetaPartnerID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets a single OrderCoupon by an index.</summary>
		///
		/// <param name="orderID">The index for OrderCoupon to be fetched</param>
		/// <param name="metaPartnerCouponID">The index for OrderCoupon to be fetched</param>
		/// <param name="debitMetaPartnerID">The index for OrderCoupon to be fetched</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Orders.OrderCouponResults GetOneOrderCoupon(string orderID, string metaPartnerCouponID, string debitMetaPartnerID, string sortColumn, string sortDirection)
		{
			Components.Orders.OrderCouponResults results = new Components.Orders.OrderCouponResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Orders.OrderCoupon item =  BLL.Orders.OrderCouponManager.GetOneOrderCoupon(MOD.Data.DataHelper.GetGuid(orderID, MOD.Data.DefaultValue.Guid), MOD.Data.DataHelper.GetGuid(metaPartnerCouponID, MOD.Data.DefaultValue.Guid), MOD.Data.DataHelper.GetGuid(debitMetaPartnerID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method updates OrderCoupon data.</summary>
		///
		/// <param name="orderID">A property of OrderCoupon item to be managed</param>
		/// <param name="metaPartnerCouponID">A property of OrderCoupon item to be managed</param>
		/// <param name="debitMetaPartnerID">A property of OrderCoupon item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Orders.OrderCouponResults UpdateOneOrderCoupon(string orderID, string metaPartnerCouponID, string debitMetaPartnerID)
		{
			Components.Orders.OrderCouponResults results = new Components.Orders.OrderCouponResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Orders.OrderCoupon item = new BLL.Orders.OrderCoupon();
				item.OrderID = MOD.Data.DataHelper.GetGuid(orderID, MOD.Data.DefaultValue.Guid);
				item.MetaPartnerCouponID = MOD.Data.DataHelper.GetGuid(metaPartnerCouponID, MOD.Data.DefaultValue.Guid);
				item.DebitMetaPartnerID = MOD.Data.DataHelper.GetGuid(debitMetaPartnerID, MOD.Data.DefaultValue.Guid);
				BLL.Orders.OrderCouponManager.UpdateOneOrderCoupon(item, false);
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
		public OrderCouponManager()
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