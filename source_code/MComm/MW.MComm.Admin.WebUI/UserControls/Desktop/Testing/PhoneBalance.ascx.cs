
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
using MW.MComm.WalletSolution.MComm.Nuevatel.CustomerManager;
using MW.MComm.WalletSolution.MComm.SMS.SMSSender;
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
	public partial class PhoneBalance  : Components.Desktop.BaseFormlUserControl
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
				base.HandleError(MW.MComm.WalletSolution.Utility.CustomAppException.WrapException(ex, "PhoneBalance.Page_Load"));
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
						GetPhoneBalance();
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
				base.HandleError(MW.MComm.WalletSolution.Utility.CustomAppException.WrapException(ex, "PhoneBalance.btnSave_Click"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Save Pay To Phone.</summary>
		///
		// ------------------------------------------------------------------------------
		private void btnCredit_Click(object sender, EventArgs e)
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
				if (btnCredit.CausesValidation == true)
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
						IssuePhoneCredit();
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
				base.HandleError(MW.MComm.WalletSolution.Utility.CustomAppException.WrapException(ex, "PhoneBalance.btnSave_Click"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Save Pay To Phone.</summary>
		///
		// ------------------------------------------------------------------------------
		private void btnDebit_Click(object sender, EventArgs e)
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
				if (btnDebit.CausesValidation == true)
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
						IssuePhoneDebit();
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
				base.HandleError(MW.MComm.WalletSolution.Utility.CustomAppException.WrapException(ex, "PhoneBalance.btnSave_Click"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Save Pay To Phone.</summary>
		///
		// ------------------------------------------------------------------------------
		private void btnTariff_Click(object sender, EventArgs e)
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
				if (btnTariff.CausesValidation == true)
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
						IssuePhoneTariff();
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
				base.HandleError(MW.MComm.WalletSolution.Utility.CustomAppException.WrapException(ex, "PhoneBalance.btnSave_Click"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Save Pay To Phone.</summary>
		///
		// ------------------------------------------------------------------------------
		private void btnInfo_Click(object sender, EventArgs e)
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
				if (btnTariff.CausesValidation == true)
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
						GetCustomerInfo();
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
				base.HandleError(MW.MComm.WalletSolution.Utility.CustomAppException.WrapException(ex, "PhoneBalance.btnSave_Click"));
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
			catch (MW.MComm.WalletSolution.Utility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(MW.MComm.WalletSolution.Utility.CustomAppException.WrapException(ex, "PhoneBalance.Page_PreRender"));
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
		private void GetPhoneBalance()
		{
			try
			{
				// get balance from selected phone
				BLL.Customers.MetaPartnerPhone fromPhone = new BLL.Customers.MetaPartnerPhone(ddlFromMetaPartnerPhoneID.SelectedValue, false);
				fromPhone = BLL.Customers.MetaPartnerPhoneManager.GetOneMetaPartnerPhone(fromPhone.MetaPartnerPhoneID, Globals.DBOptions, Globals.getDataOptions("", ""), Globals.DebugLevel, Globals.CurrentUserID);
				BLL.Customers.MetaPartner fromMetaPartner = BLL.Customers.MetaPartnerManager.GetOneMetaPartner(fromPhone.MetaPartnerID, Globals.DBOptions, Globals.getDataOptions("", ""), Globals.DebugLevel, Globals.CurrentUserID);
				// build notification event data
				MOD.Data.NamedObjectCollection eventData = new MOD.Data.NamedObjectCollection();
				eventData[BLL.Events.EventAttributeCode.SourceName.ToString("D")] = fromMetaPartner.MetaPartnerName;
				eventData[BLL.Events.EventAttributeCode.SourcePhone.ToString("D")] = fromPhone.PhoneNumber;
				// get phone balance from web service
				MW.MComm.WalletSolution.MComm.Nuevatel.CustomerManager.Service1 s_NTWS = new MW.MComm.WalletSolution.MComm.Nuevatel.CustomerManager.Service1();
				s_NTWS.Credentials = System.Net.CredentialCache.DefaultCredentials;
				MW.MComm.WalletSolution.MComm.Nuevatel.CustomerManager.balance1Response response1 = s_NTWS.wsbalanceEnquiry1(fromPhone.PhoneNumber, "");
				if (response1.errorCode < 0 || response1.fullResponse == null || response1.fullResponse == string.Empty)
				{
					Globals.AddStatusMessage(response1.errorCode.ToString() + ": " + response1.errorMessage);
				}
				else
				{
					eventData[BLL.Events.EventAttributeCode.Balance.ToString("D")] = response1.balance.ToString();
					// get alternate balance responses
					MW.MComm.WalletSolution.MComm.Nuevatel.CustomerManager.balance2Response response2 = s_NTWS.wsbalanceEnquiry2(fromPhone.PhoneNumber, "");
					MW.MComm.WalletSolution.MComm.Nuevatel.CustomerManager.balance3Response response3 = s_NTWS.wsbalanceEnquiry3(fromPhone.PhoneNumber, "", decimal.Parse("20.00"));
					MW.MComm.WalletSolution.MComm.Nuevatel.CustomerManager.balance4Response response4 = s_NTWS.wsbalanceEnquiry4(fromPhone.PhoneNumber, "");
					// build meta partner list
					SortableObjectCollection metaPartnerList = new SortableObjectCollection();
					metaPartnerList.Add(fromMetaPartner);
					Globals.AddStatusMessage("Balance on phone for " + fromPhone.DisplayName + " is " + response1.balance.ToString() + " Bolivianos.");
					Globals.AddStatusMessage("Request1 is " + response1.fullRequest.ToString() + ".");
					Globals.AddStatusMessage("Response1 is " + response1.fullResponse.ToString() + ".");
					if (response2.errorCode < 0 || response2.fullResponse == null || response2.fullResponse == string.Empty)
					{
						Globals.AddStatusMessage(response2.errorCode.ToString() + ": " + response2.errorMessage);
					}
					else
					{
						Globals.AddStatusMessage("Request2 is " + response2.fullRequest.ToString() + ".");
						Globals.AddStatusMessage("Response2 is " + response2.fullResponse.ToString() + ".");
					}
					if (response3.errorCode < 0 || response3.fullResponse == null || response3.fullResponse == string.Empty)
					{
						Globals.AddStatusMessage(response3.errorCode.ToString() + ": " + response3.errorMessage);
					}
					else
					{
						Globals.AddStatusMessage("Request3 is " + response3.fullRequest.ToString() + ".");
						Globals.AddStatusMessage("Response3 is " + response3.fullResponse.ToString() + ".");
					}
					if (response4.errorCode < 0 || response4.fullResponse == null || response4.fullResponse == string.Empty)
					{
						Globals.AddStatusMessage(response4.errorCode.ToString() + ": " + response4.errorMessage);
					}
					else
					{
						Globals.AddStatusMessage("Request4 is " + response4.fullRequest.ToString() + ".");
						Globals.AddStatusMessage("Response4 is " + response4.fullResponse.ToString() + ".");
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
		/// <summary>Update Pay To Phone information in the database.</summary>
		///
		// ------------------------------------------------------------------------------
		private void IssuePhoneCredit()
		{
			try
			{
				// get balance from selected phone
				BLL.Customers.MetaPartnerPhone fromPhone = new BLL.Customers.MetaPartnerPhone(ddlFromMetaPartnerPhoneID.SelectedValue, false);
				fromPhone = BLL.Customers.MetaPartnerPhoneManager.GetOneMetaPartnerPhone(fromPhone.MetaPartnerPhoneID, Globals.DBOptions, Globals.getDataOptions("", ""), Globals.DebugLevel, Globals.CurrentUserID);
				BLL.Customers.MetaPartner fromMetaPartner = BLL.Customers.MetaPartnerManager.GetOneMetaPartner(fromPhone.MetaPartnerID, Globals.DBOptions, Globals.getDataOptions("", ""), Globals.DebugLevel, Globals.CurrentUserID);
				// build notification event data
				MOD.Data.NamedObjectCollection eventData = new MOD.Data.NamedObjectCollection();
				eventData[BLL.Events.EventAttributeCode.SourceName.ToString("D")] = fromMetaPartner.MetaPartnerName;
				eventData[BLL.Events.EventAttributeCode.SourcePhone.ToString("D")] = fromPhone.PhoneNumber;
				// get phone balance from web service
				MW.MComm.WalletSolution.MComm.Nuevatel.CustomerManager.Service1 s_NTWS = new MW.MComm.WalletSolution.MComm.Nuevatel.CustomerManager.Service1();
				s_NTWS.Credentials = System.Net.CredentialCache.DefaultCredentials;
				MW.MComm.WalletSolution.MComm.Nuevatel.CustomerManager.addCreditResponse creditResponse = s_NTWS.wsAddCredit(fromPhone.PhoneNumber, "", decimal.Parse(txtBalance.Text), "metawallet", "walmet3942", "IVR");
				if (creditResponse.errorCode < 0 || creditResponse.fullResponse == null || creditResponse.fullResponse == string.Empty)
				{
					Globals.AddStatusMessage(creditResponse.errorCode.ToString() + ": " + creditResponse.errorMessage);
				}
				else
				{
					Globals.AddStatusMessage(txtBalance.Text + " has been credited.");
					Globals.AddStatusMessage("Request is " + creditResponse.fullRequest.ToString() + ".");
					Globals.AddStatusMessage("Response is " + creditResponse.fullResponse.ToString() + ".");
					MW.MComm.WalletSolution.MComm.Nuevatel.CustomerManager.balance2Response response = s_NTWS.wsbalanceEnquiry2(fromPhone.PhoneNumber, "");
					if (response.errorCode < 0)
					{
						Globals.AddStatusMessage(response.errorCode.ToString() + ": " + response.errorMessage);
					}
					else
					{
						eventData[BLL.Events.EventAttributeCode.Balance.ToString("D")] = response.balance.ToString();
						// build meta partner list
						SortableObjectCollection metaPartnerList = new SortableObjectCollection();
						metaPartnerList.Add(fromMetaPartner);
						Globals.AddStatusMessage("Balance on phone for " + fromPhone.DisplayName + " is " + response.balance.ToString() + " Bolivianos.");
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
		/// <summary>Update Pay To Phone information in the database.</summary>
		///
		// ------------------------------------------------------------------------------
		private void IssuePhoneDebit()
		{
			try
			{
				// get balance from selected phone
				BLL.Customers.MetaPartnerPhone fromPhone = new BLL.Customers.MetaPartnerPhone(ddlFromMetaPartnerPhoneID.SelectedValue, false);
				fromPhone = BLL.Customers.MetaPartnerPhoneManager.GetOneMetaPartnerPhone(fromPhone.MetaPartnerPhoneID, Globals.DBOptions, Globals.getDataOptions("", ""), Globals.DebugLevel, Globals.CurrentUserID);
				BLL.Customers.MetaPartner fromMetaPartner = BLL.Customers.MetaPartnerManager.GetOneMetaPartner(fromPhone.MetaPartnerID, Globals.DBOptions, Globals.getDataOptions("", ""), Globals.DebugLevel, Globals.CurrentUserID);
				// build notification event data
				MOD.Data.NamedObjectCollection eventData = new MOD.Data.NamedObjectCollection();
				eventData[BLL.Events.EventAttributeCode.SourceName.ToString("D")] = fromMetaPartner.MetaPartnerName;
				eventData[BLL.Events.EventAttributeCode.SourcePhone.ToString("D")] = fromPhone.PhoneNumber;
				// get phone balance from web service
				MW.MComm.WalletSolution.MComm.Nuevatel.CustomerManager.Service1 s_NTWS = new MW.MComm.WalletSolution.MComm.Nuevatel.CustomerManager.Service1();
				s_NTWS.Credentials = System.Net.CredentialCache.DefaultCredentials;
				MW.MComm.WalletSolution.MComm.Nuevatel.CustomerManager.discount1Response discountResponse = s_NTWS.wsbalanceDiscount1(fromPhone.PhoneNumber, "", decimal.Parse(txtBalance.Text));
				if (discountResponse.errorCode < 0 || discountResponse.fullResponse == null || discountResponse.fullResponse == string.Empty)
				{
					Globals.AddStatusMessage(discountResponse.errorCode.ToString() + ": " + discountResponse.errorMessage);
				}
				else
				{
					Globals.AddStatusMessage(txtBalance.Text + " has been debited.");
					Globals.AddStatusMessage("Request is " + discountResponse.fullRequest.ToString() + ".");
					Globals.AddStatusMessage("Response is " + discountResponse.fullResponse.ToString() + ".");
					MW.MComm.WalletSolution.MComm.Nuevatel.CustomerManager.balance1Response response1 = s_NTWS.wsbalanceEnquiry1(fromPhone.PhoneNumber, "");
					MW.MComm.WalletSolution.MComm.Nuevatel.CustomerManager.balance4Response response4 = s_NTWS.wsbalanceEnquiry4(fromPhone.PhoneNumber, "");
					if (response1.errorCode < 0)
					{
						Globals.AddStatusMessage(response1.errorCode.ToString() + ": " + response1.errorMessage);
					}
					else
					{
						eventData[BLL.Events.EventAttributeCode.Balance.ToString("D")] = response1.balance.ToString();
						// build meta partner list
						SortableObjectCollection metaPartnerList = new SortableObjectCollection();
						metaPartnerList.Add(fromMetaPartner);
						Globals.AddStatusMessage("Balance on phone for " + fromPhone.DisplayName + " is " + response1.balance.ToString() + " Bolivianos.");
						Globals.AddStatusMessage("Free minutes on phone for " + fromPhone.DisplayName + " is " + response4.freeMinutes.ToString() + ".");
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
		/// <summary>Update Pay To Phone information in the database.</summary>
		///
		// ------------------------------------------------------------------------------
		private void IssuePhoneTariff()
		{
			try
			{
				// get balance from selected phone
				BLL.Customers.MetaPartnerPhone fromPhone = new BLL.Customers.MetaPartnerPhone(ddlFromMetaPartnerPhoneID.SelectedValue, false);
				fromPhone = BLL.Customers.MetaPartnerPhoneManager.GetOneMetaPartnerPhone(fromPhone.MetaPartnerPhoneID, Globals.DBOptions, Globals.getDataOptions("", ""), Globals.DebugLevel, Globals.CurrentUserID);
				BLL.Customers.MetaPartner fromMetaPartner = BLL.Customers.MetaPartnerManager.GetOneMetaPartner(fromPhone.MetaPartnerID, Globals.DBOptions, Globals.getDataOptions("", ""), Globals.DebugLevel, Globals.CurrentUserID);
				// build notification event data
				MOD.Data.NamedObjectCollection eventData = new MOD.Data.NamedObjectCollection();
				eventData[BLL.Events.EventAttributeCode.SourceName.ToString("D")] = fromMetaPartner.MetaPartnerName;
				eventData[BLL.Events.EventAttributeCode.SourcePhone.ToString("D")] = fromPhone.PhoneNumber;
				// get phone balance from web service
				MW.MComm.WalletSolution.MComm.Nuevatel.CustomerManager.Service1 s_NTWS = new MW.MComm.WalletSolution.MComm.Nuevatel.CustomerManager.Service1();
				s_NTWS.Credentials = System.Net.CredentialCache.DefaultCredentials;
				MW.MComm.WalletSolution.MComm.Nuevatel.CustomerManager.discount2Response discountResponse = s_NTWS.wsbalanceDiscount2(fromPhone.PhoneNumber, "", "2500001");
				if (discountResponse.errorCode < 0 || discountResponse.fullResponse == null || discountResponse.fullResponse == string.Empty)
				{
					Globals.AddStatusMessage(discountResponse.errorCode.ToString() + ": " + discountResponse.errorMessage);
				}
				else
				{
					Globals.AddStatusMessage(txtBalance.Text + " has been debited.");
					Globals.AddStatusMessage("Request is " + discountResponse.fullRequest.ToString() + ".");
					Globals.AddStatusMessage("Response is " + discountResponse.fullResponse.ToString() + ".");
					MW.MComm.WalletSolution.MComm.Nuevatel.CustomerManager.balance1Response response1 = s_NTWS.wsbalanceEnquiry1(fromPhone.PhoneNumber, "");
					MW.MComm.WalletSolution.MComm.Nuevatel.CustomerManager.balance4Response response4 = s_NTWS.wsbalanceEnquiry4(fromPhone.PhoneNumber, "");
					if (response1.errorCode < 0)
					{
						Globals.AddStatusMessage(response1.errorCode.ToString() + ": " + response1.errorMessage);
					}
					else
					{
						eventData[BLL.Events.EventAttributeCode.Balance.ToString("D")] = response1.balance.ToString();
						// build meta partner list
						SortableObjectCollection metaPartnerList = new SortableObjectCollection();
						metaPartnerList.Add(fromMetaPartner);
						// send notification
						BLL.Notifications.NotificationGenerator.SendNotificationsForEvent((int)BLL.Events.EventCode.PhoneAccountQueried, eventData, metaPartnerList, Globals.MailServer, Globals.MailSenderEmail, Globals.SMSSenderPhone, Globals.DBOptions, Globals.DebugLevel, Globals.CurrentUserID);
						Globals.AddStatusMessage("Balance on phone for " + fromPhone.DisplayName + " is " + response1.balance.ToString() + " Bolivianos.");
						Globals.AddStatusMessage("Free minutes on phone for " + fromPhone.DisplayName + " is " + response4.freeMinutes.ToString() + ".");
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
		/// <summary>Update Pay To Phone information in the database.</summary>
		///
		// ------------------------------------------------------------------------------
		private void GetCustomerInfo()
		{
			try
			{
				// get balance from selected phone
				BLL.Customers.MetaPartnerPhone fromPhone = new BLL.Customers.MetaPartnerPhone(ddlFromMetaPartnerPhoneID.SelectedValue, false);
				fromPhone = BLL.Customers.MetaPartnerPhoneManager.GetOneMetaPartnerPhone(fromPhone.MetaPartnerPhoneID, Globals.DBOptions, Globals.getDataOptions("", ""), Globals.DebugLevel, Globals.CurrentUserID);
				BLL.Customers.MetaPartner fromMetaPartner = BLL.Customers.MetaPartnerManager.GetOneMetaPartner(fromPhone.MetaPartnerID, Globals.DBOptions, Globals.getDataOptions("", ""), Globals.DebugLevel, Globals.CurrentUserID);
				// build notification event data
				MOD.Data.NamedObjectCollection eventData = new MOD.Data.NamedObjectCollection();
				eventData[BLL.Events.EventAttributeCode.SourceName.ToString("D")] = fromMetaPartner.MetaPartnerName;
				eventData[BLL.Events.EventAttributeCode.SourcePhone.ToString("D")] = fromPhone.PhoneNumber;
				// get customer info from web service
				MW.MComm.WalletSolution.MComm.Nuevatel.ClientInformation.ClientInfoService s_NTWS = new MW.MComm.WalletSolution.MComm.Nuevatel.ClientInformation.ClientInfoService();
				s_NTWS.Credentials = System.Net.CredentialCache.DefaultCredentials;
				string customerPhone = fromPhone.PhoneNumber;
				if (customerPhone.StartsWith("591") == true)
				{
					customerPhone = customerPhone.Substring(3);
				}
				MW.MComm.WalletSolution.MComm.Nuevatel.ClientInformation.consumptionEntityServicesForClient response = s_NTWS.getInformation("vivaClient", "0m3g41nf0", customerPhone);
				Globals.AddStatusMessage("Billing person name is: " + response.billingPersonFullName);
				Globals.AddStatusMessage("Billing house address is: " + response.billingPersonHouseAddress);
				Globals.AddStatusMessage("Billing work address is: " + response.billingPersonHouseAddress);
				Globals.AddStatusMessage("Client person name is: " + response.clientFullName);
				Globals.AddStatusMessage("Client house address is: " + response.clientHouseAddress);
				Globals.AddStatusMessage("Client work address is: " + response.clientWorkAddress);
				Globals.AddStatusMessage("Client birthday is: " + response.clientDateOfBirth);
				Globals.AddStatusMessage("Client document is: " + response.clientDocument);
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
			this.btnCredit.Click += new EventHandler(btnCredit_Click);
			this.btnDebit.Click += new EventHandler(btnDebit_Click);
			this.btnTariff.Click += new EventHandler(btnTariff_Click);
			this.btnInfo.Click += new EventHandler(btnInfo_Click);
			this.btnSave.Click += new EventHandler(btnSave_Click);
		}
		#endregion Web Form Designer generated code
	}
}