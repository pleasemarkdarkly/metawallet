
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
	/// <summary>Edit Bill Pay Account is used to help manage BillPayAccount information.</summary>
	///
	/// File History:
	/// <created>6/1/2007 (Chris Grundy)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class EditBillPayAccount  : Components.Desktop.BaseFormlUserControl
	{
		#region Events
		/// <summary>
		/// Raised when "Add" button is clicked in internal mode.
		/// Container handles this event and adds entity to collection.
		/// </summary>
		public event EntityEditEventHandler BillPayAccountAdded;
		/// <summary>
		/// Raised when "Remove" button is clicked in internal mode.
		/// Container handles this event and removes entity from collection.
		/// </summary>
		public event EntityEditEventHandler BillPayAccountRemoved;
		#endregion Events
		#region Declarations
		#endregion Declarations
		#region Properties
		/// <summary>
		/// The BillPayAccount currently being edited by this control.
		/// Get accessor casts base._entity to BillPayAccount
		/// Set accessor used by parent control to set the item currently being edited
		/// </summary>
		public BLL.Accounts.BillPayAccount BillPayAccountItem
		{
			get
			{
				return (BLL.Accounts.BillPayAccount) _entity;
			}
			set
			{
				_entity = value; // only set by container
				Session["BillPayAccountItem"] = _entity;
			}
		}
		#endregion Properties
		#region Event Handlers
		// ------------------------------------------------------------------------------
		/// <summary>Load page for editing Bill Pay Account, getting mode and parameters.</summary>
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
						_entity = (BLL.Accounts.BillPayAccount)Session["BillPayAccountItem"];
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
					Session["BillPayAccountItem"] = _entity;
				}
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditBillPayAccount.Page_Load"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Delete Bill Pay Account.</summary>
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
					BLL.Accounts.BillPayAccountManager.DeleteOneBillPayAccount(BillPayAccountItem, performCascade);
					Globals.AddStatusMessage("Bill Pay Account deleted.");
				}
				else
				{
					// raise event so item is removed from collection
					if (BillPayAccountRemoved != null)
					{
						BillPayAccountRemoved(this, new EntityEditEventArgs(_entity));
					}
				}
				// create new object and store it in _entity
				CreateNewEntity();
				Session["BillPayAccountItem"] = _entity;
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditBillPayAccount.btnDelete_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("AccountID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("BillPayAccountAccountID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Request to create a new Bill Pay Account.</summary>
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
				Session["BillPayAccountItem"] = _entity;
				this.sectionLinks.OnSection("Basics");
				SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
				Globals.AddStatusMessage("Add new Bill Pay Account.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				doRedirect = false;
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				doRedirect = false;
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditBillPayAccount.btnNew_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("AccountID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("BillPayAccountAccountID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Reset form for Bill Pay Account.</summary>
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
					Session["BillPayAccountItem"] = _entity;
					sectionLinks.CurrentSection = "Basics";
				}
				else
				{
					CreateNewEntity();
				}
				Globals.AddStatusMessage("Bill Pay Account reset.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditBillPayAccount.btnReset_Click"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Save Bill Pay Account.</summary>
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
							if (BillPayAccountAdded != null && (BillPayAccountItem.AccountID != MOD.Data.DefaultValue.Guid || BillPayAccountItem.BusinessAccountNumber != MOD.Data.DefaultValue.String || BillPayAccountItem.StartDate != MOD.Data.DefaultValue.DateTime || BillPayAccountItem.EndDate != MOD.Data.DefaultValue.DateTime || BillPayAccountItem.DefaultMinimumPayment != MOD.Data.DefaultValue.Decimal || BillPayAccountItem.DefaultMaximumPayment != MOD.Data.DefaultValue.Decimal || BillPayAccountItem.BusinessMetaPartnerID != MOD.Data.DefaultValue.Guid || BillPayAccountItem.HourOfDay != MOD.Data.DefaultValue.Int || BillPayAccountItem.DayOfWeek != MOD.Data.DefaultValue.Int || BillPayAccountItem.WeekOfMonth != MOD.Data.DefaultValue.Int || BillPayAccountItem.MonthOfYear != MOD.Data.DefaultValue.Int || BillPayAccountItem.NumberOfReminders != MOD.Data.DefaultValue.Int || BillPayAccountItem.FrequencyCode != MOD.Data.DefaultValue.Int || BillPayAccountItem.CreatedByUserID != MOD.Data.DefaultValue.Guid || BillPayAccountItem.CreatedDate != MOD.Data.DefaultValue.DateTime || BillPayAccountItem.LastModifiedByUserID != MOD.Data.DefaultValue.Guid || BillPayAccountItem.LastModifiedDate != MOD.Data.DefaultValue.DateTime || BillPayAccountItem.Timestamp != null))
							{
								BillPayAccountAdded(this, new EntityEditEventArgs(_entity));
								// create new object and store it in _entity
								CreateNewEntity();
								Session["BillPayAccountItem"] = _entity;
								this.sectionLinks.OnSection("Basics");
								SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
							}
						}
						else
						{
							Globals.AddStatusMessage("Bill Pay Account updated.");
						}
					}
					else
					{
						UpsertToDatabase(true);
						if (AccessMode == MOD.Data.AccessMode.Add)
						{
							doRedirect = true;
							Globals.AddStatusMessage("Bill Pay Account added.");
						}
						else
						{
							Globals.AddStatusMessage("Bill Pay Account updated.");
						}
						SetAccessModeAndDisplay(MOD.Data.AccessMode.Edit);
					}
				}
				else
				{
					Globals.AddErrorMessage(Page, "Bill Pay Account validation failed.");
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditBillPayAccount.btnSave_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && isValid == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("AccountID", BillPayAccountItem.AccountID.ToString());
				queryString.Add("BillPayAccountAccountID", BillPayAccountItem.AccountID.ToString());
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditBillPayAccount.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditBillPayAccount.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditBillPayAccount.btnBasics_Click"));
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
				ResetStartDateCalendar(Page.IsPostBack == false);
				ResetEndDateCalendar(Page.IsPostBack == false);
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditBillPayAccount.Page_PreRender"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// Handle Start Date selection change.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		// ------------------------------------------------------------------------------
		private void calStartDate_SelectionChanged(object sender, EventArgs e)
		{
			txtStartDate.Text = calStartDate.SelectedDate.ToShortDateString();
			BillPayAccountItem.StartDate = calStartDate.SelectedDate;
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// HandleStart Datescheduler.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		// ------------------------------------------------------------------------------
		private void btnStartDateCalendar_Click(object sender, EventArgs e)
		{
			if (calStartDate.Visible == false)
			{
				calStartDate.Visible = true;
				btnStartDateCalendar.Text = "Hide Calendar";
				ResetStartDateCalendar(true);
			}
			else
			{
				calStartDate.Visible = false;
				btnStartDateCalendar.Text = "Calendar";
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// Handle End Date selection change.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		// ------------------------------------------------------------------------------
		private void calEndDate_SelectionChanged(object sender, EventArgs e)
		{
			txtEndDate.Text = calEndDate.SelectedDate.ToShortDateString();
			BillPayAccountItem.EndDate = calEndDate.SelectedDate;
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// HandleEnd Datescheduler.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		// ------------------------------------------------------------------------------
		private void btnEndDateCalendar_Click(object sender, EventArgs e)
		{
			if (calEndDate.Visible == false)
			{
				calEndDate.Visible = true;
				btnEndDateCalendar.Text = "Hide Calendar";
				ResetEndDateCalendar(true);
			}
			else
			{
				calEndDate.Visible = false;
				btnEndDateCalendar.Text = "Calendar";
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
		/// Create a new Bill Pay Account object reference
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void CreateNewEntity()
		{
			BLL.Accounts.BillPayAccount vBillPayAccount = new BLL.Accounts.BillPayAccount();
			vBillPayAccount.BusinessMetaPartnerID = MOD.Data.DataHelper.GetGuid(Request.QueryString["BusinessMetaPartnerID"], MOD.Data.DefaultValue.Guid);
			vBillPayAccount.FrequencyCode = MOD.Data.DataHelper.GetInt(Request.QueryString["FrequencyCode"], MOD.Data.DefaultValue.Int);
			_entity = vBillPayAccount;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update form from Bill Pay Account information.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyEntityToForm()
		{
			BLL.Accounts.BillPayAccount vBillPayAccount = BillPayAccountItem;
			lblAccountID.Text = MOD.Data.DataHelper.GetString(vBillPayAccount.AccountID, "");
			txtBusinessAccountNumber.Text = MOD.Data.EditHelper.GetString(vBillPayAccount.BusinessAccountNumber);
			txtStartDate.Text = MOD.Data.EditHelper.GetDate(vBillPayAccount.StartDate);
			txtEndDate.Text = MOD.Data.EditHelper.GetDate(vBillPayAccount.EndDate);
			txtDefaultMinimumPayment.Text = MOD.Data.EditHelper.GetCurrency(vBillPayAccount.DefaultMinimumPayment);
			txtDefaultMaximumPayment.Text = MOD.Data.EditHelper.GetCurrency(vBillPayAccount.DefaultMaximumPayment);
			ddlBusinessMetaPartnerID.DataValueField = "PrimaryIndex";
			ddlBusinessMetaPartnerID.DataTextField = "PrimaryName";
			if (UseWorkingSets == true && Session["Customers/BusinessWorkingSet"] != null)
			{
				BLL.SortableList<BLL.Customers.Business> sessionSource = (BLL.SortableList<BLL.Customers.Business>) Session["Customers/BusinessWorkingSet"];
				BLL.SortableList<BLL.Customers.Business> currentSource = new BLL.SortableList<BLL.Customers.Business>(sessionSource, true);
				if (MOD.Data.DataHelper.GetGuid(vBillPayAccount.BusinessMetaPartnerID, MOD.Data.DefaultValue.Guid) != MOD.Data.DefaultValue.Guid)
				{
					BLL.Customers.Business currentBusiness = BLL.Customers.BusinessManager.GetOneBusiness(MOD.Data.DataHelper.GetGuid(vBillPayAccount.BusinessMetaPartnerID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions("", "", true, true));
					if (currentBusiness != null && currentSource.Contains(currentBusiness) == false)
					{
						currentSource.Insert(0, currentBusiness);
					}
				}
				ddlBusinessMetaPartnerID.DataSource = currentSource;
				lnkBusinessMetaPartnerIDWorkingSet.Visible = true;
				lnkBusinessMetaPartnerIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Customers/SearchBusinessData.aspx");
				lblBusinessMetaPartnerIDWorkingSet.Visible = true;
				lblBusinessMetaPartnerIDWorkingSet.Text = " (from Business working set)";
			}
			else
			{
				ddlBusinessMetaPartnerID.DataSource = BLL.Customers.BusinessManager.GetAllBusinessData(Globals.DBOptions, Globals.getDataOptions("MetaPartnerName", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
				lblBusinessMetaPartnerIDWorkingSet.Visible = false;
				if (UseWorkingSets == true)
				{
					lnkBusinessMetaPartnerIDWorkingSet.Visible = true;
					lnkBusinessMetaPartnerIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Customers/SearchBusinessData.aspx");
				}
				else
				{
					lnkBusinessMetaPartnerIDWorkingSet.Visible = false;
				}
			}
			ddlBusinessMetaPartnerID.DataBind();
			ddlBusinessMetaPartnerID.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				BLL.Customers.Business sBusiness = new BLL.Customers.Business();
				sBusiness.MetaPartnerID = MOD.Data.DataHelper.GetGuid(vBillPayAccount.BusinessMetaPartnerID, MOD.Data.DefaultValue.Guid);
				ddlBusinessMetaPartnerID.SelectedValue = MOD.Data.DataHelper.GetString(sBusiness.PrimaryIndex, "");
				sBusiness = null;
			}
			catch {}
			if(ddlBusinessMetaPartnerID.SelectedValue == ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				try
				{
					ddlBusinessMetaPartnerID.SelectedValue = MOD.Data.DataHelper.GetString(Session["Customers/BusinessWorkingSetItem"], "");
				}
				catch {}
			}
			txtHourOfDay.Text = MOD.Data.EditHelper.GetInt(vBillPayAccount.HourOfDay);
			txtDayOfWeek.Text = MOD.Data.EditHelper.GetInt(vBillPayAccount.DayOfWeek);
			txtWeekOfMonth.Text = MOD.Data.EditHelper.GetInt(vBillPayAccount.WeekOfMonth);
			txtMonthOfYear.Text = MOD.Data.EditHelper.GetInt(vBillPayAccount.MonthOfYear);
			txtNumberOfReminders.Text = MOD.Data.EditHelper.GetInt(vBillPayAccount.NumberOfReminders);
			ddlFrequencyCode.DataValueField = "PrimaryIndex";
			ddlFrequencyCode.DataTextField = "PrimaryName";
			ddlFrequencyCode.DataSource = BLL.Accounts.FrequencyManager.GetAllFrequencyData(Globals.DBOptions, Globals.getDataOptions("FrequencyName", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
			ddlFrequencyCode.DataBind();
			ddlFrequencyCode.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				BLL.Accounts.Frequency sFrequency = new BLL.Accounts.Frequency();
				sFrequency.FrequencyCode = MOD.Data.DataHelper.GetInt(vBillPayAccount.FrequencyCode, MOD.Data.DefaultValue.Int);
				ddlFrequencyCode.SelectedValue = MOD.Data.DataHelper.GetString(sFrequency.PrimaryIndex, "");
				sFrequency = null;
			}
			catch {}
			if(ddlFrequencyCode.SelectedValue == ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				try
				{
					ddlFrequencyCode.SelectedValue = MOD.Data.DataHelper.GetString(Session["Accounts/FrequencyWorkingSetItem"], "");
				}
				catch {}
			}
			ddlMetaPartnerID.DataValueField = "PrimaryIndex";
			ddlMetaPartnerID.DataTextField = "PrimaryName";
			if (UseWorkingSets == true && Session["Customers/MetaPartnerWorkingSet"] != null)
			{
				BLL.SortableList<BLL.Customers.MetaPartner> sessionSource = (BLL.SortableList<BLL.Customers.MetaPartner>) Session["Customers/MetaPartnerWorkingSet"];
				BLL.SortableList<BLL.Customers.MetaPartner> currentSource = new BLL.SortableList<BLL.Customers.MetaPartner>(sessionSource, true);
				if (MOD.Data.DataHelper.GetGuid(vBillPayAccount.MetaPartnerID, MOD.Data.DefaultValue.Guid) != MOD.Data.DefaultValue.Guid)
				{
					BLL.Customers.MetaPartner currentMetaPartner = BLL.Customers.MetaPartnerManager.GetOneMetaPartner(MOD.Data.DataHelper.GetGuid(vBillPayAccount.MetaPartnerID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions("", "", true, true));
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
				sMetaPartner.MetaPartnerID = MOD.Data.DataHelper.GetGuid(vBillPayAccount.MetaPartnerID, MOD.Data.DefaultValue.Guid);
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
			txtAccountName.Text = MOD.Data.EditHelper.GetString(vBillPayAccount.AccountName);
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
					ddlAccountSubTypeCode.SelectedValue = ddlAccountSubTypeCode.Items.FindByText("BillPayAccount").Value;
				}
				else
				{
					ddlAccountSubTypeCode.SelectedValue = MOD.Data.DataHelper.GetString(vBillPayAccount.AccountSubTypeCode, "");
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
				sCurrency.CurrencyCode = MOD.Data.DataHelper.GetInt(vBillPayAccount.CurrencyCode, MOD.Data.DefaultValue.Int);
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
			txtDescription.Text = MOD.Data.EditHelper.GetString(vBillPayAccount.Description);
			chkIsActive.Checked = MOD.Data.DataHelper.GetBool(vBillPayAccount.IsActive, MOD.Data.DefaultValue.Bool);
			// Drop downs should be disabled when control is "Internal" and either value is constrained by container
			if (WorkflowMode == WorkflowMode.Internal)
			{
				ddlBusinessMetaPartnerID.Visible = Request.QueryString["BusinessMetaPartnerID"] == null;
				lnkBusinessMetaPartnerIDWorkingSet.Visible = lnkBusinessMetaPartnerIDWorkingSet.Visible == true && Request.QueryString["BusinessMetaPartnerID"] == null;
				lblBusinessMetaPartnerIDWorkingSet.Visible = lblBusinessMetaPartnerIDWorkingSet.Visible == true && Request.QueryString["BusinessMetaPartnerID"] == null;
				valBusinessMetaPartnerID.Enabled = Request.QueryString["BusinessMetaPartnerID"] == null;
				lblBusinessMetaPartnerIDDisplay.Visible = Request.QueryString["BusinessMetaPartnerID"] == null;
				ddlFrequencyCode.Visible = Request.QueryString["FrequencyCode"] == null;
				valFrequencyCode.Enabled = Request.QueryString["FrequencyCode"] == null;
				lblFrequencyCodeDisplay.Visible = Request.QueryString["FrequencyCode"] == null;
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
		/// <summary>Set Bill Pay Account information from the form.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyFormToEntity()
		{
			BLL.Accounts.BillPayAccount vBillPayAccount = BillPayAccountItem;
			if (vBillPayAccount == null)
			{
				throw CoreUtility.CustomAppException.WrapException(new Exception("Bill Pay Account not found"), "EditBillPayAccount.CopyFormToEntity()");
			}
			vBillPayAccount.BusinessAccountNumber = EditHelper.EncodeStringForDB(MOD.Data.DataHelper.GetString(txtBusinessAccountNumber.Text, null));
			try
			{
				vBillPayAccount.StartDate = MOD.Data.DataHelper.GetDateTime(txtStartDate.Text, MOD.Data.DefaultValue.DateTime);
			}
			catch {}
			try
			{
				vBillPayAccount.EndDate = MOD.Data.DataHelper.GetDateTime(txtEndDate.Text, MOD.Data.DefaultValue.DateTime);
			}
			catch {}
			try
			{
				vBillPayAccount.DefaultMinimumPayment = MOD.Data.DataHelper.GetDecimal(txtDefaultMinimumPayment.Text, MOD.Data.DefaultValue.Decimal);
			}
			catch {}
			try
			{
				vBillPayAccount.DefaultMaximumPayment = MOD.Data.DataHelper.GetDecimal(txtDefaultMaximumPayment.Text, MOD.Data.DefaultValue.Decimal);
			}
			catch {}
			if (ddlBusinessMetaPartnerID.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Customers.Business sBusiness = new BLL.Customers.Business(ddlBusinessMetaPartnerID.SelectedValue, false);
				vBillPayAccount.BusinessMetaPartnerID = MOD.Data.DataHelper.GetGuid(sBusiness.MetaPartnerID, MOD.Data.DefaultValue.Guid);
				sBusiness = null;
			}
			try
			{
				vBillPayAccount.HourOfDay = MOD.Data.DataHelper.GetInt(txtHourOfDay.Text, MOD.Data.DefaultValue.Int);
			}
			catch {}
			try
			{
				vBillPayAccount.DayOfWeek = MOD.Data.DataHelper.GetInt(txtDayOfWeek.Text, MOD.Data.DefaultValue.Int);
			}
			catch {}
			try
			{
				vBillPayAccount.WeekOfMonth = MOD.Data.DataHelper.GetInt(txtWeekOfMonth.Text, MOD.Data.DefaultValue.Int);
			}
			catch {}
			try
			{
				vBillPayAccount.MonthOfYear = MOD.Data.DataHelper.GetInt(txtMonthOfYear.Text, MOD.Data.DefaultValue.Int);
			}
			catch {}
			try
			{
				vBillPayAccount.NumberOfReminders = MOD.Data.DataHelper.GetInt(txtNumberOfReminders.Text, MOD.Data.DefaultValue.Int);
			}
			catch {}
			if (ddlFrequencyCode.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Accounts.Frequency sFrequency = new BLL.Accounts.Frequency(ddlFrequencyCode.SelectedValue, false);
				vBillPayAccount.FrequencyCode = MOD.Data.DataHelper.GetInt(sFrequency.FrequencyCode, MOD.Data.DefaultValue.Int);
				sFrequency = null;
				vBillPayAccount.PrimaryName += MOD.Data.DataHelper.GetString(ddlFrequencyCode.SelectedItem.Text, MOD.Data.DefaultValue.String) + ";";
			}
			if (ddlMetaPartnerID.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Customers.MetaPartner sMetaPartner = new BLL.Customers.MetaPartner(ddlMetaPartnerID.SelectedValue, false);
				vBillPayAccount.MetaPartnerID = MOD.Data.DataHelper.GetGuid(sMetaPartner.MetaPartnerID, MOD.Data.DefaultValue.Guid);
				sMetaPartner = null;
			}
			vBillPayAccount.AccountName = EditHelper.EncodeStringForDB(MOD.Data.DataHelper.GetString(txtAccountName.Text, null));
			if (ddlAccountSubTypeCode.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Accounts.AccountSubType sAccountSubType = new BLL.Accounts.AccountSubType(ddlAccountSubTypeCode.SelectedValue, false);
				vBillPayAccount.AccountSubTypeCode = MOD.Data.DataHelper.GetInt(sAccountSubType.AccountSubTypeCode, MOD.Data.DefaultValue.Int);
				sAccountSubType = null;
			}
			if (ddlCurrencyCode.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Accounts.Currency sCurrency = new BLL.Accounts.Currency(ddlCurrencyCode.SelectedValue, false);
				vBillPayAccount.CurrencyCode = MOD.Data.DataHelper.GetInt(sCurrency.CurrencyCode, MOD.Data.DefaultValue.Int);
				sCurrency = null;
			}
			vBillPayAccount.Description = EditHelper.EncodeStringForDB(MOD.Data.DataHelper.GetString(txtDescription.Text, null));
			vBillPayAccount.IsActive = chkIsActive.Checked;
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// Load entity from database, store in _entity and Session["BillPayAccountItem"]
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void LoadEntity()
		{
			_entity = null;
			Guid accountID = MOD.Data.DataHelper.GetGuid(Request.QueryString["AccountID"], MOD.Data.DefaultValue.Guid);
			if (accountID != MOD.Data.DefaultValue.Guid)
			{
				_entity = BLL.Accounts.BillPayAccountManager.GetOneBillPayAccount(accountID, Globals.getDataOptions("", "", true, true));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update Bill Pay Account information in the database.</summary>
		///
		// ------------------------------------------------------------------------------
		private void UpsertToDatabase(bool performCascade)
		{
			BLL.Accounts.BillPayAccount vBillPayAccount = BillPayAccountItem;
			if (AccessMode == MOD.Data.AccessMode.Add)
			{
				BLL.Accounts.BillPayAccountManager.AddOneBillPayAccount(vBillPayAccount, performCascade);
			}
			else if (AccessMode == MOD.Data.AccessMode.Edit)
			{
				BLL.Accounts.BillPayAccountManager.UpdateOneBillPayAccount(vBillPayAccount, performCascade);
			}
			BillPayAccountItem.AccountID = vBillPayAccount.AccountID;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set access and display modes for presenting Bill Pay Account information.</summary>
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
					lblTitle.Text = "Add Bill&nbsp;Pay&nbsp;Account";
					btnSave.Text = "Add";
					break;
				case MOD.Data.AccessMode.Edit:
					lblTitle.Text = "Edit Bill&nbsp;Pay&nbsp;Account";
					btnSave.Text = "Save";
					break;
				case MOD.Data.AccessMode.View:
					lblTitle.Text = "View Bill&nbsp;Pay&nbsp;Account";
					break;
				default:
					lblTitle.Text = "View Bill&nbsp;Pay&nbsp;Account";
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
		/// Reset Start Date schedule.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		// ------------------------------------------------------------------------------
		private void ResetStartDateCalendar(bool resetVisibleDate)
		{
			try
			{
				calStartDate.SelectedDates.Clear();
				System.DateTime strStartDate = System.DateTime.Parse(txtStartDate.Text);
				calStartDate.SelectedDate = strStartDate;
				if (resetVisibleDate == true)
				{
					calStartDate.VisibleDate = strStartDate;
				}
			}
			catch
			{
				calStartDate.SelectedDates.Clear();
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// Reset End Date schedule.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		// ------------------------------------------------------------------------------
		private void ResetEndDateCalendar(bool resetVisibleDate)
		{
			try
			{
				calEndDate.SelectedDates.Clear();
				System.DateTime strEndDate = System.DateTime.Parse(txtEndDate.Text);
				calEndDate.SelectedDate = strEndDate;
				if (resetVisibleDate == true)
				{
					calEndDate.VisibleDate = strEndDate;
				}
			}
			catch
			{
				calEndDate.SelectedDates.Clear();
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
		/// <summary>Initialize component for BillPayAccount, add delegates here.</summary>
		///
		// ------------------------------------------------------------------------------
		private void InitializeComponent()
		{
			this.calStartDate.SelectionChanged += new System.EventHandler(calStartDate_SelectionChanged);
			this.btnStartDateCalendar.Click += new EventHandler(btnStartDateCalendar_Click);
			this.calEndDate.SelectionChanged += new System.EventHandler(calEndDate_SelectionChanged);
			this.btnEndDateCalendar.Click += new EventHandler(btnEndDateCalendar_Click);
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