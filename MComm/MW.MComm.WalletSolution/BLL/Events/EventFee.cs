
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
	/// <summary>This class is used to hold and manage information for EventFee instances.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[Serializable()]
	[DataTransform(Name = "MW.MComm.WalletSolution.DAL.Events.EventFee")]
	public partial class EventFee : PersistedBusinessObject
	{
		#region Constants
		#endregion Constants
		#region Fields
		// for EventCode property
		protected int _eventCode = MOD.Data.DefaultValue.Int;
		// for FeeCode property
		protected int _feeCode = MOD.Data.DefaultValue.Int;
		// for Rank property
		protected int _rank = 0;
		// for EventName read only property
		[DataTransform]
		protected string _eventName = MOD.Data.DefaultValue.String;
		// for FeeName read only property
		[DataTransform]
		protected string _feeName = MOD.Data.DefaultValue.String;
		// for Event property
		protected BLL.Events.Event _event = null;
		// for Fee property
		protected BLL.Payments.Fee _fee = null;
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
		/// <summary>This property gets or sets the FeeCode.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Int)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual int FeeCode
		{
			get
			{
				return _feeCode;
			}
			set
			{
				if (_feeCode != value)
				{
					_feeCode = value;
					_fee = null;
					// reset Fee
					BLL.PersistedBusinessObject vFee = (BLL.PersistedBusinessObject) Fee;
					vFee = null;
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
				return (MOD.Data.DataHelper.GetString(EventCode,"") + ", " + MOD.Data.DataHelper.GetString(FeeCode,""));
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
					FeeCode = MOD.Data.DataHelper.GetInt(keyValues[1], MOD.Data.DefaultValue.Int);
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
				return (MOD.Data.DataHelper.GetString(EventCode,"") + ", " + MOD.Data.DataHelper.GetString(FeeCode,""));
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
					FeeCode = MOD.Data.DataHelper.GetInt(keyValues[1], MOD.Data.DefaultValue.Int);
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
		/// <summary>This read only property gets the FeeName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		public virtual string FeeName
		{
			get
			{
				return _feeName;
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
		/// <summary>This property gets or sets an item of Fee.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Payments.Fee Fee
		{
			get
			{
				if (_fee == null  && IsLazyLoadable == true)
				{
					_fee = BLL.Payments.FeeManager.GetOneFee((int)FeeCode);
					// refresh derived properties
					if (_fee != null)
					{
						_feeName = _fee.FeeName;
					}
					else
					{
						_feeName = MOD.Data.DefaultValue.String;
					}
				}
				return _fee;
			}
			set
			{
				if (_fee != value)
				{
					_fee = value;
					_isDirty = true;
					// refresh derived properties
					if (_fee != null)
					{
						_feeName = _fee.FeeName;
					}
					else
					{
						_feeName = MOD.Data.DefaultValue.String;
					}
				}
			}
		}
		#endregion Properties
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public EventFee()
		{
			//
			// constructor logic
			//
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method creates an instance with the primary key values.</summary>
		// ------------------------------------------------------------------------------
		public EventFee(string keyValues, bool isPrimaryKeyValues)
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
		/// <summary>This constructor initializes the EventFee from its DAL counterpart.</summary>
		// ------------------------------------------------------------------------------
		public EventFee(DAL.Events.EventFee businessObject) : base(businessObject)
		{
		}
		// ------------------------------------------------------------------------------
		/// <summary>This constructor initializes the EventFee from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public EventFee(int eventCode, int feeCode)
		{
			EventCode = eventCode;
			FeeCode = feeCode;
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the EventFee with its already set properties.</summary>
		// ------------------------------------------------------------------------------
		public void Load()
		{
			Load(EventCode, FeeCode);
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the EventFee from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public void Load(int eventCode, int feeCode)
		{
			BLL.Events.EventFee businessObject = null;
			businessObject = BLL.Events.EventFeeManager.GetOneEventFee(eventCode, feeCode);
			if(businessObject != null)
			{
				ReflectionHelper.Copy(businessObject, this, true);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the EventFee into the database,
		/// performing add/update auto detect and performing a cascade operation if indicated.</summary>
		// ------------------------------------------------------------------------------
		public void Save(bool performCascade)
		{
			if (IsLoaded == false)
			{
				BLL.Events.EventFeeManager.AddOneEventFee(this, performCascade);
			}
			else
			{
				BLL.Events.EventFeeManager.UpdateOneEventFee(this, performCascade);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the EventFee into the database,
		/// performing add/update auto detect and without performing a cascade operation.</summary>
		// ------------------------------------------------------------------------------
		public void Save()
		{
			Save(false);
		}
		/// <summary>
		///	Clears the dirty state of EventFee and its subcollections.
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
			if (this._fee != null)
			{
				this.Fee.ClearDirtyState(clearCollectionDirtyState);
			}
		}
		/// <summary>
		///	Tests to see if input object is convertable to EventFee, and has the same primary key values.
		/// </summary>
		/// <param name="obj">Input object to test.</param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			EventFee eventFeeInstance = obj as EventFee;
			if (eventFeeInstance == null)
				return false;
			else
				return (_eventCode == eventFeeInstance.EventCode && 
					_feeCode == eventFeeInstance.FeeCode);
		}
		/// <summary>
		///	Returns unique identifying integer		 
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return (_eventCode.ToString() + _feeCode.ToString()).GetHashCode();
		}
		#endregion Methods
	}
}