
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="ListDataTypeData.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.Core.ListDataTypeData" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - List Data Type Data" %>
<%@ Register TagPrefix="MOD" TagName="ListDataTypeData" Src="~/UserControls/Desktop/Core/ListDataTypeData.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - List Data Type Data</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="DataType" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:ListDataTypeData id="listDataTypeData" AccessMode="All" DisplayMode="SingleView" WorkflowMode="External" RequiresAuthentication="true" runat="server"></MOD:ListDataTypeData>
</asp:Content>