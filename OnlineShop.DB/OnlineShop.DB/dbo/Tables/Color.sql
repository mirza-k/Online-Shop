CREATE TABLE [dbo].[Color] (
    [ColorId] INT           IDENTITY (1, 1) NOT NULL,
    [Name]    NVARCHAR (20) NOT NULL,
    CONSTRAINT [Pk_Color_ColorId] PRIMARY KEY CLUSTERED ([ColorId] ASC)
);

