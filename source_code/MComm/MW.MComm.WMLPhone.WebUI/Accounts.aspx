<%@ Page language="c#" ContentType="text/xml" ValidateRequest="false" EnableViewState="false" EnableEventValidation="false" CodeFile="Accounts.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.WMLPhone.WebUI.Accounts"%>
<%@ Register Src="pageHeader.ascx" TagName="pageHeader" TagPrefix="uc2" %>
<%@ Register Src="loggedInMenu.ascx" TagName="loggedInMenu" TagPrefix="uc1" %>
<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
<Mobile:Form ID="Form1" runat="server" Title="Accounts" StyleReference="defaultTextStyle" OnPreRender="Form1_PreRender"><uc2:pageHeader ID="PageHeader1" runat="server" /> <mobile:Panel ID="panelAccounts" Runat="server" StyleReference="defaultTextStyle"><mobile:List ID="listAccounts" Runat="server" StyleReference="Lists"></mobile:List> <mobile:Label ID="lblShowDetail" Runat="server">
  </mobile:Label> <mobile:List ID="listShowDetail" Runat="server" StyleReference="Lists" ItemsAsLinks="True">
  </mobile:List> <mobile:Label ID="lblStatus" Runat="server">
</mobile:Label> <mobile:Command ID="cmdCreate" Runat="server" OnClick="cmdCreate_Click" Visible="False"></mobile:Command> <mobile:Command ID="cmdAddBank" Runat="server" OnClick="cmdAddBank_Click"></mobile:Command> </mobile:Panel><mobile:Panel ID="panelCreate" Runat="server" Visible="False"><mobile:Label ID="lblTermsTitle" Runat="server" StyleReference="title"></mobile:Label> <mobile:Label ID="lblTermsText" Runat="server" StyleReference="defaultTextStyle">By creating a MetaWallet Stored Value Account, you agree to the following terms and conditions: ..... insert legal terms here.</mobile:Label> <mobile:Command ID="cmdAccept" Runat="server" OnClick="cmdAccept_Click"></mobile:Command> <mobile:Command ID="cmdCancel" Runat="server" OnClick="cmdCancel_Click"></mobile:Command></mobile:Panel> <uc1:loggedInMenu ID="LoggedInMenu1" runat="server" />&nbsp;&nbsp;</Mobile:Form>&nbsp;<mobile:StyleSheet
  ID="StyleSheet1" Runat="server">
  <mobile:Style Font-Bold="True" Font-Size="Large" Name="header" StyleReference="title">
  </mobile:Style>
  <mobile:Style Font-Italic="True" Font-Size="Small" Name="tagline">
  </mobile:Style>
  <mobile:Style Alignment="Left" Font-Bold="False" Font-Italic="False" Font-Name="Arial"
    Font-Size="Normal" ForeColor="Black" Name="defaultTextStyle" Wrapping="Wrap">
  </mobile:Style>
  <mobile:Style Font-Size="Small" ForeColor="Blue" Name="links" StyleReference="defaultTextStyle">
  </mobile:Style>
  <mobile:Style Font-Name="Arial Narrow" Font-Size="Small" ForeColor="Black" Name="Lists">
  </mobile:Style>
  <mobile:Style Font-Bold="True" Font-Italic="False" Font-Size="Normal" Name="subtitle">
  </mobile:Style>
  <mobile:Style Font-Bold="True" Font-Size="Normal" ForeColor="Red" Name="error">
  </mobile:Style>
</mobile:StyleSheet>
</body></html>