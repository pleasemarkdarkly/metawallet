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
using System.Diagnostics;
using BLL = MW.MComm.WalletSolution.BLL;
using MW.MComm.WalletSolution.BLL.UserExperience;
using System.Web.UI.MobileControls;
namespace MW.MComm.WMLPhone.WebUI
{
  public partial class userPref : System.Web.UI.MobileControls.MobilePage
  {
    mobileSession mySession; //object used to validate the session and to read metapartnerphone properties ofter validation
    //create a validation object and call the validation routine
    protected void Page_Load(object sender, EventArgs e)
    {
      //this 2 lines should be present in all pages of this project
      //except those wich don't requiere an open session
      mySession = new mobileSession();
      mySession.validate(this);
      if (this.listAccounts.Items.Count == 0) this.fillAccounts();
      if (this.listLanguaje.Items.Count == 0) this.fillLanguajes();
      setlabels();
    }
    void setlabels()
    {
      // Set up site labels
      this.Form1.Title = Globals.GetSiteLabel(SiteLabelDefinitionCode.UserPreferencesTitle);
      this.lblFeedback.Text = string.Empty;
      this.lblTitle.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.UserPreferencesTitle);
      this.lblChangePIN.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.ChangePINButtonLabel);
      this.cmdPinChange.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.ChangePINButtonLabel);
      this.lblCurrentPIN.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.TypeCurrentPIN);
      this.lblNewPIN.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.TypeNewPIN);
      this.lblNewPIN2.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.TypeNewPINAgain);
      this.lblChangeAccount.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.ChangeDefaulAccountButton);
      this.cmdChangeAccount.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.ChangeDefaulAccountButton);
      this.cmdChangeLanguje.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.ChangeLanguageButton);
      this.lblLanguaje.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.ChangeLanguageLabel);
      this.lblPreferredAccount.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.ChangeAccountLabel);
    }
    void fillLanguajes()
    {
      this.listLanguaje.Items.Clear();
      MW.MComm.WalletSolution.BLL.SortableList<BLL.Environments.Locale> locales =
          MW.MComm.WalletSolution.BLL.Environments.LocaleManager.GetAllLocaleData();
      foreach (BLL.Environments.Locale loc in locales)
      {
        MobileListItem li = new MobileListItem(MobileListItemType.ListItem);
        li.Text = loc.LocaleName;
        li.Value = loc.LocaleCode.ToString();
        li.Selected = (loc.LocaleCode == Globals.CurrentPartner.LocaleCode);
        this.listLanguaje.Items.Add(li);
      }
    }
    void fillAccounts()
    {
      this.listAccounts.Items.Clear();
      //show the accounts
      BLL.SortableList<BLL.Accounts.DebitAccount> allAccounts;
      allAccounts = BLL.Accounts.DebitAccountManager.GetAllDebitAccountDataByMetaPartnerID(
          mySession.MetaPartnerPhone.MetaPartnerID);
      if (allAccounts.Count > 0)
      {
        foreach (BLL.Accounts.DebitAccount acc in allAccounts)
        {
          MobileListItem li = new MobileListItem();
          li.Value = acc.AccountID.ToString();
          if (acc.Description != string.Empty)
          {
            li.Text = acc.Description + " (" + acc.AccountSubTypeName + ")";
          }
          else
          {
            li.Text = acc.AccountName + " (" + acc.AccountSubTypeName + ")";
          }
          if (acc.IsDefaultDebitAccount) li.Selected = true;
          this.listAccounts.Items.Add(li);
        }
      }
    }
    protected void cmdPinChange_Click(object sender, EventArgs e)
    {
      string oldPin, newPin1, newPin2, actualPin;
      oldPin = this.inputPin.Text.Trim();
      newPin1 = this.inputPIN1.Text.Trim();
      newPin2 = this.inputPIN2.Text.Trim();
      actualPin = mySession.MetaPartnerPhone.PIN;
      if (oldPin != actualPin || newPin1 != newPin2 || oldPin == newPin1)
      {
        this.lblFeedback.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.ChangePINparametersIncorrect);
      }
      else
      {
        try
        {
          mySession.MetaPartnerPhone.PIN = newPin1;
          BLL.Customers.MetaPartnerPhoneManager.UpsertOneMetaPartnerPhone(
              mySession.MetaPartnerPhone, true);
          this.lblFeedback.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.PINhasBeenChanged);
        }
        catch
        {
          this.lblFeedback.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.UnspecifiedException);
        }
      }
    }
    protected void cmdChangeAccount_Click1(object sender, EventArgs e)
    {
      try
      {
        Guid acc;
        acc = new Guid(this.listAccounts.Selection.Value);
        this.setAccount(acc);
        this.lblFeedback.Text = "";
      }
      catch
      {
        this.lblFeedback.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.UnspecifiedException);
      }
    }
    void setAccount(System.Guid acc1)
    {
      BLL.SortableList<BLL.Accounts.DebitAccount> allAccounts;
      allAccounts = BLL.Accounts.DebitAccountManager.GetAllDebitAccountDataByMetaPartnerID(
          mySession.MetaPartnerPhone.MetaPartnerID);
      if (allAccounts.Count > 0)
      {
        foreach (BLL.Accounts.DebitAccount accD in allAccounts)
        {
          bool previousState = accD.IsDefaultDebitAccount;
          accD.IsDefaultDebitAccount = (accD.AccountID == acc1);
          if (previousState != accD.IsDefaultDebitAccount) BLL.Accounts.DebitAccountManager.UpdateOneDebitAccount(accD, true);
        }
      }
    }
    protected void cmdChangeLanguje_Click(object sender, EventArgs e)
    {
      try
      {
        Globals.CurrentPartner.LocaleCode = int.Parse(this.listLanguaje.Selection.Value);
        BLL.Customers.MetaPartnerManager.UpsertOneMetaPartner(Globals.CurrentPartner, true);
        setlabels();
      }
      catch
      {
        this.lblFeedback.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.UnspecifiedException);
      }
    }
  }
}