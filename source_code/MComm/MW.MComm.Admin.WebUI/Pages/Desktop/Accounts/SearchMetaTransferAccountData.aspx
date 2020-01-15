
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="SearchMetaTransferAccountData.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.Accounts.SearchMetaTransferAccountData" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - Search Meta Transfer Account Data" %>
<%@ Register TagPrefix="MOD" TagName="SearchMetaTransferAccountData" Src="~/UserControls/Desktop/Accounts/SearchMetaTransferAccountData.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - Search Meta Transfer Account Data</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="MetaTransferAccount" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:SearchMetaTransferAccountData id="searchMetaTransferAccountData" AccessMode="All" DisplayMode="TabbedView" WorkflowMode="External" ProvideWorkingSet="false" RequiresAuthentication="true" runat="server"></MOD:SearchMetaTransferAccountData>
</asp:Content>