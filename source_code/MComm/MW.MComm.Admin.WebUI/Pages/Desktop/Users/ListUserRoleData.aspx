
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="ListUserRoleData.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.Users.ListUserRoleData" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - List User Role Data" %>
<%@ Register TagPrefix="MOD" TagName="ListUserRoleData" Src="~/UserControls/Desktop/Users/ListUserRoleData.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - List User Role Data</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="UserRole" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:ListUserRoleData id="listUserRoleData" AccessMode="All" DisplayMode="SingleView" WorkflowMode="External" RequiresAuthentication="true" runat="server"></MOD:ListUserRoleData>
</asp:Content>