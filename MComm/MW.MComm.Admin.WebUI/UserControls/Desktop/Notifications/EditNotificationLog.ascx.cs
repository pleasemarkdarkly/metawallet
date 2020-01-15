
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
	/// <summary>Edit Notification Log is used to help manage NotificationLog information.</summary>
	///
	/// File History:
	/// <created>6/1/2007 (Chris Grundy)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class EditNotificationLog  : Components.Desktop.BaseFormlUserControl
	{
		#region Events
		/// <summary>
		/// Raised when "Add" button is clicked in internal mode.
		/// Container handles this event and adds entity to collection.
		/// </summary>
		public event EntityEditEventHandler NotificationLogAdded;
		/// <summary>
		/// Raised when "Remove" button is clicked in internal mode.
		/// Container handles this event and removes entity from collection.
		/// </summary>
		public event EntityEditEventHandler NotificationLogRemoved;
		#endregion Events
		#region Declarations
		#endregion Declarations
		#region Properties
		/// <summary>
		/// The NotificationLog currently being edited by this control.
		/// Get accessor casts base._entity to NotificationLog
		/// Set accessor used by parent control to set the item currently being edited
		/// </summary>
		public BLL.Notifications.NotificationLog NotificationLogItem
		{
			get
			{
				return (BLL.Notifications.NotificationLog) _entity;
			}
			set
			{
				_entity = value; // only set by container
				Session["NotificationLogItem"] = _entity;
			}
		}
		#endregion Properties
		#region Event Handlers
		// ------------------------------------------------------------------------------
		/// <summary>Load page for editing Notification Log, getting mode and parameters.</summary>
		///
		// ------------------------------------------------------------------------------
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				// set validator property to child controls
				listNotificationAttributeValueLogData.UseValidation = UseValidation && (DisplayMode != MOD.Data.DisplayMode.SingleView);
				listNotificationDeliveryLogData.UseValidation = UseValidation && (DisplayMode != MOD.Data.DisplayMode.SingleView);
				base.OnLoad();
				if (IsPostBack == true)
				{
					// entity may come from session, or be set by container
					if (_entity == null)
					{
						_entity = (BLL.Notifications.NotificationLog)Session["NotificationLogItem"];
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
					Session["NotificationLogItem"] = _entity;
				}
				// Assign entity collections into child controls
				listNotificationAttributeValueLogData.Collection = NotificationLogItem.NotificationAttributeValueLogList;
				listNotificationDeliveryLogData.Collection = NotificationLogItem.NotificationDeliveryLogList;
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditNotificationLog.Page_Load"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Delete Notification Log.</summary>
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
					if (NotificationLogRemoved != null)
					{
						NotificationLogRemoved(this, new EntityEditEventArgs(_entity));
					}
				}
				// create new object and store it in _entity
				CreateNewEntity();
				Session["NotificationLogItem"] = _entity;
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditNotificationLog.btnDelete_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("NotificationLogID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Request to create a new Notification Log.</summary>
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
				Session["NotificationLogItem"] = _entity;
				this.sectionLinks.OnSection("Basics");
				SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
				Globals.AddStatusMessage("Add new Notification Log.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				doRedirect = false;
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				doRedirect = false;
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditNotificationLog.btnNew_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("NotificationLogID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Reset form for Notification Log.</summary>
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
					Session["NotificationLogItem"] = _entity;
					sectionLinks.CurrentSection = "Basics";
				}
				else
				{
					CreateNewEntity();
				}
				Globals.AddStatusMessage("Notification Log reset.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditNotificationLog.btnReset_Click"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Save Notification Log.</summary>
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
							if (NotificationLogAdded != null && (NotificationLogItem.NotificationLogID != MOD.Data.DefaultValue.Guid || NotificationLogItem.NotificationCode != MOD.Data.DefaultValue.Int || NotificationLogItem.NotificationSubject != MOD.Data.DefaultValue.String || NotificationLogItem.NotificationMessage != MOD.Data.DefaultValue.String || NotificationLogItem.LocaleCode != MOD.Data.DefaultValue.Int || NotificationLogItem.CreatedByUserID != MOD.Data.DefaultValue.Guid || NotificationLogItem.CreatedDate != MOD.Data.DefaultValue.DateTime || NotificationLogItem.LastModifiedByUserID != MOD.Data.DefaultValue.Guid || NotificationLogItem.LastModifiedDate != MOD.Data.DefaultValue.DateTime || NotificationLogItem.Timestamp != null))
							{
								NotificationLogAdded(this, new EntityEditEventArgs(_entity));
								// create new object and store it in _entity
								CreateNewEntity();
								Session["NotificationLogItem"] = _entity;
								this.sectionLinks.OnSection("Basics");
								SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
							}
						}
						else
						{
							Globals.AddStatusMessage("Notification Log updated.");
						}
					}
					else
					{
						UpsertToDatabase(true);
						if (AccessMode == MOD.Data.AccessMode.Add)
						{
							doRedirect = true;
							Globals.AddStatusMessage("Notification Log added.");
						}
						else
						{
							Globals.AddStatusMessage("Notification Log updated.");
						}
						SetAccessModeAndDisplay(MOD.Data.AccessMode.Edit);
					}
				}
				else
				{
					Globals.AddErrorMessage(Page, "Notification Log validation failed.");
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditNotificationLog.btnSave_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && isValid == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("NotificationLogID", NotificationLogItem.NotificationLogID.ToString());
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditNotificationLog.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditNotificationLog.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditNotificationLog.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditNotificationLog.Page_PreRender"));
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
		/// Create a new Notification Log object reference
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void CreateNewEntity()
		{
			BLL.Notifications.NotificationLog vNotificationLog = new BLL.Notifications.NotificationLog();
			vNotificationLog.NotificationLogID = MOD.Data.DataHelper.GetGuid(Request.QueryString["NotificationLogID"], MOD.Data.DefaultValue.Guid);
			vNotificationLog.NotificationCode = MOD.Data.DataHelper.GetInt(Request.QueryString["NotificationCode"], MOD.Data.DefaultValue.Int);
			vNotificationLog.LocaleCode = MOD.Data.DataHelper.GetInt(Request.QueryString["LocaleCode"], MOD.Data.DefaultValue.Int);
			_entity = vNotificationLog;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update form from Notification Log information.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyEntityToForm()
		{
			BLL.Notifications.NotificationLog vNotificationLog = NotificationLogItem;
			lblNotificationLogID.Text = MOD.Data.DataHelper.GetString(vNotificationLog.NotificationLogID, "");
			ddlNotificationCode.DataValueField = "PrimaryIndex";
			ddlNotificationCode.DataTextField = "PrimaryName";
			if (UseWorkingSets == true && Session["Notifications/NotificationWorkingSet"] != null)
			{
				BLL.SortableList<BLL.Notifications.Notification> sessionSource = (BLL.SortableList<BLL.Notifications.Notification>) Session["Notifications/NotificationWorkingSet"];
				BLL.SortableList<BLL.Notifications.Notification> currentSource = new BLL.SortableList<BLL.Notifications.Notification>(sessionSource, true);
				if (MOD.Data.DataHelper.GetInt(vNotificationLog.NotificationCode, MOD.Data.DefaultValue.Int) != MOD.Data.DefaultValue.Int)
				{
					BLL.Notifications.Notification currentNotification = BLL.Notifications.NotificationManager.GetOneNotification(MOD.Data.DataHelper.GetInt(vNotificationLog.NotificationCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions("", "", true, true));
					if (currentNotification != null && currentSource.Contains(currentNotification) == false)
					{
						currentSource.Insert(0, currentNotification);
					}
				}
				ddlNotificationCode.DataSource = currentSource;
				lnkNotificationCodeWorkingSet.Visible = true;
				lnkNotificationCodeWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Notifications/SearchNotificationData.aspx");
				lblNotificationCodeWorkingSet.Visible = true;
				lblNotificationCodeWorkingSet.Text = " (from Notification working set)";
			}
			else
			{
				ddlNotificationCode.DataSource = BLL.Notifications.NotificationManager.GetAllNotificationData(Globals.DBOptions, Globals.getDataOptions("NotificationName", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
				lblNotificationCodeWorkingSet.Visible = false;
				if (UseWorkingSets == true)
				{
					lnkNotificationCodeWorkingSet.Visible = true;
					lnkNotificationCodeWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Notifications/SearchNotificationData.aspx");
				}
				else
				{
					lnkNotificationCodeWorkingSet.Visible = false;
				}
			}
			ddlNotificationCode.DataBind();
			ddlNotificationCode.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				BLL.Notifications.Notification sNotification = new BLL.Notifications.Notification();
				sNotification.NotificationCode = MOD.Data.DataHelper.GetInt(vNotificationLog.NotificationCode, MOD.Data.DefaultValue.Int);
				ddlNotificationCode.SelectedValue = MOD.Data.DataHelper.GetString(sNotification.PrimaryIndex, "");
				sNotification = null;
			}
			catch {}
			if(ddlNotificationCode.SelectedValue == ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				try
				{
					ddlNotificationCode.SelectedValue = MOD.Data.DataHelper.GetString(Session["Notifications/NotificationWorkingSetItem"], "");
				}
				catch {}
			}
			txtNotificationSubject.Text = MOD.Data.EditHelper.GetString(vNotificationLog.NotificationSubject);
			txtNotificationMessage.Text = MOD.Data.EditHelper.GetString(vNotificationLog.NotificationMessage);
			ddlLocaleCode.DataValueField = "PrimaryIndex";
			ddlLocaleCode.DataTextField = "PrimaryName";
			ddlLocaleCode.DataSource = BLL.Environments.LocaleManager.GetAllLocaleData(Globals.DBOptions, Globals.getDataOptions("LocaleName", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
			ddlLocaleCode.DataBind();
			ddlLocaleCode.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				BLL.Environments.Locale sLocale = new BLL.Environments.Locale();
				sLocale.LocaleCode = MOD.Data.DataHelper.GetInt(vNotificationLog.LocaleCode, MOD.Data.DefaultValue.Int);
				ddlLocaleCode.SelectedValue = MOD.Data.DataHelper.GetString(sLocale.PrimaryIndex, "");
				sLocale = null;
			}
			catch {}
			if(ddlLocaleCode.SelectedValue == ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				try
				{
					ddlLocaleCode.SelectedValue = MOD.Data.DataHelper.GetString(Session["Environments/LocaleWorkingSetItem"], "");
				}
				catch {}
			}
			// Drop downs should be disabled when control is "Internal" and either value is constrained by container
			if (WorkflowMode == WorkflowMode.Internal)
			{
				ddlNotificationCode.Visible = Request.QueryString["NotificationCode"] == null;
				lnkNotificationCodeWorkingSet.Visible = lnkNotificationCodeWorkingSet.Visible == true && Request.QueryString["NotificationCode"] == null;
				lblNotificationCodeWorkingSet.Visible = lblNotificationCodeWorkingSet.Visible == true && Request.QueryString["NotificationCode"] == null;
				valNotificationCode.Enabled = Request.QueryString["NotificationCode"] == null;
				lblNotificationCodeDisplay.Visible = Request.QueryString["NotificationCode"] == null;
				ddlLocaleCode.Visible = Request.QueryString["LocaleCode"] == null;
				valLocaleCode.Enabled = Request.QueryString["LocaleCode"] == null;
				lblLocaleCodeDisplay.Visible = Request.QueryString["LocaleCode"] == null;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set Notification Log information from the form.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyFormToEntity()
		{
			BLL.Notifications.NotificationLog vNotificationLog = NotificationLogItem;
			if (vNotificationLog == null)
			{
				throw CoreUtility.CustomAppException.WrapException(new Exception("Notification Log not found"), "EditNotificationLog.CopyFormToEntity()");
			}
			if (ddlNotificationCode.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Notifications.Notification sNotification = new BLL.Notifications.Notification(ddlNotificationCode.SelectedValue, false);
				vNotificationLog.NotificationCode = MOD.Data.DataHelper.GetInt(sNotification.NotificationCode, MOD.Data.DefaultValue.Int);
				sNotification = null;
				vNotificationLog.PrimaryName += MOD.Data.DataHelper.GetString(ddlNotificationCode.SelectedItem.Text, MOD.Data.DefaultValue.String) + ";";
			}
			vNotificationLog.NotificationSubject = EditHelper.EncodeStringForDB(MOD.Data.DataHelper.GetString(txtNotificationSubject.Text, null));
			vNotificationLog.NotificationMessage = EditHelper.EncodeStringForDB(MOD.Data.DataHelper.GetString(txtNotificationMessage.Text, null));
			if (ddlLocaleCode.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Environments.Locale sLocale = new BLL.Environments.Locale(ddlLocaleCode.SelectedValue, false);
				vNotificationLog.LocaleCode = MOD.Data.DataHelper.GetInt(sLocale.LocaleCode, MOD.Data.DefaultValue.Int);
				sLocale = null;
				vNotificationLog.PrimaryName += MOD.Data.DataHelper.GetString(ddlLocaleCode.SelectedItem.Text, MOD.Data.DefaultValue.String) + ";";
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// Load entity from database, store in _entity and Session["NotificationLogItem"]
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void LoadEntity()
		{
			_entity = null;
			Guid notificationLogID = MOD.Data.DataHelper.GetGuid(Request.QueryString["NotificationLogID"], MOD.Data.DefaultValue.Guid);
			if (notificationLogID != MOD.Data.DefaultValue.Guid)
			{
				_entity = BLL.Notifications.NotificationLogManager.GetOneNotificationLog(notificationLogID, Globals.getDataOptions("", "", true, true));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update Notification Log information in the database.</summary>
		///
		// ------------------------------------------------------------------------------
		private void UpsertToDatabase(bool performCascade)
		{
			BLL.Notifications.NotificationLog vNotificationLog = NotificationLogItem;
			if (AccessMode == MOD.Data.AccessMode.Add)
			{
				BLL.Notifications.NotificationLogManager.LogOneNotificationLog(vNotificationLog, performCascade);
			}
			else if (AccessMode == MOD.Data.AccessMode.Edit)
			{
			}
			NotificationLogItem.NotificationLogID = vNotificationLog.NotificationLogID;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set access and display modes for presenting Notification Log information.</summary>
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
					lblTitle.Text = "Add Notification&nbsp;Log";
					btnSave.Text = "Add";
					break;
				case MOD.Data.AccessMode.Edit:
					lblTitle.Text = "Edit Notification&nbsp;Log";
					btnSave.Text = "Save";
					break;
				case MOD.Data.AccessMode.View:
					lblTitle.Text = "View Notification&nbsp;Log";
					break;
				default:
					lblTitle.Text = "View Notification&nbsp;Log";
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
				Section_Notification_Attribute_Value_Logs.Visible = false;
				Section_Notification_Delivery_Logs.Visible = false;
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
					Section_Notification_Attribute_Value_Logs.Visible = true;
					Section_Notification_Delivery_Logs.Visible = true;
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
		/// <summary>Initialize component for NotificationLog, add delegates here.</summary>
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