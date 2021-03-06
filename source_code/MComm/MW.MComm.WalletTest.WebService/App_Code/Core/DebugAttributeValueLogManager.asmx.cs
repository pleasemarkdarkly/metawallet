
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
using MW.MComm.WalletTest.WebService.Core;
using BLL = MW.MComm.WalletSolution.BLL;
using MW.MComm.WalletSolution.BLL.Core;
using MOD.Data;
using Utility = MW.MComm.WalletSolution.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
namespace MW.MComm.WalletTest.WebService.Core
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage DebugAttributeValueLog related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public class DebugAttributeValueLogManager : System.Web.Services.WebService
	{
		#region "Service Methods"
		// ------------------------------------------------------------------
		/// <summary>This web service method gets all DebugAttributeValueLog data.</summary>
		///
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Core.DebugAttributeValueLogResults GetAllDebugAttributeValueLogData(string sortColumn, string sortDirection)
		{
			Components.Core.DebugAttributeValueLogResults results = new Components.Core.DebugAttributeValueLogResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Core.DebugAttributeValueLogManager.GetAllDebugAttributeValueLogData(Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all DebugAttributeValueLog data by a key.</summary>
		///
		/// <param name="baseAttributeID">A key for DebugAttributeValueLog items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Core.DebugAttributeValueLogResults GetAllDebugAttributeValueLogDataByBaseAttributeID(string baseAttributeID, string sortColumn, string sortDirection)
		{
			Components.Core.DebugAttributeValueLogResults results = new Components.Core.DebugAttributeValueLogResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Core.DebugAttributeValueLogManager.GetAllDebugAttributeValueLogDataByBaseAttributeID(MOD.Data.DataHelper.GetGuid(baseAttributeID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all DebugAttributeValueLog data by criteria.</summary>
		///
		/// <param name="attributeValue">A key for DebugAttributeValueLog items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for DebugAttributeValueLog items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for DebugAttributeValueLog items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Core.DebugAttributeValueLogResults GetAllDebugAttributeValueLogDataByCriteria(string attributeValue, string lastModifiedDateStart, string lastModifiedDateEnd, string sortColumn, string sortDirection)
		{
			Components.Core.DebugAttributeValueLogResults results = new Components.Core.DebugAttributeValueLogResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Core.DebugAttributeValueLogManager.GetAllDebugAttributeValueLogDataByCriteria(MOD.Data.SearchHelper.GetString(attributeValue), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateStart), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateEnd), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all DebugAttributeValueLog data by a key.</summary>
		///
		/// <param name="debugLogID">A key for DebugAttributeValueLog items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Core.DebugAttributeValueLogResults GetAllDebugAttributeValueLogDataByDebugLogID(string debugLogID, string sortColumn, string sortDirection)
		{
			Components.Core.DebugAttributeValueLogResults results = new Components.Core.DebugAttributeValueLogResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Core.DebugAttributeValueLogManager.GetAllDebugAttributeValueLogDataByDebugLogID(MOD.Data.DataHelper.GetGuid(debugLogID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all DebugAttributeValueLog data by criteria.</summary>
		///
		/// <param name="attributeValue">A key for DebugAttributeValueLog items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for DebugAttributeValueLog items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for DebugAttributeValueLog items to be fetched</param>
         /// <param name="startIndex">Start Index (beginning at 1)</param>
         /// <param name="pageSize">Page Size</param>
         /// <param name="maximumListSize">Maximum List Size</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Core.DebugAttributeValueLogResults GetManyDebugAttributeValueLogDataByCriteria(string attributeValue, string lastModifiedDateStart, string lastModifiedDateEnd, int startIndex, int pageSize, int maximumListSize, string sortColumn, string sortDirection)
		{
			Components.Core.DebugAttributeValueLogResults results = new Components.Core.DebugAttributeValueLogResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				int totalRecords = 0;
				bool maximumListSizeExceeded = false;
				results.Results = BLL.Core.DebugAttributeValueLogManager.GetManyDebugAttributeValueLogDataByCriteria(MOD.Data.SearchHelper.GetString(attributeValue), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateStart), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateEnd), out totalRecords, out maximumListSizeExceeded, Globals.getDataOptions(sortColumn, sortDirection, startIndex, pageSize, maximumListSize));
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
		/// <summary>This web service method gets a single DebugAttributeValueLog by an index.</summary>
		///
		/// <param name="debugAttributeValueLogID">The index for DebugAttributeValueLog to be fetched</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Core.DebugAttributeValueLogResults GetOneDebugAttributeValueLog(string debugAttributeValueLogID, string sortColumn, string sortDirection)
		{
			Components.Core.DebugAttributeValueLogResults results = new Components.Core.DebugAttributeValueLogResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Core.DebugAttributeValueLog item =  BLL.Core.DebugAttributeValueLogManager.GetOneDebugAttributeValueLog(MOD.Data.DataHelper.GetGuid(debugAttributeValueLogID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets a single DebugAttributeValueLog by an index.</summary>
		///
		/// <param name="debugAttributeValueLogID">The index for DebugAttributeValueLog to be fetched</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Core.DebugAttributeValueLogResults GetOneDebugAttributeValueLogByDebugAttributeValueLogID(string debugAttributeValueLogID, string sortColumn, string sortDirection)
		{
			Components.Core.DebugAttributeValueLogResults results = new Components.Core.DebugAttributeValueLogResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Core.DebugAttributeValueLog item =  BLL.Core.DebugAttributeValueLogManager.GetOneDebugAttributeValueLogByDebugAttributeValueLogID(MOD.Data.DataHelper.GetGuid(debugAttributeValueLogID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method logs DebugAttributeValueLog data.</summary>
		///
		/// <param name="debugAttributeValueLogID">A property of DebugAttributeValueLog item to be managed</param>
		/// <param name="debugLogID">A property of DebugAttributeValueLog item to be managed</param>
		/// <param name="baseAttributeID">A property of DebugAttributeValueLog item to be managed</param>
		/// <param name="attributeValue">A property of DebugAttributeValueLog item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Core.DebugAttributeValueLogResults LogOneDebugAttributeValueLog(string debugAttributeValueLogID, string debugLogID, string baseAttributeID, string attributeValue)
		{
			Components.Core.DebugAttributeValueLogResults results = new Components.Core.DebugAttributeValueLogResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Core.DebugAttributeValueLog item = new BLL.Core.DebugAttributeValueLog();
				item.DebugAttributeValueLogID = MOD.Data.DataHelper.GetGuid(debugAttributeValueLogID, MOD.Data.DefaultValue.Guid);
				item.DebugLogID = MOD.Data.DataHelper.GetGuid(debugLogID, MOD.Data.DefaultValue.Guid);
				item.BaseAttributeID = MOD.Data.DataHelper.GetGuid(baseAttributeID, MOD.Data.DefaultValue.Guid);
				item.AttributeValue = attributeValue;
				BLL.Core.DebugAttributeValueLogManager.LogOneDebugAttributeValueLog(item, false);
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
		public DebugAttributeValueLogManager()
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