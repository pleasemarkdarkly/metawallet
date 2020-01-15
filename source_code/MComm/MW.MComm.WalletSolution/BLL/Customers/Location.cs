
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
	/// <summary>This class is used to hold and manage information for Location instances.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[Serializable()]
	[DataTransform(Name = "MW.MComm.WalletSolution.DAL.Customers.Location")]
	public partial class Location : PersistedBusinessObject
	{
		#region Constants
		#endregion Constants
		#region Fields
		// for LocationID property
		protected Guid _locationID = MOD.Data.DefaultValue.Guid;
		// for LocationTypeCode property
		protected int _locationTypeCode = MOD.Data.DefaultValue.Int;
		// for AddressLine1 property
		protected string _addressLine1 = MOD.Data.DefaultValue.String;
		// for AddressLine2 property
		protected string _addressLine2 = null;
		// for City property
		protected string _city = MOD.Data.DefaultValue.String;
		// for StateProvince property
		protected string _stateProvince = null;
		// for CountryCode property
		protected int _countryCode = MOD.Data.DefaultValue.Int;
		// for PostalCode property
		protected string _postalCode = MOD.Data.DefaultValue.String;
		// for MetaPartnerID property
		protected Guid _metaPartnerID = MOD.Data.DefaultValue.Guid;
		// for LocationTypeName read only property
		[DataTransform]
		protected string _locationTypeName = MOD.Data.DefaultValue.String;
		// for CountryName read only property
		[DataTransform]
		protected string _countryName = MOD.Data.DefaultValue.String;
		// for MetaPartnerName read only property
		[DataTransform]
		protected string _metaPartnerName = MOD.Data.DefaultValue.String;
		// for DateFormatCode read only property
		[DataTransform]
		protected int _dateFormatCode = MOD.Data.DefaultValue.Int;
		// for LocationType property
		protected BLL.Customers.LocationType _locationType = null;
		// for MetaPartner property
		protected BLL.Customers.MetaPartner _metaPartner = null;
		// for Country property
		protected BLL.Environments.Country _country = null;
		#endregion Fields
		#region Properties
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the LocationID.</summary>
		// ------------------------------------------------------------------------------
		[XmlElementAttribute()]
		[DataTransform]
		public virtual Guid LocationID
		{
			get
			{
				return _locationID;
			}
			set
			{
				if (_locationID != value)
				{
					_locationID = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the LocationTypeCode.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Int)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual int LocationTypeCode
		{
			get
			{
				return _locationTypeCode;
			}
			set
			{
				if (_locationTypeCode != value)
				{
					_locationTypeCode = value;
					_locationType = null;
					// reset LocationType
					BLL.PersistedBusinessObject vLocationType = (BLL.PersistedBusinessObject) LocationType;
					vLocationType = null;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the AddressLine1.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual string AddressLine1
		{
			get
			{
				return _addressLine1;
			}
			set
			{
				if ((_addressLine1 != null && !_addressLine1.Equals(value)) || _addressLine1 != value)
				{
					_addressLine1 = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the AddressLine2.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(null)]
		[XmlElementAttribute(IsNullable=true)]
		[DataTransform]
		public virtual string AddressLine2
		{
			get
			{
				return _addressLine2;
			}
			set
			{
				if ((_addressLine2 != null && !_addressLine2.Equals(value)) || _addressLine2 != value)
				{
					_addressLine2 = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the City.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual string City
		{
			get
			{
				return _city;
			}
			set
			{
				if ((_city != null && !_city.Equals(value)) || _city != value)
				{
					_city = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the StateProvince.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(null)]
		[XmlElementAttribute(IsNullable=true)]
		[DataTransform]
		public virtual string StateProvince
		{
			get
			{
				return _stateProvince;
			}
			set
			{
				if ((_stateProvince != null && !_stateProvince.Equals(value)) || _stateProvince != value)
				{
					_stateProvince = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CountryCode.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Int)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual int CountryCode
		{
			get
			{
				return _countryCode;
			}
			set
			{
				if (_countryCode != value)
				{
					_countryCode = value;
					_country = null;
					// reset Country
					BLL.PersistedBusinessObject vCountry = (BLL.PersistedBusinessObject) Country;
					vCountry = null;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the PostalCode.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual string PostalCode
		{
			get
			{
				return _postalCode;
			}
			set
			{
				if ((_postalCode != null && !_postalCode.Equals(value)) || _postalCode != value)
				{
					_postalCode = value;
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
					_metaPartner = null;
					// reset MetaPartner
					BLL.PersistedBusinessObject vMetaPartner = (BLL.PersistedBusinessObject) MetaPartner;
					vMetaPartner = null;
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
				return (MOD.Data.DataHelper.GetString(LocationID,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					LocationID = MOD.Data.DataHelper.GetGuid(keyValues[0], MOD.Data.DefaultValue.Guid);
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
					return LocationTypeName;
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
				return (MOD.Data.DataHelper.GetString(LocationID,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					LocationID = MOD.Data.DataHelper.GetGuid(keyValues[0], MOD.Data.DefaultValue.Guid);
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
					return "LocationTypeName";
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
		/// <summary>This read only property gets the LocationTypeName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		public virtual string LocationTypeName
		{
			get
			{
				return _locationTypeName;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This read only property gets the CountryName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		public virtual string CountryName
		{
			get
			{
				return _countryName;
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
		/// <summary>This property gets or sets an item of LocationType.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Customers.LocationType LocationType
		{
			get
			{
				if (_locationType == null  && IsLazyLoadable == true)
				{
					_locationType = BLL.Customers.LocationTypeManager.GetOneLocationType((int)LocationTypeCode);
					// refresh derived properties
					if (_locationType != null)
					{
						_locationTypeName = _locationType.LocationTypeName;
					}
					else
					{
						_locationTypeName = MOD.Data.DefaultValue.String;
					}
				}
				return _locationType;
			}
			set
			{
				if (_locationType != value)
				{
					_locationType = value;
					_isDirty = true;
					// refresh derived properties
					if (_locationType != null)
					{
						_locationTypeName = _locationType.LocationTypeName;
					}
					else
					{
						_locationTypeName = MOD.Data.DefaultValue.String;
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
					_metaPartner = BLL.Customers.MetaPartnerManager.GetOneMetaPartner((Guid)MetaPartnerID);
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
		/// <summary>This property gets or sets an item of Country.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Environments.Country Country
		{
			get
			{
				if (_country == null  && IsLazyLoadable == true)
				{
					_country = BLL.Environments.CountryManager.GetOneCountry((int)CountryCode);
					// refresh derived properties
					if (_country != null)
					{
						_countryName = _country.CountryName;
					}
					else
					{
						_countryName = MOD.Data.DefaultValue.String;
					}
				}
				return _country;
			}
			set
			{
				if (_country != value)
				{
					_country = value;
					_isDirty = true;
					// refresh derived properties
					if (_country != null)
					{
						_countryName = _country.CountryName;
					}
					else
					{
						_countryName = MOD.Data.DefaultValue.String;
					}
				}
			}
		}
		#endregion Properties
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public Location()
		{
			//
			// constructor logic
			//
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method creates an instance with the primary key values.</summary>
		// ------------------------------------------------------------------------------
		public Location(string keyValues, bool isPrimaryKeyValues)
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
		/// <summary>This constructor initializes the Location from its DAL counterpart.</summary>
		// ------------------------------------------------------------------------------
		public Location(DAL.Customers.Location businessObject) : base(businessObject)
		{
		}
		// ------------------------------------------------------------------------------
		/// <summary>This constructor initializes the Location from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public Location(Guid locationID)
		{
			LocationID = locationID;
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the Location with its already set properties.</summary>
		// ------------------------------------------------------------------------------
		public void Load()
		{
			Load(LocationID);
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the Location from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public void Load(Guid locationID)
		{
			BLL.Customers.Location businessObject = null;
			businessObject = BLL.Customers.LocationManager.GetOneLocation(locationID);
			if(businessObject != null)
			{
				ReflectionHelper.Copy(businessObject, this, true);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the Location into the database,
		/// performing add/update auto detect and performing a cascade operation if indicated.</summary>
		// ------------------------------------------------------------------------------
		public void Save(bool performCascade)
		{
			if (IsLoaded == false)
			{
				BLL.Customers.LocationManager.UpsertOneLocation(this, performCascade);
			}
			else
			{
				BLL.Customers.LocationManager.UpsertOneLocation(this, performCascade);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the Location into the database,
		/// performing add/update auto detect and without performing a cascade operation.</summary>
		// ------------------------------------------------------------------------------
		public void Save()
		{
			Save(false);
		}
		/// <summary>
		///	Clears the dirty state of Location and its subcollections.
		/// </summary>
		/// <param name="clearCollectionDirtyState">Flag to clear subcollections.</param>
		/// <returns></returns>
		public override void ClearDirtyState(bool clearCollectionDirtyState)
		{
			// clear base items
			base.ClearDirtyState();
			// clear collections and other items
			if (this._locationType != null)
			{
				this.LocationType.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._metaPartner != null)
			{
				this.MetaPartner.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._country != null)
			{
				this.Country.ClearDirtyState(clearCollectionDirtyState);
			}
		}
		/// <summary>
		///	Tests to see if input object is convertable to Location, and has the same primary key values.
		/// </summary>
		/// <param name="obj">Input object to test.</param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			Location locationInstance = obj as Location;
			if (locationInstance == null)
				return false;
			else
				return (_locationID == locationInstance.LocationID);
		}
		/// <summary>
		///	Returns unique identifying integer		 
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return (_locationID.ToString()).GetHashCode();
		}
		#endregion Methods
	}
}