
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
using MW.MComm.WalletTest.WebService.Accounts;
using BLL = MW.MComm.WalletSolution.BLL;
using MW.MComm.WalletSolution.BLL.Accounts;
using MOD.Data;
using Utility = MW.MComm.WalletSolution.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
namespace MW.MComm.WalletTest.WebService.Accounts
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage AccountAttribute related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public class AccountAttributeManager : System.Web.Services.WebService
	{
		#region "Service Methods"
		// ------------------------------------------------------------------
		/// <summary>This web service method inserts AccountAttribute data.</summary>
		///
		/// <param name="baseAttributeID">A property of AccountAttribute item to be managed</param>
		/// <param name="attributeCode">A property of AccountAttribute item to be managed</param>
		/// <param name="attributeName">A property of AccountAttribute item to be managed</param>
		/// <param name="attributeTypeCode">A property of AccountAttribute item to be managed</param>
		/// <param name="dataTypeCode">A property of AccountAttribute item to be managed</param>
		/// <param name="description">A property of AccountAttribute item to be managed</param>
		/// <param name="isActive">A property of AccountAttribute item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.AccountAttributeResults AddOneAccountAttribute(string baseAttributeID, int attributeCode, string attributeName, int attributeTypeCode, int dataTypeCode, string description, bool isActive)
		{
			Components.Accounts.AccountAttributeResults results = new Components.Accounts.AccountAttributeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.AccountAttribute item = new BLL.Accounts.AccountAttribute();
				item.BaseAttributeID = MOD.Data.DataHelper.GetGuid(baseAttributeID, MOD.Data.DefaultValue.Guid);
				item.AttributeCode = attributeCode;
				item.AttributeName = attributeName;
				item.AttributeTypeCode = attributeTypeCode;
				item.DataTypeCode = dataTypeCode;
				item.Description = description;
				item.IsActive = isActive;
				BLL.Accounts.AccountAttributeManager.AddOneAccountAttribute(item, false);
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
		/// <summary>This web service method deletes all AccountAttribute data by a key.</summary>
		///
		/// <param name="attributeTypeCode">A key for AccountAttribute items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.AccountAttributeResults DeleteAllAccountAttributeDataByAttributeTypeCode(int attributeTypeCode)
		{
			Components.Accounts.AccountAttributeResults results = new Components.Accounts.AccountAttributeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.AccountAttributeManager.DeleteAllAccountAttributeDataByAttributeTypeCode(attributeTypeCode);
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
		/// <summary>This web service method deletes all AccountAttribute data by a key.</summary>
		///
		/// <param name="baseAttributeID">A key for AccountAttribute items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.AccountAttributeResults DeleteAllAccountAttributeDataByBaseAttributeID(string baseAttributeID)
		{
			Components.Accounts.AccountAttributeResults results = new Components.Accounts.AccountAttributeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.AccountAttributeManager.DeleteAllAccountAttributeDataByBaseAttributeID(MOD.Data.DataHelper.GetGuid(baseAttributeID, MOD.Data.DefaultValue.Guid));
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
		/// <summary>This web service method deletes all AccountAttribute data by a key.</summary>
		///
		/// <param name="dataTypeCode">A key for AccountAttribute items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.AccountAttributeResults DeleteAllAccountAttributeDataByDataTypeCode(int dataTypeCode)
		{
			Components.Accounts.AccountAttributeResults results = new Components.Accounts.AccountAttributeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.AccountAttributeManager.DeleteAllAccountAttributeDataByDataTypeCode(dataTypeCode);
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
		/// <summary>This web service method deletes AccountAttribute data.</summary>
		///
		/// <param name="baseAttributeID">A property of AccountAttribute item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.AccountAttributeResults DeleteOneAccountAttribute(string baseAttributeID)
		{
			Components.Accounts.AccountAttributeResults results = new Components.Accounts.AccountAttributeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.AccountAttribute item = new BLL.Accounts.AccountAttribute();
				item.BaseAttributeID = MOD.Data.DataHelper.GetGuid(baseAttributeID, MOD.Data.DefaultValue.Guid);
				BLL.Accounts.AccountAttributeManager.DeleteOneAccountAttribute(item, false);
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
		/// <summary>This web service method gets all AccountAttribute data.</summary>
		///
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.AccountAttributeResults GetAllAccountAttributeData(string sortColumn, string sortDirection)
		{
			Components.Accounts.AccountAttributeResults results = new Components.Accounts.AccountAttributeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Accounts.AccountAttributeManager.GetAllAccountAttributeData(Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all AccountAttribute data by a key.</summary>
		///
		/// <param name="attributeTypeCode">A key for AccountAttribute items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.AccountAttributeResults GetAllAccountAttributeDataByAttributeTypeCode(string attributeTypeCode, string sortColumn, string sortDirection)
		{
			Components.Accounts.AccountAttributeResults results = new Components.Accounts.AccountAttributeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Accounts.AccountAttributeManager.GetAllAccountAttributeDataByAttributeTypeCode(MOD.Data.DataHelper.GetInt(attributeTypeCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all AccountAttribute data by a key.</summary>
		///
		/// <param name="baseAttributeID">A key for AccountAttribute items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.AccountAttributeResults GetAllAccountAttributeDataByBaseAttributeID(string baseAttributeID, string sortColumn, string sortDirection)
		{
			Components.Accounts.AccountAttributeResults results = new Components.Accounts.AccountAttributeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Accounts.AccountAttributeManager.GetAllAccountAttributeDataByBaseAttributeID(MOD.Data.DataHelper.GetGuid(baseAttributeID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all AccountAttribute data by criteria.</summary>
		///
		/// <param name="attributeName">A key for AccountAttribute items to be fetched</param>
		/// <param name="attributeTypeCode">A key for AccountAttribute items to be fetched</param>
		/// <param name="dataTypeCode">A key for AccountAttribute items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for AccountAttribute items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for AccountAttribute items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.AccountAttributeResults GetAllAccountAttributeDataByCriteria(string attributeName, string attributeTypeCode, string dataTypeCode, string lastModifiedDateStart, string lastModifiedDateEnd, string sortColumn, string sortDirection)
		{
			Components.Accounts.AccountAttributeResults results = new Components.Accounts.AccountAttributeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Accounts.AccountAttributeManager.GetAllAccountAttributeDataByCriteria(MOD.Data.SearchHelper.GetString(attributeName), MOD.Data.SearchHelper.GetInt(attributeTypeCode), MOD.Data.SearchHelper.GetInt(dataTypeCode), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateStart), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateEnd), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all AccountAttribute data by a key.</summary>
		///
		/// <param name="dataTypeCode">A key for AccountAttribute items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.AccountAttributeResults GetAllAccountAttributeDataByDataTypeCode(string dataTypeCode, string sortColumn, string sortDirection)
		{
			Components.Accounts.AccountAttributeResults results = new Components.Accounts.AccountAttributeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Accounts.AccountAttributeManager.GetAllAccountAttributeDataByDataTypeCode(MOD.Data.DataHelper.GetInt(dataTypeCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all AccountAttribute data by criteria.</summary>
		///
		/// <param name="attributeName">A key for AccountAttribute items to be fetched</param>
		/// <param name="attributeTypeCode">A key for AccountAttribute items to be fetched</param>
		/// <param name="dataTypeCode">A key for AccountAttribute items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for AccountAttribute items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for AccountAttribute items to be fetched</param>
         /// <param name="startIndex">Start Index (beginning at 1)</param>
         /// <param name="pageSize">Page Size</param>
         /// <param name="maximumListSize">Maximum List Size</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.AccountAttributeResults GetManyAccountAttributeDataByCriteria(string attributeName, string attributeTypeCode, string dataTypeCode, string lastModifiedDateStart, string lastModifiedDateEnd, int startIndex, int pageSize, int maximumListSize, string sortColumn, string sortDirection)
		{
			Components.Accounts.AccountAttributeResults results = new Components.Accounts.AccountAttributeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				int totalRecords = 0;
				bool maximumListSizeExceeded = false;
				results.Results = BLL.Accounts.AccountAttributeManager.GetManyAccountAttributeDataByCriteria(MOD.Data.SearchHelper.GetString(attributeName), MOD.Data.SearchHelper.GetInt(attributeTypeCode), MOD.Data.SearchHelper.GetInt(dataTypeCode), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateStart), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateEnd), out totalRecords, out maximumListSizeExceeded, Globals.getDataOptions(sortColumn, sortDirection, startIndex, pageSize, maximumListSize));
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
		/// <summary>This web service method gets a single AccountAttribute by an index.</summary>
		///
		/// <param name="baseAttributeID">The index for AccountAttribute to be fetched</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.AccountAttributeResults GetOneAccountAttribute(string baseAttributeID, string sortColumn, string sortDirection)
		{
			Components.Accounts.AccountAttributeResults results = new Components.Accounts.AccountAttributeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.AccountAttribute item =  BLL.Accounts.AccountAttributeManager.GetOneAccountAttribute(MOD.Data.DataHelper.GetGuid(baseAttributeID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets a single AccountAttribute by an index.</summary>
		///
		/// <param name="attributeCode">The index for AccountAttribute to be fetched</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.AccountAttributeResults GetOneAccountAttributeByAttributeCode(int attributeCode, string sortColumn, string sortDirection)
		{
			Components.Accounts.AccountAttributeResults results = new Components.Accounts.AccountAttributeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.AccountAttribute item =  BLL.Accounts.AccountAttributeManager.GetOneAccountAttributeByAttributeCode(MOD.Data.DataHelper.GetInt(attributeCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method updates AccountAttribute data.</summary>
		///
		/// <param name="baseAttributeID">A property of AccountAttribute item to be managed</param>
		/// <param name="attributeCode">A property of AccountAttribute item to be managed</param>
		/// <param name="attributeName">A property of AccountAttribute item to be managed</param>
		/// <param name="attributeTypeCode">A property of AccountAttribute item to be managed</param>
		/// <param name="dataTypeCode">A property of AccountAttribute item to be managed</param>
		/// <param name="description">A property of AccountAttribute item to be managed</param>
		/// <param name="isActive">A property of AccountAttribute item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.AccountAttributeResults UpdateOneAccountAttribute(string baseAttributeID, int attributeCode, string attributeName, int attributeTypeCode, int dataTypeCode, string description, bool isActive)
		{
			Components.Accounts.AccountAttributeResults results = new Components.Accounts.AccountAttributeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.AccountAttribute item = new BLL.Accounts.AccountAttribute();
				item.BaseAttributeID = MOD.Data.DataHelper.GetGuid(baseAttributeID, MOD.Data.DefaultValue.Guid);
				item.AttributeCode = attributeCode;
				item.AttributeName = attributeName;
				item.AttributeTypeCode = attributeTypeCode;
				item.DataTypeCode = dataTypeCode;
				item.Description = description;
				item.IsActive = isActive;
				BLL.Accounts.AccountAttributeManager.UpdateOneAccountAttribute(item, false);
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
		public AccountAttributeManager()
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