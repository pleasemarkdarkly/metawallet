
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
using System.Collections.Specialized;
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
	/// <summary>Edit Order is used to help manage Order information.</summary>
	///
	/// File History:
	/// <created>6/1/2007 (Chris Grundy)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class EditOrder  : Components.Desktop.BaseFormlUserControl
	{
		#region Events
		/// <summary>
		/// Raised when "Add" button is clicked in internal mode.
		/// Container handles this event and adds entity to collection.
		/// </summary>
		public event EntityEditEventHandler OrderAdded;
		/// <summary>
		/// Raised when "Remove" button is clicked in internal mode.
		/// Container handles this event and removes entity from collection.
		/// </summary>
		public event EntityEditEventHandler OrderRemoved;
		#endregion Events
		#region Declarations
		#endregion Declarations
		#region Properties
		/// <summary>
		/// The Order currently being edited by this control.
		/// Get accessor casts base._entity to Order
		/// Set accessor used by parent control to set the item currently being edited
		/// </summary>
		public BLL.Orders.Order OrderItem
		{
			get
			{
				return (BLL.Orders.Order) _entity;
			}
			set
			{
				_entity = value; // only set by container
				Session["OrderItem"] = _entity;
			}
		}
		#endregion Properties
		#region Event Handlers
		// ------------------------------------------------------------------------------
		/// <summary>Load page for editing Order, getting mode and parameters.</summary>
		///
		// ------------------------------------------------------------------------------
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				// set validator property to child controls
				listPaymentData.UseValidation = UseValidation && (DisplayMode != MOD.Data.DisplayMode.SingleView);
				listOrderCouponData.UseValidation = UseValidation && (DisplayMode != MOD.Data.DisplayMode.SingleView);
				listOrderFeeData.UseValidation = UseValidation && (DisplayMode != MOD.Data.DisplayMode.SingleView);
				base.OnLoad();
				if (IsPostBack == true)
				{
					// entity may come from session, or be set by container
					if (_entity == null)
					{
						_entity = (BLL.Orders.Order)Session["OrderItem"];
					}
					if (WorkflowMode == WorkflowMode.External)
					{
						CopyFormToEntity(); // apply changes to object
					}
				}
				else
				{
					if (Request.QueryString["SaveMessages"] == null)
					{
						Globals.ClearMessages();
					}
					SetTitle(); // from query string
					if (WorkflowMode == WorkflowMode.External)
					{
						LoadEntity();
					}
					
					if (_entity == null)
					{
						CreateNewEntity();
					}
					
					// update entity in session
					Session["OrderItem"] = _entity;
				}
				// Assign entity collections into child controls
				listPaymentData.Collection = OrderItem.PaymentList;
				listOrderCouponData.Collection = OrderItem.OrderCouponList;
				listOrderFeeData.Collection = OrderItem.OrderFeeList;
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditOrder.Page_Load"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Delete Order.</summary>
		///
		// ------------------------------------------------------------------------------
		private void btnDelete_Click(object sender, EventArgs e)
		{
			bool doRedirect = true;
			try
			{
				Globals.ClearMessages();
				if (WorkflowMode == WorkflowMode.External)
				{
					bool performCascade = true;
					BLL.Orders.OrderManager.DeleteOneOrder(OrderItem, performCascade);
					Globals.AddStatusMessage("Order deleted.");
				}
				else
				{
					// raise event so item is removed from collection
					if (OrderRemoved != null)
					{
						OrderRemoved(this, new EntityEditEventArgs(_entity));
					}
				}
				// create new object and store it in _entity
				CreateNewEntity();
				Session["OrderItem"] = _entity;
				CurrentSection = "Basics";
				sectionLinks.CurrentSection = "Basics";
				SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
			}
			catch (CoreUtility.CustomAppException ex)
			{
				doRedirect = false;
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				doRedirect = false;
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditOrder.btnDelete_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("OrderID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Request to create a new Order.</summary>
		///
		// ------------------------------------------------------------------------------
		private void btnNew_Click(object sender, EventArgs e)
		{
			bool doRedirect = true;
			try
			{
				Globals.ClearMessages();
				// create new object and store it in _entity
				CreateNewEntity();
				Session["OrderItem"] = _entity;
				this.sectionLinks.OnSection("Basics");
				SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
				Globals.AddStatusMessage("Add new Order.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				doRedirect = false;
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				doRedirect = false;
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditOrder.btnNew_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("OrderID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Reset form for Order.</summary>
		///
		// ------------------------------------------------------------------------------
		private void btnReset_Click(object sender, EventArgs e)
		{
			try
			{
				Globals.ClearMessages();
				// reset data in the form
				if (WorkflowMode == WorkflowMode.External)
				{
					LoadEntity();
					if (_entity == null)
					{
						CreateNewEntity();
					}
					Session["OrderItem"] = _entity;
					sectionLinks.CurrentSection = "Basics";
				}
				else
				{
					CreateNewEntity();
				}
				Globals.AddStatusMessage("Order reset.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditOrder.btnReset_Click"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Save Order.</summary>
		///
		// ------------------------------------------------------------------------------
		private void btnSave_Click(object sender, EventArgs e)
		{
			bool doRedirect = true;
			bool isValid = true;
			try
			{
				Globals.ClearMessages();
				if (WorkflowMode == WorkflowMode.Internal)
				{
					// copy form values to _entity properties
					CopyFormToEntity();
				}
				if (btnSave.CausesValidation == true)
				{
					Page.Validate();
					isValid = Page.IsValid;
				}
				if (isValid == true)
				{
					if (WorkflowMode == WorkflowMode.Internal)
					{
						if (AccessMode == MOD.Data.AccessMode.Add)
						{
							if (OrderAdded != null && (OrderItem.OrderID != MOD.Data.DefaultValue.Guid || OrderItem.DebitMetaPartnerID != MOD.Data.DefaultValue.Guid || OrderItem.CreditMetaPartnerID != MOD.Data.DefaultValue.Guid || OrderItem.LogToAccountID != MOD.Data.DefaultValue.Guid || OrderItem.OrderDescription != MOD.Data.DefaultValue.String || OrderItem.OrderAmount != MOD.Data.DefaultValue.Decimal || OrderItem.OrderSubtotal != MOD.Data.DefaultValue.Decimal || OrderItem.OrderTax != MOD.Data.DefaultValue.Decimal || OrderItem.OrderServiceCharge != MOD.Data.DefaultValue.Decimal || OrderItem.CurrencyCode != MOD.Data.DefaultValue.Int || OrderItem.OrderStatusCode != MOD.Data.DefaultValue.Int || OrderItem.OrderStatusMessage != MOD.Data.DefaultValue.String || OrderItem.CreatedByUserID != MOD.Data.DefaultValue.Guid || OrderItem.CreatedDate != MOD.Data.DefaultValue.DateTime || OrderItem.LastModifiedByUserID != MOD.Data.DefaultValue.Guid || OrderItem.LastModifiedDate != MOD.Data.DefaultValue.DateTime || OrderItem.Timestamp != null))
							{
								OrderAdded(this, new EntityEditEventArgs(_entity));
								// create new object and store it in _entity
								CreateNewEntity();
								Session["OrderItem"] = _entity;
								this.sectionLinks.OnSection("Basics");
								SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
							}
						}
						else
						{
							Globals.AddStatusMessage("Order updated.");
						}
					}
					else
					{
						UpsertToDatabase(true);
						if (AccessMode == MOD.Data.AccessMode.Add)
						{
							doRedirect = true;
							Globals.AddStatusMessage("Order added.");
						}
						else
						{
							Globals.AddStatusMessage("Order updated.");
						}
						SetAccessModeAndDisplay(MOD.Data.AccessMode.Edit);
					}
				}
				else
				{
					Globals.AddErrorMessage(Page, "Order validation failed.");
				}
			}
			catch (CoreUtility.CustomAppException ex)
			{
				doRedirect = false;
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				doRedirect = false;
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditOrder.btnSave_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && isValid == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("OrderID", OrderItem.OrderID.ToString());
				queryString.Add("mode", MOD.Data.AccessMode.Edit.ToString());
				queryString.Add("SaveMessages", "true");
				if (sectionLinks.CurrentSection != "")
				{
					queryString.Add("currentsection", sectionLinks.CurrentSection);
					Response.Redirect(GetPageUrl(queryString, true, true));
				}
				else
				{
					Response.Redirect(GetPageUrl(queryString, true, false));
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Go to basics tab.</summary>
		///
		// ------------------------------------------------------------------------------
		private void btnBasics_Click(object sender, EventArgs e)
		{
			try
			{
				Globals.ClearMessages();
				sectionLinks.OnSection("Basics");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditOrder.btnBasics_Click"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// Move to the previous section.
		/// </summary>
		// ------------------------------------------------------------------------------
		private void btnPrevious_Click(object sender, EventArgs e)
		{
			try
			{
				Globals.ClearMessages();
				sectionLinks.OnPrevious();
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditOrder.btnBasics_Click"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// Move the next section.
		/// </summary>
		// ------------------------------------------------------------------------------
		private void btnNext_Click(object sender, EventArgs e)
		{
			try
			{
				Globals.ClearMessages();
				sectionLinks.OnNext();
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditOrder.btnBasics_Click"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// Pre render control.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		// ------------------------------------------------------------------------------
		private void Page_PreRender(object sender, EventArgs e)
		{
			try
			{
				SetAccessModeAndDisplay(AccessMode);
				base.OnPreRender();
				CopyEntityToForm();
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditOrder.Page_PreRender"));
			}
			finally
			{
			}
		}
		#endregion Event Handlers
		#region Methods
		// ------------------------------------------------------------------------------
		/// <summary>Set the title area.</summary>
		///
		// ------------------------------------------------------------------------------
		private void SetTitle()
		{
			if (Request.QueryString.Get("message") != null && Request.QueryString.Get("message") != "")
			{
				lblTitleMessage.Text = "(" + Request.QueryString.Get("message").Trim() + ")";
			}
			else
			{
				lblTitleMessage.Text = "";
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// Create a new Order object reference
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void CreateNewEntity()
		{
			BLL.Orders.Order vOrder = new BLL.Orders.Order();
			vOrder.OrderID = MOD.Data.DataHelper.GetGuid(Request.QueryString["OrderID"], MOD.Data.DefaultValue.Guid);
			vOrder.DebitMetaPartnerID = MOD.Data.DataHelper.GetGuid(Request.QueryString["DebitMetaPartnerID"], MOD.Data.DefaultValue.Guid);
			vOrder.CreditMetaPartnerID = MOD.Data.DataHelper.GetGuid(Request.QueryString["CreditMetaPartnerID"], MOD.Data.DefaultValue.Guid);
			vOrder.LogToAccountID = MOD.Data.DataHelper.GetGuid(Request.QueryString["LogToAccountID"], MOD.Data.DefaultValue.Guid);
			vOrder.CurrencyCode = MOD.Data.DataHelper.GetInt(Request.QueryString["CurrencyCode"], MOD.Data.DefaultValue.Int);
			vOrder.OrderStatusCode = MOD.Data.DataHelper.GetInt(Request.QueryString["OrderStatusCode"], MOD.Data.DefaultValue.Int);
			_entity = vOrder;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update form from Order information.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyEntityToForm()
		{
			BLL.Orders.Order vOrder = OrderItem;
			lblOrderID.Text = MOD.Data.DataHelper.GetString(vOrder.OrderID, "");
			ddlDebitMetaPartnerID.DataValueField = "PrimaryIndex";
			ddlDebitMetaPartnerID.DataTextField = "PrimaryName";
			if (UseWorkingSets == true && Session["Customers/MetaPartnerWorkingSet"] != null)
			{
				BLL.SortableList<BLL.Customers.MetaPartner> sessionSource = (BLL.SortableList<BLL.Customers.MetaPartner>) Session["Customers/MetaPartnerWorkingSet"];
				BLL.SortableList<BLL.Customers.MetaPartner> currentSource = new BLL.SortableList<BLL.Customers.MetaPartner>(sessionSource, true);
				if (MOD.Data.DataHelper.GetGuid(vOrder.DebitMetaPartnerID, MOD.Data.DefaultValue.Guid) != MOD.Data.DefaultValue.Guid)
				{
					BLL.Customers.MetaPartner currentMetaPartner = BLL.Customers.MetaPartnerManager.GetOneMetaPartner(MOD.Data.DataHelper.GetGuid(vOrder.DebitMetaPartnerID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions("", "", true, true));
					if (currentMetaPartner != null && currentSource.Contains(currentMetaPartner) == false)
					{
						currentSource.Insert(0, currentMetaPartner);
					}
				}
				ddlDebitMetaPartnerID.DataSource = currentSource;
				lnkDebitMetaPartnerIDWorkingSet.Visible = true;
				lnkDebitMetaPartnerIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Customers/SearchMetaPartnerData.aspx");
				lblDebitMetaPartnerIDWorkingSet.Visible = true;
				lblDebitMetaPartnerIDWorkingSet.Text = " (from Meta Partner working set)";
			}
			else
			{
				ddlDebitMetaPartnerID.DataSource = BLL.Customers.MetaPartnerManager.GetAllMetaPartnerData(Globals.DBOptions, Globals.getDataOptions("MetaPartnerName", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
				lblDebitMetaPartnerIDWorkingSet.Visible = false;
				if (UseWorkingSets == true)
				{
					lnkDebitMetaPartnerIDWorkingSet.Visible = true;
					lnkDebitMetaPartnerIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Customers/SearchMetaPartnerData.aspx");
				}
				else
				{
					lnkDebitMetaPartnerIDWorkingSet.Visible = false;
				}
			}
			ddlDebitMetaPartnerID.DataBind();
			ddlDebitMetaPartnerID.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				BLL.Customers.MetaPartner sMetaPartner = new BLL.Customers.MetaPartner();
				sMetaPartner.MetaPartnerID = MOD.Data.DataHelper.GetGuid(vOrder.DebitMetaPartnerID, MOD.Data.DefaultValue.Guid);
				ddlDebitMetaPartnerID.SelectedValue = MOD.Data.DataHelper.GetString(sMetaPartner.PrimaryIndex, "");
				sMetaPartner = null;
			}
			catch {}
			if(ddlDebitMetaPartnerID.SelectedValue == ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				try
				{
					ddlDebitMetaPartnerID.SelectedValue = MOD.Data.DataHelper.GetString(Session["Customers/MetaPartnerWorkingSetItem"], "");
				}
				catch {}
			}
			ddlCreditMetaPartnerID.DataValueField = "PrimaryIndex";
			ddlCreditMetaPartnerID.DataTextField = "PrimaryName";
			if (UseWorkingSets == true && Session["Accounts/AccountWorkingSet"] != null)
			{
				BLL.SortableList<BLL.Accounts.Account> sessionSource = (BLL.SortableList<BLL.Accounts.Account>) Session["Accounts/AccountWorkingSet"];
				BLL.SortableList<BLL.Accounts.Account> currentSource = new BLL.SortableList<BLL.Accounts.Account>(sessionSource, true);
				if (MOD.Data.DataHelper.GetGuid(vOrder.CreditMetaPartnerID, MOD.Data.DefaultValue.Guid) != MOD.Data.DefaultValue.Guid)
				{
					BLL.Accounts.Account currentAccount = BLL.Accounts.AccountManager.GetOneAccount(MOD.Data.DataHelper.GetGuid(vOrder.CreditMetaPartnerID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions("", "", true, true));
					if (currentAccount != null && currentSource.Contains(currentAccount) == false)
					{
						currentSource.Insert(0, currentAccount);
					}
				}
				ddlCreditMetaPartnerID.DataSource = currentSource;
				lnkCreditMetaPartnerIDWorkingSet.Visible = true;
				lnkCreditMetaPartnerIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Accounts/SearchAccountData.aspx");
				lblCreditMetaPartnerIDWorkingSet.Visible = true;
				lblCreditMetaPartnerIDWorkingSet.Text = " (from Account working set)";
			}
			else
			{
				ddlCreditMetaPartnerID.DataSource = BLL.Accounts.AccountManager.GetAllAccountData(Globals.DBOptions, Globals.getDataOptions("AccountName", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
				lblCreditMetaPartnerIDWorkingSet.Visible = false;
				if (UseWorkingSets == true)
				{
					lnkCreditMetaPartnerIDWorkingSet.Visible = true;
					lnkCreditMetaPartnerIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Accounts/SearchAccountData.aspx");
				}
				else
				{
					lnkCreditMetaPartnerIDWorkingSet.Visible = false;
				}
			}
			ddlCreditMetaPartnerID.DataBind();
			ddlCreditMetaPartnerID.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				BLL.Accounts.Account sAccount = new BLL.Accounts.Account();
				sAccount.AccountID = MOD.Data.DataHelper.GetGuid(vOrder.LogToAccountID, MOD.Data.DefaultValue.Guid);
				sAccount.MetaPartnerID = MOD.Data.DataHelper.GetGuid(vOrder.CreditMetaPartnerID, MOD.Data.DefaultValue.Guid);
				ddlCreditMetaPartnerID.SelectedValue = MOD.Data.DataHelper.GetString(sAccount.PrimaryIndex, "");
				sAccount = null;
			}
			catch {}
			if(ddlCreditMetaPartnerID.SelectedValue == ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				try
				{
					ddlCreditMetaPartnerID.SelectedValue = MOD.Data.DataHelper.GetString(Session["Accounts/AccountWorkingSetItem"], "");
				}
				catch {}
			}
			txtOrderDescription.Text = MOD.Data.EditHelper.GetString(vOrder.OrderDescription);
			txtOrderAmount.Text = MOD.Data.EditHelper.GetCurrency(vOrder.OrderAmount);
			txtOrderSubtotal.Text = MOD.Data.EditHelper.GetCurrency(vOrder.OrderSubtotal);
			txtOrderTax.Text = MOD.Data.EditHelper.GetCurrency(vOrder.OrderTax);
			txtOrderServiceCharge.Text = MOD.Data.EditHelper.GetCurrency(vOrder.OrderServiceCharge);
			ddlCurrencyCode.DataValueField = "PrimaryIndex";
			ddlCurrencyCode.DataTextField = "PrimaryName";
			ddlCurrencyCode.DataSource = BLL.Accounts.CurrencyManager.GetAllCurrencyData(Globals.DBOptions, Globals.getDataOptions("CurrencyName", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
			ddlCurrencyCode.DataBind();
			ddlCurrencyCode.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				BLL.Accounts.Currency sCurrency = new BLL.Accounts.Currency();
				sCurrency.CurrencyCode = MOD.Data.DataHelper.GetInt(vOrder.CurrencyCode, MOD.Data.DefaultValue.Int);
				ddlCurrencyCode.SelectedValue = MOD.Data.DataHelper.GetString(sCurrency.PrimaryIndex, "");
				sCurrency = null;
			}
			catch {}
			if(ddlCurrencyCode.SelectedValue == ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				try
				{
					ddlCurrencyCode.SelectedValue = MOD.Data.DataHelper.GetString(Session["Accounts/CurrencyWorkingSetItem"], "");
				}
				catch {}
			}
			ddlOrderStatusCode.DataValueField = "PrimaryIndex";
			ddlOrderStatusCode.DataTextField = "PrimaryName";
			ddlOrderStatusCode.DataSource = BLL.Orders.OrderStatusManager.GetAllOrderStatusData(Globals.DBOptions, Globals.getDataOptions("OrderStatusName", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
			ddlOrderStatusCode.DataBind();
			ddlOrderStatusCode.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				BLL.Orders.OrderStatus sOrderStatus = new BLL.Orders.OrderStatus();
				sOrderStatus.OrderStatusCode = MOD.Data.DataHelper.GetInt(vOrder.OrderStatusCode, MOD.Data.DefaultValue.Int);
				ddlOrderStatusCode.SelectedValue = MOD.Data.DataHelper.GetString(sOrderStatus.PrimaryIndex, "");
				sOrderStatus = null;
			}
			catch {}
			if(ddlOrderStatusCode.SelectedValue == ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				try
				{
					ddlOrderStatusCode.SelectedValue = MOD.Data.DataHelper.GetString(Session["Orders/OrderStatusWorkingSetItem"], "");
				}
				catch {}
			}
			txtOrderStatusMessage.Text = MOD.Data.EditHelper.GetString(vOrder.OrderStatusMessage);
			// Drop downs should be disabled when control is "Internal" and either value is constrained by container
			if (WorkflowMode == WorkflowMode.Internal)
			{
				ddlDebitMetaPartnerID.Visible = Request.QueryString["DebitMetaPartnerID"] == null;
				lnkDebitMetaPartnerIDWorkingSet.Visible = lnkDebitMetaPartnerIDWorkingSet.Visible == true && Request.QueryString["DebitMetaPartnerID"] == null;
				lblDebitMetaPartnerIDWorkingSet.Visible = lblDebitMetaPartnerIDWorkingSet.Visible == true && Request.QueryString["DebitMetaPartnerID"] == null;
				valDebitMetaPartnerID.Enabled = Request.QueryString["DebitMetaPartnerID"] == null;
				lblDebitMetaPartnerIDDisplay.Visible = Request.QueryString["DebitMetaPartnerID"] == null;
				ddlCurrencyCode.Visible = Request.QueryString["CurrencyCode"] == null;
				valCurrencyCode.Enabled = Request.QueryString["CurrencyCode"] == null;
				lblCurrencyCodeDisplay.Visible = Request.QueryString["CurrencyCode"] == null;
				ddlOrderStatusCode.Visible = Request.QueryString["OrderStatusCode"] == null;
				valOrderStatusCode.Enabled = Request.QueryString["OrderStatusCode"] == null;
				lblOrderStatusCodeDisplay.Visible = Request.QueryString["OrderStatusCode"] == null;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set Order information from the form.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyFormToEntity()
		{
			BLL.Orders.Order vOrder = OrderItem;
			if (vOrder == null)
			{
				throw CoreUtility.CustomAppException.WrapException(new Exception("Order not found"), "EditOrder.CopyFormToEntity()");
			}
			if (ddlDebitMetaPartnerID.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Customers.MetaPartner sMetaPartner = new BLL.Customers.MetaPartner(ddlDebitMetaPartnerID.SelectedValue, false);
				vOrder.DebitMetaPartnerID = MOD.Data.DataHelper.GetGuid(sMetaPartner.MetaPartnerID, MOD.Data.DefaultValue.Guid);
				sMetaPartner = null;
			}
			if (ddlCreditMetaPartnerID.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Accounts.Account sAccount = new BLL.Accounts.Account(ddlCreditMetaPartnerID.SelectedValue, false);
				vOrder.LogToAccountID = MOD.Data.DataHelper.GetGuid(sAccount.AccountID, MOD.Data.DefaultValue.Guid);
				vOrder.CreditMetaPartnerID = MOD.Data.DataHelper.GetGuid(sAccount.MetaPartnerID, MOD.Data.DefaultValue.Guid);
				sAccount = null;
			}
			vOrder.OrderDescription = EditHelper.EncodeStringForDB(MOD.Data.DataHelper.GetString(txtOrderDescription.Text, null));
			try
			{
				vOrder.OrderAmount = MOD.Data.DataHelper.GetDecimal(txtOrderAmount.Text, MOD.Data.DefaultValue.Decimal);
			}
			catch {}
			try
			{
				vOrder.OrderSubtotal = MOD.Data.DataHelper.GetDecimal(txtOrderSubtotal.Text, MOD.Data.DefaultValue.Decimal);
			}
			catch {}
			try
			{
				vOrder.OrderTax = MOD.Data.DataHelper.GetDecimal(txtOrderTax.Text, MOD.Data.DefaultValue.Decimal);
			}
			catch {}
			try
			{
				vOrder.OrderServiceCharge = MOD.Data.DataHelper.GetDecimal(txtOrderServiceCharge.Text, MOD.Data.DefaultValue.Decimal);
			}
			catch {}
			if (ddlCurrencyCode.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Accounts.Currency sCurrency = new BLL.Accounts.Currency(ddlCurrencyCode.SelectedValue, false);
				vOrder.CurrencyCode = MOD.Data.DataHelper.GetInt(sCurrency.CurrencyCode, MOD.Data.DefaultValue.Int);
				sCurrency = null;
				vOrder.PrimaryName += MOD.Data.DataHelper.GetString(ddlCurrencyCode.SelectedItem.Text, MOD.Data.DefaultValue.String) + ";";
			}
			if (ddlOrderStatusCode.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Orders.OrderStatus sOrderStatus = new BLL.Orders.OrderStatus(ddlOrderStatusCode.SelectedValue, false);
				vOrder.OrderStatusCode = MOD.Data.DataHelper.GetInt(sOrderStatus.OrderStatusCode, MOD.Data.DefaultValue.Int);
				sOrderStatus = null;
				vOrder.PrimaryName += MOD.Data.DataHelper.GetString(ddlOrderStatusCode.SelectedItem.Text, MOD.Data.DefaultValue.String) + ";";
			}
			vOrder.OrderStatusMessage = EditHelper.EncodeStringForDB(MOD.Data.DataHelper.GetString(txtOrderStatusMessage.Text, null));
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// Load entity from database, store in _entity and Session["OrderItem"]
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void LoadEntity()
		{
			_entity = null;
			Guid orderID = MOD.Data.DataHelper.GetGuid(Request.QueryString["OrderID"], MOD.Data.DefaultValue.Guid);
			if (orderID != MOD.Data.DefaultValue.Guid)
			{
				_entity = BLL.Orders.OrderManager.GetOneOrder(orderID, Globals.getDataOptions("", "", true, true));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update Order information in the database.</summary>
		///
		// ------------------------------------------------------------------------------
		private void UpsertToDatabase(bool performCascade)
		{
			BLL.Orders.Order vOrder = OrderItem;
			if (AccessMode == MOD.Data.AccessMode.Add)
			{
				BLL.Orders.OrderManager.UpsertOneOrder(vOrder, performCascade);
			}
			else if (AccessMode == MOD.Data.AccessMode.Edit)
			{
				BLL.Orders.OrderManager.UpsertOneOrder(vOrder, performCascade);
			}
			OrderItem.OrderID = vOrder.OrderID;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set access and display modes for presenting Order information.</summary>
		///
		// ------------------------------------------------------------------------------
		private void SetAccessModeAndDisplay(MOD.Data.AccessMode accessMode)
		{
			// set access mode
			AccessMode = accessMode;
			// set access mode display
			switch (AccessMode)
			{
				case MOD.Data.AccessMode.Add:
					lblTitle.Text = "Add Order";
					btnSave.Text = "Add";
					break;
				case MOD.Data.AccessMode.Edit:
					lblTitle.Text = "Edit Order";
					btnSave.Text = "Save";
					break;
				case MOD.Data.AccessMode.View:
					lblTitle.Text = "View Order";
					break;
				default:
					lblTitle.Text = "View Order";
					break;
			}
			btnDelete.Visible = IsDeleteAvailable;
			btnNew.Visible = IsEditAvailable;
			btnSave.Visible = IsEditAvailable || IsAddAvailable;
			// set workflow display
			if (WorkflowMode == MOD.Data.WorkflowMode.Internal)
			{
				btnDelete.Text = "Remove";
				btnReset.Visible = false;
			}
			else
			{
				btnDelete.Text = "Delete";
				btnReset.Visible = IsEditAvailable || IsAddAvailable;
			}
			// set display mode display
			if (DisplayMode == DisplayMode.TabbedView)
			{
				Section_Additional_Info.Visible = true;
				Section_Basics.Visible = true;
				Section_Payments.Visible = false;
				Section_Order_Coupons.Visible = false;
				Section_Order_Fees.Visible = false;
				this.ItemInfo.Visible = true;
				this.DetailNavigation.Visible = true;
				this.ItemInfoContent.Visible = true;
				this.SectionLinkContent.Visible = true;
				this.ButtonsInfo.Visible = true;
				this.btnBasics.Visible = false; //!sectionLinks.IsOnFirstTab;
				this.btnPrevious.Visible = !sectionLinks.IsOnFirstTab;
				this.btnNext.Visible = !sectionLinks.IsOnLastTab;
				this.btnPrevious.CausesValidation = false;
				this.btnNext.CausesValidation = false;
				this.btnBasics.CausesValidation = false;
				this.btnSave.CausesValidation = false;
				foreach (string section in sectionLinks.ValidationList.Split(','))
				{
					if (section == sectionLinks.CurrentSection)
					{
						this.btnPrevious.CausesValidation = true;
						this.btnNext.CausesValidation = true;
						this.btnBasics.CausesValidation = false; //true;
						this.btnSave.CausesValidation = true;
						break;
					}
				}
			}
			else
			{
				sectionLinks.SectionList = "";
				sectionLinks.Visible = false;
				Section_Additional_Info.Visible = true;
				Section_Basics.Visible = true;
				if (WorkflowMode != MOD.Data.WorkflowMode.Internal)
				{
					Section_Payments.Visible = true;
					Section_Order_Coupons.Visible = true;
					Section_Order_Fees.Visible = true;
				}
				this.ButtonsInfo.Visible = true;
				this.ItemInfo.Visible = false;
				this.DetailNavigation.Visible = false;
				this.ItemInfoContent.Visible = false;
				this.SectionLinkContent.Visible = false;
				this.btnBasics.Visible = false;
				this.btnPrevious.Visible = false;
				this.btnNext.Visible = false;
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
		/// <summary>Initialize component for Order, add delegates here.</summary>
		///
		// ------------------------------------------------------------------------------
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);
			this.PreRender += new EventHandler(Page_PreRender);
			this.btnDelete.Click += new EventHandler(btnDelete_Click);
			this.btnDelete.Attributes.Add("onclick", "javascript:return ConfirmDelete();");
			this.btnNew.Click += new EventHandler(btnNew_Click);
			this.btnNew.Attributes.Add("onclick", "javascript:return PromptToDiscardChanges();");
			this.btnReset.Click += new EventHandler(btnReset_Click);
			this.btnSave.Click += new EventHandler(btnSave_Click);
			this.btnPrevious.Click += new EventHandler(btnPrevious_Click);
			this.btnNext.Click += new EventHandler(btnNext_Click);
			this.btnBasics.Click += new EventHandler(btnBasics_Click);
		}
		#endregion Web Form Designer generated code
	}
}