
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
using MW.MComm.WalletSolution.BLL.Payments;
using CoreUtility = MW.MComm.WalletSolution.Utility;
using MW.MComm.Admin.WebUI.Components.Desktop;
namespace MW.MComm.Admin.WebUI.UserControls.Desktop.Payments
{
	// ------------------------------------------------------------------------------
	/// <summary>Edit Payment is used to help manage Payment information.</summary>
	///
	/// File History:
	/// <created>6/1/2007 (Chris Grundy)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class EditPayment  : Components.Desktop.BaseFormlUserControl
	{
		#region Events
		/// <summary>
		/// Raised when "Add" button is clicked in internal mode.
		/// Container handles this event and adds entity to collection.
		/// </summary>
		public event EntityEditEventHandler PaymentAdded;
		/// <summary>
		/// Raised when "Remove" button is clicked in internal mode.
		/// Container handles this event and removes entity from collection.
		/// </summary>
		public event EntityEditEventHandler PaymentRemoved;
		#endregion Events
		#region Declarations
		#endregion Declarations
		#region Properties
		/// <summary>
		/// The Payment currently being edited by this control.
		/// Get accessor casts base._entity to Payment
		/// Set accessor used by parent control to set the item currently being edited
		/// </summary>
		public BLL.Payments.Payment PaymentItem
		{
			get
			{
				return (BLL.Payments.Payment) _entity;
			}
			set
			{
				_entity = value; // only set by container
				Session["PaymentItem"] = _entity;
			}
		}
		#endregion Properties
		#region Event Handlers
		// ------------------------------------------------------------------------------
		/// <summary>Load page for editing Payment, getting mode and parameters.</summary>
		///
		// ------------------------------------------------------------------------------
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				// set validator property to child controls
				listPaymentTransactionLogData.UseValidation = UseValidation && (DisplayMode != MOD.Data.DisplayMode.SingleView);
				base.OnLoad();
				if (IsPostBack == true)
				{
					// entity may come from session, or be set by container
					if (_entity == null)
					{
						_entity = (BLL.Payments.Payment)Session["PaymentItem"];
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
					Session["PaymentItem"] = _entity;
				}
				// Assign entity collections into child controls
				listPaymentTransactionLogData.Collection = PaymentItem.PaymentTransactionLogList;
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditPayment.Page_Load"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Delete Payment.</summary>
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
					BLL.Payments.PaymentManager.DeleteOnePayment(PaymentItem, performCascade);
					Globals.AddStatusMessage("Payment deleted.");
				}
				else
				{
					// raise event so item is removed from collection
					if (PaymentRemoved != null)
					{
						PaymentRemoved(this, new EntityEditEventArgs(_entity));
					}
				}
				// create new object and store it in _entity
				CreateNewEntity();
				Session["PaymentItem"] = _entity;
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditPayment.btnDelete_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("PaymentID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Request to create a new Payment.</summary>
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
				Session["PaymentItem"] = _entity;
				this.sectionLinks.OnSection("Basics");
				SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
				Globals.AddStatusMessage("Add new Payment.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				doRedirect = false;
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				doRedirect = false;
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditPayment.btnNew_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("PaymentID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Reset form for Payment.</summary>
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
					Session["PaymentItem"] = _entity;
					sectionLinks.CurrentSection = "Basics";
				}
				else
				{
					CreateNewEntity();
				}
				Globals.AddStatusMessage("Payment reset.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditPayment.btnReset_Click"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Save Payment.</summary>
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
							if (PaymentAdded != null && (PaymentItem.PaymentID != MOD.Data.DefaultValue.Guid || PaymentItem.PaymentAmount != MOD.Data.DefaultValue.Decimal || PaymentItem.PaymentSubtotal != MOD.Data.DefaultValue.Decimal || PaymentItem.PaymentTax != MOD.Data.DefaultValue.Decimal || PaymentItem.PaymentServiceCharge != MOD.Data.DefaultValue.Decimal || PaymentItem.OrderID != MOD.Data.DefaultValue.Guid || PaymentItem.DebitMetaPartnerID != MOD.Data.DefaultValue.Guid || PaymentItem.SourceAccountID != MOD.Data.DefaultValue.Guid || PaymentItem.CreditMetaPartnerID != MOD.Data.DefaultValue.Guid || PaymentItem.DestinationAccountID != MOD.Data.DefaultValue.Guid || PaymentItem.PaymentStatusCode != MOD.Data.DefaultValue.Int || PaymentItem.PaymentStatusMessage != MOD.Data.DefaultValue.String || PaymentItem.CreatedByUserID != MOD.Data.DefaultValue.Guid || PaymentItem.CreatedDate != MOD.Data.DefaultValue.DateTime || PaymentItem.LastModifiedByUserID != MOD.Data.DefaultValue.Guid || PaymentItem.LastModifiedDate != MOD.Data.DefaultValue.DateTime || PaymentItem.Timestamp != null))
							{
								PaymentAdded(this, new EntityEditEventArgs(_entity));
								// create new object and store it in _entity
								CreateNewEntity();
								Session["PaymentItem"] = _entity;
								this.sectionLinks.OnSection("Basics");
								SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
							}
						}
						else
						{
							Globals.AddStatusMessage("Payment updated.");
						}
					}
					else
					{
						UpsertToDatabase(true);
						if (AccessMode == MOD.Data.AccessMode.Add)
						{
							doRedirect = true;
							Globals.AddStatusMessage("Payment added.");
						}
						else
						{
							Globals.AddStatusMessage("Payment updated.");
						}
						SetAccessModeAndDisplay(MOD.Data.AccessMode.Edit);
					}
				}
				else
				{
					Globals.AddErrorMessage(Page, "Payment validation failed.");
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditPayment.btnSave_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && isValid == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("PaymentID", PaymentItem.PaymentID.ToString());
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditPayment.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditPayment.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditPayment.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditPayment.Page_PreRender"));
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
		/// Create a new Payment object reference
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void CreateNewEntity()
		{
			BLL.Payments.Payment vPayment = new BLL.Payments.Payment();
			vPayment.PaymentID = MOD.Data.DataHelper.GetGuid(Request.QueryString["PaymentID"], MOD.Data.DefaultValue.Guid);
			vPayment.OrderID = MOD.Data.DataHelper.GetGuid(Request.QueryString["OrderID"], MOD.Data.DefaultValue.Guid);
			vPayment.DebitMetaPartnerID = MOD.Data.DataHelper.GetGuid(Request.QueryString["DebitMetaPartnerID"], MOD.Data.DefaultValue.Guid);
			vPayment.SourceAccountID = MOD.Data.DataHelper.GetGuid(Request.QueryString["SourceAccountID"], MOD.Data.DefaultValue.Guid);
			vPayment.CreditMetaPartnerID = MOD.Data.DataHelper.GetGuid(Request.QueryString["CreditMetaPartnerID"], MOD.Data.DefaultValue.Guid);
			vPayment.DestinationAccountID = MOD.Data.DataHelper.GetGuid(Request.QueryString["DestinationAccountID"], MOD.Data.DefaultValue.Guid);
			vPayment.PaymentStatusCode = MOD.Data.DataHelper.GetInt(Request.QueryString["PaymentStatusCode"], MOD.Data.DefaultValue.Int);
			_entity = vPayment;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update form from Payment information.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyEntityToForm()
		{
			BLL.Payments.Payment vPayment = PaymentItem;
			lblPaymentID.Text = MOD.Data.DataHelper.GetString(vPayment.PaymentID, "");
			txtPaymentAmount.Text = MOD.Data.EditHelper.GetCurrency(vPayment.PaymentAmount);
			txtPaymentSubtotal.Text = MOD.Data.EditHelper.GetCurrency(vPayment.PaymentSubtotal);
			txtPaymentTax.Text = MOD.Data.EditHelper.GetCurrency(vPayment.PaymentTax);
			txtPaymentServiceCharge.Text = MOD.Data.EditHelper.GetCurrency(vPayment.PaymentServiceCharge);
			ddlOrderID.DataValueField = "PrimaryIndex";
			ddlOrderID.DataTextField = "PrimaryName";
			if (UseWorkingSets == true && Session["Orders/OrderWorkingSet"] != null)
			{
				BLL.SortableList<BLL.Orders.Order> sessionSource = (BLL.SortableList<BLL.Orders.Order>) Session["Orders/OrderWorkingSet"];
				BLL.SortableList<BLL.Orders.Order> currentSource = new BLL.SortableList<BLL.Orders.Order>(sessionSource, true);
				if (MOD.Data.DataHelper.GetGuid(vPayment.OrderID, MOD.Data.DefaultValue.Guid) != MOD.Data.DefaultValue.Guid)
				{
					BLL.Orders.Order currentOrder = BLL.Orders.OrderManager.GetOneOrder(MOD.Data.DataHelper.GetGuid(vPayment.OrderID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions("", "", true, true));
					if (currentOrder != null && currentSource.Contains(currentOrder) == false)
					{
						currentSource.Insert(0, currentOrder);
					}
				}
				ddlOrderID.DataSource = currentSource;
				lnkOrderIDWorkingSet.Visible = true;
				lnkOrderIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Orders/SearchOrderData.aspx");
				lblOrderIDWorkingSet.Visible = true;
				lblOrderIDWorkingSet.Text = " (from Order working set)";
			}
			else
			{
				ddlOrderID.DataSource = BLL.Orders.OrderManager.GetAllOrderData(Globals.DBOptions, Globals.getDataOptions("", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
				lblOrderIDWorkingSet.Visible = false;
				if (UseWorkingSets == true)
				{
					lnkOrderIDWorkingSet.Visible = true;
					lnkOrderIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Orders/SearchOrderData.aspx");
				}
				else
				{
					lnkOrderIDWorkingSet.Visible = false;
				}
			}
			ddlOrderID.DataBind();
			ddlOrderID.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				BLL.Orders.Order sOrder = new BLL.Orders.Order();
				sOrder.OrderID = MOD.Data.DataHelper.GetGuid(vPayment.OrderID, MOD.Data.DefaultValue.Guid);
				ddlOrderID.SelectedValue = MOD.Data.DataHelper.GetString(sOrder.PrimaryIndex, "");
				sOrder = null;
			}
			catch {}
			if(ddlOrderID.SelectedValue == ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				try
				{
					ddlOrderID.SelectedValue = MOD.Data.DataHelper.GetString(Session["Orders/OrderWorkingSetItem"], "");
				}
				catch {}
			}
			ddlDebitMetaPartnerID.DataValueField = "PrimaryIndex";
			ddlDebitMetaPartnerID.DataTextField = "PrimaryName";
			if (UseWorkingSets == true && Session["Accounts/AccountWorkingSet"] != null)
			{
				BLL.SortableList<BLL.Accounts.Account> sessionSource = (BLL.SortableList<BLL.Accounts.Account>) Session["Accounts/AccountWorkingSet"];
				BLL.SortableList<BLL.Accounts.Account> currentSource = new BLL.SortableList<BLL.Accounts.Account>(sessionSource, true);
				if (MOD.Data.DataHelper.GetGuid(vPayment.DebitMetaPartnerID, MOD.Data.DefaultValue.Guid) != MOD.Data.DefaultValue.Guid)
				{
					BLL.Accounts.Account currentAccount = BLL.Accounts.AccountManager.GetOneAccount(MOD.Data.DataHelper.GetGuid(vPayment.DebitMetaPartnerID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions("", "", true, true));
					if (currentAccount != null && currentSource.Contains(currentAccount) == false)
					{
						currentSource.Insert(0, currentAccount);
					}
				}
				ddlDebitMetaPartnerID.DataSource = currentSource;
				lnkDebitMetaPartnerIDWorkingSet.Visible = true;
				lnkDebitMetaPartnerIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Accounts/SearchAccountData.aspx");
				lblDebitMetaPartnerIDWorkingSet.Visible = true;
				lblDebitMetaPartnerIDWorkingSet.Text = " (from Account working set)";
			}
			else
			{
				ddlDebitMetaPartnerID.DataSource = BLL.Accounts.AccountManager.GetAllAccountData(Globals.DBOptions, Globals.getDataOptions("AccountName", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
				lblDebitMetaPartnerIDWorkingSet.Visible = false;
				if (UseWorkingSets == true)
				{
					lnkDebitMetaPartnerIDWorkingSet.Visible = true;
					lnkDebitMetaPartnerIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Accounts/SearchAccountData.aspx");
				}
				else
				{
					lnkDebitMetaPartnerIDWorkingSet.Visible = false;
				}
			}
			ddlDebitMetaPartnerID.DataBind();
			ddlDebitMetaPartnerID.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				BLL.Accounts.Account sAccount = new BLL.Accounts.Account();
				sAccount.AccountID = MOD.Data.DataHelper.GetGuid(vPayment.SourceAccountID, MOD.Data.DefaultValue.Guid);
				sAccount.MetaPartnerID = MOD.Data.DataHelper.GetGuid(vPayment.DebitMetaPartnerID, MOD.Data.DefaultValue.Guid);
				ddlDebitMetaPartnerID.SelectedValue = MOD.Data.DataHelper.GetString(sAccount.PrimaryIndex, "");
				sAccount = null;
			}
			catch {}
			if(ddlDebitMetaPartnerID.SelectedValue == ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				try
				{
					ddlDebitMetaPartnerID.SelectedValue = MOD.Data.DataHelper.GetString(Session["Accounts/AccountWorkingSetItem"], "");
				}
				catch {}
			}
			ddlCreditMetaPartnerID.DataValueField = "PrimaryIndex";
			ddlCreditMetaPartnerID.DataTextField = "PrimaryName";
			if (UseWorkingSets == true && Session["Accounts/AccountWorkingSet"] != null)
			{
				BLL.SortableList<BLL.Accounts.Account> sessionSource = (BLL.SortableList<BLL.Accounts.Account>) Session["Accounts/AccountWorkingSet"];
				BLL.SortableList<BLL.Accounts.Account> currentSource = new BLL.SortableList<BLL.Accounts.Account>(sessionSource, true);
				if (MOD.Data.DataHelper.GetGuid(vPayment.CreditMetaPartnerID, MOD.Data.DefaultValue.Guid) != MOD.Data.DefaultValue.Guid)
				{
					BLL.Accounts.Account currentAccount = BLL.Accounts.AccountManager.GetOneAccount(MOD.Data.DataHelper.GetGuid(vPayment.CreditMetaPartnerID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions("", "", true, true));
					if (currentAccount != null && currentSource.Contains(currentAccount) == false)
					{
						currentSource.Insert(0, currentAccount);
					}
				}
				ddlCreditMetaPartnerID.DataSource = currentSource;
				lnkCreditMetaPartnerIDWorkingSet.Visible = true;
				lnkCreditMetaPartnerIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Accounts/SearchAccountData.aspx");
				lblCreditMetaPartnerIDWorkingSet.Visible = true;
				lblCreditMetaPartnerIDWorkingSet.Text = " (from Account working set)";
			}
			else
			{
				ddlCreditMetaPartnerID.DataSource = BLL.Accounts.AccountManager.GetAllAccountData(Globals.DBOptions, Globals.getDataOptions("AccountName", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
				lblCreditMetaPartnerIDWorkingSet.Visible = false;
				if (UseWorkingSets == true)
				{
					lnkCreditMetaPartnerIDWorkingSet.Visible = true;
					lnkCreditMetaPartnerIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Accounts/SearchAccountData.aspx");
				}
				else
				{
					lnkCreditMetaPartnerIDWorkingSet.Visible = false;
				}
			}
			ddlCreditMetaPartnerID.DataBind();
			ddlCreditMetaPartnerID.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				BLL.Accounts.Account sAccount = new BLL.Accounts.Account();
				sAccount.AccountID = MOD.Data.DataHelper.GetGuid(vPayment.DestinationAccountID, MOD.Data.DefaultValue.Guid);
				sAccount.MetaPartnerID = MOD.Data.DataHelper.GetGuid(vPayment.CreditMetaPartnerID, MOD.Data.DefaultValue.Guid);
				ddlCreditMetaPartnerID.SelectedValue = MOD.Data.DataHelper.GetString(sAccount.PrimaryIndex, "");
				sAccount = null;
			}
			catch {}
			if(ddlCreditMetaPartnerID.SelectedValue == ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				try
				{
					ddlCreditMetaPartnerID.SelectedValue = MOD.Data.DataHelper.GetString(Session["Accounts/AccountWorkingSetItem"], "");
				}
				catch {}
			}
			ddlPaymentStatusCode.DataValueField = "PrimaryIndex";
			ddlPaymentStatusCode.DataTextField = "PrimaryName";
			ddlPaymentStatusCode.DataSource = BLL.Payments.PaymentStatusManager.GetAllPaymentStatusData(Globals.DBOptions, Globals.getDataOptions("PaymentStatusName", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
			ddlPaymentStatusCode.DataBind();
			ddlPaymentStatusCode.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				BLL.Payments.PaymentStatus sPaymentStatus = new BLL.Payments.PaymentStatus();
				sPaymentStatus.PaymentStatusCode = MOD.Data.DataHelper.GetInt(vPayment.PaymentStatusCode, MOD.Data.DefaultValue.Int);
				ddlPaymentStatusCode.SelectedValue = MOD.Data.DataHelper.GetString(sPaymentStatus.PrimaryIndex, "");
				sPaymentStatus = null;
			}
			catch {}
			if(ddlPaymentStatusCode.SelectedValue == ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				try
				{
					ddlPaymentStatusCode.SelectedValue = MOD.Data.DataHelper.GetString(Session["Payments/PaymentStatusWorkingSetItem"], "");
				}
				catch {}
			}
			txtPaymentStatusMessage.Text = MOD.Data.EditHelper.GetString(vPayment.PaymentStatusMessage);
			// Drop downs should be disabled when control is "Internal" and either value is constrained by container
			if (WorkflowMode == WorkflowMode.Internal)
			{
				ddlOrderID.Visible = Request.QueryString["OrderID"] == null;
				lnkOrderIDWorkingSet.Visible = lnkOrderIDWorkingSet.Visible == true && Request.QueryString["OrderID"] == null;
				lblOrderIDWorkingSet.Visible = lblOrderIDWorkingSet.Visible == true && Request.QueryString["OrderID"] == null;
				valOrderID.Enabled = Request.QueryString["OrderID"] == null;
				lblOrderIDDisplay.Visible = Request.QueryString["OrderID"] == null;
				ddlPaymentStatusCode.Visible = Request.QueryString["PaymentStatusCode"] == null;
				valPaymentStatusCode.Enabled = Request.QueryString["PaymentStatusCode"] == null;
				lblPaymentStatusCodeDisplay.Visible = Request.QueryString["PaymentStatusCode"] == null;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set Payment information from the form.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyFormToEntity()
		{
			BLL.Payments.Payment vPayment = PaymentItem;
			if (vPayment == null)
			{
				throw CoreUtility.CustomAppException.WrapException(new Exception("Payment not found"), "EditPayment.CopyFormToEntity()");
			}
			try
			{
				vPayment.PaymentAmount = MOD.Data.DataHelper.GetDecimal(txtPaymentAmount.Text, MOD.Data.DefaultValue.Decimal);
			}
			catch {}
			try
			{
				vPayment.PaymentSubtotal = MOD.Data.DataHelper.GetDecimal(txtPaymentSubtotal.Text, MOD.Data.DefaultValue.Decimal);
			}
			catch {}
			try
			{
				vPayment.PaymentTax = MOD.Data.DataHelper.GetDecimal(txtPaymentTax.Text, MOD.Data.DefaultValue.Decimal);
			}
			catch {}
			try
			{
				vPayment.PaymentServiceCharge = MOD.Data.DataHelper.GetDecimal(txtPaymentServiceCharge.Text, MOD.Data.DefaultValue.Decimal);
			}
			catch {}
			if (ddlOrderID.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Orders.Order sOrder = new BLL.Orders.Order(ddlOrderID.SelectedValue, false);
				vPayment.OrderID = MOD.Data.DataHelper.GetGuid(sOrder.OrderID, MOD.Data.DefaultValue.Guid);
				sOrder = null;
			}
			if (ddlDebitMetaPartnerID.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Accounts.Account sAccount = new BLL.Accounts.Account(ddlDebitMetaPartnerID.SelectedValue, false);
				vPayment.SourceAccountID = MOD.Data.DataHelper.GetGuid(sAccount.AccountID, MOD.Data.DefaultValue.Guid);
				vPayment.DebitMetaPartnerID = MOD.Data.DataHelper.GetGuid(sAccount.MetaPartnerID, MOD.Data.DefaultValue.Guid);
				sAccount = null;
			}
			if (ddlCreditMetaPartnerID.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Accounts.Account sAccount = new BLL.Accounts.Account(ddlCreditMetaPartnerID.SelectedValue, false);
				vPayment.DestinationAccountID = MOD.Data.DataHelper.GetGuid(sAccount.AccountID, MOD.Data.DefaultValue.Guid);
				vPayment.CreditMetaPartnerID = MOD.Data.DataHelper.GetGuid(sAccount.MetaPartnerID, MOD.Data.DefaultValue.Guid);
				sAccount = null;
			}
			if (ddlPaymentStatusCode.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Payments.PaymentStatus sPaymentStatus = new BLL.Payments.PaymentStatus(ddlPaymentStatusCode.SelectedValue, false);
				vPayment.PaymentStatusCode = MOD.Data.DataHelper.GetInt(sPaymentStatus.PaymentStatusCode, MOD.Data.DefaultValue.Int);
				sPaymentStatus = null;
				vPayment.PrimaryName += MOD.Data.DataHelper.GetString(ddlPaymentStatusCode.SelectedItem.Text, MOD.Data.DefaultValue.String) + ";";
			}
			vPayment.PaymentStatusMessage = EditHelper.EncodeStringForDB(MOD.Data.DataHelper.GetString(txtPaymentStatusMessage.Text, null));
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// Load entity from database, store in _entity and Session["PaymentItem"]
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void LoadEntity()
		{
			_entity = null;
			Guid paymentID = MOD.Data.DataHelper.GetGuid(Request.QueryString["PaymentID"], MOD.Data.DefaultValue.Guid);
			if (paymentID != MOD.Data.DefaultValue.Guid)
			{
				_entity = BLL.Payments.PaymentManager.GetOnePayment(paymentID, Globals.getDataOptions("", "", true, true));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update Payment information in the database.</summary>
		///
		// ------------------------------------------------------------------------------
		private void UpsertToDatabase(bool performCascade)
		{
			BLL.Payments.Payment vPayment = PaymentItem;
			if (AccessMode == MOD.Data.AccessMode.Add)
			{
				BLL.Payments.PaymentManager.UpsertOnePayment(vPayment, performCascade);
			}
			else if (AccessMode == MOD.Data.AccessMode.Edit)
			{
				BLL.Payments.PaymentManager.UpsertOnePayment(vPayment, performCascade);
			}
			PaymentItem.PaymentID = vPayment.PaymentID;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set access and display modes for presenting Payment information.</summary>
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
					lblTitle.Text = "Add Payment";
					btnSave.Text = "Add";
					break;
				case MOD.Data.AccessMode.Edit:
					lblTitle.Text = "Edit Payment";
					btnSave.Text = "Save";
					break;
				case MOD.Data.AccessMode.View:
					lblTitle.Text = "View Payment";
					break;
				default:
					lblTitle.Text = "View Payment";
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
				Section_Payment_Transaction_Logs.Visible = false;
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
					Section_Payment_Transaction_Logs.Visible = true;
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
		/// <summary>Initialize component for Payment, add delegates here.</summary>
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