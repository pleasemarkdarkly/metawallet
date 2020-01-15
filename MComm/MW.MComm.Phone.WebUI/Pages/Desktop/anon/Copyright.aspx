<%@ Page language="c#" EnableViewState="false" MasterPageFile="~/Templates/Desktop/ContentPage.master" CodeFile="Copyright.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Phone.WebUI.Pages.Desktop.anon.Copyright" ValidateRequest="false" Title="MOD.MMS.Phone.WebUI - Copyright" %>
<%@ Register TagPrefix="MOD" TagName="Copyright" Src="~/UserControls/Desktop/Utility/Copyright.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Phone.WebUI - Copyright</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:Copyright id="rights" runat="server"></MOD:Copyright>
</asp:Content>
