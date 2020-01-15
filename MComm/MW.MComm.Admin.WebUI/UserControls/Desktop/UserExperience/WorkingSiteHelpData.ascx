
<!-- copyright
Meta Wallet, Inc (c) 2007 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2007, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
/copyright -->
<%@ Register TagPrefix="Wilson" Namespace="Wilson.MasterPages" Assembly="WilsonMasterPages" %>
<%@ Control Language="c#" AutoEventWireup="false" CodeFile ="WorkingSiteHelpData.ascx.cs" Inherits="MW.MComm.Admin.WebUI.UserControls.Desktop.UserExperience.WorkingSiteHelpData" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<wilson:masterpage id="Masterpage" runat="server" templatefile="~/Templates/Desktop/ListControl.ascx">
	<wilson:contentregion id="Title" runat="server">
		<asp:Label id="lblTitle" CssClass="subtitle" Runat="server">Site&nbsp;Help Working Set</asp:Label>
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
			<asp:TemplateColumn HeaderText="Locale&nbsp;Code" SortExpression="LocaleCode">
				<ItemTemplate>
					<asp:Label CssClass="FormNormal" ID="lblLocaleCode" Runat="server"></asp:Label>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Site&nbsp;Help&nbsp;Name" SortExpression="SiteHelpName">
				<ItemTemplate>
					<asp:Label CssClass="FormNormal" ID="lblSiteHelpName" Runat="server"></asp:Label>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Site&nbsp;Help&nbsp;Text" SortExpression="SiteHelpText" Visible="false">
				<ItemTemplate>
					<asp:Label CssClass="FormNormal" ID="lblSiteHelpText" Runat="server"></asp:Label>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Site&nbsp;Help&nbsp;Image&nbsp;URL" SortExpression="SiteHelpImageURL">
				<ItemTemplate>
					<asp:Image CssClass="FormNormal" ID="lblSiteHelpImageURL" Runat="server" Width="50" Height="50"></asp:Image>&nbsp;<asp:HyperLink CssClass="FormNormal" ID="lnkSiteHelpImageURL" Runat="server" Target="SiteHelpImageURL">View</asp:HyperLink>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Site&nbsp;Help&nbsp;Group&nbsp;Code" SortExpression="SiteHelpGroupCode" Visible="false">
				<ItemTemplate>
					<asp:Label CssClass="FormNormal" ID="lblSiteHelpGroupCode" Runat="server"></asp:Label>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Site&nbsp;Help&nbsp;Definition&nbsp;Code" SortExpression="SiteHelpDefinitionCode">
				<ItemTemplate>
					<asp:Label CssClass="FormNormal" ID="lblSiteHelpDefinitionCode" Runat="server"></asp:Label>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Site&nbsp;Help&nbsp;Definition&nbsp;Name" SortExpression="SiteHelpDefinitionName">
				<ItemTemplate>
					<asp:Label CssClass="FormNormal" ID="lblSiteHelpDefinitionName" Runat="server"></asp:Label>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Locale&nbsp;Name" SortExpression="LocaleName">
				<ItemTemplate>
					<asp:Label CssClass="FormNormal" ID="lblLocaleName" Runat="server"></asp:Label>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Site&nbsp;Help&nbsp;Group&nbsp;Name" SortExpression="SiteHelpGroupName">
				<ItemTemplate>
					<asp:Label CssClass="FormNormal" ID="lblSiteHelpGroupName" Runat="server"></asp:Label>
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
					<asp:LinkButton CssClass="FormNormal" ID="lnkDelete" TabIndex="102" Width="20" Runat="server" CausesValidation="false" CommandName="Delete" CommandArgument='<%#((MW.MComm.WalletSolution.BLL.UserExperience.SiteHelp)Container.DataItem).GetHashCode()%>'>Delete</asp:LinkButton>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="">
				<ItemTemplate>
					<asp:LinkButton CssClass="FormNormal" ID="lnkSelect" TabIndex="104" Width="20" Runat="server" CausesValidation="false" CommandName="Select" CommandArgument='<%#((MW.MComm.WalletSolution.BLL.UserExperience.SiteHelp)Container.DataItem).GetHashCode()%>'>Select</asp:LinkButton>
				</ItemTemplate>
			</asp:TemplateColumn>
		</Columns>
	</asp:DataGrid>
</wilson:masterpage>