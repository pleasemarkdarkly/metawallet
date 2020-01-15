
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
using System.ComponentModel;
using MOD.Data;
using MW.MComm.WalletSolution.BLL.Accounts;
using MW.MComm.WalletSolution.BLL.Accounts;
using BLL = MW.MComm.WalletSolution.BLL;
using Utility = MW.MComm.WalletSolution.Utility;
using MW.MComm.Phone.WebUI.Components.Desktop;
using MW.MComm.WalletSolution.MComm.Nuevatel.CustomerManager;
using MW.MComm.WalletSolution.MComm.SMS.SMSSender;

namespace MW.MComm.Phone.WebUI.UserControls.Desktop.Phone

{
	// ------------------------------------------------------------------------------
	/// <summary>Edit Pay To Phone is used to help manage StoredValueAccount information.</summary>
	///
	/// File History:
	/// <created>9/5/2006 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class ApproveOrder  : Components.Desktop.BaseDetailUserControl
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
					CopyFormToEntity(); // apply changes to object
				}
				else
				{
					if (Request.QueryString["SaveMessages"] == null)
					{
						Globals.ClearMessages();
					}
					LoadEntity();
					
					if (_entity == null)
					{
						CreateNewEntity();
					}
				}
				GuidConverter guidC = new GuidConverter();
				Guid orderID = (Guid)guidC.ConvertFromString(Request.QueryString.Get("OrderID"));
				BLL.Orders.Order order = BLL.Orders.OrderManager.GetOneOrder(orderID);
				if (order != null)
				{
					lblOrder.Text = "Order ID: " + order.OrderID.ToString();
					lblOrder.Text += "<br/>From: " + order.DebitMetaPartner.MetaPartnerName + " (" + order.DebitMetaPartner.PrimaryPhone.PhoneNumber + ")";
					lblOrder.Text += "<br/>To: " + order.CreditMetaPartner.MetaPartnerName + " (" + order.CreditMetaPartner.PrimaryPhone.PhoneNumber + ")";
					lblOrder.Text += "<br/>Amount: " + order.OrderAmount.ToString() + " " + order.CurrencyName;
				}
				if (Session["txtStatus"] != null)
				{
					txtStatus.Text = Session["txtStatus"].ToString();
				}
			}
			catch (MW.MComm.WalletSolution.Utility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(MW.MComm.WalletSolution.Utility.CustomAppException.WrapException(ex, "ApproveOrder.Page_Load"));
			}
			finally
			{
			}
		}


		// ------------------------------------------------------------------------------
		/// <summary>Reset form for Pay To Phone.</summary>
		///
		// ------------------------------------------------------------------------------
		private void btnReject_Click(object sender, EventArgs e)
		{
			try
			{
				// reject order
				Globals.AddStatusMessage("Pay To Phone reset.");
			}
			catch (MW.MComm.WalletSolution.Utility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(MW.MComm.WalletSolution.Utility.CustomAppException.WrapException(ex, "ApproveOrder.btnReject_Click"));
			}
			finally
			{
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>Save Pay To Phone.</summary>
		///
		// ------------------------------------------------------------------------------
		private void btnApprove_Click(object sender, EventArgs e)
		{
			bool doRedirect = true;
			bool isValid = true;
			try
			{
				Globals.ClearMessages();

				if (btnApprove.CausesValidation == true)
				{
					Page.Validate();
					isValid = Page.IsValid;
				}
				if (isValid == true)
				{
					CompleteOrder(true);
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
				base.HandleError(MW.MComm.WalletSolution.Utility.CustomAppException.WrapException(ex, "ApproveOrder.btnApprove_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && isValid == true)
			{
				NameValueCollection queryString = new NameValueCollection();
				Response.Redirect(GetPageUrl(queryString, true, true));
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
				base.OnPreRender();
				CopyEntityToForm();
				if (Session["txtStatus"] != null)
				{
					txtStatus.Text = Session["txtStatus"].ToString();
				}
			}
			catch (MW.MComm.WalletSolution.Utility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(MW.MComm.WalletSolution.Utility.CustomAppException.WrapException(ex, "ApproveOrder.Page_PreRender"));
			}
			finally
			{
			}
		}
		#endregion Event Handlers
		#region Methods

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
		/// <summary>Approve order and initiate payment.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CompleteOrder(bool performCascade)
		{
			int localeCode = (int)BLL.Environments.LocaleCode.SpanishBolivia;
			try
			{
				Session["txtStatus"] = "";

				string customerPhone = Request.QueryString.Get("Phone");
				customerPhone = customerPhone.Trim();
				GuidConverter guidC = new GuidConverter();
				Guid orderID = (Guid)guidC.ConvertFromString(Request.QueryString.Get("OrderID"));
				BLL.Orders.Order order = BLL.Orders.OrderManager.GetOneOrder(orderID);
				if (order == null)
				{
					throw new Utility.CustomAppException(BLL.Core.ErrorNumber.OrderApprovalFailure);
				}
				order.Approve(customerPhone, txtPIN.Text.Trim());
				order.Pay();

				localeCode = order.DebitMetaPartner.LocaleCode;

				// send notification
				MOD.Data.NamedObjectCollection eventData = BLL.Notifications.NotificationGenerator.SendNotificationsForOrderEvent(BLL.Events.EventCode.PhoneToPhonePaymentTransferred, order, order.DebitMetaPartner, order.CreditMetaPartner, Globals.MailServer, Globals.MailSenderEmail, Globals.SMSSenderPhone);
				lblPIN.Visible = false;
				txtPIN.Visible = false;
				btnApprove.Visible = false;
				btnReject.Visible = false;
				Session["txtStatus"] += "\r\n" + order.OrderAmount.ToString() + " " + order.Currency.CurrencyName + " was paid from " + customerPhone + " to " + eventData[BLL.Events.EventAttributeCode.DestinationPhone.ToString("D")] + ".";
				Session["txtStatus"] += "\r\nBalance on stored value account for " + order.CreditMetaPartner.MetaPartnerName + " is " + order.CreditMetaPartner.PrimaryStoredValueAccount.CarrierBalance + " " + order.CreditMetaPartner.PrimaryStoredValueAccount.CurrencyName + ".";
				Session["txtStatus"] += "\r\nBalance on stored value account for " + order.DebitMetaPartner.MetaPartnerName + " is " + order.DebitMetaPartner.PrimaryStoredValueAccount.CarrierBalance + " " + order.DebitMetaPartner.PrimaryStoredValueAccount.CurrencyName + ".";

			}
			catch (Utility.CustomAppException ex)
			{
				if (ex.SeverityLevel != BLL.Core.SeverityLevelCode.None && ex.SeverityLevel != BLL.Core.SeverityLevelCode.OK)
				{
					Utility.CustomAppException.HandleException(ex);
				}
				Session["txtStatus"] += BLL.UserExperience.FriendlyErrorManager.GetFriendlyErrorMessage(ex.ErrorNumber, localeCode);
			}
			catch (System.Exception ex)
			{
				Utility.CustomAppException.HandleException(ex);
				Session["txtStatus"] += BLL.Core.ErrorManager.GetErrorMessageFromException(ex, localeCode, false);
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>Reject order and cancel payment.</summary>
		///
		// ------------------------------------------------------------------------------
		private void RejectOrder(bool performCascade)
		{
			int localeCode = (int)BLL.Environments.LocaleCode.SpanishBolivia;
			try
			{
				Session["txtStatus"] = "";

				string customerPhone = Request.QueryString.Get("Phone");
				customerPhone = customerPhone.Trim();
				GuidConverter guidC = new GuidConverter();
				Guid orderID = (Guid)guidC.ConvertFromString(Request.QueryString.Get("OrderID"));
				BLL.Orders.Order order = BLL.Orders.OrderManager.GetOneOrder(orderID);
				if (order == null)
				{
					throw new Utility.CustomAppException(BLL.Core.ErrorNumber.OrderApprovalFailure);
				}
				order.Cancel(customerPhone, txtPIN.Text.Trim());

				localeCode = order.DebitMetaPartner.LocaleCode;

				// send notification
				MOD.Data.NamedObjectCollection eventData = BLL.Notifications.NotificationGenerator.SendNotificationsForOrderEvent(BLL.Events.EventCode.PaymentCancelled, order, order.DebitMetaPartner, null, Globals.MailServer, Globals.MailSenderEmail, Globals.SMSSenderPhone);

				Session["txtStatus"] += "\r\nA transfer of " + order.OrderAmount.ToString() + " " + order.Currency.CurrencyName + " from " + customerPhone + " to " + eventData[BLL.Events.EventAttributeCode.DestinationPhone.ToString("D")] + " was rejected.";

			}
			catch (Utility.CustomAppException ex)
			{
				if (ex.SeverityLevel != BLL.Core.SeverityLevelCode.None && ex.SeverityLevel != BLL.Core.SeverityLevelCode.OK)
				{
					Utility.CustomAppException.HandleException(ex);
				}
				Session["txtStatus"] += BLL.UserExperience.FriendlyErrorManager.GetFriendlyErrorMessage(ex.ErrorNumber, localeCode);
			}
			catch (System.Exception ex)
			{
				Utility.CustomAppException.HandleException(ex);
				Session["txtStatus"] += BLL.Core.ErrorManager.GetErrorMessageFromException(ex, localeCode, false);
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
			this.btnReject.Click += new EventHandler(btnReject_Click);
			this.btnApprove.Click += new EventHandler(btnApprove_Click);
		}
		#endregion Web Form Designer generated code
	}
}