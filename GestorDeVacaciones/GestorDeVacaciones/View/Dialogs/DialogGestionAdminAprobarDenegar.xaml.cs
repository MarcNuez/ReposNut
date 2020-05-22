using GestorDeVacaciones.Data;
using GestorDeVacaciones.Model;
using GestorDeVacaciones.ViewModel.DialogViewModel;
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

namespace GestorDeVacaciones.View.Dialogs
{
    /// <summary>
    /// Lógica de interacción para DialogGestionAdminAprobarDenegar.xaml
    /// </summary>
    public partial class DialogGestionAdminAprobarDenegar : Window
    {
        public string TextoDialog { get; set; }
        private DiasElegidosModel diaADenegarOAprobar;
        
        public DialogGestionAdminAprobarDenegar(DiasElegidosModel d)
        {
            InitializeComponent();
            
            MouseDown += Window_MouseDown;

            diaADenegarOAprobar = d;
            TextoDialog = "Que quiere hacer con el dia: " + d.diaFormato+ " del usuario: " + d.Usuario.Nombre +
                " "+d.Usuario.Apellidos;

        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }


       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void aprobar(object sender, RoutedEventArgs e)
        {
            using (var db = new ContextoBBDD())
            {
                var result = db.DiasElegidos.SingleOrDefault(x => x.UserModelId == diaADenegarOAprobar.UserModelId
                && x.Dia == diaADenegarOAprobar.Dia && x.Mes == diaADenegarOAprobar.Mes && x.Año == diaADenegarOAprobar.Año);
                if (result != null)
                {
                    result.Aprobado = true;
                    db.SaveChanges();
                }



            }
            this.Close();
        }

        private void denegar(object sender, RoutedEventArgs e)
        {
            using (var db = new ContextoBBDD())
            {

                var result = db.DiasElegidos.SingleOrDefault(x => x.UserModelId == diaADenegarOAprobar.UserModelId
                && x.Dia == diaADenegarOAprobar.Dia && x.Mes == diaADenegarOAprobar.Mes && x.Año == diaADenegarOAprobar.Año);
                if (result != null)
                {
                    result.Denegado = true;
                    db.SaveChanges();
                }

            }
            this.Close();
        }
    }


}
