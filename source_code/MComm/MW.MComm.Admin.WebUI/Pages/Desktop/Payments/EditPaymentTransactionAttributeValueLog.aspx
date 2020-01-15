
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="EditPaymentTransactionAttributeValueLog.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.Payments.EditPaymentTransactionAttributeValueLog" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - Edit Payment Transaction Attribute Value Log" %>
<%@ Register TagPrefix="MOD" TagName="EditPaymentTransactionAttributeValueLog" Src="~/UserControls/Desktop/Payments/EditPaymentTransactionAttributeValueLog.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - Edit Payment Transaction Attribute Value Log</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="PaymentTransactionAttributeValueLog" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:EditPaymentTransactionAttributeValueLog id="editPaymentTransactionAttributeValueLog" AccessMode="Add" DisplayMode="TabbedView" WorkflowMode="External" UseWorkingSets="true" RequiresAuthentication="true" runat="server"></MOD:EditPaymentTransactionAttributeValueLog>
</asp:Content>