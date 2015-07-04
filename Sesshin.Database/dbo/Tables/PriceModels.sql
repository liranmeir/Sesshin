CREATE TABLE [dbo].[PriceModels] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Title]       NVARCHAR (MAX) NULL,
    [SubTitle]    NVARCHAR (MAX) NULL,
    [Description] NVARCHAR (MAX) NULL,
    [Price]       FLOAT (53)     NOT NULL,
    [ProductId]   INT            NULL,
    [Duration]    NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.PriceModels] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.PriceModels_dbo.Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_ProductId]
    ON [dbo].[PriceModels]([ProductId] ASC);

