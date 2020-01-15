
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="EditMetaPartnerCoupon.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.Promotions.EditMetaPartnerCoupon" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - Edit Meta Partner Coupon" %>
<%@ Register TagPrefix="MOD" TagName="EditMetaPartnerCoupon" Src="~/UserControls/Desktop/Promotions/EditMetaPartnerCoupon.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - Edit Meta Partner Coupon</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="MetaPartnerCoupon" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:EditMetaPartnerCoupon id="editMetaPartnerCoupon" AccessMode="Add" DisplayMode="TabbedView" WorkflowMode="External" UseWorkingSets="true" RequiresAuthentication="true" runat="server"></MOD:EditMetaPartnerCoupon>
</asp:Content>