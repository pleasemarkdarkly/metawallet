
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="SearchCurrencyConversionData.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.Accounts.SearchCurrencyConversionData" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - Search Currency Conversion Data" %>
<%@ Register TagPrefix="MOD" TagName="SearchCurrencyConversionData" Src="~/UserControls/Desktop/Accounts/SearchCurrencyConversionData.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - Search Currency Conversion Data</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="CurrencyConversion" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:SearchCurrencyConversionData id="searchCurrencyConversionData" AccessMode="All" DisplayMode="TabbedView" WorkflowMode="External" ProvideWorkingSet="false" RequiresAuthentication="true" runat="server"></MOD:SearchCurrencyConversionData>
</asp:Content>