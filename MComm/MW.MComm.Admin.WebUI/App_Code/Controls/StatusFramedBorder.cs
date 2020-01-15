/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using BLL = MW.MComm.WalletSolution.BLL;
namespace MW.MComm.Admin.WebUI.Controls
{
	/// <summary>
	/// Summary description for StatusFramedBorder.
	/// </summary>
	[DefaultProperty("Text")] // ToolBoxData("<{0}:StatusFramedBorder runat=server></{0}:StatusFramedBorder>")]
	public class StatusFramedBorder : System.Web.UI.Control 
	{
		private string m_boxName = "box_green";
		private string m_headerClass = "status_header_ok";
		private string m_title = "";
		public StatusFramedBorder()
		{
			//
			// constructor logic
			//
		}
		[Bindable(true), Category("Data"), DefaultValue("")]
		public string Title
		{
			get { return m_title; }
			set { m_title = value; }
		}
		public string TWidth;
		public string CssClass;
		public string SpaceStyle = null;
		public string TableStyle;
		public BLL.Core.SeverityLevelCode Status
		{
			get { return ViewState["Status"] == null ? BLL.Core.SeverityLevelCode.None : (BLL.Core.SeverityLevelCode)ViewState["Status"]; }
			set { ViewState["Status"] = value; }
		}
		protected override void CreateChildControls()
		{
			base.CreateChildControls();
		}
		protected override void AddParsedSubObject(object obj)
		{
			//base.AddParsedSubObject (obj);
			Controls.Add((Control)obj);
		}
		protected override void Render(HtmlTextWriter writer)
		{
			switch (Status)
			{
				case BLL.Core.SeverityLevelCode.CriticalError:
				case BLL.Core.SeverityLevelCode.NonCriticalError:
					m_boxName = "box_black";
					m_headerClass = "status_header_error";
					break;
				case BLL.Core.SeverityLevelCode.Warning:
					m_boxName = "box_black";
					m_headerClass = "status_header_warning";
					break;
				default:
					m_boxName = "box_black";
					m_headerClass = "status_header_ok";
					break;
			}
			if (CssClass == null)
			{
				CssClass = m_boxName;
			}
			if (SpaceStyle != null)
			{
				writer.Write( "<div style=\"{0}\"></div>", SpaceStyle );
			}
			// Table header
			writer.Write( "<table style=\"{1}\" cellpadding=0 cellspacing=0 border=0 width=\"{0}\">", TWidth, TableStyle );
			// Top border
			writer.Write( "<tr><td class=img{0}_tl></td><td class=img{0}_t></td><td class=img{0}_tr></td></tr>", m_boxName );
			// Left border
			writer.Write( "<tr> <td class=img{0}_l ></td> <td valign=top class={1} style=\"padding: 0px 0px 0px 0px; \" width=100%>", m_boxName, CssClass );
			// Title
			writer.Write( "<div class=\"status_header {0}\"width=100%>{1}</div><div class=\"status_body\" width=100%>", m_headerClass, Title );
			// Content
			base.Render( writer );
			// Right border
			writer.Write( "</div></td><td class=img{0}_r></td></tr>", m_boxName );
			// Bottom border
			writer.Write( "<tr><td class=imgbkg{0}_bl ></td><td class=img{0}_b></td><td class=img{0}_br></td></tr></table>",
				m_boxName, GetFrameImageURL("bl"), GetFrameImageURL("br") );
		}
		private string GetFrameImageURL(string suffix)
		{
			return Page.ResolveUrl( string.Format( "~/images/frames/{0}_{1}.gif", m_boxName, suffix ) );
		}
	}
}
