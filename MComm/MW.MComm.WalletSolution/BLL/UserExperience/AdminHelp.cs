
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
namespace MW.MComm.WalletSolution.BLL.UserExperience
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to hold and manage information for AdminHelp instances.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[Serializable()]
	[DataTransform(Name = "MW.MComm.WalletSolution.DAL.UserExperience.AdminHelp")]
	public partial class AdminHelp : PersistedBusinessObject
	{
		#region Constants
		#endregion Constants
		#region Fields
		// for ActivityCode property
		protected int _activityCode = MOD.Data.DefaultValue.Int;
		// for LocaleCode property
		protected int _localeCode = MOD.Data.DefaultValue.Int;
		// for AdminHelpTitle property
		protected string _adminHelpTitle = MOD.Data.DefaultValue.String;
		// for AdminHelpText property
		protected string _adminHelpText = null;
		// for ActivityName read only property
		[DataTransform]
		protected string _activityName = MOD.Data.DefaultValue.String;
		// for LocaleName read only property
		[DataTransform]
		protected string _localeName = MOD.Data.DefaultValue.String;
		// for Locale property
		protected BLL.Environments.Locale _locale = null;
		// for Activity property
		protected BLL.Users.Activity _activity = null;
		#endregion Fields
		#region Properties
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
		/// <summary>This property gets or sets the AdminHelpTitle.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual string AdminHelpTitle
		{
			get
			{
				return _adminHelpTitle;
			}
			set
			{
				if ((_adminHelpTitle != null && !_adminHelpTitle.Equals(value)) || _adminHelpTitle != value)
				{
					_adminHelpTitle = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the AdminHelpText.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(null)]
		[XmlElementAttribute(IsNullable=true)]
		[DataTransform]
		public virtual string AdminHelpText
		{
			get
			{
				return _adminHelpText;
			}
			set
			{
				if ((_adminHelpText != null && !_adminHelpText.Equals(value)) || _adminHelpText != value)
				{
					_adminHelpText = value;
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
				return (MOD.Data.DataHelper.GetString(ActivityCode,"") + ", " + MOD.Data.DataHelper.GetString(LocaleCode,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					ActivityCode = MOD.Data.DataHelper.GetInt(keyValues[0], MOD.Data.DefaultValue.Int);
				}
				if (keyValues.Length > 1)
				{
					LocaleCode = MOD.Data.DataHelper.GetInt(keyValues[1], MOD.Data.DefaultValue.Int);
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
					return ActivityName;
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
				return (MOD.Data.DataHelper.GetString(ActivityCode,"") + ", " + MOD.Data.DataHelper.GetString(LocaleCode,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					ActivityCode = MOD.Data.DataHelper.GetInt(keyValues[0], MOD.Data.DefaultValue.Int);
				}
				if (keyValues.Length > 1)
				{
					LocaleCode = MOD.Data.DataHelper.GetInt(keyValues[1], MOD.Data.DefaultValue.Int);
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
					return "ActivityName";
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
		#endregion Properties
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public AdminHelp()
		{
			//
			// constructor logic
			//
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method creates an instance with the primary key values.</summary>
		// ------------------------------------------------------------------------------
		public AdminHelp(string keyValues, bool isPrimaryKeyValues)
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
		/// <summary>This constructor initializes the AdminHelp from its DAL counterpart.</summary>
		// ------------------------------------------------------------------------------
		public AdminHelp(DAL.UserExperience.AdminHelp businessObject) : base(businessObject)
		{
		}
		// ------------------------------------------------------------------------------
		/// <summary>This constructor initializes the AdminHelp from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public AdminHelp(int activityCode, int localeCode)
		{
			ActivityCode = activityCode;
			LocaleCode = localeCode;
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the AdminHelp with its already set properties.</summary>
		// ------------------------------------------------------------------------------
		public void Load()
		{
			Load(ActivityCode, LocaleCode);
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the AdminHelp from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public void Load(int activityCode, int localeCode)
		{
			BLL.UserExperience.AdminHelp businessObject = null;
			businessObject = BLL.UserExperience.AdminHelpManager.GetOneAdminHelp(activityCode, localeCode);
			if(businessObject != null)
			{
				ReflectionHelper.Copy(businessObject, this, true);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the AdminHelp into the database,
		/// performing add/update auto detect and performing a cascade operation if indicated.</summary>
		// ------------------------------------------------------------------------------
		public void Save(bool performCascade)
		{
			if (IsLoaded == false)
			{
				BLL.UserExperience.AdminHelpManager.AddOneAdminHelp(this, performCascade);
			}
			else
			{
				BLL.UserExperience.AdminHelpManager.UpdateOneAdminHelp(this, performCascade);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the AdminHelp into the database,
		/// performing add/update auto detect and without performing a cascade operation.</summary>
		// ------------------------------------------------------------------------------
		public void Save()
		{
			Save(false);
		}
		/// <summary>
		///	Clears the dirty state of AdminHelp and its subcollections.
		/// </summary>
		/// <param name="clearCollectionDirtyState">Flag to clear subcollections.</param>
		/// <returns></returns>
		public override void ClearDirtyState(bool clearCollectionDirtyState)
		{
			// clear base items
			base.ClearDirtyState();
			// clear collections and other items
			if (this._locale != null)
			{
				this.Locale.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._activity != null)
			{
				this.Activity.ClearDirtyState(clearCollectionDirtyState);
			}
		}
		/// <summary>
		///	Tests to see if input object is convertable to AdminHelp, and has the same primary key values.
		/// </summary>
		/// <param name="obj">Input object to test.</param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			AdminHelp adminHelpInstance = obj as AdminHelp;
			if (adminHelpInstance == null)
				return false;
			else
				return (_activityCode == adminHelpInstance.ActivityCode && 
					_localeCode == adminHelpInstance.LocaleCode);
		}
		/// <summary>
		///	Returns unique identifying integer		 
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return (_activityCode.ToString() + _localeCode.ToString()).GetHashCode();
		}
		#endregion Methods
	}
}