
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
using MW.MComm.WalletSolution.BLL.Events;
using CoreUtility = MW.MComm.WalletSolution.Utility;
using MW.MComm.Admin.WebUI.Components.Desktop;
namespace MW.MComm.Admin.WebUI.UserControls.Desktop.Events
{
	// ------------------------------------------------------------------------------
	/// <summary>Edit Event Promotion is used to help manage EventPromotion information.</summary>
	///
	/// File History:
	/// <created>6/1/2007 (Chris Grundy)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class EditEventPromotion  : Components.Desktop.BaseFormlUserControl
	{
		#region Events
		/// <summary>
		/// Raised when "Add" button is clicked in internal mode.
		/// Container handles this event and adds entity to collection.
		/// </summary>
		public event EntityEditEventHandler EventPromotionAdded;
		/// <summary>
		/// Raised when "Remove" button is clicked in internal mode.
		/// Container handles this event and removes entity from collection.
		/// </summary>
		public event EntityEditEventHandler EventPromotionRemoved;
		#endregion Events
		#region Declarations
		#endregion Declarations
		#region Properties
		/// <summary>
		/// The EventPromotion currently being edited by this control.
		/// Get accessor casts base._entity to EventPromotion
		/// Set accessor used by parent control to set the item currently being edited
		/// </summary>
		public BLL.Events.EventPromotion EventPromotionItem
		{
			get
			{
				return (BLL.Events.EventPromotion) _entity;
			}
			set
			{
				_entity = value; // only set by container
				Session["EventPromotionItem"] = _entity;
			}
		}
		#endregion Properties
		#region Event Handlers
		// ------------------------------------------------------------------------------
		/// <summary>Load page for editing Event Promotion, getting mode and parameters.</summary>
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
						_entity = (BLL.Events.EventPromotion)Session["EventPromotionItem"];
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
					Session["EventPromotionItem"] = _entity;
				}
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditEventPromotion.Page_Load"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Delete Event Promotion.</summary>
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
					BLL.Events.EventPromotionManager.DeleteOneEventPromotion(EventPromotionItem, performCascade);
					Globals.AddStatusMessage("Event Promotion deleted.");
				}
				else
				{
					// raise event so item is removed from collection
					if (EventPromotionRemoved != null)
					{
						EventPromotionRemoved(this, new EntityEditEventArgs(_entity));
					}
				}
				// create new object and store it in _entity
				CreateNewEntity();
				Session["EventPromotionItem"] = _entity;
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditEventPromotion.btnDelete_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("EventCode", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Int, ""));
				queryString.Add("PromotionCode", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Int, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Request to create a new Event Promotion.</summary>
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
				Session["EventPromotionItem"] = _entity;
				this.sectionLinks.OnSection("Basics");
				SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
				Globals.AddStatusMessage("Add new Event Promotion.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				doRedirect = false;
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				doRedirect = false;
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditEventPromotion.btnNew_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("EventCode", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Int, ""));
				queryString.Add("PromotionCode", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Int, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Reset form for Event Promotion.</summary>
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
					Session["EventPromotionItem"] = _entity;
					sectionLinks.CurrentSection = "Basics";
				}
				else
				{
					CreateNewEntity();
				}
				Globals.AddStatusMessage("Event Promotion reset.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditEventPromotion.btnReset_Click"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Save Event Promotion.</summary>
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
							if (EventPromotionAdded != null && (EventPromotionItem.EventCode != MOD.Data.DefaultValue.Int || EventPromotionItem.PromotionCode != MOD.Data.DefaultValue.Int || EventPromotionItem.Rank != MOD.Data.DefaultValue.Int || EventPromotionItem.CreatedByUserID != MOD.Data.DefaultValue.Guid || EventPromotionItem.CreatedDate != MOD.Data.DefaultValue.DateTime || EventPromotionItem.LastModifiedByUserID != MOD.Data.DefaultValue.Guid || EventPromotionItem.LastModifiedDate != MOD.Data.DefaultValue.DateTime || EventPromotionItem.Timestamp != null))
							{
								EventPromotionAdded(this, new EntityEditEventArgs(_entity));
								// create new object and store it in _entity
								CreateNewEntity();
								Session["EventPromotionItem"] = _entity;
								this.sectionLinks.OnSection("Basics");
								SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
							}
						}
						else
						{
							Globals.AddStatusMessage("Event Promotion updated.");
						}
					}
					else
					{
						UpsertToDatabase(true);
						if (AccessMode == MOD.Data.AccessMode.Add)
						{
							doRedirect = true;
							Globals.AddStatusMessage("Event Promotion added.");
						}
						else
						{
							Globals.AddStatusMessage("Event Promotion updated.");
						}
						SetAccessModeAndDisplay(MOD.Data.AccessMode.Edit);
					}
				}
				else
				{
					Globals.AddErrorMessage(Page, "Event Promotion validation failed.");
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditEventPromotion.btnSave_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && isValid == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("EventCode", EventPromotionItem.EventCode.ToString());
				queryString.Add("PromotionCode", EventPromotionItem.PromotionCode.ToString());
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditEventPromotion.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditEventPromotion.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditEventPromotion.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditEventPromotion.Page_PreRender"));
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
		/// Create a new Event Promotion object reference
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void CreateNewEntity()
		{
			BLL.Events.EventPromotion vEventPromotion = new BLL.Events.EventPromotion();
			vEventPromotion.EventCode = MOD.Data.DataHelper.GetInt(Request.QueryString["EventCode"], MOD.Data.DefaultValue.Int);
			vEventPromotion.PromotionCode = MOD.Data.DataHelper.GetInt(Request.QueryString["PromotionCode"], MOD.Data.DefaultValue.Int);
			_entity = vEventPromotion;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update form from Event Promotion information.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyEntityToForm()
		{
			BLL.Events.EventPromotion vEventPromotion = EventPromotionItem;
			ddlEventCode.DataValueField = "PrimaryIndex";
			ddlEventCode.DataTextField = "PrimaryName";
			if (UseWorkingSets == true && Session["Events/EventWorkingSet"] != null)
			{
				BLL.SortableList<BLL.Events.Event> sessionSource = (BLL.SortableList<BLL.Events.Event>) Session["Events/EventWorkingSet"];
				BLL.SortableList<BLL.Events.Event> currentSource = new BLL.SortableList<BLL.Events.Event>(sessionSource, true);
				if (MOD.Data.DataHelper.GetInt(vEventPromotion.EventCode, MOD.Data.DefaultValue.Int) != MOD.Data.DefaultValue.Int)
				{
					BLL.Events.Event currentEvent = BLL.Events.EventManager.GetOneEvent(MOD.Data.DataHelper.GetInt(vEventPromotion.EventCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions("", "", true, true));
					if (currentEvent != null && currentSource.Contains(currentEvent) == false)
					{
						currentSource.Insert(0, currentEvent);
					}
				}
				ddlEventCode.DataSource = currentSource;
				lnkEventCodeWorkingSet.Visible = true;
				lnkEventCodeWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Events/SearchEventData.aspx");
				lblEventCodeWorkingSet.Visible = true;
				lblEventCodeWorkingSet.Text = " (from Event working set)";
			}
			else
			{
				ddlEventCode.DataSource = BLL.Events.EventManager.GetAllEventData(Globals.DBOptions, Globals.getDataOptions("EventName", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
				lblEventCodeWorkingSet.Visible = false;
				if (UseWorkingSets == true)
				{
					lnkEventCodeWorkingSet.Visible = true;
					lnkEventCodeWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Events/SearchEventData.aspx");
				}
				else
				{
					lnkEventCodeWorkingSet.Visible = false;
				}
			}
			ddlEventCode.DataBind();
			ddlEventCode.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				BLL.Events.Event sEvent = new BLL.Events.Event();
				sEvent.EventCode = MOD.Data.DataHelper.GetInt(vEventPromotion.EventCode, MOD.Data.DefaultValue.Int);
				ddlEventCode.SelectedValue = MOD.Data.DataHelper.GetString(sEvent.PrimaryIndex, "");
				sEvent = null;
			}
			catch {}
			if(ddlEventCode.SelectedValue == ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				try
				{
					ddlEventCode.SelectedValue = MOD.Data.DataHelper.GetString(Session["Events/EventWorkingSetItem"], "");
				}
				catch {}
			}
			ddlPromotionCode.DataValueField = "PrimaryIndex";
			ddlPromotionCode.DataTextField = "PrimaryName";
			if (UseWorkingSets == true && Session["Promotions/PromotionWorkingSet"] != null)
			{
				BLL.SortableList<BLL.Promotions.Promotion> sessionSource = (BLL.SortableList<BLL.Promotions.Promotion>) Session["Promotions/PromotionWorkingSet"];
				BLL.SortableList<BLL.Promotions.Promotion> currentSource = new BLL.SortableList<BLL.Promotions.Promotion>(sessionSource, true);
				if (MOD.Data.DataHelper.GetInt(vEventPromotion.PromotionCode, MOD.Data.DefaultValue.Int) != MOD.Data.DefaultValue.Int)
				{
					BLL.Promotions.Promotion currentPromotion = BLL.Promotions.PromotionManager.GetOnePromotion(MOD.Data.DataHelper.GetInt(vEventPromotion.PromotionCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions("", "", true, true));
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
				sPromotion.PromotionCode = MOD.Data.DataHelper.GetInt(vEventPromotion.PromotionCode, MOD.Data.DefaultValue.Int);
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
			txtRank.Text = MOD.Data.EditHelper.GetInt(vEventPromotion.Rank);
			// Drop downs should be disabled when control is "Internal" and either value is constrained by container
			if (WorkflowMode == WorkflowMode.Internal)
			{
				ddlEventCode.Visible = Request.QueryString["EventCode"] == null;
				lnkEventCodeWorkingSet.Visible = lnkEventCodeWorkingSet.Visible == true && Request.QueryString["EventCode"] == null;
				lblEventCodeWorkingSet.Visible = lblEventCodeWorkingSet.Visible == true && Request.QueryString["EventCode"] == null;
				valEventCode.Enabled = Request.QueryString["EventCode"] == null;
				lblEventCodeDisplay.Visible = Request.QueryString["EventCode"] == null;
				ddlPromotionCode.Visible = Request.QueryString["PromotionCode"] == null;
				lnkPromotionCodeWorkingSet.Visible = lnkPromotionCodeWorkingSet.Visible == true && Request.QueryString["PromotionCode"] == null;
				lblPromotionCodeWorkingSet.Visible = lblPromotionCodeWorkingSet.Visible == true && Request.QueryString["PromotionCode"] == null;
				valPromotionCode.Enabled = Request.QueryString["PromotionCode"] == null;
				lblPromotionCodeDisplay.Visible = Request.QueryString["PromotionCode"] == null;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set Event Promotion information from the form.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyFormToEntity()
		{
			BLL.Events.EventPromotion vEventPromotion = EventPromotionItem;
			if (vEventPromotion == null)
			{
				throw CoreUtility.CustomAppException.WrapException(new Exception("Event Promotion not found"), "EditEventPromotion.CopyFormToEntity()");
			}
			if (ddlEventCode.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Events.Event sEvent = new BLL.Events.Event(ddlEventCode.SelectedValue, false);
				vEventPromotion.EventCode = MOD.Data.DataHelper.GetInt(sEvent.EventCode, MOD.Data.DefaultValue.Int);
				sEvent = null;
				vEventPromotion.PrimaryName += MOD.Data.DataHelper.GetString(ddlEventCode.SelectedItem.Text, MOD.Data.DefaultValue.String) + ";";
			}
			if (ddlPromotionCode.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Promotions.Promotion sPromotion = new BLL.Promotions.Promotion(ddlPromotionCode.SelectedValue, false);
				vEventPromotion.PromotionCode = MOD.Data.DataHelper.GetInt(sPromotion.PromotionCode, MOD.Data.DefaultValue.Int);
				sPromotion = null;
				vEventPromotion.PrimaryName += MOD.Data.DataHelper.GetString(ddlPromotionCode.SelectedItem.Text, MOD.Data.DefaultValue.String) + ";";
			}
			try
			{
				vEventPromotion.Rank = MOD.Data.DataHelper.GetInt(txtRank.Text, MOD.Data.DefaultValue.Int);
			}
			catch {}
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// Load entity from database, store in _entity and Session["EventPromotionItem"]
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void LoadEntity()
		{
			_entity = null;
			int eventCode = MOD.Data.DataHelper.GetInt(Request.QueryString["EventCode"], MOD.Data.DefaultValue.Int);
			int promotionCode = MOD.Data.DataHelper.GetInt(Request.QueryString["PromotionCode"], MOD.Data.DefaultValue.Int);
			if (eventCode != MOD.Data.DefaultValue.Int && promotionCode != MOD.Data.DefaultValue.Int)
			{
				_entity = BLL.Events.EventPromotionManager.GetOneEventPromotion(eventCode, promotionCode, Globals.getDataOptions("", "", true, true));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update Event Promotion information in the database.</summary>
		///
		// ------------------------------------------------------------------------------
		private void UpsertToDatabase(bool performCascade)
		{
			BLL.Events.EventPromotion vEventPromotion = EventPromotionItem;
			if (AccessMode == MOD.Data.AccessMode.Add)
			{
				BLL.Events.EventPromotionManager.AddOneEventPromotion(vEventPromotion, performCascade);
			}
			else if (AccessMode == MOD.Data.AccessMode.Edit)
			{
				BLL.Events.EventPromotionManager.UpdateOneEventPromotion(vEventPromotion, performCascade);
			}
			EventPromotionItem.EventCode = vEventPromotion.EventCode;
			EventPromotionItem.PromotionCode = vEventPromotion.PromotionCode;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set access and display modes for presenting Event Promotion information.</summary>
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
					lblTitle.Text = "Add Event&nbsp;Promotion";
					btnSave.Text = "Add";
					break;
				case MOD.Data.AccessMode.Edit:
					lblTitle.Text = "Edit Event&nbsp;Promotion";
					btnSave.Text = "Save";
					break;
				case MOD.Data.AccessMode.View:
					lblTitle.Text = "View Event&nbsp;Promotion";
					break;
				default:
					lblTitle.Text = "View Event&nbsp;Promotion";
					break;
			}
			btnDelete.Visible = IsDeleteAvailable;
			btnNew.Visible = IsEditAvailable;
			btnSave.Visible = IsEditAvailable || IsAddAvailable;
			ddlEventCode.Enabled = IsAddAvailable;
			ddlPromotionCode.Enabled = IsAddAvailable;
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
		/// <summary>Initialize component for EventPromotion, add delegates here.</summary>
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