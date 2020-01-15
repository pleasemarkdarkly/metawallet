<%@ Page language="c#" EnableViewState="false" EnableEventValidation="false" CodeFile="ApproveOrderResponse.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.SATPhone.WebUI.PayPhoneToPhone"%>
<satml>
    <card>
        <p>
        <h3>Respuesta de Aprobar el Pago</h3>
        <br /><asp:Literal id="txtStatus" runat="server"></asp:Literal>
        <do type="accept" label="Página Anterior">
            <prev />
        </do>
        </p>
        <exit />
    </card>
</satml>
