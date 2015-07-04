CREATE TABLE [dbo].[BackgroundImages] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.BackgroundImages] PRIMARY KEY CLUSTERED ([Id] ASC)
);

