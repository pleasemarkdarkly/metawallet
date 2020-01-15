
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
	/// <summary>This class is used to hold and manage information for FundAccount instances.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[Serializable()]
	[DataTransform(Name = "MW.MComm.WalletSolution.DAL.Accounts.FundAccount")]
	public partial class FundAccount : BLL.Accounts.Account
	{
		#region Constants
		#endregion Constants
		#region Fields
		// for StartDate property
		protected DateTime _startDate = MOD.Data.DefaultValue.DateTime;
		// for EndDate property
		protected DateTime _endDate = MOD.Data.DefaultValue.DateTime;
		// for FundCode property
		protected string _fundCode = null;
		// for TargetAmount property
		protected decimal _targetAmount = MOD.Data.DefaultValue.Decimal;
		// for MinimumDonationAmount property
		protected decimal _minimumDonationAmount = MOD.Data.DefaultValue.Decimal;
		// for MaximumDonationAmount property
		protected decimal _maximumDonationAmount = MOD.Data.DefaultValue.Decimal;
		// for DonatedAmount property
		protected decimal _donatedAmount = MOD.Data.DefaultValue.Decimal;
		// for IsPublic property
		protected bool _isPublic = false;
		// for FundAccountTypeCode property
		protected int _fundAccountTypeCode = MOD.Data.DefaultValue.Int;
		// for FrequencyCode property
		protected int _frequencyCode = MOD.Data.DefaultValue.Int;
		// for FundAccountTypeName read only property
		[DataTransform]
		protected string _fundAccountTypeName = MOD.Data.DefaultValue.String;
		// for FrequencyName read only property
		[DataTransform]
		protected string _frequencyName = MOD.Data.DefaultValue.String;
		// for Frequency property
		protected BLL.Accounts.Frequency _frequency = null;
		// for FundAccountType property
		protected BLL.Accounts.FundAccountType _fundAccountType = null;
		#endregion Fields
		#region Properties
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the StartDate.</summary>
		// ------------------------------------------------------------------------------
		[XmlElementAttribute()]
		[DataTransform]
		public virtual DateTime StartDate
		{
			get
			{
				return _startDate;
			}
			set
			{
				if (_startDate != value)
				{
					_startDate = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the EndDate.</summary>
		// ------------------------------------------------------------------------------
		[XmlElementAttribute()]
		[DataTransform]
		public virtual DateTime EndDate
		{
			get
			{
				return _endDate;
			}
			set
			{
				if (_endDate != value)
				{
					_endDate = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the FundCode.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(null)]
		[XmlElementAttribute(IsNullable=true)]
		[DataTransform]
		public virtual string FundCode
		{
			get
			{
				return _fundCode;
			}
			set
			{
				if ((_fundCode != null && !_fundCode.Equals(value)) || _fundCode != value)
				{
					_fundCode = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the TargetAmount.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValue(typeof(decimal),"0")]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual decimal TargetAmount
		{
			get
			{
				return _targetAmount;
			}
			set
			{
				if (_targetAmount != value)
				{
					_targetAmount = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the MinimumDonationAmount.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValue(typeof(decimal),"0")]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual decimal MinimumDonationAmount
		{
			get
			{
				return _minimumDonationAmount;
			}
			set
			{
				if (_minimumDonationAmount != value)
				{
					_minimumDonationAmount = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the MaximumDonationAmount.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValue(typeof(decimal),"0")]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual decimal MaximumDonationAmount
		{
			get
			{
				return _maximumDonationAmount;
			}
			set
			{
				if (_maximumDonationAmount != value)
				{
					_maximumDonationAmount = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the DonatedAmount.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValue(typeof(decimal),"0")]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual decimal DonatedAmount
		{
			get
			{
				return _donatedAmount;
			}
			set
			{
				if (_donatedAmount != value)
				{
					_donatedAmount = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the IsPublic.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Bool)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual bool IsPublic
		{
			get
			{
				return _isPublic;
			}
			set
			{
				if (_isPublic != value)
				{
					_isPublic = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the FundAccountTypeCode.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Int)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual int FundAccountTypeCode
		{
			get
			{
				return _fundAccountTypeCode;
			}
			set
			{
				if (_fundAccountTypeCode != value)
				{
					_fundAccountTypeCode = value;
					_fundAccountType = null;
					// reset FundAccountType
					BLL.PersistedBusinessObject vFundAccountType = (BLL.PersistedBusinessObject) FundAccountType;
					vFundAccountType = null;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the FrequencyCode.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Int)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual int FrequencyCode
		{
			get
			{
				return _frequencyCode;
			}
			set
			{
				if (_frequencyCode != value)
				{
					_frequencyCode = value;
					_frequency = null;
					// reset Frequency
					BLL.PersistedBusinessObject vFrequency = (BLL.PersistedBusinessObject) Frequency;
					vFrequency = null;
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
		/// <summary>This read only property gets the FundAccountTypeName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		public virtual string FundAccountTypeName
		{
			get
			{
				return _fundAccountTypeName;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This read only property gets the FrequencyName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		public virtual string FrequencyName
		{
			get
			{
				return _frequencyName;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of Frequency.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Accounts.Frequency Frequency
		{
			get
			{
				if (_frequency == null  && IsLazyLoadable == true)
				{
					_frequency = BLL.Accounts.FrequencyManager.GetOneFrequency((int)FrequencyCode);
					// refresh derived properties
					if (_frequency != null)
					{
						_frequencyName = _frequency.FrequencyName;
					}
					else
					{
						_frequencyName = MOD.Data.DefaultValue.String;
					}
				}
				return _frequency;
			}
			set
			{
				if (_frequency != value)
				{
					_frequency = value;
					_isDirty = true;
					// refresh derived properties
					if (_frequency != null)
					{
						_frequencyName = _frequency.FrequencyName;
					}
					else
					{
						_frequencyName = MOD.Data.DefaultValue.String;
					}
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of FundAccountType.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Accounts.FundAccountType FundAccountType
		{
			get
			{
				if (_fundAccountType == null  && IsLazyLoadable == true)
				{
					_fundAccountType = BLL.Accounts.FundAccountTypeManager.GetOneFundAccountType((int)FundAccountTypeCode);
					// refresh derived properties
					if (_fundAccountType != null)
					{
						_fundAccountTypeName = _fundAccountType.FundAccountTypeName;
					}
					else
					{
						_fundAccountTypeName = MOD.Data.DefaultValue.String;
					}
				}
				return _fundAccountType;
			}
			set
			{
				if (_fundAccountType != value)
				{
					_fundAccountType = value;
					_isDirty = true;
					// refresh derived properties
					if (_fundAccountType != null)
					{
						_fundAccountTypeName = _fundAccountType.FundAccountTypeName;
					}
					else
					{
						_fundAccountTypeName = MOD.Data.DefaultValue.String;
					}
				}
			}
		}
		#endregion Properties
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public FundAccount()
		{
			//
			// constructor logic
			//
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method creates an instance with the primary key values.</summary>
		// ------------------------------------------------------------------------------
		public FundAccount(string keyValues, bool isPrimaryKeyValues)
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
		/// <summary>This constructor initializes the FundAccount from its DAL counterpart.</summary>
		// ------------------------------------------------------------------------------
		public FundAccount(DAL.Accounts.FundAccount businessObject) : base(businessObject)
		{
		}
		// ------------------------------------------------------------------------------
		/// <summary>This constructor initializes the FundAccount from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public FundAccount(Guid accountID)
		{
			AccountID = accountID;
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the FundAccount with its already set properties.</summary>
		// ------------------------------------------------------------------------------
		public new void Load()
		{
			Load(AccountID);
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the FundAccount from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public new void Load(Guid accountID)
		{
			BLL.Accounts.FundAccount businessObject = null;
			businessObject = BLL.Accounts.FundAccountManager.GetOneFundAccount(accountID);
			if(businessObject != null)
			{
				ReflectionHelper.Copy(businessObject, this, true);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the FundAccount into the database,
		/// performing add/update auto detect and performing a cascade operation if indicated.</summary>
		// ------------------------------------------------------------------------------
		public new void Save(bool performCascade)
		{
			if (IsLoaded == false)
			{
				BLL.Accounts.FundAccountManager.AddOneFundAccount(this, performCascade);
			}
			else
			{
				BLL.Accounts.FundAccountManager.UpdateOneFundAccount(this, performCascade);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the FundAccount into the database,
		/// performing add/update auto detect and without performing a cascade operation.</summary>
		// ------------------------------------------------------------------------------
		public new void Save()
		{
			Save(false);
		}
		/// <summary>
		///	Clears the dirty state of FundAccount and its subcollections.
		/// </summary>
		/// <param name="clearCollectionDirtyState">Flag to clear subcollections.</param>
		/// <returns></returns>
		public override void ClearDirtyState(bool clearCollectionDirtyState)
		{
			// clear base items
			base.ClearDirtyState();
			// clear collections and other items
			if (this._frequency != null)
			{
				this.Frequency.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._fundAccountType != null)
			{
				this.FundAccountType.ClearDirtyState(clearCollectionDirtyState);
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
		///	Tests to see if input object is convertable to FundAccount, and has the same primary key values.
		/// </summary>
		/// <param name="obj">Input object to test.</param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			FundAccount fundAccountInstance = obj as FundAccount;
			if (fundAccountInstance == null)
				return false;
			else
				return (_accountID == fundAccountInstance.AccountID);
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