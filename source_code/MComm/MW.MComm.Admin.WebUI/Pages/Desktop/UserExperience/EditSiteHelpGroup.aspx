
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="EditSiteHelpGroup.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.UserExperience.EditSiteHelpGroup" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - Edit Site Help Group" %>
<%@ Register TagPrefix="MOD" TagName="EditSiteHelpGroup" Src="~/UserControls/Desktop/UserExperience/EditSiteHelpGroup.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - Edit Site Help Group</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="SiteHelpGroup" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:EditSiteHelpGroup id="editSiteHelpGroup" AccessMode="Add" DisplayMode="SingleView" WorkflowMode="External" UseWorkingSets="true" RequiresAuthentication="true" runat="server"></MOD:EditSiteHelpGroup>
</asp:Content>