
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
namespace MW.MComm.WalletSolution.BLL.Customers
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
	[DataTransform(Name = "MW.MComm.WalletSolution.DAL.Customers.MetaPartner")]
	public partial class MetaPartner : PersistedBusinessObject
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
		protected BLL.SortableList<BLL.Customers.MetaPartnerPhone> _phoneList = null;
		// for EmailList property
		protected BLL.SortableList<BLL.Customers.MetaPartnerEmail> _emailList = null;
		// for LocationList property
		protected BLL.SortableList<BLL.Customers.Location> _locationList = null;
		// for BankAccountList property
		protected BLL.SortableList<BLL.Accounts.BankAccount> _bankAccountList = null;
		// for StoredValueAccountList property
		protected BLL.SortableList<BLL.Accounts.StoredValueAccount> _storedValueAccountList = null;
		// for CreditAccountList property
		protected BLL.SortableList<BLL.Accounts.CreditAccount> _creditAccountList = null;
		// for FundAccountList property
		protected BLL.SortableList<BLL.Accounts.FundAccount> _fundAccountList = null;
		// for BillPayAccountList property
		protected BLL.SortableList<BLL.Accounts.BillPayAccount> _billPayAccountList = null;
		// for MetaTransferAccountList property
		protected BLL.SortableList<BLL.Accounts.MetaTransferAccount> _metaTransferAccountList = null;
		// for LoanAccountList property
		protected BLL.SortableList<BLL.Accounts.LoanAccount> _loanAccountList = null;
		// for MetaPartnerCouponList property
		protected BLL.SortableList<BLL.Promotions.MetaPartnerCoupon> _metaPartnerCouponList = null;
		// for Currency property
		protected BLL.Accounts.Currency _currency = null;
		// for MetaPartnerSubType property
		protected BLL.Customers.MetaPartnerSubType _metaPartnerSubType = null;
		// for DateFormat property
		protected BLL.Environments.DateFormat _dateFormat = null;
		// for Locale property
		protected BLL.Environments.Locale _locale = null;
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
					_metaPartnerSubType = null;
					// reset MetaPartnerSubType
					BLL.PersistedBusinessObject vMetaPartnerSubType = (BLL.PersistedBusinessObject) MetaPartnerSubType;
					vMetaPartnerSubType = null;
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
					_locale = null;
					// reset Locale
					BLL.PersistedBusinessObject vLocale = (BLL.PersistedBusinessObject) Locale;
					vLocale = null;
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
					_dateFormat = null;
					// reset DateFormat
					BLL.PersistedBusinessObject vDateFormat = (BLL.PersistedBusinessObject) DateFormat;
					vDateFormat = null;
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
		/// <summary>This property checks for any collections that have been modified since object was last saved to or loaded from the database</summary>
		// ------------------------------------------------------------------------------
		public override bool IsCollectionDirty
		{
			get
			{
				return ((_phoneList != null && _phoneList.IsDirty) ||
				(_emailList != null && _emailList.IsDirty) ||
				(_locationList != null && _locationList.IsDirty) ||
				(_bankAccountList != null && _bankAccountList.IsDirty) ||
				(_storedValueAccountList != null && _storedValueAccountList.IsDirty) ||
				(_creditAccountList != null && _creditAccountList.IsDirty) ||
				(_fundAccountList != null && _fundAccountList.IsDirty) ||
				(_billPayAccountList != null && _billPayAccountList.IsDirty) ||
				(_metaTransferAccountList != null && _metaTransferAccountList.IsDirty) ||
				(_loanAccountList != null && _loanAccountList.IsDirty) ||
				(_metaPartnerCouponList != null && _metaPartnerCouponList.IsDirty) ||
				base.IsCollectionDirty);
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
		[XmlArrayItem(typeof(BLL.Customers.MetaPartnerPhone), ElementName="MetaPartnerPhone")]
		[DataTransform]
		public virtual BLL.SortableList<BLL.Customers.MetaPartnerPhone> PhoneList
		{
			get
			{
				if (_phoneList == null && IsLazyLoadable == true)
				{
					_phoneList = BLL.Customers.MetaPartnerPhoneManager.GetAllMetaPartnerPhoneDataByMetaPartnerID(MetaPartnerID);
				}
				else if (_phoneList == null)
				{
					_phoneList = new BLL.SortableList<BLL.Customers.MetaPartnerPhone>();
				}
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
		[XmlArrayItem(typeof(BLL.Customers.MetaPartnerEmail), ElementName="MetaPartnerEmail")]
		[DataTransform]
		public virtual BLL.SortableList<BLL.Customers.MetaPartnerEmail> EmailList
		{
			get
			{
				if (_emailList == null && IsLazyLoadable == true)
				{
					_emailList = BLL.Customers.MetaPartnerEmailManager.GetAllMetaPartnerEmailDataByMetaPartnerID(MetaPartnerID);
				}
				else if (_emailList == null)
				{
					_emailList = new BLL.SortableList<BLL.Customers.MetaPartnerEmail>();
				}
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
		[XmlArrayItem(typeof(BLL.Customers.Location), ElementName="Location")]
		[DataTransform]
		public virtual BLL.SortableList<BLL.Customers.Location> LocationList
		{
			get
			{
				if (_locationList == null && IsLazyLoadable == true)
				{
					_locationList = BLL.Customers.LocationManager.GetAllLocationDataByMetaPartnerID(MetaPartnerID);
				}
				else if (_locationList == null)
				{
					_locationList = new BLL.SortableList<BLL.Customers.Location>();
				}
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
		[XmlArrayItem(typeof(BLL.Accounts.BankAccount), ElementName="BankAccount")]
		[DataTransform]
		public virtual BLL.SortableList<BLL.Accounts.BankAccount> BankAccountList
		{
			get
			{
				if (_bankAccountList == null && IsLazyLoadable == true)
				{
					_bankAccountList = BLL.Accounts.BankAccountManager.GetAllBankAccountDataByMetaPartnerID(MetaPartnerID);
				}
				else if (_bankAccountList == null)
				{
					_bankAccountList = new BLL.SortableList<BLL.Accounts.BankAccount>();
				}
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
		[XmlArrayItem(typeof(BLL.Accounts.StoredValueAccount), ElementName="StoredValueAccount")]
		[DataTransform]
		public virtual BLL.SortableList<BLL.Accounts.StoredValueAccount> StoredValueAccountList
		{
			get
			{
				if (_storedValueAccountList == null && IsLazyLoadable == true)
				{
					_storedValueAccountList = BLL.Accounts.StoredValueAccountManager.GetAllStoredValueAccountDataByMetaPartnerID(MetaPartnerID);
				}
				else if (_storedValueAccountList == null)
				{
					_storedValueAccountList = new BLL.SortableList<BLL.Accounts.StoredValueAccount>();
				}
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
		[XmlArrayItem(typeof(BLL.Accounts.CreditAccount), ElementName="CreditAccount")]
		[DataTransform]
		public virtual BLL.SortableList<BLL.Accounts.CreditAccount> CreditAccountList
		{
			get
			{
				if (_creditAccountList == null && IsLazyLoadable == true)
				{
					_creditAccountList = BLL.Accounts.CreditAccountManager.GetAllCreditAccountDataByMetaPartnerID(MetaPartnerID);
				}
				else if (_creditAccountList == null)
				{
					_creditAccountList = new BLL.SortableList<BLL.Accounts.CreditAccount>();
				}
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
		[XmlArrayItem(typeof(BLL.Accounts.FundAccount), ElementName="FundAccount")]
		[DataTransform]
		public virtual BLL.SortableList<BLL.Accounts.FundAccount> FundAccountList
		{
			get
			{
				if (_fundAccountList == null && IsLazyLoadable == true)
				{
					_fundAccountList = BLL.Accounts.FundAccountManager.GetAllFundAccountDataByMetaPartnerID(MetaPartnerID);
				}
				else if (_fundAccountList == null)
				{
					_fundAccountList = new BLL.SortableList<BLL.Accounts.FundAccount>();
				}
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
		[XmlArrayItem(typeof(BLL.Accounts.BillPayAccount), ElementName="BillPayAccount")]
		[DataTransform]
		public virtual BLL.SortableList<BLL.Accounts.BillPayAccount> BillPayAccountList
		{
			get
			{
				if (_billPayAccountList == null && IsLazyLoadable == true)
				{
					_billPayAccountList = BLL.Accounts.BillPayAccountManager.GetAllBillPayAccountDataByMetaPartnerID(MetaPartnerID);
				}
				else if (_billPayAccountList == null)
				{
					_billPayAccountList = new BLL.SortableList<BLL.Accounts.BillPayAccount>();
				}
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
		[XmlArrayItem(typeof(BLL.Accounts.MetaTransferAccount), ElementName="MetaTransferAccount")]
		[DataTransform]
		public virtual BLL.SortableList<BLL.Accounts.MetaTransferAccount> MetaTransferAccountList
		{
			get
			{
				if (_metaTransferAccountList == null && IsLazyLoadable == true)
				{
					_metaTransferAccountList = BLL.Accounts.MetaTransferAccountManager.GetAllMetaTransferAccountDataByMetaPartnerID(MetaPartnerID);
				}
				else if (_metaTransferAccountList == null)
				{
					_metaTransferAccountList = new BLL.SortableList<BLL.Accounts.MetaTransferAccount>();
				}
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
		[XmlArrayItem(typeof(BLL.Accounts.LoanAccount), ElementName="LoanAccount")]
		[DataTransform]
		public virtual BLL.SortableList<BLL.Accounts.LoanAccount> LoanAccountList
		{
			get
			{
				if (_loanAccountList == null && IsLazyLoadable == true)
				{
					_loanAccountList = BLL.Accounts.LoanAccountManager.GetAllLoanAccountDataByMetaPartnerID(MetaPartnerID);
				}
				else if (_loanAccountList == null)
				{
					_loanAccountList = new BLL.SortableList<BLL.Accounts.LoanAccount>();
				}
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
		[XmlArrayItem(typeof(BLL.Promotions.MetaPartnerCoupon), ElementName="MetaPartnerCoupon")]
		[DataTransform]
		public virtual BLL.SortableList<BLL.Promotions.MetaPartnerCoupon> MetaPartnerCouponList
		{
			get
			{
				if (_metaPartnerCouponList == null && IsLazyLoadable == true)
				{
					_metaPartnerCouponList = BLL.Promotions.MetaPartnerCouponManager.GetAllMetaPartnerCouponDataByMetaPartnerID(MetaPartnerID);
				}
				else if (_metaPartnerCouponList == null)
				{
					_metaPartnerCouponList = new BLL.SortableList<BLL.Promotions.MetaPartnerCoupon>();
				}
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
		/// <summary>This property gets or sets an item of MetaPartnerSubType.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Customers.MetaPartnerSubType MetaPartnerSubType
		{
			get
			{
				if (_metaPartnerSubType == null  && IsLazyLoadable == true)
				{
					_metaPartnerSubType = BLL.Customers.MetaPartnerSubTypeManager.GetOneMetaPartnerSubType((int)MetaPartnerSubTypeCode);
					// refresh derived properties
					if (_metaPartnerSubType != null)
					{
						_metaPartnerSubTypeName = _metaPartnerSubType.MetaPartnerSubTypeName;
					}
					else
					{
						_metaPartnerSubTypeName = MOD.Data.DefaultValue.String;
					}
				}
				return _metaPartnerSubType;
			}
			set
			{
				if (_metaPartnerSubType != value)
				{
					_metaPartnerSubType = value;
					_isDirty = true;
					// refresh derived properties
					if (_metaPartnerSubType != null)
					{
						_metaPartnerSubTypeName = _metaPartnerSubType.MetaPartnerSubTypeName;
					}
					else
					{
						_metaPartnerSubTypeName = MOD.Data.DefaultValue.String;
					}
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of DateFormat.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Environments.DateFormat DateFormat
		{
			get
			{
				if (_dateFormat == null  && IsLazyLoadable == true)
				{
					_dateFormat = BLL.Environments.DateFormatManager.GetOneDateFormat((int)DateFormatCode);
					// refresh derived properties
					if (_dateFormat != null)
					{
						_dateFormatName = _dateFormat.DateFormatName;
					}
					else
					{
						_dateFormatName = MOD.Data.DefaultValue.String;
					}
				}
				return _dateFormat;
			}
			set
			{
				if (_dateFormat != value)
				{
					_dateFormat = value;
					_isDirty = true;
					// refresh derived properties
					if (_dateFormat != null)
					{
						_dateFormatName = _dateFormat.DateFormatName;
					}
					else
					{
						_dateFormatName = MOD.Data.DefaultValue.String;
					}
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of Locale.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Environments.Locale Locale
		{
			get
			{
				if (_locale == null  && IsLazyLoadable == true)
				{
					_locale = BLL.Environments.LocaleManager.GetOneLocale((int)LocaleCode);
					// refresh derived properties
					if (_locale != null)
					{
						_localeName = _locale.LocaleName;
					}
					else
					{
						_localeName = MOD.Data.DefaultValue.String;
					}
				}
				return _locale;
			}
			set
			{
				if (_locale != value)
				{
					_locale = value;
					_isDirty = true;
					// refresh derived properties
					if (_locale != null)
					{
						_localeName = _locale.LocaleName;
					}
					else
					{
						_localeName = MOD.Data.DefaultValue.String;
					}
				}
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
		// ------------------------------------------------------------------------------
		/// <summary>This constructor initializes the MetaPartner from its DAL counterpart.</summary>
		// ------------------------------------------------------------------------------
		public MetaPartner(DAL.Customers.MetaPartner businessObject) : base(businessObject)
		{
		}
		// ------------------------------------------------------------------------------
		/// <summary>This constructor initializes the MetaPartner from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public MetaPartner(Guid metaPartnerID)
		{
			MetaPartnerID = metaPartnerID;
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the MetaPartner with its already set properties.</summary>
		// ------------------------------------------------------------------------------
		public void Load()
		{
			Load(MetaPartnerID);
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the MetaPartner from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public void Load(Guid metaPartnerID)
		{
			BLL.Customers.MetaPartner businessObject = null;
			businessObject = BLL.Customers.MetaPartnerManager.GetOneMetaPartner(metaPartnerID);
			if(businessObject != null)
			{
				ReflectionHelper.Copy(businessObject, this, true);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the MetaPartner into the database,
		/// performing add/update auto detect and performing a cascade operation if indicated.</summary>
		// ------------------------------------------------------------------------------
		public void Save(bool performCascade)
		{
			if (IsLoaded == false)
			{
				BLL.Customers.MetaPartnerManager.UpsertOneMetaPartner(this, performCascade);
			}
			else
			{
				BLL.Customers.MetaPartnerManager.UpsertOneMetaPartner(this, performCascade);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the MetaPartner into the database,
		/// performing add/update auto detect and without performing a cascade operation.</summary>
		// ------------------------------------------------------------------------------
		public void Save()
		{
			Save(false);
		}
		/// <summary>
		///	Clears the dirty state of MetaPartner and its subcollections.
		/// </summary>
		/// <param name="clearCollectionDirtyState">Flag to clear subcollections.</param>
		/// <returns></returns>
		public override void ClearDirtyState(bool clearCollectionDirtyState)
		{
			// clear base items
			base.ClearDirtyState();
			// clear collections and other items
			if (this._phoneList != null)
			{
				this.PhoneList.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._emailList != null)
			{
				this.EmailList.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._locationList != null)
			{
				this.LocationList.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._bankAccountList != null)
			{
				this.BankAccountList.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._storedValueAccountList != null)
			{
				this.StoredValueAccountList.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._creditAccountList != null)
			{
				this.CreditAccountList.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._fundAccountList != null)
			{
				this.FundAccountList.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._billPayAccountList != null)
			{
				this.BillPayAccountList.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._metaTransferAccountList != null)
			{
				this.MetaTransferAccountList.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._loanAccountList != null)
			{
				this.LoanAccountList.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._metaPartnerCouponList != null)
			{
				this.MetaPartnerCouponList.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._currency != null)
			{
				this.Currency.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._metaPartnerSubType != null)
			{
				this.MetaPartnerSubType.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._dateFormat != null)
			{
				this.DateFormat.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._locale != null)
			{
				this.Locale.ClearDirtyState(clearCollectionDirtyState);
			}
		}
		/// <summary>
		///	Tests to see if input object is convertable to MetaPartner, and has the same primary key values.
		/// </summary>
		/// <param name="obj">Input object to test.</param>
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