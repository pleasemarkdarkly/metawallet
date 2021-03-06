

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
using MW.MComm.SMS.WebService.Messages;
using BLL = MW.MComm.SMS.BLL;
using MW.MComm.SMS.BLL.Messages;
using MOD.Data;
using Utility = MW.MComm.SMS.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace MW.MComm.SMS.WebService.Messages
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage IncomingSMS related information.</summary>
	///
	/// File History:
	/// <created>10/24/2006 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public class IncomingSMSManager : System.Web.Services.WebService
	{

		#region "Service Methods"

		// ------------------------------------------------------------------
		/// <summary>This web service method deletes IncomingSMS data.</summary>
		///
		/// <param name="item">The IncomingSMS to be deleted.</param>
		/// <param name="performCascadeOperation">Flag, indicating if a cascade delete should be performed on the IncomingSMS item.</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Messages.IncomingSMSResults DeleteOneIncomingSMS(BLL.Messages.IncomingSMS item, bool performCascadeOperation)
		{
			Components.Messages.IncomingSMSResults results = new Components.Messages.IncomingSMSResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Messages.IncomingSMSManager.DeleteOneIncomingSMS(item, performCascadeOperation);
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
		/// <summary>This web service method gets all IncomingSMS data.</summary>
		///
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Messages.IncomingSMSResults GetAllIncomingSMSData(string sortColumn, string sortDirection)
		{
			Components.Messages.IncomingSMSResults results = new Components.Messages.IncomingSMSResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Messages.IncomingSMSManager.GetAllIncomingSMSData(Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all IncomingSMS data by criteria.</summary>
		///
		/// <param name="lastModifiedDateStart">A key for IncomingSMS items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for IncomingSMS items to be fetched</param>
		/// <param name="isProcessed">A key for IncomingSMS items to be fetched</param>
		/// <param name="receiver">A key for IncomingSMS items to be fetched</param>
		/// <param name="sender">A key for IncomingSMS items to be fetched</param>
		/// <param name="sMSContent">A key for IncomingSMS items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Messages.IncomingSMSResults GetAllIncomingSMSDataByCriteria(string lastModifiedDateStart, string lastModifiedDateEnd, string isProcessed, string receiver, string sender, string sMSContent, string sortColumn, string sortDirection)
		{
			Components.Messages.IncomingSMSResults results = new Components.Messages.IncomingSMSResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Messages.IncomingSMSManager.GetAllIncomingSMSDataByCriteria(MOD.Data.SearchHelper.GetDateTime(lastModifiedDateStart), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateEnd), MOD.Data.SearchHelper.GetBool(isProcessed), MOD.Data.SearchHelper.GetString(receiver), MOD.Data.SearchHelper.GetString(sender), MOD.Data.SearchHelper.GetString(sMSContent), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all IncomingSMS data by criteria.</summary>
		///
		/// <param name="lastModifiedDateStart">A key for IncomingSMS items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for IncomingSMS items to be fetched</param>
		/// <param name="isProcessed">A key for IncomingSMS items to be fetched</param>
		/// <param name="receiver">A key for IncomingSMS items to be fetched</param>
		/// <param name="sender">A key for IncomingSMS items to be fetched</param>
		/// <param name="sMSContent">A key for IncomingSMS items to be fetched</param>
         /// <param name="startIndex">Start Index (beginning at 1)</param>
         /// <param name="pageSize">Page Size</param>
         /// <param name="maximumListSize">Maximum List Size</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Messages.IncomingSMSResults GetManyIncomingSMSDataByCriteria(string lastModifiedDateStart, string lastModifiedDateEnd, string isProcessed, string receiver, string sender, string sMSContent, int startIndex, int pageSize, int maximumListSize, string sortColumn, string sortDirection)
		{
			Components.Messages.IncomingSMSResults results = new Components.Messages.IncomingSMSResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				int totalRecords = 0;
				bool maximumListSizeExceeded = false;
				results.Results = BLL.Messages.IncomingSMSManager.GetManyIncomingSMSDataByCriteria(MOD.Data.SearchHelper.GetDateTime(lastModifiedDateStart), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateEnd), MOD.Data.SearchHelper.GetBool(isProcessed), MOD.Data.SearchHelper.GetString(receiver), MOD.Data.SearchHelper.GetString(sender), MOD.Data.SearchHelper.GetString(sMSContent), out totalRecords, out maximumListSizeExceeded, Globals.getDataOptions(sortColumn, sortDirection, startIndex, pageSize, maximumListSize));
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
		/// <summary>This web service method gets a single IncomingSMS by an index.</summary>
		///
		/// <param name="internalID">The index for IncomingSMS to be fetched</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Messages.IncomingSMSResults GetOneIncomingSMS(long internalID, string sortColumn, string sortDirection)
		{
			Components.Messages.IncomingSMSResults results = new Components.Messages.IncomingSMSResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Messages.IncomingSMS item =  BLL.Messages.IncomingSMSManager.GetOneIncomingSMS(MOD.Data.DataHelper.GetLong(internalID, MOD.Data.DefaultValue.Long), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method inserts or updates IncomingSMS data.</summary>
		///
		/// <param name="item">The IncomingSMS to be managed.</param>
		/// <param name="performCascadeOperation">Flag, indicating if a cascade operation should be performed on the IncomingSMS item.</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Messages.IncomingSMSResults UpsertOneIncomingSMS(BLL.Messages.IncomingSMS item, bool performCascadeOperation)
		{
			Components.Messages.IncomingSMSResults results = new Components.Messages.IncomingSMSResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Messages.IncomingSMSManager.UpsertOneIncomingSMS(item, performCascadeOperation);
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
		public IncomingSMSManager()
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