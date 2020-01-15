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
    public partial class loggedInMenu : System.Web.UI.MobileControls.MobileUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Set up site labels
            //lblSendReceive.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.SendAndReceiveLink);
            lblAccountsLink.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.ManageAccountsLink);
            lblPreferences.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.UserPreferencesLink);
            lblHelpLink.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.HelpPageLink);
            linkLogout.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.LogoutButton);
            //[20070622 SBA] Reemplazo 
            lblSendReceive.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.SendBankTransferLink);
            linkSelfTransfer.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.TransferFundsBetweenMyAccountsLink);
            linkStoredValue.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.StoredValueTransactionsLink);
            linkPrePaid.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.BuyPrepaidMinutesLink);
            lblResellerLink.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.ResellerLink);
            lblCashierLink.Text = Globals.GetSiteLabel(SiteLabelDefinitionCode.CashierLink);

            try
            {
                this.lblCashierLink.Visible = (Globals.CurrentPartner.MetaPartnerSubTypeName.ToLower() == "cashier");
                this.lblResellerLink.Visible = (Globals.CurrentPartner.MetaPartnerSubTypeName.ToLower() == "reseller");
            }
            catch
            { }
        }
    }
}