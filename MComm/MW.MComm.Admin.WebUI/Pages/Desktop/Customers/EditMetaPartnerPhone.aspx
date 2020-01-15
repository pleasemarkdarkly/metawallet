
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="EditMetaPartnerPhone.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.Customers.EditMetaPartnerPhone" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - Edit Meta Partner Phone" %>
<%@ Register TagPrefix="MOD" TagName="EditMetaPartnerPhone" Src="~/UserControls/Desktop/Customers/EditMetaPartnerPhone.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - Edit Meta Partner Phone</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="MetaPartnerPhone" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:EditMetaPartnerPhone id="editMetaPartnerPhone" AccessMode="Add" DisplayMode="TabbedView" WorkflowMode="External" UseWorkingSets="true" RequiresAuthentication="true" runat="server"></MOD:EditMetaPartnerPhone>
</asp:Content>