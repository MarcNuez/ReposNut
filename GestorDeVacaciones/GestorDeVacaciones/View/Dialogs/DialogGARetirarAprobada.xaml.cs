using GestorDeVacaciones.Data;
using GestorDeVacaciones.Model;
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
    /// Lógica de interacción para DialogGARetirarAprobada.xaml
    /// </summary>
    public partial class DialogGARetirarAprobada : Window
    {

        private DiasElegidosModel diaADenegarOAprobar;
        public DialogGARetirarAprobada(DiasElegidosModel d)
        {
            InitializeComponent();
            MouseDown += Window_MouseDown;
            diaADenegarOAprobar = d;
        }


        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        private void aceptar(object sender, RoutedEventArgs e)
        {

            using (var db = new ContextoBBDD())
            {
                var result = db.DiasElegidos.SingleOrDefault(x => x.UserModelId == diaADenegarOAprobar.UserModelId
               && x.Dia == diaADenegarOAprobar.Dia && x.Mes == diaADenegarOAprobar.Mes && x.Año == diaADenegarOAprobar.Año);
                if (result != null)
                {
                    result.Aprobado = false;
                    db.SaveChanges();
                }
            }
            this.Close();

        }

        private void CerrarVentana(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
