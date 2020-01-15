namespace MW.MComm.Admin.WebUI.UserControls.Desktop.Utility
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using MOD.Data;
	using DAL = MW.MComm.WalletSolution.DAL;
	/// <summary>
	///		Summary description for ExpandoLink.
	/// </summary>
	public partial class ExpandoLink : System.Web.UI.UserControl
	{
		public string CssClass
		{
			get { return lbl.CssClass; }
			set { lbl.CssClass = value; }
		}
		public bool Expanded
		{
			get { return MOD.Data.DataHelper.GetBool( ViewState["Expanded"], true ); }
			set { ViewState["Expanded"] = value; 	}
		}
		public string Ref
		{
			get { return (string)ViewState["Ref"]; }
			set { ViewState["Ref"] = value; }
		}
		public string Text
		{
			get { return lbl.Text; }
			set { lbl.Text = value; }
		}
		protected void Page_Load(object sender, System.EventArgs e)
		{
			lnk.Click += new EventHandler(lnk_Click);
			PreRender += new EventHandler(ExpandoLink_PreRender);
			// Put user code to initialize the page here
			try
			{
				if(!IsPostBack)
					Expanded = Parent.FindControl(Ref).Visible;
			}
			catch(Exception ex)
			{
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
		}
		#endregion
		private void lnk_Click(object sender, EventArgs e)
		{
			Expanded = !Expanded;
			try
			{
				Parent.FindControl(Ref).Visible = Expanded;
			}
			catch(Exception ex) {}
		}
		private void ExpandoLink_PreRender(object sender, EventArgs e)
		{
			img.ImageUrl = Expanded ? "~/images/minus_sign.gif" : "~/images/plus_sign.gif";
		}
	}
}
