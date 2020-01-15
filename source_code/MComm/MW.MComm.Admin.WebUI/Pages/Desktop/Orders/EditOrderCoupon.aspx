
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="EditOrderCoupon.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.Orders.EditOrderCoupon" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - Edit Order Coupon" %>
<%@ Register TagPrefix="MOD" TagName="EditOrderCoupon" Src="~/UserControls/Desktop/Orders/EditOrderCoupon.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - Edit Order Coupon</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="OrderCoupon" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:EditOrderCoupon id="editOrderCoupon" AccessMode="Add" DisplayMode="TabbedView" WorkflowMode="External" UseWorkingSets="true" RequiresAuthentication="true" runat="server"></MOD:EditOrderCoupon>
</asp:Content>