namespace CEMEX.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddschemaentitiesPermisosDetalleMenuPermiso : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Permiso", newName: "Permisos");
            MoveTable(name: "dbo.DetalleMenuPermiso", newSchema: "Seguridad");
            MoveTable(name: "dbo.Permisos", newSchema: "Seguridad");
        }
        
        public override void Down()
        {
            MoveTable(name: "Seguridad.Permisos", newSchema: "dbo");
            MoveTable(name: "Seguridad.DetalleMenuPermiso", newSchema: "dbo");
            RenameTable(name: "dbo.Permisos", newName: "Permiso");
        }
    }
}
