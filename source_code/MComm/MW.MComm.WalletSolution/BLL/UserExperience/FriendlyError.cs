
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
	/// <summary>This class is used to hold and manage information for FriendlyError instances.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[Serializable()]
	[DataTransform(Name = "MW.MComm.WalletSolution.DAL.UserExperience.FriendlyError")]
	public partial class FriendlyError : PersistedBusinessObject
	{
		#region Constants
		#endregion Constants
		#region Fields
		// for ErrorNumber property
		protected int _errorNumber = MOD.Data.DefaultValue.Int;
		// for LocaleCode property
		protected int _localeCode = MOD.Data.DefaultValue.Int;
		// for FriendlyErrorMessage property
		protected string _friendlyErrorMessage = MOD.Data.DefaultValue.String;
		// for ErrorTitle read only property
		[DataTransform]
		protected string _errorTitle = MOD.Data.DefaultValue.String;
		// for LocaleName read only property
		[DataTransform]
		protected string _localeName = MOD.Data.DefaultValue.String;
		// for Error property
		protected BLL.Core.Error _error = null;
		// for Locale property
		protected BLL.Environments.Locale _locale = null;
		#endregion Fields
		#region Properties
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the ErrorNumber.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Int)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual int ErrorNumber
		{
			get
			{
				return _errorNumber;
			}
			set
			{
				if (_errorNumber != value)
				{
					_errorNumber = value;
					_error = null;
					// reset Error
					BLL.PersistedBusinessObject vError = (BLL.PersistedBusinessObject) Error;
					vError = null;
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
		/// <summary>This property gets or sets the FriendlyErrorMessage.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual string FriendlyErrorMessage
		{
			get
			{
				return _friendlyErrorMessage;
			}
			set
			{
				if ((_friendlyErrorMessage != null && !_friendlyErrorMessage.Equals(value)) || _friendlyErrorMessage != value)
				{
					_friendlyErrorMessage = value;
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
				return (MOD.Data.DataHelper.GetString(ErrorNumber,"") + ", " + MOD.Data.DataHelper.GetString(LocaleCode,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					ErrorNumber = MOD.Data.DataHelper.GetInt(keyValues[0], MOD.Data.DefaultValue.Int);
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
					return LocaleName;
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
				return (MOD.Data.DataHelper.GetString(ErrorNumber,"") + ", " + MOD.Data.DataHelper.GetString(LocaleCode,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					ErrorNumber = MOD.Data.DataHelper.GetInt(keyValues[0], MOD.Data.DefaultValue.Int);
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
					return "LocaleName";
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
		/// <summary>This read only property gets the ErrorTitle.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		public virtual string ErrorTitle
		{
			get
			{
				return _errorTitle;
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
		/// <summary>This property gets or sets an item of Error.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Core.Error Error
		{
			get
			{
				if (_error == null  && IsLazyLoadable == true)
				{
					_error = BLL.Core.ErrorManager.GetOneError((int)ErrorNumber);
					// refresh derived properties
					if (_error != null)
					{
						_errorTitle = _error.ErrorTitle;
					}
					else
					{
						_errorTitle = MOD.Data.DefaultValue.String;
					}
				}
				return _error;
			}
			set
			{
				if (_error != value)
				{
					_error = value;
					_isDirty = true;
					// refresh derived properties
					if (_error != null)
					{
						_errorTitle = _error.ErrorTitle;
					}
					else
					{
						_errorTitle = MOD.Data.DefaultValue.String;
					}
				}
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
		#endregion Properties
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public FriendlyError()
		{
			//
			// constructor logic
			//
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method creates an instance with the primary key values.</summary>
		// ------------------------------------------------------------------------------
		public FriendlyError(string keyValues, bool isPrimaryKeyValues)
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
		/// <summary>This constructor initializes the FriendlyError from its DAL counterpart.</summary>
		// ------------------------------------------------------------------------------
		public FriendlyError(DAL.UserExperience.FriendlyError businessObject) : base(businessObject)
		{
		}
		// ------------------------------------------------------------------------------
		/// <summary>This constructor initializes the FriendlyError from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public FriendlyError(int errorNumber, int localeCode)
		{
			ErrorNumber = errorNumber;
			LocaleCode = localeCode;
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the FriendlyError with its already set properties.</summary>
		// ------------------------------------------------------------------------------
		public void Load()
		{
			Load(ErrorNumber, LocaleCode);
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the FriendlyError from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public void Load(int errorNumber, int localeCode)
		{
			BLL.UserExperience.FriendlyError businessObject = null;
			businessObject = BLL.UserExperience.FriendlyErrorManager.GetOneFriendlyError(errorNumber, localeCode);
			if(businessObject != null)
			{
				ReflectionHelper.Copy(businessObject, this, true);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the FriendlyError into the database,
		/// performing add/update auto detect and performing a cascade operation if indicated.</summary>
		// ------------------------------------------------------------------------------
		public void Save(bool performCascade)
		{
			if (IsLoaded == false)
			{
				BLL.UserExperience.FriendlyErrorManager.AddOneFriendlyError(this, performCascade);
			}
			else
			{
				BLL.UserExperience.FriendlyErrorManager.UpdateOneFriendlyError(this, performCascade);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the FriendlyError into the database,
		/// performing add/update auto detect and without performing a cascade operation.</summary>
		// ------------------------------------------------------------------------------
		public void Save()
		{
			Save(false);
		}
		/// <summary>
		///	Clears the dirty state of FriendlyError and its subcollections.
		/// </summary>
		/// <param name="clearCollectionDirtyState">Flag to clear subcollections.</param>
		/// <returns></returns>
		public override void ClearDirtyState(bool clearCollectionDirtyState)
		{
			// clear base items
			base.ClearDirtyState();
			// clear collections and other items
			if (this._error != null)
			{
				this.Error.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._locale != null)
			{
				this.Locale.ClearDirtyState(clearCollectionDirtyState);
			}
		}
		/// <summary>
		///	Tests to see if input object is convertable to FriendlyError, and has the same primary key values.
		/// </summary>
		/// <param name="obj">Input object to test.</param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			FriendlyError friendlyErrorInstance = obj as FriendlyError;
			if (friendlyErrorInstance == null)
				return false;
			else
				return (_errorNumber == friendlyErrorInstance.ErrorNumber && 
					_localeCode == friendlyErrorInstance.LocaleCode);
		}
		/// <summary>
		///	Returns unique identifying integer		 
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return (_errorNumber.ToString() + _localeCode.ToString()).GetHashCode();
		}
		#endregion Methods
	}
}