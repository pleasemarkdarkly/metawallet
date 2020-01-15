
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
	/// <summary>This class is used to hold and manage information for Order instances.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[Serializable()]
	[DataTransform(Name = "MW.MComm.WalletSolution.DAL.Orders.Order")]
	public partial class Order : PersistedBusinessObject
	{
		#region Constants
		#endregion Constants
		#region Fields
		// for OrderID property
		protected Guid _orderID = MOD.Data.DefaultValue.Guid;
		// for DebitMetaPartnerID property
		protected Guid _debitMetaPartnerID = MOD.Data.DefaultValue.Guid;
		// for CreditMetaPartnerID property
		protected Guid _creditMetaPartnerID = MOD.Data.DefaultValue.Guid;
		// for LogToAccountID property
		protected Guid _logToAccountID = MOD.Data.DefaultValue.Guid;
		// for OrderDescription property
		protected string _orderDescription = null;
		// for OrderAmount property
		protected decimal _orderAmount = MOD.Data.DefaultValue.Decimal;
		// for OrderSubtotal property
		protected decimal _orderSubtotal = MOD.Data.DefaultValue.Decimal;
		// for OrderTax property
		protected decimal _orderTax = MOD.Data.DefaultValue.Decimal;
		// for OrderServiceCharge property
		protected decimal _orderServiceCharge = MOD.Data.DefaultValue.Decimal;
		// for CurrencyCode property
		protected int _currencyCode = MOD.Data.DefaultValue.Int;
		// for OrderStatusCode property
		protected int _orderStatusCode = MOD.Data.DefaultValue.Int;
		// for OrderStatusMessage property
		protected string _orderStatusMessage = null;
		// for AccountName read only property
		[DataTransform]
		protected string _accountName = MOD.Data.DefaultValue.String;
		// for CurrencyName read only property
		[DataTransform]
		protected string _currencyName = MOD.Data.DefaultValue.String;
		// for OrderStatusName read only property
		[DataTransform]
		protected string _orderStatusName = MOD.Data.DefaultValue.String;
		// for MetaPartnerName read only property
		[DataTransform]
		protected string _metaPartnerName = MOD.Data.DefaultValue.String;
		// for DateFormatCode read only property
		[DataTransform]
		protected int _dateFormatCode = MOD.Data.DefaultValue.Int;
		// for PaymentList property
		protected BLL.SortableList<BLL.Payments.Payment> _paymentList = null;
		// for OrderCouponList property
		protected BLL.SortableList<BLL.Orders.OrderCoupon> _orderCouponList = null;
		// for OrderFeeList property
		protected BLL.SortableList<BLL.Orders.OrderFee> _orderFeeList = null;
		// for Account property
		protected BLL.Accounts.Account _account = null;
		// for MetaPartner property
		protected BLL.Customers.MetaPartner _metaPartner = null;
		// for Currency property
		protected BLL.Accounts.Currency _currency = null;
		// for OrderStatus property
		protected BLL.Orders.OrderStatus _orderStatus = null;
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
					_metaPartner = null;
					// reset MetaPartner
					BLL.PersistedBusinessObject vMetaPartner = (BLL.PersistedBusinessObject) MetaPartner;
					vMetaPartner = null;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CreditMetaPartnerID.</summary>
		// ------------------------------------------------------------------------------
		[XmlElementAttribute()]
		[DataTransform]
		public virtual Guid CreditMetaPartnerID
		{
			get
			{
				return _creditMetaPartnerID;
			}
			set
			{
				if (_creditMetaPartnerID != value)
				{
					_creditMetaPartnerID = value;
					_account = null;
					// reset Account
					BLL.PersistedBusinessObject vAccount = (BLL.PersistedBusinessObject) Account;
					vAccount = null;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the LogToAccountID.</summary>
		// ------------------------------------------------------------------------------
		[XmlElementAttribute()]
		[DataTransform]
		public virtual Guid LogToAccountID
		{
			get
			{
				return _logToAccountID;
			}
			set
			{
				if (_logToAccountID != value)
				{
					_logToAccountID = value;
					_account = null;
					// reset Account
					BLL.PersistedBusinessObject vAccount = (BLL.PersistedBusinessObject) Account;
					vAccount = null;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the OrderDescription.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(null)]
		[XmlElementAttribute(IsNullable=true)]
		[DataTransform]
		public virtual string OrderDescription
		{
			get
			{
				return _orderDescription;
			}
			set
			{
				if ((_orderDescription != null && !_orderDescription.Equals(value)) || _orderDescription != value)
				{
					_orderDescription = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the OrderAmount.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValue(typeof(decimal),"0")]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual decimal OrderAmount
		{
			get
			{
				return _orderAmount;
			}
			set
			{
				if (_orderAmount != value)
				{
					_orderAmount = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the OrderSubtotal.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValue(typeof(decimal),"0")]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual decimal OrderSubtotal
		{
			get
			{
				return _orderSubtotal;
			}
			set
			{
				if (_orderSubtotal != value)
				{
					_orderSubtotal = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the OrderTax.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValue(typeof(decimal),"0")]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual decimal OrderTax
		{
			get
			{
				return _orderTax;
			}
			set
			{
				if (_orderTax != value)
				{
					_orderTax = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the OrderServiceCharge.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValue(typeof(decimal),"0")]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual decimal OrderServiceCharge
		{
			get
			{
				return _orderServiceCharge;
			}
			set
			{
				if (_orderServiceCharge != value)
				{
					_orderServiceCharge = value;
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
		/// <summary>This property gets or sets the OrderStatusCode.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Int)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual int OrderStatusCode
		{
			get
			{
				return _orderStatusCode;
			}
			set
			{
				if (_orderStatusCode != value)
				{
					_orderStatusCode = value;
					_orderStatus = null;
					// reset OrderStatus
					BLL.PersistedBusinessObject vOrderStatus = (BLL.PersistedBusinessObject) OrderStatus;
					vOrderStatus = null;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the OrderStatusMessage.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(null)]
		[XmlElementAttribute(IsNullable=true)]
		[DataTransform]
		public virtual string OrderStatusMessage
		{
			get
			{
				return _orderStatusMessage;
			}
			set
			{
				if ((_orderStatusMessage != null && !_orderStatusMessage.Equals(value)) || _orderStatusMessage != value)
				{
					_orderStatusMessage = value;
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
				return (MOD.Data.DataHelper.GetString(OrderID,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					OrderID = MOD.Data.DataHelper.GetGuid(keyValues[0], MOD.Data.DefaultValue.Guid);
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
				return (MOD.Data.DataHelper.GetString(OrderID,"") + ", " + MOD.Data.DataHelper.GetString(DebitMetaPartnerID,""));
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
					DebitMetaPartnerID = MOD.Data.DataHelper.GetGuid(keyValues[1], MOD.Data.DefaultValue.Guid);
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
				return ((_paymentList != null && _paymentList.IsDirty) ||
				(_orderCouponList != null && _orderCouponList.IsDirty) ||
				(_orderFeeList != null && _orderFeeList.IsDirty) ||
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
		/// <summary>This read only property gets the OrderStatusName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		public virtual string OrderStatusName
		{
			get
			{
				return _orderStatusName;
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
		/// <summary>This property gets or sets Payment lists.</summary>
		// ------------------------------------------------------------------------------
		[XmlArrayItem(typeof(BLL.Payments.Payment), ElementName="Payment")]
		[DataTransform]
		public virtual BLL.SortableList<BLL.Payments.Payment> PaymentList
		{
			get
			{
				if (_paymentList == null && IsLazyLoadable == true)
				{
					_paymentList = BLL.Payments.PaymentManager.GetAllPaymentDataByOrderID(OrderID);
				}
				else if (_paymentList == null)
				{
					_paymentList = new BLL.SortableList<BLL.Payments.Payment>();
				}
				return _paymentList;
			}
			set
			{
				if (value == null)
				{
					_paymentList = value;
				}
				else if ((_paymentList == null && value != null) ||
					  !_paymentList.Equals(value))
				{
					_paymentList = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets OrderCoupon lists.</summary>
		// ------------------------------------------------------------------------------
		[XmlArrayItem(typeof(BLL.Orders.OrderCoupon), ElementName="OrderCoupon")]
		[DataTransform]
		public virtual BLL.SortableList<BLL.Orders.OrderCoupon> OrderCouponList
		{
			get
			{
				return _orderCouponList;
			}
			set
			{
				if (value == null)
				{
					_orderCouponList = value;
				}
				else if ((_orderCouponList == null && value != null) ||
					  !_orderCouponList.Equals(value))
				{
					_orderCouponList = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets OrderFee lists.</summary>
		// ------------------------------------------------------------------------------
		[XmlArrayItem(typeof(BLL.Orders.OrderFee), ElementName="OrderFee")]
		[DataTransform]
		public virtual BLL.SortableList<BLL.Orders.OrderFee> OrderFeeList
		{
			get
			{
				if (_orderFeeList == null && IsLazyLoadable == true)
				{
					_orderFeeList = BLL.Orders.OrderFeeManager.GetAllOrderFeeDataByOrderID(OrderID);
				}
				else if (_orderFeeList == null)
				{
					_orderFeeList = new BLL.SortableList<BLL.Orders.OrderFee>();
				}
				return _orderFeeList;
			}
			set
			{
				if (value == null)
				{
					_orderFeeList = value;
				}
				else if ((_orderFeeList == null && value != null) ||
					  !_orderFeeList.Equals(value))
				{
					_orderFeeList = value;
					_isDirty = true;
				}
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
					_account = BLL.Accounts.AccountManager.GetOneAccount((Guid)LogToAccountID);
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
					_metaPartner = BLL.Customers.MetaPartnerManager.GetOneMetaPartner((Guid)CreditMetaPartnerID);
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
		/// <summary>This property gets or sets an item of OrderStatus.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Orders.OrderStatus OrderStatus
		{
			get
			{
				if (_orderStatus == null  && IsLazyLoadable == true)
				{
					_orderStatus = BLL.Orders.OrderStatusManager.GetOneOrderStatus((int)OrderStatusCode);
					// refresh derived properties
					if (_orderStatus != null)
					{
						_orderStatusName = _orderStatus.OrderStatusName;
					}
					else
					{
						_orderStatusName = MOD.Data.DefaultValue.String;
					}
				}
				return _orderStatus;
			}
			set
			{
				if (_orderStatus != value)
				{
					_orderStatus = value;
					_isDirty = true;
					// refresh derived properties
					if (_orderStatus != null)
					{
						_orderStatusName = _orderStatus.OrderStatusName;
					}
					else
					{
						_orderStatusName = MOD.Data.DefaultValue.String;
					}
				}
			}
		}
		#endregion Properties
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public Order()
		{
			//
			// constructor logic
			//
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method creates an instance with the primary key values.</summary>
		// ------------------------------------------------------------------------------
		public Order(string keyValues, bool isPrimaryKeyValues)
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
		/// <summary>This constructor initializes the Order from its DAL counterpart.</summary>
		// ------------------------------------------------------------------------------
		public Order(DAL.Orders.Order businessObject) : base(businessObject)
		{
		}
		// ------------------------------------------------------------------------------
		/// <summary>This constructor initializes the Order from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public Order(Guid orderID)
		{
			OrderID = orderID;
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the Order with its already set properties.</summary>
		// ------------------------------------------------------------------------------
		public void Load()
		{
			Load(OrderID);
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the Order from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public void Load(Guid orderID)
		{
			BLL.Orders.Order businessObject = null;
			businessObject = BLL.Orders.OrderManager.GetOneOrder(orderID);
			if(businessObject != null)
			{
				ReflectionHelper.Copy(businessObject, this, true);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the Order into the database,
		/// performing add/update auto detect and performing a cascade operation if indicated.</summary>
		// ------------------------------------------------------------------------------
		public void Save(bool performCascade)
		{
			if (IsLoaded == false)
			{
				BLL.Orders.OrderManager.UpsertOneOrder(this, performCascade);
			}
			else
			{
				BLL.Orders.OrderManager.UpsertOneOrder(this, performCascade);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the Order into the database,
		/// performing add/update auto detect and without performing a cascade operation.</summary>
		// ------------------------------------------------------------------------------
		public void Save()
		{
			Save(false);
		}
		/// <summary>
		///	Clears the dirty state of Order and its subcollections.
		/// </summary>
		/// <param name="clearCollectionDirtyState">Flag to clear subcollections.</param>
		/// <returns></returns>
		public override void ClearDirtyState(bool clearCollectionDirtyState)
		{
			// clear base items
			base.ClearDirtyState();
			// clear collections and other items
			if (this._paymentList != null)
			{
				this.PaymentList.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._orderCouponList != null)
			{
				this.OrderCouponList.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._orderFeeList != null)
			{
				this.OrderFeeList.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._account != null)
			{
				this.Account.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._metaPartner != null)
			{
				this.MetaPartner.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._currency != null)
			{
				this.Currency.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._orderStatus != null)
			{
				this.OrderStatus.ClearDirtyState(clearCollectionDirtyState);
			}
		}
		/// <summary>
		///	Tests to see if input object is convertable to Order, and has the same primary key values.
		/// </summary>
		/// <param name="obj">Input object to test.</param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			Order orderInstance = obj as Order;
			if (orderInstance == null)
				return false;
			else
				return (_orderID == orderInstance.OrderID);
		}
		/// <summary>
		///	Returns unique identifying integer		 
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return (_orderID.ToString()).GetHashCode();
		}
		#endregion Methods
	}
}