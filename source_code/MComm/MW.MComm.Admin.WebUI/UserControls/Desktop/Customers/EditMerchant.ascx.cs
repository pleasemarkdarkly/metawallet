
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
	/// <summary>Edit Merchant is used to help manage Merchant information.</summary>
	///
	/// File History:
	/// <created>6/1/2007 (Chris Grundy)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class EditMerchant  : Components.Desktop.BaseFormlUserControl, Controls.IHaveUploadableFiles
	{
		#region IHaveUploadableFiles
		public string GetFileRelativePath(Controls.FileUploader ctl)
		{
			if (ctl == txtPictureImageURL)
				return MerchantItem.PictureImageURL;
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
		public event EntityEditEventHandler MerchantAdded;
		/// <summary>
		/// Raised when "Remove" button is clicked in internal mode.
		/// Container handles this event and removes entity from collection.
		/// </summary>
		public event EntityEditEventHandler MerchantRemoved;
		#endregion Events
		#region Declarations
		#endregion Declarations
		#region Properties
		/// <summary>
		/// The Merchant currently being edited by this control.
		/// Get accessor casts base._entity to Merchant
		/// Set accessor used by parent control to set the item currently being edited
		/// </summary>
		public BLL.Customers.Merchant MerchantItem
		{
			get
			{
				return (BLL.Customers.Merchant) _entity;
			}
			set
			{
				_entity = value; // only set by container
				Session["MerchantItem"] = _entity;
			}
		}
		#endregion Properties
		#region Event Handlers
		// ------------------------------------------------------------------------------
		/// <summary>Load page for editing Merchant, getting mode and parameters.</summary>
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
						_entity = (BLL.Customers.Merchant)Session["MerchantItem"];
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
					Session["MerchantItem"] = _entity;
				}
				// Assign entity collections into child controls
				listMetaPartnerPhoneData.Collection = MerchantItem.PhoneList;
				listMetaPartnerEmailData.Collection = MerchantItem.EmailList;
				listLocationData.Collection = MerchantItem.LocationList;
				listBankAccountData.Collection = MerchantItem.BankAccountList;
				listStoredValueAccountData.Collection = MerchantItem.StoredValueAccountList;
				listCreditAccountData.Collection = MerchantItem.CreditAccountList;
				listFundAccountData.Collection = MerchantItem.FundAccountList;
				listBillPayAccountData.Collection = MerchantItem.BillPayAccountList;
				listMetaTransferAccountData.Collection = MerchantItem.MetaTransferAccountList;
				listLoanAccountData.Collection = MerchantItem.LoanAccountList;
				listMetaPartnerCouponData.Collection = MerchantItem.MetaPartnerCouponList;
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditMerchant.Page_Load"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Delete Merchant.</summary>
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
					BLL.Customers.MerchantManager.DeleteOneMerchant(MerchantItem, performCascade);
					Globals.AddStatusMessage("Merchant deleted.");
				}
				else
				{
					// raise event so item is removed from collection
					if (MerchantRemoved != null)
					{
						MerchantRemoved(this, new EntityEditEventArgs(_entity));
					}
				}
				// create new object and store it in _entity
				CreateNewEntity();
				Session["MerchantItem"] = _entity;
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditMerchant.btnDelete_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("MetaPartnerID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("MerchantMetaPartnerID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Request to create a new Merchant.</summary>
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
				Session["MerchantItem"] = _entity;
				this.sectionLinks.OnSection("Basics");
				SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
				Globals.AddStatusMessage("Add new Merchant.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				doRedirect = false;
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				doRedirect = false;
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditMerchant.btnNew_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("MetaPartnerID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("MerchantMetaPartnerID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Reset form for Merchant.</summary>
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
					Session["MerchantItem"] = _entity;
					sectionLinks.CurrentSection = "Basics";
				}
				else
				{
					CreateNewEntity();
				}
				Globals.AddStatusMessage("Merchant reset.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditMerchant.btnReset_Click"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Save Merchant.</summary>
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
							if (MerchantAdded != null && (MerchantItem.MetaPartnerID != MOD.Data.DefaultValue.Guid || MerchantItem.CreatedByUserID != MOD.Data.DefaultValue.Guid || MerchantItem.CreatedDate != MOD.Data.DefaultValue.DateTime || MerchantItem.LastModifiedByUserID != MOD.Data.DefaultValue.Guid || MerchantItem.LastModifiedDate != MOD.Data.DefaultValue.DateTime || MerchantItem.Timestamp != null))
							{
								MerchantAdded(this, new EntityEditEventArgs(_entity));
								// create new object and store it in _entity
								CreateNewEntity();
								Session["MerchantItem"] = _entity;
								this.sectionLinks.OnSection("Basics");
								SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
							}
						}
						else
						{
							Globals.AddStatusMessage("Merchant updated.");
						}
					}
					else
					{
						UpsertToDatabase(true);
						if (AccessMode == MOD.Data.AccessMode.Add)
						{
							doRedirect = true;
							Globals.AddStatusMessage("Merchant added.");
						}
						else
						{
							Globals.AddStatusMessage("Merchant updated.");
						}
						SetAccessModeAndDisplay(MOD.Data.AccessMode.Edit);
					}
				}
				else
				{
					Globals.AddErrorMessage(Page, "Merchant validation failed.");
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditMerchant.btnSave_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && isValid == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("MetaPartnerID", MerchantItem.MetaPartnerID.ToString());
				queryString.Add("MerchantMetaPartnerID", MerchantItem.MetaPartnerID.ToString());
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditMerchant.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditMerchant.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditMerchant.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditMerchant.Page_PreRender"));
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
		/// Create a new Merchant object reference
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void CreateNewEntity()
		{
			BLL.Customers.Merchant vMerchant = new BLL.Customers.Merchant();
			_entity = vMerchant;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update form from Merchant information.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyEntityToForm()
		{
			BLL.Customers.Merchant vMerchant = MerchantItem;
			lblMetaPartnerID.Text = MOD.Data.DataHelper.GetString(vMerchant.MetaPartnerID, "");
			txtServiceCharges.Text = MOD.Data.EditHelper.GetString(vMerchant.ServiceCharges);
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
					ddlMetaPartnerSubTypeCode.SelectedValue = ddlMetaPartnerSubTypeCode.Items.FindByText("Merchant").Value;
				}
				else
				{
					ddlMetaPartnerSubTypeCode.SelectedValue = MOD.Data.DataHelper.GetString(vMerchant.MetaPartnerSubTypeCode, "");
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
				sLocale.LocaleCode = MOD.Data.DataHelper.GetInt(vMerchant.LocaleCode, MOD.Data.DefaultValue.Int);
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
				sCurrency.CurrencyCode = MOD.Data.DataHelper.GetInt(vMerchant.CurrencyCode, MOD.Data.DefaultValue.Int);
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
				sDateFormat.DateFormatCode = MOD.Data.DataHelper.GetInt(vMerchant.DateFormatCode, MOD.Data.DefaultValue.Int);
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
			txtTaxCode.Text = MOD.Data.EditHelper.GetString(vMerchant.TaxCode);
			chkIsActive.Checked = MOD.Data.DataHelper.GetBool(vMerchant.IsActive, MOD.Data.DefaultValue.Bool);
			txtMetaPartnerName.Text = MOD.Data.EditHelper.GetString(vMerchant.MetaPartnerName);
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
		/// <summary>Set Merchant information from the form.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyFormToEntity()
		{
			BLL.Customers.Merchant vMerchant = MerchantItem;
			if (vMerchant == null)
			{
				throw CoreUtility.CustomAppException.WrapException(new Exception("Merchant not found"), "EditMerchant.CopyFormToEntity()");
			}
			vMerchant.ServiceCharges = EditHelper.EncodeStringForDB(MOD.Data.DataHelper.GetString(txtServiceCharges.Text, null));
			if (ddlMetaPartnerSubTypeCode.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Customers.MetaPartnerSubType sMetaPartnerSubType = new BLL.Customers.MetaPartnerSubType(ddlMetaPartnerSubTypeCode.SelectedValue, false);
				vMerchant.MetaPartnerSubTypeCode = MOD.Data.DataHelper.GetInt(sMetaPartnerSubType.MetaPartnerSubTypeCode, MOD.Data.DefaultValue.Int);
				sMetaPartnerSubType = null;
			}
			if (ddlLocaleCode.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Environments.Locale sLocale = new BLL.Environments.Locale(ddlLocaleCode.SelectedValue, false);
				vMerchant.LocaleCode = MOD.Data.DataHelper.GetInt(sLocale.LocaleCode, MOD.Data.DefaultValue.Int);
				sLocale = null;
			}
			if (ddlCurrencyCode.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Accounts.Currency sCurrency = new BLL.Accounts.Currency(ddlCurrencyCode.SelectedValue, false);
				vMerchant.CurrencyCode = MOD.Data.DataHelper.GetInt(sCurrency.CurrencyCode, MOD.Data.DefaultValue.Int);
				sCurrency = null;
			}
			if (ddlDateFormatCode.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Environments.DateFormat sDateFormat = new BLL.Environments.DateFormat(ddlDateFormatCode.SelectedValue, false);
				vMerchant.DateFormatCode = MOD.Data.DataHelper.GetInt(sDateFormat.DateFormatCode, MOD.Data.DefaultValue.Int);
				sDateFormat = null;
			}
			vMerchant.TaxCode = EditHelper.EncodeStringForDB(MOD.Data.DataHelper.GetString(txtTaxCode.Text, null));
			vMerchant.IsActive = chkIsActive.Checked;
			vMerchant.MetaPartnerName = EditHelper.EncodeStringForDB(MOD.Data.DataHelper.GetString(txtMetaPartnerName.Text, null));
			vMerchant.PictureImageURL = txtPictureImageURL.SaveFile();
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// Load entity from database, store in _entity and Session["MerchantItem"]
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void LoadEntity()
		{
			_entity = null;
			Guid metaPartnerID = MOD.Data.DataHelper.GetGuid(Request.QueryString["MetaPartnerID"], MOD.Data.DefaultValue.Guid);
			if (metaPartnerID != MOD.Data.DefaultValue.Guid)
			{
				_entity = BLL.Customers.MerchantManager.GetOneMerchant(metaPartnerID, Globals.getDataOptions("", "", true, true));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update Merchant information in the database.</summary>
		///
		// ------------------------------------------------------------------------------
		private void UpsertToDatabase(bool performCascade)
		{
			BLL.Customers.Merchant vMerchant = MerchantItem;
			if (AccessMode == MOD.Data.AccessMode.Add)
			{
				BLL.Customers.MerchantManager.AddOneMerchant(vMerchant, performCascade);
			}
			else if (AccessMode == MOD.Data.AccessMode.Edit)
			{
				BLL.Customers.MerchantManager.UpdateOneMerchant(vMerchant, performCascade);
			}
			MerchantItem.MetaPartnerID = vMerchant.MetaPartnerID;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set access and display modes for presenting Merchant information.</summary>
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
					lblTitle.Text = "Add Merchant";
					btnSave.Text = "Add";
					break;
				case MOD.Data.AccessMode.Edit:
					lblTitle.Text = "Edit Merchant";
					btnSave.Text = "Save";
					break;
				case MOD.Data.AccessMode.View:
					lblTitle.Text = "View Merchant";
					break;
				default:
					lblTitle.Text = "View Merchant";
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
		/// <summary>Initialize component for Merchant, add delegates here.</summary>
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