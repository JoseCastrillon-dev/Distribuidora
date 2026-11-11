CREATE DATABASE Distribuidora;
GO 
USE Distribuidora;
GO 



CREATE TABLE [Tipos] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [Nombre] NVARCHAR(50) NOT NULL,
    [Especie] NVARCHAR(20) NOT NULL,

);

CREATE TABLE [Carnes] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [Codigo] NVARCHAR(20) NOT NULL,
    [Nombre] NVARCHAR(50) NOT NULL,
    [Peso] DECIMAL NOT NULL,
    [id_tipo] INT REFERENCES [Tipos]([Id]) NOT NULL,
    [Activo] BIT NOT NULL,
);

CREATE TABLE [Auditoria] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [Descripcion] NVARCHAR(50) NOT NULL,
    [Fecha] SMALLDATETIME NOT NULL,

);