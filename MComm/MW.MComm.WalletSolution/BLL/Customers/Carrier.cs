
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
	/// <summary>This class is used to hold and manage information for Carrier instances.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[Serializable()]
	[DataTransform(Name = "MW.MComm.WalletSolution.DAL.Customers.Carrier")]
	public partial class Carrier : BLL.Customers.Business
	{
		#region Constants
		#endregion Constants
		#region Fields
		// for CarrierCode property
		protected int _carrierCode = MOD.Data.DefaultValue.Int;
		#endregion Fields
		#region Properties
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the CarrierCode.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Int)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual int CarrierCode
		{
			get
			{
				return _carrierCode;
			}
			set
			{
				if (_carrierCode != value)
				{
					_carrierCode = value;
					_isDirty = true;
				}
			}
		}
		#endregion Properties
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public Carrier()
		{
			//
			// constructor logic
			//
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method creates an instance with the primary key values.</summary>
		// ------------------------------------------------------------------------------
		public Carrier(string keyValues, bool isPrimaryKeyValues)
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
		/// <summary>This constructor initializes the Carrier from its DAL counterpart.</summary>
		// ------------------------------------------------------------------------------
		public Carrier(DAL.Customers.Carrier businessObject) : base(businessObject)
		{
		}
		// ------------------------------------------------------------------------------
		/// <summary>This constructor initializes the Carrier from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public Carrier(Guid metaPartnerID)
		{
			MetaPartnerID = metaPartnerID;
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the Carrier with its already set properties.</summary>
		// ------------------------------------------------------------------------------
		public new void Load()
		{
			Load(MetaPartnerID);
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the Carrier from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public new void Load(Guid metaPartnerID)
		{
			BLL.Customers.Carrier businessObject = null;
			businessObject = BLL.Customers.CarrierManager.GetOneCarrier(metaPartnerID);
			if(businessObject != null)
			{
				ReflectionHelper.Copy(businessObject, this, true);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the Carrier into the database,
		/// performing add/update auto detect and performing a cascade operation if indicated.</summary>
		// ------------------------------------------------------------------------------
		public new void Save(bool performCascade)
		{
			if (IsLoaded == false)
			{
				BLL.Customers.CarrierManager.AddOneCarrier(this, performCascade);
			}
			else
			{
				BLL.Customers.CarrierManager.UpdateOneCarrier(this, performCascade);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the Carrier into the database,
		/// performing add/update auto detect and without performing a cascade operation.</summary>
		// ------------------------------------------------------------------------------
		public new void Save()
		{
			Save(false);
		}
		/// <summary>
		///	Clears the dirty state of Carrier and its subcollections.
		/// </summary>
		/// <param name="clearCollectionDirtyState">Flag to clear subcollections.</param>
		/// <returns></returns>
		public override void ClearDirtyState(bool clearCollectionDirtyState)
		{
			// clear base items
			base.ClearDirtyState();
			// clear collections and other items
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
		///	Tests to see if input object is convertable to Carrier, and has the same primary key values.
		/// </summary>
		/// <param name="obj">Input object to test.</param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			Carrier carrierInstance = obj as Carrier;
			if (carrierInstance == null)
				return false;
			else
				return (_metaPartnerID == carrierInstance.MetaPartnerID);
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