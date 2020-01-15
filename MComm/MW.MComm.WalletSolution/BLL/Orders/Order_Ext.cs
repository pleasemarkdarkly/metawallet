
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/
using System;
using System.Xml;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using MOD.Data;
using MW.MComm.WalletSolution.BLL.Config;
using BLL = MW.MComm.WalletSolution.BLL;
using DAL = MW.MComm.WalletSolution.DAL;
using Utility = MW.MComm.WalletSolution.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
namespace MW.MComm.WalletSolution.BLL.Orders
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to hold and manage information for Order instances.</summary>
	///
	/// File History:
	/// <created>10/27/2006 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[DataTransform(Name = "MW.MComm.WalletSolution.DAL.Orders.Order")]
	public partial class Order : PersistedBusinessObject
	{
		#region Fields
		// for DebitMetaPartner property
		protected BLL.Customers.MetaPartner _debitMetaPartner = null;
		// for CreditMetaPartner property
		protected BLL.Customers.MetaPartner _creditMetaPartner = null;
		#endregion Fields
		#region Properties
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of MetaPartner.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Customers.MetaPartner DebitMetaPartner
		{
			get
			{
				if (_debitMetaPartner == null && IsLazyLoadable == true)
				{
					_debitMetaPartner = BLL.Customers.MetaPartnerManager.GetOneMetaPartner(DebitMetaPartnerID);
				}
				return _debitMetaPartner;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of MetaPartner.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Customers.MetaPartner CreditMetaPartner
		{
			get
			{
				if (_creditMetaPartner == null && IsLazyLoadable == true)
				{
					_creditMetaPartner = BLL.Customers.MetaPartnerManager.GetOneMetaPartner(CreditMetaPartnerID);
				}
				return _creditMetaPartner;
			}
		}
		#endregion Properties
		#region Methods
		// ------------------------------------------------------------------------------
		/// <summary>This method cancels the order, which prevents payment operations.</summary>
		// ------------------------------------------------------------------------------
		public void Cancel(string senderPhoneNumber, string senderPIN)
		{
			try
			{
				// validate order state before cancelling
				if (this.OrderStatusCode != (int)BLL.Orders.OrderStatusCode.Paid)
				{
					// validate sender PIN
					bool isValidPIN = false;
					foreach (BLL.Customers.MetaPartnerPhone loopPhone in this.DebitMetaPartner.PhoneList)
					{
						if (loopPhone.PhoneNumber == senderPhoneNumber && loopPhone.PIN == senderPIN)
						{
							isValidPIN = true;
							break;
						}
					}
					if (isValidPIN == true)
					{
						// PIN validated, cancel the order
						this.OrderStatusCode = (int)BLL.Orders.OrderStatusCode.Cancelled;
						this.Save();
					}
					else
					{
						// PIN not validated, cannot be cancelled
						throw new Utility.CustomAppException(BLL.Core.ErrorNumber.OrderCancelFailure);
					}
				}
				else
				{
					// order is already paid, cannot be cancelled
					throw new Utility.CustomAppException(BLL.Core.ErrorNumber.OrderCancelFailure);
				}
			}
			catch (Utility.CustomAppException ex)
			{
				throw ex;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Order.Cancel");
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method cancels the order, which prevents payment operations.</summary>
		// ------------------------------------------------------------------------------
		public void Approve(string senderPhoneNumber, string senderPIN)
		{
			try
			{
				// must be a new order to approve
				if (this.OrderStatusCode == (int)BLL.Orders.OrderStatusCode.New)
				{
					// validate sender PIN
					bool isValidPIN = false;
					foreach (BLL.Customers.MetaPartnerPhone loopPhone in this.DebitMetaPartner.PhoneList)
					{
						if (loopPhone.PhoneNumber == senderPhoneNumber && loopPhone.PIN == senderPIN)
						{
							isValidPIN = true;
							break;
						}
					}
					if (isValidPIN == true)
					{
						// PIN validated, approve order
						this.OrderStatusCode = (int)BLL.Orders.OrderStatusCode.Approved;
						this.Save();
					}
					else
					{
						// PIN not validated, do not approve order
						throw new Utility.CustomAppException(BLL.Core.ErrorNumber.CustomerPINinvalid);
					}
				}
				else
				{
					// order cannot be approved
					throw new Utility.CustomAppException(BLL.Core.ErrorNumber.OrderApprovalFailure);
				}
			}
			catch (Utility.CustomAppException ex)
			{
				throw ex;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Order.Cancel");
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method initiates payment for the order.</summary>
		// ------------------------------------------------------------------------------
		public void Pay()
		{
			try
			{
				// order must be approved prior to payment
				if (this.OrderStatusCode == (int)BLL.Orders.OrderStatusCode.Approved)
				{
					try
					{
						foreach (BLL.Payments.Payment loopPayment in this.PaymentList)
						{
							if (loopPayment.PaymentStatusCode == (int)BLL.Payments.PaymentStatusCode.New)
							{
								try
								{
									// determine type of payment services
									if (loopPayment.SourceAccount.AccountSubTypeCode == (int)BLL.Accounts.AccountSubTypeCode.StoredValueAccount && loopPayment.DestinationAccount.AccountSubTypeCode == (int)BLL.Accounts.AccountSubTypeCode.StoredValueAccount)
									{
										// stored value transfer
										// TODO: add configuration
										MComm.Nuevatel.CustomerManager.Service1 s_CustomerManager = new MComm.Nuevatel.CustomerManager.Service1();
										s_CustomerManager.Credentials = System.Net.CredentialCache.DefaultCredentials;
										MComm.Nuevatel.CustomerManager.addCreditResponse creditResponse = s_CustomerManager.wsAddCredit(this.CreditMetaPartner.PrimaryPhone.PhoneNumber, loopPayment.PaymentID.ToString(), this.OrderAmount, "metawallet", "walmet3942", "IVR");
										if (creditResponse.errorCode < 0)
										{
											// couldn't draw from sender account
											throw new Utility.CustomAppException(BLL.Core.ErrorNumber.SenderPaymentFailure, new Exception(creditResponse.errorMessage));
										}
										MComm.Nuevatel.CustomerManager.discount1Response discountResponse = s_CustomerManager.wsbalanceDiscount1(this.DebitMetaPartner.PrimaryPhone.PhoneNumber, loopPayment.PaymentID.ToString(), this.OrderAmount);
										if (discountResponse.errorCode < 0)
										{
											// couldn't transfer funds to receiver account
											throw new Utility.CustomAppException(BLL.Core.ErrorNumber.RecieverPaymentFailure, new Exception(discountResponse.errorMessage));
										}
									}
									else
									{
										// TODO: call appropriate bank payment services
									}
								}
								catch (Utility.CustomAppException ex)
								{
									throw ex;
								}
								catch (System.Exception ex)
								{
									// couldn't invoke carrier payment services
									throw new Utility.CustomAppException(BLL.Core.ErrorNumber.OrderPaidFailure, ex);
								}
								BLL.Payments.PaymentTransactionLog transaction = new BLL.Payments.PaymentTransactionLog();
								transaction.TransactionAmount = this.OrderAmount;
								transaction.TransactionStatusCode = (int)BLL.Payments.TransactionStatusCode.Success;
								transaction.TransactionTypeCode = (int)BLL.Payments.TransactionTypeCode.Capture;
								loopPayment.PaymentTransactionLogList = new MW.MComm.WalletSolution.BLL.SortableList<MW.MComm.WalletSolution.BLL.Payments.PaymentTransactionLog>();
								loopPayment.PaymentTransactionLogList.Add(transaction);
								loopPayment.Save(true);
							}
						}
						// cancel the order
						this.OrderStatusCode = (int)BLL.Orders.OrderStatusCode.Paid;
						this.Save();
					}
					catch (Utility.CustomAppException ex)
					{
						throw ex;
					}
					catch (System.Exception ex)
					{
						// order cannot be paid
						throw new Utility.CustomAppException(BLL.Core.ErrorNumber.OrderPaidFailure, ex);
					}
				}
				else
				{
					// order is not approved, cannot be paid
					throw new Utility.CustomAppException(BLL.Core.ErrorNumber.OrderPaidFailure);
				}
			}
			catch (Utility.CustomAppException ex)
			{
				throw ex;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Order.Pay");
			}
		}
		#endregion Methods
	}
}