
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="EditPaymentInstitution.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.Accounts.EditPaymentInstitution" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - Edit Payment Institution" %>
<%@ Register TagPrefix="MOD" TagName="EditPaymentInstitution" Src="~/UserControls/Desktop/Accounts/EditPaymentInstitution.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - Edit Payment Institution</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="PaymentInstitution" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:EditPaymentInstitution id="editPaymentInstitution" AccessMode="Add" DisplayMode="SingleView" WorkflowMode="External" UseWorkingSets="true" RequiresAuthentication="true" runat="server"></MOD:EditPaymentInstitution>
</asp:Content>