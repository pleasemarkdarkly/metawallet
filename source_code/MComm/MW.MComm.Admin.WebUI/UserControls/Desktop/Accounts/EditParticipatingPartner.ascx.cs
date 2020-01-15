
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
	/// <summary>Edit Participating Partner is used to help manage ParticipatingPartner information.</summary>
	///
	/// File History:
	/// <created>6/1/2007 (Chris Grundy)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class EditParticipatingPartner  : Components.Desktop.BaseFormlUserControl
	{
		#region Events
		/// <summary>
		/// Raised when "Add" button is clicked in internal mode.
		/// Container handles this event and adds entity to collection.
		/// </summary>
		public event EntityEditEventHandler ParticipatingPartnerAdded;
		/// <summary>
		/// Raised when "Remove" button is clicked in internal mode.
		/// Container handles this event and removes entity from collection.
		/// </summary>
		public event EntityEditEventHandler ParticipatingPartnerRemoved;
		#endregion Events
		#region Declarations
		#endregion Declarations
		#region Properties
		/// <summary>
		/// The ParticipatingPartner currently being edited by this control.
		/// Get accessor casts base._entity to ParticipatingPartner
		/// Set accessor used by parent control to set the item currently being edited
		/// </summary>
		public BLL.Accounts.ParticipatingPartner ParticipatingPartnerItem
		{
			get
			{
				return (BLL.Accounts.ParticipatingPartner) _entity;
			}
			set
			{
				_entity = value; // only set by container
				Session["ParticipatingPartnerItem"] = _entity;
			}
		}
		#endregion Properties
		#region Event Handlers
		// ------------------------------------------------------------------------------
		/// <summary>Load page for editing Participating Partner, getting mode and parameters.</summary>
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
						_entity = (BLL.Accounts.ParticipatingPartner)Session["ParticipatingPartnerItem"];
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
					Session["ParticipatingPartnerItem"] = _entity;
				}
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditParticipatingPartner.Page_Load"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Delete Participating Partner.</summary>
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
					BLL.Accounts.ParticipatingPartnerManager.DeleteOneParticipatingPartner(ParticipatingPartnerItem, performCascade);
					Globals.AddStatusMessage("Participating Partner deleted.");
				}
				else
				{
					// raise event so item is removed from collection
					if (ParticipatingPartnerRemoved != null)
					{
						ParticipatingPartnerRemoved(this, new EntityEditEventArgs(_entity));
					}
				}
				// create new object and store it in _entity
				CreateNewEntity();
				Session["ParticipatingPartnerItem"] = _entity;
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditParticipatingPartner.btnDelete_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("AccountID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("MetaPartnerID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Request to create a new Participating Partner.</summary>
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
				Session["ParticipatingPartnerItem"] = _entity;
				this.sectionLinks.OnSection("Basics");
				SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
				Globals.AddStatusMessage("Add new Participating Partner.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				doRedirect = false;
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				doRedirect = false;
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditParticipatingPartner.btnNew_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("AccountID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("MetaPartnerID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Reset form for Participating Partner.</summary>
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
					Session["ParticipatingPartnerItem"] = _entity;
					sectionLinks.CurrentSection = "Basics";
				}
				else
				{
					CreateNewEntity();
				}
				Globals.AddStatusMessage("Participating Partner reset.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditParticipatingPartner.btnReset_Click"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Save Participating Partner.</summary>
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
							if (ParticipatingPartnerAdded != null && (ParticipatingPartnerItem.AccountID != MOD.Data.DefaultValue.Guid || ParticipatingPartnerItem.MetaPartnerID != MOD.Data.DefaultValue.Guid || ParticipatingPartnerItem.CreatedByUserID != MOD.Data.DefaultValue.Guid || ParticipatingPartnerItem.CreatedDate != MOD.Data.DefaultValue.DateTime || ParticipatingPartnerItem.LastModifiedByUserID != MOD.Data.DefaultValue.Guid || ParticipatingPartnerItem.LastModifiedDate != MOD.Data.DefaultValue.DateTime || ParticipatingPartnerItem.Timestamp != null))
							{
								ParticipatingPartnerAdded(this, new EntityEditEventArgs(_entity));
								// create new object and store it in _entity
								CreateNewEntity();
								Session["ParticipatingPartnerItem"] = _entity;
								this.sectionLinks.OnSection("Basics");
								SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
							}
						}
						else
						{
							Globals.AddStatusMessage("Participating Partner updated.");
						}
					}
					else
					{
						UpsertToDatabase(true);
						if (AccessMode == MOD.Data.AccessMode.Add)
						{
							doRedirect = true;
							Globals.AddStatusMessage("Participating Partner added.");
						}
						else
						{
							Globals.AddStatusMessage("Participating Partner updated.");
						}
						SetAccessModeAndDisplay(MOD.Data.AccessMode.Edit);
					}
				}
				else
				{
					Globals.AddErrorMessage(Page, "Participating Partner validation failed.");
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditParticipatingPartner.btnSave_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && isValid == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("AccountID", ParticipatingPartnerItem.AccountID.ToString());
				queryString.Add("MetaPartnerID", ParticipatingPartnerItem.MetaPartnerID.ToString());
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditParticipatingPartner.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditParticipatingPartner.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditParticipatingPartner.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditParticipatingPartner.Page_PreRender"));
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
		/// Create a new Participating Partner object reference
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void CreateNewEntity()
		{
			BLL.Accounts.ParticipatingPartner vParticipatingPartner = new BLL.Accounts.ParticipatingPartner();
			vParticipatingPartner.AccountID = MOD.Data.DataHelper.GetGuid(Request.QueryString["AccountID"], MOD.Data.DefaultValue.Guid);
			vParticipatingPartner.MetaPartnerID = MOD.Data.DataHelper.GetGuid(Request.QueryString["MetaPartnerID"], MOD.Data.DefaultValue.Guid);
			_entity = vParticipatingPartner;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update form from Participating Partner information.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyEntityToForm()
		{
			BLL.Accounts.ParticipatingPartner vParticipatingPartner = ParticipatingPartnerItem;
			ddlAccountID.DataValueField = "PrimaryIndex";
			ddlAccountID.DataTextField = "PrimaryName";
			if (UseWorkingSets == true && Session["Accounts/FundAccountWorkingSet"] != null)
			{
				BLL.SortableList<BLL.Accounts.FundAccount> sessionSource = (BLL.SortableList<BLL.Accounts.FundAccount>) Session["Accounts/FundAccountWorkingSet"];
				BLL.SortableList<BLL.Accounts.FundAccount> currentSource = new BLL.SortableList<BLL.Accounts.FundAccount>(sessionSource, true);
				if (MOD.Data.DataHelper.GetGuid(vParticipatingPartner.AccountID, MOD.Data.DefaultValue.Guid) != MOD.Data.DefaultValue.Guid)
				{
					BLL.Accounts.FundAccount currentFundAccount = BLL.Accounts.FundAccountManager.GetOneFundAccount(MOD.Data.DataHelper.GetGuid(vParticipatingPartner.AccountID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions("", "", true, true));
					if (currentFundAccount != null && currentSource.Contains(currentFundAccount) == false)
					{
						currentSource.Insert(0, currentFundAccount);
					}
				}
				ddlAccountID.DataSource = currentSource;
				lnkAccountIDWorkingSet.Visible = true;
				lnkAccountIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Accounts/SearchFundAccountData.aspx");
				lblAccountIDWorkingSet.Visible = true;
				lblAccountIDWorkingSet.Text = " (from Fund Account working set)";
			}
			else
			{
				ddlAccountID.DataSource = BLL.Accounts.FundAccountManager.GetAllFundAccountData(Globals.DBOptions, Globals.getDataOptions("AccountName", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
				lblAccountIDWorkingSet.Visible = false;
				if (UseWorkingSets == true)
				{
					lnkAccountIDWorkingSet.Visible = true;
					lnkAccountIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Accounts/SearchFundAccountData.aspx");
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
				BLL.Accounts.FundAccount sFundAccount = new BLL.Accounts.FundAccount();
				sFundAccount.AccountID = MOD.Data.DataHelper.GetGuid(vParticipatingPartner.AccountID, MOD.Data.DefaultValue.Guid);
				ddlAccountID.SelectedValue = MOD.Data.DataHelper.GetString(sFundAccount.PrimaryIndex, "");
				sFundAccount = null;
			}
			catch {}
			if(ddlAccountID.SelectedValue == ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				try
				{
					ddlAccountID.SelectedValue = MOD.Data.DataHelper.GetString(Session["Accounts/FundAccountWorkingSetItem"], "");
				}
				catch {}
			}
			ddlMetaPartnerID.DataValueField = "PrimaryIndex";
			ddlMetaPartnerID.DataTextField = "PrimaryName";
			if (UseWorkingSets == true && Session["Customers/MetaPartnerWorkingSet"] != null)
			{
				BLL.SortableList<BLL.Customers.MetaPartner> sessionSource = (BLL.SortableList<BLL.Customers.MetaPartner>) Session["Customers/MetaPartnerWorkingSet"];
				BLL.SortableList<BLL.Customers.MetaPartner> currentSource = new BLL.SortableList<BLL.Customers.MetaPartner>(sessionSource, true);
				if (MOD.Data.DataHelper.GetGuid(vParticipatingPartner.MetaPartnerID, MOD.Data.DefaultValue.Guid) != MOD.Data.DefaultValue.Guid)
				{
					BLL.Customers.MetaPartner currentMetaPartner = BLL.Customers.MetaPartnerManager.GetOneMetaPartner(MOD.Data.DataHelper.GetGuid(vParticipatingPartner.MetaPartnerID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions("", "", true, true));
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
				sMetaPartner.MetaPartnerID = MOD.Data.DataHelper.GetGuid(vParticipatingPartner.MetaPartnerID, MOD.Data.DefaultValue.Guid);
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
			// Drop downs should be disabled when control is "Internal" and either value is constrained by container
			if (WorkflowMode == WorkflowMode.Internal)
			{
				ddlAccountID.Visible = Request.QueryString["AccountID"] == null;
				lnkAccountIDWorkingSet.Visible = lnkAccountIDWorkingSet.Visible == true && Request.QueryString["AccountID"] == null;
				lblAccountIDWorkingSet.Visible = lblAccountIDWorkingSet.Visible == true && Request.QueryString["AccountID"] == null;
				valAccountID.Enabled = Request.QueryString["AccountID"] == null;
				lblAccountIDDisplay.Visible = Request.QueryString["AccountID"] == null;
				ddlMetaPartnerID.Visible = Request.QueryString["MetaPartnerID"] == null;
				lnkMetaPartnerIDWorkingSet.Visible = lnkMetaPartnerIDWorkingSet.Visible == true && Request.QueryString["MetaPartnerID"] == null;
				lblMetaPartnerIDWorkingSet.Visible = lblMetaPartnerIDWorkingSet.Visible == true && Request.QueryString["MetaPartnerID"] == null;
				valMetaPartnerID.Enabled = Request.QueryString["MetaPartnerID"] == null;
				lblMetaPartnerIDDisplay.Visible = Request.QueryString["MetaPartnerID"] == null;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set Participating Partner information from the form.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyFormToEntity()
		{
			BLL.Accounts.ParticipatingPartner vParticipatingPartner = ParticipatingPartnerItem;
			if (vParticipatingPartner == null)
			{
				throw CoreUtility.CustomAppException.WrapException(new Exception("Participating Partner not found"), "EditParticipatingPartner.CopyFormToEntity()");
			}
			if (ddlAccountID.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Accounts.FundAccount sFundAccount = new BLL.Accounts.FundAccount(ddlAccountID.SelectedValue, false);
				vParticipatingPartner.AccountID = MOD.Data.DataHelper.GetGuid(sFundAccount.AccountID, MOD.Data.DefaultValue.Guid);
				sFundAccount = null;
			}
			if (ddlMetaPartnerID.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Customers.MetaPartner sMetaPartner = new BLL.Customers.MetaPartner(ddlMetaPartnerID.SelectedValue, false);
				vParticipatingPartner.MetaPartnerID = MOD.Data.DataHelper.GetGuid(sMetaPartner.MetaPartnerID, MOD.Data.DefaultValue.Guid);
				sMetaPartner = null;
				vParticipatingPartner.PrimaryName += MOD.Data.DataHelper.GetString(ddlMetaPartnerID.SelectedItem.Text, MOD.Data.DefaultValue.String) + ";";
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// Load entity from database, store in _entity and Session["ParticipatingPartnerItem"]
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void LoadEntity()
		{
			_entity = null;
			Guid accountID = MOD.Data.DataHelper.GetGuid(Request.QueryString["AccountID"], MOD.Data.DefaultValue.Guid);
			Guid metaPartnerID = MOD.Data.DataHelper.GetGuid(Request.QueryString["MetaPartnerID"], MOD.Data.DefaultValue.Guid);
			if (accountID != MOD.Data.DefaultValue.Guid && metaPartnerID != MOD.Data.DefaultValue.Guid)
			{
				_entity = BLL.Accounts.ParticipatingPartnerManager.GetOneParticipatingPartner(accountID, metaPartnerID, Globals.getDataOptions("", "", true, true));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update Participating Partner information in the database.</summary>
		///
		// ------------------------------------------------------------------------------
		private void UpsertToDatabase(bool performCascade)
		{
			BLL.Accounts.ParticipatingPartner vParticipatingPartner = ParticipatingPartnerItem;
			if (AccessMode == MOD.Data.AccessMode.Add)
			{
				BLL.Accounts.ParticipatingPartnerManager.AddOneParticipatingPartner(vParticipatingPartner, performCascade);
			}
			else if (AccessMode == MOD.Data.AccessMode.Edit)
			{
				BLL.Accounts.ParticipatingPartnerManager.UpdateOneParticipatingPartner(vParticipatingPartner, performCascade);
			}
			ParticipatingPartnerItem.AccountID = vParticipatingPartner.AccountID;
			ParticipatingPartnerItem.MetaPartnerID = vParticipatingPartner.MetaPartnerID;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set access and display modes for presenting Participating Partner information.</summary>
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
					lblTitle.Text = "Add Participating&nbsp;Partner";
					btnSave.Text = "Add";
					break;
				case MOD.Data.AccessMode.Edit:
					lblTitle.Text = "Edit Participating&nbsp;Partner";
					btnSave.Text = "Save";
					break;
				case MOD.Data.AccessMode.View:
					lblTitle.Text = "View Participating&nbsp;Partner";
					break;
				default:
					lblTitle.Text = "View Participating&nbsp;Partner";
					break;
			}
			btnDelete.Visible = IsDeleteAvailable;
			btnNew.Visible = IsEditAvailable;
			btnSave.Visible = IsEditAvailable || IsAddAvailable;
			ddlAccountID.Enabled = IsAddAvailable;
			ddlMetaPartnerID.Enabled = IsAddAvailable;
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
		/// <summary>Initialize component for ParticipatingPartner, add delegates here.</summary>
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