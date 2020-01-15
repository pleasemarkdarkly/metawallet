
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="SearchNotificationAttributeValueLogData.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.Notifications.SearchNotificationAttributeValueLogData" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - Search Notification Attribute Value Log Data" %>
<%@ Register TagPrefix="MOD" TagName="SearchNotificationAttributeValueLogData" Src="~/UserControls/Desktop/Notifications/SearchNotificationAttributeValueLogData.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - Search Notification Attribute Value Log Data</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="NotificationAttributeValueLog" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:SearchNotificationAttributeValueLogData id="searchNotificationAttributeValueLogData" AccessMode="All" DisplayMode="TabbedView" WorkflowMode="External" ProvideWorkingSet="false" RequiresAuthentication="true" runat="server"></MOD:SearchNotificationAttributeValueLogData>
</asp:Content>