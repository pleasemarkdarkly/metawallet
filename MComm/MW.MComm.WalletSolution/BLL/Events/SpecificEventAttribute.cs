
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
	/// <summary>This class is used to hold and manage information for SpecificEventAttribute instances.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[Serializable()]
	[DataTransform(Name = "MW.MComm.WalletSolution.DAL.Events.SpecificEventAttribute")]
	public partial class SpecificEventAttribute : PersistedBusinessObject
	{
		#region Constants
		#endregion Constants
		#region Fields
		// for EventCode property
		protected int _eventCode = MOD.Data.DefaultValue.Int;
		// for BaseAttributeID property
		protected Guid _baseAttributeID = MOD.Data.DefaultValue.Guid;
		// for Rank property
		protected int _rank = 0;
		// for EventName read only property
		[DataTransform]
		protected string _eventName = MOD.Data.DefaultValue.String;
		// for AttributeCode read only property
		[DataTransform]
		protected int _attributeCode = MOD.Data.DefaultValue.Int;
		// for Event property
		protected BLL.Events.Event _event = null;
		// for EventAttribute property
		protected BLL.Events.EventAttribute _eventAttribute = null;
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
					_event = null;
					// reset Event
					BLL.PersistedBusinessObject vEvent = (BLL.PersistedBusinessObject) Event;
					vEvent = null;
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
		/// <summary>This property gets or sets the Rank.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Int)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual int Rank
		{
			get
			{
				return _rank;
			}
			set
			{
				if (_rank != value)
				{
					_rank = value;
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
				return (MOD.Data.DataHelper.GetString(EventCode,"") + ", " + MOD.Data.DataHelper.GetString(BaseAttributeID,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					EventCode = MOD.Data.DataHelper.GetInt(keyValues[0], MOD.Data.DefaultValue.Int);
				}
				if (keyValues.Length > 1)
				{
					BaseAttributeID = MOD.Data.DataHelper.GetGuid(keyValues[1], MOD.Data.DefaultValue.Guid);
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
				return (MOD.Data.DataHelper.GetString(EventCode,"") + ", " + MOD.Data.DataHelper.GetString(BaseAttributeID,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					EventCode = MOD.Data.DataHelper.GetInt(keyValues[0], MOD.Data.DefaultValue.Int);
				}
				if (keyValues.Length > 1)
				{
					BaseAttributeID = MOD.Data.DataHelper.GetGuid(keyValues[1], MOD.Data.DefaultValue.Guid);
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
				return (
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
		/// <summary>This read only property gets the AttributeCode.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Int)]
		[XmlElementAttribute()]
		public virtual int AttributeCode
		{
			get
			{
				return _attributeCode;
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
						_attributeCode = _eventAttribute.AttributeCode;
					}
					else
					{
						_attributeCode = MOD.Data.DefaultValue.Int;
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
						_attributeCode = _eventAttribute.AttributeCode;
					}
					else
					{
						_attributeCode = MOD.Data.DefaultValue.Int;
					}
				}
			}
		}
		#endregion Properties
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public SpecificEventAttribute()
		{
			//
			// constructor logic
			//
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method creates an instance with the primary key values.</summary>
		// ------------------------------------------------------------------------------
		public SpecificEventAttribute(string keyValues, bool isPrimaryKeyValues)
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
		/// <summary>This constructor initializes the SpecificEventAttribute from its DAL counterpart.</summary>
		// ------------------------------------------------------------------------------
		public SpecificEventAttribute(DAL.Events.SpecificEventAttribute businessObject) : base(businessObject)
		{
		}
		// ------------------------------------------------------------------------------
		/// <summary>This constructor initializes the SpecificEventAttribute from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public SpecificEventAttribute(int eventCode, Guid baseAttributeID)
		{
			EventCode = eventCode;
			BaseAttributeID = baseAttributeID;
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the SpecificEventAttribute with its already set properties.</summary>
		// ------------------------------------------------------------------------------
		public void Load()
		{
			Load(EventCode, BaseAttributeID);
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the SpecificEventAttribute from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public void Load(int eventCode, Guid baseAttributeID)
		{
			BLL.Events.SpecificEventAttribute businessObject = null;
			businessObject = BLL.Events.SpecificEventAttributeManager.GetOneSpecificEventAttribute(eventCode, baseAttributeID);
			if(businessObject != null)
			{
				ReflectionHelper.Copy(businessObject, this, true);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the SpecificEventAttribute into the database,
		/// performing add/update auto detect and performing a cascade operation if indicated.</summary>
		// ------------------------------------------------------------------------------
		public void Save(bool performCascade)
		{
			if (IsLoaded == false)
			{
				BLL.Events.SpecificEventAttributeManager.AddOneSpecificEventAttribute(this, performCascade);
			}
			else
			{
				BLL.Events.SpecificEventAttributeManager.UpdateOneSpecificEventAttribute(this, performCascade);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the SpecificEventAttribute into the database,
		/// performing add/update auto detect and without performing a cascade operation.</summary>
		// ------------------------------------------------------------------------------
		public void Save()
		{
			Save(false);
		}
		/// <summary>
		///	Clears the dirty state of SpecificEventAttribute and its subcollections.
		/// </summary>
		/// <param name="clearCollectionDirtyState">Flag to clear subcollections.</param>
		/// <returns></returns>
		public override void ClearDirtyState(bool clearCollectionDirtyState)
		{
			// clear base items
			base.ClearDirtyState();
			// clear collections and other items
			if (this._event != null)
			{
				this.Event.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._eventAttribute != null)
			{
				this.EventAttribute.ClearDirtyState(clearCollectionDirtyState);
			}
		}
		/// <summary>
		///	Tests to see if input object is convertable to SpecificEventAttribute, and has the same primary key values.
		/// </summary>
		/// <param name="obj">Input object to test.</param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			SpecificEventAttribute specificEventAttributeInstance = obj as SpecificEventAttribute;
			if (specificEventAttributeInstance == null)
				return false;
			else
				return (_eventCode == specificEventAttributeInstance.EventCode && 
					_baseAttributeID == specificEventAttributeInstance.BaseAttributeID);
		}
		/// <summary>
		///	Returns unique identifying integer		 
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return (_eventCode.ToString() + _baseAttributeID.ToString()).GetHashCode();
		}
		#endregion Methods
	}
}