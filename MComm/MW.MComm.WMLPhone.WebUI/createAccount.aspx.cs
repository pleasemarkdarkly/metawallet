/*<copyright>
	MOD Systems, Inc (c) 2006 All Rights Reserved.
	720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
	All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by MOD Systems.  The contents also may only be viewed by MOD Systems Engineers (employees) and selected Starbucks employees as outlined in the Licensing Agreement between MOD Systems and Starbucks Corporation on June 3rd, 2005.
	No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
	No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact MOD System's competitive advantage.
	Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.Mobile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.MobileControls;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using BLL = MW.MComm.WalletSolution.BLL;
using MW.MComm.WalletSolution.BLL.UserExperience;
namespace MW.MComm.WMLPhone.WebUI
{
  public partial class createAccount : System.Web.UI.MobileControls.MobilePage
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      //set up labels.
      this.lblPhoneNumber.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.LoginPhoneLabel);
      this.lblPIN.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.TypeNewPIN);
      this.lblPIN2.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.TypeNewPINAgain);
      // [20070622 SBA] Reemplazo 
      this.cmdSignIn.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.CreateAccountButtonLabel);
      this.cmdCancel.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.CancelButtonLabel);
      //this.lblNotRetrieved.Text = "Please confirm your PIN and phone number. Other data will be retrieved from your carrier.";
      this.lblNotRetrieved.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.ConfirmPINAndPhoneNumber);


      //if the phone number was entered in the login page, disply it here
      if (this.Session["newAccountPhone"] != null)
        this.inputPhone.Text = (string)this.Session["newAccountPhone"];
      if (this.Session["newAccountPIN"] != null)
        this.inputPIN.Text = (string)this.Session["newAccountPIN"];
    }
    //this creates a new account in the metawallet database based on
    //data from the carrier
    protected void cmdSignIn_Click(object sender, EventArgs e)
    {
      //validate form
      if (this.inputPhone.Text.Trim().Length >= 8)
      {
        if (this.inputPIN.Text.Trim().Length >= 4 & this.inputPIN.Text.Trim().Length >= 4
          & this.inputPIN.Text.Trim() == this.inputPIN2.Text.Trim())
        {
            string result=BLL.Customers.CustomerManager.createCustomer(this.inputPhone.Text.Trim(), this.inputPIN.Text.Trim());
            if (result == string.Empty)
            {
              BLL.Customers.MetaPartnerPhone partnerPhone;
              partnerPhone = BLL.Customers.MetaPartnerPhoneManager.GetOneMetaPartnerPhoneByPhoneNumber(this.inputPhone.Text.Trim());
              this.Session["Customer/MetaPartnerPhoneID"] = partnerPhone.MetaPartnerPhoneID;
              Response.Redirect("./default.aspx?sid=" + partnerPhone.MetaPartnerPhoneID +
                  "&exp=" + DateTime.Now.AddMinutes(10).ToBinary().ToString(), true);
            }
            else
            {
                this.lblError.Text = result;
            }
        }
        else //pins do not match or they are not long enough
        {
          this.lblError.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.ChangePINparametersIncorrect);
        }
      }
      else //phone number was not entered or is not long enough
      {
        this.lblError.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.FormValidationFailure);
      }
    }
    //go back to the login page, no account will be created
    protected void cmdCancel_Click(object sender, EventArgs e)
    {
      Response.Redirect("./login.aspx");
    }
}
}