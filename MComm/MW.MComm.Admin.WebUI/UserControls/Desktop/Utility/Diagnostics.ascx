<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Diagnostics.ascx.cs" Inherits="UserControls_Desktop_Utility_Diagnostics" %>
<script type="text/javascript">
function ToggleDiagnostics()
{
    var div = document.getElementById('Diagnostics');
    
    if (div.style.visibility == 'hidden')
        div.style.visibility = 'visible';
    else
        div.style.visibility = 'hidden';
}
</script>
<span onclick="javascript:ToggleDiagnostics();" style="margin:0px 50px 150px 220px;text-decoration: underline;">Diagnostics</span>
<div id="Diagnostics" style="visibility: hidden;">
    Active Configuration<br />
    (Context: <asp:Label runat="server" ID="lblConfigurationContext" />)<br />
    <br />
    <asp:GridView ID="gvConfiguration" runat="server" AutoGenerateColumns="false" BorderColor="White" BorderStyle="None">
        <Columns>
            <asp:BoundField DataField="Source" HeaderText="Source" />
            <asp:BoundField DataField="Key" HeaderText="Key" />
            <asp:TemplateField HeaderText="Value (hover to see full value)">
                <ItemTemplate>
                    <span title="<%# Eval("Value") %>">
                        <%# Eval("TruncatedValue") %>
                    </span>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />
    Cookies
    <asp:GridView ID="gvCookies" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Key" HeaderText="Name" />
            <asp:TemplateField HeaderText="Value (hover to see full value)">
                <ItemTemplate>
                    <span title="<%# Eval("Value") %>">
                        <%# Eval("TruncatedValue") %>
                    </span>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />
    Add/Change Cookie:&nbsp;<br />
    Key: &nbsp;<asp:TextBox ID="txtKey" runat="server"></asp:TextBox>
    Value: &nbsp;<asp:TextBox ID="txtValue" runat="server"></asp:TextBox>
    <asp:Button ID="btnSaveCookie" runat="server" Text="Save" OnClick="btnSaveCookie_Click" />
</div>
