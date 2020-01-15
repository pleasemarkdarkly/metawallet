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
  public partial class BuyPrepaid : System.Web.UI.MobileControls.MobilePage
  {
    mobileSession mySession; //object used to validate the session and to read metapartnerphone properties ofter validation
    protected void Page_Load(object sender, EventArgs e)
    {
      //validate session
      mySession = new mobileSession();
      mySession.validate(this);
      //
      //[20070622 SBA] Reemplazo 
      //this.Form1.Title = "Buy prepaid talk-time";
      this.Form1.Title = Globals.GetSiteLabel(SiteLabelDefinitionCode.BuyPrepaidFormTitle);
      this.Label3.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.DestinationPhoneNumberLabel)+":";
      this.Label1.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.LeavePhoneNumberBlankLabel);
      this.Label2.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.AmountLabel)+":";
      this.cmdBuy.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.BuyButtonLabel);

      if (!IsPostBack)
      {
          //[20070622 SBA] Reemplazo 
        //this.AccountList1.populate(Globals.CurrentPartner, BLL.Accounts.AccountSubTypeCode.StoredValueAccount,
        //  BLL.Accounts.AccountSubTypeCode.BankAccount, BLL.Accounts.AccountSubTypeCode.BankAccount,
        //  "Select the account to withdraw funds from");
        this.AccountList1.populate(Globals.CurrentPartner, BLL.Accounts.AccountSubTypeCode.StoredValueAccount,
        BLL.Accounts.AccountSubTypeCode.BankAccount, BLL.Accounts.AccountSubTypeCode.BankAccount,
        Globals.GetSiteLabel(SiteLabelDefinitionCode.SelectTheAccountAccountList));
      }
    }
    protected void cmdBuy_Click(object sender, EventArgs e)
    {
      decimal amount;
      BLL.Accounts.Account sending;
      BLL.Customers.MetaPartnerPhone receiving;
      //validate money
      try
      {
        amount = decimal.Parse(this.textAmount.Text);
        if (amount <= 0) throw new Exception(Globals.GetSiteLabel(SiteLabelDefinitionCode.NegativeAmountEntered));
      }
      catch
      {
          this.labelError.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.EnterAValidAmount);
        return;
      }
      //validate account
      try
      {
        sending = this.AccountList1.selectedAccount();
        if (sending == null) throw new Exception();
      }
      catch
      {
          this.labelError.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.UnableToFindAccount);
        return;
      }
      //validate receiver
      try
      {
        if (this.textPhone.Text.Trim() == string.Empty)
          receiving = Globals.CurrentPhone;
        else
          receiving = BLL.Customers.MetaPartnerPhoneManager.GetOneMetaPartnerPhoneByPhoneNumber(this.textPhone.Text);
      if (receiving == null) throw new Exception(Globals.GetSiteLabel(SiteLabelDefinitionCode.RecevingPhoneNotFound));
      }
      catch
      {
          this.labelError.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.RecevingPhoneNotFound);
        return;
      }
      try
      //all input validated, initiate the transaction
      {
        string errorText;
        if (BLL.Customers.MetaPartnerPhoneManager.buyPrePaidMinutesFromAccount(
          receiving, sending, Globals.CurrentPhone, amount, Globals.CurrentPhone.PIN,
          Globals.GetSiteLabel(SiteLabelDefinitionCode.BuyPrepaidMinutesLink)
          , out errorText, Globals.LocaleCode))
        {
            Session["displaText"] = Globals.GetSiteLabel(SiteLabelDefinitionCode.BuyPrePaidMinutesSuccessful);
          Response.Redirect("./default.aspx" );
        }
        else
        {
          this.labelError.Text = errorText;
          return;
        }
      }
      catch { }
    }
}
}