
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
using MW.MComm.WalletSolution.BLL.UserExperience;
using CoreUtility = MW.MComm.WalletSolution.Utility;
using MW.MComm.Admin.WebUI.Components.Desktop;
namespace MW.MComm.Admin.WebUI.UserControls.Desktop.UserExperience
{
	// ------------------------------------------------------------------------------
	/// <summary>Edit Admin Help is used to help manage AdminHelp information.</summary>
	///
	/// File History:
	/// <created>6/1/2007 (Chris Grundy)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class EditAdminHelp  : Components.Desktop.BaseFormlUserControl
	{
		#region Events
		/// <summary>
		/// Raised when "Add" button is clicked in internal mode.
		/// Container handles this event and adds entity to collection.
		/// </summary>
		public event EntityEditEventHandler AdminHelpAdded;
		/// <summary>
		/// Raised when "Remove" button is clicked in internal mode.
		/// Container handles this event and removes entity from collection.
		/// </summary>
		public event EntityEditEventHandler AdminHelpRemoved;
		#endregion Events
		#region Declarations
		#endregion Declarations
		#region Properties
		/// <summary>
		/// The AdminHelp currently being edited by this control.
		/// Get accessor casts base._entity to AdminHelp
		/// Set accessor used by parent control to set the item currently being edited
		/// </summary>
		public BLL.UserExperience.AdminHelp AdminHelpItem
		{
			get
			{
				return (BLL.UserExperience.AdminHelp) _entity;
			}
			set
			{
				_entity = value; // only set by container
				Session["AdminHelpItem"] = _entity;
			}
		}
		#endregion Properties
		#region Event Handlers
		// ------------------------------------------------------------------------------
		/// <summary>Load page for editing Admin Help, getting mode and parameters.</summary>
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
						_entity = (BLL.UserExperience.AdminHelp)Session["AdminHelpItem"];
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
					Session["AdminHelpItem"] = _entity;
				}
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditAdminHelp.Page_Load"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Delete Admin Help.</summary>
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
					BLL.UserExperience.AdminHelpManager.DeleteOneAdminHelp(AdminHelpItem, performCascade);
					Globals.AddStatusMessage("Admin Help deleted.");
				}
				else
				{
					// raise event so item is removed from collection
					if (AdminHelpRemoved != null)
					{
						AdminHelpRemoved(this, new EntityEditEventArgs(_entity));
					}
				}
				// create new object and store it in _entity
				CreateNewEntity();
				Session["AdminHelpItem"] = _entity;
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditAdminHelp.btnDelete_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("ActivityCode", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Int, ""));
				queryString.Add("LocaleCode", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Int, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Request to create a new Admin Help.</summary>
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
				Session["AdminHelpItem"] = _entity;
				this.sectionLinks.OnSection("Basics");
				SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
				Globals.AddStatusMessage("Add new Admin Help.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				doRedirect = false;
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				doRedirect = false;
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditAdminHelp.btnNew_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("ActivityCode", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Int, ""));
				queryString.Add("LocaleCode", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Int, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Reset form for Admin Help.</summary>
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
					Session["AdminHelpItem"] = _entity;
					sectionLinks.CurrentSection = "Basics";
				}
				else
				{
					CreateNewEntity();
				}
				Globals.AddStatusMessage("Admin Help reset.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditAdminHelp.btnReset_Click"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Save Admin Help.</summary>
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
							if (AdminHelpAdded != null && (AdminHelpItem.ActivityCode != MOD.Data.DefaultValue.Int || AdminHelpItem.LocaleCode != MOD.Data.DefaultValue.Int || AdminHelpItem.AdminHelpTitle != MOD.Data.DefaultValue.String || AdminHelpItem.AdminHelpText != MOD.Data.DefaultValue.String || AdminHelpItem.CreatedByUserID != MOD.Data.DefaultValue.Guid || AdminHelpItem.CreatedDate != MOD.Data.DefaultValue.DateTime || AdminHelpItem.LastModifiedByUserID != MOD.Data.DefaultValue.Guid || AdminHelpItem.LastModifiedDate != MOD.Data.DefaultValue.DateTime || AdminHelpItem.Timestamp != null))
							{
								AdminHelpAdded(this, new EntityEditEventArgs(_entity));
								// create new object and store it in _entity
								CreateNewEntity();
								Session["AdminHelpItem"] = _entity;
								this.sectionLinks.OnSection("Basics");
								SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
							}
						}
						else
						{
							Globals.AddStatusMessage("Admin Help updated.");
						}
					}
					else
					{
						UpsertToDatabase(true);
						if (AccessMode == MOD.Data.AccessMode.Add)
						{
							doRedirect = true;
							Globals.AddStatusMessage("Admin Help added.");
						}
						else
						{
							Globals.AddStatusMessage("Admin Help updated.");
						}
						SetAccessModeAndDisplay(MOD.Data.AccessMode.Edit);
					}
				}
				else
				{
					Globals.AddErrorMessage(Page, "Admin Help validation failed.");
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditAdminHelp.btnSave_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && isValid == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("ActivityCode", AdminHelpItem.ActivityCode.ToString());
				queryString.Add("LocaleCode", AdminHelpItem.LocaleCode.ToString());
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditAdminHelp.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditAdminHelp.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditAdminHelp.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditAdminHelp.Page_PreRender"));
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
		/// Create a new Admin Help object reference
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void CreateNewEntity()
		{
			BLL.UserExperience.AdminHelp vAdminHelp = new BLL.UserExperience.AdminHelp();
			vAdminHelp.ActivityCode = MOD.Data.DataHelper.GetInt(Request.QueryString["ActivityCode"], MOD.Data.DefaultValue.Int);
			vAdminHelp.LocaleCode = MOD.Data.DataHelper.GetInt(Request.QueryString["LocaleCode"], MOD.Data.DefaultValue.Int);
			_entity = vAdminHelp;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update form from Admin Help information.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyEntityToForm()
		{
			BLL.UserExperience.AdminHelp vAdminHelp = AdminHelpItem;
			ddlActivityCode.DataValueField = "PrimaryIndex";
			ddlActivityCode.DataTextField = "PrimaryName";
			ddlActivityCode.DataSource = BLL.Users.ActivityManager.GetAllActivityData(Globals.DBOptions, Globals.getDataOptions("ActivityName", "", true, true), Globals.DebugLevel, Globals.CurrentUserID);
			ddlActivityCode.DataBind();
			ddlActivityCode.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				BLL.Users.Activity sActivity = new BLL.Users.Activity();
				sActivity.ActivityCode = MOD.Data.DataHelper.GetInt(vAdminHelp.ActivityCode, MOD.Data.DefaultValue.Int);
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
			ddlLocaleCode.DataValueField = "PrimaryIndex";
			ddlLocaleCode.DataTextField = "PrimaryName";
			ddlLocaleCode.DataSource = BLL.Environments.LocaleManager.GetAllLocaleData(Globals.DBOptions, Globals.getDataOptions("LocaleName", "", true, true), Globals.DebugLevel, Globals.CurrentUserID);
			ddlLocaleCode.DataBind();
			ddlLocaleCode.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				BLL.Environments.Locale sLocale = new BLL.Environments.Locale();
				sLocale.LocaleCode = MOD.Data.DataHelper.GetInt(vAdminHelp.LocaleCode, MOD.Data.DefaultValue.Int);
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
			txtAdminHelpTitle.Text = MOD.Data.EditHelper.GetString(vAdminHelp.AdminHelpTitle);
			txtAdminHelpText.Text = Server.HtmlDecode(MOD.Data.EditHelper.GetString(vAdminHelp.AdminHelpText));
			// Drop downs should be disabled when control is "Internal" and either value is constrained by container
			if (WorkflowMode == WorkflowMode.Internal)
			{
				ddlActivityCode.Visible = Request.QueryString["ActivityCode"] == null;
				valActivityCode.Enabled = Request.QueryString["ActivityCode"] == null;
				lblActivityCodeDisplay.Visible = Request.QueryString["ActivityCode"] == null;
				ddlLocaleCode.Visible = Request.QueryString["LocaleCode"] == null;
				valLocaleCode.Enabled = Request.QueryString["LocaleCode"] == null;
				lblLocaleCodeDisplay.Visible = Request.QueryString["LocaleCode"] == null;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set Admin Help information from the form.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyFormToEntity()
		{
			BLL.UserExperience.AdminHelp vAdminHelp = AdminHelpItem;
			if (vAdminHelp == null)
			{
				throw CoreUtility.CustomAppException.WrapException(new Exception("Admin Help not found"), "EditAdminHelp.CopyFormToEntity()");
			}
			if (ddlActivityCode.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Users.Activity sActivity = new BLL.Users.Activity(ddlActivityCode.SelectedValue, false);
				vAdminHelp.ActivityCode = MOD.Data.DataHelper.GetInt(sActivity.ActivityCode, MOD.Data.DefaultValue.Int);
				sActivity = null;
				vAdminHelp.PrimaryName += MOD.Data.DataHelper.GetString(ddlActivityCode.SelectedItem.Text, MOD.Data.DefaultValue.String) + ";";
			}
			if (ddlLocaleCode.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Environments.Locale sLocale = new BLL.Environments.Locale(ddlLocaleCode.SelectedValue, false);
				vAdminHelp.LocaleCode = MOD.Data.DataHelper.GetInt(sLocale.LocaleCode, MOD.Data.DefaultValue.Int);
				sLocale = null;
				vAdminHelp.PrimaryName += MOD.Data.DataHelper.GetString(ddlLocaleCode.SelectedItem.Text, MOD.Data.DefaultValue.String) + ";";
			}
			vAdminHelp.AdminHelpTitle = EditHelper.EncodeStringForDB(MOD.Data.DataHelper.GetString(txtAdminHelpTitle.Text, null));
			vAdminHelp.AdminHelpText = EditHelper.EncodeStringForDB(MOD.Data.DataHelper.GetString(txtAdminHelpText.Text, null));
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// Load entity from database, store in _entity and Session["AdminHelpItem"]
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void LoadEntity()
		{
			_entity = null;
			int activityCode = MOD.Data.DataHelper.GetInt(Request.QueryString["ActivityCode"], MOD.Data.DefaultValue.Int);
			int localeCode = MOD.Data.DataHelper.GetInt(Request.QueryString["LocaleCode"], MOD.Data.DefaultValue.Int);
			if (activityCode != MOD.Data.DefaultValue.Int && localeCode != MOD.Data.DefaultValue.Int)
			{
				_entity = BLL.UserExperience.AdminHelpManager.GetOneAdminHelp(activityCode, localeCode, Globals.getDataOptions("", "", true, true));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update Admin Help information in the database.</summary>
		///
		// ------------------------------------------------------------------------------
		private void UpsertToDatabase(bool performCascade)
		{
			BLL.UserExperience.AdminHelp vAdminHelp = AdminHelpItem;
			if (AccessMode == MOD.Data.AccessMode.Add)
			{
				BLL.UserExperience.AdminHelpManager.AddOneAdminHelp(vAdminHelp, performCascade);
			}
			else if (AccessMode == MOD.Data.AccessMode.Edit)
			{
				BLL.UserExperience.AdminHelpManager.UpdateOneAdminHelp(vAdminHelp, performCascade);
			}
			AdminHelpItem.ActivityCode = vAdminHelp.ActivityCode;
			AdminHelpItem.LocaleCode = vAdminHelp.LocaleCode;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set access and display modes for presenting Admin Help information.</summary>
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
					lblTitle.Text = "Add Admin&nbsp;Help";
					btnSave.Text = "Add";
					break;
				case MOD.Data.AccessMode.Edit:
					lblTitle.Text = "Edit Admin&nbsp;Help";
					btnSave.Text = "Save";
					break;
				case MOD.Data.AccessMode.View:
					lblTitle.Text = "View Admin&nbsp;Help";
					break;
				default:
					lblTitle.Text = "View Admin&nbsp;Help";
					break;
			}
			btnDelete.Visible = IsDeleteAvailable;
			btnNew.Visible = IsEditAvailable;
			btnSave.Visible = IsEditAvailable || IsAddAvailable;
			ddlActivityCode.Enabled = IsAddAvailable;
			ddlLocaleCode.Enabled = IsAddAvailable;
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
		/// <summary>Initialize component for AdminHelp, add delegates here.</summary>
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