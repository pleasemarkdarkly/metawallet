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
using MultiBank = MW.MComm.WalletSolution.MComm.MultiBank.Simulator;
namespace MW.MComm.WMLPhone.WebUI
{
  public partial class makePayment : System.Web.UI.MobileControls.MobilePage
  {
    mobileSession mySession; //object used to validate the session and to read metapartnerphone properties ofter validation
    protected void Page_Load(object sender, EventArgs e)
    {
      //create a validation object and call the validation routine
      //this 2 lines should be present in all pages of this project
      //except those wich don't requiere an open session
      mySession = new mobileSession();
      mySession.validate(this);
      // Set up site labels
      this.Form1.Title = Globals.GetSiteLabel(SiteLabelDefinitionCode.SendAndReceiveTitle);
      this.lblAmount.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.PaymentAmountLabel);// +" (" + Globals.GetSiteLabel(SiteLabelDefinitionCode.BolivianosLabel) + "): ";
      this.lblDestinationPhone.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.DestinationTelephoneInputLabel);
      this.cmdMakeOrder.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.SendButtonLabel);
      this.lblPIN.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.EnterBankPin);
      this.lblOthers.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.OtherOptions);
      if (!this.IsPostBack)
      {
        fillAccounts();
      }
    }
    void fillAccounts()
    {
      this.AccountList1.populate(Globals.CurrentPartner,BLL.Accounts.AccountSubTypeCode.BankAccount,
        BLL.Accounts.AccountSubTypeCode.BankAccount,BLL.Accounts.AccountSubTypeCode.BankAccount,
        Globals.GetSiteLabel(SiteLabelDefinitionCode.SelectSourceAccount));
    }
    protected void cmdMakeOrder_Click(object sender, EventArgs e)
    {
      try
      {
        if (validateInputFields() && validateAccount())
        {
          BLL.Accounts.BankAccount
            bankAcc = this.AccountList1.selectedBankAccount();
          MultiBank.multiBank BankService = new MultiBank.multiBank();
          MultiBank.AccountQueryResult acQuery = BankService.accountInfo(
            bankAcc.BankMetaPartnerID, bankAcc.BankCustomerCode, bankAcc.DebitAccountNumber);
          MultiBank.account accInfo;
          if (acQuery.ErroCode==0)
          {
            accInfo = acQuery.Accountdata;
            //validate funds availability
            if (accInfo.AccountBalance < decimal.Parse(this.amount.Text))
            {
              this.lblStatus.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.OrderErrorNotEnoughBalance);
              this.lblStatus.Visible = true;
              this.lblStatus.StyleReference = "error";
            }
            //validate destination account existance
            this.destinationPhone.Text = this.destinationPhone.Text.Trim();
            if (this.destinationPhone.Text.Length == 8 & this.destinationPhone.Text.StartsWith("7"))
              this.destinationPhone.Text = "591" + this.destinationPhone.Text;
            BLL.Customers.MetaPartnerPhone destination =
                BLL.Customers.MetaPartnerPhoneManager.GetOneMetaPartnerPhoneByPhoneNumber(
                this.destinationPhone.Text);
            if (destination == null)
            {
              this.lblStatus.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.OrderErrorUnknownPhone);
              this.lblStatus.Visible = true;
              this.lblStatus.StyleReference = "error";
            }
            else
            {
              BLL.SortableList<BLL.Accounts.BankAccount> allAccounts;
              allAccounts = BLL.Accounts.BankAccountManager.GetAllBankAccountDataByMetaPartnerID(destination.MetaPartnerID);
              if (allAccounts.Count == 0)
              {
                this.lblStatus.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.OrderErrorNoAccounts);
                this.lblStatus.StyleReference = "error";
                this.lblStatus.Visible = true;
              }
              else
              {
                //do the transfer
                MultiBank.TransferResult result1;
                try
                {
                  BLL.Accounts.BankAccount destinationAcc =
                      (BLL.Accounts.BankAccount)allAccounts[0];
                  result1 = BankService.transfer(
                    bankAcc.BankMetaPartnerID, bankAcc.BankCustomerCode, bankAcc.DebitAccountNumber,
                    destinationAcc.BankMetaPartnerID, destinationAcc.BankCustomerCode, destinationAcc.DebitAccountNumber,
                    decimal.Parse(this.amount.Text), bankAcc.CurrencyName, "");
                    /*s_BG.AccountTransfer(bankAcc.BankCustomerCode, this.PIN.Text
                      mySession.MetaPartnerPhone.PIN, "0",
                      bankAcc.DebitAccountNumber, destinationAcc.DebitAccountNumber, decimal.Parse(this.amount.Text), "BS");*/
                }
                catch (Exception ex)
                {
                  result1 = new MultiBank.TransferResult();
                  result1.ErrorText = ex.Message.Replace("\r\n"," ");
                  result1.ErrorCode = -1;
                }
                if (result1.ErrorCode != 0)
                {
                  this.lblStatus.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.OrderProcessingError) +
                      " " + result1.ErrorText;
                  this.lblStatus.Visible = true;
                }
                else
                {
                  this.panelResult.Visible = true;
                  this.panelPay.Visible = false;
                  this.lblResult.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.OrderProcessed);
                  try
                  {
                      string message = mySession.MetaPartnerPhone.MetaPartnerName + "  " +
                      Globals.GetSiteLabel(SiteLabelDefinitionCode.PaymentReceivedSMS) +
                      " " + decimal.Parse(this.amount.Text).ToString("0.00") + " " + 
                      Globals.GetSiteLabel(SiteLabelDefinitionCode.USDviaMetawallet) +
                      " / " + Globals.GetSiteLabel(SiteLabelDefinitionCode.Balance) + ":" + 
                      result1.NewBalanceReceiver.AccountBalance.ToString("0.00");
                    notificactions.sendNotification(mySession.MetaPartnerPhone, destination, message);
                  }
                  catch
                  {
                    this.lblResult.Text += Globals.GetSiteLabel(SiteLabelDefinitionCode.NotificationError);
                  }
                }
              }
            }
          }
        }
      }
      catch (Exception ex)
      {
        this.lblStatus.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.UnspecifiedException) + " " + ex.Message.Replace("\r\n"," ");
        this.lblStatus.Visible = true;
      }
    }
    protected bool validateInputFields()
    {
      //all the fields should be filled
      //this validation is aditional to any mobile controls validators used
      if (this.destinationPhone.Text.Trim() == string.Empty)
      {
        this.lblStatus.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.OrderErrorUnspecifiedDestination); ;
        this.lblStatus.StyleReference = "error";
        this.lblStatus.Visible = true;
        return false;
      }
      else if (this.amount.Text.Trim() == string.Empty)
      {
        this.lblStatus.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.OrderErrorUnspecifiedAmount);
        this.lblStatus.StyleReference = "error";
        this.lblStatus.Visible = true;
        return false;
      }
      else if (decimal.Parse(this.amount.Text) <= 0)
      {
        this.lblStatus.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.OrderErrorUnspecifiedAmount);
        this.lblStatus.StyleReference = "error";
        this.lblStatus.Visible = true;
        return false;
      }
      return true;
    }
    public bool validateAccount()
    {
      //validate account exists and has been selected
      BLL.Accounts.BankAccount
          bankAcc = this.AccountList1.selectedBankAccount();
      if (bankAcc == null)
      {
        //[20070622 SBA] Reemplazo 
        //this.lblStatus.Text = "You don't seem to have a bank account";
        this.lblStatus.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.NoBankAccount);
        this.lblStatus.Visible = true;
        return false;
      }
      else
        return true;
    }
  }
}