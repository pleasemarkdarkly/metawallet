
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
namespace MW.MComm.WalletSolution.BLL.Customers
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to hold and manage information for MetaPartner instances.</summary>
	///
	/// File History:
	/// <created>10/27/2006 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[DataTransform(Name = "MW.MComm.WalletSolution.DAL.Customers.MetaPartner")]
	public partial class MetaPartner : PersistedBusinessObject
	{
		// ------------------------------------------------------------------------------
		/// <summary>This property gets the Primary Phone Number.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual MetaPartnerPhone PrimaryPhone
		{
			get
			{
				MetaPartnerPhone primaryPhone = new MetaPartnerPhone();
				foreach(BLL.Customers.MetaPartnerPhone loopPhone in this.PhoneList)
				{
					if (loopPhone.IsActive == true && loopPhone.Carrier.CarrierCode == PrimaryCarrierCode)
					{
						primaryPhone = loopPhone;
						break;
					}
				}
				return primaryPhone;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets the Primary Carrier Code.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Int)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual int PrimaryCarrierCode
		{
			get
			{
				return (int) CarrierCode.Nuevatel;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets the Primary Stored Value Account.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Accounts.StoredValueAccount PrimaryStoredValueAccount
		{
			get
			{
				BLL.Accounts.StoredValueAccount primaryStoredValueAccount = null;
				foreach (BLL.Accounts.StoredValueAccount loopAccount in this.StoredValueAccountList)
				{
					if (loopAccount.IsActive == true)
					{
						if (primaryStoredValueAccount == null || loopAccount.IsDefaultDebitAccount == true)
						{
							primaryStoredValueAccount = loopAccount;
						}
					}
				}
				return primaryStoredValueAccount;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets the Primary Bank Account.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Accounts.BankAccount PrimaryBankAccount
		{
			get
			{
				BLL.Accounts.BankAccount primaryBankAccount = null;
				foreach (BLL.Accounts.BankAccount loopAccount in this.BankAccountList)
				{
					if (loopAccount.IsActive == true)
					{
						if (primaryBankAccount == null || loopAccount.IsDefaultDebitAccount == true)
						{
							primaryBankAccount = loopAccount;
						}
					}
				}
				return primaryBankAccount;
			}
		}
		#region Methods
		#endregion Methods
	}
}