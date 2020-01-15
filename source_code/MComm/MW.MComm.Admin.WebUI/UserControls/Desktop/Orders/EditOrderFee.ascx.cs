
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
	/// <summary>Edit Order Fee is used to help manage OrderFee information.</summary>
	///
	/// File History:
	/// <created>6/1/2007 (Chris Grundy)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class EditOrderFee  : Components.Desktop.BaseFormlUserControl
	{
		#region Events
		/// <summary>
		/// Raised when "Add" button is clicked in internal mode.
		/// Container handles this event and adds entity to collection.
		/// </summary>
		public event EntityEditEventHandler OrderFeeAdded;
		/// <summary>
		/// Raised when "Remove" button is clicked in internal mode.
		/// Container handles this event and removes entity from collection.
		/// </summary>
		public event EntityEditEventHandler OrderFeeRemoved;
		#endregion Events
		#region Declarations
		#endregion Declarations
		#region Properties
		/// <summary>
		/// The OrderFee currently being edited by this control.
		/// Get accessor casts base._entity to OrderFee
		/// Set accessor used by parent control to set the item currently being edited
		/// </summary>
		public BLL.Orders.OrderFee OrderFeeItem
		{
			get
			{
				return (BLL.Orders.OrderFee) _entity;
			}
			set
			{
				_entity = value; // only set by container
				Session["OrderFeeItem"] = _entity;
			}
		}
		#endregion Properties
		#region Event Handlers
		// ------------------------------------------------------------------------------
		/// <summary>Load page for editing Order Fee, getting mode and parameters.</summary>
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
						_entity = (BLL.Orders.OrderFee)Session["OrderFeeItem"];
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
					Session["OrderFeeItem"] = _entity;
				}
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditOrderFee.Page_Load"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Delete Order Fee.</summary>
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
					BLL.Orders.OrderFeeManager.DeleteOneOrderFee(OrderFeeItem, performCascade);
					Globals.AddStatusMessage("Order Fee deleted.");
				}
				else
				{
					// raise event so item is removed from collection
					if (OrderFeeRemoved != null)
					{
						OrderFeeRemoved(this, new EntityEditEventArgs(_entity));
					}
				}
				// create new object and store it in _entity
				CreateNewEntity();
				Session["OrderFeeItem"] = _entity;
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditOrderFee.btnDelete_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("OrderID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("FeeCode", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Int, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Request to create a new Order Fee.</summary>
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
				Session["OrderFeeItem"] = _entity;
				this.sectionLinks.OnSection("Basics");
				SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
				Globals.AddStatusMessage("Add new Order Fee.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				doRedirect = false;
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				doRedirect = false;
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditOrderFee.btnNew_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("OrderID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("FeeCode", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Int, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Reset form for Order Fee.</summary>
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
					Session["OrderFeeItem"] = _entity;
					sectionLinks.CurrentSection = "Basics";
				}
				else
				{
					CreateNewEntity();
				}
				Globals.AddStatusMessage("Order Fee reset.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditOrderFee.btnReset_Click"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Save Order Fee.</summary>
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
							if (OrderFeeAdded != null && (OrderFeeItem.OrderID != MOD.Data.DefaultValue.Guid || OrderFeeItem.FeeCode != MOD.Data.DefaultValue.Int || OrderFeeItem.CreatedByUserID != MOD.Data.DefaultValue.Guid || OrderFeeItem.CreatedDate != MOD.Data.DefaultValue.DateTime || OrderFeeItem.LastModifiedByUserID != MOD.Data.DefaultValue.Guid || OrderFeeItem.LastModifiedDate != MOD.Data.DefaultValue.DateTime || OrderFeeItem.Timestamp != null))
							{
								OrderFeeAdded(this, new EntityEditEventArgs(_entity));
								// create new object and store it in _entity
								CreateNewEntity();
								Session["OrderFeeItem"] = _entity;
								this.sectionLinks.OnSection("Basics");
								SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
							}
						}
						else
						{
							Globals.AddStatusMessage("Order Fee updated.");
						}
					}
					else
					{
						UpsertToDatabase(true);
						if (AccessMode == MOD.Data.AccessMode.Add)
						{
							doRedirect = true;
							Globals.AddStatusMessage("Order Fee added.");
						}
						else
						{
							Globals.AddStatusMessage("Order Fee updated.");
						}
						SetAccessModeAndDisplay(MOD.Data.AccessMode.Edit);
					}
				}
				else
				{
					Globals.AddErrorMessage(Page, "Order Fee validation failed.");
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditOrderFee.btnSave_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && isValid == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("OrderID", OrderFeeItem.OrderID.ToString());
				queryString.Add("FeeCode", OrderFeeItem.FeeCode.ToString());
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditOrderFee.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditOrderFee.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditOrderFee.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditOrderFee.Page_PreRender"));
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
		/// Create a new Order Fee object reference
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void CreateNewEntity()
		{
			BLL.Orders.OrderFee vOrderFee = new BLL.Orders.OrderFee();
			vOrderFee.OrderID = MOD.Data.DataHelper.GetGuid(Request.QueryString["OrderID"], MOD.Data.DefaultValue.Guid);
			vOrderFee.FeeCode = MOD.Data.DataHelper.GetInt(Request.QueryString["FeeCode"], MOD.Data.DefaultValue.Int);
			_entity = vOrderFee;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update form from Order Fee information.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyEntityToForm()
		{
			BLL.Orders.OrderFee vOrderFee = OrderFeeItem;
			ddlOrderID.DataValueField = "PrimaryIndex";
			ddlOrderID.DataTextField = "PrimaryName";
			if (UseWorkingSets == true && Session["Orders/OrderWorkingSet"] != null)
			{
				BLL.SortableList<BLL.Orders.Order> sessionSource = (BLL.SortableList<BLL.Orders.Order>) Session["Orders/OrderWorkingSet"];
				BLL.SortableList<BLL.Orders.Order> currentSource = new BLL.SortableList<BLL.Orders.Order>(sessionSource, true);
				if (MOD.Data.DataHelper.GetGuid(vOrderFee.OrderID, MOD.Data.DefaultValue.Guid) != MOD.Data.DefaultValue.Guid)
				{
					BLL.Orders.Order currentOrder = BLL.Orders.OrderManager.GetOneOrder(MOD.Data.DataHelper.GetGuid(vOrderFee.OrderID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions("", "", true, true));
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
				sOrder.OrderID = MOD.Data.DataHelper.GetGuid(vOrderFee.OrderID, MOD.Data.DefaultValue.Guid);
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
			ddlFeeCode.DataValueField = "PrimaryIndex";
			ddlFeeCode.DataTextField = "PrimaryName";
			if (UseWorkingSets == true && Session["Payments/FeeWorkingSet"] != null)
			{
				BLL.SortableList<BLL.Payments.Fee> sessionSource = (BLL.SortableList<BLL.Payments.Fee>) Session["Payments/FeeWorkingSet"];
				BLL.SortableList<BLL.Payments.Fee> currentSource = new BLL.SortableList<BLL.Payments.Fee>(sessionSource, true);
				if (MOD.Data.DataHelper.GetInt(vOrderFee.FeeCode, MOD.Data.DefaultValue.Int) != MOD.Data.DefaultValue.Int)
				{
					BLL.Payments.Fee currentFee = BLL.Payments.FeeManager.GetOneFee(MOD.Data.DataHelper.GetInt(vOrderFee.FeeCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions("", "", true, true));
					if (currentFee != null && currentSource.Contains(currentFee) == false)
					{
						currentSource.Insert(0, currentFee);
					}
				}
				ddlFeeCode.DataSource = currentSource;
				lnkFeeCodeWorkingSet.Visible = true;
				lnkFeeCodeWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Payments/SearchFeeData.aspx");
				lblFeeCodeWorkingSet.Visible = true;
				lblFeeCodeWorkingSet.Text = " (from Fee working set)";
			}
			else
			{
				ddlFeeCode.DataSource = BLL.Payments.FeeManager.GetAllFeeData(Globals.DBOptions, Globals.getDataOptions("FeeName", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
				lblFeeCodeWorkingSet.Visible = false;
				if (UseWorkingSets == true)
				{
					lnkFeeCodeWorkingSet.Visible = true;
					lnkFeeCodeWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Payments/SearchFeeData.aspx");
				}
				else
				{
					lnkFeeCodeWorkingSet.Visible = false;
				}
			}
			ddlFeeCode.DataBind();
			ddlFeeCode.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				BLL.Payments.Fee sFee = new BLL.Payments.Fee();
				sFee.FeeCode = MOD.Data.DataHelper.GetInt(vOrderFee.FeeCode, MOD.Data.DefaultValue.Int);
				ddlFeeCode.SelectedValue = MOD.Data.DataHelper.GetString(sFee.PrimaryIndex, "");
				sFee = null;
			}
			catch {}
			if(ddlFeeCode.SelectedValue == ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				try
				{
					ddlFeeCode.SelectedValue = MOD.Data.DataHelper.GetString(Session["Payments/FeeWorkingSetItem"], "");
				}
				catch {}
			}
			// Drop downs should be disabled when control is "Internal" and either value is constrained by container
			if (WorkflowMode == WorkflowMode.Internal)
			{
				ddlOrderID.Visible = Request.QueryString["OrderID"] == null;
				lnkOrderIDWorkingSet.Visible = lnkOrderIDWorkingSet.Visible == true && Request.QueryString["OrderID"] == null;
				lblOrderIDWorkingSet.Visible = lblOrderIDWorkingSet.Visible == true && Request.QueryString["OrderID"] == null;
				valOrderID.Enabled = Request.QueryString["OrderID"] == null;
				lblOrderIDDisplay.Visible = Request.QueryString["OrderID"] == null;
				ddlFeeCode.Visible = Request.QueryString["FeeCode"] == null;
				lnkFeeCodeWorkingSet.Visible = lnkFeeCodeWorkingSet.Visible == true && Request.QueryString["FeeCode"] == null;
				lblFeeCodeWorkingSet.Visible = lblFeeCodeWorkingSet.Visible == true && Request.QueryString["FeeCode"] == null;
				valFeeCode.Enabled = Request.QueryString["FeeCode"] == null;
				lblFeeCodeDisplay.Visible = Request.QueryString["FeeCode"] == null;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set Order Fee information from the form.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyFormToEntity()
		{
			BLL.Orders.OrderFee vOrderFee = OrderFeeItem;
			if (vOrderFee == null)
			{
				throw CoreUtility.CustomAppException.WrapException(new Exception("Order Fee not found"), "EditOrderFee.CopyFormToEntity()");
			}
			if (ddlOrderID.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Orders.Order sOrder = new BLL.Orders.Order(ddlOrderID.SelectedValue, false);
				vOrderFee.OrderID = MOD.Data.DataHelper.GetGuid(sOrder.OrderID, MOD.Data.DefaultValue.Guid);
				sOrder = null;
			}
			if (ddlFeeCode.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Payments.Fee sFee = new BLL.Payments.Fee(ddlFeeCode.SelectedValue, false);
				vOrderFee.FeeCode = MOD.Data.DataHelper.GetInt(sFee.FeeCode, MOD.Data.DefaultValue.Int);
				sFee = null;
				vOrderFee.PrimaryName += MOD.Data.DataHelper.GetString(ddlFeeCode.SelectedItem.Text, MOD.Data.DefaultValue.String) + ";";
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// Load entity from database, store in _entity and Session["OrderFeeItem"]
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void LoadEntity()
		{
			_entity = null;
			Guid orderID = MOD.Data.DataHelper.GetGuid(Request.QueryString["OrderID"], MOD.Data.DefaultValue.Guid);
			int feeCode = MOD.Data.DataHelper.GetInt(Request.QueryString["FeeCode"], MOD.Data.DefaultValue.Int);
			if (orderID != MOD.Data.DefaultValue.Guid && feeCode != MOD.Data.DefaultValue.Int)
			{
				_entity = BLL.Orders.OrderFeeManager.GetOneOrderFee(orderID, feeCode, Globals.getDataOptions("", "", true, true));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update Order Fee information in the database.</summary>
		///
		// ------------------------------------------------------------------------------
		private void UpsertToDatabase(bool performCascade)
		{
			BLL.Orders.OrderFee vOrderFee = OrderFeeItem;
			if (AccessMode == MOD.Data.AccessMode.Add)
			{
				BLL.Orders.OrderFeeManager.AddOneOrderFee(vOrderFee, performCascade);
			}
			else if (AccessMode == MOD.Data.AccessMode.Edit)
			{
				BLL.Orders.OrderFeeManager.UpdateOneOrderFee(vOrderFee, performCascade);
			}
			OrderFeeItem.OrderID = vOrderFee.OrderID;
			OrderFeeItem.FeeCode = vOrderFee.FeeCode;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set access and display modes for presenting Order Fee information.</summary>
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
					lblTitle.Text = "Add Order&nbsp;Fee";
					btnSave.Text = "Add";
					break;
				case MOD.Data.AccessMode.Edit:
					lblTitle.Text = "Edit Order&nbsp;Fee";
					btnSave.Text = "Save";
					break;
				case MOD.Data.AccessMode.View:
					lblTitle.Text = "View Order&nbsp;Fee";
					break;
				default:
					lblTitle.Text = "View Order&nbsp;Fee";
					break;
			}
			btnDelete.Visible = IsDeleteAvailable;
			btnNew.Visible = IsEditAvailable;
			btnSave.Visible = IsEditAvailable || IsAddAvailable;
			ddlOrderID.Enabled = IsAddAvailable;
			ddlFeeCode.Enabled = IsAddAvailable;
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
		/// <summary>Initialize component for OrderFee, add delegates here.</summary>
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