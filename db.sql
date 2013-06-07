/*
2012
(localdb)\v11.0
2010
.\SQLEXPRESS
*/

CREATE TABLE [dbo].[Category] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (255) NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Product] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (255) NOT NULL,
    [Stock]      INT            NOT NULL,
    [Available]  BIT            NOT NULL,
    [CategoryId] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Product_Category] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category] ([Id])
);
