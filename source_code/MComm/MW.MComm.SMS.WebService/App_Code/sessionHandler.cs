

/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;

namespace MW.MComm.SMS.WebService
{
	/// <summary>
	/// stores application configuration and application level variables and objects
	/// </summary>
	public class sessionHandler
	{
		#region declares
		public bool useSMSresponseForErrorReporting=false; 
		public string outgoingNowSMSaddress,defaultSenderNumber,defaultSMSresponse,connectionString;
		public int outgoingNowSMStcPport,retainMessagesForPolling;
		public bool pushMode;
		public bool pollMode;
		private long _lastReceivedInternalID=0; //used for other applications to poll based on their last known internalID
		#endregion
		public static BLL.SortableList<BLL.Messages.IncomingSMS> IncomingQueue
		{
			get
			{
				BLL.SortableList<BLL.Messages.IncomingSMS> queue = (BLL.SortableList<BLL.Messages.IncomingSMS>)Globals.getAppCacheObject("IncomingQueue");

				// retrieve queue if not in application cache
				if (queue == null)
				{
					// not sure if this is accurate, should it be all unprocessed items in the queue
					queue = BLL.Messages.IncomingSMSManager.GetAllIncomingSMSDataByCriteria(null, null, false, null, null, null);
					Globals.setAppCacheObject("IncomingQueue", queue, Globals.DefaultMinutesInAppCache);
				}
				return queue;
			}
			set
			{
				// update queue and cache
				BLL.SortableList<BLL.Messages.IncomingSMS> queue = null;
				if (value == null)
				{
					queue = BLL.Messages.IncomingSMSManager.GetAllIncomingSMSDataByCriteria(null, null, false, null, null, null);
				}
				else
				{
					queue = value;
				}
				Globals.setAppCacheObject("IncomingQueue", queue, Globals.DefaultMinutesInAppCache);
			}
		}
		public static int IncomingQueueCount
		{
			get
			{
				// return incoming queue count
				return IncomingQueue.Count;
			}
		}
		public long lastReceivedInternalID
		{
			get
			{
				//if (this._lastReceivedInternalID==0)
				return this._lastReceivedInternalID;	
			}
			set
			{
				if (value>this._lastReceivedInternalID)
					this._lastReceivedInternalID=value;
			}
		}
		public sessionHandler() //initializer
		{
			System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
			this.useSMSresponseForErrorReporting = ((bool)(configurationAppSettings.GetValue("useSMSresponseForErrorReporting", typeof(bool))));
			this.defaultSMSresponse = ((string)(configurationAppSettings.GetValue("defaultSMSresponse", typeof(string))));
			this.outgoingNowSMSaddress = ((string)(configurationAppSettings.GetValue("outgoingNowSMSaddress", typeof(string))));
			this.defaultSenderNumber = ((string)(configurationAppSettings.GetValue("defaultSenderNumber", typeof(string))));
			this.outgoingNowSMStcPport = ((int)(configurationAppSettings.GetValue("outgoingNowSMStcPport", typeof(int))));
			this.retainMessagesForPolling = ((int)(configurationAppSettings.GetValue("retainMessagesForPolling", typeof(int))));
      this.connectionString = ((string)(configurationAppSettings.GetValue("DBConnectionString", typeof(string))));
			string pushORpoll;
			pushORpoll= ((string)(configurationAppSettings.GetValue("pushORpoll", typeof(string))));
			pushORpoll=pushORpoll.ToLower();
			if (pushORpoll=="push")
				pushMode=true;
			if (pushORpoll=="poll")
				pollMode=true;
		}
		public void holdSMS(long internalId,string sender,string receiver,string text,string connectionId)
		{
			if (IncomingQueueCount >= this.retainMessagesForPolling)
				return;

			try
			{
				// create new incoming message and save (internalID parameter suggests that an update can occur)
				BLL.Messages.IncomingSMS message = new BLL.Messages.IncomingSMS(internalId);
				message.IsProcessed = false;
				message.Sender = sender;
				message.Receiver = receiver;
				message.SMSContent = text;
				message.ConnectionID = connectionId;
				message.Save();

				// update queue
				IncomingQueue = null;
			}
			catch (System.Exception ex)
			{
				Utility.CustomAppException.HandleException(ex);
			}
		}
	}
}
