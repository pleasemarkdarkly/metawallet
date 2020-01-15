
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
	/// <summary>This class is used to manage FundAccount related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public class FundAccountManager : System.Web.Services.WebService
	{
		#region "Service Methods"
		// ------------------------------------------------------------------
		/// <summary>This web service method inserts FundAccount data.</summary>
		///
		/// <param name="accountID">A property of FundAccount item to be managed</param>
		/// <param name="startDate">A property of FundAccount item to be managed</param>
		/// <param name="endDate">A property of FundAccount item to be managed</param>
		/// <param name="fundCode">A property of FundAccount item to be managed</param>
		/// <param name="targetAmount">A property of FundAccount item to be managed</param>
		/// <param name="minimumDonationAmount">A property of FundAccount item to be managed</param>
		/// <param name="maximumDonationAmount">A property of FundAccount item to be managed</param>
		/// <param name="donatedAmount">A property of FundAccount item to be managed</param>
		/// <param name="isPublic">A property of FundAccount item to be managed</param>
		/// <param name="fundAccountTypeCode">A property of FundAccount item to be managed</param>
		/// <param name="frequencyCode">A property of FundAccount item to be managed</param>
		/// <param name="metaPartnerID">A property of FundAccount item to be managed</param>
		/// <param name="accountName">A property of FundAccount item to be managed</param>
		/// <param name="accountSubTypeCode">A property of FundAccount item to be managed</param>
		/// <param name="currencyCode">A property of FundAccount item to be managed</param>
		/// <param name="description">A property of FundAccount item to be managed</param>
		/// <param name="isActive">A property of FundAccount item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.FundAccountResults AddOneFundAccount(string accountID, string startDate, string endDate, string fundCode, decimal targetAmount, decimal minimumDonationAmount, decimal maximumDonationAmount, decimal donatedAmount, bool isPublic, int fundAccountTypeCode, int frequencyCode, string metaPartnerID, string accountName, int accountSubTypeCode, int currencyCode, string description, bool isActive)
		{
			Components.Accounts.FundAccountResults results = new Components.Accounts.FundAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.FundAccount item = new BLL.Accounts.FundAccount();
				item.AccountID = MOD.Data.DataHelper.GetGuid(accountID, MOD.Data.DefaultValue.Guid);
				item.StartDate = MOD.Data.DataHelper.GetDateTime(startDate, System.DateTime.MinValue);
				item.EndDate = MOD.Data.DataHelper.GetDateTime(endDate, System.DateTime.MinValue);
				item.FundCode = fundCode;
				item.TargetAmount = targetAmount;
				item.MinimumDonationAmount = minimumDonationAmount;
				item.MaximumDonationAmount = maximumDonationAmount;
				item.DonatedAmount = donatedAmount;
				item.IsPublic = isPublic;
				item.FundAccountTypeCode = fundAccountTypeCode;
				item.FrequencyCode = frequencyCode;
				item.MetaPartnerID = MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid);
				item.AccountName = accountName;
				item.AccountSubTypeCode = accountSubTypeCode;
				item.CurrencyCode = currencyCode;
				item.Description = description;
				item.IsActive = isActive;
				BLL.Accounts.FundAccountManager.AddOneFundAccount(item, false);
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
		/// <summary>This web service method deletes all FundAccount data by a key.</summary>
		///
		/// <param name="accountID">A key for FundAccount items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.FundAccountResults DeleteAllFundAccountDataByAccountID(string accountID)
		{
			Components.Accounts.FundAccountResults results = new Components.Accounts.FundAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.FundAccountManager.DeleteAllFundAccountDataByAccountID(MOD.Data.DataHelper.GetGuid(accountID, MOD.Data.DefaultValue.Guid));
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
		/// <summary>This web service method deletes all FundAccount data by a key.</summary>
		///
		/// <param name="accountSubTypeCode">A key for FundAccount items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.FundAccountResults DeleteAllFundAccountDataByAccountSubTypeCode(int accountSubTypeCode)
		{
			Components.Accounts.FundAccountResults results = new Components.Accounts.FundAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.FundAccountManager.DeleteAllFundAccountDataByAccountSubTypeCode(accountSubTypeCode);
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
		/// <summary>This web service method deletes all FundAccount data by a key.</summary>
		///
		/// <param name="currencyCode">A key for FundAccount items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.FundAccountResults DeleteAllFundAccountDataByCurrencyCode(int currencyCode)
		{
			Components.Accounts.FundAccountResults results = new Components.Accounts.FundAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.FundAccountManager.DeleteAllFundAccountDataByCurrencyCode(currencyCode);
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
		/// <summary>This web service method deletes all FundAccount data by a key.</summary>
		///
		/// <param name="frequencyCode">A key for FundAccount items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.FundAccountResults DeleteAllFundAccountDataByFrequencyCode(int frequencyCode)
		{
			Components.Accounts.FundAccountResults results = new Components.Accounts.FundAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.FundAccountManager.DeleteAllFundAccountDataByFrequencyCode(frequencyCode);
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
		/// <summary>This web service method deletes all FundAccount data by a key.</summary>
		///
		/// <param name="fundAccountTypeCode">A key for FundAccount items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.FundAccountResults DeleteAllFundAccountDataByFundAccountTypeCode(int fundAccountTypeCode)
		{
			Components.Accounts.FundAccountResults results = new Components.Accounts.FundAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.FundAccountManager.DeleteAllFundAccountDataByFundAccountTypeCode(fundAccountTypeCode);
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
		/// <summary>This web service method deletes all FundAccount data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for FundAccount items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.FundAccountResults DeleteAllFundAccountDataByMetaPartnerID(string metaPartnerID)
		{
			Components.Accounts.FundAccountResults results = new Components.Accounts.FundAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.FundAccountManager.DeleteAllFundAccountDataByMetaPartnerID(MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid));
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
		/// <summary>This web service method deletes FundAccount data.</summary>
		///
		/// <param name="accountID">A property of FundAccount item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.FundAccountResults DeleteOneFundAccount(string accountID)
		{
			Components.Accounts.FundAccountResults results = new Components.Accounts.FundAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.FundAccount item = new BLL.Accounts.FundAccount();
				item.AccountID = MOD.Data.DataHelper.GetGuid(accountID, MOD.Data.DefaultValue.Guid);
				BLL.Accounts.FundAccountManager.DeleteOneFundAccount(item, false);
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
		/// <summary>This web service method gets all FundAccount data.</summary>
		///
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.FundAccountResults GetAllFundAccountData(string sortColumn, string sortDirection)
		{
			Components.Accounts.FundAccountResults results = new Components.Accounts.FundAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Accounts.FundAccountManager.GetAllFundAccountData(Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all FundAccount data by a key.</summary>
		///
		/// <param name="accountID">A key for FundAccount items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.FundAccountResults GetAllFundAccountDataByAccountID(string accountID, string sortColumn, string sortDirection)
		{
			Components.Accounts.FundAccountResults results = new Components.Accounts.FundAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Accounts.FundAccountManager.GetAllFundAccountDataByAccountID(MOD.Data.DataHelper.GetGuid(accountID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all FundAccount data by a key.</summary>
		///
		/// <param name="accountSubTypeCode">A key for FundAccount items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.FundAccountResults GetAllFundAccountDataByAccountSubTypeCode(string accountSubTypeCode, string sortColumn, string sortDirection)
		{
			Components.Accounts.FundAccountResults results = new Components.Accounts.FundAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Accounts.FundAccountManager.GetAllFundAccountDataByAccountSubTypeCode(MOD.Data.DataHelper.GetInt(accountSubTypeCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all FundAccount data by criteria.</summary>
		///
		/// <param name="startDate">A key for FundAccount items to be fetched</param>
		/// <param name="endDate">A key for FundAccount items to be fetched</param>
		/// <param name="fundAccountTypeCode">A key for FundAccount items to be fetched</param>
		/// <param name="frequencyCode">A key for FundAccount items to be fetched</param>
		/// <param name="accountName">A key for FundAccount items to be fetched</param>
		/// <param name="currencyCode">A key for FundAccount items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for FundAccount items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for FundAccount items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.FundAccountResults GetAllFundAccountDataByCriteria(string startDate, string endDate, string fundAccountTypeCode, string frequencyCode, string accountName, string currencyCode, string lastModifiedDateStart, string lastModifiedDateEnd, string sortColumn, string sortDirection)
		{
			Components.Accounts.FundAccountResults results = new Components.Accounts.FundAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Accounts.FundAccountManager.GetAllFundAccountDataByCriteria(MOD.Data.SearchHelper.GetDateTime(startDate), MOD.Data.SearchHelper.GetDateTime(endDate), MOD.Data.SearchHelper.GetInt(fundAccountTypeCode), MOD.Data.SearchHelper.GetInt(frequencyCode), MOD.Data.SearchHelper.GetString(accountName), MOD.Data.SearchHelper.GetInt(currencyCode), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateStart), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateEnd), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all FundAccount data by a key.</summary>
		///
		/// <param name="currencyCode">A key for FundAccount items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.FundAccountResults GetAllFundAccountDataByCurrencyCode(string currencyCode, string sortColumn, string sortDirection)
		{
			Components.Accounts.FundAccountResults results = new Components.Accounts.FundAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Accounts.FundAccountManager.GetAllFundAccountDataByCurrencyCode(MOD.Data.DataHelper.GetInt(currencyCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all FundAccount data by a key.</summary>
		///
		/// <param name="frequencyCode">A key for FundAccount items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.FundAccountResults GetAllFundAccountDataByFrequencyCode(string frequencyCode, string sortColumn, string sortDirection)
		{
			Components.Accounts.FundAccountResults results = new Components.Accounts.FundAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Accounts.FundAccountManager.GetAllFundAccountDataByFrequencyCode(MOD.Data.DataHelper.GetInt(frequencyCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all FundAccount data by a key.</summary>
		///
		/// <param name="fundAccountTypeCode">A key for FundAccount items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.FundAccountResults GetAllFundAccountDataByFundAccountTypeCode(string fundAccountTypeCode, string sortColumn, string sortDirection)
		{
			Components.Accounts.FundAccountResults results = new Components.Accounts.FundAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Accounts.FundAccountManager.GetAllFundAccountDataByFundAccountTypeCode(MOD.Data.DataHelper.GetInt(fundAccountTypeCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all FundAccount data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for FundAccount items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.FundAccountResults GetAllFundAccountDataByMetaPartnerID(string metaPartnerID, string sortColumn, string sortDirection)
		{
			Components.Accounts.FundAccountResults results = new Components.Accounts.FundAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Accounts.FundAccountManager.GetAllFundAccountDataByMetaPartnerID(MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all FundAccount data by criteria.</summary>
		///
		/// <param name="startDate">A key for FundAccount items to be fetched</param>
		/// <param name="endDate">A key for FundAccount items to be fetched</param>
		/// <param name="fundAccountTypeCode">A key for FundAccount items to be fetched</param>
		/// <param name="frequencyCode">A key for FundAccount items to be fetched</param>
		/// <param name="accountName">A key for FundAccount items to be fetched</param>
		/// <param name="currencyCode">A key for FundAccount items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for FundAccount items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for FundAccount items to be fetched</param>
         /// <param name="startIndex">Start Index (beginning at 1)</param>
         /// <param name="pageSize">Page Size</param>
         /// <param name="maximumListSize">Maximum List Size</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.FundAccountResults GetManyFundAccountDataByCriteria(string startDate, string endDate, string fundAccountTypeCode, string frequencyCode, string accountName, string currencyCode, string lastModifiedDateStart, string lastModifiedDateEnd, int startIndex, int pageSize, int maximumListSize, string sortColumn, string sortDirection)
		{
			Components.Accounts.FundAccountResults results = new Components.Accounts.FundAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				int totalRecords = 0;
				bool maximumListSizeExceeded = false;
				results.Results = BLL.Accounts.FundAccountManager.GetManyFundAccountDataByCriteria(MOD.Data.SearchHelper.GetDateTime(startDate), MOD.Data.SearchHelper.GetDateTime(endDate), MOD.Data.SearchHelper.GetInt(fundAccountTypeCode), MOD.Data.SearchHelper.GetInt(frequencyCode), MOD.Data.SearchHelper.GetString(accountName), MOD.Data.SearchHelper.GetInt(currencyCode), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateStart), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateEnd), out totalRecords, out maximumListSizeExceeded, Globals.getDataOptions(sortColumn, sortDirection, startIndex, pageSize, maximumListSize));
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
		/// <summary>This web service method gets a single FundAccount by an index.</summary>
		///
		/// <param name="accountID">The index for FundAccount to be fetched</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.FundAccountResults GetOneFundAccount(string accountID, string sortColumn, string sortDirection)
		{
			Components.Accounts.FundAccountResults results = new Components.Accounts.FundAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.FundAccount item =  BLL.Accounts.FundAccountManager.GetOneFundAccount(MOD.Data.DataHelper.GetGuid(accountID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method updates FundAccount data.</summary>
		///
		/// <param name="accountID">A property of FundAccount item to be managed</param>
		/// <param name="startDate">A property of FundAccount item to be managed</param>
		/// <param name="endDate">A property of FundAccount item to be managed</param>
		/// <param name="fundCode">A property of FundAccount item to be managed</param>
		/// <param name="targetAmount">A property of FundAccount item to be managed</param>
		/// <param name="minimumDonationAmount">A property of FundAccount item to be managed</param>
		/// <param name="maximumDonationAmount">A property of FundAccount item to be managed</param>
		/// <param name="donatedAmount">A property of FundAccount item to be managed</param>
		/// <param name="isPublic">A property of FundAccount item to be managed</param>
		/// <param name="fundAccountTypeCode">A property of FundAccount item to be managed</param>
		/// <param name="frequencyCode">A property of FundAccount item to be managed</param>
		/// <param name="metaPartnerID">A property of FundAccount item to be managed</param>
		/// <param name="accountName">A property of FundAccount item to be managed</param>
		/// <param name="accountSubTypeCode">A property of FundAccount item to be managed</param>
		/// <param name="currencyCode">A property of FundAccount item to be managed</param>
		/// <param name="description">A property of FundAccount item to be managed</param>
		/// <param name="isActive">A property of FundAccount item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.FundAccountResults UpdateOneFundAccount(string accountID, string startDate, string endDate, string fundCode, decimal targetAmount, decimal minimumDonationAmount, decimal maximumDonationAmount, decimal donatedAmount, bool isPublic, int fundAccountTypeCode, int frequencyCode, string metaPartnerID, string accountName, int accountSubTypeCode, int currencyCode, string description, bool isActive)
		{
			Components.Accounts.FundAccountResults results = new Components.Accounts.FundAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.FundAccount item = new BLL.Accounts.FundAccount();
				item.AccountID = MOD.Data.DataHelper.GetGuid(accountID, MOD.Data.DefaultValue.Guid);
				item.StartDate = MOD.Data.DataHelper.GetDateTime(startDate, System.DateTime.MinValue);
				item.EndDate = MOD.Data.DataHelper.GetDateTime(endDate, System.DateTime.MinValue);
				item.FundCode = fundCode;
				item.TargetAmount = targetAmount;
				item.MinimumDonationAmount = minimumDonationAmount;
				item.MaximumDonationAmount = maximumDonationAmount;
				item.DonatedAmount = donatedAmount;
				item.IsPublic = isPublic;
				item.FundAccountTypeCode = fundAccountTypeCode;
				item.FrequencyCode = frequencyCode;
				item.MetaPartnerID = MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid);
				item.AccountName = accountName;
				item.AccountSubTypeCode = accountSubTypeCode;
				item.CurrencyCode = currencyCode;
				item.Description = description;
				item.IsActive = isActive;
				BLL.Accounts.FundAccountManager.UpdateOneFundAccount(item, false);
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
		public FundAccountManager()
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