

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
using MW.MComm.CarrierSim.BLL.Config;
using BLL = MW.MComm.CarrierSim.BLL;
using DAL = MW.MComm.CarrierSim.DAL;
using Utility = MW.MComm.CarrierSim.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace MW.MComm.CarrierSim.BLL.Core
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to hold and manage information for DebugAttribute instances.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[Serializable()]
	[DataTransform(Name = "MW.MComm.CarrierSim.DAL.Core.DebugAttribute")]
	public partial class DebugAttribute : BLL.Core.BaseAttribute
	{

		#region Constants
		#endregion Constants

		#region Fields

		// for AttributeCode property
		protected int _attributeCode = MOD.Data.DefaultValue.Int;

		#endregion Fields

		#region Properties

		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the AttributeCode.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Int)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual int AttributeCode
		{
			get
			{
				return _attributeCode;
			}
			set
			{
				if (_attributeCode != value)
				{
					_attributeCode = value;
					_isDirty = true;
				}
			}
		}

		#endregion Properties

		#region Constructors

		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public DebugAttribute()
		{
			//
			// constructor logic
			//
		}

		// ------------------------------------------------------------------------------
		/// <summary>This method creates an instance with the primary key values.</summary>
		// ------------------------------------------------------------------------------
		public DebugAttribute(string keyValues, bool isPrimaryKeyValues)
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
		/// <summary>This constructor initializes the DebugAttribute from its DAL counterpart.</summary>
		// ------------------------------------------------------------------------------
		public DebugAttribute(DAL.Core.DebugAttribute businessObject) : base(businessObject)
		{
		}

		// ------------------------------------------------------------------------------
		/// <summary>This constructor initializes the DebugAttribute from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public DebugAttribute(Guid baseAttributeID)
		{
			BaseAttributeID = baseAttributeID;
		}

		#endregion Constructors

		#region Methods

		// ------------------------------------------------------------------------------
		/// <summary>This method loads the DebugAttribute with its already set properties.</summary>
		// ------------------------------------------------------------------------------
		public new void Load()
		{
			Load(BaseAttributeID);
		}

		// ------------------------------------------------------------------------------
		/// <summary>This method loads the DebugAttribute from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public new void Load(Guid baseAttributeID)
		{
			BLL.Core.DebugAttribute businessObject = null;
			businessObject = BLL.Core.DebugAttributeManager.GetOneDebugAttribute(baseAttributeID);
			if(businessObject != null)
			{
				ReflectionHelper.Copy(businessObject, this, true);
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This method saves the DebugAttribute into the database,
		/// performing add/update auto detect and performing a cascade operation if indicated.</summary>
		// ------------------------------------------------------------------------------
		public new void Save(bool performCascade)
		{
			if (IsLoaded == false)
			{
				BLL.Core.DebugAttributeManager.AddOneDebugAttribute(this, performCascade);
			}
			else
			{
				BLL.Core.DebugAttributeManager.UpdateOneDebugAttribute(this, performCascade);
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This method saves the DebugAttribute into the database,
		/// performing add/update auto detect and without performing a cascade operation.</summary>
		// ------------------------------------------------------------------------------
		public new void Save()
		{
			Save(false);
		}

		/// <summary>
		///	Clears the dirty state of DebugAttribute and its subcollections.
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
		///	Tests to see if input object is convertable to DebugAttribute, and has the same primary key values.
		/// </summary>
		/// <param name="obj">Input object to test.</param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			DebugAttribute debugAttributeInstance = obj as DebugAttribute;

			if (debugAttributeInstance == null)
				return false;
			else
				return (_baseAttributeID == debugAttributeInstance.BaseAttributeID);
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