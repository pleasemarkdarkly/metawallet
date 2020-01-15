
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="SearchAccountAttributeValueData.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.Accounts.SearchAccountAttributeValueData" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - Search Account Attribute Value Data" %>
<%@ Register TagPrefix="MOD" TagName="SearchAccountAttributeValueData" Src="~/UserControls/Desktop/Accounts/SearchAccountAttributeValueData.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - Search Account Attribute Value Data</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="AccountAttributeValue" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:SearchAccountAttributeValueData id="searchAccountAttributeValueData" AccessMode="All" DisplayMode="TabbedView" WorkflowMode="External" ProvideWorkingSet="false" RequiresAuthentication="true" runat="server"></MOD:SearchAccountAttributeValueData>
</asp:Content>