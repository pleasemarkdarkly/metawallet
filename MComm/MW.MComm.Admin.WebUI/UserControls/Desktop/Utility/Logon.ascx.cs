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
	using System.Collections;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.Security;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using MW.MComm.WalletSolution;
	using MW.MComm.WalletSolution.Utility;
	using MOD.Data;
	using BLL = MW.MComm.WalletSolution.BLL;
	/// <summary>
	///		Summary description for Logon.
	/// </summary>
	public partial class Logon : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			
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
			this.PreRender += new System.EventHandler(this.Logon_PreRender);
		}
		#endregion
		protected void Logon_PreRender(object sender, EventArgs e)
		{
			//Visible = Globals.CurrentUser == null;
		}
		protected void btnLogon_Click(object sender, EventArgs e)
		{
			BLL.Users.User user = BLL.Users.UserManager.GetOneUserByUserName(this.txtUserName.Text.Trim(), MW.MComm.Admin.WebUI.Globals.DBOptions, MW.MComm.Admin.WebUI.Globals.getDataOptions("",""), MW.MComm.Admin.WebUI.Globals.DebugLevel, MW.MComm.Admin.WebUI.Globals.CurrentUserID);
			
            if( user == null )
			{
				MW.MComm.Admin.WebUI.Globals.AddErrorMessage(Page,"Invalid name or password.");
				return;
			}
			if (user.Password != txtPassword.Text.Trim())
			{
				MW.MComm.Admin.WebUI.Globals.AddErrorMessage(Page, "Invalid name or password.");
				return;
			}
			// Store userid in ViewState
            litLoggedIn.Text = user.UserID.ToString();
		    // Authenticated - now must approve EULA
            pnlLogin.Visible = false;
            btnLogon.Visible = false;
            pnlEula.Visible = true;
            btnAgree.Visible = true;
		}
        protected void btnAgree_Click(object sender, EventArgs e)
        {
            BLL.Users.User user = BLL.Users.UserManager.GetOneUser(new Guid(litLoggedIn.Text),
                MW.MComm.Admin.WebUI.Globals.DBOptions, MW.MComm.Admin.WebUI.Globals.getDataOptions("", ""), 
                MW.MComm.Admin.WebUI.Globals.DebugLevel, MW.MComm.Admin.WebUI.Globals.CurrentUserID);
            // Complete login
            // TODO: Get rid of this, user should be stored in HttpContext.Current.User
            MW.MComm.Admin.WebUI.Globals.CurrentUser = user;
            MW.MComm.Admin.WebUI.Globals.AddStatusMessage("{0} logged in.", user.LastName);
			//HttpContext.Current.User = new BLL.Users.User(user);
            /* TODO: Use new .NET Login controls that use implement authentication propperly
            ArrayList alUserData = new ArrayList();
            //alUserData.Add( user.UserID.ToString() );
            //			alUserData.AddRange( user.GetActivityNames().Keys ); 
            string userData = String.Join("|", (string[])alUserData.ToArray(typeof(string)));
            FormsAuthenticationTicket ticket
                = new FormsAuthenticationTicket(1,  //version
                                                 user.UserID.ToString(), //id
                                                 DateTime.Now, //issue date
                                                 DateTime.Now.AddMinutes(60), //expiration date
                                                 false, //peristent
                                                 userData);
            HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName,
                                                    FormsAuthentication.Encrypt(ticket));
            Response.Cookies.Add(authCookie);
            Response.Redirect(FormsAuthentication.GetRedirectUrl(MW.MComm.Admin.WebUI.Globals.CurrentUser.LastName, false));
            */
            Response.Redirect(Page.ResolveUrl("~/Pages/Desktop/Customers/SearchCustomerData.aspx"));
        }
	}
}
