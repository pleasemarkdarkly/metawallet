/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

namespace MW.MComm.Phone.WebUI.UserControls.Desktop.Utility
{
	using System;
	using System.Collections;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	
	/// <summary>
	///		Summary description for StatusMessage.
	/// </summary>
	public partial class StatusMessage : Components.Desktop.BaseUserControl
	{

		protected void Page_Load(object sender, System.EventArgs e)
		{
			rptStatus.DataSource = null;
			rptStatus.DataBind();
		}

		public string Key
		{
			get { return (string)Session["Key"]; }
			set { Session["Key"] = value; }
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
			this.PreRender += new EventHandler(StatusMessage_PreRender);
		}
		#endregion

		private void StatusMessage_PreRender(object sender, EventArgs e)
		{
			ArrayList alMessages = Globals.GetMessages(Key);
			if(alMessages.Count > 0)
			{
				rptStatus.DataSource = alMessages;
				rptStatus.DataBind();
			}
		}
	}
}
