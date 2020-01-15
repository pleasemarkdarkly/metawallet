<%@ Page Language="C#" AutoEventWireup="true" CodeFile="userPref.aspx.cs" Inherits="MW.MComm.WMLPhone.WebUI.userPref" %>

<%@ Register Src="pageHeader.ascx" TagName="pageHeader" TagPrefix="uc1" %>
<%@ Register Src="loggedInMenu.ascx" TagName="loggedInMenu" TagPrefix="uc2" %>
<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
    <mobile:Form id="Form1" runat="server" StyleReference="defaultTextStyle">
        <uc1:pageHeader ID="PageHeader1" runat="server" />
        <mobile:Label ID="lblTitle" Runat="server" StyleReference="subtitle">
        </mobile:Label>
        <mobile:Label ID="lblFeedback" Runat="server" EnableViewState="False">
        </mobile:Label>
        <mobile:Label ID="lblChangePIN" Runat="server" StyleReference="subtitle">
        </mobile:Label>
        <mobile:Label ID="lblCurrentPIN" Runat="server" StyleReference="defaultTextStyle">
        </mobile:Label>
        <mobile:TextBox ID="inputPin" Runat="server" MaxLength="8" Numeric="True" Password="True"
            Size="4">
        </mobile:TextBox>
        <mobile:Label ID="lblNewPIN" Runat="server" StyleReference="defaultTextStyle">
        </mobile:Label>
        <mobile:TextBox ID="inputPIN1" Runat="server" MaxLength="8" Numeric="True" Password="True"
            Size="4">
        </mobile:TextBox>
        <mobile:Label ID="lblNewPIN2" Runat="server" StyleReference="defaultTextStyle">
        </mobile:Label>
        <mobile:TextBox ID="inputPIN2" Runat="server" MaxLength="8" Numeric="True" Password="True"
            Size="4">
        </mobile:TextBox>
        <mobile:Command ID="cmdPinChange" Runat="server" OnClick="cmdPinChange_Click">
        </mobile:Command>
        <mobile:Label ID="lblChangeAccount" Runat="server" StyleReference="subtitle">
        </mobile:Label>
        <mobile:Label ID="lblPreferredAccount" Runat="server">
        </mobile:Label><mobile:SelectionList ID="listAccounts" Runat="server" SelectType="Radio" StyleReference="Lists"
            Title="Languajes">
        </mobile:SelectionList>
        <mobile:Command ID="cmdChangeAccount" Runat="server" OnClick="cmdChangeAccount_Click1">
        </mobile:Command>
        <mobile:Label ID="lblLanguaje" Runat="server" StyleReference="subtitle">
        </mobile:Label>
        <mobile:SelectionList ID="listLanguaje" Runat="server" SelectType="Radio" StyleReference="Lists"
            Title="Languajes">
        </mobile:SelectionList>
        <mobile:Command ID="cmdChangeLanguje" Runat="server" OnClick="cmdChangeLanguje_Click">
        </mobile:Command>
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
    </mobile:StyleSheet>
</body>
</html>
