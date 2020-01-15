
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="SearchAuditAttributeValueLogData.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.Events.SearchAuditAttributeValueLogData" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - Search Audit Attribute Value Log Data" %>
<%@ Register TagPrefix="MOD" TagName="SearchAuditAttributeValueLogData" Src="~/UserControls/Desktop/Events/SearchAuditAttributeValueLogData.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - Search Audit Attribute Value Log Data</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="AuditAttributeValueLog" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:SearchAuditAttributeValueLogData id="searchAuditAttributeValueLogData" AccessMode="All" DisplayMode="TabbedView" WorkflowMode="External" ProvideWorkingSet="false" RequiresAuthentication="true" runat="server"></MOD:SearchAuditAttributeValueLogData>
</asp:Content>