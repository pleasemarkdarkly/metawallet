<%@ Control Language="c#" EnableViewState="false" Inherits="MW.MComm.Phone.WebUI.Templates.Desktop.SearchControl" CodeFile="SearchControl.ascx.cs" %>
<%@ Register TagPrefix="Wilson" Namespace="Wilson.MasterPages" Assembly="WilsonMasterPages" %>
        


<div style="height:inherit; display:block;">
		<div class="PageTitle"><wilson:contentregion id="Title" runat="server"></wilson:contentregion></div>
        <div style="margin-bottom: 5px"></div>
        <div>
			<wilson:contentregion id="Validation" runat="server"></wilson:contentregion></div>
		<div class="SeacrhActions">
		    <div class="Criteria">		
			    <wilson:contentregion id="Criteria" runat="server"></wilson:contentregion></div>
		    <div style="margin-bottom: 5px"></div>
		    <div class="Buttons">	
			    <wilson:contentregion id="Buttons" runat="server"></wilson:contentregion></div>
		    <div style="margin-bottom: 5px"></div>
		</div>
		<div><wilson:contentregion id="Content" runat="server"></wilson:contentregion></div>
    <div class="SearchResults">
        <wilson:contentregion id="WorkingSet" runat="server"></wilson:contentregion>
    </div>
	<div><wilson:contentregion id="Detail" runat="server"></wilson:contentregion></div>

</div>

<div class="HelpPosition">
    <wilson:contentregion id="Help" runat="server"></wilson:contentregion>
</div>