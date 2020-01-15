
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="SearchPaymentTransactionAttributeValueLogData.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.Payments.SearchPaymentTransactionAttributeValueLogData" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - Search Payment Transaction Attribute Value Log Data" %>
<%@ Register TagPrefix="MOD" TagName="SearchPaymentTransactionAttributeValueLogData" Src="~/UserControls/Desktop/Payments/SearchPaymentTransactionAttributeValueLogData.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - Search Payment Transaction Attribute Value Log Data</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="PaymentTransactionAttributeValueLog" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:SearchPaymentTransactionAttributeValueLogData id="searchPaymentTransactionAttributeValueLogData" AccessMode="All" DisplayMode="TabbedView" WorkflowMode="External" ProvideWorkingSet="false" RequiresAuthentication="true" runat="server"></MOD:SearchPaymentTransactionAttributeValueLogData>
</asp:Content>