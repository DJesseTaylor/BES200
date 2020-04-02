create database library
go
use library
-- all the commands here to creat the tables and put the data and stuff in there.
IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Books] (
    [Id] int NOT NULL IDENTITY,
    [Title] nvarchar(200) NULL,
    [Author] nvarchar(200) NULL,
    [Genre] nvarchar(200) NULL,
    [NumberOfPages] int NOT NULL,
    [InInventory] bit NOT NULL,
    CONSTRAINT [PK_Books] PRIMARY KEY ([Id])
);

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Author', N'Genre', N'InInventory', N'NumberOfPages', N'Title') AND [object_id] = OBJECT_ID(N'[Books]'))
    SET IDENTITY_INSERT [Books] ON;
INSERT INTO [Books] ([Id], [Author], [Genre], [InInventory], [NumberOfPages], [Title])
VALUES (1, N'Thoreau', N'Philosophy', CAST(0 AS bit), 322, N'Walden');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Author', N'Genre', N'InInventory', N'NumberOfPages', N'Title') AND [object_id] = OBJECT_ID(N'[Books]'))
    SET IDENTITY_INSERT [Books] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Author', N'Genre', N'InInventory', N'NumberOfPages', N'Title') AND [object_id] = OBJECT_ID(N'[Books]'))
    SET IDENTITY_INSERT [Books] ON;
INSERT INTO [Books] ([Id], [Author], [Genre], [InInventory], [NumberOfPages], [Title])
VALUES (2, N'Franz Kafka', N'Fiction', CAST(0 AS bit), 180, N'In the Penal Colony');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Author', N'Genre', N'InInventory', N'NumberOfPages', N'Title') AND [object_id] = OBJECT_ID(N'[Books]'))
    SET IDENTITY_INSERT [Books] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Author', N'Genre', N'InInventory', N'NumberOfPages', N'Title') AND [object_id] = OBJECT_ID(N'[Books]'))
    SET IDENTITY_INSERT [Books] ON;
INSERT INTO [Books] ([Id], [Author], [Genre], [InInventory], [NumberOfPages], [Title])
VALUES (3, N'Franz Kafka', N'Fiction', CAST(0 AS bit), 223, N'The Trial');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Author', N'Genre', N'InInventory', N'NumberOfPages', N'Title') AND [object_id] = OBJECT_ID(N'[Books]'))
    SET IDENTITY_INSERT [Books] OFF;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200225185821_Initial', N'3.1.3');

GO

CREATE TABLE [Reservations] (
    [Id] int NOT NULL IDENTITY,
    [For] nvarchar(max) NULL,
    [ReservationCreated] datetime2 NOT NULL,
    [Books] nvarchar(max) NULL,
    [Status] int NOT NULL,
    CONSTRAINT [PK_Reservations] PRIMARY KEY ([Id])
);

GO

UPDATE [Books] SET [InInventory] = CAST(1 AS bit)
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


GO

UPDATE [Books] SET [InInventory] = CAST(1 AS bit)
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


GO

UPDATE [Books] SET [InInventory] = CAST(1 AS bit)
WHERE [Id] = 3;
SELECT @@ROWCOUNT;


GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200401192037_Reservations', N'3.1.3');

GO

