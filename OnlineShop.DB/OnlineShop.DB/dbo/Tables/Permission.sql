CREATE TABLE [dbo].[Permission] (
    [PermissionId] INT           IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (50) NOT NULL,
    CONSTRAINT [Pk_Permission_PermissionId] PRIMARY KEY CLUSTERED ([PermissionId] ASC)
);

