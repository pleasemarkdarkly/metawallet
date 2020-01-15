

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
	/// <summary>This class is used to hold and manage information for Phone instances.</summary>
	///
	/// File History:
	/// <created>6/4/2007 (Chris Grundy)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[Serializable()]
	[XmlType(Namespace = "http://modsystems.com/MW.MComm.CarrierSim/Customers/DataTypes")]
	[DataTransform(Name = "MW.MComm.CarrierSim.DAL.Customers.Phone")]
	public partial class Phone : PersistedBusinessObject
	{

		#region Constants
		#endregion Constants

		#region Fields

		// for PhoneNumber property
		protected string _phoneNumber = MOD.Data.DefaultValue.String;

		// for CustomerID property
		protected Guid _customerID = MOD.Data.DefaultValue.Guid;

		// for Balance property
		protected float _balance = MOD.Data.DefaultValue.Float;

		// for PhoneID property
		protected Guid _phoneID = MOD.Data.DefaultValue.Guid;

		// for Name read only property
		[DataTransform]
		protected string _name = "''";

		// for StoredValueBalance read only property
		[DataTransform]
		protected float _storedValueBalance = 0;

		// for StoredValueLockedBalance read only property
		[DataTransform]
		protected float _storedValueLockedBalance = 0;

		// for Customer property
		protected BLL.Customers.Customer _customer = null;

		#endregion Fields

		#region Properties

		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the PhoneNumber.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual string PhoneNumber
		{
			get
			{
				return _phoneNumber;
			}
			set
			{
				if ((_phoneNumber != null && !_phoneNumber.Equals(value)) || _phoneNumber != value)
				{
					_phoneNumber = value;
					_isDirty = true;
				}
			}
		}

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
					_customer = null;

					// reset Customer
					BLL.PersistedBusinessObject vCustomer = (BLL.PersistedBusinessObject) Customer;
					vCustomer = null;
					_isDirty = true;
				}
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the Balance.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Float)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual float Balance
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
		/// <summary>This property gets or sets the PhoneID.</summary>
		// ------------------------------------------------------------------------------
		[XmlElementAttribute()]
		[DataTransform]
		public virtual Guid PhoneID
		{
			get
			{
				return _phoneID;
			}
			set
			{
				if (_phoneID != value)
				{
					_phoneID = value;
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
				return (MOD.Data.DataHelper.GetString(PhoneID,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					PhoneID = MOD.Data.DataHelper.GetGuid(keyValues[0], MOD.Data.DefaultValue.Guid);
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
				return (MOD.Data.DataHelper.GetString(PhoneID,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					PhoneID = MOD.Data.DataHelper.GetGuid(keyValues[0], MOD.Data.DefaultValue.Guid);
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
				return (
				base.IsCollectionDirty);
			}
		}



		// ------------------------------------------------------------------------------
		/// <summary>This read only property gets the Name.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(null)]
		[XmlElementAttribute(IsNullable=true)]
		public virtual string Name
		{
			get
			{
				return _name;
			}
			set
			{
				if (IsSerializing == false)
				{
					//throw (new System.InvalidOperationException("This property cannot be set, this is just for serialization."));
				}
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This read only property gets the StoredValueBalance.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Float)]
		[XmlElementAttribute()]
		public virtual float StoredValueBalance
		{
			get
			{
				return _storedValueBalance;
			}
			set
			{
				if (IsSerializing == false)
				{
					//throw (new System.InvalidOperationException("This property cannot be set, this is just for serialization."));
				}
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This read only property gets the StoredValueLockedBalance.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Float)]
		[XmlElementAttribute()]
		public virtual float StoredValueLockedBalance
		{
			get
			{
				return _storedValueLockedBalance;
			}
			set
			{
				if (IsSerializing == false)
				{
					//throw (new System.InvalidOperationException("This property cannot be set, this is just for serialization."));
				}
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of Customer.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Customers.Customer Customer
		{
			get
			{
				if (_customer == null  && IsLazyLoadable == true)
				{
					_customer = BLL.Customers.CustomerManager.GetOneCustomer((Guid)CustomerID);

					// refresh derived properties
					if (_customer != null)
					{
						_name = _customer.Name;
						_storedValueBalance = _customer.StoredValueBalance;
						_storedValueLockedBalance = _customer.StoredValueLockedBalance;
					}
					else
					{
						_name = MOD.Data.DefaultValue.String;
						_storedValueBalance = MOD.Data.DefaultValue.Float;
						_storedValueLockedBalance = MOD.Data.DefaultValue.Float;
					}
				}

				return _customer;
			}
			set
			{
				if (_customer != value)
				{
					_customer = value;
					_isDirty = true;

					// refresh derived properties
					if (_customer != null)
					{
						_name = _customer.Name;
						_storedValueBalance = _customer.StoredValueBalance;
						_storedValueLockedBalance = _customer.StoredValueLockedBalance;
					}
					else
					{
						_name = MOD.Data.DefaultValue.String;
						_storedValueBalance = MOD.Data.DefaultValue.Float;
						_storedValueLockedBalance = MOD.Data.DefaultValue.Float;
					}
				}
			}
		}

		#endregion Properties

		#region Constructors

		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public Phone()
		{
			//
			// constructor logic
			//
		}

		// ------------------------------------------------------------------------------
		/// <summary>This method creates an instance with the primary key values.</summary>
		// ------------------------------------------------------------------------------
		public Phone(string keyValues, bool isPrimaryKeyValues)
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
		/// <summary>This constructor initializes the Phone from its DAL counterpart.</summary>
		// ------------------------------------------------------------------------------
		public Phone(DAL.Customers.Phone businessObject) : base(businessObject)
		{
		}

		// ------------------------------------------------------------------------------
		/// <summary>This constructor initializes the Phone from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public Phone(Guid phoneID)
		{
			PhoneID = phoneID;
		}

		#endregion Constructors

		#region Methods

		// ------------------------------------------------------------------------------
		/// <summary>This method loads the Phone with its already set properties.</summary>
		// ------------------------------------------------------------------------------
		public void Load()
		{
			Load(PhoneID);
		}

		// ------------------------------------------------------------------------------
		/// <summary>This method loads the Phone from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public void Load(Guid phoneID)
		{
			BLL.Customers.Phone businessObject = null;
			businessObject = BLL.Customers.PhoneManager.GetOnePhone(phoneID);
			if(businessObject != null)
			{
				ReflectionHelper.Copy(businessObject, this, true);
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This method saves the Phone into the database,
		/// performing add/update auto detect and performing a cascade operation if indicated.</summary>
		// ------------------------------------------------------------------------------
		public void Save(bool performCascade)
		{
			if (IsLoaded == false)
			{
				BLL.Customers.PhoneManager.UpsertOnePhone(this, performCascade);
			}
			else
			{
				BLL.Customers.PhoneManager.UpsertOnePhone(this, performCascade);
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This method saves the Phone into the database,
		/// performing add/update auto detect and without performing a cascade operation.</summary>
		// ------------------------------------------------------------------------------
		public void Save()
		{
			Save(false);
		}

		/// <summary>
		///	Clears the dirty state of Phone and its subcollections.
		/// </summary>
		/// <param name="clearCollectionDirtyState">Flag to clear subcollections.</param>
		/// <returns></returns>
		public override void ClearDirtyState(bool clearCollectionDirtyState)
		{
			// clear base items
			base.ClearDirtyState();

			// clear collections and other items
			if (this._customer != null)
			{
				this.Customer.ClearDirtyState(clearCollectionDirtyState);
			}
		}


		/// <summary>
		///	Tests to see if input object is convertable to Phone, and has the same primary key values.
		/// </summary>
		/// <param name="obj">Input object to test.</param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			Phone phoneInstance = obj as Phone;

			if (phoneInstance == null)
				return false;
			else
				return (_phoneID == phoneInstance.PhoneID);
		}


		/// <summary>
		///	Returns unique identifying integer		 
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return (_phoneID.ToString()).GetHashCode();
		}
		#endregion Methods
	}
}