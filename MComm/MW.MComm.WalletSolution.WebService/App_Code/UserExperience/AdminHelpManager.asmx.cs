
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
using MW.MComm.WalletSolution.WebService.UserExperience;
using BLL = MW.MComm.WalletSolution.BLL;
using MW.MComm.WalletSolution.BLL.UserExperience;
using MOD.Data;
using Utility = MW.MComm.WalletSolution.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
namespace MW.MComm.WalletSolution.WebService.UserExperience
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage AdminHelp related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public class AdminHelpManager : System.Web.Services.WebService
	{
		#region "Service Methods"
		// ------------------------------------------------------------------
		/// <summary>This web service method inserts AdminHelp data.</summary>
		///
		/// <param name="item">The AdminHelp to be managed.</param>
		/// <param name="performCascadeOperation">Flag, indicating if a cascade operation should be performed on the AdminHelp item.</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.UserExperience.AdminHelpResults AddOneAdminHelp(BLL.UserExperience.AdminHelp item, bool performCascadeOperation)
		{
			Components.UserExperience.AdminHelpResults results = new Components.UserExperience.AdminHelpResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.UserExperience.AdminHelpManager.AddOneAdminHelp(item, performCascadeOperation);
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
		/// <summary>This web service method deletes all AdminHelp data by a key.</summary>
		///
		/// <param name="activityCode">A key for AdminHelp items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.UserExperience.AdminHelpResults DeleteAllAdminHelpDataByActivityCode(int activityCode)
		{
			Components.UserExperience.AdminHelpResults results = new Components.UserExperience.AdminHelpResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.UserExperience.AdminHelpManager.DeleteAllAdminHelpDataByActivityCode(activityCode);
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
		/// <summary>This web service method deletes all AdminHelp data by a key.</summary>
		///
		/// <param name="localeCode">A key for AdminHelp items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.UserExperience.AdminHelpResults DeleteAllAdminHelpDataByLocaleCode(int localeCode)
		{
			Components.UserExperience.AdminHelpResults results = new Components.UserExperience.AdminHelpResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.UserExperience.AdminHelpManager.DeleteAllAdminHelpDataByLocaleCode(localeCode);
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
		/// <summary>This web service method deletes AdminHelp data.</summary>
		///
		/// <param name="item">The AdminHelp to be deleted.</param>
		/// <param name="performCascadeOperation">Flag, indicating if a cascade delete should be performed on the AdminHelp item.</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.UserExperience.AdminHelpResults DeleteOneAdminHelp(BLL.UserExperience.AdminHelp item, bool performCascadeOperation)
		{
			Components.UserExperience.AdminHelpResults results = new Components.UserExperience.AdminHelpResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.UserExperience.AdminHelpManager.DeleteOneAdminHelp(item, performCascadeOperation);
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
		/// <summary>This web service method gets all AdminHelp data.</summary>
		///
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.UserExperience.AdminHelpResults GetAllAdminHelpData(string sortColumn, string sortDirection)
		{
			Components.UserExperience.AdminHelpResults results = new Components.UserExperience.AdminHelpResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.UserExperience.AdminHelpManager.GetAllAdminHelpData(Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all AdminHelp data by a key.</summary>
		///
		/// <param name="activityCode">A key for AdminHelp items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.UserExperience.AdminHelpResults GetAllAdminHelpDataByActivityCode(string activityCode, string sortColumn, string sortDirection)
		{
			Components.UserExperience.AdminHelpResults results = new Components.UserExperience.AdminHelpResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.UserExperience.AdminHelpManager.GetAllAdminHelpDataByActivityCode(MOD.Data.DataHelper.GetInt(activityCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all AdminHelp data by criteria.</summary>
		///
		/// <param name="adminHelpTitle">A key for AdminHelp items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for AdminHelp items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for AdminHelp items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.UserExperience.AdminHelpResults GetAllAdminHelpDataByCriteria(string adminHelpTitle, string lastModifiedDateStart, string lastModifiedDateEnd, string sortColumn, string sortDirection)
		{
			Components.UserExperience.AdminHelpResults results = new Components.UserExperience.AdminHelpResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.UserExperience.AdminHelpManager.GetAllAdminHelpDataByCriteria(MOD.Data.SearchHelper.GetString(adminHelpTitle), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateStart), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateEnd), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all AdminHelp data by a key.</summary>
		///
		/// <param name="localeCode">A key for AdminHelp items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.UserExperience.AdminHelpResults GetAllAdminHelpDataByLocaleCode(string localeCode, string sortColumn, string sortDirection)
		{
			Components.UserExperience.AdminHelpResults results = new Components.UserExperience.AdminHelpResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.UserExperience.AdminHelpManager.GetAllAdminHelpDataByLocaleCode(MOD.Data.DataHelper.GetInt(localeCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all AdminHelp data by criteria.</summary>
		///
		/// <param name="adminHelpTitle">A key for AdminHelp items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for AdminHelp items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for AdminHelp items to be fetched</param>
         /// <param name="startIndex">Start Index (beginning at 1)</param>
         /// <param name="pageSize">Page Size</param>
         /// <param name="maximumListSize">Maximum List Size</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.UserExperience.AdminHelpResults GetManyAdminHelpDataByCriteria(string adminHelpTitle, string lastModifiedDateStart, string lastModifiedDateEnd, int startIndex, int pageSize, int maximumListSize, string sortColumn, string sortDirection)
		{
			Components.UserExperience.AdminHelpResults results = new Components.UserExperience.AdminHelpResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				int totalRecords = 0;
				bool maximumListSizeExceeded = false;
				results.Results = BLL.UserExperience.AdminHelpManager.GetManyAdminHelpDataByCriteria(MOD.Data.SearchHelper.GetString(adminHelpTitle), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateStart), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateEnd), out totalRecords, out maximumListSizeExceeded, Globals.getDataOptions(sortColumn, sortDirection, startIndex, pageSize, maximumListSize));
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
		/// <summary>This web service method gets a single AdminHelp by an index.</summary>
		///
		/// <param name="activityCode">The index for AdminHelp to be fetched</param>
		/// <param name="localeCode">The index for AdminHelp to be fetched</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.UserExperience.AdminHelpResults GetOneAdminHelp(int activityCode, int localeCode, string sortColumn, string sortDirection)
		{
			Components.UserExperience.AdminHelpResults results = new Components.UserExperience.AdminHelpResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.UserExperience.AdminHelp item =  BLL.UserExperience.AdminHelpManager.GetOneAdminHelp(MOD.Data.DataHelper.GetInt(activityCode, MOD.Data.DefaultValue.Int), MOD.Data.DataHelper.GetInt(localeCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method updates AdminHelp data.</summary>
		///
		/// <param name="item">The AdminHelp to be managed.</param>
		/// <param name="performCascadeOperation">Flag, indicating if a cascade operation should be performed on the AdminHelp item.</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.UserExperience.AdminHelpResults UpdateOneAdminHelp(BLL.UserExperience.AdminHelp item, bool performCascadeOperation)
		{
			Components.UserExperience.AdminHelpResults results = new Components.UserExperience.AdminHelpResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.UserExperience.AdminHelpManager.UpdateOneAdminHelp(item, performCascadeOperation);
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
		public AdminHelpManager()
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