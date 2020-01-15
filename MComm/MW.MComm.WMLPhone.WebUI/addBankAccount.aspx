<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addBankAccount.aspx.cs" Inherits="MW.MComm.WMLPhone.WebUI.addBankAccount" %>
<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>
<%@ Register Src="pageHeader.ascx" TagName="pageHeader" TagPrefix="uc2" %>
<%@ Register Src="loggedInMenu.ascx" TagName="loggedInMenu" TagPrefix="uc1" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
    <mobile:Form id="Form1" runat="server" StyleReference="defaultTextStyle">
      <uc2:pageHeader ID="PageHeader1" runat="server" />
      <mobile:Label ID="Label1" Runat="server">
      </mobile:Label>
      <mobile:SelectionList ID="listBanks" Runat="server" SelectType="Radio"
        StyleReference="Lists">
      </mobile:SelectionList>
      <mobile:Label ID="Label2" Runat="server">
      </mobile:Label>
      <mobile:TextBox ID="textBankCustomerCode" Runat="server" MaxLength="50">
      </mobile:TextBox>
      <mobile:Label ID="Label3" Runat="server">
      </mobile:Label>
      <mobile:TextBox ID="textBankPIN" Runat="server" MaxLength="10" Password="True">
      </mobile:TextBox>
      <mobile:Label ID="Label4" Runat="server">
      </mobile:Label>
      <mobile:TextBox ID="textDescrption" Runat="server" MaxLength="50">
      </mobile:TextBox>
      <mobile:Label ID="lblStatusBank" Runat="server" EnableViewState="False">
      </mobile:Label>
      <mobile:Command ID="cmdCancelBank" Runat="server" OnClick="cmdCancel_Click">
      </mobile:Command><mobile:Command ID="cmdAcceptBank" Runat="server" OnClick="cmdAcceptBank_Click">
      </mobile:Command>
      <uc1:loggedInMenu ID="LoggedInMenu1" runat="server" /></mobile:Form>
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
