
<!-- copyright
Meta Wallet, Inc (c) 2007 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2007, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
/copyright -->
<%@ Register TagPrefix="Wilson" Namespace="Wilson.MasterPages" Assembly="WilsonMasterPages" %>
<%@ Control Language="c#" AutoEventWireup="false" CodeFile ="EditPaymentTransactionLog.ascx.cs" Inherits="MW.MComm.Admin.WebUI.UserControls.Desktop.Payments.EditPaymentTransactionLog" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="MOD" TagName="PageSectionLinks" Src="~/UserControls/Desktop/Utility/PageSectionLinks.ascx" %>
<%@ Register TagPrefix="MODC" Namespace="MW.MComm.Admin.WebUI.Controls"%>
<%@ Register TagPrefix="MOD" TagName="ListPaymentTransactionAttributeValueLogData" Src="~/UserControls/Desktop/Payments/ListPaymentTransactionAttributeValueLogData.ascx" %>
<wilson:masterpage id="Masterpage" runat="server" templatefile="~/Templates/Desktop/DetailControl.ascx">
	<wilson:contentregion id="Title" runat="server">
		<asp:Label id="lblTitle" CssClass="subtitle" Runat="server">Edit Payment&nbsp;Transaction&nbsp;Log</asp:Label>&nbsp;<asp:Label id="lblTitleMessage" CssClass="subtitle" Runat="server"></asp:Label>
	</wilson:contentregion>
	<wilson:contentregion id="ItemInfo" runat="server">
		<div class="IDSection" id="ItemInfoContent" runat="server">
		<table>
			<tr>
				<td>Payment&nbsp;Transaction&nbsp;Log&nbsp;ID:</td>
				<td>
					<span class="ID">
					<MODC:PropVal id="propPaymentTransactionLogID" runat="server" prop="PaymentTransactionLogItem.PaymentTransactionLogID" cssclass="ID"></MODC:PropVal>
					</span>
				</td>
			</tr>
		</table>
		</div>
	</wilson:contentregion>
	<wilson:contentregion id="DetailNavigation" runat="server">
		<div class="SectionLink" id="SectionLinkContent" runat="server">
		<MOD:PageSectionLinks id="sectionLinks" runat="server" CssClass="SectionLink" SelectedCssClass="selSectionLink" ValidationList="Basics,Additional_Info" SectionList="Basics,Additional_Info,Payment_Transaction_Attribute_Value_Logs"></MOD:PageSectionLinks>
		</div>
	</wilson:contentregion>
	<wilson:contentregion id="Buttons" runat="server">
		<table id="ButtonsInfo" runat="server">
			<tr>
				<td>
					<asp:Button id="btnSave" tabIndex="201" runat="server" CssClass="Button" CausesValidation="True" Text="Save"></asp:Button>
					<asp:Button id="btnDelete" tabIndex="201" runat="server" CssClass="Button" CausesValidation="False" Text="Delete"></asp:Button>
					<asp:Button id="btnReset" tabIndex="202" runat="server" CssClass="Button" CausesValidation="False" Text="Reset"></asp:Button>
					<asp:Button id="btnNew" tabIndex="203" runat="server" CssClass="Button" CausesValidation="False" Text="New"></asp:Button>
					<asp:Button id="btnBasics" tabIndex="205" runat="server" CssClass="Button" CausesValidation="True" Text="Basics"></asp:Button>
					<asp:Button id="btnPrevious" tabIndex="206" runat="server" CssClass="Button" CausesValidation="True" Visible="False" Text="< Previous"></asp:Button>
					<asp:Button id="btnNext" tabIndex="207" runat="server" CssClass="Button" CausesValidation="True" Text="Next >"></asp:Button>
				</td>
			</tr>
		</table>
	</wilson:contentregion>

	<MODC:PageSection id="Section_Basics" visible="false" runat="server">
		<table>
			<tr>
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblPaymentTransactionLogIDDisplay" runat="server">Payment&nbsp;Transaction&nbsp;Log&nbsp;ID:</asp:Label></span></td>
				<td valign="top">
					<asp:Label id="lblPaymentTransactionLogID" runat="server" CssClass="FormNormal"></asp:Label>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblPaymentIDDisplay" runat="server">Payment:</asp:Label></span></td>
				<td valign="top">
					<asp:DropDownList id="ddlPaymentID" tabIndex="2" runat="server" CssClass="FormNormal"></asp:DropDownList>
					<asp:Label id="lblPaymentIDWorkingSet" runat="server" CssClass="FormNormal"> (from Payment working set)</asp:Label>
					<a id="lnkPaymentIDWorkingSet" runat="server" onclick="javascript:return PromptToDiscardChanges();" class="FormNormal">search</a>
					<asp:CompareValidator id="valPaymentID" ControlToValidate="ddlPaymentID" EnableClientScript="False" Display="Dynamic" Runat="server" Type="String" ValueToCompare="0" Operator="NotEqual" ErrorMessage="Please select a value from the list." ></asp:CompareValidator>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblTransactionTypeCodeDisplay" runat="server">Transaction&nbsp;Type:</asp:Label></span></td>
				<td valign="top">
					<asp:DropDownList id="ddlTransactionTypeCode" tabIndex="3" runat="server" CssClass="FormNormal"></asp:DropDownList>
					<asp:CompareValidator id="valTransactionTypeCode" ControlToValidate="ddlTransactionTypeCode" EnableClientScript="False" Display="Dynamic" Runat="server" Type="String" ValueToCompare="0" Operator="NotEqual" ErrorMessage="Please select a value from the list." ></asp:CompareValidator>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblTransactionStatusCodeDisplay" runat="server">Transaction&nbsp;Status:</asp:Label></span></td>
				<td valign="top">
					<asp:DropDownList id="ddlTransactionStatusCode" tabIndex="4" runat="server" CssClass="FormNormal"></asp:DropDownList>
					<asp:CompareValidator id="valTransactionStatusCode" ControlToValidate="ddlTransactionStatusCode" EnableClientScript="False" Display="Dynamic" Runat="server" Type="String" ValueToCompare="0" Operator="NotEqual" ErrorMessage="Please select a value from the list." ></asp:CompareValidator>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblTransactionAmountDisplay" runat="server">Transaction&nbsp;Amount:</asp:Label></span></td>
				<td valign="top">
					<asp:TextBox id="txtTransactionAmount" tabIndex="5" runat="server" maxLength="40" Width="150" CssClass="FormNormal"></asp:TextBox>
					<asp:RangeValidator id="valTransactionAmount" ControlToValidate="txtTransactionAmount" EnableClientScript="False" Display="Dynamic" Runat="server" Type="Currency" MinimumValue="0.00" MaximumValue="1000000.00" ErrorMessage="Must be a valid value from 0.00 to 1000000.00." ></asp:RangeValidator>
					<asp:RequiredFieldValidator id="valTransactionAmountRequired" ControlToValidate="txtTransactionAmount" EnableClientScript="False" Display="Dynamic" Runat="server" ErrorMessage="Please enter a valid value from 0.00 to 1000000.00." ></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblBalanceDisplay" runat="server">Balance:</asp:Label></span></td>
				<td valign="top">
					<asp:TextBox id="txtBalance" tabIndex="6" runat="server" maxLength="40" Width="150" CssClass="FormNormal"></asp:TextBox>
					<asp:RangeValidator id="valBalance" ControlToValidate="txtBalance" EnableClientScript="False" Display="Dynamic" Runat="server" Type="Currency" MinimumValue="0.00" MaximumValue="1000000.00" ErrorMessage="Must be a valid value from 0.00 to 1000000.00." ></asp:RangeValidator>
					<asp:RequiredFieldValidator id="valBalanceRequired" ControlToValidate="txtBalance" EnableClientScript="False" Display="Dynamic" Runat="server" ErrorMessage="Please enter a valid value from 0.00 to 1000000.00." ></asp:RequiredFieldValidator>
				</td>
			</tr>
		</table>
	</MODC:PageSection>
	<MODC:PageSection id="Section_Additional_Info" visible="false" runat="server">
		<table>
			<tr>
				<td valign="top"><span class="FormLabelOptional"><asp:Label ID="lblResponseCodeDisplay" runat="server">Response&nbsp;Code:</asp:Label></span></td>
				<td valign="top">
					<asp:TextBox id="txtResponseCode" tabIndex="7" runat="server" maxLength="25" Width="150" CssClass="FormNormal"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelOptional"><asp:Label ID="lblTransactionCodeDisplay" runat="server">Transaction&nbsp;Code:</asp:Label></span></td>
				<td valign="top">
					<asp:TextBox id="txtTransactionCode" tabIndex="8" runat="server" maxLength="25" Width="150" CssClass="FormNormal"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelOptional"><asp:Label ID="lblTransactionMessageDisplay" runat="server">Transaction&nbsp;Message:</asp:Label></span></td>
				<td valign="top">
					<asp:TextBox id="txtTransactionMessage" tabIndex="9" runat="server" maxLength="255" Width="300" CssClass="FormNormal"></asp:TextBox>
				</td>
			</tr>
		</table>
	</MODC:PageSection>
	<MODC:PageSection id="Section_Payment_Transaction_Attribute_Value_Logs" visible="false" runat="server">
		<MOD:ListPaymentTransactionAttributeValueLogData id="listPaymentTransactionAttributeValueLogData" ListTitle="Payment&nbsp;Transaction&nbsp;Attribute&nbsp;Value&nbsp;Logs" WorkflowMode="Internal" AccessMode="Add" DisplayMode="SingleView" RequiresAuthentication="true" runat="server"></MOD:ListPaymentTransactionAttributeValueLogData>
	</MODC:PageSection>
</wilson:masterpage>