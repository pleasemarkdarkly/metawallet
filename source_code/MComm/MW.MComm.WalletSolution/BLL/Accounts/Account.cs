
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
	/// <summary>This class is used to hold and manage information for Account instances.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[Serializable()]
	[DataTransform(Name = "MW.MComm.WalletSolution.DAL.Accounts.Account")]
	public partial class Account : PersistedBusinessObject
	{
		#region Constants
		#endregion Constants
		#region Fields
		// for AccountID property
		protected Guid _accountID = MOD.Data.DefaultValue.Guid;
		// for MetaPartnerID property
		protected Guid _metaPartnerID = MOD.Data.DefaultValue.Guid;
		// for AccountName property
		protected string _accountName = MOD.Data.DefaultValue.String;
		// for AccountSubTypeCode property
		protected int _accountSubTypeCode = MOD.Data.DefaultValue.Int;
		// for CurrencyCode property
		protected int _currencyCode = MOD.Data.DefaultValue.Int;
		// for Description property
		protected string _description = null;
		// for IsActive property
		protected bool _isActive = false;
		// for AccountSubTypeName read only property
		[DataTransform]
		protected string _accountSubTypeName = MOD.Data.DefaultValue.String;
		// for CurrencyName read only property
		[DataTransform]
		protected string _currencyName = MOD.Data.DefaultValue.String;
		// for MetaPartnerName read only property
		[DataTransform]
		protected string _metaPartnerName = MOD.Data.DefaultValue.String;
		// for DateFormatCode read only property
		[DataTransform]
		protected int _dateFormatCode = MOD.Data.DefaultValue.Int;
		// for ExternalAccountItem property
		protected BLL.Accounts.ExternalAccount _externalAccountItem = null;
		// for MetaPartner property
		protected BLL.Customers.MetaPartner _metaPartner = null;
		// for AccountSubType property
		protected BLL.Accounts.AccountSubType _accountSubType = null;
		// for Currency property
		protected BLL.Accounts.Currency _currency = null;
		#endregion Fields
		#region Properties
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the AccountID.</summary>
		// ------------------------------------------------------------------------------
		[XmlElementAttribute()]
		[DataTransform]
		public virtual Guid AccountID
		{
			get
			{
				return _accountID;
			}
			set
			{
				if (_accountID != value)
				{
					_accountID = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the MetaPartnerID.</summary>
		// ------------------------------------------------------------------------------
		[XmlElementAttribute()]
		[DataTransform]
		public virtual Guid MetaPartnerID
		{
			get
			{
				return _metaPartnerID;
			}
			set
			{
				if (_metaPartnerID != value)
				{
					_metaPartnerID = value;
					_metaPartner = null;
					// reset MetaPartner
					BLL.PersistedBusinessObject vMetaPartner = (BLL.PersistedBusinessObject) MetaPartner;
					vMetaPartner = null;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the AccountName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual string AccountName
		{
			get
			{
				return _accountName;
			}
			set
			{
				if ((_accountName != null && !_accountName.Equals(value)) || _accountName != value)
				{
					_accountName = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the AccountSubTypeCode.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Int)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual int AccountSubTypeCode
		{
			get
			{
				return _accountSubTypeCode;
			}
			set
			{
				if (_accountSubTypeCode != value)
				{
					_accountSubTypeCode = value;
					_accountSubType = null;
					// reset AccountSubType
					BLL.PersistedBusinessObject vAccountSubType = (BLL.PersistedBusinessObject) AccountSubType;
					vAccountSubType = null;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CurrencyCode.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Int)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual int CurrencyCode
		{
			get
			{
				return _currencyCode;
			}
			set
			{
				if (_currencyCode != value)
				{
					_currencyCode = value;
					_currency = null;
					// reset Currency
					BLL.PersistedBusinessObject vCurrency = (BLL.PersistedBusinessObject) Currency;
					vCurrency = null;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the Description.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(null)]
		[XmlElementAttribute(IsNullable=true)]
		[DataTransform]
		public virtual string Description
		{
			get
			{
				return _description;
			}
			set
			{
				if ((_description != null && !_description.Equals(value)) || _description != value)
				{
					_description = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the IsActive.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Bool)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual bool IsActive
		{
			get
			{
				return _isActive;
			}
			set
			{
				if (_isActive != value)
				{
					_isActive = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the primary key.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		public string PrimaryKey
		{
			get
			{
				return (MOD.Data.DataHelper.GetString(AccountID,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					AccountID = MOD.Data.DataHelper.GetGuid(keyValues[0], MOD.Data.DefaultValue.Guid);
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the primary name.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		public string PrimaryName
		{
			get
			{
				if (_primaryName != MOD.Data.DefaultValue.String)
				{
					return _primaryName;
				}
				else
				{
					return AccountName;
				}
			}
			set
			{
				_primaryName = value;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the primary index.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		public string PrimaryIndex
		{
			get
			{
				return (MOD.Data.DataHelper.GetString(AccountID,"") + ", " + MOD.Data.DataHelper.GetString(MetaPartnerID,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					AccountID = MOD.Data.DataHelper.GetGuid(keyValues[0], MOD.Data.DefaultValue.Guid);
				}
				if (keyValues.Length > 1)
				{
					MetaPartnerID = MOD.Data.DataHelper.GetGuid(keyValues[1], MOD.Data.DefaultValue.Guid);
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the primary sort column.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		public string PrimarySortColumn
		{
			get
			{
				if (_primarySortColumn != MOD.Data.DefaultValue.String)
				{
					return _primarySortColumn;
				}
				else
				{
					return "AccountName";
				}
			}
			set
			{
				_primarySortColumn = value;
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
		/// <summary>This read only property gets the AccountSubTypeName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		public virtual string AccountSubTypeName
		{
			get
			{
				return _accountSubTypeName;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This read only property gets the CurrencyName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		public virtual string CurrencyName
		{
			get
			{
				return _currencyName;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This read only property gets the MetaPartnerName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		public virtual string MetaPartnerName
		{
			get
			{
				return _metaPartnerName;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This read only property gets the DateFormatCode.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Int)]
		[XmlElementAttribute()]
		public virtual int DateFormatCode
		{
			get
			{
				return _dateFormatCode;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of ExternalAccount.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Accounts.ExternalAccount ExternalAccountItem
		{
			get
			{
				return _externalAccountItem;
			}
			set
			{
				if (_externalAccountItem != value)
				{
					_externalAccountItem = value;
					_isDirty = true;
					// refresh derived properties
					if (_externalAccountItem != null)
					{
					}
					else
					{
					}
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of MetaPartner.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Customers.MetaPartner MetaPartner
		{
			get
			{
				if (_metaPartner == null  && IsLazyLoadable == true)
				{
					_metaPartner = BLL.Customers.MetaPartnerManager.GetOneMetaPartner((Guid)MetaPartnerID);
					// refresh derived properties
					if (_metaPartner != null)
					{
						_metaPartnerName = _metaPartner.MetaPartnerName;
						_dateFormatCode = _metaPartner.DateFormatCode;
					}
					else
					{
						_metaPartnerName = MOD.Data.DefaultValue.String;
						_dateFormatCode = MOD.Data.DefaultValue.Int;
					}
				}
				return _metaPartner;
			}
			set
			{
				if (_metaPartner != value)
				{
					_metaPartner = value;
					_isDirty = true;
					// refresh derived properties
					if (_metaPartner != null)
					{
						_metaPartnerName = _metaPartner.MetaPartnerName;
						_dateFormatCode = _metaPartner.DateFormatCode;
					}
					else
					{
						_metaPartnerName = MOD.Data.DefaultValue.String;
						_dateFormatCode = MOD.Data.DefaultValue.Int;
					}
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of AccountSubType.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Accounts.AccountSubType AccountSubType
		{
			get
			{
				if (_accountSubType == null  && IsLazyLoadable == true)
				{
					_accountSubType = BLL.Accounts.AccountSubTypeManager.GetOneAccountSubType((int)AccountSubTypeCode);
					// refresh derived properties
					if (_accountSubType != null)
					{
						_accountSubTypeName = _accountSubType.AccountSubTypeName;
					}
					else
					{
						_accountSubTypeName = MOD.Data.DefaultValue.String;
					}
				}
				return _accountSubType;
			}
			set
			{
				if (_accountSubType != value)
				{
					_accountSubType = value;
					_isDirty = true;
					// refresh derived properties
					if (_accountSubType != null)
					{
						_accountSubTypeName = _accountSubType.AccountSubTypeName;
					}
					else
					{
						_accountSubTypeName = MOD.Data.DefaultValue.String;
					}
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of Currency.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Accounts.Currency Currency
		{
			get
			{
				if (_currency == null  && IsLazyLoadable == true)
				{
					_currency = BLL.Accounts.CurrencyManager.GetOneCurrency((int)CurrencyCode);
					// refresh derived properties
					if (_currency != null)
					{
						_currencyName = _currency.CurrencyName;
					}
					else
					{
						_currencyName = MOD.Data.DefaultValue.String;
					}
				}
				return _currency;
			}
			set
			{
				if (_currency != value)
				{
					_currency = value;
					_isDirty = true;
					// refresh derived properties
					if (_currency != null)
					{
						_currencyName = _currency.CurrencyName;
					}
					else
					{
						_currencyName = MOD.Data.DefaultValue.String;
					}
				}
			}
		}
		#endregion Properties
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public Account()
		{
			//
			// constructor logic
			//
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method creates an instance with the primary key values.</summary>
		// ------------------------------------------------------------------------------
		public Account(string keyValues, bool isPrimaryKeyValues)
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
		/// <summary>This constructor initializes the Account from its DAL counterpart.</summary>
		// ------------------------------------------------------------------------------
		public Account(DAL.Accounts.Account businessObject) : base(businessObject)
		{
		}
		// ------------------------------------------------------------------------------
		/// <summary>This constructor initializes the Account from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public Account(Guid accountID)
		{
			AccountID = accountID;
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the Account with its already set properties.</summary>
		// ------------------------------------------------------------------------------
		public void Load()
		{
			Load(AccountID);
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the Account from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public void Load(Guid accountID)
		{
			BLL.Accounts.Account businessObject = null;
			businessObject = BLL.Accounts.AccountManager.GetOneAccount(accountID);
			if(businessObject != null)
			{
				ReflectionHelper.Copy(businessObject, this, true);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the Account into the database,
		/// performing add/update auto detect and performing a cascade operation if indicated.</summary>
		// ------------------------------------------------------------------------------
		public void Save(bool performCascade)
		{
			if (IsLoaded == false)
			{
				BLL.Accounts.AccountManager.UpsertOneAccount(this, performCascade);
			}
			else
			{
				BLL.Accounts.AccountManager.UpsertOneAccount(this, performCascade);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the Account into the database,
		/// performing add/update auto detect and without performing a cascade operation.</summary>
		// ------------------------------------------------------------------------------
		public void Save()
		{
			Save(false);
		}
		/// <summary>
		///	Clears the dirty state of Account and its subcollections.
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
		///	Tests to see if input object is convertable to Account, and has the same primary key values.
		/// </summary>
		/// <param name="obj">Input object to test.</param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			Account accountInstance = obj as Account;
			if (accountInstance == null)
				return false;
			else
				return (_accountID == accountInstance.AccountID);
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