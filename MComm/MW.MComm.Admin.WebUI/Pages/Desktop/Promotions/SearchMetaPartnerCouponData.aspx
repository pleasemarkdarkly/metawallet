
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="SearchMetaPartnerCouponData.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.Promotions.SearchMetaPartnerCouponData" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - Search Meta Partner Coupon Data" %>
<%@ Register TagPrefix="MOD" TagName="SearchMetaPartnerCouponData" Src="~/UserControls/Desktop/Promotions/SearchMetaPartnerCouponData.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - Search Meta Partner Coupon Data</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="MetaPartnerCoupon" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:SearchMetaPartnerCouponData id="searchMetaPartnerCouponData" AccessMode="All" DisplayMode="TabbedView" WorkflowMode="External" ProvideWorkingSet="false" RequiresAuthentication="true" runat="server"></MOD:SearchMetaPartnerCouponData>
</asp:Content>