namespace CEMEX.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addregisterbydefault : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Seguridad.DetalleMenuPermiso", "Permiso_ID", "Seguridad.Permisos");
            DropIndex("Seguridad.DetalleMenuPermiso", new[] { "Permiso_ID" });
            DropColumn("Seguridad.DetalleMenuPermiso", "Permiso_ID");
        }
        
        public override void Down()
        {
            AddColumn("Seguridad.DetalleMenuPermiso", "Permiso_ID", c => c.Int());
            CreateIndex("Seguridad.DetalleMenuPermiso", "Permiso_ID");
            AddForeignKey("Seguridad.DetalleMenuPermiso", "Permiso_ID", "Seguridad.Permisos", "ID");
        }
    }
}
