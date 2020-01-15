
<%/* copyright
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
*/%>
<%@ Control Language="c#" Inherits="MW.MComm.Admin.WebUI.UserControls.Desktop.Utility.PageHelp" CodeFile="PageHelp.ascx.cs" %>
<asp:Label id="lblHelpTitle" CssClass="subtitle" Runat="server" Visible="false"></asp:Label>&nbsp;<asp:Label id="lblTitleMessage" CssClass="subtitle" Runat="server"></asp:Label>
<br/><asp:literal id="lblPageHelp" runat="server" Visible="false"></asp:literal>
<br/><asp:Button id="btnHelp" tabIndex="10" runat="server" CssClass="Button" CausesValidation="False" Text="Help"></asp:Button>
