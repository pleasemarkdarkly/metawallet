/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

using System;
using System.Web.UI.WebControls;

namespace MW.MComm.Phone.WebUI.Components
{
	/// <summary>
	/// Summary description for Buttons.
	/// </summary>
    public class Buttons
    {
        public Buttons()
        {
            //
            // constructor logic
            //
        }

        public static void ConfirmDelete(WebControl btn, string type)
        {
            Confirm(btn,string.Format("Are you sure you want to delete this {0}?",type));
        }

        public static void Confirm(WebControl btn, string confirmationText)
        {
            btn.Attributes.Add("onclick",string.Format("return confirm('{0}');",confirmationText.Replace("'",@"\'")));
        }

		public static void InputBox(WebControl btn, string inputTextID, string text)
		{
			btn.Attributes.Add("onclick",string.Format("return inputbox('{0}','{1}');",inputTextID ,text.Replace("'",@"\'")));
		}
	}
}
