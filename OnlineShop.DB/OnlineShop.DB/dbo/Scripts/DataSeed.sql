DECLARE @ScriptId UNIQUEIDENTIFIER = '9E04C557-4C20-4616-82FF-895624FB6790';
DECLARE @ExecutionDate DATETIME2(7) = NULL;

SELECT @ExecutionDate = ExecutionDate
FROM ScriptExecutionHistory
WHERE @ScriptId = ScriptId

IF @ExecutionDate IS NULL
BEGIN

INSERT INTO ScriptExecutionHistory(ScriptId,ExecutionDate)
VALUES (@ScriptId, GETUTCDATE())

INSERT INTO City(Name)
VALUES ('Kakanj'),('Sarajevo'),('Tuzla'),('Zenica'),('Travnik')

END


