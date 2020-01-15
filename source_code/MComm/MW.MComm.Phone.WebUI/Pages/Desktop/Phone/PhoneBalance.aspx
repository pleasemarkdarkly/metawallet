<%@ Page language="c#" EnableViewState="false" MasterPageFile="~/Templates/Desktop/ContentPage.master" CodeFile="PhoneBalance.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Phone.WebUI.Pages.Desktop.Phone.PhoneBalance" ValidateRequest="false" Title="MW.MComm.Phone.WebUI - Pay Phone to Phone" %>
<%@ Register TagPrefix="MOD" TagName="PhoneBalance" Src="~/UserControls/Desktop/Phone/PhoneBalance.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Phone.WebUI - Pay Phone to Phone</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:PhoneBalance id="payPhoneToPhone" AccessMode="Add" DisplayMode="SingleView" WorkflowMode="External" UseWorkingSets="true" RequiresAuthentication="false" runat="server"></MOD:PhoneBalance>
</asp:Content>