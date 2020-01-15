<%@ Control Language="c#" Inherits="MW.MComm.Admin.WebUI.Templates.Desktop.PaginatedSearchControl" CodeFile="PaginatedSearchControl.ascx.cs" %>
<%@ Register TagPrefix="Wilson" Namespace="Wilson.MasterPages" Assembly="WilsonMasterPages" %>
<%@ Register TagPrefix="MOD" TagName="ListPager" SRC="~/UserControls/Desktop/Utility/ListPager.ascx" %>        
<div>
	<div class="PageTitle"><wilson:contentregion id="Title" runat="server"></wilson:contentregion></div>
    <div style="margin-bottom: 5px"></div>
    <div><wilson:contentregion id="Validation" runat="server"></wilson:contentregion></div>
	<div class="SearchActions">
	    <div class="Criteria"><wilson:contentregion id="Criteria" runat="server"></wilson:contentregion></div>
	    <div style="margin-bottom: 5px"></div>
	    <div class="Buttons"><wilson:contentregion id="Buttons" runat="server"></wilson:contentregion></div>
	    <div style="margin-bottom: 5px"></div>
	</div>
    <div class="SearchResults">
	    <wilson:contentregion id="SearchResultsTitle" runat="server">
	    <div class="Header">Search Results</div></wilson:contentregion>
        <wilson:contentregion id="Pager1" runat="server">
            <MOD:ListPager id="topPager" runat="server"></MOD:ListPager>
        </wilson:contentregion>
        <wilson:contentregion id="Content" runat="server"></wilson:contentregion>
        <wilson:contentregion id="Pager2" runat="server">
            <MOD:ListPager id="bottomPager" runat="server"></MOD:ListPager>
        </wilson:contentregion>
    </div>
    <div class="SearchResults">
        <wilson:contentregion id="WorkingSet" runat="server"></wilson:contentregion>
    </div>
	<div><wilson:contentregion id="Detail" runat="server"></wilson:contentregion></div>
</div>
<div class="HelpPosition">
    <wilson:contentregion id="Help" runat="server"></wilson:contentregion>
</div>