/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/
namespace MW.MComm.Admin.WebUI.UserControls.Desktop.Utility
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	/// <summary>
	///		Summary description for PageHelp.
	/// </summary>
	public partial class PageHelp : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				string title = "";
				string text = "";
				Globals.getPageHelp(out title, out text);
				lblHelpTitle.Text = title;
				lblPageHelp.Text = Server.HtmlDecode(text);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Request to create a new Asset.</summary>
		///
		// ------------------------------------------------------------------------------
		private void btnHelp_Click(object sender, EventArgs e)
		{
			if (lblPageHelp.Visible == true)
			{
				lblHelpTitle.Visible = false;
				lblPageHelp.Visible = false;
				btnHelp.Text = "Help";
			}
			else
			{
				lblHelpTitle.Visible = true;
				lblPageHelp.Visible = true;
				btnHelp.Text = "Hide";
			}
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
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
		}
		#endregion
	}
}
