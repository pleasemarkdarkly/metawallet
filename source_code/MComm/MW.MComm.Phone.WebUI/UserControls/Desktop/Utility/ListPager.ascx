<%@ Control Language="c#" EnableViewState="false" Inherits="MW.MComm.Phone.WebUI.UserControls.Desktop.Utility.ListPager" CodeFile="ListPager.ascx.cs" %>
<div id="pager" runat="server" >
<table width="70%" border=0>
<tr>
<td  class="Pager">
  Page Size:&nbsp;<asp:DropDownList ID="ddlPageSize" Runat="server" AutoPostBack="True">
  <asp:ListItem Selected="True" Value="25"></asp:ListItem><asp:ListItem Value="50"></asp:ListItem><asp:ListItem Value="100"></asp:ListItem></asp:DropDownList>
</td>
<td  align="left" class="Pager"> <asp:LinkButton ID="lnkGotoPage" CausesValidation="False" Runat="server">Goto Page</asp:LinkButton>&nbsp;<asp:TextBox Width="30" id="txtGotoPage" Runat="server"></asp:TextBox>
</td>
<td  align="center" class="Pager">
  <asp:LinkButton CausesValidation="False" ID="prevPage" Runat="server" onclick="prevPage_Click">Prev</asp:LinkButton>
  </td>
<td  align="center">Page
  <asp:Label ID="lblPage" Runat="server"></asp:Label>
  of
  <asp:Label ID="lblPageCount" Runat="server"></asp:Label>
</td>
  <td  align="center"><asp:LinkButton CausesValidation="False" ID="nextPage" Runat="server" onclick="nextPage_Click">Next</asp:LinkButton>
</td>
<td  align="right">
  Records: <asp:Label ID="lblTotalRecords" Runat="server"></asp:Label>
</td>  
</tr>  
</table>  
</div>
