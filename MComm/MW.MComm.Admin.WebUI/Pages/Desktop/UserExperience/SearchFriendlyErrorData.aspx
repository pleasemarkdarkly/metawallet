
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="SearchFriendlyErrorData.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.UserExperience.SearchFriendlyErrorData" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - Search Friendly Error Data" %>
<%@ Register TagPrefix="MOD" TagName="SearchFriendlyErrorData" Src="~/UserControls/Desktop/UserExperience/SearchFriendlyErrorData.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - Search Friendly Error Data</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="FriendlyError" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:SearchFriendlyErrorData id="searchFriendlyErrorData" AccessMode="All" DisplayMode="TabbedView" WorkflowMode="External" ProvideWorkingSet="false" RequiresAuthentication="true" runat="server"></MOD:SearchFriendlyErrorData>
</asp:Content>