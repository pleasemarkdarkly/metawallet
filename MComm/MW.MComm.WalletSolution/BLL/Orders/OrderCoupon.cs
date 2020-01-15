
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
namespace MW.MComm.WalletSolution.BLL.Orders
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to hold and manage information for OrderCoupon instances.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[Serializable()]
	[DataTransform(Name = "MW.MComm.WalletSolution.DAL.Orders.OrderCoupon")]
	public partial class OrderCoupon : PersistedBusinessObject
	{
		#region Constants
		#endregion Constants
		#region Fields
		// for OrderID property
		protected Guid _orderID = MOD.Data.DefaultValue.Guid;
		// for MetaPartnerCouponID property
		protected Guid _metaPartnerCouponID = MOD.Data.DefaultValue.Guid;
		// for DebitMetaPartnerID property
		protected Guid _debitMetaPartnerID = MOD.Data.DefaultValue.Guid;
		// for StartDate read only property
		[DataTransform]
		protected DateTime _startDate = MOD.Data.DefaultValue.DateTime;
		// for EndDate read only property
		[DataTransform]
		protected DateTime _endDate = MOD.Data.DefaultValue.DateTime;
		// for Order property
		protected BLL.Orders.Order _order = null;
		// for MetaPartnerCoupon property
		protected BLL.Promotions.MetaPartnerCoupon _metaPartnerCoupon = null;
		#endregion Fields
		#region Properties
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the OrderID.</summary>
		// ------------------------------------------------------------------------------
		[XmlElementAttribute()]
		[DataTransform]
		public virtual Guid OrderID
		{
			get
			{
				return _orderID;
			}
			set
			{
				if (_orderID != value)
				{
					_orderID = value;
					_order = null;
					// reset Order
					BLL.PersistedBusinessObject vOrder = (BLL.PersistedBusinessObject) Order;
					vOrder = null;
					_isDirty = true;
				}
			}
		}
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
					_metaPartnerCoupon = null;
					// reset MetaPartnerCoupon
					BLL.PersistedBusinessObject vMetaPartnerCoupon = (BLL.PersistedBusinessObject) MetaPartnerCoupon;
					vMetaPartnerCoupon = null;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the DebitMetaPartnerID.</summary>
		// ------------------------------------------------------------------------------
		[XmlElementAttribute()]
		[DataTransform]
		public virtual Guid DebitMetaPartnerID
		{
			get
			{
				return _debitMetaPartnerID;
			}
			set
			{
				if (_debitMetaPartnerID != value)
				{
					_debitMetaPartnerID = value;
					_order = null;
					// reset Order
					BLL.PersistedBusinessObject vOrder = (BLL.PersistedBusinessObject) Order;
					vOrder = null;
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
				return (MOD.Data.DataHelper.GetString(OrderID,"") + ", " + MOD.Data.DataHelper.GetString(MetaPartnerCouponID,"") + ", " + MOD.Data.DataHelper.GetString(DebitMetaPartnerID,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					OrderID = MOD.Data.DataHelper.GetGuid(keyValues[0], MOD.Data.DefaultValue.Guid);
				}
				if (keyValues.Length > 1)
				{
					MetaPartnerCouponID = MOD.Data.DataHelper.GetGuid(keyValues[1], MOD.Data.DefaultValue.Guid);
				}
				if (keyValues.Length > 2)
				{
					DebitMetaPartnerID = MOD.Data.DataHelper.GetGuid(keyValues[2], MOD.Data.DefaultValue.Guid);
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
					return PrimaryKey;
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
				return (MOD.Data.DataHelper.GetString(OrderID,"") + ", " + MOD.Data.DataHelper.GetString(MetaPartnerCouponID,"") + ", " + MOD.Data.DataHelper.GetString(DebitMetaPartnerID,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					OrderID = MOD.Data.DataHelper.GetGuid(keyValues[0], MOD.Data.DefaultValue.Guid);
				}
				if (keyValues.Length > 1)
				{
					MetaPartnerCouponID = MOD.Data.DataHelper.GetGuid(keyValues[1], MOD.Data.DefaultValue.Guid);
				}
				if (keyValues.Length > 2)
				{
					DebitMetaPartnerID = MOD.Data.DataHelper.GetGuid(keyValues[2], MOD.Data.DefaultValue.Guid);
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
					return "_primarySortColumn";
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
		/// <summary>This property gets or sets an item of Order.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Orders.Order Order
		{
			get
			{
				if (_order == null  && IsLazyLoadable == true)
				{
					_order = BLL.Orders.OrderManager.GetOneOrder((Guid)OrderID);
					// refresh derived properties
					if (_order != null)
					{
					}
					else
					{
					}
				}
				return _order;
			}
			set
			{
				if (_order != value)
				{
					_order = value;
					_isDirty = true;
					// refresh derived properties
					if (_order != null)
					{
					}
					else
					{
					}
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of MetaPartnerCoupon.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Promotions.MetaPartnerCoupon MetaPartnerCoupon
		{
			get
			{
				if (_metaPartnerCoupon == null  && IsLazyLoadable == true)
				{
					_metaPartnerCoupon = BLL.Promotions.MetaPartnerCouponManager.GetOneMetaPartnerCoupon((Guid)MetaPartnerCouponID);
					// refresh derived properties
					if (_metaPartnerCoupon != null)
					{
						_startDate = _metaPartnerCoupon.StartDate;
						_endDate = _metaPartnerCoupon.EndDate;
					}
					else
					{
						_startDate = MOD.Data.DefaultValue.DateTime;
						_endDate = MOD.Data.DefaultValue.DateTime;
					}
				}
				return _metaPartnerCoupon;
			}
			set
			{
				if (_metaPartnerCoupon != value)
				{
					_metaPartnerCoupon = value;
					_isDirty = true;
					// refresh derived properties
					if (_metaPartnerCoupon != null)
					{
						_startDate = _metaPartnerCoupon.StartDate;
						_endDate = _metaPartnerCoupon.EndDate;
					}
					else
					{
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
		public OrderCoupon()
		{
			//
			// constructor logic
			//
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method creates an instance with the primary key values.</summary>
		// ------------------------------------------------------------------------------
		public OrderCoupon(string keyValues, bool isPrimaryKeyValues)
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
		/// <summary>This constructor initializes the OrderCoupon from its DAL counterpart.</summary>
		// ------------------------------------------------------------------------------
		public OrderCoupon(DAL.Orders.OrderCoupon businessObject) : base(businessObject)
		{
		}
		// ------------------------------------------------------------------------------
		/// <summary>This constructor initializes the OrderCoupon from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public OrderCoupon(Guid orderID, Guid metaPartnerCouponID, Guid debitMetaPartnerID)
		{
			OrderID = orderID;
			MetaPartnerCouponID = metaPartnerCouponID;
			DebitMetaPartnerID = debitMetaPartnerID;
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the OrderCoupon with its already set properties.</summary>
		// ------------------------------------------------------------------------------
		public void Load()
		{
			Load(OrderID, MetaPartnerCouponID, DebitMetaPartnerID);
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the OrderCoupon from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public void Load(Guid orderID, Guid metaPartnerCouponID, Guid debitMetaPartnerID)
		{
			BLL.Orders.OrderCoupon businessObject = null;
			businessObject = BLL.Orders.OrderCouponManager.GetOneOrderCoupon(orderID, metaPartnerCouponID, debitMetaPartnerID);
			if(businessObject != null)
			{
				ReflectionHelper.Copy(businessObject, this, true);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the OrderCoupon into the database,
		/// performing add/update auto detect and performing a cascade operation if indicated.</summary>
		// ------------------------------------------------------------------------------
		public void Save(bool performCascade)
		{
			if (IsLoaded == false)
			{
				BLL.Orders.OrderCouponManager.AddOneOrderCoupon(this, performCascade);
			}
			else
			{
				BLL.Orders.OrderCouponManager.UpdateOneOrderCoupon(this, performCascade);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the OrderCoupon into the database,
		/// performing add/update auto detect and without performing a cascade operation.</summary>
		// ------------------------------------------------------------------------------
		public void Save()
		{
			Save(false);
		}
		/// <summary>
		///	Clears the dirty state of OrderCoupon and its subcollections.
		/// </summary>
		/// <param name="clearCollectionDirtyState">Flag to clear subcollections.</param>
		/// <returns></returns>
		public override void ClearDirtyState(bool clearCollectionDirtyState)
		{
			// clear base items
			base.ClearDirtyState();
			// clear collections and other items
			if (this._order != null)
			{
				this.Order.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._metaPartnerCoupon != null)
			{
				this.MetaPartnerCoupon.ClearDirtyState(clearCollectionDirtyState);
			}
		}
		/// <summary>
		///	Tests to see if input object is convertable to OrderCoupon, and has the same primary key values.
		/// </summary>
		/// <param name="obj">Input object to test.</param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			OrderCoupon orderCouponInstance = obj as OrderCoupon;
			if (orderCouponInstance == null)
				return false;
			else
				return (_orderID == orderCouponInstance.OrderID && 
					_metaPartnerCouponID == orderCouponInstance.MetaPartnerCouponID && 
					_debitMetaPartnerID == orderCouponInstance.DebitMetaPartnerID);
		}
		/// <summary>
		///	Returns unique identifying integer		 
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return (_orderID.ToString() + _metaPartnerCouponID.ToString() + _debitMetaPartnerID.ToString()).GetHashCode();
		}
		#endregion Methods
	}
}