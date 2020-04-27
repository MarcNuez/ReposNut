using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Comun;
using Comun.Cache;

namespace DataAccess
{
    public class UserDAO:ConnectionToSQL //hereda de conectioToSql que contiene el string con la direccion de la base de datos
    {
        public void editProfile(int id,string userName,string password,string name,string lastName,string mail)
        {
            //el using aqui sirve para liberar recursos una vez se use, llamara al metodo dispose cuando acabe todo el codigo de su interior
            using(var connection = GetConnection())//esto es porque hemos heredado de conectiosql que sino no estaria
            {
                connection.Open();
                using(var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "update Users set " + "LoginName=@userName, Password=@pass, FirstName=@name, LastName=@lastName,Email=@mail where UserId=@id";
                    command.Parameters.AddWithValue("@userName",userName);
                    command.Parameters.AddWithValue("@pass", password);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@lastName", lastName);
                    command.Parameters.AddWithValue("@mail", mail);
                    command.Parameters.AddWithValue("@id", id);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
            }
        }





        public bool Login(string user,string pass)
        {
            using(var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select * from Users where LoginName=@user and Password=@pass";
                    command.Parameters.AddWithValue("@user", user);
                    command.Parameters.AddWithValue("@pass", pass);
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)//si tiene filas true
                    {
                        while (reader.Read())
                        {

                            //popr lo visto esto guarda en cache, digamos que es temporal
                            UserLoginCache.IdUser = reader.GetInt32(0);
                            UserLoginCache.LoginName = reader.GetString(1);
                            UserLoginCache.Password = reader.GetString(2);
                            UserLoginCache.FirstName = reader.GetString(3);
                            UserLoginCache.LastName = reader.GetString(4);
                            UserLoginCache.Position = reader.GetString(5);
                            UserLoginCache.Email = reader.GetString(6);
                            



                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }


                }
         
            }


        }

        public string recoverPassword(string userRequesting)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select * from Users where LoginName=@user or Email=@mail";
                    command.Parameters.AddWithValue("@user", userRequesting);
                    command.Parameters.AddWithValue("@mail", userRequesting);
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();

                    if(reader.Read() == true)
                    {
                        string userName = reader.GetString(3)+", "+reader.GetString(4);
                        string userMail = reader.GetString(6);
                        string accountPassword = reader.GetString(2);
                       



                        var mailService = new MailServices.SystemSupportMail();
                        mailService.sendMail(
                            subject: "SYSTEM: Password recovery request",
                            body: "Hi, " + userName + "\nYou request to recover your password. \n" +
                            "your current password is:" + accountPassword +
                            "\nhowever, we ask that you change your password inmediately once you enter the system",
                            recipientMail: new List<string> { userMail });
                        return "Hi, " + userName + "\nYou request to recover your password. \n" +
                        "your current password is:" + accountPassword +
                        "\nhowever, we ask that you change your password inmediately once you enter the system";
                    }
                    else
                    {
                        return "sorry, you do not have an account with that mail or username";
                    }
                }
            }
        }



        public void AnyMethod()
        {
            if (UserLoginCache.Position == Cargos.Administrador)
            {

            }
            if(UserLoginCache.Position==Cargos.Manager || UserLoginCache.Position == Cargos.Algo)
            {

            }
        }

    }
}
