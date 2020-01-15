
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="EditMetaTransferAccount.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.Accounts.EditMetaTransferAccount" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - Edit Meta Transfer Account" %>
<%@ Register TagPrefix="MOD" TagName="EditMetaTransferAccount" Src="~/UserControls/Desktop/Accounts/EditMetaTransferAccount.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - Edit Meta Transfer Account</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="MetaTransferAccount" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:EditMetaTransferAccount id="editMetaTransferAccount" AccessMode="Add" DisplayMode="TabbedView" WorkflowMode="External" UseWorkingSets="true" RequiresAuthentication="true" runat="server"></MOD:EditMetaTransferAccount>
</asp:Content>