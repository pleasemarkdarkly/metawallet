

/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/
using System;
using System.Xml;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using MOD.Data;
using MW.MComm.Ganadero.BLL.Config;
using BLL = MW.MComm.Ganadero.BLL;
using DAL = MW.MComm.Ganadero.DAL;
using Utility = MW.MComm.Ganadero.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace MW.MComm.Ganadero.BLL.Core
{
	// ------------------------------------------------------------------------------
	/// <summary>This enumeration is for holding known Error codes.</summary>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public enum ErrorNumber
	{
		/// <summary>None.</summary>
		None = 0,
		/// <summary>A general exception.</summary>
		GeneralException = 1,
		LicenseInvalid = 2,

		/// <summary>A general exception that occured in the SQL/DB layer.</summary>
		SqlGeneralException = 1000,
		/// <summary>A parameter supplied to an SQL stored procedure was invalid.</summary>
		SqlInvalidParameter = 1001,
		/// <summary>An SQL record timestamp was changed unexpectedly during an operation.</summary>
		SqlTimestampFailure = 1002,
		/// <summary>An SQL stored procedure was operating on an invalid record.</summary>
		SqlInvalidRecord = 1003,
		/// <summary>Your search contained only ignored words, leading to no results, please refine your search.</summary>
		SqlIgnoredWords = 1004,
		SqlClientTimeout = 1005,
		SqlOutOfMemory = 1006,
		SqlLockIssue = 1007,
		SqlDeadlockVictim = 1008,
		SqlLockRequestTimeout = 1009,
		SqlLowMemory = 1010,
		SqlConstraintViolation = 1011,
		SqlDeleteConstraintViolation = 1012,
		SqlInsertConstraintViolation = 1013,
		SqlUpdateConstraintViolation = 1014,


		/// <summary>A general exception that occured in the Data Access Layer.</summary>
		DalGeneralException = 2000,

		/// <summary>A general exception that occured in the Data Access Layer.</summary>
		EnumerationAddException = 2001,

		/// <summary>A general exception that occured in the Data Access Layer.</summary>
		EnumerationDeleteException = 2002,


		/// <summary>A general exception that occured in the Buisness Logic layer.</summary>
		BllGeneralException = 3000,

		/// <summary>A general exception that occured in the Web Service layer.</summary>
		WebServiceGeneralException = 4000,

		/// <summary>The customer cd can not be updated since it already has been purchased.</summary>
		WebServiceInvalidCDUpdate = 4001,

		/// <summary>Payment operations are not required (or allowed) for this store.</summary>
		WebServicePaymentInStoreNotAllowed = 4002,

		/// <summary>Payment operations are  required for this store.</summary>
		WebServicePaymentInStoreRequired = 4003,

		/// <summary>There was a problem connecting to the value link services.</summary>
		WebServiceValueLinkConnectionProblem = 4004,

		/// <summary>The payment request was not authorized (rejected).</summary>
		WebServiceValueLinkPaymentRejection = 4005,

		/// <summary>The payment transaction request was not authorized (failed).</summary>
		WebServiceValueLinkPaymentTransactionFailure = 4006,

		/// <summary>The payment transaction request was not allowed.</summary>
		WebServiceValueLinkPaymentTransactionNotAllowed = 4007,

		/// <summary>There was a problem connecting to the skip jack services.</summary>
		WebServiceSkipJackConnectionProblem = 4008,

		/// <summary>The payment request was not authorized (rejected).</summary>
		WebServiceSkipJackPaymentRejection = 4009,

		/// <summary>The payment transaction request was not authorized (failed).</summary>
		WebServiceSkipJackPaymentTransactionFailure = 4010,

		/// <summary>The payment transaction request was not allowed.</summary>
		WebServiceSkipJackPaymentTransactionNotAllowed = 4011,

		/// <summary>There was no data found corresponding to your input parameters.</summary>
		WebServiceNoCorrespondingDataForParamaters = 4012,

		/// <summary>The card type supplied was not allowed for this operation.</summary>
		WebServiceCardTypeNotAllowed = 4013,

		/// <summary>The album is in inventory and can't be burned.</summary>
		WebServiceCDBurnAlbumInInventory = 4014,

		/// <summary>The customer cd specified cannot be found.</summary>
		WebServiceMissingCD = 4015,

		/// <summary>The payment card has expired.</summary>
		WebServiceCardExpired = 4016,

		/// <summary>The  payment card has not been activated.</summary>
		WebServiceCardNotActivated = 4017,

		/// <summary>The  payment card account has been closed.</summary>
		WebServiceCardAccountClosed = 4018,

		/// <summary>The  payment card account has been frozen.</summary>
		WebServiceCardFrozen = 4019,

		/// <summary>The  payment card has been reported lost or stolen.</summary>
		WebServiceCardLost = 4020,

		/// <summary>The  payment card does not have enough balance for this purchase.</summary>
		WebServiceCardLowBalance = 4021,

		/// <summary>The payment card account number was not recognized as valid.</summary>
		WebServiceCardBadAccount = 4022,

		/// <summary>Required parameters for this web service call were missing.</summary>
		WebServiceMissingRequiredParameters = 4023,

		/// <summary>A general exception that occured in the Web UI layer.</summary>
		WebUiGeneralException = 5000,

		// The range of 6000 - 6999 is used for content ingestion errors.

		/// <summary>A general exception that occured in the Content Ingestion layer.</summary>
		CIGeneralException = 6000,

		/// <summary>A general exception that occured in a windows service.</summary>
		WindowsServiceGeneralException = 8000,

	}
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to hold and manage information for Error instances.</summary>
	///
	/// File History:
	/// <created>10/20/2006 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[DataTransform(Name = "MW.MComm.Ganadero.DAL.Core.Error")]
	public partial class Error : BusinessObject
	{

		#region Methods
		#endregion Methods
	}
}