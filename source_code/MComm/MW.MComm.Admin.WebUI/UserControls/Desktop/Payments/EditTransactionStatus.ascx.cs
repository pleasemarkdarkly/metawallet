
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
	/// <summary>Edit Transaction Status is used to help manage TransactionStatus information.</summary>
	///
	/// File History:
	/// <created>6/1/2007 (Chris Grundy)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class EditTransactionStatus  : Components.Desktop.BaseFormlUserControl
	{
		#region Events
		/// <summary>
		/// Raised when "Add" button is clicked in internal mode.
		/// Container handles this event and adds entity to collection.
		/// </summary>
		public event EntityEditEventHandler TransactionStatusAdded;
		/// <summary>
		/// Raised when "Remove" button is clicked in internal mode.
		/// Container handles this event and removes entity from collection.
		/// </summary>
		public event EntityEditEventHandler TransactionStatusRemoved;
		#endregion Events
		#region Declarations
		#endregion Declarations
		#region Properties
		/// <summary>
		/// The TransactionStatus currently being edited by this control.
		/// Get accessor casts base._entity to TransactionStatus
		/// Set accessor used by parent control to set the item currently being edited
		/// </summary>
		public BLL.Payments.TransactionStatus TransactionStatusItem
		{
			get
			{
				return (BLL.Payments.TransactionStatus) _entity;
			}
			set
			{
				_entity = value; // only set by container
				Session["TransactionStatusItem"] = _entity;
			}
		}
		#endregion Properties
		#region Event Handlers
		// ------------------------------------------------------------------------------
		/// <summary>Load page for editing Transaction Status, getting mode and parameters.</summary>
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
						_entity = (BLL.Payments.TransactionStatus)Session["TransactionStatusItem"];
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
					Session["TransactionStatusItem"] = _entity;
				}
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditTransactionStatus.Page_Load"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Delete Transaction Status.</summary>
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
					BLL.Payments.TransactionStatusManager.DeleteOneTransactionStatus(TransactionStatusItem, performCascade);
					Globals.AddStatusMessage("Transaction Status deleted.");
				}
				else
				{
					// raise event so item is removed from collection
					if (TransactionStatusRemoved != null)
					{
						TransactionStatusRemoved(this, new EntityEditEventArgs(_entity));
					}
				}
				// create new object and store it in _entity
				CreateNewEntity();
				Session["TransactionStatusItem"] = _entity;
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditTransactionStatus.btnDelete_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("TransactionStatusCode", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Int, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Request to create a new Transaction Status.</summary>
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
				Session["TransactionStatusItem"] = _entity;
				this.sectionLinks.OnSection("Basics");
				SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
				Globals.AddStatusMessage("Add new Transaction Status.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				doRedirect = false;
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				doRedirect = false;
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditTransactionStatus.btnNew_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("TransactionStatusCode", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Int, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Reset form for Transaction Status.</summary>
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
					Session["TransactionStatusItem"] = _entity;
					sectionLinks.CurrentSection = "Basics";
				}
				else
				{
					CreateNewEntity();
				}
				Globals.AddStatusMessage("Transaction Status reset.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditTransactionStatus.btnReset_Click"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Save Transaction Status.</summary>
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
							if (TransactionStatusAdded != null && (TransactionStatusItem.TransactionStatusCode != MOD.Data.DefaultValue.Int || TransactionStatusItem.TransactionStatusName != MOD.Data.DefaultValue.String || TransactionStatusItem.Description != MOD.Data.DefaultValue.String || TransactionStatusItem.IsActive != MOD.Data.DefaultValue.Bool || TransactionStatusItem.CreatedByUserID != MOD.Data.DefaultValue.Guid || TransactionStatusItem.CreatedDate != MOD.Data.DefaultValue.DateTime || TransactionStatusItem.LastModifiedByUserID != MOD.Data.DefaultValue.Guid || TransactionStatusItem.LastModifiedDate != MOD.Data.DefaultValue.DateTime || TransactionStatusItem.Timestamp != null))
							{
								TransactionStatusAdded(this, new EntityEditEventArgs(_entity));
								// create new object and store it in _entity
								CreateNewEntity();
								Session["TransactionStatusItem"] = _entity;
								this.sectionLinks.OnSection("Basics");
								SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
							}
						}
						else
						{
							Globals.AddStatusMessage("Transaction Status updated.");
						}
					}
					else
					{
						UpsertToDatabase(true);
						if (AccessMode == MOD.Data.AccessMode.Add)
						{
							doRedirect = true;
							Globals.AddStatusMessage("Transaction Status added.");
						}
						else
						{
							Globals.AddStatusMessage("Transaction Status updated.");
						}
						SetAccessModeAndDisplay(MOD.Data.AccessMode.Edit);
					}
				}
				else
				{
					Globals.AddErrorMessage(Page, "Transaction Status validation failed.");
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditTransactionStatus.btnSave_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && isValid == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("TransactionStatusCode", TransactionStatusItem.TransactionStatusCode.ToString());
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditTransactionStatus.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditTransactionStatus.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditTransactionStatus.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditTransactionStatus.Page_PreRender"));
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
		/// Create a new Transaction Status object reference
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void CreateNewEntity()
		{
			BLL.Payments.TransactionStatus vTransactionStatus = new BLL.Payments.TransactionStatus();
			vTransactionStatus.TransactionStatusCode = MOD.Data.DataHelper.GetInt(Request.QueryString["TransactionStatusCode"], MOD.Data.DefaultValue.Int);
			_entity = vTransactionStatus;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update form from Transaction Status information.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyEntityToForm()
		{
			BLL.Payments.TransactionStatus vTransactionStatus = TransactionStatusItem;
			txtTransactionStatusCode.Text = MOD.Data.EditHelper.GetInt(vTransactionStatus.TransactionStatusCode);
			txtTransactionStatusName.Text = MOD.Data.EditHelper.GetString(vTransactionStatus.TransactionStatusName);
			txtDescription.Text = MOD.Data.EditHelper.GetString(vTransactionStatus.Description);
			chkIsActive.Checked = MOD.Data.DataHelper.GetBool(vTransactionStatus.IsActive, MOD.Data.DefaultValue.Bool);
			// Drop downs should be disabled when control is "Internal" and either value is constrained by container
			if (WorkflowMode == WorkflowMode.Internal)
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set Transaction Status information from the form.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyFormToEntity()
		{
			BLL.Payments.TransactionStatus vTransactionStatus = TransactionStatusItem;
			if (vTransactionStatus == null)
			{
				throw CoreUtility.CustomAppException.WrapException(new Exception("Transaction Status not found"), "EditTransactionStatus.CopyFormToEntity()");
			}
			try
			{
				vTransactionStatus.TransactionStatusCode = MOD.Data.DataHelper.GetInt(txtTransactionStatusCode.Text, MOD.Data.DefaultValue.Int);
			}
			catch {}
			vTransactionStatus.TransactionStatusName = EditHelper.EncodeStringForDB(MOD.Data.DataHelper.GetString(txtTransactionStatusName.Text, null));
			vTransactionStatus.Description = EditHelper.EncodeStringForDB(MOD.Data.DataHelper.GetString(txtDescription.Text, null));
			vTransactionStatus.IsActive = chkIsActive.Checked;
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// Load entity from database, store in _entity and Session["TransactionStatusItem"]
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void LoadEntity()
		{
			_entity = null;
			int transactionStatusCode = MOD.Data.DataHelper.GetInt(Request.QueryString["TransactionStatusCode"], MOD.Data.DefaultValue.Int);
			if (transactionStatusCode != MOD.Data.DefaultValue.Int)
			{
				_entity = BLL.Payments.TransactionStatusManager.GetOneTransactionStatus(transactionStatusCode, Globals.getDataOptions("", "", true, true));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update Transaction Status information in the database.</summary>
		///
		// ------------------------------------------------------------------------------
		private void UpsertToDatabase(bool performCascade)
		{
			BLL.Payments.TransactionStatus vTransactionStatus = TransactionStatusItem;
			if (AccessMode == MOD.Data.AccessMode.Add)
			{
				BLL.Payments.TransactionStatusManager.AddOneTransactionStatus(vTransactionStatus, performCascade);
			}
			else if (AccessMode == MOD.Data.AccessMode.Edit)
			{
				BLL.Payments.TransactionStatusManager.UpdateOneTransactionStatus(vTransactionStatus, performCascade);
			}
			TransactionStatusItem.TransactionStatusCode = vTransactionStatus.TransactionStatusCode;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set access and display modes for presenting Transaction Status information.</summary>
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
					lblTitle.Text = "Add Transaction&nbsp;Status";
					btnSave.Text = "Add";
					break;
				case MOD.Data.AccessMode.Edit:
					lblTitle.Text = "Edit Transaction&nbsp;Status";
					btnSave.Text = "Save";
					break;
				case MOD.Data.AccessMode.View:
					lblTitle.Text = "View Transaction&nbsp;Status";
					break;
				default:
					lblTitle.Text = "View Transaction&nbsp;Status";
					break;
			}
			btnDelete.Visible = IsDeleteAvailable;
			btnNew.Visible = IsEditAvailable;
			btnSave.Visible = IsEditAvailable || IsAddAvailable;
			txtTransactionStatusCode.Enabled = IsAddAvailable;
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
		/// <summary>Initialize component for TransactionStatus, add delegates here.</summary>
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