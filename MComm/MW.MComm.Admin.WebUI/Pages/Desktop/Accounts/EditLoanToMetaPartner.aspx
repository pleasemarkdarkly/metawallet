
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="EditLoanToMetaPartner.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.Accounts.EditLoanToMetaPartner" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - Edit Loan To Meta Partner" %>
<%@ Register TagPrefix="MOD" TagName="EditLoanToMetaPartner" Src="~/UserControls/Desktop/Accounts/EditLoanToMetaPartner.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - Edit Loan To Meta Partner</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="LoanToMetaPartner" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:EditLoanToMetaPartner id="editLoanToMetaPartner" AccessMode="Add" DisplayMode="TabbedView" WorkflowMode="External" UseWorkingSets="true" RequiresAuthentication="true" runat="server"></MOD:EditLoanToMetaPartner>
</asp:Content>