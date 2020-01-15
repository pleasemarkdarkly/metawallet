
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="ListCountryData.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.Environments.ListCountryData" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - List Country Data" %>
<%@ Register TagPrefix="MOD" TagName="ListCountryData" Src="~/UserControls/Desktop/Environments/ListCountryData.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - List Country Data</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="Country" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:ListCountryData id="listCountryData" AccessMode="All" DisplayMode="SingleView" WorkflowMode="External" RequiresAuthentication="true" runat="server"></MOD:ListCountryData>
</asp:Content>