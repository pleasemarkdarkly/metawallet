

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
using DAL = MW.MComm.CarrierSim.DAL;
using Utility = MW.MComm.CarrierSim.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace MW.MComm.CarrierSim.DAL.Customers
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
	public partial class Customer : Utility.BaseDataAccessObject
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

		// for PrimaryName property
		protected string _primaryName = MOD.Data.DefaultValue.String;

		// for PrimaryIndex property
		protected string _primaryIndex = MOD.Data.DefaultValue.String;

		// for PrimarySortColumn property
		protected string _primarySortColumn = MOD.Data.DefaultValue.String;

		// for PhoneList property
		protected MOD.Data.SortableObjectCollection _phoneList = null;

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
		[XmlElementAttribute()]
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
		[XmlElementAttribute()]
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
					return "Name";
				}
			}
			set
			{
				_primarySortColumn = value;
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets Phone lists.</summary>
		// ------------------------------------------------------------------------------
		[XmlArrayItem(typeof(DAL.Customers.Phone), ElementName="Phone")]
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

		#endregion Constructors

		#region Methods

		// ------------------------------------------------------------------
		/// <summary>This method inserts or updates Customer data.</summary>
		///
		/// <param name="item">The Customer to be inserted or updated.</param>
		/// <param name="performCascadeOperation">Peform the changes to the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpsertOneCustomer(Customer item, bool performCascadeOperation, MOD.Data.DatabaseOptions dbOptions, int debugLevel)
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
				UpsertOneCustomer(item, performCascadeOperation, dbAdapter);

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
				throw Utility.CustomAppException.WrapException(ex, "DAL.Customers.UpsertOneCustomer");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method inserts or updates Customer data.</summary>
		///
		/// <param name="item">The Customer to be inserted or updated.</param>
		/// <param name="performCascadeOperation">Peform the changes to the child entities of the item, if any exist</param>
		/// <param name="dbAdapter">Database adapter for transaction</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpsertOneCustomer(Customer item, bool performCascadeOperation, MOD.Data.SqlProcAdapter dbAdapter)
		{
			try
			{
				// perform main method tasks
				MOD.Data.NamedObjectCollection spParameters = new MOD.Data.NamedObjectCollection();
				dbAdapter.ExecuteProcNQ("spCustomers_UpsertOneCustomer", item, spParameters);

				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				item.CustomerID = MOD.Data.DataHelper.GetGuid(spParameters["CustomerID"], MOD.Data.DefaultValue.Guid);
				item.Timestamp = ((System.Byte[])(spParameters["Timestamp"]));
				item.IsLoaded = true;

				#region Cascade Operations
				if (performCascadeOperation == true)
				{
					// cascade operations
					#region PhoneList
					if (item.PhoneList != null)
					{
						MOD.Data.SortableObjectCollection phoneList = DAL.Customers.Phone.GetAllPhoneDataByCustomerID(item.CustomerID, dbAdapter);

						// process updates and adds
						foreach(DAL.Customers.Phone loopPhone in item.PhoneList)
						{
							if (phoneList.Contains(loopPhone))
							{
								// update item
								loopPhone.LastModifiedByUserID = item.LastModifiedByUserID;
								DAL.Customers.Phone.UpsertOnePhone(loopPhone, false, dbAdapter);
							}
							else
							{
								// add item
								loopPhone.CreatedByUserID = item.CreatedByUserID;
								loopPhone.LastModifiedByUserID = item.LastModifiedByUserID;
								loopPhone.CustomerID = item.CustomerID;
								DAL.Customers.Phone.UpsertOnePhone(loopPhone, false, dbAdapter);
							}
						}

						// process deletions
						foreach(DAL.Customers.Phone loopPhone in phoneList)
						{
							if (!item.PhoneList.Contains(loopPhone))
							{
								DAL.Customers.Phone.DeleteOnePhone(loopPhone, false, dbAdapter);
							}
						}
					}
					#endregion PhoneList

				}

				#endregion Cascade Operations

			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Customers.UpsertOneCustomer");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method deletes Customer data.</summary>
		///
		/// <param name="item">The Customer to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the changes to the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneCustomer(Customer item, bool performCascadeOperation, MOD.Data.DatabaseOptions dbOptions, int debugLevel)
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
				DeleteOneCustomer(item, performCascadeOperation, dbAdapter);

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
				throw Utility.CustomAppException.WrapException(ex, "DAL.Customers.DeleteOneCustomer");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method deletes Customer data.</summary>
		///
		/// <param name="item">The Customer to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the changes to the child entities of the item, if any exist</param>
		/// <param name="dbAdapter">Database adapter for transaction</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneCustomer(Customer item, bool performCascadeOperation, MOD.Data.SqlProcAdapter dbAdapter)
		{
			try
			{
				// perform main method tasks

				#region Cascade Operations
				if (performCascadeOperation == true)
				{
					// cascade operations
					#region PhoneList
					MOD.Data.SortableObjectCollection phoneList = DAL.Customers.Phone.GetAllPhoneDataByCustomerID(item.CustomerID, dbAdapter);
					foreach(DAL.Customers.Phone loopPhone in phoneList)
					{
						DAL.Customers.Phone.DeleteOnePhone(loopPhone, false, dbAdapter);
					}
					#endregion PhoneList

				}
				#endregion Cascade Operations

				MOD.Data.NamedObjectCollection spParameters = new MOD.Data.NamedObjectCollection();
				dbAdapter.ExecuteProcNQ("spCustomers_DeleteOneCustomer", item, spParameters);

				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				item.IsLoaded = false;

				#region Cascade Operations
				if (performCascadeOperation == true)
				{
					// cascade operations
				}
				#endregion Cascade Operations

			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Customers.DeleteOneCustomer");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets a single Customer by an index.</summary>
		///
		/// <param name="customerID">A key for Customer items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static Customer GetOneCustomer(Guid customerID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel)
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
				Customer item = new Customer();
				spParameters["CustomerID"] = customerID;
				if(dataOptions != null)
				{
					dataOptions.PopulateNamedObjectCollection( spParameters );
					filterFields = dataOptions.FilterFields;
				}

				DataTable dt = dbAdapter.ExecuteProc("spCustomers_GetOneCustomer", null, spParameters);

				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);

				item = null;

				// get output item
				foreach(DataRow row in dt.Rows)
				{
					// get item
					item = (Customer) DataTransformAttribute.Transform(row, new Customer(), false, filterFields);
					item.IsLoaded = true;
					break;
				}

				return item;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Customers.GetOneCustomer");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets all Customer data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetAllCustomerData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel)
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

				DataTable dt = dbAdapter.ExecuteProc("spCustomers_GetAllCustomerData", null, spParameters);

				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);

				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					Customer item = (Customer) DataTransformAttribute.Transform(row, new Customer(), false, filterFields);
					item.IsLoaded = true;
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Customers.GetAllCustomerData");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets all Customer data by criteria.</summary>
		///
		/// <param name="lastModifiedDateStart">A key for Customer items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Customer items to be fetched</param>
		/// <param name="storedValueBalance">A key for Customer items to be fetched</param>
		/// <param name="name">A key for Customer items to be fetched</param>
		/// <param name="storedValueLockedBalance">A key for Customer items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetAllCustomerDataByCriteria(DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, float? storedValueBalance, string name, float? storedValueLockedBalance, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel)
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
				spParameters["LastModifiedDateStart"] = lastModifiedDateStart;
				spParameters["LastModifiedDateEnd"] = lastModifiedDateEnd;
				spParameters["StoredValueBalance"] = storedValueBalance;
				spParameters["Name"] = MOD.Data.SearchHelper.ReplaceSpecialSQLSearchChars(name);
				spParameters["StoredValueLockedBalance"] = storedValueLockedBalance;
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

				DataTable dt = dbAdapter.ExecuteProc("spCustomers_GetAllCustomerDataByCriteria", null, spParameters);

				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);

				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					Customer item = (Customer) DataTransformAttribute.Transform(row, new Customer(), false, filterFields);
					item.IsLoaded = true;
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Customers.GetAllCustomerDataByCriteria");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets many Customer data by criteria.</summary>
		///
		/// <param name="lastModifiedDateStart">A key for Customer items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Customer items to be fetched</param>
		/// <param name="storedValueBalance">A key for Customer items to be fetched</param>
		/// <param name="name">A key for Customer items to be fetched</param>
		/// <param name="storedValueLockedBalance">A key for Customer items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetManyCustomerDataByCriteria(DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, float? storedValueBalance, string name, float? storedValueLockedBalance, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel)
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
				spParameters["LastModifiedDateStart"] = lastModifiedDateStart;
				spParameters["LastModifiedDateEnd"] = lastModifiedDateEnd;
				spParameters["StoredValueBalance"] = storedValueBalance;
				spParameters["Name"] = MOD.Data.SearchHelper.ReplaceSpecialSQLSearchChars(name);
				spParameters["StoredValueLockedBalance"] = storedValueLockedBalance;
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

				DataTable dt = dbAdapter.ExecuteProc("spCustomers_GetManyCustomerDataByCriteria", null, spParameters);

				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				totalRecords = MOD.Data.DataHelper.GetInt(spParameters["TotalRecords"], MOD.Data.DefaultValue.Int);
				maximumListSizeExceeded = MOD.Data.DataHelper.GetBool(spParameters["MaximumListSizeExceeded"], MOD.Data.DefaultValue.Bool);

				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					Customer item = (Customer) DataTransformAttribute.Transform(row, new Customer(), false, filterFields);
					item.IsLoaded = true;
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Customers.GetManyCustomerDataByCriteria");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}


		/// <summary>
		///			 
		/// </summary>
		/// <param name="obj"></param>
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