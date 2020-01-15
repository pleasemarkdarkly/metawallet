
<!-- copyright
Meta Wallet, Inc (c) 2007 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2007, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
/copyright -->
<%@ Register TagPrefix="Wilson" Namespace="Wilson.MasterPages" Assembly="WilsonMasterPages" %>
<%@ Control Language="c#" AutoEventWireup="false" CodeFile ="EditEvent.ascx.cs" Inherits="MW.MComm.Admin.WebUI.UserControls.Desktop.Events.EditEvent" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="MOD" TagName="PageSectionLinks" Src="~/UserControls/Desktop/Utility/PageSectionLinks.ascx" %>
<%@ Register TagPrefix="MODC" Namespace="MW.MComm.Admin.WebUI.Controls"%>
<%@ Register TagPrefix="MOD" TagName="ListSpecificEventAttributeData" Src="~/UserControls/Desktop/Events/ListSpecificEventAttributeData.ascx" %>
<%@ Register TagPrefix="MOD" TagName="ListNotificationData" Src="~/UserControls/Desktop/Notifications/ListNotificationData.ascx" %>
<%@ Register TagPrefix="MOD" TagName="ListEventFeeData" Src="~/UserControls/Desktop/Events/ListEventFeeData.ascx" %>
<%@ Register TagPrefix="MOD" TagName="ListEventPromotionData" Src="~/UserControls/Desktop/Events/ListEventPromotionData.ascx" %>
<%@ Register TagPrefix="MOD" TagName="ListAuditLogData" Src="~/UserControls/Desktop/Events/ListAuditLogData.ascx" %>
<wilson:masterpage id="Masterpage" runat="server" templatefile="~/Templates/Desktop/DetailControl.ascx">
	<wilson:contentregion id="Title" runat="server">
		<asp:Label id="lblTitle" CssClass="subtitle" Runat="server">Edit Event</asp:Label>&nbsp;<asp:Label id="lblTitleMessage" CssClass="subtitle" Runat="server"></asp:Label>
	</wilson:contentregion>
	<wilson:contentregion id="ItemInfo" runat="server">
		<div class="IDSection" id="ItemInfoContent" runat="server">
		<table>
			<tr>
				<td>Event&nbsp;Code:</td>
				<td>
					<span class="ID">
					<MODC:PropVal id="propEventCode" runat="server" prop="EventItem.EventCode" cssclass="ID"></MODC:PropVal>
					</span>
				</td>
			</tr>
			<tr>
				<td>Event&nbsp;Name:</td>
				<td>
					<span class="ID">
					<MODC:PropVal id="propEventName" runat="server" prop="EventItem.EventName" cssclass="ID"></MODC:PropVal>
					</span>
				</td>
			</tr>
		</table>
		</div>
	</wilson:contentregion>
	<wilson:contentregion id="DetailNavigation" runat="server">
		<div class="SectionLink" id="SectionLinkContent" runat="server">
		<MOD:PageSectionLinks id="sectionLinks" runat="server" CssClass="SectionLink" SelectedCssClass="selSectionLink" ValidationList="Basics,Additional_Info" SectionList="Basics,Additional_Info,Specific_Event_Attributes,Notifications,Event_Fees,Event_Promotions,Audit_Logs"></MOD:PageSectionLinks>
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
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblEventCodeDisplay" runat="server">Event&nbsp;Code:</asp:Label></span></td>
				<td valign="top">
					<asp:TextBox id="txtEventCode" tabIndex="1" runat="server" maxLength="5" Width="100" CssClass="FormNormal"></asp:TextBox>
					<asp:RangeValidator id="valEventCode" ControlToValidate="txtEventCode" EnableClientScript="False" Display="Dynamic" Runat="server" Type="Integer" MinimumValue="-2147483648" MaximumValue="2147483647" ErrorMessage="Must be a valid int from -2147483648 to 2147483647." ></asp:RangeValidator>
					<asp:RequiredFieldValidator id="valEventCodeRequired" ControlToValidate="txtEventCode" EnableClientScript="False" Display="Dynamic" Runat="server" ErrorMessage="Please enter a valid int from 1 to 2147483647." ></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblEventNameDisplay" runat="server">Event&nbsp;Name:</asp:Label></span></td>
				<td valign="top">
					<asp:TextBox id="txtEventName" tabIndex="2" runat="server" maxLength="255" Width="300" CssClass="FormNormal"></asp:TextBox>
					<asp:RequiredFieldValidator id="valEventNameRequired" ControlToValidate="txtEventName" EnableClientScript="False" Display="Dynamic" Runat="server" ErrorMessage="Please enter some text." ></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblEventTypeCodeDisplay" runat="server">Event&nbsp;Type:</asp:Label></span></td>
				<td valign="top">
					<asp:DropDownList id="ddlEventTypeCode" tabIndex="3" runat="server" CssClass="FormNormal"></asp:DropDownList>
					<asp:CompareValidator id="valEventTypeCode" ControlToValidate="ddlEventTypeCode" EnableClientScript="False" Display="Dynamic" Runat="server" Type="String" ValueToCompare="0" Operator="NotEqual" ErrorMessage="Please select a value from the list." ></asp:CompareValidator>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblIsActiveDisplay" runat="server">Is&nbsp;Active:</asp:Label></span></td>
				<td valign="top">
					<asp:CheckBox id="chkIsActive" tabIndex="4" runat="server" CssClass="FormNormal"></asp:CheckBox>
				</td>
			</tr>
		</table>
	</MODC:PageSection>
	<MODC:PageSection id="Section_Additional_Info" visible="false" runat="server">
		<table>
			<tr>
				<td valign="top"><span class="FormLabelOptional"><asp:Label ID="lblDescriptionDisplay" runat="server">Description:</asp:Label></span></td>
				<td valign="top">
					<asp:TextBox id="txtDescription" tabIndex="5" runat="server" Width="300" CssClass="FormNormal" TextMode="MultiLine" Rows="5" Columns="100"></asp:TextBox>
				</td>
			</tr>
		</table>
	</MODC:PageSection>
	<MODC:PageSection id="Section_Specific_Event_Attributes" visible="false" runat="server">
		<MOD:ListSpecificEventAttributeData id="listSpecificEventAttributeData" ListTitle="Specific&nbsp;Event&nbsp;Attributes" WorkflowMode="Internal" AccessMode="Add" DisplayMode="SingleView" RequiresAuthentication="true" runat="server"></MOD:ListSpecificEventAttributeData>
	</MODC:PageSection>
	<MODC:PageSection id="Section_Notifications" visible="false" runat="server">
		<MOD:ListNotificationData id="listNotificationData" ListTitle="Notifications" WorkflowMode="Internal" AccessMode="Add" DisplayMode="SingleView" RequiresAuthentication="true" runat="server"></MOD:ListNotificationData>
	</MODC:PageSection>
	<MODC:PageSection id="Section_Event_Fees" visible="false" runat="server">
		<MOD:ListEventFeeData id="listEventFeeData" ListTitle="Event&nbsp;Fees" WorkflowMode="Internal" AccessMode="Add" DisplayMode="SingleView" RequiresAuthentication="true" runat="server"></MOD:ListEventFeeData>
	</MODC:PageSection>
	<MODC:PageSection id="Section_Event_Promotions" visible="false" runat="server">
		<MOD:ListEventPromotionData id="listEventPromotionData" ListTitle="Event&nbsp;Promotions" WorkflowMode="Internal" AccessMode="Add" DisplayMode="SingleView" RequiresAuthentication="true" runat="server"></MOD:ListEventPromotionData>
	</MODC:PageSection>
	<MODC:PageSection id="Section_Audit_Logs" visible="false" runat="server">
		<MOD:ListAuditLogData id="listAuditLogData" ListTitle="Audit&nbsp;Logs" WorkflowMode="Internal" AccessMode="Add" DisplayMode="SingleView" RequiresAuthentication="true" runat="server"></MOD:ListAuditLogData>
	</MODC:PageSection>
</wilson:masterpage>