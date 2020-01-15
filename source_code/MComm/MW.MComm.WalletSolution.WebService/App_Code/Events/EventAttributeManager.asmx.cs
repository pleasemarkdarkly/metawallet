
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
using MW.MComm.WalletSolution.WebService.Events;
using BLL = MW.MComm.WalletSolution.BLL;
using MW.MComm.WalletSolution.BLL.Events;
using MOD.Data;
using Utility = MW.MComm.WalletSolution.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
namespace MW.MComm.WalletSolution.WebService.Events
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage EventAttribute related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public class EventAttributeManager : System.Web.Services.WebService
	{
		#region "Service Methods"
		// ------------------------------------------------------------------
		/// <summary>This web service method inserts EventAttribute data.</summary>
		///
		/// <param name="item">The EventAttribute to be managed.</param>
		/// <param name="performCascadeOperation">Flag, indicating if a cascade operation should be performed on the EventAttribute item.</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Events.EventAttributeResults AddOneEventAttribute(BLL.Events.EventAttribute item, bool performCascadeOperation)
		{
			Components.Events.EventAttributeResults results = new Components.Events.EventAttributeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Events.EventAttributeManager.AddOneEventAttribute(item, performCascadeOperation);
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
		/// <summary>This web service method deletes all EventAttribute data by a key.</summary>
		///
		/// <param name="attributeTypeCode">A key for EventAttribute items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Events.EventAttributeResults DeleteAllEventAttributeDataByAttributeTypeCode(int attributeTypeCode)
		{
			Components.Events.EventAttributeResults results = new Components.Events.EventAttributeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Events.EventAttributeManager.DeleteAllEventAttributeDataByAttributeTypeCode(attributeTypeCode);
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
		/// <summary>This web service method deletes all EventAttribute data by a key.</summary>
		///
		/// <param name="baseAttributeID">A key for EventAttribute items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Events.EventAttributeResults DeleteAllEventAttributeDataByBaseAttributeID(string baseAttributeID)
		{
			Components.Events.EventAttributeResults results = new Components.Events.EventAttributeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Events.EventAttributeManager.DeleteAllEventAttributeDataByBaseAttributeID(MOD.Data.DataHelper.GetGuid(baseAttributeID, MOD.Data.DefaultValue.Guid));
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
		/// <summary>This web service method deletes all EventAttribute data by a key.</summary>
		///
		/// <param name="dataTypeCode">A key for EventAttribute items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Events.EventAttributeResults DeleteAllEventAttributeDataByDataTypeCode(int dataTypeCode)
		{
			Components.Events.EventAttributeResults results = new Components.Events.EventAttributeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Events.EventAttributeManager.DeleteAllEventAttributeDataByDataTypeCode(dataTypeCode);
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
		/// <summary>This web service method deletes EventAttribute data.</summary>
		///
		/// <param name="item">The EventAttribute to be deleted.</param>
		/// <param name="performCascadeOperation">Flag, indicating if a cascade delete should be performed on the EventAttribute item.</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Events.EventAttributeResults DeleteOneEventAttribute(BLL.Events.EventAttribute item, bool performCascadeOperation)
		{
			Components.Events.EventAttributeResults results = new Components.Events.EventAttributeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Events.EventAttributeManager.DeleteOneEventAttribute(item, performCascadeOperation);
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
		/// <summary>This web service method gets all EventAttribute data.</summary>
		///
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Events.EventAttributeResults GetAllEventAttributeData(string sortColumn, string sortDirection)
		{
			Components.Events.EventAttributeResults results = new Components.Events.EventAttributeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Events.EventAttributeManager.GetAllEventAttributeData(Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all EventAttribute data by a key.</summary>
		///
		/// <param name="attributeTypeCode">A key for EventAttribute items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Events.EventAttributeResults GetAllEventAttributeDataByAttributeTypeCode(string attributeTypeCode, string sortColumn, string sortDirection)
		{
			Components.Events.EventAttributeResults results = new Components.Events.EventAttributeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Events.EventAttributeManager.GetAllEventAttributeDataByAttributeTypeCode(MOD.Data.DataHelper.GetInt(attributeTypeCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all EventAttribute data by a key.</summary>
		///
		/// <param name="baseAttributeID">A key for EventAttribute items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Events.EventAttributeResults GetAllEventAttributeDataByBaseAttributeID(string baseAttributeID, string sortColumn, string sortDirection)
		{
			Components.Events.EventAttributeResults results = new Components.Events.EventAttributeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Events.EventAttributeManager.GetAllEventAttributeDataByBaseAttributeID(MOD.Data.DataHelper.GetGuid(baseAttributeID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all EventAttribute data by criteria.</summary>
		///
		/// <param name="attributeName">A key for EventAttribute items to be fetched</param>
		/// <param name="attributeTypeCode">A key for EventAttribute items to be fetched</param>
		/// <param name="dataTypeCode">A key for EventAttribute items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for EventAttribute items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for EventAttribute items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Events.EventAttributeResults GetAllEventAttributeDataByCriteria(string attributeName, string attributeTypeCode, string dataTypeCode, string lastModifiedDateStart, string lastModifiedDateEnd, string sortColumn, string sortDirection)
		{
			Components.Events.EventAttributeResults results = new Components.Events.EventAttributeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Events.EventAttributeManager.GetAllEventAttributeDataByCriteria(MOD.Data.SearchHelper.GetString(attributeName), MOD.Data.SearchHelper.GetInt(attributeTypeCode), MOD.Data.SearchHelper.GetInt(dataTypeCode), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateStart), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateEnd), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all EventAttribute data by a key.</summary>
		///
		/// <param name="dataTypeCode">A key for EventAttribute items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Events.EventAttributeResults GetAllEventAttributeDataByDataTypeCode(string dataTypeCode, string sortColumn, string sortDirection)
		{
			Components.Events.EventAttributeResults results = new Components.Events.EventAttributeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Events.EventAttributeManager.GetAllEventAttributeDataByDataTypeCode(MOD.Data.DataHelper.GetInt(dataTypeCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all EventAttribute data by criteria.</summary>
		///
		/// <param name="attributeName">A key for EventAttribute items to be fetched</param>
		/// <param name="attributeTypeCode">A key for EventAttribute items to be fetched</param>
		/// <param name="dataTypeCode">A key for EventAttribute items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for EventAttribute items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for EventAttribute items to be fetched</param>
         /// <param name="startIndex">Start Index (beginning at 1)</param>
         /// <param name="pageSize">Page Size</param>
         /// <param name="maximumListSize">Maximum List Size</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Events.EventAttributeResults GetManyEventAttributeDataByCriteria(string attributeName, string attributeTypeCode, string dataTypeCode, string lastModifiedDateStart, string lastModifiedDateEnd, int startIndex, int pageSize, int maximumListSize, string sortColumn, string sortDirection)
		{
			Components.Events.EventAttributeResults results = new Components.Events.EventAttributeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				int totalRecords = 0;
				bool maximumListSizeExceeded = false;
				results.Results = BLL.Events.EventAttributeManager.GetManyEventAttributeDataByCriteria(MOD.Data.SearchHelper.GetString(attributeName), MOD.Data.SearchHelper.GetInt(attributeTypeCode), MOD.Data.SearchHelper.GetInt(dataTypeCode), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateStart), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateEnd), out totalRecords, out maximumListSizeExceeded, Globals.getDataOptions(sortColumn, sortDirection, startIndex, pageSize, maximumListSize));
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
		/// <summary>This web service method gets a single EventAttribute by an index.</summary>
		///
		/// <param name="baseAttributeID">The index for EventAttribute to be fetched</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Events.EventAttributeResults GetOneEventAttribute(string baseAttributeID, string sortColumn, string sortDirection)
		{
			Components.Events.EventAttributeResults results = new Components.Events.EventAttributeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Events.EventAttribute item =  BLL.Events.EventAttributeManager.GetOneEventAttribute(MOD.Data.DataHelper.GetGuid(baseAttributeID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets a single EventAttribute by an index.</summary>
		///
		/// <param name="attributeCode">The index for EventAttribute to be fetched</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Events.EventAttributeResults GetOneEventAttributeByAttributeCode(int attributeCode, string sortColumn, string sortDirection)
		{
			Components.Events.EventAttributeResults results = new Components.Events.EventAttributeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Events.EventAttribute item =  BLL.Events.EventAttributeManager.GetOneEventAttributeByAttributeCode(MOD.Data.DataHelper.GetInt(attributeCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method updates EventAttribute data.</summary>
		///
		/// <param name="item">The EventAttribute to be managed.</param>
		/// <param name="performCascadeOperation">Flag, indicating if a cascade operation should be performed on the EventAttribute item.</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Events.EventAttributeResults UpdateOneEventAttribute(BLL.Events.EventAttribute item, bool performCascadeOperation)
		{
			Components.Events.EventAttributeResults results = new Components.Events.EventAttributeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Events.EventAttributeManager.UpdateOneEventAttribute(item, performCascadeOperation);
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
		public EventAttributeManager()
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