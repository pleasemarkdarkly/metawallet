
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
	/// <summary>This class is used to manage Business related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public class BusinessManager : System.Web.Services.WebService
	{
		#region "Service Methods"
		// ------------------------------------------------------------------
		/// <summary>This web service method inserts Business data.</summary>
		///
		/// <param name="metaPartnerID">A property of Business item to be managed</param>
		/// <param name="serviceCharges">A property of Business item to be managed</param>
		/// <param name="metaPartnerSubTypeCode">A property of Business item to be managed</param>
		/// <param name="localeCode">A property of Business item to be managed</param>
		/// <param name="currencyCode">A property of Business item to be managed</param>
		/// <param name="dateFormatCode">A property of Business item to be managed</param>
		/// <param name="taxCode">A property of Business item to be managed</param>
		/// <param name="isActive">A property of Business item to be managed</param>
		/// <param name="metaPartnerName">A property of Business item to be managed</param>
		/// <param name="pictureImageURL">A property of Business item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.BusinessResults AddOneBusiness(string metaPartnerID, string serviceCharges, int metaPartnerSubTypeCode, int localeCode, int currencyCode, int dateFormatCode, string taxCode, bool isActive, string metaPartnerName, string pictureImageURL)
		{
			Components.Customers.BusinessResults results = new Components.Customers.BusinessResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Customers.Business item = new BLL.Customers.Business();
				item.MetaPartnerID = MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid);
				item.ServiceCharges = serviceCharges;
				item.MetaPartnerSubTypeCode = metaPartnerSubTypeCode;
				item.LocaleCode = localeCode;
				item.CurrencyCode = currencyCode;
				item.DateFormatCode = dateFormatCode;
				item.TaxCode = taxCode;
				item.IsActive = isActive;
				item.MetaPartnerName = metaPartnerName;
				item.PictureImageURL = pictureImageURL;
				BLL.Customers.BusinessManager.AddOneBusiness(item, false);
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
		/// <summary>This web service method deletes all Business data by a key.</summary>
		///
		/// <param name="currencyCode">A key for Business items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.BusinessResults DeleteAllBusinessDataByCurrencyCode(int currencyCode)
		{
			Components.Customers.BusinessResults results = new Components.Customers.BusinessResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Customers.BusinessManager.DeleteAllBusinessDataByCurrencyCode(currencyCode);
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
		/// <summary>This web service method deletes all Business data by a key.</summary>
		///
		/// <param name="dateFormatCode">A key for Business items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.BusinessResults DeleteAllBusinessDataByDateFormatCode(int dateFormatCode)
		{
			Components.Customers.BusinessResults results = new Components.Customers.BusinessResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Customers.BusinessManager.DeleteAllBusinessDataByDateFormatCode(dateFormatCode);
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
		/// <summary>This web service method deletes all Business data by a key.</summary>
		///
		/// <param name="localeCode">A key for Business items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.BusinessResults DeleteAllBusinessDataByLocaleCode(int localeCode)
		{
			Components.Customers.BusinessResults results = new Components.Customers.BusinessResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Customers.BusinessManager.DeleteAllBusinessDataByLocaleCode(localeCode);
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
		/// <summary>This web service method deletes all Business data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for Business items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.BusinessResults DeleteAllBusinessDataByMetaPartnerID(string metaPartnerID)
		{
			Components.Customers.BusinessResults results = new Components.Customers.BusinessResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Customers.BusinessManager.DeleteAllBusinessDataByMetaPartnerID(MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid));
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
		/// <summary>This web service method deletes all Business data by a key.</summary>
		///
		/// <param name="metaPartnerSubTypeCode">A key for Business items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.BusinessResults DeleteAllBusinessDataByMetaPartnerSubTypeCode(int metaPartnerSubTypeCode)
		{
			Components.Customers.BusinessResults results = new Components.Customers.BusinessResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Customers.BusinessManager.DeleteAllBusinessDataByMetaPartnerSubTypeCode(metaPartnerSubTypeCode);
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
		/// <summary>This web service method deletes Business data.</summary>
		///
		/// <param name="metaPartnerID">A property of Business item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.BusinessResults DeleteOneBusiness(string metaPartnerID)
		{
			Components.Customers.BusinessResults results = new Components.Customers.BusinessResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Customers.Business item = new BLL.Customers.Business();
				item.MetaPartnerID = MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid);
				BLL.Customers.BusinessManager.DeleteOneBusiness(item, false);
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
		/// <summary>This web service method gets all Business data.</summary>
		///
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.BusinessResults GetAllBusinessData(string sortColumn, string sortDirection)
		{
			Components.Customers.BusinessResults results = new Components.Customers.BusinessResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Customers.BusinessManager.GetAllBusinessData(Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Business data by criteria.</summary>
		///
		/// <param name="localeCode">A key for Business items to be fetched</param>
		/// <param name="currencyCode">A key for Business items to be fetched</param>
		/// <param name="dateFormatCode">A key for Business items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Business items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Business items to be fetched</param>
		/// <param name="metaPartnerName">A key for Business items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.BusinessResults GetAllBusinessDataByCriteria(string localeCode, string currencyCode, string dateFormatCode, string lastModifiedDateStart, string lastModifiedDateEnd, string metaPartnerName, string sortColumn, string sortDirection)
		{
			Components.Customers.BusinessResults results = new Components.Customers.BusinessResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Customers.BusinessManager.GetAllBusinessDataByCriteria(MOD.Data.SearchHelper.GetInt(localeCode), MOD.Data.SearchHelper.GetInt(currencyCode), MOD.Data.SearchHelper.GetInt(dateFormatCode), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateStart), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateEnd), MOD.Data.SearchHelper.GetString(metaPartnerName), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Business data by a key.</summary>
		///
		/// <param name="currencyCode">A key for Business items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.BusinessResults GetAllBusinessDataByCurrencyCode(string currencyCode, string sortColumn, string sortDirection)
		{
			Components.Customers.BusinessResults results = new Components.Customers.BusinessResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Customers.BusinessManager.GetAllBusinessDataByCurrencyCode(MOD.Data.DataHelper.GetInt(currencyCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Business data by a key.</summary>
		///
		/// <param name="dateFormatCode">A key for Business items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.BusinessResults GetAllBusinessDataByDateFormatCode(string dateFormatCode, string sortColumn, string sortDirection)
		{
			Components.Customers.BusinessResults results = new Components.Customers.BusinessResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Customers.BusinessManager.GetAllBusinessDataByDateFormatCode(MOD.Data.DataHelper.GetInt(dateFormatCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Business data by a key.</summary>
		///
		/// <param name="localeCode">A key for Business items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.BusinessResults GetAllBusinessDataByLocaleCode(string localeCode, string sortColumn, string sortDirection)
		{
			Components.Customers.BusinessResults results = new Components.Customers.BusinessResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Customers.BusinessManager.GetAllBusinessDataByLocaleCode(MOD.Data.DataHelper.GetInt(localeCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Business data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for Business items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.BusinessResults GetAllBusinessDataByMetaPartnerID(string metaPartnerID, string sortColumn, string sortDirection)
		{
			Components.Customers.BusinessResults results = new Components.Customers.BusinessResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Customers.BusinessManager.GetAllBusinessDataByMetaPartnerID(MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Business data by a key.</summary>
		///
		/// <param name="metaPartnerSubTypeCode">A key for Business items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.BusinessResults GetAllBusinessDataByMetaPartnerSubTypeCode(string metaPartnerSubTypeCode, string sortColumn, string sortDirection)
		{
			Components.Customers.BusinessResults results = new Components.Customers.BusinessResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Customers.BusinessManager.GetAllBusinessDataByMetaPartnerSubTypeCode(MOD.Data.DataHelper.GetInt(metaPartnerSubTypeCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Business data by criteria.</summary>
		///
		/// <param name="localeCode">A key for Business items to be fetched</param>
		/// <param name="currencyCode">A key for Business items to be fetched</param>
		/// <param name="dateFormatCode">A key for Business items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Business items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Business items to be fetched</param>
		/// <param name="metaPartnerName">A key for Business items to be fetched</param>
         /// <param name="startIndex">Start Index (beginning at 1)</param>
         /// <param name="pageSize">Page Size</param>
         /// <param name="maximumListSize">Maximum List Size</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.BusinessResults GetManyBusinessDataByCriteria(string localeCode, string currencyCode, string dateFormatCode, string lastModifiedDateStart, string lastModifiedDateEnd, string metaPartnerName, int startIndex, int pageSize, int maximumListSize, string sortColumn, string sortDirection)
		{
			Components.Customers.BusinessResults results = new Components.Customers.BusinessResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				int totalRecords = 0;
				bool maximumListSizeExceeded = false;
				results.Results = BLL.Customers.BusinessManager.GetManyBusinessDataByCriteria(MOD.Data.SearchHelper.GetInt(localeCode), MOD.Data.SearchHelper.GetInt(currencyCode), MOD.Data.SearchHelper.GetInt(dateFormatCode), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateStart), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateEnd), MOD.Data.SearchHelper.GetString(metaPartnerName), out totalRecords, out maximumListSizeExceeded, Globals.getDataOptions(sortColumn, sortDirection, startIndex, pageSize, maximumListSize));
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
		/// <summary>This web service method gets a single Business by an index.</summary>
		///
		/// <param name="metaPartnerID">The index for Business to be fetched</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.BusinessResults GetOneBusiness(string metaPartnerID, string sortColumn, string sortDirection)
		{
			Components.Customers.BusinessResults results = new Components.Customers.BusinessResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Customers.Business item =  BLL.Customers.BusinessManager.GetOneBusiness(MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method updates Business data.</summary>
		///
		/// <param name="metaPartnerID">A property of Business item to be managed</param>
		/// <param name="serviceCharges">A property of Business item to be managed</param>
		/// <param name="metaPartnerSubTypeCode">A property of Business item to be managed</param>
		/// <param name="localeCode">A property of Business item to be managed</param>
		/// <param name="currencyCode">A property of Business item to be managed</param>
		/// <param name="dateFormatCode">A property of Business item to be managed</param>
		/// <param name="taxCode">A property of Business item to be managed</param>
		/// <param name="isActive">A property of Business item to be managed</param>
		/// <param name="metaPartnerName">A property of Business item to be managed</param>
		/// <param name="pictureImageURL">A property of Business item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.BusinessResults UpdateOneBusiness(string metaPartnerID, string serviceCharges, int metaPartnerSubTypeCode, int localeCode, int currencyCode, int dateFormatCode, string taxCode, bool isActive, string metaPartnerName, string pictureImageURL)
		{
			Components.Customers.BusinessResults results = new Components.Customers.BusinessResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Customers.Business item = new BLL.Customers.Business();
				item.MetaPartnerID = MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid);
				item.ServiceCharges = serviceCharges;
				item.MetaPartnerSubTypeCode = metaPartnerSubTypeCode;
				item.LocaleCode = localeCode;
				item.CurrencyCode = currencyCode;
				item.DateFormatCode = dateFormatCode;
				item.TaxCode = taxCode;
				item.IsActive = isActive;
				item.MetaPartnerName = metaPartnerName;
				item.PictureImageURL = pictureImageURL;
				BLL.Customers.BusinessManager.UpdateOneBusiness(item, false);
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
		public BusinessManager()
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