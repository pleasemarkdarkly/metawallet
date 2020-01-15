
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
using MW.MComm.WalletSolution.BLL.Promotions;
using CoreUtility = MW.MComm.WalletSolution.Utility;
using MW.MComm.Admin.WebUI.Components.Desktop;
namespace MW.MComm.Admin.WebUI.UserControls.Desktop.Promotions
{
	// ------------------------------------------------------------------------------
	/// <summary>Edit Meta Partner Coupon is used to help manage MetaPartnerCoupon information.</summary>
	///
	/// File History:
	/// <created>6/1/2007 (Chris Grundy)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class EditMetaPartnerCoupon  : Components.Desktop.BaseFormlUserControl
	{
		#region Events
		/// <summary>
		/// Raised when "Add" button is clicked in internal mode.
		/// Container handles this event and adds entity to collection.
		/// </summary>
		public event EntityEditEventHandler MetaPartnerCouponAdded;
		/// <summary>
		/// Raised when "Remove" button is clicked in internal mode.
		/// Container handles this event and removes entity from collection.
		/// </summary>
		public event EntityEditEventHandler MetaPartnerCouponRemoved;
		#endregion Events
		#region Declarations
		#endregion Declarations
		#region Properties
		/// <summary>
		/// The MetaPartnerCoupon currently being edited by this control.
		/// Get accessor casts base._entity to MetaPartnerCoupon
		/// Set accessor used by parent control to set the item currently being edited
		/// </summary>
		public BLL.Promotions.MetaPartnerCoupon MetaPartnerCouponItem
		{
			get
			{
				return (BLL.Promotions.MetaPartnerCoupon) _entity;
			}
			set
			{
				_entity = value; // only set by container
				Session["MetaPartnerCouponItem"] = _entity;
			}
		}
		#endregion Properties
		#region Event Handlers
		// ------------------------------------------------------------------------------
		/// <summary>Load page for editing Meta Partner Coupon, getting mode and parameters.</summary>
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
						_entity = (BLL.Promotions.MetaPartnerCoupon)Session["MetaPartnerCouponItem"];
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
					Session["MetaPartnerCouponItem"] = _entity;
				}
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditMetaPartnerCoupon.Page_Load"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Delete Meta Partner Coupon.</summary>
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
					BLL.Promotions.MetaPartnerCouponManager.DeleteOneMetaPartnerCoupon(MetaPartnerCouponItem, performCascade);
					Globals.AddStatusMessage("Meta Partner Coupon deleted.");
				}
				else
				{
					// raise event so item is removed from collection
					if (MetaPartnerCouponRemoved != null)
					{
						MetaPartnerCouponRemoved(this, new EntityEditEventArgs(_entity));
					}
				}
				// create new object and store it in _entity
				CreateNewEntity();
				Session["MetaPartnerCouponItem"] = _entity;
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditMetaPartnerCoupon.btnDelete_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("MetaPartnerCouponID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Request to create a new Meta Partner Coupon.</summary>
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
				Session["MetaPartnerCouponItem"] = _entity;
				this.sectionLinks.OnSection("Basics");
				SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
				Globals.AddStatusMessage("Add new Meta Partner Coupon.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				doRedirect = false;
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				doRedirect = false;
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditMetaPartnerCoupon.btnNew_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("MetaPartnerCouponID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Reset form for Meta Partner Coupon.</summary>
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
					Session["MetaPartnerCouponItem"] = _entity;
					sectionLinks.CurrentSection = "Basics";
				}
				else
				{
					CreateNewEntity();
				}
				Globals.AddStatusMessage("Meta Partner Coupon reset.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditMetaPartnerCoupon.btnReset_Click"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Save Meta Partner Coupon.</summary>
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
							if (MetaPartnerCouponAdded != null && (MetaPartnerCouponItem.MetaPartnerCouponID != MOD.Data.DefaultValue.Guid || MetaPartnerCouponItem.MetaPartnerID != MOD.Data.DefaultValue.Guid || MetaPartnerCouponItem.CouponCode != MOD.Data.DefaultValue.Int || MetaPartnerCouponItem.OriginalAmount != MOD.Data.DefaultValue.Decimal || MetaPartnerCouponItem.BalanceAmount != MOD.Data.DefaultValue.Decimal || MetaPartnerCouponItem.StartDate != MOD.Data.DefaultValue.DateTime || MetaPartnerCouponItem.EndDate != MOD.Data.DefaultValue.DateTime || MetaPartnerCouponItem.CreatedByUserID != MOD.Data.DefaultValue.Guid || MetaPartnerCouponItem.CreatedDate != MOD.Data.DefaultValue.DateTime || MetaPartnerCouponItem.LastModifiedByUserID != MOD.Data.DefaultValue.Guid || MetaPartnerCouponItem.LastModifiedDate != MOD.Data.DefaultValue.DateTime || MetaPartnerCouponItem.Timestamp != null))
							{
								MetaPartnerCouponAdded(this, new EntityEditEventArgs(_entity));
								// create new object and store it in _entity
								CreateNewEntity();
								Session["MetaPartnerCouponItem"] = _entity;
								this.sectionLinks.OnSection("Basics");
								SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
							}
						}
						else
						{
							Globals.AddStatusMessage("Meta Partner Coupon updated.");
						}
					}
					else
					{
						UpsertToDatabase(true);
						if (AccessMode == MOD.Data.AccessMode.Add)
						{
							doRedirect = true;
							Globals.AddStatusMessage("Meta Partner Coupon added.");
						}
						else
						{
							Globals.AddStatusMessage("Meta Partner Coupon updated.");
						}
						SetAccessModeAndDisplay(MOD.Data.AccessMode.Edit);
					}
				}
				else
				{
					Globals.AddErrorMessage(Page, "Meta Partner Coupon validation failed.");
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditMetaPartnerCoupon.btnSave_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && isValid == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("MetaPartnerCouponID", MetaPartnerCouponItem.MetaPartnerCouponID.ToString());
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditMetaPartnerCoupon.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditMetaPartnerCoupon.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditMetaPartnerCoupon.btnBasics_Click"));
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
				ResetStartDateCalendar(Page.IsPostBack == false);
				ResetEndDateCalendar(Page.IsPostBack == false);
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditMetaPartnerCoupon.Page_PreRender"));
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
			MetaPartnerCouponItem.StartDate = calStartDate.SelectedDate;
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
			MetaPartnerCouponItem.EndDate = calEndDate.SelectedDate;
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
		/// Create a new Meta Partner Coupon object reference
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void CreateNewEntity()
		{
			BLL.Promotions.MetaPartnerCoupon vMetaPartnerCoupon = new BLL.Promotions.MetaPartnerCoupon();
			vMetaPartnerCoupon.MetaPartnerCouponID = MOD.Data.DataHelper.GetGuid(Request.QueryString["MetaPartnerCouponID"], MOD.Data.DefaultValue.Guid);
			vMetaPartnerCoupon.MetaPartnerID = MOD.Data.DataHelper.GetGuid(Request.QueryString["MetaPartnerID"], MOD.Data.DefaultValue.Guid);
			vMetaPartnerCoupon.CouponCode = MOD.Data.DataHelper.GetInt(Request.QueryString["CouponCode"], MOD.Data.DefaultValue.Int);
			_entity = vMetaPartnerCoupon;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update form from Meta Partner Coupon information.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyEntityToForm()
		{
			BLL.Promotions.MetaPartnerCoupon vMetaPartnerCoupon = MetaPartnerCouponItem;
			lblMetaPartnerCouponID.Text = MOD.Data.DataHelper.GetString(vMetaPartnerCoupon.MetaPartnerCouponID, "");
			ddlMetaPartnerID.DataValueField = "PrimaryIndex";
			ddlMetaPartnerID.DataTextField = "PrimaryName";
			if (UseWorkingSets == true && Session["Customers/MetaPartnerWorkingSet"] != null)
			{
				BLL.SortableList<BLL.Customers.MetaPartner> sessionSource = (BLL.SortableList<BLL.Customers.MetaPartner>) Session["Customers/MetaPartnerWorkingSet"];
				BLL.SortableList<BLL.Customers.MetaPartner> currentSource = new BLL.SortableList<BLL.Customers.MetaPartner>(sessionSource, true);
				if (MOD.Data.DataHelper.GetGuid(vMetaPartnerCoupon.MetaPartnerID, MOD.Data.DefaultValue.Guid) != MOD.Data.DefaultValue.Guid)
				{
					BLL.Customers.MetaPartner currentMetaPartner = BLL.Customers.MetaPartnerManager.GetOneMetaPartner(MOD.Data.DataHelper.GetGuid(vMetaPartnerCoupon.MetaPartnerID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions("", "", true, true));
					if (currentMetaPartner != null && currentSource.Contains(currentMetaPartner) == false)
					{
						currentSource.Insert(0, currentMetaPartner);
					}
				}
				ddlMetaPartnerID.DataSource = currentSource;
				lnkMetaPartnerIDWorkingSet.Visible = true;
				lnkMetaPartnerIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Customers/SearchMetaPartnerData.aspx");
				lblMetaPartnerIDWorkingSet.Visible = true;
				lblMetaPartnerIDWorkingSet.Text = " (from Meta Partner working set)";
			}
			else
			{
				ddlMetaPartnerID.DataSource = BLL.Customers.MetaPartnerManager.GetAllMetaPartnerData(Globals.DBOptions, Globals.getDataOptions("MetaPartnerName", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
				lblMetaPartnerIDWorkingSet.Visible = false;
				if (UseWorkingSets == true)
				{
					lnkMetaPartnerIDWorkingSet.Visible = true;
					lnkMetaPartnerIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Customers/SearchMetaPartnerData.aspx");
				}
				else
				{
					lnkMetaPartnerIDWorkingSet.Visible = false;
				}
			}
			ddlMetaPartnerID.DataBind();
			ddlMetaPartnerID.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				BLL.Customers.MetaPartner sMetaPartner = new BLL.Customers.MetaPartner();
				sMetaPartner.MetaPartnerID = MOD.Data.DataHelper.GetGuid(vMetaPartnerCoupon.MetaPartnerID, MOD.Data.DefaultValue.Guid);
				ddlMetaPartnerID.SelectedValue = MOD.Data.DataHelper.GetString(sMetaPartner.PrimaryIndex, "");
				sMetaPartner = null;
			}
			catch {}
			if(ddlMetaPartnerID.SelectedValue == ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				try
				{
					ddlMetaPartnerID.SelectedValue = MOD.Data.DataHelper.GetString(Session["Customers/MetaPartnerWorkingSetItem"], "");
				}
				catch {}
			}
			ddlCouponCode.DataValueField = "PrimaryIndex";
			ddlCouponCode.DataTextField = "PrimaryName";
			if (UseWorkingSets == true && Session["Promotions/CouponWorkingSet"] != null)
			{
				BLL.SortableList<BLL.Promotions.Coupon> sessionSource = (BLL.SortableList<BLL.Promotions.Coupon>) Session["Promotions/CouponWorkingSet"];
				BLL.SortableList<BLL.Promotions.Coupon> currentSource = new BLL.SortableList<BLL.Promotions.Coupon>(sessionSource, true);
				if (MOD.Data.DataHelper.GetInt(vMetaPartnerCoupon.CouponCode, MOD.Data.DefaultValue.Int) != MOD.Data.DefaultValue.Int)
				{
					BLL.Promotions.Coupon currentCoupon = BLL.Promotions.CouponManager.GetOneCoupon(MOD.Data.DataHelper.GetInt(vMetaPartnerCoupon.CouponCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions("", "", true, true));
					if (currentCoupon != null && currentSource.Contains(currentCoupon) == false)
					{
						currentSource.Insert(0, currentCoupon);
					}
				}
				ddlCouponCode.DataSource = currentSource;
				lnkCouponCodeWorkingSet.Visible = true;
				lnkCouponCodeWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Promotions/SearchCouponData.aspx");
				lblCouponCodeWorkingSet.Visible = true;
				lblCouponCodeWorkingSet.Text = " (from Coupon working set)";
			}
			else
			{
				ddlCouponCode.DataSource = BLL.Promotions.CouponManager.GetAllCouponData(Globals.DBOptions, Globals.getDataOptions("CouponName", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
				lblCouponCodeWorkingSet.Visible = false;
				if (UseWorkingSets == true)
				{
					lnkCouponCodeWorkingSet.Visible = true;
					lnkCouponCodeWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Promotions/SearchCouponData.aspx");
				}
				else
				{
					lnkCouponCodeWorkingSet.Visible = false;
				}
			}
			ddlCouponCode.DataBind();
			ddlCouponCode.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				BLL.Promotions.Coupon sCoupon = new BLL.Promotions.Coupon();
				sCoupon.CouponCode = MOD.Data.DataHelper.GetInt(vMetaPartnerCoupon.CouponCode, MOD.Data.DefaultValue.Int);
				ddlCouponCode.SelectedValue = MOD.Data.DataHelper.GetString(sCoupon.PrimaryIndex, "");
				sCoupon = null;
			}
			catch {}
			if(ddlCouponCode.SelectedValue == ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				try
				{
					ddlCouponCode.SelectedValue = MOD.Data.DataHelper.GetString(Session["Promotions/CouponWorkingSetItem"], "");
				}
				catch {}
			}
			txtOriginalAmount.Text = MOD.Data.EditHelper.GetCurrency(vMetaPartnerCoupon.OriginalAmount);
			txtBalanceAmount.Text = MOD.Data.EditHelper.GetCurrency(vMetaPartnerCoupon.BalanceAmount);
			txtStartDate.Text = MOD.Data.EditHelper.GetDate(vMetaPartnerCoupon.StartDate);
			txtEndDate.Text = MOD.Data.EditHelper.GetDate(vMetaPartnerCoupon.EndDate);
			// Drop downs should be disabled when control is "Internal" and either value is constrained by container
			if (WorkflowMode == WorkflowMode.Internal)
			{
				ddlMetaPartnerID.Visible = Request.QueryString["MetaPartnerID"] == null;
				lnkMetaPartnerIDWorkingSet.Visible = lnkMetaPartnerIDWorkingSet.Visible == true && Request.QueryString["MetaPartnerID"] == null;
				lblMetaPartnerIDWorkingSet.Visible = lblMetaPartnerIDWorkingSet.Visible == true && Request.QueryString["MetaPartnerID"] == null;
				valMetaPartnerID.Enabled = Request.QueryString["MetaPartnerID"] == null;
				lblMetaPartnerIDDisplay.Visible = Request.QueryString["MetaPartnerID"] == null;
				ddlCouponCode.Visible = Request.QueryString["CouponCode"] == null;
				lnkCouponCodeWorkingSet.Visible = lnkCouponCodeWorkingSet.Visible == true && Request.QueryString["CouponCode"] == null;
				lblCouponCodeWorkingSet.Visible = lblCouponCodeWorkingSet.Visible == true && Request.QueryString["CouponCode"] == null;
				valCouponCode.Enabled = Request.QueryString["CouponCode"] == null;
				lblCouponCodeDisplay.Visible = Request.QueryString["CouponCode"] == null;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set Meta Partner Coupon information from the form.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyFormToEntity()
		{
			BLL.Promotions.MetaPartnerCoupon vMetaPartnerCoupon = MetaPartnerCouponItem;
			if (vMetaPartnerCoupon == null)
			{
				throw CoreUtility.CustomAppException.WrapException(new Exception("Meta Partner Coupon not found"), "EditMetaPartnerCoupon.CopyFormToEntity()");
			}
			if (ddlMetaPartnerID.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Customers.MetaPartner sMetaPartner = new BLL.Customers.MetaPartner(ddlMetaPartnerID.SelectedValue, false);
				vMetaPartnerCoupon.MetaPartnerID = MOD.Data.DataHelper.GetGuid(sMetaPartner.MetaPartnerID, MOD.Data.DefaultValue.Guid);
				sMetaPartner = null;
				vMetaPartnerCoupon.PrimaryName += MOD.Data.DataHelper.GetString(ddlMetaPartnerID.SelectedItem.Text, MOD.Data.DefaultValue.String) + ";";
			}
			if (ddlCouponCode.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Promotions.Coupon sCoupon = new BLL.Promotions.Coupon(ddlCouponCode.SelectedValue, false);
				vMetaPartnerCoupon.CouponCode = MOD.Data.DataHelper.GetInt(sCoupon.CouponCode, MOD.Data.DefaultValue.Int);
				sCoupon = null;
				vMetaPartnerCoupon.PrimaryName += MOD.Data.DataHelper.GetString(ddlCouponCode.SelectedItem.Text, MOD.Data.DefaultValue.String) + ";";
			}
			try
			{
				vMetaPartnerCoupon.OriginalAmount = MOD.Data.DataHelper.GetDecimal(txtOriginalAmount.Text, MOD.Data.DefaultValue.Decimal);
			}
			catch {}
			try
			{
				vMetaPartnerCoupon.BalanceAmount = MOD.Data.DataHelper.GetDecimal(txtBalanceAmount.Text, MOD.Data.DefaultValue.Decimal);
			}
			catch {}
			try
			{
				vMetaPartnerCoupon.StartDate = MOD.Data.DataHelper.GetDateTime(txtStartDate.Text, MOD.Data.DefaultValue.DateTime);
			}
			catch {}
			try
			{
				vMetaPartnerCoupon.EndDate = MOD.Data.DataHelper.GetDateTime(txtEndDate.Text, MOD.Data.DefaultValue.DateTime);
			}
			catch {}
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// Load entity from database, store in _entity and Session["MetaPartnerCouponItem"]
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void LoadEntity()
		{
			_entity = null;
			Guid metaPartnerCouponID = MOD.Data.DataHelper.GetGuid(Request.QueryString["MetaPartnerCouponID"], MOD.Data.DefaultValue.Guid);
			if (metaPartnerCouponID != MOD.Data.DefaultValue.Guid)
			{
				_entity = BLL.Promotions.MetaPartnerCouponManager.GetOneMetaPartnerCoupon(metaPartnerCouponID, Globals.getDataOptions("", "", true, true));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update Meta Partner Coupon information in the database.</summary>
		///
		// ------------------------------------------------------------------------------
		private void UpsertToDatabase(bool performCascade)
		{
			BLL.Promotions.MetaPartnerCoupon vMetaPartnerCoupon = MetaPartnerCouponItem;
			if (AccessMode == MOD.Data.AccessMode.Add)
			{
				BLL.Promotions.MetaPartnerCouponManager.UpsertOneMetaPartnerCoupon(vMetaPartnerCoupon, performCascade);
			}
			else if (AccessMode == MOD.Data.AccessMode.Edit)
			{
				BLL.Promotions.MetaPartnerCouponManager.UpsertOneMetaPartnerCoupon(vMetaPartnerCoupon, performCascade);
			}
			MetaPartnerCouponItem.MetaPartnerCouponID = vMetaPartnerCoupon.MetaPartnerCouponID;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set access and display modes for presenting Meta Partner Coupon information.</summary>
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
					lblTitle.Text = "Add Meta&nbsp;Partner&nbsp;Coupon";
					btnSave.Text = "Add";
					break;
				case MOD.Data.AccessMode.Edit:
					lblTitle.Text = "Edit Meta&nbsp;Partner&nbsp;Coupon";
					btnSave.Text = "Save";
					break;
				case MOD.Data.AccessMode.View:
					lblTitle.Text = "View Meta&nbsp;Partner&nbsp;Coupon";
					break;
				default:
					lblTitle.Text = "View Meta&nbsp;Partner&nbsp;Coupon";
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
		/// <summary>Initialize component for MetaPartnerCoupon, add delegates here.</summary>
		///
		// ------------------------------------------------------------------------------
		private void InitializeComponent()
		{
			this.calStartDate.SelectionChanged += new System.EventHandler(calStartDate_SelectionChanged);
			this.btnStartDateCalendar.Click += new EventHandler(btnStartDateCalendar_Click);
			this.calEndDate.SelectionChanged += new System.EventHandler(calEndDate_SelectionChanged);
			this.btnEndDateCalendar.Click += new EventHandler(btnEndDateCalendar_Click);
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