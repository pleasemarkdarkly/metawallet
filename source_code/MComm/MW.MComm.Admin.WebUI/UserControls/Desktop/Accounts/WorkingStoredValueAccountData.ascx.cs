
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
	/// <summary>Working Stored Value Account Data is used to help manage StoredValueAccount information.</summary>
	///
	/// File History:
	/// <created>6/1/2007 (Chris Grundy)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class WorkingStoredValueAccountData  : Components.Desktop.BaseListUserControl
	{
		#region Fields
		#endregion Fields
		#region Properties
		public string ListTitle
		{
			get { return lblTitle.Text; }
			set { lblTitle.Text = value; }
		}
		public DataGrid DataGrid { get { return dgPrimaryList; } }
		#endregion Properties
		#region Event Handlers
		// ------------------------------------------------------------------------------
		/// <summary>Load page for Stored Value Account listing.</summary>
		///
		// ------------------------------------------------------------------------------
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				base.OnLoad(); // base list control manages loading data
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "WorkingStoredValueAccountData.Page_Load"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Binding for a list of Stored Value Account.</summary>
		///
		// ------------------------------------------------------------------------------
		private void dgPrimaryList_ItemDataBound(object sender, DataGridItemEventArgs e)
		{
			try
			{
				if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.SelectedItem)
				{
					BLL.Accounts.StoredValueAccount vStoredValueAccount = (BLL.Accounts.StoredValueAccount)e.Item.DataItem;
					SetControlText(e.Item,"lblPrimaryName", MOD.Data.DataHelper.GetString(vStoredValueAccount.PrimaryName, ""));
					SetControlText(e.Item,"lblBalance", MOD.Data.DataHelper.GetString(vStoredValueAccount.Balance, ""));
					SetControlText(e.Item,"lblCreatedDate", MOD.Data.DataHelper.GetString(vStoredValueAccount.CreatedDate, ""));
					SetControlText(e.Item,"lblLastModifiedDate", MOD.Data.DataHelper.GetString(vStoredValueAccount.LastModifiedDate, ""));
					SetControlText(e.Item,"lblDebitAccountNumber", MOD.Data.DataHelper.GetString(vStoredValueAccount.DebitAccountNumber, ""));
					SetControlText(e.Item,"lblIsDefaultDebitAccount", MOD.Data.DataHelper.GetString(vStoredValueAccount.IsDefaultDebitAccount, ""));
					SetControlText(e.Item,"lblBankCustomerCode", MOD.Data.DataHelper.GetString(vStoredValueAccount.BankCustomerCode, ""));
					SetControlText(e.Item,"lblAccountName", MOD.Data.DataHelper.GetString(vStoredValueAccount.AccountName, ""));
					SetControlText(e.Item,"lblAccountSubTypeCode", MOD.Data.DataHelper.GetString(vStoredValueAccount.AccountSubTypeCode, ""));
					SetControlText(e.Item,"lblCurrencyCode", MOD.Data.DataHelper.GetString(vStoredValueAccount.CurrencyCode, ""));
					SetControlText(e.Item,"lblDescription", MOD.Data.DataHelper.GetString(vStoredValueAccount.Description, ""));
					SetControlText(e.Item,"lblIsActive", MOD.Data.DataHelper.GetString(vStoredValueAccount.IsActive, ""));
					SetControlText(e.Item,"lblPhoneNumber", MOD.Data.DataHelper.GetString(vStoredValueAccount.PhoneNumber, MOD.Data.DefaultValue.String));
					HyperLink lnkEditOut = (HyperLink)SetControlText(e.Item, "lnkEditOut", "Details");
					foreach (DataGridColumn loopColumn in dgPrimaryList.Columns)
					{
						if (loopColumn.HeaderText == "Primary Name")
						{
							loopColumn.SortExpression = vStoredValueAccount.PrimarySortColumn;
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
						string modeValue = "edit";
						if (IsEditAvailable == false)
						{
							modeValue = "view";
						}
						lnkEditOut.NavigateUrl = Page.ResolveUrl(string.Format("EditStoredValueAccount.aspx?mode=" + modeValue + "&message=&AccountID={0}&StoredValueAccountAccountID={1}", vStoredValueAccount.AccountID, vStoredValueAccount.AccountID));
					}
					System.Web.UI.Control lnkDelete = SetControlText(e.Item, "lnkDelete", "Remove");
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "WorkingStoredValueAccountData.dgPrimaryList_ItemDataBound"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Get Stored Value Account information from the database.</summary>
		///
		// ------------------------------------------------------------------------------
		protected override void LoadCollectionFromDatabase()
		{
			_collection = (BLL.SortableList<BLL.Accounts.StoredValueAccount>) Session["Accounts/StoredValueAccountWorkingSet"];
			if (_collection != null)
			{
				((BLL.SortableList<BLL.Accounts.StoredValueAccount>)_collection).Sort(SortColumn, SortDirection);
				TotalRecords = _collection.Count;
			}
			else
			{
				TotalRecords = 0;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Item command event handler for Stored Value Account list.</summary>
		///
		// ------------------------------------------------------------------------------
		public void dgPrimaryList_ItemCommand(object sender, EventArgs e)
		{
			_collection = (BLL.SortableList<BLL.Accounts.StoredValueAccount>) Session["Accounts/StoredValueAccountWorkingSet"];
			if (_collection != null)
			{
				DataGridCommandEventArgs args = (DataGridCommandEventArgs)e;
				if (args.CommandName == "Delete")
				{
					int hashCode = int.Parse(args.CommandArgument.ToString());
					BLL.Accounts.StoredValueAccount item = ((BLL.SortableList<BLL.Accounts.StoredValueAccount>)_collection).Find(hashCode);
					if (item != null)
					{
						RemoveItem(item);
					}
				}
				else if (args.CommandName == "Select")
				{
					int hashCode = int.Parse(args.CommandArgument.ToString());
					BLL.Accounts.StoredValueAccount item = ((BLL.SortableList<BLL.Accounts.StoredValueAccount>)_collection).Find(hashCode);
					Session["Accounts/StoredValueAccountWorkingSetItem"] = item.PrimaryIndex;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Item command event handler for Stored Value Account list.</summary>
		///
		// ------------------------------------------------------------------------------
		public void AddItem(BLL.Accounts.StoredValueAccount item)
		{
			_collection = (BLL.SortableList<BLL.Accounts.StoredValueAccount>) Session["Accounts/StoredValueAccountWorkingSet"];
			if (_collection == null)
			{
				_collection = new BLL.SortableList<BLL.Accounts.StoredValueAccount>();
			}
			Globals.ClearMessages();
			if (_collection.Contains(item))
			{
				Globals.AddErrorMessage(this.Page, "Working set already contains this Asset", new object[0]);
			}
			else
			{
				_collection.Add(item);
				((BLL.SortableList<BLL.Accounts.StoredValueAccount>)_collection).Sort(SortColumn, SortDirection);
				TotalRecords = _collection.Count;
				Session["Accounts/StoredValueAccountWorkingSetItem"] = item.PrimaryIndex;
				Globals.AddStatusMessage("Stored Value Account working set item added.");
			}
			Session["Accounts/StoredValueAccountWorkingSet"] = _collection;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Item command event handler for Stored Value Account list.</summary>
		///
		// ------------------------------------------------------------------------------
		public void RemoveItem(BLL.Accounts.StoredValueAccount item)
		{
			Globals.ClearMessages();
			_collection = (BLL.SortableList<BLL.Accounts.StoredValueAccount>) Session["Accounts/StoredValueAccountWorkingSet"];
			if (_collection != null)
			{
				_collection.Remove(item);
				((BLL.SortableList<BLL.Accounts.StoredValueAccount>)_collection).Sort(SortColumn, SortDirection);
				TotalRecords = _collection.Count;
				if (_collection.Count == 0)
				{
					_collection = null;
				}
				Globals.AddStatusMessage("Stored Value Account working set item removed.");
			}
			Session["Accounts/StoredValueAccountWorkingSet"] = _collection;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Page pre render event handler for Stored Value Account.</summary>
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
				this.lblTitle.Visible = TotalRecords > 0;
				this.dgPrimaryList.Visible = TotalRecords > 0;
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "WorkingStoredValueAccountData.Page_PreRender"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set access and display modes for presenting Stored Value Account information.</summary>
		///
		// ------------------------------------------------------------------------------
		private void SetAccessModeAndDisplay(MOD.Data.AccessMode accessMode)
		{
			// set access mode
			AccessMode = accessMode;
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
		/// <summary>Initialize component for StoredValueAccount, add delegates here.</summary>
		///
		// ------------------------------------------------------------------------------
		private void InitializeComponent()
		{
			this.dgPrimaryList.ItemDataBound += new DataGridItemEventHandler(dgPrimaryList_ItemDataBound);
			this.dgPrimaryList.SortCommand += new DataGridSortCommandEventHandler(OnListSort);
			this.Load += new System.EventHandler(this.Page_Load);
			this.PreRender += new EventHandler(Page_PreRender);
		}
		#endregion
	}
}