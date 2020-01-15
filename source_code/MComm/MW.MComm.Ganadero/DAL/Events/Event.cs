

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

namespace MW.MComm.Ganadero.DAL.Events
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to hold and manage information for Event instances.</summary>
	///
	/// File History:
	/// <created>10/20/2006 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[Serializable()]
	public partial class Event : Utility.BaseDataAccessObject
	{

		#region Constants
		#endregion Constants

		#region Fields

		// for EventCode property
		protected int _eventCode = MOD.Data.DefaultValue.Int;

		// for EventName property
		protected string _eventName = MOD.Data.DefaultValue.String;

		// for EventTypeCode property
		protected int _eventTypeCode = MOD.Data.DefaultValue.Int;

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

		// for EventTypeName read only property
		[DataTransform]
		protected string _eventTypeName = MOD.Data.DefaultValue.String;

		// for EventType property
		protected DAL.Events.EventType _eventType = null;

		#endregion Fields

		#region Properties

		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the EventCode.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Int)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual int EventCode
		{
			get
			{
				return _eventCode;
			}
			set
			{
				if (_eventCode != value)
				{
					_eventCode = value;
					_isDirty = true;
				}
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the EventName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual string EventName
		{
			get
			{
				return _eventName;
			}
			set
			{
				if ((_eventName != null && !_eventName.Equals(value)) || _eventName != value)
				{
					_eventName = value;
					_isDirty = true;
				}
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the EventTypeCode.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Int)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual int EventTypeCode
		{
			get
			{
				return _eventTypeCode;
			}
			set
			{
				if (_eventTypeCode != value)
				{
					_eventTypeCode = value;
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
				return (MOD.Data.DataHelper.GetString(EventCode,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					EventCode = MOD.Data.DataHelper.GetInt(keyValues[0], MOD.Data.DefaultValue.Int);
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
					return EventName;
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
				return (MOD.Data.DataHelper.GetString(EventCode,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					EventCode = MOD.Data.DataHelper.GetInt(keyValues[0], MOD.Data.DefaultValue.Int);
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
					return "EventName";
				}
			}
			set
			{
				_primarySortColumn = value;
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This read only property gets the EventTypeName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		public virtual string EventTypeName
		{
			get
			{
				return _eventTypeName;
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of EventType.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual DAL.Events.EventType EventType
		{
			get
			{
				return _eventType;
			}
			set
			{
				_eventType = value;
			}
		}

		#endregion Properties

		#region Constructors

		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public Event()
		{
			//
			// constructor logic
			//
		}

		// ------------------------------------------------------------------------------
		/// <summary>This method creates an instance with the primary key values.</summary>
		// ------------------------------------------------------------------------------
		public Event(string keyValues, bool isPrimaryKeyValues)
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
		/// <summary>This method inserts Event data.</summary>
		///
		/// <param name="item">The Event to be added.</param>
		/// <param name="performCascadeOperation">Peform the changes to the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneEvent(Event item, bool performCascadeOperation, MOD.Data.DatabaseOptions dbOptions, int debugLevel)
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
				AddOneEvent(item, performCascadeOperation, dbAdapter);

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
				throw Utility.CustomAppException.WrapException(ex, "DAL.Events.AddOneEvent");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method inserts Event data.</summary>
		///
		/// <param name="item">The Event to be added.</param>
		/// <param name="performCascadeOperation">Peform the changes to the child entities of the item, if any exist</param>
		/// <param name="dbAdapter">Database adapter for transaction</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneEvent(Event item, bool performCascadeOperation, MOD.Data.SqlProcAdapter dbAdapter)
		{
			try
			{
				// perform main method tasks
				MOD.Data.NamedObjectCollection spParameters = new MOD.Data.NamedObjectCollection();
				dbAdapter.ExecuteProcNQ("spEvents_AddOneEvent", item, spParameters);

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
				throw Utility.CustomAppException.WrapException(ex, "DAL.Events.AddOneEvent");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method deletes all Event data by a key.</summary>
		///
		/// <param name="performCascadeOperation">Peform the deletes of the child entities of the item, if any exist</param>
		/// <param name="eventTypeCode">A key for Event items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllEventDataByEventTypeCode(int eventTypeCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel)
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
				DeleteAllEventDataByEventTypeCode(eventTypeCode, dbAdapter);

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
				throw Utility.CustomAppException.WrapException(ex, "DAL.Events.DeleteAllEventDataByEventTypeCode");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method deletes all Event data by a key.</summary>
		///
		/// <param name="performCascadeOperation">Peform the deletes of the child entities of the item, if any exist</param>
		/// <param name="eventTypeCode">A key for Event items to be deleted</param>
		/// <param name="dbAdapter">Database adapter for transaction</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllEventDataByEventTypeCode(int eventTypeCode, MOD.Data.SqlProcAdapter dbAdapter)
		{
			try
			{
				// perform main method tasks
				MOD.Data.NamedObjectCollection spParameters = new MOD.Data.NamedObjectCollection();
				spParameters["EventTypeCode"] = eventTypeCode;
				dbAdapter.ExecuteProcNQ("spEvents_DeleteAllEventDataByEventTypeCode", null, spParameters);

				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Events.DeleteAllEventDataByEventTypeCode");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method deletes Event data.</summary>
		///
		/// <param name="item">The Event to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the changes to the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneEvent(Event item, bool performCascadeOperation, MOD.Data.DatabaseOptions dbOptions, int debugLevel)
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
				DeleteOneEvent(item, performCascadeOperation, dbAdapter);

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
				throw Utility.CustomAppException.WrapException(ex, "DAL.Events.DeleteOneEvent");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method deletes Event data.</summary>
		///
		/// <param name="item">The Event to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the changes to the child entities of the item, if any exist</param>
		/// <param name="dbAdapter">Database adapter for transaction</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneEvent(Event item, bool performCascadeOperation, MOD.Data.SqlProcAdapter dbAdapter)
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
				dbAdapter.ExecuteProcNQ("spEvents_DeleteOneEvent", item, spParameters);

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
				throw Utility.CustomAppException.WrapException(ex, "DAL.Events.DeleteOneEvent");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets all Event data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetAllEventData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel)
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

				DataTable dt = dbAdapter.ExecuteProc("spEvents_GetAllEventData", null, spParameters);

				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);

				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					Event item = (Event) DataTransformAttribute.Transform(row, new Event(), false, filterFields);
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Events.GetAllEventData");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets all Event data by criteria.</summary>
		///
		/// <param name="eventName">A key for Event items to be fetched</param>
		/// <param name="eventTypeCode">A key for Event items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Event items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Event items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetAllEventDataByCriteria(string eventName, int? eventTypeCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel)
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
				spParameters["EventName"] = MOD.Data.SearchHelper.ReplaceSpecialSQLSearchChars(eventName);
				spParameters["EventTypeCode"] = eventTypeCode;
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

				DataTable dt = dbAdapter.ExecuteProc("spEvents_GetAllEventDataByCriteria", null, spParameters);

				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);

				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					Event item = (Event) DataTransformAttribute.Transform(row, new Event(), false, filterFields);
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Events.GetAllEventDataByCriteria");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets all Event data by a key.</summary>
		///
		/// <param name="eventTypeCode">A key for Event items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetAllEventDataByEventTypeCode(int eventTypeCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel)
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
				spParameters["EventTypeCode"] = eventTypeCode;
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

				DataTable dt = dbAdapter.ExecuteProc("spEvents_GetAllEventDataByEventTypeCode", null, spParameters);

				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);

				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					Event item = (Event) DataTransformAttribute.Transform(row, new Event(), false, filterFields);
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Events.GetAllEventDataByEventTypeCode");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets all Event data by a key.</summary>
		///
		/// <param name="eventTypeCode">A key for Event items to be fetched</param>
		/// <param name="dbAdapter">Database adapter for transaction</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetAllEventDataByEventTypeCode(int eventTypeCode, MOD.Data.SqlProcAdapter dbAdapter)
		{
			try
			{
				// perform main method tasks
				MOD.Data.NamedObjectCollection spParameters = new MOD.Data.NamedObjectCollection();
				MOD.Data.NamedObjectCollection filterFields = new MOD.Data.NamedObjectCollection();
				MOD.Data.SortableObjectCollection items = new MOD.Data.SortableObjectCollection();
				spParameters["EventTypeCode"] = eventTypeCode;
				spParameters["IncludeInactive"] = true;
				spParameters["IncludeDateInactive"] = true;

				DataTable dt = dbAdapter.ExecuteProc("spEvents_GetAllEventDataByEventTypeCode", null, spParameters);

				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);

				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					Event item = (Event) DataTransformAttribute.Transform(row, new Event(), false);
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Events.GetAllEventDataByEventTypeCode");
			}
			finally
			{
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets many Event data by criteria.</summary>
		///
		/// <param name="eventName">A key for Event items to be fetched</param>
		/// <param name="eventTypeCode">A key for Event items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for Event items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Event items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetManyEventDataByCriteria(string eventName, int? eventTypeCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel)
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
				spParameters["EventName"] = MOD.Data.SearchHelper.ReplaceSpecialSQLSearchChars(eventName);
				spParameters["EventTypeCode"] = eventTypeCode;
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

				DataTable dt = dbAdapter.ExecuteProc("spEvents_GetManyEventDataByCriteria", null, spParameters);

				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				totalRecords = MOD.Data.DataHelper.GetInt(spParameters["TotalRecords"], MOD.Data.DefaultValue.Int);
				maximumListSizeExceeded = MOD.Data.DataHelper.GetBool(spParameters["MaximumListSizeExceeded"], MOD.Data.DefaultValue.Bool);

				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					Event item = (Event) DataTransformAttribute.Transform(row, new Event(), false, filterFields);
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Events.GetManyEventDataByCriteria");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets a single Event by an index.</summary>
		///
		/// <param name="eventCode">A key for Event items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static Event GetOneEvent(int eventCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel)
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
				Event item = new Event();
				spParameters["EventCode"] = eventCode;
				if(dataOptions != null)
				{
					dataOptions.PopulateNamedObjectCollection( spParameters );
					filterFields = dataOptions.FilterFields;
				}

				DataTable dt = dbAdapter.ExecuteProc("spEvents_GetOneEvent", null, spParameters);

				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);

				item = null;

				// get output item
				foreach(DataRow row in dt.Rows)
				{
					// get item
					item = (Event) DataTransformAttribute.Transform(row, new Event(), false, filterFields);
					break;
				}

				return item;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Events.GetOneEvent");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method updates Event data.</summary>
		///
		/// <param name="item">The Event to be updated.</param>
		/// <param name="performCascadeOperation">Peform the changes to the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneEvent(Event item, bool performCascadeOperation, MOD.Data.DatabaseOptions dbOptions, int debugLevel)
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
				UpdateOneEvent(item, performCascadeOperation, dbAdapter);

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
				throw Utility.CustomAppException.WrapException(ex, "DAL.Events.UpdateOneEvent");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method updates Event data.</summary>
		///
		/// <param name="item">The Event to be updated.</param>
		/// <param name="performCascadeOperation">Peform the changes to the child entities of the item, if any exist</param>
		/// <param name="dbAdapter">Database adapter for transaction</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneEvent(Event item, bool performCascadeOperation, MOD.Data.SqlProcAdapter dbAdapter)
		{
			try
			{
				// perform main method tasks
				MOD.Data.NamedObjectCollection spParameters = new MOD.Data.NamedObjectCollection();
				dbAdapter.ExecuteProcNQ("spEvents_UpdateOneEvent", item, spParameters);

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
				throw Utility.CustomAppException.WrapException(ex, "DAL.Events.UpdateOneEvent");
			}
		}


		/// <summary>
		///			 
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			Event eventInstance = obj as Event;

			if (eventInstance == null)
				return false;
			else
				return (_eventCode == eventInstance.EventCode);
		}


		/// <summary>
		///	Returns unique identifying integer		 
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return (_eventCode.ToString()).GetHashCode();
		}
		#endregion Methods
	}
}