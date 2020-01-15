
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
using MW.MComm.WalletSolution.WebService.Customers;
using BLL = MW.MComm.WalletSolution.BLL;
using MW.MComm.WalletSolution.BLL.Customers;
using MOD.Data;
using Utility = MW.MComm.WalletSolution.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
namespace MW.MComm.WalletSolution.WebService.Customers
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage BusinessCustomer related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public class BusinessCustomerManager : System.Web.Services.WebService
	{
		#region "Service Methods"
		// ------------------------------------------------------------------
		/// <summary>This web service method inserts BusinessCustomer data.</summary>
		///
		/// <param name="item">The BusinessCustomer to be managed.</param>
		/// <param name="performCascadeOperation">Flag, indicating if a cascade operation should be performed on the BusinessCustomer item.</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.BusinessCustomerResults AddOneBusinessCustomer(BLL.Customers.BusinessCustomer item, bool performCascadeOperation)
		{
			Components.Customers.BusinessCustomerResults results = new Components.Customers.BusinessCustomerResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Customers.BusinessCustomerManager.AddOneBusinessCustomer(item, performCascadeOperation);
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
		/// <summary>This web service method deletes all BusinessCustomer data by a key.</summary>
		///
		/// <param name="businessMetaPartnerID">A key for BusinessCustomer items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.BusinessCustomerResults DeleteAllBusinessCustomerDataByBusinessMetaPartnerID(string businessMetaPartnerID)
		{
			Components.Customers.BusinessCustomerResults results = new Components.Customers.BusinessCustomerResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Customers.BusinessCustomerManager.DeleteAllBusinessCustomerDataByBusinessMetaPartnerID(MOD.Data.DataHelper.GetGuid(businessMetaPartnerID, MOD.Data.DefaultValue.Guid));
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
		/// <summary>This web service method deletes all BusinessCustomer data by a key.</summary>
		///
		/// <param name="customerMetaPartnerID">A key for BusinessCustomer items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.BusinessCustomerResults DeleteAllBusinessCustomerDataByCustomerMetaPartnerID(string customerMetaPartnerID)
		{
			Components.Customers.BusinessCustomerResults results = new Components.Customers.BusinessCustomerResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Customers.BusinessCustomerManager.DeleteAllBusinessCustomerDataByCustomerMetaPartnerID(MOD.Data.DataHelper.GetGuid(customerMetaPartnerID, MOD.Data.DefaultValue.Guid));
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
		/// <summary>This web service method deletes BusinessCustomer data.</summary>
		///
		/// <param name="item">The BusinessCustomer to be deleted.</param>
		/// <param name="performCascadeOperation">Flag, indicating if a cascade delete should be performed on the BusinessCustomer item.</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.BusinessCustomerResults DeleteOneBusinessCustomer(BLL.Customers.BusinessCustomer item, bool performCascadeOperation)
		{
			Components.Customers.BusinessCustomerResults results = new Components.Customers.BusinessCustomerResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Customers.BusinessCustomerManager.DeleteOneBusinessCustomer(item, performCascadeOperation);
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
		/// <summary>This web service method gets all BusinessCustomer data.</summary>
		///
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.BusinessCustomerResults GetAllBusinessCustomerData(string sortColumn, string sortDirection)
		{
			Components.Customers.BusinessCustomerResults results = new Components.Customers.BusinessCustomerResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Customers.BusinessCustomerManager.GetAllBusinessCustomerData(Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all BusinessCustomer data by a key.</summary>
		///
		/// <param name="businessMetaPartnerID">A key for BusinessCustomer items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.BusinessCustomerResults GetAllBusinessCustomerDataByBusinessMetaPartnerID(string businessMetaPartnerID, string sortColumn, string sortDirection)
		{
			Components.Customers.BusinessCustomerResults results = new Components.Customers.BusinessCustomerResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Customers.BusinessCustomerManager.GetAllBusinessCustomerDataByBusinessMetaPartnerID(MOD.Data.DataHelper.GetGuid(businessMetaPartnerID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all BusinessCustomer data by a key.</summary>
		///
		/// <param name="customerMetaPartnerID">A key for BusinessCustomer items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.BusinessCustomerResults GetAllBusinessCustomerDataByCustomerMetaPartnerID(string customerMetaPartnerID, string sortColumn, string sortDirection)
		{
			Components.Customers.BusinessCustomerResults results = new Components.Customers.BusinessCustomerResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Customers.BusinessCustomerManager.GetAllBusinessCustomerDataByCustomerMetaPartnerID(MOD.Data.DataHelper.GetGuid(customerMetaPartnerID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets a single BusinessCustomer by an index.</summary>
		///
		/// <param name="businessMetaPartnerID">The index for BusinessCustomer to be fetched</param>
		/// <param name="customerMetaPartnerID">The index for BusinessCustomer to be fetched</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.BusinessCustomerResults GetOneBusinessCustomer(string businessMetaPartnerID, string customerMetaPartnerID, string sortColumn, string sortDirection)
		{
			Components.Customers.BusinessCustomerResults results = new Components.Customers.BusinessCustomerResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Customers.BusinessCustomer item =  BLL.Customers.BusinessCustomerManager.GetOneBusinessCustomer(MOD.Data.DataHelper.GetGuid(businessMetaPartnerID, MOD.Data.DefaultValue.Guid), MOD.Data.DataHelper.GetGuid(customerMetaPartnerID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method updates BusinessCustomer data.</summary>
		///
		/// <param name="item">The BusinessCustomer to be managed.</param>
		/// <param name="performCascadeOperation">Flag, indicating if a cascade operation should be performed on the BusinessCustomer item.</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.BusinessCustomerResults UpdateOneBusinessCustomer(BLL.Customers.BusinessCustomer item, bool performCascadeOperation)
		{
			Components.Customers.BusinessCustomerResults results = new Components.Customers.BusinessCustomerResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Customers.BusinessCustomerManager.UpdateOneBusinessCustomer(item, performCascadeOperation);
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
		public BusinessCustomerManager()
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