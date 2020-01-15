
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="EditStoredValueAccount.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.Accounts.EditStoredValueAccount" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - Edit Stored Value Account" %>
<%@ Register TagPrefix="MOD" TagName="EditStoredValueAccount" Src="~/UserControls/Desktop/Accounts/EditStoredValueAccount.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - Edit Stored Value Account</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="StoredValueAccount" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:EditStoredValueAccount id="editStoredValueAccount" AccessMode="Add" DisplayMode="TabbedView" WorkflowMode="External" UseWorkingSets="true" RequiresAuthentication="true" runat="server"></MOD:EditStoredValueAccount>
</asp:Content>