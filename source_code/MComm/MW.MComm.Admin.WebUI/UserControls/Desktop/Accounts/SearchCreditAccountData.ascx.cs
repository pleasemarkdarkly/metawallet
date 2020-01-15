
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
	/// <summary>Search Credit Account Data is used to help manage CreditAccount information.</summary>
	///
	/// File History:
	/// <created>6/1/2007 (Chris Grundy)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class SearchCreditAccountData  : Components.Desktop.BaseSearchUserControl
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
				editCreditAccount.UseValidation = value;
			}
		}
		public DataGrid DataGrid { get { return dgPrimaryList; } }
		#endregion Properties
		#region Event Handlers
		// ------------------------------------------------------------------------------
		/// <summary>Load page for Credit Account search.</summary>
		///
		// ------------------------------------------------------------------------------
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				workingCreditAccountData.Visible = ProvideWorkingSet;
				base.OnLoad(); // base list control manages loading data
				if (WorkflowMode != WorkflowMode.Internal)
				{
					if (Session["SearchAccounts/CreditAccountData"] != null)
					{
						_collection = (BLL.SortableList<BLL.Accounts.CreditAccount>)Session["SearchAccounts/CreditAccountData"];
					}
				}
				// Set current item into child control
				if (_selectedIndex > -1)
				{
					this.editCreditAccount.CreditAccountItem = (BLL.Accounts.CreditAccount) Collection[_selectedIndex];
				}
				this.editCreditAccount.CreditAccountAdded += new EntityEditEventHandler(editCreditAccount_CreditAccountAdded);
				this.editCreditAccount.CreditAccountRemoved += new EntityEditEventHandler(editCreditAccount_CreditAccountRemoved);
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "SearchCreditAccountData.Page_Load"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Item added event handler for Credit Account.</summary>
		///
		// ------------------------------------------------------------------------------
		private void editCreditAccount_CreditAccountAdded(BaseFormlUserControl sender, EntityEditEventArgs e)
		{
			if (_collection.Contains(e.Entity))
			{
				Globals.AddErrorMessage(this.Page, "Collection already contains this Credit Account", new object[0]);
			}
			else
			{
				_collection.Add(e.Entity);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Item removed event handler for Credit Account.</summary>
		///
		// ------------------------------------------------------------------------------
		private void editCreditAccount_CreditAccountRemoved(BaseFormlUserControl sender, EntityEditEventArgs e)
		{
			_collection.Add(e.Entity);
		}
		// ------------------------------------------------------------------------------
		/// <summary>Binding for a list of Credit Account.</summary>
		///
		// ------------------------------------------------------------------------------
		private void dgPrimaryList_ItemDataBound(object sender, DataGridItemEventArgs e)
		{
			try
			{
				if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.SelectedItem)
				{
					BLL.Accounts.CreditAccount vCreditAccount = (BLL.Accounts.CreditAccount)e.Item.DataItem;
					SetControlText(e.Item,"lblPrimaryName", MOD.Data.DataHelper.GetString(vCreditAccount.PrimaryName, ""));
					SetControlText(e.Item,"lblCreditCardNumber", MOD.Data.DataHelper.GetString(vCreditAccount.CreditCardNumber, ""));
					SetControlText(e.Item,"lblCreditCardLastFour", MOD.Data.DataHelper.GetString(vCreditAccount.CreditCardLastFour, ""));
					SetControlText(e.Item,"lblCreditCardName", MOD.Data.DataHelper.GetString(vCreditAccount.CreditCardName, ""));
					SetControlText(e.Item,"lblExpirationDate", MOD.Data.DataHelper.GetString(vCreditAccount.ExpirationDate, ""));
					SetControlText(e.Item,"lblCreditCardTypeCode", MOD.Data.DataHelper.GetString(vCreditAccount.CreditCardTypeCode, ""));
					SetControlText(e.Item,"lblCreatedDate", MOD.Data.DataHelper.GetString(vCreditAccount.CreatedDate, ""));
					SetControlText(e.Item,"lblLastModifiedDate", MOD.Data.DataHelper.GetString(vCreditAccount.LastModifiedDate, ""));
					SetControlText(e.Item,"lblAccountName", MOD.Data.DataHelper.GetString(vCreditAccount.AccountName, ""));
					SetControlText(e.Item,"lblAccountSubTypeCode", MOD.Data.DataHelper.GetString(vCreditAccount.AccountSubTypeCode, ""));
					SetControlText(e.Item,"lblCurrencyCode", MOD.Data.DataHelper.GetString(vCreditAccount.CurrencyCode, ""));
					SetControlText(e.Item,"lblDescription", MOD.Data.DataHelper.GetString(vCreditAccount.Description, ""));
					SetControlText(e.Item,"lblIsActive", MOD.Data.DataHelper.GetString(vCreditAccount.IsActive, ""));
					SetControlText(e.Item,"lblCreditCardTypeName", MOD.Data.DataHelper.GetString(vCreditAccount.CreditCardTypeName, MOD.Data.DefaultValue.String));
					LinkButton lnkEdit = (LinkButton)SetControlText(e.Item, "lnkEdit", "Details");
					HyperLink lnkEditOut = (HyperLink)SetControlText(e.Item, "lnkEditOut", "Details");
					foreach (DataGridColumn loopColumn in dgPrimaryList.Columns)
					{
						if (loopColumn.HeaderText == "Primary Name")
						{
							loopColumn.SortExpression = vCreditAccount.PrimarySortColumn;
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
						lnkEditOut.NavigateUrl = Page.ResolveUrl(string.Format("EditCreditAccount.aspx?mode=" + modeValue + "&message=&AccountID={0}&CreditAccountAccountID={1}", vCreditAccount.AccountID, vCreditAccount.AccountID));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "SearchCreditAccountData.dgPrimaryList_ItemDataBound"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set Credit Account information from the ui.</summary>
		///
		// ------------------------------------------------------------------------------
		protected override void SetDataFromForm()
		{
			Session["CreditCardNumber"] = GetStringFromTextBox(txtCreditCardNumber);
			Session["CreditCardName"] = GetStringFromTextBox(txtCreditCardName);
			Session["ExpirationDateStart"] = GetStringFromTextBox(txtExpirationDateStart);
			Session["ExpirationDateEnd"] = GetStringFromTextBox(txtExpirationDateEnd);
			Session["CreditCardTypeCode"] = GetSelectedValueFromDropDownList(ddlCreditCardTypeCode);
			Session["AccountName"] = GetStringFromTextBox(txtAccountName);
			Session["CurrencyCode"] = GetSelectedValueFromDropDownList(ddlCurrencyCode);
			Session["LastModifiedDateStart"] = GetStringFromTextBox(txtLastModifiedDateStart);
			Session["LastModifiedDateEnd"] = GetStringFromTextBox(txtLastModifiedDateEnd);
		}
		// ------------------------------------------------------------------------------
		/// <summary>Get Credit Account information from the database.</summary>
		///
		// ------------------------------------------------------------------------------
		protected override void LoadCollectionFromDatabase()
		{
			try
			{
				int totalRecords = 0;
				bool maximumListSizeExceeded = false;
				string creditCardNumber = MOD.Data.SearchHelper.GetString(Session["CreditCardNumber"]);
				string creditCardName = MOD.Data.SearchHelper.GetString(Session["CreditCardName"]);
				DateTime? expirationDateStart = MOD.Data.SearchHelper.GetDateTime(Session["ExpirationDateStart"]);
				DateTime? expirationDateEnd = MOD.Data.SearchHelper.GetDateTime(Session["ExpirationDateEnd"]);
				int? creditCardTypeCode = MOD.Data.SearchHelper.GetInt(Session["CreditCardTypeCode"]);
				string accountName = MOD.Data.SearchHelper.GetString(Session["AccountName"]);
				int? currencyCode = MOD.Data.SearchHelper.GetInt(Session["CurrencyCode"]);
				DateTime? lastModifiedDateStart = MOD.Data.SearchHelper.GetDateTime(Session["LastModifiedDateStart"]);
				DateTime? lastModifiedDateEnd = MOD.Data.SearchHelper.GetDateTime(Session["LastModifiedDateEnd"]);
				// get primary list data from database and bind
				if (Page.IsPostBack == true || this.TotalRecords > 0)
				{
					_collection = BLL.Accounts.CreditAccountManager.GetManyCreditAccountDataByCriteria(creditCardNumber, creditCardName, expirationDateStart, expirationDateEnd, creditCardTypeCode, accountName, currencyCode, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, this.DataOptions);
					Session["SearchAccounts/CreditAccountData"] = _collection;
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "SearchCreditAccountData.dgPrimaryList_ItemDataBound"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Item command event handler for Credit Account list.</summary>
		///
		// ------------------------------------------------------------------------------
		public void dgPrimaryList_ItemCommand(object sender, EventArgs e)
		{
			DataGridCommandEventArgs args = (DataGridCommandEventArgs)e;
			if (args.CommandName == "Add" || args.CommandName == "Edit" || args.CommandName == "Delete")
			{
				int hashCode = int.Parse(args.CommandArgument.ToString());
				BLL.Accounts.CreditAccount item = ((BLL.SortableList<BLL.Accounts.CreditAccount>)_collection).Find(hashCode);
				if (args.CommandName == "Add")
				{
					workingCreditAccountData.AddItem(item);
				}
				else if (args.CommandName == "Edit")
				{
					this.editCreditAccount.CreditAccountItem = item;
				}
				else if (args.CommandName == "Delete")
				{
					_collection.Remove(item);
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Page pre render event handler for Credit Account.</summary>
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
					txtCreditCardNumber.Text = MOD.Data.DataHelper.GetString(Session["CreditCardNumber"], "");
					txtCreditCardName.Text = MOD.Data.DataHelper.GetString(Session["CreditCardName"], "");
					txtExpirationDateStart.Text = MOD.Data.DataHelper.GetString(Session["ExpirationDateStart"], "");
					txtExpirationDateEnd.Text = MOD.Data.DataHelper.GetString(Session["ExpirationDateEnd"], "");
					if (ddlCreditCardTypeCode.Visible == true)
					{
						Components.Lists.DataBind(ddlCreditCardTypeCode, BLL.Accounts.CreditCardTypeManager.GetAllCreditCardTypeData(Globals.DBOptions, Globals.getDataOptions("CreditCardTypeName", "", true, true), Globals.DebugLevel, Globals.CurrentUserID), "PrimaryKey", "PrimaryName", true, false);
						ddlCreditCardTypeCode.ClearSelection();
						try
						{
							ddlCreditCardTypeCode.SelectedValue = MOD.Data.DataHelper.GetString(Session["CreditCardTypeCode"], "0");
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
					editCreditAccount.Visible = true;
					btnNew.Visible = false;
				}
				else
				{
					editCreditAccount.Visible = false;
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "SearchCreditAccountData.Page_PreRender"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set access and display modes for presenting Credit Account information.</summary>
		///
		// ------------------------------------------------------------------------------
		private void SetAccessModeAndDisplay(MOD.Data.AccessMode accessMode)
		{
			// set access mode
			AccessMode = accessMode;
			btnNew.Visible = IsEditAvailable;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Request to create a new Credit Account.</summary>
		///
		// ------------------------------------------------------------------------------
		private void btnNew_Click(object sender, EventArgs e)
		{
			Globals.ClearMessages();
			Response.Redirect(Page.ResolveUrl(string.Format("EditCreditAccount.aspx?mode=" + MOD.Data.AccessMode.Add.ToString() + "&AccountID=" + MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, "") + "&CreditAccountAccountID=" + MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, "") + "")));
		}
		
		// ------------------------------------------------------------------------------
		/// <summary>Clear search form for Credit Account.</summary>
		///
		// ------------------------------------------------------------------------------
		private void btnClear_Click(object sender, EventArgs e)
		{
			Globals.ClearMessages();
			this.TotalRecords = 0;
			_collection = null;
			txtCreditCardNumber.Text = "";
			txtCreditCardName.Text = "";
			txtExpirationDateStart.Text = "";
			txtExpirationDateEnd.Text = "";
			ddlCreditCardTypeCode.ClearSelection();
			txtAccountName.Text = "";
			ddlCurrencyCode.ClearSelection();
			txtLastModifiedDateStart.Text = "";
			txtLastModifiedDateEnd.Text = "";
			SetDataFromForm();
		}
		// ------------------------------------------------------------------------------
		/// <summary>Perform search for Credit Account items.</summary>
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "SearchCreditAccountData.btnSearch_Click"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// Handle Expiration Date Start selection change.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		// ------------------------------------------------------------------------------
		private void calExpirationDateStart_SelectionChanged(object sender, EventArgs e)
		{
			txtExpirationDateStart.Text = calExpirationDateStart.SelectedDate.ToShortDateString();
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// HandleExpiration Date Start scheduler.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		// ------------------------------------------------------------------------------
		private void btnExpirationDateStartCalendar_Click(object sender, EventArgs e)
		{
			if (calExpirationDateStart.Visible == false)
			{
				calExpirationDateStart.Visible = true;
				btnExpirationDateStartCalendar.Text = "Hide Calendar";
				ResetExpirationDateStartCalendar(true);
			}
			else
			{
				calExpirationDateStart.Visible = false;
				btnExpirationDateStartCalendar.Text = "Calendar";
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// Handle Expiration Date End selection change.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		// ------------------------------------------------------------------------------
		private void calExpirationDateEnd_SelectionChanged(object sender, EventArgs e)
		{
			txtExpirationDateEnd.Text = calExpirationDateEnd.SelectedDate.ToShortDateString();
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// HandleExpiration Date End scheduler.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		// ------------------------------------------------------------------------------
		private void btnExpirationDateEndCalendar_Click(object sender, EventArgs e)
		{
			if (calExpirationDateEnd.Visible == false)
			{
				calExpirationDateEnd.Visible = true;
				btnExpirationDateEndCalendar.Text = "Hide Calendar";
				ResetExpirationDateEndCalendar(true);
			}
			else
			{
				calExpirationDateEnd.Visible = false;
				btnExpirationDateEndCalendar.Text = "Calendar";
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
		/// Reset Expiration Date Start schedule.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		// ------------------------------------------------------------------------------
		private void ResetExpirationDateStartCalendar(bool resetVisibleDate)
		{
			try
			{
				calExpirationDateStart.SelectedDates.Clear();
				System.DateTime strExpirationDateStart = System.DateTime.Parse(txtExpirationDateStart.Text);
				calExpirationDateStart.SelectedDate = strExpirationDateStart;
				if (resetVisibleDate == true)
				{
					calExpirationDateStart.VisibleDate = strExpirationDateStart;
				}
			}
			catch
			{
				calExpirationDateStart.SelectedDates.Clear();
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// Reset Expiration Date End schedule.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		// ------------------------------------------------------------------------------
		private void ResetExpirationDateEndCalendar(bool resetVisibleDate)
		{
			try
			{
				calExpirationDateEnd.SelectedDates.Clear();
				System.DateTime strExpirationDateEnd = System.DateTime.Parse(txtExpirationDateEnd.Text);
				calExpirationDateEnd.SelectedDate = strExpirationDateEnd;
				if (resetVisibleDate == true)
				{
					calExpirationDateEnd.VisibleDate = strExpirationDateEnd;
				}
			}
			catch
			{
				calExpirationDateEnd.SelectedDates.Clear();
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
		/// <summary>Initialize component for CreditAccount, add delegates here.</summary>
		///
		// ------------------------------------------------------------------------------
		private void InitializeComponent()
		{
			this.calExpirationDateStart.SelectionChanged += new System.EventHandler(calExpirationDateStart_SelectionChanged);
			this.btnExpirationDateStartCalendar.Click += new EventHandler(btnExpirationDateStartCalendar_Click);
			this.calExpirationDateEnd.SelectionChanged += new System.EventHandler(calExpirationDateEnd_SelectionChanged);
			this.btnExpirationDateEndCalendar.Click += new EventHandler(btnExpirationDateEndCalendar_Click);
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