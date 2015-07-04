CREATE TABLE [dbo].[Cities] (
    [Id]       INT           NOT NULL,
    [Name]     NVARCHAR (50) NULL,
    [RegionId] INT           NULL,
    CONSTRAINT [PK_dbo.Cities] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Cities_dbo.Regions_RegionId] FOREIGN KEY ([RegionId]) REFERENCES [dbo].[Regions] ([Id])
);




GO
CREATE NONCLUSTERED INDEX [IX_RegionId]
    ON [dbo].[Cities]([RegionId] ASC);

