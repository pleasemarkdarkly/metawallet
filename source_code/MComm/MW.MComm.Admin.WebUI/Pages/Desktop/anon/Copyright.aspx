
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" CodeFile="Copyright.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.anon.Copyright" ValidateRequest="false" Title="MOD.MMS.Admin.WebUI - Copyright" %>
<%@ Register TagPrefix="MOD" TagName="Copyright" Src="~/UserControls/Desktop/Utility/Copyright.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - Copyright</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="Copyright" name="keywords"/>
	<meta content="MOD.MMS.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:Copyright id="rights" runat="server"></MOD:Copyright>
</asp:Content>
