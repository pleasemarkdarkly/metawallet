using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;
using MW.MComm.WalletSolution.BLL;
namespace MW.MComm.WMLPhone.WebUI 
{
	/// <summary>
	/// Summary description for Global.
	/// </summary>
	public class Global : System.Web.HttpApplication
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		public Global()
		{
			InitializeComponent();
		}	
		protected void Application_Start(Object sender, EventArgs e)
		{
			// initialize business object
			BusinessObjectManager.Initialize(new Globals());
		}
		protected void Session_Start(Object sender, EventArgs e)
		{
		}
		protected void Application_BeginRequest(Object sender, EventArgs e)
		{
		}
		protected void Application_EndRequest(Object sender, EventArgs e)
		{
		}
		protected void Application_AuthenticateRequest(Object sender, EventArgs e)
		{
		}
		protected void Application_Error(Object sender, EventArgs e)
		{
      Server.Transfer("errormsg.aspx");
		}
		protected void Session_End(Object sender, EventArgs e)
		{
            System.Web.UI.Page page = new System.Web.UI.Page();
		}
		protected void Application_End(Object sender, EventArgs e)
		{
		}
		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.components = new System.ComponentModel.Container();
		}
		#endregion
	}
}
