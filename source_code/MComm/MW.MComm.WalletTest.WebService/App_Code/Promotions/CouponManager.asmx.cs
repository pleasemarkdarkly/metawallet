
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
	/// <summary>This class is used to manage Coupon related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public class CouponManager : System.Web.Services.WebService
	{
		#region "Service Methods"
		// ------------------------------------------------------------------
		/// <summary>This web service method inserts Coupon data.</summary>
		///
		/// <param name="couponCode">A property of Coupon item to be managed</param>
		/// <param name="couponName">A property of Coupon item to be managed</param>
		/// <param name="couponText">A property of Coupon item to be managed</param>
		/// <param name="couponTypeCode">A property of Coupon item to be managed</param>
		/// <param name="discountTypeCode">A property of Coupon item to be managed</param>
		/// <param name="discountAmount">A property of Coupon item to be managed</param>
		/// <param name="triggerAmount">A property of Coupon item to be managed</param>
		/// <param name="currencyCode">A property of Coupon item to be managed</param>
		/// <param name="daysToExpire">A property of Coupon item to be managed</param>
		/// <param name="isFeeEnabled">A property of Coupon item to be managed</param>
		/// <param name="isPaymentEnabled">A property of Coupon item to be managed</param>
		/// <param name="description">A property of Coupon item to be managed</param>
		/// <param name="isActive">A property of Coupon item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Promotions.CouponResults AddOneCoupon(int couponCode, string couponName, string couponText, int couponTypeCode, int discountTypeCode, decimal discountAmount, decimal triggerAmount, int currencyCode, int daysToExpire, bool isFeeEnabled, bool isPaymentEnabled, string description, bool isActive)
		{
			Components.Promotions.CouponResults results = new Components.Promotions.CouponResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Promotions.Coupon item = new BLL.Promotions.Coupon();
				item.CouponCode = couponCode;
				item.CouponName = couponName;
				item.CouponText = couponText;
				item.CouponTypeCode = couponTypeCode;
				item.DiscountTypeCode = discountTypeCode;
				item.DiscountAmount = discountAmount;
				item.TriggerAmount = triggerAmount;
				item.CurrencyCode = currencyCode;
				item.DaysToExpire = daysToExpire;
				item.IsFeeEnabled = isFeeEnabled;
				item.IsPaymentEnabled = isPaymentEnabled;
				item.Description = description;
				item.IsActive = isActive;
				BLL.Promotions.CouponManager.AddOneCoupon(item, false);
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
		/// <summary>This web service method deletes all Coupon data by a key.</summary>
		///
		/// <param name="couponTypeCode">A key for Coupon items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Promotions.CouponResults DeleteAllCouponDataByCouponTypeCode(int couponTypeCode)
		{
			Components.Promotions.CouponResults results = new Components.Promotions.CouponResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Promotions.CouponManager.DeleteAllCouponDataByCouponTypeCode(couponTypeCode);
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
		/// <summary>This web service method deletes all Coupon data by a key.</summary>
		///
		/// <param name="currencyCode">A key for Coupon items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Promotions.CouponResults DeleteAllCouponDataByCurrencyCode(int currencyCode)
		{
			Components.Promotions.CouponResults results = new Components.Promotions.CouponResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Promotions.CouponManager.DeleteAllCouponDataByCurrencyCode(currencyCode);
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
		/// <summary>This web service method deletes all Coupon data by a key.</summary>
		///
		/// <param name="discountTypeCode">A key for Coupon items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Promotions.CouponResults DeleteAllCouponDataByDiscountTypeCode(int discountTypeCode)
		{
			Components.Promotions.CouponResults results = new Components.Promotions.CouponResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Promotions.CouponManager.DeleteAllCouponDataByDiscountTypeCode(discountTypeCode);
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
		/// <summary>This web service method deletes Coupon data.</summary>
		///
		/// <param name="couponCode">A property of Coupon item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Promotions.CouponResults DeleteOneCoupon(int couponCode)
		{
			Components.Promotions.CouponResults results = new Components.Promotions.CouponResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Promotions.Coupon item = new BLL.Promotions.Coupon();
				item.CouponCode = couponCode;
				BLL.Promotions.CouponManager.DeleteOneCoupon(item, false);
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
		/// <summary>This web service method gets all Coupon data.</summary>
		///
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Promotions.CouponResults GetAllCouponData(string sortColumn, string sortDirection)
		{
			Components.Promotions.CouponResults results = new Components.Promotions.CouponResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Promotions.CouponManager.GetAllCouponData(Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Coupon data by a key.</summary>
		///
		/// <param name="couponTypeCode">A key for Coupon items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Promotions.CouponResults GetAllCouponDataByCouponTypeCode(string couponTypeCode, string sortColumn, string sortDirection)
		{
			Components.Promotions.CouponResults results = new Components.Promotions.CouponResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Promotions.CouponManager.GetAllCouponDataByCouponTypeCode(MOD.Data.DataHelper.GetInt(couponTypeCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Coupon data by criteria.</summary>
		///
		/// <param name="couponName">A key for Coupon items to be fetched</param>
		/// <param name="couponTypeCode">A key for Coupon items to be fetched</param>
		/// <param name="discountTypeCode">A key for Coupon items to be fetched</param>
		/// <param name="currencyCode">A key for Coupon items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Coupon items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Coupon items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Promotions.CouponResults GetAllCouponDataByCriteria(string couponName, string couponTypeCode, string discountTypeCode, string currencyCode, string lastModifiedDateStart, string lastModifiedDateEnd, string sortColumn, string sortDirection)
		{
			Components.Promotions.CouponResults results = new Components.Promotions.CouponResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Promotions.CouponManager.GetAllCouponDataByCriteria(MOD.Data.SearchHelper.GetString(couponName), MOD.Data.SearchHelper.GetInt(couponTypeCode), MOD.Data.SearchHelper.GetInt(discountTypeCode), MOD.Data.SearchHelper.GetInt(currencyCode), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateStart), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateEnd), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Coupon data by a key.</summary>
		///
		/// <param name="currencyCode">A key for Coupon items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Promotions.CouponResults GetAllCouponDataByCurrencyCode(string currencyCode, string sortColumn, string sortDirection)
		{
			Components.Promotions.CouponResults results = new Components.Promotions.CouponResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Promotions.CouponManager.GetAllCouponDataByCurrencyCode(MOD.Data.DataHelper.GetInt(currencyCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Coupon data by a key.</summary>
		///
		/// <param name="discountTypeCode">A key for Coupon items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Promotions.CouponResults GetAllCouponDataByDiscountTypeCode(string discountTypeCode, string sortColumn, string sortDirection)
		{
			Components.Promotions.CouponResults results = new Components.Promotions.CouponResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Promotions.CouponManager.GetAllCouponDataByDiscountTypeCode(MOD.Data.DataHelper.GetInt(discountTypeCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Coupon data by criteria.</summary>
		///
		/// <param name="couponName">A key for Coupon items to be fetched</param>
		/// <param name="couponTypeCode">A key for Coupon items to be fetched</param>
		/// <param name="discountTypeCode">A key for Coupon items to be fetched</param>
		/// <param name="currencyCode">A key for Coupon items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Coupon items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Coupon items to be fetched</param>
         /// <param name="startIndex">Start Index (beginning at 1)</param>
         /// <param name="pageSize">Page Size</param>
         /// <param name="maximumListSize">Maximum List Size</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Promotions.CouponResults GetManyCouponDataByCriteria(string couponName, string couponTypeCode, string discountTypeCode, string currencyCode, string lastModifiedDateStart, string lastModifiedDateEnd, int startIndex, int pageSize, int maximumListSize, string sortColumn, string sortDirection)
		{
			Components.Promotions.CouponResults results = new Components.Promotions.CouponResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				int totalRecords = 0;
				bool maximumListSizeExceeded = false;
				results.Results = BLL.Promotions.CouponManager.GetManyCouponDataByCriteria(MOD.Data.SearchHelper.GetString(couponName), MOD.Data.SearchHelper.GetInt(couponTypeCode), MOD.Data.SearchHelper.GetInt(discountTypeCode), MOD.Data.SearchHelper.GetInt(currencyCode), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateStart), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateEnd), out totalRecords, out maximumListSizeExceeded, Globals.getDataOptions(sortColumn, sortDirection, startIndex, pageSize, maximumListSize));
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
		/// <summary>This web service method gets a single Coupon by an index.</summary>
		///
		/// <param name="couponCode">The index for Coupon to be fetched</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Promotions.CouponResults GetOneCoupon(int couponCode, string sortColumn, string sortDirection)
		{
			Components.Promotions.CouponResults results = new Components.Promotions.CouponResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Promotions.Coupon item =  BLL.Promotions.CouponManager.GetOneCoupon(MOD.Data.DataHelper.GetInt(couponCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method updates Coupon data.</summary>
		///
		/// <param name="couponCode">A property of Coupon item to be managed</param>
		/// <param name="couponName">A property of Coupon item to be managed</param>
		/// <param name="couponText">A property of Coupon item to be managed</param>
		/// <param name="couponTypeCode">A property of Coupon item to be managed</param>
		/// <param name="discountTypeCode">A property of Coupon item to be managed</param>
		/// <param name="discountAmount">A property of Coupon item to be managed</param>
		/// <param name="triggerAmount">A property of Coupon item to be managed</param>
		/// <param name="currencyCode">A property of Coupon item to be managed</param>
		/// <param name="daysToExpire">A property of Coupon item to be managed</param>
		/// <param name="isFeeEnabled">A property of Coupon item to be managed</param>
		/// <param name="isPaymentEnabled">A property of Coupon item to be managed</param>
		/// <param name="description">A property of Coupon item to be managed</param>
		/// <param name="isActive">A property of Coupon item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Promotions.CouponResults UpdateOneCoupon(int couponCode, string couponName, string couponText, int couponTypeCode, int discountTypeCode, decimal discountAmount, decimal triggerAmount, int currencyCode, int daysToExpire, bool isFeeEnabled, bool isPaymentEnabled, string description, bool isActive)
		{
			Components.Promotions.CouponResults results = new Components.Promotions.CouponResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Promotions.Coupon item = new BLL.Promotions.Coupon();
				item.CouponCode = couponCode;
				item.CouponName = couponName;
				item.CouponText = couponText;
				item.CouponTypeCode = couponTypeCode;
				item.DiscountTypeCode = discountTypeCode;
				item.DiscountAmount = discountAmount;
				item.TriggerAmount = triggerAmount;
				item.CurrencyCode = currencyCode;
				item.DaysToExpire = daysToExpire;
				item.IsFeeEnabled = isFeeEnabled;
				item.IsPaymentEnabled = isPaymentEnabled;
				item.Description = description;
				item.IsActive = isActive;
				BLL.Promotions.CouponManager.UpdateOneCoupon(item, false);
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
		public CouponManager()
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