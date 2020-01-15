namespace MW.MComm.Admin.WebUI.Templates.Desktop
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	/// <summary>
	///		Summary description for CaptionBox.
	/// </summary>
	public partial class CaptionBox : System.Web.UI.UserControl
	{
		protected string expanded_class = "captionbox_header_expanded";
		protected string collapsed_class = "captionbox_header";
		protected string table_class = "captionbox";
		public bool Expanded
		{
			get { return MOD.Data.DataHelper.GetBool( ViewState["Expanded"], true ); }
			set { ViewState["Expanded"] = value; }
		}
		protected void Page_Load(object sender, System.EventArgs e)
		{
			PreRender += new EventHandler(CaptionBox_PreRender);
			lnk.Click += new EventHandler(lnk_Click);
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
		private void CaptionBox_PreRender(object sender, EventArgs e)
		{
			table.Attributes["class"] = table_class;
			if(Expanded)
			{
				table.Rows[1].Visible = true;
				table.Rows[2].Visible = true;
				table.Rows[3].Visible = true;
				lbl.CssClass = table.Rows[0].Attributes["class"] = expanded_class;
			}
			else
			{
				table.Rows[1].Visible = false;
				table.Rows[2].Visible = false;
				table.Rows[3].Visible = false;
				lbl.CssClass = table.Rows[0].Attributes["class"] = collapsed_class;
			}
		}
		private void lnk_Click(object sender, EventArgs e)
		{
			Expanded = !Expanded;
		}
	}
}
