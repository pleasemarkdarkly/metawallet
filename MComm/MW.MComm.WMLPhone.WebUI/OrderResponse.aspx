<%@ Page language="c#" ContentType="text/xml" ValidateRequest="false" EnableViewState="false" EnableEventValidation="false" CodeFile="OrderResponse.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.WMLPhone.WebUI.OrderResponse"%>
<Mobile:Form ID="Form1" runat="server">
    <p><Mobile:Image id=imgLogo runat=server>
        <DeviceSpecific>
            <Choice ImageURL="images/metawalletlogo.gif" />
            <Choice ImageURL="images/metawalletlogo.wbmp" />
        </DeviceSpecific>
    </Mobile:Image><big><b><Mobile:Label id=lblHeader runat=server></Mobile:Label></b></big><br />
    <small><i><Mobile:Label id=lblTagline runat=server></Mobile:Label></i></small></p>
        <p>
        <big><b><Mobile:Label id=lblOrderTitle runat=server></Mobile:Label></b></big>
        </p>
        <p>
        <Mobile:Label id=lblOrderDetail runat=server></Mobile:Label>
        <b><Mobile:Label id=lblPIN runat=server></Mobile:Label></b>
        <Mobile:TextBox runat=server id=txtPIN></Mobile:TextBox>
        <Mobile:Command runat=server id=btnSubmit></Mobile:Command>
       </p>
       <Mobile:Label id=lblStatus runat=server></Mobile:Label>
    <Mobile:Link id=lblSendReceive runat=server navigateurl="order.aspx"></Mobile:Link>
    <Mobile:Link id=lblAccountsLink runat=server navigateurl="accounts.aspx"></Mobile:Link>
    <Mobile:Link id=lblPreferences runat=server navigateurl="preferences.aspx"></Mobile:Link>
    <Mobile:Link id=lblNewAccountLink runat=server navigateurl="setup.aspx"></Mobile:Link>
    <Mobile:Link id=lblHelpLink runat=server navigateurl="help.aspx"></Mobile:Link>
</Mobile:Form>