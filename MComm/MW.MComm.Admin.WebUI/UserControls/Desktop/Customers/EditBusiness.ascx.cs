
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
	/// <summary>Edit Business is used to help manage Business information.</summary>
	///
	/// File History:
	/// <created>6/1/2007 (Chris Grundy)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class EditBusiness  : Components.Desktop.BaseFormlUserControl, Controls.IHaveUploadableFiles
	{
		#region IHaveUploadableFiles
		public string GetFileRelativePath(Controls.FileUploader ctl)
		{
			if (ctl == txtPictureImageURL)
				return BusinessItem.PictureImageURL;
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
		public event EntityEditEventHandler BusinessAdded;
		/// <summary>
		/// Raised when "Remove" button is clicked in internal mode.
		/// Container handles this event and removes entity from collection.
		/// </summary>
		public event EntityEditEventHandler BusinessRemoved;
		#endregion Events
		#region Declarations
		#endregion Declarations
		#region Properties
		/// <summary>
		/// The Business currently being edited by this control.
		/// Get accessor casts base._entity to Business
		/// Set accessor used by parent control to set the item currently being edited
		/// </summary>
		public BLL.Customers.Business BusinessItem
		{
			get
			{
				return (BLL.Customers.Business) _entity;
			}
			set
			{
				_entity = value; // only set by container
				Session["BusinessItem"] = _entity;
			}
		}
		#endregion Properties
		#region Event Handlers
		// ------------------------------------------------------------------------------
		/// <summary>Load page for editing Business, getting mode and parameters.</summary>
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
						_entity = (BLL.Customers.Business)Session["BusinessItem"];
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
					Session["BusinessItem"] = _entity;
				}
				// Assign entity collections into child controls
				listMetaPartnerPhoneData.Collection = BusinessItem.PhoneList;
				listMetaPartnerEmailData.Collection = BusinessItem.EmailList;
				listLocationData.Collection = BusinessItem.LocationList;
				listBankAccountData.Collection = BusinessItem.BankAccountList;
				listStoredValueAccountData.Collection = BusinessItem.StoredValueAccountList;
				listCreditAccountData.Collection = BusinessItem.CreditAccountList;
				listFundAccountData.Collection = BusinessItem.FundAccountList;
				listBillPayAccountData.Collection = BusinessItem.BillPayAccountList;
				listMetaTransferAccountData.Collection = BusinessItem.MetaTransferAccountList;
				listLoanAccountData.Collection = BusinessItem.LoanAccountList;
				listMetaPartnerCouponData.Collection = BusinessItem.MetaPartnerCouponList;
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditBusiness.Page_Load"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Delete Business.</summary>
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
					BLL.Customers.BusinessManager.DeleteOneBusiness(BusinessItem, performCascade);
					Globals.AddStatusMessage("Business deleted.");
				}
				else
				{
					// raise event so item is removed from collection
					if (BusinessRemoved != null)
					{
						BusinessRemoved(this, new EntityEditEventArgs(_entity));
					}
				}
				// create new object and store it in _entity
				CreateNewEntity();
				Session["BusinessItem"] = _entity;
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditBusiness.btnDelete_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("MetaPartnerID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("BusinessMetaPartnerID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Request to create a new Business.</summary>
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
				Session["BusinessItem"] = _entity;
				this.sectionLinks.OnSection("Basics");
				SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
				Globals.AddStatusMessage("Add new Business.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				doRedirect = false;
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				doRedirect = false;
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditBusiness.btnNew_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("MetaPartnerID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("BusinessMetaPartnerID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Reset form for Business.</summary>
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
					Session["BusinessItem"] = _entity;
					sectionLinks.CurrentSection = "Basics";
				}
				else
				{
					CreateNewEntity();
				}
				Globals.AddStatusMessage("Business reset.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditBusiness.btnReset_Click"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Save Business.</summary>
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
							if (BusinessAdded != null && (BusinessItem.MetaPartnerID != MOD.Data.DefaultValue.Guid || BusinessItem.ServiceCharges != MOD.Data.DefaultValue.String || BusinessItem.CreatedByUserID != MOD.Data.DefaultValue.Guid || BusinessItem.CreatedDate != MOD.Data.DefaultValue.DateTime || BusinessItem.LastModifiedByUserID != MOD.Data.DefaultValue.Guid || BusinessItem.LastModifiedDate != MOD.Data.DefaultValue.DateTime || BusinessItem.Timestamp != null))
							{
								BusinessAdded(this, new EntityEditEventArgs(_entity));
								// create new object and store it in _entity
								CreateNewEntity();
								Session["BusinessItem"] = _entity;
								this.sectionLinks.OnSection("Basics");
								SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
							}
						}
						else
						{
							Globals.AddStatusMessage("Business updated.");
						}
					}
					else
					{
						UpsertToDatabase(true);
						if (AccessMode == MOD.Data.AccessMode.Add)
						{
							doRedirect = true;
							Globals.AddStatusMessage("Business added.");
						}
						else
						{
							Globals.AddStatusMessage("Business updated.");
						}
						SetAccessModeAndDisplay(MOD.Data.AccessMode.Edit);
					}
				}
				else
				{
					Globals.AddErrorMessage(Page, "Business validation failed.");
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditBusiness.btnSave_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && isValid == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("MetaPartnerID", BusinessItem.MetaPartnerID.ToString());
				queryString.Add("BusinessMetaPartnerID", BusinessItem.MetaPartnerID.ToString());
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditBusiness.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditBusiness.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditBusiness.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditBusiness.Page_PreRender"));
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
		/// Create a new Business object reference
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void CreateNewEntity()
		{
			BLL.Customers.Business vBusiness = new BLL.Customers.Business();
			_entity = vBusiness;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update form from Business information.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyEntityToForm()
		{
			BLL.Customers.Business vBusiness = BusinessItem;
			lblMetaPartnerID.Text = MOD.Data.DataHelper.GetString(vBusiness.MetaPartnerID, "");
			txtServiceCharges.Text = MOD.Data.EditHelper.GetString(vBusiness.ServiceCharges);
			ddlMetaPartnerSubTypeCode.DataValueField = "PrimaryIndex";
			ddlMetaPartnerSubTypeCode.DataTextField = "PrimaryName";
			ddlMetaPartnerSubTypeCode.DataSource = BLL.Customers.MetaPartnerSubTypeManager.GetAllMetaPartnerSubTypeData(Globals.DBOptions, Globals.getDataOptions("MetaPartnerSubTypeName", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
			ddlMetaPartnerSubTypeCode.DataBind();
			ddlMetaPartnerSubTypeCode.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			ddlMetaPartnerSubTypeCode.Enabled = false;
			try
			{
				if (AccessMode == MOD.Data.AccessMode.Add)
				{
					ddlMetaPartnerSubTypeCode.SelectedValue = ddlMetaPartnerSubTypeCode.Items.FindByText("Business").Value;
				}
				else
				{
					ddlMetaPartnerSubTypeCode.SelectedValue = MOD.Data.DataHelper.GetString(vBusiness.MetaPartnerSubTypeCode, "");
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
				sLocale.LocaleCode = MOD.Data.DataHelper.GetInt(vBusiness.LocaleCode, MOD.Data.DefaultValue.Int);
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
				sCurrency.CurrencyCode = MOD.Data.DataHelper.GetInt(vBusiness.CurrencyCode, MOD.Data.DefaultValue.Int);
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
				sDateFormat.DateFormatCode = MOD.Data.DataHelper.GetInt(vBusiness.DateFormatCode, MOD.Data.DefaultValue.Int);
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
			txtTaxCode.Text = MOD.Data.EditHelper.GetString(vBusiness.TaxCode);
			chkIsActive.Checked = MOD.Data.DataHelper.GetBool(vBusiness.IsActive, MOD.Data.DefaultValue.Bool);
			txtMetaPartnerName.Text = MOD.Data.EditHelper.GetString(vBusiness.MetaPartnerName);
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
		/// <summary>Set Business information from the form.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyFormToEntity()
		{
			BLL.Customers.Business vBusiness = BusinessItem;
			if (vBusiness == null)
			{
				throw CoreUtility.CustomAppException.WrapException(new Exception("Business not found"), "EditBusiness.CopyFormToEntity()");
			}
			vBusiness.ServiceCharges = EditHelper.EncodeStringForDB(MOD.Data.DataHelper.GetString(txtServiceCharges.Text, null));
			if (ddlMetaPartnerSubTypeCode.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Customers.MetaPartnerSubType sMetaPartnerSubType = new BLL.Customers.MetaPartnerSubType(ddlMetaPartnerSubTypeCode.SelectedValue, false);
				vBusiness.MetaPartnerSubTypeCode = MOD.Data.DataHelper.GetInt(sMetaPartnerSubType.MetaPartnerSubTypeCode, MOD.Data.DefaultValue.Int);
				sMetaPartnerSubType = null;
			}
			if (ddlLocaleCode.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Environments.Locale sLocale = new BLL.Environments.Locale(ddlLocaleCode.SelectedValue, false);
				vBusiness.LocaleCode = MOD.Data.DataHelper.GetInt(sLocale.LocaleCode, MOD.Data.DefaultValue.Int);
				sLocale = null;
			}
			if (ddlCurrencyCode.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Accounts.Currency sCurrency = new BLL.Accounts.Currency(ddlCurrencyCode.SelectedValue, false);
				vBusiness.CurrencyCode = MOD.Data.DataHelper.GetInt(sCurrency.CurrencyCode, MOD.Data.DefaultValue.Int);
				sCurrency = null;
			}
			if (ddlDateFormatCode.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Environments.DateFormat sDateFormat = new BLL.Environments.DateFormat(ddlDateFormatCode.SelectedValue, false);
				vBusiness.DateFormatCode = MOD.Data.DataHelper.GetInt(sDateFormat.DateFormatCode, MOD.Data.DefaultValue.Int);
				sDateFormat = null;
			}
			vBusiness.TaxCode = EditHelper.EncodeStringForDB(MOD.Data.DataHelper.GetString(txtTaxCode.Text, null));
			vBusiness.IsActive = chkIsActive.Checked;
			vBusiness.MetaPartnerName = EditHelper.EncodeStringForDB(MOD.Data.DataHelper.GetString(txtMetaPartnerName.Text, null));
			vBusiness.PictureImageURL = txtPictureImageURL.SaveFile();
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// Load entity from database, store in _entity and Session["BusinessItem"]
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void LoadEntity()
		{
			_entity = null;
			Guid metaPartnerID = MOD.Data.DataHelper.GetGuid(Request.QueryString["MetaPartnerID"], MOD.Data.DefaultValue.Guid);
			if (metaPartnerID != MOD.Data.DefaultValue.Guid)
			{
				_entity = BLL.Customers.BusinessManager.GetOneBusiness(metaPartnerID, Globals.getDataOptions("", "", true, true));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update Business information in the database.</summary>
		///
		// ------------------------------------------------------------------------------
		private void UpsertToDatabase(bool performCascade)
		{
			BLL.Customers.Business vBusiness = BusinessItem;
			if (AccessMode == MOD.Data.AccessMode.Add)
			{
				BLL.Customers.BusinessManager.AddOneBusiness(vBusiness, performCascade);
			}
			else if (AccessMode == MOD.Data.AccessMode.Edit)
			{
				BLL.Customers.BusinessManager.UpdateOneBusiness(vBusiness, performCascade);
			}
			BusinessItem.MetaPartnerID = vBusiness.MetaPartnerID;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set access and display modes for presenting Business information.</summary>
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
					lblTitle.Text = "Add Business";
					btnSave.Text = "Add";
					break;
				case MOD.Data.AccessMode.Edit:
					lblTitle.Text = "Edit Business";
					btnSave.Text = "Save";
					break;
				case MOD.Data.AccessMode.View:
					lblTitle.Text = "View Business";
					break;
				default:
					lblTitle.Text = "View Business";
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
		/// <summary>Initialize component for Business, add delegates here.</summary>
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