namespace GestorDeVacaciones.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class retoquebbddfichaje : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FicharModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserModelId = c.Int(nullable: false),
                        dia = c.DateTime(nullable: false),
                        diaLaboral = c.Boolean(nullable: false),
                        HorariosModelId = c.Int(nullable: false),
                        entrada1 = c.Time(nullable: false, precision: 7),
                        salida1 = c.Time(nullable: false, precision: 7),
                        entrada2 = c.Time(nullable: false, precision: 7),
                        salida2 = c.Time(nullable: false, precision: 7),
                        warning = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HorariosModels", t => t.HorariosModelId, cascadeDelete: true)
                .ForeignKey("dbo.UserModels", t => t.UserModelId, cascadeDelete: true)
                .Index(t => t.UserModelId)
                .Index(t => t.HorariosModelId);
            
            CreateTable(
                "dbo.HorariosModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        lunes = c.Boolean(nullable: false),
                        martes = c.Boolean(nullable: false),
                        miercoles = c.Boolean(nullable: false),
                        jueves = c.Boolean(nullable: false),
                        viernes = c.Boolean(nullable: false),
                        sabado = c.Boolean(nullable: false),
                        domingo = c.Boolean(nullable: false),
                        jornadaCompleta = c.Boolean(nullable: false),
                        entrada1 = c.Time(nullable: false, precision: 7),
                        salida1 = c.Time(nullable: false, precision: 7),
                        entrada2 = c.Time(nullable: false, precision: 7),
                        salida2 = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FicharModels", "UserModelId", "dbo.UserModels");
            DropForeignKey("dbo.FicharModels", "HorariosModelId", "dbo.HorariosModels");
            DropIndex("dbo.FicharModels", new[] { "HorariosModelId" });
            DropIndex("dbo.FicharModels", new[] { "UserModelId" });
            DropTable("dbo.HorariosModels");
            DropTable("dbo.FicharModels");
        }
    }
}
