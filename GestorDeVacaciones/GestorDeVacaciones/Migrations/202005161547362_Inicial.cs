namespace GestorDeVacaciones.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AusenciasModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserModelId = c.Int(nullable: false),
                        TipoAusenciaModelId = c.Int(nullable: false),
                        FechaInicio = c.DateTime(nullable: false),
                        FechaFinal = c.DateTime(nullable: false),
                        Comentario = c.String(),
                        Denegada = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TipoAusenciaModels", t => t.TipoAusenciaModelId, cascadeDelete: true)
                .ForeignKey("dbo.UserModels", t => t.UserModelId, cascadeDelete: true)
                .Index(t => t.UserModelId)
                .Index(t => t.TipoAusenciaModelId);
            
            CreateTable(
                "dbo.TipoAusenciaModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tipo = c.String(),
                        Descripcion = c.String(),
                        Denegable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        Nombre = c.String(),
                        Apellidos = c.String(),
                        Email = c.String(),
                        Rol = c.String(),
                        UrlImage = c.String(),
                        DiasPendientes_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DiasPendientesModels", t => t.DiasPendientes_Id)
                .Index(t => t.DiasPendientes_Id);
            
            CreateTable(
                "dbo.DiasPendientesModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserModelId = c.Int(nullable: false),
                        DiasQueCorresponden = c.Int(nullable: false),
                        DiasQueMeQuedan = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VacacionesElegidasModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserModelId = c.Int(nullable: false),
                        TotalDias = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserModels", t => t.UserModelId, cascadeDelete: true)
                .Index(t => t.UserModelId);
            
            CreateTable(
                "dbo.DiasElegidosModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Dia = c.Int(nullable: false),
                        Mes = c.Int(nullable: false),
                        Año = c.Int(nullable: false),
                        Aprobado = c.Boolean(nullable: false),
                        VacacionesElegidasModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VacacionesElegidasModels", t => t.VacacionesElegidasModel_Id)
                .Index(t => t.VacacionesElegidasModel_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VacacionesElegidasModels", "UserModelId", "dbo.UserModels");
            DropForeignKey("dbo.DiasElegidosModels", "VacacionesElegidasModel_Id", "dbo.VacacionesElegidasModels");
            DropForeignKey("dbo.UserModels", "DiasPendientes_Id", "dbo.DiasPendientesModels");
            DropForeignKey("dbo.AusenciasModels", "UserModelId", "dbo.UserModels");
            DropForeignKey("dbo.AusenciasModels", "TipoAusenciaModelId", "dbo.TipoAusenciaModels");
            DropIndex("dbo.DiasElegidosModels", new[] { "VacacionesElegidasModel_Id" });
            DropIndex("dbo.VacacionesElegidasModels", new[] { "UserModelId" });
            DropIndex("dbo.UserModels", new[] { "DiasPendientes_Id" });
            DropIndex("dbo.AusenciasModels", new[] { "TipoAusenciaModelId" });
            DropIndex("dbo.AusenciasModels", new[] { "UserModelId" });
            DropTable("dbo.DiasElegidosModels");
            DropTable("dbo.VacacionesElegidasModels");
            DropTable("dbo.DiasPendientesModels");
            DropTable("dbo.UserModels");
            DropTable("dbo.TipoAusenciaModels");
            DropTable("dbo.AusenciasModels");
        }
    }
}
