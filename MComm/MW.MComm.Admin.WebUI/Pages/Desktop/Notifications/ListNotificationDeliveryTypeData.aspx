
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="ListNotificationDeliveryTypeData.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.Notifications.ListNotificationDeliveryTypeData" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - List Notification Delivery Type Data" %>
<%@ Register TagPrefix="MOD" TagName="ListNotificationDeliveryTypeData" Src="~/UserControls/Desktop/Notifications/ListNotificationDeliveryTypeData.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - List Notification Delivery Type Data</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="NotificationDeliveryType" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:ListNotificationDeliveryTypeData id="listNotificationDeliveryTypeData" AccessMode="All" DisplayMode="SingleView" WorkflowMode="External" RequiresAuthentication="true" runat="server"></MOD:ListNotificationDeliveryTypeData>
</asp:Content>