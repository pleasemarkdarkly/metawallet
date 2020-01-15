<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="MW.MComm.WMLPhone.WebUI.login" EnableSessionState="True" %>
<%@ Register Src="pageHeader.ascx" TagName="pageHeader" TagPrefix="uc1" %>
<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
    <mobile:Form id="Form1" runat="server" Title="MetaWallet" StyleReference="defaultTextStyle">
        <uc1:pageHeader ID="PageHeader1" runat="server" />
        <mobile:Panel ID="panelLoginInput" Runat="server">
            <mobile:Label ID="lblError" Runat="server" EnableViewState="False" StyleReference="subtitle">
            </mobile:Label>
            <mobile:Label ID="lblPhoneNumber" Runat="server"></mobile:Label> <mobile:TextBox
    ID="inputPhone" Runat="server" MaxLength="15" Numeric="True" Size="15" Title="Phone number">
</mobile:TextBox><mobile:Label ID="lblPIN" Runat="server"></mobile:Label><mobile:TextBox
    ID="inputPIN" Runat="server" MaxLength="8" Numeric="True" Size="8"
    Title="PIN">
</mobile:TextBox> 
            <mobile:Command ID="cmdLogIn" Runat="server" OnClick="cmdLogIn_Click" BreakAfter="False"></mobile:Command>
            <mobile:Command ID="cmdSignIn" Runat="server" OnClick="cmdSignIn_Click">Create account</mobile:Command>
            <mobile:Label ID="lblSecLevel" Runat="server"></mobile:Label>
            <mobile:SelectionList ID="listAuthenticate" Runat="server" Rows="2" SelectType="Radio"
                Title="Authentication level:">
                <Item Selected="True" Text="Demo mode (any device/browser)" Value="demo" />
                <Item Text="High security (user's phone only)" Value="normal" />
            </mobile:SelectionList>
        </mobile:Panel>
        <mobile:Label ID="lblAccepted" Runat="server" Visible="False">You PIN was accepted. To validate your phone, your session will be initiated by a link that is being sent to your mobile.</mobile:Label>
      <mobile:Label ID="lblBeta" Runat="server" StyleReference="error">This service is in internal Beta mode. (c) MetaWallet.</mobile:Label>
    </mobile:Form>&nbsp;
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
