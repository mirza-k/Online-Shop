CREATE TABLE [dbo].[UserAccount] (
    [UserAccountId] UNIQUEIDENTIFIER NOT NULL,
    [Email]         NVARCHAR (50)    NOT NULL,
    [Username]      NVARCHAR (30)    NOT NULL,
    [PasswordHash]  NVARCHAR (50)    NOT NULL,
    [PhoneNumber]   NVARCHAR (20)    NOT NULL,
    CONSTRAINT [Pk_UserAccount_UserAccountId] PRIMARY KEY CLUSTERED ([UserAccountId] ASC)
);

