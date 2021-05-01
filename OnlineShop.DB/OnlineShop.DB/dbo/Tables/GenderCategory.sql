CREATE TABLE [dbo].[GenderCategory] (
    [GenderCategoryId] INT           IDENTITY (1, 1) NOT NULL,
    [Name]             NVARCHAR (10) NOT NULL,
    CONSTRAINT [Pk_GenderCategory_GenderCategoryId] PRIMARY KEY CLUSTERED ([GenderCategoryId] ASC)
);

