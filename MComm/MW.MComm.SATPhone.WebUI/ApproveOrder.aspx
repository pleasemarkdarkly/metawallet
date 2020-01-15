<%@ Page language="c#" EnableViewState="false" EnableEventValidation="false" CodeFile="ApproveOrder.aspx.cs" AutoEventWireup="false" Inherits="MW.MComm.SATPhone.WebUI.PayPhoneToPhone"%>
<satml>
    <card>
        <p>
        <h3>Aprobar el Pago</h3>
        <br /><b>PIN:</b>
        <input type="text" name="PIN" format="NNNNNNNN" value=""/>
        <br />
        <do type="accept" label="Aprobar">
           <go href="http://70.98.63.130/MW.MComm.SATPhone.WebUI/ApproveOrderResponse.aspx" method="post">
           <postfield name="OrderID" value="<%=Request.Form.Get("OrderID")%>"/>
           <postfield name="Origen" value="<%=Request.Form.Get("Origen")%>"/>
           <postfield name="PIN" value="$(PIN)"/>
           </go>
       </do>
        <do type="accept" label="Rechazar">
           <go href="http://70.98.63.130/MW.MComm.SATPhone.WebUI/RejectOrderResponse.aspx" method="post">
           <postfield name="OrderID" value="<%=Request.Form.Get("OrderID")%>"/>
           <postfield name="Origen" value="<%=Request.Form.Get("Origen")%>"/>
           <postfield name="PIN" value="$(PIN)"/>
           </go>
       </do>
       </p>
        <exit />
    </card>
</satml>
