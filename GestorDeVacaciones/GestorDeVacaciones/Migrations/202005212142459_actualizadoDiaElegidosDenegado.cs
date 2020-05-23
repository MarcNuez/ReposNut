namespace GestorDeVacaciones.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class actualizadoDiaElegidosDenegado : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DiasElegidosModels", "Denegado", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DiasElegidosModels", "Denegado");
        }
    }
}
