
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
	/// <summary>List Debit Account Data is used to help manage DebitAccount information.</summary>
	///
	/// File History:
	/// <created>6/1/2007 (Chris Grundy)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class ListDebitAccountData  : Components.Desktop.BaseListUserControl
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
				editDebitAccount.UseValidation = value;
			}
		}
		public DataGrid DataGrid { get { return dgPrimaryList; } }
		#endregion Properties
		#region Event Handlers
		// ------------------------------------------------------------------------------
		/// <summary>Load page for Debit Account listing.</summary>
		///
		// ------------------------------------------------------------------------------
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				base.OnLoad(); // base list control manages loading data
				// Set current item into child control
				if (_selectedIndex > -1)
				{
					this.editDebitAccount.DebitAccountItem = (BLL.Accounts.DebitAccount) Collection[_selectedIndex];
				}
				this.editDebitAccount.DebitAccountAdded += new EntityEditEventHandler(editDebitAccount_DebitAccountAdded);
				this.editDebitAccount.DebitAccountRemoved += new EntityEditEventHandler(editDebitAccount_DebitAccountRemoved);
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "ListDebitAccountData.Page_Load"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Item added event handler for Debit Account.</summary>
		///
		// ------------------------------------------------------------------------------
		private void editDebitAccount_DebitAccountAdded(BaseFormlUserControl sender, EntityEditEventArgs e)
		{
			Globals.ClearMessages();
			_collection.Add(e.Entity);
			Globals.AddStatusMessage("Debit Account added.");
		}
		// ------------------------------------------------------------------------------
		/// <summary>Item removed event handler for Debit Account.</summary>
		///
		// ------------------------------------------------------------------------------
		private void editDebitAccount_DebitAccountRemoved(BaseFormlUserControl sender, EntityEditEventArgs e)
		{
			Globals.ClearMessages();
			_collection.Remove(e.Entity);
			Globals.AddStatusMessage("Debit Account removed.");
		}
		// ------------------------------------------------------------------------------
		/// <summary>Binding for a list of Debit Account.</summary>
		///
		// ------------------------------------------------------------------------------
		private void dgPrimaryList_ItemDataBound(object sender, DataGridItemEventArgs e)
		{
			try
			{
				if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.SelectedItem)
				{
					BLL.Accounts.DebitAccount vDebitAccount = (BLL.Accounts.DebitAccount)e.Item.DataItem;
					SetControlText(e.Item,"lblPrimaryName", MOD.Data.DataHelper.GetString(vDebitAccount.PrimaryName, ""));
					SetControlText(e.Item,"lblDebitAccountNumber", MOD.Data.DataHelper.GetString(vDebitAccount.DebitAccountNumber, ""));
					SetControlText(e.Item,"lblIsDefaultDebitAccount", MOD.Data.DataHelper.GetString(vDebitAccount.IsDefaultDebitAccount, ""));
					SetControlText(e.Item,"lblBankCustomerCode", MOD.Data.DataHelper.GetString(vDebitAccount.BankCustomerCode, ""));
					SetControlText(e.Item,"lblCreatedDate", MOD.Data.DataHelper.GetString(vDebitAccount.CreatedDate, ""));
					SetControlText(e.Item,"lblLastModifiedDate", MOD.Data.DataHelper.GetString(vDebitAccount.LastModifiedDate, ""));
					SetControlText(e.Item,"lblAccountName", MOD.Data.DataHelper.GetString(vDebitAccount.AccountName, ""));
					SetControlText(e.Item,"lblAccountSubTypeCode", MOD.Data.DataHelper.GetString(vDebitAccount.AccountSubTypeCode, ""));
					SetControlText(e.Item,"lblCurrencyCode", MOD.Data.DataHelper.GetString(vDebitAccount.CurrencyCode, ""));
					SetControlText(e.Item,"lblDescription", MOD.Data.DataHelper.GetString(vDebitAccount.Description, ""));
					SetControlText(e.Item,"lblIsActive", MOD.Data.DataHelper.GetString(vDebitAccount.IsActive, ""));
					LinkButton lnkEdit = (LinkButton)SetControlText(e.Item, "lnkEdit", "Details");
					HyperLink lnkEditOut = (HyperLink)SetControlText(e.Item, "lnkEditOut", "Details");
					foreach (DataGridColumn loopColumn in dgPrimaryList.Columns)
					{
						if (loopColumn.HeaderText == "Primary Name")
						{
							loopColumn.SortExpression = vDebitAccount.PrimarySortColumn;
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
						lnkEditOut.NavigateUrl = Page.ResolveUrl(string.Format("EditDebitAccount.aspx?mode=" + modeValue + "&message=&AccountID={0}&DebitAccountAccountID={1}", vDebitAccount.AccountID, vDebitAccount.AccountID));
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
				}
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "ListDebitAccountData.dgPrimaryList_ItemDataBound"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Get Debit Account information from the database.</summary>
		///
		// ------------------------------------------------------------------------------
		protected override void LoadCollectionFromDatabase()
		{
			Guid accountID = MOD.Data.DataHelper.GetGuid(Request.QueryString["AccountID"], MOD.Data.DefaultValue.Guid);
			if (accountID!= MOD.Data.DefaultValue.Guid)
			{
				_collection = BLL.Accounts.DebitAccountManager.GetAllDebitAccountDataByAccountID(accountID, Globals.DBOptions, DataOptions, Globals.DebugLevel, Globals.CurrentUserID);
			}
			else
			{
				_collection = BLL.Accounts.DebitAccountManager.GetAllDebitAccountData(Globals.DBOptions, DataOptions, Globals.DebugLevel, Globals.CurrentUserID);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Item command event handler for Debit Account list.</summary>
		///
		// ------------------------------------------------------------------------------
		public void dgPrimaryList_ItemCommand(object sender, EventArgs e)
		{
			DataGridCommandEventArgs args = (DataGridCommandEventArgs)e;
			if (args.CommandName == "Edit" || args.CommandName == "Delete")
			{
				int hashCode = int.Parse(args.CommandArgument.ToString());
				BLL.Accounts.DebitAccount item = ((BLL.SortableList<BLL.Accounts.DebitAccount>)_collection).Find(hashCode);
				if (args.CommandName == "Edit")
				{
					this.editDebitAccount.DebitAccountItem = item;
					this.editDebitAccount.AccessMode = MOD.Data.AccessMode.Edit;
				}
				else if (args.CommandName == "Delete")
				{
					Globals.ClearMessages();
					_collection.Remove(item);
					if (this.editDebitAccount.DebitAccountItem == item)
					{
						this.editDebitAccount.AccessMode = MOD.Data.AccessMode.Add;
					}
					Globals.AddStatusMessage("Debit Account removed.");
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Page pre render event handler for Debit Account.</summary>
		///
		// ------------------------------------------------------------------------------
		private void Page_PreRender(object sender, EventArgs e)
		{
			try
			{
				SetAccessModeAndDisplay(AccessMode);
				base.OnPreRender();
				dgPrimaryList.DataSource = _collection;
				dgPrimaryList.DataKeyField = "AccountID";
				dgPrimaryList.DataBind();
				if (this.WorkflowMode == MOD.Data.WorkflowMode.Internal)
				{
					editDebitAccount.Visible = true;
					btnNew.Visible = false;
				}
				else
				{
					editDebitAccount.Visible = false;
					btnNew.Visible = true;
				}
				if (btnNew.Visible == true)
				{
					btnNew.Visible = IsEditAvailable;
				}
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "ListDebitAccountData.Page_PreRender"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set access and display modes for presenting Debit Account information.</summary>
		///
		// ------------------------------------------------------------------------------
		private void SetAccessModeAndDisplay(MOD.Data.AccessMode accessMode)
		{
			// set access mode
			AccessMode = accessMode;
			btnNew.Visible = IsEditAvailable;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Request to create a new Debit Account.</summary>
		///
		// ------------------------------------------------------------------------------
		private void btnNew_Click(object sender, EventArgs e)
		{
			Globals.ClearMessages();
			Response.Redirect(Page.ResolveUrl(string.Format("EditDebitAccount.aspx?mode=" + MOD.Data.AccessMode.Add.ToString() + "&AccountID=" + MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, "") + "&DebitAccountAccountID=" + MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, "") + "")));
		}
		#endregion Event Handlers
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
		/// <summary>Initialize component for DebitAccount, add delegates here.</summary>
		///
		// ------------------------------------------------------------------------------
		private void InitializeComponent()
		{
			this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
			this.dgPrimaryList.ItemDataBound += new DataGridItemEventHandler(dgPrimaryList_ItemDataBound);
			this.dgPrimaryList.SortCommand += new DataGridSortCommandEventHandler(OnListSort);
			this.Load += new System.EventHandler(this.Page_Load);
			this.PreRender += new EventHandler(Page_PreRender);
		}
		#endregion
	}
}