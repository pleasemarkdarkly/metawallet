
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="EditAccountAttributeValue.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.Accounts.EditAccountAttributeValue" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - Edit Account Attribute Value" %>
<%@ Register TagPrefix="MOD" TagName="EditAccountAttributeValue" Src="~/UserControls/Desktop/Accounts/EditAccountAttributeValue.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - Edit Account Attribute Value</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="AccountAttributeValue" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:EditAccountAttributeValue id="editAccountAttributeValue" AccessMode="Add" DisplayMode="TabbedView" WorkflowMode="External" UseWorkingSets="true" RequiresAuthentication="true" runat="server"></MOD:EditAccountAttributeValue>
</asp:Content>