
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
using MW.MComm.WalletTest.WebService.Notifications;
using BLL = MW.MComm.WalletSolution.BLL;
using MW.MComm.WalletSolution.BLL.Notifications;
using MOD.Data;
using Utility = MW.MComm.WalletSolution.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
namespace MW.MComm.WalletTest.WebService.Notifications
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage NotificationDeliveryLog related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public class NotificationDeliveryLogManager : System.Web.Services.WebService
	{
		#region "Service Methods"
		// ------------------------------------------------------------------
		/// <summary>This web service method inserts NotificationDeliveryLog data.</summary>
		///
		/// <param name="notificationLogID">A property of NotificationDeliveryLog item to be managed</param>
		/// <param name="metaPartnerID">A property of NotificationDeliveryLog item to be managed</param>
		/// <param name="notificationDeliveryTypeCode">A property of NotificationDeliveryLog item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Notifications.NotificationDeliveryLogResults AddOneNotificationDeliveryLog(string notificationLogID, string metaPartnerID, int notificationDeliveryTypeCode)
		{
			Components.Notifications.NotificationDeliveryLogResults results = new Components.Notifications.NotificationDeliveryLogResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Notifications.NotificationDeliveryLog item = new BLL.Notifications.NotificationDeliveryLog();
				item.NotificationLogID = MOD.Data.DataHelper.GetGuid(notificationLogID, MOD.Data.DefaultValue.Guid);
				item.MetaPartnerID = MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid);
				item.NotificationDeliveryTypeCode = notificationDeliveryTypeCode;
				BLL.Notifications.NotificationDeliveryLogManager.AddOneNotificationDeliveryLog(item, false);
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
		/// <summary>This web service method deletes all NotificationDeliveryLog data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for NotificationDeliveryLog items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Notifications.NotificationDeliveryLogResults DeleteAllNotificationDeliveryLogDataByMetaPartnerID(string metaPartnerID)
		{
			Components.Notifications.NotificationDeliveryLogResults results = new Components.Notifications.NotificationDeliveryLogResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Notifications.NotificationDeliveryLogManager.DeleteAllNotificationDeliveryLogDataByMetaPartnerID(MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid));
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
		/// <summary>This web service method deletes all NotificationDeliveryLog data by a key.</summary>
		///
		/// <param name="notificationDeliveryTypeCode">A key for NotificationDeliveryLog items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Notifications.NotificationDeliveryLogResults DeleteAllNotificationDeliveryLogDataByNotificationDeliveryTypeCode(int notificationDeliveryTypeCode)
		{
			Components.Notifications.NotificationDeliveryLogResults results = new Components.Notifications.NotificationDeliveryLogResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Notifications.NotificationDeliveryLogManager.DeleteAllNotificationDeliveryLogDataByNotificationDeliveryTypeCode(notificationDeliveryTypeCode);
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
		/// <summary>This web service method deletes all NotificationDeliveryLog data by a key.</summary>
		///
		/// <param name="notificationLogID">A key for NotificationDeliveryLog items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Notifications.NotificationDeliveryLogResults DeleteAllNotificationDeliveryLogDataByNotificationLogID(string notificationLogID)
		{
			Components.Notifications.NotificationDeliveryLogResults results = new Components.Notifications.NotificationDeliveryLogResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Notifications.NotificationDeliveryLogManager.DeleteAllNotificationDeliveryLogDataByNotificationLogID(MOD.Data.DataHelper.GetGuid(notificationLogID, MOD.Data.DefaultValue.Guid));
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
		/// <summary>This web service method deletes NotificationDeliveryLog data.</summary>
		///
		/// <param name="notificationLogID">A property of NotificationDeliveryLog item to be managed</param>
		/// <param name="metaPartnerID">A property of NotificationDeliveryLog item to be managed</param>
		/// <param name="notificationDeliveryTypeCode">A property of NotificationDeliveryLog item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Notifications.NotificationDeliveryLogResults DeleteOneNotificationDeliveryLog(string notificationLogID, string metaPartnerID, int notificationDeliveryTypeCode)
		{
			Components.Notifications.NotificationDeliveryLogResults results = new Components.Notifications.NotificationDeliveryLogResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Notifications.NotificationDeliveryLog item = new BLL.Notifications.NotificationDeliveryLog();
				item.NotificationLogID = MOD.Data.DataHelper.GetGuid(notificationLogID, MOD.Data.DefaultValue.Guid);
				item.MetaPartnerID = MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid);
				item.NotificationDeliveryTypeCode = notificationDeliveryTypeCode;
				BLL.Notifications.NotificationDeliveryLogManager.DeleteOneNotificationDeliveryLog(item, false);
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
		/// <summary>This web service method gets all NotificationDeliveryLog data.</summary>
		///
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Notifications.NotificationDeliveryLogResults GetAllNotificationDeliveryLogData(string sortColumn, string sortDirection)
		{
			Components.Notifications.NotificationDeliveryLogResults results = new Components.Notifications.NotificationDeliveryLogResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Notifications.NotificationDeliveryLogManager.GetAllNotificationDeliveryLogData(Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all NotificationDeliveryLog data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for NotificationDeliveryLog items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Notifications.NotificationDeliveryLogResults GetAllNotificationDeliveryLogDataByMetaPartnerID(string metaPartnerID, string sortColumn, string sortDirection)
		{
			Components.Notifications.NotificationDeliveryLogResults results = new Components.Notifications.NotificationDeliveryLogResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Notifications.NotificationDeliveryLogManager.GetAllNotificationDeliveryLogDataByMetaPartnerID(MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all NotificationDeliveryLog data by a key.</summary>
		///
		/// <param name="notificationDeliveryTypeCode">A key for NotificationDeliveryLog items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Notifications.NotificationDeliveryLogResults GetAllNotificationDeliveryLogDataByNotificationDeliveryTypeCode(string notificationDeliveryTypeCode, string sortColumn, string sortDirection)
		{
			Components.Notifications.NotificationDeliveryLogResults results = new Components.Notifications.NotificationDeliveryLogResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Notifications.NotificationDeliveryLogManager.GetAllNotificationDeliveryLogDataByNotificationDeliveryTypeCode(MOD.Data.DataHelper.GetInt(notificationDeliveryTypeCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all NotificationDeliveryLog data by a key.</summary>
		///
		/// <param name="notificationLogID">A key for NotificationDeliveryLog items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Notifications.NotificationDeliveryLogResults GetAllNotificationDeliveryLogDataByNotificationLogID(string notificationLogID, string sortColumn, string sortDirection)
		{
			Components.Notifications.NotificationDeliveryLogResults results = new Components.Notifications.NotificationDeliveryLogResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Notifications.NotificationDeliveryLogManager.GetAllNotificationDeliveryLogDataByNotificationLogID(MOD.Data.DataHelper.GetGuid(notificationLogID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets a single NotificationDeliveryLog by an index.</summary>
		///
		/// <param name="notificationLogID">The index for NotificationDeliveryLog to be fetched</param>
		/// <param name="metaPartnerID">The index for NotificationDeliveryLog to be fetched</param>
		/// <param name="notificationDeliveryTypeCode">The index for NotificationDeliveryLog to be fetched</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Notifications.NotificationDeliveryLogResults GetOneNotificationDeliveryLog(string notificationLogID, string metaPartnerID, int notificationDeliveryTypeCode, string sortColumn, string sortDirection)
		{
			Components.Notifications.NotificationDeliveryLogResults results = new Components.Notifications.NotificationDeliveryLogResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Notifications.NotificationDeliveryLog item =  BLL.Notifications.NotificationDeliveryLogManager.GetOneNotificationDeliveryLog(MOD.Data.DataHelper.GetGuid(notificationLogID, MOD.Data.DefaultValue.Guid), MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid), MOD.Data.DataHelper.GetInt(notificationDeliveryTypeCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method updates NotificationDeliveryLog data.</summary>
		///
		/// <param name="notificationLogID">A property of NotificationDeliveryLog item to be managed</param>
		/// <param name="metaPartnerID">A property of NotificationDeliveryLog item to be managed</param>
		/// <param name="notificationDeliveryTypeCode">A property of NotificationDeliveryLog item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Notifications.NotificationDeliveryLogResults UpdateOneNotificationDeliveryLog(string notificationLogID, string metaPartnerID, int notificationDeliveryTypeCode)
		{
			Components.Notifications.NotificationDeliveryLogResults results = new Components.Notifications.NotificationDeliveryLogResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Notifications.NotificationDeliveryLog item = new BLL.Notifications.NotificationDeliveryLog();
				item.NotificationLogID = MOD.Data.DataHelper.GetGuid(notificationLogID, MOD.Data.DefaultValue.Guid);
				item.MetaPartnerID = MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid);
				item.NotificationDeliveryTypeCode = notificationDeliveryTypeCode;
				BLL.Notifications.NotificationDeliveryLogManager.UpdateOneNotificationDeliveryLog(item, false);
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
		public NotificationDeliveryLogManager()
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