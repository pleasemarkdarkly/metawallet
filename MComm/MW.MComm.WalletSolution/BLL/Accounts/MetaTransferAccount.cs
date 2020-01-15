
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
	/// <summary>This class is used to hold and manage information for MetaTransferAccount instances.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[Serializable()]
	[DataTransform(Name = "MW.MComm.WalletSolution.DAL.Accounts.MetaTransferAccount")]
	public partial class MetaTransferAccount : BLL.Accounts.Account
	{
		#region Constants
		#endregion Constants
		#region Fields
		// for MetaTransferAccountNumber property
		protected string _metaTransferAccountNumber = MOD.Data.DefaultValue.String;
		// for PaymentInstitutionCode property
		protected int _paymentInstitutionCode = MOD.Data.DefaultValue.Int;
		// for PaymentInstitutionName read only property
		[DataTransform]
		protected string _paymentInstitutionName = MOD.Data.DefaultValue.String;
		// for PaymentInstitution property
		protected BLL.Accounts.PaymentInstitution _paymentInstitution = null;
		#endregion Fields
		#region Properties
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the MetaTransferAccountNumber.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual string MetaTransferAccountNumber
		{
			get
			{
				return _metaTransferAccountNumber;
			}
			set
			{
				if ((_metaTransferAccountNumber != null && !_metaTransferAccountNumber.Equals(value)) || _metaTransferAccountNumber != value)
				{
					_metaTransferAccountNumber = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the PaymentInstitutionCode.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Int)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual int PaymentInstitutionCode
		{
			get
			{
				return _paymentInstitutionCode;
			}
			set
			{
				if (_paymentInstitutionCode != value)
				{
					_paymentInstitutionCode = value;
					_paymentInstitution = null;
					// reset PaymentInstitution
					BLL.PersistedBusinessObject vPaymentInstitution = (BLL.PersistedBusinessObject) PaymentInstitution;
					vPaymentInstitution = null;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property checks for any collections that have been modified since object was last saved to or loaded from the database</summary>
		// ------------------------------------------------------------------------------
		public override bool IsCollectionDirty
		{
			get
			{
				return (
				base.IsCollectionDirty);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This read only property gets the PaymentInstitutionName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		public virtual string PaymentInstitutionName
		{
			get
			{
				return _paymentInstitutionName;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of PaymentInstitution.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Accounts.PaymentInstitution PaymentInstitution
		{
			get
			{
				if (_paymentInstitution == null  && IsLazyLoadable == true)
				{
					_paymentInstitution = BLL.Accounts.PaymentInstitutionManager.GetOnePaymentInstitution((int)PaymentInstitutionCode);
					// refresh derived properties
					if (_paymentInstitution != null)
					{
						_paymentInstitutionName = _paymentInstitution.PaymentInstitutionName;
					}
					else
					{
						_paymentInstitutionName = MOD.Data.DefaultValue.String;
					}
				}
				return _paymentInstitution;
			}
			set
			{
				if (_paymentInstitution != value)
				{
					_paymentInstitution = value;
					_isDirty = true;
					// refresh derived properties
					if (_paymentInstitution != null)
					{
						_paymentInstitutionName = _paymentInstitution.PaymentInstitutionName;
					}
					else
					{
						_paymentInstitutionName = MOD.Data.DefaultValue.String;
					}
				}
			}
		}
		#endregion Properties
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public MetaTransferAccount()
		{
			//
			// constructor logic
			//
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method creates an instance with the primary key values.</summary>
		// ------------------------------------------------------------------------------
		public MetaTransferAccount(string keyValues, bool isPrimaryKeyValues)
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
		/// <summary>This constructor initializes the MetaTransferAccount from its DAL counterpart.</summary>
		// ------------------------------------------------------------------------------
		public MetaTransferAccount(DAL.Accounts.MetaTransferAccount businessObject) : base(businessObject)
		{
		}
		// ------------------------------------------------------------------------------
		/// <summary>This constructor initializes the MetaTransferAccount from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public MetaTransferAccount(Guid accountID)
		{
			AccountID = accountID;
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the MetaTransferAccount with its already set properties.</summary>
		// ------------------------------------------------------------------------------
		public new void Load()
		{
			Load(AccountID);
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the MetaTransferAccount from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public new void Load(Guid accountID)
		{
			BLL.Accounts.MetaTransferAccount businessObject = null;
			businessObject = BLL.Accounts.MetaTransferAccountManager.GetOneMetaTransferAccount(accountID);
			if(businessObject != null)
			{
				ReflectionHelper.Copy(businessObject, this, true);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the MetaTransferAccount into the database,
		/// performing add/update auto detect and performing a cascade operation if indicated.</summary>
		// ------------------------------------------------------------------------------
		public new void Save(bool performCascade)
		{
			if (IsLoaded == false)
			{
				BLL.Accounts.MetaTransferAccountManager.AddOneMetaTransferAccount(this, performCascade);
			}
			else
			{
				BLL.Accounts.MetaTransferAccountManager.UpdateOneMetaTransferAccount(this, performCascade);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the MetaTransferAccount into the database,
		/// performing add/update auto detect and without performing a cascade operation.</summary>
		// ------------------------------------------------------------------------------
		public new void Save()
		{
			Save(false);
		}
		/// <summary>
		///	Clears the dirty state of MetaTransferAccount and its subcollections.
		/// </summary>
		/// <param name="clearCollectionDirtyState">Flag to clear subcollections.</param>
		/// <returns></returns>
		public override void ClearDirtyState(bool clearCollectionDirtyState)
		{
			// clear base items
			base.ClearDirtyState();
			// clear collections and other items
			if (this._paymentInstitution != null)
			{
				this.PaymentInstitution.ClearDirtyState(clearCollectionDirtyState);
			}
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
		///	Tests to see if input object is convertable to MetaTransferAccount, and has the same primary key values.
		/// </summary>
		/// <param name="obj">Input object to test.</param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			MetaTransferAccount metaTransferAccountInstance = obj as MetaTransferAccount;
			if (metaTransferAccountInstance == null)
				return false;
			else
				return (_accountID == metaTransferAccountInstance.AccountID);
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