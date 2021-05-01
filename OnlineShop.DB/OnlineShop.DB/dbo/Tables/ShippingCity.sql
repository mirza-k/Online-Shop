CREATE TABLE [dbo].[ShippingCity] (
    [ShippingCityId] INT IDENTITY (1, 1) NOT NULL,
    [CityId]         INT NOT NULL,
    [ShippingId]     INT NOT NULL,
    CONSTRAINT [Pk_ShippingCity_ShippingCityId] PRIMARY KEY CLUSTERED ([ShippingCityId] ASC),
    CONSTRAINT [Fk_City_ShippingCity_CityId] FOREIGN KEY ([CityId]) REFERENCES [dbo].[City] ([CityId]),
    CONSTRAINT [Fk_Shipping_ShippingCity_ShippingId] FOREIGN KEY ([ShippingId]) REFERENCES [dbo].[Shipping] ([ShippingId])
);

