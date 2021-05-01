CREATE TABLE [dbo].[Transaction] (
    [TransactionId]   INT              IDENTITY (1, 1) NOT NULL,
    [TotalPrice]      DECIMAL (18, 2)  NOT NULL,
    [TransactionDate] DATETIME2 (7)    NOT NULL,
    [UserId]          UNIQUEIDENTIFIER NOT NULL,
    [OrderId]         INT              NOT NULL,
    CONSTRAINT [Pk_Transaction_TransactionId] PRIMARY KEY CLUSTERED ([TransactionId] ASC),
    CONSTRAINT [Fk_Order_Transaction_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Order] ([OrderId]),
    CONSTRAINT [Fk_User_Transaction_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId])
);

