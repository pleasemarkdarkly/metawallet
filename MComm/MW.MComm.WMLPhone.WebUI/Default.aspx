<%@ Page language="c#" ContentType="text/xml" ValidateRequest="false" EnableViewState="false" EnableEventValidation="false" CodeFile="Default.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.WMLPhone.WebUI._Default"%>
<%@ Register Src="pageHeader.ascx" TagName="pageHeader" TagPrefix="uc2" %>
<%@ Register Src="loggedInMenu.ascx" TagName="loggedInMenu" TagPrefix="uc1" %>
<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
<Mobile:Form ID="Form1" runat="server" Title="MetaWallet" StyleReference="defaultTextStyle">
    <uc2:pageHeader ID="PageHeader1" runat="server" />
    <mobile:Label ID="lblWelcome" Runat="server">Welcome, </mobile:Label><uc1:loggedInMenu ID="LoggedInMenu1" runat="server" /></Mobile:Form>&nbsp;<mobile:StyleSheet
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