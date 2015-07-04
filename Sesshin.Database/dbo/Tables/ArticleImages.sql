CREATE TABLE [dbo].[ArticleImages] (
    [ArticleId]         INT NOT NULL,
    [BackgroundImageId] INT NOT NULL,
    CONSTRAINT [PK_dbo.ArticleImages] PRIMARY KEY CLUSTERED ([ArticleId] ASC, [BackgroundImageId] ASC),
    CONSTRAINT [FK_dbo.ArticleImages_dbo.Articles_ArticleId] FOREIGN KEY ([ArticleId]) REFERENCES [dbo].[Articles] ([ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.ArticleImages_dbo.BackgroundImages_BackgroundImageId] FOREIGN KEY ([BackgroundImageId]) REFERENCES [dbo].[BackgroundImages] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_ArticleId]
    ON [dbo].[ArticleImages]([ArticleId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_BackgroundImageId]
    ON [dbo].[ArticleImages]([BackgroundImageId] ASC);

