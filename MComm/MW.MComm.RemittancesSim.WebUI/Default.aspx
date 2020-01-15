<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="MW.MComm.RemittancesSim.WebUI._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
  <link href="stylesheet.css" rel="stylesheet" type="text/css" />
</head>
<body style="font-size: 11pt; color: black; font-family: Arial" text="white">
    <form id="form1" runat="server">
    <div>
      &nbsp;<table id="tableMain" cellpadding="0" cellspacing="0" width="100%">
        <tr>
          <td align="center">
      <table align="left" border="0" cellpadding="0" cellspacing="0" style="padding-bottom: 10px;
        padding-top: 15px" width="730">
        <tbody>
          <tr valign="top">
            <td class="none" style="padding-top: 6px" width="365">
              <table align="left" border="0" cellpadding="0" cellspacing="0" width="365">
                <tbody>
                  <tr valign="top">
                    <td class="none" width="365">
                      <img alt="logo" height="54" src="template_files/logo.gif" width="163" /></td>
                  </tr>
                  <tr valign="middle">
                    <td class="tagline" style="padding-left: 47px" width="365">
                      Is that a vault in your pocket
                      <img align="top" alt="" height="15" src="template_files/tagline.gif" width="15" /></td>
                  </tr>
                </tbody>
              </table>
            </td>
            <td class="none" style="padding-top: 6px" width="365">
              <table align="right" border="0" cellpadding="0" cellspacing="0">
                <!--<tr valign="top">
						<td class="bodysmall"><span class="bodysmallbold">username@punto.com</span> | <a href="#" class="linklight" name="login">Sign Out</a></td>
						</tr>-->
                <tbody>
                  <tr valign="top">
                    <td class="bodysmall" style="padding-top: 5px">
                      Current user: Remittance Teller 1
                    </td>
                  </tr>
                </tbody>
              </table>
            </td>
          </tr>
        </tbody>
      </table>
          </td>
        </tr>
        <tr>
          <td align="center" style="background-image: url(images/tab_full_bkg.gif); height: 42px" valign="top">
            <table align="center" border="0" cellpadding="0" cellspacing="0" width="730">
              <tbody>
                <tr valign="top">
                  <td align="center" class="none">
                    <!-- Home -->
                    <table align="left" border="0" cellpadding="0" cellspacing="0">
                      <tbody>
                        <tr valign="top">
                          <td class="none" width="20">
                            <img alt="" border="0" height="28" src="images/tab_white_left.gif" width="20" /></td>
                          <td class="navgray" style="background-image: url(images/tab_white_bkg.gif); padding-top: 6px;
                            background-repeat: repeat-x">
                            Remittance System</td>
                          <td class="none" width="20">
                            <img alt="" border="0" height="28" src="template_files/tab_white_right.gif" width="20" /></td>
                        </tr>
                      </tbody>
                    </table>
                    <!-- Consumers -->
                    <table align="left" border="0" cellpadding="0" cellspacing="0">
                      <tbody>
                        <tr valign="top">
                          <td class="none" width="20">
                            <img alt="" border="0" height="28" src="template_files/tab_blue_left.gif" width="20" /></td>
                          <td class="navwhite" style="background-image: url(images/tab_blue_bkg.gif); padding-top: 6px;
                            background-repeat: repeat-x">
                            <a class="navwhite" href="http://www.metawallet.us/" name="consumers">Home</a></td>
                          <td class="none" width="20">
                            <img alt="" border="0" height="28" src="template_files/tab_blue_right.gif" width="20" /></td>
                        </tr>
                      </tbody>
                    </table>
                    <!-- Merchants -->
                    <!--<table border="0" cellpadding="0" cellspacing="0" align="left">
					
						<tr valign="top">
						<td width="20" class="none"><img src="img/tab_blue_left.gif" width="20" height="28" border="0" alt=""></td>
						<td class="navwhite" style="padding-top: 6px; background-image: url('img/tab_blue_bkg.gif'); background-repeat:repeat-x"><a href="merchants/index.htm" class="navwhite" name="merchants">Merchants</a></td>
						<td width="20" class="none"><img src="img/tab_blue_right.gif" width="20" height="28" border="0" alt=""></td>
						</tr>
					</table>	-->
                    <!-- Carriers -->
                    <!-- Banks -->
                    <!-- About -->
                    <!-- Contact -->
                    <table align="right" border="0" cellpadding="0" cellspacing="0" style="padding-top: 5px">
                      <tbody>
                        <tr valign="top">
                          <td align="right" class="footer" style="height: 21px">
                          </td>
                        </tr>
                      </tbody>
                    </table>
                  </td>
                </tr>
              </tbody>
            </table>
          </td>
        </tr>
        <tr>
          <td align="center" >
      <table width="100%" border="0" cellpadding="1" cellspacing="0" id="tableSearch">
        <tr >
          <td >
            &nbsp;</td>
          <td >
            &nbsp;</td>
        </tr>
        <tr>
          <td align="right" class="none">
            Search MetaWallet Customer (by phone number)</td>
          <td align="left">
            <asp:TextBox ID="textPhone" runat="server" MaxLength="11"></asp:TextBox>
            <asp:Button ID="cmdSearch" runat="server" OnClick="cmdSearch_Click" Text="Search" /></td>
        </tr>
        <tr>
          <td>
            &nbsp;</td>
          <td >
            &nbsp;</td>
        </tr>
      </table>
          </td>
        </tr>
        <tr>
          <td align="center" style="height: 35px" valign="middle">
            <asp:Label ID="lblFeedback" runat="server" BackColor="#FFFFC0" BorderColor="Black"
              BorderStyle="None" BorderWidth="1px" EnableViewState="False" Font-Bold="True" Font-Names="Arial"
              Font-Size="11pt" Height="26px" Width="300px"></asp:Label></td>
        </tr>
        <tr>
          <td align="center">
      <asp:Panel ID="panelCustomer" runat="server" Height="50px" Visible="False" Width="100%" OnPreRender="panelCustomer_PreRender">
        <table width="100%" border="0" cellpadding="1" cellspacing="0" class="none">
          <tr>
            <td align="right" >
              Customer found:</td>
            <td align="left" >
              <asp:Label ID="lblCustomerName" runat="server"></asp:Label></td>
          </tr>
          <tr>
            <td align="right">
              Availabe accounts:</td>
            <td align="left">
              <asp:RadioButtonList ID="listAccount" runat="server">
              </asp:RadioButtonList></td>
          </tr>
          <tr>
            <td align="right">
              Enter amount of cash received (US Dollars):</td>
            <td align="left">
              <asp:TextBox ID="textAmount" runat="server" MaxLength="11"></asp:TextBox></td>
          </tr>
          <tr>
            <td align="right">
              Sender's name:</td>
            <td align="left">
              <asp:TextBox ID="textSenderName" runat="server" Columns="20" MaxLength="50"></asp:TextBox></td>
          </tr>
          <tr>
            <td align="right">
              Memo:</td>
            <td align="left">
              <asp:TextBox ID="textMemo" runat="server" Columns="20" MaxLength="50"></asp:TextBox></td>
          </tr>
          <tr>
            <td>
            </td>
            <td >
              <asp:Button ID="btnSend" runat="server" Text="Send Remittance" OnClick="btnSend_Click" /></td>
          </tr>
        </table>
      </asp:Panel>
          </td>
        </tr>
        <tr>
          <td align="center" style="background-image: url(images/footer.gif); height: 20px">
          </td>
        </tr>
        <tr>
          <td align="center">
            <table align="center" border="0" cellpadding="0" cellspacing="0" style="padding-bottom: 20px"
              width="730">
              <tbody>
                <tr valign="top">
                  <td align="left" class="footer" style="padding-top: 10px" width="365">
                    © 2006 MetaWallet |<span class="footer" style="padding-top: 10px"><a class="linksmall"
                      href="file://///dotshare/Metawallet/Projects/WebSite/about.htm" name="about">About</a></span></td>
                  <td align="right" class="footer" style="padding-top: 10px" width="365">
                    <a class="linksmall" href="file://///dotshare/Metawallet/Projects/WebSite/metawallet.com/terms.htm"
                      name="terms">Terms &amp; Conditions</a> | <a class="linksmall" href="file://///dotshare/Metawallet/Projects/WebSite/metawallet.com/privacy.htm"
                        name="privacy">Privacy</a></td>
                </tr>
              </tbody>
            </table>
          </td>
        </tr>
      </table>
    </div>
    </form>
</body>
</html>
