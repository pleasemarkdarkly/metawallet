
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="SearchDebugAttributeData.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.Core.SearchDebugAttributeData" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - Search Debug Attribute Data" %>
<%@ Register TagPrefix="MOD" TagName="SearchDebugAttributeData" Src="~/UserControls/Desktop/Core/SearchDebugAttributeData.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - Search Debug Attribute Data</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="DebugAttribute" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:SearchDebugAttributeData id="searchDebugAttributeData" AccessMode="All" DisplayMode="TabbedView" WorkflowMode="External" ProvideWorkingSet="false" RequiresAuthentication="true" runat="server"></MOD:SearchDebugAttributeData>
</asp:Content>