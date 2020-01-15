
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
	/// <summary>This class is used to hold and manage information for MetaPartnerPhone instances.</summary>
	///
	/// File History:
	/// <created>2/28/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[Serializable()]
	public partial class MetaPartnerPhone : Utility.BaseDataAccessObject
	{
		#region Constants
		#endregion Constants
		#region Fields
		// for MetaPartnerPhoneID property
		protected Guid _metaPartnerPhoneID = MOD.Data.DefaultValue.Guid;
		// for PhoneNumber property
		protected string _phoneNumber = MOD.Data.DefaultValue.String;
		// for MetaPartnerID property
		protected Guid _metaPartnerID = MOD.Data.DefaultValue.Guid;
		// for PIN property
		protected string _pIN = MOD.Data.DefaultValue.String;
		// for CarrierMetaPartnerID property
		protected Guid _carrierMetaPartnerID = MOD.Data.DefaultValue.Guid;
		// for Rank property
		protected int _rank = 0;
		// for IsActive property
		protected bool _isActive = false;
		// for DisplayName read only property
		[DataTransform]
		protected string _displayName = MOD.Data.DefaultValue.String;
		// for PrimaryName property
		protected string _primaryName = MOD.Data.DefaultValue.String;
		// for PrimaryIndex property
		protected string _primaryIndex = MOD.Data.DefaultValue.String;
		// for PrimarySortColumn property
		protected string _primarySortColumn = MOD.Data.DefaultValue.String;
		// for MetaPartnerName read only property
		[DataTransform]
		protected string _metaPartnerName = MOD.Data.DefaultValue.String;
		// for DateFormatCode read only property
		[DataTransform]
		protected int _dateFormatCode = MOD.Data.DefaultValue.Int;
		// for Carrier property
		protected DAL.Customers.Carrier _carrier = null;
		// for MetaPartner property
		protected DAL.Customers.MetaPartner _metaPartner = null;
		#endregion Fields
		#region Properties
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the MetaPartnerPhoneID.</summary>
		// ------------------------------------------------------------------------------
		[XmlElementAttribute()]
		[DataTransform]
		public virtual Guid MetaPartnerPhoneID
		{
			get
			{
				return _metaPartnerPhoneID;
			}
			set
			{
				if (_metaPartnerPhoneID != value)
				{
					_metaPartnerPhoneID = value;
					_isDirty = true;
				}
			}
		}
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
		/// <summary>This property gets or sets the PIN.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual string PIN
		{
			get
			{
				return _pIN;
			}
			set
			{
				if ((_pIN != null && !_pIN.Equals(value)) || _pIN != value)
				{
					_pIN = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CarrierMetaPartnerID.</summary>
		// ------------------------------------------------------------------------------
		[XmlElementAttribute()]
		[DataTransform]
		public virtual Guid CarrierMetaPartnerID
		{
			get
			{
				return _carrierMetaPartnerID;
			}
			set
			{
				if (_carrierMetaPartnerID != value)
				{
					_carrierMetaPartnerID = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the Rank.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Int)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual int Rank
		{
			get
			{
				return _rank;
			}
			set
			{
				if (_rank != value)
				{
					_rank = value;
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
		/// <summary>This read only property gets the DisplayName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		public virtual string DisplayName
		{
			get
			{
				return _displayName;
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
				return (MOD.Data.DataHelper.GetString(MetaPartnerPhoneID,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					MetaPartnerPhoneID = MOD.Data.DataHelper.GetGuid(keyValues[0], MOD.Data.DefaultValue.Guid);
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
					return DisplayName;
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
				return (MOD.Data.DataHelper.GetString(MetaPartnerPhoneID,"") + ", " + MOD.Data.DataHelper.GetString(MetaPartnerID,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					MetaPartnerPhoneID = MOD.Data.DataHelper.GetGuid(keyValues[0], MOD.Data.DefaultValue.Guid);
				}
				if (keyValues.Length > 1)
				{
					MetaPartnerID = MOD.Data.DataHelper.GetGuid(keyValues[1], MOD.Data.DefaultValue.Guid);
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
					return "DisplayName";
				}
			}
			set
			{
				_primarySortColumn = value;
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
		/// <summary>This property gets or sets an item of Carrier.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual DAL.Customers.Carrier Carrier
		{
			get
			{
				return _carrier;
			}
			set
			{
				_carrier = value;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of MetaPartner.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual DAL.Customers.MetaPartner MetaPartner
		{
			get
			{
				return _metaPartner;
			}
			set
			{
				_metaPartner = value;
			}
		}
		#endregion Properties
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public MetaPartnerPhone()
		{
			//
			// constructor logic
			//
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method creates an instance with the primary key values.</summary>
		// ------------------------------------------------------------------------------
		public MetaPartnerPhone(string keyValues, bool isPrimaryKeyValues)
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
		/// <summary>This method inserts or updates MetaPartnerPhone data.</summary>
		///
		/// <param name="item">The MetaPartnerPhone to be inserted or updated.</param>
		/// <param name="performCascadeOperation">Peform the changes to the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpsertOneMetaPartnerPhone(MetaPartnerPhone item, bool performCascadeOperation, MOD.Data.DatabaseOptions dbOptions, int debugLevel)
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
				UpsertOneMetaPartnerPhone(item, performCascadeOperation, dbAdapter);
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
				throw Utility.CustomAppException.WrapException(ex, "DAL.Customers.UpsertOneMetaPartnerPhone");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method inserts or updates MetaPartnerPhone data.</summary>
		///
		/// <param name="item">The MetaPartnerPhone to be inserted or updated.</param>
		/// <param name="performCascadeOperation">Peform the changes to the child entities of the item, if any exist</param>
		/// <param name="dbAdapter">Database adapter for transaction</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpsertOneMetaPartnerPhone(MetaPartnerPhone item, bool performCascadeOperation, MOD.Data.SqlProcAdapter dbAdapter)
		{
			try
			{
				// perform main method tasks
				MOD.Data.NamedObjectCollection spParameters = new MOD.Data.NamedObjectCollection();
				try
				{
					item.PIN = MOD.Data.Encryption.EncryptString(item.PIN);
				}
				catch (System.Exception ex)
				{
					// revert to clear text
					MW.MComm.WalletSolution.Utility.CustomAppException.HandleException(ex);
				}
				dbAdapter.ExecuteProcNQ("spCustomers_UpsertOneMetaPartnerPhone", item, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				item.MetaPartnerPhoneID = MOD.Data.DataHelper.GetGuid(spParameters["MetaPartnerPhoneID"], MOD.Data.DefaultValue.Guid);
				item.Timestamp = ((System.Byte[])(spParameters["Timestamp"]));
				item.IsLoaded = true;
				#region Cascade Operations
				if (performCascadeOperation == true)
				{
					// cascade operations
				}
				#endregion Cascade Operations
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Customers.UpsertOneMetaPartnerPhone");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes MetaPartnerPhone data.</summary>
		///
		/// <param name="item">The MetaPartnerPhone to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the changes to the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneMetaPartnerPhone(MetaPartnerPhone item, bool performCascadeOperation, MOD.Data.DatabaseOptions dbOptions, int debugLevel)
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
				DeleteOneMetaPartnerPhone(item, performCascadeOperation, dbAdapter);
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
				throw Utility.CustomAppException.WrapException(ex, "DAL.Customers.DeleteOneMetaPartnerPhone");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes MetaPartnerPhone data.</summary>
		///
		/// <param name="item">The MetaPartnerPhone to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the changes to the child entities of the item, if any exist</param>
		/// <param name="dbAdapter">Database adapter for transaction</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneMetaPartnerPhone(MetaPartnerPhone item, bool performCascadeOperation, MOD.Data.SqlProcAdapter dbAdapter)
		{
			try
			{
				// perform main method tasks
				#region Cascade Operations
				if (performCascadeOperation == true)
				{
					// cascade operations
				}
				#endregion Cascade Operations
				MOD.Data.NamedObjectCollection spParameters = new MOD.Data.NamedObjectCollection();
				dbAdapter.ExecuteProcNQ("spCustomers_DeleteOneMetaPartnerPhone", item, spParameters);
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
				throw Utility.CustomAppException.WrapException(ex, "DAL.Customers.DeleteOneMetaPartnerPhone");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all MetaPartnerPhone data by a key.</summary>
		///
		/// <param name="performCascadeOperation">Peform the deletes of the child entities of the item, if any exist</param>
		/// <param name="carrierMetaPartnerID">A key for MetaPartnerPhone items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllMetaPartnerPhoneDataByCarrierMetaPartnerID(Guid carrierMetaPartnerID, MOD.Data.DatabaseOptions dbOptions, int debugLevel)
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
				DeleteAllMetaPartnerPhoneDataByCarrierMetaPartnerID(carrierMetaPartnerID, dbAdapter);
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
				throw Utility.CustomAppException.WrapException(ex, "DAL.Customers.DeleteAllMetaPartnerPhoneDataByCarrierMetaPartnerID");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all MetaPartnerPhone data by a key.</summary>
		///
		/// <param name="performCascadeOperation">Peform the deletes of the child entities of the item, if any exist</param>
		/// <param name="carrierMetaPartnerID">A key for MetaPartnerPhone items to be deleted</param>
		/// <param name="dbAdapter">Database adapter for transaction</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllMetaPartnerPhoneDataByCarrierMetaPartnerID(Guid carrierMetaPartnerID, MOD.Data.SqlProcAdapter dbAdapter)
		{
			try
			{
				// perform main method tasks
				MOD.Data.NamedObjectCollection spParameters = new MOD.Data.NamedObjectCollection();
				spParameters["CarrierMetaPartnerID"] = carrierMetaPartnerID;
				dbAdapter.ExecuteProcNQ("spCustomers_DeleteAllMetaPartnerPhoneDataByCarrierMetaPartnerID", null, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Customers.DeleteAllMetaPartnerPhoneDataByCarrierMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all MetaPartnerPhone data by a key.</summary>
		///
		/// <param name="performCascadeOperation">Peform the deletes of the child entities of the item, if any exist</param>
		/// <param name="metaPartnerID">A key for MetaPartnerPhone items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllMetaPartnerPhoneDataByMetaPartnerID(Guid metaPartnerID, MOD.Data.DatabaseOptions dbOptions, int debugLevel)
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
				DeleteAllMetaPartnerPhoneDataByMetaPartnerID(metaPartnerID, dbAdapter);
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
				throw Utility.CustomAppException.WrapException(ex, "DAL.Customers.DeleteAllMetaPartnerPhoneDataByMetaPartnerID");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all MetaPartnerPhone data by a key.</summary>
		///
		/// <param name="performCascadeOperation">Peform the deletes of the child entities of the item, if any exist</param>
		/// <param name="metaPartnerID">A key for MetaPartnerPhone items to be deleted</param>
		/// <param name="dbAdapter">Database adapter for transaction</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllMetaPartnerPhoneDataByMetaPartnerID(Guid metaPartnerID, MOD.Data.SqlProcAdapter dbAdapter)
		{
			try
			{
				// perform main method tasks
				MOD.Data.NamedObjectCollection spParameters = new MOD.Data.NamedObjectCollection();
				spParameters["MetaPartnerID"] = metaPartnerID;
				dbAdapter.ExecuteProcNQ("spCustomers_DeleteAllMetaPartnerPhoneDataByMetaPartnerID", null, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Customers.DeleteAllMetaPartnerPhoneDataByMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single MetaPartnerPhone by an index.</summary>
		///
		/// <param name="metaPartnerPhoneID">A key for MetaPartnerPhone items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MetaPartnerPhone GetOneMetaPartnerPhone(Guid metaPartnerPhoneID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel)
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
				MetaPartnerPhone item = new MetaPartnerPhone();
				spParameters["MetaPartnerPhoneID"] = metaPartnerPhoneID;
				if(dataOptions != null)
				{
					dataOptions.PopulateNamedObjectCollection( spParameters );
					filterFields = dataOptions.FilterFields;
				}
				DataTable dt = dbAdapter.ExecuteProc("spCustomers_GetOneMetaPartnerPhone", null, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				item = null;
				// get output item
				foreach(DataRow row in dt.Rows)
				{
					// get item
					item = (MetaPartnerPhone) DataTransformAttribute.Transform(row, new MetaPartnerPhone(), false, filterFields);
					item.IsLoaded = true;
					try
					{
						item.PIN = MOD.Data.Encryption.DecryptString(item.PIN);
					}
					catch (System.Exception ex)
					{
						// revert to clear text and handle exception
						MW.MComm.WalletSolution.Utility.CustomAppException.HandleException(ex);
					}
					break;
				}
				return item;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Customers.GetOneMetaPartnerPhone");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single MetaPartnerPhone by an index.</summary>
		///
		/// <param name="phoneNumber">A key for MetaPartnerPhone items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MetaPartnerPhone GetOneMetaPartnerPhoneByPhoneNumber(string phoneNumber, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel)
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
				MetaPartnerPhone item = new MetaPartnerPhone();
				spParameters["PhoneNumber"] = phoneNumber;
				if(dataOptions != null)
				{
					dataOptions.PopulateNamedObjectCollection( spParameters );
					filterFields = dataOptions.FilterFields;
				}
				DataTable dt = dbAdapter.ExecuteProc("spCustomers_GetOneMetaPartnerPhoneByPhoneNumber", null, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				item = null;
				// get output item
				foreach(DataRow row in dt.Rows)
				{
					// get item
					item = (MetaPartnerPhone) DataTransformAttribute.Transform(row, new MetaPartnerPhone(), false, filterFields);
					item.IsLoaded = true;
					try
					{
						item.PIN = MOD.Data.Encryption.DecryptString(item.PIN);
					}
					catch (System.Exception ex)
					{
						// revert to clear text and handle exception
						MW.MComm.WalletSolution.Utility.CustomAppException.HandleException(ex);
					}
					break;
				}
				return item;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Customers.GetOneMetaPartnerPhoneByPhoneNumber");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartnerPhone data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetAllMetaPartnerPhoneData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel)
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
				DataTable dt = dbAdapter.ExecuteProc("spCustomers_GetAllMetaPartnerPhoneData", null, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					MetaPartnerPhone item = (MetaPartnerPhone) DataTransformAttribute.Transform(row, new MetaPartnerPhone(), false, filterFields);
					item.IsLoaded = true;
					try
					{
						item.PIN = MOD.Data.Encryption.DecryptString(item.PIN);
					}
					catch (System.Exception ex)
					{
						// revert to clear text
						MW.MComm.WalletSolution.Utility.CustomAppException.HandleException(ex);
					}
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Customers.GetAllMetaPartnerPhoneData");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartnerPhone data by a key.</summary>
		///
		/// <param name="carrierMetaPartnerID">A key for MetaPartnerPhone items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetAllMetaPartnerPhoneDataByCarrierMetaPartnerID(Guid carrierMetaPartnerID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel)
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
				spParameters["CarrierMetaPartnerID"] = carrierMetaPartnerID;
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
				DataTable dt = dbAdapter.ExecuteProc("spCustomers_GetAllMetaPartnerPhoneDataByCarrierMetaPartnerID", null, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					MetaPartnerPhone item = (MetaPartnerPhone) DataTransformAttribute.Transform(row, new MetaPartnerPhone(), false, filterFields);
					item.IsLoaded = true;
					try
					{
						item.PIN = MOD.Data.Encryption.DecryptString(item.PIN);
					}
					catch (System.Exception ex)
					{
						// revert to clear text
						MW.MComm.WalletSolution.Utility.CustomAppException.HandleException(ex);
					}
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Customers.GetAllMetaPartnerPhoneDataByCarrierMetaPartnerID");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartnerPhone data by a key.</summary>
		///
		/// <param name="carrierMetaPartnerID">A key for MetaPartnerPhone items to be fetched</param>
		/// <param name="dbAdapter">Database adapter for transaction</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetAllMetaPartnerPhoneDataByCarrierMetaPartnerID(Guid carrierMetaPartnerID, MOD.Data.SqlProcAdapter dbAdapter)
		{
			try
			{
				// perform main method tasks
				MOD.Data.NamedObjectCollection spParameters = new MOD.Data.NamedObjectCollection();
				MOD.Data.NamedObjectCollection filterFields = new MOD.Data.NamedObjectCollection();
				MOD.Data.SortableObjectCollection items = new MOD.Data.SortableObjectCollection();
				spParameters["CarrierMetaPartnerID"] = carrierMetaPartnerID;
				spParameters["IncludeInactive"] = true;
				spParameters["IncludeDateInactive"] = true;
				DataTable dt = dbAdapter.ExecuteProc("spCustomers_GetAllMetaPartnerPhoneDataByCarrierMetaPartnerID", null, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					MetaPartnerPhone item = (MetaPartnerPhone) DataTransformAttribute.Transform(row, new MetaPartnerPhone(), false);
					item.IsLoaded = true;
					try
					{
						item.PIN = MOD.Data.Encryption.DecryptString(item.PIN);
					}
					catch (System.Exception ex)
					{
						// revert to clear text
						MW.MComm.WalletSolution.Utility.CustomAppException.HandleException(ex);
					}
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Customers.GetAllMetaPartnerPhoneDataByCarrierMetaPartnerID");
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartnerPhone data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for MetaPartnerPhone items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetAllMetaPartnerPhoneDataByMetaPartnerID(Guid metaPartnerID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel)
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
				spParameters["MetaPartnerID"] = metaPartnerID;
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
				DataTable dt = dbAdapter.ExecuteProc("spCustomers_GetAllMetaPartnerPhoneDataByMetaPartnerID", null, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					MetaPartnerPhone item = (MetaPartnerPhone) DataTransformAttribute.Transform(row, new MetaPartnerPhone(), false, filterFields);
					item.IsLoaded = true;
					try
					{
						item.PIN = MOD.Data.Encryption.DecryptString(item.PIN);
					}
					catch (System.Exception ex)
					{
						// revert to clear text
						MW.MComm.WalletSolution.Utility.CustomAppException.HandleException(ex);
					}
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Customers.GetAllMetaPartnerPhoneDataByMetaPartnerID");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartnerPhone data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for MetaPartnerPhone items to be fetched</param>
		/// <param name="dbAdapter">Database adapter for transaction</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetAllMetaPartnerPhoneDataByMetaPartnerID(Guid metaPartnerID, MOD.Data.SqlProcAdapter dbAdapter)
		{
			try
			{
				// perform main method tasks
				MOD.Data.NamedObjectCollection spParameters = new MOD.Data.NamedObjectCollection();
				MOD.Data.NamedObjectCollection filterFields = new MOD.Data.NamedObjectCollection();
				MOD.Data.SortableObjectCollection items = new MOD.Data.SortableObjectCollection();
				spParameters["MetaPartnerID"] = metaPartnerID;
				spParameters["IncludeInactive"] = true;
				spParameters["IncludeDateInactive"] = true;
				DataTable dt = dbAdapter.ExecuteProc("spCustomers_GetAllMetaPartnerPhoneDataByMetaPartnerID", null, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					MetaPartnerPhone item = (MetaPartnerPhone) DataTransformAttribute.Transform(row, new MetaPartnerPhone(), false);
					item.IsLoaded = true;
					try
					{
						item.PIN = MOD.Data.Encryption.DecryptString(item.PIN);
					}
					catch (System.Exception ex)
					{
						// revert to clear text
						MW.MComm.WalletSolution.Utility.CustomAppException.HandleException(ex);
					}
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Customers.GetAllMetaPartnerPhoneDataByMetaPartnerID");
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartnerPhone data by criteria.</summary>
		///
		/// <param name="phoneNumber">A key for MetaPartnerPhone items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for MetaPartnerPhone items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for MetaPartnerPhone items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetAllMetaPartnerPhoneDataByCriteria(string phoneNumber, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel)
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
				spParameters["PhoneNumber"] = MOD.Data.SearchHelper.ReplaceSpecialSQLSearchChars(phoneNumber);
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
				DataTable dt = dbAdapter.ExecuteProc("spCustomers_GetAllMetaPartnerPhoneDataByCriteria", null, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					MetaPartnerPhone item = (MetaPartnerPhone) DataTransformAttribute.Transform(row, new MetaPartnerPhone(), false, filterFields);
					item.IsLoaded = true;
					try
					{
						item.PIN = MOD.Data.Encryption.DecryptString(item.PIN);
					}
					catch (System.Exception ex)
					{
						// revert to clear text
						MW.MComm.WalletSolution.Utility.CustomAppException.HandleException(ex);
					}
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Customers.GetAllMetaPartnerPhoneDataByCriteria");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets many MetaPartnerPhone data by criteria.</summary>
		///
		/// <param name="phoneNumber">A key for MetaPartnerPhone items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for MetaPartnerPhone items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for MetaPartnerPhone items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetManyMetaPartnerPhoneDataByCriteria(string phoneNumber, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel)
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
				spParameters["PhoneNumber"] = MOD.Data.SearchHelper.ReplaceSpecialSQLSearchChars(phoneNumber);
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
				DataTable dt = dbAdapter.ExecuteProc("spCustomers_GetManyMetaPartnerPhoneDataByCriteria", null, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				totalRecords = MOD.Data.DataHelper.GetInt(spParameters["TotalRecords"], MOD.Data.DefaultValue.Int);
				maximumListSizeExceeded = MOD.Data.DataHelper.GetBool(spParameters["MaximumListSizeExceeded"], MOD.Data.DefaultValue.Bool);
				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					MetaPartnerPhone item = (MetaPartnerPhone) DataTransformAttribute.Transform(row, new MetaPartnerPhone(), false, filterFields);
					item.IsLoaded = true;
					try
					{
						item.PIN = MOD.Data.Encryption.DecryptString(item.PIN);
					}
					catch (System.Exception ex)
					{
						// revert to clear text
						MW.MComm.WalletSolution.Utility.CustomAppException.HandleException(ex);
					}
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Customers.GetManyMetaPartnerPhoneDataByCriteria");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single MetaPartnerPhone by an index.</summary>
		///
		/// <param name="metaPartnerPhoneID">A key for MetaPartnerPhone items to be fetched</param>
		/// <param name="metaPartnerID">A key for MetaPartnerPhone items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MetaPartnerPhone GetOneMetaPartnerPhoneByMetaPartnerPhoneIDAndMetaPartnerID(Guid metaPartnerPhoneID, Guid metaPartnerID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel)
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
				MetaPartnerPhone item = new MetaPartnerPhone();
				spParameters["MetaPartnerPhoneID"] = metaPartnerPhoneID;
				spParameters["MetaPartnerID"] = metaPartnerID;
				if(dataOptions != null)
				{
					dataOptions.PopulateNamedObjectCollection( spParameters );
					filterFields = dataOptions.FilterFields;
				}
				DataTable dt = dbAdapter.ExecuteProc("spCustomers_GetOneMetaPartnerPhoneByMetaPartnerPhoneIDAndMetaPartnerID", null, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				item = null;
				// get output item
				foreach(DataRow row in dt.Rows)
				{
					// get item
					item = (MetaPartnerPhone) DataTransformAttribute.Transform(row, new MetaPartnerPhone(), false, filterFields);
					item.IsLoaded = true;
					try
					{
						item.PIN = MOD.Data.Encryption.DecryptString(item.PIN);
					}
					catch (System.Exception ex)
					{
						// revert to clear text and handle exception
						MW.MComm.WalletSolution.Utility.CustomAppException.HandleException(ex);
					}
					break;
				}
				return item;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Customers.GetOneMetaPartnerPhoneByMetaPartnerPhoneIDAndMetaPartnerID");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single MetaPartnerPhone by an index.</summary>
		///
		/// <param name="phoneNumber">A key for MetaPartnerPhone items to be fetched</param>
		/// <param name="pIN">A key for MetaPartnerPhone items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MetaPartnerPhone GetOneMetaPartnerPhoneByPhoneNumberAndPIN(string phoneNumber, string pIN, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel)
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
				MetaPartnerPhone item = new MetaPartnerPhone();
				spParameters["PhoneNumber"] = phoneNumber;
				spParameters["PIN"] = pIN;
				if(dataOptions != null)
				{
					dataOptions.PopulateNamedObjectCollection( spParameters );
					filterFields = dataOptions.FilterFields;
				}
				DataTable dt = dbAdapter.ExecuteProc("spCustomers_GetOneMetaPartnerPhoneByPhoneNumberAndPIN", null, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				item = null;
				// get output item
				foreach(DataRow row in dt.Rows)
				{
					// get item
					item = (MetaPartnerPhone) DataTransformAttribute.Transform(row, new MetaPartnerPhone(), false, filterFields);
					item.IsLoaded = true;
					try
					{
						item.PIN = MOD.Data.Encryption.DecryptString(item.PIN);
					}
					catch (System.Exception ex)
					{
						// revert to clear text and handle exception
						MW.MComm.WalletSolution.Utility.CustomAppException.HandleException(ex);
					}
					break;
				}
				return item;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Customers.GetOneMetaPartnerPhoneByPhoneNumberAndPIN");
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
			MetaPartnerPhone metaPartnerPhoneInstance = obj as MetaPartnerPhone;
			if (metaPartnerPhoneInstance == null)
				return false;
			else
				return (_metaPartnerPhoneID == metaPartnerPhoneInstance.MetaPartnerPhoneID);
		}
		/// <summary>
		///	Returns unique identifying integer		 
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return (_metaPartnerPhoneID.ToString()).GetHashCode();
		}
		#endregion Methods
	}
}