
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
	/// <summary>This class is used to hold and manage information for PromotionCoupon instances.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[Serializable()]
	[DataTransform(Name = "MW.MComm.WalletSolution.DAL.Promotions.PromotionCoupon")]
	public partial class PromotionCoupon : PersistedBusinessObject
	{
		#region Constants
		#endregion Constants
		#region Fields
		// for PromotionCode property
		protected int _promotionCode = MOD.Data.DefaultValue.Int;
		// for CouponCode property
		protected int _couponCode = MOD.Data.DefaultValue.Int;
		// for Rank property
		protected int _rank = 0;
		// for PromotionName read only property
		[DataTransform]
		protected string _promotionName = MOD.Data.DefaultValue.String;
		// for StartDate read only property
		[DataTransform]
		protected DateTime _startDate = MOD.Data.DefaultValue.DateTime;
		// for EndDate read only property
		[DataTransform]
		protected DateTime _endDate = MOD.Data.DefaultValue.DateTime;
		// for CouponName read only property
		[DataTransform]
		protected string _couponName = MOD.Data.DefaultValue.String;
		// for Coupon property
		protected BLL.Promotions.Coupon _coupon = null;
		// for Promotion property
		protected BLL.Promotions.Promotion _promotion = null;
		#endregion Fields
		#region Properties
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the PromotionCode.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Int)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual int PromotionCode
		{
			get
			{
				return _promotionCode;
			}
			set
			{
				if (_promotionCode != value)
				{
					_promotionCode = value;
					_promotion = null;
					// reset Promotion
					BLL.PersistedBusinessObject vPromotion = (BLL.PersistedBusinessObject) Promotion;
					vPromotion = null;
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
		/// <summary>This property gets or sets the Rank.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Int)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual int Rank
		{
			get
			{
				return _rank;
			}
			set
			{
				if (_rank != value)
				{
					_rank = value;
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
				return (MOD.Data.DataHelper.GetString(PromotionCode,"") + ", " + MOD.Data.DataHelper.GetString(CouponCode,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					PromotionCode = MOD.Data.DataHelper.GetInt(keyValues[0], MOD.Data.DefaultValue.Int);
				}
				if (keyValues.Length > 1)
				{
					CouponCode = MOD.Data.DataHelper.GetInt(keyValues[1], MOD.Data.DefaultValue.Int);
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
					return PromotionName;
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
				return (MOD.Data.DataHelper.GetString(PromotionCode,"") + ", " + MOD.Data.DataHelper.GetString(CouponCode,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					PromotionCode = MOD.Data.DataHelper.GetInt(keyValues[0], MOD.Data.DefaultValue.Int);
				}
				if (keyValues.Length > 1)
				{
					CouponCode = MOD.Data.DataHelper.GetInt(keyValues[1], MOD.Data.DefaultValue.Int);
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
					return "PromotionName";
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
		/// <summary>This read only property gets the PromotionName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		public virtual string PromotionName
		{
			get
			{
				return _promotionName;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This read only property gets the StartDate.</summary>
		// ------------------------------------------------------------------------------
		[XmlElementAttribute()]
		public virtual DateTime StartDate
		{
			get
			{
				return _startDate;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This read only property gets the EndDate.</summary>
		// ------------------------------------------------------------------------------
		[XmlElementAttribute()]
		public virtual DateTime EndDate
		{
			get
			{
				return _endDate;
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
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of Promotion.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Promotions.Promotion Promotion
		{
			get
			{
				if (_promotion == null  && IsLazyLoadable == true)
				{
					_promotion = BLL.Promotions.PromotionManager.GetOnePromotion((int)PromotionCode);
					// refresh derived properties
					if (_promotion != null)
					{
						_promotionName = _promotion.PromotionName;
						_startDate = _promotion.StartDate;
						_endDate = _promotion.EndDate;
					}
					else
					{
						_promotionName = MOD.Data.DefaultValue.String;
						_startDate = MOD.Data.DefaultValue.DateTime;
						_endDate = MOD.Data.DefaultValue.DateTime;
					}
				}
				return _promotion;
			}
			set
			{
				if (_promotion != value)
				{
					_promotion = value;
					_isDirty = true;
					// refresh derived properties
					if (_promotion != null)
					{
						_promotionName = _promotion.PromotionName;
						_startDate = _promotion.StartDate;
						_endDate = _promotion.EndDate;
					}
					else
					{
						_promotionName = MOD.Data.DefaultValue.String;
						_startDate = MOD.Data.DefaultValue.DateTime;
						_endDate = MOD.Data.DefaultValue.DateTime;
					}
				}
			}
		}
		#endregion Properties
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public PromotionCoupon()
		{
			//
			// constructor logic
			//
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method creates an instance with the primary key values.</summary>
		// ------------------------------------------------------------------------------
		public PromotionCoupon(string keyValues, bool isPrimaryKeyValues)
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
		/// <summary>This constructor initializes the PromotionCoupon from its DAL counterpart.</summary>
		// ------------------------------------------------------------------------------
		public PromotionCoupon(DAL.Promotions.PromotionCoupon businessObject) : base(businessObject)
		{
		}
		// ------------------------------------------------------------------------------
		/// <summary>This constructor initializes the PromotionCoupon from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public PromotionCoupon(int promotionCode, int couponCode)
		{
			PromotionCode = promotionCode;
			CouponCode = couponCode;
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the PromotionCoupon with its already set properties.</summary>
		// ------------------------------------------------------------------------------
		public void Load()
		{
			Load(PromotionCode, CouponCode);
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the PromotionCoupon from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public void Load(int promotionCode, int couponCode)
		{
			BLL.Promotions.PromotionCoupon businessObject = null;
			businessObject = BLL.Promotions.PromotionCouponManager.GetOnePromotionCoupon(promotionCode, couponCode);
			if(businessObject != null)
			{
				ReflectionHelper.Copy(businessObject, this, true);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the PromotionCoupon into the database,
		/// performing add/update auto detect and performing a cascade operation if indicated.</summary>
		// ------------------------------------------------------------------------------
		public void Save(bool performCascade)
		{
			if (IsLoaded == false)
			{
				BLL.Promotions.PromotionCouponManager.AddOnePromotionCoupon(this, performCascade);
			}
			else
			{
				BLL.Promotions.PromotionCouponManager.UpdateOnePromotionCoupon(this, performCascade);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the PromotionCoupon into the database,
		/// performing add/update auto detect and without performing a cascade operation.</summary>
		// ------------------------------------------------------------------------------
		public void Save()
		{
			Save(false);
		}
		/// <summary>
		///	Clears the dirty state of PromotionCoupon and its subcollections.
		/// </summary>
		/// <param name="clearCollectionDirtyState">Flag to clear subcollections.</param>
		/// <returns></returns>
		public override void ClearDirtyState(bool clearCollectionDirtyState)
		{
			// clear base items
			base.ClearDirtyState();
			// clear collections and other items
			if (this._coupon != null)
			{
				this.Coupon.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._promotion != null)
			{
				this.Promotion.ClearDirtyState(clearCollectionDirtyState);
			}
		}
		/// <summary>
		///	Tests to see if input object is convertable to PromotionCoupon, and has the same primary key values.
		/// </summary>
		/// <param name="obj">Input object to test.</param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			PromotionCoupon promotionCouponInstance = obj as PromotionCoupon;
			if (promotionCouponInstance == null)
				return false;
			else
				return (_promotionCode == promotionCouponInstance.PromotionCode && 
					_couponCode == promotionCouponInstance.CouponCode);
		}
		/// <summary>
		///	Returns unique identifying integer		 
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return (_promotionCode.ToString() + _couponCode.ToString()).GetHashCode();
		}
		#endregion Methods
	}
}