namespace CEMEX.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntidadUsuarioUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuario", "NombreUsuario", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Usuario", "IdRolUsuario", c => c.Int(nullable: false));
            AddColumn("dbo.Usuario", "Nombre", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Usuario", "PrimerApellido", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Usuario", "SegundoApellido", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Usuario", "Sexo", c => c.Int(nullable: false));
            AddColumn("dbo.Usuario", "Calle", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Usuario", "NumeroExterior", c => c.String(nullable: false, maxLength: 10));
            AddColumn("dbo.Usuario", "NumeroInterior", c => c.String(nullable: false, maxLength: 10));
            AddColumn("dbo.Usuario", "Colonia", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Usuario", "CodigoPostal", c => c.String(nullable: false, maxLength: 10));
            AddColumn("dbo.Usuario", "IdPais", c => c.Int(nullable: false));
            AddColumn("dbo.Usuario", "IdEstado", c => c.Int(nullable: false));
            AddColumn("dbo.Usuario", "IdMunicipio", c => c.Int(nullable: false));
            AddColumn("dbo.Usuario", "TelefonoOficina", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Usuario", "Extension", c => c.String(nullable: false, maxLength: 10));
            AddColumn("dbo.Usuario", "TelefonoCasa", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Usuario", "TelefonoCelular", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Usuario", "IdZona", c => c.Int(nullable: false));
            AddColumn("dbo.Usuario", "IdPlaza", c => c.Int(nullable: false));
            AddColumn("dbo.Usuario", "IdGerencia", c => c.Int(nullable: false));
            AddColumn("dbo.Usuario", "IdEstatus", c => c.Int(nullable: false));
            AlterColumn("dbo.Usuario", "Email", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Usuario", "HashedContraseña", c => c.String(nullable: false, maxLength: 300));
            AlterColumn("dbo.Usuario", "Salt", c => c.String(nullable: false, maxLength: 300));
            DropColumn("dbo.Usuario", "Username");
            DropColumn("dbo.Usuario", "EstaBloqueado");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuario", "EstaBloqueado", c => c.Boolean(nullable: false));
            AddColumn("dbo.Usuario", "Username", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Usuario", "Salt", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Usuario", "HashedContraseña", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Usuario", "Email", c => c.String(nullable: false, maxLength: 200));
            DropColumn("dbo.Usuario", "IdEstatus");
            DropColumn("dbo.Usuario", "IdGerencia");
            DropColumn("dbo.Usuario", "IdPlaza");
            DropColumn("dbo.Usuario", "IdZona");
            DropColumn("dbo.Usuario", "TelefonoCelular");
            DropColumn("dbo.Usuario", "TelefonoCasa");
            DropColumn("dbo.Usuario", "Extension");
            DropColumn("dbo.Usuario", "TelefonoOficina");
            DropColumn("dbo.Usuario", "IdMunicipio");
            DropColumn("dbo.Usuario", "IdEstado");
            DropColumn("dbo.Usuario", "IdPais");
            DropColumn("dbo.Usuario", "CodigoPostal");
            DropColumn("dbo.Usuario", "Colonia");
            DropColumn("dbo.Usuario", "NumeroInterior");
            DropColumn("dbo.Usuario", "NumeroExterior");
            DropColumn("dbo.Usuario", "Calle");
            DropColumn("dbo.Usuario", "Sexo");
            DropColumn("dbo.Usuario", "SegundoApellido");
            DropColumn("dbo.Usuario", "PrimerApellido");
            DropColumn("dbo.Usuario", "Nombre");
            DropColumn("dbo.Usuario", "IdRolUsuario");
            DropColumn("dbo.Usuario", "NombreUsuario");
        }
    }
}
