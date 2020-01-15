
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
namespace MW.MComm.WalletSolution.DAL.Events
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
		// for SpecificEventAttributeList property
		protected MOD.Data.SortableObjectCollection _specificEventAttributeList = null;
		// for NotificationList property
		protected MOD.Data.SortableObjectCollection _notificationList = null;
		// for EventFeeList property
		protected MOD.Data.SortableObjectCollection _eventFeeList = null;
		// for EventPromotionList property
		protected MOD.Data.SortableObjectCollection _eventPromotionList = null;
		// for EventType property
		protected DAL.Events.EventType _eventType = null;
		// for AuditLogList property
		protected MOD.Data.SortableObjectCollection _auditLogList = null;
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
		/// <summary>This property gets or sets SpecificEventAttribute lists.</summary>
		// ------------------------------------------------------------------------------
		[XmlArrayItem(typeof(DAL.Events.SpecificEventAttribute), ElementName="SpecificEventAttribute")]
		[DataTransform]
		public virtual MOD.Data.SortableObjectCollection SpecificEventAttributeList
		{
			get
			{
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
		[XmlArrayItem(typeof(DAL.Notifications.Notification), ElementName="Notification")]
		[DataTransform]
		public virtual MOD.Data.SortableObjectCollection NotificationList
		{
			get
			{
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
		[XmlArrayItem(typeof(DAL.Events.EventFee), ElementName="EventFee")]
		[DataTransform]
		public virtual MOD.Data.SortableObjectCollection EventFeeList
		{
			get
			{
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
		[XmlArrayItem(typeof(DAL.Events.EventPromotion), ElementName="EventPromotion")]
		[DataTransform]
		public virtual MOD.Data.SortableObjectCollection EventPromotionList
		{
			get
			{
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
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets AuditLog lists.</summary>
		// ------------------------------------------------------------------------------
		[XmlArrayItem(typeof(DAL.Events.AuditLog), ElementName="AuditLog")]
		[DataTransform]
		public virtual MOD.Data.SortableObjectCollection AuditLogList
		{
			get
			{
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
				item.IsLoaded = true;
				#region Cascade Operations
				if (performCascadeOperation == true)
				{
					// cascade operations
					#region SpecificEventAttributeList
					if (item.SpecificEventAttributeList != null)
					{
						foreach(DAL.Events.SpecificEventAttribute loopSpecificEventAttribute in item.SpecificEventAttributeList)
						{
							loopSpecificEventAttribute.EventCode = item.EventCode;
							// add new item
							DAL.Events.SpecificEventAttribute.AddOneSpecificEventAttribute(loopSpecificEventAttribute, performCascadeOperation, dbAdapter);
						}
					}
					#endregion SpecificEventAttributeList
					#region NotificationList
					if (item.NotificationList != null)
					{
						foreach(DAL.Notifications.Notification loopNotification in item.NotificationList)
						{
							loopNotification.EventCode = item.EventCode;
							// add new item
							DAL.Notifications.Notification.AddOneNotification(loopNotification, performCascadeOperation, dbAdapter);
						}
					}
					#endregion NotificationList
					#region EventFeeList
					if (item.EventFeeList != null)
					{
						foreach(DAL.Events.EventFee loopEventFee in item.EventFeeList)
						{
							loopEventFee.EventCode = item.EventCode;
							// add new item
							DAL.Events.EventFee.AddOneEventFee(loopEventFee, performCascadeOperation, dbAdapter);
						}
					}
					#endregion EventFeeList
					#region EventPromotionList
					if (item.EventPromotionList != null)
					{
						foreach(DAL.Events.EventPromotion loopEventPromotion in item.EventPromotionList)
						{
							loopEventPromotion.EventCode = item.EventCode;
							// add new item
							DAL.Events.EventPromotion.AddOneEventPromotion(loopEventPromotion, performCascadeOperation, dbAdapter);
						}
					}
					#endregion EventPromotionList
					#region AuditLogList
					if (item.AuditLogList != null)
					{
						foreach(DAL.Events.AuditLog loopAuditLog in item.AuditLogList)
						{
							loopAuditLog.EventCode = item.EventCode;
							// add new item
							DAL.Events.AuditLog.LogOneAuditLog(loopAuditLog, performCascadeOperation, dbAdapter);
						}
					}
					#endregion AuditLogList
				}
				#endregion Cascade Operations
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Events.AddOneEvent");
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
				item.IsLoaded = true;
				#region Cascade Operations
				if (performCascadeOperation == true)
				{
					// cascade operations
					#region SpecificEventAttributeList
					if (item.SpecificEventAttributeList != null)
					{
						MOD.Data.SortableObjectCollection specificEventAttributeList = DAL.Events.SpecificEventAttribute.GetAllSpecificEventAttributeDataByEventCode(item.EventCode, dbAdapter);
						// process updates and adds
						foreach(DAL.Events.SpecificEventAttribute loopSpecificEventAttribute in item.SpecificEventAttributeList)
						{
							if (specificEventAttributeList.Contains(loopSpecificEventAttribute))
							{
								// update item
								loopSpecificEventAttribute.LastModifiedByUserID = item.LastModifiedByUserID;
								DAL.Events.SpecificEventAttribute.UpdateOneSpecificEventAttribute(loopSpecificEventAttribute, false, dbAdapter);
							}
							else
							{
								// add item
								loopSpecificEventAttribute.CreatedByUserID = item.CreatedByUserID;
								loopSpecificEventAttribute.LastModifiedByUserID = item.LastModifiedByUserID;
								loopSpecificEventAttribute.EventCode = item.EventCode;
								DAL.Events.SpecificEventAttribute.AddOneSpecificEventAttribute(loopSpecificEventAttribute, false, dbAdapter);
							}
						}
						// process deletions
						foreach(DAL.Events.SpecificEventAttribute loopSpecificEventAttribute in specificEventAttributeList)
						{
							if (!item.SpecificEventAttributeList.Contains(loopSpecificEventAttribute))
							{
								DAL.Events.SpecificEventAttribute.DeleteOneSpecificEventAttribute(loopSpecificEventAttribute, false, dbAdapter);
							}
						}
					}
					#endregion SpecificEventAttributeList
					#region NotificationList
					if (item.NotificationList != null)
					{
						MOD.Data.SortableObjectCollection notificationList = DAL.Notifications.Notification.GetAllNotificationDataByEventCode(item.EventCode, dbAdapter);
						// process updates and adds
						foreach(DAL.Notifications.Notification loopNotification in item.NotificationList)
						{
							if (notificationList.Contains(loopNotification))
							{
								// update item
								loopNotification.LastModifiedByUserID = item.LastModifiedByUserID;
								DAL.Notifications.Notification.UpdateOneNotification(loopNotification, false, dbAdapter);
							}
							else
							{
								// add item
								loopNotification.CreatedByUserID = item.CreatedByUserID;
								loopNotification.LastModifiedByUserID = item.LastModifiedByUserID;
								loopNotification.EventCode = item.EventCode;
								DAL.Notifications.Notification.AddOneNotification(loopNotification, false, dbAdapter);
							}
						}
						// process deletions
						foreach(DAL.Notifications.Notification loopNotification in notificationList)
						{
							if (!item.NotificationList.Contains(loopNotification))
							{
								DAL.Notifications.Notification.DeleteOneNotification(loopNotification, false, dbAdapter);
							}
						}
					}
					#endregion NotificationList
					#region EventFeeList
					if (item.EventFeeList != null)
					{
						MOD.Data.SortableObjectCollection eventFeeList = DAL.Events.EventFee.GetAllEventFeeDataByEventCode(item.EventCode, dbAdapter);
						// process updates and adds
						foreach(DAL.Events.EventFee loopEventFee in item.EventFeeList)
						{
							if (eventFeeList.Contains(loopEventFee))
							{
								// update item
								loopEventFee.LastModifiedByUserID = item.LastModifiedByUserID;
								DAL.Events.EventFee.UpdateOneEventFee(loopEventFee, false, dbAdapter);
							}
							else
							{
								// add item
								loopEventFee.CreatedByUserID = item.CreatedByUserID;
								loopEventFee.LastModifiedByUserID = item.LastModifiedByUserID;
								loopEventFee.EventCode = item.EventCode;
								DAL.Events.EventFee.AddOneEventFee(loopEventFee, false, dbAdapter);
							}
						}
						// process deletions
						foreach(DAL.Events.EventFee loopEventFee in eventFeeList)
						{
							if (!item.EventFeeList.Contains(loopEventFee))
							{
								DAL.Events.EventFee.DeleteOneEventFee(loopEventFee, false, dbAdapter);
							}
						}
					}
					#endregion EventFeeList
					#region EventPromotionList
					if (item.EventPromotionList != null)
					{
						MOD.Data.SortableObjectCollection eventPromotionList = DAL.Events.EventPromotion.GetAllEventPromotionDataByEventCode(item.EventCode, dbAdapter);
						// process updates and adds
						foreach(DAL.Events.EventPromotion loopEventPromotion in item.EventPromotionList)
						{
							if (eventPromotionList.Contains(loopEventPromotion))
							{
								// update item
								loopEventPromotion.LastModifiedByUserID = item.LastModifiedByUserID;
								DAL.Events.EventPromotion.UpdateOneEventPromotion(loopEventPromotion, false, dbAdapter);
							}
							else
							{
								// add item
								loopEventPromotion.CreatedByUserID = item.CreatedByUserID;
								loopEventPromotion.LastModifiedByUserID = item.LastModifiedByUserID;
								loopEventPromotion.EventCode = item.EventCode;
								DAL.Events.EventPromotion.AddOneEventPromotion(loopEventPromotion, false, dbAdapter);
							}
						}
						// process deletions
						foreach(DAL.Events.EventPromotion loopEventPromotion in eventPromotionList)
						{
							if (!item.EventPromotionList.Contains(loopEventPromotion))
							{
								DAL.Events.EventPromotion.DeleteOneEventPromotion(loopEventPromotion, false, dbAdapter);
							}
						}
					}
					#endregion EventPromotionList
					#region AuditLogList
					if (item.AuditLogList != null)
					{
						MOD.Data.SortableObjectCollection auditLogList = DAL.Events.AuditLog.GetAllAuditLogDataByEventCode(item.EventCode, dbAdapter);
						foreach(DAL.Events.AuditLog loopAuditLog in item.AuditLogList)
						{
							loopAuditLog.EventCode = item.EventCode;
							// add new item
							DAL.Events.AuditLog.LogOneAuditLog(loopAuditLog, performCascadeOperation, dbAdapter);
						}
					}
					#endregion AuditLogList
				}
				#endregion Cascade Operations
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "DAL.Events.UpdateOneEvent");
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
					if (item.SpecificEventAttributeList != null)
					{
						DAL.Events.SpecificEventAttribute.DeleteAllSpecificEventAttributeDataByEventCode(item.EventCode, dbAdapter);
					}
					if (item.NotificationList != null)
					{
						DAL.Notifications.Notification.DeleteAllNotificationDataByEventCode(item.EventCode, dbAdapter);
					}
					if (item.EventFeeList != null)
					{
						DAL.Events.EventFee.DeleteAllEventFeeDataByEventCode(item.EventCode, dbAdapter);
					}
					if (item.EventPromotionList != null)
					{
						DAL.Events.EventPromotion.DeleteAllEventPromotionDataByEventCode(item.EventCode, dbAdapter);
					}
					if (item.AuditLogList != null)
					{
						
					}
				}
				#endregion Cascade Operations
				MOD.Data.NamedObjectCollection spParameters = new MOD.Data.NamedObjectCollection();
				dbAdapter.ExecuteProcNQ("spEvents_DeleteOneEvent", item, spParameters);
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
				throw Utility.CustomAppException.WrapException(ex, "DAL.Events.DeleteOneEvent");
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
					item.IsLoaded = true;
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
					item.IsLoaded = true;
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
					item.IsLoaded = true;
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
					item.IsLoaded = true;
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
					item.IsLoaded = true;
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
					item.IsLoaded = true;
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