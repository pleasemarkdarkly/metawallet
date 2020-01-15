<%@ Page language="c#" ContentType="text/xml" ValidateRequest="false" EnableViewState="false" AutoEventWireup="true" CodeFile="Reseller.aspx.cs" Inherits="MW.MComm.WMLPhone.WebUI.reseller" %>
<%@ Register Src="pageHeader.ascx" TagName="pageHeader" TagPrefix="uc2" %>
<%@ Register Src="loggedInMenu.ascx" TagName="loggedInMenu" TagPrefix="uc1" %>
<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
<Mobile:Form ID="Form1" runat="server" Title="MetaWallet" StyleReference="defaultTextStyle" OnPreRender="Form1_PreRender">
    <uc2:pageHeader ID="PageHeader1" runat="server" />
    <mobile:Label ID="lblWelcome" Runat="server" StyleReference="defaultTextStyle"> </mobile:Label>
  <mobile:Label ID="lblBalance" Runat="server" StyleReference="Lists">
  </mobile:Label>
  <mobile:Panel ID="panelSell" Runat="server">
    <mobile:Label ID="Label1" Runat="server" StyleReference="header"></mobile:Label>
    <mobile:Label ID="lblError" Runat="server" EnableViewState="False" StyleReference="error">
    </mobile:Label>
    <mobile:SelectionList ID="listAmount" Runat="server" Rows="5" SelectType="Radio"
      StyleReference="Lists">
        <Item Selected="True" Text="Other amount" Value="0" />
        <Item Text="10" Value="10" />
        <Item Text="30" Value="30" />
        <Item Text="50" Value="50" />
        <Item Text="90" Value="90" />
    </mobile:SelectionList>
    <mobile:Label ID="Label2" Runat="server" BreakAfter="False" StyleReference="Lists"></mobile:Label>
    <mobile:TextBox ID="textAmount" Runat="server" MaxLength="5" Numeric="True" Size="5">
    </mobile:TextBox>
    <mobile:Label ID="Label3" Runat="server"></mobile:Label>
    <mobile:TextBox ID="textPhoneNumber" Runat="server" BreakAfter="False" MaxLength="8"
      Numeric="True" Size="8">
    </mobile:TextBox>
    <mobile:Command ID="cmdSell" Runat="server" OnClick="cmdSell_Click"></mobile:Command>
  </mobile:Panel>
  <mobile:Panel ID="panelSuccess" Runat="server" Visible="False">
    <mobile:Label ID="lblSuceess" Runat="server"></mobile:Label>
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