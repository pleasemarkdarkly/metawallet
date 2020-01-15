<%@ Control Language="c#" EnableViewState="false" Inherits="MW.MComm.Phone.WebUI.Templates.Desktop.DetailControl" CodeFile="DetailControl.ascx.cs" %>
<%@ Register TagPrefix="Wilson" Namespace="Wilson.MasterPages" Assembly="WilsonMasterPages" %>
<table>
	<tr>
	    <td><h2><wilson:contentregion id="Title" runat="server"></wilson:contentregion></h2></td>
	</tr>
    <br />
    <tr>
        <td>
            <wilson:contentregion id="ItemInfo" runat="server"></wilson:contentregion>
        </td>
    </tr>
    <br />
	<tr>
	    <td>
		  <wilson:contentregion id="DetailNavigation" runat="server"></wilson:contentregion>
		</td>
    </tr>
	<tr>
	    <td>
			<wilson:contentregion id="Content" runat="server"></wilson:contentregion>
		<!-- end content -->	
		</td>
    </tr>
	<tr>
	    <td>
		    <wilson:contentregion id="Buttons" runat="server"></wilson:contentregion>
		</td>
    </tr>
</table>
<br />
<wilson:contentregion id="Help" runat="server"></wilson:contentregion>