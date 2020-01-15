
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
	/// <summary>Edit Specific Event Attribute is used to help manage SpecificEventAttribute information.</summary>
	///
	/// File History:
	/// <created>6/1/2007 (Chris Grundy)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class EditSpecificEventAttribute  : Components.Desktop.BaseFormlUserControl
	{
		#region Events
		/// <summary>
		/// Raised when "Add" button is clicked in internal mode.
		/// Container handles this event and adds entity to collection.
		/// </summary>
		public event EntityEditEventHandler SpecificEventAttributeAdded;
		/// <summary>
		/// Raised when "Remove" button is clicked in internal mode.
		/// Container handles this event and removes entity from collection.
		/// </summary>
		public event EntityEditEventHandler SpecificEventAttributeRemoved;
		#endregion Events
		#region Declarations
		#endregion Declarations
		#region Properties
		/// <summary>
		/// The SpecificEventAttribute currently being edited by this control.
		/// Get accessor casts base._entity to SpecificEventAttribute
		/// Set accessor used by parent control to set the item currently being edited
		/// </summary>
		public BLL.Events.SpecificEventAttribute SpecificEventAttributeItem
		{
			get
			{
				return (BLL.Events.SpecificEventAttribute) _entity;
			}
			set
			{
				_entity = value; // only set by container
				Session["SpecificEventAttributeItem"] = _entity;
			}
		}
		#endregion Properties
		#region Event Handlers
		// ------------------------------------------------------------------------------
		/// <summary>Load page for editing Specific Event Attribute, getting mode and parameters.</summary>
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
						_entity = (BLL.Events.SpecificEventAttribute)Session["SpecificEventAttributeItem"];
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
					Session["SpecificEventAttributeItem"] = _entity;
				}
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditSpecificEventAttribute.Page_Load"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Delete Specific Event Attribute.</summary>
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
					BLL.Events.SpecificEventAttributeManager.DeleteOneSpecificEventAttribute(SpecificEventAttributeItem, performCascade);
					Globals.AddStatusMessage("Specific Event Attribute deleted.");
				}
				else
				{
					// raise event so item is removed from collection
					if (SpecificEventAttributeRemoved != null)
					{
						SpecificEventAttributeRemoved(this, new EntityEditEventArgs(_entity));
					}
				}
				// create new object and store it in _entity
				CreateNewEntity();
				Session["SpecificEventAttributeItem"] = _entity;
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditSpecificEventAttribute.btnDelete_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("EventCode", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Int, ""));
				queryString.Add("BaseAttributeID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Request to create a new Specific Event Attribute.</summary>
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
				Session["SpecificEventAttributeItem"] = _entity;
				this.sectionLinks.OnSection("Basics");
				SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
				Globals.AddStatusMessage("Add new Specific Event Attribute.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				doRedirect = false;
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				doRedirect = false;
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditSpecificEventAttribute.btnNew_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("EventCode", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Int, ""));
				queryString.Add("BaseAttributeID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Reset form for Specific Event Attribute.</summary>
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
					Session["SpecificEventAttributeItem"] = _entity;
					sectionLinks.CurrentSection = "Basics";
				}
				else
				{
					CreateNewEntity();
				}
				Globals.AddStatusMessage("Specific Event Attribute reset.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditSpecificEventAttribute.btnReset_Click"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Save Specific Event Attribute.</summary>
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
							if (SpecificEventAttributeAdded != null && (SpecificEventAttributeItem.EventCode != MOD.Data.DefaultValue.Int || SpecificEventAttributeItem.BaseAttributeID != MOD.Data.DefaultValue.Guid || SpecificEventAttributeItem.Rank != MOD.Data.DefaultValue.Int || SpecificEventAttributeItem.CreatedByUserID != MOD.Data.DefaultValue.Guid || SpecificEventAttributeItem.CreatedDate != MOD.Data.DefaultValue.DateTime || SpecificEventAttributeItem.LastModifiedByUserID != MOD.Data.DefaultValue.Guid || SpecificEventAttributeItem.LastModifiedDate != MOD.Data.DefaultValue.DateTime || SpecificEventAttributeItem.Timestamp != null))
							{
								SpecificEventAttributeAdded(this, new EntityEditEventArgs(_entity));
								// create new object and store it in _entity
								CreateNewEntity();
								Session["SpecificEventAttributeItem"] = _entity;
								this.sectionLinks.OnSection("Basics");
								SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
							}
						}
						else
						{
							Globals.AddStatusMessage("Specific Event Attribute updated.");
						}
					}
					else
					{
						UpsertToDatabase(true);
						if (AccessMode == MOD.Data.AccessMode.Add)
						{
							doRedirect = true;
							Globals.AddStatusMessage("Specific Event Attribute added.");
						}
						else
						{
							Globals.AddStatusMessage("Specific Event Attribute updated.");
						}
						SetAccessModeAndDisplay(MOD.Data.AccessMode.Edit);
					}
				}
				else
				{
					Globals.AddErrorMessage(Page, "Specific Event Attribute validation failed.");
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditSpecificEventAttribute.btnSave_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && isValid == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("EventCode", SpecificEventAttributeItem.EventCode.ToString());
				queryString.Add("BaseAttributeID", SpecificEventAttributeItem.BaseAttributeID.ToString());
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditSpecificEventAttribute.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditSpecificEventAttribute.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditSpecificEventAttribute.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditSpecificEventAttribute.Page_PreRender"));
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
		/// Create a new Specific Event Attribute object reference
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void CreateNewEntity()
		{
			BLL.Events.SpecificEventAttribute vSpecificEventAttribute = new BLL.Events.SpecificEventAttribute();
			vSpecificEventAttribute.EventCode = MOD.Data.DataHelper.GetInt(Request.QueryString["EventCode"], MOD.Data.DefaultValue.Int);
			vSpecificEventAttribute.BaseAttributeID = MOD.Data.DataHelper.GetGuid(Request.QueryString["BaseAttributeID"], MOD.Data.DefaultValue.Guid);
			_entity = vSpecificEventAttribute;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update form from Specific Event Attribute information.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyEntityToForm()
		{
			BLL.Events.SpecificEventAttribute vSpecificEventAttribute = SpecificEventAttributeItem;
			ddlEventCode.DataValueField = "PrimaryIndex";
			ddlEventCode.DataTextField = "PrimaryName";
			if (UseWorkingSets == true && Session["Events/EventWorkingSet"] != null)
			{
				BLL.SortableList<BLL.Events.Event> sessionSource = (BLL.SortableList<BLL.Events.Event>) Session["Events/EventWorkingSet"];
				BLL.SortableList<BLL.Events.Event> currentSource = new BLL.SortableList<BLL.Events.Event>(sessionSource, true);
				if (MOD.Data.DataHelper.GetInt(vSpecificEventAttribute.EventCode, MOD.Data.DefaultValue.Int) != MOD.Data.DefaultValue.Int)
				{
					BLL.Events.Event currentEvent = BLL.Events.EventManager.GetOneEvent(MOD.Data.DataHelper.GetInt(vSpecificEventAttribute.EventCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions("", "", true, true));
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
				sEvent.EventCode = MOD.Data.DataHelper.GetInt(vSpecificEventAttribute.EventCode, MOD.Data.DefaultValue.Int);
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
			ddlBaseAttributeID.DataValueField = "PrimaryIndex";
			ddlBaseAttributeID.DataTextField = "PrimaryName";
			if (UseWorkingSets == true && Session["Events/EventAttributeWorkingSet"] != null)
			{
				BLL.SortableList<BLL.Events.EventAttribute> sessionSource = (BLL.SortableList<BLL.Events.EventAttribute>) Session["Events/EventAttributeWorkingSet"];
				BLL.SortableList<BLL.Events.EventAttribute> currentSource = new BLL.SortableList<BLL.Events.EventAttribute>(sessionSource, true);
				if (MOD.Data.DataHelper.GetGuid(vSpecificEventAttribute.BaseAttributeID, MOD.Data.DefaultValue.Guid) != MOD.Data.DefaultValue.Guid)
				{
					BLL.Events.EventAttribute currentEventAttribute = BLL.Events.EventAttributeManager.GetOneEventAttribute(MOD.Data.DataHelper.GetGuid(vSpecificEventAttribute.BaseAttributeID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions("", "", true, true));
					if (currentEventAttribute != null && currentSource.Contains(currentEventAttribute) == false)
					{
						currentSource.Insert(0, currentEventAttribute);
					}
				}
				ddlBaseAttributeID.DataSource = currentSource;
				lnkBaseAttributeIDWorkingSet.Visible = true;
				lnkBaseAttributeIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Events/SearchEventAttributeData.aspx");
				lblBaseAttributeIDWorkingSet.Visible = true;
				lblBaseAttributeIDWorkingSet.Text = " (from Event Attribute working set)";
			}
			else
			{
				ddlBaseAttributeID.DataSource = BLL.Events.EventAttributeManager.GetAllEventAttributeData(Globals.DBOptions, Globals.getDataOptions("AttributeName", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
				lblBaseAttributeIDWorkingSet.Visible = false;
				if (UseWorkingSets == true)
				{
					lnkBaseAttributeIDWorkingSet.Visible = true;
					lnkBaseAttributeIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Events/SearchEventAttributeData.aspx");
				}
				else
				{
					lnkBaseAttributeIDWorkingSet.Visible = false;
				}
			}
			ddlBaseAttributeID.DataBind();
			ddlBaseAttributeID.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				BLL.Events.EventAttribute sEventAttribute = new BLL.Events.EventAttribute();
				sEventAttribute.BaseAttributeID = MOD.Data.DataHelper.GetGuid(vSpecificEventAttribute.BaseAttributeID, MOD.Data.DefaultValue.Guid);
				ddlBaseAttributeID.SelectedValue = MOD.Data.DataHelper.GetString(sEventAttribute.PrimaryIndex, "");
				sEventAttribute = null;
			}
			catch {}
			if(ddlBaseAttributeID.SelectedValue == ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				try
				{
					ddlBaseAttributeID.SelectedValue = MOD.Data.DataHelper.GetString(Session["Events/EventAttributeWorkingSetItem"], "");
				}
				catch {}
			}
			txtRank.Text = MOD.Data.EditHelper.GetInt(vSpecificEventAttribute.Rank);
			// Drop downs should be disabled when control is "Internal" and either value is constrained by container
			if (WorkflowMode == WorkflowMode.Internal)
			{
				ddlEventCode.Visible = Request.QueryString["EventCode"] == null;
				lnkEventCodeWorkingSet.Visible = lnkEventCodeWorkingSet.Visible == true && Request.QueryString["EventCode"] == null;
				lblEventCodeWorkingSet.Visible = lblEventCodeWorkingSet.Visible == true && Request.QueryString["EventCode"] == null;
				valEventCode.Enabled = Request.QueryString["EventCode"] == null;
				lblEventCodeDisplay.Visible = Request.QueryString["EventCode"] == null;
				ddlBaseAttributeID.Visible = Request.QueryString["BaseAttributeID"] == null;
				lnkBaseAttributeIDWorkingSet.Visible = lnkBaseAttributeIDWorkingSet.Visible == true && Request.QueryString["BaseAttributeID"] == null;
				lblBaseAttributeIDWorkingSet.Visible = lblBaseAttributeIDWorkingSet.Visible == true && Request.QueryString["BaseAttributeID"] == null;
				valBaseAttributeID.Enabled = Request.QueryString["BaseAttributeID"] == null;
				lblBaseAttributeIDDisplay.Visible = Request.QueryString["BaseAttributeID"] == null;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set Specific Event Attribute information from the form.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyFormToEntity()
		{
			BLL.Events.SpecificEventAttribute vSpecificEventAttribute = SpecificEventAttributeItem;
			if (vSpecificEventAttribute == null)
			{
				throw CoreUtility.CustomAppException.WrapException(new Exception("Specific Event Attribute not found"), "EditSpecificEventAttribute.CopyFormToEntity()");
			}
			if (ddlEventCode.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Events.Event sEvent = new BLL.Events.Event(ddlEventCode.SelectedValue, false);
				vSpecificEventAttribute.EventCode = MOD.Data.DataHelper.GetInt(sEvent.EventCode, MOD.Data.DefaultValue.Int);
				sEvent = null;
				vSpecificEventAttribute.PrimaryName += MOD.Data.DataHelper.GetString(ddlEventCode.SelectedItem.Text, MOD.Data.DefaultValue.String) + ";";
			}
			if (ddlBaseAttributeID.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Events.EventAttribute sEventAttribute = new BLL.Events.EventAttribute(ddlBaseAttributeID.SelectedValue, false);
				vSpecificEventAttribute.BaseAttributeID = MOD.Data.DataHelper.GetGuid(sEventAttribute.BaseAttributeID, MOD.Data.DefaultValue.Guid);
				sEventAttribute = null;
			}
			try
			{
				vSpecificEventAttribute.Rank = MOD.Data.DataHelper.GetInt(txtRank.Text, MOD.Data.DefaultValue.Int);
			}
			catch {}
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// Load entity from database, store in _entity and Session["SpecificEventAttributeItem"]
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void LoadEntity()
		{
			_entity = null;
			int eventCode = MOD.Data.DataHelper.GetInt(Request.QueryString["EventCode"], MOD.Data.DefaultValue.Int);
			Guid baseAttributeID = MOD.Data.DataHelper.GetGuid(Request.QueryString["BaseAttributeID"], MOD.Data.DefaultValue.Guid);
			if (eventCode != MOD.Data.DefaultValue.Int && baseAttributeID != MOD.Data.DefaultValue.Guid)
			{
				_entity = BLL.Events.SpecificEventAttributeManager.GetOneSpecificEventAttribute(eventCode, baseAttributeID, Globals.getDataOptions("", "", true, true));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update Specific Event Attribute information in the database.</summary>
		///
		// ------------------------------------------------------------------------------
		private void UpsertToDatabase(bool performCascade)
		{
			BLL.Events.SpecificEventAttribute vSpecificEventAttribute = SpecificEventAttributeItem;
			if (AccessMode == MOD.Data.AccessMode.Add)
			{
				BLL.Events.SpecificEventAttributeManager.AddOneSpecificEventAttribute(vSpecificEventAttribute, performCascade);
			}
			else if (AccessMode == MOD.Data.AccessMode.Edit)
			{
				BLL.Events.SpecificEventAttributeManager.UpdateOneSpecificEventAttribute(vSpecificEventAttribute, performCascade);
			}
			SpecificEventAttributeItem.EventCode = vSpecificEventAttribute.EventCode;
			SpecificEventAttributeItem.BaseAttributeID = vSpecificEventAttribute.BaseAttributeID;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set access and display modes for presenting Specific Event Attribute information.</summary>
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
					lblTitle.Text = "Add Specific&nbsp;Event&nbsp;Attribute";
					btnSave.Text = "Add";
					break;
				case MOD.Data.AccessMode.Edit:
					lblTitle.Text = "Edit Specific&nbsp;Event&nbsp;Attribute";
					btnSave.Text = "Save";
					break;
				case MOD.Data.AccessMode.View:
					lblTitle.Text = "View Specific&nbsp;Event&nbsp;Attribute";
					break;
				default:
					lblTitle.Text = "View Specific&nbsp;Event&nbsp;Attribute";
					break;
			}
			btnDelete.Visible = IsDeleteAvailable;
			btnNew.Visible = IsEditAvailable;
			btnSave.Visible = IsEditAvailable || IsAddAvailable;
			ddlEventCode.Enabled = IsAddAvailable;
			ddlBaseAttributeID.Enabled = IsAddAvailable;
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
		/// <summary>Initialize component for SpecificEventAttribute, add delegates here.</summary>
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