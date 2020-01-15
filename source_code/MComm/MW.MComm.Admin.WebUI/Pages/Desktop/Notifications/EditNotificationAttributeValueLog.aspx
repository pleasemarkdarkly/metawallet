
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="EditNotificationAttributeValueLog.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.Notifications.EditNotificationAttributeValueLog" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - Edit Notification Attribute Value Log" %>
<%@ Register TagPrefix="MOD" TagName="EditNotificationAttributeValueLog" Src="~/UserControls/Desktop/Notifications/EditNotificationAttributeValueLog.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - Edit Notification Attribute Value Log</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="NotificationAttributeValueLog" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:EditNotificationAttributeValueLog id="editNotificationAttributeValueLog" AccessMode="Add" DisplayMode="TabbedView" WorkflowMode="External" UseWorkingSets="true" RequiresAuthentication="true" runat="server"></MOD:EditNotificationAttributeValueLog>
</asp:Content>