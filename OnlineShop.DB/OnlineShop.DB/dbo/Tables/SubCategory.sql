CREATE TABLE [dbo].[SubCategory] (
    [SubCategoryId] INT           IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (25) NOT NULL,
    [CategoryId]    INT           NOT NULL,
    CONSTRAINT [Pk_SubCategory_SubCategoryId] PRIMARY KEY CLUSTERED ([SubCategoryId] ASC),
    CONSTRAINT [Fk_Category_SubCategory_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category] ([CategoryId])
);

