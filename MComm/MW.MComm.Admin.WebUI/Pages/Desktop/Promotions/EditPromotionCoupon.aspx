
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="EditPromotionCoupon.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.Promotions.EditPromotionCoupon" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - Edit Promotion Coupon" %>
<%@ Register TagPrefix="MOD" TagName="EditPromotionCoupon" Src="~/UserControls/Desktop/Promotions/EditPromotionCoupon.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - Edit Promotion Coupon</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="PromotionCoupon" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:EditPromotionCoupon id="editPromotionCoupon" AccessMode="Add" DisplayMode="TabbedView" WorkflowMode="External" UseWorkingSets="true" RequiresAuthentication="true" runat="server"></MOD:EditPromotionCoupon>
</asp:Content>