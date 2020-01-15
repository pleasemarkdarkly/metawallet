
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="ListPromotionTypeData.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.Promotions.ListPromotionTypeData" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - List Promotion Type Data" %>
<%@ Register TagPrefix="MOD" TagName="ListPromotionTypeData" Src="~/UserControls/Desktop/Promotions/ListPromotionTypeData.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - List Promotion Type Data</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="PromotionType" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:ListPromotionTypeData id="listPromotionTypeData" AccessMode="All" DisplayMode="SingleView" WorkflowMode="External" RequiresAuthentication="true" runat="server"></MOD:ListPromotionTypeData>
</asp:Content>