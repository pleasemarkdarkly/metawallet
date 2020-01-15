
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
namespace MW.MComm.WalletSolution.BLL.Payments
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to hold and manage information for Payment instances.</summary>
	///
	/// File History:
	/// <created>10/27/2006 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[DataTransform(Name = "MW.MComm.WalletSolution.DAL.Payments.Payment")]
	public partial class Payment : PersistedBusinessObject
	{
		// for SourceAccount property
		protected BLL.Accounts.Account _sourceAccount = null;
		
		// for DestinationAccount property
		protected BLL.Accounts.Account _destinationAccount = null;
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the source account.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Accounts.Account SourceAccount
		{
			get
			{
				if (_sourceAccount == null)
				{
					_sourceAccount = BLL.Accounts.AccountManager.GetOneAccount(SourceAccountID);
					// refresh derived properties
				}
				return _sourceAccount;
			}
			set
			{
				if (_sourceAccount != value)
				{
					_sourceAccount = value;
					_isDirty = true;
					// refresh derived properties
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the source account.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Accounts.Account DestinationAccount
		{
			get
			{
				if (_destinationAccount == null)
				{
					_destinationAccount = BLL.Accounts.AccountManager.GetOneAccount(DestinationAccountID);
					// refresh derived properties
				}
				return _destinationAccount;
			}
			set
			{
				if (_destinationAccount != value)
				{
					_destinationAccount = value;
					_isDirty = true;
					// refresh derived properties
				}
			}
		}
		#region Methods
		#endregion Methods
	}
}