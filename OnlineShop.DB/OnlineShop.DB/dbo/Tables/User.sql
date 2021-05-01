CREATE TABLE [dbo].[User] (
    [FirstName]     NVARCHAR (25)    NOT NULL,
    [DateBirth]     DATETIME2 (7)    NOT NULL,
    [LastName]      NVARCHAR (30)    NOT NULL,
    [UserAccountId] UNIQUEIDENTIFIER NOT NULL,
    [RoleId]        INT              NOT NULL,
    [UserId]        UNIQUEIDENTIFIER NOT NULL,
    [GenderId]      INT              NOT NULL,
    [CityId]        INT              NOT NULL,
    [Address]       NVARCHAR (30)    NOT NULL,
    CONSTRAINT [Pk_User_UserId] PRIMARY KEY CLUSTERED ([UserId] ASC),
    CONSTRAINT [Fk_City_User_CityId] FOREIGN KEY ([CityId]) REFERENCES [dbo].[City] ([CityId]),
    CONSTRAINT [Fk_Gender_User_GenderId] FOREIGN KEY ([GenderId]) REFERENCES [dbo].[Gender] ([GenderId]),
    CONSTRAINT [Fk_Role_User_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([RoleId]),
    CONSTRAINT [Fk_UserAccount_User_UserAccountId] FOREIGN KEY ([UserAccountId]) REFERENCES [dbo].[UserAccount] ([UserAccountId])
);

