CREATE TABLE [dbo].[OrderProduct] (
    [ProductPrice]   DECIMAL (18, 2)  NOT NULL,
    [Quantity]       DECIMAL (18, 2)  NOT NULL,
    [OrderId]        INT              NOT NULL,
    [ProductId]      UNIQUEIDENTIFIER NOT NULL,
    [OrderProductId] INT              IDENTITY (1, 1) NOT NULL,
    CONSTRAINT [Pk_OrderProduct_OrderProductId] PRIMARY KEY CLUSTERED ([OrderProductId] ASC),
    CONSTRAINT [Fk_Order_OrderProduct_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Order] ([OrderId]),
    CONSTRAINT [Fk_Product_OrderProduct_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([ProductId])
);

