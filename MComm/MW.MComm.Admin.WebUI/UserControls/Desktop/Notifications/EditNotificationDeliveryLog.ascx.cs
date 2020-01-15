
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
	/// <summary>Edit Notification Delivery Log is used to help manage NotificationDeliveryLog information.</summary>
	///
	/// File History:
	/// <created>6/1/2007 (Chris Grundy)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class EditNotificationDeliveryLog  : Components.Desktop.BaseFormlUserControl
	{
		#region Events
		/// <summary>
		/// Raised when "Add" button is clicked in internal mode.
		/// Container handles this event and adds entity to collection.
		/// </summary>
		public event EntityEditEventHandler NotificationDeliveryLogAdded;
		/// <summary>
		/// Raised when "Remove" button is clicked in internal mode.
		/// Container handles this event and removes entity from collection.
		/// </summary>
		public event EntityEditEventHandler NotificationDeliveryLogRemoved;
		#endregion Events
		#region Declarations
		#endregion Declarations
		#region Properties
		/// <summary>
		/// The NotificationDeliveryLog currently being edited by this control.
		/// Get accessor casts base._entity to NotificationDeliveryLog
		/// Set accessor used by parent control to set the item currently being edited
		/// </summary>
		public BLL.Notifications.NotificationDeliveryLog NotificationDeliveryLogItem
		{
			get
			{
				return (BLL.Notifications.NotificationDeliveryLog) _entity;
			}
			set
			{
				_entity = value; // only set by container
				Session["NotificationDeliveryLogItem"] = _entity;
			}
		}
		#endregion Properties
		#region Event Handlers
		// ------------------------------------------------------------------------------
		/// <summary>Load page for editing Notification Delivery Log, getting mode and parameters.</summary>
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
						_entity = (BLL.Notifications.NotificationDeliveryLog)Session["NotificationDeliveryLogItem"];
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
					Session["NotificationDeliveryLogItem"] = _entity;
				}
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditNotificationDeliveryLog.Page_Load"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Delete Notification Delivery Log.</summary>
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
					BLL.Notifications.NotificationDeliveryLogManager.DeleteOneNotificationDeliveryLog(NotificationDeliveryLogItem, performCascade);
					Globals.AddStatusMessage("Notification Delivery Log deleted.");
				}
				else
				{
					// raise event so item is removed from collection
					if (NotificationDeliveryLogRemoved != null)
					{
						NotificationDeliveryLogRemoved(this, new EntityEditEventArgs(_entity));
					}
				}
				// create new object and store it in _entity
				CreateNewEntity();
				Session["NotificationDeliveryLogItem"] = _entity;
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditNotificationDeliveryLog.btnDelete_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("NotificationLogID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("MetaPartnerID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("NotificationDeliveryTypeCode", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Int, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Request to create a new Notification Delivery Log.</summary>
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
				Session["NotificationDeliveryLogItem"] = _entity;
				this.sectionLinks.OnSection("Basics");
				SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
				Globals.AddStatusMessage("Add new Notification Delivery Log.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				doRedirect = false;
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				doRedirect = false;
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditNotificationDeliveryLog.btnNew_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("NotificationLogID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("MetaPartnerID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("NotificationDeliveryTypeCode", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Int, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Reset form for Notification Delivery Log.</summary>
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
					Session["NotificationDeliveryLogItem"] = _entity;
					sectionLinks.CurrentSection = "Basics";
				}
				else
				{
					CreateNewEntity();
				}
				Globals.AddStatusMessage("Notification Delivery Log reset.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditNotificationDeliveryLog.btnReset_Click"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Save Notification Delivery Log.</summary>
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
							if (NotificationDeliveryLogAdded != null && (NotificationDeliveryLogItem.NotificationLogID != MOD.Data.DefaultValue.Guid || NotificationDeliveryLogItem.MetaPartnerID != MOD.Data.DefaultValue.Guid || NotificationDeliveryLogItem.NotificationDeliveryTypeCode != MOD.Data.DefaultValue.Int || NotificationDeliveryLogItem.CreatedByUserID != MOD.Data.DefaultValue.Guid || NotificationDeliveryLogItem.CreatedDate != MOD.Data.DefaultValue.DateTime || NotificationDeliveryLogItem.LastModifiedByUserID != MOD.Data.DefaultValue.Guid || NotificationDeliveryLogItem.LastModifiedDate != MOD.Data.DefaultValue.DateTime || NotificationDeliveryLogItem.Timestamp != null))
							{
								NotificationDeliveryLogAdded(this, new EntityEditEventArgs(_entity));
								// create new object and store it in _entity
								CreateNewEntity();
								Session["NotificationDeliveryLogItem"] = _entity;
								this.sectionLinks.OnSection("Basics");
								SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
							}
						}
						else
						{
							Globals.AddStatusMessage("Notification Delivery Log updated.");
						}
					}
					else
					{
						UpsertToDatabase(true);
						if (AccessMode == MOD.Data.AccessMode.Add)
						{
							doRedirect = true;
							Globals.AddStatusMessage("Notification Delivery Log added.");
						}
						else
						{
							Globals.AddStatusMessage("Notification Delivery Log updated.");
						}
						SetAccessModeAndDisplay(MOD.Data.AccessMode.Edit);
					}
				}
				else
				{
					Globals.AddErrorMessage(Page, "Notification Delivery Log validation failed.");
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditNotificationDeliveryLog.btnSave_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && isValid == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("NotificationLogID", NotificationDeliveryLogItem.NotificationLogID.ToString());
				queryString.Add("MetaPartnerID", NotificationDeliveryLogItem.MetaPartnerID.ToString());
				queryString.Add("NotificationDeliveryTypeCode", NotificationDeliveryLogItem.NotificationDeliveryTypeCode.ToString());
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditNotificationDeliveryLog.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditNotificationDeliveryLog.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditNotificationDeliveryLog.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditNotificationDeliveryLog.Page_PreRender"));
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
		/// Create a new Notification Delivery Log object reference
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void CreateNewEntity()
		{
			BLL.Notifications.NotificationDeliveryLog vNotificationDeliveryLog = new BLL.Notifications.NotificationDeliveryLog();
			vNotificationDeliveryLog.NotificationLogID = MOD.Data.DataHelper.GetGuid(Request.QueryString["NotificationLogID"], MOD.Data.DefaultValue.Guid);
			vNotificationDeliveryLog.MetaPartnerID = MOD.Data.DataHelper.GetGuid(Request.QueryString["MetaPartnerID"], MOD.Data.DefaultValue.Guid);
			vNotificationDeliveryLog.NotificationDeliveryTypeCode = MOD.Data.DataHelper.GetInt(Request.QueryString["NotificationDeliveryTypeCode"], MOD.Data.DefaultValue.Int);
			_entity = vNotificationDeliveryLog;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update form from Notification Delivery Log information.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyEntityToForm()
		{
			BLL.Notifications.NotificationDeliveryLog vNotificationDeliveryLog = NotificationDeliveryLogItem;
			ddlNotificationLogID.DataValueField = "PrimaryIndex";
			ddlNotificationLogID.DataTextField = "PrimaryName";
			if (UseWorkingSets == true && Session["Notifications/NotificationLogWorkingSet"] != null)
			{
				BLL.SortableList<BLL.Notifications.NotificationLog> sessionSource = (BLL.SortableList<BLL.Notifications.NotificationLog>) Session["Notifications/NotificationLogWorkingSet"];
				BLL.SortableList<BLL.Notifications.NotificationLog> currentSource = new BLL.SortableList<BLL.Notifications.NotificationLog>(sessionSource, true);
				if (MOD.Data.DataHelper.GetGuid(vNotificationDeliveryLog.NotificationLogID, MOD.Data.DefaultValue.Guid) != MOD.Data.DefaultValue.Guid)
				{
					BLL.Notifications.NotificationLog currentNotificationLog = BLL.Notifications.NotificationLogManager.GetOneNotificationLog(MOD.Data.DataHelper.GetGuid(vNotificationDeliveryLog.NotificationLogID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions("", "", true, true));
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
				sNotificationLog.NotificationLogID = MOD.Data.DataHelper.GetGuid(vNotificationDeliveryLog.NotificationLogID, MOD.Data.DefaultValue.Guid);
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
			ddlMetaPartnerID.DataValueField = "PrimaryIndex";
			ddlMetaPartnerID.DataTextField = "PrimaryName";
			if (UseWorkingSets == true && Session["Customers/MetaPartnerWorkingSet"] != null)
			{
				BLL.SortableList<BLL.Customers.MetaPartner> sessionSource = (BLL.SortableList<BLL.Customers.MetaPartner>) Session["Customers/MetaPartnerWorkingSet"];
				BLL.SortableList<BLL.Customers.MetaPartner> currentSource = new BLL.SortableList<BLL.Customers.MetaPartner>(sessionSource, true);
				if (MOD.Data.DataHelper.GetGuid(vNotificationDeliveryLog.MetaPartnerID, MOD.Data.DefaultValue.Guid) != MOD.Data.DefaultValue.Guid)
				{
					BLL.Customers.MetaPartner currentMetaPartner = BLL.Customers.MetaPartnerManager.GetOneMetaPartner(MOD.Data.DataHelper.GetGuid(vNotificationDeliveryLog.MetaPartnerID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions("", "", true, true));
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
				sMetaPartner.MetaPartnerID = MOD.Data.DataHelper.GetGuid(vNotificationDeliveryLog.MetaPartnerID, MOD.Data.DefaultValue.Guid);
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
			ddlNotificationDeliveryTypeCode.DataValueField = "PrimaryIndex";
			ddlNotificationDeliveryTypeCode.DataTextField = "PrimaryName";
			ddlNotificationDeliveryTypeCode.DataSource = BLL.Notifications.NotificationDeliveryTypeManager.GetAllNotificationDeliveryTypeData(Globals.DBOptions, Globals.getDataOptions("NotificationDeliveryTypeName", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
			ddlNotificationDeliveryTypeCode.DataBind();
			ddlNotificationDeliveryTypeCode.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				BLL.Notifications.NotificationDeliveryType sNotificationDeliveryType = new BLL.Notifications.NotificationDeliveryType();
				sNotificationDeliveryType.NotificationDeliveryTypeCode = MOD.Data.DataHelper.GetInt(vNotificationDeliveryLog.NotificationDeliveryTypeCode, MOD.Data.DefaultValue.Int);
				ddlNotificationDeliveryTypeCode.SelectedValue = MOD.Data.DataHelper.GetString(sNotificationDeliveryType.PrimaryIndex, "");
				sNotificationDeliveryType = null;
			}
			catch {}
			if(ddlNotificationDeliveryTypeCode.SelectedValue == ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				try
				{
					ddlNotificationDeliveryTypeCode.SelectedValue = MOD.Data.DataHelper.GetString(Session["Notifications/NotificationDeliveryTypeWorkingSetItem"], "");
				}
				catch {}
			}
			// Drop downs should be disabled when control is "Internal" and either value is constrained by container
			if (WorkflowMode == WorkflowMode.Internal)
			{
				ddlNotificationLogID.Visible = Request.QueryString["NotificationLogID"] == null;
				lnkNotificationLogIDWorkingSet.Visible = lnkNotificationLogIDWorkingSet.Visible == true && Request.QueryString["NotificationLogID"] == null;
				lblNotificationLogIDWorkingSet.Visible = lblNotificationLogIDWorkingSet.Visible == true && Request.QueryString["NotificationLogID"] == null;
				valNotificationLogID.Enabled = Request.QueryString["NotificationLogID"] == null;
				lblNotificationLogIDDisplay.Visible = Request.QueryString["NotificationLogID"] == null;
				ddlMetaPartnerID.Visible = Request.QueryString["MetaPartnerID"] == null;
				lnkMetaPartnerIDWorkingSet.Visible = lnkMetaPartnerIDWorkingSet.Visible == true && Request.QueryString["MetaPartnerID"] == null;
				lblMetaPartnerIDWorkingSet.Visible = lblMetaPartnerIDWorkingSet.Visible == true && Request.QueryString["MetaPartnerID"] == null;
				valMetaPartnerID.Enabled = Request.QueryString["MetaPartnerID"] == null;
				lblMetaPartnerIDDisplay.Visible = Request.QueryString["MetaPartnerID"] == null;
				ddlNotificationDeliveryTypeCode.Visible = Request.QueryString["NotificationDeliveryTypeCode"] == null;
				valNotificationDeliveryTypeCode.Enabled = Request.QueryString["NotificationDeliveryTypeCode"] == null;
				lblNotificationDeliveryTypeCodeDisplay.Visible = Request.QueryString["NotificationDeliveryTypeCode"] == null;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set Notification Delivery Log information from the form.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyFormToEntity()
		{
			BLL.Notifications.NotificationDeliveryLog vNotificationDeliveryLog = NotificationDeliveryLogItem;
			if (vNotificationDeliveryLog == null)
			{
				throw CoreUtility.CustomAppException.WrapException(new Exception("Notification Delivery Log not found"), "EditNotificationDeliveryLog.CopyFormToEntity()");
			}
			if (ddlNotificationLogID.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Notifications.NotificationLog sNotificationLog = new BLL.Notifications.NotificationLog(ddlNotificationLogID.SelectedValue, false);
				vNotificationDeliveryLog.NotificationLogID = MOD.Data.DataHelper.GetGuid(sNotificationLog.NotificationLogID, MOD.Data.DefaultValue.Guid);
				sNotificationLog = null;
			}
			if (ddlMetaPartnerID.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Customers.MetaPartner sMetaPartner = new BLL.Customers.MetaPartner(ddlMetaPartnerID.SelectedValue, false);
				vNotificationDeliveryLog.MetaPartnerID = MOD.Data.DataHelper.GetGuid(sMetaPartner.MetaPartnerID, MOD.Data.DefaultValue.Guid);
				sMetaPartner = null;
				vNotificationDeliveryLog.PrimaryName += MOD.Data.DataHelper.GetString(ddlMetaPartnerID.SelectedItem.Text, MOD.Data.DefaultValue.String) + ";";
			}
			if (ddlNotificationDeliveryTypeCode.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Notifications.NotificationDeliveryType sNotificationDeliveryType = new BLL.Notifications.NotificationDeliveryType(ddlNotificationDeliveryTypeCode.SelectedValue, false);
				vNotificationDeliveryLog.NotificationDeliveryTypeCode = MOD.Data.DataHelper.GetInt(sNotificationDeliveryType.NotificationDeliveryTypeCode, MOD.Data.DefaultValue.Int);
				sNotificationDeliveryType = null;
				vNotificationDeliveryLog.PrimaryName += MOD.Data.DataHelper.GetString(ddlNotificationDeliveryTypeCode.SelectedItem.Text, MOD.Data.DefaultValue.String) + ";";
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// Load entity from database, store in _entity and Session["NotificationDeliveryLogItem"]
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void LoadEntity()
		{
			_entity = null;
			Guid notificationLogID = MOD.Data.DataHelper.GetGuid(Request.QueryString["NotificationLogID"], MOD.Data.DefaultValue.Guid);
			Guid metaPartnerID = MOD.Data.DataHelper.GetGuid(Request.QueryString["MetaPartnerID"], MOD.Data.DefaultValue.Guid);
			int notificationDeliveryTypeCode = MOD.Data.DataHelper.GetInt(Request.QueryString["NotificationDeliveryTypeCode"], MOD.Data.DefaultValue.Int);
			if (notificationLogID != MOD.Data.DefaultValue.Guid && metaPartnerID != MOD.Data.DefaultValue.Guid && notificationDeliveryTypeCode != MOD.Data.DefaultValue.Int)
			{
				_entity = BLL.Notifications.NotificationDeliveryLogManager.GetOneNotificationDeliveryLog(notificationLogID, metaPartnerID, notificationDeliveryTypeCode, Globals.getDataOptions("", "", true, true));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update Notification Delivery Log information in the database.</summary>
		///
		// ------------------------------------------------------------------------------
		private void UpsertToDatabase(bool performCascade)
		{
			BLL.Notifications.NotificationDeliveryLog vNotificationDeliveryLog = NotificationDeliveryLogItem;
			if (AccessMode == MOD.Data.AccessMode.Add)
			{
				BLL.Notifications.NotificationDeliveryLogManager.AddOneNotificationDeliveryLog(vNotificationDeliveryLog, performCascade);
			}
			else if (AccessMode == MOD.Data.AccessMode.Edit)
			{
				BLL.Notifications.NotificationDeliveryLogManager.UpdateOneNotificationDeliveryLog(vNotificationDeliveryLog, performCascade);
			}
			NotificationDeliveryLogItem.NotificationLogID = vNotificationDeliveryLog.NotificationLogID;
			NotificationDeliveryLogItem.MetaPartnerID = vNotificationDeliveryLog.MetaPartnerID;
			NotificationDeliveryLogItem.NotificationDeliveryTypeCode = vNotificationDeliveryLog.NotificationDeliveryTypeCode;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set access and display modes for presenting Notification Delivery Log information.</summary>
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
					lblTitle.Text = "Add Notification&nbsp;Delivery&nbsp;Log";
					btnSave.Text = "Add";
					break;
				case MOD.Data.AccessMode.Edit:
					lblTitle.Text = "Edit Notification&nbsp;Delivery&nbsp;Log";
					btnSave.Text = "Save";
					break;
				case MOD.Data.AccessMode.View:
					lblTitle.Text = "View Notification&nbsp;Delivery&nbsp;Log";
					break;
				default:
					lblTitle.Text = "View Notification&nbsp;Delivery&nbsp;Log";
					break;
			}
			btnDelete.Visible = IsDeleteAvailable;
			btnNew.Visible = IsEditAvailable;
			btnSave.Visible = IsEditAvailable || IsAddAvailable;
			ddlNotificationLogID.Enabled = IsAddAvailable;
			ddlMetaPartnerID.Enabled = IsAddAvailable;
			ddlNotificationDeliveryTypeCode.Enabled = IsAddAvailable;
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
		/// <summary>Initialize component for NotificationDeliveryLog, add delegates here.</summary>
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