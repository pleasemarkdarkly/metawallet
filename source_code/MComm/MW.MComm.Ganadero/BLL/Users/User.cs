

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
using MW.MComm.Ganadero.BLL.Config;
using BLL = MW.MComm.Ganadero.BLL;
using DAL = MW.MComm.Ganadero.DAL;
using Utility = MW.MComm.Ganadero.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace MW.MComm.Ganadero.BLL.Users
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to hold and manage information for User instances.</summary>
	///
	/// File History:
	/// <created>10/20/2006 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[Serializable()]
	[DataTransform(Name = "MW.MComm.Ganadero.DAL.Users.User")]
	public partial class User : BusinessObject
	{

		#region Constants
		#endregion Constants

		#region Fields

		// for UserID property
		protected Guid _userID = MOD.Data.DefaultValue.Guid;

		// for UserName property
		protected string _userName = null;

		// for FirstName property
		protected string _firstName = null;

		// for LastName property
		protected string _lastName = null;

		// for Password property
		protected string _password = null;

		// for LocaleCode property
		protected int? _localeCode = null;

		// for IsActive property
		protected bool _isActive = false;

		// for PrimaryName property
		protected string _primaryName = MOD.Data.DefaultValue.String;

		// for PrimaryIndex property
		protected string _primaryIndex = MOD.Data.DefaultValue.String;

		// for PrimarySortColumn property
		protected string _primarySortColumn = MOD.Data.DefaultValue.String;

		// for UserRoleUserList property
		[XmlArray(ElementName="UserRoleUserList")]
		[XmlArrayItem(typeof(BLL.Users.UserRoleUser), ElementName="UserRoleUser")]
		public BLL.SortableList<BLL.Users.UserRoleUser> _userRoleUserList = null;

		#endregion Fields

		#region Properties

		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the UserID.</summary>
		// ------------------------------------------------------------------------------
		[XmlElementAttribute()]
		[DataTransform]
		public virtual Guid UserID
		{
			get
			{
				return _userID;
			}
			set
			{
				if (_userID != value)
				{
					_userID = value;
					_isDirty = true;
				}
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the UserName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(null)]
		[XmlElementAttribute(IsNullable=true)]
		[DataTransform]
		public virtual string UserName
		{
			get
			{
				return _userName;
			}
			set
			{
				if ((_userName != null && !_userName.Equals(value)) || _userName != value)
				{
					_userName = value;
					_isDirty = true;
				}
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the FirstName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(null)]
		[XmlElementAttribute(IsNullable=true)]
		[DataTransform]
		public virtual string FirstName
		{
			get
			{
				return _firstName;
			}
			set
			{
				if ((_firstName != null && !_firstName.Equals(value)) || _firstName != value)
				{
					_firstName = value;
					_isDirty = true;
				}
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the LastName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(null)]
		[XmlElementAttribute(IsNullable=true)]
		[DataTransform]
		public virtual string LastName
		{
			get
			{
				return _lastName;
			}
			set
			{
				if ((_lastName != null && !_lastName.Equals(value)) || _lastName != value)
				{
					_lastName = value;
					_isDirty = true;
				}
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the Password.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(null)]
		[XmlElementAttribute(IsNullable=true)]
		[DataTransform]
		public virtual string Password
		{
			get
			{
				return _password;
			}
			set
			{
				if ((_password != null && !_password.Equals(value)) || _password != value)
				{
					_password = value;
					_isDirty = true;
				}
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the LocaleCode.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(null)]
		[XmlElementAttribute(IsNullable=true)]
		[DataTransform]
		public virtual int? LocaleCode
		{
			get
			{
				return _localeCode;
			}
			set
			{
				if ((_localeCode != null && !_localeCode.Equals(value)) || _localeCode != value)
				{
					_localeCode = value;
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
				return (MOD.Data.DataHelper.GetString(UserID,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					UserID = MOD.Data.DataHelper.GetGuid(keyValues[0], MOD.Data.DefaultValue.Guid);
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
					return UserName;
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
				return (MOD.Data.DataHelper.GetString(UserID,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					UserID = MOD.Data.DataHelper.GetGuid(keyValues[0], MOD.Data.DefaultValue.Guid);
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
					return "UserName";
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
				return ((_userRoleUserList != null && _userRoleUserList.IsDirty) ||

				base.IsCollectionDirty);
			}
		}



		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets UserRoleUser lists.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.SortableList<BLL.Users.UserRoleUser> UserRoleUserList
		{
			get
			{
				if (_userRoleUserList == null  && IsLoaded == true)
				{
					_userRoleUserList = BLL.Users.UserRoleUserManager.GetAllUserRoleUserDataByUserID(UserID);
				}

				return _userRoleUserList;
			}
			set
			{
				if ((_userRoleUserList == null && value != null) ||
					  !_userRoleUserList.Equals(value))
				{
					_userRoleUserList = value;
					_isDirty = true;
				}
			}
		}

		#endregion Properties

		#region Constructors

		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public User()
		{
			//
			// constructor logic
			//
		}

		// ------------------------------------------------------------------------------
		/// <summary>This method creates an instance with the primary key values.</summary>
		// ------------------------------------------------------------------------------
		public User(string keyValues, bool isPrimaryKeyValues)
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
		/// <summary>This constructor initializes the User from its DAL counterpart.</summary>
		// ------------------------------------------------------------------------------
		public User(DAL.Users.User businessObject) : base(businessObject)
		{
		}

		// ------------------------------------------------------------------------------
		/// <summary>This constructor initializes the User from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public User(Guid userID)
		{
			Load(userID);
		}

		#endregion Constructors

		#region Methods

		// ------------------------------------------------------------------------------
		/// <summary>This method loads the User with its already set properties.</summary>
		// ------------------------------------------------------------------------------
		public void Load()
		{
			Load(UserID);
		}

		// ------------------------------------------------------------------------------
		/// <summary>This method loads the User from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public void Load(Guid userID)
		{
			BLL.Users.User businessObject = BLL.Users.UserManager.Load(userID);
			if(businessObject != null)
			{
				ReflectionHelper.Copy(businessObject, this, true);
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This method saves the User into the database,
		/// performing add/update auto detect and performing a cascade operation if indicated.</summary>
		// ------------------------------------------------------------------------------
		public void Save(bool performCascade)
		{
			if (IsLoaded == false)
			{
				BLL.Users.UserManager.UpsertOneUser(this, performCascade);
			}
			else
			{
				BLL.Users.UserManager.UpsertOneUser(this, performCascade);
			}
			string key = BLL.Users.User.GetCacheKey(typeof(BLL.Users.User), "PrimaryKey", PrimaryKey);
			Utility.CacheManager.Cache.Add(key, this);
		}

		// ------------------------------------------------------------------------------
		/// <summary>This method saves the User into the database,
		/// performing add/update auto detect and without performing a cascade operation.</summary>
		// ------------------------------------------------------------------------------
		public void Save()
		{
			Save(false);
		}

		/// <summary>
		///	Clears the dirty state of User and its subcollections.
		/// </summary>
		/// <param name="clearCollectionDirtyState">Flag to clear subcollections.</param>
		/// <returns></returns>
		public override void ClearDirtyState(bool clearCollectionDirtyState)
		{
			// clear base items
			base.ClearDirtyState();

			// clear collections and other items
			if (this._userRoleUserList != null)
			{
				this.UserRoleUserList.ClearDirtyState(clearCollectionDirtyState);
			}
		}


		/// <summary>
		///	Tests to see if input object is convertable to User, and has the same primary key values.
		/// </summary>
		/// <param name="obj">Input object to test.</param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			User userInstance = obj as User;

			if (userInstance == null)
				return false;
			else
				return (_userID == userInstance.UserID);
		}


		/// <summary>
		///	Returns unique identifying integer		 
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return (_userID.ToString()).GetHashCode();
		}
		#endregion Methods
	}
}