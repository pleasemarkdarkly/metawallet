
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
using MOD.Data;
using MW.MComm.WalletSolution.BLL.Config;
using BLL = MW.MComm.WalletSolution.BLL;
using Utility = MW.MComm.WalletSolution.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
namespace MW.MComm.WalletSolution.BLL.Events
{
	// ------------------------------------------------------------------------------
	/// <summary>This enumeration is for holding known Event codes.</summary>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public enum EventCode
	{
		/// <summary>None.</summary>
		None = 0,
		/// <summary>When a new customer is created!</summary>
		NewCustomer = 1,
		/// <summary>When a customer profile is updated.</summary>
		CustomerUpdated = 2,
		/// <summary>When a new account is created.</summary>
		AccountCreated = 3,
		/// <summary>When an account is updated.</summary>
		AccountUpdated = 4,
		/// <summary>When an order is created.</summary>
		OrderCreated = 5,
		/// <summary>When an order is updated.</summary>
		OrderUpdated = 6,
		/// <summary>When a payment is initiated.</summary>
		PaymentInitiated = 7,
		/// <summary>When a payment is completed.</summary>
		PaymentCompleted = 8,
		/// <summary>Phone To Phone Payment Transferred.</summary>
		PhoneToPhonePaymentTransferred = 9,
		/// <summary>This is for account query.</summary>
		PhoneAccountQueried = 10,
		/// <summary>This is for general customer messages, including error messages.</summary>
		CustomerMessage = 11,
		/// <summary>Requested payment transfer has been cancelled.</summary>
		PaymentCancelled = 12,
	}
}