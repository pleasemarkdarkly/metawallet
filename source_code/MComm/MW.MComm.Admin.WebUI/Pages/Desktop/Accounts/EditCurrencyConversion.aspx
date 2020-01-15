
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="EditCurrencyConversion.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.Accounts.EditCurrencyConversion" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - Edit Currency Conversion" %>
<%@ Register TagPrefix="MOD" TagName="EditCurrencyConversion" Src="~/UserControls/Desktop/Accounts/EditCurrencyConversion.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - Edit Currency Conversion</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="CurrencyConversion" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:EditCurrencyConversion id="editCurrencyConversion" AccessMode="Add" DisplayMode="TabbedView" WorkflowMode="External" UseWorkingSets="true" RequiresAuthentication="true" runat="server"></MOD:EditCurrencyConversion>
</asp:Content>