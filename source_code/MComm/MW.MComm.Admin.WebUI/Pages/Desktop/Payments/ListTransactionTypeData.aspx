
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="ListTransactionTypeData.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.Payments.ListTransactionTypeData" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - List Transaction Type Data" %>
<%@ Register TagPrefix="MOD" TagName="ListTransactionTypeData" Src="~/UserControls/Desktop/Payments/ListTransactionTypeData.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - List Transaction Type Data</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="TransactionType" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:ListTransactionTypeData id="listTransactionTypeData" AccessMode="All" DisplayMode="SingleView" WorkflowMode="External" RequiresAuthentication="true" runat="server"></MOD:ListTransactionTypeData>
</asp:Content>