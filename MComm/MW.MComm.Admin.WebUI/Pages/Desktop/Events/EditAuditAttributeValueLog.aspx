
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="EditAuditAttributeValueLog.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.Events.EditAuditAttributeValueLog" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - Edit Audit Attribute Value Log" %>
<%@ Register TagPrefix="MOD" TagName="EditAuditAttributeValueLog" Src="~/UserControls/Desktop/Events/EditAuditAttributeValueLog.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - Edit Audit Attribute Value Log</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="AuditAttributeValueLog" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:EditAuditAttributeValueLog id="editAuditAttributeValueLog" AccessMode="Add" DisplayMode="TabbedView" WorkflowMode="External" UseWorkingSets="true" RequiresAuthentication="true" runat="server"></MOD:EditAuditAttributeValueLog>
</asp:Content>