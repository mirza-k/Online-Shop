CREATE TABLE [dbo].[Shipping] (
    [ShippingId] INT             IDENTITY (1, 1) NOT NULL,
    [Price]      DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [Pk_Shipping_ShippingId] PRIMARY KEY CLUSTERED ([ShippingId] ASC)
);

