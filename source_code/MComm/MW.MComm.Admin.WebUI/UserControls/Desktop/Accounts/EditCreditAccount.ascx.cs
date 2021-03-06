
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
	/// <summary>Edit Credit Account is used to help manage CreditAccount information.</summary>
	///
	/// File History:
	/// <created>6/1/2007 (Chris Grundy)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class EditCreditAccount  : Components.Desktop.BaseFormlUserControl
	{
		#region Events
		/// <summary>
		/// Raised when "Add" button is clicked in internal mode.
		/// Container handles this event and adds entity to collection.
		/// </summary>
		public event EntityEditEventHandler CreditAccountAdded;
		/// <summary>
		/// Raised when "Remove" button is clicked in internal mode.
		/// Container handles this event and removes entity from collection.
		/// </summary>
		public event EntityEditEventHandler CreditAccountRemoved;
		#endregion Events
		#region Declarations
		#endregion Declarations
		#region Properties
		/// <summary>
		/// The CreditAccount currently being edited by this control.
		/// Get accessor casts base._entity to CreditAccount
		/// Set accessor used by parent control to set the item currently being edited
		/// </summary>
		public BLL.Accounts.CreditAccount CreditAccountItem
		{
			get
			{
				return (BLL.Accounts.CreditAccount) _entity;
			}
			set
			{
				_entity = value; // only set by container
				Session["CreditAccountItem"] = _entity;
			}
		}
		#endregion Properties
		#region Event Handlers
		// ------------------------------------------------------------------------------
		/// <summary>Load page for editing Credit Account, getting mode and parameters.</summary>
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
						_entity = (BLL.Accounts.CreditAccount)Session["CreditAccountItem"];
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
					Session["CreditAccountItem"] = _entity;
				}
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditCreditAccount.Page_Load"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Delete Credit Account.</summary>
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
					BLL.Accounts.CreditAccountManager.DeleteOneCreditAccount(CreditAccountItem, performCascade);
					Globals.AddStatusMessage("Credit Account deleted.");
				}
				else
				{
					// raise event so item is removed from collection
					if (CreditAccountRemoved != null)
					{
						CreditAccountRemoved(this, new EntityEditEventArgs(_entity));
					}
				}
				// create new object and store it in _entity
				CreateNewEntity();
				Session["CreditAccountItem"] = _entity;
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditCreditAccount.btnDelete_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("AccountID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("CreditAccountAccountID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Request to create a new Credit Account.</summary>
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
				Session["CreditAccountItem"] = _entity;
				this.sectionLinks.OnSection("Basics");
				SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
				Globals.AddStatusMessage("Add new Credit Account.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				doRedirect = false;
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				doRedirect = false;
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditCreditAccount.btnNew_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("AccountID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("CreditAccountAccountID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Reset form for Credit Account.</summary>
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
					Session["CreditAccountItem"] = _entity;
					sectionLinks.CurrentSection = "Basics";
				}
				else
				{
					CreateNewEntity();
				}
				Globals.AddStatusMessage("Credit Account reset.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditCreditAccount.btnReset_Click"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Save Credit Account.</summary>
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
							if (CreditAccountAdded != null && (CreditAccountItem.AccountID != MOD.Data.DefaultValue.Guid || CreditAccountItem.CreditCardNumber != MOD.Data.DefaultValue.String || CreditAccountItem.CreditCardLastFour != MOD.Data.DefaultValue.String || CreditAccountItem.CreditCardName != MOD.Data.DefaultValue.String || CreditAccountItem.ExpirationDate != MOD.Data.DefaultValue.DateTime || CreditAccountItem.CreditCardTypeCode != MOD.Data.DefaultValue.Int || CreditAccountItem.CreatedByUserID != MOD.Data.DefaultValue.Guid || CreditAccountItem.CreatedDate != MOD.Data.DefaultValue.DateTime || CreditAccountItem.LastModifiedByUserID != MOD.Data.DefaultValue.Guid || CreditAccountItem.LastModifiedDate != MOD.Data.DefaultValue.DateTime || CreditAccountItem.Timestamp != null))
							{
								CreditAccountAdded(this, new EntityEditEventArgs(_entity));
								// create new object and store it in _entity
								CreateNewEntity();
								Session["CreditAccountItem"] = _entity;
								this.sectionLinks.OnSection("Basics");
								SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
							}
						}
						else
						{
							Globals.AddStatusMessage("Credit Account updated.");
						}
					}
					else
					{
						UpsertToDatabase(true);
						if (AccessMode == MOD.Data.AccessMode.Add)
						{
							doRedirect = true;
							Globals.AddStatusMessage("Credit Account added.");
						}
						else
						{
							Globals.AddStatusMessage("Credit Account updated.");
						}
						SetAccessModeAndDisplay(MOD.Data.AccessMode.Edit);
					}
				}
				else
				{
					Globals.AddErrorMessage(Page, "Credit Account validation failed.");
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditCreditAccount.btnSave_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && isValid == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("AccountID", CreditAccountItem.AccountID.ToString());
				queryString.Add("CreditAccountAccountID", CreditAccountItem.AccountID.ToString());
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditCreditAccount.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditCreditAccount.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditCreditAccount.btnBasics_Click"));
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
				ResetExpirationDateCalendar(Page.IsPostBack == false);
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditCreditAccount.Page_PreRender"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// Handle Expiration Date selection change.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		// ------------------------------------------------------------------------------
		private void calExpirationDate_SelectionChanged(object sender, EventArgs e)
		{
			txtExpirationDate.Text = calExpirationDate.SelectedDate.ToShortDateString();
			CreditAccountItem.ExpirationDate = calExpirationDate.SelectedDate;
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// HandleExpiration Datescheduler.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		// ------------------------------------------------------------------------------
		private void btnExpirationDateCalendar_Click(object sender, EventArgs e)
		{
			if (calExpirationDate.Visible == false)
			{
				calExpirationDate.Visible = true;
				btnExpirationDateCalendar.Text = "Hide Calendar";
				ResetExpirationDateCalendar(true);
			}
			else
			{
				calExpirationDate.Visible = false;
				btnExpirationDateCalendar.Text = "Calendar";
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
		/// Create a new Credit Account object reference
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void CreateNewEntity()
		{
			BLL.Accounts.CreditAccount vCreditAccount = new BLL.Accounts.CreditAccount();
			vCreditAccount.CreditCardTypeCode = MOD.Data.DataHelper.GetInt(Request.QueryString["CreditCardTypeCode"], MOD.Data.DefaultValue.Int);
			_entity = vCreditAccount;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update form from Credit Account information.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyEntityToForm()
		{
			BLL.Accounts.CreditAccount vCreditAccount = CreditAccountItem;
			lblAccountID.Text = MOD.Data.DataHelper.GetString(vCreditAccount.AccountID, "");
			txtCreditCardNumber.Text = MOD.Data.EditHelper.GetString(vCreditAccount.CreditCardNumber);
			txtCreditCardLastFour.Text = MOD.Data.EditHelper.GetString(vCreditAccount.CreditCardLastFour);
			txtCreditCardName.Text = MOD.Data.EditHelper.GetString(vCreditAccount.CreditCardName);
			txtExpirationDate.Text = MOD.Data.EditHelper.GetDate(vCreditAccount.ExpirationDate);
			ddlCreditCardTypeCode.DataValueField = "PrimaryIndex";
			ddlCreditCardTypeCode.DataTextField = "PrimaryName";
			ddlCreditCardTypeCode.DataSource = BLL.Accounts.CreditCardTypeManager.GetAllCreditCardTypeData(Globals.DBOptions, Globals.getDataOptions("CreditCardTypeName", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
			ddlCreditCardTypeCode.DataBind();
			ddlCreditCardTypeCode.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				BLL.Accounts.CreditCardType sCreditCardType = new BLL.Accounts.CreditCardType();
				sCreditCardType.CreditCardTypeCode = MOD.Data.DataHelper.GetInt(vCreditAccount.CreditCardTypeCode, MOD.Data.DefaultValue.Int);
				ddlCreditCardTypeCode.SelectedValue = MOD.Data.DataHelper.GetString(sCreditCardType.PrimaryIndex, "");
				sCreditCardType = null;
			}
			catch {}
			if(ddlCreditCardTypeCode.SelectedValue == ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				try
				{
					ddlCreditCardTypeCode.SelectedValue = MOD.Data.DataHelper.GetString(Session["Accounts/CreditCardTypeWorkingSetItem"], "");
				}
				catch {}
			}
			ddlMetaPartnerID.DataValueField = "PrimaryIndex";
			ddlMetaPartnerID.DataTextField = "PrimaryName";
			if (UseWorkingSets == true && Session["Customers/MetaPartnerWorkingSet"] != null)
			{
				BLL.SortableList<BLL.Customers.MetaPartner> sessionSource = (BLL.SortableList<BLL.Customers.MetaPartner>) Session["Customers/MetaPartnerWorkingSet"];
				BLL.SortableList<BLL.Customers.MetaPartner> currentSource = new BLL.SortableList<BLL.Customers.MetaPartner>(sessionSource, true);
				if (MOD.Data.DataHelper.GetGuid(vCreditAccount.MetaPartnerID, MOD.Data.DefaultValue.Guid) != MOD.Data.DefaultValue.Guid)
				{
					BLL.Customers.MetaPartner currentMetaPartner = BLL.Customers.MetaPartnerManager.GetOneMetaPartner(MOD.Data.DataHelper.GetGuid(vCreditAccount.MetaPartnerID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions("", "", true, true));
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
				sMetaPartner.MetaPartnerID = MOD.Data.DataHelper.GetGuid(vCreditAccount.MetaPartnerID, MOD.Data.DefaultValue.Guid);
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
			txtAccountName.Text = MOD.Data.EditHelper.GetString(vCreditAccount.AccountName);
			ddlAccountSubTypeCode.DataValueField = "PrimaryIndex";
			ddlAccountSubTypeCode.DataTextField = "PrimaryName";
			ddlAccountSubTypeCode.DataSource = BLL.Accounts.AccountSubTypeManager.GetAllAccountSubTypeData(Globals.DBOptions, Globals.getDataOptions("AccountSubTypeName", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
			ddlAccountSubTypeCode.DataBind();
			ddlAccountSubTypeCode.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			ddlAccountSubTypeCode.Enabled = false;
			try
			{
				if (AccessMode == MOD.Data.AccessMode.Add)
				{
					ddlAccountSubTypeCode.SelectedValue = ddlAccountSubTypeCode.Items.FindByText("CreditAccount").Value;
				}
				else
				{
					ddlAccountSubTypeCode.SelectedValue = MOD.Data.DataHelper.GetString(vCreditAccount.AccountSubTypeCode, "");
				}
			}
			catch {}
			ddlCurrencyCode.DataValueField = "PrimaryIndex";
			ddlCurrencyCode.DataTextField = "PrimaryName";
			ddlCurrencyCode.DataSource = BLL.Accounts.CurrencyManager.GetAllCurrencyData(Globals.DBOptions, Globals.getDataOptions("CurrencyName", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
			ddlCurrencyCode.DataBind();
			ddlCurrencyCode.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				BLL.Accounts.Currency sCurrency = new BLL.Accounts.Currency();
				sCurrency.CurrencyCode = MOD.Data.DataHelper.GetInt(vCreditAccount.CurrencyCode, MOD.Data.DefaultValue.Int);
				ddlCurrencyCode.SelectedValue = MOD.Data.DataHelper.GetString(sCurrency.PrimaryIndex, "");
				sCurrency = null;
			}
			catch {}
			if(ddlCurrencyCode.SelectedValue == ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				try
				{
					ddlCurrencyCode.SelectedValue = MOD.Data.DataHelper.GetString(Session["Accounts/CurrencyWorkingSetItem"], "");
				}
				catch {}
			}
			txtDescription.Text = MOD.Data.EditHelper.GetString(vCreditAccount.Description);
			chkIsActive.Checked = MOD.Data.DataHelper.GetBool(vCreditAccount.IsActive, MOD.Data.DefaultValue.Bool);
			// Drop downs should be disabled when control is "Internal" and either value is constrained by container
			if (WorkflowMode == WorkflowMode.Internal)
			{
				ddlCreditCardTypeCode.Visible = Request.QueryString["CreditCardTypeCode"] == null;
				valCreditCardTypeCode.Enabled = Request.QueryString["CreditCardTypeCode"] == null;
				lblCreditCardTypeCodeDisplay.Visible = Request.QueryString["CreditCardTypeCode"] == null;
				ddlMetaPartnerID.Visible = Request.QueryString["MetaPartnerID"] == null;
				lnkMetaPartnerIDWorkingSet.Visible = lnkMetaPartnerIDWorkingSet.Visible == true && Request.QueryString["MetaPartnerID"] == null;
				lblMetaPartnerIDWorkingSet.Visible = lblMetaPartnerIDWorkingSet.Visible == true && Request.QueryString["MetaPartnerID"] == null;
				valMetaPartnerID.Enabled = Request.QueryString["MetaPartnerID"] == null;
				lblMetaPartnerIDDisplay.Visible = Request.QueryString["MetaPartnerID"] == null;
				ddlAccountSubTypeCode.Visible = Request.QueryString["AccountSubTypeCode"] == null;
				valAccountSubTypeCode.Enabled = Request.QueryString["AccountSubTypeCode"] == null;
				lblAccountSubTypeCodeDisplay.Visible = Request.QueryString["AccountSubTypeCode"] == null;
				ddlCurrencyCode.Visible = Request.QueryString["CurrencyCode"] == null;
				valCurrencyCode.Enabled = Request.QueryString["CurrencyCode"] == null;
				lblCurrencyCodeDisplay.Visible = Request.QueryString["CurrencyCode"] == null;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set Credit Account information from the form.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyFormToEntity()
		{
			BLL.Accounts.CreditAccount vCreditAccount = CreditAccountItem;
			if (vCreditAccount == null)
			{
				throw CoreUtility.CustomAppException.WrapException(new Exception("Credit Account not found"), "EditCreditAccount.CopyFormToEntity()");
			}
			vCreditAccount.CreditCardNumber = EditHelper.EncodeStringForDB(MOD.Data.DataHelper.GetString(txtCreditCardNumber.Text, null));
			vCreditAccount.CreditCardLastFour = EditHelper.EncodeStringForDB(MOD.Data.DataHelper.GetString(txtCreditCardLastFour.Text, null));
			vCreditAccount.CreditCardName = EditHelper.EncodeStringForDB(MOD.Data.DataHelper.GetString(txtCreditCardName.Text, null));
			try
			{
				vCreditAccount.ExpirationDate = MOD.Data.DataHelper.GetNullableDateTime(txtExpirationDate.Text);
			}
			catch {}
			if (ddlCreditCardTypeCode.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Accounts.CreditCardType sCreditCardType = new BLL.Accounts.CreditCardType(ddlCreditCardTypeCode.SelectedValue, false);
				vCreditAccount.CreditCardTypeCode = MOD.Data.DataHelper.GetInt(sCreditCardType.CreditCardTypeCode, MOD.Data.DefaultValue.Int);
				sCreditCardType = null;
				vCreditAccount.PrimaryName += MOD.Data.DataHelper.GetString(ddlCreditCardTypeCode.SelectedItem.Text, MOD.Data.DefaultValue.String) + ";";
			}
			if (ddlMetaPartnerID.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Customers.MetaPartner sMetaPartner = new BLL.Customers.MetaPartner(ddlMetaPartnerID.SelectedValue, false);
				vCreditAccount.MetaPartnerID = MOD.Data.DataHelper.GetGuid(sMetaPartner.MetaPartnerID, MOD.Data.DefaultValue.Guid);
				sMetaPartner = null;
			}
			vCreditAccount.AccountName = EditHelper.EncodeStringForDB(MOD.Data.DataHelper.GetString(txtAccountName.Text, null));
			if (ddlAccountSubTypeCode.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Accounts.AccountSubType sAccountSubType = new BLL.Accounts.AccountSubType(ddlAccountSubTypeCode.SelectedValue, false);
				vCreditAccount.AccountSubTypeCode = MOD.Data.DataHelper.GetInt(sAccountSubType.AccountSubTypeCode, MOD.Data.DefaultValue.Int);
				sAccountSubType = null;
			}
			if (ddlCurrencyCode.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Accounts.Currency sCurrency = new BLL.Accounts.Currency(ddlCurrencyCode.SelectedValue, false);
				vCreditAccount.CurrencyCode = MOD.Data.DataHelper.GetInt(sCurrency.CurrencyCode, MOD.Data.DefaultValue.Int);
				sCurrency = null;
			}
			vCreditAccount.Description = EditHelper.EncodeStringForDB(MOD.Data.DataHelper.GetString(txtDescription.Text, null));
			vCreditAccount.IsActive = chkIsActive.Checked;
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// Load entity from database, store in _entity and Session["CreditAccountItem"]
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void LoadEntity()
		{
			_entity = null;
			Guid accountID = MOD.Data.DataHelper.GetGuid(Request.QueryString["AccountID"], MOD.Data.DefaultValue.Guid);
			if (accountID != MOD.Data.DefaultValue.Guid)
			{
				_entity = BLL.Accounts.CreditAccountManager.GetOneCreditAccount(accountID, Globals.getDataOptions("", "", true, true));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update Credit Account information in the database.</summary>
		///
		// ------------------------------------------------------------------------------
		private void UpsertToDatabase(bool performCascade)
		{
			BLL.Accounts.CreditAccount vCreditAccount = CreditAccountItem;
			if (AccessMode == MOD.Data.AccessMode.Add)
			{
				BLL.Accounts.CreditAccountManager.AddOneCreditAccount(vCreditAccount, performCascade);
			}
			else if (AccessMode == MOD.Data.AccessMode.Edit)
			{
				BLL.Accounts.CreditAccountManager.UpdateOneCreditAccount(vCreditAccount, performCascade);
			}
			CreditAccountItem.AccountID = vCreditAccount.AccountID;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set access and display modes for presenting Credit Account information.</summary>
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
					lblTitle.Text = "Add Credit&nbsp;Account";
					btnSave.Text = "Add";
					break;
				case MOD.Data.AccessMode.Edit:
					lblTitle.Text = "Edit Credit&nbsp;Account";
					btnSave.Text = "Save";
					break;
				case MOD.Data.AccessMode.View:
					lblTitle.Text = "View Credit&nbsp;Account";
					break;
				default:
					lblTitle.Text = "View Credit&nbsp;Account";
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
		// ------------------------------------------------------------------------------
		/// <summary>
		/// Reset Expiration Date schedule.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		// ------------------------------------------------------------------------------
		private void ResetExpirationDateCalendar(bool resetVisibleDate)
		{
			try
			{
				calExpirationDate.SelectedDates.Clear();
				System.DateTime strExpirationDate = System.DateTime.Parse(txtExpirationDate.Text);
				calExpirationDate.SelectedDate = strExpirationDate;
				if (resetVisibleDate == true)
				{
					calExpirationDate.VisibleDate = strExpirationDate;
				}
			}
			catch
			{
				calExpirationDate.SelectedDates.Clear();
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
		/// <summary>Initialize component for CreditAccount, add delegates here.</summary>
		///
		// ------------------------------------------------------------------------------
		private void InitializeComponent()
		{
			this.calExpirationDate.SelectionChanged += new System.EventHandler(calExpirationDate_SelectionChanged);
			this.btnExpirationDateCalendar.Click += new EventHandler(btnExpirationDateCalendar_Click);
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