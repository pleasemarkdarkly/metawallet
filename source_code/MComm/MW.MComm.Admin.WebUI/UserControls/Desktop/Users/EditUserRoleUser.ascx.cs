
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
	/// <summary>Edit User Role User is used to help manage UserRoleUser information.</summary>
	///
	/// File History:
	/// <created>6/1/2007 (Chris Grundy)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class EditUserRoleUser  : Components.Desktop.BaseFormlUserControl
	{
		#region Events
		/// <summary>
		/// Raised when "Add" button is clicked in internal mode.
		/// Container handles this event and adds entity to collection.
		/// </summary>
		public event EntityEditEventHandler UserRoleUserAdded;
		/// <summary>
		/// Raised when "Remove" button is clicked in internal mode.
		/// Container handles this event and removes entity from collection.
		/// </summary>
		public event EntityEditEventHandler UserRoleUserRemoved;
		#endregion Events
		#region Declarations
		#endregion Declarations
		#region Properties
		/// <summary>
		/// The UserRoleUser currently being edited by this control.
		/// Get accessor casts base._entity to UserRoleUser
		/// Set accessor used by parent control to set the item currently being edited
		/// </summary>
		public BLL.Users.UserRoleUser UserRoleUserItem
		{
			get
			{
				return (BLL.Users.UserRoleUser) _entity;
			}
			set
			{
				_entity = value; // only set by container
				Session["UserRoleUserItem"] = _entity;
			}
		}
		#endregion Properties
		#region Event Handlers
		// ------------------------------------------------------------------------------
		/// <summary>Load page for editing User Role User, getting mode and parameters.</summary>
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
						_entity = (BLL.Users.UserRoleUser)Session["UserRoleUserItem"];
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
					Session["UserRoleUserItem"] = _entity;
				}
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditUserRoleUser.Page_Load"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Delete User Role User.</summary>
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
					BLL.Users.UserRoleUserManager.DeleteOneUserRoleUser(UserRoleUserItem, performCascade);
					Globals.AddStatusMessage("User Role User deleted.");
				}
				else
				{
					// raise event so item is removed from collection
					if (UserRoleUserRemoved != null)
					{
						UserRoleUserRemoved(this, new EntityEditEventArgs(_entity));
					}
				}
				// create new object and store it in _entity
				CreateNewEntity();
				Session["UserRoleUserItem"] = _entity;
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditUserRoleUser.btnDelete_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("UserRoleCode", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Int, ""));
				queryString.Add("UserID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Request to create a new User Role User.</summary>
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
				Session["UserRoleUserItem"] = _entity;
				this.sectionLinks.OnSection("Basics");
				SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
				Globals.AddStatusMessage("Add new User Role User.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				doRedirect = false;
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				doRedirect = false;
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditUserRoleUser.btnNew_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("UserRoleCode", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Int, ""));
				queryString.Add("UserID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Reset form for User Role User.</summary>
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
					Session["UserRoleUserItem"] = _entity;
					sectionLinks.CurrentSection = "Basics";
				}
				else
				{
					CreateNewEntity();
				}
				Globals.AddStatusMessage("User Role User reset.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditUserRoleUser.btnReset_Click"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Save User Role User.</summary>
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
							if (UserRoleUserAdded != null && (UserRoleUserItem.UserRoleCode != MOD.Data.DefaultValue.Int || UserRoleUserItem.UserID != MOD.Data.DefaultValue.Guid || UserRoleUserItem.CreatedByUserID != MOD.Data.DefaultValue.Guid || UserRoleUserItem.CreatedDate != MOD.Data.DefaultValue.DateTime || UserRoleUserItem.LastModifiedByUserID != MOD.Data.DefaultValue.Guid || UserRoleUserItem.LastModifiedDate != MOD.Data.DefaultValue.DateTime || UserRoleUserItem.Timestamp != null))
							{
								UserRoleUserAdded(this, new EntityEditEventArgs(_entity));
								// create new object and store it in _entity
								CreateNewEntity();
								Session["UserRoleUserItem"] = _entity;
								this.sectionLinks.OnSection("Basics");
								SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
							}
						}
						else
						{
							Globals.AddStatusMessage("User Role User updated.");
						}
					}
					else
					{
						UpsertToDatabase(true);
						if (AccessMode == MOD.Data.AccessMode.Add)
						{
							doRedirect = true;
							Globals.AddStatusMessage("User Role User added.");
						}
						else
						{
							Globals.AddStatusMessage("User Role User updated.");
						}
						SetAccessModeAndDisplay(MOD.Data.AccessMode.Edit);
					}
				}
				else
				{
					Globals.AddErrorMessage(Page, "User Role User validation failed.");
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditUserRoleUser.btnSave_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && isValid == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("UserRoleCode", UserRoleUserItem.UserRoleCode.ToString());
				queryString.Add("UserID", UserRoleUserItem.UserID.ToString());
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditUserRoleUser.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditUserRoleUser.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditUserRoleUser.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditUserRoleUser.Page_PreRender"));
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
		/// Create a new User Role User object reference
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void CreateNewEntity()
		{
			BLL.Users.UserRoleUser vUserRoleUser = new BLL.Users.UserRoleUser();
			vUserRoleUser.UserRoleCode = MOD.Data.DataHelper.GetInt(Request.QueryString["UserRoleCode"], MOD.Data.DefaultValue.Int);
			vUserRoleUser.UserID = MOD.Data.DataHelper.GetGuid(Request.QueryString["UserID"], MOD.Data.DefaultValue.Guid);
			_entity = vUserRoleUser;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update form from User Role User information.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyEntityToForm()
		{
			BLL.Users.UserRoleUser vUserRoleUser = UserRoleUserItem;
			ddlUserRoleCode.DataValueField = "PrimaryIndex";
			ddlUserRoleCode.DataTextField = "PrimaryName";
			ddlUserRoleCode.DataSource = BLL.Users.UserRoleManager.GetAllUserRoleData(Globals.DBOptions, Globals.getDataOptions("UserRoleName", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
			ddlUserRoleCode.DataBind();
			ddlUserRoleCode.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				BLL.Users.UserRole sUserRole = new BLL.Users.UserRole();
				sUserRole.UserRoleCode = MOD.Data.DataHelper.GetInt(vUserRoleUser.UserRoleCode, MOD.Data.DefaultValue.Int);
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
			ddlUserID.DataValueField = "PrimaryIndex";
			ddlUserID.DataTextField = "PrimaryName";
			if (UseWorkingSets == true && Session["Users/UserWorkingSet"] != null)
			{
				BLL.SortableList<BLL.Users.User> sessionSource = (BLL.SortableList<BLL.Users.User>) Session["Users/UserWorkingSet"];
				BLL.SortableList<BLL.Users.User> currentSource = new BLL.SortableList<BLL.Users.User>(sessionSource, true);
				if (MOD.Data.DataHelper.GetGuid(vUserRoleUser.UserID, MOD.Data.DefaultValue.Guid) != MOD.Data.DefaultValue.Guid)
				{
					BLL.Users.User currentUser = BLL.Users.UserManager.GetOneUser(MOD.Data.DataHelper.GetGuid(vUserRoleUser.UserID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions("", "", true, true));
					if (currentUser != null && currentSource.Contains(currentUser) == false)
					{
						currentSource.Insert(0, currentUser);
					}
				}
				ddlUserID.DataSource = currentSource;
				lnkUserIDWorkingSet.Visible = true;
				lnkUserIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Users/SearchUserData.aspx");
				lblUserIDWorkingSet.Visible = true;
				lblUserIDWorkingSet.Text = " (from User working set)";
			}
			else
			{
				ddlUserID.DataSource = BLL.Users.UserManager.GetAllUserData(Globals.DBOptions, Globals.getDataOptions("", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
				lblUserIDWorkingSet.Visible = false;
				if (UseWorkingSets == true)
				{
					lnkUserIDWorkingSet.Visible = true;
					lnkUserIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Users/SearchUserData.aspx");
				}
				else
				{
					lnkUserIDWorkingSet.Visible = false;
				}
			}
			ddlUserID.DataBind();
			ddlUserID.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				BLL.Users.User sUser = new BLL.Users.User();
				sUser.UserID = MOD.Data.DataHelper.GetGuid(vUserRoleUser.UserID, MOD.Data.DefaultValue.Guid);
				ddlUserID.SelectedValue = MOD.Data.DataHelper.GetString(sUser.PrimaryIndex, "");
				sUser = null;
			}
			catch {}
			if(ddlUserID.SelectedValue == ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				try
				{
					ddlUserID.SelectedValue = MOD.Data.DataHelper.GetString(Session["Users/UserWorkingSetItem"], "");
				}
				catch {}
			}
			// Drop downs should be disabled when control is "Internal" and either value is constrained by container
			if (WorkflowMode == WorkflowMode.Internal)
			{
				ddlUserRoleCode.Visible = Request.QueryString["UserRoleCode"] == null;
				valUserRoleCode.Enabled = Request.QueryString["UserRoleCode"] == null;
				lblUserRoleCodeDisplay.Visible = Request.QueryString["UserRoleCode"] == null;
				ddlUserID.Visible = Request.QueryString["UserID"] == null;
				lnkUserIDWorkingSet.Visible = lnkUserIDWorkingSet.Visible == true && Request.QueryString["UserID"] == null;
				lblUserIDWorkingSet.Visible = lblUserIDWorkingSet.Visible == true && Request.QueryString["UserID"] == null;
				valUserID.Enabled = Request.QueryString["UserID"] == null;
				lblUserIDDisplay.Visible = Request.QueryString["UserID"] == null;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set User Role User information from the form.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyFormToEntity()
		{
			BLL.Users.UserRoleUser vUserRoleUser = UserRoleUserItem;
			if (vUserRoleUser == null)
			{
				throw CoreUtility.CustomAppException.WrapException(new Exception("User Role User not found"), "EditUserRoleUser.CopyFormToEntity()");
			}
			if (ddlUserRoleCode.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Users.UserRole sUserRole = new BLL.Users.UserRole(ddlUserRoleCode.SelectedValue, false);
				vUserRoleUser.UserRoleCode = MOD.Data.DataHelper.GetInt(sUserRole.UserRoleCode, MOD.Data.DefaultValue.Int);
				sUserRole = null;
				vUserRoleUser.PrimaryName += MOD.Data.DataHelper.GetString(ddlUserRoleCode.SelectedItem.Text, MOD.Data.DefaultValue.String) + ";";
			}
			if (ddlUserID.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Users.User sUser = new BLL.Users.User(ddlUserID.SelectedValue, false);
				vUserRoleUser.UserID = MOD.Data.DataHelper.GetGuid(sUser.UserID, MOD.Data.DefaultValue.Guid);
				sUser = null;
				vUserRoleUser.PrimaryName += MOD.Data.DataHelper.GetString(ddlUserID.SelectedItem.Text, MOD.Data.DefaultValue.String) + ";";
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// Load entity from database, store in _entity and Session["UserRoleUserItem"]
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void LoadEntity()
		{
			_entity = null;
			int userRoleCode = MOD.Data.DataHelper.GetInt(Request.QueryString["UserRoleCode"], MOD.Data.DefaultValue.Int);
			Guid userID = MOD.Data.DataHelper.GetGuid(Request.QueryString["UserID"], MOD.Data.DefaultValue.Guid);
			if (userRoleCode != MOD.Data.DefaultValue.Int && userID != MOD.Data.DefaultValue.Guid)
			{
				_entity = BLL.Users.UserRoleUserManager.GetOneUserRoleUser(userRoleCode, userID, Globals.getDataOptions("", "", true, true));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update User Role User information in the database.</summary>
		///
		// ------------------------------------------------------------------------------
		private void UpsertToDatabase(bool performCascade)
		{
			BLL.Users.UserRoleUser vUserRoleUser = UserRoleUserItem;
			if (AccessMode == MOD.Data.AccessMode.Add)
			{
				BLL.Users.UserRoleUserManager.AddOneUserRoleUser(vUserRoleUser, performCascade);
			}
			else if (AccessMode == MOD.Data.AccessMode.Edit)
			{
				BLL.Users.UserRoleUserManager.UpdateOneUserRoleUser(vUserRoleUser, performCascade);
			}
			UserRoleUserItem.UserRoleCode = vUserRoleUser.UserRoleCode;
			UserRoleUserItem.UserID = vUserRoleUser.UserID;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set access and display modes for presenting User Role User information.</summary>
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
					lblTitle.Text = "Add User&nbsp;Role&nbsp;User";
					btnSave.Text = "Add";
					break;
				case MOD.Data.AccessMode.Edit:
					lblTitle.Text = "Edit User&nbsp;Role&nbsp;User";
					btnSave.Text = "Save";
					break;
				case MOD.Data.AccessMode.View:
					lblTitle.Text = "View User&nbsp;Role&nbsp;User";
					break;
				default:
					lblTitle.Text = "View User&nbsp;Role&nbsp;User";
					break;
			}
			btnDelete.Visible = IsDeleteAvailable;
			btnNew.Visible = IsEditAvailable;
			btnSave.Visible = IsEditAvailable || IsAddAvailable;
			ddlUserRoleCode.Enabled = IsAddAvailable;
			ddlUserID.Enabled = IsAddAvailable;
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
		/// <summary>Initialize component for UserRoleUser, add delegates here.</summary>
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