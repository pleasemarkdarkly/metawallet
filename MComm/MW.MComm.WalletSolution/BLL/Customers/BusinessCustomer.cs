
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
	/// <summary>This class is used to hold and manage information for BusinessCustomer instances.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[Serializable()]
	[DataTransform(Name = "MW.MComm.WalletSolution.DAL.Customers.BusinessCustomer")]
	public partial class BusinessCustomer : PersistedBusinessObject
	{
		#region Constants
		#endregion Constants
		#region Fields
		// for BusinessMetaPartnerID property
		protected Guid _businessMetaPartnerID = MOD.Data.DefaultValue.Guid;
		// for CustomerMetaPartnerID property
		protected Guid _customerMetaPartnerID = MOD.Data.DefaultValue.Guid;
		// for FirstName read only property
		[DataTransform]
		protected string _firstName = null;
		// for LastName read only property
		[DataTransform]
		protected string _lastName = null;
		// for Business property
		protected BLL.Customers.Business _business = null;
		// for Customer property
		protected BLL.Customers.Customer _customer = null;
		#endregion Fields
		#region Properties
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the BusinessMetaPartnerID.</summary>
		// ------------------------------------------------------------------------------
		[XmlElementAttribute()]
		[DataTransform]
		public virtual Guid BusinessMetaPartnerID
		{
			get
			{
				return _businessMetaPartnerID;
			}
			set
			{
				if (_businessMetaPartnerID != value)
				{
					_businessMetaPartnerID = value;
					_business = null;
					// reset Business
					BLL.PersistedBusinessObject vBusiness = (BLL.PersistedBusinessObject) Business;
					vBusiness = null;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CustomerMetaPartnerID.</summary>
		// ------------------------------------------------------------------------------
		[XmlElementAttribute()]
		[DataTransform]
		public virtual Guid CustomerMetaPartnerID
		{
			get
			{
				return _customerMetaPartnerID;
			}
			set
			{
				if (_customerMetaPartnerID != value)
				{
					_customerMetaPartnerID = value;
					_customer = null;
					// reset Customer
					BLL.PersistedBusinessObject vCustomer = (BLL.PersistedBusinessObject) Customer;
					vCustomer = null;
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
				return (MOD.Data.DataHelper.GetString(BusinessMetaPartnerID,"") + ", " + MOD.Data.DataHelper.GetString(CustomerMetaPartnerID,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					BusinessMetaPartnerID = MOD.Data.DataHelper.GetGuid(keyValues[0], MOD.Data.DefaultValue.Guid);
				}
				if (keyValues.Length > 1)
				{
					CustomerMetaPartnerID = MOD.Data.DataHelper.GetGuid(keyValues[1], MOD.Data.DefaultValue.Guid);
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
					return FirstName;
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
				return (MOD.Data.DataHelper.GetString(BusinessMetaPartnerID,"") + ", " + MOD.Data.DataHelper.GetString(CustomerMetaPartnerID,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					BusinessMetaPartnerID = MOD.Data.DataHelper.GetGuid(keyValues[0], MOD.Data.DefaultValue.Guid);
				}
				if (keyValues.Length > 1)
				{
					CustomerMetaPartnerID = MOD.Data.DataHelper.GetGuid(keyValues[1], MOD.Data.DefaultValue.Guid);
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
					return "FirstName";
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
		/// <summary>This read only property gets the FirstName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(null)]
		[XmlElementAttribute(IsNullable=true)]
		public virtual string FirstName
		{
			get
			{
				return _firstName;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This read only property gets the LastName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(null)]
		[XmlElementAttribute(IsNullable=true)]
		public virtual string LastName
		{
			get
			{
				return _lastName;
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
					_business = BLL.Customers.BusinessManager.GetOneBusiness((Guid)BusinessMetaPartnerID);
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
					_customer = BLL.Customers.CustomerManager.GetOneCustomer((Guid)CustomerMetaPartnerID);
					// refresh derived properties
					if (_customer != null)
					{
						_firstName = _customer.FirstName;
						_lastName = _customer.LastName;
					}
					else
					{
						_firstName = MOD.Data.DefaultValue.String;
						_lastName = MOD.Data.DefaultValue.String;
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
						_firstName = _customer.FirstName;
						_lastName = _customer.LastName;
					}
					else
					{
						_firstName = MOD.Data.DefaultValue.String;
						_lastName = MOD.Data.DefaultValue.String;
					}
				}
			}
		}
		#endregion Properties
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public BusinessCustomer()
		{
			//
			// constructor logic
			//
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method creates an instance with the primary key values.</summary>
		// ------------------------------------------------------------------------------
		public BusinessCustomer(string keyValues, bool isPrimaryKeyValues)
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
		/// <summary>This constructor initializes the BusinessCustomer from its DAL counterpart.</summary>
		// ------------------------------------------------------------------------------
		public BusinessCustomer(DAL.Customers.BusinessCustomer businessObject) : base(businessObject)
		{
		}
		// ------------------------------------------------------------------------------
		/// <summary>This constructor initializes the BusinessCustomer from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public BusinessCustomer(Guid businessMetaPartnerID, Guid customerMetaPartnerID)
		{
			BusinessMetaPartnerID = businessMetaPartnerID;
			CustomerMetaPartnerID = customerMetaPartnerID;
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the BusinessCustomer with its already set properties.</summary>
		// ------------------------------------------------------------------------------
		public void Load()
		{
			Load(BusinessMetaPartnerID, CustomerMetaPartnerID);
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the BusinessCustomer from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public void Load(Guid businessMetaPartnerID, Guid customerMetaPartnerID)
		{
			BLL.Customers.BusinessCustomer businessObject = null;
			businessObject = BLL.Customers.BusinessCustomerManager.GetOneBusinessCustomer(businessMetaPartnerID, customerMetaPartnerID);
			if(businessObject != null)
			{
				ReflectionHelper.Copy(businessObject, this, true);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the BusinessCustomer into the database,
		/// performing add/update auto detect and performing a cascade operation if indicated.</summary>
		// ------------------------------------------------------------------------------
		public void Save(bool performCascade)
		{
			if (IsLoaded == false)
			{
				BLL.Customers.BusinessCustomerManager.AddOneBusinessCustomer(this, performCascade);
			}
			else
			{
				BLL.Customers.BusinessCustomerManager.UpdateOneBusinessCustomer(this, performCascade);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the BusinessCustomer into the database,
		/// performing add/update auto detect and without performing a cascade operation.</summary>
		// ------------------------------------------------------------------------------
		public void Save()
		{
			Save(false);
		}
		/// <summary>
		///	Clears the dirty state of BusinessCustomer and its subcollections.
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
			if (this._customer != null)
			{
				this.Customer.ClearDirtyState(clearCollectionDirtyState);
			}
		}
		/// <summary>
		///	Tests to see if input object is convertable to BusinessCustomer, and has the same primary key values.
		/// </summary>
		/// <param name="obj">Input object to test.</param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			BusinessCustomer businessCustomerInstance = obj as BusinessCustomer;
			if (businessCustomerInstance == null)
				return false;
			else
				return (_businessMetaPartnerID == businessCustomerInstance.BusinessMetaPartnerID && 
					_customerMetaPartnerID == businessCustomerInstance.CustomerMetaPartnerID);
		}
		/// <summary>
		///	Returns unique identifying integer		 
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return (_businessMetaPartnerID.ToString() + _customerMetaPartnerID.ToString()).GetHashCode();
		}
		#endregion Methods
	}
}