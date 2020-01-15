
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
	/// <summary>Edit Payment Transaction Attribute Value Log is used to help manage PaymentTransactionAttributeValueLog information.</summary>
	///
	/// File History:
	/// <created>6/1/2007 (Chris Grundy)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class EditPaymentTransactionAttributeValueLog  : Components.Desktop.BaseFormlUserControl
	{
		#region Events
		/// <summary>
		/// Raised when "Add" button is clicked in internal mode.
		/// Container handles this event and adds entity to collection.
		/// </summary>
		public event EntityEditEventHandler PaymentTransactionAttributeValueLogAdded;
		/// <summary>
		/// Raised when "Remove" button is clicked in internal mode.
		/// Container handles this event and removes entity from collection.
		/// </summary>
		public event EntityEditEventHandler PaymentTransactionAttributeValueLogRemoved;
		#endregion Events
		#region Declarations
		#endregion Declarations
		#region Properties
		/// <summary>
		/// The PaymentTransactionAttributeValueLog currently being edited by this control.
		/// Get accessor casts base._entity to PaymentTransactionAttributeValueLog
		/// Set accessor used by parent control to set the item currently being edited
		/// </summary>
		public BLL.Payments.PaymentTransactionAttributeValueLog PaymentTransactionAttributeValueLogItem
		{
			get
			{
				return (BLL.Payments.PaymentTransactionAttributeValueLog) _entity;
			}
			set
			{
				_entity = value; // only set by container
				Session["PaymentTransactionAttributeValueLogItem"] = _entity;
			}
		}
		#endregion Properties
		#region Event Handlers
		// ------------------------------------------------------------------------------
		/// <summary>Load page for editing Payment Transaction Attribute Value Log, getting mode and parameters.</summary>
		///
		// ------------------------------------------------------------------------------
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				base.OnLoad();
				if (IsPostBack == true)
				{
					// entity may come from session, or be set by container
					if (_entity == null)
					{
						_entity = (BLL.Payments.PaymentTransactionAttributeValueLog)Session["PaymentTransactionAttributeValueLogItem"];
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
					Session["PaymentTransactionAttributeValueLogItem"] = _entity;
				}
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditPaymentTransactionAttributeValueLog.Page_Load"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Delete Payment Transaction Attribute Value Log.</summary>
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
					if (PaymentTransactionAttributeValueLogRemoved != null)
					{
						PaymentTransactionAttributeValueLogRemoved(this, new EntityEditEventArgs(_entity));
					}
				}
				// create new object and store it in _entity
				CreateNewEntity();
				Session["PaymentTransactionAttributeValueLogItem"] = _entity;
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditPaymentTransactionAttributeValueLog.btnDelete_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("PaymentTransactionAttributeValueLogID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Request to create a new Payment Transaction Attribute Value Log.</summary>
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
				Session["PaymentTransactionAttributeValueLogItem"] = _entity;
				this.sectionLinks.OnSection("Basics");
				SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
				Globals.AddStatusMessage("Add new Payment Transaction Attribute Value Log.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				doRedirect = false;
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				doRedirect = false;
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditPaymentTransactionAttributeValueLog.btnNew_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("PaymentTransactionAttributeValueLogID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Reset form for Payment Transaction Attribute Value Log.</summary>
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
					Session["PaymentTransactionAttributeValueLogItem"] = _entity;
					sectionLinks.CurrentSection = "Basics";
				}
				else
				{
					CreateNewEntity();
				}
				Globals.AddStatusMessage("Payment Transaction Attribute Value Log reset.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditPaymentTransactionAttributeValueLog.btnReset_Click"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Save Payment Transaction Attribute Value Log.</summary>
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
							if (PaymentTransactionAttributeValueLogAdded != null && (PaymentTransactionAttributeValueLogItem.PaymentTransactionAttributeValueLogID != MOD.Data.DefaultValue.Guid || PaymentTransactionAttributeValueLogItem.PaymentTransactionLogID != MOD.Data.DefaultValue.Guid || PaymentTransactionAttributeValueLogItem.BaseAttributeID != MOD.Data.DefaultValue.Guid || PaymentTransactionAttributeValueLogItem.AttributeValue != MOD.Data.DefaultValue.String || PaymentTransactionAttributeValueLogItem.CreatedByUserID != MOD.Data.DefaultValue.Guid || PaymentTransactionAttributeValueLogItem.CreatedDate != MOD.Data.DefaultValue.DateTime || PaymentTransactionAttributeValueLogItem.LastModifiedByUserID != MOD.Data.DefaultValue.Guid || PaymentTransactionAttributeValueLogItem.LastModifiedDate != MOD.Data.DefaultValue.DateTime || PaymentTransactionAttributeValueLogItem.Timestamp != null))
							{
								PaymentTransactionAttributeValueLogAdded(this, new EntityEditEventArgs(_entity));
								// create new object and store it in _entity
								CreateNewEntity();
								Session["PaymentTransactionAttributeValueLogItem"] = _entity;
								this.sectionLinks.OnSection("Basics");
								SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
							}
						}
						else
						{
							Globals.AddStatusMessage("Payment Transaction Attribute Value Log updated.");
						}
					}
					else
					{
						UpsertToDatabase(true);
						if (AccessMode == MOD.Data.AccessMode.Add)
						{
							doRedirect = true;
							Globals.AddStatusMessage("Payment Transaction Attribute Value Log added.");
						}
						else
						{
							Globals.AddStatusMessage("Payment Transaction Attribute Value Log updated.");
						}
						SetAccessModeAndDisplay(MOD.Data.AccessMode.Edit);
					}
				}
				else
				{
					Globals.AddErrorMessage(Page, "Payment Transaction Attribute Value Log validation failed.");
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditPaymentTransactionAttributeValueLog.btnSave_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && isValid == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("PaymentTransactionAttributeValueLogID", PaymentTransactionAttributeValueLogItem.PaymentTransactionAttributeValueLogID.ToString());
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditPaymentTransactionAttributeValueLog.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditPaymentTransactionAttributeValueLog.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditPaymentTransactionAttributeValueLog.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditPaymentTransactionAttributeValueLog.Page_PreRender"));
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
		/// Create a new Payment Transaction Attribute Value Log object reference
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void CreateNewEntity()
		{
			BLL.Payments.PaymentTransactionAttributeValueLog vPaymentTransactionAttributeValueLog = new BLL.Payments.PaymentTransactionAttributeValueLog();
			vPaymentTransactionAttributeValueLog.PaymentTransactionAttributeValueLogID = MOD.Data.DataHelper.GetGuid(Request.QueryString["PaymentTransactionAttributeValueLogID"], MOD.Data.DefaultValue.Guid);
			vPaymentTransactionAttributeValueLog.PaymentTransactionLogID = MOD.Data.DataHelper.GetGuid(Request.QueryString["PaymentTransactionLogID"], MOD.Data.DefaultValue.Guid);
			vPaymentTransactionAttributeValueLog.BaseAttributeID = MOD.Data.DataHelper.GetGuid(Request.QueryString["BaseAttributeID"], MOD.Data.DefaultValue.Guid);
			_entity = vPaymentTransactionAttributeValueLog;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update form from Payment Transaction Attribute Value Log information.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyEntityToForm()
		{
			BLL.Payments.PaymentTransactionAttributeValueLog vPaymentTransactionAttributeValueLog = PaymentTransactionAttributeValueLogItem;
			lblPaymentTransactionAttributeValueLogID.Text = MOD.Data.DataHelper.GetString(vPaymentTransactionAttributeValueLog.PaymentTransactionAttributeValueLogID, "");
			ddlPaymentTransactionLogID.DataValueField = "PrimaryIndex";
			ddlPaymentTransactionLogID.DataTextField = "PrimaryName";
			if (UseWorkingSets == true && Session["Payments/PaymentTransactionLogWorkingSet"] != null)
			{
				BLL.SortableList<BLL.Payments.PaymentTransactionLog> sessionSource = (BLL.SortableList<BLL.Payments.PaymentTransactionLog>) Session["Payments/PaymentTransactionLogWorkingSet"];
				BLL.SortableList<BLL.Payments.PaymentTransactionLog> currentSource = new BLL.SortableList<BLL.Payments.PaymentTransactionLog>(sessionSource, true);
				if (MOD.Data.DataHelper.GetGuid(vPaymentTransactionAttributeValueLog.PaymentTransactionLogID, MOD.Data.DefaultValue.Guid) != MOD.Data.DefaultValue.Guid)
				{
					BLL.Payments.PaymentTransactionLog currentPaymentTransactionLog = BLL.Payments.PaymentTransactionLogManager.GetOnePaymentTransactionLog(MOD.Data.DataHelper.GetGuid(vPaymentTransactionAttributeValueLog.PaymentTransactionLogID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions("", "", true, true));
					if (currentPaymentTransactionLog != null && currentSource.Contains(currentPaymentTransactionLog) == false)
					{
						currentSource.Insert(0, currentPaymentTransactionLog);
					}
				}
				ddlPaymentTransactionLogID.DataSource = currentSource;
				lnkPaymentTransactionLogIDWorkingSet.Visible = true;
				lnkPaymentTransactionLogIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Payments/SearchPaymentTransactionLogData.aspx");
				lblPaymentTransactionLogIDWorkingSet.Visible = true;
				lblPaymentTransactionLogIDWorkingSet.Text = " (from Payment Transaction Log working set)";
			}
			else
			{
				ddlPaymentTransactionLogID.DataSource = BLL.Payments.PaymentTransactionLogManager.GetAllPaymentTransactionLogData(Globals.DBOptions, Globals.getDataOptions("", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
				lblPaymentTransactionLogIDWorkingSet.Visible = false;
				if (UseWorkingSets == true)
				{
					lnkPaymentTransactionLogIDWorkingSet.Visible = true;
					lnkPaymentTransactionLogIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Payments/SearchPaymentTransactionLogData.aspx");
				}
				else
				{
					lnkPaymentTransactionLogIDWorkingSet.Visible = false;
				}
			}
			ddlPaymentTransactionLogID.DataBind();
			ddlPaymentTransactionLogID.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				BLL.Payments.PaymentTransactionLog sPaymentTransactionLog = new BLL.Payments.PaymentTransactionLog();
				sPaymentTransactionLog.PaymentTransactionLogID = MOD.Data.DataHelper.GetGuid(vPaymentTransactionAttributeValueLog.PaymentTransactionLogID, MOD.Data.DefaultValue.Guid);
				ddlPaymentTransactionLogID.SelectedValue = MOD.Data.DataHelper.GetString(sPaymentTransactionLog.PrimaryIndex, "");
				sPaymentTransactionLog = null;
			}
			catch {}
			if(ddlPaymentTransactionLogID.SelectedValue == ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				try
				{
					ddlPaymentTransactionLogID.SelectedValue = MOD.Data.DataHelper.GetString(Session["Payments/PaymentTransactionLogWorkingSetItem"], "");
				}
				catch {}
			}
			ddlBaseAttributeID.DataValueField = "PrimaryIndex";
			ddlBaseAttributeID.DataTextField = "PrimaryName";
			if (UseWorkingSets == true && Session["Events/EventAttributeWorkingSet"] != null)
			{
				BLL.SortableList<BLL.Events.EventAttribute> sessionSource = (BLL.SortableList<BLL.Events.EventAttribute>) Session["Events/EventAttributeWorkingSet"];
				BLL.SortableList<BLL.Events.EventAttribute> currentSource = new BLL.SortableList<BLL.Events.EventAttribute>(sessionSource, true);
				if (MOD.Data.DataHelper.GetGuid(vPaymentTransactionAttributeValueLog.BaseAttributeID, MOD.Data.DefaultValue.Guid) != MOD.Data.DefaultValue.Guid)
				{
					BLL.Events.EventAttribute currentEventAttribute = BLL.Events.EventAttributeManager.GetOneEventAttribute(MOD.Data.DataHelper.GetGuid(vPaymentTransactionAttributeValueLog.BaseAttributeID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions("", "", true, true));
					if (currentEventAttribute != null && currentSource.Contains(currentEventAttribute) == false)
					{
						currentSource.Insert(0, currentEventAttribute);
					}
				}
				ddlBaseAttributeID.DataSource = currentSource;
				lnkBaseAttributeIDWorkingSet.Visible = true;
				lnkBaseAttributeIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Events/SearchEventAttributeData.aspx");
				lblBaseAttributeIDWorkingSet.Visible = true;
				lblBaseAttributeIDWorkingSet.Text = " (from Event Attribute working set)";
			}
			else
			{
				ddlBaseAttributeID.DataSource = BLL.Events.EventAttributeManager.GetAllEventAttributeData(Globals.DBOptions, Globals.getDataOptions("AttributeName", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
				lblBaseAttributeIDWorkingSet.Visible = false;
				if (UseWorkingSets == true)
				{
					lnkBaseAttributeIDWorkingSet.Visible = true;
					lnkBaseAttributeIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Events/SearchEventAttributeData.aspx");
				}
				else
				{
					lnkBaseAttributeIDWorkingSet.Visible = false;
				}
			}
			ddlBaseAttributeID.DataBind();
			ddlBaseAttributeID.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				BLL.Events.EventAttribute sEventAttribute = new BLL.Events.EventAttribute();
				sEventAttribute.BaseAttributeID = MOD.Data.DataHelper.GetGuid(vPaymentTransactionAttributeValueLog.BaseAttributeID, MOD.Data.DefaultValue.Guid);
				ddlBaseAttributeID.SelectedValue = MOD.Data.DataHelper.GetString(sEventAttribute.PrimaryIndex, "");
				sEventAttribute = null;
			}
			catch {}
			if(ddlBaseAttributeID.SelectedValue == ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				try
				{
					ddlBaseAttributeID.SelectedValue = MOD.Data.DataHelper.GetString(Session["Events/EventAttributeWorkingSetItem"], "");
				}
				catch {}
			}
			txtAttributeValue.Text = MOD.Data.EditHelper.GetString(vPaymentTransactionAttributeValueLog.AttributeValue);
			// Drop downs should be disabled when control is "Internal" and either value is constrained by container
			if (WorkflowMode == WorkflowMode.Internal)
			{
				ddlPaymentTransactionLogID.Visible = Request.QueryString["PaymentTransactionLogID"] == null;
				lnkPaymentTransactionLogIDWorkingSet.Visible = lnkPaymentTransactionLogIDWorkingSet.Visible == true && Request.QueryString["PaymentTransactionLogID"] == null;
				lblPaymentTransactionLogIDWorkingSet.Visible = lblPaymentTransactionLogIDWorkingSet.Visible == true && Request.QueryString["PaymentTransactionLogID"] == null;
				valPaymentTransactionLogID.Enabled = Request.QueryString["PaymentTransactionLogID"] == null;
				lblPaymentTransactionLogIDDisplay.Visible = Request.QueryString["PaymentTransactionLogID"] == null;
				ddlBaseAttributeID.Visible = Request.QueryString["BaseAttributeID"] == null;
				lnkBaseAttributeIDWorkingSet.Visible = lnkBaseAttributeIDWorkingSet.Visible == true && Request.QueryString["BaseAttributeID"] == null;
				lblBaseAttributeIDWorkingSet.Visible = lblBaseAttributeIDWorkingSet.Visible == true && Request.QueryString["BaseAttributeID"] == null;
				valBaseAttributeID.Enabled = Request.QueryString["BaseAttributeID"] == null;
				lblBaseAttributeIDDisplay.Visible = Request.QueryString["BaseAttributeID"] == null;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set Payment Transaction Attribute Value Log information from the form.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyFormToEntity()
		{
			BLL.Payments.PaymentTransactionAttributeValueLog vPaymentTransactionAttributeValueLog = PaymentTransactionAttributeValueLogItem;
			if (vPaymentTransactionAttributeValueLog == null)
			{
				throw CoreUtility.CustomAppException.WrapException(new Exception("Payment Transaction Attribute Value Log not found"), "EditPaymentTransactionAttributeValueLog.CopyFormToEntity()");
			}
			if (ddlPaymentTransactionLogID.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Payments.PaymentTransactionLog sPaymentTransactionLog = new BLL.Payments.PaymentTransactionLog(ddlPaymentTransactionLogID.SelectedValue, false);
				vPaymentTransactionAttributeValueLog.PaymentTransactionLogID = MOD.Data.DataHelper.GetGuid(sPaymentTransactionLog.PaymentTransactionLogID, MOD.Data.DefaultValue.Guid);
				sPaymentTransactionLog = null;
			}
			if (ddlBaseAttributeID.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Events.EventAttribute sEventAttribute = new BLL.Events.EventAttribute(ddlBaseAttributeID.SelectedValue, false);
				vPaymentTransactionAttributeValueLog.BaseAttributeID = MOD.Data.DataHelper.GetGuid(sEventAttribute.BaseAttributeID, MOD.Data.DefaultValue.Guid);
				sEventAttribute = null;
			}
			vPaymentTransactionAttributeValueLog.AttributeValue = EditHelper.EncodeStringForDB(MOD.Data.DataHelper.GetString(txtAttributeValue.Text, null));
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// Load entity from database, store in _entity and Session["PaymentTransactionAttributeValueLogItem"]
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void LoadEntity()
		{
			_entity = null;
			Guid paymentTransactionAttributeValueLogID = MOD.Data.DataHelper.GetGuid(Request.QueryString["PaymentTransactionAttributeValueLogID"], MOD.Data.DefaultValue.Guid);
			if (paymentTransactionAttributeValueLogID != MOD.Data.DefaultValue.Guid)
			{
				_entity = BLL.Payments.PaymentTransactionAttributeValueLogManager.GetOnePaymentTransactionAttributeValueLog(paymentTransactionAttributeValueLogID, Globals.getDataOptions("", "", true, true));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update Payment Transaction Attribute Value Log information in the database.</summary>
		///
		// ------------------------------------------------------------------------------
		private void UpsertToDatabase(bool performCascade)
		{
			BLL.Payments.PaymentTransactionAttributeValueLog vPaymentTransactionAttributeValueLog = PaymentTransactionAttributeValueLogItem;
			if (AccessMode == MOD.Data.AccessMode.Add)
			{
				BLL.Payments.PaymentTransactionAttributeValueLogManager.LogOnePaymentTransactionAttributeValueLog(vPaymentTransactionAttributeValueLog, performCascade);
			}
			else if (AccessMode == MOD.Data.AccessMode.Edit)
			{
			}
			PaymentTransactionAttributeValueLogItem.PaymentTransactionAttributeValueLogID = vPaymentTransactionAttributeValueLog.PaymentTransactionAttributeValueLogID;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set access and display modes for presenting Payment Transaction Attribute Value Log information.</summary>
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
					lblTitle.Text = "Add Payment&nbsp;Transaction&nbsp;Attribute&nbsp;Value&nbsp;Log";
					btnSave.Text = "Add";
					break;
				case MOD.Data.AccessMode.Edit:
					lblTitle.Text = "Edit Payment&nbsp;Transaction&nbsp;Attribute&nbsp;Value&nbsp;Log";
					btnSave.Text = "Save";
					break;
				case MOD.Data.AccessMode.View:
					lblTitle.Text = "View Payment&nbsp;Transaction&nbsp;Attribute&nbsp;Value&nbsp;Log";
					break;
				default:
					lblTitle.Text = "View Payment&nbsp;Transaction&nbsp;Attribute&nbsp;Value&nbsp;Log";
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
		/// <summary>Initialize component for PaymentTransactionAttributeValueLog, add delegates here.</summary>
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