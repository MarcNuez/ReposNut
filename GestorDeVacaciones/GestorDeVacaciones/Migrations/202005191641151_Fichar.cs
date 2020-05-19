namespace GestorDeVacaciones.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fichar : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FicharModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        dia = c.DateTime(nullable: false),
                        diaLaboral = c.Boolean(nullable: false),
                        horarioID = c.Int(nullable: false),
                        entrada1 = c.Time(nullable: false, precision: 7),
                        salida1 = c.Time(nullable: false, precision: 7),
                        entrada2 = c.Time(nullable: false, precision: 7),
                        salida2 = c.Time(nullable: false, precision: 7),
                        warning = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FicharModels");
        }
    }
}
