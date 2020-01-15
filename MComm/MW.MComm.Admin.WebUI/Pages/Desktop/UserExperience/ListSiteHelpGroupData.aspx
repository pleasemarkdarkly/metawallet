
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="ListSiteHelpGroupData.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.UserExperience.ListSiteHelpGroupData" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - List Site Help Group Data" %>
<%@ Register TagPrefix="MOD" TagName="ListSiteHelpGroupData" Src="~/UserControls/Desktop/UserExperience/ListSiteHelpGroupData.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - List Site Help Group Data</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="SiteHelpGroup" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:ListSiteHelpGroupData id="listSiteHelpGroupData" AccessMode="All" DisplayMode="SingleView" WorkflowMode="External" RequiresAuthentication="true" runat="server"></MOD:ListSiteHelpGroupData>
</asp:Content>