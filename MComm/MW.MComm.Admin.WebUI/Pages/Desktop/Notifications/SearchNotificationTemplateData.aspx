
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="SearchNotificationTemplateData.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.Notifications.SearchNotificationTemplateData" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - Search Notification Template Data" %>
<%@ Register TagPrefix="MOD" TagName="SearchNotificationTemplateData" Src="~/UserControls/Desktop/Notifications/SearchNotificationTemplateData.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - Search Notification Template Data</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="NotificationTemplate" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:SearchNotificationTemplateData id="searchNotificationTemplateData" AccessMode="All" DisplayMode="TabbedView" WorkflowMode="External" ProvideWorkingSet="false" RequiresAuthentication="true" runat="server"></MOD:SearchNotificationTemplateData>
</asp:Content>