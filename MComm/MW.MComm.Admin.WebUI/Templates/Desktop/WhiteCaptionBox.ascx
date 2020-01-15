<%@ Reference Control="~/templates/desktop/captionbox.ascx" %>
<!-- copyright
MOD Systems, Inc (c) 2006 All Rights Reserved. 
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036 

All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by MOD Systems.  The contents may only be viewed by MOD Systems Engineers (employees) and selected Starbucks employees as outlined in the Licensing Agreement between MOD Systems and Starbucks Corporation on June 3rd, 2005.   

No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.  

No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact MOD System's competitive advantage.   

Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.   


/copyright -->

<%@ Register TagPrefix="Wilson" Namespace="Wilson.MasterPages" Assembly="WilsonMasterPages" %>
<%@ Control Language="c#" Inherits="MW.MComm.Admin.WebUI.Templates.Desktop.WhiteCaptionBox" CodeFile="WhiteCaptionBox.ascx.cs" %>

<table cellpadding=0 border=0 cellspacing=0 class="captionbox_white" id="table" runat="server">
  <tr class="captionbox_white_header">
      <td colspan=3 align="center"><asp:LinkButton ID="lnk" Runat="server"><asp:Label ID="lbl" Runat="server"><wilson:contentregion id="Title" runat="server"></wilson:contentregion></asp:Label></asp:LinkButton></td>
  </tr>
  <tr>
    <td align="left"><asp:Image Runat="server" ImageUrl="~/images/captionbox_corner_tl.gif" ID="Image1"></asp:Image></td>
		<td></td>
		<td align="right"><asp:Image Runat="server" ImageUrl="~/images/captionbox_corner_tr.gif" ID="Image2"></asp:Image></td>
	</tr>
	<tr>
		<td colspan=3><wilson:contentregion id="Content" runat="server"></wilson:contentregion></td>
	</tr>
	<tr>
		<td align="left"><asp:Image Runat="server" ImageUrl="~/images/captionbox_corner_bl.gif" ID="Image3"></asp:Image></td>
		<td></td>
		<td align="right"><asp:Image Runat="server" ImageUrl="~/Images/captionbox_corner_br.gif" ID="Image4"></asp:Image></td>
	</tr>
</table>
