using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.SqlServer
{
    public class DiasElegidosDAO : ConnectionToSQL
    {


        public void guardarDiasSeleccionados(int userID, DateTime dt)
        {
            //el using aqui sirve para liberar recursos una vez se use, llamara al metodo dispose cuando acabe todo el codigo de su interior
            using (var connection = GetConnection())//esto es porque hemos heredado de conectiosql que sino no estaria
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "insert into DiasElegidosVacas (Id_user,Dia) VALUES (@userid,@dt)";
                    command.Parameters.AddWithValue("@userid", userID);
                    
                    command.Parameters.AddWithValue("@dt", dt);
                    
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }

            }
        }

        public void quitarDiaElegido(int userID, DateTime dt)
        {
            //el using aqui sirve para liberar recursos una vez se use, llamara al metodo dispose cuando acabe todo el codigo de su interior
            using (var connection = GetConnection())//esto es porque hemos heredado de conectiosql que sino no estaria
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Delete from DiasElegidosVacas  where Id_user=@userid and Dia=@dt";
                    command.Parameters.AddWithValue("@userid", userID);
                    command.Parameters.AddWithValue("@dt", dt);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }

            }
        }


        public bool comprobarSiEstaElegido(int userID,DateTime dt)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select * from DiasElegidosVacas where Id_user=@user and Dia=@dt";
                    command.Parameters.AddWithValue("@user", userID);
                    command.Parameters.AddWithValue("@dt", dt);
                    

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        
                        return true;
                    }
                    return false;
                }

            }


        }
    }
}
