

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
using DAL = MW.MComm.Ganadero.DAL;
using Utility = MW.MComm.Ganadero.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace MW.MComm.Ganadero.DAL.Users
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to hold and manage information for UserRoleActivity instances.</summary>
	///
	/// File History:
	/// <created>10/20/2006 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[Serializable()]
	public partial class UserRoleActivity : Utility.BaseDataAccessObject
	{

		#region Constants
		#endregion Constants

		#region Fields

		// for UserRoleCode property
		protected int _userRoleCode = MOD.Data.DefaultValue.Int;

		// for ActivityCode property
		protected int _activityCode = MOD.Data.DefaultValue.Int;

		// for AccessModeCode property
		protected int _accessModeCode = MOD.Data.DefaultValue.Int;

		// for PrimaryName property
		protected string _primaryName = MOD.Data.DefaultValue.String;

		// for PrimaryIndex property
		protected string _primaryIndex = MOD.Data.DefaultValue.String;

		// for PrimarySortColumn property
		protected string _primarySortColumn = MOD.Data.DefaultValue.String;

		// for UserRoleName read only property
		[DataTransform]
		protected string _userRoleName = MOD.Data.DefaultValue.String;

		// for ActivityName read only property
		[DataTransform]
		protected string _activityName = MOD.Data.DefaultValue.String;

		// for AccessModeName read only property
		[DataTransform]
		protected string _accessModeName = MOD.Data.DefaultValue.String;

		// for AccessMode property
		protected DAL.Users.AccessMode _accessMode = null;

		// for Activity property
		protected DAL.Users.Activity _activity = null;

		// for UserRole property
		protected DAL.Users.UserRole _userRole = null;

		#endregion Fields

		#region Properties

		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the UserRoleCode.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Int)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual int UserRoleCode
		{
			get
			{
				return _userRoleCode;
			}
			set
			{
				if (_userRoleCode != value)
				{
					_userRoleCode = value;
					_isDirty = true;
				}
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the ActivityCode.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Int)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual int ActivityCode
		{
			get
			{
				return _activityCode;
			}
			set
			{
				if (_activityCode != value)
				{
					_activityCode = value;
					_isDirty = true;
				}
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the AccessModeCode.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Int)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual int AccessModeCode
		{
			get
			{
				return _accessModeCode;
			}
			set
			{
				if (_accessModeCode != value)
				{
					_accessModeCode = value;
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
				return (MOD.Data.DataHelper.GetString(UserRoleCode,"") + ", " + MOD.Data.DataHelper.GetString(ActivityCode,"") + ", " + MOD.Data.DataHelper.GetString(AccessModeCode,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					UserRoleCode = MOD.Data.DataHelper.GetInt(keyValues[0], MOD.Data.DefaultValue.Int);
				}
				if (keyValues.Length > 1)
				{
					ActivityCode = MOD.Data.DataHelper.GetInt(keyValues[1], MOD.Data.DefaultValue.Int);
				}
				if (keyValues.Length > 2)
				{
					AccessModeCode = MOD.Data.DataHelper.GetInt(keyValues[2], MOD.Data.DefaultValue.Int);
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
					return UserRoleName;
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
				return (MOD.Data.DataHelper.GetString(UserRoleCode,"") + ", " + MOD.Data.DataHelper.GetString(ActivityCode,"") + ", " + MOD.Data.DataHelper.GetString(AccessModeCode,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					UserRoleCode = MOD.Data.DataHelper.GetInt(keyValues[0], MOD.Data.DefaultValue.Int);
				}
				if (keyValues.Length > 1)
				{
					ActivityCode = MOD.Data.DataHelper.GetInt(keyValues[1], MOD.Data.DefaultValue.Int);
				}
				if (keyValues.Length > 2)
				{
					AccessModeCode = MOD.Data.DataHelper.GetInt(keyValues[2], MOD.Data.DefaultValue.Int);
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
					return "UserRoleName";
				}
			}
			set
			{
				_primarySortColumn = value;
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This read only property gets the UserRoleName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		public virtual string UserRoleName
		{
			get
			{
				return _userRoleName;
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This read only property gets the ActivityName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		public virtual string ActivityName
		{
			get
			{
				return _activityName;
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This read only property gets the AccessModeName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		public virtual string AccessModeName
		{
			get
			{
				return _accessModeName;
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of AccessMode.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual DAL.Users.AccessMode AccessMode
		{
			get
			{
				return _accessMode;
			}
			set
			{
				_accessMode = value;
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of Activity.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual DAL.Users.Activity Activity
		{
			get
			{
				return _activity;
			}
			set
			{
				_activity = value;
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of UserRole.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual DAL.Users.UserRole UserRole
		{
			get
			{
				return _userRole;
			}
			set
			{
				_userRole = value;
			}
		}

		#endregion Properties

		#region Constructors

		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public UserRoleActivity()
		{
			//
			// constructor logic
			//
		}

		// ------------------------------------------------------------------------------
		/// <summary>This method creates an instance with the primary key values.</summary>
		// ------------------------------------------------------------------------------
		public UserRoleActivity(string keyValues, bool isPrimaryKeyValues)
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
		/// <summary>This method inserts UserRoleActivity data.</summary>
		///
		/// <param name="item">The UserRoleActivity to be added.</param>
		/// <param name="performCascadeOperation">Peform the changes to the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneUserRoleActivity(UserRoleActivity item, bool performCascadeOperation, MOD.Data.DatabaseOptions dbOptions, int debugLevel)
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
				AddOneUserRoleActivity(item, performCascadeOperation, dbAdapter);

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
				throw Utility.CustomAppException.WrapException(ex, "DAL.Users.AddOneUserRoleActivity");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method inserts UserRoleActivity data.</summary>
		///
		/// <param name="item">The UserRoleActivity to be added.</param>
		/// <param name="performCascadeOperation">Peform the changes to the child entities of the item, if any exist</param>
		/// <param name="dbAdapter">Database adapter for transaction</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneUserRoleActivity(UserRoleActivity item, bool performCascadeOperation, MOD.Data.SqlProcAdapter dbAdapter)
		{
			try
			{
				// perform main method tasks
				MOD.Data.NamedObjectCollection spParameters = new MOD.Data.NamedObjectCollection();
				dbAdapter.ExecuteProcNQ("spUsers_AddOneUserRoleActivity", item, spParameters);

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
				throw Utility.CustomAppException.WrapException(ex, "DAL.Users.AddOneUserRoleActivity");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method deletes all UserRoleActivity data by a key.</summary>
		///
		/// <param name="performCascadeOperation">Peform the deletes of the child entities of the item, if any exist</param>
		/// <param name="accessModeCode">A key for UserRoleActivity items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllUserRoleActivityDataByAccessModeCode(int accessModeCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel)
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
				DeleteAllUserRoleActivityDataByAccessModeCode(accessModeCode, dbAdapter);

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
				throw Utility.CustomAppException.WrapException(ex, "DAL.Users.DeleteAllUserRoleActivityDataByAccessModeCode");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method deletes all UserRoleActivity data by a key.</summary>
		///
		/// <param name="performCascadeOperation">Peform the deletes of the child entities of the item, if any exist</param>
		/// <param name="accessModeCode">A key for UserRoleActivity items to be deleted</param>
		/// <param name="dbAdapter">Database adapter for transaction</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllUserRoleActivityDataByAccessModeCode(int accessModeCode, MOD.Data.SqlProcAdapter dbAdapter)
		{
			try
			{
				// perform main method tasks
				MOD.Data.NamedObjectCollection spParameters = new MOD.Data.NamedObjectCollection();
				spParameters["AccessModeCode"] = accessModeCode;
				dbAdapter.ExecuteProcNQ("spUsers_DeleteAllUserRoleActivityDataByAccessModeCode", null, spParameters);

				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Users.DeleteAllUserRoleActivityDataByAccessModeCode");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method deletes all UserRoleActivity data by a key.</summary>
		///
		/// <param name="performCascadeOperation">Peform the deletes of the child entities of the item, if any exist</param>
		/// <param name="activityCode">A key for UserRoleActivity items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllUserRoleActivityDataByActivityCode(int activityCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel)
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
				DeleteAllUserRoleActivityDataByActivityCode(activityCode, dbAdapter);

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
				throw Utility.CustomAppException.WrapException(ex, "DAL.Users.DeleteAllUserRoleActivityDataByActivityCode");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method deletes all UserRoleActivity data by a key.</summary>
		///
		/// <param name="performCascadeOperation">Peform the deletes of the child entities of the item, if any exist</param>
		/// <param name="activityCode">A key for UserRoleActivity items to be deleted</param>
		/// <param name="dbAdapter">Database adapter for transaction</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllUserRoleActivityDataByActivityCode(int activityCode, MOD.Data.SqlProcAdapter dbAdapter)
		{
			try
			{
				// perform main method tasks
				MOD.Data.NamedObjectCollection spParameters = new MOD.Data.NamedObjectCollection();
				spParameters["ActivityCode"] = activityCode;
				dbAdapter.ExecuteProcNQ("spUsers_DeleteAllUserRoleActivityDataByActivityCode", null, spParameters);

				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Users.DeleteAllUserRoleActivityDataByActivityCode");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method deletes all UserRoleActivity data by a key.</summary>
		///
		/// <param name="performCascadeOperation">Peform the deletes of the child entities of the item, if any exist</param>
		/// <param name="userRoleCode">A key for UserRoleActivity items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllUserRoleActivityDataByUserRoleCode(int userRoleCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel)
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
				DeleteAllUserRoleActivityDataByUserRoleCode(userRoleCode, dbAdapter);

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
				throw Utility.CustomAppException.WrapException(ex, "DAL.Users.DeleteAllUserRoleActivityDataByUserRoleCode");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method deletes all UserRoleActivity data by a key.</summary>
		///
		/// <param name="performCascadeOperation">Peform the deletes of the child entities of the item, if any exist</param>
		/// <param name="userRoleCode">A key for UserRoleActivity items to be deleted</param>
		/// <param name="dbAdapter">Database adapter for transaction</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllUserRoleActivityDataByUserRoleCode(int userRoleCode, MOD.Data.SqlProcAdapter dbAdapter)
		{
			try
			{
				// perform main method tasks
				MOD.Data.NamedObjectCollection spParameters = new MOD.Data.NamedObjectCollection();
				spParameters["UserRoleCode"] = userRoleCode;
				dbAdapter.ExecuteProcNQ("spUsers_DeleteAllUserRoleActivityDataByUserRoleCode", null, spParameters);

				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Users.DeleteAllUserRoleActivityDataByUserRoleCode");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method deletes UserRoleActivity data.</summary>
		///
		/// <param name="item">The UserRoleActivity to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the changes to the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneUserRoleActivity(UserRoleActivity item, bool performCascadeOperation, MOD.Data.DatabaseOptions dbOptions, int debugLevel)
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
				DeleteOneUserRoleActivity(item, performCascadeOperation, dbAdapter);

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
				throw Utility.CustomAppException.WrapException(ex, "DAL.Users.DeleteOneUserRoleActivity");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method deletes UserRoleActivity data.</summary>
		///
		/// <param name="item">The UserRoleActivity to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the changes to the child entities of the item, if any exist</param>
		/// <param name="dbAdapter">Database adapter for transaction</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneUserRoleActivity(UserRoleActivity item, bool performCascadeOperation, MOD.Data.SqlProcAdapter dbAdapter)
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
				dbAdapter.ExecuteProcNQ("spUsers_DeleteOneUserRoleActivity", item, spParameters);

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
				throw Utility.CustomAppException.WrapException(ex, "DAL.Users.DeleteOneUserRoleActivity");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets all UserRoleActivity data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetAllUserRoleActivityData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel)
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

				DataTable dt = dbAdapter.ExecuteProc("spUsers_GetAllUserRoleActivityData", null, spParameters);

				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);

				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					UserRoleActivity item = (UserRoleActivity) DataTransformAttribute.Transform(row, new UserRoleActivity(), false, filterFields);
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Users.GetAllUserRoleActivityData");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets all UserRoleActivity data by a key.</summary>
		///
		/// <param name="accessModeCode">A key for UserRoleActivity items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetAllUserRoleActivityDataByAccessModeCode(int accessModeCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel)
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
				spParameters["AccessModeCode"] = accessModeCode;
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

				DataTable dt = dbAdapter.ExecuteProc("spUsers_GetAllUserRoleActivityDataByAccessModeCode", null, spParameters);

				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);

				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					UserRoleActivity item = (UserRoleActivity) DataTransformAttribute.Transform(row, new UserRoleActivity(), false, filterFields);
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Users.GetAllUserRoleActivityDataByAccessModeCode");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets all UserRoleActivity data by a key.</summary>
		///
		/// <param name="accessModeCode">A key for UserRoleActivity items to be fetched</param>
		/// <param name="dbAdapter">Database adapter for transaction</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetAllUserRoleActivityDataByAccessModeCode(int accessModeCode, MOD.Data.SqlProcAdapter dbAdapter)
		{
			try
			{
				// perform main method tasks
				MOD.Data.NamedObjectCollection spParameters = new MOD.Data.NamedObjectCollection();
				MOD.Data.NamedObjectCollection filterFields = new MOD.Data.NamedObjectCollection();
				MOD.Data.SortableObjectCollection items = new MOD.Data.SortableObjectCollection();
				spParameters["AccessModeCode"] = accessModeCode;
				spParameters["IncludeInactive"] = true;
				spParameters["IncludeDateInactive"] = true;

				DataTable dt = dbAdapter.ExecuteProc("spUsers_GetAllUserRoleActivityDataByAccessModeCode", null, spParameters);

				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);

				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					UserRoleActivity item = (UserRoleActivity) DataTransformAttribute.Transform(row, new UserRoleActivity(), false);
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Users.GetAllUserRoleActivityDataByAccessModeCode");
			}
			finally
			{
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets all UserRoleActivity data by a key.</summary>
		///
		/// <param name="activityCode">A key for UserRoleActivity items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetAllUserRoleActivityDataByActivityCode(int activityCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel)
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
				spParameters["ActivityCode"] = activityCode;
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

				DataTable dt = dbAdapter.ExecuteProc("spUsers_GetAllUserRoleActivityDataByActivityCode", null, spParameters);

				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);

				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					UserRoleActivity item = (UserRoleActivity) DataTransformAttribute.Transform(row, new UserRoleActivity(), false, filterFields);
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Users.GetAllUserRoleActivityDataByActivityCode");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets all UserRoleActivity data by a key.</summary>
		///
		/// <param name="activityCode">A key for UserRoleActivity items to be fetched</param>
		/// <param name="dbAdapter">Database adapter for transaction</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetAllUserRoleActivityDataByActivityCode(int activityCode, MOD.Data.SqlProcAdapter dbAdapter)
		{
			try
			{
				// perform main method tasks
				MOD.Data.NamedObjectCollection spParameters = new MOD.Data.NamedObjectCollection();
				MOD.Data.NamedObjectCollection filterFields = new MOD.Data.NamedObjectCollection();
				MOD.Data.SortableObjectCollection items = new MOD.Data.SortableObjectCollection();
				spParameters["ActivityCode"] = activityCode;
				spParameters["IncludeInactive"] = true;
				spParameters["IncludeDateInactive"] = true;

				DataTable dt = dbAdapter.ExecuteProc("spUsers_GetAllUserRoleActivityDataByActivityCode", null, spParameters);

				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);

				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					UserRoleActivity item = (UserRoleActivity) DataTransformAttribute.Transform(row, new UserRoleActivity(), false);
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Users.GetAllUserRoleActivityDataByActivityCode");
			}
			finally
			{
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets all UserRoleActivity data by a key.</summary>
		///
		/// <param name="userRoleCode">A key for UserRoleActivity items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetAllUserRoleActivityDataByUserRoleCode(int userRoleCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel)
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
				spParameters["UserRoleCode"] = userRoleCode;
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

				DataTable dt = dbAdapter.ExecuteProc("spUsers_GetAllUserRoleActivityDataByUserRoleCode", null, spParameters);

				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);

				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					UserRoleActivity item = (UserRoleActivity) DataTransformAttribute.Transform(row, new UserRoleActivity(), false, filterFields);
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Users.GetAllUserRoleActivityDataByUserRoleCode");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets all UserRoleActivity data by a key.</summary>
		///
		/// <param name="userRoleCode">A key for UserRoleActivity items to be fetched</param>
		/// <param name="dbAdapter">Database adapter for transaction</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetAllUserRoleActivityDataByUserRoleCode(int userRoleCode, MOD.Data.SqlProcAdapter dbAdapter)
		{
			try
			{
				// perform main method tasks
				MOD.Data.NamedObjectCollection spParameters = new MOD.Data.NamedObjectCollection();
				MOD.Data.NamedObjectCollection filterFields = new MOD.Data.NamedObjectCollection();
				MOD.Data.SortableObjectCollection items = new MOD.Data.SortableObjectCollection();
				spParameters["UserRoleCode"] = userRoleCode;
				spParameters["IncludeInactive"] = true;
				spParameters["IncludeDateInactive"] = true;

				DataTable dt = dbAdapter.ExecuteProc("spUsers_GetAllUserRoleActivityDataByUserRoleCode", null, spParameters);

				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);

				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					UserRoleActivity item = (UserRoleActivity) DataTransformAttribute.Transform(row, new UserRoleActivity(), false);
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Users.GetAllUserRoleActivityDataByUserRoleCode");
			}
			finally
			{
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets a single UserRoleActivity by an index.</summary>
		///
		/// <param name="userRoleCode">A key for UserRoleActivity items to be fetched</param>
		/// <param name="activityCode">A key for UserRoleActivity items to be fetched</param>
		/// <param name="accessModeCode">A key for UserRoleActivity items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static UserRoleActivity GetOneUserRoleActivity(int userRoleCode, int activityCode, int accessModeCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel)
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
				UserRoleActivity item = new UserRoleActivity();
				spParameters["UserRoleCode"] = userRoleCode;
				spParameters["ActivityCode"] = activityCode;
				spParameters["AccessModeCode"] = accessModeCode;
				if(dataOptions != null)
				{
					dataOptions.PopulateNamedObjectCollection( spParameters );
					filterFields = dataOptions.FilterFields;
				}

				DataTable dt = dbAdapter.ExecuteProc("spUsers_GetOneUserRoleActivity", null, spParameters);

				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);

				item = null;

				// get output item
				foreach(DataRow row in dt.Rows)
				{
					// get item
					item = (UserRoleActivity) DataTransformAttribute.Transform(row, new UserRoleActivity(), false, filterFields);
					break;
				}

				return item;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Users.GetOneUserRoleActivity");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method updates UserRoleActivity data.</summary>
		///
		/// <param name="item">The UserRoleActivity to be updated.</param>
		/// <param name="performCascadeOperation">Peform the changes to the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneUserRoleActivity(UserRoleActivity item, bool performCascadeOperation, MOD.Data.DatabaseOptions dbOptions, int debugLevel)
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
				UpdateOneUserRoleActivity(item, performCascadeOperation, dbAdapter);

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
				throw Utility.CustomAppException.WrapException(ex, "DAL.Users.UpdateOneUserRoleActivity");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method updates UserRoleActivity data.</summary>
		///
		/// <param name="item">The UserRoleActivity to be updated.</param>
		/// <param name="performCascadeOperation">Peform the changes to the child entities of the item, if any exist</param>
		/// <param name="dbAdapter">Database adapter for transaction</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneUserRoleActivity(UserRoleActivity item, bool performCascadeOperation, MOD.Data.SqlProcAdapter dbAdapter)
		{
			try
			{
				// perform main method tasks
				MOD.Data.NamedObjectCollection spParameters = new MOD.Data.NamedObjectCollection();
				dbAdapter.ExecuteProcNQ("spUsers_UpdateOneUserRoleActivity", item, spParameters);

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
				throw Utility.CustomAppException.WrapException(ex, "DAL.Users.UpdateOneUserRoleActivity");
			}
		}


		/// <summary>
		///			 
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			UserRoleActivity userRoleActivityInstance = obj as UserRoleActivity;

			if (userRoleActivityInstance == null)
				return false;
			else
				return (_userRoleCode == userRoleActivityInstance.UserRoleCode && 
					_activityCode == userRoleActivityInstance.ActivityCode && 
					_accessModeCode == userRoleActivityInstance.AccessModeCode);
		}


		/// <summary>
		///	Returns unique identifying integer		 
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return (_userRoleCode.ToString() + _activityCode.ToString() + _accessModeCode.ToString()).GetHashCode();
		}
		#endregion Methods
	}
}