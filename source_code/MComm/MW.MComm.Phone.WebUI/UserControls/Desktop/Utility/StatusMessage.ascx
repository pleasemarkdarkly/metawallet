<%@ Control Language="c#" EnableViewState="false" Inherits="MW.MComm.Phone.WebUI.UserControls.Desktop.Utility.StatusMessage" CodeFile="StatusMessage.ascx.cs" %>
<asp:Repeater ID="rptStatus" runat="server">
<ItemTemplate>
  <%# (string)Container.DataItem %><br>
</ItemTemplate>

</asp:Repeater>