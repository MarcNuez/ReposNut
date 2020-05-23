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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GestorDeVacaciones.View.UserControls
{
    /// <summary>
    /// Lógica de interacción para GestorAdminView.xaml
    /// </summary>
    public partial class GestorAdminView : UserControl
    {
        public GestorAdminView()
        {
            InitializeComponent();
        }

        private void abrirCalendarGrupal(object sender, RoutedEventArgs e)
        {
            CalendarioGrupalView cgv = new CalendarioGrupalView();
            cgv.Show();
        }

        private void abrirAusenciasGestion(object sender, RoutedEventArgs e)
        {

            AusenciasGestionAdminView agav = new AusenciasGestionAdminView();
            agav.Show();

        }
    }
}
