
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
using MW.MComm.WalletTest.WebService.UserExperience;
using BLL = MW.MComm.WalletSolution.BLL;
using MW.MComm.WalletSolution.BLL.UserExperience;
using MOD.Data;
using Utility = MW.MComm.WalletSolution.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
namespace MW.MComm.WalletTest.WebService.UserExperience
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage SiteLabelDefinition related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public class SiteLabelDefinitionManager : System.Web.Services.WebService
	{
		#region "Service Methods"
		// ------------------------------------------------------------------
		/// <summary>This web service method inserts SiteLabelDefinition data.</summary>
		///
		/// <param name="siteLabelDefinitionCode">A property of SiteLabelDefinition item to be managed</param>
		/// <param name="siteLabelDefinitionName">A property of SiteLabelDefinition item to be managed</param>
		/// <param name="defaultText">A property of SiteLabelDefinition item to be managed</param>
		/// <param name="description">A property of SiteLabelDefinition item to be managed</param>
		/// <param name="isActive">A property of SiteLabelDefinition item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.UserExperience.SiteLabelDefinitionResults AddOneSiteLabelDefinition(int siteLabelDefinitionCode, string siteLabelDefinitionName, string defaultText, string description, bool isActive)
		{
			Components.UserExperience.SiteLabelDefinitionResults results = new Components.UserExperience.SiteLabelDefinitionResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.UserExperience.SiteLabelDefinition item = new BLL.UserExperience.SiteLabelDefinition();
				item.SiteLabelDefinitionCode = siteLabelDefinitionCode;
				item.SiteLabelDefinitionName = siteLabelDefinitionName;
				item.DefaultText = defaultText;
				item.Description = description;
				item.IsActive = isActive;
				BLL.UserExperience.SiteLabelDefinitionManager.AddOneSiteLabelDefinition(item, false);
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
		/// <summary>This web service method deletes SiteLabelDefinition data.</summary>
		///
		/// <param name="siteLabelDefinitionCode">A property of SiteLabelDefinition item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.UserExperience.SiteLabelDefinitionResults DeleteOneSiteLabelDefinition(int siteLabelDefinitionCode)
		{
			Components.UserExperience.SiteLabelDefinitionResults results = new Components.UserExperience.SiteLabelDefinitionResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.UserExperience.SiteLabelDefinition item = new BLL.UserExperience.SiteLabelDefinition();
				item.SiteLabelDefinitionCode = siteLabelDefinitionCode;
				BLL.UserExperience.SiteLabelDefinitionManager.DeleteOneSiteLabelDefinition(item, false);
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
		/// <summary>This web service method gets all SiteLabelDefinition data.</summary>
		///
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.UserExperience.SiteLabelDefinitionResults GetAllSiteLabelDefinitionData(string sortColumn, string sortDirection)
		{
			Components.UserExperience.SiteLabelDefinitionResults results = new Components.UserExperience.SiteLabelDefinitionResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.UserExperience.SiteLabelDefinitionManager.GetAllSiteLabelDefinitionData(Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets a single SiteLabelDefinition by an index.</summary>
		///
		/// <param name="siteLabelDefinitionCode">The index for SiteLabelDefinition to be fetched</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.UserExperience.SiteLabelDefinitionResults GetOneSiteLabelDefinition(int siteLabelDefinitionCode, string sortColumn, string sortDirection)
		{
			Components.UserExperience.SiteLabelDefinitionResults results = new Components.UserExperience.SiteLabelDefinitionResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.UserExperience.SiteLabelDefinition item =  BLL.UserExperience.SiteLabelDefinitionManager.GetOneSiteLabelDefinition(MOD.Data.DataHelper.GetInt(siteLabelDefinitionCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method updates SiteLabelDefinition data.</summary>
		///
		/// <param name="siteLabelDefinitionCode">A property of SiteLabelDefinition item to be managed</param>
		/// <param name="siteLabelDefinitionName">A property of SiteLabelDefinition item to be managed</param>
		/// <param name="defaultText">A property of SiteLabelDefinition item to be managed</param>
		/// <param name="description">A property of SiteLabelDefinition item to be managed</param>
		/// <param name="isActive">A property of SiteLabelDefinition item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.UserExperience.SiteLabelDefinitionResults UpdateOneSiteLabelDefinition(int siteLabelDefinitionCode, string siteLabelDefinitionName, string defaultText, string description, bool isActive)
		{
			Components.UserExperience.SiteLabelDefinitionResults results = new Components.UserExperience.SiteLabelDefinitionResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.UserExperience.SiteLabelDefinition item = new BLL.UserExperience.SiteLabelDefinition();
				item.SiteLabelDefinitionCode = siteLabelDefinitionCode;
				item.SiteLabelDefinitionName = siteLabelDefinitionName;
				item.DefaultText = defaultText;
				item.Description = description;
				item.IsActive = isActive;
				BLL.UserExperience.SiteLabelDefinitionManager.UpdateOneSiteLabelDefinition(item, false);
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
		public SiteLabelDefinitionManager()
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