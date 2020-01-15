
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
	/// <summary>This class is used to manage CurrencyConversion related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public class CurrencyConversionManager : System.Web.Services.WebService
	{
		#region "Service Methods"
		// ------------------------------------------------------------------
		/// <summary>This web service method deletes all CurrencyConversion data by a key.</summary>
		///
		/// <param name="convertFromCurrencyCode">A key for CurrencyConversion items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.CurrencyConversionResults DeleteAllCurrencyConversionDataByConvertFromCurrencyCode(int convertFromCurrencyCode)
		{
			Components.Accounts.CurrencyConversionResults results = new Components.Accounts.CurrencyConversionResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.CurrencyConversionManager.DeleteAllCurrencyConversionDataByConvertFromCurrencyCode(convertFromCurrencyCode);
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
		/// <summary>This web service method deletes all CurrencyConversion data by a key.</summary>
		///
		/// <param name="convertToCurrencyCode">A key for CurrencyConversion items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.CurrencyConversionResults DeleteAllCurrencyConversionDataByConvertToCurrencyCode(int convertToCurrencyCode)
		{
			Components.Accounts.CurrencyConversionResults results = new Components.Accounts.CurrencyConversionResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.CurrencyConversionManager.DeleteAllCurrencyConversionDataByConvertToCurrencyCode(convertToCurrencyCode);
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
		/// <summary>This web service method deletes all CurrencyConversion data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for CurrencyConversion items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.CurrencyConversionResults DeleteAllCurrencyConversionDataByMetaPartnerID(string metaPartnerID)
		{
			Components.Accounts.CurrencyConversionResults results = new Components.Accounts.CurrencyConversionResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.CurrencyConversionManager.DeleteAllCurrencyConversionDataByMetaPartnerID(MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid));
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
		/// <summary>This web service method deletes CurrencyConversion data.</summary>
		///
		/// <param name="currencyConversionID">A property of CurrencyConversion item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.CurrencyConversionResults DeleteOneCurrencyConversion(string currencyConversionID)
		{
			Components.Accounts.CurrencyConversionResults results = new Components.Accounts.CurrencyConversionResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.CurrencyConversion item = new BLL.Accounts.CurrencyConversion();
				item.CurrencyConversionID = MOD.Data.DataHelper.GetGuid(currencyConversionID, MOD.Data.DefaultValue.Guid);
				BLL.Accounts.CurrencyConversionManager.DeleteOneCurrencyConversion(item, false);
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
		/// <summary>This web service method gets all CurrencyConversion data.</summary>
		///
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.CurrencyConversionResults GetAllCurrencyConversionData(string sortColumn, string sortDirection)
		{
			Components.Accounts.CurrencyConversionResults results = new Components.Accounts.CurrencyConversionResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Accounts.CurrencyConversionManager.GetAllCurrencyConversionData(Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all CurrencyConversion data by a key.</summary>
		///
		/// <param name="convertFromCurrencyCode">A key for CurrencyConversion items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.CurrencyConversionResults GetAllCurrencyConversionDataByConvertFromCurrencyCode(string convertFromCurrencyCode, string sortColumn, string sortDirection)
		{
			Components.Accounts.CurrencyConversionResults results = new Components.Accounts.CurrencyConversionResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Accounts.CurrencyConversionManager.GetAllCurrencyConversionDataByConvertFromCurrencyCode(MOD.Data.DataHelper.GetInt(convertFromCurrencyCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all CurrencyConversion data by a key.</summary>
		///
		/// <param name="convertToCurrencyCode">A key for CurrencyConversion items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.CurrencyConversionResults GetAllCurrencyConversionDataByConvertToCurrencyCode(string convertToCurrencyCode, string sortColumn, string sortDirection)
		{
			Components.Accounts.CurrencyConversionResults results = new Components.Accounts.CurrencyConversionResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Accounts.CurrencyConversionManager.GetAllCurrencyConversionDataByConvertToCurrencyCode(MOD.Data.DataHelper.GetInt(convertToCurrencyCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all CurrencyConversion data by criteria.</summary>
		///
		/// <param name="convertFromCurrencyCode">A key for CurrencyConversion items to be fetched</param>
		/// <param name="convertToCurrencyCode">A key for CurrencyConversion items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for CurrencyConversion items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for CurrencyConversion items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.CurrencyConversionResults GetAllCurrencyConversionDataByCriteria(string convertFromCurrencyCode, string convertToCurrencyCode, string lastModifiedDateStart, string lastModifiedDateEnd, string sortColumn, string sortDirection)
		{
			Components.Accounts.CurrencyConversionResults results = new Components.Accounts.CurrencyConversionResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Accounts.CurrencyConversionManager.GetAllCurrencyConversionDataByCriteria(MOD.Data.SearchHelper.GetInt(convertFromCurrencyCode), MOD.Data.SearchHelper.GetInt(convertToCurrencyCode), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateStart), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateEnd), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all CurrencyConversion data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for CurrencyConversion items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.CurrencyConversionResults GetAllCurrencyConversionDataByMetaPartnerID(string metaPartnerID, string sortColumn, string sortDirection)
		{
			Components.Accounts.CurrencyConversionResults results = new Components.Accounts.CurrencyConversionResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Accounts.CurrencyConversionManager.GetAllCurrencyConversionDataByMetaPartnerID(MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all CurrencyConversion data by criteria.</summary>
		///
		/// <param name="convertFromCurrencyCode">A key for CurrencyConversion items to be fetched</param>
		/// <param name="convertToCurrencyCode">A key for CurrencyConversion items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for CurrencyConversion items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for CurrencyConversion items to be fetched</param>
         /// <param name="startIndex">Start Index (beginning at 1)</param>
         /// <param name="pageSize">Page Size</param>
         /// <param name="maximumListSize">Maximum List Size</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.CurrencyConversionResults GetManyCurrencyConversionDataByCriteria(string convertFromCurrencyCode, string convertToCurrencyCode, string lastModifiedDateStart, string lastModifiedDateEnd, int startIndex, int pageSize, int maximumListSize, string sortColumn, string sortDirection)
		{
			Components.Accounts.CurrencyConversionResults results = new Components.Accounts.CurrencyConversionResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				int totalRecords = 0;
				bool maximumListSizeExceeded = false;
				results.Results = BLL.Accounts.CurrencyConversionManager.GetManyCurrencyConversionDataByCriteria(MOD.Data.SearchHelper.GetInt(convertFromCurrencyCode), MOD.Data.SearchHelper.GetInt(convertToCurrencyCode), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateStart), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateEnd), out totalRecords, out maximumListSizeExceeded, Globals.getDataOptions(sortColumn, sortDirection, startIndex, pageSize, maximumListSize));
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
		/// <summary>This web service method gets a single CurrencyConversion by an index.</summary>
		///
		/// <param name="currencyConversionID">The index for CurrencyConversion to be fetched</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.CurrencyConversionResults GetOneCurrencyConversion(string currencyConversionID, string sortColumn, string sortDirection)
		{
			Components.Accounts.CurrencyConversionResults results = new Components.Accounts.CurrencyConversionResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.CurrencyConversion item =  BLL.Accounts.CurrencyConversionManager.GetOneCurrencyConversion(MOD.Data.DataHelper.GetGuid(currencyConversionID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method inserts or updates CurrencyConversion data.</summary>
		///
		/// <param name="currencyConversionID">A property of CurrencyConversion item to be managed</param>
		/// <param name="convertFromCurrencyCode">A property of CurrencyConversion item to be managed</param>
		/// <param name="convertToCurrencyCode">A property of CurrencyConversion item to be managed</param>
		/// <param name="metaPartnerID">A property of CurrencyConversion item to be managed</param>
		/// <param name="conversionRate">A property of CurrencyConversion item to be managed</param>
		/// <param name="isActive">A property of CurrencyConversion item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Accounts.CurrencyConversionResults UpsertOneCurrencyConversion(string currencyConversionID, int convertFromCurrencyCode, int convertToCurrencyCode, string metaPartnerID, float conversionRate, bool isActive)
		{
			Components.Accounts.CurrencyConversionResults results = new Components.Accounts.CurrencyConversionResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Accounts.CurrencyConversion item = new BLL.Accounts.CurrencyConversion();
				item.CurrencyConversionID = MOD.Data.DataHelper.GetGuid(currencyConversionID, MOD.Data.DefaultValue.Guid);
				item.ConvertFromCurrencyCode = convertFromCurrencyCode;
				item.ConvertToCurrencyCode = convertToCurrencyCode;
				item.MetaPartnerID = MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid);
				item.ConversionRate = conversionRate;
				item.IsActive = isActive;
				BLL.Accounts.CurrencyConversionManager.UpsertOneCurrencyConversion(item, false);
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
		public CurrencyConversionManager()
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