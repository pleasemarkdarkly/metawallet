/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/
using MW.MComm.Admin.WebUI.Components.Desktop.Utility;
namespace MW.MComm.Admin.WebUI.UserControls.Desktop.Utility
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
    using MW.MComm.Admin.WebUI.Controls;
	/// <summary>
	///		Summary description for PageSectionLinks.
	/// </summary>
	public partial class PageSectionLinks : PageSectionLinksControl
    {
        public override event EventHandler OnSectionChanged;
        #region Declarations (Fields)
        private string[] _sections;
        private string[] _validationSections;
        #endregion
        #region Properties
        public string SelectedCssClass
		{
			get { return (string)ViewState["SelectedCssClass"]; }
			set { ViewState["SelectedCssClass"] = value; }
		}
		
		public string CssClass
		{
			get { return (string)ViewState["CssClass"]; }
			set { ViewState["CssClass"] = value; }
		}
        
        protected string[] ValidationSections
        {
            get
            {
                try
                {
                    _validationSections = ValidationList.Split(',');
                }
                catch
                {
                    _validationSections = null;
                }
                return _validationSections;
            }
        }
        public string ValidationList
        {
            get { return (string)ViewState["ValidationList"]; }
            set { ViewState["ValidationList"] = value; }
        }
        public string SectionList
        {
            get { return (string)ViewState["SectionList"]; }
            set { ViewState["SectionList"] = value; }
        }
        public string CurrentSection
		{
			get { return (string)ViewState["CurrentSection"]; }
			set
			{
				string currentSection = "";
				foreach (string section in Sections)
				{
					if (section.ToLower().Trim() == value.ToLower().Trim())
					{
						currentSection = value;
						break;
					}
				}
				if (currentSection == "")
				{
					currentSection = Sections[0];
				}
				ViewState["CurrentSection"] = currentSection;
			}
        }
        public int SelectedIndex
        {
            get
            {
                string[] sections = Sections;
                for (int i = 0; i < sections.Length; i++)
                    if (sections[i] == CurrentSection)
                        return i;
                return -1;
            }
        }
        public bool IsOnLastTab
        {
            get
            {
                string[] sections = Sections;
                return (sections[sections.Length - 1] == CurrentSection);
            }
        }
        public bool IsOnFirstTab
        {
            get
            {
                string[] sections = Sections;
                return (sections[0] == CurrentSection);
            }
        }
        protected string[] Sections
        {
            get
            {
                if (_sections == null)
                    _sections = SectionList.Split(',');
                return _sections;
            }
        }
        #endregion
        #region Event Handlers
        private void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
                if (Request.QueryString.Get("CurrentSection") != null)
                {
                   CurrentSection = Request.QueryString.Get("CurrentSection");
                }
                else
                {
                    CurrentSection = Sections[0];
                }
			}
		}
        private void rptLinks_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string sectionName = (string)e.Item.DataItem;
                LinkButton item = (LinkButton)e.Item.FindControl("itemLink");
                item.Text = sectionName.Replace("_", " ");
                //item.CommandName = "ChangeSection";
                //item.CommandArgument = sectionName;
                item.CssClass = sectionName == CurrentSection ? SelectedCssClass : CssClass;
                bool causesValidation = false;
                foreach (string validateItem in ValidationList.Split(','))
                {
                    if (sectionName == validateItem)
                    {
                        causesValidation = true;
                        break;
                    }
                }
                item.CausesValidation = causesValidation;
                //item.Enabled = sectionName != CurrentSection;
                //item.Command += new CommandEventHandler(itemLink_Command);
            }
        }
        public void rptLinks_ItemCommand(object sender, CommandEventArgs e)
        {
            //foreach (string section in Sections)
            //{
            //    System.Web.UI.Control ctlSection = NamingContainer.FindControl("Section_" + section);
            //    if (ctlSection != null)
            //        ctlSection.Visible = CurrentSection == section;
            //}
            
            bool canChangeSection = true;
            
            if (ValidationSections != null)
            {
                foreach (string section in ValidationSections)
                {
                    System.Web.UI.Control ctlSection = NamingContainer.FindControl("Section_" + section);
                    
                    if (ctlSection != null)
                    {
                        if (CurrentSection == section)
                        {
                            Page.Validate();
                            canChangeSection = Page.IsValid;
                            break;
                        }
                    }
                }
            }
            if (canChangeSection && CurrentSection != e.CommandArgument)
            {
                CurrentSection = (string)e.CommandArgument;
                
                if (OnSectionChanged != null)
                    OnSectionChanged(this, new EventArgs());
            }
            else
            {
                Globals.AddErrorMessage(Page, "Could not change section, validation error.");
            }
            
        }
        private void Page_PreRender(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rptLinks.DataSource = Sections;
                rptLinks.DataBind();
            }
            // Set the visibility of the page section
            foreach (string section in Sections)
            {
                PageSection ctlSection = (PageSection)NamingContainer.FindControl("Section_" + section);
                if (ctlSection != null)
                    ctlSection.Visible = CurrentSection == section;
            }
            foreach (RepeaterItem item in rptLinks.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    LinkButton link = (LinkButton)item.FindControl("itemLink");
                    link.CssClass = link.Text == CurrentSection.Replace("_", " ") ? SelectedCssClass : CssClass;
                }
            }
        }
        #endregion
        #region Methods
		/// <summary>
		/// Move to the next section
		/// </summary>
		public void OnSection(string nextSection)
		{
			rptLinks_ItemCommand(this, new CommandEventArgs("Next", nextSection));
		}
		/// <summary>
        /// Move to the next section
        /// </summary>
        public void OnNext()
        {
            string nextSection = Sections[SelectedIndex + 1];
            rptLinks_ItemCommand(this, new CommandEventArgs("Next", nextSection));
        }
        public void OnPrevious()
        {
            string previousSection = Sections[SelectedIndex - 1];
            rptLinks_ItemCommand(this, new CommandEventArgs("Previous", previousSection));
        }
        #endregion
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
			this.Load += new System.EventHandler(this.Page_Load);
			this.PreRender += new EventHandler(Page_PreRender);
			this.rptLinks.ItemDataBound += new RepeaterItemEventHandler(rptLinks_ItemDataBound);
		}
		#endregion
	}
}
