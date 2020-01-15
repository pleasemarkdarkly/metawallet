
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
using MW.MComm.WalletSolution.BLL.Users;
using CoreUtility = MW.MComm.WalletSolution.Utility;
using MW.MComm.Admin.WebUI.Components.Desktop;
namespace MW.MComm.Admin.WebUI.UserControls.Desktop.Users
{
	// ------------------------------------------------------------------------------
	/// <summary>Edit User Role Activity is used to help manage UserRoleActivity information.</summary>
	///
	/// File History:
	/// <created>6/1/2007 (Chris Grundy)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class EditUserRoleActivity  : Components.Desktop.BaseFormlUserControl
	{
		#region Events
		/// <summary>
		/// Raised when "Add" button is clicked in internal mode.
		/// Container handles this event and adds entity to collection.
		/// </summary>
		public event EntityEditEventHandler UserRoleActivityAdded;
		/// <summary>
		/// Raised when "Remove" button is clicked in internal mode.
		/// Container handles this event and removes entity from collection.
		/// </summary>
		public event EntityEditEventHandler UserRoleActivityRemoved;
		#endregion Events
		#region Declarations
		#endregion Declarations
		#region Properties
		/// <summary>
		/// The UserRoleActivity currently being edited by this control.
		/// Get accessor casts base._entity to UserRoleActivity
		/// Set accessor used by parent control to set the item currently being edited
		/// </summary>
		public BLL.Users.UserRoleActivity UserRoleActivityItem
		{
			get
			{
				return (BLL.Users.UserRoleActivity) _entity;
			}
			set
			{
				_entity = value; // only set by container
				Session["UserRoleActivityItem"] = _entity;
			}
		}
		#endregion Properties
		#region Event Handlers
		// ------------------------------------------------------------------------------
		/// <summary>Load page for editing User Role Activity, getting mode and parameters.</summary>
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
						_entity = (BLL.Users.UserRoleActivity)Session["UserRoleActivityItem"];
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
					Session["UserRoleActivityItem"] = _entity;
				}
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditUserRoleActivity.Page_Load"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Delete User Role Activity.</summary>
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
					BLL.Users.UserRoleActivityManager.DeleteOneUserRoleActivity(UserRoleActivityItem, performCascade);
					Globals.AddStatusMessage("User Role Activity deleted.");
				}
				else
				{
					// raise event so item is removed from collection
					if (UserRoleActivityRemoved != null)
					{
						UserRoleActivityRemoved(this, new EntityEditEventArgs(_entity));
					}
				}
				// create new object and store it in _entity
				CreateNewEntity();
				Session["UserRoleActivityItem"] = _entity;
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditUserRoleActivity.btnDelete_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("UserRoleCode", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Int, ""));
				queryString.Add("ActivityCode", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Int, ""));
				queryString.Add("AccessModeCode", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Int, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Request to create a new User Role Activity.</summary>
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
				Session["UserRoleActivityItem"] = _entity;
				this.sectionLinks.OnSection("Basics");
				SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
				Globals.AddStatusMessage("Add new User Role Activity.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				doRedirect = false;
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				doRedirect = false;
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditUserRoleActivity.btnNew_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("UserRoleCode", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Int, ""));
				queryString.Add("ActivityCode", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Int, ""));
				queryString.Add("AccessModeCode", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Int, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Reset form for User Role Activity.</summary>
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
					Session["UserRoleActivityItem"] = _entity;
					sectionLinks.CurrentSection = "Basics";
				}
				else
				{
					CreateNewEntity();
				}
				Globals.AddStatusMessage("User Role Activity reset.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditUserRoleActivity.btnReset_Click"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Save User Role Activity.</summary>
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
							if (UserRoleActivityAdded != null && (UserRoleActivityItem.UserRoleCode != MOD.Data.DefaultValue.Int || UserRoleActivityItem.ActivityCode != MOD.Data.DefaultValue.Int || UserRoleActivityItem.AccessModeCode != MOD.Data.DefaultValue.Int || UserRoleActivityItem.CreatedByUserID != MOD.Data.DefaultValue.Guid || UserRoleActivityItem.CreatedDate != MOD.Data.DefaultValue.DateTime || UserRoleActivityItem.LastModifiedByUserID != MOD.Data.DefaultValue.Guid || UserRoleActivityItem.LastModifiedDate != MOD.Data.DefaultValue.DateTime || UserRoleActivityItem.Timestamp != null))
							{
								UserRoleActivityAdded(this, new EntityEditEventArgs(_entity));
								// create new object and store it in _entity
								CreateNewEntity();
								Session["UserRoleActivityItem"] = _entity;
								this.sectionLinks.OnSection("Basics");
								SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
							}
						}
						else
						{
							Globals.AddStatusMessage("User Role Activity updated.");
						}
					}
					else
					{
						UpsertToDatabase(true);
						if (AccessMode == MOD.Data.AccessMode.Add)
						{
							doRedirect = true;
							Globals.AddStatusMessage("User Role Activity added.");
						}
						else
						{
							Globals.AddStatusMessage("User Role Activity updated.");
						}
						SetAccessModeAndDisplay(MOD.Data.AccessMode.Edit);
					}
				}
				else
				{
					Globals.AddErrorMessage(Page, "User Role Activity validation failed.");
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditUserRoleActivity.btnSave_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && isValid == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("UserRoleCode", UserRoleActivityItem.UserRoleCode.ToString());
				queryString.Add("ActivityCode", UserRoleActivityItem.ActivityCode.ToString());
				queryString.Add("AccessModeCode", UserRoleActivityItem.AccessModeCode.ToString());
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditUserRoleActivity.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditUserRoleActivity.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditUserRoleActivity.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditUserRoleActivity.Page_PreRender"));
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
		/// Create a new User Role Activity object reference
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void CreateNewEntity()
		{
			BLL.Users.UserRoleActivity vUserRoleActivity = new BLL.Users.UserRoleActivity();
			vUserRoleActivity.UserRoleCode = MOD.Data.DataHelper.GetInt(Request.QueryString["UserRoleCode"], MOD.Data.DefaultValue.Int);
			vUserRoleActivity.ActivityCode = MOD.Data.DataHelper.GetInt(Request.QueryString["ActivityCode"], MOD.Data.DefaultValue.Int);
			vUserRoleActivity.AccessModeCode = MOD.Data.DataHelper.GetInt(Request.QueryString["AccessModeCode"], MOD.Data.DefaultValue.Int);
			_entity = vUserRoleActivity;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update form from User Role Activity information.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyEntityToForm()
		{
			BLL.Users.UserRoleActivity vUserRoleActivity = UserRoleActivityItem;
			ddlUserRoleCode.DataValueField = "PrimaryIndex";
			ddlUserRoleCode.DataTextField = "PrimaryName";
			ddlUserRoleCode.DataSource = BLL.Users.UserRoleManager.GetAllUserRoleData(Globals.DBOptions, Globals.getDataOptions("UserRoleName", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
			ddlUserRoleCode.DataBind();
			ddlUserRoleCode.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				BLL.Users.UserRole sUserRole = new BLL.Users.UserRole();
				sUserRole.UserRoleCode = MOD.Data.DataHelper.GetInt(vUserRoleActivity.UserRoleCode, MOD.Data.DefaultValue.Int);
				ddlUserRoleCode.SelectedValue = MOD.Data.DataHelper.GetString(sUserRole.PrimaryIndex, "");
				sUserRole = null;
			}
			catch {}
			if(ddlUserRoleCode.SelectedValue == ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				try
				{
					ddlUserRoleCode.SelectedValue = MOD.Data.DataHelper.GetString(Session["Users/UserRoleWorkingSetItem"], "");
				}
				catch {}
			}
			ddlActivityCode.DataValueField = "PrimaryIndex";
			ddlActivityCode.DataTextField = "PrimaryName";
			ddlActivityCode.DataSource = BLL.Users.ActivityManager.GetAllActivityData(Globals.DBOptions, Globals.getDataOptions("ActivityName", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
			ddlActivityCode.DataBind();
			ddlActivityCode.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				BLL.Users.Activity sActivity = new BLL.Users.Activity();
				sActivity.ActivityCode = MOD.Data.DataHelper.GetInt(vUserRoleActivity.ActivityCode, MOD.Data.DefaultValue.Int);
				ddlActivityCode.SelectedValue = MOD.Data.DataHelper.GetString(sActivity.PrimaryIndex, "");
				sActivity = null;
			}
			catch {}
			if(ddlActivityCode.SelectedValue == ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				try
				{
					ddlActivityCode.SelectedValue = MOD.Data.DataHelper.GetString(Session["Users/ActivityWorkingSetItem"], "");
				}
				catch {}
			}
			ddlAccessModeCode.DataValueField = "PrimaryIndex";
			ddlAccessModeCode.DataTextField = "PrimaryName";
			ddlAccessModeCode.DataSource = BLL.Users.AccessModeManager.GetAllAccessModeData(Globals.DBOptions, Globals.getDataOptions("AccessModeName", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
			ddlAccessModeCode.DataBind();
			ddlAccessModeCode.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				BLL.Users.AccessMode sAccessMode = new BLL.Users.AccessMode();
				sAccessMode.AccessModeCode = MOD.Data.DataHelper.GetInt(vUserRoleActivity.AccessModeCode, MOD.Data.DefaultValue.Int);
				ddlAccessModeCode.SelectedValue = MOD.Data.DataHelper.GetString(sAccessMode.PrimaryIndex, "");
				sAccessMode = null;
			}
			catch {}
			if(ddlAccessModeCode.SelectedValue == ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				try
				{
					ddlAccessModeCode.SelectedValue = MOD.Data.DataHelper.GetString(Session["Users/AccessModeWorkingSetItem"], "");
				}
				catch {}
			}
			// Drop downs should be disabled when control is "Internal" and either value is constrained by container
			if (WorkflowMode == WorkflowMode.Internal)
			{
				ddlUserRoleCode.Visible = Request.QueryString["UserRoleCode"] == null;
				valUserRoleCode.Enabled = Request.QueryString["UserRoleCode"] == null;
				lblUserRoleCodeDisplay.Visible = Request.QueryString["UserRoleCode"] == null;
				ddlActivityCode.Visible = Request.QueryString["ActivityCode"] == null;
				valActivityCode.Enabled = Request.QueryString["ActivityCode"] == null;
				lblActivityCodeDisplay.Visible = Request.QueryString["ActivityCode"] == null;
				ddlAccessModeCode.Visible = Request.QueryString["AccessModeCode"] == null;
				valAccessModeCode.Enabled = Request.QueryString["AccessModeCode"] == null;
				lblAccessModeCodeDisplay.Visible = Request.QueryString["AccessModeCode"] == null;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set User Role Activity information from the form.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyFormToEntity()
		{
			BLL.Users.UserRoleActivity vUserRoleActivity = UserRoleActivityItem;
			if (vUserRoleActivity == null)
			{
				throw CoreUtility.CustomAppException.WrapException(new Exception("User Role Activity not found"), "EditUserRoleActivity.CopyFormToEntity()");
			}
			if (ddlUserRoleCode.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Users.UserRole sUserRole = new BLL.Users.UserRole(ddlUserRoleCode.SelectedValue, false);
				vUserRoleActivity.UserRoleCode = MOD.Data.DataHelper.GetInt(sUserRole.UserRoleCode, MOD.Data.DefaultValue.Int);
				sUserRole = null;
				vUserRoleActivity.PrimaryName += MOD.Data.DataHelper.GetString(ddlUserRoleCode.SelectedItem.Text, MOD.Data.DefaultValue.String) + ";";
			}
			if (ddlActivityCode.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Users.Activity sActivity = new BLL.Users.Activity(ddlActivityCode.SelectedValue, false);
				vUserRoleActivity.ActivityCode = MOD.Data.DataHelper.GetInt(sActivity.ActivityCode, MOD.Data.DefaultValue.Int);
				sActivity = null;
				vUserRoleActivity.PrimaryName += MOD.Data.DataHelper.GetString(ddlActivityCode.SelectedItem.Text, MOD.Data.DefaultValue.String) + ";";
			}
			if (ddlAccessModeCode.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Users.AccessMode sAccessMode = new BLL.Users.AccessMode(ddlAccessModeCode.SelectedValue, false);
				vUserRoleActivity.AccessModeCode = MOD.Data.DataHelper.GetInt(sAccessMode.AccessModeCode, MOD.Data.DefaultValue.Int);
				sAccessMode = null;
				vUserRoleActivity.PrimaryName += MOD.Data.DataHelper.GetString(ddlAccessModeCode.SelectedItem.Text, MOD.Data.DefaultValue.String) + ";";
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// Load entity from database, store in _entity and Session["UserRoleActivityItem"]
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void LoadEntity()
		{
			_entity = null;
			int userRoleCode = MOD.Data.DataHelper.GetInt(Request.QueryString["UserRoleCode"], MOD.Data.DefaultValue.Int);
			int activityCode = MOD.Data.DataHelper.GetInt(Request.QueryString["ActivityCode"], MOD.Data.DefaultValue.Int);
			int accessModeCode = MOD.Data.DataHelper.GetInt(Request.QueryString["AccessModeCode"], MOD.Data.DefaultValue.Int);
			if (userRoleCode != MOD.Data.DefaultValue.Int && activityCode != MOD.Data.DefaultValue.Int && accessModeCode != MOD.Data.DefaultValue.Int)
			{
				_entity = BLL.Users.UserRoleActivityManager.GetOneUserRoleActivity(userRoleCode, activityCode, accessModeCode, Globals.getDataOptions("", "", true, true));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update User Role Activity information in the database.</summary>
		///
		// ------------------------------------------------------------------------------
		private void UpsertToDatabase(bool performCascade)
		{
			BLL.Users.UserRoleActivity vUserRoleActivity = UserRoleActivityItem;
			if (AccessMode == MOD.Data.AccessMode.Add)
			{
				BLL.Users.UserRoleActivityManager.AddOneUserRoleActivity(vUserRoleActivity, performCascade);
			}
			else if (AccessMode == MOD.Data.AccessMode.Edit)
			{
				BLL.Users.UserRoleActivityManager.UpdateOneUserRoleActivity(vUserRoleActivity, performCascade);
			}
			UserRoleActivityItem.UserRoleCode = vUserRoleActivity.UserRoleCode;
			UserRoleActivityItem.ActivityCode = vUserRoleActivity.ActivityCode;
			UserRoleActivityItem.AccessModeCode = vUserRoleActivity.AccessModeCode;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set access and display modes for presenting User Role Activity information.</summary>
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
					lblTitle.Text = "Add User&nbsp;Role&nbsp;Activity";
					btnSave.Text = "Add";
					break;
				case MOD.Data.AccessMode.Edit:
					lblTitle.Text = "Edit User&nbsp;Role&nbsp;Activity";
					btnSave.Text = "Save";
					break;
				case MOD.Data.AccessMode.View:
					lblTitle.Text = "View User&nbsp;Role&nbsp;Activity";
					break;
				default:
					lblTitle.Text = "View User&nbsp;Role&nbsp;Activity";
					break;
			}
			btnDelete.Visible = IsDeleteAvailable;
			btnNew.Visible = IsEditAvailable;
			btnSave.Visible = IsEditAvailable || IsAddAvailable;
			ddlUserRoleCode.Enabled = IsAddAvailable;
			ddlActivityCode.Enabled = IsAddAvailable;
			ddlAccessModeCode.Enabled = IsAddAvailable;
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
		/// <summary>Initialize component for UserRoleActivity, add delegates here.</summary>
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