
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="EditBillPayAccount.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.Accounts.EditBillPayAccount" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - Edit Bill Pay Account" %>
<%@ Register TagPrefix="MOD" TagName="EditBillPayAccount" Src="~/UserControls/Desktop/Accounts/EditBillPayAccount.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - Edit Bill Pay Account</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="BillPayAccount" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:EditBillPayAccount id="editBillPayAccount" AccessMode="Add" DisplayMode="TabbedView" WorkflowMode="External" UseWorkingSets="true" RequiresAuthentication="true" runat="server"></MOD:EditBillPayAccount>
</asp:Content>