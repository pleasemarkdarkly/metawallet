
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
	/// <summary>Edit Order Coupon is used to help manage OrderCoupon information.</summary>
	///
	/// File History:
	/// <created>6/1/2007 (Chris Grundy)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class EditOrderCoupon  : Components.Desktop.BaseFormlUserControl
	{
		#region Events
		/// <summary>
		/// Raised when "Add" button is clicked in internal mode.
		/// Container handles this event and adds entity to collection.
		/// </summary>
		public event EntityEditEventHandler OrderCouponAdded;
		/// <summary>
		/// Raised when "Remove" button is clicked in internal mode.
		/// Container handles this event and removes entity from collection.
		/// </summary>
		public event EntityEditEventHandler OrderCouponRemoved;
		#endregion Events
		#region Declarations
		#endregion Declarations
		#region Properties
		/// <summary>
		/// The OrderCoupon currently being edited by this control.
		/// Get accessor casts base._entity to OrderCoupon
		/// Set accessor used by parent control to set the item currently being edited
		/// </summary>
		public BLL.Orders.OrderCoupon OrderCouponItem
		{
			get
			{
				return (BLL.Orders.OrderCoupon) _entity;
			}
			set
			{
				_entity = value; // only set by container
				Session["OrderCouponItem"] = _entity;
			}
		}
		#endregion Properties
		#region Event Handlers
		// ------------------------------------------------------------------------------
		/// <summary>Load page for editing Order Coupon, getting mode and parameters.</summary>
		///
		// ------------------------------------------------------------------------------
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				base.OnLoad();
				if (IsPostBack == true)
				{
					// entity may come from session, or be set by container
					if (_entity == null)
					{
						_entity = (BLL.Orders.OrderCoupon)Session["OrderCouponItem"];
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
					Session["OrderCouponItem"] = _entity;
				}
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditOrderCoupon.Page_Load"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Delete Order Coupon.</summary>
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
					BLL.Orders.OrderCouponManager.DeleteOneOrderCoupon(OrderCouponItem, performCascade);
					Globals.AddStatusMessage("Order Coupon deleted.");
				}
				else
				{
					// raise event so item is removed from collection
					if (OrderCouponRemoved != null)
					{
						OrderCouponRemoved(this, new EntityEditEventArgs(_entity));
					}
				}
				// create new object and store it in _entity
				CreateNewEntity();
				Session["OrderCouponItem"] = _entity;
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditOrderCoupon.btnDelete_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("OrderID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("MetaPartnerCouponID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("DebitMetaPartnerID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Request to create a new Order Coupon.</summary>
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
				Session["OrderCouponItem"] = _entity;
				this.sectionLinks.OnSection("Basics");
				SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
				Globals.AddStatusMessage("Add new Order Coupon.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				doRedirect = false;
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				doRedirect = false;
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditOrderCoupon.btnNew_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("OrderID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("MetaPartnerCouponID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("DebitMetaPartnerID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Reset form for Order Coupon.</summary>
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
					Session["OrderCouponItem"] = _entity;
					sectionLinks.CurrentSection = "Basics";
				}
				else
				{
					CreateNewEntity();
				}
				Globals.AddStatusMessage("Order Coupon reset.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditOrderCoupon.btnReset_Click"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Save Order Coupon.</summary>
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
							if (OrderCouponAdded != null && (OrderCouponItem.OrderID != MOD.Data.DefaultValue.Guid || OrderCouponItem.MetaPartnerCouponID != MOD.Data.DefaultValue.Guid || OrderCouponItem.DebitMetaPartnerID != MOD.Data.DefaultValue.Guid || OrderCouponItem.CreatedByUserID != MOD.Data.DefaultValue.Guid || OrderCouponItem.CreatedDate != MOD.Data.DefaultValue.DateTime || OrderCouponItem.LastModifiedByUserID != MOD.Data.DefaultValue.Guid || OrderCouponItem.LastModifiedDate != MOD.Data.DefaultValue.DateTime || OrderCouponItem.Timestamp != null))
							{
								OrderCouponAdded(this, new EntityEditEventArgs(_entity));
								// create new object and store it in _entity
								CreateNewEntity();
								Session["OrderCouponItem"] = _entity;
								this.sectionLinks.OnSection("Basics");
								SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
							}
						}
						else
						{
							Globals.AddStatusMessage("Order Coupon updated.");
						}
					}
					else
					{
						UpsertToDatabase(true);
						if (AccessMode == MOD.Data.AccessMode.Add)
						{
							doRedirect = true;
							Globals.AddStatusMessage("Order Coupon added.");
						}
						else
						{
							Globals.AddStatusMessage("Order Coupon updated.");
						}
						SetAccessModeAndDisplay(MOD.Data.AccessMode.Edit);
					}
				}
				else
				{
					Globals.AddErrorMessage(Page, "Order Coupon validation failed.");
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditOrderCoupon.btnSave_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && isValid == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("OrderID", OrderCouponItem.OrderID.ToString());
				queryString.Add("MetaPartnerCouponID", OrderCouponItem.MetaPartnerCouponID.ToString());
				queryString.Add("DebitMetaPartnerID", OrderCouponItem.DebitMetaPartnerID.ToString());
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditOrderCoupon.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditOrderCoupon.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditOrderCoupon.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditOrderCoupon.Page_PreRender"));
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
		/// Create a new Order Coupon object reference
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void CreateNewEntity()
		{
			BLL.Orders.OrderCoupon vOrderCoupon = new BLL.Orders.OrderCoupon();
			vOrderCoupon.OrderID = MOD.Data.DataHelper.GetGuid(Request.QueryString["OrderID"], MOD.Data.DefaultValue.Guid);
			vOrderCoupon.MetaPartnerCouponID = MOD.Data.DataHelper.GetGuid(Request.QueryString["MetaPartnerCouponID"], MOD.Data.DefaultValue.Guid);
			vOrderCoupon.DebitMetaPartnerID = MOD.Data.DataHelper.GetGuid(Request.QueryString["DebitMetaPartnerID"], MOD.Data.DefaultValue.Guid);
			_entity = vOrderCoupon;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update form from Order Coupon information.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyEntityToForm()
		{
			BLL.Orders.OrderCoupon vOrderCoupon = OrderCouponItem;
			ddlOrderID.DataValueField = "PrimaryIndex";
			ddlOrderID.DataTextField = "PrimaryName";
			if (UseWorkingSets == true && Session["Orders/OrderWorkingSet"] != null)
			{
				BLL.SortableList<BLL.Orders.Order> sessionSource = (BLL.SortableList<BLL.Orders.Order>) Session["Orders/OrderWorkingSet"];
				BLL.SortableList<BLL.Orders.Order> currentSource = new BLL.SortableList<BLL.Orders.Order>(sessionSource, true);
				if (MOD.Data.DataHelper.GetGuid(vOrderCoupon.OrderID, MOD.Data.DefaultValue.Guid) != MOD.Data.DefaultValue.Guid)
				{
					BLL.Orders.Order currentOrder = BLL.Orders.OrderManager.GetOneOrder(MOD.Data.DataHelper.GetGuid(vOrderCoupon.OrderID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions("", "", true, true));
					if (currentOrder != null && currentSource.Contains(currentOrder) == false)
					{
						currentSource.Insert(0, currentOrder);
					}
				}
				ddlOrderID.DataSource = currentSource;
				lnkOrderIDWorkingSet.Visible = true;
				lnkOrderIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Orders/SearchOrderData.aspx");
				lblOrderIDWorkingSet.Visible = true;
				lblOrderIDWorkingSet.Text = " (from Order working set)";
			}
			else
			{
				ddlOrderID.DataSource = BLL.Orders.OrderManager.GetAllOrderData(Globals.DBOptions, Globals.getDataOptions("", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
				lblOrderIDWorkingSet.Visible = false;
				if (UseWorkingSets == true)
				{
					lnkOrderIDWorkingSet.Visible = true;
					lnkOrderIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Orders/SearchOrderData.aspx");
				}
				else
				{
					lnkOrderIDWorkingSet.Visible = false;
				}
			}
			ddlOrderID.DataBind();
			ddlOrderID.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				BLL.Orders.Order sOrder = new BLL.Orders.Order();
				sOrder.OrderID = MOD.Data.DataHelper.GetGuid(vOrderCoupon.OrderID, MOD.Data.DefaultValue.Guid);
				sOrder.DebitMetaPartnerID = MOD.Data.DataHelper.GetGuid(vOrderCoupon.DebitMetaPartnerID, MOD.Data.DefaultValue.Guid);
				ddlOrderID.SelectedValue = MOD.Data.DataHelper.GetString(sOrder.PrimaryIndex, "");
				sOrder = null;
			}
			catch {}
			if(ddlOrderID.SelectedValue == ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				try
				{
					ddlOrderID.SelectedValue = MOD.Data.DataHelper.GetString(Session["Orders/OrderWorkingSetItem"], "");
				}
				catch {}
			}
			ddlMetaPartnerCouponID.DataValueField = "PrimaryIndex";
			ddlMetaPartnerCouponID.DataTextField = "PrimaryName";
			if (UseWorkingSets == true && Session["Promotions/MetaPartnerCouponWorkingSet"] != null)
			{
				BLL.SortableList<BLL.Promotions.MetaPartnerCoupon> sessionSource = (BLL.SortableList<BLL.Promotions.MetaPartnerCoupon>) Session["Promotions/MetaPartnerCouponWorkingSet"];
				BLL.SortableList<BLL.Promotions.MetaPartnerCoupon> currentSource = new BLL.SortableList<BLL.Promotions.MetaPartnerCoupon>(sessionSource, true);
				if (MOD.Data.DataHelper.GetGuid(vOrderCoupon.MetaPartnerCouponID, MOD.Data.DefaultValue.Guid) != MOD.Data.DefaultValue.Guid)
				{
					BLL.Promotions.MetaPartnerCoupon currentMetaPartnerCoupon = BLL.Promotions.MetaPartnerCouponManager.GetOneMetaPartnerCoupon(MOD.Data.DataHelper.GetGuid(vOrderCoupon.MetaPartnerCouponID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions("", "", true, true));
					if (currentMetaPartnerCoupon != null && currentSource.Contains(currentMetaPartnerCoupon) == false)
					{
						currentSource.Insert(0, currentMetaPartnerCoupon);
					}
				}
				ddlMetaPartnerCouponID.DataSource = currentSource;
				lnkMetaPartnerCouponIDWorkingSet.Visible = true;
				lnkMetaPartnerCouponIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Promotions/SearchMetaPartnerCouponData.aspx");
				lblMetaPartnerCouponIDWorkingSet.Visible = true;
				lblMetaPartnerCouponIDWorkingSet.Text = " (from Meta Partner Coupon working set)";
			}
			else
			{
				ddlMetaPartnerCouponID.DataSource = BLL.Promotions.MetaPartnerCouponManager.GetAllMetaPartnerCouponData(Globals.DBOptions, Globals.getDataOptions("", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
				lblMetaPartnerCouponIDWorkingSet.Visible = false;
				if (UseWorkingSets == true)
				{
					lnkMetaPartnerCouponIDWorkingSet.Visible = true;
					lnkMetaPartnerCouponIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Promotions/SearchMetaPartnerCouponData.aspx");
				}
				else
				{
					lnkMetaPartnerCouponIDWorkingSet.Visible = false;
				}
			}
			ddlMetaPartnerCouponID.DataBind();
			ddlMetaPartnerCouponID.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				BLL.Promotions.MetaPartnerCoupon sMetaPartnerCoupon = new BLL.Promotions.MetaPartnerCoupon();
				sMetaPartnerCoupon.MetaPartnerCouponID = MOD.Data.DataHelper.GetGuid(vOrderCoupon.MetaPartnerCouponID, MOD.Data.DefaultValue.Guid);
				sMetaPartnerCoupon.MetaPartnerID = MOD.Data.DataHelper.GetGuid(vOrderCoupon.DebitMetaPartnerID, MOD.Data.DefaultValue.Guid);
				ddlMetaPartnerCouponID.SelectedValue = MOD.Data.DataHelper.GetString(sMetaPartnerCoupon.PrimaryIndex, "");
				sMetaPartnerCoupon = null;
			}
			catch {}
			if(ddlMetaPartnerCouponID.SelectedValue == ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				try
				{
					ddlMetaPartnerCouponID.SelectedValue = MOD.Data.DataHelper.GetString(Session["Promotions/MetaPartnerCouponWorkingSetItem"], "");
				}
				catch {}
			}
			// Drop downs should be disabled when control is "Internal" and either value is constrained by container
			if (WorkflowMode == WorkflowMode.Internal)
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set Order Coupon information from the form.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyFormToEntity()
		{
			BLL.Orders.OrderCoupon vOrderCoupon = OrderCouponItem;
			if (vOrderCoupon == null)
			{
				throw CoreUtility.CustomAppException.WrapException(new Exception("Order Coupon not found"), "EditOrderCoupon.CopyFormToEntity()");
			}
			if (ddlOrderID.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Orders.Order sOrder = new BLL.Orders.Order(ddlOrderID.SelectedValue, false);
				vOrderCoupon.OrderID = MOD.Data.DataHelper.GetGuid(sOrder.OrderID, MOD.Data.DefaultValue.Guid);
				vOrderCoupon.DebitMetaPartnerID = MOD.Data.DataHelper.GetGuid(sOrder.DebitMetaPartnerID, MOD.Data.DefaultValue.Guid);
				sOrder = null;
			}
			if (ddlMetaPartnerCouponID.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Promotions.MetaPartnerCoupon sMetaPartnerCoupon = new BLL.Promotions.MetaPartnerCoupon(ddlMetaPartnerCouponID.SelectedValue, false);
				vOrderCoupon.MetaPartnerCouponID = MOD.Data.DataHelper.GetGuid(sMetaPartnerCoupon.MetaPartnerCouponID, MOD.Data.DefaultValue.Guid);
				vOrderCoupon.DebitMetaPartnerID = MOD.Data.DataHelper.GetGuid(sMetaPartnerCoupon.MetaPartnerID, MOD.Data.DefaultValue.Guid);
				sMetaPartnerCoupon = null;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// Load entity from database, store in _entity and Session["OrderCouponItem"]
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void LoadEntity()
		{
			_entity = null;
			Guid orderID = MOD.Data.DataHelper.GetGuid(Request.QueryString["OrderID"], MOD.Data.DefaultValue.Guid);
			Guid metaPartnerCouponID = MOD.Data.DataHelper.GetGuid(Request.QueryString["MetaPartnerCouponID"], MOD.Data.DefaultValue.Guid);
			Guid debitMetaPartnerID = MOD.Data.DataHelper.GetGuid(Request.QueryString["DebitMetaPartnerID"], MOD.Data.DefaultValue.Guid);
			if (orderID != MOD.Data.DefaultValue.Guid && metaPartnerCouponID != MOD.Data.DefaultValue.Guid && debitMetaPartnerID != MOD.Data.DefaultValue.Guid)
			{
				_entity = BLL.Orders.OrderCouponManager.GetOneOrderCoupon(orderID, metaPartnerCouponID, debitMetaPartnerID, Globals.getDataOptions("", "", true, true));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update Order Coupon information in the database.</summary>
		///
		// ------------------------------------------------------------------------------
		private void UpsertToDatabase(bool performCascade)
		{
			BLL.Orders.OrderCoupon vOrderCoupon = OrderCouponItem;
			if (AccessMode == MOD.Data.AccessMode.Add)
			{
				BLL.Orders.OrderCouponManager.AddOneOrderCoupon(vOrderCoupon, performCascade);
			}
			else if (AccessMode == MOD.Data.AccessMode.Edit)
			{
				BLL.Orders.OrderCouponManager.UpdateOneOrderCoupon(vOrderCoupon, performCascade);
			}
			OrderCouponItem.OrderID = vOrderCoupon.OrderID;
			OrderCouponItem.MetaPartnerCouponID = vOrderCoupon.MetaPartnerCouponID;
			OrderCouponItem.DebitMetaPartnerID = vOrderCoupon.DebitMetaPartnerID;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set access and display modes for presenting Order Coupon information.</summary>
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
					lblTitle.Text = "Add Order&nbsp;Coupon";
					btnSave.Text = "Add";
					break;
				case MOD.Data.AccessMode.Edit:
					lblTitle.Text = "Edit Order&nbsp;Coupon";
					btnSave.Text = "Save";
					break;
				case MOD.Data.AccessMode.View:
					lblTitle.Text = "View Order&nbsp;Coupon";
					break;
				default:
					lblTitle.Text = "View Order&nbsp;Coupon";
					break;
			}
			btnDelete.Visible = IsDeleteAvailable;
			btnNew.Visible = IsEditAvailable;
			btnSave.Visible = IsEditAvailable || IsAddAvailable;
			ddlOrderID.Enabled = IsAddAvailable;
			ddlMetaPartnerCouponID.Enabled = IsAddAvailable;
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
				Section_Basics.Visible = true;
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
				Section_Basics.Visible = true;
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
		/// <summary>Initialize component for OrderCoupon, add delegates here.</summary>
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