
/*<copyright>
	MOD Systems, Inc (c) 2006 All Rights Reserved.
	720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
	All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by MOD Systems.  The contents also may only be viewed by MOD Systems Engineers (employees) and selected Starbucks employees as outlined in the Licensing Agreement between MOD Systems and Starbucks Corporation on June 3rd, 2005.
	No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
	No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact MOD System's competitive advantage.
	Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/
using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Diagnostics;
using BLL = MW.MComm.WalletSolution.BLL;
using MW.MComm.WalletSolution.BLL.UserExperience;
namespace MW.MComm.WMLPhone.WebUI
{
	// ------------------------------------------------------------------------------
	/// <summary>This page contains Edit Account controls for managing Account information.</summary>
	///
	/// File History:
	/// <created>9/1/2006 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class Help : System.Web.UI.MobileControls.MobilePage
	{
        mobileSession mySession; //object used to validate the session and to read metapartnerphone properties ofter validation
		// ------------------------------------------------------------------------------
		/// <summary>Load page for managing Account.</summary>
		///
		// ------------------------------------------------------------------------------
		private void Page_Load(object sender, System.EventArgs e)
		{
            //create a validation object and call the validation routine
            //this 2 lines should be present in all pages of this project
            //except those wich don't requiere an open session
            mySession = new mobileSession();
            mySession.validate(this);
            //[20070622 SBA] Reemplazo 
            this.lblHelp.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.Help);
            // Set up site labels
            //this.lblHelp.Text=Globals.getPageHelp("", "");
		}
		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{	
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}