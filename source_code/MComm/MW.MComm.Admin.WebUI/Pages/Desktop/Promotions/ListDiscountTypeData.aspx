
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="ListDiscountTypeData.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.Promotions.ListDiscountTypeData" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - List Discount Type Data" %>
<%@ Register TagPrefix="MOD" TagName="ListDiscountTypeData" Src="~/UserControls/Desktop/Promotions/ListDiscountTypeData.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - List Discount Type Data</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="DiscountType" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:ListDiscountTypeData id="listDiscountTypeData" AccessMode="All" DisplayMode="SingleView" WorkflowMode="External" RequiresAuthentication="true" runat="server"></MOD:ListDiscountTypeData>
</asp:Content>