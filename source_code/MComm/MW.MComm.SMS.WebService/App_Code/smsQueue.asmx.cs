

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
	// ------------------------------------------------------------------------------
	/// <summary>
	/// exposes a method for counting the ammount of unprocessed received messages and a method for
	/// receiving such messages in a strongly typed dataset
	/// </summary>
	///
	/// File History:
	/// <created>10/24/2006 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[WebService(Namespace = "http://skill3.com/webservices/sms2006/")]
	public class smsQueue : System.Web.Services.WebService
	{
		sessionHandler appData;

		#region "Service Methods"

		// ------------------------------------------------------------------
		/// <summary>
		// Return the incoming sms queue count.
		/// </summary>
		///
		// ------------------------------------------------------------------
		[WebMethod]
		public int queueSize()
		{
			return sessionHandler.IncomingQueueCount;
		}

		// ------------------------------------------------------------------
		/// <summary>
		// Poll the sms queue.
		/// </summary>
		///
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Messages.IncomingSMSResults pollSMS()
		{
			Components.Messages.IncomingSMSResults status = new Components.Messages.IncomingSMSResults();
			status.StatusDescription = "Results OK";
			try
			{
				// should this just look at the queue or also update it?
				status.Results = sessionHandler.IncomingQueue;
			}
			catch (System.Exception ex)
			{
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

		// ------------------------------------------------------------------
		/// <summary>
		// Retrieve an sms message from the queue.
		/// </summary>
		///
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Messages.IncomingSMSResults retrieveOneSms()
		{
			Components.Messages.IncomingSMSResults status = new Components.Messages.IncomingSMSResults();
			status.StatusDescription = "Results OK";
			try
			{
				if (sessionHandler.IncomingQueue.Count > 0)
				{
					BLL.SortableList<BLL.Messages.IncomingSMS> queue = sessionHandler.IncomingQueue;
					BLL.Messages.IncomingSMS sms1 = queue[0];
					queue.Remove(queue[0]);
					sessionHandler.IncomingQueue = queue;
					status.Results.Add(sms1);
				}
				else
				{
					status.Results.Add(new BLL.Messages.IncomingSMS());
				}
			}
			catch (System.Exception ex)
			{
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
		public smsQueue()
		{
			//
			// constructor logic
			//
			InitializeComponent();
			appData = (sessionHandler)Application["appData"];
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
		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#endregion "Miscellaneous"
	}
}
