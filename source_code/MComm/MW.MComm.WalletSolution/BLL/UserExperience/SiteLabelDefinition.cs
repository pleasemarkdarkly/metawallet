
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
	/// <summary>This class is used to hold and manage information for SiteLabelDefinition instances.</summary>
	///
	/// File History:
	/// <created>2/16/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[Serializable()]
	[DataTransform(Name = "MW.MComm.WalletSolution.DAL.UserExperience.SiteLabelDefinition")]
	public partial class SiteLabelDefinition : PersistedBusinessObject
	{
		#region Constants
		#endregion Constants
		#region Fields
		// for SiteLabelDefinitionCode property
		protected int _siteLabelDefinitionCode = MOD.Data.DefaultValue.Int;
		// for SiteLabelDefinitionName property
		protected string _siteLabelDefinitionName = MOD.Data.DefaultValue.String;
		// for DefaultText property
		protected string _defaultText = MOD.Data.DefaultValue.String;
		// for Description property
		protected string _description = null;
		// for IsActive property
		protected bool _isActive = false;
		#endregion Fields
		#region Properties
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
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the SiteLabelDefinitionName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual string SiteLabelDefinitionName
		{
			get
			{
				return _siteLabelDefinitionName;
			}
			set
			{
				if ((_siteLabelDefinitionName != null && !_siteLabelDefinitionName.Equals(value)) || _siteLabelDefinitionName != value)
				{
					_siteLabelDefinitionName = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the DefaultText.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual string DefaultText
		{
			get
			{
				return _defaultText;
			}
			set
			{
				if ((_defaultText != null && !_defaultText.Equals(value)) || _defaultText != value)
				{
					_defaultText = value;
					_isDirty = true;
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
				return (MOD.Data.DataHelper.GetString(SiteLabelDefinitionCode,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					SiteLabelDefinitionCode = MOD.Data.DataHelper.GetInt(keyValues[0], MOD.Data.DefaultValue.Int);
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
					return SiteLabelDefinitionName;
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
				return (MOD.Data.DataHelper.GetString(SiteLabelDefinitionCode,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					SiteLabelDefinitionCode = MOD.Data.DataHelper.GetInt(keyValues[0], MOD.Data.DefaultValue.Int);
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
					return "SiteLabelDefinitionName";
				}
			}
			set
			{
				_primarySortColumn = value;
			}
		}
		#endregion Properties
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public SiteLabelDefinition()
		{
			//
			// constructor logic
			//
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method creates an instance with the primary key values.</summary>
		// ------------------------------------------------------------------------------
		public SiteLabelDefinition(string keyValues, bool isPrimaryKeyValues)
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
		/// <summary>This constructor initializes the SiteLabelDefinition from its DAL counterpart.</summary>
		// ------------------------------------------------------------------------------
		public SiteLabelDefinition(DAL.UserExperience.SiteLabelDefinition businessObject) : base(businessObject)
		{
		}
		// ------------------------------------------------------------------------------
		/// <summary>This constructor initializes the SiteLabelDefinition from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public SiteLabelDefinition(int siteLabelDefinitionCode)
		{
			SiteLabelDefinitionCode = siteLabelDefinitionCode;
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the SiteLabelDefinition with its already set properties.</summary>
		// ------------------------------------------------------------------------------
		public void Load()
		{
			Load(SiteLabelDefinitionCode);
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the SiteLabelDefinition from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public void Load(int siteLabelDefinitionCode)
		{
			BLL.UserExperience.SiteLabelDefinition businessObject = null;
			businessObject = BLL.UserExperience.SiteLabelDefinitionManager.GetOneSiteLabelDefinition(siteLabelDefinitionCode);
			if(businessObject != null)
			{
				ReflectionHelper.Copy(businessObject, this, true);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the SiteLabelDefinition into the database,
		/// performing add/update auto detect and performing a cascade operation if indicated.</summary>
		// ------------------------------------------------------------------------------
		public void Save(bool performCascade)
		{
			if (IsLoaded == false)
			{
				BLL.UserExperience.SiteLabelDefinitionManager.AddOneSiteLabelDefinition(this, performCascade);
			}
			else
			{
				BLL.UserExperience.SiteLabelDefinitionManager.UpdateOneSiteLabelDefinition(this, performCascade);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the SiteLabelDefinition into the database,
		/// performing add/update auto detect and without performing a cascade operation.</summary>
		// ------------------------------------------------------------------------------
		public void Save()
		{
			Save(false);
		}
		/// <summary>
		///	Clears the dirty state of SiteLabelDefinition and its subcollections.
		/// </summary>
		/// <param name="clearCollectionDirtyState">Flag to clear subcollections.</param>
		/// <returns></returns>
		public override void ClearDirtyState(bool clearCollectionDirtyState)
		{
			// clear base items
			base.ClearDirtyState();
			// clear collections and other items
		}
		/// <summary>
		///	Tests to see if input object is convertable to SiteLabelDefinition, and has the same primary key values.
		/// </summary>
		/// <param name="obj">Input object to test.</param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			SiteLabelDefinition siteLabelDefinitionInstance = obj as SiteLabelDefinition;
			if (siteLabelDefinitionInstance == null)
				return false;
			else
				return (_siteLabelDefinitionCode == siteLabelDefinitionInstance.SiteLabelDefinitionCode);
		}
		/// <summary>
		///	Returns unique identifying integer		 
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return (_siteLabelDefinitionCode.ToString()).GetHashCode();
		}
		#endregion Methods
	}
}