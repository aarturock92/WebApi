namespace CEMEX.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addschemaandconfigurenametable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CAT_ESTADOS", newName: "Estados");
            RenameTable(name: "dbo.CAT_MUNICIPIOS", newName: "Municipios");
            RenameTable(name: "dbo.Usuario", newName: "Usuarios");
            MoveTable(name: "dbo.Estados", newSchema: "Catalogo");
            MoveTable(name: "dbo.Municipios", newSchema: "Catalogo");
            MoveTable(name: "dbo.Usuarios", newSchema: "Seguridad");
        }
        
        public override void Down()
        {
            MoveTable(name: "Seguridad.Usuarios", newSchema: "dbo");
            MoveTable(name: "Catalogo.Municipios", newSchema: "dbo");
            MoveTable(name: "Catalogo.Estados", newSchema: "dbo");
            RenameTable(name: "dbo.Usuarios", newName: "Usuario");
            RenameTable(name: "dbo.Municipios", newName: "CAT_MUNICIPIOS");
            RenameTable(name: "dbo.Estados", newName: "CAT_ESTADOS");
        }
    }
}
