
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="EditSeverityLevel.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.Core.EditSeverityLevel" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - Edit Severity Level" %>
<%@ Register TagPrefix="MOD" TagName="EditSeverityLevel" Src="~/UserControls/Desktop/Core/EditSeverityLevel.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - Edit Severity Level</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="SeverityLevel" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:EditSeverityLevel id="editSeverityLevel" AccessMode="Add" DisplayMode="SingleView" WorkflowMode="External" UseWorkingSets="true" RequiresAuthentication="true" runat="server"></MOD:EditSeverityLevel>
</asp:Content>