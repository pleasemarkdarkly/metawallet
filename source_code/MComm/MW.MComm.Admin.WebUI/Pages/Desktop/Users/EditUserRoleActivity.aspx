
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="EditUserRoleActivity.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.Users.EditUserRoleActivity" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - Edit User Role Activity" %>
<%@ Register TagPrefix="MOD" TagName="EditUserRoleActivity" Src="~/UserControls/Desktop/Users/EditUserRoleActivity.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - Edit User Role Activity</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="UserRoleActivity" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:EditUserRoleActivity id="editUserRoleActivity" AccessMode="Add" DisplayMode="TabbedView" WorkflowMode="External" UseWorkingSets="true" RequiresAuthentication="true" runat="server"></MOD:EditUserRoleActivity>
</asp:Content>