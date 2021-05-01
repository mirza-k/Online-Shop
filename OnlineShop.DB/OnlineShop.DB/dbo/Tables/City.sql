CREATE TABLE [dbo].[City] (
    [CityId] INT           IDENTITY (1, 1) NOT NULL,
    [Name]   NVARCHAR (20) NOT NULL,
    CONSTRAINT [Pk_City_CityId] PRIMARY KEY CLUSTERED ([CityId] ASC)
);

