
/*<copyright>
Meta Wallet, Inc (c) 2007 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2007, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/
using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using MOD.Data;
using BLL = MW.MComm.WalletSolution.BLL;
using MW.MComm.WalletSolution.BLL.Accounts;
using CoreUtility = MW.MComm.WalletSolution.Utility;
using MW.MComm.Admin.WebUI.Components.Desktop;
namespace MW.MComm.Admin.WebUI.UserControls.Desktop.Accounts
{
	// ------------------------------------------------------------------------------
	/// <summary>Search Bill Pay Account Data is used to help manage BillPayAccount information.</summary>
	///
	/// File History:
	/// <created>6/1/2007 (Chris Grundy)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class SearchBillPayAccountData  : Components.Desktop.BaseSearchUserControl
	{
		#region Fields
		#endregion Fields
		#region Properties
		public string ListTitle
		{
			get { return lblTitle.Text; }
			set { lblTitle.Text = value; }
		}
		public bool UseValidation
		{
			get
			{
				return base.UseValidation;
			}
			set
			{
				base.UseValidation = value;
				editBillPayAccount.UseValidation = value;
			}
		}
		public DataGrid DataGrid { get { return dgPrimaryList; } }
		#endregion Properties
		#region Event Handlers
		// ------------------------------------------------------------------------------
		/// <summary>Load page for Bill Pay Account search.</summary>
		///
		// ------------------------------------------------------------------------------
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				workingBillPayAccountData.Visible = ProvideWorkingSet;
				base.OnLoad(); // base list control manages loading data
				if (WorkflowMode != WorkflowMode.Internal)
				{
					if (Session["SearchAccounts/BillPayAccountData"] != null)
					{
						_collection = (BLL.SortableList<BLL.Accounts.BillPayAccount>)Session["SearchAccounts/BillPayAccountData"];
					}
				}
				// Set current item into child control
				if (_selectedIndex > -1)
				{
					this.editBillPayAccount.BillPayAccountItem = (BLL.Accounts.BillPayAccount) Collection[_selectedIndex];
				}
				this.editBillPayAccount.BillPayAccountAdded += new EntityEditEventHandler(editBillPayAccount_BillPayAccountAdded);
				this.editBillPayAccount.BillPayAccountRemoved += new EntityEditEventHandler(editBillPayAccount_BillPayAccountRemoved);
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "SearchBillPayAccountData.Page_Load"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Item added event handler for Bill Pay Account.</summary>
		///
		// ------------------------------------------------------------------------------
		private void editBillPayAccount_BillPayAccountAdded(BaseFormlUserControl sender, EntityEditEventArgs e)
		{
			if (_collection.Contains(e.Entity))
			{
				Globals.AddErrorMessage(this.Page, "Collection already contains this Bill Pay Account", new object[0]);
			}
			else
			{
				_collection.Add(e.Entity);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Item removed event handler for Bill Pay Account.</summary>
		///
		// ------------------------------------------------------------------------------
		private void editBillPayAccount_BillPayAccountRemoved(BaseFormlUserControl sender, EntityEditEventArgs e)
		{
			_collection.Add(e.Entity);
		}
		// ------------------------------------------------------------------------------
		/// <summary>Binding for a list of Bill Pay Account.</summary>
		///
		// ------------------------------------------------------------------------------
		private void dgPrimaryList_ItemDataBound(object sender, DataGridItemEventArgs e)
		{
			try
			{
				if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.SelectedItem)
				{
					BLL.Accounts.BillPayAccount vBillPayAccount = (BLL.Accounts.BillPayAccount)e.Item.DataItem;
					SetControlText(e.Item,"lblPrimaryName", MOD.Data.DataHelper.GetString(vBillPayAccount.PrimaryName, ""));
					SetControlText(e.Item,"lblBusinessAccountNumber", MOD.Data.DataHelper.GetString(vBillPayAccount.BusinessAccountNumber, ""));
					SetControlText(e.Item,"lblStartDate", MOD.Data.DataHelper.GetString(vBillPayAccount.StartDate, ""));
					SetControlText(e.Item,"lblEndDate", MOD.Data.DataHelper.GetString(vBillPayAccount.EndDate, ""));
					SetControlText(e.Item,"lblDefaultMinimumPayment", MOD.Data.DataHelper.GetString(vBillPayAccount.DefaultMinimumPayment, ""));
					SetControlText(e.Item,"lblDefaultMaximumPayment", MOD.Data.DataHelper.GetString(vBillPayAccount.DefaultMaximumPayment, ""));
					SetControlText(e.Item,"lblHourOfDay", MOD.Data.DataHelper.GetString(vBillPayAccount.HourOfDay, ""));
					SetControlText(e.Item,"lblDayOfWeek", MOD.Data.DataHelper.GetString(vBillPayAccount.DayOfWeek, ""));
					SetControlText(e.Item,"lblWeekOfMonth", MOD.Data.DataHelper.GetString(vBillPayAccount.WeekOfMonth, ""));
					SetControlText(e.Item,"lblMonthOfYear", MOD.Data.DataHelper.GetString(vBillPayAccount.MonthOfYear, ""));
					SetControlText(e.Item,"lblNumberOfReminders", MOD.Data.DataHelper.GetString(vBillPayAccount.NumberOfReminders, ""));
					SetControlText(e.Item,"lblFrequencyCode", MOD.Data.DataHelper.GetString(vBillPayAccount.FrequencyCode, ""));
					SetControlText(e.Item,"lblCreatedDate", MOD.Data.DataHelper.GetString(vBillPayAccount.CreatedDate, ""));
					SetControlText(e.Item,"lblLastModifiedDate", MOD.Data.DataHelper.GetString(vBillPayAccount.LastModifiedDate, ""));
					SetControlText(e.Item,"lblAccountName", MOD.Data.DataHelper.GetString(vBillPayAccount.AccountName, ""));
					SetControlText(e.Item,"lblAccountSubTypeCode", MOD.Data.DataHelper.GetString(vBillPayAccount.AccountSubTypeCode, ""));
					SetControlText(e.Item,"lblCurrencyCode", MOD.Data.DataHelper.GetString(vBillPayAccount.CurrencyCode, ""));
					SetControlText(e.Item,"lblDescription", MOD.Data.DataHelper.GetString(vBillPayAccount.Description, ""));
					SetControlText(e.Item,"lblIsActive", MOD.Data.DataHelper.GetString(vBillPayAccount.IsActive, ""));
					SetControlText(e.Item,"lblFrequencyName", MOD.Data.DataHelper.GetString(vBillPayAccount.FrequencyName, MOD.Data.DefaultValue.String));
					LinkButton lnkEdit = (LinkButton)SetControlText(e.Item, "lnkEdit", "Details");
					HyperLink lnkEditOut = (HyperLink)SetControlText(e.Item, "lnkEditOut", "Details");
					foreach (DataGridColumn loopColumn in dgPrimaryList.Columns)
					{
						if (loopColumn.HeaderText == "Primary Name")
						{
							loopColumn.SortExpression = vBillPayAccount.PrimarySortColumn;
							break;
						}
					}
					if (this.WorkflowMode == MOD.Data.WorkflowMode.Internal)
					{
						foreach (DataGridColumn loopColumn in dgPrimaryList.Columns)
						{
							if (loopColumn.HeaderText == "Primary Name")
							{
								loopColumn.Visible = true;
								break;
							}
						}
						lnkEditOut.Visible = false;
					}
					else
					{
						foreach (DataGridColumn loopColumn in dgPrimaryList.Columns)
						{
							if (loopColumn.HeaderText == "Primary Name")
							{
								loopColumn.Visible = false;
								break;
							}
						}
						lnkEdit.Visible = false;
						string modeValue = "edit";
						if (IsEditAvailable == false)
						{
							modeValue = "view";
						}
						lnkEditOut.NavigateUrl = Page.ResolveUrl(string.Format("EditBillPayAccount.aspx?mode=" + modeValue + "&message=&AccountID={0}&BillPayAccountAccountID={1}", vBillPayAccount.AccountID, vBillPayAccount.AccountID));
					}
					System.Web.UI.Control lnkDelete = SetControlText(e.Item, "lnkDelete", (this.WorkflowMode == MOD.Data.WorkflowMode.Internal) ? "Remove" : "Delete");
					if (this.WorkflowMode == MOD.Data.WorkflowMode.External)
					{
						lnkDelete.Visible = false;
					}
					else
					{
						lnkDelete.Visible = IsDeleteAvailable;
					}
					if (lnkDelete is LinkButton)
					{
						WebControl wc = (WebControl)lnkDelete;
						wc.Attributes.Add("onclick", "javascript:return ConfirmDelete();");
					}
					System.Web.UI.Control lnkAdd = SetControlText(e.Item, "lnkAdd", "Add");
					if (this.WorkflowMode == MOD.Data.WorkflowMode.External)
					{
						lnkAdd.Visible = ProvideWorkingSet;
					}
					else
					{
						lnkAdd.Visible = false;
					}
				}
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "SearchBillPayAccountData.dgPrimaryList_ItemDataBound"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set Bill Pay Account information from the ui.</summary>
		///
		// ------------------------------------------------------------------------------
		protected override void SetDataFromForm()
		{
			Session["BusinessAccountNumber"] = GetStringFromTextBox(txtBusinessAccountNumber);
			Session["StartDate"] = GetStringFromTextBox(txtStartDate);
			Session["EndDate"] = GetStringFromTextBox(txtEndDate);
			Session["NumberOfReminders"] = GetStringFromTextBox(txtNumberOfReminders);
			Session["FrequencyCode"] = GetSelectedValueFromDropDownList(ddlFrequencyCode);
			Session["AccountName"] = GetStringFromTextBox(txtAccountName);
			Session["CurrencyCode"] = GetSelectedValueFromDropDownList(ddlCurrencyCode);
			Session["LastModifiedDateStart"] = GetStringFromTextBox(txtLastModifiedDateStart);
			Session["LastModifiedDateEnd"] = GetStringFromTextBox(txtLastModifiedDateEnd);
		}
		// ------------------------------------------------------------------------------
		/// <summary>Get Bill Pay Account information from the database.</summary>
		///
		// ------------------------------------------------------------------------------
		protected override void LoadCollectionFromDatabase()
		{
			try
			{
				int totalRecords = 0;
				bool maximumListSizeExceeded = false;
				string businessAccountNumber = MOD.Data.SearchHelper.GetString(Session["BusinessAccountNumber"]);
				DateTime? startDate = MOD.Data.SearchHelper.GetDateTime(Session["StartDate"]);
				DateTime? endDate = MOD.Data.SearchHelper.GetDateTime(Session["EndDate"]);
				int? numberOfReminders = MOD.Data.SearchHelper.GetInt(Session["NumberOfReminders"]);
				int? frequencyCode = MOD.Data.SearchHelper.GetInt(Session["FrequencyCode"]);
				string accountName = MOD.Data.SearchHelper.GetString(Session["AccountName"]);
				int? currencyCode = MOD.Data.SearchHelper.GetInt(Session["CurrencyCode"]);
				DateTime? lastModifiedDateStart = MOD.Data.SearchHelper.GetDateTime(Session["LastModifiedDateStart"]);
				DateTime? lastModifiedDateEnd = MOD.Data.SearchHelper.GetDateTime(Session["LastModifiedDateEnd"]);
				// get primary list data from database and bind
				if (Page.IsPostBack == true || this.TotalRecords > 0)
				{
					_collection = BLL.Accounts.BillPayAccountManager.GetManyBillPayAccountDataByCriteria(businessAccountNumber, startDate, endDate, numberOfReminders, frequencyCode, accountName, currencyCode, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, this.DataOptions);
					Session["SearchAccounts/BillPayAccountData"] = _collection;
					this.TotalRecords = totalRecords;
					this.MaximumListSizeExceeded = maximumListSizeExceeded;
				}
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "SearchBillPayAccountData.dgPrimaryList_ItemDataBound"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Item command event handler for Bill Pay Account list.</summary>
		///
		// ------------------------------------------------------------------------------
		public void dgPrimaryList_ItemCommand(object sender, EventArgs e)
		{
			DataGridCommandEventArgs args = (DataGridCommandEventArgs)e;
			if (args.CommandName == "Add" || args.CommandName == "Edit" || args.CommandName == "Delete")
			{
				int hashCode = int.Parse(args.CommandArgument.ToString());
				BLL.Accounts.BillPayAccount item = ((BLL.SortableList<BLL.Accounts.BillPayAccount>)_collection).Find(hashCode);
				if (args.CommandName == "Add")
				{
					workingBillPayAccountData.AddItem(item);
				}
				else if (args.CommandName == "Edit")
				{
					this.editBillPayAccount.BillPayAccountItem = item;
				}
				else if (args.CommandName == "Delete")
				{
					_collection.Remove(item);
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Page pre render event handler for Bill Pay Account.</summary>
		///
		// ------------------------------------------------------------------------------
		private void Page_PreRender(object sender, EventArgs e)
		{
			try
			{
				SetAccessModeAndDisplay(AccessMode);
				base.OnPreRender();
				if (IsPostBack == false)
				{
					txtBusinessAccountNumber.Text = MOD.Data.DataHelper.GetString(Session["BusinessAccountNumber"], "");
					txtStartDate.Text = MOD.Data.DataHelper.GetString(Session["StartDate"], "");
					txtEndDate.Text = MOD.Data.DataHelper.GetString(Session["EndDate"], "");
					txtNumberOfReminders.Text = MOD.Data.DataHelper.GetString(Session["NumberOfReminders"], "");
					if (ddlFrequencyCode.Visible == true)
					{
						Components.Lists.DataBind(ddlFrequencyCode, BLL.Accounts.FrequencyManager.GetAllFrequencyData(Globals.DBOptions, Globals.getDataOptions("FrequencyName", "", true, true), Globals.DebugLevel, Globals.CurrentUserID), "PrimaryKey", "PrimaryName", true, false);
						ddlFrequencyCode.ClearSelection();
						try
						{
							ddlFrequencyCode.SelectedValue = MOD.Data.DataHelper.GetString(Session["FrequencyCode"], "0");
						}
						catch {}
					}
					txtAccountName.Text = MOD.Data.DataHelper.GetString(Session["AccountName"], "");
					if (ddlCurrencyCode.Visible == true)
					{
						Components.Lists.DataBind(ddlCurrencyCode, BLL.Accounts.CurrencyManager.GetAllCurrencyData(Globals.DBOptions, Globals.getDataOptions("CurrencyName", "", true, true), Globals.DebugLevel, Globals.CurrentUserID), "PrimaryKey", "PrimaryName", true, false);
						ddlCurrencyCode.ClearSelection();
						try
						{
							ddlCurrencyCode.SelectedValue = MOD.Data.DataHelper.GetString(Session["CurrencyCode"], "0");
						}
						catch {}
					}
					txtLastModifiedDateStart.Text = MOD.Data.DataHelper.GetString(Session["LastModifiedDateStart"], "");
					txtLastModifiedDateEnd.Text = MOD.Data.DataHelper.GetString(Session["LastModifiedDateEnd"], "");
				}
				dgPrimaryList.DataSource = _collection;
				dgPrimaryList.DataKeyField = "AccountID";
				dgPrimaryList.DataBind();
				if (this.WorkflowMode == MOD.Data.WorkflowMode.Internal)
				{
					editBillPayAccount.Visible = true;
					btnNew.Visible = false;
				}
				else
				{
					editBillPayAccount.Visible = false;
					btnNew.Visible = true;
				}
				if (btnNew.Visible == true)
				{
					btnNew.Visible = IsEditAvailable;
				}
				this.lblSearchResultsTitle.Visible = TotalRecords != 0;
				this.dgPrimaryList.Visible = TotalRecords != 0;
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "SearchBillPayAccountData.Page_PreRender"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set access and display modes for presenting Bill Pay Account information.</summary>
		///
		// ------------------------------------------------------------------------------
		private void SetAccessModeAndDisplay(MOD.Data.AccessMode accessMode)
		{
			// set access mode
			AccessMode = accessMode;
			btnNew.Visible = IsEditAvailable;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Request to create a new Bill Pay Account.</summary>
		///
		// ------------------------------------------------------------------------------
		private void btnNew_Click(object sender, EventArgs e)
		{
			Globals.ClearMessages();
			Response.Redirect(Page.ResolveUrl(string.Format("EditBillPayAccount.aspx?mode=" + MOD.Data.AccessMode.Add.ToString() + "&AccountID=" + MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, "") + "&BillPayAccountAccountID=" + MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, "") + "")));
		}
		
		// ------------------------------------------------------------------------------
		/// <summary>Clear search form for Bill Pay Account.</summary>
		///
		// ------------------------------------------------------------------------------
		private void btnClear_Click(object sender, EventArgs e)
		{
			Globals.ClearMessages();
			this.TotalRecords = 0;
			_collection = null;
			txtBusinessAccountNumber.Text = "";
			txtStartDate.Text = "";
			txtEndDate.Text = "";
			txtNumberOfReminders.Text = "";
			ddlFrequencyCode.ClearSelection();
			txtAccountName.Text = "";
			ddlCurrencyCode.ClearSelection();
			txtLastModifiedDateStart.Text = "";
			txtLastModifiedDateEnd.Text = "";
			SetDataFromForm();
		}
		// ------------------------------------------------------------------------------
		/// <summary>Perform search for Bill Pay Account items.</summary>
		///
		// ------------------------------------------------------------------------------
		private void btnSearch_Click(object sender, EventArgs e)
		{
			try
			{
				Globals.ClearMessages();
				this.OnSearch(sender,e);
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "SearchBillPayAccountData.btnSearch_Click"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// Handle Start Date selection change.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		// ------------------------------------------------------------------------------
		private void calStartDate_SelectionChanged(object sender, EventArgs e)
		{
			txtStartDate.Text = calStartDate.SelectedDate.ToShortDateString();
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// HandleStart Datescheduler.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		// ------------------------------------------------------------------------------
		private void btnStartDateCalendar_Click(object sender, EventArgs e)
		{
			if (calStartDate.Visible == false)
			{
				calStartDate.Visible = true;
				btnStartDateCalendar.Text = "Hide Calendar";
				ResetStartDateCalendar(true);
			}
			else
			{
				calStartDate.Visible = false;
				btnStartDateCalendar.Text = "Calendar";
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// Handle End Date selection change.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		// ------------------------------------------------------------------------------
		private void calEndDate_SelectionChanged(object sender, EventArgs e)
		{
			txtEndDate.Text = calEndDate.SelectedDate.ToShortDateString();
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// HandleEnd Datescheduler.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		// ------------------------------------------------------------------------------
		private void btnEndDateCalendar_Click(object sender, EventArgs e)
		{
			if (calEndDate.Visible == false)
			{
				calEndDate.Visible = true;
				btnEndDateCalendar.Text = "Hide Calendar";
				ResetEndDateCalendar(true);
			}
			else
			{
				calEndDate.Visible = false;
				btnEndDateCalendar.Text = "Calendar";
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// Handle Last Modified Date Start selection change.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		// ------------------------------------------------------------------------------
		private void calLastModifiedDateStart_SelectionChanged(object sender, EventArgs e)
		{
			txtLastModifiedDateStart.Text = calLastModifiedDateStart.SelectedDate.ToShortDateString();
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// HandleLast Modified Date Start scheduler.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		// ------------------------------------------------------------------------------
		private void btnLastModifiedDateStartCalendar_Click(object sender, EventArgs e)
		{
			if (calLastModifiedDateStart.Visible == false)
			{
				calLastModifiedDateStart.Visible = true;
				btnLastModifiedDateStartCalendar.Text = "Hide Calendar";
				ResetLastModifiedDateStartCalendar(true);
			}
			else
			{
				calLastModifiedDateStart.Visible = false;
				btnLastModifiedDateStartCalendar.Text = "Calendar";
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// Handle Last Modified Date End selection change.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		// ------------------------------------------------------------------------------
		private void calLastModifiedDateEnd_SelectionChanged(object sender, EventArgs e)
		{
			txtLastModifiedDateEnd.Text = calLastModifiedDateEnd.SelectedDate.ToShortDateString();
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// HandleLast Modified Date End scheduler.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		// ------------------------------------------------------------------------------
		private void btnLastModifiedDateEndCalendar_Click(object sender, EventArgs e)
		{
			if (calLastModifiedDateEnd.Visible == false)
			{
				calLastModifiedDateEnd.Visible = true;
				btnLastModifiedDateEndCalendar.Text = "Hide Calendar";
				ResetLastModifiedDateEndCalendar(true);
			}
			else
			{
				calLastModifiedDateEnd.Visible = false;
				btnLastModifiedDateEndCalendar.Text = "Calendar";
			}
		}
		#endregion Event Handlers
		#region Methods
		// ------------------------------------------------------------------------------
		/// <summary>
		/// Reset Start Date schedule.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		// ------------------------------------------------------------------------------
		private void ResetStartDateCalendar(bool resetVisibleDate)
		{
			try
			{
				calStartDate.SelectedDates.Clear();
				System.DateTime strStartDate = System.DateTime.Parse(txtStartDate.Text);
				calStartDate.SelectedDate = strStartDate;
				if (resetVisibleDate == true)
				{
					calStartDate.VisibleDate = strStartDate;
				}
			}
			catch
			{
				calStartDate.SelectedDates.Clear();
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// Reset End Date schedule.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		// ------------------------------------------------------------------------------
		private void ResetEndDateCalendar(bool resetVisibleDate)
		{
			try
			{
				calEndDate.SelectedDates.Clear();
				System.DateTime strEndDate = System.DateTime.Parse(txtEndDate.Text);
				calEndDate.SelectedDate = strEndDate;
				if (resetVisibleDate == true)
				{
					calEndDate.VisibleDate = strEndDate;
				}
			}
			catch
			{
				calEndDate.SelectedDates.Clear();
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// Reset Last Modified Date Start schedule.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		// ------------------------------------------------------------------------------
		private void ResetLastModifiedDateStartCalendar(bool resetVisibleDate)
		{
			try
			{
				calLastModifiedDateStart.SelectedDates.Clear();
				System.DateTime strLastModifiedDateStart = System.DateTime.Parse(txtLastModifiedDateStart.Text);
				calLastModifiedDateStart.SelectedDate = strLastModifiedDateStart;
				if (resetVisibleDate == true)
				{
					calLastModifiedDateStart.VisibleDate = strLastModifiedDateStart;
				}
			}
			catch
			{
				calLastModifiedDateStart.SelectedDates.Clear();
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// Reset Last Modified Date End schedule.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		// ------------------------------------------------------------------------------
		private void ResetLastModifiedDateEndCalendar(bool resetVisibleDate)
		{
			try
			{
				calLastModifiedDateEnd.SelectedDates.Clear();
				System.DateTime strLastModifiedDateEnd = System.DateTime.Parse(txtLastModifiedDateEnd.Text);
				calLastModifiedDateEnd.SelectedDate = strLastModifiedDateEnd;
				if (resetVisibleDate == true)
				{
					calLastModifiedDateEnd.VisibleDate = strLastModifiedDateEnd;
				}
			}
			catch
			{
				calLastModifiedDateEnd.SelectedDates.Clear();
			}
		}
		#endregion Methods
		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		// ------------------------------------------------------------------------------
		/// <summary>Initialize component for BillPayAccount, add delegates here.</summary>
		///
		// ------------------------------------------------------------------------------
		private void InitializeComponent()
		{
			this.calStartDate.SelectionChanged += new System.EventHandler(calStartDate_SelectionChanged);
			this.btnStartDateCalendar.Click += new EventHandler(btnStartDateCalendar_Click);
			this.calEndDate.SelectionChanged += new System.EventHandler(calEndDate_SelectionChanged);
			this.btnEndDateCalendar.Click += new EventHandler(btnEndDateCalendar_Click);
			this.calLastModifiedDateStart.SelectionChanged += new System.EventHandler(calLastModifiedDateStart_SelectionChanged);
			this.btnLastModifiedDateStartCalendar.Click += new EventHandler(btnLastModifiedDateStartCalendar_Click);
			this.calLastModifiedDateEnd.SelectionChanged += new System.EventHandler(calLastModifiedDateEnd_SelectionChanged);
			this.btnLastModifiedDateEndCalendar.Click += new EventHandler(btnLastModifiedDateEndCalendar_Click);
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
			this.dgPrimaryList.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.OnListSort);
			this.dgPrimaryList.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgPrimaryList_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);
			this.PreRender += new EventHandler(Page_PreRender);
		}
		#endregion
	}
}