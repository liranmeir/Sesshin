CREATE TABLE [dbo].[Articles] (
    [ID]              INT            IDENTITY (1, 1) NOT NULL,
    [Name]            NVARCHAR (MAX) NOT NULL,
    [PageTitle]       NVARCHAR (MAX) NULL,
    [PageDescription] NVARCHAR (MAX) NULL,
    [PageKeywords]    NVARCHAR (MAX) NULL,
    [Headline]        NVARCHAR (MAX) NULL,
    [Content]         NVARCHAR (MAX) NULL,
    [DateCreated]     DATETIME       NOT NULL,
    [EnglishName]     NVARCHAR (MAX) DEFAULT ('') NOT NULL,
    CONSTRAINT [PK_dbo.Articles] PRIMARY KEY CLUSTERED ([ID] ASC)
);

