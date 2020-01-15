<!-- copyright
MOD Systems, Inc (c) 2006 All Rights Reserved. 
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036 

All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by MOD Systems.  The contents may only be viewed by MOD Systems Engineers (employees) and selected Starbucks employees as outlined in the Licensing Agreement between MOD Systems and Starbucks Corporation on June 3rd, 2005.   

No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.  

No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact MOD System's competitive advantage.   

Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.   


/copyright -->

<%@ Control Language="c#" Inherits="MW.MComm.Admin.WebUI.Templates.Desktop.SearchControlPlus" CodeFile="SearchControlPlus.ascx.cs" %>
<%@ Register TagPrefix="Wilson" Namespace="Wilson.MasterPages" Assembly="WilsonMasterPages" %>
<script>
  HelpMgr.register('HelpContent_SearchControlPlus');
</script>         


<table cellspacing=7>
	<tr>
		<td valign="bottom">
			<div class="PageTitle"><wilson:contentregion id="Title" runat="server"></wilson:contentregion></div>
		</td>
		<td valign="top" width=230><wilson:contentregion id="Links" runat="server"></wilson:contentregion></td>
	</tr>
	<tr>
		<td>
			<wilson:contentregion id="Validation" runat="server"></wilson:contentregion>
		</td>
		<td valign="top" width=230 rowspan="20">
				  <div style="display: none; width: 235px" id="HelpContent_SearchControlPlus">
				 <wilson:contentregion id="Help" runat="server"></wilson:contentregion></div>
		</td>	
	</tr>
	<tr>
		<td>		
			<wilson:contentregion id="Criteria" runat="server"></wilson:contentregion>
			
		</td>
	</tr>

	<tr>
		<td>	
			<wilson:contentregion id="Buttons" runat="server"></wilson:contentregion>
		</td>
	</tr>

	<tr>
		<td valign="top">
		  <wilson:contentregion id="Content" runat="server"></wilson:contentregion></td>
	</tr>
	    <div class="SearchResults">
        <wilson:contentregion id="WorkingSet" runat="server"></wilson:contentregion>
    </div>
	<div><wilson:contentregion id="Detail" runat="server"></wilson:contentregion></div>

</table>
