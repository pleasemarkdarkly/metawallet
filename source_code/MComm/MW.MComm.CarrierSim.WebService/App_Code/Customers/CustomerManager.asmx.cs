

/*<copyright>
Meta Wallet, Inc (c) 2007 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2007, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
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
using MW.MComm.CarrierSim.WebService;
using MW.MComm.CarrierSim.WebService.Customers;
using BLL = MW.MComm.CarrierSim.BLL;
using MW.MComm.CarrierSim.BLL.Customers;
using MOD.Data;
using Utility = MW.MComm.CarrierSim.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace MW.MComm.CarrierSim.WebService.Customers
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage Customer related information.</summary>
	///
	/// File History:
	/// <created>6/27/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[WebService(Namespace = "http://modsystems.com/MW.MComm.CarrierSim.WebService/Customers/CustomerManager")]
	[XmlType(Namespace = "http://modsystems.com/MW.MComm.CarrierSim.WebService/Customers")]
	public class CustomerManager : System.Web.Services.WebService
	{

		#region "Service Methods"

		// ------------------------------------------------------------------
		/// <summary>This web service method inserts or updates Customer data.</summary>
		///
		/// <param name="item">The Customer to be managed.</param>
		/// <param name="performCascadeOperation">Flag, indicating if a cascade operation should be performed on the Customer item.</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.CustomerResults UpsertOneCustomer(BLL.Customers.Customer item, bool performCascadeOperation)
		{
			Components.Customers.CustomerResults results = new Components.Customers.CustomerResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Customers.CustomerManager.UpsertOneCustomer(item, performCascadeOperation);
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
		/// <summary>This web service method deletes Customer data.</summary>
		///
		/// <param name="item">The Customer to be deleted.</param>
		/// <param name="performCascadeOperation">Flag, indicating if a cascade delete should be performed on the Customer item.</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.CustomerResults DeleteOneCustomer(BLL.Customers.Customer item, bool performCascadeOperation)
		{
			Components.Customers.CustomerResults results = new Components.Customers.CustomerResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Customers.CustomerManager.DeleteOneCustomer(item, performCascadeOperation);
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
		/// <summary>This web service method gets a single Customer by an index.</summary>
		///
		/// <param name="customerID">The index for Customer to be fetched</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.CustomerResults GetOneCustomer(string customerID, string sortColumn, string sortDirection)
		{
			Components.Customers.CustomerResults results = new Components.Customers.CustomerResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Customers.Customer item =  BLL.Customers.CustomerManager.GetOneCustomer(MOD.Data.DataHelper.GetGuid(customerID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
				// populate desired collections with lazy loading
				bool isAccessed = true;
				item.IsSerializing = false;
				isAccessed = item.PhoneList.IsDirty;
				item.IsSerializing = true;
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
		/// <summary>This web service method gets all Customer data.</summary>
		///
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.CustomerResults GetAllCustomerData(string sortColumn, string sortDirection)
		{
			Components.Customers.CustomerResults results = new Components.Customers.CustomerResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Customers.CustomerManager.GetAllCustomerData(Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Customer data by criteria.</summary>
		///
		/// <param name="lastModifiedDateStart">A key for Customer items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Customer items to be fetched</param>
		/// <param name="storedValueBalance">A key for Customer items to be fetched</param>
		/// <param name="name">A key for Customer items to be fetched</param>
		/// <param name="storedValueLockedBalance">A key for Customer items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.CustomerResults GetAllCustomerDataByCriteria(string lastModifiedDateStart, string lastModifiedDateEnd, string storedValueBalance, string name, string storedValueLockedBalance, string sortColumn, string sortDirection)
		{
			Components.Customers.CustomerResults results = new Components.Customers.CustomerResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Customers.CustomerManager.GetAllCustomerDataByCriteria(MOD.Data.SearchHelper.GetDateTime(lastModifiedDateStart), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateEnd), MOD.Data.SearchHelper.GetFloat(storedValueBalance), MOD.Data.SearchHelper.GetString(name), MOD.Data.SearchHelper.GetFloat(storedValueLockedBalance), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Customer data by criteria.</summary>
		///
		/// <param name="lastModifiedDateStart">A key for Customer items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Customer items to be fetched</param>
		/// <param name="storedValueBalance">A key for Customer items to be fetched</param>
		/// <param name="name">A key for Customer items to be fetched</param>
		/// <param name="storedValueLockedBalance">A key for Customer items to be fetched</param>
         /// <param name="startIndex">Start Index (beginning at 1)</param>
         /// <param name="pageSize">Page Size</param>
         /// <param name="maximumListSize">Maximum List Size</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.CustomerResults GetManyCustomerDataByCriteria(string lastModifiedDateStart, string lastModifiedDateEnd, string storedValueBalance, string name, string storedValueLockedBalance, int startIndex, int pageSize, int maximumListSize, string sortColumn, string sortDirection)
		{
			Components.Customers.CustomerResults results = new Components.Customers.CustomerResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				int totalRecords = 0;
				bool maximumListSizeExceeded = false;
				results.Results = BLL.Customers.CustomerManager.GetManyCustomerDataByCriteria(MOD.Data.SearchHelper.GetDateTime(lastModifiedDateStart), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateEnd), MOD.Data.SearchHelper.GetFloat(storedValueBalance), MOD.Data.SearchHelper.GetString(name), MOD.Data.SearchHelper.GetFloat(storedValueLockedBalance), out totalRecords, out maximumListSizeExceeded, Globals.getDataOptions(sortColumn, sortDirection, startIndex, pageSize, maximumListSize));
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
		#endregion "Service Methods"

		#region "Miscellaneous"
		// ------------------------------------------------------------------------------
		/// <summary>This web service method is the constructor.</summary>
		// ------------------------------------------------------------------------------
		public CustomerManager()
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