
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
using MW.MComm.WalletTest.WebService.Promotions;
using BLL = MW.MComm.WalletSolution.BLL;
using MW.MComm.WalletSolution.BLL.Promotions;
using MOD.Data;
using Utility = MW.MComm.WalletSolution.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
namespace MW.MComm.WalletTest.WebService.Promotions
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage MetaPartnerCoupon related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public class MetaPartnerCouponManager : System.Web.Services.WebService
	{
		#region "Service Methods"
		// ------------------------------------------------------------------
		/// <summary>This web service method deletes all MetaPartnerCoupon data by a key.</summary>
		///
		/// <param name="couponCode">A key for MetaPartnerCoupon items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Promotions.MetaPartnerCouponResults DeleteAllMetaPartnerCouponDataByCouponCode(int couponCode)
		{
			Components.Promotions.MetaPartnerCouponResults results = new Components.Promotions.MetaPartnerCouponResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Promotions.MetaPartnerCouponManager.DeleteAllMetaPartnerCouponDataByCouponCode(couponCode);
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
		/// <summary>This web service method deletes all MetaPartnerCoupon data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for MetaPartnerCoupon items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Promotions.MetaPartnerCouponResults DeleteAllMetaPartnerCouponDataByMetaPartnerID(string metaPartnerID)
		{
			Components.Promotions.MetaPartnerCouponResults results = new Components.Promotions.MetaPartnerCouponResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Promotions.MetaPartnerCouponManager.DeleteAllMetaPartnerCouponDataByMetaPartnerID(MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid));
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
		/// <summary>This web service method deletes MetaPartnerCoupon data.</summary>
		///
		/// <param name="metaPartnerCouponID">A property of MetaPartnerCoupon item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Promotions.MetaPartnerCouponResults DeleteOneMetaPartnerCoupon(string metaPartnerCouponID)
		{
			Components.Promotions.MetaPartnerCouponResults results = new Components.Promotions.MetaPartnerCouponResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Promotions.MetaPartnerCoupon item = new BLL.Promotions.MetaPartnerCoupon();
				item.MetaPartnerCouponID = MOD.Data.DataHelper.GetGuid(metaPartnerCouponID, MOD.Data.DefaultValue.Guid);
				BLL.Promotions.MetaPartnerCouponManager.DeleteOneMetaPartnerCoupon(item, false);
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
		/// <summary>This web service method gets all MetaPartnerCoupon data.</summary>
		///
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Promotions.MetaPartnerCouponResults GetAllMetaPartnerCouponData(string sortColumn, string sortDirection)
		{
			Components.Promotions.MetaPartnerCouponResults results = new Components.Promotions.MetaPartnerCouponResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Promotions.MetaPartnerCouponManager.GetAllMetaPartnerCouponData(Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all MetaPartnerCoupon data by a key.</summary>
		///
		/// <param name="couponCode">A key for MetaPartnerCoupon items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Promotions.MetaPartnerCouponResults GetAllMetaPartnerCouponDataByCouponCode(string couponCode, string sortColumn, string sortDirection)
		{
			Components.Promotions.MetaPartnerCouponResults results = new Components.Promotions.MetaPartnerCouponResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Promotions.MetaPartnerCouponManager.GetAllMetaPartnerCouponDataByCouponCode(MOD.Data.DataHelper.GetInt(couponCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all MetaPartnerCoupon data by criteria.</summary>
		///
		/// <param name="couponCode">A key for MetaPartnerCoupon items to be fetched</param>
		/// <param name="startDate">A key for MetaPartnerCoupon items to be fetched</param>
		/// <param name="endDate">A key for MetaPartnerCoupon items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for MetaPartnerCoupon items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for MetaPartnerCoupon items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Promotions.MetaPartnerCouponResults GetAllMetaPartnerCouponDataByCriteria(string couponCode, string startDate, string endDate, string lastModifiedDateStart, string lastModifiedDateEnd, string sortColumn, string sortDirection)
		{
			Components.Promotions.MetaPartnerCouponResults results = new Components.Promotions.MetaPartnerCouponResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Promotions.MetaPartnerCouponManager.GetAllMetaPartnerCouponDataByCriteria(MOD.Data.SearchHelper.GetInt(couponCode), MOD.Data.SearchHelper.GetDateTime(startDate), MOD.Data.SearchHelper.GetDateTime(endDate), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateStart), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateEnd), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all MetaPartnerCoupon data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for MetaPartnerCoupon items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Promotions.MetaPartnerCouponResults GetAllMetaPartnerCouponDataByMetaPartnerID(string metaPartnerID, string sortColumn, string sortDirection)
		{
			Components.Promotions.MetaPartnerCouponResults results = new Components.Promotions.MetaPartnerCouponResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Promotions.MetaPartnerCouponManager.GetAllMetaPartnerCouponDataByMetaPartnerID(MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all MetaPartnerCoupon data by criteria.</summary>
		///
		/// <param name="couponCode">A key for MetaPartnerCoupon items to be fetched</param>
		/// <param name="startDate">A key for MetaPartnerCoupon items to be fetched</param>
		/// <param name="endDate">A key for MetaPartnerCoupon items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for MetaPartnerCoupon items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for MetaPartnerCoupon items to be fetched</param>
         /// <param name="startIndex">Start Index (beginning at 1)</param>
         /// <param name="pageSize">Page Size</param>
         /// <param name="maximumListSize">Maximum List Size</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Promotions.MetaPartnerCouponResults GetManyMetaPartnerCouponDataByCriteria(string couponCode, string startDate, string endDate, string lastModifiedDateStart, string lastModifiedDateEnd, int startIndex, int pageSize, int maximumListSize, string sortColumn, string sortDirection)
		{
			Components.Promotions.MetaPartnerCouponResults results = new Components.Promotions.MetaPartnerCouponResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				int totalRecords = 0;
				bool maximumListSizeExceeded = false;
				results.Results = BLL.Promotions.MetaPartnerCouponManager.GetManyMetaPartnerCouponDataByCriteria(MOD.Data.SearchHelper.GetInt(couponCode), MOD.Data.SearchHelper.GetDateTime(startDate), MOD.Data.SearchHelper.GetDateTime(endDate), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateStart), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateEnd), out totalRecords, out maximumListSizeExceeded, Globals.getDataOptions(sortColumn, sortDirection, startIndex, pageSize, maximumListSize));
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
		/// <summary>This web service method gets a single MetaPartnerCoupon by an index.</summary>
		///
		/// <param name="metaPartnerCouponID">The index for MetaPartnerCoupon to be fetched</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Promotions.MetaPartnerCouponResults GetOneMetaPartnerCoupon(string metaPartnerCouponID, string sortColumn, string sortDirection)
		{
			Components.Promotions.MetaPartnerCouponResults results = new Components.Promotions.MetaPartnerCouponResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Promotions.MetaPartnerCoupon item =  BLL.Promotions.MetaPartnerCouponManager.GetOneMetaPartnerCoupon(MOD.Data.DataHelper.GetGuid(metaPartnerCouponID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets a single MetaPartnerCoupon by an index.</summary>
		///
		/// <param name="metaPartnerCouponID">The index for MetaPartnerCoupon to be fetched</param>
		/// <param name="metaPartnerID">The index for MetaPartnerCoupon to be fetched</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Promotions.MetaPartnerCouponResults GetOneMetaPartnerCouponByMetaPartnerCouponIDAndMetaPartnerID(string metaPartnerCouponID, string metaPartnerID, string sortColumn, string sortDirection)
		{
			Components.Promotions.MetaPartnerCouponResults results = new Components.Promotions.MetaPartnerCouponResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Promotions.MetaPartnerCoupon item =  BLL.Promotions.MetaPartnerCouponManager.GetOneMetaPartnerCouponByMetaPartnerCouponIDAndMetaPartnerID(MOD.Data.DataHelper.GetGuid(metaPartnerCouponID, MOD.Data.DefaultValue.Guid), MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method inserts or updates MetaPartnerCoupon data.</summary>
		///
		/// <param name="metaPartnerCouponID">A property of MetaPartnerCoupon item to be managed</param>
		/// <param name="metaPartnerID">A property of MetaPartnerCoupon item to be managed</param>
		/// <param name="couponCode">A property of MetaPartnerCoupon item to be managed</param>
		/// <param name="originalAmount">A property of MetaPartnerCoupon item to be managed</param>
		/// <param name="balanceAmount">A property of MetaPartnerCoupon item to be managed</param>
		/// <param name="startDate">A property of MetaPartnerCoupon item to be managed</param>
		/// <param name="endDate">A property of MetaPartnerCoupon item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Promotions.MetaPartnerCouponResults UpsertOneMetaPartnerCoupon(string metaPartnerCouponID, string metaPartnerID, int couponCode, decimal originalAmount, decimal balanceAmount, string startDate, string endDate)
		{
			Components.Promotions.MetaPartnerCouponResults results = new Components.Promotions.MetaPartnerCouponResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Promotions.MetaPartnerCoupon item = new BLL.Promotions.MetaPartnerCoupon();
				item.MetaPartnerCouponID = MOD.Data.DataHelper.GetGuid(metaPartnerCouponID, MOD.Data.DefaultValue.Guid);
				item.MetaPartnerID = MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid);
				item.CouponCode = couponCode;
				item.OriginalAmount = originalAmount;
				item.BalanceAmount = balanceAmount;
				item.StartDate = MOD.Data.DataHelper.GetDateTime(startDate, System.DateTime.MinValue);
				item.EndDate = MOD.Data.DataHelper.GetDateTime(endDate, System.DateTime.MinValue);
				BLL.Promotions.MetaPartnerCouponManager.UpsertOneMetaPartnerCoupon(item, false);
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
		public MetaPartnerCouponManager()
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