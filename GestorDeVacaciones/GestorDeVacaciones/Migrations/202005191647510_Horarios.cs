namespace GestorDeVacaciones.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Horarios : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HorariosModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
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
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HorariosModels");
        }
    }
}
