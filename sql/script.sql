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
GO

CREATE TABLE [Produto] (
    [Codigo] int NOT NULL IDENTITY,
    [Nome] nvarchar(50) NOT NULL,
    [Valor] decimal(10,2) NOT NULL,
    CONSTRAINT [PK_Produto] PRIMARY KEY ([Codigo])
);
GO

CREATE TABLE [ProdutoDesconto] (
    [Codigo] int NOT NULL IDENTITY,
    [Quantidade] int NOT NULL,
    [Valor] decimal(10,2) NOT NULL,
    [ProdutoCodigo] int NOT NULL,
    CONSTRAINT [PK_ProdutoDesconto] PRIMARY KEY ([Codigo]),
    CONSTRAINT [FK_ProdutoDesconto_Produto_ProdutoCodigo] FOREIGN KEY ([ProdutoCodigo]) REFERENCES [Produto] ([Codigo]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_ProdutoDesconto_ProdutoCodigo] ON [ProdutoDesconto] ([ProdutoCodigo]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241027155704_InitialCreate', N'8.0.10');
GO

COMMIT;
GO

