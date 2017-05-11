namespace CEMEX.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegionPlazaImmexPlazaOxxoDistritoTienda : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Municipio", "EstadoId", "dbo.Estado");
            CreateTable(
                "dbo.Distrito",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DistritoId = c.Int(nullable: false),
                        ClaveDistrito = c.String(nullable: false, maxLength: 50),
                        NombreDistrito = c.String(nullable: false, maxLength: 100),
                        Estatus = c.Int(nullable: false),
                        FechaAlta = c.DateTime(nullable: false),
                        FechaModifico = c.DateTime(),
                        IdUsuarioAlta = c.Int(nullable: false),
                        IdUsuarioModifico = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PlazaOxxo", t => t.DistritoId, cascadeDelete: true)
                .Index(t => t.DistritoId);
            
            CreateTable(
                "dbo.Tienda",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DistritoId = c.Int(nullable: false),
                        UniqueTienda = c.Guid(nullable: false),
                        CRTienda = c.String(nullable: false, maxLength: 50),
                        NombreTienda = c.String(nullable: false, maxLength: 100),
                        Calle = c.String(nullable: false, maxLength: 150),
                        Numero = c.String(nullable: false, maxLength: 20),
                        EntreCalles = c.String(nullable: false, maxLength: 150),
                        Colonia = c.String(nullable: false, maxLength: 100),
                        Municipio = c.String(nullable: false, maxLength: 100),
                        Ciudad = c.String(nullable: false, maxLength: 100),
                        Estado = c.String(nullable: false, maxLength: 100),
                        CodigoPostal = c.String(nullable: false, maxLength: 10),
                        Latitud = c.String(nullable: false, maxLength: 20),
                        Longitud = c.String(nullable: false, maxLength: 20),
                        EstatusTienda = c.String(nullable: false, maxLength: 20),
                        Estatus = c.Int(nullable: false),
                        FechaAlta = c.DateTime(nullable: false),
                        FechaModifico = c.DateTime(),
                        IdUsuarioAlta = c.Int(nullable: false),
                        IdUsuarioModifico = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Distrito", t => t.DistritoId, cascadeDelete: true)
                .Index(t => t.DistritoId);
            
            CreateTable(
                "dbo.PlazaImmex",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RegionId = c.Int(nullable: false),
                        CRPlazaImmex = c.String(nullable: false, maxLength: 50),
                        NombrePlazaImmex = c.String(nullable: false, maxLength: 100),
                        Estatus = c.Int(nullable: false),
                        FechaAlta = c.DateTime(nullable: false),
                        FechaModifico = c.DateTime(),
                        IdUsuarioAlta = c.Int(nullable: false),
                        IdUsuarioModifico = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Region", t => t.RegionId, cascadeDelete: true)
                .Index(t => t.RegionId);
            
            CreateTable(
                "dbo.PlazaOxxo",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PlazaImmexId = c.Int(nullable: false),
                        CRPlazaOxxo = c.String(nullable: false, maxLength: 50),
                        NombrePlazaOxxo = c.String(nullable: false, maxLength: 100),
                        Estatus = c.Int(nullable: false),
                        FechaAlta = c.DateTime(nullable: false),
                        FechaModifico = c.DateTime(),
                        IdUsuarioAlta = c.Int(nullable: false),
                        IdUsuarioModifico = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PlazaImmex", t => t.PlazaImmexId, cascadeDelete: true)
                .Index(t => t.PlazaImmexId);
            
            CreateTable(
                "dbo.Region",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IdNegocio = c.Int(nullable: false),
                        ClaveRegion = c.String(nullable: false, maxLength: 50),
                        NombreRegion = c.String(nullable: false, maxLength: 100),
                        Estatus = c.Int(nullable: false),
                        FechaAlta = c.DateTime(nullable: false),
                        FechaModifico = c.DateTime(),
                        IdUsuarioAlta = c.Int(nullable: false),
                        IdUsuarioModifico = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            DropTable("dbo.ActividadPGV");
            DropTable("dbo.Campania");
            DropTable("dbo.TipoProspecto");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TipoProspecto",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 100),
                        Estatus = c.Int(nullable: false),
                        FechaAlta = c.DateTime(nullable: false),
                        FechaModifico = c.DateTime(),
                        IdUsuarioAlta = c.Int(nullable: false),
                        IdUsuarioModifico = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Campania",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        Estatus = c.Int(nullable: false),
                        FechaAlta = c.DateTime(nullable: false),
                        FechaModifico = c.DateTime(),
                        IdUsuarioAlta = c.Int(nullable: false),
                        IdUsuarioModifico = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ActividadPGV",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 100),
                        Estatus = c.Int(nullable: false),
                        FechaAlta = c.DateTime(nullable: false),
                        FechaModifico = c.DateTime(),
                        IdUsuarioAlta = c.Int(nullable: false),
                        IdUsuarioModifico = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            DropForeignKey("dbo.PlazaImmex", "RegionId", "dbo.Region");
            DropForeignKey("dbo.PlazaOxxo", "PlazaImmexId", "dbo.PlazaImmex");
            DropForeignKey("dbo.Distrito", "DistritoId", "dbo.PlazaOxxo");
            DropForeignKey("dbo.Tienda", "DistritoId", "dbo.Distrito");
            DropIndex("dbo.PlazaOxxo", new[] { "PlazaImmexId" });
            DropIndex("dbo.PlazaImmex", new[] { "RegionId" });
            DropIndex("dbo.Tienda", new[] { "DistritoId" });
            DropIndex("dbo.Distrito", new[] { "DistritoId" });
            DropTable("dbo.Region");
            DropTable("dbo.PlazaOxxo");
            DropTable("dbo.PlazaImmex");
            DropTable("dbo.Tienda");
            DropTable("dbo.Distrito");
            AddForeignKey("dbo.Municipio", "EstadoId", "dbo.Estado", "ID", cascadeDelete: true);
        }
    }
}
