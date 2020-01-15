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
using System.Reflection;
using DAL = MW.MComm.WalletSolution.DAL;
namespace MW.MComm.Admin.WebUI.Controls
{
	/// <summary>
	/// Summary description for PropVal.
	/// </summary>
	public class UserName : System.Web.UI.Control
	{
		public UserName()
		{
		}
		public string Format
		{
			get { return (string)ViewState["Format"]; }
			set { ViewState["Format"] = value; }
		}
		protected override void Render(HtmlTextWriter writer)
		{
			if (Globals.CurrentUser == null)
				writer.Write("Not logged in");
			else
				writer.Write(string.Format(Format, Globals.CurrentUser.FirstName + " " + Globals.CurrentUser.LastName));
		}
	}
}
