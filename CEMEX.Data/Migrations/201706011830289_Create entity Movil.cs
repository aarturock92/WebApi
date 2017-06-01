namespace CEMEX.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateentityMovil : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Distrito", newName: "Distritos");
            RenameTable(name: "dbo.Tienda", newName: "Tiendas");
            RenameTable(name: "dbo.PlazaImmex", newName: "PlazasImmex");
            RenameTable(name: "dbo.PlazaOxxo", newName: "PlazasOxxo");
            RenameTable(name: "dbo.Region", newName: "Regiones");
            MoveTable(name: "dbo.Distritos", newSchema: "Catalogo");
            MoveTable(name: "dbo.Tiendas", newSchema: "Catalogo");
            MoveTable(name: "dbo.PlazasImmex", newSchema: "Catalogo");
            MoveTable(name: "dbo.PlazasOxxo", newSchema: "Catalogo");
            MoveTable(name: "dbo.Regiones", newSchema: "Catalogo");
            CreateTable(
                "Catalogo.Moviles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IdPlazaImmex = c.Int(nullable: false),
                        IdMovil = c.Int(nullable: false),
                        Marca = c.String(nullable: false, maxLength: 100),
                        Modelo = c.String(nullable: false, maxLength: 100),
                        NumeroTelefono = c.String(nullable: false, maxLength: 100),
                        NumeroSerie = c.String(nullable: false, maxLength: 100),
                        IMEI = c.String(nullable: false, maxLength: 100),
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
            DropTable("Catalogo.Moviles");
            MoveTable(name: "Catalogo.Regiones", newSchema: "dbo");
            MoveTable(name: "Catalogo.PlazasOxxo", newSchema: "dbo");
            MoveTable(name: "Catalogo.PlazasImmex", newSchema: "dbo");
            MoveTable(name: "Catalogo.Tiendas", newSchema: "dbo");
            MoveTable(name: "Catalogo.Distritos", newSchema: "dbo");
            RenameTable(name: "dbo.Regiones", newName: "Region");
            RenameTable(name: "dbo.PlazasOxxo", newName: "PlazaOxxo");
            RenameTable(name: "dbo.PlazasImmex", newName: "PlazaImmex");
            RenameTable(name: "dbo.Tiendas", newName: "Tienda");
            RenameTable(name: "dbo.Distritos", newName: "Distrito");
        }
    }
}
