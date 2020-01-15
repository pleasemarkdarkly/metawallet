<%@ Control Language="C#" AutoEventWireup="true" CodeFile="loggedInMenu.ascx.cs" Inherits="MW.MComm.WMLPhone.WebUI.loggedInMenu" %>
<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>
<Mobile:Link ID="lblSendReceive" Runat="server" NavigateUrl="./makePayment.aspx" StyleReference="links"></Mobile:Link> 
<mobile:Link ID="linkSelfTransfer" Runat="server" StyleReference="links" NavigateUrl="~/TransferSelf.aspx"></mobile:Link> 
<mobile:Link ID="linkStoredValue" Runat="server" StyleReference="links" NavigateUrl="~/StoredValue.aspx"></mobile:Link> 
<mobile:Link ID="linkPrePaid" Runat="server" StyleReference="links" NavigateUrl="~/BuyPrepaid.aspx"></mobile:Link> 
<Mobile:Link ID="lblAccountsLink" Runat="server" NavigateUrl="./accounts.aspx" StyleReference="links"></Mobile:Link><Mobile:Link
ID="lblPreferences" Runat="server" NavigateUrl="userPref.aspx" StyleReference="links"></Mobile:Link> 
<mobile:Link ID="lblResellerLink" Runat="server" NavigateUrl="./reseller.aspx" StyleReference="links" Visible="False"></mobile:Link> 
<mobile:Link ID="lblCashierLink" Runat="server" NavigateUrl="./cashier.aspx" StyleReference="links" Visible="False"></mobile:Link> 
<Mobile:Link
ID="lblHelpLink" Runat="server" NavigateUrl="help.aspx" StyleReference="links"></Mobile:Link> 
<Mobile:Link
ID="linkLogout" Runat="server" NavigateUrl="./login.aspx?logout=true" StyleReference="links">
</Mobile:Link> &nbsp; <mobile:StyleSheet ID="StyleSheet1" Runat="server">
    <mobile:Style Font-Bold="True" Font-Size="Large" Name="header" StyleReference="title">
    </mobile:Style>
    <mobile:Style Font-Italic="True" Font-Size="Small" Name="tagline">
    </mobile:Style>
    <mobile:Style Alignment="Left" Font-Bold="False" Font-Italic="False" Font-Name="Arial"
        Font-Size="Normal" ForeColor="Black" Name="defaultTextStyle" Wrapping="Wrap">
    </mobile:Style>
    <mobile:Style Font-Size="Small" ForeColor="Blue" Name="links" StyleReference="defaultTextStyle">
    </mobile:Style>
</mobile:StyleSheet>
