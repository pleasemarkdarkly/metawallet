
<%@ Page language="c#" MasterPageFile="~/Templates/Desktop/ContentPage.master" EnableEventValidation="False" CodeFile="EditDebugAttributeValueLog.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.Admin.WebUI.Pages.Desktop.Core.EditDebugAttributeValueLog" ValidateRequest="false" Title="MW.MComm.Admin.WebUI - Edit Debug Attribute Value Log" %>
<%@ Register TagPrefix="MOD" TagName="EditDebugAttributeValueLog" Src="~/UserControls/Desktop/Core/EditDebugAttributeValueLog.ascx"%>
<asp:Content id="Content1" ContentPlaceHolderID="cphTitle" runat="server">MW.MComm.Admin.WebUI - Edit Debug Attribute Value Log</asp:Content>
<asp:Content id="Content2" ContentPlaceHolderID="cphMetaTags" runat="server">
	<meta content="DebugAttributeValueLog" name="keywords"/>
	<meta content="MW.MComm.Admin.WebUI" name="description"/>
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="cphContent" runat="server">
	<MOD:EditDebugAttributeValueLog id="editDebugAttributeValueLog" AccessMode="Add" DisplayMode="TabbedView" WorkflowMode="External" UseWorkingSets="true" RequiresAuthentication="true" runat="server"></MOD:EditDebugAttributeValueLog>
</asp:Content>