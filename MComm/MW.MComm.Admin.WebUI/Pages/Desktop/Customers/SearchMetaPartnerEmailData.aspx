
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="SearchMetaPartnerEmailData.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.Customers.SearchMetaPartnerEmailData" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - Search Meta Partner Email Data" %>
<%@ Register TagPrefix="MOD" TagName="SearchMetaPartnerEmailData" Src="~/UserControls/Desktop/Customers/SearchMetaPartnerEmailData.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - Search Meta Partner Email Data</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="MetaPartnerEmail" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:SearchMetaPartnerEmailData id="searchMetaPartnerEmailData" AccessMode="All" DisplayMode="TabbedView" WorkflowMode="External" ProvideWorkingSet="false" RequiresAuthentication="true" runat="server"></MOD:SearchMetaPartnerEmailData>
</asp:Content>