
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
	/// <summary>This class is used to hold and manage information for NotificationLog instances.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[Serializable()]
	[DataTransform(Name = "MW.MComm.WalletSolution.DAL.Notifications.NotificationLog")]
	public partial class NotificationLog : PersistedBusinessObject
	{
		#region Constants
		#endregion Constants
		#region Fields
		// for NotificationLogID property
		protected Guid _notificationLogID = MOD.Data.DefaultValue.Guid;
		// for NotificationCode property
		protected int _notificationCode = MOD.Data.DefaultValue.Int;
		// for NotificationSubject property
		protected string _notificationSubject = null;
		// for NotificationMessage property
		protected string _notificationMessage = null;
		// for LocaleCode property
		protected int _localeCode = MOD.Data.DefaultValue.Int;
		// for NotificationName read only property
		[DataTransform]
		protected string _notificationName = MOD.Data.DefaultValue.String;
		// for LocaleName read only property
		[DataTransform]
		protected string _localeName = MOD.Data.DefaultValue.String;
		// for NotificationAttributeValueLogList property
		protected BLL.SortableList<BLL.Notifications.NotificationAttributeValueLog> _notificationAttributeValueLogList = null;
		// for NotificationDeliveryLogList property
		protected BLL.SortableList<BLL.Notifications.NotificationDeliveryLog> _notificationDeliveryLogList = null;
		// for Notification property
		protected BLL.Notifications.Notification _notification = null;
		// for Locale property
		protected BLL.Environments.Locale _locale = null;
		#endregion Fields
		#region Properties
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the NotificationLogID.</summary>
		// ------------------------------------------------------------------------------
		[XmlElementAttribute()]
		[DataTransform]
		public virtual Guid NotificationLogID
		{
			get
			{
				return _notificationLogID;
			}
			set
			{
				if (_notificationLogID != value)
				{
					_notificationLogID = value;
					_isDirty = true;
				}
			}
		}
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
					_notification = null;
					// reset Notification
					BLL.PersistedBusinessObject vNotification = (BLL.PersistedBusinessObject) Notification;
					vNotification = null;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the NotificationSubject.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(null)]
		[XmlElementAttribute(IsNullable=true)]
		[DataTransform]
		public virtual string NotificationSubject
		{
			get
			{
				return _notificationSubject;
			}
			set
			{
				if ((_notificationSubject != null && !_notificationSubject.Equals(value)) || _notificationSubject != value)
				{
					_notificationSubject = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the NotificationMessage.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(null)]
		[XmlElementAttribute(IsNullable=true)]
		[DataTransform]
		public virtual string NotificationMessage
		{
			get
			{
				return _notificationMessage;
			}
			set
			{
				if ((_notificationMessage != null && !_notificationMessage.Equals(value)) || _notificationMessage != value)
				{
					_notificationMessage = value;
					_isDirty = true;
				}
			}
		}
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
					_locale = null;
					// reset Locale
					BLL.PersistedBusinessObject vLocale = (BLL.PersistedBusinessObject) Locale;
					vLocale = null;
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
				return (MOD.Data.DataHelper.GetString(NotificationLogID,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					NotificationLogID = MOD.Data.DataHelper.GetGuid(keyValues[0], MOD.Data.DefaultValue.Guid);
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
				return (MOD.Data.DataHelper.GetString(NotificationLogID,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					NotificationLogID = MOD.Data.DataHelper.GetGuid(keyValues[0], MOD.Data.DefaultValue.Guid);
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
				return ((_notificationAttributeValueLogList != null && _notificationAttributeValueLogList.IsDirty) ||
				(_notificationDeliveryLogList != null && _notificationDeliveryLogList.IsDirty) ||
				base.IsCollectionDirty);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This read only property gets the NotificationName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		public virtual string NotificationName
		{
			get
			{
				return _notificationName;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This read only property gets the LocaleName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		public virtual string LocaleName
		{
			get
			{
				return _localeName;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets NotificationAttributeValueLog lists.</summary>
		// ------------------------------------------------------------------------------
		[XmlArrayItem(typeof(BLL.Notifications.NotificationAttributeValueLog), ElementName="NotificationAttributeValueLog")]
		[DataTransform]
		public virtual BLL.SortableList<BLL.Notifications.NotificationAttributeValueLog> NotificationAttributeValueLogList
		{
			get
			{
				if (_notificationAttributeValueLogList == null && IsLazyLoadable == true)
				{
					_notificationAttributeValueLogList = BLL.Notifications.NotificationAttributeValueLogManager.GetAllNotificationAttributeValueLogDataByNotificationLogID(NotificationLogID);
				}
				else if (_notificationAttributeValueLogList == null)
				{
					_notificationAttributeValueLogList = new BLL.SortableList<BLL.Notifications.NotificationAttributeValueLog>();
				}
				return _notificationAttributeValueLogList;
			}
			set
			{
				if (value == null)
				{
					_notificationAttributeValueLogList = value;
				}
				else if ((_notificationAttributeValueLogList == null && value != null) ||
					  !_notificationAttributeValueLogList.Equals(value))
				{
					_notificationAttributeValueLogList = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets NotificationDeliveryLog lists.</summary>
		// ------------------------------------------------------------------------------
		[XmlArrayItem(typeof(BLL.Notifications.NotificationDeliveryLog), ElementName="NotificationDeliveryLog")]
		[DataTransform]
		public virtual BLL.SortableList<BLL.Notifications.NotificationDeliveryLog> NotificationDeliveryLogList
		{
			get
			{
				if (_notificationDeliveryLogList == null && IsLazyLoadable == true)
				{
					_notificationDeliveryLogList = BLL.Notifications.NotificationDeliveryLogManager.GetAllNotificationDeliveryLogDataByNotificationLogID(NotificationLogID);
				}
				else if (_notificationDeliveryLogList == null)
				{
					_notificationDeliveryLogList = new BLL.SortableList<BLL.Notifications.NotificationDeliveryLog>();
				}
				return _notificationDeliveryLogList;
			}
			set
			{
				if (value == null)
				{
					_notificationDeliveryLogList = value;
				}
				else if ((_notificationDeliveryLogList == null && value != null) ||
					  !_notificationDeliveryLogList.Equals(value))
				{
					_notificationDeliveryLogList = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of Notification.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Notifications.Notification Notification
		{
			get
			{
				if (_notification == null  && IsLazyLoadable == true)
				{
					_notification = BLL.Notifications.NotificationManager.GetOneNotification((int)NotificationCode);
					// refresh derived properties
					if (_notification != null)
					{
						_notificationName = _notification.NotificationName;
					}
					else
					{
						_notificationName = MOD.Data.DefaultValue.String;
					}
				}
				return _notification;
			}
			set
			{
				if (_notification != value)
				{
					_notification = value;
					_isDirty = true;
					// refresh derived properties
					if (_notification != null)
					{
						_notificationName = _notification.NotificationName;
					}
					else
					{
						_notificationName = MOD.Data.DefaultValue.String;
					}
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of Locale.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Environments.Locale Locale
		{
			get
			{
				if (_locale == null  && IsLazyLoadable == true)
				{
					_locale = BLL.Environments.LocaleManager.GetOneLocale((int)LocaleCode);
					// refresh derived properties
					if (_locale != null)
					{
						_localeName = _locale.LocaleName;
					}
					else
					{
						_localeName = MOD.Data.DefaultValue.String;
					}
				}
				return _locale;
			}
			set
			{
				if (_locale != value)
				{
					_locale = value;
					_isDirty = true;
					// refresh derived properties
					if (_locale != null)
					{
						_localeName = _locale.LocaleName;
					}
					else
					{
						_localeName = MOD.Data.DefaultValue.String;
					}
				}
			}
		}
		#endregion Properties
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public NotificationLog()
		{
			//
			// constructor logic
			//
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method creates an instance with the primary key values.</summary>
		// ------------------------------------------------------------------------------
		public NotificationLog(string keyValues, bool isPrimaryKeyValues)
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
		/// <summary>This constructor initializes the NotificationLog from its DAL counterpart.</summary>
		// ------------------------------------------------------------------------------
		public NotificationLog(DAL.Notifications.NotificationLog businessObject) : base(businessObject)
		{
		}
		// ------------------------------------------------------------------------------
		/// <summary>This constructor initializes the NotificationLog from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public NotificationLog(Guid notificationLogID)
		{
			NotificationLogID = notificationLogID;
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the NotificationLog with its already set properties.</summary>
		// ------------------------------------------------------------------------------
		public void Load()
		{
			Load(NotificationLogID);
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the NotificationLog from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public void Load(Guid notificationLogID)
		{
			BLL.Notifications.NotificationLog businessObject = null;
			businessObject = BLL.Notifications.NotificationLogManager.GetOneNotificationLog(notificationLogID);
			if(businessObject != null)
			{
				ReflectionHelper.Copy(businessObject, this, true);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the NotificationLog into the database,
		/// performing add/update auto detect and performing a cascade operation if indicated.</summary>
		// ------------------------------------------------------------------------------
		public void Save(bool performCascade)
		{
			if (IsLoaded == false)
			{
				BLL.Notifications.NotificationLogManager.LogOneNotificationLog(this, performCascade);
			}
			else
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the NotificationLog into the database,
		/// performing add/update auto detect and without performing a cascade operation.</summary>
		// ------------------------------------------------------------------------------
		public void Save()
		{
			Save(false);
		}
		/// <summary>
		///	Clears the dirty state of NotificationLog and its subcollections.
		/// </summary>
		/// <param name="clearCollectionDirtyState">Flag to clear subcollections.</param>
		/// <returns></returns>
		public override void ClearDirtyState(bool clearCollectionDirtyState)
		{
			// clear base items
			base.ClearDirtyState();
			// clear collections and other items
			if (this._notificationAttributeValueLogList != null)
			{
				this.NotificationAttributeValueLogList.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._notificationDeliveryLogList != null)
			{
				this.NotificationDeliveryLogList.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._notification != null)
			{
				this.Notification.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._locale != null)
			{
				this.Locale.ClearDirtyState(clearCollectionDirtyState);
			}
		}
		/// <summary>
		///	Tests to see if input object is convertable to NotificationLog, and has the same primary key values.
		/// </summary>
		/// <param name="obj">Input object to test.</param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			NotificationLog notificationLogInstance = obj as NotificationLog;
			if (notificationLogInstance == null)
				return false;
			else
				return (_notificationLogID == notificationLogInstance.NotificationLogID);
		}
		/// <summary>
		///	Returns unique identifying integer		 
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return (_notificationLogID.ToString()).GetHashCode();
		}
		#endregion Methods
	}
}