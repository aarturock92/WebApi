USE [Cemex]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 16/05/2017 08:01:23 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DetalleModuloPermiso]    Script Date: 16/05/2017 08:01:23 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleModuloPermiso](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Estatus] [int] NOT NULL,
	[IdModulo] [int] NOT NULL,
	[IdPermiso] [int] NOT NULL,
	[FechaAlta] [datetime] NOT NULL,
	[FechaModifico] [datetime] NULL,
	[IdUsuarioAlta] [int] NOT NULL,
	[IdUsuarioModifico] [int] NULL,
	[Permiso_ID] [int] NULL,
	[Modulo_ID] [int] NULL,
 CONSTRAINT [PK_dbo.DetalleModuloPermiso] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DetalleRolPermiso]    Script Date: 16/05/2017 08:01:23 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleRolPermiso](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Estatus] [int] NOT NULL,
	[FechaAlta] [datetime] NOT NULL,
	[FechaModifico] [datetime] NULL,
	[IdUsuarioAlta] [int] NOT NULL,
	[IdUsuarioModifico] [int] NULL,
	[DetalleModuloPermiso_ID] [int] NULL,
	[Rol_ID] [int] NULL,
 CONSTRAINT [PK_dbo.DetalleRolPermiso] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Distrito]    Script Date: 16/05/2017 08:01:23 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Distrito](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DistritoId] [int] NOT NULL,
	[ClaveDistrito] [nvarchar](50) NOT NULL,
	[NombreDistrito] [nvarchar](100) NOT NULL,
	[Estatus] [int] NOT NULL,
	[FechaAlta] [datetime] NOT NULL,
	[FechaModifico] [datetime] NULL,
	[IdUsuarioAlta] [int] NOT NULL,
	[IdUsuarioModifico] [int] NULL,
 CONSTRAINT [PK_dbo.Distrito] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Error]    Script Date: 16/05/2017 08:01:23 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Error](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](max) NULL,
	[StackTrace] [nvarchar](max) NULL,
	[FechaAlta] [datetime] NOT NULL,
	[FechaModifico] [datetime] NOT NULL,
	[IdUsuarioAlta] [int] NOT NULL,
	[IdUsuarioModifico] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Error] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Estado]    Script Date: 16/05/2017 08:01:23 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estado](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Abreviatura] [nvarchar](50) NOT NULL,
	[Estatus] [int] NOT NULL,
	[FechaAlta] [datetime] NOT NULL,
	[FechaModifico] [datetime] NULL,
	[IdUsuarioAlta] [int] NOT NULL,
	[IdUsuarioModifico] [int] NULL,
 CONSTRAINT [PK_dbo.Estado] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Jerarquia]    Script Date: 16/05/2017 08:01:23 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jerarquia](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Descripcion] [nvarchar](200) NOT NULL,
	[IdJerarquiaPadre] [int] NOT NULL,
	[NivelEstructura] [int] NOT NULL,
	[Estatus] [int] NOT NULL,
	[FechaAlta] [datetime] NOT NULL,
	[FechaModifico] [datetime] NULL,
	[IdUsuarioAlta] [int] NOT NULL,
	[IdUsuarioModifico] [int] NULL,
 CONSTRAINT [PK_dbo.Jerarquia] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Modulo]    Script Date: 16/05/2017 08:01:23 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Modulo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IdRegistroModulo] [int] NOT NULL,
	[Orden] [int] NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Descripcion] [nvarchar](200) NOT NULL,
	[IconoMenu] [nvarchar](50) NOT NULL,
	[Url] [nvarchar](100) NOT NULL,
	[Estatus] [int] NOT NULL,
	[FechaAlta] [datetime] NOT NULL,
	[FechaModifico] [datetime] NOT NULL,
	[IdUsuarioAlta] [int] NOT NULL,
	[IdUsuarioModifico] [int] NULL,
 CONSTRAINT [PK_dbo.Modulo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Municipio]    Script Date: 16/05/2017 08:01:23 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Municipio](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Estatus] [int] NOT NULL,
	[EstadoId] [int] NOT NULL,
	[FechaAlta] [datetime] NOT NULL,
	[FechaModifico] [datetime] NULL,
	[IdUsuarioAlta] [int] NOT NULL,
	[IdUsuarioModifico] [int] NULL,
 CONSTRAINT [PK_dbo.Municipio] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Permiso]    Script Date: 16/05/2017 08:01:23 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permiso](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Descripcion] [nvarchar](200) NOT NULL,
	[Icono] [nvarchar](100) NOT NULL,
	[Estatus] [int] NOT NULL,
	[FechaAlta] [datetime] NOT NULL,
	[FechaModifico] [datetime] NULL,
	[IdUsuarioAlta] [int] NOT NULL,
	[IdUsuarioModifico] [int] NULL,
 CONSTRAINT [PK_dbo.Permiso] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PlazaImmex]    Script Date: 16/05/2017 08:01:23 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlazaImmex](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RegionId] [int] NOT NULL,
	[CRPlazaImmex] [nvarchar](50) NOT NULL,
	[NombrePlazaImmex] [nvarchar](100) NOT NULL,
	[Estatus] [int] NOT NULL,
	[FechaAlta] [datetime] NOT NULL,
	[FechaModifico] [datetime] NULL,
	[IdUsuarioAlta] [int] NOT NULL,
	[IdUsuarioModifico] [int] NULL,
 CONSTRAINT [PK_dbo.PlazaImmex] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PlazaOxxo]    Script Date: 16/05/2017 08:01:23 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlazaOxxo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PlazaImmexId] [int] NOT NULL,
	[CRPlazaOxxo] [nvarchar](50) NOT NULL,
	[NombrePlazaOxxo] [nvarchar](100) NOT NULL,
	[Estatus] [int] NOT NULL,
	[FechaAlta] [datetime] NOT NULL,
	[FechaModifico] [datetime] NULL,
	[IdUsuarioAlta] [int] NOT NULL,
	[IdUsuarioModifico] [int] NULL,
 CONSTRAINT [PK_dbo.PlazaOxxo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Region]    Script Date: 16/05/2017 08:01:23 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Region](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IdNegocio] [int] NOT NULL,
	[ClaveRegion] [nvarchar](50) NOT NULL,
	[NombreRegion] [nvarchar](100) NOT NULL,
	[Estatus] [int] NOT NULL,
	[FechaAlta] [datetime] NOT NULL,
	[FechaModifico] [datetime] NULL,
	[IdUsuarioAlta] [int] NOT NULL,
	[IdUsuarioModifico] [int] NULL,
 CONSTRAINT [PK_dbo.Region] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rol]    Script Date: 16/05/2017 08:01:23 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IdJerarquia] [int] NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Descripcion] [nvarchar](200) NOT NULL,
	[AsignacionMultiple] [int] NOT NULL,
	[Estatus] [int] NOT NULL,
	[FechaAlta] [datetime] NOT NULL,
	[FechaModifico] [datetime] NULL,
	[IdUsuarioAlta] [int] NOT NULL,
	[IdUsuarioModifico] [int] NULL,
 CONSTRAINT [PK_dbo.Rol] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tienda]    Script Date: 16/05/2017 08:01:23 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tienda](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DistritoId] [int] NOT NULL,
	[UniqueTienda] [uniqueidentifier] NOT NULL,
	[CRTienda] [nvarchar](50) NOT NULL,
	[NombreTienda] [nvarchar](100) NOT NULL,
	[Calle] [nvarchar](150) NOT NULL,
	[Numero] [nvarchar](20) NOT NULL,
	[EntreCalles] [nvarchar](150) NOT NULL,
	[Colonia] [nvarchar](100) NOT NULL,
	[Municipio] [nvarchar](100) NOT NULL,
	[Ciudad] [nvarchar](100) NOT NULL,
	[Estado] [nvarchar](100) NOT NULL,
	[CodigoPostal] [nvarchar](10) NOT NULL,
	[Latitud] [nvarchar](20) NOT NULL,
	[Longitud] [nvarchar](20) NOT NULL,
	[EstatusTienda] [nvarchar](20) NOT NULL,
	[Estatus] [int] NOT NULL,
	[FechaAlta] [datetime] NOT NULL,
	[FechaModifico] [datetime] NULL,
	[IdUsuarioAlta] [int] NOT NULL,
	[IdUsuarioModifico] [int] NULL,
 CONSTRAINT [PK_dbo.Tienda] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 16/05/2017 08:01:23 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NombreUsuario] [nvarchar](100) NOT NULL,
	[IdRolUsuario] [int] NOT NULL,
	[HashedContraseña] [nvarchar](300) NOT NULL,
	[Salt] [nvarchar](300) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[PrimerApellido] [nvarchar](100) NOT NULL,
	[SegundoApellido] [nvarchar](100) NOT NULL,
	[Sexo] [int] NOT NULL,
	[Calle] [nvarchar](100) NOT NULL,
	[NumeroExterior] [nvarchar](10) NOT NULL,
	[NumeroInterior] [nvarchar](10) NOT NULL,
	[Colonia] [nvarchar](100) NOT NULL,
	[CodigoPostal] [nvarchar](10) NOT NULL,
	[IdPais] [int] NOT NULL,
	[IdEstado] [int] NOT NULL,
	[IdMunicipio] [int] NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[TelefonoOficina] [nvarchar](20) NOT NULL,
	[Extension] [nvarchar](10) NOT NULL,
	[TelefonoCasa] [nvarchar](20) NOT NULL,
	[TelefonoCelular] [nvarchar](20) NOT NULL,
	[IdZona] [int] NOT NULL,
	[IdPlaza] [int] NOT NULL,
	[IdGerencia] [int] NOT NULL,
	[IdEstatus] [int] NOT NULL,
	[FechaAlta] [datetime] NOT NULL,
	[FechaModifico] [datetime] NULL,
	[IdUsuarioAlta] [int] NOT NULL,
	[IdUsuarioModifico] [int] NULL,
 CONSTRAINT [PK_dbo.Usuario] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UsuarioRol]    Script Date: 16/05/2017 08:01:23 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioRol](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[RolId] [int] NOT NULL,
	[FechaAlta] [datetime] NOT NULL,
	[FechaModifico] [datetime] NULL,
	[IdUsuarioAlta] [int] NOT NULL,
	[IdUsuarioModifico] [int] NULL,
 CONSTRAINT [PK_dbo.UsuarioRol] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[DetalleModuloPermiso]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DetalleModuloPermiso_dbo.Modulo_Modulo_ID] FOREIGN KEY([Modulo_ID])
REFERENCES [dbo].[Modulo] ([ID])
GO
ALTER TABLE [dbo].[DetalleModuloPermiso] CHECK CONSTRAINT [FK_dbo.DetalleModuloPermiso_dbo.Modulo_Modulo_ID]
GO
ALTER TABLE [dbo].[DetalleModuloPermiso]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DetalleModuloPermiso_dbo.Permiso_Permiso_ID] FOREIGN KEY([Permiso_ID])
REFERENCES [dbo].[Permiso] ([ID])
GO
ALTER TABLE [dbo].[DetalleModuloPermiso] CHECK CONSTRAINT [FK_dbo.DetalleModuloPermiso_dbo.Permiso_Permiso_ID]
GO
ALTER TABLE [dbo].[DetalleRolPermiso]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DetalleRolPermiso_dbo.DetalleModuloPermiso_DetalleModuloPermiso_ID] FOREIGN KEY([DetalleModuloPermiso_ID])
REFERENCES [dbo].[DetalleModuloPermiso] ([ID])
GO
ALTER TABLE [dbo].[DetalleRolPermiso] CHECK CONSTRAINT [FK_dbo.DetalleRolPermiso_dbo.DetalleModuloPermiso_DetalleModuloPermiso_ID]
GO
ALTER TABLE [dbo].[DetalleRolPermiso]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DetalleRolPermiso_dbo.Rol_Rol_ID] FOREIGN KEY([Rol_ID])
REFERENCES [dbo].[Rol] ([ID])
GO
ALTER TABLE [dbo].[DetalleRolPermiso] CHECK CONSTRAINT [FK_dbo.DetalleRolPermiso_dbo.Rol_Rol_ID]
GO
ALTER TABLE [dbo].[Distrito]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Distrito_dbo.PlazaOxxo_DistritoId] FOREIGN KEY([DistritoId])
REFERENCES [dbo].[PlazaOxxo] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Distrito] CHECK CONSTRAINT [FK_dbo.Distrito_dbo.PlazaOxxo_DistritoId]
GO
ALTER TABLE [dbo].[Municipio]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Municipio_dbo.Estado_EstadoId] FOREIGN KEY([EstadoId])
REFERENCES [dbo].[Estado] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Municipio] CHECK CONSTRAINT [FK_dbo.Municipio_dbo.Estado_EstadoId]
GO
ALTER TABLE [dbo].[PlazaImmex]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PlazaImmex_dbo.Region_RegionId] FOREIGN KEY([RegionId])
REFERENCES [dbo].[Region] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PlazaImmex] CHECK CONSTRAINT [FK_dbo.PlazaImmex_dbo.Region_RegionId]
GO
ALTER TABLE [dbo].[PlazaOxxo]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PlazaOxxo_dbo.PlazaImmex_PlazaImmexId] FOREIGN KEY([PlazaImmexId])
REFERENCES [dbo].[PlazaImmex] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PlazaOxxo] CHECK CONSTRAINT [FK_dbo.PlazaOxxo_dbo.PlazaImmex_PlazaImmexId]
GO
ALTER TABLE [dbo].[Tienda]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Tienda_dbo.Distrito_DistritoId] FOREIGN KEY([DistritoId])
REFERENCES [dbo].[Distrito] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tienda] CHECK CONSTRAINT [FK_dbo.Tienda_dbo.Distrito_DistritoId]
GO
ALTER TABLE [dbo].[UsuarioRol]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UsuarioRol_dbo.Rol_RolId] FOREIGN KEY([RolId])
REFERENCES [dbo].[Rol] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UsuarioRol] CHECK CONSTRAINT [FK_dbo.UsuarioRol_dbo.Rol_RolId]
GO
ALTER TABLE [dbo].[UsuarioRol]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UsuarioRol_dbo.Usuario_UsuarioId] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UsuarioRol] CHECK CONSTRAINT [FK_dbo.UsuarioRol_dbo.Usuario_UsuarioId]
GO
