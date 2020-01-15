
/*<copyright>
	MOD Systems, Inc (c) 2006 All Rights Reserved.
	720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
	All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by MOD Systems.  The contents also may only be viewed by MOD Systems Engineers (employees) and selected Starbucks employees as outlined in the Licensing Agreement between MOD Systems and Starbucks Corporation on June 3rd, 2005.
	No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
	No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact MOD System's competitive advantage.
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
using MW.MComm.WalletSolution.BLL.Accounts;
using MW.MComm.WalletSolution.BLL.Accounts;
using BLL = MW.MComm.WalletSolution.BLL;
using MW.MComm.WalletSolution.Utility;
using MW.MComm.Admin.WebUI.Components.Desktop;
namespace MW.MComm.Admin.WebUI.UserControls.Desktop.Testing
{
	// ------------------------------------------------------------------------------
	/// <summary>Edit Pay To Phone is used to help manage StoredValueAccount information.</summary>
	///
	/// File History:
	/// <created>9/5/2006 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class PayPhoneToPhone  : Components.Desktop.BaseFormlUserControl
	{
		#region Events
		#endregion Events
		#region Declarations
		#endregion Declarations
		#region Properties
		#endregion Properties
		#region Event Handlers
		// ------------------------------------------------------------------------------
		/// <summary>Load page for editing Pay To Phone, getting mode and parameters.</summary>
		///
		// ------------------------------------------------------------------------------
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				base.OnLoad();
				if (IsPostBack == true)
				{
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
				}
			}
			catch (MW.MComm.WalletSolution.Utility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(MW.MComm.WalletSolution.Utility.CustomAppException.WrapException(ex, "PayPhoneToPhone.Page_Load"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Reset form for Pay To Phone.</summary>
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
				Globals.AddStatusMessage("Pay To Phone reset.");
			}
			catch (MW.MComm.WalletSolution.Utility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(MW.MComm.WalletSolution.Utility.CustomAppException.WrapException(ex, "PayPhoneToPhone.btnReset_Click"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Save Pay To Phone.</summary>
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
						}
						else
						{
							Globals.AddStatusMessage("Pay To Phone updated.");
						}
					}
					else
					{
						UpsertToDatabase(true);
						SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
					}
				}
				else
				{
					Globals.AddErrorMessage(Page, "Pay To Phone validation failed.");
				}
			}
			catch (MW.MComm.WalletSolution.Utility.CustomAppException ex)
			{
				doRedirect = false;
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				doRedirect = false;
				base.HandleError(MW.MComm.WalletSolution.Utility.CustomAppException.WrapException(ex, "PayPhoneToPhone.btnSave_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && isValid == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
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
			catch (MW.MComm.WalletSolution.Utility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(MW.MComm.WalletSolution.Utility.CustomAppException.WrapException(ex, "PayPhoneToPhone.Page_PreRender"));
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
		/// Create a new Pay To Phone object reference
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void CreateNewEntity()
		{
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update form from Pay To Phone information.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyEntityToForm()
		{
			ddlFromMetaPartnerPhoneID.DataValueField = "PrimaryIndex";
			ddlFromMetaPartnerPhoneID.DataTextField = "DisplayName";
			if (UseWorkingSets == true && Session["Customers/MetaPartnerPhoneWorkingSet"] != null)
			{
				MOD.Data.SortableObjectCollection currentSource = (MOD.Data.SortableObjectCollection) Session["Customers/MetaPartnerPhoneWorkingSet"];
				ddlFromMetaPartnerPhoneID.DataSource = currentSource;
				lnkFromMetaPartnerPhoneIDWorkingSet.Visible = true;
				lnkFromMetaPartnerPhoneIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Customers/SearchMetaPartnerPhoneData.aspx");
				lblFromMetaPartnerPhoneIDWorkingSet.Visible = true;
				lblFromMetaPartnerPhoneIDWorkingSet.Text = " (from Meta Partner Phone working set)";
			}
			else
			{
				ddlFromMetaPartnerPhoneID.DataSource = MW.MComm.WalletSolution.BLL.Customers.MetaPartnerPhoneManager.GetAllMetaPartnerPhoneData(Globals.DBOptions, Globals.getDataOptions("PhoneNumber", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
				lblFromMetaPartnerPhoneIDWorkingSet.Visible = false;
				if (UseWorkingSets == true)
				{
					lnkFromMetaPartnerPhoneIDWorkingSet.Visible = true;
					lnkFromMetaPartnerPhoneIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Customers/SearchMetaPartnerPhoneData.aspx");
				}
				else
				{
					lnkFromMetaPartnerPhoneIDWorkingSet.Visible = false;
				}
			}
			ddlFromMetaPartnerPhoneID.DataBind();
			ddlFromMetaPartnerPhoneID.Items.Insert(0, new ListItem(" -- none -- ", ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				MW.MComm.WalletSolution.BLL.Customers.MetaPartnerPhone sMetaPartnerPhone = new MW.MComm.WalletSolution.BLL.Customers.MetaPartnerPhone();
				ddlFromMetaPartnerPhoneID.SelectedValue = MOD.Data.DataHelper.GetString(sMetaPartnerPhone.PrimaryIndex, "");
				sMetaPartnerPhone = null;
			}
			catch {}
			if (ddlFromMetaPartnerPhoneID.SelectedValue == ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				try
				{
					ddlFromMetaPartnerPhoneID.SelectedValue = MOD.Data.DataHelper.GetString(Session["Customers/MetaPartnerPhoneWorkingSetItem"], "");
				}
				catch {}
			}
			ddlToMetaPartnerPhoneID.DataValueField = "PrimaryIndex";
			ddlToMetaPartnerPhoneID.DataTextField = "DisplayName";
			if (UseWorkingSets == true && Session["Customers/MetaPartnerPhoneWorkingSet"] != null)
			{
				MOD.Data.SortableObjectCollection currentSource = (MOD.Data.SortableObjectCollection)Session["Customers/MetaPartnerPhoneWorkingSet"];
				ddlToMetaPartnerPhoneID.DataSource = currentSource;
				lnkToMetaPartnerPhoneIDWorkingSet.Visible = true;
				lnkToMetaPartnerPhoneIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Customers/SearchMetaPartnerPhoneData.aspx");
				lblToMetaPartnerPhoneIDWorkingSet.Visible = true;
				lblToMetaPartnerPhoneIDWorkingSet.Text = " (from Meta Partner Phone working set)";
			}
			else
			{
				ddlToMetaPartnerPhoneID.DataSource = MW.MComm.WalletSolution.BLL.Customers.MetaPartnerPhoneManager.GetAllMetaPartnerPhoneData(Globals.DBOptions, Globals.getDataOptions("PhoneNumber", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
				lblToMetaPartnerPhoneIDWorkingSet.Visible = false;
				if (UseWorkingSets == true)
				{
					lnkToMetaPartnerPhoneIDWorkingSet.Visible = true;
					lnkToMetaPartnerPhoneIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Customers/SearchMetaPartnerPhoneData.aspx");
				}
				else
				{
					lnkToMetaPartnerPhoneIDWorkingSet.Visible = false;
				}
			}
			ddlToMetaPartnerPhoneID.DataBind();
			ddlToMetaPartnerPhoneID.Items.Insert(0, new ListItem(" -- none -- ", ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				MW.MComm.WalletSolution.BLL.Customers.MetaPartnerPhone sMetaPartnerPhone = new MW.MComm.WalletSolution.BLL.Customers.MetaPartnerPhone();
				ddlToMetaPartnerPhoneID.SelectedValue = MOD.Data.DataHelper.GetString(sMetaPartnerPhone.PrimaryIndex, "");
				sMetaPartnerPhone = null;
			}
			catch { }
			if (ddlToMetaPartnerPhoneID.SelectedValue == ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				try
				{
					ddlToMetaPartnerPhoneID.SelectedValue = MOD.Data.DataHelper.GetString(Session["Customers/MetaPartnerPhoneWorkingSetItem"], "");
				}
				catch { }
			}
			ddlCurrencyCode.DataValueField = "PrimaryIndex";
			ddlCurrencyCode.DataTextField = "PrimaryName";
			ddlCurrencyCode.DataSource = MW.MComm.WalletSolution.BLL.Accounts.CurrencyManager.GetAllCurrencyData(Globals.DBOptions, Globals.getDataOptions("CurrencyName", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
			ddlCurrencyCode.DataBind();
			ddlCurrencyCode.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				MW.MComm.WalletSolution.BLL.Accounts.Currency sCurrency = new MW.MComm.WalletSolution.BLL.Accounts.Currency();
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
			// Drop downs should be disabled when control is "Internal" and either value is constrained by container
			if (WorkflowMode == WorkflowMode.Internal)
			{
				ddlCurrencyCode.Visible = Request.QueryString["CurrencyCode"] == null;
				valCurrencyCode.Enabled = Request.QueryString["CurrencyCode"] == null;
				lblCurrencyCodeDisplay.Visible = Request.QueryString["CurrencyCode"] == null;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set Pay To Phone information from the form.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyFormToEntity()
		{
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
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update Pay To Phone information in the database.</summary>
		///
		// ------------------------------------------------------------------------------
		private void UpsertToDatabase(bool performCascade)
		{
			try
			{
				// TODO: this test converts entire balances so that currency conversion is going too far
				bool canConvert = true;
				BLL.Customers.MetaPartnerPhone fromPhone = new BLL.Customers.MetaPartnerPhone(ddlFromMetaPartnerPhoneID.SelectedValue, false);
				fromPhone = BLL.Customers.MetaPartnerPhoneManager.GetOneMetaPartnerPhone(fromPhone.MetaPartnerPhoneID, Globals.DBOptions, Globals.getDataOptions("", ""), Globals.DebugLevel, Globals.CurrentUserID);
				BLL.Customers.MetaPartner fromMetaPartner = BLL.Customers.MetaPartnerManager.GetOneMetaPartner(fromPhone.MetaPartnerID, Globals.DBOptions, Globals.getDataOptions("", ""), Globals.DebugLevel, Globals.CurrentUserID);
				BLL.Customers.MetaPartnerPhone toPhone = new BLL.Customers.MetaPartnerPhone(ddlToMetaPartnerPhoneID.SelectedValue, false);
				toPhone = BLL.Customers.MetaPartnerPhoneManager.GetOneMetaPartnerPhone(toPhone.MetaPartnerPhoneID, Globals.DBOptions, Globals.getDataOptions("", ""), Globals.DebugLevel, Globals.CurrentUserID);
				BLL.Customers.MetaPartner toMetaPartner = BLL.Customers.MetaPartnerManager.GetOneMetaPartner(toPhone.MetaPartnerID, Globals.DBOptions, Globals.getDataOptions("", ""), Globals.DebugLevel, Globals.CurrentUserID);
				BLL.Accounts.Currency currency = new BLL.Accounts.Currency(ddlCurrencyCode.SelectedValue, false);
				currency = BLL.Accounts.CurrencyManager.GetOneCurrency(currency.CurrencyCode, Globals.DBOptions, Globals.getDataOptions("", ""), Globals.DebugLevel, Globals.CurrentUserID);
				// perform payment transfer validation
				BLL.Accounts.StoredValueAccount fromAccount = fromMetaPartner.PrimaryStoredValueAccount;
				BLL.Accounts.StoredValueAccount toAccount = toMetaPartner.PrimaryStoredValueAccount;
				if (fromAccount == null)
				{
					Globals.AddErrorMessage(Page, "No stored value account was found for " + fromPhone.DisplayName + ", payment transfer failed.");
				}
				else if (toAccount == null)
				{
					Globals.AddErrorMessage(Page, "No stored value account was found for " + toPhone.DisplayName + ", payment transfer failed.");
				}
				else
				{
					decimal? fromBalance = fromAccount.CarrierBalance;
					decimal? toBalance = toAccount.CarrierBalance;
					if (currency.CurrencyCode != fromAccount.CurrencyCode)
					{
						// convert to current currency
						canConvert = false;
						foreach (BLL.Accounts.CurrencyConversion loopConversion in BLL.Accounts.CurrencyConversionManager.GetAllCurrencyConversionData(Globals.DBOptions, Globals.getDataOptions("", ""), Globals.DebugLevel, Globals.CurrentUserID))
						{
							if (loopConversion.ConvertFromCurrencyCode == fromAccount.CurrencyCode && loopConversion.ConvertToCurrencyCode == currency.CurrencyCode)
							{
								fromBalance = fromBalance * decimal.Parse(loopConversion.ConversionRate.ToString());
								canConvert = true;
								break;
							}
						}
					}
					if (currency.CurrencyCode != toAccount.CurrencyCode && canConvert == true)
					{
						// convert to current currency
						canConvert = false;
						foreach (BLL.Accounts.CurrencyConversion loopConversion in BLL.Accounts.CurrencyConversionManager.GetAllCurrencyConversionData(Globals.DBOptions, Globals.getDataOptions("", ""), Globals.DebugLevel, Globals.CurrentUserID))
						{
							if (loopConversion.ConvertFromCurrencyCode == toAccount.CurrencyCode && loopConversion.ConvertToCurrencyCode == currency.CurrencyCode)
							{
								toBalance = toBalance * decimal.Parse(loopConversion.ConversionRate.ToString());
								canConvert = true;
								break;
							}
						}
					}
					if (canConvert == false)
					{
						Globals.AddErrorMessage(Page, "Proper conversion rates to " + currency.CurrencyName + " cannot be found, payment transfer failed.");
					}
					else
					{
						decimal transferAmount = decimal.Parse(txtBalance.Text);
						if (transferAmount > fromBalance)
						{
							Globals.AddErrorMessage(Page, "The balance of " + fromBalance + " " + currency.CurrencyName + " from the stored value account of " + fromPhone.DisplayName + " was not enough, payment transfer failed.");
						}
						else
						{
							fromBalance -= transferAmount;
							toBalance += transferAmount;
							canConvert = true;
							if (currency.CurrencyCode != fromAccount.CurrencyCode)
							{
								// convert to current currency
								canConvert = false;
								foreach (BLL.Accounts.CurrencyConversion loopConversion in BLL.Accounts.CurrencyConversionManager.GetAllCurrencyConversionData(Globals.DBOptions, Globals.getDataOptions("", ""), Globals.DebugLevel, Globals.CurrentUserID))
								{
									if (loopConversion.ConvertToCurrencyCode == fromAccount.CurrencyCode && loopConversion.ConvertFromCurrencyCode == currency.CurrencyCode)
									{
										fromBalance = fromBalance * decimal.Parse(loopConversion.ConversionRate.ToString());
										canConvert = true;
										break;
									}
								}
							}
							if (currency.CurrencyCode != toAccount.CurrencyCode && canConvert == true)
							{
								// convert to current currency
								canConvert = false;
								foreach (BLL.Accounts.CurrencyConversion loopConversion in BLL.Accounts.CurrencyConversionManager.GetAllCurrencyConversionData(Globals.DBOptions, Globals.getDataOptions("", ""), Globals.DebugLevel, Globals.CurrentUserID))
								{
									if (loopConversion.ConvertToCurrencyCode == toAccount.CurrencyCode && loopConversion.ConvertFromCurrencyCode == currency.CurrencyCode)
									{
										toBalance = toBalance * decimal.Parse(loopConversion.ConversionRate.ToString());
										canConvert = true;
										break;
									}
								}
							}
							if (canConvert == false)
							{
								Globals.AddErrorMessage(Page, "Proper conversion rates to " + currency.CurrencyName + " cannot be found, payment transfer failed.");
							}
							BLL.Orders.Order order = BLL.Orders.OrderManager.InitiateOrder(fromPhone, fromAccount, toPhone, toAccount, transferAmount, (int)BLL.Accounts.CurrencyCode.Bolivianos, "Testing.");
							// skip approval confirmaion
							order.OrderStatusCode = (int) BLL.Orders.OrderStatusCode.Approved;
							order.Save();
							order.Pay();
							// send notification
							MOD.Data.NamedObjectCollection eventData = BLL.Notifications.NotificationGenerator.SendNotificationsForOrderEvent(BLL.Events.EventCode.PhoneToPhonePaymentTransferred, order, order.DebitMetaPartner, order.CreditMetaPartner, Globals.MailServer, Globals.MailSenderEmail, Globals.SMSSenderPhone);
							Globals.AddStatusMessage(txtBalance.Text + " " + currency.CurrencyName + " was paid from " + fromPhone.DisplayName + " to " + toPhone.DisplayName + ".");
							Globals.AddStatusMessage("Balance on stored value account for " + fromPhone.DisplayName + " is " + fromAccount.CarrierBalance + " " + fromAccount.CurrencyName + ".");
							Globals.AddStatusMessage("Balance on stored value account for " + toPhone.DisplayName + " is " + toAccount.CarrierBalance + " " + toAccount.CurrencyName + ".");
						}
					}
				}
			}
			catch (System.Exception ex)
			{
				while (ex != null)
				{
					Globals.AddErrorMessage(Page, ex.Message);
					ex = ex.InnerException;
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set access and display modes for presenting Pay To Phone information.</summary>
		///
		// ------------------------------------------------------------------------------
		private void SetAccessModeAndDisplay(MOD.Data.AccessMode accessMode)
		{
			// set access mode
			AccessMode = accessMode;
			btnSave.Visible = IsEditAvailable || IsAddAvailable;
			// set workflow display
			if (WorkflowMode == MOD.Data.WorkflowMode.Internal)
			{
				btnReset.Visible = false;
			}
			else
			{
				btnReset.Visible = IsEditAvailable || IsAddAvailable;
			}
			// set display mode display
			if (DisplayMode == DisplayMode.TabbedView)
			{
				Section_Basics.Visible = true;
				this.DetailNavigation.Visible = true;
				this.SectionLinkContent.Visible = true;
				this.ButtonsInfo.Visible = true;
				this.btnSave.CausesValidation = false;
				foreach (string section in sectionLinks.ValidationList.Split(','))
				{
					if (section == sectionLinks.CurrentSection)
					{
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
				this.DetailNavigation.Visible = false;
				this.SectionLinkContent.Visible = false;
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
			this.btnReset.Click += new EventHandler(btnReset_Click);
			this.btnSave.Click += new EventHandler(btnSave_Click);
		}
		#endregion Web Form Designer generated code
	}
}