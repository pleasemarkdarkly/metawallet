
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="SearchPaymentTransactionLogData.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.Payments.SearchPaymentTransactionLogData" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - Search Payment Transaction Log Data" %>
<%@ Register TagPrefix="MOD" TagName="SearchPaymentTransactionLogData" Src="~/UserControls/Desktop/Payments/SearchPaymentTransactionLogData.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - Search Payment Transaction Log Data</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="PaymentTransactionLog" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:SearchPaymentTransactionLogData id="searchPaymentTransactionLogData" AccessMode="All" DisplayMode="TabbedView" WorkflowMode="External" ProvideWorkingSet="false" RequiresAuthentication="true" runat="server"></MOD:SearchPaymentTransactionLogData>
</asp:Content>