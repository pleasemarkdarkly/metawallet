
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
	/// <summary>Edit Coupon is used to help manage Coupon information.</summary>
	///
	/// File History:
	/// <created>6/1/2007 (Chris Grundy)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class EditCoupon  : Components.Desktop.BaseFormlUserControl
	{
		#region Events
		/// <summary>
		/// Raised when "Add" button is clicked in internal mode.
		/// Container handles this event and adds entity to collection.
		/// </summary>
		public event EntityEditEventHandler CouponAdded;
		/// <summary>
		/// Raised when "Remove" button is clicked in internal mode.
		/// Container handles this event and removes entity from collection.
		/// </summary>
		public event EntityEditEventHandler CouponRemoved;
		#endregion Events
		#region Declarations
		#endregion Declarations
		#region Properties
		/// <summary>
		/// The Coupon currently being edited by this control.
		/// Get accessor casts base._entity to Coupon
		/// Set accessor used by parent control to set the item currently being edited
		/// </summary>
		public BLL.Promotions.Coupon CouponItem
		{
			get
			{
				return (BLL.Promotions.Coupon) _entity;
			}
			set
			{
				_entity = value; // only set by container
				Session["CouponItem"] = _entity;
			}
		}
		#endregion Properties
		#region Event Handlers
		// ------------------------------------------------------------------------------
		/// <summary>Load page for editing Coupon, getting mode and parameters.</summary>
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
						_entity = (BLL.Promotions.Coupon)Session["CouponItem"];
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
					Session["CouponItem"] = _entity;
				}
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditCoupon.Page_Load"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Delete Coupon.</summary>
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
					BLL.Promotions.CouponManager.DeleteOneCoupon(CouponItem, performCascade);
					Globals.AddStatusMessage("Coupon deleted.");
				}
				else
				{
					// raise event so item is removed from collection
					if (CouponRemoved != null)
					{
						CouponRemoved(this, new EntityEditEventArgs(_entity));
					}
				}
				// create new object and store it in _entity
				CreateNewEntity();
				Session["CouponItem"] = _entity;
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditCoupon.btnDelete_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("CouponCode", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Int, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Request to create a new Coupon.</summary>
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
				Session["CouponItem"] = _entity;
				this.sectionLinks.OnSection("Basics");
				SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
				Globals.AddStatusMessage("Add new Coupon.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				doRedirect = false;
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				doRedirect = false;
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditCoupon.btnNew_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("CouponCode", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Int, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Reset form for Coupon.</summary>
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
					Session["CouponItem"] = _entity;
					sectionLinks.CurrentSection = "Basics";
				}
				else
				{
					CreateNewEntity();
				}
				Globals.AddStatusMessage("Coupon reset.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditCoupon.btnReset_Click"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Save Coupon.</summary>
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
							if (CouponAdded != null && (CouponItem.CouponCode != MOD.Data.DefaultValue.Int || CouponItem.CouponName != MOD.Data.DefaultValue.String || CouponItem.CouponText != MOD.Data.DefaultValue.String || CouponItem.CouponTypeCode != MOD.Data.DefaultValue.Int || CouponItem.DiscountTypeCode != MOD.Data.DefaultValue.Int || CouponItem.DiscountAmount != MOD.Data.DefaultValue.Decimal || CouponItem.TriggerAmount != MOD.Data.DefaultValue.Decimal || CouponItem.CurrencyCode != MOD.Data.DefaultValue.Int || CouponItem.DaysToExpire != MOD.Data.DefaultValue.Int || CouponItem.IsFeeEnabled != MOD.Data.DefaultValue.Bool || CouponItem.IsPaymentEnabled != MOD.Data.DefaultValue.Bool || CouponItem.Description != MOD.Data.DefaultValue.String || CouponItem.IsActive != MOD.Data.DefaultValue.Bool || CouponItem.CreatedByUserID != MOD.Data.DefaultValue.Guid || CouponItem.CreatedDate != MOD.Data.DefaultValue.DateTime || CouponItem.LastModifiedByUserID != MOD.Data.DefaultValue.Guid || CouponItem.LastModifiedDate != MOD.Data.DefaultValue.DateTime || CouponItem.Timestamp != null))
							{
								CouponAdded(this, new EntityEditEventArgs(_entity));
								// create new object and store it in _entity
								CreateNewEntity();
								Session["CouponItem"] = _entity;
								this.sectionLinks.OnSection("Basics");
								SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
							}
						}
						else
						{
							Globals.AddStatusMessage("Coupon updated.");
						}
					}
					else
					{
						UpsertToDatabase(true);
						if (AccessMode == MOD.Data.AccessMode.Add)
						{
							doRedirect = true;
							Globals.AddStatusMessage("Coupon added.");
						}
						else
						{
							Globals.AddStatusMessage("Coupon updated.");
						}
						SetAccessModeAndDisplay(MOD.Data.AccessMode.Edit);
					}
				}
				else
				{
					Globals.AddErrorMessage(Page, "Coupon validation failed.");
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditCoupon.btnSave_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && isValid == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("CouponCode", CouponItem.CouponCode.ToString());
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditCoupon.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditCoupon.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditCoupon.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditCoupon.Page_PreRender"));
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
		/// Create a new Coupon object reference
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void CreateNewEntity()
		{
			BLL.Promotions.Coupon vCoupon = new BLL.Promotions.Coupon();
			vCoupon.CouponCode = MOD.Data.DataHelper.GetInt(Request.QueryString["CouponCode"], MOD.Data.DefaultValue.Int);
			vCoupon.CouponTypeCode = MOD.Data.DataHelper.GetInt(Request.QueryString["CouponTypeCode"], MOD.Data.DefaultValue.Int);
			vCoupon.DiscountTypeCode = MOD.Data.DataHelper.GetInt(Request.QueryString["DiscountTypeCode"], MOD.Data.DefaultValue.Int);
			vCoupon.CurrencyCode = MOD.Data.DataHelper.GetInt(Request.QueryString["CurrencyCode"], MOD.Data.DefaultValue.Int);
			_entity = vCoupon;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update form from Coupon information.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyEntityToForm()
		{
			BLL.Promotions.Coupon vCoupon = CouponItem;
			txtCouponCode.Text = MOD.Data.EditHelper.GetInt(vCoupon.CouponCode);
			txtCouponName.Text = MOD.Data.EditHelper.GetString(vCoupon.CouponName);
			txtCouponText.Text = MOD.Data.EditHelper.GetString(vCoupon.CouponText);
			ddlCouponTypeCode.DataValueField = "PrimaryIndex";
			ddlCouponTypeCode.DataTextField = "PrimaryName";
			ddlCouponTypeCode.DataSource = BLL.Promotions.CouponTypeManager.GetAllCouponTypeData(Globals.DBOptions, Globals.getDataOptions("CouponTypeName", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
			ddlCouponTypeCode.DataBind();
			ddlCouponTypeCode.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				BLL.Promotions.CouponType sCouponType = new BLL.Promotions.CouponType();
				sCouponType.CouponTypeCode = MOD.Data.DataHelper.GetInt(vCoupon.CouponTypeCode, MOD.Data.DefaultValue.Int);
				ddlCouponTypeCode.SelectedValue = MOD.Data.DataHelper.GetString(sCouponType.PrimaryIndex, "");
				sCouponType = null;
			}
			catch {}
			if(ddlCouponTypeCode.SelectedValue == ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				try
				{
					ddlCouponTypeCode.SelectedValue = MOD.Data.DataHelper.GetString(Session["Promotions/CouponTypeWorkingSetItem"], "");
				}
				catch {}
			}
			ddlDiscountTypeCode.DataValueField = "PrimaryIndex";
			ddlDiscountTypeCode.DataTextField = "PrimaryName";
			ddlDiscountTypeCode.DataSource = BLL.Promotions.DiscountTypeManager.GetAllDiscountTypeData(Globals.DBOptions, Globals.getDataOptions("DiscountTypeName", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
			ddlDiscountTypeCode.DataBind();
			ddlDiscountTypeCode.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				BLL.Promotions.DiscountType sDiscountType = new BLL.Promotions.DiscountType();
				sDiscountType.DiscountTypeCode = MOD.Data.DataHelper.GetInt(vCoupon.DiscountTypeCode, MOD.Data.DefaultValue.Int);
				ddlDiscountTypeCode.SelectedValue = MOD.Data.DataHelper.GetString(sDiscountType.PrimaryIndex, "");
				sDiscountType = null;
			}
			catch {}
			if(ddlDiscountTypeCode.SelectedValue == ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				try
				{
					ddlDiscountTypeCode.SelectedValue = MOD.Data.DataHelper.GetString(Session["Promotions/DiscountTypeWorkingSetItem"], "");
				}
				catch {}
			}
			txtDiscountAmount.Text = MOD.Data.EditHelper.GetCurrency(vCoupon.DiscountAmount);
			txtTriggerAmount.Text = MOD.Data.EditHelper.GetCurrency(vCoupon.TriggerAmount);
			ddlCurrencyCode.DataValueField = "PrimaryIndex";
			ddlCurrencyCode.DataTextField = "PrimaryName";
			ddlCurrencyCode.DataSource = BLL.Accounts.CurrencyManager.GetAllCurrencyData(Globals.DBOptions, Globals.getDataOptions("CurrencyName", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
			ddlCurrencyCode.DataBind();
			ddlCurrencyCode.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				BLL.Accounts.Currency sCurrency = new BLL.Accounts.Currency();
				sCurrency.CurrencyCode = MOD.Data.DataHelper.GetInt(vCoupon.CurrencyCode, MOD.Data.DefaultValue.Int);
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
			txtDaysToExpire.Text = MOD.Data.EditHelper.GetInt(vCoupon.DaysToExpire);
			chkIsFeeEnabled.Checked = MOD.Data.DataHelper.GetBool(vCoupon.IsFeeEnabled, MOD.Data.DefaultValue.Bool);
			chkIsPaymentEnabled.Checked = MOD.Data.DataHelper.GetBool(vCoupon.IsPaymentEnabled, MOD.Data.DefaultValue.Bool);
			txtDescription.Text = MOD.Data.EditHelper.GetString(vCoupon.Description);
			chkIsActive.Checked = MOD.Data.DataHelper.GetBool(vCoupon.IsActive, MOD.Data.DefaultValue.Bool);
			// Drop downs should be disabled when control is "Internal" and either value is constrained by container
			if (WorkflowMode == WorkflowMode.Internal)
			{
				ddlCouponTypeCode.Visible = Request.QueryString["CouponTypeCode"] == null;
				valCouponTypeCode.Enabled = Request.QueryString["CouponTypeCode"] == null;
				lblCouponTypeCodeDisplay.Visible = Request.QueryString["CouponTypeCode"] == null;
				ddlDiscountTypeCode.Visible = Request.QueryString["DiscountTypeCode"] == null;
				valDiscountTypeCode.Enabled = Request.QueryString["DiscountTypeCode"] == null;
				lblDiscountTypeCodeDisplay.Visible = Request.QueryString["DiscountTypeCode"] == null;
				ddlCurrencyCode.Visible = Request.QueryString["CurrencyCode"] == null;
				valCurrencyCode.Enabled = Request.QueryString["CurrencyCode"] == null;
				lblCurrencyCodeDisplay.Visible = Request.QueryString["CurrencyCode"] == null;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set Coupon information from the form.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyFormToEntity()
		{
			BLL.Promotions.Coupon vCoupon = CouponItem;
			if (vCoupon == null)
			{
				throw CoreUtility.CustomAppException.WrapException(new Exception("Coupon not found"), "EditCoupon.CopyFormToEntity()");
			}
			try
			{
				vCoupon.CouponCode = MOD.Data.DataHelper.GetInt(txtCouponCode.Text, MOD.Data.DefaultValue.Int);
			}
			catch {}
			vCoupon.CouponName = EditHelper.EncodeStringForDB(MOD.Data.DataHelper.GetString(txtCouponName.Text, null));
			vCoupon.CouponText = EditHelper.EncodeStringForDB(MOD.Data.DataHelper.GetString(txtCouponText.Text, null));
			if (ddlCouponTypeCode.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Promotions.CouponType sCouponType = new BLL.Promotions.CouponType(ddlCouponTypeCode.SelectedValue, false);
				vCoupon.CouponTypeCode = MOD.Data.DataHelper.GetInt(sCouponType.CouponTypeCode, MOD.Data.DefaultValue.Int);
				sCouponType = null;
				vCoupon.PrimaryName += MOD.Data.DataHelper.GetString(ddlCouponTypeCode.SelectedItem.Text, MOD.Data.DefaultValue.String) + ";";
			}
			if (ddlDiscountTypeCode.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Promotions.DiscountType sDiscountType = new BLL.Promotions.DiscountType(ddlDiscountTypeCode.SelectedValue, false);
				vCoupon.DiscountTypeCode = MOD.Data.DataHelper.GetInt(sDiscountType.DiscountTypeCode, MOD.Data.DefaultValue.Int);
				sDiscountType = null;
				vCoupon.PrimaryName += MOD.Data.DataHelper.GetString(ddlDiscountTypeCode.SelectedItem.Text, MOD.Data.DefaultValue.String) + ";";
			}
			try
			{
				vCoupon.DiscountAmount = MOD.Data.DataHelper.GetDecimal(txtDiscountAmount.Text, MOD.Data.DefaultValue.Decimal);
			}
			catch {}
			try
			{
				vCoupon.TriggerAmount = MOD.Data.DataHelper.GetDecimal(txtTriggerAmount.Text, MOD.Data.DefaultValue.Decimal);
			}
			catch {}
			if (ddlCurrencyCode.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Accounts.Currency sCurrency = new BLL.Accounts.Currency(ddlCurrencyCode.SelectedValue, false);
				vCoupon.CurrencyCode = MOD.Data.DataHelper.GetInt(sCurrency.CurrencyCode, MOD.Data.DefaultValue.Int);
				sCurrency = null;
				vCoupon.PrimaryName += MOD.Data.DataHelper.GetString(ddlCurrencyCode.SelectedItem.Text, MOD.Data.DefaultValue.String) + ";";
			}
			try
			{
				vCoupon.DaysToExpire = MOD.Data.DataHelper.GetInt(txtDaysToExpire.Text, MOD.Data.DefaultValue.Int);
			}
			catch {}
			vCoupon.IsFeeEnabled = chkIsFeeEnabled.Checked;
			vCoupon.IsPaymentEnabled = chkIsPaymentEnabled.Checked;
			vCoupon.Description = EditHelper.EncodeStringForDB(MOD.Data.DataHelper.GetString(txtDescription.Text, null));
			vCoupon.IsActive = chkIsActive.Checked;
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// Load entity from database, store in _entity and Session["CouponItem"]
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void LoadEntity()
		{
			_entity = null;
			int couponCode = MOD.Data.DataHelper.GetInt(Request.QueryString["CouponCode"], MOD.Data.DefaultValue.Int);
			if (couponCode != MOD.Data.DefaultValue.Int)
			{
				_entity = BLL.Promotions.CouponManager.GetOneCoupon(couponCode, Globals.getDataOptions("", "", true, true));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update Coupon information in the database.</summary>
		///
		// ------------------------------------------------------------------------------
		private void UpsertToDatabase(bool performCascade)
		{
			BLL.Promotions.Coupon vCoupon = CouponItem;
			if (AccessMode == MOD.Data.AccessMode.Add)
			{
				BLL.Promotions.CouponManager.AddOneCoupon(vCoupon, performCascade);
			}
			else if (AccessMode == MOD.Data.AccessMode.Edit)
			{
				BLL.Promotions.CouponManager.UpdateOneCoupon(vCoupon, performCascade);
			}
			CouponItem.CouponCode = vCoupon.CouponCode;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set access and display modes for presenting Coupon information.</summary>
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
					lblTitle.Text = "Add Coupon";
					btnSave.Text = "Add";
					break;
				case MOD.Data.AccessMode.Edit:
					lblTitle.Text = "Edit Coupon";
					btnSave.Text = "Save";
					break;
				case MOD.Data.AccessMode.View:
					lblTitle.Text = "View Coupon";
					break;
				default:
					lblTitle.Text = "View Coupon";
					break;
			}
			btnDelete.Visible = IsDeleteAvailable;
			btnNew.Visible = IsEditAvailable;
			btnSave.Visible = IsEditAvailable || IsAddAvailable;
			txtCouponCode.Enabled = IsAddAvailable;
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
		/// <summary>Initialize component for Coupon, add delegates here.</summary>
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