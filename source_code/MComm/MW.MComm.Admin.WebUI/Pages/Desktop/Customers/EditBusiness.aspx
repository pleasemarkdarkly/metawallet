
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="EditBusiness.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.Customers.EditBusiness" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - Edit Business" %>
<%@ Register TagPrefix="MOD" TagName="EditBusiness" Src="~/UserControls/Desktop/Customers/EditBusiness.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - Edit Business</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="Business" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:EditBusiness id="editBusiness" AccessMode="Add" DisplayMode="TabbedView" WorkflowMode="External" UseWorkingSets="true" RequiresAuthentication="true" runat="server"></MOD:EditBusiness>
</asp:Content>