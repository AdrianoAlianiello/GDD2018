-----------------------------------------------------------------------
-- MASTER DB

USE GD2C2018;
GO;

-----------------------------------------------------------------------
-- DROP TABLES

IF OBJECT_ID('dbo.Usuarios') IS NOT NULL
BEGIN
    DROP TABLE [dbo].[Usuarios];
END;

IF OBJECT_ID('dbo.Roles') IS NOT NULL
BEGIN
    DROP TABLE [dbo].[Roles];
END;

-----------------------------------------------------------------------
-- CREATE TABLES

CREATE TABLE [dbo].[Usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](255) NOT NULL,
	[Password] [nvarchar](255) NOT NULL,
	[CantIntentos] [numeric](1,0) NOT NULL,
	[Activo] [bit] NOT NULL,
	[Temporal] [bit] NOT NULL,
	[RolId] [int] NULL
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](255) NOT NULL,
	[Activo] [bit] NOT NULL
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-----------------------------------------------------------------------
-- CREATE CONSTRAINTS

ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Roles] FOREIGN KEY([RolId])
REFERENCES [dbo].[Roles] ([Id])
GO

ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Roles]
GO

-----------------------------------------------------------------------
-- INSERT DATA IN TABLES

INSERT INTO [dbo].[Roles] (Nombre, Activo)
VALUES
('Administrativo', 1),
('Cliente', 1),
('Empresa', 1);
GO

INSERT INTO [dbo].[Usuarios] (Username, Password, CantIntentos, Activo, Temporal, RolId)
VALUES
('admin', 'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7', 0, 1, 0, 1)
GO


