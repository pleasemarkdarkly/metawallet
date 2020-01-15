
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
	/// <summary>This class is used to manage BillPayAccount related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public class BillPayAccountManager : System.Web.Services.WebService
	{
		#region "Service Methods"
		// ------------------------------------------------------------------
		/// <summary>This web service method inserts BillPayAccount data.</summary>
		///
		/// <param name="accountID">A property of BillPayAccount item to be managed</param>
		/// <param name="businessAccountNumber">A property of BillPayAccount item to be managed</param>
		/// <param name="startDate">A property of BillPayAccount item to be managed</param>
		/// <param name="endDate">A property of BillPayAccount item to be managed</param>
		/// <param name="defaultMinimumPayment">A property of BillPayAccount item to be managed</param>
		/// <param name="defaultMaximumPayment">A property of BillPayAccount item to be managed</param>
		/// <param name="businessMetaPartnerID">A property of BillPayAccount item to be managed</param>
		/// <param name="hourOfDay">A property of BillPayAccount item to be managed</param>
		/// <param name="dayOfWeek">A property of BillPayAccount item to be managed</param>
		/// <param name="weekOfMonth">A property of BillPayAccount item to be managed</param>
		/// <param name="monthOfYear">A property of BillPayAccount item to be managed</param>
		/// <param name="numberOfReminders">A property of BillPayAccount item to be managed</param>
		/// <param name="frequencyCode">A property of BillPayAccount item to be managed</param>
		/// <param name="metaPartnerID">A property of BillPayAccount item to be managed</param>
		/// <param name="accountName">A property of BillPayAccount item to be managed</param>
		/// <param name="accountSubTypeCode">A property of BillPayAccount item to be managed</param>
		/// <param name="currencyCode">A property of BillPayAccount item to be managed</param>
		/// <param name="description">A property of BillPayAccount item to be managed</param>
		/// <param name="isActive">A property of BillPayAccount item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.BillPayAccountResults AddOneBillPayAccount(string accountID, string businessAccountNumber, string startDate, string endDate, decimal defaultMinimumPayment, decimal defaultMaximumPayment, string businessMetaPartnerID, int hourOfDay, int dayOfWeek, int weekOfMonth, int monthOfYear, int numberOfReminders, int frequencyCode, string metaPartnerID, string accountName, int accountSubTypeCode, int currencyCode, string description, bool isActive)
		{
			Components.Accounts.BillPayAccountResults results = new Components.Accounts.BillPayAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.BillPayAccount item = new BLL.Accounts.BillPayAccount();
				item.AccountID = MOD.Data.DataHelper.GetGuid(accountID, MOD.Data.DefaultValue.Guid);
				item.BusinessAccountNumber = businessAccountNumber;
				item.StartDate = MOD.Data.DataHelper.GetDateTime(startDate, System.DateTime.MinValue);
				item.EndDate = MOD.Data.DataHelper.GetDateTime(endDate, System.DateTime.MinValue);
				item.DefaultMinimumPayment = defaultMinimumPayment;
				item.DefaultMaximumPayment = defaultMaximumPayment;
				item.BusinessMetaPartnerID = MOD.Data.DataHelper.GetGuid(businessMetaPartnerID, MOD.Data.DefaultValue.Guid);
				item.HourOfDay = hourOfDay;
				item.DayOfWeek = dayOfWeek;
				item.WeekOfMonth = weekOfMonth;
				item.MonthOfYear = monthOfYear;
				item.NumberOfReminders = numberOfReminders;
				item.FrequencyCode = frequencyCode;
				item.MetaPartnerID = MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid);
				item.AccountName = accountName;
				item.AccountSubTypeCode = accountSubTypeCode;
				item.CurrencyCode = currencyCode;
				item.Description = description;
				item.IsActive = isActive;
				BLL.Accounts.BillPayAccountManager.AddOneBillPayAccount(item, false);
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
		/// <summary>This web service method deletes all BillPayAccount data by a key.</summary>
		///
		/// <param name="accountID">A key for BillPayAccount items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.BillPayAccountResults DeleteAllBillPayAccountDataByAccountID(string accountID)
		{
			Components.Accounts.BillPayAccountResults results = new Components.Accounts.BillPayAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.BillPayAccountManager.DeleteAllBillPayAccountDataByAccountID(MOD.Data.DataHelper.GetGuid(accountID, MOD.Data.DefaultValue.Guid));
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
		/// <summary>This web service method deletes all BillPayAccount data by a key.</summary>
		///
		/// <param name="accountSubTypeCode">A key for BillPayAccount items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.BillPayAccountResults DeleteAllBillPayAccountDataByAccountSubTypeCode(int accountSubTypeCode)
		{
			Components.Accounts.BillPayAccountResults results = new Components.Accounts.BillPayAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.BillPayAccountManager.DeleteAllBillPayAccountDataByAccountSubTypeCode(accountSubTypeCode);
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
		/// <summary>This web service method deletes all BillPayAccount data by a key.</summary>
		///
		/// <param name="businessMetaPartnerID">A key for BillPayAccount items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.BillPayAccountResults DeleteAllBillPayAccountDataByBusinessMetaPartnerID(string businessMetaPartnerID)
		{
			Components.Accounts.BillPayAccountResults results = new Components.Accounts.BillPayAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.BillPayAccountManager.DeleteAllBillPayAccountDataByBusinessMetaPartnerID(MOD.Data.DataHelper.GetGuid(businessMetaPartnerID, MOD.Data.DefaultValue.Guid));
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
		/// <summary>This web service method deletes all BillPayAccount data by a key.</summary>
		///
		/// <param name="currencyCode">A key for BillPayAccount items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.BillPayAccountResults DeleteAllBillPayAccountDataByCurrencyCode(int currencyCode)
		{
			Components.Accounts.BillPayAccountResults results = new Components.Accounts.BillPayAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.BillPayAccountManager.DeleteAllBillPayAccountDataByCurrencyCode(currencyCode);
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
		/// <summary>This web service method deletes all BillPayAccount data by a key.</summary>
		///
		/// <param name="frequencyCode">A key for BillPayAccount items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.BillPayAccountResults DeleteAllBillPayAccountDataByFrequencyCode(int frequencyCode)
		{
			Components.Accounts.BillPayAccountResults results = new Components.Accounts.BillPayAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.BillPayAccountManager.DeleteAllBillPayAccountDataByFrequencyCode(frequencyCode);
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
		/// <summary>This web service method deletes all BillPayAccount data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for BillPayAccount items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.BillPayAccountResults DeleteAllBillPayAccountDataByMetaPartnerID(string metaPartnerID)
		{
			Components.Accounts.BillPayAccountResults results = new Components.Accounts.BillPayAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.BillPayAccountManager.DeleteAllBillPayAccountDataByMetaPartnerID(MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid));
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
		/// <summary>This web service method deletes BillPayAccount data.</summary>
		///
		/// <param name="accountID">A property of BillPayAccount item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.BillPayAccountResults DeleteOneBillPayAccount(string accountID)
		{
			Components.Accounts.BillPayAccountResults results = new Components.Accounts.BillPayAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.BillPayAccount item = new BLL.Accounts.BillPayAccount();
				item.AccountID = MOD.Data.DataHelper.GetGuid(accountID, MOD.Data.DefaultValue.Guid);
				BLL.Accounts.BillPayAccountManager.DeleteOneBillPayAccount(item, false);
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
		/// <summary>This web service method gets all BillPayAccount data.</summary>
		///
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.BillPayAccountResults GetAllBillPayAccountData(string sortColumn, string sortDirection)
		{
			Components.Accounts.BillPayAccountResults results = new Components.Accounts.BillPayAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Accounts.BillPayAccountManager.GetAllBillPayAccountData(Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all BillPayAccount data by a key.</summary>
		///
		/// <param name="accountID">A key for BillPayAccount items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.BillPayAccountResults GetAllBillPayAccountDataByAccountID(string accountID, string sortColumn, string sortDirection)
		{
			Components.Accounts.BillPayAccountResults results = new Components.Accounts.BillPayAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Accounts.BillPayAccountManager.GetAllBillPayAccountDataByAccountID(MOD.Data.DataHelper.GetGuid(accountID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all BillPayAccount data by a key.</summary>
		///
		/// <param name="accountSubTypeCode">A key for BillPayAccount items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.BillPayAccountResults GetAllBillPayAccountDataByAccountSubTypeCode(string accountSubTypeCode, string sortColumn, string sortDirection)
		{
			Components.Accounts.BillPayAccountResults results = new Components.Accounts.BillPayAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Accounts.BillPayAccountManager.GetAllBillPayAccountDataByAccountSubTypeCode(MOD.Data.DataHelper.GetInt(accountSubTypeCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all BillPayAccount data by a key.</summary>
		///
		/// <param name="businessMetaPartnerID">A key for BillPayAccount items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.BillPayAccountResults GetAllBillPayAccountDataByBusinessMetaPartnerID(string businessMetaPartnerID, string sortColumn, string sortDirection)
		{
			Components.Accounts.BillPayAccountResults results = new Components.Accounts.BillPayAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Accounts.BillPayAccountManager.GetAllBillPayAccountDataByBusinessMetaPartnerID(MOD.Data.DataHelper.GetGuid(businessMetaPartnerID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all BillPayAccount data by criteria.</summary>
		///
		/// <param name="businessAccountNumber">A key for BillPayAccount items to be fetched</param>
		/// <param name="startDate">A key for BillPayAccount items to be fetched</param>
		/// <param name="endDate">A key for BillPayAccount items to be fetched</param>
		/// <param name="numberOfReminders">A key for BillPayAccount items to be fetched</param>
		/// <param name="frequencyCode">A key for BillPayAccount items to be fetched</param>
		/// <param name="accountName">A key for BillPayAccount items to be fetched</param>
		/// <param name="currencyCode">A key for BillPayAccount items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for BillPayAccount items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for BillPayAccount items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.BillPayAccountResults GetAllBillPayAccountDataByCriteria(string businessAccountNumber, string startDate, string endDate, string numberOfReminders, string frequencyCode, string accountName, string currencyCode, string lastModifiedDateStart, string lastModifiedDateEnd, string sortColumn, string sortDirection)
		{
			Components.Accounts.BillPayAccountResults results = new Components.Accounts.BillPayAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Accounts.BillPayAccountManager.GetAllBillPayAccountDataByCriteria(MOD.Data.SearchHelper.GetString(businessAccountNumber), MOD.Data.SearchHelper.GetDateTime(startDate), MOD.Data.SearchHelper.GetDateTime(endDate), MOD.Data.SearchHelper.GetInt(numberOfReminders), MOD.Data.SearchHelper.GetInt(frequencyCode), MOD.Data.SearchHelper.GetString(accountName), MOD.Data.SearchHelper.GetInt(currencyCode), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateStart), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateEnd), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all BillPayAccount data by a key.</summary>
		///
		/// <param name="currencyCode">A key for BillPayAccount items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.BillPayAccountResults GetAllBillPayAccountDataByCurrencyCode(string currencyCode, string sortColumn, string sortDirection)
		{
			Components.Accounts.BillPayAccountResults results = new Components.Accounts.BillPayAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Accounts.BillPayAccountManager.GetAllBillPayAccountDataByCurrencyCode(MOD.Data.DataHelper.GetInt(currencyCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all BillPayAccount data by a key.</summary>
		///
		/// <param name="frequencyCode">A key for BillPayAccount items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.BillPayAccountResults GetAllBillPayAccountDataByFrequencyCode(string frequencyCode, string sortColumn, string sortDirection)
		{
			Components.Accounts.BillPayAccountResults results = new Components.Accounts.BillPayAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Accounts.BillPayAccountManager.GetAllBillPayAccountDataByFrequencyCode(MOD.Data.DataHelper.GetInt(frequencyCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all BillPayAccount data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for BillPayAccount items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.BillPayAccountResults GetAllBillPayAccountDataByMetaPartnerID(string metaPartnerID, string sortColumn, string sortDirection)
		{
			Components.Accounts.BillPayAccountResults results = new Components.Accounts.BillPayAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Accounts.BillPayAccountManager.GetAllBillPayAccountDataByMetaPartnerID(MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all BillPayAccount data by criteria.</summary>
		///
		/// <param name="businessAccountNumber">A key for BillPayAccount items to be fetched</param>
		/// <param name="startDate">A key for BillPayAccount items to be fetched</param>
		/// <param name="endDate">A key for BillPayAccount items to be fetched</param>
		/// <param name="numberOfReminders">A key for BillPayAccount items to be fetched</param>
		/// <param name="frequencyCode">A key for BillPayAccount items to be fetched</param>
		/// <param name="accountName">A key for BillPayAccount items to be fetched</param>
		/// <param name="currencyCode">A key for BillPayAccount items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for BillPayAccount items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for BillPayAccount items to be fetched</param>
         /// <param name="startIndex">Start Index (beginning at 1)</param>
         /// <param name="pageSize">Page Size</param>
         /// <param name="maximumListSize">Maximum List Size</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.BillPayAccountResults GetManyBillPayAccountDataByCriteria(string businessAccountNumber, string startDate, string endDate, string numberOfReminders, string frequencyCode, string accountName, string currencyCode, string lastModifiedDateStart, string lastModifiedDateEnd, int startIndex, int pageSize, int maximumListSize, string sortColumn, string sortDirection)
		{
			Components.Accounts.BillPayAccountResults results = new Components.Accounts.BillPayAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				int totalRecords = 0;
				bool maximumListSizeExceeded = false;
				results.Results = BLL.Accounts.BillPayAccountManager.GetManyBillPayAccountDataByCriteria(MOD.Data.SearchHelper.GetString(businessAccountNumber), MOD.Data.SearchHelper.GetDateTime(startDate), MOD.Data.SearchHelper.GetDateTime(endDate), MOD.Data.SearchHelper.GetInt(numberOfReminders), MOD.Data.SearchHelper.GetInt(frequencyCode), MOD.Data.SearchHelper.GetString(accountName), MOD.Data.SearchHelper.GetInt(currencyCode), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateStart), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateEnd), out totalRecords, out maximumListSizeExceeded, Globals.getDataOptions(sortColumn, sortDirection, startIndex, pageSize, maximumListSize));
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
		/// <summary>This web service method gets a single BillPayAccount by an index.</summary>
		///
		/// <param name="accountID">The index for BillPayAccount to be fetched</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.BillPayAccountResults GetOneBillPayAccount(string accountID, string sortColumn, string sortDirection)
		{
			Components.Accounts.BillPayAccountResults results = new Components.Accounts.BillPayAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.BillPayAccount item =  BLL.Accounts.BillPayAccountManager.GetOneBillPayAccount(MOD.Data.DataHelper.GetGuid(accountID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method updates BillPayAccount data.</summary>
		///
		/// <param name="accountID">A property of BillPayAccount item to be managed</param>
		/// <param name="businessAccountNumber">A property of BillPayAccount item to be managed</param>
		/// <param name="startDate">A property of BillPayAccount item to be managed</param>
		/// <param name="endDate">A property of BillPayAccount item to be managed</param>
		/// <param name="defaultMinimumPayment">A property of BillPayAccount item to be managed</param>
		/// <param name="defaultMaximumPayment">A property of BillPayAccount item to be managed</param>
		/// <param name="businessMetaPartnerID">A property of BillPayAccount item to be managed</param>
		/// <param name="hourOfDay">A property of BillPayAccount item to be managed</param>
		/// <param name="dayOfWeek">A property of BillPayAccount item to be managed</param>
		/// <param name="weekOfMonth">A property of BillPayAccount item to be managed</param>
		/// <param name="monthOfYear">A property of BillPayAccount item to be managed</param>
		/// <param name="numberOfReminders">A property of BillPayAccount item to be managed</param>
		/// <param name="frequencyCode">A property of BillPayAccount item to be managed</param>
		/// <param name="metaPartnerID">A property of BillPayAccount item to be managed</param>
		/// <param name="accountName">A property of BillPayAccount item to be managed</param>
		/// <param name="accountSubTypeCode">A property of BillPayAccount item to be managed</param>
		/// <param name="currencyCode">A property of BillPayAccount item to be managed</param>
		/// <param name="description">A property of BillPayAccount item to be managed</param>
		/// <param name="isActive">A property of BillPayAccount item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.BillPayAccountResults UpdateOneBillPayAccount(string accountID, string businessAccountNumber, string startDate, string endDate, decimal defaultMinimumPayment, decimal defaultMaximumPayment, string businessMetaPartnerID, int hourOfDay, int dayOfWeek, int weekOfMonth, int monthOfYear, int numberOfReminders, int frequencyCode, string metaPartnerID, string accountName, int accountSubTypeCode, int currencyCode, string description, bool isActive)
		{
			Components.Accounts.BillPayAccountResults results = new Components.Accounts.BillPayAccountResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.BillPayAccount item = new BLL.Accounts.BillPayAccount();
				item.AccountID = MOD.Data.DataHelper.GetGuid(accountID, MOD.Data.DefaultValue.Guid);
				item.BusinessAccountNumber = businessAccountNumber;
				item.StartDate = MOD.Data.DataHelper.GetDateTime(startDate, System.DateTime.MinValue);
				item.EndDate = MOD.Data.DataHelper.GetDateTime(endDate, System.DateTime.MinValue);
				item.DefaultMinimumPayment = defaultMinimumPayment;
				item.DefaultMaximumPayment = defaultMaximumPayment;
				item.BusinessMetaPartnerID = MOD.Data.DataHelper.GetGuid(businessMetaPartnerID, MOD.Data.DefaultValue.Guid);
				item.HourOfDay = hourOfDay;
				item.DayOfWeek = dayOfWeek;
				item.WeekOfMonth = weekOfMonth;
				item.MonthOfYear = monthOfYear;
				item.NumberOfReminders = numberOfReminders;
				item.FrequencyCode = frequencyCode;
				item.MetaPartnerID = MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid);
				item.AccountName = accountName;
				item.AccountSubTypeCode = accountSubTypeCode;
				item.CurrencyCode = currencyCode;
				item.Description = description;
				item.IsActive = isActive;
				BLL.Accounts.BillPayAccountManager.UpdateOneBillPayAccount(item, false);
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
		public BillPayAccountManager()
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