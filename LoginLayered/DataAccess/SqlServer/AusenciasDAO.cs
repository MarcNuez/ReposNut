using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.SqlServer
{
    public class AusenciasDAO : ConnectionToSQL
    {

        public void guardarAusencia(int userID, string tipo, DateTime inicio,DateTime fin, string comentario)
        {
            //el using aqui sirve para liberar recursos una vez se use, llamara al metodo dispose cuando acabe todo el codigo de su interior
            using (var connection = GetConnection())//esto es porque hemos heredado de conectiosql que sino no estaria
            {
                connection.Open();
                using (var cmd = new SqlCommand("InsertarAusenciasProc", connection))
                {
                  
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_user", userID);
                    cmd.Parameters.AddWithValue("@tipo", tipo);
                    cmd.Parameters.AddWithValue("@fechaini", inicio);
                    cmd.Parameters.AddWithValue("@fechafin", fin);
                    cmd.Parameters.AddWithValue("@comentario", comentario);
                    cmd.ExecuteNonQuery();

                }

            }
        }





       
       
    }
}
