
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
namespace MW.MComm.WalletSolution.BLL.Accounts
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to hold and manage information for CurrencyConversion instances.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[Serializable()]
	[DataTransform(Name = "MW.MComm.WalletSolution.DAL.Accounts.CurrencyConversion")]
	public partial class CurrencyConversion : PersistedBusinessObject
	{
		#region Constants
		#endregion Constants
		#region Fields
		// for CurrencyConversionID property
		protected Guid _currencyConversionID = MOD.Data.DefaultValue.Guid;
		// for ConvertFromCurrencyCode property
		protected int _convertFromCurrencyCode = MOD.Data.DefaultValue.Int;
		// for ConvertToCurrencyCode property
		protected int _convertToCurrencyCode = MOD.Data.DefaultValue.Int;
		// for MetaPartnerID property
		protected Guid _metaPartnerID = MOD.Data.DefaultValue.Guid;
		// for ConversionRate property
		protected float _conversionRate = MOD.Data.DefaultValue.Float;
		// for IsActive property
		protected bool _isActive = false;
		// for CurrencyName read only property
		[DataTransform]
		protected string _currencyName = MOD.Data.DefaultValue.String;
		// for Business property
		protected BLL.Customers.Business _business = null;
		// for Currency property
		protected BLL.Accounts.Currency _currency = null;
		#endregion Fields
		#region Properties
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CurrencyConversionID.</summary>
		// ------------------------------------------------------------------------------
		[XmlElementAttribute()]
		[DataTransform]
		public virtual Guid CurrencyConversionID
		{
			get
			{
				return _currencyConversionID;
			}
			set
			{
				if (_currencyConversionID != value)
				{
					_currencyConversionID = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the ConvertFromCurrencyCode.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Int)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual int ConvertFromCurrencyCode
		{
			get
			{
				return _convertFromCurrencyCode;
			}
			set
			{
				if (_convertFromCurrencyCode != value)
				{
					_convertFromCurrencyCode = value;
					_currency = null;
					// reset Currency
					BLL.PersistedBusinessObject vCurrency = (BLL.PersistedBusinessObject) Currency;
					vCurrency = null;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the ConvertToCurrencyCode.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Int)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual int ConvertToCurrencyCode
		{
			get
			{
				return _convertToCurrencyCode;
			}
			set
			{
				if (_convertToCurrencyCode != value)
				{
					_convertToCurrencyCode = value;
					_currency = null;
					// reset Currency
					BLL.PersistedBusinessObject vCurrency = (BLL.PersistedBusinessObject) Currency;
					vCurrency = null;
					_isDirty = true;
				}
			}
		}
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
					_business = null;
					// reset Business
					BLL.PersistedBusinessObject vBusiness = (BLL.PersistedBusinessObject) Business;
					vBusiness = null;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the ConversionRate.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Float)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual float ConversionRate
		{
			get
			{
				return _conversionRate;
			}
			set
			{
				if (_conversionRate != value)
				{
					_conversionRate = value;
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
				return (MOD.Data.DataHelper.GetString(CurrencyConversionID,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					CurrencyConversionID = MOD.Data.DataHelper.GetGuid(keyValues[0], MOD.Data.DefaultValue.Guid);
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
					return CurrencyName;
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
				return (MOD.Data.DataHelper.GetString(CurrencyConversionID,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					CurrencyConversionID = MOD.Data.DataHelper.GetGuid(keyValues[0], MOD.Data.DefaultValue.Guid);
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
					return "CurrencyName";
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
		/// <summary>This property gets or sets an item of Business.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Customers.Business Business
		{
			get
			{
				if (_business == null  && IsLazyLoadable == true)
				{
					_business = BLL.Customers.BusinessManager.GetOneBusiness((Guid)MetaPartnerID);
					// refresh derived properties
					if (_business != null)
					{
					}
					else
					{
					}
				}
				return _business;
			}
			set
			{
				if (_business != value)
				{
					_business = value;
					_isDirty = true;
					// refresh derived properties
					if (_business != null)
					{
					}
					else
					{
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
					_currency = BLL.Accounts.CurrencyManager.GetOneCurrency((int)ConvertToCurrencyCode);
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
		#endregion Properties
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public CurrencyConversion()
		{
			//
			// constructor logic
			//
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method creates an instance with the primary key values.</summary>
		// ------------------------------------------------------------------------------
		public CurrencyConversion(string keyValues, bool isPrimaryKeyValues)
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
		/// <summary>This constructor initializes the CurrencyConversion from its DAL counterpart.</summary>
		// ------------------------------------------------------------------------------
		public CurrencyConversion(DAL.Accounts.CurrencyConversion businessObject) : base(businessObject)
		{
		}
		// ------------------------------------------------------------------------------
		/// <summary>This constructor initializes the CurrencyConversion from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public CurrencyConversion(Guid currencyConversionID)
		{
			CurrencyConversionID = currencyConversionID;
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the CurrencyConversion with its already set properties.</summary>
		// ------------------------------------------------------------------------------
		public void Load()
		{
			Load(CurrencyConversionID);
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the CurrencyConversion from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public void Load(Guid currencyConversionID)
		{
			BLL.Accounts.CurrencyConversion businessObject = null;
			businessObject = BLL.Accounts.CurrencyConversionManager.GetOneCurrencyConversion(currencyConversionID);
			if(businessObject != null)
			{
				ReflectionHelper.Copy(businessObject, this, true);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the CurrencyConversion into the database,
		/// performing add/update auto detect and performing a cascade operation if indicated.</summary>
		// ------------------------------------------------------------------------------
		public void Save(bool performCascade)
		{
			if (IsLoaded == false)
			{
				BLL.Accounts.CurrencyConversionManager.UpsertOneCurrencyConversion(this, performCascade);
			}
			else
			{
				BLL.Accounts.CurrencyConversionManager.UpsertOneCurrencyConversion(this, performCascade);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the CurrencyConversion into the database,
		/// performing add/update auto detect and without performing a cascade operation.</summary>
		// ------------------------------------------------------------------------------
		public void Save()
		{
			Save(false);
		}
		/// <summary>
		///	Clears the dirty state of CurrencyConversion and its subcollections.
		/// </summary>
		/// <param name="clearCollectionDirtyState">Flag to clear subcollections.</param>
		/// <returns></returns>
		public override void ClearDirtyState(bool clearCollectionDirtyState)
		{
			// clear base items
			base.ClearDirtyState();
			// clear collections and other items
			if (this._business != null)
			{
				this.Business.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._currency != null)
			{
				this.Currency.ClearDirtyState(clearCollectionDirtyState);
			}
		}
		/// <summary>
		///	Tests to see if input object is convertable to CurrencyConversion, and has the same primary key values.
		/// </summary>
		/// <param name="obj">Input object to test.</param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			CurrencyConversion currencyConversionInstance = obj as CurrencyConversion;
			if (currencyConversionInstance == null)
				return false;
			else
				return (_currencyConversionID == currencyConversionInstance.CurrencyConversionID);
		}
		/// <summary>
		///	Returns unique identifying integer		 
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return (_currencyConversionID.ToString()).GetHashCode();
		}
		#endregion Methods
	}
}