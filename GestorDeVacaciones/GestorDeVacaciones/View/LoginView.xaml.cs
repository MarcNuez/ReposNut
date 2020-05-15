using GestorDeVacaciones.Data;
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
            var validLogin = false;

            using (var db = new ContextoBBDD())
            {
                //return db.User.Find(userId);
                //db.SaveChanges();
            }

            if (txtUsuario.Text == "admin" && txtContraseña.Password == "admin")
                {
                    validLogin = true;
                }

            if (validLogin)
            {
                MenuPrincipalView mp = new MenuPrincipalView();
                mp.Show();
            }
            else
            {

            }
        }
    }
}
