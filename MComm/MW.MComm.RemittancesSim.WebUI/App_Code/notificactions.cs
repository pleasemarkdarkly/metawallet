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
/// <summary>
/// this is a temporary class to be replaced by the notificationGenerator of Wallet Solution
/// </summary>
namespace MW.MComm.RemittancesSim.WebUI
{
  public class notificactions
  {
    public notificactions()
    {
    }
    public static bool sendNotification(BLL.Customers.MetaPartnerPhone sender, BLL.Customers.MetaPartnerPhone receiver, string eventText)
    {
      try
      {
        if (receiver.CarrierMetaPartnerID == new Guid("bf8d2a88-10d7-46d2-8af1-7012e98d05de"))
        {
          MW.MComm.WalletSolution.MComm.SMS.SMSSender.smsSender sender1 = new MW.MComm.WalletSolution.MComm.SMS.SMSSender.smsSender();
          sender1.sendSMS(sender.PhoneNumber, receiver.PhoneNumber,
              eventText);
        }
        else
        {
          string phone = receiver.PhoneNumber;
          if (phone.Length == 10 & !phone.StartsWith("591"))
          {
            phone = "+1" + phone.Trim();
          }
          MW.MComm.WalletSolution.MComm.SMS.SMSSenderUSA.smsSender sender1 = new MW.MComm.WalletSolution.MComm.SMS.SMSSenderUSA.smsSender();
          sender1.sendSMS(sender.PhoneNumber, phone,
              eventText);
        }
        return true;
      }
      catch
      {
        return false;
      }
    }
    public static bool sendNotification(BLL.Customers.MetaPartnerPhone sender, string receiver, string eventText)
    {
      try
      {
        receiver = receiver.Trim();
        if ((receiver.Length == 8 & receiver.StartsWith("70")) || (receiver.Length == 10 & !receiver.StartsWith("591")))
        {
          if (receiver.Length == 8) receiver = "591" + receiver;
          MW.MComm.WalletSolution.MComm.SMS.SMSSender.smsSender sender1 = new MW.MComm.WalletSolution.MComm.SMS.SMSSender.smsSender();
          sender1.sendSMS("25", receiver,
              eventText);
        }
        else
        {
          {
            receiver = "+1" + receiver;
          }
          MW.MComm.WalletSolution.MComm.SMS.SMSSenderUSA.smsSender sender1 = new MW.MComm.WalletSolution.MComm.SMS.SMSSenderUSA.smsSender();
          sender1.sendSMS("25", receiver,
              eventText);
        }
        return true;
      }
      catch
      {
        return false;
      }
    }
    public static bool sendNotification(string sender, string receiver, string eventText)
    {
      try
      {
        receiver = receiver.Trim();
        if ((receiver.Length == 8 & receiver.StartsWith("70")) || (receiver.Length == 11 & receiver.StartsWith("591")))
        {
          if (receiver.Length == 8) receiver = "591" + receiver;
          MW.MComm.WalletSolution.MComm.SMS.SMSSender.smsSender sender1 = new MW.MComm.WalletSolution.MComm.SMS.SMSSender.smsSender();
          sender1.sendSMS("25", receiver,
              eventText);
        }
        else
        {
          {
            receiver = "+1" + receiver;
          }
          MW.MComm.WalletSolution.MComm.SMS.SMSSenderUSA.smsSender sender1 = new MW.MComm.WalletSolution.MComm.SMS.SMSSenderUSA.smsSender();
          sender1.sendSMS("25", receiver,
              eventText);
        }
        return true;
      }
      catch
      {
        return false;
      }
    }

  }
}