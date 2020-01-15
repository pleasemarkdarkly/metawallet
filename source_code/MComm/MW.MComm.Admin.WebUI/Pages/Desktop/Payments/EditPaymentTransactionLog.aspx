
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="EditPaymentTransactionLog.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.Payments.EditPaymentTransactionLog" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - Edit Payment Transaction Log" %>
<%@ Register TagPrefix="MOD" TagName="EditPaymentTransactionLog" Src="~/UserControls/Desktop/Payments/EditPaymentTransactionLog.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - Edit Payment Transaction Log</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="PaymentTransactionLog" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:EditPaymentTransactionLog id="editPaymentTransactionLog" AccessMode="Add" DisplayMode="TabbedView" WorkflowMode="External" UseWorkingSets="true" RequiresAuthentication="true" runat="server"></MOD:EditPaymentTransactionLog>
</asp:Content>