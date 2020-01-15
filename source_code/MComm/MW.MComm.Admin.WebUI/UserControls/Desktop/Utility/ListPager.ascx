<%/* copyright
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
*/%>

<%@ Control Language="c#" Inherits="MW.MComm.Admin.WebUI.UserControls.Desktop.Utility.ListPager" CodeFile="ListPager.ascx.cs" %>
<div id="pager" runat="server" >
<table width="70%" border=0>
<tr>
<td  class="Pager">
  Page Size:&nbsp;<asp:DropDownList CssClass="FormNormal" ID="ddlPageSize" Runat="server" AutoPostBack="True">
  <asp:ListItem Selected="True" Value="25"></asp:ListItem><asp:ListItem Value="50"></asp:ListItem><asp:ListItem Value="100"></asp:ListItem></asp:DropDownList>
</td>
<td  align="left" class="Pager"> <asp:LinkButton ID="lnkGotoPage" CausesValidation="False" Runat="server">Goto Page</asp:LinkButton>&nbsp;<asp:TextBox Width="30" CssClass="FormNormal" id="txtGotoPage" Runat="server"></asp:TextBox>
</td>
<td  align="center" class="Pager">
  <asp:LinkButton CausesValidation="False" ID="prevPage" Runat="server" onclick="prevPage_Click">Prev</asp:LinkButton>
  </td>
<td  align="center" class="Pager">Page
  <asp:Label ID="lblPage" Runat="server"></asp:Label>
  of
  <asp:Label ID="lblPageCount" Runat="server"></asp:Label>
</td>
  <td  align="center" class="Pager"><asp:LinkButton CausesValidation="False" ID="nextPage" Runat="server" onclick="nextPage_Click">Next</asp:LinkButton>
</td>
<td  align="right" class="Pager">
  Records: <asp:Label ID="lblTotalRecords" Runat="server"></asp:Label>
</td>  
</tr>  
</table>  
</div>

