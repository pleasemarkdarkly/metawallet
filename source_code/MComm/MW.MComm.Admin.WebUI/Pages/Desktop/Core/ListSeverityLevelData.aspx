
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="ListSeverityLevelData.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.Core.ListSeverityLevelData" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - List Severity Level Data" %>
<%@ Register TagPrefix="MOD" TagName="ListSeverityLevelData" Src="~/UserControls/Desktop/Core/ListSeverityLevelData.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - List Severity Level Data</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="SeverityLevel" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:ListSeverityLevelData id="listSeverityLevelData" AccessMode="All" DisplayMode="SingleView" WorkflowMode="External" RequiresAuthentication="true" runat="server"></MOD:ListSeverityLevelData>
</asp:Content>