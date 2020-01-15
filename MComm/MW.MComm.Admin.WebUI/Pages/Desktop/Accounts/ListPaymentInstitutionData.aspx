
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="ListPaymentInstitutionData.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.Accounts.ListPaymentInstitutionData" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - List Payment Institution Data" %>
<%@ Register TagPrefix="MOD" TagName="ListPaymentInstitutionData" Src="~/UserControls/Desktop/Accounts/ListPaymentInstitutionData.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - List Payment Institution Data</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="PaymentInstitution" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:ListPaymentInstitutionData id="listPaymentInstitutionData" AccessMode="All" DisplayMode="SingleView" WorkflowMode="External" RequiresAuthentication="true" runat="server"></MOD:ListPaymentInstitutionData>
</asp:Content>