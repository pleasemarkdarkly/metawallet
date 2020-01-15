
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
	/// <summary>This class is used to hold and manage information for Promotion instances.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[Serializable()]
	[DataTransform(Name = "MW.MComm.WalletSolution.DAL.Promotions.Promotion")]
	public partial class Promotion : PersistedBusinessObject
	{
		#region Constants
		#endregion Constants
		#region Fields
		// for PromotionCode property
		protected int _promotionCode = MOD.Data.DefaultValue.Int;
		// for PromotionName property
		protected string _promotionName = MOD.Data.DefaultValue.String;
		// for PromotionText property
		protected string _promotionText = MOD.Data.DefaultValue.String;
		// for PromotionTypeCode property
		protected int _promotionTypeCode = MOD.Data.DefaultValue.Int;
		// for StartDate property
		protected DateTime _startDate = MOD.Data.DefaultValue.DateTime;
		// for EndDate property
		protected DateTime _endDate = MOD.Data.DefaultValue.DateTime;
		// for Description property
		protected string _description = null;
		// for IsActive property
		protected bool _isActive = false;
		// for PromotionTypeName read only property
		[DataTransform]
		protected string _promotionTypeName = MOD.Data.DefaultValue.String;
		// for PromotionCouponList property
		protected BLL.SortableList<BLL.Promotions.PromotionCoupon> _promotionCouponList = null;
		// for PromotionType property
		protected BLL.Promotions.PromotionType _promotionType = null;
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
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the PromotionName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual string PromotionName
		{
			get
			{
				return _promotionName;
			}
			set
			{
				if ((_promotionName != null && !_promotionName.Equals(value)) || _promotionName != value)
				{
					_promotionName = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the PromotionText.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual string PromotionText
		{
			get
			{
				return _promotionText;
			}
			set
			{
				if ((_promotionText != null && !_promotionText.Equals(value)) || _promotionText != value)
				{
					_promotionText = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the PromotionTypeCode.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Int)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual int PromotionTypeCode
		{
			get
			{
				return _promotionTypeCode;
			}
			set
			{
				if (_promotionTypeCode != value)
				{
					_promotionTypeCode = value;
					_promotionType = null;
					// reset PromotionType
					BLL.PersistedBusinessObject vPromotionType = (BLL.PersistedBusinessObject) PromotionType;
					vPromotionType = null;
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
				return (MOD.Data.DataHelper.GetString(PromotionCode,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					PromotionCode = MOD.Data.DataHelper.GetInt(keyValues[0], MOD.Data.DefaultValue.Int);
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
				return (MOD.Data.DataHelper.GetString(PromotionCode,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					PromotionCode = MOD.Data.DataHelper.GetInt(keyValues[0], MOD.Data.DefaultValue.Int);
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
				return ((_promotionCouponList != null && _promotionCouponList.IsDirty) ||
				base.IsCollectionDirty);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This read only property gets the PromotionTypeName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		public virtual string PromotionTypeName
		{
			get
			{
				return _promotionTypeName;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets PromotionCoupon lists.</summary>
		// ------------------------------------------------------------------------------
		[XmlArrayItem(typeof(BLL.Promotions.PromotionCoupon), ElementName="PromotionCoupon")]
		[DataTransform]
		public virtual BLL.SortableList<BLL.Promotions.PromotionCoupon> PromotionCouponList
		{
			get
			{
				if (_promotionCouponList == null && IsLazyLoadable == true)
				{
					_promotionCouponList = BLL.Promotions.PromotionCouponManager.GetAllPromotionCouponDataByPromotionCode(PromotionCode);
				}
				else if (_promotionCouponList == null)
				{
					_promotionCouponList = new BLL.SortableList<BLL.Promotions.PromotionCoupon>();
				}
				return _promotionCouponList;
			}
			set
			{
				if (value == null)
				{
					_promotionCouponList = value;
				}
				else if ((_promotionCouponList == null && value != null) ||
					  !_promotionCouponList.Equals(value))
				{
					_promotionCouponList = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of PromotionType.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Promotions.PromotionType PromotionType
		{
			get
			{
				if (_promotionType == null  && IsLazyLoadable == true)
				{
					_promotionType = BLL.Promotions.PromotionTypeManager.GetOnePromotionType((int)PromotionTypeCode);
					// refresh derived properties
					if (_promotionType != null)
					{
						_promotionTypeName = _promotionType.PromotionTypeName;
					}
					else
					{
						_promotionTypeName = MOD.Data.DefaultValue.String;
					}
				}
				return _promotionType;
			}
			set
			{
				if (_promotionType != value)
				{
					_promotionType = value;
					_isDirty = true;
					// refresh derived properties
					if (_promotionType != null)
					{
						_promotionTypeName = _promotionType.PromotionTypeName;
					}
					else
					{
						_promotionTypeName = MOD.Data.DefaultValue.String;
					}
				}
			}
		}
		#endregion Properties
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public Promotion()
		{
			//
			// constructor logic
			//
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method creates an instance with the primary key values.</summary>
		// ------------------------------------------------------------------------------
		public Promotion(string keyValues, bool isPrimaryKeyValues)
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
		/// <summary>This constructor initializes the Promotion from its DAL counterpart.</summary>
		// ------------------------------------------------------------------------------
		public Promotion(DAL.Promotions.Promotion businessObject) : base(businessObject)
		{
		}
		// ------------------------------------------------------------------------------
		/// <summary>This constructor initializes the Promotion from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public Promotion(int promotionCode)
		{
			PromotionCode = promotionCode;
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the Promotion with its already set properties.</summary>
		// ------------------------------------------------------------------------------
		public void Load()
		{
			Load(PromotionCode);
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the Promotion from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public void Load(int promotionCode)
		{
			BLL.Promotions.Promotion businessObject = null;
			businessObject = BLL.Promotions.PromotionManager.GetOnePromotion(promotionCode);
			if(businessObject != null)
			{
				ReflectionHelper.Copy(businessObject, this, true);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the Promotion into the database,
		/// performing add/update auto detect and performing a cascade operation if indicated.</summary>
		// ------------------------------------------------------------------------------
		public void Save(bool performCascade)
		{
			if (IsLoaded == false)
			{
				BLL.Promotions.PromotionManager.AddOnePromotion(this, performCascade);
			}
			else
			{
				BLL.Promotions.PromotionManager.UpdateOnePromotion(this, performCascade);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the Promotion into the database,
		/// performing add/update auto detect and without performing a cascade operation.</summary>
		// ------------------------------------------------------------------------------
		public void Save()
		{
			Save(false);
		}
		/// <summary>
		///	Clears the dirty state of Promotion and its subcollections.
		/// </summary>
		/// <param name="clearCollectionDirtyState">Flag to clear subcollections.</param>
		/// <returns></returns>
		public override void ClearDirtyState(bool clearCollectionDirtyState)
		{
			// clear base items
			base.ClearDirtyState();
			// clear collections and other items
			if (this._promotionCouponList != null)
			{
				this.PromotionCouponList.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._promotionType != null)
			{
				this.PromotionType.ClearDirtyState(clearCollectionDirtyState);
			}
		}
		/// <summary>
		///	Tests to see if input object is convertable to Promotion, and has the same primary key values.
		/// </summary>
		/// <param name="obj">Input object to test.</param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			Promotion promotionInstance = obj as Promotion;
			if (promotionInstance == null)
				return false;
			else
				return (_promotionCode == promotionInstance.PromotionCode);
		}
		/// <summary>
		///	Returns unique identifying integer		 
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return (_promotionCode.ToString()).GetHashCode();
		}
		#endregion Methods
	}
}