
<!-- copyright
Meta Wallet, Inc (c) 2007 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2007, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
/copyright -->
<%@ Register TagPrefix="Wilson" Namespace="Wilson.MasterPages" Assembly="WilsonMasterPages" %>
<%@ Control Language="c#" AutoEventWireup="false" CodeFile ="EditPayment.ascx.cs" Inherits="MW.MComm.Admin.WebUI.UserControls.Desktop.Payments.EditPayment" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="MOD" TagName="PageSectionLinks" Src="~/UserControls/Desktop/Utility/PageSectionLinks.ascx" %>
<%@ Register TagPrefix="MODC" Namespace="MW.MComm.Admin.WebUI.Controls"%>
<%@ Register TagPrefix="MOD" TagName="ListPaymentTransactionLogData" Src="~/UserControls/Desktop/Payments/ListPaymentTransactionLogData.ascx" %>
<wilson:masterpage id="Masterpage" runat="server" templatefile="~/Templates/Desktop/DetailControl.ascx">
	<wilson:contentregion id="Title" runat="server">
		<asp:Label id="lblTitle" CssClass="subtitle" Runat="server">Edit Payment</asp:Label>&nbsp;<asp:Label id="lblTitleMessage" CssClass="subtitle" Runat="server"></asp:Label>
	</wilson:contentregion>
	<wilson:contentregion id="ItemInfo" runat="server">
		<div class="IDSection" id="ItemInfoContent" runat="server">
		<table>
			<tr>
				<td>Payment&nbsp;ID:</td>
				<td>
					<span class="ID">
					<MODC:PropVal id="propPaymentID" runat="server" prop="PaymentItem.PaymentID" cssclass="ID"></MODC:PropVal>
					</span>
				</td>
			</tr>
		</table>
		</div>
	</wilson:contentregion>
	<wilson:contentregion id="DetailNavigation" runat="server">
		<div class="SectionLink" id="SectionLinkContent" runat="server">
		<MOD:PageSectionLinks id="sectionLinks" runat="server" CssClass="SectionLink" SelectedCssClass="selSectionLink" ValidationList="Basics,Additional_Info" SectionList="Basics,Additional_Info,Payment_Transaction_Logs"></MOD:PageSectionLinks>
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
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblPaymentIDDisplay" runat="server">Payment&nbsp;ID:</asp:Label></span></td>
				<td valign="top">
					<asp:Label id="lblPaymentID" runat="server" CssClass="FormNormal"></asp:Label>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblPaymentAmountDisplay" runat="server">Payment&nbsp;Amount:</asp:Label></span></td>
				<td valign="top">
					<asp:TextBox id="txtPaymentAmount" tabIndex="2" runat="server" maxLength="40" Width="150" CssClass="FormNormal"></asp:TextBox>
					<asp:RangeValidator id="valPaymentAmount" ControlToValidate="txtPaymentAmount" EnableClientScript="False" Display="Dynamic" Runat="server" Type="Currency" MinimumValue="0.00" MaximumValue="1000000.00" ErrorMessage="Must be a valid value from 0.00 to 1000000.00." ></asp:RangeValidator>
					<asp:RequiredFieldValidator id="valPaymentAmountRequired" ControlToValidate="txtPaymentAmount" EnableClientScript="False" Display="Dynamic" Runat="server" ErrorMessage="Please enter a valid value from 0.00 to 1000000.00." ></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblPaymentSubtotalDisplay" runat="server">Payment&nbsp;Subtotal:</asp:Label></span></td>
				<td valign="top">
					<asp:TextBox id="txtPaymentSubtotal" tabIndex="3" runat="server" maxLength="40" Width="150" CssClass="FormNormal"></asp:TextBox>
					<asp:RangeValidator id="valPaymentSubtotal" ControlToValidate="txtPaymentSubtotal" EnableClientScript="False" Display="Dynamic" Runat="server" Type="Currency" MinimumValue="0.00" MaximumValue="1000000.00" ErrorMessage="Must be a valid value from 0.00 to 1000000.00." ></asp:RangeValidator>
					<asp:RequiredFieldValidator id="valPaymentSubtotalRequired" ControlToValidate="txtPaymentSubtotal" EnableClientScript="False" Display="Dynamic" Runat="server" ErrorMessage="Please enter a valid value from 0.00 to 1000000.00." ></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblPaymentTaxDisplay" runat="server">Payment&nbsp;Tax:</asp:Label></span></td>
				<td valign="top">
					<asp:TextBox id="txtPaymentTax" tabIndex="4" runat="server" maxLength="40" Width="150" CssClass="FormNormal"></asp:TextBox>
					<asp:RangeValidator id="valPaymentTax" ControlToValidate="txtPaymentTax" EnableClientScript="False" Display="Dynamic" Runat="server" Type="Currency" MinimumValue="0.00" MaximumValue="1000000.00" ErrorMessage="Must be a valid value from 0.00 to 1000000.00." ></asp:RangeValidator>
					<asp:RequiredFieldValidator id="valPaymentTaxRequired" ControlToValidate="txtPaymentTax" EnableClientScript="False" Display="Dynamic" Runat="server" ErrorMessage="Please enter a valid value from 0.00 to 1000000.00." ></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblPaymentServiceChargeDisplay" runat="server">Payment&nbsp;Service&nbsp;Charge:</asp:Label></span></td>
				<td valign="top">
					<asp:TextBox id="txtPaymentServiceCharge" tabIndex="5" runat="server" maxLength="40" Width="150" CssClass="FormNormal"></asp:TextBox>
					<asp:RangeValidator id="valPaymentServiceCharge" ControlToValidate="txtPaymentServiceCharge" EnableClientScript="False" Display="Dynamic" Runat="server" Type="Currency" MinimumValue="0.00" MaximumValue="1000000.00" ErrorMessage="Must be a valid value from 0.00 to 1000000.00." ></asp:RangeValidator>
					<asp:RequiredFieldValidator id="valPaymentServiceChargeRequired" ControlToValidate="txtPaymentServiceCharge" EnableClientScript="False" Display="Dynamic" Runat="server" ErrorMessage="Please enter a valid value from 0.00 to 1000000.00." ></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblOrderIDDisplay" runat="server">Order:</asp:Label></span></td>
				<td valign="top">
					<asp:DropDownList id="ddlOrderID" tabIndex="6" runat="server" CssClass="FormNormal"></asp:DropDownList>
					<asp:Label id="lblOrderIDWorkingSet" runat="server" CssClass="FormNormal"> (from Order working set)</asp:Label>
					<a id="lnkOrderIDWorkingSet" runat="server" onclick="javascript:return PromptToDiscardChanges();" class="FormNormal">search</a>
					<asp:CompareValidator id="valOrderID" ControlToValidate="ddlOrderID" EnableClientScript="False" Display="Dynamic" Runat="server" Type="String" ValueToCompare="0" Operator="NotEqual" ErrorMessage="Please select a value from the list." ></asp:CompareValidator>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblDebitMetaPartnerIDDisplay" runat="server">Account:</asp:Label></span></td>
				<td valign="top">
					<asp:DropDownList id="ddlDebitMetaPartnerID" tabIndex="7" runat="server" CssClass="FormNormal"></asp:DropDownList>
					<asp:Label id="lblDebitMetaPartnerIDWorkingSet" runat="server" CssClass="FormNormal"> (from Account working set)</asp:Label>
					<a id="lnkDebitMetaPartnerIDWorkingSet" runat="server" onclick="javascript:return PromptToDiscardChanges();" class="FormNormal">search</a>
					<asp:CompareValidator id="valDebitMetaPartnerID" ControlToValidate="ddlDebitMetaPartnerID" EnableClientScript="False" Display="Dynamic" Runat="server" Type="String" ValueToCompare="0" Operator="NotEqual" ErrorMessage="Please select a value from the list." ></asp:CompareValidator>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblCreditMetaPartnerIDDisplay" runat="server">Account:</asp:Label></span></td>
				<td valign="top">
					<asp:DropDownList id="ddlCreditMetaPartnerID" tabIndex="9" runat="server" CssClass="FormNormal"></asp:DropDownList>
					<asp:Label id="lblCreditMetaPartnerIDWorkingSet" runat="server" CssClass="FormNormal"> (from Account working set)</asp:Label>
					<a id="lnkCreditMetaPartnerIDWorkingSet" runat="server" onclick="javascript:return PromptToDiscardChanges();" class="FormNormal">search</a>
					<asp:CompareValidator id="valCreditMetaPartnerID" ControlToValidate="ddlCreditMetaPartnerID" EnableClientScript="False" Display="Dynamic" Runat="server" Type="String" ValueToCompare="0" Operator="NotEqual" ErrorMessage="Please select a value from the list." ></asp:CompareValidator>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblPaymentStatusCodeDisplay" runat="server">Payment&nbsp;Status:</asp:Label></span></td>
				<td valign="top">
					<asp:DropDownList id="ddlPaymentStatusCode" tabIndex="11" runat="server" CssClass="FormNormal"></asp:DropDownList>
					<asp:CompareValidator id="valPaymentStatusCode" ControlToValidate="ddlPaymentStatusCode" EnableClientScript="False" Display="Dynamic" Runat="server" Type="String" ValueToCompare="0" Operator="NotEqual" ErrorMessage="Please select a value from the list." ></asp:CompareValidator>
				</td>
			</tr>
		</table>
	</MODC:PageSection>
	<MODC:PageSection id="Section_Additional_Info" visible="false" runat="server">
		<table>
			<tr>
				<td valign="top"><span class="FormLabelOptional"><asp:Label ID="lblPaymentStatusMessageDisplay" runat="server">Payment&nbsp;Status&nbsp;Message:</asp:Label></span></td>
				<td valign="top">
					<asp:TextBox id="txtPaymentStatusMessage" tabIndex="12" runat="server" Width="300" CssClass="FormNormal" TextMode="MultiLine" Rows="5" Columns="100"></asp:TextBox>
				</td>
			</tr>
		</table>
	</MODC:PageSection>
	<MODC:PageSection id="Section_Payment_Transaction_Logs" visible="false" runat="server">
		<MOD:ListPaymentTransactionLogData id="listPaymentTransactionLogData" ListTitle="Payment&nbsp;Transaction&nbsp;Logs" WorkflowMode="Internal" AccessMode="Add" DisplayMode="SingleView" RequiresAuthentication="true" runat="server"></MOD:ListPaymentTransactionLogData>
	</MODC:PageSection>
</wilson:masterpage>