using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MW.MComm.SMS.WebService;
using MW.MComm.SMS.WebService.Messages;
using BLL = MW.MComm.SMS.BLL;
using MW.MComm.SMS.BLL.Messages;
using MOD.Data;
using Utility = MW.MComm.SMS.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using System.Data.SqlClient;

public partial class incoming : System.Web.UI.Page
{
  protected System.Data.SqlClient.SqlCommand cmdReceive;
  protected System.Data.SqlClient.SqlCommand cmdProcessed;
  Boolean connectionCreated = false;
  sessionHandler appData;
  protected void Page_Load(object sender, EventArgs e)
    {
      this.Response.ContentType = "text/plain"; //modify output type so it can be sent over SMS
      try
      {
        //local declares
        string sendr, receiver, smsConnection, smsContent;
        long internalId;
        //application data
        appData = (sessionHandler)Application["appData"];
        //-------------------------------------------------------------
        //sms comes over http GET querystring                         -
        //nowsms should be configured like this on 2 way settings     -
        //http://localhost:88/SMSwebServ/incoming.aspx?sender=@@SENDER@@&smsConnection=NowsmsBolViva1&receiver=@@RECIP@@&smsContent=@@FULLSMS@@
        //there are many more options for binary, no timplemented here-
        //-------------------------------------------------------------
        sendr = this.Request.QueryString["sender"];
        receiver = this.Request.QueryString["receiver"];
        smsConnection = this.Request.QueryString["smsConnection"];
        smsContent = this.Request.QueryString["smsContent"];
        if (sender == null || smsContent == null)
        {
          this.litResponse.Text = "invalid request format";
        }
        else
        {
          //---Log the message to the database and assign an ID
          this.initSQL();
          this.cmdReceive.Parameters["@sender"].Value = sendr;
          this.cmdReceive.Parameters["@receiver"].Value = receiver;
          this.cmdReceive.Parameters["@conId"].Value = smsConnection;
          this.cmdReceive.Parameters["@sms"].Value = smsContent;
          internalId = (long)this.cmdReceive.ExecuteScalar();
          appData.lastReceivedInternalID = internalId;
          //---push the message to it's destination
          if (appData.pushMode)
          {
            try
            {
              string processed;
              skill3.SMSwebServ.metawallet.smsTranslate.SMSTranslater push1 = new skill3.SMSwebServ.metawallet.smsTranslate.SMSTranslater();
              processed = push1.processSMS(internalId, sendr, receiver, smsContent, smsConnection);
              if (processed == "!")
              {
                this.cmdProcessed.Parameters["@Id"].Value = internalId;
                this.cmdProcessed.ExecuteNonQuery();
                this.litResponse.Text = appData.defaultSMSresponse.Replace("@@msgId@@", internalId.ToString());
              }
              else if (processed != string.Empty)
              {
                smsSender send1 = new smsSender();
                send1.sendSMS(receiver, sendr, processed);
                this.cmdProcessed.Parameters[0].Value = internalId;
                this.cmdProcessed.ExecuteNonQuery();
                this.litResponse.Text = processed;
                if (this.litResponse.Text.Length > 155) this.litResponse.Text = processed.Substring(0, 155);
              }

            }
            catch (Exception ex)
            {
              ex.ToString();
            }
          }
        }
      }
      catch(Exception ex)
      {
        this.litResponse.Text = ex.ToString();
      }
    }
  void initSQL()
  {
    this.cmdReceive = new System.Data.SqlClient.SqlCommand();
    this.cmdProcessed = new System.Data.SqlClient.SqlCommand();
    this.cmdReceive.Connection = new SqlConnection(appData.connectionString);
    this.cmdReceive.Connection.Open();
    this.cmdProcessed.Connection = this.cmdReceive.Connection;
    // 
    // cmdReceive
    // 
    this.cmdReceive.CommandText = "dbo.[SPreceived]";
    this.cmdReceive.CommandType = System.Data.CommandType.StoredProcedure;
    this.cmdReceive.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
    this.cmdReceive.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sender", System.Data.SqlDbType.VarChar, 15));
    this.cmdReceive.Parameters.Add(new System.Data.SqlClient.SqlParameter("@receiver", System.Data.SqlDbType.VarChar, 15));
    this.cmdReceive.Parameters.Add(new System.Data.SqlClient.SqlParameter("@conId", System.Data.SqlDbType.VarChar, 15));
    this.cmdReceive.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sms", System.Data.SqlDbType.VarChar, 170));
    // 
    // cmdProcessed
    // 
    this.cmdProcessed.CommandText = "dbo.[spProcessed]";
    this.cmdProcessed.CommandType = System.Data.CommandType.StoredProcedure;
    this.cmdProcessed.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
    this.cmdProcessed.Parameters.Add(new System.Data.SqlClient.SqlParameter("@id", System.Data.SqlDbType.BigInt, 8));
    this.Load += new System.EventHandler(this.Page_Load);
  }
}
