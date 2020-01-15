
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
using MOD.Data;
using MW.MComm.WalletSolution.BLL.Config;
using BLL = MW.MComm.WalletSolution.BLL;
using Utility = MW.MComm.WalletSolution.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
namespace MW.MComm.WalletSolution.BLL.Core
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
		/// <summary>A general exception has occured.</summary>
		GeneralException = 1,
		/// <summary>A general exception that occured in the SQL/DB layer.</summary>
		SqlGeneralException = 1000,
		/// <summary>A parameter supplied to an SQL stored procedure was invalid.</summary>
		SqlInvalidParameter = 1001,
		/// <summary>A SQL record timestamp was changed unexpectedly during an operation.</summary>
		SqlTimestampFailure = 1002,
		/// <summary>Could not add, delete, or update this record due to a data conflict (make sure key is unique).</summary>
		SqlInvalidRecord = 1003,
		/// <summary>Your search contained only ignored words, leading to no results, please refine your search.</summary>
		SqlIgnoredWords = 1004,
		/// <summary>The database operation has timed out, pleas try again.</summary>
		SqlClientTimeout = 1005,
		/// <summary>The database has run out of memory, see the system administrator.</summary>
		SqlOutOfMemory = 1006,
		/// <summary>The database has locked, see the system administrator.</summary>
		SqlLockIssue = 1007,
		/// <summary>The database has locked, see the system administrator.</summary>
		SqlDeadlockVictim = 1008,
		/// <summary>The database has locked, see the system administrator.</summary>
		SqlLockRequestTimeout = 1009,
		/// <summary>The database has run low on memory, see the system administrator.</summary>
		SqlLowMemory = 1010,
		/// <summary>This item cannot be added, updated, or deleted due to a database conflict.  Please review your item details before trying again.</summary>
		SqlConstraintViolation = 1011,
		/// <summary>This item cannot be deleted due to other items depending on this item.  Please review your item details and resolve dependences before trying again.</summary>
		SqlDeleteConstraintViolation = 1012,
		/// <summary>This item cannot be added due to conflicts with other items (such as not allowing duplicates).  Please review your item details and resolve dependences before trying again.</summary>
		SqlInsertConstraintViolation = 1013,
		/// <summary>This item cannot be saved due to conflicts with other items.  Please review your item details and resolve dependences before trying again.</summary>
		SqlUpdateConstraintViolation = 1014,
		/// <summary>A general exception that occured in the Data Access Layer.</summary>
		DALGeneralException = 2000,
		/// <summary>A general exception that occured in the Buisness Logic layer.</summary>
		BLLGeneralException = 3000,
		/// <summary>An item with this code cannot be added since it already exists as a system required code or default value.</summary>
		EnumerationAddException = 3001,
		/// <summary>This item cannot be deleted since it is  a system required item.</summary>
		EnumerationDeleteException = 3002,
		/// <summary>The selected carrier could not be found.</summary>
		CarrierNotFound = 3003,
		/// <summary>The customer is not a valid customer for the selected carrier.</summary>
		CarrierCustomerNotFound = 3004,
		/// <summary>The account is not a valid account for the selected carrier.</summary>
		CarrierAccountNotFound = 3005,
		/// <summary>The selected bank could not be found.</summary>
		BankNotFound = 3006,
		/// <summary>The customer is not a valid customer for the selected bank.</summary>
		BankCustomerNotFound = 3007,
		/// <summary>The account is not a valie account for the selected bank.</summary>
		BankAccountNotFound = 3008,
		/// <summary>The sender's phone number could not be found.</summary>
		SenderPhoneNotFound = 3009,
		/// <summary>The sender's phone number is not active and cannot be used for services.</summary>
		SenderPhoneNotActive = 3010,
		/// <summary>The receiver's phone number could not be found.</summary>
		ReceiverPhoneNotFound = 3011,
		/// <summary>The receiver's phone number is not active and cannot be used for services.</summary>
		ReceiverPhoneNotActive = 3012,
		/// <summary>A valid account for the sender could not be found.</summary>
		SenderAccountNotFound = 3013,
		/// <summary>The sender's account is not active and cannot be used for services.</summary>
		SenderAccountNotActive = 3014,
		/// <summary>The sender's account has insufficient balance for this operation.</summary>
		SenderAccountInsufficientBalance = 3015,
		/// <summary>A valid account for the receiver could not be found.</summary>
		ReceiverAccountNotFound = 3016,
		/// <summary>The receiver's account is not active and cannot be used for services.</summary>
		ReceiverAccountNotActive = 3017,
		/// <summary>The order cannot be cancelled.</summary>
		OrderCancelFailure = 3018,
		/// <summary>The order cannot be approved.</summary>
		OrderApprovalFailure = 3019,
		/// <summary>The order cannot be paid.</summary>
		OrderPaidFailure = 3020,
		/// <summary>The customer PIN is invalid.</summary>
		CustomerPINinvalid = 3021,
		/// <summary>The carrier payment services could not be invoked.</summary>
		CarrierPaymentServiceFailure = 3022,
		/// <summary>The bank payment services could not be invoked.</summary>
		BankPaymentServiceFailure = 3023,
		/// <summary>Funds could not be retrieved from the sender account.</summary>
		SenderPaymentFailure = 3024,
		/// <summary>Funds could not be transferred to the receiver account.</summary>
		RecieverPaymentFailure = 3025,
		/// <summary>A general exception that occured in the Web Service layer.</summary>
		WebServiceGeneralException = 4000,
		/// <summary>The payment card has expired.</summary>
		WebServiceCardExpired = 4001,
		/// <summary>The  payment card has not been activated.</summary>
		WebServiceCardNotActivated = 4002,
		/// <summary>The  payment card account has been closed.</summary>
		WebServiceCardAccountClosed = 4003,
		/// <summary>The  payment card account has been frozen.</summary>
		WebServiceCardFrozen = 4004,
		/// <summary>The  payment card has been reported lost or stolen.</summary>
		WebServiceCardLost = 4005,
		/// <summary>The  payment card does not have enough balance for this purchase.</summary>
		WebServiceCardLowBalance = 4006,
		/// <summary>The payment card account number was not recognized as valid.</summary>
		WebServiceCardBadAccount = 4007,
		/// <summary>Required parameters for this web service call were missing.</summary>
		WebServiceMissingRequiredParameters = 4008,
		/// <summary>A general exception that occured in the Web UI layer.</summary>
		WebUiGeneralException = 5000,
		/// <summary>A general exception that occured in the Content Ingestion layer.</summary>
		CIGeneralException = 6000,
		/// <summary>The XML metadata file cannot be found</summary>
		CIMissingXmlMetadataFile = 6001,
		/// <summary>The XML metadata file format is invalid</summary>
		CIInvalidXmlMetadataFile = 6002,
		/// <summary>An error occured while creating the destination folder</summary>
		CIDestinationFolderCreationError = 6006,
		/// <summary>A field value was missing</summary>
		CIMissingValue = 6008,
		/// <summary>An invalid field value was specified</summary>
		CIInvalidValue = 6009,
		/// <summary>Marks the start of a content ingestion run</summary>
		CIStart = 6100,
		/// <summary>Marks the end of a content ingestion run</summary>
		CIFinish = 6101,
		/// <summary>A debug trace related to content ingestion</summary>
		CIDebugTrace = 6200,
		/// <summary>A general exception that occured in a windows service.</summary>
		WindowsServiceGeneralException = 8000,
	}
}