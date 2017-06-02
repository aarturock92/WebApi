namespace CEMEX.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateentityMovil : DbMigration
    {
        public override void Up()
        {
            AddColumn("Catalogo.Moviles", "IdRegion", c => c.Int(nullable: false));
            DropColumn("Catalogo.Moviles", "IdMovil");
        }
        
        public override void Down()
        {
            AddColumn("Catalogo.Moviles", "IdMovil", c => c.Int(nullable: false));
            DropColumn("Catalogo.Moviles", "IdRegion");
        }
    }
}
