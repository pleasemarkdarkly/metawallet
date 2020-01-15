
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" CodeFile="PhoneBalance.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.Testing.PhoneBalance" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - Pay Phone to Phone" %>
<%@ Register TagPrefix="MOD" TagName="PhoneBalance" Src="~/UserControls/Desktop/Testing/PhoneBalance.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - Pay Phone to Phone</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="Account" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:PhoneBalance id="payPhoneToPhone" AccessMode="Add" DisplayMode="SingleView" WorkflowMode="External" UseWorkingSets="true" RequiresAuthentication="true" runat="server"></MOD:PhoneBalance>
</asp:Content>