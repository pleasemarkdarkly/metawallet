
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
using MW.MComm.WalletSolution.BLL.Customers;
using MOD.Data;
using MW.MComm.WalletSolution.BLL.Config;
using BLL = MW.MComm.WalletSolution.BLL;
using DAL = MW.MComm.WalletSolution.DAL;
using Utility = MW.MComm.WalletSolution.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using carrier=MW.MComm.WalletSolution.MComm.CarrierSim;
using MW.MComm.WalletSolution.BLL.UserExperience;

namespace MW.MComm.WalletSolution.BLL.Customers
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage MetaPartnerPhone related information.</summary>
	///
	/// File History:
	/// <created>10/27/2006 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class MetaPartnerPhoneManager
	{
		#region Methods
    public static bool updateBalances(Guid PhoneID,float StoredValueAmount,
      float StoredValueLockedAmount,float PrePaidAmount,out string errorText,int localeCode)
    {
      MetaPartnerPhone phone;
      phone=GetOneMetaPartnerPhone(PhoneID);
      if (phone==null)
      {
        //[20070622 SBA] Reemplazo 
        //errorText="Phone not found";
          errorText = UserExperience.SiteLabelManager.GetOneSiteLabel((int)SiteLabelDefinitionCode.PhoneNotFound, localeCode).DisplayText;
        return false;
      }
      carrier.PhoneManager.Phone carrierPhone;
      carrier.PhoneManager.PhoneManager carrierPhoneManager=new MW.MComm.WalletSolution.MComm.CarrierSim.PhoneManager.PhoneManager();
      carrier.PhoneManager.PhoneResults carrierPhoneResult;
      carrier.CustomerManager.Customer carrierCustomer;
      carrier.CustomerManager.CustomerResults carrierCustomerResult;
      carrier.CustomerManager.CustomerManager carrierCustomerManager = new MW.MComm.WalletSolution.MComm.CarrierSim.CustomerManager.CustomerManager();
      try
      {
        //get the references to remote objects
        carrierPhoneResult = carrierPhoneManager.GetOnePhoneByPhoneNumber(phone.PhoneNumber, string.Empty, string.Empty);
        if (carrierPhoneResult.StatusCode != 0)
        {
          errorText = carrierPhoneResult.StatusDescription;
          return false;
        }
        carrierPhone = carrierPhoneResult.Results[0];
        carrierCustomerResult = carrierCustomerManager.GetOneCustomer(carrierPhone.CustomerID.ToString(), string.Empty, string.Empty);
        if (carrierCustomerResult.StatusCode != 0)
        {
          errorText = carrierCustomerResult.StatusDescription;
          return false;
        }
        carrierCustomer = carrierCustomerResult.Results[0];
        //validate balances, they can not result negative, unless for some reason they
        //were negative already and they are being added a positive amount
        if (
              (PrePaidAmount<0 && ((carrierPhone.Balance + PrePaidAmount) < 0)) ||
              (StoredValueAmount<0 && ((carrierCustomer.StoredValueBalance) + StoredValueAmount < 0)) ||
              (StoredValueLockedAmount<0 && ((carrierCustomer.StoredValueLockedBalance + StoredValueLockedAmount) < 0))
            )
        {
          //[20070622 SBA] Reemplazo 
          //errorText = "Not enough balance";
            errorText = UserExperience.SiteLabelManager.GetOneSiteLabel((int)SiteLabelDefinitionCode.NotEnoughBalance, localeCode).DisplayText;
          return false;
        }
        //update the objects
        carrierCustomer.StoredValueBalance += StoredValueAmount;
        carrierPhone.Balance += PrePaidAmount;
        carrierCustomer.StoredValueLockedBalance += StoredValueLockedAmount;
        carrierPhoneResult= carrierPhoneManager.UpsertOnePhone(carrierPhone, true);
        carrierCustomerResult = carrierCustomerManager.UpsertOneCustomer(carrierCustomer, false);
        if (carrierPhoneResult.StatusCode == 0 && carrierCustomerResult.StatusCode==0)
        {
          errorText = string.Empty;
          return true;
        }
        else
        {
          errorText = carrierPhoneResult.StatusDescription + carrierCustomerResult.StatusDescription;
          return false;
        }
      }
      catch (Exception ex)
      {
        errorText = ex.Message;
        return false;
      }
    }
    public static bool buyPrePaidMinutesFromAccount(MetaPartnerPhone receiving,
      BLL.Accounts.Account sendingAccount,MetaPartnerPhone sendingPhone, decimal amount,
      string customerBankPin,string description, out string errorText,int localeCode)
    {
      errorText = string.Empty;
      //validate balance
      if (sendingAccount.AccountSubTypeCode == (int)BLL.Accounts.AccountSubTypeCode.StoredValueAccount)
      {
        if (updateBalances(sendingPhone.MetaPartnerPhoneID, (float)(amount*-1), 0, 0, out errorText,localeCode)
          && updateBalances(receiving.MetaPartnerPhoneID, 0, 0, (float)amount, out errorText,localeCode))
          return true;
        else
          return false;
      }
      if (sendingAccount.AccountSubTypeCode == (int)BLL.Accounts.AccountSubTypeCode.BankAccount)
      { 
        decimal newBalance;
        BLL.Accounts.BankAccount sendingBank=BLL.Accounts.BankAccountManager.GetOneBankAccount(sendingAccount.AccountID);
        if (Accounts.BankAccountManager.UpdateBankBalance(sendingBank,amount,"",
          description,out errorText,out newBalance))
          //(sendingBank, (float)(amount*-1), customerBankPin, out errorText)
          //&& updateBalances(receiving.MetaPartnerPhoneID, 0, 0, amount, out errorText,localeCode))
          return true;
        else
          return false;
      }
      return false;
    }
		#endregion Methods
	}
}
