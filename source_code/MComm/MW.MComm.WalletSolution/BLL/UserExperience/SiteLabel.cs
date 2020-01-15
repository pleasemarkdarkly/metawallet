
/*<copyright>
Meta Wallet, Inc (c) 2007 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2007, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
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
	/// <summary>This class is used to hold and manage information for SiteLabel instances.</summary>
	///
	/// File History:
	/// <created>5/8/2007 (Chris Grundy)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[Serializable()]
	[XmlType(Namespace = "http://modsystems.com/MW.MComm.WalletSolution/UserExperience/DataTypes")]
	[DataTransform(Name = "MW.MComm.WalletSolution.DAL.UserExperience.SiteLabel")]
	public partial class SiteLabel : PersistedBusinessObject
	{
		#region Constants
		#endregion Constants
		#region Fields
		// for LocaleCode property
		protected int _localeCode = 2;
		// for Title property
		protected string _title = "''";
		// for DisplayText property
		protected string _displayText = "''";
		// for TargetLocation property
		protected string _targetLocation = "''";
		// for FileURL property
		protected string _fileURL = "''";
		// for Description property
		protected string _description = "''";
		// for SiteLabelDefinitionCode property
		protected int _siteLabelDefinitionCode = MOD.Data.DefaultValue.Int;
		// for LocaleName read only property
		[DataTransform]
		protected string _localeName = MOD.Data.DefaultValue.String;
		// for SiteLabelDefinitionName read only property
		[DataTransform]
		protected string _siteLabelDefinitionName = MOD.Data.DefaultValue.String;
		// for Locale property
		protected BLL.Environments.Locale _locale = null;
		// for SiteLabelDefinition property
		protected BLL.UserExperience.SiteLabelDefinition _siteLabelDefinition = null;
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
		/// <summary>This property gets or sets the Title.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual string Title
		{
			get
			{
				return _title;
			}
			set
			{
				if ((_title != null && !_title.Equals(value)) || _title != value)
				{
					_title = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the DisplayText.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(null)]
		[XmlElementAttribute(IsNullable=true)]
		[DataTransform]
		public virtual string DisplayText
		{
			get
			{
				return _displayText;
			}
			set
			{
				if ((_displayText != null && !_displayText.Equals(value)) || _displayText != value)
				{
					_displayText = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the TargetLocation.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(null)]
		[XmlElementAttribute(IsNullable=true)]
		[DataTransform]
		public virtual string TargetLocation
		{
			get
			{
				return _targetLocation;
			}
			set
			{
				if ((_targetLocation != null && !_targetLocation.Equals(value)) || _targetLocation != value)
				{
					_targetLocation = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the FileURL.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual string FileURL
		{
			get
			{
				return _fileURL;
			}
			set
			{
				if ((_fileURL != null && !_fileURL.Equals(value)) || _fileURL != value)
				{
					_fileURL = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets the absolute http url of FileURL.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		public virtual string AbsoluteHttpFileURL
		{
			get
			{
				if (FileURL != null && FileURL != String.Empty)
				{
				return BLL.Files.FileManager.GetAbsoluteHttpUrl(BLL.Files.FileGroupCode.UserExperience, FileURL);
				}
				return "";
			}
			set
			{
				if (IsSerializing == false)
				{
					//throw (new System.InvalidOperationException("This property cannot be set, this is just for serialization."));
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets the absolute file (unc) path of FileURL.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		public virtual string AbsoluteFilePathFileURL
		{
			get
			{
				if (FileURL != null && FileURL != String.Empty)
				{
				return BLL.Files.FileManager.GetAbsoluteFilePath(BLL.Files.FileGroupCode.UserExperience, FileURL);
				}
				return "";
			}
			set
			{
				if (IsSerializing == false)
				{
					//throw (new System.InvalidOperationException("This property cannot be set, this is just for serialization."));
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the Description.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(null)]
		[XmlElementAttribute(IsNullable=true)]
		[DataTransform]
		public virtual string Description
		{
			get
			{
				return _description;
			}
			set
			{
				if ((_description != null && !_description.Equals(value)) || _description != value)
				{
					_description = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the SiteLabelDefinitionCode.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Int)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual int SiteLabelDefinitionCode
		{
			get
			{
				return _siteLabelDefinitionCode;
			}
			set
			{
				if (_siteLabelDefinitionCode != value)
				{
					_siteLabelDefinitionCode = value;
					_siteLabelDefinition = null;
					// reset SiteLabelDefinition
					BLL.PersistedBusinessObject vSiteLabelDefinition = (BLL.PersistedBusinessObject) SiteLabelDefinition;
					vSiteLabelDefinition = null;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the primary key.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlIgnore]
		public string PrimaryKey
		{
			get
			{
				return (MOD.Data.DataHelper.GetString(LocaleCode,"") + ", " + MOD.Data.DataHelper.GetString(SiteLabelDefinitionCode,""));
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
					SiteLabelDefinitionCode = MOD.Data.DataHelper.GetInt(keyValues[1], MOD.Data.DefaultValue.Int);
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the primary name.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlIgnore]
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
		[XmlIgnore]
		public string PrimaryIndex
		{
			get
			{
				return (MOD.Data.DataHelper.GetString(SiteLabelDefinitionCode,"") + ", " + MOD.Data.DataHelper.GetString(LocaleCode,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					SiteLabelDefinitionCode = MOD.Data.DataHelper.GetInt(keyValues[0], MOD.Data.DefaultValue.Int);
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
		[XmlIgnore]
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
			set
			{
				if (IsSerializing == false)
				{
					//throw (new System.InvalidOperationException("This property cannot be set, this is just for serialization."));
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This read only property gets the SiteLabelDefinitionName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		public virtual string SiteLabelDefinitionName
		{
			get
			{
				return _siteLabelDefinitionName;
			}
			set
			{
				if (IsSerializing == false)
				{
					//throw (new System.InvalidOperationException("This property cannot be set, this is just for serialization."));
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
		/// <summary>This property gets or sets an item of SiteLabelDefinition.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.UserExperience.SiteLabelDefinition SiteLabelDefinition
		{
			get
			{
				if (_siteLabelDefinition == null  && IsLazyLoadable == true)
				{
					_siteLabelDefinition = BLL.UserExperience.SiteLabelDefinitionManager.GetOneSiteLabelDefinition((int)SiteLabelDefinitionCode);
					// refresh derived properties
					if (_siteLabelDefinition != null)
					{
						_siteLabelDefinitionName = _siteLabelDefinition.SiteLabelDefinitionName;
					}
					else
					{
						_siteLabelDefinitionName = MOD.Data.DefaultValue.String;
					}
				}
				return _siteLabelDefinition;
			}
			set
			{
				if (_siteLabelDefinition != value)
				{
					_siteLabelDefinition = value;
					_isDirty = true;
					// refresh derived properties
					if (_siteLabelDefinition != null)
					{
						_siteLabelDefinitionName = _siteLabelDefinition.SiteLabelDefinitionName;
					}
					else
					{
						_siteLabelDefinitionName = MOD.Data.DefaultValue.String;
					}
				}
			}
		}
		#endregion Properties
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public SiteLabel()
		{
			//
			// constructor logic
			//
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method creates an instance with the primary key values.</summary>
		// ------------------------------------------------------------------------------
		public SiteLabel(string keyValues, bool isPrimaryKeyValues)
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
		/// <summary>This constructor initializes the SiteLabel from its DAL counterpart.</summary>
		// ------------------------------------------------------------------------------
		public SiteLabel(DAL.UserExperience.SiteLabel businessObject) : base(businessObject)
		{
		}
		// ------------------------------------------------------------------------------
		/// <summary>This constructor initializes the SiteLabel from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public SiteLabel(int localeCode, int siteLabelDefinitionCode)
		{
			LocaleCode = localeCode;
			SiteLabelDefinitionCode = siteLabelDefinitionCode;
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the SiteLabel with its already set properties.</summary>
		// ------------------------------------------------------------------------------
		public void Load()
		{
			Load(SiteLabelDefinitionCode, LocaleCode);
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the SiteLabel from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public void Load(int siteLabelDefinitionCode, int localeCode)
		{
			BLL.UserExperience.SiteLabel businessObject = null;
			businessObject = BLL.UserExperience.SiteLabelManager.GetOneSiteLabel(siteLabelDefinitionCode, localeCode);
			if(businessObject != null)
			{
				ReflectionHelper.Copy(businessObject, this, true);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the SiteLabel into the database,
		/// performing add/update auto detect and performing a cascade operation if indicated.</summary>
		// ------------------------------------------------------------------------------
		public void Save(bool performCascade)
		{
			if (IsLoaded == false)
			{
				BLL.UserExperience.SiteLabelManager.AddOneSiteLabel(this, performCascade);
			}
			else
			{
				BLL.UserExperience.SiteLabelManager.UpdateOneSiteLabel(this, performCascade);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the SiteLabel into the database,
		/// performing add/update auto detect and without performing a cascade operation.</summary>
		// ------------------------------------------------------------------------------
		public void Save()
		{
			Save(false);
		}
		/// <summary>
		///	Clears the dirty state of SiteLabel and its subcollections.
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
			if (this._siteLabelDefinition != null)
			{
				this.SiteLabelDefinition.ClearDirtyState(clearCollectionDirtyState);
			}
		}
		/// <summary>
		///	Tests to see if input object is convertable to SiteLabel, and has the same primary key values.
		/// </summary>
		/// <param name="obj">Input object to test.</param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			SiteLabel siteLabelInstance = obj as SiteLabel;
			if (siteLabelInstance == null)
				return false;
			else
				return (_localeCode == siteLabelInstance.LocaleCode && 
					_siteLabelDefinitionCode == siteLabelInstance.SiteLabelDefinitionCode);
		}
		/// <summary>
		///	Returns unique identifying integer		 
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return (_localeCode.ToString() + _siteLabelDefinitionCode.ToString()).GetHashCode();
		}
		#endregion Methods
	}
}