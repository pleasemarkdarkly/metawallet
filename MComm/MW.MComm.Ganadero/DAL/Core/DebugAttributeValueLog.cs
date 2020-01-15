

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

namespace MW.MComm.Ganadero.DAL.Core
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to hold and manage information for DebugAttributeValueLog instances.</summary>
	///
	/// File History:
	/// <created>10/20/2006 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[Serializable()]
	public partial class DebugAttributeValueLog : Utility.BaseDataAccessObject
	{

		#region Constants
		#endregion Constants

		#region Fields

		// for DebugAttributeValueLogID property
		protected Guid _debugAttributeValueLogID = MOD.Data.DefaultValue.Guid;

		// for DebugLogID property
		protected Guid _debugLogID = MOD.Data.DefaultValue.Guid;

		// for BaseAttributeID property
		protected Guid _baseAttributeID = MOD.Data.DefaultValue.Guid;

		// for AttributeValue property
		protected string _attributeValue = MOD.Data.DefaultValue.String;

		// for PrimaryName property
		protected string _primaryName = MOD.Data.DefaultValue.String;

		// for PrimaryIndex property
		protected string _primaryIndex = MOD.Data.DefaultValue.String;

		// for PrimarySortColumn property
		protected string _primarySortColumn = MOD.Data.DefaultValue.String;

		// for EventName read only property
		[DataTransform]
		protected string _eventName = null;

		// for ErrorNumber read only property
		[DataTransform]
		protected int? _errorNumber = null;

		// for DebugAttribute property
		protected DAL.Core.DebugAttribute _debugAttribute = null;

		// for DebugLog property
		protected DAL.Core.DebugLog _debugLog = null;

		#endregion Fields

		#region Properties

		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the DebugAttributeValueLogID.</summary>
		// ------------------------------------------------------------------------------
		[XmlElementAttribute()]
		[DataTransform]
		public virtual Guid DebugAttributeValueLogID
		{
			get
			{
				return _debugAttributeValueLogID;
			}
			set
			{
				if (_debugAttributeValueLogID != value)
				{
					_debugAttributeValueLogID = value;
					_isDirty = true;
				}
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the DebugLogID.</summary>
		// ------------------------------------------------------------------------------
		[XmlElementAttribute()]
		[DataTransform]
		public virtual Guid DebugLogID
		{
			get
			{
				return _debugLogID;
			}
			set
			{
				if (_debugLogID != value)
				{
					_debugLogID = value;
					_isDirty = true;
				}
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the BaseAttributeID.</summary>
		// ------------------------------------------------------------------------------
		[XmlElementAttribute()]
		[DataTransform]
		public virtual Guid BaseAttributeID
		{
			get
			{
				return _baseAttributeID;
			}
			set
			{
				if (_baseAttributeID != value)
				{
					_baseAttributeID = value;
					_isDirty = true;
				}
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the AttributeValue.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual string AttributeValue
		{
			get
			{
				return _attributeValue;
			}
			set
			{
				if ((_attributeValue != null && !_attributeValue.Equals(value)) || _attributeValue != value)
				{
					_attributeValue = value;
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
				return (MOD.Data.DataHelper.GetString(DebugAttributeValueLogID,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					DebugAttributeValueLogID = MOD.Data.DataHelper.GetGuid(keyValues[0], MOD.Data.DefaultValue.Guid);
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
				return (MOD.Data.DataHelper.GetString(DebugAttributeValueLogID,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					DebugAttributeValueLogID = MOD.Data.DataHelper.GetGuid(keyValues[0], MOD.Data.DefaultValue.Guid);
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
		/// <summary>This read only property gets the EventName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(null)]
		[XmlElementAttribute(IsNullable=true)]
		public virtual string EventName
		{
			get
			{
				return _eventName;
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This read only property gets the ErrorNumber.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(null)]
		[XmlElementAttribute(IsNullable=true)]
		public virtual int? ErrorNumber
		{
			get
			{
				return _errorNumber;
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of DebugAttribute.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual DAL.Core.DebugAttribute DebugAttribute
		{
			get
			{
				return _debugAttribute;
			}
			set
			{
				_debugAttribute = value;
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of DebugLog.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual DAL.Core.DebugLog DebugLog
		{
			get
			{
				return _debugLog;
			}
			set
			{
				_debugLog = value;
			}
		}

		#endregion Properties

		#region Constructors

		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public DebugAttributeValueLog()
		{
			//
			// constructor logic
			//
		}

		// ------------------------------------------------------------------------------
		/// <summary>This method creates an instance with the primary key values.</summary>
		// ------------------------------------------------------------------------------
		public DebugAttributeValueLog(string keyValues, bool isPrimaryKeyValues)
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
		/// <summary>This method gets all DebugAttributeValueLog data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetAllDebugAttributeValueLogData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel)
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

				DataTable dt = dbAdapter.ExecuteProc("spCore_GetAllDebugAttributeValueLogData", null, spParameters);

				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);

				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					DebugAttributeValueLog item = (DebugAttributeValueLog) DataTransformAttribute.Transform(row, new DebugAttributeValueLog(), false, filterFields);
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Core.GetAllDebugAttributeValueLogData");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets all DebugAttributeValueLog data by a key.</summary>
		///
		/// <param name="baseAttributeID">A key for DebugAttributeValueLog items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetAllDebugAttributeValueLogDataByBaseAttributeID(Guid baseAttributeID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel)
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
				spParameters["BaseAttributeID"] = baseAttributeID;
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

				DataTable dt = dbAdapter.ExecuteProc("spCore_GetAllDebugAttributeValueLogDataByBaseAttributeID", null, spParameters);

				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);

				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					DebugAttributeValueLog item = (DebugAttributeValueLog) DataTransformAttribute.Transform(row, new DebugAttributeValueLog(), false, filterFields);
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Core.GetAllDebugAttributeValueLogDataByBaseAttributeID");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets all DebugAttributeValueLog data by a key.</summary>
		///
		/// <param name="baseAttributeID">A key for DebugAttributeValueLog items to be fetched</param>
		/// <param name="dbAdapter">Database adapter for transaction</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetAllDebugAttributeValueLogDataByBaseAttributeID(Guid baseAttributeID, MOD.Data.SqlProcAdapter dbAdapter)
		{
			try
			{
				// perform main method tasks
				MOD.Data.NamedObjectCollection spParameters = new MOD.Data.NamedObjectCollection();
				MOD.Data.NamedObjectCollection filterFields = new MOD.Data.NamedObjectCollection();
				MOD.Data.SortableObjectCollection items = new MOD.Data.SortableObjectCollection();
				spParameters["BaseAttributeID"] = baseAttributeID;
				spParameters["IncludeInactive"] = true;
				spParameters["IncludeDateInactive"] = true;

				DataTable dt = dbAdapter.ExecuteProc("spCore_GetAllDebugAttributeValueLogDataByBaseAttributeID", null, spParameters);

				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);

				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					DebugAttributeValueLog item = (DebugAttributeValueLog) DataTransformAttribute.Transform(row, new DebugAttributeValueLog(), false);
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Core.GetAllDebugAttributeValueLogDataByBaseAttributeID");
			}
			finally
			{
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets all DebugAttributeValueLog data by criteria.</summary>
		///
		/// <param name="attributeValue">A key for DebugAttributeValueLog items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for DebugAttributeValueLog items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for DebugAttributeValueLog items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetAllDebugAttributeValueLogDataByCriteria(string attributeValue, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel)
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
				spParameters["AttributeValue"] = MOD.Data.SearchHelper.ReplaceSpecialSQLSearchChars(attributeValue);
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

				DataTable dt = dbAdapter.ExecuteProc("spCore_GetAllDebugAttributeValueLogDataByCriteria", null, spParameters);

				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);

				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					DebugAttributeValueLog item = (DebugAttributeValueLog) DataTransformAttribute.Transform(row, new DebugAttributeValueLog(), false, filterFields);
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Core.GetAllDebugAttributeValueLogDataByCriteria");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets all DebugAttributeValueLog data by a key.</summary>
		///
		/// <param name="debugLogID">A key for DebugAttributeValueLog items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetAllDebugAttributeValueLogDataByDebugLogID(Guid debugLogID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel)
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
				spParameters["DebugLogID"] = debugLogID;
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

				DataTable dt = dbAdapter.ExecuteProc("spCore_GetAllDebugAttributeValueLogDataByDebugLogID", null, spParameters);

				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);

				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					DebugAttributeValueLog item = (DebugAttributeValueLog) DataTransformAttribute.Transform(row, new DebugAttributeValueLog(), false, filterFields);
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Core.GetAllDebugAttributeValueLogDataByDebugLogID");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets all DebugAttributeValueLog data by a key.</summary>
		///
		/// <param name="debugLogID">A key for DebugAttributeValueLog items to be fetched</param>
		/// <param name="dbAdapter">Database adapter for transaction</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetAllDebugAttributeValueLogDataByDebugLogID(Guid debugLogID, MOD.Data.SqlProcAdapter dbAdapter)
		{
			try
			{
				// perform main method tasks
				MOD.Data.NamedObjectCollection spParameters = new MOD.Data.NamedObjectCollection();
				MOD.Data.NamedObjectCollection filterFields = new MOD.Data.NamedObjectCollection();
				MOD.Data.SortableObjectCollection items = new MOD.Data.SortableObjectCollection();
				spParameters["DebugLogID"] = debugLogID;
				spParameters["IncludeInactive"] = true;
				spParameters["IncludeDateInactive"] = true;

				DataTable dt = dbAdapter.ExecuteProc("spCore_GetAllDebugAttributeValueLogDataByDebugLogID", null, spParameters);

				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);

				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					DebugAttributeValueLog item = (DebugAttributeValueLog) DataTransformAttribute.Transform(row, new DebugAttributeValueLog(), false);
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Core.GetAllDebugAttributeValueLogDataByDebugLogID");
			}
			finally
			{
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets many DebugAttributeValueLog data by criteria.</summary>
		///
		/// <param name="attributeValue">A key for DebugAttributeValueLog items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for DebugAttributeValueLog items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for DebugAttributeValueLog items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.SortableObjectCollection GetManyDebugAttributeValueLogDataByCriteria(string attributeValue, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel)
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
				spParameters["AttributeValue"] = MOD.Data.SearchHelper.ReplaceSpecialSQLSearchChars(attributeValue);
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

				DataTable dt = dbAdapter.ExecuteProc("spCore_GetManyDebugAttributeValueLogDataByCriteria", null, spParameters);

				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				totalRecords = MOD.Data.DataHelper.GetInt(spParameters["TotalRecords"], MOD.Data.DefaultValue.Int);
				maximumListSizeExceeded = MOD.Data.DataHelper.GetBool(spParameters["MaximumListSizeExceeded"], MOD.Data.DefaultValue.Bool);

				// get output collection
				foreach(DataRow row in dt.Rows)
				{
					// get item
					DebugAttributeValueLog item = (DebugAttributeValueLog) DataTransformAttribute.Transform(row, new DebugAttributeValueLog(), false, filterFields);
					items.Add(item);
				}
				return items;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Core.GetManyDebugAttributeValueLogDataByCriteria");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets a single DebugAttributeValueLog by an index.</summary>
		///
		/// <param name="debugAttributeValueLogID">A key for DebugAttributeValueLog items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static DebugAttributeValueLog GetOneDebugAttributeValueLog(Guid debugAttributeValueLogID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel)
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
				DebugAttributeValueLog item = new DebugAttributeValueLog();
				spParameters["DebugAttributeValueLogID"] = debugAttributeValueLogID;
				if(dataOptions != null)
				{
					dataOptions.PopulateNamedObjectCollection( spParameters );
					filterFields = dataOptions.FilterFields;
				}

				DataTable dt = dbAdapter.ExecuteProc("spCore_GetOneDebugAttributeValueLog", null, spParameters);

				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);

				item = null;

				// get output item
				foreach(DataRow row in dt.Rows)
				{
					// get item
					item = (DebugAttributeValueLog) DataTransformAttribute.Transform(row, new DebugAttributeValueLog(), false, filterFields);
					break;
				}

				return item;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Core.GetOneDebugAttributeValueLog");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets a single DebugAttributeValueLog by an index.</summary>
		///
		/// <param name="debugAttributeValueLogID">A key for DebugAttributeValueLog items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static DebugAttributeValueLog GetOneDebugAttributeValueLogByDebugAttributeValueLogID(Guid debugAttributeValueLogID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel)
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
				DebugAttributeValueLog item = new DebugAttributeValueLog();
				spParameters["DebugAttributeValueLogID"] = debugAttributeValueLogID;
				if(dataOptions != null)
				{
					dataOptions.PopulateNamedObjectCollection( spParameters );
					filterFields = dataOptions.FilterFields;
				}

				DataTable dt = dbAdapter.ExecuteProc("spCore_GetOneDebugAttributeValueLogByDebugAttributeValueLogID", null, spParameters);

				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);

				item = null;

				// get output item
				foreach(DataRow row in dt.Rows)
				{
					// get item
					item = (DebugAttributeValueLog) DataTransformAttribute.Transform(row, new DebugAttributeValueLog(), false, filterFields);
					break;
				}

				return item;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Core.GetOneDebugAttributeValueLogByDebugAttributeValueLogID");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method logs DebugAttributeValueLog data.</summary>
		///
		/// <param name="item">The DebugAttributeValueLog to be logged.</param>
		/// <param name="performCascadeOperation">Peform the changes to the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void LogOneDebugAttributeValueLog(DebugAttributeValueLog item, bool performCascadeOperation, MOD.Data.DatabaseOptions dbOptions, int debugLevel)
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
				LogOneDebugAttributeValueLog(item, performCascadeOperation, dbAdapter);

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
				throw Utility.CustomAppException.WrapException(ex, "DAL.Core.LogOneDebugAttributeValueLog");
			}
			finally
			{
				dbManager.ClearAdapter();
				dbAdapter = null;
				dbManager = null;
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method logs DebugAttributeValueLog data.</summary>
		///
		/// <param name="item">The DebugAttributeValueLog to be logged.</param>
		/// <param name="performCascadeOperation">Peform the changes to the child entities of the item, if any exist</param>
		/// <param name="dbAdapter">Database adapter for transaction</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Data.SqlClient.SqlException">Thrown when an error is encountered in SQL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void LogOneDebugAttributeValueLog(DebugAttributeValueLog item, bool performCascadeOperation, MOD.Data.SqlProcAdapter dbAdapter)
		{
			try
			{
				// perform main method tasks
				MOD.Data.NamedObjectCollection spParameters = new MOD.Data.NamedObjectCollection();
				dbAdapter.ExecuteProcNQ("spCore_LogOneDebugAttributeValueLog", item, spParameters);

				// perform sql output error handling and get output parameters
				Globals.CheckThrowSqlError(spParameters);
				item.DebugAttributeValueLogID = MOD.Data.DataHelper.GetGuid(spParameters["DebugAttributeValueLogID"], MOD.Data.DefaultValue.Guid);
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
				throw Utility.CustomAppException.WrapException(ex, "DAL.Core.LogOneDebugAttributeValueLog");
			}
		}


		/// <summary>
		///			 
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			DebugAttributeValueLog debugAttributeValueLogInstance = obj as DebugAttributeValueLog;

			if (debugAttributeValueLogInstance == null)
				return false;
			else
				return (_debugAttributeValueLogID == debugAttributeValueLogInstance.DebugAttributeValueLogID);
		}


		/// <summary>
		///	Returns unique identifying integer		 
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return (_debugAttributeValueLogID.ToString()).GetHashCode();
		}
		#endregion Methods
	}
}