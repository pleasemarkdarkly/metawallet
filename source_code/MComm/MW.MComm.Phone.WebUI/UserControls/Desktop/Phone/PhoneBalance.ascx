<%@ Register TagPrefix="Wilson" Namespace="Wilson.MasterPages" Assembly="WilsonMasterPages" %>
<%@ Control Language="c#" EnableViewState="false" AutoEventWireup="false" CodeFile ="PhoneBalance.ascx.cs" Inherits="MW.MComm.Phone.WebUI.UserControls.Desktop.Phone.PhoneBalance" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="MODC" Namespace="MW.MComm.Phone.WebUI.Controls"%>
<wilson:masterpage id="Masterpage" runat="server" templatefile="~/Templates/Desktop/DetailControl.ascx">
	<wilson:contentregion id="Title" runat="server">
		Phone&nbsp;Operations
	</wilson:contentregion>
	<wilson:contentregion id="Buttons" runat="server">
		<table id="ButtonsInfo" runat="server">
			<tr>
				<td>
					<asp:Button id="btnSave" tabIndex="201" runat="server" CssClass="Button" CausesValidation="False" Text="Balance"></asp:Button>
					<asp:Button id="btnCredit" tabIndex="201" runat="server" CssClass="Button" CausesValidation="True" Text="Credit"></asp:Button>
					<asp:Button id="btnDebit" tabIndex="202" runat="server" CssClass="Button" CausesValidation="True" Text="Debit"></asp:Button>
					<asp:Button id="btnTariff" tabIndex="202" runat="server" CssClass="Button" CausesValidation="False" Text="Tariff"></asp:Button>
				</td>
			</tr>
		</table>
	</wilson:contentregion>

		<table>
			<tr>
				<td valign="top"><b>Meta&nbsp;Partner&nbsp;Phone:</b></td>
				<td valign="top">
					<asp:TextBox id="ddlFromMetaPartnerPhoneID" tabIndex="3" runat="server" maxLength="40" Width="100">59170811167</asp:TextBox>
				</td>
			</tr>
			<tr>
				<td valign="top"><b>Amount (Bs):</b></td>
				<td valign="top">
					<asp:TextBox id="txtBalance" tabIndex="4" runat="server" maxLength="10" Width="40"></asp:TextBox>
					<asp:RangeValidator id="valBalance" ControlToValidate="txtBalance" EnableClientScript="False" Display="Dynamic" Runat="server" Type="Currency" MinimumValue="0.01" MaximumValue="10.00" ErrorMessage="Must be a valid Bolivianos amount from 0.01 to 10.00." ></asp:RangeValidator>
					<asp:RequiredFieldValidator id="valBalanceRequired" ControlToValidate="txtBalance" EnableClientScript="False" Display="Dynamic" Runat="server" ErrorMessage="Please enter a valid Bolivianos amount from 0.01 to 10.00." ></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td colspan=2 valign="top">
					<asp:Literal id="txtStatus" runat="server"></asp:Literal>
				</td>
			</tr>
		</table>
</wilson:masterpage>