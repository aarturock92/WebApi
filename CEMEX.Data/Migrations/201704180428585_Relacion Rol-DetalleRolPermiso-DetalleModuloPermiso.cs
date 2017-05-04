namespace CEMEX.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelacionRolDetalleRolPermisoDetalleModuloPermiso : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DetalleRolPermiso", "DetalleModuloPermiso_ID", c => c.Int());
            AddColumn("dbo.DetalleRolPermiso", "Rol_ID", c => c.Int());
            CreateIndex("dbo.DetalleRolPermiso", "DetalleModuloPermiso_ID");
            CreateIndex("dbo.DetalleRolPermiso", "Rol_ID");
            AddForeignKey("dbo.DetalleRolPermiso", "DetalleModuloPermiso_ID", "dbo.DetalleModuloPermiso", "ID");
            AddForeignKey("dbo.DetalleRolPermiso", "Rol_ID", "dbo.Rol", "ID");
            DropColumn("dbo.DetalleRolPermiso", "IdDetalleModuloPermiso");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DetalleRolPermiso", "IdDetalleModuloPermiso", c => c.Int(nullable: false));
            DropForeignKey("dbo.DetalleRolPermiso", "Rol_ID", "dbo.Rol");
            DropForeignKey("dbo.DetalleRolPermiso", "DetalleModuloPermiso_ID", "dbo.DetalleModuloPermiso");
            DropIndex("dbo.DetalleRolPermiso", new[] { "Rol_ID" });
            DropIndex("dbo.DetalleRolPermiso", new[] { "DetalleModuloPermiso_ID" });
            DropColumn("dbo.DetalleRolPermiso", "Rol_ID");
            DropColumn("dbo.DetalleRolPermiso", "DetalleModuloPermiso_ID");
        }
    }
}
