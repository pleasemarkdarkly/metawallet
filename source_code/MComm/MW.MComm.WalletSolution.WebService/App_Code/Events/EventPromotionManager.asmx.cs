
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
using MW.MComm.WalletSolution.WebService.Events;
using BLL = MW.MComm.WalletSolution.BLL;
using MW.MComm.WalletSolution.BLL.Events;
using MOD.Data;
using Utility = MW.MComm.WalletSolution.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
namespace MW.MComm.WalletSolution.WebService.Events
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage EventPromotion related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public class EventPromotionManager : System.Web.Services.WebService
	{
		#region "Service Methods"
		// ------------------------------------------------------------------
		/// <summary>This web service method inserts EventPromotion data.</summary>
		///
		/// <param name="item">The EventPromotion to be managed.</param>
		/// <param name="performCascadeOperation">Flag, indicating if a cascade operation should be performed on the EventPromotion item.</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Events.EventPromotionResults AddOneEventPromotion(BLL.Events.EventPromotion item, bool performCascadeOperation)
		{
			Components.Events.EventPromotionResults results = new Components.Events.EventPromotionResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Events.EventPromotionManager.AddOneEventPromotion(item, performCascadeOperation);
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
		/// <summary>This web service method deletes all EventPromotion data by a key.</summary>
		///
		/// <param name="eventCode">A key for EventPromotion items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Events.EventPromotionResults DeleteAllEventPromotionDataByEventCode(int eventCode)
		{
			Components.Events.EventPromotionResults results = new Components.Events.EventPromotionResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Events.EventPromotionManager.DeleteAllEventPromotionDataByEventCode(eventCode);
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
		/// <summary>This web service method deletes all EventPromotion data by a key.</summary>
		///
		/// <param name="promotionCode">A key for EventPromotion items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Events.EventPromotionResults DeleteAllEventPromotionDataByPromotionCode(int promotionCode)
		{
			Components.Events.EventPromotionResults results = new Components.Events.EventPromotionResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Events.EventPromotionManager.DeleteAllEventPromotionDataByPromotionCode(promotionCode);
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
		/// <summary>This web service method deletes EventPromotion data.</summary>
		///
		/// <param name="item">The EventPromotion to be deleted.</param>
		/// <param name="performCascadeOperation">Flag, indicating if a cascade delete should be performed on the EventPromotion item.</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Events.EventPromotionResults DeleteOneEventPromotion(BLL.Events.EventPromotion item, bool performCascadeOperation)
		{
			Components.Events.EventPromotionResults results = new Components.Events.EventPromotionResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Events.EventPromotionManager.DeleteOneEventPromotion(item, performCascadeOperation);
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
		/// <summary>This web service method gets all EventPromotion data.</summary>
		///
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Events.EventPromotionResults GetAllEventPromotionData(string sortColumn, string sortDirection)
		{
			Components.Events.EventPromotionResults results = new Components.Events.EventPromotionResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Events.EventPromotionManager.GetAllEventPromotionData(Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all EventPromotion data by a key.</summary>
		///
		/// <param name="eventCode">A key for EventPromotion items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Events.EventPromotionResults GetAllEventPromotionDataByEventCode(string eventCode, string sortColumn, string sortDirection)
		{
			Components.Events.EventPromotionResults results = new Components.Events.EventPromotionResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Events.EventPromotionManager.GetAllEventPromotionDataByEventCode(MOD.Data.DataHelper.GetInt(eventCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all EventPromotion data by a key.</summary>
		///
		/// <param name="promotionCode">A key for EventPromotion items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Events.EventPromotionResults GetAllEventPromotionDataByPromotionCode(string promotionCode, string sortColumn, string sortDirection)
		{
			Components.Events.EventPromotionResults results = new Components.Events.EventPromotionResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Events.EventPromotionManager.GetAllEventPromotionDataByPromotionCode(MOD.Data.DataHelper.GetInt(promotionCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets a single EventPromotion by an index.</summary>
		///
		/// <param name="eventCode">The index for EventPromotion to be fetched</param>
		/// <param name="promotionCode">The index for EventPromotion to be fetched</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Events.EventPromotionResults GetOneEventPromotion(int eventCode, int promotionCode, string sortColumn, string sortDirection)
		{
			Components.Events.EventPromotionResults results = new Components.Events.EventPromotionResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Events.EventPromotion item =  BLL.Events.EventPromotionManager.GetOneEventPromotion(MOD.Data.DataHelper.GetInt(eventCode, MOD.Data.DefaultValue.Int), MOD.Data.DataHelper.GetInt(promotionCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method updates EventPromotion data.</summary>
		///
		/// <param name="item">The EventPromotion to be managed.</param>
		/// <param name="performCascadeOperation">Flag, indicating if a cascade operation should be performed on the EventPromotion item.</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Events.EventPromotionResults UpdateOneEventPromotion(BLL.Events.EventPromotion item, bool performCascadeOperation)
		{
			Components.Events.EventPromotionResults results = new Components.Events.EventPromotionResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Events.EventPromotionManager.UpdateOneEventPromotion(item, performCascadeOperation);
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
		public EventPromotionManager()
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