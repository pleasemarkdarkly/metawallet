
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
namespace MW.MComm.WalletSolution.BLL.Promotions
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to hold and manage information for Coupon instances.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[Serializable()]
	[DataTransform(Name = "MW.MComm.WalletSolution.DAL.Promotions.Coupon")]
	public partial class Coupon : PersistedBusinessObject
	{
		#region Constants
		#endregion Constants
		#region Fields
		// for CouponCode property
		protected int _couponCode = MOD.Data.DefaultValue.Int;
		// for CouponName property
		protected string _couponName = MOD.Data.DefaultValue.String;
		// for CouponText property
		protected string _couponText = MOD.Data.DefaultValue.String;
		// for CouponTypeCode property
		protected int _couponTypeCode = MOD.Data.DefaultValue.Int;
		// for DiscountTypeCode property
		protected int _discountTypeCode = MOD.Data.DefaultValue.Int;
		// for DiscountAmount property
		protected decimal _discountAmount = 0;
		// for TriggerAmount property
		protected decimal _triggerAmount = 0;
		// for CurrencyCode property
		protected int _currencyCode = MOD.Data.DefaultValue.Int;
		// for DaysToExpire property
		protected int _daysToExpire = 0;
		// for IsFeeEnabled property
		protected bool _isFeeEnabled = false;
		// for IsPaymentEnabled property
		protected bool _isPaymentEnabled = false;
		// for Description property
		protected string _description = null;
		// for IsActive property
		protected bool _isActive = false;
		// for CouponTypeName read only property
		[DataTransform]
		protected string _couponTypeName = MOD.Data.DefaultValue.String;
		// for DiscountTypeName read only property
		[DataTransform]
		protected string _discountTypeName = MOD.Data.DefaultValue.String;
		// for CurrencyName read only property
		[DataTransform]
		protected string _currencyName = MOD.Data.DefaultValue.String;
		// for Currency property
		protected BLL.Accounts.Currency _currency = null;
		// for CouponType property
		protected BLL.Promotions.CouponType _couponType = null;
		// for DiscountType property
		protected BLL.Promotions.DiscountType _discountType = null;
		#endregion Fields
		#region Properties
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CouponCode.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Int)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual int CouponCode
		{
			get
			{
				return _couponCode;
			}
			set
			{
				if (_couponCode != value)
				{
					_couponCode = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CouponName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual string CouponName
		{
			get
			{
				return _couponName;
			}
			set
			{
				if ((_couponName != null && !_couponName.Equals(value)) || _couponName != value)
				{
					_couponName = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CouponText.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual string CouponText
		{
			get
			{
				return _couponText;
			}
			set
			{
				if ((_couponText != null && !_couponText.Equals(value)) || _couponText != value)
				{
					_couponText = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CouponTypeCode.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Int)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual int CouponTypeCode
		{
			get
			{
				return _couponTypeCode;
			}
			set
			{
				if (_couponTypeCode != value)
				{
					_couponTypeCode = value;
					_couponType = null;
					// reset CouponType
					BLL.PersistedBusinessObject vCouponType = (BLL.PersistedBusinessObject) CouponType;
					vCouponType = null;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the DiscountTypeCode.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Int)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual int DiscountTypeCode
		{
			get
			{
				return _discountTypeCode;
			}
			set
			{
				if (_discountTypeCode != value)
				{
					_discountTypeCode = value;
					_discountType = null;
					// reset DiscountType
					BLL.PersistedBusinessObject vDiscountType = (BLL.PersistedBusinessObject) DiscountType;
					vDiscountType = null;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the DiscountAmount.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValue(typeof(decimal),"0")]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual decimal DiscountAmount
		{
			get
			{
				return _discountAmount;
			}
			set
			{
				if (_discountAmount != value)
				{
					_discountAmount = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the TriggerAmount.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValue(typeof(decimal),"0")]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual decimal TriggerAmount
		{
			get
			{
				return _triggerAmount;
			}
			set
			{
				if (_triggerAmount != value)
				{
					_triggerAmount = value;
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
		/// <summary>This property gets or sets the DaysToExpire.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Int)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual int DaysToExpire
		{
			get
			{
				return _daysToExpire;
			}
			set
			{
				if (_daysToExpire != value)
				{
					_daysToExpire = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the IsFeeEnabled.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Bool)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual bool IsFeeEnabled
		{
			get
			{
				return _isFeeEnabled;
			}
			set
			{
				if (_isFeeEnabled != value)
				{
					_isFeeEnabled = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the IsPaymentEnabled.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Bool)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual bool IsPaymentEnabled
		{
			get
			{
				return _isPaymentEnabled;
			}
			set
			{
				if (_isPaymentEnabled != value)
				{
					_isPaymentEnabled = value;
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
				return (MOD.Data.DataHelper.GetString(CouponCode,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					CouponCode = MOD.Data.DataHelper.GetInt(keyValues[0], MOD.Data.DefaultValue.Int);
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
					return CouponName;
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
				return (MOD.Data.DataHelper.GetString(CouponCode,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					CouponCode = MOD.Data.DataHelper.GetInt(keyValues[0], MOD.Data.DefaultValue.Int);
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
					return "CouponName";
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
		/// <summary>This read only property gets the CouponTypeName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		public virtual string CouponTypeName
		{
			get
			{
				return _couponTypeName;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This read only property gets the DiscountTypeName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		public virtual string DiscountTypeName
		{
			get
			{
				return _discountTypeName;
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
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of CouponType.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Promotions.CouponType CouponType
		{
			get
			{
				if (_couponType == null  && IsLazyLoadable == true)
				{
					_couponType = BLL.Promotions.CouponTypeManager.GetOneCouponType((int)CouponTypeCode);
					// refresh derived properties
					if (_couponType != null)
					{
						_couponTypeName = _couponType.CouponTypeName;
					}
					else
					{
						_couponTypeName = MOD.Data.DefaultValue.String;
					}
				}
				return _couponType;
			}
			set
			{
				if (_couponType != value)
				{
					_couponType = value;
					_isDirty = true;
					// refresh derived properties
					if (_couponType != null)
					{
						_couponTypeName = _couponType.CouponTypeName;
					}
					else
					{
						_couponTypeName = MOD.Data.DefaultValue.String;
					}
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of DiscountType.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Promotions.DiscountType DiscountType
		{
			get
			{
				if (_discountType == null  && IsLazyLoadable == true)
				{
					_discountType = BLL.Promotions.DiscountTypeManager.GetOneDiscountType((int)DiscountTypeCode);
					// refresh derived properties
					if (_discountType != null)
					{
						_discountTypeName = _discountType.DiscountTypeName;
					}
					else
					{
						_discountTypeName = MOD.Data.DefaultValue.String;
					}
				}
				return _discountType;
			}
			set
			{
				if (_discountType != value)
				{
					_discountType = value;
					_isDirty = true;
					// refresh derived properties
					if (_discountType != null)
					{
						_discountTypeName = _discountType.DiscountTypeName;
					}
					else
					{
						_discountTypeName = MOD.Data.DefaultValue.String;
					}
				}
			}
		}
		#endregion Properties
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public Coupon()
		{
			//
			// constructor logic
			//
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method creates an instance with the primary key values.</summary>
		// ------------------------------------------------------------------------------
		public Coupon(string keyValues, bool isPrimaryKeyValues)
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
		/// <summary>This constructor initializes the Coupon from its DAL counterpart.</summary>
		// ------------------------------------------------------------------------------
		public Coupon(DAL.Promotions.Coupon businessObject) : base(businessObject)
		{
		}
		// ------------------------------------------------------------------------------
		/// <summary>This constructor initializes the Coupon from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public Coupon(int couponCode)
		{
			CouponCode = couponCode;
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the Coupon with its already set properties.</summary>
		// ------------------------------------------------------------------------------
		public void Load()
		{
			Load(CouponCode);
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the Coupon from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public void Load(int couponCode)
		{
			BLL.Promotions.Coupon businessObject = null;
			businessObject = BLL.Promotions.CouponManager.GetOneCoupon(couponCode);
			if(businessObject != null)
			{
				ReflectionHelper.Copy(businessObject, this, true);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the Coupon into the database,
		/// performing add/update auto detect and performing a cascade operation if indicated.</summary>
		// ------------------------------------------------------------------------------
		public void Save(bool performCascade)
		{
			if (IsLoaded == false)
			{
				BLL.Promotions.CouponManager.AddOneCoupon(this, performCascade);
			}
			else
			{
				BLL.Promotions.CouponManager.UpdateOneCoupon(this, performCascade);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the Coupon into the database,
		/// performing add/update auto detect and without performing a cascade operation.</summary>
		// ------------------------------------------------------------------------------
		public void Save()
		{
			Save(false);
		}
		/// <summary>
		///	Clears the dirty state of Coupon and its subcollections.
		/// </summary>
		/// <param name="clearCollectionDirtyState">Flag to clear subcollections.</param>
		/// <returns></returns>
		public override void ClearDirtyState(bool clearCollectionDirtyState)
		{
			// clear base items
			base.ClearDirtyState();
			// clear collections and other items
			if (this._currency != null)
			{
				this.Currency.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._couponType != null)
			{
				this.CouponType.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._discountType != null)
			{
				this.DiscountType.ClearDirtyState(clearCollectionDirtyState);
			}
		}
		/// <summary>
		///	Tests to see if input object is convertable to Coupon, and has the same primary key values.
		/// </summary>
		/// <param name="obj">Input object to test.</param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			Coupon couponInstance = obj as Coupon;
			if (couponInstance == null)
				return false;
			else
				return (_couponCode == couponInstance.CouponCode);
		}
		/// <summary>
		///	Returns unique identifying integer		 
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return (_couponCode.ToString()).GetHashCode();
		}
		#endregion Methods
	}
}