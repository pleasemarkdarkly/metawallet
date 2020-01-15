
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
namespace MW.MComm.WalletSolution.BLL.Customers
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage Customer related information.</summary>
	///
	/// File History:
	/// <created>10/27/2006 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class CustomerManager
	{
		#region Methods
		// ------------------------------------------------------------------
		/// <summary>This method activates a customer.  If the customer is a valid customer for the
		/// carrier, the customer detail is created and linked with the supplied phone number, and a
		/// stored value account is created.
		/// </summary>
		///
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static Customer ActivateCustomerForStoredValue(string phoneNumber, string customerPIN)
		{
			// perform main method tasks
			return ActivateCustomerForStoredValue(phoneNumber, customerPIN, (int)BLL.Environments.LocaleCode.SpanishBolivia, (int)BLL.Accounts.CurrencyCode.Bolivianos, (int)BLL.Customers.CarrierCode.Nuevatel);
		}
		// ------------------------------------------------------------------
		/// <summary>This method activates a customer.  If the customer is a valid customer for the
		/// carrier, the customer detail is created and linked with the supplied phone number, and a
		/// stored value account is created.
		/// </summary>
		///
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static Customer ActivateCustomerForStoredValue(string phoneNumber, string customerPIN, int localeCode, int currencyCode, int carrierCode)
		{
			try
			{
				// perform main method tasks
				Customer customer = null;
				BLL.Customers.MetaPartnerPhone customerPhone = BLL.Customers.MetaPartnerPhoneManager.GetOneMetaPartnerPhoneByPhoneNumber(phoneNumber);
				BLL.Accounts.StoredValueAccount customerAccount = null;
				if (customerPhone != null)
				{
					// customer is already known, update stored value account and activation status
					customerPhone.PIN = customerPIN;
					customerPhone.Save();
					if (customerPhone.MetaPartner.IsActive == false)
					{
						// activate customer record
						customerPhone.MetaPartner.IsActive = true;
						customerPhone.MetaPartner.Save();
					}
					if (customerPhone.MetaPartner.StoredValueAccountList.Count > 0)
					{
						foreach (BLL.Accounts.StoredValueAccount loopAccount in customerPhone.MetaPartner.StoredValueAccountList)
						{
							if (loopAccount.IsActive == false)
							{
								// activate stored value account
								loopAccount.IsActive = true;
								loopAccount.Save();
							}
						}
					}
					else
					{
						// create stored value account TODO: call Nuevatel service
						customerAccount = new BLL.Accounts.StoredValueAccount();
						customerAccount.CurrencyCode = currencyCode;
						customerAccount.DebitAccountNumber = "xoxoxoxox"; // get from Nuevatel service
						customerAccount.AccountName = "Joe Doe's account"; // get from Nuevatel service
						customerAccount.AccountSubTypeCode = (int)BLL.Accounts.AccountSubTypeCode.StoredValueAccount;
						customerAccount.IsActive = true;
						customerAccount.IsDefaultDebitAccount = true;
						customerAccount.Save();
					}
					return CustomerManager.GetOneCustomer(customerPhone.MetaPartnerID);
				}
				else
				{
					// get customer info from carrier TODO: call Nuevatel service and throw customer not found exception if not found
					customer = new Customer();
					customer.LocaleCode = localeCode;
					customer.CurrencyCode = currencyCode;
					customer.DateFormatCode = (int)BLL.Environments.DateFormatCode.DayMonthYear;
					customer.IsActive = true;
					customer.MetaPartnerSubTypeCode = (int)BLL.Customers.MetaPartnerSubTypeCode.Customer;
					customer.FirstName = "Joe"; // from Nuevatel service
					customer.LastName = "Doe"; // from Nuevatel service
					customer.MetaPartnerName = customer.FirstName + " " + customer.LastName;
					// create stored value account TODO: call Nuevatel service
					customer.StoredValueAccountList = new SortableList<MW.MComm.WalletSolution.BLL.Accounts.StoredValueAccount>();
					customerAccount = new BLL.Accounts.StoredValueAccount();
					customerAccount.CurrencyCode = currencyCode;
					customerAccount.DebitAccountNumber = "xoxoxoxox"; // get from Nuevatel service
					customerAccount.AccountName = "Joe Doe's account"; // get from Nuevatel service
					customerAccount.AccountSubTypeCode = (int)BLL.Accounts.AccountSubTypeCode.StoredValueAccount;
					customerAccount.IsActive = true;
					customerAccount.IsDefaultDebitAccount = true;
					// create phone
					customer.PhoneList = new SortableList<MetaPartnerPhone>();
					customerPhone.PhoneNumber = phoneNumber;
					customerPhone.PIN = customerPIN;
					customerPhone.IsActive = true;
					BLL.Customers.Carrier carrier = BLL.Customers.CarrierManager.GetOneCarrierByCarrierCode(carrierCode);
					if (carrier != null)
					{
						// save new customer, phone, and stored value account information
						customerPhone.CarrierMetaPartnerID = carrier.MetaPartnerID;
						customer.PhoneList.Add(customerPhone);
						customer.Save(true);
					}
					else
					{
						// throw carrier not found exception
					}
					return customer;
				}
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.ActivateCustomer");
			}
		}
    //--------------------------------------------------------------------
    public static string createCustomer(string PhoneNumber, string PIN)
    {
      PhoneNumber = PhoneNumber.Replace("+", "");
      string result = string.Empty;
      BLL.Customers.MetaPartnerPhone phone1;
      BLL.Customers.Customer customer1;
      //confirm that the user does not alredy exist
      phone1 = MetaPartnerPhoneManager.GetOneMetaPartnerPhoneByPhoneNumber(PhoneNumber);
      if (phone1 != null)
      {
        result = "This phone number is already registered. Please login instead of creating a new account.";
        return result;
      }
      //obtain customer data from the carrier or carrier simulator
      MComm.CarrierSim.CustomerManager.Customer carrierCustomer1;
      MComm.CarrierSim.PhoneManager.Phone carrierPhone1;
      try
      {
        MComm.CarrierSim.CustomerManager.CustomerManager carrierCustomerManager1 = new MComm.CarrierSim.CustomerManager.CustomerManager();
        MComm.CarrierSim.PhoneManager.PhoneManager carrierPhoneManager1 = new MComm.CarrierSim.PhoneManager.PhoneManager();
        MComm.CarrierSim.CustomerManager.CustomerResults carrierCustomerResult;
        MComm.CarrierSim.PhoneManager.PhoneResults carrierPhoneResult;
        carrierPhoneResult = carrierPhoneManager1.GetOnePhoneByPhoneNumber(PhoneNumber, string.Empty, string.Empty);
        if (carrierPhoneResult == null || carrierPhoneResult.StatusCode != 0) throw new Exception("Phone not found.");
        carrierPhone1 = carrierPhoneResult.Results[0];
        carrierCustomerResult = carrierCustomerManager1.GetOneCustomer(carrierPhone1.CustomerID.ToString(), string.Empty, string.Empty);
        if (carrierCustomerResult == null || carrierCustomerResult.StatusCode != 0) throw new Exception("Customer not found");
        carrierCustomer1 = carrierCustomerResult.Results[0];
      }
      catch //(Exception ex)
      {
        result = "Unable to retrieve customer data from carrier. Did you enter a valid number?";// +ex.Message.Replace("\r", " ").Replace("\n", " ");
        return result;
      }
      //all data requiered is available, create the metapartner 
      try
      {
        customer1 = new Customer();
        customer1.MetaPartnerName = carrierCustomer1.Name;
        try
        {
          customer1.FirstName = carrierCustomer1.Name.Split(" ".ToCharArray())[0];
          customer1.LastName = carrierCustomer1.Name.Split(" ".ToCharArray())[1];
        }
        catch { }
        customer1.IsActive = true;
        customer1.CurrencyCode = 1;
        customer1.DateFormatCode = 1;
        customer1.LocaleCode = 1;
        customer1.MetaPartnerSubTypeCode = 1;
        //customer1
        CustomerManager.AddOneCustomer(customer1, true);
        phone1 = new MetaPartnerPhone();
        phone1.MetaPartnerID = customer1.MetaPartnerID;
        phone1.CarrierMetaPartnerID = new Guid("6f21cc31-7f60-46b1-808a-a3300614ad11");
        phone1.IsActive = true;
        phone1.PhoneNumber = PhoneNumber;
        phone1.PIN = PIN;
        phone1.Rank = 1;
        MetaPartnerPhoneManager.UpsertOneMetaPartnerPhone(phone1, true);
      }
      catch (Exception ex)
      {
        return ex.Message;
      }
      return result;
    }
    //--------------------------------------------------------------------
		#endregion Methods
	}
}