
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
using MW.MComm.WalletTest.WebService.Events;
using BLL = MW.MComm.WalletSolution.BLL;
using MW.MComm.WalletSolution.BLL.Events;
using MOD.Data;
using Utility = MW.MComm.WalletSolution.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
namespace MW.MComm.WalletTest.WebService.Events
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage SpecificEventAttribute related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public class SpecificEventAttributeManager : System.Web.Services.WebService
	{
		#region "Service Methods"
		// ------------------------------------------------------------------
		/// <summary>This web service method inserts SpecificEventAttribute data.</summary>
		///
		/// <param name="eventCode">A property of SpecificEventAttribute item to be managed</param>
		/// <param name="baseAttributeID">A property of SpecificEventAttribute item to be managed</param>
		/// <param name="rank">A property of SpecificEventAttribute item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Events.SpecificEventAttributeResults AddOneSpecificEventAttribute(int eventCode, string baseAttributeID, int rank)
		{
			Components.Events.SpecificEventAttributeResults results = new Components.Events.SpecificEventAttributeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Events.SpecificEventAttribute item = new BLL.Events.SpecificEventAttribute();
				item.EventCode = eventCode;
				item.BaseAttributeID = MOD.Data.DataHelper.GetGuid(baseAttributeID, MOD.Data.DefaultValue.Guid);
				item.Rank = rank;
				BLL.Events.SpecificEventAttributeManager.AddOneSpecificEventAttribute(item, false);
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
		/// <summary>This web service method deletes all SpecificEventAttribute data by a key.</summary>
		///
		/// <param name="baseAttributeID">A key for SpecificEventAttribute items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Events.SpecificEventAttributeResults DeleteAllSpecificEventAttributeDataByBaseAttributeID(string baseAttributeID)
		{
			Components.Events.SpecificEventAttributeResults results = new Components.Events.SpecificEventAttributeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Events.SpecificEventAttributeManager.DeleteAllSpecificEventAttributeDataByBaseAttributeID(MOD.Data.DataHelper.GetGuid(baseAttributeID, MOD.Data.DefaultValue.Guid));
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
		/// <summary>This web service method deletes all SpecificEventAttribute data by a key.</summary>
		///
		/// <param name="eventCode">A key for SpecificEventAttribute items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Events.SpecificEventAttributeResults DeleteAllSpecificEventAttributeDataByEventCode(int eventCode)
		{
			Components.Events.SpecificEventAttributeResults results = new Components.Events.SpecificEventAttributeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Events.SpecificEventAttributeManager.DeleteAllSpecificEventAttributeDataByEventCode(eventCode);
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
		/// <summary>This web service method deletes SpecificEventAttribute data.</summary>
		///
		/// <param name="eventCode">A property of SpecificEventAttribute item to be managed</param>
		/// <param name="baseAttributeID">A property of SpecificEventAttribute item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Events.SpecificEventAttributeResults DeleteOneSpecificEventAttribute(int eventCode, string baseAttributeID)
		{
			Components.Events.SpecificEventAttributeResults results = new Components.Events.SpecificEventAttributeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Events.SpecificEventAttribute item = new BLL.Events.SpecificEventAttribute();
				item.EventCode = eventCode;
				item.BaseAttributeID = MOD.Data.DataHelper.GetGuid(baseAttributeID, MOD.Data.DefaultValue.Guid);
				BLL.Events.SpecificEventAttributeManager.DeleteOneSpecificEventAttribute(item, false);
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
		/// <summary>This web service method gets all SpecificEventAttribute data.</summary>
		///
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Events.SpecificEventAttributeResults GetAllSpecificEventAttributeData(string sortColumn, string sortDirection)
		{
			Components.Events.SpecificEventAttributeResults results = new Components.Events.SpecificEventAttributeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Events.SpecificEventAttributeManager.GetAllSpecificEventAttributeData(Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all SpecificEventAttribute data by a key.</summary>
		///
		/// <param name="baseAttributeID">A key for SpecificEventAttribute items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Events.SpecificEventAttributeResults GetAllSpecificEventAttributeDataByBaseAttributeID(string baseAttributeID, string sortColumn, string sortDirection)
		{
			Components.Events.SpecificEventAttributeResults results = new Components.Events.SpecificEventAttributeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Events.SpecificEventAttributeManager.GetAllSpecificEventAttributeDataByBaseAttributeID(MOD.Data.DataHelper.GetGuid(baseAttributeID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all SpecificEventAttribute data by a key.</summary>
		///
		/// <param name="eventCode">A key for SpecificEventAttribute items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Events.SpecificEventAttributeResults GetAllSpecificEventAttributeDataByEventCode(string eventCode, string sortColumn, string sortDirection)
		{
			Components.Events.SpecificEventAttributeResults results = new Components.Events.SpecificEventAttributeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Events.SpecificEventAttributeManager.GetAllSpecificEventAttributeDataByEventCode(MOD.Data.DataHelper.GetInt(eventCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets a single SpecificEventAttribute by an index.</summary>
		///
		/// <param name="eventCode">The index for SpecificEventAttribute to be fetched</param>
		/// <param name="baseAttributeID">The index for SpecificEventAttribute to be fetched</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Events.SpecificEventAttributeResults GetOneSpecificEventAttribute(int eventCode, string baseAttributeID, string sortColumn, string sortDirection)
		{
			Components.Events.SpecificEventAttributeResults results = new Components.Events.SpecificEventAttributeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Events.SpecificEventAttribute item =  BLL.Events.SpecificEventAttributeManager.GetOneSpecificEventAttribute(MOD.Data.DataHelper.GetInt(eventCode, MOD.Data.DefaultValue.Int), MOD.Data.DataHelper.GetGuid(baseAttributeID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method updates SpecificEventAttribute data.</summary>
		///
		/// <param name="eventCode">A property of SpecificEventAttribute item to be managed</param>
		/// <param name="baseAttributeID">A property of SpecificEventAttribute item to be managed</param>
		/// <param name="rank">A property of SpecificEventAttribute item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Events.SpecificEventAttributeResults UpdateOneSpecificEventAttribute(int eventCode, string baseAttributeID, int rank)
		{
			Components.Events.SpecificEventAttributeResults results = new Components.Events.SpecificEventAttributeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Events.SpecificEventAttribute item = new BLL.Events.SpecificEventAttribute();
				item.EventCode = eventCode;
				item.BaseAttributeID = MOD.Data.DataHelper.GetGuid(baseAttributeID, MOD.Data.DefaultValue.Guid);
				item.Rank = rank;
				BLL.Events.SpecificEventAttributeManager.UpdateOneSpecificEventAttribute(item, false);
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
		public SpecificEventAttributeManager()
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