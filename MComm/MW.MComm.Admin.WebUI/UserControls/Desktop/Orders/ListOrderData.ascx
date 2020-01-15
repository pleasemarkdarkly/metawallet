
<!-- copyright
Meta Wallet, Inc (c) 2007 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2007, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
/copyright -->
<%@ Register TagPrefix="Wilson" Namespace="Wilson.MasterPages" Assembly="WilsonMasterPages" %>
<%@ Control Language="c#" AutoEventWireup="false" CodeFile ="ListOrderData.ascx.cs" Inherits="MW.MComm.Admin.WebUI.UserControls.Desktop.Orders.ListOrderData" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="MOD" TagName="EditOrder" SRC="~/UserControls/Desktop/Orders/EditOrder.ascx" %>
<wilson:masterpage id="Masterpage" runat="server" templatefile="~/Templates/Desktop/ListControl.ascx">
	<wilson:contentregion id="Title" runat="server">
		<asp:Label id="lblTitle" CssClass="subtitle" Runat="server">Order List</asp:Label>
	</wilson:contentregion>
	<wilson:contentregion id="Buttons" runat="server">
		<table>
			<tr>
				<td>
					<asp:Button id="btnNew" tabIndex="12" runat="server" CssClass="Button" CausesValidation="False" Text="New Order"></asp:Button>
				</td>
			</tr>
		</table>
	</wilson:contentregion>

	<asp:DataGrid id="dgPrimaryList" Runat="server" AutoGenerateColumns="False" GridLines="None" AllowSorting="True" HeaderStyle-CssClass="tableHeader" SelectedItemStyle-CssClass="selTableCell" ItemStyle-CssClass="tableCell" AlternatingItemStyle-CssClass="altTableCell" OnItemCommand="dgPrimaryList_ItemCommand">
		<HeaderStyle></HeaderStyle>
		<ItemStyle></ItemStyle>
		<AlternatingItemStyle></AlternatingItemStyle>
		<FooterStyle></FooterStyle>
		<Columns>
			<asp:TemplateColumn HeaderText="Primary Name" SortExpression="PrimarySortColumn">
				<ItemTemplate>
					<asp:Label CssClass="FormNormal" ID="lblPrimaryName" Runat="server"></asp:Label>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Order&nbsp;Description" SortExpression="OrderDescription" Visible="false">
				<ItemTemplate>
					<asp:Label CssClass="FormNormal" ID="lblOrderDescription" Runat="server"></asp:Label>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Order&nbsp;Amount" SortExpression="OrderAmount" Visible="false">
				<ItemTemplate>
					<asp:Label CssClass="FormNormal" ID="lblOrderAmount" Runat="server"></asp:Label>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Order&nbsp;Subtotal" SortExpression="OrderSubtotal" Visible="false">
				<ItemTemplate>
					<asp:Label CssClass="FormNormal" ID="lblOrderSubtotal" Runat="server"></asp:Label>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Order&nbsp;Tax" SortExpression="OrderTax" Visible="false">
				<ItemTemplate>
					<asp:Label CssClass="FormNormal" ID="lblOrderTax" Runat="server"></asp:Label>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Order&nbsp;Service&nbsp;Charge" SortExpression="OrderServiceCharge" Visible="false">
				<ItemTemplate>
					<asp:Label CssClass="FormNormal" ID="lblOrderServiceCharge" Runat="server"></asp:Label>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Currency&nbsp;Code" SortExpression="CurrencyCode" Visible="false">
				<ItemTemplate>
					<asp:Label CssClass="FormNormal" ID="lblCurrencyCode" Runat="server"></asp:Label>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Order&nbsp;Status&nbsp;Code" SortExpression="OrderStatusCode" Visible="false">
				<ItemTemplate>
					<asp:Label CssClass="FormNormal" ID="lblOrderStatusCode" Runat="server"></asp:Label>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Order&nbsp;Status&nbsp;Message" SortExpression="OrderStatusMessage" Visible="false">
				<ItemTemplate>
					<asp:Label CssClass="FormNormal" ID="lblOrderStatusMessage" Runat="server"></asp:Label>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Meta&nbsp;Partner&nbsp;Name" SortExpression="MetaPartnerName">
				<ItemTemplate>
					<asp:Label CssClass="FormNormal" ID="lblMetaPartnerName" Runat="server"></asp:Label>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Date&nbsp;Format&nbsp;Code" SortExpression="DateFormatCode">
				<ItemTemplate>
					<asp:Label CssClass="FormNormal" ID="lblDateFormatCode" Runat="server"></asp:Label>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Account&nbsp;Name" SortExpression="AccountName">
				<ItemTemplate>
					<asp:Label CssClass="FormNormal" ID="lblAccountName" Runat="server"></asp:Label>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Currency&nbsp;Name" SortExpression="CurrencyName">
				<ItemTemplate>
					<asp:Label CssClass="FormNormal" ID="lblCurrencyName" Runat="server"></asp:Label>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Order&nbsp;Status&nbsp;Name" SortExpression="OrderStatusName">
				<ItemTemplate>
					<asp:Label CssClass="FormNormal" ID="lblOrderStatusName" Runat="server"></asp:Label>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Created&nbsp;Date" SortExpression="CreatedDate" Visible="false">
				<ItemTemplate>
					<asp:Label CssClass="FormNormal" ID="lblCreatedDate" Runat="server"></asp:Label>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Last&nbsp;Modified&nbsp;Date" SortExpression="LastModifiedDate">
				<ItemTemplate>
					<asp:Label CssClass="FormNormal" ID="lblLastModifiedDate" Runat="server"></asp:Label>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="">
				<ItemTemplate>
					<asp:LinkButton CssClass="FormNormal" ID="lnkEdit" TabIndex="100" Width="20" Runat="server" CausesValidation="false" CommandName="Edit" CommandArgument='<%#((MW.MComm.WalletSolution.BLL.Orders.Order)Container.DataItem).GetHashCode()%>'>Details</asp:LinkButton>
					<asp:HyperLink CssClass="FormNormal" ID="lnkEditOut" TabIndex="101" Width="20" Runat="server">Details</asp:HyperLink>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="">
				<ItemTemplate>
					<asp:LinkButton CssClass="FormNormal" ID="lnkDelete" TabIndex="102" Width="20" Runat="server" CausesValidation="false" CommandName="Delete" CommandArgument='<%#((MW.MComm.WalletSolution.BLL.Orders.Order)Container.DataItem).GetHashCode()%>'>Delete</asp:LinkButton>
				</ItemTemplate>
			</asp:TemplateColumn>
		</Columns>
	</asp:DataGrid>
	<wilson:contentregion id="Detail" runat="server">
		<MOD:EditOrder id="editOrder" AccessMode="Add" DisplayMode="SingleView" RequiresAuthentication="true" WorkflowMode="Internal" UseWorkingSets="true" runat="server"></MOD:EditOrder>
	</wilson:contentregion>
</wilson:masterpage>