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
	public class PropVal : System.Web.UI.Control 
	{
		public PropVal()
		{
		}
		public string CssClass
		{
			get { return MOD.Data.DataHelper.GetString(ViewState["CssClass"],""); }
			set { ViewState["CssClass"] = value; }
		}
		public string Prop
		{
			get { return MOD.Data.DataHelper.GetString(ViewState["Prop"],""); }
			set { ViewState["Prop"] = value; }
		}
		protected override void Render(HtmlTextWriter writer)
		{
			writer.Write(string.Format("<span class=\"{0}\">", CssClass));
			writer.Write(GetPropVal());
			writer.Write("</span>");
		}
		private string GetPropVal()
		{
			string[] chain = Prop.Split('.');
			object o = NamingContainer;
			foreach(string p in chain)
			{
				try
				{
					o = o.GetType().GetProperty(p, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetProperty | BindingFlags.Instance ).GetValue(o,null);
					if(o == null)
						return "";
				}
				catch
				{
					return string.Format("<span class=\"error\">Error: {0} does not have a property named {1}</span>",o.GetType().Name,p);
				}
			}
			
			return o != null ? o.ToString() : "";
		}
	}
}
