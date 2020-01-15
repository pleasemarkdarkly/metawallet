
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
using MW.MComm.WalletSolution.WebService.Accounts;
using BLL = MW.MComm.WalletSolution.BLL;
using MW.MComm.WalletSolution.BLL.Accounts;
using MOD.Data;
using Utility = MW.MComm.WalletSolution.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
namespace MW.MComm.WalletSolution.WebService.Accounts
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage ParticipatingPartner related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public class ParticipatingPartnerManager : System.Web.Services.WebService
	{
		#region "Service Methods"
		// ------------------------------------------------------------------
		/// <summary>This web service method inserts ParticipatingPartner data.</summary>
		///
		/// <param name="item">The ParticipatingPartner to be managed.</param>
		/// <param name="performCascadeOperation">Flag, indicating if a cascade operation should be performed on the ParticipatingPartner item.</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.ParticipatingPartnerResults AddOneParticipatingPartner(BLL.Accounts.ParticipatingPartner item, bool performCascadeOperation)
		{
			Components.Accounts.ParticipatingPartnerResults results = new Components.Accounts.ParticipatingPartnerResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.ParticipatingPartnerManager.AddOneParticipatingPartner(item, performCascadeOperation);
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
		/// <summary>This web service method deletes all ParticipatingPartner data by a key.</summary>
		///
		/// <param name="accountID">A key for ParticipatingPartner items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.ParticipatingPartnerResults DeleteAllParticipatingPartnerDataByAccountID(string accountID)
		{
			Components.Accounts.ParticipatingPartnerResults results = new Components.Accounts.ParticipatingPartnerResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.ParticipatingPartnerManager.DeleteAllParticipatingPartnerDataByAccountID(MOD.Data.DataHelper.GetGuid(accountID, MOD.Data.DefaultValue.Guid));
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
		/// <summary>This web service method deletes all ParticipatingPartner data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for ParticipatingPartner items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.ParticipatingPartnerResults DeleteAllParticipatingPartnerDataByMetaPartnerID(string metaPartnerID)
		{
			Components.Accounts.ParticipatingPartnerResults results = new Components.Accounts.ParticipatingPartnerResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.ParticipatingPartnerManager.DeleteAllParticipatingPartnerDataByMetaPartnerID(MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid));
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
		/// <summary>This web service method deletes ParticipatingPartner data.</summary>
		///
		/// <param name="item">The ParticipatingPartner to be deleted.</param>
		/// <param name="performCascadeOperation">Flag, indicating if a cascade delete should be performed on the ParticipatingPartner item.</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.ParticipatingPartnerResults DeleteOneParticipatingPartner(BLL.Accounts.ParticipatingPartner item, bool performCascadeOperation)
		{
			Components.Accounts.ParticipatingPartnerResults results = new Components.Accounts.ParticipatingPartnerResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.ParticipatingPartnerManager.DeleteOneParticipatingPartner(item, performCascadeOperation);
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
		/// <summary>This web service method gets all ParticipatingPartner data.</summary>
		///
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.ParticipatingPartnerResults GetAllParticipatingPartnerData(string sortColumn, string sortDirection)
		{
			Components.Accounts.ParticipatingPartnerResults results = new Components.Accounts.ParticipatingPartnerResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Accounts.ParticipatingPartnerManager.GetAllParticipatingPartnerData(Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all ParticipatingPartner data by a key.</summary>
		///
		/// <param name="accountID">A key for ParticipatingPartner items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.ParticipatingPartnerResults GetAllParticipatingPartnerDataByAccountID(string accountID, string sortColumn, string sortDirection)
		{
			Components.Accounts.ParticipatingPartnerResults results = new Components.Accounts.ParticipatingPartnerResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Accounts.ParticipatingPartnerManager.GetAllParticipatingPartnerDataByAccountID(MOD.Data.DataHelper.GetGuid(accountID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all ParticipatingPartner data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for ParticipatingPartner items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.ParticipatingPartnerResults GetAllParticipatingPartnerDataByMetaPartnerID(string metaPartnerID, string sortColumn, string sortDirection)
		{
			Components.Accounts.ParticipatingPartnerResults results = new Components.Accounts.ParticipatingPartnerResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Accounts.ParticipatingPartnerManager.GetAllParticipatingPartnerDataByMetaPartnerID(MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets a single ParticipatingPartner by an index.</summary>
		///
		/// <param name="accountID">The index for ParticipatingPartner to be fetched</param>
		/// <param name="metaPartnerID">The index for ParticipatingPartner to be fetched</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.ParticipatingPartnerResults GetOneParticipatingPartner(string accountID, string metaPartnerID, string sortColumn, string sortDirection)
		{
			Components.Accounts.ParticipatingPartnerResults results = new Components.Accounts.ParticipatingPartnerResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.ParticipatingPartner item =  BLL.Accounts.ParticipatingPartnerManager.GetOneParticipatingPartner(MOD.Data.DataHelper.GetGuid(accountID, MOD.Data.DefaultValue.Guid), MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method updates ParticipatingPartner data.</summary>
		///
		/// <param name="item">The ParticipatingPartner to be managed.</param>
		/// <param name="performCascadeOperation">Flag, indicating if a cascade operation should be performed on the ParticipatingPartner item.</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.ParticipatingPartnerResults UpdateOneParticipatingPartner(BLL.Accounts.ParticipatingPartner item, bool performCascadeOperation)
		{
			Components.Accounts.ParticipatingPartnerResults results = new Components.Accounts.ParticipatingPartnerResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.ParticipatingPartnerManager.UpdateOneParticipatingPartner(item, performCascadeOperation);
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
		public ParticipatingPartnerManager()
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