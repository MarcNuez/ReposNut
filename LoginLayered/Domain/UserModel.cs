using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Domain
{
    public class UserModel
    {
        //en el modelo de user creamos una instancia de userDAO que es la capa que se encarga de conectarse 
        //a la base de datos
        UserDAO userDAO = new UserDAO();

        //el modelo tiene sus atributos
        private int idUSer;
        private string loginName;
        private string password;
        private string firstName;
        private string lastName;
        private string position;
        private string email;

        //su contructor
        public UserModel(int idUSer, string loginName, string password, string firstName, string lastName, string position, string email)
        {
            this.idUSer = idUSer;
            this.loginName = loginName;
            this.password = password;
            this.firstName = firstName;
            this.lastName = lastName;
            this.position = position;
            this.email = email;
        }
        public UserModel()
        {

        }

        public string editUserProfile()
        {
            try
            {
                userDAO.editProfile(idUSer, loginName, password, firstName, lastName, email);
                LoginUser(loginName, password);
                return "Todo ok";
            }catch(Exception ex)
            {
                return "Nombre ya registrado";
            }
        
        }



        public bool LoginUser(string user, string pass)
        {
            return userDAO.Login(user, pass);
        }


        public string recoverPassword(string userRequesting)
        {
            return userDAO.recoverPassword(userRequesting);
        }


    }
}
