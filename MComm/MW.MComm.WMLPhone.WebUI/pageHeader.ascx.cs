using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.Mobile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.MobileControls;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using BLL = MW.MComm.WalletSolution.BLL;
using MW.MComm.WalletSolution.BLL.UserExperience;
namespace MW.MComm.WMLPhone.WebUI
{
    /// <summary>
    /// Displays the metawallet logo, header and tagline in all mobile pages
    /// </summary>
    public partial class pageHeader : System.Web.UI.MobileControls.MobileUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblHeader.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.MetaWalletHeader);
            lblTagline.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.MetaWalletTagline);
        }
    }
}