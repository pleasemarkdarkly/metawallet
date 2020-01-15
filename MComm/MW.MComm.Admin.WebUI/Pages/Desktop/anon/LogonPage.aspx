<%@ Page Language="C#" MasterPageFile="~/Templates/Desktop/LogonPage.master" AutoEventWireup="true" CodeFile="LogonPage.aspx.cs" Inherits="Pages_Desktop_anon_LogonPage" Title="Untitled Page" %>
<%@ Register TagPrefix="Wilson" Namespace="Wilson.MasterPages" Assembly="WilsonMasterPages" %>
<%@ Register TagPrefix="MOD" TagName="Logon" Src="~/UserControls/Desktop/Utility/Logon.ascx"%>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTitle" Runat="Server">Meta Wallet Administration - Logon</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMetaTags" Runat="Server">
    <META content="help me!" name="keywords">
    <META content="Meta Wallet Administrative Site" name="description">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphContent" Runat="Server">
    <MOD:Logon id="logon" runat="server"></MOD:Logon>
</asp:Content>

