
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
	/// <summary>This class is used to hold and manage information for NotificationDeliveryLog instances.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[Serializable()]
	[DataTransform(Name = "MW.MComm.WalletSolution.DAL.Notifications.NotificationDeliveryLog")]
	public partial class NotificationDeliveryLog : PersistedBusinessObject
	{
		#region Constants
		#endregion Constants
		#region Fields
		// for NotificationLogID property
		protected Guid _notificationLogID = MOD.Data.DefaultValue.Guid;
		// for MetaPartnerID property
		protected Guid _metaPartnerID = MOD.Data.DefaultValue.Guid;
		// for NotificationDeliveryTypeCode property
		protected int _notificationDeliveryTypeCode = MOD.Data.DefaultValue.Int;
		// for NotificationDeliveryTypeName read only property
		[DataTransform]
		protected string _notificationDeliveryTypeName = MOD.Data.DefaultValue.String;
		// for MetaPartnerName read only property
		[DataTransform]
		protected string _metaPartnerName = MOD.Data.DefaultValue.String;
		// for DateFormatCode read only property
		[DataTransform]
		protected int _dateFormatCode = MOD.Data.DefaultValue.Int;
		// for MetaPartner property
		protected BLL.Customers.MetaPartner _metaPartner = null;
		// for NotificationDeliveryType property
		protected BLL.Notifications.NotificationDeliveryType _notificationDeliveryType = null;
		// for NotificationLog property
		protected BLL.Notifications.NotificationLog _notificationLog = null;
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
					_notificationLog = null;
					// reset NotificationLog
					BLL.PersistedBusinessObject vNotificationLog = (BLL.PersistedBusinessObject) NotificationLog;
					vNotificationLog = null;
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
					_metaPartner = null;
					// reset MetaPartner
					BLL.PersistedBusinessObject vMetaPartner = (BLL.PersistedBusinessObject) MetaPartner;
					vMetaPartner = null;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the NotificationDeliveryTypeCode.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Int)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual int NotificationDeliveryTypeCode
		{
			get
			{
				return _notificationDeliveryTypeCode;
			}
			set
			{
				if (_notificationDeliveryTypeCode != value)
				{
					_notificationDeliveryTypeCode = value;
					_notificationDeliveryType = null;
					// reset NotificationDeliveryType
					BLL.PersistedBusinessObject vNotificationDeliveryType = (BLL.PersistedBusinessObject) NotificationDeliveryType;
					vNotificationDeliveryType = null;
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
				return (MOD.Data.DataHelper.GetString(NotificationLogID,"") + ", " + MOD.Data.DataHelper.GetString(MetaPartnerID,"") + ", " + MOD.Data.DataHelper.GetString(NotificationDeliveryTypeCode,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					NotificationLogID = MOD.Data.DataHelper.GetGuid(keyValues[0], MOD.Data.DefaultValue.Guid);
				}
				if (keyValues.Length > 1)
				{
					MetaPartnerID = MOD.Data.DataHelper.GetGuid(keyValues[1], MOD.Data.DefaultValue.Guid);
				}
				if (keyValues.Length > 2)
				{
					NotificationDeliveryTypeCode = MOD.Data.DataHelper.GetInt(keyValues[2], MOD.Data.DefaultValue.Int);
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
					return NotificationDeliveryTypeName;
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
				return (MOD.Data.DataHelper.GetString(NotificationLogID,"") + ", " + MOD.Data.DataHelper.GetString(MetaPartnerID,"") + ", " + MOD.Data.DataHelper.GetString(NotificationDeliveryTypeCode,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					NotificationLogID = MOD.Data.DataHelper.GetGuid(keyValues[0], MOD.Data.DefaultValue.Guid);
				}
				if (keyValues.Length > 1)
				{
					MetaPartnerID = MOD.Data.DataHelper.GetGuid(keyValues[1], MOD.Data.DefaultValue.Guid);
				}
				if (keyValues.Length > 2)
				{
					NotificationDeliveryTypeCode = MOD.Data.DataHelper.GetInt(keyValues[2], MOD.Data.DefaultValue.Int);
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
					return "NotificationDeliveryTypeName";
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
				return (
				base.IsCollectionDirty);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This read only property gets the NotificationDeliveryTypeName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		public virtual string NotificationDeliveryTypeName
		{
			get
			{
				return _notificationDeliveryTypeName;
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
		/// <summary>This property gets or sets an item of MetaPartner.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Customers.MetaPartner MetaPartner
		{
			get
			{
				if (_metaPartner == null  && IsLazyLoadable == true)
				{
					_metaPartner = BLL.Customers.MetaPartnerManager.GetOneMetaPartner((Guid)MetaPartnerID);
					// refresh derived properties
					if (_metaPartner != null)
					{
						_metaPartnerName = _metaPartner.MetaPartnerName;
						_dateFormatCode = _metaPartner.DateFormatCode;
					}
					else
					{
						_metaPartnerName = MOD.Data.DefaultValue.String;
						_dateFormatCode = MOD.Data.DefaultValue.Int;
					}
				}
				return _metaPartner;
			}
			set
			{
				if (_metaPartner != value)
				{
					_metaPartner = value;
					_isDirty = true;
					// refresh derived properties
					if (_metaPartner != null)
					{
						_metaPartnerName = _metaPartner.MetaPartnerName;
						_dateFormatCode = _metaPartner.DateFormatCode;
					}
					else
					{
						_metaPartnerName = MOD.Data.DefaultValue.String;
						_dateFormatCode = MOD.Data.DefaultValue.Int;
					}
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of NotificationDeliveryType.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Notifications.NotificationDeliveryType NotificationDeliveryType
		{
			get
			{
				if (_notificationDeliveryType == null  && IsLazyLoadable == true)
				{
					_notificationDeliveryType = BLL.Notifications.NotificationDeliveryTypeManager.GetOneNotificationDeliveryType((int)NotificationDeliveryTypeCode);
					// refresh derived properties
					if (_notificationDeliveryType != null)
					{
						_notificationDeliveryTypeName = _notificationDeliveryType.NotificationDeliveryTypeName;
					}
					else
					{
						_notificationDeliveryTypeName = MOD.Data.DefaultValue.String;
					}
				}
				return _notificationDeliveryType;
			}
			set
			{
				if (_notificationDeliveryType != value)
				{
					_notificationDeliveryType = value;
					_isDirty = true;
					// refresh derived properties
					if (_notificationDeliveryType != null)
					{
						_notificationDeliveryTypeName = _notificationDeliveryType.NotificationDeliveryTypeName;
					}
					else
					{
						_notificationDeliveryTypeName = MOD.Data.DefaultValue.String;
					}
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of NotificationLog.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Notifications.NotificationLog NotificationLog
		{
			get
			{
				if (_notificationLog == null  && IsLazyLoadable == true)
				{
					_notificationLog = BLL.Notifications.NotificationLogManager.GetOneNotificationLog((Guid)NotificationLogID);
					// refresh derived properties
					if (_notificationLog != null)
					{
					}
					else
					{
					}
				}
				return _notificationLog;
			}
			set
			{
				if (_notificationLog != value)
				{
					_notificationLog = value;
					_isDirty = true;
					// refresh derived properties
					if (_notificationLog != null)
					{
					}
					else
					{
					}
				}
			}
		}
		#endregion Properties
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public NotificationDeliveryLog()
		{
			//
			// constructor logic
			//
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method creates an instance with the primary key values.</summary>
		// ------------------------------------------------------------------------------
		public NotificationDeliveryLog(string keyValues, bool isPrimaryKeyValues)
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
		/// <summary>This constructor initializes the NotificationDeliveryLog from its DAL counterpart.</summary>
		// ------------------------------------------------------------------------------
		public NotificationDeliveryLog(DAL.Notifications.NotificationDeliveryLog businessObject) : base(businessObject)
		{
		}
		// ------------------------------------------------------------------------------
		/// <summary>This constructor initializes the NotificationDeliveryLog from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public NotificationDeliveryLog(Guid notificationLogID, Guid metaPartnerID, int notificationDeliveryTypeCode)
		{
			NotificationLogID = notificationLogID;
			MetaPartnerID = metaPartnerID;
			NotificationDeliveryTypeCode = notificationDeliveryTypeCode;
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the NotificationDeliveryLog with its already set properties.</summary>
		// ------------------------------------------------------------------------------
		public void Load()
		{
			Load(NotificationLogID, MetaPartnerID, NotificationDeliveryTypeCode);
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the NotificationDeliveryLog from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public void Load(Guid notificationLogID, Guid metaPartnerID, int notificationDeliveryTypeCode)
		{
			BLL.Notifications.NotificationDeliveryLog businessObject = null;
			businessObject = BLL.Notifications.NotificationDeliveryLogManager.GetOneNotificationDeliveryLog(notificationLogID, metaPartnerID, notificationDeliveryTypeCode);
			if(businessObject != null)
			{
				ReflectionHelper.Copy(businessObject, this, true);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the NotificationDeliveryLog into the database,
		/// performing add/update auto detect and performing a cascade operation if indicated.</summary>
		// ------------------------------------------------------------------------------
		public void Save(bool performCascade)
		{
			if (IsLoaded == false)
			{
				BLL.Notifications.NotificationDeliveryLogManager.AddOneNotificationDeliveryLog(this, performCascade);
			}
			else
			{
				BLL.Notifications.NotificationDeliveryLogManager.UpdateOneNotificationDeliveryLog(this, performCascade);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the NotificationDeliveryLog into the database,
		/// performing add/update auto detect and without performing a cascade operation.</summary>
		// ------------------------------------------------------------------------------
		public void Save()
		{
			Save(false);
		}
		/// <summary>
		///	Clears the dirty state of NotificationDeliveryLog and its subcollections.
		/// </summary>
		/// <param name="clearCollectionDirtyState">Flag to clear subcollections.</param>
		/// <returns></returns>
		public override void ClearDirtyState(bool clearCollectionDirtyState)
		{
			// clear base items
			base.ClearDirtyState();
			// clear collections and other items
			if (this._metaPartner != null)
			{
				this.MetaPartner.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._notificationDeliveryType != null)
			{
				this.NotificationDeliveryType.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._notificationLog != null)
			{
				this.NotificationLog.ClearDirtyState(clearCollectionDirtyState);
			}
		}
		/// <summary>
		///	Tests to see if input object is convertable to NotificationDeliveryLog, and has the same primary key values.
		/// </summary>
		/// <param name="obj">Input object to test.</param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			NotificationDeliveryLog notificationDeliveryLogInstance = obj as NotificationDeliveryLog;
			if (notificationDeliveryLogInstance == null)
				return false;
			else
				return (_notificationLogID == notificationDeliveryLogInstance.NotificationLogID && 
					_metaPartnerID == notificationDeliveryLogInstance.MetaPartnerID && 
					_notificationDeliveryTypeCode == notificationDeliveryLogInstance.NotificationDeliveryTypeCode);
		}
		/// <summary>
		///	Returns unique identifying integer		 
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return (_notificationLogID.ToString() + _metaPartnerID.ToString() + _notificationDeliveryTypeCode.ToString()).GetHashCode();
		}
		#endregion Methods
	}
}