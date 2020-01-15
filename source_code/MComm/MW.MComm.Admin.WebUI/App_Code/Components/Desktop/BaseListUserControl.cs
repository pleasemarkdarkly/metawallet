/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/
using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using MOD.Data;
using MW.MComm.WalletSolution.Utility;
using MW.MComm.WalletSolution.BLL.Core;
using BLL = MW.MComm.WalletSolution.BLL;
namespace MW.MComm.Admin.WebUI.Components.Desktop
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage the base information and behavior of all list user controls.</summary>
	/// 
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public class BaseListUserControl : BaseUserControl
	{
		#region "Declarations"
/*
		// for PageSize property
		private int _pageSize = Globals.DefaultPageSize;
		// for MaximumListSize property
		private int _maximumListSize = Globals.DefaultMaximumListSize;
		// for StartIndex property
		private int _startIndex = 1;
		// for SortColumn property
		private string _sortColumn = "";
		// for SortDirection property
		private MOD.Data.SortDirection _sortDirection = Globals.DefaultSortDirection;
		// for MaximumListSizeExceeded property
		private bool _maximumListSizeExceeded = false;
		// for TotalRecords property
		private int _totalRecords = 0;
*/
		// for DataOptions property
		private MOD.Data.DataOptions _dataOptions = new MOD.Data.DataOptions();
        protected int _selectedIndex = -1;
		protected IList _collection;
		#endregion "Declarations"
		#region "Public Properties"
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the page size.</summary>
		// ------------------------------------------------------------------------------
		public virtual int PageSize
		{
			get
			{
				return MOD.Data.DataHelper.GetInt(ControlSession["PageSize"],Globals.DefaultPageSize);
			}
			set
			{
				ControlSession["PageSize"] = value;
				MaximumListSize = Math.Max(MaximumListSize,PageSize);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the maximum list size.</summary>
		// ------------------------------------------------------------------------------
		public virtual int MaximumListSize
		{
			get
			{
				return MOD.Data.DataHelper.GetInt(ControlSession["MaximumListSize"],Globals.DefaultMaximumListSize);
			}
			set
			{
				ControlSession["MaximumListSize"] = value;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the page index.</summary>
		// ------------------------------------------------------------------------------
		public virtual int StartIndex
		{
			get
			{
				return MOD.Data.DataHelper.GetInt(ControlSession["StartIndex"],1);
			}
			set
			{
				ControlSession["StartIndex"] = value;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the sort column.</summary>
		// ------------------------------------------------------------------------------
		public virtual string SortColumn
		{
			get
			{
				return MOD.Data.DataHelper.GetString(ControlSession["SortColumn"],string.Empty);
			}
			set
			{
				ControlSession["SortColumn"] = value;
			}
		}
      
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the sort direction.</summary
		// ------------------------------------------------------------------------------
		public virtual MOD.Data.SortDirection SortDirection
		{
			get
			{
				return (MOD.Data.SortDirection)MOD.Data.DataHelper.GetInt(ControlSession["SortDirection"],(int)Globals.DefaultSortDirection);
			}
			set
			{
				ControlSession["SortDirection"] = (int)value;
			}
		}
      
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the maximum list size exceeded flag.</summary>
		// ------------------------------------------------------------------------------
		public virtual bool MaximumListSizeExceeded
		{
			get
			{
				return MOD.Data.DataHelper.GetBool(ControlSession["MaximumListSizeExceeeded"],false);
			}
			set
			{
				ControlSession["MaximumListSizeExceeded"] = value;
			}
		}
      
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the total number of records in the list.</summary>
		// ------------------------------------------------------------------------------
		public virtual int TotalRecords
		{
			get
			{
				return MOD.Data.DataHelper.GetInt(ControlSession["TotalRecords"],0);
			}
			set
			{
				ControlSession["TotalRecords"] = value;
			}
		}
      
		// ------------------------------------------------------------------------------
		/// <summary>This property gets the overall list options.</summary>
		// ------------------------------------------------------------------------------
		public virtual MOD.Data.DataOptions DataOptions
		{
			get
			{
				_dataOptions.PageSize = PageSize;
				_dataOptions.StartIndex = StartIndex;
				_dataOptions.SortColumn = SortColumn;
				_dataOptions.SortDirection = (MOD.Data.SortDirection)SortDirection;
				_dataOptions.MaximumListSize = MaximumListSize;
				_dataOptions.IncludeInactive = true;
				_dataOptions.IncludeDateInactive = true;
				return _dataOptions;
			}
		}
        /// <summary>
        /// The collection that will be displayed by the list.
        /// </summary>
		public virtual IList Collection
        {
            get
			{
				return _collection;
			}
            set
			{
				_collection = value;
			}
        }
		#endregion "Public Properties"
		#region "Public Methods"
		public override void OnPreRender()
		{
			base.OnPreRender();
		}
		protected override void OnLoad()
		{
			base.OnLoad();
			// load collection if not in internal mode
			if (WorkflowMode != WorkflowMode.Internal && !IsPostBack)
			{
				LoadCollectionFromDatabase();
			}
		}
		#endregion "Public Methods"
		#region "Miscellaneous"
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public BaseListUserControl()
		{
			//
			// constructor logic
			//
		}
		#endregion "Miscellaneous"
        #region "Virtual Methods"
        // ------------------------------------------------------------------------------
        /// <summary></summary>
        /// 
        /// <param name="sortColumn"></param>
        /// <exception cref="ApplicationException"></exception>
        /// <exception cref="System.Exception"></exception>
        // ------------------------------------------------------------------------------
        public virtual void SortList(string sortColumn)
        {
            try
            {
                // determine new sort options
                if (sortColumn.Trim() == this.SortColumn)
                {
                    if (this.SortDirection == MOD.Data.SortDirection.Ascending)
                    {
                        this.SortDirection = MOD.Data.SortDirection.Descending;
                    }
                    else
                    {
                        this.SortDirection = MOD.Data.SortDirection.Ascending;
                    }
                }
                else
                {
                    this.SortColumn = sortColumn.Trim();
                    this.SortDirection = MOD.Data.SortDirection.Ascending;
                }
				if (WorkflowMode == MOD.Data.WorkflowMode.Internal)
				{
					// sort the list
					((BLL.SortableList<BLL.PersistedBusinessObject>)_collection).Sort(sortColumn, this.SortDirection);
				}
				else
				{
					// update the list
					this.LoadCollectionFromDatabase();
				}
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw new ApplicationException("UI Error: sorting list.", ex);
            }
            finally
            {
            }
        }
        public virtual void RefreshList()
        {
            LoadCollectionFromDatabase();
        }
        // ------------------------------------------------------------------------------
        /// <summary></summary>
        /// 
        /// <exception cref="CustomAppException"></exception>
        /// <exception cref="System.Exception"></exception>
        // ------------------------------------------------------------------------------
        protected virtual void SetControlProperties()
        {
            try
            {
                // should do things in this order to utilize base behaviors
                // get querystring parameters
                // get other parameters and set user control mode
                this.AccessMode = MOD.Data.AccessMode.View;
                // set visibility of controls (utilizing user control mode)
            }
            catch (CustomAppException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
				throw new CustomAppException(BLL.Core.ErrorNumber.GeneralException, BLL.Core.SeverityLevelCode.CriticalError, BLL.Core.EventTypeCode.ErrorLog, "SetControlProperties", BLL.Core.ErrorManager.GetErrorMessageFromErrorNumber(BLL.Core.ErrorNumber.GeneralException), ex);
            }
            finally
            {
            }
        }
        // ------------------------------------------------------------------------------
        /// <summary></summary>
        /// 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="CustomAppException"></exception>
        /// <exception cref="System.Exception"></exception>
        // ------------------------------------------------------------------------------
        protected void OnListSort(object sender , DataGridSortCommandEventArgs e)
        {
            try
            {
                // set up sorting
                this.SortList(e.SortExpression);
            }
            catch (CustomAppException ex)
            {
                base.HandleError(ex);
            }
            catch (System.Exception ex)
            {
                base.HandleError(new CustomAppException(ErrorNumber.GeneralException, SeverityLevelCode.CriticalError, EventTypeCode.ErrorLog, "dgPrimaryList_Sort", ErrorManager.GetErrorMessageFromErrorNumber(ErrorNumber.GeneralException), ex));
            }
            finally
            {
            }
        }
        protected virtual void LoadCollectionFromDatabase()
        {
        }
		protected virtual void SetDataFromDatabase()
		{
		}
		#endregion "Virtual Methods"
	}
}
