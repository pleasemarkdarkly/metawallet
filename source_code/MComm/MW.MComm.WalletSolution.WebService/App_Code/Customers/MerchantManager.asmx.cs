
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
using MW.MComm.WalletSolution.WebService.Customers;
using BLL = MW.MComm.WalletSolution.BLL;
using MW.MComm.WalletSolution.BLL.Customers;
using MOD.Data;
using Utility = MW.MComm.WalletSolution.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
namespace MW.MComm.WalletSolution.WebService.Customers
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage Merchant related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public class MerchantManager : System.Web.Services.WebService
	{
		#region "Service Methods"
		// ------------------------------------------------------------------
		/// <summary>This web service method inserts Merchant data.</summary>
		///
		/// <param name="item">The Merchant to be managed.</param>
		/// <param name="performCascadeOperation">Flag, indicating if a cascade operation should be performed on the Merchant item.</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.MerchantResults AddOneMerchant(BLL.Customers.Merchant item, bool performCascadeOperation)
		{
			Components.Customers.MerchantResults results = new Components.Customers.MerchantResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Customers.MerchantManager.AddOneMerchant(item, performCascadeOperation);
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
		/// <summary>This web service method deletes all Merchant data by a key.</summary>
		///
		/// <param name="currencyCode">A key for Merchant items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.MerchantResults DeleteAllMerchantDataByCurrencyCode(int currencyCode)
		{
			Components.Customers.MerchantResults results = new Components.Customers.MerchantResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Customers.MerchantManager.DeleteAllMerchantDataByCurrencyCode(currencyCode);
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
		/// <summary>This web service method deletes all Merchant data by a key.</summary>
		///
		/// <param name="dateFormatCode">A key for Merchant items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.MerchantResults DeleteAllMerchantDataByDateFormatCode(int dateFormatCode)
		{
			Components.Customers.MerchantResults results = new Components.Customers.MerchantResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Customers.MerchantManager.DeleteAllMerchantDataByDateFormatCode(dateFormatCode);
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
		/// <summary>This web service method deletes all Merchant data by a key.</summary>
		///
		/// <param name="localeCode">A key for Merchant items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.MerchantResults DeleteAllMerchantDataByLocaleCode(int localeCode)
		{
			Components.Customers.MerchantResults results = new Components.Customers.MerchantResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Customers.MerchantManager.DeleteAllMerchantDataByLocaleCode(localeCode);
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
		/// <summary>This web service method deletes all Merchant data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for Merchant items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.MerchantResults DeleteAllMerchantDataByMetaPartnerID(string metaPartnerID)
		{
			Components.Customers.MerchantResults results = new Components.Customers.MerchantResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Customers.MerchantManager.DeleteAllMerchantDataByMetaPartnerID(MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid));
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
		/// <summary>This web service method deletes all Merchant data by a key.</summary>
		///
		/// <param name="metaPartnerSubTypeCode">A key for Merchant items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.MerchantResults DeleteAllMerchantDataByMetaPartnerSubTypeCode(int metaPartnerSubTypeCode)
		{
			Components.Customers.MerchantResults results = new Components.Customers.MerchantResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Customers.MerchantManager.DeleteAllMerchantDataByMetaPartnerSubTypeCode(metaPartnerSubTypeCode);
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
		/// <summary>This web service method deletes Merchant data.</summary>
		///
		/// <param name="item">The Merchant to be deleted.</param>
		/// <param name="performCascadeOperation">Flag, indicating if a cascade delete should be performed on the Merchant item.</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.MerchantResults DeleteOneMerchant(BLL.Customers.Merchant item, bool performCascadeOperation)
		{
			Components.Customers.MerchantResults results = new Components.Customers.MerchantResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Customers.MerchantManager.DeleteOneMerchant(item, performCascadeOperation);
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
		/// <summary>This web service method gets all Merchant data.</summary>
		///
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.MerchantResults GetAllMerchantData(string sortColumn, string sortDirection)
		{
			Components.Customers.MerchantResults results = new Components.Customers.MerchantResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Customers.MerchantManager.GetAllMerchantData(Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Merchant data by criteria.</summary>
		///
		/// <param name="localeCode">A key for Merchant items to be fetched</param>
		/// <param name="currencyCode">A key for Merchant items to be fetched</param>
		/// <param name="dateFormatCode">A key for Merchant items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Merchant items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Merchant items to be fetched</param>
		/// <param name="metaPartnerName">A key for Merchant items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.MerchantResults GetAllMerchantDataByCriteria(string localeCode, string currencyCode, string dateFormatCode, string lastModifiedDateStart, string lastModifiedDateEnd, string metaPartnerName, string sortColumn, string sortDirection)
		{
			Components.Customers.MerchantResults results = new Components.Customers.MerchantResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Customers.MerchantManager.GetAllMerchantDataByCriteria(MOD.Data.SearchHelper.GetInt(localeCode), MOD.Data.SearchHelper.GetInt(currencyCode), MOD.Data.SearchHelper.GetInt(dateFormatCode), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateStart), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateEnd), MOD.Data.SearchHelper.GetString(metaPartnerName), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Merchant data by a key.</summary>
		///
		/// <param name="currencyCode">A key for Merchant items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.MerchantResults GetAllMerchantDataByCurrencyCode(string currencyCode, string sortColumn, string sortDirection)
		{
			Components.Customers.MerchantResults results = new Components.Customers.MerchantResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Customers.MerchantManager.GetAllMerchantDataByCurrencyCode(MOD.Data.DataHelper.GetInt(currencyCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Merchant data by a key.</summary>
		///
		/// <param name="dateFormatCode">A key for Merchant items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.MerchantResults GetAllMerchantDataByDateFormatCode(string dateFormatCode, string sortColumn, string sortDirection)
		{
			Components.Customers.MerchantResults results = new Components.Customers.MerchantResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Customers.MerchantManager.GetAllMerchantDataByDateFormatCode(MOD.Data.DataHelper.GetInt(dateFormatCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Merchant data by a key.</summary>
		///
		/// <param name="localeCode">A key for Merchant items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.MerchantResults GetAllMerchantDataByLocaleCode(string localeCode, string sortColumn, string sortDirection)
		{
			Components.Customers.MerchantResults results = new Components.Customers.MerchantResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Customers.MerchantManager.GetAllMerchantDataByLocaleCode(MOD.Data.DataHelper.GetInt(localeCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Merchant data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for Merchant items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.MerchantResults GetAllMerchantDataByMetaPartnerID(string metaPartnerID, string sortColumn, string sortDirection)
		{
			Components.Customers.MerchantResults results = new Components.Customers.MerchantResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Customers.MerchantManager.GetAllMerchantDataByMetaPartnerID(MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Merchant data by a key.</summary>
		///
		/// <param name="metaPartnerSubTypeCode">A key for Merchant items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.MerchantResults GetAllMerchantDataByMetaPartnerSubTypeCode(string metaPartnerSubTypeCode, string sortColumn, string sortDirection)
		{
			Components.Customers.MerchantResults results = new Components.Customers.MerchantResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Customers.MerchantManager.GetAllMerchantDataByMetaPartnerSubTypeCode(MOD.Data.DataHelper.GetInt(metaPartnerSubTypeCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Merchant data by criteria.</summary>
		///
		/// <param name="localeCode">A key for Merchant items to be fetched</param>
		/// <param name="currencyCode">A key for Merchant items to be fetched</param>
		/// <param name="dateFormatCode">A key for Merchant items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Merchant items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Merchant items to be fetched</param>
		/// <param name="metaPartnerName">A key for Merchant items to be fetched</param>
         /// <param name="startIndex">Start Index (beginning at 1)</param>
         /// <param name="pageSize">Page Size</param>
         /// <param name="maximumListSize">Maximum List Size</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.MerchantResults GetManyMerchantDataByCriteria(string localeCode, string currencyCode, string dateFormatCode, string lastModifiedDateStart, string lastModifiedDateEnd, string metaPartnerName, int startIndex, int pageSize, int maximumListSize, string sortColumn, string sortDirection)
		{
			Components.Customers.MerchantResults results = new Components.Customers.MerchantResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				int totalRecords = 0;
				bool maximumListSizeExceeded = false;
				results.Results = BLL.Customers.MerchantManager.GetManyMerchantDataByCriteria(MOD.Data.SearchHelper.GetInt(localeCode), MOD.Data.SearchHelper.GetInt(currencyCode), MOD.Data.SearchHelper.GetInt(dateFormatCode), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateStart), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateEnd), MOD.Data.SearchHelper.GetString(metaPartnerName), out totalRecords, out maximumListSizeExceeded, Globals.getDataOptions(sortColumn, sortDirection, startIndex, pageSize, maximumListSize));
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
		/// <summary>This web service method gets a single Merchant by an index.</summary>
		///
		/// <param name="metaPartnerID">The index for Merchant to be fetched</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.MerchantResults GetOneMerchant(string metaPartnerID, string sortColumn, string sortDirection)
		{
			Components.Customers.MerchantResults results = new Components.Customers.MerchantResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Customers.Merchant item =  BLL.Customers.MerchantManager.GetOneMerchant(MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method updates Merchant data.</summary>
		///
		/// <param name="item">The Merchant to be managed.</param>
		/// <param name="performCascadeOperation">Flag, indicating if a cascade operation should be performed on the Merchant item.</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.MerchantResults UpdateOneMerchant(BLL.Customers.Merchant item, bool performCascadeOperation)
		{
			Components.Customers.MerchantResults results = new Components.Customers.MerchantResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Customers.MerchantManager.UpdateOneMerchant(item, performCascadeOperation);
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
		public MerchantManager()
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