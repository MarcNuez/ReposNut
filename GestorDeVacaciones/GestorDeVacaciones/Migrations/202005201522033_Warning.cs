namespace GestorDeVacaciones.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Warning : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WarningModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        descripcion = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WarningModels");
        }
    }
}
