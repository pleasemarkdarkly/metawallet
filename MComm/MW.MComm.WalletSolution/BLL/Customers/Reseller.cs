
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
namespace MW.MComm.WalletSolution.BLL.Customers
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to hold and manage information for Reseller instances.</summary>
	///
	/// File History:
	/// <created>5/8/2007 (Chris Grundy)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[Serializable()]
	[XmlType(Namespace = "http://modsystems.com/MW.MComm.WalletSolution/Customers/DataTypes")]
	[DataTransform(Name = "MW.MComm.WalletSolution.DAL.Customers.Reseller")]
	public partial class Reseller : BLL.Customers.Business
	{
		#region Constants
		#endregion Constants
		#region Fields
		// for ResellerTypeCode property
		protected int _resellerTypeCode = MOD.Data.DefaultValue.Int;
		// for ResellerTypeName read only property
		[DataTransform]
		protected string _resellerTypeName = MOD.Data.DefaultValue.String;
		// for Commision read only property
		[DataTransform]
		protected float _commision = MOD.Data.DefaultValue.Float;
		// for ResellerType property
		protected BLL.Customers.ResellerType _resellerType = null;
		#endregion Fields
		#region Properties
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the ResellerTypeCode.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Int)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual int ResellerTypeCode
		{
			get
			{
				return _resellerTypeCode;
			}
			set
			{
				if (_resellerTypeCode != value)
				{
					_resellerTypeCode = value;
					_resellerType = null;
					// reset ResellerType
					BLL.PersistedBusinessObject vResellerType = (BLL.PersistedBusinessObject) ResellerType;
					vResellerType = null;
					_isDirty = true;
				}
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
		/// <summary>This read only property gets the ResellerTypeName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		public virtual string ResellerTypeName
		{
			get
			{
				return _resellerTypeName;
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
		/// <summary>This read only property gets the Commision.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Float)]
		[XmlElementAttribute()]
		public virtual float Commision
		{
			get
			{
				return _commision;
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
		/// <summary>This property gets or sets an item of ResellerType.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Customers.ResellerType ResellerType
		{
			get
			{
				if (_resellerType == null  && IsLazyLoadable == true)
				{
					_resellerType = BLL.Customers.ResellerTypeManager.GetOneResellerType((int)ResellerTypeCode);
					// refresh derived properties
					if (_resellerType != null)
					{
						_resellerTypeName = _resellerType.ResellerTypeName;
						_commision = _resellerType.Commision;
					}
					else
					{
						_resellerTypeName = MOD.Data.DefaultValue.String;
						_commision = MOD.Data.DefaultValue.Float;
					}
				}
				return _resellerType;
			}
			set
			{
				if (_resellerType != value)
				{
					_resellerType = value;
					_isDirty = true;
					// refresh derived properties
					if (_resellerType != null)
					{
						_resellerTypeName = _resellerType.ResellerTypeName;
						_commision = _resellerType.Commision;
					}
					else
					{
						_resellerTypeName = MOD.Data.DefaultValue.String;
						_commision = MOD.Data.DefaultValue.Float;
					}
				}
			}
		}
		#endregion Properties
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public Reseller()
		{
			//
			// constructor logic
			//
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method creates an instance with the primary key values.</summary>
		// ------------------------------------------------------------------------------
		public Reseller(string keyValues, bool isPrimaryKeyValues)
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
		/// <summary>This constructor initializes the Reseller from its DAL counterpart.</summary>
		// ------------------------------------------------------------------------------
		public Reseller(DAL.Customers.Reseller businessObject) : base(businessObject)
		{
		}
		// ------------------------------------------------------------------------------
		/// <summary>This constructor initializes the Reseller from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public Reseller(Guid metaPartnerID)
		{
			MetaPartnerID = metaPartnerID;
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the Reseller with its already set properties.</summary>
		// ------------------------------------------------------------------------------
		public new void Load()
		{
			Load(MetaPartnerID);
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the Reseller from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public new void Load(Guid metaPartnerID)
		{
			BLL.Customers.Reseller businessObject = null;
			businessObject = BLL.Customers.ResellerManager.GetOneReseller(metaPartnerID);
			if(businessObject != null)
			{
				ReflectionHelper.Copy(businessObject, this, true);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the Reseller into the database,
		/// performing add/update auto detect and performing a cascade operation if indicated.</summary>
		// ------------------------------------------------------------------------------
		public new void Save(bool performCascade)
		{
			if (IsLoaded == false)
			{
				BLL.Customers.ResellerManager.AddOneReseller(this, performCascade);
			}
			else
			{
				BLL.Customers.ResellerManager.UpdateOneReseller(this, performCascade);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the Reseller into the database,
		/// performing add/update auto detect and without performing a cascade operation.</summary>
		// ------------------------------------------------------------------------------
		public new void Save()
		{
			Save(false);
		}
		/// <summary>
		///	Clears the dirty state of Reseller and its subcollections.
		/// </summary>
		/// <param name="clearCollectionDirtyState">Flag to clear subcollections.</param>
		/// <returns></returns>
		public override void ClearDirtyState(bool clearCollectionDirtyState)
		{
			// clear base items
			base.ClearDirtyState();
			// clear collections and other items
			if (this._resellerType != null)
			{
				this.ResellerType.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._phoneList != null)
			{
				this.PhoneList.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._emailList != null)
			{
				this.EmailList.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._locationList != null)
			{
				this.LocationList.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._bankAccountList != null)
			{
				this.BankAccountList.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._storedValueAccountList != null)
			{
				this.StoredValueAccountList.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._creditAccountList != null)
			{
				this.CreditAccountList.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._fundAccountList != null)
			{
				this.FundAccountList.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._billPayAccountList != null)
			{
				this.BillPayAccountList.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._metaTransferAccountList != null)
			{
				this.MetaTransferAccountList.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._loanAccountList != null)
			{
				this.LoanAccountList.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._metaPartnerCouponList != null)
			{
				this.MetaPartnerCouponList.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._currency != null)
			{
				this.Currency.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._metaPartnerSubType != null)
			{
				this.MetaPartnerSubType.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._dateFormat != null)
			{
				this.DateFormat.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._locale != null)
			{
				this.Locale.ClearDirtyState(clearCollectionDirtyState);
			}
		}
		/// <summary>
		///	Tests to see if input object is convertable to Reseller, and has the same primary key values.
		/// </summary>
		/// <param name="obj">Input object to test.</param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			Reseller resellerInstance = obj as Reseller;
			if (resellerInstance == null)
				return false;
			else
				return (_metaPartnerID == resellerInstance.MetaPartnerID);
		}
		/// <summary>
		///	Returns unique identifying integer		 
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return (_metaPartnerID.ToString()).GetHashCode();
		}
		#endregion Methods
	}
}