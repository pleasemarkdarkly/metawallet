
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="EditPromotionType.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.Promotions.EditPromotionType" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - Edit Promotion Type" %>
<%@ Register TagPrefix="MOD" TagName="EditPromotionType" Src="~/UserControls/Desktop/Promotions/EditPromotionType.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - Edit Promotion Type</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="PromotionType" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:EditPromotionType id="editPromotionType" AccessMode="Add" DisplayMode="SingleView" WorkflowMode="External" UseWorkingSets="true" RequiresAuthentication="true" runat="server"></MOD:EditPromotionType>
</asp:Content>