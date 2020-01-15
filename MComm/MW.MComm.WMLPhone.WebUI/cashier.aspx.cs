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
  public partial class cashier : System.Web.UI.MobileControls.MobilePage
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
      this.Form1.Title = Globals.GetSiteLabel(SiteLabelDefinitionCode.MobileFormsTitle);
      //[20070622 SBA] Reemplazo 
      //this.lblWelcome.Text = "Welcome, " + Globals.CurrentPartner.MetaPartnerName + " to the cashier application";
      this.lblWelcome.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.WelcomeLabel) + " "+ Globals.CurrentPartner.MetaPartnerName + Globals.GetSiteLabel(SiteLabelDefinitionCode.CashierApplication);
      this.Label1.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.AmountReceivedLabel);
      this.Label2.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.ResellerNumberLabel) + ":" ;
      this.cmdAdd.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.AddCreditButtonLabel);
      this.cmdNextSell.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.ContinueButtonLabel);
    }
    protected void cmdAdd_Click(object sender, EventArgs e)
    {
      decimal amountRec;
      string phone;
      MW.MComm.WalletSolution.BLL.Customers.MetaPartnerPhone mphone;
      BLL.Accounts.StoredValueAccount stored1=null;
      //valdate
      try
      {
        amountRec = decimal.Parse(this.textAmount.Text);
        //[20070622 SBA] Reemplazo 
        //if (amountRec < 0) throw new Exception("Negative amount entered");
        if (amountRec < 0) throw new Exception(Globals.GetSiteLabel(SiteLabelDefinitionCode.NegativeAmountEntered));
      }
      catch
      {
          //[20070622 SBA] Reemplazo 
        //this.lblError.Text = "Please enter a valid amount.";
          this.lblError.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.EnterAValidAmount);
        return;
      }
      try
      {
        phone = this.textPhone.Text.Trim();
        if (phone.Length == 8) phone = "591" + phone;
        mphone = MW.MComm.WalletSolution.BLL.Customers.MetaPartnerPhoneManager.GetOneMetaPartnerPhoneByPhoneNumber(phone);
        if (mphone == null)
        {
            //[20070622 SBA] Reemplazo 
            //this.lblError.Text = "Reseller " + phone + " not found";
            this.lblError.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.Reseller) + " " + phone + " " + Globals.GetSiteLabel(SiteLabelDefinitionCode.NotFound);
          return;
        }
        else
        {
          BLL.Customers.MetaPartner mpart = BLL.Customers.MetaPartnerManager.GetOneMetaPartner(mphone.MetaPartnerID);
          //[20070622 SBA] Reemplazo
            //if (mpart.MetaPartnerSubTypeName.ToLower() != "reseller")
            if (mpart.MetaPartnerSubTypeName.ToLower() != Globals.GetSiteLabel(SiteLabelDefinitionCode.Reseller))
          {
              //[20070622 SBA] Reemplazo 
              //this.lblError.Text = "Customer " + phone + " is not a reseller.";
              this.lblError.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.Customer) + " " + phone + " " + Globals.GetSiteLabel(SiteLabelDefinitionCode.IsNotAReseller);
            return;
          }
          //validate stored value account
          BLL.SortableList<BLL.Accounts.StoredValueAccount> sortableList
          = BLL.Accounts.StoredValueAccountManager.GetAllStoredValueAccountDataByMetaPartnerID(mpart.MetaPartnerID);
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
              //[20070622 SBA] Reemplazo 
              //this.lblError.Text = "Reseller does not have an stored value account.";
              this.lblError.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.ResellerWithoutAValueAccount);
            return;
          }
          else
          {
            stored1.Balance += amountRec * (decimal)1.1;
            BLL.Accounts.StoredValueAccountManager.UpdateOneStoredValueAccount(stored1,true);
            //[20070622 SBA] Reemplazo 
              //this.lblSucess.Text = "Reseller balance was added Bs." + (amountRec * (decimal)1.1).ToString("0.00") + " The new balance is: " + stored1.Balance.ToString("0.00");
            this.lblSucess.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.ResellerBalanceWasAdded) + (amountRec * (decimal)1.1).ToString("0.00") + " " + Globals.GetSiteLabel(SiteLabelDefinitionCode.NewBalance) + " " + stored1.Balance.ToString("0.00");
            this.panelRecive.Visible = false;
            this.panelSuccess.Visible = true;
          }
        }
      }
      catch (Exception ex)
      {
        this.lblError.Text = ex.Message;
      }
    }
    protected void cmdNextSell_Click(object sender, EventArgs e)
    {
      this.panelRecive.Visible = true;
      this.panelSuccess.Visible = false;
    }
}
}
