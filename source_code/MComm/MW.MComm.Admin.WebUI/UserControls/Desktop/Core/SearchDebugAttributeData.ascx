
<!-- copyright
Meta Wallet, Inc (c) 2007 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2007, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
/copyright -->
<%@ Register TagPrefix="Wilson" Namespace="Wilson.MasterPages" Assembly="WilsonMasterPages" %>
<%@ Control Language="c#" AutoEventWireup="false" CodeFile ="SearchDebugAttributeData.ascx.cs" Inherits="MW.MComm.Admin.WebUI.UserControls.Desktop.Core.SearchDebugAttributeData" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="MOD" TagName="EditDebugAttribute" SRC="~/UserControls/Desktop/Core/EditDebugAttribute.ascx" %>
<%@ Register TagPrefix="MOD" TagName="WorkingDebugAttributeData" SRC="~/UserControls/Desktop/Core/WorkingDebugAttributeData.ascx" %>
<%@ Register TagPrefix="MOD" TagName="ListPager" SRC="~/UserControls/Desktop/Utility/ListPager.ascx" %>
<wilson:masterpage id="Masterpage" runat="server" templatefile="~/Templates/Desktop/PaginatedSearchControl.ascx">
	<wilson:contentregion id="Title" runat="server">
		<asp:Label id="lblTitle" CssClass="subtitle" Runat="server">Debug&nbsp;Attribute Search</asp:Label>
	</wilson:contentregion>
	<wilson:contentregion id="Criteria" runat="server">
	<asp:Panel ID="pnlCriteriaForm" runat="server" DefaultButton="btnSearch">
		<table>
			<tr>
				<td><span class="FormLabelOptional">Attribute&nbsp;Name:</span></td>
				<td>
					<asp:TextBox id="txtAttributeName" tabIndex="1" CssClass="FormNormal" Runat="server" MaxLength="200" Width="200"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td><span class="FormLabelOptional">Attribute&nbsp;Type:</span></td>
				<td>
					<asp:DropDownList id="ddlAttributeTypeCode" tabIndex="2" runat="server" CssClass="FormNormal"></asp:DropDownList>
				</td>
			</tr>
			<tr>
				<td><span class="FormLabelOptional">Data&nbsp;Type:</span></td>
				<td>
					<asp:DropDownList id="ddlDataTypeCode" tabIndex="3" runat="server" CssClass="FormNormal"></asp:DropDownList>
				</td>
			</tr>
			<tr>
				<td><span class="FormLabelOptional">Last&nbsp;Modified&nbsp;Date Start:</span></td>
				<td>
					<asp:TextBox id="txtLastModifiedDateStart" tabIndex="4" CssClass="FormNormal" Runat="server" MaxLength="200" Width="200"></asp:TextBox>&nbsp;<asp:Button id="btnLastModifiedDateStartCalendar" tabIndex="5" runat="server" CssClass="Button" CausesValidation="False" Text="Calendar"></asp:Button>
					<asp:RangeValidator id="valLastModifiedDateStart" ControlToValidate="txtLastModifiedDateStart" EnableClientScript="False" Display="Dynamic" Runat="server" Type="Date" MinimumValue="1900/1/1" MaximumValue="2100/1/1" ErrorMessage="Must be a valid date from 1/1/1900 to 1/1/2100." ></asp:RangeValidator>
					<asp:Calendar id="calLastModifiedDateStart" runat="server" tabIndex="6" Visible="false" CssClass="FormNormal" SelectionMode="DayWeekMonth"><TodayDayStyle BorderStyle="Dotted" BorderWidth="1" BorderColor="#000000" /><SelectedDayStyle BackColor="#eeffee" ForeColor="#000000" /></asp:Calendar>
				</td>
			</tr>
			<tr>
				<td><span class="FormLabelOptional">Last&nbsp;Modified&nbsp;Date End:</span></td>
				<td>
					<asp:TextBox id="txtLastModifiedDateEnd" tabIndex="7" CssClass="FormNormal" Runat="server" MaxLength="200" Width="200"></asp:TextBox>&nbsp;<asp:Button id="btnLastModifiedDateEndCalendar" tabIndex="8" runat="server" CssClass="Button" CausesValidation="False" Text="Calendar"></asp:Button>
					<asp:RangeValidator id="valLastModifiedDateEnd" ControlToValidate="txtLastModifiedDateEnd" EnableClientScript="False" Display="Dynamic" Runat="server" Type="Date" MinimumValue="1900/1/1" MaximumValue="2100/1/1" ErrorMessage="Must be a valid date from 1/1/1900 to 1/1/2100." ></asp:RangeValidator>
					<asp:Calendar id="calLastModifiedDateEnd" runat="server" tabIndex="9" Visible="false" CssClass="FormNormal" SelectionMode="DayWeekMonth"><TodayDayStyle BorderStyle="Dotted" BorderWidth="1" BorderColor="#000000" /><SelectedDayStyle BackColor="#eeffee" ForeColor="#000000" /></asp:Calendar>
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
					<asp:Button id="btnNew" tabIndex="12" runat="server" CssClass="Button" CausesValidation="False" Text="New Debug&nbsp;Attribute"></asp:Button>
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
			<asp:TemplateColumn HeaderText="Attribute&nbsp;Code" SortExpression="AttributeCode" Visible="false">
				<ItemTemplate>
					<asp:Label CssClass="FormNormal" ID="lblAttributeCode" Runat="server"></asp:Label>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Attribute&nbsp;Name" SortExpression="AttributeName">
				<ItemTemplate>
					<asp:Label CssClass="FormNormal" ID="lblAttributeName" Runat="server"></asp:Label>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Attribute&nbsp;Type&nbsp;Code" SortExpression="AttributeTypeCode" Visible="false">
				<ItemTemplate>
					<asp:Label CssClass="FormNormal" ID="lblAttributeTypeCode" Runat="server"></asp:Label>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Data&nbsp;Type&nbsp;Code" SortExpression="DataTypeCode" Visible="false">
				<ItemTemplate>
					<asp:Label CssClass="FormNormal" ID="lblDataTypeCode" Runat="server"></asp:Label>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Description" SortExpression="Description" Visible="false">
				<ItemTemplate>
					<asp:Label CssClass="FormNormal" ID="lblDescription" Runat="server"></asp:Label>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Is&nbsp;Active" SortExpression="IsActive">
				<ItemTemplate>
					<asp:Label CssClass="FormNormal" ID="lblIsActive" Runat="server"></asp:Label>
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
					<asp:LinkButton CssClass="FormNormal" ID="lnkEdit" TabIndex="100" Width="20" Runat="server" CausesValidation="false" CommandName="Edit" CommandArgument='<%#((MW.MComm.WalletSolution.BLL.Core.DebugAttribute)Container.DataItem).GetHashCode()%>'>Details</asp:LinkButton>
					<asp:HyperLink CssClass="FormNormal" ID="lnkEditOut" TabIndex="101" Width="20" Runat="server">Details</asp:HyperLink>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="">
				<ItemTemplate>
					<asp:LinkButton CssClass="FormNormal" ID="lnkDelete" TabIndex="102" Width="20" Runat="server" CausesValidation="false" CommandName="Delete" CommandArgument='<%#((MW.MComm.WalletSolution.BLL.Core.DebugAttribute)Container.DataItem).GetHashCode()%>'>Delete</asp:LinkButton>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="">
				<ItemTemplate>
					<asp:LinkButton CssClass="FormNormal" ID="lnkAdd" TabIndex="103" Width="20" Runat="server" CausesValidation="false" CommandName="Add" CommandArgument='<%#((MW.MComm.WalletSolution.BLL.Core.DebugAttribute)Container.DataItem).GetHashCode()%>'>Add</asp:LinkButton>
				</ItemTemplate>
			</asp:TemplateColumn>
		</Columns>
	</asp:DataGrid>
	<wilson:contentregion id="Detail" runat="server">
		<MOD:EditDebugAttribute id="editDebugAttribute" AccessMode="Add" DisplayMode="SingleView" RequiresAuthentication="true" WorkflowMode="Internal" UseWorkingSets="true" runat="server"></MOD:EditDebugAttribute>
	</wilson:contentregion>
	<wilson:contentregion id="WorkingSet" runat="server">
		<MOD:WorkingDebugAttributeData id="workingDebugAttributeData" AccessMode="Edit" DisplayMode="SingleView" RequiresAuthentication="true" WorkflowMode="External" runat="server"></MOD:WorkingDebugAttributeData>
	</wilson:contentregion>
</wilson:masterpage>