IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
IF SCHEMA_ID(N'base') IS NULL EXEC(N'CREATE SCHEMA [base];');

IF SCHEMA_ID(N'element') IS NULL EXEC(N'CREATE SCHEMA [element];');

CREATE TABLE [base].[Alias] (
    [AliasId] int NOT NULL IDENTITY,
    [Name] nvarchar(250) NOT NULL,
    CONSTRAINT [PK_Alias] PRIMARY KEY ([AliasId])
);

CREATE TABLE [base].[Number] (
    [NumberId] int NOT NULL IDENTITY,
    [Description] nvarchar(500) NOT NULL,
    CONSTRAINT [PK_Number] PRIMARY KEY ([NumberId])
);

CREATE TABLE [base].[Symbol] (
    [SymbolId] int NOT NULL IDENTITY,
    [Name] nvarchar(50) NOT NULL,
    [NVARCHAR(255)] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Symbol] PRIMARY KEY ([SymbolId])
);

CREATE TABLE [element].[Element] (
    [ElementId] int NOT NULL IDENTITY,
    [Name] nvarchar(5) NOT NULL,
    [MainSymbolId] int NULL,
    CONSTRAINT [PK_Element] PRIMARY KEY ([ElementId]),
    CONSTRAINT [FK_Element_Symbol_MainSymbolId] FOREIGN KEY ([MainSymbolId]) REFERENCES [base].[Symbol] ([SymbolId])
);

CREATE TABLE [base].[Planet] (
    [PlanetId] int NOT NULL IDENTITY,
    [IsClassical] bit NOT NULL,
    [Name] nvarchar(7) NOT NULL,
    [SymbolId] int NULL,
    CONSTRAINT [PK_Planet] PRIMARY KEY ([PlanetId]),
    CONSTRAINT [FK_Planet_Symbol_SymbolId] FOREIGN KEY ([SymbolId]) REFERENCES [base].[Symbol] ([SymbolId])
);

CREATE TABLE [element].[ElementAlias] (
    [ElementAliasId] int NOT NULL IDENTITY,
    [ElementId] int NOT NULL,
    [AliasId] int NOT NULL,
    CONSTRAINT [PK_ElementAlias] PRIMARY KEY ([ElementAliasId]),
    CONSTRAINT [FK_ElementAlias_Alias_AliasId] FOREIGN KEY ([AliasId]) REFERENCES [base].[Alias] ([AliasId]) ON DELETE CASCADE,
    CONSTRAINT [FK_ElementAlias_Element_ElementId] FOREIGN KEY ([ElementId]) REFERENCES [element].[Element] ([ElementId]) ON DELETE CASCADE
);

CREATE TABLE [element].[ElementSymbol] (
    [ElementSymbolId] int NOT NULL IDENTITY,
    [ElementId] int NOT NULL,
    [SymbolId] int NOT NULL,
    CONSTRAINT [PK_ElementSymbol] PRIMARY KEY ([ElementSymbolId]),
    CONSTRAINT [FK_ElementSymbol_Element_ElementId] FOREIGN KEY ([ElementId]) REFERENCES [element].[Element] ([ElementId]) ON DELETE CASCADE,
    CONSTRAINT [FK_ElementSymbol_Symbol_SymbolId] FOREIGN KEY ([SymbolId]) REFERENCES [base].[Symbol] ([SymbolId]) ON DELETE CASCADE
);

CREATE TABLE [element].[ElementPlanetaryCorrespondence] (
    [CorrespondenceId] int NOT NULL IDENTITY,
    [ElementId] int NOT NULL,
    [PlanetId] int NOT NULL,
    CONSTRAINT [PK_ElementPlanetaryCorrespondence] PRIMARY KEY ([CorrespondenceId]),
    CONSTRAINT [FK_ElementPlanetaryCorrespondence_Element_ElementId] FOREIGN KEY ([ElementId]) REFERENCES [element].[Element] ([ElementId]) ON DELETE CASCADE,
    CONSTRAINT [FK_ElementPlanetaryCorrespondence_Planet_PlanetId] FOREIGN KEY ([PlanetId]) REFERENCES [base].[Planet] ([PlanetId]) ON DELETE CASCADE
);

CREATE INDEX [IX_Element_MainSymbolId] ON [element].[Element] ([MainSymbolId]);

CREATE INDEX [IX_ElementAlias_AliasId] ON [element].[ElementAlias] ([AliasId]);

CREATE INDEX [IX_ElementAlias_ElementId] ON [element].[ElementAlias] ([ElementId]);

CREATE INDEX [IX_ElementPlanetaryCorrespondence_ElementId] ON [element].[ElementPlanetaryCorrespondence] ([ElementId]);

CREATE INDEX [IX_ElementPlanetaryCorrespondence_PlanetId] ON [element].[ElementPlanetaryCorrespondence] ([PlanetId]);

CREATE INDEX [IX_ElementSymbol_ElementId] ON [element].[ElementSymbol] ([ElementId]);

CREATE INDEX [IX_ElementSymbol_SymbolId] ON [element].[ElementSymbol] ([SymbolId]);

CREATE INDEX [IX_Planet_SymbolId] ON [base].[Planet] ([SymbolId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260328221957_InitialMigration', N'10.0.5');

COMMIT;
GO

