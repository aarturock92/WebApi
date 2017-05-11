namespace CEMEX.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActividadPGV",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 100),
                        Estatus = c.Int(nullable: false),
                        FechaAlta = c.DateTime(nullable: false),
                        FechaModifico = c.DateTime(),
                        IdUsuarioAlta = c.Int(nullable: false),
                        IdUsuarioModifico = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Campania",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        Estatus = c.Int(nullable: false),
                        FechaAlta = c.DateTime(nullable: false),
                        FechaModifico = c.DateTime(),
                        IdUsuarioAlta = c.Int(nullable: false),
                        IdUsuarioModifico = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DetalleModuloPermiso",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Estatus = c.Int(nullable: false),
                        IdModulo = c.Int(nullable: false),
                        IdPermiso = c.Int(nullable: false),
                        FechaAlta = c.DateTime(nullable: false),
                        FechaModifico = c.DateTime(),
                        IdUsuarioAlta = c.Int(nullable: false),
                        IdUsuarioModifico = c.Int(),
                        Permiso_ID = c.Int(),
                        Modulo_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Permiso", t => t.Permiso_ID)
                .ForeignKey("dbo.Modulo", t => t.Modulo_ID)
                .Index(t => t.Permiso_ID)
                .Index(t => t.Modulo_ID);
            
            CreateTable(
                "dbo.Permiso",
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
                "dbo.DetalleRolPermiso",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Estatus = c.Int(nullable: false),
                        FechaAlta = c.DateTime(nullable: false),
                        FechaModifico = c.DateTime(),
                        IdUsuarioAlta = c.Int(nullable: false),
                        IdUsuarioModifico = c.Int(),
                        DetalleModuloPermiso_ID = c.Int(),
                        Rol_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DetalleModuloPermiso", t => t.DetalleModuloPermiso_ID)
                .ForeignKey("dbo.Rol", t => t.Rol_ID)
                .Index(t => t.DetalleModuloPermiso_ID)
                .Index(t => t.Rol_ID);
            
            CreateTable(
                "dbo.Rol",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IdJerarquia = c.Int(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Descripcion = c.String(nullable: false, maxLength: 200),
                        AsignacionMultiple = c.Int(nullable: false),
                        Estatus = c.Int(nullable: false),
                        FechaAlta = c.DateTime(nullable: false),
                        FechaModifico = c.DateTime(),
                        IdUsuarioAlta = c.Int(nullable: false),
                        IdUsuarioModifico = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Error",
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
                "dbo.Estado",
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
                "dbo.Municipio",
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
                .ForeignKey("dbo.Estado", t => t.EstadoId, cascadeDelete: true)
                .Index(t => t.EstadoId);
            
            CreateTable(
                "dbo.Jerarquia",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Descripcion = c.String(nullable: false, maxLength: 200),
                        IdJerarquiaPadre = c.Int(nullable: false),
                        NivelEstructura = c.Int(nullable: false),
                        Estatus = c.Int(nullable: false),
                        FechaAlta = c.DateTime(nullable: false),
                        FechaModifico = c.DateTime(),
                        IdUsuarioAlta = c.Int(nullable: false),
                        IdUsuarioModifico = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Modulo",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IdRegistroModulo = c.Int(nullable: false),
                        Orden = c.Int(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Descripcion = c.String(nullable: false, maxLength: 200),
                        IconoMenu = c.String(nullable: false, maxLength: 50),
                        Url = c.String(nullable: false, maxLength: 100),
                        Estatus = c.Int(nullable: false),
                        FechaAlta = c.DateTime(nullable: false),
                        FechaModifico = c.DateTime(nullable: false),
                        IdUsuarioAlta = c.Int(nullable: false),
                        IdUsuarioModifico = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TipoProspecto",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 100),
                        Estatus = c.Int(nullable: false),
                        FechaAlta = c.DateTime(nullable: false),
                        FechaModifico = c.DateTime(),
                        IdUsuarioAlta = c.Int(nullable: false),
                        IdUsuarioModifico = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UsuarioRol",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UsuarioId = c.Int(nullable: false),
                        RolId = c.Int(nullable: false),
                        FechaAlta = c.DateTime(nullable: false),
                        FechaModifico = c.DateTime(),
                        IdUsuarioAlta = c.Int(nullable: false),
                        IdUsuarioModifico = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Rol", t => t.RolId, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.UsuarioId)
                .Index(t => t.RolId);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NombreUsuario = c.String(nullable: false, maxLength: 100),
                        IdRolUsuario = c.Int(nullable: false),
                        HashedContraseña = c.String(nullable: false, maxLength: 300),
                        Salt = c.String(nullable: false, maxLength: 300),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        PrimerApellido = c.String(nullable: false, maxLength: 100),
                        SegundoApellido = c.String(nullable: false, maxLength: 100),
                        Sexo = c.Int(nullable: false),
                        Calle = c.String(nullable: false, maxLength: 100),
                        NumeroExterior = c.String(nullable: false, maxLength: 10),
                        NumeroInterior = c.String(nullable: false, maxLength: 10),
                        Colonia = c.String(nullable: false, maxLength: 100),
                        CodigoPostal = c.String(nullable: false, maxLength: 10),
                        IdPais = c.Int(nullable: false),
                        IdEstado = c.Int(nullable: false),
                        IdMunicipio = c.Int(nullable: false),
                        Email = c.String(nullable: false, maxLength: 100),
                        TelefonoOficina = c.String(nullable: false, maxLength: 20),
                        Extension = c.String(nullable: false, maxLength: 10),
                        TelefonoCasa = c.String(nullable: false, maxLength: 20),
                        TelefonoCelular = c.String(nullable: false, maxLength: 20),
                        IdZona = c.Int(nullable: false),
                        IdPlaza = c.Int(nullable: false),
                        IdGerencia = c.Int(nullable: false),
                        IdEstatus = c.Int(nullable: false),
                        FechaAlta = c.DateTime(nullable: false),
                        FechaModifico = c.DateTime(),
                        IdUsuarioAlta = c.Int(nullable: false),
                        IdUsuarioModifico = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsuarioRol", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.UsuarioRol", "RolId", "dbo.Rol");
            DropForeignKey("dbo.DetalleModuloPermiso", "Modulo_ID", "dbo.Modulo");
            DropForeignKey("dbo.Municipio", "EstadoId", "dbo.Estado");
            DropForeignKey("dbo.DetalleRolPermiso", "Rol_ID", "dbo.Rol");
            DropForeignKey("dbo.DetalleRolPermiso", "DetalleModuloPermiso_ID", "dbo.DetalleModuloPermiso");
            DropForeignKey("dbo.DetalleModuloPermiso", "Permiso_ID", "dbo.Permiso");
            DropIndex("dbo.UsuarioRol", new[] { "RolId" });
            DropIndex("dbo.UsuarioRol", new[] { "UsuarioId" });
            DropIndex("dbo.Municipio", new[] { "EstadoId" });
            DropIndex("dbo.DetalleRolPermiso", new[] { "Rol_ID" });
            DropIndex("dbo.DetalleRolPermiso", new[] { "DetalleModuloPermiso_ID" });
            DropIndex("dbo.DetalleModuloPermiso", new[] { "Modulo_ID" });
            DropIndex("dbo.DetalleModuloPermiso", new[] { "Permiso_ID" });
            DropTable("dbo.Usuario");
            DropTable("dbo.UsuarioRol");
            DropTable("dbo.TipoProspecto");
            DropTable("dbo.Modulo");
            DropTable("dbo.Jerarquia");
            DropTable("dbo.Municipio");
            DropTable("dbo.Estado");
            DropTable("dbo.Error");
            DropTable("dbo.Rol");
            DropTable("dbo.DetalleRolPermiso");
            DropTable("dbo.Permiso");
            DropTable("dbo.DetalleModuloPermiso");
            DropTable("dbo.Campania");
            DropTable("dbo.ActividadPGV");
        }
    }
}
