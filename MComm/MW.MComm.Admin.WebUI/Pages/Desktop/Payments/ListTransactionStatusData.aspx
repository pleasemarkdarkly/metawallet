
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="ListTransactionStatusData.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.Payments.ListTransactionStatusData" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - List Transaction Status Data" %>
<%@ Register TagPrefix="MOD" TagName="ListTransactionStatusData" Src="~/UserControls/Desktop/Payments/ListTransactionStatusData.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - List Transaction Status Data</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="TransactionStatus" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:ListTransactionStatusData id="listTransactionStatusData" AccessMode="All" DisplayMode="SingleView" WorkflowMode="External" RequiresAuthentication="true" runat="server"></MOD:ListTransactionStatusData>
</asp:Content>