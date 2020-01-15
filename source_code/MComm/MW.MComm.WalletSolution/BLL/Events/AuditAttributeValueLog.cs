
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
	/// <summary>This class is used to hold and manage information for AuditAttributeValueLog instances.</summary>
	///
	/// File History:
	/// <created>3/2/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[Serializable()]
	[DataTransform(Name = "MW.MComm.WalletSolution.DAL.Events.AuditAttributeValueLog")]
	public partial class AuditAttributeValueLog : PersistedBusinessObject
	{
		#region Constants
		#endregion Constants
		#region Fields
		// for AuditAttributeValueLogID property
		protected Guid _auditAttributeValueLogID = MOD.Data.DefaultValue.Guid;
		// for AuditLogID property
		protected Guid _auditLogID = MOD.Data.DefaultValue.Guid;
		// for BaseAttributeID property
		protected Guid _baseAttributeID = MOD.Data.DefaultValue.Guid;
		// for AttributeValue property
		protected string _attributeValue = null;
		// for AuditLog property
		protected BLL.Events.AuditLog _auditLog = null;
		// for EventAttribute property
		protected BLL.Events.EventAttribute _eventAttribute = null;
		#endregion Fields
		#region Properties
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the AuditAttributeValueLogID.</summary>
		// ------------------------------------------------------------------------------
		[XmlElementAttribute()]
		[DataTransform]
		public virtual Guid AuditAttributeValueLogID
		{
			get
			{
				return _auditAttributeValueLogID;
			}
			set
			{
				if (_auditAttributeValueLogID != value)
				{
					_auditAttributeValueLogID = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the AuditLogID.</summary>
		// ------------------------------------------------------------------------------
		[XmlElementAttribute()]
		[DataTransform]
		public virtual Guid AuditLogID
		{
			get
			{
				return _auditLogID;
			}
			set
			{
				if (_auditLogID != value)
				{
					_auditLogID = value;
					_auditLog = null;
					// reset AuditLog
					BLL.PersistedBusinessObject vAuditLog = (BLL.PersistedBusinessObject) AuditLog;
					vAuditLog = null;
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
					_eventAttribute = null;
					// reset EventAttribute
					BLL.PersistedBusinessObject vEventAttribute = (BLL.PersistedBusinessObject) EventAttribute;
					vEventAttribute = null;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the AttributeValue.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(null)]
		[XmlElementAttribute(IsNullable=true)]
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
				return (MOD.Data.DataHelper.GetString(AuditAttributeValueLogID,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					AuditAttributeValueLogID = MOD.Data.DataHelper.GetGuid(keyValues[0], MOD.Data.DefaultValue.Guid);
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
					return AttributeValue;
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
				return (MOD.Data.DataHelper.GetString(AuditAttributeValueLogID,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					AuditAttributeValueLogID = MOD.Data.DataHelper.GetGuid(keyValues[0], MOD.Data.DefaultValue.Guid);
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
					return "AttributeValue";
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
		/// <summary>This property gets or sets an item of AuditLog.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Events.AuditLog AuditLog
		{
			get
			{
				if (_auditLog == null  && IsLazyLoadable == true)
				{
					_auditLog = BLL.Events.AuditLogManager.GetOneAuditLog((Guid)AuditLogID);
					// refresh derived properties
					if (_auditLog != null)
					{
					}
					else
					{
					}
				}
				return _auditLog;
			}
			set
			{
				if (_auditLog != value)
				{
					_auditLog = value;
					_isDirty = true;
					// refresh derived properties
					if (_auditLog != null)
					{
					}
					else
					{
					}
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of EventAttribute.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Events.EventAttribute EventAttribute
		{
			get
			{
				if (_eventAttribute == null  && IsLazyLoadable == true)
				{
					_eventAttribute = BLL.Events.EventAttributeManager.GetOneEventAttribute((Guid)BaseAttributeID);
					// refresh derived properties
					if (_eventAttribute != null)
					{
					}
					else
					{
					}
				}
				return _eventAttribute;
			}
			set
			{
				if (_eventAttribute != value)
				{
					_eventAttribute = value;
					_isDirty = true;
					// refresh derived properties
					if (_eventAttribute != null)
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
		public AuditAttributeValueLog()
		{
			//
			// constructor logic
			//
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method creates an instance with the primary key values.</summary>
		// ------------------------------------------------------------------------------
		public AuditAttributeValueLog(string keyValues, bool isPrimaryKeyValues)
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
		/// <summary>This constructor initializes the AuditAttributeValueLog from its DAL counterpart.</summary>
		// ------------------------------------------------------------------------------
		public AuditAttributeValueLog(DAL.Events.AuditAttributeValueLog businessObject) : base(businessObject)
		{
		}
		// ------------------------------------------------------------------------------
		/// <summary>This constructor initializes the AuditAttributeValueLog from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public AuditAttributeValueLog(Guid auditAttributeValueLogID)
		{
			AuditAttributeValueLogID = auditAttributeValueLogID;
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the AuditAttributeValueLog with its already set properties.</summary>
		// ------------------------------------------------------------------------------
		public void Load()
		{
			Load(AuditAttributeValueLogID);
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the AuditAttributeValueLog from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public void Load(Guid auditAttributeValueLogID)
		{
			BLL.Events.AuditAttributeValueLog businessObject = null;
			businessObject = BLL.Events.AuditAttributeValueLogManager.GetOneAuditAttributeValueLog(auditAttributeValueLogID);
			if(businessObject != null)
			{
				ReflectionHelper.Copy(businessObject, this, true);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the AuditAttributeValueLog into the database,
		/// performing add/update auto detect and performing a cascade operation if indicated.</summary>
		// ------------------------------------------------------------------------------
		public void Save(bool performCascade)
		{
			if (IsLoaded == false)
			{
				BLL.Events.AuditAttributeValueLogManager.LogOneAuditAttributeValueLog(this, performCascade);
			}
			else
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the AuditAttributeValueLog into the database,
		/// performing add/update auto detect and without performing a cascade operation.</summary>
		// ------------------------------------------------------------------------------
		public void Save()
		{
			Save(false);
		}
		/// <summary>
		///	Clears the dirty state of AuditAttributeValueLog and its subcollections.
		/// </summary>
		/// <param name="clearCollectionDirtyState">Flag to clear subcollections.</param>
		/// <returns></returns>
		public override void ClearDirtyState(bool clearCollectionDirtyState)
		{
			// clear base items
			base.ClearDirtyState();
			// clear collections and other items
			if (this._auditLog != null)
			{
				this.AuditLog.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._eventAttribute != null)
			{
				this.EventAttribute.ClearDirtyState(clearCollectionDirtyState);
			}
		}
		/// <summary>
		///	Tests to see if input object is convertable to AuditAttributeValueLog, and has the same primary key values.
		/// </summary>
		/// <param name="obj">Input object to test.</param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			AuditAttributeValueLog auditAttributeValueLogInstance = obj as AuditAttributeValueLog;
			if (auditAttributeValueLogInstance == null)
				return false;
			else
				return (_auditAttributeValueLogID == auditAttributeValueLogInstance.AuditAttributeValueLogID);
		}
		/// <summary>
		///	Returns unique identifying integer		 
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return (_auditAttributeValueLogID.ToString()).GetHashCode();
		}
		#endregion Methods
	}
}