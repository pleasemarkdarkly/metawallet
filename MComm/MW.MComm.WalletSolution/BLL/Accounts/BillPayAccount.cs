
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
	/// <summary>This class is used to hold and manage information for BillPayAccount instances.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[Serializable()]
	[DataTransform(Name = "MW.MComm.WalletSolution.DAL.Accounts.BillPayAccount")]
	public partial class BillPayAccount : BLL.Accounts.Account
	{
		#region Constants
		#endregion Constants
		#region Fields
		// for BusinessAccountNumber property
		protected string _businessAccountNumber = MOD.Data.DefaultValue.String;
		// for StartDate property
		protected DateTime _startDate = MOD.Data.DefaultValue.DateTime;
		// for EndDate property
		protected DateTime _endDate = MOD.Data.DefaultValue.DateTime;
		// for DefaultMinimumPayment property
		protected decimal _defaultMinimumPayment = MOD.Data.DefaultValue.Decimal;
		// for DefaultMaximumPayment property
		protected decimal _defaultMaximumPayment = MOD.Data.DefaultValue.Decimal;
		// for BusinessMetaPartnerID property
		protected Guid _businessMetaPartnerID = MOD.Data.DefaultValue.Guid;
		// for HourOfDay property
		protected int _hourOfDay = MOD.Data.DefaultValue.Int;
		// for DayOfWeek property
		protected int _dayOfWeek = MOD.Data.DefaultValue.Int;
		// for WeekOfMonth property
		protected int _weekOfMonth = MOD.Data.DefaultValue.Int;
		// for MonthOfYear property
		protected int _monthOfYear = MOD.Data.DefaultValue.Int;
		// for NumberOfReminders property
		protected int _numberOfReminders = MOD.Data.DefaultValue.Int;
		// for FrequencyCode property
		protected int _frequencyCode = MOD.Data.DefaultValue.Int;
		// for FrequencyName read only property
		[DataTransform]
		protected string _frequencyName = MOD.Data.DefaultValue.String;
		// for Business property
		protected BLL.Customers.Business _business = null;
		// for Frequency property
		protected BLL.Accounts.Frequency _frequency = null;
		#endregion Fields
		#region Properties
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the BusinessAccountNumber.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual string BusinessAccountNumber
		{
			get
			{
				return _businessAccountNumber;
			}
			set
			{
				if ((_businessAccountNumber != null && !_businessAccountNumber.Equals(value)) || _businessAccountNumber != value)
				{
					_businessAccountNumber = value;
					_isDirty = true;
				}
			}
		}
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
		/// <summary>This property gets or sets the DefaultMinimumPayment.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValue(typeof(decimal),"0")]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual decimal DefaultMinimumPayment
		{
			get
			{
				return _defaultMinimumPayment;
			}
			set
			{
				if (_defaultMinimumPayment != value)
				{
					_defaultMinimumPayment = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the DefaultMaximumPayment.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValue(typeof(decimal),"0")]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual decimal DefaultMaximumPayment
		{
			get
			{
				return _defaultMaximumPayment;
			}
			set
			{
				if (_defaultMaximumPayment != value)
				{
					_defaultMaximumPayment = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the BusinessMetaPartnerID.</summary>
		// ------------------------------------------------------------------------------
		[XmlElementAttribute()]
		[DataTransform]
		public virtual Guid BusinessMetaPartnerID
		{
			get
			{
				return _businessMetaPartnerID;
			}
			set
			{
				if (_businessMetaPartnerID != value)
				{
					_businessMetaPartnerID = value;
					_business = null;
					// reset Business
					BLL.PersistedBusinessObject vBusiness = (BLL.PersistedBusinessObject) Business;
					vBusiness = null;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the HourOfDay.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Int)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual int HourOfDay
		{
			get
			{
				return _hourOfDay;
			}
			set
			{
				if (_hourOfDay != value)
				{
					_hourOfDay = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the DayOfWeek.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Int)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual int DayOfWeek
		{
			get
			{
				return _dayOfWeek;
			}
			set
			{
				if (_dayOfWeek != value)
				{
					_dayOfWeek = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the WeekOfMonth.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Int)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual int WeekOfMonth
		{
			get
			{
				return _weekOfMonth;
			}
			set
			{
				if (_weekOfMonth != value)
				{
					_weekOfMonth = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the MonthOfYear.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Int)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual int MonthOfYear
		{
			get
			{
				return _monthOfYear;
			}
			set
			{
				if (_monthOfYear != value)
				{
					_monthOfYear = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the NumberOfReminders.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Int)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual int NumberOfReminders
		{
			get
			{
				return _numberOfReminders;
			}
			set
			{
				if (_numberOfReminders != value)
				{
					_numberOfReminders = value;
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
		/// <summary>This property gets or sets an item of Business.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Customers.Business Business
		{
			get
			{
				if (_business == null  && IsLazyLoadable == true)
				{
					_business = BLL.Customers.BusinessManager.GetOneBusiness((Guid)BusinessMetaPartnerID);
					// refresh derived properties
					if (_business != null)
					{
					}
					else
					{
					}
				}
				return _business;
			}
			set
			{
				if (_business != value)
				{
					_business = value;
					_isDirty = true;
					// refresh derived properties
					if (_business != null)
					{
					}
					else
					{
					}
				}
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
		#endregion Properties
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public BillPayAccount()
		{
			//
			// constructor logic
			//
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method creates an instance with the primary key values.</summary>
		// ------------------------------------------------------------------------------
		public BillPayAccount(string keyValues, bool isPrimaryKeyValues)
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
		/// <summary>This constructor initializes the BillPayAccount from its DAL counterpart.</summary>
		// ------------------------------------------------------------------------------
		public BillPayAccount(DAL.Accounts.BillPayAccount businessObject) : base(businessObject)
		{
		}
		// ------------------------------------------------------------------------------
		/// <summary>This constructor initializes the BillPayAccount from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public BillPayAccount(Guid accountID)
		{
			AccountID = accountID;
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the BillPayAccount with its already set properties.</summary>
		// ------------------------------------------------------------------------------
		public new void Load()
		{
			Load(AccountID);
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the BillPayAccount from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public new void Load(Guid accountID)
		{
			BLL.Accounts.BillPayAccount businessObject = null;
			businessObject = BLL.Accounts.BillPayAccountManager.GetOneBillPayAccount(accountID);
			if(businessObject != null)
			{
				ReflectionHelper.Copy(businessObject, this, true);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the BillPayAccount into the database,
		/// performing add/update auto detect and performing a cascade operation if indicated.</summary>
		// ------------------------------------------------------------------------------
		public new void Save(bool performCascade)
		{
			if (IsLoaded == false)
			{
				BLL.Accounts.BillPayAccountManager.AddOneBillPayAccount(this, performCascade);
			}
			else
			{
				BLL.Accounts.BillPayAccountManager.UpdateOneBillPayAccount(this, performCascade);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the BillPayAccount into the database,
		/// performing add/update auto detect and without performing a cascade operation.</summary>
		// ------------------------------------------------------------------------------
		public new void Save()
		{
			Save(false);
		}
		/// <summary>
		///	Clears the dirty state of BillPayAccount and its subcollections.
		/// </summary>
		/// <param name="clearCollectionDirtyState">Flag to clear subcollections.</param>
		/// <returns></returns>
		public override void ClearDirtyState(bool clearCollectionDirtyState)
		{
			// clear base items
			base.ClearDirtyState();
			// clear collections and other items
			if (this._business != null)
			{
				this.Business.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._frequency != null)
			{
				this.Frequency.ClearDirtyState(clearCollectionDirtyState);
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
		///	Tests to see if input object is convertable to BillPayAccount, and has the same primary key values.
		/// </summary>
		/// <param name="obj">Input object to test.</param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			BillPayAccount billPayAccountInstance = obj as BillPayAccount;
			if (billPayAccountInstance == null)
				return false;
			else
				return (_accountID == billPayAccountInstance.AccountID);
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