
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
	/// <summary>This class is used to hold and manage information for AccountAttributeValue instances.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[Serializable()]
	[DataTransform(Name = "MW.MComm.WalletSolution.DAL.Accounts.AccountAttributeValue")]
	public partial class AccountAttributeValue : PersistedBusinessObject
	{
		#region Constants
		#endregion Constants
		#region Fields
		// for AccountAttributeValueID property
		protected Guid _accountAttributeValueID = MOD.Data.DefaultValue.Guid;
		// for AccountID property
		protected Guid _accountID = MOD.Data.DefaultValue.Guid;
		// for BaseAttributeID property
		protected Guid _baseAttributeID = MOD.Data.DefaultValue.Guid;
		// for ParameterValue property
		protected string _parameterValue = null;
		// for AccountName read only property
		[DataTransform]
		protected string _accountName = MOD.Data.DefaultValue.String;
		// for Account property
		protected BLL.Accounts.Account _account = null;
		// for AccountAttribute property
		protected BLL.Accounts.AccountAttribute _accountAttribute = null;
		#endregion Fields
		#region Properties
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the AccountAttributeValueID.</summary>
		// ------------------------------------------------------------------------------
		[XmlElementAttribute()]
		[DataTransform]
		public virtual Guid AccountAttributeValueID
		{
			get
			{
				return _accountAttributeValueID;
			}
			set
			{
				if (_accountAttributeValueID != value)
				{
					_accountAttributeValueID = value;
					_isDirty = true;
				}
			}
		}
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
					_account = null;
					// reset Account
					BLL.PersistedBusinessObject vAccount = (BLL.PersistedBusinessObject) Account;
					vAccount = null;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the BaseAttributeID.</summary>
		// ------------------------------------------------------------------------------
		[XmlElementAttribute()]
		[DataTransform]
		public virtual Guid BaseAttributeID
		{
			get
			{
				return _baseAttributeID;
			}
			set
			{
				if (_baseAttributeID != value)
				{
					_baseAttributeID = value;
					_accountAttribute = null;
					// reset AccountAttribute
					BLL.PersistedBusinessObject vAccountAttribute = (BLL.PersistedBusinessObject) AccountAttribute;
					vAccountAttribute = null;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the ParameterValue.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(null)]
		[XmlElementAttribute(IsNullable=true)]
		[DataTransform]
		public virtual string ParameterValue
		{
			get
			{
				return _parameterValue;
			}
			set
			{
				if ((_parameterValue != null && !_parameterValue.Equals(value)) || _parameterValue != value)
				{
					_parameterValue = value;
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
				return (MOD.Data.DataHelper.GetString(AccountAttributeValueID,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					AccountAttributeValueID = MOD.Data.DataHelper.GetGuid(keyValues[0], MOD.Data.DefaultValue.Guid);
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
				return (MOD.Data.DataHelper.GetString(AccountAttributeValueID,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					AccountAttributeValueID = MOD.Data.DataHelper.GetGuid(keyValues[0], MOD.Data.DefaultValue.Guid);
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
		/// <summary>This read only property gets the AccountName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		public virtual string AccountName
		{
			get
			{
				return _accountName;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of Account.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Accounts.Account Account
		{
			get
			{
				if (_account == null  && IsLazyLoadable == true)
				{
					_account = BLL.Accounts.AccountManager.GetOneAccount((Guid)AccountID);
					// refresh derived properties
					if (_account != null)
					{
						_accountName = _account.AccountName;
					}
					else
					{
						_accountName = MOD.Data.DefaultValue.String;
					}
				}
				return _account;
			}
			set
			{
				if (_account != value)
				{
					_account = value;
					_isDirty = true;
					// refresh derived properties
					if (_account != null)
					{
						_accountName = _account.AccountName;
					}
					else
					{
						_accountName = MOD.Data.DefaultValue.String;
					}
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of AccountAttribute.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Accounts.AccountAttribute AccountAttribute
		{
			get
			{
				if (_accountAttribute == null  && IsLazyLoadable == true)
				{
					_accountAttribute = BLL.Accounts.AccountAttributeManager.GetOneAccountAttribute((Guid)BaseAttributeID);
					// refresh derived properties
					if (_accountAttribute != null)
					{
					}
					else
					{
					}
				}
				return _accountAttribute;
			}
			set
			{
				if (_accountAttribute != value)
				{
					_accountAttribute = value;
					_isDirty = true;
					// refresh derived properties
					if (_accountAttribute != null)
					{
					}
					else
					{
					}
				}
			}
		}
		#endregion Properties
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public AccountAttributeValue()
		{
			//
			// constructor logic
			//
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method creates an instance with the primary key values.</summary>
		// ------------------------------------------------------------------------------
		public AccountAttributeValue(string keyValues, bool isPrimaryKeyValues)
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
		/// <summary>This constructor initializes the AccountAttributeValue from its DAL counterpart.</summary>
		// ------------------------------------------------------------------------------
		public AccountAttributeValue(DAL.Accounts.AccountAttributeValue businessObject) : base(businessObject)
		{
		}
		// ------------------------------------------------------------------------------
		/// <summary>This constructor initializes the AccountAttributeValue from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public AccountAttributeValue(Guid accountAttributeValueID)
		{
			AccountAttributeValueID = accountAttributeValueID;
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the AccountAttributeValue with its already set properties.</summary>
		// ------------------------------------------------------------------------------
		public void Load()
		{
			Load(AccountAttributeValueID);
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the AccountAttributeValue from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public void Load(Guid accountAttributeValueID)
		{
			BLL.Accounts.AccountAttributeValue businessObject = null;
			businessObject = BLL.Accounts.AccountAttributeValueManager.GetOneAccountAttributeValue(accountAttributeValueID);
			if(businessObject != null)
			{
				ReflectionHelper.Copy(businessObject, this, true);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the AccountAttributeValue into the database,
		/// performing add/update auto detect and performing a cascade operation if indicated.</summary>
		// ------------------------------------------------------------------------------
		public void Save(bool performCascade)
		{
			if (IsLoaded == false)
			{
				BLL.Accounts.AccountAttributeValueManager.UpsertOneAccountAttributeValue(this, performCascade);
			}
			else
			{
				BLL.Accounts.AccountAttributeValueManager.UpsertOneAccountAttributeValue(this, performCascade);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the AccountAttributeValue into the database,
		/// performing add/update auto detect and without performing a cascade operation.</summary>
		// ------------------------------------------------------------------------------
		public void Save()
		{
			Save(false);
		}
		/// <summary>
		///	Clears the dirty state of AccountAttributeValue and its subcollections.
		/// </summary>
		/// <param name="clearCollectionDirtyState">Flag to clear subcollections.</param>
		/// <returns></returns>
		public override void ClearDirtyState(bool clearCollectionDirtyState)
		{
			// clear base items
			base.ClearDirtyState();
			// clear collections and other items
			if (this._account != null)
			{
				this.Account.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._accountAttribute != null)
			{
				this.AccountAttribute.ClearDirtyState(clearCollectionDirtyState);
			}
		}
		/// <summary>
		///	Tests to see if input object is convertable to AccountAttributeValue, and has the same primary key values.
		/// </summary>
		/// <param name="obj">Input object to test.</param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			AccountAttributeValue accountAttributeValueInstance = obj as AccountAttributeValue;
			if (accountAttributeValueInstance == null)
				return false;
			else
				return (_accountAttributeValueID == accountAttributeValueInstance.AccountAttributeValueID);
		}
		/// <summary>
		///	Returns unique identifying integer		 
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return (_accountAttributeValueID.ToString()).GetHashCode();
		}
		#endregion Methods
	}
}