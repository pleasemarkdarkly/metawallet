
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
using MW.MComm.WalletSolution.BLL.Orders;
using CoreUtility = MW.MComm.WalletSolution.Utility;
using MW.MComm.Admin.WebUI.Components.Desktop;
namespace MW.MComm.Admin.WebUI.UserControls.Desktop.Orders
{
	// ------------------------------------------------------------------------------
	/// <summary>List Order Data is used to help manage Order information.</summary>
	///
	/// File History:
	/// <created>6/1/2007 (Chris Grundy)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class ListOrderData  : Components.Desktop.BaseListUserControl
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
				editOrder.UseValidation = value;
			}
		}
		public DataGrid DataGrid { get { return dgPrimaryList; } }
		#endregion Properties
		#region Event Handlers
		// ------------------------------------------------------------------------------
		/// <summary>Load page for Order listing.</summary>
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
					this.editOrder.OrderItem = (BLL.Orders.Order) Collection[_selectedIndex];
				}
				this.editOrder.OrderAdded += new EntityEditEventHandler(editOrder_OrderAdded);
				this.editOrder.OrderRemoved += new EntityEditEventHandler(editOrder_OrderRemoved);
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "ListOrderData.Page_Load"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Item added event handler for Order.</summary>
		///
		// ------------------------------------------------------------------------------
		private void editOrder_OrderAdded(BaseFormlUserControl sender, EntityEditEventArgs e)
		{
			Globals.ClearMessages();
			_collection.Add(e.Entity);
			Globals.AddStatusMessage("Order added.");
		}
		// ------------------------------------------------------------------------------
		/// <summary>Item removed event handler for Order.</summary>
		///
		// ------------------------------------------------------------------------------
		private void editOrder_OrderRemoved(BaseFormlUserControl sender, EntityEditEventArgs e)
		{
			Globals.ClearMessages();
			_collection.Remove(e.Entity);
			Globals.AddStatusMessage("Order removed.");
		}
		// ------------------------------------------------------------------------------
		/// <summary>Binding for a list of Order.</summary>
		///
		// ------------------------------------------------------------------------------
		private void dgPrimaryList_ItemDataBound(object sender, DataGridItemEventArgs e)
		{
			try
			{
				if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.SelectedItem)
				{
					BLL.Orders.Order vOrder = (BLL.Orders.Order)e.Item.DataItem;
					SetControlText(e.Item,"lblPrimaryName", MOD.Data.DataHelper.GetString(vOrder.PrimaryName, ""));
					SetControlText(e.Item,"lblOrderDescription", MOD.Data.DataHelper.GetString(vOrder.OrderDescription, ""));
					SetControlText(e.Item,"lblOrderAmount", MOD.Data.DataHelper.GetString(vOrder.OrderAmount, ""));
					SetControlText(e.Item,"lblOrderSubtotal", MOD.Data.DataHelper.GetString(vOrder.OrderSubtotal, ""));
					SetControlText(e.Item,"lblOrderTax", MOD.Data.DataHelper.GetString(vOrder.OrderTax, ""));
					SetControlText(e.Item,"lblOrderServiceCharge", MOD.Data.DataHelper.GetString(vOrder.OrderServiceCharge, ""));
					SetControlText(e.Item,"lblCurrencyCode", MOD.Data.DataHelper.GetString(vOrder.CurrencyCode, ""));
					SetControlText(e.Item,"lblOrderStatusCode", MOD.Data.DataHelper.GetString(vOrder.OrderStatusCode, ""));
					SetControlText(e.Item,"lblOrderStatusMessage", MOD.Data.DataHelper.GetString(vOrder.OrderStatusMessage, ""));
					SetControlText(e.Item,"lblCreatedDate", MOD.Data.DataHelper.GetString(vOrder.CreatedDate, ""));
					SetControlText(e.Item,"lblLastModifiedDate", MOD.Data.DataHelper.GetString(vOrder.LastModifiedDate, ""));
					SetControlText(e.Item,"lblMetaPartnerName", MOD.Data.DataHelper.GetString(vOrder.MetaPartnerName, MOD.Data.DefaultValue.String));
					SetControlText(e.Item,"lblDateFormatCode", MOD.Data.DataHelper.GetInt(vOrder.DateFormatCode, MOD.Data.DefaultValue.Int));
					SetControlText(e.Item,"lblAccountName", MOD.Data.DataHelper.GetString(vOrder.AccountName, MOD.Data.DefaultValue.String));
					SetControlText(e.Item,"lblCurrencyName", MOD.Data.DataHelper.GetString(vOrder.CurrencyName, MOD.Data.DefaultValue.String));
					SetControlText(e.Item,"lblOrderStatusName", MOD.Data.DataHelper.GetString(vOrder.OrderStatusName, MOD.Data.DefaultValue.String));
					LinkButton lnkEdit = (LinkButton)SetControlText(e.Item, "lnkEdit", "Details");
					HyperLink lnkEditOut = (HyperLink)SetControlText(e.Item, "lnkEditOut", "Details");
					foreach (DataGridColumn loopColumn in dgPrimaryList.Columns)
					{
						if (loopColumn.HeaderText == "Primary Name")
						{
							loopColumn.SortExpression = vOrder.PrimarySortColumn;
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
						lnkEditOut.NavigateUrl = Page.ResolveUrl(string.Format("EditOrder.aspx?mode=" + modeValue + "&message=&OrderID={0}", vOrder.OrderID));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "ListOrderData.dgPrimaryList_ItemDataBound"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Get Order information from the database.</summary>
		///
		// ------------------------------------------------------------------------------
		protected override void LoadCollectionFromDatabase()
		{
			_collection = BLL.Orders.OrderManager.GetAllOrderData(Globals.DBOptions, DataOptions, Globals.DebugLevel, Globals.CurrentUserID);
		}
		// ------------------------------------------------------------------------------
		/// <summary>Item command event handler for Order list.</summary>
		///
		// ------------------------------------------------------------------------------
		public void dgPrimaryList_ItemCommand(object sender, EventArgs e)
		{
			DataGridCommandEventArgs args = (DataGridCommandEventArgs)e;
			if (args.CommandName == "Edit" || args.CommandName == "Delete")
			{
				int hashCode = int.Parse(args.CommandArgument.ToString());
				BLL.Orders.Order item = ((BLL.SortableList<BLL.Orders.Order>)_collection).Find(hashCode);
				if (args.CommandName == "Edit")
				{
					this.editOrder.OrderItem = item;
					this.editOrder.AccessMode = MOD.Data.AccessMode.Edit;
				}
				else if (args.CommandName == "Delete")
				{
					Globals.ClearMessages();
					_collection.Remove(item);
					if (this.editOrder.OrderItem == item)
					{
						this.editOrder.AccessMode = MOD.Data.AccessMode.Add;
					}
					Globals.AddStatusMessage("Order removed.");
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Page pre render event handler for Order.</summary>
		///
		// ------------------------------------------------------------------------------
		private void Page_PreRender(object sender, EventArgs e)
		{
			try
			{
				SetAccessModeAndDisplay(AccessMode);
				base.OnPreRender();
				dgPrimaryList.DataSource = _collection;
				dgPrimaryList.DataKeyField = "OrderID";
				dgPrimaryList.DataBind();
				if (this.WorkflowMode == MOD.Data.WorkflowMode.Internal)
				{
					editOrder.Visible = true;
					btnNew.Visible = false;
				}
				else
				{
					editOrder.Visible = false;
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "ListOrderData.Page_PreRender"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set access and display modes for presenting Order information.</summary>
		///
		// ------------------------------------------------------------------------------
		private void SetAccessModeAndDisplay(MOD.Data.AccessMode accessMode)
		{
			// set access mode
			AccessMode = accessMode;
			btnNew.Visible = IsEditAvailable;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Request to create a new Order.</summary>
		///
		// ------------------------------------------------------------------------------
		private void btnNew_Click(object sender, EventArgs e)
		{
			Globals.ClearMessages();
			Response.Redirect(Page.ResolveUrl(string.Format("EditOrder.aspx?mode=" + MOD.Data.AccessMode.Add.ToString() + "&OrderID=" + MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, "") + "")));
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
		/// <summary>Initialize component for Order, add delegates here.</summary>
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