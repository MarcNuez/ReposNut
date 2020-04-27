using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.SqlServer
{
    public class TiposAusenciasDAO : ConnectionToSQL
    {


        public DataTable obtenerTiposAusencia()
        {
            DataTable dt = new DataTable();

            using (var connection = GetConnection())//esto es porque hemos heredado de conectiosql que sino no estaria
            {
                connection.Open();
                using (var cmd = new SqlCommand("cargarCmbTiposAusencia", connection))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    var lista = cmd.ExecuteReader();
                    dt.Load(lista);
                    
                }

            }
            return dt;

        }


    }
}
