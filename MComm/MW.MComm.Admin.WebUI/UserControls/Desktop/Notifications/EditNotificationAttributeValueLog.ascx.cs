
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
using MW.MComm.WalletSolution.BLL.Notifications;
using CoreUtility = MW.MComm.WalletSolution.Utility;
using MW.MComm.Admin.WebUI.Components.Desktop;
namespace MW.MComm.Admin.WebUI.UserControls.Desktop.Notifications
{
	// ------------------------------------------------------------------------------
	/// <summary>Edit Notification Attribute Value Log is used to help manage NotificationAttributeValueLog information.</summary>
	///
	/// File History:
	/// <created>6/1/2007 (Chris Grundy)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class EditNotificationAttributeValueLog  : Components.Desktop.BaseFormlUserControl
	{
		#region Events
		/// <summary>
		/// Raised when "Add" button is clicked in internal mode.
		/// Container handles this event and adds entity to collection.
		/// </summary>
		public event EntityEditEventHandler NotificationAttributeValueLogAdded;
		/// <summary>
		/// Raised when "Remove" button is clicked in internal mode.
		/// Container handles this event and removes entity from collection.
		/// </summary>
		public event EntityEditEventHandler NotificationAttributeValueLogRemoved;
		#endregion Events
		#region Declarations
		#endregion Declarations
		#region Properties
		/// <summary>
		/// The NotificationAttributeValueLog currently being edited by this control.
		/// Get accessor casts base._entity to NotificationAttributeValueLog
		/// Set accessor used by parent control to set the item currently being edited
		/// </summary>
		public BLL.Notifications.NotificationAttributeValueLog NotificationAttributeValueLogItem
		{
			get
			{
				return (BLL.Notifications.NotificationAttributeValueLog) _entity;
			}
			set
			{
				_entity = value; // only set by container
				Session["NotificationAttributeValueLogItem"] = _entity;
			}
		}
		#endregion Properties
		#region Event Handlers
		// ------------------------------------------------------------------------------
		/// <summary>Load page for editing Notification Attribute Value Log, getting mode and parameters.</summary>
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
						_entity = (BLL.Notifications.NotificationAttributeValueLog)Session["NotificationAttributeValueLogItem"];
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
					Session["NotificationAttributeValueLogItem"] = _entity;
				}
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditNotificationAttributeValueLog.Page_Load"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Delete Notification Attribute Value Log.</summary>
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
				}
				else
				{
					// raise event so item is removed from collection
					if (NotificationAttributeValueLogRemoved != null)
					{
						NotificationAttributeValueLogRemoved(this, new EntityEditEventArgs(_entity));
					}
				}
				// create new object and store it in _entity
				CreateNewEntity();
				Session["NotificationAttributeValueLogItem"] = _entity;
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditNotificationAttributeValueLog.btnDelete_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("NotificationAttributeValueLogID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Request to create a new Notification Attribute Value Log.</summary>
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
				Session["NotificationAttributeValueLogItem"] = _entity;
				this.sectionLinks.OnSection("Basics");
				SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
				Globals.AddStatusMessage("Add new Notification Attribute Value Log.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				doRedirect = false;
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				doRedirect = false;
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditNotificationAttributeValueLog.btnNew_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("NotificationAttributeValueLogID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Reset form for Notification Attribute Value Log.</summary>
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
					Session["NotificationAttributeValueLogItem"] = _entity;
					sectionLinks.CurrentSection = "Basics";
				}
				else
				{
					CreateNewEntity();
				}
				Globals.AddStatusMessage("Notification Attribute Value Log reset.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditNotificationAttributeValueLog.btnReset_Click"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Save Notification Attribute Value Log.</summary>
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
							if (NotificationAttributeValueLogAdded != null && (NotificationAttributeValueLogItem.NotificationAttributeValueLogID != MOD.Data.DefaultValue.Guid || NotificationAttributeValueLogItem.NotificationLogID != MOD.Data.DefaultValue.Guid || NotificationAttributeValueLogItem.BaseAttributeValueID != MOD.Data.DefaultValue.Guid || NotificationAttributeValueLogItem.AttributeValue != MOD.Data.DefaultValue.String || NotificationAttributeValueLogItem.CreatedByUserID != MOD.Data.DefaultValue.Guid || NotificationAttributeValueLogItem.CreatedDate != MOD.Data.DefaultValue.DateTime || NotificationAttributeValueLogItem.LastModifiedByUserID != MOD.Data.DefaultValue.Guid || NotificationAttributeValueLogItem.LastModifiedDate != MOD.Data.DefaultValue.DateTime || NotificationAttributeValueLogItem.Timestamp != null))
							{
								NotificationAttributeValueLogAdded(this, new EntityEditEventArgs(_entity));
								// create new object and store it in _entity
								CreateNewEntity();
								Session["NotificationAttributeValueLogItem"] = _entity;
								this.sectionLinks.OnSection("Basics");
								SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
							}
						}
						else
						{
							Globals.AddStatusMessage("Notification Attribute Value Log updated.");
						}
					}
					else
					{
						UpsertToDatabase(true);
						if (AccessMode == MOD.Data.AccessMode.Add)
						{
							doRedirect = true;
							Globals.AddStatusMessage("Notification Attribute Value Log added.");
						}
						else
						{
							Globals.AddStatusMessage("Notification Attribute Value Log updated.");
						}
						SetAccessModeAndDisplay(MOD.Data.AccessMode.Edit);
					}
				}
				else
				{
					Globals.AddErrorMessage(Page, "Notification Attribute Value Log validation failed.");
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditNotificationAttributeValueLog.btnSave_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && isValid == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("NotificationAttributeValueLogID", NotificationAttributeValueLogItem.NotificationAttributeValueLogID.ToString());
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditNotificationAttributeValueLog.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditNotificationAttributeValueLog.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditNotificationAttributeValueLog.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditNotificationAttributeValueLog.Page_PreRender"));
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
		/// Create a new Notification Attribute Value Log object reference
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void CreateNewEntity()
		{
			BLL.Notifications.NotificationAttributeValueLog vNotificationAttributeValueLog = new BLL.Notifications.NotificationAttributeValueLog();
			vNotificationAttributeValueLog.NotificationAttributeValueLogID = MOD.Data.DataHelper.GetGuid(Request.QueryString["NotificationAttributeValueLogID"], MOD.Data.DefaultValue.Guid);
			vNotificationAttributeValueLog.NotificationLogID = MOD.Data.DataHelper.GetGuid(Request.QueryString["NotificationLogID"], MOD.Data.DefaultValue.Guid);
			vNotificationAttributeValueLog.BaseAttributeValueID = MOD.Data.DataHelper.GetGuid(Request.QueryString["BaseAttributeValueID"], MOD.Data.DefaultValue.Guid);
			_entity = vNotificationAttributeValueLog;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update form from Notification Attribute Value Log information.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyEntityToForm()
		{
			BLL.Notifications.NotificationAttributeValueLog vNotificationAttributeValueLog = NotificationAttributeValueLogItem;
			lblNotificationAttributeValueLogID.Text = MOD.Data.DataHelper.GetString(vNotificationAttributeValueLog.NotificationAttributeValueLogID, "");
			ddlNotificationLogID.DataValueField = "PrimaryIndex";
			ddlNotificationLogID.DataTextField = "PrimaryName";
			if (UseWorkingSets == true && Session["Notifications/NotificationLogWorkingSet"] != null)
			{
				BLL.SortableList<BLL.Notifications.NotificationLog> sessionSource = (BLL.SortableList<BLL.Notifications.NotificationLog>) Session["Notifications/NotificationLogWorkingSet"];
				BLL.SortableList<BLL.Notifications.NotificationLog> currentSource = new BLL.SortableList<BLL.Notifications.NotificationLog>(sessionSource, true);
				if (MOD.Data.DataHelper.GetGuid(vNotificationAttributeValueLog.NotificationLogID, MOD.Data.DefaultValue.Guid) != MOD.Data.DefaultValue.Guid)
				{
					BLL.Notifications.NotificationLog currentNotificationLog = BLL.Notifications.NotificationLogManager.GetOneNotificationLog(MOD.Data.DataHelper.GetGuid(vNotificationAttributeValueLog.NotificationLogID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions("", "", true, true));
					if (currentNotificationLog != null && currentSource.Contains(currentNotificationLog) == false)
					{
						currentSource.Insert(0, currentNotificationLog);
					}
				}
				ddlNotificationLogID.DataSource = currentSource;
				lnkNotificationLogIDWorkingSet.Visible = true;
				lnkNotificationLogIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Notifications/SearchNotificationLogData.aspx");
				lblNotificationLogIDWorkingSet.Visible = true;
				lblNotificationLogIDWorkingSet.Text = " (from Notification Log working set)";
			}
			else
			{
				ddlNotificationLogID.DataSource = BLL.Notifications.NotificationLogManager.GetAllNotificationLogData(Globals.DBOptions, Globals.getDataOptions("", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
				lblNotificationLogIDWorkingSet.Visible = false;
				if (UseWorkingSets == true)
				{
					lnkNotificationLogIDWorkingSet.Visible = true;
					lnkNotificationLogIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Notifications/SearchNotificationLogData.aspx");
				}
				else
				{
					lnkNotificationLogIDWorkingSet.Visible = false;
				}
			}
			ddlNotificationLogID.DataBind();
			ddlNotificationLogID.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				BLL.Notifications.NotificationLog sNotificationLog = new BLL.Notifications.NotificationLog();
				sNotificationLog.NotificationLogID = MOD.Data.DataHelper.GetGuid(vNotificationAttributeValueLog.NotificationLogID, MOD.Data.DefaultValue.Guid);
				ddlNotificationLogID.SelectedValue = MOD.Data.DataHelper.GetString(sNotificationLog.PrimaryIndex, "");
				sNotificationLog = null;
			}
			catch {}
			if(ddlNotificationLogID.SelectedValue == ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				try
				{
					ddlNotificationLogID.SelectedValue = MOD.Data.DataHelper.GetString(Session["Notifications/NotificationLogWorkingSetItem"], "");
				}
				catch {}
			}
			ddlBaseAttributeValueID.DataValueField = "PrimaryIndex";
			ddlBaseAttributeValueID.DataTextField = "PrimaryName";
			if (UseWorkingSets == true && Session["Events/EventAttributeWorkingSet"] != null)
			{
				BLL.SortableList<BLL.Events.EventAttribute> sessionSource = (BLL.SortableList<BLL.Events.EventAttribute>) Session["Events/EventAttributeWorkingSet"];
				BLL.SortableList<BLL.Events.EventAttribute> currentSource = new BLL.SortableList<BLL.Events.EventAttribute>(sessionSource, true);
				if (MOD.Data.DataHelper.GetGuid(vNotificationAttributeValueLog.BaseAttributeValueID, MOD.Data.DefaultValue.Guid) != MOD.Data.DefaultValue.Guid)
				{
					BLL.Events.EventAttribute currentEventAttribute = BLL.Events.EventAttributeManager.GetOneEventAttribute(MOD.Data.DataHelper.GetGuid(vNotificationAttributeValueLog.BaseAttributeValueID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions("", "", true, true));
					if (currentEventAttribute != null && currentSource.Contains(currentEventAttribute) == false)
					{
						currentSource.Insert(0, currentEventAttribute);
					}
				}
				ddlBaseAttributeValueID.DataSource = currentSource;
				lnkBaseAttributeValueIDWorkingSet.Visible = true;
				lnkBaseAttributeValueIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Events/SearchEventAttributeData.aspx");
				lblBaseAttributeValueIDWorkingSet.Visible = true;
				lblBaseAttributeValueIDWorkingSet.Text = " (from Event Attribute working set)";
			}
			else
			{
				ddlBaseAttributeValueID.DataSource = BLL.Events.EventAttributeManager.GetAllEventAttributeData(Globals.DBOptions, Globals.getDataOptions("AttributeName", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
				lblBaseAttributeValueIDWorkingSet.Visible = false;
				if (UseWorkingSets == true)
				{
					lnkBaseAttributeValueIDWorkingSet.Visible = true;
					lnkBaseAttributeValueIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Events/SearchEventAttributeData.aspx");
				}
				else
				{
					lnkBaseAttributeValueIDWorkingSet.Visible = false;
				}
			}
			ddlBaseAttributeValueID.DataBind();
			ddlBaseAttributeValueID.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				BLL.Events.EventAttribute sEventAttribute = new BLL.Events.EventAttribute();
				sEventAttribute.BaseAttributeID = MOD.Data.DataHelper.GetGuid(vNotificationAttributeValueLog.BaseAttributeValueID, MOD.Data.DefaultValue.Guid);
				ddlBaseAttributeValueID.SelectedValue = MOD.Data.DataHelper.GetString(sEventAttribute.PrimaryIndex, "");
				sEventAttribute = null;
			}
			catch {}
			if(ddlBaseAttributeValueID.SelectedValue == ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				try
				{
					ddlBaseAttributeValueID.SelectedValue = MOD.Data.DataHelper.GetString(Session["Events/EventAttributeWorkingSetItem"], "");
				}
				catch {}
			}
			txtAttributeValue.Text = MOD.Data.EditHelper.GetString(vNotificationAttributeValueLog.AttributeValue);
			// Drop downs should be disabled when control is "Internal" and either value is constrained by container
			if (WorkflowMode == WorkflowMode.Internal)
			{
				ddlNotificationLogID.Visible = Request.QueryString["NotificationLogID"] == null;
				lnkNotificationLogIDWorkingSet.Visible = lnkNotificationLogIDWorkingSet.Visible == true && Request.QueryString["NotificationLogID"] == null;
				lblNotificationLogIDWorkingSet.Visible = lblNotificationLogIDWorkingSet.Visible == true && Request.QueryString["NotificationLogID"] == null;
				valNotificationLogID.Enabled = Request.QueryString["NotificationLogID"] == null;
				lblNotificationLogIDDisplay.Visible = Request.QueryString["NotificationLogID"] == null;
				ddlBaseAttributeValueID.Visible = Request.QueryString["BaseAttributeValueID"] == null;
				lnkBaseAttributeValueIDWorkingSet.Visible = lnkBaseAttributeValueIDWorkingSet.Visible == true && Request.QueryString["BaseAttributeValueID"] == null;
				lblBaseAttributeValueIDWorkingSet.Visible = lblBaseAttributeValueIDWorkingSet.Visible == true && Request.QueryString["BaseAttributeValueID"] == null;
				valBaseAttributeValueID.Enabled = Request.QueryString["BaseAttributeValueID"] == null;
				lblBaseAttributeValueIDDisplay.Visible = Request.QueryString["BaseAttributeValueID"] == null;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set Notification Attribute Value Log information from the form.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyFormToEntity()
		{
			BLL.Notifications.NotificationAttributeValueLog vNotificationAttributeValueLog = NotificationAttributeValueLogItem;
			if (vNotificationAttributeValueLog == null)
			{
				throw CoreUtility.CustomAppException.WrapException(new Exception("Notification Attribute Value Log not found"), "EditNotificationAttributeValueLog.CopyFormToEntity()");
			}
			if (ddlNotificationLogID.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Notifications.NotificationLog sNotificationLog = new BLL.Notifications.NotificationLog(ddlNotificationLogID.SelectedValue, false);
				vNotificationAttributeValueLog.NotificationLogID = MOD.Data.DataHelper.GetGuid(sNotificationLog.NotificationLogID, MOD.Data.DefaultValue.Guid);
				sNotificationLog = null;
			}
			if (ddlBaseAttributeValueID.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Events.EventAttribute sEventAttribute = new BLL.Events.EventAttribute(ddlBaseAttributeValueID.SelectedValue, false);
				vNotificationAttributeValueLog.BaseAttributeValueID = MOD.Data.DataHelper.GetGuid(sEventAttribute.BaseAttributeID, MOD.Data.DefaultValue.Guid);
				sEventAttribute = null;
			}
			vNotificationAttributeValueLog.AttributeValue = EditHelper.EncodeStringForDB(MOD.Data.DataHelper.GetString(txtAttributeValue.Text, null));
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// Load entity from database, store in _entity and Session["NotificationAttributeValueLogItem"]
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void LoadEntity()
		{
			_entity = null;
			Guid notificationAttributeValueLogID = MOD.Data.DataHelper.GetGuid(Request.QueryString["NotificationAttributeValueLogID"], MOD.Data.DefaultValue.Guid);
			if (notificationAttributeValueLogID != MOD.Data.DefaultValue.Guid)
			{
				_entity = BLL.Notifications.NotificationAttributeValueLogManager.GetOneNotificationAttributeValueLog(notificationAttributeValueLogID, Globals.getDataOptions("", "", true, true));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update Notification Attribute Value Log information in the database.</summary>
		///
		// ------------------------------------------------------------------------------
		private void UpsertToDatabase(bool performCascade)
		{
			BLL.Notifications.NotificationAttributeValueLog vNotificationAttributeValueLog = NotificationAttributeValueLogItem;
			if (AccessMode == MOD.Data.AccessMode.Add)
			{
				BLL.Notifications.NotificationAttributeValueLogManager.LogOneNotificationAttributeValueLog(vNotificationAttributeValueLog, performCascade);
			}
			else if (AccessMode == MOD.Data.AccessMode.Edit)
			{
			}
			NotificationAttributeValueLogItem.NotificationAttributeValueLogID = vNotificationAttributeValueLog.NotificationAttributeValueLogID;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set access and display modes for presenting Notification Attribute Value Log information.</summary>
		///
		// ------------------------------------------------------------------------------
		private void SetAccessModeAndDisplay(MOD.Data.AccessMode accessMode)
		{
			// set access mode
			if (accessMode == MOD.Data.AccessMode.Edit)
			{
				accessMode = MOD.Data.AccessMode.View;
			}
			AccessMode = accessMode;
			// set access mode display
			switch (AccessMode)
			{
				case MOD.Data.AccessMode.Add:
					lblTitle.Text = "Add Notification&nbsp;Attribute&nbsp;Value&nbsp;Log";
					btnSave.Text = "Add";
					break;
				case MOD.Data.AccessMode.Edit:
					lblTitle.Text = "Edit Notification&nbsp;Attribute&nbsp;Value&nbsp;Log";
					btnSave.Text = "Save";
					break;
				case MOD.Data.AccessMode.View:
					lblTitle.Text = "View Notification&nbsp;Attribute&nbsp;Value&nbsp;Log";
					break;
				default:
					lblTitle.Text = "View Notification&nbsp;Attribute&nbsp;Value&nbsp;Log";
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
		/// <summary>Initialize component for NotificationAttributeValueLog, add delegates here.</summary>
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