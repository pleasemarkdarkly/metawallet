using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using BLL = MW.MComm.WalletSolution.BLL;
using MW.MComm.WalletSolution.BLL.UserExperience;
namespace MW.MComm.WMLPhone.WebUI
{
  /// <summary>
  /// this single-purpose class is to be used on each page
  /// to validate the session. Custom validation logic is used
  /// to check for physical use of an specific phone in adition to
  /// a login (phone number) and password (PIN)
  /// 
  /// If the validation fails, the user will be redirected to the login
  /// page and the page that created the mobilesession class wil be truncated
  /// 
  /// Validation of existing sessions is done with the object at page.Session["Customer/MetaPartnerID"]
  /// 
  /// Validation of newly initiated sessions id done trough the querystring
  /// of the pushed link wich should contain the metapartner phone id 
  /// and an expiration date
  /// </summary>
  public class mobileSession
  {
    public BLL.Customers.MetaPartnerPhone MetaPartnerPhone;
    public BLL.Customers.MetaPartner MetaPartner;
    public Guid SelectedAccountId;
    public void validate(System.Web.UI.MobileControls.MobilePage page)
    {     
     if (page.Session["Customer/MetaPartnerPhoneID"] == null)
      {
        //tere is no session information, look for a newly received login
        //via querystring
        try
        {
          string partnerPhoneID, expDateString;
          DateTime expDate;
          partnerPhoneID = page.Request.QueryString["sid"];
          //the expiration date is pased trough the querystring
          //using a binary representation to avoid date and time format
          //and regional settings issues
          expDateString = page.Request.QueryString["exp"];
          expDate = mobileSession.string2date(expDateString);
          if (expDate < DateTime.Now)
            //if the link the user has clicked on is too old (10 minutes by default)
            //raise an exception that and cause the session to end and redirect to 
            //the login page

              //[20070622 SBA] Reemplazo  
            throw new Exception("Link expired");
            //  throw new Exception(Globals.GetSiteLabel(SiteLabelDefinitionCode.LinkExpired));

          //if no problems were detected up to this point, store the metapartnerphone ID
          //as a session variable for use in other pages or call backs to this page
          //Store the metapartnerphone object as an attribute of this object to
          //facilitate access to the most frequently used information.
          this.MetaPartnerPhone =
              BLL.Customers.MetaPartnerPhoneManager.GetOneMetaPartnerPhone(
              new System.Guid(partnerPhoneID));
          page.Session["Customer/MetaPartnerPhoneID"] = this.MetaPartnerPhone.MetaPartnerPhoneID;
          this.setGlobalUser();
        }
        catch
        {
          page.Session["Customer/MetaPartnerPhoneID"] = null;
          page.RedirectToMobilePage("./login.aspx?logout=true", true);
        }
      }
      else
      {
        this.MetaPartnerPhone = BLL.Customers.MetaPartnerPhoneManager.GetOneMetaPartnerPhone(
            (System.Guid)page.Session["Customer/MetaPartnerPhoneID"]);
        if (Globals.CurrentPartner == null) this.setGlobalUser();
        if (this.MetaPartnerPhone == null)
        {   //the meta partner data is unavailabe, kill the session, redirect to the login page
          page.Session["Customer/MetaPartnerPhoneID"] = null;
          page.RedirectToMobilePage("./login.aspx?logout=true", true);
        }
      }
    }
    public mobileSession()
    {
    }
    public void setGlobalUser()
    {
      try
      {
        BLL.Customers.MetaPartner partner =
            BLL.Customers.MetaPartnerManager.GetOneMetaPartner(this.MetaPartnerPhone.MetaPartnerID);
        Globals.CurrentPhone = this.MetaPartnerPhone;
        Globals.CurrentPartner = partner;
      }
      catch
      {
      }
    }
    public static string date2string(DateTime d1)
    {
      string s1 = d1.Year.ToString("0000").Substring(2, 2);
      s1 += d1.Month.ToString("00") + d1.Day.ToString("00") + d1.Hour.ToString("00") + d1.Minute.ToString("00");
      return s1;
    }
    public static DateTime string2date(string s1)
    {
      string sy, sm, sd, sh, smi;
      int iy, im, id, ih, imi;
      sy = s1.Substring(0, 2);
      sm = s1.Substring(2, 2);
      sd = s1.Substring(4, 2);
      sh = s1.Substring(6, 2);
      smi = s1.Substring(8, 2);
      iy = 2000 + int.Parse(sy);
      im = int.Parse(sm);
      id = int.Parse(sd);
      ih = int.Parse(sh);
      imi = int.Parse(smi);
      DateTime d1 = new DateTime(iy, im, id, ih, imi, 0);
      return d1;
    }
  }
}