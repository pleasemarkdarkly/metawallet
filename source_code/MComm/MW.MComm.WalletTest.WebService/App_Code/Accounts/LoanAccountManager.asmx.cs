
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
	/// <summary>This class is used to manage LoanAccount related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public class LoanAccountManager : System.Web.Services.WebService
	{
		#region "Service Methods"
		// ------------------------------------------------------------------
		/// <summary>This web service method inserts LoanAccount data.</summary>
		///
		/// <param name="accountID">A property of LoanAccount item to be managed</param>
		/// <param name="loanAmount">A property of LoanAccount item to be managed</param>
		/// <param name="outstandingAmount">A property of LoanAccount item to be managed</param>
		/// <param name="dueDate">A property of LoanAccount item to be managed</param>
		/// <param name="loanRate">A property of LoanAccount item to be managed</param>
		/// <param name="metaPartnerID">A property of LoanAccount item to be managed</param>
		/// <param name="accountName">A property of LoanAccount item to be managed</param>
		/// <param name="accountSubTypeCode">A property of LoanAccount item to be managed</param>
		/// <param name="currencyCode">A property of LoanAccount item to be managed</param>
		/// <param name="description">A property of LoanAccount item to be managed</param>
		/// <param name="isActive">A property of LoanAccount item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.LoanAccountResults AddOneLoanAccount(string accountID, decimal loanAmount, decimal outstandingAmount, string dueDate, float loanRate, string metaPartnerID, string accountName, int accountSubTypeCode, int currencyCode, string description, bool isActive)
		{
			Components.Accounts.LoanAccountResults results = new Components.Accounts.LoanAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.LoanAccount item = new BLL.Accounts.LoanAccount();
				item.AccountID = MOD.Data.DataHelper.GetGuid(accountID, MOD.Data.DefaultValue.Guid);
				item.LoanAmount = loanAmount;
				item.OutstandingAmount = outstandingAmount;
				item.DueDate = MOD.Data.DataHelper.GetDateTime(dueDate, System.DateTime.MinValue);
				item.LoanRate = loanRate;
				item.MetaPartnerID = MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid);
				item.AccountName = accountName;
				item.AccountSubTypeCode = accountSubTypeCode;
				item.CurrencyCode = currencyCode;
				item.Description = description;
				item.IsActive = isActive;
				BLL.Accounts.LoanAccountManager.AddOneLoanAccount(item, false);
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
		/// <summary>This web service method deletes all LoanAccount data by a key.</summary>
		///
		/// <param name="accountID">A key for LoanAccount items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.LoanAccountResults DeleteAllLoanAccountDataByAccountID(string accountID)
		{
			Components.Accounts.LoanAccountResults results = new Components.Accounts.LoanAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.LoanAccountManager.DeleteAllLoanAccountDataByAccountID(MOD.Data.DataHelper.GetGuid(accountID, MOD.Data.DefaultValue.Guid));
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
		/// <summary>This web service method deletes all LoanAccount data by a key.</summary>
		///
		/// <param name="accountSubTypeCode">A key for LoanAccount items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.LoanAccountResults DeleteAllLoanAccountDataByAccountSubTypeCode(int accountSubTypeCode)
		{
			Components.Accounts.LoanAccountResults results = new Components.Accounts.LoanAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.LoanAccountManager.DeleteAllLoanAccountDataByAccountSubTypeCode(accountSubTypeCode);
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
		/// <summary>This web service method deletes all LoanAccount data by a key.</summary>
		///
		/// <param name="currencyCode">A key for LoanAccount items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.LoanAccountResults DeleteAllLoanAccountDataByCurrencyCode(int currencyCode)
		{
			Components.Accounts.LoanAccountResults results = new Components.Accounts.LoanAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.LoanAccountManager.DeleteAllLoanAccountDataByCurrencyCode(currencyCode);
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
		/// <summary>This web service method deletes all LoanAccount data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for LoanAccount items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.LoanAccountResults DeleteAllLoanAccountDataByMetaPartnerID(string metaPartnerID)
		{
			Components.Accounts.LoanAccountResults results = new Components.Accounts.LoanAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.LoanAccountManager.DeleteAllLoanAccountDataByMetaPartnerID(MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid));
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
		/// <summary>This web service method deletes LoanAccount data.</summary>
		///
		/// <param name="accountID">A property of LoanAccount item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.LoanAccountResults DeleteOneLoanAccount(string accountID)
		{
			Components.Accounts.LoanAccountResults results = new Components.Accounts.LoanAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.LoanAccount item = new BLL.Accounts.LoanAccount();
				item.AccountID = MOD.Data.DataHelper.GetGuid(accountID, MOD.Data.DefaultValue.Guid);
				BLL.Accounts.LoanAccountManager.DeleteOneLoanAccount(item, false);
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
		/// <summary>This web service method gets all LoanAccount data.</summary>
		///
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.LoanAccountResults GetAllLoanAccountData(string sortColumn, string sortDirection)
		{
			Components.Accounts.LoanAccountResults results = new Components.Accounts.LoanAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Accounts.LoanAccountManager.GetAllLoanAccountData(Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all LoanAccount data by a key.</summary>
		///
		/// <param name="accountID">A key for LoanAccount items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.LoanAccountResults GetAllLoanAccountDataByAccountID(string accountID, string sortColumn, string sortDirection)
		{
			Components.Accounts.LoanAccountResults results = new Components.Accounts.LoanAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Accounts.LoanAccountManager.GetAllLoanAccountDataByAccountID(MOD.Data.DataHelper.GetGuid(accountID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all LoanAccount data by a key.</summary>
		///
		/// <param name="accountSubTypeCode">A key for LoanAccount items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.LoanAccountResults GetAllLoanAccountDataByAccountSubTypeCode(string accountSubTypeCode, string sortColumn, string sortDirection)
		{
			Components.Accounts.LoanAccountResults results = new Components.Accounts.LoanAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Accounts.LoanAccountManager.GetAllLoanAccountDataByAccountSubTypeCode(MOD.Data.DataHelper.GetInt(accountSubTypeCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all LoanAccount data by criteria.</summary>
		///
		/// <param name="dueDateStart">A key for LoanAccount items to be fetched</param>
		/// <param name="dueDateEnd">A key for LoanAccount items to be fetched</param>
		/// <param name="accountName">A key for LoanAccount items to be fetched</param>
		/// <param name="currencyCode">A key for LoanAccount items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for LoanAccount items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for LoanAccount items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.LoanAccountResults GetAllLoanAccountDataByCriteria(string dueDateStart, string dueDateEnd, string accountName, string currencyCode, string lastModifiedDateStart, string lastModifiedDateEnd, string sortColumn, string sortDirection)
		{
			Components.Accounts.LoanAccountResults results = new Components.Accounts.LoanAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Accounts.LoanAccountManager.GetAllLoanAccountDataByCriteria(MOD.Data.SearchHelper.GetDateTime(dueDateStart), MOD.Data.SearchHelper.GetDateTime(dueDateEnd), MOD.Data.SearchHelper.GetString(accountName), MOD.Data.SearchHelper.GetInt(currencyCode), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateStart), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateEnd), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all LoanAccount data by a key.</summary>
		///
		/// <param name="currencyCode">A key for LoanAccount items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.LoanAccountResults GetAllLoanAccountDataByCurrencyCode(string currencyCode, string sortColumn, string sortDirection)
		{
			Components.Accounts.LoanAccountResults results = new Components.Accounts.LoanAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Accounts.LoanAccountManager.GetAllLoanAccountDataByCurrencyCode(MOD.Data.DataHelper.GetInt(currencyCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all LoanAccount data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for LoanAccount items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.LoanAccountResults GetAllLoanAccountDataByMetaPartnerID(string metaPartnerID, string sortColumn, string sortDirection)
		{
			Components.Accounts.LoanAccountResults results = new Components.Accounts.LoanAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Accounts.LoanAccountManager.GetAllLoanAccountDataByMetaPartnerID(MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all LoanAccount data by criteria.</summary>
		///
		/// <param name="dueDateStart">A key for LoanAccount items to be fetched</param>
		/// <param name="dueDateEnd">A key for LoanAccount items to be fetched</param>
		/// <param name="accountName">A key for LoanAccount items to be fetched</param>
		/// <param name="currencyCode">A key for LoanAccount items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for LoanAccount items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for LoanAccount items to be fetched</param>
         /// <param name="startIndex">Start Index (beginning at 1)</param>
         /// <param name="pageSize">Page Size</param>
         /// <param name="maximumListSize">Maximum List Size</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.LoanAccountResults GetManyLoanAccountDataByCriteria(string dueDateStart, string dueDateEnd, string accountName, string currencyCode, string lastModifiedDateStart, string lastModifiedDateEnd, int startIndex, int pageSize, int maximumListSize, string sortColumn, string sortDirection)
		{
			Components.Accounts.LoanAccountResults results = new Components.Accounts.LoanAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				int totalRecords = 0;
				bool maximumListSizeExceeded = false;
				results.Results = BLL.Accounts.LoanAccountManager.GetManyLoanAccountDataByCriteria(MOD.Data.SearchHelper.GetDateTime(dueDateStart), MOD.Data.SearchHelper.GetDateTime(dueDateEnd), MOD.Data.SearchHelper.GetString(accountName), MOD.Data.SearchHelper.GetInt(currencyCode), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateStart), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateEnd), out totalRecords, out maximumListSizeExceeded, Globals.getDataOptions(sortColumn, sortDirection, startIndex, pageSize, maximumListSize));
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
		/// <summary>This web service method gets a single LoanAccount by an index.</summary>
		///
		/// <param name="accountID">The index for LoanAccount to be fetched</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.LoanAccountResults GetOneLoanAccount(string accountID, string sortColumn, string sortDirection)
		{
			Components.Accounts.LoanAccountResults results = new Components.Accounts.LoanAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.LoanAccount item =  BLL.Accounts.LoanAccountManager.GetOneLoanAccount(MOD.Data.DataHelper.GetGuid(accountID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
				// populate desired collections with lazy loading
				bool isAccessed = true;
				isAccessed = item.LoanToMetaPartnerList.IsDirty;
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
		/// <summary>This web service method updates LoanAccount data.</summary>
		///
		/// <param name="accountID">A property of LoanAccount item to be managed</param>
		/// <param name="loanAmount">A property of LoanAccount item to be managed</param>
		/// <param name="outstandingAmount">A property of LoanAccount item to be managed</param>
		/// <param name="dueDate">A property of LoanAccount item to be managed</param>
		/// <param name="loanRate">A property of LoanAccount item to be managed</param>
		/// <param name="metaPartnerID">A property of LoanAccount item to be managed</param>
		/// <param name="accountName">A property of LoanAccount item to be managed</param>
		/// <param name="accountSubTypeCode">A property of LoanAccount item to be managed</param>
		/// <param name="currencyCode">A property of LoanAccount item to be managed</param>
		/// <param name="description">A property of LoanAccount item to be managed</param>
		/// <param name="isActive">A property of LoanAccount item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.LoanAccountResults UpdateOneLoanAccount(string accountID, decimal loanAmount, decimal outstandingAmount, string dueDate, float loanRate, string metaPartnerID, string accountName, int accountSubTypeCode, int currencyCode, string description, bool isActive)
		{
			Components.Accounts.LoanAccountResults results = new Components.Accounts.LoanAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.LoanAccount item = new BLL.Accounts.LoanAccount();
				item.AccountID = MOD.Data.DataHelper.GetGuid(accountID, MOD.Data.DefaultValue.Guid);
				item.LoanAmount = loanAmount;
				item.OutstandingAmount = outstandingAmount;
				item.DueDate = MOD.Data.DataHelper.GetDateTime(dueDate, System.DateTime.MinValue);
				item.LoanRate = loanRate;
				item.MetaPartnerID = MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid);
				item.AccountName = accountName;
				item.AccountSubTypeCode = accountSubTypeCode;
				item.CurrencyCode = currencyCode;
				item.Description = description;
				item.IsActive = isActive;
				BLL.Accounts.LoanAccountManager.UpdateOneLoanAccount(item, false);
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
		public LoanAccountManager()
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