
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
using Bsim = MW.MComm.WalletSolution.MComm.Ganadero.Simulator;
using MultiBank = MW.MComm.WalletSolution.MComm.MultiBank.Simulator;
namespace MW.MComm.WalletSolution.BLL.Accounts
{
  // ------------------------------------------------------------------------------
  /// <summary>This class is used to manage Account related information.</summary>
  ///
  /// File History:
  /// <created>10/27/2006 (Dave Clemmer)</created>
  ///
  /// <remarks></remarks>
  // ------------------------------------------------------------------------------
  public partial class AccountManager
  {
    #region Methods
    public static bool AccountToAccountTransfer(
      Account OriginAccount, Account DestinationAccount,decimal Amount, 
      string Memo,string Description,int localeCode, out string errorMessage)
    {
      try
      {
        errorMessage = string.Empty;
        //if both accounts are of the same type, there's a chance the service provider will implement
        //two phase commit and auditing. Use the provider's method
        if (OriginAccount.AccountSubTypeCode == (int)BLL.Accounts.AccountSubTypeCode.BankAccount
         && DestinationAccount.AccountSubTypeCode == (int)BLL.Accounts.AccountSubTypeCode.BankAccount)
        {
          decimal newBalanceSender;
          decimal newBalanceReceiver;
          Boolean success;
          BankAccount BOriginAccount; BankAccount BDestinationAc;
          BOriginAccount = BankAccountManager.GetOneBankAccount(OriginAccount.AccountID);
          BDestinationAc = BankAccountManager.GetOneBankAccount(DestinationAccount.AccountID);
          success=BLL.Accounts.BankAccountManager.bankTransferSingleCurrency(
            BOriginAccount, BDestinationAc, Amount, BOriginAccount.Currency, Memo, 
            out errorMessage, out newBalanceSender,out newBalanceReceiver);
          if (success)
          {
            errorMessage = newBalanceSender.ToString("0.00");
            return true;
          }
          else
          {
            return false;
          }
        }
        else if (OriginAccount.AccountSubTypeCode == (int)BLL.Accounts.AccountSubTypeCode.StoredValueAccount
         && DestinationAccount.AccountSubTypeCode == (int)BLL.Accounts.AccountSubTypeCode.StoredValueAccount)
        {
          StoredValueAccount SVorigin, SVdestin;
          SVorigin = StoredValueAccountManager.GetOneStoredValueAccount(OriginAccount.AccountID);
          SVdestin = StoredValueAccountManager.GetOneStoredValueAccount(DestinationAccount.AccountID);
          if (StoredValueAccountManager.transferStoredValue(SVorigin, SVdestin, Amount, out errorMessage, localeCode))
          {
            return true;
          }
          else
          {
            return false;
          }
        }
        //if the accounts are of different types, use built in methods.
        else
        {
          bool successSender, successReceiver;
          decimal newSenderBalance,newReceiverBalance;
          successSender = AccountManager.updateOneAccount(
            OriginAccount,Amount*(-1),Description,Memo,out errorMessage,out newSenderBalance);
          successReceiver = AccountManager.updateOneAccount(
            DestinationAccount, Amount, Description, Memo, out errorMessage, out newReceiverBalance);
          return (successSender & successReceiver);
        }
      }
      catch (Exception ex)
      {
        errorMessage = ex.Message;
        return false;
      }
    }
    public static bool updateOneAccount(Account Acc, decimal Amount, string Description, string Memo, out string errorMessage, out decimal newBalance)
    {
      newBalance = 0;
      errorMessage = string.Empty;
      if (Acc.AccountSubTypeCode == (int)BLL.Accounts.AccountSubTypeCode.StoredValueAccount)
      {
        try
        {
          StoredValueAccount SVAcc = StoredValueAccountManager.GetOneStoredValueAccount(Acc.AccountID);
          SVAcc.Balance += Amount;
          StoredValueAccountManager.UpdateOneStoredValueAccount(SVAcc,true);
          newBalance = (decimal)SVAcc.Balance;
        }
        catch (Exception ex)
        {
          errorMessage = ex.Message;
          return false;
        }
        return true;
      }
      else if (Acc.AccountSubTypeCode == (int)BLL.Accounts.AccountSubTypeCode.BankAccount)
      {
        try
        {
          BankAccount BAcc = BankAccountManager.GetOneBankAccount(Acc.AccountID);
          BankAccountManager.UpdateBankBalance(BAcc, Amount, Memo, Description, out errorMessage,out newBalance);
        }
        catch (Exception ex)
        {
          errorMessage = ex.Message;
          return false;
        }
        return true;
      }
      return false;
    }
    #endregion Methods
  }
}