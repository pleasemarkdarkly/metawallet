
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
	/// <summary>Edit Payment Transaction Log is used to help manage PaymentTransactionLog information.</summary>
	///
	/// File History:
	/// <created>6/1/2007 (Chris Grundy)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class EditPaymentTransactionLog  : Components.Desktop.BaseFormlUserControl
	{
		#region Events
		/// <summary>
		/// Raised when "Add" button is clicked in internal mode.
		/// Container handles this event and adds entity to collection.
		/// </summary>
		public event EntityEditEventHandler PaymentTransactionLogAdded;
		/// <summary>
		/// Raised when "Remove" button is clicked in internal mode.
		/// Container handles this event and removes entity from collection.
		/// </summary>
		public event EntityEditEventHandler PaymentTransactionLogRemoved;
		#endregion Events
		#region Declarations
		#endregion Declarations
		#region Properties
		/// <summary>
		/// The PaymentTransactionLog currently being edited by this control.
		/// Get accessor casts base._entity to PaymentTransactionLog
		/// Set accessor used by parent control to set the item currently being edited
		/// </summary>
		public BLL.Payments.PaymentTransactionLog PaymentTransactionLogItem
		{
			get
			{
				return (BLL.Payments.PaymentTransactionLog) _entity;
			}
			set
			{
				_entity = value; // only set by container
				Session["PaymentTransactionLogItem"] = _entity;
			}
		}
		#endregion Properties
		#region Event Handlers
		// ------------------------------------------------------------------------------
		/// <summary>Load page for editing Payment Transaction Log, getting mode and parameters.</summary>
		///
		// ------------------------------------------------------------------------------
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				// set validator property to child controls
				listPaymentTransactionAttributeValueLogData.UseValidation = UseValidation && (DisplayMode != MOD.Data.DisplayMode.SingleView);
				base.OnLoad();
				if (IsPostBack == true)
				{
					// entity may come from session, or be set by container
					if (_entity == null)
					{
						_entity = (BLL.Payments.PaymentTransactionLog)Session["PaymentTransactionLogItem"];
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
					Session["PaymentTransactionLogItem"] = _entity;
				}
				// Assign entity collections into child controls
				listPaymentTransactionAttributeValueLogData.Collection = PaymentTransactionLogItem.PaymentTransactionAttributeValueLogList;
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditPaymentTransactionLog.Page_Load"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Delete Payment Transaction Log.</summary>
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
				}
				else
				{
					// raise event so item is removed from collection
					if (PaymentTransactionLogRemoved != null)
					{
						PaymentTransactionLogRemoved(this, new EntityEditEventArgs(_entity));
					}
				}
				// create new object and store it in _entity
				CreateNewEntity();
				Session["PaymentTransactionLogItem"] = _entity;
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditPaymentTransactionLog.btnDelete_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("PaymentTransactionLogID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Request to create a new Payment Transaction Log.</summary>
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
				Session["PaymentTransactionLogItem"] = _entity;
				this.sectionLinks.OnSection("Basics");
				SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
				Globals.AddStatusMessage("Add new Payment Transaction Log.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				doRedirect = false;
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				doRedirect = false;
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditPaymentTransactionLog.btnNew_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("PaymentTransactionLogID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Reset form for Payment Transaction Log.</summary>
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
					Session["PaymentTransactionLogItem"] = _entity;
					sectionLinks.CurrentSection = "Basics";
				}
				else
				{
					CreateNewEntity();
				}
				Globals.AddStatusMessage("Payment Transaction Log reset.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditPaymentTransactionLog.btnReset_Click"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Save Payment Transaction Log.</summary>
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
							if (PaymentTransactionLogAdded != null && (PaymentTransactionLogItem.PaymentTransactionLogID != MOD.Data.DefaultValue.Guid || PaymentTransactionLogItem.PaymentID != MOD.Data.DefaultValue.Guid || PaymentTransactionLogItem.TransactionTypeCode != MOD.Data.DefaultValue.Int || PaymentTransactionLogItem.TransactionStatusCode != MOD.Data.DefaultValue.Int || PaymentTransactionLogItem.TransactionAmount != MOD.Data.DefaultValue.Decimal || PaymentTransactionLogItem.ResponseCode != MOD.Data.DefaultValue.String || PaymentTransactionLogItem.TransactionCode != MOD.Data.DefaultValue.String || PaymentTransactionLogItem.TransactionMessage != MOD.Data.DefaultValue.String || PaymentTransactionLogItem.Balance != MOD.Data.DefaultValue.Decimal || PaymentTransactionLogItem.CreatedByUserID != MOD.Data.DefaultValue.Guid || PaymentTransactionLogItem.CreatedDate != MOD.Data.DefaultValue.DateTime || PaymentTransactionLogItem.LastModifiedByUserID != MOD.Data.DefaultValue.Guid || PaymentTransactionLogItem.LastModifiedDate != MOD.Data.DefaultValue.DateTime || PaymentTransactionLogItem.Timestamp != null))
							{
								PaymentTransactionLogAdded(this, new EntityEditEventArgs(_entity));
								// create new object and store it in _entity
								CreateNewEntity();
								Session["PaymentTransactionLogItem"] = _entity;
								this.sectionLinks.OnSection("Basics");
								SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
							}
						}
						else
						{
							Globals.AddStatusMessage("Payment Transaction Log updated.");
						}
					}
					else
					{
						UpsertToDatabase(true);
						if (AccessMode == MOD.Data.AccessMode.Add)
						{
							doRedirect = true;
							Globals.AddStatusMessage("Payment Transaction Log added.");
						}
						else
						{
							Globals.AddStatusMessage("Payment Transaction Log updated.");
						}
						SetAccessModeAndDisplay(MOD.Data.AccessMode.Edit);
					}
				}
				else
				{
					Globals.AddErrorMessage(Page, "Payment Transaction Log validation failed.");
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditPaymentTransactionLog.btnSave_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && isValid == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("PaymentTransactionLogID", PaymentTransactionLogItem.PaymentTransactionLogID.ToString());
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditPaymentTransactionLog.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditPaymentTransactionLog.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditPaymentTransactionLog.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditPaymentTransactionLog.Page_PreRender"));
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
		/// Create a new Payment Transaction Log object reference
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void CreateNewEntity()
		{
			BLL.Payments.PaymentTransactionLog vPaymentTransactionLog = new BLL.Payments.PaymentTransactionLog();
			vPaymentTransactionLog.PaymentTransactionLogID = MOD.Data.DataHelper.GetGuid(Request.QueryString["PaymentTransactionLogID"], MOD.Data.DefaultValue.Guid);
			vPaymentTransactionLog.PaymentID = MOD.Data.DataHelper.GetGuid(Request.QueryString["PaymentID"], MOD.Data.DefaultValue.Guid);
			vPaymentTransactionLog.TransactionTypeCode = MOD.Data.DataHelper.GetInt(Request.QueryString["TransactionTypeCode"], MOD.Data.DefaultValue.Int);
			vPaymentTransactionLog.TransactionStatusCode = MOD.Data.DataHelper.GetInt(Request.QueryString["TransactionStatusCode"], MOD.Data.DefaultValue.Int);
			_entity = vPaymentTransactionLog;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update form from Payment Transaction Log information.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyEntityToForm()
		{
			BLL.Payments.PaymentTransactionLog vPaymentTransactionLog = PaymentTransactionLogItem;
			lblPaymentTransactionLogID.Text = MOD.Data.DataHelper.GetString(vPaymentTransactionLog.PaymentTransactionLogID, "");
			ddlPaymentID.DataValueField = "PrimaryIndex";
			ddlPaymentID.DataTextField = "PrimaryName";
			if (UseWorkingSets == true && Session["Payments/PaymentWorkingSet"] != null)
			{
				BLL.SortableList<BLL.Payments.Payment> sessionSource = (BLL.SortableList<BLL.Payments.Payment>) Session["Payments/PaymentWorkingSet"];
				BLL.SortableList<BLL.Payments.Payment> currentSource = new BLL.SortableList<BLL.Payments.Payment>(sessionSource, true);
				if (MOD.Data.DataHelper.GetGuid(vPaymentTransactionLog.PaymentID, MOD.Data.DefaultValue.Guid) != MOD.Data.DefaultValue.Guid)
				{
					BLL.Payments.Payment currentPayment = BLL.Payments.PaymentManager.GetOnePayment(MOD.Data.DataHelper.GetGuid(vPaymentTransactionLog.PaymentID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions("", "", true, true));
					if (currentPayment != null && currentSource.Contains(currentPayment) == false)
					{
						currentSource.Insert(0, currentPayment);
					}
				}
				ddlPaymentID.DataSource = currentSource;
				lnkPaymentIDWorkingSet.Visible = true;
				lnkPaymentIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Payments/SearchPaymentData.aspx");
				lblPaymentIDWorkingSet.Visible = true;
				lblPaymentIDWorkingSet.Text = " (from Payment working set)";
			}
			else
			{
				ddlPaymentID.DataSource = BLL.Payments.PaymentManager.GetAllPaymentData(Globals.DBOptions, Globals.getDataOptions("", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
				lblPaymentIDWorkingSet.Visible = false;
				if (UseWorkingSets == true)
				{
					lnkPaymentIDWorkingSet.Visible = true;
					lnkPaymentIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Payments/SearchPaymentData.aspx");
				}
				else
				{
					lnkPaymentIDWorkingSet.Visible = false;
				}
			}
			ddlPaymentID.DataBind();
			ddlPaymentID.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				BLL.Payments.Payment sPayment = new BLL.Payments.Payment();
				sPayment.PaymentID = MOD.Data.DataHelper.GetGuid(vPaymentTransactionLog.PaymentID, MOD.Data.DefaultValue.Guid);
				ddlPaymentID.SelectedValue = MOD.Data.DataHelper.GetString(sPayment.PrimaryIndex, "");
				sPayment = null;
			}
			catch {}
			if(ddlPaymentID.SelectedValue == ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				try
				{
					ddlPaymentID.SelectedValue = MOD.Data.DataHelper.GetString(Session["Payments/PaymentWorkingSetItem"], "");
				}
				catch {}
			}
			ddlTransactionTypeCode.DataValueField = "PrimaryIndex";
			ddlTransactionTypeCode.DataTextField = "PrimaryName";
			ddlTransactionTypeCode.DataSource = BLL.Payments.TransactionTypeManager.GetAllTransactionTypeData(Globals.DBOptions, Globals.getDataOptions("TransactionTypeName", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
			ddlTransactionTypeCode.DataBind();
			ddlTransactionTypeCode.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				BLL.Payments.TransactionType sTransactionType = new BLL.Payments.TransactionType();
				sTransactionType.TransactionTypeCode = MOD.Data.DataHelper.GetInt(vPaymentTransactionLog.TransactionTypeCode, MOD.Data.DefaultValue.Int);
				ddlTransactionTypeCode.SelectedValue = MOD.Data.DataHelper.GetString(sTransactionType.PrimaryIndex, "");
				sTransactionType = null;
			}
			catch {}
			if(ddlTransactionTypeCode.SelectedValue == ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				try
				{
					ddlTransactionTypeCode.SelectedValue = MOD.Data.DataHelper.GetString(Session["Payments/TransactionTypeWorkingSetItem"], "");
				}
				catch {}
			}
			ddlTransactionStatusCode.DataValueField = "PrimaryIndex";
			ddlTransactionStatusCode.DataTextField = "PrimaryName";
			ddlTransactionStatusCode.DataSource = BLL.Payments.TransactionStatusManager.GetAllTransactionStatusData(Globals.DBOptions, Globals.getDataOptions("TransactionStatusName", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
			ddlTransactionStatusCode.DataBind();
			ddlTransactionStatusCode.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				BLL.Payments.TransactionStatus sTransactionStatus = new BLL.Payments.TransactionStatus();
				sTransactionStatus.TransactionStatusCode = MOD.Data.DataHelper.GetInt(vPaymentTransactionLog.TransactionStatusCode, MOD.Data.DefaultValue.Int);
				ddlTransactionStatusCode.SelectedValue = MOD.Data.DataHelper.GetString(sTransactionStatus.PrimaryIndex, "");
				sTransactionStatus = null;
			}
			catch {}
			if(ddlTransactionStatusCode.SelectedValue == ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				try
				{
					ddlTransactionStatusCode.SelectedValue = MOD.Data.DataHelper.GetString(Session["Payments/TransactionStatusWorkingSetItem"], "");
				}
				catch {}
			}
			txtTransactionAmount.Text = MOD.Data.EditHelper.GetCurrency(vPaymentTransactionLog.TransactionAmount);
			txtResponseCode.Text = MOD.Data.EditHelper.GetString(vPaymentTransactionLog.ResponseCode);
			txtTransactionCode.Text = MOD.Data.EditHelper.GetString(vPaymentTransactionLog.TransactionCode);
			txtTransactionMessage.Text = MOD.Data.EditHelper.GetString(vPaymentTransactionLog.TransactionMessage);
			txtBalance.Text = MOD.Data.EditHelper.GetCurrency(vPaymentTransactionLog.Balance);
			// Drop downs should be disabled when control is "Internal" and either value is constrained by container
			if (WorkflowMode == WorkflowMode.Internal)
			{
				ddlPaymentID.Visible = Request.QueryString["PaymentID"] == null;
				lnkPaymentIDWorkingSet.Visible = lnkPaymentIDWorkingSet.Visible == true && Request.QueryString["PaymentID"] == null;
				lblPaymentIDWorkingSet.Visible = lblPaymentIDWorkingSet.Visible == true && Request.QueryString["PaymentID"] == null;
				valPaymentID.Enabled = Request.QueryString["PaymentID"] == null;
				lblPaymentIDDisplay.Visible = Request.QueryString["PaymentID"] == null;
				ddlTransactionTypeCode.Visible = Request.QueryString["TransactionTypeCode"] == null;
				valTransactionTypeCode.Enabled = Request.QueryString["TransactionTypeCode"] == null;
				lblTransactionTypeCodeDisplay.Visible = Request.QueryString["TransactionTypeCode"] == null;
				ddlTransactionStatusCode.Visible = Request.QueryString["TransactionStatusCode"] == null;
				valTransactionStatusCode.Enabled = Request.QueryString["TransactionStatusCode"] == null;
				lblTransactionStatusCodeDisplay.Visible = Request.QueryString["TransactionStatusCode"] == null;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set Payment Transaction Log information from the form.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyFormToEntity()
		{
			BLL.Payments.PaymentTransactionLog vPaymentTransactionLog = PaymentTransactionLogItem;
			if (vPaymentTransactionLog == null)
			{
				throw CoreUtility.CustomAppException.WrapException(new Exception("Payment Transaction Log not found"), "EditPaymentTransactionLog.CopyFormToEntity()");
			}
			if (ddlPaymentID.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Payments.Payment sPayment = new BLL.Payments.Payment(ddlPaymentID.SelectedValue, false);
				vPaymentTransactionLog.PaymentID = MOD.Data.DataHelper.GetGuid(sPayment.PaymentID, MOD.Data.DefaultValue.Guid);
				sPayment = null;
			}
			if (ddlTransactionTypeCode.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Payments.TransactionType sTransactionType = new BLL.Payments.TransactionType(ddlTransactionTypeCode.SelectedValue, false);
				vPaymentTransactionLog.TransactionTypeCode = MOD.Data.DataHelper.GetInt(sTransactionType.TransactionTypeCode, MOD.Data.DefaultValue.Int);
				sTransactionType = null;
				vPaymentTransactionLog.PrimaryName += MOD.Data.DataHelper.GetString(ddlTransactionTypeCode.SelectedItem.Text, MOD.Data.DefaultValue.String) + ";";
			}
			if (ddlTransactionStatusCode.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Payments.TransactionStatus sTransactionStatus = new BLL.Payments.TransactionStatus(ddlTransactionStatusCode.SelectedValue, false);
				vPaymentTransactionLog.TransactionStatusCode = MOD.Data.DataHelper.GetInt(sTransactionStatus.TransactionStatusCode, MOD.Data.DefaultValue.Int);
				sTransactionStatus = null;
				vPaymentTransactionLog.PrimaryName += MOD.Data.DataHelper.GetString(ddlTransactionStatusCode.SelectedItem.Text, MOD.Data.DefaultValue.String) + ";";
			}
			try
			{
				vPaymentTransactionLog.TransactionAmount = MOD.Data.DataHelper.GetDecimal(txtTransactionAmount.Text, MOD.Data.DefaultValue.Decimal);
			}
			catch {}
			vPaymentTransactionLog.ResponseCode = EditHelper.EncodeStringForDB(MOD.Data.DataHelper.GetString(txtResponseCode.Text, null));
			vPaymentTransactionLog.TransactionCode = EditHelper.EncodeStringForDB(MOD.Data.DataHelper.GetString(txtTransactionCode.Text, null));
			vPaymentTransactionLog.TransactionMessage = EditHelper.EncodeStringForDB(MOD.Data.DataHelper.GetString(txtTransactionMessage.Text, null));
			try
			{
				vPaymentTransactionLog.Balance = MOD.Data.DataHelper.GetDecimal(txtBalance.Text, MOD.Data.DefaultValue.Decimal);
			}
			catch {}
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// Load entity from database, store in _entity and Session["PaymentTransactionLogItem"]
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void LoadEntity()
		{
			_entity = null;
			Guid paymentTransactionLogID = MOD.Data.DataHelper.GetGuid(Request.QueryString["PaymentTransactionLogID"], MOD.Data.DefaultValue.Guid);
			if (paymentTransactionLogID != MOD.Data.DefaultValue.Guid)
			{
				_entity = BLL.Payments.PaymentTransactionLogManager.GetOnePaymentTransactionLog(paymentTransactionLogID, Globals.getDataOptions("", "", true, true));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update Payment Transaction Log information in the database.</summary>
		///
		// ------------------------------------------------------------------------------
		private void UpsertToDatabase(bool performCascade)
		{
			BLL.Payments.PaymentTransactionLog vPaymentTransactionLog = PaymentTransactionLogItem;
			if (AccessMode == MOD.Data.AccessMode.Add)
			{
				BLL.Payments.PaymentTransactionLogManager.LogOnePaymentTransactionLog(vPaymentTransactionLog, performCascade);
			}
			else if (AccessMode == MOD.Data.AccessMode.Edit)
			{
			}
			PaymentTransactionLogItem.PaymentTransactionLogID = vPaymentTransactionLog.PaymentTransactionLogID;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set access and display modes for presenting Payment Transaction Log information.</summary>
		///
		// ------------------------------------------------------------------------------
		private void SetAccessModeAndDisplay(MOD.Data.AccessMode accessMode)
		{
			// set access mode
			if (accessMode == MOD.Data.AccessMode.Edit)
			{
				accessMode = MOD.Data.AccessMode.View;
			}
			AccessMode = accessMode;
			// set access mode display
			switch (AccessMode)
			{
				case MOD.Data.AccessMode.Add:
					lblTitle.Text = "Add Payment&nbsp;Transaction&nbsp;Log";
					btnSave.Text = "Add";
					break;
				case MOD.Data.AccessMode.Edit:
					lblTitle.Text = "Edit Payment&nbsp;Transaction&nbsp;Log";
					btnSave.Text = "Save";
					break;
				case MOD.Data.AccessMode.View:
					lblTitle.Text = "View Payment&nbsp;Transaction&nbsp;Log";
					break;
				default:
					lblTitle.Text = "View Payment&nbsp;Transaction&nbsp;Log";
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
				Section_Payment_Transaction_Attribute_Value_Logs.Visible = false;
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
					Section_Payment_Transaction_Attribute_Value_Logs.Visible = true;
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
		/// <summary>Initialize component for PaymentTransactionLog, add delegates here.</summary>
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