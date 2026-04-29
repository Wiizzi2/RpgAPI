BEGIN TRANSACTION;
ALTER TABLE [TB_PERSONAGENS] ADD [FotoPersoangem] varbinary(max) NULL;

ALTER TABLE [TB_PERSONAGENS] ADD [UsuarioId] int NULL;

CREATE TABLE [TB_USUARIOS] (
    [Id] int NOT NULL IDENTITY,
    [Username] varchar(200) NOT NULL,
    [PasswordHash] varbinary(max) NULL,
    [PasswordSalt] varbinary(max) NULL,
    [Foto] varbinary(max) NULL,
    [Latitude] float NULL,
    [Longitude] float NULL,
    [DataAcesso] datetime2 NULL,
    [Perfil] varchar(200) NULL DEFAULT 'Player',
    [Email] varchar(200) NULL,
    CONSTRAINT [PK_TB_USUARIOS] PRIMARY KEY ([Id])
);

UPDATE [TB_PERSONAGENS] SET [FotoPersoangem] = NULL, [UsuarioId] = 1
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGENS] SET [FotoPersoangem] = NULL, [UsuarioId] = 1
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGENS] SET [FotoPersoangem] = NULL, [UsuarioId] = 1
WHERE [Id] = 3;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGENS] SET [FotoPersoangem] = NULL, [UsuarioId] = 1
WHERE [Id] = 4;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGENS] SET [FotoPersoangem] = NULL, [UsuarioId] = 1
WHERE [Id] = 5;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGENS] SET [FotoPersoangem] = NULL, [UsuarioId] = 1
WHERE [Id] = 6;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGENS] SET [FotoPersoangem] = NULL, [UsuarioId] = 1
WHERE [Id] = 7;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGENS] SET [FotoPersoangem] = NULL, [UsuarioId] = 1
WHERE [Id] = 8;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGENS] SET [FotoPersoangem] = NULL, [UsuarioId] = 1
WHERE [Id] = 9;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGENS] SET [FotoPersoangem] = NULL, [UsuarioId] = 1
WHERE [Id] = 10;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGENS] SET [FotoPersoangem] = NULL, [UsuarioId] = 1
WHERE [Id] = 11;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGENS] SET [FotoPersoangem] = NULL, [UsuarioId] = 1
WHERE [Id] = 12;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGENS] SET [FotoPersoangem] = NULL, [UsuarioId] = 1
WHERE [Id] = 13;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGENS] SET [FotoPersoangem] = NULL, [UsuarioId] = 1
WHERE [Id] = 14;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGENS] SET [FotoPersoangem] = NULL, [UsuarioId] = 1
WHERE [Id] = 15;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGENS] SET [FotoPersoangem] = NULL, [UsuarioId] = 1
WHERE [Id] = 16;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGENS] SET [FotoPersoangem] = NULL, [UsuarioId] = 1
WHERE [Id] = 17;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGENS] SET [FotoPersoangem] = NULL, [UsuarioId] = 1
WHERE [Id] = 18;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGENS] SET [FotoPersoangem] = NULL, [UsuarioId] = 1
WHERE [Id] = 19;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGENS] SET [FotoPersoangem] = NULL, [UsuarioId] = 1
WHERE [Id] = 20;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGENS] SET [FotoPersoangem] = NULL, [UsuarioId] = 1
WHERE [Id] = 21;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGENS] SET [FotoPersoangem] = NULL, [UsuarioId] = 1
WHERE [Id] = 22;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGENS] SET [FotoPersoangem] = NULL, [UsuarioId] = 1
WHERE [Id] = 23;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGENS] SET [FotoPersoangem] = NULL, [UsuarioId] = 1
WHERE [Id] = 24;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGENS] SET [FotoPersoangem] = NULL, [UsuarioId] = 1
WHERE [Id] = 25;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGENS] SET [FotoPersoangem] = NULL, [UsuarioId] = 1
WHERE [Id] = 26;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGENS] SET [FotoPersoangem] = NULL, [UsuarioId] = 1
WHERE [Id] = 27;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGENS] SET [FotoPersoangem] = NULL, [UsuarioId] = 1
WHERE [Id] = 28;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGENS] SET [FotoPersoangem] = NULL, [UsuarioId] = 1
WHERE [Id] = 29;
SELECT @@ROWCOUNT;


IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataAcesso', N'Email', N'Foto', N'Latitude', N'Longitude', N'PasswordHash', N'PasswordSalt', N'Perfil', N'Username') AND [object_id] = OBJECT_ID(N'[TB_USUARIOS]'))
    SET IDENTITY_INSERT [TB_USUARIOS] ON;
INSERT INTO [TB_USUARIOS] ([Id], [DataAcesso], [Email], [Foto], [Latitude], [Longitude], [PasswordHash], [PasswordSalt], [Perfil], [Username])
VALUES (1, NULL, 'seuEmail@email.com', NULL, -23.520024100000001E0, -56.596497999999997E0, 0x1B2FAE0BF3B4C77113843F1E89E0B0182A31BA908A64A8CC782011290C044D11C6E787AE14E0A045F4D4322412A246BFD8AECE380ECD42F7811BB8D68E73F0EC, 0xF3EF79CE62BD37DD835271542E92AA8A4940DFA1D9788EFC302FE35574FDF90F23CFEA13348880DAD32E27E3610ECEF202D5FFC6659F068686F68BE163BC6C635BE69CC789374DCA130C84991191F4329685CE8511CFB25B57A9C5D805DFFC1F4E686E2F4CAF3C6FAA153FA306D1E13CE5AF2F9A54F77A8E8AD00583EC505CB4, 'admin', 'UsuarioAdmin');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataAcesso', N'Email', N'Foto', N'Latitude', N'Longitude', N'PasswordHash', N'PasswordSalt', N'Perfil', N'Username') AND [object_id] = OBJECT_ID(N'[TB_USUARIOS]'))
    SET IDENTITY_INSERT [TB_USUARIOS] OFF;

CREATE INDEX [IX_TB_PERSONAGENS_UsuarioId] ON [TB_PERSONAGENS] ([UsuarioId]);

ALTER TABLE [TB_PERSONAGENS] ADD CONSTRAINT [FK_TB_PERSONAGENS_TB_USUARIOS_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [TB_USUARIOS] ([Id]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260429012946_MigracaoUsuario', N'10.0.5');

COMMIT;
GO

