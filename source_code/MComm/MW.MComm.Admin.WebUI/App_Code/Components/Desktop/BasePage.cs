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
using System.Web.UI;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using MW.MComm.WalletSolution;
using MW.MComm.WalletSolution.Utility;
using MW.MComm.WalletSolution.BLL.Core;
using MW.MComm.WalletSolution.DAL.Core;
namespace MW.MComm.Admin.WebUI.Components.Desktop
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage the base information and behavior of all pages.</summary>
	/// 
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public class BasePage : System.Web.UI.Page
	{
		#region "Declarations"
		#endregion "Declarations"
		#region "Public Properties"
		#endregion "Public Properties"
		#region "Public Methods"
        public static Control FindControlRecursive(Control root, string id)
        {
            if (root.ID == id)
            {
                return root;
            }
            foreach (Control c in root.Controls)
            {
                Control t = FindControlRecursive(c, id);
                if (t != null)
                {
                    return t;
                }
            }
            return null;
        }
		#endregion "Public Methods"
		#region "Protected Methods"
		// ------------------------------------------------------------------------------
		/// <summary>This method performs error handling tasks.</summary>
		/// 
		/// <param name="ex">The exception to be handled.</param>
		// ------------------------------------------------------------------------------
        protected virtual void HandleError(CustomAppException ex)
		{
			// TODO: determine desired page level error behavior here (such as publishing exceptions
			Exception e = ex;
			Response.Write("<!--\r\n");
			do
			{
				Response.Write(e.Message);
				Response.Write("\r\n");
				Response.Write(e.StackTrace);
				Response.Write("\r\n");
				Response.Write(e.Source);
				Globals.AddErrorMessage(Page,e.Message);
				e = e.InnerException;
			} while( e != null );
			Response.Write("-->\r\n");
			Server.ClearError();
			// Send this exception to the core for handling
			bool rethrow = CustomAppException.HandleException(ex);
			if (rethrow)
				throw ex;
		}
		#endregion "Protected Methods"
		#region "Miscellaneous"
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public BasePage()
		{
			//
			// constructor logic
			//
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method initializes and adds error handling event.</summary>
		/// 
		/// <param name="e"></param>
		// ------------------------------------------------------------------------------
		protected override void OnInit(EventArgs e) 
		{
			InitializeComponent();
			base.OnInit(e);
			if (!IsPostBack && Request.QueryString["SaveMessages"] == null)
			{
				// clear status messages
				Globals.ClearMessages();
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method adds error handling event.</summary>
		// ------------------------------------------------------------------------------
		private void InitializeComponent()
		{    
#if ERROR_HANDLING_ENABLED
		    this.Error += new EventHandler(BasePage_Error);
#endif
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method handles the unhandled error event.</summary>
		/// 
		/// <param name="sender">The sender of the error event.</param>
		/// <param name="e">The error event arguments.</param>
		// ------------------------------------------------------------------------------
#if ERROR_HANDLING_ENABLED
        private void BasePage_Error(object sender, EventArgs e)
		{
			// get exception and handle
            CustomAppException ex = new CustomAppException(ErrorNumber.GeneralException, SeverityLevelCode.CriticalError, EventTypeCode.ErrorLog, "BasePage_Error", ErrorManager.GetErrorMessageFromErrorNumber(ErrorNumber.GeneralException), Server.GetLastError());
			HandleError(ex);
			Server.Transfer("~/Pages/Desktop/anon/Error.aspx");
		}
#endif
		
		#endregion "Miscellaneous"
	}
}
