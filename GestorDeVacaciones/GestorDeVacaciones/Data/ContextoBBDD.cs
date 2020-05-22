using GestorDeVacaciones.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeVacaciones.Data
{
    public class ContextoBBDD : DbContext
    {

        public ContextoBBDD() : base("CadenaDeConexionLocal")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<ContextoBBDD>(null);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UserModel> Usuarios { get; set; }
        public DbSet<AusenciasModel> Ausencias { get; set; }
        public DbSet<TipoAusenciaModel> TiposAusencias { get; set; }

        public DbSet<DiasElegidosModel> DiasElegidos { get; set; }

        public DbSet<DiasPendientesModel> DiasPendientes { get; set; }

        public DbSet<FicharModel> Fichar { get; set; }
        public DbSet<HorariosModel> Horarios { get; set; }
    }
}
