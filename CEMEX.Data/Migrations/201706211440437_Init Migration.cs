namespace CEMEX.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Seguridad.DetalleMenuPermiso",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IdModulo = c.Int(nullable: false),
                        IdPermiso = c.Int(nullable: false),
                        IdEstatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "Seguridad.DetallePerfilUsuarioMenu",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MenuId = c.Int(nullable: false),
                        IdEstatus = c.Int(nullable: false),
                        PefilUsuarioId = c.Int(nullable: false),
                        FechaAlta = c.DateTime(nullable: false),
                        FechaModifico = c.DateTime(nullable: false),
                        IdUsuarioAlta = c.Int(nullable: false),
                        IdUsuarioModifico = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Seguridad.PerfilesUsuario", t => t.PefilUsuarioId, cascadeDelete: true)
                .Index(t => t.PefilUsuarioId);
            
            CreateTable(
                "Seguridad.DetalleUsuarioAsignacion",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UsuarioId = c.Int(nullable: false),
                        ReferenciaId = c.Int(nullable: false),
                        IdEstatus = c.Int(nullable: false),
                        FechaAlta = c.DateTime(nullable: false),
                        FechaModifico = c.DateTime(nullable: false),
                        IdUsuarioAlta = c.Int(nullable: false),
                        IdUsuarioModifico = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Seguridad.Usuarios", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "Catalogo.Distritos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PlazaOxxoId = c.Int(nullable: false),
                        ClaveDistrito = c.String(nullable: false, maxLength: 50),
                        NombreDistrito = c.String(nullable: false, maxLength: 100),
                        Estatus = c.Int(nullable: false),
                        FechaAlta = c.DateTime(nullable: false),
                        FechaModifico = c.DateTime(),
                        IdUsuarioAlta = c.Int(nullable: false),
                        IdUsuarioModifico = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Catalogo.PlazasOxxo", t => t.PlazaOxxoId, cascadeDelete: true)
                .Index(t => t.PlazaOxxoId);
            
            CreateTable(
                "Catalogo.Tiendas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DistritoId = c.Int(nullable: false),
                        UniqueTienda = c.Guid(nullable: false),
                        CRTienda = c.String(nullable: false, maxLength: 50),
                        NombreTienda = c.String(nullable: false, maxLength: 100),
                        Calle = c.String(nullable: false, maxLength: 150),
                        Numero = c.String(nullable: false, maxLength: 20),
                        EntreCalles = c.String(nullable: false, maxLength: 150),
                        Colonia = c.String(nullable: false, maxLength: 100),
                        Municipio = c.String(nullable: false, maxLength: 100),
                        Ciudad = c.String(nullable: false, maxLength: 100),
                        Estado = c.String(nullable: false, maxLength: 100),
                        CodigoPostal = c.String(nullable: false, maxLength: 10),
                        Latitud = c.String(nullable: false, maxLength: 20),
                        Longitud = c.String(nullable: false, maxLength: 20),
                        EstatusTienda = c.String(nullable: false, maxLength: 20),
                        Estatus = c.Int(nullable: false),
                        FechaAlta = c.DateTime(nullable: false),
                        FechaModifico = c.DateTime(),
                        IdUsuarioAlta = c.Int(nullable: false),
                        IdUsuarioModifico = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Catalogo.Distritos", t => t.DistritoId, cascadeDelete: true)
                .Index(t => t.DistritoId);
            
            CreateTable(
                "Aplicacion.Error",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        StackTrace = c.String(),
                        FechaAlta = c.DateTime(nullable: false),
                        FechaModifico = c.DateTime(nullable: false),
                        IdUsuarioAlta = c.Int(nullable: false),
                        IdUsuarioModifico = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "Catalogo.Estados",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Abreviatura = c.String(nullable: false, maxLength: 50),
                        Estatus = c.Int(nullable: false),
                        FechaAlta = c.DateTime(nullable: false),
                        FechaModifico = c.DateTime(),
                        IdUsuarioAlta = c.Int(nullable: false),
                        IdUsuarioModifico = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "Catalogo.Municipios",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Estatus = c.Int(nullable: false),
                        EstadoId = c.Int(nullable: false),
                        FechaAlta = c.DateTime(nullable: false),
                        FechaModifico = c.DateTime(),
                        IdUsuarioAlta = c.Int(nullable: false),
                        IdUsuarioModifico = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Catalogo.Estados", t => t.EstadoId, cascadeDelete: true)
                .Index(t => t.EstadoId);
            
            CreateTable(
                "Seguridad.Jerarquias",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NivelJerarquia = c.Int(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Descripcion = c.String(nullable: false, maxLength: 200),
                        Estatus = c.Int(nullable: false),
                        FechaAlta = c.DateTime(nullable: false),
                        FechaModifico = c.DateTime(),
                        IdUsuarioAlta = c.Int(nullable: false),
                        IdUsuarioModifico = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "Seguridad.PerfilesUsuario",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Descripcion = c.String(nullable: false, maxLength: 200),
                        JerarquiaId = c.Int(nullable: false),
                        AsignacionMultiple = c.Boolean(nullable: false),
                        Estatus = c.Int(nullable: false),
                        FechaAlta = c.DateTime(nullable: false),
                        FechaModifico = c.DateTime(),
                        IdUsuarioAlta = c.Int(nullable: false),
                        IdUsuarioModifico = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Seguridad.Jerarquias", t => t.JerarquiaId, cascadeDelete: true)
                .Index(t => t.JerarquiaId);
            
            CreateTable(
                "Seguridad.Usuarios",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PerfilUsuarioId = c.Int(nullable: false),
                        NumeroEmpleado = c.String(),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        PrimerApellido = c.String(nullable: false, maxLength: 100),
                        SegundoApellido = c.String(nullable: false, maxLength: 100),
                        Sexo = c.Int(nullable: false),
                        Telefono = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false, maxLength: 100),
                        Curp = c.String(nullable: false, maxLength: 50),
                        RFC = c.String(nullable: false, maxLength: 50),
                        FechaNacimiento = c.String(nullable: false, maxLength: 50),
                        NombreUsuario = c.String(nullable: false, maxLength: 100),
                        HashedContraseña = c.String(nullable: false, maxLength: 300),
                        Salt = c.String(nullable: false, maxLength: 300),
                        Calle = c.String(nullable: false, maxLength: 100),
                        NumeroExterior = c.String(nullable: false, maxLength: 10),
                        Colonia = c.String(nullable: false, maxLength: 100),
                        CodigoPostal = c.String(nullable: false, maxLength: 10),
                        IdPais = c.Int(nullable: false),
                        IdEstado = c.Int(nullable: false),
                        IdMunicipio = c.Int(nullable: false),
                        Imagen = c.String(maxLength: 400),
                        IdEstatus = c.Int(nullable: false),
                        FechaAlta = c.DateTime(nullable: false),
                        FechaModifico = c.DateTime(),
                        IdUsuarioAlta = c.Int(nullable: false),
                        IdUsuarioModifico = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Seguridad.PerfilesUsuario", t => t.PerfilUsuarioId, cascadeDelete: true)
                .Index(t => t.PerfilUsuarioId);
            
            CreateTable(
                "Aplicacion.Menu",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IdMenuPadre = c.Int(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Descripcion = c.String(nullable: false, maxLength: 200),
                        Url = c.String(nullable: false, maxLength: 200),
                        Orden = c.Int(nullable: false),
                        CssClass = c.String(nullable: false, maxLength: 100),
                        IdEstatus = c.Int(nullable: false),
                        FechaAlta = c.DateTime(nullable: false),
                        FechaModifico = c.DateTime(),
                        IdUsuarioAlta = c.Int(nullable: false),
                        IdUsuarioModifico = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "Catalogo.Moviles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RegionId = c.Int(nullable: false),
                        PlazaImmexId = c.Int(nullable: false),
                        Marca = c.String(nullable: false, maxLength: 100),
                        Modelo = c.String(nullable: false, maxLength: 100),
                        NumeroTelefono = c.String(nullable: false, maxLength: 100),
                        NumeroSerie = c.String(nullable: false, maxLength: 100),
                        IMEI = c.String(nullable: false, maxLength: 100),
                        IdEstatus = c.Int(nullable: false),
                        FechaAlta = c.DateTime(nullable: false),
                        FechaModifico = c.DateTime(),
                        IdUsuarioAlta = c.Int(nullable: false),
                        IdUsuarioModifico = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Catalogo.PlazasImmex", t => t.PlazaImmexId, cascadeDelete: true)
                .Index(t => t.PlazaImmexId);
            
            CreateTable(
                "Seguridad.Permisos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Descripcion = c.String(nullable: false, maxLength: 200),
                        Icono = c.String(nullable: false, maxLength: 100),
                        Estatus = c.Int(nullable: false),
                        FechaAlta = c.DateTime(nullable: false),
                        FechaModifico = c.DateTime(),
                        IdUsuarioAlta = c.Int(nullable: false),
                        IdUsuarioModifico = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "Catalogo.PlazasImmex",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RegionId = c.Int(nullable: false),
                        CRPlazaImmex = c.String(nullable: false, maxLength: 50),
                        NombrePlazaImmex = c.String(nullable: false, maxLength: 100),
                        Estatus = c.Int(nullable: false),
                        FechaAlta = c.DateTime(nullable: false),
                        FechaModifico = c.DateTime(),
                        IdUsuarioAlta = c.Int(nullable: false),
                        IdUsuarioModifico = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Catalogo.Regiones", t => t.RegionId, cascadeDelete: true)
                .Index(t => t.RegionId);
            
            CreateTable(
                "Catalogo.PlazasOxxo",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PlazaImmexId = c.Int(nullable: false),
                        CRPlazaOxxo = c.String(nullable: false, maxLength: 50),
                        NombrePlazaOxxo = c.String(nullable: false, maxLength: 100),
                        Estatus = c.Int(nullable: false),
                        FechaAlta = c.DateTime(nullable: false),
                        FechaModifico = c.DateTime(),
                        IdUsuarioAlta = c.Int(nullable: false),
                        IdUsuarioModifico = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Catalogo.PlazasImmex", t => t.PlazaImmexId, cascadeDelete: true)
                .Index(t => t.PlazaImmexId);
            
            CreateTable(
                "Catalogo.Vehiculos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PlazaImmexId = c.Int(nullable: false),
                        UniqueVehiculo = c.Guid(nullable: false),
                        Marca = c.String(nullable: false, maxLength: 150),
                        Modelo = c.String(nullable: false, maxLength: 150),
                        NumeroPlaca = c.String(nullable: false, maxLength: 100),
                        NumeroEconomico = c.String(nullable: false, maxLength: 100),
                        IdEstatus = c.Int(nullable: false),
                        FechaAlta = c.DateTime(nullable: false),
                        FechaModifico = c.DateTime(nullable: false),
                        IdUsuarioAlta = c.Int(nullable: false),
                        IdUsuarioModifico = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Catalogo.PlazasImmex", t => t.PlazaImmexId, cascadeDelete: true)
                .Index(t => t.PlazaImmexId);
            
            CreateTable(
                "Catalogo.Regiones",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IdNegocio = c.Int(nullable: false),
                        ClaveRegion = c.String(nullable: false, maxLength: 50),
                        NombreRegion = c.String(nullable: false, maxLength: 100),
                        Estatus = c.Int(nullable: false),
                        FechaAlta = c.DateTime(nullable: false),
                        FechaModifico = c.DateTime(),
                        IdUsuarioAlta = c.Int(nullable: false),
                        IdUsuarioModifico = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Catalogo.PlazasImmex", "RegionId", "Catalogo.Regiones");
            DropForeignKey("Catalogo.Vehiculos", "PlazaImmexId", "Catalogo.PlazasImmex");
            DropForeignKey("Catalogo.PlazasOxxo", "PlazaImmexId", "Catalogo.PlazasImmex");
            DropForeignKey("Catalogo.Distritos", "PlazaOxxoId", "Catalogo.PlazasOxxo");
            DropForeignKey("Catalogo.Moviles", "PlazaImmexId", "Catalogo.PlazasImmex");
            DropForeignKey("Seguridad.PerfilesUsuario", "JerarquiaId", "Seguridad.Jerarquias");
            DropForeignKey("Seguridad.Usuarios", "PerfilUsuarioId", "Seguridad.PerfilesUsuario");
            DropForeignKey("Seguridad.DetalleUsuarioAsignacion", "UsuarioId", "Seguridad.Usuarios");
            DropForeignKey("Seguridad.DetallePerfilUsuarioMenu", "PefilUsuarioId", "Seguridad.PerfilesUsuario");
            DropForeignKey("Catalogo.Municipios", "EstadoId", "Catalogo.Estados");
            DropForeignKey("Catalogo.Tiendas", "DistritoId", "Catalogo.Distritos");
            DropIndex("Catalogo.Vehiculos", new[] { "PlazaImmexId" });
            DropIndex("Catalogo.PlazasOxxo", new[] { "PlazaImmexId" });
            DropIndex("Catalogo.PlazasImmex", new[] { "RegionId" });
            DropIndex("Catalogo.Moviles", new[] { "PlazaImmexId" });
            DropIndex("Seguridad.Usuarios", new[] { "PerfilUsuarioId" });
            DropIndex("Seguridad.PerfilesUsuario", new[] { "JerarquiaId" });
            DropIndex("Catalogo.Municipios", new[] { "EstadoId" });
            DropIndex("Catalogo.Tiendas", new[] { "DistritoId" });
            DropIndex("Catalogo.Distritos", new[] { "PlazaOxxoId" });
            DropIndex("Seguridad.DetalleUsuarioAsignacion", new[] { "UsuarioId" });
            DropIndex("Seguridad.DetallePerfilUsuarioMenu", new[] { "PefilUsuarioId" });
            DropTable("Catalogo.Regiones");
            DropTable("Catalogo.Vehiculos");
            DropTable("Catalogo.PlazasOxxo");
            DropTable("Catalogo.PlazasImmex");
            DropTable("Seguridad.Permisos");
            DropTable("Catalogo.Moviles");
            DropTable("Aplicacion.Menu");
            DropTable("Seguridad.Usuarios");
            DropTable("Seguridad.PerfilesUsuario");
            DropTable("Seguridad.Jerarquias");
            DropTable("Catalogo.Municipios");
            DropTable("Catalogo.Estados");
            DropTable("Aplicacion.Error");
            DropTable("Catalogo.Tiendas");
            DropTable("Catalogo.Distritos");
            DropTable("Seguridad.DetalleUsuarioAsignacion");
            DropTable("Seguridad.DetallePerfilUsuarioMenu");
            DropTable("Seguridad.DetalleMenuPermiso");
        }
    }
}
