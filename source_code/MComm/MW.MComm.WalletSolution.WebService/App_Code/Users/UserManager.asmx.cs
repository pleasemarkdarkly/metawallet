
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
using MW.MComm.WalletSolution.WebService.Users;
using BLL = MW.MComm.WalletSolution.BLL;
using MW.MComm.WalletSolution.BLL.Users;
using MOD.Data;
using Utility = MW.MComm.WalletSolution.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
namespace MW.MComm.WalletSolution.WebService.Users
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage User related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public class UserManager : System.Web.Services.WebService
	{
		#region "Service Methods"
		// ------------------------------------------------------------------
		/// <summary>This web service method deletes all User data by a key.</summary>
		///
		/// <param name="localeCode">A key for User items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Users.UserResults DeleteAllUserDataByLocaleCode(int localeCode)
		{
			Components.Users.UserResults results = new Components.Users.UserResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Users.UserManager.DeleteAllUserDataByLocaleCode(localeCode);
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
		/// <summary>This web service method deletes User data.</summary>
		///
		/// <param name="item">The User to be deleted.</param>
		/// <param name="performCascadeOperation">Flag, indicating if a cascade delete should be performed on the User item.</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Users.UserResults DeleteOneUser(BLL.Users.User item, bool performCascadeOperation)
		{
			Components.Users.UserResults results = new Components.Users.UserResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Users.UserManager.DeleteOneUser(item, performCascadeOperation);
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
		/// <summary>This web service method gets all User data.</summary>
		///
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Users.UserResults GetAllUserData(string sortColumn, string sortDirection)
		{
			Components.Users.UserResults results = new Components.Users.UserResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Users.UserManager.GetAllUserData(Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all User data by criteria.</summary>
		///
		/// <param name="userName">A key for User items to be fetched</param>
		/// <param name="firstName">A key for User items to be fetched</param>
		/// <param name="lastName">A key for User items to be fetched</param>
		/// <param name="localeCode">A key for User items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for User items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for User items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Users.UserResults GetAllUserDataByCriteria(string userName, string firstName, string lastName, string localeCode, string lastModifiedDateStart, string lastModifiedDateEnd, string sortColumn, string sortDirection)
		{
			Components.Users.UserResults results = new Components.Users.UserResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Users.UserManager.GetAllUserDataByCriteria(MOD.Data.SearchHelper.GetString(userName), MOD.Data.SearchHelper.GetString(firstName), MOD.Data.SearchHelper.GetString(lastName), MOD.Data.SearchHelper.GetInt(localeCode), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateStart), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateEnd), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all User data by a key.</summary>
		///
		/// <param name="localeCode">A key for User items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Users.UserResults GetAllUserDataByLocaleCode(string localeCode, string sortColumn, string sortDirection)
		{
			Components.Users.UserResults results = new Components.Users.UserResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Users.UserManager.GetAllUserDataByLocaleCode(MOD.Data.DataHelper.GetInt(localeCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all User data by criteria.</summary>
		///
		/// <param name="userName">A key for User items to be fetched</param>
		/// <param name="firstName">A key for User items to be fetched</param>
		/// <param name="lastName">A key for User items to be fetched</param>
		/// <param name="localeCode">A key for User items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for User items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for User items to be fetched</param>
         /// <param name="startIndex">Start Index (beginning at 1)</param>
         /// <param name="pageSize">Page Size</param>
         /// <param name="maximumListSize">Maximum List Size</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Users.UserResults GetManyUserDataByCriteria(string userName, string firstName, string lastName, string localeCode, string lastModifiedDateStart, string lastModifiedDateEnd, int startIndex, int pageSize, int maximumListSize, string sortColumn, string sortDirection)
		{
			Components.Users.UserResults results = new Components.Users.UserResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				int totalRecords = 0;
				bool maximumListSizeExceeded = false;
				results.Results = BLL.Users.UserManager.GetManyUserDataByCriteria(MOD.Data.SearchHelper.GetString(userName), MOD.Data.SearchHelper.GetString(firstName), MOD.Data.SearchHelper.GetString(lastName), MOD.Data.SearchHelper.GetInt(localeCode), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateStart), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateEnd), out totalRecords, out maximumListSizeExceeded, Globals.getDataOptions(sortColumn, sortDirection, startIndex, pageSize, maximumListSize));
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
		/// <summary>This web service method gets a single User by an index.</summary>
		///
		/// <param name="userID">The index for User to be fetched</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Users.UserResults GetOneUser(string userID, string sortColumn, string sortDirection)
		{
			Components.Users.UserResults results = new Components.Users.UserResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Users.User item =  BLL.Users.UserManager.GetOneUser(MOD.Data.DataHelper.GetGuid(userID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
				// populate desired collections with lazy loading
				bool isAccessed = true;
				isAccessed = item.UserRoleUserList.IsDirty;
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
		/// <summary>This web service method gets a single User by an index.</summary>
		///
		/// <param name="firstName">The index for User to be fetched</param>
		/// <param name="lastName">The index for User to be fetched</param>
		/// <param name="password">The index for User to be fetched</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Users.UserResults GetOneUserByFirstNameAndLastNameAndPassword(string firstName, string lastName, string password, string sortColumn, string sortDirection)
		{
			Components.Users.UserResults results = new Components.Users.UserResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Users.User item =  BLL.Users.UserManager.GetOneUserByFirstNameAndLastNameAndPassword(MOD.Data.DataHelper.GetString(firstName, MOD.Data.DefaultValue.String), MOD.Data.DataHelper.GetString(lastName, MOD.Data.DefaultValue.String), MOD.Data.DataHelper.GetString(password, MOD.Data.DefaultValue.String), Globals.getDataOptions(sortColumn, sortDirection));
				// populate desired collections with lazy loading
				bool isAccessed = true;
				isAccessed = item.UserRoleUserList.IsDirty;
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
		/// <summary>This web service method gets a single User by an index.</summary>
		///
		/// <param name="userName">The index for User to be fetched</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Users.UserResults GetOneUserByUserName(string userName, string sortColumn, string sortDirection)
		{
			Components.Users.UserResults results = new Components.Users.UserResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Users.User item =  BLL.Users.UserManager.GetOneUserByUserName(MOD.Data.DataHelper.GetString(userName, MOD.Data.DefaultValue.String), Globals.getDataOptions(sortColumn, sortDirection));
				// populate desired collections with lazy loading
				bool isAccessed = true;
				isAccessed = item.UserRoleUserList.IsDirty;
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
		/// <summary>This web service method inserts or updates User data.</summary>
		///
		/// <param name="item">The User to be managed.</param>
		/// <param name="performCascadeOperation">Flag, indicating if a cascade operation should be performed on the User item.</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Users.UserResults UpsertOneUser(BLL.Users.User item, bool performCascadeOperation)
		{
			Components.Users.UserResults results = new Components.Users.UserResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Users.UserManager.UpsertOneUser(item, performCascadeOperation);
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
		public UserManager()
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