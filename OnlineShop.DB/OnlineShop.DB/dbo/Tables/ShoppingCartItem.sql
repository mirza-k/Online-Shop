CREATE TABLE [dbo].[ShoppingCartItem] (
    [Quantity]           INT              NOT NULL,
    [ProductPrice]       DECIMAL (18, 2)  NOT NULL,
    [AddedInCartDate]    DATETIME2 (7)    NOT NULL,
    [TotalPrice]         DECIMAL (18, 2)  NOT NULL,
    [ShoppingCartItemId] INT              IDENTITY (1, 1) NOT NULL,
    [ProductId]          UNIQUEIDENTIFIER NOT NULL,
    [UserId]             UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [Pk_ShoppingCartItem_ShoppingCartItemId] PRIMARY KEY CLUSTERED ([ShoppingCartItemId] ASC),
    CONSTRAINT [Fk_Product_ShoppingCartItem_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([ProductId]),
    CONSTRAINT [Fk_User_ShoppingCartItem_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId])
);

