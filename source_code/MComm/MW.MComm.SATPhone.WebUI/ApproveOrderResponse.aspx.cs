
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
using MOD.Data;
using MW.MComm.WalletSolution.BLL.Accounts;
using MW.MComm.WalletSolution.BLL.Accounts;
using BLL = MW.MComm.WalletSolution.BLL;
using Utility = MW.MComm.WalletSolution.Utility;

namespace MW.MComm.SATPhone.WebUI
{

	// ------------------------------------------------------------------------------
	/// <summary>This page contains Edit Account controls for managing Account information.</summary>
	///
	/// File History:
	/// <created>9/1/2006 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class PayPhoneToPhone :  System.Web.UI.Page
	{
	
		// ------------------------------------------------------------------------------
		/// <summary>Load page for managing Account.</summary>
		///
		// ------------------------------------------------------------------------------
		private void Page_Load(object sender, System.EventArgs e)
		{
			this.Response.ContentType = "text/xml";
			int localeCode = (int)BLL.Environments.LocaleCode.SpanishBolivia;
			string customerPIN = "";
			string customerPhone = "";
			string orderStr = "";
			string message = "";

			try
			{
				txtStatus.Text = "";
				if (customerPIN == null || customerPIN.Trim() == "")
				{
					customerPIN = Request.QueryString.Get("PIN");
				}
				customerPhone = Request.Form.Get("Origen");
				if (customerPhone == null || customerPhone.Trim() == "")
				{
					customerPhone = Request.QueryString.Get("Origen");
				}
				orderStr = Request.Form.Get("OrderID");
				if (orderStr == null || orderStr.Trim() == "")
				{
					orderStr = Request.QueryString.Get("OrderID");
				}

				//EventLog.WriteEntry("MW.MComm.SATPhone.WebUI", "PageLoad:Origen(" + customerPhone + ")PIN(" + customerPIN + ")OrderID(" + orderStr + ")");
				
				GuidConverter guidC = new GuidConverter();
				Guid orderID = MOD.Data.DefaultValue.Guid;
				BLL.Orders.Order order = null;
				try
				{
					orderID = (Guid)guidC.ConvertFromString(orderStr);
					order = BLL.Orders.OrderManager.GetOneOrder(orderID);
				}
				catch (System.Exception ex)
				{
					message += ex.Message;
					throw new Utility.CustomAppException(BLL.Core.ErrorNumber.OrderApprovalFailure);
				}
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
					//message += "Order is null";
					throw new Utility.CustomAppException(BLL.Core.ErrorNumber.OrderApprovalFailure);
				}
				//message += "...approve..., order is " + order.OrderStatusName;
				order.Approve(customerPhone, customerPIN);
				//message += "...pay...";
				order.Pay();

				localeCode = order.DebitMetaPartner.LocaleCode;

				// send notification
				try
				{
					MOD.Data.NamedObjectCollection eventData = BLL.Notifications.NotificationGenerator.SendNotificationsForOrderEvent(BLL.Events.EventCode.PhoneToPhonePaymentTransferred, order, order.DebitMetaPartner, order.CreditMetaPartner, Globals.MailServer, Globals.MailSenderEmail, Globals.SMSSenderPhone);
					txtStatus.Text = "\r\n" + order.OrderAmount.ToString() + " " + order.Currency.CurrencyName + " was paid from " + customerPhone + " to " + eventData[BLL.Events.EventAttributeCode.DestinationPhone.ToString("D")] + ".";
				}
				catch
				{
					throw new Utility.CustomAppException(BLL.Core.ErrorNumber.BankCustomerNotFound);
				}
			}
			catch (Utility.CustomAppException ex)
			{
				if (ex.SeverityLevel != BLL.Core.SeverityLevelCode.None && ex.SeverityLevel != BLL.Core.SeverityLevelCode.OK)
				{
					Utility.CustomAppException.HandleException(ex);
				}
				txtStatus.Text += BLL.UserExperience.FriendlyErrorManager.GetFriendlyErrorMessage(ex.ErrorNumber, localeCode);
				txtStatus.Text += "\r\nOrderID: " + orderStr + ".";
				txtStatus.Text += "\r\nPIN: " + customerPIN + ".";
				txtStatus.Text += "\r\nOrigen: " + customerPhone + ".";
			}
			catch (System.Exception ex)
			{
				Utility.CustomAppException.HandleException(ex);
				txtStatus.Text += BLL.Core.ErrorManager.GetErrorMessageFromException(ex, localeCode, false);
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