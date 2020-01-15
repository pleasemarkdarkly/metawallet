
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
using MW.MComm.WalletTest.WebService;
using MW.MComm.WalletTest.WebService.UserExperience;
using BLL = MW.MComm.WalletSolution.BLL;
using MW.MComm.WalletSolution.BLL.UserExperience;
using MOD.Data;
using Utility = MW.MComm.WalletSolution.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
namespace MW.MComm.WalletTest.WebService.UserExperience
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage SiteLabel related information.</summary>
	///
	/// File History:
	/// <created>5/8/2007 (Chris Grundy)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[WebService(Namespace = "http://modsystems.com/MW.MComm.WalletTest.WebService/UserExperience/SiteLabelManager")]
	[XmlType(Namespace = "http://modsystems.com/MW.MComm.WalletTest.WebService/UserExperience")]
	public class SiteLabelManager : System.Web.Services.WebService
	{
		#region "Service Methods"
		// ------------------------------------------------------------------
		/// <summary>This web service method inserts SiteLabel data.</summary>
		///
		/// <param name="localeCode">A property of SiteLabel item to be managed</param>
		/// <param name="title">A property of SiteLabel item to be managed</param>
		/// <param name="displayText">A property of SiteLabel item to be managed</param>
		/// <param name="targetLocation">A property of SiteLabel item to be managed</param>
		/// <param name="fileURL">A property of SiteLabel item to be managed</param>
		/// <param name="description">A property of SiteLabel item to be managed</param>
		/// <param name="siteLabelDefinitionCode">A property of SiteLabel item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.UserExperience.SiteLabelResults AddOneSiteLabel(int localeCode, string title, string displayText, string targetLocation, string fileURL, string description, int siteLabelDefinitionCode)
		{
			Components.UserExperience.SiteLabelResults results = new Components.UserExperience.SiteLabelResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.UserExperience.SiteLabel item = new BLL.UserExperience.SiteLabel();
				item.LocaleCode = localeCode;
				item.Title = title;
				item.DisplayText = displayText;
				item.TargetLocation = targetLocation;
				item.FileURL = fileURL;
				item.Description = description;
				item.SiteLabelDefinitionCode = siteLabelDefinitionCode;
				BLL.UserExperience.SiteLabelManager.AddOneSiteLabel(item, false);
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
		/// <summary>This web service method updates SiteLabel data.</summary>
		///
		/// <param name="localeCode">A property of SiteLabel item to be managed</param>
		/// <param name="title">A property of SiteLabel item to be managed</param>
		/// <param name="displayText">A property of SiteLabel item to be managed</param>
		/// <param name="targetLocation">A property of SiteLabel item to be managed</param>
		/// <param name="fileURL">A property of SiteLabel item to be managed</param>
		/// <param name="description">A property of SiteLabel item to be managed</param>
		/// <param name="siteLabelDefinitionCode">A property of SiteLabel item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.UserExperience.SiteLabelResults UpdateOneSiteLabel(int localeCode, string title, string displayText, string targetLocation, string fileURL, string description, int siteLabelDefinitionCode)
		{
			Components.UserExperience.SiteLabelResults results = new Components.UserExperience.SiteLabelResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.UserExperience.SiteLabel item = new BLL.UserExperience.SiteLabel();
				item.LocaleCode = localeCode;
				item.Title = title;
				item.DisplayText = displayText;
				item.TargetLocation = targetLocation;
				item.FileURL = fileURL;
				item.Description = description;
				item.SiteLabelDefinitionCode = siteLabelDefinitionCode;
				BLL.UserExperience.SiteLabelManager.UpdateOneSiteLabel(item, false);
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
		/// <summary>This web service method deletes SiteLabel data.</summary>
		///
		/// <param name="localeCode">A property of SiteLabel item to be managed</param>
		/// <param name="siteLabelDefinitionCode">A property of SiteLabel item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.UserExperience.SiteLabelResults DeleteOneSiteLabel(int localeCode, int siteLabelDefinitionCode)
		{
			Components.UserExperience.SiteLabelResults results = new Components.UserExperience.SiteLabelResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.UserExperience.SiteLabel item = new BLL.UserExperience.SiteLabel();
				item.LocaleCode = localeCode;
				item.SiteLabelDefinitionCode = siteLabelDefinitionCode;
				BLL.UserExperience.SiteLabelManager.DeleteOneSiteLabel(item, false);
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
		/// <summary>This web service method deletes all SiteLabel data by a key.</summary>
		///
		/// <param name="localeCode">A key for SiteLabel items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.UserExperience.SiteLabelResults DeleteAllSiteLabelDataByLocaleCode(int localeCode)
		{
			Components.UserExperience.SiteLabelResults results = new Components.UserExperience.SiteLabelResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.UserExperience.SiteLabelManager.DeleteAllSiteLabelDataByLocaleCode(localeCode);
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
		/// <summary>This web service method gets a single SiteLabel by an index.</summary>
		///
		/// <param name="siteLabelDefinitionCode">The index for SiteLabel to be fetched</param>
		/// <param name="localeCode">The index for SiteLabel to be fetched</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.UserExperience.SiteLabelResults GetOneSiteLabel(int siteLabelDefinitionCode, int localeCode, string sortColumn, string sortDirection)
		{
			Components.UserExperience.SiteLabelResults results = new Components.UserExperience.SiteLabelResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.UserExperience.SiteLabel item =  BLL.UserExperience.SiteLabelManager.GetOneSiteLabel(MOD.Data.DataHelper.GetInt(siteLabelDefinitionCode, MOD.Data.DefaultValue.Int), MOD.Data.DataHelper.GetInt(localeCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
				// populate desired collections with lazy loading
				bool isAccessed = true;
				item.IsSerializing = false;
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
		/// <summary>This web service method gets all SiteLabel data.</summary>
		///
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.UserExperience.SiteLabelResults GetAllSiteLabelData(string sortColumn, string sortDirection)
		{
			Components.UserExperience.SiteLabelResults results = new Components.UserExperience.SiteLabelResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.UserExperience.SiteLabelManager.GetAllSiteLabelData(Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all SiteLabel data by a key.</summary>
		///
		/// <param name="localeCode">A key for SiteLabel items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.UserExperience.SiteLabelResults GetAllSiteLabelDataByLocaleCode(string localeCode, string sortColumn, string sortDirection)
		{
			Components.UserExperience.SiteLabelResults results = new Components.UserExperience.SiteLabelResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.UserExperience.SiteLabelManager.GetAllSiteLabelDataByLocaleCode(MOD.Data.DataHelper.GetInt(localeCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all SiteLabel data by criteria.</summary>
		///
		/// <param name="title">A key for SiteLabel items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for SiteLabel items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for SiteLabel items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.UserExperience.SiteLabelResults GetAllSiteLabelDataByCriteria(string title, string lastModifiedDateStart, string lastModifiedDateEnd, string sortColumn, string sortDirection)
		{
			Components.UserExperience.SiteLabelResults results = new Components.UserExperience.SiteLabelResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.UserExperience.SiteLabelManager.GetAllSiteLabelDataByCriteria(MOD.Data.SearchHelper.GetString(title), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateStart), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateEnd), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all SiteLabel data by criteria.</summary>
		///
		/// <param name="title">A key for SiteLabel items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for SiteLabel items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for SiteLabel items to be fetched</param>
         /// <param name="startIndex">Start Index (beginning at 1)</param>
         /// <param name="pageSize">Page Size</param>
         /// <param name="maximumListSize">Maximum List Size</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.UserExperience.SiteLabelResults GetManySiteLabelDataByCriteria(string title, string lastModifiedDateStart, string lastModifiedDateEnd, int startIndex, int pageSize, int maximumListSize, string sortColumn, string sortDirection)
		{
			Components.UserExperience.SiteLabelResults results = new Components.UserExperience.SiteLabelResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				int totalRecords = 0;
				bool maximumListSizeExceeded = false;
				results.Results = BLL.UserExperience.SiteLabelManager.GetManySiteLabelDataByCriteria(MOD.Data.SearchHelper.GetString(title), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateStart), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateEnd), out totalRecords, out maximumListSizeExceeded, Globals.getDataOptions(sortColumn, sortDirection, startIndex, pageSize, maximumListSize));
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
		/// <summary>This web service method deletes all SiteLabel data by a key.</summary>
		///
		/// <param name="siteLabelDefinitionCode">A key for SiteLabel items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.UserExperience.SiteLabelResults DeleteAllSiteLabelDataBySiteLabelDefinitionCode(int siteLabelDefinitionCode)
		{
			Components.UserExperience.SiteLabelResults results = new Components.UserExperience.SiteLabelResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.UserExperience.SiteLabelManager.DeleteAllSiteLabelDataBySiteLabelDefinitionCode(siteLabelDefinitionCode);
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
		/// <summary>This web service method gets all SiteLabel data by a key.</summary>
		///
		/// <param name="siteLabelDefinitionCode">A key for SiteLabel items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.UserExperience.SiteLabelResults GetAllSiteLabelDataBySiteLabelDefinitionCode(string siteLabelDefinitionCode, string sortColumn, string sortDirection)
		{
			Components.UserExperience.SiteLabelResults results = new Components.UserExperience.SiteLabelResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.UserExperience.SiteLabelManager.GetAllSiteLabelDataBySiteLabelDefinitionCode(MOD.Data.DataHelper.GetInt(siteLabelDefinitionCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		public SiteLabelManager()
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