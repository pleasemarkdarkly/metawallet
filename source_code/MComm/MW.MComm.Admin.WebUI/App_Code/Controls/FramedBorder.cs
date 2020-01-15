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
namespace MW.MComm.Admin.WebUI.Controls
{
	/// <summary>
	/// Summary description for FramedBorder.
	/// </summary>
	[DefaultProperty("Text")] // ToolBoxData("<{0}:FramedBorder runat=server></{0}:FramedBorder>")]
	public class FramedBorder : System.Web.UI.Control 
	{
		private string _text = "box";
		public FramedBorder()
		{
			//
			// constructor logic
			//
		}
		[Bindable(true), Category("Appearance"), DefaultValue("")]
		public string Prefix
		{
			get { return _text; }
			set { _text = value; }
		}
		public string TWidth;
		public string CssClass;
		public string SpaceStyle = null;
		public string TableStyle;
		protected override void CreateChildControls()
		{
			base.CreateChildControls ();
		}
		protected override void AddParsedSubObject(object obj)
		{
			//base.AddParsedSubObject (obj);
			Controls.Add((Control)obj);
		}
		protected override void Render(HtmlTextWriter writer)
		{
			if(CssClass == null)
				CssClass = Prefix;
			
			if(SpaceStyle != null)
				writer.Write("<div style=\"{0}\"></div>",SpaceStyle);
			writer.Write("<table style=\"{1}\" cellpadding=0 cellspacing=0 border=0 width=\"{0}\">",TWidth,TableStyle);
			writer.Write(
				//"<tr><td class=imgbkg{1}_tl></td><td class=imgbkg{1}_t></td><td class=imgbkg{1}_tr></td></tr>",
			//"<tr> <td class=img{1}_tl><!--<img src=\"{0}\">--></td> <td class=img{1}_t></td> <td class=img{1}_tr><!--<img src=\"{2}\">--></td> </tr>",
				"<tr><td ><img src=\"{0}\"></td><td class=imgbkg{1}_t ></td><td align=left><img border=0 src=\"{2}\"></td></tr>",
									   GetFrameImageURL("tl"), Prefix, GetFrameImageURL("tr") );
			writer.Write("<tr> <td class=img{0}_l ></td> <td valign=top class={1} width=100%>", Prefix, CssClass);
			
			base.Render(writer);
			writer.Write("</td><td class=img{0}_r></td></tr>", Prefix);
			//writer.Write("</td><td></td></tr>", Prefix);
			writer.Write(
		"<tr><td class=imgbkg{0}_bl ><!--<img src=\"{1}\">--></td><td class=img{0}_b></td><td class=img{0}_br><!--<img src=\"{2}\">--></td></tr></table>",
		//		"<tr><td class=imgbkg{0}_bl><td class=imgbkg{0}_b></td><td class=imgbkg{0}_br></td></tr></table>",
							Prefix, GetFrameImageURL("bl"), GetFrameImageURL("br") );
		}
		private string GetFrameImageURL(string suffix)
		{
			return Page.ResolveUrl(string.Format("~/images/frames/{0}_{1}.gif",Prefix,suffix));
		}
	}
}
