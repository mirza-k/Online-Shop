CREATE TABLE [dbo].[ScriptExecutionHistory]
(
	[ScriptId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [ExecutionDate] DATETIME2 NOT NULL
)
