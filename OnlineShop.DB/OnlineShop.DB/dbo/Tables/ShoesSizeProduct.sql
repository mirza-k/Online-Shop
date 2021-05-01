CREATE TABLE [dbo].[ShoesSizeProduct] (
    [ShoesSizeId]        INT              NOT NULL,
    [ProductId]          UNIQUEIDENTIFIER NOT NULL,
    [Quantiy]            INT              NOT NULL,
    [ShoesSizeProductId] INT              IDENTITY (1, 1) NOT NULL,
    CONSTRAINT [Pk_ShoesSizeProduct_ShoesSizeProductId] PRIMARY KEY CLUSTERED ([ShoesSizeProductId] ASC),
    CONSTRAINT [Fk_Product_ShoesSizeProduct_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([ProductId]),
    CONSTRAINT [Fk_ShoesSize_ShoesSizeProduct_ShoesSizeId] FOREIGN KEY ([ShoesSizeId]) REFERENCES [dbo].[ShoesSize] ([ShoesSizeId])
);

