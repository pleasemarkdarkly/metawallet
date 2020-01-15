<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BuyPrepaid.aspx.cs" Inherits="MW.MComm.WMLPhone.WebUI.BuyPrepaid" %>

<%@ Register Src="pageHeader.ascx" TagName="pageHeader" TagPrefix="uc1" %>
<%@ Register Src="loggedInMenu.ascx" TagName="loggedInMenu" TagPrefix="uc2" %>
<%@ Register Src="AccountList.ascx" TagName="AccountList" TagPrefix="uc3" %>
<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
    <mobile:Form id="Form1" runat="server" StyleReference="defaultTextStyle">
      <uc1:pageHeader ID="PageHeader1" runat="server" />
      <mobile:Label ID="labelError" Runat="server" EnableViewState="False" StyleReference="error">
      </mobile:Label>
      <mobile:Panel ID="panelBuyPrepaid" Runat="server">
        <mobile:Label ID="Label3" Runat="server"></mobile:Label>
        <mobile:Label ID="Label1" Runat="server" StyleReference="Lists"></mobile:Label>
        <mobile:TextBox ID="textPhone" Runat="server" MaxLength="11" Numeric="True">
        </mobile:TextBox>
        <mobile:Label ID="Label2" Runat="server"></mobile:Label>
        <mobile:TextBox ID="textAmount" Runat="server" Numeric="True" Size="10">
        </mobile:TextBox>
        <uc3:AccountList ID="AccountList1" runat="server" />
        <mobile:Command ID="cmdBuy" Runat="server" OnClick="cmdBuy_Click"></mobile:Command>
      </mobile:Panel>
      <uc2:loggedInMenu ID="LoggedInMenu1" runat="server" /></mobile:Form>
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
</body>
</html>
