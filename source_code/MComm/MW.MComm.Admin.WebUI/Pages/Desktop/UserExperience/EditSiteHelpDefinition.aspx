
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="EditSiteHelpDefinition.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.UserExperience.EditSiteHelpDefinition" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - Edit Site Help Definition" %>
<%@ Register TagPrefix="MOD" TagName="EditSiteHelpDefinition" Src="~/UserControls/Desktop/UserExperience/EditSiteHelpDefinition.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - Edit Site Help Definition</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="SiteHelpDefinition" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:EditSiteHelpDefinition id="editSiteHelpDefinition" AccessMode="Add" DisplayMode="SingleView" WorkflowMode="External" UseWorkingSets="true" RequiresAuthentication="true" runat="server"></MOD:EditSiteHelpDefinition>
</asp:Content>