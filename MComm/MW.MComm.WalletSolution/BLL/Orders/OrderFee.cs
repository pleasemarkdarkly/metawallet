
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
namespace MW.MComm.WalletSolution.BLL.Orders
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to hold and manage information for OrderFee instances.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[Serializable()]
	[DataTransform(Name = "MW.MComm.WalletSolution.DAL.Orders.OrderFee")]
	public partial class OrderFee : PersistedBusinessObject
	{
		#region Constants
		#endregion Constants
		#region Fields
		// for OrderID property
		protected Guid _orderID = MOD.Data.DefaultValue.Guid;
		// for FeeCode property
		protected int _feeCode = MOD.Data.DefaultValue.Int;
		// for FeeName read only property
		[DataTransform]
		protected string _feeName = MOD.Data.DefaultValue.String;
		// for Order property
		protected BLL.Orders.Order _order = null;
		// for Fee property
		protected BLL.Payments.Fee _fee = null;
		#endregion Fields
		#region Properties
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the OrderID.</summary>
		// ------------------------------------------------------------------------------
		[XmlElementAttribute()]
		[DataTransform]
		public virtual Guid OrderID
		{
			get
			{
				return _orderID;
			}
			set
			{
				if (_orderID != value)
				{
					_orderID = value;
					_order = null;
					// reset Order
					BLL.PersistedBusinessObject vOrder = (BLL.PersistedBusinessObject) Order;
					vOrder = null;
					_isDirty = true;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the FeeCode.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.Int)]
		[XmlElementAttribute()]
		[DataTransform]
		public virtual int FeeCode
		{
			get
			{
				return _feeCode;
			}
			set
			{
				if (_feeCode != value)
				{
					_feeCode = value;
					_fee = null;
					// reset Fee
					BLL.PersistedBusinessObject vFee = (BLL.PersistedBusinessObject) Fee;
					vFee = null;
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
				return (MOD.Data.DataHelper.GetString(OrderID,"") + ", " + MOD.Data.DataHelper.GetString(FeeCode,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					OrderID = MOD.Data.DataHelper.GetGuid(keyValues[0], MOD.Data.DefaultValue.Guid);
				}
				if (keyValues.Length > 1)
				{
					FeeCode = MOD.Data.DataHelper.GetInt(keyValues[1], MOD.Data.DefaultValue.Int);
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
					return FeeName;
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
				return (MOD.Data.DataHelper.GetString(OrderID,"") + ", " + MOD.Data.DataHelper.GetString(FeeCode,""));
			}
			set
			{
				string[] keyValues = value.Split(',');
				if (keyValues.Length > 0)
				{
					OrderID = MOD.Data.DataHelper.GetGuid(keyValues[0], MOD.Data.DefaultValue.Guid);
				}
				if (keyValues.Length > 1)
				{
					FeeCode = MOD.Data.DataHelper.GetInt(keyValues[1], MOD.Data.DefaultValue.Int);
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
					return "FeeName";
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
		/// <summary>This read only property gets the FeeName.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute(MOD.Data.DefaultValue.String)]
		[XmlElementAttribute()]
		public virtual string FeeName
		{
			get
			{
				return _feeName;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of Order.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Orders.Order Order
		{
			get
			{
				if (_order == null  && IsLazyLoadable == true)
				{
					_order = BLL.Orders.OrderManager.GetOneOrder((Guid)OrderID);
					// refresh derived properties
					if (_order != null)
					{
					}
					else
					{
					}
				}
				return _order;
			}
			set
			{
				if (_order != value)
				{
					_order = value;
					_isDirty = true;
					// refresh derived properties
					if (_order != null)
					{
					}
					else
					{
					}
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets an item of Fee.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		[DataTransform]
		public virtual BLL.Payments.Fee Fee
		{
			get
			{
				if (_fee == null  && IsLazyLoadable == true)
				{
					_fee = BLL.Payments.FeeManager.GetOneFee((int)FeeCode);
					// refresh derived properties
					if (_fee != null)
					{
						_feeName = _fee.FeeName;
					}
					else
					{
						_feeName = MOD.Data.DefaultValue.String;
					}
				}
				return _fee;
			}
			set
			{
				if (_fee != value)
				{
					_fee = value;
					_isDirty = true;
					// refresh derived properties
					if (_fee != null)
					{
						_feeName = _fee.FeeName;
					}
					else
					{
						_feeName = MOD.Data.DefaultValue.String;
					}
				}
			}
		}
		#endregion Properties
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public OrderFee()
		{
			//
			// constructor logic
			//
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method creates an instance with the primary key values.</summary>
		// ------------------------------------------------------------------------------
		public OrderFee(string keyValues, bool isPrimaryKeyValues)
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
		/// <summary>This constructor initializes the OrderFee from its DAL counterpart.</summary>
		// ------------------------------------------------------------------------------
		public OrderFee(DAL.Orders.OrderFee businessObject) : base(businessObject)
		{
		}
		// ------------------------------------------------------------------------------
		/// <summary>This constructor initializes the OrderFee from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public OrderFee(Guid orderID, int feeCode)
		{
			OrderID = orderID;
			FeeCode = feeCode;
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the OrderFee with its already set properties.</summary>
		// ------------------------------------------------------------------------------
		public void Load()
		{
			Load(OrderID, FeeCode);
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method loads the OrderFee from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public void Load(Guid orderID, int feeCode)
		{
			BLL.Orders.OrderFee businessObject = null;
			businessObject = BLL.Orders.OrderFeeManager.GetOneOrderFee(orderID, feeCode);
			if(businessObject != null)
			{
				ReflectionHelper.Copy(businessObject, this, true);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the OrderFee into the database,
		/// performing add/update auto detect and performing a cascade operation if indicated.</summary>
		// ------------------------------------------------------------------------------
		public void Save(bool performCascade)
		{
			if (IsLoaded == false)
			{
				BLL.Orders.OrderFeeManager.AddOneOrderFee(this, performCascade);
			}
			else
			{
				BLL.Orders.OrderFeeManager.UpdateOneOrderFee(this, performCascade);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This method saves the OrderFee into the database,
		/// performing add/update auto detect and without performing a cascade operation.</summary>
		// ------------------------------------------------------------------------------
		public void Save()
		{
			Save(false);
		}
		/// <summary>
		///	Clears the dirty state of OrderFee and its subcollections.
		/// </summary>
		/// <param name="clearCollectionDirtyState">Flag to clear subcollections.</param>
		/// <returns></returns>
		public override void ClearDirtyState(bool clearCollectionDirtyState)
		{
			// clear base items
			base.ClearDirtyState();
			// clear collections and other items
			if (this._order != null)
			{
				this.Order.ClearDirtyState(clearCollectionDirtyState);
			}
			if (this._fee != null)
			{
				this.Fee.ClearDirtyState(clearCollectionDirtyState);
			}
		}
		/// <summary>
		///	Tests to see if input object is convertable to OrderFee, and has the same primary key values.
		/// </summary>
		/// <param name="obj">Input object to test.</param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			OrderFee orderFeeInstance = obj as OrderFee;
			if (orderFeeInstance == null)
				return false;
			else
				return (_orderID == orderFeeInstance.OrderID && 
					_feeCode == orderFeeInstance.FeeCode);
		}
		/// <summary>
		///	Returns unique identifying integer		 
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return (_orderID.ToString() + _feeCode.ToString()).GetHashCode();
		}
		#endregion Methods
	}
}