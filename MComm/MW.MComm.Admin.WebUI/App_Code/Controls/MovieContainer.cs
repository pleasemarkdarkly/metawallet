/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/
using System;
using System.Collections.Specialized;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using DAL = MW.MComm.WalletSolution.DAL;
namespace MW.MComm.Admin.WebUI.Controls
{
	/// <summary>
	/// Summary description for MovieContainer.
	/// </summary>
	public class MovieContainer : System.Web.UI.Control 
	{
		public MovieContainer()
		{
			//
			// constructor logic
			//
		
		}
		public int Width
		{
			get { return MOD.Data.DataHelper.GetInt(ViewState["Width"],0); }
			set { ViewState["Width"] = value; }
		}
				
		public int Height
		{
			get { return MOD.Data.DataHelper.GetInt(ViewState["Height"],0); }
			set { ViewState["Height"] = value; }
		}
		public string MovieURL
		{
			get { return MOD.Data.DataHelper.GetString(ViewState["MovieURL"],string.Empty); }
			set { ViewState["MovieURL"] = value; }
		}
		public bool AutoStart
		{
			get { return MOD.Data.DataHelper.GetBool(ViewState["AutoStart"],false); }
			set { ViewState["AutoStart"] = value; }
		}
		public bool ShowControls
		{
			get { return MOD.Data.DataHelper.GetBool(ViewState["ShowControls"],false); }
			set { ViewState["ShowControls"] = value; }
		}
        public bool ShowStatusBar
        {
            get { return MOD.Data.DataHelper.GetBool(ViewState["ShowStatusBar"], false); }
            set { ViewState["ShowStatusBar"] = value; }
        }
        public bool ShowDisplay
        {
            get { return MOD.Data.DataHelper.GetBool(ViewState["ShowDisplay"], false); }
            set { ViewState["ShowDisplay"] = value; }
        }
		protected override void CreateChildControls()
		{
			base.CreateChildControls ();
		}
		protected override void AddParsedSubObject(object obj)
		{
			Controls.Add((Control)obj);
		}
		protected override void Render(HtmlTextWriter writer)
		{
            /*
			writer.Write("<object type=\"application/x-oleobject\" name=\"player\" ");
			if(Width != 0)
				writer.Write("width=\"{0}\" ",Width);
			if(Height != 0)
				writer.Write("height=\"{0}\" ",Height);
			writer.Write(" CLASSID=\"CLSID:6BF52A52-394A-11d3-B153-00C04F79FAA6\"> ");
			
			writer.Write("<param name=\"URL\" value=\"{0}\" />",Page.ResolveUrl(MovieURL));						
			writer.Write("<param name=\"AUTOSTART\" value=\"{0}\" />",AutoStart);
			writer.Write("<param name=\"showControls\" value=\"{0}\" />",ShowControls);
            writer.Write("<param name=\"ShowDisplay\" value=\"{0}\" />", false);
			writer.Write("</object>");
            */
            if (!Visible) return;
            writer.Write(@"<OBJECT ID=""MediaPlayer"" WIDTH=""{0}"" HEIGHT=""{1}"" CLASSID=""CLSID:22D6F312-B0F6-11D0-94AB-0080C74C7E95""" + 
                @"STANDBY=""Loading Windows Media Player components..."" TYPE=""application/x-oleobject"">" +
                @"<PARAM NAME=""FileName"" VALUE=""{2}"">" + 
                @"<PARAM name=""autostart"" VALUE=""{3}"">" +
                @"<PARAM name=""ShowControls"" VALUE=""{4}"">" +
                @"<param name=""ShowStatusBar"" value=""{5}"">" +
                @"<PARAM name=""ShowDisplay"" VALUE=""{6}"">" +
                @"<EMBED TYPE=""application/x-mplayer2"" SRC=""{2}"" NAME=""MediaPlayer""" +
                @"WIDTH=""{0}"" HEIGHT=""{1}"" ShowControls=""{7}"" ShowStatusBar=""{8}"" ShowDisplay=""{9}"" autostart=""{10}""></EMBED>" +
                @"</OBJECT>", 
                Width, Height, Page.ResolveUrl(MovieURL), AutoStart, ShowControls, ShowStatusBar, ShowDisplay,
                ShowControls ? 1 : 0, ShowStatusBar ? 1 : 0, ShowDisplay ? 1 : 0, AutoStart ? 1 : 0);
		}
	}
}
