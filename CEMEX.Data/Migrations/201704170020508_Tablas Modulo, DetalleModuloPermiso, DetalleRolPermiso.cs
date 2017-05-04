namespace CEMEX.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TablasModuloDetalleModuloPermisoDetalleRolPermiso : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DetalleModuloPermiso",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IdModulo = c.Int(nullable: false),
                        IdPermiso = c.Int(nullable: false),
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
                        IdRol = c.Int(nullable: false),
                        IdDetalleModuloPermiso = c.Int(nullable: false),
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
            
            AddColumn("dbo.Rol", "IdJerarquia", c => c.Int(nullable: false));
            AddColumn("dbo.Rol", "Descripcion", c => c.String(nullable: false, maxLength: 200));
            AddColumn("dbo.Rol", "AsignacionMultiple", c => c.Int(nullable: false));
            AddColumn("dbo.Rol", "Estatus", c => c.Int(nullable: false));
            AlterColumn("dbo.Permiso", "Nombre", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Permiso", "Descripcion", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Permiso", "Icono", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Permiso", "FechaModifico", c => c.DateTime());
            AlterColumn("dbo.Permiso", "IdUsuarioModifico", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Permiso", "IdUsuarioModifico", c => c.Int(nullable: false));
            AlterColumn("dbo.Permiso", "FechaModifico", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Permiso", "Icono", c => c.String());
            AlterColumn("dbo.Permiso", "Descripcion", c => c.String());
            AlterColumn("dbo.Permiso", "Nombre", c => c.String());
            DropColumn("dbo.Rol", "Estatus");
            DropColumn("dbo.Rol", "AsignacionMultiple");
            DropColumn("dbo.Rol", "Descripcion");
            DropColumn("dbo.Rol", "IdJerarquia");
            DropTable("dbo.Modulo");
            DropTable("dbo.DetalleRolPermiso");
            DropTable("dbo.DetalleModuloPermiso");
        }
    }
}
