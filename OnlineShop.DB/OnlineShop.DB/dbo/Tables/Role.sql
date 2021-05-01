CREATE TABLE [dbo].[Role] (
    [RoleId] INT           IDENTITY (1, 1) NOT NULL,
    [Name]   NVARCHAR (20) NOT NULL,
    CONSTRAINT [Pk_Role_RoleId] PRIMARY KEY CLUSTERED ([RoleId] ASC)
);

