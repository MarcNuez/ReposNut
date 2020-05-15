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

        public ContextoBBDD():base("CadenaDeConexionConAzure")
        {

        }

        public DbSet<UserModel> Usuarios { get; set; }
    }
}
