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
	using System.Web.UI;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using DAL = MW.MComm.WalletSolution.DAL;
	/// <summary>
	///		Summary description for ImageTextButton.
	/// </summary>
	public partial class ImageTextButton : System.Web.UI.UserControl
	{
		public event EventHandler Click;
		public event CommandEventHandler Command;
		public string NavigateUrl
		{
			get 
			{ 
				return MOD.Data.DataHelper.GetString(ViewState["NavigateUrl"],string.Empty);
			}
			set
			{
				ViewState["NavigateUrl"] = value;
			}
		}
		public bool CausesValidation
		{
			get { return _text.CausesValidation; }
			set { _text.CausesValidation = _image.CausesValidation = value; }
		}
		public string ImageUrl
		{
			get 
			{ 
				return MOD.Data.DataHelper.GetString(ViewState["ImageUrl"],string.Empty);
			}
			set
			{
				ViewState["ImageUrl"] = value;
			}
		}
		
		public string CssClass
		{
			get 
			{ 
				return MOD.Data.DataHelper.GetString(ViewState["CssClass"],string.Empty);
			}
			set
			{
				ViewState["CssClass"] = value;
			}
		}
		public string Style
		{
			get 
			{ 
				
				try { return (string)ViewState["Style"]; } 
				catch { return string.Empty; }  
			}
			set
			{
				ViewState["Style"] = value;
			}
		}
		public bool Enabled
		{
			get 
			{
				return _text.Enabled;
			}
			set 
			{
				_text.Enabled = value;
			}
		}
		
		public string Text
		{
			get 
			{ 
				try { return (string)ViewState["Text"]; } 
				catch { return string.Empty; }  
			}
			set
			{
				ViewState["Text"] = value;
			}
		}
		public string CommandName
		{
			get 
			{ 
				try { return (string)ViewState["CommandName"]; } 
				catch { return string.Empty; }  
			}
			set
			{
				ViewState["CommandName"] = value;
				_text.CommandName = value;
				_image.CommandName = value;
			}
		}
		public string CommandArgument
		{
			get 
			{ 
				try { return (string)ViewState["CommandArgument"]; } 
				catch { return string.Empty; }  
			}
			set
			{
				ViewState["CommandArgument"] = value;
				_text.CommandArgument = value;
				_image.CommandArgument = value;
			}
		}
		public string TextLeft
		{
			get 
			{ 
				try { return (string)ViewState["TextLeft"]; } 
				catch { return string.Empty; }  
			}
			set
			{
				ViewState["TextLeft"] = value;
			}
		}
		public string TextTop
		{
			get 
			{ 
				try { return (string)ViewState["TextTop"]; } 
				catch { return string.Empty; }  
			}
			set
			{
				ViewState["TextTop"] = value;
			}
		}
		private void Page_Load(object sender, System.EventArgs e)
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
			this._image.Click += new System.Web.UI.ImageClickEventHandler(this._image_Click);
			this._text.Click += new EventHandler(_text_Click);
			this.Load += new System.EventHandler(this.Page_Load);
			this.PreRender += new System.EventHandler(this.ImageTextButton_PreRender);
		}
		public void RaisePostBackEvent(string eventArgument)
		{
			if(Enabled)
			{
				if(NavigateUrl != null && NavigateUrl != string.Empty)
					Response.Redirect(Page.ResolveUrl(NavigateUrl));
				else
				{
					OnClick(new EventArgs());
					OnCommand(new CommandEventArgs(CommandName,CommandArgument));
				}
			}
		}
		protected virtual void OnClick(EventArgs e)
		{
			if( Click != null)
			{
				Click(this, e);
			}
		}
		protected virtual void OnCommand(CommandEventArgs e)
		{
			if( Command != null )
			{
				Command(this, e);
			}
		}
		#endregion
		private void ImageTextButton_PreRender(object sender, EventArgs e)
		{
			_parent.Attributes["style"] = Style;
			_text.Text = Text;
			_text.Attributes["class"] = CssClass;
			if(TextLeft != string.Empty)
				_text.Style["left"] = TextLeft;
			if(TextTop != string.Empty)
				_text.Style["top"] = TextTop;
			_image.ImageUrl = Page.ResolveUrl(ImageUrl);
		}
		private void _image_Click(object sender, ImageClickEventArgs e)
		{
			RaisePostBackEvent(null);
		}
		private void _text_Click(object sender, EventArgs e)
		{
			RaisePostBackEvent(null);
		}
	}
}
