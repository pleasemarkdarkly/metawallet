
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="ListSiteLabelDefinitionData.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.UserExperience.ListSiteLabelDefinitionData" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - List Site Label Definition Data" %>
<%@ Register TagPrefix="MOD" TagName="ListSiteLabelDefinitionData" Src="~/UserControls/Desktop/UserExperience/ListSiteLabelDefinitionData.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - List Site Label Definition Data</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="SiteLabelDefinition" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:ListSiteLabelDefinitionData id="listSiteLabelDefinitionData" AccessMode="All" DisplayMode="SingleView" WorkflowMode="External" RequiresAuthentication="true" runat="server"></MOD:ListSiteLabelDefinitionData>
</asp:Content>