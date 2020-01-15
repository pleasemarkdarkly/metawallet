
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
using MW.MComm.WalletTest.WebService.Users;
using BLL = MW.MComm.WalletSolution.BLL;
using MW.MComm.WalletSolution.BLL.Users;
using MOD.Data;
using Utility = MW.MComm.WalletSolution.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
namespace MW.MComm.WalletTest.WebService.Users
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage UserRoleActivity related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public class UserRoleActivityManager : System.Web.Services.WebService
	{
		#region "Service Methods"
		// ------------------------------------------------------------------
		/// <summary>This web service method inserts UserRoleActivity data.</summary>
		///
		/// <param name="userRoleCode">A property of UserRoleActivity item to be managed</param>
		/// <param name="activityCode">A property of UserRoleActivity item to be managed</param>
		/// <param name="accessModeCode">A property of UserRoleActivity item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Users.UserRoleActivityResults AddOneUserRoleActivity(int userRoleCode, int activityCode, int accessModeCode)
		{
			Components.Users.UserRoleActivityResults results = new Components.Users.UserRoleActivityResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Users.UserRoleActivity item = new BLL.Users.UserRoleActivity();
				item.UserRoleCode = userRoleCode;
				item.ActivityCode = activityCode;
				item.AccessModeCode = accessModeCode;
				BLL.Users.UserRoleActivityManager.AddOneUserRoleActivity(item, false);
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
		/// <summary>This web service method deletes all UserRoleActivity data by a key.</summary>
		///
		/// <param name="accessModeCode">A key for UserRoleActivity items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Users.UserRoleActivityResults DeleteAllUserRoleActivityDataByAccessModeCode(int accessModeCode)
		{
			Components.Users.UserRoleActivityResults results = new Components.Users.UserRoleActivityResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Users.UserRoleActivityManager.DeleteAllUserRoleActivityDataByAccessModeCode(accessModeCode);
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
		/// <summary>This web service method deletes all UserRoleActivity data by a key.</summary>
		///
		/// <param name="activityCode">A key for UserRoleActivity items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Users.UserRoleActivityResults DeleteAllUserRoleActivityDataByActivityCode(int activityCode)
		{
			Components.Users.UserRoleActivityResults results = new Components.Users.UserRoleActivityResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Users.UserRoleActivityManager.DeleteAllUserRoleActivityDataByActivityCode(activityCode);
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
		/// <summary>This web service method deletes all UserRoleActivity data by a key.</summary>
		///
		/// <param name="userRoleCode">A key for UserRoleActivity items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Users.UserRoleActivityResults DeleteAllUserRoleActivityDataByUserRoleCode(int userRoleCode)
		{
			Components.Users.UserRoleActivityResults results = new Components.Users.UserRoleActivityResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Users.UserRoleActivityManager.DeleteAllUserRoleActivityDataByUserRoleCode(userRoleCode);
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
		/// <summary>This web service method deletes UserRoleActivity data.</summary>
		///
		/// <param name="userRoleCode">A property of UserRoleActivity item to be managed</param>
		/// <param name="activityCode">A property of UserRoleActivity item to be managed</param>
		/// <param name="accessModeCode">A property of UserRoleActivity item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Users.UserRoleActivityResults DeleteOneUserRoleActivity(int userRoleCode, int activityCode, int accessModeCode)
		{
			Components.Users.UserRoleActivityResults results = new Components.Users.UserRoleActivityResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Users.UserRoleActivity item = new BLL.Users.UserRoleActivity();
				item.UserRoleCode = userRoleCode;
				item.ActivityCode = activityCode;
				item.AccessModeCode = accessModeCode;
				BLL.Users.UserRoleActivityManager.DeleteOneUserRoleActivity(item, false);
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
		/// <summary>This web service method gets all UserRoleActivity data.</summary>
		///
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Users.UserRoleActivityResults GetAllUserRoleActivityData(string sortColumn, string sortDirection)
		{
			Components.Users.UserRoleActivityResults results = new Components.Users.UserRoleActivityResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Users.UserRoleActivityManager.GetAllUserRoleActivityData(Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all UserRoleActivity data by a key.</summary>
		///
		/// <param name="accessModeCode">A key for UserRoleActivity items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Users.UserRoleActivityResults GetAllUserRoleActivityDataByAccessModeCode(string accessModeCode, string sortColumn, string sortDirection)
		{
			Components.Users.UserRoleActivityResults results = new Components.Users.UserRoleActivityResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Users.UserRoleActivityManager.GetAllUserRoleActivityDataByAccessModeCode(MOD.Data.DataHelper.GetInt(accessModeCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all UserRoleActivity data by a key.</summary>
		///
		/// <param name="activityCode">A key for UserRoleActivity items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Users.UserRoleActivityResults GetAllUserRoleActivityDataByActivityCode(string activityCode, string sortColumn, string sortDirection)
		{
			Components.Users.UserRoleActivityResults results = new Components.Users.UserRoleActivityResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Users.UserRoleActivityManager.GetAllUserRoleActivityDataByActivityCode(MOD.Data.DataHelper.GetInt(activityCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all UserRoleActivity data by a key.</summary>
		///
		/// <param name="userRoleCode">A key for UserRoleActivity items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Users.UserRoleActivityResults GetAllUserRoleActivityDataByUserRoleCode(string userRoleCode, string sortColumn, string sortDirection)
		{
			Components.Users.UserRoleActivityResults results = new Components.Users.UserRoleActivityResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Users.UserRoleActivityManager.GetAllUserRoleActivityDataByUserRoleCode(MOD.Data.DataHelper.GetInt(userRoleCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets a single UserRoleActivity by an index.</summary>
		///
		/// <param name="userRoleCode">The index for UserRoleActivity to be fetched</param>
		/// <param name="activityCode">The index for UserRoleActivity to be fetched</param>
		/// <param name="accessModeCode">The index for UserRoleActivity to be fetched</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Users.UserRoleActivityResults GetOneUserRoleActivity(int userRoleCode, int activityCode, int accessModeCode, string sortColumn, string sortDirection)
		{
			Components.Users.UserRoleActivityResults results = new Components.Users.UserRoleActivityResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Users.UserRoleActivity item =  BLL.Users.UserRoleActivityManager.GetOneUserRoleActivity(MOD.Data.DataHelper.GetInt(userRoleCode, MOD.Data.DefaultValue.Int), MOD.Data.DataHelper.GetInt(activityCode, MOD.Data.DefaultValue.Int), MOD.Data.DataHelper.GetInt(accessModeCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method updates UserRoleActivity data.</summary>
		///
		/// <param name="userRoleCode">A property of UserRoleActivity item to be managed</param>
		/// <param name="activityCode">A property of UserRoleActivity item to be managed</param>
		/// <param name="accessModeCode">A property of UserRoleActivity item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Users.UserRoleActivityResults UpdateOneUserRoleActivity(int userRoleCode, int activityCode, int accessModeCode)
		{
			Components.Users.UserRoleActivityResults results = new Components.Users.UserRoleActivityResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Users.UserRoleActivity item = new BLL.Users.UserRoleActivity();
				item.UserRoleCode = userRoleCode;
				item.ActivityCode = activityCode;
				item.AccessModeCode = accessModeCode;
				BLL.Users.UserRoleActivityManager.UpdateOneUserRoleActivity(item, false);
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
		public UserRoleActivityManager()
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