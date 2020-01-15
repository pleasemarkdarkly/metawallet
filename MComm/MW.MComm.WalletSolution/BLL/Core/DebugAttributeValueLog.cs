
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
namespace MW.MComm.WalletSolution.BLL.Core
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to hold and manage information for DebugAttributeValueLog instances.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[Serializable()]
	[DataTransform(Name = "MW.MComm.WalletSolution.DAL.Core.DebugAttributeValueLog")]
	public partial class DebugAttributeValueLog : PersistedBusinessObject
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
		// for EventName read only property
		[DataTransform]
		protected string _eventName = null;
		// for ErrorNumber read only property
		[DataTransform]
		protected int? _errorNumber = null;
		// for DebugAttribute property
		protected BLL.Core.DebugAttribute _debugAttribute = null;
		// for DebugLog property
		protected BLL.Core.DebugLog _debugLog = null;
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
					_debugLog = null;
					// reset DebugLog
					BLL.PersistedBusinessObject vDebugLog = (BLL.PersistedBusinessObject) DebugLog;
					vDebugLog = null;
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
					_debugAttribute = null;
					// reset DebugAttribute
					BLL.PersistedBusinessObject vDebugAttribute = (BLL.PersistedBusinessObject) DebugAttribute;
					vDebugAttribute = null;
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
		public virtual BLL.Core.DebugAttribute DebugAttribute
		{
			get
			{
				if (_debugAttribute == null  && IsLazyLoadable == true)
				{
					_debugAttribute = BLL.Core.DebugAttributeManager.GetOneDebugAttribute((Guid)BaseAttributeID);
					// refresh derived properties
					if (_debugAttribute != null)
					{
					}
					else
					{
					}
				}
				return _debugAttribute;
			}
			set
			{
				if (_debugAttribute != value)
				{
					_debugAttribute = value;
					_isDirty = true;
					// refresh derived properties
					if (_debugAttribute != null)
					{
					}
					else
					{
					}
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of DebugLog.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Core.DebugLog DebugLog
		{
			get
			{
				if (_debugLog == null  && IsLazyLoadable == true)
				{
					_debugLog = BLL.Core.DebugLogManager.GetOneDebugLog((Guid)DebugLogID);
					// refresh derived properties
					if (_debugLog != null)
					{
						_eventName = _debugLog.EventName;
						_errorNumber = _debugLog.ErrorNumber;
					}
					else
					{
						_eventName = MOD.Data.DefaultValue.String;
						_errorNumber = MOD.Data.DefaultValue.Int;
					}
				}
				return _debugLog;
			}
			set
			{
				if (_debugLog != value)
				{
					_debugLog = value;
					_isDirty = true;
					// refresh derived properties
					if (_debugLog != null)
					{
						_eventName = _debugLog.EventName;
						_errorNumber = _debugLog.ErrorNumber;
					}
					else
					{
						_eventName = MOD.Data.DefaultValue.String;
						_errorNumber = MOD.Data.DefaultValue.Int;
					}
				}
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
		// ------------------------------------------------------------------------------
		/// <summary>This constructor initializes the DebugAttributeValueLog from its DAL counterpart.</summary>
		// ------------------------------------------------------------------------------
		public DebugAttributeValueLog(DAL.Core.DebugAttributeValueLog businessObject) : base(businessObject)
		{
		}
		// ------------------------------------------------------------------------------
		/// <summary>This constructor initializes the DebugAttributeValueLog from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public DebugAttributeValueLog(Guid debugAttributeValueLogID)
		{
			DebugAttributeValueLogID = debugAttributeValueLogID;
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the DebugAttributeValueLog with its already set properties.</summary>
		// ------------------------------------------------------------------------------
		public void Load()
		{
			Load(DebugAttributeValueLogID);
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the DebugAttributeValueLog from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public void Load(Guid debugAttributeValueLogID)
		{
			BLL.Core.DebugAttributeValueLog businessObject = null;
			businessObject = BLL.Core.DebugAttributeValueLogManager.GetOneDebugAttributeValueLog(debugAttributeValueLogID);
			if(businessObject != null)
			{
				ReflectionHelper.Copy(businessObject, this, true);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the DebugAttributeValueLog into the database,
		/// performing add/update auto detect and performing a cascade operation if indicated.</summary>
		// ------------------------------------------------------------------------------
		public void Save(bool performCascade)
		{
			if (IsLoaded == false)
			{
				BLL.Core.DebugAttributeValueLogManager.LogOneDebugAttributeValueLog(this, performCascade);
			}
			else
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the DebugAttributeValueLog into the database,
		/// performing add/update auto detect and without performing a cascade operation.</summary>
		// ------------------------------------------------------------------------------
		public void Save()
		{
			Save(false);
		}
		/// <summary>
		///	Clears the dirty state of DebugAttributeValueLog and its subcollections.
		/// </summary>
		/// <param name="clearCollectionDirtyState">Flag to clear subcollections.</param>
		/// <returns></returns>
		public override void ClearDirtyState(bool clearCollectionDirtyState)
		{
			// clear base items
			base.ClearDirtyState();
			// clear collections and other items
			if (this._debugAttribute != null)
			{
				this.DebugAttribute.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._debugLog != null)
			{
				this.DebugLog.ClearDirtyState(clearCollectionDirtyState);
			}
		}
		/// <summary>
		///	Tests to see if input object is convertable to DebugAttributeValueLog, and has the same primary key values.
		/// </summary>
		/// <param name="obj">Input object to test.</param>
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