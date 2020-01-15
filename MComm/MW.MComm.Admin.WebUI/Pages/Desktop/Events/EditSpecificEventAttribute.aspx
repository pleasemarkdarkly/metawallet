
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="EditSpecificEventAttribute.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.Events.EditSpecificEventAttribute" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - Edit Specific Event Attribute" %>
<%@ Register TagPrefix="MOD" TagName="EditSpecificEventAttribute" Src="~/UserControls/Desktop/Events/EditSpecificEventAttribute.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - Edit Specific Event Attribute</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="SpecificEventAttribute" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:EditSpecificEventAttribute id="editSpecificEventAttribute" AccessMode="Add" DisplayMode="TabbedView" WorkflowMode="External" UseWorkingSets="true" RequiresAuthentication="true" runat="server"></MOD:EditSpecificEventAttribute>
</asp:Content>