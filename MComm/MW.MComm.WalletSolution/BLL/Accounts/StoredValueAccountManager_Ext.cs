
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
using carrierCM = MW.MComm.WalletSolution.MComm.CarrierSim.CustomerManager;
using carrierPM = MW.MComm.WalletSolution.MComm.CarrierSim.PhoneManager;
using MW.MComm.WalletSolution.BLL.UserExperience;
namespace MW.MComm.WalletSolution.BLL.Accounts
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage StoredValueAccount related information.</summary>
	///
	/// File History:
	/// <created>10/27/2006 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class StoredValueAccountManager
	{
		#region Methods
    public static string displayBalanceForStoredValueAccountVIVACarrier(string PhoneNumber,int localeCode)
    {
      string balance = string.Empty;
      MW.MComm.WalletSolution.MComm.Nuevatel.CustomerManager.Service1 s_NTWS = new MW.MComm.WalletSolution.MComm.Nuevatel.CustomerManager.Service1();
      MW.MComm.WalletSolution.MComm.Nuevatel.CustomerManager.balance1Response response1 = s_NTWS.wsbalanceEnquiry1(PhoneNumber, "");
      if (response1.errorCode == -1002)
      {
        balance += "(" + BLL.UserExperience.SiteLabelManager.GetOneSiteLabel(
          (int)BLL.UserExperience.SiteLabelDefinitionCode.PostPaidNote, localeCode).DisplayText + ")";
      }
      else
      {
        balance += response1.balance.ToString("0.00");
      }
      return balance;
    }
    public static string displayBalanceForPrePaidAccountMWCarrier(string PhoneNumber,int localeCode)
    {
      string balance = string.Empty;
      carrierPM.PhoneManager carrierPhoneManager1 = new carrierPM.PhoneManager();
      carrierPM.PhoneResults carrierPhoneResults; carrierPM.Phone carrierPhone1;
      try
      {
        carrierPhoneResults = carrierPhoneManager1.GetOnePhoneByPhoneNumber(PhoneNumber, string.Empty, string.Empty);
        if (carrierPhoneResults.Results.Length > 0)
        {
          carrierPhone1 = carrierPhoneResults.Results[0];
          balance = carrierPhone1.Balance.ToString("0.00");
        }
        else
        {
            //[20070622 SBA] Reemplazo 
            //balance = "Unable to retrieve stored value balance from partner.";
            balance = UserExperience.SiteLabelManager.GetOneSiteLabel((int)SiteLabelDefinitionCode.UnableToRetrieveStoredValueBalanceFromPartner, localeCode).DisplayText;
        }
        return balance;
      }
      catch
      {
          //[20070622 SBA] Reemplazo 
          //balance = "Unable to retrieve stored value balance from partner.";
          balance = UserExperience.SiteLabelManager.GetOneSiteLabel((int)SiteLabelDefinitionCode.UnableToRetrieveStoredValueBalanceFromPartner, localeCode).DisplayText;
      }
      return balance;
    }
    public static string displayBalanceForStoredValueAccountMWCarrier(string PhoneNumber,int localeCode)
    {
      string balance = string.Empty;
      carrierPM.PhoneManager carrierPhoneManager1 = new carrierPM.PhoneManager();
      carrierPM.PhoneResults carrierPhoneResults; carrierPM.Phone carrierPhone1;
      carrierCM.CustomerManager carrierCustomerManager1 = new carrierCM.CustomerManager();
      carrierCM.CustomerResults carrierCustomerResults; carrierCM.Customer carrierCustomer1;
      try
      {
        carrierPhoneResults = carrierPhoneManager1.GetOnePhoneByPhoneNumber(PhoneNumber, string.Empty, string.Empty);
        if (carrierPhoneResults.Results.Length > 0)
        {
          carrierPhone1 = carrierPhoneResults.Results[0];
          carrierCustomerResults = carrierCustomerManager1.GetOneCustomer(carrierPhone1.CustomerID.ToString(), string.Empty, string.Empty);
          if (carrierCustomerResults.Results.Length > 0)
          {
            carrierCustomer1 = carrierCustomerResults.Results[0];
            balance = balance + (carrierCustomer1.StoredValueBalance + carrierCustomer1.StoredValueLockedBalance).ToString("0.00")
              + " (" + carrierCustomer1.StoredValueLockedBalance.ToString("0.00") + " not cashable)";
          }
        }
        else
        {
            //[20070622 SBA] Reemplazo 
            //balance = "Unable to retrieve stored value balance from partner.";
            balance = UserExperience.SiteLabelManager.GetOneSiteLabel((int)SiteLabelDefinitionCode.UnableToRetrieveStoredValueBalanceFromPartner, localeCode).DisplayText;
        }
        return balance;
      }
      catch
      {
          //[20070622 SBA] Reemplazo 
          //balance = "Unable to retrieve stored value balance from partner.";
          balance = UserExperience.SiteLabelManager.GetOneSiteLabel((int)SiteLabelDefinitionCode.UnableToRetrieveStoredValueBalanceFromPartner, localeCode).DisplayText;
      }
      return balance;
    }
    public static BLL.Accounts.StoredValueAccount createOrLoadSVAccounts(BLL.Customers.MetaPartnerPhone phone, int localeCode)
    {
      BLL.Customers.MetaPartner customer1;
      BLL.Accounts.StoredValueAccount SVAccount;
      SortableList<BLL.Accounts.StoredValueAccount> allSVAccounts;
      customer1 = Customers.MetaPartnerManager.GetOneMetaPartner(phone.MetaPartnerID);
      if (customer1 == null) return null; 
      allSVAccounts = BLL.Accounts.StoredValueAccountManager.GetAllStoredValueAccountDataByMetaPartnerID(customer1.MetaPartnerID);
      if (allSVAccounts.Count == 0)
      {
        SVAccount = new MW.MComm.WalletSolution.BLL.Accounts.StoredValueAccount();
        
        // [20070622 SBA] Consulta: El reeemplazo realizado es el adecuado?
        //SVAccount.AccountName = customer1.MetaPartnerName + " stored value default account";
        SVAccount.AccountName = customer1.MetaPartnerName + UserExperience.SiteLabelManager.GetOneSiteLabel((int)SiteLabelDefinitionCode.StoredValueDefaultAccount, localeCode).DisplayText;

        SVAccount.AccountSubTypeCode = (int)Accounts.AccountSubTypeCode.StoredValueAccount;
        SVAccount.Balance = 0;
        SVAccount.BankCustomerCode = "";
        SVAccount.CarrierBalance = 0;
        SVAccount.CurrencyCode = (int)Accounts.CurrencyCode.USDollars;
        //SVAccount.DateFormatCode = BLL.Environments.DateFormatCode.MonthDayYear;
        SVAccount.DebitAccountNumber = phone.PhoneNumber;

        // [20070622 SBA] Consulta: El reeemplazo realizado es el adecuado?
        //SVAccount.Description = customer1.MetaPartnerName + " stored value account at MW Carrier";
        SVAccount.Description = customer1.MetaPartnerName + " " + UserExperience.SiteLabelManager.GetOneSiteLabel((int)SiteLabelDefinitionCode.StoredValueAccountAtMWCarrier, localeCode).DisplayText;

        SVAccount.IsActive = true;
        SVAccount.MetaPartnerPhoneID=  phone.MetaPartnerPhoneID;
        SVAccount.MetaPartnerID = customer1.MetaPartnerID;
        
        AddOneStoredValueAccount(SVAccount, true);
        return SVAccount;
      }
      else
        return allSVAccounts[0];
    }
    public static bool transferStoredValue(StoredValueAccount Sending, StoredValueAccount Receiving, decimal Amount,
      out string ErrorText,int localeCode)
    {
      ErrorText = string.Empty;
      if (Amount <= 0)
      {
          // [20070622 SBA] Reemplazo 
          //ErrorText = "Transfer amount must be a positive number";
          ErrorText = UserExperience.SiteLabelManager.GetOneSiteLabel((int)SiteLabelDefinitionCode.TransferAmountMustBeAPositiveNumber, localeCode).DisplayText;
        return false;
      }
      carrierPM.PhoneManager carrierPhoneManager=new MW.MComm.WalletSolution.MComm.CarrierSim.PhoneManager.PhoneManager();
      carrierPM.PhoneResults carrierPhoneResults;
      carrierPM.Phone carrierPhoneSending;
      carrierPM.Phone carrierPhoneReciving;
      carrierCM.CustomerManager carrierCustomerManager = new MW.MComm.WalletSolution.MComm.CarrierSim.CustomerManager.CustomerManager();
      carrierCM.CustomerResults carrierCustomerResult;
      carrierCM.Customer carrierCustomerSending, carrierCustomerReceiving;
      try
      {
        //get the references
        //phone of sender
        carrierPhoneResults = carrierPhoneManager.GetOnePhoneByPhoneNumber(Sending.PhoneNumber, string.Empty, string.Empty);
        if (carrierPhoneResults.StatusCode != 0)
        {
          ErrorText = carrierPhoneResults.StatusDescription;
          return false;
        }
        carrierPhoneSending = carrierPhoneResults.Results[0];
        //phone of receiver
        carrierPhoneResults = carrierPhoneManager.GetOnePhoneByPhoneNumber(Receiving.PhoneNumber, string.Empty, string.Empty);
        if (carrierPhoneResults.StatusCode != 0)
        {
          ErrorText = carrierPhoneResults.StatusDescription;
          return false;
        }
        carrierPhoneReciving = carrierPhoneResults.Results[0];
        //customer sendgin
        carrierCustomerResult = carrierCustomerManager.GetOneCustomer(carrierPhoneSending.CustomerID.ToString(), string.Empty, string.Empty);
        if (carrierCustomerResult.StatusCode != 0)
        {
          ErrorText = carrierCustomerResult.StatusDescription;
          return false;
        }
        carrierCustomerSending = carrierCustomerResult.Results[0];
        //customer receiving
        carrierCustomerResult = carrierCustomerManager.GetOneCustomer(carrierPhoneReciving.CustomerID.ToString(), string.Empty, string.Empty);
        if (carrierCustomerResult.StatusCode != 0)
        {
          ErrorText = carrierCustomerResult.StatusDescription;
          return false;
        }
        carrierCustomerReceiving = carrierCustomerResult.Results[0];
        //check balance
        if ((decimal)carrierCustomerSending.StoredValueBalance < Amount)
        {
            // [20070622 SBA] Reemplazo 
            //ErrorText = "Insufficient balance in stored value account";
            ErrorText = UserExperience.SiteLabelManager.GetOneSiteLabel((int)SiteLabelDefinitionCode.InsufficientBalanceInStoredValueAccount, localeCode).DisplayText;
            return false;
        }
        //update
        carrierCustomerSending.StoredValueBalance -= (float)Amount;
        carrierCustomerReceiving.StoredValueBalance += (float)Amount;
        carrierCustomerResult = carrierCustomerManager.UpsertOneCustomer(carrierCustomerSending, true);
        if (carrierCustomerResult.StatusCode == 0)
        {
          carrierCustomerResult = carrierCustomerManager.UpsertOneCustomer(carrierCustomerReceiving, true);
          return true;
        }
        else
        {
          ErrorText = carrierCustomerResult.StatusDescription;
          return false;
        }
      }
      catch(Exception ex)
      {
        ErrorText = ex.Message;
        return false;
      }
      //return true;
    }
		#endregion Methods
	}
}