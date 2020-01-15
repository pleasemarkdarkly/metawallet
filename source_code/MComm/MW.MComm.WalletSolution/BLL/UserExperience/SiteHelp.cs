
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
	/// <summary>This class is used to hold and manage information for SiteHelp instances.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[Serializable()]
	[DataTransform(Name = "MW.MComm.WalletSolution.DAL.UserExperience.SiteHelp")]
	public partial class SiteHelp : PersistedBusinessObject
	{
		#region Constants
		#endregion Constants
		#region Fields
		// for LocaleCode property
		protected int _localeCode = MOD.Data.DefaultValue.Int;
		// for SiteHelpName property
		protected string _siteHelpName = MOD.Data.DefaultValue.String;
		// for SiteHelpText property
		protected string _siteHelpText = null;
		// for SiteHelpImageURL property
		protected string _siteHelpImageURL = null;
		// for SiteHelpGroupCode property
		protected int _siteHelpGroupCode = MOD.Data.DefaultValue.Int;
		// for SiteHelpDefinitionCode property
		protected int _siteHelpDefinitionCode = MOD.Data.DefaultValue.Int;
		// for SiteHelpDefinitionName read only property
		[DataTransform]
		protected string _siteHelpDefinitionName = MOD.Data.DefaultValue.String;
		// for LocaleName read only property
		[DataTransform]
		protected string _localeName = MOD.Data.DefaultValue.String;
		// for SiteHelpGroupName read only property
		[DataTransform]
		protected string _siteHelpGroupName = null;
		// for SiteHelpGroup property
		protected BLL.UserExperience.SiteHelpGroup _siteHelpGroup = null;
		// for Locale property
		protected BLL.Environments.Locale _locale = null;
		// for SiteHelpDefinition property
		protected BLL.UserExperience.SiteHelpDefinition _siteHelpDefinition = null;
		#endregion Fields
		#region Properties
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
		/// <summary>This property gets or sets the SiteHelpName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual string SiteHelpName
		{
			get
			{
				return _siteHelpName;
			}
			set
			{
				if ((_siteHelpName != null && !_siteHelpName.Equals(value)) || _siteHelpName != value)
				{
					_siteHelpName = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the SiteHelpText.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(null)]
		[XmlElementAttribute(IsNullable=true)]
		[DataTransform]
		public virtual string SiteHelpText
		{
			get
			{
				return _siteHelpText;
			}
			set
			{
				if ((_siteHelpText != null && !_siteHelpText.Equals(value)) || _siteHelpText != value)
				{
					_siteHelpText = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the SiteHelpImageURL.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(null)]
		[XmlElementAttribute(IsNullable=true)]
		[DataTransform]
		public virtual string SiteHelpImageURL
		{
			get
			{
				return _siteHelpImageURL;
			}
			set
			{
				if ((_siteHelpImageURL != null && !_siteHelpImageURL.Equals(value)) || _siteHelpImageURL != value)
				{
					_siteHelpImageURL = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the SiteHelpGroupCode.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Int)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual int SiteHelpGroupCode
		{
			get
			{
				return _siteHelpGroupCode;
			}
			set
			{
				if (_siteHelpGroupCode != value)
				{
					_siteHelpGroupCode = value;
					_siteHelpGroup = null;
					// reset SiteHelpGroup
					BLL.PersistedBusinessObject vSiteHelpGroup = (BLL.PersistedBusinessObject) SiteHelpGroup;
					vSiteHelpGroup = null;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the SiteHelpDefinitionCode.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Int)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual int SiteHelpDefinitionCode
		{
			get
			{
				return _siteHelpDefinitionCode;
			}
			set
			{
				if (_siteHelpDefinitionCode != value)
				{
					_siteHelpDefinitionCode = value;
					_siteHelpDefinition = null;
					// reset SiteHelpDefinition
					BLL.PersistedBusinessObject vSiteHelpDefinition = (BLL.PersistedBusinessObject) SiteHelpDefinition;
					vSiteHelpDefinition = null;
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
				return (MOD.Data.DataHelper.GetString(LocaleCode,"") + ", " + MOD.Data.DataHelper.GetString(SiteHelpDefinitionCode,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					LocaleCode = MOD.Data.DataHelper.GetInt(keyValues[0], MOD.Data.DefaultValue.Int);
				}
				if (keyValues.Length > 1)
				{
					SiteHelpDefinitionCode = MOD.Data.DataHelper.GetInt(keyValues[1], MOD.Data.DefaultValue.Int);
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
					return SiteHelpName;
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
				return (MOD.Data.DataHelper.GetString(SiteHelpDefinitionCode,"") + ", " + MOD.Data.DataHelper.GetString(LocaleCode,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					SiteHelpDefinitionCode = MOD.Data.DataHelper.GetInt(keyValues[0], MOD.Data.DefaultValue.Int);
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
					return "SiteHelpName";
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
		/// <summary>This read only property gets the SiteHelpDefinitionName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		public virtual string SiteHelpDefinitionName
		{
			get
			{
				return _siteHelpDefinitionName;
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
		/// <summary>This read only property gets the SiteHelpGroupName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(null)]
		[XmlElementAttribute(IsNullable=true)]
		public virtual string SiteHelpGroupName
		{
			get
			{
				return _siteHelpGroupName;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of SiteHelpGroup.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.UserExperience.SiteHelpGroup SiteHelpGroup
		{
			get
			{
				if (_siteHelpGroup == null  && IsLazyLoadable == true)
				{
					_siteHelpGroup = BLL.UserExperience.SiteHelpGroupManager.GetOneSiteHelpGroup((int)SiteHelpGroupCode);
					// refresh derived properties
					if (_siteHelpGroup != null)
					{
						_siteHelpGroupName = _siteHelpGroup.SiteHelpGroupName;
					}
					else
					{
						_siteHelpGroupName = MOD.Data.DefaultValue.String;
					}
				}
				return _siteHelpGroup;
			}
			set
			{
				if (_siteHelpGroup != value)
				{
					_siteHelpGroup = value;
					_isDirty = true;
					// refresh derived properties
					if (_siteHelpGroup != null)
					{
						_siteHelpGroupName = _siteHelpGroup.SiteHelpGroupName;
					}
					else
					{
						_siteHelpGroupName = MOD.Data.DefaultValue.String;
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
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of SiteHelpDefinition.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.UserExperience.SiteHelpDefinition SiteHelpDefinition
		{
			get
			{
				if (_siteHelpDefinition == null  && IsLazyLoadable == true)
				{
					_siteHelpDefinition = BLL.UserExperience.SiteHelpDefinitionManager.GetOneSiteHelpDefinition((int)SiteHelpDefinitionCode);
					// refresh derived properties
					if (_siteHelpDefinition != null)
					{
						_siteHelpDefinitionName = _siteHelpDefinition.SiteHelpDefinitionName;
					}
					else
					{
						_siteHelpDefinitionName = MOD.Data.DefaultValue.String;
					}
				}
				return _siteHelpDefinition;
			}
			set
			{
				if (_siteHelpDefinition != value)
				{
					_siteHelpDefinition = value;
					_isDirty = true;
					// refresh derived properties
					if (_siteHelpDefinition != null)
					{
						_siteHelpDefinitionName = _siteHelpDefinition.SiteHelpDefinitionName;
					}
					else
					{
						_siteHelpDefinitionName = MOD.Data.DefaultValue.String;
					}
				}
			}
		}
		#endregion Properties
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public SiteHelp()
		{
			//
			// constructor logic
			//
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method creates an instance with the primary key values.</summary>
		// ------------------------------------------------------------------------------
		public SiteHelp(string keyValues, bool isPrimaryKeyValues)
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
		/// <summary>This constructor initializes the SiteHelp from its DAL counterpart.</summary>
		// ------------------------------------------------------------------------------
		public SiteHelp(DAL.UserExperience.SiteHelp businessObject) : base(businessObject)
		{
		}
		// ------------------------------------------------------------------------------
		/// <summary>This constructor initializes the SiteHelp from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public SiteHelp(int localeCode, int siteHelpDefinitionCode)
		{
			LocaleCode = localeCode;
			SiteHelpDefinitionCode = siteHelpDefinitionCode;
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the SiteHelp with its already set properties.</summary>
		// ------------------------------------------------------------------------------
		public void Load()
		{
			Load(SiteHelpDefinitionCode, LocaleCode);
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the SiteHelp from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public void Load(int siteHelpDefinitionCode, int localeCode)
		{
			BLL.UserExperience.SiteHelp businessObject = null;
			businessObject = BLL.UserExperience.SiteHelpManager.GetOneSiteHelp(siteHelpDefinitionCode, localeCode);
			if(businessObject != null)
			{
				ReflectionHelper.Copy(businessObject, this, true);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the SiteHelp into the database,
		/// performing add/update auto detect and performing a cascade operation if indicated.</summary>
		// ------------------------------------------------------------------------------
		public void Save(bool performCascade)
		{
			if (IsLoaded == false)
			{
				BLL.UserExperience.SiteHelpManager.AddOneSiteHelp(this, performCascade);
			}
			else
			{
				BLL.UserExperience.SiteHelpManager.UpdateOneSiteHelp(this, performCascade);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the SiteHelp into the database,
		/// performing add/update auto detect and without performing a cascade operation.</summary>
		// ------------------------------------------------------------------------------
		public void Save()
		{
			Save(false);
		}
		/// <summary>
		///	Clears the dirty state of SiteHelp and its subcollections.
		/// </summary>
		/// <param name="clearCollectionDirtyState">Flag to clear subcollections.</param>
		/// <returns></returns>
		public override void ClearDirtyState(bool clearCollectionDirtyState)
		{
			// clear base items
			base.ClearDirtyState();
			// clear collections and other items
			if (this._siteHelpGroup != null)
			{
				this.SiteHelpGroup.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._locale != null)
			{
				this.Locale.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._siteHelpDefinition != null)
			{
				this.SiteHelpDefinition.ClearDirtyState(clearCollectionDirtyState);
			}
		}
		/// <summary>
		///	Tests to see if input object is convertable to SiteHelp, and has the same primary key values.
		/// </summary>
		/// <param name="obj">Input object to test.</param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			SiteHelp siteHelpInstance = obj as SiteHelp;
			if (siteHelpInstance == null)
				return false;
			else
				return (_localeCode == siteHelpInstance.LocaleCode && 
					_siteHelpDefinitionCode == siteHelpInstance.SiteHelpDefinitionCode);
		}
		/// <summary>
		///	Returns unique identifying integer		 
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return (_localeCode.ToString() + _siteHelpDefinitionCode.ToString()).GetHashCode();
		}
		#endregion Methods
	}
}