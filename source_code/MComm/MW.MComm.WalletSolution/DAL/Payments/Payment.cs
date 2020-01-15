
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
	/// <summary>This class is used to hold and manage information for Payment instances.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[Serializable()]
	public partial class Payment : Utility.BaseDataAccessObject
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
		// for PrimaryName property
		protected string _primaryName = MOD.Data.DefaultValue.String;
		// for PrimaryIndex property
		protected string _primaryIndex = MOD.Data.DefaultValue.String;
		// for PrimarySortColumn property
		protected string _primarySortColumn = MOD.Data.DefaultValue.String;
		// for AccountName read only property
		[DataTransform]
		protected string _accountName = MOD.Data.DefaultValue.String;
		// for PaymentStatusName read only property
		[DataTransform]
		protected string _paymentStatusName = MOD.Data.DefaultValue.String;
		// for PaymentTransactionLogList property
		protected MOD.Data.SortableObjectCollection _paymentTransactionLogList = null;
		// for Account property
		protected DAL.Accounts.Account _account = null;
		// for Order property
		protected DAL.Orders.Order _order = null;
		// for PaymentStatus property
		protected DAL.Payments.PaymentStatus _paymentStatus = null;
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
		[XmlArrayItem(typeof(DAL.Payments.PaymentTransactionLog), ElementName="PaymentTransactionLog")]
		[DataTransform]
		public virtual MOD.Data.SortableObjectCollection PaymentTransactionLogList
		{
			get
			{
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
		public virtual DAL.Accounts.Account Account
		{
			get
			{
				return _account;
			}
			set
			{
				_account = value;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of Order.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual DAL.Orders.Order Order
		{
			get
			{
				return _order;
			}
			set
			{
				_order = value;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of PaymentStatus.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual DAL.Payments.PaymentStatus PaymentStatus
		{
			get
			{
				return _paymentStatus;
			}
			set
			{
				_paymentStatus = value;
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
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Payment data by a key.</summary>
		///
		/// <param name="performCascadeOperation">Peform the deletes of the child entities of the item, if any exist</param>
		/// <param name="destinationAccountID">A key for Payment items to be deleted</param>
		/// <param name="creditMetaPartnerID">A key for Payment items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllPaymentDataByDestinationAccountIDAndCreditMetaPartnerID(Guid destinationAccountID, Guid creditMetaPartnerID, MOD.Data.DatabaseOptions dbOptions, int debugLevel)
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
				DeleteAllPaymentDataByDestinationAccountIDAndCreditMetaPartnerID(destinationAccountID, creditMetaPartnerID, dbAdapter);
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
				throw Utility.CustomAppException.WrapException(ex, "DAL.Payments.DeleteAllPaymentDataByDestinationAccountIDAndCreditMetaPartnerID");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Payment data by a key.</summary>
		///
		/// <param name="performCascadeOperation">Peform the deletes of the child entities of the item, if any exist</param>
		/// <param name="destinationAccountID">A key for Payment items to be deleted</param>
		/// <param name="creditMetaPartnerID">A key for Payment items to be deleted</param>
		/// <param name="dbAdapter">Database adapter for transaction</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllPaymentDataByDestinationAccountIDAndCreditMetaPartnerID(Guid destinationAccountID, Guid creditMetaPartnerID, MOD.Data.SqlProcAdapter dbAdapter)
		{
			try
			{
				// perform main method tasks
				MOD.Data.NamedObjectCollection spParameters = new MOD.Data.NamedObjectCollection();
				spParameters["DestinationAccountID"] = destinationAccountID;
				spParameters["CreditMetaPartnerID"] = creditMetaPartnerID;
				dbAdapter.ExecuteProcNQ("spPayments_DeleteAllPaymentDataByDestinationAccountIDAndCreditMetaPartnerID", null, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Payments.DeleteAllPaymentDataByDestinationAccountIDAndCreditMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Payment data by a key.</summary>
		///
		/// <param name="performCascadeOperation">Peform the deletes of the child entities of the item, if any exist</param>
		/// <param name="orderID">A key for Payment items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllPaymentDataByOrderID(Guid orderID, MOD.Data.DatabaseOptions dbOptions, int debugLevel)
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
				DeleteAllPaymentDataByOrderID(orderID, dbAdapter);
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
				throw Utility.CustomAppException.WrapException(ex, "DAL.Payments.DeleteAllPaymentDataByOrderID");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Payment data by a key.</summary>
		///
		/// <param name="performCascadeOperation">Peform the deletes of the child entities of the item, if any exist</param>
		/// <param name="orderID">A key for Payment items to be deleted</param>
		/// <param name="dbAdapter">Database adapter for transaction</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllPaymentDataByOrderID(Guid orderID, MOD.Data.SqlProcAdapter dbAdapter)
		{
			try
			{
				// perform main method tasks
				MOD.Data.NamedObjectCollection spParameters = new MOD.Data.NamedObjectCollection();
				spParameters["OrderID"] = orderID;
				dbAdapter.ExecuteProcNQ("spPayments_DeleteAllPaymentDataByOrderID", null, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Payments.DeleteAllPaymentDataByOrderID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Payment data by a key.</summary>
		///
		/// <param name="performCascadeOperation">Peform the deletes of the child entities of the item, if any exist</param>
		/// <param name="paymentStatusCode">A key for Payment items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllPaymentDataByPaymentStatusCode(int paymentStatusCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel)
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
				DeleteAllPaymentDataByPaymentStatusCode(paymentStatusCode, dbAdapter);
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
				throw Utility.CustomAppException.WrapException(ex, "DAL.Payments.DeleteAllPaymentDataByPaymentStatusCode");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Payment data by a key.</summary>
		///
		/// <param name="performCascadeOperation">Peform the deletes of the child entities of the item, if any exist</param>
		/// <param name="paymentStatusCode">A key for Payment items to be deleted</param>
		/// <param name="dbAdapter">Database adapter for transaction</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllPaymentDataByPaymentStatusCode(int paymentStatusCode, MOD.Data.SqlProcAdapter dbAdapter)
		{
			try
			{
				// perform main method tasks
				MOD.Data.NamedObjectCollection spParameters = new MOD.Data.NamedObjectCollection();
				spParameters["PaymentStatusCode"] = paymentStatusCode;
				dbAdapter.ExecuteProcNQ("spPayments_DeleteAllPaymentDataByPaymentStatusCode", null, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Payments.DeleteAllPaymentDataByPaymentStatusCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Payment data by a key.</summary>
		///
		/// <param name="performCascadeOperation">Peform the deletes of the child entities of the item, if any exist</param>
		/// <param name="sourceAccountID">A key for Payment items to be deleted</param>
		/// <param name="debitMetaPartnerID">A key for Payment items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllPaymentDataBySourceAccountIDAndDebitMetaPartnerID(Guid sourceAccountID, Guid debitMetaPartnerID, MOD.Data.DatabaseOptions dbOptions, int debugLevel)
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
				DeleteAllPaymentDataBySourceAccountIDAndDebitMetaPartnerID(sourceAccountID, debitMetaPartnerID, dbAdapter);
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
				throw Utility.CustomAppException.WrapException(ex, "DAL.Payments.DeleteAllPaymentDataBySourceAccountIDAndDebitMetaPartnerID");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all Payment data by a key.</summary>
		///
		/// <param name="performCascadeOperation">Peform the deletes of the child entities of the item, if any exist</param>
		/// <param name="sourceAccountID">A key for Payment items to be deleted</param>
		/// <param name="debitMetaPartnerID">A key for Payment items to be deleted</param>
		/// <param name="dbAdapter">Database adapter for transaction</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllPaymentDataBySourceAccountIDAndDebitMetaPartnerID(Guid sourceAccountID, Guid debitMetaPartnerID, MOD.Data.SqlProcAdapter dbAdapter)
		{
			try
			{
				// perform main method tasks
				MOD.Data.NamedObjectCollection spParameters = new MOD.Data.NamedObjectCollection();
				spParameters["SourceAccountID"] = sourceAccountID;
				spParameters["DebitMetaPartnerID"] = debitMetaPartnerID;
				dbAdapter.ExecuteProcNQ("spPayments_DeleteAllPaymentDataBySourceAccountIDAndDebitMetaPartnerID", null, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Payments.DeleteAllPaymentDataBySourceAccountIDAndDebitMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes Payment data.</summary>
		///
		/// <param name="item">The Payment to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the changes to the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOnePayment(Payment item, bool performCascadeOperation, MOD.Data.DatabaseOptions dbOptions, int debugLevel)
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
				DeleteOnePayment(item, performCascadeOperation, dbAdapter);
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
				throw Utility.CustomAppException.WrapException(ex, "DAL.Payments.DeleteOnePayment");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes Payment data.</summary>
		///
		/// <param name="item">The Payment to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the changes to the child entities of the item, if any exist</param>
		/// <param name="dbAdapter">Database adapter for transaction</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOnePayment(Payment item, bool performCascadeOperation, MOD.Data.SqlProcAdapter dbAdapter)
		{
			try
			{
				// perform main method tasks
				#region Cascade Operations
				if (performCascadeOperation == true)
				{
					// cascade operations
					if (item.PaymentTransactionLogList != null)
					{
						
					}
				}
				#endregion Cascade Operations
				MOD.Data.NamedObjectCollection spParameters = new MOD.Data.NamedObjectCollection();
				dbAdapter.ExecuteProcNQ("spPayments_DeleteOnePayment", item, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				#region Cascade Operations
				if (performCascadeOperation == true)
				{
					// cascade operations
				}
				#endregion Cascade Operations
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Payments.DeleteOnePayment");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Payment data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetAllPaymentData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel)
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
				DataTable dt = dbAdapter.ExecuteProc("spPayments_GetAllPaymentData", null, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					Payment item = (Payment) DataTransformAttribute.Transform(row, new Payment(), false, filterFields);
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Payments.GetAllPaymentData");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Payment data by criteria.</summary>
		///
		/// <param name="paymentStatusCode">A key for Payment items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Payment items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Payment items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetAllPaymentDataByCriteria(int? paymentStatusCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel)
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
				spParameters["PaymentStatusCode"] = paymentStatusCode;
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
				DataTable dt = dbAdapter.ExecuteProc("spPayments_GetAllPaymentDataByCriteria", null, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					Payment item = (Payment) DataTransformAttribute.Transform(row, new Payment(), false, filterFields);
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Payments.GetAllPaymentDataByCriteria");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Payment data by a key.</summary>
		///
		/// <param name="destinationAccountID">A key for Payment items to be fetched</param>
		/// <param name="creditMetaPartnerID">A key for Payment items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetAllPaymentDataByDestinationAccountIDAndCreditMetaPartnerID(Guid destinationAccountID, Guid creditMetaPartnerID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel)
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
				spParameters["DestinationAccountID"] = destinationAccountID;
				spParameters["CreditMetaPartnerID"] = creditMetaPartnerID;
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
				DataTable dt = dbAdapter.ExecuteProc("spPayments_GetAllPaymentDataByDestinationAccountIDAndCreditMetaPartnerID", null, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					Payment item = (Payment) DataTransformAttribute.Transform(row, new Payment(), false, filterFields);
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Payments.GetAllPaymentDataByDestinationAccountIDAndCreditMetaPartnerID");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Payment data by a key.</summary>
		///
		/// <param name="destinationAccountID">A key for Payment items to be fetched</param>
		/// <param name="creditMetaPartnerID">A key for Payment items to be fetched</param>
		/// <param name="dbAdapter">Database adapter for transaction</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetAllPaymentDataByDestinationAccountIDAndCreditMetaPartnerID(Guid destinationAccountID, Guid creditMetaPartnerID, MOD.Data.SqlProcAdapter dbAdapter)
		{
			try
			{
				// perform main method tasks
				MOD.Data.NamedObjectCollection spParameters = new MOD.Data.NamedObjectCollection();
				MOD.Data.NamedObjectCollection filterFields = new MOD.Data.NamedObjectCollection();
				MOD.Data.SortableObjectCollection items = new MOD.Data.SortableObjectCollection();
				spParameters["DestinationAccountID"] = destinationAccountID;
				spParameters["CreditMetaPartnerID"] = creditMetaPartnerID;
				spParameters["IncludeInactive"] = true;
				spParameters["IncludeDateInactive"] = true;
				DataTable dt = dbAdapter.ExecuteProc("spPayments_GetAllPaymentDataByDestinationAccountIDAndCreditMetaPartnerID", null, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					Payment item = (Payment) DataTransformAttribute.Transform(row, new Payment(), false);
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Payments.GetAllPaymentDataByDestinationAccountIDAndCreditMetaPartnerID");
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Payment data by a key.</summary>
		///
		/// <param name="orderID">A key for Payment items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetAllPaymentDataByOrderID(Guid orderID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel)
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
				spParameters["OrderID"] = orderID;
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
				DataTable dt = dbAdapter.ExecuteProc("spPayments_GetAllPaymentDataByOrderID", null, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					Payment item = (Payment) DataTransformAttribute.Transform(row, new Payment(), false, filterFields);
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Payments.GetAllPaymentDataByOrderID");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Payment data by a key.</summary>
		///
		/// <param name="orderID">A key for Payment items to be fetched</param>
		/// <param name="dbAdapter">Database adapter for transaction</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetAllPaymentDataByOrderID(Guid orderID, MOD.Data.SqlProcAdapter dbAdapter)
		{
			try
			{
				// perform main method tasks
				MOD.Data.NamedObjectCollection spParameters = new MOD.Data.NamedObjectCollection();
				MOD.Data.NamedObjectCollection filterFields = new MOD.Data.NamedObjectCollection();
				MOD.Data.SortableObjectCollection items = new MOD.Data.SortableObjectCollection();
				spParameters["OrderID"] = orderID;
				spParameters["IncludeInactive"] = true;
				spParameters["IncludeDateInactive"] = true;
				DataTable dt = dbAdapter.ExecuteProc("spPayments_GetAllPaymentDataByOrderID", null, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					Payment item = (Payment) DataTransformAttribute.Transform(row, new Payment(), false);
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Payments.GetAllPaymentDataByOrderID");
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Payment data by a key.</summary>
		///
		/// <param name="paymentStatusCode">A key for Payment items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetAllPaymentDataByPaymentStatusCode(int paymentStatusCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel)
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
				spParameters["PaymentStatusCode"] = paymentStatusCode;
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
				DataTable dt = dbAdapter.ExecuteProc("spPayments_GetAllPaymentDataByPaymentStatusCode", null, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					Payment item = (Payment) DataTransformAttribute.Transform(row, new Payment(), false, filterFields);
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Payments.GetAllPaymentDataByPaymentStatusCode");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Payment data by a key.</summary>
		///
		/// <param name="paymentStatusCode">A key for Payment items to be fetched</param>
		/// <param name="dbAdapter">Database adapter for transaction</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetAllPaymentDataByPaymentStatusCode(int paymentStatusCode, MOD.Data.SqlProcAdapter dbAdapter)
		{
			try
			{
				// perform main method tasks
				MOD.Data.NamedObjectCollection spParameters = new MOD.Data.NamedObjectCollection();
				MOD.Data.NamedObjectCollection filterFields = new MOD.Data.NamedObjectCollection();
				MOD.Data.SortableObjectCollection items = new MOD.Data.SortableObjectCollection();
				spParameters["PaymentStatusCode"] = paymentStatusCode;
				spParameters["IncludeInactive"] = true;
				spParameters["IncludeDateInactive"] = true;
				DataTable dt = dbAdapter.ExecuteProc("spPayments_GetAllPaymentDataByPaymentStatusCode", null, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					Payment item = (Payment) DataTransformAttribute.Transform(row, new Payment(), false);
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Payments.GetAllPaymentDataByPaymentStatusCode");
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Payment data by a key.</summary>
		///
		/// <param name="sourceAccountID">A key for Payment items to be fetched</param>
		/// <param name="debitMetaPartnerID">A key for Payment items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetAllPaymentDataBySourceAccountIDAndDebitMetaPartnerID(Guid sourceAccountID, Guid debitMetaPartnerID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel)
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
				spParameters["SourceAccountID"] = sourceAccountID;
				spParameters["DebitMetaPartnerID"] = debitMetaPartnerID;
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
				DataTable dt = dbAdapter.ExecuteProc("spPayments_GetAllPaymentDataBySourceAccountIDAndDebitMetaPartnerID", null, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					Payment item = (Payment) DataTransformAttribute.Transform(row, new Payment(), false, filterFields);
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Payments.GetAllPaymentDataBySourceAccountIDAndDebitMetaPartnerID");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Payment data by a key.</summary>
		///
		/// <param name="sourceAccountID">A key for Payment items to be fetched</param>
		/// <param name="debitMetaPartnerID">A key for Payment items to be fetched</param>
		/// <param name="dbAdapter">Database adapter for transaction</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetAllPaymentDataBySourceAccountIDAndDebitMetaPartnerID(Guid sourceAccountID, Guid debitMetaPartnerID, MOD.Data.SqlProcAdapter dbAdapter)
		{
			try
			{
				// perform main method tasks
				MOD.Data.NamedObjectCollection spParameters = new MOD.Data.NamedObjectCollection();
				MOD.Data.NamedObjectCollection filterFields = new MOD.Data.NamedObjectCollection();
				MOD.Data.SortableObjectCollection items = new MOD.Data.SortableObjectCollection();
				spParameters["SourceAccountID"] = sourceAccountID;
				spParameters["DebitMetaPartnerID"] = debitMetaPartnerID;
				spParameters["IncludeInactive"] = true;
				spParameters["IncludeDateInactive"] = true;
				DataTable dt = dbAdapter.ExecuteProc("spPayments_GetAllPaymentDataBySourceAccountIDAndDebitMetaPartnerID", null, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					Payment item = (Payment) DataTransformAttribute.Transform(row, new Payment(), false);
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Payments.GetAllPaymentDataBySourceAccountIDAndDebitMetaPartnerID");
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets many Payment data by criteria.</summary>
		///
		/// <param name="paymentStatusCode">A key for Payment items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Payment items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Payment items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetManyPaymentDataByCriteria(int? paymentStatusCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel)
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
				spParameters["PaymentStatusCode"] = paymentStatusCode;
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
				DataTable dt = dbAdapter.ExecuteProc("spPayments_GetManyPaymentDataByCriteria", null, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				totalRecords = MOD.Data.DataHelper.GetInt(spParameters["TotalRecords"], MOD.Data.DefaultValue.Int);
				maximumListSizeExceeded = MOD.Data.DataHelper.GetBool(spParameters["MaximumListSizeExceeded"], MOD.Data.DefaultValue.Bool);
				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					Payment item = (Payment) DataTransformAttribute.Transform(row, new Payment(), false, filterFields);
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Payments.GetManyPaymentDataByCriteria");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single Payment by an index.</summary>
		///
		/// <param name="paymentID">A key for Payment items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static Payment GetOnePayment(Guid paymentID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel)
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
				Payment item = new Payment();
				spParameters["PaymentID"] = paymentID;
				if(dataOptions != null)
				{
					dataOptions.PopulateNamedObjectCollection( spParameters );
					filterFields = dataOptions.FilterFields;
				}
				DataTable dt = dbAdapter.ExecuteProc("spPayments_GetOnePayment", null, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				item = null;
				// get output item
				foreach(DataRow row in dt.Rows)
				{
					// get item
					item = (Payment) DataTransformAttribute.Transform(row, new Payment(), false, filterFields);
					break;
				}
				return item;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Payments.GetOnePayment");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method inserts or updates Payment data.</summary>
		///
		/// <param name="item">The Payment to be inserted or updated.</param>
		/// <param name="performCascadeOperation">Peform the changes to the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpsertOnePayment(Payment item, bool performCascadeOperation, MOD.Data.DatabaseOptions dbOptions, int debugLevel)
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
				UpsertOnePayment(item, performCascadeOperation, dbAdapter);
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
				throw Utility.CustomAppException.WrapException(ex, "DAL.Payments.UpsertOnePayment");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method inserts or updates Payment data.</summary>
		///
		/// <param name="item">The Payment to be inserted or updated.</param>
		/// <param name="performCascadeOperation">Peform the changes to the child entities of the item, if any exist</param>
		/// <param name="dbAdapter">Database adapter for transaction</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpsertOnePayment(Payment item, bool performCascadeOperation, MOD.Data.SqlProcAdapter dbAdapter)
		{
			try
			{
				// perform main method tasks
				MOD.Data.NamedObjectCollection spParameters = new MOD.Data.NamedObjectCollection();
				dbAdapter.ExecuteProcNQ("spPayments_UpsertOnePayment", item, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				item.PaymentID = MOD.Data.DataHelper.GetGuid(spParameters["PaymentID"], MOD.Data.DefaultValue.Guid);
				item.Timestamp = ((System.Byte[])(spParameters["Timestamp"]));
				#region Cascade Operations
				if (performCascadeOperation == true)
				{
					// cascade operations
					#region PaymentTransactionLogList
					if (item.PaymentTransactionLogList != null)
					{
						MOD.Data.SortableObjectCollection paymentTransactionLogList = DAL.Payments.PaymentTransactionLog.GetAllPaymentTransactionLogDataByPaymentID(item.PaymentID, dbAdapter);
						foreach(DAL.Payments.PaymentTransactionLog loopPaymentTransactionLog in item.PaymentTransactionLogList)
						{
							loopPaymentTransactionLog.PaymentID = item.PaymentID;
							// add new item
							DAL.Payments.PaymentTransactionLog.LogOnePaymentTransactionLog(loopPaymentTransactionLog, performCascadeOperation, dbAdapter);
						}
					}
					#endregion PaymentTransactionLogList
				}
				#endregion Cascade Operations
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Payments.UpsertOnePayment");
			}
		}
		/// <summary>
		///			 
		/// </summary>
		/// <param name="obj"></param>
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