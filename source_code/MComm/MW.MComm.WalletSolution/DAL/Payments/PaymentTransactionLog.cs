
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
using DAL = MW.MComm.WalletSolution.DAL;
using Utility = MW.MComm.WalletSolution.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
namespace MW.MComm.WalletSolution.DAL.Payments
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
	public partial class PaymentTransactionLog : Utility.BaseDataAccessObject
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
		// for PrimaryName property
		protected string _primaryName = MOD.Data.DefaultValue.String;
		// for PrimaryIndex property
		protected string _primaryIndex = MOD.Data.DefaultValue.String;
		// for PrimarySortColumn property
		protected string _primarySortColumn = MOD.Data.DefaultValue.String;
		// for TransactionTypeName read only property
		[DataTransform]
		protected string _transactionTypeName = MOD.Data.DefaultValue.String;
		// for TransactionStatusName read only property
		[DataTransform]
		protected string _transactionStatusName = MOD.Data.DefaultValue.String;
		// for PaymentTransactionAttributeValueLogList property
		protected MOD.Data.SortableObjectCollection _paymentTransactionAttributeValueLogList = null;
		// for TransactionStatus property
		protected DAL.Payments.TransactionStatus _transactionStatus = null;
		// for Payment property
		protected DAL.Payments.Payment _payment = null;
		// for TransactionType property
		protected DAL.Payments.TransactionType _transactionType = null;
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
		[XmlArrayItem(typeof(DAL.Payments.PaymentTransactionAttributeValueLog), ElementName="PaymentTransactionAttributeValueLog")]
		[DataTransform]
		public virtual MOD.Data.SortableObjectCollection PaymentTransactionAttributeValueLogList
		{
			get
			{
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
		public virtual DAL.Payments.TransactionStatus TransactionStatus
		{
			get
			{
				return _transactionStatus;
			}
			set
			{
				_transactionStatus = value;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of Payment.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual DAL.Payments.Payment Payment
		{
			get
			{
				return _payment;
			}
			set
			{
				_payment = value;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of TransactionType.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual DAL.Payments.TransactionType TransactionType
		{
			get
			{
				return _transactionType;
			}
			set
			{
				_transactionType = value;
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
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------
		/// <summary>This method gets all PaymentTransactionLog data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetAllPaymentTransactionLogData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel)
		{
			Utility.SqlManager dbManager = null;
			MOD.Data.SqlProcAdapter dbAdapter = null;
			try
			{
				// set up adapter
				dbManager = new Utility.SqlManager();
				dbAdapter = dbManager.GetAdapter(debugLevel, dbOptions);
				// perform main method tasks
				MOD.Data.NamedObjectCollection spParameters = new MOD.Data.NamedObjectCollection();
				MOD.Data.NamedObjectCollection filterFields = new MOD.Data.NamedObjectCollection();
				MOD.Data.SortableObjectCollection items = new MOD.Data.SortableObjectCollection();
				if(dataOptions != null)
				{
					spParameters["IncludeInactive"] = dataOptions.IncludeInactive;
					spParameters["IncludeDateInactive"] = dataOptions.IncludeDateInactive;
					dataOptions.PopulateNamedObjectCollection( spParameters );
					filterFields = dataOptions.FilterFields;
				}
				else
				{
					spParameters["IncludeInactive"] = false;
					spParameters["IncludeDateInactive"] = false;
				}
				DataTable dt = dbAdapter.ExecuteProc("spPayments_GetAllPaymentTransactionLogData", null, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					PaymentTransactionLog item = (PaymentTransactionLog) DataTransformAttribute.Transform(row, new PaymentTransactionLog(), false, filterFields);
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Payments.GetAllPaymentTransactionLogData");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all PaymentTransactionLog data by criteria.</summary>
		///
		/// <param name="transactionTypeCode">A key for PaymentTransactionLog items to be fetched</param>
		/// <param name="transactionStatusCode">A key for PaymentTransactionLog items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for PaymentTransactionLog items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for PaymentTransactionLog items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetAllPaymentTransactionLogDataByCriteria(int? transactionTypeCode, int? transactionStatusCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel)
		{
			Utility.SqlManager dbManager = null;
			MOD.Data.SqlProcAdapter dbAdapter = null;
			try
			{
				// set up adapter
				dbManager = new Utility.SqlManager();
				dbAdapter = dbManager.GetAdapter(debugLevel, dbOptions);
				// perform main method tasks
				MOD.Data.NamedObjectCollection spParameters = new MOD.Data.NamedObjectCollection();
				MOD.Data.NamedObjectCollection filterFields = new MOD.Data.NamedObjectCollection();
				MOD.Data.SortableObjectCollection items = new MOD.Data.SortableObjectCollection();
				spParameters["TransactionTypeCode"] = transactionTypeCode;
				spParameters["TransactionStatusCode"] = transactionStatusCode;
				spParameters["LastModifiedDateStart"] = lastModifiedDateStart;
				spParameters["LastModifiedDateEnd"] = lastModifiedDateEnd;
				if(dataOptions != null)
				{
					spParameters["IncludeInactive"] = dataOptions.IncludeInactive;
					spParameters["IncludeDateInactive"] = dataOptions.IncludeDateInactive;
					dataOptions.PopulateNamedObjectCollection( spParameters );
					filterFields = dataOptions.FilterFields;
				}
				else
				{
					spParameters["IncludeInactive"] = false;
					spParameters["IncludeDateInactive"] = false;
				}
				DataTable dt = dbAdapter.ExecuteProc("spPayments_GetAllPaymentTransactionLogDataByCriteria", null, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					PaymentTransactionLog item = (PaymentTransactionLog) DataTransformAttribute.Transform(row, new PaymentTransactionLog(), false, filterFields);
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Payments.GetAllPaymentTransactionLogDataByCriteria");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all PaymentTransactionLog data by a key.</summary>
		///
		/// <param name="paymentID">A key for PaymentTransactionLog items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetAllPaymentTransactionLogDataByPaymentID(Guid paymentID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel)
		{
			Utility.SqlManager dbManager = null;
			MOD.Data.SqlProcAdapter dbAdapter = null;
			try
			{
				// set up adapter
				dbManager = new Utility.SqlManager();
				dbAdapter = dbManager.GetAdapter(debugLevel, dbOptions);
				// perform main method tasks
				MOD.Data.NamedObjectCollection spParameters = new MOD.Data.NamedObjectCollection();
				MOD.Data.NamedObjectCollection filterFields = new MOD.Data.NamedObjectCollection();
				MOD.Data.SortableObjectCollection items = new MOD.Data.SortableObjectCollection();
				spParameters["PaymentID"] = paymentID;
				if(dataOptions != null)
				{
					spParameters["IncludeInactive"] = dataOptions.IncludeInactive;
					spParameters["IncludeDateInactive"] = dataOptions.IncludeDateInactive;
					dataOptions.PopulateNamedObjectCollection( spParameters );
					filterFields = dataOptions.FilterFields;
				}
				else
				{
					spParameters["IncludeInactive"] = false;
					spParameters["IncludeDateInactive"] = false;
				}
				DataTable dt = dbAdapter.ExecuteProc("spPayments_GetAllPaymentTransactionLogDataByPaymentID", null, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					PaymentTransactionLog item = (PaymentTransactionLog) DataTransformAttribute.Transform(row, new PaymentTransactionLog(), false, filterFields);
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Payments.GetAllPaymentTransactionLogDataByPaymentID");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all PaymentTransactionLog data by a key.</summary>
		///
		/// <param name="paymentID">A key for PaymentTransactionLog items to be fetched</param>
		/// <param name="dbAdapter">Database adapter for transaction</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetAllPaymentTransactionLogDataByPaymentID(Guid paymentID, MOD.Data.SqlProcAdapter dbAdapter)
		{
			try
			{
				// perform main method tasks
				MOD.Data.NamedObjectCollection spParameters = new MOD.Data.NamedObjectCollection();
				MOD.Data.NamedObjectCollection filterFields = new MOD.Data.NamedObjectCollection();
				MOD.Data.SortableObjectCollection items = new MOD.Data.SortableObjectCollection();
				spParameters["PaymentID"] = paymentID;
				spParameters["IncludeInactive"] = true;
				spParameters["IncludeDateInactive"] = true;
				DataTable dt = dbAdapter.ExecuteProc("spPayments_GetAllPaymentTransactionLogDataByPaymentID", null, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					PaymentTransactionLog item = (PaymentTransactionLog) DataTransformAttribute.Transform(row, new PaymentTransactionLog(), false);
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Payments.GetAllPaymentTransactionLogDataByPaymentID");
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all PaymentTransactionLog data by a key.</summary>
		///
		/// <param name="transactionStatusCode">A key for PaymentTransactionLog items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetAllPaymentTransactionLogDataByTransactionStatusCode(int transactionStatusCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel)
		{
			Utility.SqlManager dbManager = null;
			MOD.Data.SqlProcAdapter dbAdapter = null;
			try
			{
				// set up adapter
				dbManager = new Utility.SqlManager();
				dbAdapter = dbManager.GetAdapter(debugLevel, dbOptions);
				// perform main method tasks
				MOD.Data.NamedObjectCollection spParameters = new MOD.Data.NamedObjectCollection();
				MOD.Data.NamedObjectCollection filterFields = new MOD.Data.NamedObjectCollection();
				MOD.Data.SortableObjectCollection items = new MOD.Data.SortableObjectCollection();
				spParameters["TransactionStatusCode"] = transactionStatusCode;
				if(dataOptions != null)
				{
					spParameters["IncludeInactive"] = dataOptions.IncludeInactive;
					spParameters["IncludeDateInactive"] = dataOptions.IncludeDateInactive;
					dataOptions.PopulateNamedObjectCollection( spParameters );
					filterFields = dataOptions.FilterFields;
				}
				else
				{
					spParameters["IncludeInactive"] = false;
					spParameters["IncludeDateInactive"] = false;
				}
				DataTable dt = dbAdapter.ExecuteProc("spPayments_GetAllPaymentTransactionLogDataByTransactionStatusCode", null, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					PaymentTransactionLog item = (PaymentTransactionLog) DataTransformAttribute.Transform(row, new PaymentTransactionLog(), false, filterFields);
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Payments.GetAllPaymentTransactionLogDataByTransactionStatusCode");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all PaymentTransactionLog data by a key.</summary>
		///
		/// <param name="transactionStatusCode">A key for PaymentTransactionLog items to be fetched</param>
		/// <param name="dbAdapter">Database adapter for transaction</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetAllPaymentTransactionLogDataByTransactionStatusCode(int transactionStatusCode, MOD.Data.SqlProcAdapter dbAdapter)
		{
			try
			{
				// perform main method tasks
				MOD.Data.NamedObjectCollection spParameters = new MOD.Data.NamedObjectCollection();
				MOD.Data.NamedObjectCollection filterFields = new MOD.Data.NamedObjectCollection();
				MOD.Data.SortableObjectCollection items = new MOD.Data.SortableObjectCollection();
				spParameters["TransactionStatusCode"] = transactionStatusCode;
				spParameters["IncludeInactive"] = true;
				spParameters["IncludeDateInactive"] = true;
				DataTable dt = dbAdapter.ExecuteProc("spPayments_GetAllPaymentTransactionLogDataByTransactionStatusCode", null, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					PaymentTransactionLog item = (PaymentTransactionLog) DataTransformAttribute.Transform(row, new PaymentTransactionLog(), false);
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Payments.GetAllPaymentTransactionLogDataByTransactionStatusCode");
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all PaymentTransactionLog data by a key.</summary>
		///
		/// <param name="transactionTypeCode">A key for PaymentTransactionLog items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetAllPaymentTransactionLogDataByTransactionTypeCode(int transactionTypeCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel)
		{
			Utility.SqlManager dbManager = null;
			MOD.Data.SqlProcAdapter dbAdapter = null;
			try
			{
				// set up adapter
				dbManager = new Utility.SqlManager();
				dbAdapter = dbManager.GetAdapter(debugLevel, dbOptions);
				// perform main method tasks
				MOD.Data.NamedObjectCollection spParameters = new MOD.Data.NamedObjectCollection();
				MOD.Data.NamedObjectCollection filterFields = new MOD.Data.NamedObjectCollection();
				MOD.Data.SortableObjectCollection items = new MOD.Data.SortableObjectCollection();
				spParameters["TransactionTypeCode"] = transactionTypeCode;
				if(dataOptions != null)
				{
					spParameters["IncludeInactive"] = dataOptions.IncludeInactive;
					spParameters["IncludeDateInactive"] = dataOptions.IncludeDateInactive;
					dataOptions.PopulateNamedObjectCollection( spParameters );
					filterFields = dataOptions.FilterFields;
				}
				else
				{
					spParameters["IncludeInactive"] = false;
					spParameters["IncludeDateInactive"] = false;
				}
				DataTable dt = dbAdapter.ExecuteProc("spPayments_GetAllPaymentTransactionLogDataByTransactionTypeCode", null, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					PaymentTransactionLog item = (PaymentTransactionLog) DataTransformAttribute.Transform(row, new PaymentTransactionLog(), false, filterFields);
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Payments.GetAllPaymentTransactionLogDataByTransactionTypeCode");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all PaymentTransactionLog data by a key.</summary>
		///
		/// <param name="transactionTypeCode">A key for PaymentTransactionLog items to be fetched</param>
		/// <param name="dbAdapter">Database adapter for transaction</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetAllPaymentTransactionLogDataByTransactionTypeCode(int transactionTypeCode, MOD.Data.SqlProcAdapter dbAdapter)
		{
			try
			{
				// perform main method tasks
				MOD.Data.NamedObjectCollection spParameters = new MOD.Data.NamedObjectCollection();
				MOD.Data.NamedObjectCollection filterFields = new MOD.Data.NamedObjectCollection();
				MOD.Data.SortableObjectCollection items = new MOD.Data.SortableObjectCollection();
				spParameters["TransactionTypeCode"] = transactionTypeCode;
				spParameters["IncludeInactive"] = true;
				spParameters["IncludeDateInactive"] = true;
				DataTable dt = dbAdapter.ExecuteProc("spPayments_GetAllPaymentTransactionLogDataByTransactionTypeCode", null, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					PaymentTransactionLog item = (PaymentTransactionLog) DataTransformAttribute.Transform(row, new PaymentTransactionLog(), false);
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Payments.GetAllPaymentTransactionLogDataByTransactionTypeCode");
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets many PaymentTransactionLog data by criteria.</summary>
		///
		/// <param name="transactionTypeCode">A key for PaymentTransactionLog items to be fetched</param>
		/// <param name="transactionStatusCode">A key for PaymentTransactionLog items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for PaymentTransactionLog items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for PaymentTransactionLog items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetManyPaymentTransactionLogDataByCriteria(int? transactionTypeCode, int? transactionStatusCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel)
		{
			Utility.SqlManager dbManager = null;
			MOD.Data.SqlProcAdapter dbAdapter = null;
			try
			{
				// set up adapter
				dbManager = new Utility.SqlManager();
				dbAdapter = dbManager.GetAdapter(debugLevel, dbOptions);
				// perform main method tasks
				MOD.Data.NamedObjectCollection spParameters = new MOD.Data.NamedObjectCollection();
				MOD.Data.NamedObjectCollection filterFields = new MOD.Data.NamedObjectCollection();
				MOD.Data.SortableObjectCollection items = new MOD.Data.SortableObjectCollection();
				spParameters["TransactionTypeCode"] = transactionTypeCode;
				spParameters["TransactionStatusCode"] = transactionStatusCode;
				spParameters["LastModifiedDateStart"] = lastModifiedDateStart;
				spParameters["LastModifiedDateEnd"] = lastModifiedDateEnd;
				if(dataOptions != null)
				{
					spParameters["IncludeInactive"] = dataOptions.IncludeInactive;
					spParameters["IncludeDateInactive"] = dataOptions.IncludeDateInactive;
					dataOptions.PopulateNamedObjectCollection( spParameters );
					filterFields = dataOptions.FilterFields;
				}
				else
				{
					spParameters["IncludeInactive"] = false;
					spParameters["IncludeDateInactive"] = false;
				}
				DataTable dt = dbAdapter.ExecuteProc("spPayments_GetManyPaymentTransactionLogDataByCriteria", null, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				totalRecords = MOD.Data.DataHelper.GetInt(spParameters["TotalRecords"], MOD.Data.DefaultValue.Int);
				maximumListSizeExceeded = MOD.Data.DataHelper.GetBool(spParameters["MaximumListSizeExceeded"], MOD.Data.DefaultValue.Bool);
				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					PaymentTransactionLog item = (PaymentTransactionLog) DataTransformAttribute.Transform(row, new PaymentTransactionLog(), false, filterFields);
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Payments.GetManyPaymentTransactionLogDataByCriteria");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single PaymentTransactionLog by an index.</summary>
		///
		/// <param name="paymentTransactionLogID">A key for PaymentTransactionLog items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static PaymentTransactionLog GetOnePaymentTransactionLog(Guid paymentTransactionLogID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel)
		{
			Utility.SqlManager dbManager = null;
			MOD.Data.SqlProcAdapter dbAdapter = null;
			try
			{
				// set up adapter
				dbManager = new Utility.SqlManager();
				dbAdapter = dbManager.GetAdapter(debugLevel, dbOptions);
				// perform main method tasks
				MOD.Data.NamedObjectCollection spParameters = new MOD.Data.NamedObjectCollection();
				MOD.Data.NamedObjectCollection filterFields = new MOD.Data.NamedObjectCollection();
				PaymentTransactionLog item = new PaymentTransactionLog();
				spParameters["PaymentTransactionLogID"] = paymentTransactionLogID;
				if(dataOptions != null)
				{
					dataOptions.PopulateNamedObjectCollection( spParameters );
					filterFields = dataOptions.FilterFields;
				}
				DataTable dt = dbAdapter.ExecuteProc("spPayments_GetOnePaymentTransactionLog", null, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				item = null;
				// get output item
				foreach(DataRow row in dt.Rows)
				{
					// get item
					item = (PaymentTransactionLog) DataTransformAttribute.Transform(row, new PaymentTransactionLog(), false, filterFields);
					break;
				}
				return item;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Payments.GetOnePaymentTransactionLog");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method logs PaymentTransactionLog data.</summary>
		///
		/// <param name="item">The PaymentTransactionLog to be logged.</param>
		/// <param name="performCascadeOperation">Peform the changes to the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void LogOnePaymentTransactionLog(PaymentTransactionLog item, bool performCascadeOperation, MOD.Data.DatabaseOptions dbOptions, int debugLevel)
		{
			Utility.SqlManager dbManager = null;
			MOD.Data.SqlProcAdapter dbAdapter = null;
			try
			{
				// set up adapter and transaction
				dbManager = new Utility.SqlManager();
				dbAdapter = dbManager.GetAdapter(debugLevel, dbOptions);
				dbAdapter.Transaction = dbAdapter.Connection.BeginTransaction();
				// perform main method tasks
				LogOnePaymentTransactionLog(item, performCascadeOperation, dbAdapter);
				// commit the transaction
				dbAdapter.Transaction.Commit();
			}
			catch (System.Exception ex)
			{
				try
				{
					dbAdapter.Transaction.Rollback();
				}
				catch {}
				throw Utility.CustomAppException.WrapException(ex, "DAL.Payments.LogOnePaymentTransactionLog");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method logs PaymentTransactionLog data.</summary>
		///
		/// <param name="item">The PaymentTransactionLog to be logged.</param>
		/// <param name="performCascadeOperation">Peform the changes to the child entities of the item, if any exist</param>
		/// <param name="dbAdapter">Database adapter for transaction</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void LogOnePaymentTransactionLog(PaymentTransactionLog item, bool performCascadeOperation, MOD.Data.SqlProcAdapter dbAdapter)
		{
			try
			{
				// perform main method tasks
				MOD.Data.NamedObjectCollection spParameters = new MOD.Data.NamedObjectCollection();
				dbAdapter.ExecuteProcNQ("spPayments_LogOnePaymentTransactionLog", item, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				item.PaymentTransactionLogID = MOD.Data.DataHelper.GetGuid(spParameters["PaymentTransactionLogID"], MOD.Data.DefaultValue.Guid);
				item.Timestamp = ((System.Byte[])(spParameters["Timestamp"]));
				#region Cascade Operations
				if (performCascadeOperation == true)
				{
					// cascade operations
					#region PaymentTransactionAttributeValueLogList
					if (item.PaymentTransactionAttributeValueLogList != null)
					{
						foreach(DAL.Payments.PaymentTransactionAttributeValueLog loopPaymentTransactionAttributeValueLog in item.PaymentTransactionAttributeValueLogList)
						{
							loopPaymentTransactionAttributeValueLog.PaymentTransactionLogID = item.PaymentTransactionLogID;
							// add new item
							DAL.Payments.PaymentTransactionAttributeValueLog.LogOnePaymentTransactionAttributeValueLog(loopPaymentTransactionAttributeValueLog, performCascadeOperation, dbAdapter);
						}
					}
					#endregion PaymentTransactionAttributeValueLogList
				}
				#endregion Cascade Operations
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Payments.LogOnePaymentTransactionLog");
			}
		}
		/// <summary>
		///			 
		/// </summary>
		/// <param name="obj"></param>
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