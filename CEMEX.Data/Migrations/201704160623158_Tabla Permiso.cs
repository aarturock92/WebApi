namespace CEMEX.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TablaPermiso : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Permiso",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        Icono = c.String(),
                        Estatus = c.Int(nullable: false),
                        FechaAlta = c.DateTime(nullable: false),
                        FechaModifico = c.DateTime(nullable: false),
                        IdUsuarioAlta = c.Int(nullable: false),
                        IdUsuarioModifico = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Permiso");
        }
    }
}
