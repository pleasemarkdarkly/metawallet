
<!-- copyright
Meta Wallet, Inc (c) 2007 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2007, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
/copyright -->
<%@ Register TagPrefix="Wilson" Namespace="Wilson.MasterPages" Assembly="WilsonMasterPages" %>
<%@ Control Language="c#" AutoEventWireup="false" CodeFile ="EditUser.ascx.cs" Inherits="MW.MComm.Admin.WebUI.UserControls.Desktop.Users.EditUser" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="MOD" TagName="PageSectionLinks" Src="~/UserControls/Desktop/Utility/PageSectionLinks.ascx" %>
<%@ Register TagPrefix="MODC" Namespace="MW.MComm.Admin.WebUI.Controls"%>
<%@ Register TagPrefix="MOD" TagName="ListUserRoleUserData" Src="~/UserControls/Desktop/Users/ListUserRoleUserData.ascx" %>
<wilson:masterpage id="Masterpage" runat="server" templatefile="~/Templates/Desktop/DetailControl.ascx">
	<wilson:contentregion id="Title" runat="server">
		<asp:Label id="lblTitle" CssClass="subtitle" Runat="server">Edit User</asp:Label>&nbsp;<asp:Label id="lblTitleMessage" CssClass="subtitle" Runat="server"></asp:Label>
	</wilson:contentregion>
	<wilson:contentregion id="ItemInfo" runat="server">
		<div class="IDSection" id="ItemInfoContent" runat="server">
		<table>
			<tr>
				<td>User&nbsp;ID:</td>
				<td>
					<span class="ID">
					<MODC:PropVal id="propUserID" runat="server" prop="UserItem.UserID" cssclass="ID"></MODC:PropVal>
					</span>
				</td>
			</tr>
			<tr>
				<td>User&nbsp;Name:</td>
				<td>
					<span class="ID">
					<MODC:PropVal id="propUserName" runat="server" prop="UserItem.UserName" cssclass="ID"></MODC:PropVal>
					</span>
				</td>
			</tr>
		</table>
		</div>
	</wilson:contentregion>
	<wilson:contentregion id="DetailNavigation" runat="server">
		<div class="SectionLink" id="SectionLinkContent" runat="server">
		<MOD:PageSectionLinks id="sectionLinks" runat="server" CssClass="SectionLink" SelectedCssClass="selSectionLink" ValidationList="Basics,Additional_Info" SectionList="Basics,Additional_Info,User_Role_Users"></MOD:PageSectionLinks>
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
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblUserIDDisplay" runat="server">User&nbsp;ID:</asp:Label></span></td>
				<td valign="top">
					<asp:Label id="lblUserID" runat="server" CssClass="FormNormal"></asp:Label>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelRequired"><asp:Label ID="lblIsActiveDisplay" runat="server">Is&nbsp;Active:</asp:Label></span></td>
				<td valign="top">
					<asp:CheckBox id="chkIsActive" tabIndex="2" runat="server" CssClass="FormNormal"></asp:CheckBox>
				</td>
			</tr>
		</table>
	</MODC:PageSection>
	<MODC:PageSection id="Section_Additional_Info" visible="false" runat="server">
		<table>
			<tr>
				<td valign="top"><span class="FormLabelOptional"><asp:Label ID="lblUserNameDisplay" runat="server">User&nbsp;Name:</asp:Label></span></td>
				<td valign="top">
					<asp:TextBox id="txtUserName" tabIndex="3" runat="server" maxLength="50" Width="150" CssClass="FormNormal"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelOptional"><asp:Label ID="lblFirstNameDisplay" runat="server">First&nbsp;Name:</asp:Label></span></td>
				<td valign="top">
					<asp:TextBox id="txtFirstName" tabIndex="4" runat="server" maxLength="100" Width="150" CssClass="FormNormal"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelOptional"><asp:Label ID="lblLastNameDisplay" runat="server">Last&nbsp;Name:</asp:Label></span></td>
				<td valign="top">
					<asp:TextBox id="txtLastName" tabIndex="5" runat="server" maxLength="100" Width="150" CssClass="FormNormal"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelOptional"><asp:Label ID="lblPasswordDisplay" runat="server">Password:</asp:Label></span></td>
				<td valign="top">
					<asp:TextBox id="txtPassword" tabIndex="6" runat="server" maxLength="100" Width="150" CssClass="FormNormal" TextMode="Password"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td valign="top"><span class="FormLabelOptional"><asp:Label ID="lblLocaleCodeDisplay" runat="server">Locale:</asp:Label></span></td>
				<td valign="top">
					<asp:DropDownList id="ddlLocaleCode" tabIndex="7" runat="server" CssClass="FormNormal"></asp:DropDownList>
				</td>
			</tr>
		</table>
	</MODC:PageSection>
	<MODC:PageSection id="Section_User_Role_Users" visible="false" runat="server">
		<MOD:ListUserRoleUserData id="listUserRoleUserData" ListTitle="User&nbsp;Role&nbsp;Users" WorkflowMode="Internal" AccessMode="Add" DisplayMode="SingleView" RequiresAuthentication="true" runat="server"></MOD:ListUserRoleUserData>
	</MODC:PageSection>
</wilson:masterpage>