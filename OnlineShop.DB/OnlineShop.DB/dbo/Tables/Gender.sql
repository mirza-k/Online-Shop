CREATE TABLE [dbo].[Gender] (
    [GenderId] INT           IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (20) NOT NULL,
    CONSTRAINT [Pk_Gender_GenderId] PRIMARY KEY CLUSTERED ([GenderId] ASC)
);

