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
CREATE TABLE [TB_PERSONAGENS] (
    [Id] int NOT NULL IDENTITY,
    [Nome] varchar(200) NOT NULL,
    [PontosVida] int NOT NULL,
    [Forca] int NOT NULL,
    [Defesa] int NOT NULL,
    [Inteligencia] int NOT NULL,
    [Classe] int NOT NULL,
    CONSTRAINT [PK_TB_PERSONAGENS] PRIMARY KEY ([Id])
);

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Classe', N'Defesa', N'Forca', N'Inteligencia', N'Nome', N'PontosVida') AND [object_id] = OBJECT_ID(N'[TB_PERSONAGENS]'))
    SET IDENTITY_INSERT [TB_PERSONAGENS] ON;
INSERT INTO [TB_PERSONAGENS] ([Id], [Classe], [Defesa], [Forca], [Inteligencia], [Nome], [PontosVida])
VALUES (1, 1, 23, 17, 33, 'Frodo', 100),
(2, 1, 25, 15, 30, 'Sam', 100),
(3, 1, 17, 20, 31, 'Hobbit', 100),
(4, 1, 35, 28, 25, 'Artur', 120),
(5, 1, 32, 30, 24, 'Lancelote', 115),
(6, 1, 30, 26, 22, 'Gawain', 125),
(7, 1, 28, 25, 26, 'Bedivere', 110),
(8, 2, 18, 18, 37, 'Gandalf', 100),
(9, 2, 15, 14, 45, 'Merlin', 85),
(10, 2, 14, 16, 48, 'Saruman', 90),
(11, 2, 16, 13, 50, 'Morgana', 88),
(12, 2, 13, 15, 42, 'Radagast', 92),
(13, 3, 21, 18, 35, 'Galadriel', 100),
(14, 3, 13, 21, 34, 'Celeborn', 100),
(15, 3, 24, 18, 40, 'Elara', 105),
(16, 3, 26, 16, 38, 'Isolda', 100),
(17, 3, 22, 17, 41, 'Taliesin', 102),
(18, 3, 25, 19, 39, 'Morgaine', 108),
(19, 4, 100, 32, 80, 'Karsen', 110),
(20, 4, 20, 35, 18, 'Conan', 130),
(21, 4, 22, 33, 19, 'Beowulf', 128),
(22, 4, 24, 31, 20, 'Sigurd', 125),
(23, 4, 19, 36, 17, 'Heracles', 135),
(24, 5, 18, 19, 35, 'Robin', 95),
(25, 5, 20, 15, 60, 'Sofiz', 100),
(26, 5, 16, 21, 32, 'Legolas', 98),
(27, 5, 17, 20, 38, 'Artemis', 100),
(28, 5, 19, 18, 36, 'Hawkeye', 93),
(29, 5, 15, 22, 34, 'Darthur', 96);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Classe', N'Defesa', N'Forca', N'Inteligencia', N'Nome', N'PontosVida') AND [object_id] = OBJECT_ID(N'[TB_PERSONAGENS]'))
    SET IDENTITY_INSERT [TB_PERSONAGENS] OFF;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260408005339_InitialCreate', N'10.0.5');

COMMIT;
GO

