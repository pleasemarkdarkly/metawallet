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
  /// <summary>
  /// Exposes log in input controls and implements the first validation, then
  /// pushes a link for the seccond step validation.
  /// </summary>
  public partial class login : System.Web.UI.MobileControls.MobilePage
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      //if you got here from an error redirect, display a message
      if (Request.QueryString["error"] == "true")
      {
        this.lblError.Text = "Your session has expired or an error has been detected. Please log in again.";
        this.lblError.Visible = true;
      }
      // Set up site labels
      this.lblPIN.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.PINLabel);
      this.lblPhoneNumber.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.LoginPhoneLabel);
      this.cmdLogIn.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.LogInButtonLabel);
      this.lblSecLevel.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.LogInSecurityLevel);
      this.Form1.Title = Globals.GetSiteLabel(SiteLabelDefinitionCode.MetaWalletHeader);
      this.listAuthenticate.Items[0].Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.LogInLowSecurityLabel);
      this.listAuthenticate.Items[1].Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.LogInHighSecurityLabel);
      //if the page was called with a logout querystring, force end of any existing session
      if (this.Request.QueryString["logout"] == "true")
      {
        Session.Abandon();
        Response.Redirect("./login.aspx?logout=success",true);
      }
      //try to set the phone text box to the correct phone via querystring or cookies
      if (!this.IsPostBack)
      {
        if (this.Request.QueryString["phone"] != null)
        {
          if (!this.IsPostBack & this.Request.QueryString["phone"].Trim() != string.Empty)
          {
            this.inputPhone.Text = this.Request.QueryString["phone"].Trim();
          }
        }
        else if (this.Request.Cookies["phone"] != null)
        {
          if (this.Request.Cookies["phone"].Value != string.Empty)
          {
            this.inputPhone.Text = this.Request.Cookies["phone"].Value;
          }
        }
      }
    }
    protected void cmdLogIn_Click(object sender, EventArgs e)
    {
      try
      {
        string phone;
        if (this.inputPhone.Text.Trim() != string.Empty & this.inputPIN.Text.Trim() != string.Empty)
        {
          phone = this.inputPhone.Text.Trim();
          //fix nuevatel phones entered without a international prefix
          if (phone.Length == 8 & phone.StartsWith("70")) phone = "591" + phone;
          //
          BLL.Customers.MetaPartnerPhone partnerPhone;
          partnerPhone = BLL.Customers.MetaPartnerPhoneManager.GetOneMetaPartnerPhoneByPhoneNumber(phone);
          if (partnerPhone != null)
          {
            if (partnerPhone.PIN == this.inputPIN.Text.Trim())
            {
              //if the pin and phone number are accepted, the session will
              //be initiated in a indirect manner, to validate that the input
              //came from the specified phone
              this.panelLoginInput.Visible = false;
              this.lblAccepted.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.LoginAcceptedWaitForLink);
              this.lblAccepted.Visible = true;
              if (this.listAuthenticate.Selection.Value == "demo")
              {
                this.Session["Customer/MetaPartnerPhoneID"] = partnerPhone.MetaPartnerPhoneID;
                Response.Redirect("./default.aspx?sid=" + partnerPhone.MetaPartnerPhoneID +
                    "&exp=" + DateTime.Now.AddMinutes(10).ToBinary().ToString(), true);
              }
              else
              {
                ///todo: replace this for a DNS based url
                string url = "http://seattle.grundy.name/wap/default.aspx?sid=" + partnerPhone.MetaPartnerPhoneID +
                    "&exp=" + DateTime.Now.AddMinutes(10).ToBinary().ToString();
                if (partnerPhone.CarrierMetaPartnerID == new Guid("bf8d2a88-10d7-46d2-8af1-7012e98d05de"))
                {
                  MW.MComm.WalletSolution.MComm.SMS.SMSSender.smsSender smsOut = new MW.MComm.WalletSolution.MComm.SMS.SMSSender.smsSender();
                  smsOut.pushWAP("25", partnerPhone.PhoneNumber,
                      Globals.GetSiteLabel(SiteLabelDefinitionCode.LoginAcceptedPushLink), url);
                }
                else
                {
                  string phone1 = partnerPhone.PhoneNumber;
                  if (phone1.Length == 10 & !phone1.StartsWith("591"))
                  {
                    phone1 = "+1" + phone1.Trim();
                  }
                  MW.MComm.WalletSolution.MComm.SMS.SMSSenderUSA.smsSender smsOut = new MW.MComm.WalletSolution.MComm.SMS.SMSSenderUSA.smsSender();
                  smsOut.pushWAP("25", phone1,
                      Globals.GetSiteLabel(SiteLabelDefinitionCode.LoginAcceptedPushLink), url);
                }
              }
            }
            else
            {
              this.lblError.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.LoginFailed);
            }
          }
          else
          {
            this.lblError.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.LoginFailed);
          }
        }
      }
      catch
      {
        this.lblError.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.LoginFailed);
      }
    }
    protected void cmdSignIn_Click(object sender, EventArgs e)
    {
      if (this.inputPhone.Text.Trim().Length < 8)
      {
        this.lblError.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.FormValidationFailure);
      }
      else
      {
        this.inputPhone.Text = this.inputPhone.Text.Replace("+", "");
        BLL.Customers.MetaPartnerPhone phoneExists = BLL.Customers.MetaPartnerPhoneManager.GetOneMetaPartnerPhoneByPhoneNumber(this.inputPhone.Text.Trim());
        if (phoneExists == null)
        {
          this.Session["newAccountPhone"] = this.inputPhone.Text.Trim();
          this.Session["newAccountPIN"] = this.inputPIN.Text.Trim();
          Response.Redirect("./createAccount.aspx");
        }
        else
        {
          this.lblError.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.ErrorPhoneAlredyRegistered) + ".";
        }
      }
    }
  }
}