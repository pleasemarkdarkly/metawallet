<%@ Page Language="C#" AutoEventWireup="true" CodeFile="makePayment.aspx.cs" Inherits="MW.MComm.WMLPhone.WebUI.makePayment" %>

<%@ Register Src="AccountList.ascx" TagName="AccountList" TagPrefix="uc3" %>
<%@ Register Src="pageHeader.ascx" TagName="pageHeader" TagPrefix="uc1" %>
<%@ Register Src="loggedInMenu.ascx" TagName="loggedInMenu" TagPrefix="uc2" %>
<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
    <mobile:Form id="Form1" runat="server" StyleReference="defaultTextStyle">
        <uc1:pageHeader ID="PageHeader1" runat="server" />
        <mobile:Panel ID="panelPay" Runat="server">
            <mobile:Label ID="lblStatus" Runat="server" EnableViewState="False" Visible="False" StyleReference="subtitle">
            </mobile:Label>
        <mobile:Label ID="lblPIN" Runat="server" EnableViewState="False" Visible="False"></mobile:Label>
        <mobile:TextBox ID="PIN" Runat="server" MaxLength="8" Numeric="True" Password="True"
            Size="4" Visible="False">
        </mobile:TextBox>
        <mobile:Label ID="lblDestinationPhone" Runat="server" EnableViewState="False"></mobile:Label>
        <mobile:TextBox ID="destinationPhone" Runat="server" MaxLength="15" Numeric="True">
        </mobile:TextBox>
        <mobile:Label ID="lblAmount" Runat="server" EnableViewState="False">
        </mobile:Label>
        <mobile:TextBox ID="amount" Runat="server" MaxLength="8" Numeric="True" Size="8">
        </mobile:TextBox>
        <mobile:Command ID="cmdMakeOrder" Runat="server" OnClick="cmdMakeOrder_Click"></mobile:Command>
            <mobile:Label ID="lblOthers" Runat="server" StyleReference="subtitle">
            </mobile:Label>
          <uc3:AccountList ID="AccountList1" runat="server" /></mobile:Panel>
        <mobile:Panel ID="panelResult" Runat="server" Visible="False">
            <mobile:Label ID="lblResult" Runat="server">
            </mobile:Label>
        </mobile:Panel>
        <uc2:loggedInMenu ID="LoggedInMenu1" runat="server" /></mobile:Form>&nbsp;<mobile:StyleSheet
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
</body>
</html>
