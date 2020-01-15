

/*<copyright>
Meta Wallet, Inc (c) 2007 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2007, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
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
using MW.MComm.CarrierSim.BLL.Config;
using BLL = MW.MComm.CarrierSim.BLL;
using DAL = MW.MComm.CarrierSim.DAL;
using Utility = MW.MComm.CarrierSim.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace MW.MComm.CarrierSim.BLL.Customers
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to hold and manage information for Customer instances.</summary>
	///
	/// File History:
	/// <created>6/4/2007 (Chris Grundy)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[Serializable()]
	[XmlType(Namespace = "http://modsystems.com/MW.MComm.CarrierSim/Customers/DataTypes")]
	[DataTransform(Name = "MW.MComm.CarrierSim.DAL.Customers.Customer")]
	public partial class Customer : PersistedBusinessObject
	{

		#region Constants
		#endregion Constants

		#region Fields

		// for CustomerID property
		protected Guid _customerID = MOD.Data.DefaultValue.Guid;

		// for Name property
		protected string _name = "''";

		// for Address property
		protected string _address = null;

		// for StoredValueBalance property
		protected float _storedValueBalance = 0;

		// for StoredValueLockedBalance property
		protected float _storedValueLockedBalance = 0;

		// for PhoneList property
		protected BLL.SortableList<BLL.Customers.Phone> _phoneList = null;

		#endregion Fields

		#region Properties

		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CustomerID.</summary>
		// ------------------------------------------------------------------------------
		[XmlElementAttribute()]
		[DataTransform]
		public virtual Guid CustomerID
		{
			get
			{
				return _customerID;
			}
			set
			{
				if (_customerID != value)
				{
					_customerID = value;
					_isDirty = true;
				}
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the Name.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(null)]
		[XmlElementAttribute(IsNullable=true)]
		[DataTransform]
		public virtual string Name
		{
			get
			{
				return _name;
			}
			set
			{
				if ((_name != null && !_name.Equals(value)) || _name != value)
				{
					_name = value;
					_isDirty = true;
				}
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the Address.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(null)]
		[XmlElementAttribute(IsNullable=true)]
		[DataTransform]
		public virtual string Address
		{
			get
			{
				return _address;
			}
			set
			{
				if ((_address != null && !_address.Equals(value)) || _address != value)
				{
					_address = value;
					_isDirty = true;
				}
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the StoredValueBalance.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Float)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual float StoredValueBalance
		{
			get
			{
				return _storedValueBalance;
			}
			set
			{
				if (_storedValueBalance != value)
				{
					_storedValueBalance = value;
					_isDirty = true;
				}
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the StoredValueLockedBalance.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Float)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual float StoredValueLockedBalance
		{
			get
			{
				return _storedValueLockedBalance;
			}
			set
			{
				if (_storedValueLockedBalance != value)
				{
					_storedValueLockedBalance = value;
					_isDirty = true;
				}
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the primary key.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlIgnore]
		public string PrimaryKey
		{
			get
			{
				return (MOD.Data.DataHelper.GetString(CustomerID,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					CustomerID = MOD.Data.DataHelper.GetGuid(keyValues[0], MOD.Data.DefaultValue.Guid);
				}
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the primary name.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlIgnore]
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
					return Name;
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
		[XmlIgnore]
		public string PrimaryIndex
		{
			get
			{
				return (MOD.Data.DataHelper.GetString(CustomerID,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					CustomerID = MOD.Data.DataHelper.GetGuid(keyValues[0], MOD.Data.DefaultValue.Guid);
				}
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the primary sort column.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlIgnore]
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
					return "Name";
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

				base.IsCollectionDirty);
			}
		}



		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets Phone lists.</summary>
		// ------------------------------------------------------------------------------
		[XmlArrayItem(typeof(BLL.Customers.Phone), ElementName="Phone")]
		[DataTransform]
		public virtual BLL.SortableList<BLL.Customers.Phone> PhoneList
		{
			get
			{
				if (_phoneList == null && IsLazyLoadable == true)
				{
					_phoneList = BLL.Customers.PhoneManager.GetAllPhoneDataByCustomerID(CustomerID);
				}
				else if (_phoneList == null)
				{
					_phoneList = new BLL.SortableList<BLL.Customers.Phone>();
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

		#endregion Properties

		#region Constructors

		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public Customer()
		{
			//
			// constructor logic
			//
		}

		// ------------------------------------------------------------------------------
		/// <summary>This method creates an instance with the primary key values.</summary>
		// ------------------------------------------------------------------------------
		public Customer(string keyValues, bool isPrimaryKeyValues)
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
		/// <summary>This constructor initializes the Customer from its DAL counterpart.</summary>
		// ------------------------------------------------------------------------------
		public Customer(DAL.Customers.Customer businessObject) : base(businessObject)
		{
		}

		// ------------------------------------------------------------------------------
		/// <summary>This constructor initializes the Customer from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public Customer(Guid customerID)
		{
			CustomerID = customerID;
		}

		#endregion Constructors

		#region Methods

		// ------------------------------------------------------------------------------
		/// <summary>This method loads the Customer with its already set properties.</summary>
		// ------------------------------------------------------------------------------
		public void Load()
		{
			Load(CustomerID);
		}

		// ------------------------------------------------------------------------------
		/// <summary>This method loads the Customer from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public void Load(Guid customerID)
		{
			BLL.Customers.Customer businessObject = null;
			businessObject = BLL.Customers.CustomerManager.GetOneCustomer(customerID);
			if(businessObject != null)
			{
				ReflectionHelper.Copy(businessObject, this, true);
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This method saves the Customer into the database,
		/// performing add/update auto detect and performing a cascade operation if indicated.</summary>
		// ------------------------------------------------------------------------------
		public void Save(bool performCascade)
		{
			if (IsLoaded == false)
			{
				BLL.Customers.CustomerManager.UpsertOneCustomer(this, performCascade);
			}
			else
			{
				BLL.Customers.CustomerManager.UpsertOneCustomer(this, performCascade);
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This method saves the Customer into the database,
		/// performing add/update auto detect and without performing a cascade operation.</summary>
		// ------------------------------------------------------------------------------
		public void Save()
		{
			Save(false);
		}

		/// <summary>
		///	Clears the dirty state of Customer and its subcollections.
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
		}


		/// <summary>
		///	Tests to see if input object is convertable to Customer, and has the same primary key values.
		/// </summary>
		/// <param name="obj">Input object to test.</param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			Customer customerInstance = obj as Customer;

			if (customerInstance == null)
				return false;
			else
				return (_customerID == customerInstance.CustomerID);
		}


		/// <summary>
		///	Returns unique identifying integer		 
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return (_customerID.ToString()).GetHashCode();
		}
		#endregion Methods
	}
}