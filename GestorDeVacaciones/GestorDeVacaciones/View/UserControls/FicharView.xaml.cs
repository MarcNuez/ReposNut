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
    /// Lógica de interacción para FicharView.xaml
    /// </summary>
    public partial class FicharView : UserControl
    {
        public FicharView()
        {
            InitializeComponent();
        }

        private void btn_entrar_Click(object sender, RoutedEventArgs e)
        {
            registrarEntrada();
        }

        private void btn_salir_Click(object sender, RoutedEventArgs e)
        {
            registrarSalida();
        }

        private void registrarEntrada()
        {

        }
        private void registrarSalida()
        {

        }
        private void mostrarUltimosDiezRegistros()
        {
            //scv_marcajes.Content+=
        }
    }
}
