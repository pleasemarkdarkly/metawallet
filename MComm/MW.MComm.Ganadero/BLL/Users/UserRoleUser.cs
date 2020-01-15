

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
	/// <summary>This class is used to hold and manage information for UserRoleUser instances.</summary>
	///
	/// File History:
	/// <created>10/20/2006 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[Serializable()]
	[DataTransform(Name = "MW.MComm.Ganadero.DAL.Users.UserRoleUser")]
	public partial class UserRoleUser : BusinessObject
	{

		#region Constants
		#endregion Constants

		#region Fields

		// for UserRoleCode property
		protected int _userRoleCode = MOD.Data.DefaultValue.Int;

		// for UserID property
		protected Guid _userID = MOD.Data.DefaultValue.Guid;

		// for PrimaryName property
		protected string _primaryName = MOD.Data.DefaultValue.String;

		// for PrimaryIndex property
		protected string _primaryIndex = MOD.Data.DefaultValue.String;

		// for PrimarySortColumn property
		protected string _primarySortColumn = MOD.Data.DefaultValue.String;

		// for UserRoleName read only property
		[DataTransform]
		protected string _userRoleName = MOD.Data.DefaultValue.String;

		// for UserName read only property
		[DataTransform]
		protected string _userName = null;

		// for FirstName read only property
		[DataTransform]
		protected string _firstName = null;

		// for LastName read only property
		[DataTransform]
		protected string _lastName = null;

		// for User property
		protected BLL.Users.User _user = null;

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
					BLL.BusinessObject vUserRole = (BLL.BusinessObject) UserRole;
					vUserRole = null;
					_isDirty = true;
				}
			}
		}

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
					_user = null;

					// reset User
					BLL.BusinessObject vUser = (BLL.BusinessObject) User;
					vUser = null;
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
				return (MOD.Data.DataHelper.GetString(UserRoleCode,"") + ", " + MOD.Data.DataHelper.GetString(UserID,""));
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
					UserID = MOD.Data.DataHelper.GetGuid(keyValues[1], MOD.Data.DefaultValue.Guid);
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
				return (MOD.Data.DataHelper.GetString(UserRoleCode,"") + ", " + MOD.Data.DataHelper.GetString(UserID,""));
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
					UserID = MOD.Data.DataHelper.GetGuid(keyValues[1], MOD.Data.DefaultValue.Guid);
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
		/// <summary>This read only property gets the UserName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(null)]
		[XmlElementAttribute(IsNullable=true)]
		public virtual string UserName
		{
			get
			{
				return _userName;
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This read only property gets the FirstName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(null)]
		[XmlElementAttribute(IsNullable=true)]
		public virtual string FirstName
		{
			get
			{
				return _firstName;
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This read only property gets the LastName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(null)]
		[XmlElementAttribute(IsNullable=true)]
		public virtual string LastName
		{
			get
			{
				return _lastName;
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of User.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Users.User User
		{
			get
			{
				if (_user == null  && IsLoaded == true)
				{
					_user = BLL.Users.UserManager.GetOneUser((Guid)UserID);
					if (_user != null)
					{
						// refresh derived properties
						_userName = _user.UserName;
						_firstName = _user.FirstName;
						_lastName = _user.LastName;
					}
				}

				return _user;
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
				if (_userRole == null  && IsLoaded == true)
				{
					_userRole = BLL.Users.UserRoleManager.GetOneUserRole((int)UserRoleCode);
					if (_userRole != null)
					{
						// refresh derived properties
						_userRoleName = _userRole.UserRoleName;
					}
				}

				return _userRole;
			}
		}

		#endregion Properties

		#region Constructors

		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public UserRoleUser()
		{
			//
			// constructor logic
			//
		}

		// ------------------------------------------------------------------------------
		/// <summary>This method creates an instance with the primary key values.</summary>
		// ------------------------------------------------------------------------------
		public UserRoleUser(string keyValues, bool isPrimaryKeyValues)
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
		/// <summary>This constructor initializes the UserRoleUser from its DAL counterpart.</summary>
		// ------------------------------------------------------------------------------
		public UserRoleUser(DAL.Users.UserRoleUser businessObject) : base(businessObject)
		{
		}

		// ------------------------------------------------------------------------------
		/// <summary>This constructor initializes the UserRoleUser from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public UserRoleUser(int userRoleCode, Guid userID)
		{
			Load(userRoleCode, userID);
		}

		#endregion Constructors

		#region Methods

		// ------------------------------------------------------------------------------
		/// <summary>This method loads the UserRoleUser with its already set properties.</summary>
		// ------------------------------------------------------------------------------
		public void Load()
		{
			Load(UserRoleCode, UserID);
		}

		// ------------------------------------------------------------------------------
		/// <summary>This method loads the UserRoleUser from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public void Load(int userRoleCode, Guid userID)
		{
			BLL.Users.UserRoleUser businessObject = BLL.Users.UserRoleUserManager.Load(userRoleCode, userID);
			if(businessObject != null)
			{
				ReflectionHelper.Copy(businessObject, this, true);
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This method saves the UserRoleUser into the database,
		/// performing add/update auto detect and performing a cascade operation if indicated.</summary>
		// ------------------------------------------------------------------------------
		public void Save(bool performCascade)
		{
			if (IsLoaded == false)
			{
				BLL.Users.UserRoleUserManager.AddOneUserRoleUser(this, performCascade);
			}
			else
			{
				BLL.Users.UserRoleUserManager.UpdateOneUserRoleUser(this, performCascade);
			}
			string key = BLL.Users.UserRoleUser.GetCacheKey(typeof(BLL.Users.UserRoleUser), "PrimaryKey", PrimaryKey);
			Utility.CacheManager.Cache.Add(key, this);
		}

		// ------------------------------------------------------------------------------
		/// <summary>This method saves the UserRoleUser into the database,
		/// performing add/update auto detect and without performing a cascade operation.</summary>
		// ------------------------------------------------------------------------------
		public void Save()
		{
			Save(false);
		}

		/// <summary>
		///	Clears the dirty state of UserRoleUser and its subcollections.
		/// </summary>
		/// <param name="clearCollectionDirtyState">Flag to clear subcollections.</param>
		/// <returns></returns>
		public override void ClearDirtyState(bool clearCollectionDirtyState)
		{
			// clear base items
			base.ClearDirtyState();

			// clear collections and other items
			if (this._user != null)
			{
				this.User.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._userRole != null)
			{
				this.UserRole.ClearDirtyState(clearCollectionDirtyState);
			}
		}


		/// <summary>
		///	Tests to see if input object is convertable to UserRoleUser, and has the same primary key values.
		/// </summary>
		/// <param name="obj">Input object to test.</param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			UserRoleUser userRoleUserInstance = obj as UserRoleUser;

			if (userRoleUserInstance == null)
				return false;
			else
				return (_userRoleCode == userRoleUserInstance.UserRoleCode && 
					_userID == userRoleUserInstance.UserID);
		}


		/// <summary>
		///	Returns unique identifying integer		 
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return (_userRoleCode.ToString() + _userID.ToString()).GetHashCode();
		}
		#endregion Methods
	}
}