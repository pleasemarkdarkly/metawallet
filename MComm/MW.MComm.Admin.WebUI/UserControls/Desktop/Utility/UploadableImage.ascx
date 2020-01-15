<!-- copyright
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
/copyright -->

<%@ Control Language="c#" AutoEventWireup="false" CodeFile="UploadableImage.ascx.cs" Inherits="MW.MComm.Admin.WebUI.UserControls.Desktop.Utility.UploadableImage" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="MODC" Namespace="MW.MComm.Admin.WebUI.Controls"%>
<div style="text-align:left; margin:5px;">
<asp:Image id="_image1" runat="server"></asp:Image>
<MODC:FlashContainer id="_flash1" runat="server" Visible="False"></MODC:FlashContainer>
<MODC:MovieContainer id="_movie1" runat="server" AutoStart="True" ShowControls="True" Visible="False"></MODC:MovieContainer>
<asp:HyperLink ID="_linkFile1" Target="_blank" Runat="server" CssClass="FormNormal">View</asp:HyperLink><br>
<INPUT id="_htmlInputFile1" type="file" name="_htmlInputFile" runat="server" class="FormNormal"/>&nbsp;
</div>
