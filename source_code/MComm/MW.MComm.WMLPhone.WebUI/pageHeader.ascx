<%@ Control Language="C#" AutoEventWireup="true" CodeFile="pageHeader.ascx.cs" Inherits="MW.MComm.WMLPhone.WebUI.pageHeader" %>
<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>
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
</mobile:StyleSheet><Mobile:Image ID="imgLogo" Runat="server" BreakAfter="False"
    ImageUrl="~/images/metawalletlogo.gif" EnableViewState="False">
    <DeviceSpecific>
        <Choice ImageURL="images/metawalletlogo.gif" />
        <Choice ImageURL="images/metawalletlogo.wbmp" />
    </DeviceSpecific>
</Mobile:Image><Mobile:Label ID="lblHeader" Runat="server" StyleReference="header" EnableViewState="False"></Mobile:Label><Mobile:Label
    ID="lblTagline" Runat="server" StyleReference="tagline" EnableViewState="False"></Mobile:Label>
