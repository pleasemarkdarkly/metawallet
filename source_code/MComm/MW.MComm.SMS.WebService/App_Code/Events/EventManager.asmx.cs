

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
using MW.MComm.SMS.WebService;
using MW.MComm.SMS.WebService.Events;
using BLL = MW.MComm.SMS.BLL;
using MW.MComm.SMS.BLL.Events;
using MOD.Data;
using Utility = MW.MComm.SMS.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace MW.MComm.SMS.WebService.Events
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage Event related information.</summary>
	///
	/// File History:
	/// <created>10/24/2006 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public class EventManager : System.Web.Services.WebService
	{

		#region "Service Methods"

		// ------------------------------------------------------------------
		/// <summary>This web service method inserts Event data.</summary>
		///
		/// <param name="item">The Event to be managed.</param>
		/// <param name="performCascadeOperation">Flag, indicating if a cascade operation should be performed on the Event item.</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Events.EventResults AddOneEvent(BLL.Events.Event item, bool performCascadeOperation)
		{
			Components.Events.EventResults results = new Components.Events.EventResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Events.EventManager.AddOneEvent(item, performCascadeOperation);
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
		/// <summary>This web service method deletes all Event data by a key.</summary>
		///
		/// <param name="eventTypeCode">A key for Event items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Events.EventResults DeleteAllEventDataByEventTypeCode(int eventTypeCode)
		{
			Components.Events.EventResults results = new Components.Events.EventResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Events.EventManager.DeleteAllEventDataByEventTypeCode(eventTypeCode);
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
		/// <summary>This web service method deletes Event data.</summary>
		///
		/// <param name="item">The Event to be deleted.</param>
		/// <param name="performCascadeOperation">Flag, indicating if a cascade delete should be performed on the Event item.</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Events.EventResults DeleteOneEvent(BLL.Events.Event item, bool performCascadeOperation)
		{
			Components.Events.EventResults results = new Components.Events.EventResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Events.EventManager.DeleteOneEvent(item, performCascadeOperation);
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
		/// <summary>This web service method gets all Event data.</summary>
		///
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Events.EventResults GetAllEventData(string sortColumn, string sortDirection)
		{
			Components.Events.EventResults results = new Components.Events.EventResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Events.EventManager.GetAllEventData(Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Event data by criteria.</summary>
		///
		/// <param name="eventName">A key for Event items to be fetched</param>
		/// <param name="eventTypeCode">A key for Event items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Event items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Event items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Events.EventResults GetAllEventDataByCriteria(string eventName, string eventTypeCode, string lastModifiedDateStart, string lastModifiedDateEnd, string sortColumn, string sortDirection)
		{
			Components.Events.EventResults results = new Components.Events.EventResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Events.EventManager.GetAllEventDataByCriteria(MOD.Data.SearchHelper.GetString(eventName), MOD.Data.SearchHelper.GetInt(eventTypeCode), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateStart), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateEnd), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Event data by a key.</summary>
		///
		/// <param name="eventTypeCode">A key for Event items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Events.EventResults GetAllEventDataByEventTypeCode(string eventTypeCode, string sortColumn, string sortDirection)
		{
			Components.Events.EventResults results = new Components.Events.EventResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Events.EventManager.GetAllEventDataByEventTypeCode(MOD.Data.DataHelper.GetInt(eventTypeCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Event data by criteria.</summary>
		///
		/// <param name="eventName">A key for Event items to be fetched</param>
		/// <param name="eventTypeCode">A key for Event items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Event items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Event items to be fetched</param>
         /// <param name="startIndex">Start Index (beginning at 1)</param>
         /// <param name="pageSize">Page Size</param>
         /// <param name="maximumListSize">Maximum List Size</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Events.EventResults GetManyEventDataByCriteria(string eventName, string eventTypeCode, string lastModifiedDateStart, string lastModifiedDateEnd, int startIndex, int pageSize, int maximumListSize, string sortColumn, string sortDirection)
		{
			Components.Events.EventResults results = new Components.Events.EventResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				int totalRecords = 0;
				bool maximumListSizeExceeded = false;
				results.Results = BLL.Events.EventManager.GetManyEventDataByCriteria(MOD.Data.SearchHelper.GetString(eventName), MOD.Data.SearchHelper.GetInt(eventTypeCode), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateStart), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateEnd), out totalRecords, out maximumListSizeExceeded, Globals.getDataOptions(sortColumn, sortDirection, startIndex, pageSize, maximumListSize));
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
		/// <summary>This web service method gets a single Event by an index.</summary>
		///
		/// <param name="eventCode">The index for Event to be fetched</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Events.EventResults GetOneEvent(int eventCode, string sortColumn, string sortDirection)
		{
			Components.Events.EventResults results = new Components.Events.EventResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Events.Event item =  BLL.Events.EventManager.GetOneEvent(MOD.Data.DataHelper.GetInt(eventCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method updates Event data.</summary>
		///
		/// <param name="item">The Event to be managed.</param>
		/// <param name="performCascadeOperation">Flag, indicating if a cascade operation should be performed on the Event item.</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Events.EventResults UpdateOneEvent(BLL.Events.Event item, bool performCascadeOperation)
		{
			Components.Events.EventResults results = new Components.Events.EventResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Events.EventManager.UpdateOneEvent(item, performCascadeOperation);
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
		public EventManager()
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