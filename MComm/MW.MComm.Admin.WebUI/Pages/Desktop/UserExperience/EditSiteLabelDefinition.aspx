
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="EditSiteLabelDefinition.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.UserExperience.EditSiteLabelDefinition" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - Edit Site Label Definition" %>
<%@ Register TagPrefix="MOD" TagName="EditSiteLabelDefinition" Src="~/UserControls/Desktop/UserExperience/EditSiteLabelDefinition.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - Edit Site Label Definition</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="SiteLabelDefinition" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:EditSiteLabelDefinition id="editSiteLabelDefinition" AccessMode="Add" DisplayMode="SingleView" WorkflowMode="External" UseWorkingSets="true" RequiresAuthentication="true" runat="server"></MOD:EditSiteLabelDefinition>
</asp:Content>