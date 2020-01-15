
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
	/// <summary>This class is used to manage LoanToMetaPartner related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public class LoanToMetaPartnerManager : System.Web.Services.WebService
	{
		#region "Service Methods"
		// ------------------------------------------------------------------
		/// <summary>This web service method inserts LoanToMetaPartner data.</summary>
		///
		/// <param name="accountID">A property of LoanToMetaPartner item to be managed</param>
		/// <param name="metaPartnerID">A property of LoanToMetaPartner item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.LoanToMetaPartnerResults AddOneLoanToMetaPartner(string accountID, string metaPartnerID)
		{
			Components.Accounts.LoanToMetaPartnerResults results = new Components.Accounts.LoanToMetaPartnerResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.LoanToMetaPartner item = new BLL.Accounts.LoanToMetaPartner();
				item.AccountID = MOD.Data.DataHelper.GetGuid(accountID, MOD.Data.DefaultValue.Guid);
				item.MetaPartnerID = MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid);
				BLL.Accounts.LoanToMetaPartnerManager.AddOneLoanToMetaPartner(item, false);
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
		/// <summary>This web service method deletes all LoanToMetaPartner data by a key.</summary>
		///
		/// <param name="accountID">A key for LoanToMetaPartner items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.LoanToMetaPartnerResults DeleteAllLoanToMetaPartnerDataByAccountID(string accountID)
		{
			Components.Accounts.LoanToMetaPartnerResults results = new Components.Accounts.LoanToMetaPartnerResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.LoanToMetaPartnerManager.DeleteAllLoanToMetaPartnerDataByAccountID(MOD.Data.DataHelper.GetGuid(accountID, MOD.Data.DefaultValue.Guid));
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
		/// <summary>This web service method deletes all LoanToMetaPartner data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for LoanToMetaPartner items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.LoanToMetaPartnerResults DeleteAllLoanToMetaPartnerDataByMetaPartnerID(string metaPartnerID)
		{
			Components.Accounts.LoanToMetaPartnerResults results = new Components.Accounts.LoanToMetaPartnerResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.LoanToMetaPartnerManager.DeleteAllLoanToMetaPartnerDataByMetaPartnerID(MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid));
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
		/// <summary>This web service method deletes LoanToMetaPartner data.</summary>
		///
		/// <param name="accountID">A property of LoanToMetaPartner item to be managed</param>
		/// <param name="metaPartnerID">A property of LoanToMetaPartner item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.LoanToMetaPartnerResults DeleteOneLoanToMetaPartner(string accountID, string metaPartnerID)
		{
			Components.Accounts.LoanToMetaPartnerResults results = new Components.Accounts.LoanToMetaPartnerResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.LoanToMetaPartner item = new BLL.Accounts.LoanToMetaPartner();
				item.AccountID = MOD.Data.DataHelper.GetGuid(accountID, MOD.Data.DefaultValue.Guid);
				item.MetaPartnerID = MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid);
				BLL.Accounts.LoanToMetaPartnerManager.DeleteOneLoanToMetaPartner(item, false);
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
		/// <summary>This web service method gets all LoanToMetaPartner data.</summary>
		///
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.LoanToMetaPartnerResults GetAllLoanToMetaPartnerData(string sortColumn, string sortDirection)
		{
			Components.Accounts.LoanToMetaPartnerResults results = new Components.Accounts.LoanToMetaPartnerResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Accounts.LoanToMetaPartnerManager.GetAllLoanToMetaPartnerData(Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all LoanToMetaPartner data by a key.</summary>
		///
		/// <param name="accountID">A key for LoanToMetaPartner items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.LoanToMetaPartnerResults GetAllLoanToMetaPartnerDataByAccountID(string accountID, string sortColumn, string sortDirection)
		{
			Components.Accounts.LoanToMetaPartnerResults results = new Components.Accounts.LoanToMetaPartnerResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Accounts.LoanToMetaPartnerManager.GetAllLoanToMetaPartnerDataByAccountID(MOD.Data.DataHelper.GetGuid(accountID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all LoanToMetaPartner data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for LoanToMetaPartner items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.LoanToMetaPartnerResults GetAllLoanToMetaPartnerDataByMetaPartnerID(string metaPartnerID, string sortColumn, string sortDirection)
		{
			Components.Accounts.LoanToMetaPartnerResults results = new Components.Accounts.LoanToMetaPartnerResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Accounts.LoanToMetaPartnerManager.GetAllLoanToMetaPartnerDataByMetaPartnerID(MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets a single LoanToMetaPartner by an index.</summary>
		///
		/// <param name="accountID">The index for LoanToMetaPartner to be fetched</param>
		/// <param name="metaPartnerID">The index for LoanToMetaPartner to be fetched</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.LoanToMetaPartnerResults GetOneLoanToMetaPartner(string accountID, string metaPartnerID, string sortColumn, string sortDirection)
		{
			Components.Accounts.LoanToMetaPartnerResults results = new Components.Accounts.LoanToMetaPartnerResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.LoanToMetaPartner item =  BLL.Accounts.LoanToMetaPartnerManager.GetOneLoanToMetaPartner(MOD.Data.DataHelper.GetGuid(accountID, MOD.Data.DefaultValue.Guid), MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method updates LoanToMetaPartner data.</summary>
		///
		/// <param name="accountID">A property of LoanToMetaPartner item to be managed</param>
		/// <param name="metaPartnerID">A property of LoanToMetaPartner item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.LoanToMetaPartnerResults UpdateOneLoanToMetaPartner(string accountID, string metaPartnerID)
		{
			Components.Accounts.LoanToMetaPartnerResults results = new Components.Accounts.LoanToMetaPartnerResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.LoanToMetaPartner item = new BLL.Accounts.LoanToMetaPartner();
				item.AccountID = MOD.Data.DataHelper.GetGuid(accountID, MOD.Data.DefaultValue.Guid);
				item.MetaPartnerID = MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid);
				BLL.Accounts.LoanToMetaPartnerManager.UpdateOneLoanToMetaPartner(item, false);
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
		public LoanToMetaPartnerManager()
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