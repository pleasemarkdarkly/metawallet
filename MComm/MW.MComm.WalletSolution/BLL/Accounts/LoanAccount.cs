
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
namespace MW.MComm.WalletSolution.BLL.Accounts
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to hold and manage information for LoanAccount instances.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[Serializable()]
	[DataTransform(Name = "MW.MComm.WalletSolution.DAL.Accounts.LoanAccount")]
	public partial class LoanAccount : BLL.Accounts.Account
	{
		#region Constants
		#endregion Constants
		#region Fields
		// for LoanAmount property
		protected decimal _loanAmount = MOD.Data.DefaultValue.Decimal;
		// for OutstandingAmount property
		protected decimal _outstandingAmount = MOD.Data.DefaultValue.Decimal;
		// for DueDate property
		protected DateTime _dueDate = MOD.Data.DefaultValue.DateTime;
		// for LoanRate property
		protected float _loanRate = MOD.Data.DefaultValue.Float;
		// for LoaningMetaPartnerName read only property
		[DataTransform]
		protected string _loaningMetaPartnerName = MOD.Data.DefaultValue.String;
		// for LoanToMetaPartnerList property
		protected BLL.SortableList<BLL.Accounts.LoanToMetaPartner> _loanToMetaPartnerList = null;
		#endregion Fields
		#region Properties
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the LoanAmount.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValue(typeof(decimal),"0")]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual decimal LoanAmount
		{
			get
			{
				return _loanAmount;
			}
			set
			{
				if (_loanAmount != value)
				{
					_loanAmount = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the OutstandingAmount.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValue(typeof(decimal),"0")]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual decimal OutstandingAmount
		{
			get
			{
				return _outstandingAmount;
			}
			set
			{
				if (_outstandingAmount != value)
				{
					_outstandingAmount = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the DueDate.</summary>
		// ------------------------------------------------------------------------------
		[XmlElementAttribute()]
		[DataTransform]
		public virtual DateTime DueDate
		{
			get
			{
				return _dueDate;
			}
			set
			{
				if (_dueDate != value)
				{
					_dueDate = value;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the LoanRate.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Float)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual float LoanRate
		{
			get
			{
				return _loanRate;
			}
			set
			{
				if (_loanRate != value)
				{
					_loanRate = value;
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
				return ((_loanToMetaPartnerList != null && _loanToMetaPartnerList.IsDirty) ||
				base.IsCollectionDirty);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This read only property gets the LoaningMetaPartnerName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		public virtual string LoaningMetaPartnerName
		{
			get
			{
				return _loaningMetaPartnerName;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets LoanToMetaPartner lists.</summary>
		// ------------------------------------------------------------------------------
		[XmlArrayItem(typeof(BLL.Accounts.LoanToMetaPartner), ElementName="LoanToMetaPartner")]
		[DataTransform]
		public virtual BLL.SortableList<BLL.Accounts.LoanToMetaPartner> LoanToMetaPartnerList
		{
			get
			{
				if (_loanToMetaPartnerList == null && IsLazyLoadable == true)
				{
					_loanToMetaPartnerList = BLL.Accounts.LoanToMetaPartnerManager.GetAllLoanToMetaPartnerDataByAccountID(AccountID);
				}
				else if (_loanToMetaPartnerList == null)
				{
					_loanToMetaPartnerList = new BLL.SortableList<BLL.Accounts.LoanToMetaPartner>();
				}
				return _loanToMetaPartnerList;
			}
			set
			{
				if (value == null)
				{
					_loanToMetaPartnerList = value;
				}
				else if ((_loanToMetaPartnerList == null && value != null) ||
					  !_loanToMetaPartnerList.Equals(value))
				{
					_loanToMetaPartnerList = value;
					_isDirty = true;
				}
			}
		}
		#endregion Properties
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public LoanAccount()
		{
			//
			// constructor logic
			//
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method creates an instance with the primary key values.</summary>
		// ------------------------------------------------------------------------------
		public LoanAccount(string keyValues, bool isPrimaryKeyValues)
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
		/// <summary>This constructor initializes the LoanAccount from its DAL counterpart.</summary>
		// ------------------------------------------------------------------------------
		public LoanAccount(DAL.Accounts.LoanAccount businessObject) : base(businessObject)
		{
		}
		// ------------------------------------------------------------------------------
		/// <summary>This constructor initializes the LoanAccount from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public LoanAccount(Guid accountID)
		{
			AccountID = accountID;
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the LoanAccount with its already set properties.</summary>
		// ------------------------------------------------------------------------------
		public new void Load()
		{
			Load(AccountID);
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the LoanAccount from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public new void Load(Guid accountID)
		{
			BLL.Accounts.LoanAccount businessObject = null;
			businessObject = BLL.Accounts.LoanAccountManager.GetOneLoanAccount(accountID);
			if(businessObject != null)
			{
				ReflectionHelper.Copy(businessObject, this, true);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the LoanAccount into the database,
		/// performing add/update auto detect and performing a cascade operation if indicated.</summary>
		// ------------------------------------------------------------------------------
		public new void Save(bool performCascade)
		{
			if (IsLoaded == false)
			{
				BLL.Accounts.LoanAccountManager.AddOneLoanAccount(this, performCascade);
			}
			else
			{
				BLL.Accounts.LoanAccountManager.UpdateOneLoanAccount(this, performCascade);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the LoanAccount into the database,
		/// performing add/update auto detect and without performing a cascade operation.</summary>
		// ------------------------------------------------------------------------------
		public new void Save()
		{
			Save(false);
		}
		/// <summary>
		///	Clears the dirty state of LoanAccount and its subcollections.
		/// </summary>
		/// <param name="clearCollectionDirtyState">Flag to clear subcollections.</param>
		/// <returns></returns>
		public override void ClearDirtyState(bool clearCollectionDirtyState)
		{
			// clear base items
			base.ClearDirtyState();
			// clear collections and other items
			if (this._loanToMetaPartnerList != null)
			{
				this.LoanToMetaPartnerList.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._externalAccountItem != null)
			{
				this.ExternalAccountItem.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._metaPartner != null)
			{
				this.MetaPartner.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._accountSubType != null)
			{
				this.AccountSubType.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._currency != null)
			{
				this.Currency.ClearDirtyState(clearCollectionDirtyState);
			}
		}
		/// <summary>
		///	Tests to see if input object is convertable to LoanAccount, and has the same primary key values.
		/// </summary>
		/// <param name="obj">Input object to test.</param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			LoanAccount loanAccountInstance = obj as LoanAccount;
			if (loanAccountInstance == null)
				return false;
			else
				return (_accountID == loanAccountInstance.AccountID);
		}
		/// <summary>
		///	Returns unique identifying integer		 
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return (_accountID.ToString()).GetHashCode();
		}
		#endregion Methods
	}
}