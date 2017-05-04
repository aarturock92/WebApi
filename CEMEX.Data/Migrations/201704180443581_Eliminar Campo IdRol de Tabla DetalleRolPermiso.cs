namespace CEMEX.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EliminarCampoIdRoldeTablaDetalleRolPermiso : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.DetalleRolPermiso", "IdRol");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DetalleRolPermiso", "IdRol", c => c.Int(nullable: false));
        }
    }
}
