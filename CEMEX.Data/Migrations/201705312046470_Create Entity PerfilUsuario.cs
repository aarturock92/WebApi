namespace CEMEX.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateEntityPerfilUsuario : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Estado", newName: "CAT_ESTADOS");
            RenameTable(name: "dbo.Municipio", newName: "CAT_MUNICIPIOS");
            AddColumn("dbo.Jerarquia", "NivelJerarquia", c => c.Int(nullable: false));
            DropColumn("dbo.Jerarquia", "IdJerarquiaPadre");
            DropColumn("dbo.Jerarquia", "NivelEstructura");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jerarquia", "NivelEstructura", c => c.Int(nullable: false));
            AddColumn("dbo.Jerarquia", "IdJerarquiaPadre", c => c.Int(nullable: false));
            DropColumn("dbo.Jerarquia", "NivelJerarquia");
            RenameTable(name: "dbo.CAT_MUNICIPIOS", newName: "Municipio");
            RenameTable(name: "dbo.CAT_ESTADOS", newName: "Estado");
        }
    }
}
