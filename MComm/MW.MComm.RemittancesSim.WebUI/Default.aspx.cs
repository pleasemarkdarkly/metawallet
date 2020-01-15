using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using BLL = MW.MComm.WalletSolution.BLL;
namespace MW.MComm.RemittancesSim.WebUI
{
  public partial class _Default : System.Web.UI.Page
  {
    BLL.Customers.MetaPartner partner;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void cmdSearch_Click(object sender, EventArgs e)
    {
      BLL.Customers.MetaPartnerPhone phone;
      phone = BLL.Customers.MetaPartnerPhoneManager.GetOneMetaPartnerPhoneByPhoneNumber(
        this.textPhone.Text);
      if (phone != null)
      {
        partner = phone.MetaPartner;
        this.Session["phone"] = phone;
        this.displayPArtner();
        this.lblFeedback.Text = "Customer found";
      }
    }
    void displayPArtner()
    {
      if (partner == null)
      {
        this.panelCustomer.Visible = false;
      }
      else
      {
        this.panelCustomer.Visible = true;
        this.listAccount.Items.Clear();
        this.lblCustomerName.Text = partner.MetaPartnerName;
        foreach (BLL.Accounts.StoredValueAccount sv in partner.StoredValueAccountList)
        {
          ListItem li = new ListItem();
          li.Text = sv.AccountSubTypeName + ": " + sv.AccountName + " (" + sv.CurrencyName + ")";
          li.Value = sv.AccountID.ToString();
          this.listAccount.Items.Add(li);
        }
        foreach (BLL.Accounts.BankAccount sv in partner.BankAccountList)
        {
          ListItem li = new ListItem();
          li.Text = sv.AccountSubTypeName + ": " + sv.AccountName + " " + sv.DebitAccountNumber + " (" + sv.CurrencyName + ")";
          li.Value = sv.AccountID.ToString();
          this.listAccount.Items.Add(li);
        }
      }
    }
    protected void panelCustomer_PreRender(object sender, EventArgs e)
    {
      if (listAccount.Items.Count > 0 && listAccount.SelectedIndex == -1)
        listAccount.SelectedIndex = 0;
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
      decimal amount = 0;
      bool success = false;
      string errorText = string.Empty;
      //validat the amount
      try
      {
        amount = decimal.Parse(this.textAmount.Text);
      }
      catch
      {
      }
      if (amount <= 0)
      {
        lblFeedback.Text = "Invalid money amount";
        return;
      }
      //validate sender's data
      if (this.textSenderName.Text.Trim() == string.Empty)
      {
        lblFeedback.Text = "The sender's name must be entered";
        return;
      }
      //validate selected account
      BLL.Accounts.Account acc;
      try
      {
        acc = BLL.Accounts.AccountManager.GetOneAccount(new Guid(this.listAccount.SelectedItem.Value));
        //account and ammount validated
        if (acc.AccountSubTypeCode == (int)BLL.Accounts.AccountSubTypeCode.BankAccount)
        {
          decimal newBalance;
          BLL.Accounts.BankAccount bankAcc = BLL.Accounts.BankAccountManager.GetOneBankAccount(acc.AccountID);
          success = BLL.Accounts.BankAccountManager.UpdateBankBalance(bankAcc, amount, this.textMemo.Text,
            "Remittance from: " + this.textSenderName.Text, out errorText,out newBalance );
            //bankAcc, (float)amount, "1234", out errorText);
        }
        if (acc.AccountSubTypeCode == (int)BLL.Accounts.AccountSubTypeCode.StoredValueAccount)
        {
          BLL.Accounts.StoredValueAccount svAcc = BLL.Accounts.StoredValueAccountManager.GetOneStoredValueAccount(acc.AccountID);
          BLL.Customers.MetaPartnerPhone phone = BLL.Customers.MetaPartnerPhoneManager.GetOneMetaPartnerPhone(svAcc.MetaPartnerPhoneID);
          success = BLL.Customers.MetaPartnerPhoneManager.updateBalances(phone.MetaPartnerPhoneID, (float)amount, 0, 0, out errorText,1);
        }
      }
      catch
      {
        lblFeedback.Text = "Unable to load the selected acount";
        return;
      }
      if (success)
      {
        panelCustomer.Visible = false;
        lblFeedback.Text = "Remittance sent.";
        try
        {
          string message;
          BLL.Customers.MetaPartnerPhone phone = (BLL.Customers.MetaPartnerPhone)this.Session["phone"];
          message = "You have received a Remittance transfer of " + amount.ToString("0.00") +
          acc.AccountName + " USD. From " + this.textSenderName.Text.Trim() + " In your account " + acc.AccountName;
          if (this.textMemo.Text.Trim() != string.Empty)
            message += " MEMO: " + this.textMemo.Text.Trim();
          if (notificactions.sendNotification("25", phone.PhoneNumber, message))
            this.lblFeedback.Text += "  Notification sent to phone.";
          else
            this.lblFeedback.Text += "  Notification NOT sent to phone.";
        }
        catch
        {
          this.lblFeedback.Text += "  Unable to send notification to phone.";
        }
      }
      else
      {
        lblFeedback.Text = "Remittance not sent." + errorText;
      }

    }
  }
}