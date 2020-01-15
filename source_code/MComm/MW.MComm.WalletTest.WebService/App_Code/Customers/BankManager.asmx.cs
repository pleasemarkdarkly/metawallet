
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
using MW.MComm.WalletTest.WebService.Customers;
using BLL = MW.MComm.WalletSolution.BLL;
using MW.MComm.WalletSolution.BLL.Customers;
using MOD.Data;
using Utility = MW.MComm.WalletSolution.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
namespace MW.MComm.WalletTest.WebService.Customers
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage Bank related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public class BankManager : System.Web.Services.WebService
	{
		#region "Service Methods"
		// ------------------------------------------------------------------
		/// <summary>This web service method inserts Bank data.</summary>
		///
		/// <param name="metaPartnerID">A property of Bank item to be managed</param>
		/// <param name="bankCode">A property of Bank item to be managed</param>
		/// <param name="serviceCharges">A property of Bank item to be managed</param>
		/// <param name="metaPartnerSubTypeCode">A property of Bank item to be managed</param>
		/// <param name="localeCode">A property of Bank item to be managed</param>
		/// <param name="currencyCode">A property of Bank item to be managed</param>
		/// <param name="dateFormatCode">A property of Bank item to be managed</param>
		/// <param name="taxCode">A property of Bank item to be managed</param>
		/// <param name="isActive">A property of Bank item to be managed</param>
		/// <param name="metaPartnerName">A property of Bank item to be managed</param>
		/// <param name="pictureImageURL">A property of Bank item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.BankResults AddOneBank(string metaPartnerID, int bankCode, string serviceCharges, int metaPartnerSubTypeCode, int localeCode, int currencyCode, int dateFormatCode, string taxCode, bool isActive, string metaPartnerName, string pictureImageURL)
		{
			Components.Customers.BankResults results = new Components.Customers.BankResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Customers.Bank item = new BLL.Customers.Bank();
				item.MetaPartnerID = MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid);
				item.BankCode = bankCode;
				item.ServiceCharges = serviceCharges;
				item.MetaPartnerSubTypeCode = metaPartnerSubTypeCode;
				item.LocaleCode = localeCode;
				item.CurrencyCode = currencyCode;
				item.DateFormatCode = dateFormatCode;
				item.TaxCode = taxCode;
				item.IsActive = isActive;
				item.MetaPartnerName = metaPartnerName;
				item.PictureImageURL = pictureImageURL;
				BLL.Customers.BankManager.AddOneBank(item, false);
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
		/// <summary>This web service method deletes all Bank data by a key.</summary>
		///
		/// <param name="currencyCode">A key for Bank items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.BankResults DeleteAllBankDataByCurrencyCode(int currencyCode)
		{
			Components.Customers.BankResults results = new Components.Customers.BankResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Customers.BankManager.DeleteAllBankDataByCurrencyCode(currencyCode);
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
		/// <summary>This web service method deletes all Bank data by a key.</summary>
		///
		/// <param name="dateFormatCode">A key for Bank items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.BankResults DeleteAllBankDataByDateFormatCode(int dateFormatCode)
		{
			Components.Customers.BankResults results = new Components.Customers.BankResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Customers.BankManager.DeleteAllBankDataByDateFormatCode(dateFormatCode);
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
		/// <summary>This web service method deletes all Bank data by a key.</summary>
		///
		/// <param name="localeCode">A key for Bank items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.BankResults DeleteAllBankDataByLocaleCode(int localeCode)
		{
			Components.Customers.BankResults results = new Components.Customers.BankResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Customers.BankManager.DeleteAllBankDataByLocaleCode(localeCode);
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
		/// <summary>This web service method deletes all Bank data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for Bank items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.BankResults DeleteAllBankDataByMetaPartnerID(string metaPartnerID)
		{
			Components.Customers.BankResults results = new Components.Customers.BankResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Customers.BankManager.DeleteAllBankDataByMetaPartnerID(MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid));
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
		/// <summary>This web service method deletes all Bank data by a key.</summary>
		///
		/// <param name="metaPartnerSubTypeCode">A key for Bank items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.BankResults DeleteAllBankDataByMetaPartnerSubTypeCode(int metaPartnerSubTypeCode)
		{
			Components.Customers.BankResults results = new Components.Customers.BankResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Customers.BankManager.DeleteAllBankDataByMetaPartnerSubTypeCode(metaPartnerSubTypeCode);
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
		/// <summary>This web service method deletes Bank data.</summary>
		///
		/// <param name="metaPartnerID">A property of Bank item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.BankResults DeleteOneBank(string metaPartnerID)
		{
			Components.Customers.BankResults results = new Components.Customers.BankResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Customers.Bank item = new BLL.Customers.Bank();
				item.MetaPartnerID = MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid);
				BLL.Customers.BankManager.DeleteOneBank(item, false);
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
		/// <summary>This web service method gets all Bank data.</summary>
		///
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.BankResults GetAllBankData(string sortColumn, string sortDirection)
		{
			Components.Customers.BankResults results = new Components.Customers.BankResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Customers.BankManager.GetAllBankData(Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Bank data by criteria.</summary>
		///
		/// <param name="localeCode">A key for Bank items to be fetched</param>
		/// <param name="currencyCode">A key for Bank items to be fetched</param>
		/// <param name="dateFormatCode">A key for Bank items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Bank items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Bank items to be fetched</param>
		/// <param name="metaPartnerName">A key for Bank items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.BankResults GetAllBankDataByCriteria(string localeCode, string currencyCode, string dateFormatCode, string lastModifiedDateStart, string lastModifiedDateEnd, string metaPartnerName, string sortColumn, string sortDirection)
		{
			Components.Customers.BankResults results = new Components.Customers.BankResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Customers.BankManager.GetAllBankDataByCriteria(MOD.Data.SearchHelper.GetInt(localeCode), MOD.Data.SearchHelper.GetInt(currencyCode), MOD.Data.SearchHelper.GetInt(dateFormatCode), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateStart), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateEnd), MOD.Data.SearchHelper.GetString(metaPartnerName), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Bank data by a key.</summary>
		///
		/// <param name="currencyCode">A key for Bank items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.BankResults GetAllBankDataByCurrencyCode(string currencyCode, string sortColumn, string sortDirection)
		{
			Components.Customers.BankResults results = new Components.Customers.BankResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Customers.BankManager.GetAllBankDataByCurrencyCode(MOD.Data.DataHelper.GetInt(currencyCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Bank data by a key.</summary>
		///
		/// <param name="dateFormatCode">A key for Bank items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.BankResults GetAllBankDataByDateFormatCode(string dateFormatCode, string sortColumn, string sortDirection)
		{
			Components.Customers.BankResults results = new Components.Customers.BankResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Customers.BankManager.GetAllBankDataByDateFormatCode(MOD.Data.DataHelper.GetInt(dateFormatCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Bank data by a key.</summary>
		///
		/// <param name="localeCode">A key for Bank items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.BankResults GetAllBankDataByLocaleCode(string localeCode, string sortColumn, string sortDirection)
		{
			Components.Customers.BankResults results = new Components.Customers.BankResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Customers.BankManager.GetAllBankDataByLocaleCode(MOD.Data.DataHelper.GetInt(localeCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Bank data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for Bank items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.BankResults GetAllBankDataByMetaPartnerID(string metaPartnerID, string sortColumn, string sortDirection)
		{
			Components.Customers.BankResults results = new Components.Customers.BankResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Customers.BankManager.GetAllBankDataByMetaPartnerID(MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Bank data by a key.</summary>
		///
		/// <param name="metaPartnerSubTypeCode">A key for Bank items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.BankResults GetAllBankDataByMetaPartnerSubTypeCode(string metaPartnerSubTypeCode, string sortColumn, string sortDirection)
		{
			Components.Customers.BankResults results = new Components.Customers.BankResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Customers.BankManager.GetAllBankDataByMetaPartnerSubTypeCode(MOD.Data.DataHelper.GetInt(metaPartnerSubTypeCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Bank data by criteria.</summary>
		///
		/// <param name="localeCode">A key for Bank items to be fetched</param>
		/// <param name="currencyCode">A key for Bank items to be fetched</param>
		/// <param name="dateFormatCode">A key for Bank items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Bank items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Bank items to be fetched</param>
		/// <param name="metaPartnerName">A key for Bank items to be fetched</param>
         /// <param name="startIndex">Start Index (beginning at 1)</param>
         /// <param name="pageSize">Page Size</param>
         /// <param name="maximumListSize">Maximum List Size</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.BankResults GetManyBankDataByCriteria(string localeCode, string currencyCode, string dateFormatCode, string lastModifiedDateStart, string lastModifiedDateEnd, string metaPartnerName, int startIndex, int pageSize, int maximumListSize, string sortColumn, string sortDirection)
		{
			Components.Customers.BankResults results = new Components.Customers.BankResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				int totalRecords = 0;
				bool maximumListSizeExceeded = false;
				results.Results = BLL.Customers.BankManager.GetManyBankDataByCriteria(MOD.Data.SearchHelper.GetInt(localeCode), MOD.Data.SearchHelper.GetInt(currencyCode), MOD.Data.SearchHelper.GetInt(dateFormatCode), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateStart), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateEnd), MOD.Data.SearchHelper.GetString(metaPartnerName), out totalRecords, out maximumListSizeExceeded, Globals.getDataOptions(sortColumn, sortDirection, startIndex, pageSize, maximumListSize));
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
		/// <summary>This web service method gets a single Bank by an index.</summary>
		///
		/// <param name="metaPartnerID">The index for Bank to be fetched</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.BankResults GetOneBank(string metaPartnerID, string sortColumn, string sortDirection)
		{
			Components.Customers.BankResults results = new Components.Customers.BankResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Customers.Bank item =  BLL.Customers.BankManager.GetOneBank(MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
				// populate desired collections with lazy loading
				bool isAccessed = true;
				isAccessed = item.PhoneList.IsDirty;
				isAccessed = item.EmailList.IsDirty;
				isAccessed = item.LocationList.IsDirty;
				isAccessed = item.BankAccountList.IsDirty;
				isAccessed = item.StoredValueAccountList.IsDirty;
				isAccessed = item.CreditAccountList.IsDirty;
				isAccessed = item.FundAccountList.IsDirty;
				isAccessed = item.BillPayAccountList.IsDirty;
				isAccessed = item.MetaTransferAccountList.IsDirty;
				isAccessed = item.LoanAccountList.IsDirty;
				isAccessed = item.MetaPartnerCouponList.IsDirty;
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
		/// <summary>This web service method gets a single Bank by an index.</summary>
		///
		/// <param name="bankCode">The index for Bank to be fetched</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.BankResults GetOneBankByBankCode(int bankCode, string sortColumn, string sortDirection)
		{
			Components.Customers.BankResults results = new Components.Customers.BankResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Customers.Bank item =  BLL.Customers.BankManager.GetOneBankByBankCode(MOD.Data.DataHelper.GetInt(bankCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
				// populate desired collections with lazy loading
				bool isAccessed = true;
				isAccessed = item.PhoneList.IsDirty;
				isAccessed = item.EmailList.IsDirty;
				isAccessed = item.LocationList.IsDirty;
				isAccessed = item.BankAccountList.IsDirty;
				isAccessed = item.StoredValueAccountList.IsDirty;
				isAccessed = item.CreditAccountList.IsDirty;
				isAccessed = item.FundAccountList.IsDirty;
				isAccessed = item.BillPayAccountList.IsDirty;
				isAccessed = item.MetaTransferAccountList.IsDirty;
				isAccessed = item.LoanAccountList.IsDirty;
				isAccessed = item.MetaPartnerCouponList.IsDirty;
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
		/// <summary>This web service method updates Bank data.</summary>
		///
		/// <param name="metaPartnerID">A property of Bank item to be managed</param>
		/// <param name="bankCode">A property of Bank item to be managed</param>
		/// <param name="serviceCharges">A property of Bank item to be managed</param>
		/// <param name="metaPartnerSubTypeCode">A property of Bank item to be managed</param>
		/// <param name="localeCode">A property of Bank item to be managed</param>
		/// <param name="currencyCode">A property of Bank item to be managed</param>
		/// <param name="dateFormatCode">A property of Bank item to be managed</param>
		/// <param name="taxCode">A property of Bank item to be managed</param>
		/// <param name="isActive">A property of Bank item to be managed</param>
		/// <param name="metaPartnerName">A property of Bank item to be managed</param>
		/// <param name="pictureImageURL">A property of Bank item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.BankResults UpdateOneBank(string metaPartnerID, int bankCode, string serviceCharges, int metaPartnerSubTypeCode, int localeCode, int currencyCode, int dateFormatCode, string taxCode, bool isActive, string metaPartnerName, string pictureImageURL)
		{
			Components.Customers.BankResults results = new Components.Customers.BankResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Customers.Bank item = new BLL.Customers.Bank();
				item.MetaPartnerID = MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid);
				item.BankCode = bankCode;
				item.ServiceCharges = serviceCharges;
				item.MetaPartnerSubTypeCode = metaPartnerSubTypeCode;
				item.LocaleCode = localeCode;
				item.CurrencyCode = currencyCode;
				item.DateFormatCode = dateFormatCode;
				item.TaxCode = taxCode;
				item.IsActive = isActive;
				item.MetaPartnerName = metaPartnerName;
				item.PictureImageURL = pictureImageURL;
				BLL.Customers.BankManager.UpdateOneBank(item, false);
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
		public BankManager()
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