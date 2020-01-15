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
using DAL = MW.MComm.WalletSolution.DAL;
using MW.MComm.WalletSolution.BLL.UserExperience;
namespace MW.MComm.WMLPhone.WebUI
{
  public partial class reseller : System.Web.UI.MobileControls.MobilePage
  {
    BLL.Accounts.StoredValueAccount stored1;
    mobileSession mySession; //object used to validate the session and to read metapartnerphone properties ofter validation
    protected void Page_Load(object sender, EventArgs e)
    {
      //create a validation object and call the validation routine
      //this 2 lines should be present in all pages of this project
      //except those wich don't requiere an open session
      mySession = new mobileSession();
      mySession.validate(this);
      // Set up site labels
      this.Form1.Title = Globals.GetSiteLabel(SiteLabelDefinitionCode.MobileFormsTitle);
      //[20070622 SBA] Reemplazo 
      //this.lblWelcome.Text = "Welcome, " + Globals.CurrentPartner.MetaPartnerName + " to the reseller application";
      this.lblWelcome.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.WelcomeLabel) + " " + Globals.CurrentPartner.MetaPartnerName + " " + Globals.GetSiteLabel(SiteLabelDefinitionCode.ResellerApplication);
      this.Label1.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.SellCredit)+":";
      this.Label2.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.DifferentAmountLabel) + ":";
      this.Label3.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.CustomerphoneLabel);
      this.cmdSell.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.SellButtonLabel);
      this.cmdNextSell.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.ContinueButtonLabel);
      this.lblSuceess.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.Label);        

         //load default account
      BLL.SortableList<BLL.Accounts.StoredValueAccount> sortableList
        = BLL.Accounts.StoredValueAccountManager.GetAllStoredValueAccountDataByMetaPartnerID(Globals.CurrentPartner.MetaPartnerID);
      if (sortableList.Count > 0)
      {
        foreach (BLL.Accounts.StoredValueAccount x in sortableList)
        {
          if (x.IsDefaultDebitAccount) stored1 = x;
        }
        if (stored1 == null) stored1 = sortableList[0];
      }
      if (stored1 == null)
      {
        //stored1 = new MW.MComm.WalletSolution.BLL.Accounts.StoredValueAccount();
        //stored1.AccountSubTypeCode = (int)BLL.Accounts.AccountSubTypeCode.StoredValueAccount;
        //stored1.Balance = 0;
        //stored1.CarrierBalance = 0;
        //stored1.Currency = BLL.Accounts.CurrencyManager.GetOneCurrency(2);
        //stored1.DebitAccountNumber = 1.ToString();
        //stored1.BankCustomerCode = "";
        //stored1.Description = "";
        //stored1.IsActive = true;
        //stored1.MetaPartnerID = Globals.CurrentPartner.MetaPartnerID;
        //stored1.MetaPartnerPhoneID = Globals.CurrentPhone.MetaPartnerPhoneID;
        //stored1.IsDefaultDebitAccount = true;
        //BLL.Accounts.StoredValueAccountManager.AddOneStoredValueAccount(stored1, true);
          //[20070622 SBA] Reemplazo 
          //this.lblError.Text = "You do not have an stored value account.";
          this.lblError.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.NotStoredValueAccount);
      }
    }
    protected void Form1_PreRender(object sender, EventArgs e)
    {
      try
      {
          //[20070622 SBA] Reemplazo 
          //this.lblBalance.Text = "Your current balance for reselling credit is:" + stored1.Balance.ToString("0.00") + "[" + stored1.Currency.CurrencyName + "]";
          this.lblBalance.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.CurrentBalanceResellingCredit)+ ":" + stored1.Balance.ToString("0.00") + "[" + stored1.Currency.CurrencyName + "]";          
      }
      catch
      { }
    }
    protected void cmdSell_Click(object sender, EventArgs e)
    {
      int amount = 0;
      int amountClient = 0;
      string customerphone;
      //validate
      try
      {
        amount = int.Parse(this.listAmount.Selection.Value);
        if (amount == 0)
        {
          amount = (int)decimal.Parse(this.textAmount.Text);
        }
        if (amount == 0)
        {
            //[20070622 SBA] Reemplazo 
            //throw new Exception("Unable to read amount");
            throw new Exception(Globals.GetSiteLabel(SiteLabelDefinitionCode.UnableToReadAmount));
        }
      }
      catch
      {
          //[20070622 SBA] Reemplazo 
          //this.lblError.Text = "Plese select or enter a vallid amount, with no cents.";
          this.lblError.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.InvallidAmount);
          
        return;
      }
      if (amount > stored1.Balance)
      {
          //[20070622 SBA] Reemplazo 
        //this.lblError.Text = "Plese select or enter a vallid amount that does not excede your current balance.";
          this.lblError.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.ExcededAmount);
        return;
      }
      customerphone = this.textPhoneNumber.Text;
      if (customerphone.Trim() == string.Empty || customerphone.Trim().Length != 8 || !customerphone.StartsWith("70"))
      {
          //[20070622 SBA] Reemplazo 
        //this.lblError.Text = "Please specify a valid customer phone";
          this.lblError.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.InvalidCustomerPhone);
        return;
      }
      customerphone = "591" + customerphone;
      //validate ends
      //find if the user is a valid metapartner or a new customer
      //add credit to the user
      try
      {
        if (amount == 50)
        {
          amountClient = 55;
        }
        else if (amount == 90)
        {
          amountClient = 105;
        }
        else
        {
          amountClient = amount;
        }
        WalletSolution.MComm.Nuevatel.CustomerManager.Service1 nuevatel1 = new MW.MComm.WalletSolution.MComm.Nuevatel.CustomerManager.Service1();
        WalletSolution.MComm.Nuevatel.CustomerManager.addCreditResponse result1;
        result1 = nuevatel1.wsAddCredit(customerphone, "1", (decimal)amountClient, string.Empty, string.Empty, "metawallet");
        if (result1.errorCode !=-1)
        {
          stored1.Balance -= amount;
            BLL.Accounts.StoredValueAccountManager.UpdateOneStoredValueAccount(stored1, true);
            //[20070622 SBA] Reemplazo 
            //notificactions.sendNotification(Globals.CurrentPhone, customerphone, "You have received credit on your phone. Your balance was added " + amountClient.ToString() +
            //" from " + Globals.CurrentPhone.PhoneNumber.Replace("59170", "70"));
            notificactions.sendNotification(Globals.CurrentPhone, customerphone,Globals.GetSiteLabel(SiteLabelDefinitionCode.CreditOnYourPhone)+ " " + amountClient.ToString() +
            " " + Globals.GetSiteLabel(SiteLabelDefinitionCode.From) + " " + Globals.CurrentPhone.PhoneNumber.Replace("59170", "70"));
          this.panelSell.Visible = false;
          this.panelSuccess.Visible = true;

          //[20070622 SBA] Reemplazo 
          //this.lblSuceess.Text = "Transaction completed. The client balance was added Bs." + amountClient.ToString() + " Your balance was deduced Bs." +amount.ToString();
          this.lblSuceess.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.ClientBalanceWasAddedBs) + amountClient.ToString() + " " + Globals.GetSiteLabel(SiteLabelDefinitionCode.BalanceWasDeducedBs) + amount.ToString();            
        }
      }
      catch
      {
          //[20070622 SBA] Reemplazo 
//        this.lblError.Text = "Unable to process transaction. Please try again later.";
          this.lblError.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.UnableToProcessTransaction);
      }
    }
    protected void cmdNextSell_Click(object sender, EventArgs e)
    {
      this.panelSell.Visible = true;
      this.panelSuccess.Visible = false;
    }
}
}
