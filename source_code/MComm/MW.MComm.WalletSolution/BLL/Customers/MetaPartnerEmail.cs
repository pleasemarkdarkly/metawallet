
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
namespace MW.MComm.WalletSolution.BLL.Customers
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to hold and manage information for MetaPartnerEmail instances.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[Serializable()]
	[DataTransform(Name = "MW.MComm.WalletSolution.DAL.Customers.MetaPartnerEmail")]
	public partial class MetaPartnerEmail : PersistedBusinessObject
	{
		#region Constants
		#endregion Constants
		#region Fields
		// for MetaPartnerEmailID property
		protected Guid _metaPartnerEmailID = MOD.Data.DefaultValue.Guid;
		// for EmailAddress property
		protected string _emailAddress = MOD.Data.DefaultValue.String;
		// for Password property
		protected string _password = MOD.Data.DefaultValue.String;
		// for MetaPartnerID property
		protected Guid _metaPartnerID = MOD.Data.DefaultValue.Guid;
		// for Rank property
		protected int _rank = 0;
		// for IsActive property
		protected bool _isActive = false;
		// for DisplayName read only property
		[DataTransform]
		protected string _displayName = MOD.Data.DefaultValue.String;
		// for MetaPartnerName read only property
		[DataTransform]
		protected string _metaPartnerName = MOD.Data.DefaultValue.String;
		// for DateFormatCode read only property
		[DataTransform]
		protected int _dateFormatCode = MOD.Data.DefaultValue.Int;
		// for MetaPartner property
		protected BLL.Customers.MetaPartner _metaPartner = null;
		#endregion Fields
		#region Properties
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the MetaPartnerEmailID.</summary>
		// ------------------------------------------------------------------------------
		[XmlElementAttribute()]
		[DataTransform]
		public virtual Guid MetaPartnerEmailID
		{
			get
			{
				return _metaPartnerEmailID;
			}
			set
			{
				if (_metaPartnerEmailID != value)
				{
					_metaPartnerEmailID = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the EmailAddress.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual string EmailAddress
		{
			get
			{
				return _emailAddress;
			}
			set
			{
				if ((_emailAddress != null && !_emailAddress.Equals(value)) || _emailAddress != value)
				{
					_emailAddress = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the Password.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
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
		/// <summary>This property gets or sets the MetaPartnerID.</summary>
		// ------------------------------------------------------------------------------
		[XmlElementAttribute()]
		[DataTransform]
		public virtual Guid MetaPartnerID
		{
			get
			{
				return _metaPartnerID;
			}
			set
			{
				if (_metaPartnerID != value)
				{
					_metaPartnerID = value;
					_metaPartner = null;
					// reset MetaPartner
					BLL.PersistedBusinessObject vMetaPartner = (BLL.PersistedBusinessObject) MetaPartner;
					vMetaPartner = null;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the Rank.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Int)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual int Rank
		{
			get
			{
				return _rank;
			}
			set
			{
				if (_rank != value)
				{
					_rank = value;
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
		/// <summary>This read only property gets the DisplayName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		public virtual string DisplayName
		{
			get
			{
				return _displayName;
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
				return (MOD.Data.DataHelper.GetString(MetaPartnerEmailID,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					MetaPartnerEmailID = MOD.Data.DataHelper.GetGuid(keyValues[0], MOD.Data.DefaultValue.Guid);
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
					return DisplayName;
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
				return (MOD.Data.DataHelper.GetString(MetaPartnerEmailID,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					MetaPartnerEmailID = MOD.Data.DataHelper.GetGuid(keyValues[0], MOD.Data.DefaultValue.Guid);
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
					return "DisplayName";
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
		/// <summary>This read only property gets the MetaPartnerName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		public virtual string MetaPartnerName
		{
			get
			{
				return _metaPartnerName;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This read only property gets the DateFormatCode.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Int)]
		[XmlElementAttribute()]
		public virtual int DateFormatCode
		{
			get
			{
				return _dateFormatCode;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of MetaPartner.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Customers.MetaPartner MetaPartner
		{
			get
			{
				if (_metaPartner == null  && IsLazyLoadable == true)
				{
					_metaPartner = BLL.Customers.MetaPartnerManager.GetOneMetaPartner((Guid)MetaPartnerID);
					// refresh derived properties
					if (_metaPartner != null)
					{
						_metaPartnerName = _metaPartner.MetaPartnerName;
						_dateFormatCode = _metaPartner.DateFormatCode;
					}
					else
					{
						_metaPartnerName = MOD.Data.DefaultValue.String;
						_dateFormatCode = MOD.Data.DefaultValue.Int;
					}
				}
				return _metaPartner;
			}
			set
			{
				if (_metaPartner != value)
				{
					_metaPartner = value;
					_isDirty = true;
					// refresh derived properties
					if (_metaPartner != null)
					{
						_metaPartnerName = _metaPartner.MetaPartnerName;
						_dateFormatCode = _metaPartner.DateFormatCode;
					}
					else
					{
						_metaPartnerName = MOD.Data.DefaultValue.String;
						_dateFormatCode = MOD.Data.DefaultValue.Int;
					}
				}
			}
		}
		#endregion Properties
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public MetaPartnerEmail()
		{
			//
			// constructor logic
			//
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method creates an instance with the primary key values.</summary>
		// ------------------------------------------------------------------------------
		public MetaPartnerEmail(string keyValues, bool isPrimaryKeyValues)
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
		/// <summary>This constructor initializes the MetaPartnerEmail from its DAL counterpart.</summary>
		// ------------------------------------------------------------------------------
		public MetaPartnerEmail(DAL.Customers.MetaPartnerEmail businessObject) : base(businessObject)
		{
		}
		// ------------------------------------------------------------------------------
		/// <summary>This constructor initializes the MetaPartnerEmail from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public MetaPartnerEmail(Guid metaPartnerEmailID)
		{
			MetaPartnerEmailID = metaPartnerEmailID;
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the MetaPartnerEmail with its already set properties.</summary>
		// ------------------------------------------------------------------------------
		public void Load()
		{
			Load(MetaPartnerEmailID);
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the MetaPartnerEmail from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public void Load(Guid metaPartnerEmailID)
		{
			BLL.Customers.MetaPartnerEmail businessObject = null;
			businessObject = BLL.Customers.MetaPartnerEmailManager.GetOneMetaPartnerEmail(metaPartnerEmailID);
			if(businessObject != null)
			{
				ReflectionHelper.Copy(businessObject, this, true);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the MetaPartnerEmail into the database,
		/// performing add/update auto detect and performing a cascade operation if indicated.</summary>
		// ------------------------------------------------------------------------------
		public void Save(bool performCascade)
		{
			if (IsLoaded == false)
			{
				BLL.Customers.MetaPartnerEmailManager.UpsertOneMetaPartnerEmail(this, performCascade);
			}
			else
			{
				BLL.Customers.MetaPartnerEmailManager.UpsertOneMetaPartnerEmail(this, performCascade);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the MetaPartnerEmail into the database,
		/// performing add/update auto detect and without performing a cascade operation.</summary>
		// ------------------------------------------------------------------------------
		public void Save()
		{
			Save(false);
		}
		/// <summary>
		///	Clears the dirty state of MetaPartnerEmail and its subcollections.
		/// </summary>
		/// <param name="clearCollectionDirtyState">Flag to clear subcollections.</param>
		/// <returns></returns>
		public override void ClearDirtyState(bool clearCollectionDirtyState)
		{
			// clear base items
			base.ClearDirtyState();
			// clear collections and other items
			if (this._metaPartner != null)
			{
				this.MetaPartner.ClearDirtyState(clearCollectionDirtyState);
			}
		}
		/// <summary>
		///	Tests to see if input object is convertable to MetaPartnerEmail, and has the same primary key values.
		/// </summary>
		/// <param name="obj">Input object to test.</param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			MetaPartnerEmail metaPartnerEmailInstance = obj as MetaPartnerEmail;
			if (metaPartnerEmailInstance == null)
				return false;
			else
				return (_metaPartnerEmailID == metaPartnerEmailInstance.MetaPartnerEmailID);
		}
		/// <summary>
		///	Returns unique identifying integer		 
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return (_metaPartnerEmailID.ToString()).GetHashCode();
		}
		#endregion Methods
	}
}