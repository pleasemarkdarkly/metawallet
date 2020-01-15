

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

namespace MW.MComm.Ganadero.BLL.Core
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to hold and manage information for BaseAttribute instances.</summary>
	///
	/// File History:
	/// <created>10/20/2006 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[Serializable()]
	[DataTransform(Name = "MW.MComm.Ganadero.DAL.Core.BaseAttribute")]
	public partial class BaseAttribute : BusinessObject
	{

		#region Constants
		#endregion Constants

		#region Fields

		// for BaseAttributeID property
		protected Guid _baseAttributeID = MOD.Data.DefaultValue.Guid;

		// for AttributeName property
		protected string _attributeName = MOD.Data.DefaultValue.String;

		// for AttributeTypeCode property
		protected int _attributeTypeCode = MOD.Data.DefaultValue.Int;

		// for DataTypeCode property
		protected int _dataTypeCode = MOD.Data.DefaultValue.Int;

		// for Description property
		protected string _description = null;

		// for IsActive property
		protected bool _isActive = false;

		// for PrimaryName property
		protected string _primaryName = MOD.Data.DefaultValue.String;

		// for PrimaryIndex property
		protected string _primaryIndex = MOD.Data.DefaultValue.String;

		// for PrimarySortColumn property
		protected string _primarySortColumn = MOD.Data.DefaultValue.String;

		// for AttributeTypeName read only property
		[DataTransform]
		protected string _attributeTypeName = MOD.Data.DefaultValue.String;

		// for DataTypeName read only property
		[DataTransform]
		protected string _dataTypeName = MOD.Data.DefaultValue.String;

		// for AttributeType property
		protected BLL.Core.AttributeType _attributeType = null;

		// for DataType property
		protected BLL.Core.DataType _dataType = null;

		#endregion Fields

		#region Properties

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
					_isDirty = true;
				}
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the AttributeName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual string AttributeName
		{
			get
			{
				return _attributeName;
			}
			set
			{
				if ((_attributeName != null && !_attributeName.Equals(value)) || _attributeName != value)
				{
					_attributeName = value;
					_isDirty = true;
				}
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the AttributeTypeCode.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Int)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual int AttributeTypeCode
		{
			get
			{
				return _attributeTypeCode;
			}
			set
			{
				if (_attributeTypeCode != value)
				{
					_attributeTypeCode = value;
					_attributeType = null;

					// reset AttributeType
					BLL.BusinessObject vAttributeType = (BLL.BusinessObject) AttributeType;
					vAttributeType = null;
					_isDirty = true;
				}
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the DataTypeCode.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Int)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual int DataTypeCode
		{
			get
			{
				return _dataTypeCode;
			}
			set
			{
				if (_dataTypeCode != value)
				{
					_dataTypeCode = value;
					_dataType = null;

					// reset DataType
					BLL.BusinessObject vDataType = (BLL.BusinessObject) DataType;
					vDataType = null;
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
				return (MOD.Data.DataHelper.GetString(BaseAttributeID,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					BaseAttributeID = MOD.Data.DataHelper.GetGuid(keyValues[0], MOD.Data.DefaultValue.Guid);
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
					return AttributeTypeName;
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
				return (MOD.Data.DataHelper.GetString(BaseAttributeID,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					BaseAttributeID = MOD.Data.DataHelper.GetGuid(keyValues[0], MOD.Data.DefaultValue.Guid);
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
					return "AttributeTypeName";
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
		/// <summary>This read only property gets the AttributeTypeName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		public virtual string AttributeTypeName
		{
			get
			{
				return _attributeTypeName;
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This read only property gets the DataTypeName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		public virtual string DataTypeName
		{
			get
			{
				return _dataTypeName;
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of AttributeType.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Core.AttributeType AttributeType
		{
			get
			{
				if (_attributeType == null  && IsLoaded == true)
				{
					_attributeType = BLL.Core.AttributeTypeManager.GetOneAttributeType((int)AttributeTypeCode);
					if (_attributeType != null)
					{
						// refresh derived properties
						_attributeTypeName = _attributeType.AttributeTypeName;
					}
				}

				return _attributeType;
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of DataType.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Core.DataType DataType
		{
			get
			{
				if (_dataType == null  && IsLoaded == true)
				{
					_dataType = BLL.Core.DataTypeManager.GetOneDataType((int)DataTypeCode);
					if (_dataType != null)
					{
						// refresh derived properties
						_dataTypeName = _dataType.DataTypeName;
					}
				}

				return _dataType;
			}
		}

		#endregion Properties

		#region Constructors

		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public BaseAttribute()
		{
			//
			// constructor logic
			//
		}

		// ------------------------------------------------------------------------------
		/// <summary>This method creates an instance with the primary key values.</summary>
		// ------------------------------------------------------------------------------
		public BaseAttribute(string keyValues, bool isPrimaryKeyValues)
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
		/// <summary>This constructor initializes the BaseAttribute from its DAL counterpart.</summary>
		// ------------------------------------------------------------------------------
		public BaseAttribute(DAL.Core.BaseAttribute businessObject) : base(businessObject)
		{
		}

		// ------------------------------------------------------------------------------
		/// <summary>This constructor initializes the BaseAttribute from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public BaseAttribute(Guid baseAttributeID)
		{
			Load(baseAttributeID);
		}

		#endregion Constructors

		#region Methods

		// ------------------------------------------------------------------------------
		/// <summary>This method loads the BaseAttribute with its already set properties.</summary>
		// ------------------------------------------------------------------------------
		public void Load()
		{
			Load(BaseAttributeID);
		}

		// ------------------------------------------------------------------------------
		/// <summary>This method loads the BaseAttribute from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public void Load(Guid baseAttributeID)
		{
			BLL.Core.BaseAttribute businessObject = BLL.Core.BaseAttributeManager.Load(baseAttributeID);
			if(businessObject != null)
			{
				ReflectionHelper.Copy(businessObject, this, true);
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This method saves the BaseAttribute into the database,
		/// performing add/update auto detect and performing a cascade operation if indicated.</summary>
		// ------------------------------------------------------------------------------
		public void Save(bool performCascade)
		{
			if (IsLoaded == false)
			{
				BLL.Core.BaseAttributeManager.UpsertOneBaseAttribute(this, performCascade);
			}
			else
			{
				BLL.Core.BaseAttributeManager.UpsertOneBaseAttribute(this, performCascade);
			}
			string key = BLL.Core.BaseAttribute.GetCacheKey(typeof(BLL.Core.BaseAttribute), "PrimaryKey", PrimaryKey);
			Utility.CacheManager.Cache.Add(key, this);
		}

		// ------------------------------------------------------------------------------
		/// <summary>This method saves the BaseAttribute into the database,
		/// performing add/update auto detect and without performing a cascade operation.</summary>
		// ------------------------------------------------------------------------------
		public void Save()
		{
			Save(false);
		}

		/// <summary>
		///	Clears the dirty state of BaseAttribute and its subcollections.
		/// </summary>
		/// <param name="clearCollectionDirtyState">Flag to clear subcollections.</param>
		/// <returns></returns>
		public override void ClearDirtyState(bool clearCollectionDirtyState)
		{
			// clear base items
			base.ClearDirtyState();

			// clear collections and other items
			if (this._attributeType != null)
			{
				this.AttributeType.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._dataType != null)
			{
				this.DataType.ClearDirtyState(clearCollectionDirtyState);
			}
		}


		/// <summary>
		///	Tests to see if input object is convertable to BaseAttribute, and has the same primary key values.
		/// </summary>
		/// <param name="obj">Input object to test.</param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			BaseAttribute baseAttributeInstance = obj as BaseAttribute;

			if (baseAttributeInstance == null)
				return false;
			else
				return (_baseAttributeID == baseAttributeInstance.BaseAttributeID);
		}


		/// <summary>
		///	Returns unique identifying integer		 
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return (_baseAttributeID.ToString()).GetHashCode();
		}
		#endregion Methods
	}
}