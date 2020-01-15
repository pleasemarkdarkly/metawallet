
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
namespace MW.MComm.WalletSolution.DAL.Customers
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to hold and manage information for MetaPartner instances.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[Serializable()]
	public partial class MetaPartner : Utility.BaseDataAccessObject
	{
		#region Constants
		#endregion Constants
		#region Fields
		// for MetaPartnerID property
		protected Guid _metaPartnerID = MOD.Data.DefaultValue.Guid;
		// for MetaPartnerSubTypeCode property
		protected int _metaPartnerSubTypeCode = MOD.Data.DefaultValue.Int;
		// for LocaleCode property
		protected int _localeCode = MOD.Data.DefaultValue.Int;
		// for CurrencyCode property
		protected int _currencyCode = MOD.Data.DefaultValue.Int;
		// for DateFormatCode property
		protected int _dateFormatCode = MOD.Data.DefaultValue.Int;
		// for TaxCode property
		protected string _taxCode = null;
		// for IsActive property
		protected bool? _isActive = true;
		// for MetaPartnerName property
		protected string _metaPartnerName = MOD.Data.DefaultValue.String;
		// for PictureImageURL property
		protected string _pictureImageURL = null;
		// for PrimaryName property
		protected string _primaryName = MOD.Data.DefaultValue.String;
		// for PrimaryIndex property
		protected string _primaryIndex = MOD.Data.DefaultValue.String;
		// for PrimarySortColumn property
		protected string _primarySortColumn = MOD.Data.DefaultValue.String;
		// for MetaPartnerSubTypeName read only property
		[DataTransform]
		protected string _metaPartnerSubTypeName = MOD.Data.DefaultValue.String;
		// for LocaleName read only property
		[DataTransform]
		protected string _localeName = MOD.Data.DefaultValue.String;
		// for CurrencyName read only property
		[DataTransform]
		protected string _currencyName = MOD.Data.DefaultValue.String;
		// for DateFormatName read only property
		[DataTransform]
		protected string _dateFormatName = MOD.Data.DefaultValue.String;
		// for PhoneList property
		protected MOD.Data.SortableObjectCollection _phoneList = null;
		// for EmailList property
		protected MOD.Data.SortableObjectCollection _emailList = null;
		// for LocationList property
		protected MOD.Data.SortableObjectCollection _locationList = null;
		// for BankAccountList property
		protected MOD.Data.SortableObjectCollection _bankAccountList = null;
		// for StoredValueAccountList property
		protected MOD.Data.SortableObjectCollection _storedValueAccountList = null;
		// for CreditAccountList property
		protected MOD.Data.SortableObjectCollection _creditAccountList = null;
		// for FundAccountList property
		protected MOD.Data.SortableObjectCollection _fundAccountList = null;
		// for BillPayAccountList property
		protected MOD.Data.SortableObjectCollection _billPayAccountList = null;
		// for MetaTransferAccountList property
		protected MOD.Data.SortableObjectCollection _metaTransferAccountList = null;
		// for LoanAccountList property
		protected MOD.Data.SortableObjectCollection _loanAccountList = null;
		// for MetaPartnerCouponList property
		protected MOD.Data.SortableObjectCollection _metaPartnerCouponList = null;
		// for Currency property
		protected DAL.Accounts.Currency _currency = null;
		// for MetaPartnerSubType property
		protected DAL.Customers.MetaPartnerSubType _metaPartnerSubType = null;
		// for DateFormat property
		protected DAL.Environments.DateFormat _dateFormat = null;
		// for Locale property
		protected DAL.Environments.Locale _locale = null;
		#endregion Fields
		#region Properties
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
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the MetaPartnerSubTypeCode.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Int)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual int MetaPartnerSubTypeCode
		{
			get
			{
				return _metaPartnerSubTypeCode;
			}
			set
			{
				if (_metaPartnerSubTypeCode != value)
				{
					_metaPartnerSubTypeCode = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the LocaleCode.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Int)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual int LocaleCode
		{
			get
			{
				return _localeCode;
			}
			set
			{
				if (_localeCode != value)
				{
					_localeCode = value;
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
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the DateFormatCode.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Int)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual int DateFormatCode
		{
			get
			{
				return _dateFormatCode;
			}
			set
			{
				if (_dateFormatCode != value)
				{
					_dateFormatCode = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the TaxCode.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(null)]
		[XmlElementAttribute(IsNullable=true)]
		[DataTransform]
		public virtual string TaxCode
		{
			get
			{
				return _taxCode;
			}
			set
			{
				if ((_taxCode != null && !_taxCode.Equals(value)) || _taxCode != value)
				{
					_taxCode = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the IsActive.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(null)]
		[XmlElementAttribute(IsNullable=true)]
		[DataTransform]
		public virtual bool? IsActive
		{
			get
			{
				return _isActive;
			}
			set
			{
				if ((_isActive != null && !_isActive.Equals(value)) || _isActive != value)
				{
					_isActive = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the MetaPartnerName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual string MetaPartnerName
		{
			get
			{
				return _metaPartnerName;
			}
			set
			{
				if ((_metaPartnerName != null && !_metaPartnerName.Equals(value)) || _metaPartnerName != value)
				{
					_metaPartnerName = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the PictureImageURL.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(null)]
		[XmlElementAttribute(IsNullable=true)]
		[DataTransform]
		public virtual string PictureImageURL
		{
			get
			{
				return _pictureImageURL;
			}
			set
			{
				if ((_pictureImageURL != null && !_pictureImageURL.Equals(value)) || _pictureImageURL != value)
				{
					_pictureImageURL = value;
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
				return (MOD.Data.DataHelper.GetString(MetaPartnerID,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					MetaPartnerID = MOD.Data.DataHelper.GetGuid(keyValues[0], MOD.Data.DefaultValue.Guid);
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
				return (MOD.Data.DataHelper.GetString(MetaPartnerID,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					MetaPartnerID = MOD.Data.DataHelper.GetGuid(keyValues[0], MOD.Data.DefaultValue.Guid);
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
		/// <summary>This read only property gets the MetaPartnerSubTypeName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		public virtual string MetaPartnerSubTypeName
		{
			get
			{
				return _metaPartnerSubTypeName;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This read only property gets the LocaleName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		public virtual string LocaleName
		{
			get
			{
				return _localeName;
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
		/// <summary>This read only property gets the DateFormatName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		public virtual string DateFormatName
		{
			get
			{
				return _dateFormatName;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets MetaPartnerPhone lists.</summary>
		// ------------------------------------------------------------------------------
		[XmlArrayItem(typeof(DAL.Customers.MetaPartnerPhone), ElementName="MetaPartnerPhone")]
		[DataTransform]
		public virtual MOD.Data.SortableObjectCollection PhoneList
		{
			get
			{
				return _phoneList;
			}
			set
			{
				if (value == null)
				{
					_phoneList = value;
				}
				else if ((_phoneList == null && value != null) ||
					  !_phoneList.Equals(value))
				{
					_phoneList = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets MetaPartnerEmail lists.</summary>
		// ------------------------------------------------------------------------------
		[XmlArrayItem(typeof(DAL.Customers.MetaPartnerEmail), ElementName="MetaPartnerEmail")]
		[DataTransform]
		public virtual MOD.Data.SortableObjectCollection EmailList
		{
			get
			{
				return _emailList;
			}
			set
			{
				if (value == null)
				{
					_emailList = value;
				}
				else if ((_emailList == null && value != null) ||
					  !_emailList.Equals(value))
				{
					_emailList = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets Location lists.</summary>
		// ------------------------------------------------------------------------------
		[XmlArrayItem(typeof(DAL.Customers.Location), ElementName="Location")]
		[DataTransform]
		public virtual MOD.Data.SortableObjectCollection LocationList
		{
			get
			{
				return _locationList;
			}
			set
			{
				if (value == null)
				{
					_locationList = value;
				}
				else if ((_locationList == null && value != null) ||
					  !_locationList.Equals(value))
				{
					_locationList = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets BankAccount lists.</summary>
		// ------------------------------------------------------------------------------
		[XmlArrayItem(typeof(DAL.Accounts.BankAccount), ElementName="BankAccount")]
		[DataTransform]
		public virtual MOD.Data.SortableObjectCollection BankAccountList
		{
			get
			{
				return _bankAccountList;
			}
			set
			{
				if (value == null)
				{
					_bankAccountList = value;
				}
				else if ((_bankAccountList == null && value != null) ||
					  !_bankAccountList.Equals(value))
				{
					_bankAccountList = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets StoredValueAccount lists.</summary>
		// ------------------------------------------------------------------------------
		[XmlArrayItem(typeof(DAL.Accounts.StoredValueAccount), ElementName="StoredValueAccount")]
		[DataTransform]
		public virtual MOD.Data.SortableObjectCollection StoredValueAccountList
		{
			get
			{
				return _storedValueAccountList;
			}
			set
			{
				if (value == null)
				{
					_storedValueAccountList = value;
				}
				else if ((_storedValueAccountList == null && value != null) ||
					  !_storedValueAccountList.Equals(value))
				{
					_storedValueAccountList = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets CreditAccount lists.</summary>
		// ------------------------------------------------------------------------------
		[XmlArrayItem(typeof(DAL.Accounts.CreditAccount), ElementName="CreditAccount")]
		[DataTransform]
		public virtual MOD.Data.SortableObjectCollection CreditAccountList
		{
			get
			{
				return _creditAccountList;
			}
			set
			{
				if (value == null)
				{
					_creditAccountList = value;
				}
				else if ((_creditAccountList == null && value != null) ||
					  !_creditAccountList.Equals(value))
				{
					_creditAccountList = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets FundAccount lists.</summary>
		// ------------------------------------------------------------------------------
		[XmlArrayItem(typeof(DAL.Accounts.FundAccount), ElementName="FundAccount")]
		[DataTransform]
		public virtual MOD.Data.SortableObjectCollection FundAccountList
		{
			get
			{
				return _fundAccountList;
			}
			set
			{
				if (value == null)
				{
					_fundAccountList = value;
				}
				else if ((_fundAccountList == null && value != null) ||
					  !_fundAccountList.Equals(value))
				{
					_fundAccountList = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets BillPayAccount lists.</summary>
		// ------------------------------------------------------------------------------
		[XmlArrayItem(typeof(DAL.Accounts.BillPayAccount), ElementName="BillPayAccount")]
		[DataTransform]
		public virtual MOD.Data.SortableObjectCollection BillPayAccountList
		{
			get
			{
				return _billPayAccountList;
			}
			set
			{
				if (value == null)
				{
					_billPayAccountList = value;
				}
				else if ((_billPayAccountList == null && value != null) ||
					  !_billPayAccountList.Equals(value))
				{
					_billPayAccountList = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets MetaTransferAccount lists.</summary>
		// ------------------------------------------------------------------------------
		[XmlArrayItem(typeof(DAL.Accounts.MetaTransferAccount), ElementName="MetaTransferAccount")]
		[DataTransform]
		public virtual MOD.Data.SortableObjectCollection MetaTransferAccountList
		{
			get
			{
				return _metaTransferAccountList;
			}
			set
			{
				if (value == null)
				{
					_metaTransferAccountList = value;
				}
				else if ((_metaTransferAccountList == null && value != null) ||
					  !_metaTransferAccountList.Equals(value))
				{
					_metaTransferAccountList = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets LoanAccount lists.</summary>
		// ------------------------------------------------------------------------------
		[XmlArrayItem(typeof(DAL.Accounts.LoanAccount), ElementName="LoanAccount")]
		[DataTransform]
		public virtual MOD.Data.SortableObjectCollection LoanAccountList
		{
			get
			{
				return _loanAccountList;
			}
			set
			{
				if (value == null)
				{
					_loanAccountList = value;
				}
				else if ((_loanAccountList == null && value != null) ||
					  !_loanAccountList.Equals(value))
				{
					_loanAccountList = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets MetaPartnerCoupon lists.</summary>
		// ------------------------------------------------------------------------------
		[XmlArrayItem(typeof(DAL.Promotions.MetaPartnerCoupon), ElementName="MetaPartnerCoupon")]
		[DataTransform]
		public virtual MOD.Data.SortableObjectCollection MetaPartnerCouponList
		{
			get
			{
				return _metaPartnerCouponList;
			}
			set
			{
				if (value == null)
				{
					_metaPartnerCouponList = value;
				}
				else if ((_metaPartnerCouponList == null && value != null) ||
					  !_metaPartnerCouponList.Equals(value))
				{
					_metaPartnerCouponList = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of Currency.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual DAL.Accounts.Currency Currency
		{
			get
			{
				return _currency;
			}
			set
			{
				_currency = value;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of MetaPartnerSubType.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual DAL.Customers.MetaPartnerSubType MetaPartnerSubType
		{
			get
			{
				return _metaPartnerSubType;
			}
			set
			{
				_metaPartnerSubType = value;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of DateFormat.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual DAL.Environments.DateFormat DateFormat
		{
			get
			{
				return _dateFormat;
			}
			set
			{
				_dateFormat = value;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of Locale.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual DAL.Environments.Locale Locale
		{
			get
			{
				return _locale;
			}
			set
			{
				_locale = value;
			}
		}
		#endregion Properties
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public MetaPartner()
		{
			//
			// constructor logic
			//
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method creates an instance with the primary key values.</summary>
		// ------------------------------------------------------------------------------
		public MetaPartner(string keyValues, bool isPrimaryKeyValues)
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
		/// <summary>This method deletes all MetaPartner data by a key.</summary>
		///
		/// <param name="performCascadeOperation">Peform the deletes of the child entities of the item, if any exist</param>
		/// <param name="currencyCode">A key for MetaPartner items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllMetaPartnerDataByCurrencyCode(int currencyCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel)
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
				DeleteAllMetaPartnerDataByCurrencyCode(currencyCode, dbAdapter);
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
				throw Utility.CustomAppException.WrapException(ex, "DAL.Customers.DeleteAllMetaPartnerDataByCurrencyCode");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all MetaPartner data by a key.</summary>
		///
		/// <param name="performCascadeOperation">Peform the deletes of the child entities of the item, if any exist</param>
		/// <param name="currencyCode">A key for MetaPartner items to be deleted</param>
		/// <param name="dbAdapter">Database adapter for transaction</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllMetaPartnerDataByCurrencyCode(int currencyCode, MOD.Data.SqlProcAdapter dbAdapter)
		{
			try
			{
				// perform main method tasks
				MOD.Data.NamedObjectCollection spParameters = new MOD.Data.NamedObjectCollection();
				spParameters["CurrencyCode"] = currencyCode;
				dbAdapter.ExecuteProcNQ("spCustomers_DeleteAllMetaPartnerDataByCurrencyCode", null, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Customers.DeleteAllMetaPartnerDataByCurrencyCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all MetaPartner data by a key.</summary>
		///
		/// <param name="performCascadeOperation">Peform the deletes of the child entities of the item, if any exist</param>
		/// <param name="dateFormatCode">A key for MetaPartner items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllMetaPartnerDataByDateFormatCode(int dateFormatCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel)
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
				DeleteAllMetaPartnerDataByDateFormatCode(dateFormatCode, dbAdapter);
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
				throw Utility.CustomAppException.WrapException(ex, "DAL.Customers.DeleteAllMetaPartnerDataByDateFormatCode");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all MetaPartner data by a key.</summary>
		///
		/// <param name="performCascadeOperation">Peform the deletes of the child entities of the item, if any exist</param>
		/// <param name="dateFormatCode">A key for MetaPartner items to be deleted</param>
		/// <param name="dbAdapter">Database adapter for transaction</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllMetaPartnerDataByDateFormatCode(int dateFormatCode, MOD.Data.SqlProcAdapter dbAdapter)
		{
			try
			{
				// perform main method tasks
				MOD.Data.NamedObjectCollection spParameters = new MOD.Data.NamedObjectCollection();
				spParameters["DateFormatCode"] = dateFormatCode;
				dbAdapter.ExecuteProcNQ("spCustomers_DeleteAllMetaPartnerDataByDateFormatCode", null, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Customers.DeleteAllMetaPartnerDataByDateFormatCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all MetaPartner data by a key.</summary>
		///
		/// <param name="performCascadeOperation">Peform the deletes of the child entities of the item, if any exist</param>
		/// <param name="localeCode">A key for MetaPartner items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllMetaPartnerDataByLocaleCode(int localeCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel)
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
				DeleteAllMetaPartnerDataByLocaleCode(localeCode, dbAdapter);
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
				throw Utility.CustomAppException.WrapException(ex, "DAL.Customers.DeleteAllMetaPartnerDataByLocaleCode");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all MetaPartner data by a key.</summary>
		///
		/// <param name="performCascadeOperation">Peform the deletes of the child entities of the item, if any exist</param>
		/// <param name="localeCode">A key for MetaPartner items to be deleted</param>
		/// <param name="dbAdapter">Database adapter for transaction</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllMetaPartnerDataByLocaleCode(int localeCode, MOD.Data.SqlProcAdapter dbAdapter)
		{
			try
			{
				// perform main method tasks
				MOD.Data.NamedObjectCollection spParameters = new MOD.Data.NamedObjectCollection();
				spParameters["LocaleCode"] = localeCode;
				dbAdapter.ExecuteProcNQ("spCustomers_DeleteAllMetaPartnerDataByLocaleCode", null, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Customers.DeleteAllMetaPartnerDataByLocaleCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all MetaPartner data by a key.</summary>
		///
		/// <param name="performCascadeOperation">Peform the deletes of the child entities of the item, if any exist</param>
		/// <param name="metaPartnerSubTypeCode">A key for MetaPartner items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllMetaPartnerDataByMetaPartnerSubTypeCode(int metaPartnerSubTypeCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel)
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
				DeleteAllMetaPartnerDataByMetaPartnerSubTypeCode(metaPartnerSubTypeCode, dbAdapter);
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
				throw Utility.CustomAppException.WrapException(ex, "DAL.Customers.DeleteAllMetaPartnerDataByMetaPartnerSubTypeCode");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all MetaPartner data by a key.</summary>
		///
		/// <param name="performCascadeOperation">Peform the deletes of the child entities of the item, if any exist</param>
		/// <param name="metaPartnerSubTypeCode">A key for MetaPartner items to be deleted</param>
		/// <param name="dbAdapter">Database adapter for transaction</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllMetaPartnerDataByMetaPartnerSubTypeCode(int metaPartnerSubTypeCode, MOD.Data.SqlProcAdapter dbAdapter)
		{
			try
			{
				// perform main method tasks
				MOD.Data.NamedObjectCollection spParameters = new MOD.Data.NamedObjectCollection();
				spParameters["MetaPartnerSubTypeCode"] = metaPartnerSubTypeCode;
				dbAdapter.ExecuteProcNQ("spCustomers_DeleteAllMetaPartnerDataByMetaPartnerSubTypeCode", null, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Customers.DeleteAllMetaPartnerDataByMetaPartnerSubTypeCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes MetaPartner data.</summary>
		///
		/// <param name="item">The MetaPartner to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the changes to the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneMetaPartner(MetaPartner item, bool performCascadeOperation, MOD.Data.DatabaseOptions dbOptions, int debugLevel)
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
				DeleteOneMetaPartner(item, performCascadeOperation, dbAdapter);
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
				throw Utility.CustomAppException.WrapException(ex, "DAL.Customers.DeleteOneMetaPartner");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes MetaPartner data.</summary>
		///
		/// <param name="item">The MetaPartner to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the changes to the child entities of the item, if any exist</param>
		/// <param name="dbAdapter">Database adapter for transaction</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneMetaPartner(MetaPartner item, bool performCascadeOperation, MOD.Data.SqlProcAdapter dbAdapter)
		{
			try
			{
				// perform main method tasks
				#region Cascade Operations
				if (performCascadeOperation == true)
				{
					// cascade operations
					if (item.PhoneList != null)
					{
						DAL.Customers.MetaPartnerPhone.DeleteAllMetaPartnerPhoneDataByMetaPartnerID(item.MetaPartnerID, dbAdapter);
					}
					if (item.EmailList != null)
					{
						DAL.Customers.MetaPartnerEmail.DeleteAllMetaPartnerEmailDataByMetaPartnerID(item.MetaPartnerID, dbAdapter);
					}
					if (item.LocationList != null)
					{
						DAL.Customers.Location.DeleteAllLocationDataByMetaPartnerID(item.MetaPartnerID, dbAdapter);
					}
					if (item.BankAccountList != null)
					{
						DAL.Accounts.BankAccount.DeleteAllBankAccountDataByMetaPartnerID(item.MetaPartnerID, dbAdapter);
					}
					if (item.StoredValueAccountList != null)
					{
						DAL.Accounts.StoredValueAccount.DeleteAllStoredValueAccountDataByMetaPartnerID(item.MetaPartnerID, dbAdapter);
					}
					if (item.CreditAccountList != null)
					{
						DAL.Accounts.CreditAccount.DeleteAllCreditAccountDataByMetaPartnerID(item.MetaPartnerID, dbAdapter);
					}
					if (item.FundAccountList != null)
					{
						DAL.Accounts.FundAccount.DeleteAllFundAccountDataByMetaPartnerID(item.MetaPartnerID, dbAdapter);
					}
					if (item.BillPayAccountList != null)
					{
						DAL.Accounts.BillPayAccount.DeleteAllBillPayAccountDataByMetaPartnerID(item.MetaPartnerID, dbAdapter);
					}
					if (item.MetaTransferAccountList != null)
					{
						DAL.Accounts.MetaTransferAccount.DeleteAllMetaTransferAccountDataByMetaPartnerID(item.MetaPartnerID, dbAdapter);
					}
					if (item.LoanAccountList != null)
					{
						DAL.Accounts.LoanAccount.DeleteAllLoanAccountDataByMetaPartnerID(item.MetaPartnerID, dbAdapter);
					}
					if (item.MetaPartnerCouponList != null)
					{
						DAL.Promotions.MetaPartnerCoupon.DeleteAllMetaPartnerCouponDataByMetaPartnerID(item.MetaPartnerID, dbAdapter);
					}
				}
				#endregion Cascade Operations
				MOD.Data.NamedObjectCollection spParameters = new MOD.Data.NamedObjectCollection();
				dbAdapter.ExecuteProcNQ("spCustomers_DeleteOneMetaPartner", item, spParameters);
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
				throw Utility.CustomAppException.WrapException(ex, "DAL.Customers.DeleteOneMetaPartner");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartner data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetAllMetaPartnerData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel)
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
				DataTable dt = dbAdapter.ExecuteProc("spCustomers_GetAllMetaPartnerData", null, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					MetaPartner item = (MetaPartner) DataTransformAttribute.Transform(row, new MetaPartner(), false, filterFields);
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Customers.GetAllMetaPartnerData");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartner data by criteria.</summary>
		///
		/// <param name="metaPartnerSubTypeCode">A key for MetaPartner items to be fetched</param>
		/// <param name="localeCode">A key for MetaPartner items to be fetched</param>
		/// <param name="currencyCode">A key for MetaPartner items to be fetched</param>
		/// <param name="dateFormatCode">A key for MetaPartner items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for MetaPartner items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for MetaPartner items to be fetched</param>
		/// <param name="metaPartnerName">A key for MetaPartner items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetAllMetaPartnerDataByCriteria(int? metaPartnerSubTypeCode, int? localeCode, int? currencyCode, int? dateFormatCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, string metaPartnerName, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel)
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
				spParameters["MetaPartnerSubTypeCode"] = metaPartnerSubTypeCode;
				spParameters["LocaleCode"] = localeCode;
				spParameters["CurrencyCode"] = currencyCode;
				spParameters["DateFormatCode"] = dateFormatCode;
				spParameters["LastModifiedDateStart"] = lastModifiedDateStart;
				spParameters["LastModifiedDateEnd"] = lastModifiedDateEnd;
				spParameters["MetaPartnerName"] = MOD.Data.SearchHelper.ReplaceSpecialSQLSearchChars(metaPartnerName);
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
				DataTable dt = dbAdapter.ExecuteProc("spCustomers_GetAllMetaPartnerDataByCriteria", null, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					MetaPartner item = (MetaPartner) DataTransformAttribute.Transform(row, new MetaPartner(), false, filterFields);
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Customers.GetAllMetaPartnerDataByCriteria");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartner data by a key.</summary>
		///
		/// <param name="currencyCode">A key for MetaPartner items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetAllMetaPartnerDataByCurrencyCode(int currencyCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel)
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
				spParameters["CurrencyCode"] = currencyCode;
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
				DataTable dt = dbAdapter.ExecuteProc("spCustomers_GetAllMetaPartnerDataByCurrencyCode", null, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					MetaPartner item = (MetaPartner) DataTransformAttribute.Transform(row, new MetaPartner(), false, filterFields);
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Customers.GetAllMetaPartnerDataByCurrencyCode");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartner data by a key.</summary>
		///
		/// <param name="currencyCode">A key for MetaPartner items to be fetched</param>
		/// <param name="dbAdapter">Database adapter for transaction</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetAllMetaPartnerDataByCurrencyCode(int currencyCode, MOD.Data.SqlProcAdapter dbAdapter)
		{
			try
			{
				// perform main method tasks
				MOD.Data.NamedObjectCollection spParameters = new MOD.Data.NamedObjectCollection();
				MOD.Data.NamedObjectCollection filterFields = new MOD.Data.NamedObjectCollection();
				MOD.Data.SortableObjectCollection items = new MOD.Data.SortableObjectCollection();
				spParameters["CurrencyCode"] = currencyCode;
				spParameters["IncludeInactive"] = true;
				spParameters["IncludeDateInactive"] = true;
				DataTable dt = dbAdapter.ExecuteProc("spCustomers_GetAllMetaPartnerDataByCurrencyCode", null, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					MetaPartner item = (MetaPartner) DataTransformAttribute.Transform(row, new MetaPartner(), false);
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Customers.GetAllMetaPartnerDataByCurrencyCode");
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartner data by a key.</summary>
		///
		/// <param name="dateFormatCode">A key for MetaPartner items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetAllMetaPartnerDataByDateFormatCode(int dateFormatCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel)
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
				spParameters["DateFormatCode"] = dateFormatCode;
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
				DataTable dt = dbAdapter.ExecuteProc("spCustomers_GetAllMetaPartnerDataByDateFormatCode", null, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					MetaPartner item = (MetaPartner) DataTransformAttribute.Transform(row, new MetaPartner(), false, filterFields);
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Customers.GetAllMetaPartnerDataByDateFormatCode");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartner data by a key.</summary>
		///
		/// <param name="dateFormatCode">A key for MetaPartner items to be fetched</param>
		/// <param name="dbAdapter">Database adapter for transaction</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetAllMetaPartnerDataByDateFormatCode(int dateFormatCode, MOD.Data.SqlProcAdapter dbAdapter)
		{
			try
			{
				// perform main method tasks
				MOD.Data.NamedObjectCollection spParameters = new MOD.Data.NamedObjectCollection();
				MOD.Data.NamedObjectCollection filterFields = new MOD.Data.NamedObjectCollection();
				MOD.Data.SortableObjectCollection items = new MOD.Data.SortableObjectCollection();
				spParameters["DateFormatCode"] = dateFormatCode;
				spParameters["IncludeInactive"] = true;
				spParameters["IncludeDateInactive"] = true;
				DataTable dt = dbAdapter.ExecuteProc("spCustomers_GetAllMetaPartnerDataByDateFormatCode", null, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					MetaPartner item = (MetaPartner) DataTransformAttribute.Transform(row, new MetaPartner(), false);
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Customers.GetAllMetaPartnerDataByDateFormatCode");
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartner data by a key.</summary>
		///
		/// <param name="localeCode">A key for MetaPartner items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetAllMetaPartnerDataByLocaleCode(int localeCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel)
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
				spParameters["LocaleCode"] = localeCode;
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
				DataTable dt = dbAdapter.ExecuteProc("spCustomers_GetAllMetaPartnerDataByLocaleCode", null, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					MetaPartner item = (MetaPartner) DataTransformAttribute.Transform(row, new MetaPartner(), false, filterFields);
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Customers.GetAllMetaPartnerDataByLocaleCode");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartner data by a key.</summary>
		///
		/// <param name="localeCode">A key for MetaPartner items to be fetched</param>
		/// <param name="dbAdapter">Database adapter for transaction</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetAllMetaPartnerDataByLocaleCode(int localeCode, MOD.Data.SqlProcAdapter dbAdapter)
		{
			try
			{
				// perform main method tasks
				MOD.Data.NamedObjectCollection spParameters = new MOD.Data.NamedObjectCollection();
				MOD.Data.NamedObjectCollection filterFields = new MOD.Data.NamedObjectCollection();
				MOD.Data.SortableObjectCollection items = new MOD.Data.SortableObjectCollection();
				spParameters["LocaleCode"] = localeCode;
				spParameters["IncludeInactive"] = true;
				spParameters["IncludeDateInactive"] = true;
				DataTable dt = dbAdapter.ExecuteProc("spCustomers_GetAllMetaPartnerDataByLocaleCode", null, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					MetaPartner item = (MetaPartner) DataTransformAttribute.Transform(row, new MetaPartner(), false);
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Customers.GetAllMetaPartnerDataByLocaleCode");
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartner data by a key.</summary>
		///
		/// <param name="metaPartnerSubTypeCode">A key for MetaPartner items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetAllMetaPartnerDataByMetaPartnerSubTypeCode(int metaPartnerSubTypeCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel)
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
				spParameters["MetaPartnerSubTypeCode"] = metaPartnerSubTypeCode;
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
				DataTable dt = dbAdapter.ExecuteProc("spCustomers_GetAllMetaPartnerDataByMetaPartnerSubTypeCode", null, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					MetaPartner item = (MetaPartner) DataTransformAttribute.Transform(row, new MetaPartner(), false, filterFields);
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Customers.GetAllMetaPartnerDataByMetaPartnerSubTypeCode");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartner data by a key.</summary>
		///
		/// <param name="metaPartnerSubTypeCode">A key for MetaPartner items to be fetched</param>
		/// <param name="dbAdapter">Database adapter for transaction</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetAllMetaPartnerDataByMetaPartnerSubTypeCode(int metaPartnerSubTypeCode, MOD.Data.SqlProcAdapter dbAdapter)
		{
			try
			{
				// perform main method tasks
				MOD.Data.NamedObjectCollection spParameters = new MOD.Data.NamedObjectCollection();
				MOD.Data.NamedObjectCollection filterFields = new MOD.Data.NamedObjectCollection();
				MOD.Data.SortableObjectCollection items = new MOD.Data.SortableObjectCollection();
				spParameters["MetaPartnerSubTypeCode"] = metaPartnerSubTypeCode;
				spParameters["IncludeInactive"] = true;
				spParameters["IncludeDateInactive"] = true;
				DataTable dt = dbAdapter.ExecuteProc("spCustomers_GetAllMetaPartnerDataByMetaPartnerSubTypeCode", null, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					MetaPartner item = (MetaPartner) DataTransformAttribute.Transform(row, new MetaPartner(), false);
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Customers.GetAllMetaPartnerDataByMetaPartnerSubTypeCode");
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets many MetaPartner data by criteria.</summary>
		///
		/// <param name="metaPartnerSubTypeCode">A key for MetaPartner items to be fetched</param>
		/// <param name="localeCode">A key for MetaPartner items to be fetched</param>
		/// <param name="currencyCode">A key for MetaPartner items to be fetched</param>
		/// <param name="dateFormatCode">A key for MetaPartner items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for MetaPartner items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for MetaPartner items to be fetched</param>
		/// <param name="metaPartnerName">A key for MetaPartner items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetManyMetaPartnerDataByCriteria(int? metaPartnerSubTypeCode, int? localeCode, int? currencyCode, int? dateFormatCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, string metaPartnerName, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel)
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
				spParameters["MetaPartnerSubTypeCode"] = metaPartnerSubTypeCode;
				spParameters["LocaleCode"] = localeCode;
				spParameters["CurrencyCode"] = currencyCode;
				spParameters["DateFormatCode"] = dateFormatCode;
				spParameters["LastModifiedDateStart"] = lastModifiedDateStart;
				spParameters["LastModifiedDateEnd"] = lastModifiedDateEnd;
				spParameters["MetaPartnerName"] = MOD.Data.SearchHelper.ReplaceSpecialSQLSearchChars(metaPartnerName);
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
				DataTable dt = dbAdapter.ExecuteProc("spCustomers_GetManyMetaPartnerDataByCriteria", null, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				totalRecords = MOD.Data.DataHelper.GetInt(spParameters["TotalRecords"], MOD.Data.DefaultValue.Int);
				maximumListSizeExceeded = MOD.Data.DataHelper.GetBool(spParameters["MaximumListSizeExceeded"], MOD.Data.DefaultValue.Bool);
				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					MetaPartner item = (MetaPartner) DataTransformAttribute.Transform(row, new MetaPartner(), false, filterFields);
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Customers.GetManyMetaPartnerDataByCriteria");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single MetaPartner by an index.</summary>
		///
		/// <param name="metaPartnerID">A key for MetaPartner items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MetaPartner GetOneMetaPartner(Guid metaPartnerID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel)
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
				MetaPartner item = new MetaPartner();
				spParameters["MetaPartnerID"] = metaPartnerID;
				if(dataOptions != null)
				{
					dataOptions.PopulateNamedObjectCollection( spParameters );
					filterFields = dataOptions.FilterFields;
				}
				DataTable dt = dbAdapter.ExecuteProc("spCustomers_GetOneMetaPartner", null, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				item = null;
				// get output item
				foreach(DataRow row in dt.Rows)
				{
					// get item
					item = (MetaPartner) DataTransformAttribute.Transform(row, new MetaPartner(), false, filterFields);
					break;
				}
				return item;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Customers.GetOneMetaPartner");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method inserts or updates MetaPartner data.</summary>
		///
		/// <param name="item">The MetaPartner to be inserted or updated.</param>
		/// <param name="performCascadeOperation">Peform the changes to the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpsertOneMetaPartner(MetaPartner item, bool performCascadeOperation, MOD.Data.DatabaseOptions dbOptions, int debugLevel)
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
				UpsertOneMetaPartner(item, performCascadeOperation, dbAdapter);
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
				throw Utility.CustomAppException.WrapException(ex, "DAL.Customers.UpsertOneMetaPartner");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method inserts or updates MetaPartner data.</summary>
		///
		/// <param name="item">The MetaPartner to be inserted or updated.</param>
		/// <param name="performCascadeOperation">Peform the changes to the child entities of the item, if any exist</param>
		/// <param name="dbAdapter">Database adapter for transaction</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpsertOneMetaPartner(MetaPartner item, bool performCascadeOperation, MOD.Data.SqlProcAdapter dbAdapter)
		{
			try
			{
				// perform main method tasks
				MOD.Data.NamedObjectCollection spParameters = new MOD.Data.NamedObjectCollection();
				dbAdapter.ExecuteProcNQ("spCustomers_UpsertOneMetaPartner", item, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				item.MetaPartnerID = MOD.Data.DataHelper.GetGuid(spParameters["MetaPartnerID"], MOD.Data.DefaultValue.Guid);
				item.Timestamp = ((System.Byte[])(spParameters["Timestamp"]));
				#region Cascade Operations
				if (performCascadeOperation == true)
				{
					// cascade operations
					#region PhoneList
					if (item.PhoneList != null)
					{
						MOD.Data.SortableObjectCollection phoneList = DAL.Customers.MetaPartnerPhone.GetAllMetaPartnerPhoneDataByMetaPartnerID(item.MetaPartnerID, dbAdapter);
						// process updates and adds
						foreach(DAL.Customers.MetaPartnerPhone loopMetaPartnerPhone in item.PhoneList)
						{
							if (phoneList.Contains(loopMetaPartnerPhone))
							{
								// update item
								loopMetaPartnerPhone.LastModifiedByUserID = item.LastModifiedByUserID;
								DAL.Customers.MetaPartnerPhone.UpsertOneMetaPartnerPhone(loopMetaPartnerPhone, false, dbAdapter);
							}
							else
							{
								// add item
								loopMetaPartnerPhone.CreatedByUserID = item.CreatedByUserID;
								loopMetaPartnerPhone.LastModifiedByUserID = item.LastModifiedByUserID;
								loopMetaPartnerPhone.MetaPartnerID = item.MetaPartnerID;
								DAL.Customers.MetaPartnerPhone.UpsertOneMetaPartnerPhone(loopMetaPartnerPhone, false, dbAdapter);
							}
						}
						// process deletions
						foreach(DAL.Customers.MetaPartnerPhone loopMetaPartnerPhone in phoneList)
						{
							if (!item.PhoneList.Contains(loopMetaPartnerPhone))
							{
								DAL.Customers.MetaPartnerPhone.DeleteOneMetaPartnerPhone(loopMetaPartnerPhone, false, dbAdapter);
							}
						}
					}
					#endregion PhoneList
					#region EmailList
					if (item.EmailList != null)
					{
						MOD.Data.SortableObjectCollection emailList = DAL.Customers.MetaPartnerEmail.GetAllMetaPartnerEmailDataByMetaPartnerID(item.MetaPartnerID, dbAdapter);
						// process updates and adds
						foreach(DAL.Customers.MetaPartnerEmail loopMetaPartnerEmail in item.EmailList)
						{
							if (emailList.Contains(loopMetaPartnerEmail))
							{
								// update item
								loopMetaPartnerEmail.LastModifiedByUserID = item.LastModifiedByUserID;
								DAL.Customers.MetaPartnerEmail.UpsertOneMetaPartnerEmail(loopMetaPartnerEmail, false, dbAdapter);
							}
							else
							{
								// add item
								loopMetaPartnerEmail.CreatedByUserID = item.CreatedByUserID;
								loopMetaPartnerEmail.LastModifiedByUserID = item.LastModifiedByUserID;
								loopMetaPartnerEmail.MetaPartnerID = item.MetaPartnerID;
								DAL.Customers.MetaPartnerEmail.UpsertOneMetaPartnerEmail(loopMetaPartnerEmail, false, dbAdapter);
							}
						}
						// process deletions
						foreach(DAL.Customers.MetaPartnerEmail loopMetaPartnerEmail in emailList)
						{
							if (!item.EmailList.Contains(loopMetaPartnerEmail))
							{
								DAL.Customers.MetaPartnerEmail.DeleteOneMetaPartnerEmail(loopMetaPartnerEmail, false, dbAdapter);
							}
						}
					}
					#endregion EmailList
					#region LocationList
					if (item.LocationList != null)
					{
						MOD.Data.SortableObjectCollection locationList = DAL.Customers.Location.GetAllLocationDataByMetaPartnerID(item.MetaPartnerID, dbAdapter);
						// process updates and adds
						foreach(DAL.Customers.Location loopLocation in item.LocationList)
						{
							if (locationList.Contains(loopLocation))
							{
								// update item
								loopLocation.LastModifiedByUserID = item.LastModifiedByUserID;
								DAL.Customers.Location.UpsertOneLocation(loopLocation, false, dbAdapter);
							}
							else
							{
								// add item
								loopLocation.CreatedByUserID = item.CreatedByUserID;
								loopLocation.LastModifiedByUserID = item.LastModifiedByUserID;
								loopLocation.MetaPartnerID = item.MetaPartnerID;
								DAL.Customers.Location.UpsertOneLocation(loopLocation, false, dbAdapter);
							}
						}
						// process deletions
						foreach(DAL.Customers.Location loopLocation in locationList)
						{
							if (!item.LocationList.Contains(loopLocation))
							{
								DAL.Customers.Location.DeleteOneLocation(loopLocation, false, dbAdapter);
							}
						}
					}
					#endregion LocationList
					#region BankAccountList
					if (item.BankAccountList != null)
					{
						MOD.Data.SortableObjectCollection bankAccountList = DAL.Accounts.BankAccount.GetAllBankAccountDataByMetaPartnerID(item.MetaPartnerID, dbAdapter);
						// process updates and adds
						foreach(DAL.Accounts.BankAccount loopBankAccount in item.BankAccountList)
						{
							if (bankAccountList.Contains(loopBankAccount))
							{
								// update item
								loopBankAccount.LastModifiedByUserID = item.LastModifiedByUserID;
								DAL.Accounts.BankAccount.UpdateOneBankAccount(loopBankAccount, false, dbAdapter);
							}
							else
							{
								// add item
								loopBankAccount.CreatedByUserID = item.CreatedByUserID;
								loopBankAccount.LastModifiedByUserID = item.LastModifiedByUserID;
								loopBankAccount.MetaPartnerID = item.MetaPartnerID;
								DAL.Accounts.BankAccount.AddOneBankAccount(loopBankAccount, false, dbAdapter);
							}
						}
						// process deletions
						foreach(DAL.Accounts.BankAccount loopBankAccount in bankAccountList)
						{
							if (!item.BankAccountList.Contains(loopBankAccount))
							{
								DAL.Accounts.BankAccount.DeleteOneBankAccount(loopBankAccount, false, dbAdapter);
							}
						}
					}
					#endregion BankAccountList
					#region StoredValueAccountList
					if (item.StoredValueAccountList != null)
					{
						MOD.Data.SortableObjectCollection storedValueAccountList = DAL.Accounts.StoredValueAccount.GetAllStoredValueAccountDataByMetaPartnerID(item.MetaPartnerID, dbAdapter);
						// process updates and adds
						foreach(DAL.Accounts.StoredValueAccount loopStoredValueAccount in item.StoredValueAccountList)
						{
							if (storedValueAccountList.Contains(loopStoredValueAccount))
							{
								// update item
								loopStoredValueAccount.LastModifiedByUserID = item.LastModifiedByUserID;
								DAL.Accounts.StoredValueAccount.UpdateOneStoredValueAccount(loopStoredValueAccount, false, dbAdapter);
							}
							else
							{
								// add item
								loopStoredValueAccount.CreatedByUserID = item.CreatedByUserID;
								loopStoredValueAccount.LastModifiedByUserID = item.LastModifiedByUserID;
								loopStoredValueAccount.MetaPartnerID = item.MetaPartnerID;
								DAL.Accounts.StoredValueAccount.AddOneStoredValueAccount(loopStoredValueAccount, false, dbAdapter);
							}
						}
						// process deletions
						foreach(DAL.Accounts.StoredValueAccount loopStoredValueAccount in storedValueAccountList)
						{
							if (!item.StoredValueAccountList.Contains(loopStoredValueAccount))
							{
								DAL.Accounts.StoredValueAccount.DeleteOneStoredValueAccount(loopStoredValueAccount, false, dbAdapter);
							}
						}
					}
					#endregion StoredValueAccountList
					#region CreditAccountList
					if (item.CreditAccountList != null)
					{
						MOD.Data.SortableObjectCollection creditAccountList = DAL.Accounts.CreditAccount.GetAllCreditAccountDataByMetaPartnerID(item.MetaPartnerID, dbAdapter);
						// process updates and adds
						foreach(DAL.Accounts.CreditAccount loopCreditAccount in item.CreditAccountList)
						{
							if (creditAccountList.Contains(loopCreditAccount))
							{
								// update item
								loopCreditAccount.LastModifiedByUserID = item.LastModifiedByUserID;
								DAL.Accounts.CreditAccount.UpdateOneCreditAccount(loopCreditAccount, false, dbAdapter);
							}
							else
							{
								// add item
								loopCreditAccount.CreatedByUserID = item.CreatedByUserID;
								loopCreditAccount.LastModifiedByUserID = item.LastModifiedByUserID;
								loopCreditAccount.MetaPartnerID = item.MetaPartnerID;
								DAL.Accounts.CreditAccount.AddOneCreditAccount(loopCreditAccount, false, dbAdapter);
							}
						}
						// process deletions
						foreach(DAL.Accounts.CreditAccount loopCreditAccount in creditAccountList)
						{
							if (!item.CreditAccountList.Contains(loopCreditAccount))
							{
								DAL.Accounts.CreditAccount.DeleteOneCreditAccount(loopCreditAccount, false, dbAdapter);
							}
						}
					}
					#endregion CreditAccountList
					#region FundAccountList
					if (item.FundAccountList != null)
					{
						MOD.Data.SortableObjectCollection fundAccountList = DAL.Accounts.FundAccount.GetAllFundAccountDataByMetaPartnerID(item.MetaPartnerID, dbAdapter);
						// process updates and adds
						foreach(DAL.Accounts.FundAccount loopFundAccount in item.FundAccountList)
						{
							if (fundAccountList.Contains(loopFundAccount))
							{
								// update item
								loopFundAccount.LastModifiedByUserID = item.LastModifiedByUserID;
								DAL.Accounts.FundAccount.UpdateOneFundAccount(loopFundAccount, false, dbAdapter);
							}
							else
							{
								// add item
								loopFundAccount.CreatedByUserID = item.CreatedByUserID;
								loopFundAccount.LastModifiedByUserID = item.LastModifiedByUserID;
								loopFundAccount.MetaPartnerID = item.MetaPartnerID;
								DAL.Accounts.FundAccount.AddOneFundAccount(loopFundAccount, false, dbAdapter);
							}
						}
						// process deletions
						foreach(DAL.Accounts.FundAccount loopFundAccount in fundAccountList)
						{
							if (!item.FundAccountList.Contains(loopFundAccount))
							{
								DAL.Accounts.FundAccount.DeleteOneFundAccount(loopFundAccount, false, dbAdapter);
							}
						}
					}
					#endregion FundAccountList
					#region BillPayAccountList
					if (item.BillPayAccountList != null)
					{
						MOD.Data.SortableObjectCollection billPayAccountList = DAL.Accounts.BillPayAccount.GetAllBillPayAccountDataByMetaPartnerID(item.MetaPartnerID, dbAdapter);
						// process updates and adds
						foreach(DAL.Accounts.BillPayAccount loopBillPayAccount in item.BillPayAccountList)
						{
							if (billPayAccountList.Contains(loopBillPayAccount))
							{
								// update item
								loopBillPayAccount.LastModifiedByUserID = item.LastModifiedByUserID;
								DAL.Accounts.BillPayAccount.UpdateOneBillPayAccount(loopBillPayAccount, false, dbAdapter);
							}
							else
							{
								// add item
								loopBillPayAccount.CreatedByUserID = item.CreatedByUserID;
								loopBillPayAccount.LastModifiedByUserID = item.LastModifiedByUserID;
								loopBillPayAccount.MetaPartnerID = item.MetaPartnerID;
								DAL.Accounts.BillPayAccount.AddOneBillPayAccount(loopBillPayAccount, false, dbAdapter);
							}
						}
						// process deletions
						foreach(DAL.Accounts.BillPayAccount loopBillPayAccount in billPayAccountList)
						{
							if (!item.BillPayAccountList.Contains(loopBillPayAccount))
							{
								DAL.Accounts.BillPayAccount.DeleteOneBillPayAccount(loopBillPayAccount, false, dbAdapter);
							}
						}
					}
					#endregion BillPayAccountList
					#region MetaTransferAccountList
					if (item.MetaTransferAccountList != null)
					{
						MOD.Data.SortableObjectCollection metaTransferAccountList = DAL.Accounts.MetaTransferAccount.GetAllMetaTransferAccountDataByMetaPartnerID(item.MetaPartnerID, dbAdapter);
						// process updates and adds
						foreach(DAL.Accounts.MetaTransferAccount loopMetaTransferAccount in item.MetaTransferAccountList)
						{
							if (metaTransferAccountList.Contains(loopMetaTransferAccount))
							{
								// update item
								loopMetaTransferAccount.LastModifiedByUserID = item.LastModifiedByUserID;
								DAL.Accounts.MetaTransferAccount.UpdateOneMetaTransferAccount(loopMetaTransferAccount, false, dbAdapter);
							}
							else
							{
								// add item
								loopMetaTransferAccount.CreatedByUserID = item.CreatedByUserID;
								loopMetaTransferAccount.LastModifiedByUserID = item.LastModifiedByUserID;
								loopMetaTransferAccount.MetaPartnerID = item.MetaPartnerID;
								DAL.Accounts.MetaTransferAccount.AddOneMetaTransferAccount(loopMetaTransferAccount, false, dbAdapter);
							}
						}
						// process deletions
						foreach(DAL.Accounts.MetaTransferAccount loopMetaTransferAccount in metaTransferAccountList)
						{
							if (!item.MetaTransferAccountList.Contains(loopMetaTransferAccount))
							{
								DAL.Accounts.MetaTransferAccount.DeleteOneMetaTransferAccount(loopMetaTransferAccount, false, dbAdapter);
							}
						}
					}
					#endregion MetaTransferAccountList
					#region LoanAccountList
					if (item.LoanAccountList != null)
					{
						MOD.Data.SortableObjectCollection loanAccountList = DAL.Accounts.LoanAccount.GetAllLoanAccountDataByMetaPartnerID(item.MetaPartnerID, dbAdapter);
						// process updates and adds
						foreach(DAL.Accounts.LoanAccount loopLoanAccount in item.LoanAccountList)
						{
							if (loanAccountList.Contains(loopLoanAccount))
							{
								// update item
								loopLoanAccount.LastModifiedByUserID = item.LastModifiedByUserID;
								DAL.Accounts.LoanAccount.UpdateOneLoanAccount(loopLoanAccount, false, dbAdapter);
							}
							else
							{
								// add item
								loopLoanAccount.CreatedByUserID = item.CreatedByUserID;
								loopLoanAccount.LastModifiedByUserID = item.LastModifiedByUserID;
								loopLoanAccount.MetaPartnerID = item.MetaPartnerID;
								DAL.Accounts.LoanAccount.AddOneLoanAccount(loopLoanAccount, false, dbAdapter);
							}
						}
						// process deletions
						foreach(DAL.Accounts.LoanAccount loopLoanAccount in loanAccountList)
						{
							if (!item.LoanAccountList.Contains(loopLoanAccount))
							{
								DAL.Accounts.LoanAccount.DeleteOneLoanAccount(loopLoanAccount, false, dbAdapter);
							}
						}
					}
					#endregion LoanAccountList
					#region MetaPartnerCouponList
					if (item.MetaPartnerCouponList != null)
					{
						MOD.Data.SortableObjectCollection metaPartnerCouponList = DAL.Promotions.MetaPartnerCoupon.GetAllMetaPartnerCouponDataByMetaPartnerID(item.MetaPartnerID, dbAdapter);
						// process updates and adds
						foreach(DAL.Promotions.MetaPartnerCoupon loopMetaPartnerCoupon in item.MetaPartnerCouponList)
						{
							if (metaPartnerCouponList.Contains(loopMetaPartnerCoupon))
							{
								// update item
								loopMetaPartnerCoupon.LastModifiedByUserID = item.LastModifiedByUserID;
								DAL.Promotions.MetaPartnerCoupon.UpsertOneMetaPartnerCoupon(loopMetaPartnerCoupon, false, dbAdapter);
							}
							else
							{
								// add item
								loopMetaPartnerCoupon.CreatedByUserID = item.CreatedByUserID;
								loopMetaPartnerCoupon.LastModifiedByUserID = item.LastModifiedByUserID;
								loopMetaPartnerCoupon.MetaPartnerID = item.MetaPartnerID;
								DAL.Promotions.MetaPartnerCoupon.UpsertOneMetaPartnerCoupon(loopMetaPartnerCoupon, false, dbAdapter);
							}
						}
						// process deletions
						foreach(DAL.Promotions.MetaPartnerCoupon loopMetaPartnerCoupon in metaPartnerCouponList)
						{
							if (!item.MetaPartnerCouponList.Contains(loopMetaPartnerCoupon))
							{
								DAL.Promotions.MetaPartnerCoupon.DeleteOneMetaPartnerCoupon(loopMetaPartnerCoupon, false, dbAdapter);
							}
						}
					}
					#endregion MetaPartnerCouponList
				}
				#endregion Cascade Operations
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Customers.UpsertOneMetaPartner");
			}
		}
		/// <summary>
		///			 
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			MetaPartner metaPartnerInstance = obj as MetaPartner;
			if (metaPartnerInstance == null)
				return false;
			else
				return (_metaPartnerID == metaPartnerInstance.MetaPartnerID);
		}
		/// <summary>
		///	Returns unique identifying integer		 
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return (_metaPartnerID.ToString()).GetHashCode();
		}
		#endregion Methods
	}
}