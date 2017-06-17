namespace CEMEX.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitMigration : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("Catalogo.Vehiculos", "PlazaImmexId", "Catalogo.PlazasImmex");
            DropIndex("Catalogo.Vehiculos", new[] { "PlazaImmexId" });
            DropTable("Catalogo.Vehiculos");
        }
    }
}
