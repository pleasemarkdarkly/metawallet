<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AccountList.ascx.cs" Inherits="AccountList" %>
<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>
<mobile:Label ID="Label1" Runat="server" StyleReference="defaultTextStyle"></mobile:Label> 
<mobile:SelectionList ID="SelectionList1" Runat="server" SelectType="Radio" StyleReference="Lists"></mobile:SelectionList> 
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
  <mobile:Style Font-Bold="True" Font-Size="Normal" ForeColor="Red" Name="error">
  </mobile:Style>
</mobile:StyleSheet>
