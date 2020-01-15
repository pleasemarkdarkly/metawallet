
<!-- copyright
Meta Wallet, Inc (c) 2007 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2007, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
/copyright -->
<%@ Register TagPrefix="Wilson" Namespace="Wilson.MasterPages" Assembly="WilsonMasterPages" %>
<%@ Control Language="c#" AutoEventWireup="false" CodeFile ="SearchPaymentTransactionLogData.ascx.cs" Inherits="MW.MComm.Admin.WebUI.UserControls.Desktop.Payments.SearchPaymentTransactionLogData" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="MOD" TagName="EditPaymentTransactionLog" SRC="~/UserControls/Desktop/Payments/EditPaymentTransactionLog.ascx" %>
<%@ Register TagPrefix="MOD" TagName="WorkingPaymentTransactionLogData" SRC="~/UserControls/Desktop/Payments/WorkingPaymentTransactionLogData.ascx" %>
<%@ Register TagPrefix="MOD" TagName="ListPager" SRC="~/UserControls/Desktop/Utility/ListPager.ascx" %>
<wilson:masterpage id="Masterpage" runat="server" templatefile="~/Templates/Desktop/PaginatedSearchControl.ascx">
	<wilson:contentregion id="Title" runat="server">
		<asp:Label id="lblTitle" CssClass="subtitle" Runat="server">Payment&nbsp;Transaction&nbsp;Log Search</asp:Label>
	</wilson:contentregion>
	<wilson:contentregion id="Criteria" runat="server">
	<asp:Panel ID="pnlCriteriaForm" runat="server" DefaultButton="btnSearch">
		<table>
			<tr>
				<td><span class="FormLabelOptional">Transaction&nbsp;Type:</span></td>
				<td>
					<asp:DropDownList id="ddlTransactionTypeCode" tabIndex="1" runat="server" CssClass="FormNormal"></asp:DropDownList>
				</td>
			</tr>
			<tr>
				<td><span class="FormLabelOptional">Transaction&nbsp;Status:</span></td>
				<td>
					<asp:DropDownList id="ddlTransactionStatusCode" tabIndex="2" runat="server" CssClass="FormNormal"></asp:DropDownList>
				</td>
			</tr>
			<tr>
				<td><span class="FormLabelOptional">Last&nbsp;Modified&nbsp;Date Start:</span></td>
				<td>
					<asp:TextBox id="txtLastModifiedDateStart" tabIndex="3" CssClass="FormNormal" Runat="server" MaxLength="200" Width="200"></asp:TextBox>&nbsp;<asp:Button id="btnLastModifiedDateStartCalendar" tabIndex="4" runat="server" CssClass="Button" CausesValidation="False" Text="Calendar"></asp:Button>
					<asp:RangeValidator id="valLastModifiedDateStart" ControlToValidate="txtLastModifiedDateStart" EnableClientScript="False" Display="Dynamic" Runat="server" Type="Date" MinimumValue="1900/1/1" MaximumValue="2100/1/1" ErrorMessage="Must be a valid date from 1/1/1900 to 1/1/2100." ></asp:RangeValidator>
					<asp:Calendar id="calLastModifiedDateStart" runat="server" tabIndex="5" Visible="false" CssClass="FormNormal" SelectionMode="DayWeekMonth"><TodayDayStyle BorderStyle="Dotted" BorderWidth="1" BorderColor="#000000" /><SelectedDayStyle BackColor="#eeffee" ForeColor="#000000" /></asp:Calendar>
				</td>
			</tr>
			<tr>
				<td><span class="FormLabelOptional">Last&nbsp;Modified&nbsp;Date End:</span></td>
				<td>
					<asp:TextBox id="txtLastModifiedDateEnd" tabIndex="6" CssClass="FormNormal" Runat="server" MaxLength="200" Width="200"></asp:TextBox>&nbsp;<asp:Button id="btnLastModifiedDateEndCalendar" tabIndex="7" runat="server" CssClass="Button" CausesValidation="False" Text="Calendar"></asp:Button>
					<asp:RangeValidator id="valLastModifiedDateEnd" ControlToValidate="txtLastModifiedDateEnd" EnableClientScript="False" Display="Dynamic" Runat="server" Type="Date" MinimumValue="1900/1/1" MaximumValue="2100/1/1" ErrorMessage="Must be a valid date from 1/1/1900 to 1/1/2100." ></asp:RangeValidator>
					<asp:Calendar id="calLastModifiedDateEnd" runat="server" tabIndex="8" Visible="false" CssClass="FormNormal" SelectionMode="DayWeekMonth"><TodayDayStyle BorderStyle="Dotted" BorderWidth="1" BorderColor="#000000" /><SelectedDayStyle BackColor="#eeffee" ForeColor="#000000" /></asp:Calendar>
				</td>
			</tr>
		</table>
		</asp:Panel>
	</wilson:contentregion>
	<wilson:contentregion id="SearchResultsTitle" runat="server">
		<asp:Label id="lblSearchResultsTitle" CssClass="subtitle" Runat="server">Search Results</asp:Label>
	</wilson:contentregion>
	<wilson:contentregion id="Pager1" runat="server">
		<MOD:ListPager id="firstPager" runat="server"></MOD:ListPager>
	</wilson:contentregion>
	<wilson:contentregion id="Pager2" runat="server">
		<MOD:ListPager id="secondPager" runat="server"></MOD:ListPager>
	</wilson:contentregion>
	<wilson:contentregion id="Buttons" runat="server">
		<table>
			<tr>
				<td>
					<asp:Button id="btnSearch" tabIndex="10" runat="server" CssClass="Button" CausesValidation="True" Text="Search"></asp:Button>
					<asp:Button id="btnClear" tabIndex="11" runat="server" CssClass="Button" CausesValidation="False" Text="Clear"></asp:Button>
					<asp:Button id="btnNew" tabIndex="12" runat="server" CssClass="Button" CausesValidation="False" Text="New Payment&nbsp;Transaction&nbsp;Log"></asp:Button>
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
			<asp:TemplateColumn HeaderText="Transaction&nbsp;Type&nbsp;Code" SortExpression="TransactionTypeCode" Visible="false">
				<ItemTemplate>
					<asp:Label CssClass="FormNormal" ID="lblTransactionTypeCode" Runat="server"></asp:Label>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Transaction&nbsp;Status&nbsp;Code" SortExpression="TransactionStatusCode" Visible="false">
				<ItemTemplate>
					<asp:Label CssClass="FormNormal" ID="lblTransactionStatusCode" Runat="server"></asp:Label>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Transaction&nbsp;Amount" SortExpression="TransactionAmount" Visible="false">
				<ItemTemplate>
					<asp:Label CssClass="FormNormal" ID="lblTransactionAmount" Runat="server"></asp:Label>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Response&nbsp;Code" SortExpression="ResponseCode" Visible="false">
				<ItemTemplate>
					<asp:Label CssClass="FormNormal" ID="lblResponseCode" Runat="server"></asp:Label>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Transaction&nbsp;Code" SortExpression="TransactionCode" Visible="false">
				<ItemTemplate>
					<asp:Label CssClass="FormNormal" ID="lblTransactionCode" Runat="server"></asp:Label>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Transaction&nbsp;Message" SortExpression="TransactionMessage" Visible="false">
				<ItemTemplate>
					<asp:Label CssClass="FormNormal" ID="lblTransactionMessage" Runat="server"></asp:Label>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Balance" SortExpression="Balance" Visible="false">
				<ItemTemplate>
					<asp:Label CssClass="FormNormal" ID="lblBalance" Runat="server"></asp:Label>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Transaction&nbsp;Type&nbsp;Name" SortExpression="TransactionTypeName">
				<ItemTemplate>
					<asp:Label CssClass="FormNormal" ID="lblTransactionTypeName" Runat="server"></asp:Label>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Transaction&nbsp;Status&nbsp;Name" SortExpression="TransactionStatusName">
				<ItemTemplate>
					<asp:Label CssClass="FormNormal" ID="lblTransactionStatusName" Runat="server"></asp:Label>
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
					<asp:LinkButton CssClass="FormNormal" ID="lnkEdit" TabIndex="100" Width="20" Runat="server" CausesValidation="false" CommandName="Edit" CommandArgument='<%#((MW.MComm.WalletSolution.BLL.Payments.PaymentTransactionLog)Container.DataItem).GetHashCode()%>'>Details</asp:LinkButton>
					<asp:HyperLink CssClass="FormNormal" ID="lnkEditOut" TabIndex="101" Width="20" Runat="server">Details</asp:HyperLink>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="">
				<ItemTemplate>
					<asp:LinkButton CssClass="FormNormal" ID="lnkDelete" TabIndex="102" Width="20" Runat="server" CausesValidation="false" CommandName="Delete" CommandArgument='<%#((MW.MComm.WalletSolution.BLL.Payments.PaymentTransactionLog)Container.DataItem).GetHashCode()%>'>Delete</asp:LinkButton>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="">
				<ItemTemplate>
					<asp:LinkButton CssClass="FormNormal" ID="lnkAdd" TabIndex="103" Width="20" Runat="server" CausesValidation="false" CommandName="Add" CommandArgument='<%#((MW.MComm.WalletSolution.BLL.Payments.PaymentTransactionLog)Container.DataItem).GetHashCode()%>'>Add</asp:LinkButton>
				</ItemTemplate>
			</asp:TemplateColumn>
		</Columns>
	</asp:DataGrid>
	<wilson:contentregion id="Detail" runat="server">
		<MOD:EditPaymentTransactionLog id="editPaymentTransactionLog" AccessMode="Add" DisplayMode="SingleView" RequiresAuthentication="true" WorkflowMode="Internal" UseWorkingSets="true" runat="server"></MOD:EditPaymentTransactionLog>
	</wilson:contentregion>
	<wilson:contentregion id="WorkingSet" runat="server">
		<MOD:WorkingPaymentTransactionLogData id="workingPaymentTransactionLogData" AccessMode="Edit" DisplayMode="SingleView" RequiresAuthentication="true" WorkflowMode="External" runat="server"></MOD:WorkingPaymentTransactionLogData>
	</wilson:contentregion>
</wilson:masterpage>