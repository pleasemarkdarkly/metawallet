
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
using MW.MComm.WalletSolution.BLL.Customers;
using CoreUtility = MW.MComm.WalletSolution.Utility;
using MW.MComm.Admin.WebUI.Components.Desktop;
namespace MW.MComm.Admin.WebUI.UserControls.Desktop.Customers
{
	// ------------------------------------------------------------------------------
	/// <summary>Edit Meta Partner Contact is used to help manage MetaPartnerContact information.</summary>
	///
	/// File History:
	/// <created>6/1/2007 (Chris Grundy)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class EditMetaPartnerContact  : Components.Desktop.BaseFormlUserControl
	{
		#region Events
		/// <summary>
		/// Raised when "Add" button is clicked in internal mode.
		/// Container handles this event and adds entity to collection.
		/// </summary>
		public event EntityEditEventHandler MetaPartnerContactAdded;
		/// <summary>
		/// Raised when "Remove" button is clicked in internal mode.
		/// Container handles this event and removes entity from collection.
		/// </summary>
		public event EntityEditEventHandler MetaPartnerContactRemoved;
		#endregion Events
		#region Declarations
		#endregion Declarations
		#region Properties
		/// <summary>
		/// The MetaPartnerContact currently being edited by this control.
		/// Get accessor casts base._entity to MetaPartnerContact
		/// Set accessor used by parent control to set the item currently being edited
		/// </summary>
		public BLL.Customers.MetaPartnerContact MetaPartnerContactItem
		{
			get
			{
				return (BLL.Customers.MetaPartnerContact) _entity;
			}
			set
			{
				_entity = value; // only set by container
				Session["MetaPartnerContactItem"] = _entity;
			}
		}
		#endregion Properties
		#region Event Handlers
		// ------------------------------------------------------------------------------
		/// <summary>Load page for editing Meta Partner Contact, getting mode and parameters.</summary>
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
						_entity = (BLL.Customers.MetaPartnerContact)Session["MetaPartnerContactItem"];
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
					Session["MetaPartnerContactItem"] = _entity;
				}
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditMetaPartnerContact.Page_Load"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Delete Meta Partner Contact.</summary>
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
					BLL.Customers.MetaPartnerContactManager.DeleteOneMetaPartnerContact(MetaPartnerContactItem, performCascade);
					Globals.AddStatusMessage("Meta Partner Contact deleted.");
				}
				else
				{
					// raise event so item is removed from collection
					if (MetaPartnerContactRemoved != null)
					{
						MetaPartnerContactRemoved(this, new EntityEditEventArgs(_entity));
					}
				}
				// create new object and store it in _entity
				CreateNewEntity();
				Session["MetaPartnerContactItem"] = _entity;
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditMetaPartnerContact.btnDelete_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("MetaPartnerID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("ContactMetaPartnerID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Request to create a new Meta Partner Contact.</summary>
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
				Session["MetaPartnerContactItem"] = _entity;
				this.sectionLinks.OnSection("Basics");
				SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
				Globals.AddStatusMessage("Add new Meta Partner Contact.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				doRedirect = false;
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				doRedirect = false;
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditMetaPartnerContact.btnNew_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("MetaPartnerID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("ContactMetaPartnerID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Reset form for Meta Partner Contact.</summary>
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
					Session["MetaPartnerContactItem"] = _entity;
					sectionLinks.CurrentSection = "Basics";
				}
				else
				{
					CreateNewEntity();
				}
				Globals.AddStatusMessage("Meta Partner Contact reset.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditMetaPartnerContact.btnReset_Click"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Save Meta Partner Contact.</summary>
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
							if (MetaPartnerContactAdded != null && (MetaPartnerContactItem.MetaPartnerID != MOD.Data.DefaultValue.Guid || MetaPartnerContactItem.ContactMetaPartnerID != MOD.Data.DefaultValue.Guid || MetaPartnerContactItem.CreatedByUserID != MOD.Data.DefaultValue.Guid || MetaPartnerContactItem.CreatedDate != MOD.Data.DefaultValue.DateTime || MetaPartnerContactItem.LastModifiedByUserID != MOD.Data.DefaultValue.Guid || MetaPartnerContactItem.LastModifiedDate != MOD.Data.DefaultValue.DateTime || MetaPartnerContactItem.Timestamp != null))
							{
								MetaPartnerContactAdded(this, new EntityEditEventArgs(_entity));
								// create new object and store it in _entity
								CreateNewEntity();
								Session["MetaPartnerContactItem"] = _entity;
								this.sectionLinks.OnSection("Basics");
								SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
							}
						}
						else
						{
							Globals.AddStatusMessage("Meta Partner Contact updated.");
						}
					}
					else
					{
						UpsertToDatabase(true);
						if (AccessMode == MOD.Data.AccessMode.Add)
						{
							doRedirect = true;
							Globals.AddStatusMessage("Meta Partner Contact added.");
						}
						else
						{
							Globals.AddStatusMessage("Meta Partner Contact updated.");
						}
						SetAccessModeAndDisplay(MOD.Data.AccessMode.Edit);
					}
				}
				else
				{
					Globals.AddErrorMessage(Page, "Meta Partner Contact validation failed.");
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditMetaPartnerContact.btnSave_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && isValid == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("MetaPartnerID", MetaPartnerContactItem.MetaPartnerID.ToString());
				queryString.Add("ContactMetaPartnerID", MetaPartnerContactItem.ContactMetaPartnerID.ToString());
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditMetaPartnerContact.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditMetaPartnerContact.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditMetaPartnerContact.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditMetaPartnerContact.Page_PreRender"));
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
		/// Create a new Meta Partner Contact object reference
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void CreateNewEntity()
		{
			BLL.Customers.MetaPartnerContact vMetaPartnerContact = new BLL.Customers.MetaPartnerContact();
			vMetaPartnerContact.MetaPartnerID = MOD.Data.DataHelper.GetGuid(Request.QueryString["MetaPartnerID"], MOD.Data.DefaultValue.Guid);
			vMetaPartnerContact.ContactMetaPartnerID = MOD.Data.DataHelper.GetGuid(Request.QueryString["ContactMetaPartnerID"], MOD.Data.DefaultValue.Guid);
			_entity = vMetaPartnerContact;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update form from Meta Partner Contact information.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyEntityToForm()
		{
			BLL.Customers.MetaPartnerContact vMetaPartnerContact = MetaPartnerContactItem;
			ddlMetaPartnerID.DataValueField = "PrimaryIndex";
			ddlMetaPartnerID.DataTextField = "PrimaryName";
			if (UseWorkingSets == true && Session["Customers/MetaPartnerWorkingSet"] != null)
			{
				BLL.SortableList<BLL.Customers.MetaPartner> sessionSource = (BLL.SortableList<BLL.Customers.MetaPartner>) Session["Customers/MetaPartnerWorkingSet"];
				BLL.SortableList<BLL.Customers.MetaPartner> currentSource = new BLL.SortableList<BLL.Customers.MetaPartner>(sessionSource, true);
				if (MOD.Data.DataHelper.GetGuid(vMetaPartnerContact.MetaPartnerID, MOD.Data.DefaultValue.Guid) != MOD.Data.DefaultValue.Guid)
				{
					BLL.Customers.MetaPartner currentMetaPartner = BLL.Customers.MetaPartnerManager.GetOneMetaPartner(MOD.Data.DataHelper.GetGuid(vMetaPartnerContact.MetaPartnerID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions("", "", true, true));
					if (currentMetaPartner != null && currentSource.Contains(currentMetaPartner) == false)
					{
						currentSource.Insert(0, currentMetaPartner);
					}
				}
				ddlMetaPartnerID.DataSource = currentSource;
				lnkMetaPartnerIDWorkingSet.Visible = true;
				lnkMetaPartnerIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Customers/SearchMetaPartnerData.aspx");
				lblMetaPartnerIDWorkingSet.Visible = true;
				lblMetaPartnerIDWorkingSet.Text = " (from Meta Partner working set)";
			}
			else
			{
				ddlMetaPartnerID.DataSource = BLL.Customers.MetaPartnerManager.GetAllMetaPartnerData(Globals.DBOptions, Globals.getDataOptions("MetaPartnerName", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
				lblMetaPartnerIDWorkingSet.Visible = false;
				if (UseWorkingSets == true)
				{
					lnkMetaPartnerIDWorkingSet.Visible = true;
					lnkMetaPartnerIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Customers/SearchMetaPartnerData.aspx");
				}
				else
				{
					lnkMetaPartnerIDWorkingSet.Visible = false;
				}
			}
			ddlMetaPartnerID.DataBind();
			ddlMetaPartnerID.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				BLL.Customers.MetaPartner sMetaPartner = new BLL.Customers.MetaPartner();
				sMetaPartner.MetaPartnerID = MOD.Data.DataHelper.GetGuid(vMetaPartnerContact.MetaPartnerID, MOD.Data.DefaultValue.Guid);
				ddlMetaPartnerID.SelectedValue = MOD.Data.DataHelper.GetString(sMetaPartner.PrimaryIndex, "");
				sMetaPartner = null;
			}
			catch {}
			if(ddlMetaPartnerID.SelectedValue == ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				try
				{
					ddlMetaPartnerID.SelectedValue = MOD.Data.DataHelper.GetString(Session["Customers/MetaPartnerWorkingSetItem"], "");
				}
				catch {}
			}
			ddlContactMetaPartnerID.DataValueField = "PrimaryIndex";
			ddlContactMetaPartnerID.DataTextField = "PrimaryName";
			if (UseWorkingSets == true && Session["Customers/MetaPartnerWorkingSet"] != null)
			{
				BLL.SortableList<BLL.Customers.MetaPartner> sessionSource = (BLL.SortableList<BLL.Customers.MetaPartner>) Session["Customers/MetaPartnerWorkingSet"];
				BLL.SortableList<BLL.Customers.MetaPartner> currentSource = new BLL.SortableList<BLL.Customers.MetaPartner>(sessionSource, true);
				if (MOD.Data.DataHelper.GetGuid(vMetaPartnerContact.ContactMetaPartnerID, MOD.Data.DefaultValue.Guid) != MOD.Data.DefaultValue.Guid)
				{
					BLL.Customers.MetaPartner currentMetaPartner = BLL.Customers.MetaPartnerManager.GetOneMetaPartner(MOD.Data.DataHelper.GetGuid(vMetaPartnerContact.ContactMetaPartnerID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions("", "", true, true));
					if (currentMetaPartner != null && currentSource.Contains(currentMetaPartner) == false)
					{
						currentSource.Insert(0, currentMetaPartner);
					}
				}
				ddlContactMetaPartnerID.DataSource = currentSource;
				lnkContactMetaPartnerIDWorkingSet.Visible = true;
				lnkContactMetaPartnerIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Customers/SearchMetaPartnerData.aspx");
				lblContactMetaPartnerIDWorkingSet.Visible = true;
				lblContactMetaPartnerIDWorkingSet.Text = " (from Meta Partner working set)";
			}
			else
			{
				ddlContactMetaPartnerID.DataSource = BLL.Customers.MetaPartnerManager.GetAllMetaPartnerData(Globals.DBOptions, Globals.getDataOptions("MetaPartnerName", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
				lblContactMetaPartnerIDWorkingSet.Visible = false;
				if (UseWorkingSets == true)
				{
					lnkContactMetaPartnerIDWorkingSet.Visible = true;
					lnkContactMetaPartnerIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Customers/SearchMetaPartnerData.aspx");
				}
				else
				{
					lnkContactMetaPartnerIDWorkingSet.Visible = false;
				}
			}
			ddlContactMetaPartnerID.DataBind();
			ddlContactMetaPartnerID.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				BLL.Customers.MetaPartner sMetaPartner = new BLL.Customers.MetaPartner();
				sMetaPartner.MetaPartnerID = MOD.Data.DataHelper.GetGuid(vMetaPartnerContact.ContactMetaPartnerID, MOD.Data.DefaultValue.Guid);
				ddlContactMetaPartnerID.SelectedValue = MOD.Data.DataHelper.GetString(sMetaPartner.PrimaryIndex, "");
				sMetaPartner = null;
			}
			catch {}
			if(ddlContactMetaPartnerID.SelectedValue == ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				try
				{
					ddlContactMetaPartnerID.SelectedValue = MOD.Data.DataHelper.GetString(Session["Customers/MetaPartnerWorkingSetItem"], "");
				}
				catch {}
			}
			// Drop downs should be disabled when control is "Internal" and either value is constrained by container
			if (WorkflowMode == WorkflowMode.Internal)
			{
				ddlMetaPartnerID.Visible = Request.QueryString["MetaPartnerID"] == null;
				lnkMetaPartnerIDWorkingSet.Visible = lnkMetaPartnerIDWorkingSet.Visible == true && Request.QueryString["MetaPartnerID"] == null;
				lblMetaPartnerIDWorkingSet.Visible = lblMetaPartnerIDWorkingSet.Visible == true && Request.QueryString["MetaPartnerID"] == null;
				valMetaPartnerID.Enabled = Request.QueryString["MetaPartnerID"] == null;
				lblMetaPartnerIDDisplay.Visible = Request.QueryString["MetaPartnerID"] == null;
				ddlContactMetaPartnerID.Visible = Request.QueryString["ContactMetaPartnerID"] == null;
				lnkContactMetaPartnerIDWorkingSet.Visible = lnkContactMetaPartnerIDWorkingSet.Visible == true && Request.QueryString["ContactMetaPartnerID"] == null;
				lblContactMetaPartnerIDWorkingSet.Visible = lblContactMetaPartnerIDWorkingSet.Visible == true && Request.QueryString["ContactMetaPartnerID"] == null;
				valContactMetaPartnerID.Enabled = Request.QueryString["ContactMetaPartnerID"] == null;
				lblContactMetaPartnerIDDisplay.Visible = Request.QueryString["ContactMetaPartnerID"] == null;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set Meta Partner Contact information from the form.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyFormToEntity()
		{
			BLL.Customers.MetaPartnerContact vMetaPartnerContact = MetaPartnerContactItem;
			if (vMetaPartnerContact == null)
			{
				throw CoreUtility.CustomAppException.WrapException(new Exception("Meta Partner Contact not found"), "EditMetaPartnerContact.CopyFormToEntity()");
			}
			if (ddlMetaPartnerID.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Customers.MetaPartner sMetaPartner = new BLL.Customers.MetaPartner(ddlMetaPartnerID.SelectedValue, false);
				vMetaPartnerContact.MetaPartnerID = MOD.Data.DataHelper.GetGuid(sMetaPartner.MetaPartnerID, MOD.Data.DefaultValue.Guid);
				sMetaPartner = null;
				vMetaPartnerContact.PrimaryName += MOD.Data.DataHelper.GetString(ddlMetaPartnerID.SelectedItem.Text, MOD.Data.DefaultValue.String) + ";";
			}
			if (ddlContactMetaPartnerID.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Customers.MetaPartner sMetaPartner = new BLL.Customers.MetaPartner(ddlContactMetaPartnerID.SelectedValue, false);
				vMetaPartnerContact.ContactMetaPartnerID = MOD.Data.DataHelper.GetGuid(sMetaPartner.MetaPartnerID, MOD.Data.DefaultValue.Guid);
				sMetaPartner = null;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// Load entity from database, store in _entity and Session["MetaPartnerContactItem"]
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void LoadEntity()
		{
			_entity = null;
			Guid metaPartnerID = MOD.Data.DataHelper.GetGuid(Request.QueryString["MetaPartnerID"], MOD.Data.DefaultValue.Guid);
			Guid contactMetaPartnerID = MOD.Data.DataHelper.GetGuid(Request.QueryString["ContactMetaPartnerID"], MOD.Data.DefaultValue.Guid);
			if (metaPartnerID != MOD.Data.DefaultValue.Guid && contactMetaPartnerID != MOD.Data.DefaultValue.Guid)
			{
				_entity = BLL.Customers.MetaPartnerContactManager.GetOneMetaPartnerContact(metaPartnerID, contactMetaPartnerID, Globals.getDataOptions("", "", true, true));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update Meta Partner Contact information in the database.</summary>
		///
		// ------------------------------------------------------------------------------
		private void UpsertToDatabase(bool performCascade)
		{
			BLL.Customers.MetaPartnerContact vMetaPartnerContact = MetaPartnerContactItem;
			if (AccessMode == MOD.Data.AccessMode.Add)
			{
				BLL.Customers.MetaPartnerContactManager.AddOneMetaPartnerContact(vMetaPartnerContact, performCascade);
			}
			else if (AccessMode == MOD.Data.AccessMode.Edit)
			{
				BLL.Customers.MetaPartnerContactManager.UpdateOneMetaPartnerContact(vMetaPartnerContact, performCascade);
			}
			MetaPartnerContactItem.MetaPartnerID = vMetaPartnerContact.MetaPartnerID;
			MetaPartnerContactItem.ContactMetaPartnerID = vMetaPartnerContact.ContactMetaPartnerID;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set access and display modes for presenting Meta Partner Contact information.</summary>
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
					lblTitle.Text = "Add Meta&nbsp;Partner&nbsp;Contact";
					btnSave.Text = "Add";
					break;
				case MOD.Data.AccessMode.Edit:
					lblTitle.Text = "Edit Meta&nbsp;Partner&nbsp;Contact";
					btnSave.Text = "Save";
					break;
				case MOD.Data.AccessMode.View:
					lblTitle.Text = "View Meta&nbsp;Partner&nbsp;Contact";
					break;
				default:
					lblTitle.Text = "View Meta&nbsp;Partner&nbsp;Contact";
					break;
			}
			btnDelete.Visible = IsDeleteAvailable;
			btnNew.Visible = IsEditAvailable;
			btnSave.Visible = IsEditAvailable || IsAddAvailable;
			ddlMetaPartnerID.Enabled = IsAddAvailable;
			ddlContactMetaPartnerID.Enabled = IsAddAvailable;
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
		/// <summary>Initialize component for MetaPartnerContact, add delegates here.</summary>
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