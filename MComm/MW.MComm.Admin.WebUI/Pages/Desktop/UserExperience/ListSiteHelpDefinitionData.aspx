
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="ListSiteHelpDefinitionData.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.UserExperience.ListSiteHelpDefinitionData" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - List Site Help Definition Data" %>
<%@ Register TagPrefix="MOD" TagName="ListSiteHelpDefinitionData" Src="~/UserControls/Desktop/UserExperience/ListSiteHelpDefinitionData.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - List Site Help Definition Data</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="SiteHelpDefinition" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:ListSiteHelpDefinitionData id="listSiteHelpDefinitionData" AccessMode="All" DisplayMode="SingleView" WorkflowMode="External" RequiresAuthentication="true" runat="server"></MOD:ListSiteHelpDefinitionData>
</asp:Content>