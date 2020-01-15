
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
namespace MW.MComm.WalletSolution.BLL.Promotions
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to hold and manage information for PromotionType instances.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[Serializable()]
	[DataTransform(Name = "MW.MComm.WalletSolution.DAL.Promotions.PromotionType")]
	public partial class PromotionType : PersistedBusinessObject
	{
		#region Constants
		#endregion Constants
		#region Fields
		// for PromotionTypeCode property
		protected int _promotionTypeCode = MOD.Data.DefaultValue.Int;
		// for PromotionTypeName property
		protected string _promotionTypeName = MOD.Data.DefaultValue.String;
		// for Description property
		protected string _description = null;
		// for IsActive property
		protected bool _isActive = false;
		#endregion Fields
		#region Properties
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the PromotionTypeCode.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Int)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual int PromotionTypeCode
		{
			get
			{
				return _promotionTypeCode;
			}
			set
			{
				if (_promotionTypeCode != value)
				{
					_promotionTypeCode = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the PromotionTypeName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual string PromotionTypeName
		{
			get
			{
				return _promotionTypeName;
			}
			set
			{
				if ((_promotionTypeName != null && !_promotionTypeName.Equals(value)) || _promotionTypeName != value)
				{
					_promotionTypeName = value;
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
				return (MOD.Data.DataHelper.GetString(PromotionTypeCode,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					PromotionTypeCode = MOD.Data.DataHelper.GetInt(keyValues[0], MOD.Data.DefaultValue.Int);
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
					return PromotionTypeName;
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
				return (MOD.Data.DataHelper.GetString(PromotionTypeCode,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					PromotionTypeCode = MOD.Data.DataHelper.GetInt(keyValues[0], MOD.Data.DefaultValue.Int);
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
					return "PromotionTypeName";
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
		public PromotionType()
		{
			//
			// constructor logic
			//
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method creates an instance with the primary key values.</summary>
		// ------------------------------------------------------------------------------
		public PromotionType(string keyValues, bool isPrimaryKeyValues)
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
		/// <summary>This constructor initializes the PromotionType from its DAL counterpart.</summary>
		// ------------------------------------------------------------------------------
		public PromotionType(DAL.Promotions.PromotionType businessObject) : base(businessObject)
		{
		}
		// ------------------------------------------------------------------------------
		/// <summary>This constructor initializes the PromotionType from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public PromotionType(int promotionTypeCode)
		{
			PromotionTypeCode = promotionTypeCode;
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the PromotionType with its already set properties.</summary>
		// ------------------------------------------------------------------------------
		public void Load()
		{
			Load(PromotionTypeCode);
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the PromotionType from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public void Load(int promotionTypeCode)
		{
			BLL.Promotions.PromotionType businessObject = null;
			businessObject = BLL.Promotions.PromotionTypeManager.GetOnePromotionType(promotionTypeCode);
			if(businessObject != null)
			{
				ReflectionHelper.Copy(businessObject, this, true);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the PromotionType into the database,
		/// performing add/update auto detect and performing a cascade operation if indicated.</summary>
		// ------------------------------------------------------------------------------
		public void Save(bool performCascade)
		{
			if (IsLoaded == false)
			{
				BLL.Promotions.PromotionTypeManager.AddOnePromotionType(this, performCascade);
			}
			else
			{
				BLL.Promotions.PromotionTypeManager.UpdateOnePromotionType(this, performCascade);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the PromotionType into the database,
		/// performing add/update auto detect and without performing a cascade operation.</summary>
		// ------------------------------------------------------------------------------
		public void Save()
		{
			Save(false);
		}
		/// <summary>
		///	Clears the dirty state of PromotionType and its subcollections.
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
		///	Tests to see if input object is convertable to PromotionType, and has the same primary key values.
		/// </summary>
		/// <param name="obj">Input object to test.</param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			PromotionType promotionTypeInstance = obj as PromotionType;
			if (promotionTypeInstance == null)
				return false;
			else
				return (_promotionTypeCode == promotionTypeInstance.PromotionTypeCode);
		}
		/// <summary>
		///	Returns unique identifying integer		 
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return (_promotionTypeCode.ToString()).GetHashCode();
		}
		#endregion Methods
	}
}