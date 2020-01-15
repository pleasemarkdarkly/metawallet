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
using MW.MComm.WalletSolution.WebService;
using MW.MComm.WalletSolution.WebService.UserExperience;
using BLL = MW.MComm.WalletSolution.BLL;
using DAL = MW.MComm.WalletSolution.DAL;
using MW.MComm.WalletSolution.BLL.UserExperience;
using MOD.Data;
using Utility = MW.MComm.WalletSolution.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
/// <summary>
/// Summary description for SMSTranslater
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class SMSTranslater : System.Web.Services.WebService
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to translate SMS messages.</summary>
	///
	/// File History:
	/// <created>10/2/2006 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public SMSTranslater()
	{
		//Uncomment the following line if using designed components 
		//InitializeComponent(); 
	}
	[WebMethod]
	public string processSMS(long internalId, string sender, string receiver, string text, string connectionId)
	{
		//return values:
		//an empty string=do not send a response, do not mark the message as processed
		//"!"=mark the message processed, do not send any response
		//any other string wil be sent as a rsponse, if it's longer that one SMS, it will be split
		//implement you application here, good luck
		string s = "!";
		return s;
	}
}
