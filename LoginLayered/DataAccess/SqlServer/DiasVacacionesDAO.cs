using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Comun.Cache;

namespace DataAccess.SqlServer
{
    public class DiasVacacionesDAO : ConnectionToSQL
    {

        public int obtenerDias()
        {

            using (var connection = GetConnection())
            {

                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select * from DiasVacaciones where Id_User=" + UserLoginCache.IdUser;

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)//si tiene filas true
                    {
                        while (reader.Read())
                        {
                            //la columna 3 que es la que tiene los dias que le faltan por consumir
                            return reader.GetInt32(3);

                        }

                    }
                    return 22;
                }

            }





        }


        public int obtenerDiasMaximo()
        {

            using (var connection = GetConnection())
            {

                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select * from DiasVacaciones where Id_User=" + UserLoginCache.IdUser;

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)//si tiene filas true
                    {
                        while (reader.Read())
                        {
                            //la columna 3 que es la que tiene los dias que le faltan por consumir
                            return reader.GetInt32(2);

                        }

                    }
                    return 22;
                }

            }

        }
        public void cambiarDiasGastados(int dias)
        {

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "update DiasVacaciones set DiasFaltan=@dias where Id_User="+UserLoginCache.IdUser;
                    command.Parameters.AddWithValue("@dias", dias);
                    
                    command.ExecuteNonQuery();
                }
            }

        }


        public void sumarDiasCancelados(int diasSumar)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "update DiasVacaciones set DiasFaltan=DiasFaltan+@diasSumar where Id_User=" + UserLoginCache.IdUser;
                    command.Parameters.AddWithValue("@diasSumar", diasSumar);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
