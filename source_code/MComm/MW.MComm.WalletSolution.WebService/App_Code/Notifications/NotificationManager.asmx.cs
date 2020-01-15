
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
using MW.MComm.WalletSolution.WebService.Notifications;
using BLL = MW.MComm.WalletSolution.BLL;
using MW.MComm.WalletSolution.BLL.Notifications;
using MOD.Data;
using Utility = MW.MComm.WalletSolution.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
namespace MW.MComm.WalletSolution.WebService.Notifications
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage Notification related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public class NotificationManager : System.Web.Services.WebService
	{
		#region "Service Methods"
		// ------------------------------------------------------------------
		/// <summary>This web service method inserts Notification data.</summary>
		///
		/// <param name="item">The Notification to be managed.</param>
		/// <param name="performCascadeOperation">Flag, indicating if a cascade operation should be performed on the Notification item.</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Notifications.NotificationResults AddOneNotification(BLL.Notifications.Notification item, bool performCascadeOperation)
		{
			Components.Notifications.NotificationResults results = new Components.Notifications.NotificationResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Notifications.NotificationManager.AddOneNotification(item, performCascadeOperation);
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
		/// <summary>This web service method deletes all Notification data by a key.</summary>
		///
		/// <param name="eventCode">A key for Notification items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Notifications.NotificationResults DeleteAllNotificationDataByEventCode(int eventCode)
		{
			Components.Notifications.NotificationResults results = new Components.Notifications.NotificationResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Notifications.NotificationManager.DeleteAllNotificationDataByEventCode(eventCode);
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
		/// <summary>This web service method deletes Notification data.</summary>
		///
		/// <param name="item">The Notification to be deleted.</param>
		/// <param name="performCascadeOperation">Flag, indicating if a cascade delete should be performed on the Notification item.</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Notifications.NotificationResults DeleteOneNotification(BLL.Notifications.Notification item, bool performCascadeOperation)
		{
			Components.Notifications.NotificationResults results = new Components.Notifications.NotificationResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Notifications.NotificationManager.DeleteOneNotification(item, performCascadeOperation);
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
		/// <summary>This web service method gets all Notification data.</summary>
		///
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Notifications.NotificationResults GetAllNotificationData(string sortColumn, string sortDirection)
		{
			Components.Notifications.NotificationResults results = new Components.Notifications.NotificationResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Notifications.NotificationManager.GetAllNotificationData(Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Notification data by criteria.</summary>
		///
		/// <param name="notificationName">A key for Notification items to be fetched</param>
		/// <param name="eventCode">A key for Notification items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Notification items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Notification items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Notifications.NotificationResults GetAllNotificationDataByCriteria(string notificationName, string eventCode, string lastModifiedDateStart, string lastModifiedDateEnd, string sortColumn, string sortDirection)
		{
			Components.Notifications.NotificationResults results = new Components.Notifications.NotificationResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Notifications.NotificationManager.GetAllNotificationDataByCriteria(MOD.Data.SearchHelper.GetString(notificationName), MOD.Data.SearchHelper.GetInt(eventCode), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateStart), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateEnd), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Notification data by a key.</summary>
		///
		/// <param name="eventCode">A key for Notification items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Notifications.NotificationResults GetAllNotificationDataByEventCode(string eventCode, string sortColumn, string sortDirection)
		{
			Components.Notifications.NotificationResults results = new Components.Notifications.NotificationResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Notifications.NotificationManager.GetAllNotificationDataByEventCode(MOD.Data.DataHelper.GetInt(eventCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all Notification data by criteria.</summary>
		///
		/// <param name="notificationName">A key for Notification items to be fetched</param>
		/// <param name="eventCode">A key for Notification items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Notification items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Notification items to be fetched</param>
         /// <param name="startIndex">Start Index (beginning at 1)</param>
         /// <param name="pageSize">Page Size</param>
         /// <param name="maximumListSize">Maximum List Size</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Notifications.NotificationResults GetManyNotificationDataByCriteria(string notificationName, string eventCode, string lastModifiedDateStart, string lastModifiedDateEnd, int startIndex, int pageSize, int maximumListSize, string sortColumn, string sortDirection)
		{
			Components.Notifications.NotificationResults results = new Components.Notifications.NotificationResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				int totalRecords = 0;
				bool maximumListSizeExceeded = false;
				results.Results = BLL.Notifications.NotificationManager.GetManyNotificationDataByCriteria(MOD.Data.SearchHelper.GetString(notificationName), MOD.Data.SearchHelper.GetInt(eventCode), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateStart), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateEnd), out totalRecords, out maximumListSizeExceeded, Globals.getDataOptions(sortColumn, sortDirection, startIndex, pageSize, maximumListSize));
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
		/// <summary>This web service method gets a single Notification by an index.</summary>
		///
		/// <param name="notificationCode">The index for Notification to be fetched</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Notifications.NotificationResults GetOneNotification(int notificationCode, string sortColumn, string sortDirection)
		{
			Components.Notifications.NotificationResults results = new Components.Notifications.NotificationResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Notifications.Notification item =  BLL.Notifications.NotificationManager.GetOneNotification(MOD.Data.DataHelper.GetInt(notificationCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
				// populate desired collections with lazy loading
				bool isAccessed = true;
				isAccessed = item.NotificationTemplateList.IsDirty;
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
		/// <summary>This web service method updates Notification data.</summary>
		///
		/// <param name="item">The Notification to be managed.</param>
		/// <param name="performCascadeOperation">Flag, indicating if a cascade operation should be performed on the Notification item.</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Notifications.NotificationResults UpdateOneNotification(BLL.Notifications.Notification item, bool performCascadeOperation)
		{
			Components.Notifications.NotificationResults results = new Components.Notifications.NotificationResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Notifications.NotificationManager.UpdateOneNotification(item, performCascadeOperation);
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
		public NotificationManager()
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