CREATE TABLE [dbo].[ClothesSize] (
    [ClothesSizeId] INT           IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (25) NOT NULL,
    CONSTRAINT [Pk_ClothesSize_ClothesSizeId] PRIMARY KEY CLUSTERED ([ClothesSizeId] ASC)
);

