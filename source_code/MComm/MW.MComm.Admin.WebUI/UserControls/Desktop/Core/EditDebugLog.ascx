
<!-- copyright
Meta Wallet, Inc (c) 2007 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2007, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
/copyright -->
<%@ Register TagPrefix="Wilson" Namespace="Wilson.MasterPages" Assembly="WilsonMasterPages" %>
<%@ Control Language="c#" AutoEventWireup="false" CodeFile ="EditDebugLog.ascx.cs" Inherits="MW.MComm.Admin.WebUI.UserControls.Desktop.Core.EditDebugLog" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="MOD" TagName="PageSectionLinks" Src="~/UserControls/Desktop/Utility/PageSectionLinks.ascx" %>
<%@ Register TagPrefix="MODC" Namespace="MW.MComm.Admin.WebUI.Controls"%>
<%@ Register TagPrefix="MOD" TagName="ListDebugAttributeValueLogData" Src="~/UserControls/Desktop/Core/ListDebugAttributeValueLogData.ascx" %>
<wilson:masterpage id="Masterpage" runat="server" templatefile="~/Templates/Desktop/DetailControl.ascx">
	<wilson:contentregion id="Title" runat="server">
		<asp:Label id="lblTitle" CssClass="subtitle" Runat="server">Edit Debug&nbsp;Log</asp:Label>&nbsp;<asp:Label id="lblTitleMessage" CssClass="subtitle" Runat="server"></asp:Label>
	</wilson:contentregion>
	<wilson:contentregion id="ItemInfo" runat="server">
		<div class="IDSection" id="ItemInfoContent" runat="server">
		<table>
			<tr>
				<td>Debug&nbsp;Log&nbsp;ID:</td>
				<td>
					<span class="ID">
					<MODC:PropVal id="propDebugLogID" runat="server" prop="DebugLogItem.DebugLogID" cssclass="ID"></MODC:PropVal>
					</span>
				</td>
			</tr>
			<tr>
				<td>Event&nbsp;Name:</td>
				<td>
					<span class="ID">
					<MODC:PropVal id="propEventName" runat="server" prop="DebugLogItem.EventName" cssclass="ID"></MODC:PropVal>
					</span>
				</td>
			</tr>
		</table>
		</div>
	</wilson:contentregion>
	<wilson:contentregion id="DetailNavigation" runat="server">
		<div class="SectionLink" id="SectionLinkContent" runat="server">
		<MOD:PageSectionLinks id="sectionLinks" runat="server" CssClass="SectionLink" SelectedCssClass="selSectionLink" ValidationList="Basics,Additional_Info" SectionList="Basics,Additional_Info,Debug_Attribute_Value_Logs"></MOD:PageSectionLinks>
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
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblDebugLogIDDisplay" runat="server">Debug&nbsp;Log&nbsp;ID:</asp:Label></span></td>
				<td valign="top">
					<asp:Label id="lblDebugLogID" runat="server" CssClass="FormNormal"></asp:Label>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblEventTypeCodeDisplay" runat="server">Event&nbsp;Type:</asp:Label></span></td>
				<td valign="top">
					<asp:DropDownList id="ddlEventTypeCode" tabIndex="2" runat="server" CssClass="FormNormal"></asp:DropDownList>
					<asp:CompareValidator id="valEventTypeCode" ControlToValidate="ddlEventTypeCode" EnableClientScript="False" Display="Dynamic" Runat="server" Type="String" ValueToCompare="0" Operator="NotEqual" ErrorMessage="Please select a value from the list." ></asp:CompareValidator>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblSeverityLevelCodeDisplay" runat="server">Severity&nbsp;Level:</asp:Label></span></td>
				<td valign="top">
					<asp:DropDownList id="ddlSeverityLevelCode" tabIndex="3" runat="server" CssClass="FormNormal"></asp:DropDownList>
					<asp:CompareValidator id="valSeverityLevelCode" ControlToValidate="ddlSeverityLevelCode" EnableClientScript="False" Display="Dynamic" Runat="server" Type="String" ValueToCompare="0" Operator="NotEqual" ErrorMessage="Please select a value from the list." ></asp:CompareValidator>
				</td>
			</tr>
		</table>
	</MODC:PageSection>
	<MODC:PageSection id="Section_Additional_Info" visible="false" runat="server">
		<table>
			<tr>
				<td valign="top"><span class="FormLabelOptional"><asp:Label ID="lblEventNameDisplay" runat="server">Event&nbsp;Name:</asp:Label></span></td>
				<td valign="top">
					<asp:TextBox id="txtEventName" tabIndex="4" runat="server" maxLength="255" Width="300" CssClass="FormNormal"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelOptional"><asp:Label ID="lblMessageDisplay" runat="server">Message:</asp:Label></span></td>
				<td valign="top">
					<asp:TextBox id="txtMessage" tabIndex="5" runat="server" Width="300" CssClass="FormNormal" TextMode="MultiLine" Rows="5" Columns="100"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelOptional"><asp:Label ID="lblErrorNumberDisplay" runat="server">Error&nbsp;Number:</asp:Label></span></td>
				<td valign="top">
					<asp:TextBox id="txtErrorNumber" tabIndex="6" runat="server" maxLength="5" Width="100" CssClass="FormNormal"></asp:TextBox>
					<asp:RangeValidator id="valErrorNumber" ControlToValidate="txtErrorNumber" EnableClientScript="False" Display="Dynamic" Runat="server" Type="Integer" MinimumValue="-2147483648" MaximumValue="2147483647" ErrorMessage="Must be a valid int from -2147483648 to 2147483647." ></asp:RangeValidator>
				</td>
			</tr>
		</table>
	</MODC:PageSection>
	<MODC:PageSection id="Section_Debug_Attribute_Value_Logs" visible="false" runat="server">
		<MOD:ListDebugAttributeValueLogData id="listDebugAttributeValueLogData" ListTitle="Debug&nbsp;Attribute&nbsp;Value&nbsp;Logs" WorkflowMode="Internal" AccessMode="Add" DisplayMode="SingleView" RequiresAuthentication="true" runat="server"></MOD:ListDebugAttributeValueLogData>
	</MODC:PageSection>
</wilson:masterpage>