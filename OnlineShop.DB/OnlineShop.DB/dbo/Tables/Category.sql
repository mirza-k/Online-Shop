CREATE TABLE [dbo].[Category] (
    [CategoryId] INT           IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (25) NOT NULL,
    CONSTRAINT [Pk_Category_CategoryId] PRIMARY KEY CLUSTERED ([CategoryId] ASC)
);

