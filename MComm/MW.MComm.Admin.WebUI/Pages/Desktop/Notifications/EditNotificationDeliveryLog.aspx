
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="EditNotificationDeliveryLog.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.Notifications.EditNotificationDeliveryLog" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - Edit Notification Delivery Log" %>
<%@ Register TagPrefix="MOD" TagName="EditNotificationDeliveryLog" Src="~/UserControls/Desktop/Notifications/EditNotificationDeliveryLog.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - Edit Notification Delivery Log</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="NotificationDeliveryLog" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:EditNotificationDeliveryLog id="editNotificationDeliveryLog" AccessMode="Add" DisplayMode="TabbedView" WorkflowMode="External" UseWorkingSets="true" RequiresAuthentication="true" runat="server"></MOD:EditNotificationDeliveryLog>
</asp:Content>