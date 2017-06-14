namespace CEMEX.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangepropertyinentityDistrito : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "Catalogo.Distritos", name: "DistritoId", newName: "PlazaOxxoId");
            RenameIndex(table: "Catalogo.Distritos", name: "IX_DistritoId", newName: "IX_PlazaOxxoId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "Catalogo.Distritos", name: "IX_PlazaOxxoId", newName: "IX_DistritoId");
            RenameColumn(table: "Catalogo.Distritos", name: "PlazaOxxoId", newName: "DistritoId");
        }
    }
}
