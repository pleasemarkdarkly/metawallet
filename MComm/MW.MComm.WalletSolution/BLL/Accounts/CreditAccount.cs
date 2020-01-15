
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
	/// <summary>This class is used to hold and manage information for CreditAccount instances.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[Serializable()]
	[DataTransform(Name = "MW.MComm.WalletSolution.DAL.Accounts.CreditAccount")]
	public partial class CreditAccount : BLL.Accounts.Account
	{
		#region Constants
		#endregion Constants
		#region Fields
		// for CreditCardNumber property
		protected string _creditCardNumber = null;
		// for CreditCardLastFour property
		protected string _creditCardLastFour = MOD.Data.DefaultValue.String;
		// for CreditCardName property
		protected string _creditCardName = null;
		// for ExpirationDate property
		protected DateTime? _expirationDate = null;
		// for CreditCardTypeCode property
		protected int _creditCardTypeCode = MOD.Data.DefaultValue.Int;
		// for CreditCardTypeName read only property
		[DataTransform]
		protected string _creditCardTypeName = MOD.Data.DefaultValue.String;
		// for CreditCardType property
		protected BLL.Accounts.CreditCardType _creditCardType = null;
		#endregion Fields
		#region Properties
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CreditCardNumber.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(null)]
		[XmlElementAttribute(IsNullable=true)]
		[DataTransform]
		public virtual string CreditCardNumber
		{
			get
			{
				return _creditCardNumber;
			}
			set
			{
				if ((_creditCardNumber != null && !_creditCardNumber.Equals(value)) || _creditCardNumber != value)
				{
					_creditCardNumber = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CreditCardLastFour.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual string CreditCardLastFour
		{
			get
			{
				return _creditCardLastFour;
			}
			set
			{
				if ((_creditCardLastFour != null && !_creditCardLastFour.Equals(value)) || _creditCardLastFour != value)
				{
					_creditCardLastFour = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CreditCardName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(null)]
		[XmlElementAttribute(IsNullable=true)]
		[DataTransform]
		public virtual string CreditCardName
		{
			get
			{
				return _creditCardName;
			}
			set
			{
				if ((_creditCardName != null && !_creditCardName.Equals(value)) || _creditCardName != value)
				{
					_creditCardName = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the ExpirationDate.</summary>
		// ------------------------------------------------------------------------------
		[XmlElementAttribute(IsNullable=true)]
		[DataTransform]
		public virtual DateTime? ExpirationDate
		{
			get
			{
				return _expirationDate;
			}
			set
			{
				if ((_expirationDate != null && !_expirationDate.Equals(value)) || _expirationDate != value)
				{
					_expirationDate = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CreditCardTypeCode.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Int)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual int CreditCardTypeCode
		{
			get
			{
				return _creditCardTypeCode;
			}
			set
			{
				if (_creditCardTypeCode != value)
				{
					_creditCardTypeCode = value;
					_creditCardType = null;
					// reset CreditCardType
					BLL.PersistedBusinessObject vCreditCardType = (BLL.PersistedBusinessObject) CreditCardType;
					vCreditCardType = null;
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
		/// <summary>This read only property gets the CreditCardTypeName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		public virtual string CreditCardTypeName
		{
			get
			{
				return _creditCardTypeName;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of CreditCardType.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Accounts.CreditCardType CreditCardType
		{
			get
			{
				if (_creditCardType == null  && IsLazyLoadable == true)
				{
					_creditCardType = BLL.Accounts.CreditCardTypeManager.GetOneCreditCardType((int)CreditCardTypeCode);
					// refresh derived properties
					if (_creditCardType != null)
					{
						_creditCardTypeName = _creditCardType.CreditCardTypeName;
					}
					else
					{
						_creditCardTypeName = MOD.Data.DefaultValue.String;
					}
				}
				return _creditCardType;
			}
			set
			{
				if (_creditCardType != value)
				{
					_creditCardType = value;
					_isDirty = true;
					// refresh derived properties
					if (_creditCardType != null)
					{
						_creditCardTypeName = _creditCardType.CreditCardTypeName;
					}
					else
					{
						_creditCardTypeName = MOD.Data.DefaultValue.String;
					}
				}
			}
		}
		#endregion Properties
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public CreditAccount()
		{
			//
			// constructor logic
			//
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method creates an instance with the primary key values.</summary>
		// ------------------------------------------------------------------------------
		public CreditAccount(string keyValues, bool isPrimaryKeyValues)
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
		/// <summary>This constructor initializes the CreditAccount from its DAL counterpart.</summary>
		// ------------------------------------------------------------------------------
		public CreditAccount(DAL.Accounts.CreditAccount businessObject) : base(businessObject)
		{
		}
		// ------------------------------------------------------------------------------
		/// <summary>This constructor initializes the CreditAccount from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public CreditAccount(Guid accountID)
		{
			AccountID = accountID;
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the CreditAccount with its already set properties.</summary>
		// ------------------------------------------------------------------------------
		public new void Load()
		{
			Load(AccountID);
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the CreditAccount from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public new void Load(Guid accountID)
		{
			BLL.Accounts.CreditAccount businessObject = null;
			businessObject = BLL.Accounts.CreditAccountManager.GetOneCreditAccount(accountID);
			if(businessObject != null)
			{
				ReflectionHelper.Copy(businessObject, this, true);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the CreditAccount into the database,
		/// performing add/update auto detect and performing a cascade operation if indicated.</summary>
		// ------------------------------------------------------------------------------
		public new void Save(bool performCascade)
		{
			if (IsLoaded == false)
			{
				BLL.Accounts.CreditAccountManager.AddOneCreditAccount(this, performCascade);
			}
			else
			{
				BLL.Accounts.CreditAccountManager.UpdateOneCreditAccount(this, performCascade);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the CreditAccount into the database,
		/// performing add/update auto detect and without performing a cascade operation.</summary>
		// ------------------------------------------------------------------------------
		public new void Save()
		{
			Save(false);
		}
		/// <summary>
		///	Clears the dirty state of CreditAccount and its subcollections.
		/// </summary>
		/// <param name="clearCollectionDirtyState">Flag to clear subcollections.</param>
		/// <returns></returns>
		public override void ClearDirtyState(bool clearCollectionDirtyState)
		{
			// clear base items
			base.ClearDirtyState();
			// clear collections and other items
			if (this._creditCardType != null)
			{
				this.CreditCardType.ClearDirtyState(clearCollectionDirtyState);
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
		///	Tests to see if input object is convertable to CreditAccount, and has the same primary key values.
		/// </summary>
		/// <param name="obj">Input object to test.</param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			CreditAccount creditAccountInstance = obj as CreditAccount;
			if (creditAccountInstance == null)
				return false;
			else
				return (_accountID == creditAccountInstance.AccountID);
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