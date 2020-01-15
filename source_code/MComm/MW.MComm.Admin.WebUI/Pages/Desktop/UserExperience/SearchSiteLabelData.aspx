
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="SearchSiteLabelData.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.UserExperience.SearchSiteLabelData" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - Search Site Label Data" %>
<%@ Register TagPrefix="MOD" TagName="SearchSiteLabelData" Src="~/UserControls/Desktop/UserExperience/SearchSiteLabelData.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - Search Site Label Data</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="SiteLabel" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:SearchSiteLabelData id="searchSiteLabelData" AccessMode="All" DisplayMode="TabbedView" WorkflowMode="External" ProvideWorkingSet="false" RequiresAuthentication="true" runat="server"></MOD:SearchSiteLabelData>
</asp:Content>