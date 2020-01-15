using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
namespace MW.MComm.Admin.WebUI.Components.Desktop.Utility
{
    /// <summary>
    /// Summary description for PageSectionLinksControl
    /// </summary>
    public class PageSectionLinksControl : MW.MComm.Admin.WebUI.Components.Desktop.BaseUserControl
    {
        public virtual event EventHandler OnSectionChanged;
        public string CurrentSection
        {
            get { return (string)ViewState["CurrentSection"]; }
        }
    }
}