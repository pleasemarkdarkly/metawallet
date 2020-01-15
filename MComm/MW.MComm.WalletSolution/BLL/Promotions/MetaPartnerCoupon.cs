
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
	/// <summary>This class is used to hold and manage information for MetaPartnerCoupon instances.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[Serializable()]
	[DataTransform(Name = "MW.MComm.WalletSolution.DAL.Promotions.MetaPartnerCoupon")]
	public partial class MetaPartnerCoupon : PersistedBusinessObject
	{
		#region Constants
		#endregion Constants
		#region Fields
		// for MetaPartnerCouponID property
		protected Guid _metaPartnerCouponID = MOD.Data.DefaultValue.Guid;
		// for MetaPartnerID property
		protected Guid _metaPartnerID = MOD.Data.DefaultValue.Guid;
		// for CouponCode property
		protected int _couponCode = MOD.Data.DefaultValue.Int;
		// for OriginalAmount property
		protected decimal _originalAmount = 0;
		// for BalanceAmount property
		protected decimal _balanceAmount = 0;
		// for StartDate property
		protected DateTime _startDate = MOD.Data.DefaultValue.DateTime;
		// for EndDate property
		protected DateTime _endDate = MOD.Data.DefaultValue.DateTime;
		// for DateFormatCode read only property
		[DataTransform]
		protected int _dateFormatCode = MOD.Data.DefaultValue.Int;
		// for MetaPartnerName read only property
		[DataTransform]
		protected string _metaPartnerName = MOD.Data.DefaultValue.String;
		// for CouponName read only property
		[DataTransform]
		protected string _couponName = MOD.Data.DefaultValue.String;
		// for MetaPartner property
		protected BLL.Customers.MetaPartner _metaPartner = null;
		// for Coupon property
		protected BLL.Promotions.Coupon _coupon = null;
		#endregion Fields
		#region Properties
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the MetaPartnerCouponID.</summary>
		// ------------------------------------------------------------------------------
		[XmlElementAttribute()]
		[DataTransform]
		public virtual Guid MetaPartnerCouponID
		{
			get
			{
				return _metaPartnerCouponID;
			}
			set
			{
				if (_metaPartnerCouponID != value)
				{
					_metaPartnerCouponID = value;
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
					_coupon = null;
					// reset Coupon
					BLL.PersistedBusinessObject vCoupon = (BLL.PersistedBusinessObject) Coupon;
					vCoupon = null;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the OriginalAmount.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValue(typeof(decimal),"0")]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual decimal OriginalAmount
		{
			get
			{
				return _originalAmount;
			}
			set
			{
				if (_originalAmount != value)
				{
					_originalAmount = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the BalanceAmount.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValue(typeof(decimal),"0")]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual decimal BalanceAmount
		{
			get
			{
				return _balanceAmount;
			}
			set
			{
				if (_balanceAmount != value)
				{
					_balanceAmount = value;
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
		/// <summary>This property gets or sets the primary key.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		public string PrimaryKey
		{
			get
			{
				return (MOD.Data.DataHelper.GetString(MetaPartnerCouponID,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					MetaPartnerCouponID = MOD.Data.DataHelper.GetGuid(keyValues[0], MOD.Data.DefaultValue.Guid);
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
					return MetaPartnerName;
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
				return (MOD.Data.DataHelper.GetString(MetaPartnerCouponID,"") + ", " + MOD.Data.DataHelper.GetString(MetaPartnerID,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					MetaPartnerCouponID = MOD.Data.DataHelper.GetGuid(keyValues[0], MOD.Data.DefaultValue.Guid);
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
					return "MetaPartnerName";
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
		/// <summary>This read only property gets the CouponName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		public virtual string CouponName
		{
			get
			{
				return _couponName;
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
						_dateFormatCode = _metaPartner.DateFormatCode;
						_metaPartnerName = _metaPartner.MetaPartnerName;
					}
					else
					{
						_dateFormatCode = MOD.Data.DefaultValue.Int;
						_metaPartnerName = MOD.Data.DefaultValue.String;
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
						_dateFormatCode = _metaPartner.DateFormatCode;
						_metaPartnerName = _metaPartner.MetaPartnerName;
					}
					else
					{
						_dateFormatCode = MOD.Data.DefaultValue.Int;
						_metaPartnerName = MOD.Data.DefaultValue.String;
					}
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of Coupon.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Promotions.Coupon Coupon
		{
			get
			{
				if (_coupon == null  && IsLazyLoadable == true)
				{
					_coupon = BLL.Promotions.CouponManager.GetOneCoupon((int)CouponCode);
					// refresh derived properties
					if (_coupon != null)
					{
						_couponName = _coupon.CouponName;
					}
					else
					{
						_couponName = MOD.Data.DefaultValue.String;
					}
				}
				return _coupon;
			}
			set
			{
				if (_coupon != value)
				{
					_coupon = value;
					_isDirty = true;
					// refresh derived properties
					if (_coupon != null)
					{
						_couponName = _coupon.CouponName;
					}
					else
					{
						_couponName = MOD.Data.DefaultValue.String;
					}
				}
			}
		}
		#endregion Properties
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public MetaPartnerCoupon()
		{
			//
			// constructor logic
			//
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method creates an instance with the primary key values.</summary>
		// ------------------------------------------------------------------------------
		public MetaPartnerCoupon(string keyValues, bool isPrimaryKeyValues)
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
		/// <summary>This constructor initializes the MetaPartnerCoupon from its DAL counterpart.</summary>
		// ------------------------------------------------------------------------------
		public MetaPartnerCoupon(DAL.Promotions.MetaPartnerCoupon businessObject) : base(businessObject)
		{
		}
		// ------------------------------------------------------------------------------
		/// <summary>This constructor initializes the MetaPartnerCoupon from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public MetaPartnerCoupon(Guid metaPartnerCouponID)
		{
			MetaPartnerCouponID = metaPartnerCouponID;
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the MetaPartnerCoupon with its already set properties.</summary>
		// ------------------------------------------------------------------------------
		public void Load()
		{
			Load(MetaPartnerCouponID);
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the MetaPartnerCoupon from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public void Load(Guid metaPartnerCouponID)
		{
			BLL.Promotions.MetaPartnerCoupon businessObject = null;
			businessObject = BLL.Promotions.MetaPartnerCouponManager.GetOneMetaPartnerCoupon(metaPartnerCouponID);
			if(businessObject != null)
			{
				ReflectionHelper.Copy(businessObject, this, true);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the MetaPartnerCoupon into the database,
		/// performing add/update auto detect and performing a cascade operation if indicated.</summary>
		// ------------------------------------------------------------------------------
		public void Save(bool performCascade)
		{
			if (IsLoaded == false)
			{
				BLL.Promotions.MetaPartnerCouponManager.UpsertOneMetaPartnerCoupon(this, performCascade);
			}
			else
			{
				BLL.Promotions.MetaPartnerCouponManager.UpsertOneMetaPartnerCoupon(this, performCascade);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the MetaPartnerCoupon into the database,
		/// performing add/update auto detect and without performing a cascade operation.</summary>
		// ------------------------------------------------------------------------------
		public void Save()
		{
			Save(false);
		}
		/// <summary>
		///	Clears the dirty state of MetaPartnerCoupon and its subcollections.
		/// </summary>
		/// <param name="clearCollectionDirtyState">Flag to clear subcollections.</param>
		/// <returns></returns>
		public override void ClearDirtyState(bool clearCollectionDirtyState)
		{
			// clear base items
			base.ClearDirtyState();
			// clear collections and other items
			if (this._metaPartner != null)
			{
				this.MetaPartner.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._coupon != null)
			{
				this.Coupon.ClearDirtyState(clearCollectionDirtyState);
			}
		}
		/// <summary>
		///	Tests to see if input object is convertable to MetaPartnerCoupon, and has the same primary key values.
		/// </summary>
		/// <param name="obj">Input object to test.</param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			MetaPartnerCoupon metaPartnerCouponInstance = obj as MetaPartnerCoupon;
			if (metaPartnerCouponInstance == null)
				return false;
			else
				return (_metaPartnerCouponID == metaPartnerCouponInstance.MetaPartnerCouponID);
		}
		/// <summary>
		///	Returns unique identifying integer		 
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return (_metaPartnerCouponID.ToString()).GetHashCode();
		}
		#endregion Methods
	}
}