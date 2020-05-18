using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccess
{
    public abstract class ConnectionToSQL
    {
        private readonly string connectionString;
        public ConnectionToSQL()
        {
            //Pon aqui tu server
            connectionString = "Server=tcp:damproyecto.database.windows.net,1433;Initial Catalog=ProyectoDam;Persist Security Info=False;User ID=marcymarta;Password=Proyecto20;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        }
//holaa
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
