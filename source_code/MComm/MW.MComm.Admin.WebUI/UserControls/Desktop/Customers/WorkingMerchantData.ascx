
<!-- copyright
Meta Wallet, Inc (c) 2007 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2007, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
/copyright -->
<%@ Register TagPrefix="Wilson" Namespace="Wilson.MasterPages" Assembly="WilsonMasterPages" %>
<%@ Control Language="c#" AutoEventWireup="false" CodeFile ="WorkingMerchantData.ascx.cs" Inherits="MW.MComm.Admin.WebUI.UserControls.Desktop.Customers.WorkingMerchantData" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<wilson:masterpage id="Masterpage" runat="server" templatefile="~/Templates/Desktop/ListControl.ascx">
	<wilson:contentregion id="Title" runat="server">
		<asp:Label id="lblTitle" CssClass="subtitle" Runat="server">Merchant Working Set</asp:Label>
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
			<asp:TemplateColumn HeaderText="Service&nbsp;Charges" SortExpression="ServiceCharges" Visible="false">
				<ItemTemplate>
					<asp:Label CssClass="FormNormal" ID="lblServiceCharges" Runat="server"></asp:Label>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Meta&nbsp;Partner&nbsp;Sub&nbsp;Type&nbsp;Code" SortExpression="MetaPartnerSubTypeCode" Visible="false">
				<ItemTemplate>
					<asp:Label CssClass="FormNormal" ID="lblMetaPartnerSubTypeCode" Runat="server"></asp:Label>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Locale&nbsp;Code" SortExpression="LocaleCode" Visible="false">
				<ItemTemplate>
					<asp:Label CssClass="FormNormal" ID="lblLocaleCode" Runat="server"></asp:Label>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Currency&nbsp;Code" SortExpression="CurrencyCode" Visible="false">
				<ItemTemplate>
					<asp:Label CssClass="FormNormal" ID="lblCurrencyCode" Runat="server"></asp:Label>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Date&nbsp;Format&nbsp;Code" SortExpression="DateFormatCode">
				<ItemTemplate>
					<asp:Label CssClass="FormNormal" ID="lblDateFormatCode" Runat="server"></asp:Label>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Tax&nbsp;Code" SortExpression="TaxCode" Visible="false">
				<ItemTemplate>
					<asp:Label CssClass="FormNormal" ID="lblTaxCode" Runat="server"></asp:Label>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Is&nbsp;Active" SortExpression="IsActive">
				<ItemTemplate>
					<asp:Label CssClass="FormNormal" ID="lblIsActive" Runat="server"></asp:Label>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Meta&nbsp;Partner&nbsp;Name" SortExpression="MetaPartnerName">
				<ItemTemplate>
					<asp:Label CssClass="FormNormal" ID="lblMetaPartnerName" Runat="server"></asp:Label>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Picture&nbsp;Image&nbsp;URL" SortExpression="PictureImageURL">
				<ItemTemplate>
					<asp:Image CssClass="FormNormal" ID="lblPictureImageURL" Runat="server" Width="50" Height="50"></asp:Image>&nbsp;<asp:HyperLink CssClass="FormNormal" ID="lnkPictureImageURL" Runat="server" Target="PictureImageURL">View</asp:HyperLink>
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
					<asp:HyperLink CssClass="FormNormal" ID="lnkEditOut" TabIndex="101" Width="20" Runat="server">Details</asp:HyperLink>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="">
				<ItemTemplate>
					<asp:LinkButton CssClass="FormNormal" ID="lnkDelete" TabIndex="102" Width="20" Runat="server" CausesValidation="false" CommandName="Delete" CommandArgument='<%#((MW.MComm.WalletSolution.BLL.Customers.Merchant)Container.DataItem).GetHashCode()%>'>Delete</asp:LinkButton>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="">
				<ItemTemplate>
					<asp:LinkButton CssClass="FormNormal" ID="lnkSelect" TabIndex="104" Width="20" Runat="server" CausesValidation="false" CommandName="Select" CommandArgument='<%#((MW.MComm.WalletSolution.BLL.Customers.Merchant)Container.DataItem).GetHashCode()%>'>Select</asp:LinkButton>
				</ItemTemplate>
			</asp:TemplateColumn>
		</Columns>
	</asp:DataGrid>
</wilson:masterpage>