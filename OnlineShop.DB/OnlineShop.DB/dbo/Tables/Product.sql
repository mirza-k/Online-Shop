CREATE TABLE [dbo].[Product] (
    [ProductId]        UNIQUEIDENTIFIER NOT NULL,
    [Name]             NVARCHAR (50)    NOT NULL,
    [Description]      TEXT             NULL,
    [ItemPrice]        DECIMAL (18)     NOT NULL,
    [ImageUrl]         NVARCHAR (50)    NOT NULL,
    [StockQuantity]    INT              NOT NULL,
    [SoldQuantity]     INT              NOT NULL,
    [DatePublished]    DATETIME2 (7)    NOT NULL,
    [ShippingPrice]    INT              NOT NULL,
    [BrandId]          INT              NOT NULL,
    [GenderCategoryId] INT              NOT NULL,
    [IsVisible]        BIT              NOT NULL,
    [SubCategoryId]    INT              NOT NULL,
    [IsEditing]        BIT              NOT NULL,
    [ColorId]          INT              NOT NULL,
    CONSTRAINT [Pk_Product_ProductId] PRIMARY KEY CLUSTERED ([ProductId] ASC),
    CONSTRAINT [Fk_Brand_Product_BrandId] FOREIGN KEY ([BrandId]) REFERENCES [dbo].[Brand] ([BrandId]),
    CONSTRAINT [Fk_Color_Product_ColorId] FOREIGN KEY ([ColorId]) REFERENCES [dbo].[Color] ([ColorId]),
    CONSTRAINT [Fk_GenderCategory_Product_GenderCategoryId] FOREIGN KEY ([GenderCategoryId]) REFERENCES [dbo].[GenderCategory] ([GenderCategoryId]),
    CONSTRAINT [Fk_SubCategory_Product_SubCategoryId] FOREIGN KEY ([SubCategoryId]) REFERENCES [dbo].[SubCategory] ([SubCategoryId])
);

