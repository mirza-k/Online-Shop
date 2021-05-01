CREATE TABLE [dbo].[ShoesSize] (
    [ShoesSizeId] INT           IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (25) NOT NULL,
    CONSTRAINT [Pk_ShoesSize_ShoesSizeId] PRIMARY KEY CLUSTERED ([ShoesSizeId] ASC)
);

