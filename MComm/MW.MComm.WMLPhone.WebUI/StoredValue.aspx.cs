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
  public partial class StoredValue : System.Web.UI.MobileControls.MobilePage
  {
    mobileSession mySession; //object used to validate the session and to read metapartnerphone properties ofter validation
    protected void Page_Load(object sender, EventArgs e)
    {
      //validate session
      mySession = new mobileSession();
      mySession.validate(this);
      //
      //[20070622 SBA] Reemplazo 
      //this.Form1.Title = "Stored Value transactions";
      this.Form1.Title = Globals.GetSiteLabel(SiteLabelDefinitionCode.StoredValueTransactionsFormTitle);
      this.Label1.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.TransferStoredValueLabel);
      this.Label3.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.DestinationPhoneNumberLabel) + ":";
      this.Label2.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.AmountLabel) + ":";
      this.cmdTransfer.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.TransferButtonLabel);


      if (!IsPostBack)
      {
        //[20070622 SBA] Reemplazo 
        //this.AccountList1.populate(Globals.CurrentPartner,
        //  BLL.Accounts.AccountSubTypeCode.StoredValueAccount,
        //  BLL.Accounts.AccountSubTypeCode.StoredValueAccount,
        //  BLL.Accounts.AccountSubTypeCode.StoredValueAccount,
        //  "Specify the account to transfer from");


        this.AccountList1.populate(Globals.CurrentPartner,
        BLL.Accounts.AccountSubTypeCode.StoredValueAccount,
        BLL.Accounts.AccountSubTypeCode.StoredValueAccount,
        BLL.Accounts.AccountSubTypeCode.StoredValueAccount,
        Globals.GetSiteLabel(SiteLabelDefinitionCode.SpecifyAccountToTransferFrom));
      }
    }
    protected void cmdTransfer_Click(object sender, EventArgs e)
    {
      decimal amount;
      BLL.Customers.MetaPartnerPhone DestinationPhone;
      BLL.Accounts.StoredValueAccount sending, receiving;
      string erroText = string.Empty;
      bool success = false;
      //validate sending account
      try
      {
        sending = this.AccountList1.selectedStoredValueAccount();
        //[20070622 SBA] Reemplazo 
        //if (sending == null) throw new Exception("User does not have an stored value account.");
        if (sending == null) throw new Exception(Globals.GetSiteLabel(SiteLabelDefinitionCode.UserWithoutValueAccount));
      }
      catch
      {
        //[20070622 SBA] Reemplazo 
        //this.labelError.Text = "Unable to identify your stored value account.";
        this.labelError.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.UnableToIdentifyValueAccount);
        return;
      }
      //validate monet amount
      try
      {
        amount = decimal.Parse(this.textAmount.Text);
      }
      catch
      {
        //[20070622 SBA] Reemplazo 
        //this.labelError.Text = "Please specify a valid amount";
        this.labelError.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.SpecifyAValidAmount);
        return;
      }
      //validate destination account
      try
      {
        DestinationPhone = BLL.Customers.MetaPartnerPhoneManager.GetOneMetaPartnerPhoneByPhoneNumber(
          this.textPhone.Text);
        //[20070622 SBA] Reemplazo 
        //if (DestinationPhone == null) throw new Exception("The specified phone does not belong to a Meta Partner Stored Value Account Holder");
        if (DestinationPhone == null) throw new Exception(Globals.GetSiteLabel(SiteLabelDefinitionCode.InvalidPhone));
        receiving = BLL.Accounts.StoredValueAccountManager.GetAllStoredValueAccountDataByMetaPartnerID(
          DestinationPhone.MetaPartnerID)[0];
      }
      catch
      {
        //[20070622 SBA] Reemplazo 
        //this.labelError.Text = "The specified phone does not belong to a Meta Partner Stored Value Account Holder";
        this.labelError.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.InvalidPhone);
        return;
      }
      //all data items for the transaction have been loaded, perform the transaction
      try
      {
        success = BLL.Accounts.StoredValueAccountManager.transferStoredValue(sending, receiving, amount, out erroText, Globals.LocaleCode);
        if (!success)
        {
          this.labelError.Text = erroText.Replace("\r\n", " ");
          return;
        }
      }
      catch
      {
        //[20070622 SBA] Reemplazo 
        //this.labelError.Text = "Unable to perform transfer.";
        this.labelError.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.UnableToPerformTransfer);
        return;
      }
      //[20070622 SBA] Reemplazo
      //this.Session["displayText"]="Your transfer was succesful. Thanks for using MetaWallet.";
      this.Session["displayText"] = Globals.GetSiteLabel(SiteLabelDefinitionCode.TransferSuccesful);
      //[20070626 SBA] OLD CODE
      // if (success) Response.Redirect("default.aspx");
      //[20070626 SBA] NEW CODE
      if (success)
      {
        //[20070622 SBA] Reemplazo
        //string message = mySession.MetaPartnerPhone.MetaPartnerName + "  " +
        //  Globals.GetSiteLabel(SiteLabelDefinitionCode.PaymentReceivedSMS) +
        //  " " + amount.ToString("0.00") + " USD via Metawallet.";          
        //notificactions.sendNotification(mySession.MetaPartnerPhone, DestinationPhone.PhoneNumber, message);
        //this.Session["displayText"] = "Your transfer was succesful. Thanks for using MetaWallet.";
        //Response.Redirect("default.aspx");

        string message = mySession.MetaPartnerPhone.MetaPartnerName + "  " +
          Globals.GetSiteLabel(SiteLabelDefinitionCode.PaymentReceivedSMS) +
          " " + amount.ToString("0.00") + " " + Globals.GetSiteLabel(SiteLabelDefinitionCode.USDviaMetawallet);
        notificactions.sendNotification(mySession.MetaPartnerPhone, DestinationPhone.PhoneNumber, message);
        this.Session["displayText"] = Globals.GetSiteLabel(SiteLabelDefinitionCode.TransferSuccesful);
        Response.Redirect("default.aspx");
      }
    }
  }
}