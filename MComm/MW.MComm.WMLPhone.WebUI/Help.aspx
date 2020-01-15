<%@ Page language="c#" ContentType="text/xml" ValidateRequest="false" EnableViewState="false" EnableEventValidation="false" CodeFile="Help.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.WMLPhone.WebUI.Help"%>
<%@ Register Src="pageHeader.ascx" TagName="pageHeader" TagPrefix="uc1" %>
<%@ Register Src="loggedInMenu.ascx" TagName="loggedInMenu" TagPrefix="uc2" %>
<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>
<mobile:form id="Form1" runat="server"><uc1:pageHeader id="PageHeader1" runat="server"></uc1:pageHeader> <mobile:Label id="lblHelp" runat="server" StyleReference="defaultTextStyle"></mobile:Label> <uc2:loggedInMenu id="LoggedInMenu1" runat="server"></uc2:loggedInMenu></mobile:form>
<mobile:stylesheet id="StyleSheet1" runat="server">
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
</mobile:stylesheet>
