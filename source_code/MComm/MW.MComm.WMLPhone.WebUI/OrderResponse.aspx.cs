
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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Diagnostics;
using BLL = MW.MComm.WalletSolution.BLL;
using Utility = MW.MComm.WalletSolution.Utility;
using MW.MComm.WalletSolution.BLL.UserExperience;
namespace MW.MComm.WMLPhone.WebUI
{
	// ------------------------------------------------------------------------------
	/// <summary>This page contains Edit Account controls for managing Account information.</summary>
	///
	/// File History:
	/// <created>9/1/2006 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class OrderResponse : System.Web.UI.MobileControls.MobilePage
	{
		// ------------------------------------------------------------------------------
		/// <summary>Load page for managing Account.</summary>
		///
		// ------------------------------------------------------------------------------
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Set up site labels
			lblHeader.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.MetaWalletHeader);
			lblTagline.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.MetaWalletTagline);
			lblSendReceive.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.SendAndReceiveLink);
			lblAccountsLink.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.ManageAccountsLink);
			lblPreferences.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.UserPreferencesLink);
			lblNewAccountLink.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.NewAccountLink);
			lblHelpLink.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.HelpPageLink);
			lblOrderTitle.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.ApproveOrderTitle);
			lblPIN.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.PINLabel) + ":";
			btnSubmit.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.SendButtonLabel);
			lblOrderDetail.Text = "";
			lblStatus.Text = "";
			string customerPIN = txtPIN.Text.Trim();
			string orderStr = Request.QueryString.Get("OrderID");
			string customerPhone = Request.QueryString.Get("SourcePhone");
			int localeCode = (int)BLL.Environments.LocaleCode.SpanishBolivia;
			GuidConverter guidC = new GuidConverter();
			Guid orderID = MOD.Data.DefaultValue.Guid;
			BLL.Orders.Order order = null;
			try
			{
				orderID = (Guid)guidC.ConvertFromString(orderStr);
				order = BLL.Orders.OrderManager.GetOneOrder(orderID);
                //[20070622 SBA] Reemplazo 
                //lblOrderDetail.Text = "Payment requested from " + order.DebitMetaPartner.MetaPartnerName + " to " + order.CreditMetaPartner.MetaPartnerName + " for " + order.OrderAmount;
                lblOrderDetail.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.PaymentRequestedFrom) + " " + order.DebitMetaPartner.MetaPartnerName + " " + Globals.GetSiteLabel(SiteLabelDefinitionCode.To) + " " + order.CreditMetaPartner.MetaPartnerName + " " + Globals.GetSiteLabel(SiteLabelDefinitionCode.For) + " " + order.OrderAmount;
			}
			catch (System.Exception ex)
			{
				throw new Utility.CustomAppException(BLL.Core.ErrorNumber.OrderApprovalFailure);
			}
			try
			{
				// initiate order
				if (Page.IsPostBack == true)
				{
					if (customerPIN == null || customerPIN == string.Empty)
					{
						throw new Utility.CustomAppException(BLL.Core.ErrorNumber.CustomerPINinvalid);
					}
					if (customerPhone == null || customerPhone == string.Empty)
					{
						throw new Utility.CustomAppException(BLL.Core.ErrorNumber.SenderPhoneNotFound);
					}
					customerPhone = customerPhone.Trim();
					if (order == null)
					{
						throw new Utility.CustomAppException(BLL.Core.ErrorNumber.OrderApprovalFailure);
					}
					order.Approve(customerPhone, customerPIN);
					order.Pay();
					localeCode = order.DebitMetaPartner.LocaleCode;
					lblPIN.Visible = false;
					txtPIN.Visible = false;
					btnSubmit.Visible = false;
					// send notification
					try
					{
						MOD.Data.NamedObjectCollection eventData = BLL.Notifications.NotificationGenerator.SendNotificationsForOrderEvent(BLL.Events.EventCode.PhoneToPhonePaymentTransferred, order, order.DebitMetaPartner, order.CreditMetaPartner, Globals.MailServer, Globals.MailSenderEmail, Globals.SMSSenderPhone);
                        //[20070622 SBA] Reemplazo 
                        //lblStatus.Text = order.OrderAmount.ToString() + " " + order.Currency.CurrencyName + " was paid from " + customerPhone + " to " + eventData[BLL.Events.EventAttributeCode.DestinationPhone.ToString("D")] + ".";
                        lblStatus.Text = order.OrderAmount.ToString() + " " + order.Currency.CurrencyName + " " + Globals.GetSiteLabel(SiteLabelDefinitionCode.WasPaidFrom) + " " + customerPhone + " " + Globals.GetSiteLabel(SiteLabelDefinitionCode.To) + " " + eventData[BLL.Events.EventAttributeCode.DestinationPhone.ToString("D")] + ".";
					}
					catch
					{
						throw new Utility.CustomAppException(BLL.Core.ErrorNumber.BankCustomerNotFound);
					}
				}
			}
			catch (Utility.CustomAppException ex)
			{
				if (ex.SeverityLevel != BLL.Core.SeverityLevelCode.None && ex.SeverityLevel != BLL.Core.SeverityLevelCode.OK)
				{
					Utility.CustomAppException.HandleException(ex);
				}
				lblStatus.Text = BLL.UserExperience.FriendlyErrorManager.GetFriendlyErrorMessage(ex.ErrorNumber, localeCode);
			}
			catch (System.Exception ex)
			{
				Utility.CustomAppException.HandleException(ex);
				lblStatus.Text = BLL.Core.ErrorManager.GetErrorMessageFromException(ex, localeCode, false);
			}
		}
		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}