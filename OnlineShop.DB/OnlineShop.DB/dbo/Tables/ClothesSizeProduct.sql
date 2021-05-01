CREATE TABLE [dbo].[ClothesSizeProduct] (
    [ClothesSizeId]        INT              NOT NULL,
    [ProductId]            UNIQUEIDENTIFIER NOT NULL,
    [Quantity]             INT              NOT NULL,
    [ClothesSizeProductId] INT              IDENTITY (1, 1) NOT NULL,
    CONSTRAINT [Pk_ClothesSizeProduct_ClothesSizeProductId] PRIMARY KEY CLUSTERED ([ClothesSizeProductId] ASC),
    CONSTRAINT [Fk_ClothesSize_ClothesSizeProduct_ClothesSizeId] FOREIGN KEY ([ClothesSizeId]) REFERENCES [dbo].[ClothesSize] ([ClothesSizeId]),
    CONSTRAINT [Fk_Product_ClothesSizeProduct_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([ProductId])
);

