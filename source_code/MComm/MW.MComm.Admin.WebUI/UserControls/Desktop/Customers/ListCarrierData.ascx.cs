
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
using MW.MComm.WalletSolution.BLL.Customers;
using CoreUtility = MW.MComm.WalletSolution.Utility;
using MW.MComm.Admin.WebUI.Components.Desktop;
namespace MW.MComm.Admin.WebUI.UserControls.Desktop.Customers
{
	// ------------------------------------------------------------------------------
	/// <summary>List Carrier Data is used to help manage Carrier information.</summary>
	///
	/// File History:
	/// <created>6/1/2007 (Chris Grundy)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class ListCarrierData  : Components.Desktop.BaseListUserControl
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
				editCarrier.UseValidation = value;
			}
		}
		public DataGrid DataGrid { get { return dgPrimaryList; } }
		#endregion Properties
		#region Event Handlers
		// ------------------------------------------------------------------------------
		/// <summary>Load page for Carrier listing.</summary>
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
					this.editCarrier.CarrierItem = (BLL.Customers.Carrier) Collection[_selectedIndex];
				}
				this.editCarrier.CarrierAdded += new EntityEditEventHandler(editCarrier_CarrierAdded);
				this.editCarrier.CarrierRemoved += new EntityEditEventHandler(editCarrier_CarrierRemoved);
			}
			catch (CoreUtility.CustomAppException ex)
			{
				base.HandleError(ex);
			}
			catch (System.Exception ex)
			{
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "ListCarrierData.Page_Load"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Item added event handler for Carrier.</summary>
		///
		// ------------------------------------------------------------------------------
		private void editCarrier_CarrierAdded(BaseFormlUserControl sender, EntityEditEventArgs e)
		{
			Globals.ClearMessages();
			_collection.Add(e.Entity);
			Globals.AddStatusMessage("Carrier added.");
		}
		// ------------------------------------------------------------------------------
		/// <summary>Item removed event handler for Carrier.</summary>
		///
		// ------------------------------------------------------------------------------
		private void editCarrier_CarrierRemoved(BaseFormlUserControl sender, EntityEditEventArgs e)
		{
			Globals.ClearMessages();
			_collection.Remove(e.Entity);
			Globals.AddStatusMessage("Carrier removed.");
		}
		// ------------------------------------------------------------------------------
		/// <summary>Binding for a list of Carrier.</summary>
		///
		// ------------------------------------------------------------------------------
		private void dgPrimaryList_ItemDataBound(object sender, DataGridItemEventArgs e)
		{
			try
			{
				if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.SelectedItem)
				{
					BLL.Customers.Carrier vCarrier = (BLL.Customers.Carrier)e.Item.DataItem;
					SetControlText(e.Item,"lblPrimaryName", MOD.Data.DataHelper.GetString(vCarrier.PrimaryName, ""));
					SetControlText(e.Item,"lblCarrierCode", MOD.Data.DataHelper.GetString(vCarrier.CarrierCode, ""));
					SetControlText(e.Item,"lblCreatedDate", MOD.Data.DataHelper.GetString(vCarrier.CreatedDate, ""));
					SetControlText(e.Item,"lblLastModifiedDate", MOD.Data.DataHelper.GetString(vCarrier.LastModifiedDate, ""));
					SetControlText(e.Item,"lblServiceCharges", MOD.Data.DataHelper.GetString(vCarrier.ServiceCharges, ""));
					SetControlText(e.Item,"lblMetaPartnerSubTypeCode", MOD.Data.DataHelper.GetString(vCarrier.MetaPartnerSubTypeCode, ""));
					SetControlText(e.Item,"lblLocaleCode", MOD.Data.DataHelper.GetString(vCarrier.LocaleCode, ""));
					SetControlText(e.Item,"lblCurrencyCode", MOD.Data.DataHelper.GetString(vCarrier.CurrencyCode, ""));
					SetControlText(e.Item,"lblDateFormatCode", MOD.Data.DataHelper.GetString(vCarrier.DateFormatCode, ""));
					SetControlText(e.Item,"lblTaxCode", MOD.Data.DataHelper.GetString(vCarrier.TaxCode, ""));
					SetControlText(e.Item,"lblIsActive", MOD.Data.DataHelper.GetString(vCarrier.IsActive, ""));
					SetControlText(e.Item,"lblMetaPartnerName", MOD.Data.DataHelper.GetString(vCarrier.MetaPartnerName, ""));
					System.Web.UI.WebControls.Image lblPictureImageURL = (System.Web.UI.WebControls.Image)e.Item.FindControl("lblPictureImageURL");
					lblPictureImageURL.ImageUrl = CoreUtility.FileManager.GetAbsoluteHttpUrl(CoreUtility.FileGroupCode.Customers, vCarrier.PictureImageURL, Page.ResolveUrl("~/images/missing_image-75.jpg"));
					HyperLink lnkPictureImageURL = (HyperLink)e.Item.FindControl("lnkPictureImageURL");
					lnkPictureImageURL.NavigateUrl = Page.ResolveUrl(CoreUtility.FileManager.GetAbsoluteHttpUrl(CoreUtility.FileGroupCode.Customers, vCarrier.PictureImageURL, Page.ResolveUrl("~/images/missing_image-75.jpg")));
					LinkButton lnkEdit = (LinkButton)SetControlText(e.Item, "lnkEdit", "Details");
					HyperLink lnkEditOut = (HyperLink)SetControlText(e.Item, "lnkEditOut", "Details");
					foreach (DataGridColumn loopColumn in dgPrimaryList.Columns)
					{
						if (loopColumn.HeaderText == "Primary Name")
						{
							loopColumn.SortExpression = vCarrier.PrimarySortColumn;
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
						lnkEditOut.NavigateUrl = Page.ResolveUrl(string.Format("EditCarrier.aspx?mode=" + modeValue + "&message=&MetaPartnerID={0}&CarrierMetaPartnerID={1}", vCarrier.MetaPartnerID, vCarrier.MetaPartnerID));
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "ListCarrierData.dgPrimaryList_ItemDataBound"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Get Carrier information from the database.</summary>
		///
		// ------------------------------------------------------------------------------
		protected override void LoadCollectionFromDatabase()
		{
			Guid metaPartnerID = MOD.Data.DataHelper.GetGuid(Request.QueryString["MetaPartnerID"], MOD.Data.DefaultValue.Guid);
			if (metaPartnerID!= MOD.Data.DefaultValue.Guid)
			{
				_collection = BLL.Customers.CarrierManager.GetAllCarrierDataByMetaPartnerID(metaPartnerID, Globals.DBOptions, DataOptions, Globals.DebugLevel, Globals.CurrentUserID);
			}
			else
			{
				_collection = BLL.Customers.CarrierManager.GetAllCarrierData(Globals.DBOptions, DataOptions, Globals.DebugLevel, Globals.CurrentUserID);
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Item command event handler for Carrier list.</summary>
		///
		// ------------------------------------------------------------------------------
		public void dgPrimaryList_ItemCommand(object sender, EventArgs e)
		{
			DataGridCommandEventArgs args = (DataGridCommandEventArgs)e;
			if (args.CommandName == "Edit" || args.CommandName == "Delete")
			{
				int hashCode = int.Parse(args.CommandArgument.ToString());
				BLL.Customers.Carrier item = ((BLL.SortableList<BLL.Customers.Carrier>)_collection).Find(hashCode);
				if (args.CommandName == "Edit")
				{
					this.editCarrier.CarrierItem = item;
					this.editCarrier.AccessMode = MOD.Data.AccessMode.Edit;
				}
				else if (args.CommandName == "Delete")
				{
					Globals.ClearMessages();
					_collection.Remove(item);
					if (this.editCarrier.CarrierItem == item)
					{
						this.editCarrier.AccessMode = MOD.Data.AccessMode.Add;
					}
					Globals.AddStatusMessage("Carrier removed.");
				}
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Page pre render event handler for Carrier.</summary>
		///
		// ------------------------------------------------------------------------------
		private void Page_PreRender(object sender, EventArgs e)
		{
			try
			{
				SetAccessModeAndDisplay(AccessMode);
				base.OnPreRender();
				dgPrimaryList.DataSource = _collection;
				dgPrimaryList.DataKeyField = "MetaPartnerID";
				dgPrimaryList.DataBind();
				if (this.WorkflowMode == MOD.Data.WorkflowMode.Internal)
				{
					editCarrier.Visible = true;
					btnNew.Visible = false;
				}
				else
				{
					editCarrier.Visible = false;
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
				base.HandleError(CoreUtility.CustomAppException.WrapException(ex, "ListCarrierData.Page_PreRender"));
			}
			finally
			{
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>Set access and display modes for presenting Carrier information.</summary>
		///
		// ------------------------------------------------------------------------------
		private void SetAccessModeAndDisplay(MOD.Data.AccessMode accessMode)
		{
			// set access mode
			AccessMode = accessMode;
			btnNew.Visible = IsEditAvailable;
		}
		// ------------------------------------------------------------------------------
		/// <summary>Request to create a new Carrier.</summary>
		///
		// ------------------------------------------------------------------------------
		private void btnNew_Click(object sender, EventArgs e)
		{
			Globals.ClearMessages();
			Response.Redirect(Page.ResolveUrl(string.Format("EditCarrier.aspx?mode=" + MOD.Data.AccessMode.Add.ToString() + "&MetaPartnerID=" + MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, "") + "&CarrierMetaPartnerID=" + MOD.Data.DataHelper.GetString(MOD.Data.DefaultValue.Guid, "") + "")));
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
		/// <summary>Initialize component for Carrier, add delegates here.</summary>
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