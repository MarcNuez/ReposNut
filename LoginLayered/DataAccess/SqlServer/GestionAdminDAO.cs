using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.SqlServer
{
    public class GestionAdminDAO : ConnectionToSQL
    {

        public DataTable obtenerVacacionesUsuarios()
        {
            DataTable dt = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var cmd = new SqlCommand("cargarDgvVacaciones", connection))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    var lista = cmd.ExecuteReader();
                    dt.Load(lista);



                }
                return dt;

            }
        }


    }
}
