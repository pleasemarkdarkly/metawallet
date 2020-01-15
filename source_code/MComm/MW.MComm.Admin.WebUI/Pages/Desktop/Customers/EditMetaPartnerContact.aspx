
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="EditMetaPartnerContact.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.Customers.EditMetaPartnerContact" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - Edit Meta Partner Contact" %>
<%@ Register TagPrefix="MOD" TagName="EditMetaPartnerContact" Src="~/UserControls/Desktop/Customers/EditMetaPartnerContact.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - Edit Meta Partner Contact</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="MetaPartnerContact" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:EditMetaPartnerContact id="editMetaPartnerContact" AccessMode="Add" DisplayMode="TabbedView" WorkflowMode="External" UseWorkingSets="true" RequiresAuthentication="true" runat="server"></MOD:EditMetaPartnerContact>
</asp:Content>