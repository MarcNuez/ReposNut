using GestorDeVacaciones.Data;
using GestorDeVacaciones.Model;
using GestorDeVacaciones.Model.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GestorDeVacaciones.View
{
    /// <summary>
    /// Lógica de interacción para LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }



        private void Login(object sender, RoutedEventArgs e)
        {

            var user = new UserModel();
            using (var db = new ContextoBBDD())
            {
                user = db.Usuarios
                      .Where(x => x.UserName == txtUsuario.Text && x.Password == txtContraseña.Password)
                      .FirstOrDefault();

            }


            if (user != null)
            {
              

                UserLoginCache.Id = user.Id;
                UserLoginCache.UserName = user.UserName;
                UserLoginCache.Password = user.Password;
                UserLoginCache.Nombre = user.Nombre;
                UserLoginCache.Apellidos = user.Apellidos;
                UserLoginCache.Rol = user.Rol;
                UserLoginCache.Email = user.Email;
                UserLoginCache.UrlImage = user.UrlImage;

                MenuPrincipalView mp = new MenuPrincipalView();

                mp.Show();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
            }
        }
    }
}
