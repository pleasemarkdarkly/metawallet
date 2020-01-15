
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
namespace MW.MComm.WalletSolution.BLL.Users
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to hold and manage information for UserRoleActivity instances.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[Serializable()]
	[DataTransform(Name = "MW.MComm.WalletSolution.DAL.Users.UserRoleActivity")]
	public partial class UserRoleActivity : PersistedBusinessObject
	{
		#region Constants
		#endregion Constants
		#region Fields
		// for UserRoleCode property
		protected int _userRoleCode = MOD.Data.DefaultValue.Int;
		// for ActivityCode property
		protected int _activityCode = MOD.Data.DefaultValue.Int;
		// for AccessModeCode property
		protected int _accessModeCode = MOD.Data.DefaultValue.Int;
		// for UserRoleName read only property
		[DataTransform]
		protected string _userRoleName = MOD.Data.DefaultValue.String;
		// for ActivityName read only property
		[DataTransform]
		protected string _activityName = MOD.Data.DefaultValue.String;
		// for AccessModeName read only property
		[DataTransform]
		protected string _accessModeName = MOD.Data.DefaultValue.String;
		// for AccessMode property
		protected BLL.Users.AccessMode _accessMode = null;
		// for Activity property
		protected BLL.Users.Activity _activity = null;
		// for UserRole property
		protected BLL.Users.UserRole _userRole = null;
		#endregion Fields
		#region Properties
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the UserRoleCode.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Int)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual int UserRoleCode
		{
			get
			{
				return _userRoleCode;
			}
			set
			{
				if (_userRoleCode != value)
				{
					_userRoleCode = value;
					_userRole = null;
					// reset UserRole
					BLL.PersistedBusinessObject vUserRole = (BLL.PersistedBusinessObject) UserRole;
					vUserRole = null;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the ActivityCode.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Int)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual int ActivityCode
		{
			get
			{
				return _activityCode;
			}
			set
			{
				if (_activityCode != value)
				{
					_activityCode = value;
					_activity = null;
					// reset Activity
					BLL.PersistedBusinessObject vActivity = (BLL.PersistedBusinessObject) Activity;
					vActivity = null;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the AccessModeCode.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Int)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual int AccessModeCode
		{
			get
			{
				return _accessModeCode;
			}
			set
			{
				if (_accessModeCode != value)
				{
					_accessModeCode = value;
					_accessMode = null;
					// reset AccessMode
					BLL.PersistedBusinessObject vAccessMode = (BLL.PersistedBusinessObject) AccessMode;
					vAccessMode = null;
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
				return (MOD.Data.DataHelper.GetString(UserRoleCode,"") + ", " + MOD.Data.DataHelper.GetString(ActivityCode,"") + ", " + MOD.Data.DataHelper.GetString(AccessModeCode,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					UserRoleCode = MOD.Data.DataHelper.GetInt(keyValues[0], MOD.Data.DefaultValue.Int);
				}
				if (keyValues.Length > 1)
				{
					ActivityCode = MOD.Data.DataHelper.GetInt(keyValues[1], MOD.Data.DefaultValue.Int);
				}
				if (keyValues.Length > 2)
				{
					AccessModeCode = MOD.Data.DataHelper.GetInt(keyValues[2], MOD.Data.DefaultValue.Int);
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
					return UserRoleName;
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
				return (MOD.Data.DataHelper.GetString(UserRoleCode,"") + ", " + MOD.Data.DataHelper.GetString(ActivityCode,"") + ", " + MOD.Data.DataHelper.GetString(AccessModeCode,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					UserRoleCode = MOD.Data.DataHelper.GetInt(keyValues[0], MOD.Data.DefaultValue.Int);
				}
				if (keyValues.Length > 1)
				{
					ActivityCode = MOD.Data.DataHelper.GetInt(keyValues[1], MOD.Data.DefaultValue.Int);
				}
				if (keyValues.Length > 2)
				{
					AccessModeCode = MOD.Data.DataHelper.GetInt(keyValues[2], MOD.Data.DefaultValue.Int);
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
					return "UserRoleName";
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
		/// <summary>This read only property gets the UserRoleName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		public virtual string UserRoleName
		{
			get
			{
				return _userRoleName;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This read only property gets the ActivityName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		public virtual string ActivityName
		{
			get
			{
				return _activityName;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This read only property gets the AccessModeName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		public virtual string AccessModeName
		{
			get
			{
				return _accessModeName;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of AccessMode.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Users.AccessMode AccessMode
		{
			get
			{
				if (_accessMode == null  && IsLazyLoadable == true)
				{
					_accessMode = BLL.Users.AccessModeManager.GetOneAccessMode((int)AccessModeCode);
					// refresh derived properties
					if (_accessMode != null)
					{
						_accessModeName = _accessMode.AccessModeName;
					}
					else
					{
						_accessModeName = MOD.Data.DefaultValue.String;
					}
				}
				return _accessMode;
			}
			set
			{
				if (_accessMode != value)
				{
					_accessMode = value;
					_isDirty = true;
					// refresh derived properties
					if (_accessMode != null)
					{
						_accessModeName = _accessMode.AccessModeName;
					}
					else
					{
						_accessModeName = MOD.Data.DefaultValue.String;
					}
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of Activity.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Users.Activity Activity
		{
			get
			{
				if (_activity == null  && IsLazyLoadable == true)
				{
					_activity = BLL.Users.ActivityManager.GetOneActivity((int)ActivityCode);
					// refresh derived properties
					if (_activity != null)
					{
						_activityName = _activity.ActivityName;
					}
					else
					{
						_activityName = MOD.Data.DefaultValue.String;
					}
				}
				return _activity;
			}
			set
			{
				if (_activity != value)
				{
					_activity = value;
					_isDirty = true;
					// refresh derived properties
					if (_activity != null)
					{
						_activityName = _activity.ActivityName;
					}
					else
					{
						_activityName = MOD.Data.DefaultValue.String;
					}
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of UserRole.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Users.UserRole UserRole
		{
			get
			{
				if (_userRole == null  && IsLazyLoadable == true)
				{
					_userRole = BLL.Users.UserRoleManager.GetOneUserRole((int)UserRoleCode);
					// refresh derived properties
					if (_userRole != null)
					{
						_userRoleName = _userRole.UserRoleName;
					}
					else
					{
						_userRoleName = MOD.Data.DefaultValue.String;
					}
				}
				return _userRole;
			}
			set
			{
				if (_userRole != value)
				{
					_userRole = value;
					_isDirty = true;
					// refresh derived properties
					if (_userRole != null)
					{
						_userRoleName = _userRole.UserRoleName;
					}
					else
					{
						_userRoleName = MOD.Data.DefaultValue.String;
					}
				}
			}
		}
		#endregion Properties
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public UserRoleActivity()
		{
			//
			// constructor logic
			//
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method creates an instance with the primary key values.</summary>
		// ------------------------------------------------------------------------------
		public UserRoleActivity(string keyValues, bool isPrimaryKeyValues)
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
		/// <summary>This constructor initializes the UserRoleActivity from its DAL counterpart.</summary>
		// ------------------------------------------------------------------------------
		public UserRoleActivity(DAL.Users.UserRoleActivity businessObject) : base(businessObject)
		{
		}
		// ------------------------------------------------------------------------------
		/// <summary>This constructor initializes the UserRoleActivity from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public UserRoleActivity(int userRoleCode, int activityCode, int accessModeCode)
		{
			UserRoleCode = userRoleCode;
			ActivityCode = activityCode;
			AccessModeCode = accessModeCode;
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the UserRoleActivity with its already set properties.</summary>
		// ------------------------------------------------------------------------------
		public void Load()
		{
			Load(UserRoleCode, ActivityCode, AccessModeCode);
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the UserRoleActivity from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public void Load(int userRoleCode, int activityCode, int accessModeCode)
		{
			BLL.Users.UserRoleActivity businessObject = null;
			businessObject = BLL.Users.UserRoleActivityManager.GetOneUserRoleActivity(userRoleCode, activityCode, accessModeCode);
			if(businessObject != null)
			{
				ReflectionHelper.Copy(businessObject, this, true);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the UserRoleActivity into the database,
		/// performing add/update auto detect and performing a cascade operation if indicated.</summary>
		// ------------------------------------------------------------------------------
		public void Save(bool performCascade)
		{
			if (IsLoaded == false)
			{
				BLL.Users.UserRoleActivityManager.AddOneUserRoleActivity(this, performCascade);
			}
			else
			{
				BLL.Users.UserRoleActivityManager.UpdateOneUserRoleActivity(this, performCascade);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the UserRoleActivity into the database,
		/// performing add/update auto detect and without performing a cascade operation.</summary>
		// ------------------------------------------------------------------------------
		public void Save()
		{
			Save(false);
		}
		/// <summary>
		///	Clears the dirty state of UserRoleActivity and its subcollections.
		/// </summary>
		/// <param name="clearCollectionDirtyState">Flag to clear subcollections.</param>
		/// <returns></returns>
		public override void ClearDirtyState(bool clearCollectionDirtyState)
		{
			// clear base items
			base.ClearDirtyState();
			// clear collections and other items
			if (this._accessMode != null)
			{
				this.AccessMode.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._activity != null)
			{
				this.Activity.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._userRole != null)
			{
				this.UserRole.ClearDirtyState(clearCollectionDirtyState);
			}
		}
		/// <summary>
		///	Tests to see if input object is convertable to UserRoleActivity, and has the same primary key values.
		/// </summary>
		/// <param name="obj">Input object to test.</param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			UserRoleActivity userRoleActivityInstance = obj as UserRoleActivity;
			if (userRoleActivityInstance == null)
				return false;
			else
				return (_userRoleCode == userRoleActivityInstance.UserRoleCode && 
					_activityCode == userRoleActivityInstance.ActivityCode && 
					_accessModeCode == userRoleActivityInstance.AccessModeCode);
		}
		/// <summary>
		///	Returns unique identifying integer		 
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return (_userRoleCode.ToString() + _activityCode.ToString() + _accessModeCode.ToString()).GetHashCode();
		}
		#endregion Methods
	}
}