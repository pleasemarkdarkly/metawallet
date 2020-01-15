
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="SearchEventData.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.Events.SearchEventData" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - Search Event Data" %>
<%@ Register TagPrefix="MOD" TagName="SearchEventData" Src="~/UserControls/Desktop/Events/SearchEventData.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - Search Event Data</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="Event" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:SearchEventData id="searchEventData" AccessMode="All" DisplayMode="TabbedView" WorkflowMode="External" ProvideWorkingSet="false" RequiresAuthentication="true" runat="server"></MOD:SearchEventData>
</asp:Content>