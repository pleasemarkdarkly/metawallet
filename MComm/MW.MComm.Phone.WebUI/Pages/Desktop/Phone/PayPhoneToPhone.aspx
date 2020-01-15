<%@ Page language="c#" EnableViewState="false" MasterPageFile="~/Templates/Desktop/ContentPage.master" CodeFile="PayPhoneToPhone.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Phone.WebUI.Pages.Desktop.Phone.PayPhoneToPhone" ValidateRequest="false" Title="MW.MComm.Phone.WebUI - Pay Phone to Phone" %>
<%@ Register TagPrefix="MOD" TagName="PayPhoneToPhone" Src="~/UserControls/Desktop/Phone/PayPhoneToPhone.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Phone.WebUI - Pay Phone to Phone</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:PayPhoneToPhone id="payPhoneToPhone" AccessMode="Add" DisplayMode="SingleView" WorkflowMode="External" UseWorkingSets="true" RequiresAuthentication="false" runat="server"></MOD:PayPhoneToPhone>
</asp:Content>