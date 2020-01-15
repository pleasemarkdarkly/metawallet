
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="EditUserRoleUser.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.Users.EditUserRoleUser" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - Edit User Role User" %>
<%@ Register TagPrefix="MOD" TagName="EditUserRoleUser" Src="~/UserControls/Desktop/Users/EditUserRoleUser.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - Edit User Role User</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="UserRoleUser" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:EditUserRoleUser id="editUserRoleUser" AccessMode="Add" DisplayMode="TabbedView" WorkflowMode="External" UseWorkingSets="true" RequiresAuthentication="true" runat="server"></MOD:EditUserRoleUser>
</asp:Content>