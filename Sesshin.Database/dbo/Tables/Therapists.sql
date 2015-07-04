CREATE TABLE [dbo].[Therapists] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [LastName]  NVARCHAR (50) NOT NULL,
    [FirstName] NVARCHAR (50) NOT NULL,
    [HireDate]  DATETIME      NOT NULL,
    CONSTRAINT [PK_dbo.Therapists] PRIMARY KEY CLUSTERED ([Id] ASC)
);

