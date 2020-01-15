<!-- copyright
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
/copyright -->

<%@ Control Language="c#" AutoEventWireup="false" CodeFile="SelectableListBox.ascx.cs" Inherits="MW.MComm.Admin.WebUI.UserControls.Desktop.Utility.SelectableListBox" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<table cellpadding="0" cellspacing="0" >
    <tr>
        <td style="height: 19px">
            <asp:Label ID="lblUnselectedHeadingText" runat="server" Width="166px"></asp:Label></td>
        <td align="center" style="padding-left: 20px; height: 19px;">
        </td>
        <td style="padding-left: 20px; height: 19px;">
            <asp:Label ID="lblSelectedHeadingText" runat="server" Width="165px"></asp:Label></td>
        <td align="center" style="padding-left: 20px; height: 19px;">
        </td>
    </tr>
	<tr>
		<td><asp:listbox id="ListBoxUnselected" runat="server" Width="168px" Height="88px" CssClass="FormNormal" AutoPostBack="false"></asp:listbox></td>
		<td style="padding-left: 20px;" align="center">
		  <asp:Linkbutton CssClass="Button" id="btnSelect" onclick="btnSelect_Click" runat="server" Width="87px">Add &nbsp;<span class="PlusSign"></span></asp:Linkbutton><br /><br />
			<asp:Linkbutton CssClass="Button" id="btnUnselect" onclick="btnUnselect_Click" runat="server" Width="87px">Remove &nbsp;<span class="MinusSign"></span></asp:Linkbutton></td>
		<td style="padding-left: 20px;" ><asp:listbox id="ListBoxSelected" runat="server" Width="168px" Height="88px" CssClass="FormNormal"></asp:listbox></td>
		<td style="padding-left: 20px;" align="center">
		  <asp:Linkbutton id="btnMoveUp" CssClass="Button" onclick="btnMoveUp_Click" runat="server" Width="75px" >Move &nbsp;<span class="UpArrow"></span></asp:Linkbutton><br /><br />
			<asp:Linkbutton id="btnMoveDown" CssClass="Button"  onclick="btnMoveDown_Click" runat="server"  Width="75px">Move &nbsp;<span class="DownArrow"></span></asp:Linkbutton></td>
	</tr>
</table>
