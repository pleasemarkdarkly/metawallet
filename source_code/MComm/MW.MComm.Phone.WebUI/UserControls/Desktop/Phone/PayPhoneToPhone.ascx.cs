
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
	public partial class PayPhoneToPhone  : Components.Desktop.BaseDetailUserControl
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
				LoadEntity();
				if (_entity == null)
				{
					CreateNewEntity();
				}
				Session["StoredValueAccountItem"] = _entity;

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
			string approvalURL = string.Empty;
			try
			{
				Globals.ClearMessages();

				if (btnSave.CausesValidation == true)
				{
					Page.Validate();
					isValid = Page.IsValid;
				}
				if (isValid == true)
				{
					approvalURL = InitiateOrder(true);
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
			if (approvalURL != string.Empty)
			{
				Response.Redirect(approvalURL);
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
				base.HandleError(MW.MComm.WalletSolution.Utility.CustomAppException.WrapException(ex, "PayPhoneToPhone.Page_PreRender"));
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
		/// <summary>Update Pay To Phone information in the database.</summary>
		///
		// ------------------------------------------------------------------------------
		private string InitiateOrder(bool performCascade)
		{
			int localeCode = (int) BLL.Environments.LocaleCode.SpanishBolivia;
			string approveURL = string.Empty;
			try
			{
				Session["txtStatus"] = "";

				// initiate order and send notice to sender
				BLL.Orders.Order order = BLL.Orders.OrderManager.InitiateOrder(ddlFromMetaPartnerPhoneID.Text.Trim(), null, ddlToMetaPartnerPhoneID.Text.Trim(), null, decimal.Parse(txtBalance.Text.Trim()), (int)BLL.Accounts.CurrencyCode.Bolivianos, "testing");
				localeCode = order.DebitMetaPartner.LocaleCode;

				approveURL = "ApproveOrder.aspx?Phone=" + ddlFromMetaPartnerPhoneID.Text.Trim() + "&OrderID=" + order.OrderID.ToString();

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
			return approveURL;
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