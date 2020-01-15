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
public partial class AccountList : System.Web.UI.MobileControls.MobileUserControl
{
  #region declares
  private int _accountsCount, _bankAccountCount, _storedValueAccountsCount;
  #endregion
  #region misc
  public AccountList()
  { 
    _accountsCount=0;
    _bankAccountCount=0;
    _storedValueAccountsCount = 0;
  }
  protected void Page_Load(object sender, EventArgs e)
  {

  }
  #endregion
  #region methods
  public void populate(BLL.Customers.MetaPartner Customer,
    BLL.Accounts.AccountSubTypeCode Type1, BLL.Accounts.AccountSubTypeCode Type2,
    BLL.Accounts.AccountSubTypeCode Type3, String labelText)
  {
    try
    {
      this.SelectionList1.Items.Clear();
      _accountsCount = 0;
      _bankAccountCount = 0;
      _storedValueAccountsCount = 0;
      BLL.SortableList<BLL.Accounts.Account> allAccounts;
      allAccounts = BLL.Accounts.AccountManager.GetAllAccountDataByMetaPartnerID(Customer.MetaPartnerID);
      if (allAccounts.Count > 0)
      {
        foreach (BLL.Accounts.Account acc in allAccounts)
        {
          if ((acc.AccountSubTypeCode == (int)Type1
            || acc.AccountSubTypeCode == (int)Type2
            || acc.AccountSubTypeCode == (int)Type3) && acc.IsActive)
          {
            System.Web.UI.MobileControls.MobileListItem li = new MobileListItem();
            li.Value = acc.AccountID.ToString();
            {
              li.Text = acc.AccountName + " (" + acc.AccountSubTypeName + ")";
            }
            if (acc.Description != string.Empty)
            {
              li.Text += "'" + acc.Description + "'";
            }
            this.SelectionList1.Items.Add(li);
            this._accountsCount++;
            if (acc.AccountSubTypeCode == (int)BLL.Accounts.AccountSubTypeCode.BankAccount)
              this._bankAccountCount++;
            if (acc.AccountSubTypeCode == (int)BLL.Accounts.AccountSubTypeCode.StoredValueAccount)
              this._storedValueAccountsCount++;
          }
        }
      }
      if (this.SelectionList1.SelectedIndex == -1 & this.SelectionList1.Items.Count > 0)
      {
        this.SelectionList1.SelectedIndex = 0;
      }
      this.Label1.Text = labelText;
      this.SelectionList1.Visible = true;
    }
    catch (Exception ex)
    {
      this.SelectionList1.Visible = false;
      this.Label1.Text = ex.Message.Replace("\r\n", "");
      this.Label1.StyleReference = "error";
    }
  }
  public  BLL.Accounts.Account selectedAccount()
  {
    BLL.Accounts.Account account;
    if (this.SelectionList1.Selection == null)
      return null;
    else
    {
      try
      {
        account = BLL.Accounts.AccountManager.GetOneAccount(new Guid(this.SelectionList1.Selection.Value));
        return account;
      }
      catch { return null; }
    }
  }
  public BLL.Accounts.StoredValueAccount selectedStoredValueAccount()
  {
    BLL.Accounts.Account account;
    BLL.Accounts.StoredValueAccount SVaccount;
    if (this.SelectionList1.Selection == null)
      return null;
    else
    {
      try
      {
        account = BLL.Accounts.AccountManager.GetOneAccount(new Guid(this.SelectionList1.Selection.Value));
        if (account.AccountSubTypeCode==(int)BLL.Accounts.AccountSubTypeCode.StoredValueAccount)
        {
          SVaccount = BLL.Accounts.StoredValueAccountManager.GetOneStoredValueAccount(account.AccountID);
          return SVaccount;
        }
        else
          return null;
      }
      catch { return null; }
    }
  }
  public BLL.Accounts.BankAccount selectedBankAccount()
  {
    BLL.Accounts.Account account;
    BLL.Accounts.BankAccount SVaccount;
    if (this.SelectionList1.Selection == null)
      return null;
    else
    {
      try
      {
        account = BLL.Accounts.AccountManager.GetOneAccount(new Guid(this.SelectionList1.Selection.Value));
        if (account.AccountSubTypeCode == (int)BLL.Accounts.AccountSubTypeCode.BankAccount)
        {
          SVaccount = BLL.Accounts.BankAccountManager.GetOneBankAccount(account.AccountID);
          return SVaccount;
        }
        else
          return null;
      }
      catch { return null; }
    }
  }
  #endregion
  #region atributes
  public int AccountsCount
  {
    get
    {
      return _accountsCount;
    }
  }
  public int BankAccountsCount
  {
    get
    {
      return _bankAccountCount;    }
  }
  public int StoredValueAccountsCount
  {
    get
    {
      return _storedValueAccountsCount;
    }
  }
  #endregion
}
