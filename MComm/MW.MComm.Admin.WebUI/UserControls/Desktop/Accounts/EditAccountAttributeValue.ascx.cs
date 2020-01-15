
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
using MW.MComm.WalletSolution.BLL.Accounts;
using CoreUtility = MW.MComm.WalletSolution.Utility;
using MW.MComm.Admin.WebUI.Components.Desktop;
namespace MW.MComm.Admin.WebUI.UserControls.Desktop.Accounts
{
	// ------------------------------------------------------------------------------
	/// <summary>Edit Account Attribute Value is used to help manage AccountAttributeValue information.</summary>
	///
	/// File History:
	/// <created>6/1/2007 (Chris Grundy)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class EditAccountAttributeValue  : Components.Desktop.BaseFormlUserControl
	{
		#region Events
		/// <summary>
		/// Raised when "Add" button is clicked in internal mode.
		/// Container handles this event and adds entity to collection.
		/// </summary>
		public event EntityEditEventHandler AccountAttributeValueAdded;
		/// <summary>
		/// Raised when "Remove" button is clicked in internal mode.
		/// Container handles this event and removes entity from collection.
		/// </summary>
		public event EntityEditEventHandler AccountAttributeValueRemoved;
		#endregion Events
		#region Declarations
		#endregion Declarations
		#region Properties
		/// <summary>
		/// The AccountAttributeValue currently being edited by this control.
		/// Get accessor casts base._entity to AccountAttributeValue
		/// Set accessor used by parent control to set the item currently being edited
		/// </summary>
		public BLL.Accounts.AccountAttributeValue AccountAttributeValueItem
		{
			get
			{
				return (BLL.Accounts.AccountAttributeValue) _entity;
			}
			set
			{
				_entity = value; // only set by container
				Session["AccountAttributeValueItem"] = _entity;
			}
		}
		#endregion Properties
		#region Event Handlers
		// ------------------------------------------------------------------------------
		/// <summary>Load page for editing Account Attribute Value, getting mode and parameters.</summary>
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
						_entity = (BLL.Accounts.AccountAttributeValue)Session["AccountAttributeValueItem"];
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
					Session["AccountAttributeValueItem"] = _entity;
				}
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditAccountAttributeValue.Page_Load"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Delete Account Attribute Value.</summary>
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
					BLL.Accounts.AccountAttributeValueManager.DeleteOneAccountAttributeValue(AccountAttributeValueItem, performCascade);
					Globals.AddStatusMessage("Account Attribute Value deleted.");
				}
				else
				{
					// raise event so item is removed from collection
					if (AccountAttributeValueRemoved != null)
					{
						AccountAttributeValueRemoved(this, new EntityEditEventArgs(_entity));
					}
				}
				// create new object and store it in _entity
				CreateNewEntity();
				Session["AccountAttributeValueItem"] = _entity;
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditAccountAttributeValue.btnDelete_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("AccountAttributeValueID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Request to create a new Account Attribute Value.</summary>
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
				Session["AccountAttributeValueItem"] = _entity;
				this.sectionLinks.OnSection("Basics");
				SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
				Globals.AddStatusMessage("Add new Account Attribute Value.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				doRedirect = false;
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				doRedirect = false;
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditAccountAttributeValue.btnNew_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("AccountAttributeValueID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Reset form for Account Attribute Value.</summary>
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
					Session["AccountAttributeValueItem"] = _entity;
					sectionLinks.CurrentSection = "Basics";
				}
				else
				{
					CreateNewEntity();
				}
				Globals.AddStatusMessage("Account Attribute Value reset.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditAccountAttributeValue.btnReset_Click"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Save Account Attribute Value.</summary>
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
							if (AccountAttributeValueAdded != null && (AccountAttributeValueItem.AccountAttributeValueID != MOD.Data.DefaultValue.Guid || AccountAttributeValueItem.AccountID != MOD.Data.DefaultValue.Guid || AccountAttributeValueItem.BaseAttributeID != MOD.Data.DefaultValue.Guid || AccountAttributeValueItem.ParameterValue != MOD.Data.DefaultValue.String || AccountAttributeValueItem.CreatedByUserID != MOD.Data.DefaultValue.Guid || AccountAttributeValueItem.CreatedDate != MOD.Data.DefaultValue.DateTime || AccountAttributeValueItem.LastModifiedByUserID != MOD.Data.DefaultValue.Guid || AccountAttributeValueItem.LastModifiedDate != MOD.Data.DefaultValue.DateTime || AccountAttributeValueItem.Timestamp != null))
							{
								AccountAttributeValueAdded(this, new EntityEditEventArgs(_entity));
								// create new object and store it in _entity
								CreateNewEntity();
								Session["AccountAttributeValueItem"] = _entity;
								this.sectionLinks.OnSection("Basics");
								SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
							}
						}
						else
						{
							Globals.AddStatusMessage("Account Attribute Value updated.");
						}
					}
					else
					{
						UpsertToDatabase(true);
						if (AccessMode == MOD.Data.AccessMode.Add)
						{
							doRedirect = true;
							Globals.AddStatusMessage("Account Attribute Value added.");
						}
						else
						{
							Globals.AddStatusMessage("Account Attribute Value updated.");
						}
						SetAccessModeAndDisplay(MOD.Data.AccessMode.Edit);
					}
				}
				else
				{
					Globals.AddErrorMessage(Page, "Account Attribute Value validation failed.");
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditAccountAttributeValue.btnSave_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && isValid == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("AccountAttributeValueID", AccountAttributeValueItem.AccountAttributeValueID.ToString());
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditAccountAttributeValue.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditAccountAttributeValue.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditAccountAttributeValue.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditAccountAttributeValue.Page_PreRender"));
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
		/// Create a new Account Attribute Value object reference
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void CreateNewEntity()
		{
			BLL.Accounts.AccountAttributeValue vAccountAttributeValue = new BLL.Accounts.AccountAttributeValue();
			vAccountAttributeValue.AccountAttributeValueID = MOD.Data.DataHelper.GetGuid(Request.QueryString["AccountAttributeValueID"], MOD.Data.DefaultValue.Guid);
			vAccountAttributeValue.AccountID = MOD.Data.DataHelper.GetGuid(Request.QueryString["AccountID"], MOD.Data.DefaultValue.Guid);
			vAccountAttributeValue.BaseAttributeID = MOD.Data.DataHelper.GetGuid(Request.QueryString["BaseAttributeID"], MOD.Data.DefaultValue.Guid);
			_entity = vAccountAttributeValue;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update form from Account Attribute Value information.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyEntityToForm()
		{
			BLL.Accounts.AccountAttributeValue vAccountAttributeValue = AccountAttributeValueItem;
			lblAccountAttributeValueID.Text = MOD.Data.DataHelper.GetString(vAccountAttributeValue.AccountAttributeValueID, "");
			ddlAccountID.DataValueField = "PrimaryIndex";
			ddlAccountID.DataTextField = "PrimaryName";
			if (UseWorkingSets == true && Session["Accounts/AccountWorkingSet"] != null)
			{
				BLL.SortableList<BLL.Accounts.Account> sessionSource = (BLL.SortableList<BLL.Accounts.Account>) Session["Accounts/AccountWorkingSet"];
				BLL.SortableList<BLL.Accounts.Account> currentSource = new BLL.SortableList<BLL.Accounts.Account>(sessionSource, true);
				if (MOD.Data.DataHelper.GetGuid(vAccountAttributeValue.AccountID, MOD.Data.DefaultValue.Guid) != MOD.Data.DefaultValue.Guid)
				{
					BLL.Accounts.Account currentAccount = BLL.Accounts.AccountManager.GetOneAccount(MOD.Data.DataHelper.GetGuid(vAccountAttributeValue.AccountID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions("", "", true, true));
					if (currentAccount != null && currentSource.Contains(currentAccount) == false)
					{
						currentSource.Insert(0, currentAccount);
					}
				}
				ddlAccountID.DataSource = currentSource;
				lnkAccountIDWorkingSet.Visible = true;
				lnkAccountIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Accounts/SearchAccountData.aspx");
				lblAccountIDWorkingSet.Visible = true;
				lblAccountIDWorkingSet.Text = " (from Account working set)";
			}
			else
			{
				ddlAccountID.DataSource = BLL.Accounts.AccountManager.GetAllAccountData(Globals.DBOptions, Globals.getDataOptions("AccountName", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
				lblAccountIDWorkingSet.Visible = false;
				if (UseWorkingSets == true)
				{
					lnkAccountIDWorkingSet.Visible = true;
					lnkAccountIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Accounts/SearchAccountData.aspx");
				}
				else
				{
					lnkAccountIDWorkingSet.Visible = false;
				}
			}
			ddlAccountID.DataBind();
			ddlAccountID.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				BLL.Accounts.Account sAccount = new BLL.Accounts.Account();
				sAccount.AccountID = MOD.Data.DataHelper.GetGuid(vAccountAttributeValue.AccountID, MOD.Data.DefaultValue.Guid);
				ddlAccountID.SelectedValue = MOD.Data.DataHelper.GetString(sAccount.PrimaryIndex, "");
				sAccount = null;
			}
			catch {}
			if(ddlAccountID.SelectedValue == ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				try
				{
					ddlAccountID.SelectedValue = MOD.Data.DataHelper.GetString(Session["Accounts/AccountWorkingSetItem"], "");
				}
				catch {}
			}
			ddlBaseAttributeID.DataValueField = "PrimaryIndex";
			ddlBaseAttributeID.DataTextField = "PrimaryName";
			if (UseWorkingSets == true && Session["Accounts/AccountAttributeWorkingSet"] != null)
			{
				BLL.SortableList<BLL.Accounts.AccountAttribute> sessionSource = (BLL.SortableList<BLL.Accounts.AccountAttribute>) Session["Accounts/AccountAttributeWorkingSet"];
				BLL.SortableList<BLL.Accounts.AccountAttribute> currentSource = new BLL.SortableList<BLL.Accounts.AccountAttribute>(sessionSource, true);
				if (MOD.Data.DataHelper.GetGuid(vAccountAttributeValue.BaseAttributeID, MOD.Data.DefaultValue.Guid) != MOD.Data.DefaultValue.Guid)
				{
					BLL.Accounts.AccountAttribute currentAccountAttribute = BLL.Accounts.AccountAttributeManager.GetOneAccountAttribute(MOD.Data.DataHelper.GetGuid(vAccountAttributeValue.BaseAttributeID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions("", "", true, true));
					if (currentAccountAttribute != null && currentSource.Contains(currentAccountAttribute) == false)
					{
						currentSource.Insert(0, currentAccountAttribute);
					}
				}
				ddlBaseAttributeID.DataSource = currentSource;
				lnkBaseAttributeIDWorkingSet.Visible = true;
				lnkBaseAttributeIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Accounts/SearchAccountAttributeData.aspx");
				lblBaseAttributeIDWorkingSet.Visible = true;
				lblBaseAttributeIDWorkingSet.Text = " (from Account Attribute working set)";
			}
			else
			{
				ddlBaseAttributeID.DataSource = BLL.Accounts.AccountAttributeManager.GetAllAccountAttributeData(Globals.DBOptions, Globals.getDataOptions("AttributeName", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
				lblBaseAttributeIDWorkingSet.Visible = false;
				if (UseWorkingSets == true)
				{
					lnkBaseAttributeIDWorkingSet.Visible = true;
					lnkBaseAttributeIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Accounts/SearchAccountAttributeData.aspx");
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
				BLL.Accounts.AccountAttribute sAccountAttribute = new BLL.Accounts.AccountAttribute();
				sAccountAttribute.BaseAttributeID = MOD.Data.DataHelper.GetGuid(vAccountAttributeValue.BaseAttributeID, MOD.Data.DefaultValue.Guid);
				ddlBaseAttributeID.SelectedValue = MOD.Data.DataHelper.GetString(sAccountAttribute.PrimaryIndex, "");
				sAccountAttribute = null;
			}
			catch {}
			if(ddlBaseAttributeID.SelectedValue == ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				try
				{
					ddlBaseAttributeID.SelectedValue = MOD.Data.DataHelper.GetString(Session["Accounts/AccountAttributeWorkingSetItem"], "");
				}
				catch {}
			}
			txtParameterValue.Text = MOD.Data.EditHelper.GetString(vAccountAttributeValue.ParameterValue);
			// Drop downs should be disabled when control is "Internal" and either value is constrained by container
			if (WorkflowMode == WorkflowMode.Internal)
			{
				ddlAccountID.Visible = Request.QueryString["AccountID"] == null;
				lnkAccountIDWorkingSet.Visible = lnkAccountIDWorkingSet.Visible == true && Request.QueryString["AccountID"] == null;
				lblAccountIDWorkingSet.Visible = lblAccountIDWorkingSet.Visible == true && Request.QueryString["AccountID"] == null;
				valAccountID.Enabled = Request.QueryString["AccountID"] == null;
				lblAccountIDDisplay.Visible = Request.QueryString["AccountID"] == null;
				ddlBaseAttributeID.Visible = Request.QueryString["BaseAttributeID"] == null;
				lnkBaseAttributeIDWorkingSet.Visible = lnkBaseAttributeIDWorkingSet.Visible == true && Request.QueryString["BaseAttributeID"] == null;
				lblBaseAttributeIDWorkingSet.Visible = lblBaseAttributeIDWorkingSet.Visible == true && Request.QueryString["BaseAttributeID"] == null;
				valBaseAttributeID.Enabled = Request.QueryString["BaseAttributeID"] == null;
				lblBaseAttributeIDDisplay.Visible = Request.QueryString["BaseAttributeID"] == null;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set Account Attribute Value information from the form.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyFormToEntity()
		{
			BLL.Accounts.AccountAttributeValue vAccountAttributeValue = AccountAttributeValueItem;
			if (vAccountAttributeValue == null)
			{
				throw CoreUtility.CustomAppException.WrapException(new Exception("Account Attribute Value not found"), "EditAccountAttributeValue.CopyFormToEntity()");
			}
			if (ddlAccountID.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Accounts.Account sAccount = new BLL.Accounts.Account(ddlAccountID.SelectedValue, false);
				vAccountAttributeValue.AccountID = MOD.Data.DataHelper.GetGuid(sAccount.AccountID, MOD.Data.DefaultValue.Guid);
				sAccount = null;
				vAccountAttributeValue.PrimaryName += MOD.Data.DataHelper.GetString(ddlAccountID.SelectedItem.Text, MOD.Data.DefaultValue.String) + ";";
			}
			if (ddlBaseAttributeID.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Accounts.AccountAttribute sAccountAttribute = new BLL.Accounts.AccountAttribute(ddlBaseAttributeID.SelectedValue, false);
				vAccountAttributeValue.BaseAttributeID = MOD.Data.DataHelper.GetGuid(sAccountAttribute.BaseAttributeID, MOD.Data.DefaultValue.Guid);
				sAccountAttribute = null;
			}
			vAccountAttributeValue.ParameterValue = EditHelper.EncodeStringForDB(MOD.Data.DataHelper.GetString(txtParameterValue.Text, null));
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// Load entity from database, store in _entity and Session["AccountAttributeValueItem"]
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void LoadEntity()
		{
			_entity = null;
			Guid accountAttributeValueID = MOD.Data.DataHelper.GetGuid(Request.QueryString["AccountAttributeValueID"], MOD.Data.DefaultValue.Guid);
			if (accountAttributeValueID != MOD.Data.DefaultValue.Guid)
			{
				_entity = BLL.Accounts.AccountAttributeValueManager.GetOneAccountAttributeValue(accountAttributeValueID, Globals.getDataOptions("", "", true, true));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update Account Attribute Value information in the database.</summary>
		///
		// ------------------------------------------------------------------------------
		private void UpsertToDatabase(bool performCascade)
		{
			BLL.Accounts.AccountAttributeValue vAccountAttributeValue = AccountAttributeValueItem;
			if (AccessMode == MOD.Data.AccessMode.Add)
			{
				BLL.Accounts.AccountAttributeValueManager.UpsertOneAccountAttributeValue(vAccountAttributeValue, performCascade);
			}
			else if (AccessMode == MOD.Data.AccessMode.Edit)
			{
				BLL.Accounts.AccountAttributeValueManager.UpsertOneAccountAttributeValue(vAccountAttributeValue, performCascade);
			}
			AccountAttributeValueItem.AccountAttributeValueID = vAccountAttributeValue.AccountAttributeValueID;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set access and display modes for presenting Account Attribute Value information.</summary>
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
					lblTitle.Text = "Add Account&nbsp;Attribute&nbsp;Value";
					btnSave.Text = "Add";
					break;
				case MOD.Data.AccessMode.Edit:
					lblTitle.Text = "Edit Account&nbsp;Attribute&nbsp;Value";
					btnSave.Text = "Save";
					break;
				case MOD.Data.AccessMode.View:
					lblTitle.Text = "View Account&nbsp;Attribute&nbsp;Value";
					break;
				default:
					lblTitle.Text = "View Account&nbsp;Attribute&nbsp;Value";
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
		/// <summary>Initialize component for AccountAttributeValue, add delegates here.</summary>
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