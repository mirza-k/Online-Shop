CREATE TABLE [dbo].[RolePermission] (
    [RoleId]           INT NOT NULL,
    [PermissionId]     INT NOT NULL,
    [RolePermissionId] INT IDENTITY (1, 1) NOT NULL,
    CONSTRAINT [Pk_RolePermission_RolePermissionId] PRIMARY KEY CLUSTERED ([RolePermissionId] ASC),
    CONSTRAINT [Fk_Permission_RolePermission_PermissionId] FOREIGN KEY ([PermissionId]) REFERENCES [dbo].[Permission] ([PermissionId]),
    CONSTRAINT [Fk_Role_RolePermission_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([RoleId])
);

