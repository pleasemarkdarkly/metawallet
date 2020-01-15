
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="EditMetaPartnerSubType.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.Customers.EditMetaPartnerSubType" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - Edit Meta Partner Sub Type" %>
<%@ Register TagPrefix="MOD" TagName="EditMetaPartnerSubType" Src="~/UserControls/Desktop/Customers/EditMetaPartnerSubType.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - Edit Meta Partner Sub Type</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="MetaPartnerSubType" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:EditMetaPartnerSubType id="editMetaPartnerSubType" AccessMode="Add" DisplayMode="SingleView" WorkflowMode="External" UseWorkingSets="true" RequiresAuthentication="true" runat="server"></MOD:EditMetaPartnerSubType>
</asp:Content>