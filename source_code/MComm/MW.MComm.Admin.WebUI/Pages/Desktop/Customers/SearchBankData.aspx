
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="SearchBankData.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.Customers.SearchBankData" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - Search Bank Data" %>
<%@ Register TagPrefix="MOD" TagName="SearchBankData" Src="~/UserControls/Desktop/Customers/SearchBankData.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - Search Bank Data</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="Bank" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:SearchBankData id="searchBankData" AccessMode="All" DisplayMode="TabbedView" WorkflowMode="External" ProvideWorkingSet="false" RequiresAuthentication="true" runat="server"></MOD:SearchBankData>
</asp:Content>