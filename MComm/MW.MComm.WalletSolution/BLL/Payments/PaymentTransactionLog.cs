
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
	/// <summary>This class is used to hold and manage information for PaymentTransactionLog instances.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[Serializable()]
	[DataTransform(Name = "MW.MComm.WalletSolution.DAL.Payments.PaymentTransactionLog")]
	public partial class PaymentTransactionLog : PersistedBusinessObject
	{
		#region Constants
		#endregion Constants
		#region Fields
		// for PaymentTransactionLogID property
		protected Guid _paymentTransactionLogID = MOD.Data.DefaultValue.Guid;
		// for PaymentID property
		protected Guid _paymentID = MOD.Data.DefaultValue.Guid;
		// for TransactionTypeCode property
		protected int _transactionTypeCode = MOD.Data.DefaultValue.Int;
		// for TransactionStatusCode property
		protected int _transactionStatusCode = MOD.Data.DefaultValue.Int;
		// for TransactionAmount property
		protected decimal _transactionAmount = 0;
		// for ResponseCode property
		protected string _responseCode = null;
		// for TransactionCode property
		protected string _transactionCode = null;
		// for TransactionMessage property
		protected string _transactionMessage = null;
		// for Balance property
		protected decimal _balance = MOD.Data.DefaultValue.Decimal;
		// for TransactionTypeName read only property
		[DataTransform]
		protected string _transactionTypeName = MOD.Data.DefaultValue.String;
		// for TransactionStatusName read only property
		[DataTransform]
		protected string _transactionStatusName = MOD.Data.DefaultValue.String;
		// for PaymentTransactionAttributeValueLogList property
		protected BLL.SortableList<BLL.Payments.PaymentTransactionAttributeValueLog> _paymentTransactionAttributeValueLogList = null;
		// for TransactionStatus property
		protected BLL.Payments.TransactionStatus _transactionStatus = null;
		// for Payment property
		protected BLL.Payments.Payment _payment = null;
		// for TransactionType property
		protected BLL.Payments.TransactionType _transactionType = null;
		#endregion Fields
		#region Properties
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the PaymentTransactionLogID.</summary>
		// ------------------------------------------------------------------------------
		[XmlElementAttribute()]
		[DataTransform]
		public virtual Guid PaymentTransactionLogID
		{
			get
			{
				return _paymentTransactionLogID;
			}
			set
			{
				if (_paymentTransactionLogID != value)
				{
					_paymentTransactionLogID = value;
					_isDirty = true;
				}
			}
		}
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
					_payment = null;
					// reset Payment
					BLL.PersistedBusinessObject vPayment = (BLL.PersistedBusinessObject) Payment;
					vPayment = null;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the TransactionTypeCode.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Int)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual int TransactionTypeCode
		{
			get
			{
				return _transactionTypeCode;
			}
			set
			{
				if (_transactionTypeCode != value)
				{
					_transactionTypeCode = value;
					_transactionType = null;
					// reset TransactionType
					BLL.PersistedBusinessObject vTransactionType = (BLL.PersistedBusinessObject) TransactionType;
					vTransactionType = null;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the TransactionStatusCode.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Int)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual int TransactionStatusCode
		{
			get
			{
				return _transactionStatusCode;
			}
			set
			{
				if (_transactionStatusCode != value)
				{
					_transactionStatusCode = value;
					_transactionStatus = null;
					// reset TransactionStatus
					BLL.PersistedBusinessObject vTransactionStatus = (BLL.PersistedBusinessObject) TransactionStatus;
					vTransactionStatus = null;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the TransactionAmount.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValue(typeof(decimal),"0")]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual decimal TransactionAmount
		{
			get
			{
				return _transactionAmount;
			}
			set
			{
				if (_transactionAmount != value)
				{
					_transactionAmount = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the ResponseCode.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(null)]
		[XmlElementAttribute(IsNullable=true)]
		[DataTransform]
		public virtual string ResponseCode
		{
			get
			{
				return _responseCode;
			}
			set
			{
				if ((_responseCode != null && !_responseCode.Equals(value)) || _responseCode != value)
				{
					_responseCode = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the TransactionCode.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(null)]
		[XmlElementAttribute(IsNullable=true)]
		[DataTransform]
		public virtual string TransactionCode
		{
			get
			{
				return _transactionCode;
			}
			set
			{
				if ((_transactionCode != null && !_transactionCode.Equals(value)) || _transactionCode != value)
				{
					_transactionCode = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the TransactionMessage.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(null)]
		[XmlElementAttribute(IsNullable=true)]
		[DataTransform]
		public virtual string TransactionMessage
		{
			get
			{
				return _transactionMessage;
			}
			set
			{
				if ((_transactionMessage != null && !_transactionMessage.Equals(value)) || _transactionMessage != value)
				{
					_transactionMessage = value;
					_isDirty = true;
				}
			}
		}
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
		/// <summary>This property gets or sets the primary key.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		public string PrimaryKey
		{
			get
			{
				return (MOD.Data.DataHelper.GetString(PaymentTransactionLogID,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					PaymentTransactionLogID = MOD.Data.DataHelper.GetGuid(keyValues[0], MOD.Data.DefaultValue.Guid);
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
					return TransactionTypeName;
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
				return (MOD.Data.DataHelper.GetString(PaymentTransactionLogID,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					PaymentTransactionLogID = MOD.Data.DataHelper.GetGuid(keyValues[0], MOD.Data.DefaultValue.Guid);
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
					return "TransactionTypeName";
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
				return ((_paymentTransactionAttributeValueLogList != null && _paymentTransactionAttributeValueLogList.IsDirty) ||
				base.IsCollectionDirty);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This read only property gets the TransactionTypeName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		public virtual string TransactionTypeName
		{
			get
			{
				return _transactionTypeName;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This read only property gets the TransactionStatusName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		public virtual string TransactionStatusName
		{
			get
			{
				return _transactionStatusName;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets PaymentTransactionAttributeValueLog lists.</summary>
		// ------------------------------------------------------------------------------
		[XmlArrayItem(typeof(BLL.Payments.PaymentTransactionAttributeValueLog), ElementName="PaymentTransactionAttributeValueLog")]
		[DataTransform]
		public virtual BLL.SortableList<BLL.Payments.PaymentTransactionAttributeValueLog> PaymentTransactionAttributeValueLogList
		{
			get
			{
				if (_paymentTransactionAttributeValueLogList == null && IsLazyLoadable == true)
				{
					_paymentTransactionAttributeValueLogList = BLL.Payments.PaymentTransactionAttributeValueLogManager.GetAllPaymentTransactionAttributeValueLogDataByPaymentTransactionLogID(PaymentTransactionLogID);
				}
				else if (_paymentTransactionAttributeValueLogList == null)
				{
					_paymentTransactionAttributeValueLogList = new BLL.SortableList<BLL.Payments.PaymentTransactionAttributeValueLog>();
				}
				return _paymentTransactionAttributeValueLogList;
			}
			set
			{
				if (value == null)
				{
					_paymentTransactionAttributeValueLogList = value;
				}
				else if ((_paymentTransactionAttributeValueLogList == null && value != null) ||
					  !_paymentTransactionAttributeValueLogList.Equals(value))
				{
					_paymentTransactionAttributeValueLogList = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of TransactionStatus.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Payments.TransactionStatus TransactionStatus
		{
			get
			{
				if (_transactionStatus == null  && IsLazyLoadable == true)
				{
					_transactionStatus = BLL.Payments.TransactionStatusManager.GetOneTransactionStatus((int)TransactionStatusCode);
					// refresh derived properties
					if (_transactionStatus != null)
					{
						_transactionStatusName = _transactionStatus.TransactionStatusName;
					}
					else
					{
						_transactionStatusName = MOD.Data.DefaultValue.String;
					}
				}
				return _transactionStatus;
			}
			set
			{
				if (_transactionStatus != value)
				{
					_transactionStatus = value;
					_isDirty = true;
					// refresh derived properties
					if (_transactionStatus != null)
					{
						_transactionStatusName = _transactionStatus.TransactionStatusName;
					}
					else
					{
						_transactionStatusName = MOD.Data.DefaultValue.String;
					}
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of Payment.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Payments.Payment Payment
		{
			get
			{
				if (_payment == null  && IsLazyLoadable == true)
				{
					_payment = BLL.Payments.PaymentManager.GetOnePayment((Guid)PaymentID);
					// refresh derived properties
					if (_payment != null)
					{
					}
					else
					{
					}
				}
				return _payment;
			}
			set
			{
				if (_payment != value)
				{
					_payment = value;
					_isDirty = true;
					// refresh derived properties
					if (_payment != null)
					{
					}
					else
					{
					}
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of TransactionType.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Payments.TransactionType TransactionType
		{
			get
			{
				if (_transactionType == null  && IsLazyLoadable == true)
				{
					_transactionType = BLL.Payments.TransactionTypeManager.GetOneTransactionType((int)TransactionTypeCode);
					// refresh derived properties
					if (_transactionType != null)
					{
						_transactionTypeName = _transactionType.TransactionTypeName;
					}
					else
					{
						_transactionTypeName = MOD.Data.DefaultValue.String;
					}
				}
				return _transactionType;
			}
			set
			{
				if (_transactionType != value)
				{
					_transactionType = value;
					_isDirty = true;
					// refresh derived properties
					if (_transactionType != null)
					{
						_transactionTypeName = _transactionType.TransactionTypeName;
					}
					else
					{
						_transactionTypeName = MOD.Data.DefaultValue.String;
					}
				}
			}
		}
		#endregion Properties
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public PaymentTransactionLog()
		{
			//
			// constructor logic
			//
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method creates an instance with the primary key values.</summary>
		// ------------------------------------------------------------------------------
		public PaymentTransactionLog(string keyValues, bool isPrimaryKeyValues)
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
		/// <summary>This constructor initializes the PaymentTransactionLog from its DAL counterpart.</summary>
		// ------------------------------------------------------------------------------
		public PaymentTransactionLog(DAL.Payments.PaymentTransactionLog businessObject) : base(businessObject)
		{
		}
		// ------------------------------------------------------------------------------
		/// <summary>This constructor initializes the PaymentTransactionLog from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public PaymentTransactionLog(Guid paymentTransactionLogID)
		{
			PaymentTransactionLogID = paymentTransactionLogID;
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the PaymentTransactionLog with its already set properties.</summary>
		// ------------------------------------------------------------------------------
		public void Load()
		{
			Load(PaymentTransactionLogID);
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the PaymentTransactionLog from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public void Load(Guid paymentTransactionLogID)
		{
			BLL.Payments.PaymentTransactionLog businessObject = null;
			businessObject = BLL.Payments.PaymentTransactionLogManager.GetOnePaymentTransactionLog(paymentTransactionLogID);
			if(businessObject != null)
			{
				ReflectionHelper.Copy(businessObject, this, true);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the PaymentTransactionLog into the database,
		/// performing add/update auto detect and performing a cascade operation if indicated.</summary>
		// ------------------------------------------------------------------------------
		public void Save(bool performCascade)
		{
			if (IsLoaded == false)
			{
				BLL.Payments.PaymentTransactionLogManager.LogOnePaymentTransactionLog(this, performCascade);
			}
			else
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the PaymentTransactionLog into the database,
		/// performing add/update auto detect and without performing a cascade operation.</summary>
		// ------------------------------------------------------------------------------
		public void Save()
		{
			Save(false);
		}
		/// <summary>
		///	Clears the dirty state of PaymentTransactionLog and its subcollections.
		/// </summary>
		/// <param name="clearCollectionDirtyState">Flag to clear subcollections.</param>
		/// <returns></returns>
		public override void ClearDirtyState(bool clearCollectionDirtyState)
		{
			// clear base items
			base.ClearDirtyState();
			// clear collections and other items
			if (this._paymentTransactionAttributeValueLogList != null)
			{
				this.PaymentTransactionAttributeValueLogList.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._transactionStatus != null)
			{
				this.TransactionStatus.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._payment != null)
			{
				this.Payment.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._transactionType != null)
			{
				this.TransactionType.ClearDirtyState(clearCollectionDirtyState);
			}
		}
		/// <summary>
		///	Tests to see if input object is convertable to PaymentTransactionLog, and has the same primary key values.
		/// </summary>
		/// <param name="obj">Input object to test.</param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			PaymentTransactionLog paymentTransactionLogInstance = obj as PaymentTransactionLog;
			if (paymentTransactionLogInstance == null)
				return false;
			else
				return (_paymentTransactionLogID == paymentTransactionLogInstance.PaymentTransactionLogID);
		}
		/// <summary>
		///	Returns unique identifying integer		 
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return (_paymentTransactionLogID.ToString()).GetHashCode();
		}
		#endregion Methods
	}
}