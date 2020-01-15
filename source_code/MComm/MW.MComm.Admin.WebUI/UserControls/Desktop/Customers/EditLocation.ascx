
<!-- copyright
Meta Wallet, Inc (c) 2007 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2007, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
/copyright -->
<%@ Register TagPrefix="Wilson" Namespace="Wilson.MasterPages" Assembly="WilsonMasterPages" %>
<%@ Control Language="c#" AutoEventWireup="false" CodeFile ="EditLocation.ascx.cs" Inherits="MW.MComm.Admin.WebUI.UserControls.Desktop.Customers.EditLocation" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="MOD" TagName="PageSectionLinks" Src="~/UserControls/Desktop/Utility/PageSectionLinks.ascx" %>
<%@ Register TagPrefix="MODC" Namespace="MW.MComm.Admin.WebUI.Controls"%>
<wilson:masterpage id="Masterpage" runat="server" templatefile="~/Templates/Desktop/DetailControl.ascx">
	<wilson:contentregion id="Title" runat="server">
		<asp:Label id="lblTitle" CssClass="subtitle" Runat="server">Edit Location</asp:Label>&nbsp;<asp:Label id="lblTitleMessage" CssClass="subtitle" Runat="server"></asp:Label>
	</wilson:contentregion>
	<wilson:contentregion id="ItemInfo" runat="server">
		<div class="IDSection" id="ItemInfoContent" runat="server">
		<table>
			<tr>
				<td>Location&nbsp;ID:</td>
				<td>
					<span class="ID">
					<MODC:PropVal id="propLocationID" runat="server" prop="LocationItem.LocationID" cssclass="ID"></MODC:PropVal>
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
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblLocationIDDisplay" runat="server">Location&nbsp;ID:</asp:Label></span></td>
				<td valign="top">
					<asp:Label id="lblLocationID" runat="server" CssClass="FormNormal"></asp:Label>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblLocationTypeCodeDisplay" runat="server">Location&nbsp;Type:</asp:Label></span></td>
				<td valign="top">
					<asp:DropDownList id="ddlLocationTypeCode" tabIndex="2" runat="server" CssClass="FormNormal"></asp:DropDownList>
					<asp:CompareValidator id="valLocationTypeCode" ControlToValidate="ddlLocationTypeCode" EnableClientScript="False" Display="Dynamic" Runat="server" Type="String" ValueToCompare="0" Operator="NotEqual" ErrorMessage="Please select a value from the list." ></asp:CompareValidator>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblAddressLine1Display" runat="server">Address&nbsp;Line1:</asp:Label></span></td>
				<td valign="top">
					<asp:TextBox id="txtAddressLine1" tabIndex="3" runat="server" maxLength="255" Width="300" CssClass="FormNormal"></asp:TextBox>
					<asp:RequiredFieldValidator id="valAddressLine1Required" ControlToValidate="txtAddressLine1" EnableClientScript="False" Display="Dynamic" Runat="server" ErrorMessage="Please enter some text." ></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblCityDisplay" runat="server">City:</asp:Label></span></td>
				<td valign="top">
					<asp:TextBox id="txtCity" tabIndex="4" runat="server" maxLength="255" Width="300" CssClass="FormNormal"></asp:TextBox>
					<asp:RequiredFieldValidator id="valCityRequired" ControlToValidate="txtCity" EnableClientScript="False" Display="Dynamic" Runat="server" ErrorMessage="Please enter some text." ></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblCountryCodeDisplay" runat="server">Country:</asp:Label></span></td>
				<td valign="top">
					<asp:DropDownList id="ddlCountryCode" tabIndex="5" runat="server" CssClass="FormNormal"></asp:DropDownList>
					<asp:CompareValidator id="valCountryCode" ControlToValidate="ddlCountryCode" EnableClientScript="False" Display="Dynamic" Runat="server" Type="String" ValueToCompare="0" Operator="NotEqual" ErrorMessage="Please select a value from the list." ></asp:CompareValidator>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblPostalCodeDisplay" runat="server">Postal&nbsp;Code:</asp:Label></span></td>
				<td valign="top">
					<asp:TextBox id="txtPostalCode" tabIndex="6" runat="server" maxLength="50" Width="150" CssClass="FormNormal"></asp:TextBox>
					<asp:RequiredFieldValidator id="valPostalCodeRequired" ControlToValidate="txtPostalCode" EnableClientScript="False" Display="Dynamic" Runat="server" ErrorMessage="Please enter some text." ></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblMetaPartnerIDDisplay" runat="server">Meta&nbsp;Partner:</asp:Label></span></td>
				<td valign="top">
					<asp:DropDownList id="ddlMetaPartnerID" tabIndex="7" runat="server" CssClass="FormNormal"></asp:DropDownList>
					<asp:Label id="lblMetaPartnerIDWorkingSet" runat="server" CssClass="FormNormal"> (from Meta&nbsp;Partner working set)</asp:Label>
					<a id="lnkMetaPartnerIDWorkingSet" runat="server" onclick="javascript:return PromptToDiscardChanges();" class="FormNormal">search</a>
					<asp:CompareValidator id="valMetaPartnerID" ControlToValidate="ddlMetaPartnerID" EnableClientScript="False" Display="Dynamic" Runat="server" Type="String" ValueToCompare="0" Operator="NotEqual" ErrorMessage="Please select a value from the list." ></asp:CompareValidator>
				</td>
			</tr>
		</table>
	</MODC:PageSection>
	<MODC:PageSection id="Section_Additional_Info" visible="false" runat="server">
		<table>
			<tr>
				<td valign="top"><span class="FormLabelOptional"><asp:Label ID="lblAddressLine2Display" runat="server">Address&nbsp;Line2:</asp:Label></span></td>
				<td valign="top">
					<asp:TextBox id="txtAddressLine2" tabIndex="8" runat="server" maxLength="255" Width="300" CssClass="FormNormal"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelOptional"><asp:Label ID="lblStateProvinceDisplay" runat="server">State&nbsp;Province:</asp:Label></span></td>
				<td valign="top">
					<asp:TextBox id="txtStateProvince" tabIndex="9" runat="server" maxLength="255" Width="300" CssClass="FormNormal"></asp:TextBox>
				</td>
			</tr>
		</table>
	</MODC:PageSection>
</wilson:masterpage>