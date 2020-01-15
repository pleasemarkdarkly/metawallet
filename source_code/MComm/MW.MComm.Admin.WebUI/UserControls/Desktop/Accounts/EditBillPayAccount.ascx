
<!-- copyright
Meta Wallet, Inc (c) 2007 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2007, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
/copyright -->
<%@ Register TagPrefix="Wilson" Namespace="Wilson.MasterPages" Assembly="WilsonMasterPages" %>
<%@ Control Language="c#" AutoEventWireup="false" CodeFile ="EditBillPayAccount.ascx.cs" Inherits="MW.MComm.Admin.WebUI.UserControls.Desktop.Accounts.EditBillPayAccount" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="MOD" TagName="PageSectionLinks" Src="~/UserControls/Desktop/Utility/PageSectionLinks.ascx" %>
<%@ Register TagPrefix="MODC" Namespace="MW.MComm.Admin.WebUI.Controls"%>
<wilson:masterpage id="Masterpage" runat="server" templatefile="~/Templates/Desktop/DetailControl.ascx">
	<wilson:contentregion id="Title" runat="server">
		<asp:Label id="lblTitle" CssClass="subtitle" Runat="server">Edit Bill&nbsp;Pay&nbsp;Account</asp:Label>&nbsp;<asp:Label id="lblTitleMessage" CssClass="subtitle" Runat="server"></asp:Label>
	</wilson:contentregion>
	<wilson:contentregion id="ItemInfo" runat="server">
		<div class="IDSection" id="ItemInfoContent" runat="server">
		<table>
			<tr>
				<td>Account&nbsp;ID:</td>
				<td>
					<span class="ID">
					<MODC:PropVal id="propAccountID" runat="server" prop="BillPayAccountItem.AccountID" cssclass="ID"></MODC:PropVal>
					</span>
				</td>
			</tr>
			<tr>
				<td>Account&nbsp;Name:</td>
				<td>
					<span class="ID">
					<MODC:PropVal id="propAccountName" runat="server" prop="BillPayAccountItem.AccountName" cssclass="ID"></MODC:PropVal>
					</span>
				</td>
			</tr>
		</table>
		</div>
	</wilson:contentregion>
	<wilson:contentregion id="DetailNavigation" runat="server">
		<div class="SectionLink" id="SectionLinkContent" runat="server">
		<MOD:PageSectionLinks id="sectionLinks" runat="server" CssClass="SectionLink" SelectedCssClass="selSectionLink" ValidationList="Basics,Additional_Info" SectionList="Basics,Additional_Info"></MOD:PageSectionLinks>
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
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblAccountIDDisplay" runat="server">Account&nbsp;ID:</asp:Label></span></td>
				<td valign="top">
					<asp:Label id="lblAccountID" runat="server" CssClass="FormNormal"></asp:Label>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblBusinessAccountNumberDisplay" runat="server">Business&nbsp;Account&nbsp;Number:</asp:Label></span></td>
				<td valign="top">
					<asp:TextBox id="txtBusinessAccountNumber" tabIndex="2" runat="server" maxLength="100" Width="150" CssClass="FormNormal"></asp:TextBox>
					<asp:RequiredFieldValidator id="valBusinessAccountNumberRequired" ControlToValidate="txtBusinessAccountNumber" EnableClientScript="False" Display="Dynamic" Runat="server" ErrorMessage="Please enter some text." ></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblStartDateDisplay" runat="server">Start&nbsp;Date:</asp:Label></span></td>
				<td valign="top">
					<asp:TextBox id="txtStartDate" tabIndex="3" runat="server" maxLength="40" Width="150" CssClass="FormNormal"></asp:TextBox>&nbsp;<asp:Button id="btnStartDateCalendar" tabIndex="4" runat="server" CssClass="Button" CausesValidation="False" Text="Calendar"></asp:Button>
					<asp:RangeValidator id="valStartDate" ControlToValidate="txtStartDate" EnableClientScript="False" Display="Dynamic" Runat="server" Type="Date" MinimumValue="1900/1/1" MaximumValue="2100/1/1" ErrorMessage="Must be a valid date from 1/1/1900 to 1/1/2100." ></asp:RangeValidator>
					<asp:Calendar id="calStartDate" runat="server" tabIndex="5" Visible="false" CssClass="FormNormal" SelectionMode="DayWeekMonth"><TodayDayStyle BorderStyle="Dotted" BorderWidth="1" BorderColor="#000000" /><SelectedDayStyle BackColor="#eeffee" ForeColor="#000000" /></asp:Calendar>
					<asp:RequiredFieldValidator id="valStartDateRequired" ControlToValidate="txtStartDate" EnableClientScript="False" Display="Dynamic" Runat="server" ErrorMessage="Please enter a valid date from 1/1/1900 to 1/1/2100." ></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblEndDateDisplay" runat="server">End&nbsp;Date:</asp:Label></span></td>
				<td valign="top">
					<asp:TextBox id="txtEndDate" tabIndex="6" runat="server" maxLength="40" Width="150" CssClass="FormNormal"></asp:TextBox>&nbsp;<asp:Button id="btnEndDateCalendar" tabIndex="7" runat="server" CssClass="Button" CausesValidation="False" Text="Calendar"></asp:Button>
					<asp:RangeValidator id="valEndDate" ControlToValidate="txtEndDate" EnableClientScript="False" Display="Dynamic" Runat="server" Type="Date" MinimumValue="1900/1/1" MaximumValue="2100/1/1" ErrorMessage="Must be a valid date from 1/1/1900 to 1/1/2100." ></asp:RangeValidator>
					<asp:Calendar id="calEndDate" runat="server" tabIndex="8" Visible="false" CssClass="FormNormal" SelectionMode="DayWeekMonth"><TodayDayStyle BorderStyle="Dotted" BorderWidth="1" BorderColor="#000000" /><SelectedDayStyle BackColor="#eeffee" ForeColor="#000000" /></asp:Calendar>
					<asp:RequiredFieldValidator id="valEndDateRequired" ControlToValidate="txtEndDate" EnableClientScript="False" Display="Dynamic" Runat="server" ErrorMessage="Please enter a valid date from 1/1/1900 to 1/1/2100." ></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblDefaultMinimumPaymentDisplay" runat="server">Default&nbsp;Minimum&nbsp;Payment:</asp:Label></span></td>
				<td valign="top">
					<asp:TextBox id="txtDefaultMinimumPayment" tabIndex="9" runat="server" maxLength="40" Width="150" CssClass="FormNormal"></asp:TextBox>
					<asp:RangeValidator id="valDefaultMinimumPayment" ControlToValidate="txtDefaultMinimumPayment" EnableClientScript="False" Display="Dynamic" Runat="server" Type="Currency" MinimumValue="0.00" MaximumValue="1000000.00" ErrorMessage="Must be a valid value from 0.00 to 1000000.00." ></asp:RangeValidator>
					<asp:RequiredFieldValidator id="valDefaultMinimumPaymentRequired" ControlToValidate="txtDefaultMinimumPayment" EnableClientScript="False" Display="Dynamic" Runat="server" ErrorMessage="Please enter a valid value from 0.00 to 1000000.00." ></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblDefaultMaximumPaymentDisplay" runat="server">Default&nbsp;Maximum&nbsp;Payment:</asp:Label></span></td>
				<td valign="top">
					<asp:TextBox id="txtDefaultMaximumPayment" tabIndex="10" runat="server" maxLength="40" Width="150" CssClass="FormNormal"></asp:TextBox>
					<asp:RangeValidator id="valDefaultMaximumPayment" ControlToValidate="txtDefaultMaximumPayment" EnableClientScript="False" Display="Dynamic" Runat="server" Type="Currency" MinimumValue="0.00" MaximumValue="1000000.00" ErrorMessage="Must be a valid value from 0.00 to 1000000.00." ></asp:RangeValidator>
					<asp:RequiredFieldValidator id="valDefaultMaximumPaymentRequired" ControlToValidate="txtDefaultMaximumPayment" EnableClientScript="False" Display="Dynamic" Runat="server" ErrorMessage="Please enter a valid value from 0.00 to 1000000.00." ></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblBusinessMetaPartnerIDDisplay" runat="server">Business:</asp:Label></span></td>
				<td valign="top">
					<asp:DropDownList id="ddlBusinessMetaPartnerID" tabIndex="11" runat="server" CssClass="FormNormal"></asp:DropDownList>
					<asp:Label id="lblBusinessMetaPartnerIDWorkingSet" runat="server" CssClass="FormNormal"> (from Business working set)</asp:Label>
					<a id="lnkBusinessMetaPartnerIDWorkingSet" runat="server" onclick="javascript:return PromptToDiscardChanges();" class="FormNormal">search</a>
					<asp:CompareValidator id="valBusinessMetaPartnerID" ControlToValidate="ddlBusinessMetaPartnerID" EnableClientScript="False" Display="Dynamic" Runat="server" Type="String" ValueToCompare="0" Operator="NotEqual" ErrorMessage="Please select a value from the list." ></asp:CompareValidator>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblHourOfDayDisplay" runat="server">Hour&nbsp;Of&nbsp;Day:</asp:Label></span></td>
				<td valign="top">
					<asp:TextBox id="txtHourOfDay" tabIndex="12" runat="server" maxLength="5" Width="100" CssClass="FormNormal"></asp:TextBox>
					<asp:RangeValidator id="valHourOfDay" ControlToValidate="txtHourOfDay" EnableClientScript="False" Display="Dynamic" Runat="server" Type="Integer" MinimumValue="-2147483648" MaximumValue="2147483647" ErrorMessage="Must be a valid int from -2147483648 to 2147483647." ></asp:RangeValidator>
					<asp:RequiredFieldValidator id="valHourOfDayRequired" ControlToValidate="txtHourOfDay" EnableClientScript="False" Display="Dynamic" Runat="server" ErrorMessage="Please enter a valid int from 1 to 2147483647." ></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblDayOfWeekDisplay" runat="server">Day&nbsp;Of&nbsp;Week:</asp:Label></span></td>
				<td valign="top">
					<asp:TextBox id="txtDayOfWeek" tabIndex="13" runat="server" maxLength="5" Width="100" CssClass="FormNormal"></asp:TextBox>
					<asp:RangeValidator id="valDayOfWeek" ControlToValidate="txtDayOfWeek" EnableClientScript="False" Display="Dynamic" Runat="server" Type="Integer" MinimumValue="-2147483648" MaximumValue="2147483647" ErrorMessage="Must be a valid int from -2147483648 to 2147483647." ></asp:RangeValidator>
					<asp:RequiredFieldValidator id="valDayOfWeekRequired" ControlToValidate="txtDayOfWeek" EnableClientScript="False" Display="Dynamic" Runat="server" ErrorMessage="Please enter a valid int from 1 to 2147483647." ></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblWeekOfMonthDisplay" runat="server">Week&nbsp;Of&nbsp;Month:</asp:Label></span></td>
				<td valign="top">
					<asp:TextBox id="txtWeekOfMonth" tabIndex="14" runat="server" maxLength="5" Width="100" CssClass="FormNormal"></asp:TextBox>
					<asp:RangeValidator id="valWeekOfMonth" ControlToValidate="txtWeekOfMonth" EnableClientScript="False" Display="Dynamic" Runat="server" Type="Integer" MinimumValue="-2147483648" MaximumValue="2147483647" ErrorMessage="Must be a valid int from -2147483648 to 2147483647." ></asp:RangeValidator>
					<asp:RequiredFieldValidator id="valWeekOfMonthRequired" ControlToValidate="txtWeekOfMonth" EnableClientScript="False" Display="Dynamic" Runat="server" ErrorMessage="Please enter a valid int from 1 to 2147483647." ></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblMonthOfYearDisplay" runat="server">Month&nbsp;Of&nbsp;Year:</asp:Label></span></td>
				<td valign="top">
					<asp:TextBox id="txtMonthOfYear" tabIndex="15" runat="server" maxLength="5" Width="100" CssClass="FormNormal"></asp:TextBox>
					<asp:RangeValidator id="valMonthOfYear" ControlToValidate="txtMonthOfYear" EnableClientScript="False" Display="Dynamic" Runat="server" Type="Integer" MinimumValue="-2147483648" MaximumValue="2147483647" ErrorMessage="Must be a valid int from -2147483648 to 2147483647." ></asp:RangeValidator>
					<asp:RequiredFieldValidator id="valMonthOfYearRequired" ControlToValidate="txtMonthOfYear" EnableClientScript="False" Display="Dynamic" Runat="server" ErrorMessage="Please enter a valid int from 1 to 2147483647." ></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblNumberOfRemindersDisplay" runat="server">Number&nbsp;Of&nbsp;Reminders:</asp:Label></span></td>
				<td valign="top">
					<asp:TextBox id="txtNumberOfReminders" tabIndex="16" runat="server" maxLength="5" Width="100" CssClass="FormNormal"></asp:TextBox>
					<asp:RangeValidator id="valNumberOfReminders" ControlToValidate="txtNumberOfReminders" EnableClientScript="False" Display="Dynamic" Runat="server" Type="Integer" MinimumValue="-2147483648" MaximumValue="2147483647" ErrorMessage="Must be a valid int from -2147483648 to 2147483647." ></asp:RangeValidator>
					<asp:RequiredFieldValidator id="valNumberOfRemindersRequired" ControlToValidate="txtNumberOfReminders" EnableClientScript="False" Display="Dynamic" Runat="server" ErrorMessage="Please enter a valid int from 1 to 2147483647." ></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblFrequencyCodeDisplay" runat="server">Frequency:</asp:Label></span></td>
				<td valign="top">
					<asp:DropDownList id="ddlFrequencyCode" tabIndex="17" runat="server" CssClass="FormNormal"></asp:DropDownList>
					<asp:CompareValidator id="valFrequencyCode" ControlToValidate="ddlFrequencyCode" EnableClientScript="False" Display="Dynamic" Runat="server" Type="String" ValueToCompare="0" Operator="NotEqual" ErrorMessage="Please select a value from the list." ></asp:CompareValidator>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblMetaPartnerIDDisplay" runat="server">Meta&nbsp;Partner:</asp:Label></span></td>
				<td valign="top">
					<asp:DropDownList id="ddlMetaPartnerID" tabIndex="18" runat="server" CssClass="FormNormal"></asp:DropDownList>
					<asp:Label id="lblMetaPartnerIDWorkingSet" runat="server" CssClass="FormNormal"> (from Meta&nbsp;Partner working set)</asp:Label>
					<a id="lnkMetaPartnerIDWorkingSet" runat="server" onclick="javascript:return PromptToDiscardChanges();" class="FormNormal">search</a>
					<asp:CompareValidator id="valMetaPartnerID" ControlToValidate="ddlMetaPartnerID" EnableClientScript="False" Display="Dynamic" Runat="server" Type="String" ValueToCompare="0" Operator="NotEqual" ErrorMessage="Please select a value from the list." ></asp:CompareValidator>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblAccountNameDisplay" runat="server">Account&nbsp;Name:</asp:Label></span></td>
				<td valign="top">
					<asp:TextBox id="txtAccountName" tabIndex="19" runat="server" maxLength="255" Width="300" CssClass="FormNormal"></asp:TextBox>
					<asp:RequiredFieldValidator id="valAccountNameRequired" ControlToValidate="txtAccountName" EnableClientScript="False" Display="Dynamic" Runat="server" ErrorMessage="Please enter some text." ></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblAccountSubTypeCodeDisplay" runat="server">Account&nbsp;Sub&nbsp;Type:</asp:Label></span></td>
				<td valign="top">
					<asp:DropDownList id="ddlAccountSubTypeCode" tabIndex="20" runat="server" CssClass="FormNormal"></asp:DropDownList>
					<asp:CompareValidator id="valAccountSubTypeCode" ControlToValidate="ddlAccountSubTypeCode" EnableClientScript="False" Display="Dynamic" Runat="server" Type="String" ValueToCompare="0" Operator="NotEqual" ErrorMessage="Please select a value from the list." ></asp:CompareValidator>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblCurrencyCodeDisplay" runat="server">Currency:</asp:Label></span></td>
				<td valign="top">
					<asp:DropDownList id="ddlCurrencyCode" tabIndex="21" runat="server" CssClass="FormNormal"></asp:DropDownList>
					<asp:CompareValidator id="valCurrencyCode" ControlToValidate="ddlCurrencyCode" EnableClientScript="False" Display="Dynamic" Runat="server" Type="String" ValueToCompare="0" Operator="NotEqual" ErrorMessage="Please select a value from the list." ></asp:CompareValidator>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblIsActiveDisplay" runat="server">Is&nbsp;Active:</asp:Label></span></td>
				<td valign="top">
					<asp:CheckBox id="chkIsActive" tabIndex="22" runat="server" CssClass="FormNormal"></asp:CheckBox>
				</td>
			</tr>
		</table>
	</MODC:PageSection>
	<MODC:PageSection id="Section_Additional_Info" visible="false" runat="server">
		<table>
			<tr>
				<td valign="top"><span class="FormLabelOptional"><asp:Label ID="lblDescriptionDisplay" runat="server">Description:</asp:Label></span></td>
				<td valign="top">
					<asp:TextBox id="txtDescription" tabIndex="23" runat="server" Width="300" CssClass="FormNormal" TextMode="MultiLine" Rows="5" Columns="100"></asp:TextBox>
				</td>
			</tr>
		</table>
	</MODC:PageSection>
</wilson:masterpage>