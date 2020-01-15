
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
namespace MW.MComm.WalletSolution.BLL.Payments
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to hold and manage information for Payment instances.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[Serializable()]
	[DataTransform(Name = "MW.MComm.WalletSolution.DAL.Payments.Payment")]
	public partial class Payment : PersistedBusinessObject
	{
		#region Constants
		#endregion Constants
		#region Fields
		// for PaymentID property
		protected Guid _paymentID = MOD.Data.DefaultValue.Guid;
		// for PaymentAmount property
		protected decimal _paymentAmount = 0;
		// for PaymentSubtotal property
		protected decimal _paymentSubtotal = MOD.Data.DefaultValue.Decimal;
		// for PaymentTax property
		protected decimal _paymentTax = MOD.Data.DefaultValue.Decimal;
		// for PaymentServiceCharge property
		protected decimal _paymentServiceCharge = MOD.Data.DefaultValue.Decimal;
		// for OrderID property
		protected Guid _orderID = MOD.Data.DefaultValue.Guid;
		// for DebitMetaPartnerID property
		protected Guid _debitMetaPartnerID = MOD.Data.DefaultValue.Guid;
		// for SourceAccountID property
		protected Guid _sourceAccountID = MOD.Data.DefaultValue.Guid;
		// for CreditMetaPartnerID property
		protected Guid _creditMetaPartnerID = MOD.Data.DefaultValue.Guid;
		// for DestinationAccountID property
		protected Guid _destinationAccountID = MOD.Data.DefaultValue.Guid;
		// for PaymentStatusCode property
		protected int _paymentStatusCode = MOD.Data.DefaultValue.Int;
		// for PaymentStatusMessage property
		protected string _paymentStatusMessage = null;
		// for AccountName read only property
		[DataTransform]
		protected string _accountName = MOD.Data.DefaultValue.String;
		// for PaymentStatusName read only property
		[DataTransform]
		protected string _paymentStatusName = MOD.Data.DefaultValue.String;
		// for PaymentTransactionLogList property
		protected BLL.SortableList<BLL.Payments.PaymentTransactionLog> _paymentTransactionLogList = null;
		// for Account property
		protected BLL.Accounts.Account _account = null;
		// for Order property
		protected BLL.Orders.Order _order = null;
		// for PaymentStatus property
		protected BLL.Payments.PaymentStatus _paymentStatus = null;
		#endregion Fields
		#region Properties
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the PaymentID.</summary>
		// ------------------------------------------------------------------------------
		[XmlElementAttribute()]
		[DataTransform]
		public virtual Guid PaymentID
		{
			get
			{
				return _paymentID;
			}
			set
			{
				if (_paymentID != value)
				{
					_paymentID = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the PaymentAmount.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValue(typeof(decimal),"0")]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual decimal PaymentAmount
		{
			get
			{
				return _paymentAmount;
			}
			set
			{
				if (_paymentAmount != value)
				{
					_paymentAmount = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the PaymentSubtotal.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValue(typeof(decimal),"0")]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual decimal PaymentSubtotal
		{
			get
			{
				return _paymentSubtotal;
			}
			set
			{
				if (_paymentSubtotal != value)
				{
					_paymentSubtotal = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the PaymentTax.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValue(typeof(decimal),"0")]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual decimal PaymentTax
		{
			get
			{
				return _paymentTax;
			}
			set
			{
				if (_paymentTax != value)
				{
					_paymentTax = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the PaymentServiceCharge.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValue(typeof(decimal),"0")]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual decimal PaymentServiceCharge
		{
			get
			{
				return _paymentServiceCharge;
			}
			set
			{
				if (_paymentServiceCharge != value)
				{
					_paymentServiceCharge = value;
					_isDirty = true;
				}
			}
		}
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
					_account = null;
					// reset Account
					BLL.PersistedBusinessObject vAccount = (BLL.PersistedBusinessObject) Account;
					vAccount = null;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the SourceAccountID.</summary>
		// ------------------------------------------------------------------------------
		[XmlElementAttribute()]
		[DataTransform]
		public virtual Guid SourceAccountID
		{
			get
			{
				return _sourceAccountID;
			}
			set
			{
				if (_sourceAccountID != value)
				{
					_sourceAccountID = value;
					_account = null;
					// reset Account
					BLL.PersistedBusinessObject vAccount = (BLL.PersistedBusinessObject) Account;
					vAccount = null;
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
		/// <summary>This property gets or sets the DestinationAccountID.</summary>
		// ------------------------------------------------------------------------------
		[XmlElementAttribute()]
		[DataTransform]
		public virtual Guid DestinationAccountID
		{
			get
			{
				return _destinationAccountID;
			}
			set
			{
				if (_destinationAccountID != value)
				{
					_destinationAccountID = value;
					_account = null;
					// reset Account
					BLL.PersistedBusinessObject vAccount = (BLL.PersistedBusinessObject) Account;
					vAccount = null;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the PaymentStatusCode.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Int)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual int PaymentStatusCode
		{
			get
			{
				return _paymentStatusCode;
			}
			set
			{
				if (_paymentStatusCode != value)
				{
					_paymentStatusCode = value;
					_paymentStatus = null;
					// reset PaymentStatus
					BLL.PersistedBusinessObject vPaymentStatus = (BLL.PersistedBusinessObject) PaymentStatus;
					vPaymentStatus = null;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the PaymentStatusMessage.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(null)]
		[XmlElementAttribute(IsNullable=true)]
		[DataTransform]
		public virtual string PaymentStatusMessage
		{
			get
			{
				return _paymentStatusMessage;
			}
			set
			{
				if ((_paymentStatusMessage != null && !_paymentStatusMessage.Equals(value)) || _paymentStatusMessage != value)
				{
					_paymentStatusMessage = value;
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
				return (MOD.Data.DataHelper.GetString(PaymentID,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					PaymentID = MOD.Data.DataHelper.GetGuid(keyValues[0], MOD.Data.DefaultValue.Guid);
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
				return (MOD.Data.DataHelper.GetString(PaymentID,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					PaymentID = MOD.Data.DataHelper.GetGuid(keyValues[0], MOD.Data.DefaultValue.Guid);
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
				return ((_paymentTransactionLogList != null && _paymentTransactionLogList.IsDirty) ||
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
		/// <summary>This read only property gets the PaymentStatusName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		public virtual string PaymentStatusName
		{
			get
			{
				return _paymentStatusName;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets PaymentTransactionLog lists.</summary>
		// ------------------------------------------------------------------------------
		[XmlArrayItem(typeof(BLL.Payments.PaymentTransactionLog), ElementName="PaymentTransactionLog")]
		[DataTransform]
		public virtual BLL.SortableList<BLL.Payments.PaymentTransactionLog> PaymentTransactionLogList
		{
			get
			{
				if (_paymentTransactionLogList == null && IsLazyLoadable == true)
				{
					_paymentTransactionLogList = BLL.Payments.PaymentTransactionLogManager.GetAllPaymentTransactionLogDataByPaymentID(PaymentID);
				}
				else if (_paymentTransactionLogList == null)
				{
					_paymentTransactionLogList = new BLL.SortableList<BLL.Payments.PaymentTransactionLog>();
				}
				return _paymentTransactionLogList;
			}
			set
			{
				if (value == null)
				{
					_paymentTransactionLogList = value;
				}
				else if ((_paymentTransactionLogList == null && value != null) ||
					  !_paymentTransactionLogList.Equals(value))
				{
					_paymentTransactionLogList = value;
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
					_account = BLL.Accounts.AccountManager.GetOneAccount((Guid)DestinationAccountID);
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
		/// <summary>This property gets or sets an item of PaymentStatus.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Payments.PaymentStatus PaymentStatus
		{
			get
			{
				if (_paymentStatus == null  && IsLazyLoadable == true)
				{
					_paymentStatus = BLL.Payments.PaymentStatusManager.GetOnePaymentStatus((int)PaymentStatusCode);
					// refresh derived properties
					if (_paymentStatus != null)
					{
						_paymentStatusName = _paymentStatus.PaymentStatusName;
					}
					else
					{
						_paymentStatusName = MOD.Data.DefaultValue.String;
					}
				}
				return _paymentStatus;
			}
			set
			{
				if (_paymentStatus != value)
				{
					_paymentStatus = value;
					_isDirty = true;
					// refresh derived properties
					if (_paymentStatus != null)
					{
						_paymentStatusName = _paymentStatus.PaymentStatusName;
					}
					else
					{
						_paymentStatusName = MOD.Data.DefaultValue.String;
					}
				}
			}
		}
		#endregion Properties
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public Payment()
		{
			//
			// constructor logic
			//
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method creates an instance with the primary key values.</summary>
		// ------------------------------------------------------------------------------
		public Payment(string keyValues, bool isPrimaryKeyValues)
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
		/// <summary>This constructor initializes the Payment from its DAL counterpart.</summary>
		// ------------------------------------------------------------------------------
		public Payment(DAL.Payments.Payment businessObject) : base(businessObject)
		{
		}
		// ------------------------------------------------------------------------------
		/// <summary>This constructor initializes the Payment from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public Payment(Guid paymentID)
		{
			PaymentID = paymentID;
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the Payment with its already set properties.</summary>
		// ------------------------------------------------------------------------------
		public void Load()
		{
			Load(PaymentID);
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the Payment from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public void Load(Guid paymentID)
		{
			BLL.Payments.Payment businessObject = null;
			businessObject = BLL.Payments.PaymentManager.GetOnePayment(paymentID);
			if(businessObject != null)
			{
				ReflectionHelper.Copy(businessObject, this, true);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the Payment into the database,
		/// performing add/update auto detect and performing a cascade operation if indicated.</summary>
		// ------------------------------------------------------------------------------
		public void Save(bool performCascade)
		{
			if (IsLoaded == false)
			{
				BLL.Payments.PaymentManager.UpsertOnePayment(this, performCascade);
			}
			else
			{
				BLL.Payments.PaymentManager.UpsertOnePayment(this, performCascade);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the Payment into the database,
		/// performing add/update auto detect and without performing a cascade operation.</summary>
		// ------------------------------------------------------------------------------
		public void Save()
		{
			Save(false);
		}
		/// <summary>
		///	Clears the dirty state of Payment and its subcollections.
		/// </summary>
		/// <param name="clearCollectionDirtyState">Flag to clear subcollections.</param>
		/// <returns></returns>
		public override void ClearDirtyState(bool clearCollectionDirtyState)
		{
			// clear base items
			base.ClearDirtyState();
			// clear collections and other items
			if (this._paymentTransactionLogList != null)
			{
				this.PaymentTransactionLogList.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._account != null)
			{
				this.Account.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._order != null)
			{
				this.Order.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._paymentStatus != null)
			{
				this.PaymentStatus.ClearDirtyState(clearCollectionDirtyState);
			}
		}
		/// <summary>
		///	Tests to see if input object is convertable to Payment, and has the same primary key values.
		/// </summary>
		/// <param name="obj">Input object to test.</param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			Payment paymentInstance = obj as Payment;
			if (paymentInstance == null)
				return false;
			else
				return (_paymentID == paymentInstance.PaymentID);
		}
		/// <summary>
		///	Returns unique identifying integer		 
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return (_paymentID.ToString()).GetHashCode();
		}
		#endregion Methods
	}
}