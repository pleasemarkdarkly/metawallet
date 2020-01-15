namespace MW.MComm.Admin.WebUI.UserControls.Desktop.Utility
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	/// <summary>
	///		Summary description for CaptionBox.
	/// </summary>
	[ParseChildren(true)]
	public partial class CaptionBox : System.Web.UI.UserControl
	{
		private ITemplate bodyTemplate, headerTemplate;
		private CaptionBoxTemplateContainer bodyContainer, headerContainer;
		public event EventHandler HeaderClick;
		public class CaptionBoxTemplateContainer : Control, INamingContainer 
		{
			public CaptionBoxTemplateContainer() { Visible = true; }
		}
		[TemplateContainer(typeof(CaptionBoxTemplateContainer))]
		public ITemplate BodyTemplate
		{
			get { return bodyTemplate; }
			set { bodyTemplate = value; }
		}
		[TemplateContainer(typeof(CaptionBoxTemplateContainer))]
		public ITemplate HeaderTemplate
		{
			get { return headerTemplate; }
			set { headerTemplate = value; }
		}
		public string CssClass
		{
			get { return table.Attributes["class"]; }
			set { table.Attributes["class"] = value; }
		}
		public bool Expanded
		{
			get { return MOD.Data.DataHelper.GetBool( ViewState["Expanded"], true ); }
			set { ViewState["Expanded"] = value; }
		}		
		public string Text
		{
			get { return lblTitle.Text; }
			set { lblTitle.Text = value; }
		}
		public string TitleCssClass
		{
			get { return (string)ViewState["TitleCssClass"]; }
			set { ViewState["TitleCssClass"] = value; }
		}
		protected void Page_Load(object sender, System.EventArgs e)
		{
			PreRender += new EventHandler(CaptionBox_PreRender);
			lnkHeader.Click += new EventHandler(lnkHeader_Click);
			lnk.Click += new EventHandler(lnkHeader_Click);
			CheckTemplate( bodyTemplate, bodyPlaceHolder, ref bodyContainer);
			CheckTemplate( headerTemplate, headerPlaceHolder, ref headerContainer );
		}
		public override void DataBind()
		{
			CheckTemplate( bodyTemplate, bodyPlaceHolder, ref bodyContainer);
			CheckTemplate( headerTemplate, headerPlaceHolder, ref headerContainer );
			base.DataBind ();
		}
		private void CheckTemplate( ITemplate template, PlaceHolder placeHolder, ref CaptionBoxTemplateContainer container )
		{
			if( template != null && container == null )
			{
				container = new CaptionBoxTemplateContainer();
				template.InstantiateIn(container);
				placeHolder.Controls.Add(container);
			}
		}
		public override Control FindControl(string id)
		{
			CheckTemplate( bodyTemplate, bodyPlaceHolder, ref bodyContainer);
			CheckTemplate( headerTemplate, headerPlaceHolder, ref headerContainer );
			if( bodyContainer != null )
			{
				Control ctl = bodyContainer.FindControl(id);
				if(ctl != null)
					return ctl;
			}
			if( headerContainer != null)
			{
				Control ctl = headerContainer.FindControl(id);
				if(ctl != null)
					return ctl;
			}
			return base.FindControl (id);
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
			if(Expanded)
			{
				table.Rows[1].Visible = true;
				table.Rows[2].Visible = true;
				table.Rows[3].Visible = true;
				table.Rows[0].Cells[0].Attributes["class"] = CssClass + "_expanded";
				lblTitle.CssClass = TitleCssClass;
				imgCaret.ImageUrl = "~/Images/menu_caret_up.gif";
			}
			else
			{
				table.Rows[1].Visible = false;
				table.Rows[2].Visible = false;
				table.Rows[3].Visible = false;
				table.Rows[0].Cells[0].Attributes["class"] = CssClass + "_collapsed";
				lblTitle.CssClass = TitleCssClass;
				imgCaret.ImageUrl = "~/Images/menu_caret_down.gif";
			}
		}
		private void lnkHeader_Click(object sender, EventArgs e)
		{
			if( HeaderClick != null )
				HeaderClick(sender,e);
			else
				OnHeaderClick(sender,e);
		}
		public void OnHeaderClick(object sender, EventArgs e)
		{
			Expanded = !Expanded;
		}
	}
}
