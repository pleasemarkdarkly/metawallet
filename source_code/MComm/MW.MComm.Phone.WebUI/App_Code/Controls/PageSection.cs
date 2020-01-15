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

namespace MW.MComm.Phone.WebUI.Controls
{
	/// <summary>
	/// Summary description for FramedBorder.
	/// </summary>
	[DefaultProperty("Text")] // ToolBoxData("<{0}:FramedBorder runat=server></{0}:FramedBorder>")]
	public class PageSection : System.Web.UI.Control 
	{
		public PageSection() {}

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
			if(Visible)
				base.Render(writer);
		}

	}
}
