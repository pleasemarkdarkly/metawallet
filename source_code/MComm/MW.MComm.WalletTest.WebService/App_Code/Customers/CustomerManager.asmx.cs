
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
	/// <summary>This class is used to manage Customer related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public class CustomerManager : System.Web.Services.WebService
	{
		#region "Service Methods"
		// ------------------------------------------------------------------
		/// <summary>This web service method inserts Customer data.</summary>
		///
		/// <param name="metaPartnerID">A property of Customer item to be managed</param>
		/// <param name="firstName">A property of Customer item to be managed</param>
		/// <param name="lastName">A property of Customer item to be managed</param>
		/// <param name="metaPartnerSubTypeCode">A property of Customer item to be managed</param>
		/// <param name="localeCode">A property of Customer item to be managed</param>
		/// <param name="currencyCode">A property of Customer item to be managed</param>
		/// <param name="dateFormatCode">A property of Customer item to be managed</param>
		/// <param name="taxCode">A property of Customer item to be managed</param>
		/// <param name="isActive">A property of Customer item to be managed</param>
		/// <param name="metaPartnerName">A property of Customer item to be managed</param>
		/// <param name="pictureImageURL">A property of Customer item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.CustomerResults AddOneCustomer(string metaPartnerID, string firstName, string lastName, int metaPartnerSubTypeCode, int localeCode, int currencyCode, int dateFormatCode, string taxCode, bool isActive, string metaPartnerName, string pictureImageURL)
		{
			Components.Customers.CustomerResults results = new Components.Customers.CustomerResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Customers.Customer item = new BLL.Customers.Customer();
				item.MetaPartnerID = MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid);
				item.FirstName = firstName;
				item.LastName = lastName;
				item.MetaPartnerSubTypeCode = metaPartnerSubTypeCode;
				item.LocaleCode = localeCode;
				item.CurrencyCode = currencyCode;
				item.DateFormatCode = dateFormatCode;
				item.TaxCode = taxCode;
				item.IsActive = isActive;
				item.MetaPartnerName = metaPartnerName;
				item.PictureImageURL = pictureImageURL;
				BLL.Customers.CustomerManager.AddOneCustomer(item, false);
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
		/// <summary>This web service method deletes all Customer data by a key.</summary>
		///
		/// <param name="currencyCode">A key for Customer items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.CustomerResults DeleteAllCustomerDataByCurrencyCode(int currencyCode)
		{
			Components.Customers.CustomerResults results = new Components.Customers.CustomerResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Customers.CustomerManager.DeleteAllCustomerDataByCurrencyCode(currencyCode);
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
		/// <summary>This web service method deletes all Customer data by a key.</summary>
		///
		/// <param name="dateFormatCode">A key for Customer items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.CustomerResults DeleteAllCustomerDataByDateFormatCode(int dateFormatCode)
		{
			Components.Customers.CustomerResults results = new Components.Customers.CustomerResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Customers.CustomerManager.DeleteAllCustomerDataByDateFormatCode(dateFormatCode);
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
		/// <summary>This web service method deletes all Customer data by a key.</summary>
		///
		/// <param name="localeCode">A key for Customer items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.CustomerResults DeleteAllCustomerDataByLocaleCode(int localeCode)
		{
			Components.Customers.CustomerResults results = new Components.Customers.CustomerResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Customers.CustomerManager.DeleteAllCustomerDataByLocaleCode(localeCode);
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
		/// <summary>This web service method deletes all Customer data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for Customer items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.CustomerResults DeleteAllCustomerDataByMetaPartnerID(string metaPartnerID)
		{
			Components.Customers.CustomerResults results = new Components.Customers.CustomerResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Customers.CustomerManager.DeleteAllCustomerDataByMetaPartnerID(MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid));
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
		/// <summary>This web service method deletes all Customer data by a key.</summary>
		///
		/// <param name="metaPartnerSubTypeCode">A key for Customer items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.CustomerResults DeleteAllCustomerDataByMetaPartnerSubTypeCode(int metaPartnerSubTypeCode)
		{
			Components.Customers.CustomerResults results = new Components.Customers.CustomerResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Customers.CustomerManager.DeleteAllCustomerDataByMetaPartnerSubTypeCode(metaPartnerSubTypeCode);
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
		/// <summary>This web service method deletes Customer data.</summary>
		///
		/// <param name="metaPartnerID">A property of Customer item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.CustomerResults DeleteOneCustomer(string metaPartnerID)
		{
			Components.Customers.CustomerResults results = new Components.Customers.CustomerResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Customers.Customer item = new BLL.Customers.Customer();
				item.MetaPartnerID = MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid);
				BLL.Customers.CustomerManager.DeleteOneCustomer(item, false);
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
		/// <summary>This web service method gets all Customer data.</summary>
		///
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.CustomerResults GetAllCustomerData(string sortColumn, string sortDirection)
		{
			Components.Customers.CustomerResults results = new Components.Customers.CustomerResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Customers.CustomerManager.GetAllCustomerData(Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Customer data by criteria.</summary>
		///
		/// <param name="firstName">A key for Customer items to be fetched</param>
		/// <param name="lastName">A key for Customer items to be fetched</param>
		/// <param name="localeCode">A key for Customer items to be fetched</param>
		/// <param name="currencyCode">A key for Customer items to be fetched</param>
		/// <param name="dateFormatCode">A key for Customer items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Customer items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Customer items to be fetched</param>
		/// <param name="metaPartnerName">A key for Customer items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.CustomerResults GetAllCustomerDataByCriteria(string firstName, string lastName, string localeCode, string currencyCode, string dateFormatCode, string lastModifiedDateStart, string lastModifiedDateEnd, string metaPartnerName, string sortColumn, string sortDirection)
		{
			Components.Customers.CustomerResults results = new Components.Customers.CustomerResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Customers.CustomerManager.GetAllCustomerDataByCriteria(MOD.Data.SearchHelper.GetString(firstName), MOD.Data.SearchHelper.GetString(lastName), MOD.Data.SearchHelper.GetInt(localeCode), MOD.Data.SearchHelper.GetInt(currencyCode), MOD.Data.SearchHelper.GetInt(dateFormatCode), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateStart), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateEnd), MOD.Data.SearchHelper.GetString(metaPartnerName), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Customer data by a key.</summary>
		///
		/// <param name="currencyCode">A key for Customer items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.CustomerResults GetAllCustomerDataByCurrencyCode(string currencyCode, string sortColumn, string sortDirection)
		{
			Components.Customers.CustomerResults results = new Components.Customers.CustomerResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Customers.CustomerManager.GetAllCustomerDataByCurrencyCode(MOD.Data.DataHelper.GetInt(currencyCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Customer data by a key.</summary>
		///
		/// <param name="dateFormatCode">A key for Customer items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.CustomerResults GetAllCustomerDataByDateFormatCode(string dateFormatCode, string sortColumn, string sortDirection)
		{
			Components.Customers.CustomerResults results = new Components.Customers.CustomerResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Customers.CustomerManager.GetAllCustomerDataByDateFormatCode(MOD.Data.DataHelper.GetInt(dateFormatCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Customer data by a key.</summary>
		///
		/// <param name="localeCode">A key for Customer items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.CustomerResults GetAllCustomerDataByLocaleCode(string localeCode, string sortColumn, string sortDirection)
		{
			Components.Customers.CustomerResults results = new Components.Customers.CustomerResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Customers.CustomerManager.GetAllCustomerDataByLocaleCode(MOD.Data.DataHelper.GetInt(localeCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Customer data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for Customer items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.CustomerResults GetAllCustomerDataByMetaPartnerID(string metaPartnerID, string sortColumn, string sortDirection)
		{
			Components.Customers.CustomerResults results = new Components.Customers.CustomerResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Customers.CustomerManager.GetAllCustomerDataByMetaPartnerID(MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Customer data by a key.</summary>
		///
		/// <param name="metaPartnerSubTypeCode">A key for Customer items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.CustomerResults GetAllCustomerDataByMetaPartnerSubTypeCode(string metaPartnerSubTypeCode, string sortColumn, string sortDirection)
		{
			Components.Customers.CustomerResults results = new Components.Customers.CustomerResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Customers.CustomerManager.GetAllCustomerDataByMetaPartnerSubTypeCode(MOD.Data.DataHelper.GetInt(metaPartnerSubTypeCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Customer data by criteria.</summary>
		///
		/// <param name="firstName">A key for Customer items to be fetched</param>
		/// <param name="lastName">A key for Customer items to be fetched</param>
		/// <param name="localeCode">A key for Customer items to be fetched</param>
		/// <param name="currencyCode">A key for Customer items to be fetched</param>
		/// <param name="dateFormatCode">A key for Customer items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Customer items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Customer items to be fetched</param>
		/// <param name="metaPartnerName">A key for Customer items to be fetched</param>
         /// <param name="startIndex">Start Index (beginning at 1)</param>
         /// <param name="pageSize">Page Size</param>
         /// <param name="maximumListSize">Maximum List Size</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.CustomerResults GetManyCustomerDataByCriteria(string firstName, string lastName, string localeCode, string currencyCode, string dateFormatCode, string lastModifiedDateStart, string lastModifiedDateEnd, string metaPartnerName, int startIndex, int pageSize, int maximumListSize, string sortColumn, string sortDirection)
		{
			Components.Customers.CustomerResults results = new Components.Customers.CustomerResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				int totalRecords = 0;
				bool maximumListSizeExceeded = false;
				results.Results = BLL.Customers.CustomerManager.GetManyCustomerDataByCriteria(MOD.Data.SearchHelper.GetString(firstName), MOD.Data.SearchHelper.GetString(lastName), MOD.Data.SearchHelper.GetInt(localeCode), MOD.Data.SearchHelper.GetInt(currencyCode), MOD.Data.SearchHelper.GetInt(dateFormatCode), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateStart), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateEnd), MOD.Data.SearchHelper.GetString(metaPartnerName), out totalRecords, out maximumListSizeExceeded, Globals.getDataOptions(sortColumn, sortDirection, startIndex, pageSize, maximumListSize));
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
		/// <summary>This web service method gets a single Customer by an index.</summary>
		///
		/// <param name="metaPartnerID">The index for Customer to be fetched</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.CustomerResults GetOneCustomer(string metaPartnerID, string sortColumn, string sortDirection)
		{
			Components.Customers.CustomerResults results = new Components.Customers.CustomerResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Customers.Customer item =  BLL.Customers.CustomerManager.GetOneCustomer(MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method updates Customer data.</summary>
		///
		/// <param name="metaPartnerID">A property of Customer item to be managed</param>
		/// <param name="firstName">A property of Customer item to be managed</param>
		/// <param name="lastName">A property of Customer item to be managed</param>
		/// <param name="metaPartnerSubTypeCode">A property of Customer item to be managed</param>
		/// <param name="localeCode">A property of Customer item to be managed</param>
		/// <param name="currencyCode">A property of Customer item to be managed</param>
		/// <param name="dateFormatCode">A property of Customer item to be managed</param>
		/// <param name="taxCode">A property of Customer item to be managed</param>
		/// <param name="isActive">A property of Customer item to be managed</param>
		/// <param name="metaPartnerName">A property of Customer item to be managed</param>
		/// <param name="pictureImageURL">A property of Customer item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.CustomerResults UpdateOneCustomer(string metaPartnerID, string firstName, string lastName, int metaPartnerSubTypeCode, int localeCode, int currencyCode, int dateFormatCode, string taxCode, bool isActive, string metaPartnerName, string pictureImageURL)
		{
			Components.Customers.CustomerResults results = new Components.Customers.CustomerResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Customers.Customer item = new BLL.Customers.Customer();
				item.MetaPartnerID = MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid);
				item.FirstName = firstName;
				item.LastName = lastName;
				item.MetaPartnerSubTypeCode = metaPartnerSubTypeCode;
				item.LocaleCode = localeCode;
				item.CurrencyCode = currencyCode;
				item.DateFormatCode = dateFormatCode;
				item.TaxCode = taxCode;
				item.IsActive = isActive;
				item.MetaPartnerName = metaPartnerName;
				item.PictureImageURL = pictureImageURL;
				BLL.Customers.CustomerManager.UpdateOneCustomer(item, false);
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
		public CustomerManager()
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