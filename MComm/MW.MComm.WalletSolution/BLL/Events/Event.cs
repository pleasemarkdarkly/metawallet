
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
namespace MW.MComm.WalletSolution.BLL.Events
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to hold and manage information for Event instances.</summary>
	///
	/// File History:
	/// <created>3/2/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[Serializable()]
	[DataTransform(Name = "MW.MComm.WalletSolution.DAL.Events.Event")]
	public partial class Event : PersistedBusinessObject
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
		// for EventTypeName read only property
		[DataTransform]
		protected string _eventTypeName = MOD.Data.DefaultValue.String;
		// for SpecificEventAttributeList property
		protected BLL.SortableList<BLL.Events.SpecificEventAttribute> _specificEventAttributeList = null;
		// for NotificationList property
		protected BLL.SortableList<BLL.Notifications.Notification> _notificationList = null;
		// for EventFeeList property
		protected BLL.SortableList<BLL.Events.EventFee> _eventFeeList = null;
		// for EventPromotionList property
		protected BLL.SortableList<BLL.Events.EventPromotion> _eventPromotionList = null;
		// for EventType property
		protected BLL.Events.EventType _eventType = null;
		// for AuditLogList property
		protected BLL.SortableList<BLL.Events.AuditLog> _auditLogList = null;
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
					_eventType = null;
					// reset EventType
					BLL.PersistedBusinessObject vEventType = (BLL.PersistedBusinessObject) EventType;
					vEventType = null;
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
		/// <summary>This property checks for any collections that have been modified since object was last saved to or loaded from the database</summary>
		// ------------------------------------------------------------------------------
		public override bool IsCollectionDirty
		{
			get
			{
				return ((_specificEventAttributeList != null && _specificEventAttributeList.IsDirty) ||
				(_notificationList != null && _notificationList.IsDirty) ||
				(_eventFeeList != null && _eventFeeList.IsDirty) ||
				(_eventPromotionList != null && _eventPromotionList.IsDirty) ||
				(_auditLogList != null && _auditLogList.IsDirty) ||
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
		/// <summary>This property gets or sets SpecificEventAttribute lists.</summary>
		// ------------------------------------------------------------------------------
		[XmlArrayItem(typeof(BLL.Events.SpecificEventAttribute), ElementName="SpecificEventAttribute")]
		[DataTransform]
		public virtual BLL.SortableList<BLL.Events.SpecificEventAttribute> SpecificEventAttributeList
		{
			get
			{
				if (_specificEventAttributeList == null && IsLazyLoadable == true)
				{
					_specificEventAttributeList = BLL.Events.SpecificEventAttributeManager.GetAllSpecificEventAttributeDataByEventCode(EventCode);
				}
				else if (_specificEventAttributeList == null)
				{
					_specificEventAttributeList = new BLL.SortableList<BLL.Events.SpecificEventAttribute>();
				}
				return _specificEventAttributeList;
			}
			set
			{
				if (value == null)
				{
					_specificEventAttributeList = value;
				}
				else if ((_specificEventAttributeList == null && value != null) ||
					  !_specificEventAttributeList.Equals(value))
				{
					_specificEventAttributeList = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets Notification lists.</summary>
		// ------------------------------------------------------------------------------
		[XmlArrayItem(typeof(BLL.Notifications.Notification), ElementName="Notification")]
		[DataTransform]
		public virtual BLL.SortableList<BLL.Notifications.Notification> NotificationList
		{
			get
			{
				if (_notificationList == null && IsLazyLoadable == true)
				{
					_notificationList = BLL.Notifications.NotificationManager.GetAllNotificationDataByEventCode(EventCode);
				}
				else if (_notificationList == null)
				{
					_notificationList = new BLL.SortableList<BLL.Notifications.Notification>();
				}
				return _notificationList;
			}
			set
			{
				if (value == null)
				{
					_notificationList = value;
				}
				else if ((_notificationList == null && value != null) ||
					  !_notificationList.Equals(value))
				{
					_notificationList = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets EventFee lists.</summary>
		// ------------------------------------------------------------------------------
		[XmlArrayItem(typeof(BLL.Events.EventFee), ElementName="EventFee")]
		[DataTransform]
		public virtual BLL.SortableList<BLL.Events.EventFee> EventFeeList
		{
			get
			{
				if (_eventFeeList == null && IsLazyLoadable == true)
				{
					_eventFeeList = BLL.Events.EventFeeManager.GetAllEventFeeDataByEventCode(EventCode);
				}
				else if (_eventFeeList == null)
				{
					_eventFeeList = new BLL.SortableList<BLL.Events.EventFee>();
				}
				return _eventFeeList;
			}
			set
			{
				if (value == null)
				{
					_eventFeeList = value;
				}
				else if ((_eventFeeList == null && value != null) ||
					  !_eventFeeList.Equals(value))
				{
					_eventFeeList = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets EventPromotion lists.</summary>
		// ------------------------------------------------------------------------------
		[XmlArrayItem(typeof(BLL.Events.EventPromotion), ElementName="EventPromotion")]
		[DataTransform]
		public virtual BLL.SortableList<BLL.Events.EventPromotion> EventPromotionList
		{
			get
			{
				if (_eventPromotionList == null && IsLazyLoadable == true)
				{
					_eventPromotionList = BLL.Events.EventPromotionManager.GetAllEventPromotionDataByEventCode(EventCode);
				}
				else if (_eventPromotionList == null)
				{
					_eventPromotionList = new BLL.SortableList<BLL.Events.EventPromotion>();
				}
				return _eventPromotionList;
			}
			set
			{
				if (value == null)
				{
					_eventPromotionList = value;
				}
				else if ((_eventPromotionList == null && value != null) ||
					  !_eventPromotionList.Equals(value))
				{
					_eventPromotionList = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of EventType.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Events.EventType EventType
		{
			get
			{
				if (_eventType == null  && IsLazyLoadable == true)
				{
					_eventType = BLL.Events.EventTypeManager.GetOneEventType((int)EventTypeCode);
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
		/// <summary>This property gets or sets AuditLog lists.</summary>
		// ------------------------------------------------------------------------------
		[XmlArrayItem(typeof(BLL.Events.AuditLog), ElementName="AuditLog")]
		[DataTransform]
		public virtual BLL.SortableList<BLL.Events.AuditLog> AuditLogList
		{
			get
			{
				if (_auditLogList == null && IsLazyLoadable == true)
				{
					_auditLogList = BLL.Events.AuditLogManager.GetAllAuditLogDataByEventCode(EventCode);
				}
				else if (_auditLogList == null)
				{
					_auditLogList = new BLL.SortableList<BLL.Events.AuditLog>();
				}
				return _auditLogList;
			}
			set
			{
				if (value == null)
				{
					_auditLogList = value;
				}
				else if ((_auditLogList == null && value != null) ||
					  !_auditLogList.Equals(value))
				{
					_auditLogList = value;
					_isDirty = true;
				}
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
		// ------------------------------------------------------------------------------
		/// <summary>This constructor initializes the Event from its DAL counterpart.</summary>
		// ------------------------------------------------------------------------------
		public Event(DAL.Events.Event businessObject) : base(businessObject)
		{
		}
		// ------------------------------------------------------------------------------
		/// <summary>This constructor initializes the Event from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public Event(int eventCode)
		{
			EventCode = eventCode;
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the Event with its already set properties.</summary>
		// ------------------------------------------------------------------------------
		public void Load()
		{
			Load(EventCode);
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the Event from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public void Load(int eventCode)
		{
			BLL.Events.Event businessObject = null;
			businessObject = BLL.Events.EventManager.GetOneEvent(eventCode);
			if(businessObject != null)
			{
				ReflectionHelper.Copy(businessObject, this, true);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the Event into the database,
		/// performing add/update auto detect and performing a cascade operation if indicated.</summary>
		// ------------------------------------------------------------------------------
		public void Save(bool performCascade)
		{
			if (IsLoaded == false)
			{
				BLL.Events.EventManager.AddOneEvent(this, performCascade);
			}
			else
			{
				BLL.Events.EventManager.UpdateOneEvent(this, performCascade);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the Event into the database,
		/// performing add/update auto detect and without performing a cascade operation.</summary>
		// ------------------------------------------------------------------------------
		public void Save()
		{
			Save(false);
		}
		/// <summary>
		///	Clears the dirty state of Event and its subcollections.
		/// </summary>
		/// <param name="clearCollectionDirtyState">Flag to clear subcollections.</param>
		/// <returns></returns>
		public override void ClearDirtyState(bool clearCollectionDirtyState)
		{
			// clear base items
			base.ClearDirtyState();
			// clear collections and other items
			if (this._specificEventAttributeList != null)
			{
				this.SpecificEventAttributeList.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._notificationList != null)
			{
				this.NotificationList.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._eventFeeList != null)
			{
				this.EventFeeList.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._eventPromotionList != null)
			{
				this.EventPromotionList.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._eventType != null)
			{
				this.EventType.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._auditLogList != null)
			{
				this.AuditLogList.ClearDirtyState(clearCollectionDirtyState);
			}
		}
		/// <summary>
		///	Tests to see if input object is convertable to Event, and has the same primary key values.
		/// </summary>
		/// <param name="obj">Input object to test.</param>
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