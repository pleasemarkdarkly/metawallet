
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
using MW.MComm.WalletSolution.BLL.Customers;
using CoreUtility = MW.MComm.WalletSolution.Utility;
using MW.MComm.Admin.WebUI.Components.Desktop;
namespace MW.MComm.Admin.WebUI.UserControls.Desktop.Customers
{
	// ------------------------------------------------------------------------------
	/// <summary>Edit Meta Partner is used to help manage MetaPartner information.</summary>
	///
	/// File History:
	/// <created>6/1/2007 (Chris Grundy)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class EditMetaPartner  : Components.Desktop.BaseFormlUserControl, Controls.IHaveUploadableFiles
	{
		#region IHaveUploadableFiles
		public string GetFileRelativePath(Controls.FileUploader ctl)
		{
			if (ctl == txtPictureImageURL)
				return MetaPartnerItem.PictureImageURL;
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
		public event EntityEditEventHandler MetaPartnerAdded;
		/// <summary>
		/// Raised when "Remove" button is clicked in internal mode.
		/// Container handles this event and removes entity from collection.
		/// </summary>
		public event EntityEditEventHandler MetaPartnerRemoved;
		#endregion Events
		#region Declarations
		#endregion Declarations
		#region Properties
		/// <summary>
		/// The MetaPartner currently being edited by this control.
		/// Get accessor casts base._entity to MetaPartner
		/// Set accessor used by parent control to set the item currently being edited
		/// </summary>
		public BLL.Customers.MetaPartner MetaPartnerItem
		{
			get
			{
				return (BLL.Customers.MetaPartner) _entity;
			}
			set
			{
				_entity = value; // only set by container
				Session["MetaPartnerItem"] = _entity;
			}
		}
		#endregion Properties
		#region Event Handlers
		// ------------------------------------------------------------------------------
		/// <summary>Load page for editing Meta Partner, getting mode and parameters.</summary>
		///
		// ------------------------------------------------------------------------------
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				// set validator property to child controls
				listMetaPartnerPhoneData.UseValidation = UseValidation && (DisplayMode != MOD.Data.DisplayMode.SingleView);
				listMetaPartnerEmailData.UseValidation = UseValidation && (DisplayMode != MOD.Data.DisplayMode.SingleView);
				listLocationData.UseValidation = UseValidation && (DisplayMode != MOD.Data.DisplayMode.SingleView);
				listBankAccountData.UseValidation = UseValidation && (DisplayMode != MOD.Data.DisplayMode.SingleView);
				listStoredValueAccountData.UseValidation = UseValidation && (DisplayMode != MOD.Data.DisplayMode.SingleView);
				listCreditAccountData.UseValidation = UseValidation && (DisplayMode != MOD.Data.DisplayMode.SingleView);
				listFundAccountData.UseValidation = UseValidation && (DisplayMode != MOD.Data.DisplayMode.SingleView);
				listBillPayAccountData.UseValidation = UseValidation && (DisplayMode != MOD.Data.DisplayMode.SingleView);
				listMetaTransferAccountData.UseValidation = UseValidation && (DisplayMode != MOD.Data.DisplayMode.SingleView);
				listLoanAccountData.UseValidation = UseValidation && (DisplayMode != MOD.Data.DisplayMode.SingleView);
				listMetaPartnerCouponData.UseValidation = UseValidation && (DisplayMode != MOD.Data.DisplayMode.SingleView);
				base.OnLoad();
				if (IsPostBack == true)
				{
					// entity may come from session, or be set by container
					if (_entity == null)
					{
						_entity = (BLL.Customers.MetaPartner)Session["MetaPartnerItem"];
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
					Session["MetaPartnerItem"] = _entity;
				}
				// Assign entity collections into child controls
				listMetaPartnerPhoneData.Collection = MetaPartnerItem.PhoneList;
				listMetaPartnerEmailData.Collection = MetaPartnerItem.EmailList;
				listLocationData.Collection = MetaPartnerItem.LocationList;
				listBankAccountData.Collection = MetaPartnerItem.BankAccountList;
				listStoredValueAccountData.Collection = MetaPartnerItem.StoredValueAccountList;
				listCreditAccountData.Collection = MetaPartnerItem.CreditAccountList;
				listFundAccountData.Collection = MetaPartnerItem.FundAccountList;
				listBillPayAccountData.Collection = MetaPartnerItem.BillPayAccountList;
				listMetaTransferAccountData.Collection = MetaPartnerItem.MetaTransferAccountList;
				listLoanAccountData.Collection = MetaPartnerItem.LoanAccountList;
				listMetaPartnerCouponData.Collection = MetaPartnerItem.MetaPartnerCouponList;
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditMetaPartner.Page_Load"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Delete Meta Partner.</summary>
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
					BLL.Customers.MetaPartnerManager.DeleteOneMetaPartner(MetaPartnerItem, performCascade);
					Globals.AddStatusMessage("Meta Partner deleted.");
				}
				else
				{
					// raise event so item is removed from collection
					if (MetaPartnerRemoved != null)
					{
						MetaPartnerRemoved(this, new EntityEditEventArgs(_entity));
					}
				}
				// create new object and store it in _entity
				CreateNewEntity();
				Session["MetaPartnerItem"] = _entity;
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditMetaPartner.btnDelete_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("MetaPartnerID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Request to create a new Meta Partner.</summary>
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
				Session["MetaPartnerItem"] = _entity;
				this.sectionLinks.OnSection("Basics");
				SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
				Globals.AddStatusMessage("Add new Meta Partner.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				doRedirect = false;
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				doRedirect = false;
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditMetaPartner.btnNew_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("MetaPartnerID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Reset form for Meta Partner.</summary>
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
					Session["MetaPartnerItem"] = _entity;
					sectionLinks.CurrentSection = "Basics";
				}
				else
				{
					CreateNewEntity();
				}
				Globals.AddStatusMessage("Meta Partner reset.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditMetaPartner.btnReset_Click"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Save Meta Partner.</summary>
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
				if (txtPictureImageURL.HtmlInputFile.Value.Trim() != "" && txtPictureImageURL.Validate() == false)
				{
					isValid = false;
				}
				if (isValid == true)
				{
					if (WorkflowMode == WorkflowMode.Internal)
					{
						if (AccessMode == MOD.Data.AccessMode.Add)
						{
							if (MetaPartnerAdded != null && (MetaPartnerItem.MetaPartnerID != MOD.Data.DefaultValue.Guid || MetaPartnerItem.MetaPartnerSubTypeCode != MOD.Data.DefaultValue.Int || MetaPartnerItem.LocaleCode != MOD.Data.DefaultValue.Int || MetaPartnerItem.CurrencyCode != MOD.Data.DefaultValue.Int || MetaPartnerItem.DateFormatCode != MOD.Data.DefaultValue.Int || MetaPartnerItem.TaxCode != MOD.Data.DefaultValue.String || MetaPartnerItem.IsActive != MOD.Data.DefaultValue.Bool || MetaPartnerItem.CreatedByUserID != MOD.Data.DefaultValue.Guid || MetaPartnerItem.CreatedDate != MOD.Data.DefaultValue.DateTime || MetaPartnerItem.LastModifiedByUserID != MOD.Data.DefaultValue.Guid || MetaPartnerItem.LastModifiedDate != MOD.Data.DefaultValue.DateTime || MetaPartnerItem.Timestamp != null || MetaPartnerItem.MetaPartnerName != MOD.Data.DefaultValue.String || MetaPartnerItem.PictureImageURL != MOD.Data.DefaultValue.String))
							{
								MetaPartnerAdded(this, new EntityEditEventArgs(_entity));
								// create new object and store it in _entity
								CreateNewEntity();
								Session["MetaPartnerItem"] = _entity;
								this.sectionLinks.OnSection("Basics");
								SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
							}
						}
						else
						{
							Globals.AddStatusMessage("Meta Partner updated.");
						}
					}
					else
					{
						UpsertToDatabase(true);
						if (AccessMode == MOD.Data.AccessMode.Add)
						{
							doRedirect = true;
							Globals.AddStatusMessage("Meta Partner added.");
						}
						else
						{
							Globals.AddStatusMessage("Meta Partner updated.");
						}
						SetAccessModeAndDisplay(MOD.Data.AccessMode.Edit);
					}
				}
				else
				{
					Globals.AddErrorMessage(Page, "Meta Partner validation failed.");
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditMetaPartner.btnSave_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && isValid == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("MetaPartnerID", MetaPartnerItem.MetaPartnerID.ToString());
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditMetaPartner.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditMetaPartner.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditMetaPartner.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditMetaPartner.Page_PreRender"));
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
		/// Create a new Meta Partner object reference
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void CreateNewEntity()
		{
			BLL.Customers.MetaPartner vMetaPartner = new BLL.Customers.MetaPartner();
			vMetaPartner.MetaPartnerID = MOD.Data.DataHelper.GetGuid(Request.QueryString["MetaPartnerID"], MOD.Data.DefaultValue.Guid);
			vMetaPartner.MetaPartnerSubTypeCode = MOD.Data.DataHelper.GetInt(Request.QueryString["MetaPartnerSubTypeCode"], MOD.Data.DefaultValue.Int);
			vMetaPartner.LocaleCode = MOD.Data.DataHelper.GetInt(Request.QueryString["LocaleCode"], MOD.Data.DefaultValue.Int);
			vMetaPartner.CurrencyCode = MOD.Data.DataHelper.GetInt(Request.QueryString["CurrencyCode"], MOD.Data.DefaultValue.Int);
			vMetaPartner.DateFormatCode = MOD.Data.DataHelper.GetInt(Request.QueryString["DateFormatCode"], MOD.Data.DefaultValue.Int);
			_entity = vMetaPartner;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update form from Meta Partner information.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyEntityToForm()
		{
			BLL.Customers.MetaPartner vMetaPartner = MetaPartnerItem;
			lblMetaPartnerID.Text = MOD.Data.DataHelper.GetString(vMetaPartner.MetaPartnerID, "");
			ddlMetaPartnerSubTypeCode.DataValueField = "PrimaryIndex";
			ddlMetaPartnerSubTypeCode.DataTextField = "PrimaryName";
			ddlMetaPartnerSubTypeCode.DataSource = BLL.Customers.MetaPartnerSubTypeManager.GetAllMetaPartnerSubTypeData(Globals.DBOptions, Globals.getDataOptions("MetaPartnerSubTypeName", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
			ddlMetaPartnerSubTypeCode.DataBind();
			if (AccessMode == MOD.Data.AccessMode.Add)
			{
				try
				{
					ddlMetaPartnerSubTypeCode.Items.Remove(ddlMetaPartnerSubTypeCode.Items.FindByText("Business"));
				}
				catch {}
				try
				{
					ddlMetaPartnerSubTypeCode.Items.Remove(ddlMetaPartnerSubTypeCode.Items.FindByText("Customer"));
				}
				catch {}
			}
			else
			{
				ddlMetaPartnerSubTypeCode.Enabled = false;
			}
			ddlMetaPartnerSubTypeCode.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				if (AccessMode == MOD.Data.AccessMode.Add)
				{
					ddlMetaPartnerSubTypeCode.SelectedValue = ddlMetaPartnerSubTypeCode.Items.FindByText("MetaPartner").Value;
				}
				else
				{
					ddlMetaPartnerSubTypeCode.SelectedValue = MOD.Data.DataHelper.GetString(vMetaPartner.MetaPartnerSubTypeCode, "");
				}
			}
			catch {}
			ddlLocaleCode.DataValueField = "PrimaryIndex";
			ddlLocaleCode.DataTextField = "PrimaryName";
			ddlLocaleCode.DataSource = BLL.Environments.LocaleManager.GetAllLocaleData(Globals.DBOptions, Globals.getDataOptions("LocaleName", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
			ddlLocaleCode.DataBind();
			ddlLocaleCode.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				BLL.Environments.Locale sLocale = new BLL.Environments.Locale();
				sLocale.LocaleCode = MOD.Data.DataHelper.GetInt(vMetaPartner.LocaleCode, MOD.Data.DefaultValue.Int);
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
			ddlCurrencyCode.DataValueField = "PrimaryIndex";
			ddlCurrencyCode.DataTextField = "PrimaryName";
			ddlCurrencyCode.DataSource = BLL.Accounts.CurrencyManager.GetAllCurrencyData(Globals.DBOptions, Globals.getDataOptions("CurrencyName", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
			ddlCurrencyCode.DataBind();
			ddlCurrencyCode.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				BLL.Accounts.Currency sCurrency = new BLL.Accounts.Currency();
				sCurrency.CurrencyCode = MOD.Data.DataHelper.GetInt(vMetaPartner.CurrencyCode, MOD.Data.DefaultValue.Int);
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
			ddlDateFormatCode.DataValueField = "PrimaryIndex";
			ddlDateFormatCode.DataTextField = "PrimaryName";
			ddlDateFormatCode.DataSource = BLL.Environments.DateFormatManager.GetAllDateFormatData(Globals.DBOptions, Globals.getDataOptions("DateFormatName", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
			ddlDateFormatCode.DataBind();
			ddlDateFormatCode.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				BLL.Environments.DateFormat sDateFormat = new BLL.Environments.DateFormat();
				sDateFormat.DateFormatCode = MOD.Data.DataHelper.GetInt(vMetaPartner.DateFormatCode, MOD.Data.DefaultValue.Int);
				ddlDateFormatCode.SelectedValue = MOD.Data.DataHelper.GetString(sDateFormat.PrimaryIndex, "");
				sDateFormat = null;
			}
			catch {}
			if(ddlDateFormatCode.SelectedValue == ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				try
				{
					ddlDateFormatCode.SelectedValue = MOD.Data.DataHelper.GetString(Session["Environments/DateFormatWorkingSetItem"], "");
				}
				catch {}
			}
			txtTaxCode.Text = MOD.Data.EditHelper.GetString(vMetaPartner.TaxCode);
			chkIsActive.Checked = MOD.Data.DataHelper.GetBool(vMetaPartner.IsActive, MOD.Data.DefaultValue.Bool);
			txtMetaPartnerName.Text = MOD.Data.EditHelper.GetString(vMetaPartner.MetaPartnerName);
			// Drop downs should be disabled when control is "Internal" and either value is constrained by container
			if (WorkflowMode == WorkflowMode.Internal)
			{
				ddlMetaPartnerSubTypeCode.Visible = Request.QueryString["MetaPartnerSubTypeCode"] == null;
				valMetaPartnerSubTypeCode.Enabled = Request.QueryString["MetaPartnerSubTypeCode"] == null;
				lblMetaPartnerSubTypeCodeDisplay.Visible = Request.QueryString["MetaPartnerSubTypeCode"] == null;
				ddlLocaleCode.Visible = Request.QueryString["LocaleCode"] == null;
				valLocaleCode.Enabled = Request.QueryString["LocaleCode"] == null;
				lblLocaleCodeDisplay.Visible = Request.QueryString["LocaleCode"] == null;
				ddlCurrencyCode.Visible = Request.QueryString["CurrencyCode"] == null;
				valCurrencyCode.Enabled = Request.QueryString["CurrencyCode"] == null;
				lblCurrencyCodeDisplay.Visible = Request.QueryString["CurrencyCode"] == null;
				ddlDateFormatCode.Visible = Request.QueryString["DateFormatCode"] == null;
				valDateFormatCode.Enabled = Request.QueryString["DateFormatCode"] == null;
				lblDateFormatCodeDisplay.Visible = Request.QueryString["DateFormatCode"] == null;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set Meta Partner information from the form.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyFormToEntity()
		{
			BLL.Customers.MetaPartner vMetaPartner = MetaPartnerItem;
			if (vMetaPartner == null)
			{
				throw CoreUtility.CustomAppException.WrapException(new Exception("Meta Partner not found"), "EditMetaPartner.CopyFormToEntity()");
			}
			if (ddlMetaPartnerSubTypeCode.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Customers.MetaPartnerSubType sMetaPartnerSubType = new BLL.Customers.MetaPartnerSubType(ddlMetaPartnerSubTypeCode.SelectedValue, false);
				vMetaPartner.MetaPartnerSubTypeCode = MOD.Data.DataHelper.GetInt(sMetaPartnerSubType.MetaPartnerSubTypeCode, MOD.Data.DefaultValue.Int);
				sMetaPartnerSubType = null;
				vMetaPartner.PrimaryName += MOD.Data.DataHelper.GetString(ddlMetaPartnerSubTypeCode.SelectedItem.Text, MOD.Data.DefaultValue.String) + ";";
			}
			if (ddlLocaleCode.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Environments.Locale sLocale = new BLL.Environments.Locale(ddlLocaleCode.SelectedValue, false);
				vMetaPartner.LocaleCode = MOD.Data.DataHelper.GetInt(sLocale.LocaleCode, MOD.Data.DefaultValue.Int);
				sLocale = null;
				vMetaPartner.PrimaryName += MOD.Data.DataHelper.GetString(ddlLocaleCode.SelectedItem.Text, MOD.Data.DefaultValue.String) + ";";
			}
			if (ddlCurrencyCode.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Accounts.Currency sCurrency = new BLL.Accounts.Currency(ddlCurrencyCode.SelectedValue, false);
				vMetaPartner.CurrencyCode = MOD.Data.DataHelper.GetInt(sCurrency.CurrencyCode, MOD.Data.DefaultValue.Int);
				sCurrency = null;
				vMetaPartner.PrimaryName += MOD.Data.DataHelper.GetString(ddlCurrencyCode.SelectedItem.Text, MOD.Data.DefaultValue.String) + ";";
			}
			if (ddlDateFormatCode.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Environments.DateFormat sDateFormat = new BLL.Environments.DateFormat(ddlDateFormatCode.SelectedValue, false);
				vMetaPartner.DateFormatCode = MOD.Data.DataHelper.GetInt(sDateFormat.DateFormatCode, MOD.Data.DefaultValue.Int);
				sDateFormat = null;
				vMetaPartner.PrimaryName += MOD.Data.DataHelper.GetString(ddlDateFormatCode.SelectedItem.Text, MOD.Data.DefaultValue.String) + ";";
			}
			vMetaPartner.TaxCode = EditHelper.EncodeStringForDB(MOD.Data.DataHelper.GetString(txtTaxCode.Text, null));
			vMetaPartner.IsActive = chkIsActive.Checked;
			vMetaPartner.MetaPartnerName = EditHelper.EncodeStringForDB(MOD.Data.DataHelper.GetString(txtMetaPartnerName.Text, null));
			vMetaPartner.PictureImageURL = txtPictureImageURL.SaveFile();
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// Load entity from database, store in _entity and Session["MetaPartnerItem"]
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void LoadEntity()
		{
			_entity = null;
			Guid metaPartnerID = MOD.Data.DataHelper.GetGuid(Request.QueryString["MetaPartnerID"], MOD.Data.DefaultValue.Guid);
			if (metaPartnerID != MOD.Data.DefaultValue.Guid)
			{
				_entity = BLL.Customers.MetaPartnerManager.GetOneMetaPartner(metaPartnerID, Globals.getDataOptions("", "", true, true));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update Meta Partner information in the database.</summary>
		///
		// ------------------------------------------------------------------------------
		private void UpsertToDatabase(bool performCascade)
		{
			BLL.Customers.MetaPartner vMetaPartner = MetaPartnerItem;
			if (AccessMode == MOD.Data.AccessMode.Add)
			{
				BLL.Customers.MetaPartnerManager.UpsertOneMetaPartner(vMetaPartner, performCascade);
			}
			else if (AccessMode == MOD.Data.AccessMode.Edit)
			{
				BLL.Customers.MetaPartnerManager.UpsertOneMetaPartner(vMetaPartner, performCascade);
			}
			MetaPartnerItem.MetaPartnerID = vMetaPartner.MetaPartnerID;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set access and display modes for presenting Meta Partner information.</summary>
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
					lblTitle.Text = "Add Meta&nbsp;Partner";
					btnSave.Text = "Add";
					break;
				case MOD.Data.AccessMode.Edit:
					lblTitle.Text = "Edit Meta&nbsp;Partner";
					btnSave.Text = "Save";
					break;
				case MOD.Data.AccessMode.View:
					lblTitle.Text = "View Meta&nbsp;Partner";
					break;
				default:
					lblTitle.Text = "View Meta&nbsp;Partner";
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
				Section_Phones.Visible = false;
				Section_Emails.Visible = false;
				Section_Locations.Visible = false;
				Section_Bank_Accounts.Visible = false;
				Section_Stored_Value_Accounts.Visible = false;
				Section_Credit_Accounts.Visible = false;
				Section_Fund_Accounts.Visible = false;
				Section_Bill_Pay_Accounts.Visible = false;
				Section_Meta_Transfer_Accounts.Visible = false;
				Section_Loan_Accounts.Visible = false;
				Section_Meta_Partner_Coupons.Visible = false;
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
				if (WorkflowMode != MOD.Data.WorkflowMode.Internal)
				{
					Section_Phones.Visible = true;
					Section_Emails.Visible = true;
					Section_Locations.Visible = true;
					Section_Bank_Accounts.Visible = true;
					Section_Stored_Value_Accounts.Visible = true;
					Section_Credit_Accounts.Visible = true;
					Section_Fund_Accounts.Visible = true;
					Section_Bill_Pay_Accounts.Visible = true;
					Section_Meta_Transfer_Accounts.Visible = true;
					Section_Loan_Accounts.Visible = true;
					Section_Meta_Partner_Coupons.Visible = true;
				}
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
		/// <summary>Initialize component for MetaPartner, add delegates here.</summary>
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