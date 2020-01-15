
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="SearchStoredValueAccountData.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.Accounts.SearchStoredValueAccountData" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - Search Stored Value Account Data" %>
<%@ Register TagPrefix="MOD" TagName="SearchStoredValueAccountData" Src="~/UserControls/Desktop/Accounts/SearchStoredValueAccountData.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - Search Stored Value Account Data</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="StoredValueAccount" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:SearchStoredValueAccountData id="searchStoredValueAccountData" AccessMode="All" DisplayMode="TabbedView" WorkflowMode="External" ProvideWorkingSet="false" RequiresAuthentication="true" runat="server"></MOD:SearchStoredValueAccountData>
</asp:Content>