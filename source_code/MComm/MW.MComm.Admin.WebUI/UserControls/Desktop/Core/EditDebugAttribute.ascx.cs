
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
	/// <summary>Edit Debug Attribute is used to help manage DebugAttribute information.</summary>
	///
	/// File History:
	/// <created>6/1/2007 (Chris Grundy)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class EditDebugAttribute  : Components.Desktop.BaseFormlUserControl
	{
		#region Events
		/// <summary>
		/// Raised when "Add" button is clicked in internal mode.
		/// Container handles this event and adds entity to collection.
		/// </summary>
		public event EntityEditEventHandler DebugAttributeAdded;
		/// <summary>
		/// Raised when "Remove" button is clicked in internal mode.
		/// Container handles this event and removes entity from collection.
		/// </summary>
		public event EntityEditEventHandler DebugAttributeRemoved;
		#endregion Events
		#region Declarations
		#endregion Declarations
		#region Properties
		/// <summary>
		/// The DebugAttribute currently being edited by this control.
		/// Get accessor casts base._entity to DebugAttribute
		/// Set accessor used by parent control to set the item currently being edited
		/// </summary>
		public BLL.Core.DebugAttribute DebugAttributeItem
		{
			get
			{
				return (BLL.Core.DebugAttribute) _entity;
			}
			set
			{
				_entity = value; // only set by container
				Session["DebugAttributeItem"] = _entity;
			}
		}
		#endregion Properties
		#region Event Handlers
		// ------------------------------------------------------------------------------
		/// <summary>Load page for editing Debug Attribute, getting mode and parameters.</summary>
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
						_entity = (BLL.Core.DebugAttribute)Session["DebugAttributeItem"];
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
					Session["DebugAttributeItem"] = _entity;
				}
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditDebugAttribute.Page_Load"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Delete Debug Attribute.</summary>
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
					BLL.Core.DebugAttributeManager.DeleteOneDebugAttribute(DebugAttributeItem, performCascade);
					Globals.AddStatusMessage("Debug Attribute deleted.");
				}
				else
				{
					// raise event so item is removed from collection
					if (DebugAttributeRemoved != null)
					{
						DebugAttributeRemoved(this, new EntityEditEventArgs(_entity));
					}
				}
				// create new object and store it in _entity
				CreateNewEntity();
				Session["DebugAttributeItem"] = _entity;
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditDebugAttribute.btnDelete_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("BaseAttributeID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Request to create a new Debug Attribute.</summary>
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
				Session["DebugAttributeItem"] = _entity;
				this.sectionLinks.OnSection("Basics");
				SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
				Globals.AddStatusMessage("Add new Debug Attribute.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				doRedirect = false;
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				doRedirect = false;
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditDebugAttribute.btnNew_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("BaseAttributeID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Reset form for Debug Attribute.</summary>
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
					Session["DebugAttributeItem"] = _entity;
					sectionLinks.CurrentSection = "Basics";
				}
				else
				{
					CreateNewEntity();
				}
				Globals.AddStatusMessage("Debug Attribute reset.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditDebugAttribute.btnReset_Click"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Save Debug Attribute.</summary>
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
							if (DebugAttributeAdded != null && (DebugAttributeItem.BaseAttributeID != MOD.Data.DefaultValue.Guid || DebugAttributeItem.AttributeCode != MOD.Data.DefaultValue.Int || DebugAttributeItem.CreatedByUserID != MOD.Data.DefaultValue.Guid || DebugAttributeItem.CreatedDate != MOD.Data.DefaultValue.DateTime || DebugAttributeItem.LastModifiedByUserID != MOD.Data.DefaultValue.Guid || DebugAttributeItem.LastModifiedDate != MOD.Data.DefaultValue.DateTime || DebugAttributeItem.Timestamp != null))
							{
								DebugAttributeAdded(this, new EntityEditEventArgs(_entity));
								// create new object and store it in _entity
								CreateNewEntity();
								Session["DebugAttributeItem"] = _entity;
								this.sectionLinks.OnSection("Basics");
								SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
							}
						}
						else
						{
							Globals.AddStatusMessage("Debug Attribute updated.");
						}
					}
					else
					{
						UpsertToDatabase(true);
						if (AccessMode == MOD.Data.AccessMode.Add)
						{
							doRedirect = true;
							Globals.AddStatusMessage("Debug Attribute added.");
						}
						else
						{
							Globals.AddStatusMessage("Debug Attribute updated.");
						}
						SetAccessModeAndDisplay(MOD.Data.AccessMode.Edit);
					}
				}
				else
				{
					Globals.AddErrorMessage(Page, "Debug Attribute validation failed.");
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditDebugAttribute.btnSave_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && isValid == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("BaseAttributeID", DebugAttributeItem.BaseAttributeID.ToString());
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditDebugAttribute.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditDebugAttribute.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditDebugAttribute.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditDebugAttribute.Page_PreRender"));
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
		/// Create a new Debug Attribute object reference
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void CreateNewEntity()
		{
			BLL.Core.DebugAttribute vDebugAttribute = new BLL.Core.DebugAttribute();
			vDebugAttribute.BaseAttributeID = MOD.Data.DataHelper.GetGuid(Request.QueryString["BaseAttributeID"], MOD.Data.DefaultValue.Guid);
			_entity = vDebugAttribute;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update form from Debug Attribute information.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyEntityToForm()
		{
			BLL.Core.DebugAttribute vDebugAttribute = DebugAttributeItem;
			ddlBaseAttributeID.DataValueField = "PrimaryIndex";
			ddlBaseAttributeID.DataTextField = "PrimaryName";
			if (UseWorkingSets == true && Session["Core/BaseAttributeWorkingSet"] != null)
			{
				BLL.SortableList<BLL.Core.BaseAttribute> sessionSource = (BLL.SortableList<BLL.Core.BaseAttribute>) Session["Core/BaseAttributeWorkingSet"];
				BLL.SortableList<BLL.Core.BaseAttribute> currentSource = new BLL.SortableList<BLL.Core.BaseAttribute>(sessionSource, true);
				if (MOD.Data.DataHelper.GetGuid(vDebugAttribute.BaseAttributeID, MOD.Data.DefaultValue.Guid) != MOD.Data.DefaultValue.Guid)
				{
					BLL.Core.BaseAttribute currentBaseAttribute = BLL.Core.BaseAttributeManager.GetOneBaseAttribute(MOD.Data.DataHelper.GetGuid(vDebugAttribute.BaseAttributeID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions("", "", true, true));
					if (currentBaseAttribute != null && currentSource.Contains(currentBaseAttribute) == false)
					{
						currentSource.Insert(0, currentBaseAttribute);
					}
				}
				ddlBaseAttributeID.DataSource = currentSource;
				lnkBaseAttributeIDWorkingSet.Visible = true;
				lnkBaseAttributeIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Core/SearchBaseAttributeData.aspx");
				lblBaseAttributeIDWorkingSet.Visible = true;
				lblBaseAttributeIDWorkingSet.Text = " (from Base Attribute working set)";
			}
			else
			{
				ddlBaseAttributeID.DataSource = BLL.Core.BaseAttributeManager.GetAllBaseAttributeData(Globals.DBOptions, Globals.getDataOptions("AttributeName", "", true, true), Globals.DebugLevel, Globals.CurrentUserID);
				lblBaseAttributeIDWorkingSet.Visible = false;
				if (UseWorkingSets == true)
				{
					lnkBaseAttributeIDWorkingSet.Visible = true;
					lnkBaseAttributeIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Core/SearchBaseAttributeData.aspx");
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
				BLL.Core.BaseAttribute sBaseAttribute = new BLL.Core.BaseAttribute();
				sBaseAttribute.BaseAttributeID = MOD.Data.DataHelper.GetGuid(vDebugAttribute.BaseAttributeID, MOD.Data.DefaultValue.Guid);
				ddlBaseAttributeID.SelectedValue = MOD.Data.DataHelper.GetString(sBaseAttribute.PrimaryIndex, "");
				sBaseAttribute = null;
			}
			catch {}
			if(ddlBaseAttributeID.SelectedValue == ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				try
				{
					ddlBaseAttributeID.SelectedValue = MOD.Data.DataHelper.GetString(Session["Core/BaseAttributeWorkingSetItem"], "");
				}
				catch {}
			}
			txtAttributeCode.Text = MOD.Data.EditHelper.GetInt(vDebugAttribute.AttributeCode);
			txtAttributeName.Text = MOD.Data.EditHelper.GetString(vDebugAttribute.AttributeName);
			ddlAttributeTypeCode.DataValueField = "PrimaryIndex";
			ddlAttributeTypeCode.DataTextField = "PrimaryName";
			ddlAttributeTypeCode.DataSource = BLL.Core.AttributeTypeManager.GetAllAttributeTypeData(Globals.DBOptions, Globals.getDataOptions("AttributeTypeName", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
			ddlAttributeTypeCode.DataBind();
			ddlAttributeTypeCode.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				BLL.Core.AttributeType sAttributeType = new BLL.Core.AttributeType();
				sAttributeType.AttributeTypeCode = MOD.Data.DataHelper.GetInt(vDebugAttribute.AttributeTypeCode, MOD.Data.DefaultValue.Int);
				ddlAttributeTypeCode.SelectedValue = MOD.Data.DataHelper.GetString(sAttributeType.PrimaryIndex, "");
				sAttributeType = null;
			}
			catch {}
			if(ddlAttributeTypeCode.SelectedValue == ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				try
				{
					ddlAttributeTypeCode.SelectedValue = MOD.Data.DataHelper.GetString(Session["Core/AttributeTypeWorkingSetItem"], "");
				}
				catch {}
			}
			ddlDataTypeCode.DataValueField = "PrimaryIndex";
			ddlDataTypeCode.DataTextField = "PrimaryName";
			ddlDataTypeCode.DataSource = BLL.Core.DataTypeManager.GetAllDataTypeData(Globals.DBOptions, Globals.getDataOptions("DataTypeName", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
			ddlDataTypeCode.DataBind();
			ddlDataTypeCode.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				BLL.Core.DataType sDataType = new BLL.Core.DataType();
				sDataType.DataTypeCode = MOD.Data.DataHelper.GetInt(vDebugAttribute.DataTypeCode, MOD.Data.DefaultValue.Int);
				ddlDataTypeCode.SelectedValue = MOD.Data.DataHelper.GetString(sDataType.PrimaryIndex, "");
				sDataType = null;
			}
			catch {}
			if(ddlDataTypeCode.SelectedValue == ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				try
				{
					ddlDataTypeCode.SelectedValue = MOD.Data.DataHelper.GetString(Session["Core/DataTypeWorkingSetItem"], "");
				}
				catch {}
			}
			txtDescription.Text = MOD.Data.EditHelper.GetString(vDebugAttribute.Description);
			chkIsActive.Checked = MOD.Data.DataHelper.GetBool(vDebugAttribute.IsActive, MOD.Data.DefaultValue.Bool);
			// Drop downs should be disabled when control is "Internal" and either value is constrained by container
			if (WorkflowMode == WorkflowMode.Internal)
			{
				ddlBaseAttributeID.Visible = Request.QueryString["BaseAttributeID"] == null;
				lnkBaseAttributeIDWorkingSet.Visible = lnkBaseAttributeIDWorkingSet.Visible == true && Request.QueryString["BaseAttributeID"] == null;
				lblBaseAttributeIDWorkingSet.Visible = lblBaseAttributeIDWorkingSet.Visible == true && Request.QueryString["BaseAttributeID"] == null;
				lblBaseAttributeIDDisplay.Visible = Request.QueryString["BaseAttributeID"] == null;
				ddlAttributeTypeCode.Visible = Request.QueryString["AttributeTypeCode"] == null;
				valAttributeTypeCode.Enabled = Request.QueryString["AttributeTypeCode"] == null;
				lblAttributeTypeCodeDisplay.Visible = Request.QueryString["AttributeTypeCode"] == null;
				ddlDataTypeCode.Visible = Request.QueryString["DataTypeCode"] == null;
				valDataTypeCode.Enabled = Request.QueryString["DataTypeCode"] == null;
				lblDataTypeCodeDisplay.Visible = Request.QueryString["DataTypeCode"] == null;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set Debug Attribute information from the form.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyFormToEntity()
		{
			BLL.Core.DebugAttribute vDebugAttribute = DebugAttributeItem;
			if (vDebugAttribute == null)
			{
				throw CoreUtility.CustomAppException.WrapException(new Exception("Debug Attribute not found"), "EditDebugAttribute.CopyFormToEntity()");
			}
			if (ddlBaseAttributeID.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Core.BaseAttribute sBaseAttribute = new BLL.Core.BaseAttribute(ddlBaseAttributeID.SelectedValue, false);
				vDebugAttribute.BaseAttributeID = MOD.Data.DataHelper.GetGuid(sBaseAttribute.BaseAttributeID, MOD.Data.DefaultValue.Guid);
				sBaseAttribute = null;
			}
			try
			{
				vDebugAttribute.AttributeCode = MOD.Data.DataHelper.GetInt(txtAttributeCode.Text, MOD.Data.DefaultValue.Int);
			}
			catch {}
			vDebugAttribute.AttributeName = EditHelper.EncodeStringForDB(MOD.Data.DataHelper.GetString(txtAttributeName.Text, null));
			if (ddlAttributeTypeCode.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Core.AttributeType sAttributeType = new BLL.Core.AttributeType(ddlAttributeTypeCode.SelectedValue, false);
				vDebugAttribute.AttributeTypeCode = MOD.Data.DataHelper.GetInt(sAttributeType.AttributeTypeCode, MOD.Data.DefaultValue.Int);
				sAttributeType = null;
			}
			if (ddlDataTypeCode.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Core.DataType sDataType = new BLL.Core.DataType(ddlDataTypeCode.SelectedValue, false);
				vDebugAttribute.DataTypeCode = MOD.Data.DataHelper.GetInt(sDataType.DataTypeCode, MOD.Data.DefaultValue.Int);
				sDataType = null;
			}
			vDebugAttribute.Description = EditHelper.EncodeStringForDB(MOD.Data.DataHelper.GetString(txtDescription.Text, null));
			vDebugAttribute.IsActive = chkIsActive.Checked;
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// Load entity from database, store in _entity and Session["DebugAttributeItem"]
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void LoadEntity()
		{
			_entity = null;
			Guid baseAttributeID = MOD.Data.DataHelper.GetGuid(Request.QueryString["BaseAttributeID"], MOD.Data.DefaultValue.Guid);
			if (baseAttributeID != MOD.Data.DefaultValue.Guid)
			{
				_entity = BLL.Core.DebugAttributeManager.GetOneDebugAttribute(baseAttributeID, Globals.getDataOptions("", "", true, true));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update Debug Attribute information in the database.</summary>
		///
		// ------------------------------------------------------------------------------
		private void UpsertToDatabase(bool performCascade)
		{
			BLL.Core.DebugAttribute vDebugAttribute = DebugAttributeItem;
			if (AccessMode == MOD.Data.AccessMode.Add)
			{
				BLL.Core.DebugAttributeManager.AddOneDebugAttribute(vDebugAttribute, performCascade);
			}
			else if (AccessMode == MOD.Data.AccessMode.Edit)
			{
				BLL.Core.DebugAttributeManager.UpdateOneDebugAttribute(vDebugAttribute, performCascade);
			}
			DebugAttributeItem.BaseAttributeID = vDebugAttribute.BaseAttributeID;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set access and display modes for presenting Debug Attribute information.</summary>
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
					lblTitle.Text = "Add Debug&nbsp;Attribute";
					btnSave.Text = "Add";
					break;
				case MOD.Data.AccessMode.Edit:
					lblTitle.Text = "Edit Debug&nbsp;Attribute";
					btnSave.Text = "Save";
					break;
				case MOD.Data.AccessMode.View:
					lblTitle.Text = "View Debug&nbsp;Attribute";
					break;
				default:
					lblTitle.Text = "View Debug&nbsp;Attribute";
					break;
			}
			btnDelete.Visible = IsDeleteAvailable;
			btnNew.Visible = IsEditAvailable;
			btnSave.Visible = IsEditAvailable || IsAddAvailable;
			ddlBaseAttributeID.Enabled = IsAddAvailable;
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
		/// <summary>Initialize component for DebugAttribute, add delegates here.</summary>
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