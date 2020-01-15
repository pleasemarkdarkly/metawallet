

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
using MW.MComm.Ganadero.WebService;
using MW.MComm.Ganadero.WebService.Users;
using BLL = MW.MComm.Ganadero.BLL;
using MW.MComm.Ganadero.BLL.Users;
using MOD.Data;
using Utility = MW.MComm.Ganadero.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace MW.MComm.Ganadero.WebService.Users
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage UserRoleUser related information.</summary>
	///
	/// File History:
	/// <created>10/20/2006 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public class UserRoleUserManager : System.Web.Services.WebService
	{

		#region "Service Methods"

		// ------------------------------------------------------------------
		/// <summary>This web service method inserts UserRoleUser data.</summary>
		///
		/// <param name="item">The UserRoleUser to be managed.</param>
		/// <param name="performCascadeOperation">Flag, indicating if a cascade operation should be performed on the UserRoleUser item.</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Users.UserRoleUserResults AddOneUserRoleUser(BLL.Users.UserRoleUser item, bool performCascadeOperation)
		{
			Components.Users.UserRoleUserResults results = new Components.Users.UserRoleUserResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Users.UserRoleUserManager.AddOneUserRoleUser(item, performCascadeOperation);
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
		/// <summary>This web service method deletes all UserRoleUser data by a key.</summary>
		///
		/// <param name="userID">A key for UserRoleUser items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Users.UserRoleUserResults DeleteAllUserRoleUserDataByUserID(string userID)
		{
			Components.Users.UserRoleUserResults results = new Components.Users.UserRoleUserResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Users.UserRoleUserManager.DeleteAllUserRoleUserDataByUserID(MOD.Data.DataHelper.GetGuid(userID, MOD.Data.DefaultValue.Guid));
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
		/// <summary>This web service method deletes all UserRoleUser data by a key.</summary>
		///
		/// <param name="userRoleCode">A key for UserRoleUser items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Users.UserRoleUserResults DeleteAllUserRoleUserDataByUserRoleCode(int userRoleCode)
		{
			Components.Users.UserRoleUserResults results = new Components.Users.UserRoleUserResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Users.UserRoleUserManager.DeleteAllUserRoleUserDataByUserRoleCode(userRoleCode);
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
		/// <summary>This web service method deletes UserRoleUser data.</summary>
		///
		/// <param name="item">The UserRoleUser to be deleted.</param>
		/// <param name="performCascadeOperation">Flag, indicating if a cascade delete should be performed on the UserRoleUser item.</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Users.UserRoleUserResults DeleteOneUserRoleUser(BLL.Users.UserRoleUser item, bool performCascadeOperation)
		{
			Components.Users.UserRoleUserResults results = new Components.Users.UserRoleUserResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Users.UserRoleUserManager.DeleteOneUserRoleUser(item, performCascadeOperation);
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
		/// <summary>This web service method gets all UserRoleUser data.</summary>
		///
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Users.UserRoleUserResults GetAllUserRoleUserData(string sortColumn, string sortDirection)
		{
			Components.Users.UserRoleUserResults results = new Components.Users.UserRoleUserResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Users.UserRoleUserManager.GetAllUserRoleUserData(Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all UserRoleUser data by a key.</summary>
		///
		/// <param name="userID">A key for UserRoleUser items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Users.UserRoleUserResults GetAllUserRoleUserDataByUserID(string userID, string sortColumn, string sortDirection)
		{
			Components.Users.UserRoleUserResults results = new Components.Users.UserRoleUserResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Users.UserRoleUserManager.GetAllUserRoleUserDataByUserID(MOD.Data.DataHelper.GetGuid(userID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all UserRoleUser data by a key.</summary>
		///
		/// <param name="userRoleCode">A key for UserRoleUser items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Users.UserRoleUserResults GetAllUserRoleUserDataByUserRoleCode(string userRoleCode, string sortColumn, string sortDirection)
		{
			Components.Users.UserRoleUserResults results = new Components.Users.UserRoleUserResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Users.UserRoleUserManager.GetAllUserRoleUserDataByUserRoleCode(MOD.Data.DataHelper.GetInt(userRoleCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets a single UserRoleUser by an index.</summary>
		///
		/// <param name="userRoleCode">The index for UserRoleUser to be fetched</param>
		/// <param name="userID">The index for UserRoleUser to be fetched</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Users.UserRoleUserResults GetOneUserRoleUser(int userRoleCode, string userID, string sortColumn, string sortDirection)
		{
			Components.Users.UserRoleUserResults results = new Components.Users.UserRoleUserResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Users.UserRoleUser item =  BLL.Users.UserRoleUserManager.GetOneUserRoleUser(MOD.Data.DataHelper.GetInt(userRoleCode, MOD.Data.DefaultValue.Int), MOD.Data.DataHelper.GetGuid(userID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method updates UserRoleUser data.</summary>
		///
		/// <param name="item">The UserRoleUser to be managed.</param>
		/// <param name="performCascadeOperation">Flag, indicating if a cascade operation should be performed on the UserRoleUser item.</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Users.UserRoleUserResults UpdateOneUserRoleUser(BLL.Users.UserRoleUser item, bool performCascadeOperation)
		{
			Components.Users.UserRoleUserResults results = new Components.Users.UserRoleUserResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Users.UserRoleUserManager.UpdateOneUserRoleUser(item, performCascadeOperation);
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
		public UserRoleUserManager()
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