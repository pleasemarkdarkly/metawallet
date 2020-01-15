<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ErrorMsg.aspx.cs" Inherits="ErrorMsg" %>

<%@ Register Src="pageHeader.ascx" TagName="pageHeader" TagPrefix="uc1" %>
<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
    <mobile:Form id="Form1" runat="server" StyleReference="defaultTextStyle" Title="MetaWallet">
      <uc1:pageHeader ID="PageHeader1" runat="server" />
      <mobile:Label ID="Label1" Runat="server" StyleReference="subtitle">Your session has timed out or an error has occurred. Please log in again.</mobile:Label>
      <mobile:Link ID="Link1" Runat="server" NavigateUrl="./default.aspx" StyleReference="links">Login</mobile:Link>
      <mobile:Label ID="Label2" Runat="server">Error details:</mobile:Label>
      <mobile:Label ID="lblError" Runat="server" StyleReference="Lists"></mobile:Label>

    </mobile:Form>
  <mobile:StyleSheet ID="StyleSheet1" Runat="server">
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
  </mobile:StyleSheet>
</body>
</html>
