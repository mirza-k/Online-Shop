CREATE TABLE [dbo].[Brand] (
    [BrandId] INT           IDENTITY (1, 1) NOT NULL,
    [Name]    NVARCHAR (20) NOT NULL,
    CONSTRAINT [Pk_Brand_BrandId] PRIMARY KEY CLUSTERED ([BrandId] ASC)
);

