
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
using MW.MComm.WalletSolution.BLL.Customers;
using CoreUtility = MW.MComm.WalletSolution.Utility;
using MW.MComm.Admin.WebUI.Components.Desktop;
namespace MW.MComm.Admin.WebUI.UserControls.Desktop.Customers
{
	// ------------------------------------------------------------------------------
	/// <summary>Search Bank Data is used to help manage Bank information.</summary>
	///
	/// File History:
	/// <created>6/1/2007 (Chris Grundy)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class SearchBankData  : Components.Desktop.BaseSearchUserControl
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
				editBank.UseValidation = value;
			}
		}
		public DataGrid DataGrid { get { return dgPrimaryList; } }
		#endregion Properties
		#region Event Handlers
		// ------------------------------------------------------------------------------
		/// <summary>Load page for Bank search.</summary>
		///
		// ------------------------------------------------------------------------------
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				workingBankData.Visible = ProvideWorkingSet;
				base.OnLoad(); // base list control manages loading data
				if (WorkflowMode != WorkflowMode.Internal)
				{
					if (Session["SearchCustomers/BankData"] != null)
					{
						_collection = (BLL.SortableList<BLL.Customers.Bank>)Session["SearchCustomers/BankData"];
					}
				}
				// Set current item into child control
				if (_selectedIndex > -1)
				{
					this.editBank.BankItem = (BLL.Customers.Bank) Collection[_selectedIndex];
				}
				this.editBank.BankAdded += new EntityEditEventHandler(editBank_BankAdded);
				this.editBank.BankRemoved += new EntityEditEventHandler(editBank_BankRemoved);
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "SearchBankData.Page_Load"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Item added event handler for Bank.</summary>
		///
		// ------------------------------------------------------------------------------
		private void editBank_BankAdded(BaseFormlUserControl sender, EntityEditEventArgs e)
		{
			if (_collection.Contains(e.Entity))
			{
				Globals.AddErrorMessage(this.Page, "Collection already contains this Bank", new object[0]);
			}
			else
			{
				_collection.Add(e.Entity);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Item removed event handler for Bank.</summary>
		///
		// ------------------------------------------------------------------------------
		private void editBank_BankRemoved(BaseFormlUserControl sender, EntityEditEventArgs e)
		{
			_collection.Add(e.Entity);
		}
		// ------------------------------------------------------------------------------
		/// <summary>Binding for a list of Bank.</summary>
		///
		// ------------------------------------------------------------------------------
		private void dgPrimaryList_ItemDataBound(object sender, DataGridItemEventArgs e)
		{
			try
			{
				if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.SelectedItem)
				{
					BLL.Customers.Bank vBank = (BLL.Customers.Bank)e.Item.DataItem;
					SetControlText(e.Item,"lblPrimaryName", MOD.Data.DataHelper.GetString(vBank.PrimaryName, ""));
					SetControlText(e.Item,"lblBankCode", MOD.Data.DataHelper.GetString(vBank.BankCode, ""));
					SetControlText(e.Item,"lblCreatedDate", MOD.Data.DataHelper.GetString(vBank.CreatedDate, ""));
					SetControlText(e.Item,"lblLastModifiedDate", MOD.Data.DataHelper.GetString(vBank.LastModifiedDate, ""));
					SetControlText(e.Item,"lblServiceCharges", MOD.Data.DataHelper.GetString(vBank.ServiceCharges, ""));
					SetControlText(e.Item,"lblMetaPartnerSubTypeCode", MOD.Data.DataHelper.GetString(vBank.MetaPartnerSubTypeCode, ""));
					SetControlText(e.Item,"lblLocaleCode", MOD.Data.DataHelper.GetString(vBank.LocaleCode, ""));
					SetControlText(e.Item,"lblCurrencyCode", MOD.Data.DataHelper.GetString(vBank.CurrencyCode, ""));
					SetControlText(e.Item,"lblDateFormatCode", MOD.Data.DataHelper.GetString(vBank.DateFormatCode, ""));
					SetControlText(e.Item,"lblTaxCode", MOD.Data.DataHelper.GetString(vBank.TaxCode, ""));
					SetControlText(e.Item,"lblIsActive", MOD.Data.DataHelper.GetString(vBank.IsActive, ""));
					SetControlText(e.Item,"lblMetaPartnerName", MOD.Data.DataHelper.GetString(vBank.MetaPartnerName, ""));
					System.Web.UI.WebControls.Image lblPictureImageURL = (System.Web.UI.WebControls.Image)e.Item.FindControl("lblPictureImageURL");
					lblPictureImageURL.ImageUrl = CoreUtility.FileManager.GetAbsoluteHttpUrl(CoreUtility.FileGroupCode.Customers, vBank.PictureImageURL, Page.ResolveUrl("~/images/missing_image-75.jpg"));
					HyperLink lnkPictureImageURL = (HyperLink)e.Item.FindControl("lnkPictureImageURL");
					lnkPictureImageURL.NavigateUrl = Page.ResolveUrl(CoreUtility.FileManager.GetAbsoluteHttpUrl(CoreUtility.FileGroupCode.Customers, vBank.PictureImageURL, Page.ResolveUrl("~/images/missing_image-75.jpg")));
					LinkButton lnkEdit = (LinkButton)SetControlText(e.Item, "lnkEdit", "Details");
					HyperLink lnkEditOut = (HyperLink)SetControlText(e.Item, "lnkEditOut", "Details");
					foreach (DataGridColumn loopColumn in dgPrimaryList.Columns)
					{
						if (loopColumn.HeaderText == "Primary Name")
						{
							loopColumn.SortExpression = vBank.PrimarySortColumn;
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
						lnkEditOut.NavigateUrl = Page.ResolveUrl(string.Format("EditBank.aspx?mode=" + modeValue + "&message=&MetaPartnerID={0}&BankMetaPartnerID={1}", vBank.MetaPartnerID, vBank.MetaPartnerID));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "SearchBankData.dgPrimaryList_ItemDataBound"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set Bank information from the ui.</summary>
		///
		// ------------------------------------------------------------------------------
		protected override void SetDataFromForm()
		{
			Session["LocaleCode"] = GetSelectedValueFromDropDownList(ddlLocaleCode);
			Session["CurrencyCode"] = GetSelectedValueFromDropDownList(ddlCurrencyCode);
			Session["DateFormatCode"] = GetSelectedValueFromDropDownList(ddlDateFormatCode);
			Session["LastModifiedDateStart"] = GetStringFromTextBox(txtLastModifiedDateStart);
			Session["LastModifiedDateEnd"] = GetStringFromTextBox(txtLastModifiedDateEnd);
			Session["MetaPartnerName"] = GetStringFromTextBox(txtMetaPartnerName);
		}
		// ------------------------------------------------------------------------------
		/// <summary>Get Bank information from the database.</summary>
		///
		// ------------------------------------------------------------------------------
		protected override void LoadCollectionFromDatabase()
		{
			try
			{
				int totalRecords = 0;
				bool maximumListSizeExceeded = false;
				int? localeCode = MOD.Data.SearchHelper.GetInt(Session["LocaleCode"]);
				int? currencyCode = MOD.Data.SearchHelper.GetInt(Session["CurrencyCode"]);
				int? dateFormatCode = MOD.Data.SearchHelper.GetInt(Session["DateFormatCode"]);
				DateTime? lastModifiedDateStart = MOD.Data.SearchHelper.GetDateTime(Session["LastModifiedDateStart"]);
				DateTime? lastModifiedDateEnd = MOD.Data.SearchHelper.GetDateTime(Session["LastModifiedDateEnd"]);
				string metaPartnerName = MOD.Data.SearchHelper.GetString(Session["MetaPartnerName"]);
				// get primary list data from database and bind
				if (Page.IsPostBack == true || this.TotalRecords > 0)
				{
					_collection = BLL.Customers.BankManager.GetManyBankDataByCriteria(localeCode, currencyCode, dateFormatCode, lastModifiedDateStart, lastModifiedDateEnd, metaPartnerName, out totalRecords, out maximumListSizeExceeded, this.DataOptions);
					Session["SearchCustomers/BankData"] = _collection;
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "SearchBankData.dgPrimaryList_ItemDataBound"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Item command event handler for Bank list.</summary>
		///
		// ------------------------------------------------------------------------------
		public void dgPrimaryList_ItemCommand(object sender, EventArgs e)
		{
			DataGridCommandEventArgs args = (DataGridCommandEventArgs)e;
			if (args.CommandName == "Add" || args.CommandName == "Edit" || args.CommandName == "Delete")
			{
				int hashCode = int.Parse(args.CommandArgument.ToString());
				BLL.Customers.Bank item = ((BLL.SortableList<BLL.Customers.Bank>)_collection).Find(hashCode);
				if (args.CommandName == "Add")
				{
					workingBankData.AddItem(item);
				}
				else if (args.CommandName == "Edit")
				{
					this.editBank.BankItem = item;
				}
				else if (args.CommandName == "Delete")
				{
					_collection.Remove(item);
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Page pre render event handler for Bank.</summary>
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
					if (ddlLocaleCode.Visible == true)
					{
						Components.Lists.DataBind(ddlLocaleCode, BLL.Environments.LocaleManager.GetAllLocaleData(Globals.DBOptions, Globals.getDataOptions("LocaleName", "", true, true), Globals.DebugLevel, Globals.CurrentUserID), "PrimaryKey", "PrimaryName", true, false);
						ddlLocaleCode.ClearSelection();
						try
						{
							ddlLocaleCode.SelectedValue = MOD.Data.DataHelper.GetString(Session["LocaleCode"], "0");
						}
						catch {}
					}
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
					if (ddlDateFormatCode.Visible == true)
					{
						Components.Lists.DataBind(ddlDateFormatCode, BLL.Environments.DateFormatManager.GetAllDateFormatData(Globals.DBOptions, Globals.getDataOptions("DateFormatName", "", true, true), Globals.DebugLevel, Globals.CurrentUserID), "PrimaryKey", "PrimaryName", true, false);
						ddlDateFormatCode.ClearSelection();
						try
						{
							ddlDateFormatCode.SelectedValue = MOD.Data.DataHelper.GetString(Session["DateFormatCode"], "0");
						}
						catch {}
					}
					txtLastModifiedDateStart.Text = MOD.Data.DataHelper.GetString(Session["LastModifiedDateStart"], "");
					txtLastModifiedDateEnd.Text = MOD.Data.DataHelper.GetString(Session["LastModifiedDateEnd"], "");
					txtMetaPartnerName.Text = MOD.Data.DataHelper.GetString(Session["MetaPartnerName"], "");
				}
				dgPrimaryList.DataSource = _collection;
				dgPrimaryList.DataKeyField = "MetaPartnerID";
				dgPrimaryList.DataBind();
				if (this.WorkflowMode == MOD.Data.WorkflowMode.Internal)
				{
					editBank.Visible = true;
					btnNew.Visible = false;
				}
				else
				{
					editBank.Visible = false;
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "SearchBankData.Page_PreRender"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set access and display modes for presenting Bank information.</summary>
		///
		// ------------------------------------------------------------------------------
		private void SetAccessModeAndDisplay(MOD.Data.AccessMode accessMode)
		{
			// set access mode
			AccessMode = accessMode;
			btnNew.Visible = IsEditAvailable;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Request to create a new Bank.</summary>
		///
		// ------------------------------------------------------------------------------
		private void btnNew_Click(object sender, EventArgs e)
		{
			Globals.ClearMessages();
			Response.Redirect(Page.ResolveUrl(string.Format("EditBank.aspx?mode=" + MOD.Data.AccessMode.Add.ToString() + "&MetaPartnerID=" + MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, "") + "&BankMetaPartnerID=" + MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, "") + "")));
		}
		
		// ------------------------------------------------------------------------------
		/// <summary>Clear search form for Bank.</summary>
		///
		// ------------------------------------------------------------------------------
		private void btnClear_Click(object sender, EventArgs e)
		{
			Globals.ClearMessages();
			this.TotalRecords = 0;
			_collection = null;
			ddlLocaleCode.ClearSelection();
			ddlCurrencyCode.ClearSelection();
			ddlDateFormatCode.ClearSelection();
			txtLastModifiedDateStart.Text = "";
			txtLastModifiedDateEnd.Text = "";
			txtMetaPartnerName.Text = "";
			SetDataFromForm();
		}
		// ------------------------------------------------------------------------------
		/// <summary>Perform search for Bank items.</summary>
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "SearchBankData.btnSearch_Click"));
			}
			finally
			{
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
		/// <summary>Initialize component for Bank, add delegates here.</summary>
		///
		// ------------------------------------------------------------------------------
		private void InitializeComponent()
		{
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