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
	using DAL = MW.MComm.WalletSolution.DAL;
	/// <summary>
	///		Summary description for ImageCheckbox.
	/// </summary>
	public partial class ImageCheckbox : System.Web.UI.UserControl
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			_text.CausesValidation = _image.CausesValidation = false;
		}
		public bool Checked
		{
			get { return MOD.Data.DataHelper.GetBool(ViewState["Checked"],false); }
			set { ViewState["Checked"] = value; }
		}
		public string CheckedImageUrl
		{
			get 
			{ 
				return MOD.Data.DataHelper.GetString(ViewState["CheckedImageUrl"],string.Empty);
			}
			set
			{
				ViewState["CheckedImageUrl"] = value;
			}
		}
		public string UncheckedImageUrl
		{
			get 
			{ 
				return MOD.Data.DataHelper.GetString(ViewState["UncheckedImageUrl"],string.Empty);
			}
			set
			{
				ViewState["UncheckedImageUrl"] = value;
			}
		}
		public string CssClass
		{
			get 
			{ 
				return _text.CssClass;
			}
			set
			{
				_text.CssClass = value;
			}
		}
		public string Style
		{
			get 
			{ 
				return _parent.Attributes["style"];
			}
			set
			{
				_parent.Attributes["style"] = value;
			}
		}
		public string Text
		{
			get { return _text.Text; }
			set { _text.Text = value; }
		}
		public string TextLeft
		{
			get { return _text.Style["left"]; }
			set { _text.Style["left"] = value; }
		}
		public string TextTop
		{
			get { return _text.Style["top"]; }
			set { _text.Style["top"] = value; }
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
			this.Load += new System.EventHandler(this.Page_Load);
			_text.Click += new EventHandler(_text_Click);
			_image.Click += new System.Web.UI.ImageClickEventHandler(_image_Click);
			this.PreRender += new EventHandler(ImageCheckbox_PreRender);
		}
		#endregion
		private void _text_Click(object sender, EventArgs e)
		{
			Checked = !Checked;
		}
		private void _image_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Checked = !Checked;
		}
		private void ImageCheckbox_PreRender(object sender, EventArgs e)
		{
			_image.ImageUrl = Page.ResolveUrl(Checked ? CheckedImageUrl : UncheckedImageUrl);
		}
	}
}
