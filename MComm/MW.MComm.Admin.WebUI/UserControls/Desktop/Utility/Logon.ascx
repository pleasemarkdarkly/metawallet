<%@ Control Language="c#" Inherits="MW.MComm.Admin.WebUI.UserControls.Desktop.Utility.Logon"
    CodeFile="Logon.ascx.cs" %>
<%@ Register TagPrefix="Wilson" Namespace="Wilson.MasterPages" Assembly="WilsonMasterPages" %>
<%@ Register TagPrefix="MODC" Namespace="MW.MComm.Admin.WebUI.Controls" %>
<%/* copyright
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
*/%>
<Wilson:MasterPage ID="Masterpage" TemplateFile="~/Templates/Desktop/DetailControl.ascx"
    runat="server">
	<wilson:contentregion id="Title" runat="server">mCommerce Administrator</wilson:contentregion>
	<wilson:contentregion id="Buttons" runat="server">
		<asp:linkbutton id="btnLogon" tabIndex="4" runat="server" CssClass="Button" onclick="btnLogon_Click">Login<span class="LoginIcon"></span></asp:linkbutton>
        <asp:linkbutton id="btnAgree" tabIndex="5" runat="server" CssClass="Button" onclick="btnAgree_Click" Visible="false">I Agree</asp:linkbutton>
	</wilson:contentregion>
	<asp:Panel runat="server" id="pnlLogin" Visible="true" DefaultButton="btnLogon">
	    <div class="Header">System Login</div>
	    <div class="Login">
		    <div class="BorderTop">
			    <asp:Image id="tlImg" ImageAlign="Top" BorderStyle="None" Height="6px" width="6px" ImageUrl="~/images/captionbox_corner_tl.gif"
				    Runat="server"></asp:Image>
			    <asp:Image id="Space1" runat="server" Height="2px" ImageUrl="~/images/blank.gif" Width="350px"></asp:Image>
			    <asp:Image id="trImg" ImageAlign="Top" BorderStyle="None" Height="6px" width="6px" ImageUrl="~/images/captionbox_corner_tr.gif"
				    Runat="server"></asp:Image></div>
		    <div class="Fields">
    			    <table>
				    <tr>
					    <td valign="top"><span class="FormLabelOptional">User Name:</span></td>
					    <td valign="top">
						    <asp:TextBox id="txtUserName" tabIndex="1" CssClass="FormNormal" Runat="server"></asp:TextBox><br/>
						    <asp:RequiredFieldValidator id="rq1" CssClass="errors" Runat="server" ErrorMessage="* Required field." Display="Dynamic"
							    ControlToValidate="txtUserName"></asp:RequiredFieldValidator></td>
				    </tr>
				    <tr>
					    <td valign="top"><span class="FormLabelOptional">Password:</span></td>
					    <td valign="top">
						    <asp:TextBox id="txtPassword" tabIndex="3" CssClass="FormNormal" Runat="server" TextMode="Password"></asp:TextBox><br/>
						    <asp:RequiredFieldValidator id="Requiredfieldvalidator2" CssClass="errors" Runat="server" ErrorMessage="* Required field."
							    Display="Dynamic" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
							<asp:Literal id="litLoggedIn" runat="server" Text="false" Visible="false"/>
							    </td>
				    </tr>
			    </table>
    			
    			
		    </div>
		    <div class="BorderBottom">
			    <asp:Image id="Image1" ImageAlign="Bottom" ImageUrl="~/images/captionbox_corner_bl.gif" Runat="server"></asp:Image>
			    <asp:Image id="Image2" runat="server" Height="2px" ImageUrl="~/images/blank.gif" Width="350px"></asp:Image>
			    <asp:Image id="Image3" ImageAlign="Bottom" ImageUrl="~/images/captionbox_corner_br.gif" Runat="server"></asp:Image></div>
	    </div>
	    
        <script type="text/javascript">
         
         function login_onload()
         {
            document.getElementById('_ctl0_cphContent_logon_txtUserName').focus();
            document.getElementById('_ctl0_cphContent_logon_txtPassword').attachEvent('onkeypress', password_onkeypress);
         }
         
        function password_onkeypress()
         {
            if(window.event.keyCode == 13)
            {
                    WebForm_DoPostBackWithOptions(      
                                new WebForm_PostBackOptions(
                                            "_ctl0:cphContent:logon:btnLogon", 
                                            "", 
                                            true, 
                                            "", 
                                            "", 
                                            false, 
                                            true ) );
            } 
         } 
         window.attachEvent('onload', login_onload);
         
        </script>
	</asp:Panel>
	<asp:Panel runat="server" id="pnlEula" Visible="false" DefaultButton="btnAgree">
	    <div class="EULA">
            <p>
            COPYRIGHT © 2006 METAWALLET, INC. ALL RIGHTS RESERVED
            </p>
            <p><b>NOTICE: YOU MUST READ AND AGREE TO THIS SOFTWARE LICENSE AGREEMENT (“AGREEMENT”) BEFORE USING THE SOFTWARE. BY EXECUTING THIS AGREEMENT, INSTALLING, COPYING OR USING THE SOFTWARE, YOU AGREE TO BE BOUND BY THE TERMS OF THIS AGREEMENT. IF YOU DO NOT AGREE WITH THE TERMS AND CONDITIONS OF THIS AGREEMENT, PROMPTLY RETURN THE SOFTWARE TO METAWALLET, INC. </b></p>
            <p>
            This evaluation license is valid for 30 days, as described in the “Term and Termination” Section below.</p>
            <p>The mCommerce 1.0 software provided to you under this Agreement includes computer software, and also includes any and all associated media, any and all accompanying documentation, and all other computer readable or readable materials that are provided to you by MetaWallet (collectively the “Software”). The Software is owned and distributed by MetaWallet, Inc. and its suppliers and is protected by copyright law and other U.S. and international intellectual property laws and treaties. You represent that you are authorized to enter into this Agreement. As an employee of an entity, you represent that you have the authority to enter into this Agreement on behalf of such entity and bind such entity to the terms of this Agreement. By executing this Agreement or by installing, utilizing, or copying the Software, you agree to the terms and conditions of this Agreement. The Software is licensed, not sold. MetaWallet, Inc. retains all right, title and interest in and to the Software except as granted herein. All rights not expressly granted by MetaWallet are reserved.</p>
            <p>
            1. GRANT OF EVALUATION LICENSE: MetaWallet grants you a no-charge, nonexclusive, non-transferable, revocable, limited trial license to use the Software solely for internal evaluation purposes. You may not use the Software for any development, commercial or production purpose or transfer this license to another party. 
            </p>
            <p>
            2. OWNERSHIP: The Software is the proprietary product of MetaWallet and is protected by copyright and other U.S and international intellectual property laws and treaties. You acquire only the right to use the Software and do not acquire any rights of ownership. You agree not to remove any product identification, copyright notices, or other notices or proprietary restrictions from the Software.
            </p>
            <p>
            3. RESTRICTIONS: You agree that access to the server interface of the Software shall be strictly limited to no more than five of your employees that have each entered into confidentiality agreements with you that are at least as protective of MetaWallet’ rights as the confidentiality obligations described in this Agreement (“Under NDA”). You further agree that access to the Software by means of the client interface shall be limited to no more than five clients at any time, that are in each case Under NDA. You may not use, copy, modify, or transfer the Software, or any copy thereof, in whole or in part, except as expressly provided for in this Agreement. You may not reverse engineer, disassemble, decompile, or translate the Software, or otherwise attempt to derive the source code of the Software, including without limitation reverse engineering the database scheme, network traffic or file system interaction. Any attempt to transfer any of the rights, duties or obligations hereunder void this License Agreement and your rights to use the Software. You may not rent, lease, loan, sell, resell, or distribute the Software, or any part thereof. You shall not disclose the results of any benchmark tests of the Software to any third party without MetaWallet’s prior written approval. You represent and warrant that you have not used or evaluated the Software prior to this Agreement. You further agree that you will not permit access to media files associated with the Software through any other application, and in no case through the “Interactive Mode.” REDISTRIBUTION OF THE SOFTWARE IS NOT PERMITTED. 
            </p>
            <p>
            4. TERM AND TERMINATION: This Agreement shall commence on the date you execute this Agreement and install the Software and continue until the earlier of thirty (30) days from such date, or termination of this agreement by MetaWallet as described below. If you do not obtain a separate paid license for the Software prior to the expiration or termination of this Agreement, then you agree to return any and all copies of the Software Program, return all applicable documentation and destroy any compact disc burned using the Software. If you elect to obtain a paid license for the Software prior to the expiration or termination of this Agreement, such license will be subject to and governed by a separate Software License Agreement. MetaWallet may terminate this Agreement and the license granted hereunder at any time for any or no reason in its sole discretion by notifying to you of such termination.
            </p>
            <p>
            5.  CONFIDENTIALITY AND SECURITY:</p>
            <p>
            5.1 Confidential Information. You acknowledge and agree that in connection with this Agreement you may have access to, and MetaWallet may disclose to you, certain valuable information belonging to and relating to MetaWallet which MetaWallet considers confidential, including without limitation, the Software and information concerning the software, and other trade secrets ("Confidential Information"). You agree not to disclose such Confidential Information to third parties or use such Confidential Information for any purpose other than your evaluation of the Software. You agree that you will not disclose that you are evaluating or testing or have evaluated or tested the Software to any third party without the prior written consent of MetaWallet.
            </p>
            <p>
            5.2 Exceptions. This Agreement shall impose no obligation of confidentiality upon you with respect to any portion of the Confidential Information which: (i) now or hereafter, through no act or failure to act on the your part, becomes generally known or available; (ii) is known to you at the time received from MetaWallet; (iii) is hereafter furnished to the you by a third party as a matter of right and without restriction on disclosure; or (iv) is furnished to others by MetaWallet without restriction on disclosure.
            </p>
            <p>
            5.3 Security. You acknowledge and agree that you are responsible for the security of the systems, server, content and media associated with the Software. You further agree that you will not copy any content associated with the Software and you represent and warrant that you have an existing license agreement in place with the copyright owner of such content that permits use of the content in connection with the evaluation of the Software.
            </p>
            <p>
            6. WARRANTY DISCLAIMER: METAWALLET PROVIDES THIS LICENSE ON AN "AS IS" BASIS WITHOUT WARRANTY OF ANY KIND. METAWALLET MAKES NO OTHER WARRANTIES, EITHER EXPRESS OR IMPLIED, REGARDING THE SOFTWARE, INCLUDING WITHOUT LIMITATION THE MERCHANTABILITY OR FITNESS FOR ANY PARTICULAR PURPOSE OR REGARDING ANY INTELLECTUAL PROPERTY INFRINGEMENT. METAWALLET DOES NOT WARRANT THAT THE SOFTWARE IS ERROR-FREE OR THAT ITS USE WILL NOT BE INTERRUPTED.
            </p>
            <p>
            7. LIMITATION OF LIABILITY: METAWALLET SHALL NOT BE LIABLE FOR ANY DAMAGES, INCLUDING DIRECT, INDIRECT, INCIDENTAL, SPECIAL OR CONSEQUENTIAL DAMAGES, OR DAMAGES FOR LOSS OR PROFITS, REVENUE, DATA OR DATA USE, INCURRED BY YOU OR ANY THIRD PARTY, WHETHER IN AN ACTION IN CONTRACT OR TORT, EVEN IF METAWALLET, YOU OR ANY OTHER PERSON HAS BEEN ADVISED OF THE POSSIBILITY OF SUCH DAMAGES. YOU ACKNOWLEDGE AND AGREE THAT THE FOREGOING DISCLAIMER OF WARRANTY AND LIMITATION OF LIABILITY IS A FUNDAMENTAL PART OF THE BASIS OF METAWALLET’ BARGAIN HEREUNDER, AND THAT METAWALLET WOULD NOT ENTER INTO THIS AGREEMENT ABSENT SUCH DISCLAIMER.
            </p>
            <p>
            8. EXPORT RESTRICTION. You agree that you will not directly or indirectly export, re-export, or transmit the Software or related technical data in any form to any country or to any national of such country to which such export or transmission is restricted by any applicable United States law, statute, or regulation. In addition, you agree that you will not directly or indirectly export, re-export, or transmit the Software or related technical data in any form to any country or to any national of such country without the prior written consent of the Bureau of Export Administration of the Department of Commerce of the United States Government, if required, and without the prior written consent of any other governmental agency which may have jurisdiction or control over such export, re-export, or transmission. 
            </p> 
            <p>
            9. U.S. GOVERNMENT LICENSE: Use, duplication, or disclosure by the U.S. Government is subject to restrictions as set forth in DFAR 252.227-7014(a)(1) The Software under this Agreement is "commercial computer software" as that term is described in DFAR 252.227-7014(a)(1). If the Software is being evaluated by or on behalf of a civilian agency, the U.S. Government evaluates this commercial computer software and/or commercial computer software documentation subject to the terms and this Agreement as specified in 48 C.F.R. 12.212 (Computer Software) and 12.11 (Technical Data) of the Federal Acquisition Regulations (“FAR”) and its successors. If evaluated by or on behalf of any agency within the Department of Defense (“DOD”), the U.S. Government evaluates this commercial computer software and/or commercial computer software documentation subject to the terms of this Agreement as specified in 48 C.F.R. 227.7202 of the DOD FAR Supplement and its successors.
            </p>
            <p>
            10. GENERAL: This Agreement shall be construed, interpreted, and governed by the laws of the State of Washington without regard to conflict of laws principles. The parties agree that the United Nations Convention on Contracts for the International Sale of Goods is specifically excluded from application to this Agreement. The parties agree that venue for any dispute arising under this Agreement will lie exclusively in the state or federal courts located in the State of Washington. This Agreement is the entire agreement between the parties, and there are no representations, warranties, covenants or understandings other than those expressly set forth herein. 
            </p> 
            <p>
            <b>By using the software, you indicate your agreement to the terms and conditions
            set forth herein.
            </b>  
            </p> 
        </div>
    </asp:Panel>

</Wilson:MasterPage>
