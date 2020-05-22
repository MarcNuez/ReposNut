namespace GestorDeVacaciones.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class horarios2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HorariosModels", "nombre", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HorariosModels", "nombre");
        }
    }
}
