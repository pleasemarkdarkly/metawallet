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

  public partial class TransferSelf : System.Web.UI.MobileControls.MobilePage
  {
    #region auxiliar
    mobileSession mySession; //object used to validate the session and to read metapartnerphone properties ofter validation
    protected void Page_Load(object sender, EventArgs e)
    {
      //[20070622 SBA] Reemplazo  
      this.lblAmount.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.AmounttotransferLabel);
      this.lblMemo.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.Memo);
      this.cmdTransfer.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.TransferButtonLabel);
      mySession = new mobileSession();
      mySession.validate(this);
      if (!IsPostBack) populateAccounts();
    }
    #endregion
    #region methods
    void populateAccounts()
    {
      this.AccountList1.populate(Globals.CurrentPartner,
        BLL.Accounts.AccountSubTypeCode.StoredValueAccount,
        BLL.Accounts.AccountSubTypeCode.BankAccount,
        BLL.Accounts.AccountSubTypeCode.StoredValueAccount, Globals.GetSiteLabel(SiteLabelDefinitionCode.SelectAccountToDebitFrom));
      this.AccountList2.populate(Globals.CurrentPartner,
        BLL.Accounts.AccountSubTypeCode.StoredValueAccount,
        BLL.Accounts.AccountSubTypeCode.BankAccount,
        BLL.Accounts.AccountSubTypeCode.StoredValueAccount, Globals.GetSiteLabel(SiteLabelDefinitionCode.SelectAccountToCredit));
    }
    protected void transfer()
    {
      decimal Amount = 0;
      BLL.Accounts.Account OriginAccount, DestinationAccount;
      //validation
      try
      {
        Amount = decimal.Parse(this.textAmount.Text);
        if (Amount <= 0) throw new Exception(Globals.GetSiteLabel(SiteLabelDefinitionCode.EnterAValidAmount));
      }
      catch
      {
        this.labelError.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.PleaseEnterValidAmount);
        return;
      }
      try
      {
        OriginAccount = this.AccountList1.selectedAccount();
        DestinationAccount = this.AccountList2.selectedAccount();
        if (OriginAccount == null || DestinationAccount == null)
        {
          this.labelError.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.BothAccountsMustBeSelected);
          return;
        }
        if (OriginAccount.AccountID == DestinationAccount.AccountID)
        {
          this.labelError.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.BothSelectedAccountsCantBeTheSame);
          return;
        }
      }
      catch
      {
        this.labelError.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.BothAccountsMustBeSpecified);
        return;
      }
      //generate the transaction based on the account types:
      string errorText = string.Empty;
      if (BLL.Accounts.AccountManager.AccountToAccountTransfer(OriginAccount, DestinationAccount, Amount,
        this.textMemo.Text,Globals.GetSiteLabel(SiteLabelDefinitionCode.SelfTransfer),
        Globals.LocaleCode,out errorText))
      {
        Response.Redirect("./default.aspx?displaytext=" + Globals.GetSiteLabel(
          SiteLabelDefinitionCode.TransferSuccesful) +
          " / " + Globals.GetSiteLabel(SiteLabelDefinitionCode.NewBalance) + ": " + errorText);
      }
      else
      {
        this.labelError.Text = errorText;
      }
    }
    #endregion
    #region events
    protected void cmdTransfer_Click(object sender, EventArgs e)
    {
      transfer();
    }
    #endregion
  }
}