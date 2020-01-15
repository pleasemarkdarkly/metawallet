
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
using MW.MComm.WalletTest.WebService.Customers;
using BLL = MW.MComm.WalletSolution.BLL;
using MW.MComm.WalletSolution.BLL.Customers;
using MOD.Data;
using Utility = MW.MComm.WalletSolution.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
namespace MW.MComm.WalletTest.WebService.Customers
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage LocationType related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public class LocationTypeManager : System.Web.Services.WebService
	{
		#region "Service Methods"
		// ------------------------------------------------------------------
		/// <summary>This web service method inserts LocationType data.</summary>
		///
		/// <param name="locationTypeCode">A property of LocationType item to be managed</param>
		/// <param name="locationTypeName">A property of LocationType item to be managed</param>
		/// <param name="description">A property of LocationType item to be managed</param>
		/// <param name="isActive">A property of LocationType item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.LocationTypeResults AddOneLocationType(int locationTypeCode, string locationTypeName, string description, bool isActive)
		{
			Components.Customers.LocationTypeResults results = new Components.Customers.LocationTypeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Customers.LocationType item = new BLL.Customers.LocationType();
				item.LocationTypeCode = locationTypeCode;
				item.LocationTypeName = locationTypeName;
				item.Description = description;
				item.IsActive = isActive;
				BLL.Customers.LocationTypeManager.AddOneLocationType(item, false);
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
		/// <summary>This web service method deletes LocationType data.</summary>
		///
		/// <param name="locationTypeCode">A property of LocationType item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.LocationTypeResults DeleteOneLocationType(int locationTypeCode)
		{
			Components.Customers.LocationTypeResults results = new Components.Customers.LocationTypeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Customers.LocationType item = new BLL.Customers.LocationType();
				item.LocationTypeCode = locationTypeCode;
				BLL.Customers.LocationTypeManager.DeleteOneLocationType(item, false);
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
		/// <summary>This web service method gets all LocationType data.</summary>
		///
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.LocationTypeResults GetAllLocationTypeData(string sortColumn, string sortDirection)
		{
			Components.Customers.LocationTypeResults results = new Components.Customers.LocationTypeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Customers.LocationTypeManager.GetAllLocationTypeData(Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets a single LocationType by an index.</summary>
		///
		/// <param name="locationTypeCode">The index for LocationType to be fetched</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.LocationTypeResults GetOneLocationType(int locationTypeCode, string sortColumn, string sortDirection)
		{
			Components.Customers.LocationTypeResults results = new Components.Customers.LocationTypeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Customers.LocationType item =  BLL.Customers.LocationTypeManager.GetOneLocationType(MOD.Data.DataHelper.GetInt(locationTypeCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method updates LocationType data.</summary>
		///
		/// <param name="locationTypeCode">A property of LocationType item to be managed</param>
		/// <param name="locationTypeName">A property of LocationType item to be managed</param>
		/// <param name="description">A property of LocationType item to be managed</param>
		/// <param name="isActive">A property of LocationType item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.LocationTypeResults UpdateOneLocationType(int locationTypeCode, string locationTypeName, string description, bool isActive)
		{
			Components.Customers.LocationTypeResults results = new Components.Customers.LocationTypeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Customers.LocationType item = new BLL.Customers.LocationType();
				item.LocationTypeCode = locationTypeCode;
				item.LocationTypeName = locationTypeName;
				item.Description = description;
				item.IsActive = isActive;
				BLL.Customers.LocationTypeManager.UpdateOneLocationType(item, false);
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
		public LocationTypeManager()
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