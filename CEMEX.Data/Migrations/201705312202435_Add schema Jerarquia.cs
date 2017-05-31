namespace CEMEX.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddschemaJerarquia : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Jerarquia", newName: "Jerarquias");
            MoveTable(name: "dbo.Jerarquias", newSchema: "Seguridad");
            CreateTable(
                "Seguridad.PerfilesUsuario",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        IdJerarquia = c.Int(nullable: false),
                        AsignacionMultiple = c.Boolean(nullable: false),
                        Estatus = c.Int(nullable: false),
                        FechaAlta = c.DateTime(nullable: false),
                        FechaModifico = c.DateTime(nullable: false),
                        IdUsuarioAlta = c.Int(nullable: false),
                        IdUsuarioModifico = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("Seguridad.Usuarios", "IdPerfilUsuario", c => c.Int(nullable: false));
            AddColumn("Seguridad.Usuarios", "NumeroEmpleado", c => c.String());
            AddColumn("Seguridad.Usuarios", "Telefono", c => c.String(nullable: false, maxLength: 20));
            AddColumn("Seguridad.Usuarios", "Curp", c => c.String(nullable: false, maxLength: 50));
            AddColumn("Seguridad.Usuarios", "RFC", c => c.String(nullable: false, maxLength: 50));
            AddColumn("Seguridad.Usuarios", "FechaNacimiento", c => c.String(nullable: false, maxLength: 50));
            AddColumn("Seguridad.Usuarios", "Imagen", c => c.String(maxLength: 400));
            DropColumn("Seguridad.Usuarios", "IdRolUsuario");
            DropColumn("Seguridad.Usuarios", "NumeroInterior");
            DropColumn("Seguridad.Usuarios", "TelefonoOficina");
            DropColumn("Seguridad.Usuarios", "Extension");
            DropColumn("Seguridad.Usuarios", "TelefonoCasa");
            DropColumn("Seguridad.Usuarios", "TelefonoCelular");
            DropColumn("Seguridad.Usuarios", "IdZona");
            DropColumn("Seguridad.Usuarios", "IdPlaza");
            DropColumn("Seguridad.Usuarios", "IdGerencia");
        }
        
        public override void Down()
        {
            AddColumn("Seguridad.Usuarios", "IdGerencia", c => c.Int(nullable: false));
            AddColumn("Seguridad.Usuarios", "IdPlaza", c => c.Int(nullable: false));
            AddColumn("Seguridad.Usuarios", "IdZona", c => c.Int(nullable: false));
            AddColumn("Seguridad.Usuarios", "TelefonoCelular", c => c.String(nullable: false, maxLength: 20));
            AddColumn("Seguridad.Usuarios", "TelefonoCasa", c => c.String(nullable: false, maxLength: 20));
            AddColumn("Seguridad.Usuarios", "Extension", c => c.String(nullable: false, maxLength: 10));
            AddColumn("Seguridad.Usuarios", "TelefonoOficina", c => c.String(nullable: false, maxLength: 20));
            AddColumn("Seguridad.Usuarios", "NumeroInterior", c => c.String(nullable: false, maxLength: 10));
            AddColumn("Seguridad.Usuarios", "IdRolUsuario", c => c.Int(nullable: false));
            DropColumn("Seguridad.Usuarios", "Imagen");
            DropColumn("Seguridad.Usuarios", "FechaNacimiento");
            DropColumn("Seguridad.Usuarios", "RFC");
            DropColumn("Seguridad.Usuarios", "Curp");
            DropColumn("Seguridad.Usuarios", "Telefono");
            DropColumn("Seguridad.Usuarios", "NumeroEmpleado");
            DropColumn("Seguridad.Usuarios", "IdPerfilUsuario");
            DropTable("Seguridad.PerfilesUsuario");
            MoveTable(name: "Seguridad.Jerarquias", newSchema: "dbo");
            RenameTable(name: "dbo.Jerarquias", newName: "Jerarquia");
        }
    }
}
