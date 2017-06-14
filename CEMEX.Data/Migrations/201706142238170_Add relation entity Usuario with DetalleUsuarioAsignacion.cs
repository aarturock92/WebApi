namespace CEMEX.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddrelationentityUsuariowithDetalleUsuarioAsignacion : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("Seguridad.DetalleUsuarioAsignacion", "UsuarioId", "Seguridad.Usuarios");
            DropIndex("Seguridad.DetalleUsuarioAsignacion", new[] { "UsuarioId" });
            DropTable("Seguridad.DetalleUsuarioAsignacion");
        }
    }
}
