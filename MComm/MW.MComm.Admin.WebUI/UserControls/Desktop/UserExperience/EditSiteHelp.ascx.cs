
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
	/// <summary>Edit Site Help is used to help manage SiteHelp information.</summary>
	///
	/// File History:
	/// <created>6/1/2007 (Chris Grundy)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class EditSiteHelp  : Components.Desktop.BaseFormlUserControl, Controls.IHaveUploadableFiles
	{
		#region IHaveUploadableFiles
		public string GetFileRelativePath(Controls.FileUploader ctl)
		{
			if (ctl == txtSiteHelpImageURL)
				return SiteHelpItem.SiteHelpImageURL;
			else
				return null;
		}
		public string GetFolderPath(Controls.FileUploader ctl)
		{
			return CoreUtility.FileManager.GenerateFolderPathFromFileName(ctl.FileName);
		}
		public string GetNewFileName(Controls.FileUploader ctl, string fileName)
		{
			ctl.FileName = CoreUtility.FileManager.GenerateFileName(null, fileName);
			return ctl.FileName;
		}
		
		#endregion IHaveUploadableFiles
		#region Events
		/// <summary>
		/// Raised when "Add" button is clicked in internal mode.
		/// Container handles this event and adds entity to collection.
		/// </summary>
		public event EntityEditEventHandler SiteHelpAdded;
		/// <summary>
		/// Raised when "Remove" button is clicked in internal mode.
		/// Container handles this event and removes entity from collection.
		/// </summary>
		public event EntityEditEventHandler SiteHelpRemoved;
		#endregion Events
		#region Declarations
		#endregion Declarations
		#region Properties
		/// <summary>
		/// The SiteHelp currently being edited by this control.
		/// Get accessor casts base._entity to SiteHelp
		/// Set accessor used by parent control to set the item currently being edited
		/// </summary>
		public BLL.UserExperience.SiteHelp SiteHelpItem
		{
			get
			{
				return (BLL.UserExperience.SiteHelp) _entity;
			}
			set
			{
				_entity = value; // only set by container
				Session["SiteHelpItem"] = _entity;
			}
		}
		#endregion Properties
		#region Event Handlers
		// ------------------------------------------------------------------------------
		/// <summary>Load page for editing Site Help, getting mode and parameters.</summary>
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
						_entity = (BLL.UserExperience.SiteHelp)Session["SiteHelpItem"];
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
					Session["SiteHelpItem"] = _entity;
				}
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditSiteHelp.Page_Load"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Delete Site Help.</summary>
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
					BLL.UserExperience.SiteHelpManager.DeleteOneSiteHelp(SiteHelpItem, performCascade);
					Globals.AddStatusMessage("Site Help deleted.");
				}
				else
				{
					// raise event so item is removed from collection
					if (SiteHelpRemoved != null)
					{
						SiteHelpRemoved(this, new EntityEditEventArgs(_entity));
					}
				}
				// create new object and store it in _entity
				CreateNewEntity();
				Session["SiteHelpItem"] = _entity;
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditSiteHelp.btnDelete_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("LocaleCode", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Int, ""));
				queryString.Add("SiteHelpDefinitionCode", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Int, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Request to create a new Site Help.</summary>
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
				Session["SiteHelpItem"] = _entity;
				this.sectionLinks.OnSection("Basics");
				SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
				Globals.AddStatusMessage("Add new Site Help.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				doRedirect = false;
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				doRedirect = false;
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditSiteHelp.btnNew_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("LocaleCode", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Int, ""));
				queryString.Add("SiteHelpDefinitionCode", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Int, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Reset form for Site Help.</summary>
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
					Session["SiteHelpItem"] = _entity;
					sectionLinks.CurrentSection = "Basics";
				}
				else
				{
					CreateNewEntity();
				}
				Globals.AddStatusMessage("Site Help reset.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditSiteHelp.btnReset_Click"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Save Site Help.</summary>
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
				if (txtSiteHelpImageURL.HtmlInputFile.Value.Trim() != "" && txtSiteHelpImageURL.Validate() == false)
				{
					isValid = false;
				}
				if (isValid == true)
				{
					if (WorkflowMode == WorkflowMode.Internal)
					{
						if (AccessMode == MOD.Data.AccessMode.Add)
						{
							if (SiteHelpAdded != null && (SiteHelpItem.LocaleCode != MOD.Data.DefaultValue.Int || SiteHelpItem.SiteHelpName != MOD.Data.DefaultValue.String || SiteHelpItem.SiteHelpText != MOD.Data.DefaultValue.String || SiteHelpItem.SiteHelpImageURL != MOD.Data.DefaultValue.String || SiteHelpItem.SiteHelpGroupCode != MOD.Data.DefaultValue.Int || SiteHelpItem.CreatedByUserID != MOD.Data.DefaultValue.Guid || SiteHelpItem.CreatedDate != MOD.Data.DefaultValue.DateTime || SiteHelpItem.LastModifiedByUserID != MOD.Data.DefaultValue.Guid || SiteHelpItem.LastModifiedDate != MOD.Data.DefaultValue.DateTime || SiteHelpItem.Timestamp != null || SiteHelpItem.SiteHelpDefinitionCode != MOD.Data.DefaultValue.Int))
							{
								SiteHelpAdded(this, new EntityEditEventArgs(_entity));
								// create new object and store it in _entity
								CreateNewEntity();
								Session["SiteHelpItem"] = _entity;
								this.sectionLinks.OnSection("Basics");
								SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
							}
						}
						else
						{
							Globals.AddStatusMessage("Site Help updated.");
						}
					}
					else
					{
						UpsertToDatabase(true);
						if (AccessMode == MOD.Data.AccessMode.Add)
						{
							doRedirect = true;
							Globals.AddStatusMessage("Site Help added.");
						}
						else
						{
							Globals.AddStatusMessage("Site Help updated.");
						}
						SetAccessModeAndDisplay(MOD.Data.AccessMode.Edit);
					}
				}
				else
				{
					Globals.AddErrorMessage(Page, "Site Help validation failed.");
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditSiteHelp.btnSave_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && isValid == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("LocaleCode", SiteHelpItem.LocaleCode.ToString());
				queryString.Add("SiteHelpDefinitionCode", SiteHelpItem.SiteHelpDefinitionCode.ToString());
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditSiteHelp.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditSiteHelp.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditSiteHelp.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditSiteHelp.Page_PreRender"));
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
		/// Create a new Site Help object reference
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void CreateNewEntity()
		{
			BLL.UserExperience.SiteHelp vSiteHelp = new BLL.UserExperience.SiteHelp();
			vSiteHelp.LocaleCode = MOD.Data.DataHelper.GetInt(Request.QueryString["LocaleCode"], MOD.Data.DefaultValue.Int);
			vSiteHelp.SiteHelpGroupCode = MOD.Data.DataHelper.GetInt(Request.QueryString["SiteHelpGroupCode"], MOD.Data.DefaultValue.Int);
			vSiteHelp.SiteHelpDefinitionCode = MOD.Data.DataHelper.GetInt(Request.QueryString["SiteHelpDefinitionCode"], MOD.Data.DefaultValue.Int);
			_entity = vSiteHelp;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update form from Site Help information.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyEntityToForm()
		{
			BLL.UserExperience.SiteHelp vSiteHelp = SiteHelpItem;
			ddlLocaleCode.DataValueField = "PrimaryIndex";
			ddlLocaleCode.DataTextField = "PrimaryName";
			ddlLocaleCode.DataSource = BLL.Environments.LocaleManager.GetAllLocaleData(Globals.DBOptions, Globals.getDataOptions("LocaleName", "", true, true), Globals.DebugLevel, Globals.CurrentUserID);
			ddlLocaleCode.DataBind();
			ddlLocaleCode.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				BLL.Environments.Locale sLocale = new BLL.Environments.Locale();
				sLocale.LocaleCode = MOD.Data.DataHelper.GetInt(vSiteHelp.LocaleCode, MOD.Data.DefaultValue.Int);
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
			txtSiteHelpName.Text = MOD.Data.EditHelper.GetString(vSiteHelp.SiteHelpName);
			txtSiteHelpText.Text = Server.HtmlDecode(MOD.Data.EditHelper.GetString(vSiteHelp.SiteHelpText));
			ddlSiteHelpGroupCode.DataValueField = "PrimaryIndex";
			ddlSiteHelpGroupCode.DataTextField = "PrimaryName";
			ddlSiteHelpGroupCode.DataSource = BLL.UserExperience.SiteHelpGroupManager.GetAllSiteHelpGroupData(Globals.DBOptions, Globals.getDataOptions("", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
			ddlSiteHelpGroupCode.DataBind();
			ddlSiteHelpGroupCode.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				BLL.UserExperience.SiteHelpGroup sSiteHelpGroup = new BLL.UserExperience.SiteHelpGroup();
				sSiteHelpGroup.SiteHelpGroupCode = MOD.Data.DataHelper.GetInt(vSiteHelp.SiteHelpGroupCode, MOD.Data.DefaultValue.Int);
				ddlSiteHelpGroupCode.SelectedValue = MOD.Data.DataHelper.GetString(sSiteHelpGroup.PrimaryIndex, "");
				sSiteHelpGroup = null;
			}
			catch {}
			if(ddlSiteHelpGroupCode.SelectedValue == ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				try
				{
					ddlSiteHelpGroupCode.SelectedValue = MOD.Data.DataHelper.GetString(Session["UserExperience/SiteHelpGroupWorkingSetItem"], "");
				}
				catch {}
			}
			ddlSiteHelpDefinitionCode.DataValueField = "PrimaryIndex";
			ddlSiteHelpDefinitionCode.DataTextField = "PrimaryName";
			ddlSiteHelpDefinitionCode.DataSource = BLL.UserExperience.SiteHelpDefinitionManager.GetAllSiteHelpDefinitionData(Globals.DBOptions, Globals.getDataOptions("SiteHelpDefinitionName", "", true, true), Globals.DebugLevel, Globals.CurrentUserID);
			ddlSiteHelpDefinitionCode.DataBind();
			ddlSiteHelpDefinitionCode.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				BLL.UserExperience.SiteHelpDefinition sSiteHelpDefinition = new BLL.UserExperience.SiteHelpDefinition();
				sSiteHelpDefinition.SiteHelpDefinitionCode = MOD.Data.DataHelper.GetInt(vSiteHelp.SiteHelpDefinitionCode, MOD.Data.DefaultValue.Int);
				ddlSiteHelpDefinitionCode.SelectedValue = MOD.Data.DataHelper.GetString(sSiteHelpDefinition.PrimaryIndex, "");
				sSiteHelpDefinition = null;
			}
			catch {}
			if(ddlSiteHelpDefinitionCode.SelectedValue == ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				try
				{
					ddlSiteHelpDefinitionCode.SelectedValue = MOD.Data.DataHelper.GetString(Session["UserExperience/SiteHelpDefinitionWorkingSetItem"], "");
				}
				catch {}
			}
			// Drop downs should be disabled when control is "Internal" and either value is constrained by container
			if (WorkflowMode == WorkflowMode.Internal)
			{
				ddlLocaleCode.Visible = Request.QueryString["LocaleCode"] == null;
				valLocaleCode.Enabled = Request.QueryString["LocaleCode"] == null;
				lblLocaleCodeDisplay.Visible = Request.QueryString["LocaleCode"] == null;
				ddlSiteHelpGroupCode.Visible = Request.QueryString["SiteHelpGroupCode"] == null;
				valSiteHelpGroupCode.Enabled = Request.QueryString["SiteHelpGroupCode"] == null;
				lblSiteHelpGroupCodeDisplay.Visible = Request.QueryString["SiteHelpGroupCode"] == null;
				ddlSiteHelpDefinitionCode.Visible = Request.QueryString["SiteHelpDefinitionCode"] == null;
				valSiteHelpDefinitionCode.Enabled = Request.QueryString["SiteHelpDefinitionCode"] == null;
				lblSiteHelpDefinitionCodeDisplay.Visible = Request.QueryString["SiteHelpDefinitionCode"] == null;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set Site Help information from the form.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyFormToEntity()
		{
			BLL.UserExperience.SiteHelp vSiteHelp = SiteHelpItem;
			if (vSiteHelp == null)
			{
				throw CoreUtility.CustomAppException.WrapException(new Exception("Site Help not found"), "EditSiteHelp.CopyFormToEntity()");
			}
			if (ddlLocaleCode.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Environments.Locale sLocale = new BLL.Environments.Locale(ddlLocaleCode.SelectedValue, false);
				vSiteHelp.LocaleCode = MOD.Data.DataHelper.GetInt(sLocale.LocaleCode, MOD.Data.DefaultValue.Int);
				sLocale = null;
				vSiteHelp.PrimaryName += MOD.Data.DataHelper.GetString(ddlLocaleCode.SelectedItem.Text, MOD.Data.DefaultValue.String) + ";";
			}
			vSiteHelp.SiteHelpName = EditHelper.EncodeStringForDB(MOD.Data.DataHelper.GetString(txtSiteHelpName.Text, null));
			vSiteHelp.SiteHelpText = EditHelper.EncodeStringForDB(MOD.Data.DataHelper.GetString(txtSiteHelpText.Text, null));
			vSiteHelp.SiteHelpImageURL = txtSiteHelpImageURL.SaveFile();
			if (ddlSiteHelpGroupCode.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.UserExperience.SiteHelpGroup sSiteHelpGroup = new BLL.UserExperience.SiteHelpGroup(ddlSiteHelpGroupCode.SelectedValue, false);
				vSiteHelp.SiteHelpGroupCode = MOD.Data.DataHelper.GetInt(sSiteHelpGroup.SiteHelpGroupCode, MOD.Data.DefaultValue.Int);
				sSiteHelpGroup = null;
				vSiteHelp.PrimaryName += MOD.Data.DataHelper.GetString(ddlSiteHelpGroupCode.SelectedItem.Text, MOD.Data.DefaultValue.String) + ";";
			}
			if (ddlSiteHelpDefinitionCode.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.UserExperience.SiteHelpDefinition sSiteHelpDefinition = new BLL.UserExperience.SiteHelpDefinition(ddlSiteHelpDefinitionCode.SelectedValue, false);
				vSiteHelp.SiteHelpDefinitionCode = MOD.Data.DataHelper.GetInt(sSiteHelpDefinition.SiteHelpDefinitionCode, MOD.Data.DefaultValue.Int);
				sSiteHelpDefinition = null;
				vSiteHelp.PrimaryName += MOD.Data.DataHelper.GetString(ddlSiteHelpDefinitionCode.SelectedItem.Text, MOD.Data.DefaultValue.String) + ";";
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// Load entity from database, store in _entity and Session["SiteHelpItem"]
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void LoadEntity()
		{
			_entity = null;
			int siteHelpDefinitionCode = MOD.Data.DataHelper.GetInt(Request.QueryString["SiteHelpDefinitionCode"], MOD.Data.DefaultValue.Int);
			int localeCode = MOD.Data.DataHelper.GetInt(Request.QueryString["LocaleCode"], MOD.Data.DefaultValue.Int);
			if (siteHelpDefinitionCode != MOD.Data.DefaultValue.Int && localeCode != MOD.Data.DefaultValue.Int)
			{
				_entity = BLL.UserExperience.SiteHelpManager.GetOneSiteHelp(siteHelpDefinitionCode, localeCode, Globals.getDataOptions("", "", true, true));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update Site Help information in the database.</summary>
		///
		// ------------------------------------------------------------------------------
		private void UpsertToDatabase(bool performCascade)
		{
			BLL.UserExperience.SiteHelp vSiteHelp = SiteHelpItem;
			if (AccessMode == MOD.Data.AccessMode.Add)
			{
				BLL.UserExperience.SiteHelpManager.AddOneSiteHelp(vSiteHelp, performCascade);
			}
			else if (AccessMode == MOD.Data.AccessMode.Edit)
			{
				BLL.UserExperience.SiteHelpManager.UpdateOneSiteHelp(vSiteHelp, performCascade);
			}
			SiteHelpItem.LocaleCode = vSiteHelp.LocaleCode;
			SiteHelpItem.SiteHelpDefinitionCode = vSiteHelp.SiteHelpDefinitionCode;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set access and display modes for presenting Site Help information.</summary>
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
					lblTitle.Text = "Add Site&nbsp;Help";
					btnSave.Text = "Add";
					break;
				case MOD.Data.AccessMode.Edit:
					lblTitle.Text = "Edit Site&nbsp;Help";
					btnSave.Text = "Save";
					break;
				case MOD.Data.AccessMode.View:
					lblTitle.Text = "View Site&nbsp;Help";
					break;
				default:
					lblTitle.Text = "View Site&nbsp;Help";
					break;
			}
			btnDelete.Visible = IsDeleteAvailable;
			btnNew.Visible = IsEditAvailable;
			btnSave.Visible = IsEditAvailable || IsAddAvailable;
			ddlLocaleCode.Enabled = IsAddAvailable;
			ddlSiteHelpDefinitionCode.Enabled = IsAddAvailable;
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
		/// <summary>Initialize component for SiteHelp, add delegates here.</summary>
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