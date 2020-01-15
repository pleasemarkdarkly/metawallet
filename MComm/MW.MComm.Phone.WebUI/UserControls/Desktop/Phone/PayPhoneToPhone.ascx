<%@ Register TagPrefix="Wilson" Namespace="Wilson.MasterPages" Assembly="WilsonMasterPages" %>
<%@ Control Language="c#" EnableViewState="false" AutoEventWireup="false" CodeFile ="PayPhoneToPhone.ascx.cs" Inherits="MW.MComm.Phone.WebUI.UserControls.Desktop.Phone.PayPhoneToPhone" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="MODC" Namespace="MW.MComm.Phone.WebUI.Controls"%>
<wilson:masterpage id="Masterpage" runat="server" templatefile="~/Templates/Desktop/DetailControl.ascx">
	<wilson:contentregion id="Title" runat="server">
		Pay&nbsp;Phone&nbsp;To&nbsp;Phone
	</wilson:contentregion>
	<wilson:contentregion id="Buttons" runat="server">
		<table id="ButtonsInfo" runat="server">
			<tr>
				<td>
					<asp:Button id="btnSave" tabIndex="201" runat="server" CssClass="Button" CausesValidation="True" Text="Send"></asp:Button>
					<asp:Button id="btnReset" tabIndex="202" runat="server" CssClass="Button" CausesValidation="False" Text="Reset"></asp:Button>
				</td>
			</tr>
		</table>
	</wilson:contentregion>

		<table>
			<tr>
				<td valign="top"><b>From&nbsp;Meta&nbsp;Partner&nbsp;Phone:</b></td>
				<td valign="top">
					<asp:TextBox id="ddlFromMetaPartnerPhoneID" tabIndex="3" runat="server" maxLength="40" Width="100">59170811167</asp:TextBox>
				</td>
			</tr>
			<tr>
				<td valign="top"><b>To&nbsp;Meta&nbsp;Partner&nbsp;Phone:</b></td>
				<td valign="top">
					<asp:TextBox id="ddlToMetaPartnerPhoneID" tabIndex="3" runat="server" maxLength="40" Width="100">59170667179</asp:TextBox>
				</td>
			</tr>
			<tr>
				<td valign="top"><b>Amount (Bs):</b></td>
				<td valign="top">
					<asp:TextBox id="txtBalance" tabIndex="4" runat="server" maxLength="10" Width="40">0.8</asp:TextBox>
					<asp:RangeValidator id="valBalance" ControlToValidate="txtBalance" EnableClientScript="False" Display="Dynamic" Runat="server" Type="Currency" MinimumValue="0.00" MaximumValue="1000000.00" ErrorMessage="Must be a valid value from 0.00 to 1000000.00." ></asp:RangeValidator>
					<asp:RequiredFieldValidator id="valBalanceRequired" ControlToValidate="txtBalance" EnableClientScript="False" Display="Dynamic" Runat="server" ErrorMessage="Please enter a valid value from 0.00 to 1000000.00." ></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td colspan=2 valign="top">
					<asp:Literal id="txtStatus" runat="server"></asp:Literal>
				</td>
			</tr>
		</table>
</wilson:masterpage>