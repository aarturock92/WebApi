namespace CEMEX.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DetalleModuloPermiso", "Permiso_ID", "dbo.Permiso");
            DropForeignKey("dbo.DetalleRolPermiso", "DetalleModuloPermiso_ID", "dbo.DetalleModuloPermiso");
            DropForeignKey("dbo.DetalleRolPermiso", "Rol_ID", "dbo.Rol");
            DropForeignKey("dbo.DetalleModuloPermiso", "Modulo_ID", "dbo.Modulo");
            DropForeignKey("dbo.UsuarioRol", "RolId", "dbo.Rol");
            DropForeignKey("dbo.UsuarioRol", "UsuarioId", "Seguridad.Usuarios");
            DropIndex("dbo.DetalleModuloPermiso", new[] { "Permiso_ID" });
            DropIndex("dbo.DetalleModuloPermiso", new[] { "Modulo_ID" });
            DropIndex("dbo.DetalleRolPermiso", new[] { "DetalleModuloPermiso_ID" });
            DropIndex("dbo.DetalleRolPermiso", new[] { "Rol_ID" });
            DropIndex("dbo.UsuarioRol", new[] { "UsuarioId" });
            DropIndex("dbo.UsuarioRol", new[] { "RolId" });
            CreateTable(
                "dbo.DetalleMenuPermiso",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IdModulo = c.Int(nullable: false),
                        IdPermiso = c.Int(nullable: false),
                        IdEstatus = c.Int(nullable: false),
                        Permiso_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Permiso", t => t.Permiso_ID)
                .Index(t => t.Permiso_ID);
            
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
            
            AddColumn("Seguridad.Usuarios", "PerfilUsuarioId", c => c.Int(nullable: false));
            AddColumn("Seguridad.PerfilesUsuario", "JerarquiaId", c => c.Int(nullable: false));
            CreateIndex("Seguridad.PerfilesUsuario", "JerarquiaId");
            CreateIndex("Seguridad.Usuarios", "PerfilUsuarioId");
            AddForeignKey("Seguridad.Usuarios", "PerfilUsuarioId", "Seguridad.PerfilesUsuario", "ID", cascadeDelete: true);
            AddForeignKey("Seguridad.PerfilesUsuario", "JerarquiaId", "Seguridad.Jerarquias", "ID", cascadeDelete: true);
            DropColumn("Seguridad.Usuarios", "IdPerfilUsuario");
            DropColumn("Seguridad.PerfilesUsuario", "IdJerarquia");
            DropTable("dbo.DetalleModuloPermiso");
            DropTable("dbo.DetalleRolPermiso");
            DropTable("dbo.Rol");
            DropTable("dbo.Modulo");
            DropTable("dbo.UsuarioRol");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.ID);
            
            AddColumn("Seguridad.PerfilesUsuario", "IdJerarquia", c => c.Int(nullable: false));
            AddColumn("Seguridad.Usuarios", "IdPerfilUsuario", c => c.Int(nullable: false));
            DropForeignKey("Seguridad.PerfilesUsuario", "JerarquiaId", "Seguridad.Jerarquias");
            DropForeignKey("Seguridad.Usuarios", "PerfilUsuarioId", "Seguridad.PerfilesUsuario");
            DropForeignKey("dbo.DetalleMenuPermiso", "Permiso_ID", "dbo.Permiso");
            DropIndex("Seguridad.Usuarios", new[] { "PerfilUsuarioId" });
            DropIndex("Seguridad.PerfilesUsuario", new[] { "JerarquiaId" });
            DropIndex("dbo.DetalleMenuPermiso", new[] { "Permiso_ID" });
            DropColumn("Seguridad.PerfilesUsuario", "JerarquiaId");
            DropColumn("Seguridad.Usuarios", "PerfilUsuarioId");
            DropTable("Aplicacion.Menu");
            DropTable("dbo.DetalleMenuPermiso");
            CreateIndex("dbo.UsuarioRol", "RolId");
            CreateIndex("dbo.UsuarioRol", "UsuarioId");
            CreateIndex("dbo.DetalleRolPermiso", "Rol_ID");
            CreateIndex("dbo.DetalleRolPermiso", "DetalleModuloPermiso_ID");
            CreateIndex("dbo.DetalleModuloPermiso", "Modulo_ID");
            CreateIndex("dbo.DetalleModuloPermiso", "Permiso_ID");
            AddForeignKey("dbo.UsuarioRol", "UsuarioId", "Seguridad.Usuarios", "ID", cascadeDelete: true);
            AddForeignKey("dbo.UsuarioRol", "RolId", "dbo.Rol", "ID", cascadeDelete: true);
            AddForeignKey("dbo.DetalleModuloPermiso", "Modulo_ID", "dbo.Modulo", "ID");
            AddForeignKey("dbo.DetalleRolPermiso", "Rol_ID", "dbo.Rol", "ID");
            AddForeignKey("dbo.DetalleRolPermiso", "DetalleModuloPermiso_ID", "dbo.DetalleModuloPermiso", "ID");
            AddForeignKey("dbo.DetalleModuloPermiso", "Permiso_ID", "dbo.Permiso", "ID");
        }
    }
}
