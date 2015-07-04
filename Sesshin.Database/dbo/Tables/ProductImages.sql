CREATE TABLE [dbo].[ProductImages] (
    [ProductId]         INT NOT NULL,
    [BackgroundImageId] INT NOT NULL,
    CONSTRAINT [PK_dbo.ProductImages] PRIMARY KEY CLUSTERED ([ProductId] ASC, [BackgroundImageId] ASC),
    CONSTRAINT [FK_dbo.ProductImages_dbo.BackgroundImages_BackgroundImageId] FOREIGN KEY ([BackgroundImageId]) REFERENCES [dbo].[BackgroundImages] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.ProductImages_dbo.Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_ProductId]
    ON [dbo].[ProductImages]([ProductId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_BackgroundImageId]
    ON [dbo].[ProductImages]([BackgroundImageId] ASC);

