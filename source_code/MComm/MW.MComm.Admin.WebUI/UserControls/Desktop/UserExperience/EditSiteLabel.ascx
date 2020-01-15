
<!-- copyright
Meta Wallet, Inc (c) 2007 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2007, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
/copyright -->
<%@ Register TagPrefix="Wilson" Namespace="Wilson.MasterPages" Assembly="WilsonMasterPages" %>
<%@ Control Language="c#" AutoEventWireup="false" CodeFile ="EditSiteLabel.ascx.cs" Inherits="MW.MComm.Admin.WebUI.UserControls.Desktop.UserExperience.EditSiteLabel" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="MOD" TagName="PageSectionLinks" Src="~/UserControls/Desktop/Utility/PageSectionLinks.ascx" %>
<%@ Register TagPrefix="MODC" Namespace="MW.MComm.Admin.WebUI.Controls"%>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox"%>
<%@ Register TagPrefix="MOD" TagName="UploadableFile" Src="~/UserControls/Desktop/Utility/UploadableFile.ascx"%>
<wilson:masterpage id="Masterpage" runat="server" templatefile="~/Templates/Desktop/DetailControl.ascx">
	<wilson:contentregion id="Title" runat="server">
		<asp:Label id="lblTitle" CssClass="subtitle" Runat="server">Edit Site&nbsp;Label</asp:Label>&nbsp;<asp:Label id="lblTitleMessage" CssClass="subtitle" Runat="server"></asp:Label>
	</wilson:contentregion>
	<wilson:contentregion id="ItemInfo" runat="server">
		<div class="IDSection" id="ItemInfoContent" runat="server">
		<table>
			<tr>
				<td>Locale&nbsp;Code:</td>
				<td>
					<span class="ID">
					<MODC:PropVal id="propLocaleCode" runat="server" prop="SiteLabelItem.LocaleCode" cssclass="ID"></MODC:PropVal>
					</span>
				</td>
			</tr>
			<tr>
				<td>Site&nbsp;Label&nbsp;Definition&nbsp;Code:</td>
				<td>
					<span class="ID">
					<MODC:PropVal id="propSiteLabelDefinitionCode" runat="server" prop="SiteLabelItem.SiteLabelDefinitionCode" cssclass="ID"></MODC:PropVal>
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
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblLocaleCodeDisplay" runat="server">Locale:</asp:Label></span></td>
				<td valign="top">
					<asp:DropDownList id="ddlLocaleCode" tabIndex="1" runat="server" CssClass="FormNormal"></asp:DropDownList>
					<asp:CompareValidator id="valLocaleCode" ControlToValidate="ddlLocaleCode" EnableClientScript="False" Display="Dynamic" Runat="server" Type="String" ValueToCompare="0" Operator="NotEqual" ErrorMessage="Please select a value from the list." ></asp:CompareValidator>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblTitleDisplay" runat="server">Title:</asp:Label></span></td>
				<td valign="top">
					<asp:TextBox id="txtTitle" tabIndex="2" runat="server" maxLength="255" Width="300" CssClass="FormNormal"></asp:TextBox>
					<asp:RequiredFieldValidator id="valTitleRequired" ControlToValidate="txtTitle" EnableClientScript="False" Display="Dynamic" Runat="server" ErrorMessage="Please enter some text." ></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblFileURLDisplay" runat="server">File&nbsp;URL:</asp:Label></span></td>
				<td valign="top">
					<MOD:UploadableFile id="txtFileURL" runat="server" DisplayName="File URL" ValidExtensions="swf,mp3,wma,wmv" Required="true" FileGroup="UserExperience"></MOD:UploadableFile>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblSiteLabelDefinitionCodeDisplay" runat="server">Site&nbsp;Label&nbsp;Definition:</asp:Label></span></td>
				<td valign="top">
					<asp:DropDownList id="ddlSiteLabelDefinitionCode" tabIndex="4" runat="server" CssClass="FormNormal"></asp:DropDownList>
					<asp:CompareValidator id="valSiteLabelDefinitionCode" ControlToValidate="ddlSiteLabelDefinitionCode" EnableClientScript="False" Display="Dynamic" Runat="server" Type="String" ValueToCompare="0" Operator="NotEqual" ErrorMessage="Please select a value from the list." ></asp:CompareValidator>
				</td>
			</tr>
		</table>
	</MODC:PageSection>
	<MODC:PageSection id="Section_Additional_Info" visible="false" runat="server">
		<table>
			<tr>
				<td valign="top"><span class="FormLabelOptional"><asp:Label ID="lblDisplayTextDisplay" runat="server">Display&nbsp;Text:</asp:Label></span></td>
				<td valign="top">
					<FTB:FreeTextBox id="txtDisplayText" tabIndex="5" runat="server" UpdateToolbar="false" RenderMode="Rich" ScriptMode="InPage" HtmlModeCssClass="FormNormal" DownLevelMode="InlineHtml" ShowTagPath="false" StripAllScripting="true" EnableToolbars="true" AutoHideToolbar="true" Focus="false" BackColor="#999999"></FTB:FreeTextBox>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelOptional"><asp:Label ID="lblTargetLocationDisplay" runat="server">Target&nbsp;Location:</asp:Label></span></td>
				<td valign="top">
					<asp:TextBox id="txtTargetLocation" tabIndex="6" runat="server" maxLength="255" Width="300" CssClass="FormNormal"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelOptional"><asp:Label ID="lblDescriptionDisplay" runat="server">Description:</asp:Label></span></td>
				<td valign="top">
					<asp:TextBox id="txtDescription" tabIndex="7" runat="server" Width="300" CssClass="FormNormal" TextMode="MultiLine" Rows="5" Columns="100"></asp:TextBox>
				</td>
			</tr>
		</table>
	</MODC:PageSection>
</wilson:masterpage>