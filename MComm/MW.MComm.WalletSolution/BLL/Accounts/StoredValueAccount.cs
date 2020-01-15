
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
	/// <summary>This class is used to hold and manage information for StoredValueAccount instances.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[Serializable()]
	[DataTransform(Name = "MW.MComm.WalletSolution.DAL.Accounts.StoredValueAccount")]
	public partial class StoredValueAccount : BLL.Accounts.DebitAccount
	{
		#region Constants
		#endregion Constants
		#region Fields
		// for Balance property
		protected decimal _balance = 0;
		// for MetaPartnerPhoneID property
		protected Guid _metaPartnerPhoneID = MOD.Data.DefaultValue.Guid;
		// for PhoneNumber read only property
		[DataTransform]
		protected string _phoneNumber = MOD.Data.DefaultValue.String;
		// for MetaPartnerPhone property
		protected BLL.Customers.MetaPartnerPhone _metaPartnerPhone = null;
		#endregion Fields
		#region Properties
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the Balance.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValue(typeof(decimal),"0")]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual decimal Balance
		{
			get
			{
				return _balance;
			}
			set
			{
				if (_balance != value)
				{
					_balance = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the MetaPartnerPhoneID.</summary>
		// ------------------------------------------------------------------------------
		[XmlElementAttribute()]
		[DataTransform]
		public virtual Guid MetaPartnerPhoneID
		{
			get
			{
				return _metaPartnerPhoneID;
			}
			set
			{
				if (_metaPartnerPhoneID != value)
				{
					_metaPartnerPhoneID = value;
					_metaPartnerPhone = null;
					// reset MetaPartnerPhone
					BLL.PersistedBusinessObject vMetaPartnerPhone = (BLL.PersistedBusinessObject) MetaPartnerPhone;
					vMetaPartnerPhone = null;
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
		/// <summary>This read only property gets the PhoneNumber.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		public virtual string PhoneNumber
		{
			get
			{
				return _phoneNumber;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of MetaPartnerPhone.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Customers.MetaPartnerPhone MetaPartnerPhone
		{
			get
			{
				if (_metaPartnerPhone == null  && IsLazyLoadable == true)
				{
					_metaPartnerPhone = BLL.Customers.MetaPartnerPhoneManager.GetOneMetaPartnerPhone((Guid)MetaPartnerPhoneID);
					// refresh derived properties
					if (_metaPartnerPhone != null)
					{
						_phoneNumber = _metaPartnerPhone.PhoneNumber;
					}
					else
					{
						_phoneNumber = MOD.Data.DefaultValue.String;
					}
				}
				return _metaPartnerPhone;
			}
			set
			{
				if (_metaPartnerPhone != value)
				{
					_metaPartnerPhone = value;
					_isDirty = true;
					// refresh derived properties
					if (_metaPartnerPhone != null)
					{
						_phoneNumber = _metaPartnerPhone.PhoneNumber;
					}
					else
					{
						_phoneNumber = MOD.Data.DefaultValue.String;
					}
				}
			}
		}
		#endregion Properties
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public StoredValueAccount()
		{
			//
			// constructor logic
			//
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method creates an instance with the primary key values.</summary>
		// ------------------------------------------------------------------------------
		public StoredValueAccount(string keyValues, bool isPrimaryKeyValues)
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
		/// <summary>This constructor initializes the StoredValueAccount from its DAL counterpart.</summary>
		// ------------------------------------------------------------------------------
		public StoredValueAccount(DAL.Accounts.StoredValueAccount businessObject) : base(businessObject)
		{
		}
		// ------------------------------------------------------------------------------
		/// <summary>This constructor initializes the StoredValueAccount from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public StoredValueAccount(Guid accountID)
		{
			AccountID = accountID;
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the StoredValueAccount with its already set properties.</summary>
		// ------------------------------------------------------------------------------
		public new void Load()
		{
			Load(AccountID);
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the StoredValueAccount from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public new void Load(Guid accountID)
		{
			BLL.Accounts.StoredValueAccount businessObject = null;
			businessObject = BLL.Accounts.StoredValueAccountManager.GetOneStoredValueAccount(accountID);
			if(businessObject != null)
			{
				ReflectionHelper.Copy(businessObject, this, true);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the StoredValueAccount into the database,
		/// performing add/update auto detect and performing a cascade operation if indicated.</summary>
		// ------------------------------------------------------------------------------
		public new void Save(bool performCascade)
		{
			if (IsLoaded == false)
			{
				BLL.Accounts.StoredValueAccountManager.AddOneStoredValueAccount(this, performCascade);
			}
			else
			{
				BLL.Accounts.StoredValueAccountManager.UpdateOneStoredValueAccount(this, performCascade);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the StoredValueAccount into the database,
		/// performing add/update auto detect and without performing a cascade operation.</summary>
		// ------------------------------------------------------------------------------
		public new void Save()
		{
			Save(false);
		}
		/// <summary>
		///	Clears the dirty state of StoredValueAccount and its subcollections.
		/// </summary>
		/// <param name="clearCollectionDirtyState">Flag to clear subcollections.</param>
		/// <returns></returns>
		public override void ClearDirtyState(bool clearCollectionDirtyState)
		{
			// clear base items
			base.ClearDirtyState();
			// clear collections and other items
			if (this._metaPartnerPhone != null)
			{
				this.MetaPartnerPhone.ClearDirtyState(clearCollectionDirtyState);
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
		///	Tests to see if input object is convertable to StoredValueAccount, and has the same primary key values.
		/// </summary>
		/// <param name="obj">Input object to test.</param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			StoredValueAccount storedValueAccountInstance = obj as StoredValueAccount;
			if (storedValueAccountInstance == null)
				return false;
			else
				return (_accountID == storedValueAccountInstance.AccountID);
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