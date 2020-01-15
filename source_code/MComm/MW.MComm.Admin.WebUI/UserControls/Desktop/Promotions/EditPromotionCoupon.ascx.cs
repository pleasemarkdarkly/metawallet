
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
	/// <summary>Edit Promotion Coupon is used to help manage PromotionCoupon information.</summary>
	///
	/// File History:
	/// <created>6/1/2007 (Chris Grundy)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class EditPromotionCoupon  : Components.Desktop.BaseFormlUserControl
	{
		#region Events
		/// <summary>
		/// Raised when "Add" button is clicked in internal mode.
		/// Container handles this event and adds entity to collection.
		/// </summary>
		public event EntityEditEventHandler PromotionCouponAdded;
		/// <summary>
		/// Raised when "Remove" button is clicked in internal mode.
		/// Container handles this event and removes entity from collection.
		/// </summary>
		public event EntityEditEventHandler PromotionCouponRemoved;
		#endregion Events
		#region Declarations
		#endregion Declarations
		#region Properties
		/// <summary>
		/// The PromotionCoupon currently being edited by this control.
		/// Get accessor casts base._entity to PromotionCoupon
		/// Set accessor used by parent control to set the item currently being edited
		/// </summary>
		public BLL.Promotions.PromotionCoupon PromotionCouponItem
		{
			get
			{
				return (BLL.Promotions.PromotionCoupon) _entity;
			}
			set
			{
				_entity = value; // only set by container
				Session["PromotionCouponItem"] = _entity;
			}
		}
		#endregion Properties
		#region Event Handlers
		// ------------------------------------------------------------------------------
		/// <summary>Load page for editing Promotion Coupon, getting mode and parameters.</summary>
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
						_entity = (BLL.Promotions.PromotionCoupon)Session["PromotionCouponItem"];
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
					Session["PromotionCouponItem"] = _entity;
				}
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditPromotionCoupon.Page_Load"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Delete Promotion Coupon.</summary>
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
					BLL.Promotions.PromotionCouponManager.DeleteOnePromotionCoupon(PromotionCouponItem, performCascade);
					Globals.AddStatusMessage("Promotion Coupon deleted.");
				}
				else
				{
					// raise event so item is removed from collection
					if (PromotionCouponRemoved != null)
					{
						PromotionCouponRemoved(this, new EntityEditEventArgs(_entity));
					}
				}
				// create new object and store it in _entity
				CreateNewEntity();
				Session["PromotionCouponItem"] = _entity;
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditPromotionCoupon.btnDelete_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("PromotionCode", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Int, ""));
				queryString.Add("CouponCode", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Int, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Request to create a new Promotion Coupon.</summary>
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
				Session["PromotionCouponItem"] = _entity;
				this.sectionLinks.OnSection("Basics");
				SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
				Globals.AddStatusMessage("Add new Promotion Coupon.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				doRedirect = false;
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				doRedirect = false;
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditPromotionCoupon.btnNew_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("PromotionCode", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Int, ""));
				queryString.Add("CouponCode", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Int, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Reset form for Promotion Coupon.</summary>
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
					Session["PromotionCouponItem"] = _entity;
					sectionLinks.CurrentSection = "Basics";
				}
				else
				{
					CreateNewEntity();
				}
				Globals.AddStatusMessage("Promotion Coupon reset.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditPromotionCoupon.btnReset_Click"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Save Promotion Coupon.</summary>
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
							if (PromotionCouponAdded != null && (PromotionCouponItem.PromotionCode != MOD.Data.DefaultValue.Int || PromotionCouponItem.CouponCode != MOD.Data.DefaultValue.Int || PromotionCouponItem.Rank != MOD.Data.DefaultValue.Int || PromotionCouponItem.CreatedByUserID != MOD.Data.DefaultValue.Guid || PromotionCouponItem.CreatedDate != MOD.Data.DefaultValue.DateTime || PromotionCouponItem.LastModifiedByUserID != MOD.Data.DefaultValue.Guid || PromotionCouponItem.LastModifiedDate != MOD.Data.DefaultValue.DateTime || PromotionCouponItem.Timestamp != null))
							{
								PromotionCouponAdded(this, new EntityEditEventArgs(_entity));
								// create new object and store it in _entity
								CreateNewEntity();
								Session["PromotionCouponItem"] = _entity;
								this.sectionLinks.OnSection("Basics");
								SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
							}
						}
						else
						{
							Globals.AddStatusMessage("Promotion Coupon updated.");
						}
					}
					else
					{
						UpsertToDatabase(true);
						if (AccessMode == MOD.Data.AccessMode.Add)
						{
							doRedirect = true;
							Globals.AddStatusMessage("Promotion Coupon added.");
						}
						else
						{
							Globals.AddStatusMessage("Promotion Coupon updated.");
						}
						SetAccessModeAndDisplay(MOD.Data.AccessMode.Edit);
					}
				}
				else
				{
					Globals.AddErrorMessage(Page, "Promotion Coupon validation failed.");
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditPromotionCoupon.btnSave_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && isValid == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("PromotionCode", PromotionCouponItem.PromotionCode.ToString());
				queryString.Add("CouponCode", PromotionCouponItem.CouponCode.ToString());
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditPromotionCoupon.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditPromotionCoupon.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditPromotionCoupon.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditPromotionCoupon.Page_PreRender"));
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
		/// Create a new Promotion Coupon object reference
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void CreateNewEntity()
		{
			BLL.Promotions.PromotionCoupon vPromotionCoupon = new BLL.Promotions.PromotionCoupon();
			vPromotionCoupon.PromotionCode = MOD.Data.DataHelper.GetInt(Request.QueryString["PromotionCode"], MOD.Data.DefaultValue.Int);
			vPromotionCoupon.CouponCode = MOD.Data.DataHelper.GetInt(Request.QueryString["CouponCode"], MOD.Data.DefaultValue.Int);
			_entity = vPromotionCoupon;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update form from Promotion Coupon information.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyEntityToForm()
		{
			BLL.Promotions.PromotionCoupon vPromotionCoupon = PromotionCouponItem;
			ddlPromotionCode.DataValueField = "PrimaryIndex";
			ddlPromotionCode.DataTextField = "PrimaryName";
			if (UseWorkingSets == true && Session["Promotions/PromotionWorkingSet"] != null)
			{
				BLL.SortableList<BLL.Promotions.Promotion> sessionSource = (BLL.SortableList<BLL.Promotions.Promotion>) Session["Promotions/PromotionWorkingSet"];
				BLL.SortableList<BLL.Promotions.Promotion> currentSource = new BLL.SortableList<BLL.Promotions.Promotion>(sessionSource, true);
				if (MOD.Data.DataHelper.GetInt(vPromotionCoupon.PromotionCode, MOD.Data.DefaultValue.Int) != MOD.Data.DefaultValue.Int)
				{
					BLL.Promotions.Promotion currentPromotion = BLL.Promotions.PromotionManager.GetOnePromotion(MOD.Data.DataHelper.GetInt(vPromotionCoupon.PromotionCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions("", "", true, true));
					if (currentPromotion != null && currentSource.Contains(currentPromotion) == false)
					{
						currentSource.Insert(0, currentPromotion);
					}
				}
				ddlPromotionCode.DataSource = currentSource;
				lnkPromotionCodeWorkingSet.Visible = true;
				lnkPromotionCodeWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Promotions/SearchPromotionData.aspx");
				lblPromotionCodeWorkingSet.Visible = true;
				lblPromotionCodeWorkingSet.Text = " (from Promotion working set)";
			}
			else
			{
				ddlPromotionCode.DataSource = BLL.Promotions.PromotionManager.GetAllPromotionData(Globals.DBOptions, Globals.getDataOptions("PromotionName", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
				lblPromotionCodeWorkingSet.Visible = false;
				if (UseWorkingSets == true)
				{
					lnkPromotionCodeWorkingSet.Visible = true;
					lnkPromotionCodeWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Promotions/SearchPromotionData.aspx");
				}
				else
				{
					lnkPromotionCodeWorkingSet.Visible = false;
				}
			}
			ddlPromotionCode.DataBind();
			ddlPromotionCode.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				BLL.Promotions.Promotion sPromotion = new BLL.Promotions.Promotion();
				sPromotion.PromotionCode = MOD.Data.DataHelper.GetInt(vPromotionCoupon.PromotionCode, MOD.Data.DefaultValue.Int);
				ddlPromotionCode.SelectedValue = MOD.Data.DataHelper.GetString(sPromotion.PrimaryIndex, "");
				sPromotion = null;
			}
			catch {}
			if(ddlPromotionCode.SelectedValue == ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				try
				{
					ddlPromotionCode.SelectedValue = MOD.Data.DataHelper.GetString(Session["Promotions/PromotionWorkingSetItem"], "");
				}
				catch {}
			}
			ddlCouponCode.DataValueField = "PrimaryIndex";
			ddlCouponCode.DataTextField = "PrimaryName";
			if (UseWorkingSets == true && Session["Promotions/CouponWorkingSet"] != null)
			{
				BLL.SortableList<BLL.Promotions.Coupon> sessionSource = (BLL.SortableList<BLL.Promotions.Coupon>) Session["Promotions/CouponWorkingSet"];
				BLL.SortableList<BLL.Promotions.Coupon> currentSource = new BLL.SortableList<BLL.Promotions.Coupon>(sessionSource, true);
				if (MOD.Data.DataHelper.GetInt(vPromotionCoupon.CouponCode, MOD.Data.DefaultValue.Int) != MOD.Data.DefaultValue.Int)
				{
					BLL.Promotions.Coupon currentCoupon = BLL.Promotions.CouponManager.GetOneCoupon(MOD.Data.DataHelper.GetInt(vPromotionCoupon.CouponCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions("", "", true, true));
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
				sCoupon.CouponCode = MOD.Data.DataHelper.GetInt(vPromotionCoupon.CouponCode, MOD.Data.DefaultValue.Int);
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
			txtRank.Text = MOD.Data.EditHelper.GetInt(vPromotionCoupon.Rank);
			// Drop downs should be disabled when control is "Internal" and either value is constrained by container
			if (WorkflowMode == WorkflowMode.Internal)
			{
				ddlPromotionCode.Visible = Request.QueryString["PromotionCode"] == null;
				lnkPromotionCodeWorkingSet.Visible = lnkPromotionCodeWorkingSet.Visible == true && Request.QueryString["PromotionCode"] == null;
				lblPromotionCodeWorkingSet.Visible = lblPromotionCodeWorkingSet.Visible == true && Request.QueryString["PromotionCode"] == null;
				valPromotionCode.Enabled = Request.QueryString["PromotionCode"] == null;
				lblPromotionCodeDisplay.Visible = Request.QueryString["PromotionCode"] == null;
				ddlCouponCode.Visible = Request.QueryString["CouponCode"] == null;
				lnkCouponCodeWorkingSet.Visible = lnkCouponCodeWorkingSet.Visible == true && Request.QueryString["CouponCode"] == null;
				lblCouponCodeWorkingSet.Visible = lblCouponCodeWorkingSet.Visible == true && Request.QueryString["CouponCode"] == null;
				valCouponCode.Enabled = Request.QueryString["CouponCode"] == null;
				lblCouponCodeDisplay.Visible = Request.QueryString["CouponCode"] == null;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set Promotion Coupon information from the form.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyFormToEntity()
		{
			BLL.Promotions.PromotionCoupon vPromotionCoupon = PromotionCouponItem;
			if (vPromotionCoupon == null)
			{
				throw CoreUtility.CustomAppException.WrapException(new Exception("Promotion Coupon not found"), "EditPromotionCoupon.CopyFormToEntity()");
			}
			if (ddlPromotionCode.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Promotions.Promotion sPromotion = new BLL.Promotions.Promotion(ddlPromotionCode.SelectedValue, false);
				vPromotionCoupon.PromotionCode = MOD.Data.DataHelper.GetInt(sPromotion.PromotionCode, MOD.Data.DefaultValue.Int);
				sPromotion = null;
				vPromotionCoupon.PrimaryName += MOD.Data.DataHelper.GetString(ddlPromotionCode.SelectedItem.Text, MOD.Data.DefaultValue.String) + ";";
			}
			if (ddlCouponCode.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Promotions.Coupon sCoupon = new BLL.Promotions.Coupon(ddlCouponCode.SelectedValue, false);
				vPromotionCoupon.CouponCode = MOD.Data.DataHelper.GetInt(sCoupon.CouponCode, MOD.Data.DefaultValue.Int);
				sCoupon = null;
				vPromotionCoupon.PrimaryName += MOD.Data.DataHelper.GetString(ddlCouponCode.SelectedItem.Text, MOD.Data.DefaultValue.String) + ";";
			}
			try
			{
				vPromotionCoupon.Rank = MOD.Data.DataHelper.GetInt(txtRank.Text, MOD.Data.DefaultValue.Int);
			}
			catch {}
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// Load entity from database, store in _entity and Session["PromotionCouponItem"]
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void LoadEntity()
		{
			_entity = null;
			int promotionCode = MOD.Data.DataHelper.GetInt(Request.QueryString["PromotionCode"], MOD.Data.DefaultValue.Int);
			int couponCode = MOD.Data.DataHelper.GetInt(Request.QueryString["CouponCode"], MOD.Data.DefaultValue.Int);
			if (promotionCode != MOD.Data.DefaultValue.Int && couponCode != MOD.Data.DefaultValue.Int)
			{
				_entity = BLL.Promotions.PromotionCouponManager.GetOnePromotionCoupon(promotionCode, couponCode, Globals.getDataOptions("", "", true, true));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update Promotion Coupon information in the database.</summary>
		///
		// ------------------------------------------------------------------------------
		private void UpsertToDatabase(bool performCascade)
		{
			BLL.Promotions.PromotionCoupon vPromotionCoupon = PromotionCouponItem;
			if (AccessMode == MOD.Data.AccessMode.Add)
			{
				BLL.Promotions.PromotionCouponManager.AddOnePromotionCoupon(vPromotionCoupon, performCascade);
			}
			else if (AccessMode == MOD.Data.AccessMode.Edit)
			{
				BLL.Promotions.PromotionCouponManager.UpdateOnePromotionCoupon(vPromotionCoupon, performCascade);
			}
			PromotionCouponItem.PromotionCode = vPromotionCoupon.PromotionCode;
			PromotionCouponItem.CouponCode = vPromotionCoupon.CouponCode;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set access and display modes for presenting Promotion Coupon information.</summary>
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
					lblTitle.Text = "Add Promotion&nbsp;Coupon";
					btnSave.Text = "Add";
					break;
				case MOD.Data.AccessMode.Edit:
					lblTitle.Text = "Edit Promotion&nbsp;Coupon";
					btnSave.Text = "Save";
					break;
				case MOD.Data.AccessMode.View:
					lblTitle.Text = "View Promotion&nbsp;Coupon";
					break;
				default:
					lblTitle.Text = "View Promotion&nbsp;Coupon";
					break;
			}
			btnDelete.Visible = IsDeleteAvailable;
			btnNew.Visible = IsEditAvailable;
			btnSave.Visible = IsEditAvailable || IsAddAvailable;
			ddlPromotionCode.Enabled = IsAddAvailable;
			ddlCouponCode.Enabled = IsAddAvailable;
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
		/// <summary>Initialize component for PromotionCoupon, add delegates here.</summary>
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