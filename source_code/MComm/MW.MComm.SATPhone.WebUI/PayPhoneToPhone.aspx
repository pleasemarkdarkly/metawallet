<%@ Page language="c#" ContentType="text/xml" ValidateRequest="false" EnableViewState="false" EnableEventValidation="false" CodeFile="PayPhoneToPhone.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.SATPhone.WebUI.PayPhoneToPhone"%>
<satml>
    <card>
        <p>
        <h3>Paga al Teléfono</h3>
        <b>Teléfono de Origen:</b>
        <input type="text" name="Origen" format="NNNNNNNN" value="70131278"/>
        <br /><b>Teléfono de Destino:</b>
        <input type="text" name="Destino" format="NNNNNNNN" value="59170066111"/>
        <br /><b>Monto (Bs.):</b>
        <input type="text" id="Monto" format="NNNNNNNN" value="10"/>
        <br />
        <do type="accept" label="Enviar">
           <go href="http://70.98.63.130/MW.MComm.SATPhone.WebUI/PayPhoneToPhoneResponse.aspx" method="post">
            <postfield name="Origen" value="$(Origen)"/>
            <postfield name="Destino" value="$(Destino)"/>
            <postfield name="Monto" value="$(Monto)"/>
            </go>
       </do>
       </p>
        <exit />
    </card>
</satml>
