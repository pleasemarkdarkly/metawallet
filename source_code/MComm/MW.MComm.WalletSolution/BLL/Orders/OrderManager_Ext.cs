
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
using MW.MComm.WalletSolution.BLL.Orders;
using MOD.Data;
using MW.MComm.WalletSolution.BLL.Config;
using BLL = MW.MComm.WalletSolution.BLL;
using DAL = MW.MComm.WalletSolution.DAL;
using Utility = MW.MComm.WalletSolution.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
namespace MW.MComm.WalletSolution.BLL.Orders
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage Order related information.</summary>
	///
	/// File History:
	/// <created>10/27/2006 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class OrderManager
	{
		#region Methods
		// ------------------------------------------------------------------
		/// <summary>This method initiates an order.  The order must be approved by the customer
		/// having funds debited (with a valid PIN) before the order can be paid).
		/// </summary>
		///
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static Order InitiateOrder(string fromPhoneNumber, Guid? fromAccountNumber, string toPhoneNumber, Guid? toAccountNumber, decimal orderAmount, int orderCurrency, string orderDescription)
		{
			try
			{
				// validate sender phone
				BLL.Customers.MetaPartnerPhone fromPhone = BLL.Customers.MetaPartnerPhoneManager.GetOneMetaPartnerPhoneByPhoneNumber(fromPhoneNumber);
				if (fromPhone == null)
				{
					throw new Utility.CustomAppException(BLL.Core.ErrorNumber.SenderPhoneNotFound);
				}
				if (fromPhone.IsActive == false)
				{
					throw new Utility.CustomAppException(BLL.Core.ErrorNumber.SenderPhoneNotActive);
				}
				// validate sender account and balance
				BLL.Accounts.Account fromAccount = null;
				bool lowBalance = false;
				bool notActive = false;
				
				foreach (BLL.Accounts.StoredValueAccount loopAccount in fromPhone.MetaPartner.StoredValueAccountList)
				{
					if (fromAccount == null || ((fromAccountNumber == null && loopAccount.MetaPartnerPhoneID == fromPhone.MetaPartnerPhoneID) || loopAccount.AccountID == fromAccountNumber))
					{
						if (loopAccount.IsActive == true && loopAccount.Balance >= orderAmount)
						{
							fromAccount = loopAccount;
						}
						else
						{
							if (loopAccount.IsActive == false)
							{
								notActive = true;
							}
							if (loopAccount.Balance < orderAmount)
							{
								lowBalance = true;
							}
						}
					}
				}
				foreach (BLL.Accounts.BankAccount loopAccount in fromPhone.MetaPartner.BankAccountList)
				{
					if (fromAccount == null || ((fromAccountNumber == null && loopAccount.IsDefaultDebitAccount == true) || loopAccount.AccountID == fromAccountNumber))
					{
						if (loopAccount.IsActive == true && loopAccount.Balance >= orderAmount)
						{
							fromAccount = loopAccount;
						}
						else
						{
							if (loopAccount.IsActive == false)
							{
								notActive = true;
							}
							if (loopAccount.Balance < orderAmount)
							{
								lowBalance = true;
							}
						}
					}
				}
				if (fromAccount == null)
				{
					if (notActive == true)
					{
						throw new Utility.CustomAppException(BLL.Core.ErrorNumber.SenderAccountNotActive);
					}
					else if (lowBalance == true)
					{
						throw new Utility.CustomAppException(BLL.Core.ErrorNumber.SenderAccountInsufficientBalance);
					}
					else
					{
						throw new Utility.CustomAppException(BLL.Core.ErrorNumber.CarrierCustomerNotFound);
					}
				}
				// validate receiving phone
				BLL.Customers.MetaPartnerPhone toPhone = BLL.Customers.MetaPartnerPhoneManager.GetOneMetaPartnerPhoneByPhoneNumber(toPhoneNumber);
				if (toPhone == null)
				{
					throw new Utility.CustomAppException(BLL.Core.ErrorNumber.ReceiverPhoneNotFound);
				}
				if (toPhone.IsActive == false)
				{
					throw new Utility.CustomAppException(BLL.Core.ErrorNumber.ReceiverPhoneNotActive);
				}
				// validate receiving account
				BLL.Accounts.Account toAccount = null;
				notActive = false;
				foreach (BLL.Accounts.StoredValueAccount loopAccount in toPhone.MetaPartner.StoredValueAccountList)
				{
					if (toAccount == null || ((toAccountNumber == null && loopAccount.MetaPartnerPhoneID == toPhone.MetaPartnerPhoneID) || loopAccount.AccountID == toAccountNumber))
					{
						if (loopAccount.IsActive == true)
						{
							toAccount = loopAccount;
						}
						else
						{
							notActive = true;
						}
					}
				}
				foreach (BLL.Accounts.BankAccount loopAccount in toPhone.MetaPartner.BankAccountList)
				{
					if (toAccount == null || ((toAccountNumber == null && loopAccount.IsDefaultDebitAccount == true) || loopAccount.AccountID == toAccountNumber))
					{
						if (loopAccount.IsActive == true)
						{
							toAccount = loopAccount;
						}
						else
						{
							notActive = true;
						}
					}
				}
				if (toAccount == null)
				{
					if (notActive == true)
					{
						throw new Utility.CustomAppException(BLL.Core.ErrorNumber.ReceiverAccountNotActive);
					}
					else
					{
						throw new Utility.CustomAppException(BLL.Core.ErrorNumber.ReceiverAccountNotFound);
					}
				}
				// initiate order
				return InitiateOrder(fromPhone, fromAccount, toPhone, toAccount, orderAmount, orderCurrency, orderDescription);
			}
			catch (Utility.CustomAppException ex)
			{
				throw ex;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Orders.InitiateOrder");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method initiates an order.  The order must be approved by the customer
		/// having funds debited (with a valid PIN) before the order can be paid).
		/// </summary>
		///
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static Order InitiateOrder(BLL.Customers.MetaPartnerPhone fromPhone, BLL.Accounts.Account fromAccount, BLL.Customers.MetaPartnerPhone toPhone, BLL.Accounts.Account toAccount, decimal orderAmount, int orderCurrency, string orderDescription)
		{
			try
			{
				// validate sender phone
				if (fromPhone == null)
				{
					throw new Utility.CustomAppException(BLL.Core.ErrorNumber.SenderPhoneNotFound);
				}
				if (fromPhone.IsActive == false)
				{
					throw new Utility.CustomAppException(BLL.Core.ErrorNumber.SenderPhoneNotActive);
				}
				// validate sender account and balance
				if (fromAccount == null)
				{
					throw new Utility.CustomAppException(BLL.Core.ErrorNumber.CarrierCustomerNotFound);
				}
				if (fromAccount.IsActive == false)
				{
					throw new Utility.CustomAppException(BLL.Core.ErrorNumber.SenderAccountNotActive);
				}
				if (fromAccount is BLL.Accounts.BankAccount)
				{
					if (((BLL.Accounts.BankAccount)fromAccount).Balance < orderAmount)
					{
						throw new Utility.CustomAppException(BLL.Core.ErrorNumber.SenderAccountInsufficientBalance);
					}
				}
				if (fromAccount is BLL.Accounts.StoredValueAccount)
				{
					if (((BLL.Accounts.StoredValueAccount)fromAccount).CarrierBalance < orderAmount)
					{
						throw new Utility.CustomAppException(BLL.Core.ErrorNumber.SenderAccountInsufficientBalance);
					}
				}
				// validate receiving phone
				if (toPhone == null)
				{
					throw new Utility.CustomAppException(BLL.Core.ErrorNumber.ReceiverPhoneNotFound);
				}
				if (toPhone.IsActive == false)
				{
					throw new Utility.CustomAppException(BLL.Core.ErrorNumber.ReceiverPhoneNotActive);
				}
				// validate receiving account
				if (toAccount == null)
				{
					throw new Utility.CustomAppException(BLL.Core.ErrorNumber.ReceiverAccountNotFound);
				}
				if (toAccount.IsActive == false)
				{
					throw new Utility.CustomAppException(BLL.Core.ErrorNumber.ReceiverAccountNotActive);
				}
				// create order
				Order customerOrder = new Order();
				customerOrder.CurrencyCode = orderCurrency;
				customerOrder.DebitMetaPartnerID = fromAccount.MetaPartnerID;
				customerOrder.CreditMetaPartnerID = toAccount.MetaPartnerID;
				customerOrder.LogToAccountID = toAccount.AccountID;
				customerOrder.OrderAmount = orderAmount;
				// TODO: add fees, promotions, coupons, etc.
				customerOrder.OrderSubtotal = orderAmount;
				customerOrder.OrderTax = 0;
				customerOrder.OrderDescription = orderDescription;
				customerOrder.OrderStatusCode = (int)BLL.Orders.OrderStatusCode.New;
				// add payment info to order
				BLL.Payments.Payment customerPayment = new BLL.Payments.Payment();
				customerPayment.DebitMetaPartnerID = fromAccount.MetaPartnerID;
				customerPayment.CreditMetaPartnerID = toAccount.MetaPartnerID;
				customerPayment.SourceAccountID = fromAccount.AccountID;
				customerPayment.DestinationAccountID = toAccount.AccountID;
				customerPayment.PaymentAmount = orderAmount;
				// TODO: add fees, etc.
				customerPayment.PaymentSubtotal = orderAmount;
				customerPayment.PaymentTax = 0;
				customerPayment.PaymentServiceCharge = 0;
				customerPayment.PaymentStatusCode = (int)BLL.Payments.PaymentStatusCode.New;
				
				customerOrder.PaymentList = new SortableList<MW.MComm.WalletSolution.BLL.Payments.Payment>();
				customerOrder.PaymentList.Add(customerPayment);
				// save order
				customerOrder.Save(true);
				// return saved order
				return customerOrder;
			}
			catch (Utility.CustomAppException ex)
			{
				throw ex;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Orders.InitiateOrder");
			}
		}
		#endregion Methods
	}
}