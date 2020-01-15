
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
	/// <summary>Edit Stored Value Account is used to help manage StoredValueAccount information.</summary>
	///
	/// File History:
	/// <created>6/1/2007 (Chris Grundy)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class EditStoredValueAccount  : Components.Desktop.BaseFormlUserControl
	{
		#region Events
		/// <summary>
		/// Raised when "Add" button is clicked in internal mode.
		/// Container handles this event and adds entity to collection.
		/// </summary>
		public event EntityEditEventHandler StoredValueAccountAdded;
		/// <summary>
		/// Raised when "Remove" button is clicked in internal mode.
		/// Container handles this event and removes entity from collection.
		/// </summary>
		public event EntityEditEventHandler StoredValueAccountRemoved;
		#endregion Events
		#region Declarations
		#endregion Declarations
		#region Properties
		/// <summary>
		/// The StoredValueAccount currently being edited by this control.
		/// Get accessor casts base._entity to StoredValueAccount
		/// Set accessor used by parent control to set the item currently being edited
		/// </summary>
		public BLL.Accounts.StoredValueAccount StoredValueAccountItem
		{
			get
			{
				return (BLL.Accounts.StoredValueAccount) _entity;
			}
			set
			{
				_entity = value; // only set by container
				Session["StoredValueAccountItem"] = _entity;
			}
		}
		#endregion Properties
		#region Event Handlers
		// ------------------------------------------------------------------------------
		/// <summary>Load page for editing Stored Value Account, getting mode and parameters.</summary>
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
						_entity = (BLL.Accounts.StoredValueAccount)Session["StoredValueAccountItem"];
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
					Session["StoredValueAccountItem"] = _entity;
				}
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditStoredValueAccount.Page_Load"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Delete Stored Value Account.</summary>
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
					BLL.Accounts.StoredValueAccountManager.DeleteOneStoredValueAccount(StoredValueAccountItem, performCascade);
					Globals.AddStatusMessage("Stored Value Account deleted.");
				}
				else
				{
					// raise event so item is removed from collection
					if (StoredValueAccountRemoved != null)
					{
						StoredValueAccountRemoved(this, new EntityEditEventArgs(_entity));
					}
				}
				// create new object and store it in _entity
				CreateNewEntity();
				Session["StoredValueAccountItem"] = _entity;
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditStoredValueAccount.btnDelete_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("AccountID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("StoredValueAccountAccountID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Request to create a new Stored Value Account.</summary>
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
				Session["StoredValueAccountItem"] = _entity;
				this.sectionLinks.OnSection("Basics");
				SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
				Globals.AddStatusMessage("Add new Stored Value Account.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				doRedirect = false;
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				doRedirect = false;
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditStoredValueAccount.btnNew_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("AccountID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("StoredValueAccountAccountID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Reset form for Stored Value Account.</summary>
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
					Session["StoredValueAccountItem"] = _entity;
					sectionLinks.CurrentSection = "Basics";
				}
				else
				{
					CreateNewEntity();
				}
				Globals.AddStatusMessage("Stored Value Account reset.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditStoredValueAccount.btnReset_Click"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Save Stored Value Account.</summary>
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
							if (StoredValueAccountAdded != null && (StoredValueAccountItem.AccountID != MOD.Data.DefaultValue.Guid || StoredValueAccountItem.CreatedByUserID != MOD.Data.DefaultValue.Guid || StoredValueAccountItem.CreatedDate != MOD.Data.DefaultValue.DateTime || StoredValueAccountItem.LastModifiedByUserID != MOD.Data.DefaultValue.Guid || StoredValueAccountItem.LastModifiedDate != MOD.Data.DefaultValue.DateTime || StoredValueAccountItem.Timestamp != null || StoredValueAccountItem.Balance != MOD.Data.DefaultValue.Decimal || StoredValueAccountItem.MetaPartnerPhoneID != MOD.Data.DefaultValue.Guid))
							{
								StoredValueAccountAdded(this, new EntityEditEventArgs(_entity));
								// create new object and store it in _entity
								CreateNewEntity();
								Session["StoredValueAccountItem"] = _entity;
								this.sectionLinks.OnSection("Basics");
								SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
							}
						}
						else
						{
							Globals.AddStatusMessage("Stored Value Account updated.");
						}
					}
					else
					{
						UpsertToDatabase(true);
						if (AccessMode == MOD.Data.AccessMode.Add)
						{
							doRedirect = true;
							Globals.AddStatusMessage("Stored Value Account added.");
						}
						else
						{
							Globals.AddStatusMessage("Stored Value Account updated.");
						}
						SetAccessModeAndDisplay(MOD.Data.AccessMode.Edit);
					}
				}
				else
				{
					Globals.AddErrorMessage(Page, "Stored Value Account validation failed.");
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditStoredValueAccount.btnSave_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && isValid == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("AccountID", StoredValueAccountItem.AccountID.ToString());
				queryString.Add("StoredValueAccountAccountID", StoredValueAccountItem.AccountID.ToString());
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditStoredValueAccount.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditStoredValueAccount.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditStoredValueAccount.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditStoredValueAccount.Page_PreRender"));
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
		/// Create a new Stored Value Account object reference
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void CreateNewEntity()
		{
			BLL.Accounts.StoredValueAccount vStoredValueAccount = new BLL.Accounts.StoredValueAccount();
			vStoredValueAccount.MetaPartnerPhoneID = MOD.Data.DataHelper.GetGuid(Request.QueryString["MetaPartnerPhoneID"], MOD.Data.DefaultValue.Guid);
			_entity = vStoredValueAccount;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update form from Stored Value Account information.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyEntityToForm()
		{
			BLL.Accounts.StoredValueAccount vStoredValueAccount = StoredValueAccountItem;
			lblAccountID.Text = MOD.Data.DataHelper.GetString(vStoredValueAccount.AccountID, "");
			ddlMetaPartnerPhoneID.DataValueField = "PrimaryIndex";
			ddlMetaPartnerPhoneID.DataTextField = "PrimaryName";
			if (UseWorkingSets == true && Session["Customers/MetaPartnerPhoneWorkingSet"] != null)
			{
				BLL.SortableList<BLL.Customers.MetaPartnerPhone> sessionSource = (BLL.SortableList<BLL.Customers.MetaPartnerPhone>) Session["Customers/MetaPartnerPhoneWorkingSet"];
				BLL.SortableList<BLL.Customers.MetaPartnerPhone> currentSource = new BLL.SortableList<BLL.Customers.MetaPartnerPhone>(sessionSource, true);
				if (MOD.Data.DataHelper.GetGuid(vStoredValueAccount.MetaPartnerPhoneID, MOD.Data.DefaultValue.Guid) != MOD.Data.DefaultValue.Guid)
				{
					BLL.Customers.MetaPartnerPhone currentMetaPartnerPhone = BLL.Customers.MetaPartnerPhoneManager.GetOneMetaPartnerPhone(MOD.Data.DataHelper.GetGuid(vStoredValueAccount.MetaPartnerPhoneID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions("", "", true, true));
					if (currentMetaPartnerPhone != null && currentSource.Contains(currentMetaPartnerPhone) == false)
					{
						currentSource.Insert(0, currentMetaPartnerPhone);
					}
				}
				ddlMetaPartnerPhoneID.DataSource = currentSource;
				lnkMetaPartnerPhoneIDWorkingSet.Visible = true;
				lnkMetaPartnerPhoneIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Customers/SearchMetaPartnerPhoneData.aspx");
				lblMetaPartnerPhoneIDWorkingSet.Visible = true;
				lblMetaPartnerPhoneIDWorkingSet.Text = " (from Meta Partner Phone working set)";
			}
			else
			{
				ddlMetaPartnerPhoneID.DataSource = BLL.Customers.MetaPartnerPhoneManager.GetAllMetaPartnerPhoneData(Globals.DBOptions, Globals.getDataOptions("DisplayName", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
				lblMetaPartnerPhoneIDWorkingSet.Visible = false;
				if (UseWorkingSets == true)
				{
					lnkMetaPartnerPhoneIDWorkingSet.Visible = true;
					lnkMetaPartnerPhoneIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Customers/SearchMetaPartnerPhoneData.aspx");
				}
				else
				{
					lnkMetaPartnerPhoneIDWorkingSet.Visible = false;
				}
			}
			ddlMetaPartnerPhoneID.DataBind();
			ddlMetaPartnerPhoneID.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				BLL.Customers.MetaPartnerPhone sMetaPartnerPhone = new BLL.Customers.MetaPartnerPhone();
				sMetaPartnerPhone.MetaPartnerPhoneID = MOD.Data.DataHelper.GetGuid(vStoredValueAccount.MetaPartnerPhoneID, MOD.Data.DefaultValue.Guid);
				ddlMetaPartnerPhoneID.SelectedValue = MOD.Data.DataHelper.GetString(sMetaPartnerPhone.PrimaryIndex, "");
				sMetaPartnerPhone = null;
			}
			catch {}
			if(ddlMetaPartnerPhoneID.SelectedValue == ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				try
				{
					ddlMetaPartnerPhoneID.SelectedValue = MOD.Data.DataHelper.GetString(Session["Customers/MetaPartnerPhoneWorkingSetItem"], "");
				}
				catch {}
			}
			txtDebitAccountNumber.Text = MOD.Data.EditHelper.GetString(vStoredValueAccount.DebitAccountNumber);
			chkIsDefaultDebitAccount.Checked = MOD.Data.DataHelper.GetBool(vStoredValueAccount.IsDefaultDebitAccount, MOD.Data.DefaultValue.Bool);
			txtBankCustomerCode.Text = MOD.Data.EditHelper.GetString(vStoredValueAccount.BankCustomerCode);
			ddlMetaPartnerID.DataValueField = "PrimaryIndex";
			ddlMetaPartnerID.DataTextField = "PrimaryName";
			if (UseWorkingSets == true && Session["Customers/MetaPartnerWorkingSet"] != null)
			{
				BLL.SortableList<BLL.Customers.MetaPartner> sessionSource = (BLL.SortableList<BLL.Customers.MetaPartner>) Session["Customers/MetaPartnerWorkingSet"];
				BLL.SortableList<BLL.Customers.MetaPartner> currentSource = new BLL.SortableList<BLL.Customers.MetaPartner>(sessionSource, true);
				if (MOD.Data.DataHelper.GetGuid(vStoredValueAccount.MetaPartnerID, MOD.Data.DefaultValue.Guid) != MOD.Data.DefaultValue.Guid)
				{
					BLL.Customers.MetaPartner currentMetaPartner = BLL.Customers.MetaPartnerManager.GetOneMetaPartner(MOD.Data.DataHelper.GetGuid(vStoredValueAccount.MetaPartnerID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions("", "", true, true));
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
				sMetaPartner.MetaPartnerID = MOD.Data.DataHelper.GetGuid(vStoredValueAccount.MetaPartnerID, MOD.Data.DefaultValue.Guid);
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
			txtAccountName.Text = MOD.Data.EditHelper.GetString(vStoredValueAccount.AccountName);
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
					ddlAccountSubTypeCode.SelectedValue = ddlAccountSubTypeCode.Items.FindByText("StoredValueAccount").Value;
				}
				else
				{
					ddlAccountSubTypeCode.SelectedValue = MOD.Data.DataHelper.GetString(vStoredValueAccount.AccountSubTypeCode, "");
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
				sCurrency.CurrencyCode = MOD.Data.DataHelper.GetInt(vStoredValueAccount.CurrencyCode, MOD.Data.DefaultValue.Int);
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
			txtDescription.Text = MOD.Data.EditHelper.GetString(vStoredValueAccount.Description);
			chkIsActive.Checked = MOD.Data.DataHelper.GetBool(vStoredValueAccount.IsActive, MOD.Data.DefaultValue.Bool);
			// Drop downs should be disabled when control is "Internal" and either value is constrained by container
			if (WorkflowMode == WorkflowMode.Internal)
			{
				ddlMetaPartnerPhoneID.Visible = Request.QueryString["MetaPartnerPhoneID"] == null;
				lnkMetaPartnerPhoneIDWorkingSet.Visible = lnkMetaPartnerPhoneIDWorkingSet.Visible == true && Request.QueryString["MetaPartnerPhoneID"] == null;
				lblMetaPartnerPhoneIDWorkingSet.Visible = lblMetaPartnerPhoneIDWorkingSet.Visible == true && Request.QueryString["MetaPartnerPhoneID"] == null;
				valMetaPartnerPhoneID.Enabled = Request.QueryString["MetaPartnerPhoneID"] == null;
				lblMetaPartnerPhoneIDDisplay.Visible = Request.QueryString["MetaPartnerPhoneID"] == null;
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
		/// <summary>Set Stored Value Account information from the form.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyFormToEntity()
		{
			BLL.Accounts.StoredValueAccount vStoredValueAccount = StoredValueAccountItem;
			if (vStoredValueAccount == null)
			{
				throw CoreUtility.CustomAppException.WrapException(new Exception("Stored Value Account not found"), "EditStoredValueAccount.CopyFormToEntity()");
			}
			if (ddlMetaPartnerPhoneID.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Customers.MetaPartnerPhone sMetaPartnerPhone = new BLL.Customers.MetaPartnerPhone(ddlMetaPartnerPhoneID.SelectedValue, false);
				vStoredValueAccount.MetaPartnerPhoneID = MOD.Data.DataHelper.GetGuid(sMetaPartnerPhone.MetaPartnerPhoneID, MOD.Data.DefaultValue.Guid);
				sMetaPartnerPhone = null;
			}
			vStoredValueAccount.DebitAccountNumber = EditHelper.EncodeStringForDB(MOD.Data.DataHelper.GetString(txtDebitAccountNumber.Text, null));
			vStoredValueAccount.IsDefaultDebitAccount = chkIsDefaultDebitAccount.Checked;
			vStoredValueAccount.BankCustomerCode = EditHelper.EncodeStringForDB(MOD.Data.DataHelper.GetString(txtBankCustomerCode.Text, null));
			if (ddlMetaPartnerID.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Customers.MetaPartner sMetaPartner = new BLL.Customers.MetaPartner(ddlMetaPartnerID.SelectedValue, false);
				vStoredValueAccount.MetaPartnerID = MOD.Data.DataHelper.GetGuid(sMetaPartner.MetaPartnerID, MOD.Data.DefaultValue.Guid);
				sMetaPartner = null;
			}
			vStoredValueAccount.AccountName = EditHelper.EncodeStringForDB(MOD.Data.DataHelper.GetString(txtAccountName.Text, null));
			if (ddlAccountSubTypeCode.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Accounts.AccountSubType sAccountSubType = new BLL.Accounts.AccountSubType(ddlAccountSubTypeCode.SelectedValue, false);
				vStoredValueAccount.AccountSubTypeCode = MOD.Data.DataHelper.GetInt(sAccountSubType.AccountSubTypeCode, MOD.Data.DefaultValue.Int);
				sAccountSubType = null;
			}
			if (ddlCurrencyCode.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Accounts.Currency sCurrency = new BLL.Accounts.Currency(ddlCurrencyCode.SelectedValue, false);
				vStoredValueAccount.CurrencyCode = MOD.Data.DataHelper.GetInt(sCurrency.CurrencyCode, MOD.Data.DefaultValue.Int);
				sCurrency = null;
			}
			vStoredValueAccount.Description = EditHelper.EncodeStringForDB(MOD.Data.DataHelper.GetString(txtDescription.Text, null));
			vStoredValueAccount.IsActive = chkIsActive.Checked;
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// Load entity from database, store in _entity and Session["StoredValueAccountItem"]
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void LoadEntity()
		{
			_entity = null;
			Guid accountID = MOD.Data.DataHelper.GetGuid(Request.QueryString["AccountID"], MOD.Data.DefaultValue.Guid);
			if (accountID != MOD.Data.DefaultValue.Guid)
			{
				_entity = BLL.Accounts.StoredValueAccountManager.GetOneStoredValueAccount(accountID, Globals.getDataOptions("", "", true, true));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update Stored Value Account information in the database.</summary>
		///
		// ------------------------------------------------------------------------------
		private void UpsertToDatabase(bool performCascade)
		{
			BLL.Accounts.StoredValueAccount vStoredValueAccount = StoredValueAccountItem;
			if (AccessMode == MOD.Data.AccessMode.Add)
			{
				BLL.Accounts.StoredValueAccountManager.AddOneStoredValueAccount(vStoredValueAccount, performCascade);
			}
			else if (AccessMode == MOD.Data.AccessMode.Edit)
			{
				BLL.Accounts.StoredValueAccountManager.UpdateOneStoredValueAccount(vStoredValueAccount, performCascade);
			}
			StoredValueAccountItem.AccountID = vStoredValueAccount.AccountID;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set access and display modes for presenting Stored Value Account information.</summary>
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
					lblTitle.Text = "Add Stored&nbsp;Value&nbsp;Account";
					btnSave.Text = "Add";
					break;
				case MOD.Data.AccessMode.Edit:
					lblTitle.Text = "Edit Stored&nbsp;Value&nbsp;Account";
					btnSave.Text = "Save";
					break;
				case MOD.Data.AccessMode.View:
					lblTitle.Text = "View Stored&nbsp;Value&nbsp;Account";
					break;
				default:
					lblTitle.Text = "View Stored&nbsp;Value&nbsp;Account";
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
		/// <summary>Initialize component for StoredValueAccount, add delegates here.</summary>
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