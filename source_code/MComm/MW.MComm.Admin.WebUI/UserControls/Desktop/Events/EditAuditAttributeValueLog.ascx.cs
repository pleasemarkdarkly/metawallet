
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
	/// <summary>Edit Audit Attribute Value Log is used to help manage AuditAttributeValueLog information.</summary>
	///
	/// File History:
	/// <created>6/1/2007 (Chris Grundy)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class EditAuditAttributeValueLog  : Components.Desktop.BaseFormlUserControl
	{
		#region Events
		/// <summary>
		/// Raised when "Add" button is clicked in internal mode.
		/// Container handles this event and adds entity to collection.
		/// </summary>
		public event EntityEditEventHandler AuditAttributeValueLogAdded;
		/// <summary>
		/// Raised when "Remove" button is clicked in internal mode.
		/// Container handles this event and removes entity from collection.
		/// </summary>
		public event EntityEditEventHandler AuditAttributeValueLogRemoved;
		#endregion Events
		#region Declarations
		#endregion Declarations
		#region Properties
		/// <summary>
		/// The AuditAttributeValueLog currently being edited by this control.
		/// Get accessor casts base._entity to AuditAttributeValueLog
		/// Set accessor used by parent control to set the item currently being edited
		/// </summary>
		public BLL.Events.AuditAttributeValueLog AuditAttributeValueLogItem
		{
			get
			{
				return (BLL.Events.AuditAttributeValueLog) _entity;
			}
			set
			{
				_entity = value; // only set by container
				Session["AuditAttributeValueLogItem"] = _entity;
			}
		}
		#endregion Properties
		#region Event Handlers
		// ------------------------------------------------------------------------------
		/// <summary>Load page for editing Audit Attribute Value Log, getting mode and parameters.</summary>
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
						_entity = (BLL.Events.AuditAttributeValueLog)Session["AuditAttributeValueLogItem"];
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
					Session["AuditAttributeValueLogItem"] = _entity;
				}
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditAuditAttributeValueLog.Page_Load"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Delete Audit Attribute Value Log.</summary>
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
					if (AuditAttributeValueLogRemoved != null)
					{
						AuditAttributeValueLogRemoved(this, new EntityEditEventArgs(_entity));
					}
				}
				// create new object and store it in _entity
				CreateNewEntity();
				Session["AuditAttributeValueLogItem"] = _entity;
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditAuditAttributeValueLog.btnDelete_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("AuditAttributeValueLogID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Request to create a new Audit Attribute Value Log.</summary>
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
				Session["AuditAttributeValueLogItem"] = _entity;
				this.sectionLinks.OnSection("Basics");
				SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
				Globals.AddStatusMessage("Add new Audit Attribute Value Log.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				doRedirect = false;
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				doRedirect = false;
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditAuditAttributeValueLog.btnNew_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("AuditAttributeValueLogID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Reset form for Audit Attribute Value Log.</summary>
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
					Session["AuditAttributeValueLogItem"] = _entity;
					sectionLinks.CurrentSection = "Basics";
				}
				else
				{
					CreateNewEntity();
				}
				Globals.AddStatusMessage("Audit Attribute Value Log reset.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditAuditAttributeValueLog.btnReset_Click"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Save Audit Attribute Value Log.</summary>
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
							if (AuditAttributeValueLogAdded != null && (AuditAttributeValueLogItem.AuditAttributeValueLogID != MOD.Data.DefaultValue.Guid || AuditAttributeValueLogItem.AuditLogID != MOD.Data.DefaultValue.Guid || AuditAttributeValueLogItem.BaseAttributeID != MOD.Data.DefaultValue.Guid || AuditAttributeValueLogItem.AttributeValue != MOD.Data.DefaultValue.String || AuditAttributeValueLogItem.CreatedByUserID != MOD.Data.DefaultValue.Guid || AuditAttributeValueLogItem.CreatedDate != MOD.Data.DefaultValue.DateTime || AuditAttributeValueLogItem.LastModifiedByUserID != MOD.Data.DefaultValue.Guid || AuditAttributeValueLogItem.LastModifiedDate != MOD.Data.DefaultValue.DateTime || AuditAttributeValueLogItem.Timestamp != null))
							{
								AuditAttributeValueLogAdded(this, new EntityEditEventArgs(_entity));
								// create new object and store it in _entity
								CreateNewEntity();
								Session["AuditAttributeValueLogItem"] = _entity;
								this.sectionLinks.OnSection("Basics");
								SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
							}
						}
						else
						{
							Globals.AddStatusMessage("Audit Attribute Value Log updated.");
						}
					}
					else
					{
						UpsertToDatabase(true);
						if (AccessMode == MOD.Data.AccessMode.Add)
						{
							doRedirect = true;
							Globals.AddStatusMessage("Audit Attribute Value Log added.");
						}
						else
						{
							Globals.AddStatusMessage("Audit Attribute Value Log updated.");
						}
						SetAccessModeAndDisplay(MOD.Data.AccessMode.Edit);
					}
				}
				else
				{
					Globals.AddErrorMessage(Page, "Audit Attribute Value Log validation failed.");
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditAuditAttributeValueLog.btnSave_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && isValid == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("AuditAttributeValueLogID", AuditAttributeValueLogItem.AuditAttributeValueLogID.ToString());
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditAuditAttributeValueLog.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditAuditAttributeValueLog.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditAuditAttributeValueLog.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditAuditAttributeValueLog.Page_PreRender"));
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
		/// Create a new Audit Attribute Value Log object reference
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void CreateNewEntity()
		{
			BLL.Events.AuditAttributeValueLog vAuditAttributeValueLog = new BLL.Events.AuditAttributeValueLog();
			vAuditAttributeValueLog.AuditAttributeValueLogID = MOD.Data.DataHelper.GetGuid(Request.QueryString["AuditAttributeValueLogID"], MOD.Data.DefaultValue.Guid);
			vAuditAttributeValueLog.AuditLogID = MOD.Data.DataHelper.GetGuid(Request.QueryString["AuditLogID"], MOD.Data.DefaultValue.Guid);
			vAuditAttributeValueLog.BaseAttributeID = MOD.Data.DataHelper.GetGuid(Request.QueryString["BaseAttributeID"], MOD.Data.DefaultValue.Guid);
			_entity = vAuditAttributeValueLog;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update form from Audit Attribute Value Log information.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyEntityToForm()
		{
			BLL.Events.AuditAttributeValueLog vAuditAttributeValueLog = AuditAttributeValueLogItem;
			lblAuditAttributeValueLogID.Text = MOD.Data.DataHelper.GetString(vAuditAttributeValueLog.AuditAttributeValueLogID, "");
			ddlAuditLogID.DataValueField = "PrimaryIndex";
			ddlAuditLogID.DataTextField = "PrimaryName";
			if (UseWorkingSets == true && Session["Events/AuditLogWorkingSet"] != null)
			{
				BLL.SortableList<BLL.Events.AuditLog> sessionSource = (BLL.SortableList<BLL.Events.AuditLog>) Session["Events/AuditLogWorkingSet"];
				BLL.SortableList<BLL.Events.AuditLog> currentSource = new BLL.SortableList<BLL.Events.AuditLog>(sessionSource, true);
				if (MOD.Data.DataHelper.GetGuid(vAuditAttributeValueLog.AuditLogID, MOD.Data.DefaultValue.Guid) != MOD.Data.DefaultValue.Guid)
				{
					BLL.Events.AuditLog currentAuditLog = BLL.Events.AuditLogManager.GetOneAuditLog(MOD.Data.DataHelper.GetGuid(vAuditAttributeValueLog.AuditLogID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions("", "", true, true));
					if (currentAuditLog != null && currentSource.Contains(currentAuditLog) == false)
					{
						currentSource.Insert(0, currentAuditLog);
					}
				}
				ddlAuditLogID.DataSource = currentSource;
				lnkAuditLogIDWorkingSet.Visible = true;
				lnkAuditLogIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Events/SearchAuditLogData.aspx");
				lblAuditLogIDWorkingSet.Visible = true;
				lblAuditLogIDWorkingSet.Text = " (from Audit Log working set)";
			}
			else
			{
				ddlAuditLogID.DataSource = BLL.Events.AuditLogManager.GetAllAuditLogData(Globals.DBOptions, Globals.getDataOptions("", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
				lblAuditLogIDWorkingSet.Visible = false;
				if (UseWorkingSets == true)
				{
					lnkAuditLogIDWorkingSet.Visible = true;
					lnkAuditLogIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Events/SearchAuditLogData.aspx");
				}
				else
				{
					lnkAuditLogIDWorkingSet.Visible = false;
				}
			}
			ddlAuditLogID.DataBind();
			ddlAuditLogID.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				BLL.Events.AuditLog sAuditLog = new BLL.Events.AuditLog();
				sAuditLog.AuditLogID = MOD.Data.DataHelper.GetGuid(vAuditAttributeValueLog.AuditLogID, MOD.Data.DefaultValue.Guid);
				ddlAuditLogID.SelectedValue = MOD.Data.DataHelper.GetString(sAuditLog.PrimaryIndex, "");
				sAuditLog = null;
			}
			catch {}
			if(ddlAuditLogID.SelectedValue == ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				try
				{
					ddlAuditLogID.SelectedValue = MOD.Data.DataHelper.GetString(Session["Events/AuditLogWorkingSetItem"], "");
				}
				catch {}
			}
			ddlBaseAttributeID.DataValueField = "PrimaryIndex";
			ddlBaseAttributeID.DataTextField = "PrimaryName";
			if (UseWorkingSets == true && Session["Events/EventAttributeWorkingSet"] != null)
			{
				BLL.SortableList<BLL.Events.EventAttribute> sessionSource = (BLL.SortableList<BLL.Events.EventAttribute>) Session["Events/EventAttributeWorkingSet"];
				BLL.SortableList<BLL.Events.EventAttribute> currentSource = new BLL.SortableList<BLL.Events.EventAttribute>(sessionSource, true);
				if (MOD.Data.DataHelper.GetGuid(vAuditAttributeValueLog.BaseAttributeID, MOD.Data.DefaultValue.Guid) != MOD.Data.DefaultValue.Guid)
				{
					BLL.Events.EventAttribute currentEventAttribute = BLL.Events.EventAttributeManager.GetOneEventAttribute(MOD.Data.DataHelper.GetGuid(vAuditAttributeValueLog.BaseAttributeID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions("", "", true, true));
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
				sEventAttribute.BaseAttributeID = MOD.Data.DataHelper.GetGuid(vAuditAttributeValueLog.BaseAttributeID, MOD.Data.DefaultValue.Guid);
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
			txtAttributeValue.Text = MOD.Data.EditHelper.GetString(vAuditAttributeValueLog.AttributeValue);
			// Drop downs should be disabled when control is "Internal" and either value is constrained by container
			if (WorkflowMode == WorkflowMode.Internal)
			{
				ddlAuditLogID.Visible = Request.QueryString["AuditLogID"] == null;
				lnkAuditLogIDWorkingSet.Visible = lnkAuditLogIDWorkingSet.Visible == true && Request.QueryString["AuditLogID"] == null;
				lblAuditLogIDWorkingSet.Visible = lblAuditLogIDWorkingSet.Visible == true && Request.QueryString["AuditLogID"] == null;
				valAuditLogID.Enabled = Request.QueryString["AuditLogID"] == null;
				lblAuditLogIDDisplay.Visible = Request.QueryString["AuditLogID"] == null;
				ddlBaseAttributeID.Visible = Request.QueryString["BaseAttributeID"] == null;
				lnkBaseAttributeIDWorkingSet.Visible = lnkBaseAttributeIDWorkingSet.Visible == true && Request.QueryString["BaseAttributeID"] == null;
				lblBaseAttributeIDWorkingSet.Visible = lblBaseAttributeIDWorkingSet.Visible == true && Request.QueryString["BaseAttributeID"] == null;
				valBaseAttributeID.Enabled = Request.QueryString["BaseAttributeID"] == null;
				lblBaseAttributeIDDisplay.Visible = Request.QueryString["BaseAttributeID"] == null;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set Audit Attribute Value Log information from the form.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyFormToEntity()
		{
			BLL.Events.AuditAttributeValueLog vAuditAttributeValueLog = AuditAttributeValueLogItem;
			if (vAuditAttributeValueLog == null)
			{
				throw CoreUtility.CustomAppException.WrapException(new Exception("Audit Attribute Value Log not found"), "EditAuditAttributeValueLog.CopyFormToEntity()");
			}
			if (ddlAuditLogID.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Events.AuditLog sAuditLog = new BLL.Events.AuditLog(ddlAuditLogID.SelectedValue, false);
				vAuditAttributeValueLog.AuditLogID = MOD.Data.DataHelper.GetGuid(sAuditLog.AuditLogID, MOD.Data.DefaultValue.Guid);
				sAuditLog = null;
			}
			if (ddlBaseAttributeID.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Events.EventAttribute sEventAttribute = new BLL.Events.EventAttribute(ddlBaseAttributeID.SelectedValue, false);
				vAuditAttributeValueLog.BaseAttributeID = MOD.Data.DataHelper.GetGuid(sEventAttribute.BaseAttributeID, MOD.Data.DefaultValue.Guid);
				sEventAttribute = null;
			}
			vAuditAttributeValueLog.AttributeValue = EditHelper.EncodeStringForDB(MOD.Data.DataHelper.GetString(txtAttributeValue.Text, null));
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// Load entity from database, store in _entity and Session["AuditAttributeValueLogItem"]
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void LoadEntity()
		{
			_entity = null;
			Guid auditAttributeValueLogID = MOD.Data.DataHelper.GetGuid(Request.QueryString["AuditAttributeValueLogID"], MOD.Data.DefaultValue.Guid);
			if (auditAttributeValueLogID != MOD.Data.DefaultValue.Guid)
			{
				_entity = BLL.Events.AuditAttributeValueLogManager.GetOneAuditAttributeValueLog(auditAttributeValueLogID, Globals.getDataOptions("", "", true, true));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update Audit Attribute Value Log information in the database.</summary>
		///
		// ------------------------------------------------------------------------------
		private void UpsertToDatabase(bool performCascade)
		{
			BLL.Events.AuditAttributeValueLog vAuditAttributeValueLog = AuditAttributeValueLogItem;
			if (AccessMode == MOD.Data.AccessMode.Add)
			{
				BLL.Events.AuditAttributeValueLogManager.LogOneAuditAttributeValueLog(vAuditAttributeValueLog, performCascade);
			}
			else if (AccessMode == MOD.Data.AccessMode.Edit)
			{
			}
			AuditAttributeValueLogItem.AuditAttributeValueLogID = vAuditAttributeValueLog.AuditAttributeValueLogID;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set access and display modes for presenting Audit Attribute Value Log information.</summary>
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
					lblTitle.Text = "Add Audit&nbsp;Attribute&nbsp;Value&nbsp;Log";
					btnSave.Text = "Add";
					break;
				case MOD.Data.AccessMode.Edit:
					lblTitle.Text = "Edit Audit&nbsp;Attribute&nbsp;Value&nbsp;Log";
					btnSave.Text = "Save";
					break;
				case MOD.Data.AccessMode.View:
					lblTitle.Text = "View Audit&nbsp;Attribute&nbsp;Value&nbsp;Log";
					break;
				default:
					lblTitle.Text = "View Audit&nbsp;Attribute&nbsp;Value&nbsp;Log";
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
		/// <summary>Initialize component for AuditAttributeValueLog, add delegates here.</summary>
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