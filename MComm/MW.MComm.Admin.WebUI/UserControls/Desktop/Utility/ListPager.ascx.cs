/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/
namespace MW.MComm.Admin.WebUI.UserControls.Desktop.Utility
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
    using MW.MComm.WalletSolution;
    using MW.MComm.WalletSolution.Utility;
    using MOD.Data;
    using DAL = MW.MComm.WalletSolution.DAL;
    using BLL = MW.MComm.WalletSolution.BLL;
	/// <summary>
	///		Summary description for ListPager.
	/// </summary>
	public partial class ListPager : Components.Desktop.BaseUserControl
	{
        private Components.Desktop.BaseListUserControl _list = null;
        public string ListID
        {
            get { return (string)ViewState["listID"]; }
            set { ViewState["listID"] = value; }
        }
        public Components.Desktop.BaseListUserControl List
        {
            get 
            { 
                if(_list == null)
                {
                    _list = NamingContainer as Components.Desktop.BaseListUserControl;
                }
                return _list; 
            }
            set { _list = value; }
        }
		private int PageCount
		{
			get
			{
				int pageCount = List.TotalRecords / List.PageSize;
				if((List.TotalRecords % List.PageSize) != 0)
					pageCount += 1;
				return pageCount;
			}
		}
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
		}
		
        private void SetupDisplayFromList()
        {
            int page = 1 + _list.StartIndex / _list.PageSize;
            pager.Visible = PageCount > 1;
            lblPage.Text = page.ToString();
            lblPageCount.Text = PageCount.ToString();
            int startIndex = _list.StartIndex + _list.PageSize;
            nextPage.CommandArgument = startIndex.ToString();
            nextPage.Enabled = startIndex <= _list.TotalRecords;
            startIndex = _list.StartIndex - _list.PageSize;
            prevPage.CommandArgument = startIndex.ToString();
            prevPage.Enabled = startIndex >= 1;
			lblTotalRecords.Text = string.Format("{0}-{1} of {2}",
				_list.StartIndex, 
				Math.Min(_list.TotalRecords,_list.StartIndex+_list.PageSize-1),
				_list.TotalRecords);
        }
		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.PreRender += new System.EventHandler(this.ListPager_PreRender);
			this.lnkGotoPage.Click += new EventHandler(lnkGotoPage_Click);
			ddlPageSize.SelectedIndexChanged += new EventHandler(ddlPageSize_SelectedIndexChanged);
        }   
        #endregion
        protected void prevPage_Click(object sender, EventArgs e)
        {
            List.StartIndex = int.Parse(prevPage.CommandArgument);
            List.RefreshList();
        }
        protected void nextPage_Click(object sender, EventArgs e)
        {
            List.StartIndex = int.Parse(nextPage.CommandArgument);
            List.RefreshList();
        }
        protected void ListPager_PreRender(object sender, EventArgs e)
        {
            if(List != null)
                SetupDisplayFromList();
			foreach(ListItem li in ddlPageSize.Items)
				li.Selected = li.Value == List.PageSize.ToString();
					
		}
		private void lnkGotoPage_Click(object sender, EventArgs e)
		{
			int page = MOD.Data.DataHelper.GetInt(txtGotoPage.Text,0);
			int pageCount = List.TotalRecords / List.PageSize;
			if(page < 1 || page > PageCount )
			{
				MW.MComm.Admin.WebUI.Globals.AddErrorMessage(Page,"Page Number between 1 and {0} Required.", PageCount);
				return;
			}
			
			List.StartIndex = 1 + (page-1) * List.PageSize;
			List.RefreshList();
		}
		private void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
		{
			List.PageSize = MOD.Data.DataHelper.GetInt(ddlPageSize.SelectedValue,List.PageSize);
			List.StartIndex = 1;
			List.RefreshList();
		}
	}
}
