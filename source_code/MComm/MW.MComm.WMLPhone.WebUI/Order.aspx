<%@ Page language="c#" ContentType="text/xml" ValidateRequest="false" EnableViewState="false" EnableEventValidation="false" CodeFile="Order.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.WMLPhone.WebUI.Order"%>
<%@ Register Src="pageHeader.ascx" TagName="pageHeader" TagPrefix="uc1" %>
<%@ Register Src="loggedInMenu.ascx" TagName="loggedInMenu" TagPrefix="uc2" %>
<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
<Mobile:Form ID="Form1" runat="server" StyleReference="defaultTextStyle">
<uc1:pageHeader id="PageHeader1" runat="server" ></uc1:pageHeader>
<Mobile:Label id="lblOrderTitle" runat="server"></Mobile:Label>
<Mobile:Label id=lblSourcePhone runat=server BreakAfter="False"></Mobile:Label>
<Mobile:TextBox runat=server id=txtSourcePhone></Mobile:TextBox>
<Mobile:Label id=lblDestinationPhone runat=server BreakAfter="False"></Mobile:Label>
<Mobile:TextBox runat=server id=txtDestinationPhone></Mobile:TextBox>
<Mobile:Label id=lblAmount runat=server BreakAfter="False"></Mobile:Label>
<Mobile:Label id=lblCurrency runat=server BreakAfter="False"></Mobile:Label>
<Mobile:TextBox runat=server id=txtAmount MaxLength="10" Numeric="True" Size="8"></Mobile:TextBox>
<Mobile:Command runat=server id=btnSubmit OnClick="btnSubmit_Click"></Mobile:Command>
<Mobile:Label id=lblStatus runat=server></Mobile:Label>
<uc2:loggedInMenu ID="LoggedInMenu1" runat="server" /></Mobile:Form>
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
    </mobile:StyleSheet>
</body></html>