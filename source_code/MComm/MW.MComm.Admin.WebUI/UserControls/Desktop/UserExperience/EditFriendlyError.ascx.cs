
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
	/// <summary>Edit Friendly Error is used to help manage FriendlyError information.</summary>
	///
	/// File History:
	/// <created>6/1/2007 (Chris Grundy)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class EditFriendlyError  : Components.Desktop.BaseFormlUserControl
	{
		#region Events
		/// <summary>
		/// Raised when "Add" button is clicked in internal mode.
		/// Container handles this event and adds entity to collection.
		/// </summary>
		public event EntityEditEventHandler FriendlyErrorAdded;
		/// <summary>
		/// Raised when "Remove" button is clicked in internal mode.
		/// Container handles this event and removes entity from collection.
		/// </summary>
		public event EntityEditEventHandler FriendlyErrorRemoved;
		#endregion Events
		#region Declarations
		#endregion Declarations
		#region Properties
		/// <summary>
		/// The FriendlyError currently being edited by this control.
		/// Get accessor casts base._entity to FriendlyError
		/// Set accessor used by parent control to set the item currently being edited
		/// </summary>
		public BLL.UserExperience.FriendlyError FriendlyErrorItem
		{
			get
			{
				return (BLL.UserExperience.FriendlyError) _entity;
			}
			set
			{
				_entity = value; // only set by container
				Session["FriendlyErrorItem"] = _entity;
			}
		}
		#endregion Properties
		#region Event Handlers
		// ------------------------------------------------------------------------------
		/// <summary>Load page for editing Friendly Error, getting mode and parameters.</summary>
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
						_entity = (BLL.UserExperience.FriendlyError)Session["FriendlyErrorItem"];
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
					Session["FriendlyErrorItem"] = _entity;
				}
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditFriendlyError.Page_Load"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Delete Friendly Error.</summary>
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
					BLL.UserExperience.FriendlyErrorManager.DeleteOneFriendlyError(FriendlyErrorItem, performCascade);
					Globals.AddStatusMessage("Friendly Error deleted.");
				}
				else
				{
					// raise event so item is removed from collection
					if (FriendlyErrorRemoved != null)
					{
						FriendlyErrorRemoved(this, new EntityEditEventArgs(_entity));
					}
				}
				// create new object and store it in _entity
				CreateNewEntity();
				Session["FriendlyErrorItem"] = _entity;
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditFriendlyError.btnDelete_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("ErrorNumber", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Int, ""));
				queryString.Add("LocaleCode", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Int, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Request to create a new Friendly Error.</summary>
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
				Session["FriendlyErrorItem"] = _entity;
				this.sectionLinks.OnSection("Basics");
				SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
				Globals.AddStatusMessage("Add new Friendly Error.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				doRedirect = false;
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				doRedirect = false;
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditFriendlyError.btnNew_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("ErrorNumber", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Int, ""));
				queryString.Add("LocaleCode", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Int, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Reset form for Friendly Error.</summary>
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
					Session["FriendlyErrorItem"] = _entity;
					sectionLinks.CurrentSection = "Basics";
				}
				else
				{
					CreateNewEntity();
				}
				Globals.AddStatusMessage("Friendly Error reset.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditFriendlyError.btnReset_Click"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Save Friendly Error.</summary>
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
							if (FriendlyErrorAdded != null && (FriendlyErrorItem.ErrorNumber != MOD.Data.DefaultValue.Int || FriendlyErrorItem.LocaleCode != MOD.Data.DefaultValue.Int || FriendlyErrorItem.FriendlyErrorMessage != MOD.Data.DefaultValue.String || FriendlyErrorItem.CreatedByUserID != MOD.Data.DefaultValue.Guid || FriendlyErrorItem.CreatedDate != MOD.Data.DefaultValue.DateTime || FriendlyErrorItem.LastModifiedByUserID != MOD.Data.DefaultValue.Guid || FriendlyErrorItem.LastModifiedDate != MOD.Data.DefaultValue.DateTime || FriendlyErrorItem.Timestamp != null))
							{
								FriendlyErrorAdded(this, new EntityEditEventArgs(_entity));
								// create new object and store it in _entity
								CreateNewEntity();
								Session["FriendlyErrorItem"] = _entity;
								this.sectionLinks.OnSection("Basics");
								SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
							}
						}
						else
						{
							Globals.AddStatusMessage("Friendly Error updated.");
						}
					}
					else
					{
						UpsertToDatabase(true);
						if (AccessMode == MOD.Data.AccessMode.Add)
						{
							doRedirect = true;
							Globals.AddStatusMessage("Friendly Error added.");
						}
						else
						{
							Globals.AddStatusMessage("Friendly Error updated.");
						}
						SetAccessModeAndDisplay(MOD.Data.AccessMode.Edit);
					}
				}
				else
				{
					Globals.AddErrorMessage(Page, "Friendly Error validation failed.");
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditFriendlyError.btnSave_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && isValid == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("ErrorNumber", FriendlyErrorItem.ErrorNumber.ToString());
				queryString.Add("LocaleCode", FriendlyErrorItem.LocaleCode.ToString());
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditFriendlyError.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditFriendlyError.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditFriendlyError.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditFriendlyError.Page_PreRender"));
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
		/// Create a new Friendly Error object reference
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void CreateNewEntity()
		{
			BLL.UserExperience.FriendlyError vFriendlyError = new BLL.UserExperience.FriendlyError();
			vFriendlyError.ErrorNumber = MOD.Data.DataHelper.GetInt(Request.QueryString["ErrorNumber"], MOD.Data.DefaultValue.Int);
			vFriendlyError.LocaleCode = MOD.Data.DataHelper.GetInt(Request.QueryString["LocaleCode"], MOD.Data.DefaultValue.Int);
			_entity = vFriendlyError;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update form from Friendly Error information.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyEntityToForm()
		{
			BLL.UserExperience.FriendlyError vFriendlyError = FriendlyErrorItem;
			ddlErrorNumber.DataValueField = "PrimaryIndex";
			ddlErrorNumber.DataTextField = "PrimaryName";
			ddlErrorNumber.DataSource = BLL.Core.ErrorManager.GetAllErrorData(Globals.DBOptions, Globals.getDataOptions("ErrorTitle", "", true, true), Globals.DebugLevel, Globals.CurrentUserID);
			ddlErrorNumber.DataBind();
			ddlErrorNumber.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				BLL.Core.Error sError = new BLL.Core.Error();
				sError.ErrorNumber = MOD.Data.DataHelper.GetInt(vFriendlyError.ErrorNumber, MOD.Data.DefaultValue.Int);
				ddlErrorNumber.SelectedValue = MOD.Data.DataHelper.GetString(sError.PrimaryIndex, "");
				sError = null;
			}
			catch {}
			if(ddlErrorNumber.SelectedValue == ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				try
				{
					ddlErrorNumber.SelectedValue = MOD.Data.DataHelper.GetString(Session["Core/ErrorWorkingSetItem"], "");
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
				sLocale.LocaleCode = MOD.Data.DataHelper.GetInt(vFriendlyError.LocaleCode, MOD.Data.DefaultValue.Int);
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
			txtFriendlyErrorMessage.Text = MOD.Data.EditHelper.GetString(vFriendlyError.FriendlyErrorMessage);
			// Drop downs should be disabled when control is "Internal" and either value is constrained by container
			if (WorkflowMode == WorkflowMode.Internal)
			{
				ddlErrorNumber.Visible = Request.QueryString["ErrorNumber"] == null;
				valErrorNumber.Enabled = Request.QueryString["ErrorNumber"] == null;
				lblErrorNumberDisplay.Visible = Request.QueryString["ErrorNumber"] == null;
				ddlLocaleCode.Visible = Request.QueryString["LocaleCode"] == null;
				valLocaleCode.Enabled = Request.QueryString["LocaleCode"] == null;
				lblLocaleCodeDisplay.Visible = Request.QueryString["LocaleCode"] == null;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set Friendly Error information from the form.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyFormToEntity()
		{
			BLL.UserExperience.FriendlyError vFriendlyError = FriendlyErrorItem;
			if (vFriendlyError == null)
			{
				throw CoreUtility.CustomAppException.WrapException(new Exception("Friendly Error not found"), "EditFriendlyError.CopyFormToEntity()");
			}
			if (ddlErrorNumber.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Core.Error sError = new BLL.Core.Error(ddlErrorNumber.SelectedValue, false);
				vFriendlyError.ErrorNumber = MOD.Data.DataHelper.GetInt(sError.ErrorNumber, MOD.Data.DefaultValue.Int);
				sError = null;
			}
			if (ddlLocaleCode.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Environments.Locale sLocale = new BLL.Environments.Locale(ddlLocaleCode.SelectedValue, false);
				vFriendlyError.LocaleCode = MOD.Data.DataHelper.GetInt(sLocale.LocaleCode, MOD.Data.DefaultValue.Int);
				sLocale = null;
				vFriendlyError.PrimaryName += MOD.Data.DataHelper.GetString(ddlLocaleCode.SelectedItem.Text, MOD.Data.DefaultValue.String) + ";";
			}
			vFriendlyError.FriendlyErrorMessage = EditHelper.EncodeStringForDB(MOD.Data.DataHelper.GetString(txtFriendlyErrorMessage.Text, null));
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// Load entity from database, store in _entity and Session["FriendlyErrorItem"]
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void LoadEntity()
		{
			_entity = null;
			int errorNumber = MOD.Data.DataHelper.GetInt(Request.QueryString["ErrorNumber"], MOD.Data.DefaultValue.Int);
			int localeCode = MOD.Data.DataHelper.GetInt(Request.QueryString["LocaleCode"], MOD.Data.DefaultValue.Int);
			if (errorNumber != MOD.Data.DefaultValue.Int && localeCode != MOD.Data.DefaultValue.Int)
			{
				_entity = BLL.UserExperience.FriendlyErrorManager.GetOneFriendlyError(errorNumber, localeCode, Globals.getDataOptions("", "", true, true));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update Friendly Error information in the database.</summary>
		///
		// ------------------------------------------------------------------------------
		private void UpsertToDatabase(bool performCascade)
		{
			BLL.UserExperience.FriendlyError vFriendlyError = FriendlyErrorItem;
			if (AccessMode == MOD.Data.AccessMode.Add)
			{
				BLL.UserExperience.FriendlyErrorManager.AddOneFriendlyError(vFriendlyError, performCascade);
			}
			else if (AccessMode == MOD.Data.AccessMode.Edit)
			{
				BLL.UserExperience.FriendlyErrorManager.UpdateOneFriendlyError(vFriendlyError, performCascade);
			}
			FriendlyErrorItem.ErrorNumber = vFriendlyError.ErrorNumber;
			FriendlyErrorItem.LocaleCode = vFriendlyError.LocaleCode;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set access and display modes for presenting Friendly Error information.</summary>
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
					lblTitle.Text = "Add Friendly&nbsp;Error";
					btnSave.Text = "Add";
					break;
				case MOD.Data.AccessMode.Edit:
					lblTitle.Text = "Edit Friendly&nbsp;Error";
					btnSave.Text = "Save";
					break;
				case MOD.Data.AccessMode.View:
					lblTitle.Text = "View Friendly&nbsp;Error";
					break;
				default:
					lblTitle.Text = "View Friendly&nbsp;Error";
					break;
			}
			btnDelete.Visible = IsDeleteAvailable;
			btnNew.Visible = IsEditAvailable;
			btnSave.Visible = IsEditAvailable || IsAddAvailable;
			ddlErrorNumber.Enabled = IsAddAvailable;
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
		/// <summary>Initialize component for FriendlyError, add delegates here.</summary>
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