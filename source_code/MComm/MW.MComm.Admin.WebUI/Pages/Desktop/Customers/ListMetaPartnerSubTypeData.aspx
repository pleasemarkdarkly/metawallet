
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="ListMetaPartnerSubTypeData.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.Customers.ListMetaPartnerSubTypeData" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - List Meta Partner Sub Type Data" %>
<%@ Register TagPrefix="MOD" TagName="ListMetaPartnerSubTypeData" Src="~/UserControls/Desktop/Customers/ListMetaPartnerSubTypeData.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - List Meta Partner Sub Type Data</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="MetaPartnerSubType" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:ListMetaPartnerSubTypeData id="listMetaPartnerSubTypeData" AccessMode="All" DisplayMode="SingleView" WorkflowMode="External" RequiresAuthentication="true" runat="server"></MOD:ListMetaPartnerSubTypeData>
</asp:Content>