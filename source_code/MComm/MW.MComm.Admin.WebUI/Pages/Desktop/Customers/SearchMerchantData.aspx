
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="SearchMerchantData.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.Customers.SearchMerchantData" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - Search Merchant Data" %>
<%@ Register TagPrefix="MOD" TagName="SearchMerchantData" Src="~/UserControls/Desktop/Customers/SearchMerchantData.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - Search Merchant Data</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="Merchant" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:SearchMerchantData id="searchMerchantData" AccessMode="All" DisplayMode="TabbedView" WorkflowMode="External" ProvideWorkingSet="false" RequiresAuthentication="true" runat="server"></MOD:SearchMerchantData>
</asp:Content>