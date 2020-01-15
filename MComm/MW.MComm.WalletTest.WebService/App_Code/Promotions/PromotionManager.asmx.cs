
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
	/// <summary>This class is used to manage Promotion related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public class PromotionManager : System.Web.Services.WebService
	{
		#region "Service Methods"
		// ------------------------------------------------------------------
		/// <summary>This web service method inserts Promotion data.</summary>
		///
		/// <param name="promotionCode">A property of Promotion item to be managed</param>
		/// <param name="promotionName">A property of Promotion item to be managed</param>
		/// <param name="promotionText">A property of Promotion item to be managed</param>
		/// <param name="promotionTypeCode">A property of Promotion item to be managed</param>
		/// <param name="startDate">A property of Promotion item to be managed</param>
		/// <param name="endDate">A property of Promotion item to be managed</param>
		/// <param name="description">A property of Promotion item to be managed</param>
		/// <param name="isActive">A property of Promotion item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Promotions.PromotionResults AddOnePromotion(int promotionCode, string promotionName, string promotionText, int promotionTypeCode, string startDate, string endDate, string description, bool isActive)
		{
			Components.Promotions.PromotionResults results = new Components.Promotions.PromotionResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Promotions.Promotion item = new BLL.Promotions.Promotion();
				item.PromotionCode = promotionCode;
				item.PromotionName = promotionName;
				item.PromotionText = promotionText;
				item.PromotionTypeCode = promotionTypeCode;
				item.StartDate = MOD.Data.DataHelper.GetDateTime(startDate, System.DateTime.MinValue);
				item.EndDate = MOD.Data.DataHelper.GetDateTime(endDate, System.DateTime.MinValue);
				item.Description = description;
				item.IsActive = isActive;
				BLL.Promotions.PromotionManager.AddOnePromotion(item, false);
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
		/// <summary>This web service method deletes all Promotion data by a key.</summary>
		///
		/// <param name="promotionTypeCode">A key for Promotion items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Promotions.PromotionResults DeleteAllPromotionDataByPromotionTypeCode(int promotionTypeCode)
		{
			Components.Promotions.PromotionResults results = new Components.Promotions.PromotionResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Promotions.PromotionManager.DeleteAllPromotionDataByPromotionTypeCode(promotionTypeCode);
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
		/// <summary>This web service method deletes Promotion data.</summary>
		///
		/// <param name="promotionCode">A property of Promotion item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Promotions.PromotionResults DeleteOnePromotion(int promotionCode)
		{
			Components.Promotions.PromotionResults results = new Components.Promotions.PromotionResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Promotions.Promotion item = new BLL.Promotions.Promotion();
				item.PromotionCode = promotionCode;
				BLL.Promotions.PromotionManager.DeleteOnePromotion(item, false);
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
		/// <summary>This web service method gets all Promotion data.</summary>
		///
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Promotions.PromotionResults GetAllPromotionData(string sortColumn, string sortDirection)
		{
			Components.Promotions.PromotionResults results = new Components.Promotions.PromotionResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Promotions.PromotionManager.GetAllPromotionData(Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Promotion data by criteria.</summary>
		///
		/// <param name="promotionName">A key for Promotion items to be fetched</param>
		/// <param name="promotionTypeCode">A key for Promotion items to be fetched</param>
		/// <param name="startDate">A key for Promotion items to be fetched</param>
		/// <param name="endDate">A key for Promotion items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Promotion items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Promotion items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Promotions.PromotionResults GetAllPromotionDataByCriteria(string promotionName, string promotionTypeCode, string startDate, string endDate, string lastModifiedDateStart, string lastModifiedDateEnd, string sortColumn, string sortDirection)
		{
			Components.Promotions.PromotionResults results = new Components.Promotions.PromotionResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Promotions.PromotionManager.GetAllPromotionDataByCriteria(MOD.Data.SearchHelper.GetString(promotionName), MOD.Data.SearchHelper.GetInt(promotionTypeCode), MOD.Data.SearchHelper.GetDateTime(startDate), MOD.Data.SearchHelper.GetDateTime(endDate), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateStart), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateEnd), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Promotion data by a key.</summary>
		///
		/// <param name="promotionTypeCode">A key for Promotion items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Promotions.PromotionResults GetAllPromotionDataByPromotionTypeCode(string promotionTypeCode, string sortColumn, string sortDirection)
		{
			Components.Promotions.PromotionResults results = new Components.Promotions.PromotionResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Promotions.PromotionManager.GetAllPromotionDataByPromotionTypeCode(MOD.Data.DataHelper.GetInt(promotionTypeCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Promotion data by criteria.</summary>
		///
		/// <param name="promotionName">A key for Promotion items to be fetched</param>
		/// <param name="promotionTypeCode">A key for Promotion items to be fetched</param>
		/// <param name="startDate">A key for Promotion items to be fetched</param>
		/// <param name="endDate">A key for Promotion items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Promotion items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Promotion items to be fetched</param>
         /// <param name="startIndex">Start Index (beginning at 1)</param>
         /// <param name="pageSize">Page Size</param>
         /// <param name="maximumListSize">Maximum List Size</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Promotions.PromotionResults GetManyPromotionDataByCriteria(string promotionName, string promotionTypeCode, string startDate, string endDate, string lastModifiedDateStart, string lastModifiedDateEnd, int startIndex, int pageSize, int maximumListSize, string sortColumn, string sortDirection)
		{
			Components.Promotions.PromotionResults results = new Components.Promotions.PromotionResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				int totalRecords = 0;
				bool maximumListSizeExceeded = false;
				results.Results = BLL.Promotions.PromotionManager.GetManyPromotionDataByCriteria(MOD.Data.SearchHelper.GetString(promotionName), MOD.Data.SearchHelper.GetInt(promotionTypeCode), MOD.Data.SearchHelper.GetDateTime(startDate), MOD.Data.SearchHelper.GetDateTime(endDate), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateStart), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateEnd), out totalRecords, out maximumListSizeExceeded, Globals.getDataOptions(sortColumn, sortDirection, startIndex, pageSize, maximumListSize));
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
		/// <summary>This web service method gets a single Promotion by an index.</summary>
		///
		/// <param name="promotionCode">The index for Promotion to be fetched</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Promotions.PromotionResults GetOnePromotion(int promotionCode, string sortColumn, string sortDirection)
		{
			Components.Promotions.PromotionResults results = new Components.Promotions.PromotionResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Promotions.Promotion item =  BLL.Promotions.PromotionManager.GetOnePromotion(MOD.Data.DataHelper.GetInt(promotionCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
				// populate desired collections with lazy loading
				bool isAccessed = true;
				isAccessed = item.PromotionCouponList.IsDirty;
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
		/// <summary>This web service method updates Promotion data.</summary>
		///
		/// <param name="promotionCode">A property of Promotion item to be managed</param>
		/// <param name="promotionName">A property of Promotion item to be managed</param>
		/// <param name="promotionText">A property of Promotion item to be managed</param>
		/// <param name="promotionTypeCode">A property of Promotion item to be managed</param>
		/// <param name="startDate">A property of Promotion item to be managed</param>
		/// <param name="endDate">A property of Promotion item to be managed</param>
		/// <param name="description">A property of Promotion item to be managed</param>
		/// <param name="isActive">A property of Promotion item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Promotions.PromotionResults UpdateOnePromotion(int promotionCode, string promotionName, string promotionText, int promotionTypeCode, string startDate, string endDate, string description, bool isActive)
		{
			Components.Promotions.PromotionResults results = new Components.Promotions.PromotionResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Promotions.Promotion item = new BLL.Promotions.Promotion();
				item.PromotionCode = promotionCode;
				item.PromotionName = promotionName;
				item.PromotionText = promotionText;
				item.PromotionTypeCode = promotionTypeCode;
				item.StartDate = MOD.Data.DataHelper.GetDateTime(startDate, System.DateTime.MinValue);
				item.EndDate = MOD.Data.DataHelper.GetDateTime(endDate, System.DateTime.MinValue);
				item.Description = description;
				item.IsActive = isActive;
				BLL.Promotions.PromotionManager.UpdateOnePromotion(item, false);
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
		public PromotionManager()
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