
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
namespace MW.MComm.WalletSolution.BLL.Accounts
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to hold and manage information for DebitAccount instances.</summary>
	///
	/// File History:
	/// <created>3/5/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[Serializable()]
	[DataTransform(Name = "MW.MComm.WalletSolution.DAL.Accounts.DebitAccount")]
	public partial class DebitAccount : BLL.Accounts.Account
	{
		#region Constants
		#endregion Constants
		#region Fields
		// for DebitAccountNumber property
		protected string _debitAccountNumber = MOD.Data.DefaultValue.String;
		// for IsDefaultDebitAccount property
		protected bool _isDefaultDebitAccount = MOD.Data.DefaultValue.Bool;
		// for BankCustomerCode property
		protected string _bankCustomerCode = null;
		#endregion Fields
		#region Properties
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the DebitAccountNumber.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual string DebitAccountNumber
		{
			get
			{
				return _debitAccountNumber;
			}
			set
			{
				if ((_debitAccountNumber != null && !_debitAccountNumber.Equals(value)) || _debitAccountNumber != value)
				{
					_debitAccountNumber = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the IsDefaultDebitAccount.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Bool)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual bool IsDefaultDebitAccount
		{
			get
			{
				return _isDefaultDebitAccount;
			}
			set
			{
				if (_isDefaultDebitAccount != value)
				{
					_isDefaultDebitAccount = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the BankCustomerCode.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(null)]
		[XmlElementAttribute(IsNullable=true)]
		[DataTransform]
		public virtual string BankCustomerCode
		{
			get
			{
				return _bankCustomerCode;
			}
			set
			{
				if ((_bankCustomerCode != null && !_bankCustomerCode.Equals(value)) || _bankCustomerCode != value)
				{
					_bankCustomerCode = value;
					_isDirty = true;
				}
			}
		}
		#endregion Properties
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public DebitAccount()
		{
			//
			// constructor logic
			//
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method creates an instance with the primary key values.</summary>
		// ------------------------------------------------------------------------------
		public DebitAccount(string keyValues, bool isPrimaryKeyValues)
		{
			if (isPrimaryKeyValues == true)
			{
				//
				// set the primary keys from the comma delimeted list
				//
				PrimaryKey = keyValues;
			}
			else
			{
				//
				// set the index keys from the comma delimeted list
				//
				PrimaryIndex = keyValues;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This constructor initializes the DebitAccount from its DAL counterpart.</summary>
		// ------------------------------------------------------------------------------
		public DebitAccount(DAL.Accounts.DebitAccount businessObject) : base(businessObject)
		{
		}
		// ------------------------------------------------------------------------------
		/// <summary>This constructor initializes the DebitAccount from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public DebitAccount(Guid accountID)
		{
			AccountID = accountID;
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the DebitAccount with its already set properties.</summary>
		// ------------------------------------------------------------------------------
		public new void Load()
		{
			Load(AccountID);
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the DebitAccount from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public new void Load(Guid accountID)
		{
			BLL.Accounts.DebitAccount businessObject = null;
			businessObject = BLL.Accounts.DebitAccountManager.GetOneDebitAccount(accountID);
			if(businessObject != null)
			{
				ReflectionHelper.Copy(businessObject, this, true);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the DebitAccount into the database,
		/// performing add/update auto detect and performing a cascade operation if indicated.</summary>
		// ------------------------------------------------------------------------------
		public new void Save(bool performCascade)
		{
			if (IsLoaded == false)
			{
				BLL.Accounts.DebitAccountManager.AddOneDebitAccount(this, performCascade);
			}
			else
			{
				BLL.Accounts.DebitAccountManager.UpdateOneDebitAccount(this, performCascade);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the DebitAccount into the database,
		/// performing add/update auto detect and without performing a cascade operation.</summary>
		// ------------------------------------------------------------------------------
		public new void Save()
		{
			Save(false);
		}
		/// <summary>
		///	Clears the dirty state of DebitAccount and its subcollections.
		/// </summary>
		/// <param name="clearCollectionDirtyState">Flag to clear subcollections.</param>
		/// <returns></returns>
		public override void ClearDirtyState(bool clearCollectionDirtyState)
		{
			// clear base items
			base.ClearDirtyState();
			// clear collections and other items
			if (this._externalAccountItem != null)
			{
				this.ExternalAccountItem.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._metaPartner != null)
			{
				this.MetaPartner.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._accountSubType != null)
			{
				this.AccountSubType.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._currency != null)
			{
				this.Currency.ClearDirtyState(clearCollectionDirtyState);
			}
		}
		/// <summary>
		///	Tests to see if input object is convertable to DebitAccount, and has the same primary key values.
		/// </summary>
		/// <param name="obj">Input object to test.</param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			DebitAccount debitAccountInstance = obj as DebitAccount;
			if (debitAccountInstance == null)
				return false;
			else
				return (_accountID == debitAccountInstance.AccountID);
		}
		/// <summary>
		///	Returns unique identifying integer		 
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return (_accountID.ToString()).GetHashCode();
		}
		#endregion Methods
	}
}