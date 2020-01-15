<%/* copyright
MOD Systems, Inc (c) 2006 All Rights Reserved. 
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036 
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by MOD Systems.  The contents may only be viewed by MOD Systems Engineers (employees) and selected Starbucks employees as outlined in the Licensing Agreement between MOD Systems and Starbucks Corporation on June 3rd, 2005.   
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.  
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact MOD System's competitive advantage.   
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.   
*/%>
<asp:TreeView ID="tvPrimaryNav" runat="server"  ExpandDepth="0" EnableClientScript="False" 
    onclick="javascript:return PromptToDiscardChanges();"
    ImageSet="Arrows" OnSelectedNodeChanged="tvPrimaryNav_SelectedNodeChanged" OnTreeNodeDataBound="tvPrimaryNav_TreeNodeDataBound">
    <ParentNodeStyle Font-Bold="False" />
    <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
    <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD"
        HorizontalPadding="0px" VerticalPadding="0px" />
    <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
        NodeSpacing="0px" VerticalPadding="0px" />
    <DataBindings>
        <asp:TreeNodeBinding DataMember="item" TextField="name" ValueField="url" />
    </DataBindings>
</asp:TreeView>


<%@ Control Language="c#" Inherits="MW.MComm.Admin.WebUI.UserControls.Desktop.navigation.PrimaryNav" CodeFile="PrimaryNav.ascx.cs" %>