CREATE TABLE [dbo].[Streets] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (MAX) NULL,
    [ParentCityId] INT            NULL,
    CONSTRAINT [PK_dbo.Streets] PRIMARY KEY CLUSTERED ([Id] ASC)
);

