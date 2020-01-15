
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
namespace MW.MComm.WalletSolution.BLL.Notifications
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to hold and manage information for Notification instances.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[Serializable()]
	[DataTransform(Name = "MW.MComm.WalletSolution.DAL.Notifications.Notification")]
	public partial class Notification : PersistedBusinessObject
	{
		#region Constants
		#endregion Constants
		#region Fields
		// for NotificationCode property
		protected int _notificationCode = MOD.Data.DefaultValue.Int;
		// for NotificationName property
		protected string _notificationName = MOD.Data.DefaultValue.String;
		// for EventCode property
		protected int _eventCode = MOD.Data.DefaultValue.Int;
		// for Description property
		protected string _description = null;
		// for IsActive property
		protected bool _isActive = false;
		// for EventName read only property
		[DataTransform]
		protected string _eventName = MOD.Data.DefaultValue.String;
		// for NotificationTemplateList property
		protected BLL.SortableList<BLL.Notifications.NotificationTemplate> _notificationTemplateList = null;
		// for Event property
		protected BLL.Events.Event _event = null;
		#endregion Fields
		#region Properties
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the NotificationCode.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Int)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual int NotificationCode
		{
			get
			{
				return _notificationCode;
			}
			set
			{
				if (_notificationCode != value)
				{
					_notificationCode = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the NotificationName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual string NotificationName
		{
			get
			{
				return _notificationName;
			}
			set
			{
				if ((_notificationName != null && !_notificationName.Equals(value)) || _notificationName != value)
				{
					_notificationName = value;
					_isDirty = true;
				}
			}
		}
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
					_event = null;
					// reset Event
					BLL.PersistedBusinessObject vEvent = (BLL.PersistedBusinessObject) Event;
					vEvent = null;
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
				return (MOD.Data.DataHelper.GetString(NotificationCode,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					NotificationCode = MOD.Data.DataHelper.GetInt(keyValues[0], MOD.Data.DefaultValue.Int);
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
					return NotificationName;
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
				return (MOD.Data.DataHelper.GetString(NotificationCode,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					NotificationCode = MOD.Data.DataHelper.GetInt(keyValues[0], MOD.Data.DefaultValue.Int);
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
					return "NotificationName";
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
				return ((_notificationTemplateList != null && _notificationTemplateList.IsDirty) ||
				base.IsCollectionDirty);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This read only property gets the EventName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		public virtual string EventName
		{
			get
			{
				return _eventName;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets NotificationTemplate lists.</summary>
		// ------------------------------------------------------------------------------
		[XmlArrayItem(typeof(BLL.Notifications.NotificationTemplate), ElementName="NotificationTemplate")]
		[DataTransform]
		public virtual BLL.SortableList<BLL.Notifications.NotificationTemplate> NotificationTemplateList
		{
			get
			{
				if (_notificationTemplateList == null && IsLazyLoadable == true)
				{
					_notificationTemplateList = BLL.Notifications.NotificationTemplateManager.GetAllNotificationTemplateDataByNotificationCode(NotificationCode);
				}
				else if (_notificationTemplateList == null)
				{
					_notificationTemplateList = new BLL.SortableList<BLL.Notifications.NotificationTemplate>();
				}
				return _notificationTemplateList;
			}
			set
			{
				if (value == null)
				{
					_notificationTemplateList = value;
				}
				else if ((_notificationTemplateList == null && value != null) ||
					  !_notificationTemplateList.Equals(value))
				{
					_notificationTemplateList = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of Event.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Events.Event Event
		{
			get
			{
				if (_event == null  && IsLazyLoadable == true)
				{
					_event = BLL.Events.EventManager.GetOneEvent((int)EventCode);
					// refresh derived properties
					if (_event != null)
					{
						_eventName = _event.EventName;
					}
					else
					{
						_eventName = MOD.Data.DefaultValue.String;
					}
				}
				return _event;
			}
			set
			{
				if (_event != value)
				{
					_event = value;
					_isDirty = true;
					// refresh derived properties
					if (_event != null)
					{
						_eventName = _event.EventName;
					}
					else
					{
						_eventName = MOD.Data.DefaultValue.String;
					}
				}
			}
		}
		#endregion Properties
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public Notification()
		{
			//
			// constructor logic
			//
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method creates an instance with the primary key values.</summary>
		// ------------------------------------------------------------------------------
		public Notification(string keyValues, bool isPrimaryKeyValues)
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
		/// <summary>This constructor initializes the Notification from its DAL counterpart.</summary>
		// ------------------------------------------------------------------------------
		public Notification(DAL.Notifications.Notification businessObject) : base(businessObject)
		{
		}
		// ------------------------------------------------------------------------------
		/// <summary>This constructor initializes the Notification from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public Notification(int notificationCode)
		{
			NotificationCode = notificationCode;
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the Notification with its already set properties.</summary>
		// ------------------------------------------------------------------------------
		public void Load()
		{
			Load(NotificationCode);
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the Notification from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public void Load(int notificationCode)
		{
			BLL.Notifications.Notification businessObject = null;
			businessObject = BLL.Notifications.NotificationManager.GetOneNotification(notificationCode);
			if(businessObject != null)
			{
				ReflectionHelper.Copy(businessObject, this, true);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the Notification into the database,
		/// performing add/update auto detect and performing a cascade operation if indicated.</summary>
		// ------------------------------------------------------------------------------
		public void Save(bool performCascade)
		{
			if (IsLoaded == false)
			{
				BLL.Notifications.NotificationManager.AddOneNotification(this, performCascade);
			}
			else
			{
				BLL.Notifications.NotificationManager.UpdateOneNotification(this, performCascade);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the Notification into the database,
		/// performing add/update auto detect and without performing a cascade operation.</summary>
		// ------------------------------------------------------------------------------
		public void Save()
		{
			Save(false);
		}
		/// <summary>
		///	Clears the dirty state of Notification and its subcollections.
		/// </summary>
		/// <param name="clearCollectionDirtyState">Flag to clear subcollections.</param>
		/// <returns></returns>
		public override void ClearDirtyState(bool clearCollectionDirtyState)
		{
			// clear base items
			base.ClearDirtyState();
			// clear collections and other items
			if (this._notificationTemplateList != null)
			{
				this.NotificationTemplateList.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._event != null)
			{
				this.Event.ClearDirtyState(clearCollectionDirtyState);
			}
		}
		/// <summary>
		///	Tests to see if input object is convertable to Notification, and has the same primary key values.
		/// </summary>
		/// <param name="obj">Input object to test.</param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			Notification notificationInstance = obj as Notification;
			if (notificationInstance == null)
				return false;
			else
				return (_notificationCode == notificationInstance.NotificationCode);
		}
		/// <summary>
		///	Returns unique identifying integer		 
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return (_notificationCode.ToString()).GetHashCode();
		}
		#endregion Methods
	}
}