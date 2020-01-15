
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
	/// <summary>Edit Business Customer is used to help manage BusinessCustomer information.</summary>
	///
	/// File History:
	/// <created>6/1/2007 (Chris Grundy)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class EditBusinessCustomer  : Components.Desktop.BaseFormlUserControl
	{
		#region Events
		/// <summary>
		/// Raised when "Add" button is clicked in internal mode.
		/// Container handles this event and adds entity to collection.
		/// </summary>
		public event EntityEditEventHandler BusinessCustomerAdded;
		/// <summary>
		/// Raised when "Remove" button is clicked in internal mode.
		/// Container handles this event and removes entity from collection.
		/// </summary>
		public event EntityEditEventHandler BusinessCustomerRemoved;
		#endregion Events
		#region Declarations
		#endregion Declarations
		#region Properties
		/// <summary>
		/// The BusinessCustomer currently being edited by this control.
		/// Get accessor casts base._entity to BusinessCustomer
		/// Set accessor used by parent control to set the item currently being edited
		/// </summary>
		public BLL.Customers.BusinessCustomer BusinessCustomerItem
		{
			get
			{
				return (BLL.Customers.BusinessCustomer) _entity;
			}
			set
			{
				_entity = value; // only set by container
				Session["BusinessCustomerItem"] = _entity;
			}
		}
		#endregion Properties
		#region Event Handlers
		// ------------------------------------------------------------------------------
		/// <summary>Load page for editing Business Customer, getting mode and parameters.</summary>
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
						_entity = (BLL.Customers.BusinessCustomer)Session["BusinessCustomerItem"];
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
					Session["BusinessCustomerItem"] = _entity;
				}
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditBusinessCustomer.Page_Load"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Delete Business Customer.</summary>
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
					BLL.Customers.BusinessCustomerManager.DeleteOneBusinessCustomer(BusinessCustomerItem, performCascade);
					Globals.AddStatusMessage("Business Customer deleted.");
				}
				else
				{
					// raise event so item is removed from collection
					if (BusinessCustomerRemoved != null)
					{
						BusinessCustomerRemoved(this, new EntityEditEventArgs(_entity));
					}
				}
				// create new object and store it in _entity
				CreateNewEntity();
				Session["BusinessCustomerItem"] = _entity;
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditBusinessCustomer.btnDelete_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("BusinessMetaPartnerID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("CustomerMetaPartnerID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Request to create a new Business Customer.</summary>
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
				Session["BusinessCustomerItem"] = _entity;
				this.sectionLinks.OnSection("Basics");
				SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
				Globals.AddStatusMessage("Add new Business Customer.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				doRedirect = false;
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				doRedirect = false;
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditBusinessCustomer.btnNew_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("BusinessMetaPartnerID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("CustomerMetaPartnerID", MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, ""));
				queryString.Add("mode", MOD.Data.AccessMode.Add.ToString());
				queryString.Add("SaveMessages", "true");
				Response.Redirect(GetPageUrl(queryString, true, false));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Reset form for Business Customer.</summary>
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
					Session["BusinessCustomerItem"] = _entity;
					sectionLinks.CurrentSection = "Basics";
				}
				else
				{
					CreateNewEntity();
				}
				Globals.AddStatusMessage("Business Customer reset.");
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditBusinessCustomer.btnReset_Click"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Save Business Customer.</summary>
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
							if (BusinessCustomerAdded != null && (BusinessCustomerItem.BusinessMetaPartnerID != MOD.Data.DefaultValue.Guid || BusinessCustomerItem.CustomerMetaPartnerID != MOD.Data.DefaultValue.Guid || BusinessCustomerItem.CreatedByUserID != MOD.Data.DefaultValue.Guid || BusinessCustomerItem.CreatedDate != MOD.Data.DefaultValue.DateTime || BusinessCustomerItem.LastModifiedByUserID != MOD.Data.DefaultValue.Guid || BusinessCustomerItem.LastModifiedDate != MOD.Data.DefaultValue.DateTime || BusinessCustomerItem.Timestamp != null))
							{
								BusinessCustomerAdded(this, new EntityEditEventArgs(_entity));
								// create new object and store it in _entity
								CreateNewEntity();
								Session["BusinessCustomerItem"] = _entity;
								this.sectionLinks.OnSection("Basics");
								SetAccessModeAndDisplay(MOD.Data.AccessMode.Add);
							}
						}
						else
						{
							Globals.AddStatusMessage("Business Customer updated.");
						}
					}
					else
					{
						UpsertToDatabase(true);
						if (AccessMode == MOD.Data.AccessMode.Add)
						{
							doRedirect = true;
							Globals.AddStatusMessage("Business Customer added.");
						}
						else
						{
							Globals.AddStatusMessage("Business Customer updated.");
						}
						SetAccessModeAndDisplay(MOD.Data.AccessMode.Edit);
					}
				}
				else
				{
					Globals.AddErrorMessage(Page, "Business Customer validation failed.");
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditBusinessCustomer.btnSave_Click"));
			}
			finally
			{
			}
			if (doRedirect == true && isValid == true && WorkflowMode == MOD.Data.WorkflowMode.External)
			{
				NameValueCollection queryString = new NameValueCollection();
				queryString.Add("BusinessMetaPartnerID", BusinessCustomerItem.BusinessMetaPartnerID.ToString());
				queryString.Add("CustomerMetaPartnerID", BusinessCustomerItem.CustomerMetaPartnerID.ToString());
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditBusinessCustomer.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditBusinessCustomer.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditBusinessCustomer.btnBasics_Click"));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "EditBusinessCustomer.Page_PreRender"));
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
		/// Create a new Business Customer object reference
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void CreateNewEntity()
		{
			BLL.Customers.BusinessCustomer vBusinessCustomer = new BLL.Customers.BusinessCustomer();
			vBusinessCustomer.BusinessMetaPartnerID = MOD.Data.DataHelper.GetGuid(Request.QueryString["BusinessMetaPartnerID"], MOD.Data.DefaultValue.Guid);
			vBusinessCustomer.CustomerMetaPartnerID = MOD.Data.DataHelper.GetGuid(Request.QueryString["CustomerMetaPartnerID"], MOD.Data.DefaultValue.Guid);
			_entity = vBusinessCustomer;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update form from Business Customer information.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyEntityToForm()
		{
			BLL.Customers.BusinessCustomer vBusinessCustomer = BusinessCustomerItem;
			ddlBusinessMetaPartnerID.DataValueField = "PrimaryIndex";
			ddlBusinessMetaPartnerID.DataTextField = "PrimaryName";
			if (UseWorkingSets == true && Session["Customers/BusinessWorkingSet"] != null)
			{
				BLL.SortableList<BLL.Customers.Business> sessionSource = (BLL.SortableList<BLL.Customers.Business>) Session["Customers/BusinessWorkingSet"];
				BLL.SortableList<BLL.Customers.Business> currentSource = new BLL.SortableList<BLL.Customers.Business>(sessionSource, true);
				if (MOD.Data.DataHelper.GetGuid(vBusinessCustomer.BusinessMetaPartnerID, MOD.Data.DefaultValue.Guid) != MOD.Data.DefaultValue.Guid)
				{
					BLL.Customers.Business currentBusiness = BLL.Customers.BusinessManager.GetOneBusiness(MOD.Data.DataHelper.GetGuid(vBusinessCustomer.BusinessMetaPartnerID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions("", "", true, true));
					if (currentBusiness != null && currentSource.Contains(currentBusiness) == false)
					{
						currentSource.Insert(0, currentBusiness);
					}
				}
				ddlBusinessMetaPartnerID.DataSource = currentSource;
				lnkBusinessMetaPartnerIDWorkingSet.Visible = true;
				lnkBusinessMetaPartnerIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Customers/SearchBusinessData.aspx");
				lblBusinessMetaPartnerIDWorkingSet.Visible = true;
				lblBusinessMetaPartnerIDWorkingSet.Text = " (from Business working set)";
			}
			else
			{
				ddlBusinessMetaPartnerID.DataSource = BLL.Customers.BusinessManager.GetAllBusinessData(Globals.DBOptions, Globals.getDataOptions("MetaPartnerName", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
				lblBusinessMetaPartnerIDWorkingSet.Visible = false;
				if (UseWorkingSets == true)
				{
					lnkBusinessMetaPartnerIDWorkingSet.Visible = true;
					lnkBusinessMetaPartnerIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Customers/SearchBusinessData.aspx");
				}
				else
				{
					lnkBusinessMetaPartnerIDWorkingSet.Visible = false;
				}
			}
			ddlBusinessMetaPartnerID.DataBind();
			ddlBusinessMetaPartnerID.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				BLL.Customers.Business sBusiness = new BLL.Customers.Business();
				sBusiness.MetaPartnerID = MOD.Data.DataHelper.GetGuid(vBusinessCustomer.BusinessMetaPartnerID, MOD.Data.DefaultValue.Guid);
				ddlBusinessMetaPartnerID.SelectedValue = MOD.Data.DataHelper.GetString(sBusiness.PrimaryIndex, "");
				sBusiness = null;
			}
			catch {}
			if(ddlBusinessMetaPartnerID.SelectedValue == ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				try
				{
					ddlBusinessMetaPartnerID.SelectedValue = MOD.Data.DataHelper.GetString(Session["Customers/BusinessWorkingSetItem"], "");
				}
				catch {}
			}
			ddlCustomerMetaPartnerID.DataValueField = "PrimaryIndex";
			ddlCustomerMetaPartnerID.DataTextField = "PrimaryName";
			if (UseWorkingSets == true && Session["Customers/CustomerWorkingSet"] != null)
			{
				BLL.SortableList<BLL.Customers.Customer> sessionSource = (BLL.SortableList<BLL.Customers.Customer>) Session["Customers/CustomerWorkingSet"];
				BLL.SortableList<BLL.Customers.Customer> currentSource = new BLL.SortableList<BLL.Customers.Customer>(sessionSource, true);
				if (MOD.Data.DataHelper.GetGuid(vBusinessCustomer.CustomerMetaPartnerID, MOD.Data.DefaultValue.Guid) != MOD.Data.DefaultValue.Guid)
				{
					BLL.Customers.Customer currentCustomer = BLL.Customers.CustomerManager.GetOneCustomer(MOD.Data.DataHelper.GetGuid(vBusinessCustomer.CustomerMetaPartnerID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions("", "", true, true));
					if (currentCustomer != null && currentSource.Contains(currentCustomer) == false)
					{
						currentSource.Insert(0, currentCustomer);
					}
				}
				ddlCustomerMetaPartnerID.DataSource = currentSource;
				lnkCustomerMetaPartnerIDWorkingSet.Visible = true;
				lnkCustomerMetaPartnerIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Customers/SearchCustomerData.aspx");
				lblCustomerMetaPartnerIDWorkingSet.Visible = true;
				lblCustomerMetaPartnerIDWorkingSet.Text = " (from Customer working set)";
			}
			else
			{
				ddlCustomerMetaPartnerID.DataSource = BLL.Customers.CustomerManager.GetAllCustomerData(Globals.DBOptions, Globals.getDataOptions("MetaPartnerName", "", false, false), Globals.DebugLevel, Globals.CurrentUserID);
				lblCustomerMetaPartnerIDWorkingSet.Visible = false;
				if (UseWorkingSets == true)
				{
					lnkCustomerMetaPartnerIDWorkingSet.Visible = true;
					lnkCustomerMetaPartnerIDWorkingSet.HRef = Page.ResolveUrl("~/Pages/Desktop/Customers/SearchCustomerData.aspx");
				}
				else
				{
					lnkCustomerMetaPartnerIDWorkingSet.Visible = false;
				}
			}
			ddlCustomerMetaPartnerID.DataBind();
			ddlCustomerMetaPartnerID.Items.Insert(0, new ListItem(" -- none -- ",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
			try
			{
				BLL.Customers.Customer sCustomer = new BLL.Customers.Customer();
				sCustomer.MetaPartnerID = MOD.Data.DataHelper.GetGuid(vBusinessCustomer.CustomerMetaPartnerID, MOD.Data.DefaultValue.Guid);
				ddlCustomerMetaPartnerID.SelectedValue = MOD.Data.DataHelper.GetString(sCustomer.PrimaryIndex, "");
				sCustomer = null;
			}
			catch {}
			if(ddlCustomerMetaPartnerID.SelectedValue == ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				try
				{
					ddlCustomerMetaPartnerID.SelectedValue = MOD.Data.DataHelper.GetString(Session["Customers/CustomerWorkingSetItem"], "");
				}
				catch {}
			}
			// Drop downs should be disabled when control is "Internal" and either value is constrained by container
			if (WorkflowMode == WorkflowMode.Internal)
			{
				ddlBusinessMetaPartnerID.Visible = Request.QueryString["BusinessMetaPartnerID"] == null;
				lnkBusinessMetaPartnerIDWorkingSet.Visible = lnkBusinessMetaPartnerIDWorkingSet.Visible == true && Request.QueryString["BusinessMetaPartnerID"] == null;
				lblBusinessMetaPartnerIDWorkingSet.Visible = lblBusinessMetaPartnerIDWorkingSet.Visible == true && Request.QueryString["BusinessMetaPartnerID"] == null;
				valBusinessMetaPartnerID.Enabled = Request.QueryString["BusinessMetaPartnerID"] == null;
				lblBusinessMetaPartnerIDDisplay.Visible = Request.QueryString["BusinessMetaPartnerID"] == null;
				ddlCustomerMetaPartnerID.Visible = Request.QueryString["CustomerMetaPartnerID"] == null;
				lnkCustomerMetaPartnerIDWorkingSet.Visible = lnkCustomerMetaPartnerIDWorkingSet.Visible == true && Request.QueryString["CustomerMetaPartnerID"] == null;
				lblCustomerMetaPartnerIDWorkingSet.Visible = lblCustomerMetaPartnerIDWorkingSet.Visible == true && Request.QueryString["CustomerMetaPartnerID"] == null;
				valCustomerMetaPartnerID.Enabled = Request.QueryString["CustomerMetaPartnerID"] == null;
				lblCustomerMetaPartnerIDDisplay.Visible = Request.QueryString["CustomerMetaPartnerID"] == null;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set Business Customer information from the form.</summary>
		///
		// ------------------------------------------------------------------------------
		private void CopyFormToEntity()
		{
			BLL.Customers.BusinessCustomer vBusinessCustomer = BusinessCustomerItem;
			if (vBusinessCustomer == null)
			{
				throw CoreUtility.CustomAppException.WrapException(new Exception("Business Customer not found"), "EditBusinessCustomer.CopyFormToEntity()");
			}
			if (ddlBusinessMetaPartnerID.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Customers.Business sBusiness = new BLL.Customers.Business(ddlBusinessMetaPartnerID.SelectedValue, false);
				vBusinessCustomer.BusinessMetaPartnerID = MOD.Data.DataHelper.GetGuid(sBusiness.MetaPartnerID, MOD.Data.DefaultValue.Guid);
				sBusiness = null;
			}
			if (ddlCustomerMetaPartnerID.SelectedValue != ((int)MOD.Data.Lists.ListDefaultSelection.None).ToString())
			{
				BLL.Customers.Customer sCustomer = new BLL.Customers.Customer(ddlCustomerMetaPartnerID.SelectedValue, false);
				vBusinessCustomer.CustomerMetaPartnerID = MOD.Data.DataHelper.GetGuid(sCustomer.MetaPartnerID, MOD.Data.DefaultValue.Guid);
				sCustomer = null;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>
		/// Load entity from database, store in _entity and Session["BusinessCustomerItem"]
		/// </summary>
		/// <returns></returns>
		// ------------------------------------------------------------------------------
		protected void LoadEntity()
		{
			_entity = null;
			Guid businessMetaPartnerID = MOD.Data.DataHelper.GetGuid(Request.QueryString["BusinessMetaPartnerID"], MOD.Data.DefaultValue.Guid);
			Guid customerMetaPartnerID = MOD.Data.DataHelper.GetGuid(Request.QueryString["CustomerMetaPartnerID"], MOD.Data.DefaultValue.Guid);
			if (businessMetaPartnerID != MOD.Data.DefaultValue.Guid && customerMetaPartnerID != MOD.Data.DefaultValue.Guid)
			{
				_entity = BLL.Customers.BusinessCustomerManager.GetOneBusinessCustomer(businessMetaPartnerID, customerMetaPartnerID, Globals.getDataOptions("", "", true, true));
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Update Business Customer information in the database.</summary>
		///
		// ------------------------------------------------------------------------------
		private void UpsertToDatabase(bool performCascade)
		{
			BLL.Customers.BusinessCustomer vBusinessCustomer = BusinessCustomerItem;
			if (AccessMode == MOD.Data.AccessMode.Add)
			{
				BLL.Customers.BusinessCustomerManager.AddOneBusinessCustomer(vBusinessCustomer, performCascade);
			}
			else if (AccessMode == MOD.Data.AccessMode.Edit)
			{
				BLL.Customers.BusinessCustomerManager.UpdateOneBusinessCustomer(vBusinessCustomer, performCascade);
			}
			BusinessCustomerItem.BusinessMetaPartnerID = vBusinessCustomer.BusinessMetaPartnerID;
			BusinessCustomerItem.CustomerMetaPartnerID = vBusinessCustomer.CustomerMetaPartnerID;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set access and display modes for presenting Business Customer information.</summary>
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
					lblTitle.Text = "Add Business&nbsp;Customer";
					btnSave.Text = "Add";
					break;
				case MOD.Data.AccessMode.Edit:
					lblTitle.Text = "Edit Business&nbsp;Customer";
					btnSave.Text = "Save";
					break;
				case MOD.Data.AccessMode.View:
					lblTitle.Text = "View Business&nbsp;Customer";
					break;
				default:
					lblTitle.Text = "View Business&nbsp;Customer";
					break;
			}
			btnDelete.Visible = IsDeleteAvailable;
			btnNew.Visible = IsEditAvailable;
			btnSave.Visible = IsEditAvailable || IsAddAvailable;
			ddlBusinessMetaPartnerID.Enabled = IsAddAvailable;
			ddlCustomerMetaPartnerID.Enabled = IsAddAvailable;
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
		/// <summary>Initialize component for BusinessCustomer, add delegates here.</summary>
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