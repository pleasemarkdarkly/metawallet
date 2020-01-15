
<!-- copyright
Meta Wallet, Inc (c) 2007 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2007, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
/copyright -->
<%@ Register TagPrefix="Wilson" Namespace="Wilson.MasterPages" Assembly="WilsonMasterPages" %>
<%@ Control Language="c#" AutoEventWireup="false" CodeFile ="EditCarrier.ascx.cs" Inherits="MW.MComm.Admin.WebUI.UserControls.Desktop.Customers.EditCarrier" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="MOD" TagName="PageSectionLinks" Src="~/UserControls/Desktop/Utility/PageSectionLinks.ascx" %>
<%@ Register TagPrefix="MODC" Namespace="MW.MComm.Admin.WebUI.Controls"%>
<%@ Register TagPrefix="MOD" TagName="UploadableImage" Src="~/UserControls/Desktop/Utility/UploadableImage.ascx"%>
<%@ Register TagPrefix="MOD" TagName="ListMetaPartnerPhoneData" Src="~/UserControls/Desktop/Customers/ListMetaPartnerPhoneData.ascx" %>
<%@ Register TagPrefix="MOD" TagName="ListMetaPartnerEmailData" Src="~/UserControls/Desktop/Customers/ListMetaPartnerEmailData.ascx" %>
<%@ Register TagPrefix="MOD" TagName="ListLocationData" Src="~/UserControls/Desktop/Customers/ListLocationData.ascx" %>
<%@ Register TagPrefix="MOD" TagName="ListBankAccountData" Src="~/UserControls/Desktop/Accounts/ListBankAccountData.ascx" %>
<%@ Register TagPrefix="MOD" TagName="ListStoredValueAccountData" Src="~/UserControls/Desktop/Accounts/ListStoredValueAccountData.ascx" %>
<%@ Register TagPrefix="MOD" TagName="ListCreditAccountData" Src="~/UserControls/Desktop/Accounts/ListCreditAccountData.ascx" %>
<%@ Register TagPrefix="MOD" TagName="ListFundAccountData" Src="~/UserControls/Desktop/Accounts/ListFundAccountData.ascx" %>
<%@ Register TagPrefix="MOD" TagName="ListBillPayAccountData" Src="~/UserControls/Desktop/Accounts/ListBillPayAccountData.ascx" %>
<%@ Register TagPrefix="MOD" TagName="ListMetaTransferAccountData" Src="~/UserControls/Desktop/Accounts/ListMetaTransferAccountData.ascx" %>
<%@ Register TagPrefix="MOD" TagName="ListLoanAccountData" Src="~/UserControls/Desktop/Accounts/ListLoanAccountData.ascx" %>
<%@ Register TagPrefix="MOD" TagName="ListMetaPartnerCouponData" Src="~/UserControls/Desktop/Promotions/ListMetaPartnerCouponData.ascx" %>
<wilson:masterpage id="Masterpage" runat="server" templatefile="~/Templates/Desktop/DetailControl.ascx">
	<wilson:contentregion id="Title" runat="server">
		<asp:Label id="lblTitle" CssClass="subtitle" Runat="server">Edit Carrier</asp:Label>&nbsp;<asp:Label id="lblTitleMessage" CssClass="subtitle" Runat="server"></asp:Label>
	</wilson:contentregion>
	<wilson:contentregion id="ItemInfo" runat="server">
		<div class="IDSection" id="ItemInfoContent" runat="server">
		<table>
			<tr>
				<td>Meta&nbsp;Partner&nbsp;ID:</td>
				<td>
					<span class="ID">
					<MODC:PropVal id="propMetaPartnerID" runat="server" prop="CarrierItem.MetaPartnerID" cssclass="ID"></MODC:PropVal>
					</span>
				</td>
			</tr>
			<tr>
				<td>Meta&nbsp;Partner&nbsp;Name:</td>
				<td>
					<span class="ID">
					<MODC:PropVal id="propMetaPartnerName" runat="server" prop="CarrierItem.MetaPartnerName" cssclass="ID"></MODC:PropVal>
					</span>
				</td>
			</tr>
		</table>
		</div>
	</wilson:contentregion>
	<wilson:contentregion id="DetailNavigation" runat="server">
		<div class="SectionLink" id="SectionLinkContent" runat="server">
		<MOD:PageSectionLinks id="sectionLinks" runat="server" CssClass="SectionLink" SelectedCssClass="selSectionLink" ValidationList="Basics,Additional_Info" SectionList="Basics,Additional_Info,Phones,Emails,Locations,Bank_Accounts,Stored_Value_Accounts,Credit_Accounts,Fund_Accounts,Bill_Pay_Accounts,Meta_Transfer_Accounts,Loan_Accounts,Meta_Partner_Coupons"></MOD:PageSectionLinks>
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
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblMetaPartnerIDDisplay" runat="server">Meta&nbsp;Partner&nbsp;ID:</asp:Label></span></td>
				<td valign="top">
					<asp:Label id="lblMetaPartnerID" runat="server" CssClass="FormNormal"></asp:Label>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblCarrierCodeDisplay" runat="server">Carrier&nbsp;Code:</asp:Label></span></td>
				<td valign="top">
					<asp:TextBox id="txtCarrierCode" tabIndex="2" runat="server" maxLength="5" Width="100" CssClass="FormNormal"></asp:TextBox>
					<asp:RangeValidator id="valCarrierCode" ControlToValidate="txtCarrierCode" EnableClientScript="False" Display="Dynamic" Runat="server" Type="Integer" MinimumValue="-2147483648" MaximumValue="2147483647" ErrorMessage="Must be a valid int from -2147483648 to 2147483647." ></asp:RangeValidator>
					<asp:RequiredFieldValidator id="valCarrierCodeRequired" ControlToValidate="txtCarrierCode" EnableClientScript="False" Display="Dynamic" Runat="server" ErrorMessage="Please enter a valid int from 1 to 2147483647." ></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblMetaPartnerSubTypeCodeDisplay" runat="server">Meta&nbsp;Partner&nbsp;Sub&nbsp;Type:</asp:Label></span></td>
				<td valign="top">
					<asp:DropDownList id="ddlMetaPartnerSubTypeCode" tabIndex="3" runat="server" CssClass="FormNormal"></asp:DropDownList>
					<asp:CompareValidator id="valMetaPartnerSubTypeCode" ControlToValidate="ddlMetaPartnerSubTypeCode" EnableClientScript="False" Display="Dynamic" Runat="server" Type="String" ValueToCompare="0" Operator="NotEqual" ErrorMessage="Please select a value from the list." ></asp:CompareValidator>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblLocaleCodeDisplay" runat="server">Locale:</asp:Label></span></td>
				<td valign="top">
					<asp:DropDownList id="ddlLocaleCode" tabIndex="4" runat="server" CssClass="FormNormal"></asp:DropDownList>
					<asp:CompareValidator id="valLocaleCode" ControlToValidate="ddlLocaleCode" EnableClientScript="False" Display="Dynamic" Runat="server" Type="String" ValueToCompare="0" Operator="NotEqual" ErrorMessage="Please select a value from the list." ></asp:CompareValidator>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblCurrencyCodeDisplay" runat="server">Currency:</asp:Label></span></td>
				<td valign="top">
					<asp:DropDownList id="ddlCurrencyCode" tabIndex="5" runat="server" CssClass="FormNormal"></asp:DropDownList>
					<asp:CompareValidator id="valCurrencyCode" ControlToValidate="ddlCurrencyCode" EnableClientScript="False" Display="Dynamic" Runat="server" Type="String" ValueToCompare="0" Operator="NotEqual" ErrorMessage="Please select a value from the list." ></asp:CompareValidator>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblDateFormatCodeDisplay" runat="server">Date&nbsp;Format:</asp:Label></span></td>
				<td valign="top">
					<asp:DropDownList id="ddlDateFormatCode" tabIndex="6" runat="server" CssClass="FormNormal"></asp:DropDownList>
					<asp:CompareValidator id="valDateFormatCode" ControlToValidate="ddlDateFormatCode" EnableClientScript="False" Display="Dynamic" Runat="server" Type="String" ValueToCompare="0" Operator="NotEqual" ErrorMessage="Please select a value from the list." ></asp:CompareValidator>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblMetaPartnerNameDisplay" runat="server">Meta&nbsp;Partner&nbsp;Name:</asp:Label></span></td>
				<td valign="top">
					<asp:TextBox id="txtMetaPartnerName" tabIndex="7" runat="server" maxLength="255" Width="300" CssClass="FormNormal"></asp:TextBox>
					<asp:RequiredFieldValidator id="valMetaPartnerNameRequired" ControlToValidate="txtMetaPartnerName" EnableClientScript="False" Display="Dynamic" Runat="server" ErrorMessage="Please enter some text." ></asp:RequiredFieldValidator>
				</td>
			</tr>
		</table>
	</MODC:PageSection>
	<MODC:PageSection id="Section_Additional_Info" visible="false" runat="server">
		<table>
			<tr>
				<td valign="top"><span class="FormLabelOptional"><asp:Label ID="lblServiceChargesDisplay" runat="server">Service&nbsp;Charges:</asp:Label></span></td>
				<td valign="top">
					<asp:TextBox id="txtServiceCharges" tabIndex="8" runat="server" maxLength="255" Width="300" CssClass="FormNormal"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelOptional"><asp:Label ID="lblTaxCodeDisplay" runat="server">Tax&nbsp;Code:</asp:Label></span></td>
				<td valign="top">
					<asp:TextBox id="txtTaxCode" tabIndex="9" runat="server" maxLength="100" Width="150" CssClass="FormNormal"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelOptional"><asp:Label ID="lblIsActiveDisplay" runat="server">Is&nbsp;Active:</asp:Label></span></td>
				<td valign="top">
					<asp:CheckBox id="chkIsActive" tabIndex="10" runat="server" CssClass="FormNormal"></asp:CheckBox>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelOptional"><asp:Label ID="lblPictureImageURLDisplay" runat="server">Picture&nbsp;Image&nbsp;URL:</asp:Label></span></td>
				<td valign="top">
					<MOD:UploadableImage id="txtPictureImageURL" runat="server" DisplayName="Picture Image URL" ValidExtensions="jpg,jpeg" Required="false" FileGroup="Customers" Width="150" Height="150"></MOD:UploadableImage>
				</td>
			</tr>
		</table>
	</MODC:PageSection>
	<MODC:PageSection id="Section_Phones" visible="false" runat="server">
		<MOD:ListMetaPartnerPhoneData id="listMetaPartnerPhoneData" ListTitle="Phones" WorkflowMode="Internal" AccessMode="Add" DisplayMode="SingleView" RequiresAuthentication="true" runat="server"></MOD:ListMetaPartnerPhoneData>
	</MODC:PageSection>
	<MODC:PageSection id="Section_Emails" visible="false" runat="server">
		<MOD:ListMetaPartnerEmailData id="listMetaPartnerEmailData" ListTitle="Emails" WorkflowMode="Internal" AccessMode="Add" DisplayMode="SingleView" RequiresAuthentication="true" runat="server"></MOD:ListMetaPartnerEmailData>
	</MODC:PageSection>
	<MODC:PageSection id="Section_Locations" visible="false" runat="server">
		<MOD:ListLocationData id="listLocationData" ListTitle="Locations" WorkflowMode="Internal" AccessMode="Add" DisplayMode="SingleView" RequiresAuthentication="true" runat="server"></MOD:ListLocationData>
	</MODC:PageSection>
	<MODC:PageSection id="Section_Bank_Accounts" visible="false" runat="server">
		<MOD:ListBankAccountData id="listBankAccountData" ListTitle="Bank&nbsp;Accounts" WorkflowMode="Internal" AccessMode="Add" DisplayMode="SingleView" RequiresAuthentication="true" runat="server"></MOD:ListBankAccountData>
	</MODC:PageSection>
	<MODC:PageSection id="Section_Stored_Value_Accounts" visible="false" runat="server">
		<MOD:ListStoredValueAccountData id="listStoredValueAccountData" ListTitle="Stored&nbsp;Value&nbsp;Accounts" WorkflowMode="Internal" AccessMode="Add" DisplayMode="SingleView" RequiresAuthentication="true" runat="server"></MOD:ListStoredValueAccountData>
	</MODC:PageSection>
	<MODC:PageSection id="Section_Credit_Accounts" visible="false" runat="server">
		<MOD:ListCreditAccountData id="listCreditAccountData" ListTitle="Credit&nbsp;Accounts" WorkflowMode="Internal" AccessMode="Add" DisplayMode="SingleView" RequiresAuthentication="true" runat="server"></MOD:ListCreditAccountData>
	</MODC:PageSection>
	<MODC:PageSection id="Section_Fund_Accounts" visible="false" runat="server">
		<MOD:ListFundAccountData id="listFundAccountData" ListTitle="Fund&nbsp;Accounts" WorkflowMode="Internal" AccessMode="Add" DisplayMode="SingleView" RequiresAuthentication="true" runat="server"></MOD:ListFundAccountData>
	</MODC:PageSection>
	<MODC:PageSection id="Section_Bill_Pay_Accounts" visible="false" runat="server">
		<MOD:ListBillPayAccountData id="listBillPayAccountData" ListTitle="Bill&nbsp;Pay&nbsp;Accounts" WorkflowMode="Internal" AccessMode="Add" DisplayMode="SingleView" RequiresAuthentication="true" runat="server"></MOD:ListBillPayAccountData>
	</MODC:PageSection>
	<MODC:PageSection id="Section_Meta_Transfer_Accounts" visible="false" runat="server">
		<MOD:ListMetaTransferAccountData id="listMetaTransferAccountData" ListTitle="Meta&nbsp;Transfer&nbsp;Accounts" WorkflowMode="Internal" AccessMode="Add" DisplayMode="SingleView" RequiresAuthentication="true" runat="server"></MOD:ListMetaTransferAccountData>
	</MODC:PageSection>
	<MODC:PageSection id="Section_Loan_Accounts" visible="false" runat="server">
		<MOD:ListLoanAccountData id="listLoanAccountData" ListTitle="Loan&nbsp;Accounts" WorkflowMode="Internal" AccessMode="Add" DisplayMode="SingleView" RequiresAuthentication="true" runat="server"></MOD:ListLoanAccountData>
	</MODC:PageSection>
	<MODC:PageSection id="Section_Meta_Partner_Coupons" visible="false" runat="server">
		<MOD:ListMetaPartnerCouponData id="listMetaPartnerCouponData" ListTitle="Meta&nbsp;Partner&nbsp;Coupons" WorkflowMode="Internal" AccessMode="Add" DisplayMode="SingleView" RequiresAuthentication="true" runat="server"></MOD:ListMetaPartnerCouponData>
	</MODC:PageSection>
</wilson:masterpage>