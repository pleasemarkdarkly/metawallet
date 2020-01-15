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
	/// Summary description for FlashContainer.
	/// </summary>
	public class FlashContainer : System.Web.UI.Control 
	{
		public FlashContainer()
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
		public string FlashURL
		{
			get { return MOD.Data.DataHelper.GetString(ViewState["FlashURL"],string.Empty); }
			set { ViewState["FlashURL"] = value; }
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
			writer.Write("<object type=\"application/x-shockwave-flash\" ");
			writer.Write("data=\"{0}\" ", Page.ResolveUrl(FlashURL));
			if(Width != 0)
				writer.Write("width=\"{0}\" ",Width);
			if(Height != 0)
				writer.Write("height=\"{0}\" ",Height);
			writer.Write("VIEWASTEXT>");
			writer.Write("<param name=\"movie\" value=\"{0}\" />",Page.ResolveUrl(FlashURL));
			writer.Write("</object>");
		}
	}
}
