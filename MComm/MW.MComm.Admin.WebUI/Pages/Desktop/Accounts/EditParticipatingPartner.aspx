
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="EditParticipatingPartner.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.Accounts.EditParticipatingPartner" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - Edit Participating Partner" %>
<%@ Register TagPrefix="MOD" TagName="EditParticipatingPartner" Src="~/UserControls/Desktop/Accounts/EditParticipatingPartner.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - Edit Participating Partner</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="ParticipatingPartner" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:EditParticipatingPartner id="editParticipatingPartner" AccessMode="Add" DisplayMode="TabbedView" WorkflowMode="External" UseWorkingSets="true" RequiresAuthentication="true" runat="server"></MOD:EditParticipatingPartner>
</asp:Content>