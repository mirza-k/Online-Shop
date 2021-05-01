CREATE TABLE [dbo].[Order] (
    [OrderId]    INT              IDENTITY (1, 1) NOT NULL,
    [OrderDate]  DATETIME2 (7)    NOT NULL,
    [TotalPrice] DECIMAL (18, 2)  NOT NULL,
    [UserId]     UNIQUEIDENTIFIER NOT NULL,
    [ShippingId] INT              NOT NULL,
    CONSTRAINT [Pk_Order_OrderId] PRIMARY KEY CLUSTERED ([OrderId] ASC),
    CONSTRAINT [Fk_Shipping_Order_ShippingId] FOREIGN KEY ([ShippingId]) REFERENCES [dbo].[Shipping] ([ShippingId]),
    CONSTRAINT [Fk_User_Order_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId])
);

