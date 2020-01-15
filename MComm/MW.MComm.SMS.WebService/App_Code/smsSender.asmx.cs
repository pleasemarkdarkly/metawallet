

/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using MW.MComm.SMS.WebService;
using MW.MComm.SMS.WebService.Messages;
using BLL = MW.MComm.SMS.BLL;
using MW.MComm.SMS.BLL.Messages;
using MOD.Data;
using Utility = MW.MComm.SMS.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace MW.MComm.SMS.WebService
{
	// ------------------------------------------------------------------------------
	/// <summary>
	/// Simple sms sending web service, exposes Now SMS over a standard XML web service interface
	/// </summary>
	///
	/// File History:
	/// <created>10/24/2006 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[WebService(Namespace="http://skill3.com/webservices/sms2006/")]
	public class smsSender : System.Web.Services.WebService
	{
		#region "Service Methods"

		// ------------------------------------------------------------------
		/// <summary>
		// sends an sms message over Now SMS, logs it to the database and returns teh internal sequence number
		// if it fails, it returns a negative number
		// -1 error loging to the database before sending
		// -2 error sending
		// -3 error logging the sent response to the database
		/// </summary>
		///
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Messages.OutgoingSMSResults sendSMS(string sender, string receiver, string text)
		{
			Components.Messages.OutgoingSMSResults status = new Components.Messages.OutgoingSMSResults();
			status.StatusDescription = "Results OK";
			sessionHandler appData;
			try
			{
				appData = (sessionHandler)Application["appData"];
				string url = "http://@@serv@@:@@port@@/Send%20Text%20Message.htm?PhoneNumber=@@rece@@" +
					"&Text=@@smsT@@&InfoCharCounter=&PID=&DCS=&Submit=Submit&sender=@@send@@";
				if (sender == string.Empty)
					sender = appData.defaultSenderNumber;
				url = url.Replace("@@serv@@", appData.outgoingNowSMSaddress);
				url = url.Replace("@@port@@", appData.outgoingNowSMStcPport.ToString());
				url = url.Replace("@@rece@@", receiver);
				url = url.Replace("@@send@@", sender);
				url = url.Replace("@@smsT@@", text);

				// build outgoing message and save to database
				BLL.Messages.OutgoingSMS message = new OutgoingSMS();
				message.Sender = sender;
				message.Receiver = receiver;
				message.NowSMSServer = appData.outgoingNowSMSaddress + ":" + appData.outgoingNowSMStcPport.ToString();
				message.SMSContent = text;
				message.Save();

				//hasta aqui se logeo lo que se va a intentar enviar
				//proceder al envío
				System.Net.WebClient webC = new System.Net.WebClient();
				byte[] response;
				char[] responseC;
				string responseS = string.Empty;
				try
				{
					response = webC.DownloadData(url);
					ASCIIEncoding AE = new ASCIIEncoding();
					responseC = AE.GetChars(response);
					foreach (char c1 in responseC)
					{
						responseS += c1;
					}
					//the response is an html doccument. strip it of html headers in order to save the usable text
					if (responseS.StartsWith("<HTML>") & responseS.Length > 161)
					{
						responseS = responseS.Substring(161);
						if (responseS.IndexOf("") > -1)
						{

						}
					}
					if (responseS.Length > 255) responseS = responseS.Substring(0, 255);
					message.ServerResponse = responseS;

					try
					{
						// save outgoing message with response
						message.Save();
					}
					catch (System.Exception ex)
					{
						Utility.CustomAppException.HandleException(ex);
						status.StatusCode = -3;
						string exceptionMessage = "";
						System.Exception messageEx = ex;
						while (messageEx != null)
						{
							exceptionMessage += System.Environment.NewLine + messageEx.Message;
							messageEx = messageEx.InnerException;
						}
						status.StatusDescription = exceptionMessage;
					}
				}
				catch (System.Exception ex)
				{
					Utility.CustomAppException.HandleException(ex);
					status.StatusCode = - 2;
					string exceptionMessage = "";
					System.Exception messageEx = ex;
					while (messageEx != null)
					{
						exceptionMessage += System.Environment.NewLine + messageEx.Message;
						messageEx = messageEx.InnerException;
					}
					status.StatusDescription = exceptionMessage;
				}
			}
			catch (System.Exception ex)
			{
				Utility.CustomAppException.HandleException(ex);
				status.StatusCode = -1;
				string exceptionMessage = "";
				System.Exception messageEx = ex;
				while (messageEx != null)
				{
					exceptionMessage += System.Environment.NewLine + messageEx.Message;
					messageEx = messageEx.InnerException;
				}
				status.StatusDescription = exceptionMessage;
			}
			finally
			{
			}
			return status;
		}
        [WebMethod]
        public Components.Messages.OutgoingSMSResults pushWAP(string sender, string receiver, string text, string WapUrl)
        {
            Components.Messages.OutgoingSMSResults status = new Components.Messages.OutgoingSMSResults();
            status.StatusDescription = "Results OK";
            sessionHandler appData;
            try
            {
                appData = (sessionHandler)Application["appData"];
                string url ;//= "http://@@serv@@:@@port@@/Send%20Text%20Message.htm?PhoneNumber=@@rece@@" +
                    //"&Text=@@smsT@@&InfoCharCounter=&PID=&DCS=&Submit=Submit&sender=@@send@@";
                url = "http://@@serv@@:@@port@@/Send%20WAP%20Push%20Message.htm?" + 
                    "WAPSL=&PhoneNumber=@@rece@@&WAPURL=@@WapUrl@@" + 
                    "&Text=@@smsT@@&WAPSIACTION=signal-medium&WAPSIID=&WAPSICREATED=" +
                    "&WAPSIEXPIRES=&Submit=Submit&sender=@@send@@";
                if (sender == string.Empty)
                    sender = appData.defaultSenderNumber;
                url = url.Replace("@@serv@@", appData.outgoingNowSMSaddress);
                url = url.Replace("@@port@@", appData.outgoingNowSMStcPport.ToString());
                url = url.Replace("@@rece@@", receiver);
                url = url.Replace("@@send@@", sender);
                url = url.Replace("@@smsT@@", text); 
                WapUrl = WapUrl.Replace(":", "%3A");
                WapUrl = WapUrl.Replace("/", "%2f");
                WapUrl = WapUrl.Replace("?", "%3f");
                WapUrl = WapUrl.Replace("=", "%3d");
                WapUrl = WapUrl.Replace("&", "%26");
                url = url.Replace("@@WapUrl@@", WapUrl);
                // build outgoing message and save to database
                BLL.Messages.OutgoingSMS message = new OutgoingSMS();
                message.Sender = sender;
                message.Receiver = receiver;
                message.NowSMSServer = appData.outgoingNowSMSaddress + ":" + appData.outgoingNowSMStcPport.ToString();
                message.SMSContent = text;
                message.Save();

                //hasta aqui se logeo lo que se va a intentar enviar
                //proceder al envío
                System.Net.WebClient webC = new System.Net.WebClient();
                byte[] response;
                char[] responseC;
                string responseS = string.Empty;
                try
                {
                    response = webC.DownloadData(url);
                    ASCIIEncoding AE = new ASCIIEncoding();
                    responseC = AE.GetChars(response);
                    foreach (char c1 in responseC)
                    {
                        responseS += c1;
                    }
                    //the response is an html doccument. strip it of html headers in order to save the usable text
                    if (responseS.StartsWith("<HTML>") & responseS.Length > 161)
                    {
                        responseS = responseS.Substring(161);
                        if (responseS.IndexOf("") > -1)
                        {

                        }
                    }
                    if (responseS.Length > 255) responseS = responseS.Substring(0, 255);
                    message.ServerResponse = responseS;

                    try
                    {
                        // save outgoing message with response
                        message.Save();
                    }
                    catch (System.Exception ex)
                    {
                        Utility.CustomAppException.HandleException(ex);
                        status.StatusCode = -3;
                        string exceptionMessage = "";
                        System.Exception messageEx = ex;
                        while (messageEx != null)
                        {
                            exceptionMessage += System.Environment.NewLine + messageEx.Message;
                            messageEx = messageEx.InnerException;
                        }
                        status.StatusDescription = exceptionMessage;
                    }
                }
                catch (System.Exception ex)
                {
                    Utility.CustomAppException.HandleException(ex);
                    status.StatusCode = -2;
                    string exceptionMessage = "";
                    System.Exception messageEx = ex;
                    while (messageEx != null)
                    {
                        exceptionMessage += System.Environment.NewLine + messageEx.Message;
                        messageEx = messageEx.InnerException;
                    }
                    status.StatusDescription = exceptionMessage;
                }
            }
            catch (System.Exception ex)
            {
                Utility.CustomAppException.HandleException(ex);
                status.StatusCode = -1;
                string exceptionMessage = "";
                System.Exception messageEx = ex;
                while (messageEx != null)
                {
                    exceptionMessage += System.Environment.NewLine + messageEx.Message;
                    messageEx = messageEx.InnerException;
                }
                status.StatusDescription = exceptionMessage;
            }
            finally
            {
            }
            return status;
        }

		#endregion "Service Methods"

		#region "Miscellaneous"
		// ------------------------------------------------------------------------------
		/// <summary>This web service method is the constructor.</summary>
		// ------------------------------------------------------------------------------
		public smsSender()
		{
			//
			// constructor logic
			//
			InitializeComponent();
		}

			//Required by the Web Services Designer
			private IContainer components = null;

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if(disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#endregion "Miscellaneous"
	}
}
