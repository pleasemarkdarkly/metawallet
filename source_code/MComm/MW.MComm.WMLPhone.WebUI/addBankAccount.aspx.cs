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
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Diagnostics;
using BLL = MW.MComm.WalletSolution.BLL;
using MW.MComm.WalletSolution.BLL.UserExperience;
namespace MW.MComm.WMLPhone.WebUI
{
  public partial class addBankAccount : System.Web.UI.MobileControls.MobilePage
  {
    mobileSession mySession;
    protected void Page_Load(object sender, EventArgs e)
    {
      //create a validation object and call the validation routine
      //this 2 lines should be present in all pages of this project
      //except those wich don't requiere an open session
      mySession = new mobileSession();
      mySession.validate(this);
      if (!IsPostBack)
      {
        // Set up site labels
        this.Form1.Title = Globals.GetSiteLabel(SiteLabelDefinitionCode.AccountsTitle);
        this.cmdAcceptBank.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.AcceptButtonLabel);
        this.Label1.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.SelectAParticipatingBankLabel);
        this.Label2.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.EnterYourBankCustomerCodeLabel);
        this.Label3.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.EnterYourBankPINLabel);
        this.Label4.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.OptionalDescriptionForNewAccountLabel);
        this.cmdCancelBank.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.CancelButtonLabel);
        //populate options
        BLL.SortableList<BLL.Customers.Bank> banks;
        banks = BLL.Customers.BankManager.GetAllBankData();
        foreach (BLL.Customers.Bank bank in banks)
        {
          if (bank.IsActive == true)
          {
            System.Web.UI.MobileControls.MobileListItem li = new System.Web.UI.MobileControls.MobileListItem(bank.MetaPartnerName, bank.MetaPartnerID.ToString());
            this.listBanks.Items.Add(li);
          }
        }
      }
    }
    protected void cmdCancel_Click(object sender, EventArgs e)
    {
      Response.Redirect("./accounts.aspx");
    }
    protected void createAcc()
    {
      //validate input
      if (this.textBankCustomerCode.Text.Trim() == string.Empty ||
        this.textBankPIN.Text.Trim() == string.Empty)
      {
        this.lblStatusBank.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.FormValidationFailure);
        this.lblStatusBank.Visible = true;
        return;
      }
      //call account creation
      string errorText;
      int accounts;
      try
      {
        accounts = BLL.Accounts.BankAccountManager.createBankAccountsFromBank(new Guid(this.listBanks.Selection.Value),
          Globals.CurrentPartner.MetaPartnerID, this.textBankCustomerCode.Text,// this.textBankPIN.Text,
          this.textDescrption.Text, out errorText);
        if (accounts > 0)
        {
          Response.Redirect("./accounts.aspx");
        }
        else
        {
          this.lblStatusBank.Text = errorText;
          //[20070622 SBA] Reemplazo
          //if (errorText == string.Empty) this.lblStatusBank.Text = "No new accounts were found";
          if (errorText == string.Empty) this.lblStatusBank.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.NoNewAccountsWereFound);
          this.lblStatusBank.Visible = true;
        }
      }
      catch //(Exception ex)
      {
        //this.lblStatusBank.Text = ex.Message.Replace("\r\n", " ");
        this.lblStatusBank.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.UnspecifiedException);
      }
    }
    protected void cmdAcceptBank_Click(object sender, EventArgs e)
    {
      createAcc();
    }
}
}