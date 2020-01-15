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
using DAL = MW.MComm.WalletSolution.DAL;
namespace MW.MComm.Admin.WebUI.Controls
{
	/// <summary>
	/// Summary description for PolicyCheck.
	/// </summary>
	public class PolicyCheck : System.Web.UI.Control //, IAttributeAccessor
	{
/*
		public string GetAttribute(string name)
		{
			return (string)ViewState[name];
		}
		public void SetAttribute(string name, string value1)
		{
			ViewState[name] = value1;
		}
*/
		private static bool s_ArePolicyChecksEnabled = true;
		static PolicyCheck()
		{
			//s_ArePolicyChecksEnabled = MW.MComm.WalletSolution.BLL.Config.ConfigurationContext.Current.AllValues.GetBoolValue( "PolicyChecksEnabled", true );
		}
		public enum PolicyAction
		{
			None = 0,
			Show,
			Hide,
			Enable,
			Disable
		}
		public string Policies
		{
			get { return MOD.Data.DataHelper.GetString(ViewState["Policies"],""); }
			set { ViewState["Policies"] = value; }
		}
		public PolicyAction Pass
		{
			get 
			{ 
				try
				{
					return (PolicyAction)ViewState["Pass"];
				}
				catch
				{
					return PolicyAction.None;
				}
			}
			set { ViewState["Pass"] = value; }
		}
		public PolicyAction Fail
		{
			get 
			{ 
				try
				{
					return (PolicyAction)ViewState["Fail"];
				}
				catch
				{
					return PolicyAction.None;
				}
			}
			set { ViewState["Fail"] = value; }
		}
	
		public PolicyCheck()
		{
			//
			// constructor logic
			//
			//this.PreRender += new EventHandler(PolicyCheck_PreRender);
		}
		protected override void CreateChildControls()
		{
			base.CreateChildControls ();
		}
		protected override void AddParsedSubObject(object obj)
		{
			Controls.Add((Control)obj);
		}
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender (e);
			PolicyCheck_PreRender(null,null);
		}
		private void PolicyCheck_PreRender(object sender, EventArgs e)
		{
			if(!s_ArePolicyChecksEnabled)
				return;
			PolicyAction action = IsValid ? Pass : Fail;
			switch(action)
			{
				case PolicyAction.None: break;
				case PolicyAction.Enable : EnableChildren(this,true); break;
				case PolicyAction.Show : Visible = true; break;
				case PolicyAction.Disable : EnableChildren(this,false); break;
				case PolicyAction.Hide : Visible = false; break;
			}
		}
/*
		protected override void Render(HtmlTextWriter writer)
		{
			if(Visible)
				base.Render (writer);
		}
*/
		private object _isValid = null;
		public bool IsValid
		{
			get 
			{
				if(_isValid == null)
					_isValid = CheckValidUser();
				return (bool)_isValid;
			}
		}
		private bool CheckValidUser()
		{
			if(Policies == "")
				return true;
			else if(Context.User != null)
				foreach(string policy in Policies.Split(','))
					if( Context.User.IsInRole( policy.Trim() ) )
						return true;
			return false;
		}
		private void EnableChildren(Control ctl,bool bEnable)
		{
			foreach(Control c in ctl.Controls)
			{
				try
				{
					if(bEnable || (c is LinkButton || c is ImageButton || c is Button))
					{
						c.GetType().GetProperty("Enabled").SetValue(c,bEnable,null);
					}
				}
				catch {}
				EnableChildren(c,bEnable);
			}
		}
	}
}
