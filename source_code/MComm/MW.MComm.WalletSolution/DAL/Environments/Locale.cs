
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
namespace MW.MComm.WalletSolution.DAL.Environments
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to hold and manage information for Locale instances.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[Serializable()]
	public partial class Locale : Utility.BaseDataAccessObject
	{
		#region Constants
		#endregion Constants
		#region Fields
		// for LocaleCode property
		protected int _localeCode = MOD.Data.DefaultValue.Int;
		// for LocaleName property
		protected string _localeName = MOD.Data.DefaultValue.String;
		// for Description property
		protected string _description = null;
		// for IsActive property
		protected bool _isActive = false;
		// for PrimaryName property
		protected string _primaryName = MOD.Data.DefaultValue.String;
		// for PrimaryIndex property
		protected string _primaryIndex = MOD.Data.DefaultValue.String;
		// for PrimarySortColumn property
		protected string _primarySortColumn = MOD.Data.DefaultValue.String;
		#endregion Fields
		#region Properties
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
		/// <summary>This property gets or sets the LocaleName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual string LocaleName
		{
			get
			{
				return _localeName;
			}
			set
			{
				if ((_localeName != null && !_localeName.Equals(value)) || _localeName != value)
				{
					_localeName = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the Description.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(null)]
		[XmlElementAttribute(IsNullable=true)]
		[DataTransform]
		public virtual string Description
		{
			get
			{
				return _description;
			}
			set
			{
				if ((_description != null && !_description.Equals(value)) || _description != value)
				{
					_description = value;
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
				return (MOD.Data.DataHelper.GetString(LocaleCode,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					LocaleCode = MOD.Data.DataHelper.GetInt(keyValues[0], MOD.Data.DefaultValue.Int);
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
					return LocaleName;
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
				return (MOD.Data.DataHelper.GetString(LocaleCode,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					LocaleCode = MOD.Data.DataHelper.GetInt(keyValues[0], MOD.Data.DefaultValue.Int);
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
					return "LocaleName";
				}
			}
			set
			{
				_primarySortColumn = value;
			}
		}
		#endregion Properties
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public Locale()
		{
			//
			// constructor logic
			//
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method creates an instance with the primary key values.</summary>
		// ------------------------------------------------------------------------------
		public Locale(string keyValues, bool isPrimaryKeyValues)
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
		/// <summary>This method inserts Locale data.</summary>
		///
		/// <param name="item">The Locale to be added.</param>
		/// <param name="performCascadeOperation">Peform the changes to the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneLocale(Locale item, bool performCascadeOperation, MOD.Data.DatabaseOptions dbOptions, int debugLevel)
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
				AddOneLocale(item, performCascadeOperation, dbAdapter);
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
				throw Utility.CustomAppException.WrapException(ex, "DAL.Environments.AddOneLocale");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method inserts Locale data.</summary>
		///
		/// <param name="item">The Locale to be added.</param>
		/// <param name="performCascadeOperation">Peform the changes to the child entities of the item, if any exist</param>
		/// <param name="dbAdapter">Database adapter for transaction</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneLocale(Locale item, bool performCascadeOperation, MOD.Data.SqlProcAdapter dbAdapter)
		{
			try
			{
				// perform main method tasks
				MOD.Data.NamedObjectCollection spParameters = new MOD.Data.NamedObjectCollection();
				dbAdapter.ExecuteProcNQ("spEnvironments_AddOneLocale", item, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				item.Timestamp = ((System.Byte[])(spParameters["Timestamp"]));
				#region Cascade Operations
				if (performCascadeOperation == true)
				{
					// cascade operations
				}
				#endregion Cascade Operations
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Environments.AddOneLocale");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes Locale data.</summary>
		///
		/// <param name="item">The Locale to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the changes to the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneLocale(Locale item, bool performCascadeOperation, MOD.Data.DatabaseOptions dbOptions, int debugLevel)
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
				DeleteOneLocale(item, performCascadeOperation, dbAdapter);
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
				throw Utility.CustomAppException.WrapException(ex, "DAL.Environments.DeleteOneLocale");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes Locale data.</summary>
		///
		/// <param name="item">The Locale to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the changes to the child entities of the item, if any exist</param>
		/// <param name="dbAdapter">Database adapter for transaction</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneLocale(Locale item, bool performCascadeOperation, MOD.Data.SqlProcAdapter dbAdapter)
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
				dbAdapter.ExecuteProcNQ("spEnvironments_DeleteOneLocale", item, spParameters);
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
				throw Utility.CustomAppException.WrapException(ex, "DAL.Environments.DeleteOneLocale");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all Locale data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetAllLocaleData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel)
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
				DataTable dt = dbAdapter.ExecuteProc("spEnvironments_GetAllLocaleData", null, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					Locale item = (Locale) DataTransformAttribute.Transform(row, new Locale(), false, filterFields);
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Environments.GetAllLocaleData");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single Locale by an index.</summary>
		///
		/// <param name="localeCode">A key for Locale items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static Locale GetOneLocale(int localeCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel)
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
				Locale item = new Locale();
				spParameters["LocaleCode"] = localeCode;
				if(dataOptions != null)
				{
					dataOptions.PopulateNamedObjectCollection( spParameters );
					filterFields = dataOptions.FilterFields;
				}
				DataTable dt = dbAdapter.ExecuteProc("spEnvironments_GetOneLocale", null, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				item = null;
				// get output item
				foreach(DataRow row in dt.Rows)
				{
					// get item
					item = (Locale) DataTransformAttribute.Transform(row, new Locale(), false, filterFields);
					break;
				}
				return item;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Environments.GetOneLocale");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates Locale data.</summary>
		///
		/// <param name="item">The Locale to be updated.</param>
		/// <param name="performCascadeOperation">Peform the changes to the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneLocale(Locale item, bool performCascadeOperation, MOD.Data.DatabaseOptions dbOptions, int debugLevel)
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
				UpdateOneLocale(item, performCascadeOperation, dbAdapter);
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
				throw Utility.CustomAppException.WrapException(ex, "DAL.Environments.UpdateOneLocale");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates Locale data.</summary>
		///
		/// <param name="item">The Locale to be updated.</param>
		/// <param name="performCascadeOperation">Peform the changes to the child entities of the item, if any exist</param>
		/// <param name="dbAdapter">Database adapter for transaction</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneLocale(Locale item, bool performCascadeOperation, MOD.Data.SqlProcAdapter dbAdapter)
		{
			try
			{
				// perform main method tasks
				MOD.Data.NamedObjectCollection spParameters = new MOD.Data.NamedObjectCollection();
				dbAdapter.ExecuteProcNQ("spEnvironments_UpdateOneLocale", item, spParameters);
				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				item.Timestamp = ((System.Byte[])(spParameters["Timestamp"]));
				#region Cascade Operations
				if (performCascadeOperation == true)
				{
					// cascade operations
				}
				#endregion Cascade Operations
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Environments.UpdateOneLocale");
			}
		}
		/// <summary>
		///			 
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			Locale localeInstance = obj as Locale;
			if (localeInstance == null)
				return false;
			else
				return (_localeCode == localeInstance.LocaleCode);
		}
		/// <summary>
		///	Returns unique identifying integer		 
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return (_localeCode.ToString()).GetHashCode();
		}
		#endregion Methods
	}
}