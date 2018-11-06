-----------------------------------------------------------------------
-- MASTER DB

USE GD2C2018;
GO

-----------------------------------------------------------------------
-- DROP TABLES

IF OBJECT_ID('dbo.Empresas') IS NOT NULL
BEGIN
    DROP TABLE [dbo].[Empresas];
END;

IF OBJECT_ID('dbo.Clientes') IS NOT NULL
BEGIN
    DROP TABLE [dbo].[Clientes];
END;

IF OBJECT_ID('dbo.FuncionalidadesRoles') IS NOT NULL
BEGIN
    DROP TABLE [dbo].[FuncionalidadesRoles];
END;

IF OBJECT_ID('dbo.Funcionalidades') IS NOT NULL
BEGIN
    DROP TABLE [dbo].[Funcionalidades];
END;

IF OBJECT_ID('dbo.RolesUsuarios') IS NOT NULL
BEGIN
    DROP TABLE [dbo].[RolesUsuarios];
END;

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
	[Temporal] [bit] NOT NULL
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

CREATE TABLE [dbo].[RolesUsuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RolId] [int] NOT NULL,
	[UsuarioId] [int] NOT NULL
 CONSTRAINT [PK_RolesUsuarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Funcionalidades](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Detalle] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Funcionalidades] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[FuncionalidadesRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FuncionalidadId] [int] NOT NULL,
	[RolId] [int] NOT NULL
 CONSTRAINT [PK_FuncionalidadesRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Clientes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](255) NOT NULL,
	[Apellido] [nvarchar](255) NOT NULL,
	[TipoDocumento] [nvarchar](255) NOT NULL,
	[Cuil] [numeric](18,0) NULL,
	[Mail] [nvarchar](255) NOT NULL,
	[Telefono] [numeric](18,0) NOT NULL,
	[DomicilioCalle] [nvarchar](255) NOT NULL,
	[DomicilioNro] [numeric](18,0) NOT NULL,
	[DomicilioPiso] [numeric](18,0) NOT NULL,
	[DomicilioDepto] [nvarchar](255) NOT NULL,
	[DomicilioCodPostal] [nvarchar](255) NOT NULL,
	[FechaNacimiento] [datetime] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[Activo] [bit] NOT NULL,
	[UsuarioId] [int] NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Empresas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RazonSocial] [nvarchar](255) NOT NULL,
	[Cuit] [nvarchar](255) NOT NULL,
	[Mail] [nvarchar](50) NOT NULL,
	[Telefono] [numeric](18,0) NOT NULL,
	[DomicilioCalle] [nvarchar](50) NOT NULL,
	[DomicilioNro] [numeric](18,0) NOT NULL,
	[DomicilioPiso] [numeric](18,0) NULL,
	[DomicilioDepto] [nvarchar](50) NULL,
	[DomicilioCodPostal] [nvarchar](50) NOT NULL,
	[Ciudad] [nvarchar](255) NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[Activa] [bit] NOT NULL,
	[UsuarioId] [int] NOT NULL,
 CONSTRAINT [PK_Empresas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-----------------------------------------------------------------------
-- CREATE CONSTRAINTS

ALTER TABLE [dbo].[RolesUsuarios]  WITH CHECK ADD  CONSTRAINT [FK_RolesUsuarios_Roles] FOREIGN KEY([RolId])
REFERENCES [dbo].[Roles] ([Id])
GO

ALTER TABLE [dbo].[RolesUsuarios] CHECK CONSTRAINT [FK_RolesUsuarios_Roles]
GO

ALTER TABLE [dbo].[RolesUsuarios]  WITH CHECK ADD  CONSTRAINT [FK_RolesUsuarios_Usuarios] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuarios] ([Id])
GO

ALTER TABLE [dbo].[RolesUsuarios] CHECK CONSTRAINT [FK_RolesUsuarios_Usuarios]
GO

ALTER TABLE [dbo].[FuncionalidadesRoles]  WITH CHECK ADD  CONSTRAINT [FK_FuncionalidadesRoles_Funcionalidades] FOREIGN KEY([FuncionalidadId])
REFERENCES [dbo].[Funcionalidades] ([Id])
GO

ALTER TABLE [dbo].[FuncionalidadesRoles] CHECK CONSTRAINT [FK_FuncionalidadesRoles_Funcionalidades]
GO

ALTER TABLE [dbo].[FuncionalidadesRoles]  WITH CHECK ADD  CONSTRAINT [FK_FuncionalidadesRoles_Roles] FOREIGN KEY([RolId])
REFERENCES [dbo].[Roles] ([Id])
GO

ALTER TABLE [dbo].[FuncionalidadesRoles] CHECK CONSTRAINT [FK_FuncionalidadesRoles_Roles]
GO

ALTER TABLE [dbo].[Clientes] WITH CHECK ADD  CONSTRAINT [FK_Clientes_Usuarios] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuarios] ([Id])
GO

ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Clientes_Usuarios]
GO

ALTER TABLE [dbo].[Empresas] WITH CHECK ADD  CONSTRAINT [FK_Empresas_Usuarios] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuarios] ([Id])
GO

ALTER TABLE [dbo].[Empresas] CHECK CONSTRAINT [FK_Empresas_Usuarios]
GO

-----------------------------------------------------------------------
-- INSERT DATA IN TABLES

INSERT INTO [dbo].[Roles] (Nombre, Activo)
VALUES
('Administrativo', 1),
('Cliente', 1),
('Empresa', 1);
GO

INSERT INTO [dbo].[Usuarios] (Username, Password, CantIntentos, Activo, Temporal)
VALUES
('admin', 'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7', 0, 1, 0)
GO

INSERT INTO [dbo].[RolesUsuarios] (RolId, UsuarioId)
VALUES
(1,1);
GO

INSERT INTO [dbo].[Funcionalidades] (Detalle)
VALUES
('Alta de Cliente'),
('Modificar Cliente'),
('Baja de Cliente');
GO

INSERT INTO [dbo].[FuncionalidadesRoles] (RolId, FuncionalidadId)
SELECT 1, Id FROM [dbo].[Funcionalidades]
GO


