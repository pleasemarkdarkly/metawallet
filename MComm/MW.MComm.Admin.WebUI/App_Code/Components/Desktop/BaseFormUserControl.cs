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
using MOD.Data;
namespace MW.MComm.Admin.WebUI.Components.Desktop
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage the base information and behavior of all simple detail user controls.</summary>
	/// 
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public class BaseFormlUserControl : BaseDetailUserControl
	{
		#region "Declarations"
		// for UseWorkingSets property
		private bool _useWorkingSets = false;
		#endregion "Declarations"
		#region "Public Properties"
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets whether or not to use working sets for drop down lists.</summary>
		// ------------------------------------------------------------------------------
		public virtual bool UseWorkingSets
		{
			get
			{
				return _useWorkingSets;
			}
			set
			{
				_useWorkingSets = value;
			}
		}
		#endregion "Public Properties"
		#region "Public Methods"
        protected override void OnLoad()
        {
            base.OnLoad();
            AttachClientOnChangeScript(this);
        }
        public override void OnPreRender()
        {
			base.OnPreRender();
            if (WorkflowMode == WorkflowMode.External)
            {
                if (_entity != null)
                    Page.ClientScript.RegisterClientScriptBlock(typeof(string), "SetFormChanged", 
                        "SetFormChanged(" + _entity.IsDirty.ToString().ToLower() + ")", true);
            }
		}
        /// <summary>
        /// See also /Scripts/UnsavedFormChanges.js
        /// </summary>
        /// <param name="control"></param>
        public void AttachClientOnChangeScript(Control control)
        {
            if (control is TextBox || control is CheckBox || control is DropDownList)
                ((WebControl)control).Attributes.Add("onchange", "javascript:SetFormChanged(true);");
            else
            {
                foreach (Control child in control.Controls)
                    AttachClientOnChangeScript(child);
            }
        }
		#endregion "Public Methods"
		#region "Miscellaneous"
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public BaseFormlUserControl()
		{
			//
			// constructor logic
			//
		}
		#endregion "Miscellaneous"
	}
}
