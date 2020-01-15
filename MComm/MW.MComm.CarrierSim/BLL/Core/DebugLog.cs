

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
using MW.MComm.CarrierSim.BLL.Config;
using BLL = MW.MComm.CarrierSim.BLL;
using DAL = MW.MComm.CarrierSim.DAL;
using Utility = MW.MComm.CarrierSim.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace MW.MComm.CarrierSim.BLL.Core
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to hold and manage information for DebugLog instances.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[Serializable()]
	[DataTransform(Name = "MW.MComm.CarrierSim.DAL.Core.DebugLog")]
	public partial class DebugLog : PersistedBusinessObject
	{

		#region Constants
		#endregion Constants

		#region Fields

		// for DebugLogID property
		protected Guid _debugLogID = MOD.Data.DefaultValue.Guid;

		// for EventName property
		protected string _eventName = null;

		// for Message property
		protected string _message = null;

		// for ErrorNumber property
		protected int? _errorNumber = null;

		// for EventTypeCode property
		protected int _eventTypeCode = MOD.Data.DefaultValue.Int;

		// for SeverityLevelCode property
		protected int _severityLevelCode = MOD.Data.DefaultValue.Int;

		// for EventTypeName read only property
		[DataTransform]
		protected string _eventTypeName = MOD.Data.DefaultValue.String;

		// for SeverityLevelName read only property
		[DataTransform]
		protected string _severityLevelName = MOD.Data.DefaultValue.String;

		// for DebugAttributeValueLogList property
		protected BLL.SortableList<BLL.Core.DebugAttributeValueLog> _debugAttributeValueLogList = null;

		// for EventType property
		protected BLL.Core.EventType _eventType = null;

		// for SeverityLevel property
		protected BLL.Core.SeverityLevel _severityLevel = null;

		#endregion Fields

		#region Properties

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
		/// <summary>This property gets or sets the EventName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(null)]
		[XmlElementAttribute(IsNullable=true)]
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
		/// <summary>This property gets or sets the Message.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(null)]
		[XmlElementAttribute(IsNullable=true)]
		[DataTransform]
		public virtual string Message
		{
			get
			{
				return _message;
			}
			set
			{
				if ((_message != null && !_message.Equals(value)) || _message != value)
				{
					_message = value;
					_isDirty = true;
				}
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the ErrorNumber.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(null)]
		[XmlElementAttribute(IsNullable=true)]
		[DataTransform]
		public virtual int? ErrorNumber
		{
			get
			{
				return _errorNumber;
			}
			set
			{
				if ((_errorNumber != null && !_errorNumber.Equals(value)) || _errorNumber != value)
				{
					_errorNumber = value;
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
					_eventType = null;

					// reset EventType
					BLL.PersistedBusinessObject vEventType = (BLL.PersistedBusinessObject) EventType;
					vEventType = null;
					_isDirty = true;
				}
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the SeverityLevelCode.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Int)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual int SeverityLevelCode
		{
			get
			{
				return _severityLevelCode;
			}
			set
			{
				if (_severityLevelCode != value)
				{
					_severityLevelCode = value;
					_severityLevel = null;

					// reset SeverityLevel
					BLL.PersistedBusinessObject vSeverityLevel = (BLL.PersistedBusinessObject) SeverityLevel;
					vSeverityLevel = null;
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
				return (MOD.Data.DataHelper.GetString(DebugLogID,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					DebugLogID = MOD.Data.DataHelper.GetGuid(keyValues[0], MOD.Data.DefaultValue.Guid);
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
					return EventTypeName;
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
				return (MOD.Data.DataHelper.GetString(DebugLogID,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					DebugLogID = MOD.Data.DataHelper.GetGuid(keyValues[0], MOD.Data.DefaultValue.Guid);
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
					return "EventTypeName";
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
				return ((_debugAttributeValueLogList != null && _debugAttributeValueLogList.IsDirty) ||

				base.IsCollectionDirty);
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
		/// <summary>This read only property gets the SeverityLevelName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		public virtual string SeverityLevelName
		{
			get
			{
				return _severityLevelName;
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets DebugAttributeValueLog lists.</summary>
		// ------------------------------------------------------------------------------
		[XmlArrayItem(typeof(BLL.Core.DebugAttributeValueLog), ElementName="DebugAttributeValueLog")]
		[DataTransform]
		public virtual BLL.SortableList<BLL.Core.DebugAttributeValueLog> DebugAttributeValueLogList
		{
			get
			{
				if (_debugAttributeValueLogList == null && IsLazyLoadable == true)
				{
					_debugAttributeValueLogList = BLL.Core.DebugAttributeValueLogManager.GetAllDebugAttributeValueLogDataByDebugLogID(DebugLogID);
				}
				else if (_debugAttributeValueLogList == null)
				{
					_debugAttributeValueLogList = new BLL.SortableList<BLL.Core.DebugAttributeValueLog>();
				}

				return _debugAttributeValueLogList;
			}
			set
			{
				if (value == null)
				{
					_debugAttributeValueLogList = value;
				}
				else if ((_debugAttributeValueLogList == null && value != null) ||
					  !_debugAttributeValueLogList.Equals(value))
				{
					_debugAttributeValueLogList = value;
					_isDirty = true;
				}
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of EventType.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Core.EventType EventType
		{
			get
			{
				if (_eventType == null  && IsLazyLoadable == true)
				{
					_eventType = BLL.Core.EventTypeManager.GetOneEventType((int)EventTypeCode);

					// refresh derived properties
					if (_eventType != null)
					{
						_eventTypeName = _eventType.EventTypeName;
					}
					else
					{
						_eventTypeName = MOD.Data.DefaultValue.String;
					}
				}

				return _eventType;
			}
			set
			{
				if (_eventType != value)
				{
					_eventType = value;
					_isDirty = true;

					// refresh derived properties
					if (_eventType != null)
					{
						_eventTypeName = _eventType.EventTypeName;
					}
					else
					{
						_eventTypeName = MOD.Data.DefaultValue.String;
					}
				}
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of SeverityLevel.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Core.SeverityLevel SeverityLevel
		{
			get
			{
				if (_severityLevel == null  && IsLazyLoadable == true)
				{
					_severityLevel = BLL.Core.SeverityLevelManager.GetOneSeverityLevel((int)SeverityLevelCode);

					// refresh derived properties
					if (_severityLevel != null)
					{
						_severityLevelName = _severityLevel.SeverityLevelName;
					}
					else
					{
						_severityLevelName = MOD.Data.DefaultValue.String;
					}
				}

				return _severityLevel;
			}
			set
			{
				if (_severityLevel != value)
				{
					_severityLevel = value;
					_isDirty = true;

					// refresh derived properties
					if (_severityLevel != null)
					{
						_severityLevelName = _severityLevel.SeverityLevelName;
					}
					else
					{
						_severityLevelName = MOD.Data.DefaultValue.String;
					}
				}
			}
		}

		#endregion Properties

		#region Constructors

		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public DebugLog()
		{
			//
			// constructor logic
			//
		}

		// ------------------------------------------------------------------------------
		/// <summary>This method creates an instance with the primary key values.</summary>
		// ------------------------------------------------------------------------------
		public DebugLog(string keyValues, bool isPrimaryKeyValues)
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
		/// <summary>This constructor initializes the DebugLog from its DAL counterpart.</summary>
		// ------------------------------------------------------------------------------
		public DebugLog(DAL.Core.DebugLog businessObject) : base(businessObject)
		{
		}

		// ------------------------------------------------------------------------------
		/// <summary>This constructor initializes the DebugLog from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public DebugLog(Guid debugLogID)
		{
			DebugLogID = debugLogID;
		}

		#endregion Constructors

		#region Methods

		// ------------------------------------------------------------------------------
		/// <summary>This method loads the DebugLog with its already set properties.</summary>
		// ------------------------------------------------------------------------------
		public void Load()
		{
			Load(DebugLogID);
		}

		// ------------------------------------------------------------------------------
		/// <summary>This method loads the DebugLog from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public void Load(Guid debugLogID)
		{
			BLL.Core.DebugLog businessObject = null;
			businessObject = BLL.Core.DebugLogManager.GetOneDebugLog(debugLogID);
			if(businessObject != null)
			{
				ReflectionHelper.Copy(businessObject, this, true);
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This method saves the DebugLog into the database,
		/// performing add/update auto detect and performing a cascade operation if indicated.</summary>
		// ------------------------------------------------------------------------------
		public void Save(bool performCascade)
		{
			if (IsLoaded == false)
			{
				BLL.Core.DebugLogManager.LogOneDebugLog(this, performCascade);
			}
			else
			{
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This method saves the DebugLog into the database,
		/// performing add/update auto detect and without performing a cascade operation.</summary>
		// ------------------------------------------------------------------------------
		public void Save()
		{
			Save(false);
		}

		/// <summary>
		///	Clears the dirty state of DebugLog and its subcollections.
		/// </summary>
		/// <param name="clearCollectionDirtyState">Flag to clear subcollections.</param>
		/// <returns></returns>
		public override void ClearDirtyState(bool clearCollectionDirtyState)
		{
			// clear base items
			base.ClearDirtyState();

			// clear collections and other items
			if (this._debugAttributeValueLogList != null)
			{
				this.DebugAttributeValueLogList.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._eventType != null)
			{
				this.EventType.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._severityLevel != null)
			{
				this.SeverityLevel.ClearDirtyState(clearCollectionDirtyState);
			}
		}


		/// <summary>
		///	Tests to see if input object is convertable to DebugLog, and has the same primary key values.
		/// </summary>
		/// <param name="obj">Input object to test.</param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			DebugLog debugLogInstance = obj as DebugLog;

			if (debugLogInstance == null)
				return false;
			else
				return (_debugLogID == debugLogInstance.DebugLogID);
		}


		/// <summary>
		///	Returns unique identifying integer		 
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return (_debugLogID.ToString()).GetHashCode();
		}
		#endregion Methods
	}
}