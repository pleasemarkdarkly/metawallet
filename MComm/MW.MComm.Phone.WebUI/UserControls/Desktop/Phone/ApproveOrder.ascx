<%@ Register TagPrefix="Wilson" Namespace="Wilson.MasterPages" Assembly="WilsonMasterPages" %>
<%@ Control Language="c#" EnableViewState="false" AutoEventWireup="false" CodeFile ="ApproveOrder.ascx.cs" Inherits="MW.MComm.Phone.WebUI.UserControls.Desktop.Phone.ApproveOrder" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="MODC" Namespace="MW.MComm.Phone.WebUI.Controls"%>
<wilson:masterpage id="Masterpage" runat="server" templatefile="~/Templates/Desktop/DetailControl.ascx">
	<wilson:contentregion id="Title" runat="server">
		Approve&nbsp;Phone&nbsp;Order
	</wilson:contentregion>
	<wilson:contentregion id="Buttons" runat="server">
		<table id="ButtonsInfo" runat="server">
			<tr>
				<td>
					<asp:Button id="btnApprove" tabIndex="201" runat="server" CssClass="Button" CausesValidation="True" Text="Approve"></asp:Button>
					<asp:Button id="btnReject" tabIndex="202" runat="server" CssClass="Button" CausesValidation="False" Text="Reject"></asp:Button>
				</td>
			</tr>
		</table>
	</wilson:contentregion>

		<table>
			<tr>
				<td valign="top" colspan="2"><asp:Literal id="lblOrder" runat="server" ></asp:Literal></td>
			</tr>
			<tr>
				<td valign="top"><b><asp:Label id="lblPIN" runat="server" >PIN:</asp:Label></b></td>
				<td valign="top">
					<asp:TextBox id="txtPIN" tabIndex="3" runat="server" maxLength="40" Width="100"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td colspan=2 valign="top">
					<asp:Literal id="txtStatus" runat="server"></asp:Literal>
				</td>
			</tr>
		</table>
</wilson:masterpage>