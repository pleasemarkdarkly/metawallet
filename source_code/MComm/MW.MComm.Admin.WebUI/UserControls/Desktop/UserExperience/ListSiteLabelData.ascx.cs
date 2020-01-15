
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
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using MOD.Data;
using BLL = MW.MComm.WalletSolution.BLL;
using MW.MComm.WalletSolution.BLL.UserExperience;
using CoreUtility = MW.MComm.WalletSolution.Utility;
using MW.MComm.Admin.WebUI.Components.Desktop;
namespace MW.MComm.Admin.WebUI.UserControls.Desktop.UserExperience
{
	// ------------------------------------------------------------------------------
	/// <summary>List Site Label Data is used to help manage SiteLabel information.</summary>
	///
	/// File History:
	/// <created>6/1/2007 (Chris Grundy)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class ListSiteLabelData  : Components.Desktop.BaseListUserControl
	{
		#region Fields
		#endregion Fields
		#region Properties
		public string ListTitle
		{
			get { return lblTitle.Text; }
			set { lblTitle.Text = value; }
		}
		public bool UseValidation
		{
			get
			{
				return base.UseValidation;
			}
			set
			{
				base.UseValidation = value;
				editSiteLabel.UseValidation = value;
			}
		}
		public DataGrid DataGrid { get { return dgPrimaryList; } }
		#endregion Properties
		#region Event Handlers
		// ------------------------------------------------------------------------------
		/// <summary>Load page for Site Label listing.</summary>
		///
		// ------------------------------------------------------------------------------
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				base.OnLoad(); // base list control manages loading data
				// Set current item into child control
				if (_selectedIndex > -1)
				{
					this.editSiteLabel.SiteLabelItem = (BLL.UserExperience.SiteLabel) Collection[_selectedIndex];
				}
				this.editSiteLabel.SiteLabelAdded += new EntityEditEventHandler(editSiteLabel_SiteLabelAdded);
				this.editSiteLabel.SiteLabelRemoved += new EntityEditEventHandler(editSiteLabel_SiteLabelRemoved);
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "ListSiteLabelData.Page_Load"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Item added event handler for Site Label.</summary>
		///
		// ------------------------------------------------------------------------------
		private void editSiteLabel_SiteLabelAdded(BaseFormlUserControl sender, EntityEditEventArgs e)
		{
			Globals.ClearMessages();
			if (_collection.Contains(e.Entity))
			{
				Globals.AddErrorMessage(Page, "Collection already contains this Site Label");
			}
			else
			{
				_collection.Add(e.Entity);
				Globals.AddStatusMessage("Site Label added.");
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Item removed event handler for Site Label.</summary>
		///
		// ------------------------------------------------------------------------------
		private void editSiteLabel_SiteLabelRemoved(BaseFormlUserControl sender, EntityEditEventArgs e)
		{
			Globals.ClearMessages();
			_collection.Remove(e.Entity);
			Globals.AddStatusMessage("Site Label removed.");
		}
		// ------------------------------------------------------------------------------
		/// <summary>Binding for a list of Site Label.</summary>
		///
		// ------------------------------------------------------------------------------
		private void dgPrimaryList_ItemDataBound(object sender, DataGridItemEventArgs e)
		{
			try
			{
				if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.SelectedItem)
				{
					BLL.UserExperience.SiteLabel vSiteLabel = (BLL.UserExperience.SiteLabel)e.Item.DataItem;
					SetControlText(e.Item,"lblPrimaryName", MOD.Data.DataHelper.GetString(vSiteLabel.PrimaryName, ""));
					SetControlText(e.Item,"lblLocaleCode", MOD.Data.DataHelper.GetString(vSiteLabel.LocaleCode, ""));
					SetControlText(e.Item,"lblTitle", MOD.Data.DataHelper.GetString(vSiteLabel.Title, ""));
					SetControlText(e.Item,"lblDisplayText", MOD.Data.DataHelper.GetString(vSiteLabel.DisplayText, ""));
					SetControlText(e.Item,"lblTargetLocation", MOD.Data.DataHelper.GetString(vSiteLabel.TargetLocation, ""));
					HyperLink lnkFileURL = (HyperLink)e.Item.FindControl("lnkFileURL");
					lnkFileURL.NavigateUrl = Page.ResolveUrl(CoreUtility.FileManager.GetAbsoluteHttpUrl(CoreUtility.FileGroupCode.UserExperience, vSiteLabel.FileURL, Page.ResolveUrl("~/images/missing_image-75.jpg")));
					SetControlText(e.Item,"lblDescription", MOD.Data.DataHelper.GetString(vSiteLabel.Description, ""));
					SetControlText(e.Item,"lblSiteLabelDefinitionCode", MOD.Data.DataHelper.GetString(vSiteLabel.SiteLabelDefinitionCode, ""));
					SetControlText(e.Item,"lblCreatedDate", MOD.Data.DataHelper.GetString(vSiteLabel.CreatedDate, ""));
					SetControlText(e.Item,"lblLastModifiedDate", MOD.Data.DataHelper.GetString(vSiteLabel.LastModifiedDate, ""));
					SetControlText(e.Item,"lblSiteLabelDefinitionName", MOD.Data.DataHelper.GetString(vSiteLabel.SiteLabelDefinitionName, MOD.Data.DefaultValue.String));
					SetControlText(e.Item,"lblLocaleName", MOD.Data.DataHelper.GetString(vSiteLabel.LocaleName, MOD.Data.DefaultValue.String));
					LinkButton lnkEdit = (LinkButton)SetControlText(e.Item, "lnkEdit", "Details");
					HyperLink lnkEditOut = (HyperLink)SetControlText(e.Item, "lnkEditOut", "Details");
					foreach (DataGridColumn loopColumn in dgPrimaryList.Columns)
					{
						if (loopColumn.HeaderText == "Primary Name")
						{
							loopColumn.SortExpression = vSiteLabel.PrimarySortColumn;
							break;
						}
					}
					if (this.WorkflowMode == MOD.Data.WorkflowMode.Internal)
					{
						foreach (DataGridColumn loopColumn in dgPrimaryList.Columns)
						{
							if (loopColumn.HeaderText == "Primary Name")
							{
								loopColumn.Visible = true;
								break;
							}
						}
						lnkEditOut.Visible = false;
					}
					else
					{
						foreach (DataGridColumn loopColumn in dgPrimaryList.Columns)
						{
							if (loopColumn.HeaderText == "Primary Name")
							{
								loopColumn.Visible = false;
								break;
							}
						}
						lnkEdit.Visible = false;
						string modeValue = "edit";
						if (IsEditAvailable == false)
						{
							modeValue = "view";
						}
						lnkEditOut.NavigateUrl = Page.ResolveUrl(string.Format("EditSiteLabel.aspx?mode=" + modeValue + "&message=&LocaleCode={0}&SiteLabelDefinitionCode={1}", vSiteLabel.LocaleCode, vSiteLabel.SiteLabelDefinitionCode));
					}
					System.Web.UI.Control lnkDelete = SetControlText(e.Item, "lnkDelete", (this.WorkflowMode == MOD.Data.WorkflowMode.Internal) ? "Remove" : "Delete");
					if (this.WorkflowMode == MOD.Data.WorkflowMode.External)
					{
						lnkDelete.Visible = false;
					}
					else
					{
						lnkDelete.Visible = IsDeleteAvailable;
					}
					if (lnkDelete is LinkButton)
					{
						WebControl wc = (WebControl)lnkDelete;
						wc.Attributes.Add("onclick", "javascript:return ConfirmDelete();");
					}
				}
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "ListSiteLabelData.dgPrimaryList_ItemDataBound"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Get Site Label information from the database.</summary>
		///
		// ------------------------------------------------------------------------------
		protected override void LoadCollectionFromDatabase()
		{
			int localeCode = MOD.Data.DataHelper.GetInt(Request.QueryString["LocaleCode"], MOD.Data.DefaultValue.Int);
			int siteLabelDefinitionCode = MOD.Data.DataHelper.GetInt(Request.QueryString["SiteLabelDefinitionCode"], MOD.Data.DefaultValue.Int);
			if (localeCode!= MOD.Data.DefaultValue.Int)
			{
				_collection = BLL.UserExperience.SiteLabelManager.GetAllSiteLabelDataByLocaleCode(localeCode, Globals.DBOptions, DataOptions, Globals.DebugLevel, Globals.CurrentUserID);
			}
			else if (siteLabelDefinitionCode!= MOD.Data.DefaultValue.Int)
			{
				_collection = BLL.UserExperience.SiteLabelManager.GetAllSiteLabelDataBySiteLabelDefinitionCode(siteLabelDefinitionCode, Globals.DBOptions, DataOptions, Globals.DebugLevel, Globals.CurrentUserID);
			}
			else
			{
				_collection = BLL.UserExperience.SiteLabelManager.GetAllSiteLabelData(Globals.DBOptions, DataOptions, Globals.DebugLevel, Globals.CurrentUserID);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Item command event handler for Site Label list.</summary>
		///
		// ------------------------------------------------------------------------------
		public void dgPrimaryList_ItemCommand(object sender, EventArgs e)
		{
			DataGridCommandEventArgs args = (DataGridCommandEventArgs)e;
			if (args.CommandName == "Edit" || args.CommandName == "Delete")
			{
				int hashCode = int.Parse(args.CommandArgument.ToString());
				BLL.UserExperience.SiteLabel item = ((BLL.SortableList<BLL.UserExperience.SiteLabel>)_collection).Find(hashCode);
				if (args.CommandName == "Edit")
				{
					this.editSiteLabel.SiteLabelItem = item;
					this.editSiteLabel.AccessMode = MOD.Data.AccessMode.Edit;
				}
				else if (args.CommandName == "Delete")
				{
					Globals.ClearMessages();
					_collection.Remove(item);
					if (this.editSiteLabel.SiteLabelItem == item)
					{
						this.editSiteLabel.AccessMode = MOD.Data.AccessMode.Add;
					}
					Globals.AddStatusMessage("Site Label removed.");
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Page pre render event handler for Site Label.</summary>
		///
		// ------------------------------------------------------------------------------
		private void Page_PreRender(object sender, EventArgs e)
		{
			try
			{
				SetAccessModeAndDisplay(AccessMode);
				base.OnPreRender();
				dgPrimaryList.DataSource = _collection;
				dgPrimaryList.DataKeyField = "LocaleCode";
				dgPrimaryList.DataBind();
				if (this.WorkflowMode == MOD.Data.WorkflowMode.Internal)
				{
					editSiteLabel.Visible = true;
					btnNew.Visible = false;
				}
				else
				{
					editSiteLabel.Visible = false;
					btnNew.Visible = true;
				}
				if (btnNew.Visible == true)
				{
					btnNew.Visible = IsEditAvailable;
				}
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "ListSiteLabelData.Page_PreRender"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set access and display modes for presenting Site Label information.</summary>
		///
		// ------------------------------------------------------------------------------
		private void SetAccessModeAndDisplay(MOD.Data.AccessMode accessMode)
		{
			// set access mode
			AccessMode = accessMode;
			btnNew.Visible = IsEditAvailable;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Request to create a new Site Label.</summary>
		///
		// ------------------------------------------------------------------------------
		private void btnNew_Click(object sender, EventArgs e)
		{
			Globals.ClearMessages();
			Response.Redirect(Page.ResolveUrl(string.Format("EditSiteLabel.aspx?mode=" + MOD.Data.AccessMode.Add.ToString() + "&LocaleCode=" + MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Int, "") + "&SiteLabelDefinitionCode=" + MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Int, "") + "")));
		}
		#endregion Event Handlers
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
		/// <summary>Initialize component for SiteLabel, add delegates here.</summary>
		///
		// ------------------------------------------------------------------------------
		private void InitializeComponent()
		{
			this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
			this.dgPrimaryList.ItemDataBound += new DataGridItemEventHandler(dgPrimaryList_ItemDataBound);
			this.dgPrimaryList.SortCommand += new DataGridSortCommandEventHandler(OnListSort);
			this.Load += new System.EventHandler(this.Page_Load);
			this.PreRender += new EventHandler(Page_PreRender);
		}
		#endregion
	}
}