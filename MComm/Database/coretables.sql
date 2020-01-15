if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblAccounts_AccountAttributeValue_tblAccounts_Account]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblAccounts_AccountAttributeValue] DROP CONSTRAINT FK_tblAccounts_AccountAttributeValue_tblAccounts_Account
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblAccounts_BillPayAccount_tblAccounts_Account]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblAccounts_BillPayAccount] DROP CONSTRAINT FK_tblAccounts_BillPayAccount_tblAccounts_Account
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblAccounts_CreditAccount_tblAccounts_Account]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblAccounts_CreditAccount] DROP CONSTRAINT FK_tblAccounts_CreditAccount_tblAccounts_Account
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblAccounts_DebitAccount_tblAccounts_Account1]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblAccounts_DebitAccount] DROP CONSTRAINT FK_tblAccounts_DebitAccount_tblAccounts_Account1
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblAccounts_FundAccount_tblAccounts_Account]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblAccounts_FundAccount] DROP CONSTRAINT FK_tblAccounts_FundAccount_tblAccounts_Account
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblAccounts_LoanAccount_tblAccounts_Account]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblAccounts_LoanAccount] DROP CONSTRAINT FK_tblAccounts_LoanAccount_tblAccounts_Account
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblAccounts_MetaTransferAccount_tblAccounts_Account]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblAccounts_MetaTransferAccount] DROP CONSTRAINT FK_tblAccounts_MetaTransferAccount_tblAccounts_Account
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblAccounts_StoredValueAccount_tblAccounts_Account1]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblAccounts_StoredValueAccount] DROP CONSTRAINT FK_tblAccounts_StoredValueAccount_tblAccounts_Account1
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblOrders_Order_tblAccounts_Account]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblOrders_Order] DROP CONSTRAINT FK_tblOrders_Order_tblAccounts_Account
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblPayments_Payment_tblAccounts_Account]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblPayments_Payment] DROP CONSTRAINT FK_tblPayments_Payment_tblAccounts_Account
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblPayments_Payment_tblAccounts_Account1]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblPayments_Payment] DROP CONSTRAINT FK_tblPayments_Payment_tblAccounts_Account1
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblAccounts_AccountAttributeValue_tblAccounts_AccountAttribute]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblAccounts_AccountAttributeValue] DROP CONSTRAINT FK_tblAccounts_AccountAttributeValue_tblAccounts_AccountAttribute
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblAccounts_BankAccount_tblAccounts_DebitAccount]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblAccounts_BankAccount] DROP CONSTRAINT FK_tblAccounts_BankAccount_tblAccounts_DebitAccount
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblAccounts_StoredValueAccount_tblAccounts_DebitAccount1]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblAccounts_StoredValueAccount] DROP CONSTRAINT FK_tblAccounts_StoredValueAccount_tblAccounts_DebitAccount1
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_trelAccounts_ParticipatingPartner_tblAccounts_FundAccount]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[trelAccounts_ParticipatingPartner] DROP CONSTRAINT FK_trelAccounts_ParticipatingPartner_tblAccounts_FundAccount
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_trelAccounts_LoanToMetaPartner_tblAccounts_LoanAccount]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[trelAccounts_LoanToMetaPartner] DROP CONSTRAINT FK_trelAccounts_LoanToMetaPartner_tblAccounts_LoanAccount
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblAccounts_AccountAttribute_tblCore_BaseAttribute]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblAccounts_AccountAttribute] DROP CONSTRAINT FK_tblAccounts_AccountAttribute_tblCore_BaseAttribute
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblCore_DebugAttribute_tblCore_BaseAttribute]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblCore_DebugAttribute] DROP CONSTRAINT FK_tblCore_DebugAttribute_tblCore_BaseAttribute
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UPDATEBASE_FK_tblEvents_EventAttribute_tblCore_BaseAttribute]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblEvents_EventAttribute] DROP CONSTRAINT UPDATEBASE_FK_tblEvents_EventAttribute_tblCore_BaseAttribute
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblCORE_DebugAttributeValueLog_tblCORE_DebugAttribute]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblCore_DebugAttributeValueLog] DROP CONSTRAINT FK_tblCORE_DebugAttributeValueLog_tblCORE_DebugAttribute
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblCore_DebugAttributeValues_tblCore_DebugLogs]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblCore_DebugAttributeValueLog] DROP CONSTRAINT FK_tblCore_DebugAttributeValues_tblCore_DebugLogs
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblAccounts_BankAccount_tblCustomers_Bank]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblAccounts_BankAccount] DROP CONSTRAINT FK_tblAccounts_BankAccount_tblCustomers_Bank
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblAccounts_BillPayAccount_tblCustomers_Business]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblAccounts_BillPayAccount] DROP CONSTRAINT FK_tblAccounts_BillPayAccount_tblCustomers_Business
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblAccounts_CurrencyConversion_tblCustomers_Business]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblAccounts_CurrencyConversion] DROP CONSTRAINT FK_tblAccounts_CurrencyConversion_tblCustomers_Business
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblCustomers_Bank_tblCustomers_Business]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblCustomers_Bank] DROP CONSTRAINT FK_tblCustomers_Bank_tblCustomers_Business
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblCustomers_Carrier_tblCustomers_Business]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblCustomers_Carrier] DROP CONSTRAINT FK_tblCustomers_Carrier_tblCustomers_Business
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblCustomers_Merchant_tblCustomers_Business]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblCustomers_Merchant] DROP CONSTRAINT FK_tblCustomers_Merchant_tblCustomers_Business
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_trelCustomers_BusinessCustomer_tblCustomers_Business]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[trelCustomers_BusinessCustomer] DROP CONSTRAINT FK_trelCustomers_BusinessCustomer_tblCustomers_Business
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblCustomers_MetaPartnerPhone_tblCustomers_Carrier]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblCustomers_MetaPartnerPhone] DROP CONSTRAINT FK_tblCustomers_MetaPartnerPhone_tblCustomers_Carrier
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_trelCustomers_BusinessCustomer_tblCustomers_Customer]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[trelCustomers_BusinessCustomer] DROP CONSTRAINT FK_trelCustomers_BusinessCustomer_tblCustomers_Customer
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblAccounts_Account_tblCustomers_MetaPartner]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblAccounts_Account] DROP CONSTRAINT FK_tblAccounts_Account_tblCustomers_MetaPartner
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblCustomers_Business_tblCustomers_MetaPartner]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblCustomers_Business] DROP CONSTRAINT FK_tblCustomers_Business_tblCustomers_MetaPartner
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblCustomers_Customer_tblCustomers_MetaPartner]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblCustomers_Customer] DROP CONSTRAINT FK_tblCustomers_Customer_tblCustomers_MetaPartner
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblCustomers_Location_tblCustomers_MetaPartner]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblCustomers_Location] DROP CONSTRAINT FK_tblCustomers_Location_tblCustomers_MetaPartner
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblCustomers_MetaPartnerEmail_tblCustomers_MetaPartner]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblCustomers_MetaPartnerEmail] DROP CONSTRAINT FK_tblCustomers_MetaPartnerEmail_tblCustomers_MetaPartner
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblCustomers_MetaPartnerPhone_tblCustomers_MetaPartner]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblCustomers_MetaPartnerPhone] DROP CONSTRAINT FK_tblCustomers_MetaPartnerPhone_tblCustomers_MetaPartner
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblOrders_Order_tblCustomers_MetaPartner]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblOrders_Order] DROP CONSTRAINT FK_tblOrders_Order_tblCustomers_MetaPartner
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblOrders_Order_tblCustomers_MetaPartner1]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblOrders_Order] DROP CONSTRAINT FK_tblOrders_Order_tblCustomers_MetaPartner1
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_trelAccounts_LoanToMetaPartner_tblCustomers_MetaPartner]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[trelAccounts_LoanToMetaPartner] DROP CONSTRAINT FK_trelAccounts_LoanToMetaPartner_tblCustomers_MetaPartner
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_trelAccounts_ParticipatingPartner_tblCustomers_MetaPartner]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[trelAccounts_ParticipatingPartner] DROP CONSTRAINT FK_trelAccounts_ParticipatingPartner_tblCustomers_MetaPartner
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_trelCustomers_MetaPartnerContact_tblCustomers_MetaPartner]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[trelCustomers_MetaPartnerContact] DROP CONSTRAINT FK_trelCustomers_MetaPartnerContact_tblCustomers_MetaPartner
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_trelCustomers_MetaPartnerContact_tblCustomers_MetaPartner1]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[trelCustomers_MetaPartnerContact] DROP CONSTRAINT FK_trelCustomers_MetaPartnerContact_tblCustomers_MetaPartner1
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_trelNotifications_NotificationDeliveryLog_tblCustomers_MetaPartner]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[trelNotifications_NotificationDeliveryLog] DROP CONSTRAINT FK_trelNotifications_NotificationDeliveryLog_tblCustomers_MetaPartner
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblAccounts_StoredValueAccount_tblCustomers_MetaPartnerPhone1]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblAccounts_StoredValueAccount] DROP CONSTRAINT FK_tblAccounts_StoredValueAccount_tblCustomers_MetaPartnerPhone1
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblNotifications_Notification_tblEvents_Event]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblNotifications_Notification] DROP CONSTRAINT FK_tblNotifications_Notification_tblEvents_Event
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_trelEvents_SpecificEventAttribute_tblEvents_Event]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[trelEvents_SpecificEventAttribute] DROP CONSTRAINT FK_trelEvents_SpecificEventAttribute_tblEvents_Event
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblNotifications_NotificationAttributeValueLog_tblEvents_EventAttribute]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblNotifications_NotificationAttributeValueLog] DROP CONSTRAINT FK_tblNotifications_NotificationAttributeValueLog_tblEvents_EventAttribute
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblPayments_PaymentTransactionAttributeValueLog_tblEvents_EventAttribute]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblPayments_PaymentTransactionAttributeValueLog] DROP CONSTRAINT FK_tblPayments_PaymentTransactionAttributeValueLog_tblEvents_EventAttribute
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_trelEvents_SpecificEventAttribute_tblEvents_EventAttribute1]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[trelEvents_SpecificEventAttribute] DROP CONSTRAINT FK_trelEvents_SpecificEventAttribute_tblEvents_EventAttribute1
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblNotifications_NotificationLog_tblNotifications_Notification]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblNotifications_NotificationLog] DROP CONSTRAINT FK_tblNotifications_NotificationLog_tblNotifications_Notification
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblNotifications_NotificationTemplate_tblNotifications_Notification]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblNotifications_NotificationTemplate] DROP CONSTRAINT FK_tblNotifications_NotificationTemplate_tblNotifications_Notification
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PROP_FK_tblNotifications_NotificationLogAttributeValue_tblNotifications_NotificationLog]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblNotifications_NotificationAttributeValueLog] DROP CONSTRAINT PROP_FK_tblNotifications_NotificationLogAttributeValue_tblNotifications_NotificationLog
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PROP_FK_trelNotifications_NotificationDeliveryLog_tblNotifications_NotificationLog]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[trelNotifications_NotificationDeliveryLog] DROP CONSTRAINT PROP_FK_trelNotifications_NotificationDeliveryLog_tblNotifications_NotificationLog
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblPayments_Payments_tblCustomers_Orders]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblPayments_Payment] DROP CONSTRAINT FK_tblPayments_Payments_tblCustomers_Orders
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblPayments_PaymentTransactions_tblPayments_Payments1]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblPayments_PaymentTransactionLog] DROP CONSTRAINT FK_tblPayments_PaymentTransactions_tblPayments_Payments1
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblPayments_PaymentTransactionAttributeValueLog_tblPayments_PaymentTransactionLog]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblPayments_PaymentTransactionAttributeValueLog] DROP CONSTRAINT FK_tblPayments_PaymentTransactionAttributeValueLog_tblPayments_PaymentTransactionLog
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_trelUsers_UserRoleUsers_tblUsers_User]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[trelUsers_UserRoleUser] DROP CONSTRAINT FK_trelUsers_UserRoleUsers_tblUsers_User
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblAccounts_Account_tlkpAccounts_AccountSubType]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblAccounts_Account] DROP CONSTRAINT FK_tblAccounts_Account_tlkpAccounts_AccountSubType
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblAccounts_CreditAccount_tlkpAccounts_CreditCardType]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblAccounts_CreditAccount] DROP CONSTRAINT FK_tblAccounts_CreditAccount_tlkpAccounts_CreditCardType
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblAccounts_Account_tlkpAccounts_Currency]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblAccounts_Account] DROP CONSTRAINT FK_tblAccounts_Account_tlkpAccounts_Currency
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblAccounts_CurrencyConversion_tlkpAccounts_Currency]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblAccounts_CurrencyConversion] DROP CONSTRAINT FK_tblAccounts_CurrencyConversion_tlkpAccounts_Currency
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblAccounts_CurrencyConversion_tlkpAccounts_Currency1]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblAccounts_CurrencyConversion] DROP CONSTRAINT FK_tblAccounts_CurrencyConversion_tlkpAccounts_Currency1
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblCustomers_MetaPartner_tlkpAccounts_Currency]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblCustomers_MetaPartner] DROP CONSTRAINT FK_tblCustomers_MetaPartner_tlkpAccounts_Currency
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblOrders_Order_tlkpAccounts_Currency]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblOrders_Order] DROP CONSTRAINT FK_tblOrders_Order_tlkpAccounts_Currency
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblAccounts_BillPayAccount_tlkpAccounts_Frequency]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblAccounts_BillPayAccount] DROP CONSTRAINT FK_tblAccounts_BillPayAccount_tlkpAccounts_Frequency
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblAccounts_FundAccount_tlkpAccounts_Frequency]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblAccounts_FundAccount] DROP CONSTRAINT FK_tblAccounts_FundAccount_tlkpAccounts_Frequency
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblAccounts_FundAccount_tlkpAccounts_FundAccountType]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblAccounts_FundAccount] DROP CONSTRAINT FK_tblAccounts_FundAccount_tlkpAccounts_FundAccountType
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblAccounts_MetaTransferAccount_tlkpAccounts_PaymentInstitution]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblAccounts_MetaTransferAccount] DROP CONSTRAINT FK_tblAccounts_MetaTransferAccount_tlkpAccounts_PaymentInstitution
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblCore_BaseAttributes_tlkpCore_BaseAttributeTypes]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblCore_BaseAttribute] DROP CONSTRAINT FK_tblCore_BaseAttributes_tlkpCore_BaseAttributeTypes
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblCore_BaseAttributes_tlkpCore_DataTypes]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblCore_BaseAttribute] DROP CONSTRAINT FK_tblCore_BaseAttributes_tlkpCore_DataTypes
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblCore_DebugLogs_tlkpCore_EventTypes]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblCore_DebugLog] DROP CONSTRAINT FK_tblCore_DebugLogs_tlkpCore_EventTypes
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblCore_DebugLogs_tlkpCore_SeverityLevels]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblCore_DebugLog] DROP CONSTRAINT FK_tblCore_DebugLogs_tlkpCore_SeverityLevels
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblCustomers_Location_tlkpCustomers_LocationType]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblCustomers_Location] DROP CONSTRAINT FK_tblCustomers_Location_tlkpCustomers_LocationType
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblCustomers_MetaPartner_tlkpCustomers_MetaPartnerSubType]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblCustomers_MetaPartner] DROP CONSTRAINT FK_tblCustomers_MetaPartner_tlkpCustomers_MetaPartnerSubType
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblCustomers_Location_tlkpEnvironments_Country]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblCustomers_Location] DROP CONSTRAINT FK_tblCustomers_Location_tlkpEnvironments_Country
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblCustomers_MetaPartner_tlkpEnvironments_DateFormat]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblCustomers_MetaPartner] DROP CONSTRAINT FK_tblCustomers_MetaPartner_tlkpEnvironments_DateFormat
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblCustomers_MetaPartner_tlkpEnvironments_Locale]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblCustomers_MetaPartner] DROP CONSTRAINT FK_tblCustomers_MetaPartner_tlkpEnvironments_Locale
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblNotifications_NotificationLog_tlkpEnvironments_Locale]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblNotifications_NotificationLog] DROP CONSTRAINT FK_tblNotifications_NotificationLog_tlkpEnvironments_Locale
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblNotifications_NotificationTemplate_tlkpEnvironments_Locale]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblNotifications_NotificationTemplate] DROP CONSTRAINT FK_tblNotifications_NotificationTemplate_tlkpEnvironments_Locale
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblUserExperience_AdminHelp_tlkpEnvironments_Locale]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblUserExperience_AdminHelp] DROP CONSTRAINT FK_tblUserExperience_AdminHelp_tlkpEnvironments_Locale
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblUserExperience_SiteHelp_tlkpEnvironments_Locale]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblUserExperience_SiteHelp] DROP CONSTRAINT FK_tblUserExperience_SiteHelp_tlkpEnvironments_Locale
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblUserExperience_SiteLabel_tlkpEnvironments_Locale]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblUserExperience_SiteLabel] DROP CONSTRAINT FK_tblUserExperience_SiteLabel_tlkpEnvironments_Locale
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblUsers_User_tlkpEnvironments_Locale]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblUsers_User] DROP CONSTRAINT FK_tblUsers_User_tlkpEnvironments_Locale
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblEvents_Events_tlkpEvents_EventType]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblEvents_Event] DROP CONSTRAINT FK_tblEvents_Events_tlkpEvents_EventType
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_trelNotifications_NotificationDeliveryLog_tlkpNotifications_NotificationDeliveryType]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[trelNotifications_NotificationDeliveryLog] DROP CONSTRAINT FK_trelNotifications_NotificationDeliveryLog_tlkpNotifications_NotificationDeliveryType
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblOrders_Order_tlkpOrders_OrderStatus]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblOrders_Order] DROP CONSTRAINT FK_tblOrders_Order_tlkpOrders_OrderStatus
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblPayments_Payments_tlkpPayments_PaymentStatus]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblPayments_Payment] DROP CONSTRAINT FK_tblPayments_Payments_tlkpPayments_PaymentStatus
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblPayments_PaymentTransactionLog_tlkpPayments_TransactionStatus]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblPayments_PaymentTransactionLog] DROP CONSTRAINT FK_tblPayments_PaymentTransactionLog_tlkpPayments_TransactionStatus
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblPayments_PaymentTransactions_tlkpPayments_TransactionTypes]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblPayments_PaymentTransactionLog] DROP CONSTRAINT FK_tblPayments_PaymentTransactions_tlkpPayments_TransactionTypes
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblStores_SiteHelp_tlkpStores_SiteHelpGroups]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblUserExperience_SiteHelp] DROP CONSTRAINT FK_tblStores_SiteHelp_tlkpStores_SiteHelpGroups
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_trelUsers_UserRoleActivity_tlkpUsers_AccessMode]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[trelUsers_UserRoleActivity] DROP CONSTRAINT FK_trelUsers_UserRoleActivity_tlkpUsers_AccessMode
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblUserExperience_AdminHelp_tlkpUsers_Activity]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblUserExperience_AdminHelp] DROP CONSTRAINT FK_tblUserExperience_AdminHelp_tlkpUsers_Activity
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_trelUsers_UserRoles_Activities_tlkpUsers_Activities]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[trelUsers_UserRoleActivity] DROP CONSTRAINT FK_trelUsers_UserRoles_Activities_tlkpUsers_Activities
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_trelUsers_UserRoles_Activities_tlkpUsers_UserRoles]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[trelUsers_UserRoleActivity] DROP CONSTRAINT FK_trelUsers_UserRoles_Activities_tlkpUsers_UserRoles
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_trelUsers_UserRoleUsers_tlkpbUsers_UserRole]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[trelUsers_UserRoleUser] DROP CONSTRAINT FK_trelUsers_UserRoleUsers_tlkpbUsers_UserRole
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dba_SchemaVerCntrl]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[dba_SchemaVerCntrl]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblAccounts_Account]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblAccounts_Account]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblAccounts_AccountAttribute]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblAccounts_AccountAttribute]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblAccounts_AccountAttributeValue]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblAccounts_AccountAttributeValue]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblAccounts_BankAccount]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblAccounts_BankAccount]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblAccounts_BillPayAccount]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblAccounts_BillPayAccount]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblAccounts_CreditAccount]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblAccounts_CreditAccount]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblAccounts_CurrencyConversion]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblAccounts_CurrencyConversion]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblAccounts_DebitAccount]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblAccounts_DebitAccount]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblAccounts_FundAccount]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblAccounts_FundAccount]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblAccounts_LoanAccount]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblAccounts_LoanAccount]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblAccounts_MetaTransferAccount]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblAccounts_MetaTransferAccount]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblAccounts_StoredValueAccount]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblAccounts_StoredValueAccount]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblCore_BaseAttribute]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblCore_BaseAttribute]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblCore_DebugAttribute]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblCore_DebugAttribute]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblCore_DebugAttributeValueLog]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblCore_DebugAttributeValueLog]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblCore_DebugLog]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblCore_DebugLog]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblCustomers_Bank]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblCustomers_Bank]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblCustomers_Business]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblCustomers_Business]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblCustomers_Carrier]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblCustomers_Carrier]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblCustomers_Customer]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblCustomers_Customer]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblCustomers_Location]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblCustomers_Location]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblCustomers_Merchant]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblCustomers_Merchant]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblCustomers_MetaPartner]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblCustomers_MetaPartner]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblCustomers_MetaPartnerEmail]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblCustomers_MetaPartnerEmail]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblCustomers_MetaPartnerPhone]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblCustomers_MetaPartnerPhone]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblEvents_Event]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblEvents_Event]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblEvents_EventAttribute]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblEvents_EventAttribute]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblNotifications_Notification]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblNotifications_Notification]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblNotifications_NotificationAttributeValueLog]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblNotifications_NotificationAttributeValueLog]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblNotifications_NotificationLog]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblNotifications_NotificationLog]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblNotifications_NotificationTemplate]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblNotifications_NotificationTemplate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblOrders_Order]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblOrders_Order]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblPayments_Payment]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblPayments_Payment]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblPayments_PaymentTransactionAttributeValueLog]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblPayments_PaymentTransactionAttributeValueLog]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblPayments_PaymentTransactionLog]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblPayments_PaymentTransactionLog]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblUserExperience_AdminHelp]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblUserExperience_AdminHelp]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblUserExperience_SiteHelp]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblUserExperience_SiteHelp]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblUserExperience_SiteLabel]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblUserExperience_SiteLabel]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblUsers_User]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblUsers_User]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tlkpAccounts_AccountSubType]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tlkpAccounts_AccountSubType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tlkpAccounts_CreditCardType]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tlkpAccounts_CreditCardType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tlkpAccounts_Currency]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tlkpAccounts_Currency]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tlkpAccounts_Frequency]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tlkpAccounts_Frequency]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tlkpAccounts_FundAccountType]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tlkpAccounts_FundAccountType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tlkpAccounts_PaymentInstitution]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tlkpAccounts_PaymentInstitution]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tlkpCore_AttributeType]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tlkpCore_AttributeType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tlkpCore_DataType]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tlkpCore_DataType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tlkpCore_Error]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tlkpCore_Error]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tlkpCore_EventType]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tlkpCore_EventType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tlkpCore_SeverityLevel]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tlkpCore_SeverityLevel]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tlkpCustomers_LocationType]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tlkpCustomers_LocationType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tlkpCustomers_MetaPartnerSubType]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tlkpCustomers_MetaPartnerSubType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tlkpEnvironments_Country]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tlkpEnvironments_Country]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tlkpEnvironments_DateFormat]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tlkpEnvironments_DateFormat]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tlkpEnvironments_Locale]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tlkpEnvironments_Locale]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tlkpEvents_EventType]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tlkpEvents_EventType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tlkpNotifications_NotificationDeliveryType]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tlkpNotifications_NotificationDeliveryType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tlkpOrders_OrderStatus]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tlkpOrders_OrderStatus]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tlkpPayments_PaymentStatus]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tlkpPayments_PaymentStatus]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tlkpPayments_TransactionStatus]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tlkpPayments_TransactionStatus]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tlkpPayments_TransactionType]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tlkpPayments_TransactionType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tlkpUserExperience_SiteHelpGroup]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tlkpUserExperience_SiteHelpGroup]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tlkpUsers_AccessMode]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tlkpUsers_AccessMode]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tlkpUsers_Activity]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tlkpUsers_Activity]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tlkpUsers_UserRole]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tlkpUsers_UserRole]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[trelAccounts_LoanToMetaPartner]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[trelAccounts_LoanToMetaPartner]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[trelAccounts_ParticipatingPartner]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[trelAccounts_ParticipatingPartner]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[trelCustomers_BusinessCustomer]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[trelCustomers_BusinessCustomer]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[trelCustomers_MetaPartnerContact]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[trelCustomers_MetaPartnerContact]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[trelEvents_SpecificEventAttribute]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[trelEvents_SpecificEventAttribute]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[trelNotifications_NotificationDeliveryLog]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[trelNotifications_NotificationDeliveryLog]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[trelUsers_UserRoleActivity]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[trelUsers_UserRoleActivity]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[trelUsers_UserRoleUser]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[trelUsers_UserRoleUser]
GO

if (select DATABASEPROPERTY(DB_NAME(), N'IsFullTextEnabled')) <> 1 
exec sp_fulltext_database N'enable' 

GO


if exists (select * from dbo.sysfulltextcatalogs where name = N'MMS_Assets')
exec sp_fulltext_catalog N'MMS_Assets', N'drop'

GO

if not exists (select * from dbo.sysfulltextcatalogs where name = N'MMS_Assets')
exec sp_fulltext_catalog N'MMS_Assets', N'create' 

GO

if exists (select * from dbo.sysfulltextcatalogs where name = N'MMS_Albums')
exec sp_fulltext_catalog N'MMS_Albums', N'drop'

GO

if not exists (select * from dbo.sysfulltextcatalogs where name = N'MMS_Albums')
exec sp_fulltext_catalog N'MMS_Albums', N'create' 

GO

if exists (select * from dbo.sysfulltextcatalogs where name = N'MMS_Contributors')
exec sp_fulltext_catalog N'MMS_Contributors', N'drop'

GO

if not exists (select * from dbo.sysfulltextcatalogs where name = N'MMS_Contributors')
exec sp_fulltext_catalog N'MMS_Contributors', N'create' 

GO

if exists (select * from dbo.sysfulltextcatalogs where name = N'MMS_Tracks')
exec sp_fulltext_catalog N'MMS_Tracks', N'drop'

GO

if not exists (select * from dbo.sysfulltextcatalogs where name = N'MMS_Tracks')
exec sp_fulltext_catalog N'MMS_Tracks', N'create' 

GO

CREATE TABLE [dbo].[dba_SchemaVerCntrl] (
	[TableName] [sysname] NOT NULL ,
	[CreateDate] [datetime] NOT NULL ,
	[SchemaVersion] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tblAccounts_Account] (
	[AccountID] [uniqueidentifier] NOT NULL ,
	[MetaPartnerID] [uniqueidentifier] NOT NULL ,
	[AccountName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[AccountSubTypeCode] [int] NOT NULL ,
	[CurrencyCode] [int] NOT NULL ,
	[Description] [nvarchar] (2000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[IsActive] [bit] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tblAccounts_AccountAttribute] (
	[BaseAttributeID] [uniqueidentifier] NOT NULL ,
	[AttributeCode] [int] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tblAccounts_AccountAttributeValue] (
	[AccountAttributeValueID] [uniqueidentifier] NOT NULL ,
	[AccountID] [uniqueidentifier] NOT NULL ,
	[BaseAttributeID] [uniqueidentifier] NOT NULL ,
	[ParameterValue] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tblAccounts_BankAccount] (
	[AccountID] [uniqueidentifier] NOT NULL ,
	[BankMetaPartnerID] [uniqueidentifier] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tblAccounts_BillPayAccount] (
	[AccountID] [uniqueidentifier] NOT NULL ,
	[BusinessAccountNumber] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[StartDate] [datetime] NOT NULL ,
	[EndDate] [datetime] NOT NULL ,
	[DefaultMinimumPayment] [money] NOT NULL ,
	[DefaultMaximumPayment] [money] NOT NULL ,
	[BusinessMetaPartnerID] [uniqueidentifier] NOT NULL ,
	[HourOfDay] [int] NOT NULL ,
	[DayOfWeek] [int] NOT NULL ,
	[WeekOfMonth] [int] NOT NULL ,
	[MonthOfYear] [int] NOT NULL ,
	[NumberOfReminders] [int] NOT NULL ,
	[FrequencyCode] [int] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tblAccounts_CreditAccount] (
	[AccountID] [uniqueidentifier] NOT NULL ,
	[CreditCardNumber] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[CreditCardLastFour] [nvarchar] (4) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[CreditCardName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[ExpirationDate] [datetime] NULL ,
	[CreditCardTypeCode] [int] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tblAccounts_CurrencyConversion] (
	[CurrencyConversionID] [uniqueidentifier] NOT NULL ,
	[ConvertFromCurrencyCode] [int] NOT NULL ,
	[ConvertToCurrencyCode] [int] NOT NULL ,
	[MetaPartnerID] [uniqueidentifier] NOT NULL ,
	[ConversionRate] [float] NOT NULL ,
	[IsActive] [bit] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tblAccounts_DebitAccount] (
	[AccountID] [uniqueidentifier] NOT NULL ,
	[DebitAccountNumber] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[IsDefaultDebitAccount] [bit] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tblAccounts_FundAccount] (
	[AccountID] [uniqueidentifier] NOT NULL ,
	[StartDate] [datetime] NOT NULL ,
	[EndDate] [datetime] NOT NULL ,
	[FundCode] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[TargetAmount] [money] NOT NULL ,
	[MinimumDonationAmount] [money] NOT NULL ,
	[MaximumDonationAmount] [money] NOT NULL ,
	[DonatedAmount] [money] NOT NULL ,
	[IsPublic] [bit] NOT NULL ,
	[FundAccountTypeCode] [int] NOT NULL ,
	[FrequencyCode] [int] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tblAccounts_LoanAccount] (
	[AccountID] [uniqueidentifier] NOT NULL ,
	[LoanAmount] [money] NOT NULL ,
	[OutstandingAmount] [money] NOT NULL ,
	[DueDate] [datetime] NOT NULL ,
	[LoanRate] [float] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tblAccounts_MetaTransferAccount] (
	[AccountID] [uniqueidentifier] NOT NULL ,
	[MetaTransferAccountNumber] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[PaymentInstitutionCode] [int] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tblAccounts_StoredValueAccount] (
	[AccountID] [uniqueidentifier] NOT NULL ,
	[MetaPartnerPhoneID] [uniqueidentifier] NOT NULL ,
	[PhoneMetaPartnerID] [uniqueidentifier] NOT NULL ,
	[Balance] [money] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tblCore_BaseAttribute] (
	[BaseAttributeID] [uniqueidentifier] NOT NULL ,
	[AttributeName] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[AttributeTypeCode] [int] NOT NULL ,
	[DataTypeCode] [int] NOT NULL ,
	[Description] [nvarchar] (1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[IsActive] [bit] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tblCore_DebugAttribute] (
	[BaseAttributeID] [uniqueidentifier] NOT NULL ,
	[AttributeCode] [int] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tblCore_DebugAttributeValueLog] (
	[DebugAttributeValueLogID] [uniqueidentifier] NOT NULL ,
	[DebugLogID] [uniqueidentifier] NOT NULL ,
	[BaseAttributeID] [uniqueidentifier] NOT NULL ,
	[AttributeValue] [nvarchar] (1000) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tblCore_DebugLog] (
	[DebugLogID] [uniqueidentifier] NOT NULL ,
	[EventName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Message] [nvarchar] (1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[ErrorNumber] [int] NULL ,
	[EventTypeCode] [int] NOT NULL ,
	[SeverityLevelCode] [int] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tblCustomers_Bank] (
	[MetaPartnerID] [uniqueidentifier] NOT NULL ,
	[BankCode] [int] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tblCustomers_Business] (
	[MetaPartnerID] [uniqueidentifier] NOT NULL ,
	[ServiceCharges] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tblCustomers_Carrier] (
	[MetaPartnerID] [uniqueidentifier] NOT NULL ,
	[CarrierCode] [int] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tblCustomers_Customer] (
	[MetaPartnerID] [uniqueidentifier] NOT NULL ,
	[FirstName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[LastName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tblCustomers_Location] (
	[LocationID] [uniqueidentifier] NOT NULL ,
	[LocationTypeCode] [int] NOT NULL ,
	[AddressLine1] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[AddressLine2] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[City] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[StateProvince] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[CountryCode] [int] NOT NULL ,
	[PostalCode] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[MetaPartnerID] [uniqueidentifier] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tblCustomers_Merchant] (
	[MetaPartnerID] [uniqueidentifier] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tblCustomers_MetaPartner] (
	[MetaPartnerID] [uniqueidentifier] NOT NULL ,
	[MetaPartnerSubTypeCode] [int] NOT NULL ,
	[MetaPartnerName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[LocaleCode] [int] NOT NULL ,
	[CurrencyCode] [int] NOT NULL ,
	[DateFormatCode] [int] NOT NULL ,
	[PictureImageURL] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[TaxCode] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[IsActive] [bit] NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tblCustomers_MetaPartnerEmail] (
	[MetaPartnerEmailID] [uniqueidentifier] NOT NULL ,
	[EmailAddress] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Password] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[MetaPartnerID] [uniqueidentifier] NOT NULL ,
	[Rank] [int] NOT NULL ,
	[IsActive] [bit] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tblCustomers_MetaPartnerPhone] (
	[MetaPartnerPhoneID] [uniqueidentifier] NOT NULL ,
	[PhoneNumber] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[MetaPartnerID] [uniqueidentifier] NOT NULL ,
	[PIN] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[CarrierMetaPartnerID] [uniqueidentifier] NOT NULL ,
	[Rank] [int] NOT NULL ,
	[IsActive] [bit] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tblEvents_Event] (
	[EventCode] [int] NOT NULL ,
	[EventName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[EventTypeCode] [int] NOT NULL ,
	[Description] [nvarchar] (2000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[IsActive] [bit] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tblEvents_EventAttribute] (
	[BaseAttributeID] [uniqueidentifier] NOT NULL ,
	[AttributeCode] [int] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tblNotifications_Notification] (
	[NotificationCode] [int] NOT NULL ,
	[NotificationName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[EventCode] [int] NOT NULL ,
	[Description] [nvarchar] (2000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[IsActive] [bit] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[tblNotifications_NotificationAttributeValueLog] (
	[NotificationAttributeValueLogID] [uniqueidentifier] NOT NULL ,
	[NotificationLogID] [uniqueidentifier] NOT NULL ,
	[BaseAttributeValueID] [uniqueidentifier] NOT NULL ,
	[AttributeValue] [nvarchar] (1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tblNotifications_NotificationLog] (
	[NotificationLogID] [uniqueidentifier] NOT NULL ,
	[NotificationCode] [int] NOT NULL ,
	[NotificationSubject] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[NotificationMessage] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[LocaleCode] [int] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[tblNotifications_NotificationTemplate] (
	[NotificationTemplateID] [uniqueidentifier] NOT NULL ,
	[NotificationCode] [int] NOT NULL ,
	[NotificationSubjectTemplate] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[NotificationMessageTemplate] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[LocaleCode] [int] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[tblOrders_Order] (
	[OrderID] [uniqueidentifier] NOT NULL ,
	[DebitMetaPartnerID] [uniqueidentifier] NOT NULL ,
	[CreditMetaPartnerID] [uniqueidentifier] NOT NULL ,
	[LogToAccountID] [uniqueidentifier] NOT NULL ,
	[OrderDescription] [nvarchar] (2000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[OrderAmount] [money] NOT NULL ,
	[OrderSubtotal] [money] NOT NULL ,
	[OrderTax] [money] NOT NULL ,
	[OrderServiceCharge] [money] NOT NULL ,
	[CurrencyCode] [int] NOT NULL ,
	[OrderStatusCode] [int] NOT NULL ,
	[OrderStatusMessage] [nvarchar] (1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tblPayments_Payment] (
	[PaymentID] [uniqueidentifier] NOT NULL ,
	[PaymentAmount] [money] NOT NULL ,
	[PaymentSubtotal] [money] NOT NULL ,
	[PaymentTax] [money] NOT NULL ,
	[PaymentServiceCharge] [money] NOT NULL ,
	[OrderID] [uniqueidentifier] NOT NULL ,
	[DebitMetaPartnerID] [uniqueidentifier] NOT NULL ,
	[SourceAccountID] [uniqueidentifier] NOT NULL ,
	[CreditMetaPartnerID] [uniqueidentifier] NOT NULL ,
	[DestinationAccountID] [uniqueidentifier] NOT NULL ,
	[PaymentStatusCode] [int] NOT NULL ,
	[PaymentStatusMessage] [nvarchar] (1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tblPayments_PaymentTransactionAttributeValueLog] (
	[PaymentTransactionAttributeValueLogID] [uniqueidentifier] NOT NULL ,
	[PaymentTransactionLogID] [uniqueidentifier] NOT NULL ,
	[BaseAttributeID] [uniqueidentifier] NOT NULL ,
	[AttributeValue] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tblPayments_PaymentTransactionLog] (
	[PaymentTransactionLogID] [uniqueidentifier] NOT NULL ,
	[PaymentID] [uniqueidentifier] NOT NULL ,
	[TransactionTypeCode] [int] NOT NULL ,
	[TransactionStatusCode] [int] NOT NULL ,
	[TransactionAmount] [money] NOT NULL ,
	[ResponseCode] [nvarchar] (25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[TransactionCode] [nvarchar] (25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[TransactionMessage] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Balance] [money] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tblUserExperience_AdminHelp] (
	[ActivityCode] [int] NOT NULL ,
	[LocaleCode] [int] NOT NULL ,
	[AdminHelpTitle] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[AdminHelpText] [nvarchar] (2000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tblUserExperience_SiteHelp] (
	[SiteHelpCode] [int] NOT NULL ,
	[LocaleCode] [int] NOT NULL ,
	[SiteHelpName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[SiteHelpText] [nvarchar] (2000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[SiteHelpImageURL] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[SiteHelpGroupCode] [int] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tblUserExperience_SiteLabel] (
	[SiteLabelCode] [int] NOT NULL ,
	[LocaleCode] [int] NOT NULL ,
	[Title] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[DisplayText] [nvarchar] (2000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[TargetLocation] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[FileURL] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Description] [nvarchar] (1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tblUsers_User] (
	[UserID] [uniqueidentifier] NOT NULL ,
	[UserName] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[FirstName] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[LastName] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Password] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[LocaleCode] [int] NULL ,
	[IsActive] [bit] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tlkpAccounts_AccountSubType] (
	[AccountSubTypeCode] [int] NOT NULL ,
	[AccountSubTypeName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Description] [nvarchar] (2000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[IsActive] [bit] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tlkpAccounts_CreditCardType] (
	[CreditCardTypeCode] [int] NOT NULL ,
	[CreditCardTypeName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Description] [nvarchar] (2000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[IsActive] [bit] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tlkpAccounts_Currency] (
	[CurrencyCode] [int] NOT NULL ,
	[CurrencyName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[IsPaymentCurrency] [bit] NOT NULL ,
	[Description] [nvarchar] (2000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[IsActive] [bit] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tlkpAccounts_Frequency] (
	[FrequencyCode] [int] NOT NULL ,
	[FrequencyName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Description] [nvarchar] (2000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[IsActive] [bit] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tlkpAccounts_FundAccountType] (
	[FundAccountTypeCode] [int] NOT NULL ,
	[FundAccountTypeName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Description] [nvarchar] (2000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[IsActive] [bit] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tlkpAccounts_PaymentInstitution] (
	[PaymentInstitutionCode] [int] NOT NULL ,
	[PaymentInstitutionName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Description] [nvarchar] (2000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[IsActive] [bit] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tlkpCore_AttributeType] (
	[AttributeTypeCode] [int] NOT NULL ,
	[AttributeTypeName] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Description] [nvarchar] (1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[IsActive] [bit] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tlkpCore_DataType] (
	[DataTypeCode] [int] NOT NULL ,
	[DataTypeName] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Description] [nvarchar] (1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[IsActive] [bit] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tlkpCore_Error] (
	[ErrorNumber] [int] NOT NULL ,
	[ErrorTitle] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[ErrorMessage] [nvarchar] (1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tlkpCore_EventType] (
	[EventTypeCode] [int] NOT NULL ,
	[EventTypeName] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Description] [nvarchar] (1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[IsActive] [bit] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tlkpCore_SeverityLevel] (
	[SeverityLevelCode] [int] NOT NULL ,
	[SeverityLevelName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Description] [nvarchar] (1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[IsActive] [bit] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tlkpCustomers_LocationType] (
	[LocationTypeCode] [int] NOT NULL ,
	[LocationTypeName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Description] [nvarchar] (2000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[IsActive] [bit] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tlkpCustomers_MetaPartnerSubType] (
	[MetaPartnerSubTypeCode] [int] NOT NULL ,
	[MetaPartnerSubTypeName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Description] [nvarchar] (2000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[IsActive] [bit] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tlkpEnvironments_Country] (
	[CountryCode] [int] NOT NULL ,
	[CountryName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Description] [nvarchar] (2000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[IsActive] [bit] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tlkpEnvironments_DateFormat] (
	[DateFormatCode] [int] NOT NULL ,
	[DateFormatName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[DataFormatString] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Description] [nvarchar] (2000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[IsActive] [bit] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tlkpEnvironments_Locale] (
	[LocaleCode] [int] NOT NULL ,
	[LocaleName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Description] [nvarchar] (2000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[IsActive] [bit] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tlkpEvents_EventType] (
	[EventTypeCode] [int] NOT NULL ,
	[EventTypeName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Description] [nvarchar] (2000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[IsActive] [bit] NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tlkpNotifications_NotificationDeliveryType] (
	[NotificationDeliveryTypeCode] [int] NOT NULL ,
	[NotificationDeliveryTypeName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Description] [nvarchar] (2000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[IsActive] [bit] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tlkpOrders_OrderStatus] (
	[OrderStatusCode] [int] NOT NULL ,
	[OrderStatusName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Description] [nvarchar] (2000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[IsActive] [bit] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tlkpPayments_PaymentStatus] (
	[PaymentStatusCode] [int] NOT NULL ,
	[PaymentStatusName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Description] [nvarchar] (2000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[IsActive] [bit] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tlkpPayments_TransactionStatus] (
	[TransactionStatusCode] [int] NOT NULL ,
	[TransactionStatusName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Description] [nvarchar] (2000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[IsActive] [bit] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tlkpPayments_TransactionType] (
	[TransactionTypeCode] [int] NOT NULL ,
	[TransactionTypeName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Description] [nvarchar] (2000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[IsActive] [bit] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tlkpUserExperience_SiteHelpGroup] (
	[SiteHelpGroupCode] [int] NOT NULL ,
	[SiteHelpGroupName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tlkpUsers_AccessMode] (
	[AccessModeCode] [int] NOT NULL ,
	[AccessModeName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Description] [nvarchar] (2000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[IsActive] [bit] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tlkpUsers_Activity] (
	[ActivityCode] [int] NOT NULL ,
	[ActivityName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Description] [nvarchar] (2000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[IsActive] [bit] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tlkpUsers_UserRole] (
	[UserRoleCode] [int] NOT NULL ,
	[UserRoleName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Description] [nvarchar] (2000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[IsActive] [bit] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[trelAccounts_LoanToMetaPartner] (
	[AccountID] [uniqueidentifier] NOT NULL ,
	[MetaPartnerID] [uniqueidentifier] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[trelAccounts_ParticipatingPartner] (
	[AccountID] [uniqueidentifier] NOT NULL ,
	[MetaPartnerID] [uniqueidentifier] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[trelCustomers_BusinessCustomer] (
	[BusinessMetaPartnerID] [uniqueidentifier] NOT NULL ,
	[CustomerMetaPartnerID] [uniqueidentifier] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[trelCustomers_MetaPartnerContact] (
	[MetaPartnerID] [uniqueidentifier] NOT NULL ,
	[ContactMetaPartnerID] [uniqueidentifier] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[trelEvents_SpecificEventAttribute] (
	[EventCode] [int] NOT NULL ,
	[BaseAttributeID] [uniqueidentifier] NOT NULL ,
	[Rank] [int] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[trelNotifications_NotificationDeliveryLog] (
	[NotificationLogID] [uniqueidentifier] NOT NULL ,
	[MetaPartnerID] [uniqueidentifier] NOT NULL ,
	[NotificationDeliveryTypeCode] [int] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[trelUsers_UserRoleActivity] (
	[UserRoleCode] [int] NOT NULL ,
	[ActivityCode] [int] NOT NULL ,
	[AccessModeCode] [int] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[trelUsers_UserRoleUser] (
	[UserRoleCode] [int] NOT NULL ,
	[UserID] [uniqueidentifier] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tblAccounts_Account] WITH NOCHECK ADD 
	CONSTRAINT [PK_tblAccounts_Account] PRIMARY KEY  CLUSTERED 
	(
		[AccountID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblAccounts_AccountAttribute] WITH NOCHECK ADD 
	CONSTRAINT [PK_tblAccounts_AccountAttribute] PRIMARY KEY  CLUSTERED 
	(
		[BaseAttributeID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblAccounts_AccountAttributeValue] WITH NOCHECK ADD 
	CONSTRAINT [PK_tblAccounts_AccountAttributeValue] PRIMARY KEY  CLUSTERED 
	(
		[AccountAttributeValueID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblAccounts_BankAccount] WITH NOCHECK ADD 
	CONSTRAINT [PK_tblAccounts_BankAccount] PRIMARY KEY  CLUSTERED 
	(
		[AccountID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblAccounts_BillPayAccount] WITH NOCHECK ADD 
	CONSTRAINT [PK_tblAccounts_BillPayAccount] PRIMARY KEY  CLUSTERED 
	(
		[AccountID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblAccounts_CreditAccount] WITH NOCHECK ADD 
	CONSTRAINT [PK_tblAccounts_CreditAccount] PRIMARY KEY  CLUSTERED 
	(
		[AccountID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblAccounts_CurrencyConversion] WITH NOCHECK ADD 
	CONSTRAINT [PK_tblAccounts_CurrencyConversion] PRIMARY KEY  CLUSTERED 
	(
		[CurrencyConversionID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblAccounts_DebitAccount] WITH NOCHECK ADD 
	CONSTRAINT [PK_tblAccounts_DebitAccount] PRIMARY KEY  CLUSTERED 
	(
		[AccountID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblAccounts_FundAccount] WITH NOCHECK ADD 
	CONSTRAINT [PK_tblAccounts_FundAccount] PRIMARY KEY  CLUSTERED 
	(
		[AccountID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblAccounts_LoanAccount] WITH NOCHECK ADD 
	CONSTRAINT [PK_tblAccounts_LoanAccount] PRIMARY KEY  CLUSTERED 
	(
		[AccountID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblAccounts_MetaTransferAccount] WITH NOCHECK ADD 
	CONSTRAINT [PK_tblAccounts_MetaTransferAccount] PRIMARY KEY  CLUSTERED 
	(
		[AccountID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblAccounts_StoredValueAccount] WITH NOCHECK ADD 
	CONSTRAINT [PK_tblAccounts_StoredValueAccount] PRIMARY KEY  CLUSTERED 
	(
		[AccountID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblCore_BaseAttribute] WITH NOCHECK ADD 
	CONSTRAINT [PK_tblCore_BaseAttribute] PRIMARY KEY  CLUSTERED 
	(
		[BaseAttributeID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblCore_DebugAttribute] WITH NOCHECK ADD 
	CONSTRAINT [PK_tblCore_DebugAttributes] PRIMARY KEY  CLUSTERED 
	(
		[BaseAttributeID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblCore_DebugAttributeValueLog] WITH NOCHECK ADD 
	CONSTRAINT [PK_tblCore_DebugAttributeValues] PRIMARY KEY  CLUSTERED 
	(
		[DebugAttributeValueLogID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblCore_DebugLog] WITH NOCHECK ADD 
	CONSTRAINT [PK_tblCore_DebugLogs] PRIMARY KEY  CLUSTERED 
	(
		[DebugLogID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblCustomers_Bank] WITH NOCHECK ADD 
	CONSTRAINT [PK_tblCustomers_Bank] PRIMARY KEY  CLUSTERED 
	(
		[MetaPartnerID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblCustomers_Business] WITH NOCHECK ADD 
	CONSTRAINT [PK_tblCustomers_Business] PRIMARY KEY  CLUSTERED 
	(
		[MetaPartnerID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblCustomers_Carrier] WITH NOCHECK ADD 
	CONSTRAINT [PK_tblCustomers_Carrier] PRIMARY KEY  CLUSTERED 
	(
		[MetaPartnerID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblCustomers_Customer] WITH NOCHECK ADD 
	CONSTRAINT [PK_tblCustomers_Customer] PRIMARY KEY  CLUSTERED 
	(
		[MetaPartnerID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblCustomers_Location] WITH NOCHECK ADD 
	CONSTRAINT [PK_tblCustomers_Location] PRIMARY KEY  CLUSTERED 
	(
		[LocationID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblCustomers_Merchant] WITH NOCHECK ADD 
	CONSTRAINT [PK_tblCustomers_Merchant] PRIMARY KEY  CLUSTERED 
	(
		[MetaPartnerID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblCustomers_MetaPartner] WITH NOCHECK ADD 
	CONSTRAINT [PK_tblCustomers_Customers] PRIMARY KEY  CLUSTERED 
	(
		[MetaPartnerID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblCustomers_MetaPartnerEmail] WITH NOCHECK ADD 
	CONSTRAINT [PK_tblCustomers_MetaPartnerEmail] PRIMARY KEY  CLUSTERED 
	(
		[MetaPartnerEmailID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblCustomers_MetaPartnerPhone] WITH NOCHECK ADD 
	CONSTRAINT [PK_tblCustomers_MetaPartnerPhone] PRIMARY KEY  CLUSTERED 
	(
		[MetaPartnerPhoneID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblEvents_Event] WITH NOCHECK ADD 
	CONSTRAINT [PK_tblEvents_Event] PRIMARY KEY  CLUSTERED 
	(
		[EventCode]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblEvents_EventAttribute] WITH NOCHECK ADD 
	CONSTRAINT [PK_tblEvents_EventAttribute] PRIMARY KEY  CLUSTERED 
	(
		[BaseAttributeID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblNotifications_Notification] WITH NOCHECK ADD 
	CONSTRAINT [PK_tblNotifications_Notification] PRIMARY KEY  CLUSTERED 
	(
		[NotificationCode]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblNotifications_NotificationAttributeValueLog] WITH NOCHECK ADD 
	CONSTRAINT [PK_tblNotifications_NotificationLogAttributeValue] PRIMARY KEY  CLUSTERED 
	(
		[NotificationAttributeValueLogID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblNotifications_NotificationLog] WITH NOCHECK ADD 
	CONSTRAINT [PK_tblNotifications_NotificationLog] PRIMARY KEY  CLUSTERED 
	(
		[NotificationLogID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblNotifications_NotificationTemplate] WITH NOCHECK ADD 
	CONSTRAINT [PK_tblNotifications_NotificationTemplate] PRIMARY KEY  CLUSTERED 
	(
		[NotificationTemplateID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblOrders_Order] WITH NOCHECK ADD 
	CONSTRAINT [PK_tblCustomers_Orders] PRIMARY KEY  CLUSTERED 
	(
		[OrderID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblPayments_Payment] WITH NOCHECK ADD 
	CONSTRAINT [PK_tblPayments_Payments] PRIMARY KEY  CLUSTERED 
	(
		[PaymentID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblPayments_PaymentTransactionAttributeValueLog] WITH NOCHECK ADD 
	CONSTRAINT [PK_tblPayments_PaymentTransactionAttributeValueLog] PRIMARY KEY  CLUSTERED 
	(
		[PaymentTransactionAttributeValueLogID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblPayments_PaymentTransactionLog] WITH NOCHECK ADD 
	CONSTRAINT [PK_tblPayments_PaymentTransactions] PRIMARY KEY  CLUSTERED 
	(
		[PaymentTransactionLogID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblUserExperience_AdminHelp] WITH NOCHECK ADD 
	CONSTRAINT [PK_tblUserExperience_AdminHelp] PRIMARY KEY  CLUSTERED 
	(
		[ActivityCode],
		[LocaleCode]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblUserExperience_SiteHelp] WITH NOCHECK ADD 
	CONSTRAINT [PK_tblUserExperience_SiteHelp] PRIMARY KEY  CLUSTERED 
	(
		[SiteHelpCode],
		[LocaleCode]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblUserExperience_SiteLabel] WITH NOCHECK ADD 
	CONSTRAINT [PK_tblStores_SiteLabels] PRIMARY KEY  CLUSTERED 
	(
		[SiteLabelCode],
		[LocaleCode]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblUsers_User] WITH NOCHECK ADD 
	CONSTRAINT [PK_tblUsers_User] PRIMARY KEY  CLUSTERED 
	(
		[UserID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tlkpAccounts_AccountSubType] WITH NOCHECK ADD 
	CONSTRAINT [PK_tlkpAccounts_AccountSubType] PRIMARY KEY  CLUSTERED 
	(
		[AccountSubTypeCode]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tlkpAccounts_CreditCardType] WITH NOCHECK ADD 
	CONSTRAINT [PK_tlkpAccounts_CreditCardType] PRIMARY KEY  CLUSTERED 
	(
		[CreditCardTypeCode]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tlkpAccounts_Currency] WITH NOCHECK ADD 
	CONSTRAINT [PK_tlkpAccounts_Currency] PRIMARY KEY  CLUSTERED 
	(
		[CurrencyCode]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tlkpAccounts_Frequency] WITH NOCHECK ADD 
	CONSTRAINT [PK_tlkpAccounts_Frequency] PRIMARY KEY  CLUSTERED 
	(
		[FrequencyCode]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tlkpAccounts_FundAccountType] WITH NOCHECK ADD 
	CONSTRAINT [PK_tlkpAccounts_FundAccountType] PRIMARY KEY  CLUSTERED 
	(
		[FundAccountTypeCode]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tlkpAccounts_PaymentInstitution] WITH NOCHECK ADD 
	CONSTRAINT [PK_tlkpAccounts_PaymentInstitution] PRIMARY KEY  CLUSTERED 
	(
		[PaymentInstitutionCode]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tlkpCore_AttributeType] WITH NOCHECK ADD 
	CONSTRAINT [PK_tlkpCore_BaseAttributeTypes] PRIMARY KEY  CLUSTERED 
	(
		[AttributeTypeCode]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tlkpCore_DataType] WITH NOCHECK ADD 
	CONSTRAINT [PK_tlkpCore_DataTypes] PRIMARY KEY  CLUSTERED 
	(
		[DataTypeCode]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tlkpCore_Error] WITH NOCHECK ADD 
	CONSTRAINT [PK_tlkpCore_Errors] PRIMARY KEY  CLUSTERED 
	(
		[ErrorNumber]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tlkpCore_EventType] WITH NOCHECK ADD 
	CONSTRAINT [PK_tlkpCore_EventTypes] PRIMARY KEY  CLUSTERED 
	(
		[EventTypeCode]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tlkpCore_SeverityLevel] WITH NOCHECK ADD 
	CONSTRAINT [PK_tlkpCore_SeverityLevels] PRIMARY KEY  CLUSTERED 
	(
		[SeverityLevelCode]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tlkpCustomers_LocationType] WITH NOCHECK ADD 
	CONSTRAINT [PK_tlkpCustomers_LocationType] PRIMARY KEY  CLUSTERED 
	(
		[LocationTypeCode]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tlkpCustomers_MetaPartnerSubType] WITH NOCHECK ADD 
	CONSTRAINT [PK_tlkpCustomers_MetaPartnerSubType] PRIMARY KEY  CLUSTERED 
	(
		[MetaPartnerSubTypeCode]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tlkpEnvironments_Country] WITH NOCHECK ADD 
	CONSTRAINT [PK_tlkpEnvironments_Country] PRIMARY KEY  CLUSTERED 
	(
		[CountryCode]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tlkpEnvironments_DateFormat] WITH NOCHECK ADD 
	CONSTRAINT [PK_tlkpEnvironments_DateFormat] PRIMARY KEY  CLUSTERED 
	(
		[DateFormatCode]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tlkpEnvironments_Locale] WITH NOCHECK ADD 
	CONSTRAINT [PK_tlkpEnvironments_Locale] PRIMARY KEY  CLUSTERED 
	(
		[LocaleCode]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tlkpEvents_EventType] WITH NOCHECK ADD 
	CONSTRAINT [PK_tlkpEvents_EventType] PRIMARY KEY  CLUSTERED 
	(
		[EventTypeCode]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tlkpNotifications_NotificationDeliveryType] WITH NOCHECK ADD 
	CONSTRAINT [PK_tlkpNotifications_NotificationLogSubType] PRIMARY KEY  CLUSTERED 
	(
		[NotificationDeliveryTypeCode]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tlkpOrders_OrderStatus] WITH NOCHECK ADD 
	CONSTRAINT [PK_tlkpOrders_OrderStatus] PRIMARY KEY  CLUSTERED 
	(
		[OrderStatusCode]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tlkpPayments_PaymentStatus] WITH NOCHECK ADD 
	CONSTRAINT [PK_tlkpPayments_PaymentStatus] PRIMARY KEY  CLUSTERED 
	(
		[PaymentStatusCode]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tlkpPayments_TransactionStatus] WITH NOCHECK ADD 
	CONSTRAINT [PK_tlkpPayments_TransactionStatus] PRIMARY KEY  CLUSTERED 
	(
		[TransactionStatusCode]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tlkpPayments_TransactionType] WITH NOCHECK ADD 
	CONSTRAINT [PK_tlkpPayments_TransactionTypes] PRIMARY KEY  CLUSTERED 
	(
		[TransactionTypeCode]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tlkpUserExperience_SiteHelpGroup] WITH NOCHECK ADD 
	CONSTRAINT [PK_tlkpStores_SiteHelpGroups] PRIMARY KEY  CLUSTERED 
	(
		[SiteHelpGroupCode]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tlkpUsers_AccessMode] WITH NOCHECK ADD 
	CONSTRAINT [PK_tlkpCore_AccessMode] PRIMARY KEY  CLUSTERED 
	(
		[AccessModeCode]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tlkpUsers_Activity] WITH NOCHECK ADD 
	CONSTRAINT [PK_tlkpUsers_Activities] PRIMARY KEY  CLUSTERED 
	(
		[ActivityCode]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tlkpUsers_UserRole] WITH NOCHECK ADD 
	CONSTRAINT [PK_tlkpUsers_UserRoles] PRIMARY KEY  CLUSTERED 
	(
		[UserRoleCode]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[trelAccounts_LoanToMetaPartner] WITH NOCHECK ADD 
	CONSTRAINT [PK_trelAccounts_LoanToMetaPartner] PRIMARY KEY  CLUSTERED 
	(
		[AccountID],
		[MetaPartnerID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[trelAccounts_ParticipatingPartner] WITH NOCHECK ADD 
	CONSTRAINT [PK_trelAccounts_ParticipatingPartner] PRIMARY KEY  CLUSTERED 
	(
		[AccountID],
		[MetaPartnerID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[trelCustomers_BusinessCustomer] WITH NOCHECK ADD 
	CONSTRAINT [PK_trelCustomers_BusinessCustomer] PRIMARY KEY  CLUSTERED 
	(
		[BusinessMetaPartnerID],
		[CustomerMetaPartnerID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[trelCustomers_MetaPartnerContact] WITH NOCHECK ADD 
	CONSTRAINT [PK_trelCustomers_MetaPartnerContact] PRIMARY KEY  CLUSTERED 
	(
		[MetaPartnerID],
		[ContactMetaPartnerID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[trelEvents_SpecificEventAttribute] WITH NOCHECK ADD 
	CONSTRAINT [PK_trelEvents_SpecificEventAttribute] PRIMARY KEY  CLUSTERED 
	(
		[EventCode],
		[BaseAttributeID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[trelNotifications_NotificationDeliveryLog] WITH NOCHECK ADD 
	CONSTRAINT [PK_trelNotifications_NotificationDeliveryLog] PRIMARY KEY  CLUSTERED 
	(
		[NotificationLogID],
		[MetaPartnerID],
		[NotificationDeliveryTypeCode]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[trelUsers_UserRoleActivity] WITH NOCHECK ADD 
	CONSTRAINT [PK_trelUsers_UserRoles_Activities] PRIMARY KEY  CLUSTERED 
	(
		[UserRoleCode],
		[ActivityCode],
		[AccessModeCode]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[trelUsers_UserRoleUser] WITH NOCHECK ADD 
	CONSTRAINT [PK_trelUsers_UserRoleUser] PRIMARY KEY  CLUSTERED 
	(
		[UserRoleCode],
		[UserID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblAccounts_Account] ADD 
	CONSTRAINT [DF_tblAccounts_Account_IsActive] DEFAULT (0) FOR [IsActive],
	CONSTRAINT [DF_tblAccounts_Account_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tblAccounts_Account_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate],
	CONSTRAINT [IX_tblAccounts_Account] UNIQUE  NONCLUSTERED 
	(
		[AccountID],
		[MetaPartnerID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblAccounts_AccountAttribute] ADD 
	CONSTRAINT [DF_tblAccounts_AccountAttribute_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tblAccounts_AccountAttribute_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate],
	CONSTRAINT [IX_tblAccounts_AccountAttribute] UNIQUE  NONCLUSTERED 
	(
		[AttributeCode]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblAccounts_AccountAttributeValue] ADD 
	CONSTRAINT [DF_tblAccounts_AccountAttributeValue_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tblAccounts_AccountAttributeValue_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[tblAccounts_BankAccount] ADD 
	CONSTRAINT [DF_tblAccounts_BankAccount_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tblAccounts_BankAccount_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[tblAccounts_BillPayAccount] ADD 
	CONSTRAINT [DF_tblAccounts_BillPayAccount_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tblAccounts_BillPayAccount_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[tblAccounts_CreditAccount] ADD 
	CONSTRAINT [DF_tblAccounts_CreditAccount_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tblAccounts_CreditAccount_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[tblAccounts_CurrencyConversion] ADD 
	CONSTRAINT [DF_tblAccounts_CurrencyConversion_IsActive] DEFAULT (0) FOR [IsActive],
	CONSTRAINT [DF_tblAccounts_CurrencyConversion_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tblAccounts_CurrencyConversion_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[tblAccounts_DebitAccount] ADD 
	CONSTRAINT [DF_tblAccounts_DebitAccount_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tblAccounts_DebitAccount_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[tblAccounts_FundAccount] ADD 
	CONSTRAINT [DF_tblAccounts_FundAccount_IsPublic] DEFAULT (0) FOR [IsPublic],
	CONSTRAINT [DF_tblAccounts_FundAccount_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tblAccounts_FundAccount_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[tblAccounts_LoanAccount] ADD 
	CONSTRAINT [DF_tblAccounts_LoanAccount_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tblAccounts_LoanAccount_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[tblAccounts_MetaTransferAccount] ADD 
	CONSTRAINT [DF_tblAccounts_MetaTransferAccount_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tblAccounts_MetaTransferAccount_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[tblAccounts_StoredValueAccount] ADD 
	CONSTRAINT [DF_tblAccounts_StoredValueAccount_Balance] DEFAULT (0) FOR [Balance],
	CONSTRAINT [DF_tblAccounts_StoredValueAccount_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tblAccounts_StoredValueAccount_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate],
	CONSTRAINT [IX_tblAccounts_StoredValueAccount] UNIQUE  NONCLUSTERED 
	(
		[AccountID],
		[PhoneMetaPartnerID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblCore_BaseAttribute] ADD 
	CONSTRAINT [DF_tblCore_BaseAttribute_BaseAttributeID] DEFAULT (newid()) FOR [BaseAttributeID],
	CONSTRAINT [DF_tblCore_BaseAttributes_IsActive] DEFAULT (0) FOR [IsActive],
	CONSTRAINT [DF_tblCore_BaseAttributes_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tblCore_BaseAttributes_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[tblCore_DebugAttribute] ADD 
	CONSTRAINT [DF_tblCore_DebugAttributes_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tblCore_DebugAttributes_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate],
	CONSTRAINT [IX_tblCore_DebugAttributes] UNIQUE  NONCLUSTERED 
	(
		[AttributeCode]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblCore_DebugAttributeValueLog] ADD 
	CONSTRAINT [DF_tblCore_DebugLogs_DebugAttributeValueID] DEFAULT (newid()) FOR [DebugAttributeValueLogID],
	CONSTRAINT [DF_tblCore_DebugAttributeValues_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tblCore_DebugAttributeValues_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate],
	CONSTRAINT [IX_tblCore_DebugAttributeValues] UNIQUE  NONCLUSTERED 
	(
		[DebugAttributeValueLogID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblCore_DebugLog] ADD 
	CONSTRAINT [DF_tblCore_DebugLogs_DebugLogID] DEFAULT (newid()) FOR [DebugLogID],
	CONSTRAINT [DF_tblCore_DebugLogs_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tblCore_DebugLogs_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[tblCustomers_Bank] ADD 
	CONSTRAINT [DF_tblCustomers_Bank_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tblCustomers_Bank_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate],
	CONSTRAINT [IX_tblCustomers_Bank] UNIQUE  NONCLUSTERED 
	(
		[BankCode]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblCustomers_Business] ADD 
	CONSTRAINT [DF_tblCustomers_Business_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tblCustomers_Business_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[tblCustomers_Carrier] ADD 
	CONSTRAINT [DF_tblCustomers_Carrier_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tblCustomers_Carrier_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate],
	CONSTRAINT [IX_tblCustomers_Carrier] UNIQUE  NONCLUSTERED 
	(
		[CarrierCode]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblCustomers_Customer] ADD 
	CONSTRAINT [DF_tblCustomers_Customer_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tblCustomers_Customer_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[tblCustomers_Location] ADD 
	CONSTRAINT [DF_tblCustomers_Location_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tblCustomers_Location_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[tblCustomers_Merchant] ADD 
	CONSTRAINT [DF_tblCustomers_Merchant_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tblCustomers_Merchant_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[tblCustomers_MetaPartner] ADD 
	CONSTRAINT [DF_tblCustomers_MetaPartner_IsActive] DEFAULT (1) FOR [IsActive],
	CONSTRAINT [DF_tblCustomers_Customers_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tblCustomers_Customers_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[tblCustomers_MetaPartnerEmail] ADD 
	CONSTRAINT [DF_tblCustomers_MetaPartnerEmail_Rank] DEFAULT (0) FOR [Rank],
	CONSTRAINT [DF_tblCustomers_MetaPartnerEmail_IsActive] DEFAULT (0) FOR [IsActive],
	CONSTRAINT [DF_tblCustomers_MetaPartnerEmail_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tblCustomers_MetaPartnerEmail_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate],
	CONSTRAINT [IX_tblCustomers_MetaPartnerEmail] UNIQUE  NONCLUSTERED 
	(
		[EmailAddress]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblCustomers_MetaPartnerPhone] ADD 
	CONSTRAINT [DF_tblCustomers_MetaPartnerPhone_Rank] DEFAULT (0) FOR [Rank],
	CONSTRAINT [DF_tblCustomers_MetaPartnerPhone_IsActive] DEFAULT (0) FOR [IsActive],
	CONSTRAINT [DF_tblCustomers_MetaPartnerPhone_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tblCustomers_MetaPartnerPhone_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate],
	CONSTRAINT [IX_tblCustomers_MetaPartnerPhone] UNIQUE  NONCLUSTERED 
	(
		[PhoneNumber]
	)  ON [PRIMARY] ,
	CONSTRAINT [IX_tblCustomers_MetaPartnerPhone_1] UNIQUE  NONCLUSTERED 
	(
		[MetaPartnerPhoneID],
		[MetaPartnerID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblEvents_Event] ADD 
	CONSTRAINT [DF_tblEvents_Events_IsActive] DEFAULT (0) FOR [IsActive],
	CONSTRAINT [DF_tblEvents_Events_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tblEvents_Events_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[tblEvents_EventAttribute] ADD 
	CONSTRAINT [DF_tblEvents_EventAttribute_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tblEvents_EventAttribute_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate],
	CONSTRAINT [IX_tblEvents_EventAttribute] UNIQUE  NONCLUSTERED 
	(
		[AttributeCode]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblNotifications_Notification] ADD 
	CONSTRAINT [DF_tblNotifications_Notifications_IsActive] DEFAULT (0) FOR [IsActive],
	CONSTRAINT [DF_tblNotifications_Notifications_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tblNotifications_Notifications_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[tblNotifications_NotificationAttributeValueLog] ADD 
	CONSTRAINT [DF_tblNotifications_NotificationLogAttributeValue_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tblNotifications_NotificationLogAttributeValue_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[tblNotifications_NotificationLog] ADD 
	CONSTRAINT [DF_tblNotifications_NotificationLog_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tblNotifications_NotificationLog_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[tblNotifications_NotificationTemplate] ADD 
	CONSTRAINT [DF_tblNotifications_NotificationTemplate_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tblNotifications_NotificationTemplate_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[tblOrders_Order] ADD 
	CONSTRAINT [DF_tblCustomers_Orders_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tblCustomers_Orders_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate],
	CONSTRAINT [IX_tblOrders_Order] UNIQUE  NONCLUSTERED 
	(
		[OrderID],
		[DebitMetaPartnerID],
		[CreditMetaPartnerID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblPayments_Payment] ADD 
	CONSTRAINT [DF_tblPayments_Payments_PaymentID] DEFAULT (newid()) FOR [PaymentID],
	CONSTRAINT [DF_tblPayments_Payments_PaymentAmount] DEFAULT (0) FOR [PaymentAmount],
	CONSTRAINT [DF_tblPayments_Payments_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tblPayments_Payments_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[tblPayments_PaymentTransactionAttributeValueLog] ADD 
	CONSTRAINT [DF_tblPayments_PaymentTransactionAttributeValueLog_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tblPayments_PaymentTransactionAttributeValueLog_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[tblPayments_PaymentTransactionLog] ADD 
	CONSTRAINT [DF_tblPayments_PaymentTransaction_PaymentTransactionID] DEFAULT (newid()) FOR [PaymentTransactionLogID],
	CONSTRAINT [DF_tblPayments_PaymentTransactions_TransactionAmount] DEFAULT (0) FOR [TransactionAmount],
	CONSTRAINT [DF_tblPayments_PaymentTransactions_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tblPayments_PaymentTransactions_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[tblUserExperience_AdminHelp] ADD 
	CONSTRAINT [DF_tblStores_AdminHelp_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tblStores_AdminHelp_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[tblUserExperience_SiteHelp] ADD 
	CONSTRAINT [DF_tblStores_SiteHelp_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tblStores_SiteHelp_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[tblUserExperience_SiteLabel] ADD 
	CONSTRAINT [DF_tblStores_SiteLabels_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tblStores_SiteLabels_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[tblUsers_User] ADD 
	CONSTRAINT [DF_tblUsers_Users_UserID] DEFAULT (newid()) FOR [UserID],
	CONSTRAINT [DF_tblUsers_Users_IsActive] DEFAULT (0) FOR [IsActive],
	CONSTRAINT [DF_tblUsers_Users_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tblUsers_Users_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate],
	CONSTRAINT [IX_tblUsers_User] UNIQUE  NONCLUSTERED 
	(
		[FirstName],
		[LastName],
		[Password]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tlkpAccounts_AccountSubType] ADD 
	CONSTRAINT [DF_tlkpAccounts_AccountSubType_IsActive] DEFAULT (0) FOR [IsActive],
	CONSTRAINT [DF_tlkpAccounts_AccountSubType_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tlkpAccounts_AccountSubType_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[tlkpAccounts_CreditCardType] ADD 
	CONSTRAINT [DF_tlkpAccounts_CreditCardType_IsActive] DEFAULT (0) FOR [IsActive],
	CONSTRAINT [DF_tlkpAccounts_CreditCardType_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tlkpAccounts_CreditCardType_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[tlkpAccounts_Currency] ADD 
	CONSTRAINT [DF_tlkpAccounts_Currency_IsPaymentCurrency] DEFAULT (1) FOR [IsPaymentCurrency],
	CONSTRAINT [DF_tlkpAccounts_Currency_IsActive] DEFAULT (0) FOR [IsActive],
	CONSTRAINT [DF_tlkpAccounts_Currency_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tlkpAccounts_Currency_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[tlkpAccounts_Frequency] ADD 
	CONSTRAINT [DF_tlkpAccounts_Frequency_IsActive] DEFAULT (0) FOR [IsActive],
	CONSTRAINT [DF_tlkpAccounts_Frequency_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tlkpAccounts_Frequency_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[tlkpAccounts_FundAccountType] ADD 
	CONSTRAINT [DF_tlkpAccounts_FundAccountType_IsActive] DEFAULT (0) FOR [IsActive],
	CONSTRAINT [DF_tlkpAccounts_FundAccountType_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tlkpAccounts_FundAccountType_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[tlkpAccounts_PaymentInstitution] ADD 
	CONSTRAINT [DF_tlkpAccounts_PaymentInstitution_IsActive] DEFAULT (0) FOR [IsActive],
	CONSTRAINT [DF_tlkpAccounts_PaymentInstitution_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tlkpAccounts_PaymentInstitution_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[tlkpCore_AttributeType] ADD 
	CONSTRAINT [DF_tlkpCore_BaseAttributeTypes_IsActive] DEFAULT (0) FOR [IsActive],
	CONSTRAINT [DF_tlkpCore_BaseAttributeTypes_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tlkpCore_BaseAttributeTypes_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[tlkpCore_DataType] ADD 
	CONSTRAINT [DF_tlkpCore_DataTypes_IsActive] DEFAULT (0) FOR [IsActive],
	CONSTRAINT [DF_tlkpCore_DataTypes_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tlkpCore_DataTypes_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[tlkpCore_Error] ADD 
	CONSTRAINT [DF_tlkpCore_Errors_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tlkpCore_Errors_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[tlkpCore_EventType] ADD 
	CONSTRAINT [DF_tlkpCore_EventTypes_IsActive] DEFAULT (0) FOR [IsActive],
	CONSTRAINT [DF_tlkpCore_EventTypes_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tlkpCore_EventTypes_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[tlkpCore_SeverityLevel] ADD 
	CONSTRAINT [DF_tlkpCore_SeverityLevels_IsActive] DEFAULT (0) FOR [IsActive],
	CONSTRAINT [DF_tlkpCore_SeverityLevels_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tlkpCore_SeverityLevels_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[tlkpCustomers_LocationType] ADD 
	CONSTRAINT [DF_tlkpCustomers_LocationType_IsActive] DEFAULT (0) FOR [IsActive],
	CONSTRAINT [DF_tlkpCustomers_LocationType_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tlkpCustomers_LocationType_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[tlkpCustomers_MetaPartnerSubType] ADD 
	CONSTRAINT [DF_tlkpCustomers_MetaPartnerSubType_IsActive] DEFAULT (0) FOR [IsActive],
	CONSTRAINT [DF_tlkpCustomers_MetaPartnerSubType_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tlkpCustomers_MetaPartnerSubType_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[tlkpEnvironments_Country] ADD 
	CONSTRAINT [DF_tlkpEnvironments_Country_IsActive] DEFAULT (0) FOR [IsActive],
	CONSTRAINT [DF_tlkpEnvironments_Country_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tlkpEnvironments_Country_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[tlkpEnvironments_DateFormat] ADD 
	CONSTRAINT [DF_tlkpEnvironments_DateFormat_IsActive] DEFAULT (0) FOR [IsActive],
	CONSTRAINT [DF_tlkpEnvironments_DateFormat_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tlkpEnvironments_DateFormat_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[tlkpEnvironments_Locale] ADD 
	CONSTRAINT [DF_tlkpEnvironments_Locale_IsActive] DEFAULT (0) FOR [IsActive],
	CONSTRAINT [DF_tlkpEnvironments_Locale_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tlkpEnvironments_Locale_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[tlkpEvents_EventType] ADD 
	CONSTRAINT [DF_tlkpEvents_EventType_IsActive] DEFAULT (1) FOR [IsActive],
	CONSTRAINT [DF_tlkpEvents_EventType_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tlkpEvents_EventType_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[tlkpNotifications_NotificationDeliveryType] ADD 
	CONSTRAINT [DF_tlkpNotifications_NotificationLogSubType_IsActive] DEFAULT (0) FOR [IsActive],
	CONSTRAINT [DF_tlkpNotifications_NotificationLogSubType_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tlkpNotifications_NotificationLogSubType_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[tlkpOrders_OrderStatus] ADD 
	CONSTRAINT [DF_tlkpOrders_OrderStatus_IsActive] DEFAULT (0) FOR [IsActive],
	CONSTRAINT [DF_tlkpOrders_OrderStatus_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tlkpOrders_OrderStatus_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[tlkpPayments_PaymentStatus] ADD 
	CONSTRAINT [DF_tlkpPayments_PaymentStatus_IsActive] DEFAULT (1) FOR [IsActive],
	CONSTRAINT [DF_tlkpPayments_PaymentStatus_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tlkpPayments_PaymentStatus_LastModifedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[tlkpPayments_TransactionStatus] ADD 
	CONSTRAINT [DF_tlkpPayments_TransactionStatus_IsActive] DEFAULT (0) FOR [IsActive],
	CONSTRAINT [DF_tlkpPayments_TransactionStatus_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tlkpPayments_TransactionStatus_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[tlkpPayments_TransactionType] ADD 
	CONSTRAINT [DF_tlkpPayments_TransactionTypes_IsActive] DEFAULT (0) FOR [IsActive],
	CONSTRAINT [DF_tlkpPayments_TransactionTypes_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tlkpPayments_TransactionTypes_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[tlkpUserExperience_SiteHelpGroup] ADD 
	CONSTRAINT [DF_tlkpStores_SiteHelpGroups_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tlkpStores_SiteHelpGroups_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[tlkpUsers_AccessMode] ADD 
	CONSTRAINT [DF_tlkpCore_AccessMode_IsActive] DEFAULT (0) FOR [IsActive],
	CONSTRAINT [DF_tlkpCore_AccessMode_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tlkpCore_AccessMode_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[tlkpUsers_Activity] ADD 
	CONSTRAINT [DF_tlkpUsers_Activities_IsActive] DEFAULT (0) FOR [IsActive],
	CONSTRAINT [DF_tlkpUsers_Activities_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tlkpUsers_Activities_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate],
	CONSTRAINT [IX_tlkpUsers_Activity] UNIQUE  NONCLUSTERED 
	(
		[ActivityName]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tlkpUsers_UserRole] ADD 
	CONSTRAINT [DF_tlkpUsers_UserRoles_IsActive] DEFAULT (0) FOR [IsActive],
	CONSTRAINT [DF_tlkpUsers_UserRoles_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tlkpUsers_UserRoles_LastModifedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[trelAccounts_LoanToMetaPartner] ADD 
	CONSTRAINT [DF_trelAccounts_LoanToMetaPartner_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_trelAccounts_LoanToMetaPartner_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[trelAccounts_ParticipatingPartner] ADD 
	CONSTRAINT [DF_trelAccounts_ParticipatingPartner_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_trelAccounts_ParticipatingPartner_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[trelCustomers_BusinessCustomer] ADD 
	CONSTRAINT [DF_trelCustomers_BusinessCustomer_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_trelCustomers_BusinessCustomer_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[trelCustomers_MetaPartnerContact] ADD 
	CONSTRAINT [DF_trelCustomers_MetaPartnerContact_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_trelCustomers_MetaPartnerContact_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[trelEvents_SpecificEventAttribute] ADD 
	CONSTRAINT [DF_trelEvents_SpecificEventAttribute_Rank] DEFAULT (0) FOR [Rank],
	CONSTRAINT [DF_trelEvents_SpecificEventAttribute_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_trelEvents_SpecificEventAttribute_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[trelNotifications_NotificationDeliveryLog] ADD 
	CONSTRAINT [DF_trelNotifications_NotificationDeliveryLog_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_trelNotifications_NotificationDeliveryLog_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[trelUsers_UserRoleActivity] ADD 
	CONSTRAINT [DF_trelUsers_UserRoles_Activities_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_trelUsers_UserRoles_Activities_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[trelUsers_UserRoleUser] ADD 
	CONSTRAINT [DF_trelUsers_UserRoles_Users_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_trelUsers_UserRoles_Users_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[tblAccounts_Account] ADD 
	CONSTRAINT [FK_tblAccounts_Account_tblCustomers_MetaPartner] FOREIGN KEY 
	(
		[MetaPartnerID]
	) REFERENCES [dbo].[tblCustomers_MetaPartner] (
		[MetaPartnerID]
	),
	CONSTRAINT [FK_tblAccounts_Account_tlkpAccounts_AccountSubType] FOREIGN KEY 
	(
		[AccountSubTypeCode]
	) REFERENCES [dbo].[tlkpAccounts_AccountSubType] (
		[AccountSubTypeCode]
	),
	CONSTRAINT [FK_tblAccounts_Account_tlkpAccounts_Currency] FOREIGN KEY 
	(
		[CurrencyCode]
	) REFERENCES [dbo].[tlkpAccounts_Currency] (
		[CurrencyCode]
	)
GO

ALTER TABLE [dbo].[tblAccounts_AccountAttribute] ADD 
	CONSTRAINT [FK_tblAccounts_AccountAttribute_tblCore_BaseAttribute] FOREIGN KEY 
	(
		[BaseAttributeID]
	) REFERENCES [dbo].[tblCore_BaseAttribute] (
		[BaseAttributeID]
	)
GO

ALTER TABLE [dbo].[tblAccounts_AccountAttributeValue] ADD 
	CONSTRAINT [FK_tblAccounts_AccountAttributeValue_tblAccounts_Account] FOREIGN KEY 
	(
		[AccountID]
	) REFERENCES [dbo].[tblAccounts_Account] (
		[AccountID]
	),
	CONSTRAINT [FK_tblAccounts_AccountAttributeValue_tblAccounts_AccountAttribute] FOREIGN KEY 
	(
		[BaseAttributeID]
	) REFERENCES [dbo].[tblAccounts_AccountAttribute] (
		[BaseAttributeID]
	)
GO

ALTER TABLE [dbo].[tblAccounts_BankAccount] ADD 
	CONSTRAINT [FK_tblAccounts_BankAccount_tblAccounts_DebitAccount] FOREIGN KEY 
	(
		[AccountID]
	) REFERENCES [dbo].[tblAccounts_DebitAccount] (
		[AccountID]
	),
	CONSTRAINT [FK_tblAccounts_BankAccount_tblCustomers_Bank] FOREIGN KEY 
	(
		[BankMetaPartnerID]
	) REFERENCES [dbo].[tblCustomers_Bank] (
		[MetaPartnerID]
	)
GO

ALTER TABLE [dbo].[tblAccounts_BillPayAccount] ADD 
	CONSTRAINT [FK_tblAccounts_BillPayAccount_tblAccounts_Account] FOREIGN KEY 
	(
		[AccountID]
	) REFERENCES [dbo].[tblAccounts_Account] (
		[AccountID]
	),
	CONSTRAINT [FK_tblAccounts_BillPayAccount_tblCustomers_Business] FOREIGN KEY 
	(
		[BusinessMetaPartnerID]
	) REFERENCES [dbo].[tblCustomers_Business] (
		[MetaPartnerID]
	),
	CONSTRAINT [FK_tblAccounts_BillPayAccount_tlkpAccounts_Frequency] FOREIGN KEY 
	(
		[FrequencyCode]
	) REFERENCES [dbo].[tlkpAccounts_Frequency] (
		[FrequencyCode]
	)
GO

ALTER TABLE [dbo].[tblAccounts_CreditAccount] ADD 
	CONSTRAINT [FK_tblAccounts_CreditAccount_tblAccounts_Account] FOREIGN KEY 
	(
		[AccountID]
	) REFERENCES [dbo].[tblAccounts_Account] (
		[AccountID]
	),
	CONSTRAINT [FK_tblAccounts_CreditAccount_tlkpAccounts_CreditCardType] FOREIGN KEY 
	(
		[CreditCardTypeCode]
	) REFERENCES [dbo].[tlkpAccounts_CreditCardType] (
		[CreditCardTypeCode]
	)
GO

ALTER TABLE [dbo].[tblAccounts_CurrencyConversion] ADD 
	CONSTRAINT [FK_tblAccounts_CurrencyConversion_tblCustomers_Business] FOREIGN KEY 
	(
		[MetaPartnerID]
	) REFERENCES [dbo].[tblCustomers_Business] (
		[MetaPartnerID]
	),
	CONSTRAINT [FK_tblAccounts_CurrencyConversion_tlkpAccounts_Currency] FOREIGN KEY 
	(
		[ConvertFromCurrencyCode]
	) REFERENCES [dbo].[tlkpAccounts_Currency] (
		[CurrencyCode]
	),
	CONSTRAINT [FK_tblAccounts_CurrencyConversion_tlkpAccounts_Currency1] FOREIGN KEY 
	(
		[ConvertToCurrencyCode]
	) REFERENCES [dbo].[tlkpAccounts_Currency] (
		[CurrencyCode]
	)
GO

ALTER TABLE [dbo].[tblAccounts_DebitAccount] ADD 
	CONSTRAINT [FK_tblAccounts_DebitAccount_tblAccounts_Account1] FOREIGN KEY 
	(
		[AccountID]
	) REFERENCES [dbo].[tblAccounts_Account] (
		[AccountID]
	)
GO

ALTER TABLE [dbo].[tblAccounts_FundAccount] ADD 
	CONSTRAINT [FK_tblAccounts_FundAccount_tblAccounts_Account] FOREIGN KEY 
	(
		[AccountID]
	) REFERENCES [dbo].[tblAccounts_Account] (
		[AccountID]
	),
	CONSTRAINT [FK_tblAccounts_FundAccount_tlkpAccounts_Frequency] FOREIGN KEY 
	(
		[FrequencyCode]
	) REFERENCES [dbo].[tlkpAccounts_Frequency] (
		[FrequencyCode]
	),
	CONSTRAINT [FK_tblAccounts_FundAccount_tlkpAccounts_FundAccountType] FOREIGN KEY 
	(
		[FundAccountTypeCode]
	) REFERENCES [dbo].[tlkpAccounts_FundAccountType] (
		[FundAccountTypeCode]
	)
GO

ALTER TABLE [dbo].[tblAccounts_LoanAccount] ADD 
	CONSTRAINT [FK_tblAccounts_LoanAccount_tblAccounts_Account] FOREIGN KEY 
	(
		[AccountID]
	) REFERENCES [dbo].[tblAccounts_Account] (
		[AccountID]
	)
GO

ALTER TABLE [dbo].[tblAccounts_MetaTransferAccount] ADD 
	CONSTRAINT [FK_tblAccounts_MetaTransferAccount_tblAccounts_Account] FOREIGN KEY 
	(
		[AccountID]
	) REFERENCES [dbo].[tblAccounts_Account] (
		[AccountID]
	),
	CONSTRAINT [FK_tblAccounts_MetaTransferAccount_tlkpAccounts_PaymentInstitution] FOREIGN KEY 
	(
		[PaymentInstitutionCode]
	) REFERENCES [dbo].[tlkpAccounts_PaymentInstitution] (
		[PaymentInstitutionCode]
	)
GO

ALTER TABLE [dbo].[tblAccounts_StoredValueAccount] ADD 
	CONSTRAINT [FK_tblAccounts_StoredValueAccount_tblAccounts_Account1] FOREIGN KEY 
	(
		[AccountID],
		[PhoneMetaPartnerID]
	) REFERENCES [dbo].[tblAccounts_Account] (
		[AccountID],
		[MetaPartnerID]
	),
	CONSTRAINT [FK_tblAccounts_StoredValueAccount_tblAccounts_DebitAccount1] FOREIGN KEY 
	(
		[AccountID]
	) REFERENCES [dbo].[tblAccounts_DebitAccount] (
		[AccountID]
	),
	CONSTRAINT [FK_tblAccounts_StoredValueAccount_tblCustomers_MetaPartnerPhone1] FOREIGN KEY 
	(
		[MetaPartnerPhoneID],
		[PhoneMetaPartnerID]
	) REFERENCES [dbo].[tblCustomers_MetaPartnerPhone] (
		[MetaPartnerPhoneID],
		[MetaPartnerID]
	)
GO

ALTER TABLE [dbo].[tblCore_BaseAttribute] ADD 
	CONSTRAINT [FK_tblCore_BaseAttributes_tlkpCore_BaseAttributeTypes] FOREIGN KEY 
	(
		[AttributeTypeCode]
	) REFERENCES [dbo].[tlkpCore_AttributeType] (
		[AttributeTypeCode]
	),
	CONSTRAINT [FK_tblCore_BaseAttributes_tlkpCore_DataTypes] FOREIGN KEY 
	(
		[DataTypeCode]
	) REFERENCES [dbo].[tlkpCore_DataType] (
		[DataTypeCode]
	)
GO

ALTER TABLE [dbo].[tblCore_DebugAttribute] ADD 
	CONSTRAINT [FK_tblCore_DebugAttribute_tblCore_BaseAttribute] FOREIGN KEY 
	(
		[BaseAttributeID]
	) REFERENCES [dbo].[tblCore_BaseAttribute] (
		[BaseAttributeID]
	)
GO

ALTER TABLE [dbo].[tblCore_DebugAttributeValueLog] ADD 
	CONSTRAINT [FK_tblCORE_DebugAttributeValueLog_tblCORE_DebugAttribute] FOREIGN KEY 
	(
		[BaseAttributeID]
	) REFERENCES [dbo].[tblCore_DebugAttribute] (
		[BaseAttributeID]
	),
	CONSTRAINT [FK_tblCore_DebugAttributeValues_tblCore_DebugLogs] FOREIGN KEY 
	(
		[DebugLogID]
	) REFERENCES [dbo].[tblCore_DebugLog] (
		[DebugLogID]
	)
GO

ALTER TABLE [dbo].[tblCore_DebugLog] ADD 
	CONSTRAINT [FK_tblCore_DebugLogs_tlkpCore_EventTypes] FOREIGN KEY 
	(
		[EventTypeCode]
	) REFERENCES [dbo].[tlkpCore_EventType] (
		[EventTypeCode]
	),
	CONSTRAINT [FK_tblCore_DebugLogs_tlkpCore_SeverityLevels] FOREIGN KEY 
	(
		[SeverityLevelCode]
	) REFERENCES [dbo].[tlkpCore_SeverityLevel] (
		[SeverityLevelCode]
	)
GO

ALTER TABLE [dbo].[tblCustomers_Bank] ADD 
	CONSTRAINT [FK_tblCustomers_Bank_tblCustomers_Business] FOREIGN KEY 
	(
		[MetaPartnerID]
	) REFERENCES [dbo].[tblCustomers_Business] (
		[MetaPartnerID]
	)
GO

ALTER TABLE [dbo].[tblCustomers_Business] ADD 
	CONSTRAINT [FK_tblCustomers_Business_tblCustomers_MetaPartner] FOREIGN KEY 
	(
		[MetaPartnerID]
	) REFERENCES [dbo].[tblCustomers_MetaPartner] (
		[MetaPartnerID]
	)
GO

ALTER TABLE [dbo].[tblCustomers_Carrier] ADD 
	CONSTRAINT [FK_tblCustomers_Carrier_tblCustomers_Business] FOREIGN KEY 
	(
		[MetaPartnerID]
	) REFERENCES [dbo].[tblCustomers_Business] (
		[MetaPartnerID]
	)
GO

ALTER TABLE [dbo].[tblCustomers_Customer] ADD 
	CONSTRAINT [FK_tblCustomers_Customer_tblCustomers_MetaPartner] FOREIGN KEY 
	(
		[MetaPartnerID]
	) REFERENCES [dbo].[tblCustomers_MetaPartner] (
		[MetaPartnerID]
	)
GO

ALTER TABLE [dbo].[tblCustomers_Location] ADD 
	CONSTRAINT [FK_tblCustomers_Location_tblCustomers_MetaPartner] FOREIGN KEY 
	(
		[MetaPartnerID]
	) REFERENCES [dbo].[tblCustomers_MetaPartner] (
		[MetaPartnerID]
	),
	CONSTRAINT [FK_tblCustomers_Location_tlkpCustomers_LocationType] FOREIGN KEY 
	(
		[LocationTypeCode]
	) REFERENCES [dbo].[tlkpCustomers_LocationType] (
		[LocationTypeCode]
	),
	CONSTRAINT [FK_tblCustomers_Location_tlkpEnvironments_Country] FOREIGN KEY 
	(
		[CountryCode]
	) REFERENCES [dbo].[tlkpEnvironments_Country] (
		[CountryCode]
	)
GO

ALTER TABLE [dbo].[tblCustomers_Merchant] ADD 
	CONSTRAINT [FK_tblCustomers_Merchant_tblCustomers_Business] FOREIGN KEY 
	(
		[MetaPartnerID]
	) REFERENCES [dbo].[tblCustomers_Business] (
		[MetaPartnerID]
	)
GO

ALTER TABLE [dbo].[tblCustomers_MetaPartner] ADD 
	CONSTRAINT [FK_tblCustomers_MetaPartner_tlkpAccounts_Currency] FOREIGN KEY 
	(
		[CurrencyCode]
	) REFERENCES [dbo].[tlkpAccounts_Currency] (
		[CurrencyCode]
	),
	CONSTRAINT [FK_tblCustomers_MetaPartner_tlkpCustomers_MetaPartnerSubType] FOREIGN KEY 
	(
		[MetaPartnerSubTypeCode]
	) REFERENCES [dbo].[tlkpCustomers_MetaPartnerSubType] (
		[MetaPartnerSubTypeCode]
	),
	CONSTRAINT [FK_tblCustomers_MetaPartner_tlkpEnvironments_DateFormat] FOREIGN KEY 
	(
		[DateFormatCode]
	) REFERENCES [dbo].[tlkpEnvironments_DateFormat] (
		[DateFormatCode]
	),
	CONSTRAINT [FK_tblCustomers_MetaPartner_tlkpEnvironments_Locale] FOREIGN KEY 
	(
		[LocaleCode]
	) REFERENCES [dbo].[tlkpEnvironments_Locale] (
		[LocaleCode]
	)
GO

ALTER TABLE [dbo].[tblCustomers_MetaPartnerEmail] ADD 
	CONSTRAINT [FK_tblCustomers_MetaPartnerEmail_tblCustomers_MetaPartner] FOREIGN KEY 
	(
		[MetaPartnerID]
	) REFERENCES [dbo].[tblCustomers_MetaPartner] (
		[MetaPartnerID]
	)
GO

ALTER TABLE [dbo].[tblCustomers_MetaPartnerPhone] ADD 
	CONSTRAINT [FK_tblCustomers_MetaPartnerPhone_tblCustomers_Carrier] FOREIGN KEY 
	(
		[CarrierMetaPartnerID]
	) REFERENCES [dbo].[tblCustomers_Carrier] (
		[MetaPartnerID]
	),
	CONSTRAINT [FK_tblCustomers_MetaPartnerPhone_tblCustomers_MetaPartner] FOREIGN KEY 
	(
		[MetaPartnerID]
	) REFERENCES [dbo].[tblCustomers_MetaPartner] (
		[MetaPartnerID]
	)
GO

ALTER TABLE [dbo].[tblEvents_Event] ADD 
	CONSTRAINT [FK_tblEvents_Events_tlkpEvents_EventType] FOREIGN KEY 
	(
		[EventTypeCode]
	) REFERENCES [dbo].[tlkpEvents_EventType] (
		[EventTypeCode]
	)
GO

ALTER TABLE [dbo].[tblEvents_EventAttribute] ADD 
	CONSTRAINT [UPDATEBASE_FK_tblEvents_EventAttribute_tblCore_BaseAttribute] FOREIGN KEY 
	(
		[BaseAttributeID]
	) REFERENCES [dbo].[tblCore_BaseAttribute] (
		[BaseAttributeID]
	)
GO

ALTER TABLE [dbo].[tblNotifications_Notification] ADD 
	CONSTRAINT [FK_tblNotifications_Notification_tblEvents_Event] FOREIGN KEY 
	(
		[EventCode]
	) REFERENCES [dbo].[tblEvents_Event] (
		[EventCode]
	)
GO

ALTER TABLE [dbo].[tblNotifications_NotificationAttributeValueLog] ADD 
	CONSTRAINT [FK_tblNotifications_NotificationAttributeValueLog_tblEvents_EventAttribute] FOREIGN KEY 
	(
		[BaseAttributeValueID]
	) REFERENCES [dbo].[tblEvents_EventAttribute] (
		[BaseAttributeID]
	),
	CONSTRAINT [PROP_FK_tblNotifications_NotificationLogAttributeValue_tblNotifications_NotificationLog] FOREIGN KEY 
	(
		[NotificationLogID]
	) REFERENCES [dbo].[tblNotifications_NotificationLog] (
		[NotificationLogID]
	)
GO

ALTER TABLE [dbo].[tblNotifications_NotificationLog] ADD 
	CONSTRAINT [FK_tblNotifications_NotificationLog_tblNotifications_Notification] FOREIGN KEY 
	(
		[NotificationCode]
	) REFERENCES [dbo].[tblNotifications_Notification] (
		[NotificationCode]
	),
	CONSTRAINT [FK_tblNotifications_NotificationLog_tlkpEnvironments_Locale] FOREIGN KEY 
	(
		[LocaleCode]
	) REFERENCES [dbo].[tlkpEnvironments_Locale] (
		[LocaleCode]
	)
GO

ALTER TABLE [dbo].[tblNotifications_NotificationTemplate] ADD 
	CONSTRAINT [FK_tblNotifications_NotificationTemplate_tblNotifications_Notification] FOREIGN KEY 
	(
		[NotificationCode]
	) REFERENCES [dbo].[tblNotifications_Notification] (
		[NotificationCode]
	),
	CONSTRAINT [FK_tblNotifications_NotificationTemplate_tlkpEnvironments_Locale] FOREIGN KEY 
	(
		[LocaleCode]
	) REFERENCES [dbo].[tlkpEnvironments_Locale] (
		[LocaleCode]
	)
GO

ALTER TABLE [dbo].[tblOrders_Order] ADD 
	CONSTRAINT [FK_tblOrders_Order_tblAccounts_Account] FOREIGN KEY 
	(
		[LogToAccountID],
		[CreditMetaPartnerID]
	) REFERENCES [dbo].[tblAccounts_Account] (
		[AccountID],
		[MetaPartnerID]
	),
	CONSTRAINT [FK_tblOrders_Order_tblCustomers_MetaPartner] FOREIGN KEY 
	(
		[DebitMetaPartnerID]
	) REFERENCES [dbo].[tblCustomers_MetaPartner] (
		[MetaPartnerID]
	),
	CONSTRAINT [FK_tblOrders_Order_tblCustomers_MetaPartner1] FOREIGN KEY 
	(
		[CreditMetaPartnerID]
	) REFERENCES [dbo].[tblCustomers_MetaPartner] (
		[MetaPartnerID]
	),
	CONSTRAINT [FK_tblOrders_Order_tlkpAccounts_Currency] FOREIGN KEY 
	(
		[CurrencyCode]
	) REFERENCES [dbo].[tlkpAccounts_Currency] (
		[CurrencyCode]
	),
	CONSTRAINT [FK_tblOrders_Order_tlkpOrders_OrderStatus] FOREIGN KEY 
	(
		[OrderStatusCode]
	) REFERENCES [dbo].[tlkpOrders_OrderStatus] (
		[OrderStatusCode]
	)
GO

ALTER TABLE [dbo].[tblPayments_Payment] ADD 
	CONSTRAINT [FK_tblPayments_Payment_tblAccounts_Account] FOREIGN KEY 
	(
		[SourceAccountID],
		[DebitMetaPartnerID]
	) REFERENCES [dbo].[tblAccounts_Account] (
		[AccountID],
		[MetaPartnerID]
	),
	CONSTRAINT [FK_tblPayments_Payment_tblAccounts_Account1] FOREIGN KEY 
	(
		[DestinationAccountID],
		[CreditMetaPartnerID]
	) REFERENCES [dbo].[tblAccounts_Account] (
		[AccountID],
		[MetaPartnerID]
	),
	CONSTRAINT [FK_tblPayments_Payments_tblCustomers_Orders] FOREIGN KEY 
	(
		[OrderID]
	) REFERENCES [dbo].[tblOrders_Order] (
		[OrderID]
	),
	CONSTRAINT [FK_tblPayments_Payments_tlkpPayments_PaymentStatus] FOREIGN KEY 
	(
		[PaymentStatusCode]
	) REFERENCES [dbo].[tlkpPayments_PaymentStatus] (
		[PaymentStatusCode]
	)
GO

ALTER TABLE [dbo].[tblPayments_PaymentTransactionAttributeValueLog] ADD 
	CONSTRAINT [FK_tblPayments_PaymentTransactionAttributeValueLog_tblEvents_EventAttribute] FOREIGN KEY 
	(
		[BaseAttributeID]
	) REFERENCES [dbo].[tblEvents_EventAttribute] (
		[BaseAttributeID]
	),
	CONSTRAINT [FK_tblPayments_PaymentTransactionAttributeValueLog_tblPayments_PaymentTransactionLog] FOREIGN KEY 
	(
		[PaymentTransactionLogID]
	) REFERENCES [dbo].[tblPayments_PaymentTransactionLog] (
		[PaymentTransactionLogID]
	)
GO

ALTER TABLE [dbo].[tblPayments_PaymentTransactionLog] ADD 
	CONSTRAINT [FK_tblPayments_PaymentTransactionLog_tlkpPayments_TransactionStatus] FOREIGN KEY 
	(
		[TransactionStatusCode]
	) REFERENCES [dbo].[tlkpPayments_TransactionStatus] (
		[TransactionStatusCode]
	),
	CONSTRAINT [FK_tblPayments_PaymentTransactions_tblPayments_Payments1] FOREIGN KEY 
	(
		[PaymentID]
	) REFERENCES [dbo].[tblPayments_Payment] (
		[PaymentID]
	),
	CONSTRAINT [FK_tblPayments_PaymentTransactions_tlkpPayments_TransactionTypes] FOREIGN KEY 
	(
		[TransactionTypeCode]
	) REFERENCES [dbo].[tlkpPayments_TransactionType] (
		[TransactionTypeCode]
	)
GO

ALTER TABLE [dbo].[tblUserExperience_AdminHelp] ADD 
	CONSTRAINT [FK_tblUserExperience_AdminHelp_tlkpEnvironments_Locale] FOREIGN KEY 
	(
		[LocaleCode]
	) REFERENCES [dbo].[tlkpEnvironments_Locale] (
		[LocaleCode]
	),
	CONSTRAINT [FK_tblUserExperience_AdminHelp_tlkpUsers_Activity] FOREIGN KEY 
	(
		[ActivityCode]
	) REFERENCES [dbo].[tlkpUsers_Activity] (
		[ActivityCode]
	)
GO

ALTER TABLE [dbo].[tblUserExperience_SiteHelp] ADD 
	CONSTRAINT [FK_tblStores_SiteHelp_tlkpStores_SiteHelpGroups] FOREIGN KEY 
	(
		[SiteHelpGroupCode]
	) REFERENCES [dbo].[tlkpUserExperience_SiteHelpGroup] (
		[SiteHelpGroupCode]
	),
	CONSTRAINT [FK_tblUserExperience_SiteHelp_tlkpEnvironments_Locale] FOREIGN KEY 
	(
		[LocaleCode]
	) REFERENCES [dbo].[tlkpEnvironments_Locale] (
		[LocaleCode]
	)
GO

ALTER TABLE [dbo].[tblUserExperience_SiteLabel] ADD 
	CONSTRAINT [FK_tblUserExperience_SiteLabel_tlkpEnvironments_Locale] FOREIGN KEY 
	(
		[LocaleCode]
	) REFERENCES [dbo].[tlkpEnvironments_Locale] (
		[LocaleCode]
	)
GO

ALTER TABLE [dbo].[tblUsers_User] ADD 
	CONSTRAINT [FK_tblUsers_User_tlkpEnvironments_Locale] FOREIGN KEY 
	(
		[LocaleCode]
	) REFERENCES [dbo].[tlkpEnvironments_Locale] (
		[LocaleCode]
	)
GO

ALTER TABLE [dbo].[trelAccounts_LoanToMetaPartner] ADD 
	CONSTRAINT [FK_trelAccounts_LoanToMetaPartner_tblAccounts_LoanAccount] FOREIGN KEY 
	(
		[AccountID]
	) REFERENCES [dbo].[tblAccounts_LoanAccount] (
		[AccountID]
	),
	CONSTRAINT [FK_trelAccounts_LoanToMetaPartner_tblCustomers_MetaPartner] FOREIGN KEY 
	(
		[MetaPartnerID]
	) REFERENCES [dbo].[tblCustomers_MetaPartner] (
		[MetaPartnerID]
	)
GO

ALTER TABLE [dbo].[trelAccounts_ParticipatingPartner] ADD 
	CONSTRAINT [FK_trelAccounts_ParticipatingPartner_tblAccounts_FundAccount] FOREIGN KEY 
	(
		[AccountID]
	) REFERENCES [dbo].[tblAccounts_FundAccount] (
		[AccountID]
	),
	CONSTRAINT [FK_trelAccounts_ParticipatingPartner_tblCustomers_MetaPartner] FOREIGN KEY 
	(
		[MetaPartnerID]
	) REFERENCES [dbo].[tblCustomers_MetaPartner] (
		[MetaPartnerID]
	)
GO

ALTER TABLE [dbo].[trelCustomers_BusinessCustomer] ADD 
	CONSTRAINT [FK_trelCustomers_BusinessCustomer_tblCustomers_Business] FOREIGN KEY 
	(
		[BusinessMetaPartnerID]
	) REFERENCES [dbo].[tblCustomers_Business] (
		[MetaPartnerID]
	),
	CONSTRAINT [FK_trelCustomers_BusinessCustomer_tblCustomers_Customer] FOREIGN KEY 
	(
		[CustomerMetaPartnerID]
	) REFERENCES [dbo].[tblCustomers_Customer] (
		[MetaPartnerID]
	)
GO

ALTER TABLE [dbo].[trelCustomers_MetaPartnerContact] ADD 
	CONSTRAINT [FK_trelCustomers_MetaPartnerContact_tblCustomers_MetaPartner] FOREIGN KEY 
	(
		[MetaPartnerID]
	) REFERENCES [dbo].[tblCustomers_MetaPartner] (
		[MetaPartnerID]
	),
	CONSTRAINT [FK_trelCustomers_MetaPartnerContact_tblCustomers_MetaPartner1] FOREIGN KEY 
	(
		[ContactMetaPartnerID]
	) REFERENCES [dbo].[tblCustomers_MetaPartner] (
		[MetaPartnerID]
	)
GO

ALTER TABLE [dbo].[trelEvents_SpecificEventAttribute] ADD 
	CONSTRAINT [FK_trelEvents_SpecificEventAttribute_tblEvents_Event] FOREIGN KEY 
	(
		[EventCode]
	) REFERENCES [dbo].[tblEvents_Event] (
		[EventCode]
	),
	CONSTRAINT [FK_trelEvents_SpecificEventAttribute_tblEvents_EventAttribute1] FOREIGN KEY 
	(
		[BaseAttributeID]
	) REFERENCES [dbo].[tblEvents_EventAttribute] (
		[BaseAttributeID]
	)
GO

ALTER TABLE [dbo].[trelNotifications_NotificationDeliveryLog] ADD 
	CONSTRAINT [FK_trelNotifications_NotificationDeliveryLog_tblCustomers_MetaPartner] FOREIGN KEY 
	(
		[MetaPartnerID]
	) REFERENCES [dbo].[tblCustomers_MetaPartner] (
		[MetaPartnerID]
	),
	CONSTRAINT [FK_trelNotifications_NotificationDeliveryLog_tlkpNotifications_NotificationDeliveryType] FOREIGN KEY 
	(
		[NotificationDeliveryTypeCode]
	) REFERENCES [dbo].[tlkpNotifications_NotificationDeliveryType] (
		[NotificationDeliveryTypeCode]
	),
	CONSTRAINT [PROP_FK_trelNotifications_NotificationDeliveryLog_tblNotifications_NotificationLog] FOREIGN KEY 
	(
		[NotificationLogID]
	) REFERENCES [dbo].[tblNotifications_NotificationLog] (
		[NotificationLogID]
	)
GO

ALTER TABLE [dbo].[trelUsers_UserRoleActivity] ADD 
	CONSTRAINT [FK_trelUsers_UserRoleActivity_tlkpUsers_AccessMode] FOREIGN KEY 
	(
		[AccessModeCode]
	) REFERENCES [dbo].[tlkpUsers_AccessMode] (
		[AccessModeCode]
	),
	CONSTRAINT [FK_trelUsers_UserRoles_Activities_tlkpUsers_Activities] FOREIGN KEY 
	(
		[ActivityCode]
	) REFERENCES [dbo].[tlkpUsers_Activity] (
		[ActivityCode]
	),
	CONSTRAINT [FK_trelUsers_UserRoles_Activities_tlkpUsers_UserRoles] FOREIGN KEY 
	(
		[UserRoleCode]
	) REFERENCES [dbo].[tlkpUsers_UserRole] (
		[UserRoleCode]
	)
GO

ALTER TABLE [dbo].[trelUsers_UserRoleUser] ADD 
	CONSTRAINT [FK_trelUsers_UserRoleUsers_tblUsers_User] FOREIGN KEY 
	(
		[UserID]
	) REFERENCES [dbo].[tblUsers_User] (
		[UserID]
	),
	CONSTRAINT [FK_trelUsers_UserRoleUsers_tlkpbUsers_UserRole] FOREIGN KEY 
	(
		[UserRoleCode]
	) REFERENCES [dbo].[tlkpUsers_UserRole] (
		[UserRoleCode]
	)
GO

