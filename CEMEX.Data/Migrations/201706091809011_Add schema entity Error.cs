namespace CEMEX.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddschemaentityError : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "dbo.Error", newSchema: "Aplicacion");
        }
        
        public override void Down()
        {
            MoveTable(name: "Aplicacion.Error", newSchema: "dbo");
        }
    }
}
