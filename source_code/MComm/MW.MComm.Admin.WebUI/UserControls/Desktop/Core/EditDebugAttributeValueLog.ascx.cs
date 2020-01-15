
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
using MW.MComm.WalletSolution.BLL.Core;
using CoreUtility = MW.MComm.WalletSolution.Utility;
using MW.MComm.Admin.WebUI.Components.Desktop;
namespace MW.MComm.Admin.WebUI.UserControls.Desktop.Core
{
	// ------------------------------------------------------------------------------
	/// <summary>Edit Debug Attribute Value Log is used to help manage DebugAttributeValueLog information.</summary>
	///
	/// File History:
	/// <created>6/1/2007 (Chris Grundy)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class EditDebugAttributeValueLog  : Components.Desktop.BaseFormlUserControl
	{
		#region Events
		/// <summary>
		/// Raised when "Add" button is clicked in internal mode.
		/// Container handles this event and adds entity to collection.
		/// </summary>
		public event EntityEditEventHandler DebugAttributeValueLogAdded;
		/// <summary>
		/// Raised when "Remove" button is clicked in internal mode.
		/// Container handles this event and removes entity from collection.
		/// </summary>
		public event EntityEditEventHandler DebugAttributeValueLogRemoved;
		#endregion Events
		#region Declarations
		#endregion Declarations
		#region Properties
		/// <summary>
		/// The DebugAttributeValueLog currently being edited by this control.
		/// Get accessor casts base._entity to DebugAttributeValueLog
		/// Set accessor used by parent control to set the item currently being edited
		/// </summary>
		public BLL.Core.DebugAttributeValueLog DebugAttributeValueLogItem
		{
			get
			{
				return (BLL.Core.DebugAttributeValueLog) _entity;
			}
			set
			{
				_entity = value; // only set by container
				Session["DebugAttributeValueLogItem"] = _entity;
			}
		}
		#endregion Properties
		#region Event Handlers
		// ------------------------------------------------------------------------------
		/// <summary>Load page for editing Debug Attribute Value Log, getting mode and parameters.</summary>
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
						_entity = (BLL.Core.DebugAttributeValueLog)Session["DebugAttributeValueLogItem"];
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
					Session["DebugAttributeValueLogItem"] = _entity;
				}
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditDebugAttributeValueLog.Page_Load"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Delete Debug Attribute Value Log.</summary>
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
					if (DebugAttributeValueLogRemoved != null)
					{
						DebugAttributeValueLogRemoved(this, new EntityEditEventArgs(_entity));
					}
				}
				// create new object and store it in _entity
				CreateNewEntity();
				Session["DebugAttributeValueLogItem"] = _entity;
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditDebugAttributeValueLog.btnDelete_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("DebugAttributeValueLogID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Request to create a new Debug Attribute Value Log.</summary>
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
				Session["DebugAttributeValueLogItem"] = _entity;
				this.sectionLinks.OnSection("Basics");
				SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
				Globals.AddStatusMessage("Add new Debug Attribute Value Log.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				doRedirect = false;
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				doRedirect = false;
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditDebugAttributeValueLog.btnNew_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("DebugAttributeValueLogID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Reset form for Debug Attribute Value Log.</summary>
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
					Session["DebugAttributeValueLogItem"] = _entity;
					sectionLinks.CurrentSection = "Basics";
				}
				else
				{
					CreateNewEntity();
				}
				Globals.AddStatusMessage("Debug Attribute Value Log reset.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditDebugAttributeValueLog.btnReset_Click"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Save Debug Attribute Value Log.</summary>
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
							if (DebugAttributeValueLogAdded != null && (DebugAttributeValueLogItem.DebugAttributeValueLogID != MOD.Data.DefaultValue.Guid || DebugAttributeValueLogItem.DebugLogID != MOD.Data.DefaultValue.Guid || DebugAttributeValueLogItem.BaseAttributeID != MOD.Data.DefaultValue.Guid || DebugAttributeValueLogItem.AttributeValue != MOD.Data.DefaultValue.String || DebugAttributeValueLogItem.CreatedByUserID != MOD.Data.DefaultValue.Guid || DebugAttributeValueLogItem.CreatedDate != MOD.Data.DefaultValue.DateTime || DebugAttributeValueLogItem.LastModifiedByUserID != MOD.Data.DefaultValue.Guid || DebugAttributeValueLogItem.LastModifiedDate != MOD.Data.DefaultValue.DateTime || DebugAttributeValueLogItem.Timestamp != null))
							{
								DebugAttributeValueLogAdded(this, new EntityEditEventArgs(_entity));
								// create new object and store it in _entity
								CreateNewEntity();
								Session["DebugAttributeValueLogItem"] = _entity;
								this.sectionLinks.OnSection("Basics");
								SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
							}
						}
						else
						{
							Globals.AddStatusMessage("Debug Attribute Value Log updated.");
						}
					}
					else
					{
						UpsertToDatabase(true);
						if (AccessMode == MOD.Data.AccessMode.Add)
						{
							doRedirect = true;
							Globals.AddStatusMessage("Debug Attribute Value Log added.");
						}
						else
						{
							Globals.AddStatusMessage("Debug Attribute Value Log updated.");
						}
						SetAccessModeAndDisplay(MOD.Data.AccessMode.Edit);
					}
				}
				else
				{
					Globals.AddErrorMessage(Page, "Debug Attribute Value Log validation failed.");
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditDebugAttributeValueLog.btnSave_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && isValid == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("DebugAttributeValueLogID", DebugAttributeValueLogItem.DebugAttributeValueLogID.ToString());
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditDebugAttributeValueLog.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditDebugAttributeValueLog.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditDebugAttributeValueLog.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditDebugAttributeValueLog.Page_PreRender"));
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
		/// Create a new Debug Attribute Value Log object reference
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void CreateNewEntity()
		{
			BLL.Core.DebugAttributeValueLog vDebugAttributeValueLog = new BLL.Core.DebugAttributeValueLog();
			vDebugAttributeValueLog.DebugAttributeValueLogID = MOD.Data.DataHelper.GetGuid(Request.QueryString["DebugAttributeValueLogID"], MOD.Data.DefaultValue.Guid);
			vDebugAttributeValueLog.DebugLogID = MOD.Data.DataHelper.GetGuid(Request.QueryString["DebugLogID"], MOD.Data.DefaultValue.Guid);
			vDebugAttributeValueLog.BaseAttributeID = MOD.Data.DataHelper.GetGuid(Request.QueryString["BaseAttributeID"], MOD.Data.DefaultValue.Guid);
			_entity = vDebugAttributeValueLog;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update form from Debug Attribute Value Log information.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyEntityToForm()
		{
			BLL.Core.DebugAttributeValueLog vDebugAttributeValueLog = DebugAttributeValueLogItem;
			lblDebugAttributeValueLogID.Text = MOD.Data.DataHelper.GetString(vDebugAttributeValueLog.DebugAttributeValueLogID, "");
			ddlDebugLogID.DataValueField = "PrimaryIndex";
			ddlDebugLogID.DataTextField = "PrimaryName";
			if (UseWorkingSets == true && Session["Core/DebugLogWorkingSet"] != null)
			{
				BLL.SortableList<BLL.Core.DebugLog> sessionSource = (BLL.SortableList<BLL.Core.DebugLog>) Session["Core/DebugLogWorkingSet"];
				BLL.SortableList<BLL.Core.DebugLog> currentSource = new BLL.SortableList<BLL.Core.DebugLog>(sessionSource, true);
				if (MOD.Data.DataHelper.GetGuid(vDebugAttributeValueLog.DebugLogID, MOD.Data.DefaultValue.Guid) != MOD.Data.DefaultValue.Guid)
				{
					BLL.Core.DebugLog currentDebugLog = BLL.Core.DebugLogManager.GetOneDebugLog(MOD.Data.DataHelper.GetGuid(vDebugAttributeValueLog.DebugLogID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions("", "", true, true));
					if (currentDebugLog != null && currentSource.Contains(currentDebugLog) == false)
					{
						currentSource.Insert(0, currentDebugLog);
					}
				}
				ddlDebugLogID.DataSource = currentSource;
				lnkDebugLogIDWorkingSet.Visible = true;
				lnkDebugLogIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Core/SearchDebugLogData.aspx");
				lblDebugLogIDWorkingSet.Visible = true;
				lblDebugLogIDWorkingSet.Text = " (from Debug Log working set)";
			}
			else
			{
				ddlDebugLogID.DataSource = BLL.Core.DebugLogManager.GetAllDebugLogData(Globals.DBOptions, Globals.getDataOptions("", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
				lblDebugLogIDWorkingSet.Visible = false;
				if (UseWorkingSets == true)
				{
					lnkDebugLogIDWorkingSet.Visible = true;
					lnkDebugLogIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Core/SearchDebugLogData.aspx");
				}
				else
				{
					lnkDebugLogIDWorkingSet.Visible = false;
				}
			}
			ddlDebugLogID.DataBind();
			ddlDebugLogID.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				BLL.Core.DebugLog sDebugLog = new BLL.Core.DebugLog();
				sDebugLog.DebugLogID = MOD.Data.DataHelper.GetGuid(vDebugAttributeValueLog.DebugLogID, MOD.Data.DefaultValue.Guid);
				ddlDebugLogID.SelectedValue = MOD.Data.DataHelper.GetString(sDebugLog.PrimaryIndex, "");
				sDebugLog = null;
			}
			catch {}
			if(ddlDebugLogID.SelectedValue == ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				try
				{
					ddlDebugLogID.SelectedValue = MOD.Data.DataHelper.GetString(Session["Core/DebugLogWorkingSetItem"], "");
				}
				catch {}
			}
			ddlBaseAttributeID.DataValueField = "PrimaryIndex";
			ddlBaseAttributeID.DataTextField = "PrimaryName";
			if (UseWorkingSets == true && Session["Core/DebugAttributeWorkingSet"] != null)
			{
				BLL.SortableList<BLL.Core.DebugAttribute> sessionSource = (BLL.SortableList<BLL.Core.DebugAttribute>) Session["Core/DebugAttributeWorkingSet"];
				BLL.SortableList<BLL.Core.DebugAttribute> currentSource = new BLL.SortableList<BLL.Core.DebugAttribute>(sessionSource, true);
				if (MOD.Data.DataHelper.GetGuid(vDebugAttributeValueLog.BaseAttributeID, MOD.Data.DefaultValue.Guid) != MOD.Data.DefaultValue.Guid)
				{
					BLL.Core.DebugAttribute currentDebugAttribute = BLL.Core.DebugAttributeManager.GetOneDebugAttribute(MOD.Data.DataHelper.GetGuid(vDebugAttributeValueLog.BaseAttributeID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions("", "", true, true));
					if (currentDebugAttribute != null && currentSource.Contains(currentDebugAttribute) == false)
					{
						currentSource.Insert(0, currentDebugAttribute);
					}
				}
				ddlBaseAttributeID.DataSource = currentSource;
				lnkBaseAttributeIDWorkingSet.Visible = true;
				lnkBaseAttributeIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Core/SearchDebugAttributeData.aspx");
				lblBaseAttributeIDWorkingSet.Visible = true;
				lblBaseAttributeIDWorkingSet.Text = " (from Debug Attribute working set)";
			}
			else
			{
				ddlBaseAttributeID.DataSource = BLL.Core.DebugAttributeManager.GetAllDebugAttributeData(Globals.DBOptions, Globals.getDataOptions("AttributeName", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
				lblBaseAttributeIDWorkingSet.Visible = false;
				if (UseWorkingSets == true)
				{
					lnkBaseAttributeIDWorkingSet.Visible = true;
					lnkBaseAttributeIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Core/SearchDebugAttributeData.aspx");
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
				BLL.Core.DebugAttribute sDebugAttribute = new BLL.Core.DebugAttribute();
				sDebugAttribute.BaseAttributeID = MOD.Data.DataHelper.GetGuid(vDebugAttributeValueLog.BaseAttributeID, MOD.Data.DefaultValue.Guid);
				ddlBaseAttributeID.SelectedValue = MOD.Data.DataHelper.GetString(sDebugAttribute.PrimaryIndex, "");
				sDebugAttribute = null;
			}
			catch {}
			if(ddlBaseAttributeID.SelectedValue == ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				try
				{
					ddlBaseAttributeID.SelectedValue = MOD.Data.DataHelper.GetString(Session["Core/DebugAttributeWorkingSetItem"], "");
				}
				catch {}
			}
			txtAttributeValue.Text = MOD.Data.EditHelper.GetString(vDebugAttributeValueLog.AttributeValue);
			// Drop downs should be disabled when control is "Internal" and either value is constrained by container
			if (WorkflowMode == WorkflowMode.Internal)
			{
				ddlDebugLogID.Visible = Request.QueryString["DebugLogID"] == null;
				lnkDebugLogIDWorkingSet.Visible = lnkDebugLogIDWorkingSet.Visible == true && Request.QueryString["DebugLogID"] == null;
				lblDebugLogIDWorkingSet.Visible = lblDebugLogIDWorkingSet.Visible == true && Request.QueryString["DebugLogID"] == null;
				valDebugLogID.Enabled = Request.QueryString["DebugLogID"] == null;
				lblDebugLogIDDisplay.Visible = Request.QueryString["DebugLogID"] == null;
				ddlBaseAttributeID.Visible = Request.QueryString["BaseAttributeID"] == null;
				lnkBaseAttributeIDWorkingSet.Visible = lnkBaseAttributeIDWorkingSet.Visible == true && Request.QueryString["BaseAttributeID"] == null;
				lblBaseAttributeIDWorkingSet.Visible = lblBaseAttributeIDWorkingSet.Visible == true && Request.QueryString["BaseAttributeID"] == null;
				valBaseAttributeID.Enabled = Request.QueryString["BaseAttributeID"] == null;
				lblBaseAttributeIDDisplay.Visible = Request.QueryString["BaseAttributeID"] == null;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set Debug Attribute Value Log information from the form.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyFormToEntity()
		{
			BLL.Core.DebugAttributeValueLog vDebugAttributeValueLog = DebugAttributeValueLogItem;
			if (vDebugAttributeValueLog == null)
			{
				throw CoreUtility.CustomAppException.WrapException(new Exception("Debug Attribute Value Log not found"), "EditDebugAttributeValueLog.CopyFormToEntity()");
			}
			if (ddlDebugLogID.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Core.DebugLog sDebugLog = new BLL.Core.DebugLog(ddlDebugLogID.SelectedValue, false);
				vDebugAttributeValueLog.DebugLogID = MOD.Data.DataHelper.GetGuid(sDebugLog.DebugLogID, MOD.Data.DefaultValue.Guid);
				sDebugLog = null;
			}
			if (ddlBaseAttributeID.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Core.DebugAttribute sDebugAttribute = new BLL.Core.DebugAttribute(ddlBaseAttributeID.SelectedValue, false);
				vDebugAttributeValueLog.BaseAttributeID = MOD.Data.DataHelper.GetGuid(sDebugAttribute.BaseAttributeID, MOD.Data.DefaultValue.Guid);
				sDebugAttribute = null;
			}
			vDebugAttributeValueLog.AttributeValue = EditHelper.EncodeStringForDB(MOD.Data.DataHelper.GetString(txtAttributeValue.Text, null));
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// Load entity from database, store in _entity and Session["DebugAttributeValueLogItem"]
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void LoadEntity()
		{
			_entity = null;
			Guid debugAttributeValueLogID = MOD.Data.DataHelper.GetGuid(Request.QueryString["DebugAttributeValueLogID"], MOD.Data.DefaultValue.Guid);
			if (debugAttributeValueLogID != MOD.Data.DefaultValue.Guid)
			{
				_entity = BLL.Core.DebugAttributeValueLogManager.GetOneDebugAttributeValueLog(debugAttributeValueLogID, Globals.getDataOptions("", "", true, true));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update Debug Attribute Value Log information in the database.</summary>
		///
		// ------------------------------------------------------------------------------
		private void UpsertToDatabase(bool performCascade)
		{
			BLL.Core.DebugAttributeValueLog vDebugAttributeValueLog = DebugAttributeValueLogItem;
			if (AccessMode == MOD.Data.AccessMode.Add)
			{
				BLL.Core.DebugAttributeValueLogManager.LogOneDebugAttributeValueLog(vDebugAttributeValueLog, performCascade);
			}
			else if (AccessMode == MOD.Data.AccessMode.Edit)
			{
			}
			DebugAttributeValueLogItem.DebugAttributeValueLogID = vDebugAttributeValueLog.DebugAttributeValueLogID;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set access and display modes for presenting Debug Attribute Value Log information.</summary>
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
					lblTitle.Text = "Add Debug&nbsp;Attribute&nbsp;Value&nbsp;Log";
					btnSave.Text = "Add";
					break;
				case MOD.Data.AccessMode.Edit:
					lblTitle.Text = "Edit Debug&nbsp;Attribute&nbsp;Value&nbsp;Log";
					btnSave.Text = "Save";
					break;
				case MOD.Data.AccessMode.View:
					lblTitle.Text = "View Debug&nbsp;Attribute&nbsp;Value&nbsp;Log";
					break;
				default:
					lblTitle.Text = "View Debug&nbsp;Attribute&nbsp;Value&nbsp;Log";
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
		/// <summary>Initialize component for DebugAttributeValueLog, add delegates here.</summary>
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