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
using MW.MComm.WalletSolution.BLL.UserExperience;
using MW.MComm.WMLPhone.WebUI;

public partial class ErrorMsg : System.Web.UI.MobileControls.MobilePage
{
  protected void Page_Load(object sender, EventArgs e)
  {
      
      this.Label1.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.SessionTimeOut);
      this.Link1.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.LoginLabel);
      Session.Abandon();
      lblError.Text = Server.GetLastError().Message.Replace("\n\r", " / ").Replace("\r\n", " - ");
  }
}
