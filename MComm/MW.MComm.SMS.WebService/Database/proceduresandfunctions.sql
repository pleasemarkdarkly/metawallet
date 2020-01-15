if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[NYSIIS]') and xtype in (N'FN', N'IF', N'TF'))
drop function [dbo].[NYSIIS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_AddOneAttributeType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_AddOneAttributeType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_AddOneDataType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_AddOneDataType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_AddOneDebugAttribute]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_AddOneDebugAttribute]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_AddOneError]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_AddOneError]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_AddOneEventType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_AddOneEventType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_AddOneSeverityLevel]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_AddOneSeverityLevel]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_DeleteAllBaseAttributeDataByAttributeTypeCode]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_DeleteAllBaseAttributeDataByAttributeTypeCode]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_DeleteAllBaseAttributeDataByDataTypeCode]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_DeleteAllBaseAttributeDataByDataTypeCode]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_DeleteAllDebugAttributeDataByAttributeTypeCode]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_DeleteAllDebugAttributeDataByAttributeTypeCode]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_DeleteAllDebugAttributeDataByBaseAttributeID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_DeleteAllDebugAttributeDataByBaseAttributeID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_DeleteAllDebugAttributeDataByDataTypeCode]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_DeleteAllDebugAttributeDataByDataTypeCode]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_DeleteOneAttributeType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_DeleteOneAttributeType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_DeleteOneBaseAttribute]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_DeleteOneBaseAttribute]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_DeleteOneDataType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_DeleteOneDataType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_DeleteOneDebugAttribute]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_DeleteOneDebugAttribute]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_DeleteOneError]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_DeleteOneError]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_DeleteOneEventType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_DeleteOneEventType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_DeleteOneSeverityLevel]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_DeleteOneSeverityLevel]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_GetAllAttributeTypeData]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_GetAllAttributeTypeData]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_GetAllBaseAttributeData]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_GetAllBaseAttributeData]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_GetAllBaseAttributeDataByAttributeTypeCode]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_GetAllBaseAttributeDataByAttributeTypeCode]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_GetAllBaseAttributeDataByCriteria]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_GetAllBaseAttributeDataByCriteria]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_GetAllBaseAttributeDataByDataTypeCode]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_GetAllBaseAttributeDataByDataTypeCode]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_GetAllDataTypeData]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_GetAllDataTypeData]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_GetAllDebugAttributeData]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_GetAllDebugAttributeData]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_GetAllDebugAttributeDataByAttributeTypeCode]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_GetAllDebugAttributeDataByAttributeTypeCode]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_GetAllDebugAttributeDataByBaseAttributeID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_GetAllDebugAttributeDataByBaseAttributeID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_GetAllDebugAttributeDataByCriteria]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_GetAllDebugAttributeDataByCriteria]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_GetAllDebugAttributeDataByDataTypeCode]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_GetAllDebugAttributeDataByDataTypeCode]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_GetAllDebugAttributeValueLogData]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_GetAllDebugAttributeValueLogData]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_GetAllDebugAttributeValueLogDataByBaseAttributeID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_GetAllDebugAttributeValueLogDataByBaseAttributeID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_GetAllDebugAttributeValueLogDataByCriteria]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_GetAllDebugAttributeValueLogDataByCriteria]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_GetAllDebugAttributeValueLogDataByDebugLogID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_GetAllDebugAttributeValueLogDataByDebugLogID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_GetAllDebugLogData]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_GetAllDebugLogData]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_GetAllDebugLogDataByCriteria]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_GetAllDebugLogDataByCriteria]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_GetAllDebugLogDataByEventTypeCode]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_GetAllDebugLogDataByEventTypeCode]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_GetAllDebugLogDataBySeverityLevelCode]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_GetAllDebugLogDataBySeverityLevelCode]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_GetAllErrorData]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_GetAllErrorData]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_GetAllEventTypeData]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_GetAllEventTypeData]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_GetAllSeverityLevelData]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_GetAllSeverityLevelData]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_GetManyBaseAttributeDataByCriteria]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_GetManyBaseAttributeDataByCriteria]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_GetManyDebugAttributeDataByCriteria]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_GetManyDebugAttributeDataByCriteria]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_GetManyDebugAttributeValueLogDataByCriteria]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_GetManyDebugAttributeValueLogDataByCriteria]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_GetManyDebugLogDataByCriteria]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_GetManyDebugLogDataByCriteria]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_GetOneAttributeType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_GetOneAttributeType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_GetOneBaseAttribute]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_GetOneBaseAttribute]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_GetOneDataType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_GetOneDataType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_GetOneDebugAttribute]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_GetOneDebugAttribute]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_GetOneDebugAttributeByAttributeCode]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_GetOneDebugAttributeByAttributeCode]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_GetOneDebugAttributeValueLog]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_GetOneDebugAttributeValueLog]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_GetOneDebugAttributeValueLogByDebugAttributeValueLogID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_GetOneDebugAttributeValueLogByDebugAttributeValueLogID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_GetOneDebugLog]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_GetOneDebugLog]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_GetOneError]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_GetOneError]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_GetOneEventType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_GetOneEventType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_GetOneSeverityLevel]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_GetOneSeverityLevel]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_LogOneDebugAttributeValueLog]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_LogOneDebugAttributeValueLog]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_LogOneDebugLog]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_LogOneDebugLog]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_UpdateOneAttributeType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_UpdateOneAttributeType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_UpdateOneDataType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_UpdateOneDataType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_UpdateOneDebugAttribute]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_UpdateOneDebugAttribute]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_UpdateOneError]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_UpdateOneError]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_UpdateOneEventType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_UpdateOneEventType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_UpdateOneSeverityLevel]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_UpdateOneSeverityLevel]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCore_UpsertOneBaseAttribute]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCore_UpsertOneBaseAttribute]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spEvents_AddOneEvent]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spEvents_AddOneEvent]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spEvents_AddOneEventAttribute]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spEvents_AddOneEventAttribute]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spEvents_AddOneEventType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spEvents_AddOneEventType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spEvents_DeleteAllEventAttributeDataByAttributeTypeCode]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spEvents_DeleteAllEventAttributeDataByAttributeTypeCode]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spEvents_DeleteAllEventAttributeDataByBaseAttributeID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spEvents_DeleteAllEventAttributeDataByBaseAttributeID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spEvents_DeleteAllEventAttributeDataByDataTypeCode]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spEvents_DeleteAllEventAttributeDataByDataTypeCode]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spEvents_DeleteAllEventDataByEventTypeCode]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spEvents_DeleteAllEventDataByEventTypeCode]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spEvents_DeleteOneEvent]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spEvents_DeleteOneEvent]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spEvents_DeleteOneEventAttribute]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spEvents_DeleteOneEventAttribute]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spEvents_DeleteOneEventType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spEvents_DeleteOneEventType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spEvents_GetAllAuditAttributeValueLogData]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spEvents_GetAllAuditAttributeValueLogData]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spEvents_GetAllAuditAttributeValueLogDataByAuditLogID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spEvents_GetAllAuditAttributeValueLogDataByAuditLogID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spEvents_GetAllAuditAttributeValueLogDataByBaseAttributeID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spEvents_GetAllAuditAttributeValueLogDataByBaseAttributeID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spEvents_GetAllAuditAttributeValueLogDataByCriteria]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spEvents_GetAllAuditAttributeValueLogDataByCriteria]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spEvents_GetAllAuditLogData]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spEvents_GetAllAuditLogData]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spEvents_GetAllAuditLogDataByCriteria]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spEvents_GetAllAuditLogDataByCriteria]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spEvents_GetAllAuditLogDataByEventCode]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spEvents_GetAllAuditLogDataByEventCode]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spEvents_GetAllEventAttributeData]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spEvents_GetAllEventAttributeData]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spEvents_GetAllEventAttributeDataByAttributeTypeCode]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spEvents_GetAllEventAttributeDataByAttributeTypeCode]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spEvents_GetAllEventAttributeDataByBaseAttributeID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spEvents_GetAllEventAttributeDataByBaseAttributeID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spEvents_GetAllEventAttributeDataByCriteria]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spEvents_GetAllEventAttributeDataByCriteria]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spEvents_GetAllEventAttributeDataByDataTypeCode]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spEvents_GetAllEventAttributeDataByDataTypeCode]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spEvents_GetAllEventData]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spEvents_GetAllEventData]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spEvents_GetAllEventDataByCriteria]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spEvents_GetAllEventDataByCriteria]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spEvents_GetAllEventDataByEventTypeCode]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spEvents_GetAllEventDataByEventTypeCode]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spEvents_GetAllEventTypeData]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spEvents_GetAllEventTypeData]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spEvents_GetManyAuditAttributeValueLogDataByCriteria]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spEvents_GetManyAuditAttributeValueLogDataByCriteria]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spEvents_GetManyAuditLogDataByCriteria]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spEvents_GetManyAuditLogDataByCriteria]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spEvents_GetManyEventAttributeDataByCriteria]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spEvents_GetManyEventAttributeDataByCriteria]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spEvents_GetManyEventDataByCriteria]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spEvents_GetManyEventDataByCriteria]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spEvents_GetOneAuditAttributeValueLog]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spEvents_GetOneAuditAttributeValueLog]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spEvents_GetOneAuditLog]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spEvents_GetOneAuditLog]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spEvents_GetOneEvent]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spEvents_GetOneEvent]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spEvents_GetOneEventAttribute]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spEvents_GetOneEventAttribute]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spEvents_GetOneEventAttributeByAttributeCode]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spEvents_GetOneEventAttributeByAttributeCode]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spEvents_GetOneEventType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spEvents_GetOneEventType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spEvents_LogOneAuditAttributeValueLog]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spEvents_LogOneAuditAttributeValueLog]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spEvents_LogOneAuditLog]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spEvents_LogOneAuditLog]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spEvents_UpdateOneEvent]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spEvents_UpdateOneEvent]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spEvents_UpdateOneEventAttribute]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spEvents_UpdateOneEventAttribute]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spEvents_UpdateOneEventType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spEvents_UpdateOneEventType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spMessages_DeleteOneIncomingSMS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spMessages_DeleteOneIncomingSMS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spMessages_DeleteOneOutgoingSMS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spMessages_DeleteOneOutgoingSMS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spMessages_GetAllIncomingSMSData]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spMessages_GetAllIncomingSMSData]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spMessages_GetAllIncomingSMSDataByCriteria]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spMessages_GetAllIncomingSMSDataByCriteria]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spMessages_GetAllOutgoingSMSData]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spMessages_GetAllOutgoingSMSData]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spMessages_GetAllOutgoingSMSDataByCriteria]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spMessages_GetAllOutgoingSMSDataByCriteria]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spMessages_GetManyIncomingSMSDataByCriteria]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spMessages_GetManyIncomingSMSDataByCriteria]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spMessages_GetManyOutgoingSMSDataByCriteria]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spMessages_GetManyOutgoingSMSDataByCriteria]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spMessages_GetOneIncomingSMS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spMessages_GetOneIncomingSMS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spMessages_GetOneOutgoingSMS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spMessages_GetOneOutgoingSMS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spMessages_UpsertOneIncomingSMS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spMessages_UpsertOneIncomingSMS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spMessages_UpsertOneOutgoingSMS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spMessages_UpsertOneOutgoingSMS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUsers_AddOneAccessMode]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spUsers_AddOneAccessMode]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUsers_AddOneActivity]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spUsers_AddOneActivity]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUsers_AddOneUserRole]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spUsers_AddOneUserRole]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUsers_AddOneUserRoleActivity]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spUsers_AddOneUserRoleActivity]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUsers_AddOneUserRoleUser]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spUsers_AddOneUserRoleUser]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUsers_DeleteAllUserRoleActivityDataByAccessModeCode]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spUsers_DeleteAllUserRoleActivityDataByAccessModeCode]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUsers_DeleteAllUserRoleActivityDataByActivityCode]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spUsers_DeleteAllUserRoleActivityDataByActivityCode]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUsers_DeleteAllUserRoleActivityDataByUserRoleCode]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spUsers_DeleteAllUserRoleActivityDataByUserRoleCode]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUsers_DeleteAllUserRoleUserDataByUserID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spUsers_DeleteAllUserRoleUserDataByUserID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUsers_DeleteAllUserRoleUserDataByUserRoleCode]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spUsers_DeleteAllUserRoleUserDataByUserRoleCode]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUsers_DeleteOneAccessMode]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spUsers_DeleteOneAccessMode]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUsers_DeleteOneActivity]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spUsers_DeleteOneActivity]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUsers_DeleteOneUser]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spUsers_DeleteOneUser]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUsers_DeleteOneUserRole]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spUsers_DeleteOneUserRole]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUsers_DeleteOneUserRoleActivity]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spUsers_DeleteOneUserRoleActivity]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUsers_DeleteOneUserRoleUser]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spUsers_DeleteOneUserRoleUser]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUsers_GetAllAccessModeData]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spUsers_GetAllAccessModeData]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUsers_GetAllActivityData]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spUsers_GetAllActivityData]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUsers_GetAllUserData]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spUsers_GetAllUserData]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUsers_GetAllUserDataByCriteria]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spUsers_GetAllUserDataByCriteria]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUsers_GetAllUserRoleActivityData]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spUsers_GetAllUserRoleActivityData]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUsers_GetAllUserRoleActivityDataByAccessModeCode]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spUsers_GetAllUserRoleActivityDataByAccessModeCode]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUsers_GetAllUserRoleActivityDataByActivityCode]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spUsers_GetAllUserRoleActivityDataByActivityCode]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUsers_GetAllUserRoleActivityDataByUserRoleCode]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spUsers_GetAllUserRoleActivityDataByUserRoleCode]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUsers_GetAllUserRoleData]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spUsers_GetAllUserRoleData]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUsers_GetAllUserRoleUserData]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spUsers_GetAllUserRoleUserData]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUsers_GetAllUserRoleUserDataByUserID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spUsers_GetAllUserRoleUserDataByUserID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUsers_GetAllUserRoleUserDataByUserRoleCode]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spUsers_GetAllUserRoleUserDataByUserRoleCode]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUsers_GetManyUserDataByCriteria]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spUsers_GetManyUserDataByCriteria]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUsers_GetOneAccessMode]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spUsers_GetOneAccessMode]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUsers_GetOneActivity]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spUsers_GetOneActivity]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUsers_GetOneActivityByActivityName]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spUsers_GetOneActivityByActivityName]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUsers_GetOneUser]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spUsers_GetOneUser]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUsers_GetOneUserByFirstNameAndLastNameAndPassword]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spUsers_GetOneUserByFirstNameAndLastNameAndPassword]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUsers_GetOneUserByUserName]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spUsers_GetOneUserByUserName]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUsers_GetOneUserRole]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spUsers_GetOneUserRole]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUsers_GetOneUserRoleActivity]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spUsers_GetOneUserRoleActivity]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUsers_GetOneUserRoleUser]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spUsers_GetOneUserRoleUser]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUsers_UpdateOneAccessMode]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spUsers_UpdateOneAccessMode]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUsers_UpdateOneActivity]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spUsers_UpdateOneActivity]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUsers_UpdateOneUserRole]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spUsers_UpdateOneUserRole]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUsers_UpdateOneUserRoleActivity]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spUsers_UpdateOneUserRoleActivity]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUsers_UpdateOneUserRoleUser]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spUsers_UpdateOneUserRoleUser]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUsers_UpsertOneUser]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spUsers_UpsertOneUser]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO





CREATE FUNCTION dbo.NYSIIS
( @instring VARCHAR(50) )
RETURNS VARCHAR(50)
AS

/*
    New York State Identification and Intelligence System (NYSIIS) Phonetic Encoder
    http://www.dropby.com/indexLF.html?content=/NYSIIS.html
*/

BEGIN

    DECLARE @cKey VARCHAR(50),
            @cChar VARCHAR(3),
            @cChars VARCHAR(3),
            @cVowels VARCHAR(10),
            @cFirst_char CHAR(1),
            @cResult VARCHAR(10)

    DECLARE @i integer

    /* vowels */
    SELECT @cVowels = 'AEIOU'

    /* trim all spaces */
    SELECT @instring = REPLACE( @instring, ' ', '' )
    SELECT @instring = UPPER( @instring )

    /* save first char */
    SELECT @cFirst_char = LEFT( @instring, 1 )

    /* ( 1) remove all 'S' and 'Z' chars from the end of the surname */
    SELECT @i = LEN( @instring )
    WHILE SUBSTRING( @instring, @i, 1 ) IN ( 'S', 'Z' )
        SELECT @i = @i - 1
    SELECT @instring = LEFT( @instring, @i )

     /* ( 2) transcode initial strings */
    /*      MAC => MC                 */
    /*      PF => F                     */
    SELECT @instring = CASE
                            WHEN LEFT( @instring, 3 ) = 'MAC' THEN 'MC' + SUBSTRING( @instring, 3, LEN( @instring ) )
                            WHEN LEFT( @instring, 2 ) = 'PF' THEN 'F' + SUBSTRING( @instring, 3, LEN( @instring ) )
                            ELSE @instring    -- do nothing
                       END

    /* ( 3) Transcode trailing strings as follows */
    /*      IX       => IC                        */
    /*      EX       => EC                        */
    /*      YE,EE,IE => Y                         */
    /*      NT,ND    => D                         */
    SELECT @instring = CASE
                            WHEN RIGHT( @instring, 2 ) = 'IX' THEN LEFT( @instring, LEN( @instring ) - 2 ) + 'IC'
                            WHEN RIGHT( @instring, 2 ) = 'EX' THEN LEFT( @instring, LEN( @instring ) - 2 ) + 'EC'
                            WHEN RIGHT( @instring, 2 ) IN ( 'YE', 'EE', 'IE' ) THEN LEFT( @instring, LEN( @instring ) - 2 ) + 'Y'
                            WHEN RIGHT( @instring, 2 ) IN ( 'NT', 'ND' ) THEN LEFT( @instring, LEN( @instring ) - 2 ) + 'D'
                            ELSE @instring    -- do nothing
                       END

    /* the step ( 4) I moved to begining of WHILE ... END below */

    /* ( 5) use first character of name as first character of key */
    /* SELECT @cKey = LEFT( @instring, 1 ) */
    /* don't now, what they thing with this, but with @cKey = '' it seems to be working */
    SELECT @cKey = ''


    SELECT @i = 1
    /* while not end of @instring */
    WHILE SUBSTRING( @instring, @i, 1 ) > ''
    BEGIN
        SELECT @cChars = SUBSTRING( @instring, @i, 3 )

        SELECT @cResult = CASE /* ( 4) transcode 'EV' to 'EF' if not at start of name */
                               WHEN @i > 1 AND LEFT( @cChars, 2 ) = 'EV' THEN 'AF'
                               /* ( 6) remove any 'W' that follows a vowel */
                               WHEN LEFT( @cChars, 1 ) = 'W' AND CHARINDEX( SUBSTRING( @instring, @i - 1, 1 ), @cVowels ) > 0 THEN SUBSTRING( @instring, @i - 1, 1 )
                               /* ( 7) replace all vowels with 'A' */
                               WHEN CHARINDEX( LEFT( @cChars, 1 ), @cVowels ) > 0 THEN 'A'
                                /* ( 8) transcode 'GHT' to 'GT' */
                               WHEN LEFT( @cChars, 2 ) = 'GHT' THEN 'GGG'
                                /* ( 9) transcode 'DG' to 'G' */
                               WHEN LEFT( @cChars, 2 ) = 'DG' THEN 'G'
                               /* (10) transcode 'PH' to 'F' */
                               WHEN LEFT( @cChars, 2 ) = 'PH' THEN 'F'
                                /* (11) if not first character, eliminate all 'H' preceded or followed by a vowel */
                               WHEN LEFT( @cChars, 1 ) = 'H' AND @i > 1 AND ( CHARINDEX( SUBSTRING( @instring, @i - 1, 1 ), @cVowels ) > 0 OR CHARINDEX( SUBSTRING( @instring, @i + 1, 1 ), @cVowels ) > 0 ) THEN SUBSTRING( @instring, @i - 1, 1 )
                               /* (12) change 'KN' to 'N', else 'K' to 'C' */
                               WHEN LEFT( @cChars, 2 ) = 'KN' THEN 'N'
                               WHEN LEFT( @cChars, 1 ) = 'K' THEN 'C'
                               /* (13) if not first character, change 'M' to 'N' */
                               WHEN @i > 1 AND LEFT( @cChars, 1 ) = 'M' THEN 'N'
                               /* (14) if not first character, change 'Q' to 'G' */
                               WHEN @i > 1 AND LEFT( @cChars, 1 ) = 'Q' THEN 'G'
                               /* (15) transcode 'SH' to 'S' */
                               WHEN LEFT( @cChars, 2 ) = 'SH' THEN 'S'
                               /* (16) transcode 'SCH' to 'S' */
                               WHEN @cChars = 'SCH' THEN 'SSS'
                               /* (17) transcode 'YW' to 'Y' */
                               WHEN LEFT( @cChars, 2 ) = 'YW' THEN 'Y'
                               /* (18) if not first or last character, change 'Y' to 'A' */
                               WHEN @i > 1 AND @i < LEN( @instring ) AND LEFT( @cChars, 1 ) = 'Y' THEN 'A'     
                               /* (19) transcode 'WR' to 'R' */
                               WHEN LEFT( @cChars, 2 ) = 'WR' THEN 'R'
                               /* (20) if not first character, change 'Z' to 'S' */
                               WHEN @i > 1 AND LEFT( @cChars, 1 ) = 'Z' THEN 'S'
                               ELSE LEFT( @cChars, 1 )
                         END

        SELECT @instring = STUFF( @instring, @i, LEN( @cResult ), @cResult )

        /* Add current to key if current <> last key character */
        IF RIGHT( @cKey, 1 ) != LEFT( @cResult, 1 )
            SELECT @cKey = @cKey + @cResult


        SELECT @i = @i + 1

    END


    /* (21) transcode terminal 'AY' to 'Y' */
    IF RIGHT( @cKey, 2 ) = 'AY'
        SELECT @cKey = LEFT( @cKey, LEN( @cKey ) - 2 ) + 'Y'
  
    /* (22) remove traling vowels */
    /*      start vowels */
    SELECT @i = 1
    WHILE CHARINDEX( SUBSTRING( @cKey, @i, 1 ), @cVowels ) > 0
        /* replace vowels with spaces */
        SELECT @cKey = STUFF( @cKey, @i, 1, ' ' ),
               @i = @i + 1

    /*     end vowels */
    SELECT @i = LEN( @cKey )
    WHILE CHARINDEX( SUBSTRING( @cKey, @i, 1 ), @cVowels ) > 0
        /* replace vowels with spaces */
        SELECT @cKey = STUFF( @cKey, @i, 1, ' ' ),
               @i = @i - 1
    /*     remove spaces */
    SELECT @cKey = REPLACE( @cKey, ' ', '' )

    /* (23) collapse all strings of repeated characters */
    /* not neede, see 'Add current to key if current <> last key character' before step (21) */

/* (24) if first char of original surname was a vowel, append it to the start of code */
    IF CHARINDEX( @cFirst_char, @cVowels ) > 0
        SELECT @cKey = @cFirst_char + @cKey

    RETURN @cKey

END





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_AddOneAttributeType
	  @SqlErrorNumber int = 0 OUTPUT
	, @CreatedByUserID uniqueidentifier = NULL
	, @Timestamp timestamp = NULL OUTPUT
	, @AttributeTypeCode int
	, @AttributeTypeName nvarchar(100)
	, @Description nvarchar(1000) = NULL
	, @IsActive bit = 0
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure inserts AttributeType data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@AttributeTypeCode IS NULL OR @AttributeTypeName IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END
/*
** record validation
*/
IF EXISTS (SELECT [AttributeTypeCode] FROM [dbo].[tlkpCore_AttributeType] WHERE [AttributeTypeCode] =  @AttributeTypeCode)
BEGIN
	SET @SqlErrorNumber = -1003
	GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	INSERT
	      [dbo].[tlkpCore_AttributeType]
	      (
 	     [CreatedByUserID]
 	   , [LastModifiedByUserID]
	   , [AttributeTypeCode]
	   , [AttributeTypeName]
	   , [Description]
	   , [IsActive]
	      )

	VALUES 
	      (
 	     @CreatedByUserID
 	   , @CreatedByUserID
	   , @AttributeTypeCode
	   , @AttributeTypeName
	   , @Description
	   , @IsActive
	      )

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END


	SET  @Timestamp = @@DBTS
END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_AddOneDataType
	  @SqlErrorNumber int = 0 OUTPUT
	, @CreatedByUserID uniqueidentifier = NULL
	, @Timestamp timestamp = NULL OUTPUT
	, @DataTypeCode int
	, @DataTypeName nvarchar(100)
	, @Description nvarchar(1000) = NULL
	, @IsActive bit = 0
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure inserts DataType data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@DataTypeCode IS NULL OR @DataTypeName IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END
/*
** record validation
*/
IF EXISTS (SELECT [DataTypeCode] FROM [dbo].[tlkpCore_DataType] WHERE [DataTypeCode] =  @DataTypeCode)
BEGIN
	SET @SqlErrorNumber = -1003
	GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	INSERT
	      [dbo].[tlkpCore_DataType]
	      (
 	     [CreatedByUserID]
 	   , [LastModifiedByUserID]
	   , [DataTypeCode]
	   , [DataTypeName]
	   , [Description]
	   , [IsActive]
	      )

	VALUES 
	      (
 	     @CreatedByUserID
 	   , @CreatedByUserID
	   , @DataTypeCode
	   , @DataTypeName
	   , @Description
	   , @IsActive
	      )

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END


	SET  @Timestamp = @@DBTS
END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_AddOneDebugAttribute
	  @SqlErrorNumber int = 0 OUTPUT
	, @CreatedByUserID uniqueidentifier = NULL
	, @Timestamp timestamp = NULL OUTPUT
	, @BaseAttributeID uniqueidentifier
	, @AttributeCode int
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure inserts DebugAttribute data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@BaseAttributeID IS NULL OR @AttributeCode IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END
/*
** record validation
*/
IF EXISTS (SELECT [BaseAttributeID] FROM [dbo].[tblCore_DebugAttribute] WHERE [BaseAttributeID] =  @BaseAttributeID)
BEGIN
	SET @SqlErrorNumber = -1003
	GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	INSERT
	      [dbo].[tblCore_DebugAttribute]
	      (
 	     [CreatedByUserID]
 	   , [LastModifiedByUserID]
	   , [BaseAttributeID]
	   , [AttributeCode]
	      )

	VALUES 
	      (
 	     @CreatedByUserID
 	   , @CreatedByUserID
	   , @BaseAttributeID
	   , @AttributeCode
	      )

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END


	SET  @Timestamp = @@DBTS
END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_AddOneError
	  @SqlErrorNumber int = 0 OUTPUT
	, @CreatedByUserID uniqueidentifier = NULL
	, @Timestamp timestamp = NULL OUTPUT
	, @ErrorNumber int
	, @ErrorTitle nvarchar(100)
	, @ErrorMessage nvarchar(1000) = NULL
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure inserts Error data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@ErrorNumber IS NULL OR @ErrorTitle IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END
/*
** record validation
*/
IF EXISTS (SELECT [ErrorNumber] FROM [dbo].[tlkpCore_Error] WHERE [ErrorNumber] =  @ErrorNumber)
BEGIN
	SET @SqlErrorNumber = -1003
	GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	INSERT
	      [dbo].[tlkpCore_Error]
	      (
 	     [CreatedByUserID]
 	   , [LastModifiedByUserID]
	   , [ErrorNumber]
	   , [ErrorTitle]
	   , [ErrorMessage]
	      )

	VALUES 
	      (
 	     @CreatedByUserID
 	   , @CreatedByUserID
	   , @ErrorNumber
	   , @ErrorTitle
	   , @ErrorMessage
	      )

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END


	SET  @Timestamp = @@DBTS
END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_AddOneEventType
	  @SqlErrorNumber int = 0 OUTPUT
	, @CreatedByUserID uniqueidentifier = NULL
	, @Timestamp timestamp = NULL OUTPUT
	, @EventTypeCode int
	, @EventTypeName nvarchar(100)
	, @Description nvarchar(1000) = NULL
	, @IsActive bit = 0
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure inserts EventType data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@EventTypeCode IS NULL OR @EventTypeName IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END
/*
** record validation
*/
IF EXISTS (SELECT [EventTypeCode] FROM [dbo].[tlkpCore_EventType] WHERE [EventTypeCode] =  @EventTypeCode)
BEGIN
	SET @SqlErrorNumber = -1003
	GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	INSERT
	      [dbo].[tlkpCore_EventType]
	      (
 	     [CreatedByUserID]
 	   , [LastModifiedByUserID]
	   , [EventTypeCode]
	   , [EventTypeName]
	   , [Description]
	   , [IsActive]
	      )

	VALUES 
	      (
 	     @CreatedByUserID
 	   , @CreatedByUserID
	   , @EventTypeCode
	   , @EventTypeName
	   , @Description
	   , @IsActive
	      )

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END


	SET  @Timestamp = @@DBTS
END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_AddOneSeverityLevel
	  @SqlErrorNumber int = 0 OUTPUT
	, @CreatedByUserID uniqueidentifier = NULL
	, @Timestamp timestamp = NULL OUTPUT
	, @SeverityLevelCode int
	, @SeverityLevelName nvarchar(255)
	, @Description nvarchar(1000) = NULL
	, @IsActive bit = 0
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure inserts SeverityLevel data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@SeverityLevelCode IS NULL OR @SeverityLevelName IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END
/*
** record validation
*/
IF EXISTS (SELECT [SeverityLevelCode] FROM [dbo].[tlkpCore_SeverityLevel] WHERE [SeverityLevelCode] =  @SeverityLevelCode)
BEGIN
	SET @SqlErrorNumber = -1003
	GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	INSERT
	      [dbo].[tlkpCore_SeverityLevel]
	      (
 	     [CreatedByUserID]
 	   , [LastModifiedByUserID]
	   , [SeverityLevelCode]
	   , [SeverityLevelName]
	   , [Description]
	   , [IsActive]
	      )

	VALUES 
	      (
 	     @CreatedByUserID
 	   , @CreatedByUserID
	   , @SeverityLevelCode
	   , @SeverityLevelName
	   , @Description
	   , @IsActive
	      )

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END


	SET  @Timestamp = @@DBTS
END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_DeleteAllBaseAttributeDataByAttributeTypeCode
	  @SqlErrorNumber int = 0 OUTPUT
	, @AttributeTypeCode int
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure deletes all BaseAttribute data by a key.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@AttributeTypeCode IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	DELETE FROM
	      [dbo].[tblCore_BaseAttribute]
	WHERE [AttributeTypeCode] =  @AttributeTypeCode

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_DeleteAllBaseAttributeDataByDataTypeCode
	  @SqlErrorNumber int = 0 OUTPUT
	, @DataTypeCode int
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure deletes all BaseAttribute data by a key.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@DataTypeCode IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	DELETE FROM
	      [dbo].[tblCore_BaseAttribute]
	WHERE [DataTypeCode] =  @DataTypeCode

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_DeleteAllDebugAttributeDataByAttributeTypeCode
	  @SqlErrorNumber int = 0 OUTPUT
	, @AttributeTypeCode int
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure deletes all DebugAttribute data by a key.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@AttributeTypeCode IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	DELETE FROM
	      [dbo].[tblCore_DebugAttribute]
	WHERE [BaseAttributeID] IN (SELECT [BaseAttributeID] FROM [dbo].[tblCore_BaseAttribute] WHERE [AttributeTypeCode] =  @AttributeTypeCode)

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_DeleteAllDebugAttributeDataByBaseAttributeID
	  @SqlErrorNumber int = 0 OUTPUT
	, @BaseAttributeID uniqueidentifier
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure deletes all DebugAttribute data by a key.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@BaseAttributeID IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	DELETE FROM
	      [dbo].[tblCore_DebugAttribute]
	WHERE [BaseAttributeID] =  @BaseAttributeID

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_DeleteAllDebugAttributeDataByDataTypeCode
	  @SqlErrorNumber int = 0 OUTPUT
	, @DataTypeCode int
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure deletes all DebugAttribute data by a key.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@DataTypeCode IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	DELETE FROM
	      [dbo].[tblCore_DebugAttribute]
	WHERE [BaseAttributeID] IN (SELECT [BaseAttributeID] FROM [dbo].[tblCore_BaseAttribute] WHERE [DataTypeCode] =  @DataTypeCode)

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_DeleteOneAttributeType
	  @SqlErrorNumber int = 0 OUTPUT
	, @Timestamp timestamp = NULL OUTPUT
	, @CheckTimestamp bit = 0
	, @AttributeTypeCode int
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure deletes AttributeType data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@AttributeTypeCode IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END
/*
** record validation
*/
IF NOT EXISTS (SELECT [AttributeTypeCode] FROM [dbo].[tlkpCore_AttributeType] WHERE [AttributeTypeCode] =  @AttributeTypeCode)
BEGIN
	SET @SqlErrorNumber = -1003
	GOTO EXIT_ERROR
END
/*
** timestamp validation
*/
IF (@CheckTimestamp = 1)
BEGIN
	IF EXISTS (SELECT [AttributeTypeCode] FROM [dbo].[tlkpCore_AttributeType] WHERE [AttributeTypeCode] =  @AttributeTypeCode AND [Timestamp] <> @Timestamp)
	BEGIN
		SET @SqlErrorNumber = -1002
		GOTO EXIT_ERROR
	END
END

/*
** perform main procedure tasks
*/
BEGIN
	DELETE FROM
	      [dbo].[tlkpCore_AttributeType]
	WHERE [AttributeTypeCode] =  @AttributeTypeCode

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_DeleteOneBaseAttribute
	  @SqlErrorNumber int = 0 OUTPUT
	, @Timestamp timestamp = NULL OUTPUT
	, @CheckTimestamp bit = 0
	, @BaseAttributeID uniqueidentifier
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure deletes BaseAttribute data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@BaseAttributeID IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END
/*
** record validation
*/
IF NOT EXISTS (SELECT [BaseAttributeID] FROM [dbo].[tblCore_BaseAttribute] WHERE [BaseAttributeID] =  @BaseAttributeID)
BEGIN
	SET @SqlErrorNumber = -1003
	GOTO EXIT_ERROR
END
/*
** timestamp validation
*/
IF (@CheckTimestamp = 1)
BEGIN
	IF EXISTS (SELECT [BaseAttributeID] FROM [dbo].[tblCore_BaseAttribute] WHERE [BaseAttributeID] =  @BaseAttributeID AND [Timestamp] <> @Timestamp)
	BEGIN
		SET @SqlErrorNumber = -1002
		GOTO EXIT_ERROR
	END
END

/*
** perform main procedure tasks
*/
BEGIN
	DELETE FROM
	      [dbo].[tblCore_BaseAttribute]
	WHERE [BaseAttributeID] =  @BaseAttributeID

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_DeleteOneDataType
	  @SqlErrorNumber int = 0 OUTPUT
	, @Timestamp timestamp = NULL OUTPUT
	, @CheckTimestamp bit = 0
	, @DataTypeCode int
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure deletes DataType data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@DataTypeCode IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END
/*
** record validation
*/
IF NOT EXISTS (SELECT [DataTypeCode] FROM [dbo].[tlkpCore_DataType] WHERE [DataTypeCode] =  @DataTypeCode)
BEGIN
	SET @SqlErrorNumber = -1003
	GOTO EXIT_ERROR
END
/*
** timestamp validation
*/
IF (@CheckTimestamp = 1)
BEGIN
	IF EXISTS (SELECT [DataTypeCode] FROM [dbo].[tlkpCore_DataType] WHERE [DataTypeCode] =  @DataTypeCode AND [Timestamp] <> @Timestamp)
	BEGIN
		SET @SqlErrorNumber = -1002
		GOTO EXIT_ERROR
	END
END

/*
** perform main procedure tasks
*/
BEGIN
	DELETE FROM
	      [dbo].[tlkpCore_DataType]
	WHERE [DataTypeCode] =  @DataTypeCode

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_DeleteOneDebugAttribute
	  @SqlErrorNumber int = 0 OUTPUT
	, @Timestamp timestamp = NULL OUTPUT
	, @CheckTimestamp bit = 0
	, @BaseAttributeID uniqueidentifier
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure deletes DebugAttribute data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@BaseAttributeID IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END
/*
** record validation
*/
IF NOT EXISTS (SELECT [BaseAttributeID] FROM [dbo].[tblCore_DebugAttribute] WHERE [BaseAttributeID] =  @BaseAttributeID)
BEGIN
	SET @SqlErrorNumber = -1003
	GOTO EXIT_ERROR
END
/*
** timestamp validation
*/
IF (@CheckTimestamp = 1)
BEGIN
	IF EXISTS (SELECT [BaseAttributeID] FROM [dbo].[tblCore_DebugAttribute] WHERE [BaseAttributeID] =  @BaseAttributeID AND [Timestamp] <> @Timestamp)
	BEGIN
		SET @SqlErrorNumber = -1002
		GOTO EXIT_ERROR
	END
END

/*
** perform main procedure tasks
*/
BEGIN
	DELETE FROM
	      [dbo].[tblCore_DebugAttribute]
	WHERE [BaseAttributeID] =  @BaseAttributeID

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_DeleteOneError
	  @SqlErrorNumber int = 0 OUTPUT
	, @Timestamp timestamp = NULL OUTPUT
	, @CheckTimestamp bit = 0
	, @ErrorNumber int
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure deletes Error data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@ErrorNumber IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END
/*
** record validation
*/
IF NOT EXISTS (SELECT [ErrorNumber] FROM [dbo].[tlkpCore_Error] WHERE [ErrorNumber] =  @ErrorNumber)
BEGIN
	SET @SqlErrorNumber = -1003
	GOTO EXIT_ERROR
END
/*
** timestamp validation
*/
IF (@CheckTimestamp = 1)
BEGIN
	IF EXISTS (SELECT [ErrorNumber] FROM [dbo].[tlkpCore_Error] WHERE [ErrorNumber] =  @ErrorNumber AND [Timestamp] <> @Timestamp)
	BEGIN
		SET @SqlErrorNumber = -1002
		GOTO EXIT_ERROR
	END
END

/*
** perform main procedure tasks
*/
BEGIN
	DELETE FROM
	      [dbo].[tlkpCore_Error]
	WHERE [ErrorNumber] =  @ErrorNumber

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_DeleteOneEventType
	  @SqlErrorNumber int = 0 OUTPUT
	, @Timestamp timestamp = NULL OUTPUT
	, @CheckTimestamp bit = 0
	, @EventTypeCode int
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure deletes EventType data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@EventTypeCode IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END
/*
** record validation
*/
IF NOT EXISTS (SELECT [EventTypeCode] FROM [dbo].[tlkpCore_EventType] WHERE [EventTypeCode] =  @EventTypeCode)
BEGIN
	SET @SqlErrorNumber = -1003
	GOTO EXIT_ERROR
END
/*
** timestamp validation
*/
IF (@CheckTimestamp = 1)
BEGIN
	IF EXISTS (SELECT [EventTypeCode] FROM [dbo].[tlkpCore_EventType] WHERE [EventTypeCode] =  @EventTypeCode AND [Timestamp] <> @Timestamp)
	BEGIN
		SET @SqlErrorNumber = -1002
		GOTO EXIT_ERROR
	END
END

/*
** perform main procedure tasks
*/
BEGIN
	DELETE FROM
	      [dbo].[tlkpCore_EventType]
	WHERE [EventTypeCode] =  @EventTypeCode

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_DeleteOneSeverityLevel
	  @SqlErrorNumber int = 0 OUTPUT
	, @Timestamp timestamp = NULL OUTPUT
	, @CheckTimestamp bit = 0
	, @SeverityLevelCode int
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure deletes SeverityLevel data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@SeverityLevelCode IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END
/*
** record validation
*/
IF NOT EXISTS (SELECT [SeverityLevelCode] FROM [dbo].[tlkpCore_SeverityLevel] WHERE [SeverityLevelCode] =  @SeverityLevelCode)
BEGIN
	SET @SqlErrorNumber = -1003
	GOTO EXIT_ERROR
END
/*
** timestamp validation
*/
IF (@CheckTimestamp = 1)
BEGIN
	IF EXISTS (SELECT [SeverityLevelCode] FROM [dbo].[tlkpCore_SeverityLevel] WHERE [SeverityLevelCode] =  @SeverityLevelCode AND [Timestamp] <> @Timestamp)
	BEGIN
		SET @SqlErrorNumber = -1002
		GOTO EXIT_ERROR
	END
END

/*
** perform main procedure tasks
*/
BEGIN
	DELETE FROM
	      [dbo].[tlkpCore_SeverityLevel]
	WHERE [SeverityLevelCode] =  @SeverityLevelCode

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_GetAllAttributeTypeData
	  @SqlErrorNumber int = 0 OUTPUT
	, @SortColumn sysname = 'AttributeTypeCode'
	, @SortDirection nvarchar(20) = 'Ascending'
	, @IncludeInactive bit = 0
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets all AttributeType data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0
IF (@SortColumn = '') SET @SortColumn='AttributeTypeCode'

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

IF (@SortDirection = 'Random')
BEGIN
	SELECT
		  AttributeType1.[AttributeTypeCode]
		, AttributeType1.[AttributeTypeName]
		, AttributeType1.[Description]
		, AttributeType1.[IsActive]
		, AttributeType1.[CreatedByUserID]
		, AttributeType1.[CreatedDate]
		, AttributeType1.[LastModifiedByUserID]
		, AttributeType1.[LastModifiedDate]
		, AttributeType1.[Timestamp]
	FROM
	      [dbo].[tlkpCore_AttributeType] AttributeType1
	WHERE 
		AttributeType1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN AttributeType1.[IsActive] ELSE 1 END

	ORDER BY NewID()
END
ELSE
BEGIN
	SELECT
		  AttributeType1.[AttributeTypeCode]
		, AttributeType1.[AttributeTypeName]
		, AttributeType1.[Description]
		, AttributeType1.[IsActive]
		, AttributeType1.[CreatedByUserID]
		, AttributeType1.[CreatedDate]
		, AttributeType1.[LastModifiedByUserID]
		, AttributeType1.[LastModifiedDate]
		, AttributeType1.[Timestamp]
	FROM
	      [dbo].[tlkpCore_AttributeType] AttributeType1
	WHERE 
		AttributeType1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN AttributeType1.[IsActive] ELSE 1 END

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeTypeCode' THEN AttributeType1.[AttributeTypeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeTypeCode' THEN AttributeType1.[AttributeTypeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeTypeName' THEN AttributeType1.[AttributeTypeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeTypeName' THEN AttributeType1.[AttributeTypeName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Description' THEN AttributeType1.[Description] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Description' THEN AttributeType1.[Description] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'IsActive' THEN AttributeType1.[IsActive] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'IsActive' THEN AttributeType1.[IsActive] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN AttributeType1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN AttributeType1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN AttributeType1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN AttributeType1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN AttributeType1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN AttributeType1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN AttributeType1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN AttributeType1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN AttributeType1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN AttributeType1.[Timestamp] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END


RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_GetAllBaseAttributeData
	  @SqlErrorNumber int = 0 OUTPUT
	, @SortColumn sysname = 'BaseAttributeID'
	, @SortDirection nvarchar(20) = 'Ascending'
	, @IncludeInactive bit = 0
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets all BaseAttribute data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0
IF (@SortColumn = '') SET @SortColumn='BaseAttributeID'

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

IF (@SortDirection = 'Random')
BEGIN
	SELECT
		  BaseAttribute1.[BaseAttributeID]
		, BaseAttribute1.[AttributeName]
		, BaseAttribute1.[AttributeTypeCode]
		, BaseAttribute1.[DataTypeCode]
		, BaseAttribute1.[Description]
		, BaseAttribute1.[IsActive]
		, BaseAttribute1.[CreatedByUserID]
		, BaseAttribute1.[CreatedDate]
		, BaseAttribute1.[LastModifiedByUserID]
		, BaseAttribute1.[LastModifiedDate]
		, BaseAttribute1.[Timestamp]
		, AttributeType1.[AttributeTypeName]
		, DataType1.[DataTypeName]
	FROM
	      [dbo].[tblCore_BaseAttribute] BaseAttribute1
	INNER JOIN [dbo].[tlkpCore_AttributeType] AttributeType1 ON AttributeType1.[AttributeTypeCode]=BaseAttribute1.[AttributeTypeCode]
	INNER JOIN [dbo].[tlkpCore_DataType] DataType1 ON DataType1.[DataTypeCode]=BaseAttribute1.[DataTypeCode]
	WHERE 
		BaseAttribute1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN BaseAttribute1.[IsActive] ELSE 1 END

	ORDER BY NewID()
END
ELSE
BEGIN
	SELECT
		  BaseAttribute1.[BaseAttributeID]
		, BaseAttribute1.[AttributeName]
		, BaseAttribute1.[AttributeTypeCode]
		, BaseAttribute1.[DataTypeCode]
		, BaseAttribute1.[Description]
		, BaseAttribute1.[IsActive]
		, BaseAttribute1.[CreatedByUserID]
		, BaseAttribute1.[CreatedDate]
		, BaseAttribute1.[LastModifiedByUserID]
		, BaseAttribute1.[LastModifiedDate]
		, BaseAttribute1.[Timestamp]
		, AttributeType1.[AttributeTypeName]
		, DataType1.[DataTypeName]
	FROM
	      [dbo].[tblCore_BaseAttribute] BaseAttribute1
	INNER JOIN [dbo].[tlkpCore_AttributeType] AttributeType1 ON AttributeType1.[AttributeTypeCode]=BaseAttribute1.[AttributeTypeCode]
	INNER JOIN [dbo].[tlkpCore_DataType] DataType1 ON DataType1.[DataTypeCode]=BaseAttribute1.[DataTypeCode]
	WHERE 
		BaseAttribute1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN BaseAttribute1.[IsActive] ELSE 1 END

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'BaseAttributeID' THEN BaseAttribute1.[BaseAttributeID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'BaseAttributeID' THEN BaseAttribute1.[BaseAttributeID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeName' THEN BaseAttribute1.[AttributeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeName' THEN BaseAttribute1.[AttributeName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeTypeCode' THEN BaseAttribute1.[AttributeTypeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeTypeCode' THEN BaseAttribute1.[AttributeTypeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'DataTypeCode' THEN BaseAttribute1.[DataTypeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'DataTypeCode' THEN BaseAttribute1.[DataTypeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Description' THEN BaseAttribute1.[Description] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Description' THEN BaseAttribute1.[Description] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'IsActive' THEN BaseAttribute1.[IsActive] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'IsActive' THEN BaseAttribute1.[IsActive] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN BaseAttribute1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN BaseAttribute1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN BaseAttribute1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN BaseAttribute1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN BaseAttribute1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN BaseAttribute1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN BaseAttribute1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN BaseAttribute1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN BaseAttribute1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN BaseAttribute1.[Timestamp] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeTypeName' THEN AttributeType1.[AttributeTypeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeTypeName' THEN AttributeType1.[AttributeTypeName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'DataTypeName' THEN DataType1.[DataTypeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'DataTypeName' THEN DataType1.[DataTypeName] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END


RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_GetAllBaseAttributeDataByAttributeTypeCode
	  @SqlErrorNumber int = 0 OUTPUT
	, @SortColumn sysname = 'AttributeTypeCode'
	, @SortDirection nvarchar(20) = 'Ascending'
	, @IncludeInactive bit = 0
	, @AttributeTypeCode int
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets all BaseAttribute data by a key.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0
IF (@SortColumn = '') SET @SortColumn='AttributeTypeCode'

/*
** parameter validation
*/
IF (@AttributeTypeCode IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

IF (@SortDirection = 'Random')
BEGIN
	SELECT
		  BaseAttribute1.[BaseAttributeID]
		, BaseAttribute1.[AttributeName]
		, BaseAttribute1.[AttributeTypeCode]
		, BaseAttribute1.[DataTypeCode]
		, BaseAttribute1.[Description]
		, BaseAttribute1.[IsActive]
		, BaseAttribute1.[CreatedByUserID]
		, BaseAttribute1.[CreatedDate]
		, BaseAttribute1.[LastModifiedByUserID]
		, BaseAttribute1.[LastModifiedDate]
		, BaseAttribute1.[Timestamp]
		, AttributeType1.[AttributeTypeName]
		, DataType1.[DataTypeName]
	FROM
	      [dbo].[tblCore_BaseAttribute] BaseAttribute1
	INNER JOIN [dbo].[tlkpCore_AttributeType] AttributeType1 ON AttributeType1.[AttributeTypeCode]=BaseAttribute1.[AttributeTypeCode]
	INNER JOIN [dbo].[tlkpCore_DataType] DataType1 ON DataType1.[DataTypeCode]=BaseAttribute1.[DataTypeCode]
	WHERE 
		BaseAttribute1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN BaseAttribute1.[IsActive] ELSE 1 END
		AND BaseAttribute1.[AttributeTypeCode] = @AttributeTypeCode

	ORDER BY NewID()
END
ELSE
BEGIN
	SELECT
		  BaseAttribute1.[BaseAttributeID]
		, BaseAttribute1.[AttributeName]
		, BaseAttribute1.[AttributeTypeCode]
		, BaseAttribute1.[DataTypeCode]
		, BaseAttribute1.[Description]
		, BaseAttribute1.[IsActive]
		, BaseAttribute1.[CreatedByUserID]
		, BaseAttribute1.[CreatedDate]
		, BaseAttribute1.[LastModifiedByUserID]
		, BaseAttribute1.[LastModifiedDate]
		, BaseAttribute1.[Timestamp]
		, AttributeType1.[AttributeTypeName]
		, DataType1.[DataTypeName]
	FROM
	      [dbo].[tblCore_BaseAttribute] BaseAttribute1
	INNER JOIN [dbo].[tlkpCore_AttributeType] AttributeType1 ON AttributeType1.[AttributeTypeCode]=BaseAttribute1.[AttributeTypeCode]
	INNER JOIN [dbo].[tlkpCore_DataType] DataType1 ON DataType1.[DataTypeCode]=BaseAttribute1.[DataTypeCode]
	WHERE 
		BaseAttribute1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN BaseAttribute1.[IsActive] ELSE 1 END
		AND BaseAttribute1.[AttributeTypeCode] = @AttributeTypeCode

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'BaseAttributeID' THEN BaseAttribute1.[BaseAttributeID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'BaseAttributeID' THEN BaseAttribute1.[BaseAttributeID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeName' THEN BaseAttribute1.[AttributeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeName' THEN BaseAttribute1.[AttributeName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeTypeCode' THEN BaseAttribute1.[AttributeTypeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeTypeCode' THEN BaseAttribute1.[AttributeTypeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'DataTypeCode' THEN BaseAttribute1.[DataTypeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'DataTypeCode' THEN BaseAttribute1.[DataTypeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Description' THEN BaseAttribute1.[Description] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Description' THEN BaseAttribute1.[Description] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'IsActive' THEN BaseAttribute1.[IsActive] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'IsActive' THEN BaseAttribute1.[IsActive] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN BaseAttribute1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN BaseAttribute1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN BaseAttribute1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN BaseAttribute1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN BaseAttribute1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN BaseAttribute1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN BaseAttribute1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN BaseAttribute1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN BaseAttribute1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN BaseAttribute1.[Timestamp] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeTypeName' THEN AttributeType1.[AttributeTypeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeTypeName' THEN AttributeType1.[AttributeTypeName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'DataTypeName' THEN DataType1.[DataTypeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'DataTypeName' THEN DataType1.[DataTypeName] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END


RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_GetAllBaseAttributeDataByCriteria
	  @SqlErrorNumber int = 0 OUTPUT
	, @SortColumn sysname = 'AttributeName'
	, @SortDirection nvarchar(20) = 'Ascending'
	, @IncludeInactive bit = 0
	, @AttributeName nvarchar(100)
	, @AttributeTypeCode int
	, @DataTypeCode int
	, @LastModifiedDateStart datetime = getdate
	, @LastModifiedDateEnd datetime = getdate
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets all BaseAttribute data by criteria.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0
IF (@SortColumn = '') SET @SortColumn='AttributeName'

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

IF (@SortDirection = 'Random')
BEGIN
	SELECT
		  BaseAttribute1.[BaseAttributeID]
		, BaseAttribute1.[AttributeName]
		, BaseAttribute1.[AttributeTypeCode]
		, BaseAttribute1.[DataTypeCode]
		, BaseAttribute1.[Description]
		, BaseAttribute1.[IsActive]
		, BaseAttribute1.[CreatedByUserID]
		, BaseAttribute1.[CreatedDate]
		, BaseAttribute1.[LastModifiedByUserID]
		, BaseAttribute1.[LastModifiedDate]
		, BaseAttribute1.[Timestamp]
		, AttributeType1.[AttributeTypeName]
		, DataType1.[DataTypeName]
	FROM
	      [dbo].[tblCore_BaseAttribute] BaseAttribute1
	INNER JOIN [dbo].[tlkpCore_AttributeType] AttributeType1 ON AttributeType1.[AttributeTypeCode]=BaseAttribute1.[AttributeTypeCode]
	INNER JOIN [dbo].[tlkpCore_DataType] DataType1 ON DataType1.[DataTypeCode]=BaseAttribute1.[DataTypeCode]
	WHERE 
		BaseAttribute1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN BaseAttribute1.[IsActive] ELSE 1 END
		AND (@AttributeName IS NULL OR BaseAttribute1.[AttributeName] like '%' + @AttributeName + '%')
		AND (@AttributeTypeCode IS NULL OR BaseAttribute1.[AttributeTypeCode] = @AttributeTypeCode)
		AND (@DataTypeCode IS NULL OR BaseAttribute1.[DataTypeCode] = @DataTypeCode)
		AND ((@LastModifiedDateStart  IS NULL) OR (BaseAttribute1.[LastModifiedDate] >=  @LastModifiedDateStart))
		AND ((@LastModifiedDateEnd  IS NULL) OR (BaseAttribute1.[LastModifiedDate] <=  @LastModifiedDateEnd))

	ORDER BY NewID()
END
ELSE
BEGIN
	SELECT
		  BaseAttribute1.[BaseAttributeID]
		, BaseAttribute1.[AttributeName]
		, BaseAttribute1.[AttributeTypeCode]
		, BaseAttribute1.[DataTypeCode]
		, BaseAttribute1.[Description]
		, BaseAttribute1.[IsActive]
		, BaseAttribute1.[CreatedByUserID]
		, BaseAttribute1.[CreatedDate]
		, BaseAttribute1.[LastModifiedByUserID]
		, BaseAttribute1.[LastModifiedDate]
		, BaseAttribute1.[Timestamp]
		, AttributeType1.[AttributeTypeName]
		, DataType1.[DataTypeName]
	FROM
	      [dbo].[tblCore_BaseAttribute] BaseAttribute1
	INNER JOIN [dbo].[tlkpCore_AttributeType] AttributeType1 ON AttributeType1.[AttributeTypeCode]=BaseAttribute1.[AttributeTypeCode]
	INNER JOIN [dbo].[tlkpCore_DataType] DataType1 ON DataType1.[DataTypeCode]=BaseAttribute1.[DataTypeCode]
	WHERE 
		BaseAttribute1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN BaseAttribute1.[IsActive] ELSE 1 END
		AND (@AttributeName IS NULL OR BaseAttribute1.[AttributeName] like '%' + @AttributeName + '%')
		AND (@AttributeTypeCode IS NULL OR BaseAttribute1.[AttributeTypeCode] = @AttributeTypeCode)
		AND (@DataTypeCode IS NULL OR BaseAttribute1.[DataTypeCode] = @DataTypeCode)
		AND ((@LastModifiedDateStart  IS NULL) OR (BaseAttribute1.[LastModifiedDate] >=  @LastModifiedDateStart))
		AND ((@LastModifiedDateEnd  IS NULL) OR (BaseAttribute1.[LastModifiedDate] <=  @LastModifiedDateEnd))

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'BaseAttributeID' THEN BaseAttribute1.[BaseAttributeID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'BaseAttributeID' THEN BaseAttribute1.[BaseAttributeID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeName' THEN BaseAttribute1.[AttributeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeName' THEN BaseAttribute1.[AttributeName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeTypeCode' THEN BaseAttribute1.[AttributeTypeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeTypeCode' THEN BaseAttribute1.[AttributeTypeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'DataTypeCode' THEN BaseAttribute1.[DataTypeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'DataTypeCode' THEN BaseAttribute1.[DataTypeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Description' THEN BaseAttribute1.[Description] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Description' THEN BaseAttribute1.[Description] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'IsActive' THEN BaseAttribute1.[IsActive] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'IsActive' THEN BaseAttribute1.[IsActive] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN BaseAttribute1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN BaseAttribute1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN BaseAttribute1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN BaseAttribute1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN BaseAttribute1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN BaseAttribute1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN BaseAttribute1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN BaseAttribute1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN BaseAttribute1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN BaseAttribute1.[Timestamp] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeTypeName' THEN AttributeType1.[AttributeTypeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeTypeName' THEN AttributeType1.[AttributeTypeName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'DataTypeName' THEN DataType1.[DataTypeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'DataTypeName' THEN DataType1.[DataTypeName] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END


RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_GetAllBaseAttributeDataByDataTypeCode
	  @SqlErrorNumber int = 0 OUTPUT
	, @SortColumn sysname = 'DataTypeCode'
	, @SortDirection nvarchar(20) = 'Ascending'
	, @IncludeInactive bit = 0
	, @DataTypeCode int
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets all BaseAttribute data by a key.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0
IF (@SortColumn = '') SET @SortColumn='DataTypeCode'

/*
** parameter validation
*/
IF (@DataTypeCode IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

IF (@SortDirection = 'Random')
BEGIN
	SELECT
		  BaseAttribute1.[BaseAttributeID]
		, BaseAttribute1.[AttributeName]
		, BaseAttribute1.[AttributeTypeCode]
		, BaseAttribute1.[DataTypeCode]
		, BaseAttribute1.[Description]
		, BaseAttribute1.[IsActive]
		, BaseAttribute1.[CreatedByUserID]
		, BaseAttribute1.[CreatedDate]
		, BaseAttribute1.[LastModifiedByUserID]
		, BaseAttribute1.[LastModifiedDate]
		, BaseAttribute1.[Timestamp]
		, AttributeType1.[AttributeTypeName]
		, DataType1.[DataTypeName]
	FROM
	      [dbo].[tblCore_BaseAttribute] BaseAttribute1
	INNER JOIN [dbo].[tlkpCore_AttributeType] AttributeType1 ON AttributeType1.[AttributeTypeCode]=BaseAttribute1.[AttributeTypeCode]
	INNER JOIN [dbo].[tlkpCore_DataType] DataType1 ON DataType1.[DataTypeCode]=BaseAttribute1.[DataTypeCode]
	WHERE 
		BaseAttribute1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN BaseAttribute1.[IsActive] ELSE 1 END
		AND BaseAttribute1.[DataTypeCode] = @DataTypeCode

	ORDER BY NewID()
END
ELSE
BEGIN
	SELECT
		  BaseAttribute1.[BaseAttributeID]
		, BaseAttribute1.[AttributeName]
		, BaseAttribute1.[AttributeTypeCode]
		, BaseAttribute1.[DataTypeCode]
		, BaseAttribute1.[Description]
		, BaseAttribute1.[IsActive]
		, BaseAttribute1.[CreatedByUserID]
		, BaseAttribute1.[CreatedDate]
		, BaseAttribute1.[LastModifiedByUserID]
		, BaseAttribute1.[LastModifiedDate]
		, BaseAttribute1.[Timestamp]
		, AttributeType1.[AttributeTypeName]
		, DataType1.[DataTypeName]
	FROM
	      [dbo].[tblCore_BaseAttribute] BaseAttribute1
	INNER JOIN [dbo].[tlkpCore_AttributeType] AttributeType1 ON AttributeType1.[AttributeTypeCode]=BaseAttribute1.[AttributeTypeCode]
	INNER JOIN [dbo].[tlkpCore_DataType] DataType1 ON DataType1.[DataTypeCode]=BaseAttribute1.[DataTypeCode]
	WHERE 
		BaseAttribute1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN BaseAttribute1.[IsActive] ELSE 1 END
		AND BaseAttribute1.[DataTypeCode] = @DataTypeCode

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'BaseAttributeID' THEN BaseAttribute1.[BaseAttributeID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'BaseAttributeID' THEN BaseAttribute1.[BaseAttributeID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeName' THEN BaseAttribute1.[AttributeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeName' THEN BaseAttribute1.[AttributeName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeTypeCode' THEN BaseAttribute1.[AttributeTypeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeTypeCode' THEN BaseAttribute1.[AttributeTypeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'DataTypeCode' THEN BaseAttribute1.[DataTypeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'DataTypeCode' THEN BaseAttribute1.[DataTypeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Description' THEN BaseAttribute1.[Description] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Description' THEN BaseAttribute1.[Description] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'IsActive' THEN BaseAttribute1.[IsActive] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'IsActive' THEN BaseAttribute1.[IsActive] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN BaseAttribute1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN BaseAttribute1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN BaseAttribute1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN BaseAttribute1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN BaseAttribute1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN BaseAttribute1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN BaseAttribute1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN BaseAttribute1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN BaseAttribute1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN BaseAttribute1.[Timestamp] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeTypeName' THEN AttributeType1.[AttributeTypeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeTypeName' THEN AttributeType1.[AttributeTypeName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'DataTypeName' THEN DataType1.[DataTypeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'DataTypeName' THEN DataType1.[DataTypeName] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END


RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_GetAllDataTypeData
	  @SqlErrorNumber int = 0 OUTPUT
	, @SortColumn sysname = 'DataTypeCode'
	, @SortDirection nvarchar(20) = 'Ascending'
	, @IncludeInactive bit = 0
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets all DataType data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0
IF (@SortColumn = '') SET @SortColumn='DataTypeCode'

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

IF (@SortDirection = 'Random')
BEGIN
	SELECT
		  DataType1.[DataTypeCode]
		, DataType1.[DataTypeName]
		, DataType1.[Description]
		, DataType1.[IsActive]
		, DataType1.[CreatedByUserID]
		, DataType1.[CreatedDate]
		, DataType1.[LastModifiedByUserID]
		, DataType1.[LastModifiedDate]
		, DataType1.[Timestamp]
	FROM
	      [dbo].[tlkpCore_DataType] DataType1
	WHERE 
		DataType1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN DataType1.[IsActive] ELSE 1 END

	ORDER BY NewID()
END
ELSE
BEGIN
	SELECT
		  DataType1.[DataTypeCode]
		, DataType1.[DataTypeName]
		, DataType1.[Description]
		, DataType1.[IsActive]
		, DataType1.[CreatedByUserID]
		, DataType1.[CreatedDate]
		, DataType1.[LastModifiedByUserID]
		, DataType1.[LastModifiedDate]
		, DataType1.[Timestamp]
	FROM
	      [dbo].[tlkpCore_DataType] DataType1
	WHERE 
		DataType1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN DataType1.[IsActive] ELSE 1 END

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'DataTypeCode' THEN DataType1.[DataTypeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'DataTypeCode' THEN DataType1.[DataTypeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'DataTypeName' THEN DataType1.[DataTypeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'DataTypeName' THEN DataType1.[DataTypeName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Description' THEN DataType1.[Description] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Description' THEN DataType1.[Description] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'IsActive' THEN DataType1.[IsActive] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'IsActive' THEN DataType1.[IsActive] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN DataType1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN DataType1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN DataType1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN DataType1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN DataType1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN DataType1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN DataType1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN DataType1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN DataType1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN DataType1.[Timestamp] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END


RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_GetAllDebugAttributeData
	  @SqlErrorNumber int = 0 OUTPUT
	, @SortColumn sysname = 'BaseAttributeID'
	, @SortDirection nvarchar(20) = 'Ascending'
	, @IncludeInactive bit = 0
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets all DebugAttribute data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0
IF (@SortColumn = '') SET @SortColumn='BaseAttributeID'

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

IF (@SortDirection = 'Random')
BEGIN
	SELECT
		  DebugAttribute1.[BaseAttributeID]
		, DebugAttribute1.[AttributeCode]
		, DebugAttribute1.[CreatedByUserID]
		, DebugAttribute1.[CreatedDate]
		, DebugAttribute1.[LastModifiedByUserID]
		, DebugAttribute1.[LastModifiedDate]
		, DebugAttribute1.[Timestamp]
		, BaseAttribute1.[AttributeName]
		, BaseAttribute1.[AttributeTypeCode]
		, BaseAttribute1.[DataTypeCode]
		, BaseAttribute1.[Description]
		, BaseAttribute1.[IsActive]
		, AttributeType1.[AttributeTypeName]
		, DataType1.[DataTypeName]
	FROM
	      [dbo].[tblCore_DebugAttribute] DebugAttribute1
	INNER JOIN [dbo].[tblCore_BaseAttribute] BaseAttribute1 ON BaseAttribute1.[BaseAttributeID]=DebugAttribute1.[BaseAttributeID]
	INNER JOIN [dbo].[tlkpCore_AttributeType] AttributeType1 ON AttributeType1.[AttributeTypeCode]=BaseAttribute1.[AttributeTypeCode]
	INNER JOIN [dbo].[tlkpCore_DataType] DataType1 ON DataType1.[DataTypeCode]=BaseAttribute1.[DataTypeCode]
	WHERE 
		BaseAttribute1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN BaseAttribute1.[IsActive] ELSE 1 END

	ORDER BY NewID()
END
ELSE
BEGIN
	SELECT
		  DebugAttribute1.[BaseAttributeID]
		, DebugAttribute1.[AttributeCode]
		, DebugAttribute1.[CreatedByUserID]
		, DebugAttribute1.[CreatedDate]
		, DebugAttribute1.[LastModifiedByUserID]
		, DebugAttribute1.[LastModifiedDate]
		, DebugAttribute1.[Timestamp]
		, BaseAttribute1.[AttributeName]
		, BaseAttribute1.[AttributeTypeCode]
		, BaseAttribute1.[DataTypeCode]
		, BaseAttribute1.[Description]
		, BaseAttribute1.[IsActive]
		, AttributeType1.[AttributeTypeName]
		, DataType1.[DataTypeName]
	FROM
	      [dbo].[tblCore_DebugAttribute] DebugAttribute1
	INNER JOIN [dbo].[tblCore_BaseAttribute] BaseAttribute1 ON BaseAttribute1.[BaseAttributeID]=DebugAttribute1.[BaseAttributeID]
	INNER JOIN [dbo].[tlkpCore_AttributeType] AttributeType1 ON AttributeType1.[AttributeTypeCode]=BaseAttribute1.[AttributeTypeCode]
	INNER JOIN [dbo].[tlkpCore_DataType] DataType1 ON DataType1.[DataTypeCode]=BaseAttribute1.[DataTypeCode]
	WHERE 
		BaseAttribute1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN BaseAttribute1.[IsActive] ELSE 1 END

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'BaseAttributeID' THEN DebugAttribute1.[BaseAttributeID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'BaseAttributeID' THEN DebugAttribute1.[BaseAttributeID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeCode' THEN DebugAttribute1.[AttributeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeCode' THEN DebugAttribute1.[AttributeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN DebugAttribute1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN DebugAttribute1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN DebugAttribute1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN DebugAttribute1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN DebugAttribute1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN DebugAttribute1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN DebugAttribute1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN DebugAttribute1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN DebugAttribute1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN DebugAttribute1.[Timestamp] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeName' THEN BaseAttribute1.[AttributeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeName' THEN BaseAttribute1.[AttributeName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeTypeCode' THEN BaseAttribute1.[AttributeTypeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeTypeCode' THEN BaseAttribute1.[AttributeTypeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'DataTypeCode' THEN BaseAttribute1.[DataTypeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'DataTypeCode' THEN BaseAttribute1.[DataTypeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Description' THEN BaseAttribute1.[Description] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Description' THEN BaseAttribute1.[Description] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'IsActive' THEN BaseAttribute1.[IsActive] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'IsActive' THEN BaseAttribute1.[IsActive] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeTypeName' THEN AttributeType1.[AttributeTypeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeTypeName' THEN AttributeType1.[AttributeTypeName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'DataTypeName' THEN DataType1.[DataTypeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'DataTypeName' THEN DataType1.[DataTypeName] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END


RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_GetAllDebugAttributeDataByAttributeTypeCode
	  @SqlErrorNumber int = 0 OUTPUT
	, @SortColumn sysname = 'AttributeTypeCode'
	, @SortDirection nvarchar(20) = 'Ascending'
	, @IncludeInactive bit = 0
	, @AttributeTypeCode int
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets all DebugAttribute data by a key.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0
IF (@SortColumn = '') SET @SortColumn='AttributeTypeCode'

/*
** parameter validation
*/
IF (@AttributeTypeCode IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

IF (@SortDirection = 'Random')
BEGIN
	SELECT
		  DebugAttribute1.[BaseAttributeID]
		, DebugAttribute1.[AttributeCode]
		, DebugAttribute1.[CreatedByUserID]
		, DebugAttribute1.[CreatedDate]
		, DebugAttribute1.[LastModifiedByUserID]
		, DebugAttribute1.[LastModifiedDate]
		, DebugAttribute1.[Timestamp]
		, BaseAttribute1.[AttributeName]
		, BaseAttribute1.[AttributeTypeCode]
		, BaseAttribute1.[DataTypeCode]
		, BaseAttribute1.[Description]
		, BaseAttribute1.[IsActive]
		, AttributeType1.[AttributeTypeName]
		, DataType1.[DataTypeName]
	FROM
	      [dbo].[tblCore_DebugAttribute] DebugAttribute1
	INNER JOIN [dbo].[tblCore_BaseAttribute] BaseAttribute1 ON BaseAttribute1.[BaseAttributeID]=DebugAttribute1.[BaseAttributeID]
	INNER JOIN [dbo].[tlkpCore_AttributeType] AttributeType1 ON AttributeType1.[AttributeTypeCode]=BaseAttribute1.[AttributeTypeCode]
	INNER JOIN [dbo].[tlkpCore_DataType] DataType1 ON DataType1.[DataTypeCode]=BaseAttribute1.[DataTypeCode]
	WHERE 
		BaseAttribute1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN BaseAttribute1.[IsActive] ELSE 1 END
		AND BaseAttribute1.[AttributeTypeCode] = @AttributeTypeCode

	ORDER BY NewID()
END
ELSE
BEGIN
	SELECT
		  DebugAttribute1.[BaseAttributeID]
		, DebugAttribute1.[AttributeCode]
		, DebugAttribute1.[CreatedByUserID]
		, DebugAttribute1.[CreatedDate]
		, DebugAttribute1.[LastModifiedByUserID]
		, DebugAttribute1.[LastModifiedDate]
		, DebugAttribute1.[Timestamp]
		, BaseAttribute1.[AttributeName]
		, BaseAttribute1.[AttributeTypeCode]
		, BaseAttribute1.[DataTypeCode]
		, BaseAttribute1.[Description]
		, BaseAttribute1.[IsActive]
		, AttributeType1.[AttributeTypeName]
		, DataType1.[DataTypeName]
	FROM
	      [dbo].[tblCore_DebugAttribute] DebugAttribute1
	INNER JOIN [dbo].[tblCore_BaseAttribute] BaseAttribute1 ON BaseAttribute1.[BaseAttributeID]=DebugAttribute1.[BaseAttributeID]
	INNER JOIN [dbo].[tlkpCore_AttributeType] AttributeType1 ON AttributeType1.[AttributeTypeCode]=BaseAttribute1.[AttributeTypeCode]
	INNER JOIN [dbo].[tlkpCore_DataType] DataType1 ON DataType1.[DataTypeCode]=BaseAttribute1.[DataTypeCode]
	WHERE 
		BaseAttribute1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN BaseAttribute1.[IsActive] ELSE 1 END
		AND BaseAttribute1.[AttributeTypeCode] = @AttributeTypeCode

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'BaseAttributeID' THEN DebugAttribute1.[BaseAttributeID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'BaseAttributeID' THEN DebugAttribute1.[BaseAttributeID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeCode' THEN DebugAttribute1.[AttributeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeCode' THEN DebugAttribute1.[AttributeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN DebugAttribute1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN DebugAttribute1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN DebugAttribute1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN DebugAttribute1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN DebugAttribute1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN DebugAttribute1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN DebugAttribute1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN DebugAttribute1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN DebugAttribute1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN DebugAttribute1.[Timestamp] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeName' THEN BaseAttribute1.[AttributeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeName' THEN BaseAttribute1.[AttributeName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeTypeCode' THEN BaseAttribute1.[AttributeTypeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeTypeCode' THEN BaseAttribute1.[AttributeTypeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'DataTypeCode' THEN BaseAttribute1.[DataTypeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'DataTypeCode' THEN BaseAttribute1.[DataTypeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Description' THEN BaseAttribute1.[Description] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Description' THEN BaseAttribute1.[Description] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'IsActive' THEN BaseAttribute1.[IsActive] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'IsActive' THEN BaseAttribute1.[IsActive] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeTypeName' THEN AttributeType1.[AttributeTypeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeTypeName' THEN AttributeType1.[AttributeTypeName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'DataTypeName' THEN DataType1.[DataTypeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'DataTypeName' THEN DataType1.[DataTypeName] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END


RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_GetAllDebugAttributeDataByBaseAttributeID
	  @SqlErrorNumber int = 0 OUTPUT
	, @SortColumn sysname = 'BaseAttributeID'
	, @SortDirection nvarchar(20) = 'Ascending'
	, @IncludeInactive bit = 0
	, @BaseAttributeID uniqueidentifier
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets all DebugAttribute data by a key.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0
IF (@SortColumn = '') SET @SortColumn='BaseAttributeID'

/*
** parameter validation
*/
IF (@BaseAttributeID IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

IF (@SortDirection = 'Random')
BEGIN
	SELECT
		  DebugAttribute1.[BaseAttributeID]
		, DebugAttribute1.[AttributeCode]
		, DebugAttribute1.[CreatedByUserID]
		, DebugAttribute1.[CreatedDate]
		, DebugAttribute1.[LastModifiedByUserID]
		, DebugAttribute1.[LastModifiedDate]
		, DebugAttribute1.[Timestamp]
		, BaseAttribute1.[AttributeName]
		, BaseAttribute1.[AttributeTypeCode]
		, BaseAttribute1.[DataTypeCode]
		, BaseAttribute1.[Description]
		, BaseAttribute1.[IsActive]
		, AttributeType1.[AttributeTypeName]
		, DataType1.[DataTypeName]
	FROM
	      [dbo].[tblCore_DebugAttribute] DebugAttribute1
	INNER JOIN [dbo].[tblCore_BaseAttribute] BaseAttribute1 ON BaseAttribute1.[BaseAttributeID]=DebugAttribute1.[BaseAttributeID]
	INNER JOIN [dbo].[tlkpCore_AttributeType] AttributeType1 ON AttributeType1.[AttributeTypeCode]=BaseAttribute1.[AttributeTypeCode]
	INNER JOIN [dbo].[tlkpCore_DataType] DataType1 ON DataType1.[DataTypeCode]=BaseAttribute1.[DataTypeCode]
	WHERE 
		BaseAttribute1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN BaseAttribute1.[IsActive] ELSE 1 END
		AND DebugAttribute1.[BaseAttributeID] = @BaseAttributeID

	ORDER BY NewID()
END
ELSE
BEGIN
	SELECT
		  DebugAttribute1.[BaseAttributeID]
		, DebugAttribute1.[AttributeCode]
		, DebugAttribute1.[CreatedByUserID]
		, DebugAttribute1.[CreatedDate]
		, DebugAttribute1.[LastModifiedByUserID]
		, DebugAttribute1.[LastModifiedDate]
		, DebugAttribute1.[Timestamp]
		, BaseAttribute1.[AttributeName]
		, BaseAttribute1.[AttributeTypeCode]
		, BaseAttribute1.[DataTypeCode]
		, BaseAttribute1.[Description]
		, BaseAttribute1.[IsActive]
		, AttributeType1.[AttributeTypeName]
		, DataType1.[DataTypeName]
	FROM
	      [dbo].[tblCore_DebugAttribute] DebugAttribute1
	INNER JOIN [dbo].[tblCore_BaseAttribute] BaseAttribute1 ON BaseAttribute1.[BaseAttributeID]=DebugAttribute1.[BaseAttributeID]
	INNER JOIN [dbo].[tlkpCore_AttributeType] AttributeType1 ON AttributeType1.[AttributeTypeCode]=BaseAttribute1.[AttributeTypeCode]
	INNER JOIN [dbo].[tlkpCore_DataType] DataType1 ON DataType1.[DataTypeCode]=BaseAttribute1.[DataTypeCode]
	WHERE 
		BaseAttribute1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN BaseAttribute1.[IsActive] ELSE 1 END
		AND DebugAttribute1.[BaseAttributeID] = @BaseAttributeID

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'BaseAttributeID' THEN DebugAttribute1.[BaseAttributeID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'BaseAttributeID' THEN DebugAttribute1.[BaseAttributeID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeCode' THEN DebugAttribute1.[AttributeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeCode' THEN DebugAttribute1.[AttributeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN DebugAttribute1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN DebugAttribute1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN DebugAttribute1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN DebugAttribute1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN DebugAttribute1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN DebugAttribute1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN DebugAttribute1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN DebugAttribute1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN DebugAttribute1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN DebugAttribute1.[Timestamp] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeName' THEN BaseAttribute1.[AttributeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeName' THEN BaseAttribute1.[AttributeName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeTypeCode' THEN BaseAttribute1.[AttributeTypeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeTypeCode' THEN BaseAttribute1.[AttributeTypeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'DataTypeCode' THEN BaseAttribute1.[DataTypeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'DataTypeCode' THEN BaseAttribute1.[DataTypeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Description' THEN BaseAttribute1.[Description] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Description' THEN BaseAttribute1.[Description] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'IsActive' THEN BaseAttribute1.[IsActive] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'IsActive' THEN BaseAttribute1.[IsActive] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeTypeName' THEN AttributeType1.[AttributeTypeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeTypeName' THEN AttributeType1.[AttributeTypeName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'DataTypeName' THEN DataType1.[DataTypeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'DataTypeName' THEN DataType1.[DataTypeName] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END


RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_GetAllDebugAttributeDataByCriteria
	  @SqlErrorNumber int = 0 OUTPUT
	, @SortColumn sysname = 'AttributeName'
	, @SortDirection nvarchar(20) = 'Ascending'
	, @IncludeInactive bit = 0
	, @AttributeName nvarchar(100)
	, @AttributeTypeCode int
	, @DataTypeCode int
	, @LastModifiedDateStart datetime = getdate
	, @LastModifiedDateEnd datetime = getdate
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets all DebugAttribute data by criteria.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0
IF (@SortColumn = '') SET @SortColumn='AttributeName'

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

IF (@SortDirection = 'Random')
BEGIN
	SELECT
		  DebugAttribute1.[BaseAttributeID]
		, DebugAttribute1.[AttributeCode]
		, DebugAttribute1.[CreatedByUserID]
		, DebugAttribute1.[CreatedDate]
		, DebugAttribute1.[LastModifiedByUserID]
		, DebugAttribute1.[LastModifiedDate]
		, DebugAttribute1.[Timestamp]
		, BaseAttribute1.[AttributeName]
		, BaseAttribute1.[AttributeTypeCode]
		, BaseAttribute1.[DataTypeCode]
		, BaseAttribute1.[Description]
		, BaseAttribute1.[IsActive]
		, AttributeType1.[AttributeTypeName]
		, DataType1.[DataTypeName]
	FROM
	      [dbo].[tblCore_DebugAttribute] DebugAttribute1
	INNER JOIN [dbo].[tblCore_BaseAttribute] BaseAttribute1 ON BaseAttribute1.[BaseAttributeID]=DebugAttribute1.[BaseAttributeID]
	INNER JOIN [dbo].[tlkpCore_AttributeType] AttributeType1 ON AttributeType1.[AttributeTypeCode]=BaseAttribute1.[AttributeTypeCode]
	INNER JOIN [dbo].[tlkpCore_DataType] DataType1 ON DataType1.[DataTypeCode]=BaseAttribute1.[DataTypeCode]
	WHERE 
		BaseAttribute1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN BaseAttribute1.[IsActive] ELSE 1 END
		AND (@AttributeName IS NULL OR BaseAttribute1.[AttributeName] like '%' + @AttributeName + '%')
		AND (@AttributeTypeCode IS NULL OR BaseAttribute1.[AttributeTypeCode] = @AttributeTypeCode)
		AND (@DataTypeCode IS NULL OR BaseAttribute1.[DataTypeCode] = @DataTypeCode)
		AND ((@LastModifiedDateStart  IS NULL) OR (BaseAttribute1.[LastModifiedDate] >=  @LastModifiedDateStart))
		AND ((@LastModifiedDateEnd  IS NULL) OR (BaseAttribute1.[LastModifiedDate] <=  @LastModifiedDateEnd))

	ORDER BY NewID()
END
ELSE
BEGIN
	SELECT
		  DebugAttribute1.[BaseAttributeID]
		, DebugAttribute1.[AttributeCode]
		, DebugAttribute1.[CreatedByUserID]
		, DebugAttribute1.[CreatedDate]
		, DebugAttribute1.[LastModifiedByUserID]
		, DebugAttribute1.[LastModifiedDate]
		, DebugAttribute1.[Timestamp]
		, BaseAttribute1.[AttributeName]
		, BaseAttribute1.[AttributeTypeCode]
		, BaseAttribute1.[DataTypeCode]
		, BaseAttribute1.[Description]
		, BaseAttribute1.[IsActive]
		, AttributeType1.[AttributeTypeName]
		, DataType1.[DataTypeName]
	FROM
	      [dbo].[tblCore_DebugAttribute] DebugAttribute1
	INNER JOIN [dbo].[tblCore_BaseAttribute] BaseAttribute1 ON BaseAttribute1.[BaseAttributeID]=DebugAttribute1.[BaseAttributeID]
	INNER JOIN [dbo].[tlkpCore_AttributeType] AttributeType1 ON AttributeType1.[AttributeTypeCode]=BaseAttribute1.[AttributeTypeCode]
	INNER JOIN [dbo].[tlkpCore_DataType] DataType1 ON DataType1.[DataTypeCode]=BaseAttribute1.[DataTypeCode]
	WHERE 
		BaseAttribute1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN BaseAttribute1.[IsActive] ELSE 1 END
		AND (@AttributeName IS NULL OR BaseAttribute1.[AttributeName] like '%' + @AttributeName + '%')
		AND (@AttributeTypeCode IS NULL OR BaseAttribute1.[AttributeTypeCode] = @AttributeTypeCode)
		AND (@DataTypeCode IS NULL OR BaseAttribute1.[DataTypeCode] = @DataTypeCode)
		AND ((@LastModifiedDateStart  IS NULL) OR (BaseAttribute1.[LastModifiedDate] >=  @LastModifiedDateStart))
		AND ((@LastModifiedDateEnd  IS NULL) OR (BaseAttribute1.[LastModifiedDate] <=  @LastModifiedDateEnd))

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'BaseAttributeID' THEN DebugAttribute1.[BaseAttributeID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'BaseAttributeID' THEN DebugAttribute1.[BaseAttributeID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeCode' THEN DebugAttribute1.[AttributeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeCode' THEN DebugAttribute1.[AttributeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN DebugAttribute1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN DebugAttribute1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN DebugAttribute1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN DebugAttribute1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN DebugAttribute1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN DebugAttribute1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN DebugAttribute1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN DebugAttribute1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN DebugAttribute1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN DebugAttribute1.[Timestamp] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeName' THEN BaseAttribute1.[AttributeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeName' THEN BaseAttribute1.[AttributeName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeTypeCode' THEN BaseAttribute1.[AttributeTypeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeTypeCode' THEN BaseAttribute1.[AttributeTypeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'DataTypeCode' THEN BaseAttribute1.[DataTypeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'DataTypeCode' THEN BaseAttribute1.[DataTypeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Description' THEN BaseAttribute1.[Description] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Description' THEN BaseAttribute1.[Description] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'IsActive' THEN BaseAttribute1.[IsActive] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'IsActive' THEN BaseAttribute1.[IsActive] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeTypeName' THEN AttributeType1.[AttributeTypeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeTypeName' THEN AttributeType1.[AttributeTypeName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'DataTypeName' THEN DataType1.[DataTypeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'DataTypeName' THEN DataType1.[DataTypeName] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END


RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_GetAllDebugAttributeDataByDataTypeCode
	  @SqlErrorNumber int = 0 OUTPUT
	, @SortColumn sysname = 'DataTypeCode'
	, @SortDirection nvarchar(20) = 'Ascending'
	, @IncludeInactive bit = 0
	, @DataTypeCode int
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets all DebugAttribute data by a key.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0
IF (@SortColumn = '') SET @SortColumn='DataTypeCode'

/*
** parameter validation
*/
IF (@DataTypeCode IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

IF (@SortDirection = 'Random')
BEGIN
	SELECT
		  DebugAttribute1.[BaseAttributeID]
		, DebugAttribute1.[AttributeCode]
		, DebugAttribute1.[CreatedByUserID]
		, DebugAttribute1.[CreatedDate]
		, DebugAttribute1.[LastModifiedByUserID]
		, DebugAttribute1.[LastModifiedDate]
		, DebugAttribute1.[Timestamp]
		, BaseAttribute1.[AttributeName]
		, BaseAttribute1.[AttributeTypeCode]
		, BaseAttribute1.[DataTypeCode]
		, BaseAttribute1.[Description]
		, BaseAttribute1.[IsActive]
		, AttributeType1.[AttributeTypeName]
		, DataType1.[DataTypeName]
	FROM
	      [dbo].[tblCore_DebugAttribute] DebugAttribute1
	INNER JOIN [dbo].[tblCore_BaseAttribute] BaseAttribute1 ON BaseAttribute1.[BaseAttributeID]=DebugAttribute1.[BaseAttributeID]
	INNER JOIN [dbo].[tlkpCore_AttributeType] AttributeType1 ON AttributeType1.[AttributeTypeCode]=BaseAttribute1.[AttributeTypeCode]
	INNER JOIN [dbo].[tlkpCore_DataType] DataType1 ON DataType1.[DataTypeCode]=BaseAttribute1.[DataTypeCode]
	WHERE 
		BaseAttribute1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN BaseAttribute1.[IsActive] ELSE 1 END
		AND BaseAttribute1.[DataTypeCode] = @DataTypeCode

	ORDER BY NewID()
END
ELSE
BEGIN
	SELECT
		  DebugAttribute1.[BaseAttributeID]
		, DebugAttribute1.[AttributeCode]
		, DebugAttribute1.[CreatedByUserID]
		, DebugAttribute1.[CreatedDate]
		, DebugAttribute1.[LastModifiedByUserID]
		, DebugAttribute1.[LastModifiedDate]
		, DebugAttribute1.[Timestamp]
		, BaseAttribute1.[AttributeName]
		, BaseAttribute1.[AttributeTypeCode]
		, BaseAttribute1.[DataTypeCode]
		, BaseAttribute1.[Description]
		, BaseAttribute1.[IsActive]
		, AttributeType1.[AttributeTypeName]
		, DataType1.[DataTypeName]
	FROM
	      [dbo].[tblCore_DebugAttribute] DebugAttribute1
	INNER JOIN [dbo].[tblCore_BaseAttribute] BaseAttribute1 ON BaseAttribute1.[BaseAttributeID]=DebugAttribute1.[BaseAttributeID]
	INNER JOIN [dbo].[tlkpCore_AttributeType] AttributeType1 ON AttributeType1.[AttributeTypeCode]=BaseAttribute1.[AttributeTypeCode]
	INNER JOIN [dbo].[tlkpCore_DataType] DataType1 ON DataType1.[DataTypeCode]=BaseAttribute1.[DataTypeCode]
	WHERE 
		BaseAttribute1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN BaseAttribute1.[IsActive] ELSE 1 END
		AND BaseAttribute1.[DataTypeCode] = @DataTypeCode

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'BaseAttributeID' THEN DebugAttribute1.[BaseAttributeID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'BaseAttributeID' THEN DebugAttribute1.[BaseAttributeID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeCode' THEN DebugAttribute1.[AttributeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeCode' THEN DebugAttribute1.[AttributeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN DebugAttribute1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN DebugAttribute1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN DebugAttribute1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN DebugAttribute1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN DebugAttribute1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN DebugAttribute1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN DebugAttribute1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN DebugAttribute1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN DebugAttribute1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN DebugAttribute1.[Timestamp] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeName' THEN BaseAttribute1.[AttributeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeName' THEN BaseAttribute1.[AttributeName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeTypeCode' THEN BaseAttribute1.[AttributeTypeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeTypeCode' THEN BaseAttribute1.[AttributeTypeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'DataTypeCode' THEN BaseAttribute1.[DataTypeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'DataTypeCode' THEN BaseAttribute1.[DataTypeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Description' THEN BaseAttribute1.[Description] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Description' THEN BaseAttribute1.[Description] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'IsActive' THEN BaseAttribute1.[IsActive] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'IsActive' THEN BaseAttribute1.[IsActive] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeTypeName' THEN AttributeType1.[AttributeTypeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeTypeName' THEN AttributeType1.[AttributeTypeName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'DataTypeName' THEN DataType1.[DataTypeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'DataTypeName' THEN DataType1.[DataTypeName] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END


RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_GetAllDebugAttributeValueLogData
	  @SqlErrorNumber int = 0 OUTPUT
	, @SortColumn sysname = 'DebugAttributeValueLogID'
	, @SortDirection nvarchar(20) = 'Ascending'
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets all DebugAttributeValueLog data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0
IF (@SortColumn = '') SET @SortColumn='DebugAttributeValueLogID'

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

IF (@SortDirection = 'Random')
BEGIN
	SELECT
		  DebugAttributeValueLog1.[DebugAttributeValueLogID]
		, DebugAttributeValueLog1.[DebugLogID]
		, DebugAttributeValueLog1.[BaseAttributeID]
		, DebugAttributeValueLog1.[AttributeValue]
		, DebugAttributeValueLog1.[CreatedByUserID]
		, DebugAttributeValueLog1.[CreatedDate]
		, DebugAttributeValueLog1.[LastModifiedByUserID]
		, DebugAttributeValueLog1.[LastModifiedDate]
		, DebugAttributeValueLog1.[Timestamp]
		, DebugLog1.[EventName]
		, DebugLog1.[ErrorNumber]
	FROM
	      [dbo].[tblCore_DebugAttributeValueLog] DebugAttributeValueLog1
	INNER JOIN [dbo].[tblCore_DebugLog] DebugLog1 ON DebugLog1.[DebugLogID]=DebugAttributeValueLog1.[DebugLogID]

	ORDER BY NewID()
END
ELSE
BEGIN
	SELECT
		  DebugAttributeValueLog1.[DebugAttributeValueLogID]
		, DebugAttributeValueLog1.[DebugLogID]
		, DebugAttributeValueLog1.[BaseAttributeID]
		, DebugAttributeValueLog1.[AttributeValue]
		, DebugAttributeValueLog1.[CreatedByUserID]
		, DebugAttributeValueLog1.[CreatedDate]
		, DebugAttributeValueLog1.[LastModifiedByUserID]
		, DebugAttributeValueLog1.[LastModifiedDate]
		, DebugAttributeValueLog1.[Timestamp]
		, DebugLog1.[EventName]
		, DebugLog1.[ErrorNumber]
	FROM
	      [dbo].[tblCore_DebugAttributeValueLog] DebugAttributeValueLog1
	INNER JOIN [dbo].[tblCore_DebugLog] DebugLog1 ON DebugLog1.[DebugLogID]=DebugAttributeValueLog1.[DebugLogID]

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'DebugAttributeValueLogID' THEN DebugAttributeValueLog1.[DebugAttributeValueLogID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'DebugAttributeValueLogID' THEN DebugAttributeValueLog1.[DebugAttributeValueLogID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'DebugLogID' THEN DebugAttributeValueLog1.[DebugLogID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'DebugLogID' THEN DebugAttributeValueLog1.[DebugLogID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'BaseAttributeID' THEN DebugAttributeValueLog1.[BaseAttributeID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'BaseAttributeID' THEN DebugAttributeValueLog1.[BaseAttributeID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeValue' THEN DebugAttributeValueLog1.[AttributeValue] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeValue' THEN DebugAttributeValueLog1.[AttributeValue] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN DebugAttributeValueLog1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN DebugAttributeValueLog1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN DebugAttributeValueLog1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN DebugAttributeValueLog1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN DebugAttributeValueLog1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN DebugAttributeValueLog1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN DebugAttributeValueLog1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN DebugAttributeValueLog1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN DebugAttributeValueLog1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN DebugAttributeValueLog1.[Timestamp] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'EventName' THEN DebugLog1.[EventName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'EventName' THEN DebugLog1.[EventName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'ErrorNumber' THEN DebugLog1.[ErrorNumber] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'ErrorNumber' THEN DebugLog1.[ErrorNumber] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END


RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_GetAllDebugAttributeValueLogDataByBaseAttributeID
	  @SqlErrorNumber int = 0 OUTPUT
	, @SortColumn sysname = 'BaseAttributeID'
	, @SortDirection nvarchar(20) = 'Ascending'
	, @BaseAttributeID uniqueidentifier
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets all DebugAttributeValueLog data by a key.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0
IF (@SortColumn = '') SET @SortColumn='BaseAttributeID'

/*
** parameter validation
*/
IF (@BaseAttributeID IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

IF (@SortDirection = 'Random')
BEGIN
	SELECT
		  DebugAttributeValueLog1.[DebugAttributeValueLogID]
		, DebugAttributeValueLog1.[DebugLogID]
		, DebugAttributeValueLog1.[BaseAttributeID]
		, DebugAttributeValueLog1.[AttributeValue]
		, DebugAttributeValueLog1.[CreatedByUserID]
		, DebugAttributeValueLog1.[CreatedDate]
		, DebugAttributeValueLog1.[LastModifiedByUserID]
		, DebugAttributeValueLog1.[LastModifiedDate]
		, DebugAttributeValueLog1.[Timestamp]
		, DebugLog1.[EventName]
		, DebugLog1.[ErrorNumber]
	FROM
	      [dbo].[tblCore_DebugAttributeValueLog] DebugAttributeValueLog1
	INNER JOIN [dbo].[tblCore_DebugLog] DebugLog1 ON DebugLog1.[DebugLogID]=DebugAttributeValueLog1.[DebugLogID]
	WHERE 
		DebugAttributeValueLog1.[BaseAttributeID] = @BaseAttributeID

	ORDER BY NewID()
END
ELSE
BEGIN
	SELECT
		  DebugAttributeValueLog1.[DebugAttributeValueLogID]
		, DebugAttributeValueLog1.[DebugLogID]
		, DebugAttributeValueLog1.[BaseAttributeID]
		, DebugAttributeValueLog1.[AttributeValue]
		, DebugAttributeValueLog1.[CreatedByUserID]
		, DebugAttributeValueLog1.[CreatedDate]
		, DebugAttributeValueLog1.[LastModifiedByUserID]
		, DebugAttributeValueLog1.[LastModifiedDate]
		, DebugAttributeValueLog1.[Timestamp]
		, DebugLog1.[EventName]
		, DebugLog1.[ErrorNumber]
	FROM
	      [dbo].[tblCore_DebugAttributeValueLog] DebugAttributeValueLog1
	INNER JOIN [dbo].[tblCore_DebugLog] DebugLog1 ON DebugLog1.[DebugLogID]=DebugAttributeValueLog1.[DebugLogID]
	WHERE 
		DebugAttributeValueLog1.[BaseAttributeID] = @BaseAttributeID

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'DebugAttributeValueLogID' THEN DebugAttributeValueLog1.[DebugAttributeValueLogID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'DebugAttributeValueLogID' THEN DebugAttributeValueLog1.[DebugAttributeValueLogID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'DebugLogID' THEN DebugAttributeValueLog1.[DebugLogID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'DebugLogID' THEN DebugAttributeValueLog1.[DebugLogID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'BaseAttributeID' THEN DebugAttributeValueLog1.[BaseAttributeID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'BaseAttributeID' THEN DebugAttributeValueLog1.[BaseAttributeID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeValue' THEN DebugAttributeValueLog1.[AttributeValue] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeValue' THEN DebugAttributeValueLog1.[AttributeValue] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN DebugAttributeValueLog1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN DebugAttributeValueLog1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN DebugAttributeValueLog1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN DebugAttributeValueLog1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN DebugAttributeValueLog1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN DebugAttributeValueLog1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN DebugAttributeValueLog1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN DebugAttributeValueLog1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN DebugAttributeValueLog1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN DebugAttributeValueLog1.[Timestamp] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'EventName' THEN DebugLog1.[EventName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'EventName' THEN DebugLog1.[EventName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'ErrorNumber' THEN DebugLog1.[ErrorNumber] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'ErrorNumber' THEN DebugLog1.[ErrorNumber] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END


RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_GetAllDebugAttributeValueLogDataByCriteria
	  @SqlErrorNumber int = 0 OUTPUT
	, @SortColumn sysname = 'AttributeValue'
	, @SortDirection nvarchar(20) = 'Ascending'
	, @AttributeValue nvarchar(1000)
	, @LastModifiedDateStart datetime = getdate
	, @LastModifiedDateEnd datetime = getdate
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets all DebugAttributeValueLog data by criteria.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0
IF (@SortColumn = '') SET @SortColumn='AttributeValue'

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

IF (@SortDirection = 'Random')
BEGIN
	SELECT
		  DebugAttributeValueLog1.[DebugAttributeValueLogID]
		, DebugAttributeValueLog1.[DebugLogID]
		, DebugAttributeValueLog1.[BaseAttributeID]
		, DebugAttributeValueLog1.[AttributeValue]
		, DebugAttributeValueLog1.[CreatedByUserID]
		, DebugAttributeValueLog1.[CreatedDate]
		, DebugAttributeValueLog1.[LastModifiedByUserID]
		, DebugAttributeValueLog1.[LastModifiedDate]
		, DebugAttributeValueLog1.[Timestamp]
		, DebugLog1.[EventName]
		, DebugLog1.[ErrorNumber]
	FROM
	      [dbo].[tblCore_DebugAttributeValueLog] DebugAttributeValueLog1
	INNER JOIN [dbo].[tblCore_DebugLog] DebugLog1 ON DebugLog1.[DebugLogID]=DebugAttributeValueLog1.[DebugLogID]
	WHERE 
		(@AttributeValue IS NULL OR DebugAttributeValueLog1.[AttributeValue] like '%' + @AttributeValue + '%')
		AND ((@LastModifiedDateStart  IS NULL) OR (DebugAttributeValueLog1.[LastModifiedDate] >=  @LastModifiedDateStart))
		AND ((@LastModifiedDateEnd  IS NULL) OR (DebugAttributeValueLog1.[LastModifiedDate] <=  @LastModifiedDateEnd))

	ORDER BY NewID()
END
ELSE
BEGIN
	SELECT
		  DebugAttributeValueLog1.[DebugAttributeValueLogID]
		, DebugAttributeValueLog1.[DebugLogID]
		, DebugAttributeValueLog1.[BaseAttributeID]
		, DebugAttributeValueLog1.[AttributeValue]
		, DebugAttributeValueLog1.[CreatedByUserID]
		, DebugAttributeValueLog1.[CreatedDate]
		, DebugAttributeValueLog1.[LastModifiedByUserID]
		, DebugAttributeValueLog1.[LastModifiedDate]
		, DebugAttributeValueLog1.[Timestamp]
		, DebugLog1.[EventName]
		, DebugLog1.[ErrorNumber]
	FROM
	      [dbo].[tblCore_DebugAttributeValueLog] DebugAttributeValueLog1
	INNER JOIN [dbo].[tblCore_DebugLog] DebugLog1 ON DebugLog1.[DebugLogID]=DebugAttributeValueLog1.[DebugLogID]
	WHERE 
		(@AttributeValue IS NULL OR DebugAttributeValueLog1.[AttributeValue] like '%' + @AttributeValue + '%')
		AND ((@LastModifiedDateStart  IS NULL) OR (DebugAttributeValueLog1.[LastModifiedDate] >=  @LastModifiedDateStart))
		AND ((@LastModifiedDateEnd  IS NULL) OR (DebugAttributeValueLog1.[LastModifiedDate] <=  @LastModifiedDateEnd))

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'DebugAttributeValueLogID' THEN DebugAttributeValueLog1.[DebugAttributeValueLogID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'DebugAttributeValueLogID' THEN DebugAttributeValueLog1.[DebugAttributeValueLogID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'DebugLogID' THEN DebugAttributeValueLog1.[DebugLogID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'DebugLogID' THEN DebugAttributeValueLog1.[DebugLogID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'BaseAttributeID' THEN DebugAttributeValueLog1.[BaseAttributeID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'BaseAttributeID' THEN DebugAttributeValueLog1.[BaseAttributeID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeValue' THEN DebugAttributeValueLog1.[AttributeValue] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeValue' THEN DebugAttributeValueLog1.[AttributeValue] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN DebugAttributeValueLog1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN DebugAttributeValueLog1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN DebugAttributeValueLog1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN DebugAttributeValueLog1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN DebugAttributeValueLog1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN DebugAttributeValueLog1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN DebugAttributeValueLog1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN DebugAttributeValueLog1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN DebugAttributeValueLog1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN DebugAttributeValueLog1.[Timestamp] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'EventName' THEN DebugLog1.[EventName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'EventName' THEN DebugLog1.[EventName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'ErrorNumber' THEN DebugLog1.[ErrorNumber] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'ErrorNumber' THEN DebugLog1.[ErrorNumber] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END


RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_GetAllDebugAttributeValueLogDataByDebugLogID
	  @SqlErrorNumber int = 0 OUTPUT
	, @SortColumn sysname = 'DebugLogID'
	, @SortDirection nvarchar(20) = 'Ascending'
	, @DebugLogID uniqueidentifier
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets all DebugAttributeValueLog data by a key.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0
IF (@SortColumn = '') SET @SortColumn='DebugLogID'

/*
** parameter validation
*/
IF (@DebugLogID IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

IF (@SortDirection = 'Random')
BEGIN
	SELECT
		  DebugAttributeValueLog1.[DebugAttributeValueLogID]
		, DebugAttributeValueLog1.[DebugLogID]
		, DebugAttributeValueLog1.[BaseAttributeID]
		, DebugAttributeValueLog1.[AttributeValue]
		, DebugAttributeValueLog1.[CreatedByUserID]
		, DebugAttributeValueLog1.[CreatedDate]
		, DebugAttributeValueLog1.[LastModifiedByUserID]
		, DebugAttributeValueLog1.[LastModifiedDate]
		, DebugAttributeValueLog1.[Timestamp]
		, DebugLog1.[EventName]
		, DebugLog1.[ErrorNumber]
	FROM
	      [dbo].[tblCore_DebugAttributeValueLog] DebugAttributeValueLog1
	INNER JOIN [dbo].[tblCore_DebugLog] DebugLog1 ON DebugLog1.[DebugLogID]=DebugAttributeValueLog1.[DebugLogID]
	WHERE 
		DebugAttributeValueLog1.[DebugLogID] = @DebugLogID

	ORDER BY NewID()
END
ELSE
BEGIN
	SELECT
		  DebugAttributeValueLog1.[DebugAttributeValueLogID]
		, DebugAttributeValueLog1.[DebugLogID]
		, DebugAttributeValueLog1.[BaseAttributeID]
		, DebugAttributeValueLog1.[AttributeValue]
		, DebugAttributeValueLog1.[CreatedByUserID]
		, DebugAttributeValueLog1.[CreatedDate]
		, DebugAttributeValueLog1.[LastModifiedByUserID]
		, DebugAttributeValueLog1.[LastModifiedDate]
		, DebugAttributeValueLog1.[Timestamp]
		, DebugLog1.[EventName]
		, DebugLog1.[ErrorNumber]
	FROM
	      [dbo].[tblCore_DebugAttributeValueLog] DebugAttributeValueLog1
	INNER JOIN [dbo].[tblCore_DebugLog] DebugLog1 ON DebugLog1.[DebugLogID]=DebugAttributeValueLog1.[DebugLogID]
	WHERE 
		DebugAttributeValueLog1.[DebugLogID] = @DebugLogID

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'DebugAttributeValueLogID' THEN DebugAttributeValueLog1.[DebugAttributeValueLogID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'DebugAttributeValueLogID' THEN DebugAttributeValueLog1.[DebugAttributeValueLogID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'DebugLogID' THEN DebugAttributeValueLog1.[DebugLogID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'DebugLogID' THEN DebugAttributeValueLog1.[DebugLogID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'BaseAttributeID' THEN DebugAttributeValueLog1.[BaseAttributeID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'BaseAttributeID' THEN DebugAttributeValueLog1.[BaseAttributeID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeValue' THEN DebugAttributeValueLog1.[AttributeValue] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeValue' THEN DebugAttributeValueLog1.[AttributeValue] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN DebugAttributeValueLog1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN DebugAttributeValueLog1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN DebugAttributeValueLog1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN DebugAttributeValueLog1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN DebugAttributeValueLog1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN DebugAttributeValueLog1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN DebugAttributeValueLog1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN DebugAttributeValueLog1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN DebugAttributeValueLog1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN DebugAttributeValueLog1.[Timestamp] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'EventName' THEN DebugLog1.[EventName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'EventName' THEN DebugLog1.[EventName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'ErrorNumber' THEN DebugLog1.[ErrorNumber] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'ErrorNumber' THEN DebugLog1.[ErrorNumber] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END


RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_GetAllDebugLogData
	  @SqlErrorNumber int = 0 OUTPUT
	, @SortColumn sysname = 'DebugLogID'
	, @SortDirection nvarchar(20) = 'Ascending'
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets all DebugLog data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0
IF (@SortColumn = '') SET @SortColumn='DebugLogID'

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

IF (@SortDirection = 'Random')
BEGIN
	SELECT
		  DebugLog1.[DebugLogID]
		, DebugLog1.[EventName]
		, DebugLog1.[Message]
		, DebugLog1.[ErrorNumber]
		, DebugLog1.[EventTypeCode]
		, DebugLog1.[SeverityLevelCode]
		, DebugLog1.[CreatedByUserID]
		, DebugLog1.[CreatedDate]
		, DebugLog1.[LastModifiedByUserID]
		, DebugLog1.[LastModifiedDate]
		, DebugLog1.[Timestamp]
		, EventType1.[EventTypeName]
		, SeverityLevel1.[SeverityLevelName]
	FROM
	      [dbo].[tblCore_DebugLog] DebugLog1
	INNER JOIN [dbo].[tlkpCore_EventType] EventType1 ON EventType1.[EventTypeCode]=DebugLog1.[EventTypeCode]
	INNER JOIN [dbo].[tlkpCore_SeverityLevel] SeverityLevel1 ON SeverityLevel1.[SeverityLevelCode]=DebugLog1.[SeverityLevelCode]

	ORDER BY NewID()
END
ELSE
BEGIN
	SELECT
		  DebugLog1.[DebugLogID]
		, DebugLog1.[EventName]
		, DebugLog1.[Message]
		, DebugLog1.[ErrorNumber]
		, DebugLog1.[EventTypeCode]
		, DebugLog1.[SeverityLevelCode]
		, DebugLog1.[CreatedByUserID]
		, DebugLog1.[CreatedDate]
		, DebugLog1.[LastModifiedByUserID]
		, DebugLog1.[LastModifiedDate]
		, DebugLog1.[Timestamp]
		, EventType1.[EventTypeName]
		, SeverityLevel1.[SeverityLevelName]
	FROM
	      [dbo].[tblCore_DebugLog] DebugLog1
	INNER JOIN [dbo].[tlkpCore_EventType] EventType1 ON EventType1.[EventTypeCode]=DebugLog1.[EventTypeCode]
	INNER JOIN [dbo].[tlkpCore_SeverityLevel] SeverityLevel1 ON SeverityLevel1.[SeverityLevelCode]=DebugLog1.[SeverityLevelCode]

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'DebugLogID' THEN DebugLog1.[DebugLogID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'DebugLogID' THEN DebugLog1.[DebugLogID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'EventName' THEN DebugLog1.[EventName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'EventName' THEN DebugLog1.[EventName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Message' THEN DebugLog1.[Message] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Message' THEN DebugLog1.[Message] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'ErrorNumber' THEN DebugLog1.[ErrorNumber] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'ErrorNumber' THEN DebugLog1.[ErrorNumber] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'EventTypeCode' THEN DebugLog1.[EventTypeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'EventTypeCode' THEN DebugLog1.[EventTypeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'SeverityLevelCode' THEN DebugLog1.[SeverityLevelCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'SeverityLevelCode' THEN DebugLog1.[SeverityLevelCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN DebugLog1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN DebugLog1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN DebugLog1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN DebugLog1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN DebugLog1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN DebugLog1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN DebugLog1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN DebugLog1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN DebugLog1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN DebugLog1.[Timestamp] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'EventTypeName' THEN EventType1.[EventTypeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'EventTypeName' THEN EventType1.[EventTypeName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'SeverityLevelName' THEN SeverityLevel1.[SeverityLevelName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'SeverityLevelName' THEN SeverityLevel1.[SeverityLevelName] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END


RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_GetAllDebugLogDataByCriteria
	  @SqlErrorNumber int = 0 OUTPUT
	, @SortColumn sysname = 'EventName'
	, @SortDirection nvarchar(20) = 'Ascending'
	, @EventName nvarchar(255) = NULL
	, @ErrorNumber int = NULL
	, @EventTypeCode int
	, @SeverityLevelCode int
	, @LastModifiedDateStart datetime = getdate
	, @LastModifiedDateEnd datetime = getdate
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets all DebugLog data by criteria.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0
IF (@SortColumn = '') SET @SortColumn='EventName'

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

IF (@SortDirection = 'Random')
BEGIN
	SELECT
		  DebugLog1.[DebugLogID]
		, DebugLog1.[EventName]
		, DebugLog1.[Message]
		, DebugLog1.[ErrorNumber]
		, DebugLog1.[EventTypeCode]
		, DebugLog1.[SeverityLevelCode]
		, DebugLog1.[CreatedByUserID]
		, DebugLog1.[CreatedDate]
		, DebugLog1.[LastModifiedByUserID]
		, DebugLog1.[LastModifiedDate]
		, DebugLog1.[Timestamp]
		, EventType1.[EventTypeName]
		, SeverityLevel1.[SeverityLevelName]
	FROM
	      [dbo].[tblCore_DebugLog] DebugLog1
	INNER JOIN [dbo].[tlkpCore_EventType] EventType1 ON EventType1.[EventTypeCode]=DebugLog1.[EventTypeCode]
	INNER JOIN [dbo].[tlkpCore_SeverityLevel] SeverityLevel1 ON SeverityLevel1.[SeverityLevelCode]=DebugLog1.[SeverityLevelCode]
	WHERE 
		(@EventName IS NULL OR DebugLog1.[EventName] like '%' + @EventName + '%')
		AND (@ErrorNumber IS NULL OR DebugLog1.[ErrorNumber] = @ErrorNumber)
		AND (@EventTypeCode IS NULL OR DebugLog1.[EventTypeCode] = @EventTypeCode)
		AND (@SeverityLevelCode IS NULL OR DebugLog1.[SeverityLevelCode] = @SeverityLevelCode)
		AND ((@LastModifiedDateStart  IS NULL) OR (DebugLog1.[LastModifiedDate] >=  @LastModifiedDateStart))
		AND ((@LastModifiedDateEnd  IS NULL) OR (DebugLog1.[LastModifiedDate] <=  @LastModifiedDateEnd))

	ORDER BY NewID()
END
ELSE
BEGIN
	SELECT
		  DebugLog1.[DebugLogID]
		, DebugLog1.[EventName]
		, DebugLog1.[Message]
		, DebugLog1.[ErrorNumber]
		, DebugLog1.[EventTypeCode]
		, DebugLog1.[SeverityLevelCode]
		, DebugLog1.[CreatedByUserID]
		, DebugLog1.[CreatedDate]
		, DebugLog1.[LastModifiedByUserID]
		, DebugLog1.[LastModifiedDate]
		, DebugLog1.[Timestamp]
		, EventType1.[EventTypeName]
		, SeverityLevel1.[SeverityLevelName]
	FROM
	      [dbo].[tblCore_DebugLog] DebugLog1
	INNER JOIN [dbo].[tlkpCore_EventType] EventType1 ON EventType1.[EventTypeCode]=DebugLog1.[EventTypeCode]
	INNER JOIN [dbo].[tlkpCore_SeverityLevel] SeverityLevel1 ON SeverityLevel1.[SeverityLevelCode]=DebugLog1.[SeverityLevelCode]
	WHERE 
		(@EventName IS NULL OR DebugLog1.[EventName] like '%' + @EventName + '%')
		AND (@ErrorNumber IS NULL OR DebugLog1.[ErrorNumber] = @ErrorNumber)
		AND (@EventTypeCode IS NULL OR DebugLog1.[EventTypeCode] = @EventTypeCode)
		AND (@SeverityLevelCode IS NULL OR DebugLog1.[SeverityLevelCode] = @SeverityLevelCode)
		AND ((@LastModifiedDateStart  IS NULL) OR (DebugLog1.[LastModifiedDate] >=  @LastModifiedDateStart))
		AND ((@LastModifiedDateEnd  IS NULL) OR (DebugLog1.[LastModifiedDate] <=  @LastModifiedDateEnd))

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'DebugLogID' THEN DebugLog1.[DebugLogID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'DebugLogID' THEN DebugLog1.[DebugLogID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'EventName' THEN DebugLog1.[EventName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'EventName' THEN DebugLog1.[EventName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Message' THEN DebugLog1.[Message] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Message' THEN DebugLog1.[Message] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'ErrorNumber' THEN DebugLog1.[ErrorNumber] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'ErrorNumber' THEN DebugLog1.[ErrorNumber] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'EventTypeCode' THEN DebugLog1.[EventTypeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'EventTypeCode' THEN DebugLog1.[EventTypeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'SeverityLevelCode' THEN DebugLog1.[SeverityLevelCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'SeverityLevelCode' THEN DebugLog1.[SeverityLevelCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN DebugLog1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN DebugLog1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN DebugLog1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN DebugLog1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN DebugLog1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN DebugLog1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN DebugLog1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN DebugLog1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN DebugLog1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN DebugLog1.[Timestamp] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'EventTypeName' THEN EventType1.[EventTypeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'EventTypeName' THEN EventType1.[EventTypeName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'SeverityLevelName' THEN SeverityLevel1.[SeverityLevelName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'SeverityLevelName' THEN SeverityLevel1.[SeverityLevelName] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END


RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_GetAllDebugLogDataByEventTypeCode
	  @SqlErrorNumber int = 0 OUTPUT
	, @SortColumn sysname = 'EventTypeCode'
	, @SortDirection nvarchar(20) = 'Ascending'
	, @EventTypeCode int
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets all DebugLog data by a key.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0
IF (@SortColumn = '') SET @SortColumn='EventTypeCode'

/*
** parameter validation
*/
IF (@EventTypeCode IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

IF (@SortDirection = 'Random')
BEGIN
	SELECT
		  DebugLog1.[DebugLogID]
		, DebugLog1.[EventName]
		, DebugLog1.[Message]
		, DebugLog1.[ErrorNumber]
		, DebugLog1.[EventTypeCode]
		, DebugLog1.[SeverityLevelCode]
		, DebugLog1.[CreatedByUserID]
		, DebugLog1.[CreatedDate]
		, DebugLog1.[LastModifiedByUserID]
		, DebugLog1.[LastModifiedDate]
		, DebugLog1.[Timestamp]
		, EventType1.[EventTypeName]
		, SeverityLevel1.[SeverityLevelName]
	FROM
	      [dbo].[tblCore_DebugLog] DebugLog1
	INNER JOIN [dbo].[tlkpCore_EventType] EventType1 ON EventType1.[EventTypeCode]=DebugLog1.[EventTypeCode]
	INNER JOIN [dbo].[tlkpCore_SeverityLevel] SeverityLevel1 ON SeverityLevel1.[SeverityLevelCode]=DebugLog1.[SeverityLevelCode]
	WHERE 
		DebugLog1.[EventTypeCode] = @EventTypeCode

	ORDER BY NewID()
END
ELSE
BEGIN
	SELECT
		  DebugLog1.[DebugLogID]
		, DebugLog1.[EventName]
		, DebugLog1.[Message]
		, DebugLog1.[ErrorNumber]
		, DebugLog1.[EventTypeCode]
		, DebugLog1.[SeverityLevelCode]
		, DebugLog1.[CreatedByUserID]
		, DebugLog1.[CreatedDate]
		, DebugLog1.[LastModifiedByUserID]
		, DebugLog1.[LastModifiedDate]
		, DebugLog1.[Timestamp]
		, EventType1.[EventTypeName]
		, SeverityLevel1.[SeverityLevelName]
	FROM
	      [dbo].[tblCore_DebugLog] DebugLog1
	INNER JOIN [dbo].[tlkpCore_EventType] EventType1 ON EventType1.[EventTypeCode]=DebugLog1.[EventTypeCode]
	INNER JOIN [dbo].[tlkpCore_SeverityLevel] SeverityLevel1 ON SeverityLevel1.[SeverityLevelCode]=DebugLog1.[SeverityLevelCode]
	WHERE 
		DebugLog1.[EventTypeCode] = @EventTypeCode

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'DebugLogID' THEN DebugLog1.[DebugLogID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'DebugLogID' THEN DebugLog1.[DebugLogID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'EventName' THEN DebugLog1.[EventName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'EventName' THEN DebugLog1.[EventName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Message' THEN DebugLog1.[Message] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Message' THEN DebugLog1.[Message] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'ErrorNumber' THEN DebugLog1.[ErrorNumber] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'ErrorNumber' THEN DebugLog1.[ErrorNumber] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'EventTypeCode' THEN DebugLog1.[EventTypeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'EventTypeCode' THEN DebugLog1.[EventTypeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'SeverityLevelCode' THEN DebugLog1.[SeverityLevelCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'SeverityLevelCode' THEN DebugLog1.[SeverityLevelCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN DebugLog1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN DebugLog1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN DebugLog1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN DebugLog1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN DebugLog1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN DebugLog1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN DebugLog1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN DebugLog1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN DebugLog1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN DebugLog1.[Timestamp] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'EventTypeName' THEN EventType1.[EventTypeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'EventTypeName' THEN EventType1.[EventTypeName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'SeverityLevelName' THEN SeverityLevel1.[SeverityLevelName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'SeverityLevelName' THEN SeverityLevel1.[SeverityLevelName] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END


RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_GetAllDebugLogDataBySeverityLevelCode
	  @SqlErrorNumber int = 0 OUTPUT
	, @SortColumn sysname = 'SeverityLevelCode'
	, @SortDirection nvarchar(20) = 'Ascending'
	, @SeverityLevelCode int
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets all DebugLog data by a key.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0
IF (@SortColumn = '') SET @SortColumn='SeverityLevelCode'

/*
** parameter validation
*/
IF (@SeverityLevelCode IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

IF (@SortDirection = 'Random')
BEGIN
	SELECT
		  DebugLog1.[DebugLogID]
		, DebugLog1.[EventName]
		, DebugLog1.[Message]
		, DebugLog1.[ErrorNumber]
		, DebugLog1.[EventTypeCode]
		, DebugLog1.[SeverityLevelCode]
		, DebugLog1.[CreatedByUserID]
		, DebugLog1.[CreatedDate]
		, DebugLog1.[LastModifiedByUserID]
		, DebugLog1.[LastModifiedDate]
		, DebugLog1.[Timestamp]
		, EventType1.[EventTypeName]
		, SeverityLevel1.[SeverityLevelName]
	FROM
	      [dbo].[tblCore_DebugLog] DebugLog1
	INNER JOIN [dbo].[tlkpCore_EventType] EventType1 ON EventType1.[EventTypeCode]=DebugLog1.[EventTypeCode]
	INNER JOIN [dbo].[tlkpCore_SeverityLevel] SeverityLevel1 ON SeverityLevel1.[SeverityLevelCode]=DebugLog1.[SeverityLevelCode]
	WHERE 
		DebugLog1.[SeverityLevelCode] = @SeverityLevelCode

	ORDER BY NewID()
END
ELSE
BEGIN
	SELECT
		  DebugLog1.[DebugLogID]
		, DebugLog1.[EventName]
		, DebugLog1.[Message]
		, DebugLog1.[ErrorNumber]
		, DebugLog1.[EventTypeCode]
		, DebugLog1.[SeverityLevelCode]
		, DebugLog1.[CreatedByUserID]
		, DebugLog1.[CreatedDate]
		, DebugLog1.[LastModifiedByUserID]
		, DebugLog1.[LastModifiedDate]
		, DebugLog1.[Timestamp]
		, EventType1.[EventTypeName]
		, SeverityLevel1.[SeverityLevelName]
	FROM
	      [dbo].[tblCore_DebugLog] DebugLog1
	INNER JOIN [dbo].[tlkpCore_EventType] EventType1 ON EventType1.[EventTypeCode]=DebugLog1.[EventTypeCode]
	INNER JOIN [dbo].[tlkpCore_SeverityLevel] SeverityLevel1 ON SeverityLevel1.[SeverityLevelCode]=DebugLog1.[SeverityLevelCode]
	WHERE 
		DebugLog1.[SeverityLevelCode] = @SeverityLevelCode

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'DebugLogID' THEN DebugLog1.[DebugLogID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'DebugLogID' THEN DebugLog1.[DebugLogID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'EventName' THEN DebugLog1.[EventName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'EventName' THEN DebugLog1.[EventName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Message' THEN DebugLog1.[Message] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Message' THEN DebugLog1.[Message] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'ErrorNumber' THEN DebugLog1.[ErrorNumber] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'ErrorNumber' THEN DebugLog1.[ErrorNumber] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'EventTypeCode' THEN DebugLog1.[EventTypeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'EventTypeCode' THEN DebugLog1.[EventTypeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'SeverityLevelCode' THEN DebugLog1.[SeverityLevelCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'SeverityLevelCode' THEN DebugLog1.[SeverityLevelCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN DebugLog1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN DebugLog1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN DebugLog1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN DebugLog1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN DebugLog1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN DebugLog1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN DebugLog1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN DebugLog1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN DebugLog1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN DebugLog1.[Timestamp] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'EventTypeName' THEN EventType1.[EventTypeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'EventTypeName' THEN EventType1.[EventTypeName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'SeverityLevelName' THEN SeverityLevel1.[SeverityLevelName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'SeverityLevelName' THEN SeverityLevel1.[SeverityLevelName] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END


RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_GetAllErrorData
	  @SqlErrorNumber int = 0 OUTPUT
	, @SortColumn sysname = 'ErrorNumber'
	, @SortDirection nvarchar(20) = 'Ascending'
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets all Error data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0
IF (@SortColumn = '') SET @SortColumn='ErrorNumber'

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

IF (@SortDirection = 'Random')
BEGIN
	SELECT
		  Error1.[ErrorNumber]
		, Error1.[ErrorTitle]
		, Error1.[ErrorMessage]
		, Error1.[CreatedByUserID]
		, Error1.[CreatedDate]
		, Error1.[LastModifiedByUserID]
		, Error1.[LastModifiedDate]
		, Error1.[Timestamp]
	FROM
	      [dbo].[tlkpCore_Error] Error1

	ORDER BY NewID()
END
ELSE
BEGIN
	SELECT
		  Error1.[ErrorNumber]
		, Error1.[ErrorTitle]
		, Error1.[ErrorMessage]
		, Error1.[CreatedByUserID]
		, Error1.[CreatedDate]
		, Error1.[LastModifiedByUserID]
		, Error1.[LastModifiedDate]
		, Error1.[Timestamp]
	FROM
	      [dbo].[tlkpCore_Error] Error1

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'ErrorNumber' THEN Error1.[ErrorNumber] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'ErrorNumber' THEN Error1.[ErrorNumber] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'ErrorTitle' THEN Error1.[ErrorTitle] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'ErrorTitle' THEN Error1.[ErrorTitle] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'ErrorMessage' THEN Error1.[ErrorMessage] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'ErrorMessage' THEN Error1.[ErrorMessage] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN Error1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN Error1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN Error1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN Error1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN Error1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN Error1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN Error1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN Error1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN Error1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN Error1.[Timestamp] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END


RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_GetAllEventTypeData
	  @SqlErrorNumber int = 0 OUTPUT
	, @SortColumn sysname = 'EventTypeCode'
	, @SortDirection nvarchar(20) = 'Ascending'
	, @IncludeInactive bit = 0
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets all EventType data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0
IF (@SortColumn = '') SET @SortColumn='EventTypeCode'

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

IF (@SortDirection = 'Random')
BEGIN
	SELECT
		  EventType1.[EventTypeCode]
		, EventType1.[EventTypeName]
		, EventType1.[Description]
		, EventType1.[IsActive]
		, EventType1.[CreatedByUserID]
		, EventType1.[CreatedDate]
		, EventType1.[LastModifiedByUserID]
		, EventType1.[LastModifiedDate]
		, EventType1.[Timestamp]
	FROM
	      [dbo].[tlkpCore_EventType] EventType1
	WHERE 
		EventType1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN EventType1.[IsActive] ELSE 1 END

	ORDER BY NewID()
END
ELSE
BEGIN
	SELECT
		  EventType1.[EventTypeCode]
		, EventType1.[EventTypeName]
		, EventType1.[Description]
		, EventType1.[IsActive]
		, EventType1.[CreatedByUserID]
		, EventType1.[CreatedDate]
		, EventType1.[LastModifiedByUserID]
		, EventType1.[LastModifiedDate]
		, EventType1.[Timestamp]
	FROM
	      [dbo].[tlkpCore_EventType] EventType1
	WHERE 
		EventType1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN EventType1.[IsActive] ELSE 1 END

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'EventTypeCode' THEN EventType1.[EventTypeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'EventTypeCode' THEN EventType1.[EventTypeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'EventTypeName' THEN EventType1.[EventTypeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'EventTypeName' THEN EventType1.[EventTypeName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Description' THEN EventType1.[Description] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Description' THEN EventType1.[Description] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'IsActive' THEN EventType1.[IsActive] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'IsActive' THEN EventType1.[IsActive] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN EventType1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN EventType1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN EventType1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN EventType1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN EventType1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN EventType1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN EventType1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN EventType1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN EventType1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN EventType1.[Timestamp] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END


RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_GetAllSeverityLevelData
	  @SqlErrorNumber int = 0 OUTPUT
	, @SortColumn sysname = 'SeverityLevelCode'
	, @SortDirection nvarchar(20) = 'Ascending'
	, @IncludeInactive bit = 0
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets all SeverityLevel data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0
IF (@SortColumn = '') SET @SortColumn='SeverityLevelCode'

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

IF (@SortDirection = 'Random')
BEGIN
	SELECT
		  SeverityLevel1.[SeverityLevelCode]
		, SeverityLevel1.[SeverityLevelName]
		, SeverityLevel1.[Description]
		, SeverityLevel1.[IsActive]
		, SeverityLevel1.[CreatedByUserID]
		, SeverityLevel1.[CreatedDate]
		, SeverityLevel1.[LastModifiedByUserID]
		, SeverityLevel1.[LastModifiedDate]
		, SeverityLevel1.[Timestamp]
	FROM
	      [dbo].[tlkpCore_SeverityLevel] SeverityLevel1
	WHERE 
		SeverityLevel1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN SeverityLevel1.[IsActive] ELSE 1 END

	ORDER BY NewID()
END
ELSE
BEGIN
	SELECT
		  SeverityLevel1.[SeverityLevelCode]
		, SeverityLevel1.[SeverityLevelName]
		, SeverityLevel1.[Description]
		, SeverityLevel1.[IsActive]
		, SeverityLevel1.[CreatedByUserID]
		, SeverityLevel1.[CreatedDate]
		, SeverityLevel1.[LastModifiedByUserID]
		, SeverityLevel1.[LastModifiedDate]
		, SeverityLevel1.[Timestamp]
	FROM
	      [dbo].[tlkpCore_SeverityLevel] SeverityLevel1
	WHERE 
		SeverityLevel1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN SeverityLevel1.[IsActive] ELSE 1 END

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'SeverityLevelCode' THEN SeverityLevel1.[SeverityLevelCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'SeverityLevelCode' THEN SeverityLevel1.[SeverityLevelCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'SeverityLevelName' THEN SeverityLevel1.[SeverityLevelName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'SeverityLevelName' THEN SeverityLevel1.[SeverityLevelName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Description' THEN SeverityLevel1.[Description] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Description' THEN SeverityLevel1.[Description] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'IsActive' THEN SeverityLevel1.[IsActive] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'IsActive' THEN SeverityLevel1.[IsActive] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN SeverityLevel1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN SeverityLevel1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN SeverityLevel1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN SeverityLevel1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN SeverityLevel1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN SeverityLevel1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN SeverityLevel1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN SeverityLevel1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN SeverityLevel1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN SeverityLevel1.[Timestamp] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END


RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_GetManyBaseAttributeDataByCriteria
	  @SqlErrorNumber int = 0 OUTPUT
	, @StartIndex int = 1
	, @PageSize int = 50
	, @MaximumListSize int = 0
	, @MaximumListSizeExceeded bit = 0 OUTPUT
	, @TotalRecords int = 0 OUTPUT
	, @SortColumn sysname = 'AttributeName'
	, @SortDirection nvarchar(20) = 'Ascending'
	, @IncludeInactive bit = 0
	, @AttributeName nvarchar(100)
	, @AttributeTypeCode int
	, @DataTypeCode int
	, @LastModifiedDateStart datetime = getdate
	, @LastModifiedDateEnd datetime = getdate
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets many BaseAttribute data by criteria.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

DECLARE @vEndIndex int
IF (@StartIndex < 1) SET @StartIndex=1
IF (@PageSize < 1) SET @PageSize=1
SET @vEndIndex = @StartIndex + @Pagesize
IF (@SortColumn = '') SET @SortColumn='AttributeName'

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

DECLARE @OrderedRecords TABLE
(
     SearchOrderID int IDENTITY (1, 1) NOT NULL
    , BaseAttributeID uniqueidentifier
)
IF (@SortDirection = 'Random')
BEGIN
	INSERT INTO @OrderedRecords (BaseAttributeID)
	SELECT
		  BaseAttribute1.[BaseAttributeID]
	FROM
	      [dbo].[tblCore_BaseAttribute] BaseAttribute1
	INNER JOIN [dbo].[tlkpCore_AttributeType] AttributeType1 ON AttributeType1.[AttributeTypeCode]=BaseAttribute1.[AttributeTypeCode]
	INNER JOIN [dbo].[tlkpCore_DataType] DataType1 ON DataType1.[DataTypeCode]=BaseAttribute1.[DataTypeCode]
	WHERE 
		BaseAttribute1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN BaseAttribute1.[IsActive] ELSE 1 END
		AND (@AttributeName IS NULL OR BaseAttribute1.[AttributeName] like '%' + @AttributeName + '%')
		AND (@AttributeTypeCode IS NULL OR BaseAttribute1.[AttributeTypeCode] = @AttributeTypeCode)
		AND (@DataTypeCode IS NULL OR BaseAttribute1.[DataTypeCode] = @DataTypeCode)
		AND ((@LastModifiedDateStart  IS NULL) OR (BaseAttribute1.[LastModifiedDate] >=  @LastModifiedDateStart))
		AND ((@LastModifiedDateEnd  IS NULL) OR (BaseAttribute1.[LastModifiedDate] <=  @LastModifiedDateEnd))

	ORDER BY NewID()
END
ELSE
BEGIN
	INSERT INTO @OrderedRecords (BaseAttributeID)
	SELECT
		  BaseAttribute1.[BaseAttributeID]
	FROM
	      [dbo].[tblCore_BaseAttribute] BaseAttribute1
	INNER JOIN [dbo].[tlkpCore_AttributeType] AttributeType1 ON AttributeType1.[AttributeTypeCode]=BaseAttribute1.[AttributeTypeCode]
	INNER JOIN [dbo].[tlkpCore_DataType] DataType1 ON DataType1.[DataTypeCode]=BaseAttribute1.[DataTypeCode]
	WHERE 
		BaseAttribute1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN BaseAttribute1.[IsActive] ELSE 1 END
		AND (@AttributeName IS NULL OR BaseAttribute1.[AttributeName] like '%' + @AttributeName + '%')
		AND (@AttributeTypeCode IS NULL OR BaseAttribute1.[AttributeTypeCode] = @AttributeTypeCode)
		AND (@DataTypeCode IS NULL OR BaseAttribute1.[DataTypeCode] = @DataTypeCode)
		AND ((@LastModifiedDateStart  IS NULL) OR (BaseAttribute1.[LastModifiedDate] >=  @LastModifiedDateStart))
		AND ((@LastModifiedDateEnd  IS NULL) OR (BaseAttribute1.[LastModifiedDate] <=  @LastModifiedDateEnd))

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'BaseAttributeID' THEN BaseAttribute1.[BaseAttributeID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'BaseAttributeID' THEN BaseAttribute1.[BaseAttributeID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeName' THEN BaseAttribute1.[AttributeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeName' THEN BaseAttribute1.[AttributeName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeTypeCode' THEN BaseAttribute1.[AttributeTypeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeTypeCode' THEN BaseAttribute1.[AttributeTypeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'DataTypeCode' THEN BaseAttribute1.[DataTypeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'DataTypeCode' THEN BaseAttribute1.[DataTypeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Description' THEN BaseAttribute1.[Description] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Description' THEN BaseAttribute1.[Description] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'IsActive' THEN BaseAttribute1.[IsActive] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'IsActive' THEN BaseAttribute1.[IsActive] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN BaseAttribute1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN BaseAttribute1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN BaseAttribute1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN BaseAttribute1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN BaseAttribute1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN BaseAttribute1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN BaseAttribute1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN BaseAttribute1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN BaseAttribute1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN BaseAttribute1.[Timestamp] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeTypeName' THEN AttributeType1.[AttributeTypeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeTypeName' THEN AttributeType1.[AttributeTypeName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'DataTypeName' THEN DataType1.[DataTypeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'DataTypeName' THEN DataType1.[DataTypeName] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END

BEGIN
	SET @TotalRecords = (SELECT Count (*) FROM @OrderedRecords)
	IF @MaximumListSize > 0
	BEGIN
		IF @TotalRecords > @MaximumListSize
		BEGIN
			SET @MaximumListSizeExceeded = 1
			SET @TotalRecords = @MaximumListSize
		END
	END

	/* get search results */
	SELECT
		  BaseAttribute1.[BaseAttributeID]
		, BaseAttribute1.[AttributeName]
		, BaseAttribute1.[AttributeTypeCode]
		, BaseAttribute1.[DataTypeCode]
		, BaseAttribute1.[Description]
		, BaseAttribute1.[IsActive]
		, BaseAttribute1.[CreatedByUserID]
		, BaseAttribute1.[CreatedDate]
		, BaseAttribute1.[LastModifiedByUserID]
		, BaseAttribute1.[LastModifiedDate]
		, BaseAttribute1.[Timestamp]
		, AttributeType1.[AttributeTypeName]
		, DataType1.[DataTypeName]
	FROM
	      [dbo].[tblCore_BaseAttribute] BaseAttribute1
	INNER JOIN [dbo].[tlkpCore_AttributeType] AttributeType1 ON AttributeType1.[AttributeTypeCode]=BaseAttribute1.[AttributeTypeCode]
	INNER JOIN [dbo].[tlkpCore_DataType] DataType1 ON DataType1.[DataTypeCode]=BaseAttribute1.[DataTypeCode]
	INNER JOIN @OrderedRecords search ON search.[BaseAttributeID] = BaseAttribute1.[BaseAttributeID]
	WHERE
		search.SearchOrderID  >= @StartIndex AND
		search.SearchOrderID  < @vEndIndex
	ORDER BY
		search.SearchOrderID

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_GetManyDebugAttributeDataByCriteria
	  @SqlErrorNumber int = 0 OUTPUT
	, @StartIndex int = 1
	, @PageSize int = 50
	, @MaximumListSize int = 0
	, @MaximumListSizeExceeded bit = 0 OUTPUT
	, @TotalRecords int = 0 OUTPUT
	, @SortColumn sysname = 'AttributeName'
	, @SortDirection nvarchar(20) = 'Ascending'
	, @IncludeInactive bit = 0
	, @AttributeName nvarchar(100)
	, @AttributeTypeCode int
	, @DataTypeCode int
	, @LastModifiedDateStart datetime = getdate
	, @LastModifiedDateEnd datetime = getdate
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets many DebugAttribute data by criteria.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

DECLARE @vEndIndex int
IF (@StartIndex < 1) SET @StartIndex=1
IF (@PageSize < 1) SET @PageSize=1
SET @vEndIndex = @StartIndex + @Pagesize
IF (@SortColumn = '') SET @SortColumn='AttributeName'

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

DECLARE @OrderedRecords TABLE
(
     SearchOrderID int IDENTITY (1, 1) NOT NULL
    , BaseAttributeID uniqueidentifier
)
IF (@SortDirection = 'Random')
BEGIN
	INSERT INTO @OrderedRecords (BaseAttributeID)
	SELECT
		  DebugAttribute1.[BaseAttributeID]
	FROM
	      [dbo].[tblCore_DebugAttribute] DebugAttribute1
	INNER JOIN [dbo].[tblCore_BaseAttribute] BaseAttribute1 ON BaseAttribute1.[BaseAttributeID]=DebugAttribute1.[BaseAttributeID]
	INNER JOIN [dbo].[tlkpCore_AttributeType] AttributeType1 ON AttributeType1.[AttributeTypeCode]=BaseAttribute1.[AttributeTypeCode]
	INNER JOIN [dbo].[tlkpCore_DataType] DataType1 ON DataType1.[DataTypeCode]=BaseAttribute1.[DataTypeCode]
	WHERE 
		BaseAttribute1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN BaseAttribute1.[IsActive] ELSE 1 END
		AND (@AttributeName IS NULL OR BaseAttribute1.[AttributeName] like '%' + @AttributeName + '%')
		AND (@AttributeTypeCode IS NULL OR BaseAttribute1.[AttributeTypeCode] = @AttributeTypeCode)
		AND (@DataTypeCode IS NULL OR BaseAttribute1.[DataTypeCode] = @DataTypeCode)
		AND ((@LastModifiedDateStart  IS NULL) OR (BaseAttribute1.[LastModifiedDate] >=  @LastModifiedDateStart))
		AND ((@LastModifiedDateEnd  IS NULL) OR (BaseAttribute1.[LastModifiedDate] <=  @LastModifiedDateEnd))

	ORDER BY NewID()
END
ELSE
BEGIN
	INSERT INTO @OrderedRecords (BaseAttributeID)
	SELECT
		  DebugAttribute1.[BaseAttributeID]
	FROM
	      [dbo].[tblCore_DebugAttribute] DebugAttribute1
	INNER JOIN [dbo].[tblCore_BaseAttribute] BaseAttribute1 ON BaseAttribute1.[BaseAttributeID]=DebugAttribute1.[BaseAttributeID]
	INNER JOIN [dbo].[tlkpCore_AttributeType] AttributeType1 ON AttributeType1.[AttributeTypeCode]=BaseAttribute1.[AttributeTypeCode]
	INNER JOIN [dbo].[tlkpCore_DataType] DataType1 ON DataType1.[DataTypeCode]=BaseAttribute1.[DataTypeCode]
	WHERE 
		BaseAttribute1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN BaseAttribute1.[IsActive] ELSE 1 END
		AND (@AttributeName IS NULL OR BaseAttribute1.[AttributeName] like '%' + @AttributeName + '%')
		AND (@AttributeTypeCode IS NULL OR BaseAttribute1.[AttributeTypeCode] = @AttributeTypeCode)
		AND (@DataTypeCode IS NULL OR BaseAttribute1.[DataTypeCode] = @DataTypeCode)
		AND ((@LastModifiedDateStart  IS NULL) OR (BaseAttribute1.[LastModifiedDate] >=  @LastModifiedDateStart))
		AND ((@LastModifiedDateEnd  IS NULL) OR (BaseAttribute1.[LastModifiedDate] <=  @LastModifiedDateEnd))

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'BaseAttributeID' THEN DebugAttribute1.[BaseAttributeID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'BaseAttributeID' THEN DebugAttribute1.[BaseAttributeID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeCode' THEN DebugAttribute1.[AttributeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeCode' THEN DebugAttribute1.[AttributeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN DebugAttribute1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN DebugAttribute1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN DebugAttribute1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN DebugAttribute1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN DebugAttribute1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN DebugAttribute1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN DebugAttribute1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN DebugAttribute1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN DebugAttribute1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN DebugAttribute1.[Timestamp] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeName' THEN BaseAttribute1.[AttributeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeName' THEN BaseAttribute1.[AttributeName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeTypeCode' THEN BaseAttribute1.[AttributeTypeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeTypeCode' THEN BaseAttribute1.[AttributeTypeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'DataTypeCode' THEN BaseAttribute1.[DataTypeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'DataTypeCode' THEN BaseAttribute1.[DataTypeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Description' THEN BaseAttribute1.[Description] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Description' THEN BaseAttribute1.[Description] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'IsActive' THEN BaseAttribute1.[IsActive] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'IsActive' THEN BaseAttribute1.[IsActive] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeTypeName' THEN AttributeType1.[AttributeTypeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeTypeName' THEN AttributeType1.[AttributeTypeName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'DataTypeName' THEN DataType1.[DataTypeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'DataTypeName' THEN DataType1.[DataTypeName] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END

BEGIN
	SET @TotalRecords = (SELECT Count (*) FROM @OrderedRecords)
	IF @MaximumListSize > 0
	BEGIN
		IF @TotalRecords > @MaximumListSize
		BEGIN
			SET @MaximumListSizeExceeded = 1
			SET @TotalRecords = @MaximumListSize
		END
	END

	/* get search results */
	SELECT
		  DebugAttribute1.[BaseAttributeID]
		, DebugAttribute1.[AttributeCode]
		, DebugAttribute1.[CreatedByUserID]
		, DebugAttribute1.[CreatedDate]
		, DebugAttribute1.[LastModifiedByUserID]
		, DebugAttribute1.[LastModifiedDate]
		, DebugAttribute1.[Timestamp]
		, BaseAttribute1.[AttributeName]
		, BaseAttribute1.[AttributeTypeCode]
		, BaseAttribute1.[DataTypeCode]
		, BaseAttribute1.[Description]
		, BaseAttribute1.[IsActive]
		, AttributeType1.[AttributeTypeName]
		, DataType1.[DataTypeName]
	FROM
	      [dbo].[tblCore_DebugAttribute] DebugAttribute1
	INNER JOIN [dbo].[tblCore_BaseAttribute] BaseAttribute1 ON BaseAttribute1.[BaseAttributeID]=DebugAttribute1.[BaseAttributeID]
	INNER JOIN [dbo].[tlkpCore_AttributeType] AttributeType1 ON AttributeType1.[AttributeTypeCode]=BaseAttribute1.[AttributeTypeCode]
	INNER JOIN [dbo].[tlkpCore_DataType] DataType1 ON DataType1.[DataTypeCode]=BaseAttribute1.[DataTypeCode]
	INNER JOIN @OrderedRecords search ON search.[BaseAttributeID] = DebugAttribute1.[BaseAttributeID]
	WHERE
		search.SearchOrderID  >= @StartIndex AND
		search.SearchOrderID  < @vEndIndex
	ORDER BY
		search.SearchOrderID

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_GetManyDebugAttributeValueLogDataByCriteria
	  @SqlErrorNumber int = 0 OUTPUT
	, @StartIndex int = 1
	, @PageSize int = 50
	, @MaximumListSize int = 0
	, @MaximumListSizeExceeded bit = 0 OUTPUT
	, @TotalRecords int = 0 OUTPUT
	, @SortColumn sysname = 'AttributeValue'
	, @SortDirection nvarchar(20) = 'Ascending'
	, @AttributeValue nvarchar(1000)
	, @LastModifiedDateStart datetime = getdate
	, @LastModifiedDateEnd datetime = getdate
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets many DebugAttributeValueLog data by criteria.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

DECLARE @vEndIndex int
IF (@StartIndex < 1) SET @StartIndex=1
IF (@PageSize < 1) SET @PageSize=1
SET @vEndIndex = @StartIndex + @Pagesize
IF (@SortColumn = '') SET @SortColumn='AttributeValue'

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

DECLARE @OrderedRecords TABLE
(
     SearchOrderID int IDENTITY (1, 1) NOT NULL
    , DebugAttributeValueLogID uniqueidentifier
)
IF (@SortDirection = 'Random')
BEGIN
	INSERT INTO @OrderedRecords (DebugAttributeValueLogID)
	SELECT
		  DebugAttributeValueLog1.[DebugAttributeValueLogID]
	FROM
	      [dbo].[tblCore_DebugAttributeValueLog] DebugAttributeValueLog1
	INNER JOIN [dbo].[tblCore_DebugLog] DebugLog1 ON DebugLog1.[DebugLogID]=DebugAttributeValueLog1.[DebugLogID]
	WHERE 
		(@AttributeValue IS NULL OR DebugAttributeValueLog1.[AttributeValue] like '%' + @AttributeValue + '%')
		AND ((@LastModifiedDateStart  IS NULL) OR (DebugAttributeValueLog1.[LastModifiedDate] >=  @LastModifiedDateStart))
		AND ((@LastModifiedDateEnd  IS NULL) OR (DebugAttributeValueLog1.[LastModifiedDate] <=  @LastModifiedDateEnd))

	ORDER BY NewID()
END
ELSE
BEGIN
	INSERT INTO @OrderedRecords (DebugAttributeValueLogID)
	SELECT
		  DebugAttributeValueLog1.[DebugAttributeValueLogID]
	FROM
	      [dbo].[tblCore_DebugAttributeValueLog] DebugAttributeValueLog1
	INNER JOIN [dbo].[tblCore_DebugLog] DebugLog1 ON DebugLog1.[DebugLogID]=DebugAttributeValueLog1.[DebugLogID]
	WHERE 
		(@AttributeValue IS NULL OR DebugAttributeValueLog1.[AttributeValue] like '%' + @AttributeValue + '%')
		AND ((@LastModifiedDateStart  IS NULL) OR (DebugAttributeValueLog1.[LastModifiedDate] >=  @LastModifiedDateStart))
		AND ((@LastModifiedDateEnd  IS NULL) OR (DebugAttributeValueLog1.[LastModifiedDate] <=  @LastModifiedDateEnd))

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'DebugAttributeValueLogID' THEN DebugAttributeValueLog1.[DebugAttributeValueLogID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'DebugAttributeValueLogID' THEN DebugAttributeValueLog1.[DebugAttributeValueLogID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'DebugLogID' THEN DebugAttributeValueLog1.[DebugLogID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'DebugLogID' THEN DebugAttributeValueLog1.[DebugLogID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'BaseAttributeID' THEN DebugAttributeValueLog1.[BaseAttributeID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'BaseAttributeID' THEN DebugAttributeValueLog1.[BaseAttributeID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeValue' THEN DebugAttributeValueLog1.[AttributeValue] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeValue' THEN DebugAttributeValueLog1.[AttributeValue] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN DebugAttributeValueLog1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN DebugAttributeValueLog1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN DebugAttributeValueLog1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN DebugAttributeValueLog1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN DebugAttributeValueLog1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN DebugAttributeValueLog1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN DebugAttributeValueLog1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN DebugAttributeValueLog1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN DebugAttributeValueLog1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN DebugAttributeValueLog1.[Timestamp] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'EventName' THEN DebugLog1.[EventName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'EventName' THEN DebugLog1.[EventName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'ErrorNumber' THEN DebugLog1.[ErrorNumber] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'ErrorNumber' THEN DebugLog1.[ErrorNumber] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END

BEGIN
	SET @TotalRecords = (SELECT Count (*) FROM @OrderedRecords)
	IF @MaximumListSize > 0
	BEGIN
		IF @TotalRecords > @MaximumListSize
		BEGIN
			SET @MaximumListSizeExceeded = 1
			SET @TotalRecords = @MaximumListSize
		END
	END

	/* get search results */
	SELECT
		  DebugAttributeValueLog1.[DebugAttributeValueLogID]
		, DebugAttributeValueLog1.[DebugLogID]
		, DebugAttributeValueLog1.[BaseAttributeID]
		, DebugAttributeValueLog1.[AttributeValue]
		, DebugAttributeValueLog1.[CreatedByUserID]
		, DebugAttributeValueLog1.[CreatedDate]
		, DebugAttributeValueLog1.[LastModifiedByUserID]
		, DebugAttributeValueLog1.[LastModifiedDate]
		, DebugAttributeValueLog1.[Timestamp]
		, DebugLog1.[EventName]
		, DebugLog1.[ErrorNumber]
	FROM
	      [dbo].[tblCore_DebugAttributeValueLog] DebugAttributeValueLog1
	INNER JOIN [dbo].[tblCore_DebugLog] DebugLog1 ON DebugLog1.[DebugLogID]=DebugAttributeValueLog1.[DebugLogID]
	INNER JOIN @OrderedRecords search ON search.[DebugAttributeValueLogID] = DebugAttributeValueLog1.[DebugAttributeValueLogID]
	WHERE
		search.SearchOrderID  >= @StartIndex AND
		search.SearchOrderID  < @vEndIndex
	ORDER BY
		search.SearchOrderID

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_GetManyDebugLogDataByCriteria
	  @SqlErrorNumber int = 0 OUTPUT
	, @StartIndex int = 1
	, @PageSize int = 50
	, @MaximumListSize int = 0
	, @MaximumListSizeExceeded bit = 0 OUTPUT
	, @TotalRecords int = 0 OUTPUT
	, @SortColumn sysname = 'EventName'
	, @SortDirection nvarchar(20) = 'Ascending'
	, @EventName nvarchar(255) = NULL
	, @ErrorNumber int = NULL
	, @EventTypeCode int
	, @SeverityLevelCode int
	, @LastModifiedDateStart datetime = getdate
	, @LastModifiedDateEnd datetime = getdate
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets many DebugLog data by criteria.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

DECLARE @vEndIndex int
IF (@StartIndex < 1) SET @StartIndex=1
IF (@PageSize < 1) SET @PageSize=1
SET @vEndIndex = @StartIndex + @Pagesize
IF (@SortColumn = '') SET @SortColumn='EventName'

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

DECLARE @OrderedRecords TABLE
(
     SearchOrderID int IDENTITY (1, 1) NOT NULL
    , DebugLogID uniqueidentifier
)
IF (@SortDirection = 'Random')
BEGIN
	INSERT INTO @OrderedRecords (DebugLogID)
	SELECT
		  DebugLog1.[DebugLogID]
	FROM
	      [dbo].[tblCore_DebugLog] DebugLog1
	INNER JOIN [dbo].[tlkpCore_EventType] EventType1 ON EventType1.[EventTypeCode]=DebugLog1.[EventTypeCode]
	INNER JOIN [dbo].[tlkpCore_SeverityLevel] SeverityLevel1 ON SeverityLevel1.[SeverityLevelCode]=DebugLog1.[SeverityLevelCode]
	WHERE 
		(@EventName IS NULL OR DebugLog1.[EventName] like '%' + @EventName + '%')
		AND (@ErrorNumber IS NULL OR DebugLog1.[ErrorNumber] = @ErrorNumber)
		AND (@EventTypeCode IS NULL OR DebugLog1.[EventTypeCode] = @EventTypeCode)
		AND (@SeverityLevelCode IS NULL OR DebugLog1.[SeverityLevelCode] = @SeverityLevelCode)
		AND ((@LastModifiedDateStart  IS NULL) OR (DebugLog1.[LastModifiedDate] >=  @LastModifiedDateStart))
		AND ((@LastModifiedDateEnd  IS NULL) OR (DebugLog1.[LastModifiedDate] <=  @LastModifiedDateEnd))

	ORDER BY NewID()
END
ELSE
BEGIN
	INSERT INTO @OrderedRecords (DebugLogID)
	SELECT
		  DebugLog1.[DebugLogID]
	FROM
	      [dbo].[tblCore_DebugLog] DebugLog1
	INNER JOIN [dbo].[tlkpCore_EventType] EventType1 ON EventType1.[EventTypeCode]=DebugLog1.[EventTypeCode]
	INNER JOIN [dbo].[tlkpCore_SeverityLevel] SeverityLevel1 ON SeverityLevel1.[SeverityLevelCode]=DebugLog1.[SeverityLevelCode]
	WHERE 
		(@EventName IS NULL OR DebugLog1.[EventName] like '%' + @EventName + '%')
		AND (@ErrorNumber IS NULL OR DebugLog1.[ErrorNumber] = @ErrorNumber)
		AND (@EventTypeCode IS NULL OR DebugLog1.[EventTypeCode] = @EventTypeCode)
		AND (@SeverityLevelCode IS NULL OR DebugLog1.[SeverityLevelCode] = @SeverityLevelCode)
		AND ((@LastModifiedDateStart  IS NULL) OR (DebugLog1.[LastModifiedDate] >=  @LastModifiedDateStart))
		AND ((@LastModifiedDateEnd  IS NULL) OR (DebugLog1.[LastModifiedDate] <=  @LastModifiedDateEnd))

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'DebugLogID' THEN DebugLog1.[DebugLogID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'DebugLogID' THEN DebugLog1.[DebugLogID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'EventName' THEN DebugLog1.[EventName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'EventName' THEN DebugLog1.[EventName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Message' THEN DebugLog1.[Message] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Message' THEN DebugLog1.[Message] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'ErrorNumber' THEN DebugLog1.[ErrorNumber] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'ErrorNumber' THEN DebugLog1.[ErrorNumber] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'EventTypeCode' THEN DebugLog1.[EventTypeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'EventTypeCode' THEN DebugLog1.[EventTypeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'SeverityLevelCode' THEN DebugLog1.[SeverityLevelCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'SeverityLevelCode' THEN DebugLog1.[SeverityLevelCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN DebugLog1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN DebugLog1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN DebugLog1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN DebugLog1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN DebugLog1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN DebugLog1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN DebugLog1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN DebugLog1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN DebugLog1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN DebugLog1.[Timestamp] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'EventTypeName' THEN EventType1.[EventTypeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'EventTypeName' THEN EventType1.[EventTypeName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'SeverityLevelName' THEN SeverityLevel1.[SeverityLevelName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'SeverityLevelName' THEN SeverityLevel1.[SeverityLevelName] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END

BEGIN
	SET @TotalRecords = (SELECT Count (*) FROM @OrderedRecords)
	IF @MaximumListSize > 0
	BEGIN
		IF @TotalRecords > @MaximumListSize
		BEGIN
			SET @MaximumListSizeExceeded = 1
			SET @TotalRecords = @MaximumListSize
		END
	END

	/* get search results */
	SELECT
		  DebugLog1.[DebugLogID]
		, DebugLog1.[EventName]
		, DebugLog1.[Message]
		, DebugLog1.[ErrorNumber]
		, DebugLog1.[EventTypeCode]
		, DebugLog1.[SeverityLevelCode]
		, DebugLog1.[CreatedByUserID]
		, DebugLog1.[CreatedDate]
		, DebugLog1.[LastModifiedByUserID]
		, DebugLog1.[LastModifiedDate]
		, DebugLog1.[Timestamp]
		, EventType1.[EventTypeName]
		, SeverityLevel1.[SeverityLevelName]
	FROM
	      [dbo].[tblCore_DebugLog] DebugLog1
	INNER JOIN [dbo].[tlkpCore_EventType] EventType1 ON EventType1.[EventTypeCode]=DebugLog1.[EventTypeCode]
	INNER JOIN [dbo].[tlkpCore_SeverityLevel] SeverityLevel1 ON SeverityLevel1.[SeverityLevelCode]=DebugLog1.[SeverityLevelCode]
	INNER JOIN @OrderedRecords search ON search.[DebugLogID] = DebugLog1.[DebugLogID]
	WHERE
		search.SearchOrderID  >= @StartIndex AND
		search.SearchOrderID  < @vEndIndex
	ORDER BY
		search.SearchOrderID

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_GetOneAttributeType
	  @SqlErrorNumber int = 0 OUTPUT
	, @AttributeTypeCode int
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets a single AttributeType by an index.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@AttributeTypeCode IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	SELECT
		  AttributeType1.[AttributeTypeCode]
		, AttributeType1.[AttributeTypeName]
		, AttributeType1.[Description]
		, AttributeType1.[IsActive]
		, AttributeType1.[CreatedByUserID]
		, AttributeType1.[CreatedDate]
		, AttributeType1.[LastModifiedByUserID]
		, AttributeType1.[LastModifiedDate]
		, AttributeType1.[Timestamp]
	FROM
	      [dbo].[tlkpCore_AttributeType] AttributeType1
	WHERE AttributeType1.[AttributeTypeCode] =  @AttributeTypeCode

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_GetOneBaseAttribute
	  @SqlErrorNumber int = 0 OUTPUT
	, @BaseAttributeID uniqueidentifier
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets a single BaseAttribute by an index.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@BaseAttributeID IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	SELECT
		  BaseAttribute1.[BaseAttributeID]
		, BaseAttribute1.[AttributeName]
		, BaseAttribute1.[AttributeTypeCode]
		, BaseAttribute1.[DataTypeCode]
		, BaseAttribute1.[Description]
		, BaseAttribute1.[IsActive]
		, BaseAttribute1.[CreatedByUserID]
		, BaseAttribute1.[CreatedDate]
		, BaseAttribute1.[LastModifiedByUserID]
		, BaseAttribute1.[LastModifiedDate]
		, BaseAttribute1.[Timestamp]
		, AttributeType1.[AttributeTypeName]
		, DataType1.[DataTypeName]
	FROM
	      [dbo].[tblCore_BaseAttribute] BaseAttribute1
	INNER JOIN [dbo].[tlkpCore_AttributeType] AttributeType1 ON AttributeType1.[AttributeTypeCode]=BaseAttribute1.[AttributeTypeCode]
	INNER JOIN [dbo].[tlkpCore_DataType] DataType1 ON DataType1.[DataTypeCode]=BaseAttribute1.[DataTypeCode]
	WHERE BaseAttribute1.[BaseAttributeID] =  @BaseAttributeID

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_GetOneDataType
	  @SqlErrorNumber int = 0 OUTPUT
	, @DataTypeCode int
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets a single DataType by an index.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@DataTypeCode IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	SELECT
		  DataType1.[DataTypeCode]
		, DataType1.[DataTypeName]
		, DataType1.[Description]
		, DataType1.[IsActive]
		, DataType1.[CreatedByUserID]
		, DataType1.[CreatedDate]
		, DataType1.[LastModifiedByUserID]
		, DataType1.[LastModifiedDate]
		, DataType1.[Timestamp]
	FROM
	      [dbo].[tlkpCore_DataType] DataType1
	WHERE DataType1.[DataTypeCode] =  @DataTypeCode

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_GetOneDebugAttribute
	  @SqlErrorNumber int = 0 OUTPUT
	, @BaseAttributeID uniqueidentifier
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets a single DebugAttribute by an index.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@BaseAttributeID IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	SELECT
		  DebugAttribute1.[BaseAttributeID]
		, DebugAttribute1.[AttributeCode]
		, DebugAttribute1.[CreatedByUserID]
		, DebugAttribute1.[CreatedDate]
		, DebugAttribute1.[LastModifiedByUserID]
		, DebugAttribute1.[LastModifiedDate]
		, DebugAttribute1.[Timestamp]
		, BaseAttribute1.[AttributeName]
		, BaseAttribute1.[AttributeTypeCode]
		, BaseAttribute1.[DataTypeCode]
		, BaseAttribute1.[Description]
		, BaseAttribute1.[IsActive]
		, AttributeType1.[AttributeTypeName]
		, DataType1.[DataTypeName]
	FROM
	      [dbo].[tblCore_DebugAttribute] DebugAttribute1
	INNER JOIN [dbo].[tblCore_BaseAttribute] BaseAttribute1 ON BaseAttribute1.[BaseAttributeID]=DebugAttribute1.[BaseAttributeID]
	INNER JOIN [dbo].[tlkpCore_AttributeType] AttributeType1 ON AttributeType1.[AttributeTypeCode]=BaseAttribute1.[AttributeTypeCode]
	INNER JOIN [dbo].[tlkpCore_DataType] DataType1 ON DataType1.[DataTypeCode]=BaseAttribute1.[DataTypeCode]
	WHERE DebugAttribute1.[BaseAttributeID] =  @BaseAttributeID

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_GetOneDebugAttributeByAttributeCode
	  @SqlErrorNumber int = 0 OUTPUT
	, @AttributeCode int
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets a single DebugAttribute by an index.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@AttributeCode IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	SELECT
		  DebugAttribute1.[BaseAttributeID]
		, DebugAttribute1.[AttributeCode]
		, DebugAttribute1.[CreatedByUserID]
		, DebugAttribute1.[CreatedDate]
		, DebugAttribute1.[LastModifiedByUserID]
		, DebugAttribute1.[LastModifiedDate]
		, DebugAttribute1.[Timestamp]
		, BaseAttribute1.[AttributeName]
		, BaseAttribute1.[AttributeTypeCode]
		, BaseAttribute1.[DataTypeCode]
		, BaseAttribute1.[Description]
		, BaseAttribute1.[IsActive]
		, AttributeType1.[AttributeTypeName]
		, DataType1.[DataTypeName]
	FROM
	      [dbo].[tblCore_DebugAttribute] DebugAttribute1
	INNER JOIN [dbo].[tblCore_BaseAttribute] BaseAttribute1 ON BaseAttribute1.[BaseAttributeID]=DebugAttribute1.[BaseAttributeID]
	INNER JOIN [dbo].[tlkpCore_AttributeType] AttributeType1 ON AttributeType1.[AttributeTypeCode]=BaseAttribute1.[AttributeTypeCode]
	INNER JOIN [dbo].[tlkpCore_DataType] DataType1 ON DataType1.[DataTypeCode]=BaseAttribute1.[DataTypeCode]
	WHERE DebugAttribute1.[AttributeCode] =  @AttributeCode

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_GetOneDebugAttributeValueLog
	  @SqlErrorNumber int = 0 OUTPUT
	, @DebugAttributeValueLogID uniqueidentifier
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets a single DebugAttributeValueLog by an index.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@DebugAttributeValueLogID IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	SELECT
		  DebugAttributeValueLog1.[DebugAttributeValueLogID]
		, DebugAttributeValueLog1.[DebugLogID]
		, DebugAttributeValueLog1.[BaseAttributeID]
		, DebugAttributeValueLog1.[AttributeValue]
		, DebugAttributeValueLog1.[CreatedByUserID]
		, DebugAttributeValueLog1.[CreatedDate]
		, DebugAttributeValueLog1.[LastModifiedByUserID]
		, DebugAttributeValueLog1.[LastModifiedDate]
		, DebugAttributeValueLog1.[Timestamp]
		, DebugLog1.[EventName]
		, DebugLog1.[ErrorNumber]
	FROM
	      [dbo].[tblCore_DebugAttributeValueLog] DebugAttributeValueLog1
	INNER JOIN [dbo].[tblCore_DebugLog] DebugLog1 ON DebugLog1.[DebugLogID]=DebugAttributeValueLog1.[DebugLogID]
	WHERE DebugAttributeValueLog1.[DebugAttributeValueLogID] =  @DebugAttributeValueLogID

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_GetOneDebugAttributeValueLogByDebugAttributeValueLogID
	  @SqlErrorNumber int = 0 OUTPUT
	, @DebugAttributeValueLogID uniqueidentifier
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets a single DebugAttributeValueLog by an index.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@DebugAttributeValueLogID IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	SELECT
		  DebugAttributeValueLog1.[DebugAttributeValueLogID]
		, DebugAttributeValueLog1.[DebugLogID]
		, DebugAttributeValueLog1.[BaseAttributeID]
		, DebugAttributeValueLog1.[AttributeValue]
		, DebugAttributeValueLog1.[CreatedByUserID]
		, DebugAttributeValueLog1.[CreatedDate]
		, DebugAttributeValueLog1.[LastModifiedByUserID]
		, DebugAttributeValueLog1.[LastModifiedDate]
		, DebugAttributeValueLog1.[Timestamp]
		, DebugLog1.[EventName]
		, DebugLog1.[ErrorNumber]
	FROM
	      [dbo].[tblCore_DebugAttributeValueLog] DebugAttributeValueLog1
	INNER JOIN [dbo].[tblCore_DebugLog] DebugLog1 ON DebugLog1.[DebugLogID]=DebugAttributeValueLog1.[DebugLogID]
	WHERE DebugAttributeValueLog1.[DebugAttributeValueLogID] =  @DebugAttributeValueLogID

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_GetOneDebugLog
	  @SqlErrorNumber int = 0 OUTPUT
	, @DebugLogID uniqueidentifier
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets a single DebugLog by an index.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@DebugLogID IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	SELECT
		  DebugLog1.[DebugLogID]
		, DebugLog1.[EventName]
		, DebugLog1.[Message]
		, DebugLog1.[ErrorNumber]
		, DebugLog1.[EventTypeCode]
		, DebugLog1.[SeverityLevelCode]
		, DebugLog1.[CreatedByUserID]
		, DebugLog1.[CreatedDate]
		, DebugLog1.[LastModifiedByUserID]
		, DebugLog1.[LastModifiedDate]
		, DebugLog1.[Timestamp]
		, EventType1.[EventTypeName]
		, SeverityLevel1.[SeverityLevelName]
	FROM
	      [dbo].[tblCore_DebugLog] DebugLog1
	INNER JOIN [dbo].[tlkpCore_EventType] EventType1 ON EventType1.[EventTypeCode]=DebugLog1.[EventTypeCode]
	INNER JOIN [dbo].[tlkpCore_SeverityLevel] SeverityLevel1 ON SeverityLevel1.[SeverityLevelCode]=DebugLog1.[SeverityLevelCode]
	WHERE DebugLog1.[DebugLogID] =  @DebugLogID

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_GetOneError
	  @SqlErrorNumber int = 0 OUTPUT
	, @ErrorNumber int
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets a single Error by an index.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@ErrorNumber IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	SELECT
		  Error1.[ErrorNumber]
		, Error1.[ErrorTitle]
		, Error1.[ErrorMessage]
		, Error1.[CreatedByUserID]
		, Error1.[CreatedDate]
		, Error1.[LastModifiedByUserID]
		, Error1.[LastModifiedDate]
		, Error1.[Timestamp]
	FROM
	      [dbo].[tlkpCore_Error] Error1
	WHERE Error1.[ErrorNumber] =  @ErrorNumber

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_GetOneEventType
	  @SqlErrorNumber int = 0 OUTPUT
	, @EventTypeCode int
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets a single EventType by an index.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@EventTypeCode IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	SELECT
		  EventType1.[EventTypeCode]
		, EventType1.[EventTypeName]
		, EventType1.[Description]
		, EventType1.[IsActive]
		, EventType1.[CreatedByUserID]
		, EventType1.[CreatedDate]
		, EventType1.[LastModifiedByUserID]
		, EventType1.[LastModifiedDate]
		, EventType1.[Timestamp]
	FROM
	      [dbo].[tlkpCore_EventType] EventType1
	WHERE EventType1.[EventTypeCode] =  @EventTypeCode

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_GetOneSeverityLevel
	  @SqlErrorNumber int = 0 OUTPUT
	, @SeverityLevelCode int
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets a single SeverityLevel by an index.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@SeverityLevelCode IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	SELECT
		  SeverityLevel1.[SeverityLevelCode]
		, SeverityLevel1.[SeverityLevelName]
		, SeverityLevel1.[Description]
		, SeverityLevel1.[IsActive]
		, SeverityLevel1.[CreatedByUserID]
		, SeverityLevel1.[CreatedDate]
		, SeverityLevel1.[LastModifiedByUserID]
		, SeverityLevel1.[LastModifiedDate]
		, SeverityLevel1.[Timestamp]
	FROM
	      [dbo].[tlkpCore_SeverityLevel] SeverityLevel1
	WHERE SeverityLevel1.[SeverityLevelCode] =  @SeverityLevelCode

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_LogOneDebugAttributeValueLog
	  @SqlErrorNumber int = 0 OUTPUT
	, @CreatedByUserID uniqueidentifier = NULL
	, @Timestamp timestamp = NULL OUTPUT
	, @DebugAttributeValueLogID uniqueidentifier = NULL OUTPUT
	, @DebugLogID uniqueidentifier
	, @BaseAttributeID uniqueidentifier
	, @AttributeValue nvarchar(1000)
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure logs DebugAttributeValueLog data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@DebugLogID IS NULL OR @BaseAttributeID IS NULL OR @AttributeValue IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END
/*
** record validation
*/
IF EXISTS (SELECT [DebugAttributeValueLogID] FROM [dbo].[tblCore_DebugAttributeValueLog] WHERE [DebugAttributeValueLogID] =  @DebugAttributeValueLogID)
BEGIN
	SET @SqlErrorNumber = -1003
	GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	IF @DebugAttributeValueLogID  IS NULL
	BEGIN
		SET @DebugAttributeValueLogID  = NEWID ()
	END
	INSERT
	      [dbo].[tblCore_DebugAttributeValueLog]
	      (
 	     [CreatedByUserID]
 	   , [LastModifiedByUserID]
	   , [DebugAttributeValueLogID]
	   , [DebugLogID]
	   , [BaseAttributeID]
	   , [AttributeValue]
	      )

	VALUES 
	      (
 	     @CreatedByUserID
 	   , @CreatedByUserID
	   , @DebugAttributeValueLogID
	   , @DebugLogID
	   , @BaseAttributeID
	   , @AttributeValue
	      )

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END


	SET  @Timestamp = @@DBTS
END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_LogOneDebugLog
	  @SqlErrorNumber int = 0 OUTPUT
	, @CreatedByUserID uniqueidentifier = NULL
	, @Timestamp timestamp = NULL OUTPUT
	, @DebugLogID uniqueidentifier = NULL OUTPUT
	, @EventName nvarchar(255) = NULL
	, @Message nvarchar(1000) = NULL
	, @ErrorNumber int = NULL
	, @EventTypeCode int
	, @SeverityLevelCode int
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure logs DebugLog data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@EventTypeCode IS NULL OR @SeverityLevelCode IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END
/*
** record validation
*/
IF EXISTS (SELECT [DebugLogID] FROM [dbo].[tblCore_DebugLog] WHERE [DebugLogID] =  @DebugLogID)
BEGIN
	SET @SqlErrorNumber = -1003
	GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	IF @DebugLogID  IS NULL
	BEGIN
		SET @DebugLogID  = NEWID ()
	END
	INSERT
	      [dbo].[tblCore_DebugLog]
	      (
 	     [CreatedByUserID]
 	   , [LastModifiedByUserID]
	   , [DebugLogID]
	   , [EventName]
	   , [Message]
	   , [ErrorNumber]
	   , [EventTypeCode]
	   , [SeverityLevelCode]
	      )

	VALUES 
	      (
 	     @CreatedByUserID
 	   , @CreatedByUserID
	   , @DebugLogID
	   , @EventName
	   , @Message
	   , @ErrorNumber
	   , @EventTypeCode
	   , @SeverityLevelCode
	      )

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END


	SET  @Timestamp = @@DBTS
END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_UpdateOneAttributeType
	  @SqlErrorNumber int = 0 OUTPUT
	, @LastModifiedByUserID uniqueidentifier = NULL
	, @Timestamp timestamp = NULL OUTPUT
	, @CheckTimestamp bit = 0
	, @AttributeTypeCode int
	, @AttributeTypeName nvarchar(100)
	, @Description nvarchar(1000) = NULL
	, @IsActive bit = 0
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure updates AttributeType data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@AttributeTypeCode IS NULL OR @AttributeTypeName IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END
/*
** record validation
*/
IF NOT EXISTS (SELECT [AttributeTypeCode] FROM [dbo].[tlkpCore_AttributeType] WHERE [AttributeTypeCode] =  @AttributeTypeCode)
BEGIN
	SET @SqlErrorNumber = -1003
	GOTO EXIT_ERROR
END
/*
** timestamp validation
*/
IF (@CheckTimestamp = 1)
BEGIN
	IF EXISTS (SELECT [AttributeTypeCode] FROM [dbo].[tlkpCore_AttributeType] WHERE [AttributeTypeCode] =  @AttributeTypeCode AND [Timestamp] <> @Timestamp)
	BEGIN
		SET @SqlErrorNumber = -1002
		GOTO EXIT_ERROR
	END
END

/*
** perform main procedure tasks
*/
BEGIN
	UPDATE
	      [dbo].[tlkpCore_AttributeType]
	SET
	     [LastModifiedByUserID] = @LastModifiedByUserID
	   , [LastModifiedDate] = getdate()
	   , [AttributeTypeCode] = @AttributeTypeCode
	   , [AttributeTypeName] = @AttributeTypeName
	   , [Description] = @Description
	   , [IsActive] = @IsActive
	WHERE [AttributeTypeCode] =  @AttributeTypeCode

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

	SET  @Timestamp = @@DBTS

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_UpdateOneDataType
	  @SqlErrorNumber int = 0 OUTPUT
	, @LastModifiedByUserID uniqueidentifier = NULL
	, @Timestamp timestamp = NULL OUTPUT
	, @CheckTimestamp bit = 0
	, @DataTypeCode int
	, @DataTypeName nvarchar(100)
	, @Description nvarchar(1000) = NULL
	, @IsActive bit = 0
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure updates DataType data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@DataTypeCode IS NULL OR @DataTypeName IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END
/*
** record validation
*/
IF NOT EXISTS (SELECT [DataTypeCode] FROM [dbo].[tlkpCore_DataType] WHERE [DataTypeCode] =  @DataTypeCode)
BEGIN
	SET @SqlErrorNumber = -1003
	GOTO EXIT_ERROR
END
/*
** timestamp validation
*/
IF (@CheckTimestamp = 1)
BEGIN
	IF EXISTS (SELECT [DataTypeCode] FROM [dbo].[tlkpCore_DataType] WHERE [DataTypeCode] =  @DataTypeCode AND [Timestamp] <> @Timestamp)
	BEGIN
		SET @SqlErrorNumber = -1002
		GOTO EXIT_ERROR
	END
END

/*
** perform main procedure tasks
*/
BEGIN
	UPDATE
	      [dbo].[tlkpCore_DataType]
	SET
	     [LastModifiedByUserID] = @LastModifiedByUserID
	   , [LastModifiedDate] = getdate()
	   , [DataTypeCode] = @DataTypeCode
	   , [DataTypeName] = @DataTypeName
	   , [Description] = @Description
	   , [IsActive] = @IsActive
	WHERE [DataTypeCode] =  @DataTypeCode

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

	SET  @Timestamp = @@DBTS

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_UpdateOneDebugAttribute
	  @SqlErrorNumber int = 0 OUTPUT
	, @LastModifiedByUserID uniqueidentifier = NULL
	, @Timestamp timestamp = NULL OUTPUT
	, @CheckTimestamp bit = 0
	, @BaseAttributeID uniqueidentifier
	, @AttributeCode int
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure updates DebugAttribute data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@BaseAttributeID IS NULL OR @AttributeCode IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END
/*
** record validation
*/
IF NOT EXISTS (SELECT [BaseAttributeID] FROM [dbo].[tblCore_DebugAttribute] WHERE [BaseAttributeID] =  @BaseAttributeID)
BEGIN
	SET @SqlErrorNumber = -1003
	GOTO EXIT_ERROR
END
/*
** timestamp validation
*/
IF (@CheckTimestamp = 1)
BEGIN
	IF EXISTS (SELECT [BaseAttributeID] FROM [dbo].[tblCore_DebugAttribute] WHERE [BaseAttributeID] =  @BaseAttributeID AND [Timestamp] <> @Timestamp)
	BEGIN
		SET @SqlErrorNumber = -1002
		GOTO EXIT_ERROR
	END
END

/*
** perform main procedure tasks
*/
BEGIN
	UPDATE
	      [dbo].[tblCore_DebugAttribute]
	SET
	     [LastModifiedByUserID] = @LastModifiedByUserID
	   , [LastModifiedDate] = getdate()
	   , [BaseAttributeID] = @BaseAttributeID
	   , [AttributeCode] = @AttributeCode
	WHERE [BaseAttributeID] =  @BaseAttributeID

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

	SET  @Timestamp = @@DBTS

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_UpdateOneError
	  @SqlErrorNumber int = 0 OUTPUT
	, @LastModifiedByUserID uniqueidentifier = NULL
	, @Timestamp timestamp = NULL OUTPUT
	, @CheckTimestamp bit = 0
	, @ErrorNumber int
	, @ErrorTitle nvarchar(100)
	, @ErrorMessage nvarchar(1000) = NULL
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure updates Error data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@ErrorNumber IS NULL OR @ErrorTitle IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END
/*
** record validation
*/
IF NOT EXISTS (SELECT [ErrorNumber] FROM [dbo].[tlkpCore_Error] WHERE [ErrorNumber] =  @ErrorNumber)
BEGIN
	SET @SqlErrorNumber = -1003
	GOTO EXIT_ERROR
END
/*
** timestamp validation
*/
IF (@CheckTimestamp = 1)
BEGIN
	IF EXISTS (SELECT [ErrorNumber] FROM [dbo].[tlkpCore_Error] WHERE [ErrorNumber] =  @ErrorNumber AND [Timestamp] <> @Timestamp)
	BEGIN
		SET @SqlErrorNumber = -1002
		GOTO EXIT_ERROR
	END
END

/*
** perform main procedure tasks
*/
BEGIN
	UPDATE
	      [dbo].[tlkpCore_Error]
	SET
	     [LastModifiedByUserID] = @LastModifiedByUserID
	   , [LastModifiedDate] = getdate()
	   , [ErrorNumber] = @ErrorNumber
	   , [ErrorTitle] = @ErrorTitle
	   , [ErrorMessage] = @ErrorMessage
	WHERE [ErrorNumber] =  @ErrorNumber

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

	SET  @Timestamp = @@DBTS

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_UpdateOneEventType
	  @SqlErrorNumber int = 0 OUTPUT
	, @LastModifiedByUserID uniqueidentifier = NULL
	, @Timestamp timestamp = NULL OUTPUT
	, @CheckTimestamp bit = 0
	, @EventTypeCode int
	, @EventTypeName nvarchar(100)
	, @Description nvarchar(1000) = NULL
	, @IsActive bit = 0
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure updates EventType data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@EventTypeCode IS NULL OR @EventTypeName IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END
/*
** record validation
*/
IF NOT EXISTS (SELECT [EventTypeCode] FROM [dbo].[tlkpCore_EventType] WHERE [EventTypeCode] =  @EventTypeCode)
BEGIN
	SET @SqlErrorNumber = -1003
	GOTO EXIT_ERROR
END
/*
** timestamp validation
*/
IF (@CheckTimestamp = 1)
BEGIN
	IF EXISTS (SELECT [EventTypeCode] FROM [dbo].[tlkpCore_EventType] WHERE [EventTypeCode] =  @EventTypeCode AND [Timestamp] <> @Timestamp)
	BEGIN
		SET @SqlErrorNumber = -1002
		GOTO EXIT_ERROR
	END
END

/*
** perform main procedure tasks
*/
BEGIN
	UPDATE
	      [dbo].[tlkpCore_EventType]
	SET
	     [LastModifiedByUserID] = @LastModifiedByUserID
	   , [LastModifiedDate] = getdate()
	   , [EventTypeCode] = @EventTypeCode
	   , [EventTypeName] = @EventTypeName
	   , [Description] = @Description
	   , [IsActive] = @IsActive
	WHERE [EventTypeCode] =  @EventTypeCode

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

	SET  @Timestamp = @@DBTS

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_UpdateOneSeverityLevel
	  @SqlErrorNumber int = 0 OUTPUT
	, @LastModifiedByUserID uniqueidentifier = NULL
	, @Timestamp timestamp = NULL OUTPUT
	, @CheckTimestamp bit = 0
	, @SeverityLevelCode int
	, @SeverityLevelName nvarchar(255)
	, @Description nvarchar(1000) = NULL
	, @IsActive bit = 0
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure updates SeverityLevel data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@SeverityLevelCode IS NULL OR @SeverityLevelName IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END
/*
** record validation
*/
IF NOT EXISTS (SELECT [SeverityLevelCode] FROM [dbo].[tlkpCore_SeverityLevel] WHERE [SeverityLevelCode] =  @SeverityLevelCode)
BEGIN
	SET @SqlErrorNumber = -1003
	GOTO EXIT_ERROR
END
/*
** timestamp validation
*/
IF (@CheckTimestamp = 1)
BEGIN
	IF EXISTS (SELECT [SeverityLevelCode] FROM [dbo].[tlkpCore_SeverityLevel] WHERE [SeverityLevelCode] =  @SeverityLevelCode AND [Timestamp] <> @Timestamp)
	BEGIN
		SET @SqlErrorNumber = -1002
		GOTO EXIT_ERROR
	END
END

/*
** perform main procedure tasks
*/
BEGIN
	UPDATE
	      [dbo].[tlkpCore_SeverityLevel]
	SET
	     [LastModifiedByUserID] = @LastModifiedByUserID
	   , [LastModifiedDate] = getdate()
	   , [SeverityLevelCode] = @SeverityLevelCode
	   , [SeverityLevelName] = @SeverityLevelName
	   , [Description] = @Description
	   , [IsActive] = @IsActive
	WHERE [SeverityLevelCode] =  @SeverityLevelCode

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

	SET  @Timestamp = @@DBTS

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spCore_UpsertOneBaseAttribute
	  @SqlErrorNumber int = 0 OUTPUT
	, @CreatedByUserID uniqueidentifier = NULL
	, @LastModifiedByUserID uniqueidentifier = NULL
	, @Timestamp timestamp = NULL OUTPUT
	, @CheckTimestamp bit = 0
	, @BaseAttributeID uniqueidentifier = NULL OUTPUT
	, @AttributeName nvarchar(100)
	, @AttributeTypeCode int
	, @DataTypeCode int
	, @Description nvarchar(1000) = NULL
	, @IsActive bit = 0
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure inserts or updates BaseAttribute data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@AttributeName IS NULL OR @AttributeTypeCode IS NULL OR @DataTypeCode IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END
/*
** timestamp validation
*/
IF (@CheckTimestamp = 1)
BEGIN
	IF EXISTS (SELECT [BaseAttributeID] FROM [dbo].[tblCore_BaseAttribute] WHERE [BaseAttributeID] =  @BaseAttributeID AND [Timestamp] <> @Timestamp)
	BEGIN
		SET @SqlErrorNumber = -1002
		GOTO EXIT_ERROR
	END
END

/*
** perform main procedure tasks
*/
IF NOT EXISTS (SELECT [BaseAttributeID] FROM [dbo].[tblCore_BaseAttribute] WHERE [BaseAttributeID] =  @BaseAttributeID)
BEGIN
	IF @BaseAttributeID  IS NULL
	BEGIN
		SET @BaseAttributeID  = NEWID ()
	END
	INSERT
	      [dbo].[tblCore_BaseAttribute]
	      (
 	     [CreatedByUserID]
 	   , [LastModifiedByUserID]
	   , [BaseAttributeID]
	   , [AttributeName]
	   , [AttributeTypeCode]
	   , [DataTypeCode]
	   , [Description]
	   , [IsActive]
	      )

	VALUES 
	      (
 	     @CreatedByUserID
 	   , @CreatedByUserID
	   , @BaseAttributeID
	   , @AttributeName
	   , @AttributeTypeCode
	   , @DataTypeCode
	   , @Description
	   , @IsActive
	      )

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END


	SET  @Timestamp = @@DBTS
	END
ELSE
BEGIN
	UPDATE
	      [dbo].[tblCore_BaseAttribute]
	SET
	     [LastModifiedByUserID] = @LastModifiedByUserID
	   , [LastModifiedDate] = getdate()
	   , [BaseAttributeID] = @BaseAttributeID
	   , [AttributeName] = @AttributeName
	   , [AttributeTypeCode] = @AttributeTypeCode
	   , [DataTypeCode] = @DataTypeCode
	   , [Description] = @Description
	   , [IsActive] = @IsActive
	WHERE [BaseAttributeID] =  @BaseAttributeID

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

	SET  @Timestamp = @@DBTS

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spEvents_AddOneEvent
	  @SqlErrorNumber int = 0 OUTPUT
	, @CreatedByUserID uniqueidentifier = NULL
	, @Timestamp timestamp = NULL OUTPUT
	, @EventCode int
	, @EventName nvarchar(255)
	, @EventTypeCode int
	, @Description nvarchar(2000) = NULL
	, @IsActive bit = 0
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure inserts Event data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@EventCode IS NULL OR @EventName IS NULL OR @EventTypeCode IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END
/*
** record validation
*/
IF EXISTS (SELECT [EventCode] FROM [dbo].[tblEvents_Event] WHERE [EventCode] =  @EventCode)
BEGIN
	SET @SqlErrorNumber = -1003
	GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	INSERT
	      [dbo].[tblEvents_Event]
	      (
 	     [CreatedByUserID]
 	   , [LastModifiedByUserID]
	   , [EventCode]
	   , [EventName]
	   , [EventTypeCode]
	   , [Description]
	   , [IsActive]
	      )

	VALUES 
	      (
 	     @CreatedByUserID
 	   , @CreatedByUserID
	   , @EventCode
	   , @EventName
	   , @EventTypeCode
	   , @Description
	   , @IsActive
	      )

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END


	SET  @Timestamp = @@DBTS
END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spEvents_AddOneEventAttribute
	  @SqlErrorNumber int = 0 OUTPUT
	, @CreatedByUserID uniqueidentifier = NULL
	, @Timestamp timestamp = NULL OUTPUT
	, @BaseAttributeID uniqueidentifier
	, @AttributeCode int
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure inserts EventAttribute data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@BaseAttributeID IS NULL OR @AttributeCode IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END
/*
** record validation
*/
IF EXISTS (SELECT [BaseAttributeID] FROM [dbo].[tblEvents_EventAttribute] WHERE [BaseAttributeID] =  @BaseAttributeID)
BEGIN
	SET @SqlErrorNumber = -1003
	GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	INSERT
	      [dbo].[tblEvents_EventAttribute]
	      (
 	     [CreatedByUserID]
 	   , [LastModifiedByUserID]
	   , [BaseAttributeID]
	   , [AttributeCode]
	      )

	VALUES 
	      (
 	     @CreatedByUserID
 	   , @CreatedByUserID
	   , @BaseAttributeID
	   , @AttributeCode
	      )

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END


	SET  @Timestamp = @@DBTS
END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spEvents_AddOneEventType
	  @SqlErrorNumber int = 0 OUTPUT
	, @CreatedByUserID uniqueidentifier = NULL
	, @Timestamp timestamp = NULL OUTPUT
	, @EventTypeCode int
	, @EventTypeName nvarchar(255)
	, @Description nvarchar(2000) = NULL
	, @IsActive bit = 1
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure inserts EventType data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@EventTypeCode IS NULL OR @EventTypeName IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END
/*
** record validation
*/
IF EXISTS (SELECT [EventTypeCode] FROM [dbo].[tlkpEvents_EventType] WHERE [EventTypeCode] =  @EventTypeCode)
BEGIN
	SET @SqlErrorNumber = -1003
	GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	INSERT
	      [dbo].[tlkpEvents_EventType]
	      (
 	     [CreatedByUserID]
 	   , [LastModifiedByUserID]
	   , [EventTypeCode]
	   , [EventTypeName]
	   , [Description]
	   , [IsActive]
	      )

	VALUES 
	      (
 	     @CreatedByUserID
 	   , @CreatedByUserID
	   , @EventTypeCode
	   , @EventTypeName
	   , @Description
	   , @IsActive
	      )

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END


	SET  @Timestamp = @@DBTS
END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spEvents_DeleteAllEventAttributeDataByAttributeTypeCode
	  @SqlErrorNumber int = 0 OUTPUT
	, @AttributeTypeCode int
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure deletes all EventAttribute data by a key.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@AttributeTypeCode IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	DELETE FROM
	      [dbo].[tblEvents_EventAttribute]
	WHERE [BaseAttributeID] IN (SELECT [BaseAttributeID] FROM [dbo].[tblCore_BaseAttribute] WHERE [AttributeTypeCode] =  @AttributeTypeCode)

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spEvents_DeleteAllEventAttributeDataByBaseAttributeID
	  @SqlErrorNumber int = 0 OUTPUT
	, @BaseAttributeID uniqueidentifier
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure deletes all EventAttribute data by a key.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@BaseAttributeID IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	DELETE FROM
	      [dbo].[tblEvents_EventAttribute]
	WHERE [BaseAttributeID] =  @BaseAttributeID

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spEvents_DeleteAllEventAttributeDataByDataTypeCode
	  @SqlErrorNumber int = 0 OUTPUT
	, @DataTypeCode int
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure deletes all EventAttribute data by a key.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@DataTypeCode IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	DELETE FROM
	      [dbo].[tblEvents_EventAttribute]
	WHERE [BaseAttributeID] IN (SELECT [BaseAttributeID] FROM [dbo].[tblCore_BaseAttribute] WHERE [DataTypeCode] =  @DataTypeCode)

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spEvents_DeleteAllEventDataByEventTypeCode
	  @SqlErrorNumber int = 0 OUTPUT
	, @EventTypeCode int
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure deletes all Event data by a key.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@EventTypeCode IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	DELETE FROM
	      [dbo].[tblEvents_Event]
	WHERE [EventTypeCode] =  @EventTypeCode

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spEvents_DeleteOneEvent
	  @SqlErrorNumber int = 0 OUTPUT
	, @Timestamp timestamp = NULL OUTPUT
	, @CheckTimestamp bit = 0
	, @EventCode int
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure deletes Event data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@EventCode IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END
/*
** record validation
*/
IF NOT EXISTS (SELECT [EventCode] FROM [dbo].[tblEvents_Event] WHERE [EventCode] =  @EventCode)
BEGIN
	SET @SqlErrorNumber = -1003
	GOTO EXIT_ERROR
END
/*
** timestamp validation
*/
IF (@CheckTimestamp = 1)
BEGIN
	IF EXISTS (SELECT [EventCode] FROM [dbo].[tblEvents_Event] WHERE [EventCode] =  @EventCode AND [Timestamp] <> @Timestamp)
	BEGIN
		SET @SqlErrorNumber = -1002
		GOTO EXIT_ERROR
	END
END

/*
** perform main procedure tasks
*/
BEGIN
	DELETE FROM
	      [dbo].[tblEvents_Event]
	WHERE [EventCode] =  @EventCode

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spEvents_DeleteOneEventAttribute
	  @SqlErrorNumber int = 0 OUTPUT
	, @Timestamp timestamp = NULL OUTPUT
	, @CheckTimestamp bit = 0
	, @BaseAttributeID uniqueidentifier
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure deletes EventAttribute data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@BaseAttributeID IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END
/*
** record validation
*/
IF NOT EXISTS (SELECT [BaseAttributeID] FROM [dbo].[tblEvents_EventAttribute] WHERE [BaseAttributeID] =  @BaseAttributeID)
BEGIN
	SET @SqlErrorNumber = -1003
	GOTO EXIT_ERROR
END
/*
** timestamp validation
*/
IF (@CheckTimestamp = 1)
BEGIN
	IF EXISTS (SELECT [BaseAttributeID] FROM [dbo].[tblEvents_EventAttribute] WHERE [BaseAttributeID] =  @BaseAttributeID AND [Timestamp] <> @Timestamp)
	BEGIN
		SET @SqlErrorNumber = -1002
		GOTO EXIT_ERROR
	END
END

/*
** perform main procedure tasks
*/
BEGIN
	DELETE FROM
	      [dbo].[tblEvents_EventAttribute]
	WHERE [BaseAttributeID] =  @BaseAttributeID

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spEvents_DeleteOneEventType
	  @SqlErrorNumber int = 0 OUTPUT
	, @Timestamp timestamp = NULL OUTPUT
	, @CheckTimestamp bit = 0
	, @EventTypeCode int
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure deletes EventType data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@EventTypeCode IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END
/*
** record validation
*/
IF NOT EXISTS (SELECT [EventTypeCode] FROM [dbo].[tlkpEvents_EventType] WHERE [EventTypeCode] =  @EventTypeCode)
BEGIN
	SET @SqlErrorNumber = -1003
	GOTO EXIT_ERROR
END
/*
** timestamp validation
*/
IF (@CheckTimestamp = 1)
BEGIN
	IF EXISTS (SELECT [EventTypeCode] FROM [dbo].[tlkpEvents_EventType] WHERE [EventTypeCode] =  @EventTypeCode AND [Timestamp] <> @Timestamp)
	BEGIN
		SET @SqlErrorNumber = -1002
		GOTO EXIT_ERROR
	END
END

/*
** perform main procedure tasks
*/
BEGIN
	DELETE FROM
	      [dbo].[tlkpEvents_EventType]
	WHERE [EventTypeCode] =  @EventTypeCode

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spEvents_GetAllAuditAttributeValueLogData
	  @SqlErrorNumber int = 0 OUTPUT
	, @SortColumn sysname = 'AuditAttributeValueLogID'
	, @SortDirection nvarchar(20) = 'Ascending'
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets all AuditAttributeValueLog data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0
IF (@SortColumn = '') SET @SortColumn='AuditAttributeValueLogID'

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

IF (@SortDirection = 'Random')
BEGIN
	SELECT
		  AuditAttributeValueLog1.[AuditAttributeValueLogID]
		, AuditAttributeValueLog1.[AuditLogID]
		, AuditAttributeValueLog1.[BaseAttributeID]
		, AuditAttributeValueLog1.[AttributeValue]
		, AuditAttributeValueLog1.[CreatedByUserID]
		, AuditAttributeValueLog1.[CreatedDate]
		, AuditAttributeValueLog1.[LastModifiedByUserID]
		, AuditAttributeValueLog1.[LastModifiedDate]
		, AuditAttributeValueLog1.[Timestamp]
	FROM
	      [dbo].[tblEvents_AuditAttributeValueLog] AuditAttributeValueLog1

	ORDER BY NewID()
END
ELSE
BEGIN
	SELECT
		  AuditAttributeValueLog1.[AuditAttributeValueLogID]
		, AuditAttributeValueLog1.[AuditLogID]
		, AuditAttributeValueLog1.[BaseAttributeID]
		, AuditAttributeValueLog1.[AttributeValue]
		, AuditAttributeValueLog1.[CreatedByUserID]
		, AuditAttributeValueLog1.[CreatedDate]
		, AuditAttributeValueLog1.[LastModifiedByUserID]
		, AuditAttributeValueLog1.[LastModifiedDate]
		, AuditAttributeValueLog1.[Timestamp]
	FROM
	      [dbo].[tblEvents_AuditAttributeValueLog] AuditAttributeValueLog1

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AuditAttributeValueLogID' THEN AuditAttributeValueLog1.[AuditAttributeValueLogID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AuditAttributeValueLogID' THEN AuditAttributeValueLog1.[AuditAttributeValueLogID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AuditLogID' THEN AuditAttributeValueLog1.[AuditLogID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AuditLogID' THEN AuditAttributeValueLog1.[AuditLogID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'BaseAttributeID' THEN AuditAttributeValueLog1.[BaseAttributeID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'BaseAttributeID' THEN AuditAttributeValueLog1.[BaseAttributeID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeValue' THEN AuditAttributeValueLog1.[AttributeValue] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeValue' THEN AuditAttributeValueLog1.[AttributeValue] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN AuditAttributeValueLog1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN AuditAttributeValueLog1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN AuditAttributeValueLog1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN AuditAttributeValueLog1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN AuditAttributeValueLog1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN AuditAttributeValueLog1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN AuditAttributeValueLog1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN AuditAttributeValueLog1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN AuditAttributeValueLog1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN AuditAttributeValueLog1.[Timestamp] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END


RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spEvents_GetAllAuditAttributeValueLogDataByAuditLogID
	  @SqlErrorNumber int = 0 OUTPUT
	, @SortColumn sysname = 'AuditLogID'
	, @SortDirection nvarchar(20) = 'Ascending'
	, @AuditLogID uniqueidentifier
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets all AuditAttributeValueLog data by a key.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0
IF (@SortColumn = '') SET @SortColumn='AuditLogID'

/*
** parameter validation
*/
IF (@AuditLogID IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

IF (@SortDirection = 'Random')
BEGIN
	SELECT
		  AuditAttributeValueLog1.[AuditAttributeValueLogID]
		, AuditAttributeValueLog1.[AuditLogID]
		, AuditAttributeValueLog1.[BaseAttributeID]
		, AuditAttributeValueLog1.[AttributeValue]
		, AuditAttributeValueLog1.[CreatedByUserID]
		, AuditAttributeValueLog1.[CreatedDate]
		, AuditAttributeValueLog1.[LastModifiedByUserID]
		, AuditAttributeValueLog1.[LastModifiedDate]
		, AuditAttributeValueLog1.[Timestamp]
	FROM
	      [dbo].[tblEvents_AuditAttributeValueLog] AuditAttributeValueLog1
	WHERE 
		AuditAttributeValueLog1.[AuditLogID] = @AuditLogID

	ORDER BY NewID()
END
ELSE
BEGIN
	SELECT
		  AuditAttributeValueLog1.[AuditAttributeValueLogID]
		, AuditAttributeValueLog1.[AuditLogID]
		, AuditAttributeValueLog1.[BaseAttributeID]
		, AuditAttributeValueLog1.[AttributeValue]
		, AuditAttributeValueLog1.[CreatedByUserID]
		, AuditAttributeValueLog1.[CreatedDate]
		, AuditAttributeValueLog1.[LastModifiedByUserID]
		, AuditAttributeValueLog1.[LastModifiedDate]
		, AuditAttributeValueLog1.[Timestamp]
	FROM
	      [dbo].[tblEvents_AuditAttributeValueLog] AuditAttributeValueLog1
	WHERE 
		AuditAttributeValueLog1.[AuditLogID] = @AuditLogID

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AuditAttributeValueLogID' THEN AuditAttributeValueLog1.[AuditAttributeValueLogID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AuditAttributeValueLogID' THEN AuditAttributeValueLog1.[AuditAttributeValueLogID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AuditLogID' THEN AuditAttributeValueLog1.[AuditLogID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AuditLogID' THEN AuditAttributeValueLog1.[AuditLogID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'BaseAttributeID' THEN AuditAttributeValueLog1.[BaseAttributeID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'BaseAttributeID' THEN AuditAttributeValueLog1.[BaseAttributeID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeValue' THEN AuditAttributeValueLog1.[AttributeValue] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeValue' THEN AuditAttributeValueLog1.[AttributeValue] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN AuditAttributeValueLog1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN AuditAttributeValueLog1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN AuditAttributeValueLog1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN AuditAttributeValueLog1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN AuditAttributeValueLog1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN AuditAttributeValueLog1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN AuditAttributeValueLog1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN AuditAttributeValueLog1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN AuditAttributeValueLog1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN AuditAttributeValueLog1.[Timestamp] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END


RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spEvents_GetAllAuditAttributeValueLogDataByBaseAttributeID
	  @SqlErrorNumber int = 0 OUTPUT
	, @SortColumn sysname = 'BaseAttributeID'
	, @SortDirection nvarchar(20) = 'Ascending'
	, @BaseAttributeID uniqueidentifier
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets all AuditAttributeValueLog data by a key.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0
IF (@SortColumn = '') SET @SortColumn='BaseAttributeID'

/*
** parameter validation
*/
IF (@BaseAttributeID IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

IF (@SortDirection = 'Random')
BEGIN
	SELECT
		  AuditAttributeValueLog1.[AuditAttributeValueLogID]
		, AuditAttributeValueLog1.[AuditLogID]
		, AuditAttributeValueLog1.[BaseAttributeID]
		, AuditAttributeValueLog1.[AttributeValue]
		, AuditAttributeValueLog1.[CreatedByUserID]
		, AuditAttributeValueLog1.[CreatedDate]
		, AuditAttributeValueLog1.[LastModifiedByUserID]
		, AuditAttributeValueLog1.[LastModifiedDate]
		, AuditAttributeValueLog1.[Timestamp]
	FROM
	      [dbo].[tblEvents_AuditAttributeValueLog] AuditAttributeValueLog1
	WHERE 
		AuditAttributeValueLog1.[BaseAttributeID] = @BaseAttributeID

	ORDER BY NewID()
END
ELSE
BEGIN
	SELECT
		  AuditAttributeValueLog1.[AuditAttributeValueLogID]
		, AuditAttributeValueLog1.[AuditLogID]
		, AuditAttributeValueLog1.[BaseAttributeID]
		, AuditAttributeValueLog1.[AttributeValue]
		, AuditAttributeValueLog1.[CreatedByUserID]
		, AuditAttributeValueLog1.[CreatedDate]
		, AuditAttributeValueLog1.[LastModifiedByUserID]
		, AuditAttributeValueLog1.[LastModifiedDate]
		, AuditAttributeValueLog1.[Timestamp]
	FROM
	      [dbo].[tblEvents_AuditAttributeValueLog] AuditAttributeValueLog1
	WHERE 
		AuditAttributeValueLog1.[BaseAttributeID] = @BaseAttributeID

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AuditAttributeValueLogID' THEN AuditAttributeValueLog1.[AuditAttributeValueLogID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AuditAttributeValueLogID' THEN AuditAttributeValueLog1.[AuditAttributeValueLogID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AuditLogID' THEN AuditAttributeValueLog1.[AuditLogID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AuditLogID' THEN AuditAttributeValueLog1.[AuditLogID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'BaseAttributeID' THEN AuditAttributeValueLog1.[BaseAttributeID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'BaseAttributeID' THEN AuditAttributeValueLog1.[BaseAttributeID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeValue' THEN AuditAttributeValueLog1.[AttributeValue] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeValue' THEN AuditAttributeValueLog1.[AttributeValue] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN AuditAttributeValueLog1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN AuditAttributeValueLog1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN AuditAttributeValueLog1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN AuditAttributeValueLog1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN AuditAttributeValueLog1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN AuditAttributeValueLog1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN AuditAttributeValueLog1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN AuditAttributeValueLog1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN AuditAttributeValueLog1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN AuditAttributeValueLog1.[Timestamp] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END


RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spEvents_GetAllAuditAttributeValueLogDataByCriteria
	  @SqlErrorNumber int = 0 OUTPUT
	, @SortColumn sysname = 'AttributeValue'
	, @SortDirection nvarchar(20) = 'Ascending'
	, @AttributeValue nvarchar(1000) = NULL
	, @LastModifiedDateStart datetime = getdate
	, @LastModifiedDateEnd datetime = getdate
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets all AuditAttributeValueLog data by criteria.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0
IF (@SortColumn = '') SET @SortColumn='AttributeValue'

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

IF (@SortDirection = 'Random')
BEGIN
	SELECT
		  AuditAttributeValueLog1.[AuditAttributeValueLogID]
		, AuditAttributeValueLog1.[AuditLogID]
		, AuditAttributeValueLog1.[BaseAttributeID]
		, AuditAttributeValueLog1.[AttributeValue]
		, AuditAttributeValueLog1.[CreatedByUserID]
		, AuditAttributeValueLog1.[CreatedDate]
		, AuditAttributeValueLog1.[LastModifiedByUserID]
		, AuditAttributeValueLog1.[LastModifiedDate]
		, AuditAttributeValueLog1.[Timestamp]
	FROM
	      [dbo].[tblEvents_AuditAttributeValueLog] AuditAttributeValueLog1
	WHERE 
		(@AttributeValue IS NULL OR AuditAttributeValueLog1.[AttributeValue] like '%' + @AttributeValue + '%')
		AND ((@LastModifiedDateStart  IS NULL) OR (AuditAttributeValueLog1.[LastModifiedDate] >=  @LastModifiedDateStart))
		AND ((@LastModifiedDateEnd  IS NULL) OR (AuditAttributeValueLog1.[LastModifiedDate] <=  @LastModifiedDateEnd))

	ORDER BY NewID()
END
ELSE
BEGIN
	SELECT
		  AuditAttributeValueLog1.[AuditAttributeValueLogID]
		, AuditAttributeValueLog1.[AuditLogID]
		, AuditAttributeValueLog1.[BaseAttributeID]
		, AuditAttributeValueLog1.[AttributeValue]
		, AuditAttributeValueLog1.[CreatedByUserID]
		, AuditAttributeValueLog1.[CreatedDate]
		, AuditAttributeValueLog1.[LastModifiedByUserID]
		, AuditAttributeValueLog1.[LastModifiedDate]
		, AuditAttributeValueLog1.[Timestamp]
	FROM
	      [dbo].[tblEvents_AuditAttributeValueLog] AuditAttributeValueLog1
	WHERE 
		(@AttributeValue IS NULL OR AuditAttributeValueLog1.[AttributeValue] like '%' + @AttributeValue + '%')
		AND ((@LastModifiedDateStart  IS NULL) OR (AuditAttributeValueLog1.[LastModifiedDate] >=  @LastModifiedDateStart))
		AND ((@LastModifiedDateEnd  IS NULL) OR (AuditAttributeValueLog1.[LastModifiedDate] <=  @LastModifiedDateEnd))

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AuditAttributeValueLogID' THEN AuditAttributeValueLog1.[AuditAttributeValueLogID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AuditAttributeValueLogID' THEN AuditAttributeValueLog1.[AuditAttributeValueLogID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AuditLogID' THEN AuditAttributeValueLog1.[AuditLogID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AuditLogID' THEN AuditAttributeValueLog1.[AuditLogID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'BaseAttributeID' THEN AuditAttributeValueLog1.[BaseAttributeID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'BaseAttributeID' THEN AuditAttributeValueLog1.[BaseAttributeID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeValue' THEN AuditAttributeValueLog1.[AttributeValue] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeValue' THEN AuditAttributeValueLog1.[AttributeValue] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN AuditAttributeValueLog1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN AuditAttributeValueLog1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN AuditAttributeValueLog1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN AuditAttributeValueLog1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN AuditAttributeValueLog1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN AuditAttributeValueLog1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN AuditAttributeValueLog1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN AuditAttributeValueLog1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN AuditAttributeValueLog1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN AuditAttributeValueLog1.[Timestamp] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END


RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spEvents_GetAllAuditLogData
	  @SqlErrorNumber int = 0 OUTPUT
	, @SortColumn sysname = 'AuditLogID'
	, @SortDirection nvarchar(20) = 'Ascending'
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets all AuditLog data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0
IF (@SortColumn = '') SET @SortColumn='AuditLogID'

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

IF (@SortDirection = 'Random')
BEGIN
	SELECT
		  AuditLog1.[AuditLogID]
		, AuditLog1.[EventCode]
		, AuditLog1.[CreatedByUserID]
		, AuditLog1.[CreatedDate]
		, AuditLog1.[LastModifiedByUserID]
		, AuditLog1.[LastModifiedDate]
		, AuditLog1.[Timestamp]
		, Event1.[EventName]
	FROM
	      [dbo].[tblEvents_AuditLog] AuditLog1
	INNER JOIN [dbo].[tblEvents_Event] Event1 ON Event1.[EventCode]=AuditLog1.[EventCode]

	ORDER BY NewID()
END
ELSE
BEGIN
	SELECT
		  AuditLog1.[AuditLogID]
		, AuditLog1.[EventCode]
		, AuditLog1.[CreatedByUserID]
		, AuditLog1.[CreatedDate]
		, AuditLog1.[LastModifiedByUserID]
		, AuditLog1.[LastModifiedDate]
		, AuditLog1.[Timestamp]
		, Event1.[EventName]
	FROM
	      [dbo].[tblEvents_AuditLog] AuditLog1
	INNER JOIN [dbo].[tblEvents_Event] Event1 ON Event1.[EventCode]=AuditLog1.[EventCode]

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AuditLogID' THEN AuditLog1.[AuditLogID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AuditLogID' THEN AuditLog1.[AuditLogID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'EventCode' THEN AuditLog1.[EventCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'EventCode' THEN AuditLog1.[EventCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN AuditLog1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN AuditLog1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN AuditLog1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN AuditLog1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN AuditLog1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN AuditLog1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN AuditLog1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN AuditLog1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN AuditLog1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN AuditLog1.[Timestamp] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'EventName' THEN Event1.[EventName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'EventName' THEN Event1.[EventName] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END


RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spEvents_GetAllAuditLogDataByCriteria
	  @SqlErrorNumber int = 0 OUTPUT
	, @SortColumn sysname = 'EventCode'
	, @SortDirection nvarchar(20) = 'Ascending'
	, @EventCode int
	, @LastModifiedDateStart datetime = getdate
	, @LastModifiedDateEnd datetime = getdate
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets all AuditLog data by criteria.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0
IF (@SortColumn = '') SET @SortColumn='EventCode'

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

IF (@SortDirection = 'Random')
BEGIN
	SELECT
		  AuditLog1.[AuditLogID]
		, AuditLog1.[EventCode]
		, AuditLog1.[CreatedByUserID]
		, AuditLog1.[CreatedDate]
		, AuditLog1.[LastModifiedByUserID]
		, AuditLog1.[LastModifiedDate]
		, AuditLog1.[Timestamp]
		, Event1.[EventName]
	FROM
	      [dbo].[tblEvents_AuditLog] AuditLog1
	INNER JOIN [dbo].[tblEvents_Event] Event1 ON Event1.[EventCode]=AuditLog1.[EventCode]
	WHERE 
		(@EventCode IS NULL OR AuditLog1.[EventCode] = @EventCode)
		AND ((@LastModifiedDateStart  IS NULL) OR (AuditLog1.[LastModifiedDate] >=  @LastModifiedDateStart))
		AND ((@LastModifiedDateEnd  IS NULL) OR (AuditLog1.[LastModifiedDate] <=  @LastModifiedDateEnd))

	ORDER BY NewID()
END
ELSE
BEGIN
	SELECT
		  AuditLog1.[AuditLogID]
		, AuditLog1.[EventCode]
		, AuditLog1.[CreatedByUserID]
		, AuditLog1.[CreatedDate]
		, AuditLog1.[LastModifiedByUserID]
		, AuditLog1.[LastModifiedDate]
		, AuditLog1.[Timestamp]
		, Event1.[EventName]
	FROM
	      [dbo].[tblEvents_AuditLog] AuditLog1
	INNER JOIN [dbo].[tblEvents_Event] Event1 ON Event1.[EventCode]=AuditLog1.[EventCode]
	WHERE 
		(@EventCode IS NULL OR AuditLog1.[EventCode] = @EventCode)
		AND ((@LastModifiedDateStart  IS NULL) OR (AuditLog1.[LastModifiedDate] >=  @LastModifiedDateStart))
		AND ((@LastModifiedDateEnd  IS NULL) OR (AuditLog1.[LastModifiedDate] <=  @LastModifiedDateEnd))

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AuditLogID' THEN AuditLog1.[AuditLogID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AuditLogID' THEN AuditLog1.[AuditLogID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'EventCode' THEN AuditLog1.[EventCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'EventCode' THEN AuditLog1.[EventCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN AuditLog1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN AuditLog1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN AuditLog1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN AuditLog1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN AuditLog1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN AuditLog1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN AuditLog1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN AuditLog1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN AuditLog1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN AuditLog1.[Timestamp] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'EventName' THEN Event1.[EventName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'EventName' THEN Event1.[EventName] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END


RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spEvents_GetAllAuditLogDataByEventCode
	  @SqlErrorNumber int = 0 OUTPUT
	, @SortColumn sysname = 'EventCode'
	, @SortDirection nvarchar(20) = 'Ascending'
	, @EventCode int
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets all AuditLog data by a key.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0
IF (@SortColumn = '') SET @SortColumn='EventCode'

/*
** parameter validation
*/
IF (@EventCode IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

IF (@SortDirection = 'Random')
BEGIN
	SELECT
		  AuditLog1.[AuditLogID]
		, AuditLog1.[EventCode]
		, AuditLog1.[CreatedByUserID]
		, AuditLog1.[CreatedDate]
		, AuditLog1.[LastModifiedByUserID]
		, AuditLog1.[LastModifiedDate]
		, AuditLog1.[Timestamp]
		, Event1.[EventName]
	FROM
	      [dbo].[tblEvents_AuditLog] AuditLog1
	INNER JOIN [dbo].[tblEvents_Event] Event1 ON Event1.[EventCode]=AuditLog1.[EventCode]
	WHERE 
		AuditLog1.[EventCode] = @EventCode

	ORDER BY NewID()
END
ELSE
BEGIN
	SELECT
		  AuditLog1.[AuditLogID]
		, AuditLog1.[EventCode]
		, AuditLog1.[CreatedByUserID]
		, AuditLog1.[CreatedDate]
		, AuditLog1.[LastModifiedByUserID]
		, AuditLog1.[LastModifiedDate]
		, AuditLog1.[Timestamp]
		, Event1.[EventName]
	FROM
	      [dbo].[tblEvents_AuditLog] AuditLog1
	INNER JOIN [dbo].[tblEvents_Event] Event1 ON Event1.[EventCode]=AuditLog1.[EventCode]
	WHERE 
		AuditLog1.[EventCode] = @EventCode

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AuditLogID' THEN AuditLog1.[AuditLogID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AuditLogID' THEN AuditLog1.[AuditLogID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'EventCode' THEN AuditLog1.[EventCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'EventCode' THEN AuditLog1.[EventCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN AuditLog1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN AuditLog1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN AuditLog1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN AuditLog1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN AuditLog1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN AuditLog1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN AuditLog1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN AuditLog1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN AuditLog1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN AuditLog1.[Timestamp] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'EventName' THEN Event1.[EventName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'EventName' THEN Event1.[EventName] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END


RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spEvents_GetAllEventAttributeData
	  @SqlErrorNumber int = 0 OUTPUT
	, @SortColumn sysname = 'BaseAttributeID'
	, @SortDirection nvarchar(20) = 'Ascending'
	, @IncludeInactive bit = 0
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets all EventAttribute data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0
IF (@SortColumn = '') SET @SortColumn='BaseAttributeID'

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

IF (@SortDirection = 'Random')
BEGIN
	SELECT
		  EventAttribute1.[BaseAttributeID]
		, EventAttribute1.[AttributeCode]
		, EventAttribute1.[CreatedByUserID]
		, EventAttribute1.[CreatedDate]
		, EventAttribute1.[LastModifiedByUserID]
		, EventAttribute1.[LastModifiedDate]
		, EventAttribute1.[Timestamp]
		, BaseAttribute1.[AttributeName]
		, BaseAttribute1.[AttributeTypeCode]
		, BaseAttribute1.[DataTypeCode]
		, BaseAttribute1.[Description]
		, BaseAttribute1.[IsActive]
		, AttributeType1.[AttributeTypeName]
		, DataType1.[DataTypeName]
	FROM
	      [dbo].[tblEvents_EventAttribute] EventAttribute1
	INNER JOIN [dbo].[tblCore_BaseAttribute] BaseAttribute1 ON BaseAttribute1.[BaseAttributeID]=EventAttribute1.[BaseAttributeID]
	INNER JOIN [dbo].[tlkpCore_AttributeType] AttributeType1 ON AttributeType1.[AttributeTypeCode]=BaseAttribute1.[AttributeTypeCode]
	INNER JOIN [dbo].[tlkpCore_DataType] DataType1 ON DataType1.[DataTypeCode]=BaseAttribute1.[DataTypeCode]
	WHERE 
		BaseAttribute1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN BaseAttribute1.[IsActive] ELSE 1 END

	ORDER BY NewID()
END
ELSE
BEGIN
	SELECT
		  EventAttribute1.[BaseAttributeID]
		, EventAttribute1.[AttributeCode]
		, EventAttribute1.[CreatedByUserID]
		, EventAttribute1.[CreatedDate]
		, EventAttribute1.[LastModifiedByUserID]
		, EventAttribute1.[LastModifiedDate]
		, EventAttribute1.[Timestamp]
		, BaseAttribute1.[AttributeName]
		, BaseAttribute1.[AttributeTypeCode]
		, BaseAttribute1.[DataTypeCode]
		, BaseAttribute1.[Description]
		, BaseAttribute1.[IsActive]
		, AttributeType1.[AttributeTypeName]
		, DataType1.[DataTypeName]
	FROM
	      [dbo].[tblEvents_EventAttribute] EventAttribute1
	INNER JOIN [dbo].[tblCore_BaseAttribute] BaseAttribute1 ON BaseAttribute1.[BaseAttributeID]=EventAttribute1.[BaseAttributeID]
	INNER JOIN [dbo].[tlkpCore_AttributeType] AttributeType1 ON AttributeType1.[AttributeTypeCode]=BaseAttribute1.[AttributeTypeCode]
	INNER JOIN [dbo].[tlkpCore_DataType] DataType1 ON DataType1.[DataTypeCode]=BaseAttribute1.[DataTypeCode]
	WHERE 
		BaseAttribute1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN BaseAttribute1.[IsActive] ELSE 1 END

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'BaseAttributeID' THEN EventAttribute1.[BaseAttributeID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'BaseAttributeID' THEN EventAttribute1.[BaseAttributeID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeCode' THEN EventAttribute1.[AttributeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeCode' THEN EventAttribute1.[AttributeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN EventAttribute1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN EventAttribute1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN EventAttribute1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN EventAttribute1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN EventAttribute1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN EventAttribute1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN EventAttribute1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN EventAttribute1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN EventAttribute1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN EventAttribute1.[Timestamp] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeName' THEN BaseAttribute1.[AttributeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeName' THEN BaseAttribute1.[AttributeName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeTypeCode' THEN BaseAttribute1.[AttributeTypeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeTypeCode' THEN BaseAttribute1.[AttributeTypeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'DataTypeCode' THEN BaseAttribute1.[DataTypeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'DataTypeCode' THEN BaseAttribute1.[DataTypeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Description' THEN BaseAttribute1.[Description] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Description' THEN BaseAttribute1.[Description] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'IsActive' THEN BaseAttribute1.[IsActive] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'IsActive' THEN BaseAttribute1.[IsActive] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeTypeName' THEN AttributeType1.[AttributeTypeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeTypeName' THEN AttributeType1.[AttributeTypeName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'DataTypeName' THEN DataType1.[DataTypeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'DataTypeName' THEN DataType1.[DataTypeName] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END


RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spEvents_GetAllEventAttributeDataByAttributeTypeCode
	  @SqlErrorNumber int = 0 OUTPUT
	, @SortColumn sysname = 'AttributeTypeCode'
	, @SortDirection nvarchar(20) = 'Ascending'
	, @IncludeInactive bit = 0
	, @AttributeTypeCode int
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets all EventAttribute data by a key.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0
IF (@SortColumn = '') SET @SortColumn='AttributeTypeCode'

/*
** parameter validation
*/
IF (@AttributeTypeCode IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

IF (@SortDirection = 'Random')
BEGIN
	SELECT
		  EventAttribute1.[BaseAttributeID]
		, EventAttribute1.[AttributeCode]
		, EventAttribute1.[CreatedByUserID]
		, EventAttribute1.[CreatedDate]
		, EventAttribute1.[LastModifiedByUserID]
		, EventAttribute1.[LastModifiedDate]
		, EventAttribute1.[Timestamp]
		, BaseAttribute1.[AttributeName]
		, BaseAttribute1.[AttributeTypeCode]
		, BaseAttribute1.[DataTypeCode]
		, BaseAttribute1.[Description]
		, BaseAttribute1.[IsActive]
		, AttributeType1.[AttributeTypeName]
		, DataType1.[DataTypeName]
	FROM
	      [dbo].[tblEvents_EventAttribute] EventAttribute1
	INNER JOIN [dbo].[tblCore_BaseAttribute] BaseAttribute1 ON BaseAttribute1.[BaseAttributeID]=EventAttribute1.[BaseAttributeID]
	INNER JOIN [dbo].[tlkpCore_AttributeType] AttributeType1 ON AttributeType1.[AttributeTypeCode]=BaseAttribute1.[AttributeTypeCode]
	INNER JOIN [dbo].[tlkpCore_DataType] DataType1 ON DataType1.[DataTypeCode]=BaseAttribute1.[DataTypeCode]
	WHERE 
		BaseAttribute1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN BaseAttribute1.[IsActive] ELSE 1 END
		AND BaseAttribute1.[AttributeTypeCode] = @AttributeTypeCode

	ORDER BY NewID()
END
ELSE
BEGIN
	SELECT
		  EventAttribute1.[BaseAttributeID]
		, EventAttribute1.[AttributeCode]
		, EventAttribute1.[CreatedByUserID]
		, EventAttribute1.[CreatedDate]
		, EventAttribute1.[LastModifiedByUserID]
		, EventAttribute1.[LastModifiedDate]
		, EventAttribute1.[Timestamp]
		, BaseAttribute1.[AttributeName]
		, BaseAttribute1.[AttributeTypeCode]
		, BaseAttribute1.[DataTypeCode]
		, BaseAttribute1.[Description]
		, BaseAttribute1.[IsActive]
		, AttributeType1.[AttributeTypeName]
		, DataType1.[DataTypeName]
	FROM
	      [dbo].[tblEvents_EventAttribute] EventAttribute1
	INNER JOIN [dbo].[tblCore_BaseAttribute] BaseAttribute1 ON BaseAttribute1.[BaseAttributeID]=EventAttribute1.[BaseAttributeID]
	INNER JOIN [dbo].[tlkpCore_AttributeType] AttributeType1 ON AttributeType1.[AttributeTypeCode]=BaseAttribute1.[AttributeTypeCode]
	INNER JOIN [dbo].[tlkpCore_DataType] DataType1 ON DataType1.[DataTypeCode]=BaseAttribute1.[DataTypeCode]
	WHERE 
		BaseAttribute1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN BaseAttribute1.[IsActive] ELSE 1 END
		AND BaseAttribute1.[AttributeTypeCode] = @AttributeTypeCode

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'BaseAttributeID' THEN EventAttribute1.[BaseAttributeID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'BaseAttributeID' THEN EventAttribute1.[BaseAttributeID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeCode' THEN EventAttribute1.[AttributeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeCode' THEN EventAttribute1.[AttributeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN EventAttribute1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN EventAttribute1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN EventAttribute1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN EventAttribute1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN EventAttribute1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN EventAttribute1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN EventAttribute1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN EventAttribute1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN EventAttribute1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN EventAttribute1.[Timestamp] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeName' THEN BaseAttribute1.[AttributeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeName' THEN BaseAttribute1.[AttributeName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeTypeCode' THEN BaseAttribute1.[AttributeTypeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeTypeCode' THEN BaseAttribute1.[AttributeTypeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'DataTypeCode' THEN BaseAttribute1.[DataTypeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'DataTypeCode' THEN BaseAttribute1.[DataTypeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Description' THEN BaseAttribute1.[Description] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Description' THEN BaseAttribute1.[Description] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'IsActive' THEN BaseAttribute1.[IsActive] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'IsActive' THEN BaseAttribute1.[IsActive] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeTypeName' THEN AttributeType1.[AttributeTypeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeTypeName' THEN AttributeType1.[AttributeTypeName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'DataTypeName' THEN DataType1.[DataTypeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'DataTypeName' THEN DataType1.[DataTypeName] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END


RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spEvents_GetAllEventAttributeDataByBaseAttributeID
	  @SqlErrorNumber int = 0 OUTPUT
	, @SortColumn sysname = 'BaseAttributeID'
	, @SortDirection nvarchar(20) = 'Ascending'
	, @IncludeInactive bit = 0
	, @BaseAttributeID uniqueidentifier
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets all EventAttribute data by a key.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0
IF (@SortColumn = '') SET @SortColumn='BaseAttributeID'

/*
** parameter validation
*/
IF (@BaseAttributeID IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

IF (@SortDirection = 'Random')
BEGIN
	SELECT
		  EventAttribute1.[BaseAttributeID]
		, EventAttribute1.[AttributeCode]
		, EventAttribute1.[CreatedByUserID]
		, EventAttribute1.[CreatedDate]
		, EventAttribute1.[LastModifiedByUserID]
		, EventAttribute1.[LastModifiedDate]
		, EventAttribute1.[Timestamp]
		, BaseAttribute1.[AttributeName]
		, BaseAttribute1.[AttributeTypeCode]
		, BaseAttribute1.[DataTypeCode]
		, BaseAttribute1.[Description]
		, BaseAttribute1.[IsActive]
		, AttributeType1.[AttributeTypeName]
		, DataType1.[DataTypeName]
	FROM
	      [dbo].[tblEvents_EventAttribute] EventAttribute1
	INNER JOIN [dbo].[tblCore_BaseAttribute] BaseAttribute1 ON BaseAttribute1.[BaseAttributeID]=EventAttribute1.[BaseAttributeID]
	INNER JOIN [dbo].[tlkpCore_AttributeType] AttributeType1 ON AttributeType1.[AttributeTypeCode]=BaseAttribute1.[AttributeTypeCode]
	INNER JOIN [dbo].[tlkpCore_DataType] DataType1 ON DataType1.[DataTypeCode]=BaseAttribute1.[DataTypeCode]
	WHERE 
		BaseAttribute1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN BaseAttribute1.[IsActive] ELSE 1 END
		AND EventAttribute1.[BaseAttributeID] = @BaseAttributeID

	ORDER BY NewID()
END
ELSE
BEGIN
	SELECT
		  EventAttribute1.[BaseAttributeID]
		, EventAttribute1.[AttributeCode]
		, EventAttribute1.[CreatedByUserID]
		, EventAttribute1.[CreatedDate]
		, EventAttribute1.[LastModifiedByUserID]
		, EventAttribute1.[LastModifiedDate]
		, EventAttribute1.[Timestamp]
		, BaseAttribute1.[AttributeName]
		, BaseAttribute1.[AttributeTypeCode]
		, BaseAttribute1.[DataTypeCode]
		, BaseAttribute1.[Description]
		, BaseAttribute1.[IsActive]
		, AttributeType1.[AttributeTypeName]
		, DataType1.[DataTypeName]
	FROM
	      [dbo].[tblEvents_EventAttribute] EventAttribute1
	INNER JOIN [dbo].[tblCore_BaseAttribute] BaseAttribute1 ON BaseAttribute1.[BaseAttributeID]=EventAttribute1.[BaseAttributeID]
	INNER JOIN [dbo].[tlkpCore_AttributeType] AttributeType1 ON AttributeType1.[AttributeTypeCode]=BaseAttribute1.[AttributeTypeCode]
	INNER JOIN [dbo].[tlkpCore_DataType] DataType1 ON DataType1.[DataTypeCode]=BaseAttribute1.[DataTypeCode]
	WHERE 
		BaseAttribute1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN BaseAttribute1.[IsActive] ELSE 1 END
		AND EventAttribute1.[BaseAttributeID] = @BaseAttributeID

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'BaseAttributeID' THEN EventAttribute1.[BaseAttributeID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'BaseAttributeID' THEN EventAttribute1.[BaseAttributeID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeCode' THEN EventAttribute1.[AttributeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeCode' THEN EventAttribute1.[AttributeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN EventAttribute1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN EventAttribute1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN EventAttribute1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN EventAttribute1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN EventAttribute1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN EventAttribute1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN EventAttribute1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN EventAttribute1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN EventAttribute1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN EventAttribute1.[Timestamp] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeName' THEN BaseAttribute1.[AttributeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeName' THEN BaseAttribute1.[AttributeName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeTypeCode' THEN BaseAttribute1.[AttributeTypeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeTypeCode' THEN BaseAttribute1.[AttributeTypeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'DataTypeCode' THEN BaseAttribute1.[DataTypeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'DataTypeCode' THEN BaseAttribute1.[DataTypeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Description' THEN BaseAttribute1.[Description] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Description' THEN BaseAttribute1.[Description] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'IsActive' THEN BaseAttribute1.[IsActive] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'IsActive' THEN BaseAttribute1.[IsActive] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeTypeName' THEN AttributeType1.[AttributeTypeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeTypeName' THEN AttributeType1.[AttributeTypeName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'DataTypeName' THEN DataType1.[DataTypeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'DataTypeName' THEN DataType1.[DataTypeName] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END


RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spEvents_GetAllEventAttributeDataByCriteria
	  @SqlErrorNumber int = 0 OUTPUT
	, @SortColumn sysname = 'AttributeName'
	, @SortDirection nvarchar(20) = 'Ascending'
	, @IncludeInactive bit = 0
	, @AttributeName nvarchar(100)
	, @AttributeTypeCode int
	, @DataTypeCode int
	, @LastModifiedDateStart datetime = getdate
	, @LastModifiedDateEnd datetime = getdate
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets all EventAttribute data by criteria.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0
IF (@SortColumn = '') SET @SortColumn='AttributeName'

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

IF (@SortDirection = 'Random')
BEGIN
	SELECT
		  EventAttribute1.[BaseAttributeID]
		, EventAttribute1.[AttributeCode]
		, EventAttribute1.[CreatedByUserID]
		, EventAttribute1.[CreatedDate]
		, EventAttribute1.[LastModifiedByUserID]
		, EventAttribute1.[LastModifiedDate]
		, EventAttribute1.[Timestamp]
		, BaseAttribute1.[AttributeName]
		, BaseAttribute1.[AttributeTypeCode]
		, BaseAttribute1.[DataTypeCode]
		, BaseAttribute1.[Description]
		, BaseAttribute1.[IsActive]
		, AttributeType1.[AttributeTypeName]
		, DataType1.[DataTypeName]
	FROM
	      [dbo].[tblEvents_EventAttribute] EventAttribute1
	INNER JOIN [dbo].[tblCore_BaseAttribute] BaseAttribute1 ON BaseAttribute1.[BaseAttributeID]=EventAttribute1.[BaseAttributeID]
	INNER JOIN [dbo].[tlkpCore_AttributeType] AttributeType1 ON AttributeType1.[AttributeTypeCode]=BaseAttribute1.[AttributeTypeCode]
	INNER JOIN [dbo].[tlkpCore_DataType] DataType1 ON DataType1.[DataTypeCode]=BaseAttribute1.[DataTypeCode]
	WHERE 
		BaseAttribute1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN BaseAttribute1.[IsActive] ELSE 1 END
		AND (@AttributeName IS NULL OR BaseAttribute1.[AttributeName] like '%' + @AttributeName + '%')
		AND (@AttributeTypeCode IS NULL OR BaseAttribute1.[AttributeTypeCode] = @AttributeTypeCode)
		AND (@DataTypeCode IS NULL OR BaseAttribute1.[DataTypeCode] = @DataTypeCode)
		AND ((@LastModifiedDateStart  IS NULL) OR (BaseAttribute1.[LastModifiedDate] >=  @LastModifiedDateStart))
		AND ((@LastModifiedDateEnd  IS NULL) OR (BaseAttribute1.[LastModifiedDate] <=  @LastModifiedDateEnd))

	ORDER BY NewID()
END
ELSE
BEGIN
	SELECT
		  EventAttribute1.[BaseAttributeID]
		, EventAttribute1.[AttributeCode]
		, EventAttribute1.[CreatedByUserID]
		, EventAttribute1.[CreatedDate]
		, EventAttribute1.[LastModifiedByUserID]
		, EventAttribute1.[LastModifiedDate]
		, EventAttribute1.[Timestamp]
		, BaseAttribute1.[AttributeName]
		, BaseAttribute1.[AttributeTypeCode]
		, BaseAttribute1.[DataTypeCode]
		, BaseAttribute1.[Description]
		, BaseAttribute1.[IsActive]
		, AttributeType1.[AttributeTypeName]
		, DataType1.[DataTypeName]
	FROM
	      [dbo].[tblEvents_EventAttribute] EventAttribute1
	INNER JOIN [dbo].[tblCore_BaseAttribute] BaseAttribute1 ON BaseAttribute1.[BaseAttributeID]=EventAttribute1.[BaseAttributeID]
	INNER JOIN [dbo].[tlkpCore_AttributeType] AttributeType1 ON AttributeType1.[AttributeTypeCode]=BaseAttribute1.[AttributeTypeCode]
	INNER JOIN [dbo].[tlkpCore_DataType] DataType1 ON DataType1.[DataTypeCode]=BaseAttribute1.[DataTypeCode]
	WHERE 
		BaseAttribute1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN BaseAttribute1.[IsActive] ELSE 1 END
		AND (@AttributeName IS NULL OR BaseAttribute1.[AttributeName] like '%' + @AttributeName + '%')
		AND (@AttributeTypeCode IS NULL OR BaseAttribute1.[AttributeTypeCode] = @AttributeTypeCode)
		AND (@DataTypeCode IS NULL OR BaseAttribute1.[DataTypeCode] = @DataTypeCode)
		AND ((@LastModifiedDateStart  IS NULL) OR (BaseAttribute1.[LastModifiedDate] >=  @LastModifiedDateStart))
		AND ((@LastModifiedDateEnd  IS NULL) OR (BaseAttribute1.[LastModifiedDate] <=  @LastModifiedDateEnd))

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'BaseAttributeID' THEN EventAttribute1.[BaseAttributeID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'BaseAttributeID' THEN EventAttribute1.[BaseAttributeID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeCode' THEN EventAttribute1.[AttributeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeCode' THEN EventAttribute1.[AttributeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN EventAttribute1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN EventAttribute1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN EventAttribute1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN EventAttribute1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN EventAttribute1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN EventAttribute1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN EventAttribute1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN EventAttribute1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN EventAttribute1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN EventAttribute1.[Timestamp] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeName' THEN BaseAttribute1.[AttributeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeName' THEN BaseAttribute1.[AttributeName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeTypeCode' THEN BaseAttribute1.[AttributeTypeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeTypeCode' THEN BaseAttribute1.[AttributeTypeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'DataTypeCode' THEN BaseAttribute1.[DataTypeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'DataTypeCode' THEN BaseAttribute1.[DataTypeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Description' THEN BaseAttribute1.[Description] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Description' THEN BaseAttribute1.[Description] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'IsActive' THEN BaseAttribute1.[IsActive] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'IsActive' THEN BaseAttribute1.[IsActive] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeTypeName' THEN AttributeType1.[AttributeTypeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeTypeName' THEN AttributeType1.[AttributeTypeName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'DataTypeName' THEN DataType1.[DataTypeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'DataTypeName' THEN DataType1.[DataTypeName] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END


RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spEvents_GetAllEventAttributeDataByDataTypeCode
	  @SqlErrorNumber int = 0 OUTPUT
	, @SortColumn sysname = 'DataTypeCode'
	, @SortDirection nvarchar(20) = 'Ascending'
	, @IncludeInactive bit = 0
	, @DataTypeCode int
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets all EventAttribute data by a key.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0
IF (@SortColumn = '') SET @SortColumn='DataTypeCode'

/*
** parameter validation
*/
IF (@DataTypeCode IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

IF (@SortDirection = 'Random')
BEGIN
	SELECT
		  EventAttribute1.[BaseAttributeID]
		, EventAttribute1.[AttributeCode]
		, EventAttribute1.[CreatedByUserID]
		, EventAttribute1.[CreatedDate]
		, EventAttribute1.[LastModifiedByUserID]
		, EventAttribute1.[LastModifiedDate]
		, EventAttribute1.[Timestamp]
		, BaseAttribute1.[AttributeName]
		, BaseAttribute1.[AttributeTypeCode]
		, BaseAttribute1.[DataTypeCode]
		, BaseAttribute1.[Description]
		, BaseAttribute1.[IsActive]
		, AttributeType1.[AttributeTypeName]
		, DataType1.[DataTypeName]
	FROM
	      [dbo].[tblEvents_EventAttribute] EventAttribute1
	INNER JOIN [dbo].[tblCore_BaseAttribute] BaseAttribute1 ON BaseAttribute1.[BaseAttributeID]=EventAttribute1.[BaseAttributeID]
	INNER JOIN [dbo].[tlkpCore_AttributeType] AttributeType1 ON AttributeType1.[AttributeTypeCode]=BaseAttribute1.[AttributeTypeCode]
	INNER JOIN [dbo].[tlkpCore_DataType] DataType1 ON DataType1.[DataTypeCode]=BaseAttribute1.[DataTypeCode]
	WHERE 
		BaseAttribute1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN BaseAttribute1.[IsActive] ELSE 1 END
		AND BaseAttribute1.[DataTypeCode] = @DataTypeCode

	ORDER BY NewID()
END
ELSE
BEGIN
	SELECT
		  EventAttribute1.[BaseAttributeID]
		, EventAttribute1.[AttributeCode]
		, EventAttribute1.[CreatedByUserID]
		, EventAttribute1.[CreatedDate]
		, EventAttribute1.[LastModifiedByUserID]
		, EventAttribute1.[LastModifiedDate]
		, EventAttribute1.[Timestamp]
		, BaseAttribute1.[AttributeName]
		, BaseAttribute1.[AttributeTypeCode]
		, BaseAttribute1.[DataTypeCode]
		, BaseAttribute1.[Description]
		, BaseAttribute1.[IsActive]
		, AttributeType1.[AttributeTypeName]
		, DataType1.[DataTypeName]
	FROM
	      [dbo].[tblEvents_EventAttribute] EventAttribute1
	INNER JOIN [dbo].[tblCore_BaseAttribute] BaseAttribute1 ON BaseAttribute1.[BaseAttributeID]=EventAttribute1.[BaseAttributeID]
	INNER JOIN [dbo].[tlkpCore_AttributeType] AttributeType1 ON AttributeType1.[AttributeTypeCode]=BaseAttribute1.[AttributeTypeCode]
	INNER JOIN [dbo].[tlkpCore_DataType] DataType1 ON DataType1.[DataTypeCode]=BaseAttribute1.[DataTypeCode]
	WHERE 
		BaseAttribute1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN BaseAttribute1.[IsActive] ELSE 1 END
		AND BaseAttribute1.[DataTypeCode] = @DataTypeCode

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'BaseAttributeID' THEN EventAttribute1.[BaseAttributeID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'BaseAttributeID' THEN EventAttribute1.[BaseAttributeID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeCode' THEN EventAttribute1.[AttributeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeCode' THEN EventAttribute1.[AttributeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN EventAttribute1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN EventAttribute1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN EventAttribute1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN EventAttribute1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN EventAttribute1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN EventAttribute1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN EventAttribute1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN EventAttribute1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN EventAttribute1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN EventAttribute1.[Timestamp] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeName' THEN BaseAttribute1.[AttributeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeName' THEN BaseAttribute1.[AttributeName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeTypeCode' THEN BaseAttribute1.[AttributeTypeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeTypeCode' THEN BaseAttribute1.[AttributeTypeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'DataTypeCode' THEN BaseAttribute1.[DataTypeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'DataTypeCode' THEN BaseAttribute1.[DataTypeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Description' THEN BaseAttribute1.[Description] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Description' THEN BaseAttribute1.[Description] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'IsActive' THEN BaseAttribute1.[IsActive] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'IsActive' THEN BaseAttribute1.[IsActive] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeTypeName' THEN AttributeType1.[AttributeTypeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeTypeName' THEN AttributeType1.[AttributeTypeName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'DataTypeName' THEN DataType1.[DataTypeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'DataTypeName' THEN DataType1.[DataTypeName] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END


RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spEvents_GetAllEventData
	  @SqlErrorNumber int = 0 OUTPUT
	, @SortColumn sysname = 'EventCode'
	, @SortDirection nvarchar(20) = 'Ascending'
	, @IncludeInactive bit = 0
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets all Event data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0
IF (@SortColumn = '') SET @SortColumn='EventCode'

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

IF (@SortDirection = 'Random')
BEGIN
	SELECT
		  Event1.[EventCode]
		, Event1.[EventName]
		, Event1.[EventTypeCode]
		, Event1.[Description]
		, Event1.[IsActive]
		, Event1.[CreatedByUserID]
		, Event1.[CreatedDate]
		, Event1.[LastModifiedByUserID]
		, Event1.[LastModifiedDate]
		, Event1.[Timestamp]
		, EventType1.[EventTypeName]
	FROM
	      [dbo].[tblEvents_Event] Event1
	INNER JOIN [dbo].[tlkpEvents_EventType] EventType1 ON EventType1.[EventTypeCode]=Event1.[EventTypeCode]
	WHERE 
		Event1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN Event1.[IsActive] ELSE 1 END

	ORDER BY NewID()
END
ELSE
BEGIN
	SELECT
		  Event1.[EventCode]
		, Event1.[EventName]
		, Event1.[EventTypeCode]
		, Event1.[Description]
		, Event1.[IsActive]
		, Event1.[CreatedByUserID]
		, Event1.[CreatedDate]
		, Event1.[LastModifiedByUserID]
		, Event1.[LastModifiedDate]
		, Event1.[Timestamp]
		, EventType1.[EventTypeName]
	FROM
	      [dbo].[tblEvents_Event] Event1
	INNER JOIN [dbo].[tlkpEvents_EventType] EventType1 ON EventType1.[EventTypeCode]=Event1.[EventTypeCode]
	WHERE 
		Event1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN Event1.[IsActive] ELSE 1 END

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'EventCode' THEN Event1.[EventCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'EventCode' THEN Event1.[EventCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'EventName' THEN Event1.[EventName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'EventName' THEN Event1.[EventName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'EventTypeCode' THEN Event1.[EventTypeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'EventTypeCode' THEN Event1.[EventTypeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Description' THEN Event1.[Description] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Description' THEN Event1.[Description] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'IsActive' THEN Event1.[IsActive] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'IsActive' THEN Event1.[IsActive] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN Event1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN Event1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN Event1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN Event1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN Event1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN Event1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN Event1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN Event1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN Event1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN Event1.[Timestamp] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'EventTypeName' THEN EventType1.[EventTypeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'EventTypeName' THEN EventType1.[EventTypeName] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END


RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spEvents_GetAllEventDataByCriteria
	  @SqlErrorNumber int = 0 OUTPUT
	, @SortColumn sysname = 'EventName'
	, @SortDirection nvarchar(20) = 'Ascending'
	, @IncludeInactive bit = 0
	, @EventName nvarchar(255)
	, @EventTypeCode int
	, @LastModifiedDateStart datetime = getdate
	, @LastModifiedDateEnd datetime = getdate
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets all Event data by criteria.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0
IF (@SortColumn = '') SET @SortColumn='EventName'

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

IF (@SortDirection = 'Random')
BEGIN
	SELECT
		  Event1.[EventCode]
		, Event1.[EventName]
		, Event1.[EventTypeCode]
		, Event1.[Description]
		, Event1.[IsActive]
		, Event1.[CreatedByUserID]
		, Event1.[CreatedDate]
		, Event1.[LastModifiedByUserID]
		, Event1.[LastModifiedDate]
		, Event1.[Timestamp]
		, EventType1.[EventTypeName]
	FROM
	      [dbo].[tblEvents_Event] Event1
	INNER JOIN [dbo].[tlkpEvents_EventType] EventType1 ON EventType1.[EventTypeCode]=Event1.[EventTypeCode]
	WHERE 
		Event1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN Event1.[IsActive] ELSE 1 END
		AND (@EventName IS NULL OR Event1.[EventName] like '%' + @EventName + '%')
		AND (@EventTypeCode IS NULL OR Event1.[EventTypeCode] = @EventTypeCode)
		AND ((@LastModifiedDateStart  IS NULL) OR (Event1.[LastModifiedDate] >=  @LastModifiedDateStart))
		AND ((@LastModifiedDateEnd  IS NULL) OR (Event1.[LastModifiedDate] <=  @LastModifiedDateEnd))

	ORDER BY NewID()
END
ELSE
BEGIN
	SELECT
		  Event1.[EventCode]
		, Event1.[EventName]
		, Event1.[EventTypeCode]
		, Event1.[Description]
		, Event1.[IsActive]
		, Event1.[CreatedByUserID]
		, Event1.[CreatedDate]
		, Event1.[LastModifiedByUserID]
		, Event1.[LastModifiedDate]
		, Event1.[Timestamp]
		, EventType1.[EventTypeName]
	FROM
	      [dbo].[tblEvents_Event] Event1
	INNER JOIN [dbo].[tlkpEvents_EventType] EventType1 ON EventType1.[EventTypeCode]=Event1.[EventTypeCode]
	WHERE 
		Event1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN Event1.[IsActive] ELSE 1 END
		AND (@EventName IS NULL OR Event1.[EventName] like '%' + @EventName + '%')
		AND (@EventTypeCode IS NULL OR Event1.[EventTypeCode] = @EventTypeCode)
		AND ((@LastModifiedDateStart  IS NULL) OR (Event1.[LastModifiedDate] >=  @LastModifiedDateStart))
		AND ((@LastModifiedDateEnd  IS NULL) OR (Event1.[LastModifiedDate] <=  @LastModifiedDateEnd))

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'EventCode' THEN Event1.[EventCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'EventCode' THEN Event1.[EventCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'EventName' THEN Event1.[EventName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'EventName' THEN Event1.[EventName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'EventTypeCode' THEN Event1.[EventTypeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'EventTypeCode' THEN Event1.[EventTypeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Description' THEN Event1.[Description] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Description' THEN Event1.[Description] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'IsActive' THEN Event1.[IsActive] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'IsActive' THEN Event1.[IsActive] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN Event1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN Event1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN Event1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN Event1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN Event1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN Event1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN Event1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN Event1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN Event1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN Event1.[Timestamp] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'EventTypeName' THEN EventType1.[EventTypeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'EventTypeName' THEN EventType1.[EventTypeName] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END


RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spEvents_GetAllEventDataByEventTypeCode
	  @SqlErrorNumber int = 0 OUTPUT
	, @SortColumn sysname = 'EventTypeCode'
	, @SortDirection nvarchar(20) = 'Ascending'
	, @IncludeInactive bit = 0
	, @EventTypeCode int
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets all Event data by a key.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0
IF (@SortColumn = '') SET @SortColumn='EventTypeCode'

/*
** parameter validation
*/
IF (@EventTypeCode IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

IF (@SortDirection = 'Random')
BEGIN
	SELECT
		  Event1.[EventCode]
		, Event1.[EventName]
		, Event1.[EventTypeCode]
		, Event1.[Description]
		, Event1.[IsActive]
		, Event1.[CreatedByUserID]
		, Event1.[CreatedDate]
		, Event1.[LastModifiedByUserID]
		, Event1.[LastModifiedDate]
		, Event1.[Timestamp]
		, EventType1.[EventTypeName]
	FROM
	      [dbo].[tblEvents_Event] Event1
	INNER JOIN [dbo].[tlkpEvents_EventType] EventType1 ON EventType1.[EventTypeCode]=Event1.[EventTypeCode]
	WHERE 
		Event1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN Event1.[IsActive] ELSE 1 END
		AND Event1.[EventTypeCode] = @EventTypeCode

	ORDER BY NewID()
END
ELSE
BEGIN
	SELECT
		  Event1.[EventCode]
		, Event1.[EventName]
		, Event1.[EventTypeCode]
		, Event1.[Description]
		, Event1.[IsActive]
		, Event1.[CreatedByUserID]
		, Event1.[CreatedDate]
		, Event1.[LastModifiedByUserID]
		, Event1.[LastModifiedDate]
		, Event1.[Timestamp]
		, EventType1.[EventTypeName]
	FROM
	      [dbo].[tblEvents_Event] Event1
	INNER JOIN [dbo].[tlkpEvents_EventType] EventType1 ON EventType1.[EventTypeCode]=Event1.[EventTypeCode]
	WHERE 
		Event1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN Event1.[IsActive] ELSE 1 END
		AND Event1.[EventTypeCode] = @EventTypeCode

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'EventCode' THEN Event1.[EventCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'EventCode' THEN Event1.[EventCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'EventName' THEN Event1.[EventName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'EventName' THEN Event1.[EventName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'EventTypeCode' THEN Event1.[EventTypeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'EventTypeCode' THEN Event1.[EventTypeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Description' THEN Event1.[Description] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Description' THEN Event1.[Description] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'IsActive' THEN Event1.[IsActive] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'IsActive' THEN Event1.[IsActive] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN Event1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN Event1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN Event1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN Event1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN Event1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN Event1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN Event1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN Event1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN Event1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN Event1.[Timestamp] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'EventTypeName' THEN EventType1.[EventTypeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'EventTypeName' THEN EventType1.[EventTypeName] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END


RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spEvents_GetAllEventTypeData
	  @SqlErrorNumber int = 0 OUTPUT
	, @SortColumn sysname = 'EventTypeCode'
	, @SortDirection nvarchar(20) = 'Ascending'
	, @IncludeInactive bit = 0
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets all EventType data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0
IF (@SortColumn = '') SET @SortColumn='EventTypeCode'

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

IF (@SortDirection = 'Random')
BEGIN
	SELECT
		  EventType1.[EventTypeCode]
		, EventType1.[EventTypeName]
		, EventType1.[Description]
		, EventType1.[IsActive]
		, EventType1.[CreatedByUserID]
		, EventType1.[CreatedDate]
		, EventType1.[LastModifiedByUserID]
		, EventType1.[LastModifiedDate]
		, EventType1.[Timestamp]
	FROM
	      [dbo].[tlkpEvents_EventType] EventType1
	WHERE 
		EventType1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN EventType1.[IsActive] ELSE 1 END

	ORDER BY NewID()
END
ELSE
BEGIN
	SELECT
		  EventType1.[EventTypeCode]
		, EventType1.[EventTypeName]
		, EventType1.[Description]
		, EventType1.[IsActive]
		, EventType1.[CreatedByUserID]
		, EventType1.[CreatedDate]
		, EventType1.[LastModifiedByUserID]
		, EventType1.[LastModifiedDate]
		, EventType1.[Timestamp]
	FROM
	      [dbo].[tlkpEvents_EventType] EventType1
	WHERE 
		EventType1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN EventType1.[IsActive] ELSE 1 END

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'EventTypeCode' THEN EventType1.[EventTypeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'EventTypeCode' THEN EventType1.[EventTypeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'EventTypeName' THEN EventType1.[EventTypeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'EventTypeName' THEN EventType1.[EventTypeName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Description' THEN EventType1.[Description] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Description' THEN EventType1.[Description] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'IsActive' THEN EventType1.[IsActive] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'IsActive' THEN EventType1.[IsActive] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN EventType1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN EventType1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN EventType1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN EventType1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN EventType1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN EventType1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN EventType1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN EventType1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN EventType1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN EventType1.[Timestamp] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END


RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spEvents_GetManyAuditAttributeValueLogDataByCriteria
	  @SqlErrorNumber int = 0 OUTPUT
	, @StartIndex int = 1
	, @PageSize int = 50
	, @MaximumListSize int = 0
	, @MaximumListSizeExceeded bit = 0 OUTPUT
	, @TotalRecords int = 0 OUTPUT
	, @SortColumn sysname = 'AttributeValue'
	, @SortDirection nvarchar(20) = 'Ascending'
	, @AttributeValue nvarchar(1000) = NULL
	, @LastModifiedDateStart datetime = getdate
	, @LastModifiedDateEnd datetime = getdate
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets many AuditAttributeValueLog data by criteria.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

DECLARE @vEndIndex int
IF (@StartIndex < 1) SET @StartIndex=1
IF (@PageSize < 1) SET @PageSize=1
SET @vEndIndex = @StartIndex + @Pagesize
IF (@SortColumn = '') SET @SortColumn='AttributeValue'

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

DECLARE @OrderedRecords TABLE
(
     SearchOrderID int IDENTITY (1, 1) NOT NULL
    , AuditAttributeValueLogID uniqueidentifier
)
IF (@SortDirection = 'Random')
BEGIN
	INSERT INTO @OrderedRecords (AuditAttributeValueLogID)
	SELECT
		  AuditAttributeValueLog1.[AuditAttributeValueLogID]
	FROM
	      [dbo].[tblEvents_AuditAttributeValueLog] AuditAttributeValueLog1
	WHERE 
		(@AttributeValue IS NULL OR AuditAttributeValueLog1.[AttributeValue] like '%' + @AttributeValue + '%')
		AND ((@LastModifiedDateStart  IS NULL) OR (AuditAttributeValueLog1.[LastModifiedDate] >=  @LastModifiedDateStart))
		AND ((@LastModifiedDateEnd  IS NULL) OR (AuditAttributeValueLog1.[LastModifiedDate] <=  @LastModifiedDateEnd))

	ORDER BY NewID()
END
ELSE
BEGIN
	INSERT INTO @OrderedRecords (AuditAttributeValueLogID)
	SELECT
		  AuditAttributeValueLog1.[AuditAttributeValueLogID]
	FROM
	      [dbo].[tblEvents_AuditAttributeValueLog] AuditAttributeValueLog1
	WHERE 
		(@AttributeValue IS NULL OR AuditAttributeValueLog1.[AttributeValue] like '%' + @AttributeValue + '%')
		AND ((@LastModifiedDateStart  IS NULL) OR (AuditAttributeValueLog1.[LastModifiedDate] >=  @LastModifiedDateStart))
		AND ((@LastModifiedDateEnd  IS NULL) OR (AuditAttributeValueLog1.[LastModifiedDate] <=  @LastModifiedDateEnd))

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AuditAttributeValueLogID' THEN AuditAttributeValueLog1.[AuditAttributeValueLogID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AuditAttributeValueLogID' THEN AuditAttributeValueLog1.[AuditAttributeValueLogID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AuditLogID' THEN AuditAttributeValueLog1.[AuditLogID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AuditLogID' THEN AuditAttributeValueLog1.[AuditLogID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'BaseAttributeID' THEN AuditAttributeValueLog1.[BaseAttributeID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'BaseAttributeID' THEN AuditAttributeValueLog1.[BaseAttributeID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeValue' THEN AuditAttributeValueLog1.[AttributeValue] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeValue' THEN AuditAttributeValueLog1.[AttributeValue] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN AuditAttributeValueLog1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN AuditAttributeValueLog1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN AuditAttributeValueLog1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN AuditAttributeValueLog1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN AuditAttributeValueLog1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN AuditAttributeValueLog1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN AuditAttributeValueLog1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN AuditAttributeValueLog1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN AuditAttributeValueLog1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN AuditAttributeValueLog1.[Timestamp] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END

BEGIN
	SET @TotalRecords = (SELECT Count (*) FROM @OrderedRecords)
	IF @MaximumListSize > 0
	BEGIN
		IF @TotalRecords > @MaximumListSize
		BEGIN
			SET @MaximumListSizeExceeded = 1
			SET @TotalRecords = @MaximumListSize
		END
	END

	/* get search results */
	SELECT
		  AuditAttributeValueLog1.[AuditAttributeValueLogID]
		, AuditAttributeValueLog1.[AuditLogID]
		, AuditAttributeValueLog1.[BaseAttributeID]
		, AuditAttributeValueLog1.[AttributeValue]
		, AuditAttributeValueLog1.[CreatedByUserID]
		, AuditAttributeValueLog1.[CreatedDate]
		, AuditAttributeValueLog1.[LastModifiedByUserID]
		, AuditAttributeValueLog1.[LastModifiedDate]
		, AuditAttributeValueLog1.[Timestamp]
	FROM
	      [dbo].[tblEvents_AuditAttributeValueLog] AuditAttributeValueLog1
	INNER JOIN @OrderedRecords search ON search.[AuditAttributeValueLogID] = AuditAttributeValueLog1.[AuditAttributeValueLogID]
	WHERE
		search.SearchOrderID  >= @StartIndex AND
		search.SearchOrderID  < @vEndIndex
	ORDER BY
		search.SearchOrderID

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spEvents_GetManyAuditLogDataByCriteria
	  @SqlErrorNumber int = 0 OUTPUT
	, @StartIndex int = 1
	, @PageSize int = 50
	, @MaximumListSize int = 0
	, @MaximumListSizeExceeded bit = 0 OUTPUT
	, @TotalRecords int = 0 OUTPUT
	, @SortColumn sysname = 'EventCode'
	, @SortDirection nvarchar(20) = 'Ascending'
	, @EventCode int
	, @LastModifiedDateStart datetime = getdate
	, @LastModifiedDateEnd datetime = getdate
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets many AuditLog data by criteria.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

DECLARE @vEndIndex int
IF (@StartIndex < 1) SET @StartIndex=1
IF (@PageSize < 1) SET @PageSize=1
SET @vEndIndex = @StartIndex + @Pagesize
IF (@SortColumn = '') SET @SortColumn='EventCode'

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

DECLARE @OrderedRecords TABLE
(
     SearchOrderID int IDENTITY (1, 1) NOT NULL
    , AuditLogID uniqueidentifier
)
IF (@SortDirection = 'Random')
BEGIN
	INSERT INTO @OrderedRecords (AuditLogID)
	SELECT
		  AuditLog1.[AuditLogID]
	FROM
	      [dbo].[tblEvents_AuditLog] AuditLog1
	INNER JOIN [dbo].[tblEvents_Event] Event1 ON Event1.[EventCode]=AuditLog1.[EventCode]
	WHERE 
		(@EventCode IS NULL OR AuditLog1.[EventCode] = @EventCode)
		AND ((@LastModifiedDateStart  IS NULL) OR (AuditLog1.[LastModifiedDate] >=  @LastModifiedDateStart))
		AND ((@LastModifiedDateEnd  IS NULL) OR (AuditLog1.[LastModifiedDate] <=  @LastModifiedDateEnd))

	ORDER BY NewID()
END
ELSE
BEGIN
	INSERT INTO @OrderedRecords (AuditLogID)
	SELECT
		  AuditLog1.[AuditLogID]
	FROM
	      [dbo].[tblEvents_AuditLog] AuditLog1
	INNER JOIN [dbo].[tblEvents_Event] Event1 ON Event1.[EventCode]=AuditLog1.[EventCode]
	WHERE 
		(@EventCode IS NULL OR AuditLog1.[EventCode] = @EventCode)
		AND ((@LastModifiedDateStart  IS NULL) OR (AuditLog1.[LastModifiedDate] >=  @LastModifiedDateStart))
		AND ((@LastModifiedDateEnd  IS NULL) OR (AuditLog1.[LastModifiedDate] <=  @LastModifiedDateEnd))

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AuditLogID' THEN AuditLog1.[AuditLogID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AuditLogID' THEN AuditLog1.[AuditLogID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'EventCode' THEN AuditLog1.[EventCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'EventCode' THEN AuditLog1.[EventCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN AuditLog1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN AuditLog1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN AuditLog1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN AuditLog1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN AuditLog1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN AuditLog1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN AuditLog1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN AuditLog1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN AuditLog1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN AuditLog1.[Timestamp] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'EventName' THEN Event1.[EventName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'EventName' THEN Event1.[EventName] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END

BEGIN
	SET @TotalRecords = (SELECT Count (*) FROM @OrderedRecords)
	IF @MaximumListSize > 0
	BEGIN
		IF @TotalRecords > @MaximumListSize
		BEGIN
			SET @MaximumListSizeExceeded = 1
			SET @TotalRecords = @MaximumListSize
		END
	END

	/* get search results */
	SELECT
		  AuditLog1.[AuditLogID]
		, AuditLog1.[EventCode]
		, AuditLog1.[CreatedByUserID]
		, AuditLog1.[CreatedDate]
		, AuditLog1.[LastModifiedByUserID]
		, AuditLog1.[LastModifiedDate]
		, AuditLog1.[Timestamp]
		, Event1.[EventName]
	FROM
	      [dbo].[tblEvents_AuditLog] AuditLog1
	INNER JOIN [dbo].[tblEvents_Event] Event1 ON Event1.[EventCode]=AuditLog1.[EventCode]
	INNER JOIN @OrderedRecords search ON search.[AuditLogID] = AuditLog1.[AuditLogID]
	WHERE
		search.SearchOrderID  >= @StartIndex AND
		search.SearchOrderID  < @vEndIndex
	ORDER BY
		search.SearchOrderID

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spEvents_GetManyEventAttributeDataByCriteria
	  @SqlErrorNumber int = 0 OUTPUT
	, @StartIndex int = 1
	, @PageSize int = 50
	, @MaximumListSize int = 0
	, @MaximumListSizeExceeded bit = 0 OUTPUT
	, @TotalRecords int = 0 OUTPUT
	, @SortColumn sysname = 'AttributeName'
	, @SortDirection nvarchar(20) = 'Ascending'
	, @IncludeInactive bit = 0
	, @AttributeName nvarchar(100)
	, @AttributeTypeCode int
	, @DataTypeCode int
	, @LastModifiedDateStart datetime = getdate
	, @LastModifiedDateEnd datetime = getdate
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets many EventAttribute data by criteria.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

DECLARE @vEndIndex int
IF (@StartIndex < 1) SET @StartIndex=1
IF (@PageSize < 1) SET @PageSize=1
SET @vEndIndex = @StartIndex + @Pagesize
IF (@SortColumn = '') SET @SortColumn='AttributeName'

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

DECLARE @OrderedRecords TABLE
(
     SearchOrderID int IDENTITY (1, 1) NOT NULL
    , BaseAttributeID uniqueidentifier
)
IF (@SortDirection = 'Random')
BEGIN
	INSERT INTO @OrderedRecords (BaseAttributeID)
	SELECT
		  EventAttribute1.[BaseAttributeID]
	FROM
	      [dbo].[tblEvents_EventAttribute] EventAttribute1
	INNER JOIN [dbo].[tblCore_BaseAttribute] BaseAttribute1 ON BaseAttribute1.[BaseAttributeID]=EventAttribute1.[BaseAttributeID]
	INNER JOIN [dbo].[tlkpCore_AttributeType] AttributeType1 ON AttributeType1.[AttributeTypeCode]=BaseAttribute1.[AttributeTypeCode]
	INNER JOIN [dbo].[tlkpCore_DataType] DataType1 ON DataType1.[DataTypeCode]=BaseAttribute1.[DataTypeCode]
	WHERE 
		BaseAttribute1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN BaseAttribute1.[IsActive] ELSE 1 END
		AND (@AttributeName IS NULL OR BaseAttribute1.[AttributeName] like '%' + @AttributeName + '%')
		AND (@AttributeTypeCode IS NULL OR BaseAttribute1.[AttributeTypeCode] = @AttributeTypeCode)
		AND (@DataTypeCode IS NULL OR BaseAttribute1.[DataTypeCode] = @DataTypeCode)
		AND ((@LastModifiedDateStart  IS NULL) OR (BaseAttribute1.[LastModifiedDate] >=  @LastModifiedDateStart))
		AND ((@LastModifiedDateEnd  IS NULL) OR (BaseAttribute1.[LastModifiedDate] <=  @LastModifiedDateEnd))

	ORDER BY NewID()
END
ELSE
BEGIN
	INSERT INTO @OrderedRecords (BaseAttributeID)
	SELECT
		  EventAttribute1.[BaseAttributeID]
	FROM
	      [dbo].[tblEvents_EventAttribute] EventAttribute1
	INNER JOIN [dbo].[tblCore_BaseAttribute] BaseAttribute1 ON BaseAttribute1.[BaseAttributeID]=EventAttribute1.[BaseAttributeID]
	INNER JOIN [dbo].[tlkpCore_AttributeType] AttributeType1 ON AttributeType1.[AttributeTypeCode]=BaseAttribute1.[AttributeTypeCode]
	INNER JOIN [dbo].[tlkpCore_DataType] DataType1 ON DataType1.[DataTypeCode]=BaseAttribute1.[DataTypeCode]
	WHERE 
		BaseAttribute1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN BaseAttribute1.[IsActive] ELSE 1 END
		AND (@AttributeName IS NULL OR BaseAttribute1.[AttributeName] like '%' + @AttributeName + '%')
		AND (@AttributeTypeCode IS NULL OR BaseAttribute1.[AttributeTypeCode] = @AttributeTypeCode)
		AND (@DataTypeCode IS NULL OR BaseAttribute1.[DataTypeCode] = @DataTypeCode)
		AND ((@LastModifiedDateStart  IS NULL) OR (BaseAttribute1.[LastModifiedDate] >=  @LastModifiedDateStart))
		AND ((@LastModifiedDateEnd  IS NULL) OR (BaseAttribute1.[LastModifiedDate] <=  @LastModifiedDateEnd))

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'BaseAttributeID' THEN EventAttribute1.[BaseAttributeID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'BaseAttributeID' THEN EventAttribute1.[BaseAttributeID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeCode' THEN EventAttribute1.[AttributeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeCode' THEN EventAttribute1.[AttributeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN EventAttribute1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN EventAttribute1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN EventAttribute1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN EventAttribute1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN EventAttribute1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN EventAttribute1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN EventAttribute1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN EventAttribute1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN EventAttribute1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN EventAttribute1.[Timestamp] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeName' THEN BaseAttribute1.[AttributeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeName' THEN BaseAttribute1.[AttributeName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeTypeCode' THEN BaseAttribute1.[AttributeTypeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeTypeCode' THEN BaseAttribute1.[AttributeTypeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'DataTypeCode' THEN BaseAttribute1.[DataTypeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'DataTypeCode' THEN BaseAttribute1.[DataTypeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Description' THEN BaseAttribute1.[Description] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Description' THEN BaseAttribute1.[Description] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'IsActive' THEN BaseAttribute1.[IsActive] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'IsActive' THEN BaseAttribute1.[IsActive] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AttributeTypeName' THEN AttributeType1.[AttributeTypeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AttributeTypeName' THEN AttributeType1.[AttributeTypeName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'DataTypeName' THEN DataType1.[DataTypeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'DataTypeName' THEN DataType1.[DataTypeName] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END

BEGIN
	SET @TotalRecords = (SELECT Count (*) FROM @OrderedRecords)
	IF @MaximumListSize > 0
	BEGIN
		IF @TotalRecords > @MaximumListSize
		BEGIN
			SET @MaximumListSizeExceeded = 1
			SET @TotalRecords = @MaximumListSize
		END
	END

	/* get search results */
	SELECT
		  EventAttribute1.[BaseAttributeID]
		, EventAttribute1.[AttributeCode]
		, EventAttribute1.[CreatedByUserID]
		, EventAttribute1.[CreatedDate]
		, EventAttribute1.[LastModifiedByUserID]
		, EventAttribute1.[LastModifiedDate]
		, EventAttribute1.[Timestamp]
		, BaseAttribute1.[AttributeName]
		, BaseAttribute1.[AttributeTypeCode]
		, BaseAttribute1.[DataTypeCode]
		, BaseAttribute1.[Description]
		, BaseAttribute1.[IsActive]
		, AttributeType1.[AttributeTypeName]
		, DataType1.[DataTypeName]
	FROM
	      [dbo].[tblEvents_EventAttribute] EventAttribute1
	INNER JOIN [dbo].[tblCore_BaseAttribute] BaseAttribute1 ON BaseAttribute1.[BaseAttributeID]=EventAttribute1.[BaseAttributeID]
	INNER JOIN [dbo].[tlkpCore_AttributeType] AttributeType1 ON AttributeType1.[AttributeTypeCode]=BaseAttribute1.[AttributeTypeCode]
	INNER JOIN [dbo].[tlkpCore_DataType] DataType1 ON DataType1.[DataTypeCode]=BaseAttribute1.[DataTypeCode]
	INNER JOIN @OrderedRecords search ON search.[BaseAttributeID] = EventAttribute1.[BaseAttributeID]
	WHERE
		search.SearchOrderID  >= @StartIndex AND
		search.SearchOrderID  < @vEndIndex
	ORDER BY
		search.SearchOrderID

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spEvents_GetManyEventDataByCriteria
	  @SqlErrorNumber int = 0 OUTPUT
	, @StartIndex int = 1
	, @PageSize int = 50
	, @MaximumListSize int = 0
	, @MaximumListSizeExceeded bit = 0 OUTPUT
	, @TotalRecords int = 0 OUTPUT
	, @SortColumn sysname = 'EventName'
	, @SortDirection nvarchar(20) = 'Ascending'
	, @IncludeInactive bit = 0
	, @EventName nvarchar(255)
	, @EventTypeCode int
	, @LastModifiedDateStart datetime = getdate
	, @LastModifiedDateEnd datetime = getdate
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets many Event data by criteria.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

DECLARE @vEndIndex int
IF (@StartIndex < 1) SET @StartIndex=1
IF (@PageSize < 1) SET @PageSize=1
SET @vEndIndex = @StartIndex + @Pagesize
IF (@SortColumn = '') SET @SortColumn='EventName'

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

DECLARE @OrderedRecords TABLE
(
     SearchOrderID int IDENTITY (1, 1) NOT NULL
    , EventCode int
)
IF (@SortDirection = 'Random')
BEGIN
	INSERT INTO @OrderedRecords (EventCode)
	SELECT
		  Event1.[EventCode]
	FROM
	      [dbo].[tblEvents_Event] Event1
	INNER JOIN [dbo].[tlkpEvents_EventType] EventType1 ON EventType1.[EventTypeCode]=Event1.[EventTypeCode]
	WHERE 
		Event1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN Event1.[IsActive] ELSE 1 END
		AND (@EventName IS NULL OR Event1.[EventName] like '%' + @EventName + '%')
		AND (@EventTypeCode IS NULL OR Event1.[EventTypeCode] = @EventTypeCode)
		AND ((@LastModifiedDateStart  IS NULL) OR (Event1.[LastModifiedDate] >=  @LastModifiedDateStart))
		AND ((@LastModifiedDateEnd  IS NULL) OR (Event1.[LastModifiedDate] <=  @LastModifiedDateEnd))

	ORDER BY NewID()
END
ELSE
BEGIN
	INSERT INTO @OrderedRecords (EventCode)
	SELECT
		  Event1.[EventCode]
	FROM
	      [dbo].[tblEvents_Event] Event1
	INNER JOIN [dbo].[tlkpEvents_EventType] EventType1 ON EventType1.[EventTypeCode]=Event1.[EventTypeCode]
	WHERE 
		Event1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN Event1.[IsActive] ELSE 1 END
		AND (@EventName IS NULL OR Event1.[EventName] like '%' + @EventName + '%')
		AND (@EventTypeCode IS NULL OR Event1.[EventTypeCode] = @EventTypeCode)
		AND ((@LastModifiedDateStart  IS NULL) OR (Event1.[LastModifiedDate] >=  @LastModifiedDateStart))
		AND ((@LastModifiedDateEnd  IS NULL) OR (Event1.[LastModifiedDate] <=  @LastModifiedDateEnd))

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'EventCode' THEN Event1.[EventCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'EventCode' THEN Event1.[EventCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'EventName' THEN Event1.[EventName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'EventName' THEN Event1.[EventName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'EventTypeCode' THEN Event1.[EventTypeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'EventTypeCode' THEN Event1.[EventTypeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Description' THEN Event1.[Description] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Description' THEN Event1.[Description] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'IsActive' THEN Event1.[IsActive] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'IsActive' THEN Event1.[IsActive] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN Event1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN Event1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN Event1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN Event1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN Event1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN Event1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN Event1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN Event1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN Event1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN Event1.[Timestamp] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'EventTypeName' THEN EventType1.[EventTypeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'EventTypeName' THEN EventType1.[EventTypeName] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END

BEGIN
	SET @TotalRecords = (SELECT Count (*) FROM @OrderedRecords)
	IF @MaximumListSize > 0
	BEGIN
		IF @TotalRecords > @MaximumListSize
		BEGIN
			SET @MaximumListSizeExceeded = 1
			SET @TotalRecords = @MaximumListSize
		END
	END

	/* get search results */
	SELECT
		  Event1.[EventCode]
		, Event1.[EventName]
		, Event1.[EventTypeCode]
		, Event1.[Description]
		, Event1.[IsActive]
		, Event1.[CreatedByUserID]
		, Event1.[CreatedDate]
		, Event1.[LastModifiedByUserID]
		, Event1.[LastModifiedDate]
		, Event1.[Timestamp]
		, EventType1.[EventTypeName]
	FROM
	      [dbo].[tblEvents_Event] Event1
	INNER JOIN [dbo].[tlkpEvents_EventType] EventType1 ON EventType1.[EventTypeCode]=Event1.[EventTypeCode]
	INNER JOIN @OrderedRecords search ON search.[EventCode] = Event1.[EventCode]
	WHERE
		search.SearchOrderID  >= @StartIndex AND
		search.SearchOrderID  < @vEndIndex
	ORDER BY
		search.SearchOrderID

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spEvents_GetOneAuditAttributeValueLog
	  @SqlErrorNumber int = 0 OUTPUT
	, @AuditAttributeValueLogID uniqueidentifier
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets a single AuditAttributeValueLog by an index.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@AuditAttributeValueLogID IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	SELECT
		  AuditAttributeValueLog1.[AuditAttributeValueLogID]
		, AuditAttributeValueLog1.[AuditLogID]
		, AuditAttributeValueLog1.[BaseAttributeID]
		, AuditAttributeValueLog1.[AttributeValue]
		, AuditAttributeValueLog1.[CreatedByUserID]
		, AuditAttributeValueLog1.[CreatedDate]
		, AuditAttributeValueLog1.[LastModifiedByUserID]
		, AuditAttributeValueLog1.[LastModifiedDate]
		, AuditAttributeValueLog1.[Timestamp]
	FROM
	      [dbo].[tblEvents_AuditAttributeValueLog] AuditAttributeValueLog1
	WHERE AuditAttributeValueLog1.[AuditAttributeValueLogID] =  @AuditAttributeValueLogID

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spEvents_GetOneAuditLog
	  @SqlErrorNumber int = 0 OUTPUT
	, @AuditLogID uniqueidentifier
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets a single AuditLog by an index.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@AuditLogID IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	SELECT
		  AuditLog1.[AuditLogID]
		, AuditLog1.[EventCode]
		, AuditLog1.[CreatedByUserID]
		, AuditLog1.[CreatedDate]
		, AuditLog1.[LastModifiedByUserID]
		, AuditLog1.[LastModifiedDate]
		, AuditLog1.[Timestamp]
		, Event1.[EventName]
	FROM
	      [dbo].[tblEvents_AuditLog] AuditLog1
	INNER JOIN [dbo].[tblEvents_Event] Event1 ON Event1.[EventCode]=AuditLog1.[EventCode]
	WHERE AuditLog1.[AuditLogID] =  @AuditLogID

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spEvents_GetOneEvent
	  @SqlErrorNumber int = 0 OUTPUT
	, @EventCode int
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets a single Event by an index.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@EventCode IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	SELECT
		  Event1.[EventCode]
		, Event1.[EventName]
		, Event1.[EventTypeCode]
		, Event1.[Description]
		, Event1.[IsActive]
		, Event1.[CreatedByUserID]
		, Event1.[CreatedDate]
		, Event1.[LastModifiedByUserID]
		, Event1.[LastModifiedDate]
		, Event1.[Timestamp]
		, EventType1.[EventTypeName]
	FROM
	      [dbo].[tblEvents_Event] Event1
	INNER JOIN [dbo].[tlkpEvents_EventType] EventType1 ON EventType1.[EventTypeCode]=Event1.[EventTypeCode]
	WHERE Event1.[EventCode] =  @EventCode

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spEvents_GetOneEventAttribute
	  @SqlErrorNumber int = 0 OUTPUT
	, @BaseAttributeID uniqueidentifier
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets a single EventAttribute by an index.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@BaseAttributeID IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	SELECT
		  EventAttribute1.[BaseAttributeID]
		, EventAttribute1.[AttributeCode]
		, EventAttribute1.[CreatedByUserID]
		, EventAttribute1.[CreatedDate]
		, EventAttribute1.[LastModifiedByUserID]
		, EventAttribute1.[LastModifiedDate]
		, EventAttribute1.[Timestamp]
		, BaseAttribute1.[AttributeName]
		, BaseAttribute1.[AttributeTypeCode]
		, BaseAttribute1.[DataTypeCode]
		, BaseAttribute1.[Description]
		, BaseAttribute1.[IsActive]
		, AttributeType1.[AttributeTypeName]
		, DataType1.[DataTypeName]
	FROM
	      [dbo].[tblEvents_EventAttribute] EventAttribute1
	INNER JOIN [dbo].[tblCore_BaseAttribute] BaseAttribute1 ON BaseAttribute1.[BaseAttributeID]=EventAttribute1.[BaseAttributeID]
	INNER JOIN [dbo].[tlkpCore_AttributeType] AttributeType1 ON AttributeType1.[AttributeTypeCode]=BaseAttribute1.[AttributeTypeCode]
	INNER JOIN [dbo].[tlkpCore_DataType] DataType1 ON DataType1.[DataTypeCode]=BaseAttribute1.[DataTypeCode]
	WHERE EventAttribute1.[BaseAttributeID] =  @BaseAttributeID

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spEvents_GetOneEventAttributeByAttributeCode
	  @SqlErrorNumber int = 0 OUTPUT
	, @AttributeCode int
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets a single EventAttribute by an index.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@AttributeCode IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	SELECT
		  EventAttribute1.[BaseAttributeID]
		, EventAttribute1.[AttributeCode]
		, EventAttribute1.[CreatedByUserID]
		, EventAttribute1.[CreatedDate]
		, EventAttribute1.[LastModifiedByUserID]
		, EventAttribute1.[LastModifiedDate]
		, EventAttribute1.[Timestamp]
		, BaseAttribute1.[AttributeName]
		, BaseAttribute1.[AttributeTypeCode]
		, BaseAttribute1.[DataTypeCode]
		, BaseAttribute1.[Description]
		, BaseAttribute1.[IsActive]
		, AttributeType1.[AttributeTypeName]
		, DataType1.[DataTypeName]
	FROM
	      [dbo].[tblEvents_EventAttribute] EventAttribute1
	INNER JOIN [dbo].[tblCore_BaseAttribute] BaseAttribute1 ON BaseAttribute1.[BaseAttributeID]=EventAttribute1.[BaseAttributeID]
	INNER JOIN [dbo].[tlkpCore_AttributeType] AttributeType1 ON AttributeType1.[AttributeTypeCode]=BaseAttribute1.[AttributeTypeCode]
	INNER JOIN [dbo].[tlkpCore_DataType] DataType1 ON DataType1.[DataTypeCode]=BaseAttribute1.[DataTypeCode]
	WHERE EventAttribute1.[AttributeCode] =  @AttributeCode

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spEvents_GetOneEventType
	  @SqlErrorNumber int = 0 OUTPUT
	, @EventTypeCode int
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets a single EventType by an index.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@EventTypeCode IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	SELECT
		  EventType1.[EventTypeCode]
		, EventType1.[EventTypeName]
		, EventType1.[Description]
		, EventType1.[IsActive]
		, EventType1.[CreatedByUserID]
		, EventType1.[CreatedDate]
		, EventType1.[LastModifiedByUserID]
		, EventType1.[LastModifiedDate]
		, EventType1.[Timestamp]
	FROM
	      [dbo].[tlkpEvents_EventType] EventType1
	WHERE EventType1.[EventTypeCode] =  @EventTypeCode

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spEvents_LogOneAuditAttributeValueLog
	  @SqlErrorNumber int = 0 OUTPUT
	, @CreatedByUserID uniqueidentifier = NULL
	, @Timestamp timestamp = NULL OUTPUT
	, @AuditAttributeValueLogID uniqueidentifier = NULL OUTPUT
	, @AuditLogID uniqueidentifier
	, @BaseAttributeID uniqueidentifier
	, @AttributeValue nvarchar(1000) = NULL
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure logs AuditAttributeValueLog data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@AuditLogID IS NULL OR @BaseAttributeID IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END
/*
** record validation
*/
IF EXISTS (SELECT [AuditAttributeValueLogID] FROM [dbo].[tblEvents_AuditAttributeValueLog] WHERE [AuditAttributeValueLogID] =  @AuditAttributeValueLogID)
BEGIN
	SET @SqlErrorNumber = -1003
	GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	IF @AuditAttributeValueLogID  IS NULL
	BEGIN
		SET @AuditAttributeValueLogID  = NEWID ()
	END
	INSERT
	      [dbo].[tblEvents_AuditAttributeValueLog]
	      (
 	     [CreatedByUserID]
 	   , [LastModifiedByUserID]
	   , [AuditAttributeValueLogID]
	   , [AuditLogID]
	   , [BaseAttributeID]
	   , [AttributeValue]
	      )

	VALUES 
	      (
 	     @CreatedByUserID
 	   , @CreatedByUserID
	   , @AuditAttributeValueLogID
	   , @AuditLogID
	   , @BaseAttributeID
	   , @AttributeValue
	      )

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END


	SET  @Timestamp = @@DBTS
END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spEvents_LogOneAuditLog
	  @SqlErrorNumber int = 0 OUTPUT
	, @CreatedByUserID uniqueidentifier = NULL
	, @Timestamp timestamp = NULL OUTPUT
	, @AuditLogID uniqueidentifier = NULL OUTPUT
	, @EventCode int
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure logs AuditLog data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@EventCode IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END
/*
** record validation
*/
IF EXISTS (SELECT [AuditLogID] FROM [dbo].[tblEvents_AuditLog] WHERE [AuditLogID] =  @AuditLogID)
BEGIN
	SET @SqlErrorNumber = -1003
	GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	IF @AuditLogID  IS NULL
	BEGIN
		SET @AuditLogID  = NEWID ()
	END
	INSERT
	      [dbo].[tblEvents_AuditLog]
	      (
 	     [CreatedByUserID]
 	   , [LastModifiedByUserID]
	   , [AuditLogID]
	   , [EventCode]
	      )

	VALUES 
	      (
 	     @CreatedByUserID
 	   , @CreatedByUserID
	   , @AuditLogID
	   , @EventCode
	      )

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END


	SET  @Timestamp = @@DBTS
END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spEvents_UpdateOneEvent
	  @SqlErrorNumber int = 0 OUTPUT
	, @LastModifiedByUserID uniqueidentifier = NULL
	, @Timestamp timestamp = NULL OUTPUT
	, @CheckTimestamp bit = 0
	, @EventCode int
	, @EventName nvarchar(255)
	, @EventTypeCode int
	, @Description nvarchar(2000) = NULL
	, @IsActive bit = 0
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure updates Event data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@EventCode IS NULL OR @EventName IS NULL OR @EventTypeCode IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END
/*
** record validation
*/
IF NOT EXISTS (SELECT [EventCode] FROM [dbo].[tblEvents_Event] WHERE [EventCode] =  @EventCode)
BEGIN
	SET @SqlErrorNumber = -1003
	GOTO EXIT_ERROR
END
/*
** timestamp validation
*/
IF (@CheckTimestamp = 1)
BEGIN
	IF EXISTS (SELECT [EventCode] FROM [dbo].[tblEvents_Event] WHERE [EventCode] =  @EventCode AND [Timestamp] <> @Timestamp)
	BEGIN
		SET @SqlErrorNumber = -1002
		GOTO EXIT_ERROR
	END
END

/*
** perform main procedure tasks
*/
BEGIN
	UPDATE
	      [dbo].[tblEvents_Event]
	SET
	     [LastModifiedByUserID] = @LastModifiedByUserID
	   , [LastModifiedDate] = getdate()
	   , [EventCode] = @EventCode
	   , [EventName] = @EventName
	   , [EventTypeCode] = @EventTypeCode
	   , [Description] = @Description
	   , [IsActive] = @IsActive
	WHERE [EventCode] =  @EventCode

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

	SET  @Timestamp = @@DBTS

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spEvents_UpdateOneEventAttribute
	  @SqlErrorNumber int = 0 OUTPUT
	, @LastModifiedByUserID uniqueidentifier = NULL
	, @Timestamp timestamp = NULL OUTPUT
	, @CheckTimestamp bit = 0
	, @BaseAttributeID uniqueidentifier
	, @AttributeCode int
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure updates EventAttribute data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@BaseAttributeID IS NULL OR @AttributeCode IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END
/*
** record validation
*/
IF NOT EXISTS (SELECT [BaseAttributeID] FROM [dbo].[tblEvents_EventAttribute] WHERE [BaseAttributeID] =  @BaseAttributeID)
BEGIN
	SET @SqlErrorNumber = -1003
	GOTO EXIT_ERROR
END
/*
** timestamp validation
*/
IF (@CheckTimestamp = 1)
BEGIN
	IF EXISTS (SELECT [BaseAttributeID] FROM [dbo].[tblEvents_EventAttribute] WHERE [BaseAttributeID] =  @BaseAttributeID AND [Timestamp] <> @Timestamp)
	BEGIN
		SET @SqlErrorNumber = -1002
		GOTO EXIT_ERROR
	END
END

/*
** perform main procedure tasks
*/
BEGIN
	UPDATE
	      [dbo].[tblEvents_EventAttribute]
	SET
	     [LastModifiedByUserID] = @LastModifiedByUserID
	   , [LastModifiedDate] = getdate()
	   , [BaseAttributeID] = @BaseAttributeID
	   , [AttributeCode] = @AttributeCode
	WHERE [BaseAttributeID] =  @BaseAttributeID

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

	SET  @Timestamp = @@DBTS

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spEvents_UpdateOneEventType
	  @SqlErrorNumber int = 0 OUTPUT
	, @LastModifiedByUserID uniqueidentifier = NULL
	, @Timestamp timestamp = NULL OUTPUT
	, @CheckTimestamp bit = 0
	, @EventTypeCode int
	, @EventTypeName nvarchar(255)
	, @Description nvarchar(2000) = NULL
	, @IsActive bit = 1
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure updates EventType data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@EventTypeCode IS NULL OR @EventTypeName IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END
/*
** record validation
*/
IF NOT EXISTS (SELECT [EventTypeCode] FROM [dbo].[tlkpEvents_EventType] WHERE [EventTypeCode] =  @EventTypeCode)
BEGIN
	SET @SqlErrorNumber = -1003
	GOTO EXIT_ERROR
END
/*
** timestamp validation
*/
IF (@CheckTimestamp = 1)
BEGIN
	IF EXISTS (SELECT [EventTypeCode] FROM [dbo].[tlkpEvents_EventType] WHERE [EventTypeCode] =  @EventTypeCode AND [Timestamp] <> @Timestamp)
	BEGIN
		SET @SqlErrorNumber = -1002
		GOTO EXIT_ERROR
	END
END

/*
** perform main procedure tasks
*/
BEGIN
	UPDATE
	      [dbo].[tlkpEvents_EventType]
	SET
	     [LastModifiedByUserID] = @LastModifiedByUserID
	   , [LastModifiedDate] = getdate()
	   , [EventTypeCode] = @EventTypeCode
	   , [EventTypeName] = @EventTypeName
	   , [Description] = @Description
	   , [IsActive] = @IsActive
	WHERE [EventTypeCode] =  @EventTypeCode

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

	SET  @Timestamp = @@DBTS

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spMessages_DeleteOneIncomingSMS
	  @SqlErrorNumber int = 0 OUTPUT
	, @Timestamp timestamp = NULL OUTPUT
	, @CheckTimestamp bit = 0
	, @InternalID bigint
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure deletes IncomingSMS data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@InternalID IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END
/*
** record validation
*/
IF NOT EXISTS (SELECT [InternalID] FROM [dbo].[tblMessages_IncomingSMS] WHERE [InternalID] =  @InternalID)
BEGIN
	SET @SqlErrorNumber = -1003
	GOTO EXIT_ERROR
END
/*
** timestamp validation
*/
IF (@CheckTimestamp = 1)
BEGIN
	IF EXISTS (SELECT [InternalID] FROM [dbo].[tblMessages_IncomingSMS] WHERE [InternalID] =  @InternalID AND [Timestamp] <> @Timestamp)
	BEGIN
		SET @SqlErrorNumber = -1002
		GOTO EXIT_ERROR
	END
END

/*
** perform main procedure tasks
*/
BEGIN
	DELETE FROM
	      [dbo].[tblMessages_IncomingSMS]
	WHERE [InternalID] =  @InternalID

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spMessages_DeleteOneOutgoingSMS
	  @SqlErrorNumber int = 0 OUTPUT
	, @Timestamp timestamp = NULL OUTPUT
	, @CheckTimestamp bit = 0
	, @InternalID bigint
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure deletes OutgoingSMS data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@InternalID IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END
/*
** record validation
*/
IF NOT EXISTS (SELECT [InternalID] FROM [dbo].[tblMessages_OutgoingSMS] WHERE [InternalID] =  @InternalID)
BEGIN
	SET @SqlErrorNumber = -1003
	GOTO EXIT_ERROR
END
/*
** timestamp validation
*/
IF (@CheckTimestamp = 1)
BEGIN
	IF EXISTS (SELECT [InternalID] FROM [dbo].[tblMessages_OutgoingSMS] WHERE [InternalID] =  @InternalID AND [Timestamp] <> @Timestamp)
	BEGIN
		SET @SqlErrorNumber = -1002
		GOTO EXIT_ERROR
	END
END

/*
** perform main procedure tasks
*/
BEGIN
	DELETE FROM
	      [dbo].[tblMessages_OutgoingSMS]
	WHERE [InternalID] =  @InternalID

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spMessages_GetAllIncomingSMSData
	  @SqlErrorNumber int = 0 OUTPUT
	, @SortColumn sysname = 'Sender'
	, @SortDirection nvarchar(20) = 'Ascending'
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets all IncomingSMS data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0
IF (@SortColumn = '') SET @SortColumn='Sender'

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

IF (@SortDirection = 'Random')
BEGIN
	SELECT
		  IncomingSMS1.[Sender]
		, IncomingSMS1.[Receiver]
		, IncomingSMS1.[ConnectionID]
		, IncomingSMS1.[SMSContent]
		, IncomingSMS1.[IsProcessed]
		, IncomingSMS1.[InternalID]
		, IncomingSMS1.[CreatedByUserID]
		, IncomingSMS1.[CreatedDate]
		, IncomingSMS1.[LastModifiedByUserID]
		, IncomingSMS1.[LastModifiedDate]
		, IncomingSMS1.[Timestamp]
	FROM
	      [dbo].[tblMessages_IncomingSMS] IncomingSMS1

	ORDER BY NewID()
END
ELSE
BEGIN
	SELECT
		  IncomingSMS1.[Sender]
		, IncomingSMS1.[Receiver]
		, IncomingSMS1.[ConnectionID]
		, IncomingSMS1.[SMSContent]
		, IncomingSMS1.[IsProcessed]
		, IncomingSMS1.[InternalID]
		, IncomingSMS1.[CreatedByUserID]
		, IncomingSMS1.[CreatedDate]
		, IncomingSMS1.[LastModifiedByUserID]
		, IncomingSMS1.[LastModifiedDate]
		, IncomingSMS1.[Timestamp]
	FROM
	      [dbo].[tblMessages_IncomingSMS] IncomingSMS1

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Sender' THEN IncomingSMS1.[Sender] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Sender' THEN IncomingSMS1.[Sender] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Receiver' THEN IncomingSMS1.[Receiver] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Receiver' THEN IncomingSMS1.[Receiver] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'ConnectionID' THEN IncomingSMS1.[ConnectionID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'ConnectionID' THEN IncomingSMS1.[ConnectionID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'SMSContent' THEN IncomingSMS1.[SMSContent] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'SMSContent' THEN IncomingSMS1.[SMSContent] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'IsProcessed' THEN IncomingSMS1.[IsProcessed] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'IsProcessed' THEN IncomingSMS1.[IsProcessed] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'InternalID' THEN IncomingSMS1.[InternalID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'InternalID' THEN IncomingSMS1.[InternalID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN IncomingSMS1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN IncomingSMS1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN IncomingSMS1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN IncomingSMS1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN IncomingSMS1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN IncomingSMS1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN IncomingSMS1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN IncomingSMS1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN IncomingSMS1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN IncomingSMS1.[Timestamp] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END


RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spMessages_GetAllIncomingSMSDataByCriteria
	  @SqlErrorNumber int = 0 OUTPUT
	, @SortColumn sysname = 'LastModifiedDate'
	, @SortDirection nvarchar(20) = 'Ascending'
	, @LastModifiedDateStart datetime = getdate
	, @LastModifiedDateEnd datetime = getdate
	, @IsProcessed bit = 0
	, @Receiver nvarchar(15)
	, @Sender nvarchar(15)
	, @SMSContent nvarchar(170)
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets all IncomingSMS data by criteria.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0
IF (@SortColumn = '') SET @SortColumn='LastModifiedDate'

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

IF (@SortDirection = 'Random')
BEGIN
	SELECT
		  IncomingSMS1.[Sender]
		, IncomingSMS1.[Receiver]
		, IncomingSMS1.[ConnectionID]
		, IncomingSMS1.[SMSContent]
		, IncomingSMS1.[IsProcessed]
		, IncomingSMS1.[InternalID]
		, IncomingSMS1.[CreatedByUserID]
		, IncomingSMS1.[CreatedDate]
		, IncomingSMS1.[LastModifiedByUserID]
		, IncomingSMS1.[LastModifiedDate]
		, IncomingSMS1.[Timestamp]
	FROM
	      [dbo].[tblMessages_IncomingSMS] IncomingSMS1
	WHERE 
		((@LastModifiedDateStart  IS NULL) OR (IncomingSMS1.[LastModifiedDate] >=  @LastModifiedDateStart))
		AND ((@LastModifiedDateEnd  IS NULL) OR (IncomingSMS1.[LastModifiedDate] <=  @LastModifiedDateEnd))
		AND (@IsProcessed IS NULL OR IncomingSMS1.[IsProcessed] = @IsProcessed)
		AND (@Receiver IS NULL OR IncomingSMS1.[Receiver] like '%' + @Receiver + '%')
		AND (@Sender IS NULL OR IncomingSMS1.[Sender] like '%' + @Sender + '%')
		AND (@SMSContent IS NULL OR IncomingSMS1.[SMSContent] like '%' + @SMSContent + '%')

	ORDER BY NewID()
END
ELSE
BEGIN
	SELECT
		  IncomingSMS1.[Sender]
		, IncomingSMS1.[Receiver]
		, IncomingSMS1.[ConnectionID]
		, IncomingSMS1.[SMSContent]
		, IncomingSMS1.[IsProcessed]
		, IncomingSMS1.[InternalID]
		, IncomingSMS1.[CreatedByUserID]
		, IncomingSMS1.[CreatedDate]
		, IncomingSMS1.[LastModifiedByUserID]
		, IncomingSMS1.[LastModifiedDate]
		, IncomingSMS1.[Timestamp]
	FROM
	      [dbo].[tblMessages_IncomingSMS] IncomingSMS1
	WHERE 
		((@LastModifiedDateStart  IS NULL) OR (IncomingSMS1.[LastModifiedDate] >=  @LastModifiedDateStart))
		AND ((@LastModifiedDateEnd  IS NULL) OR (IncomingSMS1.[LastModifiedDate] <=  @LastModifiedDateEnd))
		AND (@IsProcessed IS NULL OR IncomingSMS1.[IsProcessed] = @IsProcessed)
		AND (@Receiver IS NULL OR IncomingSMS1.[Receiver] like '%' + @Receiver + '%')
		AND (@Sender IS NULL OR IncomingSMS1.[Sender] like '%' + @Sender + '%')
		AND (@SMSContent IS NULL OR IncomingSMS1.[SMSContent] like '%' + @SMSContent + '%')

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Sender' THEN IncomingSMS1.[Sender] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Sender' THEN IncomingSMS1.[Sender] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Receiver' THEN IncomingSMS1.[Receiver] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Receiver' THEN IncomingSMS1.[Receiver] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'ConnectionID' THEN IncomingSMS1.[ConnectionID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'ConnectionID' THEN IncomingSMS1.[ConnectionID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'SMSContent' THEN IncomingSMS1.[SMSContent] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'SMSContent' THEN IncomingSMS1.[SMSContent] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'IsProcessed' THEN IncomingSMS1.[IsProcessed] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'IsProcessed' THEN IncomingSMS1.[IsProcessed] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'InternalID' THEN IncomingSMS1.[InternalID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'InternalID' THEN IncomingSMS1.[InternalID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN IncomingSMS1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN IncomingSMS1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN IncomingSMS1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN IncomingSMS1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN IncomingSMS1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN IncomingSMS1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN IncomingSMS1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN IncomingSMS1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN IncomingSMS1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN IncomingSMS1.[Timestamp] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END


RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spMessages_GetAllOutgoingSMSData
	  @SqlErrorNumber int = 0 OUTPUT
	, @SortColumn sysname = 'Sender'
	, @SortDirection nvarchar(20) = 'Ascending'
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets all OutgoingSMS data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0
IF (@SortColumn = '') SET @SortColumn='Sender'

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

IF (@SortDirection = 'Random')
BEGIN
	SELECT
		  OutgoingSMS1.[Sender]
		, OutgoingSMS1.[Receiver]
		, OutgoingSMS1.[NowSMSServer]
		, OutgoingSMS1.[SMSContent]
		, OutgoingSMS1.[ServerResponse]
		, OutgoingSMS1.[InternalID]
		, OutgoingSMS1.[CreatedByUserID]
		, OutgoingSMS1.[CreatedDate]
		, OutgoingSMS1.[LastModifiedByUserID]
		, OutgoingSMS1.[LastModifiedDate]
		, OutgoingSMS1.[Timestamp]
	FROM
	      [dbo].[tblMessages_OutgoingSMS] OutgoingSMS1

	ORDER BY NewID()
END
ELSE
BEGIN
	SELECT
		  OutgoingSMS1.[Sender]
		, OutgoingSMS1.[Receiver]
		, OutgoingSMS1.[NowSMSServer]
		, OutgoingSMS1.[SMSContent]
		, OutgoingSMS1.[ServerResponse]
		, OutgoingSMS1.[InternalID]
		, OutgoingSMS1.[CreatedByUserID]
		, OutgoingSMS1.[CreatedDate]
		, OutgoingSMS1.[LastModifiedByUserID]
		, OutgoingSMS1.[LastModifiedDate]
		, OutgoingSMS1.[Timestamp]
	FROM
	      [dbo].[tblMessages_OutgoingSMS] OutgoingSMS1

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Sender' THEN OutgoingSMS1.[Sender] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Sender' THEN OutgoingSMS1.[Sender] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Receiver' THEN OutgoingSMS1.[Receiver] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Receiver' THEN OutgoingSMS1.[Receiver] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'NowSMSServer' THEN OutgoingSMS1.[NowSMSServer] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'NowSMSServer' THEN OutgoingSMS1.[NowSMSServer] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'SMSContent' THEN OutgoingSMS1.[SMSContent] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'SMSContent' THEN OutgoingSMS1.[SMSContent] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'ServerResponse' THEN OutgoingSMS1.[ServerResponse] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'ServerResponse' THEN OutgoingSMS1.[ServerResponse] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'InternalID' THEN OutgoingSMS1.[InternalID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'InternalID' THEN OutgoingSMS1.[InternalID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN OutgoingSMS1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN OutgoingSMS1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN OutgoingSMS1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN OutgoingSMS1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN OutgoingSMS1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN OutgoingSMS1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN OutgoingSMS1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN OutgoingSMS1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN OutgoingSMS1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN OutgoingSMS1.[Timestamp] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END


RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spMessages_GetAllOutgoingSMSDataByCriteria
	  @SqlErrorNumber int = 0 OUTPUT
	, @SortColumn sysname = 'LastModifiedDate'
	, @SortDirection nvarchar(20) = 'Ascending'
	, @LastModifiedDateStart datetime = getdate
	, @LastModifiedDateEnd datetime = getdate
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets all OutgoingSMS data by criteria.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0
IF (@SortColumn = '') SET @SortColumn='LastModifiedDate'

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

IF (@SortDirection = 'Random')
BEGIN
	SELECT
		  OutgoingSMS1.[Sender]
		, OutgoingSMS1.[Receiver]
		, OutgoingSMS1.[NowSMSServer]
		, OutgoingSMS1.[SMSContent]
		, OutgoingSMS1.[ServerResponse]
		, OutgoingSMS1.[InternalID]
		, OutgoingSMS1.[CreatedByUserID]
		, OutgoingSMS1.[CreatedDate]
		, OutgoingSMS1.[LastModifiedByUserID]
		, OutgoingSMS1.[LastModifiedDate]
		, OutgoingSMS1.[Timestamp]
	FROM
	      [dbo].[tblMessages_OutgoingSMS] OutgoingSMS1
	WHERE 
		((@LastModifiedDateStart  IS NULL) OR (OutgoingSMS1.[LastModifiedDate] >=  @LastModifiedDateStart))
		AND ((@LastModifiedDateEnd  IS NULL) OR (OutgoingSMS1.[LastModifiedDate] <=  @LastModifiedDateEnd))

	ORDER BY NewID()
END
ELSE
BEGIN
	SELECT
		  OutgoingSMS1.[Sender]
		, OutgoingSMS1.[Receiver]
		, OutgoingSMS1.[NowSMSServer]
		, OutgoingSMS1.[SMSContent]
		, OutgoingSMS1.[ServerResponse]
		, OutgoingSMS1.[InternalID]
		, OutgoingSMS1.[CreatedByUserID]
		, OutgoingSMS1.[CreatedDate]
		, OutgoingSMS1.[LastModifiedByUserID]
		, OutgoingSMS1.[LastModifiedDate]
		, OutgoingSMS1.[Timestamp]
	FROM
	      [dbo].[tblMessages_OutgoingSMS] OutgoingSMS1
	WHERE 
		((@LastModifiedDateStart  IS NULL) OR (OutgoingSMS1.[LastModifiedDate] >=  @LastModifiedDateStart))
		AND ((@LastModifiedDateEnd  IS NULL) OR (OutgoingSMS1.[LastModifiedDate] <=  @LastModifiedDateEnd))

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Sender' THEN OutgoingSMS1.[Sender] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Sender' THEN OutgoingSMS1.[Sender] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Receiver' THEN OutgoingSMS1.[Receiver] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Receiver' THEN OutgoingSMS1.[Receiver] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'NowSMSServer' THEN OutgoingSMS1.[NowSMSServer] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'NowSMSServer' THEN OutgoingSMS1.[NowSMSServer] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'SMSContent' THEN OutgoingSMS1.[SMSContent] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'SMSContent' THEN OutgoingSMS1.[SMSContent] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'ServerResponse' THEN OutgoingSMS1.[ServerResponse] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'ServerResponse' THEN OutgoingSMS1.[ServerResponse] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'InternalID' THEN OutgoingSMS1.[InternalID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'InternalID' THEN OutgoingSMS1.[InternalID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN OutgoingSMS1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN OutgoingSMS1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN OutgoingSMS1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN OutgoingSMS1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN OutgoingSMS1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN OutgoingSMS1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN OutgoingSMS1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN OutgoingSMS1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN OutgoingSMS1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN OutgoingSMS1.[Timestamp] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END


RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spMessages_GetManyIncomingSMSDataByCriteria
	  @SqlErrorNumber int = 0 OUTPUT
	, @StartIndex int = 1
	, @PageSize int = 50
	, @MaximumListSize int = 0
	, @MaximumListSizeExceeded bit = 0 OUTPUT
	, @TotalRecords int = 0 OUTPUT
	, @SortColumn sysname = 'LastModifiedDate'
	, @SortDirection nvarchar(20) = 'Ascending'
	, @LastModifiedDateStart datetime = getdate
	, @LastModifiedDateEnd datetime = getdate
	, @IsProcessed bit = 0
	, @Receiver nvarchar(15)
	, @Sender nvarchar(15)
	, @SMSContent nvarchar(170)
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets many IncomingSMS data by criteria.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

DECLARE @vEndIndex int
IF (@StartIndex < 1) SET @StartIndex=1
IF (@PageSize < 1) SET @PageSize=1
SET @vEndIndex = @StartIndex + @Pagesize
IF (@SortColumn = '') SET @SortColumn='LastModifiedDate'

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

DECLARE @OrderedRecords TABLE
(
     SearchOrderID int IDENTITY (1, 1) NOT NULL
    , InternalID bigint
)
IF (@SortDirection = 'Random')
BEGIN
	INSERT INTO @OrderedRecords (InternalID)
	SELECT
		  IncomingSMS1.[InternalID]
	FROM
	      [dbo].[tblMessages_IncomingSMS] IncomingSMS1
	WHERE 
		((@LastModifiedDateStart  IS NULL) OR (IncomingSMS1.[LastModifiedDate] >=  @LastModifiedDateStart))
		AND ((@LastModifiedDateEnd  IS NULL) OR (IncomingSMS1.[LastModifiedDate] <=  @LastModifiedDateEnd))
		AND (@IsProcessed IS NULL OR IncomingSMS1.[IsProcessed] = @IsProcessed)
		AND (@Receiver IS NULL OR IncomingSMS1.[Receiver] like '%' + @Receiver + '%')
		AND (@Sender IS NULL OR IncomingSMS1.[Sender] like '%' + @Sender + '%')
		AND (@SMSContent IS NULL OR IncomingSMS1.[SMSContent] like '%' + @SMSContent + '%')

	ORDER BY NewID()
END
ELSE
BEGIN
	INSERT INTO @OrderedRecords (InternalID)
	SELECT
		  IncomingSMS1.[InternalID]
	FROM
	      [dbo].[tblMessages_IncomingSMS] IncomingSMS1
	WHERE 
		((@LastModifiedDateStart  IS NULL) OR (IncomingSMS1.[LastModifiedDate] >=  @LastModifiedDateStart))
		AND ((@LastModifiedDateEnd  IS NULL) OR (IncomingSMS1.[LastModifiedDate] <=  @LastModifiedDateEnd))
		AND (@IsProcessed IS NULL OR IncomingSMS1.[IsProcessed] = @IsProcessed)
		AND (@Receiver IS NULL OR IncomingSMS1.[Receiver] like '%' + @Receiver + '%')
		AND (@Sender IS NULL OR IncomingSMS1.[Sender] like '%' + @Sender + '%')
		AND (@SMSContent IS NULL OR IncomingSMS1.[SMSContent] like '%' + @SMSContent + '%')

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Sender' THEN IncomingSMS1.[Sender] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Sender' THEN IncomingSMS1.[Sender] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Receiver' THEN IncomingSMS1.[Receiver] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Receiver' THEN IncomingSMS1.[Receiver] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'ConnectionID' THEN IncomingSMS1.[ConnectionID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'ConnectionID' THEN IncomingSMS1.[ConnectionID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'SMSContent' THEN IncomingSMS1.[SMSContent] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'SMSContent' THEN IncomingSMS1.[SMSContent] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'IsProcessed' THEN IncomingSMS1.[IsProcessed] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'IsProcessed' THEN IncomingSMS1.[IsProcessed] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'InternalID' THEN IncomingSMS1.[InternalID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'InternalID' THEN IncomingSMS1.[InternalID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN IncomingSMS1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN IncomingSMS1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN IncomingSMS1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN IncomingSMS1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN IncomingSMS1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN IncomingSMS1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN IncomingSMS1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN IncomingSMS1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN IncomingSMS1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN IncomingSMS1.[Timestamp] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END

BEGIN
	SET @TotalRecords = (SELECT Count (*) FROM @OrderedRecords)
	IF @MaximumListSize > 0
	BEGIN
		IF @TotalRecords > @MaximumListSize
		BEGIN
			SET @MaximumListSizeExceeded = 1
			SET @TotalRecords = @MaximumListSize
		END
	END

	/* get search results */
	SELECT
		  IncomingSMS1.[Sender]
		, IncomingSMS1.[Receiver]
		, IncomingSMS1.[ConnectionID]
		, IncomingSMS1.[SMSContent]
		, IncomingSMS1.[IsProcessed]
		, IncomingSMS1.[InternalID]
		, IncomingSMS1.[CreatedByUserID]
		, IncomingSMS1.[CreatedDate]
		, IncomingSMS1.[LastModifiedByUserID]
		, IncomingSMS1.[LastModifiedDate]
		, IncomingSMS1.[Timestamp]
	FROM
	      [dbo].[tblMessages_IncomingSMS] IncomingSMS1
	INNER JOIN @OrderedRecords search ON search.[InternalID] = IncomingSMS1.[InternalID]
	WHERE
		search.SearchOrderID  >= @StartIndex AND
		search.SearchOrderID  < @vEndIndex
	ORDER BY
		search.SearchOrderID

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spMessages_GetManyOutgoingSMSDataByCriteria
	  @SqlErrorNumber int = 0 OUTPUT
	, @StartIndex int = 1
	, @PageSize int = 50
	, @MaximumListSize int = 0
	, @MaximumListSizeExceeded bit = 0 OUTPUT
	, @TotalRecords int = 0 OUTPUT
	, @SortColumn sysname = 'LastModifiedDate'
	, @SortDirection nvarchar(20) = 'Ascending'
	, @LastModifiedDateStart datetime = getdate
	, @LastModifiedDateEnd datetime = getdate
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets many OutgoingSMS data by criteria.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

DECLARE @vEndIndex int
IF (@StartIndex < 1) SET @StartIndex=1
IF (@PageSize < 1) SET @PageSize=1
SET @vEndIndex = @StartIndex + @Pagesize
IF (@SortColumn = '') SET @SortColumn='LastModifiedDate'

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

DECLARE @OrderedRecords TABLE
(
     SearchOrderID int IDENTITY (1, 1) NOT NULL
    , InternalID bigint
)
IF (@SortDirection = 'Random')
BEGIN
	INSERT INTO @OrderedRecords (InternalID)
	SELECT
		  OutgoingSMS1.[InternalID]
	FROM
	      [dbo].[tblMessages_OutgoingSMS] OutgoingSMS1
	WHERE 
		((@LastModifiedDateStart  IS NULL) OR (OutgoingSMS1.[LastModifiedDate] >=  @LastModifiedDateStart))
		AND ((@LastModifiedDateEnd  IS NULL) OR (OutgoingSMS1.[LastModifiedDate] <=  @LastModifiedDateEnd))

	ORDER BY NewID()
END
ELSE
BEGIN
	INSERT INTO @OrderedRecords (InternalID)
	SELECT
		  OutgoingSMS1.[InternalID]
	FROM
	      [dbo].[tblMessages_OutgoingSMS] OutgoingSMS1
	WHERE 
		((@LastModifiedDateStart  IS NULL) OR (OutgoingSMS1.[LastModifiedDate] >=  @LastModifiedDateStart))
		AND ((@LastModifiedDateEnd  IS NULL) OR (OutgoingSMS1.[LastModifiedDate] <=  @LastModifiedDateEnd))

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Sender' THEN OutgoingSMS1.[Sender] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Sender' THEN OutgoingSMS1.[Sender] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Receiver' THEN OutgoingSMS1.[Receiver] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Receiver' THEN OutgoingSMS1.[Receiver] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'NowSMSServer' THEN OutgoingSMS1.[NowSMSServer] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'NowSMSServer' THEN OutgoingSMS1.[NowSMSServer] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'SMSContent' THEN OutgoingSMS1.[SMSContent] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'SMSContent' THEN OutgoingSMS1.[SMSContent] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'ServerResponse' THEN OutgoingSMS1.[ServerResponse] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'ServerResponse' THEN OutgoingSMS1.[ServerResponse] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'InternalID' THEN OutgoingSMS1.[InternalID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'InternalID' THEN OutgoingSMS1.[InternalID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN OutgoingSMS1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN OutgoingSMS1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN OutgoingSMS1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN OutgoingSMS1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN OutgoingSMS1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN OutgoingSMS1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN OutgoingSMS1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN OutgoingSMS1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN OutgoingSMS1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN OutgoingSMS1.[Timestamp] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END

BEGIN
	SET @TotalRecords = (SELECT Count (*) FROM @OrderedRecords)
	IF @MaximumListSize > 0
	BEGIN
		IF @TotalRecords > @MaximumListSize
		BEGIN
			SET @MaximumListSizeExceeded = 1
			SET @TotalRecords = @MaximumListSize
		END
	END

	/* get search results */
	SELECT
		  OutgoingSMS1.[Sender]
		, OutgoingSMS1.[Receiver]
		, OutgoingSMS1.[NowSMSServer]
		, OutgoingSMS1.[SMSContent]
		, OutgoingSMS1.[ServerResponse]
		, OutgoingSMS1.[InternalID]
		, OutgoingSMS1.[CreatedByUserID]
		, OutgoingSMS1.[CreatedDate]
		, OutgoingSMS1.[LastModifiedByUserID]
		, OutgoingSMS1.[LastModifiedDate]
		, OutgoingSMS1.[Timestamp]
	FROM
	      [dbo].[tblMessages_OutgoingSMS] OutgoingSMS1
	INNER JOIN @OrderedRecords search ON search.[InternalID] = OutgoingSMS1.[InternalID]
	WHERE
		search.SearchOrderID  >= @StartIndex AND
		search.SearchOrderID  < @vEndIndex
	ORDER BY
		search.SearchOrderID

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spMessages_GetOneIncomingSMS
	  @SqlErrorNumber int = 0 OUTPUT
	, @InternalID bigint
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets a single IncomingSMS by an index.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@InternalID IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	SELECT
		  IncomingSMS1.[Sender]
		, IncomingSMS1.[Receiver]
		, IncomingSMS1.[ConnectionID]
		, IncomingSMS1.[SMSContent]
		, IncomingSMS1.[IsProcessed]
		, IncomingSMS1.[InternalID]
		, IncomingSMS1.[CreatedByUserID]
		, IncomingSMS1.[CreatedDate]
		, IncomingSMS1.[LastModifiedByUserID]
		, IncomingSMS1.[LastModifiedDate]
		, IncomingSMS1.[Timestamp]
	FROM
	      [dbo].[tblMessages_IncomingSMS] IncomingSMS1
	WHERE IncomingSMS1.[InternalID] =  @InternalID

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spMessages_GetOneOutgoingSMS
	  @SqlErrorNumber int = 0 OUTPUT
	, @InternalID bigint
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets a single OutgoingSMS by an index.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@InternalID IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	SELECT
		  OutgoingSMS1.[Sender]
		, OutgoingSMS1.[Receiver]
		, OutgoingSMS1.[NowSMSServer]
		, OutgoingSMS1.[SMSContent]
		, OutgoingSMS1.[ServerResponse]
		, OutgoingSMS1.[InternalID]
		, OutgoingSMS1.[CreatedByUserID]
		, OutgoingSMS1.[CreatedDate]
		, OutgoingSMS1.[LastModifiedByUserID]
		, OutgoingSMS1.[LastModifiedDate]
		, OutgoingSMS1.[Timestamp]
	FROM
	      [dbo].[tblMessages_OutgoingSMS] OutgoingSMS1
	WHERE OutgoingSMS1.[InternalID] =  @InternalID

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spMessages_UpsertOneIncomingSMS
	  @SqlErrorNumber int = 0 OUTPUT
	, @CreatedByUserID uniqueidentifier = NULL
	, @LastModifiedByUserID uniqueidentifier = NULL
	, @Timestamp timestamp = NULL OUTPUT
	, @CheckTimestamp bit = 0
	, @Sender nvarchar(15)
	, @Receiver nvarchar(15)
	, @ConnectionID nvarchar(15)
	, @SMSContent nvarchar(170)
	, @IsProcessed bit = 0
	, @InternalID bigint = NULL OUTPUT
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure inserts or updates IncomingSMS data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@Sender IS NULL OR @Receiver IS NULL OR @ConnectionID IS NULL OR @SMSContent IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END
/*
** timestamp validation
*/
IF (@CheckTimestamp = 1)
BEGIN
	IF EXISTS (SELECT [InternalID] FROM [dbo].[tblMessages_IncomingSMS] WHERE [InternalID] =  @InternalID AND [Timestamp] <> @Timestamp)
	BEGIN
		SET @SqlErrorNumber = -1002
		GOTO EXIT_ERROR
	END
END

/*
** perform main procedure tasks
*/
IF NOT EXISTS (SELECT [InternalID] FROM [dbo].[tblMessages_IncomingSMS] WHERE [InternalID] =  @InternalID)
BEGIN
	INSERT
	      [dbo].[tblMessages_IncomingSMS]
	      (
 	     [CreatedByUserID]
 	   , [LastModifiedByUserID]
	   , [Sender]
	   , [Receiver]
	   , [ConnectionID]
	   , [SMSContent]
	   , [IsProcessed]
	      )

	VALUES 
	      (
 	     @CreatedByUserID
 	   , @CreatedByUserID
	   , @Sender
	   , @Receiver
	   , @ConnectionID
	   , @SMSContent
	   , @IsProcessed
	      )

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END


	SET @InternalID = SCOPE_IDENTITY ()

	SET  @Timestamp = @@DBTS
	END
ELSE
BEGIN
	UPDATE
	      [dbo].[tblMessages_IncomingSMS]
	SET
	     [LastModifiedByUserID] = @LastModifiedByUserID
	   , [LastModifiedDate] = getdate()
	   , [Sender] = @Sender
	   , [Receiver] = @Receiver
	   , [ConnectionID] = @ConnectionID
	   , [SMSContent] = @SMSContent
	   , [IsProcessed] = @IsProcessed
	WHERE [InternalID] =  @InternalID

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

	SET  @Timestamp = @@DBTS

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spMessages_UpsertOneOutgoingSMS
	  @SqlErrorNumber int = 0 OUTPUT
	, @CreatedByUserID uniqueidentifier = NULL
	, @LastModifiedByUserID uniqueidentifier = NULL
	, @Timestamp timestamp = NULL OUTPUT
	, @CheckTimestamp bit = 0
	, @Sender nvarchar(15)
	, @Receiver nvarchar(15)
	, @NowSMSServer nvarchar(50)
	, @SMSContent nvarchar(170)
	, @ServerResponse nvarchar(255)
	, @InternalID bigint = NULL OUTPUT
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure inserts or updates OutgoingSMS data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@Sender IS NULL OR @Receiver IS NULL OR @NowSMSServer IS NULL OR @SMSContent IS NULL OR @ServerResponse IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END
/*
** timestamp validation
*/
IF (@CheckTimestamp = 1)
BEGIN
	IF EXISTS (SELECT [InternalID] FROM [dbo].[tblMessages_OutgoingSMS] WHERE [InternalID] =  @InternalID AND [Timestamp] <> @Timestamp)
	BEGIN
		SET @SqlErrorNumber = -1002
		GOTO EXIT_ERROR
	END
END

/*
** perform main procedure tasks
*/
IF NOT EXISTS (SELECT [InternalID] FROM [dbo].[tblMessages_OutgoingSMS] WHERE [InternalID] =  @InternalID)
BEGIN
	INSERT
	      [dbo].[tblMessages_OutgoingSMS]
	      (
 	     [CreatedByUserID]
 	   , [LastModifiedByUserID]
	   , [Sender]
	   , [Receiver]
	   , [NowSMSServer]
	   , [SMSContent]
	   , [ServerResponse]
	      )

	VALUES 
	      (
 	     @CreatedByUserID
 	   , @CreatedByUserID
	   , @Sender
	   , @Receiver
	   , @NowSMSServer
	   , @SMSContent
	   , @ServerResponse
	      )

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END


	SET @InternalID = SCOPE_IDENTITY ()

	SET  @Timestamp = @@DBTS
	END
ELSE
BEGIN
	UPDATE
	      [dbo].[tblMessages_OutgoingSMS]
	SET
	     [LastModifiedByUserID] = @LastModifiedByUserID
	   , [LastModifiedDate] = getdate()
	   , [Sender] = @Sender
	   , [Receiver] = @Receiver
	   , [NowSMSServer] = @NowSMSServer
	   , [SMSContent] = @SMSContent
	   , [ServerResponse] = @ServerResponse
	WHERE [InternalID] =  @InternalID

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

	SET  @Timestamp = @@DBTS

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spUsers_AddOneAccessMode
	  @SqlErrorNumber int = 0 OUTPUT
	, @CreatedByUserID uniqueidentifier = NULL
	, @Timestamp timestamp = NULL OUTPUT
	, @AccessModeCode int
	, @AccessModeName nvarchar(255)
	, @Description nvarchar(2000) = NULL
	, @IsActive bit = 0
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure inserts AccessMode data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@AccessModeCode IS NULL OR @AccessModeName IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END
/*
** record validation
*/
IF EXISTS (SELECT [AccessModeCode] FROM [dbo].[tlkpUsers_AccessMode] WHERE [AccessModeCode] =  @AccessModeCode)
BEGIN
	SET @SqlErrorNumber = -1003
	GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	INSERT
	      [dbo].[tlkpUsers_AccessMode]
	      (
 	     [CreatedByUserID]
 	   , [LastModifiedByUserID]
	   , [AccessModeCode]
	   , [AccessModeName]
	   , [Description]
	   , [IsActive]
	      )

	VALUES 
	      (
 	     @CreatedByUserID
 	   , @CreatedByUserID
	   , @AccessModeCode
	   , @AccessModeName
	   , @Description
	   , @IsActive
	      )

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END


	SET  @Timestamp = @@DBTS
END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spUsers_AddOneActivity
	  @SqlErrorNumber int = 0 OUTPUT
	, @CreatedByUserID uniqueidentifier = NULL
	, @Timestamp timestamp = NULL OUTPUT
	, @ActivityCode int
	, @ActivityName nvarchar(255)
	, @Description nvarchar(2000) = NULL
	, @IsActive bit = 0
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure inserts Activity data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@ActivityCode IS NULL OR @ActivityName IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END
/*
** record validation
*/
IF EXISTS (SELECT [ActivityCode] FROM [dbo].[tlkpUsers_Activity] WHERE [ActivityCode] =  @ActivityCode)
BEGIN
	SET @SqlErrorNumber = -1003
	GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	INSERT
	      [dbo].[tlkpUsers_Activity]
	      (
 	     [CreatedByUserID]
 	   , [LastModifiedByUserID]
	   , [ActivityCode]
	   , [ActivityName]
	   , [Description]
	   , [IsActive]
	      )

	VALUES 
	      (
 	     @CreatedByUserID
 	   , @CreatedByUserID
	   , @ActivityCode
	   , @ActivityName
	   , @Description
	   , @IsActive
	      )

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END


	SET  @Timestamp = @@DBTS
END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spUsers_AddOneUserRole
	  @SqlErrorNumber int = 0 OUTPUT
	, @CreatedByUserID uniqueidentifier = NULL
	, @Timestamp timestamp = NULL OUTPUT
	, @UserRoleCode int
	, @UserRoleName nvarchar(255)
	, @Description nvarchar(2000) = NULL
	, @IsActive bit = 0
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure inserts UserRole data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@UserRoleCode IS NULL OR @UserRoleName IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END
/*
** record validation
*/
IF EXISTS (SELECT [UserRoleCode] FROM [dbo].[tlkpUsers_UserRole] WHERE [UserRoleCode] =  @UserRoleCode)
BEGIN
	SET @SqlErrorNumber = -1003
	GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	INSERT
	      [dbo].[tlkpUsers_UserRole]
	      (
 	     [CreatedByUserID]
 	   , [LastModifiedByUserID]
	   , [UserRoleCode]
	   , [UserRoleName]
	   , [Description]
	   , [IsActive]
	      )

	VALUES 
	      (
 	     @CreatedByUserID
 	   , @CreatedByUserID
	   , @UserRoleCode
	   , @UserRoleName
	   , @Description
	   , @IsActive
	      )

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END


	SET  @Timestamp = @@DBTS
END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spUsers_AddOneUserRoleActivity
	  @SqlErrorNumber int = 0 OUTPUT
	, @CreatedByUserID uniqueidentifier = NULL
	, @Timestamp timestamp = NULL OUTPUT
	, @UserRoleCode int
	, @ActivityCode int
	, @AccessModeCode int
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure inserts UserRoleActivity data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@UserRoleCode IS NULL OR @ActivityCode IS NULL OR @AccessModeCode IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END
/*
** record validation
*/
IF EXISTS (SELECT [UserRoleCode], [ActivityCode], [AccessModeCode] FROM [dbo].[trelUsers_UserRoleActivity] WHERE [UserRoleCode] =  @UserRoleCode AND [ActivityCode] =  @ActivityCode AND [AccessModeCode] =  @AccessModeCode)
BEGIN
	SET @SqlErrorNumber = -1003
	GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	INSERT
	      [dbo].[trelUsers_UserRoleActivity]
	      (
 	     [CreatedByUserID]
 	   , [LastModifiedByUserID]
	   , [UserRoleCode]
	   , [ActivityCode]
	   , [AccessModeCode]
	      )

	VALUES 
	      (
 	     @CreatedByUserID
 	   , @CreatedByUserID
	   , @UserRoleCode
	   , @ActivityCode
	   , @AccessModeCode
	      )

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END


	SET  @Timestamp = @@DBTS
END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spUsers_AddOneUserRoleUser
	  @SqlErrorNumber int = 0 OUTPUT
	, @CreatedByUserID uniqueidentifier = NULL
	, @Timestamp timestamp = NULL OUTPUT
	, @UserRoleCode int
	, @UserID uniqueidentifier
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure inserts UserRoleUser data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@UserRoleCode IS NULL OR @UserID IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END
/*
** record validation
*/
IF EXISTS (SELECT [UserRoleCode], [UserID] FROM [dbo].[trelUsers_UserRoleUser] WHERE [UserRoleCode] =  @UserRoleCode AND [UserID] =  @UserID)
BEGIN
	SET @SqlErrorNumber = -1003
	GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	INSERT
	      [dbo].[trelUsers_UserRoleUser]
	      (
 	     [CreatedByUserID]
 	   , [LastModifiedByUserID]
	   , [UserRoleCode]
	   , [UserID]
	      )

	VALUES 
	      (
 	     @CreatedByUserID
 	   , @CreatedByUserID
	   , @UserRoleCode
	   , @UserID
	      )

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END


	SET  @Timestamp = @@DBTS
END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spUsers_DeleteAllUserRoleActivityDataByAccessModeCode
	  @SqlErrorNumber int = 0 OUTPUT
	, @AccessModeCode int
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure deletes all UserRoleActivity data by a key.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@AccessModeCode IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	DELETE FROM
	      [dbo].[trelUsers_UserRoleActivity]
	WHERE [AccessModeCode] =  @AccessModeCode

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spUsers_DeleteAllUserRoleActivityDataByActivityCode
	  @SqlErrorNumber int = 0 OUTPUT
	, @ActivityCode int
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure deletes all UserRoleActivity data by a key.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@ActivityCode IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	DELETE FROM
	      [dbo].[trelUsers_UserRoleActivity]
	WHERE [ActivityCode] =  @ActivityCode

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spUsers_DeleteAllUserRoleActivityDataByUserRoleCode
	  @SqlErrorNumber int = 0 OUTPUT
	, @UserRoleCode int
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure deletes all UserRoleActivity data by a key.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@UserRoleCode IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	DELETE FROM
	      [dbo].[trelUsers_UserRoleActivity]
	WHERE [UserRoleCode] =  @UserRoleCode

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spUsers_DeleteAllUserRoleUserDataByUserID
	  @SqlErrorNumber int = 0 OUTPUT
	, @UserID uniqueidentifier
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure deletes all UserRoleUser data by a key.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@UserID IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	DELETE FROM
	      [dbo].[trelUsers_UserRoleUser]
	WHERE [UserID] =  @UserID

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spUsers_DeleteAllUserRoleUserDataByUserRoleCode
	  @SqlErrorNumber int = 0 OUTPUT
	, @UserRoleCode int
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure deletes all UserRoleUser data by a key.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@UserRoleCode IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	DELETE FROM
	      [dbo].[trelUsers_UserRoleUser]
	WHERE [UserRoleCode] =  @UserRoleCode

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spUsers_DeleteOneAccessMode
	  @SqlErrorNumber int = 0 OUTPUT
	, @Timestamp timestamp = NULL OUTPUT
	, @CheckTimestamp bit = 0
	, @AccessModeCode int
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure deletes AccessMode data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@AccessModeCode IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END
/*
** record validation
*/
IF NOT EXISTS (SELECT [AccessModeCode] FROM [dbo].[tlkpUsers_AccessMode] WHERE [AccessModeCode] =  @AccessModeCode)
BEGIN
	SET @SqlErrorNumber = -1003
	GOTO EXIT_ERROR
END
/*
** timestamp validation
*/
IF (@CheckTimestamp = 1)
BEGIN
	IF EXISTS (SELECT [AccessModeCode] FROM [dbo].[tlkpUsers_AccessMode] WHERE [AccessModeCode] =  @AccessModeCode AND [Timestamp] <> @Timestamp)
	BEGIN
		SET @SqlErrorNumber = -1002
		GOTO EXIT_ERROR
	END
END

/*
** perform main procedure tasks
*/
BEGIN
	DELETE FROM
	      [dbo].[tlkpUsers_AccessMode]
	WHERE [AccessModeCode] =  @AccessModeCode

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spUsers_DeleteOneActivity
	  @SqlErrorNumber int = 0 OUTPUT
	, @Timestamp timestamp = NULL OUTPUT
	, @CheckTimestamp bit = 0
	, @ActivityCode int
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure deletes Activity data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@ActivityCode IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END
/*
** record validation
*/
IF NOT EXISTS (SELECT [ActivityCode] FROM [dbo].[tlkpUsers_Activity] WHERE [ActivityCode] =  @ActivityCode)
BEGIN
	SET @SqlErrorNumber = -1003
	GOTO EXIT_ERROR
END
/*
** timestamp validation
*/
IF (@CheckTimestamp = 1)
BEGIN
	IF EXISTS (SELECT [ActivityCode] FROM [dbo].[tlkpUsers_Activity] WHERE [ActivityCode] =  @ActivityCode AND [Timestamp] <> @Timestamp)
	BEGIN
		SET @SqlErrorNumber = -1002
		GOTO EXIT_ERROR
	END
END

/*
** perform main procedure tasks
*/
BEGIN
	DELETE FROM
	      [dbo].[tlkpUsers_Activity]
	WHERE [ActivityCode] =  @ActivityCode

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spUsers_DeleteOneUser
	  @SqlErrorNumber int = 0 OUTPUT
	, @Timestamp timestamp = NULL OUTPUT
	, @CheckTimestamp bit = 0
	, @UserID uniqueidentifier
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure deletes User data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@UserID IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END
/*
** record validation
*/
IF NOT EXISTS (SELECT [UserID] FROM [dbo].[tblUsers_User] WHERE [UserID] =  @UserID)
BEGIN
	SET @SqlErrorNumber = -1003
	GOTO EXIT_ERROR
END
/*
** timestamp validation
*/
IF (@CheckTimestamp = 1)
BEGIN
	IF EXISTS (SELECT [UserID] FROM [dbo].[tblUsers_User] WHERE [UserID] =  @UserID AND [Timestamp] <> @Timestamp)
	BEGIN
		SET @SqlErrorNumber = -1002
		GOTO EXIT_ERROR
	END
END

/*
** perform main procedure tasks
*/
BEGIN
	DELETE FROM
	      [dbo].[tblUsers_User]
	WHERE [UserID] =  @UserID

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spUsers_DeleteOneUserRole
	  @SqlErrorNumber int = 0 OUTPUT
	, @Timestamp timestamp = NULL OUTPUT
	, @CheckTimestamp bit = 0
	, @UserRoleCode int
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure deletes UserRole data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@UserRoleCode IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END
/*
** record validation
*/
IF NOT EXISTS (SELECT [UserRoleCode] FROM [dbo].[tlkpUsers_UserRole] WHERE [UserRoleCode] =  @UserRoleCode)
BEGIN
	SET @SqlErrorNumber = -1003
	GOTO EXIT_ERROR
END
/*
** timestamp validation
*/
IF (@CheckTimestamp = 1)
BEGIN
	IF EXISTS (SELECT [UserRoleCode] FROM [dbo].[tlkpUsers_UserRole] WHERE [UserRoleCode] =  @UserRoleCode AND [Timestamp] <> @Timestamp)
	BEGIN
		SET @SqlErrorNumber = -1002
		GOTO EXIT_ERROR
	END
END

/*
** perform main procedure tasks
*/
BEGIN
	DELETE FROM
	      [dbo].[tlkpUsers_UserRole]
	WHERE [UserRoleCode] =  @UserRoleCode

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spUsers_DeleteOneUserRoleActivity
	  @SqlErrorNumber int = 0 OUTPUT
	, @Timestamp timestamp = NULL OUTPUT
	, @CheckTimestamp bit = 0
	, @UserRoleCode int
	, @ActivityCode int
	, @AccessModeCode int
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure deletes UserRoleActivity data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@UserRoleCode IS NULL OR @ActivityCode IS NULL OR @AccessModeCode IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END
/*
** record validation
*/
IF NOT EXISTS (SELECT [UserRoleCode], [ActivityCode], [AccessModeCode] FROM [dbo].[trelUsers_UserRoleActivity] WHERE [UserRoleCode] =  @UserRoleCode AND [ActivityCode] =  @ActivityCode AND [AccessModeCode] =  @AccessModeCode)
BEGIN
	SET @SqlErrorNumber = -1003
	GOTO EXIT_ERROR
END
/*
** timestamp validation
*/
IF (@CheckTimestamp = 1)
BEGIN
	IF EXISTS (SELECT [UserRoleCode], [ActivityCode], [AccessModeCode] FROM [dbo].[trelUsers_UserRoleActivity] WHERE [UserRoleCode] =  @UserRoleCode AND [ActivityCode] =  @ActivityCode AND [AccessModeCode] =  @AccessModeCode AND [Timestamp] <> @Timestamp)
	BEGIN
		SET @SqlErrorNumber = -1002
		GOTO EXIT_ERROR
	END
END

/*
** perform main procedure tasks
*/
BEGIN
	DELETE FROM
	      [dbo].[trelUsers_UserRoleActivity]
	WHERE [UserRoleCode] =  @UserRoleCode AND [ActivityCode] =  @ActivityCode AND [AccessModeCode] =  @AccessModeCode

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spUsers_DeleteOneUserRoleUser
	  @SqlErrorNumber int = 0 OUTPUT
	, @Timestamp timestamp = NULL OUTPUT
	, @CheckTimestamp bit = 0
	, @UserRoleCode int
	, @UserID uniqueidentifier
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure deletes UserRoleUser data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@UserRoleCode IS NULL OR @UserID IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END
/*
** record validation
*/
IF NOT EXISTS (SELECT [UserRoleCode], [UserID] FROM [dbo].[trelUsers_UserRoleUser] WHERE [UserRoleCode] =  @UserRoleCode AND [UserID] =  @UserID)
BEGIN
	SET @SqlErrorNumber = -1003
	GOTO EXIT_ERROR
END
/*
** timestamp validation
*/
IF (@CheckTimestamp = 1)
BEGIN
	IF EXISTS (SELECT [UserRoleCode], [UserID] FROM [dbo].[trelUsers_UserRoleUser] WHERE [UserRoleCode] =  @UserRoleCode AND [UserID] =  @UserID AND [Timestamp] <> @Timestamp)
	BEGIN
		SET @SqlErrorNumber = -1002
		GOTO EXIT_ERROR
	END
END

/*
** perform main procedure tasks
*/
BEGIN
	DELETE FROM
	      [dbo].[trelUsers_UserRoleUser]
	WHERE [UserRoleCode] =  @UserRoleCode AND [UserID] =  @UserID

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spUsers_GetAllAccessModeData
	  @SqlErrorNumber int = 0 OUTPUT
	, @SortColumn sysname = 'AccessModeCode'
	, @SortDirection nvarchar(20) = 'Ascending'
	, @IncludeInactive bit = 0
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets all AccessMode data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0
IF (@SortColumn = '') SET @SortColumn='AccessModeCode'

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

IF (@SortDirection = 'Random')
BEGIN
	SELECT
		  AccessMode1.[AccessModeCode]
		, AccessMode1.[AccessModeName]
		, AccessMode1.[Description]
		, AccessMode1.[IsActive]
		, AccessMode1.[CreatedByUserID]
		, AccessMode1.[CreatedDate]
		, AccessMode1.[LastModifiedByUserID]
		, AccessMode1.[LastModifiedDate]
		, AccessMode1.[Timestamp]
	FROM
	      [dbo].[tlkpUsers_AccessMode] AccessMode1
	WHERE 
		AccessMode1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN AccessMode1.[IsActive] ELSE 1 END

	ORDER BY NewID()
END
ELSE
BEGIN
	SELECT
		  AccessMode1.[AccessModeCode]
		, AccessMode1.[AccessModeName]
		, AccessMode1.[Description]
		, AccessMode1.[IsActive]
		, AccessMode1.[CreatedByUserID]
		, AccessMode1.[CreatedDate]
		, AccessMode1.[LastModifiedByUserID]
		, AccessMode1.[LastModifiedDate]
		, AccessMode1.[Timestamp]
	FROM
	      [dbo].[tlkpUsers_AccessMode] AccessMode1
	WHERE 
		AccessMode1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN AccessMode1.[IsActive] ELSE 1 END

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AccessModeCode' THEN AccessMode1.[AccessModeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AccessModeCode' THEN AccessMode1.[AccessModeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AccessModeName' THEN AccessMode1.[AccessModeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AccessModeName' THEN AccessMode1.[AccessModeName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Description' THEN AccessMode1.[Description] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Description' THEN AccessMode1.[Description] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'IsActive' THEN AccessMode1.[IsActive] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'IsActive' THEN AccessMode1.[IsActive] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN AccessMode1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN AccessMode1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN AccessMode1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN AccessMode1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN AccessMode1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN AccessMode1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN AccessMode1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN AccessMode1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN AccessMode1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN AccessMode1.[Timestamp] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END


RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spUsers_GetAllActivityData
	  @SqlErrorNumber int = 0 OUTPUT
	, @SortColumn sysname = 'ActivityCode'
	, @SortDirection nvarchar(20) = 'Ascending'
	, @IncludeInactive bit = 0
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets all Activity data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0
IF (@SortColumn = '') SET @SortColumn='ActivityCode'

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

IF (@SortDirection = 'Random')
BEGIN
	SELECT
		  Activity1.[ActivityCode]
		, Activity1.[ActivityName]
		, Activity1.[Description]
		, Activity1.[IsActive]
		, Activity1.[CreatedByUserID]
		, Activity1.[CreatedDate]
		, Activity1.[LastModifiedByUserID]
		, Activity1.[LastModifiedDate]
		, Activity1.[Timestamp]
	FROM
	      [dbo].[tlkpUsers_Activity] Activity1
	WHERE 
		Activity1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN Activity1.[IsActive] ELSE 1 END

	ORDER BY NewID()
END
ELSE
BEGIN
	SELECT
		  Activity1.[ActivityCode]
		, Activity1.[ActivityName]
		, Activity1.[Description]
		, Activity1.[IsActive]
		, Activity1.[CreatedByUserID]
		, Activity1.[CreatedDate]
		, Activity1.[LastModifiedByUserID]
		, Activity1.[LastModifiedDate]
		, Activity1.[Timestamp]
	FROM
	      [dbo].[tlkpUsers_Activity] Activity1
	WHERE 
		Activity1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN Activity1.[IsActive] ELSE 1 END

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'ActivityCode' THEN Activity1.[ActivityCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'ActivityCode' THEN Activity1.[ActivityCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'ActivityName' THEN Activity1.[ActivityName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'ActivityName' THEN Activity1.[ActivityName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Description' THEN Activity1.[Description] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Description' THEN Activity1.[Description] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'IsActive' THEN Activity1.[IsActive] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'IsActive' THEN Activity1.[IsActive] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN Activity1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN Activity1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN Activity1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN Activity1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN Activity1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN Activity1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN Activity1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN Activity1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN Activity1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN Activity1.[Timestamp] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END


RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spUsers_GetAllUserData
	  @SqlErrorNumber int = 0 OUTPUT
	, @SortColumn sysname = 'UserID'
	, @SortDirection nvarchar(20) = 'Ascending'
	, @IncludeInactive bit = 0
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets all User data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0
IF (@SortColumn = '') SET @SortColumn='UserID'

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

IF (@SortDirection = 'Random')
BEGIN
	SELECT
		  User1.[UserID]
		, User1.[UserName]
		, User1.[FirstName]
		, User1.[LastName]
		, User1.[Password]
		, User1.[LocaleCode]
		, User1.[IsActive]
		, User1.[CreatedByUserID]
		, User1.[CreatedDate]
		, User1.[LastModifiedByUserID]
		, User1.[LastModifiedDate]
		, User1.[Timestamp]
	FROM
	      [dbo].[tblUsers_User] User1
	WHERE 
		User1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN User1.[IsActive] ELSE 1 END

	ORDER BY NewID()
END
ELSE
BEGIN
	SELECT
		  User1.[UserID]
		, User1.[UserName]
		, User1.[FirstName]
		, User1.[LastName]
		, User1.[Password]
		, User1.[LocaleCode]
		, User1.[IsActive]
		, User1.[CreatedByUserID]
		, User1.[CreatedDate]
		, User1.[LastModifiedByUserID]
		, User1.[LastModifiedDate]
		, User1.[Timestamp]
	FROM
	      [dbo].[tblUsers_User] User1
	WHERE 
		User1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN User1.[IsActive] ELSE 1 END

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'UserID' THEN User1.[UserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'UserID' THEN User1.[UserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'UserName' THEN User1.[UserName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'UserName' THEN User1.[UserName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'FirstName' THEN User1.[FirstName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'FirstName' THEN User1.[FirstName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastName' THEN User1.[LastName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastName' THEN User1.[LastName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Password' THEN User1.[Password] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Password' THEN User1.[Password] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LocaleCode' THEN User1.[LocaleCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LocaleCode' THEN User1.[LocaleCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'IsActive' THEN User1.[IsActive] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'IsActive' THEN User1.[IsActive] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN User1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN User1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN User1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN User1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN User1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN User1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN User1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN User1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN User1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN User1.[Timestamp] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END


RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spUsers_GetAllUserDataByCriteria
	  @SqlErrorNumber int = 0 OUTPUT
	, @SortColumn sysname = 'UserName'
	, @SortDirection nvarchar(20) = 'Ascending'
	, @IncludeInactive bit = 0
	, @UserName nvarchar(50) = NULL
	, @FirstName nvarchar(100) = NULL
	, @LastName nvarchar(100) = NULL
	, @LastModifiedDateStart datetime = getdate
	, @LastModifiedDateEnd datetime = getdate
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets all User data by criteria.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0
IF (@SortColumn = '') SET @SortColumn='UserName'

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

IF (@SortDirection = 'Random')
BEGIN
	SELECT
		  User1.[UserID]
		, User1.[UserName]
		, User1.[FirstName]
		, User1.[LastName]
		, User1.[Password]
		, User1.[LocaleCode]
		, User1.[IsActive]
		, User1.[CreatedByUserID]
		, User1.[CreatedDate]
		, User1.[LastModifiedByUserID]
		, User1.[LastModifiedDate]
		, User1.[Timestamp]
	FROM
	      [dbo].[tblUsers_User] User1
	WHERE 
		User1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN User1.[IsActive] ELSE 1 END
		AND (@UserName IS NULL OR User1.[UserName] like '%' + @UserName + '%')
		AND (@FirstName IS NULL OR User1.[FirstName] like '%' + @FirstName + '%')
		AND (@LastName IS NULL OR User1.[LastName] like '%' + @LastName + '%')
		AND ((@LastModifiedDateStart  IS NULL) OR (User1.[LastModifiedDate] >=  @LastModifiedDateStart))
		AND ((@LastModifiedDateEnd  IS NULL) OR (User1.[LastModifiedDate] <=  @LastModifiedDateEnd))

	ORDER BY NewID()
END
ELSE
BEGIN
	SELECT
		  User1.[UserID]
		, User1.[UserName]
		, User1.[FirstName]
		, User1.[LastName]
		, User1.[Password]
		, User1.[LocaleCode]
		, User1.[IsActive]
		, User1.[CreatedByUserID]
		, User1.[CreatedDate]
		, User1.[LastModifiedByUserID]
		, User1.[LastModifiedDate]
		, User1.[Timestamp]
	FROM
	      [dbo].[tblUsers_User] User1
	WHERE 
		User1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN User1.[IsActive] ELSE 1 END
		AND (@UserName IS NULL OR User1.[UserName] like '%' + @UserName + '%')
		AND (@FirstName IS NULL OR User1.[FirstName] like '%' + @FirstName + '%')
		AND (@LastName IS NULL OR User1.[LastName] like '%' + @LastName + '%')
		AND ((@LastModifiedDateStart  IS NULL) OR (User1.[LastModifiedDate] >=  @LastModifiedDateStart))
		AND ((@LastModifiedDateEnd  IS NULL) OR (User1.[LastModifiedDate] <=  @LastModifiedDateEnd))

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'UserID' THEN User1.[UserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'UserID' THEN User1.[UserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'UserName' THEN User1.[UserName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'UserName' THEN User1.[UserName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'FirstName' THEN User1.[FirstName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'FirstName' THEN User1.[FirstName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastName' THEN User1.[LastName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastName' THEN User1.[LastName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Password' THEN User1.[Password] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Password' THEN User1.[Password] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LocaleCode' THEN User1.[LocaleCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LocaleCode' THEN User1.[LocaleCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'IsActive' THEN User1.[IsActive] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'IsActive' THEN User1.[IsActive] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN User1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN User1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN User1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN User1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN User1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN User1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN User1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN User1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN User1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN User1.[Timestamp] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END


RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spUsers_GetAllUserRoleActivityData
	  @SqlErrorNumber int = 0 OUTPUT
	, @SortColumn sysname = 'UserRoleCode'
	, @SortDirection nvarchar(20) = 'Ascending'
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets all UserRoleActivity data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0
IF (@SortColumn = '') SET @SortColumn='UserRoleCode'

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

IF (@SortDirection = 'Random')
BEGIN
	SELECT
		  UserRoleActivity1.[UserRoleCode]
		, UserRoleActivity1.[ActivityCode]
		, UserRoleActivity1.[AccessModeCode]
		, UserRoleActivity1.[CreatedByUserID]
		, UserRoleActivity1.[CreatedDate]
		, UserRoleActivity1.[LastModifiedByUserID]
		, UserRoleActivity1.[LastModifiedDate]
		, UserRoleActivity1.[Timestamp]
		, UserRole1.[UserRoleName]
		, Activity1.[ActivityName]
		, AccessMode1.[AccessModeName]
	FROM
	      [dbo].[trelUsers_UserRoleActivity] UserRoleActivity1
	INNER JOIN [dbo].[tlkpUsers_UserRole] UserRole1 ON UserRole1.[UserRoleCode]=UserRoleActivity1.[UserRoleCode]
	INNER JOIN [dbo].[tlkpUsers_Activity] Activity1 ON Activity1.[ActivityCode]=UserRoleActivity1.[ActivityCode]
	INNER JOIN [dbo].[tlkpUsers_AccessMode] AccessMode1 ON AccessMode1.[AccessModeCode]=UserRoleActivity1.[AccessModeCode]

	ORDER BY NewID()
END
ELSE
BEGIN
	SELECT
		  UserRoleActivity1.[UserRoleCode]
		, UserRoleActivity1.[ActivityCode]
		, UserRoleActivity1.[AccessModeCode]
		, UserRoleActivity1.[CreatedByUserID]
		, UserRoleActivity1.[CreatedDate]
		, UserRoleActivity1.[LastModifiedByUserID]
		, UserRoleActivity1.[LastModifiedDate]
		, UserRoleActivity1.[Timestamp]
		, UserRole1.[UserRoleName]
		, Activity1.[ActivityName]
		, AccessMode1.[AccessModeName]
	FROM
	      [dbo].[trelUsers_UserRoleActivity] UserRoleActivity1
	INNER JOIN [dbo].[tlkpUsers_UserRole] UserRole1 ON UserRole1.[UserRoleCode]=UserRoleActivity1.[UserRoleCode]
	INNER JOIN [dbo].[tlkpUsers_Activity] Activity1 ON Activity1.[ActivityCode]=UserRoleActivity1.[ActivityCode]
	INNER JOIN [dbo].[tlkpUsers_AccessMode] AccessMode1 ON AccessMode1.[AccessModeCode]=UserRoleActivity1.[AccessModeCode]

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'UserRoleCode' THEN UserRoleActivity1.[UserRoleCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'UserRoleCode' THEN UserRoleActivity1.[UserRoleCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'ActivityCode' THEN UserRoleActivity1.[ActivityCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'ActivityCode' THEN UserRoleActivity1.[ActivityCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AccessModeCode' THEN UserRoleActivity1.[AccessModeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AccessModeCode' THEN UserRoleActivity1.[AccessModeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN UserRoleActivity1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN UserRoleActivity1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN UserRoleActivity1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN UserRoleActivity1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN UserRoleActivity1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN UserRoleActivity1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN UserRoleActivity1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN UserRoleActivity1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN UserRoleActivity1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN UserRoleActivity1.[Timestamp] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'UserRoleName' THEN UserRole1.[UserRoleName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'UserRoleName' THEN UserRole1.[UserRoleName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'ActivityName' THEN Activity1.[ActivityName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'ActivityName' THEN Activity1.[ActivityName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AccessModeName' THEN AccessMode1.[AccessModeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AccessModeName' THEN AccessMode1.[AccessModeName] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END


RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spUsers_GetAllUserRoleActivityDataByAccessModeCode
	  @SqlErrorNumber int = 0 OUTPUT
	, @SortColumn sysname = 'AccessModeCode'
	, @SortDirection nvarchar(20) = 'Ascending'
	, @AccessModeCode int
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets all UserRoleActivity data by a key.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0
IF (@SortColumn = '') SET @SortColumn='AccessModeCode'

/*
** parameter validation
*/
IF (@AccessModeCode IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

IF (@SortDirection = 'Random')
BEGIN
	SELECT
		  UserRoleActivity1.[UserRoleCode]
		, UserRoleActivity1.[ActivityCode]
		, UserRoleActivity1.[AccessModeCode]
		, UserRoleActivity1.[CreatedByUserID]
		, UserRoleActivity1.[CreatedDate]
		, UserRoleActivity1.[LastModifiedByUserID]
		, UserRoleActivity1.[LastModifiedDate]
		, UserRoleActivity1.[Timestamp]
		, UserRole1.[UserRoleName]
		, Activity1.[ActivityName]
		, AccessMode1.[AccessModeName]
	FROM
	      [dbo].[trelUsers_UserRoleActivity] UserRoleActivity1
	INNER JOIN [dbo].[tlkpUsers_UserRole] UserRole1 ON UserRole1.[UserRoleCode]=UserRoleActivity1.[UserRoleCode]
	INNER JOIN [dbo].[tlkpUsers_Activity] Activity1 ON Activity1.[ActivityCode]=UserRoleActivity1.[ActivityCode]
	INNER JOIN [dbo].[tlkpUsers_AccessMode] AccessMode1 ON AccessMode1.[AccessModeCode]=UserRoleActivity1.[AccessModeCode]
	WHERE 
		UserRoleActivity1.[AccessModeCode] = @AccessModeCode

	ORDER BY NewID()
END
ELSE
BEGIN
	SELECT
		  UserRoleActivity1.[UserRoleCode]
		, UserRoleActivity1.[ActivityCode]
		, UserRoleActivity1.[AccessModeCode]
		, UserRoleActivity1.[CreatedByUserID]
		, UserRoleActivity1.[CreatedDate]
		, UserRoleActivity1.[LastModifiedByUserID]
		, UserRoleActivity1.[LastModifiedDate]
		, UserRoleActivity1.[Timestamp]
		, UserRole1.[UserRoleName]
		, Activity1.[ActivityName]
		, AccessMode1.[AccessModeName]
	FROM
	      [dbo].[trelUsers_UserRoleActivity] UserRoleActivity1
	INNER JOIN [dbo].[tlkpUsers_UserRole] UserRole1 ON UserRole1.[UserRoleCode]=UserRoleActivity1.[UserRoleCode]
	INNER JOIN [dbo].[tlkpUsers_Activity] Activity1 ON Activity1.[ActivityCode]=UserRoleActivity1.[ActivityCode]
	INNER JOIN [dbo].[tlkpUsers_AccessMode] AccessMode1 ON AccessMode1.[AccessModeCode]=UserRoleActivity1.[AccessModeCode]
	WHERE 
		UserRoleActivity1.[AccessModeCode] = @AccessModeCode

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'UserRoleCode' THEN UserRoleActivity1.[UserRoleCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'UserRoleCode' THEN UserRoleActivity1.[UserRoleCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'ActivityCode' THEN UserRoleActivity1.[ActivityCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'ActivityCode' THEN UserRoleActivity1.[ActivityCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AccessModeCode' THEN UserRoleActivity1.[AccessModeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AccessModeCode' THEN UserRoleActivity1.[AccessModeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN UserRoleActivity1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN UserRoleActivity1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN UserRoleActivity1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN UserRoleActivity1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN UserRoleActivity1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN UserRoleActivity1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN UserRoleActivity1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN UserRoleActivity1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN UserRoleActivity1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN UserRoleActivity1.[Timestamp] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'UserRoleName' THEN UserRole1.[UserRoleName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'UserRoleName' THEN UserRole1.[UserRoleName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'ActivityName' THEN Activity1.[ActivityName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'ActivityName' THEN Activity1.[ActivityName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AccessModeName' THEN AccessMode1.[AccessModeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AccessModeName' THEN AccessMode1.[AccessModeName] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END


RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spUsers_GetAllUserRoleActivityDataByActivityCode
	  @SqlErrorNumber int = 0 OUTPUT
	, @SortColumn sysname = 'ActivityCode'
	, @SortDirection nvarchar(20) = 'Ascending'
	, @ActivityCode int
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets all UserRoleActivity data by a key.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0
IF (@SortColumn = '') SET @SortColumn='ActivityCode'

/*
** parameter validation
*/
IF (@ActivityCode IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

IF (@SortDirection = 'Random')
BEGIN
	SELECT
		  UserRoleActivity1.[UserRoleCode]
		, UserRoleActivity1.[ActivityCode]
		, UserRoleActivity1.[AccessModeCode]
		, UserRoleActivity1.[CreatedByUserID]
		, UserRoleActivity1.[CreatedDate]
		, UserRoleActivity1.[LastModifiedByUserID]
		, UserRoleActivity1.[LastModifiedDate]
		, UserRoleActivity1.[Timestamp]
		, UserRole1.[UserRoleName]
		, Activity1.[ActivityName]
		, AccessMode1.[AccessModeName]
	FROM
	      [dbo].[trelUsers_UserRoleActivity] UserRoleActivity1
	INNER JOIN [dbo].[tlkpUsers_UserRole] UserRole1 ON UserRole1.[UserRoleCode]=UserRoleActivity1.[UserRoleCode]
	INNER JOIN [dbo].[tlkpUsers_Activity] Activity1 ON Activity1.[ActivityCode]=UserRoleActivity1.[ActivityCode]
	INNER JOIN [dbo].[tlkpUsers_AccessMode] AccessMode1 ON AccessMode1.[AccessModeCode]=UserRoleActivity1.[AccessModeCode]
	WHERE 
		UserRoleActivity1.[ActivityCode] = @ActivityCode

	ORDER BY NewID()
END
ELSE
BEGIN
	SELECT
		  UserRoleActivity1.[UserRoleCode]
		, UserRoleActivity1.[ActivityCode]
		, UserRoleActivity1.[AccessModeCode]
		, UserRoleActivity1.[CreatedByUserID]
		, UserRoleActivity1.[CreatedDate]
		, UserRoleActivity1.[LastModifiedByUserID]
		, UserRoleActivity1.[LastModifiedDate]
		, UserRoleActivity1.[Timestamp]
		, UserRole1.[UserRoleName]
		, Activity1.[ActivityName]
		, AccessMode1.[AccessModeName]
	FROM
	      [dbo].[trelUsers_UserRoleActivity] UserRoleActivity1
	INNER JOIN [dbo].[tlkpUsers_UserRole] UserRole1 ON UserRole1.[UserRoleCode]=UserRoleActivity1.[UserRoleCode]
	INNER JOIN [dbo].[tlkpUsers_Activity] Activity1 ON Activity1.[ActivityCode]=UserRoleActivity1.[ActivityCode]
	INNER JOIN [dbo].[tlkpUsers_AccessMode] AccessMode1 ON AccessMode1.[AccessModeCode]=UserRoleActivity1.[AccessModeCode]
	WHERE 
		UserRoleActivity1.[ActivityCode] = @ActivityCode

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'UserRoleCode' THEN UserRoleActivity1.[UserRoleCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'UserRoleCode' THEN UserRoleActivity1.[UserRoleCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'ActivityCode' THEN UserRoleActivity1.[ActivityCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'ActivityCode' THEN UserRoleActivity1.[ActivityCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AccessModeCode' THEN UserRoleActivity1.[AccessModeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AccessModeCode' THEN UserRoleActivity1.[AccessModeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN UserRoleActivity1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN UserRoleActivity1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN UserRoleActivity1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN UserRoleActivity1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN UserRoleActivity1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN UserRoleActivity1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN UserRoleActivity1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN UserRoleActivity1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN UserRoleActivity1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN UserRoleActivity1.[Timestamp] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'UserRoleName' THEN UserRole1.[UserRoleName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'UserRoleName' THEN UserRole1.[UserRoleName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'ActivityName' THEN Activity1.[ActivityName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'ActivityName' THEN Activity1.[ActivityName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AccessModeName' THEN AccessMode1.[AccessModeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AccessModeName' THEN AccessMode1.[AccessModeName] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END


RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spUsers_GetAllUserRoleActivityDataByUserRoleCode
	  @SqlErrorNumber int = 0 OUTPUT
	, @SortColumn sysname = 'UserRoleCode'
	, @SortDirection nvarchar(20) = 'Ascending'
	, @UserRoleCode int
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets all UserRoleActivity data by a key.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0
IF (@SortColumn = '') SET @SortColumn='UserRoleCode'

/*
** parameter validation
*/
IF (@UserRoleCode IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

IF (@SortDirection = 'Random')
BEGIN
	SELECT
		  UserRoleActivity1.[UserRoleCode]
		, UserRoleActivity1.[ActivityCode]
		, UserRoleActivity1.[AccessModeCode]
		, UserRoleActivity1.[CreatedByUserID]
		, UserRoleActivity1.[CreatedDate]
		, UserRoleActivity1.[LastModifiedByUserID]
		, UserRoleActivity1.[LastModifiedDate]
		, UserRoleActivity1.[Timestamp]
		, UserRole1.[UserRoleName]
		, Activity1.[ActivityName]
		, AccessMode1.[AccessModeName]
	FROM
	      [dbo].[trelUsers_UserRoleActivity] UserRoleActivity1
	INNER JOIN [dbo].[tlkpUsers_UserRole] UserRole1 ON UserRole1.[UserRoleCode]=UserRoleActivity1.[UserRoleCode]
	INNER JOIN [dbo].[tlkpUsers_Activity] Activity1 ON Activity1.[ActivityCode]=UserRoleActivity1.[ActivityCode]
	INNER JOIN [dbo].[tlkpUsers_AccessMode] AccessMode1 ON AccessMode1.[AccessModeCode]=UserRoleActivity1.[AccessModeCode]
	WHERE 
		UserRoleActivity1.[UserRoleCode] = @UserRoleCode

	ORDER BY NewID()
END
ELSE
BEGIN
	SELECT
		  UserRoleActivity1.[UserRoleCode]
		, UserRoleActivity1.[ActivityCode]
		, UserRoleActivity1.[AccessModeCode]
		, UserRoleActivity1.[CreatedByUserID]
		, UserRoleActivity1.[CreatedDate]
		, UserRoleActivity1.[LastModifiedByUserID]
		, UserRoleActivity1.[LastModifiedDate]
		, UserRoleActivity1.[Timestamp]
		, UserRole1.[UserRoleName]
		, Activity1.[ActivityName]
		, AccessMode1.[AccessModeName]
	FROM
	      [dbo].[trelUsers_UserRoleActivity] UserRoleActivity1
	INNER JOIN [dbo].[tlkpUsers_UserRole] UserRole1 ON UserRole1.[UserRoleCode]=UserRoleActivity1.[UserRoleCode]
	INNER JOIN [dbo].[tlkpUsers_Activity] Activity1 ON Activity1.[ActivityCode]=UserRoleActivity1.[ActivityCode]
	INNER JOIN [dbo].[tlkpUsers_AccessMode] AccessMode1 ON AccessMode1.[AccessModeCode]=UserRoleActivity1.[AccessModeCode]
	WHERE 
		UserRoleActivity1.[UserRoleCode] = @UserRoleCode

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'UserRoleCode' THEN UserRoleActivity1.[UserRoleCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'UserRoleCode' THEN UserRoleActivity1.[UserRoleCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'ActivityCode' THEN UserRoleActivity1.[ActivityCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'ActivityCode' THEN UserRoleActivity1.[ActivityCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AccessModeCode' THEN UserRoleActivity1.[AccessModeCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AccessModeCode' THEN UserRoleActivity1.[AccessModeCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN UserRoleActivity1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN UserRoleActivity1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN UserRoleActivity1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN UserRoleActivity1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN UserRoleActivity1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN UserRoleActivity1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN UserRoleActivity1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN UserRoleActivity1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN UserRoleActivity1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN UserRoleActivity1.[Timestamp] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'UserRoleName' THEN UserRole1.[UserRoleName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'UserRoleName' THEN UserRole1.[UserRoleName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'ActivityName' THEN Activity1.[ActivityName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'ActivityName' THEN Activity1.[ActivityName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'AccessModeName' THEN AccessMode1.[AccessModeName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'AccessModeName' THEN AccessMode1.[AccessModeName] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END


RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spUsers_GetAllUserRoleData
	  @SqlErrorNumber int = 0 OUTPUT
	, @SortColumn sysname = 'UserRoleCode'
	, @SortDirection nvarchar(20) = 'Ascending'
	, @IncludeInactive bit = 0
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets all UserRole data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0
IF (@SortColumn = '') SET @SortColumn='UserRoleCode'

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

IF (@SortDirection = 'Random')
BEGIN
	SELECT
		  UserRole1.[UserRoleCode]
		, UserRole1.[UserRoleName]
		, UserRole1.[Description]
		, UserRole1.[IsActive]
		, UserRole1.[CreatedByUserID]
		, UserRole1.[CreatedDate]
		, UserRole1.[LastModifiedByUserID]
		, UserRole1.[LastModifiedDate]
		, UserRole1.[Timestamp]
	FROM
	      [dbo].[tlkpUsers_UserRole] UserRole1
	WHERE 
		UserRole1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN UserRole1.[IsActive] ELSE 1 END

	ORDER BY NewID()
END
ELSE
BEGIN
	SELECT
		  UserRole1.[UserRoleCode]
		, UserRole1.[UserRoleName]
		, UserRole1.[Description]
		, UserRole1.[IsActive]
		, UserRole1.[CreatedByUserID]
		, UserRole1.[CreatedDate]
		, UserRole1.[LastModifiedByUserID]
		, UserRole1.[LastModifiedDate]
		, UserRole1.[Timestamp]
	FROM
	      [dbo].[tlkpUsers_UserRole] UserRole1
	WHERE 
		UserRole1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN UserRole1.[IsActive] ELSE 1 END

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'UserRoleCode' THEN UserRole1.[UserRoleCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'UserRoleCode' THEN UserRole1.[UserRoleCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'UserRoleName' THEN UserRole1.[UserRoleName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'UserRoleName' THEN UserRole1.[UserRoleName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Description' THEN UserRole1.[Description] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Description' THEN UserRole1.[Description] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'IsActive' THEN UserRole1.[IsActive] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'IsActive' THEN UserRole1.[IsActive] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN UserRole1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN UserRole1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN UserRole1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN UserRole1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN UserRole1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN UserRole1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN UserRole1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN UserRole1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN UserRole1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN UserRole1.[Timestamp] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END


RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spUsers_GetAllUserRoleUserData
	  @SqlErrorNumber int = 0 OUTPUT
	, @SortColumn sysname = 'UserRoleCode'
	, @SortDirection nvarchar(20) = 'Ascending'
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets all UserRoleUser data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0
IF (@SortColumn = '') SET @SortColumn='UserRoleCode'

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

IF (@SortDirection = 'Random')
BEGIN
	SELECT
		  UserRoleUser1.[UserRoleCode]
		, UserRoleUser1.[UserID]
		, UserRoleUser1.[CreatedByUserID]
		, UserRoleUser1.[CreatedDate]
		, UserRoleUser1.[LastModifiedByUserID]
		, UserRoleUser1.[LastModifiedDate]
		, UserRoleUser1.[Timestamp]
		, UserRole1.[UserRoleName]
		, User1.[UserName]
		, User1.[FirstName]
		, User1.[LastName]
	FROM
	      [dbo].[trelUsers_UserRoleUser] UserRoleUser1
	INNER JOIN [dbo].[tlkpUsers_UserRole] UserRole1 ON UserRole1.[UserRoleCode]=UserRoleUser1.[UserRoleCode]
	INNER JOIN [dbo].[tblUsers_User] User1 ON User1.[UserID]=UserRoleUser1.[UserID]

	ORDER BY NewID()
END
ELSE
BEGIN
	SELECT
		  UserRoleUser1.[UserRoleCode]
		, UserRoleUser1.[UserID]
		, UserRoleUser1.[CreatedByUserID]
		, UserRoleUser1.[CreatedDate]
		, UserRoleUser1.[LastModifiedByUserID]
		, UserRoleUser1.[LastModifiedDate]
		, UserRoleUser1.[Timestamp]
		, UserRole1.[UserRoleName]
		, User1.[UserName]
		, User1.[FirstName]
		, User1.[LastName]
	FROM
	      [dbo].[trelUsers_UserRoleUser] UserRoleUser1
	INNER JOIN [dbo].[tlkpUsers_UserRole] UserRole1 ON UserRole1.[UserRoleCode]=UserRoleUser1.[UserRoleCode]
	INNER JOIN [dbo].[tblUsers_User] User1 ON User1.[UserID]=UserRoleUser1.[UserID]

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'UserRoleCode' THEN UserRoleUser1.[UserRoleCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'UserRoleCode' THEN UserRoleUser1.[UserRoleCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'UserID' THEN UserRoleUser1.[UserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'UserID' THEN UserRoleUser1.[UserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN UserRoleUser1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN UserRoleUser1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN UserRoleUser1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN UserRoleUser1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN UserRoleUser1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN UserRoleUser1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN UserRoleUser1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN UserRoleUser1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN UserRoleUser1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN UserRoleUser1.[Timestamp] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'UserRoleName' THEN UserRole1.[UserRoleName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'UserRoleName' THEN UserRole1.[UserRoleName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'UserName' THEN User1.[UserName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'UserName' THEN User1.[UserName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'FirstName' THEN User1.[FirstName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'FirstName' THEN User1.[FirstName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastName' THEN User1.[LastName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastName' THEN User1.[LastName] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END


RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spUsers_GetAllUserRoleUserDataByUserID
	  @SqlErrorNumber int = 0 OUTPUT
	, @SortColumn sysname = 'UserID'
	, @SortDirection nvarchar(20) = 'Ascending'
	, @UserID uniqueidentifier
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets all UserRoleUser data by a key.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0
IF (@SortColumn = '') SET @SortColumn='UserID'

/*
** parameter validation
*/
IF (@UserID IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

IF (@SortDirection = 'Random')
BEGIN
	SELECT
		  UserRoleUser1.[UserRoleCode]
		, UserRoleUser1.[UserID]
		, UserRoleUser1.[CreatedByUserID]
		, UserRoleUser1.[CreatedDate]
		, UserRoleUser1.[LastModifiedByUserID]
		, UserRoleUser1.[LastModifiedDate]
		, UserRoleUser1.[Timestamp]
		, UserRole1.[UserRoleName]
		, User1.[UserName]
		, User1.[FirstName]
		, User1.[LastName]
	FROM
	      [dbo].[trelUsers_UserRoleUser] UserRoleUser1
	INNER JOIN [dbo].[tlkpUsers_UserRole] UserRole1 ON UserRole1.[UserRoleCode]=UserRoleUser1.[UserRoleCode]
	INNER JOIN [dbo].[tblUsers_User] User1 ON User1.[UserID]=UserRoleUser1.[UserID]
	WHERE 
		UserRoleUser1.[UserID] = @UserID

	ORDER BY NewID()
END
ELSE
BEGIN
	SELECT
		  UserRoleUser1.[UserRoleCode]
		, UserRoleUser1.[UserID]
		, UserRoleUser1.[CreatedByUserID]
		, UserRoleUser1.[CreatedDate]
		, UserRoleUser1.[LastModifiedByUserID]
		, UserRoleUser1.[LastModifiedDate]
		, UserRoleUser1.[Timestamp]
		, UserRole1.[UserRoleName]
		, User1.[UserName]
		, User1.[FirstName]
		, User1.[LastName]
	FROM
	      [dbo].[trelUsers_UserRoleUser] UserRoleUser1
	INNER JOIN [dbo].[tlkpUsers_UserRole] UserRole1 ON UserRole1.[UserRoleCode]=UserRoleUser1.[UserRoleCode]
	INNER JOIN [dbo].[tblUsers_User] User1 ON User1.[UserID]=UserRoleUser1.[UserID]
	WHERE 
		UserRoleUser1.[UserID] = @UserID

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'UserRoleCode' THEN UserRoleUser1.[UserRoleCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'UserRoleCode' THEN UserRoleUser1.[UserRoleCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'UserID' THEN UserRoleUser1.[UserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'UserID' THEN UserRoleUser1.[UserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN UserRoleUser1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN UserRoleUser1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN UserRoleUser1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN UserRoleUser1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN UserRoleUser1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN UserRoleUser1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN UserRoleUser1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN UserRoleUser1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN UserRoleUser1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN UserRoleUser1.[Timestamp] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'UserRoleName' THEN UserRole1.[UserRoleName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'UserRoleName' THEN UserRole1.[UserRoleName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'UserName' THEN User1.[UserName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'UserName' THEN User1.[UserName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'FirstName' THEN User1.[FirstName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'FirstName' THEN User1.[FirstName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastName' THEN User1.[LastName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastName' THEN User1.[LastName] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END


RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spUsers_GetAllUserRoleUserDataByUserRoleCode
	  @SqlErrorNumber int = 0 OUTPUT
	, @SortColumn sysname = 'UserRoleCode'
	, @SortDirection nvarchar(20) = 'Ascending'
	, @UserRoleCode int
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets all UserRoleUser data by a key.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0
IF (@SortColumn = '') SET @SortColumn='UserRoleCode'

/*
** parameter validation
*/
IF (@UserRoleCode IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

IF (@SortDirection = 'Random')
BEGIN
	SELECT
		  UserRoleUser1.[UserRoleCode]
		, UserRoleUser1.[UserID]
		, UserRoleUser1.[CreatedByUserID]
		, UserRoleUser1.[CreatedDate]
		, UserRoleUser1.[LastModifiedByUserID]
		, UserRoleUser1.[LastModifiedDate]
		, UserRoleUser1.[Timestamp]
		, UserRole1.[UserRoleName]
		, User1.[UserName]
		, User1.[FirstName]
		, User1.[LastName]
	FROM
	      [dbo].[trelUsers_UserRoleUser] UserRoleUser1
	INNER JOIN [dbo].[tlkpUsers_UserRole] UserRole1 ON UserRole1.[UserRoleCode]=UserRoleUser1.[UserRoleCode]
	INNER JOIN [dbo].[tblUsers_User] User1 ON User1.[UserID]=UserRoleUser1.[UserID]
	WHERE 
		UserRoleUser1.[UserRoleCode] = @UserRoleCode

	ORDER BY NewID()
END
ELSE
BEGIN
	SELECT
		  UserRoleUser1.[UserRoleCode]
		, UserRoleUser1.[UserID]
		, UserRoleUser1.[CreatedByUserID]
		, UserRoleUser1.[CreatedDate]
		, UserRoleUser1.[LastModifiedByUserID]
		, UserRoleUser1.[LastModifiedDate]
		, UserRoleUser1.[Timestamp]
		, UserRole1.[UserRoleName]
		, User1.[UserName]
		, User1.[FirstName]
		, User1.[LastName]
	FROM
	      [dbo].[trelUsers_UserRoleUser] UserRoleUser1
	INNER JOIN [dbo].[tlkpUsers_UserRole] UserRole1 ON UserRole1.[UserRoleCode]=UserRoleUser1.[UserRoleCode]
	INNER JOIN [dbo].[tblUsers_User] User1 ON User1.[UserID]=UserRoleUser1.[UserID]
	WHERE 
		UserRoleUser1.[UserRoleCode] = @UserRoleCode

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'UserRoleCode' THEN UserRoleUser1.[UserRoleCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'UserRoleCode' THEN UserRoleUser1.[UserRoleCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'UserID' THEN UserRoleUser1.[UserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'UserID' THEN UserRoleUser1.[UserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN UserRoleUser1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN UserRoleUser1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN UserRoleUser1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN UserRoleUser1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN UserRoleUser1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN UserRoleUser1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN UserRoleUser1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN UserRoleUser1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN UserRoleUser1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN UserRoleUser1.[Timestamp] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'UserRoleName' THEN UserRole1.[UserRoleName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'UserRoleName' THEN UserRole1.[UserRoleName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'UserName' THEN User1.[UserName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'UserName' THEN User1.[UserName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'FirstName' THEN User1.[FirstName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'FirstName' THEN User1.[FirstName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastName' THEN User1.[LastName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastName' THEN User1.[LastName] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END


RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spUsers_GetManyUserDataByCriteria
	  @SqlErrorNumber int = 0 OUTPUT
	, @StartIndex int = 1
	, @PageSize int = 50
	, @MaximumListSize int = 0
	, @MaximumListSizeExceeded bit = 0 OUTPUT
	, @TotalRecords int = 0 OUTPUT
	, @SortColumn sysname = 'UserName'
	, @SortDirection nvarchar(20) = 'Ascending'
	, @IncludeInactive bit = 0
	, @UserName nvarchar(50) = NULL
	, @FirstName nvarchar(100) = NULL
	, @LastName nvarchar(100) = NULL
	, @LastModifiedDateStart datetime = getdate
	, @LastModifiedDateEnd datetime = getdate
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets many User data by criteria.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

DECLARE @vEndIndex int
IF (@StartIndex < 1) SET @StartIndex=1
IF (@PageSize < 1) SET @PageSize=1
SET @vEndIndex = @StartIndex + @Pagesize
IF (@SortColumn = '') SET @SortColumn='UserName'

/*
** perform main procedure tasks
*/
DECLARE @SearchCondition varchar(2048)

DECLARE @OrderedRecords TABLE
(
     SearchOrderID int IDENTITY (1, 1) NOT NULL
    , UserID uniqueidentifier
)
IF (@SortDirection = 'Random')
BEGIN
	INSERT INTO @OrderedRecords (UserID)
	SELECT
		  User1.[UserID]
	FROM
	      [dbo].[tblUsers_User] User1
	WHERE 
		User1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN User1.[IsActive] ELSE 1 END
		AND (@UserName IS NULL OR User1.[UserName] like '%' + @UserName + '%')
		AND (@FirstName IS NULL OR User1.[FirstName] like '%' + @FirstName + '%')
		AND (@LastName IS NULL OR User1.[LastName] like '%' + @LastName + '%')
		AND ((@LastModifiedDateStart  IS NULL) OR (User1.[LastModifiedDate] >=  @LastModifiedDateStart))
		AND ((@LastModifiedDateEnd  IS NULL) OR (User1.[LastModifiedDate] <=  @LastModifiedDateEnd))

	ORDER BY NewID()
END
ELSE
BEGIN
	INSERT INTO @OrderedRecords (UserID)
	SELECT
		  User1.[UserID]
	FROM
	      [dbo].[tblUsers_User] User1
	WHERE 
		User1.[IsActive] = CASE WHEN @IncludeInactive=1 THEN User1.[IsActive] ELSE 1 END
		AND (@UserName IS NULL OR User1.[UserName] like '%' + @UserName + '%')
		AND (@FirstName IS NULL OR User1.[FirstName] like '%' + @FirstName + '%')
		AND (@LastName IS NULL OR User1.[LastName] like '%' + @LastName + '%')
		AND ((@LastModifiedDateStart  IS NULL) OR (User1.[LastModifiedDate] >=  @LastModifiedDateStart))
		AND ((@LastModifiedDateEnd  IS NULL) OR (User1.[LastModifiedDate] <=  @LastModifiedDateEnd))

	ORDER BY
		 CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'UserID' THEN User1.[UserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'UserID' THEN User1.[UserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'UserName' THEN User1.[UserName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'UserName' THEN User1.[UserName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'FirstName' THEN User1.[FirstName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'FirstName' THEN User1.[FirstName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastName' THEN User1.[LastName] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastName' THEN User1.[LastName] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Password' THEN User1.[Password] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Password' THEN User1.[Password] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LocaleCode' THEN User1.[LocaleCode] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LocaleCode' THEN User1.[LocaleCode] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'IsActive' THEN User1.[IsActive] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'IsActive' THEN User1.[IsActive] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedByUserID' THEN User1.[CreatedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedByUserID' THEN User1.[CreatedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'CreatedDate' THEN User1.[CreatedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'CreatedDate' THEN User1.[CreatedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedByUserID' THEN User1.[LastModifiedByUserID] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedByUserID' THEN User1.[LastModifiedByUserID] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'LastModifiedDate' THEN User1.[LastModifiedDate] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'LastModifiedDate' THEN User1.[LastModifiedDate] END DESC
		,CASE WHEN @SortDirection = 'Ascending' AND @SortColumn = 'Timestamp' THEN User1.[Timestamp] END
		,CASE WHEN @SortDirection = 'Descending' AND @SortColumn = 'Timestamp' THEN User1.[Timestamp] END DESC
END

SET @SqlErrorNumber = @@ERROR
IF (@SqlErrorNumber <> 0)
BEGIN
    GOTO EXIT_ERROR
END

BEGIN
	SET @TotalRecords = (SELECT Count (*) FROM @OrderedRecords)
	IF @MaximumListSize > 0
	BEGIN
		IF @TotalRecords > @MaximumListSize
		BEGIN
			SET @MaximumListSizeExceeded = 1
			SET @TotalRecords = @MaximumListSize
		END
	END

	/* get search results */
	SELECT
		  User1.[UserID]
		, User1.[UserName]
		, User1.[FirstName]
		, User1.[LastName]
		, User1.[Password]
		, User1.[LocaleCode]
		, User1.[IsActive]
		, User1.[CreatedByUserID]
		, User1.[CreatedDate]
		, User1.[LastModifiedByUserID]
		, User1.[LastModifiedDate]
		, User1.[Timestamp]
	FROM
	      [dbo].[tblUsers_User] User1
	INNER JOIN @OrderedRecords search ON search.[UserID] = User1.[UserID]
	WHERE
		search.SearchOrderID  >= @StartIndex AND
		search.SearchOrderID  < @vEndIndex
	ORDER BY
		search.SearchOrderID

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spUsers_GetOneAccessMode
	  @SqlErrorNumber int = 0 OUTPUT
	, @AccessModeCode int
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets a single AccessMode by an index.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@AccessModeCode IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	SELECT
		  AccessMode1.[AccessModeCode]
		, AccessMode1.[AccessModeName]
		, AccessMode1.[Description]
		, AccessMode1.[IsActive]
		, AccessMode1.[CreatedByUserID]
		, AccessMode1.[CreatedDate]
		, AccessMode1.[LastModifiedByUserID]
		, AccessMode1.[LastModifiedDate]
		, AccessMode1.[Timestamp]
	FROM
	      [dbo].[tlkpUsers_AccessMode] AccessMode1
	WHERE AccessMode1.[AccessModeCode] =  @AccessModeCode

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spUsers_GetOneActivity
	  @SqlErrorNumber int = 0 OUTPUT
	, @ActivityCode int
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets a single Activity by an index.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@ActivityCode IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	SELECT
		  Activity1.[ActivityCode]
		, Activity1.[ActivityName]
		, Activity1.[Description]
		, Activity1.[IsActive]
		, Activity1.[CreatedByUserID]
		, Activity1.[CreatedDate]
		, Activity1.[LastModifiedByUserID]
		, Activity1.[LastModifiedDate]
		, Activity1.[Timestamp]
	FROM
	      [dbo].[tlkpUsers_Activity] Activity1
	WHERE Activity1.[ActivityCode] =  @ActivityCode

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spUsers_GetOneActivityByActivityName
	  @SqlErrorNumber int = 0 OUTPUT
	, @ActivityName nvarchar(255)
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets a single Activity by an index.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@ActivityName IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	SELECT
		  Activity1.[ActivityCode]
		, Activity1.[ActivityName]
		, Activity1.[Description]
		, Activity1.[IsActive]
		, Activity1.[CreatedByUserID]
		, Activity1.[CreatedDate]
		, Activity1.[LastModifiedByUserID]
		, Activity1.[LastModifiedDate]
		, Activity1.[Timestamp]
	FROM
	      [dbo].[tlkpUsers_Activity] Activity1
	WHERE Activity1.[ActivityName] =  @ActivityName

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spUsers_GetOneUser
	  @SqlErrorNumber int = 0 OUTPUT
	, @UserID uniqueidentifier
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets a single User by an index.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@UserID IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	SELECT
		  User1.[UserID]
		, User1.[UserName]
		, User1.[FirstName]
		, User1.[LastName]
		, User1.[Password]
		, User1.[LocaleCode]
		, User1.[IsActive]
		, User1.[CreatedByUserID]
		, User1.[CreatedDate]
		, User1.[LastModifiedByUserID]
		, User1.[LastModifiedDate]
		, User1.[Timestamp]
	FROM
	      [dbo].[tblUsers_User] User1
	WHERE User1.[UserID] =  @UserID

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spUsers_GetOneUserByFirstNameAndLastNameAndPassword
	  @SqlErrorNumber int = 0 OUTPUT
	, @FirstName nvarchar(100) = NULL
	, @LastName nvarchar(100) = NULL
	, @Password nvarchar(100) = NULL
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets a single User by an index.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@FirstName IS NULL OR @LastName IS NULL OR @Password IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	SELECT
		  User1.[UserID]
		, User1.[UserName]
		, User1.[FirstName]
		, User1.[LastName]
		, User1.[Password]
		, User1.[LocaleCode]
		, User1.[IsActive]
		, User1.[CreatedByUserID]
		, User1.[CreatedDate]
		, User1.[LastModifiedByUserID]
		, User1.[LastModifiedDate]
		, User1.[Timestamp]
	FROM
	      [dbo].[tblUsers_User] User1
	WHERE User1.[FirstName] =  @FirstName AND User1.[LastName] =  @LastName AND User1.[Password] =  @Password

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spUsers_GetOneUserByUserName
	  @SqlErrorNumber int = 0 OUTPUT
	, @UserName nvarchar(50) = NULL
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets a single User by an index.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@UserName IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	SELECT
		  User1.[UserID]
		, User1.[UserName]
		, User1.[FirstName]
		, User1.[LastName]
		, User1.[Password]
		, User1.[LocaleCode]
		, User1.[IsActive]
		, User1.[CreatedByUserID]
		, User1.[CreatedDate]
		, User1.[LastModifiedByUserID]
		, User1.[LastModifiedDate]
		, User1.[Timestamp]
	FROM
	      [dbo].[tblUsers_User] User1
	WHERE User1.[UserName] =  @UserName

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spUsers_GetOneUserRole
	  @SqlErrorNumber int = 0 OUTPUT
	, @UserRoleCode int
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets a single UserRole by an index.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@UserRoleCode IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	SELECT
		  UserRole1.[UserRoleCode]
		, UserRole1.[UserRoleName]
		, UserRole1.[Description]
		, UserRole1.[IsActive]
		, UserRole1.[CreatedByUserID]
		, UserRole1.[CreatedDate]
		, UserRole1.[LastModifiedByUserID]
		, UserRole1.[LastModifiedDate]
		, UserRole1.[Timestamp]
	FROM
	      [dbo].[tlkpUsers_UserRole] UserRole1
	WHERE UserRole1.[UserRoleCode] =  @UserRoleCode

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spUsers_GetOneUserRoleActivity
	  @SqlErrorNumber int = 0 OUTPUT
	, @UserRoleCode int
	, @ActivityCode int
	, @AccessModeCode int
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets a single UserRoleActivity by an index.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@UserRoleCode IS NULL OR @ActivityCode IS NULL OR @AccessModeCode IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	SELECT
		  UserRoleActivity1.[UserRoleCode]
		, UserRoleActivity1.[ActivityCode]
		, UserRoleActivity1.[AccessModeCode]
		, UserRoleActivity1.[CreatedByUserID]
		, UserRoleActivity1.[CreatedDate]
		, UserRoleActivity1.[LastModifiedByUserID]
		, UserRoleActivity1.[LastModifiedDate]
		, UserRoleActivity1.[Timestamp]
		, UserRole1.[UserRoleName]
		, Activity1.[ActivityName]
		, AccessMode1.[AccessModeName]
	FROM
	      [dbo].[trelUsers_UserRoleActivity] UserRoleActivity1
	INNER JOIN [dbo].[tlkpUsers_UserRole] UserRole1 ON UserRole1.[UserRoleCode]=UserRoleActivity1.[UserRoleCode]
	INNER JOIN [dbo].[tlkpUsers_Activity] Activity1 ON Activity1.[ActivityCode]=UserRoleActivity1.[ActivityCode]
	INNER JOIN [dbo].[tlkpUsers_AccessMode] AccessMode1 ON AccessMode1.[AccessModeCode]=UserRoleActivity1.[AccessModeCode]
	WHERE UserRoleActivity1.[UserRoleCode] =  @UserRoleCode AND UserRoleActivity1.[ActivityCode] =  @ActivityCode AND UserRoleActivity1.[AccessModeCode] =  @AccessModeCode

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spUsers_GetOneUserRoleUser
	  @SqlErrorNumber int = 0 OUTPUT
	, @UserRoleCode int
	, @UserID uniqueidentifier
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure gets a single UserRoleUser by an index.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@UserRoleCode IS NULL OR @UserID IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END

/*
** perform main procedure tasks
*/
BEGIN
	SELECT
		  UserRoleUser1.[UserRoleCode]
		, UserRoleUser1.[UserID]
		, UserRoleUser1.[CreatedByUserID]
		, UserRoleUser1.[CreatedDate]
		, UserRoleUser1.[LastModifiedByUserID]
		, UserRoleUser1.[LastModifiedDate]
		, UserRoleUser1.[Timestamp]
		, UserRole1.[UserRoleName]
		, User1.[UserName]
		, User1.[FirstName]
		, User1.[LastName]
	FROM
	      [dbo].[trelUsers_UserRoleUser] UserRoleUser1
	INNER JOIN [dbo].[tlkpUsers_UserRole] UserRole1 ON UserRole1.[UserRoleCode]=UserRoleUser1.[UserRoleCode]
	INNER JOIN [dbo].[tblUsers_User] User1 ON User1.[UserID]=UserRoleUser1.[UserID]
	WHERE UserRoleUser1.[UserRoleCode] =  @UserRoleCode AND UserRoleUser1.[UserID] =  @UserID

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spUsers_UpdateOneAccessMode
	  @SqlErrorNumber int = 0 OUTPUT
	, @LastModifiedByUserID uniqueidentifier = NULL
	, @Timestamp timestamp = NULL OUTPUT
	, @CheckTimestamp bit = 0
	, @AccessModeCode int
	, @AccessModeName nvarchar(255)
	, @Description nvarchar(2000) = NULL
	, @IsActive bit = 0
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure updates AccessMode data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@AccessModeCode IS NULL OR @AccessModeName IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END
/*
** record validation
*/
IF NOT EXISTS (SELECT [AccessModeCode] FROM [dbo].[tlkpUsers_AccessMode] WHERE [AccessModeCode] =  @AccessModeCode)
BEGIN
	SET @SqlErrorNumber = -1003
	GOTO EXIT_ERROR
END
/*
** timestamp validation
*/
IF (@CheckTimestamp = 1)
BEGIN
	IF EXISTS (SELECT [AccessModeCode] FROM [dbo].[tlkpUsers_AccessMode] WHERE [AccessModeCode] =  @AccessModeCode AND [Timestamp] <> @Timestamp)
	BEGIN
		SET @SqlErrorNumber = -1002
		GOTO EXIT_ERROR
	END
END

/*
** perform main procedure tasks
*/
BEGIN
	UPDATE
	      [dbo].[tlkpUsers_AccessMode]
	SET
	     [LastModifiedByUserID] = @LastModifiedByUserID
	   , [LastModifiedDate] = getdate()
	   , [AccessModeCode] = @AccessModeCode
	   , [AccessModeName] = @AccessModeName
	   , [Description] = @Description
	   , [IsActive] = @IsActive
	WHERE [AccessModeCode] =  @AccessModeCode

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

	SET  @Timestamp = @@DBTS

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spUsers_UpdateOneActivity
	  @SqlErrorNumber int = 0 OUTPUT
	, @LastModifiedByUserID uniqueidentifier = NULL
	, @Timestamp timestamp = NULL OUTPUT
	, @CheckTimestamp bit = 0
	, @ActivityCode int
	, @ActivityName nvarchar(255)
	, @Description nvarchar(2000) = NULL
	, @IsActive bit = 0
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure updates Activity data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@ActivityCode IS NULL OR @ActivityName IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END
/*
** record validation
*/
IF NOT EXISTS (SELECT [ActivityCode] FROM [dbo].[tlkpUsers_Activity] WHERE [ActivityCode] =  @ActivityCode)
BEGIN
	SET @SqlErrorNumber = -1003
	GOTO EXIT_ERROR
END
/*
** timestamp validation
*/
IF (@CheckTimestamp = 1)
BEGIN
	IF EXISTS (SELECT [ActivityCode] FROM [dbo].[tlkpUsers_Activity] WHERE [ActivityCode] =  @ActivityCode AND [Timestamp] <> @Timestamp)
	BEGIN
		SET @SqlErrorNumber = -1002
		GOTO EXIT_ERROR
	END
END

/*
** perform main procedure tasks
*/
BEGIN
	UPDATE
	      [dbo].[tlkpUsers_Activity]
	SET
	     [LastModifiedByUserID] = @LastModifiedByUserID
	   , [LastModifiedDate] = getdate()
	   , [ActivityCode] = @ActivityCode
	   , [ActivityName] = @ActivityName
	   , [Description] = @Description
	   , [IsActive] = @IsActive
	WHERE [ActivityCode] =  @ActivityCode

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

	SET  @Timestamp = @@DBTS

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spUsers_UpdateOneUserRole
	  @SqlErrorNumber int = 0 OUTPUT
	, @LastModifiedByUserID uniqueidentifier = NULL
	, @Timestamp timestamp = NULL OUTPUT
	, @CheckTimestamp bit = 0
	, @UserRoleCode int
	, @UserRoleName nvarchar(255)
	, @Description nvarchar(2000) = NULL
	, @IsActive bit = 0
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure updates UserRole data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@UserRoleCode IS NULL OR @UserRoleName IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END
/*
** record validation
*/
IF NOT EXISTS (SELECT [UserRoleCode] FROM [dbo].[tlkpUsers_UserRole] WHERE [UserRoleCode] =  @UserRoleCode)
BEGIN
	SET @SqlErrorNumber = -1003
	GOTO EXIT_ERROR
END
/*
** timestamp validation
*/
IF (@CheckTimestamp = 1)
BEGIN
	IF EXISTS (SELECT [UserRoleCode] FROM [dbo].[tlkpUsers_UserRole] WHERE [UserRoleCode] =  @UserRoleCode AND [Timestamp] <> @Timestamp)
	BEGIN
		SET @SqlErrorNumber = -1002
		GOTO EXIT_ERROR
	END
END

/*
** perform main procedure tasks
*/
BEGIN
	UPDATE
	      [dbo].[tlkpUsers_UserRole]
	SET
	     [LastModifiedByUserID] = @LastModifiedByUserID
	   , [LastModifiedDate] = getdate()
	   , [UserRoleCode] = @UserRoleCode
	   , [UserRoleName] = @UserRoleName
	   , [Description] = @Description
	   , [IsActive] = @IsActive
	WHERE [UserRoleCode] =  @UserRoleCode

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

	SET  @Timestamp = @@DBTS

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spUsers_UpdateOneUserRoleActivity
	  @SqlErrorNumber int = 0 OUTPUT
	, @LastModifiedByUserID uniqueidentifier = NULL
	, @Timestamp timestamp = NULL OUTPUT
	, @CheckTimestamp bit = 0
	, @UserRoleCode int
	, @ActivityCode int
	, @AccessModeCode int
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure updates UserRoleActivity data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@UserRoleCode IS NULL OR @ActivityCode IS NULL OR @AccessModeCode IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END
/*
** record validation
*/
IF NOT EXISTS (SELECT [UserRoleCode], [ActivityCode], [AccessModeCode] FROM [dbo].[trelUsers_UserRoleActivity] WHERE [UserRoleCode] =  @UserRoleCode AND [ActivityCode] =  @ActivityCode AND [AccessModeCode] =  @AccessModeCode)
BEGIN
	SET @SqlErrorNumber = -1003
	GOTO EXIT_ERROR
END
/*
** timestamp validation
*/
IF (@CheckTimestamp = 1)
BEGIN
	IF EXISTS (SELECT [UserRoleCode], [ActivityCode], [AccessModeCode] FROM [dbo].[trelUsers_UserRoleActivity] WHERE [UserRoleCode] =  @UserRoleCode AND [ActivityCode] =  @ActivityCode AND [AccessModeCode] =  @AccessModeCode AND [Timestamp] <> @Timestamp)
	BEGIN
		SET @SqlErrorNumber = -1002
		GOTO EXIT_ERROR
	END
END

/*
** perform main procedure tasks
*/
BEGIN
	UPDATE
	      [dbo].[trelUsers_UserRoleActivity]
	SET
	     [LastModifiedByUserID] = @LastModifiedByUserID
	   , [LastModifiedDate] = getdate()
	   , [UserRoleCode] = @UserRoleCode
	   , [ActivityCode] = @ActivityCode
	   , [AccessModeCode] = @AccessModeCode
	WHERE [UserRoleCode] =  @UserRoleCode AND [ActivityCode] =  @ActivityCode AND [AccessModeCode] =  @AccessModeCode

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

	SET  @Timestamp = @@DBTS

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spUsers_UpdateOneUserRoleUser
	  @SqlErrorNumber int = 0 OUTPUT
	, @LastModifiedByUserID uniqueidentifier = NULL
	, @Timestamp timestamp = NULL OUTPUT
	, @CheckTimestamp bit = 0
	, @UserRoleCode int
	, @UserID uniqueidentifier
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure updates UserRoleUser data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0

/*
** parameter validation
*/
IF (@UserRoleCode IS NULL OR @UserID IS NULL)
BEGIN
    SET @SqlErrorNumber = -1001
    GOTO EXIT_ERROR
END
/*
** record validation
*/
IF NOT EXISTS (SELECT [UserRoleCode], [UserID] FROM [dbo].[trelUsers_UserRoleUser] WHERE [UserRoleCode] =  @UserRoleCode AND [UserID] =  @UserID)
BEGIN
	SET @SqlErrorNumber = -1003
	GOTO EXIT_ERROR
END
/*
** timestamp validation
*/
IF (@CheckTimestamp = 1)
BEGIN
	IF EXISTS (SELECT [UserRoleCode], [UserID] FROM [dbo].[trelUsers_UserRoleUser] WHERE [UserRoleCode] =  @UserRoleCode AND [UserID] =  @UserID AND [Timestamp] <> @Timestamp)
	BEGIN
		SET @SqlErrorNumber = -1002
		GOTO EXIT_ERROR
	END
END

/*
** perform main procedure tasks
*/
BEGIN
	UPDATE
	      [dbo].[trelUsers_UserRoleUser]
	SET
	     [LastModifiedByUserID] = @LastModifiedByUserID
	   , [LastModifiedDate] = getdate()
	   , [UserRoleCode] = @UserRoleCode
	   , [UserID] = @UserID
	WHERE [UserRoleCode] =  @UserRoleCode AND [UserID] =  @UserID

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

	SET  @Timestamp = @@DBTS

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.spUsers_UpsertOneUser
	  @SqlErrorNumber int = 0 OUTPUT
	, @CreatedByUserID uniqueidentifier = NULL
	, @LastModifiedByUserID uniqueidentifier = NULL
	, @Timestamp timestamp = NULL OUTPUT
	, @CheckTimestamp bit = 0
	, @UserID uniqueidentifier = NULL OUTPUT
	, @UserName nvarchar(50) = NULL
	, @FirstName nvarchar(100) = NULL
	, @LastName nvarchar(100) = NULL
	, @Password nvarchar(100) = NULL
	, @LocaleCode int = NULL
	, @IsActive bit = 0
AS
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

/* ------------------------------------------------------------------------------
** Stored Procedure Description: 
** This procedure inserts or updates User data.
**
** Stored Procedure History:
**	10/24/2006 <created> (Dave Clemmer)
**	10/24/2006 <notmodified> (Dave Clemmer)
**	(delete "not" from the "notmodified" tag to prevent this procedure from being regenerated)
** ------------------------------------------------------------------------------
*/
 SET NOCOUNT ON
/*
** declarations
*/
SET @SqlErrorNumber = 0
/*
** timestamp validation
*/
IF (@CheckTimestamp = 1)
BEGIN
	IF EXISTS (SELECT [UserID] FROM [dbo].[tblUsers_User] WHERE [UserID] =  @UserID AND [Timestamp] <> @Timestamp)
	BEGIN
		SET @SqlErrorNumber = -1002
		GOTO EXIT_ERROR
	END
END

/*
** perform main procedure tasks
*/
IF NOT EXISTS (SELECT [UserID] FROM [dbo].[tblUsers_User] WHERE [UserID] =  @UserID)
BEGIN
	IF @UserID  IS NULL
	BEGIN
		SET @UserID  = NEWID ()
	END
	INSERT
	      [dbo].[tblUsers_User]
	      (
 	     [CreatedByUserID]
 	   , [LastModifiedByUserID]
	   , [UserID]
	   , [UserName]
	   , [FirstName]
	   , [LastName]
	   , [Password]
	   , [LocaleCode]
	   , [IsActive]
	      )

	VALUES 
	      (
 	     @CreatedByUserID
 	   , @CreatedByUserID
	   , @UserID
	   , @UserName
	   , @FirstName
	   , @LastName
	   , @Password
	   , @LocaleCode
	   , @IsActive
	      )

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END


	SET  @Timestamp = @@DBTS
	END
ELSE
BEGIN
	UPDATE
	      [dbo].[tblUsers_User]
	SET
	     [LastModifiedByUserID] = @LastModifiedByUserID
	   , [LastModifiedDate] = getdate()
	   , [UserID] = @UserID
	   , [UserName] = @UserName
	   , [FirstName] = @FirstName
	   , [LastName] = @LastName
	   , [Password] = @Password
	   , [LocaleCode] = @LocaleCode
	   , [IsActive] = @IsActive
	WHERE [UserID] =  @UserID

	SET @SqlErrorNumber = @@ERROR
	IF (@SqlErrorNumber <> 0)
	BEGIN
	    GOTO EXIT_ERROR
	END

	SET  @Timestamp = @@DBTS

END

RETURN 0

EXIT_ERROR:

RETURN -1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

