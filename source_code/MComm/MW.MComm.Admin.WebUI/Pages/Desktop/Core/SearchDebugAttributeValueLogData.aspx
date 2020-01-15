
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="SearchDebugAttributeValueLogData.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.Core.SearchDebugAttributeValueLogData" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - Search Debug Attribute Value Log Data" %>
<%@ Register TagPrefix="MOD" TagName="SearchDebugAttributeValueLogData" Src="~/UserControls/Desktop/Core/SearchDebugAttributeValueLogData.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - Search Debug Attribute Value Log Data</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="DebugAttributeValueLog" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:SearchDebugAttributeValueLogData id="searchDebugAttributeValueLogData" AccessMode="All" DisplayMode="TabbedView" WorkflowMode="External" ProvideWorkingSet="false" RequiresAuthentication="true" runat="server"></MOD:SearchDebugAttributeValueLogData>
</asp:Content>