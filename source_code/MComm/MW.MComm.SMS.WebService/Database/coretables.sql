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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblEvents_AuditAttributeValueLog_tblEvents_AuditLog]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblEvents_AuditAttributeValueLog] DROP CONSTRAINT FK_tblEvents_AuditAttributeValueLog_tblEvents_AuditLog
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblEvents_AuditLog_tblEvents_Event]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblEvents_AuditLog] DROP CONSTRAINT FK_tblEvents_AuditLog_tblEvents_Event
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblEvents_AuditAttributeValueLog_tblEvents_EventAttribute]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblEvents_AuditAttributeValueLog] DROP CONSTRAINT FK_tblEvents_AuditAttributeValueLog_tblEvents_EventAttribute
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_trelUsers_UserRoleUsers_tblUsers_User]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[trelUsers_UserRoleUser] DROP CONSTRAINT FK_trelUsers_UserRoleUsers_tblUsers_User
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblEvents_Events_tlkpEvents_EventType]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblEvents_Event] DROP CONSTRAINT FK_tblEvents_Events_tlkpEvents_EventType
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_trelUsers_UserRoleActivity_tlkpUsers_AccessMode]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[trelUsers_UserRoleActivity] DROP CONSTRAINT FK_trelUsers_UserRoleActivity_tlkpUsers_AccessMode
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblEvents_AuditAttributeValueLog]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblEvents_AuditAttributeValueLog]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblEvents_AuditLog]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblEvents_AuditLog]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblEvents_Event]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblEvents_Event]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblEvents_EventAttribute]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblEvents_EventAttribute]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblMessages_IncomingSMS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblMessages_IncomingSMS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblMessages_OutgoingSMS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblMessages_OutgoingSMS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblUsers_User]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblUsers_User]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tlkpEvents_EventType]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tlkpEvents_EventType]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[trelUsers_UserRoleActivity]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[trelUsers_UserRoleActivity]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[trelUsers_UserRoleUser]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[trelUsers_UserRoleUser]
GO

CREATE TABLE [dbo].[dba_SchemaVerCntrl] (
	[TableName] [sysname] NOT NULL ,
	[CreateDate] [datetime] NOT NULL ,
	[SchemaVersion] [int] NOT NULL 
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

CREATE TABLE [dbo].[tblEvents_AuditAttributeValueLog] (
	[AuditAttributeValueLogID] [uniqueidentifier] NOT NULL ,
	[AuditLogID] [uniqueidentifier] NOT NULL ,
	[BaseAttributeID] [uniqueidentifier] NOT NULL ,
	[AttributeValue] [nvarchar] (1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tblEvents_AuditLog] (
	[AuditLogID] [uniqueidentifier] NOT NULL ,
	[EventCode] [int] NOT NULL ,
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

CREATE TABLE [dbo].[tblMessages_IncomingSMS] (
	[InternalID] [bigint] IDENTITY (1, 1) NOT NULL ,
	[Sender] [nvarchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Receiver] [nvarchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[ConnectionID] [nvarchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[SMSContent] [nvarchar] (170) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[IsProcessed] [bit] NOT NULL ,
	[CreatedByUserID] [uniqueidentifier] NULL ,
	[CreatedDate] [datetime] NULL ,
	[LastModifiedByUserID] [uniqueidentifier] NULL ,
	[LastModifiedDate] [datetime] NULL ,
	[Timestamp] [timestamp] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tblMessages_OutgoingSMS] (
	[InternalID] [bigint] IDENTITY (1, 1) NOT NULL ,
	[Sender] [nvarchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Receiver] [nvarchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[NowSMSServer] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[SMSContent] [nvarchar] (170) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[ServerResponse] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
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

ALTER TABLE [dbo].[tblEvents_AuditAttributeValueLog] WITH NOCHECK ADD 
	CONSTRAINT [PK_tblEvents_AuditAttributeValueLog] PRIMARY KEY  CLUSTERED 
	(
		[AuditAttributeValueLogID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblEvents_AuditLog] WITH NOCHECK ADD 
	CONSTRAINT [PK_tblEvents_AuditLog] PRIMARY KEY  CLUSTERED 
	(
		[AuditLogID]
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

ALTER TABLE [dbo].[tblMessages_IncomingSMS] WITH NOCHECK ADD 
	CONSTRAINT [PK_tblMessages_IncomingSMS] PRIMARY KEY  CLUSTERED 
	(
		[InternalID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblMessages_OutgoingSMS] WITH NOCHECK ADD 
	CONSTRAINT [PK_tblMessages_OutgoingSMS] PRIMARY KEY  CLUSTERED 
	(
		[InternalID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblUsers_User] WITH NOCHECK ADD 
	CONSTRAINT [PK_tblUsers_User] PRIMARY KEY  CLUSTERED 
	(
		[UserID]
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

ALTER TABLE [dbo].[tlkpEvents_EventType] WITH NOCHECK ADD 
	CONSTRAINT [PK_tlkpEvents_EventType] PRIMARY KEY  CLUSTERED 
	(
		[EventTypeCode]
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

ALTER TABLE [dbo].[tblEvents_AuditAttributeValueLog] ADD 
	CONSTRAINT [DF_tblEvents_AuditAttributeValueLog_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tblEvents_AuditAttributeValueLog_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[tblEvents_AuditLog] ADD 
	CONSTRAINT [DF_tblEvents_AuditLog_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tblEvents_AuditLog_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
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

ALTER TABLE [dbo].[tblMessages_IncomingSMS] ADD 
	CONSTRAINT [DF_tblMessages_IncomingSMS_IsProcessed] DEFAULT (0) FOR [IsProcessed],
	CONSTRAINT [DF_tblMessages_IncomingSMS_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tblMessages_IncomingSMS_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[tblMessages_OutgoingSMS] ADD 
	CONSTRAINT [DF_tblMessages_OutgoingSMS_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tblMessages_OutgoingSMS_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
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
	)  ON [PRIMARY] ,
	CONSTRAINT [IX_tblUsers_User_1] UNIQUE  NONCLUSTERED 
	(
		[UserName]
	)  ON [PRIMARY] 
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

ALTER TABLE [dbo].[tlkpEvents_EventType] ADD 
	CONSTRAINT [DF_tlkpEvents_EventType_IsActive] DEFAULT (1) FOR [IsActive],
	CONSTRAINT [DF_tlkpEvents_EventType_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_tlkpEvents_EventType_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
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

ALTER TABLE [dbo].[trelUsers_UserRoleActivity] ADD 
	CONSTRAINT [DF_trelUsers_UserRoles_Activities_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_trelUsers_UserRoles_Activities_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[trelUsers_UserRoleUser] ADD 
	CONSTRAINT [DF_trelUsers_UserRoles_Users_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate],
	CONSTRAINT [DF_trelUsers_UserRoles_Users_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
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

ALTER TABLE [dbo].[tblEvents_AuditAttributeValueLog] ADD 
	CONSTRAINT [FK_tblEvents_AuditAttributeValueLog_tblEvents_AuditLog] FOREIGN KEY 
	(
		[AuditLogID]
	) REFERENCES [dbo].[tblEvents_AuditLog] (
		[AuditLogID]
	),
	CONSTRAINT [FK_tblEvents_AuditAttributeValueLog_tblEvents_EventAttribute] FOREIGN KEY 
	(
		[BaseAttributeID]
	) REFERENCES [dbo].[tblEvents_EventAttribute] (
		[BaseAttributeID]
	)
GO

ALTER TABLE [dbo].[tblEvents_AuditLog] ADD 
	CONSTRAINT [FK_tblEvents_AuditLog_tblEvents_Event] FOREIGN KEY 
	(
		[EventCode]
	) REFERENCES [dbo].[tblEvents_Event] (
		[EventCode]
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

