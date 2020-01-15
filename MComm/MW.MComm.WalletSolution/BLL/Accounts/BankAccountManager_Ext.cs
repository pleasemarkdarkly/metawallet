/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/
using System;
using System.ComponentModel;
using MW.MComm.WalletSolution.BLL.Accounts;
using MOD.Data;
using MW.MComm.WalletSolution.BLL.Config;
using BLL = MW.MComm.WalletSolution.BLL;
using DAL = MW.MComm.WalletSolution.DAL;
using Utility = MW.MComm.WalletSolution.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using BankSim = MW.MComm.WalletSolution.MComm.Ganadero.Simulator;
using MultiBankSim = MW.MComm.WalletSolution.MComm.MultiBank.Simulator;
using MW.MComm.WalletSolution.BLL.UserExperience;
namespace MW.MComm.WalletSolution.BLL.Accounts
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage BankAccount related information.</summary>
	///
	/// File History:
	/// <created>10/27/2006 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class BankAccountManager
  {
    #region ObsoleteMethods
    [Obsolete]//this version of this method was used before the multiple bank simulation was in place
    public static int createBankAccountsFromBank(Guid BankMetaPartnerID, Guid CustomerID,
      string CustomerBankID, string CustomerBankPIN, string description, out string errorMessage)
    {
      int accounts = 0;
      errorMessage = string.Empty;
      //returns the number of accounts imported
      //each bank is treated different
      try
      {
        Guid MWBankID = new Guid("2fa8fd9b-c37c-4369-8a91-2739fbce17b0");
        if (BankMetaPartnerID == MWBankID)
        {
          BankSim.CustomerInformationResult CustomerResult1;
          BankSim.Service BankService = new BankSim.Service();
          CustomerResult1 = BankService.CustomerInformation(
            CustomerBankID, CustomerBankPIN, string.Empty);
          if (CustomerResult1.ErrorCode != 0)
          {
            errorMessage = CustomerResult1.ErrorDescription;
            return accounts;
          }
          else
          {
            BLL.SortableList<BLL.Accounts.BankAccount> AllMWAccounts;
            AllMWAccounts = GetAllBankAccountDataByMetaPartnerID(CustomerID);
            for (int i = 1; i <= CustomerResult1.AccountCount; i++)
            {
              BankSim.AccountInformationResult BKacc;
              try
              {
                BKacc = BankService.AccountInformation(CustomerBankID, CustomerBankPIN, string.Empty, i);
                if (BKacc.ErrorCode == 0)
                {
                  //see if this account was already imported
                  bool accountExists = false;
                  foreach (BLL.Accounts.BankAccount MWexistingAccount in AllMWAccounts)
                  {
                    if (MWexistingAccount.DebitAccountNumber == BKacc.AccountCode) accountExists = true;
                  }
                  if (!accountExists) //it's a new account, import it.
                  {
                    BLL.Accounts.BankAccount MWacc = new BankAccount();
                    MWacc.AccountName = "MW Bank account " + BKacc.AccountCode;
                    MWacc.AccountSubTypeCode = (int)BLL.Accounts.AccountSubTypeCode.BankAccount;
                    MWacc.BankMetaPartnerID = MWBankID;
                    MWacc.BankCustomerCode = CustomerBankID;
                    MWacc.CurrencyCode = (int)BLL.Accounts.CurrencyCode.USDollars;
                    MWacc.Description = description;
                    MWacc.IsActive = true;
                    MWacc.MetaPartnerID = CustomerID;
                    MWacc.DebitAccountNumber = BKacc.AccountCode;
                    BLL.Accounts.BankAccountManager.AddOneBankAccount(MWacc, true);
                    accounts += 1;
                  }
                }
              }
              catch (Exception ex)
              {
                errorMessage = ex.Message;
              }
            }
          }
        }
      }
      catch (Exception ex)
      { errorMessage = ex.Message; }
      return accounts;
    }
    [Obsolete]//this version of this method was used before the multiple bank simulation was in place
    public static string displayBalanceForBankAccount(Guid accountID, string PIN, int localeCode)
    {
      string balance = string.Empty;
      BankSim.Service bankService = new BankSim.Service();
      BankSim.AccountInformationResult bankResult;
      BLL.Accounts.BankAccount BAccount;
      BAccount = BLL.Accounts.BankAccountManager.GetOneBankAccount(accountID);
      bankResult = bankService.AccountInformation2(BAccount.BankCustomerCode, PIN, string.Empty, BAccount.DebitAccountNumber);
      if (bankResult.ErrorCode == 0)
      {
        balance += bankResult.AccountBalance.ToString("0.00");
      }
      else
      {
        //[20070622 SBA] Reemplazo
        //balance = "unable to retrieve balance from bank";
        balance = UserExperience.SiteLabelManager.GetOneSiteLabel((int)SiteLabelDefinitionCode.UnableToRetrieveBalanceFromBank, localeCode).DisplayText;
        //balance = UserExperience.SiteLabelManager.GetOneSiteLabel((int)SiteLabelDefinitionCode.UnableToRetrieveBalanceFromBank);          
      }
      return balance;
    }
    [Obsolete]//this version of this method was used before the multiple bank simulation was in place
    public static bool TransferFunds(BankAccount sending, BankAccount receiving, float amount, string customerBankPIN, out string errorText)
    {
      errorText = string.Empty;
      BankSim.Service BankService = new BankSim.Service();
      BankSim.AccountTransferResult result;
      try
      {
        result = BankService.AccountTransfer(sending.BankCustomerCode, customerBankPIN, "",
          sending.DebitAccountNumber, receiving.DebitAccountNumber, (decimal)amount, "USD");
        if (result.ErrorCode == 0)
          return true;
        else
        {
          errorText = result.ErrorDescription;
          return false;
        }
      }
      catch (Exception ex)
      {
        errorText = ex.Message;
        return false;
      }
    }
    [Obsolete]
    public static bool UpdateBankBalance(BankAccount account, float Amount, string customerBankPIN, out string errorText)
    {
      //When the bank balance is updated, and the other party account does not belong to the bank,
      //a special use MW account receives or sends the funds
      errorText = string.Empty;
      BankAccount MWAccount = BankAccountManager.GetOneBankAccount(new Guid("df3cb9b5-bdeb-41bf-bf9a-666ec3a994f4"));
      string MWAccountPIN = "4525";
      try
      {
        if (Amount > 0)
        {
          return TransferFunds(MWAccount, account, Amount, MWAccountPIN, out errorText);
        }
        else
        {
          return TransferFunds(account, MWAccount, (float)((-1) * Amount), customerBankPIN, out errorText);
        }
      }
      catch (Exception ex)
      {
        errorText = ex.Message;
        return false;
      }
    }

    #endregion
    #region Methods
    public static string displayBalanceForBankAccount(BankAccount CustomerAccount, int localeCode)
    {
      string balance = string.Empty;
      MultiBankSim.multiBank bankService= new MultiBankSim.multiBank();
      MultiBankSim.AccountQueryResult queryResult;
      try
      {
        queryResult = bankService.accountInfo(CustomerAccount.BankMetaPartnerID,
          CustomerAccount.BankCustomerCode, CustomerAccount.DebitAccountNumber);
        if (queryResult.ErroCode==0)
          balance=queryResult.Accountdata.AccountBalance.ToString("0.00");
        else
          balance = UserExperience.SiteLabelManager.GetOneSiteLabel((int)SiteLabelDefinitionCode.UnableToRetrieveBalanceFromBank, localeCode).DisplayText;
      }
      catch 
      {
        balance = UserExperience.SiteLabelManager.GetOneSiteLabel((int)SiteLabelDefinitionCode.UnableToRetrieveBalanceFromBank, localeCode).DisplayText;
      }
      return balance;
    }
    public static int createBankAccountsFromBank(Guid BankMetaPartnerID, Guid CustomerID,
      string CustomerBankID, string description, out string errorMessage)
    {
      MultiBankSim.multiBank BankService=new MultiBankSim.multiBank();
      MultiBankSim.CustomerQueryResult QueryResult;
      errorMessage = string.Empty;
      try
      {
        QueryResult = BankService.customerInfo(BankMetaPartnerID, CustomerBankID);
        if (QueryResult.ErroCode == 0)
        {
          //iterate trough accounts in the bank simulation and accounts in mw databse
          //to see wich ones need to be imported
          BLL.SortableList<BLL.Accounts.BankAccount> AllMWAccounts;
          AllMWAccounts = GetAllBankAccountDataByMetaPartnerID(CustomerID);
          foreach (MultiBankSim.account queryAc in QueryResult.Accounts)
          {
            bool accountExists = false;
            foreach (BankAccount existingAc in AllMWAccounts)
            {
              if (existingAc.BankMetaPartnerID == queryAc.BankId
                && existingAc.BankCustomerCode == queryAc.CustomerCode
                && existingAc.DebitAccountNumber == queryAc.AccountCode)
                accountExists = true;
            }
            if (!accountExists)
            { 
              //an account wich needs to be imported has been found;
              BLL.Accounts.BankAccount MWacc = new BankAccount();
              MWacc.AccountName = queryAc.BankName + " account " + queryAc.AccountCode;
              MWacc.AccountSubTypeCode = (int)BLL.Accounts.AccountSubTypeCode.BankAccount;
              MWacc.BankMetaPartnerID = BankMetaPartnerID;
              MWacc.BankCustomerCode = CustomerBankID;
              if (queryAc.AccountCurrency.ToUpper()=="USD")
                MWacc.CurrencyCode = (int)BLL.Accounts.CurrencyCode.USDollars;
              else if (queryAc.AccountCurrency.ToUpper() == "EURO")
                MWacc.CurrencyCode = (int)BLL.Accounts.CurrencyCode.Euro;
              else if (queryAc.AccountCurrency.ToUpper() == "BS")
                MWacc.CurrencyCode = (int)BLL.Accounts.CurrencyCode.Bolivianos;  
              else
                MWacc.CurrencyCode = (int)BLL.Accounts.CurrencyCode.USDollars;  
              MWacc.Description = description;
              MWacc.IsActive = true;
              MWacc.MetaPartnerID = CustomerID;
              MWacc.DebitAccountNumber = queryAc.AccountCode;
              BLL.Accounts.BankAccountManager.AddOneBankAccount(MWacc, true);
            }
          }
          return QueryResult.Accounts.Length;
        }
        else
          return 0;
      }
      catch (Exception ex)
      {
        errorMessage = ex.Message;
        return 0;
      }
    }
    public static bool bankTransferSingleCurrency(BankAccount sending, BankAccount receiving, decimal amount,BLL.Accounts.Currency currencyUsed,
      string memo, out string errorText, out decimal newSenderBalance, out decimal newReceiverBalance)
    {
      errorText = string.Empty;
      newSenderBalance = 0;
      newReceiverBalance = 0;
      try
      {
        MultiBankSim.multiBank service = new MultiBankSim.multiBank();
        MultiBankSim.TransferResult result;
        result = service.transfer(
          sending.BankMetaPartnerID, sending.BankCustomerCode, sending.DebitAccountNumber,
          receiving.BankMetaPartnerID, receiving.BankCustomerCode, receiving.DebitAccountNumber,
          amount, currencyUsed.CurrencyName, memo);
        if (result.ErrorCode != 0)
        {
          errorText = result.ErrorText;
          return false;
        }
        else
        {
          newSenderBalance = result.NewBalanceSender.AccountBalance;
          newReceiverBalance = result.NewBalanceReceiver.AccountBalance;
        }
      }
      catch (Exception ex)
      {
        errorText = ex.Message;
        return false;
      }
      return true;
    }
    public static bool UpdateBankBalance(BankAccount account, decimal Amount, string Memo,string Description, out string errorText,out decimal newBalance)
    {
      //When the bank balance is updated, and the other party account does not belong to the bank,
      //a special use MW account receives or sends the funds
      errorText = string.Empty;
      newBalance = 0;
      BankAccount MWAccount = BankAccountManager.GetOneBankAccount(new Guid("df3cb9b5-bdeb-41bf-bf9a-666ec3a994f4"));
      try
      {
        MultiBankSim.multiBank BankService = new MultiBankSim.multiBank();
        MultiBankSim.TransferResult result1 =
          BankService.UpdateBalance(account.BankMetaPartnerID, account.BankCustomerCode, account.DebitAccountNumber,
          Amount, Memo, Description);
        if (result1.ErrorCode == 0)
        {
          newBalance = result1.NewBalanceReceiver.AccountBalance;
          errorText = result1.NewBalanceReceiver.AccountBalance.ToString("0.00");
          return true;
        }
        else
        {
          errorText = result1.ErrorText;
          return false;
        }
      }
      catch (Exception ex)
      {
        errorText = ex.Message;
        return false;
      }
    }
    public static MultiBankSim.HistoryQueryResult getAccountHistory(BankAccount account)
    {
      MultiBankSim.HistoryQueryResult result=new MultiBankSim.HistoryQueryResult();
      MultiBankSim.multiBank bankService=new MultiBankSim.multiBank();
      try
      {
        result = bankService.accountHistory(account.BankMetaPartnerID, account.BankCustomerCode, account.DebitAccountNumber);
      }
      catch (Exception ex)
      {
        result.ErroCode = -100;
        result.ErrorText = "Unable to connect to bank. " + ex.Message;
      }
      return result;
    }
		#endregion Methods
	}
}