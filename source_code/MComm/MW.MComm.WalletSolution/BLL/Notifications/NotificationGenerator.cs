
/*<copyright>
	MOD Systems, Inc (c) 2006 All Rights Reserved.
	720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
	All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by MOD Systems.  The contents also may only be viewed by MOD Systems Engineers (employees) and selected Starbucks employees as outlined in the Licensing Agreement between MOD Systems and Starbucks Corporation on June 3rd, 2005.
	No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
	No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact MOD System's competitive advantage.
	Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/
using System;
using System.ComponentModel;
using System.Web;
using BLL = MW.MComm.WalletSolution.BLL;
using MW.MComm.WalletSolution.BLL.Notifications;
using MOD.Data;
using MW.MComm.WalletSolution.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
namespace MW.MComm.WalletSolution.BLL.Notifications
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage Notification related information.</summary>
	///
	/// File History:
	/// 3/6/2006 <created> (Dave Clemmer)
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public class NotificationGenerator
	{
		#region "Public Static Methods"
		// ------------------------------------------------------------------
		/// <summary>This method sends all notifications for an event.</summary>
		///
		/// <param name="eventCode">Event to send notification for.</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in DAL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static MOD.Data.NamedObjectCollection SendNotificationsForOrderEvent(BLL.Events.EventCode eventCode, BLL.Orders.Order order, BLL.Customers.MetaPartner sender, BLL.Customers.MetaPartner receiver, string mailServer, string senderEmail, string senderPhone)
		{
			try
			{
				MOD.Data.NamedObjectCollection eventData = BLL.Events.EventManager.BuildEventValues(order);
				// build meta partner list
				SortableObjectCollection metaPartnerList = new SortableObjectCollection();
				if (sender != null)
				{
					metaPartnerList.Add(sender);
				}
				if (receiver != null)
				{
					metaPartnerList.Add(receiver);
				}
				SendNotificationsForEvent((int) eventCode, eventData, metaPartnerList, mailServer, senderEmail, senderPhone, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
				return eventData;
			}
			catch (System.Exception ex)
			{
				throw CustomAppException.WrapException(ex, "MW.MComm.WalletSolution.BLL.Notifications.SendNotificationsForEvent");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method sends all notifications for an event.</summary>
		///
		/// <param name="eventCode">Event to send notification for.</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in DAL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void SendNotificationsForEvent(int eventCode, MOD.Data.NamedObjectCollection eventData, MOD.Data.SortableObjectCollection metaPartnerList, string mailServer, string senderEmail, string senderPhone, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				MOD.Data.DataOptions dataOptions = new DataOptions();
				System.Exception sendExceptions = null;
				MComm.SMS.SMSSender.smsSender s_SMSSender = new MComm.SMS.SMSSender.smsSender();
				s_SMSSender.Credentials = System.Net.CredentialCache.DefaultCredentials;
				// perform main method tasks
				BLL.Events.Event notificationEvent = BLL.Events.EventManager.GetOneEvent(eventCode, dbOptions, dataOptions, debugLevel, currentUserID);
				if (notificationEvent != null)
				{
					foreach (BLL.Notifications.Notification loopNotification in notificationEvent.NotificationList)
					{
						foreach (BLL.Notifications.NotificationTemplate loopTemplate in BLL.Notifications.NotificationTemplateManager.GetAllNotificationTemplateDataByNotificationCode(loopNotification.NotificationCode, dbOptions, dataOptions, debugLevel, currentUserID))
						{
							BLL.Notifications.NotificationLog loopNotificationLog = new NotificationLog();
							bool isNotificationLogUsed = false;
							loopNotificationLog.NotificationCode = loopNotification.NotificationCode;
							loopNotificationLog.LocaleCode = loopTemplate.LocaleCode;
							string subject = loopTemplate.NotificationSubjectTemplate;
							string message = loopTemplate.NotificationMessageTemplate;
							// fill the notification templates with event data
							foreach (BLL.Events.SpecificEventAttribute loopAttribute in notificationEvent.SpecificEventAttributeList)
							{
								// add attribute info to log
								BLL.Notifications.NotificationAttributeValueLog loopAttributeLog = new NotificationAttributeValueLog();
								loopAttributeLog.BaseAttributeValueID = loopAttribute.BaseAttributeID;
								// customize templates with event data
								if (eventData[loopAttribute.AttributeCode.ToString()] != null)
								{
									subject = subject.Replace("<" + loopAttribute.AttributeCode.ToString() + ">", eventData[loopAttribute.AttributeCode.ToString()].ToString());
									message = message.Replace("<" + loopAttribute.AttributeCode.ToString() + ">", eventData[loopAttribute.AttributeCode.ToString()].ToString());
									loopAttributeLog.AttributeValue = eventData[loopAttribute.AttributeCode.ToString()].ToString();
								}
								else
								{
									subject = subject.Replace("<" + loopAttribute.AttributeCode.ToString() + ">", "n/a");
									message = message.Replace("<" + loopAttribute.AttributeCode.ToString() + ">", "n/a");
									loopAttributeLog.AttributeValue = "n/a";
								}
								if (loopNotificationLog.NotificationAttributeValueLogList == null)
								{
									loopNotificationLog.NotificationAttributeValueLogList = new SortableList<NotificationAttributeValueLog>();
								}
								loopNotificationLog.NotificationAttributeValueLogList.Add(loopAttributeLog);
							}
							// add message info to log
							loopNotificationLog.NotificationSubject = subject;
							loopNotificationLog.NotificationMessage = message;
							// get specific meta partners, fill in remaining info, and send notification
							foreach (BLL.Customers.MetaPartner loopPartner in metaPartnerList)
							{
								if (loopPartner.LocaleCode == loopTemplate.LocaleCode)
								{
									BLL.Customers.MetaPartner notificationPartner = BLL.Customers.MetaPartnerManager.GetOneMetaPartner(loopPartner.MetaPartnerID, dbOptions, dataOptions, debugLevel, currentUserID);
									string userSubject = subject;
									string userMessage = message;
									// customize templates with meta partner info
									userSubject = userSubject.Replace("<name>", loopPartner.MetaPartnerName);
									userMessage = userMessage.Replace("<name>", loopPartner.MetaPartnerName);
									// send notification
									foreach (BLL.Customers.MetaPartnerEmail loopEmail in notificationPartner.EmailList)
									{
										try
										{
											if (loopEmail.IsActive == true)
											{
												// send email
												System.Net.Mail.SmtpClient mailClient = new System.Net.Mail.SmtpClient();
												mailClient.Host = mailServer;
												mailClient.Send(senderEmail,
													string.Format("\"{0}\" <{1}>", loopPartner.MetaPartnerName, loopEmail.EmailAddress),
													userSubject,
													userMessage);
												isNotificationLogUsed = true;
											}
										}
										catch (System.Exception ex)
										{
											sendExceptions = new Exception(ex.Message + string.Format("\"{0}\" <{1}>", loopPartner.MetaPartnerName, loopEmail.EmailAddress), sendExceptions);
										}
									}
									foreach (BLL.Customers.MetaPartnerPhone loopPhone in notificationPartner.PhoneList)
									{
										try
										{
											if (loopPhone.IsActive == true)
											{
												// send sms (without subject due to limited message sizes)
												MComm.SMS.SMSSender.OutgoingSMSResults results = s_SMSSender.sendSMS(senderPhone, loopPhone.PhoneNumber, userMessage);
												if (results.StatusCode != 0)
												{
													throw new System.Exception(results.StatusDescription);
												}
												isNotificationLogUsed = true;
											}
										}
										catch (System.Exception ex)
										{
											sendExceptions = new Exception(ex.Message + string.Format("\"{0}\" <{1}>", loopPartner.MetaPartnerName, loopPhone.PhoneNumber), sendExceptions);
										}
									}
								}
							}
							// log the notification info
							if (isNotificationLogUsed == true)
							{
								BLL.Notifications.NotificationLogManager.LogOneNotificationLog(loopNotificationLog, true, dbOptions, debugLevel, currentUserID);
							}
							// throw summary exception of sending notifications
							if (sendExceptions != null)
							{
								throw sendExceptions;
							}
						}
					}
				}
			}
			catch (System.Exception ex)
			{
				throw CustomAppException.WrapException(ex, "MW.MComm.WalletSolution.BLL.Notifications.SendNotificationsForEvent");
			}
		}
		#endregion "Public Static Methods"
		#region "Miscellaneous"
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public NotificationGenerator()
		{
			//
			// constructor logic
			//
		}
		#endregion "Miscellaneous"
	}
}