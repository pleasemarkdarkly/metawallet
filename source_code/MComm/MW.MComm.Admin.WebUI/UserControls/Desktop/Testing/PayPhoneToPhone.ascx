
<!-- copyright
	MOD Systems, Inc (c) 2006 All Rights Reserved.
	720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
	All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by MOD Systems.  The contents also may only be viewed by MOD Systems Engineers (employees) and selected Starbucks employees as outlined in the Licensing Agreement between MOD Systems and Starbucks Corporation on June 3rd, 2005.
	No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
	No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact MOD System's competitive advantage.
	Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
/copyright -->
<%@ Register TagPrefix="Wilson" Namespace="Wilson.MasterPages" Assembly="WilsonMasterPages" %>
<%@ Control Language="c#" AutoEventWireup="false" CodeFile ="PayPhoneToPhone.ascx.cs" Inherits="MW.MComm.Admin.WebUI.UserControls.Desktop.Testing.PayPhoneToPhone" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="MOD" TagName="PageSectionLinks" Src="~/UserControls/Desktop/Utility/PageSectionLinks.ascx" %>
<%@ Register TagPrefix="MODC" Namespace="MW.MComm.Admin.WebUI.Controls"%>
<wilson:masterpage id="Masterpage" runat="server" templatefile="~/Templates/Desktop/DetailControl.ascx">
	<wilson:contentregion id="Title" runat="server">
		<asp:Label id="lblTitle" CssClass="subtitle" Runat="server">Pay&nbsp;Phone&nbsp;To&nbsp;Phone</asp:Label>&nbsp;<asp:Label id="lblTitleMessage" CssClass="subtitle" Runat="server"></asp:Label>
	</wilson:contentregion>
	<wilson:contentregion id="DetailNavigation" runat="server">
		<div class="SectionLink" id="SectionLinkContent" runat="server">
		<MOD:PageSectionLinks id="sectionLinks" runat="server" CssClass="SectionLink" SelectedCssClass="selSectionLink" ValidationList="Basics" SectionList="Basics"></MOD:PageSectionLinks>
		</div>
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

	<MODC:PageSection id="Section_Basics" visible="false" runat="server">
		<table>
			<tr>
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblFromMetaPartnerPhoneIDDisplay" runat="server">From&nbsp;Meta&nbsp;Partner&nbsp;Phone:</asp:Label></span></td>
				<td valign="top">
					<asp:DropDownList id="ddlFromMetaPartnerPhoneID" tabIndex="3" runat="server" CssClass="FormNormal"></asp:DropDownList>
					<asp:Label id="lblFromMetaPartnerPhoneIDWorkingSet" runat="server" CssClass="FormNormal"> (from Meta&nbsp;Partner&nbsp;Phone working set)</asp:Label>
					<a id="lnkFromMetaPartnerPhoneIDWorkingSet" runat="server" onclick="javascript:return PromptToDiscardChanges();" class="FormNormal">search</a>
					<asp:CompareValidator id="valFromMetaPartnerPhoneID" ControlToValidate="ddlFromMetaPartnerPhoneID" EnableClientScript="False" Display="Dynamic" Runat="server" Type="String" ValueToCompare="0" Operator="NotEqual" ErrorMessage="Please select a value from the list." ></asp:CompareValidator>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblToMetaPartnerPhoneIDDisplay" runat="server">To&nbsp;Meta&nbsp;Partner&nbsp;Phone:</asp:Label></span></td>
				<td valign="top">
					<asp:DropDownList id="ddlToMetaPartnerPhoneID" tabIndex="3" runat="server" CssClass="FormNormal"></asp:DropDownList>
					<asp:Label id="lblToMetaPartnerPhoneIDWorkingSet" runat="server" CssClass="FormNormal"> (from Meta&nbsp;Partner&nbsp;Phone working set)</asp:Label>
					<a id="lnkToMetaPartnerPhoneIDWorkingSet" runat="server" onclick="javascript:return PromptToDiscardChanges();" class="FormNormal">search</a>
					<asp:CompareValidator id="valToMetaPartnerPhoneID" ControlToValidate="ddlToMetaPartnerPhoneID" EnableClientScript="False" Display="Dynamic" Runat="server" Type="String" ValueToCompare="0" Operator="NotEqual" ErrorMessage="Please select a value from the list." ></asp:CompareValidator>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblBalanceDisplay" runat="server">Amount:</asp:Label></span></td>
				<td valign="top">
					<asp:TextBox id="txtBalance" tabIndex="4" runat="server" maxLength="40" Width="150" CssClass="FormNormal"></asp:TextBox>
					<asp:RangeValidator id="valBalance" ControlToValidate="txtBalance" EnableClientScript="False" Display="Dynamic" Runat="server" Type="Currency" MinimumValue="0.00" MaximumValue="1000000.00" ErrorMessage="Must be a valid value from 0.00 to 1000000.00." ></asp:RangeValidator>
					<asp:RequiredFieldValidator id="valBalanceRequired" ControlToValidate="txtBalance" EnableClientScript="False" Display="Dynamic" Runat="server" ErrorMessage="Please enter a valid value from 0.00 to 1000000.00." ></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblCurrencyCodeDisplay" runat="server">Currency:</asp:Label></span></td>
				<td valign="top">
					<asp:DropDownList id="ddlCurrencyCode" tabIndex="10" runat="server" CssClass="FormNormal"></asp:DropDownList>
					<asp:CompareValidator id="valCurrencyCode" ControlToValidate="ddlCurrencyCode" EnableClientScript="False" Display="Dynamic" Runat="server" Type="String" ValueToCompare="0" Operator="NotEqual" ErrorMessage="Please select a value from the list." ></asp:CompareValidator>
				</td>
			</tr>
		</table>
	</MODC:PageSection>
</wilson:masterpage>