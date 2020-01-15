
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
	/// <summary>This class is used to manage SiteHelp related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public class SiteHelpManager : System.Web.Services.WebService
	{
		#region "Service Methods"
		// ------------------------------------------------------------------
		/// <summary>This web service method inserts SiteHelp data.</summary>
		///
		/// <param name="item">The SiteHelp to be managed.</param>
		/// <param name="performCascadeOperation">Flag, indicating if a cascade operation should be performed on the SiteHelp item.</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.UserExperience.SiteHelpResults AddOneSiteHelp(BLL.UserExperience.SiteHelp item, bool performCascadeOperation)
		{
			Components.UserExperience.SiteHelpResults results = new Components.UserExperience.SiteHelpResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.UserExperience.SiteHelpManager.AddOneSiteHelp(item, performCascadeOperation);
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
		/// <summary>This web service method deletes all SiteHelp data by a key.</summary>
		///
		/// <param name="localeCode">A key for SiteHelp items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.UserExperience.SiteHelpResults DeleteAllSiteHelpDataByLocaleCode(int localeCode)
		{
			Components.UserExperience.SiteHelpResults results = new Components.UserExperience.SiteHelpResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.UserExperience.SiteHelpManager.DeleteAllSiteHelpDataByLocaleCode(localeCode);
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
		/// <summary>This web service method deletes all SiteHelp data by a key.</summary>
		///
		/// <param name="siteHelpDefinitionCode">A key for SiteHelp items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.UserExperience.SiteHelpResults DeleteAllSiteHelpDataBySiteHelpDefinitionCode(int siteHelpDefinitionCode)
		{
			Components.UserExperience.SiteHelpResults results = new Components.UserExperience.SiteHelpResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.UserExperience.SiteHelpManager.DeleteAllSiteHelpDataBySiteHelpDefinitionCode(siteHelpDefinitionCode);
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
		/// <summary>This web service method deletes all SiteHelp data by a key.</summary>
		///
		/// <param name="siteHelpGroupCode">A key for SiteHelp items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.UserExperience.SiteHelpResults DeleteAllSiteHelpDataBySiteHelpGroupCode(int siteHelpGroupCode)
		{
			Components.UserExperience.SiteHelpResults results = new Components.UserExperience.SiteHelpResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.UserExperience.SiteHelpManager.DeleteAllSiteHelpDataBySiteHelpGroupCode(siteHelpGroupCode);
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
		/// <summary>This web service method deletes SiteHelp data.</summary>
		///
		/// <param name="item">The SiteHelp to be deleted.</param>
		/// <param name="performCascadeOperation">Flag, indicating if a cascade delete should be performed on the SiteHelp item.</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.UserExperience.SiteHelpResults DeleteOneSiteHelp(BLL.UserExperience.SiteHelp item, bool performCascadeOperation)
		{
			Components.UserExperience.SiteHelpResults results = new Components.UserExperience.SiteHelpResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.UserExperience.SiteHelpManager.DeleteOneSiteHelp(item, performCascadeOperation);
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
		/// <summary>This web service method gets all SiteHelp data.</summary>
		///
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.UserExperience.SiteHelpResults GetAllSiteHelpData(string sortColumn, string sortDirection)
		{
			Components.UserExperience.SiteHelpResults results = new Components.UserExperience.SiteHelpResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.UserExperience.SiteHelpManager.GetAllSiteHelpData(Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all SiteHelp data by criteria.</summary>
		///
		/// <param name="siteHelpName">A key for SiteHelp items to be fetched</param>
		/// <param name="siteHelpGroupCode">A key for SiteHelp items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for SiteHelp items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for SiteHelp items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.UserExperience.SiteHelpResults GetAllSiteHelpDataByCriteria(string siteHelpName, string siteHelpGroupCode, string lastModifiedDateStart, string lastModifiedDateEnd, string sortColumn, string sortDirection)
		{
			Components.UserExperience.SiteHelpResults results = new Components.UserExperience.SiteHelpResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.UserExperience.SiteHelpManager.GetAllSiteHelpDataByCriteria(MOD.Data.SearchHelper.GetString(siteHelpName), MOD.Data.SearchHelper.GetInt(siteHelpGroupCode), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateStart), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateEnd), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all SiteHelp data by a key.</summary>
		///
		/// <param name="localeCode">A key for SiteHelp items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.UserExperience.SiteHelpResults GetAllSiteHelpDataByLocaleCode(string localeCode, string sortColumn, string sortDirection)
		{
			Components.UserExperience.SiteHelpResults results = new Components.UserExperience.SiteHelpResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.UserExperience.SiteHelpManager.GetAllSiteHelpDataByLocaleCode(MOD.Data.DataHelper.GetInt(localeCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all SiteHelp data by a key.</summary>
		///
		/// <param name="siteHelpDefinitionCode">A key for SiteHelp items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.UserExperience.SiteHelpResults GetAllSiteHelpDataBySiteHelpDefinitionCode(string siteHelpDefinitionCode, string sortColumn, string sortDirection)
		{
			Components.UserExperience.SiteHelpResults results = new Components.UserExperience.SiteHelpResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.UserExperience.SiteHelpManager.GetAllSiteHelpDataBySiteHelpDefinitionCode(MOD.Data.DataHelper.GetInt(siteHelpDefinitionCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all SiteHelp data by a key.</summary>
		///
		/// <param name="siteHelpGroupCode">A key for SiteHelp items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.UserExperience.SiteHelpResults GetAllSiteHelpDataBySiteHelpGroupCode(string siteHelpGroupCode, string sortColumn, string sortDirection)
		{
			Components.UserExperience.SiteHelpResults results = new Components.UserExperience.SiteHelpResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.UserExperience.SiteHelpManager.GetAllSiteHelpDataBySiteHelpGroupCode(MOD.Data.DataHelper.GetInt(siteHelpGroupCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all SiteHelp data by criteria.</summary>
		///
		/// <param name="siteHelpName">A key for SiteHelp items to be fetched</param>
		/// <param name="siteHelpGroupCode">A key for SiteHelp items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for SiteHelp items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for SiteHelp items to be fetched</param>
         /// <param name="startIndex">Start Index (beginning at 1)</param>
         /// <param name="pageSize">Page Size</param>
         /// <param name="maximumListSize">Maximum List Size</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.UserExperience.SiteHelpResults GetManySiteHelpDataByCriteria(string siteHelpName, string siteHelpGroupCode, string lastModifiedDateStart, string lastModifiedDateEnd, int startIndex, int pageSize, int maximumListSize, string sortColumn, string sortDirection)
		{
			Components.UserExperience.SiteHelpResults results = new Components.UserExperience.SiteHelpResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				int totalRecords = 0;
				bool maximumListSizeExceeded = false;
				results.Results = BLL.UserExperience.SiteHelpManager.GetManySiteHelpDataByCriteria(MOD.Data.SearchHelper.GetString(siteHelpName), MOD.Data.SearchHelper.GetInt(siteHelpGroupCode), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateStart), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateEnd), out totalRecords, out maximumListSizeExceeded, Globals.getDataOptions(sortColumn, sortDirection, startIndex, pageSize, maximumListSize));
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
		/// <summary>This web service method gets a single SiteHelp by an index.</summary>
		///
		/// <param name="siteHelpDefinitionCode">The index for SiteHelp to be fetched</param>
		/// <param name="localeCode">The index for SiteHelp to be fetched</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.UserExperience.SiteHelpResults GetOneSiteHelp(int siteHelpDefinitionCode, int localeCode, string sortColumn, string sortDirection)
		{
			Components.UserExperience.SiteHelpResults results = new Components.UserExperience.SiteHelpResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.UserExperience.SiteHelp item =  BLL.UserExperience.SiteHelpManager.GetOneSiteHelp(MOD.Data.DataHelper.GetInt(siteHelpDefinitionCode, MOD.Data.DefaultValue.Int), MOD.Data.DataHelper.GetInt(localeCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method updates SiteHelp data.</summary>
		///
		/// <param name="item">The SiteHelp to be managed.</param>
		/// <param name="performCascadeOperation">Flag, indicating if a cascade operation should be performed on the SiteHelp item.</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.UserExperience.SiteHelpResults UpdateOneSiteHelp(BLL.UserExperience.SiteHelp item, bool performCascadeOperation)
		{
			Components.UserExperience.SiteHelpResults results = new Components.UserExperience.SiteHelpResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.UserExperience.SiteHelpManager.UpdateOneSiteHelp(item, performCascadeOperation);
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
		public SiteHelpManager()
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