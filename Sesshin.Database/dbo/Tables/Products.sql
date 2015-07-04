CREATE TABLE [dbo].[Products] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [Name]            NVARCHAR (MAX) NOT NULL,
    [Description]     NVARCHAR (MAX) NULL,
    [BackgroundFiles] NVARCHAR (MAX) NULL,
    [DateModified]    DATETIME       NOT NULL,
    [PageTitle]       NVARCHAR (MAX) NULL,
    [PageDescription] NVARCHAR (MAX) NULL,
    [PageKeywords]    NVARCHAR (MAX) NULL,
    [EnglishName]     NVARCHAR (MAX) DEFAULT ('') NOT NULL,
    CONSTRAINT [PK_dbo.Products] PRIMARY KEY CLUSTERED ([Id] ASC)
);

