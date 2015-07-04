CREATE TABLE [dbo].[Redirects] (
    [RedirectId] INT            IDENTITY (1, 1) NOT NULL,
    [OldFile]    NVARCHAR (MAX) NULL,
    [NewPath]    NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Redirects] PRIMARY KEY CLUSTERED ([RedirectId] ASC)
);

