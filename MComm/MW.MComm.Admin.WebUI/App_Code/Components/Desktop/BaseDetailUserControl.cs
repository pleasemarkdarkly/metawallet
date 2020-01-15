/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/
using System;
using System.ComponentModel;
using MOD.Data;
using MW.MComm.WalletSolution.Utility;
using BLL = MW.MComm.WalletSolution.BLL;
namespace MW.MComm.Admin.WebUI.Components.Desktop
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage the base information and behavior of all simple detail user controls.</summary>
	/// 
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public class BaseDetailUserControl : BaseUserControl
	{
		#region "Declarations"
        /// <summary>
        /// The entity currently being edited
        /// </summary>
        protected BLL.PersistedBusinessObject _entity;
		#endregion "Declarations"
		#region "Public Properties"
      
		#endregion "Public Properties"
		#region "Public Methods"
		#endregion "Public Methods"
        #region "Protected Methods"
		public override void OnPreRender()
		{
			base.OnPreRender();
		}
		protected override void LoadControlState(object savedState)
        {
            object[] state = (object[])savedState;
            base.LoadControlState(state[0]);
        }
        protected override object SaveControlState()
        {
            object[] state = new object[2];
            state[0] = base.SaveControlState();
            if (_entity != null)
            {
                state[1] = _entity.GetHashCode();
            }
            else
            {
                state[1] = null;
            }
            return state;
        }
        #endregion
        #region "Miscellaneous"
        // ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public BaseDetailUserControl()
		{
			//
			// constructor logic
			//
		}
		#endregion "Miscellaneous"
	}
}
