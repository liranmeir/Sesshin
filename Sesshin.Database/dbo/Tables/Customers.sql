CREATE TABLE [dbo].[Customers] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]       NVARCHAR (50)  NOT NULL,
    [LastName]        NVARCHAR (50)  NULL,
    [Phone]           NVARCHAR (MAX) NULL,
    [Email]           NVARCHAR (MAX) NULL,
    [Address_City]    NVARCHAR (MAX) NULL,
    [Address_Street]  NVARCHAR (MAX) NULL,
    [Address_Number]  NVARCHAR (MAX) NULL,
    [Address_Remarks] NVARCHAR (MAX) NULL,
    [Address_CityId]  INT            DEFAULT ((0)) NULL,
    [IsAcceptEmail]   BIT            DEFAULT ((0)) NOT NULL,
    [LeadSource]      INT            DEFAULT ((0)) NOT NULL,
    [CreationDate]    DATETIME       DEFAULT ('1900-01-01T00:00:00.000') NULL,
    [Birthday]        DATETIME       DEFAULT ('1900-01-01T00:00:00.000') NULL,
    [Aniversery]      DATETIME       DEFAULT ('1900-01-01T00:00:00.000') NULL,
    CONSTRAINT [PK_dbo.Customers] PRIMARY KEY CLUSTERED ([Id] ASC)
);





