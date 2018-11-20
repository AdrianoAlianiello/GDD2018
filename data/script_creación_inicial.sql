-----------------------------------------------------------------------
-- MASTER DB

USE GD2C2018;
GO

-----------------------------------------------------------------------
-- DROP TABLES

IF OBJECT_ID('dbo.DetallesFacturas') IS NOT NULL
BEGIN
    DROP TABLE [dbo].[DetallesFacturas];
END;

IF OBJECT_ID('dbo.Facturas') IS NOT NULL
BEGIN
    DROP TABLE [dbo].[Facturas];
END;

IF OBJECT_ID('dbo.Pagos') IS NOT NULL
BEGIN
    DROP TABLE [dbo].[Pagos];
END;

IF OBJECT_ID('dbo.UbicacionesEspectaculos') IS NOT NULL
BEGIN
    DROP TABLE [dbo].[UbicacionesEspectaculos];
END;
 
IF OBJECT_ID('dbo.PagosClientes') IS NOT NULL
BEGIN
    DROP TABLE [dbo].[PagosClientes];
END;

IF OBJECT_ID('dbo.FuncionalidadesRoles') IS NOT NULL
BEGIN
    DROP TABLE [dbo].[FuncionalidadesRoles];
END;

IF OBJECT_ID('dbo.Funcionalidades') IS NOT NULL
BEGIN
    DROP TABLE [dbo].[Funcionalidades];
END;

IF OBJECT_ID('dbo.Entradas') IS NOT NULL
BEGIN
    DROP TABLE [dbo].[Entradas];
END; 

IF OBJECT_ID('dbo.Publicaciones') IS NOT NULL
BEGIN
    DROP TABLE [dbo].[Publicaciones];
END;

IF OBJECT_ID('dbo.GradosPublicaciones') IS NOT NULL
BEGIN
    DROP TABLE [dbo].[GradosPublicaciones];
END;

IF OBJECT_ID('dbo.EstadosPublicaciones') IS NOT NULL
BEGIN
    DROP TABLE [dbo].[EstadosPublicaciones];
END;

IF OBJECT_ID('dbo.EspectaculosHorarios') IS NOT NULL
BEGIN
    DROP TABLE [dbo].[EspectaculosHorarios];
END; 

IF OBJECT_ID('dbo.Espectaculos') IS NOT NULL
BEGIN
    DROP TABLE [dbo].[Espectaculos];
END;

IF OBJECT_ID('dbo.Rubros') IS NOT NULL
BEGIN
    DROP TABLE [dbo].[Rubros];
END;

IF OBJECT_ID('dbo.Ubicaciones') IS NOT NULL
BEGIN
    DROP TABLE [dbo].[Ubicaciones];
END;

IF OBJECT_ID('dbo.UbicacionesTipos') IS NOT NULL
BEGIN
    DROP TABLE [dbo].[UbicacionesTipos];
END;

IF OBJECT_ID('dbo.PuntosClientes') IS NOT NULL
BEGIN
    DROP TABLE [dbo].[PuntosClientes];
END;

IF OBJECT_ID('dbo.TiposMovimientos') IS NOT NULL
BEGIN
    DROP TABLE [dbo].[TiposMovimientos];
END;

IF OBJECT_ID('dbo.Canjes') IS NOT NULL
BEGIN
    DROP TABLE [dbo].[Canjes];
END;

IF OBJECT_ID('dbo.Productos') IS NOT NULL
BEGIN
    DROP TABLE [dbo].[Productos];
END;

IF OBJECT_ID('dbo.Empresas') IS NOT NULL
BEGIN
    DROP TABLE [dbo].[Empresas];
END;

IF OBJECT_ID('dbo.TarjetasCredito') IS NOT NULL
BEGIN
    DROP TABLE [dbo].[TarjetasCredito];
END;

IF OBJECT_ID('dbo.TiposTarjetasCredito') IS NOT NULL
BEGIN
    DROP TABLE [dbo].[TiposTarjetasCredito];
END;

IF OBJECT_ID('dbo.RolesUsuarios') IS NOT NULL
BEGIN
    DROP TABLE [dbo].[RolesUsuarios];
END;

IF OBJECT_ID('dbo.Compras') IS NOT NULL
BEGIN
    DROP TABLE [dbo].[Compras];
END;

IF OBJECT_ID('dbo.Clientes') IS NOT NULL
BEGIN
    DROP TABLE [dbo].[Clientes];
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

CREATE TABLE [dbo].[PagosClientes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TarjetaId] [int] NOT NULL,
	[CompraId] [int] NOT NULL
 CONSTRAINT [PK_PagosClientes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[EstadosPublicaciones](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](255) NOT NULL,
	[Peso] [numeric](18,0) NOT NULL
 CONSTRAINT [PK_EstadosPublicaciones] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Productos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](255) NOT NULL,
	[PuntosRequeridos] [numeric](18,0) NOT NULL,
	[Stock] [numeric](18,0) NOT NULL
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[DetallesFacturas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PrecioEntrada] [numeric](18,0) NOT NULL,
	[PrecioComision] [numeric](18,0) NOT NULL,
	[FacturaId] [int] NOT NULL,
	[EntradaId] [int] NOT NULL,
 CONSTRAINT [PK_DetallesFacturas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Canjes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime]NOT NULL,
	[ProductoId] [int] NOT NULL,
	[ClienteId] [int] NOT NULL,
 CONSTRAINT [PK_Canjes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[GradosPublicaciones](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](255) NOT NULL,
	[PorcentajeComision] [numeric](18,0) NOT NULL
 CONSTRAINT [PK_GradosPublicaciones] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[UbicacionesTipos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [numeric](18,0) NOT NULL,
	[Descripcion] [nvarchar](255) NOT NULL
 CONSTRAINT [PK_UbicacionesTipos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[TiposMovimientos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [nvarchar](255) NOT NULL,
	[Descripcion] [nvarchar](255) NOT NULL
 CONSTRAINT [PK_TiposMovimientos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Ubicaciones](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Fila] [varchar](3) NULL,
	[Asiento] [numeric](18,0) NULL,
	[Precio] [numeric](18,0) NOT NULL,
	[Numerada] [bit] NOT NULL,
	[TipoId] [int] NOT NULL,
	[CantPuntos] [numeric](18,0) NOT NULL,
 CONSTRAINT [PK_Ubicaciones] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Rubros](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [numeric](18,0) NOT NULL,
	[Descripcion] [nvarchar](255) NOT NULL
 CONSTRAINT [PK_Rubros] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Espectaculos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](255) NOT NULL,
	[Direccion] [nvarchar](255) NULL,
	[RubroId] [int] NOT NULL,
 CONSTRAINT [PK_Espectaculos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[UbicacionesEspectaculos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EspectaculoId] [int] NOT NULL,
	[UbicacionId] [int] NOT NULL
 CONSTRAINT [PK_UbicacionesEspectaculos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[EspectaculosHorarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[EspectaculoId] [int] NOT NULL,
 CONSTRAINT [PK_EspectaculosHorarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

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

CREATE TABLE [dbo].[Compras](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Rendida] [bit] NOT NULL,
	[ClienteId] [int] NOT NULL
 CONSTRAINT [PK_Compras] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Entradas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](255) NOT NULL,
	[Apellido] [nvarchar](255) NOT NULL,
	[UbicacionId] [int] NOT NULL,
	[CompraId] [int] NOT NULL,
	[PublicacionId] [int] NOT NULL,
	[EspectaculoId] [int] NOT NULL
 CONSTRAINT [PK_Entradas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[PuntosClientes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Cantidad] [numeric](18,0) NOT NULL,
	[FechaVto] [datetime] NULL,
	[ClienteId] [int] NOT NULL,
	[TipoMovimientoId] [int] NOT NULL,
	[CompraId] [int] NOT NULL,
	[CanjeId] [int] NOT NULL
 CONSTRAINT [PK_PuntosClientes] PRIMARY KEY CLUSTERED 
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
	[NroDocumento] [numeric](18,0) NOT NULL,
	[Cuil] [numeric](18,0) NULL,
	[Mail] [nvarchar](255) NOT NULL,
	[Telefono] [numeric](18,0) NOT NULL,
	[DomicilioCalle] [nvarchar](255) NOT NULL,
	[DomicilioNro] [numeric](18,0) NOT NULL,
	[DomicilioPiso] [numeric](18,0) NOT NULL,
	[DomicilioDepto] [nvarchar](255) NOT NULL,
	[DomicilioCodPostal] [nvarchar](255) NOT NULL,
	[DomicilioLocalidad] [nvarchar](255) NULL,
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

CREATE TABLE [dbo].[Pagos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Total] [numeric](18,0) NOT NULL
 CONSTRAINT [PK_Pagos] PRIMARY KEY CLUSTERED 
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

CREATE TABLE [dbo].[Publicaciones](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [numeric](18,0) NOT NULL,
	[Descripcion] [nvarchar](255) NOT NULL,
	[FechaInicio] [Datetime] NOT NULL,
	[EstadoId] [int] NOT NULL,
	[GradoId] [int] NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[EspectaculoHorarioId] [int] NOT NULL,
	[EmpresaId] [int] NOT NULL,
 CONSTRAINT [PK_Publicaciones] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Facturas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Numero] [numeric](18,0) NOT NULL,
	[EmpresaId] [int] NOT NULL,
	[PagoId] [int] NULL,
	[Valida] [bit] NOT NULL,
 CONSTRAINT [PK_Facturas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[TiposTarjetasCredito](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_TiposTarjetasCredito] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[TarjetasCredito](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Numero] [numeric](18,0) NOT NULL,
	[FechaVto] [datetime] NOT NULL,
	[Activa] [bit] NOT NULL,
	[ClienteId] [int] NOT NULL,
	[TipoId] [int] NOT NULL
 CONSTRAINT [PK_TarjetasCredito] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


-----------------------------------------------------------------------
-- CREATE CONSTRAINTS

ALTER TABLE [dbo].[Ubicaciones]  WITH CHECK ADD  CONSTRAINT [FK_Ubicaciones_UbicacionesTipos] FOREIGN KEY([TipoId])
REFERENCES [dbo].[UbicacionesTipos] ([Id])
GO

ALTER TABLE [dbo].[Ubicaciones] CHECK CONSTRAINT [FK_Ubicaciones_UbicacionesTipos]
GO
ALTER TABLE [dbo].[RolesUsuarios]  WITH CHECK ADD  CONSTRAINT [FK_RolesUsuarios_Roles] FOREIGN KEY([RolId])
REFERENCES [dbo].[Roles] ([Id])
GO

ALTER TABLE [dbo].[RolesUsuarios] CHECK CONSTRAINT [FK_RolesUsuarios_Roles]
GO

ALTER TABLE [dbo].[Facturas]  WITH CHECK ADD  CONSTRAINT [FK_Facturas_Pagos] FOREIGN KEY([PagoId])
REFERENCES [dbo].[Pagos] ([Id])
GO

ALTER TABLE [dbo].[Facturas] CHECK CONSTRAINT [FK_Facturas_Pagos]
GO

ALTER TABLE [dbo].[Espectaculos]  WITH CHECK ADD  CONSTRAINT [FK_Espectaculos_Empresas] FOREIGN KEY([RubroId])
REFERENCES [dbo].[Rubros] ([Id])
GO

ALTER TABLE [dbo].[Espectaculos] CHECK CONSTRAINT [FK_Espectaculos_Empresas]
GO

ALTER TABLE [dbo].[UbicacionesEspectaculos]  WITH CHECK ADD  CONSTRAINT [FK_UbicacionesEspectaculos_Ubicaciones] FOREIGN KEY([UbicacionId])
REFERENCES [dbo].[Ubicaciones] ([Id])
GO

ALTER TABLE [dbo].[UbicacionesEspectaculos] CHECK CONSTRAINT [FK_UbicacionesEspectaculos_Ubicaciones]
GO

ALTER TABLE [dbo].[UbicacionesEspectaculos]  WITH CHECK ADD  CONSTRAINT [FK_UbicacionesEspectaculos_Espectaculos] FOREIGN KEY([EspectaculoId])
REFERENCES [dbo].[Espectaculos] ([Id])
GO

ALTER TABLE [dbo].[UbicacionesEspectaculos] CHECK CONSTRAINT [FK_UbicacionesEspectaculos_Espectaculos]
GO

ALTER TABLE [dbo].[EspectaculosHorarios]  WITH CHECK ADD  CONSTRAINT [FK_EspectaculosHorarios_Espectaculos] FOREIGN KEY([EspectaculoId])
REFERENCES [dbo].[Espectaculos] ([Id])
GO

ALTER TABLE [dbo].[EspectaculosHorarios] CHECK CONSTRAINT [FK_EspectaculosHorarios_Espectaculos]
GO

ALTER TABLE [dbo].[Facturas]  WITH CHECK ADD  CONSTRAINT [FK_Facturas_Empresas] FOREIGN KEY([EmpresaId])
REFERENCES [dbo].[Empresas] ([Id])
GO

ALTER TABLE [dbo].[Facturas] CHECK CONSTRAINT [FK_Facturas_Empresas]
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

ALTER TABLE [dbo].[Publicaciones] WITH CHECK ADD  CONSTRAINT [FK_Publicaciones_EstadosPublicaciones] FOREIGN KEY([EstadoId])
REFERENCES [dbo].[EstadosPublicaciones] ([Id])
GO

ALTER TABLE [dbo].[Publicaciones] CHECK CONSTRAINT [FK_Publicaciones_EstadosPublicaciones]
GO

ALTER TABLE [dbo].[Publicaciones] WITH CHECK ADD  CONSTRAINT [FK_Publicaciones_GradosPublicaciones] FOREIGN KEY([GradoId])
REFERENCES [dbo].[GradosPublicaciones] ([Id])
GO

ALTER TABLE [dbo].[Publicaciones] CHECK CONSTRAINT [FK_Publicaciones_GradosPublicaciones]
GO

ALTER TABLE [dbo].[Publicaciones] WITH CHECK ADD  CONSTRAINT [FK_Publicaciones_Usuarios] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuarios] ([Id])
GO

ALTER TABLE [dbo].[Publicaciones] CHECK CONSTRAINT [FK_Publicaciones_Usuarios]
GO

ALTER TABLE [dbo].[Publicaciones] WITH CHECK ADD  CONSTRAINT [FK_Publicaciones_EspectaculosHorarios] FOREIGN KEY([EspectaculoHorarioId])
REFERENCES [dbo].[EspectaculosHorarios] ([Id])
GO

ALTER TABLE [dbo].[Publicaciones] CHECK CONSTRAINT [FK_Publicaciones_EspectaculosHorarios]
GO

ALTER TABLE [dbo].[Publicaciones] WITH CHECK ADD  CONSTRAINT [FK_Publicaciones_Empresas] FOREIGN KEY([EmpresaId])
REFERENCES [dbo].[Empresas] ([Id])
GO

ALTER TABLE [dbo].[Publicaciones] CHECK CONSTRAINT [FK_Publicaciones_Empresas]
GO

ALTER TABLE [dbo].[TarjetasCredito] WITH CHECK ADD  CONSTRAINT [FK_TarjetasCredito_Clientes] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Clientes] ([Id])
GO

ALTER TABLE [dbo].[TarjetasCredito] CHECK CONSTRAINT [FK_TarjetasCredito_Clientes]
GO

ALTER TABLE [dbo].[TarjetasCredito] WITH CHECK ADD  CONSTRAINT [FK_TarjetasCredito_TiposTarjetasCredito] FOREIGN KEY([TipoId])
REFERENCES [dbo].[TiposTarjetasCredito] ([Id])
GO

ALTER TABLE [dbo].[TarjetasCredito] CHECK CONSTRAINT [FK_TarjetasCredito_TiposTarjetasCredito]
GO

ALTER TABLE [dbo].[DetallesFacturas] WITH CHECK ADD  CONSTRAINT [FK_DetallesFacturas_Facturas] FOREIGN KEY([FacturaId])
REFERENCES [dbo].[Clientes] ([Id])
GO

ALTER TABLE [dbo].[DetallesFacturas] CHECK CONSTRAINT [FK_DetallesFacturas_Facturas]
GO

ALTER TABLE [dbo].[DetallesFacturas] WITH CHECK ADD  CONSTRAINT [FK_DetallesFacturas_Entradas] FOREIGN KEY([EntradaId])
REFERENCES [dbo].[Entradas] ([Id])
GO

ALTER TABLE [dbo].[DetallesFacturas] CHECK CONSTRAINT [FK_DetallesFacturas_Entradas]
GO

ALTER TABLE [dbo].[Entradas] WITH CHECK ADD  CONSTRAINT [FK_Entradas_Ubicaciones] FOREIGN KEY([UbicacionId])
REFERENCES [dbo].[Ubicaciones] ([Id])
GO

ALTER TABLE [dbo].[Entradas] CHECK CONSTRAINT [FK_Entradas_Ubicaciones]
GO

ALTER TABLE [dbo].[Entradas] WITH CHECK ADD  CONSTRAINT [FK_Entradas_Compras] FOREIGN KEY([CompraId])
REFERENCES [dbo].[Compras] ([Id])
GO

ALTER TABLE [dbo].[Entradas] CHECK CONSTRAINT [FK_Entradas_Compras]
GO

ALTER TABLE [dbo].[Entradas] WITH CHECK ADD  CONSTRAINT [FK_Entradas_Publicaciones] FOREIGN KEY([PublicacionId])
REFERENCES [dbo].[Publicaciones] ([Id])
GO

ALTER TABLE [dbo].[Entradas] CHECK CONSTRAINT [FK_Entradas_Publicaciones]
GO

ALTER TABLE [dbo].[Entradas] WITH CHECK ADD  CONSTRAINT [FK_Entradas_Espectaculos] FOREIGN KEY([EspectaculoId])
REFERENCES [dbo].[Espectaculos] ([Id])
GO

ALTER TABLE [dbo].[Entradas] CHECK CONSTRAINT [FK_Entradas_Espectaculos]
GO

ALTER TABLE [dbo].[PuntosClientes] WITH CHECK ADD  CONSTRAINT [FK_PuntosClientes_Clientes] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Clientes] ([Id])
GO

ALTER TABLE [dbo].[PuntosClientes] CHECK CONSTRAINT [FK_PuntosClientes_Clientes]
GO

ALTER TABLE [dbo].[PuntosClientes] WITH CHECK ADD  CONSTRAINT [FK_PuntosClientes_TiposMovimientos] FOREIGN KEY([TipoMovimientoId])
REFERENCES [dbo].[TiposMovimientos] ([Id])
GO

ALTER TABLE [dbo].[PuntosClientes] CHECK CONSTRAINT [FK_PuntosClientes_TiposMovimientos]
GO

ALTER TABLE [dbo].[PuntosClientes] WITH CHECK ADD  CONSTRAINT [FK_PuntosClientes_Compras] FOREIGN KEY([CompraId])
REFERENCES [dbo].[Compras] ([Id])
GO

ALTER TABLE [dbo].[PuntosClientes] CHECK CONSTRAINT [FK_PuntosClientes_Compras]
GO

ALTER TABLE [dbo].[PuntosClientes] WITH CHECK ADD  CONSTRAINT [FK_PuntosClientes_Canjes] FOREIGN KEY([CanjeId])
REFERENCES [dbo].[Canjes] ([Id])
GO

ALTER TABLE [dbo].[PuntosClientes] CHECK CONSTRAINT [FK_PuntosClientes_Canjes]
GO

ALTER TABLE [dbo].[Canjes] WITH CHECK ADD  CONSTRAINT [FK_Canjes_Productos] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[Compras] ([Id])
GO

ALTER TABLE [dbo].[Canjes] CHECK CONSTRAINT [FK_Canjes_Productos]
GO

ALTER TABLE [dbo].[Canjes] WITH CHECK ADD  CONSTRAINT [FK_Canjes_Clientes] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Canjes] ([Id])
GO

ALTER TABLE [dbo].[Canjes] CHECK CONSTRAINT [FK_Canjes_Clientes]
GO

ALTER TABLE [dbo].[PagosClientes] WITH CHECK ADD  CONSTRAINT [FK_PagosClientes_TarjetasCredito] FOREIGN KEY([TarjetaId])
REFERENCES [dbo].[TarjetasCredito] ([Id])
GO

ALTER TABLE [dbo].[PagosClientes] CHECK CONSTRAINT [FK_PagosClientes_TarjetasCredito]
GO

ALTER TABLE [dbo].[PagosClientes] WITH CHECK ADD  CONSTRAINT [FK_PagosClientes_Compras] FOREIGN KEY([CompraId])
REFERENCES [dbo].[Compras] ([Id])
GO

ALTER TABLE [dbo].[PagosClientes] CHECK CONSTRAINT [FK_PagosClientes_Compras]
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

INSERT INTO [dbo].[TiposTarjetasCredito] (Descripcion)
VALUES
('Visa'),
('Mastercard'),
('American Express');
GO


