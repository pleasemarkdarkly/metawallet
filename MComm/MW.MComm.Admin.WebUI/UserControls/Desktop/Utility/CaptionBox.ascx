<%@ Control Language="c#" Inherits="MW.MComm.Admin.WebUI.UserControls.Desktop.Utility.CaptionBox" CodeFile="CaptionBox.ascx.cs" %>

<table cellpadding="0" border="0" cellspacing="0" class="captionbox" runat="server" id="table">
  <tr>
      <td colspan="3" align="left">
        <table cellspacing="0" cellpadding="0" width="100%">
          <tr>
            <td align="left" style="padding: 0px">
               <asp:LinkButton ID="lnkHeader" Runat="server">
                  <asp:Label ID="lblTitle" Runat="server">
                    <asp:PlaceHolder ID="headerPlaceHolder" Runat="server"></asp:PlaceHolder>
                  </asp:Label>
                </asp:LinkButton>
            </td>
            <td align="left" width="15" style="padding: 0px">
              <asp:LinkButton ID="lnk" Runat="server">
              <asp:Image ImageAlign="AbsMiddle"  ID="imgCaret" Runat="server"></asp:Image>
              </asp:LinkButton>
            </td>
            </tr>
        </table>
       </td>
  </tr>
  <tr>
    <td align="left"><asp:Image id="tlImg" Runat="server" ImageUrl="~/images/captionbox_corner_tl.gif"></asp:Image></td>
		<td></td>
		<td align="right"><asp:Image id="trImg" Runat="server" ImageUrl="~/images/captionbox_corner_tr.gif"></asp:Image></td>
	</tr>
	<tr>
		<td colspan="3">
		  <asp:PlaceHolder ID="bodyPlaceHolder" Runat="server"></asp:PlaceHolder>
		</td>
	</tr>
	<tr>
		<td align="left"><asp:Image id="blImg" Runat="server" ImageUrl="~/images/captionbox_corner_bl.gif"></asp:Image></td>
		<td></td>
		<td align="right"><asp:Image id="brImg" Runat="server" ImageUrl="~/Images/captionbox_corner_br.gif"></asp:Image></td>
	</tr>
</table>
