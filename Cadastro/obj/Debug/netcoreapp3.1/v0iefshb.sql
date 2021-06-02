﻿IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Categories] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Clients] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(100) NOT NULL,
    [LastName] nvarchar(100) NOT NULL,
    [Email] nvarchar(250) NOT NULL,
    [Ative] bit NOT NULL,
    CONSTRAINT [PK_Clients] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Products] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(100) NOT NULL,
    [Value] DECIMAL NOT NULL,
    [Active] bit NOT NULL,
    [IdCategory] int NOT NULL,
    [IdClient] int NOT NULL,
    [ClientId1] int NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Products_Categories_IdCategory] FOREIGN KEY ([IdCategory]) REFERENCES [Categories] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Products_Clients_ClientId1] FOREIGN KEY ([ClientId1]) REFERENCES [Clients] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Products_Clients_IdClient] FOREIGN KEY ([IdClient]) REFERENCES [Clients] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Products_ClientId1] ON [Products] ([ClientId1]);
GO

CREATE INDEX [IX_Products_IdCategory] ON [Products] ([IdCategory]);
GO

CREATE INDEX [IX_Products_IdClient] ON [Products] ([IdClient]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210601170621_initial', N'5.0.4');
GO

COMMIT;
GO

