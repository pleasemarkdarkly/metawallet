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
using System.Web.UI.MobileControls;
using System.Diagnostics;
using BLL = MW.MComm.WalletSolution.BLL;
using MW.MComm.WalletSolution.BLL.UserExperience;
using carrierCM=MW.MComm.WalletSolution.MComm.CarrierSim.CustomerManager;
using carrierPM = MW.MComm.WalletSolution.MComm.CarrierSim.PhoneManager;
using bankAM = MW.MComm.WalletSolution.MComm.Ganadero.Simulator;
namespace MW.MComm.WMLPhone.WebUI
{
  // ------------------------------------------------------------------------------
  /// <summary>This page contains Edit Account controls for managing Account information.</summary>
  ///
  /// File History:
  /// <created>9/1/2006 (Dave Clemmer)</created>
  ///
  /// <remarks></remarks>
  // ------------------------------------------------------------------------------
  public partial class Accounts : System.Web.UI.MobileControls.MobilePage
  {
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
      //
      // CODEGEN: This call is required by the ASP.NET Web Form Designer.
      //
      InitializeComponent();
      base.OnInit(e);
    }
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.Load += new System.EventHandler(this.Page_Load);
    }
    #endregion
    mobileSession mySession; //object used to validate the session and to read metapartnerphone properties ofter validation
    private string bankPin;
    // ------------------------------------------------------------------------------
    /// <summary>Load page for managing Account.</summary>
    ///
    // ------------------------------------------------------------------------------
    private void Page_Load(object sender, System.EventArgs e)
    {
      //create a validation object and call the validation routine
      //this 2 lines should be present in all pages of this project
      //except those wich don't requiere an open session
      mySession = new mobileSession();
      mySession.validate(this);
      // Set up site labels
      this.Form1.Title = Globals.GetSiteLabel(SiteLabelDefinitionCode.AccountsTitle);
      this.lblShowDetail.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.ShowAccountHistory);
      this.cmdCreate.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.CreateStoredValueAccount);
      this.cmdAddBank.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.AddBankAccountsLabel);
      this.lblTermsTitle.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.TermsAndConditionsLabel);
      this.lblTermsText.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.TermsLabel);
      this.cmdAccept.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.AcceptButtonLabel);
      this.cmdCancel.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.CancelButtonLabel);
    }
    // ------------------------------------------------------------------------------
    /// <summary>Account data is displyed in pre render, to reflect changes.</summary>
    ///
    // ------------------------------------------------------------------------------
    protected void Form1_PreRender(object sender, EventArgs e)
    {
      if (this.panelAccounts.Visible) this.displayAccounts();

    }
    // ------------------------------------------------------------------------------
    /// <summary>Populates a list with all account data</summary>
    // ------------------------------------------------------------------------------
    void displayAccounts()
    {      //show the accounts 2=bank 3=storedvalue
      this.listAccounts.Items.Clear();
      this.listShowDetail.Items.Clear();
      int totalBank = 0; int totalStored = 0;
      string prepaidBalance = string.Empty;
      BLL.SortableList<BLL.Accounts.Account> allAccounts;
      try
      {
        allAccounts = BLL.Accounts.AccountManager.GetAllAccountDataByMetaPartnerID(
            mySession.MetaPartnerPhone.MetaPartnerID);
        if (allAccounts.Count > 0)
        {
          foreach (BLL.Accounts.Account acc in allAccounts)
          {
            MobileListItem li;
            li = new MobileListItem(Globals.GetSiteLabel(SiteLabelDefinitionCode.Account) + ": " + acc.AccountName);
            this.listAccounts.Items.Add(li);
            this.listAccounts.Items.Add("- " + Globals.GetSiteLabel(SiteLabelDefinitionCode.AccountCurrency) + ": " + acc.CurrencyName);
            this.listAccounts.Items.Add("- " + Globals.GetSiteLabel(SiteLabelDefinitionCode.AccountType) + ": " + acc.AccountSubTypeName);
            this.listAccounts.Items.Add("- " + Globals.GetSiteLabel(SiteLabelDefinitionCode.AccountDescription) + ": " + acc.Description);
            //if it's a bank account, history is available. show the link
            if (acc.AccountSubTypeCode == (int)BLL.Accounts.AccountSubTypeCode.BankAccount)
            {
              MobileListItem li2;
              li2 = new MobileListItem(acc.AccountName, "./AccountHistory.aspx?acc=" + acc.AccountID.ToString());
              this.listShowDetail.Items.Add(li2);
            }
            //get the balance from different sources
            string balance = "- " + Globals.GetSiteLabel(SiteLabelDefinitionCode.Balance) + ": ";
            try
            {
              if (acc.AccountSubTypeCode == (int)BLL.Accounts.AccountSubTypeCode.StoredValueAccount)
              {
                totalStored += 1;
                //each carrier is treated by a different web service
                if (mySession.MetaPartnerPhone.CarrierMetaPartnerID.ToString() == "6f21cc31-7f60-46b1-808a-a3300614ad11")
                {
                  balance += BLL.Accounts.StoredValueAccountManager.displayBalanceForStoredValueAccountMWCarrier(mySession.MetaPartnerPhone.PhoneNumber, Globals.LocaleCode);
                  prepaidBalance = BLL.Accounts.StoredValueAccountManager.displayBalanceForPrePaidAccountMWCarrier(mySession.MetaPartnerPhone.PhoneNumber, Globals.LocaleCode);
                }
                else //nuevatel
                  balance += BLL.Accounts.StoredValueAccountManager.displayBalanceForStoredValueAccountVIVACarrier(mySession.MetaPartnerPhone.PhoneNumber, Globals.LocaleCode);
              }
              if (acc.AccountSubTypeCode == (int)BLL.Accounts.AccountSubTypeCode.BankAccount)
              {
                totalBank += 1;
                BLL.Accounts.BankAccount bankAcc = BLL.Accounts.BankAccountManager.GetOneBankAccount(acc.AccountID);
                balance += BLL.Accounts.BankAccountManager.displayBalanceForBankAccount(bankAcc, Globals.LocaleCode);
              }
            }
            catch (Exception ex)
            {
              balance += Globals.GetSiteLabel(SiteLabelDefinitionCode.UnableToRetrieveBalance);
              ex.ToString();
            }
            this.listAccounts.Items.Add(balance);
          }
        }
        //if no stored value accounts were found, offer to create one
        this.cmdCreate.Visible = (totalStored == 0);
        //if there is a prepaid balance, display it
        if (prepaidBalance != string.Empty)
          this.listAccounts.Items.Add(Globals.GetSiteLabel(SiteLabelDefinitionCode.CarrierPrepaidBalance) + ": " + prepaidBalance);
        //if no accouts with history are available, hide the section
        this.lblShowDetail.Visible = (this.listShowDetail.Items.Count > 0);
      }
      catch
      {
        this.lblStatus.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.UnspecifiedException);
        this.lblStatus.Visible = true;
      }
    }
    // ------------------------------------------------------------------------------
    /// <summary>Cancel the creation of a sotred value accout. User did not agree to 
    /// terms and conditions</summary>
    // ------------------------------------------------------------------------------
    protected void cmdCancel_Click(object sender, EventArgs e)
    {
      this.panelAccounts.Visible = true;
      this.panelCreate.Visible = false;
    }
    // ------------------------------------------------------------------------------
    /// <summary>User did agree to 
    /// terms and conditions. Create the stored value account.</summary>
    // ------------------------------------------------------------------------------
    protected void cmdAccept_Click(object sender, EventArgs e)
    {
      try
      {
        BLL.Accounts.StoredValueAccountManager.createOrLoadSVAccounts(mySession.MetaPartnerPhone, Globals.LocaleCode);
      }
      catch
      {
        //[20070622 SBA] Reemplazo
        //this.lblStatus.Text = "There was an error creating the account.";
        this.lblStatus.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.ErrorCreatingTheAccount);
      }
    }
    // ------------------------------------------------------------------------------
    /// <summary>Display te create account panel for stored value</summary>
    // ------------------------------------------------------------------------------
    protected void cmdCreate_Click(object sender, EventArgs e)
    {
      this.panelCreate.Visible = true;
      this.panelAccounts.Visible = false;
    }
    // ------------------------------------------------------------------------------
    /// <summary>Display te create account panel for importing bank accounts</summary>
    // ------------------------------------------------------------------------------
    protected void cmdAddBank_Click(object sender, EventArgs e)
    {
      Response.Redirect("./addBankAccount.aspx");
    }
  }
}