
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
	/// <summary>Edit Promotion is used to help manage Promotion information.</summary>
	///
	/// File History:
	/// <created>6/1/2007 (Chris Grundy)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class EditPromotion  : Components.Desktop.BaseFormlUserControl
	{
		#region Events
		/// <summary>
		/// Raised when "Add" button is clicked in internal mode.
		/// Container handles this event and adds entity to collection.
		/// </summary>
		public event EntityEditEventHandler PromotionAdded;
		/// <summary>
		/// Raised when "Remove" button is clicked in internal mode.
		/// Container handles this event and removes entity from collection.
		/// </summary>
		public event EntityEditEventHandler PromotionRemoved;
		#endregion Events
		#region Declarations
		#endregion Declarations
		#region Properties
		/// <summary>
		/// The Promotion currently being edited by this control.
		/// Get accessor casts base._entity to Promotion
		/// Set accessor used by parent control to set the item currently being edited
		/// </summary>
		public BLL.Promotions.Promotion PromotionItem
		{
			get
			{
				return (BLL.Promotions.Promotion) _entity;
			}
			set
			{
				_entity = value; // only set by container
				Session["PromotionItem"] = _entity;
			}
		}
		#endregion Properties
		#region Event Handlers
		// ------------------------------------------------------------------------------
		/// <summary>Load page for editing Promotion, getting mode and parameters.</summary>
		///
		// ------------------------------------------------------------------------------
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				// set validator property to child controls
				listPromotionCouponData.UseValidation = UseValidation && (DisplayMode != MOD.Data.DisplayMode.SingleView);
				base.OnLoad();
				if (IsPostBack == true)
				{
					// entity may come from session, or be set by container
					if (_entity == null)
					{
						_entity = (BLL.Promotions.Promotion)Session["PromotionItem"];
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
					Session["PromotionItem"] = _entity;
				}
				// Assign entity collections into child controls
				listPromotionCouponData.Collection = PromotionItem.PromotionCouponList;
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditPromotion.Page_Load"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Delete Promotion.</summary>
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
					BLL.Promotions.PromotionManager.DeleteOnePromotion(PromotionItem, performCascade);
					Globals.AddStatusMessage("Promotion deleted.");
				}
				else
				{
					// raise event so item is removed from collection
					if (PromotionRemoved != null)
					{
						PromotionRemoved(this, new EntityEditEventArgs(_entity));
					}
				}
				// create new object and store it in _entity
				CreateNewEntity();
				Session["PromotionItem"] = _entity;
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditPromotion.btnDelete_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("PromotionCode", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Int, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Request to create a new Promotion.</summary>
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
				Session["PromotionItem"] = _entity;
				this.sectionLinks.OnSection("Basics");
				SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
				Globals.AddStatusMessage("Add new Promotion.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				doRedirect = false;
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				doRedirect = false;
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditPromotion.btnNew_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("PromotionCode", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Int, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Reset form for Promotion.</summary>
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
					Session["PromotionItem"] = _entity;
					sectionLinks.CurrentSection = "Basics";
				}
				else
				{
					CreateNewEntity();
				}
				Globals.AddStatusMessage("Promotion reset.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditPromotion.btnReset_Click"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Save Promotion.</summary>
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
							if (PromotionAdded != null && (PromotionItem.PromotionCode != MOD.Data.DefaultValue.Int || PromotionItem.PromotionName != MOD.Data.DefaultValue.String || PromotionItem.PromotionText != MOD.Data.DefaultValue.String || PromotionItem.PromotionTypeCode != MOD.Data.DefaultValue.Int || PromotionItem.StartDate != MOD.Data.DefaultValue.DateTime || PromotionItem.EndDate != MOD.Data.DefaultValue.DateTime || PromotionItem.Description != MOD.Data.DefaultValue.String || PromotionItem.IsActive != MOD.Data.DefaultValue.Bool || PromotionItem.CreatedByUserID != MOD.Data.DefaultValue.Guid || PromotionItem.CreatedDate != MOD.Data.DefaultValue.DateTime || PromotionItem.LastModifiedByUserID != MOD.Data.DefaultValue.Guid || PromotionItem.LastModifiedDate != MOD.Data.DefaultValue.DateTime || PromotionItem.Timestamp != null))
							{
								PromotionAdded(this, new EntityEditEventArgs(_entity));
								// create new object and store it in _entity
								CreateNewEntity();
								Session["PromotionItem"] = _entity;
								this.sectionLinks.OnSection("Basics");
								SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
							}
						}
						else
						{
							Globals.AddStatusMessage("Promotion updated.");
						}
					}
					else
					{
						UpsertToDatabase(true);
						if (AccessMode == MOD.Data.AccessMode.Add)
						{
							doRedirect = true;
							Globals.AddStatusMessage("Promotion added.");
						}
						else
						{
							Globals.AddStatusMessage("Promotion updated.");
						}
						SetAccessModeAndDisplay(MOD.Data.AccessMode.Edit);
					}
				}
				else
				{
					Globals.AddErrorMessage(Page, "Promotion validation failed.");
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditPromotion.btnSave_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && isValid == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("PromotionCode", PromotionItem.PromotionCode.ToString());
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditPromotion.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditPromotion.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditPromotion.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditPromotion.Page_PreRender"));
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
			PromotionItem.StartDate = calStartDate.SelectedDate;
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
			PromotionItem.EndDate = calEndDate.SelectedDate;
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
		/// Create a new Promotion object reference
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void CreateNewEntity()
		{
			BLL.Promotions.Promotion vPromotion = new BLL.Promotions.Promotion();
			vPromotion.PromotionCode = MOD.Data.DataHelper.GetInt(Request.QueryString["PromotionCode"], MOD.Data.DefaultValue.Int);
			vPromotion.PromotionTypeCode = MOD.Data.DataHelper.GetInt(Request.QueryString["PromotionTypeCode"], MOD.Data.DefaultValue.Int);
			_entity = vPromotion;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update form from Promotion information.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyEntityToForm()
		{
			BLL.Promotions.Promotion vPromotion = PromotionItem;
			txtPromotionCode.Text = MOD.Data.EditHelper.GetInt(vPromotion.PromotionCode);
			txtPromotionName.Text = MOD.Data.EditHelper.GetString(vPromotion.PromotionName);
			txtPromotionText.Text = MOD.Data.EditHelper.GetString(vPromotion.PromotionText);
			ddlPromotionTypeCode.DataValueField = "PrimaryIndex";
			ddlPromotionTypeCode.DataTextField = "PrimaryName";
			ddlPromotionTypeCode.DataSource = BLL.Promotions.PromotionTypeManager.GetAllPromotionTypeData(Globals.DBOptions, Globals.getDataOptions("PromotionTypeName", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
			ddlPromotionTypeCode.DataBind();
			ddlPromotionTypeCode.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				BLL.Promotions.PromotionType sPromotionType = new BLL.Promotions.PromotionType();
				sPromotionType.PromotionTypeCode = MOD.Data.DataHelper.GetInt(vPromotion.PromotionTypeCode, MOD.Data.DefaultValue.Int);
				ddlPromotionTypeCode.SelectedValue = MOD.Data.DataHelper.GetString(sPromotionType.PrimaryIndex, "");
				sPromotionType = null;
			}
			catch {}
			if(ddlPromotionTypeCode.SelectedValue == ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				try
				{
					ddlPromotionTypeCode.SelectedValue = MOD.Data.DataHelper.GetString(Session["Promotions/PromotionTypeWorkingSetItem"], "");
				}
				catch {}
			}
			txtStartDate.Text = MOD.Data.EditHelper.GetDate(vPromotion.StartDate);
			txtEndDate.Text = MOD.Data.EditHelper.GetDate(vPromotion.EndDate);
			txtDescription.Text = MOD.Data.EditHelper.GetString(vPromotion.Description);
			chkIsActive.Checked = MOD.Data.DataHelper.GetBool(vPromotion.IsActive, MOD.Data.DefaultValue.Bool);
			// Drop downs should be disabled when control is "Internal" and either value is constrained by container
			if (WorkflowMode == WorkflowMode.Internal)
			{
				ddlPromotionTypeCode.Visible = Request.QueryString["PromotionTypeCode"] == null;
				valPromotionTypeCode.Enabled = Request.QueryString["PromotionTypeCode"] == null;
				lblPromotionTypeCodeDisplay.Visible = Request.QueryString["PromotionTypeCode"] == null;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set Promotion information from the form.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyFormToEntity()
		{
			BLL.Promotions.Promotion vPromotion = PromotionItem;
			if (vPromotion == null)
			{
				throw CoreUtility.CustomAppException.WrapException(new Exception("Promotion not found"), "EditPromotion.CopyFormToEntity()");
			}
			try
			{
				vPromotion.PromotionCode = MOD.Data.DataHelper.GetInt(txtPromotionCode.Text, MOD.Data.DefaultValue.Int);
			}
			catch {}
			vPromotion.PromotionName = EditHelper.EncodeStringForDB(MOD.Data.DataHelper.GetString(txtPromotionName.Text, null));
			vPromotion.PromotionText = EditHelper.EncodeStringForDB(MOD.Data.DataHelper.GetString(txtPromotionText.Text, null));
			if (ddlPromotionTypeCode.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Promotions.PromotionType sPromotionType = new BLL.Promotions.PromotionType(ddlPromotionTypeCode.SelectedValue, false);
				vPromotion.PromotionTypeCode = MOD.Data.DataHelper.GetInt(sPromotionType.PromotionTypeCode, MOD.Data.DefaultValue.Int);
				sPromotionType = null;
				vPromotion.PrimaryName += MOD.Data.DataHelper.GetString(ddlPromotionTypeCode.SelectedItem.Text, MOD.Data.DefaultValue.String) + ";";
			}
			try
			{
				vPromotion.StartDate = MOD.Data.DataHelper.GetDateTime(txtStartDate.Text, MOD.Data.DefaultValue.DateTime);
			}
			catch {}
			try
			{
				vPromotion.EndDate = MOD.Data.DataHelper.GetDateTime(txtEndDate.Text, MOD.Data.DefaultValue.DateTime);
			}
			catch {}
			vPromotion.Description = EditHelper.EncodeStringForDB(MOD.Data.DataHelper.GetString(txtDescription.Text, null));
			vPromotion.IsActive = chkIsActive.Checked;
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// Load entity from database, store in _entity and Session["PromotionItem"]
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void LoadEntity()
		{
			_entity = null;
			int promotionCode = MOD.Data.DataHelper.GetInt(Request.QueryString["PromotionCode"], MOD.Data.DefaultValue.Int);
			if (promotionCode != MOD.Data.DefaultValue.Int)
			{
				_entity = BLL.Promotions.PromotionManager.GetOnePromotion(promotionCode, Globals.getDataOptions("", "", true, true));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update Promotion information in the database.</summary>
		///
		// ------------------------------------------------------------------------------
		private void UpsertToDatabase(bool performCascade)
		{
			BLL.Promotions.Promotion vPromotion = PromotionItem;
			if (AccessMode == MOD.Data.AccessMode.Add)
			{
				BLL.Promotions.PromotionManager.AddOnePromotion(vPromotion, performCascade);
			}
			else if (AccessMode == MOD.Data.AccessMode.Edit)
			{
				BLL.Promotions.PromotionManager.UpdateOnePromotion(vPromotion, performCascade);
			}
			PromotionItem.PromotionCode = vPromotion.PromotionCode;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set access and display modes for presenting Promotion information.</summary>
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
					lblTitle.Text = "Add Promotion";
					btnSave.Text = "Add";
					break;
				case MOD.Data.AccessMode.Edit:
					lblTitle.Text = "Edit Promotion";
					btnSave.Text = "Save";
					break;
				case MOD.Data.AccessMode.View:
					lblTitle.Text = "View Promotion";
					break;
				default:
					lblTitle.Text = "View Promotion";
					break;
			}
			btnDelete.Visible = IsDeleteAvailable;
			btnNew.Visible = IsEditAvailable;
			btnSave.Visible = IsEditAvailable || IsAddAvailable;
			txtPromotionCode.Enabled = IsAddAvailable;
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
				Section_Promotion_Coupons.Visible = false;
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
					Section_Promotion_Coupons.Visible = true;
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
		/// <summary>Initialize component for Promotion, add delegates here.</summary>
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