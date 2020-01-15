
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="SearchMetaPartnerPhoneData.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.Customers.SearchMetaPartnerPhoneData" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - Search Meta Partner Phone Data" %>
<%@ Register TagPrefix="MOD" TagName="SearchMetaPartnerPhoneData" Src="~/UserControls/Desktop/Customers/SearchMetaPartnerPhoneData.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - Search Meta Partner Phone Data</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="MetaPartnerPhone" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:SearchMetaPartnerPhoneData id="searchMetaPartnerPhoneData" AccessMode="All" DisplayMode="TabbedView" WorkflowMode="External" ProvideWorkingSet="false" RequiresAuthentication="true" runat="server"></MOD:SearchMetaPartnerPhoneData>
</asp:Content>