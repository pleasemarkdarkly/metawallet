
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
	/// <summary>This class is used to manage CreditAccount related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public class CreditAccountManager : System.Web.Services.WebService
	{
		#region "Service Methods"
		// ------------------------------------------------------------------
		/// <summary>This web service method inserts CreditAccount data.</summary>
		///
		/// <param name="accountID">A property of CreditAccount item to be managed</param>
		/// <param name="creditCardNumber">A property of CreditAccount item to be managed</param>
		/// <param name="creditCardLastFour">A property of CreditAccount item to be managed</param>
		/// <param name="creditCardName">A property of CreditAccount item to be managed</param>
		/// <param name="expirationDate">A property of CreditAccount item to be managed</param>
		/// <param name="creditCardTypeCode">A property of CreditAccount item to be managed</param>
		/// <param name="metaPartnerID">A property of CreditAccount item to be managed</param>
		/// <param name="accountName">A property of CreditAccount item to be managed</param>
		/// <param name="accountSubTypeCode">A property of CreditAccount item to be managed</param>
		/// <param name="currencyCode">A property of CreditAccount item to be managed</param>
		/// <param name="description">A property of CreditAccount item to be managed</param>
		/// <param name="isActive">A property of CreditAccount item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.CreditAccountResults AddOneCreditAccount(string accountID, string creditCardNumber, string creditCardLastFour, string creditCardName, string expirationDate, int creditCardTypeCode, string metaPartnerID, string accountName, int accountSubTypeCode, int currencyCode, string description, bool isActive)
		{
			Components.Accounts.CreditAccountResults results = new Components.Accounts.CreditAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.CreditAccount item = new BLL.Accounts.CreditAccount();
				item.AccountID = MOD.Data.DataHelper.GetGuid(accountID, MOD.Data.DefaultValue.Guid);
				item.CreditCardNumber = creditCardNumber;
				item.CreditCardLastFour = creditCardLastFour;
				item.CreditCardName = creditCardName;
				item.ExpirationDate = MOD.Data.DataHelper.GetDateTime(expirationDate, System.DateTime.MinValue);
				item.CreditCardTypeCode = creditCardTypeCode;
				item.MetaPartnerID = MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid);
				item.AccountName = accountName;
				item.AccountSubTypeCode = accountSubTypeCode;
				item.CurrencyCode = currencyCode;
				item.Description = description;
				item.IsActive = isActive;
				BLL.Accounts.CreditAccountManager.AddOneCreditAccount(item, false);
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
		/// <summary>This web service method deletes all CreditAccount data by a key.</summary>
		///
		/// <param name="accountID">A key for CreditAccount items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.CreditAccountResults DeleteAllCreditAccountDataByAccountID(string accountID)
		{
			Components.Accounts.CreditAccountResults results = new Components.Accounts.CreditAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.CreditAccountManager.DeleteAllCreditAccountDataByAccountID(MOD.Data.DataHelper.GetGuid(accountID, MOD.Data.DefaultValue.Guid));
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
		/// <summary>This web service method deletes all CreditAccount data by a key.</summary>
		///
		/// <param name="accountSubTypeCode">A key for CreditAccount items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.CreditAccountResults DeleteAllCreditAccountDataByAccountSubTypeCode(int accountSubTypeCode)
		{
			Components.Accounts.CreditAccountResults results = new Components.Accounts.CreditAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.CreditAccountManager.DeleteAllCreditAccountDataByAccountSubTypeCode(accountSubTypeCode);
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
		/// <summary>This web service method deletes all CreditAccount data by a key.</summary>
		///
		/// <param name="creditCardTypeCode">A key for CreditAccount items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.CreditAccountResults DeleteAllCreditAccountDataByCreditCardTypeCode(int creditCardTypeCode)
		{
			Components.Accounts.CreditAccountResults results = new Components.Accounts.CreditAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.CreditAccountManager.DeleteAllCreditAccountDataByCreditCardTypeCode(creditCardTypeCode);
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
		/// <summary>This web service method deletes all CreditAccount data by a key.</summary>
		///
		/// <param name="currencyCode">A key for CreditAccount items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.CreditAccountResults DeleteAllCreditAccountDataByCurrencyCode(int currencyCode)
		{
			Components.Accounts.CreditAccountResults results = new Components.Accounts.CreditAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.CreditAccountManager.DeleteAllCreditAccountDataByCurrencyCode(currencyCode);
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
		/// <summary>This web service method deletes all CreditAccount data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for CreditAccount items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.CreditAccountResults DeleteAllCreditAccountDataByMetaPartnerID(string metaPartnerID)
		{
			Components.Accounts.CreditAccountResults results = new Components.Accounts.CreditAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.CreditAccountManager.DeleteAllCreditAccountDataByMetaPartnerID(MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid));
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
		/// <summary>This web service method deletes CreditAccount data.</summary>
		///
		/// <param name="accountID">A property of CreditAccount item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.CreditAccountResults DeleteOneCreditAccount(string accountID)
		{
			Components.Accounts.CreditAccountResults results = new Components.Accounts.CreditAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.CreditAccount item = new BLL.Accounts.CreditAccount();
				item.AccountID = MOD.Data.DataHelper.GetGuid(accountID, MOD.Data.DefaultValue.Guid);
				BLL.Accounts.CreditAccountManager.DeleteOneCreditAccount(item, false);
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
		/// <summary>This web service method gets all CreditAccount data.</summary>
		///
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.CreditAccountResults GetAllCreditAccountData(string sortColumn, string sortDirection)
		{
			Components.Accounts.CreditAccountResults results = new Components.Accounts.CreditAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Accounts.CreditAccountManager.GetAllCreditAccountData(Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all CreditAccount data by a key.</summary>
		///
		/// <param name="accountID">A key for CreditAccount items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.CreditAccountResults GetAllCreditAccountDataByAccountID(string accountID, string sortColumn, string sortDirection)
		{
			Components.Accounts.CreditAccountResults results = new Components.Accounts.CreditAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Accounts.CreditAccountManager.GetAllCreditAccountDataByAccountID(MOD.Data.DataHelper.GetGuid(accountID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all CreditAccount data by a key.</summary>
		///
		/// <param name="accountSubTypeCode">A key for CreditAccount items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.CreditAccountResults GetAllCreditAccountDataByAccountSubTypeCode(string accountSubTypeCode, string sortColumn, string sortDirection)
		{
			Components.Accounts.CreditAccountResults results = new Components.Accounts.CreditAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Accounts.CreditAccountManager.GetAllCreditAccountDataByAccountSubTypeCode(MOD.Data.DataHelper.GetInt(accountSubTypeCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all CreditAccount data by a key.</summary>
		///
		/// <param name="creditCardTypeCode">A key for CreditAccount items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.CreditAccountResults GetAllCreditAccountDataByCreditCardTypeCode(string creditCardTypeCode, string sortColumn, string sortDirection)
		{
			Components.Accounts.CreditAccountResults results = new Components.Accounts.CreditAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Accounts.CreditAccountManager.GetAllCreditAccountDataByCreditCardTypeCode(MOD.Data.DataHelper.GetInt(creditCardTypeCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all CreditAccount data by criteria.</summary>
		///
		/// <param name="creditCardNumber">A key for CreditAccount items to be fetched</param>
		/// <param name="creditCardName">A key for CreditAccount items to be fetched</param>
		/// <param name="expirationDateStart">A key for CreditAccount items to be fetched</param>
		/// <param name="expirationDateEnd">A key for CreditAccount items to be fetched</param>
		/// <param name="creditCardTypeCode">A key for CreditAccount items to be fetched</param>
		/// <param name="accountName">A key for CreditAccount items to be fetched</param>
		/// <param name="currencyCode">A key for CreditAccount items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for CreditAccount items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for CreditAccount items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.CreditAccountResults GetAllCreditAccountDataByCriteria(string creditCardNumber, string creditCardName, string expirationDateStart, string expirationDateEnd, string creditCardTypeCode, string accountName, string currencyCode, string lastModifiedDateStart, string lastModifiedDateEnd, string sortColumn, string sortDirection)
		{
			Components.Accounts.CreditAccountResults results = new Components.Accounts.CreditAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Accounts.CreditAccountManager.GetAllCreditAccountDataByCriteria(MOD.Data.SearchHelper.GetString(creditCardNumber), MOD.Data.SearchHelper.GetString(creditCardName), MOD.Data.SearchHelper.GetDateTime(expirationDateStart), MOD.Data.SearchHelper.GetDateTime(expirationDateEnd), MOD.Data.SearchHelper.GetInt(creditCardTypeCode), MOD.Data.SearchHelper.GetString(accountName), MOD.Data.SearchHelper.GetInt(currencyCode), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateStart), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateEnd), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all CreditAccount data by a key.</summary>
		///
		/// <param name="currencyCode">A key for CreditAccount items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.CreditAccountResults GetAllCreditAccountDataByCurrencyCode(string currencyCode, string sortColumn, string sortDirection)
		{
			Components.Accounts.CreditAccountResults results = new Components.Accounts.CreditAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Accounts.CreditAccountManager.GetAllCreditAccountDataByCurrencyCode(MOD.Data.DataHelper.GetInt(currencyCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all CreditAccount data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for CreditAccount items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.CreditAccountResults GetAllCreditAccountDataByMetaPartnerID(string metaPartnerID, string sortColumn, string sortDirection)
		{
			Components.Accounts.CreditAccountResults results = new Components.Accounts.CreditAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Accounts.CreditAccountManager.GetAllCreditAccountDataByMetaPartnerID(MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all CreditAccount data by criteria.</summary>
		///
		/// <param name="creditCardNumber">A key for CreditAccount items to be fetched</param>
		/// <param name="creditCardName">A key for CreditAccount items to be fetched</param>
		/// <param name="expirationDateStart">A key for CreditAccount items to be fetched</param>
		/// <param name="expirationDateEnd">A key for CreditAccount items to be fetched</param>
		/// <param name="creditCardTypeCode">A key for CreditAccount items to be fetched</param>
		/// <param name="accountName">A key for CreditAccount items to be fetched</param>
		/// <param name="currencyCode">A key for CreditAccount items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for CreditAccount items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for CreditAccount items to be fetched</param>
         /// <param name="startIndex">Start Index (beginning at 1)</param>
         /// <param name="pageSize">Page Size</param>
         /// <param name="maximumListSize">Maximum List Size</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.CreditAccountResults GetManyCreditAccountDataByCriteria(string creditCardNumber, string creditCardName, string expirationDateStart, string expirationDateEnd, string creditCardTypeCode, string accountName, string currencyCode, string lastModifiedDateStart, string lastModifiedDateEnd, int startIndex, int pageSize, int maximumListSize, string sortColumn, string sortDirection)
		{
			Components.Accounts.CreditAccountResults results = new Components.Accounts.CreditAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				int totalRecords = 0;
				bool maximumListSizeExceeded = false;
				results.Results = BLL.Accounts.CreditAccountManager.GetManyCreditAccountDataByCriteria(MOD.Data.SearchHelper.GetString(creditCardNumber), MOD.Data.SearchHelper.GetString(creditCardName), MOD.Data.SearchHelper.GetDateTime(expirationDateStart), MOD.Data.SearchHelper.GetDateTime(expirationDateEnd), MOD.Data.SearchHelper.GetInt(creditCardTypeCode), MOD.Data.SearchHelper.GetString(accountName), MOD.Data.SearchHelper.GetInt(currencyCode), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateStart), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateEnd), out totalRecords, out maximumListSizeExceeded, Globals.getDataOptions(sortColumn, sortDirection, startIndex, pageSize, maximumListSize));
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
		/// <summary>This web service method gets a single CreditAccount by an index.</summary>
		///
		/// <param name="accountID">The index for CreditAccount to be fetched</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.CreditAccountResults GetOneCreditAccount(string accountID, string sortColumn, string sortDirection)
		{
			Components.Accounts.CreditAccountResults results = new Components.Accounts.CreditAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.CreditAccount item =  BLL.Accounts.CreditAccountManager.GetOneCreditAccount(MOD.Data.DataHelper.GetGuid(accountID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method updates CreditAccount data.</summary>
		///
		/// <param name="accountID">A property of CreditAccount item to be managed</param>
		/// <param name="creditCardNumber">A property of CreditAccount item to be managed</param>
		/// <param name="creditCardLastFour">A property of CreditAccount item to be managed</param>
		/// <param name="creditCardName">A property of CreditAccount item to be managed</param>
		/// <param name="expirationDate">A property of CreditAccount item to be managed</param>
		/// <param name="creditCardTypeCode">A property of CreditAccount item to be managed</param>
		/// <param name="metaPartnerID">A property of CreditAccount item to be managed</param>
		/// <param name="accountName">A property of CreditAccount item to be managed</param>
		/// <param name="accountSubTypeCode">A property of CreditAccount item to be managed</param>
		/// <param name="currencyCode">A property of CreditAccount item to be managed</param>
		/// <param name="description">A property of CreditAccount item to be managed</param>
		/// <param name="isActive">A property of CreditAccount item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.CreditAccountResults UpdateOneCreditAccount(string accountID, string creditCardNumber, string creditCardLastFour, string creditCardName, string expirationDate, int creditCardTypeCode, string metaPartnerID, string accountName, int accountSubTypeCode, int currencyCode, string description, bool isActive)
		{
			Components.Accounts.CreditAccountResults results = new Components.Accounts.CreditAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.CreditAccount item = new BLL.Accounts.CreditAccount();
				item.AccountID = MOD.Data.DataHelper.GetGuid(accountID, MOD.Data.DefaultValue.Guid);
				item.CreditCardNumber = creditCardNumber;
				item.CreditCardLastFour = creditCardLastFour;
				item.CreditCardName = creditCardName;
				item.ExpirationDate = MOD.Data.DataHelper.GetDateTime(expirationDate, System.DateTime.MinValue);
				item.CreditCardTypeCode = creditCardTypeCode;
				item.MetaPartnerID = MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid);
				item.AccountName = accountName;
				item.AccountSubTypeCode = accountSubTypeCode;
				item.CurrencyCode = currencyCode;
				item.Description = description;
				item.IsActive = isActive;
				BLL.Accounts.CreditAccountManager.UpdateOneCreditAccount(item, false);
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
		public CreditAccountManager()
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