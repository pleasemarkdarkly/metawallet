<%@ Page Language="c#" ContentType="text/xml" ValidateRequest="false" EnableViewState="false" AutoEventWireup="true" CodeFile="cashier.aspx.cs" Inherits="MW.MComm.WMLPhone.WebUI.cashier" %>
<%@ Register Src="pageHeader.ascx" TagName="pageHeader" TagPrefix="uc2" %>
<%@ Register Src="loggedInMenu.ascx" TagName="loggedInMenu" TagPrefix="uc1" %>
<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
<Mobile:Form ID="Form1" runat="server" Title="MetaWallet" StyleReference="defaultTextStyle">
    <uc2:pageHeader ID="PageHeader1" runat="server" /><mobile:Panel ID="panelRecive" Runat="server"><mobile:Label
      ID="lblWelcome" Runat="server"> </mobile:Label>
      <mobile:Label ID="lblError" Runat="server" StyleReference="error">
      </mobile:Label>
      <mobile:Label ID="Label1" Runat="server"></mobile:Label>
      <mobile:TextBox ID="textAmount" Runat="server" MaxLength="7" Numeric="True" Size="7">0</mobile:TextBox>
      <mobile:Label ID="Label2" Runat="server"></mobile:Label>
      <mobile:TextBox ID="textPhone" Runat="server" MaxLength="8" Numeric="True" Size="8">70</mobile:TextBox>
      <mobile:Command ID="cmdAdd" Runat="server" OnClick="cmdAdd_Click"></mobile:Command>
    </mobile:Panel>
  <mobile:Panel ID="panelSuccess" Runat="server" Visible="False">
    <mobile:Label ID="lblSucess" Runat="server">
    </mobile:Label>
    <mobile:Command ID="cmdNextSell" Runat="server" OnClick="cmdNextSell_Click"></mobile:Command>
  </mobile:Panel>
  <uc1:loggedInMenu ID="LoggedInMenu1" runat="server" /></Mobile:Form>
    <mobile:StyleSheet
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
    </mobile:StyleSheet>
</body></html>