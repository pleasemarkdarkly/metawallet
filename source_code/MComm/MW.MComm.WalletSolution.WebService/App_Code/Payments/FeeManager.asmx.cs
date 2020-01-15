
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
using MW.MComm.WalletSolution.WebService.Payments;
using BLL = MW.MComm.WalletSolution.BLL;
using MW.MComm.WalletSolution.BLL.Payments;
using MOD.Data;
using Utility = MW.MComm.WalletSolution.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
namespace MW.MComm.WalletSolution.WebService.Payments
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage Fee related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public class FeeManager : System.Web.Services.WebService
	{
		#region "Service Methods"
		// ------------------------------------------------------------------
		/// <summary>This web service method inserts Fee data.</summary>
		///
		/// <param name="item">The Fee to be managed.</param>
		/// <param name="performCascadeOperation">Flag, indicating if a cascade operation should be performed on the Fee item.</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Payments.FeeResults AddOneFee(BLL.Payments.Fee item, bool performCascadeOperation)
		{
			Components.Payments.FeeResults results = new Components.Payments.FeeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Payments.FeeManager.AddOneFee(item, performCascadeOperation);
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
		/// <summary>This web service method deletes all Fee data by a key.</summary>
		///
		/// <param name="currencyCode">A key for Fee items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Payments.FeeResults DeleteAllFeeDataByCurrencyCode(int currencyCode)
		{
			Components.Payments.FeeResults results = new Components.Payments.FeeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Payments.FeeManager.DeleteAllFeeDataByCurrencyCode(currencyCode);
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
		/// <summary>This web service method deletes all Fee data by a key.</summary>
		///
		/// <param name="feeTypeCode">A key for Fee items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Payments.FeeResults DeleteAllFeeDataByFeeTypeCode(int feeTypeCode)
		{
			Components.Payments.FeeResults results = new Components.Payments.FeeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Payments.FeeManager.DeleteAllFeeDataByFeeTypeCode(feeTypeCode);
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
		/// <summary>This web service method deletes Fee data.</summary>
		///
		/// <param name="item">The Fee to be deleted.</param>
		/// <param name="performCascadeOperation">Flag, indicating if a cascade delete should be performed on the Fee item.</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Payments.FeeResults DeleteOneFee(BLL.Payments.Fee item, bool performCascadeOperation)
		{
			Components.Payments.FeeResults results = new Components.Payments.FeeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Payments.FeeManager.DeleteOneFee(item, performCascadeOperation);
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
		/// <summary>This web service method gets all Fee data.</summary>
		///
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Payments.FeeResults GetAllFeeData(string sortColumn, string sortDirection)
		{
			Components.Payments.FeeResults results = new Components.Payments.FeeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Payments.FeeManager.GetAllFeeData(Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Fee data by criteria.</summary>
		///
		/// <param name="feeName">A key for Fee items to be fetched</param>
		/// <param name="feeTypeCode">A key for Fee items to be fetched</param>
		/// <param name="currencyCode">A key for Fee items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Fee items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Fee items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Payments.FeeResults GetAllFeeDataByCriteria(string feeName, string feeTypeCode, string currencyCode, string lastModifiedDateStart, string lastModifiedDateEnd, string sortColumn, string sortDirection)
		{
			Components.Payments.FeeResults results = new Components.Payments.FeeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Payments.FeeManager.GetAllFeeDataByCriteria(MOD.Data.SearchHelper.GetString(feeName), MOD.Data.SearchHelper.GetInt(feeTypeCode), MOD.Data.SearchHelper.GetInt(currencyCode), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateStart), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateEnd), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Fee data by a key.</summary>
		///
		/// <param name="currencyCode">A key for Fee items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Payments.FeeResults GetAllFeeDataByCurrencyCode(string currencyCode, string sortColumn, string sortDirection)
		{
			Components.Payments.FeeResults results = new Components.Payments.FeeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Payments.FeeManager.GetAllFeeDataByCurrencyCode(MOD.Data.DataHelper.GetInt(currencyCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Fee data by a key.</summary>
		///
		/// <param name="feeTypeCode">A key for Fee items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Payments.FeeResults GetAllFeeDataByFeeTypeCode(string feeTypeCode, string sortColumn, string sortDirection)
		{
			Components.Payments.FeeResults results = new Components.Payments.FeeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Payments.FeeManager.GetAllFeeDataByFeeTypeCode(MOD.Data.DataHelper.GetInt(feeTypeCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Fee data by criteria.</summary>
		///
		/// <param name="feeName">A key for Fee items to be fetched</param>
		/// <param name="feeTypeCode">A key for Fee items to be fetched</param>
		/// <param name="currencyCode">A key for Fee items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Fee items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Fee items to be fetched</param>
         /// <param name="startIndex">Start Index (beginning at 1)</param>
         /// <param name="pageSize">Page Size</param>
         /// <param name="maximumListSize">Maximum List Size</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Payments.FeeResults GetManyFeeDataByCriteria(string feeName, string feeTypeCode, string currencyCode, string lastModifiedDateStart, string lastModifiedDateEnd, int startIndex, int pageSize, int maximumListSize, string sortColumn, string sortDirection)
		{
			Components.Payments.FeeResults results = new Components.Payments.FeeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				int totalRecords = 0;
				bool maximumListSizeExceeded = false;
				results.Results = BLL.Payments.FeeManager.GetManyFeeDataByCriteria(MOD.Data.SearchHelper.GetString(feeName), MOD.Data.SearchHelper.GetInt(feeTypeCode), MOD.Data.SearchHelper.GetInt(currencyCode), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateStart), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateEnd), out totalRecords, out maximumListSizeExceeded, Globals.getDataOptions(sortColumn, sortDirection, startIndex, pageSize, maximumListSize));
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
		/// <summary>This web service method gets a single Fee by an index.</summary>
		///
		/// <param name="feeCode">The index for Fee to be fetched</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Payments.FeeResults GetOneFee(int feeCode, string sortColumn, string sortDirection)
		{
			Components.Payments.FeeResults results = new Components.Payments.FeeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Payments.Fee item =  BLL.Payments.FeeManager.GetOneFee(MOD.Data.DataHelper.GetInt(feeCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method updates Fee data.</summary>
		///
		/// <param name="item">The Fee to be managed.</param>
		/// <param name="performCascadeOperation">Flag, indicating if a cascade operation should be performed on the Fee item.</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Payments.FeeResults UpdateOneFee(BLL.Payments.Fee item, bool performCascadeOperation)
		{
			Components.Payments.FeeResults results = new Components.Payments.FeeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Payments.FeeManager.UpdateOneFee(item, performCascadeOperation);
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
		public FeeManager()
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