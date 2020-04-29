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

        public void aprobarVacaciones(int id)
        {


            using (var connection = GetConnection())
            {
                connection.Open();
                using (var cmd = new SqlCommand("aprobarVacaciones", connection))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id",id);
                    cmd.ExecuteNonQuery();




                }


            }
        }

        public void denegarVacaciones(int id,int id_user, DateTime dia, int id_admin, string nombre_admin,string comentario)
        {


            using (var connection = GetConnection())
            {
                connection.Open();
                using (var cmd = new SqlCommand("denegarVacaciones", connection))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@id_user", id_user);
                    cmd.Parameters.AddWithValue("@dia", dia);
                    cmd.Parameters.AddWithValue("@id_admin", id_admin);
                    cmd.Parameters.AddWithValue("@nombre_admin", nombre_admin);
                    cmd.Parameters.AddWithValue("@comentario", comentario);

                    cmd.ExecuteNonQuery();




                }


            }
        }

    }
}
